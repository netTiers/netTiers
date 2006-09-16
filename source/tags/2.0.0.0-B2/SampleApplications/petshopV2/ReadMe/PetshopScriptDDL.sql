USE [Master]
GO 
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'petshopDB')
DROP DATABASE [petshopDB]
GO

/***** Create petshop database -- 7/17/2006 1:56:38 AM ****/
CREATE DATABASE [petshopDB] 
GO 

USE [petshopDB] 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderStatusType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderStatusType](
	[OrderStatusId] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatus] [varchar](24) NOT NULL,
	[OrderStatusDescription] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderStatusId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[OrderStatusType]') AND name = N'IX_OrderStatusType')
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrderStatusType] ON [dbo].[OrderStatusType] 
(
	[OrderStatus] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'Used to represent an OrderStatusTypeList Enumeration' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'OrderStatusType'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Courier]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Courier](
	[CourierId] [uniqueidentifier] NOT NULL,
	[CourierName] [varchar](30) NOT NULL,
	[CourierDescription] [varchar](60) NULL,
	[MinItems] [int] NOT NULL,
	[MaxItems] [int] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Courier] PRIMARY KEY CLUSTERED 
(
	[CourierId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'Used to simulate finding a courier based on business rules, albeit simple ones.  Each courier can supply only so many pets.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Courier'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CreditCard]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CreditCard](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [varchar](255) NOT NULL,
	[CardType] [varchar](255) NOT NULL,
	[ExpiryMonth] [varchar](255) NOT NULL,
	[ExpiryYear] [varchar](255) NOT NULL,
	[Timestamp] [timestamp] NOT NULL
 CONSTRAINT [PK_CreditCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Category](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[AdvicePhoto] [varchar](255) NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Supplier]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Supplier](
	[SuppId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](80) NULL,
	[Status] [varchar](2) NOT NULL,
	[Addr1] [varchar](80) NULL,
	[Addr2] [varchar](80) NULL,
	[City] [varchar](80) NULL,
	[State] [varchar](80) NULL,
	[Zip] [varchar](5) NULL,
	[Phone] [varchar](40) NULL,
	[Timestamp] [timestamp] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[SuppId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderStatus](
	[OrderId] [int] NOT NULL,
	[LineNum] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PkOrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[LineNum] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[ShipAddr1] [varchar](80) NOT NULL,
	[ShipAddr2] [varchar](80) NULL,
	[ShipCity] [varchar](80) NOT NULL,
	[ShipState] [varchar](80) NOT NULL,
	[ShipZip] [varchar](20) NOT NULL,
	[ShipCountry] [varchar](20) NULL,
	[BillAddr1] [varchar](80) NOT NULL,
	[BillAddr2] [varchar](80) NULL,
	[BillCity] [varchar](80) NOT NULL,
	[BillState] [varchar](80) NOT NULL,
	[BillZip] [varchar](20) NOT NULL,
	[BillCountry] [varchar](20) NULL,
	[CourierId] [uniqueidentifier] NOT NULL,
	[TotalPrice] [decimal](10, 2) NULL,
	[BillToFirstName] [varchar](80) NOT NULL,
	[BillToLastName] [varchar](80) NOT NULL,
	[ShipToFirstName] [varchar](80) NOT NULL,
	[ShipToLastName] [varchar](80) NOT NULL,
	[CreditCardId] [uniqueidentifier] NOT NULL,
	[Locale] [varchar](20) NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK__Orders__0CBAE877] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Account](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[StreetAddress] [varchar](255) NULL,
	[PostalCode] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[StateOrProvince] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
	[TelephoneNumber] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Login] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[IWantMyList] [bit] NULL,
	[IWantPetTips] [bit] NULL,
	[FavoriteLanguage] [varchar](255) NULL,
	[CreditCardId] [uniqueidentifier] NULL,
	[FavoriteCategoryId] [uniqueidentifier] NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND name = N'IX_Account')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account] ON [dbo].[Account] 
(
	[Login] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND name = N'IX_Account_LastName')
CREATE NONCLUSTERED INDEX [IX_Account_LastName] ON [dbo].[Account] 
(
	[LastName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Item](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
	[Price] [float] NULL,
	[Currency] [varchar](255) NULL,
	[Photo] [varchar](255) NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LineItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LineItem](
	[OrderId] [int] NOT NULL,
	[LineNum] [int] NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PkLineItem] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[LineNum] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Inventory](
	[ItemId] [uniqueidentifier] NOT NULL,
	[SuppId] [uniqueidentifier] NOT NULL,
	[Qty] [int] NOT NULL,
	[Timestamp] Timestamp NOT NULL
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC,
	[SuppId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OrderStat__Order__164452B1]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderStatus]'))
