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
	/// This class is the base class for any <see cref="TestTimestampProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TestTimestampProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.TestTimestamp, Nettiers.AdventureWorks.Entities.TestTimestampKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestTimestampKey key)
		{
			return Delete(transactionManager, key.TestTimestampId, ((key.Entity != null) ? key.Entity.Version : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_testTimestampId">. Primary Key.</param>
		/// <param name="_version">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _testTimestampId, byte[] _version)
		{
			return Delete(null, _testTimestampId, _version);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testTimestampId">. Primary Key.</param>
		/// <param name="_version">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _testTimestampId, byte[] _version);		
		
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
		public override Nettiers.AdventureWorks.Entities.TestTimestamp Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestTimestampKey key, int start, int pageLength)
		{
			return GetByTestTimestampId(transactionManager, key.TestTimestampId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TestTimestamp index.
		/// </summary>
		/// <param name="_testTimestampId"></param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestTimestamp GetByTestTimestampId(System.Int32 _testTimestampId)
		{
			int count = -1;
			return GetByTestTimestampId(null,_testTimestampId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestTimestamp index.
		/// </summary>
		/// <param name="_testTimestampId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestTimestamp GetByTestTimestampId(System.Int32 _testTimestampId, int start, int pageLength)
		{
			int count = -1;
			return GetByTestTimestampId(null, _testTimestampId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestTimestamp index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testTimestampId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestTimestamp GetByTestTimestampId(TransactionManager transactionManager, System.Int32 _testTimestampId)
		{
			int count = -1;
			return GetByTestTimestampId(transactionManager, _testTimestampId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestTimestamp index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testTimestampId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestTimestamp GetByTestTimestampId(TransactionManager transactionManager, System.Int32 _testTimestampId, int start, int pageLength)
		{
			int count = -1;
			return GetByTestTimestampId(transactionManager, _testTimestampId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestTimestamp index.
		/// </summary>
		/// <param name="_testTimestampId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestTimestamp GetByTestTimestampId(System.Int32 _testTimestampId, int start, int pageLength, out int count)
		{
			return GetByTestTimestampId(null, _testTimestampId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TestTimestamp index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_testTimestampId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.TestTimestamp GetByTestTimestampId(TransactionManager transactionManager, System.Int32 _testTimestampId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region _TestTimestamp_GetAllTimestamp 
		
		/// <summary>
		///	This method wrap the '_TestTimestamp_GetAllTimestamp' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;TestTimestamp&gt;"/> instance.</returns>
		public TList<TestTimestamp> GetAllTimestamp()
		{
			return GetAllTimestamp(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the '_TestTimestamp_GetAllTimestamp' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;TestTimestamp&gt;"/> instance.</returns>
		public TList<TestTimestamp> GetAllTimestamp(int start, int pageLength)
		{
			return GetAllTimestamp(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the '_TestTimestamp_GetAllTimestamp' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;TestTimestamp&gt;"/> instance.</returns>
		public TList<TestTimestamp> GetAllTimestamp(TransactionManager transactionManager)
		{
			return GetAllTimestamp(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the '_TestTimestamp_GetAllTimestamp' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;TestTimestamp&gt;"/> instance.</returns>
		public abstract TList<TestTimestamp> GetAllTimestamp(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TestTimestamp&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TestTimestamp&gt;"/></returns>
		public static TList<TestTimestamp> Fill(IDataReader reader, TList<TestTimestamp> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.TestTimestamp c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TestTimestamp")
					.Append("|").Append((System.Int32)reader[((int)TestTimestampColumn.TestTimestampId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TestTimestamp>(
					key.ToString(), // EntityTrackingKey
					"TestTimestamp",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.TestTimestamp();
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
					c.TestTimestampId = (System.Int32)reader[((int)TestTimestampColumn.TestTimestampId - 1)];
					c.DumbField = (reader.IsDBNull(((int)TestTimestampColumn.DumbField - 1)))?null:(System.Boolean?)reader[((int)TestTimestampColumn.DumbField - 1)];
					c.Version = (System.Byte[])reader[((int)TestTimestampColumn.Version - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.TestTimestamp entity)
		{
			if (!reader.Read()) return;
			
			entity.TestTimestampId = (System.Int32)reader[((int)TestTimestampColumn.TestTimestampId - 1)];
			entity.DumbField = (reader.IsDBNull(((int)TestTimestampColumn.DumbField - 1)))?null:(System.Boolean?)reader[((int)TestTimestampColumn.DumbField - 1)];
			entity.Version = (System.Byte[])reader[((int)TestTimestampColumn.Version - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.TestTimestamp entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TestTimestampId = (System.Int32)dataRow["TestTimestampId"];
			entity.DumbField = Convert.IsDBNull(dataRow["DumbField"]) ? null : (System.Boolean?)dataRow["DumbField"];
			entity.Version = (System.Byte[])dataRow["Version"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestTimestamp"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TestTimestamp Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestTimestamp entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.TestTimestamp object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.TestTimestamp instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TestTimestamp Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestTimestamp entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TestTimestampChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.TestTimestamp</c>
	///</summary>
	public enum TestTimestampChildEntityTypes
	{
	}
	
	#endregion TestTimestampChildEntityTypes
	
	#region TestTimestampFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TestTimestampColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestTimestamp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestTimestampFilterBuilder : SqlFilterBuilder<TestTimestampColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestTimestampFilterBuilder class.
		/// </summary>
		public TestTimestampFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestTimestampFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestTimestampFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestTimestampFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestTimestampFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestTimestampFilterBuilder
	
	#region TestTimestampParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TestTimestampColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestTimestamp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestTimestampParameterBuilder : ParameterizedSqlFilterBuilder<TestTimestampColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestTimestampParameterBuilder class.
		/// </summary>
		public TestTimestampParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestTimestampParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestTimestampParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestTimestampParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestTimestampParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestTimestampParameterBuilder
	
	#region TestTimestampSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TestTimestampColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestTimestamp"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TestTimestampSortBuilder : SqlSortBuilder<TestTimestampColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestTimestampSqlSortBuilder class.
		/// </summary>
		public TestTimestampSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TestTimestampSortBuilder
	
} // end namespace
