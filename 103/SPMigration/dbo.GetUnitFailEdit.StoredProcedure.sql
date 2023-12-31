USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetUnitFailEdit]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnitFailEdit]
	@StudentID INT,
	@MarkID INT

AS
BEGIN

 -- Count failed unit 
SELECT COUNT(1) as UnitCount
FROM dbo.Mark as m WITH (NOLOCK)
WHERE m.Mark < 50 AND m.StudentID = @StudentID AND m.IsDeleted = 0 AND m.MarkID!=@MarkID --exclude the one editing, so the rest 9 units can be saved 

END;
GO
