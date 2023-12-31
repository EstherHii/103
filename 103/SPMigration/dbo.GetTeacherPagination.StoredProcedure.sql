USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherPagination]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTeacherPagination]
 @PageNumber AS INT,
 @pageSize AS INT

AS
BEGIN

	SELECT TeacherID,TeacherName
	FROM dbo.Teachers WITH(NOLOCK) 
	WHERE IsDeleted = 0
	ORDER BY TeacherID
	OFFSET (@PageNumber-1) * @pageSize ROWS
	FETCH NEXT @pageSize ROWS ONLY
END
GO
