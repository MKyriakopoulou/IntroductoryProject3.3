
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/31/2020 16:59:12
-- Generated from EDMX file: C:\Users\mkyri\source\repos\IntroductoryProject3.1\LawyerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LawyerDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Lawyers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lawyers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Lawyers'
CREATE TABLE [dbo].[Lawyers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Initials] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Gender] int  NOT NULL,
    [Title] int  NOT NULL
);
GO

-- Creating table 'OldLawyers'
CREATE TABLE [dbo].[OldLawyers] (
    [RecId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Initials] nvarchar(max)  NOT NULL,
    [DateOfBirth] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [LawyerId] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Lawyers'
ALTER TABLE [dbo].[Lawyers]
ADD CONSTRAINT [PK_Lawyers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RecId] in table 'OldLawyers'
ALTER TABLE [dbo].[OldLawyers]
ADD CONSTRAINT [PK_OldLawyers]
    PRIMARY KEY CLUSTERED ([RecId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------