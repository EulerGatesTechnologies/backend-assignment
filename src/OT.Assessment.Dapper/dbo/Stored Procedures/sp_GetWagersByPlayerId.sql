CREATE PROCEDURE [dbo].[sp_GetCasinoWagersByPlayerId]
	@PlayerId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pcw.*
	FROM [dbo].[PlayerAccount] pa	
	JOIN [dbo].[PlayerCasinoWager] pcw
	ON pa.AccountId = pcw.AccountId
	WHERE pa.Id = @PlayerId;

END
