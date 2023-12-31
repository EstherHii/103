USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetUnitPagination]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnitPagination]
 @PageNumber AS INT,
 @pageSize AS INT

AS
BEGIN

	SELECT UnitID, UnitName, t.TeacherName, units.TeacherID, Schedule
	FROM dbo.Units WITH(NOLOCK) 
	LEFT JOIN Teachers as t  WITH (NOLOCK) ON Units.TeacherID = t.TeacherID 
	WHERE Units.IsDeleted = 0
	ORDER BY UnitID
	OFFSET (@PageNumber-1) * @pageSize ROWS
	FETCH NEXT @pageSize ROWS ONLY
END
GO
