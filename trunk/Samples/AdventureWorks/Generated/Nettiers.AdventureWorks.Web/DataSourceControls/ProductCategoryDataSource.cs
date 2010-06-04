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
	/// Represents the DataRepository.ProductCategoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductCategoryDataSourceDesigner))]
	public class ProductCategoryDataSource : ProviderDataSource<ProductCategory, ProductCategoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCategoryDataSource class.
		/// </summary>
		public ProductCategoryDataSource() : base(new ProductCategoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductCategoryDataSourceView used by the ProductCategoryDataSource.
		/// </summary>
		protected ProductCategoryDataSourceView ProductCategoryView
		{
			get { return ( View as ProductCategoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductCategoryDataSource control invokes to retrieve data.
		/// </summary>
		public ProductCategorySelectMethod SelectMethod
		{
			get
			{
				ProductCategorySelectMethod selectMethod = ProductCategorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductCategorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductCategoryDataSourceView class that is to be
		/// used by the ProductCategoryDataSource.
		/// </summary>
		/// <returns>An instance of the ProductCategoryDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductCategory, ProductCategoryKey> GetNewDataSourceView()
		{
			return new ProductCategoryDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductCategoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductCategoryDataSourceView : ProviderDataSourceView<ProductCategory, ProductCategoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCategoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductCategoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductCategoryDataSourceView(ProductCategoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductCategoryDataSource ProductCategoryOwner
		{
			get { return Owner as ProductCategoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductCategorySelectMethod SelectMethod
		{
			get { return ProductCategoryOwner.SelectMethod; }
			set { ProductCategoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductCategoryService ProductCategoryProvider
		{
			get { return Provider as ProductCategoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductCategory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductCategory> results = null;
			ProductCategory item;
			count = 0;
			
			System.String _name;
			System.Guid _rowguid;
			System.Int32 _productCategoryId;

			switch ( SelectMethod )
			{
				case ProductCategorySelectMethod.Get:
					ProductCategoryKey entityKey  = new ProductCategoryKey();
					entityKey.Load(values);
					item = ProductCategoryProvider.Get(entityKey);
					results = new TList<ProductCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductCategorySelectMethod.GetAll:
                    results = ProductCategoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductCategorySelectMethod.GetPaged:
					results = ProductCategoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductCategorySelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductCategoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductCategoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductCategorySelectMethod.GetByProductCategoryId:
					_productCategoryId = ( values["ProductCategoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductCategoryId"], typeof(System.Int32)) : (int)0;
					item = ProductCategoryProvider.GetByProductCategoryId(_productCategoryId);
					results = new TList<ProductCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductCategorySelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ProductCategoryProvider.GetByName(_name);
					results = new TList<ProductCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductCategorySelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = ProductCategoryProvider.GetByRowguid(_rowguid);
					results = new TList<ProductCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
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
			if ( SelectMethod == ProductCategorySelectMethod.Get || SelectMethod == ProductCategorySelectMethod.GetByProductCategoryId )
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
				ProductCategory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductCategoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductCategory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductCategoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductCategoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductCategoryDataSource class.
	/// </summary>
	public class ProductCategoryDataSourceDesigner : ProviderDataSourceDesigner<ProductCategory, ProductCategoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductCategoryDataSourceDesigner class.
		/// </summary>
		public ProductCategoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductCategorySelectMethod SelectMethod
		{
			get { return ((ProductCategoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductCategoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductCategoryDataSourceActionList

	/// <summary>
	/// Supports the ProductCategoryDataSourceDesigner class.
	/// </summary>
	internal class ProductCategoryDataSourceActionList : DesignerActionList
	{
		private ProductCategoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductCategoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductCategoryDataSourceActionList(ProductCategoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductCategorySelectMethod SelectMethod
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

	#endregion ProductCategoryDataSourceActionList
	
	#endregion ProductCategoryDataSourceDesigner
	
	#region ProductCategorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductCategoryDataSource.SelectMethod property.
	/// </summary>
	public enum ProductCategorySelectMethod
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
		/// Represents the GetByProductCategoryId method.
		/// </summary>
		GetByProductCategoryId
	}
	
	#endregion ProductCategorySelectMethod

	#region ProductCategoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCategoryFilter : SqlFilter<ProductCategoryColumn>
	{
	}
	
	#endregion ProductCategoryFilter

	#region ProductCategoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCategoryExpressionBuilder : SqlExpressionBuilder<ProductCategoryColumn>
	{
	}
	
	#endregion ProductCategoryExpressionBuilder	

	#region ProductCategoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductCategoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCategoryProperty : ChildEntityProperty<ProductCategoryChildEntityTypes>
	{
	}
	
	#endregion ProductCategoryProperty
}

