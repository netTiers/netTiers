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
	/// This class is the base class for any <see cref="ScrapReasonProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ScrapReasonProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ScrapReason, Nettiers.AdventureWorks.Entities.ScrapReasonKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ScrapReasonKey key)
		{
			return Delete(transactionManager, key.ScrapReasonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_scrapReasonId">Primary key for ScrapReason records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int16 _scrapReasonId)
		{
			return Delete(null, _scrapReasonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_scrapReasonId">Primary key for ScrapReason records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int16 _scrapReasonId);		
		
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
		public override Nettiers.AdventureWorks.Entities.ScrapReason Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ScrapReasonKey key, int start, int pageLength)
		{
			return GetByScrapReasonId(transactionManager, key.ScrapReasonId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ScrapReason_Name index.
		/// </summary>
		/// <param name="_name">Failure description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ScrapReason_Name index.
		/// </summary>
		/// <param name="_name">Failure description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ScrapReason_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Failure description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ScrapReason_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Failure description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ScrapReason_Name index.
		/// </summary>
		/// <param name="_name">Failure description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ScrapReason_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Failure description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ScrapReason GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ScrapReason_ScrapReasonID index.
		/// </summary>
		/// <param name="_scrapReasonId">Primary key for ScrapReason records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByScrapReasonId(System.Int16 _scrapReasonId)
		{
			int count = -1;
			return GetByScrapReasonId(null,_scrapReasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ScrapReason_ScrapReasonID index.
		/// </summary>
		/// <param name="_scrapReasonId">Primary key for ScrapReason records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByScrapReasonId(System.Int16 _scrapReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetByScrapReasonId(null, _scrapReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ScrapReason_ScrapReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_scrapReasonId">Primary key for ScrapReason records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByScrapReasonId(TransactionManager transactionManager, System.Int16 _scrapReasonId)
		{
			int count = -1;
			return GetByScrapReasonId(transactionManager, _scrapReasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ScrapReason_ScrapReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_scrapReasonId">Primary key for ScrapReason records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByScrapReasonId(TransactionManager transactionManager, System.Int16 _scrapReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetByScrapReasonId(transactionManager, _scrapReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ScrapReason_ScrapReasonID index.
		/// </summary>
		/// <param name="_scrapReasonId">Primary key for ScrapReason records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ScrapReason GetByScrapReasonId(System.Int16 _scrapReasonId, int start, int pageLength, out int count)
		{
			return GetByScrapReasonId(null, _scrapReasonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ScrapReason_ScrapReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_scrapReasonId">Primary key for ScrapReason records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ScrapReason GetByScrapReasonId(TransactionManager transactionManager, System.Int16 _scrapReasonId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ScrapReason&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ScrapReason&gt;"/></returns>
		public static TList<ScrapReason> Fill(IDataReader reader, TList<ScrapReason> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ScrapReason c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ScrapReason")
					.Append("|").Append((System.Int16)reader[((int)ScrapReasonColumn.ScrapReasonId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ScrapReason>(
					key.ToString(), // EntityTrackingKey
					"ScrapReason",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ScrapReason();
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
					c.ScrapReasonId = (System.Int16)reader[((int)ScrapReasonColumn.ScrapReasonId - 1)];
					c.Name = (System.String)reader[((int)ScrapReasonColumn.Name - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ScrapReasonColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ScrapReason entity)
		{
			if (!reader.Read()) return;
			
			entity.ScrapReasonId = (System.Int16)reader[((int)ScrapReasonColumn.ScrapReasonId - 1)];
			entity.Name = (System.String)reader[((int)ScrapReasonColumn.Name - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ScrapReasonColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ScrapReason entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ScrapReasonId = (System.Int16)dataRow["ScrapReasonID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ScrapReason"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ScrapReason Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ScrapReason entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByScrapReasonId methods when available
			
			#region WorkOrderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WorkOrder>|WorkOrderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WorkOrderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WorkOrderCollection = DataRepository.WorkOrderProvider.GetByScrapReasonId(transactionManager, entity.ScrapReasonId);

				if (deep && entity.WorkOrderCollection.Count > 0)
				{
					deepHandles.Add("WorkOrderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WorkOrder>) DataRepository.WorkOrderProvider.DeepLoad,
						new object[] { transactionManager, entity.WorkOrderCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ScrapReason object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ScrapReason instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ScrapReason Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ScrapReason entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<WorkOrder>
				if (CanDeepSave(entity.WorkOrderCollection, "List<WorkOrder>|WorkOrderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WorkOrder child in entity.WorkOrderCollection)
					{
						if(child.ScrapReasonIdSource != null)
						{
							child.ScrapReasonId = child.ScrapReasonIdSource.ScrapReasonId;
						}
						else
						{
							child.ScrapReasonId = entity.ScrapReasonId;
						}

					}

					if (entity.WorkOrderCollection.Count > 0 || entity.WorkOrderCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WorkOrderProvider.Save(transactionManager, entity.WorkOrderCollection);
						
						deepHandles.Add("WorkOrderCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WorkOrder >) DataRepository.WorkOrderProvider.DeepSave,
							new object[] { transactionManager, entity.WorkOrderCollection, deepSaveType, childTypes, innerList }
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
	
	#region ScrapReasonChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ScrapReason</c>
	///</summary>
	public enum ScrapReasonChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ScrapReason</c> as OneToMany for WorkOrderCollection
		///</summary>
		[ChildEntityType(typeof(TList<WorkOrder>))]
		WorkOrderCollection,
	}
	
	#endregion ScrapReasonChildEntityTypes
	
	#region ScrapReasonFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ScrapReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScrapReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScrapReasonFilterBuilder : SqlFilterBuilder<ScrapReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScrapReasonFilterBuilder class.
		/// </summary>
		public ScrapReasonFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScrapReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScrapReasonFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScrapReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScrapReasonFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScrapReasonFilterBuilder
	
	#region ScrapReasonParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ScrapReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScrapReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScrapReasonParameterBuilder : ParameterizedSqlFilterBuilder<ScrapReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScrapReasonParameterBuilder class.
		/// </summary>
		public ScrapReasonParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScrapReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScrapReasonParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScrapReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScrapReasonParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScrapReasonParameterBuilder
	
	#region ScrapReasonSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ScrapReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScrapReason"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ScrapReasonSortBuilder : SqlSortBuilder<ScrapReasonColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScrapReasonSqlSortBuilder class.
		/// </summary>
		public ScrapReasonSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ScrapReasonSortBuilder
	
} // end namespace
