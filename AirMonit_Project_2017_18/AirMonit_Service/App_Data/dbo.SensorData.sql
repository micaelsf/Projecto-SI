CREATE TABLE [dbo].[SensorData]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Param] NVARCHAR(10) NOT NULL, 
    [Value] TINYINT NOT NULL, 
    [CityId] TINYINT NOT NULL, 
    [DateTime] DATETIME NULL, 
    [SensorId] INT NOT NULL 
)
