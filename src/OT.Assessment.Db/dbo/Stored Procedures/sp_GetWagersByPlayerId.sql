CREATE PROCEDURE [dbo].[sp_GetCasinoWagersByPlayerId]
	@PlayerId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pcw.AccountId, pcw.Game, pcw.[Provider], pcw.Amount,	pa.Username
		FROM [dbo].[PlayerAccount] pa	
		 LEFT JOIN [dbo].[PlayerCasinoWager] pcw
		ON pa.AccountId = pcw.AccountId
		WHERE 

END
