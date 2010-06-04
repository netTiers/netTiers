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
	/// This class is the base class for any <see cref="WorkOrderProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WorkOrderProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.WorkOrder, Nettiers.AdventureWorks.Entities.WorkOrderKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.WorkOrderKey key)
		{
			return Delete(transactionManager, key.WorkOrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_workOrderId">Primary key for WorkOrder records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _workOrderId)
		{
			return Delete(null, _workOrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key for WorkOrder records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _workOrderId);		
		
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
		public override Nettiers.AdventureWorks.Entities.WorkOrder Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.WorkOrderKey key, int start, int pageLength)
		{
			return GetByWorkOrderId(transactionManager, key.WorkOrderId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_WorkOrder_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public abstract TList<WorkOrder> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_WorkOrder_ScrapReasonID index.
		/// </summary>
		/// <param name="_scrapReasonId">Reason for inspection failure.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByScrapReasonId(System.Int16? _scrapReasonId)
		{
			int count = -1;
			return GetByScrapReasonId(null,_scrapReasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ScrapReasonID index.
		/// </summary>
		/// <param name="_scrapReasonId">Reason for inspection failure.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByScrapReasonId(System.Int16? _scrapReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetByScrapReasonId(null, _scrapReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ScrapReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_scrapReasonId">Reason for inspection failure.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByScrapReasonId(TransactionManager transactionManager, System.Int16? _scrapReasonId)
		{
			int count = -1;
			return GetByScrapReasonId(transactionManager, _scrapReasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ScrapReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_scrapReasonId">Reason for inspection failure.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByScrapReasonId(TransactionManager transactionManager, System.Int16? _scrapReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetByScrapReasonId(transactionManager, _scrapReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ScrapReasonID index.
		/// </summary>
		/// <param name="_scrapReasonId">Reason for inspection failure.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public TList<WorkOrder> GetByScrapReasonId(System.Int16? _scrapReasonId, int start, int pageLength, out int count)
		{
			return GetByScrapReasonId(null, _scrapReasonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrder_ScrapReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_scrapReasonId">Reason for inspection failure.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrder&gt;"/> class.</returns>
		public abstract TList<WorkOrder> GetByScrapReasonId(TransactionManager transactionManager, System.Int16? _scrapReasonId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_WorkOrder_WorkOrderID index.
		/// </summary>
		/// <param name="_workOrderId">Primary key for WorkOrder records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrder GetByWorkOrderId(System.Int32 _workOrderId)
		{
			int count = -1;
			return GetByWorkOrderId(null,_workOrderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrder_WorkOrderID index.
		/// </summary>
		/// <param name="_workOrderId">Primary key for WorkOrder records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrder GetByWorkOrderId(System.Int32 _workOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkOrderId(null, _workOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrder_WorkOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key for WorkOrder records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrder GetByWorkOrderId(TransactionManager transactionManager, System.Int32 _workOrderId)
		{
			int count = -1;
			return GetByWorkOrderId(transactionManager, _workOrderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrder_WorkOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key for WorkOrder records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrder GetByWorkOrderId(TransactionManager transactionManager, System.Int32 _workOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkOrderId(transactionManager, _workOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrder_WorkOrderID index.
		/// </summary>
		/// <param name="_workOrderId">Primary key for WorkOrder records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrder GetByWorkOrderId(System.Int32 _workOrderId, int start, int pageLength, out int count)
		{
			return GetByWorkOrderId(null, _workOrderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrder_WorkOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key for WorkOrder records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.WorkOrder GetByWorkOrderId(TransactionManager transactionManager, System.Int32 _workOrderId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;WorkOrder&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;WorkOrder&gt;"/></returns>
		public static TList<WorkOrder> Fill(IDataReader reader, TList<WorkOrder> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.WorkOrder c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("WorkOrder")
					.Append("|").Append((System.Int32)reader[((int)WorkOrderColumn.WorkOrderId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<WorkOrder>(
					key.ToString(), // EntityTrackingKey
					"WorkOrder",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.WorkOrder();
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
					c.WorkOrderId = (System.Int32)reader[((int)WorkOrderColumn.WorkOrderId - 1)];
					c.ProductId = (System.Int32)reader[((int)WorkOrderColumn.ProductId - 1)];
					c.OrderQty = (System.Int32)reader[((int)WorkOrderColumn.OrderQty - 1)];
					c.StockedQty = (System.Int32)reader[((int)WorkOrderColumn.StockedQty - 1)];
					c.ScrappedQty = (System.Int16)reader[((int)WorkOrderColumn.ScrappedQty - 1)];
					c.StartDate = (System.DateTime)reader[((int)WorkOrderColumn.StartDate - 1)];
					c.EndDate = (reader.IsDBNull(((int)WorkOrderColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)WorkOrderColumn.EndDate - 1)];
					c.DueDate = (System.DateTime)reader[((int)WorkOrderColumn.DueDate - 1)];
					c.ScrapReasonId = (reader.IsDBNull(((int)WorkOrderColumn.ScrapReasonId - 1)))?null:(System.Int16?)reader[((int)WorkOrderColumn.ScrapReasonId - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)WorkOrderColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.WorkOrder entity)
		{
			if (!reader.Read()) return;
			
			entity.WorkOrderId = (System.Int32)reader[((int)WorkOrderColumn.WorkOrderId - 1)];
			entity.ProductId = (System.Int32)reader[((int)WorkOrderColumn.ProductId - 1)];
			entity.OrderQty = (System.Int32)reader[((int)WorkOrderColumn.OrderQty - 1)];
			entity.StockedQty = (System.Int32)reader[((int)WorkOrderColumn.StockedQty - 1)];
			entity.ScrappedQty = (System.Int16)reader[((int)WorkOrderColumn.ScrappedQty - 1)];
			entity.StartDate = (System.DateTime)reader[((int)WorkOrderColumn.StartDate - 1)];
			entity.EndDate = (reader.IsDBNull(((int)WorkOrderColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)WorkOrderColumn.EndDate - 1)];
			entity.DueDate = (System.DateTime)reader[((int)WorkOrderColumn.DueDate - 1)];
			entity.ScrapReasonId = (reader.IsDBNull(((int)WorkOrderColumn.ScrapReasonId - 1)))?null:(System.Int16?)reader[((int)WorkOrderColumn.ScrapReasonId - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)WorkOrderColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.WorkOrder entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.WorkOrderId = (System.Int32)dataRow["WorkOrderID"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OrderQty = (System.Int32)dataRow["OrderQty"];
			entity.StockedQty = (System.Int32)dataRow["StockedQty"];
			entity.ScrappedQty = (System.Int16)dataRow["ScrappedQty"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.EndDate = Convert.IsDBNull(dataRow["EndDate"]) ? null : (System.DateTime?)dataRow["EndDate"];
			entity.DueDate = (System.DateTime)dataRow["DueDate"];
			entity.ScrapReasonId = Convert.IsDBNull(dataRow["ScrapReasonID"]) ? null : (System.Int16?)dataRow["ScrapReasonID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.WorkOrder"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.WorkOrder Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.WorkOrder entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ProductIdSource	
			if (CanDeepLoad(entity, "Product|ProductIdSource", deepLoadType, innerList) 
				&& entity.ProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductId;
				Product tmpEntity = EntityManager.LocateEntity<Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductIdSource = tmpEntity;
				else
					entity.ProductIdSource = DataRepository.ProductProvider.GetByProductId(transactionManager, entity.ProductId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductIdSource

			#region ScrapReasonIdSource	
			if (CanDeepLoad(entity, "ScrapReason|ScrapReasonIdSource", deepLoadType, innerList) 
				&& entity.ScrapReasonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ScrapReasonId ?? (short)0);
				ScrapReason tmpEntity = EntityManager.LocateEntity<ScrapReason>(EntityLocator.ConstructKeyFromPkItems(typeof(ScrapReason), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ScrapReasonIdSource = tmpEntity;
				else
					entity.ScrapReasonIdSource = DataRepository.ScrapReasonProvider.GetByScrapReasonId(transactionManager, (entity.ScrapReasonId ?? (short)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ScrapReasonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ScrapReasonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ScrapReasonProvider.DeepLoad(transactionManager, entity.ScrapReasonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ScrapReasonIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByWorkOrderId methods when available
			
			#region WorkOrderRoutingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WorkOrderRouting>|WorkOrderRoutingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WorkOrderRoutingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WorkOrderRoutingCollection = DataRepository.WorkOrderRoutingProvider.GetByWorkOrderId(transactionManager, entity.WorkOrderId);

				if (deep && entity.WorkOrderRoutingCollection.Count > 0)
				{
					deepHandles.Add("WorkOrderRoutingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WorkOrderRouting>) DataRepository.WorkOrderRoutingProvider.DeepLoad,
						new object[] { transactionManager, entity.WorkOrderRoutingCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.WorkOrder object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.WorkOrder instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.WorkOrder Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.WorkOrder entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductIdSource
			if (CanDeepSave(entity, "Product|ProductIdSource", deepSaveType, innerList) 
				&& entity.ProductIdSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdSource);
				entity.ProductId = entity.ProductIdSource.ProductId;
			}
			#endregion 
			
			#region ScrapReasonIdSource
			if (CanDeepSave(entity, "ScrapReason|ScrapReasonIdSource", deepSaveType, innerList) 
				&& entity.ScrapReasonIdSource != null)
			{
				DataRepository.ScrapReasonProvider.Save(transactionManager, entity.ScrapReasonIdSource);
				entity.ScrapReasonId = entity.ScrapReasonIdSource.ScrapReasonId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<WorkOrderRouting>
				if (CanDeepSave(entity.WorkOrderRoutingCollection, "List<WorkOrderRouting>|WorkOrderRoutingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WorkOrderRouting child in entity.WorkOrderRoutingCollection)
					{
						if(child.WorkOrderIdSource != null)
						{
							child.WorkOrderId = child.WorkOrderIdSource.WorkOrderId;
						}
						else
						{
							child.WorkOrderId = entity.WorkOrderId;
						}

					}

					if (entity.WorkOrderRoutingCollection.Count > 0 || entity.WorkOrderRoutingCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WorkOrderRoutingProvider.Save(transactionManager, entity.WorkOrderRoutingCollection);
						
						deepHandles.Add("WorkOrderRoutingCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WorkOrderRouting >) DataRepository.WorkOrderRoutingProvider.DeepSave,
							new object[] { transactionManager, entity.WorkOrderRoutingCollection, deepSaveType, childTypes, innerList }
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
	
	#region WorkOrderChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.WorkOrder</c>
	///</summary>
	public enum WorkOrderChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>ScrapReason</c> at ScrapReasonIdSource
		///</summary>
		[ChildEntityType(typeof(ScrapReason))]
		ScrapReason,
	
		///<summary>
		/// Collection of <c>WorkOrder</c> as OneToMany for WorkOrderRoutingCollection
		///</summary>
		[ChildEntityType(typeof(TList<WorkOrderRouting>))]
		WorkOrderRoutingCollection,
	}
	
	#endregion WorkOrderChildEntityTypes
	
	#region WorkOrderFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WorkOrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderFilterBuilder : SqlFilterBuilder<WorkOrderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderFilterBuilder class.
		/// </summary>
		public WorkOrderFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkOrderFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkOrderFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkOrderFilterBuilder
	
	#region WorkOrderParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WorkOrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderParameterBuilder : ParameterizedSqlFilterBuilder<WorkOrderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderParameterBuilder class.
		/// </summary>
		public WorkOrderParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkOrderParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkOrderParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkOrderParameterBuilder
	
	#region WorkOrderSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;WorkOrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrder"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WorkOrderSortBuilder : SqlSortBuilder<WorkOrderColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderSqlSortBuilder class.
		/// </summary>
		public WorkOrderSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WorkOrderSortBuilder
	
} // end namespace
