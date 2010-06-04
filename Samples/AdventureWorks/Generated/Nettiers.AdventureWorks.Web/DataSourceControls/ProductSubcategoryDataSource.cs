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
	/// Represents the DataRepository.ProductSubcategoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductSubcategoryDataSourceDesigner))]
	public class ProductSubcategoryDataSource : ProviderDataSource<ProductSubcategory, ProductSubcategoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryDataSource class.
		/// </summary>
		public ProductSubcategoryDataSource() : base(new ProductSubcategoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductSubcategoryDataSourceView used by the ProductSubcategoryDataSource.
		/// </summary>
		protected ProductSubcategoryDataSourceView ProductSubcategoryView
		{
			get { return ( View as ProductSubcategoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductSubcategoryDataSource control invokes to retrieve data.
		/// </summary>
		public ProductSubcategorySelectMethod SelectMethod
		{
			get
			{
				ProductSubcategorySelectMethod selectMethod = ProductSubcategorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductSubcategorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductSubcategoryDataSourceView class that is to be
		/// used by the ProductSubcategoryDataSource.
		/// </summary>
		/// <returns>An instance of the ProductSubcategoryDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductSubcategory, ProductSubcategoryKey> GetNewDataSourceView()
		{
			return new ProductSubcategoryDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductSubcategoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductSubcategoryDataSourceView : ProviderDataSourceView<ProductSubcategory, ProductSubcategoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductSubcategoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductSubcategoryDataSourceView(ProductSubcategoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductSubcategoryDataSource ProductSubcategoryOwner
		{
			get { return Owner as ProductSubcategoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductSubcategorySelectMethod SelectMethod
		{
			get { return ProductSubcategoryOwner.SelectMethod; }
			set { ProductSubcategoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductSubcategoryService ProductSubcategoryProvider
		{
			get { return Provider as ProductSubcategoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductSubcategory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductSubcategory> results = null;
			ProductSubcategory item;
			count = 0;
			
			System.String _name;
			System.Guid _rowguid;
			System.Int32 _productSubcategoryId;
			System.Int32 _productCategoryId;

			switch ( SelectMethod )
			{
				case ProductSubcategorySelectMethod.Get:
					ProductSubcategoryKey entityKey  = new ProductSubcategoryKey();
					entityKey.Load(values);
					item = ProductSubcategoryProvider.Get(entityKey);
					results = new TList<ProductSubcategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductSubcategorySelectMethod.GetAll:
                    results = ProductSubcategoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductSubcategorySelectMethod.GetPaged:
					results = ProductSubcategoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductSubcategorySelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductSubcategoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductSubcategoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductSubcategorySelectMethod.GetByProductSubcategoryId:
					_productSubcategoryId = ( values["ProductSubcategoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductSubcategoryId"], typeof(System.Int32)) : (int)0;
					item = ProductSubcategoryProvider.GetByProductSubcategoryId(_productSubcategoryId);
					results = new TList<ProductSubcategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductSubcategorySelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ProductSubcategoryProvider.GetByName(_name);
					results = new TList<ProductSubcategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductSubcategorySelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = ProductSubcategoryProvider.GetByRowguid(_rowguid);
					results = new TList<ProductSubcategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case ProductSubcategorySelectMethod.GetByProductCategoryId:
					_productCategoryId = ( values["ProductCategoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductCategoryId"], typeof(System.Int32)) : (int)0;
					results = ProductSubcategoryProvider.GetByProductCategoryId(_productCategoryId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductSubcategorySelectMethod.Get || SelectMethod == ProductSubcategorySelectMethod.GetByProductSubcategoryId )
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
				ProductSubcategory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductSubcategoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductSubcategory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductSubcategoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductSubcategoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductSubcategoryDataSource class.
	/// </summary>
	public class ProductSubcategoryDataSourceDesigner : ProviderDataSourceDesigner<ProductSubcategory, ProductSubcategoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryDataSourceDesigner class.
		/// </summary>
		public ProductSubcategoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductSubcategorySelectMethod SelectMethod
		{
			get { return ((ProductSubcategoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductSubcategoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductSubcategoryDataSourceActionList

	/// <summary>
	/// Supports the ProductSubcategoryDataSourceDesigner class.
	/// </summary>
	internal class ProductSubcategoryDataSourceActionList : DesignerActionList
	{
		private ProductSubcategoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductSubcategoryDataSourceActionList(ProductSubcategoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductSubcategorySelectMethod SelectMethod
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

	#endregion ProductSubcategoryDataSourceActionList
	
	#endregion ProductSubcategoryDataSourceDesigner
	
	#region ProductSubcategorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductSubcategoryDataSource.SelectMethod property.
	/// </summary>
	public enum ProductSubcategorySelectMethod
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
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByProductSubcategoryId method.
		/// </summary>
		GetByProductSubcategoryId,
		/// <summary>
		/// Represents the GetByProductCategoryId method.
		/// </summary>
		GetByProductCategoryId
	}
	
	#endregion ProductSubcategorySelectMethod

	#region ProductSubcategoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSubcategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSubcategoryFilter : SqlFilter<ProductSubcategoryColumn>
	{
	}
	
	#endregion ProductSubcategoryFilter

	#region ProductSubcategoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSubcategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSubcategoryExpressionBuilder : SqlExpressionBuilder<ProductSubcategoryColumn>
	{
	}
	
	#endregion ProductSubcategoryExpressionBuilder	

	#region ProductSubcategoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductSubcategoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSubcategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSubcategoryProperty : ChildEntityProperty<ProductSubcategoryChildEntityTypes>
	{
	}
	
	#endregion ProductSubcategoryProperty
}

