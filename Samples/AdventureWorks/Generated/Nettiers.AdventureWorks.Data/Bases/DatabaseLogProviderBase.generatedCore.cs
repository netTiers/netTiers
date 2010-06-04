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
	/// This class is the base class for any <see cref="DatabaseLogProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DatabaseLogProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.DatabaseLog, Nettiers.AdventureWorks.Entities.DatabaseLogKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.DatabaseLogKey key)
		{
			return Delete(transactionManager, key.DatabaseLogId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_databaseLogId">Primary key for DatabaseLog records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _databaseLogId)
		{
			return Delete(null, _databaseLogId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_databaseLogId">Primary key for DatabaseLog records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _databaseLogId);		
		
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
		public override Nettiers.AdventureWorks.Entities.DatabaseLog Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.DatabaseLogKey key, int start, int pageLength)
		{
			return GetByDatabaseLogId(transactionManager, key.DatabaseLogId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DatabaseLog_DatabaseLogID index.
		/// </summary>
		/// <param name="_databaseLogId">Primary key for DatabaseLog records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.DatabaseLog GetByDatabaseLogId(System.Int32 _databaseLogId)
		{
			int count = -1;
			return GetByDatabaseLogId(null,_databaseLogId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DatabaseLog_DatabaseLogID index.
		/// </summary>
		/// <param name="_databaseLogId">Primary key for DatabaseLog records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.DatabaseLog GetByDatabaseLogId(System.Int32 _databaseLogId, int start, int pageLength)
		{
			int count = -1;
			return GetByDatabaseLogId(null, _databaseLogId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DatabaseLog_DatabaseLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_databaseLogId">Primary key for DatabaseLog records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.DatabaseLog GetByDatabaseLogId(TransactionManager transactionManager, System.Int32 _databaseLogId)
		{
			int count = -1;
			return GetByDatabaseLogId(transactionManager, _databaseLogId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DatabaseLog_DatabaseLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_databaseLogId">Primary key for DatabaseLog records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.DatabaseLog GetByDatabaseLogId(TransactionManager transactionManager, System.Int32 _databaseLogId, int start, int pageLength)
		{
			int count = -1;
			return GetByDatabaseLogId(transactionManager, _databaseLogId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DatabaseLog_DatabaseLogID index.
		/// </summary>
		/// <param name="_databaseLogId">Primary key for DatabaseLog records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.DatabaseLog GetByDatabaseLogId(System.Int32 _databaseLogId, int start, int pageLength, out int count)
		{
			return GetByDatabaseLogId(null, _databaseLogId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DatabaseLog_DatabaseLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_databaseLogId">Primary key for DatabaseLog records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.DatabaseLog GetByDatabaseLogId(TransactionManager transactionManager, System.Int32 _databaseLogId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DatabaseLog&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DatabaseLog&gt;"/></returns>
		public static TList<DatabaseLog> Fill(IDataReader reader, TList<DatabaseLog> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.DatabaseLog c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DatabaseLog")
					.Append("|").Append((System.Int32)reader[((int)DatabaseLogColumn.DatabaseLogId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DatabaseLog>(
					key.ToString(), // EntityTrackingKey
					"DatabaseLog",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.DatabaseLog();
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
					c.DatabaseLogId = (System.Int32)reader[((int)DatabaseLogColumn.DatabaseLogId - 1)];
					c.PostTime = (System.DateTime)reader[((int)DatabaseLogColumn.PostTime - 1)];
					c.DatabaseUser = (System.String)reader[((int)DatabaseLogColumn.DatabaseUser - 1)];
					c.SafeNameEvent = (System.String)reader[((int)DatabaseLogColumn.SafeNameEvent - 1)];
					c.Schema = (reader.IsDBNull(((int)DatabaseLogColumn.Schema - 1)))?null:(System.String)reader[((int)DatabaseLogColumn.Schema - 1)];
					c.SafeNameObject = (reader.IsDBNull(((int)DatabaseLogColumn.SafeNameObject - 1)))?null:(System.String)reader[((int)DatabaseLogColumn.SafeNameObject - 1)];
					c.Tsql = (System.String)reader[((int)DatabaseLogColumn.Tsql - 1)];
					c.XmlEvent = (string)reader[((int)DatabaseLogColumn.XmlEvent - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.DatabaseLog entity)
		{
			if (!reader.Read()) return;
			
			entity.DatabaseLogId = (System.Int32)reader[((int)DatabaseLogColumn.DatabaseLogId - 1)];
			entity.PostTime = (System.DateTime)reader[((int)DatabaseLogColumn.PostTime - 1)];
			entity.DatabaseUser = (System.String)reader[((int)DatabaseLogColumn.DatabaseUser - 1)];
			entity.SafeNameEvent = (System.String)reader[((int)DatabaseLogColumn.SafeNameEvent - 1)];
			entity.Schema = (reader.IsDBNull(((int)DatabaseLogColumn.Schema - 1)))?null:(System.String)reader[((int)DatabaseLogColumn.Schema - 1)];
			entity.SafeNameObject = (reader.IsDBNull(((int)DatabaseLogColumn.SafeNameObject - 1)))?null:(System.String)reader[((int)DatabaseLogColumn.SafeNameObject - 1)];
			entity.Tsql = (System.String)reader[((int)DatabaseLogColumn.Tsql - 1)];
			entity.XmlEvent = (string)reader[((int)DatabaseLogColumn.XmlEvent - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.DatabaseLog entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DatabaseLogId = (System.Int32)dataRow["DatabaseLogID"];
			entity.PostTime = (System.DateTime)dataRow["PostTime"];
			entity.DatabaseUser = (System.String)dataRow["DatabaseUser"];
			entity.SafeNameEvent = (System.String)dataRow["Event"];
			entity.Schema = Convert.IsDBNull(dataRow["Schema"]) ? null : (System.String)dataRow["Schema"];
			entity.SafeNameObject = Convert.IsDBNull(dataRow["Object"]) ? null : (System.String)dataRow["Object"];
			entity.Tsql = (System.String)dataRow["TSQL"];
			entity.XmlEvent = (string)dataRow["XmlEvent"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.DatabaseLog"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.DatabaseLog Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.DatabaseLog entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.DatabaseLog object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.DatabaseLog instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.DatabaseLog Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.DatabaseLog entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region DatabaseLogChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.DatabaseLog</c>
	///</summary>
	public enum DatabaseLogChildEntityTypes
	{
	}
	
	#endregion DatabaseLogChildEntityTypes
	
	#region DatabaseLogFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DatabaseLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DatabaseLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DatabaseLogFilterBuilder : SqlFilterBuilder<DatabaseLogColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DatabaseLogFilterBuilder class.
		/// </summary>
		public DatabaseLogFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DatabaseLogFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DatabaseLogFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DatabaseLogFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DatabaseLogFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DatabaseLogFilterBuilder
	
	#region DatabaseLogParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DatabaseLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DatabaseLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DatabaseLogParameterBuilder : ParameterizedSqlFilterBuilder<DatabaseLogColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DatabaseLogParameterBuilder class.
		/// </summary>
		public DatabaseLogParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DatabaseLogParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DatabaseLogParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DatabaseLogParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DatabaseLogParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DatabaseLogParameterBuilder
	
	#region DatabaseLogSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DatabaseLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DatabaseLog"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DatabaseLogSortBuilder : SqlSortBuilder<DatabaseLogColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DatabaseLogSqlSortBuilder class.
		/// </summary>
		public DatabaseLogSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DatabaseLogSortBuilder
	
} // end namespace
