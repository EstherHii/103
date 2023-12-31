USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentResultByID]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentResultByID]
	@StudentID INT --input parameters for sp

AS
BEGIN

	SET NOCOUNT ON;

	SELECT  s.StudentID, m.UnitID, UnitName, m.Mark, m.Grade
	FROM dbo.Students as s	WITH (NOLOCK)
	INNER JOIN Mark as m WITH (NOLOCK) ON s.StudentID = m.StudentID
	INNER JOIN Units as u WITH (NOLOCK) ON m.UnitID = u.UnitID
	WHERE m.StudentID = @studentID AND m.IsDeleted = 0

END
GO
