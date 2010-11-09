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
	/// This class is the base class for any <see cref="SupplierProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SupplierProviderBaseCore : EntityProviderBase<PetShop.Business.Supplier, PetShop.Business.SupplierKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.SupplierKey key)
		{
			return Delete(transactionManager, key.SuppId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_suppId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(int _suppId)
		{
			return Delete(null, _suppId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_suppId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, int _suppId);		
		
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
		public override PetShop.Business.Supplier Get(TransactionManager transactionManager, PetShop.Business.SupplierKey key, int start, int pageLength)
		{
			return GetBySuppId(transactionManager, key.SuppId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Supplier__F099B03F07020F21 index.
		/// </summary>
		/// <param name="_suppId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Supplier"/> class.</returns>
		public PetShop.Business.Supplier GetBySuppId(int _suppId)
		{
			int count = -1;
			return GetBySuppId(null,_suppId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__F099B03F07020F21 index.
		/// </summary>
		/// <param name="_suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Supplier"/> class.</returns>
		public PetShop.Business.Supplier GetBySuppId(int _suppId, int start, int pageLength)
		{
			int count = -1;
			return GetBySuppId(null, _suppId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__F099B03F07020F21 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_suppId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Supplier"/> class.</returns>
		public PetShop.Business.Supplier GetBySuppId(TransactionManager transactionManager, int _suppId)
		{
			int count = -1;
			return GetBySuppId(transactionManager, _suppId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__F099B03F07020F21 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Supplier"/> class.</returns>
		public PetShop.Business.Supplier GetBySuppId(TransactionManager transactionManager, int _suppId, int start, int pageLength)
		{
			int count = -1;
			return GetBySuppId(transactionManager, _suppId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__F099B03F07020F21 index.
		/// </summary>
		/// <param name="_suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Supplier"/> class.</returns>
		public PetShop.Business.Supplier GetBySuppId(int _suppId, int start, int pageLength, out int count)
		{
			return GetBySuppId(null, _suppId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Supplier__F099B03F07020F21 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_suppId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Supplier"/> class.</returns>
		public abstract PetShop.Business.Supplier GetBySuppId(TransactionManager transactionManager, int _suppId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Supplier&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Supplier&gt;"/></returns>
		public static TList<Supplier> Fill(IDataReader reader, TList<Supplier> rows, int start, int pageLength)
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
				
				PetShop.Business.Supplier c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Supplier")
					.Append("|").Append((int)reader[((int)SupplierColumn.SuppId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Supplier>(
					key.ToString(), // EntityTrackingKey
					"Supplier",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Supplier();
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
					c.SuppId = (int)reader[((int)SupplierColumn.SuppId - 1)];
					c.OriginalSuppId = c.SuppId;
					c.Name = (reader.IsDBNull(((int)SupplierColumn.Name - 1)))?null:(string)reader[((int)SupplierColumn.Name - 1)];
					c.Status = (string)reader[((int)SupplierColumn.Status - 1)];
					c.Addr1 = (reader.IsDBNull(((int)SupplierColumn.Addr1 - 1)))?null:(string)reader[((int)SupplierColumn.Addr1 - 1)];
					c.Addr2 = (reader.IsDBNull(((int)SupplierColumn.Addr2 - 1)))?null:(string)reader[((int)SupplierColumn.Addr2 - 1)];
					c.City = (reader.IsDBNull(((int)SupplierColumn.City - 1)))?null:(string)reader[((int)SupplierColumn.City - 1)];
					c.State = (reader.IsDBNull(((int)SupplierColumn.State - 1)))?null:(string)reader[((int)SupplierColumn.State - 1)];
					c.Zip = (reader.IsDBNull(((int)SupplierColumn.Zip - 1)))?null:(string)reader[((int)SupplierColumn.Zip - 1)];
					c.Phone = (reader.IsDBNull(((int)SupplierColumn.Phone - 1)))?null:(string)reader[((int)SupplierColumn.Phone - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Supplier"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Supplier"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Supplier entity)
		{
			if (!reader.Read()) return;
			
			entity.SuppId = (int)reader[((int)SupplierColumn.SuppId - 1)];
			entity.OriginalSuppId = (int)reader["SuppId"];
			entity.Name = (reader.IsDBNull(((int)SupplierColumn.Name - 1)))?null:(string)reader[((int)SupplierColumn.Name - 1)];
			entity.Status = (string)reader[((int)SupplierColumn.Status - 1)];
			entity.Addr1 = (reader.IsDBNull(((int)SupplierColumn.Addr1 - 1)))?null:(string)reader[((int)SupplierColumn.Addr1 - 1)];
			entity.Addr2 = (reader.IsDBNull(((int)SupplierColumn.Addr2 - 1)))?null:(string)reader[((int)SupplierColumn.Addr2 - 1)];
			entity.City = (reader.IsDBNull(((int)SupplierColumn.City - 1)))?null:(string)reader[((int)SupplierColumn.City - 1)];
			entity.State = (reader.IsDBNull(((int)SupplierColumn.State - 1)))?null:(string)reader[((int)SupplierColumn.State - 1)];
			entity.Zip = (reader.IsDBNull(((int)SupplierColumn.Zip - 1)))?null:(string)reader[((int)SupplierColumn.Zip - 1)];
			entity.Phone = (reader.IsDBNull(((int)SupplierColumn.Phone - 1)))?null:(string)reader[((int)SupplierColumn.Phone - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Supplier"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Supplier"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Supplier entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SuppId = (int)dataRow["SuppId"];
			entity.OriginalSuppId = (int)dataRow["SuppId"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (string)dataRow["Name"];
			entity.Status = (string)dataRow["Status"];
			entity.Addr1 = Convert.IsDBNull(dataRow["Addr1"]) ? null : (string)dataRow["Addr1"];
			entity.Addr2 = Convert.IsDBNull(dataRow["Addr2"]) ? null : (string)dataRow["Addr2"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (string)dataRow["City"];
			entity.State = Convert.IsDBNull(dataRow["State"]) ? null : (string)dataRow["State"];
			entity.Zip = Convert.IsDBNull(dataRow["Zip"]) ? null : (string)dataRow["Zip"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (string)dataRow["Phone"];
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
		/// <param name="entity">The <see cref="PetShop.Business.Supplier"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Supplier Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Supplier entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySuppId methods when available
			
			#region ItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Item>|ItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ItemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ItemCollection = DataRepository.ItemProvider.GetBySupplier(transactionManager, entity.SuppId);

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
		/// Deep Save the entire object graph of the PetShop.Business.Supplier object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Supplier instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Supplier Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Supplier entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Item>
				if (CanDeepSave(entity.ItemCollection, "List<Item>|ItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Item child in entity.ItemCollection)
					{
						if(child.SupplierSource != null)
						{
							child.Supplier = child.SupplierSource.SuppId;
						}
						else
						{
							child.Supplier = entity.SuppId;
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
	
	#region SupplierChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Supplier</c>
	///</summary>
	public enum SupplierChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Supplier</c> as OneToMany for ItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<Item>))]
		ItemCollection,
	}
	
	#endregion SupplierChildEntityTypes
	
	#region SupplierFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SupplierColumn&gt;"/> class
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
	
	#region SupplierParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SupplierColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Supplier"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SupplierParameterBuilder : ParameterizedSqlFilterBuilder<SupplierColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SupplierParameterBuilder class.
		/// </summary>
		public SupplierParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SupplierParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SupplierParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SupplierParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SupplierParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SupplierParameterBuilder
	
	#region SupplierSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SupplierColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Supplier"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SupplierSortBuilder : SqlSortBuilder<SupplierColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SupplierSqlSortBuilder class.
		/// </summary>
		public SupplierSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SupplierSortBuilder
	
} // end namespace
