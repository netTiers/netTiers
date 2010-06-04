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
	/// This class is the base class for any <see cref="TestIssue117TablebProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TestIssue117TablebProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.TestIssue117Tableb, Nettiers.AdventureWorks.Entities.TestIssue117TablebKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByTestIssue117TableAidFromTestIssue117Tablec
		
		/// <summary>
		///		Gets TestIssue117TableB objects from the datasource by TestIssue117TableAId in the
		///		TestIssue117TableC table. Table TestIssue117TableB is related to table TestIssue117TableA
		///		through the (M:N) relationship defined in the TestIssue117TableC table.
		/// </summary>
		/// <param name="_testIssue117TableAid"></param>
		/// <returns>Returns a typed collection of TestIssue117Tableb objects.</returns>
		public TList<TestIssue117Tableb> GetByTestIssue117TableAidFromTestIssue117Tablec(System.Int32 _testIssue117TableAid)
		{
			int count = -1;
			return GetByTestIssue117TableAidFromTestIssue117Tablec(null,_testIssue117TableAid, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.TestIssue117Tableb objects from the datasource by TestIssue117TableAId in the
		///		TestIssue117TableC table. Table TestIssue117TableB is related to table TestIssue117TableA
		///		through the (M:N) relationship defined in the TestIssue117TableC table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of TestIssue117Tableb objects.</returns>
		public TList<TestIssue117Tableb> GetByTestIssue117TableAidFromTestIssue117Tablec(System.Int32 _testIssue117TableAid, int start, int pageLength)
		{
			int count = -1;
			return GetByTestIssue117TableAidFromTestIssue117Tablec(null, _testIssue117TableAid, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets TestIssue117Tableb objects from the datasource by TestIssue117TableAId in the
		///		TestIssue117TableC table. Table TestIssue117TableB is related to table TestIssue117TableA
		///		through the (M:N) relationship defined in the TestIssue117TableC table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TestIssue117TableB objects.</returns>
		public TList<TestIssue117Tableb> GetByTestIssue117TableAidFromTestIssue117Tablec(TransactionManager transactionManager, System.Int32 _testIssue117TableAid)
		{
			int count = -1;
			return GetByTestIssue117TableAidFromTestIssue117Tablec(transactionManager, _testIssue117TableAid, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets TestIssue117Tableb objects from the datasource by TestIssue117TableAId in the
		///		TestIssue117TableC table. Table TestIssue117TableB is related to table TestIssue117TableA
		///		through the (M:N) relationship defined in the TestIssue117TableC table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TestIssue117TableB objects.</returns>
		public TList<TestIssue117Tableb> GetByTestIssue117TableAidFromTestIssue117Tablec(TransactionManager transactionManager, System.Int32 _testIssue117TableAid,int start, int pageLength)
		{
			int count = -1;
			return GetByTestIssue117TableAidFromTestIssue117Tablec(transactionManager, _testIssue117TableAid, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets TestIssue117Tableb objects from the datasource by TestIssue117TableAId in the
		///		TestIssue117TableC table. Table TestIssue117TableB is related to table TestIssue117TableA
		///		through the (M:N) relationship defined in the TestIssue117TableC table.
		/// </summary>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TestIssue117TableB objects.</returns>
		public TList<TestIssue117Tableb> GetByTestIssue117TableAidFromTestIssue117Tablec(System.Int32 _testIssue117TableAid,int start, int pageLength, out int count)
		{
			
			return GetByTestIssue117TableAidFromTestIssue117Tablec(null, _testIssue117TableAid, start, pageLength, out count);
		}


		/// <summary>
		///		Gets TestIssue117TableB objects from the datasource by TestIssue117TableAId in the
		///		TestIssue117TableC table. Table TestIssue117TableB is related to table TestIssue117TableA
		///		through the (M:N) relationship defined in the TestIssue117TableC table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of TestIssue117Tableb objects.</returns>
		public abstract TList<TestIssue117Tableb> GetByTestIssue117TableAidFromTestIssue117Tablec(TransactionManager transactionManager,System.Int32 _testIssue117TableAid, int start, int pageLength, out int count);
		
		#endregion GetByTestIssue117TableAidFromTestIssue117Tablec
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestIssue117TablebKey key)
		{
			return Delete(transactionManager, key.TestIssue117TableBid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_testIssue117TableBid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _testIssue117TableBid)
		{
			return Delete(null, _testIssue117TableBid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableBid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _testIssue117TableBid);		
		
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
		public override Nettiers.AdventureWorks.Entities.TestIssue117Tableb Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestIssue117TablebKey key, int start, int pageLength)
		{
			return GetByTestIssue117TableBid(transactionManager, key.TestIssue117TableBid, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TestIssue117TableB index.
		/// </summary>
		/// <param name="_testIssue117TableBid"></param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tableb GetByTestIssue117TableBid(System.Int32 _testIssue117TableBid)
		{
			int count = -1;
			return GetByTestIssue117TableBid(null,_testIssue117TableBid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableB index.
		/// </summary>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tableb GetByTestIssue117TableBid(System.Int32 _testIssue117TableBid, int start, int pageLength)
		{
			int count = -1;
			return GetByTestIssue117TableBid(null, _testIssue117TableBid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableB index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableBid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tableb GetByTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableBid)
		{
			int count = -1;
			return GetByTestIssue117TableBid(transactionManager, _testIssue117TableBid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableB index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tableb GetByTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableBid, int start, int pageLength)
		{
			int count = -1;
			return GetByTestIssue117TableBid(transactionManager, _testIssue117TableBid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableB index.
		/// </summary>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tableb GetByTestIssue117TableBid(System.Int32 _testIssue117TableBid, int start, int pageLength, out int count)
		{
			return GetByTestIssue117TableBid(null, _testIssue117TableBid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableB index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.TestIssue117Tableb GetByTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableBid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TestIssue117Tableb&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TestIssue117Tableb&gt;"/></returns>
		public static TList<TestIssue117Tableb> Fill(IDataReader reader, TList<TestIssue117Tableb> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.TestIssue117Tableb c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TestIssue117Tableb")
					.Append("|").Append((System.Int32)reader[((int)TestIssue117TablebColumn.TestIssue117TableBid - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TestIssue117Tableb>(
					key.ToString(), // EntityTrackingKey
					"TestIssue117Tableb",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.TestIssue117Tableb();
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
					c.TestIssue117TableBid = (System.Int32)reader[((int)TestIssue117TablebColumn.TestIssue117TableBid - 1)];
					c.DumbField = (reader.IsDBNull(((int)TestIssue117TablebColumn.DumbField - 1)))?null:(System.Boolean?)reader[((int)TestIssue117TablebColumn.DumbField - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.TestIssue117Tableb entity)
		{
			if (!reader.Read()) return;
			
			entity.TestIssue117TableBid = (System.Int32)reader[((int)TestIssue117TablebColumn.TestIssue117TableBid - 1)];
			entity.DumbField = (reader.IsDBNull(((int)TestIssue117TablebColumn.DumbField - 1)))?null:(System.Boolean?)reader[((int)TestIssue117TablebColumn.DumbField - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.TestIssue117Tableb entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TestIssue117TableBid = (System.Int32)dataRow["TestIssue117TableBId"];
			entity.DumbField = Convert.IsDBNull(dataRow["DumbField"]) ? null : (System.Boolean?)dataRow["DumbField"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tableb"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TestIssue117Tableb Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestIssue117Tableb entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByTestIssue117TableBid methods when available
			
			#region TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<TestIssue117Tablea>|TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec", deepLoadType, innerList))
			{
				entity.TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec = DataRepository.TestIssue117TableaProvider.GetByTestIssue117TableBidFromTestIssue117Tablec(transactionManager, entity.TestIssue117TableBid);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec != null)
				{
					deepHandles.Add("TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< TestIssue117Tablea >) DataRepository.TestIssue117TableaProvider.DeepLoad,
						new object[] { transactionManager, entity.TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region TestIssue117TablecCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<TestIssue117Tablec>|TestIssue117TablecCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TestIssue117TablecCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TestIssue117TablecCollection = DataRepository.TestIssue117TablecProvider.GetByTestIssue117TableBid(transactionManager, entity.TestIssue117TableBid);

				if (deep && entity.TestIssue117TablecCollection.Count > 0)
				{
					deepHandles.Add("TestIssue117TablecCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<TestIssue117Tablec>) DataRepository.TestIssue117TablecProvider.DeepLoad,
						new object[] { transactionManager, entity.TestIssue117TablecCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.TestIssue117Tableb object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.TestIssue117Tableb instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TestIssue117Tableb Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestIssue117Tableb entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec>
			if (CanDeepSave(entity.TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec, "List<TestIssue117Tablea>|TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec", deepSaveType, innerList))
			{
				if (entity.TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec.Count > 0 || entity.TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec.DeletedItems.Count > 0)
				{
					DataRepository.TestIssue117TableaProvider.Save(transactionManager, entity.TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec); 
					deepHandles.Add("TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<TestIssue117Tablea>) DataRepository.TestIssue117TableaProvider.DeepSave,
						new object[] { transactionManager, entity.TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<TestIssue117Tablec>
				if (CanDeepSave(entity.TestIssue117TablecCollection, "List<TestIssue117Tablec>|TestIssue117TablecCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(TestIssue117Tablec child in entity.TestIssue117TablecCollection)
					{
						if(child.TestIssue117TableBidSource != null)
						{
								child.TestIssue117TableBid = child.TestIssue117TableBidSource.TestIssue117TableBid;
						}

						if(child.TestIssue117TableAidSource != null)
						{
								child.TestIssue117TableAid = child.TestIssue117TableAidSource.TestIssue117TableAid;
						}

					}

					if (entity.TestIssue117TablecCollection.Count > 0 || entity.TestIssue117TablecCollection.DeletedItems.Count > 0)
					{
						//DataRepository.TestIssue117TablecProvider.Save(transactionManager, entity.TestIssue117TablecCollection);
						
						deepHandles.Add("TestIssue117TablecCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< TestIssue117Tablec >) DataRepository.TestIssue117TablecProvider.DeepSave,
							new object[] { transactionManager, entity.TestIssue117TablecCollection, deepSaveType, childTypes, innerList }
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
	
	#region TestIssue117TablebChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.TestIssue117Tableb</c>
	///</summary>
	public enum TestIssue117TablebChildEntityTypes
	{

		///<summary>
		/// Collection of <c>TestIssue117Tableb</c> as ManyToMany for TestIssue117TableaCollection_From_TestIssue117Tablec
		///</summary>
		[ChildEntityType(typeof(TList<TestIssue117Tablea>))]
		TestIssue117TableAidTestIssue117TableaCollection_From_TestIssue117Tablec,

		///<summary>
		/// Collection of <c>TestIssue117Tableb</c> as OneToMany for TestIssue117TablecCollection
		///</summary>
		[ChildEntityType(typeof(TList<TestIssue117Tablec>))]
		TestIssue117TablecCollection,
	}
	
	#endregion TestIssue117TablebChildEntityTypes
	
	#region TestIssue117TablebFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TestIssue117TablebColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tableb"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablebFilterBuilder : SqlFilterBuilder<TestIssue117TablebColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebFilterBuilder class.
		/// </summary>
		public TestIssue117TablebFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestIssue117TablebFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestIssue117TablebFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestIssue117TablebFilterBuilder
	
	#region TestIssue117TablebParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TestIssue117TablebColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tableb"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablebParameterBuilder : ParameterizedSqlFilterBuilder<TestIssue117TablebColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebParameterBuilder class.
		/// </summary>
		public TestIssue117TablebParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestIssue117TablebParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestIssue117TablebParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestIssue117TablebParameterBuilder
	
	#region TestIssue117TablebSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TestIssue117TablebColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tableb"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TestIssue117TablebSortBuilder : SqlSortBuilder<TestIssue117TablebColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebSqlSortBuilder class.
		/// </summary>
		public TestIssue117TablebSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TestIssue117TablebSortBuilder
	
} // end namespace
