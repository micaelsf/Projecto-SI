CREATE TABLE [dbo].[AlarmLogs]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [City] NVARCHAR (50) NOT NULL,
    [Alarm] NVARCHAR(50) NOT NULL,
    [Incident] NVARCHAR(50)    NULL,
    [Date_Time] DATETIME NOT NULL, 
    [UncomonEvents] NVARCHAR(50) NULL, 
    [Value] SMALLINT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
