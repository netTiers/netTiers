
USE [D:\WORK\CODESMITH-SAMPLES\NETTIERS\CSHARP\PETSHOP\SOURCE\PETSHOP.UI\APP_DATA\PETSHOP.MDF]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Get_List

AS


				
				SELECT
					[OrderId],
					[LineNum],
					[Timestamp],
					[Status]
				FROM
					[dbo].[OrderStatus]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the OrderStatus table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderId]'
				SET @SQL = @SQL + ', [LineNum]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ' FROM [dbo].[OrderStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderId],'
				SET @SQL = @SQL + ' [LineNum],'
				SET @SQL = @SQL + ' [Timestamp],'
				SET @SQL = @SQL + ' [Status]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[OrderStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Insert
(

	@OrderId int   ,

	@LineNum int   ,

	@Timestamp datetime   ,

	@Status varchar (2)  
)
AS


				
				INSERT INTO [dbo].[OrderStatus]
					(
					[OrderId]
					,[LineNum]
					,[Timestamp]
					,[Status]
					)
				VALUES
					(
					@OrderId
					,@LineNum
					,@Timestamp
					,@Status
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Update
(

	@OrderId int   ,

	@OriginalOrderId int   ,

	@LineNum int   ,

	@OriginalLineNum int   ,

	@Timestamp datetime   ,

	@Status varchar (2)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[OrderStatus]
				SET
					[OrderId] = @OrderId
					,[LineNum] = @LineNum
					,[Timestamp] = @Timestamp
					,[Status] = @Status
				WHERE
[OrderId] = @OriginalOrderId 
AND [LineNum] = @OriginalLineNum 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Delete
(

	@OrderId int   ,

	@LineNum int   
)
AS


				DELETE FROM [dbo].[OrderStatus] WITH (ROWLOCK) 
				WHERE
					[OrderId] = @OrderId
					AND [LineNum] = @LineNum
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the OrderStatus table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_GetByOrderId
(

	@OrderId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OrderId],
					[LineNum],
					[Timestamp],
					[Status]
				FROM
					[dbo].[OrderStatus]
				WHERE
					[OrderId] = @OrderId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetByOrderIdLineNum procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetByOrderIdLineNum') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetByOrderIdLineNum
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the OrderStatus table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_GetByOrderIdLineNum
(

	@OrderId int   ,

	@LineNum int   
)
AS


				SELECT
					[OrderId],
					[LineNum],
					[Timestamp],
					[Status]
				FROM
					[dbo].[OrderStatus]
				WHERE
					[OrderId] = @OrderId
					AND [LineNum] = @LineNum
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the OrderStatus table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Find
(

	@SearchUsingOR bit   = null ,

	@OrderId int   = null ,

	@LineNum int   = null ,

	@Timestamp datetime   = null ,

	@Status varchar (2)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderId]
	, [LineNum]
	, [Timestamp]
	, [Status]
    FROM
	[dbo].[OrderStatus]
    WHERE 
	 ([OrderId] = @OrderId OR @OrderId IS NULL)
	AND ([LineNum] = @LineNum OR @LineNum IS NULL)
	AND ([Timestamp] = @Timestamp OR @Timestamp IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderId]
	, [LineNum]
	, [Timestamp]
	, [Status]
    FROM
	[dbo].[OrderStatus]
    WHERE 
	 ([OrderId] = @OrderId AND @OrderId is not null)
	OR ([LineNum] = @LineNum AND @LineNum is not null)
	OR ([Timestamp] = @Timestamp AND @Timestamp is not null)
	OR ([Status] = @Status AND @Status is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Cart table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_Get_List

AS


				
				SELECT
					[CartId],
					[UniqueID],
					[ItemId],
					[Name],
					[Type],
					[Price],
					[CategoryId],
					[ProductId],
					[IsShoppingCart],
					[Quantity]
				FROM
					[dbo].[Cart]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Cart table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CartId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CartId]'
				SET @SQL = @SQL + ', [UniqueID]'
				SET @SQL = @SQL + ', [ItemId]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Type]'
				SET @SQL = @SQL + ', [Price]'
				SET @SQL = @SQL + ', [CategoryId]'
				SET @SQL = @SQL + ', [ProductId]'
				SET @SQL = @SQL + ', [IsShoppingCart]'
				SET @SQL = @SQL + ', [Quantity]'
				SET @SQL = @SQL + ' FROM [dbo].[Cart]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CartId],'
				SET @SQL = @SQL + ' [UniqueID],'
				SET @SQL = @SQL + ' [ItemId],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Type],'
				SET @SQL = @SQL + ' [Price],'
				SET @SQL = @SQL + ' [CategoryId],'
				SET @SQL = @SQL + ' [ProductId],'
				SET @SQL = @SQL + ' [IsShoppingCart],'
				SET @SQL = @SQL + ' [Quantity]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Cart]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Cart table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_Insert
(

	@CartId int    OUTPUT,

	@UniqueId int   ,

	@ItemId varchar (10)  ,

	@Name varchar (80)  ,

	@Type varchar (80)  ,

	@Price decimal (10, 2)  ,

	@CategoryId varchar (10)  ,

	@ProductId varchar (10)  ,

	@IsShoppingCart bit   ,

	@Quantity int   
)
AS


				
				INSERT INTO [dbo].[Cart]
					(
					[UniqueID]
					,[ItemId]
					,[Name]
					,[Type]
					,[Price]
					,[CategoryId]
					,[ProductId]
					,[IsShoppingCart]
					,[Quantity]
					)
				VALUES
					(
					@UniqueId
					,@ItemId
					,@Name
					,@Type
					,@Price
					,@CategoryId
					,@ProductId
					,@IsShoppingCart
					,@Quantity
					)
				
				-- Get the identity value
				SET @CartId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Cart table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_Update
(

	@CartId int   ,

	@UniqueId int   ,

	@ItemId varchar (10)  ,

	@Name varchar (80)  ,

	@Type varchar (80)  ,

	@Price decimal (10, 2)  ,

	@CategoryId varchar (10)  ,

	@ProductId varchar (10)  ,

	@IsShoppingCart bit   ,

	@Quantity int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Cart]
				SET
					[UniqueID] = @UniqueId
					,[ItemId] = @ItemId
					,[Name] = @Name
					,[Type] = @Type
					,[Price] = @Price
					,[CategoryId] = @CategoryId
					,[ProductId] = @ProductId
					,[IsShoppingCart] = @IsShoppingCart
					,[Quantity] = @Quantity
				WHERE
[CartId] = @CartId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Cart table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_Delete
(

	@CartId int   
)
AS


				DELETE FROM [dbo].[Cart] WITH (ROWLOCK) 
				WHERE
					[CartId] = @CartId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_GetByUniqueId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_GetByUniqueId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_GetByUniqueId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Cart table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_GetByUniqueId
(

	@UniqueId int   
)
AS


				SELECT
					[CartId],
					[UniqueID],
					[ItemId],
					[Name],
					[Type],
					[Price],
					[CategoryId],
					[ProductId],
					[IsShoppingCart],
					[Quantity]
				FROM
					[dbo].[Cart]
				WHERE
					[UniqueID] = @UniqueId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_GetByIsShoppingCart procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_GetByIsShoppingCart') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_GetByIsShoppingCart
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Cart table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_GetByIsShoppingCart
(

	@IsShoppingCart bit   
)
AS


				SELECT
					[CartId],
					[UniqueID],
					[ItemId],
					[Name],
					[Type],
					[Price],
					[CategoryId],
					[ProductId],
					[IsShoppingCart],
					[Quantity]
				FROM
					[dbo].[Cart]
				WHERE
					[IsShoppingCart] = @IsShoppingCart
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_GetByCartId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_GetByCartId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_GetByCartId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Cart table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_GetByCartId
(

	@CartId int   
)
AS


				SELECT
					[CartId],
					[UniqueID],
					[ItemId],
					[Name],
					[Type],
					[Price],
					[CategoryId],
					[ProductId],
					[IsShoppingCart],
					[Quantity]
				FROM
					[dbo].[Cart]
				WHERE
					[CartId] = @CartId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cart_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cart_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cart_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Cart table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cart_Find
(

	@SearchUsingOR bit   = null ,

	@CartId int   = null ,

	@UniqueId int   = null ,

	@ItemId varchar (10)  = null ,

	@Name varchar (80)  = null ,

	@Type varchar (80)  = null ,

	@Price decimal (10, 2)  = null ,

	@CategoryId varchar (10)  = null ,

	@ProductId varchar (10)  = null ,

	@IsShoppingCart bit   = null ,

	@Quantity int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CartId]
	, [UniqueID]
	, [ItemId]
	, [Name]
	, [Type]
	, [Price]
	, [CategoryId]
	, [ProductId]
	, [IsShoppingCart]
	, [Quantity]
    FROM
	[dbo].[Cart]
    WHERE 
	 ([CartId] = @CartId OR @CartId IS NULL)
	AND ([UniqueID] = @UniqueId OR @UniqueId IS NULL)
	AND ([ItemId] = @ItemId OR @ItemId IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Type] = @Type OR @Type IS NULL)
	AND ([Price] = @Price OR @Price IS NULL)
	AND ([CategoryId] = @CategoryId OR @CategoryId IS NULL)
	AND ([ProductId] = @ProductId OR @ProductId IS NULL)
	AND ([IsShoppingCart] = @IsShoppingCart OR @IsShoppingCart IS NULL)
	AND ([Quantity] = @Quantity OR @Quantity IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CartId]
	, [UniqueID]
	, [ItemId]
	, [Name]
	, [Type]
	, [Price]
	, [CategoryId]
	, [ProductId]
	, [IsShoppingCart]
	, [Quantity]
    FROM
	[dbo].[Cart]
    WHERE 
	 ([CartId] = @CartId AND @CartId is not null)
	OR ([UniqueID] = @UniqueId AND @UniqueId is not null)
	OR ([ItemId] = @ItemId AND @ItemId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Type] = @Type AND @Type is not null)
	OR ([Price] = @Price AND @Price is not null)
	OR ([CategoryId] = @CategoryId AND @CategoryId is not null)
	OR ([ProductId] = @ProductId AND @ProductId is not null)
	OR ([IsShoppingCart] = @IsShoppingCart AND @IsShoppingCart is not null)
	OR ([Quantity] = @Quantity AND @Quantity is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Get_List

AS


				
				SELECT
					[OrderId],
					[UserId],
					[OrderDate],
					[ShipAddr1],
					[ShipAddr2],
					[ShipCity],
					[ShipState],
					[ShipZip],
					[ShipCountry],
					[BillAddr1],
					[BillAddr2],
					[BillCity],
					[BillState],
					[BillZip],
					[BillCountry],
					[Courier],
					[TotalPrice],
					[BillToFirstName],
					[BillToLastName],
					[ShipToFirstName],
					[ShipToLastName],
					[AuthorizationNumber],
					[Locale]
				FROM
					[dbo].[Orders]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Orders table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderId]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ', [OrderDate]'
				SET @SQL = @SQL + ', [ShipAddr1]'
				SET @SQL = @SQL + ', [ShipAddr2]'
				SET @SQL = @SQL + ', [ShipCity]'
				SET @SQL = @SQL + ', [ShipState]'
				SET @SQL = @SQL + ', [ShipZip]'
				SET @SQL = @SQL + ', [ShipCountry]'
				SET @SQL = @SQL + ', [BillAddr1]'
				SET @SQL = @SQL + ', [BillAddr2]'
				SET @SQL = @SQL + ', [BillCity]'
				SET @SQL = @SQL + ', [BillState]'
				SET @SQL = @SQL + ', [BillZip]'
				SET @SQL = @SQL + ', [BillCountry]'
				SET @SQL = @SQL + ', [Courier]'
				SET @SQL = @SQL + ', [TotalPrice]'
				SET @SQL = @SQL + ', [BillToFirstName]'
				SET @SQL = @SQL + ', [BillToLastName]'
				SET @SQL = @SQL + ', [ShipToFirstName]'
				SET @SQL = @SQL + ', [ShipToLastName]'
				SET @SQL = @SQL + ', [AuthorizationNumber]'
				SET @SQL = @SQL + ', [Locale]'
				SET @SQL = @SQL + ' FROM [dbo].[Orders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderId],'
				SET @SQL = @SQL + ' [UserId],'
				SET @SQL = @SQL + ' [OrderDate],'
				SET @SQL = @SQL + ' [ShipAddr1],'
				SET @SQL = @SQL + ' [ShipAddr2],'
				SET @SQL = @SQL + ' [ShipCity],'
				SET @SQL = @SQL + ' [ShipState],'
				SET @SQL = @SQL + ' [ShipZip],'
				SET @SQL = @SQL + ' [ShipCountry],'
				SET @SQL = @SQL + ' [BillAddr1],'
				SET @SQL = @SQL + ' [BillAddr2],'
				SET @SQL = @SQL + ' [BillCity],'
				SET @SQL = @SQL + ' [BillState],'
				SET @SQL = @SQL + ' [BillZip],'
				SET @SQL = @SQL + ' [BillCountry],'
				SET @SQL = @SQL + ' [Courier],'
				SET @SQL = @SQL + ' [TotalPrice],'
				SET @SQL = @SQL + ' [BillToFirstName],'
				SET @SQL = @SQL + ' [BillToLastName],'
				SET @SQL = @SQL + ' [ShipToFirstName],'
				SET @SQL = @SQL + ' [ShipToLastName],'
				SET @SQL = @SQL + ' [AuthorizationNumber],'
				SET @SQL = @SQL + ' [Locale]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Orders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Insert
