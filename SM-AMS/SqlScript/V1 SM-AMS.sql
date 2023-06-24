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
AS
BEGIN
    SELECT [numID], [chvUserName], [chvEmail], [numBranchID], [tnyUserType]
    FROM [dbo].[tbl_Users_Mst];
END;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND object_id = OBJECT_ID('spSaveUsers'))
BEGIN
    DROP PROCEDURE spSaveUsers;
END;
GO
CREATE PROCEDURE dbo.spSaveUsers
    @numID		 NUMERIC(18,0),
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
        INSERT INTO [dbo].[tbl_Users_Mst] ([numID], [chvUserName], [chvPassword], [chvEmail], [numBranchID], [tnyUserType])
        VALUES (@numID, @chvUserName, @chvUserName, @chvEmail, @numBranchID, @tnyUserType);
    END;
END;
GO


