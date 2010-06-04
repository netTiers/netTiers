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
	/// Represents the DataRepository.WorkOrderRoutingProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(WorkOrderRoutingDataSourceDesigner))]
	public class WorkOrderRoutingDataSource : ProviderDataSource<WorkOrderRouting, WorkOrderRoutingKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingDataSource class.
		/// </summary>
		public WorkOrderRoutingDataSource() : base(new WorkOrderRoutingService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the WorkOrderRoutingDataSourceView used by the WorkOrderRoutingDataSource.
		/// </summary>
		protected WorkOrderRoutingDataSourceView WorkOrderRoutingView
		{
			get { return ( View as WorkOrderRoutingDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the WorkOrderRoutingDataSource control invokes to retrieve data.
		/// </summary>
		public WorkOrderRoutingSelectMethod SelectMethod
		{
			get
			{
				WorkOrderRoutingSelectMethod selectMethod = WorkOrderRoutingSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (WorkOrderRoutingSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the WorkOrderRoutingDataSourceView class that is to be
		/// used by the WorkOrderRoutingDataSource.
		/// </summary>
		/// <returns>An instance of the WorkOrderRoutingDataSourceView class.</returns>
		protected override BaseDataSourceView<WorkOrderRouting, WorkOrderRoutingKey> GetNewDataSourceView()
		{
			return new WorkOrderRoutingDataSourceView(this, DefaultViewName);
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
	/// Supports the WorkOrderRoutingDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class WorkOrderRoutingDataSourceView : ProviderDataSourceView<WorkOrderRouting, WorkOrderRoutingKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the WorkOrderRoutingDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public WorkOrderRoutingDataSourceView(WorkOrderRoutingDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal WorkOrderRoutingDataSource WorkOrderRoutingOwner
		{
			get { return Owner as WorkOrderRoutingDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal WorkOrderRoutingSelectMethod SelectMethod
		{
			get { return WorkOrderRoutingOwner.SelectMethod; }
			set { WorkOrderRoutingOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal WorkOrderRoutingService WorkOrderRoutingProvider
		{
			get { return Provider as WorkOrderRoutingService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<WorkOrderRouting> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<WorkOrderRouting> results = null;
			WorkOrderRouting item;
			count = 0;
			
			System.Int32 _productId;
			System.Int32 _workOrderId;
			System.Int16 _operationSequence;
			System.Int16 _locationId;

			switch ( SelectMethod )
			{
				case WorkOrderRoutingSelectMethod.Get:
					WorkOrderRoutingKey entityKey  = new WorkOrderRoutingKey();
					entityKey.Load(values);
					item = WorkOrderRoutingProvider.Get(entityKey);
					results = new TList<WorkOrderRouting>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case WorkOrderRoutingSelectMethod.GetAll:
                    results = WorkOrderRoutingProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case WorkOrderRoutingSelectMethod.GetPaged:
					results = WorkOrderRoutingProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case WorkOrderRoutingSelectMethod.Find:
					if ( FilterParameters != null )
						results = WorkOrderRoutingProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = WorkOrderRoutingProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case WorkOrderRoutingSelectMethod.GetByWorkOrderIdProductIdOperationSequence:
					_workOrderId = ( values["WorkOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkOrderId"], typeof(System.Int32)) : (int)0;
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_operationSequence = ( values["OperationSequence"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["OperationSequence"], typeof(System.Int16)) : (short)0;
					item = WorkOrderRoutingProvider.GetByWorkOrderIdProductIdOperationSequence(_workOrderId, _productId, _operationSequence);
					results = new TList<WorkOrderRouting>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case WorkOrderRoutingSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = WorkOrderRoutingProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case WorkOrderRoutingSelectMethod.GetByLocationId:
					_locationId = ( values["LocationId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["LocationId"], typeof(System.Int16)) : (short)0;
					results = WorkOrderRoutingProvider.GetByLocationId(_locationId, this.StartIndex, this.PageSize, out count);
					break;
				case WorkOrderRoutingSelectMethod.GetByWorkOrderId:
					_workOrderId = ( values["WorkOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkOrderId"], typeof(System.Int32)) : (int)0;
					results = WorkOrderRoutingProvider.GetByWorkOrderId(_workOrderId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == WorkOrderRoutingSelectMethod.Get || SelectMethod == WorkOrderRoutingSelectMethod.GetByWorkOrderIdProductIdOperationSequence )
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
				WorkOrderRouting entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					WorkOrderRoutingProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<WorkOrderRouting> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			WorkOrderRoutingProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region WorkOrderRoutingDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the WorkOrderRoutingDataSource class.
	/// </summary>
	public class WorkOrderRoutingDataSourceDesigner : ProviderDataSourceDesigner<WorkOrderRouting, WorkOrderRoutingKey>
	{
		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingDataSourceDesigner class.
		/// </summary>
		public WorkOrderRoutingDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WorkOrderRoutingSelectMethod SelectMethod
		{
			get { return ((WorkOrderRoutingDataSource) DataSource).SelectMethod; }
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
				actions.Add(new WorkOrderRoutingDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region WorkOrderRoutingDataSourceActionList

	/// <summary>
	/// Supports the WorkOrderRoutingDataSourceDesigner class.
	/// </summary>
	internal class WorkOrderRoutingDataSourceActionList : DesignerActionList
	{
		private WorkOrderRoutingDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public WorkOrderRoutingDataSourceActionList(WorkOrderRoutingDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WorkOrderRoutingSelectMethod SelectMethod
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

	#endregion WorkOrderRoutingDataSourceActionList
	
	#endregion WorkOrderRoutingDataSourceDesigner
	
	#region WorkOrderRoutingSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the WorkOrderRoutingDataSource.SelectMethod property.
	/// </summary>
	public enum WorkOrderRoutingSelectMethod
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
		/// Represents the GetByWorkOrderIdProductIdOperationSequence method.
		/// </summary>
		GetByWorkOrderIdProductIdOperationSequence,
		/// <summary>
		/// Represents the GetByLocationId method.
		/// </summary>
		GetByLocationId,
		/// <summary>
		/// Represents the GetByWorkOrderId method.
		/// </summary>
		GetByWorkOrderId
	}
	
	#endregion WorkOrderRoutingSelectMethod

	#region WorkOrderRoutingFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrderRouting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderRoutingFilter : SqlFilter<WorkOrderRoutingColumn>
	{
	}
	
	#endregion WorkOrderRoutingFilter

	#region WorkOrderRoutingExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrderRouting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderRoutingExpressionBuilder : SqlExpressionBuilder<WorkOrderRoutingColumn>
	{
	}
	
	#endregion WorkOrderRoutingExpressionBuilder	

	#region WorkOrderRoutingProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;WorkOrderRoutingChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrderRouting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderRoutingProperty : ChildEntityProperty<WorkOrderRoutingChildEntityTypes>
	{
	}
	
	#endregion WorkOrderRoutingProperty
}

