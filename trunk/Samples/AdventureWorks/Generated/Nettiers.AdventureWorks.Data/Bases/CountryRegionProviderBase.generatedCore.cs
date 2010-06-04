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
	/// This class is the base class for any <see cref="CountryRegionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CountryRegionProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.CountryRegion, Nettiers.AdventureWorks.Entities.CountryRegionKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByCurrencyCodeFromCountryRegionCurrency
		
		/// <summary>
		///		Gets CountryRegion objects from the datasource by CurrencyCode in the
		///		CountryRegionCurrency table. Table CountryRegion is related to table Currency
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <returns>Returns a typed collection of CountryRegion objects.</returns>
		public TList<CountryRegion> GetByCurrencyCodeFromCountryRegionCurrency(System.String _currencyCode)
		{
			int count = -1;
			return GetByCurrencyCodeFromCountryRegionCurrency(null,_currencyCode, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.CountryRegion objects from the datasource by CurrencyCode in the
		///		CountryRegionCurrency table. Table CountryRegion is related to table Currency
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of CountryRegion objects.</returns>
		public TList<CountryRegion> GetByCurrencyCodeFromCountryRegionCurrency(System.String _currencyCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyCodeFromCountryRegionCurrency(null, _currencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets CountryRegion objects from the datasource by CurrencyCode in the
		///		CountryRegionCurrency table. Table CountryRegion is related to table Currency
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CountryRegion objects.</returns>
		public TList<CountryRegion> GetByCurrencyCodeFromCountryRegionCurrency(TransactionManager transactionManager, System.String _currencyCode)
		{
			int count = -1;
			return GetByCurrencyCodeFromCountryRegionCurrency(transactionManager, _currencyCode, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets CountryRegion objects from the datasource by CurrencyCode in the
		///		CountryRegionCurrency table. Table CountryRegion is related to table Currency
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CountryRegion objects.</returns>
		public TList<CountryRegion> GetByCurrencyCodeFromCountryRegionCurrency(TransactionManager transactionManager, System.String _currencyCode,int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyCodeFromCountryRegionCurrency(transactionManager, _currencyCode, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets CountryRegion objects from the datasource by CurrencyCode in the
		///		CountryRegionCurrency table. Table CountryRegion is related to table Currency
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CountryRegion objects.</returns>
		public TList<CountryRegion> GetByCurrencyCodeFromCountryRegionCurrency(System.String _currencyCode,int start, int pageLength, out int count)
		{
			
			return GetByCurrencyCodeFromCountryRegionCurrency(null, _currencyCode, start, pageLength, out count);
		}


		/// <summary>
		///		Gets CountryRegion objects from the datasource by CurrencyCode in the
		///		CountryRegionCurrency table. Table CountryRegion is related to table Currency
		///		through the (M:N) relationship defined in the CountryRegionCurrency table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_currencyCode">ISO standard currency code. Foreign key to Currency.CurrencyCode.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of CountryRegion objects.</returns>
		public abstract TList<CountryRegion> GetByCurrencyCodeFromCountryRegionCurrency(TransactionManager transactionManager,System.String _currencyCode, int start, int pageLength, out int count);
		
		#endregion GetByCurrencyCodeFromCountryRegionCurrency
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CountryRegionKey key)
		{
			return Delete(transactionManager, key.CountryRegionCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_countryRegionCode">ISO standard code for countries and regions.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _countryRegionCode)
		{
			return Delete(null, _countryRegionCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO standard code for countries and regions.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _countryRegionCode);		
		
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
		public override Nettiers.AdventureWorks.Entities.CountryRegion Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CountryRegionKey key, int start, int pageLength)
		{
			return GetByCountryRegionCode(transactionManager, key.CountryRegionCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_CountryRegion_Name index.
		/// </summary>
		/// <param name="_name">Country or region name.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CountryRegion_Name index.
		/// </summary>
		/// <param name="_name">Country or region name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CountryRegion_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Country or region name.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CountryRegion_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Country or region name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CountryRegion_Name index.
		/// </summary>
		/// <param name="_name">Country or region name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CountryRegion_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Country or region name.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CountryRegion GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CountryRegion_CountryRegionCode index.
		/// </summary>
		/// <param name="_countryRegionCode">ISO standard code for countries and regions.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByCountryRegionCode(System.String _countryRegionCode)
		{
			int count = -1;
			return GetByCountryRegionCode(null,_countryRegionCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegion_CountryRegionCode index.
		/// </summary>
		/// <param name="_countryRegionCode">ISO standard code for countries and regions.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByCountryRegionCode(System.String _countryRegionCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryRegionCode(null, _countryRegionCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegion_CountryRegionCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO standard code for countries and regions.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode)
		{
			int count = -1;
			return GetByCountryRegionCode(transactionManager, _countryRegionCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegion_CountryRegionCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO standard code for countries and regions.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryRegionCode(transactionManager, _countryRegionCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegion_CountryRegionCode index.
		/// </summary>
		/// <param name="_countryRegionCode">ISO standard code for countries and regions.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CountryRegion GetByCountryRegionCode(System.String _countryRegionCode, int start, int pageLength, out int count)
		{
			return GetByCountryRegionCode(null, _countryRegionCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CountryRegion_CountryRegionCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryRegionCode">ISO standard code for countries and regions.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CountryRegion GetByCountryRegionCode(TransactionManager transactionManager, System.String _countryRegionCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CountryRegion&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CountryRegion&gt;"/></returns>
		public static TList<CountryRegion> Fill(IDataReader reader, TList<CountryRegion> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.CountryRegion c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CountryRegion")
					.Append("|").Append((System.String)reader[((int)CountryRegionColumn.CountryRegionCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CountryRegion>(
					key.ToString(), // EntityTrackingKey
					"CountryRegion",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.CountryRegion();
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
					c.CountryRegionCode = (System.String)reader[((int)CountryRegionColumn.CountryRegionCode - 1)];
					c.OriginalCountryRegionCode = c.CountryRegionCode;
					c.Name = (System.String)reader[((int)CountryRegionColumn.Name - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CountryRegionColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.CountryRegion entity)
		{
			if (!reader.Read()) return;
			
			entity.CountryRegionCode = (System.String)reader[((int)CountryRegionColumn.CountryRegionCode - 1)];
			entity.OriginalCountryRegionCode = (System.String)reader["CountryRegionCode"];
			entity.Name = (System.String)reader[((int)CountryRegionColumn.Name - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CountryRegionColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.CountryRegion entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CountryRegionCode = (System.String)dataRow["CountryRegionCode"];
			entity.OriginalCountryRegionCode = (System.String)dataRow["CountryRegionCode"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CountryRegion"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CountryRegion Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CountryRegion entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCountryRegionCode methods when available
			
			#region StateProvinceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<StateProvince>|StateProvinceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StateProvinceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.StateProvinceCollection = DataRepository.StateProvinceProvider.GetByCountryRegionCode(transactionManager, entity.CountryRegionCode);

				if (deep && entity.StateProvinceCollection.Count > 0)
				{
					deepHandles.Add("StateProvinceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<StateProvince>) DataRepository.StateProvinceProvider.DeepLoad,
						new object[] { transactionManager, entity.StateProvinceCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.CountryRegionCurrencyCollection = DataRepository.CountryRegionCurrencyProvider.GetByCountryRegionCode(transactionManager, entity.CountryRegionCode);

				if (deep && entity.CountryRegionCurrencyCollection.Count > 0)
				{
					deepHandles.Add("CountryRegionCurrencyCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CountryRegionCurrency>) DataRepository.CountryRegionCurrencyProvider.DeepLoad,
						new object[] { transactionManager, entity.CountryRegionCurrencyCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CurrencyCodeCurrencyCollection_From_CountryRegionCurrency
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Currency>|CurrencyCodeCurrencyCollection_From_CountryRegionCurrency", deepLoadType, innerList))
			{
				entity.CurrencyCodeCurrencyCollection_From_CountryRegionCurrency = DataRepository.CurrencyProvider.GetByCountryRegionCodeFromCountryRegionCurrency(transactionManager, entity.CountryRegionCode);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurrencyCodeCurrencyCollection_From_CountryRegionCurrency' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CurrencyCodeCurrencyCollection_From_CountryRegionCurrency != null)
				{
					deepHandles.Add("CurrencyCodeCurrencyCollection_From_CountryRegionCurrency",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Currency >) DataRepository.CurrencyProvider.DeepLoad,
						new object[] { transactionManager, entity.CurrencyCodeCurrencyCollection_From_CountryRegionCurrency, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.CountryRegion object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.CountryRegion instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CountryRegion Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CountryRegion entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region CurrencyCodeCurrencyCollection_From_CountryRegionCurrency>
			if (CanDeepSave(entity.CurrencyCodeCurrencyCollection_From_CountryRegionCurrency, "List<Currency>|CurrencyCodeCurrencyCollection_From_CountryRegionCurrency", deepSaveType, innerList))
			{
				if (entity.CurrencyCodeCurrencyCollection_From_CountryRegionCurrency.Count > 0 || entity.CurrencyCodeCurrencyCollection_From_CountryRegionCurrency.DeletedItems.Count > 0)
				{
					DataRepository.CurrencyProvider.Save(transactionManager, entity.CurrencyCodeCurrencyCollection_From_CountryRegionCurrency); 
					deepHandles.Add("CurrencyCodeCurrencyCollection_From_CountryRegionCurrency",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Currency>) DataRepository.CurrencyProvider.DeepSave,
						new object[] { transactionManager, entity.CurrencyCodeCurrencyCollection_From_CountryRegionCurrency, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<StateProvince>
				if (CanDeepSave(entity.StateProvinceCollection, "List<StateProvince>|StateProvinceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(StateProvince child in entity.StateProvinceCollection)
					{
						if(child.CountryRegionCodeSource != null)
						{
							child.CountryRegionCode = child.CountryRegionCodeSource.CountryRegionCode;
						}
						else
						{
							child.CountryRegionCode = entity.CountryRegionCode;
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
				
	
			#region List<CountryRegionCurrency>
				if (CanDeepSave(entity.CountryRegionCurrencyCollection, "List<CountryRegionCurrency>|CountryRegionCurrencyCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CountryRegionCurrency child in entity.CountryRegionCurrencyCollection)
					{
						if(child.CountryRegionCodeSource != null)
						{
								child.CountryRegionCode = child.CountryRegionCodeSource.CountryRegionCode;
						}

						if(child.CurrencyCodeSource != null)
						{
								child.CurrencyCode = child.CurrencyCodeSource.CurrencyCode;
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
	
	#region CountryRegionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.CountryRegion</c>
	///</summary>
	public enum CountryRegionChildEntityTypes
	{

		///<summary>
		/// Collection of <c>CountryRegion</c> as OneToMany for StateProvinceCollection
		///</summary>
		[ChildEntityType(typeof(TList<StateProvince>))]
		StateProvinceCollection,

		///<summary>
		/// Collection of <c>CountryRegion</c> as OneToMany for CountryRegionCurrencyCollection
		///</summary>
		[ChildEntityType(typeof(TList<CountryRegionCurrency>))]
		CountryRegionCurrencyCollection,

		///<summary>
		/// Collection of <c>CountryRegion</c> as ManyToMany for CurrencyCollection_From_CountryRegionCurrency
		///</summary>
		[ChildEntityType(typeof(TList<Currency>))]
		CurrencyCodeCurrencyCollection_From_CountryRegionCurrency,
	}
	
	#endregion CountryRegionChildEntityTypes
	
	#region CountryRegionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CountryRegionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionFilterBuilder : SqlFilterBuilder<CountryRegionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionFilterBuilder class.
		/// </summary>
		public CountryRegionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryRegionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryRegionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryRegionFilterBuilder
	
	#region CountryRegionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CountryRegionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionParameterBuilder : ParameterizedSqlFilterBuilder<CountryRegionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionParameterBuilder class.
		/// </summary>
		public CountryRegionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryRegionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryRegionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryRegionParameterBuilder
	
	#region CountryRegionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CountryRegionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegion"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CountryRegionSortBuilder : SqlSortBuilder<CountryRegionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionSqlSortBuilder class.
		/// </summary>
		public CountryRegionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CountryRegionSortBuilder
	
} // end namespace
