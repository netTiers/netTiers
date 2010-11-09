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
	/// Represents the DataRepository.ShoppingCartItemProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ShoppingCartItemDataSourceDesigner))]
	public class ShoppingCartItemDataSource : ProviderDataSource<ShoppingCartItem, ShoppingCartItemKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemDataSource class.
		/// </summary>
		public ShoppingCartItemDataSource() : base(new ShoppingCartItemService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ShoppingCartItemDataSourceView used by the ShoppingCartItemDataSource.
		/// </summary>
		protected ShoppingCartItemDataSourceView ShoppingCartItemView
		{
			get { return ( View as ShoppingCartItemDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ShoppingCartItemDataSource control invokes to retrieve data.
		/// </summary>
		public ShoppingCartItemSelectMethod SelectMethod
		{
			get
			{
				ShoppingCartItemSelectMethod selectMethod = ShoppingCartItemSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ShoppingCartItemSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ShoppingCartItemDataSourceView class that is to be
		/// used by the ShoppingCartItemDataSource.
		/// </summary>
		/// <returns>An instance of the ShoppingCartItemDataSourceView class.</returns>
		protected override BaseDataSourceView<ShoppingCartItem, ShoppingCartItemKey> GetNewDataSourceView()
		{
			return new ShoppingCartItemDataSourceView(this, DefaultViewName);
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
	/// Supports the ShoppingCartItemDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ShoppingCartItemDataSourceView : ProviderDataSourceView<ShoppingCartItem, ShoppingCartItemKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ShoppingCartItemDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ShoppingCartItemDataSourceView(ShoppingCartItemDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ShoppingCartItemDataSource ShoppingCartItemOwner
		{
			get { return Owner as ShoppingCartItemDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ShoppingCartItemSelectMethod SelectMethod
		{
			get { return ShoppingCartItemOwner.SelectMethod; }
			set { ShoppingCartItemOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ShoppingCartItemService ShoppingCartItemProvider
		{
			get { return Provider as ShoppingCartItemService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ShoppingCartItem> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ShoppingCartItem> results = null;
			ShoppingCartItem item;
			count = 0;
			
			System.String _shoppingCartId;
			System.Int32 _productId;
			System.Int32 _shoppingCartItemId;

			switch ( SelectMethod )
			{
				case ShoppingCartItemSelectMethod.Get:
					ShoppingCartItemKey entityKey  = new ShoppingCartItemKey();
					entityKey.Load(values);
					item = ShoppingCartItemProvider.Get(entityKey);
					results = new TList<ShoppingCartItem>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ShoppingCartItemSelectMethod.GetAll:
                    results = ShoppingCartItemProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ShoppingCartItemSelectMethod.GetPaged:
					results = ShoppingCartItemProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ShoppingCartItemSelectMethod.Find:
					if ( FilterParameters != null )
						results = ShoppingCartItemProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ShoppingCartItemProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ShoppingCartItemSelectMethod.GetByShoppingCartItemId:
					_shoppingCartItemId = ( values["ShoppingCartItemId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ShoppingCartItemId"], typeof(System.Int32)) : (int)0;
					item = ShoppingCartItemProvider.GetByShoppingCartItemId(_shoppingCartItemId);
					results = new TList<ShoppingCartItem>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ShoppingCartItemSelectMethod.GetByShoppingCartIdProductId:
					_shoppingCartId = ( values["ShoppingCartId"] != null ) ? (System.String) EntityUtil.ChangeType(values["ShoppingCartId"], typeof(System.String)) : string.Empty;
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ShoppingCartItemProvider.GetByShoppingCartIdProductId(_shoppingCartId, _productId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case ShoppingCartItemSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ShoppingCartItemProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ShoppingCartItemSelectMethod.Get || SelectMethod == ShoppingCartItemSelectMethod.GetByShoppingCartItemId )
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
				ShoppingCartItem entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ShoppingCartItemProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ShoppingCartItem> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ShoppingCartItemProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ShoppingCartItemDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ShoppingCartItemDataSource class.
	/// </summary>
	public class ShoppingCartItemDataSourceDesigner : ProviderDataSourceDesigner<ShoppingCartItem, ShoppingCartItemKey>
	{
		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemDataSourceDesigner class.
		/// </summary>
		public ShoppingCartItemDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ShoppingCartItemSelectMethod SelectMethod
		{
			get { return ((ShoppingCartItemDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ShoppingCartItemDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ShoppingCartItemDataSourceActionList

	/// <summary>
	/// Supports the ShoppingCartItemDataSourceDesigner class.
	/// </summary>
	internal class ShoppingCartItemDataSourceActionList : DesignerActionList
	{
		private ShoppingCartItemDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ShoppingCartItemDataSourceActionList(ShoppingCartItemDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ShoppingCartItemSelectMethod SelectMethod
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

	#endregion ShoppingCartItemDataSourceActionList
	
	#endregion ShoppingCartItemDataSourceDesigner
	
	#region ShoppingCartItemSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ShoppingCartItemDataSource.SelectMethod property.
	/// </summary>
	public enum ShoppingCartItemSelectMethod
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
		/// Represents the GetByShoppingCartIdProductId method.
		/// </summary>
		GetByShoppingCartIdProductId,
		/// <summary>
		/// Represents the GetByShoppingCartItemId method.
		/// </summary>
		GetByShoppingCartItemId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion ShoppingCartItemSelectMethod

	#region ShoppingCartItemFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShoppingCartItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShoppingCartItemFilter : SqlFilter<ShoppingCartItemColumn>
	{
	}
	
	#endregion ShoppingCartItemFilter

	#region ShoppingCartItemExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShoppingCartItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShoppingCartItemExpressionBuilder : SqlExpressionBuilder<ShoppingCartItemColumn>
	{
	}
	
	#endregion ShoppingCartItemExpressionBuilder	

	#region ShoppingCartItemProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ShoppingCartItemChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ShoppingCartItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShoppingCartItemProperty : ChildEntityProperty<ShoppingCartItemChildEntityTypes>
	{
	}
	
	#endregion ShoppingCartItemProperty
}

