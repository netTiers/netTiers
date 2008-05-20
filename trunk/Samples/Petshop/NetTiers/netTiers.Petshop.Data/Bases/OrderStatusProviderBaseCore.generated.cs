#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="OrderStatusProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderStatusProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.OrderStatus, netTiers.Petshop.Entities.OrderStatusKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Functions

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.OrderStatusKey key)
		{
			return Delete(transactionManager, key.OrderId, key.LineNum, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="orderId">. Primary Key.</param>
		/// <param name="lineNum">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 orderId, System.Int32 lineNum, byte[] timestamp)
		{
			return Delete(null, orderId, lineNum, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId">. Primary Key.</param>
		/// <param name="lineNum">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum, byte[] timestamp);		
		
		#endregion
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__OrderStat__Order__164452B1 key.
		///		FK__OrderStat__Order__164452B1 Description: 
		/// </summary>
		/// <param name="orderId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderId(System.Int32 orderId)
		{
			int count = -1;
			return GetByOrderId(orderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__OrderStat__Order__164452B1 key.
		///		FK__OrderStat__Order__164452B1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderId(TransactionManager transactionManager, System.Int32 orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, orderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__OrderStat__Order__164452B1 key.
		///		FK__OrderStat__Order__164452B1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderId(TransactionManager transactionManager, System.Int32 orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__OrderStat__Order__164452B1 key.
		///		fK__OrderStat__Order__164452B1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderId(System.Int32 orderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderId(null, orderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__OrderStat__Order__164452B1 key.
		///		fK__OrderStat__Order__164452B1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderId(System.Int32 orderId, int start, int pageLength,out int count)
		{
			return GetByOrderId(null, orderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__OrderStat__Order__164452B1 key.
		///		FK__OrderStat__Order__164452B1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderId(TransactionManager transactionManager, System.Int32 orderId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderStatus_OrderStatusType key.
		///		FK_OrderStatus_OrderStatusType Description: 
		/// </summary>
		/// <param name="orderStatusId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderStatusId(System.Int32 orderStatusId)
		{
			int count = -1;
			return GetByOrderStatusId(orderStatusId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderStatus_OrderStatusType key.
		///		FK_OrderStatus_OrderStatusType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatusId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderStatusId(TransactionManager transactionManager, System.Int32 orderStatusId)
		{
			int count = -1;
			return GetByOrderStatusId(transactionManager, orderStatusId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderStatus_OrderStatusType key.
		///		FK_OrderStatus_OrderStatusType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderStatusId(TransactionManager transactionManager, System.Int32 orderStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStatusId(transactionManager, orderStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderStatus_OrderStatusType key.
		///		fK_OrderStatus_OrderStatusType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderStatusId(System.Int32 orderStatusId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderStatusId(null, orderStatusId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderStatus_OrderStatusType key.
		///		fK_OrderStatus_OrderStatusType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderStatusId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderStatusId(System.Int32 orderStatusId, int start, int pageLength,out int count)
		{
			return GetByOrderStatusId(null, orderStatusId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderStatus_OrderStatusType key.
		///		FK_OrderStatus_OrderStatusType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.OrderStatus objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<OrderStatus> GetByOrderStatusId(TransactionManager transactionManager, System.Int32 orderStatusId, int start, int pageLength, out int count);
		
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
		public override netTiers.Petshop.Entities.OrderStatus Get(TransactionManager transactionManager, netTiers.Petshop.Entities.OrderStatusKey key, int start, int pageLength)
		{
			return GetByLineNumOrderId(transactionManager, key.OrderId, key.LineNum, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PkOrderStatus index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatus"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatus GetByLineNumOrderId(System.Int32 orderId, System.Int32 lineNum)
		{
			int count = -1;
			return GetByLineNumOrderId(null,orderId, lineNum, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkOrderStatus index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatus"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatus GetByLineNumOrderId(System.Int32 orderId, System.Int32 lineNum, int start, int pageLength)
		{
			int count = -1;
			return GetByLineNumOrderId(null, orderId, lineNum, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkOrderStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatus"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatus GetByLineNumOrderId(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum)
		{
			int count = -1;
			return GetByLineNumOrderId(transactionManager, orderId, lineNum, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkOrderStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatus"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatus GetByLineNumOrderId(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum, int start, int pageLength)
		{
			int count = -1;
			return GetByLineNumOrderId(transactionManager, orderId, lineNum, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkOrderStatus index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatus"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatus GetByLineNumOrderId(System.Int32 orderId, System.Int32 lineNum, int start, int pageLength, out int count)
		{
			return GetByLineNumOrderId(null, orderId, lineNum, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PkOrderStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatus"/> class.</returns>
		public abstract netTiers.Petshop.Entities.OrderStatus GetByLineNumOrderId(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;OrderStatus&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;OrderStatus&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<OrderStatus> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<OrderStatus> rows, int start, int pageLength)
		{
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
				
				netTiers.Petshop.Entities.OrderStatus c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"OrderStatus" 
							+ (reader.IsDBNull(reader.GetOrdinal("OrderId"))?(int)0:(System.Int32)reader["OrderId"]).ToString()
							+ (reader.IsDBNull(reader.GetOrdinal("LineNum"))?(int)0:(System.Int32)reader["LineNum"]).ToString();

					c = EntityManager.LocateOrCreate<OrderStatus>(
						key.ToString(), // EntityTrackingKey 
						"OrderStatus",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.OrderStatus();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.OrderId = (System.Int32)reader["OrderId"];
					c.OriginalOrderId = c.OrderId; //(reader.IsDBNull(reader.GetOrdinal("OrderId")))?(int)0:(System.Int32)reader["OrderId"];
					c.LineNum = (System.Int32)reader["LineNum"];
					c.OriginalLineNum = c.LineNum; //(reader.IsDBNull(reader.GetOrdinal("LineNum")))?(int)0:(System.Int32)reader["LineNum"];
					c.OrderDate = (System.DateTime)reader["OrderDate"];
					c.OrderStatusId = (System.Int32)reader["OrderStatusId"];
					c.Timestamp = (System.Byte[])reader["Timestamp"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.OrderStatus"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.OrderStatus"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.OrderStatus entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderId = (System.Int32)reader["OrderId"];
			entity.OriginalOrderId = (System.Int32)reader["OrderId"];
			entity.LineNum = (System.Int32)reader["LineNum"];
			entity.OriginalLineNum = (System.Int32)reader["LineNum"];
			entity.OrderDate = (System.DateTime)reader["OrderDate"];
			entity.OrderStatusId = (System.Int32)reader["OrderStatusId"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.OrderStatus"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.OrderStatus"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.OrderStatus entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (System.Int32)dataRow["OrderId"];
			entity.OriginalOrderId = (System.Int32)dataRow["OrderId"];
			entity.LineNum = (System.Int32)dataRow["LineNum"];
			entity.OriginalLineNum = (System.Int32)dataRow["LineNum"];
			entity.OrderDate = (System.DateTime)dataRow["OrderDate"];
			entity.OrderStatusId = (System.Int32)dataRow["OrderStatusId"];
			entity.Timestamp = (System.Byte[])dataRow["Timestamp"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.OrderStatus"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.OrderStatus Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.OrderStatus entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region OrderIdSource	
			if (CanDeepLoad(entity, "Orders", "OrderIdSource", deepLoadType, innerList) 
				&& entity.OrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.OrderId;
				Orders tmpEntity = EntityManager.LocateEntity<Orders>(EntityLocator.ConstructKeyFromPkItems(typeof(Orders), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderIdSource = tmpEntity;
				else
					entity.OrderIdSource = DataRepository.OrdersProvider.GetByOrderId(entity.OrderId);
			
				if (deep && entity.OrderIdSource != null)
				{
					DataRepository.OrdersProvider.DeepLoad(transactionManager, entity.OrderIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion OrderIdSource

			#region OrderStatusIdSource	
			if (CanDeepLoad(entity, "OrderStatusType", "OrderStatusIdSource", deepLoadType, innerList) 
				&& entity.OrderStatusIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.OrderStatusId;
				OrderStatusType tmpEntity = EntityManager.LocateEntity<OrderStatusType>(EntityLocator.ConstructKeyFromPkItems(typeof(OrderStatusType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderStatusIdSource = tmpEntity;
				else
					entity.OrderStatusIdSource = DataRepository.OrderStatusTypeProvider.GetByOrderStatusId(entity.OrderStatusId);
			
				if (deep && entity.OrderStatusIdSource != null)
				{
					DataRepository.OrderStatusTypeProvider.DeepLoad(transactionManager, entity.OrderStatusIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion OrderStatusIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.OrderStatus object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.OrderStatus instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.OrderStatus Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.OrderStatus entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region OrderIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Orders"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Orders"] == null))
			{
				if (entity.OrderIdSource != null )
				{			
					DataRepository.OrdersProvider.Save(transactionManager, entity.OrderIdSource);
				}
			}
			#endregion 
			
			#region OrderStatusIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["OrderStatusType"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" OrderStatusType"] == null))
			{
				if (entity.OrderStatusIdSource != null )
				{			
					DataRepository.OrderStatusTypeProvider.Save(transactionManager, entity.OrderStatusIdSource);
				}
			}
			#endregion 
			#endregion Composite Source Properties

		}
		#endregion
	} // end class
	
	#region OrderStatusChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.OrderStatus</c>
	///</summary>
	public enum OrderStatusChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Orders</c> at OrderIdSource
		///</summary>
		[ChildEntityType(typeof(Orders))]
		Orders,
			
		///<summary>
		/// Composite Property for <c>OrderStatusType</c> at OrderStatusIdSource
		///</summary>
		[ChildEntityType(typeof(OrderStatusType))]
		OrderStatusType,
		}
	
	#endregion OrderStatusChildEntityTypes
	
	#region OrderStatusFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusFilterBuilder : SqlFilterBuilder<OrderStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilterBuilder class.
		/// </summary>
		public OrderStatusFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStatusFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStatusFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStatusFilterBuilder
} // end namespace
