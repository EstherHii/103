USE [103]
GO
/****** Object:  StoredProcedure [dbo].[DeleteMarksByID]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteMarksByID]
	@MarkID INT

AS
Begin
    SET NOCOUNT ON;

	UPDATE Mark WITH (ROWLOCK)
	SET IsDeleted = 1
	where MarkID = @MarkID
End
GO
