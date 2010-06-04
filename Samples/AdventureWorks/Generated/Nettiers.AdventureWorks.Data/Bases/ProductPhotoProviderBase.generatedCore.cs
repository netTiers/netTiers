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
	/// This class is the base class for any <see cref="ProductPhotoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductPhotoProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductPhoto, Nettiers.AdventureWorks.Entities.ProductPhotoKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByProductIdFromProductProductPhoto
		
		/// <summary>
		///		Gets ProductPhoto objects from the datasource by ProductID in the
		///		ProductProductPhoto table. Table ProductPhoto is related to table Product
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of ProductPhoto objects.</returns>
		public TList<ProductPhoto> GetByProductIdFromProductProductPhoto(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromProductProductPhoto(null,_productId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.ProductPhoto objects from the datasource by ProductID in the
		///		ProductProductPhoto table. Table ProductPhoto is related to table Product
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductPhoto objects.</returns>
		public TList<ProductPhoto> GetByProductIdFromProductProductPhoto(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromProductProductPhoto(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductPhoto objects from the datasource by ProductID in the
		///		ProductProductPhoto table. Table ProductPhoto is related to table Product
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductPhoto objects.</returns>
		public TList<ProductPhoto> GetByProductIdFromProductProductPhoto(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromProductProductPhoto(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets ProductPhoto objects from the datasource by ProductID in the
		///		ProductProductPhoto table. Table ProductPhoto is related to table Product
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductPhoto objects.</returns>
		public TList<ProductPhoto> GetByProductIdFromProductProductPhoto(TransactionManager transactionManager, System.Int32 _productId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromProductProductPhoto(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductPhoto objects from the datasource by ProductID in the
		///		ProductProductPhoto table. Table ProductPhoto is related to table Product
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductPhoto objects.</returns>
		public TList<ProductPhoto> GetByProductIdFromProductProductPhoto(System.Int32 _productId,int start, int pageLength, out int count)
		{
			
			return GetByProductIdFromProductProductPhoto(null, _productId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ProductPhoto objects from the datasource by ProductID in the
		///		ProductProductPhoto table. Table ProductPhoto is related to table Product
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductPhoto objects.</returns>
		public abstract TList<ProductPhoto> GetByProductIdFromProductProductPhoto(TransactionManager transactionManager,System.Int32 _productId, int start, int pageLength, out int count);
		
		#endregion GetByProductIdFromProductProductPhoto
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductPhotoKey key)
		{
			return Delete(transactionManager, key.ProductPhotoId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productPhotoId">Primary key for ProductPhoto records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productPhotoId)
		{
			return Delete(null, _productPhotoId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Primary key for ProductPhoto records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productPhotoId);		
		
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
		public override Nettiers.AdventureWorks.Entities.ProductPhoto Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductPhotoKey key, int start, int pageLength)
		{
			return GetByProductPhotoId(transactionManager, key.ProductPhotoId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductPhoto_ProductPhotoID index.
		/// </summary>
		/// <param name="_productPhotoId">Primary key for ProductPhoto records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductPhoto GetByProductPhotoId(System.Int32 _productPhotoId)
		{
			int count = -1;
			return GetByProductPhotoId(null,_productPhotoId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductPhoto_ProductPhotoID index.
		/// </summary>
		/// <param name="_productPhotoId">Primary key for ProductPhoto records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductPhoto GetByProductPhotoId(System.Int32 _productPhotoId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductPhotoId(null, _productPhotoId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductPhoto_ProductPhotoID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Primary key for ProductPhoto records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductPhoto GetByProductPhotoId(TransactionManager transactionManager, System.Int32 _productPhotoId)
		{
			int count = -1;
			return GetByProductPhotoId(transactionManager, _productPhotoId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductPhoto_ProductPhotoID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Primary key for ProductPhoto records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductPhoto GetByProductPhotoId(TransactionManager transactionManager, System.Int32 _productPhotoId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductPhotoId(transactionManager, _productPhotoId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductPhoto_ProductPhotoID index.
		/// </summary>
		/// <param name="_productPhotoId">Primary key for ProductPhoto records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductPhoto GetByProductPhotoId(System.Int32 _productPhotoId, int start, int pageLength, out int count)
		{
			return GetByProductPhotoId(null, _productPhotoId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductPhoto_ProductPhotoID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Primary key for ProductPhoto records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductPhoto GetByProductPhotoId(TransactionManager transactionManager, System.Int32 _productPhotoId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductPhoto&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductPhoto&gt;"/></returns>
		public static TList<ProductPhoto> Fill(IDataReader reader, TList<ProductPhoto> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductPhoto c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductPhoto")
					.Append("|").Append((System.Int32)reader[((int)ProductPhotoColumn.ProductPhotoId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductPhoto>(
					key.ToString(), // EntityTrackingKey
					"ProductPhoto",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductPhoto();
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
					c.ProductPhotoId = (System.Int32)reader[((int)ProductPhotoColumn.ProductPhotoId - 1)];
					c.ThumbNailPhoto = (reader.IsDBNull(((int)ProductPhotoColumn.ThumbNailPhoto - 1)))?null:(System.Byte[])reader[((int)ProductPhotoColumn.ThumbNailPhoto - 1)];
					c.ThumbnailPhotoFileName = (reader.IsDBNull(((int)ProductPhotoColumn.ThumbnailPhotoFileName - 1)))?null:(System.String)reader[((int)ProductPhotoColumn.ThumbnailPhotoFileName - 1)];
					c.LargePhoto = (reader.IsDBNull(((int)ProductPhotoColumn.LargePhoto - 1)))?null:(System.Byte[])reader[((int)ProductPhotoColumn.LargePhoto - 1)];
					c.LargePhotoFileName = (reader.IsDBNull(((int)ProductPhotoColumn.LargePhotoFileName - 1)))?null:(System.String)reader[((int)ProductPhotoColumn.LargePhotoFileName - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ProductPhotoColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductPhoto entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductPhotoId = (System.Int32)reader[((int)ProductPhotoColumn.ProductPhotoId - 1)];
			entity.ThumbNailPhoto = (reader.IsDBNull(((int)ProductPhotoColumn.ThumbNailPhoto - 1)))?null:(System.Byte[])reader[((int)ProductPhotoColumn.ThumbNailPhoto - 1)];
			entity.ThumbnailPhotoFileName = (reader.IsDBNull(((int)ProductPhotoColumn.ThumbnailPhotoFileName - 1)))?null:(System.String)reader[((int)ProductPhotoColumn.ThumbnailPhotoFileName - 1)];
			entity.LargePhoto = (reader.IsDBNull(((int)ProductPhotoColumn.LargePhoto - 1)))?null:(System.Byte[])reader[((int)ProductPhotoColumn.LargePhoto - 1)];
			entity.LargePhotoFileName = (reader.IsDBNull(((int)ProductPhotoColumn.LargePhotoFileName - 1)))?null:(System.String)reader[((int)ProductPhotoColumn.LargePhotoFileName - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductPhotoColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductPhoto entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductPhotoId = (System.Int32)dataRow["ProductPhotoID"];
			entity.ThumbNailPhoto = Convert.IsDBNull(dataRow["ThumbNailPhoto"]) ? null : (System.Byte[])dataRow["ThumbNailPhoto"];
			entity.ThumbnailPhotoFileName = Convert.IsDBNull(dataRow["ThumbnailPhotoFileName"]) ? null : (System.String)dataRow["ThumbnailPhotoFileName"];
			entity.LargePhoto = Convert.IsDBNull(dataRow["LargePhoto"]) ? null : (System.Byte[])dataRow["LargePhoto"];
			entity.LargePhotoFileName = Convert.IsDBNull(dataRow["LargePhotoFileName"]) ? null : (System.String)dataRow["LargePhotoFileName"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductPhoto"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductPhoto Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductPhoto entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProductPhotoId methods when available
			
			#region ProductIdProductCollection_From_ProductProductPhoto
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Product>|ProductIdProductCollection_From_ProductProductPhoto", deepLoadType, innerList))
			{
				entity.ProductIdProductCollection_From_ProductProductPhoto = DataRepository.ProductProvider.GetByProductPhotoIdFromProductProductPhoto(transactionManager, entity.ProductPhotoId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdProductCollection_From_ProductProductPhoto' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdProductCollection_From_ProductProductPhoto != null)
				{
					deepHandles.Add("ProductIdProductCollection_From_ProductProductPhoto",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Product >) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_ProductProductPhoto, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ProductProductPhotoCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductProductPhoto>|ProductProductPhotoCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductProductPhotoCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductProductPhotoCollection = DataRepository.ProductProductPhotoProvider.GetByProductPhotoId(transactionManager, entity.ProductPhotoId);

				if (deep && entity.ProductProductPhotoCollection.Count > 0)
				{
					deepHandles.Add("ProductProductPhotoCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductProductPhoto>) DataRepository.ProductProductPhotoProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductProductPhotoCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductPhoto object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductPhoto instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductPhoto Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductPhoto entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductIdProductCollection_From_ProductProductPhoto>
			if (CanDeepSave(entity.ProductIdProductCollection_From_ProductProductPhoto, "List<Product>|ProductIdProductCollection_From_ProductProductPhoto", deepSaveType, innerList))
			{
				if (entity.ProductIdProductCollection_From_ProductProductPhoto.Count > 0 || entity.ProductIdProductCollection_From_ProductProductPhoto.DeletedItems.Count > 0)
				{
					DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdProductCollection_From_ProductProductPhoto); 
					deepHandles.Add("ProductIdProductCollection_From_ProductProductPhoto",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Product>) DataRepository.ProductProvider.DeepSave,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_ProductProductPhoto, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<ProductProductPhoto>
				if (CanDeepSave(entity.ProductProductPhotoCollection, "List<ProductProductPhoto>|ProductProductPhotoCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductProductPhoto child in entity.ProductProductPhotoCollection)
					{
						if(child.ProductPhotoIdSource != null)
						{
								child.ProductPhotoId = child.ProductPhotoIdSource.ProductPhotoId;
						}

						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

					}

					if (entity.ProductProductPhotoCollection.Count > 0 || entity.ProductProductPhotoCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductProductPhotoProvider.Save(transactionManager, entity.ProductProductPhotoCollection);
						
						deepHandles.Add("ProductProductPhotoCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductProductPhoto >) DataRepository.ProductProductPhotoProvider.DeepSave,
							new object[] { transactionManager, entity.ProductProductPhotoCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProductPhotoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductPhoto</c>
	///</summary>
	public enum ProductPhotoChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ProductPhoto</c> as ManyToMany for ProductCollection_From_ProductProductPhoto
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductIdProductCollection_From_ProductProductPhoto,

		///<summary>
		/// Collection of <c>ProductPhoto</c> as OneToMany for ProductProductPhotoCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductProductPhoto>))]
		ProductProductPhotoCollection,
	}
	
	#endregion ProductPhotoChildEntityTypes
	
	#region ProductPhotoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductPhotoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductPhotoFilterBuilder : SqlFilterBuilder<ProductPhotoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductPhotoFilterBuilder class.
		/// </summary>
		public ProductPhotoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductPhotoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductPhotoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductPhotoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductPhotoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductPhotoFilterBuilder
	
	#region ProductPhotoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductPhotoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductPhotoParameterBuilder : ParameterizedSqlFilterBuilder<ProductPhotoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductPhotoParameterBuilder class.
		/// </summary>
		public ProductPhotoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductPhotoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductPhotoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductPhotoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductPhotoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductPhotoParameterBuilder
	
	#region ProductPhotoSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductPhotoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductPhoto"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductPhotoSortBuilder : SqlSortBuilder<ProductPhotoColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductPhotoSqlSortBuilder class.
		/// </summary>
		public ProductPhotoSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductPhotoSortBuilder
	
} // end namespace
