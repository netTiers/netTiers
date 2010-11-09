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
	/// Represents the DataRepository.CurrencyProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CurrencyDataSourceDesigner))]
	public class CurrencyDataSource : ProviderDataSource<Currency, CurrencyKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyDataSource class.
		/// </summary>
		public CurrencyDataSource() : base(new CurrencyService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CurrencyDataSourceView used by the CurrencyDataSource.
		/// </summary>
		protected CurrencyDataSourceView CurrencyView
		{
			get { return ( View as CurrencyDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CurrencyDataSource control invokes to retrieve data.
		/// </summary>
		public CurrencySelectMethod SelectMethod
		{
			get
			{
				CurrencySelectMethod selectMethod = CurrencySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CurrencySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CurrencyDataSourceView class that is to be
		/// used by the CurrencyDataSource.
		/// </summary>
		/// <returns>An instance of the CurrencyDataSourceView class.</returns>
		protected override BaseDataSourceView<Currency, CurrencyKey> GetNewDataSourceView()
		{
			return new CurrencyDataSourceView(this, DefaultViewName);
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
	/// Supports the CurrencyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CurrencyDataSourceView : ProviderDataSourceView<Currency, CurrencyKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CurrencyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CurrencyDataSourceView(CurrencyDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CurrencyDataSource CurrencyOwner
		{
			get { return Owner as CurrencyDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CurrencySelectMethod SelectMethod
		{
			get { return CurrencyOwner.SelectMethod; }
			set { CurrencyOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CurrencyService CurrencyProvider
		{
			get { return Provider as CurrencyService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Currency> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Currency> results = null;
			Currency item;
			count = 0;
			
			System.String _name;
			System.String _currencyCode;
			System.String _countryRegionCode;

			switch ( SelectMethod )
			{
				case CurrencySelectMethod.Get:
					CurrencyKey entityKey  = new CurrencyKey();
					entityKey.Load(values);
					item = CurrencyProvider.Get(entityKey);
					results = new TList<Currency>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CurrencySelectMethod.GetAll:
                    results = CurrencyProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CurrencySelectMethod.GetPaged:
					results = CurrencyProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CurrencySelectMethod.Find:
					if ( FilterParameters != null )
						results = CurrencyProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CurrencyProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CurrencySelectMethod.GetByCurrencyCode:
					_currencyCode = ( values["CurrencyCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CurrencyCode"], typeof(System.String)) : string.Empty;
					item = CurrencyProvider.GetByCurrencyCode(_currencyCode);
					results = new TList<Currency>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CurrencySelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = CurrencyProvider.GetByName(_name);
					results = new TList<Currency>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case CurrencySelectMethod.GetByCountryRegionCodeFromCountryRegionCurrency:
					_countryRegionCode = ( values["CountryRegionCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryRegionCode"], typeof(System.String)) : string.Empty;
					results = CurrencyProvider.GetByCountryRegionCodeFromCountryRegionCurrency(_countryRegionCode, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CurrencySelectMethod.Get || SelectMethod == CurrencySelectMethod.GetByCurrencyCode )
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
				Currency entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CurrencyProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Currency> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CurrencyProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CurrencyDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CurrencyDataSource class.
	/// </summary>
	public class CurrencyDataSourceDesigner : ProviderDataSourceDesigner<Currency, CurrencyKey>
	{
		/// <summary>
		/// Initializes a new instance of the CurrencyDataSourceDesigner class.
		/// </summary>
		public CurrencyDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CurrencySelectMethod SelectMethod
		{
			get { return ((CurrencyDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CurrencyDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CurrencyDataSourceActionList

	/// <summary>
	/// Supports the CurrencyDataSourceDesigner class.
	/// </summary>
	internal class CurrencyDataSourceActionList : DesignerActionList
	{
		private CurrencyDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CurrencyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CurrencyDataSourceActionList(CurrencyDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CurrencySelectMethod SelectMethod
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

	#endregion CurrencyDataSourceActionList
	
	#endregion CurrencyDataSourceDesigner
	
	#region CurrencySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CurrencyDataSource.SelectMethod property.
	/// </summary>
	public enum CurrencySelectMethod
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
		/// Represents the GetByCurrencyCode method.
		/// </summary>
		GetByCurrencyCode,
		/// <summary>
		/// Represents the GetByCountryRegionCodeFromCountryRegionCurrency method.
		/// </summary>
		GetByCountryRegionCodeFromCountryRegionCurrency
	}
	
	#endregion CurrencySelectMethod

	#region CurrencyFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyFilter : SqlFilter<CurrencyColumn>
	{
	}
	
	#endregion CurrencyFilter

	#region CurrencyExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyExpressionBuilder : SqlExpressionBuilder<CurrencyColumn>
	{
	}
	
	#endregion CurrencyExpressionBuilder	

	#region CurrencyProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CurrencyChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyProperty : ChildEntityProperty<CurrencyChildEntityTypes>
	{
	}
	
	#endregion CurrencyProperty
}

