
Use [petshopDB]
Go
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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [LastName]'
				SET @SQL = @SQL + ', [StreetAddress]'
				SET @SQL = @SQL + ', [PostalCode]'
				SET @SQL = @SQL + ', [City]'
				SET @SQL = @SQL + ', [StateOrProvince]'
				SET @SQL = @SQL + ', [Country]'
				SET @SQL = @SQL + ', [TelephoneNumber]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [Login]'
				SET @SQL = @SQL + ', [Password]'
				SET @SQL = @SQL + ', [IWantMyList]'
				SET @SQL = @SQL + ', [IWantPetTips]'
				SET @SQL = @SQL + ', [FavoriteLanguage]'
				SET @SQL = @SQL + ', [CreditCardId]'
				SET @SQL = @SQL + ', [FavoriteCategoryId]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[Account]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [LastName],'
				SET @SQL = @SQL + ' [StreetAddress],'
				SET @SQL = @SQL + ' [PostalCode],'
				SET @SQL = @SQL + ' [City],'
				SET @SQL = @SQL + ' [StateOrProvince],'
				SET @SQL = @SQL + ' [Country],'
				SET @SQL = @SQL + ' [TelephoneNumber],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [Login],'
				SET @SQL = @SQL + ' [Password],'
				SET @SQL = @SQL + ' [IWantMyList],'
				SET @SQL = @SQL + ' [IWantPetTips],'
				SET @SQL = @SQL + ' [FavoriteLanguage],'
				SET @SQL = @SQL + ' [CreditCardId],'
				SET @SQL = @SQL + ' [FavoriteCategoryId],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[Account]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Insert
