#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.Item, netTiers.Petshop.Entities.ItemKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetBySuppIdFromInventory
		
		/// <summary>
		///		Gets Item objects from the datasource by SuppId in the
		///		Inventory table. Table Item is related to table Supplier
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="suppId"></param>
		/// <returns>Returns a typed collection of Item objects.</returns>
		public TList<Item> GetBySuppIdFromInventory(System.Guid suppId)
		{
			int count = -1;
			return GetBySuppIdFromInventory(null,suppId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets netTiers.Petshop.Entities.Item objects from the datasource by SuppId in the
		///		Inventory table. Table Item is related to table Supplier
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="suppId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Item objects.</returns>
		public TList<Item> GetBySuppIdFromInventory(System.Guid suppId, int start, int pageLength)
		{
			int count = -1;
			return GetBySuppIdFromInventory(null, suppId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Item objects from the datasource by SuppId in the
		///		Inventory table. Table Item is related to table Supplier
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Item objects.</returns>
		public TList<Item> GetBySuppIdFromInventory(TransactionManager transactionManager, System.Guid suppId)
		{
			int count = -1;
			return GetBySuppIdFromInventory(transactionManager, suppId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Item objects from the datasource by SuppId in the
		///		Inventory table. Table Item is related to table Supplier
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Item objects.</returns>
		public TList<Item> GetBySuppIdFromInventory(TransactionManager transactionManager, System.Guid suppId,int start, int pageLength)
		{
			int count = -1;
			return GetBySuppIdFromInventory(transactionManager, suppId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Item objects from the datasource by SuppId in the
		///		Inventory table. Table Item is related to table Supplier
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Item objects.</returns>
		public TList<Item> GetBySuppIdFromInventory(System.Guid suppId,int start, int pageLength, out int count)
		{
			
			return GetBySuppIdFromInventory(null, suppId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Item objects from the datasource by SuppId in the
		///		Inventory table. Table Item is related to table Supplier
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="suppId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Item objects.</returns>
		public abstract TList<Item> GetBySuppIdFromInventory(TransactionManager transactionManager,System.Guid suppId, int start, int pageLength, out int count);
		
		#endregion GetBySuppIdFromInventory
		
		#endregion	
		
		#region Delete Functions

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.ItemKey key)
		{
			return Delete(transactionManager, key.Id, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid id, byte[] timestamp)
		{
			return Delete(null, id, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid id, byte[] timestamp);		
		
		#endregion
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Item_Product key.
		///		FK_Item_Product Description: 
		/// </summary>
		/// <param name="productId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Item objects.</returns>
		public netTiers.Petshop.Entities.TList<Item> GetByProductId(System.Guid productId)
		{
			int count = -1;
			return GetByProductId(productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Item_Product key.
		///		FK_Item_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Item objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Item> GetByProductId(TransactionManager transactionManager, System.Guid productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Item_Product key.
		///		FK_Item_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Item objects.</returns>
		public netTiers.Petshop.Entities.TList<Item> GetByProductId(TransactionManager transactionManager, System.Guid productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Item_Product key.
		///		fK_Item_Product Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Item objects.</returns>
		public netTiers.Petshop.Entities.TList<Item> GetByProductId(System.Guid productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Item_Product key.
		///		fK_Item_Product Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Item objects.</returns>
		public netTiers.Petshop.Entities.TList<Item> GetByProductId(System.Guid productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Item_Product key.
		///		FK_Item_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Item objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Item> GetByProductId(TransactionManager transactionManager, System.Guid productId, int start, int pageLength, out int count);
		
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
		public override netTiers.Petshop.Entities.Item Get(TransactionManager transactionManager, netTiers.Petshop.Entities.ItemKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Item index.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Item"/> class.</returns>
		public netTiers.Petshop.Entities.Item GetById(System.Guid id)
		{
			int count = -1;
			return GetById(null,id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Item index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Item"/> class.</returns>
		public netTiers.Petshop.Entities.Item GetById(System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Item index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Item"/> class.</returns>
		public netTiers.Petshop.Entities.Item GetById(TransactionManager transactionManager, System.Guid id)
		{
			int count = -1;
			return GetById(transactionManager, id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Item index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Item"/> class.</returns>
		public netTiers.Petshop.Entities.Item GetById(TransactionManager transactionManager, System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Item index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Item"/> class.</returns>
		public netTiers.Petshop.Entities.Item GetById(System.Guid id, int start, int pageLength, out int count)
		{
			return GetById(null, id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Item index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Item"/> class.</returns>
		public abstract netTiers.Petshop.Entities.Item GetById(TransactionManager transactionManager, System.Guid id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;Item&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;Item&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<Item> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<Item> rows, int start, int pageLength)
		{
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
				
				netTiers.Petshop.Entities.Item c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Item" 
							+ (reader.IsDBNull(reader.GetOrdinal("Id"))?Guid.Empty:(System.Guid)reader["Id"]).ToString();

					c = EntityManager.LocateOrCreate<Item>(
						key.ToString(), // EntityTrackingKey 
						"Item",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.Item();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.Id = (System.Guid)reader["Id"];
					c.OriginalId = c.Id; //(reader.IsDBNull(reader.GetOrdinal("Id")))?Guid.Empty:(System.Guid)reader["Id"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.Price = (reader.IsDBNull(reader.GetOrdinal("Price")))?null:(System.Double?)reader["Price"];
					c.Currency = (reader.IsDBNull(reader.GetOrdinal("Currency")))?null:(System.String)reader["Currency"];
					c.Photo = (reader.IsDBNull(reader.GetOrdinal("Photo")))?null:(System.String)reader["Photo"];
					c.ProductId = (System.Guid)reader["ProductId"];
					c.Timestamp = (System.Byte[])reader["Timestamp"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Item"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Item"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.Item entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Guid)reader["Id"];
			entity.OriginalId = (System.Guid)reader["Id"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.Price = (reader.IsDBNull(reader.GetOrdinal("Price")))?null:(System.Double?)reader["Price"];
			entity.Currency = (reader.IsDBNull(reader.GetOrdinal("Currency")))?null:(System.String)reader["Currency"];
			entity.Photo = (reader.IsDBNull(reader.GetOrdinal("Photo")))?null:(System.String)reader["Photo"];
			entity.ProductId = (System.Guid)reader["ProductId"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Item"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Item"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.Item entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Guid)dataRow["Id"];
			entity.OriginalId = (System.Guid)dataRow["Id"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.Price = (Convert.IsDBNull(dataRow["Price"]))?null:(System.Double?)dataRow["Price"];
			entity.Currency = (Convert.IsDBNull(dataRow["Currency"]))?null:(System.String)dataRow["Currency"];
			entity.Photo = (Convert.IsDBNull(dataRow["Photo"]))?null:(System.String)dataRow["Photo"];
			entity.ProductId = (System.Guid)dataRow["ProductId"];
			entity.Timestamp = (System.Byte[])dataRow["Timestamp"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Item"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Item Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.Item entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ProductIdSource	
			if (CanDeepLoad(entity, "Product", "ProductIdSource", deepLoadType, innerList) 
				&& entity.ProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductId;
				Product tmpEntity = EntityManager.LocateEntity<Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductIdSource = tmpEntity;
				else
					entity.ProductIdSource = DataRepository.ProductProvider.GetById(entity.ProductId);
			
				if (deep && entity.ProductIdSource != null)
				{
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProductIdSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetById methods when available
			
			#region LineItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<LineItem>", "LineItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'LineItemCollection' loaded.");
				#endif 

				entity.LineItemCollection = DataRepository.LineItemProvider.GetByItemId(transactionManager, entity.Id);

				if (deep && entity.LineItemCollection.Count > 0)
				{
					DataRepository.LineItemProvider.DeepLoad(transactionManager, entity.LineItemCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region InventoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Inventory>", "InventoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'InventoryCollection' loaded.");
				#endif 

				entity.InventoryCollection = DataRepository.InventoryProvider.GetByItemId(transactionManager, entity.Id);

				if (deep && entity.InventoryCollection.Count > 0)
				{
					DataRepository.InventoryProvider.DeepLoad(transactionManager, entity.InventoryCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region SupplierCollection_From_Inventory
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Supplier>", "SupplierCollection_From_Inventory", deepLoadType, innerList))
			{
				entity.SupplierCollection_From_Inventory = DataRepository.SupplierProvider.GetByItemIdFromInventory(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'SupplierCollection_From_Inventory' loaded.");
				#endif 

				if (deep && entity.SupplierCollection_From_Inventory.Count > 0)
				{
					DataRepository.SupplierProvider.DeepLoad(transactionManager, entity.SupplierCollection_From_Inventory, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion SupplierCollection_From_Inventory
			
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.Item object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.Item instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Item Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.Item entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Product"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Product"] == null))
			{
				if (entity.ProductIdSource != null )
				{			
					DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdSource);
				}
			}
			#endregion 
			#endregion Composite Source Properties


			#region List<LineItem>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<LineItem>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<LineItem>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(LineItem child in entity.LineItemCollection)
			{
					child.ItemId = entity.Id;			}
			
			if (entity.LineItemCollection.Count > 0)
				DataRepository.LineItemProvider.DeepSave(transactionManager, entity.LineItemCollection, deepSaveType, childTypes);
			} 
			#endregion 

			#region List<Inventory>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<Inventory>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<Inventory>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(Inventory child in entity.InventoryCollection)
			{
					child.ItemId = entity.Id;			}
			
			if (entity.InventoryCollection.Count > 0)
				DataRepository.InventoryProvider.DeepSave(transactionManager, entity.InventoryCollection, deepSaveType, childTypes);
			} 
			#endregion 

			#region List<Supplier>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<Supplier>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<Supplier>"] == null))
			{
				if (entity.SupplierCollection_From_Inventory.Count > 0)
					DataRepository.SupplierProvider.DeepSave(transactionManager, entity.SupplierCollection_From_Inventory, deepSaveType, childTypes); 
			}
			#endregion 
		}
		#endregion
	} // end class
	
	#region ItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.Item</c>
	///</summary>
	public enum ItemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
	
		///<summary>
		/// Collection of <c>Item</c> as OneToMany for LineItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<LineItem>))]
		LineItemCollection,

		///<summary>
		/// Collection of <c>Item</c> as OneToMany for InventoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<Inventory>))]
		InventoryCollection,

		///<summary>
		/// Collection of <c>Item</c> as ManyToMany for SupplierCollection_From_Inventory
		///</summary>
		[ChildEntityType(typeof(TList<Supplier>))]
		SupplierCollection_From_Inventory,
	}
	
	#endregion ItemChildEntityTypes
	
	#region ItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
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
} // end namespace
