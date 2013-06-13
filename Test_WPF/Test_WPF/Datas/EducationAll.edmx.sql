
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2013 15:42:51
-- Generated from EDMX file: C:\Users\isen\Desktop\Docs\Visual_Studio\EducationAll\Test_WPF\Test_WPF\Datas\EducationAll.edmx
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

IF OBJECT_ID(N'[dbo].[FK_User_Difficulty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Difficulty];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course];
GO
IF OBJECT_ID(N'[dbo].[Game]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Game];
GO
IF OBJECT_ID(N'[dbo].[Grade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grade];
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

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [idCourse] int  NOT NULL
);
GO

-- Creating table 'Grades'
CREATE TABLE [dbo].[Grades] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Scores'
CREATE TABLE [dbo].[Scores] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idUser] int  NOT NULL,
    [value] int  NOT NULL,
    [idGame] int  NOT NULL
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
    [rank] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [PK_Grades]
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

-- Creating foreign key on [idGrade] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Difficulty]
    FOREIGN KEY ([idGrade])
    REFERENCES [dbo].[Grades]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Difficulty'
CREATE INDEX [IX_FK_User_Difficulty]
ON [dbo].[Users]
    ([idGrade]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------