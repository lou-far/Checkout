CREATE TABLE [payment].[Payment]
(
	[Id]                INT IDENTITY (1, 1) NOT NULL,
    [MerchantId]        INT NOT NULL,
    [Amount]            INT NOT NULL,
    [PaymentStatusId]   INT NOT NULL,
    [CurrencyId]        INT NOT NULL,
    
    CONSTRAINT [PK_Payment_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    
	CONSTRAINT [FK_Payment_MerchantId] FOREIGN KEY ([MerchantId]) REFERENCES [merchant].[Merchant] ([Id]),
	CONSTRAINT [FK_Payment_PaymentStatusId] FOREIGN KEY ([PaymentStatusId]) REFERENCES [payment].[PaymentStatus] ([Id]),
	CONSTRAINT [FK_Payment_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [payment].[Currency] ([Id]),
    
    INDEX [IX_Payment_MerchantId] NONCLUSTERED ([MerchantId] ASC),    
    INDEX [IX_Payment_PaymentStatusId] NONCLUSTERED ([PaymentStatusId] ASC),    
    INDEX [IX_Payment_CurrencyId] NONCLUSTERED ([CurrencyId] ASC),
)
