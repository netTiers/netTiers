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
	/// Represents the DataRepository.CountryRegionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CountryRegionDataSourceDesigner))]
	public class CountryRegionDataSource : ProviderDataSource<CountryRegion, CountryRegionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionDataSource class.
		/// </summary>
		public CountryRegionDataSource() : base(new CountryRegionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CountryRegionDataSourceView used by the CountryRegionDataSource.
		/// </summary>
		protected CountryRegionDataSourceView CountryRegionView
		{
			get { return ( View as CountryRegionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CountryRegionDataSource control invokes to retrieve data.
		/// </summary>
		public CountryRegionSelectMethod SelectMethod
		{
			get
			{
				CountryRegionSelectMethod selectMethod = CountryRegionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CountryRegionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CountryRegionDataSourceView class that is to be
		/// used by the CountryRegionDataSource.
		/// </summary>
		/// <returns>An instance of the CountryRegionDataSourceView class.</returns>
		protected override BaseDataSourceView<CountryRegion, CountryRegionKey> GetNewDataSourceView()
		{
			return new CountryRegionDataSourceView(this, DefaultViewName);
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
	/// Supports the CountryRegionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CountryRegionDataSourceView : ProviderDataSourceView<CountryRegion, CountryRegionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CountryRegionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CountryRegionDataSourceView(CountryRegionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CountryRegionDataSource CountryRegionOwner
		{
			get { return Owner as CountryRegionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CountryRegionSelectMethod SelectMethod
		{
			get { return CountryRegionOwner.SelectMethod; }
			set { CountryRegionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CountryRegionService CountryRegionProvider
		{
			get { return Provider as CountryRegionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CountryRegion> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CountryRegion> results = null;
			CountryRegion item;
			count = 0;
			
			System.String _name;
			System.String _countryRegionCode;
			System.String _currencyCode;

			switch ( SelectMethod )
			{
				case CountryRegionSelectMethod.Get:
					CountryRegionKey entityKey  = new CountryRegionKey();
					entityKey.Load(values);
					item = CountryRegionProvider.Get(entityKey);
					results = new TList<CountryRegion>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CountryRegionSelectMethod.GetAll:
                    results = CountryRegionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CountryRegionSelectMethod.GetPaged:
					results = CountryRegionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CountryRegionSelectMethod.Find:
					if ( FilterParameters != null )
						results = CountryRegionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CountryRegionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CountryRegionSelectMethod.GetByCountryRegionCode:
					_countryRegionCode = ( values["CountryRegionCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryRegionCode"], typeof(System.String)) : string.Empty;
					item = CountryRegionProvider.GetByCountryRegionCode(_countryRegionCode);
					results = new TList<CountryRegion>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CountryRegionSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = CountryRegionProvider.GetByName(_name);
					results = new TList<CountryRegion>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case CountryRegionSelectMethod.GetByCurrencyCodeFromCountryRegionCurrency:
					_currencyCode = ( values["CurrencyCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CurrencyCode"], typeof(System.String)) : string.Empty;
					results = CountryRegionProvider.GetByCurrencyCodeFromCountryRegionCurrency(_currencyCode, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CountryRegionSelectMethod.Get || SelectMethod == CountryRegionSelectMethod.GetByCountryRegionCode )
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
				CountryRegion entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CountryRegionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CountryRegion> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CountryRegionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CountryRegionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CountryRegionDataSource class.
	/// </summary>
	public class CountryRegionDataSourceDesigner : ProviderDataSourceDesigner<CountryRegion, CountryRegionKey>
	{
		/// <summary>
		/// Initializes a new instance of the CountryRegionDataSourceDesigner class.
		/// </summary>
		public CountryRegionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CountryRegionSelectMethod SelectMethod
		{
			get { return ((CountryRegionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CountryRegionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CountryRegionDataSourceActionList

	/// <summary>
	/// Supports the CountryRegionDataSourceDesigner class.
	/// </summary>
	internal class CountryRegionDataSourceActionList : DesignerActionList
	{
		private CountryRegionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CountryRegionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CountryRegionDataSourceActionList(CountryRegionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CountryRegionSelectMethod SelectMethod
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

	#endregion CountryRegionDataSourceActionList
	
	#endregion CountryRegionDataSourceDesigner
	
	#region CountryRegionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CountryRegionDataSource.SelectMethod property.
	/// </summary>
	public enum CountryRegionSelectMethod
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
		/// Represents the GetByCountryRegionCode method.
		/// </summary>
		GetByCountryRegionCode,
		/// <summary>
		/// Represents the GetByCurrencyCodeFromCountryRegionCurrency method.
		/// </summary>
		GetByCurrencyCodeFromCountryRegionCurrency
	}
	
	#endregion CountryRegionSelectMethod

	#region CountryRegionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionFilter : SqlFilter<CountryRegionColumn>
	{
	}
	
	#endregion CountryRegionFilter

	#region CountryRegionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionExpressionBuilder : SqlExpressionBuilder<CountryRegionColumn>
	{
	}
	
	#endregion CountryRegionExpressionBuilder	

	#region CountryRegionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CountryRegionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionProperty : ChildEntityProperty<CountryRegionChildEntityTypes>
	{
	}
	
	#endregion CountryRegionProperty
}

