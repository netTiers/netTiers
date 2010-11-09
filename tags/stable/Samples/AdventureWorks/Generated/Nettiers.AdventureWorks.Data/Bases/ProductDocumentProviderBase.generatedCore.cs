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
	/// This class is the base class for any <see cref="ProductDocumentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductDocumentProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductDocument, Nettiers.AdventureWorks.Entities.ProductDocumentKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDocumentKey key)
		{
			return Delete(transactionManager, key.ProductId, key.DocumentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productId, System.Int32 _documentId)
		{
			return Delete(null, _productId, _documentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _documentId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Document_DocumentID key.
		///		FK_ProductDocument_Document_DocumentID Description: Foreign key constraint referencing Document.DocumentID.
		/// </summary>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public TList<ProductDocument> GetByDocumentId(System.Int32 _documentId)
		{
			int count = -1;
			return GetByDocumentId(_documentId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Document_DocumentID key.
		///		FK_ProductDocument_Document_DocumentID Description: Foreign key constraint referencing Document.DocumentID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		/// <remarks></remarks>
		public TList<ProductDocument> GetByDocumentId(TransactionManager transactionManager, System.Int32 _documentId)
		{
			int count = -1;
			return GetByDocumentId(transactionManager, _documentId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Document_DocumentID key.
		///		FK_ProductDocument_Document_DocumentID Description: Foreign key constraint referencing Document.DocumentID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public TList<ProductDocument> GetByDocumentId(TransactionManager transactionManager, System.Int32 _documentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDocumentId(transactionManager, _documentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Document_DocumentID key.
		///		fkProductDocumentDocumentDocumentId Description: Foreign key constraint referencing Document.DocumentID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public TList<ProductDocument> GetByDocumentId(System.Int32 _documentId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDocumentId(null, _documentId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Document_DocumentID key.
		///		fkProductDocumentDocumentDocumentId Description: Foreign key constraint referencing Document.DocumentID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public TList<ProductDocument> GetByDocumentId(System.Int32 _documentId, int start, int pageLength,out int count)
		{
			return GetByDocumentId(null, _documentId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Document_DocumentID key.
		///		FK_ProductDocument_Document_DocumentID Description: Foreign key constraint referencing Document.DocumentID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public abstract TList<ProductDocument> GetByDocumentId(TransactionManager transactionManager, System.Int32 _documentId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Product_ProductID key.
		///		FK_ProductDocument_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public TList<ProductDocument> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(_productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Product_ProductID key.
		///		FK_ProductDocument_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		/// <remarks></remarks>
		public TList<ProductDocument> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Product_ProductID key.
		///		FK_ProductDocument_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public TList<ProductDocument> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Product_ProductID key.
		///		fkProductDocumentProductProductId Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public TList<ProductDocument> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Product_ProductID key.
		///		fkProductDocumentProductProductId Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public TList<ProductDocument> GetByProductId(System.Int32 _productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Product_ProductID key.
		///		FK_ProductDocument_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public abstract TList<ProductDocument> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.ProductDocument Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDocumentKey key, int start, int pageLength)
		{
			return GetByProductIdDocumentId(transactionManager, key.ProductId, key.DocumentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductDocument_ProductID_DocumentID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDocument GetByProductIdDocumentId(System.Int32 _productId, System.Int32 _documentId)
		{
			int count = -1;
			return GetByProductIdDocumentId(null,_productId, _documentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDocument_ProductID_DocumentID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDocument GetByProductIdDocumentId(System.Int32 _productId, System.Int32 _documentId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdDocumentId(null, _productId, _documentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDocument_ProductID_DocumentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDocument GetByProductIdDocumentId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _documentId)
		{
			int count = -1;
			return GetByProductIdDocumentId(transactionManager, _productId, _documentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDocument_ProductID_DocumentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDocument GetByProductIdDocumentId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _documentId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdDocumentId(transactionManager, _productId, _documentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDocument_ProductID_DocumentID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDocument GetByProductIdDocumentId(System.Int32 _productId, System.Int32 _documentId, int start, int pageLength, out int count)
		{
			return GetByProductIdDocumentId(null, _productId, _documentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDocument_ProductID_DocumentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductDocument GetByProductIdDocumentId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _documentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductDocument&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductDocument&gt;"/></returns>
		public static TList<ProductDocument> Fill(IDataReader reader, TList<ProductDocument> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductDocument c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductDocument")
					.Append("|").Append((System.Int32)reader[((int)ProductDocumentColumn.ProductId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ProductDocumentColumn.DocumentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductDocument>(
					key.ToString(), // EntityTrackingKey
					"ProductDocument",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductDocument();
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
					c.ProductId = (System.Int32)reader[((int)ProductDocumentColumn.ProductId - 1)];
					c.OriginalProductId = c.ProductId;
					c.DocumentId = (System.Int32)reader[((int)ProductDocumentColumn.DocumentId - 1)];
					c.OriginalDocumentId = c.DocumentId;
					c.ModifiedDate = (System.DateTime)reader[((int)ProductDocumentColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductDocument entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductId = (System.Int32)reader[((int)ProductDocumentColumn.ProductId - 1)];
			entity.OriginalProductId = (System.Int32)reader["ProductID"];
			entity.DocumentId = (System.Int32)reader[((int)ProductDocumentColumn.DocumentId - 1)];
			entity.OriginalDocumentId = (System.Int32)reader["DocumentID"];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductDocumentColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductDocument entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OriginalProductId = (System.Int32)dataRow["ProductID"];
			entity.DocumentId = (System.Int32)dataRow["DocumentID"];
			entity.OriginalDocumentId = (System.Int32)dataRow["DocumentID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductDocument Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDocument entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DocumentIdSource	
			if (CanDeepLoad(entity, "Document|DocumentIdSource", deepLoadType, innerList) 
				&& entity.DocumentIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DocumentId;
				Document tmpEntity = EntityManager.LocateEntity<Document>(EntityLocator.ConstructKeyFromPkItems(typeof(Document), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DocumentIdSource = tmpEntity;
				else
					entity.DocumentIdSource = DataRepository.DocumentProvider.GetByDocumentId(transactionManager, entity.DocumentId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DocumentIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DocumentIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DocumentProvider.DeepLoad(transactionManager, entity.DocumentIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DocumentIdSource

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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductDocument object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductDocument instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductDocument Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDocument entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DocumentIdSource
			if (CanDeepSave(entity, "Document|DocumentIdSource", deepSaveType, innerList) 
				&& entity.DocumentIdSource != null)
			{
				DataRepository.DocumentProvider.Save(transactionManager, entity.DocumentIdSource);
				entity.DocumentId = entity.DocumentIdSource.DocumentId;
			}
			#endregion 
			
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
	
	#region ProductDocumentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductDocument</c>
	///</summary>
	public enum ProductDocumentChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Document</c> at DocumentIdSource
		///</summary>
		[ChildEntityType(typeof(Document))]
		Document,
			
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
		}
	
	#endregion ProductDocumentChildEntityTypes
	
	#region ProductDocumentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductDocumentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDocumentFilterBuilder : SqlFilterBuilder<ProductDocumentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDocumentFilterBuilder class.
		/// </summary>
		public ProductDocumentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductDocumentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductDocumentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductDocumentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductDocumentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductDocumentFilterBuilder
	
	#region ProductDocumentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductDocumentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDocumentParameterBuilder : ParameterizedSqlFilterBuilder<ProductDocumentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDocumentParameterBuilder class.
		/// </summary>
		public ProductDocumentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductDocumentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductDocumentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductDocumentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductDocumentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductDocumentParameterBuilder
	
	#region ProductDocumentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductDocumentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDocument"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductDocumentSortBuilder : SqlSortBuilder<ProductDocumentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDocumentSqlSortBuilder class.
		/// </summary>
		public ProductDocumentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductDocumentSortBuilder
	
} // end namespace
