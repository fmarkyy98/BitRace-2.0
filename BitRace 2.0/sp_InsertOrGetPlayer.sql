SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_InsertOrGetPlayer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_InsertOrGetPlayer]
GO

CREATE PROCEDURE [dbo].[sp_InsertOrGetPlayer]
	@i_UserName NVARCHAR(255)
	, @o_Score INT OUTPUT
	, @o_ID INT OUTPUT
AS

IF(EXISTS(SELECT 1 FROM Players WHERE [Name] = @i_UserName))
BEGIN
	
	SELECT @o_Score = Score, @o_ID = ID FROM Players WHERE [Name] = @i_UserName;

END
ELSE
BEGIN

	INSERT INTO Players
	([Name], Score)
	VALUES
	(@i_UserName, 0);

	SELECT @o_ID = SCOPE_IDENTITY(), @o_Score= 0;
	
END


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO