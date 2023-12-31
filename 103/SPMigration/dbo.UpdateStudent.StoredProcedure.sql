USE [103]
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudent]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStudent]
	@StudentID INT,
	@StudentName NVARCHAR(50), 
	@StudentEmail VARcHAR(50)
	
AS
BEGIN
	UPDATE dbo.Students WITH (ROWLOCK)
    SET
		StudentName = @StudentName,
		StudentEmail = @StudentEmail
		
	WHERE StudentID = @StudentID AND IsDeleted = 0;
END
GO
