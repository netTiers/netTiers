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
	/// This class is the base class for any <see cref="CountryRegionCurrencyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CountryRegionCurrencyProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.CountryRegionCurrency, Nettiers.AdventureWorks.Entities.CountryRegionCurrencyKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CountryRegionCurrencyKey key)
		{
			return Delete(transactionManager, key.CountryRegionCode, key.CurrencyCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.. Primary Key.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _countryRegionCode, System.String _currencyCode)
		{
			return Delete(null, _countryRegionCode, _currencyCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.. Primary Key.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _countryRegionCode, System.String _currencyCode);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CountryRegionCurrency_CountryRegion_CountryRegionCode key.
		///		FK_CountryRegionCurrency_CountryRegion_CountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CountryRegionCurrency objects.</returns>
		public TList<CountryRegionCurrency> GetByCountryRegionCode(System.String _countryRegionCode)
		{
			int count = -1;
			return GetByCountryRegionCode(_countryRegionCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CountryRegionCurrency_CountryRegion_CountryRegionCode key.
		///		FK_CountryRegionCurrency_CountryRegion_CountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CountryRegionCurrency objects.</returns>
		/// <remarks></remarks>
		public TList<CountryRegionCurrency> GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode)
		{
			int count = -1;
			return GetByCountryRegionCode(transactionManager, _countryRegionCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CountryRegionCurrency_CountryRegion_CountryRegionCode key.
		///		FK_CountryRegionCurrency_CountryRegion_CountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CountryRegionCurrency objects.</returns>
		public TList<CountryRegionCurrency> GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryRegionCode(transactionManager, _countryRegionCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CountryRegionCurrency_CountryRegion_CountryRegionCode key.
		///		fkCountryRegionCurrencyCountryRegionCountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CountryRegionCurrency objects.</returns>
		public TList<CountryRegionCurrency> GetByCountryRegionCode(System.String _countryRegionCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryRegionCode(null, _countryRegionCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CountryRegionCurrency_CountryRegion_CountryRegionCode key.
		///		fkCountryRegionCurrencyCountryRegionCountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CountryRegionCurrency objects.</returns>
		public TList<CountryRegionCurrency> GetByCountryRegionCode(System.String _countryRegionCode, int start, int pageLength,out int count)
		{
			return GetByCountryRegionCode(null, _countryRegionCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CountryRegionCurrency_CountryRegion_CountryRegionCode key.
		///		FK_CountryRegionCurrency_CountryRegion_CountryRegionCode Description: Foreign key constraint referencing CountryRegion.CountryRegionCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CountryRegionCurrency objects.</returns>
		public abstract TList<CountryRegionCurrency> GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.CountryRegionCurrency Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CountryRegionCurrencyKey key, int start, int pageLength)
		{
			return GetByCountryRegionCodeCurrencyCode(transactionManager, key.CountryRegionCode, key.CurrencyCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_CountryRegionCurrency_CurrencyCode index.
		/// </summary>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;CountryRegionCurrency&gt;"/> class.</returns>
		public TList<CountryRegionCurrency> GetByCurrencyCode(System.String _currencyCode)
		{
			int count = -1;
			return GetByCurrencyCode(null,_currencyCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CountryRegionCurrency_CurrencyCode index.
		/// </summary>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;CountryRegionCurrency&gt;"/> class.</returns>
		public TList<CountryRegionCurrency> GetByCurrencyCode(System.String _currencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyCode(null, _currencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CountryRegionCurrency_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;CountryRegionCurrency&gt;"/> class.</returns>
		public TList<CountryRegionCurrency> GetByCurrencyCode(TransactionManager transactionManager, System.String _currencyCode)
		{
			int count = -1;
			return GetByCurrencyCode(transactionManager, _currencyCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CountryRegionCurrency_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;CountryRegionCurrency&gt;"/> class.</returns>
		public TList<CountryRegionCurrency> GetByCurrencyCode(TransactionManager transactionManager, System.String _currencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyCode(transactionManager, _currencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CountryRegionCurrency_CurrencyCode index.
		/// </summary>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;CountryRegionCurrency&gt;"/> class.</returns>
		public TList<CountryRegionCurrency> GetByCurrencyCode(System.String _currencyCode, int start, int pageLength, out int count)
		{
			return GetByCurrencyCode(null, _currencyCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CountryRegionCurrency_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;CountryRegionCurrency&gt;"/> class.</returns>
		public abstract TList<CountryRegionCurrency> GetByCurrencyCode(TransactionManager transactionManager, System.String _currencyCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode index.
		/// </summary>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegionCurrency GetByCountryRegionCodeCurrencyCode(System.String _countryRegionCode, System.String _currencyCode)
		{
			int count = -1;
			return GetByCountryRegionCodeCurrencyCode(null,_countryRegionCode, _currencyCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode index.
		/// </summary>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegionCurrency GetByCountryRegionCodeCurrencyCode(System.String _countryRegionCode, System.String _currencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryRegionCodeCurrencyCode(null, _countryRegionCode, _currencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegionCurrency GetByCountryRegionCodeCurrencyCode(TransactionManager transactionManager, System.String _countryRegionCode, System.String _currencyCode)
		{
			int count = -1;
			return GetByCountryRegionCodeCurrencyCode(transactionManager, _countryRegionCode, _currencyCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegionCurrency GetByCountryRegionCodeCurrencyCode(TransactionManager transactionManager, System.String _countryRegionCode, System.String _currencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryRegionCodeCurrencyCode(transactionManager, _countryRegionCode, _currencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode index.
		/// </summary>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegionCurrency GetByCountryRegionCodeCurrencyCode(System.String _countryRegionCode, System.String _currencyCode, int start, int pageLength, out int count)
		{
			return GetByCountryRegionCodeCurrencyCode(null, _countryRegionCode, _currencyCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CountryRegionCurrency GetByCountryRegionCodeCurrencyCode(TransactionManager transactionManager, System.String _countryRegionCode, System.String _currencyCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CountryRegionCurrency&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CountryRegionCurrency&gt;"/></returns>
		public static TList<CountryRegionCurrency> Fill(IDataReader reader, TList<CountryRegionCurrency> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.CountryRegionCurrency c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CountryRegionCurrency")
					.Append("|").Append((System.String)reader[((int)CountryRegionCurrencyColumn.CountryRegionCode - 1)])
					.Append("|").Append((System.String)reader[((int)CountryRegionCurrencyColumn.CurrencyCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CountryRegionCurrency>(
					key.ToString(), // EntityTrackingKey
					"CountryRegionCurrency",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.CountryRegionCurrency();
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
					c.CountryRegionCode = (System.String)reader[((int)CountryRegionCurrencyColumn.CountryRegionCode - 1)];
					c.OriginalCountryRegionCode = c.CountryRegionCode;
					c.CurrencyCode = (System.String)reader[((int)CountryRegionCurrencyColumn.CurrencyCode - 1)];
					c.OriginalCurrencyCode = c.CurrencyCode;
					c.ModifiedDate = (System.DateTime)reader[((int)CountryRegionCurrencyColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.CountryRegionCurrency entity)
		{
			if (!reader.Read()) return;
			
			entity.CountryRegionCode = (System.String)reader[((int)CountryRegionCurrencyColumn.CountryRegionCode - 1)];
			entity.OriginalCountryRegionCode = (System.String)reader["CountryRegionCode"];
			entity.CurrencyCode = (System.String)reader[((int)CountryRegionCurrencyColumn.CurrencyCode - 1)];
			entity.OriginalCurrencyCode = (System.String)reader["CurrencyCode"];
			entity.ModifiedDate = (System.DateTime)reader[((int)CountryRegionCurrencyColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.CountryRegionCurrency entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CountryRegionCode = (System.String)dataRow["CountryRegionCode"];
			entity.OriginalCountryRegionCode = (System.String)dataRow["CountryRegionCode"];
			entity.CurrencyCode = (System.String)dataRow["CurrencyCode"];
			entity.OriginalCurrencyCode = (System.String)dataRow["CurrencyCode"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CountryRegionCurrency"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CountryRegionCurrency Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CountryRegionCurrency entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region CurrencyCodeSource	
			if (CanDeepLoad(entity, "Currency|CurrencyCodeSource", deepLoadType, innerList) 
				&& entity.CurrencyCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CurrencyCode;
				Currency tmpEntity = EntityManager.LocateEntity<Currency>(EntityLocator.ConstructKeyFromPkItems(typeof(Currency), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CurrencyCodeSource = tmpEntity;
				else
					entity.CurrencyCodeSource = DataRepository.CurrencyProvider.GetByCurrencyCode(transactionManager, entity.CurrencyCode);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurrencyCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CurrencyCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrencyProvider.DeepLoad(transactionManager, entity.CurrencyCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CurrencyCodeSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.CountryRegionCurrency object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.CountryRegionCurrency instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CountryRegionCurrency Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CountryRegionCurrency entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region CurrencyCodeSource
			if (CanDeepSave(entity, "Currency|CurrencyCodeSource", deepSaveType, innerList) 
				&& entity.CurrencyCodeSource != null)
			{
				DataRepository.CurrencyProvider.Save(transactionManager, entity.CurrencyCodeSource);
				entity.CurrencyCode = entity.CurrencyCodeSource.CurrencyCode;
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
	
	#region CountryRegionCurrencyChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.CountryRegionCurrency</c>
	///</summary>
	public enum CountryRegionCurrencyChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CountryRegion</c> at CountryRegionCodeSource
		///</summary>
		[ChildEntityType(typeof(CountryRegion))]
		CountryRegion,
			
		///<summary>
		/// Composite Property for <c>Currency</c> at CurrencyCodeSource
		///</summary>
		[ChildEntityType(typeof(Currency))]
		Currency,
		}
	
	#endregion CountryRegionCurrencyChildEntityTypes
	
	#region CountryRegionCurrencyFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CountryRegionCurrencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegionCurrency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionCurrencyFilterBuilder : SqlFilterBuilder<CountryRegionCurrencyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyFilterBuilder class.
		/// </summary>
		public CountryRegionCurrencyFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryRegionCurrencyFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryRegionCurrencyFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryRegionCurrencyFilterBuilder
	
	#region CountryRegionCurrencyParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CountryRegionCurrencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegionCurrency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionCurrencyParameterBuilder : ParameterizedSqlFilterBuilder<CountryRegionCurrencyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyParameterBuilder class.
		/// </summary>
		public CountryRegionCurrencyParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryRegionCurrencyParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryRegionCurrencyParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryRegionCurrencyParameterBuilder
	
	#region CountryRegionCurrencySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CountryRegionCurrencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegionCurrency"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CountryRegionCurrencySortBuilder : SqlSortBuilder<CountryRegionCurrencyColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencySqlSortBuilder class.
		/// </summary>
		public CountryRegionCurrencySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CountryRegionCurrencySortBuilder
	
} // end namespace
