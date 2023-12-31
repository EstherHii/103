USE [103]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUnitByID]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUnitByID]
	@UnitID INT

AS 
BEGIN
    SET NOCOUNT ON;

	UPDATE dbo.Units WITH (ROWLOCK)
	SET IsDeleted = 1
	WHERE UnitID = @UnitID
END
GO