(

	@OrderId int    OUTPUT,

	@UserId varchar (20)  ,

	@OrderDate datetime   ,

	@ShipAddr1 varchar (80)  ,

	@ShipAddr2 varchar (80)  ,

	@ShipCity varchar (80)  ,

	@ShipState varchar (80)  ,

	@ShipZip varchar (20)  ,

	@ShipCountry varchar (20)  ,

	@BillAddr1 varchar (80)  ,

	@BillAddr2 varchar (80)  ,

	@BillCity varchar (80)  ,

	@BillState varchar (80)  ,

	@BillZip varchar (20)  ,

	@BillCountry varchar (20)  ,

	@Courier varchar (80)  ,

	@TotalPrice decimal (10, 2)  ,

	@BillToFirstName varchar (80)  ,

	@BillToLastName varchar (80)  ,

	@ShipToFirstName varchar (80)  ,

	@ShipToLastName varchar (80)  ,

	@AuthorizationNumber int   ,

	@Locale varchar (20)  
)
AS


				
				INSERT INTO [dbo].[Orders]
					(
					[UserId]
					,[OrderDate]
					,[ShipAddr1]
					,[ShipAddr2]
					,[ShipCity]
					,[ShipState]
					,[ShipZip]
					,[ShipCountry]
					,[BillAddr1]
					,[BillAddr2]
					,[BillCity]
					,[BillState]
					,[BillZip]
					,[BillCountry]
					,[Courier]
					,[TotalPrice]
					,[BillToFirstName]
					,[BillToLastName]
					,[ShipToFirstName]
					,[ShipToLastName]
					,[AuthorizationNumber]
					,[Locale]
					)
				VALUES
					(
					@UserId
					,@OrderDate
					,@ShipAddr1
					,@ShipAddr2
					,@ShipCity
					,@ShipState
					,@ShipZip
					,@ShipCountry
					,@BillAddr1
					,@BillAddr2
					,@BillCity
					,@BillState
					,@BillZip
					,@BillCountry
					,@Courier
					,@TotalPrice
					,@BillToFirstName
					,@BillToLastName
					,@ShipToFirstName
					,@ShipToLastName
					,@AuthorizationNumber
					,@Locale
					)
				
				-- Get the identity value
				SET @OrderId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Update
