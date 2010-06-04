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
	/// Represents the DataRepository.ContactProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ContactDataSourceDesigner))]
	public class ContactDataSource : ProviderDataSource<Contact, ContactKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactDataSource class.
		/// </summary>
		public ContactDataSource() : base(new ContactService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ContactDataSourceView used by the ContactDataSource.
		/// </summary>
		protected ContactDataSourceView ContactView
		{
			get { return ( View as ContactDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ContactDataSource control invokes to retrieve data.
		/// </summary>
		public ContactSelectMethod SelectMethod
		{
			get
			{
				ContactSelectMethod selectMethod = ContactSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ContactSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ContactDataSourceView class that is to be
		/// used by the ContactDataSource.
		/// </summary>
		/// <returns>An instance of the ContactDataSourceView class.</returns>
		protected override BaseDataSourceView<Contact, ContactKey> GetNewDataSourceView()
		{
			return new ContactDataSourceView(this, DefaultViewName);
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
	/// Supports the ContactDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ContactDataSourceView : ProviderDataSourceView<Contact, ContactKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ContactDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ContactDataSourceView(ContactDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ContactDataSource ContactOwner
		{
			get { return Owner as ContactDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ContactSelectMethod SelectMethod
		{
			get { return ContactOwner.SelectMethod; }
			set { ContactOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ContactService ContactProvider
		{
			get { return Provider as ContactService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Contact> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Contact> results = null;
			Contact item;
			count = 0;
			
			System.Guid _rowguid;
			System.String _emailAddress_nullable;
			System.Int32 _contactId;
			string _additionalContactInfo_nullable;
			System.Int32 _creditCardId;
			System.Int32 _customerId;
			System.Int32 _vendorId;

			switch ( SelectMethod )
			{
				case ContactSelectMethod.Get:
					ContactKey entityKey  = new ContactKey();
					entityKey.Load(values);
					item = ContactProvider.Get(entityKey);
					results = new TList<Contact>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ContactSelectMethod.GetAll:
                    results = ContactProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ContactSelectMethod.GetPaged:
					results = ContactProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ContactSelectMethod.Find:
					if ( FilterParameters != null )
						results = ContactProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ContactProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ContactSelectMethod.GetByContactId:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					item = ContactProvider.GetByContactId(_contactId);
					results = new TList<Contact>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ContactSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = ContactProvider.GetByRowguid(_rowguid);
					results = new TList<Contact>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ContactSelectMethod.GetByEmailAddress:
					_emailAddress_nullable = (System.String) EntityUtil.ChangeType(values["EmailAddress"], typeof(System.String));
					results = ContactProvider.GetByEmailAddress(_emailAddress_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ContactSelectMethod.GetByAdditionalContactInfo:
					_additionalContactInfo_nullable = (string) EntityUtil.ChangeType(values["AdditionalContactInfo"], typeof(string));
					results = ContactProvider.GetByAdditionalContactInfo(_additionalContactInfo_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				case ContactSelectMethod.GetByCreditCardIdFromContactCreditCard:
					_creditCardId = ( values["CreditCardId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CreditCardId"], typeof(System.Int32)) : (int)0;
					results = ContactProvider.GetByCreditCardIdFromContactCreditCard(_creditCardId, this.StartIndex, this.PageSize, out count);
					break;
				case ContactSelectMethod.GetByCustomerIdFromStoreContact:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = ContactProvider.GetByCustomerIdFromStoreContact(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case ContactSelectMethod.GetByVendorIdFromVendorContact:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					results = ContactProvider.GetByVendorIdFromVendorContact(_vendorId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ContactSelectMethod.Get || SelectMethod == ContactSelectMethod.GetByContactId )
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
				Contact entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ContactProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Contact> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ContactProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ContactDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ContactDataSource class.
	/// </summary>
	public class ContactDataSourceDesigner : ProviderDataSourceDesigner<Contact, ContactKey>
	{
		/// <summary>
		/// Initializes a new instance of the ContactDataSourceDesigner class.
		/// </summary>
		public ContactDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContactSelectMethod SelectMethod
		{
			get { return ((ContactDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ContactDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ContactDataSourceActionList

	/// <summary>
	/// Supports the ContactDataSourceDesigner class.
	/// </summary>
	internal class ContactDataSourceActionList : DesignerActionList
	{
		private ContactDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ContactDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ContactDataSourceActionList(ContactDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContactSelectMethod SelectMethod
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

	#endregion ContactDataSourceActionList
	
	#endregion ContactDataSourceDesigner
	
	#region ContactSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ContactDataSource.SelectMethod property.
	/// </summary>
	public enum ContactSelectMethod
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
		/// Represents the GetByEmailAddress method.
		/// </summary>
		GetByEmailAddress,
		/// <summary>
		/// Represents the GetByContactId method.
		/// </summary>
		GetByContactId,
		/// <summary>
		/// Represents the GetByAdditionalContactInfo method.
		/// </summary>
		GetByAdditionalContactInfo,
		/// <summary>
		/// Represents the GetByCreditCardIdFromContactCreditCard method.
		/// </summary>
		GetByCreditCardIdFromContactCreditCard,
		/// <summary>
		/// Represents the GetByCustomerIdFromStoreContact method.
		/// </summary>
		GetByCustomerIdFromStoreContact,
		/// <summary>
		/// Represents the GetByVendorIdFromVendorContact method.
		/// </summary>
		GetByVendorIdFromVendorContact
	}
	
	#endregion ContactSelectMethod

	#region ContactFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactFilter : SqlFilter<ContactColumn>
	{
	}
	
	#endregion ContactFilter

	#region ContactExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactExpressionBuilder : SqlExpressionBuilder<ContactColumn>
	{
	}
	
	#endregion ContactExpressionBuilder	

	#region ContactProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ContactChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Contact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactProperty : ChildEntityProperty<ContactChildEntityTypes>
	{
	}
	
	#endregion ContactProperty
}

