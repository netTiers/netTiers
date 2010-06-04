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
	/// Represents the DataRepository.SalesReasonProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalesReasonDataSourceDesigner))]
	public class SalesReasonDataSource : ProviderDataSource<SalesReason, SalesReasonKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesReasonDataSource class.
		/// </summary>
		public SalesReasonDataSource() : base(new SalesReasonService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalesReasonDataSourceView used by the SalesReasonDataSource.
		/// </summary>
		protected SalesReasonDataSourceView SalesReasonView
		{
			get { return ( View as SalesReasonDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalesReasonDataSource control invokes to retrieve data.
		/// </summary>
		public SalesReasonSelectMethod SelectMethod
		{
			get
			{
				SalesReasonSelectMethod selectMethod = SalesReasonSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalesReasonSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalesReasonDataSourceView class that is to be
		/// used by the SalesReasonDataSource.
		/// </summary>
		/// <returns>An instance of the SalesReasonDataSourceView class.</returns>
		protected override BaseDataSourceView<SalesReason, SalesReasonKey> GetNewDataSourceView()
		{
			return new SalesReasonDataSourceView(this, DefaultViewName);
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
	/// Supports the SalesReasonDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalesReasonDataSourceView : ProviderDataSourceView<SalesReason, SalesReasonKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesReasonDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalesReasonDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalesReasonDataSourceView(SalesReasonDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalesReasonDataSource SalesReasonOwner
		{
			get { return Owner as SalesReasonDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalesReasonSelectMethod SelectMethod
		{
			get { return SalesReasonOwner.SelectMethod; }
			set { SalesReasonOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalesReasonService SalesReasonProvider
		{
			get { return Provider as SalesReasonService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalesReason> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalesReason> results = null;
			SalesReason item;
			count = 0;
			
			System.Int32 _salesReasonId;
			System.Int32 _salesOrderId;

			switch ( SelectMethod )
			{
				case SalesReasonSelectMethod.Get:
					SalesReasonKey entityKey  = new SalesReasonKey();
					entityKey.Load(values);
					item = SalesReasonProvider.Get(entityKey);
					results = new TList<SalesReason>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesReasonSelectMethod.GetAll:
                    results = SalesReasonProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalesReasonSelectMethod.GetPaged:
					results = SalesReasonProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalesReasonSelectMethod.Find:
					if ( FilterParameters != null )
						results = SalesReasonProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalesReasonProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalesReasonSelectMethod.GetBySalesReasonId:
					_salesReasonId = ( values["SalesReasonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesReasonId"], typeof(System.Int32)) : (int)0;
					item = SalesReasonProvider.GetBySalesReasonId(_salesReasonId);
					results = new TList<SalesReason>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case SalesReasonSelectMethod.GetBySalesOrderIdFromSalesOrderHeaderSalesReason:
					_salesOrderId = ( values["SalesOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesOrderId"], typeof(System.Int32)) : (int)0;
					results = SalesReasonProvider.GetBySalesOrderIdFromSalesOrderHeaderSalesReason(_salesOrderId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == SalesReasonSelectMethod.Get || SelectMethod == SalesReasonSelectMethod.GetBySalesReasonId )
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
				SalesReason entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalesReasonProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalesReason> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalesReasonProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalesReasonDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalesReasonDataSource class.
	/// </summary>
	public class SalesReasonDataSourceDesigner : ProviderDataSourceDesigner<SalesReason, SalesReasonKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalesReasonDataSourceDesigner class.
		/// </summary>
		public SalesReasonDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesReasonSelectMethod SelectMethod
		{
			get { return ((SalesReasonDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalesReasonDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalesReasonDataSourceActionList

	/// <summary>
	/// Supports the SalesReasonDataSourceDesigner class.
	/// </summary>
	internal class SalesReasonDataSourceActionList : DesignerActionList
	{
		private SalesReasonDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalesReasonDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalesReasonDataSourceActionList(SalesReasonDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesReasonSelectMethod SelectMethod
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

	#endregion SalesReasonDataSourceActionList
	
	#endregion SalesReasonDataSourceDesigner
	
	#region SalesReasonSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalesReasonDataSource.SelectMethod property.
	/// </summary>
	public enum SalesReasonSelectMethod
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
		/// Represents the GetBySalesReasonId method.
		/// </summary>
		GetBySalesReasonId,
		/// <summary>
		/// Represents the GetBySalesOrderIdFromSalesOrderHeaderSalesReason method.
		/// </summary>
		GetBySalesOrderIdFromSalesOrderHeaderSalesReason
	}
	
	#endregion SalesReasonSelectMethod

	#region SalesReasonFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesReasonFilter : SqlFilter<SalesReasonColumn>
	{
	}
	
	#endregion SalesReasonFilter

	#region SalesReasonExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesReasonExpressionBuilder : SqlExpressionBuilder<SalesReasonColumn>
	{
	}
	
	#endregion SalesReasonExpressionBuilder	

	#region SalesReasonProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalesReasonChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesReasonProperty : ChildEntityProperty<SalesReasonChildEntityTypes>
	{
	}
	
	#endregion SalesReasonProperty
}

