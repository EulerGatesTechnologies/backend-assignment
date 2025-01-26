CREATE PROCEDURE [dbo].[sp_GetCasinoWagersByPlayerId]
	@PlayerId NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pcw.WagerId, pcw.Game, pcw.[Provider], pcw.Amount, pcw.CreatedDateTime
		FROM [dbo].[PlayerAccount] pa	
		 LEFT JOIN [dbo].[PlayerCasinoWager] pcw
		ON pa.Id = pcw.PlayerId
		WHERE pa.AccountId = @PlayerId;
END
