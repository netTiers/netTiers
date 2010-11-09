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
	/// This class is the base class for any <see cref="ProductCostHistoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductCostHistoryProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductCostHistory, Nettiers.AdventureWorks.Entities.ProductCostHistoryKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductCostHistoryKey key)
		{
			return Delete(transactionManager, key.ProductId, key.StartDate);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID. Primary Key.</param>
		/// <param name="_startDate">Product cost start date.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productId, System.DateTime _startDate)
		{
			return Delete(null, _productId, _startDate);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID. Primary Key.</param>
		/// <param name="_startDate">Product cost start date.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productId, System.DateTime _startDate);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductCostHistory_Product_ProductID key.
		///		FK_ProductCostHistory_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductCostHistory objects.</returns>
		public TList<ProductCostHistory> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(_productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductCostHistory_Product_ProductID key.
		///		FK_ProductCostHistory_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductCostHistory objects.</returns>
		/// <remarks></remarks>
		public TList<ProductCostHistory> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductCostHistory_Product_ProductID key.
		///		FK_ProductCostHistory_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductCostHistory objects.</returns>
		public TList<ProductCostHistory> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductCostHistory_Product_ProductID key.
		///		fkProductCostHistoryProductProductId Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductCostHistory objects.</returns>
		public TList<ProductCostHistory> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductCostHistory_Product_ProductID key.
		///		fkProductCostHistoryProductProductId Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductCostHistory objects.</returns>
		public TList<ProductCostHistory> GetByProductId(System.Int32 _productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductCostHistory_Product_ProductID key.
		///		FK_ProductCostHistory_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductCostHistory objects.</returns>
		public abstract TList<ProductCostHistory> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.ProductCostHistory Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductCostHistoryKey key, int start, int pageLength)
		{
			return GetByProductIdStartDate(transactionManager, key.ProductId, key.StartDate, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductCostHistory_ProductID_StartDate index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="_startDate">Product cost start date.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductCostHistory GetByProductIdStartDate(System.Int32 _productId, System.DateTime _startDate)
		{
			int count = -1;
			return GetByProductIdStartDate(null,_productId, _startDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCostHistory_ProductID_StartDate index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="_startDate">Product cost start date.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductCostHistory GetByProductIdStartDate(System.Int32 _productId, System.DateTime _startDate, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdStartDate(null, _productId, _startDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCostHistory_ProductID_StartDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="_startDate">Product cost start date.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductCostHistory GetByProductIdStartDate(TransactionManager transactionManager, System.Int32 _productId, System.DateTime _startDate)
		{
			int count = -1;
			return GetByProductIdStartDate(transactionManager, _productId, _startDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCostHistory_ProductID_StartDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="_startDate">Product cost start date.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductCostHistory GetByProductIdStartDate(TransactionManager transactionManager, System.Int32 _productId, System.DateTime _startDate, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdStartDate(transactionManager, _productId, _startDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCostHistory_ProductID_StartDate index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="_startDate">Product cost start date.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductCostHistory GetByProductIdStartDate(System.Int32 _productId, System.DateTime _startDate, int start, int pageLength, out int count)
		{
			return GetByProductIdStartDate(null, _productId, _startDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCostHistory_ProductID_StartDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID</param>
		/// <param name="_startDate">Product cost start date.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductCostHistory GetByProductIdStartDate(TransactionManager transactionManager, System.Int32 _productId, System.DateTime _startDate, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductCostHistory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductCostHistory&gt;"/></returns>
		public static TList<ProductCostHistory> Fill(IDataReader reader, TList<ProductCostHistory> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductCostHistory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductCostHistory")
					.Append("|").Append((System.Int32)reader[((int)ProductCostHistoryColumn.ProductId - 1)])
					.Append("|").Append((System.DateTime)reader[((int)ProductCostHistoryColumn.StartDate - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductCostHistory>(
					key.ToString(), // EntityTrackingKey
					"ProductCostHistory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductCostHistory();
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
					c.ProductId = (System.Int32)reader[((int)ProductCostHistoryColumn.ProductId - 1)];
					c.OriginalProductId = c.ProductId;
					c.StartDate = (System.DateTime)reader[((int)ProductCostHistoryColumn.StartDate - 1)];
					c.OriginalStartDate = c.StartDate;
					c.EndDate = (reader.IsDBNull(((int)ProductCostHistoryColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)ProductCostHistoryColumn.EndDate - 1)];
					c.StandardCost = (System.Decimal)reader[((int)ProductCostHistoryColumn.StandardCost - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ProductCostHistoryColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductCostHistory entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductId = (System.Int32)reader[((int)ProductCostHistoryColumn.ProductId - 1)];
			entity.OriginalProductId = (System.Int32)reader["ProductID"];
			entity.StartDate = (System.DateTime)reader[((int)ProductCostHistoryColumn.StartDate - 1)];
			entity.OriginalStartDate = (System.DateTime)reader["StartDate"];
			entity.EndDate = (reader.IsDBNull(((int)ProductCostHistoryColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)ProductCostHistoryColumn.EndDate - 1)];
			entity.StandardCost = (System.Decimal)reader[((int)ProductCostHistoryColumn.StandardCost - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductCostHistoryColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductCostHistory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OriginalProductId = (System.Int32)dataRow["ProductID"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.OriginalStartDate = (System.DateTime)dataRow["StartDate"];
			entity.EndDate = Convert.IsDBNull(dataRow["EndDate"]) ? null : (System.DateTime?)dataRow["EndDate"];
			entity.StandardCost = (System.Decimal)dataRow["StandardCost"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductCostHistory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductCostHistory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductCostHistory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductCostHistory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductCostHistory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductCostHistory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductCostHistory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ProductCostHistoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductCostHistory</c>
	///</summary>
	public enum ProductCostHistoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
		}
	
	#endregion ProductCostHistoryChildEntityTypes
	
	#region ProductCostHistoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductCostHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCostHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCostHistoryFilterBuilder : SqlFilterBuilder<ProductCostHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryFilterBuilder class.
		/// </summary>
		public ProductCostHistoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCostHistoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCostHistoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCostHistoryFilterBuilder
	
	#region ProductCostHistoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductCostHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCostHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCostHistoryParameterBuilder : ParameterizedSqlFilterBuilder<ProductCostHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryParameterBuilder class.
		/// </summary>
		public ProductCostHistoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCostHistoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCostHistoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCostHistoryParameterBuilder
	
	#region ProductCostHistorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductCostHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCostHistory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductCostHistorySortBuilder : SqlSortBuilder<ProductCostHistoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCostHistorySqlSortBuilder class.
		/// </summary>
		public ProductCostHistorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductCostHistorySortBuilder
	
} // end namespace
