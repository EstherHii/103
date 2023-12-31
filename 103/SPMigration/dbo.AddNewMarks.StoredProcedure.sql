USE [103]
GO
/****** Object:  StoredProcedure [dbo].[AddNewMarks]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewMarks]
	@StudentID int, 
	@UnitID int, 
	@Mark int, 
	@Grade varchar(2), 
	@IsDeleted BIT = 0

AS
BEGIN 
	SET NOCOUNT ON;

	INSERT INTO	dbo.Mark
	(
		StudentID,
		UnitID,
		Mark,
		Grade,
		IsDeleted
	)

	Values 
	(
		@StudentID,
		@UnitID,
		@Mark,
		@Grade,
		@IsDeleted		
	)

END
GO
