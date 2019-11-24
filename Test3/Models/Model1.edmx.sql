
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2019 00:41:32
-- Generated from EDMX file: C:\Users\mujta\source\repos\bitsplz\Test3\Test3\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Position]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Position];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomsReserves]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reserves] DROP CONSTRAINT [FK_RoomsReserves];
GO
IF OBJECT_ID(N'[dbo].[FK_EventReserves]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reserves] DROP CONSTRAINT [FK_EventReserves];
GO
IF OBJECT_ID(N'[dbo].[FK_SocietyEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_SocietyEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_SocietyUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_SocietyUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[User_Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Type];
GO
IF OBJECT_ID(N'[dbo].[Societies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Societies];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Reserves]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reserves];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [User_ID] int IDENTITY(1,1) NOT NULL,
    [User_Name] varchar(100)  NOT NULL,
    [User_Pass] varchar(max)  NOT NULL,
    [Type_ID] int  NOT NULL,
    [Society_ID] int  NULL
);
GO

-- Creating table 'User_Type'
CREATE TABLE [dbo].[User_Type] (
    [Type_ID] int IDENTITY(1,1) NOT NULL,
    [Type_Name] varchar(10)  NOT NULL
);
GO

-- Creating table 'Societies'
CREATE TABLE [dbo].[Societies] (
    [Society_ID] int IDENTITY(1,1) NOT NULL,
    [Society_Name] varchar(30)  NOT NULL,
    [Patron_Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Room_ID] int IDENTITY(1,1) NOT NULL,
    [Building_Name] varchar(15)  NOT NULL,
    [Room_Status] varchar(10)  NOT NULL,
    [Room_Name] varchar(10)  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Event_ID] int IDENTITY(1,1) NOT NULL,
    [Event_name] varchar(50)  NOT NULL,
    [Society_ID] int  NOT NULL
);
GO

-- Creating table 'Reserves'
CREATE TABLE [dbo].[Reserves] (
    [Reserve_ID] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Start_Time] time  NOT NULL,
    [End_Time] time  NOT NULL,
    [Room_ID] int  NOT NULL,
    [Event_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [User_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([User_ID] ASC);
GO

-- Creating primary key on [Type_ID] in table 'User_Type'
ALTER TABLE [dbo].[User_Type]
ADD CONSTRAINT [PK_User_Type]
    PRIMARY KEY CLUSTERED ([Type_ID] ASC);
GO

-- Creating primary key on [Society_ID] in table 'Societies'
ALTER TABLE [dbo].[Societies]
ADD CONSTRAINT [PK_Societies]
    PRIMARY KEY CLUSTERED ([Society_ID] ASC);
GO

-- Creating primary key on [Room_ID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Room_ID] ASC);
GO

-- Creating primary key on [Event_ID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Event_ID] ASC);
GO

-- Creating primary key on [Reserve_ID] in table 'Reserves'
ALTER TABLE [dbo].[Reserves]
ADD CONSTRAINT [PK_Reserves]
    PRIMARY KEY CLUSTERED ([Reserve_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Type_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Position]
    FOREIGN KEY ([Type_ID])
    REFERENCES [dbo].[User_Type]
        ([Type_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Position'
CREATE INDEX [IX_FK_Position]
ON [dbo].[Users]
    ([Type_ID]);
GO

-- Creating foreign key on [Room_ID] in table 'Reserves'
ALTER TABLE [dbo].[Reserves]
ADD CONSTRAINT [FK_RoomsReserves]
    FOREIGN KEY ([Room_ID])
    REFERENCES [dbo].[Rooms]
        ([Room_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomsReserves'
CREATE INDEX [IX_FK_RoomsReserves]
ON [dbo].[Reserves]
    ([Room_ID]);
GO

-- Creating foreign key on [Event_ID] in table 'Reserves'
ALTER TABLE [dbo].[Reserves]
ADD CONSTRAINT [FK_EventReserves]
    FOREIGN KEY ([Event_ID])
    REFERENCES [dbo].[Events]
        ([Event_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventReserves'
CREATE INDEX [IX_FK_EventReserves]
ON [dbo].[Reserves]
    ([Event_ID]);
GO

-- Creating foreign key on [Society_ID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_SocietyEvent]
    FOREIGN KEY ([Society_ID])
    REFERENCES [dbo].[Societies]
        ([Society_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SocietyEvent'
CREATE INDEX [IX_FK_SocietyEvent]
ON [dbo].[Events]
    ([Society_ID]);
GO

-- Creating foreign key on [Society_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_SocietyUser]
    FOREIGN KEY ([Society_ID])
    REFERENCES [dbo].[Societies]
        ([Society_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SocietyUser'
CREATE INDEX [IX_FK_SocietyUser]
ON [dbo].[Users]
    ([Society_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------