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
	/// This class is the base class for any <see cref="SalesTaxRateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesTaxRateProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesTaxRate, Nettiers.AdventureWorks.Entities.SalesTaxRateKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTaxRateKey key)
		{
			return Delete(transactionManager, key.SalesTaxRateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salesTaxRateId">Primary key for SalesTaxRate records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salesTaxRateId)
		{
			return Delete(null, _salesTaxRateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesTaxRateId">Primary key for SalesTaxRate records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salesTaxRateId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTaxRate_StateProvince_StateProvinceID key.
		///		FK_SalesTaxRate_StateProvince_StateProvinceID Description: Foreign key constraint referencing StateProvince.StateProvinceID.
		/// </summary>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTaxRate objects.</returns>
		public TList<SalesTaxRate> GetByStateProvinceId(System.Int32 _stateProvinceId)
		{
			int count = -1;
			return GetByStateProvinceId(_stateProvinceId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTaxRate_StateProvince_StateProvinceID key.
		///		FK_SalesTaxRate_StateProvince_StateProvinceID Description: Foreign key constraint referencing StateProvince.StateProvinceID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTaxRate objects.</returns>
		/// <remarks></remarks>
		public TList<SalesTaxRate> GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId)
		{
			int count = -1;
			return GetByStateProvinceId(transactionManager, _stateProvinceId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTaxRate_StateProvince_StateProvinceID key.
		///		FK_SalesTaxRate_StateProvince_StateProvinceID Description: Foreign key constraint referencing StateProvince.StateProvinceID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTaxRate objects.</returns>
		public TList<SalesTaxRate> GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceId(transactionManager, _stateProvinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTaxRate_StateProvince_StateProvinceID key.
		///		fkSalesTaxRateStateProvinceStateProvinceId Description: Foreign key constraint referencing StateProvince.StateProvinceID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTaxRate objects.</returns>
		public TList<SalesTaxRate> GetByStateProvinceId(System.Int32 _stateProvinceId, int start, int pageLength)
		{
			int count =  -1;
			return GetByStateProvinceId(null, _stateProvinceId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTaxRate_StateProvince_StateProvinceID key.
		///		fkSalesTaxRateStateProvinceStateProvinceId Description: Foreign key constraint referencing StateProvince.StateProvinceID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTaxRate objects.</returns>
		public TList<SalesTaxRate> GetByStateProvinceId(System.Int32 _stateProvinceId, int start, int pageLength,out int count)
		{
			return GetByStateProvinceId(null, _stateProvinceId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesTaxRate_StateProvince_StateProvinceID key.
		///		FK_SalesTaxRate_StateProvince_StateProvinceID Description: Foreign key constraint referencing StateProvince.StateProvinceID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesTaxRate objects.</returns>
		public abstract TList<SalesTaxRate> GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.SalesTaxRate Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTaxRateKey key, int start, int pageLength)
		{
			return GetBySalesTaxRateId(transactionManager, key.SalesTaxRateId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesTaxRate_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesTaxRate GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesTaxRate_StateProvinceID_TaxType index.
		/// </summary>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="_taxType">1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByStateProvinceIdTaxType(System.Int32 _stateProvinceId, System.Byte _taxType)
		{
			int count = -1;
			return GetByStateProvinceIdTaxType(null,_stateProvinceId, _taxType, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_StateProvinceID_TaxType index.
		/// </summary>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="_taxType">1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByStateProvinceIdTaxType(System.Int32 _stateProvinceId, System.Byte _taxType, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceIdTaxType(null, _stateProvinceId, _taxType, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_StateProvinceID_TaxType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="_taxType">1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByStateProvinceIdTaxType(TransactionManager transactionManager, System.Int32 _stateProvinceId, System.Byte _taxType)
		{
			int count = -1;
			return GetByStateProvinceIdTaxType(transactionManager, _stateProvinceId, _taxType, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_StateProvinceID_TaxType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="_taxType">1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByStateProvinceIdTaxType(TransactionManager transactionManager, System.Int32 _stateProvinceId, System.Byte _taxType, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceIdTaxType(transactionManager, _stateProvinceId, _taxType, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_StateProvinceID_TaxType index.
		/// </summary>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="_taxType">1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetByStateProvinceIdTaxType(System.Int32 _stateProvinceId, System.Byte _taxType, int start, int pageLength, out int count)
		{
			return GetByStateProvinceIdTaxType(null, _stateProvinceId, _taxType, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesTaxRate_StateProvinceID_TaxType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">State, province, or country/region the sales tax applies to.</param>
		/// <param name="_taxType">1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesTaxRate GetByStateProvinceIdTaxType(TransactionManager transactionManager, System.Int32 _stateProvinceId, System.Byte _taxType, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesTaxRate_SalesTaxRateID index.
		/// </summary>
		/// <param name="_salesTaxRateId">Primary key for SalesTaxRate records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetBySalesTaxRateId(System.Int32 _salesTaxRateId)
		{
			int count = -1;
			return GetBySalesTaxRateId(null,_salesTaxRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTaxRate_SalesTaxRateID index.
		/// </summary>
		/// <param name="_salesTaxRateId">Primary key for SalesTaxRate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetBySalesTaxRateId(System.Int32 _salesTaxRateId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesTaxRateId(null, _salesTaxRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTaxRate_SalesTaxRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesTaxRateId">Primary key for SalesTaxRate records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetBySalesTaxRateId(TransactionManager transactionManager, System.Int32 _salesTaxRateId)
		{
			int count = -1;
			return GetBySalesTaxRateId(transactionManager, _salesTaxRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTaxRate_SalesTaxRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesTaxRateId">Primary key for SalesTaxRate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetBySalesTaxRateId(TransactionManager transactionManager, System.Int32 _salesTaxRateId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesTaxRateId(transactionManager, _salesTaxRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTaxRate_SalesTaxRateID index.
		/// </summary>
		/// <param name="_salesTaxRateId">Primary key for SalesTaxRate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesTaxRate GetBySalesTaxRateId(System.Int32 _salesTaxRateId, int start, int pageLength, out int count)
		{
			return GetBySalesTaxRateId(null, _salesTaxRateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesTaxRate_SalesTaxRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesTaxRateId">Primary key for SalesTaxRate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesTaxRate GetBySalesTaxRateId(TransactionManager transactionManager, System.Int32 _salesTaxRateId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesTaxRate&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesTaxRate&gt;"/></returns>
		public static TList<SalesTaxRate> Fill(IDataReader reader, TList<SalesTaxRate> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SalesTaxRate c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesTaxRate")
					.Append("|").Append((System.Int32)reader[((int)SalesTaxRateColumn.SalesTaxRateId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesTaxRate>(
					key.ToString(), // EntityTrackingKey
					"SalesTaxRate",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesTaxRate();
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
					c.SalesTaxRateId = (System.Int32)reader[((int)SalesTaxRateColumn.SalesTaxRateId - 1)];
					c.StateProvinceId = (System.Int32)reader[((int)SalesTaxRateColumn.StateProvinceId - 1)];
					c.TaxType = (System.Byte)reader[((int)SalesTaxRateColumn.TaxType - 1)];
					c.TaxRate = (System.Decimal)reader[((int)SalesTaxRateColumn.TaxRate - 1)];
					c.Name = (System.String)reader[((int)SalesTaxRateColumn.Name - 1)];
					c.Rowguid = (System.Guid)reader[((int)SalesTaxRateColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SalesTaxRateColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesTaxRate entity)
		{
			if (!reader.Read()) return;
			
			entity.SalesTaxRateId = (System.Int32)reader[((int)SalesTaxRateColumn.SalesTaxRateId - 1)];
			entity.StateProvinceId = (System.Int32)reader[((int)SalesTaxRateColumn.StateProvinceId - 1)];
			entity.TaxType = (System.Byte)reader[((int)SalesTaxRateColumn.TaxType - 1)];
			entity.TaxRate = (System.Decimal)reader[((int)SalesTaxRateColumn.TaxRate - 1)];
			entity.Name = (System.String)reader[((int)SalesTaxRateColumn.Name - 1)];
			entity.Rowguid = (System.Guid)reader[((int)SalesTaxRateColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesTaxRateColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesTaxRate entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesTaxRateId = (System.Int32)dataRow["SalesTaxRateID"];
			entity.StateProvinceId = (System.Int32)dataRow["StateProvinceID"];
			entity.TaxType = (System.Byte)dataRow["TaxType"];
			entity.TaxRate = (System.Decimal)dataRow["TaxRate"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesTaxRate"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesTaxRate Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTaxRate entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region StateProvinceIdSource	
			if (CanDeepLoad(entity, "StateProvince|StateProvinceIdSource", deepLoadType, innerList) 
				&& entity.StateProvinceIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.StateProvinceId;
				StateProvince tmpEntity = EntityManager.LocateEntity<StateProvince>(EntityLocator.ConstructKeyFromPkItems(typeof(StateProvince), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.StateProvinceIdSource = tmpEntity;
				else
					entity.StateProvinceIdSource = DataRepository.StateProvinceProvider.GetByStateProvinceId(transactionManager, entity.StateProvinceId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StateProvinceIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.StateProvinceIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.StateProvinceProvider.DeepLoad(transactionManager, entity.StateProvinceIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion StateProvinceIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesTaxRate object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesTaxRate instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesTaxRate Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesTaxRate entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region StateProvinceIdSource
			if (CanDeepSave(entity, "StateProvince|StateProvinceIdSource", deepSaveType, innerList) 
				&& entity.StateProvinceIdSource != null)
			{
				DataRepository.StateProvinceProvider.Save(transactionManager, entity.StateProvinceIdSource);
				entity.StateProvinceId = entity.StateProvinceIdSource.StateProvinceId;
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
	
	#region SalesTaxRateChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesTaxRate</c>
	///</summary>
	public enum SalesTaxRateChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>StateProvince</c> at StateProvinceIdSource
		///</summary>
		[ChildEntityType(typeof(StateProvince))]
		StateProvince,
		}
	
	#endregion SalesTaxRateChildEntityTypes
	
	#region SalesTaxRateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesTaxRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTaxRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTaxRateFilterBuilder : SqlFilterBuilder<SalesTaxRateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateFilterBuilder class.
		/// </summary>
		public SalesTaxRateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTaxRateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTaxRateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTaxRateFilterBuilder
	
	#region SalesTaxRateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesTaxRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTaxRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTaxRateParameterBuilder : ParameterizedSqlFilterBuilder<SalesTaxRateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateParameterBuilder class.
		/// </summary>
		public SalesTaxRateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTaxRateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTaxRateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTaxRateParameterBuilder
	
	#region SalesTaxRateSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesTaxRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTaxRate"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesTaxRateSortBuilder : SqlSortBuilder<SalesTaxRateColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateSqlSortBuilder class.
		/// </summary>
		public SalesTaxRateSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesTaxRateSortBuilder
	
} // end namespace
