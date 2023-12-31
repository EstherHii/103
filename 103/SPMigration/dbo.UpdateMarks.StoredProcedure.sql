USE [103]
GO
/****** Object:  StoredProcedure [dbo].[UpdateMarks]    Script Date: 2023/12/28 上午 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateMarks]
    @MarkID INT,
	@StudentID INT, 
	@UnitID INT, 
	@Mark INT, 
	@Grade CHAR(1)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Mark WITH (ROWLOCK)
    SET StudentID = @StudentID,
        UnitID = @UnitID, 
		Mark = @Mark, 
		Grade = @Grade

    WHERE MarkID = @MarkID AND IsDeleted = 0 -- Ensure not deleted
END
GO
