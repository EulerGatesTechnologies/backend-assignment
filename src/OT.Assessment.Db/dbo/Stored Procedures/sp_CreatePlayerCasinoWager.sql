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

--DECLARE @PlayerId INT = 1;
--DECLARE @AccountId INT = 2;
--DECLARE @Username NVARCHAR(50) = 'player1';
--DECLARE @Amount DECIMAL(10,2) = 100.00;

--IF EXISTS (SELECT 1 FROM PlayerAccount WHERE PlayerId = @PlayerId)
--BEGIN
--    IF NOT EXISTS (SELECT 1 FROM PlayerCasinoWager WHERE PlayerId = @PlayerId)
--    BEGIN
--        INSERT INTO PlayerCasinoWager (WagerId, AccountId, Username, Amount, PlayerId)
--        VALUES (NEWID(), @AccountId, @Username, @Amount, @PlayerId);
--    END
--END
--ELSE
--BEGIN
--    INSERT INTO PlayerAccount (AccountId, Username)
--    VALUES (@AccountId, @Username);

--    INSERT INTO PlayerCasinoWager (WagerId, AccountId, Username, Amount, PlayerId)
--    VALUES (NEWID(), @AccountId, @Username, @Amount, @PlayerId);
--END
