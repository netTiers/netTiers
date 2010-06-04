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
	/// This class is the base class for any <see cref="SalesPersonProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesPersonProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesPerson, Nettiers.AdventureWorks.Entities.SalesPersonKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesPersonKey key)
		{
			return Delete(transactionManager, key.SalesPersonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesPerson records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salesPersonId)
		{
			return Delete(null, _salesPersonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesPerson records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salesPersonId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesTerritory_TerritoryID key.
		///		FK_SalesPerson_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="_territoryId">Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPerson objects.</returns>
		public TList<SalesPerson> GetByTerritoryId(System.Int32? _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(_territoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesTerritory_TerritoryID key.
		///		FK_SalesPerson_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPerson objects.</returns>
		/// <remarks></remarks>
		public TList<SalesPerson> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesTerritory_TerritoryID key.
		///		FK_SalesPerson_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPerson objects.</returns>
		public TList<SalesPerson> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesTerritory_TerritoryID key.
		///		fkSalesPersonSalesTerritoryTerritoryId Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId">Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPerson objects.</returns>
		public TList<SalesPerson> GetByTerritoryId(System.Int32? _territoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTerritoryId(null, _territoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesTerritory_TerritoryID key.
		///		fkSalesPersonSalesTerritoryTerritoryId Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId">Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPerson objects.</returns>
		public TList<SalesPerson> GetByTerritoryId(System.Int32? _territoryId, int start, int pageLength,out int count)
		{
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesTerritory_TerritoryID key.
		///		FK_SalesPerson_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPerson objects.</returns>
		public abstract TList<SalesPerson> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.SalesPerson Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesPersonKey key, int start, int pageLength)
		{
			return GetBySalesPersonId(transactionManager, key.SalesPersonId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesPerson_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPerson_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPerson_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPerson_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPerson_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPerson_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesPerson GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesPerson_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesPerson records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetBySalesPersonId(System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(null,_salesPersonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPerson_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesPerson records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPerson_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesPerson records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPerson_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesPerson records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPerson_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesPerson records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPerson GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength, out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPerson_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesPerson records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesPerson GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesPerson&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesPerson&gt;"/></returns>
		public static TList<SalesPerson> Fill(IDataReader reader, TList<SalesPerson> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SalesPerson c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesPerson")
					.Append("|").Append((System.Int32)reader[((int)SalesPersonColumn.SalesPersonId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesPerson>(
					key.ToString(), // EntityTrackingKey
					"SalesPerson",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesPerson();
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
					c.SalesPersonId = (System.Int32)reader[((int)SalesPersonColumn.SalesPersonId - 1)];
					c.OriginalSalesPersonId = c.SalesPersonId;
					c.TerritoryId = (reader.IsDBNull(((int)SalesPersonColumn.TerritoryId - 1)))?null:(System.Int32?)reader[((int)SalesPersonColumn.TerritoryId - 1)];
					c.SalesQuota = (reader.IsDBNull(((int)SalesPersonColumn.SalesQuota - 1)))?null:(System.Decimal?)reader[((int)SalesPersonColumn.SalesQuota - 1)];
					c.Bonus = (System.Decimal)reader[((int)SalesPersonColumn.Bonus - 1)];
					c.CommissionPct = (System.Decimal)reader[((int)SalesPersonColumn.CommissionPct - 1)];
					c.SalesYtd = (System.Decimal)reader[((int)SalesPersonColumn.SalesYtd - 1)];
					c.SalesLastYear = (System.Decimal)reader[((int)SalesPersonColumn.SalesLastYear - 1)];
					c.Rowguid = (System.Guid)reader[((int)SalesPersonColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SalesPersonColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesPerson entity)
		{
			if (!reader.Read()) return;
			
			entity.SalesPersonId = (System.Int32)reader[((int)SalesPersonColumn.SalesPersonId - 1)];
			entity.OriginalSalesPersonId = (System.Int32)reader["SalesPersonID"];
			entity.TerritoryId = (reader.IsDBNull(((int)SalesPersonColumn.TerritoryId - 1)))?null:(System.Int32?)reader[((int)SalesPersonColumn.TerritoryId - 1)];
			entity.SalesQuota = (reader.IsDBNull(((int)SalesPersonColumn.SalesQuota - 1)))?null:(System.Decimal?)reader[((int)SalesPersonColumn.SalesQuota - 1)];
			entity.Bonus = (System.Decimal)reader[((int)SalesPersonColumn.Bonus - 1)];
			entity.CommissionPct = (System.Decimal)reader[((int)SalesPersonColumn.CommissionPct - 1)];
			entity.SalesYtd = (System.Decimal)reader[((int)SalesPersonColumn.SalesYtd - 1)];
			entity.SalesLastYear = (System.Decimal)reader[((int)SalesPersonColumn.SalesLastYear - 1)];
			entity.Rowguid = (System.Guid)reader[((int)SalesPersonColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesPersonColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesPerson entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.OriginalSalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.TerritoryId = Convert.IsDBNull(dataRow["TerritoryID"]) ? null : (System.Int32?)dataRow["TerritoryID"];
			entity.SalesQuota = Convert.IsDBNull(dataRow["SalesQuota"]) ? null : (System.Decimal?)dataRow["SalesQuota"];
			entity.Bonus = (System.Decimal)dataRow["Bonus"];
			entity.CommissionPct = (System.Decimal)dataRow["CommissionPct"];
			entity.SalesYtd = (System.Decimal)dataRow["SalesYTD"];
			entity.SalesLastYear = (System.Decimal)dataRow["SalesLastYear"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesPerson"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesPerson Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesPerson entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SalesPersonIdSource	
			if (CanDeepLoad(entity, "Employee|SalesPersonIdSource", deepLoadType, innerList) 
				&& entity.SalesPersonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalesPersonId;
				Employee tmpEntity = EntityManager.LocateEntity<Employee>(EntityLocator.ConstructKeyFromPkItems(typeof(Employee), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesPersonIdSource = tmpEntity;
				else
					entity.SalesPersonIdSource = DataRepository.EmployeeProvider.GetByEmployeeId(transactionManager, entity.SalesPersonId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesPersonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeeProvider.DeepLoad(transactionManager, entity.SalesPersonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesPersonIdSource

			#region TerritoryIdSource	
			if (CanDeepLoad(entity, "SalesTerritory|TerritoryIdSource", deepLoadType, innerList) 
				&& entity.TerritoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.TerritoryId ?? (int)0);
				SalesTerritory tmpEntity = EntityManager.LocateEntity<SalesTerritory>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesTerritory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TerritoryIdSource = tmpEntity;
				else
					entity.TerritoryIdSource = DataRepository.SalesTerritoryProvider.GetByTerritoryId(transactionManager, (entity.TerritoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TerritoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TerritoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesTerritoryProvider.DeepLoad(transactionManager, entity.TerritoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TerritoryIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySalesPersonId methods when available
			
			#region StoreCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Store>|StoreCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StoreCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.StoreCollection = DataRepository.StoreProvider.GetBySalesPersonId(transactionManager, entity.SalesPersonId);

				if (deep && entity.StoreCollection.Count > 0)
				{
					deepHandles.Add("StoreCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Store>) DataRepository.StoreProvider.DeepLoad,
						new object[] { transactionManager, entity.StoreCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesPersonQuotaHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesPersonQuotaHistory>|SalesPersonQuotaHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonQuotaHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesPersonQuotaHistoryCollection = DataRepository.SalesPersonQuotaHistoryProvider.GetBySalesPersonId(transactionManager, entity.SalesPersonId);

				if (deep && entity.SalesPersonQuotaHistoryCollection.Count > 0)
				{
					deepHandles.Add("SalesPersonQuotaHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesPersonQuotaHistory>) DataRepository.SalesPersonQuotaHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesPersonQuotaHistoryCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.SalesOrderHeaderCollection = DataRepository.SalesOrderHeaderProvider.GetBySalesPersonId(transactionManager, entity.SalesPersonId);

				if (deep && entity.SalesOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.SalesTerritoryHistoryCollection = DataRepository.SalesTerritoryHistoryProvider.GetBySalesPersonId(transactionManager, entity.SalesPersonId);

				if (deep && entity.SalesTerritoryHistoryCollection.Count > 0)
				{
					deepHandles.Add("SalesTerritoryHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesTerritoryHistory>) DataRepository.SalesTerritoryHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesTerritoryHistoryCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesPerson object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesPerson instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesPerson Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesPerson entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SalesPersonIdSource
			if (CanDeepSave(entity, "Employee|SalesPersonIdSource", deepSaveType, innerList) 
				&& entity.SalesPersonIdSource != null)
			{
				DataRepository.EmployeeProvider.Save(transactionManager, entity.SalesPersonIdSource);
				entity.SalesPersonId = entity.SalesPersonIdSource.EmployeeId;
			}
			#endregion 
			
			#region TerritoryIdSource
			if (CanDeepSave(entity, "SalesTerritory|TerritoryIdSource", deepSaveType, innerList) 
				&& entity.TerritoryIdSource != null)
			{
				DataRepository.SalesTerritoryProvider.Save(transactionManager, entity.TerritoryIdSource);
				entity.TerritoryId = entity.TerritoryIdSource.TerritoryId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Store>
				if (CanDeepSave(entity.StoreCollection, "List<Store>|StoreCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Store child in entity.StoreCollection)
					{
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.SalesPersonId;
						}
						else
						{
							child.SalesPersonId = entity.SalesPersonId;
						}

					}

					if (entity.StoreCollection.Count > 0 || entity.StoreCollection.DeletedItems.Count > 0)
					{
						//DataRepository.StoreProvider.Save(transactionManager, entity.StoreCollection);
						
						deepHandles.Add("StoreCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Store >) DataRepository.StoreProvider.DeepSave,
							new object[] { transactionManager, entity.StoreCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesPersonQuotaHistory>
				if (CanDeepSave(entity.SalesPersonQuotaHistoryCollection, "List<SalesPersonQuotaHistory>|SalesPersonQuotaHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesPersonQuotaHistory child in entity.SalesPersonQuotaHistoryCollection)
					{
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.SalesPersonId;
						}
						else
						{
							child.SalesPersonId = entity.SalesPersonId;
						}

					}

					if (entity.SalesPersonQuotaHistoryCollection.Count > 0 || entity.SalesPersonQuotaHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesPersonQuotaHistoryProvider.Save(transactionManager, entity.SalesPersonQuotaHistoryCollection);
						
						deepHandles.Add("SalesPersonQuotaHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesPersonQuotaHistory >) DataRepository.SalesPersonQuotaHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.SalesPersonQuotaHistoryCollection, deepSaveType, childTypes, innerList }
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
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.SalesPersonId;
						}
						else
						{
							child.SalesPersonId = entity.SalesPersonId;
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
				
	
			#region List<SalesTerritoryHistory>
				if (CanDeepSave(entity.SalesTerritoryHistoryCollection, "List<SalesTerritoryHistory>|SalesTerritoryHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesTerritoryHistory child in entity.SalesTerritoryHistoryCollection)
					{
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.SalesPersonId;
						}
						else
						{
							child.SalesPersonId = entity.SalesPersonId;
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
	
	#region SalesPersonChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesPerson</c>
	///</summary>
	public enum SalesPersonChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Employee</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
			
		///<summary>
		/// Composite Property for <c>SalesTerritory</c> at TerritoryIdSource
		///</summary>
		[ChildEntityType(typeof(SalesTerritory))]
		SalesTerritory,
	
		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for StoreCollection
		///</summary>
		[ChildEntityType(typeof(TList<Store>))]
		StoreCollection,

		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for SalesPersonQuotaHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesPersonQuotaHistory>))]
		SalesPersonQuotaHistoryCollection,

		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollection,

		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for SalesTerritoryHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesTerritoryHistory>))]
		SalesTerritoryHistoryCollection,
	}
	
	#endregion SalesPersonChildEntityTypes
	
	#region SalesPersonFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesPersonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonFilterBuilder : SqlFilterBuilder<SalesPersonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilterBuilder class.
		/// </summary>
		public SalesPersonFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonFilterBuilder
	
	#region SalesPersonParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesPersonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonParameterBuilder : ParameterizedSqlFilterBuilder<SalesPersonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonParameterBuilder class.
		/// </summary>
		public SalesPersonParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonParameterBuilder
	
	#region SalesPersonSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesPersonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesPersonSortBuilder : SqlSortBuilder<SalesPersonColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonSqlSortBuilder class.
		/// </summary>
		public SalesPersonSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesPersonSortBuilder
	
} // end namespace
