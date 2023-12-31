USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentByID]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentByID]

	@StudentID INT
	
AS
BEGIN
	SELECT
		StudentID,
		StudentName,
		StudentEmail, 
		IsDeleted
		
	FROM dbo.Students WITH (NOLOCK)
	WHERE StudentID = @StudentID AND IsDeleted = 0;
END
GO
