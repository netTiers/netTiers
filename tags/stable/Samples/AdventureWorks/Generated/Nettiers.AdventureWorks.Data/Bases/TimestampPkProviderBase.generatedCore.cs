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
	/// This class is the base class for any <see cref="TimestampPkProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TimestampPkProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.TimestampPk, Nettiers.AdventureWorks.Entities.TimestampPkKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TimestampPkKey key)
		{
			return Delete(transactionManager, key.TimestampPk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_timestampPk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Byte[] _timestampPk)
		{
			return Delete(null, _timestampPk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_timestampPk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Byte[] _timestampPk);		
		
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
		public override Nettiers.AdventureWorks.Entities.TimestampPk Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TimestampPkKey key, int start, int pageLength)
		{
			return GetByTimestampPk(transactionManager, key.TimestampPk, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TimestampPK index.
		/// </summary>
		/// <param name="_timestampPk"></param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TimestampPk GetByTimestampPk(System.Byte[] _timestampPk)
		{
			int count = -1;
			return GetByTimestampPk(null,_timestampPk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TimestampPK index.
		/// </summary>
		/// <param name="_timestampPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TimestampPk GetByTimestampPk(System.Byte[] _timestampPk, int start, int pageLength)
		{
			int count = -1;
			return GetByTimestampPk(null, _timestampPk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TimestampPK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_timestampPk"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TimestampPk GetByTimestampPk(TransactionManager transactionManager, System.Byte[] _timestampPk)
		{
			int count = -1;
			return GetByTimestampPk(transactionManager, _timestampPk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TimestampPK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_timestampPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TimestampPk GetByTimestampPk(TransactionManager transactionManager, System.Byte[] _timestampPk, int start, int pageLength)
		{
			int count = -1;
			return GetByTimestampPk(transactionManager, _timestampPk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TimestampPK index.
		/// </summary>
		/// <param name="_timestampPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TimestampPk GetByTimestampPk(System.Byte[] _timestampPk, int start, int pageLength, out int count)
		{
			return GetByTimestampPk(null, _timestampPk, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TimestampPK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_timestampPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.TimestampPk GetByTimestampPk(TransactionManager transactionManager, System.Byte[] _timestampPk, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TimestampPk&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TimestampPk&gt;"/></returns>
		public static TList<TimestampPk> Fill(IDataReader reader, TList<TimestampPk> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.TimestampPk c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TimestampPk")
					.Append("|").Append((System.Byte[])reader[((int)TimestampPkColumn.TimestampPk - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TimestampPk>(
					key.ToString(), // EntityTrackingKey
					"TimestampPk",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.TimestampPk();
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
					c.TimestampPk = (System.Byte[])reader[((int)TimestampPkColumn.TimestampPk - 1)];
					c.SomeText = (reader.IsDBNull(((int)TimestampPkColumn.SomeText - 1)))?null:(System.String)reader[((int)TimestampPkColumn.SomeText - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.TimestampPk entity)
		{
			if (!reader.Read()) return;
			
			entity.TimestampPk = (System.Byte[])reader[((int)TimestampPkColumn.TimestampPk - 1)];
			entity.SomeText = (reader.IsDBNull(((int)TimestampPkColumn.SomeText - 1)))?null:(System.String)reader[((int)TimestampPkColumn.SomeText - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.TimestampPk entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TimestampPk = (System.Byte[])dataRow["TimestampPK"];
			entity.SomeText = Convert.IsDBNull(dataRow["SomeText"]) ? null : (System.String)dataRow["SomeText"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TimestampPk"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TimestampPk Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TimestampPk entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.TimestampPk object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.TimestampPk instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TimestampPk Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TimestampPk entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TimestampPkChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.TimestampPk</c>
	///</summary>
	public enum TimestampPkChildEntityTypes
	{
	}
	
	#endregion TimestampPkChildEntityTypes
	
	#region TimestampPkFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TimestampPkColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TimestampPk"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TimestampPkFilterBuilder : SqlFilterBuilder<TimestampPkColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TimestampPkFilterBuilder class.
		/// </summary>
		public TimestampPkFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TimestampPkFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TimestampPkFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TimestampPkFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TimestampPkFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TimestampPkFilterBuilder
	
	#region TimestampPkParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TimestampPkColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TimestampPk"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TimestampPkParameterBuilder : ParameterizedSqlFilterBuilder<TimestampPkColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TimestampPkParameterBuilder class.
		/// </summary>
		public TimestampPkParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TimestampPkParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TimestampPkParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TimestampPkParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TimestampPkParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TimestampPkParameterBuilder
	
	#region TimestampPkSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TimestampPkColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TimestampPk"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TimestampPkSortBuilder : SqlSortBuilder<TimestampPkColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TimestampPkSqlSortBuilder class.
		/// </summary>
		public TimestampPkSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TimestampPkSortBuilder
	
} // end namespace
