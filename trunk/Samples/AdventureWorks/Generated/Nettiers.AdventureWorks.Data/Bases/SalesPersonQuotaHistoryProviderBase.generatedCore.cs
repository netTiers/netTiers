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
	/// This class is the base class for any <see cref="SalesPersonQuotaHistoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesPersonQuotaHistoryProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory, Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistoryKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistoryKey key)
		{
			return Delete(transactionManager, key.SalesPersonId, key.QuotaDate);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.. Primary Key.</param>
		/// <param name="_quotaDate">Sales quota date.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salesPersonId, System.DateTime _quotaDate)
		{
			return Delete(null, _salesPersonId, _quotaDate);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.. Primary Key.</param>
		/// <param name="_quotaDate">Sales quota date.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salesPersonId, System.DateTime _quotaDate);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID key.
		///		FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory objects.</returns>
		public TList<SalesPersonQuotaHistory> GetBySalesPersonId(System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(_salesPersonId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID key.
		///		FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory objects.</returns>
		/// <remarks></remarks>
		public TList<SalesPersonQuotaHistory> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID key.
		///		FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory objects.</returns>
		public TList<SalesPersonQuotaHistory> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID key.
		///		fkSalesPersonQuotaHistorySalesPersonSalesPersonId Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory objects.</returns>
		public TList<SalesPersonQuotaHistory> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID key.
		///		fkSalesPersonQuotaHistorySalesPersonSalesPersonId Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory objects.</returns>
		public TList<SalesPersonQuotaHistory> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength,out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID key.
		///		FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory objects.</returns>
		public abstract TList<SalesPersonQuotaHistory> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistoryKey key, int start, int pageLength)
		{
			return GetBySalesPersonIdQuotaDate(transactionManager, key.SalesPersonId, key.QuotaDate, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesPersonQuotaHistory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPersonQuotaHistory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPersonQuotaHistory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPersonQuotaHistory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPersonQuotaHistory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesPersonQuotaHistory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesPersonQuotaHistory_SalesPersonID_QuotaDate index.
		/// </summary>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="_quotaDate">Sales quota date.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetBySalesPersonIdQuotaDate(System.Int32 _salesPersonId, System.DateTime _quotaDate)
		{
			int count = -1;
			return GetBySalesPersonIdQuotaDate(null,_salesPersonId, _quotaDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPersonQuotaHistory_SalesPersonID_QuotaDate index.
		/// </summary>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="_quotaDate">Sales quota date.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetBySalesPersonIdQuotaDate(System.Int32 _salesPersonId, System.DateTime _quotaDate, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonIdQuotaDate(null, _salesPersonId, _quotaDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPersonQuotaHistory_SalesPersonID_QuotaDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="_quotaDate">Sales quota date.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetBySalesPersonIdQuotaDate(TransactionManager transactionManager, System.Int32 _salesPersonId, System.DateTime _quotaDate)
		{
			int count = -1;
			return GetBySalesPersonIdQuotaDate(transactionManager, _salesPersonId, _quotaDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPersonQuotaHistory_SalesPersonID_QuotaDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="_quotaDate">Sales quota date.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetBySalesPersonIdQuotaDate(TransactionManager transactionManager, System.Int32 _salesPersonId, System.DateTime _quotaDate, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonIdQuotaDate(transactionManager, _salesPersonId, _quotaDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPersonQuotaHistory_SalesPersonID_QuotaDate index.
		/// </summary>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="_quotaDate">Sales quota date.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetBySalesPersonIdQuotaDate(System.Int32 _salesPersonId, System.DateTime _quotaDate, int start, int pageLength, out int count)
		{
			return GetBySalesPersonIdQuotaDate(null, _salesPersonId, _quotaDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesPersonQuotaHistory_SalesPersonID_QuotaDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person identification number. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="_quotaDate">Sales quota date.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory GetBySalesPersonIdQuotaDate(TransactionManager transactionManager, System.Int32 _salesPersonId, System.DateTime _quotaDate, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesPersonQuotaHistory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesPersonQuotaHistory&gt;"/></returns>
		public static TList<SalesPersonQuotaHistory> Fill(IDataReader reader, TList<SalesPersonQuotaHistory> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesPersonQuotaHistory")
					.Append("|").Append((System.Int32)reader[((int)SalesPersonQuotaHistoryColumn.SalesPersonId - 1)])
					.Append("|").Append((System.DateTime)reader[((int)SalesPersonQuotaHistoryColumn.QuotaDate - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesPersonQuotaHistory>(
					key.ToString(), // EntityTrackingKey
					"SalesPersonQuotaHistory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory();
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
					c.SalesPersonId = (System.Int32)reader[((int)SalesPersonQuotaHistoryColumn.SalesPersonId - 1)];
					c.OriginalSalesPersonId = c.SalesPersonId;
					c.QuotaDate = (System.DateTime)reader[((int)SalesPersonQuotaHistoryColumn.QuotaDate - 1)];
					c.OriginalQuotaDate = c.QuotaDate;
					c.SalesQuota = (System.Decimal)reader[((int)SalesPersonQuotaHistoryColumn.SalesQuota - 1)];
					c.Rowguid = (System.Guid)reader[((int)SalesPersonQuotaHistoryColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SalesPersonQuotaHistoryColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory entity)
		{
			if (!reader.Read()) return;
			
			entity.SalesPersonId = (System.Int32)reader[((int)SalesPersonQuotaHistoryColumn.SalesPersonId - 1)];
			entity.OriginalSalesPersonId = (System.Int32)reader["SalesPersonID"];
			entity.QuotaDate = (System.DateTime)reader[((int)SalesPersonQuotaHistoryColumn.QuotaDate - 1)];
			entity.OriginalQuotaDate = (System.DateTime)reader["QuotaDate"];
			entity.SalesQuota = (System.Decimal)reader[((int)SalesPersonQuotaHistoryColumn.SalesQuota - 1)];
			entity.Rowguid = (System.Guid)reader[((int)SalesPersonQuotaHistoryColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesPersonQuotaHistoryColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.OriginalSalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.QuotaDate = (System.DateTime)dataRow["QuotaDate"];
			entity.OriginalQuotaDate = (System.DateTime)dataRow["QuotaDate"];
			entity.SalesQuota = (System.Decimal)dataRow["SalesQuota"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SalesPersonIdSource	
			if (CanDeepLoad(entity, "SalesPerson|SalesPersonIdSource", deepLoadType, innerList) 
				&& entity.SalesPersonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalesPersonId;
				SalesPerson tmpEntity = EntityManager.LocateEntity<SalesPerson>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesPerson), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesPersonIdSource = tmpEntity;
				else
					entity.SalesPersonIdSource = DataRepository.SalesPersonProvider.GetBySalesPersonId(transactionManager, entity.SalesPersonId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesPersonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesPersonProvider.DeepLoad(transactionManager, entity.SalesPersonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesPersonIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SalesPersonIdSource
			if (CanDeepSave(entity, "SalesPerson|SalesPersonIdSource", deepSaveType, innerList) 
				&& entity.SalesPersonIdSource != null)
			{
				DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPersonIdSource);
				entity.SalesPersonId = entity.SalesPersonIdSource.SalesPersonId;
			}
			#endregion 
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
	
	#region SalesPersonQuotaHistoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesPersonQuotaHistory</c>
	///</summary>
	public enum SalesPersonQuotaHistoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
		}
	
	#endregion SalesPersonQuotaHistoryChildEntityTypes
	
	#region SalesPersonQuotaHistoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesPersonQuotaHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPersonQuotaHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuotaHistoryFilterBuilder : SqlFilterBuilder<SalesPersonQuotaHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryFilterBuilder class.
		/// </summary>
		public SalesPersonQuotaHistoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonQuotaHistoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonQuotaHistoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonQuotaHistoryFilterBuilder
	
	#region SalesPersonQuotaHistoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesPersonQuotaHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPersonQuotaHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuotaHistoryParameterBuilder : ParameterizedSqlFilterBuilder<SalesPersonQuotaHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryParameterBuilder class.
		/// </summary>
		public SalesPersonQuotaHistoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonQuotaHistoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonQuotaHistoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonQuotaHistoryParameterBuilder
	
	#region SalesPersonQuotaHistorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesPersonQuotaHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPersonQuotaHistory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesPersonQuotaHistorySortBuilder : SqlSortBuilder<SalesPersonQuotaHistoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistorySqlSortBuilder class.
		/// </summary>
		public SalesPersonQuotaHistorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesPersonQuotaHistorySortBuilder
	
} // end namespace
