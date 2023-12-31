USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentUnitAvailable]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentUnitAvailable]  --Unit available
	@StudentID INT
AS
BEGIN
 SET NOCOUNT ON;


 SELECT *
    FROM Units WITH (NOLOCK)
    WHERE UnitID NOT IN (
        SELECT UnitID
        FROM Mark WITH (NOLOCK)
        WHERE StudentID = @StudentID 
    ) AND IsDeleted = 0
END
GO
