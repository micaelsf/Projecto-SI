CREATE TABLE [dbo].[UncommonEvents]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CityId] INT NOT NULL,
    [Type] NVCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NOT NULL, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Temperature] INT NOT NULL
)
