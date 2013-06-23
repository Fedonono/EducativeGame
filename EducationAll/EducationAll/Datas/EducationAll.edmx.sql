
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/23/2013 04:36:49
-- Generated from EDMX file: C:\Users\isen\Desktop\Docs\Visual_Studio\EducationAll\EducationAll\EducationAll\Datas\EducationAll.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EducationAll];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AddRequest_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationshipRequest] DROP CONSTRAINT [FK_AddRequest_0];
GO
IF OBJECT_ID(N'[dbo].[FK_AddRequest_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationshipRequest] DROP CONSTRAINT [FK_AddRequest_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Choice_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Choice] DROP CONSTRAINT [FK_Choice_0];
GO
IF OBJECT_ID(N'[dbo].[FK_Course_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Course] DROP CONSTRAINT [FK_Course_0];
GO
IF OBJECT_ID(N'[dbo].[FK_Dual_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dual] DROP CONSTRAINT [FK_Dual_0];
GO
IF OBJECT_ID(N'[dbo].[FK_Dual_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dual] DROP CONSTRAINT [FK_Dual_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Dual_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dual] DROP CONSTRAINT [FK_Dual_2];
GO
IF OBJECT_ID(N'[dbo].[FK_Dual_3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dual] DROP CONSTRAINT [FK_Dual_3];
GO
IF OBJECT_ID(N'[dbo].[FK_Dual_4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dual] DROP CONSTRAINT [FK_Dual_4];
GO
IF OBJECT_ID(N'[dbo].[FK_Dual_5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dual] DROP CONSTRAINT [FK_Dual_5];
GO
IF OBJECT_ID(N'[dbo].[FK_Game_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Game] DROP CONSTRAINT [FK_Game_0];
GO
IF OBJECT_ID(N'[dbo].[FK_Game_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Game] DROP CONSTRAINT [FK_Game_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Question_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Question_0];
GO
IF OBJECT_ID(N'[dbo].[FK_Questionary_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Questionary] DROP CONSTRAINT [FK_Questionary_0];
GO
IF OBJECT_ID(N'[dbo].[FK_Relationship_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Relationship] DROP CONSTRAINT [FK_Relationship_0];
GO
IF OBJECT_ID(N'[dbo].[FK_Relationship_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Relationship] DROP CONSTRAINT [FK_Relationship_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Score_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Score] DROP CONSTRAINT [FK_Score_0];
GO
IF OBJECT_ID(N'[dbo].[FK_Score_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Score] DROP CONSTRAINT [FK_Score_1];
GO
IF OBJECT_ID(N'[dbo].[FK_User_0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_0];
GO
IF OBJECT_ID(N'[dbo].[FK_User_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Choice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Choice];
GO
IF OBJECT_ID(N'[dbo].[Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course];
GO
IF OBJECT_ID(N'[dbo].[Dual]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dual];
GO
IF OBJECT_ID(N'[dbo].[Game]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Game];
GO
IF OBJECT_ID(N'[dbo].[Grade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grade];
GO
IF OBJECT_ID(N'[dbo].[Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question];
GO
IF OBJECT_ID(N'[dbo].[Questionary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questionary];
GO
IF OBJECT_ID(N'[dbo].[Rank]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rank];
GO
IF OBJECT_ID(N'[dbo].[Relationship]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Relationship];
GO
IF OBJECT_ID(N'[dbo].[RelationshipRequest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelationshipRequest];
GO
IF OBJECT_ID(N'[dbo].[Score]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Score];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Choices'
CREATE TABLE [dbo].[Choices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idQuestion] int  NOT NULL,
    [choice1] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [idGrade] int  NOT NULL
);
GO

-- Creating table 'Duals'
CREATE TABLE [dbo].[Duals] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idChallenger] int  NOT NULL,
    [idChallenged] int  NOT NULL,
    [date] datetime  NOT NULL,
    [idGame] int  NOT NULL,
    [idScoreChallenger] int  NOT NULL,
    [idScoreChallenged] int  NULL,
    [winner] int  NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [idCourse] int  NOT NULL,
    [idQuestionary] int  NULL,
    [description] nvarchar(max)  NULL,
    [className] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Grades'
CREATE TABLE [dbo].[Grades] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [question1] nvarchar(250)  NOT NULL,
    [answer] nvarchar(50)  NOT NULL,
    [idQuestionary] int  NULL
);
GO

-- Creating table 'Questionaries'
CREATE TABLE [dbo].[Questionaries] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idGame] int  NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Ranks'
CREATE TABLE [dbo].[Ranks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Relationships'
CREATE TABLE [dbo].[Relationships] (
    [userId1] int  NOT NULL,
    [userId2] int  NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'RelationshipRequests'
CREATE TABLE [dbo].[RelationshipRequests] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idCaller] int  NOT NULL,
    [idCalled] int  NOT NULL
);
GO

-- Creating table 'Scores'
CREATE TABLE [dbo].[Scores] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idUser] int  NOT NULL,
    [idGame] int  NOT NULL,
    [value] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(15)  NOT NULL,
    [password] nvarchar(40)  NOT NULL,
    [mail] nvarchar(32)  NULL,
    [name] nvarchar(50)  NULL,
    [firstName] nvarchar(50)  NULL,
    [idGrade] int  NOT NULL,
    [idRank] int  NOT NULL,
    [birthDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [PK_Choices]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Duals'
ALTER TABLE [dbo].[Duals]
ADD CONSTRAINT [PK_Duals]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [PK_Grades]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Questionaries'
ALTER TABLE [dbo].[Questionaries]
ADD CONSTRAINT [PK_Questionaries]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Ranks'
ALTER TABLE [dbo].[Ranks]
ADD CONSTRAINT [PK_Ranks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Relationships'
ALTER TABLE [dbo].[Relationships]
ADD CONSTRAINT [PK_Relationships]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RelationshipRequests'
ALTER TABLE [dbo].[RelationshipRequests]
ADD CONSTRAINT [PK_RelationshipRequests]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Scores'
ALTER TABLE [dbo].[Scores]
ADD CONSTRAINT [PK_Scores]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idQuestion] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [FK_Choice_0]
    FOREIGN KEY ([idQuestion])
    REFERENCES [dbo].[Questions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Choice_0'
CREATE INDEX [IX_FK_Choice_0]
ON [dbo].[Choices]
    ([idQuestion]);
GO

-- Creating foreign key on [idGrade] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_Course_0]
    FOREIGN KEY ([idGrade])
    REFERENCES [dbo].[Grades]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_0'
CREATE INDEX [IX_FK_Course_0]
ON [dbo].[Courses]
    ([idGrade]);
GO

-- Creating foreign key on [idCourse] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [FK_Game_0]
    FOREIGN KEY ([idCourse])
    REFERENCES [dbo].[Courses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Game_0'
CREATE INDEX [IX_FK_Game_0]
ON [dbo].[Games]
    ([idCourse]);
GO

-- Creating foreign key on [idChallenger] in table 'Duals'
ALTER TABLE [dbo].[Duals]
ADD CONSTRAINT [FK_Dual_0]
    FOREIGN KEY ([idChallenger])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dual_0'
CREATE INDEX [IX_FK_Dual_0]
ON [dbo].[Duals]
    ([idChallenger]);
GO

-- Creating foreign key on [idChallenged] in table 'Duals'
ALTER TABLE [dbo].[Duals]
ADD CONSTRAINT [FK_Dual_1]
    FOREIGN KEY ([idChallenged])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dual_1'
CREATE INDEX [IX_FK_Dual_1]
ON [dbo].[Duals]
    ([idChallenged]);
GO

-- Creating foreign key on [idGame] in table 'Duals'
ALTER TABLE [dbo].[Duals]
ADD CONSTRAINT [FK_Dual_2]
    FOREIGN KEY ([idGame])
    REFERENCES [dbo].[Games]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dual_2'
CREATE INDEX [IX_FK_Dual_2]
ON [dbo].[Duals]
    ([idGame]);
GO

-- Creating foreign key on [idScoreChallenger] in table 'Duals'
ALTER TABLE [dbo].[Duals]
ADD CONSTRAINT [FK_Dual_3]
    FOREIGN KEY ([idScoreChallenger])
    REFERENCES [dbo].[Scores]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dual_3'
CREATE INDEX [IX_FK_Dual_3]
ON [dbo].[Duals]
    ([idScoreChallenger]);
GO

-- Creating foreign key on [idScoreChallenged] in table 'Duals'
ALTER TABLE [dbo].[Duals]
ADD CONSTRAINT [FK_Dual_4]
    FOREIGN KEY ([idScoreChallenged])
    REFERENCES [dbo].[Scores]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dual_4'
CREATE INDEX [IX_FK_Dual_4]
ON [dbo].[Duals]
    ([idScoreChallenged]);
GO

-- Creating foreign key on [winner] in table 'Duals'
ALTER TABLE [dbo].[Duals]
ADD CONSTRAINT [FK_Dual_5]
    FOREIGN KEY ([winner])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dual_5'
CREATE INDEX [IX_FK_Dual_5]
ON [dbo].[Duals]
    ([winner]);
GO

-- Creating foreign key on [idQuestionary] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [FK_Game_1]
    FOREIGN KEY ([idQuestionary])
    REFERENCES [dbo].[Questionaries]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Game_1'
CREATE INDEX [IX_FK_Game_1]
ON [dbo].[Games]
    ([idQuestionary]);
GO

-- Creating foreign key on [idGame] in table 'Questionaries'
ALTER TABLE [dbo].[Questionaries]
ADD CONSTRAINT [FK_Questionary_0]
    FOREIGN KEY ([idGame])
    REFERENCES [dbo].[Games]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Questionary_0'
CREATE INDEX [IX_FK_Questionary_0]
ON [dbo].[Questionaries]
    ([idGame]);
GO

-- Creating foreign key on [idGame] in table 'Scores'
ALTER TABLE [dbo].[Scores]
ADD CONSTRAINT [FK_Score_1]
    FOREIGN KEY ([idGame])
    REFERENCES [dbo].[Games]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Score_1'
CREATE INDEX [IX_FK_Score_1]
ON [dbo].[Scores]
    ([idGame]);
GO

-- Creating foreign key on [idGrade] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_1]
    FOREIGN KEY ([idGrade])
    REFERENCES [dbo].[Grades]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_1'
CREATE INDEX [IX_FK_User_1]
ON [dbo].[Users]
    ([idGrade]);
GO

-- Creating foreign key on [idQuestionary] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_Question_0]
    FOREIGN KEY ([idQuestionary])
    REFERENCES [dbo].[Questionaries]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Question_0'
CREATE INDEX [IX_FK_Question_0]
ON [dbo].[Questions]
    ([idQuestionary]);
GO

-- Creating foreign key on [idRank] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_0]
    FOREIGN KEY ([idRank])
    REFERENCES [dbo].[Ranks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_0'
CREATE INDEX [IX_FK_User_0]
ON [dbo].[Users]
    ([idRank]);
GO

-- Creating foreign key on [userId1] in table 'Relationships'
ALTER TABLE [dbo].[Relationships]
ADD CONSTRAINT [FK_Relationship_0]
    FOREIGN KEY ([userId1])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Relationship_0'
CREATE INDEX [IX_FK_Relationship_0]
ON [dbo].[Relationships]
    ([userId1]);
GO

-- Creating foreign key on [userId2] in table 'Relationships'
ALTER TABLE [dbo].[Relationships]
ADD CONSTRAINT [FK_Relationship_1]
    FOREIGN KEY ([userId2])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Relationship_1'
CREATE INDEX [IX_FK_Relationship_1]
ON [dbo].[Relationships]
    ([userId2]);
GO

-- Creating foreign key on [idCaller] in table 'RelationshipRequests'
ALTER TABLE [dbo].[RelationshipRequests]
ADD CONSTRAINT [FK_AddRequest_0]
    FOREIGN KEY ([idCaller])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddRequest_0'
CREATE INDEX [IX_FK_AddRequest_0]
ON [dbo].[RelationshipRequests]
    ([idCaller]);
GO

-- Creating foreign key on [idCalled] in table 'RelationshipRequests'
ALTER TABLE [dbo].[RelationshipRequests]
ADD CONSTRAINT [FK_AddRequest_1]
    FOREIGN KEY ([idCalled])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddRequest_1'
CREATE INDEX [IX_FK_AddRequest_1]
ON [dbo].[RelationshipRequests]
    ([idCalled]);
GO

-- Creating foreign key on [idUser] in table 'Scores'
ALTER TABLE [dbo].[Scores]
ADD CONSTRAINT [FK_Score_0]
    FOREIGN KEY ([idUser])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Score_0'
CREATE INDEX [IX_FK_Score_0]
ON [dbo].[Scores]
    ([idUser]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------