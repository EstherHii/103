USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherByID]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTeacherByID]

	@TeacherID int 
	
AS
BEGIN
	SELECT
		TeacherID,
		TeacherName, 
		IsDeleted
		
	FROM dbo.Teachers WITH (NOLOCK)
	WHERE TeacherID = @TeacherID AND IsDeleted = 0;
END
GO
