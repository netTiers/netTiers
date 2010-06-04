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
	/// Represents the DataRepository.AddressTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AddressTypeDataSourceDesigner))]
	public class AddressTypeDataSource : ProviderDataSource<AddressType, AddressTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressTypeDataSource class.
		/// </summary>
		public AddressTypeDataSource() : base(new AddressTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AddressTypeDataSourceView used by the AddressTypeDataSource.
		/// </summary>
		protected AddressTypeDataSourceView AddressTypeView
		{
			get { return ( View as AddressTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AddressTypeDataSource control invokes to retrieve data.
		/// </summary>
		public AddressTypeSelectMethod SelectMethod
		{
			get
			{
				AddressTypeSelectMethod selectMethod = AddressTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AddressTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AddressTypeDataSourceView class that is to be
		/// used by the AddressTypeDataSource.
		/// </summary>
		/// <returns>An instance of the AddressTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<AddressType, AddressTypeKey> GetNewDataSourceView()
		{
			return new AddressTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the AddressTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AddressTypeDataSourceView : ProviderDataSourceView<AddressType, AddressTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AddressTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AddressTypeDataSourceView(AddressTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AddressTypeDataSource AddressTypeOwner
		{
			get { return Owner as AddressTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AddressTypeSelectMethod SelectMethod
		{
			get { return AddressTypeOwner.SelectMethod; }
			set { AddressTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AddressTypeService AddressTypeProvider
		{
			get { return Provider as AddressTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AddressType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AddressType> results = null;
			AddressType item;
			count = 0;
			
			System.String _name;
			System.Guid _rowguid;
			System.Int32 _addressTypeId;

			switch ( SelectMethod )
			{
				case AddressTypeSelectMethod.Get:
					AddressTypeKey entityKey  = new AddressTypeKey();
					entityKey.Load(values);
					item = AddressTypeProvider.Get(entityKey);
					results = new TList<AddressType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AddressTypeSelectMethod.GetAll:
                    results = AddressTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AddressTypeSelectMethod.GetPaged:
					results = AddressTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AddressTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = AddressTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AddressTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AddressTypeSelectMethod.GetByAddressTypeId:
					_addressTypeId = ( values["AddressTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressTypeId"], typeof(System.Int32)) : (int)0;
					item = AddressTypeProvider.GetByAddressTypeId(_addressTypeId);
					results = new TList<AddressType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AddressTypeSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = AddressTypeProvider.GetByName(_name);
					results = new TList<AddressType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AddressTypeSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = AddressTypeProvider.GetByRowguid(_rowguid);
					results = new TList<AddressType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
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
			if ( SelectMethod == AddressTypeSelectMethod.Get || SelectMethod == AddressTypeSelectMethod.GetByAddressTypeId )
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
				AddressType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AddressTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AddressType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AddressTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AddressTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AddressTypeDataSource class.
	/// </summary>
	public class AddressTypeDataSourceDesigner : ProviderDataSourceDesigner<AddressType, AddressTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the AddressTypeDataSourceDesigner class.
		/// </summary>
		public AddressTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AddressTypeSelectMethod SelectMethod
		{
			get { return ((AddressTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AddressTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AddressTypeDataSourceActionList

	/// <summary>
	/// Supports the AddressTypeDataSourceDesigner class.
	/// </summary>
	internal class AddressTypeDataSourceActionList : DesignerActionList
	{
		private AddressTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AddressTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AddressTypeDataSourceActionList(AddressTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AddressTypeSelectMethod SelectMethod
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

	#endregion AddressTypeDataSourceActionList
	
	#endregion AddressTypeDataSourceDesigner
	
	#region AddressTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AddressTypeDataSource.SelectMethod property.
	/// </summary>
	public enum AddressTypeSelectMethod
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
		/// Represents the GetByName method.
		/// </summary>
		GetByName,
		/// <summary>
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByAddressTypeId method.
		/// </summary>
		GetByAddressTypeId
	}
	
	#endregion AddressTypeSelectMethod

	#region AddressTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddressType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressTypeFilter : SqlFilter<AddressTypeColumn>
	{
	}
	
	#endregion AddressTypeFilter

	#region AddressTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddressType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressTypeExpressionBuilder : SqlExpressionBuilder<AddressTypeColumn>
	{
	}
	
	#endregion AddressTypeExpressionBuilder	

	#region AddressTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AddressTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AddressType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressTypeProperty : ChildEntityProperty<AddressTypeChildEntityTypes>
	{
	}
	
	#endregion AddressTypeProperty
}

