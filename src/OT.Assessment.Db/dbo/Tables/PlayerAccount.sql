CREATE TABLE [dbo].[PlayerAccount]
(	
	[Id]			    INT		        IDENTITY (1, 1) NOT NULL,
    [AccountId]		    NVARCHAR(50)    NOT NULL, 
	[Username]		    NVARCHAR(50)    NOT NULL,
	[Created]           DATETIME2 (7)   NULL,
    [CreatedBy]         NVARCHAR (MAX)  NULL,
    [LastModified]      DATETIME2 (7)   NULL,
    [LastModifiedBy]    NVARCHAR (MAX)  NULL,
)
