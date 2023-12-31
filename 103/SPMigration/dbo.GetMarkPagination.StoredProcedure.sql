USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetMarkPagination]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMarkPagination]
 @PageNumber AS INT,
 @pageSize AS INT

AS
BEGIN

	SELECT s.StudentID, StudentName, u.UnitID, UnitName, MarkID, Mark, Grade 
	FROM dbo.Mark WITH(NOLOCK) 
	INNER JOIN Students as s WITH(NOLOCK)  ON Mark.StudentID = s.StudentID 
	INNER JOIN Units as u WITH(NOLOCK)  ON Mark.UnitID = u.UnitID 
	WHERE Mark.IsDeleted = 0
	ORDER BY MarkID
	OFFSET (@PageNumber-1) * @pageSize ROWS
	FETCH NEXT @pageSize ROWS ONLY
END
GO
