USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetMarkList]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMarkList]
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT m.MarkID, m.Mark, m.Grade, u.UnitName, s.StudentID, s.StudentName, m.IsDeleted
	FROM dbo.Mark as m WITH (NOLOCK)
	INNER JOIN Units as u  WITH (NOLOCK) ON m.UnitID = u.UnitID 
	INNER JOIN Students as s  WITH (NOLOCK) ON m.StudentID = s.StudentID
	WHERE m.IsDeleted = 0

END
GO
