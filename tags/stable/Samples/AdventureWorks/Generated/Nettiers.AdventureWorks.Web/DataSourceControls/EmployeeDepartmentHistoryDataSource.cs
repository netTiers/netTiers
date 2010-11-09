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
	/// Represents the DataRepository.EmployeeDepartmentHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmployeeDepartmentHistoryDataSourceDesigner))]
	public class EmployeeDepartmentHistoryDataSource : ProviderDataSource<EmployeeDepartmentHistory, EmployeeDepartmentHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryDataSource class.
		/// </summary>
		public EmployeeDepartmentHistoryDataSource() : base(new EmployeeDepartmentHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmployeeDepartmentHistoryDataSourceView used by the EmployeeDepartmentHistoryDataSource.
		/// </summary>
		protected EmployeeDepartmentHistoryDataSourceView EmployeeDepartmentHistoryView
		{
			get { return ( View as EmployeeDepartmentHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmployeeDepartmentHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public EmployeeDepartmentHistorySelectMethod SelectMethod
		{
			get
			{
				EmployeeDepartmentHistorySelectMethod selectMethod = EmployeeDepartmentHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmployeeDepartmentHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmployeeDepartmentHistoryDataSourceView class that is to be
		/// used by the EmployeeDepartmentHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the EmployeeDepartmentHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<EmployeeDepartmentHistory, EmployeeDepartmentHistoryKey> GetNewDataSourceView()
		{
			return new EmployeeDepartmentHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the EmployeeDepartmentHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmployeeDepartmentHistoryDataSourceView : ProviderDataSourceView<EmployeeDepartmentHistory, EmployeeDepartmentHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmployeeDepartmentHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmployeeDepartmentHistoryDataSourceView(EmployeeDepartmentHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmployeeDepartmentHistoryDataSource EmployeeDepartmentHistoryOwner
		{
			get { return Owner as EmployeeDepartmentHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmployeeDepartmentHistorySelectMethod SelectMethod
		{
			get { return EmployeeDepartmentHistoryOwner.SelectMethod; }
			set { EmployeeDepartmentHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmployeeDepartmentHistoryService EmployeeDepartmentHistoryProvider
		{
			get { return Provider as EmployeeDepartmentHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmployeeDepartmentHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmployeeDepartmentHistory> results = null;
			EmployeeDepartmentHistory item;
			count = 0;
			
			System.Int16 _departmentId;
			System.Byte _shiftId;
			System.Int32 _employeeId;
			System.DateTime _startDate;

			switch ( SelectMethod )
			{
				case EmployeeDepartmentHistorySelectMethod.Get:
					EmployeeDepartmentHistoryKey entityKey  = new EmployeeDepartmentHistoryKey();
					entityKey.Load(values);
					item = EmployeeDepartmentHistoryProvider.Get(entityKey);
					results = new TList<EmployeeDepartmentHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeDepartmentHistorySelectMethod.GetAll:
                    results = EmployeeDepartmentHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmployeeDepartmentHistorySelectMethod.GetPaged:
					results = EmployeeDepartmentHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmployeeDepartmentHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = EmployeeDepartmentHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmployeeDepartmentHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmployeeDepartmentHistorySelectMethod.GetByEmployeeIdStartDateDepartmentIdShiftId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					_startDate = ( values["StartDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartDate"], typeof(System.DateTime)) : DateTime.MinValue;
					_departmentId = ( values["DepartmentId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["DepartmentId"], typeof(System.Int16)) : (short)0;
					_shiftId = ( values["ShiftId"] != null ) ? (System.Byte) EntityUtil.ChangeType(values["ShiftId"], typeof(System.Byte)) : (byte)0;
					item = EmployeeDepartmentHistoryProvider.GetByEmployeeIdStartDateDepartmentIdShiftId(_employeeId, _startDate, _departmentId, _shiftId);
					results = new TList<EmployeeDepartmentHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case EmployeeDepartmentHistorySelectMethod.GetByDepartmentId:
					_departmentId = ( values["DepartmentId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["DepartmentId"], typeof(System.Int16)) : (short)0;
					results = EmployeeDepartmentHistoryProvider.GetByDepartmentId(_departmentId, this.StartIndex, this.PageSize, out count);
					break;
				case EmployeeDepartmentHistorySelectMethod.GetByShiftId:
					_shiftId = ( values["ShiftId"] != null ) ? (System.Byte) EntityUtil.ChangeType(values["ShiftId"], typeof(System.Byte)) : (byte)0;
					results = EmployeeDepartmentHistoryProvider.GetByShiftId(_shiftId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case EmployeeDepartmentHistorySelectMethod.GetByEmployeeId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					results = EmployeeDepartmentHistoryProvider.GetByEmployeeId(_employeeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EmployeeDepartmentHistorySelectMethod.Get || SelectMethod == EmployeeDepartmentHistorySelectMethod.GetByEmployeeIdStartDateDepartmentIdShiftId )
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
				EmployeeDepartmentHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmployeeDepartmentHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmployeeDepartmentHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmployeeDepartmentHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmployeeDepartmentHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmployeeDepartmentHistoryDataSource class.
	/// </summary>
	public class EmployeeDepartmentHistoryDataSourceDesigner : ProviderDataSourceDesigner<EmployeeDepartmentHistory, EmployeeDepartmentHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryDataSourceDesigner class.
		/// </summary>
		public EmployeeDepartmentHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeDepartmentHistorySelectMethod SelectMethod
		{
			get { return ((EmployeeDepartmentHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmployeeDepartmentHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmployeeDepartmentHistoryDataSourceActionList

	/// <summary>
	/// Supports the EmployeeDepartmentHistoryDataSourceDesigner class.
	/// </summary>
	internal class EmployeeDepartmentHistoryDataSourceActionList : DesignerActionList
	{
		private EmployeeDepartmentHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmployeeDepartmentHistoryDataSourceActionList(EmployeeDepartmentHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeDepartmentHistorySelectMethod SelectMethod
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

	#endregion EmployeeDepartmentHistoryDataSourceActionList
	
	#endregion EmployeeDepartmentHistoryDataSourceDesigner
	
	#region EmployeeDepartmentHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmployeeDepartmentHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum EmployeeDepartmentHistorySelectMethod
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
		/// Represents the GetByDepartmentId method.
		/// </summary>
		GetByDepartmentId,
		/// <summary>
		/// Represents the GetByShiftId method.
		/// </summary>
		GetByShiftId,
		/// <summary>
		/// Represents the GetByEmployeeIdStartDateDepartmentIdShiftId method.
		/// </summary>
		GetByEmployeeIdStartDateDepartmentIdShiftId,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId
	}
	
	#endregion EmployeeDepartmentHistorySelectMethod

	#region EmployeeDepartmentHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentHistoryFilter : SqlFilter<EmployeeDepartmentHistoryColumn>
	{
	}
	
	#endregion EmployeeDepartmentHistoryFilter

	#region EmployeeDepartmentHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentHistoryExpressionBuilder : SqlExpressionBuilder<EmployeeDepartmentHistoryColumn>
	{
	}
	
	#endregion EmployeeDepartmentHistoryExpressionBuilder	

	#region EmployeeDepartmentHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmployeeDepartmentHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentHistoryProperty : ChildEntityProperty<EmployeeDepartmentHistoryChildEntityTypes>
	{
	}
	
	#endregion EmployeeDepartmentHistoryProperty
}

