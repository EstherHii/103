USE [103]
GO
/****** Object:  StoredProcedure [dbo].[AddNewStudent]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewStudent]
	@StudentName NVARCHAR(50),
	@StudentEmail VARCHAR(50), 	
	@IsDeleted BIT = 0
	
AS
BEGIN
	INSERT INTO dbo.Students
		(
			StudentName,
			StudentEmail, 
			IsDeleted
		)

    VALUES
		(
			@StudentName,
			@StudentEmail, 
			@IsDeleted
		)
END
GO
