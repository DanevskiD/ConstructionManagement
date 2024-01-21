CREATE TABLE [dbo].[Document]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UID] UNIQUEIDENTIFIER NOT NULL, 
    [DeletedOn] SMALLDATETIME NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(100) NOT NULL, 
    [ProjectFK] INT NOT NULL, 
    CONSTRAINT [FK_Document_Project] FOREIGN KEY ([ProjectFK]) REFERENCES [Project]([Id]),
    
)
