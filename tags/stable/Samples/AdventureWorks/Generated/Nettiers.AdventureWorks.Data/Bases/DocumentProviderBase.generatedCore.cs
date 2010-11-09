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
	/// This class is the base class for any <see cref="DocumentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DocumentProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Document, Nettiers.AdventureWorks.Entities.DocumentKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByProductIdFromProductDocument
		
		/// <summary>
		///		Gets Document objects from the datasource by ProductID in the
		///		ProductDocument table. Table Document is related to table Product
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Document objects.</returns>
		public TList<Document> GetByProductIdFromProductDocument(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromProductDocument(null,_productId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Document objects from the datasource by ProductID in the
		///		ProductDocument table. Table Document is related to table Product
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Document objects.</returns>
		public TList<Document> GetByProductIdFromProductDocument(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromProductDocument(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Document objects from the datasource by ProductID in the
		///		ProductDocument table. Table Document is related to table Product
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Document objects.</returns>
		public TList<Document> GetByProductIdFromProductDocument(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromProductDocument(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Document objects from the datasource by ProductID in the
		///		ProductDocument table. Table Document is related to table Product
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Document objects.</returns>
		public TList<Document> GetByProductIdFromProductDocument(TransactionManager transactionManager, System.Int32 _productId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromProductDocument(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Document objects from the datasource by ProductID in the
		///		ProductDocument table. Table Document is related to table Product
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Document objects.</returns>
		public TList<Document> GetByProductIdFromProductDocument(System.Int32 _productId,int start, int pageLength, out int count)
		{
			
			return GetByProductIdFromProductDocument(null, _productId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Document objects from the datasource by ProductID in the
		///		ProductDocument table. Table Document is related to table Product
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Document objects.</returns>
		public abstract TList<Document> GetByProductIdFromProductDocument(TransactionManager transactionManager,System.Int32 _productId, int start, int pageLength, out int count);
		
		#endregion GetByProductIdFromProductDocument
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.DocumentKey key)
		{
			return Delete(transactionManager, key.DocumentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_documentId">Primary key for Document records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _documentId)
		{
			return Delete(null, _documentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Primary key for Document records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _documentId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Document Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.DocumentKey key, int start, int pageLength)
		{
			return GetByDocumentId(transactionManager, key.DocumentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Document_FileName_Revision index.
		/// </summary>
		/// <param name="_fileName">Directory path and file name of the document</param>
		/// <param name="_revision">Revision number of the document. </param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByFileNameRevision(System.String _fileName, System.String _revision)
		{
			int count = -1;
			return GetByFileNameRevision(null,_fileName, _revision, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Document_FileName_Revision index.
		/// </summary>
		/// <param name="_fileName">Directory path and file name of the document</param>
		/// <param name="_revision">Revision number of the document. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByFileNameRevision(System.String _fileName, System.String _revision, int start, int pageLength)
		{
			int count = -1;
			return GetByFileNameRevision(null, _fileName, _revision, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Document_FileName_Revision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileName">Directory path and file name of the document</param>
		/// <param name="_revision">Revision number of the document. </param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByFileNameRevision(TransactionManager transactionManager, System.String _fileName, System.String _revision)
		{
			int count = -1;
			return GetByFileNameRevision(transactionManager, _fileName, _revision, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Document_FileName_Revision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileName">Directory path and file name of the document</param>
		/// <param name="_revision">Revision number of the document. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByFileNameRevision(TransactionManager transactionManager, System.String _fileName, System.String _revision, int start, int pageLength)
		{
			int count = -1;
			return GetByFileNameRevision(transactionManager, _fileName, _revision, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Document_FileName_Revision index.
		/// </summary>
		/// <param name="_fileName">Directory path and file name of the document</param>
		/// <param name="_revision">Revision number of the document. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByFileNameRevision(System.String _fileName, System.String _revision, int start, int pageLength, out int count)
		{
			return GetByFileNameRevision(null, _fileName, _revision, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Document_FileName_Revision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileName">Directory path and file name of the document</param>
		/// <param name="_revision">Revision number of the document. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Document GetByFileNameRevision(TransactionManager transactionManager, System.String _fileName, System.String _revision, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Document_DocumentID index.
		/// </summary>
		/// <param name="_documentId">Primary key for Document records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByDocumentId(System.Int32 _documentId)
		{
			int count = -1;
			return GetByDocumentId(null,_documentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Document_DocumentID index.
		/// </summary>
		/// <param name="_documentId">Primary key for Document records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByDocumentId(System.Int32 _documentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDocumentId(null, _documentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Document_DocumentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Primary key for Document records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByDocumentId(TransactionManager transactionManager, System.Int32 _documentId)
		{
			int count = -1;
			return GetByDocumentId(transactionManager, _documentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Document_DocumentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Primary key for Document records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByDocumentId(TransactionManager transactionManager, System.Int32 _documentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDocumentId(transactionManager, _documentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Document_DocumentID index.
		/// </summary>
		/// <param name="_documentId">Primary key for Document records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Document GetByDocumentId(System.Int32 _documentId, int start, int pageLength, out int count)
		{
			return GetByDocumentId(null, _documentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Document_DocumentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Primary key for Document records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Document"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Document GetByDocumentId(TransactionManager transactionManager, System.Int32 _documentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Document&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Document&gt;"/></returns>
		public static TList<Document> Fill(IDataReader reader, TList<Document> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Document c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Document")
					.Append("|").Append((System.Int32)reader[((int)DocumentColumn.DocumentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Document>(
					key.ToString(), // EntityTrackingKey
					"Document",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Document();
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
					c.DocumentId = (System.Int32)reader[((int)DocumentColumn.DocumentId - 1)];
					c.Title = (System.String)reader[((int)DocumentColumn.Title - 1)];
					c.FileName = (System.String)reader[((int)DocumentColumn.FileName - 1)];
					c.FileExtension = (System.String)reader[((int)DocumentColumn.FileExtension - 1)];
					c.Revision = (System.String)reader[((int)DocumentColumn.Revision - 1)];
					c.ChangeNumber = (System.Int32)reader[((int)DocumentColumn.ChangeNumber - 1)];
					c.Status = (System.Byte)reader[((int)DocumentColumn.Status - 1)];
					c.DocumentSummary = (reader.IsDBNull(((int)DocumentColumn.DocumentSummary - 1)))?null:(System.String)reader[((int)DocumentColumn.DocumentSummary - 1)];
					c.Document = (reader.IsDBNull(((int)DocumentColumn.Document - 1)))?null:(System.Byte[])reader[((int)DocumentColumn.Document - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)DocumentColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Document"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Document"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Document entity)
		{
			if (!reader.Read()) return;
			
			entity.DocumentId = (System.Int32)reader[((int)DocumentColumn.DocumentId - 1)];
			entity.Title = (System.String)reader[((int)DocumentColumn.Title - 1)];
			entity.FileName = (System.String)reader[((int)DocumentColumn.FileName - 1)];
			entity.FileExtension = (System.String)reader[((int)DocumentColumn.FileExtension - 1)];
			entity.Revision = (System.String)reader[((int)DocumentColumn.Revision - 1)];
			entity.ChangeNumber = (System.Int32)reader[((int)DocumentColumn.ChangeNumber - 1)];
			entity.Status = (System.Byte)reader[((int)DocumentColumn.Status - 1)];
			entity.DocumentSummary = (reader.IsDBNull(((int)DocumentColumn.DocumentSummary - 1)))?null:(System.String)reader[((int)DocumentColumn.DocumentSummary - 1)];
			entity.Document = (reader.IsDBNull(((int)DocumentColumn.Document - 1)))?null:(System.Byte[])reader[((int)DocumentColumn.Document - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)DocumentColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Document"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Document"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Document entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DocumentId = (System.Int32)dataRow["DocumentID"];
			entity.Title = (System.String)dataRow["Title"];
			entity.FileName = (System.String)dataRow["FileName"];
			entity.FileExtension = (System.String)dataRow["FileExtension"];
			entity.Revision = (System.String)dataRow["Revision"];
			entity.ChangeNumber = (System.Int32)dataRow["ChangeNumber"];
			entity.Status = (System.Byte)dataRow["Status"];
			entity.DocumentSummary = Convert.IsDBNull(dataRow["DocumentSummary"]) ? null : (System.String)dataRow["DocumentSummary"];
			entity.Document = Convert.IsDBNull(dataRow["Document"]) ? null : (System.Byte[])dataRow["Document"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Document"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Document Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Document entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDocumentId methods when available
			
			#region ProductDocumentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductDocument>|ProductDocumentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductDocumentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductDocumentCollection = DataRepository.ProductDocumentProvider.GetByDocumentId(transactionManager, entity.DocumentId);

				if (deep && entity.ProductDocumentCollection.Count > 0)
				{
					deepHandles.Add("ProductDocumentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductDocument>) DataRepository.ProductDocumentProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductDocumentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductIdProductCollection_From_ProductDocument
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Product>|ProductIdProductCollection_From_ProductDocument", deepLoadType, innerList))
			{
				entity.ProductIdProductCollection_From_ProductDocument = DataRepository.ProductProvider.GetByDocumentIdFromProductDocument(transactionManager, entity.DocumentId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdProductCollection_From_ProductDocument' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdProductCollection_From_ProductDocument != null)
				{
					deepHandles.Add("ProductIdProductCollection_From_ProductDocument",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Product >) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_ProductDocument, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Document object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Document instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Document Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Document entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductIdProductCollection_From_ProductDocument>
			if (CanDeepSave(entity.ProductIdProductCollection_From_ProductDocument, "List<Product>|ProductIdProductCollection_From_ProductDocument", deepSaveType, innerList))
			{
				if (entity.ProductIdProductCollection_From_ProductDocument.Count > 0 || entity.ProductIdProductCollection_From_ProductDocument.DeletedItems.Count > 0)
				{
					DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdProductCollection_From_ProductDocument); 
					deepHandles.Add("ProductIdProductCollection_From_ProductDocument",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Product>) DataRepository.ProductProvider.DeepSave,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_ProductDocument, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<ProductDocument>
				if (CanDeepSave(entity.ProductDocumentCollection, "List<ProductDocument>|ProductDocumentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductDocument child in entity.ProductDocumentCollection)
					{
						if(child.DocumentIdSource != null)
						{
								child.DocumentId = child.DocumentIdSource.DocumentId;
						}

						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

					}

					if (entity.ProductDocumentCollection.Count > 0 || entity.ProductDocumentCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductDocumentProvider.Save(transactionManager, entity.ProductDocumentCollection);
						
						deepHandles.Add("ProductDocumentCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductDocument >) DataRepository.ProductDocumentProvider.DeepSave,
							new object[] { transactionManager, entity.ProductDocumentCollection, deepSaveType, childTypes, innerList }
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
	
	#region DocumentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Document</c>
	///</summary>
	public enum DocumentChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Document</c> as OneToMany for ProductDocumentCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductDocument>))]
		ProductDocumentCollection,

		///<summary>
		/// Collection of <c>Document</c> as ManyToMany for ProductCollection_From_ProductDocument
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductIdProductCollection_From_ProductDocument,
	}
	
	#endregion DocumentChildEntityTypes
	
	#region DocumentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DocumentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Document"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentFilterBuilder : SqlFilterBuilder<DocumentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentFilterBuilder class.
		/// </summary>
		public DocumentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DocumentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DocumentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DocumentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DocumentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DocumentFilterBuilder
	
	#region DocumentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DocumentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Document"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentParameterBuilder : ParameterizedSqlFilterBuilder<DocumentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentParameterBuilder class.
		/// </summary>
		public DocumentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DocumentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DocumentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DocumentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DocumentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DocumentParameterBuilder
	
	#region DocumentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DocumentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Document"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DocumentSortBuilder : SqlSortBuilder<DocumentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentSqlSortBuilder class.
		/// </summary>
		public DocumentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DocumentSortBuilder
	
} // end namespace
