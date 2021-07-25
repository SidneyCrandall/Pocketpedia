USE [master]

IF db_id('Pocketpedia') IS NULL

CREATE DATABASE [Pocketpedia]
GO

USE [Pocketpedia]
GO

DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [SeasonAvailability];
DROP TABLE IF EXISTS [Location];
DROP TABLE IF EXISTS [Notes];
DROP TABLE IF EXISTS [Villagers];
DROP TABLE IF EXISTS [Bugs];
DROP TABLE IF EXISTS [Fish];
DROP TABLE IF EXISTS [SeaCreatures];
DROP TABLE IF EXISTS [Fossils];
DROP TABLE IF EXISTS [Art];
GO


CREATE TABLE [UserProfile] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [FirebaseUserId] VARCHAR(50) NOT NULL,
  [Email] VARCHAR(255) NOT NULL,
  [DisplayName] VARCHAR(255) NOT NULL,
  [IslandName] VARCHAR(255) NOT NULL,
  [IslandPhrase] VARCHAR(255) NOT NULL

  CONSTRAINT UQ_FirebaseUserId UNIQUE(FirebaseUserId)
)
GO

CREATE TABLE [SeasonAvailability] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Season] VARCHAR(255) NOT NULL
)
GO

CREATE TABLE [Location] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Location] VARCHAR(255) NOT NULL
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

CREATE TABLE [Villagers] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [Birthday] VARCHAR(255) NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [IsResiding] bit NOT NULL
)
GO

CREATE TABLE [Bugs] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [LocationId] INTEGER NOT NULL,
  [SeasonAvailabilityId] INTEGER NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [Caught] bit NOT NULL
)
GO

CREATE TABLE [Fish] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [LocationId] INTEGER NOT NULL,
  [SeasonAvailabilityId] INTEGER NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [Caught] bit NOT NULL
)
GO

CREATE TABLE [SeaCreatures] (
  [Id] INTEGER PRIMARY KEY IDENTITY NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [ImageUrl] VARCHAR(255) NOT NULL,
  [SeasonAvailabilityId] INTEGER NOT NULL,
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


ALTER TABLE [Notes] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Villagers] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Bugs] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Fish] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [SeaCreatures] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Fossils] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Art] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Bugs] ADD FOREIGN KEY ([SeasonAvailabilityId]) REFERENCES [SeasonAvailability] ([Id])
GO

ALTER TABLE [Bugs] ADD FOREIGN KEY ([LocationId]) REFERENCES [Location] ([Id])
GO

ALTER TABLE [Fish] ADD FOREIGN KEY ([SeasonAvailabilityId]) REFERENCES [SeasonAvailability] ([Id])
GO

ALTER TABLE [Fish] ADD FOREIGN KEY ([LocationId]) REFERENCES [Location] ([Id])
GO

ALTER TABLE [SeaCreatures] ADD FOREIGN KEY ([SeasonAvailabilityId]) REFERENCES [SeasonAvailability] ([Id])
GO