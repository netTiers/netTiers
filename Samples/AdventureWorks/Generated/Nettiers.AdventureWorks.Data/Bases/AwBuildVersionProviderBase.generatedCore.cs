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
	/// This class is the base class for any <see cref="AwBuildVersionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AwBuildVersionProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.AwBuildVersion, Nettiers.AdventureWorks.Entities.AwBuildVersionKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AwBuildVersionKey key)
		{
			return Delete(transactionManager, key.SystemInformationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_systemInformationId">Primary key for AWBuildVersion records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Byte _systemInformationId)
		{
			return Delete(null, _systemInformationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemInformationId">Primary key for AWBuildVersion records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Byte _systemInformationId);		
		
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
		public override Nettiers.AdventureWorks.Entities.AwBuildVersion Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AwBuildVersionKey key, int start, int pageLength)
		{
			return GetBySystemInformationId(transactionManager, key.SystemInformationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AWBuildVersion_SystemInformationID index.
		/// </summary>
		/// <param name="_systemInformationId">Primary key for AWBuildVersion records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AwBuildVersion GetBySystemInformationId(System.Byte _systemInformationId)
		{
			int count = -1;
			return GetBySystemInformationId(null,_systemInformationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AWBuildVersion_SystemInformationID index.
		/// </summary>
		/// <param name="_systemInformationId">Primary key for AWBuildVersion records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AwBuildVersion GetBySystemInformationId(System.Byte _systemInformationId, int start, int pageLength)
		{
			int count = -1;
			return GetBySystemInformationId(null, _systemInformationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AWBuildVersion_SystemInformationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemInformationId">Primary key for AWBuildVersion records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AwBuildVersion GetBySystemInformationId(TransactionManager transactionManager, System.Byte _systemInformationId)
		{
			int count = -1;
			return GetBySystemInformationId(transactionManager, _systemInformationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AWBuildVersion_SystemInformationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemInformationId">Primary key for AWBuildVersion records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AwBuildVersion GetBySystemInformationId(TransactionManager transactionManager, System.Byte _systemInformationId, int start, int pageLength)
		{
			int count = -1;
			return GetBySystemInformationId(transactionManager, _systemInformationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AWBuildVersion_SystemInformationID index.
		/// </summary>
		/// <param name="_systemInformationId">Primary key for AWBuildVersion records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.AwBuildVersion GetBySystemInformationId(System.Byte _systemInformationId, int start, int pageLength, out int count)
		{
			return GetBySystemInformationId(null, _systemInformationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AWBuildVersion_SystemInformationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemInformationId">Primary key for AWBuildVersion records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.AwBuildVersion GetBySystemInformationId(TransactionManager transactionManager, System.Byte _systemInformationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AwBuildVersion&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AwBuildVersion&gt;"/></returns>
		public static TList<AwBuildVersion> Fill(IDataReader reader, TList<AwBuildVersion> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.AwBuildVersion c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AwBuildVersion")
					.Append("|").Append((System.Byte)reader[((int)AwBuildVersionColumn.SystemInformationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AwBuildVersion>(
					key.ToString(), // EntityTrackingKey
					"AwBuildVersion",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.AwBuildVersion();
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
					c.SystemInformationId = (System.Byte)reader[((int)AwBuildVersionColumn.SystemInformationId - 1)];
					c.DatabaseVersion = (System.String)reader[((int)AwBuildVersionColumn.DatabaseVersion - 1)];
					c.VersionDate = (System.DateTime)reader[((int)AwBuildVersionColumn.VersionDate - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)AwBuildVersionColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.AwBuildVersion entity)
		{
			if (!reader.Read()) return;
			
			entity.SystemInformationId = (System.Byte)reader[((int)AwBuildVersionColumn.SystemInformationId - 1)];
			entity.DatabaseVersion = (System.String)reader[((int)AwBuildVersionColumn.DatabaseVersion - 1)];
			entity.VersionDate = (System.DateTime)reader[((int)AwBuildVersionColumn.VersionDate - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)AwBuildVersionColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.AwBuildVersion entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SystemInformationId = (System.Byte)dataRow["SystemInformationID"];
			entity.DatabaseVersion = (System.String)dataRow["Database Version"];
			entity.VersionDate = (System.DateTime)dataRow["VersionDate"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.AwBuildVersion"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.AwBuildVersion Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AwBuildVersion entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.AwBuildVersion object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.AwBuildVersion instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.AwBuildVersion Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AwBuildVersion entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AwBuildVersionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.AwBuildVersion</c>
	///</summary>
	public enum AwBuildVersionChildEntityTypes
	{
	}
	
	#endregion AwBuildVersionChildEntityTypes
	
	#region AwBuildVersionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AwBuildVersionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AwBuildVersion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AwBuildVersionFilterBuilder : SqlFilterBuilder<AwBuildVersionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionFilterBuilder class.
		/// </summary>
		public AwBuildVersionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AwBuildVersionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AwBuildVersionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AwBuildVersionFilterBuilder
	
	#region AwBuildVersionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AwBuildVersionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AwBuildVersion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AwBuildVersionParameterBuilder : ParameterizedSqlFilterBuilder<AwBuildVersionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionParameterBuilder class.
		/// </summary>
		public AwBuildVersionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AwBuildVersionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AwBuildVersionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AwBuildVersionParameterBuilder
	
	#region AwBuildVersionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AwBuildVersionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AwBuildVersion"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AwBuildVersionSortBuilder : SqlSortBuilder<AwBuildVersionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionSqlSortBuilder class.
		/// </summary>
		public AwBuildVersionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AwBuildVersionSortBuilder
	
} // end namespace
