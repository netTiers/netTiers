﻿
/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file Nettiers.AdventureWorks.Entities.ProductDocument.cs instead.
*/

#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Web.Services.Protocols;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.Data.WebServiceClient
{

	///<summary>
	/// This class is the webservice client implementation that exposes CRUD methods for Nettiers.AdventureWorks.Entities.ProductDocument objects.
	///</summary>
	public abstract partial class WsProductDocumentProviderBase : ProductDocumentProviderBase
	{
		#region Declarations

		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		private string url;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Creates a new <see cref="WsProductDocumentProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsProductDocumentProviderBase()
		{
		}

		/// <summary>
		/// Creates a new <see cref="WsProductDocumentProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsProductDocumentProviderBase(string url)
		{
			this.Url = url;
		}

		#endregion Constructors

		#region Url
		///<summary>
		/// Current URL for webservice endpoint.
		///</summary>
		public string Url
        {
        	get {return url;}
        	set {url = value;}
        }
		#endregion

		#region Convertion utility

		/// <summary>
		/// Convert a collection from the ws proxy to a nettiers collection.
		/// </summary>
		public static Nettiers.AdventureWorks.Entities.TList<ProductDocument> Convert(WsProxy.ProductDocument[] items)
		{
			Nettiers.AdventureWorks.Entities.TList<ProductDocument> outItems = new Nettiers.AdventureWorks.Entities.TList<ProductDocument>();
			foreach(WsProxy.ProductDocument item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}

		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static Nettiers.AdventureWorks.Entities.ProductDocument Convert(WsProxy.ProductDocument item)
		{
			Nettiers.AdventureWorks.Entities.ProductDocument outItem = item == null ? null : new Nettiers.AdventureWorks.Entities.ProductDocument();
			Convert(outItem, item);
			return outItem;
		}

		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static Nettiers.AdventureWorks.Entities.ProductDocument Convert(Nettiers.AdventureWorks.Entities.ProductDocument outItem , WsProxy.ProductDocument item)
		{
			if (item != null && outItem != null)
			{
				outItem.ProductId = item.ProductId;
				outItem.DocumentId = item.DocumentId;
				outItem.ModifiedDate = item.ModifiedDate;

				outItem.OriginalProductId = item.ProductId;
				outItem.OriginalDocumentId = item.DocumentId;
				outItem.AcceptChanges();
			}

			return outItem;
		}

		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.ProductDocument Convert(Nettiers.AdventureWorks.Entities.ProductDocument item)
		{
			WsProxy.ProductDocument outItem = new WsProxy.ProductDocument();
			outItem.ProductId = item.ProductId;
			outItem.DocumentId = item.DocumentId;
			outItem.ModifiedDate = item.ModifiedDate;

			outItem.OriginalProductId = item.OriginalProductId;
			outItem.OriginalDocumentId = item.OriginalDocumentId;

			return outItem;
		}

		/// <summary>
		/// Convert a collection from  to a nettiers collection to a the ws proxy collection.
		/// </summary>
		public static WsProxy.ProductDocument[] Convert(Nettiers.AdventureWorks.Entities.TList<ProductDocument> items)
		{
			WsProxy.ProductDocument[] outItems = new WsProxy.ProductDocument[items.Count];
			int count = 0;

			foreach (Nettiers.AdventureWorks.Entities.ProductDocument item in items)
			{
				outItems[count++] = Convert(item);
			}
			return outItems;
		}


		#endregion

		#region Get from  Many To Many Relationship Functions
		#endregion


		#region Delete Methods

			/// <summary>
			/// 	Deletes a row from the DataSource.
			/// </summary>
			/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.. Primary Key.</param>
			/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.. Primary Key.</param>

			/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
			/// <remarks>Deletes based on primary key(s).</remarks>
			/// <returns>Returns true if operation suceeded.</returns>
			public override bool Delete(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _documentId)
			{
				try
				{
				// call the proxy
				WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
				proxy.Url = Url;

				bool result = proxy.ProductDocumentProvider_Delete(_productId, _documentId);
				return result;
				}
				catch(SoapException soex)
				{
					System.Diagnostics.Debug.WriteLine(soex);
					throw soex;
				}
				catch(Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex);
					throw ex;
				}
			}

			#endregion Delete Methods


		#region Find Methods


		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<ProductDocument> Find(TransactionManager transactionManager, string whereClause, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;

			WsProxy.ProductDocument[] items = proxy.ProductDocumentProvider_Find(whereClause, start, pagelen, out count);

			return Convert(items);
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion Find Methods


		#region GetAll Methods

		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<ProductDocument> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;

			WsProxy.ProductDocument[] items = proxy.ProductDocumentProvider_GetAll(start, pageLength, out count);

			return Convert(items);
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion GetAll Methods

		#region GetPaged Methods

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<ProductDocument> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			try
			{
			whereClause = whereClause ?? string.Empty;
			orderBy = orderBy ?? string.Empty;

			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;

			WsProxy.ProductDocument[] items = proxy.ProductDocumentProvider_GetPaged(whereClause, orderBy, start, pageLength, out count);

			// Create a collection and fill it with the dataset
			return Convert(items);
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion GetPaged Methods


		#region Get By Foreign Key Functions

		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Document_DocumentID key.
		///		FK_ProductDocument_Document_DocumentID Description: Foreign key constraint referencing Document.DocumentID.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<ProductDocument> GetByDocumentId(TransactionManager transactionManager, System.Int32 _documentId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			WsProxy.ProductDocument[] items = proxy.ProductDocumentProvider_GetByDocumentId(_documentId, start, pageLength, out count);

			return Convert(items);
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}


		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductDocument_Product_ProductID key.
		///		FK_ProductDocument_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDocument objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<ProductDocument> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			WsProxy.ProductDocument[] items = proxy.ProductDocumentProvider_GetByProductId(_productId, start, pageLength, out count);

			return Convert(items);
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion


		#region Get By Index Functions

		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDocument_ProductID_DocumentID index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDocument"/> class.</returns>
		public override Nettiers.AdventureWorks.Entities.ProductDocument GetByProductIdDocumentId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _documentId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			WsProxy.ProductDocument items = proxy.ProductDocumentProvider_GetByProductIdDocumentId(_productId, _documentId, start, pageLength, out count);

			return Convert(items);
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion Get By Index Functions


		#region Insert Methods
		/// <summary>
		/// 	Inserts a Nettiers.AdventureWorks.Entities.ProductDocument object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductDocument object to insert.</param>
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDocument entity)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;

			try
			{
				WsProxy.ProductDocument result = proxy.ProductDocumentProvider_Insert(Convert(entity));
				Convert(entity, result);
				return true;
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">NOTE: The transaction manager should be null for the web service client implementation.</param>
		/// <param name="entityList">The entities.</param>
		/// <remarks>
		/// After inserting into the datasource, the Nettiers.AdventureWorks.Entities.ProductDocument object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TList<ProductDocument> entityList)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			try
			{
				proxy.ProductDocumentProvider_BulkInsert(Convert(entityList));
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion Insert Methods


		#region Update Methods

		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductDocument object to update.</param>
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDocument entity)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;

			try
			{
				WsProxy.ProductDocument result = proxy.ProductDocumentProvider_Update(Convert(entity));
				Convert(entity, result);
				entity.AcceptChanges();
				return true;
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion Update Methods

		#region Custom Methods


		#endregion

	}//end class
} // end namespace
