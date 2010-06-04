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
	/// Represents the DataRepository.CustomerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomerDataSourceDesigner))]
	public class CustomerDataSource : ProviderDataSource<Customer, CustomerKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDataSource class.
		/// </summary>
		public CustomerDataSource() : base(new CustomerService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomerDataSourceView used by the CustomerDataSource.
		/// </summary>
		protected CustomerDataSourceView CustomerView
		{
			get { return ( View as CustomerDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomerDataSource control invokes to retrieve data.
		/// </summary>
		public CustomerSelectMethod SelectMethod
		{
			get
			{
				CustomerSelectMethod selectMethod = CustomerSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomerSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomerDataSourceView class that is to be
		/// used by the CustomerDataSource.
		/// </summary>
		/// <returns>An instance of the CustomerDataSourceView class.</returns>
		protected override BaseDataSourceView<Customer, CustomerKey> GetNewDataSourceView()
		{
			return new CustomerDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomerDataSourceView : ProviderDataSourceView<Customer, CustomerKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomerDataSourceView(CustomerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomerDataSource CustomerOwner
		{
			get { return Owner as CustomerDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomerSelectMethod SelectMethod
		{
			get { return CustomerOwner.SelectMethod; }
			set { CustomerOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomerService CustomerProvider
		{
			get { return Provider as CustomerService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Customer> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Customer> results = null;
			Customer item;
			count = 0;
			
			System.String _accountNumber;
			System.Guid _rowguid;
			System.Int32? _territoryId_nullable;
			System.Int32 _customerId;
			System.Int32 _addressId;

			switch ( SelectMethod )
			{
				case CustomerSelectMethod.Get:
					CustomerKey entityKey  = new CustomerKey();
					entityKey.Load(values);
					item = CustomerProvider.Get(entityKey);
					results = new TList<Customer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerSelectMethod.GetAll:
                    results = CustomerProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CustomerSelectMethod.GetPaged:
					results = CustomerProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomerSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomerProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomerProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomerSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					item = CustomerProvider.GetByCustomerId(_customerId);
					results = new TList<Customer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CustomerSelectMethod.GetByAccountNumber:
					_accountNumber = ( values["AccountNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["AccountNumber"], typeof(System.String)) : string.Empty;
					item = CustomerProvider.GetByAccountNumber(_accountNumber);
					results = new TList<Customer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = CustomerProvider.GetByRowguid(_rowguid);
					results = new TList<Customer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerSelectMethod.GetByTerritoryId:
					_territoryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["TerritoryId"], typeof(System.Int32?));
					results = CustomerProvider.GetByTerritoryId(_territoryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				case CustomerSelectMethod.GetByAddressIdFromCustomerAddress:
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					results = CustomerProvider.GetByAddressIdFromCustomerAddress(_addressId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomerSelectMethod.Get || SelectMethod == CustomerSelectMethod.GetByCustomerId )
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
				Customer entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CustomerProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Customer> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CustomerProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomerDataSource class.
	/// </summary>
	public class CustomerDataSourceDesigner : ProviderDataSourceDesigner<Customer, CustomerKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomerDataSourceDesigner class.
		/// </summary>
		public CustomerDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerSelectMethod SelectMethod
		{
			get { return ((CustomerDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomerDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomerDataSourceActionList

	/// <summary>
	/// Supports the CustomerDataSourceDesigner class.
	/// </summary>
	internal class CustomerDataSourceActionList : DesignerActionList
	{
		private CustomerDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomerDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomerDataSourceActionList(CustomerDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerSelectMethod SelectMethod
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

	#endregion CustomerDataSourceActionList
	
	#endregion CustomerDataSourceDesigner
	
	#region CustomerSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomerDataSource.SelectMethod property.
	/// </summary>
	public enum CustomerSelectMethod
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
		/// Represents the GetByAccountNumber method.
		/// </summary>
		GetByAccountNumber,
		/// <summary>
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByTerritoryId method.
		/// </summary>
		GetByTerritoryId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByAddressIdFromCustomerAddress method.
		/// </summary>
		GetByAddressIdFromCustomerAddress
	}
	
	#endregion CustomerSelectMethod

	#region CustomerFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerFilter : SqlFilter<CustomerColumn>
	{
	}
	
	#endregion CustomerFilter

	#region CustomerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerExpressionBuilder : SqlExpressionBuilder<CustomerColumn>
	{
	}
	
	#endregion CustomerExpressionBuilder	

	#region CustomerProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomerChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerProperty : ChildEntityProperty<CustomerChildEntityTypes>
	{
	}
	
	#endregion CustomerProperty
}

