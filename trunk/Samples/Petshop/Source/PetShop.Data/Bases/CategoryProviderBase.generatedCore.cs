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
	/// This class is the base class for any <see cref="CategoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CategoryProviderBaseCore : EntityProviderBase<PetShop.Business.Category, PetShop.Business.CategoryKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.CategoryKey key)
		{
			return Delete(transactionManager, key.CategoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_categoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(string _categoryId)
		{
			return Delete(null, _categoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, string _categoryId);		
		
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
		public override PetShop.Business.Category Get(TransactionManager transactionManager, PetShop.Business.CategoryKey key, int start, int pageLength)
		{
			return GetByCategoryId(transactionManager, key.CategoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Category__19093A0B7F60ED59 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Category"/> class.</returns>
		public PetShop.Business.Category GetByCategoryId(string _categoryId)
		{
			int count = -1;
			return GetByCategoryId(null,_categoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Category__19093A0B7F60ED59 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Category"/> class.</returns>
		public PetShop.Business.Category GetByCategoryId(string _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Category__19093A0B7F60ED59 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Category"/> class.</returns>
		public PetShop.Business.Category GetByCategoryId(TransactionManager transactionManager, string _categoryId)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Category__19093A0B7F60ED59 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Category"/> class.</returns>
		public PetShop.Business.Category GetByCategoryId(TransactionManager transactionManager, string _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Category__19093A0B7F60ED59 index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Category"/> class.</returns>
		public PetShop.Business.Category GetByCategoryId(string _categoryId, int start, int pageLength, out int count)
		{
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Category__19093A0B7F60ED59 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Category"/> class.</returns>
		public abstract PetShop.Business.Category GetByCategoryId(TransactionManager transactionManager, string _categoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Category&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Category&gt;"/></returns>
		public static TList<Category> Fill(IDataReader reader, TList<Category> rows, int start, int pageLength)
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
				
				PetShop.Business.Category c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Category")
					.Append("|").Append((string)reader[((int)CategoryColumn.CategoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Category>(
					key.ToString(), // EntityTrackingKey
					"Category",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Category();
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
					c.CategoryId = (string)reader[((int)CategoryColumn.CategoryId - 1)];
					c.OriginalCategoryId = c.CategoryId;
					c.Name = (reader.IsDBNull(((int)CategoryColumn.Name - 1)))?null:(string)reader[((int)CategoryColumn.Name - 1)];
					c.Descn = (reader.IsDBNull(((int)CategoryColumn.Descn - 1)))?null:(string)reader[((int)CategoryColumn.Descn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Category"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Category"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Category entity)
		{
			if (!reader.Read()) return;
			
			entity.CategoryId = (string)reader[((int)CategoryColumn.CategoryId - 1)];
			entity.OriginalCategoryId = (string)reader["CategoryId"];
			entity.Name = (reader.IsDBNull(((int)CategoryColumn.Name - 1)))?null:(string)reader[((int)CategoryColumn.Name - 1)];
			entity.Descn = (reader.IsDBNull(((int)CategoryColumn.Descn - 1)))?null:(string)reader[((int)CategoryColumn.Descn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Category"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Category"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Category entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CategoryId = (string)dataRow["CategoryId"];
			entity.OriginalCategoryId = (string)dataRow["CategoryId"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (string)dataRow["Name"];
			entity.Descn = Convert.IsDBNull(dataRow["Descn"]) ? null : (string)dataRow["Descn"];
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
		/// <param name="entity">The <see cref="PetShop.Business.Category"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Category Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Category entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCategoryId methods when available
			
			#region ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>|ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductCollection = DataRepository.ProductProvider.GetByCategoryId(transactionManager, entity.CategoryId);

				if (deep && entity.ProductCollection.Count > 0)
				{
					deepHandles.Add("ProductCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Product>) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the PetShop.Business.Category object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Category instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Category Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Category entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Product>
				if (CanDeepSave(entity.ProductCollection, "List<Product>|ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollection)
					{
						if(child.CategoryIdSource != null)
						{
							child.CategoryId = child.CategoryIdSource.CategoryId;
						}
						else
						{
							child.CategoryId = entity.CategoryId;
						}

					}

					if (entity.ProductCollection.Count > 0 || entity.ProductCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductProvider.Save(transactionManager, entity.ProductCollection);
						
						deepHandles.Add("ProductCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Product >) DataRepository.ProductProvider.DeepSave,
							new object[] { transactionManager, entity.ProductCollection, deepSaveType, childTypes, innerList }
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
	
	#region CategoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Category</c>
	///</summary>
	public enum CategoryChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Category</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollection,
	}
	
	#endregion CategoryChildEntityTypes
	
	#region CategoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Category"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoryFilterBuilder : SqlFilterBuilder<CategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoryFilterBuilder class.
		/// </summary>
		public CategoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoryFilterBuilder
	
	#region CategoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Category"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoryParameterBuilder : ParameterizedSqlFilterBuilder<CategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoryParameterBuilder class.
		/// </summary>
		public CategoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoryParameterBuilder
	
	#region CategorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Category"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CategorySortBuilder : SqlSortBuilder<CategoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategorySqlSortBuilder class.
		/// </summary>
		public CategorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CategorySortBuilder
	
} // end namespace
