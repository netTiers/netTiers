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
	/// This class is the base class for any <see cref="OrderStatusTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderStatusTypeProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.OrderStatusType, netTiers.Petshop.Entities.OrderStatusTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.OrderStatusTypeKey key)
		{
			return Delete(transactionManager, key.OrderStatusId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="orderStatusId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 orderStatusId)
		{
			return Delete(null, orderStatusId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatusId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 orderStatusId);		
		
		#endregion
		
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
		public override netTiers.Petshop.Entities.OrderStatusType Get(TransactionManager transactionManager, netTiers.Petshop.Entities.OrderStatusTypeKey key, int start, int pageLength)
		{
			return GetByOrderStatusId(transactionManager, key.OrderStatusId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__OrderStatusType__7C8480AE index.
		/// </summary>
		/// <param name="orderStatusId"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatusId(System.Int32 orderStatusId)
		{
			int count = -1;
			return GetByOrderStatusId(null,orderStatusId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__OrderStatusType__7C8480AE index.
		/// </summary>
		/// <param name="orderStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatusId(System.Int32 orderStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStatusId(null, orderStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__OrderStatusType__7C8480AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatusId(TransactionManager transactionManager, System.Int32 orderStatusId)
		{
			int count = -1;
			return GetByOrderStatusId(transactionManager, orderStatusId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__OrderStatusType__7C8480AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatusId(TransactionManager transactionManager, System.Int32 orderStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStatusId(transactionManager, orderStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__OrderStatusType__7C8480AE index.
		/// </summary>
		/// <param name="orderStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatusId(System.Int32 orderStatusId, int start, int pageLength, out int count)
		{
			return GetByOrderStatusId(null, orderStatusId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__OrderStatusType__7C8480AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public abstract netTiers.Petshop.Entities.OrderStatusType GetByOrderStatusId(TransactionManager transactionManager, System.Int32 orderStatusId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_OrderStatusType index.
		/// </summary>
		/// <param name="orderStatus"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatus(System.String orderStatus)
		{
			int count = -1;
			return GetByOrderStatus(null,orderStatus, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_OrderStatusType index.
		/// </summary>
		/// <param name="orderStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatus(System.String orderStatus, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStatus(null, orderStatus, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_OrderStatusType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatus"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatus(TransactionManager transactionManager, System.String orderStatus)
		{
			int count = -1;
			return GetByOrderStatus(transactionManager, orderStatus, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_OrderStatusType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatus(TransactionManager transactionManager, System.String orderStatus, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStatus(transactionManager, orderStatus, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_OrderStatusType index.
		/// </summary>
		/// <param name="orderStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public netTiers.Petshop.Entities.OrderStatusType GetByOrderStatus(System.String orderStatus, int start, int pageLength, out int count)
		{
			return GetByOrderStatus(null, orderStatus, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_OrderStatusType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> class.</returns>
		public abstract netTiers.Petshop.Entities.OrderStatusType GetByOrderStatus(TransactionManager transactionManager, System.String orderStatus, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;OrderStatusType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;OrderStatusType&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<OrderStatusType> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<OrderStatusType> rows, int start, int pageLength)
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
				
				netTiers.Petshop.Entities.OrderStatusType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"OrderStatusType" 
							+ (reader.IsDBNull(reader.GetOrdinal("OrderStatusId"))?(int)0:(System.Int32)reader["OrderStatusId"]).ToString();

					c = EntityManager.LocateOrCreate<OrderStatusType>(
						key.ToString(), // EntityTrackingKey 
						"OrderStatusType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.OrderStatusType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.OrderStatusId = (System.Int32)reader["OrderStatusId"];
					c.OrderStatus = (System.String)reader["OrderStatus"];
					c.OrderStatusDescription = (reader.IsDBNull(reader.GetOrdinal("OrderStatusDescription")))?null:(System.String)reader["OrderStatusDescription"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.OrderStatusType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.OrderStatusType entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderStatusId = (System.Int32)reader["OrderStatusId"];
			entity.OrderStatus = (System.String)reader["OrderStatus"];
			entity.OrderStatusDescription = (reader.IsDBNull(reader.GetOrdinal("OrderStatusDescription")))?null:(System.String)reader["OrderStatusDescription"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.OrderStatusType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.OrderStatusType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.OrderStatusType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderStatusId = (System.Int32)dataRow["OrderStatusId"];
			entity.OrderStatus = (System.String)dataRow["OrderStatus"];
			entity.OrderStatusDescription = (Convert.IsDBNull(dataRow["OrderStatusDescription"]))?null:(System.String)dataRow["OrderStatusDescription"];
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
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.OrderStatusType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.OrderStatusType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.OrderStatusType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByOrderStatusId methods when available
			
			#region OrderStatusCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<OrderStatus>", "OrderStatusCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderStatusCollection' loaded.");
				#endif 

				entity.OrderStatusCollection = DataRepository.OrderStatusProvider.GetByOrderStatusId(transactionManager, entity.OrderStatusId);

				if (deep && entity.OrderStatusCollection.Count > 0)
				{
					DataRepository.OrderStatusProvider.DeepLoad(transactionManager, entity.OrderStatusCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.OrderStatusType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.OrderStatusType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.OrderStatusType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.OrderStatusType entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Source Properties


			#region List<OrderStatus>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<OrderStatus>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<OrderStatus>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(OrderStatus child in entity.OrderStatusCollection)
			{
					child.OrderStatusId = entity.OrderStatusId;			}
			
			if (entity.OrderStatusCollection.Count > 0)
				DataRepository.OrderStatusProvider.DeepSave(transactionManager, entity.OrderStatusCollection, deepSaveType, childTypes);
			} 
			#endregion 
		}
		#endregion
	} // end class
	
	#region OrderStatusTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.OrderStatusType</c>
	///</summary>
	public enum OrderStatusTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>OrderStatusType</c> as OneToMany for OrderStatusCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderStatus>))]
		OrderStatusCollection,
	}
	
	#endregion OrderStatusTypeChildEntityTypes
	
	#region OrderStatusTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatusType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusTypeFilterBuilder : SqlFilterBuilder<OrderStatusTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeFilterBuilder class.
		/// </summary>
		public OrderStatusTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStatusTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStatusTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStatusTypeFilterBuilder
} // end namespace
