#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.Bases;
using netTiers.Petshop.Services;
#endregion

namespace netTiers.Petshop.Web.Data
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
			get { return ProductView.SelectMethod; }
			set { ProductView.SelectMethod = value; }
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

		private ProductSelectMethod _selectMethod;

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
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
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
			IList<Product> results = null;
			Product item;
			count = 0;
			
			System.String id;
			System.String categoryId;

			switch ( SelectMethod )
			{
				case ProductSelectMethod.Get:
					ProductKey key = new ProductKey();
					key.Load(values);
					item = ProductProvider.Get(key);
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
					results = ProductProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductSelectMethod.GetById:
					id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = ProductProvider.GetById(id);
					results = new TList<Product>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProductSelectMethod.GetByCategoryId:
					categoryId = ( values["CategoryId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CategoryId"], typeof(System.String)) : string.Empty;
					results = ProductProvider.GetByCategoryId(categoryId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				default:
					break;
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == ProductSelectMethod.Get || SelectMethod == ProductSelectMethod.GetById )
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
				IsDeepLoaded = true;
				ProductProvider.DeepLoad(GetCurrentEntity());
			}
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
		/// Represents the GetById method.
		/// </summary>
		GetById,
		/// <summary>
		/// Represents the GetByCategoryId method.
		/// </summary>
		GetByCategoryId
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
}

