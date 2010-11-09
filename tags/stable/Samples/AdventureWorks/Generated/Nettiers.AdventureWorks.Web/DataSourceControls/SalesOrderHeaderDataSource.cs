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
	/// Represents the DataRepository.SalesOrderHeaderProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalesOrderHeaderDataSourceDesigner))]
	public class SalesOrderHeaderDataSource : ProviderDataSource<SalesOrderHeader, SalesOrderHeaderKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderDataSource class.
		/// </summary>
		public SalesOrderHeaderDataSource() : base(new SalesOrderHeaderService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalesOrderHeaderDataSourceView used by the SalesOrderHeaderDataSource.
		/// </summary>
		protected SalesOrderHeaderDataSourceView SalesOrderHeaderView
		{
			get { return ( View as SalesOrderHeaderDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalesOrderHeaderDataSource control invokes to retrieve data.
		/// </summary>
		public SalesOrderHeaderSelectMethod SelectMethod
		{
			get
			{
				SalesOrderHeaderSelectMethod selectMethod = SalesOrderHeaderSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalesOrderHeaderSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalesOrderHeaderDataSourceView class that is to be
		/// used by the SalesOrderHeaderDataSource.
		/// </summary>
		/// <returns>An instance of the SalesOrderHeaderDataSourceView class.</returns>
		protected override BaseDataSourceView<SalesOrderHeader, SalesOrderHeaderKey> GetNewDataSourceView()
		{
			return new SalesOrderHeaderDataSourceView(this, DefaultViewName);
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
	/// Supports the SalesOrderHeaderDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalesOrderHeaderDataSourceView : ProviderDataSourceView<SalesOrderHeader, SalesOrderHeaderKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalesOrderHeaderDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalesOrderHeaderDataSourceView(SalesOrderHeaderDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalesOrderHeaderDataSource SalesOrderHeaderOwner
		{
			get { return Owner as SalesOrderHeaderDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalesOrderHeaderSelectMethod SelectMethod
		{
			get { return SalesOrderHeaderOwner.SelectMethod; }
			set { SalesOrderHeaderOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalesOrderHeaderService SalesOrderHeaderProvider
		{
			get { return Provider as SalesOrderHeaderService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalesOrderHeader> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalesOrderHeader> results = null;
			SalesOrderHeader item;
			count = 0;
			
			System.Guid _rowguid;
			System.String _salesOrderNumber;
			System.Int32 _customerId;
			System.Int32? _salesPersonId_nullable;
			System.Int32 _salesOrderId;
			System.Int32 _billToAddressId;
			System.Int32 _shipToAddressId;
			System.Int32 _contactId;
			System.Int32? _creditCardId_nullable;
			System.Int32? _currencyRateId_nullable;
			System.Int32? _territoryId_nullable;
			System.Int32 _shipMethodId;
			System.Int32 _salesReasonId;

			switch ( SelectMethod )
			{
				case SalesOrderHeaderSelectMethod.Get:
					SalesOrderHeaderKey entityKey  = new SalesOrderHeaderKey();
					entityKey.Load(values);
					item = SalesOrderHeaderProvider.Get(entityKey);
					results = new TList<SalesOrderHeader>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesOrderHeaderSelectMethod.GetAll:
                    results = SalesOrderHeaderProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalesOrderHeaderSelectMethod.GetPaged:
					results = SalesOrderHeaderProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalesOrderHeaderSelectMethod.Find:
					if ( FilterParameters != null )
						results = SalesOrderHeaderProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalesOrderHeaderProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalesOrderHeaderSelectMethod.GetBySalesOrderId:
					_salesOrderId = ( values["SalesOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesOrderId"], typeof(System.Int32)) : (int)0;
					item = SalesOrderHeaderProvider.GetBySalesOrderId(_salesOrderId);
					results = new TList<SalesOrderHeader>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SalesOrderHeaderSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = SalesOrderHeaderProvider.GetByRowguid(_rowguid);
					results = new TList<SalesOrderHeader>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesOrderHeaderSelectMethod.GetBySalesOrderNumber:
					_salesOrderNumber = ( values["SalesOrderNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["SalesOrderNumber"], typeof(System.String)) : string.Empty;
					item = SalesOrderHeaderProvider.GetBySalesOrderNumber(_salesOrderNumber);
					results = new TList<SalesOrderHeader>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesOrderHeaderSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderHeaderProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderHeaderSelectMethod.GetBySalesPersonId:
					_salesPersonId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32?));
					results = SalesOrderHeaderProvider.GetBySalesPersonId(_salesPersonId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case SalesOrderHeaderSelectMethod.GetByBillToAddressId:
					_billToAddressId = ( values["BillToAddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["BillToAddressId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderHeaderProvider.GetByBillToAddressId(_billToAddressId, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderHeaderSelectMethod.GetByShipToAddressId:
					_shipToAddressId = ( values["ShipToAddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ShipToAddressId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderHeaderProvider.GetByShipToAddressId(_shipToAddressId, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderHeaderSelectMethod.GetByContactId:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderHeaderProvider.GetByContactId(_contactId, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderHeaderSelectMethod.GetByCreditCardId:
					_creditCardId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CreditCardId"], typeof(System.Int32?));
					results = SalesOrderHeaderProvider.GetByCreditCardId(_creditCardId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderHeaderSelectMethod.GetByCurrencyRateId:
					_currencyRateId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CurrencyRateId"], typeof(System.Int32?));
					results = SalesOrderHeaderProvider.GetByCurrencyRateId(_currencyRateId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderHeaderSelectMethod.GetByTerritoryId:
					_territoryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["TerritoryId"], typeof(System.Int32?));
					results = SalesOrderHeaderProvider.GetByTerritoryId(_territoryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderHeaderSelectMethod.GetByShipMethodId:
					_shipMethodId = ( values["ShipMethodId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ShipMethodId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderHeaderProvider.GetByShipMethodId(_shipMethodId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case SalesOrderHeaderSelectMethod.GetBySalesReasonIdFromSalesOrderHeaderSalesReason:
					_salesReasonId = ( values["SalesReasonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesReasonId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderHeaderProvider.GetBySalesReasonIdFromSalesOrderHeaderSalesReason(_salesReasonId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SalesOrderHeaderSelectMethod.Get || SelectMethod == SalesOrderHeaderSelectMethod.GetBySalesOrderId )
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
				SalesOrderHeader entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalesOrderHeaderProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalesOrderHeader> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalesOrderHeaderProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalesOrderHeaderDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalesOrderHeaderDataSource class.
	/// </summary>
	public class SalesOrderHeaderDataSourceDesigner : ProviderDataSourceDesigner<SalesOrderHeader, SalesOrderHeaderKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderDataSourceDesigner class.
		/// </summary>
		public SalesOrderHeaderDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesOrderHeaderSelectMethod SelectMethod
		{
			get { return ((SalesOrderHeaderDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalesOrderHeaderDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalesOrderHeaderDataSourceActionList

	/// <summary>
	/// Supports the SalesOrderHeaderDataSourceDesigner class.
	/// </summary>
	internal class SalesOrderHeaderDataSourceActionList : DesignerActionList
	{
		private SalesOrderHeaderDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalesOrderHeaderDataSourceActionList(SalesOrderHeaderDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesOrderHeaderSelectMethod SelectMethod
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

	#endregion SalesOrderHeaderDataSourceActionList
	
	#endregion SalesOrderHeaderDataSourceDesigner
	
	#region SalesOrderHeaderSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalesOrderHeaderDataSource.SelectMethod property.
	/// </summary>
	public enum SalesOrderHeaderSelectMethod
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
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetBySalesOrderNumber method.
		/// </summary>
		GetBySalesOrderNumber,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId,
		/// <summary>
		/// Represents the GetBySalesOrderId method.
		/// </summary>
		GetBySalesOrderId,
		/// <summary>
		/// Represents the GetByBillToAddressId method.
		/// </summary>
		GetByBillToAddressId,
		/// <summary>
		/// Represents the GetByShipToAddressId method.
		/// </summary>
		GetByShipToAddressId,
		/// <summary>
		/// Represents the GetByContactId method.
		/// </summary>
		GetByContactId,
		/// <summary>
		/// Represents the GetByCreditCardId method.
		/// </summary>
		GetByCreditCardId,
		/// <summary>
		/// Represents the GetByCurrencyRateId method.
		/// </summary>
		GetByCurrencyRateId,
		/// <summary>
		/// Represents the GetByTerritoryId method.
		/// </summary>
		GetByTerritoryId,
		/// <summary>
		/// Represents the GetByShipMethodId method.
		/// </summary>
		GetByShipMethodId,
		/// <summary>
		/// Represents the GetBySalesReasonIdFromSalesOrderHeaderSalesReason method.
		/// </summary>
		GetBySalesReasonIdFromSalesOrderHeaderSalesReason
	}
	
	#endregion SalesOrderHeaderSelectMethod

	#region SalesOrderHeaderFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderFilter : SqlFilter<SalesOrderHeaderColumn>
	{
	}
	
	#endregion SalesOrderHeaderFilter

	#region SalesOrderHeaderExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderExpressionBuilder : SqlExpressionBuilder<SalesOrderHeaderColumn>
	{
	}
	
	#endregion SalesOrderHeaderExpressionBuilder	

	#region SalesOrderHeaderProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalesOrderHeaderChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderProperty : ChildEntityProperty<SalesOrderHeaderChildEntityTypes>
	{
	}
	
	#endregion SalesOrderHeaderProperty
}

