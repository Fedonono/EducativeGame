
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2013 18:48:30
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Ask]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ask];
GO
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
IF OBJECT_ID(N'[dbo].[Questionary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questionary];
GO
IF OBJECT_ID(N'[dbo].[Rank]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rank];
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

-- Creating table 'Asks'
CREATE TABLE [dbo].[Asks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idQuestion] int  NOT NULL,
    [idQuestionary] int  NOT NULL
);
GO

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
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Duals'
CREATE TABLE [dbo].[Duals] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idChallenger] int  NOT NULL,
    [idChallenged] int  NOT NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [idCourse] int  NOT NULL
);
GO

-- Creating table 'Grades'
CREATE TABLE [dbo].[Grades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Questionaries'
CREATE TABLE [dbo].[Questionaries] (
    [ID] int  NOT NULL,
    [idGame] int  NOT NULL
);
GO

-- Creating table 'Ranks'
CREATE TABLE [dbo].[Ranks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
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
    [password] nvarchar(32)  NOT NULL,
    [mail] nvarchar(32)  NULL,
    [name] nvarchar(50)  NULL,
    [firstName] nvarchar(50)  NULL,
    [idGrade] int  NOT NULL,
    [birthdayYear] int  NOT NULL,
    [idRank] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Asks'
ALTER TABLE [dbo].[Asks]
ADD CONSTRAINT [PK_Asks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

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

-- Creating primary key on [id] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [PK_Grades]
    PRIMARY KEY CLUSTERED ([id] ASC);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------