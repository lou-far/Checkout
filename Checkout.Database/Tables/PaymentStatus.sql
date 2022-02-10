CREATE TABLE [payment].[PaymentStatus]
(
	[Id]	INT         NOT NULL,
    [Name]	VARCHAR(16) NOT NULL,	
    
    CONSTRAINT [PK_PaymentStatus_Id] PRIMARY KEY CLUSTERED ([Id] ASC),

    INDEX [AK_PaymentStatus_Name] UNIQUE NONCLUSTERED ([Name] ASC),
)
