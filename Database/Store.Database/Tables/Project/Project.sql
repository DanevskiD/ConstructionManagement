CREATE TABLE [dbo].[Project] 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UID] UNIQUEIDENTIFIER NOT NULL, 
    [DeletedOn] SMALLDATETIME NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [InternalNumber] INT NULL, 
    [UserFK] INT NOT NULL, 
    CONSTRAINT [FK_Project_User] FOREIGN KEY ([UserFK]) REFERENCES [User]([Id])
  
    
)
