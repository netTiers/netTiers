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
	/// This class is the base class for any <see cref="SalesTerritoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesTerritoryProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesTerritory, Nettiers.AdventureWorks.Entities.SalesTerritoryKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTerritoryKey key)
		{
			return Delete(transactionManager, key.TerritoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_territoryId">Primary key for SalesTerritory records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _territoryId)
		{
			return Delete(null, _territoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Primary key for SalesTerritory records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _territoryId);		
		
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
		public override Nettiers.AdventureWorks.Entities.SalesTerritory Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTerritoryKey key, int start, int pageLength)
		{
			return GetByTerritoryId(transactionManager, key.TerritoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesTerritory_Name index.
		/// </summary>
		/// <param name="_name">Sales territory description</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_Name index.
		/// </summary>
		/// <param name="_name">Sales territory description</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Sales territory description</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Sales territory description</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_Name index.
		/// </summary>
		/// <param name="_name">Sales territory description</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Sales territory description</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesTerritory GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesTerritory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesTerritory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesTerritory_TerritoryID index.
		/// </summary>
		/// <param name="_territoryId">Primary key for SalesTerritory records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByTerritoryId(System.Int32 _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(null,_territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritory_TerritoryID index.
		/// </summary>
		/// <param name="_territoryId">Primary key for SalesTerritory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByTerritoryId(System.Int32 _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritory_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Primary key for SalesTerritory records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritory_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Primary key for SalesTerritory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritory_TerritoryID index.
		/// </summary>
		/// <param name="_territoryId">Primary key for SalesTerritory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritory GetByTerritoryId(System.Int32 _territoryId, int start, int pageLength, out int count)
		{
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritory_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Primary key for SalesTerritory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesTerritory GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesTerritory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesTerritory&gt;"/></returns>
		public static TList<SalesTerritory> Fill(IDataReader reader, TList<SalesTerritory> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SalesTerritory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesTerritory")
					.Append("|").Append((System.Int32)reader[((int)SalesTerritoryColumn.TerritoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesTerritory>(
					key.ToString(), // EntityTrackingKey
					"SalesTerritory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesTerritory();
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
					c.TerritoryId = (System.Int32)reader[((int)SalesTerritoryColumn.TerritoryId - 1)];
					c.Name = (System.String)reader[((int)SalesTerritoryColumn.Name - 1)];
					c.CountryRegionCode = (System.String)reader[((int)SalesTerritoryColumn.CountryRegionCode - 1)];
					c.Group = (System.String)reader[((int)SalesTerritoryColumn.Group - 1)];
					c.SalesYtd = (System.Decimal)reader[((int)SalesTerritoryColumn.SalesYtd - 1)];
					c.SalesLastYear = (System.Decimal)reader[((int)SalesTerritoryColumn.SalesLastYear - 1)];
					c.CostYtd = (System.Decimal)reader[((int)SalesTerritoryColumn.CostYtd - 1)];
					c.CostLastYear = (System.Decimal)reader[((int)SalesTerritoryColumn.CostLastYear - 1)];
					c.Rowguid = (System.Guid)reader[((int)SalesTerritoryColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SalesTerritoryColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesTerritory entity)
		{
			if (!reader.Read()) return;
			
			entity.TerritoryId = (System.Int32)reader[((int)SalesTerritoryColumn.TerritoryId - 1)];
			entity.Name = (System.String)reader[((int)SalesTerritoryColumn.Name - 1)];
			entity.CountryRegionCode = (System.String)reader[((int)SalesTerritoryColumn.CountryRegionCode - 1)];
			entity.Group = (System.String)reader[((int)SalesTerritoryColumn.Group - 1)];
			entity.SalesYtd = (System.Decimal)reader[((int)SalesTerritoryColumn.SalesYtd - 1)];
			entity.SalesLastYear = (System.Decimal)reader[((int)SalesTerritoryColumn.SalesLastYear - 1)];
			entity.CostYtd = (System.Decimal)reader[((int)SalesTerritoryColumn.CostYtd - 1)];
			entity.CostLastYear = (System.Decimal)reader[((int)SalesTerritoryColumn.CostLastYear - 1)];
			entity.Rowguid = (System.Guid)reader[((int)SalesTerritoryColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesTerritoryColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesTerritory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TerritoryId = (System.Int32)dataRow["TerritoryID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.CountryRegionCode = (System.String)dataRow["CountryRegionCode"];
			entity.Group = (System.String)dataRow["Group"];
			entity.SalesYtd = (System.Decimal)dataRow["SalesYTD"];
			entity.SalesLastYear = (System.Decimal)dataRow["SalesLastYear"];
			entity.CostYtd = (System.Decimal)dataRow["CostYTD"];
			entity.CostLastYear = (System.Decimal)dataRow["CostLastYear"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTerritory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesTerritory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTerritory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByTerritoryId methods when available
			
			#region StateProvinceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<StateProvince>|StateProvinceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StateProvinceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.StateProvinceCollection = DataRepository.StateProvinceProvider.GetByTerritoryId(transactionManager, entity.TerritoryId);

				if (deep && entity.StateProvinceCollection.Count > 0)
				{
					deepHandles.Add("StateProvinceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<StateProvince>) DataRepository.StateProvinceProvider.DeepLoad,
						new object[] { transactionManager, entity.StateProvinceCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesOrderHeaderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderCollection = DataRepository.SalesOrderHeaderProvider.GetByTerritoryId(transactionManager, entity.TerritoryId);

				if (deep && entity.SalesOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesPersonCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesPerson>|SalesPersonCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesPersonCollection = DataRepository.SalesPersonProvider.GetByTerritoryId(transactionManager, entity.TerritoryId);

				if (deep && entity.SalesPersonCollection.Count > 0)
				{
					deepHandles.Add("SalesPersonCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesPerson>) DataRepository.SalesPersonProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesPersonCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesTerritoryHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesTerritoryHistory>|SalesTerritoryHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesTerritoryHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesTerritoryHistoryCollection = DataRepository.SalesTerritoryHistoryProvider.GetByTerritoryId(transactionManager, entity.TerritoryId);

				if (deep && entity.SalesTerritoryHistoryCollection.Count > 0)
				{
					deepHandles.Add("SalesTerritoryHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesTerritoryHistory>) DataRepository.SalesTerritoryHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesTerritoryHistoryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer>|CustomerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerCollection = DataRepository.CustomerProvider.GetByTerritoryId(transactionManager, entity.TerritoryId);

				if (deep && entity.CustomerCollection.Count > 0)
				{
					deepHandles.Add("CustomerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesTerritory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesTerritory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesTerritory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTerritory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<StateProvince>
				if (CanDeepSave(entity.StateProvinceCollection, "List<StateProvince>|StateProvinceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(StateProvince child in entity.StateProvinceCollection)
					{
						if(child.TerritoryIdSource != null)
						{
							child.TerritoryId = child.TerritoryIdSource.TerritoryId;
						}
						else
						{
							child.TerritoryId = entity.TerritoryId;
						}

					}

					if (entity.StateProvinceCollection.Count > 0 || entity.StateProvinceCollection.DeletedItems.Count > 0)
					{
						//DataRepository.StateProvinceProvider.Save(transactionManager, entity.StateProvinceCollection);
						
						deepHandles.Add("StateProvinceCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< StateProvince >) DataRepository.StateProvinceProvider.DeepSave,
							new object[] { transactionManager, entity.StateProvinceCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesOrderHeader>
				if (CanDeepSave(entity.SalesOrderHeaderCollection, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderHeader child in entity.SalesOrderHeaderCollection)
					{
						if(child.TerritoryIdSource != null)
						{
							child.TerritoryId = child.TerritoryIdSource.TerritoryId;
						}
						else
						{
							child.TerritoryId = entity.TerritoryId;
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
				
	
			#region List<SalesPerson>
				if (CanDeepSave(entity.SalesPersonCollection, "List<SalesPerson>|SalesPersonCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesPerson child in entity.SalesPersonCollection)
					{
						if(child.TerritoryIdSource != null)
						{
							child.TerritoryId = child.TerritoryIdSource.TerritoryId;
						}
						else
						{
							child.TerritoryId = entity.TerritoryId;
						}

					}

					if (entity.SalesPersonCollection.Count > 0 || entity.SalesPersonCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPersonCollection);
						
						deepHandles.Add("SalesPersonCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesPerson >) DataRepository.SalesPersonProvider.DeepSave,
							new object[] { transactionManager, entity.SalesPersonCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesTerritoryHistory>
				if (CanDeepSave(entity.SalesTerritoryHistoryCollection, "List<SalesTerritoryHistory>|SalesTerritoryHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesTerritoryHistory child in entity.SalesTerritoryHistoryCollection)
					{
						if(child.TerritoryIdSource != null)
						{
							child.TerritoryId = child.TerritoryIdSource.TerritoryId;
						}
						else
						{
							child.TerritoryId = entity.TerritoryId;
						}

					}

					if (entity.SalesTerritoryHistoryCollection.Count > 0 || entity.SalesTerritoryHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesTerritoryHistoryProvider.Save(transactionManager, entity.SalesTerritoryHistoryCollection);
						
						deepHandles.Add("SalesTerritoryHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesTerritoryHistory >) DataRepository.SalesTerritoryHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.SalesTerritoryHistoryCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Customer>
				if (CanDeepSave(entity.CustomerCollection, "List<Customer>|CustomerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer child in entity.CustomerCollection)
					{
						if(child.TerritoryIdSource != null)
						{
							child.TerritoryId = child.TerritoryIdSource.TerritoryId;
						}
						else
						{
							child.TerritoryId = entity.TerritoryId;
						}

					}

					if (entity.CustomerCollection.Count > 0 || entity.CustomerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerCollection);
						
						deepHandles.Add("CustomerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer >) DataRepository.CustomerProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerCollection, deepSaveType, childTypes, innerList }
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
	
	#region SalesTerritoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesTerritory</c>
	///</summary>
	public enum SalesTerritoryChildEntityTypes
	{

		///<summary>
		/// Collection of <c>SalesTerritory</c> as OneToMany for StateProvinceCollection
		///</summary>
		[ChildEntityType(typeof(TList<StateProvince>))]
		StateProvinceCollection,

		///<summary>
		/// Collection of <c>SalesTerritory</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollection,

		///<summary>
		/// Collection of <c>SalesTerritory</c> as OneToMany for SalesPersonCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesPerson>))]
		SalesPersonCollection,

		///<summary>
		/// Collection of <c>SalesTerritory</c> as OneToMany for SalesTerritoryHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesTerritoryHistory>))]
		SalesTerritoryHistoryCollection,

		///<summary>
		/// Collection of <c>SalesTerritory</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollection,
	}
	
	#endregion SalesTerritoryChildEntityTypes
	
	#region SalesTerritoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesTerritoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryFilterBuilder : SqlFilterBuilder<SalesTerritoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryFilterBuilder class.
		/// </summary>
		public SalesTerritoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTerritoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTerritoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTerritoryFilterBuilder
	
	#region SalesTerritoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesTerritoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryParameterBuilder : ParameterizedSqlFilterBuilder<SalesTerritoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryParameterBuilder class.
		/// </summary>
		public SalesTerritoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTerritoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTerritoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTerritoryParameterBuilder
	
	#region SalesTerritorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesTerritoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesTerritorySortBuilder : SqlSortBuilder<SalesTerritoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritorySqlSortBuilder class.
		/// </summary>
		public SalesTerritorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesTerritorySortBuilder
	
} // end namespace
