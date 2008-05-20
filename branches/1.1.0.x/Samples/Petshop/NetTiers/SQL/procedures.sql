
Use [PetShop]
Go
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Category_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Gets all records from the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[AdvicePhoto],
					[Timestamp]
				FROM
					dbo.[Category]
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Category_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
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
				DECLARE @RowsToReturn int
				DECLARE @RowCount int
				
				-- First set the rowcount
				SET @RowsToReturn = @PageSize * (@PageIndex + 1)
				--SET ROWCOUNT @RowsToReturn
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize
				
				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Id] char(36) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(3500)
				SET @SQL = 'INSERT INTO #PageIndex (Id)'
				SET @SQL = @SQL + ' SELECT [Id]'
				SET @SQL = @SQL + ' FROM dbo.[Category]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				 
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return total count
				SELECT @RowCount = @@ROWCOUNT
				
				IF @PageSize <= 0
				BEGIN
				--Return all rows
				SET @PageUpperBound = @RowCount
				END
				
				-- Return total count
				SELECT @RowCount 
					
				--Set RowCount After Total Rows is determined
				SET ROWCOUNT @RowsToReturn

				-- Return paged results
				SELECT O.[Id], O.[Name], O.[AdvicePhoto], O.[Timestamp]
				FROM
				    dbo.[Category] O,
				    #PageIndex PageIndex
				WHERE
