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
	/// This class is the base class for any <see cref="WorkOrderRoutingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WorkOrderRoutingProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.WorkOrderRouting, Nettiers.AdventureWorks.Entities.WorkOrderRoutingKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.WorkOrderRoutingKey key)
		{
			return Delete(transactionManager, key.WorkOrderId, key.ProductId, key.OperationSequence);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.. Primary Key.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <param name="_operationSequence">Primary key. Indicates the manufacturing process sequence.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _workOrderId, System.Int32 _productId, System.Int16 _operationSequence)
		{
			return Delete(null, _workOrderId, _productId, _operationSequence);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.. Primary Key.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <param name="_operationSequence">Primary key. Indicates the manufacturing process sequence.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _workOrderId, System.Int32 _productId, System.Int16 _operationSequence);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_Location_LocationID key.
		///		FK_WorkOrderRouting_Location_LocationID Description: Foreign key constraint referencing Location.LocationID.
		/// </summary>
		/// <param name="_locationId">Manufacturing location where the part is processed. Foreign key to Location.LocationID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public TList<WorkOrderRouting> GetByLocationId(System.Int16 _locationId)
		{
			int count = -1;
			return GetByLocationId(_locationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_Location_LocationID key.
		///		FK_WorkOrderRouting_Location_LocationID Description: Foreign key constraint referencing Location.LocationID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Manufacturing location where the part is processed. Foreign key to Location.LocationID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		/// <remarks></remarks>
		public TList<WorkOrderRouting> GetByLocationId(TransactionManager transactionManager, System.Int16 _locationId)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_Location_LocationID key.
		///		FK_WorkOrderRouting_Location_LocationID Description: Foreign key constraint referencing Location.LocationID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Manufacturing location where the part is processed. Foreign key to Location.LocationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public TList<WorkOrderRouting> GetByLocationId(TransactionManager transactionManager, System.Int16 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_Location_LocationID key.
		///		fkWorkOrderRoutingLocationLocationId Description: Foreign key constraint referencing Location.LocationID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId">Manufacturing location where the part is processed. Foreign key to Location.LocationID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public TList<WorkOrderRouting> GetByLocationId(System.Int16 _locationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLocationId(null, _locationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_Location_LocationID key.
		///		fkWorkOrderRoutingLocationLocationId Description: Foreign key constraint referencing Location.LocationID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId">Manufacturing location where the part is processed. Foreign key to Location.LocationID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public TList<WorkOrderRouting> GetByLocationId(System.Int16 _locationId, int start, int pageLength,out int count)
		{
			return GetByLocationId(null, _locationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_Location_LocationID key.
		///		FK_WorkOrderRouting_Location_LocationID Description: Foreign key constraint referencing Location.LocationID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Manufacturing location where the part is processed. Foreign key to Location.LocationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public abstract TList<WorkOrderRouting> GetByLocationId(TransactionManager transactionManager, System.Int16 _locationId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_WorkOrder_WorkOrderID key.
		///		FK_WorkOrderRouting_WorkOrder_WorkOrderID Description: Foreign key constraint referencing WorkOrder.WorkOrderID.
		/// </summary>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public TList<WorkOrderRouting> GetByWorkOrderId(System.Int32 _workOrderId)
		{
			int count = -1;
			return GetByWorkOrderId(_workOrderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_WorkOrder_WorkOrderID key.
		///		FK_WorkOrderRouting_WorkOrder_WorkOrderID Description: Foreign key constraint referencing WorkOrder.WorkOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		/// <remarks></remarks>
		public TList<WorkOrderRouting> GetByWorkOrderId(TransactionManager transactionManager, System.Int32 _workOrderId)
		{
			int count = -1;
			return GetByWorkOrderId(transactionManager, _workOrderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_WorkOrder_WorkOrderID key.
		///		FK_WorkOrderRouting_WorkOrder_WorkOrderID Description: Foreign key constraint referencing WorkOrder.WorkOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public TList<WorkOrderRouting> GetByWorkOrderId(TransactionManager transactionManager, System.Int32 _workOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkOrderId(transactionManager, _workOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_WorkOrder_WorkOrderID key.
		///		fkWorkOrderRoutingWorkOrderWorkOrderId Description: Foreign key constraint referencing WorkOrder.WorkOrderID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public TList<WorkOrderRouting> GetByWorkOrderId(System.Int32 _workOrderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWorkOrderId(null, _workOrderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_WorkOrder_WorkOrderID key.
		///		fkWorkOrderRoutingWorkOrderWorkOrderId Description: Foreign key constraint referencing WorkOrder.WorkOrderID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public TList<WorkOrderRouting> GetByWorkOrderId(System.Int32 _workOrderId, int start, int pageLength,out int count)
		{
			return GetByWorkOrderId(null, _workOrderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_WorkOrderRouting_WorkOrder_WorkOrderID key.
		///		FK_WorkOrderRouting_WorkOrder_WorkOrderID Description: Foreign key constraint referencing WorkOrder.WorkOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.WorkOrderRouting objects.</returns>
		public abstract TList<WorkOrderRouting> GetByWorkOrderId(TransactionManager transactionManager, System.Int32 _workOrderId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.WorkOrderRouting Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.WorkOrderRoutingKey key, int start, int pageLength)
		{
			return GetByWorkOrderIdProductIdOperationSequence(transactionManager, key.WorkOrderId, key.ProductId, key.OperationSequence, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_WorkOrderRouting_ProductID index.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrderRouting&gt;"/> class.</returns>
		public TList<WorkOrderRouting> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrderRouting_ProductID index.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrderRouting&gt;"/> class.</returns>
		public TList<WorkOrderRouting> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrderRouting_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrderRouting&gt;"/> class.</returns>
		public TList<WorkOrderRouting> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrderRouting_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrderRouting&gt;"/> class.</returns>
		public TList<WorkOrderRouting> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrderRouting_ProductID index.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrderRouting&gt;"/> class.</returns>
		public TList<WorkOrderRouting> GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_WorkOrderRouting_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;WorkOrderRouting&gt;"/> class.</returns>
		public abstract TList<WorkOrderRouting> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence index.
		/// </summary>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_operationSequence">Primary key. Indicates the manufacturing process sequence.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrderRouting GetByWorkOrderIdProductIdOperationSequence(System.Int32 _workOrderId, System.Int32 _productId, System.Int16 _operationSequence)
		{
			int count = -1;
			return GetByWorkOrderIdProductIdOperationSequence(null,_workOrderId, _productId, _operationSequence, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence index.
		/// </summary>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_operationSequence">Primary key. Indicates the manufacturing process sequence.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrderRouting GetByWorkOrderIdProductIdOperationSequence(System.Int32 _workOrderId, System.Int32 _productId, System.Int16 _operationSequence, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkOrderIdProductIdOperationSequence(null, _workOrderId, _productId, _operationSequence, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_operationSequence">Primary key. Indicates the manufacturing process sequence.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrderRouting GetByWorkOrderIdProductIdOperationSequence(TransactionManager transactionManager, System.Int32 _workOrderId, System.Int32 _productId, System.Int16 _operationSequence)
		{
			int count = -1;
			return GetByWorkOrderIdProductIdOperationSequence(transactionManager, _workOrderId, _productId, _operationSequence, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_operationSequence">Primary key. Indicates the manufacturing process sequence.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrderRouting GetByWorkOrderIdProductIdOperationSequence(TransactionManager transactionManager, System.Int32 _workOrderId, System.Int32 _productId, System.Int16 _operationSequence, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkOrderIdProductIdOperationSequence(transactionManager, _workOrderId, _productId, _operationSequence, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence index.
		/// </summary>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_operationSequence">Primary key. Indicates the manufacturing process sequence.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.WorkOrderRouting GetByWorkOrderIdProductIdOperationSequence(System.Int32 _workOrderId, System.Int32 _productId, System.Int16 _operationSequence, int start, int pageLength, out int count)
		{
			return GetByWorkOrderIdProductIdOperationSequence(null, _workOrderId, _productId, _operationSequence, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workOrderId">Primary key. Foreign key to WorkOrder.WorkOrderID.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_operationSequence">Primary key. Indicates the manufacturing process sequence.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.WorkOrderRouting GetByWorkOrderIdProductIdOperationSequence(TransactionManager transactionManager, System.Int32 _workOrderId, System.Int32 _productId, System.Int16 _operationSequence, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;WorkOrderRouting&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;WorkOrderRouting&gt;"/></returns>
		public static TList<WorkOrderRouting> Fill(IDataReader reader, TList<WorkOrderRouting> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.WorkOrderRouting c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("WorkOrderRouting")
					.Append("|").Append((System.Int32)reader[((int)WorkOrderRoutingColumn.WorkOrderId - 1)])
					.Append("|").Append((System.Int32)reader[((int)WorkOrderRoutingColumn.ProductId - 1)])
					.Append("|").Append((System.Int16)reader[((int)WorkOrderRoutingColumn.OperationSequence - 1)]).ToString();
					c = EntityManager.LocateOrCreate<WorkOrderRouting>(
					key.ToString(), // EntityTrackingKey
					"WorkOrderRouting",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.WorkOrderRouting();
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
					c.WorkOrderId = (System.Int32)reader[((int)WorkOrderRoutingColumn.WorkOrderId - 1)];
					c.OriginalWorkOrderId = c.WorkOrderId;
					c.ProductId = (System.Int32)reader[((int)WorkOrderRoutingColumn.ProductId - 1)];
					c.OriginalProductId = c.ProductId;
					c.OperationSequence = (System.Int16)reader[((int)WorkOrderRoutingColumn.OperationSequence - 1)];
					c.OriginalOperationSequence = c.OperationSequence;
					c.LocationId = (System.Int16)reader[((int)WorkOrderRoutingColumn.LocationId - 1)];
					c.ScheduledStartDate = (System.DateTime)reader[((int)WorkOrderRoutingColumn.ScheduledStartDate - 1)];
					c.ScheduledEndDate = (System.DateTime)reader[((int)WorkOrderRoutingColumn.ScheduledEndDate - 1)];
					c.ActualStartDate = (reader.IsDBNull(((int)WorkOrderRoutingColumn.ActualStartDate - 1)))?null:(System.DateTime?)reader[((int)WorkOrderRoutingColumn.ActualStartDate - 1)];
					c.ActualEndDate = (reader.IsDBNull(((int)WorkOrderRoutingColumn.ActualEndDate - 1)))?null:(System.DateTime?)reader[((int)WorkOrderRoutingColumn.ActualEndDate - 1)];
					c.ActualResourceHrs = (reader.IsDBNull(((int)WorkOrderRoutingColumn.ActualResourceHrs - 1)))?null:(System.Decimal?)reader[((int)WorkOrderRoutingColumn.ActualResourceHrs - 1)];
					c.PlannedCost = (System.Decimal)reader[((int)WorkOrderRoutingColumn.PlannedCost - 1)];
					c.ActualCost = (reader.IsDBNull(((int)WorkOrderRoutingColumn.ActualCost - 1)))?null:(System.Decimal?)reader[((int)WorkOrderRoutingColumn.ActualCost - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)WorkOrderRoutingColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.WorkOrderRouting entity)
		{
			if (!reader.Read()) return;
			
			entity.WorkOrderId = (System.Int32)reader[((int)WorkOrderRoutingColumn.WorkOrderId - 1)];
			entity.OriginalWorkOrderId = (System.Int32)reader["WorkOrderID"];
			entity.ProductId = (System.Int32)reader[((int)WorkOrderRoutingColumn.ProductId - 1)];
			entity.OriginalProductId = (System.Int32)reader["ProductID"];
			entity.OperationSequence = (System.Int16)reader[((int)WorkOrderRoutingColumn.OperationSequence - 1)];
			entity.OriginalOperationSequence = (System.Int16)reader["OperationSequence"];
			entity.LocationId = (System.Int16)reader[((int)WorkOrderRoutingColumn.LocationId - 1)];
			entity.ScheduledStartDate = (System.DateTime)reader[((int)WorkOrderRoutingColumn.ScheduledStartDate - 1)];
			entity.ScheduledEndDate = (System.DateTime)reader[((int)WorkOrderRoutingColumn.ScheduledEndDate - 1)];
			entity.ActualStartDate = (reader.IsDBNull(((int)WorkOrderRoutingColumn.ActualStartDate - 1)))?null:(System.DateTime?)reader[((int)WorkOrderRoutingColumn.ActualStartDate - 1)];
			entity.ActualEndDate = (reader.IsDBNull(((int)WorkOrderRoutingColumn.ActualEndDate - 1)))?null:(System.DateTime?)reader[((int)WorkOrderRoutingColumn.ActualEndDate - 1)];
			entity.ActualResourceHrs = (reader.IsDBNull(((int)WorkOrderRoutingColumn.ActualResourceHrs - 1)))?null:(System.Decimal?)reader[((int)WorkOrderRoutingColumn.ActualResourceHrs - 1)];
			entity.PlannedCost = (System.Decimal)reader[((int)WorkOrderRoutingColumn.PlannedCost - 1)];
			entity.ActualCost = (reader.IsDBNull(((int)WorkOrderRoutingColumn.ActualCost - 1)))?null:(System.Decimal?)reader[((int)WorkOrderRoutingColumn.ActualCost - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)WorkOrderRoutingColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.WorkOrderRouting entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.WorkOrderId = (System.Int32)dataRow["WorkOrderID"];
			entity.OriginalWorkOrderId = (System.Int32)dataRow["WorkOrderID"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OriginalProductId = (System.Int32)dataRow["ProductID"];
			entity.OperationSequence = (System.Int16)dataRow["OperationSequence"];
			entity.OriginalOperationSequence = (System.Int16)dataRow["OperationSequence"];
			entity.LocationId = (System.Int16)dataRow["LocationID"];
			entity.ScheduledStartDate = (System.DateTime)dataRow["ScheduledStartDate"];
			entity.ScheduledEndDate = (System.DateTime)dataRow["ScheduledEndDate"];
			entity.ActualStartDate = Convert.IsDBNull(dataRow["ActualStartDate"]) ? null : (System.DateTime?)dataRow["ActualStartDate"];
			entity.ActualEndDate = Convert.IsDBNull(dataRow["ActualEndDate"]) ? null : (System.DateTime?)dataRow["ActualEndDate"];
			entity.ActualResourceHrs = Convert.IsDBNull(dataRow["ActualResourceHrs"]) ? null : (System.Decimal?)dataRow["ActualResourceHrs"];
			entity.PlannedCost = (System.Decimal)dataRow["PlannedCost"];
			entity.ActualCost = Convert.IsDBNull(dataRow["ActualCost"]) ? null : (System.Decimal?)dataRow["ActualCost"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.WorkOrderRouting"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.WorkOrderRouting Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.WorkOrderRouting entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LocationIdSource	
			if (CanDeepLoad(entity, "Location|LocationIdSource", deepLoadType, innerList) 
				&& entity.LocationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LocationId;
				Location tmpEntity = EntityManager.LocateEntity<Location>(EntityLocator.ConstructKeyFromPkItems(typeof(Location), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LocationIdSource = tmpEntity;
				else
					entity.LocationIdSource = DataRepository.LocationProvider.GetByLocationId(transactionManager, entity.LocationId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LocationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LocationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LocationProvider.DeepLoad(transactionManager, entity.LocationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LocationIdSource

			#region WorkOrderIdSource	
			if (CanDeepLoad(entity, "WorkOrder|WorkOrderIdSource", deepLoadType, innerList) 
				&& entity.WorkOrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.WorkOrderId;
				WorkOrder tmpEntity = EntityManager.LocateEntity<WorkOrder>(EntityLocator.ConstructKeyFromPkItems(typeof(WorkOrder), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.WorkOrderIdSource = tmpEntity;
				else
					entity.WorkOrderIdSource = DataRepository.WorkOrderProvider.GetByWorkOrderId(transactionManager, entity.WorkOrderId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WorkOrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.WorkOrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.WorkOrderProvider.DeepLoad(transactionManager, entity.WorkOrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion WorkOrderIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.WorkOrderRouting object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.WorkOrderRouting instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.WorkOrderRouting Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.WorkOrderRouting entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LocationIdSource
			if (CanDeepSave(entity, "Location|LocationIdSource", deepSaveType, innerList) 
				&& entity.LocationIdSource != null)
			{
				DataRepository.LocationProvider.Save(transactionManager, entity.LocationIdSource);
				entity.LocationId = entity.LocationIdSource.LocationId;
			}
			#endregion 
			
			#region WorkOrderIdSource
			if (CanDeepSave(entity, "WorkOrder|WorkOrderIdSource", deepSaveType, innerList) 
				&& entity.WorkOrderIdSource != null)
			{
				DataRepository.WorkOrderProvider.Save(transactionManager, entity.WorkOrderIdSource);
				entity.WorkOrderId = entity.WorkOrderIdSource.WorkOrderId;
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
	
	#region WorkOrderRoutingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.WorkOrderRouting</c>
	///</summary>
	public enum WorkOrderRoutingChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Location</c> at LocationIdSource
		///</summary>
		[ChildEntityType(typeof(Location))]
		Location,
			
		///<summary>
		/// Composite Property for <c>WorkOrder</c> at WorkOrderIdSource
		///</summary>
		[ChildEntityType(typeof(WorkOrder))]
		WorkOrder,
		}
	
	#endregion WorkOrderRoutingChildEntityTypes
	
	#region WorkOrderRoutingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WorkOrderRoutingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrderRouting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderRoutingFilterBuilder : SqlFilterBuilder<WorkOrderRoutingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingFilterBuilder class.
		/// </summary>
		public WorkOrderRoutingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkOrderRoutingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkOrderRoutingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkOrderRoutingFilterBuilder
	
	#region WorkOrderRoutingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WorkOrderRoutingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrderRouting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderRoutingParameterBuilder : ParameterizedSqlFilterBuilder<WorkOrderRoutingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingParameterBuilder class.
		/// </summary>
		public WorkOrderRoutingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkOrderRoutingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkOrderRoutingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkOrderRoutingParameterBuilder
	
	#region WorkOrderRoutingSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;WorkOrderRoutingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrderRouting"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WorkOrderRoutingSortBuilder : SqlSortBuilder<WorkOrderRoutingColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingSqlSortBuilder class.
		/// </summary>
		public WorkOrderRoutingSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WorkOrderRoutingSortBuilder
	
} // end namespace
