﻿--Условия хранения Code(storage)
--Внешнее состояние Code(external)
USE ncelsTest
GO
UPDATE OBK_Ref_MaterialCondition SET IsDeleted = 1 WHERE Code IN('storage','external')
GO 

INSERT INTO dbo.OBK_Ref_MaterialCondition
(
  Id
 ,Code
 ,NameRu
 ,NameKz
 ,IsDeleted
)
VALUES
(
  NEWID()
 ,N'storage'
 ,N'на полу, влажность и температурный режим не контролируется,'
 ,N'на поддонах, влажность и температурный режим контролируется'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'на стеллажах, влажность и температурный режим контролируется'
 ,N'на стеллажах, влажность и температурный режим контролируется'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'в сухом месте с соблюдением температурного режима'
 ,N'в сухом месте с соблюдением температурного режима'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'влажность и температурный режим контролируется'
 ,N'влажность и температурный режим контролируется'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'на поддонах в сухом вентилируемом помещении'
 ,N'на поддонах в сухом вентилируемом помещении'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'на поддонах в сухом вентилируемом и в защищенном от света  помещении, влажность и температурный режи'
 ,N'на поддонах в сухом вентилируемом и в защищенном от света  помещении, влажность и температурный режи'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'на стеллажах в сухом вентилируемом помещении, в защищенном от света месте с соблюдением температурного режима'
 ,N'на стеллажах в сухом вентилируемом помещении, в защищенном от света месте с соблюдением температурного режима'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'на поддонах в сухом вентилируемом помещении, соответствуют требованиям приказа МЗ и С РК №238 от 10.'
 ,N'на поддонах в сухом вентилируемом помещении, соответствуют требованиям приказа МЗ и С РК №238 от 10.'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'при температуре от 2 градусов до 8 С'
 ,N'при температуре от 2 градусов до 8 С'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'на поддонах, влажность и температурный режим контролируется, температура от +15 до +25 С'
 ,N'на поддонах, влажность и температурный режим контролируется, температура от +15 до +25 С'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'соответствуют требованиям приказа МЗ и С РК №238 от 10.05.1999 г.'
 ,N'соответствуют требованиям приказа МЗ и С РК №238 от 10.05.1999 г.'
 ,0
),(
  NEWID()
 ,N'storage'
 ,N'температурный режим, влажность соблюдается, хранение на поддонах в сухом помещении'
 ,N'температурный режим, влажность соблюдается, хранение на поддонах в сухом помещении'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'без подмочек, разрывов, состояние упаковки удовлетворительное'
 ,N'без подмочек, разрывов, состояние упаковки удовлетворительное'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'без подмочек, разрывов, состояние упаковки удовлетворительное, в пластиковом контейнере вместе с инструкцией по применению на госуд. и русс. языках помещены в картонную коробку'
 ,N'без подмочек, разрывов, состояние упаковки удовлетворительное, в пластиковом контейнере вместе с инструкцией по применению на госуд. и русс. языках помещены в картонную коробку'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'без подмочек, разрывов, состояние упаковки удовлетворительное, вместе с инструкцией по применению на госуд. и русс. языках помещены в картонную коробку'
 ,N'без подмочек, разрывов, состояние упаковки удовлетворительное, вместе с инструкцией по применению на госуд. и русс. языках помещены в картонную коробку'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'без подмочек, разрывов, состояние упковки удовлетворительное, блистеры упакованы в коробочку с инструкцией на рус. и каз. языках, флаконы из прозрачного стекла, укупоренные пробками с аллюминиевыми и пластиковыми колпачками, флаконы упакованы'
 ,N'без подмочек, разрывов, состояние упковки удовлетворительное, блистеры упакованы в коробочку с инструкцией на рус. и каз. языках, флаконы из прозрачного стекла, укупоренные пробками с аллюминиевыми и пластиковыми колпачками, флаконы упакованы'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'в соответствии с ГОСТ 17768 - 90Е - растворы во флаконах из стекла с навинчиваемой пластмассовой крышкой, без подмочек, разрывов, состояние упаковки удовлетворительное'
 ,N'в соответствии с ГОСТ 17768 - 90Е - растворы во флаконах из стекла с навинчиваемой пластмассовой крышкой, без подмочек, разрывов, состояние упаковки удовлетворительное'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'по 5 картриджей в контурной ячейковой упаковке из поливинилхлоридной пленки и приваренной к ней фольги алюминиевой'
 ,N'по 5 картриджей в контурной ячейковой упаковке из поливинилхлоридной пленки и приваренной к ней фольги алюминиевой'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'продукция упакована в полиэтиленовые пакеты и картонные коробки'
 ,N'продукция упакована в полиэтиленовые пакеты и картонные коробки'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'продукция упакована в полиэтиленовые пакеты и картонные коробки, без подмочек, разрывов, состояние упаковки удовлетворительное'
 ,N'продукция упакована в полиэтиленовые пакеты и картонные коробки, без подмочек, разрывов, состояние упаковки удовлетворительное'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'флаконы из прозрачного стекла, укупоренные пробками с аллюминиевыми и пластиковыми колпачками, флаконы упакованы в картонные коробочки'
 ,N'флаконы из прозрачного стекла, укупоренные пробками с аллюминиевыми и пластиковыми колпачками, флаконы упакованы в картонные коробочки'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'состояние упаковочного материала неудовлетворительное; на мешковине и полиэтил. пленке имеются загрязнения неизвестной этиологии, а также частично загрязнена марля'
 ,N'состояние упаковочного материала неудовлетворительное; на мешковине и полиэтил. пленке имеются загрязнения неизвестной этиологии, а также частично загрязнена марля'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'без подмочек, разрывов, состояние упаковки удовлетворительное, вместе с инструкцией по применению на госуд. и русском языках'
 ,N'без подмочек, разрывов, состояние упаковки удовлетворительное, вместе с инструкцией по применению на госуд. и русском языках'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'без подмочек, разрывов, состояние упковки удовлетворительное. Блистеры упакованы в коробочку с инструкцией на рус. и каз. языках'
 ,N'без подмочек, разрывов, состояние упковки удовлетворительное. Блистеры упакованы в коробочку с инструкцией на рус. и каз. языках'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'в пластиковом контейнере вместе с инструкцией по применению на госуд. и русс. языках помещены в картонную коробку'
 ,N'в пластиковом контейнере вместе с инструкцией по применению на госуд. и русс. языках помещены в картонную коробку'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'в соответствии с ГОСТ 17768 - 90Е - растворы во флаконах из стекла с навинчиваемой пластмассовой крышкой, имеет наружную упаковку в виде картонных коробок'
 ,N'в соответствии с ГОСТ 17768 - 90Е - растворы во флаконах из стекла с навинчиваемой пластмассовой крышкой, имеет наружную упаковку в виде картонных коробок'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'в стомат. цилиндрические картриджи прозрачного бесцветного стекла, укупоренные резиновыми поршнем и обжатые алюминовыми колпачками '
 ,N'в стомат. цилиндрические картриджи прозрачного бесцветного стекла, укупоренные резиновыми поршнем и обжатые алюминовыми колпачками '
 ,0
),(
  NEWID()
 ,N'external'
 ,N'вместе с инструкцией по применению на госуд. и русском яз. помещен в коробку из картона.'
 ,N'вместе с инструкцией по применению на госуд. и русском яз. помещен в коробку из картона.'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'групповая и транспортная упаковка в соответствии с ГОСТ 17768 - 90Е '
 ,N'групповая и транспортная упаковка в соответствии с ГОСТ 17768 - 90Е '
 ,0
),(
  NEWID()
 ,N'external'
 ,N'по __ картриджей в контурной ячейковой упаковке из поливинилхлоридной пленки и приваренной к ней фольги алюминиевой '
 ,N'по __ картриджей в контурной ячейковой упаковке из поливинилхлоридной пленки и приваренной к ней фольги алюминиевой '
 ,0
),(
  NEWID()
 ,N'external'
 ,N'помещены в ламинированный пакетик с этикеткой'
 ,N'помещены в ламинированный пакетик с этикеткой'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'продукция упакована в  картонные коробки'
 ,N'продукция упакована в  картонные коробки'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'продукция упакована в полиэтиленовые пакеты'
 ,N'продукция упакована в полиэтиленовые пакеты'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'продукция упакована вместе с инструкциями по применению на государственном и русском языках'
 ,N'продукция упакована вместе с инструкциями по применению на государственном и русском языках'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'упакованы в пластмассовые флаконы с навинчивающей крышкой'
 ,N'упакованы в пластмассовые флаконы с навинчивающей крышкой'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'флаконы из прозрачного стекла, укупоренные пробками с аллюминиевыми и пластиковыми колпачками'
 ,N'флаконы из прозрачного стекла, укупоренные пробками с аллюминиевыми и пластиковыми колпачками'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'флаконы из прозрачного стекла, укупоренные пробками с аллюминиевыми колпачками, флаконы упакованы в картонные коробочки, продукция упакована вместе с инструкциями по применению на государственном и русском языках'
 ,N'флаконы из прозрачного стекла, укупоренные пробками с аллюминиевыми колпачками, флаконы упакованы в картонные коробочки, продукция упакована вместе с инструкциями по применению на государственном и русском языках'
 ,0
),(
  NEWID()
 ,N'external'
 ,N'обеспечивает защиту продукции от внешних воздействий'
 ,N'обеспечивает защиту продукции от внешних воздействий'
 ,0
);
GO