(

	@OrderId int   ,

	@UserId varchar (20)  ,

	@OrderDate datetime   ,

	@ShipAddr1 varchar (80)  ,

	@ShipAddr2 varchar (80)  ,

	@ShipCity varchar (80)  ,

	@ShipState varchar (80)  ,

	@ShipZip varchar (20)  ,

	@ShipCountry varchar (20)  ,

	@BillAddr1 varchar (80)  ,

	@BillAddr2 varchar (80)  ,

	@BillCity varchar (80)  ,

	@BillState varchar (80)  ,

	@BillZip varchar (20)  ,

	@BillCountry varchar (20)  ,

	@Courier varchar (80)  ,

	@TotalPrice decimal (10, 2)  ,

	@BillToFirstName varchar (80)  ,

	@BillToLastName varchar (80)  ,

	@ShipToFirstName varchar (80)  ,

	@ShipToLastName varchar (80)  ,

	@AuthorizationNumber int   ,

	@Locale varchar (20)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Orders]
				SET
					[UserId] = @UserId
					,[OrderDate] = @OrderDate
					,[ShipAddr1] = @ShipAddr1
					,[ShipAddr2] = @ShipAddr2
					,[ShipCity] = @ShipCity
					,[ShipState] = @ShipState
					,[ShipZip] = @ShipZip
					,[ShipCountry] = @ShipCountry
					,[BillAddr1] = @BillAddr1
					,[BillAddr2] = @BillAddr2
					,[BillCity] = @BillCity
					,[BillState] = @BillState
					,[BillZip] = @BillZip
					,[BillCountry] = @BillCountry
					,[Courier] = @Courier
					,[TotalPrice] = @TotalPrice
					,[BillToFirstName] = @BillToFirstName
					,[BillToLastName] = @BillToLastName
					,[ShipToFirstName] = @ShipToFirstName
					,[ShipToLastName] = @ShipToLastName
					,[AuthorizationNumber] = @AuthorizationNumber
					,[Locale] = @Locale
				WHERE
[OrderId] = @OrderId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Delete
(

	@OrderId int   
)
AS


				DELETE FROM [dbo].[Orders] WITH (ROWLOCK) 
				WHERE
					[OrderId] = @OrderId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByOrderId
(

	@OrderId int   
)
AS


				SELECT
					[OrderId],
					[UserId],
					[OrderDate],
					[ShipAddr1],
					[ShipAddr2],
					[ShipCity],
					[ShipState],
					[ShipZip],
					[ShipCountry],
					[BillAddr1],
					[BillAddr2],
					[BillCity],
					[BillState],
					[BillZip],
					[BillCountry],
					[Courier],
					[TotalPrice],
					[BillToFirstName],
					[BillToLastName],
					[ShipToFirstName],
					[ShipToLastName],
					[AuthorizationNumber],
					[Locale]
				FROM
					[dbo].[Orders]
				WHERE
					[OrderId] = @OrderId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Orders table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Find
