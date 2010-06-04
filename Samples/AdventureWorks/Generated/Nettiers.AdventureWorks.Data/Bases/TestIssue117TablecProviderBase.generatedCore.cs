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
	/// This class is the base class for any <see cref="TestIssue117TablecProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TestIssue117TablecProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.TestIssue117Tablec, Nettiers.AdventureWorks.Entities.TestIssue117TablecKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestIssue117TablecKey key)
		{
			return Delete(transactionManager, key.TestIssue117TableAid, key.TestIssue117TableBid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_testIssue117TableAid">. Primary Key.</param>
		/// <param name="_testIssue117TableBid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _testIssue117TableAid, System.Int32 _testIssue117TableBid)
		{
			return Delete(null, _testIssue117TableAid, _testIssue117TableBid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid">. Primary Key.</param>
		/// <param name="_testIssue117TableBid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _testIssue117TableAid, System.Int32 _testIssue117TableBid);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableA key.
		///		FK_TestIssue117TableC_TestIssue117TableA Description: 
		/// </summary>
		/// <param name="_testIssue117TableAid"></param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public TList<TestIssue117Tablec> GetByTestIssue117TableAid(System.Int32 _testIssue117TableAid)
		{
			int count = -1;
			return GetByTestIssue117TableAid(_testIssue117TableAid, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableA key.
		///		FK_TestIssue117TableC_TestIssue117TableA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		/// <remarks></remarks>
		public TList<TestIssue117Tablec> GetByTestIssue117TableAid(TransactionManager transactionManager, System.Int32 _testIssue117TableAid)
		{
			int count = -1;
			return GetByTestIssue117TableAid(transactionManager, _testIssue117TableAid, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableA key.
		///		FK_TestIssue117TableC_TestIssue117TableA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public TList<TestIssue117Tablec> GetByTestIssue117TableAid(TransactionManager transactionManager, System.Int32 _testIssue117TableAid, int start, int pageLength)
		{
			int count = -1;
			return GetByTestIssue117TableAid(transactionManager, _testIssue117TableAid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableA key.
		///		fkTestIssue117TablecTestIssue117Tablea Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public TList<TestIssue117Tablec> GetByTestIssue117TableAid(System.Int32 _testIssue117TableAid, int start, int pageLength)
		{
			int count =  -1;
			return GetByTestIssue117TableAid(null, _testIssue117TableAid, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableA key.
		///		fkTestIssue117TablecTestIssue117Tablea Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public TList<TestIssue117Tablec> GetByTestIssue117TableAid(System.Int32 _testIssue117TableAid, int start, int pageLength,out int count)
		{
			return GetByTestIssue117TableAid(null, _testIssue117TableAid, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableA key.
		///		FK_TestIssue117TableC_TestIssue117TableA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public abstract TList<TestIssue117Tablec> GetByTestIssue117TableAid(TransactionManager transactionManager, System.Int32 _testIssue117TableAid, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableB key.
		///		FK_TestIssue117TableC_TestIssue117TableB Description: 
		/// </summary>
		/// <param name="_testIssue117TableBid"></param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public TList<TestIssue117Tablec> GetByTestIssue117TableBid(System.Int32 _testIssue117TableBid)
		{
			int count = -1;
			return GetByTestIssue117TableBid(_testIssue117TableBid, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableB key.
		///		FK_TestIssue117TableC_TestIssue117TableB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableBid"></param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		/// <remarks></remarks>
		public TList<TestIssue117Tablec> GetByTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableBid)
		{
			int count = -1;
			return GetByTestIssue117TableBid(transactionManager, _testIssue117TableBid, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableB key.
		///		FK_TestIssue117TableC_TestIssue117TableB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public TList<TestIssue117Tablec> GetByTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableBid, int start, int pageLength)
		{
			int count = -1;
			return GetByTestIssue117TableBid(transactionManager, _testIssue117TableBid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableB key.
		///		fkTestIssue117TablecTestIssue117Tableb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testIssue117TableBid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public TList<TestIssue117Tablec> GetByTestIssue117TableBid(System.Int32 _testIssue117TableBid, int start, int pageLength)
		{
			int count =  -1;
			return GetByTestIssue117TableBid(null, _testIssue117TableBid, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableB key.
		///		fkTestIssue117TablecTestIssue117Tableb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public TList<TestIssue117Tablec> GetByTestIssue117TableBid(System.Int32 _testIssue117TableBid, int start, int pageLength,out int count)
		{
			return GetByTestIssue117TableBid(null, _testIssue117TableBid, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TestIssue117TableC_TestIssue117TableB key.
		///		FK_TestIssue117TableC_TestIssue117TableB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.TestIssue117Tablec objects.</returns>
		public abstract TList<TestIssue117Tablec> GetByTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableBid, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.TestIssue117Tablec Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestIssue117TablecKey key, int start, int pageLength)
		{
			return GetByTestIssue117TableAidTestIssue117TableBid(transactionManager, key.TestIssue117TableAid, key.TestIssue117TableBid, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TestIssue117TableC index.
		/// </summary>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="_testIssue117TableBid"></param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tablec GetByTestIssue117TableAidTestIssue117TableBid(System.Int32 _testIssue117TableAid, System.Int32 _testIssue117TableBid)
		{
			int count = -1;
			return GetByTestIssue117TableAidTestIssue117TableBid(null,_testIssue117TableAid, _testIssue117TableBid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableC index.
		/// </summary>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tablec GetByTestIssue117TableAidTestIssue117TableBid(System.Int32 _testIssue117TableAid, System.Int32 _testIssue117TableBid, int start, int pageLength)
		{
			int count = -1;
			return GetByTestIssue117TableAidTestIssue117TableBid(null, _testIssue117TableAid, _testIssue117TableBid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="_testIssue117TableBid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tablec GetByTestIssue117TableAidTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableAid, System.Int32 _testIssue117TableBid)
		{
			int count = -1;
			return GetByTestIssue117TableAidTestIssue117TableBid(transactionManager, _testIssue117TableAid, _testIssue117TableBid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tablec GetByTestIssue117TableAidTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableAid, System.Int32 _testIssue117TableBid, int start, int pageLength)
		{
			int count = -1;
			return GetByTestIssue117TableAidTestIssue117TableBid(transactionManager, _testIssue117TableAid, _testIssue117TableBid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableC index.
		/// </summary>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestIssue117Tablec GetByTestIssue117TableAidTestIssue117TableBid(System.Int32 _testIssue117TableAid, System.Int32 _testIssue117TableBid, int start, int pageLength, out int count)
		{
			return GetByTestIssue117TableAidTestIssue117TableBid(null, _testIssue117TableAid, _testIssue117TableBid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestIssue117TableC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testIssue117TableAid"></param>
		/// <param name="_testIssue117TableBid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.TestIssue117Tablec GetByTestIssue117TableAidTestIssue117TableBid(TransactionManager transactionManager, System.Int32 _testIssue117TableAid, System.Int32 _testIssue117TableBid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TestIssue117Tablec&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TestIssue117Tablec&gt;"/></returns>
		public static TList<TestIssue117Tablec> Fill(IDataReader reader, TList<TestIssue117Tablec> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.TestIssue117Tablec c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TestIssue117Tablec")
					.Append("|").Append((System.Int32)reader[((int)TestIssue117TablecColumn.TestIssue117TableAid - 1)])
					.Append("|").Append((System.Int32)reader[((int)TestIssue117TablecColumn.TestIssue117TableBid - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TestIssue117Tablec>(
					key.ToString(), // EntityTrackingKey
					"TestIssue117Tablec",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.TestIssue117Tablec();
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
					c.TestIssue117TableAid = (System.Int32)reader[((int)TestIssue117TablecColumn.TestIssue117TableAid - 1)];
					c.OriginalTestIssue117TableAid = c.TestIssue117TableAid;
					c.TestIssue117TableBid = (System.Int32)reader[((int)TestIssue117TablecColumn.TestIssue117TableBid - 1)];
					c.OriginalTestIssue117TableBid = c.TestIssue117TableBid;
					c.DumbField = (reader.IsDBNull(((int)TestIssue117TablecColumn.DumbField - 1)))?null:(System.Boolean?)reader[((int)TestIssue117TablecColumn.DumbField - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.TestIssue117Tablec entity)
		{
			if (!reader.Read()) return;
			
			entity.TestIssue117TableAid = (System.Int32)reader[((int)TestIssue117TablecColumn.TestIssue117TableAid - 1)];
			entity.OriginalTestIssue117TableAid = (System.Int32)reader["TestIssue117TableAId"];
			entity.TestIssue117TableBid = (System.Int32)reader[((int)TestIssue117TablecColumn.TestIssue117TableBid - 1)];
			entity.OriginalTestIssue117TableBid = (System.Int32)reader["TestIssue117TableBId"];
			entity.DumbField = (reader.IsDBNull(((int)TestIssue117TablecColumn.DumbField - 1)))?null:(System.Boolean?)reader[((int)TestIssue117TablecColumn.DumbField - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.TestIssue117Tablec entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TestIssue117TableAid = (System.Int32)dataRow["TestIssue117TableAId"];
			entity.OriginalTestIssue117TableAid = (System.Int32)dataRow["TestIssue117TableAId"];
			entity.TestIssue117TableBid = (System.Int32)dataRow["TestIssue117TableBId"];
			entity.OriginalTestIssue117TableBid = (System.Int32)dataRow["TestIssue117TableBId"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestIssue117Tablec"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TestIssue117Tablec Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestIssue117Tablec entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region TestIssue117TableAidSource	
			if (CanDeepLoad(entity, "TestIssue117Tablea|TestIssue117TableAidSource", deepLoadType, innerList) 
				&& entity.TestIssue117TableAidSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TestIssue117TableAid;
				TestIssue117Tablea tmpEntity = EntityManager.LocateEntity<TestIssue117Tablea>(EntityLocator.ConstructKeyFromPkItems(typeof(TestIssue117Tablea), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TestIssue117TableAidSource = tmpEntity;
				else
					entity.TestIssue117TableAidSource = DataRepository.TestIssue117TableaProvider.GetByTestIssue117TableAid(transactionManager, entity.TestIssue117TableAid);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TestIssue117TableAidSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TestIssue117TableAidSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TestIssue117TableaProvider.DeepLoad(transactionManager, entity.TestIssue117TableAidSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TestIssue117TableAidSource

			#region TestIssue117TableBidSource	
			if (CanDeepLoad(entity, "TestIssue117Tableb|TestIssue117TableBidSource", deepLoadType, innerList) 
				&& entity.TestIssue117TableBidSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TestIssue117TableBid;
				TestIssue117Tableb tmpEntity = EntityManager.LocateEntity<TestIssue117Tableb>(EntityLocator.ConstructKeyFromPkItems(typeof(TestIssue117Tableb), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TestIssue117TableBidSource = tmpEntity;
				else
					entity.TestIssue117TableBidSource = DataRepository.TestIssue117TablebProvider.GetByTestIssue117TableBid(transactionManager, entity.TestIssue117TableBid);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TestIssue117TableBidSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TestIssue117TableBidSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TestIssue117TablebProvider.DeepLoad(transactionManager, entity.TestIssue117TableBidSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TestIssue117TableBidSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.TestIssue117Tablec object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.TestIssue117Tablec instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TestIssue117Tablec Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestIssue117Tablec entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region TestIssue117TableAidSource
			if (CanDeepSave(entity, "TestIssue117Tablea|TestIssue117TableAidSource", deepSaveType, innerList) 
				&& entity.TestIssue117TableAidSource != null)
			{
				DataRepository.TestIssue117TableaProvider.Save(transactionManager, entity.TestIssue117TableAidSource);
				entity.TestIssue117TableAid = entity.TestIssue117TableAidSource.TestIssue117TableAid;
			}
			#endregion 
			
			#region TestIssue117TableBidSource
			if (CanDeepSave(entity, "TestIssue117Tableb|TestIssue117TableBidSource", deepSaveType, innerList) 
				&& entity.TestIssue117TableBidSource != null)
			{
				DataRepository.TestIssue117TablebProvider.Save(transactionManager, entity.TestIssue117TableBidSource);
				entity.TestIssue117TableBid = entity.TestIssue117TableBidSource.TestIssue117TableBid;
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
	
	#region TestIssue117TablecChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.TestIssue117Tablec</c>
	///</summary>
	public enum TestIssue117TablecChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>TestIssue117Tablea</c> at TestIssue117TableAidSource
		///</summary>
		[ChildEntityType(typeof(TestIssue117Tablea))]
		TestIssue117Tablea,
			
		///<summary>
		/// Composite Property for <c>TestIssue117Tableb</c> at TestIssue117TableBidSource
		///</summary>
		[ChildEntityType(typeof(TestIssue117Tableb))]
		TestIssue117Tableb,
		}
	
	#endregion TestIssue117TablecChildEntityTypes
	
	#region TestIssue117TablecFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TestIssue117TablecColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablec"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablecFilterBuilder : SqlFilterBuilder<TestIssue117TablecColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecFilterBuilder class.
		/// </summary>
		public TestIssue117TablecFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestIssue117TablecFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestIssue117TablecFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestIssue117TablecFilterBuilder
	
	#region TestIssue117TablecParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TestIssue117TablecColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablec"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablecParameterBuilder : ParameterizedSqlFilterBuilder<TestIssue117TablecColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecParameterBuilder class.
		/// </summary>
		public TestIssue117TablecParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestIssue117TablecParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestIssue117TablecParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestIssue117TablecParameterBuilder
	
	#region TestIssue117TablecSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TestIssue117TablecColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablec"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TestIssue117TablecSortBuilder : SqlSortBuilder<TestIssue117TablecColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecSqlSortBuilder class.
		/// </summary>
		public TestIssue117TablecSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TestIssue117TablecSortBuilder
	
} // end namespace
