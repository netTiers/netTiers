<%@ WebService Language="C#" Class="petshopDBServices" %>
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
///	Exposes CRUD webmethods for the petshopDBServices Database.
/// </summary>
[WebService(Namespace="http://localhost/PetshopServices", Description="Exposes CRUD webmethods for the petshopDBServices Database.")]
public class petshopDBServices : WebService 
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
	public bool AccountProvider_Delete(System.Guid id, byte[] timestamp)
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Account.")]
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
	
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
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_GetByFavoriteCategoryId(System.Guid? favoriteCategoryId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetByFavoriteCategoryId(favoriteCategoryId, start, pageLength, out count);
	}
	
	
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
	public netTiers.Petshop.Entities.TList<Account> AccountProvider_GetByCreditCardId(System.Guid? creditCardId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.AccountProvider.GetByCreditCardId(creditCardId, start, pageLength, out count);
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
	public netTiers.Petshop.Entities.Account AccountProvider_GetById(System.Guid id, int start, int pageLength, out int count)
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
	public bool CategoryProvider_Delete(System.Guid id, byte[] timestamp)
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
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
	public netTiers.Petshop.Entities.Category CategoryProvider_GetById(System.Guid id, int start, int pageLength, out int count)
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
	/// <param name="CourierId">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table Courier.")]
	public bool CourierProvider_Delete(System.Guid courierId, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.CourierProvider.Delete(courierId, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Courier with additional query text.")]
	public netTiers.Petshop.Entities.TList<Courier> CourierProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CourierProvider.Find(null, whereClause, start, pageLength, out count);
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
	[WebMethod(Description="Get all rows from the table Courier.")]
	public netTiers.Petshop.Entities.TList<Courier> CourierProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CourierProvider.GetAll(start, pageLength, out count);		
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Courier.")]
	public netTiers.Petshop.Entities.TList<Courier> CourierProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CourierProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK_Courier index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="CourierId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Courier filtered by the column CourierId that is part of the PK_Courier index.")]
	public netTiers.Petshop.Entities.Courier CourierProvider_GetByCourierId(System.Guid courierId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.CourierProvider.GetByCourierId(courierId, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table Courier.")]
	public netTiers.Petshop.Entities.Courier CourierProvider_Insert(netTiers.Petshop.Entities.Courier entity )
	{
		netTiers.Petshop.Data.DataRepository.CourierProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<Courier> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<Courier> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.Courier object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table Courier.")]
	public void CourierProvider_BulkInsert(netTiers.Petshop.Entities.TList<Courier> entityList )
	{
		netTiers.Petshop.Data.DataRepository.CourierProvider.BulkInsert(entityList);
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
	[WebMethod(Description="Update a row in the table Courier.")]
	public netTiers.Petshop.Entities.Courier CourierProvider_Update(netTiers.Petshop.Entities.Courier entity)
	{
		netTiers.Petshop.Data.DataRepository.CourierProvider.Update(entity);
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
	public bool CreditCardProvider_Delete(System.Guid id, byte[] timestamp)
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
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
	public netTiers.Petshop.Entities.CreditCard CreditCardProvider_GetById(System.Guid id, int start, int pageLength, out int count)
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
	/// <param name="ItemId">. Primary Key.</param>	
	/// <param name="SuppId">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table Inventory.")]
	public bool InventoryProvider_Delete(System.Guid itemId, System.Guid suppId, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.InventoryProvider.Delete(itemId, suppId, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Inventory with additional query text.")]
	public netTiers.Petshop.Entities.TList<Inventory> InventoryProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.InventoryProvider.Find(null, whereClause, start, pageLength, out count);
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
	[WebMethod(Description="Get all rows from the table Inventory.")]
	public netTiers.Petshop.Entities.TList<Inventory> InventoryProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.InventoryProvider.GetAll(start, pageLength, out count);		
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Inventory.")]
	public netTiers.Petshop.Entities.TList<Inventory> InventoryProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.InventoryProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Inventory_Item key.
	///		FK_Inventory_Item Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="ItemId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Inventory filtered by the ItemId column.")]
	public netTiers.Petshop.Entities.TList<Inventory> InventoryProvider_GetByItemId(System.Guid itemId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.InventoryProvider.GetByItemId(itemId, start, pageLength, out count);
	}
	
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Inventory_Supplier key.
	///		FK_Inventory_Supplier Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="SuppId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Inventory filtered by the SuppId column.")]
	public netTiers.Petshop.Entities.TList<Inventory> InventoryProvider_GetBySuppId(System.Guid suppId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.InventoryProvider.GetBySuppId(suppId, start, pageLength, out count);
	}
	
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK_Inventory index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="ItemId"></param>
	/// <param name="SuppId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Inventory filtered by the column ItemIdSuppId that is part of the PK_Inventory index.")]
	public netTiers.Petshop.Entities.Inventory InventoryProvider_GetByItemIdSuppId(System.Guid itemId, System.Guid suppId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.InventoryProvider.GetByItemIdSuppId(itemId, suppId, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table Inventory.")]
	public netTiers.Petshop.Entities.Inventory InventoryProvider_Insert(netTiers.Petshop.Entities.Inventory entity )
	{
		netTiers.Petshop.Data.DataRepository.InventoryProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<Inventory> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<Inventory> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.Inventory object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table Inventory.")]
	public void InventoryProvider_BulkInsert(netTiers.Petshop.Entities.TList<Inventory> entityList )
	{
		netTiers.Petshop.Data.DataRepository.InventoryProvider.BulkInsert(entityList);
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
	[WebMethod(Description="Update a row in the table Inventory.")]
	public netTiers.Petshop.Entities.Inventory InventoryProvider_Update(netTiers.Petshop.Entities.Inventory entity)
	{
		netTiers.Petshop.Data.DataRepository.InventoryProvider.Update(entity);
		return entity;
	}

	#endregion "Update Functions"

	#region Custom Methods
	
	
	/// <summary>
	///	This method wrap the CSP_Inventory_GetMaxSupplier stored procedure. 
	/// </summary>
	[WebMethod(Description="This method wrap the CSP_Inventory_GetMaxSupplier stored procedure.")]
	public netTiers.Petshop.Entities.TList<Inventory> InventoryProvider_GetMaxSupplier(int start, int pageLength , System.Guid? itemId)
	{
		    return netTiers.Petshop.Data.DataRepository.InventoryProvider.GetMaxSupplier(start, pageLength , itemId);
	}
		
	
	#endregion


	
	#region "Get from  Many To Many Relationship Functions"

	#region GetBySuppIdFromInventory
		
	[WebMethod(Description="Get rows from the table Item, through the junction table Inventory.")]
	public netTiers.Petshop.Entities.TList<Item> ItemProvider_GetBySuppIdFromInventory(System.Guid suppId, int start, int pageLength, out int count)
	{		
		return netTiers.Petshop.Data.DataRepository.ItemProvider.GetBySuppIdFromInventory(suppId, start, pageLength, out count);
	}
	
	#endregion GetBySuppIdFromInventory
	
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
	public bool ItemProvider_Delete(System.Guid id, byte[] timestamp)
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
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
	public netTiers.Petshop.Entities.TList<Item> ItemProvider_GetByProductId(System.Guid productId, int start, int pageLength, out int count)
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
	public netTiers.Petshop.Entities.Item ItemProvider_GetById(System.Guid id, int start, int pageLength, out int count)
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
	/// <param name="OrderId">. Primary Key.</param>	
	/// <param name="LineNum">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table LineItem.")]
	public bool LineItemProvider_Delete(System.Int32 orderId, System.Int32 lineNum, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.LineItemProvider.Delete(orderId, lineNum, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table LineItem with additional query text.")]
	public netTiers.Petshop.Entities.TList<LineItem> LineItemProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.LineItemProvider.Find(null, whereClause, start, pageLength, out count);
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
	[WebMethod(Description="Get all rows from the table LineItem.")]
	public netTiers.Petshop.Entities.TList<LineItem> LineItemProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.LineItemProvider.GetAll(start, pageLength, out count);		
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
	[WebMethod(Description="Get all rows from the table LineItem.")]
	public netTiers.Petshop.Entities.TList<LineItem> LineItemProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.LineItemProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__1367E606 key.
	///		FK__LineItem__OrderI__1367E606 Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="OrderId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from LineItem filtered by the OrderId column.")]
	public netTiers.Petshop.Entities.TList<LineItem> LineItemProvider_GetByOrderId(System.Int32 orderId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.LineItemProvider.GetByOrderId(orderId, start, pageLength, out count);
	}
	
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_LineItem_Item key.
	///		FK_LineItem_Item Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="ItemId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from LineItem filtered by the ItemId column.")]
	public netTiers.Petshop.Entities.TList<LineItem> LineItemProvider_GetByItemId(System.Guid itemId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.LineItemProvider.GetByItemId(itemId, start, pageLength, out count);
	}
	
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PkLineItem index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="OrderId"></param>
	/// <param name="LineNum"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table LineItem filtered by the column LineNumOrderId that is part of the PkLineItem index.")]
	public netTiers.Petshop.Entities.LineItem LineItemProvider_GetByLineNumOrderId(System.Int32 orderId, System.Int32 lineNum, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.LineItemProvider.GetByLineNumOrderId(orderId, lineNum, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table LineItem.")]
	public netTiers.Petshop.Entities.LineItem LineItemProvider_Insert(netTiers.Petshop.Entities.LineItem entity )
	{
		netTiers.Petshop.Data.DataRepository.LineItemProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<LineItem> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<LineItem> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.LineItem object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table LineItem.")]
	public void LineItemProvider_BulkInsert(netTiers.Petshop.Entities.TList<LineItem> entityList )
	{
		netTiers.Petshop.Data.DataRepository.LineItemProvider.BulkInsert(entityList);
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
	[WebMethod(Description="Update a row in the table LineItem.")]
	public netTiers.Petshop.Entities.LineItem LineItemProvider_Update(netTiers.Petshop.Entities.LineItem entity)
	{
		netTiers.Petshop.Data.DataRepository.LineItemProvider.Update(entity);
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
	/// <param name="OrderId">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table Orders.")]
	public bool OrdersProvider_Delete(System.Int32 orderId, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.OrdersProvider.Delete(orderId, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Orders with additional query text.")]
	public netTiers.Petshop.Entities.TList<Orders> OrdersProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrdersProvider.Find(null, whereClause, start, pageLength, out count);
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
	[WebMethod(Description="Get all rows from the table Orders.")]
	public netTiers.Petshop.Entities.TList<Orders> OrdersProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrdersProvider.GetAll(start, pageLength, out count);		
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Orders.")]
	public netTiers.Petshop.Entities.TList<Orders> OrdersProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrdersProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Orders_Account key.
	///		FK_Orders_Account Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="AccountId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Orders filtered by the AccountId column.")]
	public netTiers.Petshop.Entities.TList<Orders> OrdersProvider_GetByAccountId(System.Guid accountId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrdersProvider.GetByAccountId(accountId, start, pageLength, out count);
	}
	
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Orders_Courier key.
	///		FK_Orders_Courier Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="CourierId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Orders filtered by the CourierId column.")]
	public netTiers.Petshop.Entities.TList<Orders> OrdersProvider_GetByCourierId(System.Guid courierId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrdersProvider.GetByCourierId(courierId, start, pageLength, out count);
	}
	
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_Orders_CreditCard key.
	///		FK_Orders_CreditCard Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="CreditCardId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from Orders filtered by the CreditCardId column.")]
	public netTiers.Petshop.Entities.TList<Orders> OrdersProvider_GetByCreditCardId(System.Guid creditCardId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrdersProvider.GetByCreditCardId(creditCardId, start, pageLength, out count);
	}
	
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK__Orders__0CBAE877 index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="OrderId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Orders filtered by the column OrderId that is part of the PK__Orders__0CBAE877 index.")]
	public netTiers.Petshop.Entities.Orders OrdersProvider_GetByOrderId(System.Int32 orderId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrdersProvider.GetByOrderId(orderId, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table Orders.")]
	public netTiers.Petshop.Entities.Orders OrdersProvider_Insert(netTiers.Petshop.Entities.Orders entity )
	{
		netTiers.Petshop.Data.DataRepository.OrdersProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<Orders> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<Orders> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.Orders object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table Orders.")]
	public void OrdersProvider_BulkInsert(netTiers.Petshop.Entities.TList<Orders> entityList )
	{
		netTiers.Petshop.Data.DataRepository.OrdersProvider.BulkInsert(entityList);
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
	[WebMethod(Description="Update a row in the table Orders.")]
	public netTiers.Petshop.Entities.Orders OrdersProvider_Update(netTiers.Petshop.Entities.Orders entity)
	{
		netTiers.Petshop.Data.DataRepository.OrdersProvider.Update(entity);
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
	/// <param name="OrderId">. Primary Key.</param>	
	/// <param name="LineNum">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table OrderStatus.")]
	public bool OrderStatusProvider_Delete(System.Int32 orderId, System.Int32 lineNum, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusProvider.Delete(orderId, lineNum, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table OrderStatus with additional query text.")]
	public netTiers.Petshop.Entities.TList<OrderStatus> OrderStatusProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusProvider.Find(null, whereClause, start, pageLength, out count);
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
	[WebMethod(Description="Get all rows from the table OrderStatus.")]
	public netTiers.Petshop.Entities.TList<OrderStatus> OrderStatusProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusProvider.GetAll(start, pageLength, out count);		
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
	[WebMethod(Description="Get all rows from the table OrderStatus.")]
	public netTiers.Petshop.Entities.TList<OrderStatus> OrderStatusProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK__OrderStat__Order__164452B1 key.
	///		FK__OrderStat__Order__164452B1 Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="OrderId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from OrderStatus filtered by the OrderId column.")]
	public netTiers.Petshop.Entities.TList<OrderStatus> OrderStatusProvider_GetByOrderId(System.Int32 orderId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusProvider.GetByOrderId(orderId, start, pageLength, out count);
	}
	
	
	/// <summary>
	/// 	Gets rows from the datasource based on the FK_OrderStatus_OrderStatusType key.
	///		FK_OrderStatus_OrderStatusType Description: 
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="OrderStatusId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from OrderStatus filtered by the OrderStatusId column.")]
	public netTiers.Petshop.Entities.TList<OrderStatus> OrderStatusProvider_GetByOrderStatusId(System.Int32 orderStatusId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusProvider.GetByOrderStatusId(orderStatusId, start, pageLength, out count);
	}
	
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PkOrderStatus index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="OrderId"></param>
	/// <param name="LineNum"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table OrderStatus filtered by the column LineNumOrderId that is part of the PkOrderStatus index.")]
	public netTiers.Petshop.Entities.OrderStatus OrderStatusProvider_GetByLineNumOrderId(System.Int32 orderId, System.Int32 lineNum, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusProvider.GetByLineNumOrderId(orderId, lineNum, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table OrderStatus.")]
	public netTiers.Petshop.Entities.OrderStatus OrderStatusProvider_Insert(netTiers.Petshop.Entities.OrderStatus entity )
	{
		netTiers.Petshop.Data.DataRepository.OrderStatusProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<OrderStatus> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<OrderStatus> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.OrderStatus object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table OrderStatus.")]
	public void OrderStatusProvider_BulkInsert(netTiers.Petshop.Entities.TList<OrderStatus> entityList )
	{
		netTiers.Petshop.Data.DataRepository.OrderStatusProvider.BulkInsert(entityList);
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
	[WebMethod(Description="Update a row in the table OrderStatus.")]
	public netTiers.Petshop.Entities.OrderStatus OrderStatusProvider_Update(netTiers.Petshop.Entities.OrderStatus entity)
	{
		netTiers.Petshop.Data.DataRepository.OrderStatusProvider.Update(entity);
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
	/// <param name="OrderStatusId">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table OrderStatusType.")]
	public bool OrderStatusTypeProvider_Delete(System.Int32 orderStatusId)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.Delete(orderStatusId);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table OrderStatusType with additional query text.")]
	public netTiers.Petshop.Entities.TList<OrderStatusType> OrderStatusTypeProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.Find(null, whereClause, start, pageLength, out count);
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
	[WebMethod(Description="Get all rows from the table OrderStatusType.")]
	public netTiers.Petshop.Entities.TList<OrderStatusType> OrderStatusTypeProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.GetAll(start, pageLength, out count);		
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
	[WebMethod(Description="Get all rows from the table OrderStatusType.")]
	public netTiers.Petshop.Entities.TList<OrderStatusType> OrderStatusTypeProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK__OrderStatusType__7C8480AE index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="OrderStatusId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table OrderStatusType filtered by the column OrderStatusId that is part of the PK__OrderStatusType__7C8480AE index.")]
	public netTiers.Petshop.Entities.OrderStatusType OrderStatusTypeProvider_GetByOrderStatusId(System.Int32 orderStatusId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.GetByOrderStatusId(orderStatusId, start, pageLength, out count);
	}
	

	
	/// <summary>
	/// 	Gets rows from the datasource based on the IX_OrderStatusType index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="OrderStatus"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table OrderStatusType filtered by the column OrderStatus that is part of the IX_OrderStatusType index.")]
	public netTiers.Petshop.Entities.OrderStatusType OrderStatusTypeProvider_GetByOrderStatus(System.String orderStatus, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.GetByOrderStatus(orderStatus, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table OrderStatusType.")]
	public netTiers.Petshop.Entities.OrderStatusType OrderStatusTypeProvider_Insert(netTiers.Petshop.Entities.OrderStatusType entity )
	{
		netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<OrderStatusType> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<OrderStatusType> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.OrderStatusType object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table OrderStatusType.")]
	public void OrderStatusTypeProvider_BulkInsert(netTiers.Petshop.Entities.TList<OrderStatusType> entityList )
	{
		netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.BulkInsert(entityList);
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
	[WebMethod(Description="Update a row in the table OrderStatusType.")]
	public netTiers.Petshop.Entities.OrderStatusType OrderStatusTypeProvider_Update(netTiers.Petshop.Entities.OrderStatusType entity)
	{
		netTiers.Petshop.Data.DataRepository.OrderStatusTypeProvider.Update(entity);
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
	public bool ProductProvider_Delete(System.Guid id, byte[] timestamp)
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
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
	public netTiers.Petshop.Entities.TList<Product> ProductProvider_GetByCategoryId(System.Guid categoryId, int start, int pageLength, out int count)
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
	public netTiers.Petshop.Entities.Product ProductProvider_GetById(System.Guid id, int start, int pageLength, out int count)
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


	
	#region "Get from  Many To Many Relationship Functions"

	#region GetByItemIdFromInventory
		
	[WebMethod(Description="Get rows from the table Supplier, through the junction table Inventory.")]
	public netTiers.Petshop.Entities.TList<Supplier> SupplierProvider_GetByItemIdFromInventory(System.Guid itemId, int start, int pageLength, out int count)
	{		
		return netTiers.Petshop.Data.DataRepository.SupplierProvider.GetByItemIdFromInventory(itemId, start, pageLength, out count);
	}
	
	#endregion GetByItemIdFromInventory
	
	#endregion	
	
	#region "Delete Functions"
	
		
	/// <summary>
	/// 	Deletes a row from the DataSource.
	/// </summary>
	/// <param name="SuppId">. Primary Key.</param>	
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="connectionString">Connection string to datasource.</param>
	/// <remarks>Deletes based on primary key(s).</remarks>
	/// <returns>Returns true if operation suceeded.</returns>
	[WebMethod(Description="Delete a row from the table Supplier.")]
	public bool SupplierProvider_Delete(System.Guid suppId, byte[] timestamp)
	{
		return netTiers.Petshop.Data.DataRepository.SupplierProvider.Delete(suppId, timestamp);
	}//end Delete
		
	
	#endregion
	
	#region "Find Functions"
	
	/// <summary>
	/// 	Returns rows meeting the whereclause condition from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query.</param>
	/// <remarks></remarks>
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Supplier with additional query text.")]
	public netTiers.Petshop.Entities.TList<Supplier> SupplierProvider_Find(string whereClause, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.SupplierProvider.Find(null, whereClause, start, pageLength, out count);
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
	[WebMethod(Description="Get all rows from the table Supplier.")]
	public netTiers.Petshop.Entities.TList<Supplier> SupplierProvider_GetAll(int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.SupplierProvider.GetAll(start, pageLength, out count);		
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
	[WebMethod(Description="Get all rows from the table Supplier.")]
	public netTiers.Petshop.Entities.TList<Supplier> SupplierProvider_GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.SupplierProvider.GetPaged(whereClause.Length > 0 ? whereClause : null, orderBy.Length > 0 ? orderBy : null, start, pageLength, out count);
	}

	#endregion
		
	#region "Get By Foreign Key Functions"
#endregion
	
	#region "Get By Index Functions"
	
	/// <summary>
	/// 	Gets rows from the datasource based on the PK__Supplier__0425A276 index.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pagelen">Number of rows to return.</param>
	/// <param name="SuppId"></param>
	/// <param name="count">out parameter to get total records for query</param>	
	/// <returns>Returns a DataSet.</returns>
	[WebMethod(Description="Get rows from the table Supplier filtered by the column SuppId that is part of the PK__Supplier__0425A276 index.")]
	public netTiers.Petshop.Entities.Supplier SupplierProvider_GetBySuppId(System.Guid suppId, int start, int pageLength, out int count)
	{
		return netTiers.Petshop.Data.DataRepository.SupplierProvider.GetBySuppId(suppId, start, pageLength, out count);
	}
	

	#endregion "Get By Index Functions"
	
	#region "Insert Functions"
		
	/// <summary>
	/// 	Inserts an object into the datasource.
	/// </summary>	
	/// <remarks>After inserting into the datasource, the object will be returned
	/// to refelect any changes made by the datasource. (ie: identity columns)</remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a row in the table Supplier.")]
	public netTiers.Petshop.Entities.Supplier SupplierProvider_Insert(netTiers.Petshop.Entities.Supplier entity )
	{
		netTiers.Petshop.Data.DataRepository.SupplierProvider.Insert(entity);
		return entity;		
	}
	
	/// <summary>
	/// Inserts a netTiers.Petshop.Entities.TList<Supplier> object into the datasource using a transaction.
	/// </summary>
	/// <param name="entity">netTiers.Petshop.Entities.TList<Supplier> object to insert.</param>
	/// <remarks>After inserting into the datasource, the netTiers.Petshop.Entities.Supplier object will be updated
	/// to refelect any changes made by the datasource. (ie: identity or computed columns)
	/// </remarks>
	/// <returns>Returns true if operation is successful.</returns>
	[WebMethod(Description="Inserts a Bulk set of rows into the table Supplier.")]
	public void SupplierProvider_BulkInsert(netTiers.Petshop.Entities.TList<Supplier> entityList )
	{
		netTiers.Petshop.Data.DataRepository.SupplierProvider.BulkInsert(entityList);
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
	[WebMethod(Description="Update a row in the table Supplier.")]
	public netTiers.Petshop.Entities.Supplier SupplierProvider_Update(netTiers.Petshop.Entities.Supplier entity)
	{
		netTiers.Petshop.Data.DataRepository.SupplierProvider.Update(entity);
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
	/// <returns>Returns a typed collection of petshopDBServices objects.</returns>
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