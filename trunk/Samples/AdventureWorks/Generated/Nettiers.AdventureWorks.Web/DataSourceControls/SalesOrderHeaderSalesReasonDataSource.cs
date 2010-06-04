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
	/// Represents the DataRepository.SalesOrderHeaderSalesReasonProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalesOrderHeaderSalesReasonDataSourceDesigner))]
	public class SalesOrderHeaderSalesReasonDataSource : ProviderDataSource<SalesOrderHeaderSalesReason, SalesOrderHeaderSalesReasonKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonDataSource class.
		/// </summary>
		public SalesOrderHeaderSalesReasonDataSource() : base(new SalesOrderHeaderSalesReasonService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalesOrderHeaderSalesReasonDataSourceView used by the SalesOrderHeaderSalesReasonDataSource.
		/// </summary>
		protected SalesOrderHeaderSalesReasonDataSourceView SalesOrderHeaderSalesReasonView
		{
			get { return ( View as SalesOrderHeaderSalesReasonDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalesOrderHeaderSalesReasonDataSource control invokes to retrieve data.
		/// </summary>
		public SalesOrderHeaderSalesReasonSelectMethod SelectMethod
		{
			get
			{
				SalesOrderHeaderSalesReasonSelectMethod selectMethod = SalesOrderHeaderSalesReasonSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalesOrderHeaderSalesReasonSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalesOrderHeaderSalesReasonDataSourceView class that is to be
		/// used by the SalesOrderHeaderSalesReasonDataSource.
		/// </summary>
		/// <returns>An instance of the SalesOrderHeaderSalesReasonDataSourceView class.</returns>
		protected override BaseDataSourceView<SalesOrderHeaderSalesReason, SalesOrderHeaderSalesReasonKey> GetNewDataSourceView()
		{
			return new SalesOrderHeaderSalesReasonDataSourceView(this, DefaultViewName);
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
	/// Supports the SalesOrderHeaderSalesReasonDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalesOrderHeaderSalesReasonDataSourceView : ProviderDataSourceView<SalesOrderHeaderSalesReason, SalesOrderHeaderSalesReasonKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalesOrderHeaderSalesReasonDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalesOrderHeaderSalesReasonDataSourceView(SalesOrderHeaderSalesReasonDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalesOrderHeaderSalesReasonDataSource SalesOrderHeaderSalesReasonOwner
		{
			get { return Owner as SalesOrderHeaderSalesReasonDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalesOrderHeaderSalesReasonSelectMethod SelectMethod
		{
			get { return SalesOrderHeaderSalesReasonOwner.SelectMethod; }
			set { SalesOrderHeaderSalesReasonOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalesOrderHeaderSalesReasonService SalesOrderHeaderSalesReasonProvider
		{
			get { return Provider as SalesOrderHeaderSalesReasonService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalesOrderHeaderSalesReason> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalesOrderHeaderSalesReason> results = null;
			SalesOrderHeaderSalesReason item;
			count = 0;
			
			System.Int32 _salesOrderId;
			System.Int32 _salesReasonId;

			switch ( SelectMethod )
			{
				case SalesOrderHeaderSalesReasonSelectMethod.Get:
					SalesOrderHeaderSalesReasonKey entityKey  = new SalesOrderHeaderSalesReasonKey();
					entityKey.Load(values);
					item = SalesOrderHeaderSalesReasonProvider.Get(entityKey);
					results = new TList<SalesOrderHeaderSalesReason>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesOrderHeaderSalesReasonSelectMethod.GetAll:
                    results = SalesOrderHeaderSalesReasonProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalesOrderHeaderSalesReasonSelectMethod.GetPaged:
					results = SalesOrderHeaderSalesReasonProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalesOrderHeaderSalesReasonSelectMethod.Find:
					if ( FilterParameters != null )
						results = SalesOrderHeaderSalesReasonProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalesOrderHeaderSalesReasonProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalesOrderHeaderSalesReasonSelectMethod.GetBySalesOrderIdSalesReasonId:
					_salesOrderId = ( values["SalesOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesOrderId"], typeof(System.Int32)) : (int)0;
					_salesReasonId = ( values["SalesReasonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesReasonId"], typeof(System.Int32)) : (int)0;
					item = SalesOrderHeaderSalesReasonProvider.GetBySalesOrderIdSalesReasonId(_salesOrderId, _salesReasonId);
					results = new TList<SalesOrderHeaderSalesReason>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case SalesOrderHeaderSalesReasonSelectMethod.GetBySalesOrderId:
					_salesOrderId = ( values["SalesOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesOrderId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderHeaderSalesReasonProvider.GetBySalesOrderId(_salesOrderId, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderHeaderSalesReasonSelectMethod.GetBySalesReasonId:
					_salesReasonId = ( values["SalesReasonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesReasonId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderHeaderSalesReasonProvider.GetBySalesReasonId(_salesReasonId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SalesOrderHeaderSalesReasonSelectMethod.Get || SelectMethod == SalesOrderHeaderSalesReasonSelectMethod.GetBySalesOrderIdSalesReasonId )
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
				SalesOrderHeaderSalesReason entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalesOrderHeaderSalesReasonProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalesOrderHeaderSalesReason> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalesOrderHeaderSalesReasonProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalesOrderHeaderSalesReasonDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalesOrderHeaderSalesReasonDataSource class.
	/// </summary>
	public class SalesOrderHeaderSalesReasonDataSourceDesigner : ProviderDataSourceDesigner<SalesOrderHeaderSalesReason, SalesOrderHeaderSalesReasonKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonDataSourceDesigner class.
		/// </summary>
		public SalesOrderHeaderSalesReasonDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesOrderHeaderSalesReasonSelectMethod SelectMethod
		{
			get { return ((SalesOrderHeaderSalesReasonDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalesOrderHeaderSalesReasonDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalesOrderHeaderSalesReasonDataSourceActionList

	/// <summary>
	/// Supports the SalesOrderHeaderSalesReasonDataSourceDesigner class.
	/// </summary>
	internal class SalesOrderHeaderSalesReasonDataSourceActionList : DesignerActionList
	{
		private SalesOrderHeaderSalesReasonDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalesOrderHeaderSalesReasonDataSourceActionList(SalesOrderHeaderSalesReasonDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesOrderHeaderSalesReasonSelectMethod SelectMethod
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

	#endregion SalesOrderHeaderSalesReasonDataSourceActionList
	
	#endregion SalesOrderHeaderSalesReasonDataSourceDesigner
	
	#region SalesOrderHeaderSalesReasonSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalesOrderHeaderSalesReasonDataSource.SelectMethod property.
	/// </summary>
	public enum SalesOrderHeaderSalesReasonSelectMethod
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
		/// Represents the GetBySalesOrderIdSalesReasonId method.
		/// </summary>
		GetBySalesOrderIdSalesReasonId,
		/// <summary>
		/// Represents the GetBySalesOrderId method.
		/// </summary>
		GetBySalesOrderId,
		/// <summary>
		/// Represents the GetBySalesReasonId method.
		/// </summary>
		GetBySalesReasonId
	}
	
	#endregion SalesOrderHeaderSalesReasonSelectMethod

	#region SalesOrderHeaderSalesReasonFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeaderSalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderSalesReasonFilter : SqlFilter<SalesOrderHeaderSalesReasonColumn>
	{
	}
	
	#endregion SalesOrderHeaderSalesReasonFilter

	#region SalesOrderHeaderSalesReasonExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeaderSalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderSalesReasonExpressionBuilder : SqlExpressionBuilder<SalesOrderHeaderSalesReasonColumn>
	{
	}
	
	#endregion SalesOrderHeaderSalesReasonExpressionBuilder	

	#region SalesOrderHeaderSalesReasonProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalesOrderHeaderSalesReasonChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeaderSalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderSalesReasonProperty : ChildEntityProperty<SalesOrderHeaderSalesReasonChildEntityTypes>
	{
	}
	
	#endregion SalesOrderHeaderSalesReasonProperty
}

