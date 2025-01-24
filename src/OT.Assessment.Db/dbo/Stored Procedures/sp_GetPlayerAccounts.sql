CREATE PROCEDURE [dbo].[sp_GetPlayerAccounts]
	@PlayerId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pcw.*, pcw.*
	FROM [dbo].[PlayerAccount] pa	
	LEFT JOIN [dbo].[PlayerCasinoWager] pcw
	ON pa.AccountId = pcw.AccountId
	WHERE pa.Id = @PlayerId;

END
