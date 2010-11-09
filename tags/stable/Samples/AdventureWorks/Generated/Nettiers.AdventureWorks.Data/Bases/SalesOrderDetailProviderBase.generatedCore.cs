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
	/// This class is the base class for any <see cref="SalesOrderDetailProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesOrderDetailProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesOrderDetail, Nettiers.AdventureWorks.Entities.SalesOrderDetailKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderDetailKey key)
		{
			return Delete(transactionManager, key.SalesOrderId, key.SalesOrderDetailId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.. Primary Key.</param>
		/// <param name="_salesOrderDetailId">Primary key. One incremental unique number per product sold.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salesOrderId, System.Int32 _salesOrderDetailId)
		{
			return Delete(null, _salesOrderId, _salesOrderDetailId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.. Primary Key.</param>
		/// <param name="_salesOrderDetailId">Primary key. One incremental unique number per product sold.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salesOrderId, System.Int32 _salesOrderDetailId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID key.
		///		FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID Description: Foreign key constraint referencing SalesOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public TList<SalesOrderDetail> GetBySalesOrderId(System.Int32 _salesOrderId)
		{
			int count = -1;
			return GetBySalesOrderId(_salesOrderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID key.
		///		FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID Description: Foreign key constraint referencing SalesOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderDetail> GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId)
		{
			int count = -1;
			return GetBySalesOrderId(transactionManager, _salesOrderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID key.
		///		FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID Description: Foreign key constraint referencing SalesOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public TList<SalesOrderDetail> GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderId(transactionManager, _salesOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID key.
		///		fkSalesOrderDetailSalesOrderHeaderSalesOrderId Description: Foreign key constraint referencing SalesOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public TList<SalesOrderDetail> GetBySalesOrderId(System.Int32 _salesOrderId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesOrderId(null, _salesOrderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID key.
		///		fkSalesOrderDetailSalesOrderHeaderSalesOrderId Description: Foreign key constraint referencing SalesOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public TList<SalesOrderDetail> GetBySalesOrderId(System.Int32 _salesOrderId, int start, int pageLength,out int count)
		{
			return GetBySalesOrderId(null, _salesOrderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID key.
		///		FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID Description: Foreign key constraint referencing SalesOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public abstract TList<SalesOrderDetail> GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID key.
		///		FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID Description: Foreign key constraint referencing SpecialOfferProduct.SpecialOfferIDProductID.
		/// </summary>
		/// <param name="_specialOfferId">Promotional code. Foreign key to SpecialOffer.SpecialOfferID.</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public TList<SalesOrderDetail> GetBySpecialOfferIdProductId(System.Int32 _specialOfferId, System.Int32 _productId)
		{
			int count = -1;
			return GetBySpecialOfferIdProductId(_specialOfferId, _productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID key.
		///		FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID Description: Foreign key constraint referencing SpecialOfferProduct.SpecialOfferIDProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Promotional code. Foreign key to SpecialOffer.SpecialOfferID.</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderDetail> GetBySpecialOfferIdProductId(TransactionManager transactionManager, System.Int32 _specialOfferId, System.Int32 _productId)
		{
			int count = -1;
			return GetBySpecialOfferIdProductId(transactionManager, _specialOfferId, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID key.
		///		FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID Description: Foreign key constraint referencing SpecialOfferProduct.SpecialOfferIDProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Promotional code. Foreign key to SpecialOffer.SpecialOfferID.</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public TList<SalesOrderDetail> GetBySpecialOfferIdProductId(TransactionManager transactionManager, System.Int32 _specialOfferId, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetBySpecialOfferIdProductId(transactionManager, _specialOfferId, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID key.
		///		fkSalesOrderDetailSpecialOfferProductSpecialOfferIdProductId Description: Foreign key constraint referencing SpecialOfferProduct.SpecialOfferIDProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_specialOfferId">Promotional code. Foreign key to SpecialOffer.SpecialOfferID.</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public TList<SalesOrderDetail> GetBySpecialOfferIdProductId(System.Int32 _specialOfferId, System.Int32 _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySpecialOfferIdProductId(null, _specialOfferId, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID key.
		///		fkSalesOrderDetailSpecialOfferProductSpecialOfferIdProductId Description: Foreign key constraint referencing SpecialOfferProduct.SpecialOfferIDProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_specialOfferId">Promotional code. Foreign key to SpecialOffer.SpecialOfferID.</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public TList<SalesOrderDetail> GetBySpecialOfferIdProductId(System.Int32 _specialOfferId, System.Int32 _productId, int start, int pageLength,out int count)
		{
			return GetBySpecialOfferIdProductId(null, _specialOfferId, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID key.
		///		FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID Description: Foreign key constraint referencing SpecialOfferProduct.SpecialOfferIDProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Promotional code. Foreign key to SpecialOffer.SpecialOfferID.</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderDetail objects.</returns>
		public abstract TList<SalesOrderDetail> GetBySpecialOfferIdProductId(TransactionManager transactionManager, System.Int32 _specialOfferId, System.Int32 _productId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.SalesOrderDetail Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderDetailKey key, int start, int pageLength)
		{
			return GetBySalesOrderIdSalesOrderDetailId(transactionManager, key.SalesOrderId, key.SalesOrderDetailId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesOrderDetail_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderDetail_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderDetail_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderDetail_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderDetail_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderDetail_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesOrderDetail GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SalesOrderDetail_ProductID index.
		/// </summary>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderDetail&gt;"/> class.</returns>
		public TList<SalesOrderDetail> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderDetail_ProductID index.
		/// </summary>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderDetail&gt;"/> class.</returns>
		public TList<SalesOrderDetail> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderDetail_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderDetail&gt;"/> class.</returns>
		public TList<SalesOrderDetail> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderDetail_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderDetail&gt;"/> class.</returns>
		public TList<SalesOrderDetail> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderDetail_ProductID index.
		/// </summary>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderDetail&gt;"/> class.</returns>
		public TList<SalesOrderDetail> GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderDetail_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product sold to customer. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderDetail&gt;"/> class.</returns>
		public abstract TList<SalesOrderDetail> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesOrderDetailId">Primary key. One incremental unique number per product sold.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetBySalesOrderIdSalesOrderDetailId(System.Int32 _salesOrderId, System.Int32 _salesOrderDetailId)
		{
			int count = -1;
			return GetBySalesOrderIdSalesOrderDetailId(null,_salesOrderId, _salesOrderDetailId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesOrderDetailId">Primary key. One incremental unique number per product sold.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetBySalesOrderIdSalesOrderDetailId(System.Int32 _salesOrderId, System.Int32 _salesOrderDetailId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderIdSalesOrderDetailId(null, _salesOrderId, _salesOrderDetailId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesOrderDetailId">Primary key. One incremental unique number per product sold.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetBySalesOrderIdSalesOrderDetailId(TransactionManager transactionManager, System.Int32 _salesOrderId, System.Int32 _salesOrderDetailId)
		{
			int count = -1;
			return GetBySalesOrderIdSalesOrderDetailId(transactionManager, _salesOrderId, _salesOrderDetailId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesOrderDetailId">Primary key. One incremental unique number per product sold.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetBySalesOrderIdSalesOrderDetailId(TransactionManager transactionManager, System.Int32 _salesOrderId, System.Int32 _salesOrderDetailId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderIdSalesOrderDetailId(transactionManager, _salesOrderId, _salesOrderDetailId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesOrderDetailId">Primary key. One incremental unique number per product sold.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderDetail GetBySalesOrderIdSalesOrderDetailId(System.Int32 _salesOrderId, System.Int32 _salesOrderDetailId, int start, int pageLength, out int count)
		{
			return GetBySalesOrderIdSalesOrderDetailId(null, _salesOrderId, _salesOrderDetailId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesOrderDetailId">Primary key. One incremental unique number per product sold.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesOrderDetail GetBySalesOrderIdSalesOrderDetailId(TransactionManager transactionManager, System.Int32 _salesOrderId, System.Int32 _salesOrderDetailId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesOrderDetail&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesOrderDetail&gt;"/></returns>
		public static TList<SalesOrderDetail> Fill(IDataReader reader, TList<SalesOrderDetail> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SalesOrderDetail c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesOrderDetail")
					.Append("|").Append((System.Int32)reader[((int)SalesOrderDetailColumn.SalesOrderId - 1)])
					.Append("|").Append((System.Int32)reader[((int)SalesOrderDetailColumn.SalesOrderDetailId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesOrderDetail>(
					key.ToString(), // EntityTrackingKey
					"SalesOrderDetail",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesOrderDetail();
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
					c.SalesOrderId = (System.Int32)reader[((int)SalesOrderDetailColumn.SalesOrderId - 1)];
					c.OriginalSalesOrderId = c.SalesOrderId;
					c.SalesOrderDetailId = (System.Int32)reader[((int)SalesOrderDetailColumn.SalesOrderDetailId - 1)];
					c.CarrierTrackingNumber = (reader.IsDBNull(((int)SalesOrderDetailColumn.CarrierTrackingNumber - 1)))?null:(System.String)reader[((int)SalesOrderDetailColumn.CarrierTrackingNumber - 1)];
					c.OrderQty = (System.Int16)reader[((int)SalesOrderDetailColumn.OrderQty - 1)];
					c.ProductId = (System.Int32)reader[((int)SalesOrderDetailColumn.ProductId - 1)];
					c.SpecialOfferId = (System.Int32)reader[((int)SalesOrderDetailColumn.SpecialOfferId - 1)];
					c.UnitPrice = (System.Decimal)reader[((int)SalesOrderDetailColumn.UnitPrice - 1)];
					c.UnitPriceDiscount = (System.Decimal)reader[((int)SalesOrderDetailColumn.UnitPriceDiscount - 1)];
					c.LineTotal = (System.Decimal)reader[((int)SalesOrderDetailColumn.LineTotal - 1)];
					c.Rowguid = (System.Guid)reader[((int)SalesOrderDetailColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SalesOrderDetailColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesOrderDetail entity)
		{
			if (!reader.Read()) return;
			
			entity.SalesOrderId = (System.Int32)reader[((int)SalesOrderDetailColumn.SalesOrderId - 1)];
			entity.OriginalSalesOrderId = (System.Int32)reader["SalesOrderID"];
			entity.SalesOrderDetailId = (System.Int32)reader[((int)SalesOrderDetailColumn.SalesOrderDetailId - 1)];
			entity.CarrierTrackingNumber = (reader.IsDBNull(((int)SalesOrderDetailColumn.CarrierTrackingNumber - 1)))?null:(System.String)reader[((int)SalesOrderDetailColumn.CarrierTrackingNumber - 1)];
			entity.OrderQty = (System.Int16)reader[((int)SalesOrderDetailColumn.OrderQty - 1)];
			entity.ProductId = (System.Int32)reader[((int)SalesOrderDetailColumn.ProductId - 1)];
			entity.SpecialOfferId = (System.Int32)reader[((int)SalesOrderDetailColumn.SpecialOfferId - 1)];
			entity.UnitPrice = (System.Decimal)reader[((int)SalesOrderDetailColumn.UnitPrice - 1)];
			entity.UnitPriceDiscount = (System.Decimal)reader[((int)SalesOrderDetailColumn.UnitPriceDiscount - 1)];
			entity.LineTotal = (System.Decimal)reader[((int)SalesOrderDetailColumn.LineTotal - 1)];
			entity.Rowguid = (System.Guid)reader[((int)SalesOrderDetailColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesOrderDetailColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesOrderDetail entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesOrderId = (System.Int32)dataRow["SalesOrderID"];
			entity.OriginalSalesOrderId = (System.Int32)dataRow["SalesOrderID"];
			entity.SalesOrderDetailId = (System.Int32)dataRow["SalesOrderDetailID"];
			entity.CarrierTrackingNumber = Convert.IsDBNull(dataRow["CarrierTrackingNumber"]) ? null : (System.String)dataRow["CarrierTrackingNumber"];
			entity.OrderQty = (System.Int16)dataRow["OrderQty"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.SpecialOfferId = (System.Int32)dataRow["SpecialOfferID"];
			entity.UnitPrice = (System.Decimal)dataRow["UnitPrice"];
			entity.UnitPriceDiscount = (System.Decimal)dataRow["UnitPriceDiscount"];
			entity.LineTotal = (System.Decimal)dataRow["LineTotal"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderDetail"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesOrderDetail Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderDetail entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SalesOrderIdSource	
			if (CanDeepLoad(entity, "SalesOrderHeader|SalesOrderIdSource", deepLoadType, innerList) 
				&& entity.SalesOrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalesOrderId;
				SalesOrderHeader tmpEntity = EntityManager.LocateEntity<SalesOrderHeader>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesOrderHeader), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesOrderIdSource = tmpEntity;
				else
					entity.SalesOrderIdSource = DataRepository.SalesOrderHeaderProvider.GetBySalesOrderId(transactionManager, entity.SalesOrderId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesOrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesOrderHeaderProvider.DeepLoad(transactionManager, entity.SalesOrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesOrderIdSource

			#region SpecialOfferIdProductIdSource	
			if (CanDeepLoad(entity, "SpecialOfferProduct|SpecialOfferIdProductIdSource", deepLoadType, innerList) 
				&& entity.SpecialOfferIdProductIdSource == null)
			{
				object[] pkItems = new object[2];
				pkItems[0] = entity.SpecialOfferId;
				pkItems[1] = entity.ProductId;
				SpecialOfferProduct tmpEntity = EntityManager.LocateEntity<SpecialOfferProduct>(EntityLocator.ConstructKeyFromPkItems(typeof(SpecialOfferProduct), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SpecialOfferIdProductIdSource = tmpEntity;
				else
					entity.SpecialOfferIdProductIdSource = DataRepository.SpecialOfferProductProvider.GetBySpecialOfferIdProductId(transactionManager, entity.SpecialOfferId, entity.ProductId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SpecialOfferIdProductIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SpecialOfferIdProductIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SpecialOfferProductProvider.DeepLoad(transactionManager, entity.SpecialOfferIdProductIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SpecialOfferIdProductIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesOrderDetail object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesOrderDetail instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesOrderDetail Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderDetail entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SalesOrderIdSource
			if (CanDeepSave(entity, "SalesOrderHeader|SalesOrderIdSource", deepSaveType, innerList) 
				&& entity.SalesOrderIdSource != null)
			{
				DataRepository.SalesOrderHeaderProvider.Save(transactionManager, entity.SalesOrderIdSource);
				entity.SalesOrderId = entity.SalesOrderIdSource.SalesOrderId;
			}
			#endregion 
			
			#region SpecialOfferIdProductIdSource
			if (CanDeepSave(entity, "SpecialOfferProduct|SpecialOfferIdProductIdSource", deepSaveType, innerList) 
				&& entity.SpecialOfferIdProductIdSource != null)
			{
				DataRepository.SpecialOfferProductProvider.Save(transactionManager, entity.SpecialOfferIdProductIdSource);
				entity.SpecialOfferId = entity.SpecialOfferIdProductIdSource.SpecialOfferId;
				entity.ProductId = entity.SpecialOfferIdProductIdSource.ProductId;
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
	
	#region SalesOrderDetailChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesOrderDetail</c>
	///</summary>
	public enum SalesOrderDetailChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SalesOrderHeader</c> at SalesOrderIdSource
		///</summary>
		[ChildEntityType(typeof(SalesOrderHeader))]
		SalesOrderHeader,
			
		///<summary>
		/// Composite Property for <c>SpecialOfferProduct</c> at SpecialOfferIdProductIdSource
		///</summary>
		[ChildEntityType(typeof(SpecialOfferProduct))]
		SpecialOfferProduct,
		}
	
	#endregion SalesOrderDetailChildEntityTypes
	
	#region SalesOrderDetailFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesOrderDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderDetailFilterBuilder : SqlFilterBuilder<SalesOrderDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailFilterBuilder class.
		/// </summary>
		public SalesOrderDetailFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderDetailFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderDetailFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderDetailFilterBuilder
	
	#region SalesOrderDetailParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesOrderDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderDetailParameterBuilder : ParameterizedSqlFilterBuilder<SalesOrderDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailParameterBuilder class.
		/// </summary>
		public SalesOrderDetailParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderDetailParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderDetailParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderDetailParameterBuilder
	
	#region SalesOrderDetailSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesOrderDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderDetail"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesOrderDetailSortBuilder : SqlSortBuilder<SalesOrderDetailColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailSqlSortBuilder class.
		/// </summary>
		public SalesOrderDetailSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesOrderDetailSortBuilder
	
} // end namespace
