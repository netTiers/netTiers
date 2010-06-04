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
	/// This class is the base class for any <see cref="CurrencyRateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CurrencyRateProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.CurrencyRate, Nettiers.AdventureWorks.Entities.CurrencyRateKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CurrencyRateKey key)
		{
			return Delete(transactionManager, key.CurrencyRateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_currencyRateId">Primary key for CurrencyRate records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _currencyRateId)
		{
			return Delete(null, _currencyRateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateId">Primary key for CurrencyRate records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _currencyRateId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_FromCurrencyCode key.
		///		FK_CurrencyRate_Currency_FromCurrencyCode Description: Foreign key constraint referencing Currency.FromCurrencyCode.
		/// </summary>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public TList<CurrencyRate> GetByFromCurrencyCode(System.String _fromCurrencyCode)
		{
			int count = -1;
			return GetByFromCurrencyCode(_fromCurrencyCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_FromCurrencyCode key.
		///		FK_CurrencyRate_Currency_FromCurrencyCode Description: Foreign key constraint referencing Currency.FromCurrencyCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		/// <remarks></remarks>
		public TList<CurrencyRate> GetByFromCurrencyCode(TransactionManager transactionManager, System.String _fromCurrencyCode)
		{
			int count = -1;
			return GetByFromCurrencyCode(transactionManager, _fromCurrencyCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_FromCurrencyCode key.
		///		FK_CurrencyRate_Currency_FromCurrencyCode Description: Foreign key constraint referencing Currency.FromCurrencyCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public TList<CurrencyRate> GetByFromCurrencyCode(TransactionManager transactionManager, System.String _fromCurrencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByFromCurrencyCode(transactionManager, _fromCurrencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_FromCurrencyCode key.
		///		fkCurrencyRateCurrencyFromCurrencyCode Description: Foreign key constraint referencing Currency.FromCurrencyCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public TList<CurrencyRate> GetByFromCurrencyCode(System.String _fromCurrencyCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByFromCurrencyCode(null, _fromCurrencyCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_FromCurrencyCode key.
		///		fkCurrencyRateCurrencyFromCurrencyCode Description: Foreign key constraint referencing Currency.FromCurrencyCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public TList<CurrencyRate> GetByFromCurrencyCode(System.String _fromCurrencyCode, int start, int pageLength,out int count)
		{
			return GetByFromCurrencyCode(null, _fromCurrencyCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_FromCurrencyCode key.
		///		FK_CurrencyRate_Currency_FromCurrencyCode Description: Foreign key constraint referencing Currency.FromCurrencyCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public abstract TList<CurrencyRate> GetByFromCurrencyCode(TransactionManager transactionManager, System.String _fromCurrencyCode, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_ToCurrencyCode key.
		///		FK_CurrencyRate_Currency_ToCurrencyCode Description: Foreign key constraint referencing Currency.ToCurrencyCode.
		/// </summary>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public TList<CurrencyRate> GetByToCurrencyCode(System.String _toCurrencyCode)
		{
			int count = -1;
			return GetByToCurrencyCode(_toCurrencyCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_ToCurrencyCode key.
		///		FK_CurrencyRate_Currency_ToCurrencyCode Description: Foreign key constraint referencing Currency.ToCurrencyCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		/// <remarks></remarks>
		public TList<CurrencyRate> GetByToCurrencyCode(TransactionManager transactionManager, System.String _toCurrencyCode)
		{
			int count = -1;
			return GetByToCurrencyCode(transactionManager, _toCurrencyCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_ToCurrencyCode key.
		///		FK_CurrencyRate_Currency_ToCurrencyCode Description: Foreign key constraint referencing Currency.ToCurrencyCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public TList<CurrencyRate> GetByToCurrencyCode(TransactionManager transactionManager, System.String _toCurrencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByToCurrencyCode(transactionManager, _toCurrencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_ToCurrencyCode key.
		///		fkCurrencyRateCurrencyToCurrencyCode Description: Foreign key constraint referencing Currency.ToCurrencyCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public TList<CurrencyRate> GetByToCurrencyCode(System.String _toCurrencyCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByToCurrencyCode(null, _toCurrencyCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_ToCurrencyCode key.
		///		fkCurrencyRateCurrencyToCurrencyCode Description: Foreign key constraint referencing Currency.ToCurrencyCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public TList<CurrencyRate> GetByToCurrencyCode(System.String _toCurrencyCode, int start, int pageLength,out int count)
		{
			return GetByToCurrencyCode(null, _toCurrencyCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CurrencyRate_Currency_ToCurrencyCode key.
		///		FK_CurrencyRate_Currency_ToCurrencyCode Description: Foreign key constraint referencing Currency.ToCurrencyCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CurrencyRate objects.</returns>
		public abstract TList<CurrencyRate> GetByToCurrencyCode(TransactionManager transactionManager, System.String _toCurrencyCode, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.CurrencyRate Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CurrencyRateKey key, int start, int pageLength)
		{
			return GetByCurrencyRateId(transactionManager, key.CurrencyRateId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode index.
		/// </summary>
		/// <param name="_currencyRateDate">Date and time the exchange rate was obtained.</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(System.DateTime _currencyRateDate, System.String _fromCurrencyCode, System.String _toCurrencyCode)
		{
			int count = -1;
			return GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(null,_currencyRateDate, _fromCurrencyCode, _toCurrencyCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode index.
		/// </summary>
		/// <param name="_currencyRateDate">Date and time the exchange rate was obtained.</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(System.DateTime _currencyRateDate, System.String _fromCurrencyCode, System.String _toCurrencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(null, _currencyRateDate, _fromCurrencyCode, _toCurrencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateDate">Date and time the exchange rate was obtained.</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(TransactionManager transactionManager, System.DateTime _currencyRateDate, System.String _fromCurrencyCode, System.String _toCurrencyCode)
		{
			int count = -1;
			return GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(transactionManager, _currencyRateDate, _fromCurrencyCode, _toCurrencyCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateDate">Date and time the exchange rate was obtained.</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(TransactionManager transactionManager, System.DateTime _currencyRateDate, System.String _fromCurrencyCode, System.String _toCurrencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(transactionManager, _currencyRateDate, _fromCurrencyCode, _toCurrencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode index.
		/// </summary>
		/// <param name="_currencyRateDate">Date and time the exchange rate was obtained.</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(System.DateTime _currencyRateDate, System.String _fromCurrencyCode, System.String _toCurrencyCode, int start, int pageLength, out int count)
		{
			return GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(null, _currencyRateDate, _fromCurrencyCode, _toCurrencyCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateDate">Date and time the exchange rate was obtained.</param>
		/// <param name="_fromCurrencyCode">Exchange rate was converted from this currency code.</param>
		/// <param name="_toCurrencyCode">Exchange rate was converted to this currency code.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(TransactionManager transactionManager, System.DateTime _currencyRateDate, System.String _fromCurrencyCode, System.String _toCurrencyCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CurrencyRate_CurrencyRateID index.
		/// </summary>
		/// <param name="_currencyRateId">Primary key for CurrencyRate records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateId(System.Int32 _currencyRateId)
		{
			int count = -1;
			return GetByCurrencyRateId(null,_currencyRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CurrencyRate_CurrencyRateID index.
		/// </summary>
		/// <param name="_currencyRateId">Primary key for CurrencyRate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateId(System.Int32 _currencyRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyRateId(null, _currencyRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CurrencyRate_CurrencyRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateId">Primary key for CurrencyRate records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateId(TransactionManager transactionManager, System.Int32 _currencyRateId)
		{
			int count = -1;
			return GetByCurrencyRateId(transactionManager, _currencyRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CurrencyRate_CurrencyRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateId">Primary key for CurrencyRate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateId(TransactionManager transactionManager, System.Int32 _currencyRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyRateId(transactionManager, _currencyRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CurrencyRate_CurrencyRateID index.
		/// </summary>
		/// <param name="_currencyRateId">Primary key for CurrencyRate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateId(System.Int32 _currencyRateId, int start, int pageLength, out int count)
		{
			return GetByCurrencyRateId(null, _currencyRateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CurrencyRate_CurrencyRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateId">Primary key for CurrencyRate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CurrencyRate GetByCurrencyRateId(TransactionManager transactionManager, System.Int32 _currencyRateId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CurrencyRate&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CurrencyRate&gt;"/></returns>
		public static TList<CurrencyRate> Fill(IDataReader reader, TList<CurrencyRate> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.CurrencyRate c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CurrencyRate")
					.Append("|").Append((System.Int32)reader[((int)CurrencyRateColumn.CurrencyRateId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CurrencyRate>(
					key.ToString(), // EntityTrackingKey
					"CurrencyRate",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.CurrencyRate();
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
					c.CurrencyRateId = (System.Int32)reader[((int)CurrencyRateColumn.CurrencyRateId - 1)];
					c.CurrencyRateDate = (System.DateTime)reader[((int)CurrencyRateColumn.CurrencyRateDate - 1)];
					c.FromCurrencyCode = (System.String)reader[((int)CurrencyRateColumn.FromCurrencyCode - 1)];
					c.ToCurrencyCode = (System.String)reader[((int)CurrencyRateColumn.ToCurrencyCode - 1)];
					c.AverageRate = (System.Decimal)reader[((int)CurrencyRateColumn.AverageRate - 1)];
					c.EndOfDayRate = (System.Decimal)reader[((int)CurrencyRateColumn.EndOfDayRate - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CurrencyRateColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.CurrencyRate entity)
		{
			if (!reader.Read()) return;
			
			entity.CurrencyRateId = (System.Int32)reader[((int)CurrencyRateColumn.CurrencyRateId - 1)];
			entity.CurrencyRateDate = (System.DateTime)reader[((int)CurrencyRateColumn.CurrencyRateDate - 1)];
			entity.FromCurrencyCode = (System.String)reader[((int)CurrencyRateColumn.FromCurrencyCode - 1)];
			entity.ToCurrencyCode = (System.String)reader[((int)CurrencyRateColumn.ToCurrencyCode - 1)];
			entity.AverageRate = (System.Decimal)reader[((int)CurrencyRateColumn.AverageRate - 1)];
			entity.EndOfDayRate = (System.Decimal)reader[((int)CurrencyRateColumn.EndOfDayRate - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CurrencyRateColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.CurrencyRate entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CurrencyRateId = (System.Int32)dataRow["CurrencyRateID"];
			entity.CurrencyRateDate = (System.DateTime)dataRow["CurrencyRateDate"];
			entity.FromCurrencyCode = (System.String)dataRow["FromCurrencyCode"];
			entity.ToCurrencyCode = (System.String)dataRow["ToCurrencyCode"];
			entity.AverageRate = (System.Decimal)dataRow["AverageRate"];
			entity.EndOfDayRate = (System.Decimal)dataRow["EndOfDayRate"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CurrencyRate"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CurrencyRate Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CurrencyRate entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region FromCurrencyCodeSource	
			if (CanDeepLoad(entity, "Currency|FromCurrencyCodeSource", deepLoadType, innerList) 
				&& entity.FromCurrencyCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FromCurrencyCode;
				Currency tmpEntity = EntityManager.LocateEntity<Currency>(EntityLocator.ConstructKeyFromPkItems(typeof(Currency), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FromCurrencyCodeSource = tmpEntity;
				else
					entity.FromCurrencyCodeSource = DataRepository.CurrencyProvider.GetByCurrencyCode(transactionManager, entity.FromCurrencyCode);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FromCurrencyCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FromCurrencyCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrencyProvider.DeepLoad(transactionManager, entity.FromCurrencyCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FromCurrencyCodeSource

			#region ToCurrencyCodeSource	
			if (CanDeepLoad(entity, "Currency|ToCurrencyCodeSource", deepLoadType, innerList) 
				&& entity.ToCurrencyCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ToCurrencyCode;
				Currency tmpEntity = EntityManager.LocateEntity<Currency>(EntityLocator.ConstructKeyFromPkItems(typeof(Currency), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ToCurrencyCodeSource = tmpEntity;
				else
					entity.ToCurrencyCodeSource = DataRepository.CurrencyProvider.GetByCurrencyCode(transactionManager, entity.ToCurrencyCode);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ToCurrencyCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ToCurrencyCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrencyProvider.DeepLoad(transactionManager, entity.ToCurrencyCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ToCurrencyCodeSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCurrencyRateId methods when available
			
			#region SalesOrderHeaderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderCollection = DataRepository.SalesOrderHeaderProvider.GetByCurrencyRateId(transactionManager, entity.CurrencyRateId);

				if (deep && entity.SalesOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.CurrencyRate object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.CurrencyRate instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CurrencyRate Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CurrencyRate entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FromCurrencyCodeSource
			if (CanDeepSave(entity, "Currency|FromCurrencyCodeSource", deepSaveType, innerList) 
				&& entity.FromCurrencyCodeSource != null)
			{
				DataRepository.CurrencyProvider.Save(transactionManager, entity.FromCurrencyCodeSource);
				entity.FromCurrencyCode = entity.FromCurrencyCodeSource.CurrencyCode;
			}
			#endregion 
			
			#region ToCurrencyCodeSource
			if (CanDeepSave(entity, "Currency|ToCurrencyCodeSource", deepSaveType, innerList) 
				&& entity.ToCurrencyCodeSource != null)
			{
				DataRepository.CurrencyProvider.Save(transactionManager, entity.ToCurrencyCodeSource);
				entity.ToCurrencyCode = entity.ToCurrencyCodeSource.CurrencyCode;
			}
			#endregion 
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
						if(child.CurrencyRateIdSource != null)
						{
							child.CurrencyRateId = child.CurrencyRateIdSource.CurrencyRateId;
						}
						else
						{
							child.CurrencyRateId = entity.CurrencyRateId;
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
	
	#region CurrencyRateChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.CurrencyRate</c>
	///</summary>
	public enum CurrencyRateChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Currency</c> at FromCurrencyCodeSource
		///</summary>
		[ChildEntityType(typeof(Currency))]
		Currency,
	
		///<summary>
		/// Collection of <c>CurrencyRate</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollection,
	}
	
	#endregion CurrencyRateChildEntityTypes
	
	#region CurrencyRateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CurrencyRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrencyRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyRateFilterBuilder : SqlFilterBuilder<CurrencyRateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyRateFilterBuilder class.
		/// </summary>
		public CurrencyRateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyRateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyRateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyRateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyRateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyRateFilterBuilder
	
	#region CurrencyRateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CurrencyRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrencyRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyRateParameterBuilder : ParameterizedSqlFilterBuilder<CurrencyRateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyRateParameterBuilder class.
		/// </summary>
		public CurrencyRateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyRateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyRateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyRateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyRateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyRateParameterBuilder
	
	#region CurrencyRateSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CurrencyRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrencyRate"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CurrencyRateSortBuilder : SqlSortBuilder<CurrencyRateColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyRateSqlSortBuilder class.
		/// </summary>
		public CurrencyRateSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CurrencyRateSortBuilder
	
} // end namespace
