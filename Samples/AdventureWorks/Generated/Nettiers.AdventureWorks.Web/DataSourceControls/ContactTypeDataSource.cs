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
	/// Represents the DataRepository.ContactTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ContactTypeDataSourceDesigner))]
	public class ContactTypeDataSource : ProviderDataSource<ContactType, ContactTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTypeDataSource class.
		/// </summary>
		public ContactTypeDataSource() : base(new ContactTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ContactTypeDataSourceView used by the ContactTypeDataSource.
		/// </summary>
		protected ContactTypeDataSourceView ContactTypeView
		{
			get { return ( View as ContactTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ContactTypeDataSource control invokes to retrieve data.
		/// </summary>
		public ContactTypeSelectMethod SelectMethod
		{
			get
			{
				ContactTypeSelectMethod selectMethod = ContactTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ContactTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ContactTypeDataSourceView class that is to be
		/// used by the ContactTypeDataSource.
		/// </summary>
		/// <returns>An instance of the ContactTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<ContactType, ContactTypeKey> GetNewDataSourceView()
		{
			return new ContactTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the ContactTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ContactTypeDataSourceView : ProviderDataSourceView<ContactType, ContactTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ContactTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ContactTypeDataSourceView(ContactTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ContactTypeDataSource ContactTypeOwner
		{
			get { return Owner as ContactTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ContactTypeSelectMethod SelectMethod
		{
			get { return ContactTypeOwner.SelectMethod; }
			set { ContactTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ContactTypeService ContactTypeProvider
		{
			get { return Provider as ContactTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ContactType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ContactType> results = null;
			ContactType item;
			count = 0;
			
			System.String _name;
			System.Int32 _contactTypeId;

			switch ( SelectMethod )
			{
				case ContactTypeSelectMethod.Get:
					ContactTypeKey entityKey  = new ContactTypeKey();
					entityKey.Load(values);
					item = ContactTypeProvider.Get(entityKey);
					results = new TList<ContactType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ContactTypeSelectMethod.GetAll:
                    results = ContactTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ContactTypeSelectMethod.GetPaged:
					results = ContactTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ContactTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = ContactTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ContactTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ContactTypeSelectMethod.GetByContactTypeId:
					_contactTypeId = ( values["ContactTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactTypeId"], typeof(System.Int32)) : (int)0;
					item = ContactTypeProvider.GetByContactTypeId(_contactTypeId);
					results = new TList<ContactType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ContactTypeSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ContactTypeProvider.GetByName(_name);
					results = new TList<ContactType>();
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
			if ( SelectMethod == ContactTypeSelectMethod.Get || SelectMethod == ContactTypeSelectMethod.GetByContactTypeId )
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
				ContactType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ContactTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ContactType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ContactTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ContactTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ContactTypeDataSource class.
	/// </summary>
	public class ContactTypeDataSourceDesigner : ProviderDataSourceDesigner<ContactType, ContactTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the ContactTypeDataSourceDesigner class.
		/// </summary>
		public ContactTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContactTypeSelectMethod SelectMethod
		{
			get { return ((ContactTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ContactTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ContactTypeDataSourceActionList

	/// <summary>
	/// Supports the ContactTypeDataSourceDesigner class.
	/// </summary>
	internal class ContactTypeDataSourceActionList : DesignerActionList
	{
		private ContactTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ContactTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ContactTypeDataSourceActionList(ContactTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContactTypeSelectMethod SelectMethod
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

	#endregion ContactTypeDataSourceActionList
	
	#endregion ContactTypeDataSourceDesigner
	
	#region ContactTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ContactTypeDataSource.SelectMethod property.
	/// </summary>
	public enum ContactTypeSelectMethod
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
		/// Represents the GetByContactTypeId method.
		/// </summary>
		GetByContactTypeId
	}
	
	#endregion ContactTypeSelectMethod

	#region ContactTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTypeFilter : SqlFilter<ContactTypeColumn>
	{
	}
	
	#endregion ContactTypeFilter

	#region ContactTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTypeExpressionBuilder : SqlExpressionBuilder<ContactTypeColumn>
	{
	}
	
	#endregion ContactTypeExpressionBuilder	

	#region ContactTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ContactTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ContactType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTypeProperty : ChildEntityProperty<ContactTypeChildEntityTypes>
	{
	}
	
	#endregion ContactTypeProperty
}

