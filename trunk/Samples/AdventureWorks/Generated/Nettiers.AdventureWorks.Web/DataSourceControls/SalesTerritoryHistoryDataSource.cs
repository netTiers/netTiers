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
	/// Represents the DataRepository.SalesTerritoryHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalesTerritoryHistoryDataSourceDesigner))]
	public class SalesTerritoryHistoryDataSource : ProviderDataSource<SalesTerritoryHistory, SalesTerritoryHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryDataSource class.
		/// </summary>
		public SalesTerritoryHistoryDataSource() : base(new SalesTerritoryHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalesTerritoryHistoryDataSourceView used by the SalesTerritoryHistoryDataSource.
		/// </summary>
		protected SalesTerritoryHistoryDataSourceView SalesTerritoryHistoryView
		{
			get { return ( View as SalesTerritoryHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalesTerritoryHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public SalesTerritoryHistorySelectMethod SelectMethod
		{
			get
			{
				SalesTerritoryHistorySelectMethod selectMethod = SalesTerritoryHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalesTerritoryHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalesTerritoryHistoryDataSourceView class that is to be
		/// used by the SalesTerritoryHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the SalesTerritoryHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<SalesTerritoryHistory, SalesTerritoryHistoryKey> GetNewDataSourceView()
		{
			return new SalesTerritoryHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the SalesTerritoryHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalesTerritoryHistoryDataSourceView : ProviderDataSourceView<SalesTerritoryHistory, SalesTerritoryHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalesTerritoryHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalesTerritoryHistoryDataSourceView(SalesTerritoryHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalesTerritoryHistoryDataSource SalesTerritoryHistoryOwner
		{
			get { return Owner as SalesTerritoryHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalesTerritoryHistorySelectMethod SelectMethod
		{
			get { return SalesTerritoryHistoryOwner.SelectMethod; }
			set { SalesTerritoryHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalesTerritoryHistoryService SalesTerritoryHistoryProvider
		{
			get { return Provider as SalesTerritoryHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalesTerritoryHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalesTerritoryHistory> results = null;
			SalesTerritoryHistory item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _salesPersonId;
			System.DateTime _startDate;
			System.Int32 _territoryId;

			switch ( SelectMethod )
			{
				case SalesTerritoryHistorySelectMethod.Get:
					SalesTerritoryHistoryKey entityKey  = new SalesTerritoryHistoryKey();
					entityKey.Load(values);
					item = SalesTerritoryHistoryProvider.Get(entityKey);
					results = new TList<SalesTerritoryHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesTerritoryHistorySelectMethod.GetAll:
                    results = SalesTerritoryHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalesTerritoryHistorySelectMethod.GetPaged:
					results = SalesTerritoryHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalesTerritoryHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = SalesTerritoryHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalesTerritoryHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalesTerritoryHistorySelectMethod.GetBySalesPersonIdStartDateTerritoryId:
					_salesPersonId = ( values["SalesPersonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32)) : (int)0;
					_startDate = ( values["StartDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartDate"], typeof(System.DateTime)) : DateTime.MinValue;
					_territoryId = ( values["TerritoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TerritoryId"], typeof(System.Int32)) : (int)0;
					item = SalesTerritoryHistoryProvider.GetBySalesPersonIdStartDateTerritoryId(_salesPersonId, _startDate, _territoryId);
					results = new TList<SalesTerritoryHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SalesTerritoryHistorySelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = SalesTerritoryHistoryProvider.GetByRowguid(_rowguid);
					results = new TList<SalesTerritoryHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case SalesTerritoryHistorySelectMethod.GetBySalesPersonId:
					_salesPersonId = ( values["SalesPersonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32)) : (int)0;
					results = SalesTerritoryHistoryProvider.GetBySalesPersonId(_salesPersonId, this.StartIndex, this.PageSize, out count);
					break;
				case SalesTerritoryHistorySelectMethod.GetByTerritoryId:
					_territoryId = ( values["TerritoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TerritoryId"], typeof(System.Int32)) : (int)0;
					results = SalesTerritoryHistoryProvider.GetByTerritoryId(_territoryId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SalesTerritoryHistorySelectMethod.Get || SelectMethod == SalesTerritoryHistorySelectMethod.GetBySalesPersonIdStartDateTerritoryId )
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
				SalesTerritoryHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalesTerritoryHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalesTerritoryHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalesTerritoryHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalesTerritoryHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalesTerritoryHistoryDataSource class.
	/// </summary>
	public class SalesTerritoryHistoryDataSourceDesigner : ProviderDataSourceDesigner<SalesTerritoryHistory, SalesTerritoryHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryDataSourceDesigner class.
		/// </summary>
		public SalesTerritoryHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesTerritoryHistorySelectMethod SelectMethod
		{
			get { return ((SalesTerritoryHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalesTerritoryHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalesTerritoryHistoryDataSourceActionList

	/// <summary>
	/// Supports the SalesTerritoryHistoryDataSourceDesigner class.
	/// </summary>
	internal class SalesTerritoryHistoryDataSourceActionList : DesignerActionList
	{
		private SalesTerritoryHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalesTerritoryHistoryDataSourceActionList(SalesTerritoryHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesTerritoryHistorySelectMethod SelectMethod
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

	#endregion SalesTerritoryHistoryDataSourceActionList
	
	#endregion SalesTerritoryHistoryDataSourceDesigner
	
	#region SalesTerritoryHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalesTerritoryHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum SalesTerritoryHistorySelectMethod
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
		/// Represents the GetBySalesPersonIdStartDateTerritoryId method.
		/// </summary>
		GetBySalesPersonIdStartDateTerritoryId,
		/// <summary>
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId,
		/// <summary>
		/// Represents the GetByTerritoryId method.
		/// </summary>
		GetByTerritoryId
	}
	
	#endregion SalesTerritoryHistorySelectMethod

	#region SalesTerritoryHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritoryHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryHistoryFilter : SqlFilter<SalesTerritoryHistoryColumn>
	{
	}
	
	#endregion SalesTerritoryHistoryFilter

	#region SalesTerritoryHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritoryHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryHistoryExpressionBuilder : SqlExpressionBuilder<SalesTerritoryHistoryColumn>
	{
	}
	
	#endregion SalesTerritoryHistoryExpressionBuilder	

	#region SalesTerritoryHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalesTerritoryHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritoryHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryHistoryProperty : ChildEntityProperty<SalesTerritoryHistoryChildEntityTypes>
	{
	}
	
	#endregion SalesTerritoryHistoryProperty
}

