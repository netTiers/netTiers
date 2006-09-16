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
	/// Represents the DataRepository.OrderStatusTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OrderStatusTypeDataSourceDesigner))]
	public class OrderStatusTypeDataSource : ProviderDataSource<OrderStatusType, OrderStatusTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeDataSource class.
		/// </summary>
		public OrderStatusTypeDataSource() : base(new OrderStatusTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OrderStatusTypeDataSourceView used by the OrderStatusTypeDataSource.
		/// </summary>
		protected OrderStatusTypeDataSourceView OrderStatusTypeView
		{
			get { return ( View as OrderStatusTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OrderStatusTypeDataSource control invokes to retrieve data.
		/// </summary>
		public OrderStatusTypeSelectMethod SelectMethod
		{
			get { return OrderStatusTypeView.SelectMethod; }
			set { OrderStatusTypeView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OrderStatusTypeDataSourceView class that is to be
		/// used by the OrderStatusTypeDataSource.
		/// </summary>
		/// <returns>An instance of the OrderStatusTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<OrderStatusType, OrderStatusTypeKey> GetNewDataSourceView()
		{
			return new OrderStatusTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the OrderStatusTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OrderStatusTypeDataSourceView : ProviderDataSourceView<OrderStatusType, OrderStatusTypeKey>
	{
		#region Declarations

		private OrderStatusTypeSelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OrderStatusTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OrderStatusTypeDataSourceView(OrderStatusTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OrderStatusTypeSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OrderStatusTypeService OrderStatusTypeProvider
		{
			get { return Provider as OrderStatusTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<OrderStatusType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<OrderStatusType> results = null;
			OrderStatusType item;
			count = 0;
			
			System.Int32 orderStatusId;
			System.String orderStatus;

			switch ( SelectMethod )
			{
				case OrderStatusTypeSelectMethod.Get:
					OrderStatusTypeKey entityKey  = new OrderStatusTypeKey();
					entityKey.Load(values);
					item = OrderStatusTypeProvider.Get(entityKey);
					results = new TList<OrderStatusType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OrderStatusTypeSelectMethod.GetAll:
                    results = OrderStatusTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case OrderStatusTypeSelectMethod.GetPaged:
					results = OrderStatusTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OrderStatusTypeSelectMethod.Find:
					results = OrderStatusTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OrderStatusTypeSelectMethod.GetByOrderStatusId:
					orderStatusId = ( values["OrderStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderStatusId"], typeof(System.Int32)) : (int)0;
					item = OrderStatusTypeProvider.GetByOrderStatusId(orderStatusId);
					results = new TList<OrderStatusType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case OrderStatusTypeSelectMethod.GetByOrderStatus:
					orderStatus = ( values["OrderStatus"] != null ) ? (System.String) EntityUtil.ChangeType(values["OrderStatus"], typeof(System.String)) : string.Empty;
					item = OrderStatusTypeProvider.GetByOrderStatus(orderStatus);
					results = new TList<OrderStatusType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
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
			if ( SelectMethod == OrderStatusTypeSelectMethod.Get || SelectMethod == OrderStatusTypeSelectMethod.GetByOrderStatusId )
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
				OrderStatusType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					OrderStatusTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					IsDeepLoaded = true;
				}
			}
		}

		#endregion Select Methods
	}
	
	#region OrderStatusTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OrderStatusTypeDataSource class.
	/// </summary>
	public class OrderStatusTypeDataSourceDesigner : ProviderDataSourceDesigner<OrderStatusType, OrderStatusTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeDataSourceDesigner class.
		/// </summary>
		public OrderStatusTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrderStatusTypeSelectMethod SelectMethod
		{
			get { return ((OrderStatusTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OrderStatusTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OrderStatusTypeDataSourceActionList

	/// <summary>
	/// Supports the OrderStatusTypeDataSourceDesigner class.
	/// </summary>
	internal class OrderStatusTypeDataSourceActionList : DesignerActionList
	{
		private OrderStatusTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OrderStatusTypeDataSourceActionList(OrderStatusTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrderStatusTypeSelectMethod SelectMethod
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

	#endregion OrderStatusTypeDataSourceActionList
	
	#endregion OrderStatusTypeDataSourceDesigner
	
	#region OrderStatusTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OrderStatusTypeDataSource.SelectMethod property.
	/// </summary>
	public enum OrderStatusTypeSelectMethod
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
		/// Represents the GetByOrderStatusId method.
		/// </summary>
		GetByOrderStatusId,
		/// <summary>
		/// Represents the GetByOrderStatus method.
		/// </summary>
		GetByOrderStatus
	}
	
	#endregion OrderStatusTypeSelectMethod

	#region OrderStatusTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatusType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusTypeFilter : SqlFilter<OrderStatusTypeColumn>
	{
	}
	
	#endregion OrderStatusTypeFilter
}

