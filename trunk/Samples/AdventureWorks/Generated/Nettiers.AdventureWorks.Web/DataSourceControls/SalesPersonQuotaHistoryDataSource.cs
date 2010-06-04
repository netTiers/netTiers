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
	/// Represents the DataRepository.SalesPersonQuotaHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalesPersonQuotaHistoryDataSourceDesigner))]
	public class SalesPersonQuotaHistoryDataSource : ProviderDataSource<SalesPersonQuotaHistory, SalesPersonQuotaHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryDataSource class.
		/// </summary>
		public SalesPersonQuotaHistoryDataSource() : base(new SalesPersonQuotaHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalesPersonQuotaHistoryDataSourceView used by the SalesPersonQuotaHistoryDataSource.
		/// </summary>
		protected SalesPersonQuotaHistoryDataSourceView SalesPersonQuotaHistoryView
		{
			get { return ( View as SalesPersonQuotaHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalesPersonQuotaHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public SalesPersonQuotaHistorySelectMethod SelectMethod
		{
			get
			{
				SalesPersonQuotaHistorySelectMethod selectMethod = SalesPersonQuotaHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalesPersonQuotaHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalesPersonQuotaHistoryDataSourceView class that is to be
		/// used by the SalesPersonQuotaHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the SalesPersonQuotaHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<SalesPersonQuotaHistory, SalesPersonQuotaHistoryKey> GetNewDataSourceView()
		{
			return new SalesPersonQuotaHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the SalesPersonQuotaHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalesPersonQuotaHistoryDataSourceView : ProviderDataSourceView<SalesPersonQuotaHistory, SalesPersonQuotaHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalesPersonQuotaHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalesPersonQuotaHistoryDataSourceView(SalesPersonQuotaHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalesPersonQuotaHistoryDataSource SalesPersonQuotaHistoryOwner
		{
			get { return Owner as SalesPersonQuotaHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalesPersonQuotaHistorySelectMethod SelectMethod
		{
			get { return SalesPersonQuotaHistoryOwner.SelectMethod; }
			set { SalesPersonQuotaHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalesPersonQuotaHistoryService SalesPersonQuotaHistoryProvider
		{
			get { return Provider as SalesPersonQuotaHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalesPersonQuotaHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalesPersonQuotaHistory> results = null;
			SalesPersonQuotaHistory item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _salesPersonId;
			System.DateTime _quotaDate;

			switch ( SelectMethod )
			{
				case SalesPersonQuotaHistorySelectMethod.Get:
					SalesPersonQuotaHistoryKey entityKey  = new SalesPersonQuotaHistoryKey();
					entityKey.Load(values);
					item = SalesPersonQuotaHistoryProvider.Get(entityKey);
					results = new TList<SalesPersonQuotaHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesPersonQuotaHistorySelectMethod.GetAll:
                    results = SalesPersonQuotaHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalesPersonQuotaHistorySelectMethod.GetPaged:
					results = SalesPersonQuotaHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalesPersonQuotaHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = SalesPersonQuotaHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalesPersonQuotaHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalesPersonQuotaHistorySelectMethod.GetBySalesPersonIdQuotaDate:
					_salesPersonId = ( values["SalesPersonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32)) : (int)0;
					_quotaDate = ( values["QuotaDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["QuotaDate"], typeof(System.DateTime)) : DateTime.MinValue;
					item = SalesPersonQuotaHistoryProvider.GetBySalesPersonIdQuotaDate(_salesPersonId, _quotaDate);
					results = new TList<SalesPersonQuotaHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SalesPersonQuotaHistorySelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = SalesPersonQuotaHistoryProvider.GetByRowguid(_rowguid);
					results = new TList<SalesPersonQuotaHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case SalesPersonQuotaHistorySelectMethod.GetBySalesPersonId:
					_salesPersonId = ( values["SalesPersonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32)) : (int)0;
					results = SalesPersonQuotaHistoryProvider.GetBySalesPersonId(_salesPersonId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SalesPersonQuotaHistorySelectMethod.Get || SelectMethod == SalesPersonQuotaHistorySelectMethod.GetBySalesPersonIdQuotaDate )
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
				SalesPersonQuotaHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalesPersonQuotaHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalesPersonQuotaHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalesPersonQuotaHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalesPersonQuotaHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalesPersonQuotaHistoryDataSource class.
	/// </summary>
	public class SalesPersonQuotaHistoryDataSourceDesigner : ProviderDataSourceDesigner<SalesPersonQuotaHistory, SalesPersonQuotaHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryDataSourceDesigner class.
		/// </summary>
		public SalesPersonQuotaHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesPersonQuotaHistorySelectMethod SelectMethod
		{
			get { return ((SalesPersonQuotaHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalesPersonQuotaHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalesPersonQuotaHistoryDataSourceActionList

	/// <summary>
	/// Supports the SalesPersonQuotaHistoryDataSourceDesigner class.
	/// </summary>
	internal class SalesPersonQuotaHistoryDataSourceActionList : DesignerActionList
	{
		private SalesPersonQuotaHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalesPersonQuotaHistoryDataSourceActionList(SalesPersonQuotaHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesPersonQuotaHistorySelectMethod SelectMethod
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

	#endregion SalesPersonQuotaHistoryDataSourceActionList
	
	#endregion SalesPersonQuotaHistoryDataSourceDesigner
	
	#region SalesPersonQuotaHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalesPersonQuotaHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum SalesPersonQuotaHistorySelectMethod
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
		/// Represents the GetBySalesPersonIdQuotaDate method.
		/// </summary>
		GetBySalesPersonIdQuotaDate,
		/// <summary>
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId
	}
	
	#endregion SalesPersonQuotaHistorySelectMethod

	#region SalesPersonQuotaHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPersonQuotaHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuotaHistoryFilter : SqlFilter<SalesPersonQuotaHistoryColumn>
	{
	}
	
	#endregion SalesPersonQuotaHistoryFilter

	#region SalesPersonQuotaHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPersonQuotaHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuotaHistoryExpressionBuilder : SqlExpressionBuilder<SalesPersonQuotaHistoryColumn>
	{
	}
	
	#endregion SalesPersonQuotaHistoryExpressionBuilder	

	#region SalesPersonQuotaHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalesPersonQuotaHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPersonQuotaHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuotaHistoryProperty : ChildEntityProperty<SalesPersonQuotaHistoryChildEntityTypes>
	{
	}
	
	#endregion SalesPersonQuotaHistoryProperty
}

