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
	/// This class is the base class for any <see cref="CurrencyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CurrencyProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Currency, Nettiers.AdventureWorks.Entities.CurrencyKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByCountryRegionCodeFromCountryRegionCurrency
		
		/// <summary>
		///		Gets Currency objects from the datasource by CountryRegionCode in the
		///		CountryRegionCurrency table. Table Currency is related to table CountryRegion
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <returns>Returns a typed collection of Currency objects.</returns>
		public TList<Currency> GetByCountryRegionCodeFromCountryRegionCurrency(System.String _countryRegionCode)
		{
			int count = -1;
			return GetByCountryRegionCodeFromCountryRegionCurrency(null,_countryRegionCode, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Currency objects from the datasource by CountryRegionCode in the
		///		CountryRegionCurrency table. Table Currency is related to table CountryRegion
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Currency objects.</returns>
		public TList<Currency> GetByCountryRegionCodeFromCountryRegionCurrency(System.String _countryRegionCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryRegionCodeFromCountryRegionCurrency(null, _countryRegionCode, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Currency objects from the datasource by CountryRegionCode in the
		///		CountryRegionCurrency table. Table Currency is related to table CountryRegion
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Currency objects.</returns>
		public TList<Currency> GetByCountryRegionCodeFromCountryRegionCurrency(TransactionManager transactionManager, System.String _countryRegionCode)
		{
			int count = -1;
			return GetByCountryRegionCodeFromCountryRegionCurrency(transactionManager, _countryRegionCode, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Currency objects from the datasource by CountryRegionCode in the
		///		CountryRegionCurrency table. Table Currency is related to table CountryRegion
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Currency objects.</returns>
		public TList<Currency> GetByCountryRegionCodeFromCountryRegionCurrency(TransactionManager transactionManager, System.String _countryRegionCode,int start, int pageLength)
		{
			int count = -1;
			return GetByCountryRegionCodeFromCountryRegionCurrency(transactionManager, _countryRegionCode, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Currency objects from the datasource by CountryRegionCode in the
		///		CountryRegionCurrency table. Table Currency is related to table CountryRegion
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Currency objects.</returns>
		public TList<Currency> GetByCountryRegionCodeFromCountryRegionCurrency(System.String _countryRegionCode,int start, int pageLength, out int count)
		{
			
			return GetByCountryRegionCodeFromCountryRegionCurrency(null, _countryRegionCode, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Currency objects from the datasource by CountryRegionCode in the
		///		CountryRegionCurrency table. Table Currency is related to table CountryRegion
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_countryRegionCode">ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Currency objects.</returns>
		public abstract TList<Currency> GetByCountryRegionCodeFromCountryRegionCurrency(TransactionManager transactionManager,System.String _countryRegionCode, int start, int pageLength, out int count);
		
		#endregion GetByCountryRegionCodeFromCountryRegionCurrency
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CurrencyKey key)
		{
			return Delete(transactionManager, key.CurrencyCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_currencyCode">The ISO code for the Currency.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _currencyCode)
		{
			return Delete(null, _currencyCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">The ISO code for the Currency.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _currencyCode);		
		
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
		public override Nettiers.AdventureWorks.Entities.Currency Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CurrencyKey key, int start, int pageLength)
		{
			return GetByCurrencyCode(transactionManager, key.CurrencyCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Currency_Name index.
		/// </summary>
		/// <param name="_name">Currency name.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Currency_Name index.
		/// </summary>
		/// <param name="_name">Currency name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Currency_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Currency name.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Currency_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Currency name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Currency_Name index.
		/// </summary>
		/// <param name="_name">Currency name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Currency_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Currency name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Currency GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Currency_CurrencyCode index.
		/// </summary>
		/// <param name="_currencyCode">The ISO code for the Currency.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByCurrencyCode(System.String _currencyCode)
		{
			int count = -1;
			return GetByCurrencyCode(null,_currencyCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Currency_CurrencyCode index.
		/// </summary>
		/// <param name="_currencyCode">The ISO code for the Currency.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByCurrencyCode(System.String _currencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyCode(null, _currencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Currency_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">The ISO code for the Currency.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByCurrencyCode(TransactionManager transactionManager, System.String _currencyCode)
		{
			int count = -1;
			return GetByCurrencyCode(transactionManager, _currencyCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Currency_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">The ISO code for the Currency.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByCurrencyCode(TransactionManager transactionManager, System.String _currencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyCode(transactionManager, _currencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Currency_CurrencyCode index.
		/// </summary>
		/// <param name="_currencyCode">The ISO code for the Currency.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Currency GetByCurrencyCode(System.String _currencyCode, int start, int pageLength, out int count)
		{
			return GetByCurrencyCode(null, _currencyCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Currency_CurrencyCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">The ISO code for the Currency.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Currency GetByCurrencyCode(TransactionManager transactionManager, System.String _currencyCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Currency&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Currency&gt;"/></returns>
		public static TList<Currency> Fill(IDataReader reader, TList<Currency> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Currency c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Currency")
					.Append("|").Append((System.String)reader[((int)CurrencyColumn.CurrencyCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Currency>(
					key.ToString(), // EntityTrackingKey
					"Currency",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Currency();
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
					c.CurrencyCode = (System.String)reader[((int)CurrencyColumn.CurrencyCode - 1)];
					c.OriginalCurrencyCode = c.CurrencyCode;
					c.Name = (System.String)reader[((int)CurrencyColumn.Name - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CurrencyColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Currency"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Currency entity)
		{
			if (!reader.Read()) return;
			
			entity.CurrencyCode = (System.String)reader[((int)CurrencyColumn.CurrencyCode - 1)];
			entity.OriginalCurrencyCode = (System.String)reader["CurrencyCode"];
			entity.Name = (System.String)reader[((int)CurrencyColumn.Name - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CurrencyColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Currency"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Currency"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Currency entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CurrencyCode = (System.String)dataRow["CurrencyCode"];
			entity.OriginalCurrencyCode = (System.String)dataRow["CurrencyCode"];
			entity.Name = (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Currency"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Currency Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Currency entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCurrencyCode methods when available
			
			#region CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<CountryRegion>|CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency", deepLoadType, innerList))
			{
				entity.CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency = DataRepository.CountryRegionProvider.GetByCurrencyCodeFromCountryRegionCurrency(transactionManager, entity.CurrencyCode);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency != null)
				{
					deepHandles.Add("CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< CountryRegion >) DataRepository.CountryRegionProvider.DeepLoad,
						new object[] { transactionManager, entity.CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region CountryRegionCurrencyCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CountryRegionCurrency>|CountryRegionCurrencyCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryRegionCurrencyCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CountryRegionCurrencyCollection = DataRepository.CountryRegionCurrencyProvider.GetByCurrencyCode(transactionManager, entity.CurrencyCode);

				if (deep && entity.CountryRegionCurrencyCollection.Count > 0)
				{
					deepHandles.Add("CountryRegionCurrencyCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CountryRegionCurrency>) DataRepository.CountryRegionCurrencyProvider.DeepLoad,
						new object[] { transactionManager, entity.CountryRegionCurrencyCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CurrencyRateCollectionGetByFromCurrencyCode
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CurrencyRate>|CurrencyRateCollectionGetByFromCurrencyCode", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurrencyRateCollectionGetByFromCurrencyCode' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CurrencyRateCollectionGetByFromCurrencyCode = DataRepository.CurrencyRateProvider.GetByFromCurrencyCode(transactionManager, entity.CurrencyCode);

				if (deep && entity.CurrencyRateCollectionGetByFromCurrencyCode.Count > 0)
				{
					deepHandles.Add("CurrencyRateCollectionGetByFromCurrencyCode",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CurrencyRate>) DataRepository.CurrencyRateProvider.DeepLoad,
						new object[] { transactionManager, entity.CurrencyRateCollectionGetByFromCurrencyCode, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CurrencyRateCollectionGetByToCurrencyCode
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CurrencyRate>|CurrencyRateCollectionGetByToCurrencyCode", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurrencyRateCollectionGetByToCurrencyCode' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CurrencyRateCollectionGetByToCurrencyCode = DataRepository.CurrencyRateProvider.GetByToCurrencyCode(transactionManager, entity.CurrencyCode);

				if (deep && entity.CurrencyRateCollectionGetByToCurrencyCode.Count > 0)
				{
					deepHandles.Add("CurrencyRateCollectionGetByToCurrencyCode",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CurrencyRate>) DataRepository.CurrencyRateProvider.DeepLoad,
						new object[] { transactionManager, entity.CurrencyRateCollectionGetByToCurrencyCode, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Currency object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Currency instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Currency Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Currency entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency>
			if (CanDeepSave(entity.CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency, "List<CountryRegion>|CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency", deepSaveType, innerList))
			{
				if (entity.CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency.Count > 0 || entity.CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency.DeletedItems.Count > 0)
				{
					DataRepository.CountryRegionProvider.Save(transactionManager, entity.CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency); 
					deepHandles.Add("CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<CountryRegion>) DataRepository.CountryRegionProvider.DeepSave,
						new object[] { transactionManager, entity.CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<CountryRegionCurrency>
				if (CanDeepSave(entity.CountryRegionCurrencyCollection, "List<CountryRegionCurrency>|CountryRegionCurrencyCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CountryRegionCurrency child in entity.CountryRegionCurrencyCollection)
					{
						if(child.CurrencyCodeSource != null)
						{
								child.CurrencyCode = child.CurrencyCodeSource.CurrencyCode;
						}

						if(child.CountryRegionCodeSource != null)
						{
								child.CountryRegionCode = child.CountryRegionCodeSource.CountryRegionCode;
						}

					}

					if (entity.CountryRegionCurrencyCollection.Count > 0 || entity.CountryRegionCurrencyCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CountryRegionCurrencyProvider.Save(transactionManager, entity.CountryRegionCurrencyCollection);
						
						deepHandles.Add("CountryRegionCurrencyCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CountryRegionCurrency >) DataRepository.CountryRegionCurrencyProvider.DeepSave,
							new object[] { transactionManager, entity.CountryRegionCurrencyCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CurrencyRate>
				if (CanDeepSave(entity.CurrencyRateCollectionGetByFromCurrencyCode, "List<CurrencyRate>|CurrencyRateCollectionGetByFromCurrencyCode", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CurrencyRate child in entity.CurrencyRateCollectionGetByFromCurrencyCode)
					{
						if(child.FromCurrencyCodeSource != null)
						{
							child.FromCurrencyCode = child.FromCurrencyCodeSource.CurrencyCode;
						}
						else
						{
							child.FromCurrencyCode = entity.CurrencyCode;
						}

					}

					if (entity.CurrencyRateCollectionGetByFromCurrencyCode.Count > 0 || entity.CurrencyRateCollectionGetByFromCurrencyCode.DeletedItems.Count > 0)
					{
						//DataRepository.CurrencyRateProvider.Save(transactionManager, entity.CurrencyRateCollectionGetByFromCurrencyCode);
						
						deepHandles.Add("CurrencyRateCollectionGetByFromCurrencyCode",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CurrencyRate >) DataRepository.CurrencyRateProvider.DeepSave,
							new object[] { transactionManager, entity.CurrencyRateCollectionGetByFromCurrencyCode, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CurrencyRate>
				if (CanDeepSave(entity.CurrencyRateCollectionGetByToCurrencyCode, "List<CurrencyRate>|CurrencyRateCollectionGetByToCurrencyCode", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CurrencyRate child in entity.CurrencyRateCollectionGetByToCurrencyCode)
					{
						if(child.ToCurrencyCodeSource != null)
						{
							child.ToCurrencyCode = child.ToCurrencyCodeSource.CurrencyCode;
						}
						else
						{
							child.ToCurrencyCode = entity.CurrencyCode;
						}

					}

					if (entity.CurrencyRateCollectionGetByToCurrencyCode.Count > 0 || entity.CurrencyRateCollectionGetByToCurrencyCode.DeletedItems.Count > 0)
					{
						//DataRepository.CurrencyRateProvider.Save(transactionManager, entity.CurrencyRateCollectionGetByToCurrencyCode);
						
						deepHandles.Add("CurrencyRateCollectionGetByToCurrencyCode",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CurrencyRate >) DataRepository.CurrencyRateProvider.DeepSave,
							new object[] { transactionManager, entity.CurrencyRateCollectionGetByToCurrencyCode, deepSaveType, childTypes, innerList }
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
	
	#region CurrencyChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Currency</c>
	///</summary>
	public enum CurrencyChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Currency</c> as ManyToMany for CountryRegionCollection_From_CountryRegionCurrency
		///</summary>
		[ChildEntityType(typeof(TList<CountryRegion>))]
		CountryRegionCodeCountryRegionCollection_From_CountryRegionCurrency,

		///<summary>
		/// Collection of <c>Currency</c> as OneToMany for CountryRegionCurrencyCollection
		///</summary>
		[ChildEntityType(typeof(TList<CountryRegionCurrency>))]
		CountryRegionCurrencyCollection,

		///<summary>
		/// Collection of <c>Currency</c> as OneToMany for CurrencyRateCollection
		///</summary>
		[ChildEntityType(typeof(TList<CurrencyRate>))]
		CurrencyRateCollectionGetByFromCurrencyCode,

		///<summary>
		/// Collection of <c>Currency</c> as OneToMany for CurrencyRateCollection
		///</summary>
		[ChildEntityType(typeof(TList<CurrencyRate>))]
		CurrencyRateCollectionGetByToCurrencyCode,
	}
	
	#endregion CurrencyChildEntityTypes
	
	#region CurrencyFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CurrencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyFilterBuilder : SqlFilterBuilder<CurrencyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyFilterBuilder class.
		/// </summary>
		public CurrencyFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyFilterBuilder
	
	#region CurrencyParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CurrencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyParameterBuilder : ParameterizedSqlFilterBuilder<CurrencyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyParameterBuilder class.
		/// </summary>
		public CurrencyParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyParameterBuilder
	
	#region CurrencySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CurrencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CurrencySortBuilder : SqlSortBuilder<CurrencyColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencySqlSortBuilder class.
		/// </summary>
		public CurrencySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CurrencySortBuilder
	
} // end namespace
