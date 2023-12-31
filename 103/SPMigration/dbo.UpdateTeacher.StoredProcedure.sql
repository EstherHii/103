USE [103]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeacher]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTeacher]
	@TeacherID INT, 
	@TeacherName NVARCHAR(50)

AS
BEGIN
	UPDATE dbo.Teachers WITH (ROWLOCK)
    SET
		TeacherName = @TeacherName

	WHERE TeacherID = @TeacherID AND IsDeleted = 0;
END
GO
