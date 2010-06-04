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
	/// Represents the DataRepository.CurrencyRateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CurrencyRateDataSourceDesigner))]
	public class CurrencyRateDataSource : ProviderDataSource<CurrencyRate, CurrencyRateKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyRateDataSource class.
		/// </summary>
		public CurrencyRateDataSource() : base(new CurrencyRateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CurrencyRateDataSourceView used by the CurrencyRateDataSource.
		/// </summary>
		protected CurrencyRateDataSourceView CurrencyRateView
		{
			get { return ( View as CurrencyRateDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CurrencyRateDataSource control invokes to retrieve data.
		/// </summary>
		public CurrencyRateSelectMethod SelectMethod
		{
			get
			{
				CurrencyRateSelectMethod selectMethod = CurrencyRateSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CurrencyRateSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CurrencyRateDataSourceView class that is to be
		/// used by the CurrencyRateDataSource.
		/// </summary>
		/// <returns>An instance of the CurrencyRateDataSourceView class.</returns>
		protected override BaseDataSourceView<CurrencyRate, CurrencyRateKey> GetNewDataSourceView()
		{
			return new CurrencyRateDataSourceView(this, DefaultViewName);
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
	/// Supports the CurrencyRateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CurrencyRateDataSourceView : ProviderDataSourceView<CurrencyRate, CurrencyRateKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyRateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CurrencyRateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CurrencyRateDataSourceView(CurrencyRateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CurrencyRateDataSource CurrencyRateOwner
		{
			get { return Owner as CurrencyRateDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CurrencyRateSelectMethod SelectMethod
		{
			get { return CurrencyRateOwner.SelectMethod; }
			set { CurrencyRateOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CurrencyRateService CurrencyRateProvider
		{
			get { return Provider as CurrencyRateService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CurrencyRate> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CurrencyRate> results = null;
			CurrencyRate item;
			count = 0;
			
			System.DateTime _currencyRateDate;
			System.String _fromCurrencyCode;
			System.String _toCurrencyCode;
			System.Int32 _currencyRateId;

			switch ( SelectMethod )
			{
				case CurrencyRateSelectMethod.Get:
					CurrencyRateKey entityKey  = new CurrencyRateKey();
					entityKey.Load(values);
					item = CurrencyRateProvider.Get(entityKey);
					results = new TList<CurrencyRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CurrencyRateSelectMethod.GetAll:
                    results = CurrencyRateProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CurrencyRateSelectMethod.GetPaged:
					results = CurrencyRateProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CurrencyRateSelectMethod.Find:
					if ( FilterParameters != null )
						results = CurrencyRateProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CurrencyRateProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CurrencyRateSelectMethod.GetByCurrencyRateId:
					_currencyRateId = ( values["CurrencyRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CurrencyRateId"], typeof(System.Int32)) : (int)0;
					item = CurrencyRateProvider.GetByCurrencyRateId(_currencyRateId);
					results = new TList<CurrencyRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CurrencyRateSelectMethod.GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode:
					_currencyRateDate = ( values["CurrencyRateDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["CurrencyRateDate"], typeof(System.DateTime)) : DateTime.MinValue;
					_fromCurrencyCode = ( values["FromCurrencyCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["FromCurrencyCode"], typeof(System.String)) : string.Empty;
					_toCurrencyCode = ( values["ToCurrencyCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["ToCurrencyCode"], typeof(System.String)) : string.Empty;
					item = CurrencyRateProvider.GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode(_currencyRateDate, _fromCurrencyCode, _toCurrencyCode);
					results = new TList<CurrencyRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case CurrencyRateSelectMethod.GetByFromCurrencyCode:
					_fromCurrencyCode = ( values["FromCurrencyCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["FromCurrencyCode"], typeof(System.String)) : string.Empty;
					results = CurrencyRateProvider.GetByFromCurrencyCode(_fromCurrencyCode, this.StartIndex, this.PageSize, out count);
					break;
				case CurrencyRateSelectMethod.GetByToCurrencyCode:
					_toCurrencyCode = ( values["ToCurrencyCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["ToCurrencyCode"], typeof(System.String)) : string.Empty;
					results = CurrencyRateProvider.GetByToCurrencyCode(_toCurrencyCode, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CurrencyRateSelectMethod.Get || SelectMethod == CurrencyRateSelectMethod.GetByCurrencyRateId )
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
				CurrencyRate entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CurrencyRateProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CurrencyRate> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CurrencyRateProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CurrencyRateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CurrencyRateDataSource class.
	/// </summary>
	public class CurrencyRateDataSourceDesigner : ProviderDataSourceDesigner<CurrencyRate, CurrencyRateKey>
	{
		/// <summary>
		/// Initializes a new instance of the CurrencyRateDataSourceDesigner class.
		/// </summary>
		public CurrencyRateDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CurrencyRateSelectMethod SelectMethod
		{
			get { return ((CurrencyRateDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CurrencyRateDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CurrencyRateDataSourceActionList

	/// <summary>
	/// Supports the CurrencyRateDataSourceDesigner class.
	/// </summary>
	internal class CurrencyRateDataSourceActionList : DesignerActionList
	{
		private CurrencyRateDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CurrencyRateDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CurrencyRateDataSourceActionList(CurrencyRateDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CurrencyRateSelectMethod SelectMethod
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

	#endregion CurrencyRateDataSourceActionList
	
	#endregion CurrencyRateDataSourceDesigner
	
	#region CurrencyRateSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CurrencyRateDataSource.SelectMethod property.
	/// </summary>
	public enum CurrencyRateSelectMethod
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
		/// Represents the GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode method.
		/// </summary>
		GetByCurrencyRateDateFromCurrencyCodeToCurrencyCode,
		/// <summary>
		/// Represents the GetByCurrencyRateId method.
		/// </summary>
		GetByCurrencyRateId,
		/// <summary>
		/// Represents the GetByFromCurrencyCode method.
		/// </summary>
		GetByFromCurrencyCode,
		/// <summary>
		/// Represents the GetByToCurrencyCode method.
		/// </summary>
		GetByToCurrencyCode
	}
	
	#endregion CurrencyRateSelectMethod

	#region CurrencyRateFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrencyRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyRateFilter : SqlFilter<CurrencyRateColumn>
	{
	}
	
	#endregion CurrencyRateFilter

	#region CurrencyRateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrencyRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyRateExpressionBuilder : SqlExpressionBuilder<CurrencyRateColumn>
	{
	}
	
	#endregion CurrencyRateExpressionBuilder	

	#region CurrencyRateProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CurrencyRateChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CurrencyRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyRateProperty : ChildEntityProperty<CurrencyRateChildEntityTypes>
	{
	}
	
	#endregion CurrencyRateProperty
}

