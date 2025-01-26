
/****** Object:  Table [dbo].[PlayerAccount]    Script Date: 1/26/2025 2:03:02 PM ******/
CREATE TABLE [dbo].[PlayerCasinoWager]
(
	[Id]                    INT NOT NULL PRIMARY KEY IDENTITY,
    [AccountId]             NVARCHAR(50) NOT NULL, 
    [Game]                  NVARCHAR(50) NOT NULL, 
    [Provider]              NVARCHAR(50) NOT NULL, 
    [Amount]                MONEY		 NOT NULL, 
    [WagerId]               NVARCHAR(50) NOT NULL,
    [PlayerId]              INT			   NULL,
    [CreatedDateTime]       DATETIME2 (7)  NULL,
    [CreatedBy]             NVARCHAR (MAX) NULL,
    [LastModifiedDateTime]  DATETIME2 (7)  NULL,
    [LastModifiedBy]        NVARCHAR (MAX) NULL
)


