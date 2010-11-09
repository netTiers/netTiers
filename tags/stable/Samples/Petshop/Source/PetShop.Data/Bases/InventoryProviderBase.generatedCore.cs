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
	/// This class is the base class for any <see cref="InventoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class InventoryProviderBaseCore : EntityProviderBase<PetShop.Business.Inventory, PetShop.Business.InventoryKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.InventoryKey key)
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
		public override PetShop.Business.Inventory Get(TransactionManager transactionManager, PetShop.Business.InventoryKey key, int start, int pageLength)
		{
			return GetByItemId(transactionManager, key.ItemId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Inventor__727E838B03317E3D index.
		/// </summary>
		/// <param name="_itemId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Inventory"/> class.</returns>
		public PetShop.Business.Inventory GetByItemId(string _itemId)
		{
			int count = -1;
			return GetByItemId(null,_itemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Inventor__727E838B03317E3D index.
		/// </summary>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Inventory"/> class.</returns>
		public PetShop.Business.Inventory GetByItemId(string _itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(null, _itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Inventor__727E838B03317E3D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Inventory"/> class.</returns>
		public PetShop.Business.Inventory GetByItemId(TransactionManager transactionManager, string _itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Inventor__727E838B03317E3D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Inventory"/> class.</returns>
		public PetShop.Business.Inventory GetByItemId(TransactionManager transactionManager, string _itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Inventor__727E838B03317E3D index.
		/// </summary>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Inventory"/> class.</returns>
		public PetShop.Business.Inventory GetByItemId(string _itemId, int start, int pageLength, out int count)
		{
			return GetByItemId(null, _itemId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Inventor__727E838B03317E3D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Inventory"/> class.</returns>
		public abstract PetShop.Business.Inventory GetByItemId(TransactionManager transactionManager, string _itemId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Inventory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Inventory&gt;"/></returns>
		public static TList<Inventory> Fill(IDataReader reader, TList<Inventory> rows, int start, int pageLength)
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
				
				PetShop.Business.Inventory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Inventory")
					.Append("|").Append((string)reader[((int)InventoryColumn.ItemId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Inventory>(
					key.ToString(), // EntityTrackingKey
					"Inventory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Inventory();
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
					c.ItemId = (string)reader[((int)InventoryColumn.ItemId - 1)];
					c.OriginalItemId = c.ItemId;
					c.Qty = (int)reader[((int)InventoryColumn.Qty - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Inventory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Inventory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Inventory entity)
		{
			if (!reader.Read()) return;
			
			entity.ItemId = (string)reader[((int)InventoryColumn.ItemId - 1)];
			entity.OriginalItemId = (string)reader["ItemId"];
			entity.Qty = (int)reader[((int)InventoryColumn.Qty - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Inventory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Inventory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Inventory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ItemId = (string)dataRow["ItemId"];
			entity.OriginalItemId = (string)dataRow["ItemId"];
			entity.Qty = (int)dataRow["Qty"];
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
		/// <param name="entity">The <see cref="PetShop.Business.Inventory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Inventory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Inventory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the PetShop.Business.Inventory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Inventory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Inventory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Inventory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
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
	
	#region InventoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Inventory</c>
	///</summary>
	public enum InventoryChildEntityTypes
	{
	}
	
	#endregion InventoryChildEntityTypes
	
	#region InventoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;InventoryColumn&gt;"/> class
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
	
	#region InventoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;InventoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Inventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InventoryParameterBuilder : ParameterizedSqlFilterBuilder<InventoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InventoryParameterBuilder class.
		/// </summary>
		public InventoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InventoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InventoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InventoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InventoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InventoryParameterBuilder
	
	#region InventorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;InventoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Inventory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class InventorySortBuilder : SqlSortBuilder<InventoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InventorySqlSortBuilder class.
		/// </summary>
		public InventorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion InventorySortBuilder
	
} // end namespace
