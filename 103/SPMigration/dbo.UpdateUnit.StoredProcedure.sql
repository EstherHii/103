USE [103]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUnit]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUnit]
	@UnitID INT,
	@UnitName VARCHAR(50),
	@TeacherID INT, 
	@Schedule DATETIME
	
AS
BEGIN
	UPDATE dbo.Units WITH (ROWLOCK)
    SET
		UnitName = @UnitName,
		TeacherID = @TeacherID,
		Schedule = @Schedule
		
	WHERE UnitID = @UnitID AND IsDeleted = 0;
END
GO
