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
	/// Represents the DataRepository.OrderStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OrderStatusDataSourceDesigner))]
	public class OrderStatusDataSource : ProviderDataSource<OrderStatus, OrderStatusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusDataSource class.
		/// </summary>
		public OrderStatusDataSource() : base(new OrderStatusService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OrderStatusDataSourceView used by the OrderStatusDataSource.
		/// </summary>
		protected OrderStatusDataSourceView OrderStatusView
		{
			get { return ( View as OrderStatusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OrderStatusDataSource control invokes to retrieve data.
		/// </summary>
		public OrderStatusSelectMethod SelectMethod
		{
			get { return OrderStatusView.SelectMethod; }
			set { OrderStatusView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OrderStatusDataSourceView class that is to be
		/// used by the OrderStatusDataSource.
		/// </summary>
		/// <returns>An instance of the OrderStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<OrderStatus, OrderStatusKey> GetNewDataSourceView()
		{
			return new OrderStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the OrderStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OrderStatusDataSourceView : ProviderDataSourceView<OrderStatus, OrderStatusKey>
	{
		#region Declarations

		private OrderStatusSelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OrderStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OrderStatusDataSourceView(OrderStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OrderStatusSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OrderStatusService OrderStatusProvider
		{
			get { return Provider as OrderStatusService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<OrderStatus> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<OrderStatus> results = null;
			OrderStatus item;
			count = 0;
			
			System.Int32 orderId;
			System.Int32 lineNum;
			System.Int32 orderStatusId;

			switch ( SelectMethod )
			{
				case OrderStatusSelectMethod.Get:
					OrderStatusKey entityKey  = new OrderStatusKey();
					entityKey.Load(values);
					item = OrderStatusProvider.Get(entityKey);
					results = new TList<OrderStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OrderStatusSelectMethod.GetAll:
                    results = OrderStatusProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case OrderStatusSelectMethod.GetPaged:
					results = OrderStatusProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OrderStatusSelectMethod.Find:
					results = OrderStatusProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OrderStatusSelectMethod.GetByLineNumOrderId:
					orderId = ( values["OrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderId"], typeof(System.Int32)) : (int)0;
					lineNum = ( values["LineNum"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LineNum"], typeof(System.Int32)) : (int)0;
					item = OrderStatusProvider.GetByLineNumOrderId(orderId, lineNum);
					results = new TList<OrderStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case OrderStatusSelectMethod.GetByOrderId:
					orderId = ( values["OrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderId"], typeof(System.Int32)) : (int)0;
					results = OrderStatusProvider.GetByOrderId(orderId, this.StartIndex, this.PageSize, out count);
					break;
				case OrderStatusSelectMethod.GetByOrderStatusId:
					orderStatusId = ( values["OrderStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderStatusId"], typeof(System.Int32)) : (int)0;
					results = OrderStatusProvider.GetByOrderStatusId(orderStatusId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == OrderStatusSelectMethod.Get || SelectMethod == OrderStatusSelectMethod.GetByLineNumOrderId )
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
				OrderStatus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					OrderStatusProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					IsDeepLoaded = true;
				}
			}
		}

		#endregion Select Methods
	}
	
	#region OrderStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OrderStatusDataSource class.
	/// </summary>
	public class OrderStatusDataSourceDesigner : ProviderDataSourceDesigner<OrderStatus, OrderStatusKey>
	{
		/// <summary>
		/// Initializes a new instance of the OrderStatusDataSourceDesigner class.
		/// </summary>
		public OrderStatusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrderStatusSelectMethod SelectMethod
		{
			get { return ((OrderStatusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OrderStatusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OrderStatusDataSourceActionList

	/// <summary>
	/// Supports the OrderStatusDataSourceDesigner class.
	/// </summary>
	internal class OrderStatusDataSourceActionList : DesignerActionList
	{
		private OrderStatusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OrderStatusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OrderStatusDataSourceActionList(OrderStatusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrderStatusSelectMethod SelectMethod
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

	#endregion OrderStatusDataSourceActionList
	
	#endregion OrderStatusDataSourceDesigner
	
	#region OrderStatusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OrderStatusDataSource.SelectMethod property.
	/// </summary>
	public enum OrderStatusSelectMethod
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
		/// Represents the GetByOrderStatusId method.
		/// </summary>
		GetByOrderStatusId
	}
	
	#endregion OrderStatusSelectMethod

	#region OrderStatusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusFilter : SqlFilter<OrderStatusColumn>
	{
	}
	
	#endregion OrderStatusFilter
}

