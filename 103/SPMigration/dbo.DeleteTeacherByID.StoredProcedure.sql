USE [103]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherByID]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteTeacherByID]
@TeacherID int

As
Begin
	UPDATE dbo.Teachers WITH (ROWLOCK)
	SET IsDeleted = 1
	where TeacherID = @TeacherID
End
GO