(

	@Id uniqueidentifier   ,

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

	@CreditCardId uniqueidentifier   ,

	@FavoriteCategoryId uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Update
(

	@Id uniqueidentifier   ,

	@OriginalId uniqueidentifier   ,

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

	@CreditCardId uniqueidentifier   ,

	@FavoriteCategoryId uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the Account table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Delete
(

	@Id uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Account table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetByFavoriteCategoryId
(

	@FavoriteCategoryId uniqueidentifier   
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
				
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Account table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetByCreditCardId
(

	@CreditCardId uniqueidentifier   
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
				
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Account table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetById
(

	@Id uniqueidentifier   
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
			Select @@ROWCOUNT
					
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Account_GetByLastName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Account_GetByLastName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Account_GetByLastName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Account table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_GetByLastName
(

	@LastName varchar (255)  
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
					[LastName] = @LastName
			Select @@ROWCOUNT
					
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the Account table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Account_Find
(

	@SearchUsingOR bit   = null ,

	@Id uniqueidentifier   = null ,

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

	@CreditCardId uniqueidentifier   = null ,

	@FavoriteCategoryId uniqueidentifier   = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
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
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
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
	 ([Id] = @Id AND @Id is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([StreetAddress] = @StreetAddress AND @StreetAddress is not null)
	OR ([PostalCode] = @PostalCode AND @PostalCode is not null)
	OR ([City] = @City AND @City is not null)
	OR ([StateOrProvince] = @StateOrProvince AND @StateOrProvince is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([TelephoneNumber] = @TelephoneNumber AND @TelephoneNumber is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Login] = @Login AND @Login is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([IWantMyList] = @IWantMyList AND @IWantMyList is not null)
	OR ([IWantPetTips] = @IWantPetTips AND @IWantPetTips is not null)
	OR ([FavoriteLanguage] = @FavoriteLanguage AND @FavoriteLanguage is not null)
	OR ([CreditCardId] = @CreditCardId AND @CreditCardId is not null)
	OR ([FavoriteCategoryId] = @FavoriteCategoryId AND @FavoriteCategoryId is not null)
	Select @@ROWCOUNT			
  END
				

GO
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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [AdvicePhoto]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[Category]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [AdvicePhoto],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[Category]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Insert
(

	@Id uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Update
(

	@Id uniqueidentifier   ,

	@OriginalId uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the Category table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Delete
(

	@Id uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Category table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_GetById
(

	@Id uniqueidentifier   
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
			Select @@ROWCOUNT
					
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the Category table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Category_Find
(

	@SearchUsingOR bit   = null ,

	@Id uniqueidentifier   = null ,

	@Name varchar (255)  = null ,

	@AdvicePhoto varchar (255)  = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [AdvicePhoto]
	, [Timestamp]
    FROM
	dbo.[Category]
    WHERE 
	 ([Id] = @Id OR @Id is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([AdvicePhoto] = @AdvicePhoto OR @AdvicePhoto is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [AdvicePhoto]
	, [Timestamp]
    FROM
	dbo.[Category]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([AdvicePhoto] = @AdvicePhoto AND @AdvicePhoto is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Courier_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Courier_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Courier_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets all records from the Courier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Courier_Get_List

AS


				
				SELECT
					[CourierId],
					[CourierName],
					[CourierDescription],
					[MinItems],
					[MaxItems],
					[Timestamp]
				FROM
					dbo.[Courier]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Courier_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Courier_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Courier_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets records from the Courier table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Courier_GetPaged
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CourierId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CourierId]'
				SET @SQL = @SQL + ', [CourierName]'
				SET @SQL = @SQL + ', [CourierDescription]'
				SET @SQL = @SQL + ', [MinItems]'
				SET @SQL = @SQL + ', [MaxItems]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[Courier]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CourierId],'
				SET @SQL = @SQL + ' [CourierName],'
				SET @SQL = @SQL + ' [CourierDescription],'
				SET @SQL = @SQL + ' [MinItems],'
				SET @SQL = @SQL + ' [MaxItems],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[Courier]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Courier_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Courier_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Courier_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the Courier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Courier_Insert
(

	@CourierId uniqueidentifier   ,

	@CourierName varchar (30)  ,

	@CourierDescription varchar (60)  ,

	@MinItems int   ,

	@MaxItems int   ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[Courier]
					(
					[CourierId]
					,[CourierName]
					,[CourierDescription]
					,[MinItems]
					,[MaxItems]
					)
				VALUES
					(
					@CourierId
					,@CourierName
					,@CourierDescription
					,@MinItems
					,@MaxItems
					)
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[Courier]
				WHERE
[CourierId] = @CourierId 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Courier_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Courier_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Courier_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the Courier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Courier_Update
(

	@CourierId uniqueidentifier   ,

	@OriginalCourierId uniqueidentifier   ,

	@CourierName varchar (30)  ,

	@CourierDescription varchar (60)  ,

	@MinItems int   ,

	@MaxItems int   ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[Courier]
				SET
					[CourierId] = @CourierId
					,[CourierName] = @CourierName
					,[CourierDescription] = @CourierDescription
					,[MinItems] = @MinItems
					,[MaxItems] = @MaxItems
				WHERE
[CourierId] = @OriginalCourierId 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[Courier]
				WHERE
[CourierId] = @CourierId 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Courier_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Courier_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Courier_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the Courier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Courier_Delete
(

	@CourierId uniqueidentifier   ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[Courier] WITH (ROWLOCK) 
				WHERE
					[CourierId] = @CourierId
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Courier_GetByCourierId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Courier_GetByCourierId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Courier_GetByCourierId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Courier table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Courier_GetByCourierId
(

	@CourierId uniqueidentifier   
)
AS


				SELECT
					[CourierId],
					[CourierName],
					[CourierDescription],
					[MinItems],
					[MaxItems],
					[Timestamp]
				FROM
					dbo.[Courier]
				WHERE
					[CourierId] = @CourierId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Courier_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Courier_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Courier_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the Courier table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Courier_Find
(

	@SearchUsingOR bit   = null ,

	@CourierId uniqueidentifier   = null ,

	@CourierName varchar (30)  = null ,

	@CourierDescription varchar (60)  = null ,

	@MinItems int   = null ,

	@MaxItems int   = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CourierId]
	, [CourierName]
	, [CourierDescription]
	, [MinItems]
	, [MaxItems]
	, [Timestamp]
    FROM
	dbo.[Courier]
    WHERE 
	 ([CourierId] = @CourierId OR @CourierId is null)
	AND ([CourierName] = @CourierName OR @CourierName is null)
	AND ([CourierDescription] = @CourierDescription OR @CourierDescription is null)
	AND ([MinItems] = @MinItems OR @MinItems is null)
	AND ([MaxItems] = @MaxItems OR @MaxItems is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CourierId]
	, [CourierName]
	, [CourierDescription]
	, [MinItems]
	, [MaxItems]
	, [Timestamp]
    FROM
	dbo.[Courier]
    WHERE 
	 ([CourierId] = @CourierId AND @CourierId is not null)
	OR ([CourierName] = @CourierName AND @CourierName is not null)
	OR ([CourierDescription] = @CourierDescription AND @CourierDescription is not null)
	OR ([MinItems] = @MinItems AND @MinItems is not null)
	OR ([MaxItems] = @MaxItems AND @MaxItems is not null)
	Select @@ROWCOUNT			
  END
				

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Number]'
				SET @SQL = @SQL + ', [CardType]'
				SET @SQL = @SQL + ', [ExpiryMonth]'
				SET @SQL = @SQL + ', [ExpiryYear]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[CreditCard]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Number],'
				SET @SQL = @SQL + ' [CardType],'
				SET @SQL = @SQL + ' [ExpiryMonth],'
				SET @SQL = @SQL + ' [ExpiryYear],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[CreditCard]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the CreditCard table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Insert
(

	@Id uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the CreditCard table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Update
(

	@Id uniqueidentifier   ,

	@OriginalId uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the CreditCard table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Delete
(

	@Id uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the CreditCard table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_GetById
(

	@Id uniqueidentifier   
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
			Select @@ROWCOUNT
					
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the CreditCard table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CreditCard_Find
(

	@SearchUsingOR bit   = null ,

	@Id uniqueidentifier   = null ,

	@Number varchar (255)  = null ,

	@CardType varchar (255)  = null ,

	@ExpiryMonth varchar (255)  = null ,

	@ExpiryYear varchar (255)  = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
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
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Number]
	, [CardType]
	, [ExpiryMonth]
	, [ExpiryYear]
	, [Timestamp]
    FROM
	dbo.[CreditCard]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Number] = @Number AND @Number is not null)
	OR ([CardType] = @CardType AND @CardType is not null)
	OR ([ExpiryMonth] = @ExpiryMonth AND @ExpiryMonth is not null)
	OR ([ExpiryYear] = @ExpiryYear AND @ExpiryYear is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets all records from the Inventory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Get_List

AS


				
				SELECT
					[ItemId],
					[SuppId],
					[Qty],
					[Timestamp]
				FROM
					dbo.[Inventory]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ItemId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ItemId]'
				SET @SQL = @SQL + ', [SuppId]'
				SET @SQL = @SQL + ', [Qty]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[Inventory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ItemId],'
				SET @SQL = @SQL + ' [SuppId],'
				SET @SQL = @SQL + ' [Qty],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[Inventory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the Inventory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Insert
(

	@ItemId uniqueidentifier   ,

	@SuppId uniqueidentifier   ,

	@Qty int   ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[Inventory]
					(
					[ItemId]
					,[SuppId]
					,[Qty]
					)
				VALUES
					(
					@ItemId
					,@SuppId
					,@Qty
					)
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[Inventory]
				WHERE
[ItemId] = @ItemId 
AND [SuppId] = @SuppId 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the Inventory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Update
(

	@ItemId uniqueidentifier   ,

	@OriginalItemId uniqueidentifier   ,

	@SuppId uniqueidentifier   ,

	@OriginalSuppId uniqueidentifier   ,

	@Qty int   ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[Inventory]
				SET
					[ItemId] = @ItemId
					,[SuppId] = @SuppId
					,[Qty] = @Qty
				WHERE
[ItemId] = @OriginalItemId 
AND [SuppId] = @OriginalSuppId 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[Inventory]
				WHERE
[ItemId] = @ItemId 
AND [SuppId] = @SuppId 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the Inventory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Delete
(

	@ItemId uniqueidentifier   ,

	@SuppId uniqueidentifier   ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[Inventory] WITH (ROWLOCK) 
				WHERE
					[ItemId] = @ItemId
					AND [SuppId] = @SuppId
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Inventory table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_GetByItemId
(

	@ItemId uniqueidentifier   
)
AS


				
				SELECT
					[ItemId],
					[SuppId],
					[Qty],
					[Timestamp]
				FROM
					dbo.[Inventory]
				WHERE
					[ItemId] = @ItemId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_GetBySuppId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_GetBySuppId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_GetBySuppId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Inventory table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_GetBySuppId
(

	@SuppId uniqueidentifier   
)
AS


				
				SELECT
					[ItemId],
					[SuppId],
					[Qty],
					[Timestamp]
				FROM
					dbo.[Inventory]
				WHERE
					[SuppId] = @SuppId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_GetByItemIdSuppId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_GetByItemIdSuppId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_GetByItemIdSuppId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Inventory table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_GetByItemIdSuppId
(

	@ItemId uniqueidentifier   ,

	@SuppId uniqueidentifier   
)
AS


				SELECT
					[ItemId],
					[SuppId],
					[Qty],
					[Timestamp]
				FROM
					dbo.[Inventory]
				WHERE
					[ItemId] = @ItemId
					AND [SuppId] = @SuppId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Inventory_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Inventory_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Inventory_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the Inventory table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Inventory_Find
(

	@SearchUsingOR bit   = null ,

	@ItemId uniqueidentifier   = null ,

	@SuppId uniqueidentifier   = null ,

	@Qty int   = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ItemId]
	, [SuppId]
	, [Qty]
	, [Timestamp]
    FROM
	dbo.[Inventory]
    WHERE 
	 ([ItemId] = @ItemId OR @ItemId is null)
	AND ([SuppId] = @SuppId OR @SuppId is null)
	AND ([Qty] = @Qty OR @Qty is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ItemId]
	, [SuppId]
	, [Qty]
	, [Timestamp]
    FROM
	dbo.[Inventory]
    WHERE 
	 ([ItemId] = @ItemId AND @ItemId is not null)
	OR ([SuppId] = @SuppId AND @SuppId is not null)
	OR ([Qty] = @Qty AND @Qty is not null)
	Select @@ROWCOUNT			
  END
				

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [Price]'
				SET @SQL = @SQL + ', [Currency]'
				SET @SQL = @SQL + ', [Photo]'
				SET @SQL = @SQL + ', [ProductId]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[Item]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [Price],'
				SET @SQL = @SQL + ' [Currency],'
				SET @SQL = @SQL + ' [Photo],'
				SET @SQL = @SQL + ' [ProductId],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[Item]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Insert
(

	@Id uniqueidentifier   ,

	@Name varchar (255)  ,

	@Description varchar (255)  ,

	@Price float   ,

	@Currency varchar (255)  ,

	@Photo varchar (255)  ,

	@ProductId uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Update
(

	@Id uniqueidentifier   ,

	@OriginalId uniqueidentifier   ,

	@Name varchar (255)  ,

	@Description varchar (255)  ,

	@Price float   ,

	@Currency varchar (255)  ,

	@Photo varchar (255)  ,

	@ProductId uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Delete
(

	@Id uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Item table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByProductId
(

	@ProductId uniqueidentifier   
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
				
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Item table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetById
(

	@Id uniqueidentifier   
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
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetBySuppIdFromInventory procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetBySuppIdFromInventory') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetBySuppIdFromInventory
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetBySuppIdFromInventory
(

	@SuppId uniqueidentifier   
)
AS


SELECT dbo.[Item].[Id]
       ,dbo.[Item].[Name]
       ,dbo.[Item].[Description]
       ,dbo.[Item].[Price]
       ,dbo.[Item].[Currency]
       ,dbo.[Item].[Photo]
       ,dbo.[Item].[ProductId]
       ,dbo.[Item].[Timestamp]
  FROM dbo.[Item]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[Inventory] 
                WHERE dbo.[Inventory].[SuppId] = @SuppId
                  AND dbo.[Inventory].[ItemId] = dbo.[Item].[Id]
                  )
				Select @@ROWCOUNT			
				

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the Item table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Find
(

	@SearchUsingOR bit   = null ,

	@Id uniqueidentifier   = null ,

	@Name varchar (255)  = null ,

	@Description varchar (255)  = null ,

	@Price float   = null ,

	@Currency varchar (255)  = null ,

	@Photo varchar (255)  = null ,

	@ProductId uniqueidentifier   = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
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
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
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
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([Price] = @Price AND @Price is not null)
	OR ([Currency] = @Currency AND @Currency is not null)
	OR ([Photo] = @Photo AND @Photo is not null)
	OR ([ProductId] = @ProductId AND @ProductId is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					[UnitPrice],
					[Timestamp]
				FROM
					dbo.[LineItem]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderId]'
				SET @SQL = @SQL + ', [LineNum]'
				SET @SQL = @SQL + ', [ItemId]'
				SET @SQL = @SQL + ', [Quantity]'
				SET @SQL = @SQL + ', [UnitPrice]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[LineItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderId],'
				SET @SQL = @SQL + ' [LineNum],'
				SET @SQL = @SQL + ' [ItemId],'
				SET @SQL = @SQL + ' [Quantity],'
				SET @SQL = @SQL + ' [UnitPrice],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[LineItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the LineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Insert
(

	@OrderId int   ,

	@LineNum int   ,

	@ItemId uniqueidentifier   ,

	@Quantity int   ,

	@UnitPrice money   ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[LineItem]
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
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[LineItem]
				WHERE
[OrderId] = @OrderId 
AND [LineNum] = @LineNum 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the LineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Update
(

	@OrderId int   ,

	@OriginalOrderId int   ,

	@LineNum int   ,

	@OriginalLineNum int   ,

	@ItemId uniqueidentifier   ,

	@Quantity int   ,

	@UnitPrice money   ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[LineItem]
				SET
					[OrderId] = @OrderId
					,[LineNum] = @LineNum
					,[ItemId] = @ItemId
					,[Quantity] = @Quantity
					,[UnitPrice] = @UnitPrice
				WHERE
[OrderId] = @OriginalOrderId 
AND [LineNum] = @OriginalLineNum 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[LineItem]
				WHERE
[OrderId] = @OrderId 
AND [LineNum] = @LineNum 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the LineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Delete
(

	@OrderId int   ,

	@LineNum int   ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[LineItem] WITH (ROWLOCK) 
				WHERE
					[OrderId] = @OrderId
					AND [LineNum] = @LineNum
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the LineItem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_GetByOrderId
(

	@OrderId int   
)
AS


				
				SELECT
					[OrderId],
					[LineNum],
					[ItemId],
					[Quantity],
					[UnitPrice],
					[Timestamp]
				FROM
					dbo.[LineItem]
				WHERE
					[OrderId] = @OrderId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the LineItem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_GetByItemId
(

	@ItemId uniqueidentifier   
)
AS


				
				SELECT
					[OrderId],
					[LineNum],
					[ItemId],
					[Quantity],
					[UnitPrice],
					[Timestamp]
				FROM
					dbo.[LineItem]
				WHERE
					[ItemId] = @ItemId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_GetByLineNumOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_GetByLineNumOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_GetByLineNumOrderId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the LineItem table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_GetByLineNumOrderId
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
					[UnitPrice],
					[Timestamp]
				FROM
					dbo.[LineItem]
				WHERE
					[OrderId] = @OrderId
					AND [LineNum] = @LineNum
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LineItem_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LineItem_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LineItem_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the LineItem table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LineItem_Find
(

	@SearchUsingOR bit   = null ,

	@OrderId int   = null ,

	@LineNum int   = null ,

	@ItemId uniqueidentifier   = null ,

	@Quantity int   = null ,

	@UnitPrice money   = null ,

	@Timestamp timestamp   = null 
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
	, [Timestamp]
    FROM
	dbo.[LineItem]
    WHERE 
	 ([OrderId] = @OrderId OR @OrderId is null)
	AND ([LineNum] = @LineNum OR @LineNum is null)
	AND ([ItemId] = @ItemId OR @ItemId is null)
	AND ([Quantity] = @Quantity OR @Quantity is null)
	AND ([UnitPrice] = @UnitPrice OR @UnitPrice is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderId]
	, [LineNum]
	, [ItemId]
	, [Quantity]
	, [UnitPrice]
	, [Timestamp]
    FROM
	dbo.[LineItem]
    WHERE 
	 ([OrderId] = @OrderId AND @OrderId is not null)
	OR ([LineNum] = @LineNum AND @LineNum is not null)
	OR ([ItemId] = @ItemId AND @ItemId is not null)
	OR ([Quantity] = @Quantity AND @Quantity is not null)
	OR ([UnitPrice] = @UnitPrice AND @UnitPrice is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets all records from the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Get_List

AS


				
				SELECT
					[OrderId],
					[AccountId],
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
					[CourierId],
					[TotalPrice],
					[BillToFirstName],
					[BillToLastName],
					[ShipToFirstName],
					[ShipToLastName],
					[CreditCardId],
					[Locale],
					[Timestamp]
				FROM
					dbo.[Orders]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderId]'
				SET @SQL = @SQL + ', [AccountId]'
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
				SET @SQL = @SQL + ', [CourierId]'
				SET @SQL = @SQL + ', [TotalPrice]'
				SET @SQL = @SQL + ', [BillToFirstName]'
				SET @SQL = @SQL + ', [BillToLastName]'
				SET @SQL = @SQL + ', [ShipToFirstName]'
				SET @SQL = @SQL + ', [ShipToLastName]'
				SET @SQL = @SQL + ', [CreditCardId]'
				SET @SQL = @SQL + ', [Locale]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[Orders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderId],'
				SET @SQL = @SQL + ' [AccountId],'
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
				SET @SQL = @SQL + ' [CourierId],'
				SET @SQL = @SQL + ' [TotalPrice],'
				SET @SQL = @SQL + ' [BillToFirstName],'
				SET @SQL = @SQL + ' [BillToLastName],'
				SET @SQL = @SQL + ' [ShipToFirstName],'
				SET @SQL = @SQL + ' [ShipToLastName],'
				SET @SQL = @SQL + ' [CreditCardId],'
				SET @SQL = @SQL + ' [Locale],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[Orders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Insert
(

	@OrderId int    OUTPUT,

	@AccountId uniqueidentifier   ,

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

	@CourierId uniqueidentifier   ,

	@TotalPrice decimal (10, 2)  ,

	@BillToFirstName varchar (80)  ,

	@BillToLastName varchar (80)  ,

	@ShipToFirstName varchar (80)  ,

	@ShipToLastName varchar (80)  ,

	@CreditCardId uniqueidentifier   ,

	@Locale varchar (20)  ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[Orders]
					(
					[AccountId]
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
					,[CourierId]
					,[TotalPrice]
					,[BillToFirstName]
					,[BillToLastName]
					,[ShipToFirstName]
					,[ShipToLastName]
					,[CreditCardId]
					,[Locale]
					)
				VALUES
					(
					@AccountId
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
					,@CourierId
					,@TotalPrice
					,@BillToFirstName
					,@BillToLastName
					,@ShipToFirstName
					,@ShipToLastName
					,@CreditCardId
					,@Locale
					)
				
				-- Get the identity value
				SET @OrderId = SCOPE_IDENTITY()
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[Orders]
				WHERE
[OrderId] = @OrderId 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Update
(

	@OrderId int   ,

	@AccountId uniqueidentifier   ,

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

	@CourierId uniqueidentifier   ,

	@TotalPrice decimal (10, 2)  ,

	@BillToFirstName varchar (80)  ,

	@BillToLastName varchar (80)  ,

	@ShipToFirstName varchar (80)  ,

	@ShipToLastName varchar (80)  ,

	@CreditCardId uniqueidentifier   ,

	@Locale varchar (20)  ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[Orders]
				SET
					[AccountId] = @AccountId
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
					,[CourierId] = @CourierId
					,[TotalPrice] = @TotalPrice
					,[BillToFirstName] = @BillToFirstName
					,[BillToLastName] = @BillToLastName
					,[ShipToFirstName] = @ShipToFirstName
					,[ShipToLastName] = @ShipToLastName
					,[CreditCardId] = @CreditCardId
					,[Locale] = @Locale
				WHERE
[OrderId] = @OrderId 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[Orders]
				WHERE
[OrderId] = @OrderId 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Delete
(

	@OrderId int   ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[Orders] WITH (ROWLOCK) 
				WHERE
					[OrderId] = @OrderId
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByAccountId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByAccountId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByAccountId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Orders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByAccountId
(

	@AccountId uniqueidentifier   
)
AS


				
				SELECT
					[OrderId],
					[AccountId],
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
					[CourierId],
					[TotalPrice],
					[BillToFirstName],
					[BillToLastName],
					[ShipToFirstName],
					[ShipToLastName],
					[CreditCardId],
					[Locale],
					[Timestamp]
				FROM
					dbo.[Orders]
				WHERE
					[AccountId] = @AccountId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByCourierId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByCourierId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByCourierId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Orders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByCourierId
(

	@CourierId uniqueidentifier   
)
AS


				
				SELECT
					[OrderId],
					[AccountId],
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
					[CourierId],
					[TotalPrice],
					[BillToFirstName],
					[BillToLastName],
					[ShipToFirstName],
					[ShipToLastName],
					[CreditCardId],
					[Locale],
					[Timestamp]
				FROM
					dbo.[Orders]
				WHERE
					[CourierId] = @CourierId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByCreditCardId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByCreditCardId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByCreditCardId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Orders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByCreditCardId
(

	@CreditCardId uniqueidentifier   
)
AS


				
				SELECT
					[OrderId],
					[AccountId],
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
					[CourierId],
					[TotalPrice],
					[BillToFirstName],
					[BillToLastName],
					[ShipToFirstName],
					[ShipToLastName],
					[CreditCardId],
					[Locale],
					[Timestamp]
				FROM
					dbo.[Orders]
				WHERE
					[CreditCardId] = @CreditCardId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					[AccountId],
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
					[CourierId],
					[TotalPrice],
					[BillToFirstName],
					[BillToLastName],
					[ShipToFirstName],
					[ShipToLastName],
					[CreditCardId],
					[Locale],
					[Timestamp]
				FROM
					dbo.[Orders]
				WHERE
					[OrderId] = @OrderId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the Orders table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Find
(

	@SearchUsingOR bit   = null ,

	@OrderId int   = null ,

	@AccountId uniqueidentifier   = null ,

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

	@CourierId uniqueidentifier   = null ,

	@TotalPrice decimal (10, 2)  = null ,

	@BillToFirstName varchar (80)  = null ,

	@BillToLastName varchar (80)  = null ,

	@ShipToFirstName varchar (80)  = null ,

	@ShipToLastName varchar (80)  = null ,

	@CreditCardId uniqueidentifier   = null ,

	@Locale varchar (20)  = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderId]
	, [AccountId]
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
	, [CourierId]
	, [TotalPrice]
	, [BillToFirstName]
	, [BillToLastName]
	, [ShipToFirstName]
	, [ShipToLastName]
	, [CreditCardId]
	, [Locale]
	, [Timestamp]
    FROM
	dbo.[Orders]
    WHERE 
	 ([OrderId] = @OrderId OR @OrderId is null)
	AND ([AccountId] = @AccountId OR @AccountId is null)
	AND ([OrderDate] = @OrderDate OR @OrderDate is null)
	AND ([ShipAddr1] = @ShipAddr1 OR @ShipAddr1 is null)
	AND ([ShipAddr2] = @ShipAddr2 OR @ShipAddr2 is null)
	AND ([ShipCity] = @ShipCity OR @ShipCity is null)
	AND ([ShipState] = @ShipState OR @ShipState is null)
	AND ([ShipZip] = @ShipZip OR @ShipZip is null)
	AND ([ShipCountry] = @ShipCountry OR @ShipCountry is null)
	AND ([BillAddr1] = @BillAddr1 OR @BillAddr1 is null)
	AND ([BillAddr2] = @BillAddr2 OR @BillAddr2 is null)
	AND ([BillCity] = @BillCity OR @BillCity is null)
	AND ([BillState] = @BillState OR @BillState is null)
	AND ([BillZip] = @BillZip OR @BillZip is null)
	AND ([BillCountry] = @BillCountry OR @BillCountry is null)
	AND ([CourierId] = @CourierId OR @CourierId is null)
	AND ([TotalPrice] = @TotalPrice OR @TotalPrice is null)
	AND ([BillToFirstName] = @BillToFirstName OR @BillToFirstName is null)
	AND ([BillToLastName] = @BillToLastName OR @BillToLastName is null)
	AND ([ShipToFirstName] = @ShipToFirstName OR @ShipToFirstName is null)
	AND ([ShipToLastName] = @ShipToLastName OR @ShipToLastName is null)
	AND ([CreditCardId] = @CreditCardId OR @CreditCardId is null)
	AND ([Locale] = @Locale OR @Locale is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderId]
	, [AccountId]
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
	, [CourierId]
	, [TotalPrice]
	, [BillToFirstName]
	, [BillToLastName]
	, [ShipToFirstName]
	, [ShipToLastName]
	, [CreditCardId]
	, [Locale]
	, [Timestamp]
    FROM
	dbo.[Orders]
    WHERE 
	 ([OrderId] = @OrderId AND @OrderId is not null)
	OR ([AccountId] = @AccountId AND @AccountId is not null)
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
	OR ([CourierId] = @CourierId AND @CourierId is not null)
	OR ([TotalPrice] = @TotalPrice AND @TotalPrice is not null)
	OR ([BillToFirstName] = @BillToFirstName AND @BillToFirstName is not null)
	OR ([BillToLastName] = @BillToLastName AND @BillToLastName is not null)
	OR ([ShipToFirstName] = @ShipToFirstName AND @ShipToFirstName is not null)
	OR ([ShipToLastName] = @ShipToLastName AND @ShipToLastName is not null)
	OR ([CreditCardId] = @CreditCardId AND @CreditCardId is not null)
	OR ([Locale] = @Locale AND @Locale is not null)
	Select @@ROWCOUNT			
  END
				

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets all records from the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Get_List

AS


				
				SELECT
					[OrderId],
					[LineNum],
					[OrderDate],
					[OrderStatusId],
					[Timestamp]
				FROM
					dbo.[OrderStatus]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderId]'
				SET @SQL = @SQL + ', [LineNum]'
				SET @SQL = @SQL + ', [OrderDate]'
				SET @SQL = @SQL + ', [OrderStatusId]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[OrderStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderId],'
				SET @SQL = @SQL + ' [LineNum],'
				SET @SQL = @SQL + ' [OrderDate],'
				SET @SQL = @SQL + ' [OrderStatusId],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[OrderStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Insert
(

	@OrderId int   ,

	@LineNum int   ,

	@OrderDate datetime   ,

	@OrderStatusId int   ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[OrderStatus]
					(
					[OrderId]
					,[LineNum]
					,[OrderDate]
					,[OrderStatusId]
					)
				VALUES
					(
					@OrderId
					,@LineNum
					,@OrderDate
					,@OrderStatusId
					)
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[OrderStatus]
				WHERE
[OrderId] = @OrderId 
AND [LineNum] = @LineNum 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Update
(

	@OrderId int   ,

	@OriginalOrderId int   ,

	@LineNum int   ,

	@OriginalLineNum int   ,

	@OrderDate datetime   ,

	@OrderStatusId int   ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[OrderStatus]
				SET
					[OrderId] = @OrderId
					,[LineNum] = @LineNum
					,[OrderDate] = @OrderDate
					,[OrderStatusId] = @OrderStatusId
				WHERE
[OrderId] = @OriginalOrderId 
AND [LineNum] = @OriginalLineNum 
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[OrderStatus]
				WHERE
[OrderId] = @OrderId 
AND [LineNum] = @LineNum 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Delete
(

	@OrderId int   ,

	@LineNum int   ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[OrderStatus] WITH (ROWLOCK) 
				WHERE
					[OrderId] = @OrderId
					AND [LineNum] = @LineNum
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the OrderStatus table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_GetByOrderId
(

	@OrderId int   
)
AS


				
				SELECT
					[OrderId],
					[LineNum],
					[OrderDate],
					[OrderStatusId],
					[Timestamp]
				FROM
					dbo.[OrderStatus]
				WHERE
					[OrderId] = @OrderId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetByOrderStatusId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetByOrderStatusId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetByOrderStatusId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the OrderStatus table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_GetByOrderStatusId
(

	@OrderStatusId int   
)
AS


				
				SELECT
					[OrderId],
					[LineNum],
					[OrderDate],
					[OrderStatusId],
					[Timestamp]
				FROM
					dbo.[OrderStatus]
				WHERE
					[OrderStatusId] = @OrderStatusId
				
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetByLineNumOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetByLineNumOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetByLineNumOrderId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the OrderStatus table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_GetByLineNumOrderId
(

	@OrderId int   ,

	@LineNum int   
)
AS


				SELECT
					[OrderId],
					[LineNum],
					[OrderDate],
					[OrderStatusId],
					[Timestamp]
				FROM
					dbo.[OrderStatus]
				WHERE
					[OrderId] = @OrderId
					AND [LineNum] = @LineNum
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the OrderStatus table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Find
(

	@SearchUsingOR bit   = null ,

	@OrderId int   = null ,

	@LineNum int   = null ,

	@OrderDate datetime   = null ,

	@OrderStatusId int   = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderId]
	, [LineNum]
	, [OrderDate]
	, [OrderStatusId]
	, [Timestamp]
    FROM
	dbo.[OrderStatus]
    WHERE 
	 ([OrderId] = @OrderId OR @OrderId is null)
	AND ([LineNum] = @LineNum OR @LineNum is null)
	AND ([OrderDate] = @OrderDate OR @OrderDate is null)
	AND ([OrderStatusId] = @OrderStatusId OR @OrderStatusId is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderId]
	, [LineNum]
	, [OrderDate]
	, [OrderStatusId]
	, [Timestamp]
    FROM
	dbo.[OrderStatus]
    WHERE 
	 ([OrderId] = @OrderId AND @OrderId is not null)
	OR ([LineNum] = @LineNum AND @LineNum is not null)
	OR ([OrderDate] = @OrderDate AND @OrderDate is not null)
	OR ([OrderStatusId] = @OrderStatusId AND @OrderStatusId is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatusType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatusType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatusType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets all records from the OrderStatusType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatusType_Get_List

AS


				
				SELECT
					[OrderStatusId],
					[OrderStatus],
					[OrderStatusDescription]
				FROM
					dbo.[OrderStatusType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatusType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatusType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatusType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets records from the OrderStatusType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatusType_GetPaged
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderStatusId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderStatusId]'
				SET @SQL = @SQL + ', [OrderStatus]'
				SET @SQL = @SQL + ', [OrderStatusDescription]'
				SET @SQL = @SQL + ' FROM dbo.[OrderStatusType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderStatusId],'
				SET @SQL = @SQL + ' [OrderStatus],'
				SET @SQL = @SQL + ' [OrderStatusDescription]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[OrderStatusType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatusType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatusType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatusType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the OrderStatusType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatusType_Insert
(

	@OrderStatusId int    OUTPUT,

	@OrderStatus varchar (24)  ,

	@OrderStatusDescription varchar (300)  
)
AS


					
				INSERT INTO dbo.[OrderStatusType]
					(
					[OrderStatus]
					,[OrderStatusDescription]
					)
				VALUES
					(
					@OrderStatus
					,@OrderStatusDescription
					)
				
				-- Get the identity value
				SET @OrderStatusId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatusType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatusType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatusType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the OrderStatusType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatusType_Update
(

	@OrderStatusId int   ,

	@OrderStatus varchar (24)  ,

	@OrderStatusDescription varchar (300)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[OrderStatusType]
				SET
					[OrderStatus] = @OrderStatus
					,[OrderStatusDescription] = @OrderStatusDescription
				WHERE
[OrderStatusId] = @OrderStatusId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatusType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatusType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatusType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the OrderStatusType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatusType_Delete
(

	@OrderStatusId int   
)
AS


				DELETE FROM dbo.[OrderStatusType] WITH (ROWLOCK) 
				WHERE
					[OrderStatusId] = @OrderStatusId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatusType_GetByOrderStatusId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatusType_GetByOrderStatusId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatusType_GetByOrderStatusId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the OrderStatusType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatusType_GetByOrderStatusId
(

	@OrderStatusId int   
)
AS


				SELECT
					[OrderStatusId],
					[OrderStatus],
					[OrderStatusDescription]
				FROM
					dbo.[OrderStatusType]
				WHERE
					[OrderStatusId] = @OrderStatusId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatusType_GetByOrderStatus procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatusType_GetByOrderStatus') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatusType_GetByOrderStatus
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the OrderStatusType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatusType_GetByOrderStatus
(

	@OrderStatus varchar (24)  
)
AS


				SELECT
					[OrderStatusId],
					[OrderStatus],
					[OrderStatusDescription]
				FROM
					dbo.[OrderStatusType]
				WHERE
					[OrderStatus] = @OrderStatus
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatusType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatusType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatusType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the OrderStatusType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatusType_Find
(

	@SearchUsingOR bit   = null ,

	@OrderStatusId int   = null ,

	@OrderStatus varchar (24)  = null ,

	@OrderStatusDescription varchar (300)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderStatusId]
	, [OrderStatus]
	, [OrderStatusDescription]
    FROM
	dbo.[OrderStatusType]
    WHERE 
	 ([OrderStatusId] = @OrderStatusId OR @OrderStatusId is null)
	AND ([OrderStatus] = @OrderStatus OR @OrderStatus is null)
	AND ([OrderStatusDescription] = @OrderStatusDescription OR @OrderStatusDescription is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderStatusId]
	, [OrderStatus]
	, [OrderStatusDescription]
    FROM
	dbo.[OrderStatusType]
    WHERE 
	 ([OrderStatusId] = @OrderStatusId AND @OrderStatusId is not null)
	OR ([OrderStatus] = @OrderStatus AND @OrderStatus is not null)
	OR ([OrderStatusDescription] = @OrderStatusDescription AND @OrderStatusDescription is not null)
	Select @@ROWCOUNT			
  END
				

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [CategoryId]'
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[Product]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [CategoryId],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[Product]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Insert
(

	@Id uniqueidentifier   ,

	@Name varchar (255)  ,

	@Description varchar (255)  ,

	@CategoryId uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Update
(

	@Id uniqueidentifier   ,

	@OriginalId uniqueidentifier   ,

	@Name varchar (255)  ,

	@Description varchar (255)  ,

	@CategoryId uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the Product table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Delete
(

	@Id uniqueidentifier   ,

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Product table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetByCategoryId
(

	@CategoryId uniqueidentifier   
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
				
				Select @@ROWCOUNT
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Product table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_GetById
(

	@Id uniqueidentifier   
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
			Select @@ROWCOUNT
					
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the Product table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Product_Find
(

	@SearchUsingOR bit   = null ,

	@Id uniqueidentifier   = null ,

	@Name varchar (255)  = null ,

	@Description varchar (255)  = null ,

	@CategoryId uniqueidentifier   = null ,

	@Timestamp timestamp   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
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
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Description]
	, [CategoryId]
	, [Timestamp]
    FROM
	dbo.[Product]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([CategoryId] = @CategoryId AND @CategoryId is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					[Phone],
					[Timestamp]
				FROM
					dbo.[Supplier]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SuppId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
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
				SET @SQL = @SQL + ', [Timestamp]'
				SET @SQL = @SQL + ' FROM dbo.[Supplier]'
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
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Timestamp]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[Supplier]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Inserts a record into the Supplier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Insert
(

	@SuppId uniqueidentifier   ,

	@Name varchar (80)  ,

	@Status varchar (2)  ,

	@Addr1 varchar (80)  ,

	@Addr2 varchar (80)  ,

	@City varchar (80)  ,

	@State varchar (80)  ,

	@Zip varchar (5)  ,

	@Phone varchar (40)  ,

	@Timestamp timestamp    OUTPUT
)
AS


					
				INSERT INTO dbo.[Supplier]
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
				
									
				-- Select computed columns into output parameters
				SELECT
 @Timestamp = [Timestamp]
				FROM
					dbo.[Supplier]
				WHERE
[SuppId] = @SuppId 
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Updates a record in the Supplier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Update
(

	@SuppId uniqueidentifier   ,

	@OriginalSuppId uniqueidentifier   ,

	@Name varchar (80)  ,

	@Status varchar (2)  ,

	@Addr1 varchar (80)  ,

	@Addr2 varchar (80)  ,

	@City varchar (80)  ,

	@State varchar (80)  ,

	@Zip varchar (5)  ,

	@Phone varchar (40)  ,

	@Timestamp timestamp   ,

	@ReturnedTimestamp timestamp    OUTPUT
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[Supplier]
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
AND [Timestamp] = @Timestamp				
				
				-- Select computed columns into output parameters
				SELECT
 @ReturnedTimestamp = [Timestamp]
				FROM
					dbo.[Supplier]
				WHERE
[SuppId] = @SuppId 
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Deletes a record in the Supplier table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Delete
(

	@SuppId uniqueidentifier   ,

	@Timestamp timestamp   
)
AS


				DELETE FROM dbo.[Supplier] WITH (ROWLOCK) 
				WHERE
					[SuppId] = @SuppId
	AND [Timestamp] = @Timestamp					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_GetBySuppId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_GetBySuppId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_GetBySuppId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Select records from the Supplier table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_GetBySuppId
(

	@SuppId uniqueidentifier   
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
					[Phone],
					[Timestamp]
				FROM
					dbo.[Supplier]
				WHERE
					[SuppId] = @SuppId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_GetByItemIdFromInventory procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_GetByItemIdFromInventory') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_GetByItemIdFromInventory
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_GetByItemIdFromInventory
(

	@ItemId uniqueidentifier   
)
AS


SELECT dbo.[Supplier].[SuppId]
       ,dbo.[Supplier].[Name]
       ,dbo.[Supplier].[Status]
       ,dbo.[Supplier].[Addr1]
       ,dbo.[Supplier].[Addr2]
       ,dbo.[Supplier].[City]
       ,dbo.[Supplier].[State]
       ,dbo.[Supplier].[Zip]
       ,dbo.[Supplier].[Phone]
       ,dbo.[Supplier].[Timestamp]
  FROM dbo.[Supplier]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[Inventory] 
                WHERE dbo.[Inventory].[ItemId] = @ItemId
                  AND dbo.[Inventory].[SuppId] = dbo.[Supplier].[SuppId]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Supplier_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Supplier_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Supplier_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Finds records in the Supplier table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Supplier_Find
(

	@SearchUsingOR bit   = null ,

	@SuppId uniqueidentifier   = null ,

	@Name varchar (80)  = null ,

	@Status varchar (2)  = null ,

	@Addr1 varchar (80)  = null ,

	@Addr2 varchar (80)  = null ,

	@City varchar (80)  = null ,

	@State varchar (80)  = null ,

	@Zip varchar (5)  = null ,

	@Phone varchar (40)  = null ,

	@Timestamp timestamp   = null 
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
	, [Timestamp]
    FROM
	dbo.[Supplier]
    WHERE 
	 ([SuppId] = @SuppId OR @SuppId is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([Status] = @Status OR @Status is null)
	AND ([Addr1] = @Addr1 OR @Addr1 is null)
	AND ([Addr2] = @Addr2 OR @Addr2 is null)
	AND ([City] = @City OR @City is null)
	AND ([State] = @State OR @State is null)
	AND ([Zip] = @Zip OR @Zip is null)
	AND ([Phone] = @Phone OR @Phone is null)
						
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
	, [Timestamp]
    FROM
	dbo.[Supplier]
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
	Select @@ROWCOUNT			
  END
				

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
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
					
				Select @@ROWCOUNT			
			

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
-- Date Created: Monday, July 24, 2006

-- Created By: NetTiers (www.nettiers.com)
-- Purpose: Gets records from the ExtendedItem view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ExtendedItem_Get
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

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ItemId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ItemId]'
				SET @SQL = @SQL + ', [ItemName]'
				SET @SQL = @SQL + ', [ItemDescription]'
				SET @SQL = @SQL + ', [ItemPrice]'
				SET @SQL = @SQL + ', [ItemPhoto]'
				SET @SQL = @SQL + ', [ProductId]'
				SET @SQL = @SQL + ', [ProductName]'
				SET @SQL = @SQL + ', [ProductDescription]'
				SET @SQL = @SQL + ', [CategoryId]'
				SET @SQL = @SQL + ', [CategoryName]'
				SET @SQL = @SQL + ' FROM dbo.[ExtendedItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ItemId],'
				SET @SQL = @SQL + ' [ItemName],'
				SET @SQL = @SQL + ' [ItemDescription],'
				SET @SQL = @SQL + ' [ItemPrice],'
				SET @SQL = @SQL + ' [ItemPhoto],'
				SET @SQL = @SQL + ' [ProductId],'
				SET @SQL = @SQL + ' [ProductName],'
				SET @SQL = @SQL + ' [ProductDescription],'
				SET @SQL = @SQL + ' [CategoryId],'
				SET @SQL = @SQL + ' [CategoryName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL

				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ExtendedItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
				
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

