#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.Bases;
using netTiers.Petshop.Services;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.AccountProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AccountDataSourceDesigner))]
	public class AccountDataSource : ProviderDataSource<Account, AccountKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountDataSource class.
		/// </summary>
		public AccountDataSource() : base(new AccountService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AccountDataSourceView used by the AccountDataSource.
		/// </summary>
		protected AccountDataSourceView AccountView
		{
			get { return ( View as AccountDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AccountDataSource control invokes to retrieve data.
		/// </summary>
		public AccountSelectMethod SelectMethod
		{
			get { return AccountView.SelectMethod; }
			set { AccountView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AccountDataSourceView class that is to be
		/// used by the AccountDataSource.
		/// </summary>
		/// <returns>An instance of the AccountDataSourceView class.</returns>
		protected override BaseDataSourceView<Account, AccountKey> GetNewDataSourceView()
		{
			return new AccountDataSourceView(this, DefaultViewName);
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
	/// Supports the AccountDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AccountDataSourceView : ProviderDataSourceView<Account, AccountKey>
	{
		#region Declarations

		private AccountSelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AccountDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AccountDataSourceView(AccountDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AccountSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AccountService AccountProvider
		{
			get { return Provider as AccountService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Account> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<Account> results = null;
			Account item;
			count = 0;
			
			System.Guid id;
			System.String login;
			System.String lastName;
			System.Guid? favoriteCategoryId;
			System.Guid? creditCardId;

			switch ( SelectMethod )
			{
				case AccountSelectMethod.Get:
					AccountKey entityKey  = new AccountKey();
					entityKey.Load(values);
					item = AccountProvider.Get(entityKey);
					results = new TList<Account>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AccountSelectMethod.GetAll:
                    results = AccountProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AccountSelectMethod.GetPaged:
					results = AccountProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AccountSelectMethod.Find:
					results = AccountProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AccountSelectMethod.GetById:
					id = ( values["Id"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Id"], typeof(System.Guid)) : Guid.Empty;
					item = AccountProvider.GetById(id);
					results = new TList<Account>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AccountSelectMethod.GetByLogin:
					login = (System.String) EntityUtil.ChangeType(values["Login"], typeof(System.String));
					item = AccountProvider.GetByLogin(login);
					results = new TList<Account>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AccountSelectMethod.GetByLastName:
					lastName = (System.String) EntityUtil.ChangeType(values["LastName"], typeof(System.String));
					results = AccountProvider.GetByLastName(lastName, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case AccountSelectMethod.GetByFavoriteCategoryId:
					favoriteCategoryId = (System.Guid?) EntityUtil.ChangeType(values["FavoriteCategoryId"], typeof(System.Guid?));
					results = AccountProvider.GetByFavoriteCategoryId(favoriteCategoryId, this.StartIndex, this.PageSize, out count);
					break;
				case AccountSelectMethod.GetByCreditCardId:
					creditCardId = (System.Guid?) EntityUtil.ChangeType(values["CreditCardId"], typeof(System.Guid?));
					results = AccountProvider.GetByCreditCardId(creditCardId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				default:
					break;
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == AccountSelectMethod.Get || SelectMethod == AccountSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(Account entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.Id == Guid.Empty )
				entity.Id = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Account entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AccountProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					IsDeepLoaded = true;
				}
			}
		}

		#endregion Select Methods
	}
	
	#region AccountDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AccountDataSource class.
	/// </summary>
	public class AccountDataSourceDesigner : ProviderDataSourceDesigner<Account, AccountKey>
	{
		/// <summary>
		/// Initializes a new instance of the AccountDataSourceDesigner class.
		/// </summary>
		public AccountDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AccountSelectMethod SelectMethod
		{
			get { return ((AccountDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AccountDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AccountDataSourceActionList

	/// <summary>
	/// Supports the AccountDataSourceDesigner class.
	/// </summary>
	internal class AccountDataSourceActionList : DesignerActionList
	{
		private AccountDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AccountDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AccountDataSourceActionList(AccountDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AccountSelectMethod SelectMethod
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

	#endregion AccountDataSourceActionList
	
	#endregion AccountDataSourceDesigner
	
	#region AccountSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AccountDataSource.SelectMethod property.
	/// </summary>
	public enum AccountSelectMethod
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
		/// Represents the GetById method.
		/// </summary>
		GetById,
		/// <summary>
		/// Represents the GetByLogin method.
		/// </summary>
		GetByLogin,
		/// <summary>
		/// Represents the GetByLastName method.
		/// </summary>
		GetByLastName,
		/// <summary>
		/// Represents the GetByFavoriteCategoryId method.
		/// </summary>
		GetByFavoriteCategoryId,
		/// <summary>
		/// Represents the GetByCreditCardId method.
		/// </summary>
		GetByCreditCardId
	}
	
	#endregion AccountSelectMethod

	#region AccountFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountFilter : SqlFilter<AccountColumn>
	{
	}
	
	#endregion AccountFilter
}

