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
	/// This class is the base class for any <see cref="ProductSubcategoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductSubcategoryProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductSubcategory, Nettiers.AdventureWorks.Entities.ProductSubcategoryKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductSubcategoryKey key)
		{
			return Delete(transactionManager, key.ProductSubcategoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productSubcategoryId">Primary key for ProductSubcategory records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productSubcategoryId)
		{
			return Delete(null, _productSubcategoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productSubcategoryId">Primary key for ProductSubcategory records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productSubcategoryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductSubcategory_ProductCategory_ProductCategoryID key.
		///		FK_ProductSubcategory_ProductCategory_ProductCategoryID Description: Foreign key constraint referencing ProductCategory.ProductCategoryID.
		/// </summary>
		/// <param name="_productCategoryId">Product category identification number. Foreign key to ProductCategory.ProductCategoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductSubcategory objects.</returns>
		public TList<ProductSubcategory> GetByProductCategoryId(System.Int32 _productCategoryId)
		{
			int count = -1;
			return GetByProductCategoryId(_productCategoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductSubcategory_ProductCategory_ProductCategoryID key.
		///		FK_ProductSubcategory_ProductCategory_ProductCategoryID Description: Foreign key constraint referencing ProductCategory.ProductCategoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productCategoryId">Product category identification number. Foreign key to ProductCategory.ProductCategoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductSubcategory objects.</returns>
		/// <remarks></remarks>
		public TList<ProductSubcategory> GetByProductCategoryId(TransactionManager transactionManager, System.Int32 _productCategoryId)
		{
			int count = -1;
			return GetByProductCategoryId(transactionManager, _productCategoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductSubcategory_ProductCategory_ProductCategoryID key.
		///		FK_ProductSubcategory_ProductCategory_ProductCategoryID Description: Foreign key constraint referencing ProductCategory.ProductCategoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productCategoryId">Product category identification number. Foreign key to ProductCategory.ProductCategoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductSubcategory objects.</returns>
		public TList<ProductSubcategory> GetByProductCategoryId(TransactionManager transactionManager, System.Int32 _productCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductCategoryId(transactionManager, _productCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductSubcategory_ProductCategory_ProductCategoryID key.
		///		fkProductSubcategoryProductCategoryProductCategoryId Description: Foreign key constraint referencing ProductCategory.ProductCategoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productCategoryId">Product category identification number. Foreign key to ProductCategory.ProductCategoryID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductSubcategory objects.</returns>
		public TList<ProductSubcategory> GetByProductCategoryId(System.Int32 _productCategoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductCategoryId(null, _productCategoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductSubcategory_ProductCategory_ProductCategoryID key.
		///		fkProductSubcategoryProductCategoryProductCategoryId Description: Foreign key constraint referencing ProductCategory.ProductCategoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productCategoryId">Product category identification number. Foreign key to ProductCategory.ProductCategoryID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductSubcategory objects.</returns>
		public TList<ProductSubcategory> GetByProductCategoryId(System.Int32 _productCategoryId, int start, int pageLength,out int count)
		{
			return GetByProductCategoryId(null, _productCategoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductSubcategory_ProductCategory_ProductCategoryID key.
		///		FK_ProductSubcategory_ProductCategory_ProductCategoryID Description: Foreign key constraint referencing ProductCategory.ProductCategoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productCategoryId">Product category identification number. Foreign key to ProductCategory.ProductCategoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductSubcategory objects.</returns>
		public abstract TList<ProductSubcategory> GetByProductCategoryId(TransactionManager transactionManager, System.Int32 _productCategoryId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.ProductSubcategory Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductSubcategoryKey key, int start, int pageLength)
		{
			return GetByProductSubcategoryId(transactionManager, key.ProductSubcategoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ProductSubcategory_Name index.
		/// </summary>
		/// <param name="_name">Subcategory description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_Name index.
		/// </summary>
		/// <param name="_name">Subcategory description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Subcategory description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Subcategory description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_Name index.
		/// </summary>
		/// <param name="_name">Subcategory description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Subcategory description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductSubcategory GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ProductSubcategory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductSubcategory_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductSubcategory GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductSubcategory_ProductSubcategoryID index.
		/// </summary>
		/// <param name="_productSubcategoryId">Primary key for ProductSubcategory records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByProductSubcategoryId(System.Int32 _productSubcategoryId)
		{
			int count = -1;
			return GetByProductSubcategoryId(null,_productSubcategoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductSubcategory_ProductSubcategoryID index.
		/// </summary>
		/// <param name="_productSubcategoryId">Primary key for ProductSubcategory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByProductSubcategoryId(System.Int32 _productSubcategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductSubcategoryId(null, _productSubcategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductSubcategory_ProductSubcategoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productSubcategoryId">Primary key for ProductSubcategory records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByProductSubcategoryId(TransactionManager transactionManager, System.Int32 _productSubcategoryId)
		{
			int count = -1;
			return GetByProductSubcategoryId(transactionManager, _productSubcategoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductSubcategory_ProductSubcategoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productSubcategoryId">Primary key for ProductSubcategory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByProductSubcategoryId(TransactionManager transactionManager, System.Int32 _productSubcategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductSubcategoryId(transactionManager, _productSubcategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductSubcategory_ProductSubcategoryID index.
		/// </summary>
		/// <param name="_productSubcategoryId">Primary key for ProductSubcategory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductSubcategory GetByProductSubcategoryId(System.Int32 _productSubcategoryId, int start, int pageLength, out int count)
		{
			return GetByProductSubcategoryId(null, _productSubcategoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductSubcategory_ProductSubcategoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productSubcategoryId">Primary key for ProductSubcategory records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductSubcategory GetByProductSubcategoryId(TransactionManager transactionManager, System.Int32 _productSubcategoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductSubcategory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductSubcategory&gt;"/></returns>
		public static TList<ProductSubcategory> Fill(IDataReader reader, TList<ProductSubcategory> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductSubcategory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductSubcategory")
					.Append("|").Append((System.Int32)reader[((int)ProductSubcategoryColumn.ProductSubcategoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductSubcategory>(
					key.ToString(), // EntityTrackingKey
					"ProductSubcategory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductSubcategory();
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
					c.ProductSubcategoryId = (System.Int32)reader[((int)ProductSubcategoryColumn.ProductSubcategoryId - 1)];
					c.ProductCategoryId = (System.Int32)reader[((int)ProductSubcategoryColumn.ProductCategoryId - 1)];
					c.Name = (System.String)reader[((int)ProductSubcategoryColumn.Name - 1)];
					c.Rowguid = (System.Guid)reader[((int)ProductSubcategoryColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ProductSubcategoryColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductSubcategory entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductSubcategoryId = (System.Int32)reader[((int)ProductSubcategoryColumn.ProductSubcategoryId - 1)];
			entity.ProductCategoryId = (System.Int32)reader[((int)ProductSubcategoryColumn.ProductCategoryId - 1)];
			entity.Name = (System.String)reader[((int)ProductSubcategoryColumn.Name - 1)];
			entity.Rowguid = (System.Guid)reader[((int)ProductSubcategoryColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductSubcategoryColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductSubcategory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductSubcategoryId = (System.Int32)dataRow["ProductSubcategoryID"];
			entity.ProductCategoryId = (System.Int32)dataRow["ProductCategoryID"];
			entity.Name = (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductSubcategory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductSubcategory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductSubcategory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ProductCategoryIdSource	
			if (CanDeepLoad(entity, "ProductCategory|ProductCategoryIdSource", deepLoadType, innerList) 
				&& entity.ProductCategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductCategoryId;
				ProductCategory tmpEntity = EntityManager.LocateEntity<ProductCategory>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductCategory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductCategoryIdSource = tmpEntity;
				else
					entity.ProductCategoryIdSource = DataRepository.ProductCategoryProvider.GetByProductCategoryId(transactionManager, entity.ProductCategoryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductCategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductCategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductCategoryProvider.DeepLoad(transactionManager, entity.ProductCategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductCategoryIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProductSubcategoryId methods when available
			
			#region ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>|ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductCollection = DataRepository.ProductProvider.GetByProductSubcategoryId(transactionManager, entity.ProductSubcategoryId);

				if (deep && entity.ProductCollection.Count > 0)
				{
					deepHandles.Add("ProductCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Product>) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductSubcategory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductSubcategory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductSubcategory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductSubcategory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductCategoryIdSource
			if (CanDeepSave(entity, "ProductCategory|ProductCategoryIdSource", deepSaveType, innerList) 
				&& entity.ProductCategoryIdSource != null)
			{
				DataRepository.ProductCategoryProvider.Save(transactionManager, entity.ProductCategoryIdSource);
				entity.ProductCategoryId = entity.ProductCategoryIdSource.ProductCategoryId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Product>
				if (CanDeepSave(entity.ProductCollection, "List<Product>|ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollection)
					{
						if(child.ProductSubcategoryIdSource != null)
						{
							child.ProductSubcategoryId = child.ProductSubcategoryIdSource.ProductSubcategoryId;
						}
						else
						{
							child.ProductSubcategoryId = entity.ProductSubcategoryId;
						}

					}

					if (entity.ProductCollection.Count > 0 || entity.ProductCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductProvider.Save(transactionManager, entity.ProductCollection);
						
						deepHandles.Add("ProductCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Product >) DataRepository.ProductProvider.DeepSave,
							new object[] { transactionManager, entity.ProductCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProductSubcategoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductSubcategory</c>
	///</summary>
	public enum ProductSubcategoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ProductCategory</c> at ProductCategoryIdSource
		///</summary>
		[ChildEntityType(typeof(ProductCategory))]
		ProductCategory,
	
		///<summary>
		/// Collection of <c>ProductSubcategory</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollection,
	}
	
	#endregion ProductSubcategoryChildEntityTypes
	
	#region ProductSubcategoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductSubcategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSubcategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSubcategoryFilterBuilder : SqlFilterBuilder<ProductSubcategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryFilterBuilder class.
		/// </summary>
		public ProductSubcategoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductSubcategoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductSubcategoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductSubcategoryFilterBuilder
	
	#region ProductSubcategoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductSubcategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSubcategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSubcategoryParameterBuilder : ParameterizedSqlFilterBuilder<ProductSubcategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryParameterBuilder class.
		/// </summary>
		public ProductSubcategoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductSubcategoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductSubcategoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductSubcategoryParameterBuilder
	
	#region ProductSubcategorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductSubcategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSubcategory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductSubcategorySortBuilder : SqlSortBuilder<ProductSubcategoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSubcategorySqlSortBuilder class.
		/// </summary>
		public ProductSubcategorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductSubcategorySortBuilder
	
} // end namespace
