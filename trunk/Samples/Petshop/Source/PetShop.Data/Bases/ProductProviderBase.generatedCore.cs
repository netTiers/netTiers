#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using PetShop.Business;
using PetShop.Data;

#endregion

namespace PetShop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductProviderBaseCore : EntityProviderBase<PetShop.Business.Product, PetShop.Business.ProductKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.ProductKey key)
		{
			return Delete(transactionManager, key.ProductId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(string _productId)
		{
			return Delete(null, _productId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, string _productId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override PetShop.Business.Product Get(TransactionManager transactionManager, PetShop.Business.ProductKey key, int start, int pageLength)
		{
			return GetByProductId(transactionManager, key.ProductId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IxProduct1 index.
		/// </summary>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByName(string _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct1 index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByName(string _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByName(TransactionManager transactionManager, string _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByName(TransactionManager transactionManager, string _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct1 index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByName(string _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public abstract TList<Product> GetByName(TransactionManager transactionManager, string _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IxProduct2 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryId(string _categoryId)
		{
			int count = -1;
			return GetByCategoryId(null,_categoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct2 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryId(string _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryId(TransactionManager transactionManager, string _categoryId)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryId(TransactionManager transactionManager, string _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct2 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryId(string _categoryId, int start, int pageLength, out int count)
		{
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public abstract TList<Product> GetByCategoryId(TransactionManager transactionManager, string _categoryId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IxProduct3 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdName(string _categoryId, string _name)
		{
			int count = -1;
			return GetByCategoryIdName(null,_categoryId, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct3 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdName(string _categoryId, string _name, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryIdName(null, _categoryId, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdName(TransactionManager transactionManager, string _categoryId, string _name)
		{
			int count = -1;
			return GetByCategoryIdName(transactionManager, _categoryId, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdName(TransactionManager transactionManager, string _categoryId, string _name, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryIdName(transactionManager, _categoryId, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct3 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdName(string _categoryId, string _name, int start, int pageLength, out int count)
		{
			return GetByCategoryIdName(null, _categoryId, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public abstract TList<Product> GetByCategoryIdName(TransactionManager transactionManager, string _categoryId, string _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IxProduct4 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="_productId"></param>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdProductIdName(string _categoryId, string _productId, string _name)
		{
			int count = -1;
			return GetByCategoryIdProductIdName(null,_categoryId, _productId, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct4 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="_productId"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdProductIdName(string _categoryId, string _productId, string _name, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryIdProductIdName(null, _categoryId, _productId, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="_productId"></param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdProductIdName(TransactionManager transactionManager, string _categoryId, string _productId, string _name)
		{
			int count = -1;
			return GetByCategoryIdProductIdName(transactionManager, _categoryId, _productId, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="_productId"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdProductIdName(TransactionManager transactionManager, string _categoryId, string _productId, string _name, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryIdProductIdName(transactionManager, _categoryId, _productId, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct4 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="_productId"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public TList<Product> GetByCategoryIdProductIdName(string _categoryId, string _productId, string _name, int start, int pageLength, out int count)
		{
			return GetByCategoryIdProductIdName(null, _categoryId, _productId, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IxProduct4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="_productId"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Product&gt;"/> class.</returns>
		public abstract TList<Product> GetByCategoryIdProductIdName(TransactionManager transactionManager, string _categoryId, string _productId, string _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Product__B40CC6CD0AD2A005 index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Product"/> class.</returns>
		public PetShop.Business.Product GetByProductId(string _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Product__B40CC6CD0AD2A005 index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Product"/> class.</returns>
		public PetShop.Business.Product GetByProductId(string _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Product__B40CC6CD0AD2A005 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Product"/> class.</returns>
		public PetShop.Business.Product GetByProductId(TransactionManager transactionManager, string _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Product__B40CC6CD0AD2A005 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Product"/> class.</returns>
		public PetShop.Business.Product GetByProductId(TransactionManager transactionManager, string _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Product__B40CC6CD0AD2A005 index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Product"/> class.</returns>
		public PetShop.Business.Product GetByProductId(string _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Product__B40CC6CD0AD2A005 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Product"/> class.</returns>
		public abstract PetShop.Business.Product GetByProductId(TransactionManager transactionManager, string _productId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Product&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Product&gt;"/></returns>
		public static TList<Product> Fill(IDataReader reader, TList<Product> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				PetShop.Business.Product c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Product")
					.Append("|").Append((string)reader[((int)ProductColumn.ProductId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Product>(
					key.ToString(), // EntityTrackingKey
					"Product",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Product();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.ProductId = (string)reader[((int)ProductColumn.ProductId - 1)];
					c.OriginalProductId = c.ProductId;
					c.CategoryId = (string)reader[((int)ProductColumn.CategoryId - 1)];
					c.Name = (reader.IsDBNull(((int)ProductColumn.Name - 1)))?null:(string)reader[((int)ProductColumn.Name - 1)];
					c.Descn = (reader.IsDBNull(((int)ProductColumn.Descn - 1)))?null:(string)reader[((int)ProductColumn.Descn - 1)];
					c.Image = (reader.IsDBNull(((int)ProductColumn.Image - 1)))?null:(string)reader[((int)ProductColumn.Image - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Product"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Product"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Product entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductId = (string)reader[((int)ProductColumn.ProductId - 1)];
			entity.OriginalProductId = (string)reader["ProductId"];
			entity.CategoryId = (string)reader[((int)ProductColumn.CategoryId - 1)];
			entity.Name = (reader.IsDBNull(((int)ProductColumn.Name - 1)))?null:(string)reader[((int)ProductColumn.Name - 1)];
			entity.Descn = (reader.IsDBNull(((int)ProductColumn.Descn - 1)))?null:(string)reader[((int)ProductColumn.Descn - 1)];
			entity.Image = (reader.IsDBNull(((int)ProductColumn.Image - 1)))?null:(string)reader[((int)ProductColumn.Image - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Product"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Product"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Product entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (string)dataRow["ProductId"];
			entity.OriginalProductId = (string)dataRow["ProductId"];
			entity.CategoryId = (string)dataRow["CategoryId"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (string)dataRow["Name"];
			entity.Descn = Convert.IsDBNull(dataRow["Descn"]) ? null : (string)dataRow["Descn"];
			entity.Image = Convert.IsDBNull(dataRow["Image"]) ? null : (string)dataRow["Image"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="PetShop.Business.Product"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Product Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Product entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CategoryIdSource	
			if (CanDeepLoad(entity, "Category|CategoryIdSource", deepLoadType, innerList) 
				&& entity.CategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CategoryId;
				Category tmpEntity = EntityManager.LocateEntity<Category>(EntityLocator.ConstructKeyFromPkItems(typeof(Category), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CategoryIdSource = tmpEntity;
				else
					entity.CategoryIdSource = DataRepository.CategoryProvider.GetByCategoryId(transactionManager, entity.CategoryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CategoryProvider.DeepLoad(transactionManager, entity.CategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CategoryIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProductId methods when available
			
			#region ItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Item>|ItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ItemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ItemCollection = DataRepository.ItemProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ItemCollection.Count > 0)
				{
					deepHandles.Add("ItemCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Item>) DataRepository.ItemProvider.DeepLoad,
						new object[] { transactionManager, entity.ItemCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the PetShop.Business.Product object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Product instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Product Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Product entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CategoryIdSource
			if (CanDeepSave(entity, "Category|CategoryIdSource", deepSaveType, innerList) 
				&& entity.CategoryIdSource != null)
			{
				DataRepository.CategoryProvider.Save(transactionManager, entity.CategoryIdSource);
				entity.CategoryId = entity.CategoryIdSource.CategoryId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Item>
				if (CanDeepSave(entity.ItemCollection, "List<Item>|ItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Item child in entity.ItemCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.ProductId;
						}
						else
						{
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.ItemCollection.Count > 0 || entity.ItemCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ItemProvider.Save(transactionManager, entity.ItemCollection);
						
						deepHandles.Add("ItemCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Item >) DataRepository.ItemProvider.DeepSave,
							new object[] { transactionManager, entity.ItemCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region ProductChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Product</c>
	///</summary>
	public enum ProductChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Category</c> at CategoryIdSource
		///</summary>
		[ChildEntityType(typeof(Category))]
		Category,
	
		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<Item>))]
		ItemCollection,
	}
	
	#endregion ProductChildEntityTypes
	
	#region ProductFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductFilterBuilder : SqlFilterBuilder<ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		public ProductFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductFilterBuilder
	
	#region ProductParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductParameterBuilder : ParameterizedSqlFilterBuilder<ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		public ProductParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductParameterBuilder
	
	#region ProductSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductSortBuilder : SqlSortBuilder<ProductColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSqlSortBuilder class.
		/// </summary>
		public ProductSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductSortBuilder
	
} // end namespace
