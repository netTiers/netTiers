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
	/// Represents the DataRepository.LineItemProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LineItemDataSourceDesigner))]
	public class LineItemDataSource : ProviderDataSource<LineItem, LineItemKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LineItemDataSource class.
		/// </summary>
		public LineItemDataSource() : base(new LineItemService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LineItemDataSourceView used by the LineItemDataSource.
		/// </summary>
		protected LineItemDataSourceView LineItemView
		{
			get { return ( View as LineItemDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LineItemDataSource control invokes to retrieve data.
		/// </summary>
		public LineItemSelectMethod SelectMethod
		{
			get { return LineItemView.SelectMethod; }
			set { LineItemView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LineItemDataSourceView class that is to be
		/// used by the LineItemDataSource.
		/// </summary>
		/// <returns>An instance of the LineItemDataSourceView class.</returns>
		protected override BaseDataSourceView<LineItem, LineItemKey> GetNewDataSourceView()
		{
			return new LineItemDataSourceView(this, DefaultViewName);
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
	/// Supports the LineItemDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LineItemDataSourceView : ProviderDataSourceView<LineItem, LineItemKey>
	{
		#region Declarations

		private LineItemSelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LineItemDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LineItemDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LineItemDataSourceView(LineItemDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LineItemSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LineItemService LineItemProvider
		{
			get { return Provider as LineItemService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LineItem> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<LineItem> results = null;
			LineItem item;
			count = 0;
			
			System.Int32 orderId;
			System.Int32 lineNum;
			System.Guid itemId;

			switch ( SelectMethod )
			{
				case LineItemSelectMethod.Get:
					LineItemKey entityKey  = new LineItemKey();
					entityKey.Load(values);
					item = LineItemProvider.Get(entityKey);
					results = new TList<LineItem>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LineItemSelectMethod.GetAll:
                    results = LineItemProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LineItemSelectMethod.GetPaged:
					results = LineItemProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LineItemSelectMethod.Find:
					results = LineItemProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LineItemSelectMethod.GetByLineNumOrderId:
					orderId = ( values["OrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderId"], typeof(System.Int32)) : (int)0;
					lineNum = ( values["LineNum"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LineNum"], typeof(System.Int32)) : (int)0;
					item = LineItemProvider.GetByLineNumOrderId(orderId, lineNum);
					results = new TList<LineItem>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case LineItemSelectMethod.GetByOrderId:
					orderId = ( values["OrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderId"], typeof(System.Int32)) : (int)0;
					results = LineItemProvider.GetByOrderId(orderId, this.StartIndex, this.PageSize, out count);
					break;
				case LineItemSelectMethod.GetByItemId:
					itemId = ( values["ItemId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ItemId"], typeof(System.Guid)) : Guid.Empty;
					results = LineItemProvider.GetByItemId(itemId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LineItemSelectMethod.Get || SelectMethod == LineItemSelectMethod.GetByLineNumOrderId )
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
				LineItem entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LineItemProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					IsDeepLoaded = true;
				}
			}
		}

		#endregion Select Methods
	}
	
	#region LineItemDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LineItemDataSource class.
	/// </summary>
	public class LineItemDataSourceDesigner : ProviderDataSourceDesigner<LineItem, LineItemKey>
	{
		/// <summary>
		/// Initializes a new instance of the LineItemDataSourceDesigner class.
		/// </summary>
		public LineItemDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LineItemSelectMethod SelectMethod
		{
			get { return ((LineItemDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LineItemDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LineItemDataSourceActionList

	/// <summary>
	/// Supports the LineItemDataSourceDesigner class.
	/// </summary>
	internal class LineItemDataSourceActionList : DesignerActionList
	{
		private LineItemDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LineItemDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LineItemDataSourceActionList(LineItemDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LineItemSelectMethod SelectMethod
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

	#endregion LineItemDataSourceActionList
	
	#endregion LineItemDataSourceDesigner
	
	#region LineItemSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LineItemDataSource.SelectMethod property.
	/// </summary>
	public enum LineItemSelectMethod
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
		/// Represents the GetByLineNumOrderId method.
		/// </summary>
		GetByLineNumOrderId,
		/// <summary>
		/// Represents the GetByOrderId method.
		/// </summary>
		GetByOrderId,
		/// <summary>
		/// Represents the GetByItemId method.
		/// </summary>
		GetByItemId
	}
	
	#endregion LineItemSelectMethod

	#region LineItemFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LineItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LineItemFilter : SqlFilter<LineItemColumn>
	{
	}
	
	#endregion LineItemFilter
}

