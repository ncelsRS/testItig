CREATE VIEW [DirectionPaymentsReportView]
AS
SELECT
	 [OBK_DirectionToPayments].[Id] 
	,[OBK_Ref_Type].[NameRu] AS [TypeId]
	,[OBK_Contract].[Number] AS [ContractNumber]
	,[OBK_Contract].[SendDate]
	,[Units].[Name] AS [ExpertOrganization]
	,[OBK_Declarant].[NameRu] AS [Declarant]
	,[OBK_DirectionToPayments].[TotalPrice]
	,[OBK_DirectionToPayments].[InvoiceNumber1C]
	,[OBK_DirectionToPayments].[InvoiceDatetime1C]
	,(SELECT CASE WHEN [OBK_DirectionToPayments].[IsPaid] = 1 THEN N'оплачен'
	WHEN [OBK_DirectionToPayments].[IsNotFullPaid] = 1 THEN N'оплачен не полностью'
	WHEN [OBK_DirectionToPayments].[IsPaid] != 1 AND [OBK_DirectionToPayments].[IsNotFullPaid] != 1
	THEN N'в ожиданий оплаты' END) AS [PayStatus]
FROM [ncels].[dbo].[OBK_DirectionToPayments]
INNER JOIN [ncels].[dbo].[OBK_Contract] ON [OBK_DirectionToPayments].[ContractId] = [OBK_Contract].[Id]
INNER JOIN [ncels].[dbo].[OBK_Ref_Type] ON [OBK_Ref_Type].[Id] = [OBK_Contract].[Type]
LEFT JOIN [ncels].[dbo].[Units] ON [OBK_Contract].[ExpertOrganization] = [Units].[Id]
LEFT JOIN [ncels].[dbo].[OBK_Declarant] ON [OBK_Contract].[DeclarantId] = [OBK_Declarant].[Id]
WHERE [OBK_DirectionToPayments].[InvoiceNumber1C] IS NOT NULL

UNION ALL

SELECT 
	 [OBK_DirectionToPayments].[Id]
	,[OBK_Ref_Type].[NameRu] AS [TypeId]
	,[OBK_Contract].[Number] AS [ContractNumber]
	,[OBK_ZBKCopy].[SendDate] 
	,[Units].[Name] AS [ExpertOrganization]
	,[OBK_Declarant].[NameRu] AS [Declarant]
	,[OBK_DirectionToPayments].[TotalPrice]
	,[OBK_DirectionToPayments].[InvoiceNumber1C]
	,[OBK_DirectionToPayments].[InvoiceDatetime1C]
	,(SELECT CASE WHEN [OBK_DirectionToPayments].[IsPaid] = 1 THEN N'оплачен'
	WHEN [OBK_DirectionToPayments].[IsNotFullPaid] = 1 THEN N'оплачен не полностью'
	WHEN [OBK_DirectionToPayments].[IsPaid] != 1 AND [OBK_DirectionToPayments].[IsNotFullPaid] != 1
	THEN N'в ожиданий оплаты' END) AS [PayStatus]
FROM [ncels].[dbo].[OBK_DirectionToPayments]
INNER JOIN [ncels].[dbo].[OBK_ZBKCopy] ON [OBK_ZBKCopy].[Id] = [OBK_DirectionToPayments].[ZBKCopy_id]
INNER JOIN [ncels].[dbo].[OBK_StageExpDocument] ON [OBK_StageExpDocument].Id = [OBK_ZBKCopy].[OBK_StageExpDocumentId]
INNER JOIN [ncels].[dbo].[OBK_AssessmentDeclaration] ON [OBK_StageExpDocument].[AssessmentDeclarationId] = [OBK_AssessmentDeclaration].[Id]
INNER JOIN [ncels].[dbo].[OBK_Ref_Type] ON [OBK_Ref_Type].[Code] = 5
INNER JOIN [ncels].[dbo].[OBK_Contract] ON [OBK_Contract].[Id] = [OBK_AssessmentDeclaration].[ContractId]
LEFT JOIN [ncels].[dbo].[Units] ON [OBK_Contract].[ExpertOrganization] = [Units].[Id]
LEFT JOIN [ncels].[dbo].[OBK_Declarant] ON [OBK_Contract].[DeclarantId] = [OBK_Declarant].[Id]
WHERE [OBK_DirectionToPayments].[InvoiceNumber1C] IS NOT NULL
