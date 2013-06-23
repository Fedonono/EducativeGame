/*
Navicat SQL Server Data Transfer

Source Server         : azure
Source Server Version : 110000
Source Host           : b2ch0nz980.database.windows.net:1433
Source Database       : EducationAll
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 110000
File Encoding         : 65001

Date: 2013-06-23 05:26:05
*/


-- ----------------------------
-- Table structure for Choice
-- ----------------------------
CREATE TABLE [Choice] (
[ID] int NOT NULL IDENTITY(1,1) ,
[idQuestion] int NOT NULL ,
[choice] nvarchar(50) NOT NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Choice
-- ----------------------------

-- ----------------------------
-- Records of Choice
-- ----------------------------
SET IDENTITY_INSERT [Choice] ON
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'1', N'2', N'82')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'2', N'3', N'8 h 45')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'3', N'4', N'170')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'4', N'2', N'91')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'5', N'2', N'102')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'6', N'3', N'9 h')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'7', N'3', N'9 h 15')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'8', N'4', N'30')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'9', N'4', N'17')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'10', N'5', N'Cahier')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'11', N'5', N'Crayon')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'12', N'5', N'Règle')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'13', N'5', N'Dictionnaire')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'14', N'6', N'Cahier')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'15', N'6', N'Crayon')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'16', N'6', N'Règle')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'17', N'6', N'Bibliothèque')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'18', N'7', N'Bibliothèque')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'19', N'7', N'Dictionnaire')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'20', N'7', N'Cahier')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'21', N'7', N'Crayon')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'22', N'8', N'Règle')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'23', N'8', N'Dictionnaire')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'24', N'8', N'Crayon')
GO
GO
INSERT INTO [Choice] ([ID], [idQuestion], [choice]) VALUES (N'25', N'8', N'Bibliothèque')
GO
GO
SET IDENTITY_INSERT [Choice] OFF
GO

-- ----------------------------
-- Table structure for Course
-- ----------------------------
CREATE TABLE [Course] (
[ID] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(50) NOT NULL ,
[idGrade] int NOT NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Course
-- ----------------------------

-- ----------------------------
-- Records of Course
-- ----------------------------
SET IDENTITY_INSERT [Course] ON
GO
INSERT INTO [Course] ([ID], [name], [idGrade]) VALUES (N'1', N'Autre', N'2')
GO
GO
INSERT INTO [Course] ([ID], [name], [idGrade]) VALUES (N'2', N'Anglais', N'2')
GO
GO
INSERT INTO [Course] ([ID], [name], [idGrade]) VALUES (N'3', N'Mathématiques', N'2')
GO
GO
INSERT INTO [Course] ([ID], [name], [idGrade]) VALUES (N'4', N'Anglais', N'3')
GO
GO
INSERT INTO [Course] ([ID], [name], [idGrade]) VALUES (N'5', N'Autre', N'3')
GO
GO
INSERT INTO [Course] ([ID], [name], [idGrade]) VALUES (N'6', N'Français', N'2')
GO
GO
INSERT INTO [Course] ([ID], [name], [idGrade]) VALUES (N'7', N'Mathématiques', N'1')
GO
GO
INSERT INTO [Course] ([ID], [name], [idGrade]) VALUES (N'8', N'Autre', N'1')
GO
GO
SET IDENTITY_INSERT [Course] OFF
GO

-- ----------------------------
-- Table structure for Dual
-- ----------------------------
CREATE TABLE [Dual] (
[ID] int NOT NULL IDENTITY(1,1) ,
[idChallenger] int NOT NULL ,
[idChallenged] int NOT NULL ,
[date] datetime NOT NULL ,
[idGame] int NOT NULL ,
[idScoreChallenger] int NOT NULL ,
[idScoreChallenged] int NULL DEFAULT NULL ,
[winner] int NULL DEFAULT NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Dual
-- ----------------------------

-- ----------------------------
-- Records of Dual
-- ----------------------------
SET IDENTITY_INSERT [Dual] ON
GO
SET IDENTITY_INSERT [Dual] OFF
GO

-- ----------------------------
-- Table structure for Game
-- ----------------------------
CREATE TABLE [Game] (
[ID] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(50) NOT NULL ,
[idCourse] int NOT NULL ,
[idQuestionary] int NULL ,
[description] ntext NULL ,
[className] nvarchar(50) NOT NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Game
-- ----------------------------

-- ----------------------------
-- Records of Game
-- ----------------------------
SET IDENTITY_INSERT [Game] ON
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'1', N'L''école CE1', N'6', N'1', N'Questionnaire vocabulaire sur l''école', N'QuestionaryControl')
GO
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'2', N'Pendu anglais CE1', N'2', null, N'Pendu en anglais pour se faire un peu de vocabulaire.', N'Hangman')
GO
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'3', N'Addition CE1', N'3', null, N'Teste tes facultés de calcul sur des tables d''additions !', N'Additions1_ce1')
GO
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'4', N'Mathématiques pour les CE1', N'3', N'2', N'Mathématiques pour les CE1', N'QuestionaryControl')
GO
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'5', N'Pendu anglais CE2', N'4', null, N'Pendu en anglais pour se faire un peu de vocabulaire.', N'Hangman')
GO
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'6', N'Coloriage CE1', N'1', null, N'Coloriage magique à imprimer.', N'Colouring')
GO
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'7', N'Addition CP', N'7', null, N'Teste tes facultés de calcul sur des tables d''additions !', N'Additions1_ce1')
GO
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'8', N'Coloriage CP', N'8', null, N'Coloriage magique à imprimer.', N'Colouring')
GO
GO
INSERT INTO [Game] ([ID], [name], [idCourse], [idQuestionary], [description], [className]) VALUES (N'9', N'Heure CE1', N'1', null, N'Apprend à lire l''heure.', N'HourReading')
GO
GO
SET IDENTITY_INSERT [Game] OFF
GO

