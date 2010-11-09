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
	/// This class is the base class for any <see cref="NullFkeyParentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class NullFkeyParentProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.NullFkeyParent, Nettiers.AdventureWorks.Entities.NullFkeyParentKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.NullFkeyParentKey key)
		{
			return Delete(transactionManager, key.NullFkeyParentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_nullFkeyParentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _nullFkeyParentId)
		{
			return Delete(null, _nullFkeyParentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyParentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _nullFkeyParentId);		
		
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
		public override Nettiers.AdventureWorks.Entities.NullFkeyParent Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.NullFkeyParentKey key, int start, int pageLength)
		{
			return GetByNullFkeyParentId(transactionManager, key.NullFkeyParentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_NullKeyParent index.
		/// </summary>
		/// <param name="_nullFkeyParentId"></param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyParent GetByNullFkeyParentId(System.Int32 _nullFkeyParentId)
		{
			int count = -1;
			return GetByNullFkeyParentId(null,_nullFkeyParentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullKeyParent index.
		/// </summary>
		/// <param name="_nullFkeyParentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyParent GetByNullFkeyParentId(System.Int32 _nullFkeyParentId, int start, int pageLength)
		{
			int count = -1;
			return GetByNullFkeyParentId(null, _nullFkeyParentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullKeyParent index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyParentId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyParent GetByNullFkeyParentId(TransactionManager transactionManager, System.Int32 _nullFkeyParentId)
		{
			int count = -1;
			return GetByNullFkeyParentId(transactionManager, _nullFkeyParentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullKeyParent index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyParentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyParent GetByNullFkeyParentId(TransactionManager transactionManager, System.Int32 _nullFkeyParentId, int start, int pageLength)
		{
			int count = -1;
			return GetByNullFkeyParentId(transactionManager, _nullFkeyParentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullKeyParent index.
		/// </summary>
		/// <param name="_nullFkeyParentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyParent GetByNullFkeyParentId(System.Int32 _nullFkeyParentId, int start, int pageLength, out int count)
		{
			return GetByNullFkeyParentId(null, _nullFkeyParentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullKeyParent index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyParentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.NullFkeyParent GetByNullFkeyParentId(TransactionManager transactionManager, System.Int32 _nullFkeyParentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;NullFkeyParent&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;NullFkeyParent&gt;"/></returns>
		public static TList<NullFkeyParent> Fill(IDataReader reader, TList<NullFkeyParent> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.NullFkeyParent c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("NullFkeyParent")
					.Append("|").Append((System.Int32)reader[((int)NullFkeyParentColumn.NullFkeyParentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<NullFkeyParent>(
					key.ToString(), // EntityTrackingKey
					"NullFkeyParent",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.NullFkeyParent();
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
					c.NullFkeyParentId = (System.Int32)reader[((int)NullFkeyParentColumn.NullFkeyParentId - 1)];
					c.OriginalNullFkeyParentId = c.NullFkeyParentId;
					c.SomeText = (reader.IsDBNull(((int)NullFkeyParentColumn.SomeText - 1)))?null:(System.String)reader[((int)NullFkeyParentColumn.SomeText - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.NullFkeyParent entity)
		{
			if (!reader.Read()) return;
			
			entity.NullFkeyParentId = (System.Int32)reader[((int)NullFkeyParentColumn.NullFkeyParentId - 1)];
			entity.OriginalNullFkeyParentId = (System.Int32)reader["NullFKeyParentID"];
			entity.SomeText = (reader.IsDBNull(((int)NullFkeyParentColumn.SomeText - 1)))?null:(System.String)reader[((int)NullFkeyParentColumn.SomeText - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.NullFkeyParent entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NullFkeyParentId = (System.Int32)dataRow["NullFKeyParentID"];
			entity.OriginalNullFkeyParentId = (System.Int32)dataRow["NullFKeyParentID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.NullFkeyParent"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.NullFkeyParent Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.NullFkeyParent entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByNullFkeyParentId methods when available
			
			#region NullFkeyChildCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<NullFkeyChild>|NullFkeyChildCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NullFkeyChildCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.NullFkeyChildCollection = DataRepository.NullFkeyChildProvider.GetByNullFkeyParentId(transactionManager, entity.NullFkeyParentId);

				if (deep && entity.NullFkeyChildCollection.Count > 0)
				{
					deepHandles.Add("NullFkeyChildCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<NullFkeyChild>) DataRepository.NullFkeyChildProvider.DeepLoad,
						new object[] { transactionManager, entity.NullFkeyChildCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.NullFkeyParent object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.NullFkeyParent instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.NullFkeyParent Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.NullFkeyParent entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<NullFkeyChild>
				if (CanDeepSave(entity.NullFkeyChildCollection, "List<NullFkeyChild>|NullFkeyChildCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(NullFkeyChild child in entity.NullFkeyChildCollection)
					{
						if(child.NullFkeyParentIdSource != null)
						{
							child.NullFkeyParentId = child.NullFkeyParentIdSource.NullFkeyParentId;
						}
						else
						{
							child.NullFkeyParentId = entity.NullFkeyParentId;
						}

					}

					if (entity.NullFkeyChildCollection.Count > 0 || entity.NullFkeyChildCollection.DeletedItems.Count > 0)
					{
						//DataRepository.NullFkeyChildProvider.Save(transactionManager, entity.NullFkeyChildCollection);
						
						deepHandles.Add("NullFkeyChildCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< NullFkeyChild >) DataRepository.NullFkeyChildProvider.DeepSave,
							new object[] { transactionManager, entity.NullFkeyChildCollection, deepSaveType, childTypes, innerList }
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
	
	#region NullFkeyParentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.NullFkeyParent</c>
	///</summary>
	public enum NullFkeyParentChildEntityTypes
	{

		///<summary>
		/// Collection of <c>NullFkeyParent</c> as OneToMany for NullFkeyChildCollection
		///</summary>
		[ChildEntityType(typeof(TList<NullFkeyChild>))]
		NullFkeyChildCollection,
	}
	
	#endregion NullFkeyParentChildEntityTypes
	
	#region NullFkeyParentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;NullFkeyParentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyParent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyParentFilterBuilder : SqlFilterBuilder<NullFkeyParentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentFilterBuilder class.
		/// </summary>
		public NullFkeyParentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NullFkeyParentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NullFkeyParentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NullFkeyParentFilterBuilder
	
	#region NullFkeyParentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;NullFkeyParentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyParent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyParentParameterBuilder : ParameterizedSqlFilterBuilder<NullFkeyParentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentParameterBuilder class.
		/// </summary>
		public NullFkeyParentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NullFkeyParentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NullFkeyParentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NullFkeyParentParameterBuilder
	
	#region NullFkeyParentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;NullFkeyParentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyParent"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class NullFkeyParentSortBuilder : SqlSortBuilder<NullFkeyParentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentSqlSortBuilder class.
		/// </summary>
		public NullFkeyParentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion NullFkeyParentSortBuilder
	
} // end namespace
