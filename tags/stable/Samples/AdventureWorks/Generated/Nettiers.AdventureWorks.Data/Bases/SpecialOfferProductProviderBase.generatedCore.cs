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
	/// This class is the base class for any <see cref="SpecialOfferProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SpecialOfferProductProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SpecialOfferProduct, Nettiers.AdventureWorks.Entities.SpecialOfferProductKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SpecialOfferProductKey key)
		{
			return Delete(transactionManager, key.SpecialOfferId, key.ProductId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.. Primary Key.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _specialOfferId, System.Int32 _productId)
		{
			return Delete(null, _specialOfferId, _productId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.. Primary Key.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _specialOfferId, System.Int32 _productId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID key.
		///		FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID Description: Foreign key constraint referencing SpecialOffer.SpecialOfferID.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SpecialOfferProduct objects.</returns>
		public TList<SpecialOfferProduct> GetBySpecialOfferId(System.Int32 _specialOfferId)
		{
			int count = -1;
			return GetBySpecialOfferId(_specialOfferId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID key.
		///		FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID Description: Foreign key constraint referencing SpecialOffer.SpecialOfferID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SpecialOfferProduct objects.</returns>
		/// <remarks></remarks>
		public TList<SpecialOfferProduct> GetBySpecialOfferId(TransactionManager transactionManager, System.Int32 _specialOfferId)
		{
			int count = -1;
			return GetBySpecialOfferId(transactionManager, _specialOfferId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID key.
		///		FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID Description: Foreign key constraint referencing SpecialOffer.SpecialOfferID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SpecialOfferProduct objects.</returns>
		public TList<SpecialOfferProduct> GetBySpecialOfferId(TransactionManager transactionManager, System.Int32 _specialOfferId, int start, int pageLength)
		{
			int count = -1;
			return GetBySpecialOfferId(transactionManager, _specialOfferId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID key.
		///		fkSpecialOfferProductSpecialOfferSpecialOfferId Description: Foreign key constraint referencing SpecialOffer.SpecialOfferID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SpecialOfferProduct objects.</returns>
		public TList<SpecialOfferProduct> GetBySpecialOfferId(System.Int32 _specialOfferId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySpecialOfferId(null, _specialOfferId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID key.
		///		fkSpecialOfferProductSpecialOfferSpecialOfferId Description: Foreign key constraint referencing SpecialOffer.SpecialOfferID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SpecialOfferProduct objects.</returns>
		public TList<SpecialOfferProduct> GetBySpecialOfferId(System.Int32 _specialOfferId, int start, int pageLength,out int count)
		{
			return GetBySpecialOfferId(null, _specialOfferId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID key.
		///		FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID Description: Foreign key constraint referencing SpecialOffer.SpecialOfferID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SpecialOfferProduct objects.</returns>
		public abstract TList<SpecialOfferProduct> GetBySpecialOfferId(TransactionManager transactionManager, System.Int32 _specialOfferId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.SpecialOfferProduct Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SpecialOfferProductKey key, int start, int pageLength)
		{
			return GetBySpecialOfferIdProductId(transactionManager, key.SpecialOfferId, key.ProductId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SpecialOfferProduct_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOfferProduct_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOfferProduct_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOfferProduct_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOfferProduct_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOfferProduct_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SpecialOfferProduct_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SpecialOfferProduct&gt;"/> class.</returns>
		public TList<SpecialOfferProduct> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SpecialOfferProduct_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SpecialOfferProduct&gt;"/> class.</returns>
		public TList<SpecialOfferProduct> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SpecialOfferProduct_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SpecialOfferProduct&gt;"/> class.</returns>
		public TList<SpecialOfferProduct> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SpecialOfferProduct_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SpecialOfferProduct&gt;"/> class.</returns>
		public TList<SpecialOfferProduct> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SpecialOfferProduct_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SpecialOfferProduct&gt;"/> class.</returns>
		public TList<SpecialOfferProduct> GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SpecialOfferProduct_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SpecialOfferProduct&gt;"/> class.</returns>
		public abstract TList<SpecialOfferProduct> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SpecialOfferProduct_SpecialOfferID_ProductID index.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetBySpecialOfferIdProductId(System.Int32 _specialOfferId, System.Int32 _productId)
		{
			int count = -1;
			return GetBySpecialOfferIdProductId(null,_specialOfferId, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOfferProduct_SpecialOfferID_ProductID index.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetBySpecialOfferIdProductId(System.Int32 _specialOfferId, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetBySpecialOfferIdProductId(null, _specialOfferId, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOfferProduct_SpecialOfferID_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetBySpecialOfferIdProductId(TransactionManager transactionManager, System.Int32 _specialOfferId, System.Int32 _productId)
		{
			int count = -1;
			return GetBySpecialOfferIdProductId(transactionManager, _specialOfferId, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOfferProduct_SpecialOfferID_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetBySpecialOfferIdProductId(TransactionManager transactionManager, System.Int32 _specialOfferId, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetBySpecialOfferIdProductId(transactionManager, _specialOfferId, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOfferProduct_SpecialOfferID_ProductID index.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetBySpecialOfferIdProductId(System.Int32 _specialOfferId, System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetBySpecialOfferIdProductId(null, _specialOfferId, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOfferProduct_SpecialOfferID_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOfferProduct records.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SpecialOfferProduct GetBySpecialOfferIdProductId(TransactionManager transactionManager, System.Int32 _specialOfferId, System.Int32 _productId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SpecialOfferProduct&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SpecialOfferProduct&gt;"/></returns>
		public static TList<SpecialOfferProduct> Fill(IDataReader reader, TList<SpecialOfferProduct> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SpecialOfferProduct c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SpecialOfferProduct")
					.Append("|").Append((System.Int32)reader[((int)SpecialOfferProductColumn.SpecialOfferId - 1)])
					.Append("|").Append((System.Int32)reader[((int)SpecialOfferProductColumn.ProductId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SpecialOfferProduct>(
					key.ToString(), // EntityTrackingKey
					"SpecialOfferProduct",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SpecialOfferProduct();
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
					c.SpecialOfferId = (System.Int32)reader[((int)SpecialOfferProductColumn.SpecialOfferId - 1)];
					c.OriginalSpecialOfferId = c.SpecialOfferId;
					c.ProductId = (System.Int32)reader[((int)SpecialOfferProductColumn.ProductId - 1)];
					c.OriginalProductId = c.ProductId;
					c.Rowguid = (System.Guid)reader[((int)SpecialOfferProductColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SpecialOfferProductColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SpecialOfferProduct entity)
		{
			if (!reader.Read()) return;
			
			entity.SpecialOfferId = (System.Int32)reader[((int)SpecialOfferProductColumn.SpecialOfferId - 1)];
			entity.OriginalSpecialOfferId = (System.Int32)reader["SpecialOfferID"];
			entity.ProductId = (System.Int32)reader[((int)SpecialOfferProductColumn.ProductId - 1)];
			entity.OriginalProductId = (System.Int32)reader["ProductID"];
			entity.Rowguid = (System.Guid)reader[((int)SpecialOfferProductColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SpecialOfferProductColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SpecialOfferProduct entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SpecialOfferId = (System.Int32)dataRow["SpecialOfferID"];
			entity.OriginalSpecialOfferId = (System.Int32)dataRow["SpecialOfferID"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OriginalProductId = (System.Int32)dataRow["ProductID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SpecialOfferProduct"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SpecialOfferProduct Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SpecialOfferProduct entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region SpecialOfferIdSource	
			if (CanDeepLoad(entity, "SpecialOffer|SpecialOfferIdSource", deepLoadType, innerList) 
				&& entity.SpecialOfferIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SpecialOfferId;
				SpecialOffer tmpEntity = EntityManager.LocateEntity<SpecialOffer>(EntityLocator.ConstructKeyFromPkItems(typeof(SpecialOffer), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SpecialOfferIdSource = tmpEntity;
				else
					entity.SpecialOfferIdSource = DataRepository.SpecialOfferProvider.GetBySpecialOfferId(transactionManager, entity.SpecialOfferId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SpecialOfferIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SpecialOfferIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SpecialOfferProvider.DeepLoad(transactionManager, entity.SpecialOfferIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SpecialOfferIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySpecialOfferIdProductId methods when available
			
			#region SalesOrderDetailCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderDetail>|SalesOrderDetailCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderDetailCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderDetailCollection = DataRepository.SalesOrderDetailProvider.GetBySpecialOfferIdProductId(transactionManager, entity.SpecialOfferId, entity.ProductId);

				if (deep && entity.SalesOrderDetailCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderDetailCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderDetail>) DataRepository.SalesOrderDetailProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderDetailCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SpecialOfferProduct object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SpecialOfferProduct instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SpecialOfferProduct Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SpecialOfferProduct entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region SpecialOfferIdSource
			if (CanDeepSave(entity, "SpecialOffer|SpecialOfferIdSource", deepSaveType, innerList) 
				&& entity.SpecialOfferIdSource != null)
			{
				DataRepository.SpecialOfferProvider.Save(transactionManager, entity.SpecialOfferIdSource);
				entity.SpecialOfferId = entity.SpecialOfferIdSource.SpecialOfferId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<SalesOrderDetail>
				if (CanDeepSave(entity.SalesOrderDetailCollection, "List<SalesOrderDetail>|SalesOrderDetailCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderDetail child in entity.SalesOrderDetailCollection)
					{
						if(child.SpecialOfferIdProductIdSource != null)
						{
							child.SpecialOfferId = child.SpecialOfferIdProductIdSource.SpecialOfferId;
							child.ProductId = child.SpecialOfferIdProductIdSource.ProductId;
						}
						else
						{
							child.SpecialOfferId = entity.SpecialOfferId;
							child.ProductId = entity.ProductId;
						}

					}

					if (entity.SalesOrderDetailCollection.Count > 0 || entity.SalesOrderDetailCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderDetailProvider.Save(transactionManager, entity.SalesOrderDetailCollection);
						
						deepHandles.Add("SalesOrderDetailCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderDetail >) DataRepository.SalesOrderDetailProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderDetailCollection, deepSaveType, childTypes, innerList }
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
	
	#region SpecialOfferProductChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SpecialOfferProduct</c>
	///</summary>
	public enum SpecialOfferProductChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>SpecialOffer</c> at SpecialOfferIdSource
		///</summary>
		[ChildEntityType(typeof(SpecialOffer))]
		SpecialOffer,
	
		///<summary>
		/// Collection of <c>SpecialOfferProduct</c> as OneToMany for SalesOrderDetailCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderDetail>))]
		SalesOrderDetailCollection,
	}
	
	#endregion SpecialOfferProductChildEntityTypes
	
	#region SpecialOfferProductFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SpecialOfferProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOfferProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferProductFilterBuilder : SqlFilterBuilder<SpecialOfferProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductFilterBuilder class.
		/// </summary>
		public SpecialOfferProductFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecialOfferProductFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecialOfferProductFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecialOfferProductFilterBuilder
	
	#region SpecialOfferProductParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SpecialOfferProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOfferProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferProductParameterBuilder : ParameterizedSqlFilterBuilder<SpecialOfferProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductParameterBuilder class.
		/// </summary>
		public SpecialOfferProductParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecialOfferProductParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecialOfferProductParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecialOfferProductParameterBuilder
	
	#region SpecialOfferProductSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SpecialOfferProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOfferProduct"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SpecialOfferProductSortBuilder : SqlSortBuilder<SpecialOfferProductColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductSqlSortBuilder class.
		/// </summary>
		public SpecialOfferProductSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SpecialOfferProductSortBuilder
	
} // end namespace
