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
	/// This class is the base class for any <see cref="SalesTerritoryHistoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesTerritoryHistoryProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesTerritoryHistory, Nettiers.AdventureWorks.Entities.SalesTerritoryHistoryKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTerritoryHistoryKey key)
		{
			return Delete(transactionManager, key.SalesPersonId, key.StartDate, key.TerritoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.. Primary Key.</param>
		/// <param name="_startDate">Date the sales representive started work in the territory.. Primary Key.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salesPersonId, System.DateTime _startDate, System.Int32 _territoryId)
		{
			return Delete(null, _salesPersonId, _startDate, _territoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.. Primary Key.</param>
		/// <param name="_startDate">Date the sales representive started work in the territory.. Primary Key.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salesPersonId, System.DateTime _startDate, System.Int32 _territoryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesPerson_SalesPersonID key.
		///		FK_SalesTerritoryHistory_SalesPerson_SalesPersonID Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public TList<SalesTerritoryHistory> GetBySalesPersonId(System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(_salesPersonId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesPerson_SalesPersonID key.
		///		FK_SalesTerritoryHistory_SalesPerson_SalesPersonID Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		/// <remarks></remarks>
		public TList<SalesTerritoryHistory> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesPerson_SalesPersonID key.
		///		FK_SalesTerritoryHistory_SalesPerson_SalesPersonID Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public TList<SalesTerritoryHistory> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesPerson_SalesPersonID key.
		///		fkSalesTerritoryHistorySalesPersonSalesPersonId Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public TList<SalesTerritoryHistory> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesPerson_SalesPersonID key.
		///		fkSalesTerritoryHistorySalesPersonSalesPersonId Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public TList<SalesTerritoryHistory> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength,out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesPerson_SalesPersonID key.
		///		FK_SalesTerritoryHistory_SalesPerson_SalesPersonID Description: Foreign key constraint referencing SalesPerson.SalesPersonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public abstract TList<SalesTerritoryHistory> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesTerritory_TerritoryID key.
		///		FK_SalesTerritoryHistory_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public TList<SalesTerritoryHistory> GetByTerritoryId(System.Int32 _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(_territoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesTerritory_TerritoryID key.
		///		FK_SalesTerritoryHistory_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		/// <remarks></remarks>
		public TList<SalesTerritoryHistory> GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesTerritory_TerritoryID key.
		///		FK_SalesTerritoryHistory_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public TList<SalesTerritoryHistory> GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesTerritory_TerritoryID key.
		///		fkSalesTerritoryHistorySalesTerritoryTerritoryId Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public TList<SalesTerritoryHistory> GetByTerritoryId(System.Int32 _territoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTerritoryId(null, _territoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesTerritory_TerritoryID key.
		///		fkSalesTerritoryHistorySalesTerritoryTerritoryId Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public TList<SalesTerritoryHistory> GetByTerritoryId(System.Int32 _territoryId, int start, int pageLength,out int count)
		{
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTerritoryHistory_SalesTerritory_TerritoryID key.
		///		FK_SalesTerritoryHistory_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTerritoryHistory objects.</returns>
		public abstract TList<SalesTerritoryHistory> GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.SalesTerritoryHistory Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTerritoryHistoryKey key, int start, int pageLength)
		{
			return GetBySalesPersonIdStartDateTerritoryId(transactionManager, key.SalesPersonId, key.StartDate, key.TerritoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesTerritoryHistory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritoryHistory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritoryHistory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritoryHistory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritoryHistory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTerritoryHistory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesTerritoryHistory_SalesPersonID_StartDate_TerritoryID index.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="_startDate">Date the sales representive started work in the territory.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetBySalesPersonIdStartDateTerritoryId(System.Int32 _salesPersonId, System.DateTime _startDate, System.Int32 _territoryId)
		{
			int count = -1;
			return GetBySalesPersonIdStartDateTerritoryId(null,_salesPersonId, _startDate, _territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritoryHistory_SalesPersonID_StartDate_TerritoryID index.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="_startDate">Date the sales representive started work in the territory.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetBySalesPersonIdStartDateTerritoryId(System.Int32 _salesPersonId, System.DateTime _startDate, System.Int32 _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonIdStartDateTerritoryId(null, _salesPersonId, _startDate, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritoryHistory_SalesPersonID_StartDate_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="_startDate">Date the sales representive started work in the territory.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetBySalesPersonIdStartDateTerritoryId(TransactionManager transactionManager, System.Int32 _salesPersonId, System.DateTime _startDate, System.Int32 _territoryId)
		{
			int count = -1;
			return GetBySalesPersonIdStartDateTerritoryId(transactionManager, _salesPersonId, _startDate, _territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritoryHistory_SalesPersonID_StartDate_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="_startDate">Date the sales representive started work in the territory.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetBySalesPersonIdStartDateTerritoryId(TransactionManager transactionManager, System.Int32 _salesPersonId, System.DateTime _startDate, System.Int32 _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonIdStartDateTerritoryId(transactionManager, _salesPersonId, _startDate, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritoryHistory_SalesPersonID_StartDate_TerritoryID index.
		/// </summary>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="_startDate">Date the sales representive started work in the territory.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetBySalesPersonIdStartDateTerritoryId(System.Int32 _salesPersonId, System.DateTime _startDate, System.Int32 _territoryId, int start, int pageLength, out int count)
		{
			return GetBySalesPersonIdStartDateTerritoryId(null, _salesPersonId, _startDate, _territoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTerritoryHistory_SalesPersonID_StartDate_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Primary key for SalesTerritoryHistory records.</param>
		/// <param name="_startDate">Date the sales representive started work in the territory.</param>
		/// <param name="_territoryId">Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesTerritoryHistory GetBySalesPersonIdStartDateTerritoryId(TransactionManager transactionManager, System.Int32 _salesPersonId, System.DateTime _startDate, System.Int32 _territoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesTerritoryHistory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesTerritoryHistory&gt;"/></returns>
		public static TList<SalesTerritoryHistory> Fill(IDataReader reader, TList<SalesTerritoryHistory> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SalesTerritoryHistory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesTerritoryHistory")
					.Append("|").Append((System.Int32)reader[((int)SalesTerritoryHistoryColumn.SalesPersonId - 1)])
					.Append("|").Append((System.Int32)reader[((int)SalesTerritoryHistoryColumn.TerritoryId - 1)])
					.Append("|").Append((System.DateTime)reader[((int)SalesTerritoryHistoryColumn.StartDate - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesTerritoryHistory>(
					key.ToString(), // EntityTrackingKey
					"SalesTerritoryHistory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesTerritoryHistory();
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
					c.SalesPersonId = (System.Int32)reader[((int)SalesTerritoryHistoryColumn.SalesPersonId - 1)];
					c.OriginalSalesPersonId = c.SalesPersonId;
					c.TerritoryId = (System.Int32)reader[((int)SalesTerritoryHistoryColumn.TerritoryId - 1)];
					c.OriginalTerritoryId = c.TerritoryId;
					c.StartDate = (System.DateTime)reader[((int)SalesTerritoryHistoryColumn.StartDate - 1)];
					c.OriginalStartDate = c.StartDate;
					c.EndDate = (reader.IsDBNull(((int)SalesTerritoryHistoryColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)SalesTerritoryHistoryColumn.EndDate - 1)];
					c.Rowguid = (System.Guid)reader[((int)SalesTerritoryHistoryColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SalesTerritoryHistoryColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesTerritoryHistory entity)
		{
			if (!reader.Read()) return;
			
			entity.SalesPersonId = (System.Int32)reader[((int)SalesTerritoryHistoryColumn.SalesPersonId - 1)];
			entity.OriginalSalesPersonId = (System.Int32)reader["SalesPersonID"];
			entity.TerritoryId = (System.Int32)reader[((int)SalesTerritoryHistoryColumn.TerritoryId - 1)];
			entity.OriginalTerritoryId = (System.Int32)reader["TerritoryID"];
			entity.StartDate = (System.DateTime)reader[((int)SalesTerritoryHistoryColumn.StartDate - 1)];
			entity.OriginalStartDate = (System.DateTime)reader["StartDate"];
			entity.EndDate = (reader.IsDBNull(((int)SalesTerritoryHistoryColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)SalesTerritoryHistoryColumn.EndDate - 1)];
			entity.Rowguid = (System.Guid)reader[((int)SalesTerritoryHistoryColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesTerritoryHistoryColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesTerritoryHistory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.OriginalSalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.TerritoryId = (System.Int32)dataRow["TerritoryID"];
			entity.OriginalTerritoryId = (System.Int32)dataRow["TerritoryID"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.OriginalStartDate = (System.DateTime)dataRow["StartDate"];
			entity.EndDate = Convert.IsDBNull(dataRow["EndDate"]) ? null : (System.DateTime?)dataRow["EndDate"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTerritoryHistory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesTerritoryHistory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTerritoryHistory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region TerritoryIdSource	
			if (CanDeepLoad(entity, "SalesTerritory|TerritoryIdSource", deepLoadType, innerList) 
				&& entity.TerritoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TerritoryId;
				SalesTerritory tmpEntity = EntityManager.LocateEntity<SalesTerritory>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesTerritory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TerritoryIdSource = tmpEntity;
				else
					entity.TerritoryIdSource = DataRepository.SalesTerritoryProvider.GetByTerritoryId(transactionManager, entity.TerritoryId);		
				
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesTerritoryHistory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesTerritoryHistory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesTerritoryHistory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTerritoryHistory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region SalesTerritoryHistoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesTerritoryHistory</c>
	///</summary>
	public enum SalesTerritoryHistoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
			
		///<summary>
		/// Composite Property for <c>SalesTerritory</c> at TerritoryIdSource
		///</summary>
		[ChildEntityType(typeof(SalesTerritory))]
		SalesTerritory,
		}
	
	#endregion SalesTerritoryHistoryChildEntityTypes
	
	#region SalesTerritoryHistoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesTerritoryHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritoryHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryHistoryFilterBuilder : SqlFilterBuilder<SalesTerritoryHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryFilterBuilder class.
		/// </summary>
		public SalesTerritoryHistoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTerritoryHistoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTerritoryHistoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTerritoryHistoryFilterBuilder
	
	#region SalesTerritoryHistoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesTerritoryHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritoryHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryHistoryParameterBuilder : ParameterizedSqlFilterBuilder<SalesTerritoryHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryParameterBuilder class.
		/// </summary>
		public SalesTerritoryHistoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTerritoryHistoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTerritoryHistoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTerritoryHistoryParameterBuilder
	
	#region SalesTerritoryHistorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesTerritoryHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritoryHistory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesTerritoryHistorySortBuilder : SqlSortBuilder<SalesTerritoryHistoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistorySqlSortBuilder class.
		/// </summary>
		public SalesTerritoryHistorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesTerritoryHistorySortBuilder
	
} // end namespace
