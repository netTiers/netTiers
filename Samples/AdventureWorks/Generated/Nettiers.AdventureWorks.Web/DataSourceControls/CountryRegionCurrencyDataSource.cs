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
	/// Represents the DataRepository.CountryRegionCurrencyProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CountryRegionCurrencyDataSourceDesigner))]
	public class CountryRegionCurrencyDataSource : ProviderDataSource<CountryRegionCurrency, CountryRegionCurrencyKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyDataSource class.
		/// </summary>
		public CountryRegionCurrencyDataSource() : base(new CountryRegionCurrencyService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CountryRegionCurrencyDataSourceView used by the CountryRegionCurrencyDataSource.
		/// </summary>
		protected CountryRegionCurrencyDataSourceView CountryRegionCurrencyView
		{
			get { return ( View as CountryRegionCurrencyDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CountryRegionCurrencyDataSource control invokes to retrieve data.
		/// </summary>
		public CountryRegionCurrencySelectMethod SelectMethod
		{
			get
			{
				CountryRegionCurrencySelectMethod selectMethod = CountryRegionCurrencySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CountryRegionCurrencySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CountryRegionCurrencyDataSourceView class that is to be
		/// used by the CountryRegionCurrencyDataSource.
		/// </summary>
		/// <returns>An instance of the CountryRegionCurrencyDataSourceView class.</returns>
		protected override BaseDataSourceView<CountryRegionCurrency, CountryRegionCurrencyKey> GetNewDataSourceView()
		{
			return new CountryRegionCurrencyDataSourceView(this, DefaultViewName);
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
	/// Supports the CountryRegionCurrencyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CountryRegionCurrencyDataSourceView : ProviderDataSourceView<CountryRegionCurrency, CountryRegionCurrencyKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CountryRegionCurrencyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CountryRegionCurrencyDataSourceView(CountryRegionCurrencyDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CountryRegionCurrencyDataSource CountryRegionCurrencyOwner
		{
			get { return Owner as CountryRegionCurrencyDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CountryRegionCurrencySelectMethod SelectMethod
		{
			get { return CountryRegionCurrencyOwner.SelectMethod; }
			set { CountryRegionCurrencyOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CountryRegionCurrencyService CountryRegionCurrencyProvider
		{
			get { return Provider as CountryRegionCurrencyService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CountryRegionCurrency> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CountryRegionCurrency> results = null;
			CountryRegionCurrency item;
			count = 0;
			
			System.String _currencyCode;
			System.String _countryRegionCode;

			switch ( SelectMethod )
			{
				case CountryRegionCurrencySelectMethod.Get:
					CountryRegionCurrencyKey entityKey  = new CountryRegionCurrencyKey();
					entityKey.Load(values);
					item = CountryRegionCurrencyProvider.Get(entityKey);
					results = new TList<CountryRegionCurrency>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CountryRegionCurrencySelectMethod.GetAll:
                    results = CountryRegionCurrencyProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CountryRegionCurrencySelectMethod.GetPaged:
					results = CountryRegionCurrencyProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CountryRegionCurrencySelectMethod.Find:
					if ( FilterParameters != null )
						results = CountryRegionCurrencyProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CountryRegionCurrencyProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CountryRegionCurrencySelectMethod.GetByCountryRegionCodeCurrencyCode:
					_countryRegionCode = ( values["CountryRegionCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryRegionCode"], typeof(System.String)) : string.Empty;
					_currencyCode = ( values["CurrencyCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CurrencyCode"], typeof(System.String)) : string.Empty;
					item = CountryRegionCurrencyProvider.GetByCountryRegionCodeCurrencyCode(_countryRegionCode, _currencyCode);
					results = new TList<CountryRegionCurrency>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CountryRegionCurrencySelectMethod.GetByCurrencyCode:
					_currencyCode = ( values["CurrencyCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CurrencyCode"], typeof(System.String)) : string.Empty;
					results = CountryRegionCurrencyProvider.GetByCurrencyCode(_currencyCode, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case CountryRegionCurrencySelectMethod.GetByCountryRegionCode:
					_countryRegionCode = ( values["CountryRegionCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryRegionCode"], typeof(System.String)) : string.Empty;
					results = CountryRegionCurrencyProvider.GetByCountryRegionCode(_countryRegionCode, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CountryRegionCurrencySelectMethod.Get || SelectMethod == CountryRegionCurrencySelectMethod.GetByCountryRegionCodeCurrencyCode )
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
				CountryRegionCurrency entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CountryRegionCurrencyProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CountryRegionCurrency> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CountryRegionCurrencyProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CountryRegionCurrencyDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CountryRegionCurrencyDataSource class.
	/// </summary>
	public class CountryRegionCurrencyDataSourceDesigner : ProviderDataSourceDesigner<CountryRegionCurrency, CountryRegionCurrencyKey>
	{
		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyDataSourceDesigner class.
		/// </summary>
		public CountryRegionCurrencyDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CountryRegionCurrencySelectMethod SelectMethod
		{
			get { return ((CountryRegionCurrencyDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CountryRegionCurrencyDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CountryRegionCurrencyDataSourceActionList

	/// <summary>
	/// Supports the CountryRegionCurrencyDataSourceDesigner class.
	/// </summary>
	internal class CountryRegionCurrencyDataSourceActionList : DesignerActionList
	{
		private CountryRegionCurrencyDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CountryRegionCurrencyDataSourceActionList(CountryRegionCurrencyDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CountryRegionCurrencySelectMethod SelectMethod
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

	#endregion CountryRegionCurrencyDataSourceActionList
	
	#endregion CountryRegionCurrencyDataSourceDesigner
	
	#region CountryRegionCurrencySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CountryRegionCurrencyDataSource.SelectMethod property.
	/// </summary>
	public enum CountryRegionCurrencySelectMethod
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
		/// Represents the GetByCurrencyCode method.
		/// </summary>
		GetByCurrencyCode,
		/// <summary>
		/// Represents the GetByCountryRegionCodeCurrencyCode method.
		/// </summary>
		GetByCountryRegionCodeCurrencyCode,
		/// <summary>
		/// Represents the GetByCountryRegionCode method.
		/// </summary>
		GetByCountryRegionCode
	}
	
	#endregion CountryRegionCurrencySelectMethod

	#region CountryRegionCurrencyFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegionCurrency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionCurrencyFilter : SqlFilter<CountryRegionCurrencyColumn>
	{
	}
	
	#endregion CountryRegionCurrencyFilter

	#region CountryRegionCurrencyExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegionCurrency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionCurrencyExpressionBuilder : SqlExpressionBuilder<CountryRegionCurrencyColumn>
	{
	}
	
	#endregion CountryRegionCurrencyExpressionBuilder	

	#region CountryRegionCurrencyProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CountryRegionCurrencyChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegionCurrency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionCurrencyProperty : ChildEntityProperty<CountryRegionCurrencyChildEntityTypes>
	{
	}
	
	#endregion CountryRegionCurrencyProperty
}