(

	@SearchUsingOR bit   = null ,

	@OrderId int   = null ,

	@UserId varchar (20)  = null ,

	@OrderDate datetime   = null ,

	@ShipAddr1 varchar (80)  = null ,

	@ShipAddr2 varchar (80)  = null ,

	@ShipCity varchar (80)  = null ,

	@ShipState varchar (80)  = null ,

	@ShipZip varchar (20)  = null ,

	@ShipCountry varchar (20)  = null ,

	@BillAddr1 varchar (80)  = null ,

	@BillAddr2 varchar (80)  = null ,

	@BillCity varchar (80)  = null ,

	@BillState varchar (80)  = null ,

	@BillZip varchar (20)  = null ,

	@BillCountry varchar (20)  = null ,

	@Courier varchar (80)  = null ,

	@TotalPrice decimal (10, 2)  = null ,

	@BillToFirstName varchar (80)  = null ,

	@BillToLastName varchar (80)  = null ,

	@ShipToFirstName varchar (80)  = null ,

	@ShipToLastName varchar (80)  = null ,

	@AuthorizationNumber int   = null ,

	@Locale varchar (20)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderId]
	, [UserId]
	, [OrderDate]
	, [ShipAddr1]
	, [ShipAddr2]
	, [ShipCity]
	, [ShipState]
	, [ShipZip]
	, [ShipCountry]
	, [BillAddr1]
	, [BillAddr2]
	, [BillCity]
	, [BillState]
	, [BillZip]
	, [BillCountry]
	, [Courier]
	, [TotalPrice]
	, [BillToFirstName]
	, [BillToLastName]
	, [ShipToFirstName]
	, [ShipToLastName]
	, [AuthorizationNumber]
	, [Locale]
    FROM
	[dbo].[Orders]
    WHERE 
	 ([OrderId] = @OrderId OR @OrderId IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
	AND ([OrderDate] = @OrderDate OR @OrderDate IS NULL)
	AND ([ShipAddr1] = @ShipAddr1 OR @ShipAddr1 IS NULL)
	AND ([ShipAddr2] = @ShipAddr2 OR @ShipAddr2 IS NULL)
	AND ([ShipCity] = @ShipCity OR @ShipCity IS NULL)
	AND ([ShipState] = @ShipState OR @ShipState IS NULL)
	AND ([ShipZip] = @ShipZip OR @ShipZip IS NULL)
	AND ([ShipCountry] = @ShipCountry OR @ShipCountry IS NULL)
	AND ([BillAddr1] = @BillAddr1 OR @BillAddr1 IS NULL)
	AND ([BillAddr2] = @BillAddr2 OR @BillAddr2 IS NULL)
	AND ([BillCity] = @BillCity OR @BillCity IS NULL)
	AND ([BillState] = @BillState OR @BillState IS NULL)
	AND ([BillZip] = @BillZip OR @BillZip IS NULL)
	AND ([BillCountry] = @BillCountry OR @BillCountry IS NULL)
	AND ([Courier] = @Courier OR @Courier IS NULL)
	AND ([TotalPrice] = @TotalPrice OR @TotalPrice IS NULL)
	AND ([BillToFirstName] = @BillToFirstName OR @BillToFirstName IS NULL)
	AND ([BillToLastName] = @BillToLastName OR @BillToLastName IS NULL)
	AND ([ShipToFirstName] = @ShipToFirstName OR @ShipToFirstName IS NULL)
	AND ([ShipToLastName] = @ShipToLastName OR @ShipToLastName IS NULL)
	AND ([AuthorizationNumber] = @AuthorizationNumber OR @AuthorizationNumber IS NULL)
	AND ([Locale] = @Locale OR @Locale IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderId]
	, [UserId]
	, [OrderDate]
	, [ShipAddr1]
	, [ShipAddr2]
	, [ShipCity]
	, [ShipState]
	, [ShipZip]
	, [ShipCountry]
	, [BillAddr1]
	, [BillAddr2]
	, [BillCity]
	, [BillState]
	, [BillZip]
	, [BillCountry]
	, [Courier]
	, [TotalPrice]
	, [BillToFirstName]
	, [BillToLastName]
	, [ShipToFirstName]
	, [ShipToLastName]
	, [AuthorizationNumber]
	, [Locale]
    FROM
	[dbo].[Orders]
    WHERE 
	 ([OrderId] = @OrderId AND @OrderId is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	OR ([OrderDate] = @OrderDate AND @OrderDate is not null)
	OR ([ShipAddr1] = @ShipAddr1 AND @ShipAddr1 is not null)
	OR ([ShipAddr2] = @ShipAddr2 AND @ShipAddr2 is not null)
	OR ([ShipCity] = @ShipCity AND @ShipCity is not null)
	OR ([ShipState] = @ShipState AND @ShipState is not null)
	OR ([ShipZip] = @ShipZip AND @ShipZip is not null)
	OR ([ShipCountry] = @ShipCountry AND @ShipCountry is not null)
	OR ([BillAddr1] = @BillAddr1 AND @BillAddr1 is not null)
	OR ([BillAddr2] = @BillAddr2 AND @BillAddr2 is not null)
	OR ([BillCity] = @BillCity AND @BillCity is not null)
	OR ([BillState] = @BillState AND @BillState is not null)
	OR ([BillZip] = @BillZip AND @BillZip is not null)
	OR ([BillCountry] = @BillCountry AND @BillCountry is not null)
	OR ([Courier] = @Courier AND @Courier is not null)
	OR ([TotalPrice] = @TotalPrice AND @TotalPrice is not null)
	OR ([BillToFirstName] = @BillToFirstName AND @BillToFirstName is not null)
	OR ([BillToLastName] = @BillToLastName AND @BillToLastName is not null)
	OR ([ShipToFirstName] = @ShipToFirstName AND @ShipToFirstName is not null)
	OR ([ShipToLastName] = @ShipToLastName AND @ShipToLastName is not null)
	OR ([AuthorizationNumber] = @AuthorizationNumber AND @AuthorizationNumber is not null)
	OR ([Locale] = @Locale AND @Locale is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Inventory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Get_List

AS


				
				SELECT
					[ItemId],
					[Qty]
				FROM
					[dbo].[Inventory]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Inventory table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ItemId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ItemId]'
				SET @SQL = @SQL + ', [Qty]'
				SET @SQL = @SQL + ' FROM [dbo].[Inventory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ItemId],'
				SET @SQL = @SQL + ' [Qty]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Inventory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Inventory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Insert
(

	@ItemId varchar (10)  ,

	@Qty int   
)
AS


				
				INSERT INTO [dbo].[Inventory]
					(
					[ItemId]
					,[Qty]
					)
				VALUES
					(
					@ItemId
					,@Qty
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Inventory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Update
(

	@ItemId varchar (10)  ,

	@OriginalItemId varchar (10)  ,

	@Qty int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Inventory]
				SET
					[ItemId] = @ItemId
					,[Qty] = @Qty
				WHERE
[ItemId] = @OriginalItemId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Inventory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Delete
(

	@ItemId varchar (10)  
)
AS


				DELETE FROM [dbo].[Inventory] WITH (ROWLOCK) 
				WHERE
					[ItemId] = @ItemId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Inventory table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_GetByItemId
(

	@ItemId varchar (10)  
)
AS


				SELECT
					[ItemId],
					[Qty]
				FROM
					[dbo].[Inventory]
				WHERE
					[ItemId] = @ItemId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Inventory table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Find
(

	@SearchUsingOR bit   = null ,

	@ItemId varchar (10)  = null ,

	@Qty int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ItemId]
	, [Qty]
    FROM
	[dbo].[Inventory]
    WHERE 
	 ([ItemId] = @ItemId OR @ItemId IS NULL)
	AND ([Qty] = @Qty OR @Qty IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ItemId]
	, [Qty]
    FROM
	[dbo].[Inventory]
    WHERE 
	 ([ItemId] = @ItemId AND @ItemId is not null)
	OR ([Qty] = @Qty AND @Qty is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Supplier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Get_List

AS


				
				SELECT
					[SuppId],
					[Name],
					[Status],
					[Addr1],
					[Addr2],
					[City],
					[State],
					[Zip],
					[Phone]
				FROM
					[dbo].[Supplier]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Supplier table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SuppId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SuppId]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ', [Addr1]'
				SET @SQL = @SQL + ', [Addr2]'
				SET @SQL = @SQL + ', [City]'
				SET @SQL = @SQL + ', [State]'
				SET @SQL = @SQL + ', [Zip]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ' FROM [dbo].[Supplier]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SuppId],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Status],'
				SET @SQL = @SQL + ' [Addr1],'
				SET @SQL = @SQL + ' [Addr2],'
				SET @SQL = @SQL + ' [City],'
				SET @SQL = @SQL + ' [State],'
				SET @SQL = @SQL + ' [Zip],'
				SET @SQL = @SQL + ' [Phone]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Supplier]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Supplier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Insert
(

	@SuppId int   ,

	@Name varchar (80)  ,

	@Status varchar (2)  ,

	@Addr1 varchar (80)  ,

	@Addr2 varchar (80)  ,

	@City varchar (80)  ,

	@State varchar (80)  ,

	@Zip varchar (5)  ,

	@Phone varchar (40)  
)
AS


				
				INSERT INTO [dbo].[Supplier]
					(
					[SuppId]
					,[Name]
					,[Status]
					,[Addr1]
					,[Addr2]
					,[City]
					,[State]
					,[Zip]
					,[Phone]
					)
				VALUES
					(
					@SuppId
					,@Name
					,@Status
					,@Addr1
					,@Addr2
					,@City
					,@State
					,@Zip
					,@Phone
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Supplier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Update
(

	@SuppId int   ,

	@OriginalSuppId int   ,

	@Name varchar (80)  ,

	@Status varchar (2)  ,

	@Addr1 varchar (80)  ,

	@Addr2 varchar (80)  ,

	@City varchar (80)  ,

	@State varchar (80)  ,

	@Zip varchar (5)  ,

	@Phone varchar (40)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Supplier]
				SET
					[SuppId] = @SuppId
					,[Name] = @Name
					,[Status] = @Status
					,[Addr1] = @Addr1
					,[Addr2] = @Addr2
					,[City] = @City
					,[State] = @State
					,[Zip] = @Zip
					,[Phone] = @Phone
				WHERE
[SuppId] = @OriginalSuppId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Supplier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Delete
(

	@SuppId int   
)
AS


				DELETE FROM [dbo].[Supplier] WITH (ROWLOCK) 
				WHERE
					[SuppId] = @SuppId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_GetBySuppId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_GetBySuppId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_GetBySuppId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Supplier table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_GetBySuppId
(

	@SuppId int   
)
AS


				SELECT
					[SuppId],
					[Name],
					[Status],
					[Addr1],
					[Addr2],
					[City],
					[State],
					[Zip],
					[Phone]
				FROM
					[dbo].[Supplier]
				WHERE
					[SuppId] = @SuppId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Supplier table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Find
(

	@SearchUsingOR bit   = null ,

	@SuppId int   = null ,

	@Name varchar (80)  = null ,

	@Status varchar (2)  = null ,

	@Addr1 varchar (80)  = null ,

	@Addr2 varchar (80)  = null ,

	@City varchar (80)  = null ,

	@State varchar (80)  = null ,

	@Zip varchar (5)  = null ,

	@Phone varchar (40)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SuppId]
	, [Name]
	, [Status]
	, [Addr1]
	, [Addr2]
	, [City]
	, [State]
	, [Zip]
	, [Phone]
    FROM
	[dbo].[Supplier]
    WHERE 
	 ([SuppId] = @SuppId OR @SuppId IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
	AND ([Addr1] = @Addr1 OR @Addr1 IS NULL)
	AND ([Addr2] = @Addr2 OR @Addr2 IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([State] = @State OR @State IS NULL)
	AND ([Zip] = @Zip OR @Zip IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SuppId]
	, [Name]
	, [Status]
	, [Addr1]
	, [Addr2]
	, [City]
	, [State]
	, [Zip]
	, [Phone]
    FROM
	[dbo].[Supplier]
    WHERE 
	 ([SuppId] = @SuppId AND @SuppId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Status] = @Status AND @Status is not null)
	OR ([Addr1] = @Addr1 AND @Addr1 is not null)
	OR ([Addr2] = @Addr2 AND @Addr2 is not null)
	OR ([City] = @City AND @City is not null)
	OR ([State] = @State AND @State is not null)
	OR ([Zip] = @Zip AND @Zip is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Category_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Get_List

AS


				
				SELECT
					[CategoryId],
					[Name],
					[Descn]
				FROM
					[dbo].[Category]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Category_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Category table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CategoryId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CategoryId]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Descn]'
				SET @SQL = @SQL + ' FROM [dbo].[Category]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CategoryId],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Descn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Category]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Category_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Insert
(

	@CategoryId varchar (10)  ,

	@Name varchar (80)  ,

	@Descn varchar (255)  
)
AS


				
				INSERT INTO [dbo].[Category]
					(
					[CategoryId]
					,[Name]
					,[Descn]
					)
				VALUES
					(
					@CategoryId
					,@Name
					,@Descn
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Category_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Update
(

	@CategoryId varchar (10)  ,

	@OriginalCategoryId varchar (10)  ,

	@Name varchar (80)  ,

	@Descn varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Category]
				SET
					[CategoryId] = @CategoryId
					,[Name] = @Name
					,[Descn] = @Descn
				WHERE
[CategoryId] = @OriginalCategoryId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Category_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Delete
(

	@CategoryId varchar (10)  
)
AS


				DELETE FROM [dbo].[Category] WITH (ROWLOCK) 
				WHERE
					[CategoryId] = @CategoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Category_GetByCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_GetByCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_GetByCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Category table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_GetByCategoryId
(

	@CategoryId varchar (10)  
)
AS


				SELECT
					[CategoryId],
					[Name],
					[Descn]
				FROM
					[dbo].[Category]
				WHERE
					[CategoryId] = @CategoryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Category_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Category table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Find
(

	@SearchUsingOR bit   = null ,

	@CategoryId varchar (10)  = null ,

	@Name varchar (80)  = null ,

	@Descn varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CategoryId]
	, [Name]
	, [Descn]
    FROM
	[dbo].[Category]
    WHERE 
	 ([CategoryId] = @CategoryId OR @CategoryId IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Descn] = @Descn OR @Descn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CategoryId]
	, [Name]
	, [Descn]
    FROM
	[dbo].[Category]
    WHERE 
	 ([CategoryId] = @CategoryId AND @CategoryId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Descn] = @Descn AND @Descn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Get_List

AS


				
				SELECT
					[ProductId],
					[CategoryId],
					[Name],
					[Descn],
					[Image]
				FROM
					[dbo].[Product]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Product table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductId]'
				SET @SQL = @SQL + ', [CategoryId]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Descn]'
				SET @SQL = @SQL + ', [Image]'
				SET @SQL = @SQL + ' FROM [dbo].[Product]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductId],'
				SET @SQL = @SQL + ' [CategoryId],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Descn],'
				SET @SQL = @SQL + ' [Image]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Product]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Insert
(

	@ProductId varchar (10)  ,

	@CategoryId varchar (10)  ,

	@Name varchar (80)  ,

	@Descn varchar (255)  ,

	@Image varchar (80)  
)
AS


				
				INSERT INTO [dbo].[Product]
					(
					[ProductId]
					,[CategoryId]
					,[Name]
					,[Descn]
					,[Image]
					)
				VALUES
					(
					@ProductId
					,@CategoryId
					,@Name
					,@Descn
					,@Image
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Update
(

	@ProductId varchar (10)  ,

	@OriginalProductId varchar (10)  ,

	@CategoryId varchar (10)  ,

	@Name varchar (80)  ,

	@Descn varchar (255)  ,

	@Image varchar (80)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Product]
				SET
					[ProductId] = @ProductId
					,[CategoryId] = @CategoryId
					,[Name] = @Name
					,[Descn] = @Descn
					,[Image] = @Image
				WHERE
[ProductId] = @OriginalProductId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Delete
(

	@ProductId varchar (10)  
)
AS


				DELETE FROM [dbo].[Product] WITH (ROWLOCK) 
				WHERE
					[ProductId] = @ProductId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_GetByName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetByName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetByName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Product table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetByName
(

	@Name varchar (80)  
)
AS


				SELECT
					[ProductId],
					[CategoryId],
					[Name],
					[Descn],
					[Image]
				FROM
					[dbo].[Product]
				WHERE
					[Name] = @Name
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_GetByCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetByCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetByCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Product table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetByCategoryId
(

	@CategoryId varchar (10)  
)
AS


				SELECT
					[ProductId],
					[CategoryId],
					[Name],
					[Descn],
					[Image]
				FROM
					[dbo].[Product]
				WHERE
					[CategoryId] = @CategoryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_GetByCategoryIdName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetByCategoryIdName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetByCategoryIdName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Product table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetByCategoryIdName
(

	@CategoryId varchar (10)  ,

	@Name varchar (80)  
)
AS


				SELECT
					[ProductId],
					[CategoryId],
					[Name],
					[Descn],
					[Image]
				FROM
					[dbo].[Product]
				WHERE
					[CategoryId] = @CategoryId
					AND [Name] = @Name
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_GetByCategoryIdProductIdName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetByCategoryIdProductIdName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetByCategoryIdProductIdName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Product table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetByCategoryIdProductIdName
(

	@CategoryId varchar (10)  ,

	@ProductId varchar (10)  ,

	@Name varchar (80)  
)
AS


				SELECT
					[ProductId],
					[CategoryId],
					[Name],
					[Descn],
					[Image]
				FROM
					[dbo].[Product]
				WHERE
					[CategoryId] = @CategoryId
					AND [ProductId] = @ProductId
					AND [Name] = @Name
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_GetByProductId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetByProductId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetByProductId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Product table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetByProductId
(

	@ProductId varchar (10)  
)
AS


				SELECT
					[ProductId],
					[CategoryId],
					[Name],
					[Descn],
					[Image]
				FROM
					[dbo].[Product]
				WHERE
					[ProductId] = @ProductId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Product_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Product table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Find
(

	@SearchUsingOR bit   = null ,

	@ProductId varchar (10)  = null ,

	@CategoryId varchar (10)  = null ,

	@Name varchar (80)  = null ,

	@Descn varchar (255)  = null ,

	@Image varchar (80)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductId]
	, [CategoryId]
	, [Name]
	, [Descn]
	, [Image]
    FROM
	[dbo].[Product]
    WHERE 
	 ([ProductId] = @ProductId OR @ProductId IS NULL)
	AND ([CategoryId] = @CategoryId OR @CategoryId IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Descn] = @Descn OR @Descn IS NULL)
	AND ([Image] = @Image OR @Image IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductId]
	, [CategoryId]
	, [Name]
	, [Descn]
	, [Image]
    FROM
	[dbo].[Product]
    WHERE 
	 ([ProductId] = @ProductId AND @ProductId is not null)
	OR ([CategoryId] = @CategoryId AND @CategoryId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Descn] = @Descn AND @Descn is not null)
	OR ([Image] = @Image AND @Image is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the LineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Get_List

AS


				
				SELECT
					[OrderId],
					[LineNum],
					[ItemId],
					[Quantity],
					[UnitPrice]
				FROM
					[dbo].[LineItem]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the LineItem table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderId]'
				SET @SQL = @SQL + ', [LineNum]'
				SET @SQL = @SQL + ', [ItemId]'
				SET @SQL = @SQL + ', [Quantity]'
				SET @SQL = @SQL + ', [UnitPrice]'
				SET @SQL = @SQL + ' FROM [dbo].[LineItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderId],'
				SET @SQL = @SQL + ' [LineNum],'
				SET @SQL = @SQL + ' [ItemId],'
				SET @SQL = @SQL + ' [Quantity],'
				SET @SQL = @SQL + ' [UnitPrice]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LineItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the LineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Insert
