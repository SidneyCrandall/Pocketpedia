using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Pocketpedia.Models;
using Pocketpedia.Utils;

// These methods connect the controller to the database, which then communicates to the controller to tell the React component to render
namespace Pocketpedia.Repositories
{
    public class NotesRepository : BaseRepository, INotesRepository
    {
        public NotesRepository(IConfiguration configuration) : base(configuration) { }

        // A user will be able to navigate thru a link to see all the notes they have written on their page 
        public List<Notes> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT n.Id, n.Title, n.Message, n.CreateDateTime, n.UserProfileId
                                        FROM Notes n
                                        ORDER BY n.CreateDateTime Desc";

                    var reader = cmd.ExecuteReader();

                    var notes = new List<Notes>();

                    while (reader.Read())
                    {
                        notes.Add(NewNotesFromReader(reader));
                    }

                    reader.Close();

                    return notes;
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
                              u.Email
                         FROM Notes n
                              LEFT JOIN UserProfile u ON n.UserProfileId = u.id
                        WHERE CreateDateTime < SYSDATETIME() AND u.FirebaseUserId = @FirebaseUserId
                        ORDER BY CreateDateTime DESC";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", FirebaseUserId);

                    var reader = cmd.ExecuteReader();

                    var notes = new List<Notes>();

                    while (reader.Read())
                    {
                        notes.Add(NewNotesFromReader(reader));
                    }

                    reader.Close();

                    return notes;
                }
            }
        }

        // When a user would like to see the details of a note or wish to delete or edit the note, a getbyid() mnethod is needed
        public Notes GetNotesById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT n.Id AS NotesId, n.Title, n.Message, n.CreateDateTime, n.UserProfileId
                                       FROM Notes n                                   
                                       WHERE n.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Notes notes = new Notes()
                        {

                            Id = DbUtils.GetInt(reader, "NotesId"),
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

        // Create a note that a user can track any important detail of the game.
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

        // Method called if I would like to edit a note do to wrong info, code changing, etc.
        public void UpdateNotes(Notes notes)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Notes
                                           SET Title = @title,
                                               Message = @message
                                         WHERE Id = @id";

                    DbUtils.AddParameter(cmd, "@title", notes.Title);
                    DbUtils.AddParameter(cmd, "@message", notes.Message);
                    DbUtils.AddParameter(cmd, "@id", notes.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Notes WHERE Id = @id;";

                    DbUtils.AddParameter(cmd, "@id",id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
