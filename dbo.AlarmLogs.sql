CREATE TABLE [dbo].[AlarmLogs] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Description]   NVARCHAR (200) NOT NULL,
    [Date_Time]     DATETIME      NOT NULL,
    [SensorDataId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

