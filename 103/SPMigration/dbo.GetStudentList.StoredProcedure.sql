USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentList]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentList]

AS
BEGIN 

	SELECT StudentID, StudentName, StudentEmail, IsDeleted
	FROM dbo.Students WITH (NOLOCK)
	WHERE IsDeleted = 0

END;
GO
