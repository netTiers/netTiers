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
	/// This class is the base class for any <see cref="BillOfMaterialsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BillOfMaterialsProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.BillOfMaterials, Nettiers.AdventureWorks.Entities.BillOfMaterialsKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.BillOfMaterialsKey key)
		{
			return Delete(transactionManager, key.BillOfMaterialsId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_billOfMaterialsId">Primary key for BillOfMaterials records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _billOfMaterialsId)
		{
			return Delete(null, _billOfMaterialsId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billOfMaterialsId">Primary key for BillOfMaterials records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _billOfMaterialsId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ComponentID key.
		///		FK_BillOfMaterials_Product_ComponentID Description: Foreign key constraint referencing Product.ComponentID.
		/// </summary>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public TList<BillOfMaterials> GetByComponentId(System.Int32 _componentId)
		{
			int count = -1;
			return GetByComponentId(_componentId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ComponentID key.
		///		FK_BillOfMaterials_Product_ComponentID Description: Foreign key constraint referencing Product.ComponentID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		/// <remarks></remarks>
		public TList<BillOfMaterials> GetByComponentId(TransactionManager transactionManager, System.Int32 _componentId)
		{
			int count = -1;
			return GetByComponentId(transactionManager, _componentId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ComponentID key.
		///		FK_BillOfMaterials_Product_ComponentID Description: Foreign key constraint referencing Product.ComponentID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public TList<BillOfMaterials> GetByComponentId(TransactionManager transactionManager, System.Int32 _componentId, int start, int pageLength)
		{
			int count = -1;
			return GetByComponentId(transactionManager, _componentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ComponentID key.
		///		fkBillOfMaterialsProductComponentId Description: Foreign key constraint referencing Product.ComponentID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public TList<BillOfMaterials> GetByComponentId(System.Int32 _componentId, int start, int pageLength)
		{
			int count =  -1;
			return GetByComponentId(null, _componentId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ComponentID key.
		///		fkBillOfMaterialsProductComponentId Description: Foreign key constraint referencing Product.ComponentID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public TList<BillOfMaterials> GetByComponentId(System.Int32 _componentId, int start, int pageLength,out int count)
		{
			return GetByComponentId(null, _componentId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ComponentID key.
		///		FK_BillOfMaterials_Product_ComponentID Description: Foreign key constraint referencing Product.ComponentID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public abstract TList<BillOfMaterials> GetByComponentId(TransactionManager transactionManager, System.Int32 _componentId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ProductAssemblyID key.
		///		FK_BillOfMaterials_Product_ProductAssemblyID Description: Foreign key constraint referencing Product.ProductAssemblyID.
		/// </summary>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public TList<BillOfMaterials> GetByProductAssemblyId(System.Int32? _productAssemblyId)
		{
			int count = -1;
			return GetByProductAssemblyId(_productAssemblyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ProductAssemblyID key.
		///		FK_BillOfMaterials_Product_ProductAssemblyID Description: Foreign key constraint referencing Product.ProductAssemblyID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		/// <remarks></remarks>
		public TList<BillOfMaterials> GetByProductAssemblyId(TransactionManager transactionManager, System.Int32? _productAssemblyId)
		{
			int count = -1;
			return GetByProductAssemblyId(transactionManager, _productAssemblyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ProductAssemblyID key.
		///		FK_BillOfMaterials_Product_ProductAssemblyID Description: Foreign key constraint referencing Product.ProductAssemblyID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public TList<BillOfMaterials> GetByProductAssemblyId(TransactionManager transactionManager, System.Int32? _productAssemblyId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductAssemblyId(transactionManager, _productAssemblyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ProductAssemblyID key.
		///		fkBillOfMaterialsProductProductAssemblyId Description: Foreign key constraint referencing Product.ProductAssemblyID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public TList<BillOfMaterials> GetByProductAssemblyId(System.Int32? _productAssemblyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductAssemblyId(null, _productAssemblyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ProductAssemblyID key.
		///		fkBillOfMaterialsProductProductAssemblyId Description: Foreign key constraint referencing Product.ProductAssemblyID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public TList<BillOfMaterials> GetByProductAssemblyId(System.Int32? _productAssemblyId, int start, int pageLength,out int count)
		{
			return GetByProductAssemblyId(null, _productAssemblyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BillOfMaterials_Product_ProductAssemblyID key.
		///		FK_BillOfMaterials_Product_ProductAssemblyID Description: Foreign key constraint referencing Product.ProductAssemblyID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.BillOfMaterials objects.</returns>
		public abstract TList<BillOfMaterials> GetByProductAssemblyId(TransactionManager transactionManager, System.Int32? _productAssemblyId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.BillOfMaterials Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.BillOfMaterialsKey key, int start, int pageLength)
		{
			return GetByBillOfMaterialsId(transactionManager, key.BillOfMaterialsId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate index.
		/// </summary>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_startDate">Date the component started being used in the assembly item.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByProductAssemblyIdComponentIdStartDate(System.Int32? _productAssemblyId, System.Int32 _componentId, System.DateTime _startDate)
		{
			int count = -1;
			return GetByProductAssemblyIdComponentIdStartDate(null,_productAssemblyId, _componentId, _startDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate index.
		/// </summary>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_startDate">Date the component started being used in the assembly item.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByProductAssemblyIdComponentIdStartDate(System.Int32? _productAssemblyId, System.Int32 _componentId, System.DateTime _startDate, int start, int pageLength)
		{
			int count = -1;
			return GetByProductAssemblyIdComponentIdStartDate(null, _productAssemblyId, _componentId, _startDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_startDate">Date the component started being used in the assembly item.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByProductAssemblyIdComponentIdStartDate(TransactionManager transactionManager, System.Int32? _productAssemblyId, System.Int32 _componentId, System.DateTime _startDate)
		{
			int count = -1;
			return GetByProductAssemblyIdComponentIdStartDate(transactionManager, _productAssemblyId, _componentId, _startDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_startDate">Date the component started being used in the assembly item.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByProductAssemblyIdComponentIdStartDate(TransactionManager transactionManager, System.Int32? _productAssemblyId, System.Int32 _componentId, System.DateTime _startDate, int start, int pageLength)
		{
			int count = -1;
			return GetByProductAssemblyIdComponentIdStartDate(transactionManager, _productAssemblyId, _componentId, _startDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate index.
		/// </summary>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_startDate">Date the component started being used in the assembly item.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByProductAssemblyIdComponentIdStartDate(System.Int32? _productAssemblyId, System.Int32 _componentId, System.DateTime _startDate, int start, int pageLength, out int count)
		{
			return GetByProductAssemblyIdComponentIdStartDate(null, _productAssemblyId, _componentId, _startDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productAssemblyId">Parent product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_componentId">Component identification number. Foreign key to Product.ProductID.</param>
		/// <param name="_startDate">Date the component started being used in the assembly item.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.BillOfMaterials GetByProductAssemblyIdComponentIdStartDate(TransactionManager transactionManager, System.Int32? _productAssemblyId, System.Int32 _componentId, System.DateTime _startDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_BillOfMaterials_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">Standard code identifying the unit of measure for the quantity.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;BillOfMaterials&gt;"/> class.</returns>
		public TList<BillOfMaterials> GetByUnitMeasureCode(System.String _unitMeasureCode)
		{
			int count = -1;
			return GetByUnitMeasureCode(null,_unitMeasureCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BillOfMaterials_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">Standard code identifying the unit of measure for the quantity.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;BillOfMaterials&gt;"/> class.</returns>
		public TList<BillOfMaterials> GetByUnitMeasureCode(System.String _unitMeasureCode, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitMeasureCode(null, _unitMeasureCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BillOfMaterials_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">Standard code identifying the unit of measure for the quantity.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;BillOfMaterials&gt;"/> class.</returns>
		public TList<BillOfMaterials> GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode)
		{
			int count = -1;
			return GetByUnitMeasureCode(transactionManager, _unitMeasureCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BillOfMaterials_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">Standard code identifying the unit of measure for the quantity.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;BillOfMaterials&gt;"/> class.</returns>
		public TList<BillOfMaterials> GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitMeasureCode(transactionManager, _unitMeasureCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BillOfMaterials_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">Standard code identifying the unit of measure for the quantity.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;BillOfMaterials&gt;"/> class.</returns>
		public TList<BillOfMaterials> GetByUnitMeasureCode(System.String _unitMeasureCode, int start, int pageLength, out int count)
		{
			return GetByUnitMeasureCode(null, _unitMeasureCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BillOfMaterials_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">Standard code identifying the unit of measure for the quantity.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;BillOfMaterials&gt;"/> class.</returns>
		public abstract TList<BillOfMaterials> GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_BillOfMaterials_BillOfMaterialsID index.
		/// </summary>
		/// <param name="_billOfMaterialsId">Primary key for BillOfMaterials records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByBillOfMaterialsId(System.Int32 _billOfMaterialsId)
		{
			int count = -1;
			return GetByBillOfMaterialsId(null,_billOfMaterialsId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BillOfMaterials_BillOfMaterialsID index.
		/// </summary>
		/// <param name="_billOfMaterialsId">Primary key for BillOfMaterials records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByBillOfMaterialsId(System.Int32 _billOfMaterialsId, int start, int pageLength)
		{
			int count = -1;
			return GetByBillOfMaterialsId(null, _billOfMaterialsId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BillOfMaterials_BillOfMaterialsID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billOfMaterialsId">Primary key for BillOfMaterials records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByBillOfMaterialsId(TransactionManager transactionManager, System.Int32 _billOfMaterialsId)
		{
			int count = -1;
			return GetByBillOfMaterialsId(transactionManager, _billOfMaterialsId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BillOfMaterials_BillOfMaterialsID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billOfMaterialsId">Primary key for BillOfMaterials records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByBillOfMaterialsId(TransactionManager transactionManager, System.Int32 _billOfMaterialsId, int start, int pageLength)
		{
			int count = -1;
			return GetByBillOfMaterialsId(transactionManager, _billOfMaterialsId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BillOfMaterials_BillOfMaterialsID index.
		/// </summary>
		/// <param name="_billOfMaterialsId">Primary key for BillOfMaterials records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.BillOfMaterials GetByBillOfMaterialsId(System.Int32 _billOfMaterialsId, int start, int pageLength, out int count)
		{
			return GetByBillOfMaterialsId(null, _billOfMaterialsId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BillOfMaterials_BillOfMaterialsID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billOfMaterialsId">Primary key for BillOfMaterials records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.BillOfMaterials GetByBillOfMaterialsId(TransactionManager transactionManager, System.Int32 _billOfMaterialsId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;BillOfMaterials&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;BillOfMaterials&gt;"/></returns>
		public static TList<BillOfMaterials> Fill(IDataReader reader, TList<BillOfMaterials> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.BillOfMaterials c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("BillOfMaterials")
					.Append("|").Append((System.Int32)reader[((int)BillOfMaterialsColumn.BillOfMaterialsId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<BillOfMaterials>(
					key.ToString(), // EntityTrackingKey
					"BillOfMaterials",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.BillOfMaterials();
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
					c.BillOfMaterialsId = (System.Int32)reader[((int)BillOfMaterialsColumn.BillOfMaterialsId - 1)];
					c.ProductAssemblyId = (reader.IsDBNull(((int)BillOfMaterialsColumn.ProductAssemblyId - 1)))?null:(System.Int32?)reader[((int)BillOfMaterialsColumn.ProductAssemblyId - 1)];
					c.ComponentId = (System.Int32)reader[((int)BillOfMaterialsColumn.ComponentId - 1)];
					c.StartDate = (System.DateTime)reader[((int)BillOfMaterialsColumn.StartDate - 1)];
					c.EndDate = (reader.IsDBNull(((int)BillOfMaterialsColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)BillOfMaterialsColumn.EndDate - 1)];
					c.UnitMeasureCode = (System.String)reader[((int)BillOfMaterialsColumn.UnitMeasureCode - 1)];
					c.BomLevel = (System.Int16)reader[((int)BillOfMaterialsColumn.BomLevel - 1)];
					c.PerAssemblyQty = (System.Decimal)reader[((int)BillOfMaterialsColumn.PerAssemblyQty - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)BillOfMaterialsColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.BillOfMaterials entity)
		{
			if (!reader.Read()) return;
			
			entity.BillOfMaterialsId = (System.Int32)reader[((int)BillOfMaterialsColumn.BillOfMaterialsId - 1)];
			entity.ProductAssemblyId = (reader.IsDBNull(((int)BillOfMaterialsColumn.ProductAssemblyId - 1)))?null:(System.Int32?)reader[((int)BillOfMaterialsColumn.ProductAssemblyId - 1)];
			entity.ComponentId = (System.Int32)reader[((int)BillOfMaterialsColumn.ComponentId - 1)];
			entity.StartDate = (System.DateTime)reader[((int)BillOfMaterialsColumn.StartDate - 1)];
			entity.EndDate = (reader.IsDBNull(((int)BillOfMaterialsColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)BillOfMaterialsColumn.EndDate - 1)];
			entity.UnitMeasureCode = (System.String)reader[((int)BillOfMaterialsColumn.UnitMeasureCode - 1)];
			entity.BomLevel = (System.Int16)reader[((int)BillOfMaterialsColumn.BomLevel - 1)];
			entity.PerAssemblyQty = (System.Decimal)reader[((int)BillOfMaterialsColumn.PerAssemblyQty - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)BillOfMaterialsColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.BillOfMaterials entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.BillOfMaterialsId = (System.Int32)dataRow["BillOfMaterialsID"];
			entity.ProductAssemblyId = Convert.IsDBNull(dataRow["ProductAssemblyID"]) ? null : (System.Int32?)dataRow["ProductAssemblyID"];
			entity.ComponentId = (System.Int32)dataRow["ComponentID"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.EndDate = Convert.IsDBNull(dataRow["EndDate"]) ? null : (System.DateTime?)dataRow["EndDate"];
			entity.UnitMeasureCode = (System.String)dataRow["UnitMeasureCode"];
			entity.BomLevel = (System.Int16)dataRow["BOMLevel"];
			entity.PerAssemblyQty = (System.Decimal)dataRow["PerAssemblyQty"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.BillOfMaterials"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.BillOfMaterials Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.BillOfMaterials entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ComponentIdSource	
			if (CanDeepLoad(entity, "Product|ComponentIdSource", deepLoadType, innerList) 
				&& entity.ComponentIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ComponentId;
				Product tmpEntity = EntityManager.LocateEntity<Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ComponentIdSource = tmpEntity;
				else
					entity.ComponentIdSource = DataRepository.ProductProvider.GetByProductId(transactionManager, entity.ComponentId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ComponentIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ComponentIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ComponentIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ComponentIdSource

			#region ProductAssemblyIdSource	
			if (CanDeepLoad(entity, "Product|ProductAssemblyIdSource", deepLoadType, innerList) 
				&& entity.ProductAssemblyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ProductAssemblyId ?? (int)0);
				Product tmpEntity = EntityManager.LocateEntity<Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductAssemblyIdSource = tmpEntity;
				else
					entity.ProductAssemblyIdSource = DataRepository.ProductProvider.GetByProductId(transactionManager, (entity.ProductAssemblyId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductAssemblyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductAssemblyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductAssemblyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductAssemblyIdSource

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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.BillOfMaterials object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.BillOfMaterials instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.BillOfMaterials Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.BillOfMaterials entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ComponentIdSource
			if (CanDeepSave(entity, "Product|ComponentIdSource", deepSaveType, innerList) 
				&& entity.ComponentIdSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ComponentIdSource);
				entity.ComponentId = entity.ComponentIdSource.ProductId;
			}
			#endregion 
			
			#region ProductAssemblyIdSource
			if (CanDeepSave(entity, "Product|ProductAssemblyIdSource", deepSaveType, innerList) 
				&& entity.ProductAssemblyIdSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ProductAssemblyIdSource);
				entity.ProductAssemblyId = entity.ProductAssemblyIdSource.ProductId;
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
	
	#region BillOfMaterialsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.BillOfMaterials</c>
	///</summary>
	public enum BillOfMaterialsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ComponentIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>UnitMeasure</c> at UnitMeasureCodeSource
		///</summary>
		[ChildEntityType(typeof(UnitMeasure))]
		UnitMeasure,
		}
	
	#endregion BillOfMaterialsChildEntityTypes
	
	#region BillOfMaterialsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BillOfMaterialsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillOfMaterials"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillOfMaterialsFilterBuilder : SqlFilterBuilder<BillOfMaterialsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsFilterBuilder class.
		/// </summary>
		public BillOfMaterialsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BillOfMaterialsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BillOfMaterialsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BillOfMaterialsFilterBuilder
	
	#region BillOfMaterialsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BillOfMaterialsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillOfMaterials"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillOfMaterialsParameterBuilder : ParameterizedSqlFilterBuilder<BillOfMaterialsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsParameterBuilder class.
		/// </summary>
		public BillOfMaterialsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BillOfMaterialsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BillOfMaterialsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BillOfMaterialsParameterBuilder
	
	#region BillOfMaterialsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;BillOfMaterialsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillOfMaterials"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class BillOfMaterialsSortBuilder : SqlSortBuilder<BillOfMaterialsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsSqlSortBuilder class.
		/// </summary>
		public BillOfMaterialsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion BillOfMaterialsSortBuilder
	
} // end namespace
