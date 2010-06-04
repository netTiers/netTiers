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
	/// Represents the DataRepository.DepartmentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DepartmentDataSourceDesigner))]
	public class DepartmentDataSource : ProviderDataSource<Department, DepartmentKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentDataSource class.
		/// </summary>
		public DepartmentDataSource() : base(new DepartmentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DepartmentDataSourceView used by the DepartmentDataSource.
		/// </summary>
		protected DepartmentDataSourceView DepartmentView
		{
			get { return ( View as DepartmentDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DepartmentDataSource control invokes to retrieve data.
		/// </summary>
		public DepartmentSelectMethod SelectMethod
		{
			get
			{
				DepartmentSelectMethod selectMethod = DepartmentSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DepartmentSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DepartmentDataSourceView class that is to be
		/// used by the DepartmentDataSource.
		/// </summary>
		/// <returns>An instance of the DepartmentDataSourceView class.</returns>
		protected override BaseDataSourceView<Department, DepartmentKey> GetNewDataSourceView()
		{
			return new DepartmentDataSourceView(this, DefaultViewName);
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
	/// Supports the DepartmentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DepartmentDataSourceView : ProviderDataSourceView<Department, DepartmentKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DepartmentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DepartmentDataSourceView(DepartmentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DepartmentDataSource DepartmentOwner
		{
			get { return Owner as DepartmentDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DepartmentSelectMethod SelectMethod
		{
			get { return DepartmentOwner.SelectMethod; }
			set { DepartmentOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DepartmentService DepartmentProvider
		{
			get { return Provider as DepartmentService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Department> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Department> results = null;
			Department item;
			count = 0;
			
			System.String _name;
			System.Int16 _departmentId;

			switch ( SelectMethod )
			{
				case DepartmentSelectMethod.Get:
					DepartmentKey entityKey  = new DepartmentKey();
					entityKey.Load(values);
					item = DepartmentProvider.Get(entityKey);
					results = new TList<Department>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DepartmentSelectMethod.GetAll:
                    results = DepartmentProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DepartmentSelectMethod.GetPaged:
					results = DepartmentProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DepartmentSelectMethod.Find:
					if ( FilterParameters != null )
						results = DepartmentProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DepartmentProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DepartmentSelectMethod.GetByDepartmentId:
					_departmentId = ( values["DepartmentId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["DepartmentId"], typeof(System.Int16)) : (short)0;
					item = DepartmentProvider.GetByDepartmentId(_departmentId);
					results = new TList<Department>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case DepartmentSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = DepartmentProvider.GetByName(_name);
					results = new TList<Department>();
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
			if ( SelectMethod == DepartmentSelectMethod.Get || SelectMethod == DepartmentSelectMethod.GetByDepartmentId )
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
				Department entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DepartmentProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Department> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DepartmentProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DepartmentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DepartmentDataSource class.
	/// </summary>
	public class DepartmentDataSourceDesigner : ProviderDataSourceDesigner<Department, DepartmentKey>
	{
		/// <summary>
		/// Initializes a new instance of the DepartmentDataSourceDesigner class.
		/// </summary>
		public DepartmentDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DepartmentSelectMethod SelectMethod
		{
			get { return ((DepartmentDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DepartmentDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DepartmentDataSourceActionList

	/// <summary>
	/// Supports the DepartmentDataSourceDesigner class.
	/// </summary>
	internal class DepartmentDataSourceActionList : DesignerActionList
	{
		private DepartmentDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DepartmentDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DepartmentDataSourceActionList(DepartmentDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DepartmentSelectMethod SelectMethod
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

	#endregion DepartmentDataSourceActionList
	
	#endregion DepartmentDataSourceDesigner
	
	#region DepartmentSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DepartmentDataSource.SelectMethod property.
	/// </summary>
	public enum DepartmentSelectMethod
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
		/// Represents the GetByDepartmentId method.
		/// </summary>
		GetByDepartmentId
	}
	
	#endregion DepartmentSelectMethod

	#region DepartmentFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentFilter : SqlFilter<DepartmentColumn>
	{
	}
	
	#endregion DepartmentFilter

	#region DepartmentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentExpressionBuilder : SqlExpressionBuilder<DepartmentColumn>
	{
	}
	
	#endregion DepartmentExpressionBuilder	

	#region DepartmentProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DepartmentChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentProperty : ChildEntityProperty<DepartmentChildEntityTypes>
	{
	}
	
	#endregion DepartmentProperty
}

