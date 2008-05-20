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
	/// This class is the base class for any <see cref="InventoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class InventoryProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.Inventory, netTiers.Petshop.Entities.InventoryKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Functions

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.InventoryKey key)
		{
			return Delete(transactionManager, key.ItemId, key.SuppId, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="itemId">. Primary Key.</param>
		/// <param name="suppId">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid itemId, System.Guid suppId, byte[] timestamp)
		{
			return Delete(null, itemId, suppId, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId">. Primary Key.</param>
		/// <param name="suppId">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid itemId, System.Guid suppId, byte[] timestamp);		
		
		#endregion
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Item key.
		///		FK_Inventory_Item Description: 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetByItemId(System.Guid itemId)
		{
			int count = -1;
			return GetByItemId(itemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Item key.
		///		FK_Inventory_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Inventory> GetByItemId(TransactionManager transactionManager, System.Guid itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Item key.
		///		FK_Inventory_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetByItemId(TransactionManager transactionManager, System.Guid itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Item key.
		///		fK_Inventory_Item Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetByItemId(System.Guid itemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByItemId(null, itemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Item key.
		///		fK_Inventory_Item Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetByItemId(System.Guid itemId, int start, int pageLength,out int count)
		{
			return GetByItemId(null, itemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Item key.
		///		FK_Inventory_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Inventory> GetByItemId(TransactionManager transactionManager, System.Guid itemId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Supplier key.
		///		FK_Inventory_Supplier Description: 
		/// </summary>
		/// <param name="suppId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetBySuppId(System.Guid suppId)
		{
			int count = -1;
			return GetBySuppId(suppId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Supplier key.
		///		FK_Inventory_Supplier Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Inventory> GetBySuppId(TransactionManager transactionManager, System.Guid suppId)
		{
			int count = -1;
			return GetBySuppId(transactionManager, suppId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Supplier key.
		///		FK_Inventory_Supplier Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetBySuppId(TransactionManager transactionManager, System.Guid suppId, int start, int pageLength)
		{
			int count = -1;
			return GetBySuppId(transactionManager, suppId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Supplier key.
		///		fK_Inventory_Supplier Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="suppId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetBySuppId(System.Guid suppId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySuppId(null, suppId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Supplier key.
		///		fK_Inventory_Supplier Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="suppId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetBySuppId(System.Guid suppId, int start, int pageLength,out int count)
		{
			return GetBySuppId(null, suppId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Inventory_Supplier key.
		///		FK_Inventory_Supplier Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Inventory objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Inventory> GetBySuppId(TransactionManager transactionManager, System.Guid suppId, int start, int pageLength, out int count);
		
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
		public override netTiers.Petshop.Entities.Inventory Get(TransactionManager transactionManager, netTiers.Petshop.Entities.InventoryKey key, int start, int pageLength)
		{
			return GetByItemIdSuppId(transactionManager, key.ItemId, key.SuppId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Inventory index.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="suppId"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Inventory"/> class.</returns>
		public netTiers.Petshop.Entities.Inventory GetByItemIdSuppId(System.Guid itemId, System.Guid suppId)
		{
			int count = -1;
			return GetByItemIdSuppId(null,itemId, suppId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Inventory index.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Inventory"/> class.</returns>
		public netTiers.Petshop.Entities.Inventory GetByItemIdSuppId(System.Guid itemId, System.Guid suppId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemIdSuppId(null, itemId, suppId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Inventory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="suppId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Inventory"/> class.</returns>
		public netTiers.Petshop.Entities.Inventory GetByItemIdSuppId(TransactionManager transactionManager, System.Guid itemId, System.Guid suppId)
		{
			int count = -1;
			return GetByItemIdSuppId(transactionManager, itemId, suppId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Inventory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Inventory"/> class.</returns>
		public netTiers.Petshop.Entities.Inventory GetByItemIdSuppId(TransactionManager transactionManager, System.Guid itemId, System.Guid suppId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemIdSuppId(transactionManager, itemId, suppId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Inventory index.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Inventory"/> class.</returns>
		public netTiers.Petshop.Entities.Inventory GetByItemIdSuppId(System.Guid itemId, System.Guid suppId, int start, int pageLength, out int count)
		{
			return GetByItemIdSuppId(null, itemId, suppId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Inventory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Inventory"/> class.</returns>
		public abstract netTiers.Petshop.Entities.Inventory GetByItemIdSuppId(TransactionManager transactionManager, System.Guid itemId, System.Guid suppId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		#region CSP_Inventory_GetMaxSupplier 
		
		/// <summary>
		///	This method wrap the 'CSP_Inventory_GetMaxSupplier' stored procedure. 
		/// </summary>
			/// <param name="itemId"> A <c>System.Guid?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="netTiers.Petshop.Entities.TList&lt;Inventory&gt;"/> instance.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetMaxSupplier(System.Guid? itemId)
		{
			return GetMaxSupplier(null, 0, int.MaxValue , itemId);
		}
		
		/// <summary>
		///	This method wrap the 'CSP_Inventory_GetMaxSupplier' stored procedure. 
		/// </summary>
			/// <param name="itemId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="netTiers.Petshop.Entities.TList&lt;Inventory&gt;"/> instance.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetMaxSupplier(int start, int pageLength, System.Guid? itemId)
		{
			return GetMaxSupplier(null, start, pageLength , itemId);
		}
				
		/// <summary>
		///	This method wrap the 'CSP_Inventory_GetMaxSupplier' stored procedure. 
		/// </summary>
			/// <param name="itemId"> A <c>System.Guid?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="netTiers.Petshop.Entities.TList&lt;Inventory&gt;"/> instance.</returns>
		public netTiers.Petshop.Entities.TList<Inventory> GetMaxSupplier(TransactionManager transactionManager, System.Guid? itemId)
		{
			return GetMaxSupplier(0, int.MaxValue , itemId);
		}
		
		/// <summary>
		///	This method wrap the 'CSP_Inventory_GetMaxSupplier' stored procedure. 
		/// </summary>
			/// <param name="itemId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="netTiers.Petshop.Entities.TList&lt;Inventory&gt;"/> instance.</returns>
		public abstract netTiers.Petshop.Entities.TList<Inventory> GetMaxSupplier(TransactionManager transactionManager, int start, int pageLength , System.Guid? itemId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;Inventory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;Inventory&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<Inventory> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<Inventory> rows, int start, int pageLength)
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
				
				netTiers.Petshop.Entities.Inventory c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Inventory" 
							+ (reader.IsDBNull(reader.GetOrdinal("ItemId"))?Guid.Empty:(System.Guid)reader["ItemId"]).ToString()
							+ (reader.IsDBNull(reader.GetOrdinal("SuppId"))?Guid.Empty:(System.Guid)reader["SuppId"]).ToString();

					c = EntityManager.LocateOrCreate<Inventory>(
						key.ToString(), // EntityTrackingKey 
						"Inventory",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.Inventory();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ItemId = (System.Guid)reader["ItemId"];
					c.OriginalItemId = c.ItemId; //(reader.IsDBNull(reader.GetOrdinal("ItemId")))?Guid.Empty:(System.Guid)reader["ItemId"];
					c.SuppId = (System.Guid)reader["SuppId"];
					c.OriginalSuppId = c.SuppId; //(reader.IsDBNull(reader.GetOrdinal("SuppId")))?Guid.Empty:(System.Guid)reader["SuppId"];
					c.Qty = (System.Int32)reader["Qty"];
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
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Inventory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Inventory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.Inventory entity)
		{
			if (!reader.Read()) return;
			
			entity.ItemId = (System.Guid)reader["ItemId"];
			entity.OriginalItemId = (System.Guid)reader["ItemId"];
			entity.SuppId = (System.Guid)reader["SuppId"];
			entity.OriginalSuppId = (System.Guid)reader["SuppId"];
			entity.Qty = (System.Int32)reader["Qty"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Inventory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Inventory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.Inventory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ItemId = (System.Guid)dataRow["ItemId"];
			entity.OriginalItemId = (System.Guid)dataRow["ItemId"];
			entity.SuppId = (System.Guid)dataRow["SuppId"];
			entity.OriginalSuppId = (System.Guid)dataRow["SuppId"];
			entity.Qty = (System.Int32)dataRow["Qty"];
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
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Inventory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Inventory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.Inventory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ItemIdSource	
			if (CanDeepLoad(entity, "Item", "ItemIdSource", deepLoadType, innerList) 
				&& entity.ItemIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ItemId;
				Item tmpEntity = EntityManager.LocateEntity<Item>(EntityLocator.ConstructKeyFromPkItems(typeof(Item), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ItemIdSource = tmpEntity;
				else
					entity.ItemIdSource = DataRepository.ItemProvider.GetById(entity.ItemId);
			
				if (deep && entity.ItemIdSource != null)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ItemIdSource

			#region SuppIdSource	
			if (CanDeepLoad(entity, "Supplier", "SuppIdSource", deepLoadType, innerList) 
				&& entity.SuppIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SuppId;
				Supplier tmpEntity = EntityManager.LocateEntity<Supplier>(EntityLocator.ConstructKeyFromPkItems(typeof(Supplier), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SuppIdSource = tmpEntity;
				else
					entity.SuppIdSource = DataRepository.SupplierProvider.GetBySuppId(entity.SuppId);
			
				if (deep && entity.SuppIdSource != null)
				{
					DataRepository.SupplierProvider.DeepLoad(transactionManager, entity.SuppIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion SuppIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.Inventory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.Inventory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Inventory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.Inventory entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ItemIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Item"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Item"] == null))
			{
				if (entity.ItemIdSource != null )
				{			
					DataRepository.ItemProvider.Save(transactionManager, entity.ItemIdSource);
				}
			}
			#endregion 
			
			#region SuppIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Supplier"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Supplier"] == null))
			{
				if (entity.SuppIdSource != null )
				{			
					DataRepository.SupplierProvider.Save(transactionManager, entity.SuppIdSource);
				}
			}
			#endregion 
			#endregion Composite Source Properties

		}
		#endregion
	} // end class
	
	#region InventoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.Inventory</c>
	///</summary>
	public enum InventoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Item</c> at ItemIdSource
		///</summary>
		[ChildEntityType(typeof(Item))]
		Item,
			
		///<summary>
		/// Composite Property for <c>Supplier</c> at SuppIdSource
		///</summary>
		[ChildEntityType(typeof(Supplier))]
		Supplier,
		}
	
	#endregion InventoryChildEntityTypes
	
	#region InventoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Inventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InventoryFilterBuilder : SqlFilterBuilder<InventoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InventoryFilterBuilder class.
		/// </summary>
		public InventoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InventoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InventoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InventoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InventoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InventoryFilterBuilder
} // end namespace
