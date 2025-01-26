CREATE PROCEDURE [dbo].[sp_CreatePlayerCasinoWager]
	@people BasicUDT readonly
AS
BEGIN
	INSERT INTO dbo.PlayerAccount(AccountId, Username)
	SELECT [AccountId], [Username]
	FROM @people


END