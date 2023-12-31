USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetTotalTeacher]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTotalTeacher]

AS
BEGIN

SELECT COUNT(1) TotalTeacherCount
FROM dbo.Teachers WITH(NOLOCK)
WHERE IsDeleted = 0;
END
GO
