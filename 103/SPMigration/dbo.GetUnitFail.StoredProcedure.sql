USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetUnitFail]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnitFail]
	@StudentID INT

AS
BEGIN

 -- Count failed unit 
SELECT COUNT(1) as UnitCount
FROM dbo.Mark as m WITH (NOLOCK)
INNER JOIN Students as s  WITH (NOLOCK) ON m.StudentID = s.StudentID
WHERE m.Mark < 50 AND m.StudentID = @StudentID AND m.IsDeleted = 0

END;
GO
