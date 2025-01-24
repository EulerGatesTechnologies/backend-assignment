CREATE PROCEDURE [dbo].[sp_CreatePlayerCasinoWager]
	@people BasicUDT readonly
AS
BEGIN
	INSERT INTO dbo.Person(FirstName, LastName)
	SELECT [FirstName], [LastName]
	FROM @people;
END