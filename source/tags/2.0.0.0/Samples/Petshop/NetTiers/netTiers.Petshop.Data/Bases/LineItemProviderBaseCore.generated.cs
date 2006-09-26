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
	/// This class is the base class for any <see cref="LineItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LineItemProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.LineItem, netTiers.Petshop.Entities.LineItemKey>
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
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.LineItemKey key)
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
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__1367E606 key.
		///		FK__LineItem__OrderI__1367E606 Description: 
		/// </summary>
		/// <param name="orderId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public netTiers.Petshop.Entities.TList<LineItem> GetByOrderId(System.Int32 orderId)
		{
			int count = -1;
			return GetByOrderId(orderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__1367E606 key.
		///		FK__LineItem__OrderI__1367E606 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<LineItem> GetByOrderId(TransactionManager transactionManager, System.Int32 orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, orderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__1367E606 key.
		///		FK__LineItem__OrderI__1367E606 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public netTiers.Petshop.Entities.TList<LineItem> GetByOrderId(TransactionManager transactionManager, System.Int32 orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__1367E606 key.
		///		fK__LineItem__OrderI__1367E606 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public netTiers.Petshop.Entities.TList<LineItem> GetByOrderId(System.Int32 orderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderId(null, orderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__1367E606 key.
		///		fK__LineItem__OrderI__1367E606 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public netTiers.Petshop.Entities.TList<LineItem> GetByOrderId(System.Int32 orderId, int start, int pageLength,out int count)
		{
			return GetByOrderId(null, orderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__1367E606 key.
		///		FK__LineItem__OrderI__1367E606 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<LineItem> GetByOrderId(TransactionManager transactionManager, System.Int32 orderId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LineItem_Item key.
		///		FK_LineItem_Item Description: 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public netTiers.Petshop.Entities.TList<LineItem> GetByItemId(System.Guid itemId)
		{
			int count = -1;
			return GetByItemId(itemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LineItem_Item key.
		///		FK_LineItem_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<LineItem> GetByItemId(TransactionManager transactionManager, System.Guid itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LineItem_Item key.
		///		FK_LineItem_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public netTiers.Petshop.Entities.TList<LineItem> GetByItemId(TransactionManager transactionManager, System.Guid itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LineItem_Item key.
		///		fK_LineItem_Item Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public netTiers.Petshop.Entities.TList<LineItem> GetByItemId(System.Guid itemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByItemId(null, itemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LineItem_Item key.
		///		fK_LineItem_Item Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public netTiers.Petshop.Entities.TList<LineItem> GetByItemId(System.Guid itemId, int start, int pageLength,out int count)
		{
			return GetByItemId(null, itemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LineItem_Item key.
		///		FK_LineItem_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<LineItem> GetByItemId(TransactionManager transactionManager, System.Guid itemId, int start, int pageLength, out int count);
		
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
		public override netTiers.Petshop.Entities.LineItem Get(TransactionManager transactionManager, netTiers.Petshop.Entities.LineItemKey key, int start, int pageLength)
		{
			return GetByLineNumOrderId(transactionManager, key.OrderId, key.LineNum, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PkLineItem index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.LineItem"/> class.</returns>
		public netTiers.Petshop.Entities.LineItem GetByLineNumOrderId(System.Int32 orderId, System.Int32 lineNum)
		{
			int count = -1;
			return GetByLineNumOrderId(null,orderId, lineNum, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.LineItem"/> class.</returns>
		public netTiers.Petshop.Entities.LineItem GetByLineNumOrderId(System.Int32 orderId, System.Int32 lineNum, int start, int pageLength)
		{
			int count = -1;
			return GetByLineNumOrderId(null, orderId, lineNum, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.LineItem"/> class.</returns>
		public netTiers.Petshop.Entities.LineItem GetByLineNumOrderId(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum)
		{
			int count = -1;
			return GetByLineNumOrderId(transactionManager, orderId, lineNum, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.LineItem"/> class.</returns>
		public netTiers.Petshop.Entities.LineItem GetByLineNumOrderId(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum, int start, int pageLength)
		{
			int count = -1;
			return GetByLineNumOrderId(transactionManager, orderId, lineNum, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.LineItem"/> class.</returns>
		public netTiers.Petshop.Entities.LineItem GetByLineNumOrderId(System.Int32 orderId, System.Int32 lineNum, int start, int pageLength, out int count)
		{
			return GetByLineNumOrderId(null, orderId, lineNum, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.LineItem"/> class.</returns>
		public abstract netTiers.Petshop.Entities.LineItem GetByLineNumOrderId(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;LineItem&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;LineItem&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<LineItem> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<LineItem> rows, int start, int pageLength)
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
				
				netTiers.Petshop.Entities.LineItem c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"LineItem" 
							+ (reader.IsDBNull(reader.GetOrdinal("OrderId"))?(int)0:(System.Int32)reader["OrderId"]).ToString()
							+ (reader.IsDBNull(reader.GetOrdinal("LineNum"))?(int)0:(System.Int32)reader["LineNum"]).ToString();

					c = EntityManager.LocateOrCreate<LineItem>(
						key.ToString(), // EntityTrackingKey 
						"LineItem",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.LineItem();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.OrderId = (System.Int32)reader["OrderId"];
					c.OriginalOrderId = c.OrderId; //(reader.IsDBNull(reader.GetOrdinal("OrderId")))?(int)0:(System.Int32)reader["OrderId"];
					c.LineNum = (System.Int32)reader["LineNum"];
					c.OriginalLineNum = c.LineNum; //(reader.IsDBNull(reader.GetOrdinal("LineNum")))?(int)0:(System.Int32)reader["LineNum"];
					c.ItemId = (System.Guid)reader["ItemId"];
					c.Quantity = (System.Int32)reader["Quantity"];
					c.UnitPrice = (System.Decimal)reader["UnitPrice"];
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
		/// Refreshes the <see cref="netTiers.Petshop.Entities.LineItem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.LineItem"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.LineItem entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderId = (System.Int32)reader["OrderId"];
			entity.OriginalOrderId = (System.Int32)reader["OrderId"];
			entity.LineNum = (System.Int32)reader["LineNum"];
			entity.OriginalLineNum = (System.Int32)reader["LineNum"];
			entity.ItemId = (System.Guid)reader["ItemId"];
			entity.Quantity = (System.Int32)reader["Quantity"];
			entity.UnitPrice = (System.Decimal)reader["UnitPrice"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.LineItem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.LineItem"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.LineItem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (System.Int32)dataRow["OrderId"];
			entity.OriginalOrderId = (System.Int32)dataRow["OrderId"];
			entity.LineNum = (System.Int32)dataRow["LineNum"];
			entity.OriginalLineNum = (System.Int32)dataRow["LineNum"];
			entity.ItemId = (System.Guid)dataRow["ItemId"];
			entity.Quantity = (System.Int32)dataRow["Quantity"];
			entity.UnitPrice = (System.Decimal)dataRow["UnitPrice"];
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
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.LineItem"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.LineItem Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.LineItem entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
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

			#region ItemIdSource	
			if (CanDeepLoad(entity, "Item", "ItemIdSource", deepLoadType, innerList) 
				&& entity.ItemIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ItemId;
				Item tmpEntity = EntityManager.LocateEntity<Item>(EntityLocator.ConstructKeyFromPkItems(typeof(Item), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ItemIdSource = tmpEntity;
				else
					entity.ItemIdSource = DataRepository.ItemProvider.GetById(entity.ItemId);
			
				if (deep && entity.ItemIdSource != null)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ItemIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.LineItem object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.LineItem instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.LineItem Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.LineItem entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
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
			
			#region ItemIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Item"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Item"] == null))
			{
				if (entity.ItemIdSource != null )
				{			
					DataRepository.ItemProvider.Save(transactionManager, entity.ItemIdSource);
				}
			}
			#endregion 
			#endregion Composite Source Properties

		}
		#endregion
	} // end class
	
	#region LineItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.LineItem</c>
	///</summary>
	public enum LineItemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Orders</c> at OrderIdSource
		///</summary>
		[ChildEntityType(typeof(Orders))]
		Orders,
			
		///<summary>
		/// Composite Property for <c>Item</c> at ItemIdSource
		///</summary>
		[ChildEntityType(typeof(Item))]
		Item,
		}
	
	#endregion LineItemChildEntityTypes
	
	#region LineItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LineItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LineItemFilterBuilder : SqlFilterBuilder<LineItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LineItemFilterBuilder class.
		/// </summary>
		public LineItemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LineItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LineItemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LineItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LineItemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LineItemFilterBuilder
} // end namespace
