IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DBSM_AMS')
BEGIN
    CREATE DATABASE DBSM_AMS;
END;
GO
USE [DBSM_AMS]
GO
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_Users_Mst' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
	CREATE TABLE [dbo].[tbl_Users_Mst](
		[numID]		  [numeric](18, 0) IDENTITY(1,1) PRIMARY KEY,
		[chvUserName] [varchar](200) NOT NULL,
		[chvPassword] [varchar](50) NOT NULL,
		[chvEmail]	  [varchar](50) NULL,
		[numBranchID] [numeric](18, 0) NULL,
		[tnyUserType] [tinyint] NOT NULL
	) 
END
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND object_id = OBJECT_ID('spGetUsers'))
BEGIN
    DROP PROCEDURE spGetUsers;
END;
GO
CREATE PROC dbo.spGetUsers
    @numID	NUMERIC(18,0) = NULL
AS
BEGIN
    SELECT 
	[numID], 
	[chvUserName], 
	[chvEmail], 
	[numBranchID], 
	CASE [numBranchID]
	WHEN 1 THEN 'Algiers' 
	WHEN 2 THEN 'Oran' 
	WHEN 3 THEN 'Constantine' 
	END Branch,
	[tnyUserType]
    FROM [dbo].[tbl_Users_Mst]
	WHERE numID = ISNULL(numID,@numID)
END;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND object_id = OBJECT_ID('spSaveUsers'))
BEGIN
    DROP PROCEDURE spSaveUsers;
END;
GO
CREATE PROCEDURE dbo.spSaveUsers
    @numID		 NUMERIC(18,0) =NULL,
    @chvUserName VARCHAR(255),
    @chvEmail	 VARCHAR(255),
    @numBranchID NUMERIC(18,0),
    @tnyUserType TINYINT
AS
BEGIN
    IF EXISTS (SELECT * FROM [dbo].[tbl_Users_Mst] WHERE [numID] = @numID)
    BEGIN
        UPDATE [dbo].[tbl_Users_Mst]
        SET [chvUserName] = @chvUserName,
            [chvEmail]	  = @chvEmail,
            [numBranchID] = @numBranchID,
            [tnyUserType] = @tnyUserType
        WHERE [numID] = @numID;
    END
    ELSE
    BEGIN
        -- Insert a new record
        INSERT INTO [dbo].[tbl_Users_Mst] ([chvUserName], [chvPassword], [chvEmail], [numBranchID], [tnyUserType])
        VALUES (@chvUserName, @chvUserName, @chvEmail, @numBranchID, @tnyUserType);
    END;
END;
GO
-------------------------------Athira-----------------------
GO
CREATE TABLE [dbo].[tbl_Branch_Mst](
	[numBrID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[chvBranchCode] [varchar](50) NOT NULL,
	[chvBranchName] [varchar](200) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[numBrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE OR ALTER PROCEDURE [dbo].[spSaveBranch]
    @numBrID		 NUMERIC(18,0) =NULL,
	@chvBranchCode varchar(50),
    @chvBrName VARCHAR(200)
AS
BEGIN
    IF EXISTS (SELECT * FROM [dbo].[tbl_Branch_Mst] WHERE [numBrID] = @numBrID)
    BEGIN
        UPDATE [dbo].[tbl_Branch_Mst]
        SET chvBranchCode=@chvBranchCode,
		chvBranchName=@chvBrName
        WHERE [numBrID] = @numBrID;
    END
    ELSE
    BEGIN
        -- Insert a new record
        INSERT INTO [dbo].[tbl_Branch_Mst] ([chvBranchCode],[chvBranchName])
        VALUES (@chvBranchCode,@chvBrName);
    END;
END;
GO
CREATE OR ALTER PROC [dbo].[spGetBranch]
    @numBrID	NUMERIC(18,0) = NULL
AS
BEGIN
    SELECT 
	numBrID,chvBranchCode,chvBranchName
    FROM [dbo].[tbl_Branch_Mst]
	WHERE [numBrID] = ISNULL(@numBrID,numBrID)
END;
GO
----------------------Athira--------{End}--------
