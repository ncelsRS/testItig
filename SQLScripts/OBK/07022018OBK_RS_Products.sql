  ALTER TABLE [ncels].[dbo].[OBK_RS_Products]
  ADD ActReceptionId UNIQUEIDENTIFIER NULL

  ALTER TABLE [ncels].[dbo].[OBK_RS_Products]
  ADD FOREIGN KEY (ActReceptionId) REFERENCES [ncels].[dbo].[OBK_ActReception](Id);

  ALTER TABLE [ncels].[dbo].[OBK_RS_Products]
  ADD UsedInSerie BIT NULL


