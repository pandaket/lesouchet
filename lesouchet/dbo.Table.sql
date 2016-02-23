CREATE TABLE [dbo].[Table]
(
	[Номер] INT NOT NULL PRIMARY KEY, 
    [Лесничество] TEXT NULL, 
    [Квартал] TEXT NULL, 
    [Тип лесорастительных условий] TEXT NULL, 
    [Площадь участка (га)] TEXT NULL, 
    [Способ производства] TEXT NULL, 
    [Категория защитных насаждений] TEXT NULL, 
    [Главная порода] TEXT NULL, 
    [Схема смешения] TEXT NULL, 
    [Количество посадочных мест на 1 га (шт)] INT NULL, 
    [Длина посадочных рядов на 1 га (м)] REAL NULL, 
    [Размещение (м)] REAL NULL
)
