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
	/// This class is the base class for any <see cref="AddressTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AddressTypeProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.AddressType, Nettiers.AdventureWorks.Entities.AddressTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AddressTypeKey key)
		{
			return Delete(transactionManager, key.AddressTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_addressTypeId">Primary key for AddressType records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _addressTypeId)
		{
			return Delete(null, _addressTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Primary key for AddressType records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _addressTypeId);		
		
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
		public override Nettiers.AdventureWorks.Entities.AddressType Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AddressTypeKey key, int start, int pageLength)
		{
			return GetByAddressTypeId(transactionManager, key.AddressTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_AddressType_Name index.
		/// </summary>
		/// <param name="_name">Address type description. For example, Billing, Home, or Shipping.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_Name index.
		/// </summary>
		/// <param name="_name">Address type description. For example, Billing, Home, or Shipping.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Address type description. For example, Billing, Home, or Shipping.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Address type description. For example, Billing, Home, or Shipping.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_Name index.
		/// </summary>
		/// <param name="_name">Address type description. For example, Billing, Home, or Shipping.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Address type description. For example, Billing, Home, or Shipping.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.AddressType GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_AddressType_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_AddressType_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.AddressType GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AddressType_AddressTypeID index.
		/// </summary>
		/// <param name="_addressTypeId">Primary key for AddressType records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByAddressTypeId(System.Int32 _addressTypeId)
		{
			int count = -1;
			return GetByAddressTypeId(null,_addressTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AddressType_AddressTypeID index.
		/// </summary>
		/// <param name="_addressTypeId">Primary key for AddressType records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByAddressTypeId(System.Int32 _addressTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressTypeId(null, _addressTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AddressType_AddressTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Primary key for AddressType records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId)
		{
			int count = -1;
			return GetByAddressTypeId(transactionManager, _addressTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AddressType_AddressTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Primary key for AddressType records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressTypeId(transactionManager, _addressTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AddressType_AddressTypeID index.
		/// </summary>
		/// <param name="_addressTypeId">Primary key for AddressType records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AddressType GetByAddressTypeId(System.Int32 _addressTypeId, int start, int pageLength, out int count)
		{
			return GetByAddressTypeId(null, _addressTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AddressType_AddressTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Primary key for AddressType records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.AddressType GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AddressType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AddressType&gt;"/></returns>
		public static TList<AddressType> Fill(IDataReader reader, TList<AddressType> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.AddressType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AddressType")
					.Append("|").Append((System.Int32)reader[((int)AddressTypeColumn.AddressTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AddressType>(
					key.ToString(), // EntityTrackingKey
					"AddressType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.AddressType();
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
					c.AddressTypeId = (System.Int32)reader[((int)AddressTypeColumn.AddressTypeId - 1)];
					c.Name = (System.String)reader[((int)AddressTypeColumn.Name - 1)];
					c.Rowguid = (System.Guid)reader[((int)AddressTypeColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)AddressTypeColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.AddressType entity)
		{
			if (!reader.Read()) return;
			
			entity.AddressTypeId = (System.Int32)reader[((int)AddressTypeColumn.AddressTypeId - 1)];
			entity.Name = (System.String)reader[((int)AddressTypeColumn.Name - 1)];
			entity.Rowguid = (System.Guid)reader[((int)AddressTypeColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)AddressTypeColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.AddressType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AddressTypeId = (System.Int32)dataRow["AddressTypeID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Rowguid = (System.Guid)dataRow["rowguid"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.AddressType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.AddressType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AddressType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAddressTypeId methods when available
			
			#region VendorAddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<VendorAddress>|VendorAddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorAddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.VendorAddressCollection = DataRepository.VendorAddressProvider.GetByAddressTypeId(transactionManager, entity.AddressTypeId);

				if (deep && entity.VendorAddressCollection.Count > 0)
				{
					deepHandles.Add("VendorAddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<VendorAddress>) DataRepository.VendorAddressProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorAddressCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerAddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerAddress>|CustomerAddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerAddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerAddressCollection = DataRepository.CustomerAddressProvider.GetByAddressTypeId(transactionManager, entity.AddressTypeId);

				if (deep && entity.CustomerAddressCollection.Count > 0)
				{
					deepHandles.Add("CustomerAddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerAddress>) DataRepository.CustomerAddressProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerAddressCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.AddressType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.AddressType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.AddressType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AddressType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<VendorAddress>
				if (CanDeepSave(entity.VendorAddressCollection, "List<VendorAddress>|VendorAddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(VendorAddress child in entity.VendorAddressCollection)
					{
					}

					if (entity.VendorAddressCollection.Count > 0 || entity.VendorAddressCollection.DeletedItems.Count > 0)
					{
						//DataRepository.VendorAddressProvider.Save(transactionManager, entity.VendorAddressCollection);
						
						deepHandles.Add("VendorAddressCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< VendorAddress >) DataRepository.VendorAddressProvider.DeepSave,
							new object[] { transactionManager, entity.VendorAddressCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CustomerAddress>
				if (CanDeepSave(entity.CustomerAddressCollection, "List<CustomerAddress>|CustomerAddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerAddress child in entity.CustomerAddressCollection)
					{
					}

					if (entity.CustomerAddressCollection.Count > 0 || entity.CustomerAddressCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerAddressProvider.Save(transactionManager, entity.CustomerAddressCollection);
						
						deepHandles.Add("CustomerAddressCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerAddress >) DataRepository.CustomerAddressProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerAddressCollection, deepSaveType, childTypes, innerList }
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
	
	#region AddressTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.AddressType</c>
	///</summary>
	public enum AddressTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AddressType</c> as OneToMany for VendorAddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<VendorAddress>))]
		VendorAddressCollection,

		///<summary>
		/// Collection of <c>AddressType</c> as OneToMany for CustomerAddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerAddress>))]
		CustomerAddressCollection,
	}
	
	#endregion AddressTypeChildEntityTypes
	
	#region AddressTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AddressTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddressType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressTypeFilterBuilder : SqlFilterBuilder<AddressTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressTypeFilterBuilder class.
		/// </summary>
		public AddressTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressTypeFilterBuilder
	
	#region AddressTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AddressTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddressType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressTypeParameterBuilder : ParameterizedSqlFilterBuilder<AddressTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressTypeParameterBuilder class.
		/// </summary>
		public AddressTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressTypeParameterBuilder
	
	#region AddressTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AddressTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddressType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AddressTypeSortBuilder : SqlSortBuilder<AddressTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressTypeSqlSortBuilder class.
		/// </summary>
		public AddressTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AddressTypeSortBuilder
	
} // end namespace
