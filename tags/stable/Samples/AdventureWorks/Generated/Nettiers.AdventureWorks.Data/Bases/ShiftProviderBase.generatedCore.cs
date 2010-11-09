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
	/// This class is the base class for any <see cref="ShiftProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ShiftProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Shift, Nettiers.AdventureWorks.Entities.ShiftKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ShiftKey key)
		{
			return Delete(transactionManager, key.ShiftId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_shiftId">Primary key for Shift records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Byte _shiftId)
		{
			return Delete(null, _shiftId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shiftId">Primary key for Shift records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Byte _shiftId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Shift Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ShiftKey key, int start, int pageLength)
		{
			return GetByShiftId(transactionManager, key.ShiftId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Shift_Name index.
		/// </summary>
		/// <param name="_name">Shift description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_Name index.
		/// </summary>
		/// <param name="_name">Shift description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Shift description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Shift description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_Name index.
		/// </summary>
		/// <param name="_name">Shift description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Shift description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Shift GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Shift_StartTime_EndTime index.
		/// </summary>
		/// <param name="_startTime">Shift start time.</param>
		/// <param name="_endTime">Shift end time.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByStartTimeEndTime(System.DateTime _startTime, System.DateTime _endTime)
		{
			int count = -1;
			return GetByStartTimeEndTime(null,_startTime, _endTime, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_StartTime_EndTime index.
		/// </summary>
		/// <param name="_startTime">Shift start time.</param>
		/// <param name="_endTime">Shift end time.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByStartTimeEndTime(System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength)
		{
			int count = -1;
			return GetByStartTimeEndTime(null, _startTime, _endTime, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_StartTime_EndTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startTime">Shift start time.</param>
		/// <param name="_endTime">Shift end time.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByStartTimeEndTime(TransactionManager transactionManager, System.DateTime _startTime, System.DateTime _endTime)
		{
			int count = -1;
			return GetByStartTimeEndTime(transactionManager, _startTime, _endTime, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_StartTime_EndTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startTime">Shift start time.</param>
		/// <param name="_endTime">Shift end time.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByStartTimeEndTime(TransactionManager transactionManager, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength)
		{
			int count = -1;
			return GetByStartTimeEndTime(transactionManager, _startTime, _endTime, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_StartTime_EndTime index.
		/// </summary>
		/// <param name="_startTime">Shift start time.</param>
		/// <param name="_endTime">Shift end time.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByStartTimeEndTime(System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength, out int count)
		{
			return GetByStartTimeEndTime(null, _startTime, _endTime, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Shift_StartTime_EndTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startTime">Shift start time.</param>
		/// <param name="_endTime">Shift end time.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Shift GetByStartTimeEndTime(TransactionManager transactionManager, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Shift_ShiftID index.
		/// </summary>
		/// <param name="_shiftId">Primary key for Shift records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByShiftId(System.Byte _shiftId)
		{
			int count = -1;
			return GetByShiftId(null,_shiftId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Shift_ShiftID index.
		/// </summary>
		/// <param name="_shiftId">Primary key for Shift records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByShiftId(System.Byte _shiftId, int start, int pageLength)
		{
			int count = -1;
			return GetByShiftId(null, _shiftId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Shift_ShiftID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shiftId">Primary key for Shift records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByShiftId(TransactionManager transactionManager, System.Byte _shiftId)
		{
			int count = -1;
			return GetByShiftId(transactionManager, _shiftId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Shift_ShiftID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shiftId">Primary key for Shift records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByShiftId(TransactionManager transactionManager, System.Byte _shiftId, int start, int pageLength)
		{
			int count = -1;
			return GetByShiftId(transactionManager, _shiftId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Shift_ShiftID index.
		/// </summary>
		/// <param name="_shiftId">Primary key for Shift records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Shift GetByShiftId(System.Byte _shiftId, int start, int pageLength, out int count)
		{
			return GetByShiftId(null, _shiftId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Shift_ShiftID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shiftId">Primary key for Shift records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Shift GetByShiftId(TransactionManager transactionManager, System.Byte _shiftId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Shift&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Shift&gt;"/></returns>
		public static TList<Shift> Fill(IDataReader reader, TList<Shift> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Shift c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Shift")
					.Append("|").Append((System.Byte)reader[((int)ShiftColumn.ShiftId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Shift>(
					key.ToString(), // EntityTrackingKey
					"Shift",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Shift();
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
					c.ShiftId = (System.Byte)reader[((int)ShiftColumn.ShiftId - 1)];
					c.Name = (System.String)reader[((int)ShiftColumn.Name - 1)];
					c.StartTime = (System.DateTime)reader[((int)ShiftColumn.StartTime - 1)];
					c.EndTime = (System.DateTime)reader[((int)ShiftColumn.EndTime - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ShiftColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Shift"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Shift entity)
		{
			if (!reader.Read()) return;
			
			entity.ShiftId = (System.Byte)reader[((int)ShiftColumn.ShiftId - 1)];
			entity.Name = (System.String)reader[((int)ShiftColumn.Name - 1)];
			entity.StartTime = (System.DateTime)reader[((int)ShiftColumn.StartTime - 1)];
			entity.EndTime = (System.DateTime)reader[((int)ShiftColumn.EndTime - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ShiftColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Shift"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Shift"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Shift entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShiftId = (System.Byte)dataRow["ShiftID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.StartTime = (System.DateTime)dataRow["StartTime"];
			entity.EndTime = (System.DateTime)dataRow["EndTime"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Shift"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Shift Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Shift entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByShiftId methods when available
			
			#region EmployeeDepartmentHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeDepartmentHistory>|EmployeeDepartmentHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeDepartmentHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeDepartmentHistoryCollection = DataRepository.EmployeeDepartmentHistoryProvider.GetByShiftId(transactionManager, entity.ShiftId);

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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Shift object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Shift instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Shift Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Shift entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.ShiftIdSource != null)
						{
							child.ShiftId = child.ShiftIdSource.ShiftId;
						}
						else
						{
							child.ShiftId = entity.ShiftId;
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
	
	#region ShiftChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Shift</c>
	///</summary>
	public enum ShiftChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Shift</c> as OneToMany for EmployeeDepartmentHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeDepartmentHistory>))]
		EmployeeDepartmentHistoryCollection,
	}
	
	#endregion ShiftChildEntityTypes
	
	#region ShiftFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ShiftColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shift"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShiftFilterBuilder : SqlFilterBuilder<ShiftColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShiftFilterBuilder class.
		/// </summary>
		public ShiftFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShiftFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShiftFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShiftFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShiftFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShiftFilterBuilder
	
	#region ShiftParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ShiftColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shift"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShiftParameterBuilder : ParameterizedSqlFilterBuilder<ShiftColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShiftParameterBuilder class.
		/// </summary>
		public ShiftParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShiftParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShiftParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShiftParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShiftParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShiftParameterBuilder
	
	#region ShiftSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ShiftColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shift"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ShiftSortBuilder : SqlSortBuilder<ShiftColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShiftSqlSortBuilder class.
		/// </summary>
		public ShiftSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ShiftSortBuilder
	
} // end namespace