-- ----------------------------
-- Table structure for Grade
-- ----------------------------
CREATE TABLE [Grade] (
[ID] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(50) NOT NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Grade
-- ----------------------------
CREATE INDEX [IX_Difficulty_0] ON [Grade]
([name] ASC) 
GO

-- ----------------------------
-- Records of Grade
-- ----------------------------
SET IDENTITY_INSERT [Grade] ON
GO
INSERT INTO [Grade] ([ID], [name]) VALUES (N'2', N'CE1')
GO
GO
INSERT INTO [Grade] ([ID], [name]) VALUES (N'3', N'CE2')
GO
GO
INSERT INTO [Grade] ([ID], [name]) VALUES (N'1', N'CP')
GO
GO
SET IDENTITY_INSERT [Grade] OFF
GO

-- ----------------------------
-- Table structure for Question
-- ----------------------------
CREATE TABLE [Question] (
[ID] int NOT NULL IDENTITY(1,1) ,
[question] nvarchar(250) NOT NULL ,
[answer] nvarchar(50) NOT NULL ,
[idQuestionary] int NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Question
-- ----------------------------

-- ----------------------------
-- Records of Question
-- ----------------------------
SET IDENTITY_INSERT [Question] ON
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'1', N'37 - 20 = ?', N'17', N'2')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'2', N'45 + 30 + 27 = ?', N'102', N'2')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'3', N'Je pars à 9 h 00, je mets 15 mn pour aller à l''école. À quelle heure vais-je arrivé ?', N'9 h 15', N'2')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'4', N'Wilfried avait 100 bonbons . Il en donne 70. Combien a-t-il de bonbons maintenant ?', N'30', N'2')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'5', N'J''utilise une _____ pour souligner le titre.', N'Règle', N'1')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'6', N'Je recopie l''exercice sur mon _______.', N'Cahier', N'1')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'7', N'Je choisis un nouveau livre dans la ____________.', N'Bibliothèque', N'1')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'8', N'J''écris avec un stylo, un feutre ou un ______.', N'Crayon', N'1')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'9', N'10 + 5', N'15', N'2')
GO
GO
INSERT INTO [Question] ([ID], [question], [answer], [idQuestionary]) VALUES (N'10', N'1,23 x 5,12 + 2,46', N'8,7576', N'2')
GO
GO
SET IDENTITY_INSERT [Question] OFF
GO

