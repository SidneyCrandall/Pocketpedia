USE [Pocketpedia]
GO

SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] 
	(Id, FirebaseUserId, Email, DisplayName, IslandName, IslandPhrase) 
VALUES 
	(4, 'xjkgvP8WYNPmd5HC1xGMsm6xg082', 'sc@sc.com', 'Squidney', 'Gallifrey', 'Down and Out Island Dweller'),
	(5, 'UPn2xL58Q0Q9TDKNdnuMNEppG3U2', 'miko@mc.com', 'Mikosa', 'Carcosa', 'Festive Island Hopper');
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Notes] ON
INSERT INTO [Notes] 
	(Id, Title, [Message], CreateDateTime, UserProfileId) 
VALUES 
	(1, 'Dream Code', 'Galifrey dream code is: 8675309JENNY', SYSDATETIME(), 1),
	(2, 'Villager Gifts', 'Apple = red dress.', SYSDATETIME(), 1);
SET IDENTITY_INSERT [Notes] OFF

SET IDENTITY_INSERT [Location] ON
INSERT INTO [Location]
	(Id, [Name])
VALUES 
	(1, 'Flying'),
	(2, 'Flying near hybrid flowers'),
	(3, 'Flying by light'),
	(4, 'On trees'),
	(5, 'On the ground'),
	(6, 'On flowers'),
	(7, 'On white flowers'),
	(8, 'Shaking trees'),
	(9, 'Flying (near water)'),
	(10, 'Underground'),
	(11, 'On ponds and rivers'),
	(12, 'On tree stumps'),
	(13, 'On palm tress'),
	(14, 'On rotten food'),
	(15, 'On the beach'),
	(16, 'On beach rocks'),
	(17, 'Near trash'),
	(18, 'On villagers'),
	(19, 'On rocks and bush (when raining)'),
	(20, 'Hitting rocks'),
	(21, 'River'),
	(22, 'Pond'),
	(23, 'River (Clifftop)'),
	(24, 'River (Clifftop) & Pond'),
	(25, 'River (Mouth)'),
	(26, 'Sea'),
	(27, 'Pier'),
	(28, 'Sea (when raining or snowing)');
SET IDENTITY_INSERT [Location] OFF