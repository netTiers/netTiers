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
	/// This class is the base class for any <see cref="JobCandidateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobCandidateProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.JobCandidate, Nettiers.AdventureWorks.Entities.JobCandidateKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.JobCandidateKey key)
		{
			return Delete(transactionManager, key.JobCandidateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobCandidateId">Primary key for JobCandidate records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobCandidateId)
		{
			return Delete(null, _jobCandidateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCandidateId">Primary key for JobCandidate records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobCandidateId);		
		
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
		public override Nettiers.AdventureWorks.Entities.JobCandidate Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.JobCandidateKey key, int start, int pageLength)
		{
			return GetByJobCandidateId(transactionManager, key.JobCandidateId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobCandidate_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Employee identification number if applicant was hired. Foreign key to Employee.EmployeeID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobCandidate&gt;"/> class.</returns>
		public TList<JobCandidate> GetByEmployeeId(System.Int32? _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(null,_employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobCandidate_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Employee identification number if applicant was hired. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobCandidate&gt;"/> class.</returns>
		public TList<JobCandidate> GetByEmployeeId(System.Int32? _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobCandidate_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number if applicant was hired. Foreign key to Employee.EmployeeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobCandidate&gt;"/> class.</returns>
		public TList<JobCandidate> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobCandidate_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number if applicant was hired. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobCandidate&gt;"/> class.</returns>
		public TList<JobCandidate> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobCandidate_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Employee identification number if applicant was hired. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobCandidate&gt;"/> class.</returns>
		public TList<JobCandidate> GetByEmployeeId(System.Int32? _employeeId, int start, int pageLength, out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobCandidate_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number if applicant was hired. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobCandidate&gt;"/> class.</returns>
		public abstract TList<JobCandidate> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_JobCandidate_JobCandidateID index.
		/// </summary>
		/// <param name="_jobCandidateId">Primary key for JobCandidate records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.JobCandidate GetByJobCandidateId(System.Int32 _jobCandidateId)
		{
			int count = -1;
			return GetByJobCandidateId(null,_jobCandidateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_JobCandidate_JobCandidateID index.
		/// </summary>
		/// <param name="_jobCandidateId">Primary key for JobCandidate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.JobCandidate GetByJobCandidateId(System.Int32 _jobCandidateId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobCandidateId(null, _jobCandidateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_JobCandidate_JobCandidateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCandidateId">Primary key for JobCandidate records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.JobCandidate GetByJobCandidateId(TransactionManager transactionManager, System.Int32 _jobCandidateId)
		{
			int count = -1;
			return GetByJobCandidateId(transactionManager, _jobCandidateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_JobCandidate_JobCandidateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCandidateId">Primary key for JobCandidate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.JobCandidate GetByJobCandidateId(TransactionManager transactionManager, System.Int32 _jobCandidateId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobCandidateId(transactionManager, _jobCandidateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_JobCandidate_JobCandidateID index.
		/// </summary>
		/// <param name="_jobCandidateId">Primary key for JobCandidate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.JobCandidate GetByJobCandidateId(System.Int32 _jobCandidateId, int start, int pageLength, out int count)
		{
			return GetByJobCandidateId(null, _jobCandidateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_JobCandidate_JobCandidateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCandidateId">Primary key for JobCandidate records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.JobCandidate GetByJobCandidateId(TransactionManager transactionManager, System.Int32 _jobCandidateId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobCandidate&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobCandidate&gt;"/></returns>
		public static TList<JobCandidate> Fill(IDataReader reader, TList<JobCandidate> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.JobCandidate c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobCandidate")
					.Append("|").Append((System.Int32)reader[((int)JobCandidateColumn.JobCandidateId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobCandidate>(
					key.ToString(), // EntityTrackingKey
					"JobCandidate",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.JobCandidate();
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
					c.JobCandidateId = (System.Int32)reader[((int)JobCandidateColumn.JobCandidateId - 1)];
					c.EmployeeId = (reader.IsDBNull(((int)JobCandidateColumn.EmployeeId - 1)))?null:(System.Int32?)reader[((int)JobCandidateColumn.EmployeeId - 1)];
					c.Resume = (reader.IsDBNull(((int)JobCandidateColumn.Resume - 1)))?null:(string)reader[((int)JobCandidateColumn.Resume - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)JobCandidateColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.JobCandidate entity)
		{
			if (!reader.Read()) return;
			
			entity.JobCandidateId = (System.Int32)reader[((int)JobCandidateColumn.JobCandidateId - 1)];
			entity.EmployeeId = (reader.IsDBNull(((int)JobCandidateColumn.EmployeeId - 1)))?null:(System.Int32?)reader[((int)JobCandidateColumn.EmployeeId - 1)];
			entity.Resume = (reader.IsDBNull(((int)JobCandidateColumn.Resume - 1)))?null:(string)reader[((int)JobCandidateColumn.Resume - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)JobCandidateColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.JobCandidate entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobCandidateId = (System.Int32)dataRow["JobCandidateID"];
			entity.EmployeeId = Convert.IsDBNull(dataRow["EmployeeID"]) ? null : (System.Int32?)dataRow["EmployeeID"];
			entity.Resume = Convert.IsDBNull(dataRow["Resume"]) ? null : (string)dataRow["Resume"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.JobCandidate"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.JobCandidate Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.JobCandidate entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region EmployeeIdSource	
			if (CanDeepLoad(entity, "Employee|EmployeeIdSource", deepLoadType, innerList) 
				&& entity.EmployeeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.EmployeeId ?? (int)0);
				Employee tmpEntity = EntityManager.LocateEntity<Employee>(EntityLocator.ConstructKeyFromPkItems(typeof(Employee), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmployeeIdSource = tmpEntity;
				else
					entity.EmployeeIdSource = DataRepository.EmployeeProvider.GetByEmployeeId(transactionManager, (entity.EmployeeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmployeeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeeProvider.DeepLoad(transactionManager, entity.EmployeeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EmployeeIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.JobCandidate object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.JobCandidate instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.JobCandidate Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.JobCandidate entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region EmployeeIdSource
			if (CanDeepSave(entity, "Employee|EmployeeIdSource", deepSaveType, innerList) 
				&& entity.EmployeeIdSource != null)
			{
				DataRepository.EmployeeProvider.Save(transactionManager, entity.EmployeeIdSource);
				entity.EmployeeId = entity.EmployeeIdSource.EmployeeId;
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
	
	#region JobCandidateChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.JobCandidate</c>
	///</summary>
	public enum JobCandidateChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
		}
	
	#endregion JobCandidateChildEntityTypes
	
	#region JobCandidateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobCandidateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCandidateFilterBuilder : SqlFilterBuilder<JobCandidateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCandidateFilterBuilder class.
		/// </summary>
		public JobCandidateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCandidateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCandidateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCandidateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCandidateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCandidateFilterBuilder
	
	#region JobCandidateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobCandidateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCandidateParameterBuilder : ParameterizedSqlFilterBuilder<JobCandidateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCandidateParameterBuilder class.
		/// </summary>
		public JobCandidateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCandidateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCandidateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCandidateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCandidateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCandidateParameterBuilder
	
	#region JobCandidateSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobCandidateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCandidate"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobCandidateSortBuilder : SqlSortBuilder<JobCandidateColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCandidateSqlSortBuilder class.
		/// </summary>
		public JobCandidateSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobCandidateSortBuilder
	
} // end namespace
