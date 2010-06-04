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
	/// Represents the DataRepository.EmployeeAddressProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmployeeAddressDataSourceDesigner))]
	public class EmployeeAddressDataSource : ProviderDataSource<EmployeeAddress, EmployeeAddressKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressDataSource class.
		/// </summary>
		public EmployeeAddressDataSource() : base(new EmployeeAddressService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmployeeAddressDataSourceView used by the EmployeeAddressDataSource.
		/// </summary>
		protected EmployeeAddressDataSourceView EmployeeAddressView
		{
			get { return ( View as EmployeeAddressDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmployeeAddressDataSource control invokes to retrieve data.
		/// </summary>
		public EmployeeAddressSelectMethod SelectMethod
		{
			get
			{
				EmployeeAddressSelectMethod selectMethod = EmployeeAddressSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmployeeAddressSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmployeeAddressDataSourceView class that is to be
		/// used by the EmployeeAddressDataSource.
		/// </summary>
		/// <returns>An instance of the EmployeeAddressDataSourceView class.</returns>
		protected override BaseDataSourceView<EmployeeAddress, EmployeeAddressKey> GetNewDataSourceView()
		{
			return new EmployeeAddressDataSourceView(this, DefaultViewName);
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
	/// Supports the EmployeeAddressDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmployeeAddressDataSourceView : ProviderDataSourceView<EmployeeAddress, EmployeeAddressKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmployeeAddressDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmployeeAddressDataSourceView(EmployeeAddressDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmployeeAddressDataSource EmployeeAddressOwner
		{
			get { return Owner as EmployeeAddressDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmployeeAddressSelectMethod SelectMethod
		{
			get { return EmployeeAddressOwner.SelectMethod; }
			set { EmployeeAddressOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmployeeAddressService EmployeeAddressProvider
		{
			get { return Provider as EmployeeAddressService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmployeeAddress> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmployeeAddress> results = null;
			EmployeeAddress item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _employeeId;
			System.Int32 _addressId;

			switch ( SelectMethod )
			{
				case EmployeeAddressSelectMethod.Get:
					EmployeeAddressKey entityKey  = new EmployeeAddressKey();
					entityKey.Load(values);
					item = EmployeeAddressProvider.Get(entityKey);
					results = new TList<EmployeeAddress>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeAddressSelectMethod.GetAll:
                    results = EmployeeAddressProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmployeeAddressSelectMethod.GetPaged:
					results = EmployeeAddressProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmployeeAddressSelectMethod.Find:
					if ( FilterParameters != null )
						results = EmployeeAddressProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmployeeAddressProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmployeeAddressSelectMethod.GetByEmployeeIdAddressId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					item = EmployeeAddressProvider.GetByEmployeeIdAddressId(_employeeId, _addressId);
					results = new TList<EmployeeAddress>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case EmployeeAddressSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = EmployeeAddressProvider.GetByRowguid(_rowguid);
					results = new TList<EmployeeAddress>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case EmployeeAddressSelectMethod.GetByAddressId:
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					results = EmployeeAddressProvider.GetByAddressId(_addressId, this.StartIndex, this.PageSize, out count);
					break;
				case EmployeeAddressSelectMethod.GetByEmployeeId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					results = EmployeeAddressProvider.GetByEmployeeId(_employeeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EmployeeAddressSelectMethod.Get || SelectMethod == EmployeeAddressSelectMethod.GetByEmployeeIdAddressId )
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
				EmployeeAddress entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmployeeAddressProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmployeeAddress> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmployeeAddressProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmployeeAddressDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmployeeAddressDataSource class.
	/// </summary>
	public class EmployeeAddressDataSourceDesigner : ProviderDataSourceDesigner<EmployeeAddress, EmployeeAddressKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmployeeAddressDataSourceDesigner class.
		/// </summary>
		public EmployeeAddressDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeAddressSelectMethod SelectMethod
		{
			get { return ((EmployeeAddressDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmployeeAddressDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmployeeAddressDataSourceActionList

	/// <summary>
	/// Supports the EmployeeAddressDataSourceDesigner class.
	/// </summary>
	internal class EmployeeAddressDataSourceActionList : DesignerActionList
	{
		private EmployeeAddressDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmployeeAddressDataSourceActionList(EmployeeAddressDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeAddressSelectMethod SelectMethod
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

	#endregion EmployeeAddressDataSourceActionList
	
	#endregion EmployeeAddressDataSourceDesigner
	
	#region EmployeeAddressSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmployeeAddressDataSource.SelectMethod property.
	/// </summary>
	public enum EmployeeAddressSelectMethod
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
		/// Represents the GetByEmployeeIdAddressId method.
		/// </summary>
		GetByEmployeeIdAddressId,
		/// <summary>
		/// Represents the GetByAddressId method.
		/// </summary>
		GetByAddressId,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId
	}
	
	#endregion EmployeeAddressSelectMethod

	#region EmployeeAddressFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeAddressFilter : SqlFilter<EmployeeAddressColumn>
	{
	}
	
	#endregion EmployeeAddressFilter

	#region EmployeeAddressExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeAddressExpressionBuilder : SqlExpressionBuilder<EmployeeAddressColumn>
	{
	}
	
	#endregion EmployeeAddressExpressionBuilder	

	#region EmployeeAddressProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmployeeAddressChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeAddressProperty : ChildEntityProperty<EmployeeAddressChildEntityTypes>
	{
	}
	
	#endregion EmployeeAddressProperty
}