(

	@OrderId int   ,

	@LineNum int   ,

	@ItemId varchar (10)  ,

	@Quantity int   ,

	@UnitPrice decimal (10, 2)  
)
AS


				
				INSERT INTO [dbo].[LineItem]
					(
					[OrderId]
					,[LineNum]
					,[ItemId]
					,[Quantity]
					,[UnitPrice]
					)
				VALUES
					(
					@OrderId
					,@LineNum
					,@ItemId
					,@Quantity
					,@UnitPrice
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the LineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Update
(

	@OrderId int   ,

	@OriginalOrderId int   ,

	@LineNum int   ,

	@OriginalLineNum int   ,

	@ItemId varchar (10)  ,

	@Quantity int   ,

	@UnitPrice decimal (10, 2)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LineItem]
				SET
					[OrderId] = @OrderId
					,[LineNum] = @LineNum
					,[ItemId] = @ItemId
					,[Quantity] = @Quantity
					,[UnitPrice] = @UnitPrice
				WHERE
[OrderId] = @OriginalOrderId 
AND [LineNum] = @OriginalLineNum 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the LineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Delete
(

	@OrderId int   ,

	@LineNum int   
)
AS


				DELETE FROM [dbo].[LineItem] WITH (ROWLOCK) 
				WHERE
					[OrderId] = @OrderId
					AND [LineNum] = @LineNum
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the LineItem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_GetByOrderId
(

	@OrderId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OrderId],
					[LineNum],
					[ItemId],
					[Quantity],
					[UnitPrice]
				FROM
					[dbo].[LineItem]
				WHERE
					[OrderId] = @OrderId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_GetByOrderIdLineNum procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_GetByOrderIdLineNum') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_GetByOrderIdLineNum
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the LineItem table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_GetByOrderIdLineNum
(

	@OrderId int   ,

	@LineNum int   
)
AS


				SELECT
					[OrderId],
					[LineNum],
					[ItemId],
					[Quantity],
					[UnitPrice]
				FROM
					[dbo].[LineItem]
				WHERE
					[OrderId] = @OrderId
					AND [LineNum] = @LineNum
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the LineItem table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Find
(

	@SearchUsingOR bit   = null ,

	@OrderId int   = null ,

	@LineNum int   = null ,

	@ItemId varchar (10)  = null ,

	@Quantity int   = null ,

	@UnitPrice decimal (10, 2)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderId]
	, [LineNum]
	, [ItemId]
	, [Quantity]
	, [UnitPrice]
    FROM
	[dbo].[LineItem]
    WHERE 
	 ([OrderId] = @OrderId OR @OrderId IS NULL)
	AND ([LineNum] = @LineNum OR @LineNum IS NULL)
	AND ([ItemId] = @ItemId OR @ItemId IS NULL)
	AND ([Quantity] = @Quantity OR @Quantity IS NULL)
	AND ([UnitPrice] = @UnitPrice OR @UnitPrice IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderId]
	, [LineNum]
	, [ItemId]
	, [Quantity]
	, [UnitPrice]
    FROM
	[dbo].[LineItem]
    WHERE 
	 ([OrderId] = @OrderId AND @OrderId is not null)
	OR ([LineNum] = @LineNum AND @LineNum is not null)
	OR ([ItemId] = @ItemId AND @ItemId is not null)
	OR ([Quantity] = @Quantity AND @Quantity is not null)
	OR ([UnitPrice] = @UnitPrice AND @UnitPrice is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Get_List

AS


				
				SELECT
					[AccountId],
					[UniqueID],
					[Email],
					[FirstName],
					[LastName],
					[Address1],
					[Address2],
					[City],
					[State],
					[Zip],
					[Country],
					[Phone]
				FROM
					[dbo].[Account]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Account table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AccountId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AccountId]'
				SET @SQL = @SQL + ', [UniqueID]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [LastName]'
				SET @SQL = @SQL + ', [Address1]'
				SET @SQL = @SQL + ', [Address2]'
				SET @SQL = @SQL + ', [City]'
				SET @SQL = @SQL + ', [State]'
				SET @SQL = @SQL + ', [Zip]'
				SET @SQL = @SQL + ', [Country]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ' FROM [dbo].[Account]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AccountId],'
				SET @SQL = @SQL + ' [UniqueID],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [LastName],'
				SET @SQL = @SQL + ' [Address1],'
				SET @SQL = @SQL + ' [Address2],'
				SET @SQL = @SQL + ' [City],'
				SET @SQL = @SQL + ' [State],'
				SET @SQL = @SQL + ' [Zip],'
				SET @SQL = @SQL + ' [Country],'
				SET @SQL = @SQL + ' [Phone]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Account]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Insert
