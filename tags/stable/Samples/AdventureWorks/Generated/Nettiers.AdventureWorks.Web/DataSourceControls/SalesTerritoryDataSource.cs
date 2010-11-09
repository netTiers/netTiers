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
	/// Represents the DataRepository.SalesTerritoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalesTerritoryDataSourceDesigner))]
	public class SalesTerritoryDataSource : ProviderDataSource<SalesTerritory, SalesTerritoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryDataSource class.
		/// </summary>
		public SalesTerritoryDataSource() : base(new SalesTerritoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalesTerritoryDataSourceView used by the SalesTerritoryDataSource.
		/// </summary>
		protected SalesTerritoryDataSourceView SalesTerritoryView
		{
			get { return ( View as SalesTerritoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalesTerritoryDataSource control invokes to retrieve data.
		/// </summary>
		public SalesTerritorySelectMethod SelectMethod
		{
			get
			{
				SalesTerritorySelectMethod selectMethod = SalesTerritorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalesTerritorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalesTerritoryDataSourceView class that is to be
		/// used by the SalesTerritoryDataSource.
		/// </summary>
		/// <returns>An instance of the SalesTerritoryDataSourceView class.</returns>
		protected override BaseDataSourceView<SalesTerritory, SalesTerritoryKey> GetNewDataSourceView()
		{
			return new SalesTerritoryDataSourceView(this, DefaultViewName);
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
	/// Supports the SalesTerritoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalesTerritoryDataSourceView : ProviderDataSourceView<SalesTerritory, SalesTerritoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalesTerritoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalesTerritoryDataSourceView(SalesTerritoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalesTerritoryDataSource SalesTerritoryOwner
		{
			get { return Owner as SalesTerritoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalesTerritorySelectMethod SelectMethod
		{
			get { return SalesTerritoryOwner.SelectMethod; }
			set { SalesTerritoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalesTerritoryService SalesTerritoryProvider
		{
			get { return Provider as SalesTerritoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalesTerritory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalesTerritory> results = null;
			SalesTerritory item;
			count = 0;
			
			System.String _name;
			System.Guid _rowguid;
			System.Int32 _territoryId;

			switch ( SelectMethod )
			{
				case SalesTerritorySelectMethod.Get:
					SalesTerritoryKey entityKey  = new SalesTerritoryKey();
					entityKey.Load(values);
					item = SalesTerritoryProvider.Get(entityKey);
					results = new TList<SalesTerritory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesTerritorySelectMethod.GetAll:
                    results = SalesTerritoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalesTerritorySelectMethod.GetPaged:
					results = SalesTerritoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalesTerritorySelectMethod.Find:
					if ( FilterParameters != null )
						results = SalesTerritoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalesTerritoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalesTerritorySelectMethod.GetByTerritoryId:
					_territoryId = ( values["TerritoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TerritoryId"], typeof(System.Int32)) : (int)0;
					item = SalesTerritoryProvider.GetByTerritoryId(_territoryId);
					results = new TList<SalesTerritory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SalesTerritorySelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = SalesTerritoryProvider.GetByName(_name);
					results = new TList<SalesTerritory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesTerritorySelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = SalesTerritoryProvider.GetByRowguid(_rowguid);
					results = new TList<SalesTerritory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
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
			if ( SelectMethod == SalesTerritorySelectMethod.Get || SelectMethod == SalesTerritorySelectMethod.GetByTerritoryId )
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
				SalesTerritory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalesTerritoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalesTerritory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalesTerritoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalesTerritoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalesTerritoryDataSource class.
	/// </summary>
	public class SalesTerritoryDataSourceDesigner : ProviderDataSourceDesigner<SalesTerritory, SalesTerritoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalesTerritoryDataSourceDesigner class.
		/// </summary>
		public SalesTerritoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesTerritorySelectMethod SelectMethod
		{
			get { return ((SalesTerritoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalesTerritoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalesTerritoryDataSourceActionList

	/// <summary>
	/// Supports the SalesTerritoryDataSourceDesigner class.
	/// </summary>
	internal class SalesTerritoryDataSourceActionList : DesignerActionList
	{
		private SalesTerritoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalesTerritoryDataSourceActionList(SalesTerritoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesTerritorySelectMethod SelectMethod
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

	#endregion SalesTerritoryDataSourceActionList
	
	#endregion SalesTerritoryDataSourceDesigner
	
	#region SalesTerritorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalesTerritoryDataSource.SelectMethod property.
	/// </summary>
	public enum SalesTerritorySelectMethod
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
		/// Represents the GetByTerritoryId method.
		/// </summary>
		GetByTerritoryId
	}
	
	#endregion SalesTerritorySelectMethod

	#region SalesTerritoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryFilter : SqlFilter<SalesTerritoryColumn>
	{
	}
	
	#endregion SalesTerritoryFilter

	#region SalesTerritoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryExpressionBuilder : SqlExpressionBuilder<SalesTerritoryColumn>
	{
	}
	
	#endregion SalesTerritoryExpressionBuilder	

	#region SalesTerritoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalesTerritoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryProperty : ChildEntityProperty<SalesTerritoryChildEntityTypes>
	{
	}
	
	#endregion SalesTerritoryProperty
}

