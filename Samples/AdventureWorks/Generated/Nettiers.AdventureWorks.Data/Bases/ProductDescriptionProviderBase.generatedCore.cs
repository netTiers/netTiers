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
	/// This class is the base class for any <see cref="ProductDescriptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductDescriptionProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductDescription, Nettiers.AdventureWorks.Entities.ProductDescriptionKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByCultureIdFromProductModelProductDescriptionCulture
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByCultureIdFromProductModelProductDescriptionCulture(System.String _cultureId)
		{
			int count = -1;
			return GetByCultureIdFromProductModelProductDescriptionCulture(null,_cultureId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.ProductDescription objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByCultureIdFromProductModelProductDescriptionCulture(System.String _cultureId, int start, int pageLength)
		{
			int count = -1;
			return GetByCultureIdFromProductModelProductDescriptionCulture(null, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByCultureIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.String _cultureId)
		{
			int count = -1;
			return GetByCultureIdFromProductModelProductDescriptionCulture(transactionManager, _cultureId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByCultureIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.String _cultureId,int start, int pageLength)
		{
			int count = -1;
			return GetByCultureIdFromProductModelProductDescriptionCulture(transactionManager, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByCultureIdFromProductModelProductDescriptionCulture(System.String _cultureId,int start, int pageLength, out int count)
		{
			
			return GetByCultureIdFromProductModelProductDescriptionCulture(null, _cultureId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ProductDescription objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductDescription objects.</returns>
		public abstract TList<ProductDescription> GetByCultureIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager,System.String _cultureId, int start, int pageLength, out int count);
		
		#endregion GetByCultureIdFromProductModelProductDescriptionCulture
		
		#region GetByProductModelIdFromProductModelProductDescriptionCulture
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByProductModelIdFromProductModelProductDescriptionCulture(System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelProductDescriptionCulture(null,_productModelId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.ProductDescription objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByProductModelIdFromProductModelProductDescriptionCulture(System.Int32 _productModelId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelProductDescriptionCulture(null, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByProductModelIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelProductDescriptionCulture(transactionManager, _productModelId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByProductModelIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productModelId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelProductDescriptionCulture(transactionManager, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public TList<ProductDescription> GetByProductModelIdFromProductModelProductDescriptionCulture(System.Int32 _productModelId,int start, int pageLength, out int count)
		{
			
			return GetByProductModelIdFromProductModelProductDescriptionCulture(null, _productModelId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ProductDescription objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductDescription objects.</returns>
		public abstract TList<ProductDescription> GetByProductModelIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager,System.Int32 _productModelId, int start, int pageLength, out int count);
		
		#endregion GetByProductModelIdFromProductModelProductDescriptionCulture
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDescriptionKey key)
		{
			return Delete(transactionManager, key.ProductDescriptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productDescriptionId)
		{
			return Delete(null, _productDescriptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productDescriptionId);		
		
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
		public override Nettiers.AdventureWorks.Entities.ProductDescription Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDescriptionKey key, int start, int pageLength)
		{
			return GetByProductDescriptionId(transactionManager, key.ProductDescriptionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ProductDescription_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductDescription_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductDescription_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductDescription_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductDescription_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductDescription_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductDescription GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductDescription_ProductDescriptionID index.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByProductDescriptionId(System.Int32 _productDescriptionId)
		{
			int count = -1;
			return GetByProductDescriptionId(null,_productDescriptionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDescription_ProductDescriptionID index.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByProductDescriptionId(System.Int32 _productDescriptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductDescriptionId(null, _productDescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDescription_ProductDescriptionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByProductDescriptionId(TransactionManager transactionManager, System.Int32 _productDescriptionId)
		{
			int count = -1;
			return GetByProductDescriptionId(transactionManager, _productDescriptionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDescription_ProductDescriptionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByProductDescriptionId(TransactionManager transactionManager, System.Int32 _productDescriptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductDescriptionId(transactionManager, _productDescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDescription_ProductDescriptionID index.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductDescription GetByProductDescriptionId(System.Int32 _productDescriptionId, int start, int pageLength, out int count)
		{
			return GetByProductDescriptionId(null, _productDescriptionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDescription_ProductDescriptionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductDescription GetByProductDescriptionId(TransactionManager transactionManager, System.Int32 _productDescriptionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductDescription&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductDescription&gt;"/></returns>
		public static TList<ProductDescription> Fill(IDataReader reader, TList<ProductDescription> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductDescription c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductDescription")
					.Append("|").Append((System.Int32)reader[((int)ProductDescriptionColumn.ProductDescriptionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductDescription>(
					key.ToString(), // EntityTrackingKey
					"ProductDescription",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductDescription();
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
					c.ProductDescriptionId = (System.Int32)reader[((int)ProductDescriptionColumn.ProductDescriptionId - 1)];
					c.Description = (System.String)reader[((int)ProductDescriptionColumn.Description - 1)];
					c.Rowguid = (System.Guid)reader[((int)ProductDescriptionColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ProductDescriptionColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductDescription entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductDescriptionId = (System.Int32)reader[((int)ProductDescriptionColumn.ProductDescriptionId - 1)];
			entity.Description = (System.String)reader[((int)ProductDescriptionColumn.Description - 1)];
			entity.Rowguid = (System.Guid)reader[((int)ProductDescriptionColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductDescriptionColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductDescription entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductDescriptionId = (System.Int32)dataRow["ProductDescriptionID"];
			entity.Description = (System.String)dataRow["Description"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductDescription Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDescription entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProductDescriptionId methods when available
			
			#region ProductModelProductDescriptionCultureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductModelProductDescriptionCulture>|ProductModelProductDescriptionCultureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelProductDescriptionCultureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductModelProductDescriptionCultureCollection = DataRepository.ProductModelProductDescriptionCultureProvider.GetByProductDescriptionId(transactionManager, entity.ProductDescriptionId);

				if (deep && entity.ProductModelProductDescriptionCultureCollection.Count > 0)
				{
					deepHandles.Add("ProductModelProductDescriptionCultureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductModelProductDescriptionCulture>) DataRepository.ProductModelProductDescriptionCultureProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductModelProductDescriptionCultureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<ProductModel>|ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture", deepLoadType, innerList))
			{
				entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture = DataRepository.ProductModelProvider.GetByProductDescriptionIdFromProductModelProductDescriptionCulture(transactionManager, entity.ProductDescriptionId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture != null)
				{
					deepHandles.Add("ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< ProductModel >) DataRepository.ProductModelProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region CultureIdCultureCollection_From_ProductModelProductDescriptionCulture
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Culture>|CultureIdCultureCollection_From_ProductModelProductDescriptionCulture", deepLoadType, innerList))
			{
				entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture = DataRepository.CultureProvider.GetByProductDescriptionIdFromProductModelProductDescriptionCulture(transactionManager, entity.ProductDescriptionId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CultureIdCultureCollection_From_ProductModelProductDescriptionCulture' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture != null)
				{
					deepHandles.Add("CultureIdCultureCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Culture >) DataRepository.CultureProvider.DeepLoad,
						new object[] { transactionManager, entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductDescription object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductDescription instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductDescription Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDescription entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture>
			if (CanDeepSave(entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture, "List<ProductModel>|ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture", deepSaveType, innerList))
			{
				if (entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture.Count > 0 || entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture.DeletedItems.Count > 0)
				{
					DataRepository.ProductModelProvider.Save(transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture); 
					deepHandles.Add("ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<ProductModel>) DataRepository.ProductModelProvider.DeepSave,
						new object[] { transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region CultureIdCultureCollection_From_ProductModelProductDescriptionCulture>
			if (CanDeepSave(entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture, "List<Culture>|CultureIdCultureCollection_From_ProductModelProductDescriptionCulture", deepSaveType, innerList))
			{
				if (entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture.Count > 0 || entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture.DeletedItems.Count > 0)
				{
					DataRepository.CultureProvider.Save(transactionManager, entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture); 
					deepHandles.Add("CultureIdCultureCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Culture>) DataRepository.CultureProvider.DeepSave,
						new object[] { transactionManager, entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<ProductModelProductDescriptionCulture>
				if (CanDeepSave(entity.ProductModelProductDescriptionCultureCollection, "List<ProductModelProductDescriptionCulture>|ProductModelProductDescriptionCultureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductModelProductDescriptionCulture child in entity.ProductModelProductDescriptionCultureCollection)
					{
						if(child.ProductDescriptionIdSource != null)
						{
								child.ProductDescriptionId = child.ProductDescriptionIdSource.ProductDescriptionId;
						}

						if(child.ProductModelIdSource != null)
						{
								child.ProductModelId = child.ProductModelIdSource.ProductModelId;
						}

						if(child.CultureIdSource != null)
						{
								child.CultureId = child.CultureIdSource.CultureId;
						}

					}

					if (entity.ProductModelProductDescriptionCultureCollection.Count > 0 || entity.ProductModelProductDescriptionCultureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductModelProductDescriptionCultureProvider.Save(transactionManager, entity.ProductModelProductDescriptionCultureCollection);
						
						deepHandles.Add("ProductModelProductDescriptionCultureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductModelProductDescriptionCulture >) DataRepository.ProductModelProductDescriptionCultureProvider.DeepSave,
							new object[] { transactionManager, entity.ProductModelProductDescriptionCultureCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProductDescriptionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductDescription</c>
	///</summary>
	public enum ProductDescriptionChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ProductDescription</c> as OneToMany for ProductModelProductDescriptionCultureCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductModelProductDescriptionCulture>))]
		ProductModelProductDescriptionCultureCollection,

		///<summary>
		/// Collection of <c>ProductDescription</c> as ManyToMany for ProductModelCollection_From_ProductModelProductDescriptionCulture
		///</summary>
		[ChildEntityType(typeof(TList<ProductModel>))]
		ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture,

		///<summary>
		/// Collection of <c>ProductDescription</c> as ManyToMany for CultureCollection_From_ProductModelProductDescriptionCulture
		///</summary>
		[ChildEntityType(typeof(TList<Culture>))]
		CultureIdCultureCollection_From_ProductModelProductDescriptionCulture,
	}
	
	#endregion ProductDescriptionChildEntityTypes
	
	#region ProductDescriptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductDescriptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDescriptionFilterBuilder : SqlFilterBuilder<ProductDescriptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionFilterBuilder class.
		/// </summary>
		public ProductDescriptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductDescriptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductDescriptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductDescriptionFilterBuilder
	
	#region ProductDescriptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductDescriptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDescriptionParameterBuilder : ParameterizedSqlFilterBuilder<ProductDescriptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionParameterBuilder class.
		/// </summary>
		public ProductDescriptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductDescriptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductDescriptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductDescriptionParameterBuilder
	
	#region ProductDescriptionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductDescriptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDescription"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductDescriptionSortBuilder : SqlSortBuilder<ProductDescriptionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionSqlSortBuilder class.
		/// </summary>
		public ProductDescriptionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductDescriptionSortBuilder
	
} // end namespace
