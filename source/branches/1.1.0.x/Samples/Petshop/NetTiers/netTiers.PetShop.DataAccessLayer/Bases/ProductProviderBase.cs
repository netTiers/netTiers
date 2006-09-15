
#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;

#endregion

namespace netTiers.PetShop.DataAccessLayer.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ProductProviderBase
	{		
		
		#region "Get from  Many To Many Relationship Functions"
		#endregion	
		
		
		#region "Delete Functions"
			
		/// <summary>
		/// 	Deletes rows from the DataSource.
		/// </summary>
		/// <param name="entityCollection">netTiers.PetShop.TList&lt;Product&gt; containing data.</param>
		/// <remarks>Deletes netTiers.PetShop.Products only when IsDeleted equals true.</remarks>
		/// <returns>Returns the number of successful delete.</returns>
		public int Delete(netTiers.PetShop.TList<Product> entityCollection)
		{
			int number = 0;
			foreach (netTiers.PetShop.Product entity in entityCollection)
			{
				if( Delete(entity) )
				{
					number++;
				}
			}
			return number;
		}
			
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product object containing data.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(netTiers.PetShop.Product entity)
		{
			return Delete(entity.OriginalId, entity.Timestamp);	
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String id, byte[] timestamp)
		{
			return Delete(null, id, timestamp);
		}
			
		/// <summary>
		/// 	Deletes a rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entityCollection">netTiers.PetShop.TList&lt;Product&gt; containing data.</param>
		/// <remarks>Deletes netTiers.PetShop.Products only when IsDeleted equals true.</remarks>
		/// <returns>Returns the number of successful delete.</returns>
		public int Delete(TransactionManager transactionManager, netTiers.PetShop.TList<Product> entityCollection)
		{
			int number = 0;
			foreach (netTiers.PetShop.Product entity in entityCollection)
			{
				if ( Delete(transactionManager, entity) )
				{
					number++;
				}
			}
			return number;
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product object containing data.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(TransactionManager transactionManager, netTiers.PetShop.Product entity)
		{
			return Delete(transactionManager, entity.OriginalId, entity.Timestamp);	
		}		
						
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id">. Primary Key.</param>
/// <param name="timestamp">The timestamp field used for concurrency check.</param>/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String id, byte[] timestamp);
		
		#endregion
		
		#region "Find Functions"
		
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> Find(string whereClause)
		{
			return Find(whereClause, 0, int.MaxValue);
		}	
		
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> Find(string whereClause, int start, int pageLength)
		{
			return Find(null, whereClause, start, pageLength);
		}
		
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> Find(TransactionManager transactionManager, string whereClause)
		{
			return Find(transactionManager, whereClause, 0, int.MaxValue);
		}
		
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public abstract netTiers.PetShop.TList<Product> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength);
		
		#endregion "Find Functions"
			
		#region "GetList Functions"
		
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <returns>Returns a TList of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetAll()
		{
			return GetAll(0, int.MaxValue);
		}
		
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetAll(int start, int pageLength)
		{	
			return GetAll(null, start, pageLength);
		}
					
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetAll(TransactionManager transactionManager)
		{
			return GetAll(transactionManager, 0,int.MaxValue);
		}	
		
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of netTiers.PetShop.Product objects.</returns>
		public abstract netTiers.PetShop.TList<Product> GetAll(TransactionManager transactionManager, int start, int pageLength);
		
		#endregion
		
		#region Paged Recordset
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetPaged(out int count)
		{
			return GetPaged(null, null, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetPaged(int start, int pageLength, out int count)
		{
			return GetPaged(null, null, start, pageLength, out count);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			return GetPaged(null, whereClause, orderBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetPaged(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			return GetPaged(transactionManager, null, null, start, pageLength, out count);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of netTiers.PetShop.Product objects.</returns>
		public abstract netTiers.PetShop.TList<Product> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count);
		
		
		/// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
        /// <param name="count">Number of rows in the DataSource.</param>
        /// <remarks></remarks>
        /// <returns>Returns an int indicating the total number of records that would be returned by an equivalent GetPaged call.</returns>
        public int GetTotalItems(string whereClause, out int count)
        {
            GetPaged(null, whereClause, "", 0, 0, out count);
            return count;
        }
		
		#endregion
			
			
		#region "Get By Foreign Key Functions"
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		FK_Product_Category Description: 
		/// </summary>
		/// <param name="categoryId"></param>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetByCategoryId(System.String categoryId)
		{
			return GetByCategoryId(categoryId, 0,int.MaxValue);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		FK_Product_Category Description: 
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetByCategoryId(TransactionManager transactionManager, System.String categoryId)
		{
			return GetByCategoryId(transactionManager, categoryId, 0, int.MaxValue);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		fK_Product_Category Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public netTiers.PetShop.TList<Product> GetByCategoryId(System.String categoryId, int start, int pageLength)
		{
			return GetByCategoryId(null, categoryId, start, pageLength);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		FK_Product_Category Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryId"></param>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public abstract netTiers.PetShop.TList<Product> GetByCategoryId(TransactionManager transactionManager, System.String categoryId, int start, int pageLength);
		
		#endregion
		
		
		#region "Get By Index Functions"
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Product index.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.PetShop.Product"/> class.</returns>
		public netTiers.PetShop.Product GetById(System.String id)
		{
			return GetById(id, 0, int.MaxValue);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.PetShop.Product"/> class.</returns>
		public netTiers.PetShop.Product GetById(System.String id, int start, int pageLength)
		{
			return GetById(null, id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.PetShop.Product"/> class.</returns>
		public netTiers.PetShop.Product GetById(TransactionManager transactionManager, System.String id)
		{
			return GetById(transactionManager, id, 0, int.MaxValue);
		}
			
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.PetShop.Product"/> class.</returns>
		public abstract netTiers.PetShop.Product GetById(TransactionManager transactionManager, System.String id, int start, int pageLength);
						
		#endregion "Get By Index Functions"
	
	
		#region "Insert Functions"
		
		/// <summary>
		/// 	Inserts a <see cref="netTiers.PetShop.Product"/> object into the datasource.
		/// </summary>
		/// <param name="entity">The <see cref="netTiers.PetShop.Product"/> object to insert.</param>
		/// <remarks>
		/// 	After inserting into the datasource, the <see cref="netTiers.PetShop.Product"/> object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public bool Insert(netTiers.PetShop.Product entity)
		{
			return Insert(null, entity);
		}	
		
		/// <summary>
		/// 	Insert rows in the datasource.
		/// </summary>
		/// <param name="entityCollection">TList of <c>netTiers.PetShop.Product</c> objects.</param>
		/// <remarks>
		///		This function will only insert entity objects marked as dirty
		///		and have an identity field equal to zero.
		///		Upon inserting the objects, each dirty object will have the public
		///		method <c>Object.AcceptChanges()</c> called to make it clean.
		/// 	After inserting into the datasource, the <c>netTiers.PetShop.Product</c> objects will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		///</remarks>
		/// <returns>Returns the number of successful insert.</returns>
		public int Insert(netTiers.PetShop.TList<Product> entityCollection)
		{
			return Insert(null, entityCollection);
		}
		
		/// <summary>
		/// 	Insert rows in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entityCollection"><c>netTiers.PetShop.Product</c> objects in a netTiers.PetShop.TList&lt;Product&gt; object to insert.</param>
		/// <remarks>
		///		This function will only insert entity objects marked as dirty
		///		and have an identity field equal to zero.
		///		Upon inserting the objects, each dirty object will have the public
		///		method <c>Object.AcceptChanges()</c> called to make it clean.
		/// 	After inserting into the datasource, the <c>netTiers.PetShop.Product</c> objects will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		///	</remarks>
		/// <returns>Returns the number of successful insert.</returns>
		public int Insert(TransactionManager transactionManager, netTiers.PetShop.TList<Product> entityCollection)
		{
			int number = 0;
			foreach (netTiers.PetShop.Product entity in entityCollection)
			{
				//if (entity.IsNew)
				if (entity.EntityState == EntityState.Added)
				{
					if (Insert(transactionManager, entity) )
					{
						number++;
					}
				}
			}
			return number;
		}
		
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the netTiers.PetShop.Product object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public void BulkInsert(TList<netTiers.PetShop.Product> entities)
		{
			BulkInsert(null, entities);
		}
	
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the netTiers.PetShop.Product object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public abstract void BulkInsert(TransactionManager transactionManager, TList<netTiers.PetShop.Product> entities);
	
		/// <summary>
		/// 	Inserts a netTiers.PetShop.Product object into the datasource using a transaction.
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product object to insert.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>After inserting into the datasource, the netTiers.PetShop.Product object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public abstract bool Insert(TransactionManager transactionManager, netTiers.PetShop.Product entity);
		
		#endregion
	
	
		#region "Update Functions"
		
		/// <summary>
		/// 	Update existing rows in the datasource.
		/// </summary>
		/// <param name="entityCollection">TList of <c>netTiers.PetShop.Product</c> objects.</param>
		/// <remarks>
		///		This function will only update entity objects marked as dirty
		///		and do not have an primary key value of 0.
		///		Upon updating the objects, each dirty object will have the public
		///		method <c>Object.AcceptChanges()</c> called to make it clean.
		/// 	After updating the datasource, the <c>netTiers.PetShop.Product</c> objects will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		///</remarks>
		/// <returns>Returns the number of successful update.</returns>
		public int Update(netTiers.PetShop.TList<Product> entityCollection)
		{	
			return Update(null, entityCollection);
		}
		
		/// <summary>
		/// 	Update existing rows in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entityCollection">TList of <c>netTiers.PetShop.Product</c> objects.</param>
		/// <remarks>
		///		This function will only update entity objects marked as dirty
		///		and do not have an primary key value of 0.
		///		Upon updating the objects, each dirty object will have the public
		///		method <c>Object.AcceptChanges()</c> called to make it clean.
		/// 	After updating the datasource, the <c>netTiers.PetShop.Product</c> objects will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		///</remarks>
		/// <returns>Returns the number of successful update .</returns>
		public int Update(TransactionManager transactionManager, netTiers.PetShop.TList<Product> entityCollection)
		{
			int number = 0;
			foreach (netTiers.PetShop.Product entity in entityCollection)
			{
				//if ((entity.IsDirty) && !(entity.IsNew))
				if (entity.EntityState == EntityState.Changed)
				{
					if ( Update(transactionManager, entity) )
					{
						number++;
					}
				}
			}
			return number;
		}
		
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product object to update.</param>
		/// <remarks>
		///		After updating the datasource, the netTiers.PetShop.Product object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public bool Update(netTiers.PetShop.Product entity)
		{	
			return Update(null, entity);
		}
		
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product object to update.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>
		///		After updating the datasource, the netTiers.PetShop.Product object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public abstract bool Update(TransactionManager transactionManager, netTiers.PetShop.Product entity);
		
		#endregion
	
	
		#region "Save Functions"
		
		/// <summary>
		/// 	Save rows changes in the datasource (insert, update ,delete).
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product object to update.</param>
		/// <remarks>
		/// 	After updating the datasource, the <c>netTiers.PetShop.Product</c> objects will be updated or inserted
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		///</remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public void Save(netTiers.PetShop.Product entity)
		{		
			Save(null, entity);
		}
		
		/// <summary>
		/// 	Updates, Inserts rows in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity"><c>netTiers.PetShop.Product</c> to save.</param>
		/// <remarks>
		/// 	After updating the datasource, the <c>netTiers.PetShop.Product</c> objects will be updated or inserted
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public void Save(TransactionManager transactionManager, netTiers.PetShop.Product entity)
		{				
			switch (entity.EntityState)
			{				
				case EntityState.Deleted:
					Delete(transactionManager, entity);
					break ;				
				case EntityState.Changed:
					Update(transactionManager, entity);
					break ;
				case EntityState.Added:
					Insert(transactionManager, entity);
					break ;
			}			
			
			/*
			if (entity.IsDeleted)
			{
				Delete(transactionManager, entity);
			}
			if ((entity.IsDirty) && !(entity.IsNew))
			{
				Update(transactionManager, entity);
			}
			else if (entity.IsNew)
			{
				Insert(transactionManager, entity);
			}
			*/
		}
		
		/// <summary>
		/// 	Save rows changes in the datasource (insert, update ,delete).
		/// </summary>
		/// <param name="entityCollection">TList of <c>netTiers.PetShop.Product</c> objects.</param>
		/// <remarks>
		/// 	After updating the datasource, the <c>netTiers.PetShop.Product</c> objects will be updated or inserted
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		///</remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public void Save(netTiers.PetShop.TList<Product> entityCollection)
		{
			Save(null, entityCollection);
		}				
		
		/// <summary>
		/// 	Updates, Inserts rows in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entityCollection">TList of <c>netTiers.PetShop.Product</c> objects.</param>
		/// <remarks>
		/// 	After updating the datasource, the <c>netTiers.PetShop.Product</c> objects will be updated or inserted
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public void Save(TransactionManager transactionManager, netTiers.PetShop.TList<Product> entityCollection)
		{
			foreach (netTiers.PetShop.Product entity in entityCollection)
			{
				Save(transactionManager, entity);
			}
			
			foreach (netTiers.PetShop.Product entity in entityCollection.DeletedItems)
			{
				Delete(transactionManager, entity);
			}
			
			// Clear the items to delete list.
			entityCollection.DeletedItems.Clear();
		}
		
		#endregion
	
		#region Custom Methods
		
		
		#endregion
	
		#region "Helper Functions"	
		/*
		/// <summary>
		/// Fill an netTiers.PetShop.TList&lt;Product&gt; from the first table in a DataSet
		/// </summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of rows.</param>
		///<returns><see chref="netTiers.PetShop.TList<Product>"/></returns>
		public static netTiers.PetShop.TList<Product> Fill(DataSet dataSet, netTiers.PetShop.TList<Product> rows, int start, int pageLength)
		{
			if (dataSet.Tables.Count >= 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pageLength);
			}
			else
			{
				return new netTiers.PetShop.TList<Product>();
			}	
		}
		
		
		/// <summary>
		/// Fill an netTiers.PetShop.TList&lt;Product&gt; From a DataTable
		/// </summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns><see chref="netTiers.PetShop.TList&lt;Product&gt;"/></returns>
		public static netTiers.PetShop.TList<Product> Fill(DataTable dataTable, netTiers.PetShop.TList<Product> rows, int start, int pageLength)
		{
			// trying to start past the last row?
			if ( start > dataTable.Rows.Count )
				return rows;

			// will we go past the last row?
			if ( (pageLength+start) > dataTable.Rows.Count )
				pageLength = dataTable.Rows.Count;

			for (int i = start; i < pageLength; i++)
			{
				DataRow row = dataTable.Rows[i];
				
				netTiers.PetShop.Product c = new netTiers.PetShop.Product();
				c.Id = (Convert.IsDBNull(row["Id"]))?string.Empty:(System.String)row["Id"];
				c.OriginalId = (Convert.IsDBNull(row["Id"]))?string.Empty:(System.String)row["Id"];
				c.Name = (Convert.IsDBNull(row["Name"]))?string.Empty:(System.String)row["Name"];
				c.Description = (Convert.IsDBNull(row["Description"]))?null:(System.String)row["Description"];
				c.CategoryId = (Convert.IsDBNull(row["CategoryId"]))?string.Empty:(System.String)row["CategoryId"];
				c.Timestamp = (Convert.IsDBNull(row["Timestamp"]))?new byte[] {}:(System.Byte[])row["Timestamp"];
				c.AcceptChanges();
				rows.Add(c);
			}
			return rows;
		}
		*/
						
		/// <summary>
		/// Fill a netTiers.PetShop.TList&lt;Product&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.PetShop.TList&lt;Product&gt;"/></returns>
		public static netTiers.PetShop.TList<Product> Fill(IDataReader reader, netTiers.PetShop.TList<Product> rows, int start, int pageLength)
		{
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (! reader.Read() )
					return rows; // not enough rows, just return
			}

			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done

				netTiers.PetShop.Product c = new netTiers.PetShop.Product();
				c.Id = (Convert.IsDBNull(reader["Id"]))?string.Empty:(System.String)reader["Id"];
				c.OriginalId = (Convert.IsDBNull(reader["Id"]))?string.Empty:(System.String)reader["Id"];
				c.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
				c.Description = (Convert.IsDBNull(reader["Description"]))?null:(System.String)reader["Description"];
				c.CategoryId = (Convert.IsDBNull(reader["CategoryId"]))?string.Empty:(System.String)reader["CategoryId"];
				c.Timestamp = (Convert.IsDBNull(reader["Timestamp"]))?new byte[] {}:(System.Byte[])reader["Timestamp"];
				c.AcceptChanges();
				rows.Add(c);
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.PetShop.Product"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.PetShop.Product"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.PetShop.Product entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (Convert.IsDBNull(reader["Id"]))?string.Empty:(System.String)reader["Id"];
			entity.OriginalId = (Convert.IsDBNull(reader["Id"]))?string.Empty:(System.String)reader["Id"];
			entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
			entity.Description = (Convert.IsDBNull(reader["Description"]))?null:(System.String)reader["Description"];
			entity.CategoryId = (Convert.IsDBNull(reader["CategoryId"]))?string.Empty:(System.String)reader["CategoryId"];
			entity.Timestamp = (Convert.IsDBNull(reader["Timestamp"]))?new byte[] {}:(System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.PetShop.Product"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.PetShop.Product"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.PetShop.Product entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (Convert.IsDBNull(dataRow["Id"]))?string.Empty:(System.String)dataRow["Id"];
			entity.OriginalId = (Convert.IsDBNull(dataRow["Id"]))?string.Empty:(System.String)dataRow["Id"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?string.Empty:(System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.CategoryId = (Convert.IsDBNull(dataRow["CategoryId"]))?string.Empty:(System.String)dataRow["CategoryId"];
			entity.Timestamp = (Convert.IsDBNull(dataRow["Timestamp"]))?new byte[] {}:(System.Byte[])dataRow["Timestamp"];
			entity.AcceptChanges();
		}
				
		
		#region DeepLoad
		#region Deep Load By Entity
		/// <summary>
		/// Deep Load the IEntity object with all of the child 
		/// property collections only 1 Level Deep.
		/// </summary>
		/// <remarks>
		/// <c>DeepLoad</c> overloaded methods for a recursive N Level deep loading method.
		/// </remarks>
		/// <param name="entity">netTiers.PetShop.Product Object</param>
		public void DeepLoad(netTiers.PetShop.Product entity)
		{
		 	DeepLoad(entity, false, DeepLoadType.ExcludeChildren, new Type[] {});
		}
		
		/// <summary>
		/// Deep Load the IEntity object with all of the child 
		/// property collections only 1 Level Deep.
		/// </summary>
		/// <remarks>
		/// <c>DeepLoad</c> overloaded methods for a recursive N Level deep loading method.
		/// </remarks>
		/// <param name="entity">netTiers.PetShop.Product Object</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		public void DeepLoad(netTiers.PetShop.Product entity, bool deep)
		{
		 	DeepLoad(entity, deep, DeepLoadType.ExcludeChildren, new Type[] {});
		}
		
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="entity">The <see cref="netTiers.PetShop.Product"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.PetShop.Product Property Collection Type Array To Include or Exclude from Load</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public void DeepLoad(netTiers.PetShop.Product entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes)
		{
			#region Argument Validation
			//Argument checks
			if (entity ==  null)
			{
				throw new ArgumentNullException("entity", "The argument netTiers.PetShop.Product, can not be null.");
			}
			if (!Enum.IsDefined(typeof(DeepLoadType), deepLoadType))
			{
				throw new ArgumentException("A valid DeepLoadType option is not present.", "DeepLoadType");
			}
			if (childTypes == null)
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion
			
			//In case an event can trigger the disabling of the deep load
			if (deepLoadType == DeepLoadType.Ignore)
			{
				return;
			}
			
			//Create a HashTable list of types for easy access
			Hashtable innerList = new Hashtable(childTypes.Length);
			for(int i=0; i < childTypes.Length; i++)
			{
				innerList.Add(childTypes[i], childTypes[i].ToString()); 
			}
			
			Debug.Indent();
			Debug.WriteLine("DeepLoad object 'netTiers.PetShop.Product'");
			Debug.Indent();
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetById methods when available
			if ((deepLoadType == DeepLoadType.IncludeChildren && innerList[typeof(netTiers.PetShop. TList<Item>)] != null)
				|| (deepLoadType == DeepLoadType.ExcludeChildren && innerList[typeof(netTiers.PetShop. TList<Item>)] == null))
			{
				Debug.WriteLine("- property 'ItemCollection' loaded.");
				entity.ItemCollection = DataRepository.ItemProvider.GetByProductId(entity.Id);
				if (deep)
				{
					DataRepository.ItemProvider.DeepLoad(entity.ItemCollection, deep, deepLoadType, childTypes);
				}
			}		
			Debug.Unindent();
			Debug.Unindent();
			Debug.WriteLine("");
			return;
		}
		
		#endregion
		
		#region Deep Load By Entity Collection
		/// <summary>
		/// Deep Loads the <see cref="netTiers.PetShop.TList&lt;Product&gt;"/> object with all of the child 
		/// property collections only 1 Level Deep.
		/// </summary>
		/// <remarks>
		/// <c>DeepLoad</c> overloaded methods for a recursive N Level deep loading method.
		/// </remarks>
		/// <param name="entityCollection">the <see cref="netTiers.PetShop.TList&lt;Product&gt;"/> Object to deep loads.</param>
		public void DeepLoad(netTiers.PetShop.TList<Product> entityCollection)
		{
			 DeepLoad(entityCollection, false, DeepLoadType.ExcludeChildren, new Type[] {});
		}
		
		/// <summary>
		/// Deep Loads the <see cref="netTiers.PetShop.TList&lt;Product&gt;"/> object.
		/// </summary>
		/// <remarks>
		/// <c>DeepLoad</c> overloaded methods for a recursive N Level deep loading method.
		/// </remarks>
		/// <param name="entityCollection">the <see cref="netTiers.PetShop.TList&lt;Product&gt;"/> Object to deep loads.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		public void DeepLoad(netTiers.PetShop.TList<Product> entityCollection, bool deep)
		{
			 DeepLoad(entityCollection, deep, DeepLoadType.ExcludeChildren, new Type[] {});
		}	
	
		/// <summary>
		/// Deep Loads the entire <see cref="netTiers.PetShop.TList&lt;Product&gt;"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire collection's object graph.
		/// </remarks>
		/// <param name="entityCollection">The <see cref="netTiers.PetShop.TList&lt;Product&gt;"/> instance to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType"><see cref="DeepLoadType"/> Enumeration to Include/Exclude object property collections from Load.
		///		Use DeepLoadType.[IncludeChildren/ExcludeChildren]WithRecursion to traverse the entire object graph.
		///	</param>
		/// <param name="childTypes"><see cref="netTiers.PetShop.Product"/> Property Collection Type Array To Include or Exclude from Load</param>
		public void DeepLoad(netTiers.PetShop.TList<Product> entityCollection, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes)
		{
			#region Argument Validation
			//Argument checks
			if (entityCollection ==  null)
			{
				throw new ArgumentNullException("entityCollection", "A valid non-null, netTiers.PetShop.TList<Product> object is not present.");
			}
			if (!Enum.IsDefined(typeof(DeepLoadType), deepLoadType))
			{
				throw new ArgumentException("A valid DeepLoadType option is not present.", deepLoadType.ToString());
			}
			if (childTypes == null)
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion
					
			//In case an event can trigger the disabling of the deepload
			if (deepLoadType == DeepLoadType.Ignore)
			{
				return;
			}
			
			foreach (netTiers.PetShop.Product entity in entityCollection)
			{
				DeepLoad(entity, deep, deepLoadType, childTypes);
			}		
			return;
		}
		#endregion
		#endregion 
		
		#region DeepSave
		
		#region Deep Save By Entity
		
		/// <summary>
		/// Deep Save the <see cref="netTiers.PetShop.Product"/> object with all of the child
		/// property collections N Levels Deep.
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product Object</param>
		public bool DeepSave(netTiers.PetShop.Product entity)
		{
			return DeepSave(entity, DeepSaveType.ExcludeChildren, new Type[] {} );
		}
		
		/// <summary>
		/// Deep Save the <see cref="netTiers.PetShop.Product"/> object with all of the child
		/// property collections N Levels Deep.
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product instance</param>
		/// <param name="transactionManager">The transaction manager.</param>
		public bool DeepSave(TransactionManager transactionManager, netTiers.PetShop.Product entity)
		{
			return DeepSave(transactionManager, entity, DeepSaveType.ExcludeChildren, new Type[] {} );
		}
		
		
		
		/// <summary>
		/// Deep Save the entire object graph of the netTiers.PetShop.Product object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="entity">netTiers.PetShop.Product Object</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.
		///	</param>
		/// <param name="childTypes">netTiers.PetShop.Product Property Collection Type Array To Include or Exclude from Save</param>
		public bool DeepSave(netTiers.PetShop.Product entity, DeepSaveType deepSaveType, System.Type[] childTypes)
		{
			return DeepSave(null, entity, deepSaveType, childTypes);
		}
					
		/// <summary>
		/// Deep Save the entire object graph of the netTiers.PetShop.Product object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.PetShop.Product instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.
		///	</param>
		/// <param name="childTypes">netTiers.PetShop.Product Property Collection Type Array To Include or Exclude from Save</param>
		public bool DeepSave(TransactionManager transactionManager, netTiers.PetShop.Product entity, DeepSaveType deepSaveType, System.Type[] childTypes)
		{
			#region Argument Validation
			//Argument checks
			if (entity ==  null)
			{
				throw new ArgumentNullException("entity", "The argument netTiers.PetShop.Product, can not be null.");
			}
			if (!Enum.IsDefined(typeof(DeepSaveType), deepSaveType))
			{
				throw new ArgumentNullException("A valid DeepSaveType option is not present.", "deepSaveType");
			}
			if (childTypes == null)
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion
			
			//In case an event can trigger the disabling of the deepsave
			if (deepSaveType == DeepSaveType.Ignore)
			{
				return true;
			}
			
			//Create a HashTable list of types for easy access
			Hashtable innerList = new Hashtable(childTypes.Length);
			for(int i=0; i < childTypes.Length; i++)
			{
				innerList.Add(childTypes[i], childTypes[i].ToString()); 
			}
	
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
		//deep save child collections  - Call DeepSave() Methods on Children
	
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList[typeof(netTiers.PetShop.TList<Item>)] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[typeof(netTiers.PetShop.TList<Item>)] == null))
			{
				// update each child parent id with the real parent id (mostly used on insert)
				foreach(Item child in entity.ItemCollection)
				{
					child.ProductId = entity.Id;				}
				
				DataRepository.ItemProvider.DeepSave(transactionManager, entity.ItemCollection);
			} 
			
			return true;
		}
		#endregion
		
		#region Deep Save By Entity Collection
		/// <summary>
		/// Deep Save the entire netTiers.PetShop.TList&lt;Product&gt; object with all of the child 
		/// property collections.
		/// </summary>
		/// <param name="entityCollection">netTiers.PetShop.TList&lt;Product&gt; Object</param>
		public bool DeepSave(netTiers.PetShop.TList<Product> entityCollection)
		{
			return DeepSave(null, entityCollection, DeepSaveType.ExcludeChildren, new Type[] {});
		}
		
		/// <summary>
		/// Deep Save the entire netTiers.PetShop.TList&lt;Product&gt; object with all of the child 
		/// property collections.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entityCollection">netTiers.PetShop.TList&lt;Product&gt; Object</param>
		public bool DeepSave(TransactionManager transactionManager, netTiers.PetShop.TList<Product> entityCollection)
		{
			return DeepSave(transactionManager, entityCollection, DeepSaveType.ExcludeChildren, new Type[] {});
		}
		
		/// <summary>
		/// Deep Save the entire object graph of the netTiers.PetShop.TList&lt;Product&gt; object with criteria based of the child 
		/// property collections.
		/// </summary>
		/// <param name="entityCollection">netTiers.PetShop.TList&lt;Product&gt; Object</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.PetShop.Product Property Collection Type Array To Include or Exclude from Save</param>
		public bool DeepSave(netTiers.PetShop.TList<Product> entityCollection, DeepSaveType deepSaveType, System.Type[] childTypes)
		{
			return DeepSave(null, entityCollection, deepSaveType, childTypes);
		}
		
		/// <summary>
		/// Deep Save the entire object graph of the netTiers.PetShop.TList&lt;Product&gt; object with criteria based of the child 
		/// property collections.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entityCollection"><c cref="netTiers.PetShop.TList&lt;Product&gt;"/> instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.PetShop.Product Property Collection Type Array To Include or Exclude from Save</param>
		public bool DeepSave(TransactionManager transactionManager, netTiers.PetShop.TList<Product> entityCollection, DeepSaveType deepSaveType, System.Type[] childTypes)
		{
			#region Argument Validation
			//Argument checks
			if (entityCollection ==  null)
			{
				throw new ArgumentNullException("entityCollection", "A valid non-null, netTiers.PetShop.TList<Product> object is not present.");
			}
			if (!Enum.IsDefined(typeof(DeepSaveType), deepSaveType))
			{
				throw new ArgumentException("A valid DeepSaveType option is not present.", "deepSaveType");
			}
			if (childTypes == null)
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion
					
			//In case an event can trigger the disabling of the deepsave
			if (deepSaveType == DeepSaveType.Ignore)
			{
				return true;
			}
			
			bool deepSaveResult = true;
			bool result;
			
			foreach (netTiers.PetShop.Product entity in entityCollection)
			{
				result = DeepSave(transactionManager, entity, deepSaveType, childTypes);
				if (!result){
					 deepSaveResult = false;
				}
			}
			
			foreach (netTiers.PetShop.Product entity in entityCollection.DeletedItems)
            {
                result = DeepSave(transactionManager, entity, deepSaveType, childTypes);
                if (!result){
                     deepSaveResult = false;
                }
            }

            entityCollection.DeletedItems.Clear();
			
			return deepSaveResult;
		}
		#endregion
		
		#endregion
			
		#endregion "Helper Functions"
		
	}//end class
} // end namespace
