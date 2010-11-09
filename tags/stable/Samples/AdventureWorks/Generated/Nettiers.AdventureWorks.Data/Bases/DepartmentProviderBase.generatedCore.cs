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
	/// This class is the base class for any <see cref="DepartmentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DepartmentProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Department, Nettiers.AdventureWorks.Entities.DepartmentKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.DepartmentKey key)
		{
			return Delete(transactionManager, key.DepartmentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_departmentId">Primary key for Department records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int16 _departmentId)
		{
			return Delete(null, _departmentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId">Primary key for Department records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int16 _departmentId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Department Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.DepartmentKey key, int start, int pageLength)
		{
			return GetByDepartmentId(transactionManager, key.DepartmentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Department_Name index.
		/// </summary>
		/// <param name="_name">Name of the department.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Department_Name index.
		/// </summary>
		/// <param name="_name">Name of the department.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Department_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Name of the department.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Department_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Name of the department.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Department_Name index.
		/// </summary>
		/// <param name="_name">Name of the department.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Department_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Name of the department.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Department GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Department_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId">Primary key for Department records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByDepartmentId(System.Int16 _departmentId)
		{
			int count = -1;
			return GetByDepartmentId(null,_departmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Department_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId">Primary key for Department records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByDepartmentId(System.Int16 _departmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentId(null, _departmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Department_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId">Primary key for Department records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByDepartmentId(TransactionManager transactionManager, System.Int16 _departmentId)
		{
			int count = -1;
			return GetByDepartmentId(transactionManager, _departmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Department_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId">Primary key for Department records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByDepartmentId(TransactionManager transactionManager, System.Int16 _departmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentId(transactionManager, _departmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Department_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId">Primary key for Department records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Department GetByDepartmentId(System.Int16 _departmentId, int start, int pageLength, out int count)
		{
			return GetByDepartmentId(null, _departmentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Department_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId">Primary key for Department records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Department"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Department GetByDepartmentId(TransactionManager transactionManager, System.Int16 _departmentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Department&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Department&gt;"/></returns>
		public static TList<Department> Fill(IDataReader reader, TList<Department> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Department c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Department")
					.Append("|").Append((System.Int16)reader[((int)DepartmentColumn.DepartmentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Department>(
					key.ToString(), // EntityTrackingKey
					"Department",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Department();
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
					c.DepartmentId = (System.Int16)reader[((int)DepartmentColumn.DepartmentId - 1)];
					c.Name = (System.String)reader[((int)DepartmentColumn.Name - 1)];
					c.GroupName = (System.String)reader[((int)DepartmentColumn.GroupName - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)DepartmentColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Department"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Department"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Department entity)
		{
			if (!reader.Read()) return;
			
			entity.DepartmentId = (System.Int16)reader[((int)DepartmentColumn.DepartmentId - 1)];
			entity.Name = (System.String)reader[((int)DepartmentColumn.Name - 1)];
			entity.GroupName = (System.String)reader[((int)DepartmentColumn.GroupName - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)DepartmentColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Department"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Department"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Department entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DepartmentId = (System.Int16)dataRow["DepartmentID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.GroupName = (System.String)dataRow["GroupName"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Department"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Department Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Department entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDepartmentId methods when available
			
			#region EmployeeDepartmentHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeDepartmentHistory>|EmployeeDepartmentHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeDepartmentHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeDepartmentHistoryCollection = DataRepository.EmployeeDepartmentHistoryProvider.GetByDepartmentId(transactionManager, entity.DepartmentId);

				if (deep && entity.EmployeeDepartmentHistoryCollection.Count > 0)
				{
					deepHandles.Add("EmployeeDepartmentHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeDepartmentHistory>) DataRepository.EmployeeDepartmentHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeDepartmentHistoryCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Department object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Department instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Department Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Department entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<EmployeeDepartmentHistory>
				if (CanDeepSave(entity.EmployeeDepartmentHistoryCollection, "List<EmployeeDepartmentHistory>|EmployeeDepartmentHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeeDepartmentHistory child in entity.EmployeeDepartmentHistoryCollection)
					{
						if(child.DepartmentIdSource != null)
						{
							child.DepartmentId = child.DepartmentIdSource.DepartmentId;
						}
						else
						{
							child.DepartmentId = entity.DepartmentId;
						}

					}

					if (entity.EmployeeDepartmentHistoryCollection.Count > 0 || entity.EmployeeDepartmentHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeeDepartmentHistoryProvider.Save(transactionManager, entity.EmployeeDepartmentHistoryCollection);
						
						deepHandles.Add("EmployeeDepartmentHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmployeeDepartmentHistory >) DataRepository.EmployeeDepartmentHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeeDepartmentHistoryCollection, deepSaveType, childTypes, innerList }
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
	
	#region DepartmentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Department</c>
	///</summary>
	public enum DepartmentChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Department</c> as OneToMany for EmployeeDepartmentHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeDepartmentHistory>))]
		EmployeeDepartmentHistoryCollection,
	}
	
	#endregion DepartmentChildEntityTypes
	
	#region DepartmentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DepartmentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentFilterBuilder : SqlFilterBuilder<DepartmentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentFilterBuilder class.
		/// </summary>
		public DepartmentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentFilterBuilder
	
	#region DepartmentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DepartmentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentParameterBuilder : ParameterizedSqlFilterBuilder<DepartmentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentParameterBuilder class.
		/// </summary>
		public DepartmentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentParameterBuilder
	
	#region DepartmentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DepartmentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DepartmentSortBuilder : SqlSortBuilder<DepartmentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentSqlSortBuilder class.
		/// </summary>
		public DepartmentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DepartmentSortBuilder
	
} // end namespace
