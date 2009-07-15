#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using PetShop.Business;
using PetShop.Data;

#endregion

namespace PetShop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="OrderProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderProviderBaseCore : EntityProviderBase<PetShop.Business.Order, PetShop.Business.OrderKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.OrderKey key)
		{
			return Delete(transactionManager, key.OrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_orderId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(int _orderId)
		{
			return Delete(null, _orderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, int _orderId);		
		
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
		public override PetShop.Business.Order Get(TransactionManager transactionManager, PetShop.Business.OrderKey key, int start, int pageLength)
		{
			return GetByOrderId(transactionManager, key.OrderId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Orders__C3905BCF7F60ED59 index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Order"/> class.</returns>
		public PetShop.Business.Order GetByOrderId(int _orderId)
		{
			int count = -1;
			return GetByOrderId(null,_orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__C3905BCF7F60ED59 index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Order"/> class.</returns>
		public PetShop.Business.Order GetByOrderId(int _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(null, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__C3905BCF7F60ED59 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Order"/> class.</returns>
		public PetShop.Business.Order GetByOrderId(TransactionManager transactionManager, int _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__C3905BCF7F60ED59 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Order"/> class.</returns>
		public PetShop.Business.Order GetByOrderId(TransactionManager transactionManager, int _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__C3905BCF7F60ED59 index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Order"/> class.</returns>
		public PetShop.Business.Order GetByOrderId(int _orderId, int start, int pageLength, out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__C3905BCF7F60ED59 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Order"/> class.</returns>
		public abstract PetShop.Business.Order GetByOrderId(TransactionManager transactionManager, int _orderId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Order&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Order&gt;"/></returns>
		public static TList<Order> Fill(IDataReader reader, TList<Order> rows, int start, int pageLength)
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
				
				PetShop.Business.Order c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Order")
					.Append("|").Append((int)reader[((int)OrderColumn.OrderId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Order>(
					key.ToString(), // EntityTrackingKey
					"Order",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Order();
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
					c.OrderId = (int)reader[((int)OrderColumn.OrderId - 1)];
					c.UserId = (string)reader[((int)OrderColumn.UserId - 1)];
					c.OrderDate = (System.DateTime)reader[((int)OrderColumn.OrderDate - 1)];
					c.ShipAddr1 = (string)reader[((int)OrderColumn.ShipAddr1 - 1)];
					c.ShipAddr2 = (reader.IsDBNull(((int)OrderColumn.ShipAddr2 - 1)))?null:(string)reader[((int)OrderColumn.ShipAddr2 - 1)];
					c.ShipCity = (string)reader[((int)OrderColumn.ShipCity - 1)];
					c.ShipState = (string)reader[((int)OrderColumn.ShipState - 1)];
					c.ShipZip = (string)reader[((int)OrderColumn.ShipZip - 1)];
					c.ShipCountry = (string)reader[((int)OrderColumn.ShipCountry - 1)];
					c.BillAddr1 = (string)reader[((int)OrderColumn.BillAddr1 - 1)];
					c.BillAddr2 = (reader.IsDBNull(((int)OrderColumn.BillAddr2 - 1)))?null:(string)reader[((int)OrderColumn.BillAddr2 - 1)];
					c.BillCity = (string)reader[((int)OrderColumn.BillCity - 1)];
					c.BillState = (string)reader[((int)OrderColumn.BillState - 1)];
					c.BillZip = (string)reader[((int)OrderColumn.BillZip - 1)];
					c.BillCountry = (string)reader[((int)OrderColumn.BillCountry - 1)];
					c.Courier = (string)reader[((int)OrderColumn.Courier - 1)];
					c.TotalPrice = (decimal)reader[((int)OrderColumn.TotalPrice - 1)];
					c.BillToFirstName = (string)reader[((int)OrderColumn.BillToFirstName - 1)];
					c.BillToLastName = (string)reader[((int)OrderColumn.BillToLastName - 1)];
					c.ShipToFirstName = (string)reader[((int)OrderColumn.ShipToFirstName - 1)];
					c.ShipToLastName = (string)reader[((int)OrderColumn.ShipToLastName - 1)];
					c.AuthorizationNumber = (int)reader[((int)OrderColumn.AuthorizationNumber - 1)];
					c.Locale = (string)reader[((int)OrderColumn.Locale - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Order"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Order"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Order entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderId = (int)reader[((int)OrderColumn.OrderId - 1)];
			entity.UserId = (string)reader[((int)OrderColumn.UserId - 1)];
			entity.OrderDate = (System.DateTime)reader[((int)OrderColumn.OrderDate - 1)];
			entity.ShipAddr1 = (string)reader[((int)OrderColumn.ShipAddr1 - 1)];
			entity.ShipAddr2 = (reader.IsDBNull(((int)OrderColumn.ShipAddr2 - 1)))?null:(string)reader[((int)OrderColumn.ShipAddr2 - 1)];
			entity.ShipCity = (string)reader[((int)OrderColumn.ShipCity - 1)];
			entity.ShipState = (string)reader[((int)OrderColumn.ShipState - 1)];
			entity.ShipZip = (string)reader[((int)OrderColumn.ShipZip - 1)];
			entity.ShipCountry = (string)reader[((int)OrderColumn.ShipCountry - 1)];
			entity.BillAddr1 = (string)reader[((int)OrderColumn.BillAddr1 - 1)];
			entity.BillAddr2 = (reader.IsDBNull(((int)OrderColumn.BillAddr2 - 1)))?null:(string)reader[((int)OrderColumn.BillAddr2 - 1)];
			entity.BillCity = (string)reader[((int)OrderColumn.BillCity - 1)];
			entity.BillState = (string)reader[((int)OrderColumn.BillState - 1)];
			entity.BillZip = (string)reader[((int)OrderColumn.BillZip - 1)];
			entity.BillCountry = (string)reader[((int)OrderColumn.BillCountry - 1)];
			entity.Courier = (string)reader[((int)OrderColumn.Courier - 1)];
			entity.TotalPrice = (decimal)reader[((int)OrderColumn.TotalPrice - 1)];
			entity.BillToFirstName = (string)reader[((int)OrderColumn.BillToFirstName - 1)];
			entity.BillToLastName = (string)reader[((int)OrderColumn.BillToLastName - 1)];
			entity.ShipToFirstName = (string)reader[((int)OrderColumn.ShipToFirstName - 1)];
			entity.ShipToLastName = (string)reader[((int)OrderColumn.ShipToLastName - 1)];
			entity.AuthorizationNumber = (int)reader[((int)OrderColumn.AuthorizationNumber - 1)];
			entity.Locale = (string)reader[((int)OrderColumn.Locale - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Order"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Order"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Order entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (int)dataRow["OrderId"];
			entity.UserId = (string)dataRow["UserId"];
			entity.OrderDate = (System.DateTime)dataRow["OrderDate"];
			entity.ShipAddr1 = (string)dataRow["ShipAddr1"];
			entity.ShipAddr2 = Convert.IsDBNull(dataRow["ShipAddr2"]) ? null : (string)dataRow["ShipAddr2"];
			entity.ShipCity = (string)dataRow["ShipCity"];
			entity.ShipState = (string)dataRow["ShipState"];
			entity.ShipZip = (string)dataRow["ShipZip"];
			entity.ShipCountry = (string)dataRow["ShipCountry"];
			entity.BillAddr1 = (string)dataRow["BillAddr1"];
			entity.BillAddr2 = Convert.IsDBNull(dataRow["BillAddr2"]) ? null : (string)dataRow["BillAddr2"];
			entity.BillCity = (string)dataRow["BillCity"];
			entity.BillState = (string)dataRow["BillState"];
			entity.BillZip = (string)dataRow["BillZip"];
			entity.BillCountry = (string)dataRow["BillCountry"];
			entity.Courier = (string)dataRow["Courier"];
			entity.TotalPrice = (decimal)dataRow["TotalPrice"];
			entity.BillToFirstName = (string)dataRow["BillToFirstName"];
			entity.BillToLastName = (string)dataRow["BillToLastName"];
			entity.ShipToFirstName = (string)dataRow["ShipToFirstName"];
			entity.ShipToLastName = (string)dataRow["ShipToLastName"];
			entity.AuthorizationNumber = (int)dataRow["AuthorizationNumber"];
			entity.Locale = (string)dataRow["Locale"];
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
		/// <param name="entity">The <see cref="PetShop.Business.Order"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Order Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Order entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByOrderId methods when available
			
			#region LineItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<LineItem>|LineItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LineItemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LineItemCollection = DataRepository.LineItemProvider.GetByOrderId(transactionManager, entity.OrderId);

				if (deep && entity.LineItemCollection.Count > 0)
				{
					deepHandles.Add("LineItemCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<LineItem>) DataRepository.LineItemProvider.DeepLoad,
						new object[] { transactionManager, entity.LineItemCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region OrderStatusCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<OrderStatus>|OrderStatusCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderStatusCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OrderStatusCollection = DataRepository.OrderStatusProvider.GetByOrderId(transactionManager, entity.OrderId);

				if (deep && entity.OrderStatusCollection.Count > 0)
				{
					deepHandles.Add("OrderStatusCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<OrderStatus>) DataRepository.OrderStatusProvider.DeepLoad,
						new object[] { transactionManager, entity.OrderStatusCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the PetShop.Business.Order object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Order instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Order Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Order entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<LineItem>
				if (CanDeepSave(entity.LineItemCollection, "List<LineItem>|LineItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(LineItem child in entity.LineItemCollection)
					{
						if(child.OrderIdSource != null)
						{
							child.OrderId = child.OrderIdSource.OrderId;
						}
						else
						{
							child.OrderId = entity.OrderId;
						}

					}

					if (entity.LineItemCollection.Count > 0 || entity.LineItemCollection.DeletedItems.Count > 0)
					{
						//DataRepository.LineItemProvider.Save(transactionManager, entity.LineItemCollection);
						
						deepHandles.Add("LineItemCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< LineItem >) DataRepository.LineItemProvider.DeepSave,
							new object[] { transactionManager, entity.LineItemCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<OrderStatus>
				if (CanDeepSave(entity.OrderStatusCollection, "List<OrderStatus>|OrderStatusCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(OrderStatus child in entity.OrderStatusCollection)
					{
						if(child.OrderIdSource != null)
						{
							child.OrderId = child.OrderIdSource.OrderId;
						}
						else
						{
							child.OrderId = entity.OrderId;
						}

					}

					if (entity.OrderStatusCollection.Count > 0 || entity.OrderStatusCollection.DeletedItems.Count > 0)
					{
						//DataRepository.OrderStatusProvider.Save(transactionManager, entity.OrderStatusCollection);
						
						deepHandles.Add("OrderStatusCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< OrderStatus >) DataRepository.OrderStatusProvider.DeepSave,
							new object[] { transactionManager, entity.OrderStatusCollection, deepSaveType, childTypes, innerList }
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
	
	#region OrderChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Order</c>
	///</summary>
	public enum OrderChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Order</c> as OneToMany for LineItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<LineItem>))]
		LineItemCollection,

		///<summary>
		/// Collection of <c>Order</c> as OneToMany for OrderStatusCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderStatus>))]
		OrderStatusCollection,
	}
	
	#endregion OrderChildEntityTypes
	
	#region OrderFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Order"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderFilterBuilder : SqlFilterBuilder<OrderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderFilterBuilder class.
		/// </summary>
		public OrderFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderFilterBuilder
	
	#region OrderParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Order"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderParameterBuilder : ParameterizedSqlFilterBuilder<OrderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderParameterBuilder class.
		/// </summary>
		public OrderParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderParameterBuilder
	
	#region OrderSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;OrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Order"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrderSortBuilder : SqlSortBuilder<OrderColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderSqlSortBuilder class.
		/// </summary>
		public OrderSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrderSortBuilder
	
} // end namespace
