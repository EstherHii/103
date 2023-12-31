USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetUnitByID]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnitByID]

	@UnitID INT
	
AS
BEGIN
	SELECT
		UnitID,
		UnitName,
		t.TeacherID,
		t.TeacherName,
		Schedule, 
		u.IsDeleted
		
	FROM dbo.Units as u WITH (NOLOCK)
	INNER JOIN Teachers as t  WITH (NOLOCK) ON t.TeacherID = u.TeacherID
	WHERE UnitID = @UnitID AND u.IsDeleted = 0;
END
GO
