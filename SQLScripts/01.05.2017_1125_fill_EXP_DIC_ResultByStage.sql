update EXP_DIC_StageResult set NameRu=N'Снят с регистрации заявителем', NameKz=N'Снят с регистрации заявителем'
where Id=3
go
insert into EXP_DIC_StageResult (Id, Code, NameRu, NameKz, DateCreate, IsDeleted)
values(4, '4', N'Рекомендовать', N'Рекомендовать', DATEFROMPARTS(2017,1,1), 0)
go
insert into EXP_DIC_StageResult (Id, Code, NameRu, NameKz, DateCreate, IsDeleted)
values(5, '5', N'Не рекомендовать', N'Не рекомендовать', DATEFROMPARTS(2017,1,1), 0)
go
insert into EXP_DIC_StageResult (Id, Code, NameRu, NameKz, DateCreate, IsDeleted)
values(6, '6', N'Рассмотреть документы повторно', N'Рассмотреть документы повторно', DATEFROMPARTS(2017,1,1), 0)
go
insert into EXP_DIC_StageResult (Id, Code, NameRu, NameKz, DateCreate, IsDeleted)
values(7, '7', N'Решение Экспертного Совета', N'Решение Экспертного Совета', DATEFROMPARTS(2017,1,1), 0)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (1,1)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (1,2)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (1,3)

go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (2,3)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (2,4)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (2,5)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (2,6)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (2,7)

go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (3,3)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (3,4)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (3,5)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (3,6)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (3,7)

go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (4,1)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (4,2)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (4,3)

go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (8,1)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (8,2)

go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (5,1)
go
insert into EXP_DIC_ResultByStage (StageId, StageResultId) values (5,2)