CREATE TABLE [dbo].[UncommonEvents]
(
	[Id] SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CityId] TINYINT NOT NULL, 
    [Description] NVARCHAR(200) NOT NULL, 
    [UserId] NVARCHAR(50) NOT NULL, 
    [Temperature] TINYINT NOT NULL
)
