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
	/// Represents the DataRepository.StateProvinceProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(StateProvinceDataSourceDesigner))]
	public class StateProvinceDataSource : ProviderDataSource<StateProvince, StateProvinceKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateProvinceDataSource class.
		/// </summary>
		public StateProvinceDataSource() : base(new StateProvinceService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the StateProvinceDataSourceView used by the StateProvinceDataSource.
		/// </summary>
		protected StateProvinceDataSourceView StateProvinceView
		{
			get { return ( View as StateProvinceDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the StateProvinceDataSource control invokes to retrieve data.
		/// </summary>
		public StateProvinceSelectMethod SelectMethod
		{
			get
			{
				StateProvinceSelectMethod selectMethod = StateProvinceSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (StateProvinceSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the StateProvinceDataSourceView class that is to be
		/// used by the StateProvinceDataSource.
		/// </summary>
		/// <returns>An instance of the StateProvinceDataSourceView class.</returns>
		protected override BaseDataSourceView<StateProvince, StateProvinceKey> GetNewDataSourceView()
		{
			return new StateProvinceDataSourceView(this, DefaultViewName);
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
	/// Supports the StateProvinceDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class StateProvinceDataSourceView : ProviderDataSourceView<StateProvince, StateProvinceKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateProvinceDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the StateProvinceDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public StateProvinceDataSourceView(StateProvinceDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal StateProvinceDataSource StateProvinceOwner
		{
			get { return Owner as StateProvinceDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal StateProvinceSelectMethod SelectMethod
		{
			get { return StateProvinceOwner.SelectMethod; }
			set { StateProvinceOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal StateProvinceService StateProvinceProvider
		{
			get { return Provider as StateProvinceService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<StateProvince> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<StateProvince> results = null;
			StateProvince item;
			count = 0;
			
			System.String _name;
			System.Guid _rowguid;
			System.String _stateProvinceCode;
			System.String _countryRegionCode;
			System.Int32 _stateProvinceId;
			System.Int32 _territoryId;

			switch ( SelectMethod )
			{
				case StateProvinceSelectMethod.Get:
					StateProvinceKey entityKey  = new StateProvinceKey();
					entityKey.Load(values);
					item = StateProvinceProvider.Get(entityKey);
					results = new TList<StateProvince>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StateProvinceSelectMethod.GetAll:
                    results = StateProvinceProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case StateProvinceSelectMethod.GetPaged:
					results = StateProvinceProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case StateProvinceSelectMethod.Find:
					if ( FilterParameters != null )
						results = StateProvinceProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = StateProvinceProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case StateProvinceSelectMethod.GetByStateProvinceId:
					_stateProvinceId = ( values["StateProvinceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StateProvinceId"], typeof(System.Int32)) : (int)0;
					item = StateProvinceProvider.GetByStateProvinceId(_stateProvinceId);
					results = new TList<StateProvince>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case StateProvinceSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = StateProvinceProvider.GetByName(_name);
					results = new TList<StateProvince>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StateProvinceSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = StateProvinceProvider.GetByRowguid(_rowguid);
					results = new TList<StateProvince>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StateProvinceSelectMethod.GetByStateProvinceCodeCountryRegionCode:
					_stateProvinceCode = ( values["StateProvinceCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["StateProvinceCode"], typeof(System.String)) : string.Empty;
					_countryRegionCode = ( values["CountryRegionCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryRegionCode"], typeof(System.String)) : string.Empty;
					item = StateProvinceProvider.GetByStateProvinceCodeCountryRegionCode(_stateProvinceCode, _countryRegionCode);
					results = new TList<StateProvince>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case StateProvinceSelectMethod.GetByCountryRegionCode:
					_countryRegionCode = ( values["CountryRegionCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryRegionCode"], typeof(System.String)) : string.Empty;
					results = StateProvinceProvider.GetByCountryRegionCode(_countryRegionCode, this.StartIndex, this.PageSize, out count);
					break;
				case StateProvinceSelectMethod.GetByTerritoryId:
					_territoryId = ( values["TerritoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TerritoryId"], typeof(System.Int32)) : (int)0;
					results = StateProvinceProvider.GetByTerritoryId(_territoryId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == StateProvinceSelectMethod.Get || SelectMethod == StateProvinceSelectMethod.GetByStateProvinceId )
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
				StateProvince entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					StateProvinceProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<StateProvince> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			StateProvinceProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region StateProvinceDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the StateProvinceDataSource class.
	/// </summary>
	public class StateProvinceDataSourceDesigner : ProviderDataSourceDesigner<StateProvince, StateProvinceKey>
	{
		/// <summary>
		/// Initializes a new instance of the StateProvinceDataSourceDesigner class.
		/// </summary>
		public StateProvinceDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StateProvinceSelectMethod SelectMethod
		{
			get { return ((StateProvinceDataSource) DataSource).SelectMethod; }
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
				actions.Add(new StateProvinceDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region StateProvinceDataSourceActionList

	/// <summary>
	/// Supports the StateProvinceDataSourceDesigner class.
	/// </summary>
	internal class StateProvinceDataSourceActionList : DesignerActionList
	{
		private StateProvinceDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the StateProvinceDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public StateProvinceDataSourceActionList(StateProvinceDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StateProvinceSelectMethod SelectMethod
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

	#endregion StateProvinceDataSourceActionList
	
	#endregion StateProvinceDataSourceDesigner
	
	#region StateProvinceSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the StateProvinceDataSource.SelectMethod property.
	/// </summary>
	public enum StateProvinceSelectMethod
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
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByStateProvinceCodeCountryRegionCode method.
		/// </summary>
		GetByStateProvinceCodeCountryRegionCode,
		/// <summary>
		/// Represents the GetByStateProvinceId method.
		/// </summary>
		GetByStateProvinceId,
		/// <summary>
		/// Represents the GetByCountryRegionCode method.
		/// </summary>
		GetByCountryRegionCode,
		/// <summary>
		/// Represents the GetByTerritoryId method.
		/// </summary>
		GetByTerritoryId
	}
	
	#endregion StateProvinceSelectMethod

	#region StateProvinceFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StateProvince"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateProvinceFilter : SqlFilter<StateProvinceColumn>
	{
	}
	
	#endregion StateProvinceFilter

	#region StateProvinceExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StateProvince"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateProvinceExpressionBuilder : SqlExpressionBuilder<StateProvinceColumn>
	{
	}
	
	#endregion StateProvinceExpressionBuilder	

	#region StateProvinceProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;StateProvinceChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="StateProvince"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateProvinceProperty : ChildEntityProperty<StateProvinceChildEntityTypes>
	{
	}
	
	#endregion StateProvinceProperty
}