(

	@AccountId int    OUTPUT,

	@UniqueId int   ,

	@Email varchar (80)  ,

	@FirstName varchar (80)  ,

	@LastName varchar (80)  ,

	@Address1 varchar (80)  ,

	@Address2 varchar (80)  ,

	@City varchar (80)  ,

	@State varchar (80)  ,

	@Zip varchar (20)  ,

	@Country varchar (20)  ,

	@Phone varchar (20)  
)
AS


				
				INSERT INTO [dbo].[Account]
					(
					[UniqueID]
					,[Email]
					,[FirstName]
					,[LastName]
					,[Address1]
					,[Address2]
					,[City]
					,[State]
					,[Zip]
					,[Country]
					,[Phone]
					)
				VALUES
					(
					@UniqueId
					,@Email
					,@FirstName
					,@LastName
					,@Address1
					,@Address2
					,@City
					,@State
					,@Zip
					,@Country
					,@Phone
					)
				
				-- Get the identity value
				SET @AccountId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Update
(

	@AccountId int   ,

	@UniqueId int   ,

	@Email varchar (80)  ,

	@FirstName varchar (80)  ,

	@LastName varchar (80)  ,

	@Address1 varchar (80)  ,

	@Address2 varchar (80)  ,

	@City varchar (80)  ,

	@State varchar (80)  ,

	@Zip varchar (20)  ,

	@Country varchar (20)  ,

	@Phone varchar (20)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Account]
				SET
					[UniqueID] = @UniqueId
					,[Email] = @Email
					,[FirstName] = @FirstName
					,[LastName] = @LastName
					,[Address1] = @Address1
					,[Address2] = @Address2
					,[City] = @City
					,[State] = @State
					,[Zip] = @Zip
					,[Country] = @Country
					,[Phone] = @Phone
				WHERE
