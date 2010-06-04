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
	/// This class is the base class for any <see cref="ProductProductPhotoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductProductPhotoProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductProductPhoto, Nettiers.AdventureWorks.Entities.ProductProductPhotoKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductProductPhotoKey key)
		{
			return Delete(transactionManager, key.ProductId, key.ProductPhotoId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productId, System.Int32 _productPhotoId)
		{
			return Delete(null, _productId, _productPhotoId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _productPhotoId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_Product_ProductID key.
		///		FK_ProductProductPhoto_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public TList<ProductProductPhoto> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(_productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_Product_ProductID key.
		///		FK_ProductProductPhoto_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		/// <remarks></remarks>
		public TList<ProductProductPhoto> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_Product_ProductID key.
		///		FK_ProductProductPhoto_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public TList<ProductProductPhoto> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_Product_ProductID key.
		///		fkProductProductPhotoProductProductId Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public TList<ProductProductPhoto> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_Product_ProductID key.
		///		fkProductProductPhotoProductProductId Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public TList<ProductProductPhoto> GetByProductId(System.Int32 _productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_Product_ProductID key.
		///		FK_ProductProductPhoto_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public abstract TList<ProductProductPhoto> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_ProductPhoto_ProductPhotoID key.
		///		FK_ProductProductPhoto_ProductPhoto_ProductPhotoID Description: Foreign key constraint referencing ProductPhoto.ProductPhotoID.
		/// </summary>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public TList<ProductProductPhoto> GetByProductPhotoId(System.Int32 _productPhotoId)
		{
			int count = -1;
			return GetByProductPhotoId(_productPhotoId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_ProductPhoto_ProductPhotoID key.
		///		FK_ProductProductPhoto_ProductPhoto_ProductPhotoID Description: Foreign key constraint referencing ProductPhoto.ProductPhotoID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		/// <remarks></remarks>
		public TList<ProductProductPhoto> GetByProductPhotoId(TransactionManager transactionManager, System.Int32 _productPhotoId)
		{
			int count = -1;
			return GetByProductPhotoId(transactionManager, _productPhotoId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_ProductPhoto_ProductPhotoID key.
		///		FK_ProductProductPhoto_ProductPhoto_ProductPhotoID Description: Foreign key constraint referencing ProductPhoto.ProductPhotoID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public TList<ProductProductPhoto> GetByProductPhotoId(TransactionManager transactionManager, System.Int32 _productPhotoId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductPhotoId(transactionManager, _productPhotoId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_ProductPhoto_ProductPhotoID key.
		///		fkProductProductPhotoProductPhotoProductPhotoId Description: Foreign key constraint referencing ProductPhoto.ProductPhotoID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public TList<ProductProductPhoto> GetByProductPhotoId(System.Int32 _productPhotoId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductPhotoId(null, _productPhotoId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_ProductPhoto_ProductPhotoID key.
		///		fkProductProductPhotoProductPhotoProductPhotoId Description: Foreign key constraint referencing ProductPhoto.ProductPhotoID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public TList<ProductProductPhoto> GetByProductPhotoId(System.Int32 _productPhotoId, int start, int pageLength,out int count)
		{
			return GetByProductPhotoId(null, _productPhotoId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductProductPhoto_ProductPhoto_ProductPhotoID key.
		///		FK_ProductProductPhoto_ProductPhoto_ProductPhotoID Description: Foreign key constraint referencing ProductPhoto.ProductPhotoID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductProductPhoto objects.</returns>
		public abstract TList<ProductProductPhoto> GetByProductPhotoId(TransactionManager transactionManager, System.Int32 _productPhotoId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.ProductProductPhoto Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductProductPhotoKey key, int start, int pageLength)
		{
			return GetByProductIdProductPhotoId(transactionManager, key.ProductId, key.ProductPhotoId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductProductPhoto_ProductID_ProductPhotoID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductProductPhoto GetByProductIdProductPhotoId(System.Int32 _productId, System.Int32 _productPhotoId)
		{
			int count = -1;
			return GetByProductIdProductPhotoId(null,_productId, _productPhotoId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductProductPhoto_ProductID_ProductPhotoID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductProductPhoto GetByProductIdProductPhotoId(System.Int32 _productId, System.Int32 _productPhotoId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdProductPhotoId(null, _productId, _productPhotoId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductProductPhoto_ProductID_ProductPhotoID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductProductPhoto GetByProductIdProductPhotoId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _productPhotoId)
		{
			int count = -1;
			return GetByProductIdProductPhotoId(transactionManager, _productId, _productPhotoId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductProductPhoto_ProductID_ProductPhotoID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductProductPhoto GetByProductIdProductPhotoId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _productPhotoId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdProductPhotoId(transactionManager, _productId, _productPhotoId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductProductPhoto_ProductID_ProductPhotoID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductProductPhoto GetByProductIdProductPhotoId(System.Int32 _productId, System.Int32 _productPhotoId, int start, int pageLength, out int count)
		{
			return GetByProductIdProductPhotoId(null, _productId, _productPhotoId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductProductPhoto_ProductID_ProductPhotoID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductProductPhoto GetByProductIdProductPhotoId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _productPhotoId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductProductPhoto&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductProductPhoto&gt;"/></returns>
		public static TList<ProductProductPhoto> Fill(IDataReader reader, TList<ProductProductPhoto> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductProductPhoto c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductProductPhoto")
					.Append("|").Append((System.Int32)reader[((int)ProductProductPhotoColumn.ProductId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ProductProductPhotoColumn.ProductPhotoId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductProductPhoto>(
					key.ToString(), // EntityTrackingKey
					"ProductProductPhoto",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductProductPhoto();
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
					c.ProductId = (System.Int32)reader[((int)ProductProductPhotoColumn.ProductId - 1)];
					c.OriginalProductId = c.ProductId;
					c.ProductPhotoId = (System.Int32)reader[((int)ProductProductPhotoColumn.ProductPhotoId - 1)];
					c.OriginalProductPhotoId = c.ProductPhotoId;
					c.Primary = (System.Boolean)reader[((int)ProductProductPhotoColumn.Primary - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ProductProductPhotoColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductProductPhoto entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductId = (System.Int32)reader[((int)ProductProductPhotoColumn.ProductId - 1)];
			entity.OriginalProductId = (System.Int32)reader["ProductID"];
			entity.ProductPhotoId = (System.Int32)reader[((int)ProductProductPhotoColumn.ProductPhotoId - 1)];
			entity.OriginalProductPhotoId = (System.Int32)reader["ProductPhotoID"];
			entity.Primary = (System.Boolean)reader[((int)ProductProductPhotoColumn.Primary - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductProductPhotoColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductProductPhoto entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OriginalProductId = (System.Int32)dataRow["ProductID"];
			entity.ProductPhotoId = (System.Int32)dataRow["ProductPhotoID"];
			entity.OriginalProductPhotoId = (System.Int32)dataRow["ProductPhotoID"];
			entity.Primary = (System.Boolean)dataRow["Primary"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductProductPhoto"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductProductPhoto Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductProductPhoto entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductPhotoIdSource	
			if (CanDeepLoad(entity, "ProductPhoto|ProductPhotoIdSource", deepLoadType, innerList) 
				&& entity.ProductPhotoIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductPhotoId;
				ProductPhoto tmpEntity = EntityManager.LocateEntity<ProductPhoto>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductPhoto), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductPhotoIdSource = tmpEntity;
				else
					entity.ProductPhotoIdSource = DataRepository.ProductPhotoProvider.GetByProductPhotoId(transactionManager, entity.ProductPhotoId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductPhotoIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductPhotoIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductPhotoProvider.DeepLoad(transactionManager, entity.ProductPhotoIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductPhotoIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductProductPhoto object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductProductPhoto instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductProductPhoto Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductProductPhoto entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region ProductPhotoIdSource
			if (CanDeepSave(entity, "ProductPhoto|ProductPhotoIdSource", deepSaveType, innerList) 
				&& entity.ProductPhotoIdSource != null)
			{
				DataRepository.ProductPhotoProvider.Save(transactionManager, entity.ProductPhotoIdSource);
				entity.ProductPhotoId = entity.ProductPhotoIdSource.ProductPhotoId;
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
	
	#region ProductProductPhotoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductProductPhoto</c>
	///</summary>
	public enum ProductProductPhotoChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>ProductPhoto</c> at ProductPhotoIdSource
		///</summary>
		[ChildEntityType(typeof(ProductPhoto))]
		ProductPhoto,
		}
	
	#endregion ProductProductPhotoChildEntityTypes
	
	#region ProductProductPhotoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductProductPhotoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductProductPhotoFilterBuilder : SqlFilterBuilder<ProductProductPhotoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoFilterBuilder class.
		/// </summary>
		public ProductProductPhotoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductProductPhotoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductProductPhotoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductProductPhotoFilterBuilder
	
	#region ProductProductPhotoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductProductPhotoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductProductPhotoParameterBuilder : ParameterizedSqlFilterBuilder<ProductProductPhotoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoParameterBuilder class.
		/// </summary>
		public ProductProductPhotoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductProductPhotoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductProductPhotoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductProductPhotoParameterBuilder
	
	#region ProductProductPhotoSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductProductPhotoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductProductPhoto"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductProductPhotoSortBuilder : SqlSortBuilder<ProductProductPhotoColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoSqlSortBuilder class.
		/// </summary>
		public ProductProductPhotoSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductProductPhotoSortBuilder
	
} // end namespace
