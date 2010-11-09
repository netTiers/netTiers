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
	/// This class is the base class for any <see cref="PurchaseOrderDetailProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PurchaseOrderDetailProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.PurchaseOrderDetail, Nettiers.AdventureWorks.Entities.PurchaseOrderDetailKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.PurchaseOrderDetailKey key)
		{
			return Delete(transactionManager, key.PurchaseOrderId, key.PurchaseOrderDetailId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.. Primary Key.</param>
		/// <param name="_purchaseOrderDetailId">Primary key. One line number per purchased product.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _purchaseOrderId, System.Int32 _purchaseOrderDetailId)
		{
			return Delete(null, _purchaseOrderId, _purchaseOrderDetailId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.. Primary Key.</param>
		/// <param name="_purchaseOrderDetailId">Primary key. One line number per purchased product.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _purchaseOrderId, System.Int32 _purchaseOrderDetailId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID key.
		///		FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID Description: Foreign key constraint referencing PurchaseOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderDetail objects.</returns>
		public TList<PurchaseOrderDetail> GetByPurchaseOrderId(System.Int32 _purchaseOrderId)
		{
			int count = -1;
			return GetByPurchaseOrderId(_purchaseOrderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID key.
		///		FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID Description: Foreign key constraint referencing PurchaseOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderDetail objects.</returns>
		/// <remarks></remarks>
		public TList<PurchaseOrderDetail> GetByPurchaseOrderId(TransactionManager transactionManager, System.Int32 _purchaseOrderId)
		{
			int count = -1;
			return GetByPurchaseOrderId(transactionManager, _purchaseOrderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID key.
		///		FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID Description: Foreign key constraint referencing PurchaseOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderDetail objects.</returns>
		public TList<PurchaseOrderDetail> GetByPurchaseOrderId(TransactionManager transactionManager, System.Int32 _purchaseOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetByPurchaseOrderId(transactionManager, _purchaseOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID key.
		///		fkPurchaseOrderDetailPurchaseOrderHeaderPurchaseOrderId Description: Foreign key constraint referencing PurchaseOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderDetail objects.</returns>
		public TList<PurchaseOrderDetail> GetByPurchaseOrderId(System.Int32 _purchaseOrderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPurchaseOrderId(null, _purchaseOrderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID key.
		///		fkPurchaseOrderDetailPurchaseOrderHeaderPurchaseOrderId Description: Foreign key constraint referencing PurchaseOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderDetail objects.</returns>
		public TList<PurchaseOrderDetail> GetByPurchaseOrderId(System.Int32 _purchaseOrderId, int start, int pageLength,out int count)
		{
			return GetByPurchaseOrderId(null, _purchaseOrderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID key.
		///		FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID Description: Foreign key constraint referencing PurchaseOrderHeader.PurchaseOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderDetail objects.</returns>
		public abstract TList<PurchaseOrderDetail> GetByPurchaseOrderId(TransactionManager transactionManager, System.Int32 _purchaseOrderId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.PurchaseOrderDetail Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.PurchaseOrderDetailKey key, int start, int pageLength)
		{
			return GetByPurchaseOrderIdPurchaseOrderDetailId(transactionManager, key.PurchaseOrderId, key.PurchaseOrderDetailId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_PurchaseOrderDetail_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderDetail&gt;"/> class.</returns>
		public TList<PurchaseOrderDetail> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderDetail_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderDetail&gt;"/> class.</returns>
		public TList<PurchaseOrderDetail> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderDetail_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderDetail&gt;"/> class.</returns>
		public TList<PurchaseOrderDetail> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderDetail_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderDetail&gt;"/> class.</returns>
		public TList<PurchaseOrderDetail> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderDetail_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderDetail&gt;"/> class.</returns>
		public TList<PurchaseOrderDetail> GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderDetail_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderDetail&gt;"/> class.</returns>
		public abstract TList<PurchaseOrderDetail> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID index.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="_purchaseOrderDetailId">Primary key. One line number per purchased product.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderDetail GetByPurchaseOrderIdPurchaseOrderDetailId(System.Int32 _purchaseOrderId, System.Int32 _purchaseOrderDetailId)
		{
			int count = -1;
			return GetByPurchaseOrderIdPurchaseOrderDetailId(null,_purchaseOrderId, _purchaseOrderDetailId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID index.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="_purchaseOrderDetailId">Primary key. One line number per purchased product.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderDetail GetByPurchaseOrderIdPurchaseOrderDetailId(System.Int32 _purchaseOrderId, System.Int32 _purchaseOrderDetailId, int start, int pageLength)
		{
			int count = -1;
			return GetByPurchaseOrderIdPurchaseOrderDetailId(null, _purchaseOrderId, _purchaseOrderDetailId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="_purchaseOrderDetailId">Primary key. One line number per purchased product.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderDetail GetByPurchaseOrderIdPurchaseOrderDetailId(TransactionManager transactionManager, System.Int32 _purchaseOrderId, System.Int32 _purchaseOrderDetailId)
		{
			int count = -1;
			return GetByPurchaseOrderIdPurchaseOrderDetailId(transactionManager, _purchaseOrderId, _purchaseOrderDetailId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="_purchaseOrderDetailId">Primary key. One line number per purchased product.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderDetail GetByPurchaseOrderIdPurchaseOrderDetailId(TransactionManager transactionManager, System.Int32 _purchaseOrderId, System.Int32 _purchaseOrderDetailId, int start, int pageLength)
		{
			int count = -1;
			return GetByPurchaseOrderIdPurchaseOrderDetailId(transactionManager, _purchaseOrderId, _purchaseOrderDetailId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID index.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="_purchaseOrderDetailId">Primary key. One line number per purchased product.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderDetail GetByPurchaseOrderIdPurchaseOrderDetailId(System.Int32 _purchaseOrderId, System.Int32 _purchaseOrderDetailId, int start, int pageLength, out int count)
		{
			return GetByPurchaseOrderIdPurchaseOrderDetailId(null, _purchaseOrderId, _purchaseOrderDetailId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.</param>
		/// <param name="_purchaseOrderDetailId">Primary key. One line number per purchased product.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.PurchaseOrderDetail GetByPurchaseOrderIdPurchaseOrderDetailId(TransactionManager transactionManager, System.Int32 _purchaseOrderId, System.Int32 _purchaseOrderDetailId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;PurchaseOrderDetail&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;PurchaseOrderDetail&gt;"/></returns>
		public static TList<PurchaseOrderDetail> Fill(IDataReader reader, TList<PurchaseOrderDetail> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.PurchaseOrderDetail c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("PurchaseOrderDetail")
					.Append("|").Append((System.Int32)reader[((int)PurchaseOrderDetailColumn.PurchaseOrderId - 1)])
					.Append("|").Append((System.Int32)reader[((int)PurchaseOrderDetailColumn.PurchaseOrderDetailId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<PurchaseOrderDetail>(
					key.ToString(), // EntityTrackingKey
					"PurchaseOrderDetail",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.PurchaseOrderDetail();
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
					c.PurchaseOrderId = (System.Int32)reader[((int)PurchaseOrderDetailColumn.PurchaseOrderId - 1)];
					c.OriginalPurchaseOrderId = c.PurchaseOrderId;
					c.PurchaseOrderDetailId = (System.Int32)reader[((int)PurchaseOrderDetailColumn.PurchaseOrderDetailId - 1)];
					c.DueDate = (System.DateTime)reader[((int)PurchaseOrderDetailColumn.DueDate - 1)];
					c.OrderQty = (System.Int16)reader[((int)PurchaseOrderDetailColumn.OrderQty - 1)];
					c.ProductId = (System.Int32)reader[((int)PurchaseOrderDetailColumn.ProductId - 1)];
					c.UnitPrice = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.UnitPrice - 1)];
					c.LineTotal = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.LineTotal - 1)];
					c.ReceivedQty = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.ReceivedQty - 1)];
					c.RejectedQty = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.RejectedQty - 1)];
					c.StockedQty = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.StockedQty - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)PurchaseOrderDetailColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.PurchaseOrderDetail entity)
		{
			if (!reader.Read()) return;
			
			entity.PurchaseOrderId = (System.Int32)reader[((int)PurchaseOrderDetailColumn.PurchaseOrderId - 1)];
			entity.OriginalPurchaseOrderId = (System.Int32)reader["PurchaseOrderID"];
			entity.PurchaseOrderDetailId = (System.Int32)reader[((int)PurchaseOrderDetailColumn.PurchaseOrderDetailId - 1)];
			entity.DueDate = (System.DateTime)reader[((int)PurchaseOrderDetailColumn.DueDate - 1)];
			entity.OrderQty = (System.Int16)reader[((int)PurchaseOrderDetailColumn.OrderQty - 1)];
			entity.ProductId = (System.Int32)reader[((int)PurchaseOrderDetailColumn.ProductId - 1)];
			entity.UnitPrice = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.UnitPrice - 1)];
			entity.LineTotal = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.LineTotal - 1)];
			entity.ReceivedQty = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.ReceivedQty - 1)];
			entity.RejectedQty = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.RejectedQty - 1)];
			entity.StockedQty = (System.Decimal)reader[((int)PurchaseOrderDetailColumn.StockedQty - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)PurchaseOrderDetailColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.PurchaseOrderDetail entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PurchaseOrderId = (System.Int32)dataRow["PurchaseOrderID"];
			entity.OriginalPurchaseOrderId = (System.Int32)dataRow["PurchaseOrderID"];
			entity.PurchaseOrderDetailId = (System.Int32)dataRow["PurchaseOrderDetailID"];
			entity.DueDate = (System.DateTime)dataRow["DueDate"];
			entity.OrderQty = (System.Int16)dataRow["OrderQty"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.UnitPrice = (System.Decimal)dataRow["UnitPrice"];
			entity.LineTotal = (System.Decimal)dataRow["LineTotal"];
			entity.ReceivedQty = (System.Decimal)dataRow["ReceivedQty"];
			entity.RejectedQty = (System.Decimal)dataRow["RejectedQty"];
			entity.StockedQty = (System.Decimal)dataRow["StockedQty"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderDetail"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.PurchaseOrderDetail Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.PurchaseOrderDetail entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region PurchaseOrderIdSource	
			if (CanDeepLoad(entity, "PurchaseOrderHeader|PurchaseOrderIdSource", deepLoadType, innerList) 
				&& entity.PurchaseOrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.PurchaseOrderId;
				PurchaseOrderHeader tmpEntity = EntityManager.LocateEntity<PurchaseOrderHeader>(EntityLocator.ConstructKeyFromPkItems(typeof(PurchaseOrderHeader), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PurchaseOrderIdSource = tmpEntity;
				else
					entity.PurchaseOrderIdSource = DataRepository.PurchaseOrderHeaderProvider.GetByPurchaseOrderId(transactionManager, entity.PurchaseOrderId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PurchaseOrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PurchaseOrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PurchaseOrderHeaderProvider.DeepLoad(transactionManager, entity.PurchaseOrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PurchaseOrderIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.PurchaseOrderDetail object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.PurchaseOrderDetail instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.PurchaseOrderDetail Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.PurchaseOrderDetail entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region PurchaseOrderIdSource
			if (CanDeepSave(entity, "PurchaseOrderHeader|PurchaseOrderIdSource", deepSaveType, innerList) 
				&& entity.PurchaseOrderIdSource != null)
			{
				DataRepository.PurchaseOrderHeaderProvider.Save(transactionManager, entity.PurchaseOrderIdSource);
				entity.PurchaseOrderId = entity.PurchaseOrderIdSource.PurchaseOrderId;
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
	
	#region PurchaseOrderDetailChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.PurchaseOrderDetail</c>
	///</summary>
	public enum PurchaseOrderDetailChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>PurchaseOrderHeader</c> at PurchaseOrderIdSource
		///</summary>
		[ChildEntityType(typeof(PurchaseOrderHeader))]
		PurchaseOrderHeader,
		}
	
	#endregion PurchaseOrderDetailChildEntityTypes
	
	#region PurchaseOrderDetailFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PurchaseOrderDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderDetailFilterBuilder : SqlFilterBuilder<PurchaseOrderDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailFilterBuilder class.
		/// </summary>
		public PurchaseOrderDetailFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PurchaseOrderDetailFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PurchaseOrderDetailFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PurchaseOrderDetailFilterBuilder
	
	#region PurchaseOrderDetailParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PurchaseOrderDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderDetailParameterBuilder : ParameterizedSqlFilterBuilder<PurchaseOrderDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailParameterBuilder class.
		/// </summary>
		public PurchaseOrderDetailParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PurchaseOrderDetailParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PurchaseOrderDetailParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PurchaseOrderDetailParameterBuilder
	
	#region PurchaseOrderDetailSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;PurchaseOrderDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderDetail"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class PurchaseOrderDetailSortBuilder : SqlSortBuilder<PurchaseOrderDetailColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailSqlSortBuilder class.
		/// </summary>
		public PurchaseOrderDetailSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion PurchaseOrderDetailSortBuilder
	
} // end namespace
