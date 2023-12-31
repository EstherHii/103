USE [103]
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherList]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTeacherList]

AS
BEGIN 

	SELECT TeacherID, TeacherName, IsDeleted
	FROM dbo.Teachers WITH (NOLOCK)
	WHERE IsDeleted = 0;
END
GO
