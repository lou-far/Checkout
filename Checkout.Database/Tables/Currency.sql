CREATE TABLE [payment].[Currency]
(
	[Id]	INT         NOT NULL,
    [Name]	VARCHAR(4)  NOT NULL,	
    
    CONSTRAINT [PK_Currency_Id] PRIMARY KEY CLUSTERED ([Id] ASC),

    INDEX [AK_Currency_Name] UNIQUE NONCLUSTERED ([Name] ASC),
)