O.[Id] = PageIndex.[Id] AND 				    PageIndex.IndexID > @PageLowerBound AND
				    PageIndex.IndexID <= @PageUpperBound
				ORDER BY
				    PageIndex.IndexID
				
				END
			
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Category_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Inserts a record into the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Insert
(

	@Id char (36)  ,

	@Name varchar (255)  ,

	@AdvicePhoto varchar (255)  ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[Category]
					(
					[Id]
					,[Name]
					,[AdvicePhoto]
					)
				VALUES
					(
					@Id
					,@Name
					,@AdvicePhoto
					)
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[Category]
				WHERE
[Id] = @Id 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Category_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Updates a record in the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Update
(

	@Id char (36)  ,

	@OriginalId char (36)  ,

	@Name varchar (255)  ,

	@AdvicePhoto varchar (255)  ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[Category]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[AdvicePhoto] = @AdvicePhoto
				WHERE
[Id] = @OriginalId 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[Category]
				WHERE
[Id] = @Id 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Category_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Deletes a record in the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Delete
(

	@Id char (36)  ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[Category] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Category_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Category table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_GetById
(

	@Id char (36)  
)
AS


				SELECT
					[Id],
					[Name],
					[AdvicePhoto],
					[Timestamp]
				FROM
					dbo.[Category]
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Category_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Category_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Category_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Finds records in the Category table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Find
(

	@Id char (36)  = null ,

	@Name varchar (255)  = null ,

	@AdvicePhoto varchar (255)  = null ,

	@Timestamp timestamp   = null 
)
AS


				
				
				SELECT   [Id]
	, [Name]
	, [AdvicePhoto]
	, [Timestamp]
				FROM
					dbo.[Category]
				WHERE 
([Id] = @Id OR @Id is null)
AND ([Name] = @Name OR @Name is null)
AND ([AdvicePhoto] = @AdvicePhoto OR @AdvicePhoto is null)
																
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.CreditCard_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CreditCard_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CreditCard_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Gets all records from the CreditCard table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Get_List

AS


				
				SELECT
					[Id],
					[Number],
					[CardType],
					[ExpiryMonth],
					[ExpiryYear],
					[Timestamp]
				FROM
					dbo.[CreditCard]
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.CreditCard_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CreditCard_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CreditCard_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Gets records from the CreditCard table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_GetPaged
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
				DECLARE @RowsToReturn int
				DECLARE @RowCount int
				
				-- First set the rowcount
				SET @RowsToReturn = @PageSize * (@PageIndex + 1)
				--SET ROWCOUNT @RowsToReturn
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize
				
				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Id] char(36) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(3500)
				SET @SQL = 'INSERT INTO #PageIndex (Id)'
				SET @SQL = @SQL + ' SELECT [Id]'
				SET @SQL = @SQL + ' FROM dbo.[CreditCard]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				 
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return total count
				SELECT @RowCount = @@ROWCOUNT
				
				IF @PageSize <= 0
				BEGIN
				--Return all rows
				SET @PageUpperBound = @RowCount
				END
				
				-- Return total count
				SELECT @RowCount 
					
				--Set RowCount After Total Rows is determined
				SET ROWCOUNT @RowsToReturn

				-- Return paged results
				SELECT O.[Id], O.[Number], O.[CardType], O.[ExpiryMonth], O.[ExpiryYear], O.[Timestamp]
				FROM
				    dbo.[CreditCard] O,
				    #PageIndex PageIndex
				WHERE
O.[Id] = PageIndex.[Id] AND 				    PageIndex.IndexID > @PageLowerBound AND
				    PageIndex.IndexID <= @PageUpperBound
				ORDER BY
				    PageIndex.IndexID
				
				END
			
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.CreditCard_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CreditCard_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CreditCard_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Inserts a record into the CreditCard table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Insert
(

	@Id char (36)  ,

	@Number varchar (255)  ,

	@CardType varchar (255)  ,

	@ExpiryMonth varchar (255)  ,

	@ExpiryYear varchar (255)  ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[CreditCard]
					(
					[Id]
					,[Number]
					,[CardType]
					,[ExpiryMonth]
					,[ExpiryYear]
					)
				VALUES
					(
					@Id
					,@Number
					,@CardType
					,@ExpiryMonth
					,@ExpiryYear
					)
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[CreditCard]
				WHERE
[Id] = @Id 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.CreditCard_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CreditCard_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CreditCard_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Updates a record in the CreditCard table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Update
(

	@Id char (36)  ,

	@OriginalId char (36)  ,

	@Number varchar (255)  ,

	@CardType varchar (255)  ,

	@ExpiryMonth varchar (255)  ,

	@ExpiryYear varchar (255)  ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[CreditCard]
				SET
					[Id] = @Id
					,[Number] = @Number
					,[CardType] = @CardType
					,[ExpiryMonth] = @ExpiryMonth
					,[ExpiryYear] = @ExpiryYear
				WHERE
[Id] = @OriginalId 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[CreditCard]
				WHERE
[Id] = @Id 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.CreditCard_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CreditCard_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CreditCard_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Deletes a record in the CreditCard table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Delete
(

	@Id char (36)  ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[CreditCard] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.CreditCard_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CreditCard_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CreditCard_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the CreditCard table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_GetById
(

	@Id char (36)  
)
AS


				SELECT
					[Id],
					[Number],
					[CardType],
					[ExpiryMonth],
					[ExpiryYear],
					[Timestamp]
				FROM
					dbo.[CreditCard]
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.CreditCard_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CreditCard_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CreditCard_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Finds records in the CreditCard table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Find
(

	@Id char (36)  = null ,

	@Number varchar (255)  = null ,

	@CardType varchar (255)  = null ,

	@ExpiryMonth varchar (255)  = null ,

	@ExpiryYear varchar (255)  = null ,

	@Timestamp timestamp   = null 
)
AS


				
				
				SELECT   [Id]
	, [Number]
	, [CardType]
	, [ExpiryMonth]
	, [ExpiryYear]
	, [Timestamp]
				FROM
					dbo.[CreditCard]
				WHERE 
([Id] = @Id OR @Id is null)
AND ([Number] = @Number OR @Number is null)
AND ([CardType] = @CardType OR @CardType is null)
AND ([ExpiryMonth] = @ExpiryMonth OR @ExpiryMonth is null)
AND ([ExpiryYear] = @ExpiryYear OR @ExpiryYear is null)
																
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Product_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Gets all records from the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[Description],
					[CategoryId],
					[Timestamp]
				FROM
					dbo.[Product]
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Product_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
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
				DECLARE @RowsToReturn int
				DECLARE @RowCount int
				
				-- First set the rowcount
				SET @RowsToReturn = @PageSize * (@PageIndex + 1)
				--SET ROWCOUNT @RowsToReturn
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize
				
				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Id] char(36) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(3500)
				SET @SQL = 'INSERT INTO #PageIndex (Id)'
				SET @SQL = @SQL + ' SELECT [Id]'
				SET @SQL = @SQL + ' FROM dbo.[Product]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				 
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return total count
				SELECT @RowCount = @@ROWCOUNT
				
				IF @PageSize <= 0
				BEGIN
				--Return all rows
				SET @PageUpperBound = @RowCount
				END
				
				-- Return total count
				SELECT @RowCount 
					
				--Set RowCount After Total Rows is determined
				SET ROWCOUNT @RowsToReturn

				-- Return paged results
				SELECT O.[Id], O.[Name], O.[Description], O.[CategoryId], O.[Timestamp]
				FROM
				    dbo.[Product] O,
				    #PageIndex PageIndex
				WHERE
O.[Id] = PageIndex.[Id] AND 				    PageIndex.IndexID > @PageLowerBound AND
				    PageIndex.IndexID <= @PageUpperBound
				ORDER BY
				    PageIndex.IndexID
				
				END
			
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Product_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Inserts a record into the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Insert
(

	@Id char (36)  ,

	@Name varchar (255)  ,

	@Description varchar (255)  ,

	@CategoryId char (36)  ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[Product]
					(
					[Id]
					,[Name]
					,[Description]
					,[CategoryId]
					)
				VALUES
					(
					@Id
					,@Name
					,@Description
					,@CategoryId
					)
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[Product]
				WHERE
[Id] = @Id 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Product_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Updates a record in the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Update
(

	@Id char (36)  ,

	@OriginalId char (36)  ,

	@Name varchar (255)  ,

	@Description varchar (255)  ,

	@CategoryId char (36)  ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[Product]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[Description] = @Description
					,[CategoryId] = @CategoryId
				WHERE
[Id] = @OriginalId 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[Product]
				WHERE
[Id] = @Id 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Product_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Deletes a record in the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Delete
(

	@Id char (36)  ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[Product] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Product_GetByCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetByCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetByCategoryId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Product table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetByCategoryId
(

	@CategoryId char (36)  
)
AS


				
				SELECT
					[Id],
					[Name],
					[Description],
					[CategoryId],
					[Timestamp]
				FROM
					dbo.[Product]
				WHERE
					[CategoryId] = @CategoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Product_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Product table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetById
(

	@Id char (36)  
)
AS


				SELECT
					[Id],
					[Name],
					[Description],
					[CategoryId],
					[Timestamp]
				FROM
					dbo.[Product]
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Product_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Product_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Product_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Finds records in the Product table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Find
(

	@Id char (36)  = null ,

	@Name varchar (255)  = null ,

	@Description varchar (255)  = null ,

	@CategoryId char (36)  = null ,

	@Timestamp timestamp   = null 
)
AS


				
				
				SELECT   [Id]
	, [Name]
	, [Description]
	, [CategoryId]
	, [Timestamp]
				FROM
					dbo.[Product]
				WHERE 
([Id] = @Id OR @Id is null)
AND ([Name] = @Name OR @Name is null)
AND ([Description] = @Description OR @Description is null)
AND ([CategoryId] = @CategoryId OR @CategoryId is null)
																
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Item_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Gets all records from the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[Description],
					[Price],
					[Currency],
					[Photo],
					[ProductId],
					[Timestamp]
				FROM
					dbo.[Item]
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Item_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
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
				DECLARE @RowsToReturn int
				DECLARE @RowCount int
				
				-- First set the rowcount
				SET @RowsToReturn = @PageSize * (@PageIndex + 1)
				--SET ROWCOUNT @RowsToReturn
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize
				
				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Id] char(36) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(3500)
				SET @SQL = 'INSERT INTO #PageIndex (Id)'
				SET @SQL = @SQL + ' SELECT [Id]'
				SET @SQL = @SQL + ' FROM dbo.[Item]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				 
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return total count
				SELECT @RowCount = @@ROWCOUNT
				
				IF @PageSize <= 0
				BEGIN
				--Return all rows
				SET @PageUpperBound = @RowCount
				END
				
				-- Return total count
				SELECT @RowCount 
					
				--Set RowCount After Total Rows is determined
				SET ROWCOUNT @RowsToReturn

				-- Return paged results
				SELECT O.[Id], O.[Name], O.[Description], O.[Price], O.[Currency], O.[Photo], O.[ProductId], O.[Timestamp]
				FROM
				    dbo.[Item] O,
				    #PageIndex PageIndex
				WHERE
O.[Id] = PageIndex.[Id] AND 				    PageIndex.IndexID > @PageLowerBound AND
				    PageIndex.IndexID <= @PageUpperBound
				ORDER BY
				    PageIndex.IndexID
				
				END
			
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Item_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Inserts a record into the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Insert
(

	@Id char (36)  ,

	@Name varchar (255)  ,

	@Description varchar (255)  ,

	@Price float   ,

	@Currency varchar (255)  ,

	@Photo varchar (255)  ,

	@ProductId char (36)  ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[Item]
					(
					[Id]
					,[Name]
					,[Description]
					,[Price]
					,[Currency]
					,[Photo]
					,[ProductId]
					)
				VALUES
					(
					@Id
					,@Name
					,@Description
					,@Price
					,@Currency
					,@Photo
					,@ProductId
					)
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[Item]
				WHERE
[Id] = @Id 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Item_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Updates a record in the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Update
(

	@Id char (36)  ,

	@OriginalId char (36)  ,

	@Name varchar (255)  ,

	@Description varchar (255)  ,

	@Price float   ,

	@Currency varchar (255)  ,

	@Photo varchar (255)  ,

	@ProductId char (36)  ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[Item]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[Description] = @Description
					,[Price] = @Price
					,[Currency] = @Currency
					,[Photo] = @Photo
					,[ProductId] = @ProductId
				WHERE
[Id] = @OriginalId 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[Item]
				WHERE
[Id] = @Id 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Item_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Deletes a record in the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Delete
(

	@Id char (36)  ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[Item] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Item_GetByProductId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByProductId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByProductId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Item table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByProductId
(

	@ProductId char (36)  
)
AS


				
				SELECT
					[Id],
					[Name],
					[Description],
					[Price],
					[Currency],
					[Photo],
					[ProductId],
					[Timestamp]
				FROM
					dbo.[Item]
				WHERE
					[ProductId] = @ProductId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Item_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Item table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetById
(

	@Id char (36)  
)
AS


				SELECT
					[Id],
					[Name],
					[Description],
					[Price],
					[Currency],
					[Photo],
					[ProductId],
					[Timestamp]
				FROM
					dbo.[Item]
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Item_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Finds records in the Item table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Find
(

	@Id char (36)  = null ,

	@Name varchar (255)  = null ,

	@Description varchar (255)  = null ,

	@Price float   = null ,

	@Currency varchar (255)  = null ,

	@Photo varchar (255)  = null ,

	@ProductId char (36)  = null ,

	@Timestamp timestamp   = null 
)
AS


				
				
				SELECT   [Id]
	, [Name]
	, [Description]
	, [Price]
	, [Currency]
	, [Photo]
	, [ProductId]
	, [Timestamp]
				FROM
					dbo.[Item]
				WHERE 
([Id] = @Id OR @Id is null)
AND ([Name] = @Name OR @Name is null)
AND ([Description] = @Description OR @Description is null)
AND ([Price] = @Price OR @Price is null)
AND ([Currency] = @Currency OR @Currency is null)
AND ([Photo] = @Photo OR @Photo is null)
AND ([ProductId] = @ProductId OR @ProductId is null)
																
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Gets all records from the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Get_List

AS


				
				SELECT
					[Id],
					[FirstName],
					[LastName],
					[StreetAddress],
					[PostalCode],
					[City],
					[StateOrProvince],
					[Country],
					[TelephoneNumber],
					[Email],
					[Login],
					[Password],
					[IWantMyList],
					[IWantPetTips],
					[FavoriteLanguage],
					[CreditCardId],
					[FavoriteCategoryId],
					[Timestamp]
				FROM
					dbo.[Account]
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
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
				DECLARE @RowsToReturn int
				DECLARE @RowCount int
				
				-- First set the rowcount
				SET @RowsToReturn = @PageSize * (@PageIndex + 1)
				--SET ROWCOUNT @RowsToReturn
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize
				
				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Id] char(36) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(3500)
				SET @SQL = 'INSERT INTO #PageIndex (Id)'
				SET @SQL = @SQL + ' SELECT [Id]'
				SET @SQL = @SQL + ' FROM dbo.[Account]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				 
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return total count
				SELECT @RowCount = @@ROWCOUNT
				
				IF @PageSize <= 0
				BEGIN
				--Return all rows
				SET @PageUpperBound = @RowCount
				END
				
				-- Return total count
				SELECT @RowCount 
					
				--Set RowCount After Total Rows is determined
				SET ROWCOUNT @RowsToReturn

				-- Return paged results
				SELECT O.[Id], O.[FirstName], O.[LastName], O.[StreetAddress], O.[PostalCode], O.[City], O.[StateOrProvince], O.[Country], O.[TelephoneNumber], O.[Email], O.[Login], O.[Password], O.[IWantMyList], O.[IWantPetTips], O.[FavoriteLanguage], O.[CreditCardId], O.[FavoriteCategoryId], O.[Timestamp]
				FROM
				    dbo.[Account] O,
				    #PageIndex PageIndex
				WHERE
O.[Id] = PageIndex.[Id] AND 				    PageIndex.IndexID > @PageLowerBound AND
				    PageIndex.IndexID <= @PageUpperBound
				ORDER BY
				    PageIndex.IndexID
				
				END
			
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Inserts a record into the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Insert
(

	@Id char (36)  ,

	@FirstName varchar (255)  ,

	@LastName varchar (255)  ,

	@StreetAddress varchar (255)  ,

	@PostalCode varchar (255)  ,

	@City varchar (255)  ,

	@StateOrProvince varchar (255)  ,

	@Country varchar (255)  ,

	@TelephoneNumber varchar (255)  ,

	@Email varchar (255)  ,

	@Login varchar (255)  ,

	@Password varchar (255)  ,

	@IWantMyList bit   ,

	@IWantPetTips bit   ,

	@FavoriteLanguage varchar (255)  ,

	@CreditCardId char (36)  ,

	@FavoriteCategoryId char (36)  ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[Account]
					(
					[Id]
					,[FirstName]
					,[LastName]
					,[StreetAddress]
					,[PostalCode]
					,[City]
					,[StateOrProvince]
					,[Country]
					,[TelephoneNumber]
					,[Email]
					,[Login]
					,[Password]
					,[IWantMyList]
					,[IWantPetTips]
					,[FavoriteLanguage]
					,[CreditCardId]
					,[FavoriteCategoryId]
					)
				VALUES
					(
					@Id
					,@FirstName
					,@LastName
					,@StreetAddress
					,@PostalCode
					,@City
					,@StateOrProvince
					,@Country
					,@TelephoneNumber
					,@Email
					,@Login
					,@Password
					,@IWantMyList
					,@IWantPetTips
					,@FavoriteLanguage
					,@CreditCardId
					,@FavoriteCategoryId
					)
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[Account]
				WHERE
[Id] = @Id 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Updates a record in the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Update
(

	@Id char (36)  ,

	@OriginalId char (36)  ,

	@FirstName varchar (255)  ,

	@LastName varchar (255)  ,

	@StreetAddress varchar (255)  ,

	@PostalCode varchar (255)  ,

	@City varchar (255)  ,

	@StateOrProvince varchar (255)  ,

	@Country varchar (255)  ,

	@TelephoneNumber varchar (255)  ,

	@Email varchar (255)  ,

	@Login varchar (255)  ,

	@Password varchar (255)  ,

	@IWantMyList bit   ,

	@IWantPetTips bit   ,

	@FavoriteLanguage varchar (255)  ,

	@CreditCardId char (36)  ,

	@FavoriteCategoryId char (36)  ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[Account]
				SET
					[Id] = @Id
					,[FirstName] = @FirstName
					,[LastName] = @LastName
					,[StreetAddress] = @StreetAddress
					,[PostalCode] = @PostalCode
					,[City] = @City
					,[StateOrProvince] = @StateOrProvince
					,[Country] = @Country
					,[TelephoneNumber] = @TelephoneNumber
					,[Email] = @Email
					,[Login] = @Login
					,[Password] = @Password
					,[IWantMyList] = @IWantMyList
					,[IWantPetTips] = @IWantPetTips
					,[FavoriteLanguage] = @FavoriteLanguage
					,[CreditCardId] = @CreditCardId
					,[FavoriteCategoryId] = @FavoriteCategoryId
				WHERE
[Id] = @OriginalId 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[Account]
				WHERE
[Id] = @Id 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Deletes a record in the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Delete
(

	@Id char (36)  ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[Account] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_GetByFavoriteCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetByFavoriteCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetByFavoriteCategoryId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Account table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetByFavoriteCategoryId
(

	@FavoriteCategoryId char (36)  
)
AS


				
				SELECT
					[Id],
					[FirstName],
					[LastName],
					[StreetAddress],
					[PostalCode],
					[City],
					[StateOrProvince],
					[Country],
					[TelephoneNumber],
					[Email],
					[Login],
					[Password],
					[IWantMyList],
					[IWantPetTips],
					[FavoriteLanguage],
					[CreditCardId],
					[FavoriteCategoryId],
					[Timestamp]
				FROM
					dbo.[Account]
				WHERE
					[FavoriteCategoryId] = @FavoriteCategoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_GetByCreditCardId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetByCreditCardId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetByCreditCardId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Account table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetByCreditCardId
(

	@CreditCardId char (36)  
)
AS


				
				SELECT
					[Id],
					[FirstName],
					[LastName],
					[StreetAddress],
					[PostalCode],
					[City],
					[StateOrProvince],
					[Country],
					[TelephoneNumber],
					[Email],
					[Login],
					[Password],
					[IWantMyList],
					[IWantPetTips],
					[FavoriteLanguage],
					[CreditCardId],
					[FavoriteCategoryId],
					[Timestamp]
				FROM
					dbo.[Account]
				WHERE
					[CreditCardId] = @CreditCardId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Account table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetById
(

	@Id char (36)  
)
AS


				SELECT
					[Id],
					[FirstName],
					[LastName],
					[StreetAddress],
					[PostalCode],
					[City],
					[StateOrProvince],
					[Country],
					[TelephoneNumber],
					[Email],
					[Login],
					[Password],
					[IWantMyList],
					[IWantPetTips],
					[FavoriteLanguage],
					[CreditCardId],
					[FavoriteCategoryId],
					[Timestamp]
				FROM
					dbo.[Account]
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_GetByLogin procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetByLogin') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetByLogin
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Select records from the Account table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetByLogin
(

	@Login varchar (255)  
)
AS


				SELECT
					[Id],
					[FirstName],
					[LastName],
					[StreetAddress],
					[PostalCode],
					[City],
					[StateOrProvince],
					[Country],
					[TelephoneNumber],
					[Email],
					[Login],
					[Password],
					[IWantMyList],
					[IWantPetTips],
					[FavoriteLanguage],
					[CreditCardId],
					[FavoriteCategoryId],
					[Timestamp]
				FROM
					dbo.[Account]
				WHERE
					[Login] = @Login
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.Account_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Finds records in the Account table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Find
(

	@Id char (36)  = null ,

	@FirstName varchar (255)  = null ,

	@LastName varchar (255)  = null ,

	@StreetAddress varchar (255)  = null ,

	@PostalCode varchar (255)  = null ,

	@City varchar (255)  = null ,

	@StateOrProvince varchar (255)  = null ,

	@Country varchar (255)  = null ,

	@TelephoneNumber varchar (255)  = null ,

	@Email varchar (255)  = null ,

	@Login varchar (255)  = null ,

	@Password varchar (255)  = null ,

	@IWantMyList bit   = null ,

	@IWantPetTips bit   = null ,

	@FavoriteLanguage varchar (255)  = null ,

	@CreditCardId char (36)  = null ,

	@FavoriteCategoryId char (36)  = null ,

	@Timestamp timestamp   = null 
)
AS


				
				
				SELECT   [Id]
	, [FirstName]
	, [LastName]
	, [StreetAddress]
	, [PostalCode]
	, [City]
	, [StateOrProvince]
	, [Country]
	, [TelephoneNumber]
	, [Email]
	, [Login]
	, [Password]
	, [IWantMyList]
	, [IWantPetTips]
	, [FavoriteLanguage]
	, [CreditCardId]
	, [FavoriteCategoryId]
	, [Timestamp]
				FROM
					dbo.[Account]
				WHERE 
([Id] = @Id OR @Id is null)
AND ([FirstName] = @FirstName OR @FirstName is null)
AND ([LastName] = @LastName OR @LastName is null)
AND ([StreetAddress] = @StreetAddress OR @StreetAddress is null)
AND ([PostalCode] = @PostalCode OR @PostalCode is null)
AND ([City] = @City OR @City is null)
AND ([StateOrProvince] = @StateOrProvince OR @StateOrProvince is null)
AND ([Country] = @Country OR @Country is null)
AND ([TelephoneNumber] = @TelephoneNumber OR @TelephoneNumber is null)
AND ([Email] = @Email OR @Email is null)
AND ([Login] = @Login OR @Login is null)
AND ([Password] = @Password OR @Password is null)
AND ([IWantMyList] = @IWantMyList OR @IWantMyList is null)
AND ([IWantPetTips] = @IWantPetTips OR @IWantPetTips is null)
AND ([FavoriteLanguage] = @FavoriteLanguage OR @FavoriteLanguage is null)
AND ([CreditCardId] = @CreditCardId OR @CreditCardId is null)
AND ([FavoriteCategoryId] = @FavoriteCategoryId OR @FavoriteCategoryId is null)
																
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.ExtendedItem_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ExtendedItem_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ExtendedItem_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Gets all records from the ExtendedItem view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ExtendedItem_Get_List

AS


				
				SELECT
					[ItemId],
					[ItemName],
					[ItemDescription],
					[ItemPrice],
					[ItemPhoto],
					[ProductId],
					[ProductName],
					[ProductDescription],
					[CategoryId],
					[CategoryName]
				FROM
					dbo.[ExtendedItem]
										
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- Drop the dbo.ExtendedItem_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ExtendedItem_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ExtendedItem_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: mercredi 15 mars 2006

-- Created By: .netTiers (http://www.nettiers.com)
-- Purpose: Gets records from the ExtendedItem view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ExtendedItem_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


				
				BEGIN

				-- Build the sql query
				declare @SQL as nvarchar(4000)
				SET @SQL = ' SELECT * FROM dbo.[ExtendedItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				 
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Execution the query
				exec sp_executesql @SQL
								
				END
								
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

