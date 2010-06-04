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
	/// This class is the base class for any <see cref="ErrorLogProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ErrorLogProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ErrorLog, Nettiers.AdventureWorks.Entities.ErrorLogKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ErrorLogKey key)
		{
			return Delete(transactionManager, key.ErrorLogId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_errorLogId">Primary key for ErrorLog records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _errorLogId)
		{
			return Delete(null, _errorLogId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_errorLogId">Primary key for ErrorLog records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _errorLogId);		
		
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
		public override Nettiers.AdventureWorks.Entities.ErrorLog Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ErrorLogKey key, int start, int pageLength)
		{
			return GetByErrorLogId(transactionManager, key.ErrorLogId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ErrorLog_ErrorLogID index.
		/// </summary>
		/// <param name="_errorLogId">Primary key for ErrorLog records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ErrorLog GetByErrorLogId(System.Int32 _errorLogId)
		{
			int count = -1;
			return GetByErrorLogId(null,_errorLogId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ErrorLog_ErrorLogID index.
		/// </summary>
		/// <param name="_errorLogId">Primary key for ErrorLog records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ErrorLog GetByErrorLogId(System.Int32 _errorLogId, int start, int pageLength)
		{
			int count = -1;
			return GetByErrorLogId(null, _errorLogId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ErrorLog_ErrorLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_errorLogId">Primary key for ErrorLog records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ErrorLog GetByErrorLogId(TransactionManager transactionManager, System.Int32 _errorLogId)
		{
			int count = -1;
			return GetByErrorLogId(transactionManager, _errorLogId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ErrorLog_ErrorLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_errorLogId">Primary key for ErrorLog records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ErrorLog GetByErrorLogId(TransactionManager transactionManager, System.Int32 _errorLogId, int start, int pageLength)
		{
			int count = -1;
			return GetByErrorLogId(transactionManager, _errorLogId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ErrorLog_ErrorLogID index.
		/// </summary>
		/// <param name="_errorLogId">Primary key for ErrorLog records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ErrorLog GetByErrorLogId(System.Int32 _errorLogId, int start, int pageLength, out int count)
		{
			return GetByErrorLogId(null, _errorLogId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ErrorLog_ErrorLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_errorLogId">Primary key for ErrorLog records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ErrorLog GetByErrorLogId(TransactionManager transactionManager, System.Int32 _errorLogId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ErrorLog&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ErrorLog&gt;"/></returns>
		public static TList<ErrorLog> Fill(IDataReader reader, TList<ErrorLog> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ErrorLog c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ErrorLog")
					.Append("|").Append((System.Int32)reader[((int)ErrorLogColumn.ErrorLogId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ErrorLog>(
					key.ToString(), // EntityTrackingKey
					"ErrorLog",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ErrorLog();
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
					c.ErrorLogId = (System.Int32)reader[((int)ErrorLogColumn.ErrorLogId - 1)];
					c.ErrorTime = (System.DateTime)reader[((int)ErrorLogColumn.ErrorTime - 1)];
					c.UserName = (System.String)reader[((int)ErrorLogColumn.UserName - 1)];
					c.ErrorNumber = (System.Int32)reader[((int)ErrorLogColumn.ErrorNumber - 1)];
					c.ErrorSeverity = (reader.IsDBNull(((int)ErrorLogColumn.ErrorSeverity - 1)))?null:(System.Int32?)reader[((int)ErrorLogColumn.ErrorSeverity - 1)];
					c.ErrorState = (reader.IsDBNull(((int)ErrorLogColumn.ErrorState - 1)))?null:(System.Int32?)reader[((int)ErrorLogColumn.ErrorState - 1)];
					c.ErrorProcedure = (reader.IsDBNull(((int)ErrorLogColumn.ErrorProcedure - 1)))?null:(System.String)reader[((int)ErrorLogColumn.ErrorProcedure - 1)];
					c.ErrorLine = (reader.IsDBNull(((int)ErrorLogColumn.ErrorLine - 1)))?null:(System.Int32?)reader[((int)ErrorLogColumn.ErrorLine - 1)];
					c.ErrorMessage = (System.String)reader[((int)ErrorLogColumn.ErrorMessage - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ErrorLog entity)
		{
			if (!reader.Read()) return;
			
			entity.ErrorLogId = (System.Int32)reader[((int)ErrorLogColumn.ErrorLogId - 1)];
			entity.ErrorTime = (System.DateTime)reader[((int)ErrorLogColumn.ErrorTime - 1)];
			entity.UserName = (System.String)reader[((int)ErrorLogColumn.UserName - 1)];
			entity.ErrorNumber = (System.Int32)reader[((int)ErrorLogColumn.ErrorNumber - 1)];
			entity.ErrorSeverity = (reader.IsDBNull(((int)ErrorLogColumn.ErrorSeverity - 1)))?null:(System.Int32?)reader[((int)ErrorLogColumn.ErrorSeverity - 1)];
			entity.ErrorState = (reader.IsDBNull(((int)ErrorLogColumn.ErrorState - 1)))?null:(System.Int32?)reader[((int)ErrorLogColumn.ErrorState - 1)];
			entity.ErrorProcedure = (reader.IsDBNull(((int)ErrorLogColumn.ErrorProcedure - 1)))?null:(System.String)reader[((int)ErrorLogColumn.ErrorProcedure - 1)];
			entity.ErrorLine = (reader.IsDBNull(((int)ErrorLogColumn.ErrorLine - 1)))?null:(System.Int32?)reader[((int)ErrorLogColumn.ErrorLine - 1)];
			entity.ErrorMessage = (System.String)reader[((int)ErrorLogColumn.ErrorMessage - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ErrorLog entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ErrorLogId = (System.Int32)dataRow["ErrorLogID"];
			entity.ErrorTime = (System.DateTime)dataRow["ErrorTime"];
			entity.UserName = (System.String)dataRow["UserName"];
			entity.ErrorNumber = (System.Int32)dataRow["ErrorNumber"];
			entity.ErrorSeverity = Convert.IsDBNull(dataRow["ErrorSeverity"]) ? null : (System.Int32?)dataRow["ErrorSeverity"];
			entity.ErrorState = Convert.IsDBNull(dataRow["ErrorState"]) ? null : (System.Int32?)dataRow["ErrorState"];
			entity.ErrorProcedure = Convert.IsDBNull(dataRow["ErrorProcedure"]) ? null : (System.String)dataRow["ErrorProcedure"];
			entity.ErrorLine = Convert.IsDBNull(dataRow["ErrorLine"]) ? null : (System.Int32?)dataRow["ErrorLine"];
			entity.ErrorMessage = (System.String)dataRow["ErrorMessage"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ErrorLog Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ErrorLog entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ErrorLog object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ErrorLog instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ErrorLog Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ErrorLog entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ErrorLogChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ErrorLog</c>
	///</summary>
	public enum ErrorLogChildEntityTypes
	{
	}
	
	#endregion ErrorLogChildEntityTypes
	
	#region ErrorLogFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ErrorLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorLogFilterBuilder : SqlFilterBuilder<ErrorLogColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorLogFilterBuilder class.
		/// </summary>
		public ErrorLogFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ErrorLogFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ErrorLogFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ErrorLogFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ErrorLogFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ErrorLogFilterBuilder
	
	#region ErrorLogParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ErrorLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorLogParameterBuilder : ParameterizedSqlFilterBuilder<ErrorLogColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorLogParameterBuilder class.
		/// </summary>
		public ErrorLogParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ErrorLogParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ErrorLogParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ErrorLogParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ErrorLogParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ErrorLogParameterBuilder
	
	#region ErrorLogSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ErrorLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorLog"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ErrorLogSortBuilder : SqlSortBuilder<ErrorLogColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorLogSqlSortBuilder class.
		/// </summary>
		public ErrorLogSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ErrorLogSortBuilder
	
} // end namespace
