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
	/// This class is the base class for any <see cref="LineItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LineItemProviderBaseCore : EntityProviderBase<PetShop.Business.LineItem, PetShop.Business.LineItemKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.LineItemKey key)
		{
			return Delete(transactionManager, key.OrderId, key.LineNum);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_orderId">. Primary Key.</param>
		/// <param name="_lineNum">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(int _orderId, int _lineNum)
		{
			return Delete(null, _orderId, _lineNum);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId">. Primary Key.</param>
		/// <param name="_lineNum">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, int _orderId, int _lineNum);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__03317E3D key.
		///		FK__LineItem__OrderI__03317E3D Description: 
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of PetShop.Business.LineItem objects.</returns>
		public TList<LineItem> GetByOrderId(int _orderId)
		{
			int count = -1;
			return GetByOrderId(_orderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__03317E3D key.
		///		FK__LineItem__OrderI__03317E3D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of PetShop.Business.LineItem objects.</returns>
		/// <remarks></remarks>
		public TList<LineItem> GetByOrderId(TransactionManager transactionManager, int _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__03317E3D key.
		///		FK__LineItem__OrderI__03317E3D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.LineItem objects.</returns>
		public TList<LineItem> GetByOrderId(TransactionManager transactionManager, int _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__03317E3D key.
		///		fkLineItemOrderi03317e3d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.LineItem objects.</returns>
		public TList<LineItem> GetByOrderId(int _orderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderId(null, _orderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__03317E3D key.
		///		fkLineItemOrderi03317e3d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.LineItem objects.</returns>
		public TList<LineItem> GetByOrderId(int _orderId, int start, int pageLength,out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__03317E3D key.
		///		FK__LineItem__OrderI__03317E3D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of PetShop.Business.LineItem objects.</returns>
		public abstract TList<LineItem> GetByOrderId(TransactionManager transactionManager, int _orderId, int start, int pageLength, out int count);
		
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
		public override PetShop.Business.LineItem Get(TransactionManager transactionManager, PetShop.Business.LineItemKey key, int start, int pageLength)
		{
			return GetByOrderIdLineNum(transactionManager, key.OrderId, key.LineNum, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PkLineItem index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="_lineNum"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.LineItem"/> class.</returns>
		public PetShop.Business.LineItem GetByOrderIdLineNum(int _orderId, int _lineNum)
		{
			int count = -1;
			return GetByOrderIdLineNum(null,_orderId, _lineNum, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="_lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.LineItem"/> class.</returns>
		public PetShop.Business.LineItem GetByOrderIdLineNum(int _orderId, int _lineNum, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderIdLineNum(null, _orderId, _lineNum, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="_lineNum"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.LineItem"/> class.</returns>
		public PetShop.Business.LineItem GetByOrderIdLineNum(TransactionManager transactionManager, int _orderId, int _lineNum)
		{
			int count = -1;
			return GetByOrderIdLineNum(transactionManager, _orderId, _lineNum, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="_lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.LineItem"/> class.</returns>
		public PetShop.Business.LineItem GetByOrderIdLineNum(TransactionManager transactionManager, int _orderId, int _lineNum, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderIdLineNum(transactionManager, _orderId, _lineNum, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="_lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.LineItem"/> class.</returns>
		public PetShop.Business.LineItem GetByOrderIdLineNum(int _orderId, int _lineNum, int start, int pageLength, out int count)
		{
			return GetByOrderIdLineNum(null, _orderId, _lineNum, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="_lineNum"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.LineItem"/> class.</returns>
		public abstract PetShop.Business.LineItem GetByOrderIdLineNum(TransactionManager transactionManager, int _orderId, int _lineNum, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;LineItem&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;LineItem&gt;"/></returns>
		public static TList<LineItem> Fill(IDataReader reader, TList<LineItem> rows, int start, int pageLength)
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
				
				PetShop.Business.LineItem c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("LineItem")
					.Append("|").Append((int)reader[((int)LineItemColumn.OrderId - 1)])
					.Append("|").Append((int)reader[((int)LineItemColumn.LineNum - 1)]).ToString();
					c = EntityManager.LocateOrCreate<LineItem>(
					key.ToString(), // EntityTrackingKey
					"LineItem",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.LineItem();
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
					c.OrderId = (int)reader[((int)LineItemColumn.OrderId - 1)];
					c.OriginalOrderId = c.OrderId;
					c.LineNum = (int)reader[((int)LineItemColumn.LineNum - 1)];
					c.OriginalLineNum = c.LineNum;
					c.ItemId = (string)reader[((int)LineItemColumn.ItemId - 1)];
					c.Quantity = (int)reader[((int)LineItemColumn.Quantity - 1)];
					c.UnitPrice = (decimal)reader[((int)LineItemColumn.UnitPrice - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.LineItem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.LineItem"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.LineItem entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderId = (int)reader[((int)LineItemColumn.OrderId - 1)];
			entity.OriginalOrderId = (int)reader["OrderId"];
			entity.LineNum = (int)reader[((int)LineItemColumn.LineNum - 1)];
			entity.OriginalLineNum = (int)reader["LineNum"];
			entity.ItemId = (string)reader[((int)LineItemColumn.ItemId - 1)];
			entity.Quantity = (int)reader[((int)LineItemColumn.Quantity - 1)];
			entity.UnitPrice = (decimal)reader[((int)LineItemColumn.UnitPrice - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.LineItem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.LineItem"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.LineItem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (int)dataRow["OrderId"];
			entity.OriginalOrderId = (int)dataRow["OrderId"];
			entity.LineNum = (int)dataRow["LineNum"];
			entity.OriginalLineNum = (int)dataRow["LineNum"];
			entity.ItemId = (string)dataRow["ItemId"];
			entity.Quantity = (int)dataRow["Quantity"];
			entity.UnitPrice = (decimal)dataRow["UnitPrice"];
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
		/// <param name="entity">The <see cref="PetShop.Business.LineItem"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.LineItem Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.LineItem entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region OrderIdSource	
			if (CanDeepLoad(entity, "Order|OrderIdSource", deepLoadType, innerList) 
				&& entity.OrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.OrderId;
				Order tmpEntity = EntityManager.LocateEntity<Order>(EntityLocator.ConstructKeyFromPkItems(typeof(Order), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderIdSource = tmpEntity;
				else
					entity.OrderIdSource = DataRepository.OrderProvider.GetByOrderId(transactionManager, entity.OrderId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.OrderProvider.DeepLoad(transactionManager, entity.OrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OrderIdSource
			
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
		/// Deep Save the entire object graph of the PetShop.Business.LineItem object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.LineItem instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.LineItem Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.LineItem entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region OrderIdSource
			if (CanDeepSave(entity, "Order|OrderIdSource", deepSaveType, innerList) 
				&& entity.OrderIdSource != null)
			{
				DataRepository.OrderProvider.Save(transactionManager, entity.OrderIdSource);
				entity.OrderId = entity.OrderIdSource.OrderId;
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
	
	#region LineItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.LineItem</c>
	///</summary>
	public enum LineItemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Order</c> at OrderIdSource
		///</summary>
		[ChildEntityType(typeof(Order))]
		Order,
		}
	
	#endregion LineItemChildEntityTypes
	
	#region LineItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LineItemColumn&gt;"/> class
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
	
	#region LineItemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LineItemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LineItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LineItemParameterBuilder : ParameterizedSqlFilterBuilder<LineItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LineItemParameterBuilder class.
		/// </summary>
		public LineItemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LineItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LineItemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LineItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LineItemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LineItemParameterBuilder
	
	#region LineItemSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;LineItemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LineItem"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class LineItemSortBuilder : SqlSortBuilder<LineItemColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LineItemSqlSortBuilder class.
		/// </summary>
		public LineItemSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion LineItemSortBuilder
	
} // end namespace
