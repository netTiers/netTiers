<%@ WebService Language="C#" Class="petshopServices" %>
<%@ Assembly Name="netTiers.Petshop.Entities" %>
<%@ Assembly Name="netTiers.Petshop.Data" %>
<%@ Assembly Name="netTiers.Petshop.Data.SqlClient" %>


using System;
using System.Data;
using System.Web.Services;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.SqlClient;



/// <summary>
///	Exposes CRUD webmethods for the petshopServices Database.
/// </summary>
[WebService(Namespace="http://localhost/PetshopServices", Description="Exposes CRUD webmethods for the petshopServices Database.")]
public class petshopServices : WebService 
{

	
	#region "Get from  Many To Many Relationship Functions"
	#endregion	
	
	#region "Delete Functions"
	
		
	/// <summary>
	/// 	Deletes a row from the DataSource.
	/// </summary>
	/// <param name="Id">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table Account.")]
	public bool AccountProvider_Delete(System.String id, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.Delete(id, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Account with additional query text.")]
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.Find(null, whereClause, start, pageLength, out count);
	}
	
	#endregion "Find Functions"
	
	
	#region "GetList Functions"
		
	/// <summary>
	/// 	Gets All rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <returns>Returns a <s>DataSet</s>.</returns>
	[WebMethod(Description="Get all rows from the table Account.")]
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetAll(start, pageLength, out count);		
	}
	
	#endregion
	
	#region "Get Paged"
	
