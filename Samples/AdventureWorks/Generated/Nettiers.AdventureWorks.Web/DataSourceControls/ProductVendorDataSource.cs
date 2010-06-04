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
	/// Represents the DataRepository.ProductVendorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductVendorDataSourceDesigner))]
	public class ProductVendorDataSource : ProviderDataSource<ProductVendor, ProductVendorKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductVendorDataSource class.
		/// </summary>
		public ProductVendorDataSource() : base(new ProductVendorService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductVendorDataSourceView used by the ProductVendorDataSource.
		/// </summary>
		protected ProductVendorDataSourceView ProductVendorView
		{
			get { return ( View as ProductVendorDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductVendorDataSource control invokes to retrieve data.
		/// </summary>
		public ProductVendorSelectMethod SelectMethod
		{
			get
			{
				ProductVendorSelectMethod selectMethod = ProductVendorSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductVendorSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductVendorDataSourceView class that is to be
		/// used by the ProductVendorDataSource.
		/// </summary>
		/// <returns>An instance of the ProductVendorDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductVendor, ProductVendorKey> GetNewDataSourceView()
		{
			return new ProductVendorDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductVendorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductVendorDataSourceView : ProviderDataSourceView<ProductVendor, ProductVendorKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductVendorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductVendorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductVendorDataSourceView(ProductVendorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductVendorDataSource ProductVendorOwner
		{
			get { return Owner as ProductVendorDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductVendorSelectMethod SelectMethod
		{
			get { return ProductVendorOwner.SelectMethod; }
			set { ProductVendorOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductVendorService ProductVendorProvider
		{
			get { return Provider as ProductVendorService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductVendor> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductVendor> results = null;
			ProductVendor item;
			count = 0;
			
			System.String _unitMeasureCode;
			System.Int32 _vendorId;
			System.Int32 _productId;

			switch ( SelectMethod )
			{
				case ProductVendorSelectMethod.Get:
					ProductVendorKey entityKey  = new ProductVendorKey();
					entityKey.Load(values);
					item = ProductVendorProvider.Get(entityKey);
					results = new TList<ProductVendor>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductVendorSelectMethod.GetAll:
                    results = ProductVendorProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductVendorSelectMethod.GetPaged:
					results = ProductVendorProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductVendorSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductVendorProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductVendorProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductVendorSelectMethod.GetByProductIdVendorId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					item = ProductVendorProvider.GetByProductIdVendorId(_productId, _vendorId);
					results = new TList<ProductVendor>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductVendorSelectMethod.GetByUnitMeasureCode:
					_unitMeasureCode = ( values["UnitMeasureCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["UnitMeasureCode"], typeof(System.String)) : string.Empty;
					results = ProductVendorProvider.GetByUnitMeasureCode(_unitMeasureCode, this.StartIndex, this.PageSize, out count);
					break;
				case ProductVendorSelectMethod.GetByVendorId:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					results = ProductVendorProvider.GetByVendorId(_vendorId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case ProductVendorSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductVendorProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
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
			if ( SelectMethod == ProductVendorSelectMethod.Get || SelectMethod == ProductVendorSelectMethod.GetByProductIdVendorId )
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
				ProductVendor entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductVendorProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductVendor> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductVendorProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductVendorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductVendorDataSource class.
	/// </summary>
	public class ProductVendorDataSourceDesigner : ProviderDataSourceDesigner<ProductVendor, ProductVendorKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductVendorDataSourceDesigner class.
		/// </summary>
		public ProductVendorDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductVendorSelectMethod SelectMethod
		{
			get { return ((ProductVendorDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductVendorDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductVendorDataSourceActionList

	/// <summary>
	/// Supports the ProductVendorDataSourceDesigner class.
	/// </summary>
	internal class ProductVendorDataSourceActionList : DesignerActionList
	{
		private ProductVendorDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductVendorDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductVendorDataSourceActionList(ProductVendorDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductVendorSelectMethod SelectMethod
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

	#endregion ProductVendorDataSourceActionList
	
	#endregion ProductVendorDataSourceDesigner
	
	#region ProductVendorSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductVendorDataSource.SelectMethod property.
	/// </summary>
	public enum ProductVendorSelectMethod
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
		/// Represents the GetByUnitMeasureCode method.
		/// </summary>
		GetByUnitMeasureCode,
		/// <summary>
		/// Represents the GetByVendorId method.
		/// </summary>
		GetByVendorId,
		/// <summary>
		/// Represents the GetByProductIdVendorId method.
		/// </summary>
		GetByProductIdVendorId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion ProductVendorSelectMethod

	#region ProductVendorFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductVendorFilter : SqlFilter<ProductVendorColumn>
	{
	}
	
	#endregion ProductVendorFilter

	#region ProductVendorExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductVendorExpressionBuilder : SqlExpressionBuilder<ProductVendorColumn>
	{
	}
	
	#endregion ProductVendorExpressionBuilder	

	#region ProductVendorProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductVendorChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductVendorProperty : ChildEntityProperty<ProductVendorChildEntityTypes>
	{
	}
	
	#endregion ProductVendorProperty
}

