USE [103]
GO
/****** Object:  StoredProcedure [dbo].[AddNewUnit]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewUnit]
	@UnitName VARCHAR(50),
	@TeacherID INT,
	@Schedule DATETIME, 
	@IsDeleted BIT = 0
	
AS
BEGIN
	INSERT INTO dbo.Units
		(
			UnitName,
			TeacherID,
			Schedule, 
			IsDeleted
		)

    Values
		(
			@UnitName,
			@TeacherID,
			@Schedule, 
			@IsDeleted
		)
End
GO
