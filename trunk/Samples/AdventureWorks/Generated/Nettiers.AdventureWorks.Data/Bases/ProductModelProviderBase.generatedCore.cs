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
	/// This class is the base class for any <see cref="ProductModelProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductModelProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductModel, Nettiers.AdventureWorks.Entities.ProductModelKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByIllustrationIdFromProductModelIllustration
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by IllustrationID in the
		///		ProductModelIllustration table. Table ProductModel is related to table Illustration
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByIllustrationIdFromProductModelIllustration(System.Int32 _illustrationId)
		{
			int count = -1;
			return GetByIllustrationIdFromProductModelIllustration(null,_illustrationId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.ProductModel objects from the datasource by IllustrationID in the
		///		ProductModelIllustration table. Table ProductModel is related to table Illustration
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductModel objects.</returns>
		public TList<ProductModel> GetByIllustrationIdFromProductModelIllustration(System.Int32 _illustrationId, int start, int pageLength)
		{
			int count = -1;
			return GetByIllustrationIdFromProductModelIllustration(null, _illustrationId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by IllustrationID in the
		///		ProductModelIllustration table. Table ProductModel is related to table Illustration
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByIllustrationIdFromProductModelIllustration(TransactionManager transactionManager, System.Int32 _illustrationId)
		{
			int count = -1;
			return GetByIllustrationIdFromProductModelIllustration(transactionManager, _illustrationId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by IllustrationID in the
		///		ProductModelIllustration table. Table ProductModel is related to table Illustration
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByIllustrationIdFromProductModelIllustration(TransactionManager transactionManager, System.Int32 _illustrationId,int start, int pageLength)
		{
			int count = -1;
			return GetByIllustrationIdFromProductModelIllustration(transactionManager, _illustrationId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by IllustrationID in the
		///		ProductModelIllustration table. Table ProductModel is related to table Illustration
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByIllustrationIdFromProductModelIllustration(System.Int32 _illustrationId,int start, int pageLength, out int count)
		{
			
			return GetByIllustrationIdFromProductModelIllustration(null, _illustrationId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ProductModel objects from the datasource by IllustrationID in the
		///		ProductModelIllustration table. Table ProductModel is related to table Illustration
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductModel objects.</returns>
		public abstract TList<ProductModel> GetByIllustrationIdFromProductModelIllustration(TransactionManager transactionManager,System.Int32 _illustrationId, int start, int pageLength, out int count);
		
		#endregion GetByIllustrationIdFromProductModelIllustration
		
		#region GetByCultureIdFromProductModelProductDescriptionCulture
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByCultureIdFromProductModelProductDescriptionCulture(System.String _cultureId)
		{
			int count = -1;
			return GetByCultureIdFromProductModelProductDescriptionCulture(null,_cultureId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.ProductModel objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductModel objects.</returns>
		public TList<ProductModel> GetByCultureIdFromProductModelProductDescriptionCulture(System.String _cultureId, int start, int pageLength)
		{
			int count = -1;
			return GetByCultureIdFromProductModelProductDescriptionCulture(null, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByCultureIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.String _cultureId)
		{
			int count = -1;
			return GetByCultureIdFromProductModelProductDescriptionCulture(transactionManager, _cultureId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByCultureIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.String _cultureId,int start, int pageLength)
		{
			int count = -1;
			return GetByCultureIdFromProductModelProductDescriptionCulture(transactionManager, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByCultureIdFromProductModelProductDescriptionCulture(System.String _cultureId,int start, int pageLength, out int count)
		{
			
			return GetByCultureIdFromProductModelProductDescriptionCulture(null, _cultureId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ProductModel objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductModel objects.</returns>
		public abstract TList<ProductModel> GetByCultureIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager,System.String _cultureId, int start, int pageLength, out int count);
		
		#endregion GetByCultureIdFromProductModelProductDescriptionCulture
		
		#region GetByProductDescriptionIdFromProductModelProductDescriptionCulture
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(System.Int32 _productDescriptionId)
		{
			int count = -1;
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(null,_productDescriptionId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.ProductModel objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductModel objects.</returns>
		public TList<ProductModel> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(System.Int32 _productDescriptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(null, _productDescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productDescriptionId)
		{
			int count = -1;
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(transactionManager, _productDescriptionId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productDescriptionId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(transactionManager, _productDescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets ProductModel objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductModel objects.</returns>
		public TList<ProductModel> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(System.Int32 _productDescriptionId,int start, int pageLength, out int count)
		{
			
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(null, _productDescriptionId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ProductModel objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table ProductModel is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of ProductModel objects.</returns>
		public abstract TList<ProductModel> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager,System.Int32 _productDescriptionId, int start, int pageLength, out int count);
		
		#endregion GetByProductDescriptionIdFromProductModelProductDescriptionCulture
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelKey key)
		{
			return Delete(transactionManager, key.ProductModelId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productModelId">Primary key for ProductModel records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productModelId)
		{
			return Delete(null, _productModelId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key for ProductModel records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productModelId);		
		
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
		public override Nettiers.AdventureWorks.Entities.ProductModel Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelKey key, int start, int pageLength)
		{
			return GetByProductModelId(transactionManager, key.ProductModelId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ProductModel_Name index.
		/// </summary>
		/// <param name="_name">Product model description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_Name index.
		/// </summary>
		/// <param name="_name">Product model description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Product model description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Product model description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_Name index.
		/// </summary>
		/// <param name="_name">Product model description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Product model description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductModel GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_ProductModel_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductModel_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductModel GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductModel_ProductModelID index.
		/// </summary>
		/// <param name="_productModelId">Primary key for ProductModel records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByProductModelId(System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelId(null,_productModelId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModel_ProductModelID index.
		/// </summary>
		/// <param name="_productModelId">Primary key for ProductModel records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByProductModelId(System.Int32 _productModelId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelId(null, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModel_ProductModelID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key for ProductModel records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelId(transactionManager, _productModelId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModel_ProductModelID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key for ProductModel records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelId(transactionManager, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModel_ProductModelID index.
		/// </summary>
		/// <param name="_productModelId">Primary key for ProductModel records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModel GetByProductModelId(System.Int32 _productModelId, int start, int pageLength, out int count)
		{
			return GetByProductModelId(null, _productModelId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModel_ProductModelID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key for ProductModel records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductModel GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PXML_ProductModel_CatalogDescription index.
		/// </summary>
		/// <param name="_catalogDescription">Detailed product catalog information in xml format.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByCatalogDescription(string _catalogDescription)
		{
			int count = -1;
			return GetByCatalogDescription(null,_catalogDescription, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_CatalogDescription index.
		/// </summary>
		/// <param name="_catalogDescription">Detailed product catalog information in xml format.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByCatalogDescription(string _catalogDescription, int start, int pageLength)
		{
			int count = -1;
			return GetByCatalogDescription(null, _catalogDescription, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_CatalogDescription index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_catalogDescription">Detailed product catalog information in xml format.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByCatalogDescription(TransactionManager transactionManager, string _catalogDescription)
		{
			int count = -1;
			return GetByCatalogDescription(transactionManager, _catalogDescription, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_CatalogDescription index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_catalogDescription">Detailed product catalog information in xml format.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByCatalogDescription(TransactionManager transactionManager, string _catalogDescription, int start, int pageLength)
		{
			int count = -1;
			return GetByCatalogDescription(transactionManager, _catalogDescription, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_CatalogDescription index.
		/// </summary>
		/// <param name="_catalogDescription">Detailed product catalog information in xml format.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByCatalogDescription(string _catalogDescription, int start, int pageLength, out int count)
		{
			return GetByCatalogDescription(null, _catalogDescription, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_CatalogDescription index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_catalogDescription">Detailed product catalog information in xml format.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public abstract TList<ProductModel> GetByCatalogDescription(TransactionManager transactionManager, string _catalogDescription, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PXML_ProductModel_Instructions index.
		/// </summary>
		/// <param name="_instructions">Manufacturing instructions in xml format.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByInstructions(string _instructions)
		{
			int count = -1;
			return GetByInstructions(null,_instructions, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_Instructions index.
		/// </summary>
		/// <param name="_instructions">Manufacturing instructions in xml format.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByInstructions(string _instructions, int start, int pageLength)
		{
			int count = -1;
			return GetByInstructions(null, _instructions, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_Instructions index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_instructions">Manufacturing instructions in xml format.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByInstructions(TransactionManager transactionManager, string _instructions)
		{
			int count = -1;
			return GetByInstructions(transactionManager, _instructions, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_Instructions index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_instructions">Manufacturing instructions in xml format.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByInstructions(TransactionManager transactionManager, string _instructions, int start, int pageLength)
		{
			int count = -1;
			return GetByInstructions(transactionManager, _instructions, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_Instructions index.
		/// </summary>
		/// <param name="_instructions">Manufacturing instructions in xml format.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public TList<ProductModel> GetByInstructions(string _instructions, int start, int pageLength, out int count)
		{
			return GetByInstructions(null, _instructions, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_ProductModel_Instructions index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_instructions">Manufacturing instructions in xml format.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ProductModel&gt;"/> class.</returns>
		public abstract TList<ProductModel> GetByInstructions(TransactionManager transactionManager, string _instructions, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductModel&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductModel&gt;"/></returns>
		public static TList<ProductModel> Fill(IDataReader reader, TList<ProductModel> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductModel c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductModel")
					.Append("|").Append((System.Int32)reader[((int)ProductModelColumn.ProductModelId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductModel>(
					key.ToString(), // EntityTrackingKey
					"ProductModel",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductModel();
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
					c.ProductModelId = (System.Int32)reader[((int)ProductModelColumn.ProductModelId - 1)];
					c.Name = (System.String)reader[((int)ProductModelColumn.Name - 1)];
					c.CatalogDescription = (reader.IsDBNull(((int)ProductModelColumn.CatalogDescription - 1)))?null:(string)reader[((int)ProductModelColumn.CatalogDescription - 1)];
					c.Instructions = (reader.IsDBNull(((int)ProductModelColumn.Instructions - 1)))?null:(string)reader[((int)ProductModelColumn.Instructions - 1)];
					c.Rowguid = (System.Guid)reader[((int)ProductModelColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ProductModelColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductModel entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductModelId = (System.Int32)reader[((int)ProductModelColumn.ProductModelId - 1)];
			entity.Name = (System.String)reader[((int)ProductModelColumn.Name - 1)];
			entity.CatalogDescription = (reader.IsDBNull(((int)ProductModelColumn.CatalogDescription - 1)))?null:(string)reader[((int)ProductModelColumn.CatalogDescription - 1)];
			entity.Instructions = (reader.IsDBNull(((int)ProductModelColumn.Instructions - 1)))?null:(string)reader[((int)ProductModelColumn.Instructions - 1)];
			entity.Rowguid = (System.Guid)reader[((int)ProductModelColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductModelColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductModel entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductModelId = (System.Int32)dataRow["ProductModelID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.CatalogDescription = Convert.IsDBNull(dataRow["CatalogDescription"]) ? null : (string)dataRow["CatalogDescription"];
			entity.Instructions = Convert.IsDBNull(dataRow["Instructions"]) ? null : (string)dataRow["Instructions"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModel"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductModel Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModel entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProductModelId methods when available
			
			#region ProductModelProductDescriptionCultureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductModelProductDescriptionCulture>|ProductModelProductDescriptionCultureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelProductDescriptionCultureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductModelProductDescriptionCultureCollection = DataRepository.ProductModelProductDescriptionCultureProvider.GetByProductModelId(transactionManager, entity.ProductModelId);

				if (deep && entity.ProductModelProductDescriptionCultureCollection.Count > 0)
				{
					deepHandles.Add("ProductModelProductDescriptionCultureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductModelProductDescriptionCulture>) DataRepository.ProductModelProductDescriptionCultureProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductModelProductDescriptionCultureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CultureIdCultureCollection_From_ProductModelProductDescriptionCulture
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Culture>|CultureIdCultureCollection_From_ProductModelProductDescriptionCulture", deepLoadType, innerList))
			{
				entity.CultureIdCultureCollection_From_ProductModelProductDescriptionCulture = DataRepository.CultureProvider.GetByProductModelIdFromProductModelProductDescriptionCulture(transactionManager, entity.ProductModelId);			 
		
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
			
			
			
			#region ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<ProductDescription>|ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture", deepLoadType, innerList))
			{
				entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture = DataRepository.ProductDescriptionProvider.GetByProductModelIdFromProductModelProductDescriptionCulture(transactionManager, entity.ProductModelId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture != null)
				{
					deepHandles.Add("ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< ProductDescription >) DataRepository.ProductDescriptionProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region IllustrationIdIllustrationCollection_From_ProductModelIllustration
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Illustration>|IllustrationIdIllustrationCollection_From_ProductModelIllustration", deepLoadType, innerList))
			{
				entity.IllustrationIdIllustrationCollection_From_ProductModelIllustration = DataRepository.IllustrationProvider.GetByProductModelIdFromProductModelIllustration(transactionManager, entity.ProductModelId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IllustrationIdIllustrationCollection_From_ProductModelIllustration' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IllustrationIdIllustrationCollection_From_ProductModelIllustration != null)
				{
					deepHandles.Add("IllustrationIdIllustrationCollection_From_ProductModelIllustration",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Illustration >) DataRepository.IllustrationProvider.DeepLoad,
						new object[] { transactionManager, entity.IllustrationIdIllustrationCollection_From_ProductModelIllustration, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ProductModelIllustrationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductModelIllustration>|ProductModelIllustrationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelIllustrationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductModelIllustrationCollection = DataRepository.ProductModelIllustrationProvider.GetByProductModelId(transactionManager, entity.ProductModelId);

				if (deep && entity.ProductModelIllustrationCollection.Count > 0)
				{
					deepHandles.Add("ProductModelIllustrationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductModelIllustration>) DataRepository.ProductModelIllustrationProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductModelIllustrationCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>|ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductCollection = DataRepository.ProductProvider.GetByProductModelId(transactionManager, entity.ProductModelId);

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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductModel object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductModel instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductModel Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModel entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture>
			if (CanDeepSave(entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture, "List<ProductDescription>|ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture", deepSaveType, innerList))
			{
				if (entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture.Count > 0 || entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture.DeletedItems.Count > 0)
				{
					DataRepository.ProductDescriptionProvider.Save(transactionManager, entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture); 
					deepHandles.Add("ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<ProductDescription>) DataRepository.ProductDescriptionProvider.DeepSave,
						new object[] { transactionManager, entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region IllustrationIdIllustrationCollection_From_ProductModelIllustration>
			if (CanDeepSave(entity.IllustrationIdIllustrationCollection_From_ProductModelIllustration, "List<Illustration>|IllustrationIdIllustrationCollection_From_ProductModelIllustration", deepSaveType, innerList))
			{
				if (entity.IllustrationIdIllustrationCollection_From_ProductModelIllustration.Count > 0 || entity.IllustrationIdIllustrationCollection_From_ProductModelIllustration.DeletedItems.Count > 0)
				{
					DataRepository.IllustrationProvider.Save(transactionManager, entity.IllustrationIdIllustrationCollection_From_ProductModelIllustration); 
					deepHandles.Add("IllustrationIdIllustrationCollection_From_ProductModelIllustration",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Illustration>) DataRepository.IllustrationProvider.DeepSave,
						new object[] { transactionManager, entity.IllustrationIdIllustrationCollection_From_ProductModelIllustration, deepSaveType, childTypes, innerList }
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
						if(child.ProductModelIdSource != null)
						{
								child.ProductModelId = child.ProductModelIdSource.ProductModelId;
						}

						if(child.CultureIdSource != null)
						{
								child.CultureId = child.CultureIdSource.CultureId;
						}

						if(child.ProductDescriptionIdSource != null)
						{
								child.ProductDescriptionId = child.ProductDescriptionIdSource.ProductDescriptionId;
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
				
	
			#region List<ProductModelIllustration>
				if (CanDeepSave(entity.ProductModelIllustrationCollection, "List<ProductModelIllustration>|ProductModelIllustrationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductModelIllustration child in entity.ProductModelIllustrationCollection)
					{
						if(child.ProductModelIdSource != null)
						{
								child.ProductModelId = child.ProductModelIdSource.ProductModelId;
						}

						if(child.IllustrationIdSource != null)
						{
								child.IllustrationId = child.IllustrationIdSource.IllustrationId;
						}

					}

					if (entity.ProductModelIllustrationCollection.Count > 0 || entity.ProductModelIllustrationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductModelIllustrationProvider.Save(transactionManager, entity.ProductModelIllustrationCollection);
						
						deepHandles.Add("ProductModelIllustrationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductModelIllustration >) DataRepository.ProductModelIllustrationProvider.DeepSave,
							new object[] { transactionManager, entity.ProductModelIllustrationCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Product>
				if (CanDeepSave(entity.ProductCollection, "List<Product>|ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollection)
					{
						if(child.ProductModelIdSource != null)
						{
							child.ProductModelId = child.ProductModelIdSource.ProductModelId;
						}
						else
						{
							child.ProductModelId = entity.ProductModelId;
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
	
	#region ProductModelChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductModel</c>
	///</summary>
	public enum ProductModelChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ProductModel</c> as OneToMany for ProductModelProductDescriptionCultureCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductModelProductDescriptionCulture>))]
		ProductModelProductDescriptionCultureCollection,

		///<summary>
		/// Collection of <c>ProductModel</c> as ManyToMany for CultureCollection_From_ProductModelProductDescriptionCulture
		///</summary>
		[ChildEntityType(typeof(TList<Culture>))]
		CultureIdCultureCollection_From_ProductModelProductDescriptionCulture,

		///<summary>
		/// Collection of <c>ProductModel</c> as ManyToMany for ProductDescriptionCollection_From_ProductModelProductDescriptionCulture
		///</summary>
		[ChildEntityType(typeof(TList<ProductDescription>))]
		ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture,

		///<summary>
		/// Collection of <c>ProductModel</c> as ManyToMany for IllustrationCollection_From_ProductModelIllustration
		///</summary>
		[ChildEntityType(typeof(TList<Illustration>))]
		IllustrationIdIllustrationCollection_From_ProductModelIllustration,

		///<summary>
		/// Collection of <c>ProductModel</c> as OneToMany for ProductModelIllustrationCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductModelIllustration>))]
		ProductModelIllustrationCollection,

		///<summary>
		/// Collection of <c>ProductModel</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollection,
	}
	
	#endregion ProductModelChildEntityTypes
	
	#region ProductModelFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductModelColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelFilterBuilder : SqlFilterBuilder<ProductModelColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelFilterBuilder class.
		/// </summary>
		public ProductModelFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelFilterBuilder
	
	#region ProductModelParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductModelColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelParameterBuilder : ParameterizedSqlFilterBuilder<ProductModelColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelParameterBuilder class.
		/// </summary>
		public ProductModelParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelParameterBuilder
	
	#region ProductModelSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductModelColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModel"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductModelSortBuilder : SqlSortBuilder<ProductModelColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelSqlSortBuilder class.
		/// </summary>
		public ProductModelSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductModelSortBuilder
	
} // end namespace
