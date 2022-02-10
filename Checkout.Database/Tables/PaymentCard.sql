CREATE TABLE [payment].[PaymentCard]
(
	[Id]						INT IDENTITY (1, 1) NOT NULL,
	[PaymentId]					INT					NOT NULL,
	[PermanentAccountNumber]	BIGINT				NOT NULL,
	[CardholderName]			NVARCHAR(128)		NOT NULL,
	[ExpiresOnMonth]			TINYINT				NOT NULL,
	[ExpiresOnYear]				TINYINT				NOT NULL,
	[CardVerificationValue]		SMALLINT			NOT NULL,
    
    CONSTRAINT [PK_PaymentCard_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    
	CONSTRAINT [FK_PaymentCard_PaymentId] FOREIGN KEY ([PaymentId]) REFERENCES [payment].[Payment] ([Id]),
    
    INDEX [AK_PaymentCard_PaymentId] UNIQUE NONCLUSTERED ([PaymentId]),
)
