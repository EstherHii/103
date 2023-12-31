USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentPagination]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentPagination]
 @PageNumber AS INT,
 @pageSize AS INT

AS
BEGIN

	SELECT StudentID,StudentName,StudentEmail
	FROM dbo.Students WITH(NOLOCK) 
	WHERE IsDeleted = 0
	ORDER BY StudentID
	OFFSET (@PageNumber-1) * @pageSize ROWS
	FETCH NEXT @pageSize ROWS ONLY
END
GO
