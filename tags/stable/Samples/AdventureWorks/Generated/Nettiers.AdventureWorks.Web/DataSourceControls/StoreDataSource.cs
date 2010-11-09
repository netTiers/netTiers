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
	/// Represents the DataRepository.StoreProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(StoreDataSourceDesigner))]
	public class StoreDataSource : ProviderDataSource<Store, StoreKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreDataSource class.
		/// </summary>
		public StoreDataSource() : base(new StoreService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the StoreDataSourceView used by the StoreDataSource.
		/// </summary>
		protected StoreDataSourceView StoreView
		{
			get { return ( View as StoreDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the StoreDataSource control invokes to retrieve data.
		/// </summary>
		public StoreSelectMethod SelectMethod
		{
			get
			{
				StoreSelectMethod selectMethod = StoreSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (StoreSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the StoreDataSourceView class that is to be
		/// used by the StoreDataSource.
		/// </summary>
		/// <returns>An instance of the StoreDataSourceView class.</returns>
		protected override BaseDataSourceView<Store, StoreKey> GetNewDataSourceView()
		{
			return new StoreDataSourceView(this, DefaultViewName);
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
	/// Supports the StoreDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class StoreDataSourceView : ProviderDataSourceView<Store, StoreKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the StoreDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public StoreDataSourceView(StoreDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal StoreDataSource StoreOwner
		{
			get { return Owner as StoreDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal StoreSelectMethod SelectMethod
		{
			get { return StoreOwner.SelectMethod; }
			set { StoreOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal StoreService StoreProvider
		{
			get { return Provider as StoreService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Store> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Store> results = null;
			Store item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32? _salesPersonId_nullable;
			System.Int32 _customerId;
			string _demographics_nullable;
			System.Int32 _contactId;

			switch ( SelectMethod )
			{
				case StoreSelectMethod.Get:
					StoreKey entityKey  = new StoreKey();
					entityKey.Load(values);
					item = StoreProvider.Get(entityKey);
					results = new TList<Store>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StoreSelectMethod.GetAll:
                    results = StoreProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case StoreSelectMethod.GetPaged:
					results = StoreProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case StoreSelectMethod.Find:
					if ( FilterParameters != null )
						results = StoreProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = StoreProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case StoreSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					item = StoreProvider.GetByCustomerId(_customerId);
					results = new TList<Store>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case StoreSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = StoreProvider.GetByRowguid(_rowguid);
					results = new TList<Store>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StoreSelectMethod.GetBySalesPersonId:
					_salesPersonId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32?));
					results = StoreProvider.GetBySalesPersonId(_salesPersonId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case StoreSelectMethod.GetByDemographics:
					_demographics_nullable = (string) EntityUtil.ChangeType(values["Demographics"], typeof(string));
					results = StoreProvider.GetByDemographics(_demographics_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				case StoreSelectMethod.GetByContactIdFromStoreContact:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					results = StoreProvider.GetByContactIdFromStoreContact(_contactId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == StoreSelectMethod.Get || SelectMethod == StoreSelectMethod.GetByCustomerId )
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
				Store entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					StoreProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Store> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			StoreProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region StoreDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the StoreDataSource class.
	/// </summary>
	public class StoreDataSourceDesigner : ProviderDataSourceDesigner<Store, StoreKey>
	{
		/// <summary>
		/// Initializes a new instance of the StoreDataSourceDesigner class.
		/// </summary>
		public StoreDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StoreSelectMethod SelectMethod
		{
			get { return ((StoreDataSource) DataSource).SelectMethod; }
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
				actions.Add(new StoreDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region StoreDataSourceActionList

	/// <summary>
	/// Supports the StoreDataSourceDesigner class.
	/// </summary>
	internal class StoreDataSourceActionList : DesignerActionList
	{
		private StoreDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the StoreDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public StoreDataSourceActionList(StoreDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StoreSelectMethod SelectMethod
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

	#endregion StoreDataSourceActionList
	
	#endregion StoreDataSourceDesigner
	
	#region StoreSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the StoreDataSource.SelectMethod property.
	/// </summary>
	public enum StoreSelectMethod
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
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByDemographics method.
		/// </summary>
		GetByDemographics,
		/// <summary>
		/// Represents the GetByContactIdFromStoreContact method.
		/// </summary>
		GetByContactIdFromStoreContact
	}
	
	#endregion StoreSelectMethod

	#region StoreFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreFilter : SqlFilter<StoreColumn>
	{
	}
	
	#endregion StoreFilter

	#region StoreExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreExpressionBuilder : SqlExpressionBuilder<StoreColumn>
	{
	}
	
	#endregion StoreExpressionBuilder	

	#region StoreProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;StoreChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreProperty : ChildEntityProperty<StoreChildEntityTypes>
	{
	}
	
	#endregion StoreProperty
}