ALTER TABLE [dbo].[OrderStatus]  WITH CHECK ADD  CONSTRAINT [FK__OrderStat__Order__164452B1] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderStatus_OrderStatusType]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderStatus]'))
ALTER TABLE [dbo].[OrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_OrderStatus_OrderStatusType] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[OrderStatusType] ([OrderStatusId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Account]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Courier]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Courier] FOREIGN KEY([CourierId])
REFERENCES [dbo].[Courier] ([CourierId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_CreditCard]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_CreditCard] FOREIGN KEY([CreditCardId])
REFERENCES [dbo].[CreditCard] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Category] FOREIGN KEY([FavoriteCategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_CreditCard]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_CreditCard] FOREIGN KEY([CreditCardId])
REFERENCES [dbo].[CreditCard] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Product_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Item_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[Item]'))
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__LineItem__OrderI__1367E606]') AND parent_object_id = OBJECT_ID(N'[dbo].[LineItem]'))
ALTER TABLE [dbo].[LineItem]  WITH CHECK ADD  CONSTRAINT [FK__LineItem__OrderI__1367E606] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LineItem_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[LineItem]'))
ALTER TABLE [dbo].[LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Inventory_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[Inventory]'))
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Inventory_Supplier]') AND parent_object_id = OBJECT_ID(N'[dbo].[Inventory]'))
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Supplier] FOREIGN KEY([SuppId])
REFERENCES [dbo].[Supplier] ([SuppId])
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ExtendedItem]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[ExtendedItem]
AS
SELECT
dbo.Item.Id AS ItemId, dbo.Item.Name AS ItemName, dbo.Item.Description AS ItemDescription, dbo.Item.Price AS ItemPrice,
dbo.Item.Photo AS ItemPhoto , dbo.Product.Id AS ProductId, dbo.Product. Name AS ProductName, dbo. Product.Description AS ProductDescription,
dbo.Category.Id AS CategoryId , dbo.Category.Name AS CategoryName
FROM
	dbo.Category 
INNER JOIN 
	dbo.Product on Product.CategoryId = Category.Id
INNER JOIN
	dbo.Item on Product.Id = Item.ProductId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


	INSERT INTO [dbo].[Category]
	([Id],[Name],[AdvicePhoto],[Timestamp])
 values
		('6ea4bc05-2402-45ee-b707-e3ba1f865f4d', 'Reptiles', 'reptiles_icon.gif', null)
GO
	INSERT INTO [dbo].[Category]
	([Id],[Name],[AdvicePhoto],[Timestamp])
 values
		('6eb220f9-7992-4e19-a264-54a50ea0e389', 'Cats', 'cats_icon.gif', null)
GO
	INSERT INTO [dbo].[Category]
	([Id],[Name],[AdvicePhoto],[Timestamp])
 values
		('7c6cc986-bee6-42ac-948a-bf8f579ac3dc', 'Dogs', 'dogs_icon.gif', null)
GO
	INSERT INTO [dbo].[Category]
	([Id],[Name],[AdvicePhoto],[Timestamp])
 values
		('99d1bea3-9c50-466a-b082-d1954d736644', 'Birds', 'birds_icon.gif', null)
GO
	INSERT INTO [dbo].[Category]
	([Id],[Name],[AdvicePhoto],[Timestamp])
 values
		('b8469bb3-991b-4623-a7ea-d772106698be', 'Fish', 'fish_icon.gif', null)
GO

INSERT INTO [dbo].[CreditCard]
	([Id],[Number],[CardType],[ExpiryMonth],[ExpiryYear],[Timestamp])
 values
		('fbcba852-4d7a-4df3-b984-8f33930b5c30', '1234-1234-1234', 'VISA', '07', '2006', null)
GO
	INSERT INTO [dbo].[CreditCard]
	([Id],[Number],[CardType],[ExpiryMonth],[ExpiryYear],[Timestamp])
 values
		('fbcba852-4d7a-4df3-b984-8f35829b5c12', '4567-4567-4567', 'VISA', '09', '2008', null)
