USE [103]
GO
/****** Object:  StoredProcedure [dbo].[AddNewTeacher]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewTeacher]
	@TeacherName nvarchar(50), 
	@IsDeleted BIT = 0
	
As
Begin
	Insert into dbo.Teachers
		(
			TeacherName, 
			IsDeleted
		)

    Values
		(
			@TeacherName, 
			@IsDeleted
		)
End
GO
