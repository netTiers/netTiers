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
	/// This class is the base class for any <see cref="NullFkeyChildProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class NullFkeyChildProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.NullFkeyChild, Nettiers.AdventureWorks.Entities.NullFkeyChildKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.NullFkeyChildKey key)
		{
			return Delete(transactionManager, key.NullFkeyChildId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_nullFkeyChildId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _nullFkeyChildId)
		{
			return Delete(null, _nullFkeyChildId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyChildId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _nullFkeyChildId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_NullFKeyChild_NullFKeyParent key.
		///		FK_NullFKeyChild_NullFKeyParent Description: 
		/// </summary>
		/// <param name="_nullFkeyParentId"></param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.NullFkeyChild objects.</returns>
		public TList<NullFkeyChild> GetByNullFkeyParentId(System.Int32? _nullFkeyParentId)
		{
			int count = -1;
			return GetByNullFkeyParentId(_nullFkeyParentId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_NullFKeyChild_NullFKeyParent key.
		///		FK_NullFKeyChild_NullFKeyParent Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyParentId"></param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.NullFkeyChild objects.</returns>
		/// <remarks></remarks>
		public TList<NullFkeyChild> GetByNullFkeyParentId(TransactionManager transactionManager, System.Int32? _nullFkeyParentId)
		{
			int count = -1;
			return GetByNullFkeyParentId(transactionManager, _nullFkeyParentId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_NullFKeyChild_NullFKeyParent key.
		///		FK_NullFKeyChild_NullFKeyParent Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyParentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.NullFkeyChild objects.</returns>
		public TList<NullFkeyChild> GetByNullFkeyParentId(TransactionManager transactionManager, System.Int32? _nullFkeyParentId, int start, int pageLength)
		{
			int count = -1;
			return GetByNullFkeyParentId(transactionManager, _nullFkeyParentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_NullFKeyChild_NullFKeyParent key.
		///		fkNullFkeyChildNullFkeyParent Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_nullFkeyParentId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.NullFkeyChild objects.</returns>
		public TList<NullFkeyChild> GetByNullFkeyParentId(System.Int32? _nullFkeyParentId, int start, int pageLength)
		{
			int count =  -1;
			return GetByNullFkeyParentId(null, _nullFkeyParentId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_NullFKeyChild_NullFKeyParent key.
		///		fkNullFkeyChildNullFkeyParent Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_nullFkeyParentId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.NullFkeyChild objects.</returns>
		public TList<NullFkeyChild> GetByNullFkeyParentId(System.Int32? _nullFkeyParentId, int start, int pageLength,out int count)
		{
			return GetByNullFkeyParentId(null, _nullFkeyParentId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_NullFKeyChild_NullFKeyParent key.
		///		FK_NullFKeyChild_NullFKeyParent Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyParentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.NullFkeyChild objects.</returns>
		public abstract TList<NullFkeyChild> GetByNullFkeyParentId(TransactionManager transactionManager, System.Int32? _nullFkeyParentId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.NullFkeyChild Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.NullFkeyChildKey key, int start, int pageLength)
		{
			return GetByNullFkeyChildId(transactionManager, key.NullFkeyChildId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_NullFKeyChild index.
		/// </summary>
		/// <param name="_nullFkeyChildId"></param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyChild GetByNullFkeyChildId(System.Int32 _nullFkeyChildId)
		{
			int count = -1;
			return GetByNullFkeyChildId(null,_nullFkeyChildId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullFKeyChild index.
		/// </summary>
		/// <param name="_nullFkeyChildId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyChild GetByNullFkeyChildId(System.Int32 _nullFkeyChildId, int start, int pageLength)
		{
			int count = -1;
			return GetByNullFkeyChildId(null, _nullFkeyChildId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullFKeyChild index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyChildId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyChild GetByNullFkeyChildId(TransactionManager transactionManager, System.Int32 _nullFkeyChildId)
		{
			int count = -1;
			return GetByNullFkeyChildId(transactionManager, _nullFkeyChildId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullFKeyChild index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyChildId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyChild GetByNullFkeyChildId(TransactionManager transactionManager, System.Int32 _nullFkeyChildId, int start, int pageLength)
		{
			int count = -1;
			return GetByNullFkeyChildId(transactionManager, _nullFkeyChildId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullFKeyChild index.
		/// </summary>
		/// <param name="_nullFkeyChildId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.NullFkeyChild GetByNullFkeyChildId(System.Int32 _nullFkeyChildId, int start, int pageLength, out int count)
		{
			return GetByNullFkeyChildId(null, _nullFkeyChildId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_NullFKeyChild index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nullFkeyChildId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.NullFkeyChild GetByNullFkeyChildId(TransactionManager transactionManager, System.Int32 _nullFkeyChildId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;NullFkeyChild&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;NullFkeyChild&gt;"/></returns>
		public static TList<NullFkeyChild> Fill(IDataReader reader, TList<NullFkeyChild> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.NullFkeyChild c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("NullFkeyChild")
					.Append("|").Append((System.Int32)reader[((int)NullFkeyChildColumn.NullFkeyChildId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<NullFkeyChild>(
					key.ToString(), // EntityTrackingKey
					"NullFkeyChild",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.NullFkeyChild();
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
					c.NullFkeyChildId = (System.Int32)reader[((int)NullFkeyChildColumn.NullFkeyChildId - 1)];
					c.OriginalNullFkeyChildId = c.NullFkeyChildId;
					c.NullFkeyParentId = (reader.IsDBNull(((int)NullFkeyChildColumn.NullFkeyParentId - 1)))?null:(System.Int32?)reader[((int)NullFkeyChildColumn.NullFkeyParentId - 1)];
					c.SomeText = (reader.IsDBNull(((int)NullFkeyChildColumn.SomeText - 1)))?null:(System.String)reader[((int)NullFkeyChildColumn.SomeText - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.NullFkeyChild entity)
		{
			if (!reader.Read()) return;
			
			entity.NullFkeyChildId = (System.Int32)reader[((int)NullFkeyChildColumn.NullFkeyChildId - 1)];
			entity.OriginalNullFkeyChildId = (System.Int32)reader["NullFKeyChildID"];
			entity.NullFkeyParentId = (reader.IsDBNull(((int)NullFkeyChildColumn.NullFkeyParentId - 1)))?null:(System.Int32?)reader[((int)NullFkeyChildColumn.NullFkeyParentId - 1)];
			entity.SomeText = (reader.IsDBNull(((int)NullFkeyChildColumn.SomeText - 1)))?null:(System.String)reader[((int)NullFkeyChildColumn.SomeText - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.NullFkeyChild entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NullFkeyChildId = (System.Int32)dataRow["NullFKeyChildID"];
			entity.OriginalNullFkeyChildId = (System.Int32)dataRow["NullFKeyChildID"];
			entity.NullFkeyParentId = Convert.IsDBNull(dataRow["NullFKeyParentID"]) ? null : (System.Int32?)dataRow["NullFKeyParentID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.NullFkeyChild"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.NullFkeyChild Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.NullFkeyChild entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region NullFkeyParentIdSource	
			if (CanDeepLoad(entity, "NullFkeyParent|NullFkeyParentIdSource", deepLoadType, innerList) 
				&& entity.NullFkeyParentIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.NullFkeyParentId ?? (int)0);
				NullFkeyParent tmpEntity = EntityManager.LocateEntity<NullFkeyParent>(EntityLocator.ConstructKeyFromPkItems(typeof(NullFkeyParent), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.NullFkeyParentIdSource = tmpEntity;
				else
					entity.NullFkeyParentIdSource = DataRepository.NullFkeyParentProvider.GetByNullFkeyParentId(transactionManager, (entity.NullFkeyParentId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NullFkeyParentIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.NullFkeyParentIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.NullFkeyParentProvider.DeepLoad(transactionManager, entity.NullFkeyParentIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion NullFkeyParentIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.NullFkeyChild object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.NullFkeyChild instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.NullFkeyChild Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.NullFkeyChild entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region NullFkeyParentIdSource
			if (CanDeepSave(entity, "NullFkeyParent|NullFkeyParentIdSource", deepSaveType, innerList) 
				&& entity.NullFkeyParentIdSource != null)
			{
				DataRepository.NullFkeyParentProvider.Save(transactionManager, entity.NullFkeyParentIdSource);
				entity.NullFkeyParentId = entity.NullFkeyParentIdSource.NullFkeyParentId;
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
	
	#region NullFkeyChildChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.NullFkeyChild</c>
	///</summary>
	public enum NullFkeyChildChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>NullFkeyParent</c> at NullFkeyParentIdSource
		///</summary>
		[ChildEntityType(typeof(NullFkeyParent))]
		NullFkeyParent,
		}
	
	#endregion NullFkeyChildChildEntityTypes
	
	#region NullFkeyChildFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;NullFkeyChildColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyChild"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyChildFilterBuilder : SqlFilterBuilder<NullFkeyChildColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildFilterBuilder class.
		/// </summary>
		public NullFkeyChildFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NullFkeyChildFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NullFkeyChildFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NullFkeyChildFilterBuilder
	
	#region NullFkeyChildParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;NullFkeyChildColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyChild"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyChildParameterBuilder : ParameterizedSqlFilterBuilder<NullFkeyChildColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildParameterBuilder class.
		/// </summary>
		public NullFkeyChildParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NullFkeyChildParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NullFkeyChildParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NullFkeyChildParameterBuilder
	
	#region NullFkeyChildSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;NullFkeyChildColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyChild"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class NullFkeyChildSortBuilder : SqlSortBuilder<NullFkeyChildColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildSqlSortBuilder class.
		/// </summary>
		public NullFkeyChildSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion NullFkeyChildSortBuilder
	
} // end namespace
