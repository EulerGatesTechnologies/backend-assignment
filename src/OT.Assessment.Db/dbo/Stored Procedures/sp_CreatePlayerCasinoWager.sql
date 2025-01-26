CREATE PROCEDURE [dbo].[sp_CreatePlayerCasinoWager]
	@PlayerId INT
AS
BEGIN
	INSERT INTO dbo.PlayerCasinoWager(
			[AccountId]
           ,[Game]
           ,[Provider]
           ,[Amount]
           ,[WagerId]
           ,[PlayerId])
	SELECT @PlayerId, pcw.Game, pcw.[Provider], pcw.Amount, pcw.WagerId, pa.[Id]
		FROM [dbo].[PlayerAccount] pa	
			JOIN [dbo].[PlayerCasinoWager] pcw
		ON pa.AccountId = pcw.AccountId
	WHERE @PlayerId = pa.AccountId;
END