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
	/// Represents the DataRepository.UnitMeasureProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(UnitMeasureDataSourceDesigner))]
	public class UnitMeasureDataSource : ProviderDataSource<UnitMeasure, UnitMeasureKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitMeasureDataSource class.
		/// </summary>
		public UnitMeasureDataSource() : base(new UnitMeasureService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the UnitMeasureDataSourceView used by the UnitMeasureDataSource.
		/// </summary>
		protected UnitMeasureDataSourceView UnitMeasureView
		{
			get { return ( View as UnitMeasureDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the UnitMeasureDataSource control invokes to retrieve data.
		/// </summary>
		public UnitMeasureSelectMethod SelectMethod
		{
			get
			{
				UnitMeasureSelectMethod selectMethod = UnitMeasureSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (UnitMeasureSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the UnitMeasureDataSourceView class that is to be
		/// used by the UnitMeasureDataSource.
		/// </summary>
		/// <returns>An instance of the UnitMeasureDataSourceView class.</returns>
		protected override BaseDataSourceView<UnitMeasure, UnitMeasureKey> GetNewDataSourceView()
		{
			return new UnitMeasureDataSourceView(this, DefaultViewName);
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
	/// Supports the UnitMeasureDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class UnitMeasureDataSourceView : ProviderDataSourceView<UnitMeasure, UnitMeasureKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitMeasureDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the UnitMeasureDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public UnitMeasureDataSourceView(UnitMeasureDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal UnitMeasureDataSource UnitMeasureOwner
		{
			get { return Owner as UnitMeasureDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal UnitMeasureSelectMethod SelectMethod
		{
			get { return UnitMeasureOwner.SelectMethod; }
			set { UnitMeasureOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal UnitMeasureService UnitMeasureProvider
		{
			get { return Provider as UnitMeasureService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<UnitMeasure> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<UnitMeasure> results = null;
			UnitMeasure item;
			count = 0;
			
			System.String _name;
			System.String _unitMeasureCode;

			switch ( SelectMethod )
			{
				case UnitMeasureSelectMethod.Get:
					UnitMeasureKey entityKey  = new UnitMeasureKey();
					entityKey.Load(values);
					item = UnitMeasureProvider.Get(entityKey);
					results = new TList<UnitMeasure>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case UnitMeasureSelectMethod.GetAll:
                    results = UnitMeasureProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case UnitMeasureSelectMethod.GetPaged:
					results = UnitMeasureProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case UnitMeasureSelectMethod.Find:
					if ( FilterParameters != null )
						results = UnitMeasureProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = UnitMeasureProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case UnitMeasureSelectMethod.GetByUnitMeasureCode:
					_unitMeasureCode = ( values["UnitMeasureCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["UnitMeasureCode"], typeof(System.String)) : string.Empty;
					item = UnitMeasureProvider.GetByUnitMeasureCode(_unitMeasureCode);
					results = new TList<UnitMeasure>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case UnitMeasureSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = UnitMeasureProvider.GetByName(_name);
					results = new TList<UnitMeasure>();
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
			if ( SelectMethod == UnitMeasureSelectMethod.Get || SelectMethod == UnitMeasureSelectMethod.GetByUnitMeasureCode )
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
				UnitMeasure entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					UnitMeasureProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<UnitMeasure> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			UnitMeasureProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region UnitMeasureDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the UnitMeasureDataSource class.
	/// </summary>
	public class UnitMeasureDataSourceDesigner : ProviderDataSourceDesigner<UnitMeasure, UnitMeasureKey>
	{
		/// <summary>
		/// Initializes a new instance of the UnitMeasureDataSourceDesigner class.
		/// </summary>
		public UnitMeasureDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UnitMeasureSelectMethod SelectMethod
		{
			get { return ((UnitMeasureDataSource) DataSource).SelectMethod; }
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
				actions.Add(new UnitMeasureDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region UnitMeasureDataSourceActionList

	/// <summary>
	/// Supports the UnitMeasureDataSourceDesigner class.
	/// </summary>
	internal class UnitMeasureDataSourceActionList : DesignerActionList
	{
		private UnitMeasureDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the UnitMeasureDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public UnitMeasureDataSourceActionList(UnitMeasureDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UnitMeasureSelectMethod SelectMethod
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

	#endregion UnitMeasureDataSourceActionList
	
	#endregion UnitMeasureDataSourceDesigner
	
	#region UnitMeasureSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the UnitMeasureDataSource.SelectMethod property.
	/// </summary>
	public enum UnitMeasureSelectMethod
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
		/// Represents the GetByUnitMeasureCode method.
		/// </summary>
		GetByUnitMeasureCode
	}
	
	#endregion UnitMeasureSelectMethod

	#region UnitMeasureFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitMeasure"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitMeasureFilter : SqlFilter<UnitMeasureColumn>
	{
	}
	
	#endregion UnitMeasureFilter

	#region UnitMeasureExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitMeasure"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitMeasureExpressionBuilder : SqlExpressionBuilder<UnitMeasureColumn>
	{
	}
	
	#endregion UnitMeasureExpressionBuilder	

	#region UnitMeasureProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;UnitMeasureChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="UnitMeasure"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitMeasureProperty : ChildEntityProperty<UnitMeasureChildEntityTypes>
	{
	}
	
	#endregion UnitMeasureProperty
}

