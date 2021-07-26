using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Pocketpedia.Models;
using Pocketpedia.Utils;


namespace Pocketpedia.Repositories
{
    public class NotesRepository : INotesRepository
    {
        public NotesRepository(IConfiguration configuration) : base(configuration) { }

        public List<Notes> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT n.Id, n.Title, n.Message, n.CreatDateTime, n.UserProfileId
                         FROM Notes n
                              LEFT JOIN UserProfile u ON n.UserProfileId = u.id
                        ORDER BY p.CreateDateTime Desc";

                    var reader = cmd.ExecuteReader();

                    var posts = new List<Notes>();

                    while (reader.Read())
                    {
                        posts.Add(NewNotesFromReader(reader));
                    }

                    reader.Close();

                    return posts;
                }
            }
        }

        private Notes NewNotesFromReader(SqlDataReader reader)
        {
            return new Notes()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Message = reader.GetString(reader.GetOrdinal("Message")),
                CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),

                UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
            };
        }

        public List<Notes> GetUserNotes(string FirebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                       SELECT n.Id, n.Title, n.Message,
                              n.CreateDateTime, n.UserProfileId,
                              u.DisplayName, 
                              u.Email, u.CreateDateTime
                         FROM Notes n
                              LEFT JOIN UserProfile u ON n.UserProfileId = u.id
                        WHERE CreateDateTime < SYSDATETIME() AND u.FirebaseUserId = @FirebaseUserId
                        ORDER BY CreateDateTime DESC";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", FirebaseUserId);

                    var reader = cmd.ExecuteReader();

                    var posts = new List<Notes>();

                    while (reader.Read())
                    {
                        notes.Add(NewNotesFromReader(reader));
                    }

                    reader.Close();

                    return notes;
                }
            }
        }

        public Notes GetNotesById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT p.Id AS PostId, p.Title, p.Content, p.ImageLocation, p.PublishDateTime,
                                               c.Id AS CategoryId, c.[Name],
                                               up.Id AS UserProfileId, up.DisplayName
                                       FROM p
                                       LEFT JOIN Category c ON c.Id = p.CategoryId
                                       LEFT JOIN UserProfile up ON up.Id = p.UserProfileId
                                       WHERE p.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Notes notes = new Notes()
                        {
                            Id = DbUtils.GetInt(reader, "NOtesId"),
                            Title = DbUtils.GetString(reader, "Title"),
                            Message = DbUtils.GetString(reader, "Message"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        };
                        reader.Close();
                        return notes;
                    }

                    reader.Close();
                    return null;
                }
            }
        }

        public void Add(Notes notes)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Notes (Title, Message, CreateDateTime, UserProfileId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Title, @Message, @CreateDateTime, @UserProfileId)";

                    DbUtils.AddParameter(cmd, "@Title", notes.Title);
                    DbUtils.AddParameter(cmd, "@Message", notes.Message);
                    DbUtils.AddParameter(cmd, "@CreateDateTime", notes.CreateDateTime);
                    DbUtils.AddParameter(cmd, "@UserProfileId", notes.UserProfileId);

                    notes.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Notes notes)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Notes
                           SET Title = @Title,
                               Message = @Message,
                         WHERE id = @id";

                    DbUtils.AddParameter(cmd, "@Title", notes.Title);
                    DbUtils.AddParameter(cmd, "@Message", notes.Message);
                    DbUtils.AddParameter(cmd, "@id", notes.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int notesId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Post WHERE Id = @id;";

                    DbUtils.AddParameter(cmd, "@id", notesId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
