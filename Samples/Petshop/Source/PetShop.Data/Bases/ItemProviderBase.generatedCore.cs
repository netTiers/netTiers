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
	/// This class is the base class for any <see cref="ItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemProviderBaseCore : EntityProviderBase<PetShop.Business.Item, PetShop.Business.ItemKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.ItemKey key)
		{
			return Delete(transactionManager, key.ItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_itemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(string _itemId)
		{
			return Delete(null, _itemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, string _itemId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__ProductId__117F9D94 key.
		///		FK__Item__ProductId__117F9D94 Description: 
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public TList<Item> GetByProductId(string _productId)
		{
			int count = -1;
			return GetByProductId(_productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__ProductId__117F9D94 key.
		///		FK__Item__ProductId__117F9D94 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		/// <remarks></remarks>
		public TList<Item> GetByProductId(TransactionManager transactionManager, string _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__ProductId__117F9D94 key.
		///		FK__Item__ProductId__117F9D94 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public TList<Item> GetByProductId(TransactionManager transactionManager, string _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__ProductId__117F9D94 key.
		///		fkItemProductId117f9d94 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public TList<Item> GetByProductId(string _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__ProductId__117F9D94 key.
		///		fkItemProductId117f9d94 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public TList<Item> GetByProductId(string _productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__ProductId__117F9D94 key.
		///		FK__Item__ProductId__117F9D94 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public abstract TList<Item> GetByProductId(TransactionManager transactionManager, string _productId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__Supplier__1273C1CD key.
		///		FK__Item__Supplier__1273C1CD Description: 
		/// </summary>
		/// <param name="_supplier"></param>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public TList<Item> GetBySupplier(System.Int32? _supplier)
		{
			int count = -1;
			return GetBySupplier(_supplier, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__Supplier__1273C1CD key.
		///		FK__Item__Supplier__1273C1CD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplier"></param>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		/// <remarks></remarks>
		public TList<Item> GetBySupplier(TransactionManager transactionManager, System.Int32? _supplier)
		{
			int count = -1;
			return GetBySupplier(transactionManager, _supplier, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__Supplier__1273C1CD key.
		///		FK__Item__Supplier__1273C1CD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplier"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public TList<Item> GetBySupplier(TransactionManager transactionManager, System.Int32? _supplier, int start, int pageLength)
		{
			int count = -1;
			return GetBySupplier(transactionManager, _supplier, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__Supplier__1273C1CD key.
		///		fkItemSupplier1273c1Cd Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_supplier"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public TList<Item> GetBySupplier(System.Int32? _supplier, int start, int pageLength)
		{
			int count =  -1;
			return GetBySupplier(null, _supplier, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__Supplier__1273C1CD key.
		///		fkItemSupplier1273c1Cd Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_supplier"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public TList<Item> GetBySupplier(System.Int32? _supplier, int start, int pageLength,out int count)
		{
			return GetBySupplier(null, _supplier, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__Supplier__1273C1CD key.
		///		FK__Item__Supplier__1273C1CD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplier"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public abstract TList<Item> GetBySupplier(TransactionManager transactionManager, System.Int32? _supplier, int start, int pageLength, out int count);
		
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
		public override PetShop.Business.Item Get(TransactionManager transactionManager, PetShop.Business.ItemKey key, int start, int pageLength)
		{
			return GetByItemId(transactionManager, key.ItemId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IxItem index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="_itemId"></param>
		/// <param name="_listPrice"></param>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Item&gt;"/> class.</returns>
		public TList<Item> GetByProductIdItemIdListPriceName(string _productId, string _itemId, System.Decimal? _listPrice, string _name)
		{
			int count = -1;
			return GetByProductIdItemIdListPriceName(null,_productId, _itemId, _listPrice, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxItem index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="_itemId"></param>
		/// <param name="_listPrice"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Item&gt;"/> class.</returns>
		public TList<Item> GetByProductIdItemIdListPriceName(string _productId, string _itemId, System.Decimal? _listPrice, string _name, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdItemIdListPriceName(null, _productId, _itemId, _listPrice, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="_itemId"></param>
		/// <param name="_listPrice"></param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Item&gt;"/> class.</returns>
		public TList<Item> GetByProductIdItemIdListPriceName(TransactionManager transactionManager, string _productId, string _itemId, System.Decimal? _listPrice, string _name)
		{
			int count = -1;
			return GetByProductIdItemIdListPriceName(transactionManager, _productId, _itemId, _listPrice, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="_itemId"></param>
		/// <param name="_listPrice"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Item&gt;"/> class.</returns>
		public TList<Item> GetByProductIdItemIdListPriceName(TransactionManager transactionManager, string _productId, string _itemId, System.Decimal? _listPrice, string _name, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdItemIdListPriceName(transactionManager, _productId, _itemId, _listPrice, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IxItem index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="_itemId"></param>
		/// <param name="_listPrice"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Item&gt;"/> class.</returns>
		public TList<Item> GetByProductIdItemIdListPriceName(string _productId, string _itemId, System.Decimal? _listPrice, string _name, int start, int pageLength, out int count)
		{
			return GetByProductIdItemIdListPriceName(null, _productId, _itemId, _listPrice, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IxItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="_itemId"></param>
		/// <param name="_listPrice"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Item&gt;"/> class.</returns>
		public abstract TList<Item> GetByProductIdItemIdListPriceName(TransactionManager transactionManager, string _productId, string _itemId, System.Decimal? _listPrice, string _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Item__727E838B0F975522 index.
		/// </summary>
		/// <param name="_itemId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Item"/> class.</returns>
		public PetShop.Business.Item GetByItemId(string _itemId)
		{
			int count = -1;
			return GetByItemId(null,_itemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Item__727E838B0F975522 index.
		/// </summary>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Item"/> class.</returns>
		public PetShop.Business.Item GetByItemId(string _itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(null, _itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Item__727E838B0F975522 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Item"/> class.</returns>
		public PetShop.Business.Item GetByItemId(TransactionManager transactionManager, string _itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Item__727E838B0F975522 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Item"/> class.</returns>
		public PetShop.Business.Item GetByItemId(TransactionManager transactionManager, string _itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Item__727E838B0F975522 index.
		/// </summary>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Item"/> class.</returns>
		public PetShop.Business.Item GetByItemId(string _itemId, int start, int pageLength, out int count)
		{
			return GetByItemId(null, _itemId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Item__727E838B0F975522 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Item"/> class.</returns>
		public abstract PetShop.Business.Item GetByItemId(TransactionManager transactionManager, string _itemId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Item&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Item&gt;"/></returns>
		public static TList<Item> Fill(IDataReader reader, TList<Item> rows, int start, int pageLength)
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
				
				PetShop.Business.Item c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Item")
					.Append("|").Append((string)reader[((int)ItemColumn.ItemId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Item>(
					key.ToString(), // EntityTrackingKey
					"Item",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Item();
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
					c.ItemId = (string)reader[((int)ItemColumn.ItemId - 1)];
					c.OriginalItemId = c.ItemId;
					c.ProductId = (string)reader[((int)ItemColumn.ProductId - 1)];
					c.ListPrice = (reader.IsDBNull(((int)ItemColumn.ListPrice - 1)))?null:(System.Decimal?)reader[((int)ItemColumn.ListPrice - 1)];
					c.UnitCost = (reader.IsDBNull(((int)ItemColumn.UnitCost - 1)))?null:(System.Decimal?)reader[((int)ItemColumn.UnitCost - 1)];
					c.Supplier = (reader.IsDBNull(((int)ItemColumn.Supplier - 1)))?null:(System.Int32?)reader[((int)ItemColumn.Supplier - 1)];
					c.Status = (reader.IsDBNull(((int)ItemColumn.Status - 1)))?null:(string)reader[((int)ItemColumn.Status - 1)];
					c.Name = (reader.IsDBNull(((int)ItemColumn.Name - 1)))?null:(string)reader[((int)ItemColumn.Name - 1)];
					c.Image = (reader.IsDBNull(((int)ItemColumn.Image - 1)))?null:(string)reader[((int)ItemColumn.Image - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Item"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Item"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Item entity)
		{
			if (!reader.Read()) return;
			
			entity.ItemId = (string)reader[((int)ItemColumn.ItemId - 1)];
			entity.OriginalItemId = (string)reader["ItemId"];
			entity.ProductId = (string)reader[((int)ItemColumn.ProductId - 1)];
			entity.ListPrice = (reader.IsDBNull(((int)ItemColumn.ListPrice - 1)))?null:(System.Decimal?)reader[((int)ItemColumn.ListPrice - 1)];
			entity.UnitCost = (reader.IsDBNull(((int)ItemColumn.UnitCost - 1)))?null:(System.Decimal?)reader[((int)ItemColumn.UnitCost - 1)];
			entity.Supplier = (reader.IsDBNull(((int)ItemColumn.Supplier - 1)))?null:(System.Int32?)reader[((int)ItemColumn.Supplier - 1)];
			entity.Status = (reader.IsDBNull(((int)ItemColumn.Status - 1)))?null:(string)reader[((int)ItemColumn.Status - 1)];
			entity.Name = (reader.IsDBNull(((int)ItemColumn.Name - 1)))?null:(string)reader[((int)ItemColumn.Name - 1)];
			entity.Image = (reader.IsDBNull(((int)ItemColumn.Image - 1)))?null:(string)reader[((int)ItemColumn.Image - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Item"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Item"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Item entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ItemId = (string)dataRow["ItemId"];
			entity.OriginalItemId = (string)dataRow["ItemId"];
			entity.ProductId = (string)dataRow["ProductId"];
			entity.ListPrice = Convert.IsDBNull(dataRow["ListPrice"]) ? null : (System.Decimal?)dataRow["ListPrice"];
			entity.UnitCost = Convert.IsDBNull(dataRow["UnitCost"]) ? null : (System.Decimal?)dataRow["UnitCost"];
			entity.Supplier = Convert.IsDBNull(dataRow["Supplier"]) ? null : (System.Int32?)dataRow["Supplier"];
			entity.Status = Convert.IsDBNull(dataRow["Status"]) ? null : (string)dataRow["Status"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (string)dataRow["Name"];
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
		/// <param name="entity">The <see cref="PetShop.Business.Item"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Item Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Item entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ProductIdSource	
			if (CanDeepLoad(entity, "Product|ProductIdSource", deepLoadType, innerList) 
				&& entity.ProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductId;
				Product tmpEntity = EntityManager.LocateEntity<Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductIdSource = tmpEntity;
				else
					entity.ProductIdSource = DataRepository.ProductProvider.GetByProductId(transactionManager, entity.ProductId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductIdSource

			#region SupplierSource	
			if (CanDeepLoad(entity, "Supplier|SupplierSource", deepLoadType, innerList) 
				&& entity.SupplierSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.Supplier ?? (int)0);
				Supplier tmpEntity = EntityManager.LocateEntity<Supplier>(EntityLocator.ConstructKeyFromPkItems(typeof(Supplier), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SupplierSource = tmpEntity;
				else
					entity.SupplierSource = DataRepository.SupplierProvider.GetBySuppId(transactionManager, (entity.Supplier ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SupplierSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SupplierSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SupplierProvider.DeepLoad(transactionManager, entity.SupplierSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SupplierSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the PetShop.Business.Item object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Item instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Item Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Item entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductIdSource
			if (CanDeepSave(entity, "Product|ProductIdSource", deepSaveType, innerList) 
				&& entity.ProductIdSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdSource);
				entity.ProductId = entity.ProductIdSource.ProductId;
			}
			#endregion 
			
			#region SupplierSource
			if (CanDeepSave(entity, "Supplier|SupplierSource", deepSaveType, innerList) 
				&& entity.SupplierSource != null)
			{
				DataRepository.SupplierProvider.Save(transactionManager, entity.SupplierSource);
				entity.Supplier = entity.SupplierSource.SuppId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region ItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Item</c>
	///</summary>
	public enum ItemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>Supplier</c> at SupplierSource
		///</summary>
		[ChildEntityType(typeof(Supplier))]
		Supplier,
		}
	
	#endregion ItemChildEntityTypes
	
	#region ItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ItemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Item"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemFilterBuilder : SqlFilterBuilder<ItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemFilterBuilder class.
		/// </summary>
		public ItemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemFilterBuilder
	
	#region ItemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ItemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Item"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemParameterBuilder : ParameterizedSqlFilterBuilder<ItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemParameterBuilder class.
		/// </summary>
		public ItemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemParameterBuilder
	
	#region ItemSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ItemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Item"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ItemSortBuilder : SqlSortBuilder<ItemColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemSqlSortBuilder class.
		/// </summary>
		public ItemSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ItemSortBuilder
	
} // end namespace
