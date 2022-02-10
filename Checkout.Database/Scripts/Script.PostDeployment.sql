------------------------------------
--------- DICTIONARY VALUES --------
------------------------------------

MERGE INTO [payment].[Currency] AS Target
USING (VALUES
    (N'1', N'EUR')
    ,(N'2',N'GBP')
    ,(N'3',N'USD')
) AS Source (Id, Name)
ON Target.Id = Source.Id
WHEN MATCHED THEN
    UPDATE SET Name = Source.Name
WHEN NOT MATCHED BY Target THEN
    INSERT (Id, Name)
    VALUES (Id, Name)
WHEN NOT MATCHED BY SOURCE THEN
    DELETE;
GO

MERGE INTO [payment].[PaymentStatus] AS Target
USING (VALUES
    (N'1', N'Pending')
    ,(N'2',N'Successful')
    ,(N'3',N'Failed')
) AS Source (Id, Name)
ON Target.Id = Source.Id
WHEN MATCHED THEN
    UPDATE SET Name = Source.Name
WHEN NOT MATCHED BY Target THEN
    INSERT (Id, Name)
    VALUES (Id, Name)
WHEN NOT MATCHED BY SOURCE THEN
    DELETE;
GO

------------------------------------
---------- TEMPORARY DATA ----------
------------------------------------

MERGE INTO [merchant].[Merchant] AS Target
USING (VALUES
    (N'1')
   ,(N'2')
   ,(N'3')
) AS Source (Id)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY Target THEN
    INSERT (Id)
    VALUES (Id)
WHEN NOT MATCHED BY SOURCE THEN
    DELETE;
GO
