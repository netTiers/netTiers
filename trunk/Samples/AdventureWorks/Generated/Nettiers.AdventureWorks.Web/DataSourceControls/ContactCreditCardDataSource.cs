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
	/// Represents the DataRepository.ContactCreditCardProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ContactCreditCardDataSourceDesigner))]
	public class ContactCreditCardDataSource : ProviderDataSource<ContactCreditCard, ContactCreditCardKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardDataSource class.
		/// </summary>
		public ContactCreditCardDataSource() : base(new ContactCreditCardService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ContactCreditCardDataSourceView used by the ContactCreditCardDataSource.
		/// </summary>
		protected ContactCreditCardDataSourceView ContactCreditCardView
		{
			get { return ( View as ContactCreditCardDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ContactCreditCardDataSource control invokes to retrieve data.
		/// </summary>
		public ContactCreditCardSelectMethod SelectMethod
		{
			get
			{
				ContactCreditCardSelectMethod selectMethod = ContactCreditCardSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ContactCreditCardSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ContactCreditCardDataSourceView class that is to be
		/// used by the ContactCreditCardDataSource.
		/// </summary>
		/// <returns>An instance of the ContactCreditCardDataSourceView class.</returns>
		protected override BaseDataSourceView<ContactCreditCard, ContactCreditCardKey> GetNewDataSourceView()
		{
			return new ContactCreditCardDataSourceView(this, DefaultViewName);
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
	/// Supports the ContactCreditCardDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ContactCreditCardDataSourceView : ProviderDataSourceView<ContactCreditCard, ContactCreditCardKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ContactCreditCardDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ContactCreditCardDataSourceView(ContactCreditCardDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ContactCreditCardDataSource ContactCreditCardOwner
		{
			get { return Owner as ContactCreditCardDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ContactCreditCardSelectMethod SelectMethod
		{
			get { return ContactCreditCardOwner.SelectMethod; }
			set { ContactCreditCardOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ContactCreditCardService ContactCreditCardProvider
		{
			get { return Provider as ContactCreditCardService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ContactCreditCard> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ContactCreditCard> results = null;
			ContactCreditCard item;
			count = 0;
			
			System.Int32 _contactId;
			System.Int32 _creditCardId;

			switch ( SelectMethod )
			{
				case ContactCreditCardSelectMethod.Get:
					ContactCreditCardKey entityKey  = new ContactCreditCardKey();
					entityKey.Load(values);
					item = ContactCreditCardProvider.Get(entityKey);
					results = new TList<ContactCreditCard>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ContactCreditCardSelectMethod.GetAll:
                    results = ContactCreditCardProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ContactCreditCardSelectMethod.GetPaged:
					results = ContactCreditCardProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ContactCreditCardSelectMethod.Find:
					if ( FilterParameters != null )
						results = ContactCreditCardProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ContactCreditCardProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ContactCreditCardSelectMethod.GetByContactIdCreditCardId:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					_creditCardId = ( values["CreditCardId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CreditCardId"], typeof(System.Int32)) : (int)0;
					item = ContactCreditCardProvider.GetByContactIdCreditCardId(_contactId, _creditCardId);
					results = new TList<ContactCreditCard>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ContactCreditCardSelectMethod.GetByContactId:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					results = ContactCreditCardProvider.GetByContactId(_contactId, this.StartIndex, this.PageSize, out count);
					break;
				case ContactCreditCardSelectMethod.GetByCreditCardId:
					_creditCardId = ( values["CreditCardId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CreditCardId"], typeof(System.Int32)) : (int)0;
					results = ContactCreditCardProvider.GetByCreditCardId(_creditCardId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ContactCreditCardSelectMethod.Get || SelectMethod == ContactCreditCardSelectMethod.GetByContactIdCreditCardId )
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
				ContactCreditCard entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ContactCreditCardProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ContactCreditCard> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ContactCreditCardProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ContactCreditCardDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ContactCreditCardDataSource class.
	/// </summary>
	public class ContactCreditCardDataSourceDesigner : ProviderDataSourceDesigner<ContactCreditCard, ContactCreditCardKey>
	{
		/// <summary>
		/// Initializes a new instance of the ContactCreditCardDataSourceDesigner class.
		/// </summary>
		public ContactCreditCardDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContactCreditCardSelectMethod SelectMethod
		{
			get { return ((ContactCreditCardDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ContactCreditCardDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ContactCreditCardDataSourceActionList

	/// <summary>
	/// Supports the ContactCreditCardDataSourceDesigner class.
	/// </summary>
	internal class ContactCreditCardDataSourceActionList : DesignerActionList
	{
		private ContactCreditCardDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ContactCreditCardDataSourceActionList(ContactCreditCardDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContactCreditCardSelectMethod SelectMethod
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

	#endregion ContactCreditCardDataSourceActionList
	
	#endregion ContactCreditCardDataSourceDesigner
	
	#region ContactCreditCardSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ContactCreditCardDataSource.SelectMethod property.
	/// </summary>
	public enum ContactCreditCardSelectMethod
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
		/// Represents the GetByContactIdCreditCardId method.
		/// </summary>
		GetByContactIdCreditCardId,
		/// <summary>
		/// Represents the GetByContactId method.
		/// </summary>
		GetByContactId,
		/// <summary>
		/// Represents the GetByCreditCardId method.
		/// </summary>
		GetByCreditCardId
	}
	
	#endregion ContactCreditCardSelectMethod

	#region ContactCreditCardFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactCreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactCreditCardFilter : SqlFilter<ContactCreditCardColumn>
	{
	}
	
	#endregion ContactCreditCardFilter

	#region ContactCreditCardExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactCreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactCreditCardExpressionBuilder : SqlExpressionBuilder<ContactCreditCardColumn>
	{
	}
	
	#endregion ContactCreditCardExpressionBuilder	

	#region ContactCreditCardProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ContactCreditCardChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ContactCreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactCreditCardProperty : ChildEntityProperty<ContactCreditCardChildEntityTypes>
	{
	}
	
	#endregion ContactCreditCardProperty
}

