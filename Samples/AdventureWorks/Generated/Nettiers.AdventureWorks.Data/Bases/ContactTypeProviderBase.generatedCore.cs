#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ContactTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContactTypeProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ContactType, Nettiers.AdventureWorks.Entities.ContactTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactTypeKey key)
		{
			return Delete(transactionManager, key.ContactTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_contactTypeId">Primary key for ContactType records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _contactTypeId)
		{
			return Delete(null, _contactTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactTypeId">Primary key for ContactType records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _contactTypeId);		
		
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
		public override Nettiers.AdventureWorks.Entities.ContactType Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactTypeKey key, int start, int pageLength)
		{
			return GetByContactTypeId(transactionManager, key.ContactTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ContactType_Name index.
		/// </summary>
		/// <param name="_name">Contact type description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ContactType_Name index.
		/// </summary>
		/// <param name="_name">Contact type description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ContactType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Contact type description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ContactType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Contact type description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ContactType_Name index.
		/// </summary>
		/// <param name="_name">Contact type description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ContactType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Contact type description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ContactType GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ContactType_ContactTypeID index.
		/// </summary>
		/// <param name="_contactTypeId">Primary key for ContactType records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByContactTypeId(System.Int32 _contactTypeId)
		{
			int count = -1;
			return GetByContactTypeId(null,_contactTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactType_ContactTypeID index.
		/// </summary>
		/// <param name="_contactTypeId">Primary key for ContactType records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByContactTypeId(System.Int32 _contactTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactTypeId(null, _contactTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactType_ContactTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactTypeId">Primary key for ContactType records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByContactTypeId(TransactionManager transactionManager, System.Int32 _contactTypeId)
		{
			int count = -1;
			return GetByContactTypeId(transactionManager, _contactTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactType_ContactTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactTypeId">Primary key for ContactType records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByContactTypeId(TransactionManager transactionManager, System.Int32 _contactTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactTypeId(transactionManager, _contactTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactType_ContactTypeID index.
		/// </summary>
		/// <param name="_contactTypeId">Primary key for ContactType records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactType GetByContactTypeId(System.Int32 _contactTypeId, int start, int pageLength, out int count)
		{
			return GetByContactTypeId(null, _contactTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactType_ContactTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactTypeId">Primary key for ContactType records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ContactType GetByContactTypeId(TransactionManager transactionManager, System.Int32 _contactTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ContactType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ContactType&gt;"/></returns>
		public static TList<ContactType> Fill(IDataReader reader, TList<ContactType> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ContactType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ContactType")
					.Append("|").Append((System.Int32)reader[((int)ContactTypeColumn.ContactTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ContactType>(
					key.ToString(), // EntityTrackingKey
					"ContactType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ContactType();
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
					c.ContactTypeId = (System.Int32)reader[((int)ContactTypeColumn.ContactTypeId - 1)];
					c.Name = (System.String)reader[((int)ContactTypeColumn.Name - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ContactTypeColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ContactType entity)
		{
			if (!reader.Read()) return;
			
			entity.ContactTypeId = (System.Int32)reader[((int)ContactTypeColumn.ContactTypeId - 1)];
			entity.Name = (System.String)reader[((int)ContactTypeColumn.Name - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ContactTypeColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ContactType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ContactTypeId = (System.Int32)dataRow["ContactTypeID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.ModifiedDate = (System.DateTime)dataRow["ModifiedDate"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ContactType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ContactType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByContactTypeId methods when available
			
			#region StoreContactCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<StoreContact>|StoreContactCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StoreContactCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.StoreContactCollection = DataRepository.StoreContactProvider.GetByContactTypeId(transactionManager, entity.ContactTypeId);

				if (deep && entity.StoreContactCollection.Count > 0)
				{
					deepHandles.Add("StoreContactCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<StoreContact>) DataRepository.StoreContactProvider.DeepLoad,
						new object[] { transactionManager, entity.StoreContactCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region VendorContactCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<VendorContact>|VendorContactCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorContactCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.VendorContactCollection = DataRepository.VendorContactProvider.GetByContactTypeId(transactionManager, entity.ContactTypeId);

				if (deep && entity.VendorContactCollection.Count > 0)
				{
					deepHandles.Add("VendorContactCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<VendorContact>) DataRepository.VendorContactProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorContactCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ContactType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ContactType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ContactType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<StoreContact>
				if (CanDeepSave(entity.StoreContactCollection, "List<StoreContact>|StoreContactCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(StoreContact child in entity.StoreContactCollection)
					{
					}

					if (entity.StoreContactCollection.Count > 0 || entity.StoreContactCollection.DeletedItems.Count > 0)
					{
						//DataRepository.StoreContactProvider.Save(transactionManager, entity.StoreContactCollection);
						
						deepHandles.Add("StoreContactCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< StoreContact >) DataRepository.StoreContactProvider.DeepSave,
							new object[] { transactionManager, entity.StoreContactCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<VendorContact>
				if (CanDeepSave(entity.VendorContactCollection, "List<VendorContact>|VendorContactCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(VendorContact child in entity.VendorContactCollection)
					{
					}

					if (entity.VendorContactCollection.Count > 0 || entity.VendorContactCollection.DeletedItems.Count > 0)
					{
						//DataRepository.VendorContactProvider.Save(transactionManager, entity.VendorContactCollection);
						
						deepHandles.Add("VendorContactCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< VendorContact >) DataRepository.VendorContactProvider.DeepSave,
							new object[] { transactionManager, entity.VendorContactCollection, deepSaveType, childTypes, innerList }
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
	
	#region ContactTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ContactType</c>
	///</summary>
	public enum ContactTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ContactType</c> as OneToMany for StoreContactCollection
		///</summary>
		[ChildEntityType(typeof(TList<StoreContact>))]
		StoreContactCollection,

		///<summary>
		/// Collection of <c>ContactType</c> as OneToMany for VendorContactCollection
		///</summary>
		[ChildEntityType(typeof(TList<VendorContact>))]
		VendorContactCollection,
	}
	
	#endregion ContactTypeChildEntityTypes
	
	#region ContactTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ContactTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTypeFilterBuilder : SqlFilterBuilder<ContactTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTypeFilterBuilder class.
		/// </summary>
		public ContactTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactTypeFilterBuilder
	
	#region ContactTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ContactTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTypeParameterBuilder : ParameterizedSqlFilterBuilder<ContactTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTypeParameterBuilder class.
		/// </summary>
		public ContactTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactTypeParameterBuilder
	
	#region ContactTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ContactTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ContactTypeSortBuilder : SqlSortBuilder<ContactTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTypeSqlSortBuilder class.
		/// </summary>
		public ContactTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ContactTypeSortBuilder
	
} // end namespace
