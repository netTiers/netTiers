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
	/// This class is the base class for any <see cref="ProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.Product, netTiers.Petshop.Entities.ProductKey>
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
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.ProductKey key)
		{
			return Delete(transactionManager, key.Id, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid id, byte[] timestamp)
		{
			return Delete(null, id, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid id, byte[] timestamp);		
		
		#endregion
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		FK_Product_Category Description: 
		/// </summary>
		/// <param name="categoryId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Product objects.</returns>
		public netTiers.Petshop.Entities.TList<Product> GetByCategoryId(System.Guid categoryId)
		{
			int count = -1;
			return GetByCategoryId(categoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		FK_Product_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Product> GetByCategoryId(TransactionManager transactionManager, System.Guid categoryId)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, categoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		FK_Product_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Product objects.</returns>
		public netTiers.Petshop.Entities.TList<Product> GetByCategoryId(TransactionManager transactionManager, System.Guid categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		fK_Product_Category Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Product objects.</returns>
		public netTiers.Petshop.Entities.TList<Product> GetByCategoryId(System.Guid categoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCategoryId(null, categoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		fK_Product_Category Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="categoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Product objects.</returns>
		public netTiers.Petshop.Entities.TList<Product> GetByCategoryId(System.Guid categoryId, int start, int pageLength,out int count)
		{
			return GetByCategoryId(null, categoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		FK_Product_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Product objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Product> GetByCategoryId(TransactionManager transactionManager, System.Guid categoryId, int start, int pageLength, out int count);
		
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
		public override netTiers.Petshop.Entities.Product Get(TransactionManager transactionManager, netTiers.Petshop.Entities.ProductKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Product index.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Product"/> class.</returns>
		public netTiers.Petshop.Entities.Product GetById(System.Guid id)
		{
			int count = -1;
			return GetById(null,id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Product"/> class.</returns>
		public netTiers.Petshop.Entities.Product GetById(System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Product"/> class.</returns>
		public netTiers.Petshop.Entities.Product GetById(TransactionManager transactionManager, System.Guid id)
		{
			int count = -1;
			return GetById(transactionManager, id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Product"/> class.</returns>
		public netTiers.Petshop.Entities.Product GetById(TransactionManager transactionManager, System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Product"/> class.</returns>
		public netTiers.Petshop.Entities.Product GetById(System.Guid id, int start, int pageLength, out int count)
		{
			return GetById(null, id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Product"/> class.</returns>
		public abstract netTiers.Petshop.Entities.Product GetById(TransactionManager transactionManager, System.Guid id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;Product&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;Product&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<Product> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<Product> rows, int start, int pageLength)
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
				
				netTiers.Petshop.Entities.Product c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Product" 
							+ (reader.IsDBNull(reader.GetOrdinal("Id"))?Guid.Empty:(System.Guid)reader["Id"]).ToString();

					c = EntityManager.LocateOrCreate<Product>(
						key.ToString(), // EntityTrackingKey 
						"Product",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.Product();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.Id = (System.Guid)reader["Id"];
					c.OriginalId = c.Id; //(reader.IsDBNull(reader.GetOrdinal("Id")))?Guid.Empty:(System.Guid)reader["Id"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.CategoryId = (System.Guid)reader["CategoryId"];
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
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Product"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Product"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.Product entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Guid)reader["Id"];
			entity.OriginalId = (System.Guid)reader["Id"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.CategoryId = (System.Guid)reader["CategoryId"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Product"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Product"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.Product entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Guid)dataRow["Id"];
			entity.OriginalId = (System.Guid)dataRow["Id"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.CategoryId = (System.Guid)dataRow["CategoryId"];
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
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Product"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Product Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.Product entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region CategoryIdSource	
			if (CanDeepLoad(entity, "Category", "CategoryIdSource", deepLoadType, innerList) 
				&& entity.CategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CategoryId;
				Category tmpEntity = EntityManager.LocateEntity<Category>(EntityLocator.ConstructKeyFromPkItems(typeof(Category), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CategoryIdSource = tmpEntity;
				else
					entity.CategoryIdSource = DataRepository.CategoryProvider.GetById(entity.CategoryId);
			
				if (deep && entity.CategoryIdSource != null)
				{
					DataRepository.CategoryProvider.DeepLoad(transactionManager, entity.CategoryIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CategoryIdSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetById methods when available
			
			#region ItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Item>", "ItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemCollection' loaded.");
				#endif 

				entity.ItemCollection = DataRepository.ItemProvider.GetByProductId(transactionManager, entity.Id);

				if (deep && entity.ItemCollection.Count > 0)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.Product object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.Product instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Product Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.Product entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CategoryIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Category"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Category"] == null))
			{
				if (entity.CategoryIdSource != null )
				{			
					DataRepository.CategoryProvider.Save(transactionManager, entity.CategoryIdSource);
				}
			}
			#endregion 
			#endregion Composite Source Properties


			#region List<Item>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<Item>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<Item>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(Item child in entity.ItemCollection)
			{
					child.ProductId = entity.Id;			}
			
			if (entity.ItemCollection.Count > 0)
				DataRepository.ItemProvider.DeepSave(transactionManager, entity.ItemCollection, deepSaveType, childTypes);
			} 
			#endregion 
		}
		#endregion
	} // end class
	
	#region ProductChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.Product</c>
	///</summary>
	public enum ProductChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Category</c> at CategoryIdSource
		///</summary>
		[ChildEntityType(typeof(Category))]
		Category,
	
		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<Item>))]
		ItemCollection,
	}
	
	#endregion ProductChildEntityTypes
	
	#region ProductFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductFilterBuilder : SqlFilterBuilder<ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		public ProductFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductFilterBuilder
} // end namespace
