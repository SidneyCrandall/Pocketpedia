USE [Pocketpedia]
GO

SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO UserProfile 
	(Id, FirebaseUserId, Email, DisplayName, IslandName, IslandPhrase) 
VALUES 
	(1, 'WZ8zeLK1kIhe5GDydzhh8PSiOz02', 'sc@sc.com', 'Squidney', 'Gallifrey', 'Down and Out Island Dweller');
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Notes] ON
INSERT INTO Notes 
	(Id, Title, [Message], CreateDateTime, UserProfileId) 
VALUES 
	(1, 'Dream Code', 'Galifrey dream code is: 8675309JENNY', SYSDATETIME(), 1);
SET IDENTITY_INSERT [Notes] OFF