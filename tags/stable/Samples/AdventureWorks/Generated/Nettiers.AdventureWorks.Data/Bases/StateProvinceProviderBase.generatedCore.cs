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
	/// This class is the base class for any <see cref="StateProvinceProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class StateProvinceProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.StateProvince, Nettiers.AdventureWorks.Entities.StateProvinceKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StateProvinceKey key)
		{
			return Delete(transactionManager, key.StateProvinceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_stateProvinceId">Primary key for StateProvince records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _stateProvinceId)
		{
			return Delete(null, _stateProvinceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">Primary key for StateProvince records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _stateProvinceId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_CountryRegion_CountryRegionCode key.
		///		FK_StateProvince_CountryRegion_CountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public TList<StateProvince> GetByCountryRegionCode(System.String _countryRegionCode)
		{
			int count = -1;
			return GetByCountryRegionCode(_countryRegionCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_CountryRegion_CountryRegionCode key.
		///		FK_StateProvince_CountryRegion_CountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		/// <remarks></remarks>
		public TList<StateProvince> GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode)
		{
			int count = -1;
			return GetByCountryRegionCode(transactionManager, _countryRegionCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_CountryRegion_CountryRegionCode key.
		///		FK_StateProvince_CountryRegion_CountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public TList<StateProvince> GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryRegionCode(transactionManager, _countryRegionCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_CountryRegion_CountryRegionCode key.
		///		fkStateProvinceCountryRegionCountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public TList<StateProvince> GetByCountryRegionCode(System.String _countryRegionCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryRegionCode(null, _countryRegionCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_CountryRegion_CountryRegionCode key.
		///		fkStateProvinceCountryRegionCountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public TList<StateProvince> GetByCountryRegionCode(System.String _countryRegionCode, int start, int pageLength,out int count)
		{
			return GetByCountryRegionCode(null, _countryRegionCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_CountryRegion_CountryRegionCode key.
		///		FK_StateProvince_CountryRegion_CountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public abstract TList<StateProvince> GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_SalesTerritory_TerritoryID key.
		///		FK_StateProvince_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="_territoryId">ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public TList<StateProvince> GetByTerritoryId(System.Int32 _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(_territoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_SalesTerritory_TerritoryID key.
		///		FK_StateProvince_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		/// <remarks></remarks>
		public TList<StateProvince> GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_SalesTerritory_TerritoryID key.
		///		FK_StateProvince_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public TList<StateProvince> GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_SalesTerritory_TerritoryID key.
		///		fkStateProvinceSalesTerritoryTerritoryId Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId">ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public TList<StateProvince> GetByTerritoryId(System.Int32 _territoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTerritoryId(null, _territoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_SalesTerritory_TerritoryID key.
		///		fkStateProvinceSalesTerritoryTerritoryId Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId">ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public TList<StateProvince> GetByTerritoryId(System.Int32 _territoryId, int start, int pageLength,out int count)
		{
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_StateProvince_SalesTerritory_TerritoryID key.
		///		FK_StateProvince_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.StateProvince objects.</returns>
		public abstract TList<StateProvince> GetByTerritoryId(TransactionManager transactionManager, System.Int32 _territoryId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.StateProvince Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StateProvinceKey key, int start, int pageLength)
		{
			return GetByStateProvinceId(transactionManager, key.StateProvinceId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_StateProvince_Name index.
		/// </summary>
		/// <param name="_name">State or province description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_Name index.
		/// </summary>
		/// <param name="_name">State or province description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">State or province description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">State or province description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_Name index.
		/// </summary>
		/// <param name="_name">State or province description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">State or province description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.StateProvince GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_StateProvince_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.StateProvince GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_StateProvince_StateProvinceCode_CountryRegionCode index.
		/// </summary>
		/// <param name="_stateProvinceCode">ISO standard state or province code.</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceCodeCountryRegionCode(System.String _stateProvinceCode, System.String _countryRegionCode)
		{
			int count = -1;
			return GetByStateProvinceCodeCountryRegionCode(null,_stateProvinceCode, _countryRegionCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_StateProvinceCode_CountryRegionCode index.
		/// </summary>
		/// <param name="_stateProvinceCode">ISO standard state or province code.</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceCodeCountryRegionCode(System.String _stateProvinceCode, System.String _countryRegionCode, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceCodeCountryRegionCode(null, _stateProvinceCode, _countryRegionCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_StateProvinceCode_CountryRegionCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceCode">ISO standard state or province code.</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceCodeCountryRegionCode(TransactionManager transactionManager, System.String _stateProvinceCode, System.String _countryRegionCode)
		{
			int count = -1;
			return GetByStateProvinceCodeCountryRegionCode(transactionManager, _stateProvinceCode, _countryRegionCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_StateProvinceCode_CountryRegionCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceCode">ISO standard state or province code.</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceCodeCountryRegionCode(TransactionManager transactionManager, System.String _stateProvinceCode, System.String _countryRegionCode, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceCodeCountryRegionCode(transactionManager, _stateProvinceCode, _countryRegionCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_StateProvinceCode_CountryRegionCode index.
		/// </summary>
		/// <param name="_stateProvinceCode">ISO standard state or province code.</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceCodeCountryRegionCode(System.String _stateProvinceCode, System.String _countryRegionCode, int start, int pageLength, out int count)
		{
			return GetByStateProvinceCodeCountryRegionCode(null, _stateProvinceCode, _countryRegionCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_StateProvince_StateProvinceCode_CountryRegionCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceCode">ISO standard state or province code.</param>
		/// <param name="_countryRegionCode">ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceCodeCountryRegionCode(TransactionManager transactionManager, System.String _stateProvinceCode, System.String _countryRegionCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_StateProvince_StateProvinceID index.
		/// </summary>
		/// <param name="_stateProvinceId">Primary key for StateProvince records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceId(System.Int32 _stateProvinceId)
		{
			int count = -1;
			return GetByStateProvinceId(null,_stateProvinceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_StateProvince_StateProvinceID index.
		/// </summary>
		/// <param name="_stateProvinceId">Primary key for StateProvince records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceId(System.Int32 _stateProvinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceId(null, _stateProvinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_StateProvince_StateProvinceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">Primary key for StateProvince records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId)
		{
			int count = -1;
			return GetByStateProvinceId(transactionManager, _stateProvinceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_StateProvince_StateProvinceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">Primary key for StateProvince records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceId(transactionManager, _stateProvinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_StateProvince_StateProvinceID index.
		/// </summary>
		/// <param name="_stateProvinceId">Primary key for StateProvince records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceId(System.Int32 _stateProvinceId, int start, int pageLength, out int count)
		{
			return GetByStateProvinceId(null, _stateProvinceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_StateProvince_StateProvinceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">Primary key for StateProvince records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.StateProvince GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;StateProvince&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;StateProvince&gt;"/></returns>
		public static TList<StateProvince> Fill(IDataReader reader, TList<StateProvince> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.StateProvince c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("StateProvince")
					.Append("|").Append((System.Int32)reader[((int)StateProvinceColumn.StateProvinceId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<StateProvince>(
					key.ToString(), // EntityTrackingKey
					"StateProvince",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.StateProvince();
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
					c.StateProvinceId = (System.Int32)reader[((int)StateProvinceColumn.StateProvinceId - 1)];
					c.StateProvinceCode = (System.String)reader[((int)StateProvinceColumn.StateProvinceCode - 1)];
					c.CountryRegionCode = (System.String)reader[((int)StateProvinceColumn.CountryRegionCode - 1)];
					c.IsOnlyStateProvinceFlag = (System.Boolean)reader[((int)StateProvinceColumn.IsOnlyStateProvinceFlag - 1)];
					c.Name = (System.String)reader[((int)StateProvinceColumn.Name - 1)];
					c.TerritoryId = (System.Int32)reader[((int)StateProvinceColumn.TerritoryId - 1)];
					c.Rowguid = (System.Guid)reader[((int)StateProvinceColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)StateProvinceColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.StateProvince entity)
		{
			if (!reader.Read()) return;
			
			entity.StateProvinceId = (System.Int32)reader[((int)StateProvinceColumn.StateProvinceId - 1)];
			entity.StateProvinceCode = (System.String)reader[((int)StateProvinceColumn.StateProvinceCode - 1)];
			entity.CountryRegionCode = (System.String)reader[((int)StateProvinceColumn.CountryRegionCode - 1)];
			entity.IsOnlyStateProvinceFlag = (System.Boolean)reader[((int)StateProvinceColumn.IsOnlyStateProvinceFlag - 1)];
			entity.Name = (System.String)reader[((int)StateProvinceColumn.Name - 1)];
			entity.TerritoryId = (System.Int32)reader[((int)StateProvinceColumn.TerritoryId - 1)];
			entity.Rowguid = (System.Guid)reader[((int)StateProvinceColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)StateProvinceColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.StateProvince entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.StateProvinceId = (System.Int32)dataRow["StateProvinceID"];
			entity.StateProvinceCode = (System.String)dataRow["StateProvinceCode"];
			entity.CountryRegionCode = (System.String)dataRow["CountryRegionCode"];
			entity.IsOnlyStateProvinceFlag = (System.Boolean)dataRow["IsOnlyStateProvinceFlag"];
			entity.Name = (System.String)dataRow["Name"];
			entity.TerritoryId = (System.Int32)dataRow["TerritoryID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.StateProvince"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.StateProvince Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StateProvince entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CountryRegionCodeSource	
			if (CanDeepLoad(entity, "CountryRegion|CountryRegionCodeSource", deepLoadType, innerList) 
				&& entity.CountryRegionCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CountryRegionCode;
				CountryRegion tmpEntity = EntityManager.LocateEntity<CountryRegion>(EntityLocator.ConstructKeyFromPkItems(typeof(CountryRegion), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountryRegionCodeSource = tmpEntity;
				else
					entity.CountryRegionCodeSource = DataRepository.CountryRegionProvider.GetByCountryRegionCode(transactionManager, entity.CountryRegionCode);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryRegionCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountryRegionCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountryRegionProvider.DeepLoad(transactionManager, entity.CountryRegionCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CountryRegionCodeSource

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
			// Deep load child collections  - Call GetByStateProvinceId methods when available
			
			#region AddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Address>|AddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AddressCollection = DataRepository.AddressProvider.GetByStateProvinceId(transactionManager, entity.StateProvinceId);

				if (deep && entity.AddressCollection.Count > 0)
				{
					deepHandles.Add("AddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Address>) DataRepository.AddressProvider.DeepLoad,
						new object[] { transactionManager, entity.AddressCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesTaxRateCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesTaxRate>|SalesTaxRateCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesTaxRateCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesTaxRateCollection = DataRepository.SalesTaxRateProvider.GetByStateProvinceId(transactionManager, entity.StateProvinceId);

				if (deep && entity.SalesTaxRateCollection.Count > 0)
				{
					deepHandles.Add("SalesTaxRateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesTaxRate>) DataRepository.SalesTaxRateProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesTaxRateCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.StateProvince object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.StateProvince instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.StateProvince Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StateProvince entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CountryRegionCodeSource
			if (CanDeepSave(entity, "CountryRegion|CountryRegionCodeSource", deepSaveType, innerList) 
				&& entity.CountryRegionCodeSource != null)
			{
				DataRepository.CountryRegionProvider.Save(transactionManager, entity.CountryRegionCodeSource);
				entity.CountryRegionCode = entity.CountryRegionCodeSource.CountryRegionCode;
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
	
			#region List<Address>
				if (CanDeepSave(entity.AddressCollection, "List<Address>|AddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Address child in entity.AddressCollection)
					{
						if(child.StateProvinceIdSource != null)
						{
							child.StateProvinceId = child.StateProvinceIdSource.StateProvinceId;
						}
						else
						{
							child.StateProvinceId = entity.StateProvinceId;
						}

					}

					if (entity.AddressCollection.Count > 0 || entity.AddressCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AddressProvider.Save(transactionManager, entity.AddressCollection);
						
						deepHandles.Add("AddressCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Address >) DataRepository.AddressProvider.DeepSave,
							new object[] { transactionManager, entity.AddressCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesTaxRate>
				if (CanDeepSave(entity.SalesTaxRateCollection, "List<SalesTaxRate>|SalesTaxRateCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesTaxRate child in entity.SalesTaxRateCollection)
					{
						if(child.StateProvinceIdSource != null)
						{
							child.StateProvinceId = child.StateProvinceIdSource.StateProvinceId;
						}
						else
						{
							child.StateProvinceId = entity.StateProvinceId;
						}

					}

					if (entity.SalesTaxRateCollection.Count > 0 || entity.SalesTaxRateCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesTaxRateProvider.Save(transactionManager, entity.SalesTaxRateCollection);
						
						deepHandles.Add("SalesTaxRateCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesTaxRate >) DataRepository.SalesTaxRateProvider.DeepSave,
							new object[] { transactionManager, entity.SalesTaxRateCollection, deepSaveType, childTypes, innerList }
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
	
	#region StateProvinceChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.StateProvince</c>
	///</summary>
	public enum StateProvinceChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CountryRegion</c> at CountryRegionCodeSource
		///</summary>
		[ChildEntityType(typeof(CountryRegion))]
		CountryRegion,
			
		///<summary>
		/// Composite Property for <c>SalesTerritory</c> at TerritoryIdSource
		///</summary>
		[ChildEntityType(typeof(SalesTerritory))]
		SalesTerritory,
	
		///<summary>
		/// Collection of <c>StateProvince</c> as OneToMany for AddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<Address>))]
		AddressCollection,

		///<summary>
		/// Collection of <c>StateProvince</c> as OneToMany for SalesTaxRateCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesTaxRate>))]
		SalesTaxRateCollection,
	}
	
	#endregion StateProvinceChildEntityTypes
	
	#region StateProvinceFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;StateProvinceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StateProvince"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateProvinceFilterBuilder : SqlFilterBuilder<StateProvinceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateProvinceFilterBuilder class.
		/// </summary>
		public StateProvinceFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StateProvinceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StateProvinceFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StateProvinceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StateProvinceFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StateProvinceFilterBuilder
	
	#region StateProvinceParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;StateProvinceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StateProvince"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateProvinceParameterBuilder : ParameterizedSqlFilterBuilder<StateProvinceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateProvinceParameterBuilder class.
		/// </summary>
		public StateProvinceParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StateProvinceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StateProvinceParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StateProvinceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StateProvinceParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StateProvinceParameterBuilder
	
	#region StateProvinceSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;StateProvinceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StateProvince"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class StateProvinceSortBuilder : SqlSortBuilder<StateProvinceColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateProvinceSqlSortBuilder class.
		/// </summary>
		public StateProvinceSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion StateProvinceSortBuilder
	
} // end namespace
