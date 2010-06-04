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
	/// Represents the DataRepository.AddressProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AddressDataSourceDesigner))]
	public class AddressDataSource : ProviderDataSource<Address, AddressKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressDataSource class.
		/// </summary>
		public AddressDataSource() : base(new AddressService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AddressDataSourceView used by the AddressDataSource.
		/// </summary>
		protected AddressDataSourceView AddressView
		{
			get { return ( View as AddressDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AddressDataSource control invokes to retrieve data.
		/// </summary>
		public AddressSelectMethod SelectMethod
		{
			get
			{
				AddressSelectMethod selectMethod = AddressSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AddressSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AddressDataSourceView class that is to be
		/// used by the AddressDataSource.
		/// </summary>
		/// <returns>An instance of the AddressDataSourceView class.</returns>
		protected override BaseDataSourceView<Address, AddressKey> GetNewDataSourceView()
		{
			return new AddressDataSourceView(this, DefaultViewName);
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
	/// Supports the AddressDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AddressDataSourceView : ProviderDataSourceView<Address, AddressKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AddressDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AddressDataSourceView(AddressDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AddressDataSource AddressOwner
		{
			get { return Owner as AddressDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AddressSelectMethod SelectMethod
		{
			get { return AddressOwner.SelectMethod; }
			set { AddressOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AddressService AddressProvider
		{
			get { return Provider as AddressService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Address> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Address> results = null;
			Address item;
			count = 0;
			
			System.Guid _rowguid;
			System.String _addressLine1;
			System.String _addressLine2_nullable;
			System.String _city;
			System.Int32 _stateProvinceId;
			System.String _postalCode;
			System.Int32 _addressId;
			System.Int32 _customerId;
			System.Int32 _employeeId;
			System.Int32 _vendorId;

			switch ( SelectMethod )
			{
				case AddressSelectMethod.Get:
					AddressKey entityKey  = new AddressKey();
					entityKey.Load(values);
					item = AddressProvider.Get(entityKey);
					results = new TList<Address>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AddressSelectMethod.GetAll:
                    results = AddressProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AddressSelectMethod.GetPaged:
					results = AddressProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AddressSelectMethod.Find:
					if ( FilterParameters != null )
						results = AddressProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AddressProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AddressSelectMethod.GetByAddressId:
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					item = AddressProvider.GetByAddressId(_addressId);
					results = new TList<Address>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AddressSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = AddressProvider.GetByRowguid(_rowguid);
					results = new TList<Address>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AddressSelectMethod.GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode:
					_addressLine1 = ( values["AddressLine1"] != null ) ? (System.String) EntityUtil.ChangeType(values["AddressLine1"], typeof(System.String)) : string.Empty;
					_addressLine2_nullable = (System.String) EntityUtil.ChangeType(values["AddressLine2"], typeof(System.String));
					_city = ( values["City"] != null ) ? (System.String) EntityUtil.ChangeType(values["City"], typeof(System.String)) : string.Empty;
					_stateProvinceId = ( values["StateProvinceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StateProvinceId"], typeof(System.Int32)) : (int)0;
					_postalCode = ( values["PostalCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["PostalCode"], typeof(System.String)) : string.Empty;
					item = AddressProvider.GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(_addressLine1, _addressLine2_nullable, _city, _stateProvinceId, _postalCode);
					results = new TList<Address>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AddressSelectMethod.GetByStateProvinceId:
					_stateProvinceId = ( values["StateProvinceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StateProvinceId"], typeof(System.Int32)) : (int)0;
					results = AddressProvider.GetByStateProvinceId(_stateProvinceId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				case AddressSelectMethod.GetByCustomerIdFromCustomerAddress:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = AddressProvider.GetByCustomerIdFromCustomerAddress(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case AddressSelectMethod.GetByEmployeeIdFromEmployeeAddress:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					results = AddressProvider.GetByEmployeeIdFromEmployeeAddress(_employeeId, this.StartIndex, this.PageSize, out count);
					break;
				case AddressSelectMethod.GetByVendorIdFromVendorAddress:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					results = AddressProvider.GetByVendorIdFromVendorAddress(_vendorId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AddressSelectMethod.Get || SelectMethod == AddressSelectMethod.GetByAddressId )
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
				Address entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AddressProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Address> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AddressProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AddressDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AddressDataSource class.
	/// </summary>
	public class AddressDataSourceDesigner : ProviderDataSourceDesigner<Address, AddressKey>
	{
		/// <summary>
		/// Initializes a new instance of the AddressDataSourceDesigner class.
		/// </summary>
		public AddressDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AddressSelectMethod SelectMethod
		{
			get { return ((AddressDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AddressDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AddressDataSourceActionList

	/// <summary>
	/// Supports the AddressDataSourceDesigner class.
	/// </summary>
	internal class AddressDataSourceActionList : DesignerActionList
	{
		private AddressDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AddressDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AddressDataSourceActionList(AddressDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AddressSelectMethod SelectMethod
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

	#endregion AddressDataSourceActionList
	
	#endregion AddressDataSourceDesigner
	
	#region AddressSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AddressDataSource.SelectMethod property.
	/// </summary>
	public enum AddressSelectMethod
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
		/// Represents the GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode method.
		/// </summary>
		GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode,
		/// <summary>
		/// Represents the GetByStateProvinceId method.
		/// </summary>
		GetByStateProvinceId,
		/// <summary>
		/// Represents the GetByAddressId method.
		/// </summary>
		GetByAddressId,
		/// <summary>
		/// Represents the GetByCustomerIdFromCustomerAddress method.
		/// </summary>
		GetByCustomerIdFromCustomerAddress,
		/// <summary>
		/// Represents the GetByEmployeeIdFromEmployeeAddress method.
		/// </summary>
		GetByEmployeeIdFromEmployeeAddress,
		/// <summary>
		/// Represents the GetByVendorIdFromVendorAddress method.
		/// </summary>
		GetByVendorIdFromVendorAddress
	}
	
	#endregion AddressSelectMethod

	#region AddressFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressFilter : SqlFilter<AddressColumn>
	{
	}
	
	#endregion AddressFilter

	#region AddressExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressExpressionBuilder : SqlExpressionBuilder<AddressColumn>
	{
	}
	
	#endregion AddressExpressionBuilder	

	#region AddressProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AddressChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressProperty : ChildEntityProperty<AddressChildEntityTypes>
	{
	}
	
	#endregion AddressProperty
}

