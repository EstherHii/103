USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetUnitList]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnitList]

AS
BEGIN 

    SET NOCOUNT ON;

	SELECT UnitID, UnitName, t.TeacherName, Schedule, dbo.Units.IsDeleted
	FROM dbo.Units WITH (NOLOCK)
	LEFT JOIN Teachers as t WITH (NOLOCK)
	ON dbo.Units.TeacherID = t.TeacherID
	WHERE dbo.Units.IsDeleted = 0

END;
GO
