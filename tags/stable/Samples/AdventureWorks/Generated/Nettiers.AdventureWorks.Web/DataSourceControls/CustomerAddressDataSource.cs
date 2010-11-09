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
	/// Represents the DataRepository.CustomerAddressProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomerAddressDataSourceDesigner))]
	public class CustomerAddressDataSource : ProviderDataSource<CustomerAddress, CustomerAddressKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAddressDataSource class.
		/// </summary>
		public CustomerAddressDataSource() : base(new CustomerAddressService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomerAddressDataSourceView used by the CustomerAddressDataSource.
		/// </summary>
		protected CustomerAddressDataSourceView CustomerAddressView
		{
			get { return ( View as CustomerAddressDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomerAddressDataSource control invokes to retrieve data.
		/// </summary>
		public CustomerAddressSelectMethod SelectMethod
		{
			get
			{
				CustomerAddressSelectMethod selectMethod = CustomerAddressSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomerAddressSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomerAddressDataSourceView class that is to be
		/// used by the CustomerAddressDataSource.
		/// </summary>
		/// <returns>An instance of the CustomerAddressDataSourceView class.</returns>
		protected override BaseDataSourceView<CustomerAddress, CustomerAddressKey> GetNewDataSourceView()
		{
			return new CustomerAddressDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomerAddressDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomerAddressDataSourceView : ProviderDataSourceView<CustomerAddress, CustomerAddressKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAddressDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomerAddressDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomerAddressDataSourceView(CustomerAddressDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomerAddressDataSource CustomerAddressOwner
		{
			get { return Owner as CustomerAddressDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomerAddressSelectMethod SelectMethod
		{
			get { return CustomerAddressOwner.SelectMethod; }
			set { CustomerAddressOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomerAddressService CustomerAddressProvider
		{
			get { return Provider as CustomerAddressService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CustomerAddress> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CustomerAddress> results = null;
			CustomerAddress item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _customerId;
			System.Int32 _addressId;
			System.Int32 _addressTypeId;

			switch ( SelectMethod )
			{
				case CustomerAddressSelectMethod.Get:
					CustomerAddressKey entityKey  = new CustomerAddressKey();
					entityKey.Load(values);
					item = CustomerAddressProvider.Get(entityKey);
					results = new TList<CustomerAddress>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerAddressSelectMethod.GetAll:
                    results = CustomerAddressProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CustomerAddressSelectMethod.GetPaged:
					results = CustomerAddressProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomerAddressSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomerAddressProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomerAddressProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomerAddressSelectMethod.GetByCustomerIdAddressId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					item = CustomerAddressProvider.GetByCustomerIdAddressId(_customerId, _addressId);
					results = new TList<CustomerAddress>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CustomerAddressSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = CustomerAddressProvider.GetByRowguid(_rowguid);
					results = new TList<CustomerAddress>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case CustomerAddressSelectMethod.GetByAddressId:
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					results = CustomerAddressProvider.GetByAddressId(_addressId, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerAddressSelectMethod.GetByAddressTypeId:
					_addressTypeId = ( values["AddressTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressTypeId"], typeof(System.Int32)) : (int)0;
					results = CustomerAddressProvider.GetByAddressTypeId(_addressTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerAddressSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = CustomerAddressProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomerAddressSelectMethod.Get || SelectMethod == CustomerAddressSelectMethod.GetByCustomerIdAddressId )
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
				CustomerAddress entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CustomerAddressProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CustomerAddress> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CustomerAddressProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomerAddressDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomerAddressDataSource class.
	/// </summary>
	public class CustomerAddressDataSourceDesigner : ProviderDataSourceDesigner<CustomerAddress, CustomerAddressKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomerAddressDataSourceDesigner class.
		/// </summary>
		public CustomerAddressDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerAddressSelectMethod SelectMethod
		{
			get { return ((CustomerAddressDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomerAddressDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomerAddressDataSourceActionList

	/// <summary>
	/// Supports the CustomerAddressDataSourceDesigner class.
	/// </summary>
	internal class CustomerAddressDataSourceActionList : DesignerActionList
	{
		private CustomerAddressDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomerAddressDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomerAddressDataSourceActionList(CustomerAddressDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerAddressSelectMethod SelectMethod
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

	#endregion CustomerAddressDataSourceActionList
	
	#endregion CustomerAddressDataSourceDesigner
	
	#region CustomerAddressSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomerAddressDataSource.SelectMethod property.
	/// </summary>
	public enum CustomerAddressSelectMethod
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
		/// Represents the GetByCustomerIdAddressId method.
		/// </summary>
		GetByCustomerIdAddressId,
		/// <summary>
		/// Represents the GetByAddressId method.
		/// </summary>
		GetByAddressId,
		/// <summary>
		/// Represents the GetByAddressTypeId method.
		/// </summary>
		GetByAddressTypeId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId
	}
	
	#endregion CustomerAddressSelectMethod

	#region CustomerAddressFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAddressFilter : SqlFilter<CustomerAddressColumn>
	{
	}
	
	#endregion CustomerAddressFilter

	#region CustomerAddressExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAddressExpressionBuilder : SqlExpressionBuilder<CustomerAddressColumn>
	{
	}
	
	#endregion CustomerAddressExpressionBuilder	

	#region CustomerAddressProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomerAddressChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAddressProperty : ChildEntityProperty<CustomerAddressChildEntityTypes>
	{
	}
	
	#endregion CustomerAddressProperty
}

