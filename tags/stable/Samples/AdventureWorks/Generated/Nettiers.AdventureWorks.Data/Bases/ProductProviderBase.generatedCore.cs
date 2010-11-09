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
	/// This class is the base class for any <see cref="ProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Product, Nettiers.AdventureWorks.Entities.ProductKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByDocumentIdFromProductDocument
		
		/// <summary>
		///		Gets Product objects from the datasource by DocumentID in the
		///		ProductDocument table. Table Product is related to table Document
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByDocumentIdFromProductDocument(System.Int32 _documentId)
		{
			int count = -1;
			return GetByDocumentIdFromProductDocument(null,_documentId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Product objects from the datasource by DocumentID in the
		///		ProductDocument table. Table Product is related to table Document
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public TList<Product> GetByDocumentIdFromProductDocument(System.Int32 _documentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDocumentIdFromProductDocument(null, _documentId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by DocumentID in the
		///		ProductDocument table. Table Product is related to table Document
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByDocumentIdFromProductDocument(TransactionManager transactionManager, System.Int32 _documentId)
		{
			int count = -1;
			return GetByDocumentIdFromProductDocument(transactionManager, _documentId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Product objects from the datasource by DocumentID in the
		///		ProductDocument table. Table Product is related to table Document
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByDocumentIdFromProductDocument(TransactionManager transactionManager, System.Int32 _documentId,int start, int pageLength)
		{
			int count = -1;
			return GetByDocumentIdFromProductDocument(transactionManager, _documentId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by DocumentID in the
		///		ProductDocument table. Table Product is related to table Document
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByDocumentIdFromProductDocument(System.Int32 _documentId,int start, int pageLength, out int count)
		{
			
			return GetByDocumentIdFromProductDocument(null, _documentId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Product objects from the datasource by DocumentID in the
		///		ProductDocument table. Table Product is related to table Document
		///		through the (M:N) relationship defined in the ProductDocument table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_documentId">Document identification number. Foreign key to Document.DocumentID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public abstract TList<Product> GetByDocumentIdFromProductDocument(TransactionManager transactionManager,System.Int32 _documentId, int start, int pageLength, out int count);
		
		#endregion GetByDocumentIdFromProductDocument
		
		#region GetByLocationIdFromProductInventory
		
		/// <summary>
		///		Gets Product objects from the datasource by LocationID in the
		///		ProductInventory table. Table Product is related to table Location
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="_locationId">Inventory location identification number. Foreign key to Location.LocationID. </param>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByLocationIdFromProductInventory(System.Int16 _locationId)
		{
			int count = -1;
			return GetByLocationIdFromProductInventory(null,_locationId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Product objects from the datasource by LocationID in the
		///		ProductInventory table. Table Product is related to table Location
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId">Inventory location identification number. Foreign key to Location.LocationID. </param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public TList<Product> GetByLocationIdFromProductInventory(System.Int16 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationIdFromProductInventory(null, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by LocationID in the
		///		ProductInventory table. Table Product is related to table Location
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Inventory location identification number. Foreign key to Location.LocationID. </param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByLocationIdFromProductInventory(TransactionManager transactionManager, System.Int16 _locationId)
		{
			int count = -1;
			return GetByLocationIdFromProductInventory(transactionManager, _locationId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Product objects from the datasource by LocationID in the
		///		ProductInventory table. Table Product is related to table Location
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Inventory location identification number. Foreign key to Location.LocationID. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByLocationIdFromProductInventory(TransactionManager transactionManager, System.Int16 _locationId,int start, int pageLength)
		{
			int count = -1;
			return GetByLocationIdFromProductInventory(transactionManager, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by LocationID in the
		///		ProductInventory table. Table Product is related to table Location
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="_locationId">Inventory location identification number. Foreign key to Location.LocationID. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByLocationIdFromProductInventory(System.Int16 _locationId,int start, int pageLength, out int count)
		{
			
			return GetByLocationIdFromProductInventory(null, _locationId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Product objects from the datasource by LocationID in the
		///		ProductInventory table. Table Product is related to table Location
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_locationId">Inventory location identification number. Foreign key to Location.LocationID. </param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public abstract TList<Product> GetByLocationIdFromProductInventory(TransactionManager transactionManager,System.Int16 _locationId, int start, int pageLength, out int count);
		
		#endregion GetByLocationIdFromProductInventory
		
		#region GetByProductPhotoIdFromProductProductPhoto
		
		/// <summary>
		///		Gets Product objects from the datasource by ProductPhotoID in the
		///		ProductProductPhoto table. Table Product is related to table ProductPhoto
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByProductPhotoIdFromProductProductPhoto(System.Int32 _productPhotoId)
		{
			int count = -1;
			return GetByProductPhotoIdFromProductProductPhoto(null,_productPhotoId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Product objects from the datasource by ProductPhotoID in the
		///		ProductProductPhoto table. Table Product is related to table ProductPhoto
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public TList<Product> GetByProductPhotoIdFromProductProductPhoto(System.Int32 _productPhotoId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductPhotoIdFromProductProductPhoto(null, _productPhotoId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by ProductPhotoID in the
		///		ProductProductPhoto table. Table Product is related to table ProductPhoto
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByProductPhotoIdFromProductProductPhoto(TransactionManager transactionManager, System.Int32 _productPhotoId)
		{
			int count = -1;
			return GetByProductPhotoIdFromProductProductPhoto(transactionManager, _productPhotoId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Product objects from the datasource by ProductPhotoID in the
		///		ProductProductPhoto table. Table Product is related to table ProductPhoto
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByProductPhotoIdFromProductProductPhoto(TransactionManager transactionManager, System.Int32 _productPhotoId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductPhotoIdFromProductProductPhoto(transactionManager, _productPhotoId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by ProductPhotoID in the
		///		ProductProductPhoto table. Table Product is related to table ProductPhoto
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByProductPhotoIdFromProductProductPhoto(System.Int32 _productPhotoId,int start, int pageLength, out int count)
		{
			
			return GetByProductPhotoIdFromProductProductPhoto(null, _productPhotoId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Product objects from the datasource by ProductPhotoID in the
		///		ProductProductPhoto table. Table Product is related to table ProductPhoto
		///		through the (M:N) relationship defined in the ProductProductPhoto table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productPhotoId">Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public abstract TList<Product> GetByProductPhotoIdFromProductProductPhoto(TransactionManager transactionManager,System.Int32 _productPhotoId, int start, int pageLength, out int count);
		
		#endregion GetByProductPhotoIdFromProductProductPhoto
		
		#region GetByVendorIdFromProductVendor
		
		/// <summary>
		///		Gets Product objects from the datasource by VendorID in the
		///		ProductVendor table. Table Product is related to table Vendor
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByVendorIdFromProductVendor(System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorIdFromProductVendor(null,_vendorId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Product objects from the datasource by VendorID in the
		///		ProductVendor table. Table Product is related to table Vendor
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public TList<Product> GetByVendorIdFromProductVendor(System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdFromProductVendor(null, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by VendorID in the
		///		ProductVendor table. Table Product is related to table Vendor
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByVendorIdFromProductVendor(TransactionManager transactionManager, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorIdFromProductVendor(transactionManager, _vendorId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Product objects from the datasource by VendorID in the
		///		ProductVendor table. Table Product is related to table Vendor
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByVendorIdFromProductVendor(TransactionManager transactionManager, System.Int32 _vendorId,int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdFromProductVendor(transactionManager, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by VendorID in the
		///		ProductVendor table. Table Product is related to table Vendor
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetByVendorIdFromProductVendor(System.Int32 _vendorId,int start, int pageLength, out int count)
		{
			
			return GetByVendorIdFromProductVendor(null, _vendorId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Product objects from the datasource by VendorID in the
		///		ProductVendor table. Table Product is related to table Vendor
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public abstract TList<Product> GetByVendorIdFromProductVendor(TransactionManager transactionManager,System.Int32 _vendorId, int start, int pageLength, out int count);
		
		#endregion GetByVendorIdFromProductVendor
		
		#region GetBySpecialOfferIdFromSpecialOfferProduct
		
		/// <summary>
		///		Gets Product objects from the datasource by SpecialOfferID in the
		///		SpecialOfferProduct table. Table Product is related to table SpecialOffer
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetBySpecialOfferIdFromSpecialOfferProduct(System.Int32 _specialOfferId)
		{
			int count = -1;
			return GetBySpecialOfferIdFromSpecialOfferProduct(null,_specialOfferId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Product objects from the datasource by SpecialOfferID in the
		///		SpecialOfferProduct table. Table Product is related to table SpecialOffer
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public TList<Product> GetBySpecialOfferIdFromSpecialOfferProduct(System.Int32 _specialOfferId, int start, int pageLength)
		{
			int count = -1;
			return GetBySpecialOfferIdFromSpecialOfferProduct(null, _specialOfferId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by SpecialOfferID in the
		///		SpecialOfferProduct table. Table Product is related to table SpecialOffer
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetBySpecialOfferIdFromSpecialOfferProduct(TransactionManager transactionManager, System.Int32 _specialOfferId)
		{
			int count = -1;
			return GetBySpecialOfferIdFromSpecialOfferProduct(transactionManager, _specialOfferId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Product objects from the datasource by SpecialOfferID in the
		///		SpecialOfferProduct table. Table Product is related to table SpecialOffer
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetBySpecialOfferIdFromSpecialOfferProduct(TransactionManager transactionManager, System.Int32 _specialOfferId,int start, int pageLength)
		{
			int count = -1;
			return GetBySpecialOfferIdFromSpecialOfferProduct(transactionManager, _specialOfferId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Product objects from the datasource by SpecialOfferID in the
		///		SpecialOfferProduct table. Table Product is related to table SpecialOffer
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Product objects.</returns>
		public TList<Product> GetBySpecialOfferIdFromSpecialOfferProduct(System.Int32 _specialOfferId,int start, int pageLength, out int count)
		{
			
			return GetBySpecialOfferIdFromSpecialOfferProduct(null, _specialOfferId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Product objects from the datasource by SpecialOfferID in the
		///		SpecialOfferProduct table. Table Product is related to table SpecialOffer
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Product objects.</returns>
		public abstract TList<Product> GetBySpecialOfferIdFromSpecialOfferProduct(TransactionManager transactionManager,System.Int32 _specialOfferId, int start, int pageLength, out int count);
		
		#endregion GetBySpecialOfferIdFromSpecialOfferProduct
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductKey key)
		{
			return Delete(transactionManager, key.ProductId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productId">Primary key for Product records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productId)
		{
			return Delete(null, _productId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key for Product records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductModel_ProductModelID key.
		///		FK_Product_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="_productModelId">Product is a member of this product model. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByProductModelId(System.Int32? _productModelId)
		{
			int count = -1;
			return GetByProductModelId(_productModelId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductModel_ProductModelID key.
		///		FK_Product_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Product is a member of this product model. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public TList<Product> GetByProductModelId(TransactionManager transactionManager, System.Int32? _productModelId)
		{
			int count = -1;
			return GetByProductModelId(transactionManager, _productModelId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductModel_ProductModelID key.
		///		FK_Product_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Product is a member of this product model. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByProductModelId(TransactionManager transactionManager, System.Int32? _productModelId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelId(transactionManager, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductModel_ProductModelID key.
		///		fkProductProductModelProductModelId Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Product is a member of this product model. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByProductModelId(System.Int32? _productModelId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductModelId(null, _productModelId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductModel_ProductModelID key.
		///		fkProductProductModelProductModelId Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Product is a member of this product model. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByProductModelId(System.Int32? _productModelId, int start, int pageLength,out int count)
		{
			return GetByProductModelId(null, _productModelId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductModel_ProductModelID key.
		///		FK_Product_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Product is a member of this product model. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public abstract TList<Product> GetByProductModelId(TransactionManager transactionManager, System.Int32? _productModelId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductSubcategory_ProductSubcategoryID key.
		///		FK_Product_ProductSubcategory_ProductSubcategoryID Description: Foreign key constraint referencing ProductSubcategory.ProductSubcategoryID.
		/// </summary>
		/// <param name="_productSubcategoryId">Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. </param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByProductSubcategoryId(System.Int32? _productSubcategoryId)
		{
			int count = -1;
			return GetByProductSubcategoryId(_productSubcategoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductSubcategory_ProductSubcategoryID key.
		///		FK_Product_ProductSubcategory_ProductSubcategoryID Description: Foreign key constraint referencing ProductSubcategory.ProductSubcategoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productSubcategoryId">Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. </param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public TList<Product> GetByProductSubcategoryId(TransactionManager transactionManager, System.Int32? _productSubcategoryId)
		{
			int count = -1;
			return GetByProductSubcategoryId(transactionManager, _productSubcategoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductSubcategory_ProductSubcategoryID key.
		///		FK_Product_ProductSubcategory_ProductSubcategoryID Description: Foreign key constraint referencing ProductSubcategory.ProductSubcategoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productSubcategoryId">Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByProductSubcategoryId(TransactionManager transactionManager, System.Int32? _productSubcategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductSubcategoryId(transactionManager, _productSubcategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductSubcategory_ProductSubcategoryID key.
		///		fkProductProductSubcategoryProductSubcategoryId Description: Foreign key constraint referencing ProductSubcategory.ProductSubcategoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productSubcategoryId">Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. </param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByProductSubcategoryId(System.Int32? _productSubcategoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductSubcategoryId(null, _productSubcategoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductSubcategory_ProductSubcategoryID key.
		///		fkProductProductSubcategoryProductSubcategoryId Description: Foreign key constraint referencing ProductSubcategory.ProductSubcategoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productSubcategoryId">Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. </param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByProductSubcategoryId(System.Int32? _productSubcategoryId, int start, int pageLength,out int count)
		{
			return GetByProductSubcategoryId(null, _productSubcategoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_ProductSubcategory_ProductSubcategoryID key.
		///		FK_Product_ProductSubcategory_ProductSubcategoryID Description: Foreign key constraint referencing ProductSubcategory.ProductSubcategoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productSubcategoryId">Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public abstract TList<Product> GetByProductSubcategoryId(TransactionManager transactionManager, System.Int32? _productSubcategoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_SizeUnitMeasureCode key.
		///		FK_Product_UnitMeasure_SizeUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="_sizeUnitMeasureCode">Unit of measure for Size column.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetBySizeUnitMeasureCode(System.String _sizeUnitMeasureCode)
		{
			int count = -1;
			return GetBySizeUnitMeasureCode(_sizeUnitMeasureCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_SizeUnitMeasureCode key.
		///		FK_Product_UnitMeasure_SizeUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sizeUnitMeasureCode">Unit of measure for Size column.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public TList<Product> GetBySizeUnitMeasureCode(TransactionManager transactionManager, System.String _sizeUnitMeasureCode)
		{
			int count = -1;
			return GetBySizeUnitMeasureCode(transactionManager, _sizeUnitMeasureCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_SizeUnitMeasureCode key.
		///		FK_Product_UnitMeasure_SizeUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sizeUnitMeasureCode">Unit of measure for Size column.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetBySizeUnitMeasureCode(TransactionManager transactionManager, System.String _sizeUnitMeasureCode, int start, int pageLength)
		{
			int count = -1;
			return GetBySizeUnitMeasureCode(transactionManager, _sizeUnitMeasureCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_SizeUnitMeasureCode key.
		///		fkProductUnitMeasureSizeUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_sizeUnitMeasureCode">Unit of measure for Size column.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetBySizeUnitMeasureCode(System.String _sizeUnitMeasureCode, int start, int pageLength)
		{
			int count =  -1;
			return GetBySizeUnitMeasureCode(null, _sizeUnitMeasureCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_SizeUnitMeasureCode key.
		///		fkProductUnitMeasureSizeUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_sizeUnitMeasureCode">Unit of measure for Size column.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetBySizeUnitMeasureCode(System.String _sizeUnitMeasureCode, int start, int pageLength,out int count)
		{
			return GetBySizeUnitMeasureCode(null, _sizeUnitMeasureCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_SizeUnitMeasureCode key.
		///		FK_Product_UnitMeasure_SizeUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sizeUnitMeasureCode">Unit of measure for Size column.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public abstract TList<Product> GetBySizeUnitMeasureCode(TransactionManager transactionManager, System.String _sizeUnitMeasureCode, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_WeightUnitMeasureCode key.
		///		FK_Product_UnitMeasure_WeightUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="_weightUnitMeasureCode">Unit of measure for Weight column.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByWeightUnitMeasureCode(System.String _weightUnitMeasureCode)
		{
			int count = -1;
			return GetByWeightUnitMeasureCode(_weightUnitMeasureCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_WeightUnitMeasureCode key.
		///		FK_Product_UnitMeasure_WeightUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_weightUnitMeasureCode">Unit of measure for Weight column.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public TList<Product> GetByWeightUnitMeasureCode(TransactionManager transactionManager, System.String _weightUnitMeasureCode)
		{
			int count = -1;
			return GetByWeightUnitMeasureCode(transactionManager, _weightUnitMeasureCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_WeightUnitMeasureCode key.
		///		FK_Product_UnitMeasure_WeightUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_weightUnitMeasureCode">Unit of measure for Weight column.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByWeightUnitMeasureCode(TransactionManager transactionManager, System.String _weightUnitMeasureCode, int start, int pageLength)
		{
			int count = -1;
			return GetByWeightUnitMeasureCode(transactionManager, _weightUnitMeasureCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_WeightUnitMeasureCode key.
		///		fkProductUnitMeasureWeightUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_weightUnitMeasureCode">Unit of measure for Weight column.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByWeightUnitMeasureCode(System.String _weightUnitMeasureCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByWeightUnitMeasureCode(null, _weightUnitMeasureCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_WeightUnitMeasureCode key.
		///		fkProductUnitMeasureWeightUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_weightUnitMeasureCode">Unit of measure for Weight column.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public TList<Product> GetByWeightUnitMeasureCode(System.String _weightUnitMeasureCode, int start, int pageLength,out int count)
		{
			return GetByWeightUnitMeasureCode(null, _weightUnitMeasureCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_UnitMeasure_WeightUnitMeasureCode key.
		///		FK_Product_UnitMeasure_WeightUnitMeasureCode Description: Foreign key constraint referencing UnitMeasure.UnitMeasureCode.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_weightUnitMeasureCode">Unit of measure for Weight column.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Product objects.</returns>
		public abstract TList<Product> GetByWeightUnitMeasureCode(TransactionManager transactionManager, System.String _weightUnitMeasureCode, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.Product Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductKey key, int start, int pageLength)
		{
			return GetByProductId(transactionManager, key.ProductId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Product_Name index.
		/// </summary>
		/// <param name="_name">Name of the product.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_Name index.
		/// </summary>
		/// <param name="_name">Name of the product.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Name of the product.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Name of the product.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_Name index.
		/// </summary>
		/// <param name="_name">Name of the product.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Name of the product.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Product GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Product_ProductNumber index.
		/// </summary>
		/// <param name="_productNumber">Unique product identification number.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductNumber(System.String _productNumber)
		{
			int count = -1;
			return GetByProductNumber(null,_productNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_ProductNumber index.
		/// </summary>
		/// <param name="_productNumber">Unique product identification number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductNumber(System.String _productNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByProductNumber(null, _productNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_ProductNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productNumber">Unique product identification number.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductNumber(TransactionManager transactionManager, System.String _productNumber)
		{
			int count = -1;
			return GetByProductNumber(transactionManager, _productNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_ProductNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productNumber">Unique product identification number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductNumber(TransactionManager transactionManager, System.String _productNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByProductNumber(transactionManager, _productNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_ProductNumber index.
		/// </summary>
		/// <param name="_productNumber">Unique product identification number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductNumber(System.String _productNumber, int start, int pageLength, out int count)
		{
			return GetByProductNumber(null, _productNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_ProductNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productNumber">Unique product identification number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Product GetByProductNumber(TransactionManager transactionManager, System.String _productNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Product_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Product_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Product GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Product_ProductID index.
		/// </summary>
		/// <param name="_productId">Primary key for Product records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product_ProductID index.
		/// </summary>
		/// <param name="_productId">Primary key for Product records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key for Product records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key for Product records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product_ProductID index.
		/// </summary>
		/// <param name="_productId">Primary key for Product records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Product GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key for Product records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Product"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Product GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Product&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Product&gt;"/></returns>
		public static TList<Product> Fill(IDataReader reader, TList<Product> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Product c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Product")
					.Append("|").Append((System.Int32)reader[((int)ProductColumn.ProductId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Product>(
					key.ToString(), // EntityTrackingKey
					"Product",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Product();
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
					c.ProductId = (System.Int32)reader[((int)ProductColumn.ProductId - 1)];
					c.Name = (System.String)reader[((int)ProductColumn.Name - 1)];
					c.ProductNumber = (System.String)reader[((int)ProductColumn.ProductNumber - 1)];
					c.MakeFlag = (System.Boolean)reader[((int)ProductColumn.MakeFlag - 1)];
					c.FinishedGoodsFlag = (System.Boolean)reader[((int)ProductColumn.FinishedGoodsFlag - 1)];
					c.Color = (reader.IsDBNull(((int)ProductColumn.Color - 1)))?null:(System.String)reader[((int)ProductColumn.Color - 1)];
					c.SafetyStockLevel = (System.Int16)reader[((int)ProductColumn.SafetyStockLevel - 1)];
					c.ReorderPoint = (System.Int16)reader[((int)ProductColumn.ReorderPoint - 1)];
					c.StandardCost = (System.Decimal)reader[((int)ProductColumn.StandardCost - 1)];
					c.ListPrice = (System.Decimal)reader[((int)ProductColumn.ListPrice - 1)];
					c.Size = (reader.IsDBNull(((int)ProductColumn.Size - 1)))?null:(System.String)reader[((int)ProductColumn.Size - 1)];
					c.SizeUnitMeasureCode = (reader.IsDBNull(((int)ProductColumn.SizeUnitMeasureCode - 1)))?null:(System.String)reader[((int)ProductColumn.SizeUnitMeasureCode - 1)];
					c.WeightUnitMeasureCode = (reader.IsDBNull(((int)ProductColumn.WeightUnitMeasureCode - 1)))?null:(System.String)reader[((int)ProductColumn.WeightUnitMeasureCode - 1)];
					c.Weight = (reader.IsDBNull(((int)ProductColumn.Weight - 1)))?null:(System.Decimal?)reader[((int)ProductColumn.Weight - 1)];
					c.DaysToManufacture = (System.Int32)reader[((int)ProductColumn.DaysToManufacture - 1)];
					c.ProductLine = (reader.IsDBNull(((int)ProductColumn.ProductLine - 1)))?null:(System.String)reader[((int)ProductColumn.ProductLine - 1)];
					c.SafeNameClass = (reader.IsDBNull(((int)ProductColumn.SafeNameClass - 1)))?null:(System.String)reader[((int)ProductColumn.SafeNameClass - 1)];
					c.Style = (reader.IsDBNull(((int)ProductColumn.Style - 1)))?null:(System.String)reader[((int)ProductColumn.Style - 1)];
					c.ProductSubcategoryId = (reader.IsDBNull(((int)ProductColumn.ProductSubcategoryId - 1)))?null:(System.Int32?)reader[((int)ProductColumn.ProductSubcategoryId - 1)];
					c.ProductModelId = (reader.IsDBNull(((int)ProductColumn.ProductModelId - 1)))?null:(System.Int32?)reader[((int)ProductColumn.ProductModelId - 1)];
					c.SellStartDate = (System.DateTime)reader[((int)ProductColumn.SellStartDate - 1)];
					c.SellEndDate = (reader.IsDBNull(((int)ProductColumn.SellEndDate - 1)))?null:(System.DateTime?)reader[((int)ProductColumn.SellEndDate - 1)];
					c.DiscontinuedDate = (reader.IsDBNull(((int)ProductColumn.DiscontinuedDate - 1)))?null:(System.DateTime?)reader[((int)ProductColumn.DiscontinuedDate - 1)];
					c.Rowguid = (System.Guid)reader[((int)ProductColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ProductColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Product"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Product"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Product entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductId = (System.Int32)reader[((int)ProductColumn.ProductId - 1)];
			entity.Name = (System.String)reader[((int)ProductColumn.Name - 1)];
			entity.ProductNumber = (System.String)reader[((int)ProductColumn.ProductNumber - 1)];
			entity.MakeFlag = (System.Boolean)reader[((int)ProductColumn.MakeFlag - 1)];
			entity.FinishedGoodsFlag = (System.Boolean)reader[((int)ProductColumn.FinishedGoodsFlag - 1)];
			entity.Color = (reader.IsDBNull(((int)ProductColumn.Color - 1)))?null:(System.String)reader[((int)ProductColumn.Color - 1)];
			entity.SafetyStockLevel = (System.Int16)reader[((int)ProductColumn.SafetyStockLevel - 1)];
			entity.ReorderPoint = (System.Int16)reader[((int)ProductColumn.ReorderPoint - 1)];
			entity.StandardCost = (System.Decimal)reader[((int)ProductColumn.StandardCost - 1)];
			entity.ListPrice = (System.Decimal)reader[((int)ProductColumn.ListPrice - 1)];
			entity.Size = (reader.IsDBNull(((int)ProductColumn.Size - 1)))?null:(System.String)reader[((int)ProductColumn.Size - 1)];
			entity.SizeUnitMeasureCode = (reader.IsDBNull(((int)ProductColumn.SizeUnitMeasureCode - 1)))?null:(System.String)reader[((int)ProductColumn.SizeUnitMeasureCode - 1)];
			entity.WeightUnitMeasureCode = (reader.IsDBNull(((int)ProductColumn.WeightUnitMeasureCode - 1)))?null:(System.String)reader[((int)ProductColumn.WeightUnitMeasureCode - 1)];
			entity.Weight = (reader.IsDBNull(((int)ProductColumn.Weight - 1)))?null:(System.Decimal?)reader[((int)ProductColumn.Weight - 1)];
			entity.DaysToManufacture = (System.Int32)reader[((int)ProductColumn.DaysToManufacture - 1)];
			entity.ProductLine = (reader.IsDBNull(((int)ProductColumn.ProductLine - 1)))?null:(System.String)reader[((int)ProductColumn.ProductLine - 1)];
			entity.SafeNameClass = (reader.IsDBNull(((int)ProductColumn.SafeNameClass - 1)))?null:(System.String)reader[((int)ProductColumn.SafeNameClass - 1)];
			entity.Style = (reader.IsDBNull(((int)ProductColumn.Style - 1)))?null:(System.String)reader[((int)ProductColumn.Style - 1)];
			entity.ProductSubcategoryId = (reader.IsDBNull(((int)ProductColumn.ProductSubcategoryId - 1)))?null:(System.Int32?)reader[((int)ProductColumn.ProductSubcategoryId - 1)];
			entity.ProductModelId = (reader.IsDBNull(((int)ProductColumn.ProductModelId - 1)))?null:(System.Int32?)reader[((int)ProductColumn.ProductModelId - 1)];
			entity.SellStartDate = (System.DateTime)reader[((int)ProductColumn.SellStartDate - 1)];
			entity.SellEndDate = (reader.IsDBNull(((int)ProductColumn.SellEndDate - 1)))?null:(System.DateTime?)reader[((int)ProductColumn.SellEndDate - 1)];
			entity.DiscontinuedDate = (reader.IsDBNull(((int)ProductColumn.DiscontinuedDate - 1)))?null:(System.DateTime?)reader[((int)ProductColumn.DiscontinuedDate - 1)];
			entity.Rowguid = (System.Guid)reader[((int)ProductColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Product"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Product"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Product entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.ProductNumber = (System.String)dataRow["ProductNumber"];
			entity.MakeFlag = (System.Boolean)dataRow["MakeFlag"];
			entity.FinishedGoodsFlag = (System.Boolean)dataRow["FinishedGoodsFlag"];
			entity.Color = Convert.IsDBNull(dataRow["Color"]) ? null : (System.String)dataRow["Color"];
			entity.SafetyStockLevel = (System.Int16)dataRow["SafetyStockLevel"];
			entity.ReorderPoint = (System.Int16)dataRow["ReorderPoint"];
			entity.StandardCost = (System.Decimal)dataRow["StandardCost"];
			entity.ListPrice = (System.Decimal)dataRow["ListPrice"];
			entity.Size = Convert.IsDBNull(dataRow["Size"]) ? null : (System.String)dataRow["Size"];
			entity.SizeUnitMeasureCode = Convert.IsDBNull(dataRow["SizeUnitMeasureCode"]) ? null : (System.String)dataRow["SizeUnitMeasureCode"];
			entity.WeightUnitMeasureCode = Convert.IsDBNull(dataRow["WeightUnitMeasureCode"]) ? null : (System.String)dataRow["WeightUnitMeasureCode"];
			entity.Weight = Convert.IsDBNull(dataRow["Weight"]) ? null : (System.Decimal?)dataRow["Weight"];
			entity.DaysToManufacture = (System.Int32)dataRow["DaysToManufacture"];
			entity.ProductLine = Convert.IsDBNull(dataRow["ProductLine"]) ? null : (System.String)dataRow["ProductLine"];
			entity.SafeNameClass = Convert.IsDBNull(dataRow["Class"]) ? null : (System.String)dataRow["Class"];
			entity.Style = Convert.IsDBNull(dataRow["Style"]) ? null : (System.String)dataRow["Style"];
			entity.ProductSubcategoryId = Convert.IsDBNull(dataRow["ProductSubcategoryID"]) ? null : (System.Int32?)dataRow["ProductSubcategoryID"];
			entity.ProductModelId = Convert.IsDBNull(dataRow["ProductModelID"]) ? null : (System.Int32?)dataRow["ProductModelID"];
			entity.SellStartDate = (System.DateTime)dataRow["SellStartDate"];
			entity.SellEndDate = Convert.IsDBNull(dataRow["SellEndDate"]) ? null : (System.DateTime?)dataRow["SellEndDate"];
			entity.DiscontinuedDate = Convert.IsDBNull(dataRow["DiscontinuedDate"]) ? null : (System.DateTime?)dataRow["DiscontinuedDate"];
			entity.Rowguid = (System.Guid)dataRow["rowguid"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Product"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Product Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Product entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ProductModelIdSource	
			if (CanDeepLoad(entity, "ProductModel|ProductModelIdSource", deepLoadType, innerList) 
				&& entity.ProductModelIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ProductModelId ?? (int)0);
				ProductModel tmpEntity = EntityManager.LocateEntity<ProductModel>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductModel), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductModelIdSource = tmpEntity;
				else
					entity.ProductModelIdSource = DataRepository.ProductModelProvider.GetByProductModelId(transactionManager, (entity.ProductModelId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductModelIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductModelProvider.DeepLoad(transactionManager, entity.ProductModelIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductModelIdSource

			#region ProductSubcategoryIdSource	
			if (CanDeepLoad(entity, "ProductSubcategory|ProductSubcategoryIdSource", deepLoadType, innerList) 
				&& entity.ProductSubcategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ProductSubcategoryId ?? (int)0);
				ProductSubcategory tmpEntity = EntityManager.LocateEntity<ProductSubcategory>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductSubcategory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductSubcategoryIdSource = tmpEntity;
				else
					entity.ProductSubcategoryIdSource = DataRepository.ProductSubcategoryProvider.GetByProductSubcategoryId(transactionManager, (entity.ProductSubcategoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductSubcategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductSubcategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductSubcategoryProvider.DeepLoad(transactionManager, entity.ProductSubcategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductSubcategoryIdSource

			#region SizeUnitMeasureCodeSource	
			if (CanDeepLoad(entity, "UnitMeasure|SizeUnitMeasureCodeSource", deepLoadType, innerList) 
				&& entity.SizeUnitMeasureCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SizeUnitMeasureCode ?? string.Empty);
				UnitMeasure tmpEntity = EntityManager.LocateEntity<UnitMeasure>(EntityLocator.ConstructKeyFromPkItems(typeof(UnitMeasure), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SizeUnitMeasureCodeSource = tmpEntity;
				else
					entity.SizeUnitMeasureCodeSource = DataRepository.UnitMeasureProvider.GetByUnitMeasureCode(transactionManager, (entity.SizeUnitMeasureCode ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SizeUnitMeasureCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SizeUnitMeasureCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UnitMeasureProvider.DeepLoad(transactionManager, entity.SizeUnitMeasureCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SizeUnitMeasureCodeSource

			#region WeightUnitMeasureCodeSource	
			if (CanDeepLoad(entity, "UnitMeasure|WeightUnitMeasureCodeSource", deepLoadType, innerList) 
				&& entity.WeightUnitMeasureCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.WeightUnitMeasureCode ?? string.Empty);
				UnitMeasure tmpEntity = EntityManager.LocateEntity<UnitMeasure>(EntityLocator.ConstructKeyFromPkItems(typeof(UnitMeasure), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.WeightUnitMeasureCodeSource = tmpEntity;
				else
					entity.WeightUnitMeasureCodeSource = DataRepository.UnitMeasureProvider.GetByUnitMeasureCode(transactionManager, (entity.WeightUnitMeasureCode ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WeightUnitMeasureCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.WeightUnitMeasureCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UnitMeasureProvider.DeepLoad(transactionManager, entity.WeightUnitMeasureCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion WeightUnitMeasureCodeSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProductId methods when available
			
			#region ProductProductPhotoCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductProductPhoto>|ProductProductPhotoCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductProductPhotoCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductProductPhotoCollection = DataRepository.ProductProductPhotoProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ProductProductPhotoCollection.Count > 0)
				{
					deepHandles.Add("ProductProductPhotoCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductProductPhoto>) DataRepository.ProductProductPhotoProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductProductPhotoCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region TransactionHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<TransactionHistory>|TransactionHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TransactionHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TransactionHistoryCollection = DataRepository.TransactionHistoryProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.TransactionHistoryCollection.Count > 0)
				{
					deepHandles.Add("TransactionHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<TransactionHistory>) DataRepository.TransactionHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.TransactionHistoryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductVendorCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductVendor>|ProductVendorCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductVendorCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductVendorCollection = DataRepository.ProductVendorProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ProductVendorCollection.Count > 0)
				{
					deepHandles.Add("ProductVendorCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductVendor>) DataRepository.ProductVendorProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductVendorCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region BillOfMaterialsCollectionGetByProductAssemblyId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<BillOfMaterials>|BillOfMaterialsCollectionGetByProductAssemblyId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillOfMaterialsCollectionGetByProductAssemblyId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BillOfMaterialsCollectionGetByProductAssemblyId = DataRepository.BillOfMaterialsProvider.GetByProductAssemblyId(transactionManager, entity.ProductId);

				if (deep && entity.BillOfMaterialsCollectionGetByProductAssemblyId.Count > 0)
				{
					deepHandles.Add("BillOfMaterialsCollectionGetByProductAssemblyId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<BillOfMaterials>) DataRepository.BillOfMaterialsProvider.DeepLoad,
						new object[] { transactionManager, entity.BillOfMaterialsCollectionGetByProductAssemblyId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DocumentIdDocumentCollection_From_ProductDocument
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Document>|DocumentIdDocumentCollection_From_ProductDocument", deepLoadType, innerList))
			{
				entity.DocumentIdDocumentCollection_From_ProductDocument = DataRepository.DocumentProvider.GetByProductIdFromProductDocument(transactionManager, entity.ProductId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DocumentIdDocumentCollection_From_ProductDocument' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DocumentIdDocumentCollection_From_ProductDocument != null)
				{
					deepHandles.Add("DocumentIdDocumentCollection_From_ProductDocument",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Document >) DataRepository.DocumentProvider.DeepLoad,
						new object[] { transactionManager, entity.DocumentIdDocumentCollection_From_ProductDocument, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region SpecialOfferProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SpecialOfferProduct>|SpecialOfferProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SpecialOfferProductCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SpecialOfferProductCollection = DataRepository.SpecialOfferProductProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.SpecialOfferProductCollection.Count > 0)
				{
					deepHandles.Add("SpecialOfferProductCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SpecialOfferProduct>) DataRepository.SpecialOfferProductProvider.DeepLoad,
						new object[] { transactionManager, entity.SpecialOfferProductCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<ProductPhoto>|ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto", deepLoadType, innerList))
			{
				entity.ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto = DataRepository.ProductPhotoProvider.GetByProductIdFromProductProductPhoto(transactionManager, entity.ProductId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto != null)
				{
					deepHandles.Add("ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< ProductPhoto >) DataRepository.ProductPhotoProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region BillOfMaterialsCollectionGetByComponentId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<BillOfMaterials>|BillOfMaterialsCollectionGetByComponentId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillOfMaterialsCollectionGetByComponentId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BillOfMaterialsCollectionGetByComponentId = DataRepository.BillOfMaterialsProvider.GetByComponentId(transactionManager, entity.ProductId);

				if (deep && entity.BillOfMaterialsCollectionGetByComponentId.Count > 0)
				{
					deepHandles.Add("BillOfMaterialsCollectionGetByComponentId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<BillOfMaterials>) DataRepository.BillOfMaterialsProvider.DeepLoad,
						new object[] { transactionManager, entity.BillOfMaterialsCollectionGetByComponentId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductInventoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductInventory>|ProductInventoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductInventoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductInventoryCollection = DataRepository.ProductInventoryProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ProductInventoryCollection.Count > 0)
				{
					deepHandles.Add("ProductInventoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductInventory>) DataRepository.ProductInventoryProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductInventoryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductDocumentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductDocument>|ProductDocumentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductDocumentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductDocumentCollection = DataRepository.ProductDocumentProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ProductDocumentCollection.Count > 0)
				{
					deepHandles.Add("ProductDocumentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductDocument>) DataRepository.ProductDocumentProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductDocumentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductReviewCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductReview>|ProductReviewCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductReviewCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductReviewCollection = DataRepository.ProductReviewProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ProductReviewCollection.Count > 0)
				{
					deepHandles.Add("ProductReviewCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductReview>) DataRepository.ProductReviewProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductReviewCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region VendorIdVendorCollection_From_ProductVendor
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Vendor>|VendorIdVendorCollection_From_ProductVendor", deepLoadType, innerList))
			{
				entity.VendorIdVendorCollection_From_ProductVendor = DataRepository.VendorProvider.GetByProductIdFromProductVendor(transactionManager, entity.ProductId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorIdVendorCollection_From_ProductVendor' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.VendorIdVendorCollection_From_ProductVendor != null)
				{
					deepHandles.Add("VendorIdVendorCollection_From_ProductVendor",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Vendor >) DataRepository.VendorProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorIdVendorCollection_From_ProductVendor, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region WorkOrderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WorkOrder>|WorkOrderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WorkOrderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WorkOrderCollection = DataRepository.WorkOrderProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.WorkOrderCollection.Count > 0)
				{
					deepHandles.Add("WorkOrderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WorkOrder>) DataRepository.WorkOrderProvider.DeepLoad,
						new object[] { transactionManager, entity.WorkOrderCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region PurchaseOrderDetailCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PurchaseOrderDetail>|PurchaseOrderDetailCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PurchaseOrderDetailCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PurchaseOrderDetailCollection = DataRepository.PurchaseOrderDetailProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.PurchaseOrderDetailCollection.Count > 0)
				{
					deepHandles.Add("PurchaseOrderDetailCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PurchaseOrderDetail>) DataRepository.PurchaseOrderDetailProvider.DeepLoad,
						new object[] { transactionManager, entity.PurchaseOrderDetailCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region LocationIdLocationCollection_From_ProductInventory
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Location>|LocationIdLocationCollection_From_ProductInventory", deepLoadType, innerList))
			{
				entity.LocationIdLocationCollection_From_ProductInventory = DataRepository.LocationProvider.GetByProductIdFromProductInventory(transactionManager, entity.ProductId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LocationIdLocationCollection_From_ProductInventory' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LocationIdLocationCollection_From_ProductInventory != null)
				{
					deepHandles.Add("LocationIdLocationCollection_From_ProductInventory",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Location >) DataRepository.LocationProvider.DeepLoad,
						new object[] { transactionManager, entity.LocationIdLocationCollection_From_ProductInventory, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ProductListPriceHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductListPriceHistory>|ProductListPriceHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductListPriceHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductListPriceHistoryCollection = DataRepository.ProductListPriceHistoryProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ProductListPriceHistoryCollection.Count > 0)
				{
					deepHandles.Add("ProductListPriceHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductListPriceHistory>) DataRepository.ProductListPriceHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductListPriceHistoryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<SpecialOffer>|SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct", deepLoadType, innerList))
			{
				entity.SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct = DataRepository.SpecialOfferProvider.GetByProductIdFromSpecialOfferProduct(transactionManager, entity.ProductId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct != null)
				{
					deepHandles.Add("SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< SpecialOffer >) DataRepository.SpecialOfferProvider.DeepLoad,
						new object[] { transactionManager, entity.SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ShoppingCartItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ShoppingCartItem>|ShoppingCartItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ShoppingCartItemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ShoppingCartItemCollection = DataRepository.ShoppingCartItemProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ShoppingCartItemCollection.Count > 0)
				{
					deepHandles.Add("ShoppingCartItemCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ShoppingCartItem>) DataRepository.ShoppingCartItemProvider.DeepLoad,
						new object[] { transactionManager, entity.ShoppingCartItemCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductCostHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductCostHistory>|ProductCostHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductCostHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductCostHistoryCollection = DataRepository.ProductCostHistoryProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.ProductCostHistoryCollection.Count > 0)
				{
					deepHandles.Add("ProductCostHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductCostHistory>) DataRepository.ProductCostHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductCostHistoryCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Product object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Product instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Product Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Product entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductModelIdSource
			if (CanDeepSave(entity, "ProductModel|ProductModelIdSource", deepSaveType, innerList) 
				&& entity.ProductModelIdSource != null)
			{
				DataRepository.ProductModelProvider.Save(transactionManager, entity.ProductModelIdSource);
				entity.ProductModelId = entity.ProductModelIdSource.ProductModelId;
			}
			#endregion 
			
			#region ProductSubcategoryIdSource
			if (CanDeepSave(entity, "ProductSubcategory|ProductSubcategoryIdSource", deepSaveType, innerList) 
				&& entity.ProductSubcategoryIdSource != null)
			{
				DataRepository.ProductSubcategoryProvider.Save(transactionManager, entity.ProductSubcategoryIdSource);
				entity.ProductSubcategoryId = entity.ProductSubcategoryIdSource.ProductSubcategoryId;
			}
			#endregion 
			
			#region SizeUnitMeasureCodeSource
			if (CanDeepSave(entity, "UnitMeasure|SizeUnitMeasureCodeSource", deepSaveType, innerList) 
				&& entity.SizeUnitMeasureCodeSource != null)
			{
				DataRepository.UnitMeasureProvider.Save(transactionManager, entity.SizeUnitMeasureCodeSource);
				entity.SizeUnitMeasureCode = entity.SizeUnitMeasureCodeSource.UnitMeasureCode;
			}
			#endregion 
			
			#region WeightUnitMeasureCodeSource
			if (CanDeepSave(entity, "UnitMeasure|WeightUnitMeasureCodeSource", deepSaveType, innerList) 
				&& entity.WeightUnitMeasureCodeSource != null)
			{
				DataRepository.UnitMeasureProvider.Save(transactionManager, entity.WeightUnitMeasureCodeSource);
				entity.WeightUnitMeasureCode = entity.WeightUnitMeasureCodeSource.UnitMeasureCode;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region DocumentIdDocumentCollection_From_ProductDocument>
			if (CanDeepSave(entity.DocumentIdDocumentCollection_From_ProductDocument, "List<Document>|DocumentIdDocumentCollection_From_ProductDocument", deepSaveType, innerList))
			{
				if (entity.DocumentIdDocumentCollection_From_ProductDocument.Count > 0 || entity.DocumentIdDocumentCollection_From_ProductDocument.DeletedItems.Count > 0)
				{
					DataRepository.DocumentProvider.Save(transactionManager, entity.DocumentIdDocumentCollection_From_ProductDocument); 
					deepHandles.Add("DocumentIdDocumentCollection_From_ProductDocument",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Document>) DataRepository.DocumentProvider.DeepSave,
						new object[] { transactionManager, entity.DocumentIdDocumentCollection_From_ProductDocument, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto>
			if (CanDeepSave(entity.ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto, "List<ProductPhoto>|ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto", deepSaveType, innerList))
			{
				if (entity.ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto.Count > 0 || entity.ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto.DeletedItems.Count > 0)
				{
					DataRepository.ProductPhotoProvider.Save(transactionManager, entity.ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto); 
					deepHandles.Add("ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<ProductPhoto>) DataRepository.ProductPhotoProvider.DeepSave,
						new object[] { transactionManager, entity.ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region VendorIdVendorCollection_From_ProductVendor>
			if (CanDeepSave(entity.VendorIdVendorCollection_From_ProductVendor, "List<Vendor>|VendorIdVendorCollection_From_ProductVendor", deepSaveType, innerList))
			{
				if (entity.VendorIdVendorCollection_From_ProductVendor.Count > 0 || entity.VendorIdVendorCollection_From_ProductVendor.DeletedItems.Count > 0)
				{
					DataRepository.VendorProvider.Save(transactionManager, entity.VendorIdVendorCollection_From_ProductVendor); 
					deepHandles.Add("VendorIdVendorCollection_From_ProductVendor",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Vendor>) DataRepository.VendorProvider.DeepSave,
						new object[] { transactionManager, entity.VendorIdVendorCollection_From_ProductVendor, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region LocationIdLocationCollection_From_ProductInventory>
			if (CanDeepSave(entity.LocationIdLocationCollection_From_ProductInventory, "List<Location>|LocationIdLocationCollection_From_ProductInventory", deepSaveType, innerList))
			{
				if (entity.LocationIdLocationCollection_From_ProductInventory.Count > 0 || entity.LocationIdLocationCollection_From_ProductInventory.DeletedItems.Count > 0)
				{
					DataRepository.LocationProvider.Save(transactionManager, entity.LocationIdLocationCollection_From_ProductInventory); 
					deepHandles.Add("LocationIdLocationCollection_From_ProductInventory",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Location>) DataRepository.LocationProvider.DeepSave,
						new object[] { transactionManager, entity.LocationIdLocationCollection_From_ProductInventory, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct>
			if (CanDeepSave(entity.SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct, "List<SpecialOffer>|SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct", deepSaveType, innerList))
			{
				if (entity.SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct.Count > 0 || entity.SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct.DeletedItems.Count > 0)
				{
					DataRepository.SpecialOfferProvider.Save(transactionManager, entity.SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct); 
					deepHandles.Add("SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<SpecialOffer>) DataRepository.SpecialOfferProvider.DeepSave,
						new object[] { transactionManager, entity.SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct, deepSaveType, childTypes, innerList }
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
						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

						if(child.ProductPhotoIdSource != null)
						{
								child.ProductPhotoId = child.ProductPhotoIdSource.ProductPhotoId;
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
				
	
			#region List<TransactionHistory>
				if (CanDeepSave(entity.TransactionHistoryCollection, "List<TransactionHistory>|TransactionHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(TransactionHistory child in entity.TransactionHistoryCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.ProductId;
						}
						else
						{
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.TransactionHistoryCollection.Count > 0 || entity.TransactionHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.TransactionHistoryProvider.Save(transactionManager, entity.TransactionHistoryCollection);
						
						deepHandles.Add("TransactionHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< TransactionHistory >) DataRepository.TransactionHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.TransactionHistoryCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProductVendor>
				if (CanDeepSave(entity.ProductVendorCollection, "List<ProductVendor>|ProductVendorCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductVendor child in entity.ProductVendorCollection)
					{
						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

						if(child.VendorIdSource != null)
						{
								child.VendorId = child.VendorIdSource.VendorId;
						}

					}

					if (entity.ProductVendorCollection.Count > 0 || entity.ProductVendorCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductVendorProvider.Save(transactionManager, entity.ProductVendorCollection);
						
						deepHandles.Add("ProductVendorCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductVendor >) DataRepository.ProductVendorProvider.DeepSave,
							new object[] { transactionManager, entity.ProductVendorCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<BillOfMaterials>
				if (CanDeepSave(entity.BillOfMaterialsCollectionGetByProductAssemblyId, "List<BillOfMaterials>|BillOfMaterialsCollectionGetByProductAssemblyId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(BillOfMaterials child in entity.BillOfMaterialsCollectionGetByProductAssemblyId)
					{
						if(child.ProductAssemblyIdSource != null)
						{
							child.ProductAssemblyId = child.ProductAssemblyIdSource.ProductId;
						}
						else
						{
							child.ProductAssemblyId = entity.ProductId;
						}

					}

					if (entity.BillOfMaterialsCollectionGetByProductAssemblyId.Count > 0 || entity.BillOfMaterialsCollectionGetByProductAssemblyId.DeletedItems.Count > 0)
					{
						//DataRepository.BillOfMaterialsProvider.Save(transactionManager, entity.BillOfMaterialsCollectionGetByProductAssemblyId);
						
						deepHandles.Add("BillOfMaterialsCollectionGetByProductAssemblyId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< BillOfMaterials >) DataRepository.BillOfMaterialsProvider.DeepSave,
							new object[] { transactionManager, entity.BillOfMaterialsCollectionGetByProductAssemblyId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SpecialOfferProduct>
				if (CanDeepSave(entity.SpecialOfferProductCollection, "List<SpecialOfferProduct>|SpecialOfferProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SpecialOfferProduct child in entity.SpecialOfferProductCollection)
					{
						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

						if(child.SpecialOfferIdSource != null)
						{
								child.SpecialOfferId = child.SpecialOfferIdSource.SpecialOfferId;
						}

					}

					if (entity.SpecialOfferProductCollection.Count > 0 || entity.SpecialOfferProductCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SpecialOfferProductProvider.Save(transactionManager, entity.SpecialOfferProductCollection);
						
						deepHandles.Add("SpecialOfferProductCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SpecialOfferProduct >) DataRepository.SpecialOfferProductProvider.DeepSave,
							new object[] { transactionManager, entity.SpecialOfferProductCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<BillOfMaterials>
				if (CanDeepSave(entity.BillOfMaterialsCollectionGetByComponentId, "List<BillOfMaterials>|BillOfMaterialsCollectionGetByComponentId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(BillOfMaterials child in entity.BillOfMaterialsCollectionGetByComponentId)
					{
						if(child.ComponentIdSource != null)
						{
							child.ComponentId = child.ComponentIdSource.ProductId;
						}
						else
						{
							child.ComponentId = entity.ProductId;
						}

					}

					if (entity.BillOfMaterialsCollectionGetByComponentId.Count > 0 || entity.BillOfMaterialsCollectionGetByComponentId.DeletedItems.Count > 0)
					{
						//DataRepository.BillOfMaterialsProvider.Save(transactionManager, entity.BillOfMaterialsCollectionGetByComponentId);
						
						deepHandles.Add("BillOfMaterialsCollectionGetByComponentId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< BillOfMaterials >) DataRepository.BillOfMaterialsProvider.DeepSave,
							new object[] { transactionManager, entity.BillOfMaterialsCollectionGetByComponentId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProductInventory>
				if (CanDeepSave(entity.ProductInventoryCollection, "List<ProductInventory>|ProductInventoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductInventory child in entity.ProductInventoryCollection)
					{
						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

						if(child.LocationIdSource != null)
						{
								child.LocationId = child.LocationIdSource.LocationId;
						}

					}

					if (entity.ProductInventoryCollection.Count > 0 || entity.ProductInventoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductInventoryProvider.Save(transactionManager, entity.ProductInventoryCollection);
						
						deepHandles.Add("ProductInventoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductInventory >) DataRepository.ProductInventoryProvider.DeepSave,
							new object[] { transactionManager, entity.ProductInventoryCollection, deepSaveType, childTypes, innerList }
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
						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

						if(child.DocumentIdSource != null)
						{
								child.DocumentId = child.DocumentIdSource.DocumentId;
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
				
	
			#region List<ProductReview>
				if (CanDeepSave(entity.ProductReviewCollection, "List<ProductReview>|ProductReviewCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductReview child in entity.ProductReviewCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.ProductId;
						}
						else
						{
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.ProductReviewCollection.Count > 0 || entity.ProductReviewCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductReviewProvider.Save(transactionManager, entity.ProductReviewCollection);
						
						deepHandles.Add("ProductReviewCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductReview >) DataRepository.ProductReviewProvider.DeepSave,
							new object[] { transactionManager, entity.ProductReviewCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<WorkOrder>
				if (CanDeepSave(entity.WorkOrderCollection, "List<WorkOrder>|WorkOrderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WorkOrder child in entity.WorkOrderCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.ProductId;
						}
						else
						{
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.WorkOrderCollection.Count > 0 || entity.WorkOrderCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WorkOrderProvider.Save(transactionManager, entity.WorkOrderCollection);
						
						deepHandles.Add("WorkOrderCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WorkOrder >) DataRepository.WorkOrderProvider.DeepSave,
							new object[] { transactionManager, entity.WorkOrderCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<PurchaseOrderDetail>
				if (CanDeepSave(entity.PurchaseOrderDetailCollection, "List<PurchaseOrderDetail>|PurchaseOrderDetailCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PurchaseOrderDetail child in entity.PurchaseOrderDetailCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.ProductId;
						}
						else
						{
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.PurchaseOrderDetailCollection.Count > 0 || entity.PurchaseOrderDetailCollection.DeletedItems.Count > 0)
					{
						//DataRepository.PurchaseOrderDetailProvider.Save(transactionManager, entity.PurchaseOrderDetailCollection);
						
						deepHandles.Add("PurchaseOrderDetailCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< PurchaseOrderDetail >) DataRepository.PurchaseOrderDetailProvider.DeepSave,
							new object[] { transactionManager, entity.PurchaseOrderDetailCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProductListPriceHistory>
				if (CanDeepSave(entity.ProductListPriceHistoryCollection, "List<ProductListPriceHistory>|ProductListPriceHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductListPriceHistory child in entity.ProductListPriceHistoryCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.ProductId;
						}
						else
						{
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.ProductListPriceHistoryCollection.Count > 0 || entity.ProductListPriceHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductListPriceHistoryProvider.Save(transactionManager, entity.ProductListPriceHistoryCollection);
						
						deepHandles.Add("ProductListPriceHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductListPriceHistory >) DataRepository.ProductListPriceHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.ProductListPriceHistoryCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ShoppingCartItem>
				if (CanDeepSave(entity.ShoppingCartItemCollection, "List<ShoppingCartItem>|ShoppingCartItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ShoppingCartItem child in entity.ShoppingCartItemCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.ProductId;
						}
						else
						{
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.ShoppingCartItemCollection.Count > 0 || entity.ShoppingCartItemCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ShoppingCartItemProvider.Save(transactionManager, entity.ShoppingCartItemCollection);
						
						deepHandles.Add("ShoppingCartItemCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ShoppingCartItem >) DataRepository.ShoppingCartItemProvider.DeepSave,
							new object[] { transactionManager, entity.ShoppingCartItemCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProductCostHistory>
				if (CanDeepSave(entity.ProductCostHistoryCollection, "List<ProductCostHistory>|ProductCostHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductCostHistory child in entity.ProductCostHistoryCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.ProductId;
						}
						else
						{
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.ProductCostHistoryCollection.Count > 0 || entity.ProductCostHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductCostHistoryProvider.Save(transactionManager, entity.ProductCostHistoryCollection);
						
						deepHandles.Add("ProductCostHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductCostHistory >) DataRepository.ProductCostHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.ProductCostHistoryCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProductChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Product</c>
	///</summary>
	public enum ProductChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ProductModel</c> at ProductModelIdSource
		///</summary>
		[ChildEntityType(typeof(ProductModel))]
		ProductModel,
			
		///<summary>
		/// Composite Property for <c>ProductSubcategory</c> at ProductSubcategoryIdSource
		///</summary>
		[ChildEntityType(typeof(ProductSubcategory))]
		ProductSubcategory,
			
		///<summary>
		/// Composite Property for <c>UnitMeasure</c> at SizeUnitMeasureCodeSource
		///</summary>
		[ChildEntityType(typeof(UnitMeasure))]
		UnitMeasure,
	
		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductProductPhotoCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductProductPhoto>))]
		ProductProductPhotoCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for TransactionHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<TransactionHistory>))]
		TransactionHistoryCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductVendorCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductVendor>))]
		ProductVendorCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for BillOfMaterialsCollection
		///</summary>
		[ChildEntityType(typeof(TList<BillOfMaterials>))]
		BillOfMaterialsCollectionGetByProductAssemblyId,

		///<summary>
		/// Collection of <c>Product</c> as ManyToMany for DocumentCollection_From_ProductDocument
		///</summary>
		[ChildEntityType(typeof(TList<Document>))]
		DocumentIdDocumentCollection_From_ProductDocument,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for SpecialOfferProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<SpecialOfferProduct>))]
		SpecialOfferProductCollection,

		///<summary>
		/// Collection of <c>Product</c> as ManyToMany for ProductPhotoCollection_From_ProductProductPhoto
		///</summary>
		[ChildEntityType(typeof(TList<ProductPhoto>))]
		ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for BillOfMaterialsCollection
		///</summary>
		[ChildEntityType(typeof(TList<BillOfMaterials>))]
		BillOfMaterialsCollectionGetByComponentId,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductInventoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductInventory>))]
		ProductInventoryCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductDocumentCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductDocument>))]
		ProductDocumentCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductReviewCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductReview>))]
		ProductReviewCollection,

		///<summary>
		/// Collection of <c>Product</c> as ManyToMany for VendorCollection_From_ProductVendor
		///</summary>
		[ChildEntityType(typeof(TList<Vendor>))]
		VendorIdVendorCollection_From_ProductVendor,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for WorkOrderCollection
		///</summary>
		[ChildEntityType(typeof(TList<WorkOrder>))]
		WorkOrderCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for PurchaseOrderDetailCollection
		///</summary>
		[ChildEntityType(typeof(TList<PurchaseOrderDetail>))]
		PurchaseOrderDetailCollection,

		///<summary>
		/// Collection of <c>Product</c> as ManyToMany for LocationCollection_From_ProductInventory
		///</summary>
		[ChildEntityType(typeof(TList<Location>))]
		LocationIdLocationCollection_From_ProductInventory,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductListPriceHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductListPriceHistory>))]
		ProductListPriceHistoryCollection,

		///<summary>
		/// Collection of <c>Product</c> as ManyToMany for SpecialOfferCollection_From_SpecialOfferProduct
		///</summary>
		[ChildEntityType(typeof(TList<SpecialOffer>))]
		SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ShoppingCartItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<ShoppingCartItem>))]
		ShoppingCartItemCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductCostHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductCostHistory>))]
		ProductCostHistoryCollection,
	}
	
	#endregion ProductChildEntityTypes
	
	#region ProductFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductColumn&gt;"/> class
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
	
	#region ProductParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductParameterBuilder : ParameterizedSqlFilterBuilder<ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		public ProductParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductParameterBuilder
	
	#region ProductSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductSortBuilder : SqlSortBuilder<ProductColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSqlSortBuilder class.
		/// </summary>
		public ProductSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductSortBuilder
	
} // end namespace
