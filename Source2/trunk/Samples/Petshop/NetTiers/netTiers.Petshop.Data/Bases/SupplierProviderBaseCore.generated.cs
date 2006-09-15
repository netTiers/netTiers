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
	/// This class is the base class for any <see cref="SupplierProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SupplierProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.Supplier, netTiers.Petshop.Entities.SupplierKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByItemIdFromInventory
		
		/// <summary>
		///		Gets Supplier objects from the datasource by ItemId in the
		///		Inventory table. Table Supplier is related to table Item
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of Supplier objects.</returns>
		public TList<Supplier> GetByItemIdFromInventory(System.Guid itemId)
		{
			int count = -1;
			return GetByItemIdFromInventory(null,itemId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets netTiers.Petshop.Entities.Supplier objects from the datasource by ItemId in the
		///		Inventory table. Table Supplier is related to table Item
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Supplier objects.</returns>
		public TList<Supplier> GetByItemIdFromInventory(System.Guid itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemIdFromInventory(null, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Supplier objects from the datasource by ItemId in the
		///		Inventory table. Table Supplier is related to table Item
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Supplier objects.</returns>
		public TList<Supplier> GetByItemIdFromInventory(TransactionManager transactionManager, System.Guid itemId)
		{
			int count = -1;
			return GetByItemIdFromInventory(transactionManager, itemId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Supplier objects from the datasource by ItemId in the
		///		Inventory table. Table Supplier is related to table Item
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Supplier objects.</returns>
		public TList<Supplier> GetByItemIdFromInventory(TransactionManager transactionManager, System.Guid itemId,int start, int pageLength)
		{
			int count = -1;
			return GetByItemIdFromInventory(transactionManager, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Supplier objects from the datasource by ItemId in the
		///		Inventory table. Table Supplier is related to table Item
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Supplier objects.</returns>
		public TList<Supplier> GetByItemIdFromInventory(System.Guid itemId,int start, int pageLength, out int count)
		{
			
			return GetByItemIdFromInventory(null, itemId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Supplier objects from the datasource by ItemId in the
		///		Inventory table. Table Supplier is related to table Item
		///		through the (M:N) relationship defined in the Inventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Supplier objects.</returns>
		public abstract TList<Supplier> GetByItemIdFromInventory(TransactionManager transactionManager,System.Guid itemId, int start, int pageLength, out int count);
		
		#endregion GetByItemIdFromInventory
		
		#endregion	
		
		#region Delete Functions

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.SupplierKey key)
		{
			return Delete(transactionManager, key.SuppId, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="suppId">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid suppId, byte[] timestamp)
		{
			return Delete(null, suppId, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid suppId, byte[] timestamp);		
		
		#endregion
		
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
		public override netTiers.Petshop.Entities.Supplier Get(TransactionManager transactionManager, netTiers.Petshop.Entities.SupplierKey key, int start, int pageLength)
		{
			return GetBySuppId(transactionManager, key.SuppId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Supplier__0425A276 index.
		/// </summary>
		/// <param name="suppId"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Supplier"/> class.</returns>
		public netTiers.Petshop.Entities.Supplier GetBySuppId(System.Guid suppId)
		{
			int count = -1;
			return GetBySuppId(null,suppId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__0425A276 index.
		/// </summary>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Supplier"/> class.</returns>
		public netTiers.Petshop.Entities.Supplier GetBySuppId(System.Guid suppId, int start, int pageLength)
		{
			int count = -1;
			return GetBySuppId(null, suppId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__0425A276 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Supplier"/> class.</returns>
		public netTiers.Petshop.Entities.Supplier GetBySuppId(TransactionManager transactionManager, System.Guid suppId)
		{
			int count = -1;
			return GetBySuppId(transactionManager, suppId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__0425A276 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Supplier"/> class.</returns>
		public netTiers.Petshop.Entities.Supplier GetBySuppId(TransactionManager transactionManager, System.Guid suppId, int start, int pageLength)
		{
			int count = -1;
			return GetBySuppId(transactionManager, suppId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__0425A276 index.
		/// </summary>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Supplier"/> class.</returns>
		public netTiers.Petshop.Entities.Supplier GetBySuppId(System.Guid suppId, int start, int pageLength, out int count)
		{
			return GetBySuppId(null, suppId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__0425A276 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Supplier"/> class.</returns>
		public abstract netTiers.Petshop.Entities.Supplier GetBySuppId(TransactionManager transactionManager, System.Guid suppId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;Supplier&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;Supplier&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<Supplier> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<Supplier> rows, int start, int pageLength)
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
				
				netTiers.Petshop.Entities.Supplier c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Supplier" 
							+ (reader.IsDBNull(reader.GetOrdinal("SuppId"))?Guid.Empty:(System.Guid)reader["SuppId"]).ToString();

					c = EntityManager.LocateOrCreate<Supplier>(
						key.ToString(), // EntityTrackingKey 
						"Supplier",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.Supplier();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.SuppId = (System.Guid)reader["SuppId"];
					c.OriginalSuppId = c.SuppId; //(reader.IsDBNull(reader.GetOrdinal("SuppId")))?Guid.Empty:(System.Guid)reader["SuppId"];
					c.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
					c.Status = (System.String)reader["Status"];
					c.Addr1 = (reader.IsDBNull(reader.GetOrdinal("Addr1")))?null:(System.String)reader["Addr1"];
					c.Addr2 = (reader.IsDBNull(reader.GetOrdinal("Addr2")))?null:(System.String)reader["Addr2"];
					c.City = (reader.IsDBNull(reader.GetOrdinal("City")))?null:(System.String)reader["City"];
					c.State = (reader.IsDBNull(reader.GetOrdinal("State")))?null:(System.String)reader["State"];
					c.Zip = (reader.IsDBNull(reader.GetOrdinal("Zip")))?null:(System.String)reader["Zip"];
					c.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
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
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Supplier"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Supplier"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.Supplier entity)
		{
			if (!reader.Read()) return;
			
			entity.SuppId = (System.Guid)reader["SuppId"];
			entity.OriginalSuppId = (System.Guid)reader["SuppId"];
			entity.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
			entity.Status = (System.String)reader["Status"];
			entity.Addr1 = (reader.IsDBNull(reader.GetOrdinal("Addr1")))?null:(System.String)reader["Addr1"];
			entity.Addr2 = (reader.IsDBNull(reader.GetOrdinal("Addr2")))?null:(System.String)reader["Addr2"];
			entity.City = (reader.IsDBNull(reader.GetOrdinal("City")))?null:(System.String)reader["City"];
			entity.State = (reader.IsDBNull(reader.GetOrdinal("State")))?null:(System.String)reader["State"];
			entity.Zip = (reader.IsDBNull(reader.GetOrdinal("Zip")))?null:(System.String)reader["Zip"];
			entity.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Supplier"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Supplier"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.Supplier entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SuppId = (System.Guid)dataRow["SuppId"];
			entity.OriginalSuppId = (System.Guid)dataRow["SuppId"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?null:(System.String)dataRow["Name"];
			entity.Status = (System.String)dataRow["Status"];
			entity.Addr1 = (Convert.IsDBNull(dataRow["Addr1"]))?null:(System.String)dataRow["Addr1"];
			entity.Addr2 = (Convert.IsDBNull(dataRow["Addr2"]))?null:(System.String)dataRow["Addr2"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?null:(System.String)dataRow["City"];
			entity.State = (Convert.IsDBNull(dataRow["State"]))?null:(System.String)dataRow["State"];
			entity.Zip = (Convert.IsDBNull(dataRow["Zip"]))?null:(System.String)dataRow["Zip"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?null:(System.String)dataRow["Phone"];
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
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Supplier"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Supplier Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.Supplier entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetBySuppId methods when available
			
			#region InventoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Inventory>", "InventoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'InventoryCollection' loaded.");
				#endif 

				entity.InventoryCollection = DataRepository.InventoryProvider.GetBySuppId(transactionManager, entity.SuppId);

				if (deep && entity.InventoryCollection.Count > 0)
				{
					DataRepository.InventoryProvider.DeepLoad(transactionManager, entity.InventoryCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ItemCollection_From_Inventory
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Item>", "ItemCollection_From_Inventory", deepLoadType, innerList))
			{
				entity.ItemCollection_From_Inventory = DataRepository.ItemProvider.GetBySuppIdFromInventory(transactionManager, entity.SuppId);			 
		
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemCollection_From_Inventory' loaded.");
				#endif 

				if (deep && entity.ItemCollection_From_Inventory.Count > 0)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemCollection_From_Inventory, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ItemCollection_From_Inventory
			
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.Supplier object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.Supplier instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Supplier Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.Supplier entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Source Properties


			#region List<Inventory>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<Inventory>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<Inventory>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(Inventory child in entity.InventoryCollection)
			{
					child.SuppId = entity.SuppId;			}
			
			if (entity.InventoryCollection.Count > 0)
				DataRepository.InventoryProvider.DeepSave(transactionManager, entity.InventoryCollection, deepSaveType, childTypes);
			} 
			#endregion 

			#region List<Item>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<Item>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<Item>"] == null))
			{
				if (entity.ItemCollection_From_Inventory.Count > 0)
					DataRepository.ItemProvider.DeepSave(transactionManager, entity.ItemCollection_From_Inventory, deepSaveType, childTypes); 
			}
			#endregion 
		}
		#endregion
	} // end class
	
	#region SupplierChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.Supplier</c>
	///</summary>
	public enum SupplierChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Supplier</c> as OneToMany for InventoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<Inventory>))]
		InventoryCollection,

		///<summary>
		/// Collection of <c>Supplier</c> as ManyToMany for ItemCollection_From_Inventory
		///</summary>
		[ChildEntityType(typeof(TList<Item>))]
		ItemCollection_From_Inventory,
	}
	
	#endregion SupplierChildEntityTypes
	
	#region SupplierFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Supplier"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SupplierFilterBuilder : SqlFilterBuilder<SupplierColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SupplierFilterBuilder class.
		/// </summary>
		public SupplierFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SupplierFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SupplierFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SupplierFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SupplierFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SupplierFilterBuilder
} // end namespace
