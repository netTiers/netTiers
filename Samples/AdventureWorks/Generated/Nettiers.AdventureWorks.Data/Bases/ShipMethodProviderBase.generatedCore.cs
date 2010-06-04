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
	/// This class is the base class for any <see cref="ShipMethodProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ShipMethodProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ShipMethod, Nettiers.AdventureWorks.Entities.ShipMethodKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ShipMethodKey key)
		{
			return Delete(transactionManager, key.ShipMethodId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_shipMethodId">Primary key for ShipMethod records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _shipMethodId)
		{
			return Delete(null, _shipMethodId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Primary key for ShipMethod records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _shipMethodId);		
		
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
		public override Nettiers.AdventureWorks.Entities.ShipMethod Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ShipMethodKey key, int start, int pageLength)
		{
			return GetByShipMethodId(transactionManager, key.ShipMethodId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ShipMethod_Name index.
		/// </summary>
		/// <param name="_name">Shipping company name.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_Name index.
		/// </summary>
		/// <param name="_name">Shipping company name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Shipping company name.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Shipping company name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_Name index.
		/// </summary>
		/// <param name="_name">Shipping company name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Shipping company name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ShipMethod GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ShipMethod_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ShipMethod_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ShipMethod GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ShipMethod_ShipMethodID index.
		/// </summary>
		/// <param name="_shipMethodId">Primary key for ShipMethod records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByShipMethodId(System.Int32 _shipMethodId)
		{
			int count = -1;
			return GetByShipMethodId(null,_shipMethodId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ShipMethod_ShipMethodID index.
		/// </summary>
		/// <param name="_shipMethodId">Primary key for ShipMethod records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByShipMethodId(System.Int32 _shipMethodId, int start, int pageLength)
		{
			int count = -1;
			return GetByShipMethodId(null, _shipMethodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ShipMethod_ShipMethodID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Primary key for ShipMethod records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId)
		{
			int count = -1;
			return GetByShipMethodId(transactionManager, _shipMethodId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ShipMethod_ShipMethodID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Primary key for ShipMethod records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId, int start, int pageLength)
		{
			int count = -1;
			return GetByShipMethodId(transactionManager, _shipMethodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ShipMethod_ShipMethodID index.
		/// </summary>
		/// <param name="_shipMethodId">Primary key for ShipMethod records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ShipMethod GetByShipMethodId(System.Int32 _shipMethodId, int start, int pageLength, out int count)
		{
			return GetByShipMethodId(null, _shipMethodId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ShipMethod_ShipMethodID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Primary key for ShipMethod records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ShipMethod GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ShipMethod&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ShipMethod&gt;"/></returns>
		public static TList<ShipMethod> Fill(IDataReader reader, TList<ShipMethod> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ShipMethod c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ShipMethod")
					.Append("|").Append((System.Int32)reader[((int)ShipMethodColumn.ShipMethodId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ShipMethod>(
					key.ToString(), // EntityTrackingKey
					"ShipMethod",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ShipMethod();
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
					c.ShipMethodId = (System.Int32)reader[((int)ShipMethodColumn.ShipMethodId - 1)];
					c.Name = (System.String)reader[((int)ShipMethodColumn.Name - 1)];
					c.ShipBase = (System.Decimal)reader[((int)ShipMethodColumn.ShipBase - 1)];
					c.ShipRate = (System.Decimal)reader[((int)ShipMethodColumn.ShipRate - 1)];
					c.Rowguid = (System.Guid)reader[((int)ShipMethodColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ShipMethodColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ShipMethod entity)
		{
			if (!reader.Read()) return;
			
			entity.ShipMethodId = (System.Int32)reader[((int)ShipMethodColumn.ShipMethodId - 1)];
			entity.Name = (System.String)reader[((int)ShipMethodColumn.Name - 1)];
			entity.ShipBase = (System.Decimal)reader[((int)ShipMethodColumn.ShipBase - 1)];
			entity.ShipRate = (System.Decimal)reader[((int)ShipMethodColumn.ShipRate - 1)];
			entity.Rowguid = (System.Guid)reader[((int)ShipMethodColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ShipMethodColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ShipMethod entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShipMethodId = (System.Int32)dataRow["ShipMethodID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.ShipBase = (System.Decimal)dataRow["ShipBase"];
			entity.ShipRate = (System.Decimal)dataRow["ShipRate"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ShipMethod"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ShipMethod Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ShipMethod entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByShipMethodId methods when available
			
			#region SalesOrderHeaderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderCollection = DataRepository.SalesOrderHeaderProvider.GetByShipMethodId(transactionManager, entity.ShipMethodId);

				if (deep && entity.SalesOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region PurchaseOrderHeaderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PurchaseOrderHeader>|PurchaseOrderHeaderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PurchaseOrderHeaderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PurchaseOrderHeaderCollection = DataRepository.PurchaseOrderHeaderProvider.GetByShipMethodId(transactionManager, entity.ShipMethodId);

				if (deep && entity.PurchaseOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("PurchaseOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PurchaseOrderHeader>) DataRepository.PurchaseOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.PurchaseOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ShipMethod object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ShipMethod instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ShipMethod Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ShipMethod entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<SalesOrderHeader>
				if (CanDeepSave(entity.SalesOrderHeaderCollection, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderHeader child in entity.SalesOrderHeaderCollection)
					{
						if(child.ShipMethodIdSource != null)
						{
							child.ShipMethodId = child.ShipMethodIdSource.ShipMethodId;
						}
						else
						{
							child.ShipMethodId = entity.ShipMethodId;
						}

					}

					if (entity.SalesOrderHeaderCollection.Count > 0 || entity.SalesOrderHeaderCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderHeaderProvider.Save(transactionManager, entity.SalesOrderHeaderCollection);
						
						deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderHeader >) DataRepository.SalesOrderHeaderProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderHeaderCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<PurchaseOrderHeader>
				if (CanDeepSave(entity.PurchaseOrderHeaderCollection, "List<PurchaseOrderHeader>|PurchaseOrderHeaderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PurchaseOrderHeader child in entity.PurchaseOrderHeaderCollection)
					{
						if(child.ShipMethodIdSource != null)
						{
							child.ShipMethodId = child.ShipMethodIdSource.ShipMethodId;
						}
						else
						{
							child.ShipMethodId = entity.ShipMethodId;
						}

					}

					if (entity.PurchaseOrderHeaderCollection.Count > 0 || entity.PurchaseOrderHeaderCollection.DeletedItems.Count > 0)
					{
						//DataRepository.PurchaseOrderHeaderProvider.Save(transactionManager, entity.PurchaseOrderHeaderCollection);
						
						deepHandles.Add("PurchaseOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< PurchaseOrderHeader >) DataRepository.PurchaseOrderHeaderProvider.DeepSave,
							new object[] { transactionManager, entity.PurchaseOrderHeaderCollection, deepSaveType, childTypes, innerList }
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
	
	#region ShipMethodChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ShipMethod</c>
	///</summary>
	public enum ShipMethodChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ShipMethod</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollection,

		///<summary>
		/// Collection of <c>ShipMethod</c> as OneToMany for PurchaseOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<PurchaseOrderHeader>))]
		PurchaseOrderHeaderCollection,
	}
	
	#endregion ShipMethodChildEntityTypes
	
	#region ShipMethodFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ShipMethodColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShipMethod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShipMethodFilterBuilder : SqlFilterBuilder<ShipMethodColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShipMethodFilterBuilder class.
		/// </summary>
		public ShipMethodFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShipMethodFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShipMethodFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShipMethodFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShipMethodFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShipMethodFilterBuilder
	
	#region ShipMethodParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ShipMethodColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShipMethod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShipMethodParameterBuilder : ParameterizedSqlFilterBuilder<ShipMethodColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShipMethodParameterBuilder class.
		/// </summary>
		public ShipMethodParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShipMethodParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShipMethodParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShipMethodParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShipMethodParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShipMethodParameterBuilder
	
	#region ShipMethodSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ShipMethodColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShipMethod"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ShipMethodSortBuilder : SqlSortBuilder<ShipMethodColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShipMethodSqlSortBuilder class.
		/// </summary>
		public ShipMethodSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ShipMethodSortBuilder
	
} // end namespace
