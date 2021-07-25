﻿using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserProfile> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, DisplayName, Email, IslandName, IslandPhrase
                                         FROM UserProfile";

                    var reader = cmd.ExecuteReader();

                    var userProfiles = new List<UserProfile>();

                    while (reader.Read())
                    {
                        userProfiles.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            DisplayName = DbUtils.GetString(reader, "DisplayName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            IslandName = DbUtils.GetString(reader, "IslandName"),
                            IslandPhrase = DbUtils.GetString(reader, "IslandPhrase")
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
                    cmd.CommandText = @"SELECT Id, DisplayName, Email, IslandName, IslandPhrase
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
                            DisplayName = DbUtils.GetString(reader, "DisplayName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            IslandName = DbUtils.GetString(reader, "IslandName"),
                            IslandPhrase = DbUtils.GetString(reader, "IslandPhrase")
                        };
                    }

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
                        INSERT INTO UserProfile ([DisplayName], Email, IslandName, IslandPhrase)
                        OUTPUT INSERTED.ID
                        VALUES (@Name, @Email, @IslandName, @IslandPhrase)";

                    DbUtils.AddParameter(cmd, "@Name", userProfile.DisplayName);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@IslandName", userProfile.IslandName);
                    DbUtils.AddParameter(cmd, "@IslandPhrase", userProfile.IslandPhrase);

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
                            SET DisplayName = @Name,
                                Email = @Email,
                                IslandName = @IslandName,
                                IslandPhrase = @IslandPhrase
                        WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@DisplayName", userProfile.DisplayName);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@IslandName", userProfile.IslandName);
                    DbUtils.AddParameter(cmd, "@IslandPhrase", userProfile.IslandPhrase);
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
                        SELECT up.Id, up.FirebaseUserId, up.DisplayName AS UserProfileDisplayName, up.Email, up.IslandName. up.IslandPhrase            
                        FROM UserProfile up
                        WHERE FirebaseUserId = @FirebaseUserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            DisplayName = DbUtils.GetString(reader, "UserProfileDisplayName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            IslandName = DbUtils.GetString(reader, "IslandName"),
                            IslandPhrase = DbUtils.GetString(reader, "IslandPhrase")
                        };
                    }
                    reader.Close();

                    return userProfile;
                }
            }
        }
    }
}