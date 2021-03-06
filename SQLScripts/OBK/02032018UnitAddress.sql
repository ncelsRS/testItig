
  ALTER TABLE [ncels].[dbo].[UnitsAddress]
  ADD [PostalCode] NVARCHAR(50) NULL 

  ALTER TABLE [ncels].[dbo].[UnitsAddress]
  ADD [ShortCityNameRu] NVARCHAR(100) NULL 

  ALTER TABLE [ncels].[dbo].[UnitsAddress]
  ADD [ShortCityNameKz] NVARCHAR(100) NULL 


  USE [ncels]
GO

/****** Object:  View [dbo].[OBK_DefectiveProductsReportView]    Script Date: 03.03.2018 15:05:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





	ALTER VIEW [dbo].[OBK_DefectiveProductsReportView]
	AS
	SELECT	 [OBK_StageExpDocument].[Id]
			,[OBK_StageExpDocument].[ExpStartDate]
			,[OBK_AssessmentDeclaration].[Number] AS [DeclarationNumber]
			,[OBK_AssessmentDeclaration].[SendDate]	
			,[OBK_Declarant].[NameRu] AS [Declarant] --Информация о Заявителе
			,[Units].[Name] AS [ExpertOrganization] 
			,[OBK_RS_Products].[RegNumber] AS [ExpConclusionNumber]
			,[OBK_RS_Products].[DrugFormFullName] AS [ProductInfo]--Наименование продукции
			,[OBK_RS_Products].[ProducerNameRu] +' '+ [OBK_RS_Products].[CountryNameRu] AS [ProducerName]
			,[OBK_StageExpDocument].[ExpReasonNameRu] AS [ExpReasonName]

	FROM [ncels].[dbo].[OBK_StageExpDocument]
	INNER JOIN [ncels].[dbo].[OBK_AssessmentDeclaration] ON [OBK_StageExpDocument].[AssessmentDeclarationId] = [OBK_AssessmentDeclaration].[Id]
	INNER JOIN [ncels].[dbo].[OBK_Contract] ON [OBK_AssessmentDeclaration].[ContractId] = [OBK_Contract].[Id]
	LEFT JOIN [ncels].[dbo].[OBK_Declarant] ON [OBK_Contract].[DeclarantId] = [OBK_Declarant].[Id]
	INNER JOIN [ncels].[dbo].[OBK_Procunts_Series] ON [OBK_StageExpDocument].[ProductSeriesId] = [OBK_Procunts_Series].[Id]
	INNER JOIN [ncels].[dbo].[OBK_RS_Products] ON [OBK_Procunts_Series].[OBK_RS_ProductsId] = [OBK_RS_Products].[Id]
	LEFT JOIN [ncels].[dbo].[Units] ON [OBK_Contract].[ExpertOrganization] = [Units].[Id]
	WHERE [OBK_StageExpDocument].[ExpResult] = 0
GO