-- ----------------------------
-- Table structure for Questionary
-- ----------------------------
CREATE TABLE [Questionary] (
[ID] int NOT NULL IDENTITY(1,1) ,
[idGame] int NOT NULL ,
[name] nvarchar(50) NOT NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Questionary
-- ----------------------------

-- ----------------------------
-- Records of Questionary
-- ----------------------------
SET IDENTITY_INSERT [Questionary] ON
GO
INSERT INTO [Questionary] ([ID], [idGame], [name]) VALUES (N'1', N'1', N'L''école')
GO
GO
INSERT INTO [Questionary] ([ID], [idGame], [name]) VALUES (N'2', N'4', N'Mathématiques pour les CE1')
GO
GO
SET IDENTITY_INSERT [Questionary] OFF
GO

-- ----------------------------
-- Table structure for Rank
-- ----------------------------
CREATE TABLE [Rank] (
[ID] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(50) NOT NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Rank
-- ----------------------------

-- ----------------------------
-- Records of Rank
-- ----------------------------
SET IDENTITY_INSERT [Rank] ON
GO
INSERT INTO [Rank] ([ID], [name]) VALUES (N'1', N'Elève')
GO
GO
INSERT INTO [Rank] ([ID], [name]) VALUES (N'2', N'Professeur')
GO
GO
INSERT INTO [Rank] ([ID], [name]) VALUES (N'10', N'Admin')
GO
GO
SET IDENTITY_INSERT [Rank] OFF
GO

-- ----------------------------
-- Table structure for Relationship
-- ----------------------------
CREATE TABLE [Relationship] (
[userId1] int NOT NULL ,
[userId2] int NOT NULL ,
[ID] int NOT NULL IDENTITY(1,1) ,
PRIMARY KEY ([ID]),
UNIQUE ([userId1] ASC, [userId2] ASC)
)


GO

-- ----------------------------
-- Indexes structure for table Relationship
-- ----------------------------

-- ----------------------------
-- Records of Relationship
-- ----------------------------
SET IDENTITY_INSERT [Relationship] ON
GO
SET IDENTITY_INSERT [Relationship] OFF
GO

-- ----------------------------
-- Table structure for RelationshipRequest
-- ----------------------------
CREATE TABLE [RelationshipRequest] (
[ID] int NOT NULL IDENTITY(1,1) ,
[idCaller] int NOT NULL ,
[idCalled] int NOT NULL ,
PRIMARY KEY ([ID]),
UNIQUE ([idCaller] ASC, [idCalled] ASC)
)


GO

-- ----------------------------
-- Indexes structure for table RelationshipRequest
-- ----------------------------

-- ----------------------------
-- Records of RelationshipRequest
-- ----------------------------
SET IDENTITY_INSERT [RelationshipRequest] ON
GO
SET IDENTITY_INSERT [RelationshipRequest] OFF
GO

-- ----------------------------
-- Table structure for Score
-- ----------------------------
CREATE TABLE [Score] (
[ID] int NOT NULL IDENTITY(1,1) ,
[idUser] int NOT NULL ,
[idGame] int NOT NULL ,
[value] int NULL ,
PRIMARY KEY ([ID])
)


GO

-- ----------------------------
-- Indexes structure for table Score
-- ----------------------------

-- ----------------------------
-- Records of Score
-- ----------------------------
SET IDENTITY_INSERT [Score] ON
GO
SET IDENTITY_INSERT [Score] OFF
GO

-- ----------------------------
-- Table structure for User
-- ----------------------------
CREATE TABLE [User] (
[ID] int NOT NULL IDENTITY(1,1) ,
[username] nvarchar(15) NOT NULL ,
[password] nvarchar(40) NOT NULL ,
[mail] nvarchar(32) NULL ,
[name] nvarchar(50) NULL ,
[firstName] nvarchar(50) NULL ,
[idGrade] int NOT NULL ,
[idRank] int NOT NULL DEFAULT ((1)) ,
[birthDate] date NOT NULL ,
PRIMARY KEY ([ID]),
UNIQUE ([username] ASC)
)


GO

-- ----------------------------
-- Indexes structure for table User
-- ----------------------------

-- ----------------------------
-- Records of User
-- ----------------------------
SET IDENTITY_INSERT [User] ON
GO
INSERT INTO [User] ([ID], [username], [password], [mail], [name], [firstName], [idGrade], [idRank], [birthDate]) VALUES (N'1', N'admin', N'd033e22ae348aeb5660fc2140aec35850c4da997', N'admin@sharpentier.fr', N'Einstein', N'Albert', N'2', N'10', N'1879-03-14')
GO
GO
SET IDENTITY_INSERT [User] OFF
GO

-- ----------------------------
-- Foreign Key structure for table [Choice]
-- ----------------------------
ALTER TABLE [Choice] ADD FOREIGN KEY ([idQuestion]) REFERENCES [Question] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Course]
-- ----------------------------
ALTER TABLE [Course] ADD FOREIGN KEY ([idGrade]) REFERENCES [Grade] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Dual]
-- ----------------------------
ALTER TABLE [Dual] ADD FOREIGN KEY ([idChallenger]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Dual] ADD FOREIGN KEY ([idChallenged]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Dual] ADD FOREIGN KEY ([idGame]) REFERENCES [Game] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Dual] ADD FOREIGN KEY ([idScoreChallenger]) REFERENCES [Score] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Dual] ADD FOREIGN KEY ([idScoreChallenged]) REFERENCES [Score] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Dual] ADD FOREIGN KEY ([winner]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Game]
-- ----------------------------
ALTER TABLE [Game] ADD FOREIGN KEY ([idCourse]) REFERENCES [Course] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Game] ADD FOREIGN KEY ([idQuestionary]) REFERENCES [Questionary] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Question]
-- ----------------------------
ALTER TABLE [Question] ADD FOREIGN KEY ([idQuestionary]) REFERENCES [Questionary] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Questionary]
-- ----------------------------
ALTER TABLE [Questionary] ADD FOREIGN KEY ([idGame]) REFERENCES [Game] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Relationship]
-- ----------------------------
ALTER TABLE [Relationship] ADD FOREIGN KEY ([userId1]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Relationship] ADD FOREIGN KEY ([userId2]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [RelationshipRequest]
-- ----------------------------
ALTER TABLE [RelationshipRequest] ADD FOREIGN KEY ([idCaller]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [RelationshipRequest] ADD FOREIGN KEY ([idCalled]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Score]
-- ----------------------------
ALTER TABLE [Score] ADD FOREIGN KEY ([idGame]) REFERENCES [Game] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Score] ADD FOREIGN KEY ([idUser]) REFERENCES [User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [User]
-- ----------------------------
ALTER TABLE [User] ADD FOREIGN KEY ([idGrade]) REFERENCES [Grade] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [User] ADD FOREIGN KEY ([idRank]) REFERENCES [Rank] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
