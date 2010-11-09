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
	/// Represents the DataRepository.WorkOrderProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(WorkOrderDataSourceDesigner))]
	public class WorkOrderDataSource : ProviderDataSource<WorkOrder, WorkOrderKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderDataSource class.
		/// </summary>
		public WorkOrderDataSource() : base(new WorkOrderService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the WorkOrderDataSourceView used by the WorkOrderDataSource.
		/// </summary>
		protected WorkOrderDataSourceView WorkOrderView
		{
			get { return ( View as WorkOrderDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the WorkOrderDataSource control invokes to retrieve data.
		/// </summary>
		public WorkOrderSelectMethod SelectMethod
		{
			get
			{
				WorkOrderSelectMethod selectMethod = WorkOrderSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (WorkOrderSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the WorkOrderDataSourceView class that is to be
		/// used by the WorkOrderDataSource.
		/// </summary>
		/// <returns>An instance of the WorkOrderDataSourceView class.</returns>
		protected override BaseDataSourceView<WorkOrder, WorkOrderKey> GetNewDataSourceView()
		{
			return new WorkOrderDataSourceView(this, DefaultViewName);
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
	/// Supports the WorkOrderDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class WorkOrderDataSourceView : ProviderDataSourceView<WorkOrder, WorkOrderKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the WorkOrderDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public WorkOrderDataSourceView(WorkOrderDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal WorkOrderDataSource WorkOrderOwner
		{
			get { return Owner as WorkOrderDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal WorkOrderSelectMethod SelectMethod
		{
			get { return WorkOrderOwner.SelectMethod; }
			set { WorkOrderOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal WorkOrderService WorkOrderProvider
		{
			get { return Provider as WorkOrderService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<WorkOrder> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<WorkOrder> results = null;
			WorkOrder item;
			count = 0;
			
			System.Int32 _productId;
			System.Int16? _scrapReasonId_nullable;
			System.Int32 _workOrderId;

			switch ( SelectMethod )
			{
				case WorkOrderSelectMethod.Get:
					WorkOrderKey entityKey  = new WorkOrderKey();
					entityKey.Load(values);
					item = WorkOrderProvider.Get(entityKey);
					results = new TList<WorkOrder>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case WorkOrderSelectMethod.GetAll:
                    results = WorkOrderProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case WorkOrderSelectMethod.GetPaged:
					results = WorkOrderProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case WorkOrderSelectMethod.Find:
					if ( FilterParameters != null )
						results = WorkOrderProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = WorkOrderProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case WorkOrderSelectMethod.GetByWorkOrderId:
					_workOrderId = ( values["WorkOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkOrderId"], typeof(System.Int32)) : (int)0;
					item = WorkOrderProvider.GetByWorkOrderId(_workOrderId);
					results = new TList<WorkOrder>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case WorkOrderSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = WorkOrderProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				case WorkOrderSelectMethod.GetByScrapReasonId:
					_scrapReasonId_nullable = (System.Int16?) EntityUtil.ChangeType(values["ScrapReasonId"], typeof(System.Int16?));
					results = WorkOrderProvider.GetByScrapReasonId(_scrapReasonId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == WorkOrderSelectMethod.Get || SelectMethod == WorkOrderSelectMethod.GetByWorkOrderId )
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
				WorkOrder entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					WorkOrderProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<WorkOrder> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			WorkOrderProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region WorkOrderDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the WorkOrderDataSource class.
	/// </summary>
	public class WorkOrderDataSourceDesigner : ProviderDataSourceDesigner<WorkOrder, WorkOrderKey>
	{
		/// <summary>
		/// Initializes a new instance of the WorkOrderDataSourceDesigner class.
		/// </summary>
		public WorkOrderDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WorkOrderSelectMethod SelectMethod
		{
			get { return ((WorkOrderDataSource) DataSource).SelectMethod; }
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
				actions.Add(new WorkOrderDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region WorkOrderDataSourceActionList

	/// <summary>
	/// Supports the WorkOrderDataSourceDesigner class.
	/// </summary>
	internal class WorkOrderDataSourceActionList : DesignerActionList
	{
		private WorkOrderDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the WorkOrderDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public WorkOrderDataSourceActionList(WorkOrderDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WorkOrderSelectMethod SelectMethod
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

	#endregion WorkOrderDataSourceActionList
	
	#endregion WorkOrderDataSourceDesigner
	
	#region WorkOrderSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the WorkOrderDataSource.SelectMethod property.
	/// </summary>
	public enum WorkOrderSelectMethod
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
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId,
		/// <summary>
		/// Represents the GetByScrapReasonId method.
		/// </summary>
		GetByScrapReasonId,
		/// <summary>
		/// Represents the GetByWorkOrderId method.
		/// </summary>
		GetByWorkOrderId
	}
	
	#endregion WorkOrderSelectMethod

	#region WorkOrderFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderFilter : SqlFilter<WorkOrderColumn>
	{
	}
	
	#endregion WorkOrderFilter

	#region WorkOrderExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderExpressionBuilder : SqlExpressionBuilder<WorkOrderColumn>
	{
	}
	
	#endregion WorkOrderExpressionBuilder	

	#region WorkOrderProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;WorkOrderChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderProperty : ChildEntityProperty<WorkOrderChildEntityTypes>
	{
	}
	
	#endregion WorkOrderProperty
}

