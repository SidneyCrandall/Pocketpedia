USE [master]
GO

IF db_id('Pocketpedia') IS NOT NULL
BEGIN
  ALTER DATABASE [Pocketpedia] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
  DROP DATABASE [Pocketpedia]
END
GO

CREATE DATABASE [Pocketpedia]
GO

USE [Pocketpedia]
GO

-- DROP TABLE IF EXISTS [Notes];
-- DROP TABLE IF EXISTS [Villager];
-- DROP TABLE IF EXISTS [UserProfile];
-- DROP TABLE IF EXISTS [Bugs];
-- DROP TABLE IF EXISTS [Fish];
-- DROP TABLE IF EXISTS [SeaCreatures];
-- DROP TABLE IF EXISTS [Fossils];
-- DROP TABLE IF EXISTS [Art];
-- DROP TABLE IF EXISTS [SeasonAvailbility];
-- DROP TABLE IF EXISTS [Location];
-- GO



CREATE TABLE [UserProfile] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [FirebaseUserId] VARCHAR(255) NOT NULL,
  [Email] VARCHAR(255) NOT NULL,
  [DisplayName] VARCHAR(255) NOT NULL,
  [IslandName] VARCHAR(255) NOT NULL,
  [IslandPhrase] VARCHAR(255) NOT NULL

  CONSTRAINT UQ_FirebaseUserId UNIQUE(FirebaseUserId),
)
GO

CREATE TABLE [Bugs] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [LocationId] INTEGER NOT NULL,
  [SeasonAvailbilityId] INTEGER NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [Caught] bit NOT NULL
)
GO

CREATE TABLE [Fish] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [LocationId] INTEGER NOT NULL,
  [SeasonAvailbilityId] INTEGER NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [Caught] bit NOT NULL
)
GO

CREATE TABLE [SeaCreatures] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [SeasonAvailbilityId] INTEGER NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [Caught] bit NOT NULL
)
GO

CREATE TABLE [Fossils] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [Discovered] bit NOT NULL
)
GO

CREATE TABLE [Art] (
   [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [IsReal] bit NOT NULL,
  [Obtained] bit NOT NULL
)
GO

CREATE TABLE [Villagers] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [Birthday] VARCHAR(255) NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [IsResiding] bit NOT NULL
)
GO

CREATE TABLE [Notes] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Title] VARCHAR(255) NOT NULL,
  [Message] VARCHAR(255) NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [CreateDateTime] datetime NOT NULL
)
GO

CREATE TABLE [SeasonAvailbility] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Season] VARCHAR(255) NOT NULL
)
GO

CREATE TABLE [Location] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [IslandLocation] VARCHAR(255) NOT NULL
)
GO



ALTER TABLE [Bugs] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Notes] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [SeaCreatures] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Fossils] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Fish] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Villagers] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Art] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Fish] ADD FOREIGN KEY ([LocationId]) REFERENCES [Location] ([Id])
GO

ALTER TABLE [Fish] ADD FOREIGN KEY ([SeasonAvailbilityId]) REFERENCES [SeasonAvailbility] ([Id])
GO

ALTER TABLE [SeasonAvailbility] ADD FOREIGN KEY ([Id]) REFERENCES [SeaCreatures] ([SeasonAvailbilityId])
GO

ALTER TABLE [SeasonAvailbility] ADD FOREIGN KEY ([Id]) REFERENCES [Bugs] ([SeasonAvailbilityId])
GO

ALTER TABLE [Location] ADD FOREIGN KEY ([Id]) REFERENCES [Bugs] ([LocationId])
GO