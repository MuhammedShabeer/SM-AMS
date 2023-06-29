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
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_Users_Mst' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
CREATE TABLE [dbo].[tbl_Branch_Mst](
	[numBrID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[chvBranchCode] [varchar](50) NOT NULL,
	[chvBranchName] [varchar](200) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[numBrID] ASC
)) ON [PRIMARY]
END
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND object_id = OBJECT_ID('spSaveCMasters'))
BEGIN
    DROP PROCEDURE spSaveCMasters;
END;
GO
CREATE PROCEDURE [dbo].[spSaveCMasters]
    @numID		 NUMERIC(18,0) =NULL,
	@chvCode	 VARCHAR(50),
    @chvName	 VARCHAR(200),
	@CMasters	 TINYINT
AS
BEGIN
	IF @CMasters = 1 --Branch
	BEGIN
		IF EXISTS (SELECT * FROM [dbo].[tbl_Branch_Mst] WHERE [numBrID] = @numID)
		BEGIN
		    UPDATE [dbo].[tbl_Branch_Mst] SET chvBranchCode=@chvCode,chvBranchName=@chvName WHERE [numBrID] = @numID;
		END
		ELSE
		BEGIN
		    INSERT INTO [dbo].[tbl_Branch_Mst] ([chvBranchCode],[chvBranchName]) VALUES (@chvCode,@chvName);
		END;
	END;
END;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND object_id = OBJECT_ID('spGetCMasters'))
BEGIN
    DROP PROCEDURE spGetCMasters;
END;
GO
CREATE PROC [dbo].[spGetCMasters]
    @numID	NUMERIC(18,0) = NULL,
	@CMasters	 TINYINT
AS
BEGIN
	IF @CMasters = 1 --Branch
	BEGIN
		SELECT numBrID numID,chvBranchCode chvCode,chvBranchName chvName FROM [dbo].[tbl_Branch_Mst] WHERE [numBrID] = ISNULL(@numID,numBrID)
	END
END;
GO
----------------------Athira--------{End}--------
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND object_id = OBJECT_ID('spDeleteCMasters'))
BEGIN
    DROP PROCEDURE spDeleteCMasters;
END;
GO
CREATE PROC [dbo].[spDeleteCMasters]
    @numID		NUMERIC(18,0),
	@CMasters	TINYINT
AS
BEGIN
	IF @CMasters = 1 --Branch
	BEGIN
		DELETE [dbo].[tbl_Branch_Mst] WHERE [numBrID] = @numID
	END
END;
GO
