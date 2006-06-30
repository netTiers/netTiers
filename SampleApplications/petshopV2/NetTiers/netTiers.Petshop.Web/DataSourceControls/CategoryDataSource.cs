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
	/// Represents the DataRepository.CategoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CategoryDataSourceDesigner))]
	public class CategoryDataSource : ProviderDataSource<Category, CategoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoryDataSource class.
		/// </summary>
		public CategoryDataSource() : base(new CategoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CategoryDataSourceView used by the CategoryDataSource.
		/// </summary>
		protected CategoryDataSourceView CategoryView
		{
			get { return ( View as CategoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CategoryDataSource control invokes to retrieve data.
		/// </summary>
		public CategorySelectMethod SelectMethod
		{
			get { return CategoryView.SelectMethod; }
			set { CategoryView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CategoryDataSourceView class that is to be
		/// used by the CategoryDataSource.
		/// </summary>
		/// <returns>An instance of the CategoryDataSourceView class.</returns>
		protected override BaseDataSourceView<Category, CategoryKey> GetNewDataSourceView()
		{
			return new CategoryDataSourceView(this, DefaultViewName);
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
	/// Supports the CategoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CategoryDataSourceView : ProviderDataSourceView<Category, CategoryKey>
	{
		#region Declarations

		private CategorySelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CategoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CategoryDataSourceView(CategoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CategorySelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CategoryService CategoryProvider
		{
			get { return Provider as CategoryService; }
		}

		#endregion Properties
		
		#region Select Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Category> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<Category> results = null;
			Category item;
			count = 0;
			
			System.String id;

			switch ( SelectMethod )
			{
				case CategorySelectMethod.Get:
					CategoryKey key = new CategoryKey();
					key.Load(values);
					item = CategoryProvider.Get(key);
					results = new TList<Category>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CategorySelectMethod.GetAll:
                    results = CategoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CategorySelectMethod.GetPaged:
					results = CategoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CategorySelectMethod.Find:
					results = CategoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CategorySelectMethod.GetById:
					id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = CategoryProvider.GetById(id);
					results = new TList<Category>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == CategorySelectMethod.Get || SelectMethod == CategorySelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}
		
		#endregion Select Methods
	}
	
	#region CategoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CategoryDataSource class.
	/// </summary>
	public class CategoryDataSourceDesigner : ProviderDataSourceDesigner<Category, CategoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the CategoryDataSourceDesigner class.
		/// </summary>
		public CategoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CategorySelectMethod SelectMethod
		{
			get { return ((CategoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CategoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CategoryDataSourceActionList

	/// <summary>
	/// Supports the CategoryDataSourceDesigner class.
	/// </summary>
	internal class CategoryDataSourceActionList : DesignerActionList
	{
		private CategoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CategoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CategoryDataSourceActionList(CategoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CategorySelectMethod SelectMethod
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

	#endregion CategoryDataSourceActionList
	
	#endregion CategoryDataSourceDesigner
	
	#region CategorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CategoryDataSource.SelectMethod property.
	/// </summary>
	public enum CategorySelectMethod
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
		GetById
	}
	
	#endregion CategorySelectMethod

	#region CategoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Category"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoryFilter : SqlFilter<CategoryColumn>
	{
	}
	
	#endregion CategoryFilter
}

