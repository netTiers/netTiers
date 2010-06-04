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
	/// Represents the DataRepository.EmployeeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmployeeDataSourceDesigner))]
	public class EmployeeDataSource : ProviderDataSource<Employee, EmployeeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDataSource class.
		/// </summary>
		public EmployeeDataSource() : base(new EmployeeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmployeeDataSourceView used by the EmployeeDataSource.
		/// </summary>
		protected EmployeeDataSourceView EmployeeView
		{
			get { return ( View as EmployeeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmployeeDataSource control invokes to retrieve data.
		/// </summary>
		public EmployeeSelectMethod SelectMethod
		{
			get
			{
				EmployeeSelectMethod selectMethod = EmployeeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmployeeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmployeeDataSourceView class that is to be
		/// used by the EmployeeDataSource.
		/// </summary>
		/// <returns>An instance of the EmployeeDataSourceView class.</returns>
		protected override BaseDataSourceView<Employee, EmployeeKey> GetNewDataSourceView()
		{
			return new EmployeeDataSourceView(this, DefaultViewName);
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
	/// Supports the EmployeeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmployeeDataSourceView : ProviderDataSourceView<Employee, EmployeeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmployeeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmployeeDataSourceView(EmployeeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmployeeDataSource EmployeeOwner
		{
			get { return Owner as EmployeeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmployeeSelectMethod SelectMethod
		{
			get { return EmployeeOwner.SelectMethod; }
			set { EmployeeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmployeeService EmployeeProvider
		{
			get { return Provider as EmployeeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Employee> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Employee> results = null;
			Employee item;
			count = 0;
			
			System.String _loginId;
			System.String _nationalIdNumber;
			System.Guid _rowguid;
			System.Int32? _managerId_nullable;
			System.Int32 _employeeId;
			System.Int32 _contactId;
			System.Int32 _addressId;

			switch ( SelectMethod )
			{
				case EmployeeSelectMethod.Get:
					EmployeeKey entityKey  = new EmployeeKey();
					entityKey.Load(values);
					item = EmployeeProvider.Get(entityKey);
					results = new TList<Employee>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeSelectMethod.GetAll:
                    results = EmployeeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmployeeSelectMethod.GetPaged:
					results = EmployeeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmployeeSelectMethod.Find:
					if ( FilterParameters != null )
						results = EmployeeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmployeeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmployeeSelectMethod.GetByEmployeeId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					item = EmployeeProvider.GetByEmployeeId(_employeeId);
					results = new TList<Employee>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case EmployeeSelectMethod.GetByLoginId:
					_loginId = ( values["LoginId"] != null ) ? (System.String) EntityUtil.ChangeType(values["LoginId"], typeof(System.String)) : string.Empty;
					item = EmployeeProvider.GetByLoginId(_loginId);
					results = new TList<Employee>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeSelectMethod.GetByNationalIdNumber:
					_nationalIdNumber = ( values["NationalIdNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["NationalIdNumber"], typeof(System.String)) : string.Empty;
					item = EmployeeProvider.GetByNationalIdNumber(_nationalIdNumber);
					results = new TList<Employee>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = EmployeeProvider.GetByRowguid(_rowguid);
					results = new TList<Employee>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeSelectMethod.GetByManagerId:
					_managerId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ManagerId"], typeof(System.Int32?));
					results = EmployeeProvider.GetByManagerId(_managerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case EmployeeSelectMethod.GetByContactId:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					results = EmployeeProvider.GetByContactId(_contactId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case EmployeeSelectMethod.GetByAddressIdFromEmployeeAddress:
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					results = EmployeeProvider.GetByAddressIdFromEmployeeAddress(_addressId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EmployeeSelectMethod.Get || SelectMethod == EmployeeSelectMethod.GetByEmployeeId )
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
				Employee entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmployeeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Employee> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmployeeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmployeeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmployeeDataSource class.
	/// </summary>
	public class EmployeeDataSourceDesigner : ProviderDataSourceDesigner<Employee, EmployeeKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmployeeDataSourceDesigner class.
		/// </summary>
		public EmployeeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeSelectMethod SelectMethod
		{
			get { return ((EmployeeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmployeeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmployeeDataSourceActionList

	/// <summary>
	/// Supports the EmployeeDataSourceDesigner class.
	/// </summary>
	internal class EmployeeDataSourceActionList : DesignerActionList
	{
		private EmployeeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmployeeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmployeeDataSourceActionList(EmployeeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeSelectMethod SelectMethod
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

	#endregion EmployeeDataSourceActionList
	
	#endregion EmployeeDataSourceDesigner
	
	#region EmployeeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmployeeDataSource.SelectMethod property.
	/// </summary>
	public enum EmployeeSelectMethod
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
		/// Represents the GetByLoginId method.
		/// </summary>
		GetByLoginId,
		/// <summary>
		/// Represents the GetByNationalIdNumber method.
		/// </summary>
		GetByNationalIdNumber,
		/// <summary>
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByManagerId method.
		/// </summary>
		GetByManagerId,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId,
		/// <summary>
		/// Represents the GetByContactId method.
		/// </summary>
		GetByContactId,
		/// <summary>
		/// Represents the GetByAddressIdFromEmployeeAddress method.
		/// </summary>
		GetByAddressIdFromEmployeeAddress
	}
	
	#endregion EmployeeSelectMethod

	#region EmployeeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeFilter : SqlFilter<EmployeeColumn>
	{
	}
	
	#endregion EmployeeFilter

	#region EmployeeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeExpressionBuilder : SqlExpressionBuilder<EmployeeColumn>
	{
	}
	
	#endregion EmployeeExpressionBuilder	

	#region EmployeeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmployeeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeProperty : ChildEntityProperty<EmployeeChildEntityTypes>
	{
	}
	
	#endregion EmployeeProperty
}

