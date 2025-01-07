CREATE TABLE [dbo].[Categories]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryName] NVARCHAR(25) NOT NULL, 
    [DisplayOrder] INT NOT NULL 
)
