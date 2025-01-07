CREATE TABLE [dbo].[MenuItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(255) NOT NULL, 
    [Image] NVARCHAR(255) NOT NULL DEFAULT 'https://placehold.co/400', 
    [Price] DECIMAL(10, 2) NOT NULL, 
    [DisplayOrder] INT NULL DEFAULT 0, 
    [FoodTypeId] INT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_MenuItems_FoodType_FoodTypeIdTo] FOREIGN KEY ([FoodTypeId]) REFERENCES [dbo].[FoodTypes]([Id]), 
    CONSTRAINT [FK_MenuItems_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories]([Id]) 
)
