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
	/// This class is the base class for any <see cref="ProductVendorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductVendorProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductVendor, Nettiers.AdventureWorks.Entities.ProductVendorKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductVendorKey key)
		{
			return Delete(transactionManager, key.ProductId, key.VendorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productId, System.Int32 _vendorId)
		{
			return Delete(null, _productId, _vendorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _vendorId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductVendor_Product_ProductID key.
		///		FK_ProductVendor_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductVendor objects.</returns>
		public TList<ProductVendor> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(_productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductVendor_Product_ProductID key.
		///		FK_ProductVendor_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductVendor objects.</returns>
		/// <remarks></remarks>
		public TList<ProductVendor> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductVendor_Product_ProductID key.
		///		FK_ProductVendor_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductVendor objects.</returns>
		public TList<ProductVendor> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductVendor_Product_ProductID key.
		///		fkProductVendorProductProductId Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductVendor objects.</returns>
		public TList<ProductVendor> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductVendor_Product_ProductID key.
		///		fkProductVendorProductProductId Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductVendor objects.</returns>
		public TList<ProductVendor> GetByProductId(System.Int32 _productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductVendor_Product_ProductID key.
		///		FK_ProductVendor_Product_ProductID Description: Foreign key constraint referencing Product.ProductID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductVendor objects.</returns>
		public abstract TList<ProductVendor> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.ProductVendor Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductVendorKey key, int start, int pageLength)
		{
			return GetByProductIdVendorId(transactionManager, key.ProductId, key.VendorId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ProductVendor_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">The product's unit of measure.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByUnitMeasureCode(System.String _unitMeasureCode)
		{
			int count = -1;
			return GetByUnitMeasureCode(null,_unitMeasureCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">The product's unit of measure.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByUnitMeasureCode(System.String _unitMeasureCode, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitMeasureCode(null, _unitMeasureCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">The product's unit of measure.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode)
		{
			int count = -1;
			return GetByUnitMeasureCode(transactionManager, _unitMeasureCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">The product's unit of measure.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitMeasureCode(transactionManager, _unitMeasureCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">The product's unit of measure.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByUnitMeasureCode(System.String _unitMeasureCode, int start, int pageLength, out int count)
		{
			return GetByUnitMeasureCode(null, _unitMeasureCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">The product's unit of measure.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public abstract TList<ProductVendor> GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ProductVendor_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByVendorId(System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(null,_vendorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByVendorId(System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorId(null, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public TList<ProductVendor> GetByVendorId(System.Int32 _vendorId, int start, int pageLength, out int count)
		{
			return GetByVendorId(null, _vendorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductVendor_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductVendor&gt;"/> class.</returns>
		public abstract TList<ProductVendor> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductVendor_ProductID_VendorID index.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductVendor GetByProductIdVendorId(System.Int32 _productId, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByProductIdVendorId(null,_productId, _vendorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductVendor_ProductID_VendorID index.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductVendor GetByProductIdVendorId(System.Int32 _productId, System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdVendorId(null, _productId, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductVendor_ProductID_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductVendor GetByProductIdVendorId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByProductIdVendorId(transactionManager, _productId, _vendorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductVendor_ProductID_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductVendor GetByProductIdVendorId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdVendorId(transactionManager, _productId, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductVendor_ProductID_VendorID index.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductVendor GetByProductIdVendorId(System.Int32 _productId, System.Int32 _vendorId, int start, int pageLength, out int count)
		{
			return GetByProductIdVendorId(null, _productId, _vendorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductVendor_ProductID_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductVendor GetByProductIdVendorId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _vendorId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductVendor&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductVendor&gt;"/></returns>
		public static TList<ProductVendor> Fill(IDataReader reader, TList<ProductVendor> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductVendor c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductVendor")
					.Append("|").Append((System.Int32)reader[((int)ProductVendorColumn.ProductId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ProductVendorColumn.VendorId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductVendor>(
					key.ToString(), // EntityTrackingKey
					"ProductVendor",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductVendor();
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
					c.ProductId = (System.Int32)reader[((int)ProductVendorColumn.ProductId - 1)];
					c.OriginalProductId = c.ProductId;
					c.VendorId = (System.Int32)reader[((int)ProductVendorColumn.VendorId - 1)];
					c.OriginalVendorId = c.VendorId;
					c.AverageLeadTime = (System.Int32)reader[((int)ProductVendorColumn.AverageLeadTime - 1)];
					c.StandardPrice = (System.Decimal)reader[((int)ProductVendorColumn.StandardPrice - 1)];
					c.LastReceiptCost = (reader.IsDBNull(((int)ProductVendorColumn.LastReceiptCost - 1)))?null:(System.Decimal?)reader[((int)ProductVendorColumn.LastReceiptCost - 1)];
					c.LastReceiptDate = (reader.IsDBNull(((int)ProductVendorColumn.LastReceiptDate - 1)))?null:(System.DateTime?)reader[((int)ProductVendorColumn.LastReceiptDate - 1)];
					c.MinOrderQty = (System.Int32)reader[((int)ProductVendorColumn.MinOrderQty - 1)];
					c.MaxOrderQty = (System.Int32)reader[((int)ProductVendorColumn.MaxOrderQty - 1)];
					c.OnOrderQty = (reader.IsDBNull(((int)ProductVendorColumn.OnOrderQty - 1)))?null:(System.Int32?)reader[((int)ProductVendorColumn.OnOrderQty - 1)];
					c.UnitMeasureCode = (System.String)reader[((int)ProductVendorColumn.UnitMeasureCode - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ProductVendorColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductVendor entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductId = (System.Int32)reader[((int)ProductVendorColumn.ProductId - 1)];
			entity.OriginalProductId = (System.Int32)reader["ProductID"];
			entity.VendorId = (System.Int32)reader[((int)ProductVendorColumn.VendorId - 1)];
			entity.OriginalVendorId = (System.Int32)reader["VendorID"];
			entity.AverageLeadTime = (System.Int32)reader[((int)ProductVendorColumn.AverageLeadTime - 1)];
			entity.StandardPrice = (System.Decimal)reader[((int)ProductVendorColumn.StandardPrice - 1)];
			entity.LastReceiptCost = (reader.IsDBNull(((int)ProductVendorColumn.LastReceiptCost - 1)))?null:(System.Decimal?)reader[((int)ProductVendorColumn.LastReceiptCost - 1)];
			entity.LastReceiptDate = (reader.IsDBNull(((int)ProductVendorColumn.LastReceiptDate - 1)))?null:(System.DateTime?)reader[((int)ProductVendorColumn.LastReceiptDate - 1)];
			entity.MinOrderQty = (System.Int32)reader[((int)ProductVendorColumn.MinOrderQty - 1)];
			entity.MaxOrderQty = (System.Int32)reader[((int)ProductVendorColumn.MaxOrderQty - 1)];
			entity.OnOrderQty = (reader.IsDBNull(((int)ProductVendorColumn.OnOrderQty - 1)))?null:(System.Int32?)reader[((int)ProductVendorColumn.OnOrderQty - 1)];
			entity.UnitMeasureCode = (System.String)reader[((int)ProductVendorColumn.UnitMeasureCode - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductVendorColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductVendor entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OriginalProductId = (System.Int32)dataRow["ProductID"];
			entity.VendorId = (System.Int32)dataRow["VendorID"];
			entity.OriginalVendorId = (System.Int32)dataRow["VendorID"];
			entity.AverageLeadTime = (System.Int32)dataRow["AverageLeadTime"];
			entity.StandardPrice = (System.Decimal)dataRow["StandardPrice"];
			entity.LastReceiptCost = Convert.IsDBNull(dataRow["LastReceiptCost"]) ? null : (System.Decimal?)dataRow["LastReceiptCost"];
			entity.LastReceiptDate = Convert.IsDBNull(dataRow["LastReceiptDate"]) ? null : (System.DateTime?)dataRow["LastReceiptDate"];
			entity.MinOrderQty = (System.Int32)dataRow["MinOrderQty"];
			entity.MaxOrderQty = (System.Int32)dataRow["MaxOrderQty"];
			entity.OnOrderQty = Convert.IsDBNull(dataRow["OnOrderQty"]) ? null : (System.Int32?)dataRow["OnOrderQty"];
			entity.UnitMeasureCode = (System.String)dataRow["UnitMeasureCode"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductVendor"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductVendor Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductVendor entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region UnitMeasureCodeSource	
			if (CanDeepLoad(entity, "UnitMeasure|UnitMeasureCodeSource", deepLoadType, innerList) 
				&& entity.UnitMeasureCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.UnitMeasureCode;
				UnitMeasure tmpEntity = EntityManager.LocateEntity<UnitMeasure>(EntityLocator.ConstructKeyFromPkItems(typeof(UnitMeasure), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UnitMeasureCodeSource = tmpEntity;
				else
					entity.UnitMeasureCodeSource = DataRepository.UnitMeasureProvider.GetByUnitMeasureCode(transactionManager, entity.UnitMeasureCode);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UnitMeasureCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UnitMeasureCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UnitMeasureProvider.DeepLoad(transactionManager, entity.UnitMeasureCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UnitMeasureCodeSource

			#region VendorIdSource	
			if (CanDeepLoad(entity, "Vendor|VendorIdSource", deepLoadType, innerList) 
				&& entity.VendorIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.VendorId;
				Vendor tmpEntity = EntityManager.LocateEntity<Vendor>(EntityLocator.ConstructKeyFromPkItems(typeof(Vendor), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.VendorIdSource = tmpEntity;
				else
					entity.VendorIdSource = DataRepository.VendorProvider.GetByVendorId(transactionManager, entity.VendorId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.VendorIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.VendorProvider.DeepLoad(transactionManager, entity.VendorIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion VendorIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductVendor object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductVendor instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductVendor Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductVendor entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region UnitMeasureCodeSource
			if (CanDeepSave(entity, "UnitMeasure|UnitMeasureCodeSource", deepSaveType, innerList) 
				&& entity.UnitMeasureCodeSource != null)
			{
				DataRepository.UnitMeasureProvider.Save(transactionManager, entity.UnitMeasureCodeSource);
				entity.UnitMeasureCode = entity.UnitMeasureCodeSource.UnitMeasureCode;
			}
			#endregion 
			
			#region VendorIdSource
			if (CanDeepSave(entity, "Vendor|VendorIdSource", deepSaveType, innerList) 
				&& entity.VendorIdSource != null)
			{
				DataRepository.VendorProvider.Save(transactionManager, entity.VendorIdSource);
				entity.VendorId = entity.VendorIdSource.VendorId;
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
	
	#region ProductVendorChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductVendor</c>
	///</summary>
	public enum ProductVendorChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>UnitMeasure</c> at UnitMeasureCodeSource
		///</summary>
		[ChildEntityType(typeof(UnitMeasure))]
		UnitMeasure,
			
		///<summary>
		/// Composite Property for <c>Vendor</c> at VendorIdSource
		///</summary>
		[ChildEntityType(typeof(Vendor))]
		Vendor,
		}
	
	#endregion ProductVendorChildEntityTypes
	
	#region ProductVendorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductVendorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductVendorFilterBuilder : SqlFilterBuilder<ProductVendorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductVendorFilterBuilder class.
		/// </summary>
		public ProductVendorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductVendorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductVendorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductVendorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductVendorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductVendorFilterBuilder
	
	#region ProductVendorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductVendorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductVendorParameterBuilder : ParameterizedSqlFilterBuilder<ProductVendorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductVendorParameterBuilder class.
		/// </summary>
		public ProductVendorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductVendorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductVendorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductVendorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductVendorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductVendorParameterBuilder
	
	#region ProductVendorSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductVendorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductVendor"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductVendorSortBuilder : SqlSortBuilder<ProductVendorColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductVendorSqlSortBuilder class.
		/// </summary>
		public ProductVendorSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductVendorSortBuilder
	
} // end namespace
