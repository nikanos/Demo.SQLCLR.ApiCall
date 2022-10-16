CREATE TABLE [dbo].[ConfigurationParameter]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParameterName] NVARCHAR(50) NOT NULL, 
    [ParameterValue] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL
)