[AccountId] = @AccountId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Delete
(

	@AccountId int   
)
AS


				DELETE FROM [dbo].[Account] WITH (ROWLOCK) 
				WHERE
					[AccountId] = @AccountId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_GetByUniqueId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetByUniqueId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetByUniqueId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Account table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetByUniqueId
(

	@UniqueId int   
)
AS


				SELECT
					[AccountId],
					[UniqueID],
					[Email],
					[FirstName],
					[LastName],
					[Address1],
					[Address2],
					[City],
					[State],
					[Zip],
					[Country],
					[Phone]
				FROM
					[dbo].[Account]
				WHERE
					[UniqueID] = @UniqueId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_GetByAccountId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetByAccountId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetByAccountId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Account table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetByAccountId
(

	@AccountId int   
)
AS


				SELECT
					[AccountId],
					[UniqueID],
					[Email],
					[FirstName],
					[LastName],
					[Address1],
					[Address2],
					[City],
					[State],
					[Zip],
					[Country],
					[Phone]
				FROM
					[dbo].[Account]
				WHERE
					[AccountId] = @AccountId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Account table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Find
(

	@SearchUsingOR bit   = null ,

	@AccountId int   = null ,

	@UniqueId int   = null ,

	@Email varchar (80)  = null ,

	@FirstName varchar (80)  = null ,

	@LastName varchar (80)  = null ,

	@Address1 varchar (80)  = null ,

	@Address2 varchar (80)  = null ,

	@City varchar (80)  = null ,

	@State varchar (80)  = null ,

	@Zip varchar (20)  = null ,

	@Country varchar (20)  = null ,

	@Phone varchar (20)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AccountId]
	, [UniqueID]
	, [Email]
	, [FirstName]
	, [LastName]
	, [Address1]
	, [Address2]
	, [City]
	, [State]
	, [Zip]
	, [Country]
	, [Phone]
    FROM
	[dbo].[Account]
    WHERE 
	 ([AccountId] = @AccountId OR @AccountId IS NULL)
	AND ([UniqueID] = @UniqueId OR @UniqueId IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([LastName] = @LastName OR @LastName IS NULL)
	AND ([Address1] = @Address1 OR @Address1 IS NULL)
	AND ([Address2] = @Address2 OR @Address2 IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([State] = @State OR @State IS NULL)
	AND ([Zip] = @Zip OR @Zip IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AccountId]
	, [UniqueID]
	, [Email]
	, [FirstName]
	, [LastName]
	, [Address1]
	, [Address2]
	, [City]
	, [State]
	, [Zip]
	, [Country]
	, [Phone]
    FROM
	[dbo].[Account]
    WHERE 
	 ([AccountId] = @AccountId AND @AccountId is not null)
	OR ([UniqueID] = @UniqueId AND @UniqueId is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([Address1] = @Address1 AND @Address1 is not null)
	OR ([Address2] = @Address2 AND @Address2 is not null)
	OR ([City] = @City AND @City is not null)
	OR ([State] = @State AND @State is not null)
	OR ([Zip] = @Zip AND @Zip is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Profiles_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Profiles_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Profiles_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Profiles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Profiles_Get_List

AS


				
				SELECT
					[UniqueID],
					[Username],
					[ApplicationName],
					[IsAnonymous],
					[LastActivityDate],
					[LastUpdatedDate]
				FROM
					[dbo].[Profiles]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Profiles_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Profiles_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Profiles_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Profiles table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Profiles_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[UniqueID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [UniqueID]'
				SET @SQL = @SQL + ', [Username]'
				SET @SQL = @SQL + ', [ApplicationName]'
				SET @SQL = @SQL + ', [IsAnonymous]'
				SET @SQL = @SQL + ', [LastActivityDate]'
				SET @SQL = @SQL + ', [LastUpdatedDate]'
				SET @SQL = @SQL + ' FROM [dbo].[Profiles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [UniqueID],'
				SET @SQL = @SQL + ' [Username],'
				SET @SQL = @SQL + ' [ApplicationName],'
				SET @SQL = @SQL + ' [IsAnonymous],'
				SET @SQL = @SQL + ' [LastActivityDate],'
				SET @SQL = @SQL + ' [LastUpdatedDate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Profiles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Profiles_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Profiles_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Profiles_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Profiles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Profiles_Insert
(

	@UniqueId int    OUTPUT,

	@Username varchar (256)  ,

	@ApplicationName varchar (256)  ,

	@IsAnonymous bit   ,

	@LastActivityDate datetime   ,

	@LastUpdatedDate datetime   
)
AS


				
				INSERT INTO [dbo].[Profiles]
					(
					[Username]
					,[ApplicationName]
					,[IsAnonymous]
					,[LastActivityDate]
					,[LastUpdatedDate]
					)
				VALUES
					(
					@Username
					,@ApplicationName
					,@IsAnonymous
					,@LastActivityDate
					,@LastUpdatedDate
					)
				
				-- Get the identity value
				SET @UniqueId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Profiles_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Profiles_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Profiles_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Profiles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Profiles_Update
(

	@UniqueId int   ,

	@Username varchar (256)  ,

	@ApplicationName varchar (256)  ,

	@IsAnonymous bit   ,

	@LastActivityDate datetime   ,

	@LastUpdatedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Profiles]
				SET
					[Username] = @Username
					,[ApplicationName] = @ApplicationName
					,[IsAnonymous] = @IsAnonymous
					,[LastActivityDate] = @LastActivityDate
					,[LastUpdatedDate] = @LastUpdatedDate
				WHERE
[UniqueID] = @UniqueId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Profiles_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Profiles_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Profiles_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Profiles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Profiles_Delete
(

	@UniqueId int   
)
AS


				DELETE FROM [dbo].[Profiles] WITH (ROWLOCK) 
				WHERE
					[UniqueID] = @UniqueId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Profiles_GetByUsernameApplicationName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Profiles_GetByUsernameApplicationName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Profiles_GetByUsernameApplicationName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Profiles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Profiles_GetByUsernameApplicationName
(

	@Username varchar (256)  ,

	@ApplicationName varchar (256)  
)
AS


				SELECT
					[UniqueID],
					[Username],
					[ApplicationName],
					[IsAnonymous],
					[LastActivityDate],
					[LastUpdatedDate]
				FROM
					[dbo].[Profiles]
				WHERE
					[Username] = @Username
					AND [ApplicationName] = @ApplicationName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Profiles_GetByUniqueId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Profiles_GetByUniqueId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Profiles_GetByUniqueId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Profiles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Profiles_GetByUniqueId
(

	@UniqueId int   
)
AS


				SELECT
					[UniqueID],
					[Username],
					[ApplicationName],
					[IsAnonymous],
					[LastActivityDate],
					[LastUpdatedDate]
				FROM
					[dbo].[Profiles]
				WHERE
					[UniqueID] = @UniqueId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Profiles_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Profiles_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Profiles_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Profiles table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Profiles_Find
(

	@SearchUsingOR bit   = null ,

	@UniqueId int   = null ,

	@Username varchar (256)  = null ,

	@ApplicationName varchar (256)  = null ,

	@IsAnonymous bit   = null ,

	@LastActivityDate datetime   = null ,

	@LastUpdatedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [UniqueID]
	, [Username]
	, [ApplicationName]
	, [IsAnonymous]
	, [LastActivityDate]
	, [LastUpdatedDate]
    FROM
	[dbo].[Profiles]
    WHERE 
	 ([UniqueID] = @UniqueId OR @UniqueId IS NULL)
	AND ([Username] = @Username OR @Username IS NULL)
	AND ([ApplicationName] = @ApplicationName OR @ApplicationName IS NULL)
	AND ([IsAnonymous] = @IsAnonymous OR @IsAnonymous IS NULL)
	AND ([LastActivityDate] = @LastActivityDate OR @LastActivityDate IS NULL)
	AND ([LastUpdatedDate] = @LastUpdatedDate OR @LastUpdatedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [UniqueID]
	, [Username]
	, [ApplicationName]
	, [IsAnonymous]
	, [LastActivityDate]
	, [LastUpdatedDate]
    FROM
	[dbo].[Profiles]
    WHERE 
	 ([UniqueID] = @UniqueId AND @UniqueId is not null)
	OR ([Username] = @Username AND @Username is not null)
	OR ([ApplicationName] = @ApplicationName AND @ApplicationName is not null)
	OR ([IsAnonymous] = @IsAnonymous AND @IsAnonymous is not null)
	OR ([LastActivityDate] = @LastActivityDate AND @LastActivityDate is not null)
	OR ([LastUpdatedDate] = @LastUpdatedDate AND @LastUpdatedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets all records from the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Get_List

AS


				
				SELECT
					[ItemId],
					[ProductId],
					[ListPrice],
					[UnitCost],
					[Supplier],
					[Status],
					[Name],
					[Image]
				FROM
					[dbo].[Item]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Gets records from the Item table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ItemId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ItemId]'
				SET @SQL = @SQL + ', [ProductId]'
				SET @SQL = @SQL + ', [ListPrice]'
				SET @SQL = @SQL + ', [UnitCost]'
				SET @SQL = @SQL + ', [Supplier]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Image]'
				SET @SQL = @SQL + ' FROM [dbo].[Item]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ItemId],'
				SET @SQL = @SQL + ' [ProductId],'
				SET @SQL = @SQL + ' [ListPrice],'
				SET @SQL = @SQL + ' [UnitCost],'
				SET @SQL = @SQL + ' [Supplier],'
				SET @SQL = @SQL + ' [Status],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Image]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Item]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Inserts a record into the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Insert
(

	@ItemId varchar (10)  ,

	@ProductId varchar (10)  ,

	@ListPrice decimal (10, 2)  ,

	@UnitCost decimal (10, 2)  ,

	@Supplier int   ,

	@Status varchar (2)  ,

	@Name varchar (80)  ,

	@Image varchar (80)  
)
AS


				
				INSERT INTO [dbo].[Item]
					(
					[ItemId]
					,[ProductId]
					,[ListPrice]
					,[UnitCost]
					,[Supplier]
					,[Status]
					,[Name]
					,[Image]
					)
				VALUES
					(
					@ItemId
					,@ProductId
					,@ListPrice
					,@UnitCost
					,@Supplier
					,@Status
					,@Name
					,@Image
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Updates a record in the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Update
(

	@ItemId varchar (10)  ,

	@OriginalItemId varchar (10)  ,

	@ProductId varchar (10)  ,

	@ListPrice decimal (10, 2)  ,

	@UnitCost decimal (10, 2)  ,

	@Supplier int   ,

	@Status varchar (2)  ,

	@Name varchar (80)  ,

	@Image varchar (80)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Item]
				SET
					[ItemId] = @ItemId
					,[ProductId] = @ProductId
					,[ListPrice] = @ListPrice
					,[UnitCost] = @UnitCost
					,[Supplier] = @Supplier
					,[Status] = @Status
					,[Name] = @Name
					,[Image] = @Image
				WHERE
[ItemId] = @OriginalItemId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Deletes a record in the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Delete
(

	@ItemId varchar (10)  
)
AS


				DELETE FROM [dbo].[Item] WITH (ROWLOCK) 
				WHERE
					[ItemId] = @ItemId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetByProductId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByProductId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByProductId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Item table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByProductId
(

	@ProductId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ItemId],
					[ProductId],
					[ListPrice],
					[UnitCost],
					[Supplier],
					[Status],
					[Name],
					[Image]
				FROM
					[dbo].[Item]
				WHERE
					[ProductId] = @ProductId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetBySupplier procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetBySupplier') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetBySupplier
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Item table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetBySupplier
(

	@Supplier int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ItemId],
					[ProductId],
					[ListPrice],
					[UnitCost],
					[Supplier],
					[Status],
					[Name],
					[Image]
				FROM
					[dbo].[Item]
				WHERE
					[Supplier] = @Supplier
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetByProductIdItemIdListPriceName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByProductIdItemIdListPriceName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByProductIdItemIdListPriceName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Item table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByProductIdItemIdListPriceName
(

	@ProductId varchar (10)  ,

	@ItemId varchar (10)  ,

	@ListPrice decimal (10, 2)  ,

	@Name varchar (80)  
)
AS


				SELECT
					[ItemId],
					[ProductId],
					[ListPrice],
					[UnitCost],
					[Supplier],
					[Status],
					[Name],
					[Image]
				FROM
					[dbo].[Item]
				WHERE
					[ProductId] = @ProductId
					AND [ItemId] = @ItemId
					AND [ListPrice] = @ListPrice
					AND [Name] = @Name
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Select records from the Item table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByItemId
(

	@ItemId varchar (10)  
)
AS


				SELECT
					[ItemId],
					[ProductId],
					[ListPrice],
					[UnitCost],
					[Supplier],
					[Status],
					[Name],
					[Image]
				FROM
					[dbo].[Item]
				WHERE
					[ItemId] = @ItemId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Pet Shop ()
-- Purpose: Finds records in the Item table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Find
(

	@SearchUsingOR bit   = null ,

	@ItemId varchar (10)  = null ,

	@ProductId varchar (10)  = null ,

	@ListPrice decimal (10, 2)  = null ,

	@UnitCost decimal (10, 2)  = null ,

	@Supplier int   = null ,

	@Status varchar (2)  = null ,

	@Name varchar (80)  = null ,

	@Image varchar (80)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ItemId]
	, [ProductId]
	, [ListPrice]
	, [UnitCost]
	, [Supplier]
	, [Status]
	, [Name]
	, [Image]
    FROM
	[dbo].[Item]
    WHERE 
	 ([ItemId] = @ItemId OR @ItemId IS NULL)
	AND ([ProductId] = @ProductId OR @ProductId IS NULL)
	AND ([ListPrice] = @ListPrice OR @ListPrice IS NULL)
	AND ([UnitCost] = @UnitCost OR @UnitCost IS NULL)
	AND ([Supplier] = @Supplier OR @Supplier IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Image] = @Image OR @Image IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ItemId]
	, [ProductId]
	, [ListPrice]
	, [UnitCost]
	, [Supplier]
	, [Status]
	, [Name]
	, [Image]
    FROM
	[dbo].[Item]
    WHERE 
	 ([ItemId] = @ItemId AND @ItemId is not null)
	OR ([ProductId] = @ProductId AND @ProductId is not null)
	OR ([ListPrice] = @ListPrice AND @ListPrice is not null)
	OR ([UnitCost] = @UnitCost AND @UnitCost is not null)
	OR ([Supplier] = @Supplier AND @Supplier is not null)
	OR ([Status] = @Status AND @Status is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Image] = @Image AND @Image is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