	/// <summary>
	/// Gets a page of rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
	/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of petshopServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Account.")]
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Account_CreditCard key.
	///		FK_Account_CreditCard Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="CreditCardId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Account filtered by the CreditCardId column.")]
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_GetByCreditCardId(System.String creditCardId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetByCreditCardId(creditCardId, start, pageLength, out count);
	}
	
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Account_Category key.
	///		FK_Account_Category Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="FavoriteCategoryId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Account filtered by the FavoriteCategoryId column.")]
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_GetByFavoriteCategoryId(System.String favoriteCategoryId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetByFavoriteCategoryId(favoriteCategoryId, start, pageLength, out count);
	}
	
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK_Account index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="Id"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Account filtered by the column Id that is part of the PK_Account index.")]
	public netTiers.Petshop.Entities.Account AccountProvider_GetById(System.String id, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetById(id, start, pageLength, out count);
	}
	

	
	/// <summary>
	/// 	Gets rows from the datasource based on the IX_Account index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="Login"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Account filtered by the column Login that is part of the IX_Account index.")]
	public netTiers.Petshop.Entities.Account AccountProvider_GetByLogin(System.String login, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetByLogin(login, start, pageLength, out count);
	}
	

	
	/// <summary>
	/// 	Gets rows from the datasource based on the IX_Account_LastName index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="LastName"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Account filtered by the column LastName that is part of the IX_Account_LastName index.")]
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_GetByLastName(System.String lastName, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetByLastName(lastName, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table Account.")]
	public netTiers.Petshop.Entities.Account AccountProvider_Insert(netTiers.Petshop.Entities.Account entity )
	{
		netTiers.Petshop.Data.DataRepository.AccountProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<Account> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<Account> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.Account object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table Account.")]
	public void AccountProvider_BulkInsert(netTiers.Petshop.Entities.TList<Account> entityList )
	{
		netTiers.Petshop.Data.DataRepository.AccountProvider.BulkInsert(entityList);
	}
	#endregion "Insert Functions"
			
	#region "Update Functions"
		
	/// <summary>
	/// 	Update an existing row in the datasource.
	/// </summary>
	/// <param name="entity"> object to update.</param>
	/// <remarks>After updating the datasource, the object will be updated
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Update a row in the table Account.")]
	public netTiers.Petshop.Entities.Account AccountProvider_Update(netTiers.Petshop.Entities.Account entity)
	{
		netTiers.Petshop.Data.DataRepository.AccountProvider.Update(entity);
		return entity;
	}

	#endregion "Update Functions"

	#region Custom Methods
	
	
	#endregion


	
	#region "Get from  Many To Many Relationship Functions"
	#endregion	
	
	#region "Delete Functions"
	
		
	/// <summary>
	/// 	Deletes a row from the DataSource.
	/// </summary>
	/// <param name="Id">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table Category.")]
	public bool CategoryProvider_Delete(System.String id, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.CategoryProvider.Delete(id, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Category with additional query text.")]
	public netTiers.Petshop.Entities.TList<Category> CategoryProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CategoryProvider.Find(null, whereClause, start, pageLength, out count);
	}
	
	#endregion "Find Functions"
	
	
	#region "GetList Functions"
		
	/// <summary>
	/// 	Gets All rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <returns>Returns a <s>DataSet</s>.</returns>
	[WebMethod(Description="Get all rows from the table Category.")]
	public netTiers.Petshop.Entities.TList<Category> CategoryProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CategoryProvider.GetAll(start, pageLength, out count);		
	}
	
	#endregion
	
	#region "Get Paged"
	
	/// <summary>
	/// Gets a page of rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
	/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of petshopServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Category.")]
	public netTiers.Petshop.Entities.TList<Category> CategoryProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CategoryProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK_Category index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="Id"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Category filtered by the column Id that is part of the PK_Category index.")]
	public netTiers.Petshop.Entities.Category CategoryProvider_GetById(System.String id, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CategoryProvider.GetById(id, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table Category.")]
	public netTiers.Petshop.Entities.Category CategoryProvider_Insert(netTiers.Petshop.Entities.Category entity )
	{
		netTiers.Petshop.Data.DataRepository.CategoryProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<Category> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<Category> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.Category object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table Category.")]
	public void CategoryProvider_BulkInsert(netTiers.Petshop.Entities.TList<Category> entityList )
	{
		netTiers.Petshop.Data.DataRepository.CategoryProvider.BulkInsert(entityList);
	}
	#endregion "Insert Functions"
			
	#region "Update Functions"
		
	/// <summary>
	/// 	Update an existing row in the datasource.
	/// </summary>
	/// <param name="entity"> object to update.</param>
	/// <remarks>After updating the datasource, the object will be updated
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Update a row in the table Category.")]
	public netTiers.Petshop.Entities.Category CategoryProvider_Update(netTiers.Petshop.Entities.Category entity)
	{
		netTiers.Petshop.Data.DataRepository.CategoryProvider.Update(entity);
		return entity;
	}

	#endregion "Update Functions"

	#region Custom Methods
	
	
	#endregion


	
	#region "Get from  Many To Many Relationship Functions"
	#endregion	
	
	#region "Delete Functions"
	
		
	/// <summary>
	/// 	Deletes a row from the DataSource.
	/// </summary>
	/// <param name="Id">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table CreditCard.")]
	public bool CreditCardProvider_Delete(System.String id, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.CreditCardProvider.Delete(id, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table CreditCard with additional query text.")]
	public netTiers.Petshop.Entities.TList<CreditCard> CreditCardProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CreditCardProvider.Find(null, whereClause, start, pageLength, out count);
	}
	
	#endregion "Find Functions"
	
	
	#region "GetList Functions"
		
	/// <summary>
	/// 	Gets All rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <returns>Returns a <s>DataSet</s>.</returns>
	[WebMethod(Description="Get all rows from the table CreditCard.")]
	public netTiers.Petshop.Entities.TList<CreditCard> CreditCardProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CreditCardProvider.GetAll(start, pageLength, out count);		
	}
	
	#endregion
	
	#region "Get Paged"
	
	/// <summary>
	/// Gets a page of rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
	/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of petshopServices objects.</returns>
	[WebMethod(Description="Get all rows from the table CreditCard.")]
	public netTiers.Petshop.Entities.TList<CreditCard> CreditCardProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CreditCardProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK_CreditCard index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="Id"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table CreditCard filtered by the column Id that is part of the PK_CreditCard index.")]
	public netTiers.Petshop.Entities.CreditCard CreditCardProvider_GetById(System.String id, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CreditCardProvider.GetById(id, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table CreditCard.")]
	public netTiers.Petshop.Entities.CreditCard CreditCardProvider_Insert(netTiers.Petshop.Entities.CreditCard entity )
	{
		netTiers.Petshop.Data.DataRepository.CreditCardProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<CreditCard> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<CreditCard> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.CreditCard object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table CreditCard.")]
	public void CreditCardProvider_BulkInsert(netTiers.Petshop.Entities.TList<CreditCard> entityList )
	{
		netTiers.Petshop.Data.DataRepository.CreditCardProvider.BulkInsert(entityList);
	}
	#endregion "Insert Functions"
			
	#region "Update Functions"
		
	/// <summary>
	/// 	Update an existing row in the datasource.
	/// </summary>
	/// <param name="entity"> object to update.</param>
	/// <remarks>After updating the datasource, the object will be updated
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Update a row in the table CreditCard.")]
	public netTiers.Petshop.Entities.CreditCard CreditCardProvider_Update(netTiers.Petshop.Entities.CreditCard entity)
	{
		netTiers.Petshop.Data.DataRepository.CreditCardProvider.Update(entity);
		return entity;
	}

	#endregion "Update Functions"

	#region Custom Methods
	
	
	#endregion


	
	#region "Get from  Many To Many Relationship Functions"
	#endregion	
	
	#region "Delete Functions"
	
		
	/// <summary>
	/// 	Deletes a row from the DataSource.
	/// </summary>
	/// <param name="Id">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table Item.")]
	public bool ItemProvider_Delete(System.String id, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.ItemProvider.Delete(id, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Item with additional query text.")]
	public netTiers.Petshop.Entities.TList<Item> ItemProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ItemProvider.Find(null, whereClause, start, pageLength, out count);
	}
	
	#endregion "Find Functions"
	
	
	#region "GetList Functions"
		
	/// <summary>
	/// 	Gets All rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <returns>Returns a <s>DataSet</s>.</returns>
	[WebMethod(Description="Get all rows from the table Item.")]
	public netTiers.Petshop.Entities.TList<Item> ItemProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ItemProvider.GetAll(start, pageLength, out count);		
	}
	
	#endregion
	
	#region "Get Paged"
	
	/// <summary>
	/// Gets a page of rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
	/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of petshopServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Item.")]
	public netTiers.Petshop.Entities.TList<Item> ItemProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ItemProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Item_Product key.
	///		FK_Item_Product Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="ProductId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Item filtered by the ProductId column.")]
	public netTiers.Petshop.Entities.TList<Item> ItemProvider_GetByProductId(System.String productId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ItemProvider.GetByProductId(productId, start, pageLength, out count);
	}
	
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK_Item index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="Id"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Item filtered by the column Id that is part of the PK_Item index.")]
	public netTiers.Petshop.Entities.Item ItemProvider_GetById(System.String id, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ItemProvider.GetById(id, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table Item.")]
	public netTiers.Petshop.Entities.Item ItemProvider_Insert(netTiers.Petshop.Entities.Item entity )
	{
		netTiers.Petshop.Data.DataRepository.ItemProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<Item> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<Item> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.Item object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table Item.")]
	public void ItemProvider_BulkInsert(netTiers.Petshop.Entities.TList<Item> entityList )
	{
		netTiers.Petshop.Data.DataRepository.ItemProvider.BulkInsert(entityList);
	}
	#endregion "Insert Functions"
			
	#region "Update Functions"
		
	/// <summary>
	/// 	Update an existing row in the datasource.
	/// </summary>
	/// <param name="entity"> object to update.</param>
	/// <remarks>After updating the datasource, the object will be updated
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Update a row in the table Item.")]
	public netTiers.Petshop.Entities.Item ItemProvider_Update(netTiers.Petshop.Entities.Item entity)
	{
		netTiers.Petshop.Data.DataRepository.ItemProvider.Update(entity);
		return entity;
	}

	#endregion "Update Functions"

	#region Custom Methods
	
	
	#endregion


	
	#region "Get from  Many To Many Relationship Functions"
	#endregion	
	
	#region "Delete Functions"
	
		
	/// <summary>
	/// 	Deletes a row from the DataSource.
	/// </summary>
	/// <param name="Id">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table Product.")]
	public bool ProductProvider_Delete(System.String id, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.ProductProvider.Delete(id, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Product with additional query text.")]
	public netTiers.Petshop.Entities.TList<Product> ProductProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ProductProvider.Find(null, whereClause, start, pageLength, out count);
	}
	
	#endregion "Find Functions"
	
	
	#region "GetList Functions"
		
	/// <summary>
	/// 	Gets All rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <returns>Returns a <s>DataSet</s>.</returns>
	[WebMethod(Description="Get all rows from the table Product.")]
	public netTiers.Petshop.Entities.TList<Product> ProductProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ProductProvider.GetAll(start, pageLength, out count);		
	}
	
	#endregion
	
	#region "Get Paged"
	
	/// <summary>
	/// Gets a page of rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
	/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	/// <param name="count">Number of rows in the DataSource.</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of petshopServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Product.")]
	public netTiers.Petshop.Entities.TList<Product> ProductProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ProductProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Product_Category key.
	///		FK_Product_Category Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="CategoryId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Product filtered by the CategoryId column.")]
	public netTiers.Petshop.Entities.TList<Product> ProductProvider_GetByCategoryId(System.String categoryId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ProductProvider.GetByCategoryId(categoryId, start, pageLength, out count);
	}
	
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK_Product index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="Id"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Product filtered by the column Id that is part of the PK_Product index.")]
	public netTiers.Petshop.Entities.Product ProductProvider_GetById(System.String id, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.ProductProvider.GetById(id, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table Product.")]
	public netTiers.Petshop.Entities.Product ProductProvider_Insert(netTiers.Petshop.Entities.Product entity )
	{
		netTiers.Petshop.Data.DataRepository.ProductProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<Product> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<Product> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.Product object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table Product.")]
	public void ProductProvider_BulkInsert(netTiers.Petshop.Entities.TList<Product> entityList )
	{
		netTiers.Petshop.Data.DataRepository.ProductProvider.BulkInsert(entityList);
	}
	#endregion "Insert Functions"
			
	#region "Update Functions"
		
	/// <summary>
	/// 	Update an existing row in the datasource.
	/// </summary>
	/// <param name="entity"> object to update.</param>
	/// <remarks>After updating the datasource, the object will be updated
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Update a row in the table Product.")]
	public netTiers.Petshop.Entities.Product ProductProvider_Update(netTiers.Petshop.Entities.Product entity)
	{
		netTiers.Petshop.Data.DataRepository.ProductProvider.Update(entity);
		return entity;
	}

	#endregion "Update Functions"

	#region Custom Methods
	
	
	#endregion

	
	
	/* --------------------------------------------------------
		SQL VIEWS
	----------------------------------------------------------- */
	
	#region "GetList Functions"
		
	/// <summary>
	/// 	Gets All rows from the DataSource.
	/// </summary>
	/// <returns>Returns a <s>DataSet</s>.</returns>
	[WebMethod(Description="Get all rows from the view ExtendedItem.")]
	public netTiers.Petshop.Entities.VList<ExtendedItem> ExtendedItemProvider_GetAll(int start, int pageLength)
	{
		return netTiers.Petshop.Data.DataRepository.ExtendedItemProvider.GetAll(start, pageLength);
	}
	
	#endregion
	
	#region "Get search"
	
	/// <summary>
	/// Gets a page of rows from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <param name="orderBy">Specifies the ORDER By criteria for the rows in the DataSource.</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of petshopServices objects.</returns>
	[WebMethod(Description="Get all rows from the view ExtendedItem.")]
	public netTiers.Petshop.Entities.VList<ExtendedItem> ExtendedItemProvider_Get(string whereClause, string orderBy, int start, int pageLength)
	{
		return netTiers.Petshop.Data.DataRepository.ExtendedItemProvider.Get(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength);
	}

	#endregion
	
	#region Custom Methods
	
	
	#endregion
	

	#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		[WebMethod(MessageName="ExecuteNonQueryPs", Description="This method wrap the ExecuteNonQuery method provided by the Enterprise Library Data Access Application Block.")]
		public int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			return netTiers.Petshop.Data.DataRepository.Provider.ExecuteNonQuery(storedProcedureName, parameterValues);
		}

		/*
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		[WebMethod(MessageName="ExecuteNonQueryCmd", Description="This method wrap the ExecuteNonQuery method provided by the Enterprise Library Data Access Application Block.")]
		public void ExecuteNonQuery(Microsoft.Practices.EnterpriseLibrary.Data.DBCommandWrapper commandWrapper)
		{
			netTiers.Petshop.Data.DataRepository.Current.ExecuteNonQuery(commandWrapper);
		}
		*/

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		[WebMethod(MessageName="ExecuteNonQueryQry", Description="This method wrap the ExecuteNonQuery method provided by the Enterprise Library Data Access Application Block.")]
		public int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			return netTiers.Petshop.Data.DataRepository.Provider.ExecuteNonQuery(commandType, commandText);
		}
		
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		[WebMethod(MessageName="ExecuteDataSetPs", Description="This method wrap the ExecuteDataSet method provided by the Enterprise Library Data Access Application Block.")]
		public DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			return netTiers.Petshop.Data.DataRepository.Provider.ExecuteDataSet(storedProcedureName, parameterValues);
		}
		
		/*
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		[WebMethod(MessageName="ExecuteDataSetCmd", Description="This method wrap the ExecuteDataSet method provided by the Enterprise Library Data Access Application Block.")]
		public DataSet ExecuteDataSet(Microsoft.Practices.EnterpriseLibrary.Data.DBCommandWrapper commandWrapper)
		{
			return netTiers.Petshop.Data.DataRepository.Current.ExecuteDataSet(commandWrapper);
		}
		*/

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		[WebMethod(MessageName="ExecuteDataSetQry", Description="This method wrap the ExecuteDataSet method provided by the Enterprise Library Data Access Application Block.")]
		public DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			return netTiers.Petshop.Data.DataRepository.Provider.ExecuteDataSet(commandType, commandText);
		}		
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		[WebMethod(MessageName="ExecuteScalarPs", Description="This method wrap the ExecuteScalar method provided by the Enterprise Library Data Access Application Block.")]
		public object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			return netTiers.Petshop.Data.DataRepository.Provider.ExecuteScalar(storedProcedureName, parameterValues);
		}	

		/*
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		[WebMethod(MessageName="ExecuteScalarCmd", Description="This method wrap the ExecuteScalar method provided by the Enterprise Library Data Access Application Block.")]
		public object ExecuteScalar(Microsoft.Practices.EnterpriseLibrary.Data.DBCommandWrapper commandWrapper)
		{
			return netTiers.Petshop.Data.DataRepository.Current.ExecuteScalar(commandWrapper);
		}
		*/

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		[WebMethod(MessageName="ExecuteScalarQry", Description="This method wrap the ExecuteScalar method provided by the Enterprise Library Data Access Application Block.")]
		public object ExecuteScalar(CommandType commandType, string commandText)
		{
			return netTiers.Petshop.Data.DataRepository.Provider.ExecuteScalar(commandType, commandText);	
		}
		
		#endregion

		#endregion
}