USE [103]
GO
/****** Object:  StoredProcedure [dbo].[CheckEmailDuplicate]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckEmailDuplicate]
	@StudentEmail VARCHAR(50)

AS
BEGIN

 -- Check Email Duplicate
SELECT COUNT(1) as EmailDuplicate
FROM dbo.Students WITH (NOLOCK)
WHERE StudentEmail = @StudentEmail AND IsDeleted = 0

END;
GO
