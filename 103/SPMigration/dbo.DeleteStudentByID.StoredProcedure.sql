USE [103]
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentByID]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudentByID]
	@StudentID INT

AS 
BEGIN
	UPDATE dbo.Students WITH (ROWLOCK)
	SET IsDeleted = 1
	WHERE StudentID = @StudentID
END
GO
