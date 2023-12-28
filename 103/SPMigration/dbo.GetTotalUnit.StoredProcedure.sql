USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetTotalUnit]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTotalUnit]

AS
BEGIN

SELECT COUNT(1) TotalUnitCount
FROM dbo.Units WITH(NOLOCK)
WHERE IsDeleted = 0;
END
GO
