#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;
using Nettiers.AdventureWorks.Services;
#endregion

namespace Nettiers.AdventureWorks.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.ProductProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductDataSourceDesigner))]
	public class ProductDataSource : ProviderDataSource<Product, ProductKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDataSource class.
		/// </summary>
		public ProductDataSource() : base(new ProductService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductDataSourceView used by the ProductDataSource.
		/// </summary>
		protected ProductDataSourceView ProductView
		{
			get { return ( View as ProductDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductDataSource control invokes to retrieve data.
		/// </summary>
		public ProductSelectMethod SelectMethod
		{
			get
			{
				ProductSelectMethod selectMethod = ProductSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductDataSourceView class that is to be
		/// used by the ProductDataSource.
		/// </summary>
		/// <returns>An instance of the ProductDataSourceView class.</returns>
		protected override BaseDataSourceView<Product, ProductKey> GetNewDataSourceView()
		{
			return new ProductDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the ProductDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductDataSourceView : ProviderDataSourceView<Product, ProductKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductDataSourceView(ProductDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductDataSource ProductOwner
		{
			get { return Owner as ProductDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductSelectMethod SelectMethod
		{
			get { return ProductOwner.SelectMethod; }
			set { ProductOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductService ProductProvider
		{
			get { return Provider as ProductService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Product> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Product> results = null;
			Product item;
			count = 0;
			
			System.String _name;
			System.String _productNumber;
			System.Guid _rowguid;
			System.Int32 _productId;
			System.Int32? _productModelId_nullable;
			System.Int32? _productSubcategoryId_nullable;
			System.String _sizeUnitMeasureCode_nullable;
			System.String _weightUnitMeasureCode_nullable;
			System.Int32 _documentId;
			System.Int16 _locationId;
			System.Int32 _productPhotoId;
			System.Int32 _vendorId;
			System.Int32 _specialOfferId;

			switch ( SelectMethod )
			{
				case ProductSelectMethod.Get:
					ProductKey entityKey  = new ProductKey();
					entityKey.Load(values);
					item = ProductProvider.Get(entityKey);
					results = new TList<Product>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductSelectMethod.GetAll:
                    results = ProductProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductSelectMethod.GetPaged:
					results = ProductProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					item = ProductProvider.GetByProductId(_productId);
					results = new TList<Product>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ProductProvider.GetByName(_name);
					results = new TList<Product>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductSelectMethod.GetByProductNumber:
					_productNumber = ( values["ProductNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["ProductNumber"], typeof(System.String)) : string.Empty;
					item = ProductProvider.GetByProductNumber(_productNumber);
					results = new TList<Product>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = ProductProvider.GetByRowguid(_rowguid);
					results = new TList<Product>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case ProductSelectMethod.GetByProductModelId:
					_productModelId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32?));
					results = ProductProvider.GetByProductModelId(_productModelId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProductSelectMethod.GetByProductSubcategoryId:
					_productSubcategoryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ProductSubcategoryId"], typeof(System.Int32?));
					results = ProductProvider.GetByProductSubcategoryId(_productSubcategoryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProductSelectMethod.GetBySizeUnitMeasureCode:
					_sizeUnitMeasureCode_nullable = (System.String) EntityUtil.ChangeType(values["SizeUnitMeasureCode"], typeof(System.String));
					results = ProductProvider.GetBySizeUnitMeasureCode(_sizeUnitMeasureCode_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProductSelectMethod.GetByWeightUnitMeasureCode:
					_weightUnitMeasureCode_nullable = (System.String) EntityUtil.ChangeType(values["WeightUnitMeasureCode"], typeof(System.String));
					results = ProductProvider.GetByWeightUnitMeasureCode(_weightUnitMeasureCode_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case ProductSelectMethod.GetByDocumentIdFromProductDocument:
					_documentId = ( values["DocumentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DocumentId"], typeof(System.Int32)) : (int)0;
					results = ProductProvider.GetByDocumentIdFromProductDocument(_documentId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductSelectMethod.GetByLocationIdFromProductInventory:
					_locationId = ( values["LocationId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["LocationId"], typeof(System.Int16)) : (short)0;
					results = ProductProvider.GetByLocationIdFromProductInventory(_locationId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductSelectMethod.GetByProductPhotoIdFromProductProductPhoto:
					_productPhotoId = ( values["ProductPhotoId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductPhotoId"], typeof(System.Int32)) : (int)0;
					results = ProductProvider.GetByProductPhotoIdFromProductProductPhoto(_productPhotoId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductSelectMethod.GetByVendorIdFromProductVendor:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					results = ProductProvider.GetByVendorIdFromProductVendor(_vendorId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductSelectMethod.GetBySpecialOfferIdFromSpecialOfferProduct:
					_specialOfferId = ( values["SpecialOfferId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SpecialOfferId"], typeof(System.Int32)) : (int)0;
					results = ProductProvider.GetBySpecialOfferIdFromSpecialOfferProduct(_specialOfferId, this.StartIndex, this.PageSize, out count);
					break;
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == ProductSelectMethod.Get || SelectMethod == ProductSelectMethod.GetByProductId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Product entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<Product> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductDataSource class.
	/// </summary>
	public class ProductDataSourceDesigner : ProviderDataSourceDesigner<Product, ProductKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductDataSourceDesigner class.
		/// </summary>
		public ProductDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductSelectMethod SelectMethod
		{
			get { return ((ProductDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new ProductDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductDataSourceActionList

	/// <summary>
	/// Supports the ProductDataSourceDesigner class.
	/// </summary>
	internal class ProductDataSourceActionList : DesignerActionList
	{
		private ProductDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductDataSourceActionList(ProductDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion ProductDataSourceActionList
	
	#endregion ProductDataSourceDesigner
	
	#region ProductSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductDataSource.SelectMethod property.
	/// </summary>
	public enum ProductSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByName method.
		/// </summary>
		GetByName,
		/// <summary>
		/// Represents the GetByProductNumber method.
		/// </summary>
		GetByProductNumber,
		/// <summary>
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId,
		/// <summary>
		/// Represents the GetByProductModelId method.
		/// </summary>
		GetByProductModelId,
		/// <summary>
		/// Represents the GetByProductSubcategoryId method.
		/// </summary>
		GetByProductSubcategoryId,
		/// <summary>
		/// Represents the GetBySizeUnitMeasureCode method.
		/// </summary>
		GetBySizeUnitMeasureCode,
		/// <summary>
		/// Represents the GetByWeightUnitMeasureCode method.
		/// </summary>
		GetByWeightUnitMeasureCode,
		/// <summary>
		/// Represents the GetByDocumentIdFromProductDocument method.
		/// </summary>
		GetByDocumentIdFromProductDocument,
		/// <summary>
		/// Represents the GetByLocationIdFromProductInventory method.
		/// </summary>
		GetByLocationIdFromProductInventory,
		/// <summary>
		/// Represents the GetByProductPhotoIdFromProductProductPhoto method.
		/// </summary>
		GetByProductPhotoIdFromProductProductPhoto,
		/// <summary>
		/// Represents the GetByVendorIdFromProductVendor method.
		/// </summary>
		GetByVendorIdFromProductVendor,
		/// <summary>
		/// Represents the GetBySpecialOfferIdFromSpecialOfferProduct method.
		/// </summary>
		GetBySpecialOfferIdFromSpecialOfferProduct
	}
	
	#endregion ProductSelectMethod

	#region ProductFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductFilter : SqlFilter<ProductColumn>
	{
	}
	
	#endregion ProductFilter

	#region ProductExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductExpressionBuilder : SqlExpressionBuilder<ProductColumn>
	{
	}
	
	#endregion ProductExpressionBuilder	

	#region ProductProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductProperty : ChildEntityProperty<ProductChildEntityTypes>
	{
	}
	
	#endregion ProductProperty
}

