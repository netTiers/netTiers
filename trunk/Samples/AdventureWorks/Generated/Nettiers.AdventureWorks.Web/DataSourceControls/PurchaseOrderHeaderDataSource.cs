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
	/// Represents the DataRepository.PurchaseOrderHeaderProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PurchaseOrderHeaderDataSourceDesigner))]
	public class PurchaseOrderHeaderDataSource : ProviderDataSource<PurchaseOrderHeader, PurchaseOrderHeaderKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderDataSource class.
		/// </summary>
		public PurchaseOrderHeaderDataSource() : base(new PurchaseOrderHeaderService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PurchaseOrderHeaderDataSourceView used by the PurchaseOrderHeaderDataSource.
		/// </summary>
		protected PurchaseOrderHeaderDataSourceView PurchaseOrderHeaderView
		{
			get { return ( View as PurchaseOrderHeaderDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PurchaseOrderHeaderDataSource control invokes to retrieve data.
		/// </summary>
		public PurchaseOrderHeaderSelectMethod SelectMethod
		{
			get
			{
				PurchaseOrderHeaderSelectMethod selectMethod = PurchaseOrderHeaderSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PurchaseOrderHeaderSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PurchaseOrderHeaderDataSourceView class that is to be
		/// used by the PurchaseOrderHeaderDataSource.
		/// </summary>
		/// <returns>An instance of the PurchaseOrderHeaderDataSourceView class.</returns>
		protected override BaseDataSourceView<PurchaseOrderHeader, PurchaseOrderHeaderKey> GetNewDataSourceView()
		{
			return new PurchaseOrderHeaderDataSourceView(this, DefaultViewName);
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
	/// Supports the PurchaseOrderHeaderDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PurchaseOrderHeaderDataSourceView : ProviderDataSourceView<PurchaseOrderHeader, PurchaseOrderHeaderKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PurchaseOrderHeaderDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PurchaseOrderHeaderDataSourceView(PurchaseOrderHeaderDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PurchaseOrderHeaderDataSource PurchaseOrderHeaderOwner
		{
			get { return Owner as PurchaseOrderHeaderDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PurchaseOrderHeaderSelectMethod SelectMethod
		{
			get { return PurchaseOrderHeaderOwner.SelectMethod; }
			set { PurchaseOrderHeaderOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PurchaseOrderHeaderService PurchaseOrderHeaderProvider
		{
			get { return Provider as PurchaseOrderHeaderService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<PurchaseOrderHeader> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<PurchaseOrderHeader> results = null;
			PurchaseOrderHeader item;
			count = 0;
			
			System.Int32 _employeeId;
			System.Int32 _vendorId;
			System.Int32 _purchaseOrderId;
			System.Int32 _shipMethodId;

			switch ( SelectMethod )
			{
				case PurchaseOrderHeaderSelectMethod.Get:
					PurchaseOrderHeaderKey entityKey  = new PurchaseOrderHeaderKey();
					entityKey.Load(values);
					item = PurchaseOrderHeaderProvider.Get(entityKey);
					results = new TList<PurchaseOrderHeader>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PurchaseOrderHeaderSelectMethod.GetAll:
                    results = PurchaseOrderHeaderProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case PurchaseOrderHeaderSelectMethod.GetPaged:
					results = PurchaseOrderHeaderProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PurchaseOrderHeaderSelectMethod.Find:
					if ( FilterParameters != null )
						results = PurchaseOrderHeaderProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PurchaseOrderHeaderProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PurchaseOrderHeaderSelectMethod.GetByPurchaseOrderId:
					_purchaseOrderId = ( values["PurchaseOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["PurchaseOrderId"], typeof(System.Int32)) : (int)0;
					item = PurchaseOrderHeaderProvider.GetByPurchaseOrderId(_purchaseOrderId);
					results = new TList<PurchaseOrderHeader>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case PurchaseOrderHeaderSelectMethod.GetByEmployeeId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					results = PurchaseOrderHeaderProvider.GetByEmployeeId(_employeeId, this.StartIndex, this.PageSize, out count);
					break;
				case PurchaseOrderHeaderSelectMethod.GetByVendorId:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					results = PurchaseOrderHeaderProvider.GetByVendorId(_vendorId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case PurchaseOrderHeaderSelectMethod.GetByShipMethodId:
					_shipMethodId = ( values["ShipMethodId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ShipMethodId"], typeof(System.Int32)) : (int)0;
					results = PurchaseOrderHeaderProvider.GetByShipMethodId(_shipMethodId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == PurchaseOrderHeaderSelectMethod.Get || SelectMethod == PurchaseOrderHeaderSelectMethod.GetByPurchaseOrderId )
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
				PurchaseOrderHeader entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					PurchaseOrderHeaderProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<PurchaseOrderHeader> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			PurchaseOrderHeaderProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PurchaseOrderHeaderDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PurchaseOrderHeaderDataSource class.
	/// </summary>
	public class PurchaseOrderHeaderDataSourceDesigner : ProviderDataSourceDesigner<PurchaseOrderHeader, PurchaseOrderHeaderKey>
	{
		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderDataSourceDesigner class.
		/// </summary>
		public PurchaseOrderHeaderDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PurchaseOrderHeaderSelectMethod SelectMethod
		{
			get { return ((PurchaseOrderHeaderDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PurchaseOrderHeaderDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PurchaseOrderHeaderDataSourceActionList

	/// <summary>
	/// Supports the PurchaseOrderHeaderDataSourceDesigner class.
	/// </summary>
	internal class PurchaseOrderHeaderDataSourceActionList : DesignerActionList
	{
		private PurchaseOrderHeaderDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PurchaseOrderHeaderDataSourceActionList(PurchaseOrderHeaderDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PurchaseOrderHeaderSelectMethod SelectMethod
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

	#endregion PurchaseOrderHeaderDataSourceActionList
	
	#endregion PurchaseOrderHeaderDataSourceDesigner
	
	#region PurchaseOrderHeaderSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PurchaseOrderHeaderDataSource.SelectMethod property.
	/// </summary>
	public enum PurchaseOrderHeaderSelectMethod
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
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId,
		/// <summary>
		/// Represents the GetByVendorId method.
		/// </summary>
		GetByVendorId,
		/// <summary>
		/// Represents the GetByPurchaseOrderId method.
		/// </summary>
		GetByPurchaseOrderId,
		/// <summary>
		/// Represents the GetByShipMethodId method.
		/// </summary>
		GetByShipMethodId
	}
	
	#endregion PurchaseOrderHeaderSelectMethod

	#region PurchaseOrderHeaderFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderHeaderFilter : SqlFilter<PurchaseOrderHeaderColumn>
	{
	}
	
	#endregion PurchaseOrderHeaderFilter

	#region PurchaseOrderHeaderExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderHeaderExpressionBuilder : SqlExpressionBuilder<PurchaseOrderHeaderColumn>
	{
	}
	
	#endregion PurchaseOrderHeaderExpressionBuilder	

	#region PurchaseOrderHeaderProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PurchaseOrderHeaderChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderHeaderProperty : ChildEntityProperty<PurchaseOrderHeaderChildEntityTypes>
	{
	}
	
	#endregion PurchaseOrderHeaderProperty
}