GO
	INSERT INTO [dbo].[CreditCard]
	([Id],[Number],[CardType],[ExpiryMonth],[ExpiryYear],[Timestamp])
 values
		('fbcba852-4d7a-4df3-b984-8f33929b5c28', '98798765', 'MasterCard', '12', '2004', null)
GO
    

	INSERT INTO [dbo].[Account]
	([Id],[FirstName],[LastName],[StreetAddress],[PostalCode],[City],[StateOrProvince],[Country],[TelephoneNumber],[Email],[Login],[Password],[IWantMyList],[IWantPetTips],[FavoriteLanguage],[CreditCardId],[FavoriteCategoryId],[Timestamp])
 values
		('2ca631d3-1385-4fc1-8cef-715730b03d3b', 'John', 'Doe', 'noWhere street', '55555', 'Atlantis', NULL, 'USA', '555-1234', 'jroland@gmail.com', 'demo', 'demo', 0, 0, NULL, NULL, '6ea4bc05-2402-45ee-b707-e3ba1f865f4d', null)
GO
	INSERT INTO [dbo].[Account]
	([Id],[FirstName],[LastName],[StreetAddress],[PostalCode],[City],[StateOrProvince],[Country],[TelephoneNumber],[Email],[Login],[Password],[IWantMyList],[IWantPetTips],[FavoriteLanguage],[CreditCardId],[FavoriteCategoryId],[Timestamp])
 values
		('675cba0f-c2c1-4e37-939f-393758e53f95', 'Frank', 'Sanders', '3299 W. Apple Drive', '87454', 'Middletown', 'USA', '213-393-3998', NULL, 'rawi@br.com', 'rawi', 'rawi', 0, 0, 'en-GB', NULL, '6eb220f9-7992-4e19-a264-54a50ea0e389', null)
GO
	INSERT INTO [dbo].[Account]
	([Id],[FirstName],[LastName],[StreetAddress],[PostalCode],[City],[StateOrProvince],[Country],[TelephoneNumber],[Email],[Login],[Password],[IWantMyList],[IWantPetTips],[FavoriteLanguage],[CreditCardId],[FavoriteCategoryId],[Timestamp])
 values
		('81c70769-d79d-40fe-a45f-44b0fe61dce3', 'Robert', 'Hinojosa', '500 W. Main St', '76123', 'Fort Worth', 'Texas', 'USA', '214-555-3322', 'rhinojosa@codesmithtools.com', 'rhinojosa', 'pass', 0, 0, 'en-US', NULL, NULL, null)
GO
	INSERT INTO [dbo].[Account]
	([Id],[FirstName],[LastName],[StreetAddress],[PostalCode],[City],[StateOrProvince],[Country],[TelephoneNumber],[Email],[Login],[Password],[IWantMyList],[IWantPetTips],[FavoriteLanguage],[CreditCardId],[FavoriteCategoryId],[Timestamp])
 values
		('969c1ea5-b9ea-4a49-a91c-97bc033bfc2e', 'Slim', 'Gribnik', '123 Any', '55565', 'Maple Grove', 'MN', 'USA', '585-585-8555', 'slim@rhodnett.com', 'slim', 'slimy', 0, 0, 'en-GB', NULL, '6eb220f9-7992-4e19-a264-54a50ea0e389', null)
GO
	INSERT INTO [dbo].[Account]
	([Id],[FirstName],[LastName],[StreetAddress],[PostalCode],[City],[StateOrProvince],[Country],[TelephoneNumber],[Email],[Login],[Password],[IWantMyList],[IWantPetTips],[FavoriteLanguage],[CreditCardId],[FavoriteCategoryId],[Timestamp])
 values
		('e294a25f-ef9e-4692-9dec-0a9a56292b69', 'DontCall', 'MeShirley', NULL, NULL, NULL, NULL, NULL, NULL, 'rr', 'rr', 'rr', 0, 0, 'en-GB', NULL, '6eb220f9-7992-4e19-a264-54a50ea0e389', null)
GO
	INSERT INTO [dbo].[Account]
	([Id],[FirstName],[LastName],[StreetAddress],[PostalCode],[City],[StateOrProvince],[Country],[TelephoneNumber],[Email],[Login],[Password],[IWantMyList],[IWantPetTips],[FavoriteLanguage],[CreditCardId],[FavoriteCategoryId],[Timestamp])
 values
		('fcfd4760-5631-4fa3-bbd1-3e8ffd66b509', 'Power', 'User', '323 Outside st', '75142', 'Aledo', 'TX', '887-851-5698', NULL, 'proyecto2001', 'proyecto2001', 'proyecto2001', 0, 0, 'en-GB', NULL, '6eb220f9-7992-4e19-a264-54a50ea0e389', null)
