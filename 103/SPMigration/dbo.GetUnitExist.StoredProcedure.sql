USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetUnitExist]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnitExist]
	@StudentID INT,
	@UnitID INT

AS
BEGIN
 SET NOCOUNT ON;
 -- Check if same unit was taken 
SELECT COUNT(1) as SameUnitCount
FROM dbo.Mark as m WITH (NOLOCK)
INNER JOIN Units as u  WITH (NOLOCK) ON m.UnitID = u.UnitID 
WHERE m.StudentID = @StudentID AND m.UnitID = @UnitID AND m.IsDeleted = 0

END
GO
