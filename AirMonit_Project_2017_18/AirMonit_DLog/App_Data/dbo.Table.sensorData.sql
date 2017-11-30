CREATE TABLE [dbo].[sensorData]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [City_Id] INT NOT NULL, 
    [Date_Time] DATETIME NOT NULL, 
    [Param] VARCHAR (10) NOT NULL, 
	[Value] INT NOT NULL, 
	PRIMARY KEY CLUSTERED ([Id] ASC)
)

