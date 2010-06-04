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
	/// Represents the DataRepository.EmployeePayHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmployeePayHistoryDataSourceDesigner))]
	public class EmployeePayHistoryDataSource : ProviderDataSource<EmployeePayHistory, EmployeePayHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryDataSource class.
		/// </summary>
		public EmployeePayHistoryDataSource() : base(new EmployeePayHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmployeePayHistoryDataSourceView used by the EmployeePayHistoryDataSource.
		/// </summary>
		protected EmployeePayHistoryDataSourceView EmployeePayHistoryView
		{
			get { return ( View as EmployeePayHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmployeePayHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public EmployeePayHistorySelectMethod SelectMethod
		{
			get
			{
				EmployeePayHistorySelectMethod selectMethod = EmployeePayHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmployeePayHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmployeePayHistoryDataSourceView class that is to be
		/// used by the EmployeePayHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the EmployeePayHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<EmployeePayHistory, EmployeePayHistoryKey> GetNewDataSourceView()
		{
			return new EmployeePayHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the EmployeePayHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmployeePayHistoryDataSourceView : ProviderDataSourceView<EmployeePayHistory, EmployeePayHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmployeePayHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmployeePayHistoryDataSourceView(EmployeePayHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmployeePayHistoryDataSource EmployeePayHistoryOwner
		{
			get { return Owner as EmployeePayHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmployeePayHistorySelectMethod SelectMethod
		{
			get { return EmployeePayHistoryOwner.SelectMethod; }
			set { EmployeePayHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmployeePayHistoryService EmployeePayHistoryProvider
		{
			get { return Provider as EmployeePayHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmployeePayHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmployeePayHistory> results = null;
			EmployeePayHistory item;
			count = 0;
			
			System.Int32 _employeeId;
			System.DateTime _rateChangeDate;

			switch ( SelectMethod )
			{
				case EmployeePayHistorySelectMethod.Get:
					EmployeePayHistoryKey entityKey  = new EmployeePayHistoryKey();
					entityKey.Load(values);
					item = EmployeePayHistoryProvider.Get(entityKey);
					results = new TList<EmployeePayHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeePayHistorySelectMethod.GetAll:
                    results = EmployeePayHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmployeePayHistorySelectMethod.GetPaged:
					results = EmployeePayHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmployeePayHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = EmployeePayHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmployeePayHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmployeePayHistorySelectMethod.GetByEmployeeIdRateChangeDate:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					_rateChangeDate = ( values["RateChangeDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["RateChangeDate"], typeof(System.DateTime)) : DateTime.MinValue;
					item = EmployeePayHistoryProvider.GetByEmployeeIdRateChangeDate(_employeeId, _rateChangeDate);
					results = new TList<EmployeePayHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case EmployeePayHistorySelectMethod.GetByEmployeeId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					results = EmployeePayHistoryProvider.GetByEmployeeId(_employeeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EmployeePayHistorySelectMethod.Get || SelectMethod == EmployeePayHistorySelectMethod.GetByEmployeeIdRateChangeDate )
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
				EmployeePayHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmployeePayHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmployeePayHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmployeePayHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmployeePayHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmployeePayHistoryDataSource class.
	/// </summary>
	public class EmployeePayHistoryDataSourceDesigner : ProviderDataSourceDesigner<EmployeePayHistory, EmployeePayHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryDataSourceDesigner class.
		/// </summary>
		public EmployeePayHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeePayHistorySelectMethod SelectMethod
		{
			get { return ((EmployeePayHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmployeePayHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmployeePayHistoryDataSourceActionList

	/// <summary>
	/// Supports the EmployeePayHistoryDataSourceDesigner class.
	/// </summary>
	internal class EmployeePayHistoryDataSourceActionList : DesignerActionList
	{
		private EmployeePayHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmployeePayHistoryDataSourceActionList(EmployeePayHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeePayHistorySelectMethod SelectMethod
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

	#endregion EmployeePayHistoryDataSourceActionList
	
	#endregion EmployeePayHistoryDataSourceDesigner
	
	#region EmployeePayHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmployeePayHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum EmployeePayHistorySelectMethod
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
		/// Represents the GetByEmployeeIdRateChangeDate method.
		/// </summary>
		GetByEmployeeIdRateChangeDate,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId
	}
	
	#endregion EmployeePayHistorySelectMethod

	#region EmployeePayHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeePayHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeePayHistoryFilter : SqlFilter<EmployeePayHistoryColumn>
	{
	}
	
	#endregion EmployeePayHistoryFilter

	#region EmployeePayHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeePayHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeePayHistoryExpressionBuilder : SqlExpressionBuilder<EmployeePayHistoryColumn>
	{
	}
	
	#endregion EmployeePayHistoryExpressionBuilder	

	#region EmployeePayHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmployeePayHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeePayHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeePayHistoryProperty : ChildEntityProperty<EmployeePayHistoryChildEntityTypes>
	{
	}
	
	#endregion EmployeePayHistoryProperty
}

