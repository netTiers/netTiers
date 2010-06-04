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
	/// This class is the base class for any <see cref="SalesReasonProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesReasonProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesReason, Nettiers.AdventureWorks.Entities.SalesReasonKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetBySalesOrderIdFromSalesOrderHeaderSalesReason
		
		/// <summary>
		///		Gets SalesReason objects from the datasource by SalesOrderID in the
		///		SalesOrderHeaderSalesReason table. Table SalesReason is related to table SalesOrderHeader
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <returns>Returns a typed collection of SalesReason objects.</returns>
		public TList<SalesReason> GetBySalesOrderIdFromSalesOrderHeaderSalesReason(System.Int32 _salesOrderId)
		{
			int count = -1;
			return GetBySalesOrderIdFromSalesOrderHeaderSalesReason(null,_salesOrderId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.SalesReason objects from the datasource by SalesOrderID in the
		///		SalesOrderHeaderSalesReason table. Table SalesReason is related to table SalesOrderHeader
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of SalesReason objects.</returns>
		public TList<SalesReason> GetBySalesOrderIdFromSalesOrderHeaderSalesReason(System.Int32 _salesOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderIdFromSalesOrderHeaderSalesReason(null, _salesOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets SalesReason objects from the datasource by SalesOrderID in the
		///		SalesOrderHeaderSalesReason table. Table SalesReason is related to table SalesOrderHeader
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SalesReason objects.</returns>
		public TList<SalesReason> GetBySalesOrderIdFromSalesOrderHeaderSalesReason(TransactionManager transactionManager, System.Int32 _salesOrderId)
		{
			int count = -1;
			return GetBySalesOrderIdFromSalesOrderHeaderSalesReason(transactionManager, _salesOrderId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets SalesReason objects from the datasource by SalesOrderID in the
		///		SalesOrderHeaderSalesReason table. Table SalesReason is related to table SalesOrderHeader
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SalesReason objects.</returns>
		public TList<SalesReason> GetBySalesOrderIdFromSalesOrderHeaderSalesReason(TransactionManager transactionManager, System.Int32 _salesOrderId,int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderIdFromSalesOrderHeaderSalesReason(transactionManager, _salesOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets SalesReason objects from the datasource by SalesOrderID in the
		///		SalesOrderHeaderSalesReason table. Table SalesReason is related to table SalesOrderHeader
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SalesReason objects.</returns>
		public TList<SalesReason> GetBySalesOrderIdFromSalesOrderHeaderSalesReason(System.Int32 _salesOrderId,int start, int pageLength, out int count)
		{
			
			return GetBySalesOrderIdFromSalesOrderHeaderSalesReason(null, _salesOrderId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets SalesReason objects from the datasource by SalesOrderID in the
		///		SalesOrderHeaderSalesReason table. Table SalesReason is related to table SalesOrderHeader
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of SalesReason objects.</returns>
		public abstract TList<SalesReason> GetBySalesOrderIdFromSalesOrderHeaderSalesReason(TransactionManager transactionManager,System.Int32 _salesOrderId, int start, int pageLength, out int count);
		
		#endregion GetBySalesOrderIdFromSalesOrderHeaderSalesReason
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesReasonKey key)
		{
			return Delete(transactionManager, key.SalesReasonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salesReasonId">Primary key for SalesReason records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salesReasonId)
		{
			return Delete(null, _salesReasonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key for SalesReason records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salesReasonId);		
		
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
		public override Nettiers.AdventureWorks.Entities.SalesReason Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesReasonKey key, int start, int pageLength)
		{
			return GetBySalesReasonId(transactionManager, key.SalesReasonId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesReason_SalesReasonID index.
		/// </summary>
		/// <param name="_salesReasonId">Primary key for SalesReason records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesReason GetBySalesReasonId(System.Int32 _salesReasonId)
		{
			int count = -1;
			return GetBySalesReasonId(null,_salesReasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesReason_SalesReasonID index.
		/// </summary>
		/// <param name="_salesReasonId">Primary key for SalesReason records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesReason GetBySalesReasonId(System.Int32 _salesReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesReasonId(null, _salesReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesReason_SalesReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key for SalesReason records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesReason GetBySalesReasonId(TransactionManager transactionManager, System.Int32 _salesReasonId)
		{
			int count = -1;
			return GetBySalesReasonId(transactionManager, _salesReasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesReason_SalesReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key for SalesReason records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesReason GetBySalesReasonId(TransactionManager transactionManager, System.Int32 _salesReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesReasonId(transactionManager, _salesReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesReason_SalesReasonID index.
		/// </summary>
		/// <param name="_salesReasonId">Primary key for SalesReason records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesReason GetBySalesReasonId(System.Int32 _salesReasonId, int start, int pageLength, out int count)
		{
			return GetBySalesReasonId(null, _salesReasonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesReason_SalesReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key for SalesReason records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesReason GetBySalesReasonId(TransactionManager transactionManager, System.Int32 _salesReasonId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesReason&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesReason&gt;"/></returns>
		public static TList<SalesReason> Fill(IDataReader reader, TList<SalesReason> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SalesReason c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesReason")
					.Append("|").Append((System.Int32)reader[((int)SalesReasonColumn.SalesReasonId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesReason>(
					key.ToString(), // EntityTrackingKey
					"SalesReason",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesReason();
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
					c.SalesReasonId = (System.Int32)reader[((int)SalesReasonColumn.SalesReasonId - 1)];
					c.Name = (System.String)reader[((int)SalesReasonColumn.Name - 1)];
					c.ReasonType = (System.String)reader[((int)SalesReasonColumn.ReasonType - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SalesReasonColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesReason entity)
		{
			if (!reader.Read()) return;
			
			entity.SalesReasonId = (System.Int32)reader[((int)SalesReasonColumn.SalesReasonId - 1)];
			entity.Name = (System.String)reader[((int)SalesReasonColumn.Name - 1)];
			entity.ReasonType = (System.String)reader[((int)SalesReasonColumn.ReasonType - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesReasonColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesReason entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesReasonId = (System.Int32)dataRow["SalesReasonID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.ReasonType = (System.String)dataRow["ReasonType"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesReason"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesReason Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesReason entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySalesReasonId methods when available
			
			#region SalesOrderHeaderSalesReasonCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeaderSalesReason>|SalesOrderHeaderSalesReasonCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderSalesReasonCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderSalesReasonCollection = DataRepository.SalesOrderHeaderSalesReasonProvider.GetBySalesReasonId(transactionManager, entity.SalesReasonId);

				if (deep && entity.SalesOrderHeaderSalesReasonCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderSalesReasonCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeaderSalesReason>) DataRepository.SalesOrderHeaderSalesReasonProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderSalesReasonCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<SalesOrderHeader>|SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason", deepLoadType, innerList))
			{
				entity.SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason = DataRepository.SalesOrderHeaderProvider.GetBySalesReasonIdFromSalesOrderHeaderSalesReason(transactionManager, entity.SalesReasonId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason != null)
				{
					deepHandles.Add("SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< SalesOrderHeader >) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesReason object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesReason instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesReason Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesReason entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason>
			if (CanDeepSave(entity.SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason, "List<SalesOrderHeader>|SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason", deepSaveType, innerList))
			{
				if (entity.SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason.Count > 0 || entity.SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason.DeletedItems.Count > 0)
				{
					DataRepository.SalesOrderHeaderProvider.Save(transactionManager, entity.SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason); 
					deepHandles.Add("SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepSave,
						new object[] { transactionManager, entity.SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<SalesOrderHeaderSalesReason>
				if (CanDeepSave(entity.SalesOrderHeaderSalesReasonCollection, "List<SalesOrderHeaderSalesReason>|SalesOrderHeaderSalesReasonCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderHeaderSalesReason child in entity.SalesOrderHeaderSalesReasonCollection)
					{
						if(child.SalesReasonIdSource != null)
						{
								child.SalesReasonId = child.SalesReasonIdSource.SalesReasonId;
						}

						if(child.SalesOrderIdSource != null)
						{
								child.SalesOrderId = child.SalesOrderIdSource.SalesOrderId;
						}

					}

					if (entity.SalesOrderHeaderSalesReasonCollection.Count > 0 || entity.SalesOrderHeaderSalesReasonCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderHeaderSalesReasonProvider.Save(transactionManager, entity.SalesOrderHeaderSalesReasonCollection);
						
						deepHandles.Add("SalesOrderHeaderSalesReasonCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderHeaderSalesReason >) DataRepository.SalesOrderHeaderSalesReasonProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderHeaderSalesReasonCollection, deepSaveType, childTypes, innerList }
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
	
	#region SalesReasonChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesReason</c>
	///</summary>
	public enum SalesReasonChildEntityTypes
	{

		///<summary>
		/// Collection of <c>SalesReason</c> as OneToMany for SalesOrderHeaderSalesReasonCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeaderSalesReason>))]
		SalesOrderHeaderSalesReasonCollection,

		///<summary>
		/// Collection of <c>SalesReason</c> as ManyToMany for SalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderIdSalesOrderHeaderCollection_From_SalesOrderHeaderSalesReason,
	}
	
	#endregion SalesReasonChildEntityTypes
	
	#region SalesReasonFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesReasonFilterBuilder : SqlFilterBuilder<SalesReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesReasonFilterBuilder class.
		/// </summary>
		public SalesReasonFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesReasonFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesReasonFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesReasonFilterBuilder
	
	#region SalesReasonParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesReasonParameterBuilder : ParameterizedSqlFilterBuilder<SalesReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesReasonParameterBuilder class.
		/// </summary>
		public SalesReasonParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesReasonParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesReasonParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesReasonParameterBuilder
	
	#region SalesReasonSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesReason"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesReasonSortBuilder : SqlSortBuilder<SalesReasonColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesReasonSqlSortBuilder class.
		/// </summary>
		public SalesReasonSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesReasonSortBuilder
	
} // end namespace
