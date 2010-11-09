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
	/// Represents the DataRepository.StoreContactProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(StoreContactDataSourceDesigner))]
	public class StoreContactDataSource : ProviderDataSource<StoreContact, StoreContactKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreContactDataSource class.
		/// </summary>
		public StoreContactDataSource() : base(new StoreContactService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the StoreContactDataSourceView used by the StoreContactDataSource.
		/// </summary>
		protected StoreContactDataSourceView StoreContactView
		{
			get { return ( View as StoreContactDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the StoreContactDataSource control invokes to retrieve data.
		/// </summary>
		public StoreContactSelectMethod SelectMethod
		{
			get
			{
				StoreContactSelectMethod selectMethod = StoreContactSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (StoreContactSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the StoreContactDataSourceView class that is to be
		/// used by the StoreContactDataSource.
		/// </summary>
		/// <returns>An instance of the StoreContactDataSourceView class.</returns>
		protected override BaseDataSourceView<StoreContact, StoreContactKey> GetNewDataSourceView()
		{
			return new StoreContactDataSourceView(this, DefaultViewName);
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
	/// Supports the StoreContactDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class StoreContactDataSourceView : ProviderDataSourceView<StoreContact, StoreContactKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreContactDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the StoreContactDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public StoreContactDataSourceView(StoreContactDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal StoreContactDataSource StoreContactOwner
		{
			get { return Owner as StoreContactDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal StoreContactSelectMethod SelectMethod
		{
			get { return StoreContactOwner.SelectMethod; }
			set { StoreContactOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal StoreContactService StoreContactProvider
		{
			get { return Provider as StoreContactService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<StoreContact> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<StoreContact> results = null;
			StoreContact item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _contactId;
			System.Int32 _contactTypeId;
			System.Int32 _customerId;

			switch ( SelectMethod )
			{
				case StoreContactSelectMethod.Get:
					StoreContactKey entityKey  = new StoreContactKey();
					entityKey.Load(values);
					item = StoreContactProvider.Get(entityKey);
					results = new TList<StoreContact>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StoreContactSelectMethod.GetAll:
                    results = StoreContactProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case StoreContactSelectMethod.GetPaged:
					results = StoreContactProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case StoreContactSelectMethod.Find:
					if ( FilterParameters != null )
						results = StoreContactProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = StoreContactProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case StoreContactSelectMethod.GetByCustomerIdContactId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					item = StoreContactProvider.GetByCustomerIdContactId(_customerId, _contactId);
					results = new TList<StoreContact>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case StoreContactSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = StoreContactProvider.GetByRowguid(_rowguid);
					results = new TList<StoreContact>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StoreContactSelectMethod.GetByContactId:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					results = StoreContactProvider.GetByContactId(_contactId, this.StartIndex, this.PageSize, out count);
					break;
				case StoreContactSelectMethod.GetByContactTypeId:
					_contactTypeId = ( values["ContactTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactTypeId"], typeof(System.Int32)) : (int)0;
					results = StoreContactProvider.GetByContactTypeId(_contactTypeId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case StoreContactSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = StoreContactProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == StoreContactSelectMethod.Get || SelectMethod == StoreContactSelectMethod.GetByCustomerIdContactId )
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
				StoreContact entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					StoreContactProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<StoreContact> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			StoreContactProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region StoreContactDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the StoreContactDataSource class.
	/// </summary>
	public class StoreContactDataSourceDesigner : ProviderDataSourceDesigner<StoreContact, StoreContactKey>
	{
		/// <summary>
		/// Initializes a new instance of the StoreContactDataSourceDesigner class.
		/// </summary>
		public StoreContactDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StoreContactSelectMethod SelectMethod
		{
			get { return ((StoreContactDataSource) DataSource).SelectMethod; }
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
				actions.Add(new StoreContactDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region StoreContactDataSourceActionList

	/// <summary>
	/// Supports the StoreContactDataSourceDesigner class.
	/// </summary>
	internal class StoreContactDataSourceActionList : DesignerActionList
	{
		private StoreContactDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the StoreContactDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public StoreContactDataSourceActionList(StoreContactDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StoreContactSelectMethod SelectMethod
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

	#endregion StoreContactDataSourceActionList
	
	#endregion StoreContactDataSourceDesigner
	
	#region StoreContactSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the StoreContactDataSource.SelectMethod property.
	/// </summary>
	public enum StoreContactSelectMethod
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
		/// Represents the GetByContactId method.
		/// </summary>
		GetByContactId,
		/// <summary>
		/// Represents the GetByContactTypeId method.
		/// </summary>
		GetByContactTypeId,
		/// <summary>
		/// Represents the GetByCustomerIdContactId method.
		/// </summary>
		GetByCustomerIdContactId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId
	}
	
	#endregion StoreContactSelectMethod

	#region StoreContactFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StoreContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreContactFilter : SqlFilter<StoreContactColumn>
	{
	}
	
	#endregion StoreContactFilter

	#region StoreContactExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StoreContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreContactExpressionBuilder : SqlExpressionBuilder<StoreContactColumn>
	{
	}
	
	#endregion StoreContactExpressionBuilder	

	#region StoreContactProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;StoreContactChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="StoreContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreContactProperty : ChildEntityProperty<StoreContactChildEntityTypes>
	{
	}
	
	#endregion StoreContactProperty
}

