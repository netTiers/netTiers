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
	/// This class is the base class for any <see cref="CartProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CartProviderBaseCore : EntityProviderBase<PetShop.Business.Cart, PetShop.Business.CartKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.CartKey key)
		{
			return Delete(transactionManager, key.CartId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_cartId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(int _cartId)
		{
			return Delete(null, _cartId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cartId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, int _cartId);		
		
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
		public override PetShop.Business.Cart Get(TransactionManager transactionManager, PetShop.Business.CartKey key, int start, int pageLength)
		{
			return GetByCartId(transactionManager, key.CartId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key FK_Cart_UniqueID index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByUniqueId(int _uniqueId)
		{
			int count = -1;
			return GetByUniqueId(null,_uniqueId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cart_UniqueID index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByUniqueId(int _uniqueId, int start, int pageLength)
		{
			int count = -1;
			return GetByUniqueId(null, _uniqueId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cart_UniqueID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByUniqueId(TransactionManager transactionManager, int _uniqueId)
		{
			int count = -1;
			return GetByUniqueId(transactionManager, _uniqueId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cart_UniqueID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByUniqueId(TransactionManager transactionManager, int _uniqueId, int start, int pageLength)
		{
			int count = -1;
			return GetByUniqueId(transactionManager, _uniqueId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cart_UniqueID index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByUniqueId(int _uniqueId, int start, int pageLength, out int count)
		{
			return GetByUniqueId(null, _uniqueId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cart_UniqueID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public abstract TList<Cart> GetByUniqueId(TransactionManager transactionManager, int _uniqueId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SHOPPINGCART index.
		/// </summary>
		/// <param name="_isShoppingCart"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByIsShoppingCart(bool _isShoppingCart)
		{
			int count = -1;
			return GetByIsShoppingCart(null,_isShoppingCart, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SHOPPINGCART index.
		/// </summary>
		/// <param name="_isShoppingCart"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByIsShoppingCart(bool _isShoppingCart, int start, int pageLength)
		{
			int count = -1;
			return GetByIsShoppingCart(null, _isShoppingCart, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SHOPPINGCART index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_isShoppingCart"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByIsShoppingCart(TransactionManager transactionManager, bool _isShoppingCart)
		{
			int count = -1;
			return GetByIsShoppingCart(transactionManager, _isShoppingCart, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SHOPPINGCART index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_isShoppingCart"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByIsShoppingCart(TransactionManager transactionManager, bool _isShoppingCart, int start, int pageLength)
		{
			int count = -1;
			return GetByIsShoppingCart(transactionManager, _isShoppingCart, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SHOPPINGCART index.
		/// </summary>
		/// <param name="_isShoppingCart"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public TList<Cart> GetByIsShoppingCart(bool _isShoppingCart, int start, int pageLength, out int count)
		{
			return GetByIsShoppingCart(null, _isShoppingCart, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SHOPPINGCART index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_isShoppingCart"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Cart&gt;"/> class.</returns>
		public abstract TList<Cart> GetByIsShoppingCart(TransactionManager transactionManager, bool _isShoppingCart, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Cart index.
		/// </summary>
		/// <param name="_cartId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Cart"/> class.</returns>
		public PetShop.Business.Cart GetByCartId(int _cartId)
		{
			int count = -1;
			return GetByCartId(null,_cartId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cart index.
		/// </summary>
		/// <param name="_cartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Cart"/> class.</returns>
		public PetShop.Business.Cart GetByCartId(int _cartId, int start, int pageLength)
		{
			int count = -1;
			return GetByCartId(null, _cartId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cartId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Cart"/> class.</returns>
		public PetShop.Business.Cart GetByCartId(TransactionManager transactionManager, int _cartId)
		{
			int count = -1;
			return GetByCartId(transactionManager, _cartId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Cart"/> class.</returns>
		public PetShop.Business.Cart GetByCartId(TransactionManager transactionManager, int _cartId, int start, int pageLength)
		{
			int count = -1;
			return GetByCartId(transactionManager, _cartId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cart index.
		/// </summary>
		/// <param name="_cartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Cart"/> class.</returns>
		public PetShop.Business.Cart GetByCartId(int _cartId, int start, int pageLength, out int count)
		{
			return GetByCartId(null, _cartId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Cart"/> class.</returns>
		public abstract PetShop.Business.Cart GetByCartId(TransactionManager transactionManager, int _cartId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Cart&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Cart&gt;"/></returns>
		public static TList<Cart> Fill(IDataReader reader, TList<Cart> rows, int start, int pageLength)
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
				
				PetShop.Business.Cart c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Cart")
					.Append("|").Append((int)reader[((int)CartColumn.CartId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Cart>(
					key.ToString(), // EntityTrackingKey
					"Cart",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Cart();
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
					c.CartId = (int)reader[((int)CartColumn.CartId - 1)];
					c.UniqueId = (int)reader[((int)CartColumn.UniqueId - 1)];
					c.ItemId = (string)reader[((int)CartColumn.ItemId - 1)];
					c.Name = (string)reader[((int)CartColumn.Name - 1)];
					c.Type = (string)reader[((int)CartColumn.Type - 1)];
					c.Price = (decimal)reader[((int)CartColumn.Price - 1)];
					c.CategoryId = (string)reader[((int)CartColumn.CategoryId - 1)];
					c.ProductId = (string)reader[((int)CartColumn.ProductId - 1)];
					c.IsShoppingCart = (bool)reader[((int)CartColumn.IsShoppingCart - 1)];
					c.Quantity = (int)reader[((int)CartColumn.Quantity - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Cart"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Cart"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Cart entity)
		{
			if (!reader.Read()) return;
			
			entity.CartId = (int)reader[((int)CartColumn.CartId - 1)];
			entity.UniqueId = (int)reader[((int)CartColumn.UniqueId - 1)];
			entity.ItemId = (string)reader[((int)CartColumn.ItemId - 1)];
			entity.Name = (string)reader[((int)CartColumn.Name - 1)];
			entity.Type = (string)reader[((int)CartColumn.Type - 1)];
			entity.Price = (decimal)reader[((int)CartColumn.Price - 1)];
			entity.CategoryId = (string)reader[((int)CartColumn.CategoryId - 1)];
			entity.ProductId = (string)reader[((int)CartColumn.ProductId - 1)];
			entity.IsShoppingCart = (bool)reader[((int)CartColumn.IsShoppingCart - 1)];
			entity.Quantity = (int)reader[((int)CartColumn.Quantity - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Cart"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Cart"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Cart entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CartId = (int)dataRow["CartId"];
			entity.UniqueId = (int)dataRow["UniqueID"];
			entity.ItemId = (string)dataRow["ItemId"];
			entity.Name = (string)dataRow["Name"];
			entity.Type = (string)dataRow["Type"];
			entity.Price = (decimal)dataRow["Price"];
			entity.CategoryId = (string)dataRow["CategoryId"];
			entity.ProductId = (string)dataRow["ProductId"];
			entity.IsShoppingCart = (bool)dataRow["IsShoppingCart"];
			entity.Quantity = (int)dataRow["Quantity"];
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
		/// <param name="entity">The <see cref="PetShop.Business.Cart"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Cart Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Cart entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region UniqueIdSource	
			if (CanDeepLoad(entity, "Profile|UniqueIdSource", deepLoadType, innerList) 
				&& entity.UniqueIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.UniqueId;
				Profile tmpEntity = EntityManager.LocateEntity<Profile>(EntityLocator.ConstructKeyFromPkItems(typeof(Profile), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UniqueIdSource = tmpEntity;
				else
					entity.UniqueIdSource = DataRepository.ProfileProvider.GetByUniqueId(transactionManager, entity.UniqueId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UniqueIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UniqueIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProfileProvider.DeepLoad(transactionManager, entity.UniqueIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UniqueIdSource
			
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
		/// Deep Save the entire object graph of the PetShop.Business.Cart object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Cart instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Cart Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Cart entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region UniqueIdSource
			if (CanDeepSave(entity, "Profile|UniqueIdSource", deepSaveType, innerList) 
				&& entity.UniqueIdSource != null)
			{
				DataRepository.ProfileProvider.Save(transactionManager, entity.UniqueIdSource);
				entity.UniqueId = entity.UniqueIdSource.UniqueId;
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
	
	#region CartChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Cart</c>
	///</summary>
	public enum CartChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Profile</c> at UniqueIdSource
		///</summary>
		[ChildEntityType(typeof(Profile))]
		Profile,
		}
	
	#endregion CartChildEntityTypes
	
	#region CartFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CartColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CartFilterBuilder : SqlFilterBuilder<CartColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CartFilterBuilder class.
		/// </summary>
		public CartFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CartFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CartFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CartFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CartFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CartFilterBuilder
	
	#region CartParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CartColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CartParameterBuilder : ParameterizedSqlFilterBuilder<CartColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CartParameterBuilder class.
		/// </summary>
		public CartParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CartParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CartParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CartParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CartParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CartParameterBuilder
	
	#region CartSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CartColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cart"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CartSortBuilder : SqlSortBuilder<CartColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CartSqlSortBuilder class.
		/// </summary>
		public CartSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CartSortBuilder
	
} // end namespace