GO

	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('036adf72-5e23-4af0-9671-e5f3ba10482b', 'Labrador Retriever', 'Great hunting dog', '7c6cc986-bee6-42ac-948a-bf8f579ac3dc', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('07fff0cf-11c3-470f-958b-b5da3ddedb0b', 'Finch', 'Great stress reliever', '99d1bea3-9c50-466a-b082-d1954d736644', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('24f57c8d-a7f2-4e10-ba97-02cf13fa13e6', 'Dalmation', 'Great dog for a Fire Station', '7c6cc986-bee6-42ac-948a-bf8f579ac3dc', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('258c26a0-9eee-421d-a3c2-dc4b426ef891', 'Angelfish', 'Salt Water fish from Australia', 'b8469bb3-991b-4623-a7ea-d772106698be', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('316af4fc-8b22-4096-8d8c-35f66fd33601', 'Tiger Shark', 'Salt Water fish from Australia', 'b8469bb3-991b-4623-a7ea-d772106698be', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('42d0a9ed-c325-4e44-8bb4-fccef84f533b', 'Bulldog', 'Friendly dog from England', '7c6cc986-bee6-42ac-948a-bf8f579ac3dc', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('5220ab1c-c77d-418e-8931-d4ddd5074f03', 'Persian', 'Friendly house cat, doubles as a princess', '6eb220f9-7992-4e19-a264-54a50ea0e389', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('53c52166-8d76-4ef7-acc6-4f11fc6e83d4', 'Amazon Parrot', 'Great companion for up to 75 years', '99d1bea3-9c50-466a-b082-d1954d736644', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('724f0a12-ed75-4c5d-86b6-36266cc9eebb', 'Golden Retriever', 'Great family dog', '7c6cc986-bee6-42ac-948a-bf8f579ac3dc', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('7d17eaa6-ca5f-43ab-a894-d5101a5e4112', 'Iguana', 'Friendly green friend', '6ea4bc05-2402-45ee-b707-e3ba1f865f4d', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('7d5ae7a5-c9cc-497e-af3d-ce968bcb67b1', 'Rattlesnake', 'Doubles as a watch dog', '6ea4bc05-2402-45ee-b707-e3ba1f865f4d', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('8b219ee4-9e0d-4937-81ef-95de76383170', 'Chihuahua', 'Great companion dog', '7c6cc986-bee6-42ac-948a-bf8f579ac3dc', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('a992c0ad-f5a4-471f-8fcd-b16e72eebd4c', 'Koi', 'Fresh Water fish from Japan', 'b8469bb3-991b-4623-a7ea-d772106698be', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('ea27ba68-4894-43f7-aee6-e0712752af3f', 'Poodlesss', 'Cute dog from France', '7c6cc986-bee6-42ac-948a-bf8f579ac3dc', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('ecf90932-d852-450e-a3b2-9cb0012a9d9c', 'Manx', 'Great for reducing mouse populations', '6eb220f9-7992-4e19-a264-54a50ea0e389', null)
GO
	INSERT INTO [dbo].[Product]
	([Id],[Name],[Description],[CategoryId],[Timestamp])
 values
		('f73db909-f20a-476d-af5a-13c55c05215e', 'Goldfish', 'Fresh Water fish from China', 'b8469bb3-991b-4623-a7ea-d772106698be', null)
GO


INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('02a457cd-17bf-4704-897a-1653f6475039', 'Spotless Male Puppy Dalmation', 'Great dog for a Fire Station', 18.5, 'USD', 'dog5.gif', '24f57c8d-a7f2-4e10-ba97-02cf13fa13e6', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('12e6a8fd-00a3-46b0-9cd2-6620e67de037', 'Spotted Angelfish', 'Fresh Water fish from Japan', 18.5, 'USD', 'fish3.gif', '258c26a0-9eee-421d-a3c2-dc4b426ef891', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('17211b39-67cf-47e7-bc90-53814f47b8f4', 'Male Puppy Poodle', 'Cute dog from France', 18.5, 'USD', 'dog6.gif', 'ea27ba68-4894-43f7-aee6-e0712752af3f', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('28556ab6-f5da-4543-845c-ceff4f31b052', 'Female Puppy Bulldog', 'Friendly dog from England', 18.5, 'USD', 'dog2.gif', '42d0a9ed-c325-4e44-8bb4-fccef84f533b', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('3357f691-e48d-4e08-b7c3-d2518f7375db', 'Venomless Rattlesnake', 'Doubles as a watch dog', 18.5, 'USD', 'lizard3.gif', '7d5ae7a5-c9cc-497e-af3d-ce968bcb67b1', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('3d51c10a-7db3-417a-90a9-b9e817dda8f1', 'Adult Female Persian', 'Friendly house cat, doubles as a princess', 93.5, 'USD', 'cat1.gif', '5220ab1c-c77d-418e-8931-d4ddd5074f03', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('59ab030e-31e1-4172-9efd-65699f9bd3eb', 'Small Angelfish', 'Fresh Water fish from Japan', 16.5, 'USD', 'fish3.gif', '258c26a0-9eee-421d-a3c2-dc4b426ef891', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('74c04620-ff58-4a7b-9916-b8e475001325', 'Spotless Angelfish', 'Fresh Water fish from Japan', 18.5, 'USD', 'fish3.gif', '258c26a0-9eee-421d-a3c2-dc4b426ef891', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('8145b066-d2ab-4af4-b7c1-139bacf6437b', 'Adult Male Persian', 'Friendly house cat, doubles as a princess', 93.5, 'USD', 'cat1.gif', '5220ab1c-c77d-418e-8931-d4ddd5074f03', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('9511da02-e885-4918-9530-49165ccba60b', 'Adult Male Amazon Parrot', 'Great companion for up to 75 years', 193.5, 'USD', 'bird4.gif', '53c52166-8d76-4ef7-acc6-4f11fc6e83d4', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('a178b17b-4d65-48ba-912f-b058f7a56d91', 'Mean Toothless Tiger Shark', 'Salt Water fish from Australia', 18.5, 'USD', 'fish4.gif', '316af4fc-8b22-4096-8d8c-35f66fd33601', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('a19dc7a0-9569-4aa9-8ea4-9f699a06f87c', 'Tailless Manx', 'Great for reducing mouse populations', 58.5, 'USD', 'cat3.gif', 'ecf90932-d852-450e-a3b2-9cb0012a9d9c', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('a9ecbff4-8745-478c-bef8-4fc201d28bd4', 'Adult Male Finch', 'Great stress reliever', 15.5, 'USD', 'bird1.gif', '07fff0cf-11c3-470f-958b-b5da3ddedb0b', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('bdbf9dfe-3f60-4c87-9cc9-a1cbcb93722e', 'With Tail Manx', 'Great for reducing mouse populations', 58.5, 'USD', 'cat3.gif', 'ecf90932-d852-450e-a3b2-9cb0012a9d9c', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('d3e67ba4-b16c-4692-92fd-35e12df08700', 'Large Cuddly Angelfish', 'Fresh Water fish from Japan', 16.5, 'USD', 'fish3.gif', '258c26a0-9eee-421d-a3c2-dc4b426ef891', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('d718411b-4294-4903-8699-98cc33272328', 'Male Adult Bulldog', 'Friendly dog from England', 18.5, 'USD', 'dog2.gif', '42d0a9ed-c325-4e44-8bb4-fccef84f533b', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('dd7a9839-1e37-4de6-b642-9e34d2b943aa', 'Spotted Adult Female Dalmation', 'Great dog for a Fire Station', 18.5, 'USD', 'dog5.gif', '24f57c8d-a7f2-4e10-ba97-02cf13fa13e6', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('e31a4b43-558b-4a99-9f16-14aaef49cbcf', 'Adult Female Angelfish', 'Fresh Water fish from China', 5.29, 'USD', 'fish2.gif', 'f73db909-f20a-476d-af5a-13c55c05215e', null)
GO
	INSERT INTO [dbo].[Item]
	([Id],[Name],[Description],[Price],[Currency],[Photo],[ProductId],[Timestamp])
 values
		('e779639d-65c4-4e65-9aef-0c0dd09af2db', 'Venomless Iguana', 'Friendly green friend', 18.5, 'USD', 'lizard2.gif', '7d17eaa6-ca5f-43ab-a894-d5101a5e4112', null)
GO

INSERT INTO [Courier] VALUES 
('0FC46B67-1873-4E45-9745-814EB8B1C1D1', 'NTS Shipping', 'NetTiers Shipping Delivers Low Volume Goods', 1, 2, null)
GO
INSERT INTO [Courier] VALUES 
('A79505E6-650E-4CE0-B171-97D15377CB8E', 'NetTiers Delivers', 'NetTiers Delivers High Volume Goods ', 3, 100, null)
GO

INSERT INTO [Supplier] VALUES 
('72EA9F26-4ACA-4220-AF43-CC035A3653CA', 'XYZ Pets', 'AC', '600 Avon Way', '', 'Los Angeles', 'CA', '94024', '212-947-0797', null)
GO
INSERT INTO [Supplier] VALUES 
('D98D7E84-E25F-4DD9-8880-0713F884863B', 'ABC Pets', 'AC', '700 Abalone Way', '', 'San Francisco', 'CA', '94024', '415-947-0797', null)
GO




INSERT INTO [Inventory] VALUES ('02a457cd-17bf-4704-897a-1653f6475039', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 5, null)
GO
INSERT INTO [Inventory] VALUES ('12e6a8fd-00a3-46b0-9cd2-6620e67de037', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 10, null)
GO
INSERT INTO [Inventory] VALUES ('17211b39-67cf-47e7-bc90-53814f47b8f4', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 3, null)
GO
INSERT INTO [Inventory] VALUES ('28556ab6-f5da-4543-845c-ceff4f31b052', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 2, null)
GO
INSERT INTO [Inventory] VALUES ('3357f691-e48d-4e08-b7c3-d2518f7375db', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 1, null)
GO
INSERT INTO [Inventory] VALUES ('3d51c10a-7db3-417a-90a9-b9e817dda8f1', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 4, null)
GO
INSERT INTO [Inventory] VALUES ('59ab030e-31e1-4172-9efd-65699f9bd3eb', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 11, null)
GO
INSERT INTO [Inventory] VALUES ('74c04620-ff58-4a7b-9916-b8e475001325', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 10, null)
GO
INSERT INTO [Inventory] VALUES ('8145b066-d2ab-4af4-b7c1-139bacf6437b', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 5, null)
GO
INSERT INTO [Inventory] VALUES ('9511da02-e885-4918-9530-49165ccba60b', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 6, null)
GO
INSERT INTO [Inventory] VALUES ('a178b17b-4d65-48ba-912f-b058f7a56d91', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 2, null)
GO
INSERT INTO [Inventory] VALUES ('a19dc7a0-9569-4aa9-8ea4-9f699a06f87c', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 1, null)
GO
INSERT INTO [Inventory] VALUES ('a9ecbff4-8745-478c-bef8-4fc201d28bd4', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 4, null)
GO
INSERT INTO [Inventory] VALUES ('bdbf9dfe-3f60-4c87-9cc9-a1cbcb93722e', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 5, null)
GO
INSERT INTO [Inventory] VALUES ('d3e67ba4-b16c-4692-92fd-35e12df08700', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 7, null)
GO
INSERT INTO [Inventory] VALUES ('d718411b-4294-4903-8699-98cc33272328', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 10, null)
GO
INSERT INTO [Inventory] VALUES ('dd7a9839-1e37-4de6-b642-9e34d2b943aa', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 5, null)
GO
INSERT INTO [Inventory] VALUES ('e31a4b43-558b-4a99-9f16-14aaef49cbcf', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 8, null)
GO
INSERT INTO [Inventory] VALUES ('e779639d-65c4-4e65-9aef-0c0dd09af2db', '72EA9F26-4ACA-4220-AF43-CC035A3653CA', 10, null)
GO


INSERT INTO [Inventory] VALUES ('02a457cd-17bf-4704-897a-1653f6475039', 'D98D7E84-E25F-4DD9-8880-0713F884863B', 5, null)
GO
INSERT INTO [Inventory] VALUES ('12e6a8fd-00a3-46b0-9cd2-6620e67de037', 'D98D7E84-E25F-4DD9-8880-0713F884863B',10, null)
GO
INSERT INTO [Inventory] VALUES ('17211b39-67cf-47e7-bc90-53814f47b8f4', 'D98D7E84-E25F-4DD9-8880-0713F884863B',3, null)
GO
INSERT INTO [Inventory] VALUES ('28556ab6-f5da-4543-845c-ceff4f31b052', 'D98D7E84-E25F-4DD9-8880-0713F884863B',2, null)
GO
INSERT INTO [Inventory] VALUES ('3357f691-e48d-4e08-b7c3-d2518f7375db', 'D98D7E84-E25F-4DD9-8880-0713F884863B',1, null)
GO
INSERT INTO [Inventory] VALUES ('3d51c10a-7db3-417a-90a9-b9e817dda8f1', 'D98D7E84-E25F-4DD9-8880-0713F884863B',4, null)
GO
INSERT INTO [Inventory] VALUES ('59ab030e-31e1-4172-9efd-65699f9bd3eb','D98D7E84-E25F-4DD9-8880-0713F884863B', 11, null)
GO
INSERT INTO [Inventory] VALUES ('74c04620-ff58-4a7b-9916-b8e475001325', 'D98D7E84-E25F-4DD9-8880-0713F884863B',10, null)
GO
INSERT INTO [Inventory] VALUES ('8145b066-d2ab-4af4-b7c1-139bacf6437b', 'D98D7E84-E25F-4DD9-8880-0713F884863B',5, null)
GO
INSERT INTO [Inventory] VALUES ('9511da02-e885-4918-9530-49165ccba60b','D98D7E84-E25F-4DD9-8880-0713F884863B', 6, null)
GO
INSERT INTO [Inventory] VALUES ('a178b17b-4d65-48ba-912f-b058f7a56d91', 'D98D7E84-E25F-4DD9-8880-0713F884863B',2, null)
GO
INSERT INTO [Inventory] VALUES ('a19dc7a0-9569-4aa9-8ea4-9f699a06f87c', 'D98D7E84-E25F-4DD9-8880-0713F884863B',1, null)
GO
INSERT INTO [Inventory] VALUES ('a9ecbff4-8745-478c-bef8-4fc201d28bd4', 'D98D7E84-E25F-4DD9-8880-0713F884863B',4, null)
GO
INSERT INTO [Inventory] VALUES ('bdbf9dfe-3f60-4c87-9cc9-a1cbcb93722e', 'D98D7E84-E25F-4DD9-8880-0713F884863B',5, null)
GO
INSERT INTO [Inventory] VALUES ('d3e67ba4-b16c-4692-92fd-35e12df08700', 'D98D7E84-E25F-4DD9-8880-0713F884863B',7, null)
GO
INSERT INTO [Inventory] VALUES ('d718411b-4294-4903-8699-98cc33272328', 'D98D7E84-E25F-4DD9-8880-0713F884863B',10, null)
GO
INSERT INTO [Inventory] VALUES ('dd7a9839-1e37-4de6-b642-9e34d2b943aa', 'D98D7E84-E25F-4DD9-8880-0713F884863B',5, null)
GO
INSERT INTO [Inventory] VALUES ('e31a4b43-558b-4a99-9f16-14aaef49cbcf', 'D98D7E84-E25F-4DD9-8880-0713F884863B',8, null)
GO
INSERT INTO [Inventory] VALUES ('e779639d-65c4-4e65-9aef-0c0dd09af2db', 'D98D7E84-E25F-4DD9-8880-0713F884863B',10, null)
GO

INSERT INTO [OrderStatusType] VALUES ('Ordered', 'Order has been placed')
GO
INSERT INTO [OrderStatusType] VALUES ('Shipped', 'Order has been shipped')
GO
INSERT INTO [OrderStatusType] VALUES ('Fulfilled', 'Order has been shipped and fulfilled')
GO
INSERT INTO [OrderStatusType] VALUES ('Canceled', 'Order has been canceled')
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSP_Inventory_GetMaxSupplier]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSP_Inventory_GetMaxSupplier]
GO 

CREATE Procedure [dbo].[CSP_Inventory_GetMaxSupplier]
@itemId uniqueidentifier
AS
Begin
	--SOCIALIST RULE: ALWAYS CHOOSE THE SUPPLIER WITH THE HIGHEST QTY 
	Select ItemId, SuppId, Max(Qty) as Qty, null as [Timestamp]
	From Inventory
	where ItemId = @itemId
	GROUP BY ItemId, SuppId
End
GO

EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'Sample Custom Stored Procedure' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'PROCEDURE', @level1name=N'CSP_Inventory_GetMaxSupplier'
GO

PRINT 'Completed Creating PetshopDB'