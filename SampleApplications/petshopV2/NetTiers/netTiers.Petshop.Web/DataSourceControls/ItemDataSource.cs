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
	/// Represents the DataRepository.ItemProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemDataSourceDesigner))]
	public class ItemDataSource : ProviderDataSource<Item, ItemKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemDataSource class.
		/// </summary>
		public ItemDataSource() : base(new ItemService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemDataSourceView used by the ItemDataSource.
		/// </summary>
		protected ItemDataSourceView ItemView
		{
			get { return ( View as ItemDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemDataSource control invokes to retrieve data.
		/// </summary>
		public ItemSelectMethod SelectMethod
		{
			get { return ItemView.SelectMethod; }
			set { ItemView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemDataSourceView class that is to be
		/// used by the ItemDataSource.
		/// </summary>
		/// <returns>An instance of the ItemDataSourceView class.</returns>
		protected override BaseDataSourceView<Item, ItemKey> GetNewDataSourceView()
		{
			return new ItemDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemDataSourceView : ProviderDataSourceView<Item, ItemKey>
	{
		#region Declarations

		private ItemSelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemDataSourceView(ItemDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemService ItemProvider
		{
			get { return Provider as ItemService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Item> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<Item> results = null;
			Item item;
			count = 0;
			
			System.String id;
			System.String productId;

			switch ( SelectMethod )
			{
				case ItemSelectMethod.Get:
					ItemKey key = new ItemKey();
					key.Load(values);
					item = ItemProvider.Get(key);
					results = new TList<Item>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemSelectMethod.GetAll:
                    results = ItemProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ItemSelectMethod.GetPaged:
					results = ItemProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemSelectMethod.Find:
					results = ItemProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemSelectMethod.GetById:
					id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = ItemProvider.GetById(id);
					results = new TList<Item>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ItemSelectMethod.GetByProductId:
					productId = ( values["ProductId"] != null ) ? (System.String) EntityUtil.ChangeType(values["ProductId"], typeof(System.String)) : string.Empty;
					results = ItemProvider.GetByProductId(productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ItemSelectMethod.Get || SelectMethod == ItemSelectMethod.GetById )
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
				ItemProvider.DeepLoad(GetCurrentEntity());
			}
		}

		#endregion Select Methods
	}
	
	#region ItemDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemDataSource class.
	/// </summary>
	public class ItemDataSourceDesigner : ProviderDataSourceDesigner<Item, ItemKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemDataSourceDesigner class.
		/// </summary>
		public ItemDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemSelectMethod SelectMethod
		{
			get { return ((ItemDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemDataSourceActionList

	/// <summary>
	/// Supports the ItemDataSourceDesigner class.
	/// </summary>
	internal class ItemDataSourceActionList : DesignerActionList
	{
		private ItemDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemDataSourceActionList(ItemDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemSelectMethod SelectMethod
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

	#endregion ItemDataSourceActionList
	
	#endregion ItemDataSourceDesigner
	
	#region ItemSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemDataSource.SelectMethod property.
	/// </summary>
	public enum ItemSelectMethod
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
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion ItemSelectMethod

	#region ItemFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Item"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemFilter : SqlFilter<ItemColumn>
	{
	}
	
	#endregion ItemFilter
}

