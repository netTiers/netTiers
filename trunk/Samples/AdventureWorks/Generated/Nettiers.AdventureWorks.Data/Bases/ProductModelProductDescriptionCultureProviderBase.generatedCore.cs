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
	/// This class is the base class for any <see cref="ProductModelProductDescriptionCultureProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductModelProductDescriptionCultureProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture, Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCultureKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCultureKey key)
		{
			return Delete(transactionManager, key.ProductModelId, key.ProductDescriptionId, key.CultureId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.. Primary Key.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.. Primary Key.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productModelId, System.Int32 _productDescriptionId, System.String _cultureId)
		{
			return Delete(null, _productModelId, _productDescriptionId, _cultureId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.. Primary Key.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.. Primary Key.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productModelId, System.Int32 _productDescriptionId, System.String _cultureId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_Culture_CultureID key.
		///		FK_ProductModelProductDescriptionCulture_Culture_CultureID Description: Foreign key constraint referencing Culture.CultureID.
		/// </summary>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByCultureId(System.String _cultureId)
		{
			int count = -1;
			return GetByCultureId(_cultureId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_Culture_CultureID key.
		///		FK_ProductModelProductDescriptionCulture_Culture_CultureID Description: Foreign key constraint referencing Culture.CultureID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		/// <remarks></remarks>
		public TList<ProductModelProductDescriptionCulture> GetByCultureId(TransactionManager transactionManager, System.String _cultureId)
		{
			int count = -1;
			return GetByCultureId(transactionManager, _cultureId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_Culture_CultureID key.
		///		FK_ProductModelProductDescriptionCulture_Culture_CultureID Description: Foreign key constraint referencing Culture.CultureID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByCultureId(TransactionManager transactionManager, System.String _cultureId, int start, int pageLength)
		{
			int count = -1;
			return GetByCultureId(transactionManager, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_Culture_CultureID key.
		///		fkProductModelProductDescriptionCultureCultureCultureId Description: Foreign key constraint referencing Culture.CultureID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByCultureId(System.String _cultureId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCultureId(null, _cultureId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_Culture_CultureID key.
		///		fkProductModelProductDescriptionCultureCultureCultureId Description: Foreign key constraint referencing Culture.CultureID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByCultureId(System.String _cultureId, int start, int pageLength,out int count)
		{
			return GetByCultureId(null, _cultureId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_Culture_CultureID key.
		///		FK_ProductModelProductDescriptionCulture_Culture_CultureID Description: Foreign key constraint referencing Culture.CultureID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public abstract TList<ProductModelProductDescriptionCulture> GetByCultureId(TransactionManager transactionManager, System.String _cultureId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID key.
		///		FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID Description: Foreign key constraint referencing ProductDescription.ProductDescriptionID.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByProductDescriptionId(System.Int32 _productDescriptionId)
		{
			int count = -1;
			return GetByProductDescriptionId(_productDescriptionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID key.
		///		FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID Description: Foreign key constraint referencing ProductDescription.ProductDescriptionID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		/// <remarks></remarks>
		public TList<ProductModelProductDescriptionCulture> GetByProductDescriptionId(TransactionManager transactionManager, System.Int32 _productDescriptionId)
		{
			int count = -1;
			return GetByProductDescriptionId(transactionManager, _productDescriptionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID key.
		///		FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID Description: Foreign key constraint referencing ProductDescription.ProductDescriptionID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByProductDescriptionId(TransactionManager transactionManager, System.Int32 _productDescriptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductDescriptionId(transactionManager, _productDescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID key.
		///		fkProductModelProductDescriptionCultureProductDescriptionProductDescriptionId Description: Foreign key constraint referencing ProductDescription.ProductDescriptionID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByProductDescriptionId(System.Int32 _productDescriptionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductDescriptionId(null, _productDescriptionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID key.
		///		fkProductModelProductDescriptionCultureProductDescriptionProductDescriptionId Description: Foreign key constraint referencing ProductDescription.ProductDescriptionID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByProductDescriptionId(System.Int32 _productDescriptionId, int start, int pageLength,out int count)
		{
			return GetByProductDescriptionId(null, _productDescriptionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID key.
		///		FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID Description: Foreign key constraint referencing ProductDescription.ProductDescriptionID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public abstract TList<ProductModelProductDescriptionCulture> GetByProductDescriptionId(TransactionManager transactionManager, System.Int32 _productDescriptionId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID key.
		///		FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByProductModelId(System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelId(_productModelId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID key.
		///		FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		/// <remarks></remarks>
		public TList<ProductModelProductDescriptionCulture> GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelId(transactionManager, _productModelId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID key.
		///		FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelId(transactionManager, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID key.
		///		fkProductModelProductDescriptionCultureProductModelProductModelId Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByProductModelId(System.Int32 _productModelId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductModelId(null, _productModelId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID key.
		///		fkProductModelProductDescriptionCultureProductModelProductModelId Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public TList<ProductModelProductDescriptionCulture> GetByProductModelId(System.Int32 _productModelId, int start, int pageLength,out int count)
		{
			return GetByProductModelId(null, _productModelId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID key.
		///		FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture objects.</returns>
		public abstract TList<ProductModelProductDescriptionCulture> GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCultureKey key, int start, int pageLength)
		{
			return GetByProductModelIdProductDescriptionIdCultureId(transactionManager, key.ProductModelId, key.ProductDescriptionId, key.CultureId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID index.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture GetByProductModelIdProductDescriptionIdCultureId(System.Int32 _productModelId, System.Int32 _productDescriptionId, System.String _cultureId)
		{
			int count = -1;
			return GetByProductModelIdProductDescriptionIdCultureId(null,_productModelId, _productDescriptionId, _cultureId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID index.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture GetByProductModelIdProductDescriptionIdCultureId(System.Int32 _productModelId, System.Int32 _productDescriptionId, System.String _cultureId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdProductDescriptionIdCultureId(null, _productModelId, _productDescriptionId, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture GetByProductModelIdProductDescriptionIdCultureId(TransactionManager transactionManager, System.Int32 _productModelId, System.Int32 _productDescriptionId, System.String _cultureId)
		{
			int count = -1;
			return GetByProductModelIdProductDescriptionIdCultureId(transactionManager, _productModelId, _productDescriptionId, _cultureId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture GetByProductModelIdProductDescriptionIdCultureId(TransactionManager transactionManager, System.Int32 _productModelId, System.Int32 _productDescriptionId, System.String _cultureId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdProductDescriptionIdCultureId(transactionManager, _productModelId, _productDescriptionId, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID index.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture GetByProductModelIdProductDescriptionIdCultureId(System.Int32 _productModelId, System.Int32 _productDescriptionId, System.String _cultureId, int start, int pageLength, out int count)
		{
			return GetByProductModelIdProductDescriptionIdCultureId(null, _productModelId, _productDescriptionId, _cultureId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture GetByProductModelIdProductDescriptionIdCultureId(TransactionManager transactionManager, System.Int32 _productModelId, System.Int32 _productDescriptionId, System.String _cultureId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductModelProductDescriptionCulture&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductModelProductDescriptionCulture&gt;"/></returns>
		public static TList<ProductModelProductDescriptionCulture> Fill(IDataReader reader, TList<ProductModelProductDescriptionCulture> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductModelProductDescriptionCulture")
					.Append("|").Append((System.Int32)reader[((int)ProductModelProductDescriptionCultureColumn.ProductModelId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ProductModelProductDescriptionCultureColumn.ProductDescriptionId - 1)])
					.Append("|").Append((System.String)reader[((int)ProductModelProductDescriptionCultureColumn.CultureId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductModelProductDescriptionCulture>(
					key.ToString(), // EntityTrackingKey
					"ProductModelProductDescriptionCulture",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture();
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
					c.ProductModelId = (System.Int32)reader[((int)ProductModelProductDescriptionCultureColumn.ProductModelId - 1)];
					c.OriginalProductModelId = c.ProductModelId;
					c.ProductDescriptionId = (System.Int32)reader[((int)ProductModelProductDescriptionCultureColumn.ProductDescriptionId - 1)];
					c.OriginalProductDescriptionId = c.ProductDescriptionId;
					c.CultureId = (System.String)reader[((int)ProductModelProductDescriptionCultureColumn.CultureId - 1)];
					c.OriginalCultureId = c.CultureId;
					c.ModifiedDate = (System.DateTime)reader[((int)ProductModelProductDescriptionCultureColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductModelId = (System.Int32)reader[((int)ProductModelProductDescriptionCultureColumn.ProductModelId - 1)];
			entity.OriginalProductModelId = (System.Int32)reader["ProductModelID"];
			entity.ProductDescriptionId = (System.Int32)reader[((int)ProductModelProductDescriptionCultureColumn.ProductDescriptionId - 1)];
			entity.OriginalProductDescriptionId = (System.Int32)reader["ProductDescriptionID"];
			entity.CultureId = (System.String)reader[((int)ProductModelProductDescriptionCultureColumn.CultureId - 1)];
			entity.OriginalCultureId = (System.String)reader["CultureID"];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductModelProductDescriptionCultureColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductModelId = (System.Int32)dataRow["ProductModelID"];
			entity.OriginalProductModelId = (System.Int32)dataRow["ProductModelID"];
			entity.ProductDescriptionId = (System.Int32)dataRow["ProductDescriptionID"];
			entity.OriginalProductDescriptionId = (System.Int32)dataRow["ProductDescriptionID"];
			entity.CultureId = (System.String)dataRow["CultureID"];
			entity.OriginalCultureId = (System.String)dataRow["CultureID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CultureIdSource	
			if (CanDeepLoad(entity, "Culture|CultureIdSource", deepLoadType, innerList) 
				&& entity.CultureIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CultureId;
				Culture tmpEntity = EntityManager.LocateEntity<Culture>(EntityLocator.ConstructKeyFromPkItems(typeof(Culture), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CultureIdSource = tmpEntity;
				else
					entity.CultureIdSource = DataRepository.CultureProvider.GetByCultureId(transactionManager, entity.CultureId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CultureIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CultureIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CultureProvider.DeepLoad(transactionManager, entity.CultureIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CultureIdSource

			#region ProductDescriptionIdSource	
			if (CanDeepLoad(entity, "ProductDescription|ProductDescriptionIdSource", deepLoadType, innerList) 
				&& entity.ProductDescriptionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductDescriptionId;
				ProductDescription tmpEntity = EntityManager.LocateEntity<ProductDescription>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductDescription), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductDescriptionIdSource = tmpEntity;
				else
					entity.ProductDescriptionIdSource = DataRepository.ProductDescriptionProvider.GetByProductDescriptionId(transactionManager, entity.ProductDescriptionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductDescriptionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductDescriptionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductDescriptionProvider.DeepLoad(transactionManager, entity.ProductDescriptionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductDescriptionIdSource

			#region ProductModelIdSource	
			if (CanDeepLoad(entity, "ProductModel|ProductModelIdSource", deepLoadType, innerList) 
				&& entity.ProductModelIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductModelId;
				ProductModel tmpEntity = EntityManager.LocateEntity<ProductModel>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductModel), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductModelIdSource = tmpEntity;
				else
					entity.ProductModelIdSource = DataRepository.ProductModelProvider.GetByProductModelId(transactionManager, entity.ProductModelId);		
				
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CultureIdSource
			if (CanDeepSave(entity, "Culture|CultureIdSource", deepSaveType, innerList) 
				&& entity.CultureIdSource != null)
			{
				DataRepository.CultureProvider.Save(transactionManager, entity.CultureIdSource);
				entity.CultureId = entity.CultureIdSource.CultureId;
			}
			#endregion 
			
			#region ProductDescriptionIdSource
			if (CanDeepSave(entity, "ProductDescription|ProductDescriptionIdSource", deepSaveType, innerList) 
				&& entity.ProductDescriptionIdSource != null)
			{
				DataRepository.ProductDescriptionProvider.Save(transactionManager, entity.ProductDescriptionIdSource);
				entity.ProductDescriptionId = entity.ProductDescriptionIdSource.ProductDescriptionId;
			}
			#endregion 
			
			#region ProductModelIdSource
			if (CanDeepSave(entity, "ProductModel|ProductModelIdSource", deepSaveType, innerList) 
				&& entity.ProductModelIdSource != null)
			{
				DataRepository.ProductModelProvider.Save(transactionManager, entity.ProductModelIdSource);
				entity.ProductModelId = entity.ProductModelIdSource.ProductModelId;
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
	
	#region ProductModelProductDescriptionCultureChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductModelProductDescriptionCulture</c>
	///</summary>
	public enum ProductModelProductDescriptionCultureChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Culture</c> at CultureIdSource
		///</summary>
		[ChildEntityType(typeof(Culture))]
		Culture,
			
		///<summary>
		/// Composite Property for <c>ProductDescription</c> at ProductDescriptionIdSource
		///</summary>
		[ChildEntityType(typeof(ProductDescription))]
		ProductDescription,
			
		///<summary>
		/// Composite Property for <c>ProductModel</c> at ProductModelIdSource
		///</summary>
		[ChildEntityType(typeof(ProductModel))]
		ProductModel,
		}
	
	#endregion ProductModelProductDescriptionCultureChildEntityTypes
	
	#region ProductModelProductDescriptionCultureFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductModelProductDescriptionCultureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelProductDescriptionCulture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelProductDescriptionCultureFilterBuilder : SqlFilterBuilder<ProductModelProductDescriptionCultureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureFilterBuilder class.
		/// </summary>
		public ProductModelProductDescriptionCultureFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelProductDescriptionCultureFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelProductDescriptionCultureFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelProductDescriptionCultureFilterBuilder
	
	#region ProductModelProductDescriptionCultureParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductModelProductDescriptionCultureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelProductDescriptionCulture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelProductDescriptionCultureParameterBuilder : ParameterizedSqlFilterBuilder<ProductModelProductDescriptionCultureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureParameterBuilder class.
		/// </summary>
		public ProductModelProductDescriptionCultureParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelProductDescriptionCultureParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelProductDescriptionCultureParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelProductDescriptionCultureParameterBuilder
	
	#region ProductModelProductDescriptionCultureSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductModelProductDescriptionCultureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelProductDescriptionCulture"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductModelProductDescriptionCultureSortBuilder : SqlSortBuilder<ProductModelProductDescriptionCultureColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureSqlSortBuilder class.
		/// </summary>
		public ProductModelProductDescriptionCultureSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductModelProductDescriptionCultureSortBuilder
	
} // end namespace
