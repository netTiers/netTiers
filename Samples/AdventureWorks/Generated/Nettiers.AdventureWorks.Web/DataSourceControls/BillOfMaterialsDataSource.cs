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
	/// Represents the DataRepository.BillOfMaterialsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BillOfMaterialsDataSourceDesigner))]
	public class BillOfMaterialsDataSource : ProviderDataSource<BillOfMaterials, BillOfMaterialsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsDataSource class.
		/// </summary>
		public BillOfMaterialsDataSource() : base(new BillOfMaterialsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BillOfMaterialsDataSourceView used by the BillOfMaterialsDataSource.
		/// </summary>
		protected BillOfMaterialsDataSourceView BillOfMaterialsView
		{
			get { return ( View as BillOfMaterialsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BillOfMaterialsDataSource control invokes to retrieve data.
		/// </summary>
		public BillOfMaterialsSelectMethod SelectMethod
		{
			get
			{
				BillOfMaterialsSelectMethod selectMethod = BillOfMaterialsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BillOfMaterialsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BillOfMaterialsDataSourceView class that is to be
		/// used by the BillOfMaterialsDataSource.
		/// </summary>
		/// <returns>An instance of the BillOfMaterialsDataSourceView class.</returns>
		protected override BaseDataSourceView<BillOfMaterials, BillOfMaterialsKey> GetNewDataSourceView()
		{
			return new BillOfMaterialsDataSourceView(this, DefaultViewName);
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
	/// Supports the BillOfMaterialsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BillOfMaterialsDataSourceView : ProviderDataSourceView<BillOfMaterials, BillOfMaterialsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BillOfMaterialsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BillOfMaterialsDataSourceView(BillOfMaterialsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BillOfMaterialsDataSource BillOfMaterialsOwner
		{
			get { return Owner as BillOfMaterialsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BillOfMaterialsSelectMethod SelectMethod
		{
			get { return BillOfMaterialsOwner.SelectMethod; }
			set { BillOfMaterialsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BillOfMaterialsService BillOfMaterialsProvider
		{
			get { return Provider as BillOfMaterialsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BillOfMaterials> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BillOfMaterials> results = null;
			BillOfMaterials item;
			count = 0;
			
			System.Int32? _productAssemblyId_nullable;
			System.Int32 _componentId;
			System.DateTime _startDate;
			System.String _unitMeasureCode;
			System.Int32 _billOfMaterialsId;

			switch ( SelectMethod )
			{
				case BillOfMaterialsSelectMethod.Get:
					BillOfMaterialsKey entityKey  = new BillOfMaterialsKey();
					entityKey.Load(values);
					item = BillOfMaterialsProvider.Get(entityKey);
					results = new TList<BillOfMaterials>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BillOfMaterialsSelectMethod.GetAll:
                    results = BillOfMaterialsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case BillOfMaterialsSelectMethod.GetPaged:
					results = BillOfMaterialsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BillOfMaterialsSelectMethod.Find:
					if ( FilterParameters != null )
						results = BillOfMaterialsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BillOfMaterialsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BillOfMaterialsSelectMethod.GetByBillOfMaterialsId:
					_billOfMaterialsId = ( values["BillOfMaterialsId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["BillOfMaterialsId"], typeof(System.Int32)) : (int)0;
					item = BillOfMaterialsProvider.GetByBillOfMaterialsId(_billOfMaterialsId);
					results = new TList<BillOfMaterials>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case BillOfMaterialsSelectMethod.GetByProductAssemblyIdComponentIdStartDate:
					_productAssemblyId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ProductAssemblyId"], typeof(System.Int32?));
					_componentId = ( values["ComponentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ComponentId"], typeof(System.Int32)) : (int)0;
					_startDate = ( values["StartDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartDate"], typeof(System.DateTime)) : DateTime.MinValue;
					item = BillOfMaterialsProvider.GetByProductAssemblyIdComponentIdStartDate(_productAssemblyId_nullable, _componentId, _startDate);
					results = new TList<BillOfMaterials>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BillOfMaterialsSelectMethod.GetByUnitMeasureCode:
					_unitMeasureCode = ( values["UnitMeasureCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["UnitMeasureCode"], typeof(System.String)) : string.Empty;
					results = BillOfMaterialsProvider.GetByUnitMeasureCode(_unitMeasureCode, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case BillOfMaterialsSelectMethod.GetByComponentId:
					_componentId = ( values["ComponentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ComponentId"], typeof(System.Int32)) : (int)0;
					results = BillOfMaterialsProvider.GetByComponentId(_componentId, this.StartIndex, this.PageSize, out count);
					break;
				case BillOfMaterialsSelectMethod.GetByProductAssemblyId:
					_productAssemblyId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ProductAssemblyId"], typeof(System.Int32?));
					results = BillOfMaterialsProvider.GetByProductAssemblyId(_productAssemblyId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == BillOfMaterialsSelectMethod.Get || SelectMethod == BillOfMaterialsSelectMethod.GetByBillOfMaterialsId )
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
				BillOfMaterials entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					BillOfMaterialsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BillOfMaterials> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			BillOfMaterialsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BillOfMaterialsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BillOfMaterialsDataSource class.
	/// </summary>
	public class BillOfMaterialsDataSourceDesigner : ProviderDataSourceDesigner<BillOfMaterials, BillOfMaterialsKey>
	{
		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsDataSourceDesigner class.
		/// </summary>
		public BillOfMaterialsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BillOfMaterialsSelectMethod SelectMethod
		{
			get { return ((BillOfMaterialsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BillOfMaterialsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BillOfMaterialsDataSourceActionList

	/// <summary>
	/// Supports the BillOfMaterialsDataSourceDesigner class.
	/// </summary>
	internal class BillOfMaterialsDataSourceActionList : DesignerActionList
	{
		private BillOfMaterialsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BillOfMaterialsDataSourceActionList(BillOfMaterialsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BillOfMaterialsSelectMethod SelectMethod
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

	#endregion BillOfMaterialsDataSourceActionList
	
	#endregion BillOfMaterialsDataSourceDesigner
	
	#region BillOfMaterialsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BillOfMaterialsDataSource.SelectMethod property.
	/// </summary>
	public enum BillOfMaterialsSelectMethod
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
		/// Represents the GetByProductAssemblyIdComponentIdStartDate method.
		/// </summary>
		GetByProductAssemblyIdComponentIdStartDate,
		/// <summary>
		/// Represents the GetByUnitMeasureCode method.
		/// </summary>
		GetByUnitMeasureCode,
		/// <summary>
		/// Represents the GetByBillOfMaterialsId method.
		/// </summary>
		GetByBillOfMaterialsId,
		/// <summary>
		/// Represents the GetByComponentId method.
		/// </summary>
		GetByComponentId,
		/// <summary>
		/// Represents the GetByProductAssemblyId method.
		/// </summary>
		GetByProductAssemblyId
	}
	
	#endregion BillOfMaterialsSelectMethod

	#region BillOfMaterialsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillOfMaterials"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillOfMaterialsFilter : SqlFilter<BillOfMaterialsColumn>
	{
	}
	
	#endregion BillOfMaterialsFilter

	#region BillOfMaterialsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillOfMaterials"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillOfMaterialsExpressionBuilder : SqlExpressionBuilder<BillOfMaterialsColumn>
	{
	}
	
	#endregion BillOfMaterialsExpressionBuilder	

	#region BillOfMaterialsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BillOfMaterialsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BillOfMaterials"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillOfMaterialsProperty : ChildEntityProperty<BillOfMaterialsChildEntityTypes>
	{
	}
	
	#endregion BillOfMaterialsProperty
}

