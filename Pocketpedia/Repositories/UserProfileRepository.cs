using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class UserProfileRepository
    {
        public class UserProfileRepository : BaseRepository, IUserProfileRepository, IUserProfileRepository
        {
            public UserProfileRepository(IConfiguration configuration) : base(configuration) { }

            public List<UserProfile> GetAll()
            {
                using (var conn = Connection)
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT Id, Name, Email, ImageURl, DateCreated
                                         FROM UserProfile";

                        var reader = cmd.ExecuteReader();

                        var userProfiles = new List<UserProfile>();

                        while (reader.Read())
                        {
                            userProfiles.Add(new UserProfile()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                DateCreated = DbUtils.GetDateTime(reader, "DateCreated")
                            });
                        }

                        reader.Close();

                        return userProfiles;
                    }
                }
            }

            public UserProfile GetUserById(int id)
            {
                using (var conn = Connection)
                {

                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT Id, Name, Email, ImageUrl, DateCreated
                                        FROM UserProfile
                                        WHERE Id = @Id";

                        DbUtils.AddParameter(cmd, "@Id", id);

                        var reader = cmd.ExecuteReader();

                        UserProfile userProfile = null;

                        if (reader.Read())
                        {
                            userProfile = new UserProfile()
                            {
                                Id = id,
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                DateCreated = DbUtils.GetDateTime(reader, "DateCreated")
                            };
                        }

                        reader.Close();

                        return userProfile;
                    }
                }
            }

            public UserProfile GetUserWithVideos(int id)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT up.Id, up.Name, up.Email, up.ImageUrl, up.DateCreated,
                                               v.id as VideoId, v.title, v.description, v.url, v.datecreated as videoDateCreated, v.UserProfileId, 
                                               c.Id AS CommentId, c.Message, c.UserProfileId AS CommentUserProfileId, c.VideoId
                                        FROM Video v
                                        LEFT JOIN UserProfile up on up.id = v.userprofileid
                                        LEFT JOIN Comment c on c.VideoId = v.Id
                          
                                        WHERE up.Id = @Id";

                        DbUtils.AddParameter(cmd, "@Id", id);

                        var reader = cmd.ExecuteReader();

                        UserProfile userProfile = null;
                        while (reader.Read())
                        {
                            if (userProfile == null)
                            {
                                userProfile = new UserProfile()
                                {
                                    Id = id,
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                    DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                                    Videos = new List<Video>(),

                                };
                            }

                            if (DbUtils.IsNotDbNull(reader, "UserProfileId"))
                            {
                                var videoId = DbUtils.GetInt(reader, "VideoId");
                                var video = userProfile.Videos.FirstOrDefault(p => p.Id == videoId);

                                if (video == null)
                                {
                                    video = new Video()

                                    {
                                        Id = DbUtils.GetInt(reader, "VideoId"),
                                        Title = DbUtils.GetString(reader, "Title"),
                                        Description = DbUtils.GetString(reader, "Description"),
                                        Url = DbUtils.GetString(reader, "Url"),
                                        DateCreated = DbUtils.GetDateTime(reader, "VideoDateCreated"),
                                        UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                        Comments = new List<Comment>()

                                    };
                                    userProfile.Videos.Add(video);
                                }

                                if (DbUtils.IsNotDbNull(reader, "CommentId"))
                                {
                                    video.Comments.Add(new Comment()
                                    {
                                        Id = DbUtils.GetInt(reader, "CommentId"),
                                        Message = DbUtils.GetString(reader, "Message"),
                                        VideoId = DbUtils.GetInt(reader, "VideoId"),
                                        UserProfileId = DbUtils.GetInt(reader, "CommentUserProfileId")
                                    });

                                };
                            }
                        };

                        reader.Close();

                        return userProfile;
                    }
                }
            }

            public void Add(UserProfile userProfile)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        INSERT INTO UserProfile ([Name], Email, ImageUrl, DateCreated)
                        OUTPUT INSERTED.ID
                        VALUES (@Name, @Email, @ImageUrl, @DateCreated)";

                        DbUtils.AddParameter(cmd, "@Name", userProfile.Name);
                        DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                        DbUtils.AddParameter(cmd, "@ImageUrl", userProfile.ImageUrl);
                        DbUtils.AddParameter(cmd, "@DateCreated", userProfile.DateCreated);

                        userProfile.Id = (int)cmd.ExecuteScalar();
                    }
                }
            }

            public void Update(UserProfile userProfile)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        UPDATE UserProfile
                            SET Name = @Name,
                                Email = @Email,
                                ImageUrl = @ImageUrl,
                                DateCreated = @DateCreated
                        WHERE Id = @Id";

                        DbUtils.AddParameter(cmd, "@Name", userProfile.Name);
                        DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                        DbUtils.AddParameter(cmd, "@ImageUrl", userProfile.ImageUrl);
                        DbUtils.AddParameter(cmd, "@DateCreated", userProfile.DateCreated);
                        DbUtils.AddParameter(cmd, "@Id", userProfile.Id);

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
                        cmd.CommandText = "DELETE FROM UserProfile WHERE Id = @Id";
                        DbUtils.AddParameter(cmd, "@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public UserProfile GetByFirebaseUserId(string firebaseUserId)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        SELECT up.Id, up.FirebaseUserId, up.Name AS UserProfileName, up.Email, up.DateCreated, up.ImageUrl            
                        FROM UserProfile up
                        WHERE FirebaseUserId = @FirebaseuserId";

                        DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                        UserProfile userProfile = null;

                        var reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            userProfile = new UserProfile()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                                Name = DbUtils.GetString(reader, "UserProfileName"),
                                Email = DbUtils.GetString(reader, "Email"),
                                DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl")
                            };
                        }
                        reader.Close();

                        return userProfile;
                    }
                }
            }
        }
    }
}
}
