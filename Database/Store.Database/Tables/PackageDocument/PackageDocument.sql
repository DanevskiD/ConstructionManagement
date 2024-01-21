CREATE TABLE [dbo].[PackageDocuments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UID] UNIQUEIDENTIFIER NOT NULL, 
    [DeletedOn] SMALLDATETIME NULL, 
    [PackageFK] INT NOT NULL, 
    [DocumentFK] INT NOT NULL, 
    CONSTRAINT [FK_PackageDocument_Package] FOREIGN KEY ([PackageFK]) REFERENCES [Package]([Id]), 
    CONSTRAINT [FK_PackageDocument_Document] FOREIGN KEY ([DocumentFK]) REFERENCES [Document]([Id])
)
