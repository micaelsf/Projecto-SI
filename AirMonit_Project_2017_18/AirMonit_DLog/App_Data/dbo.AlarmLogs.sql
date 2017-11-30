CREATE TABLE [dbo].[AlarmLogs]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [CityId] INT NOT NULL,
    [Type] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(50)    NULL,
    [Date_Time] DATETIME NOT NULL, 
    [UncomonEvents] NVARCHAR(50) NULL, 
    [Value] SMALLINT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
