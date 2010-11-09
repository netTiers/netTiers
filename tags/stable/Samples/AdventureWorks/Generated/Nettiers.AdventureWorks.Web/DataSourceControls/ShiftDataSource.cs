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
	/// Represents the DataRepository.ShiftProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ShiftDataSourceDesigner))]
	public class ShiftDataSource : ProviderDataSource<Shift, ShiftKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShiftDataSource class.
		/// </summary>
		public ShiftDataSource() : base(new ShiftService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ShiftDataSourceView used by the ShiftDataSource.
		/// </summary>
		protected ShiftDataSourceView ShiftView
		{
			get { return ( View as ShiftDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ShiftDataSource control invokes to retrieve data.
		/// </summary>
		public ShiftSelectMethod SelectMethod
		{
			get
			{
				ShiftSelectMethod selectMethod = ShiftSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ShiftSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ShiftDataSourceView class that is to be
		/// used by the ShiftDataSource.
		/// </summary>
		/// <returns>An instance of the ShiftDataSourceView class.</returns>
		protected override BaseDataSourceView<Shift, ShiftKey> GetNewDataSourceView()
		{
			return new ShiftDataSourceView(this, DefaultViewName);
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
	/// Supports the ShiftDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ShiftDataSourceView : ProviderDataSourceView<Shift, ShiftKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShiftDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ShiftDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ShiftDataSourceView(ShiftDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ShiftDataSource ShiftOwner
		{
			get { return Owner as ShiftDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ShiftSelectMethod SelectMethod
		{
			get { return ShiftOwner.SelectMethod; }
			set { ShiftOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ShiftService ShiftProvider
		{
			get { return Provider as ShiftService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Shift> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Shift> results = null;
			Shift item;
			count = 0;
			
			System.String _name;
			System.DateTime _startTime;
			System.DateTime _endTime;
			System.Byte _shiftId;

			switch ( SelectMethod )
			{
				case ShiftSelectMethod.Get:
					ShiftKey entityKey  = new ShiftKey();
					entityKey.Load(values);
					item = ShiftProvider.Get(entityKey);
					results = new TList<Shift>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ShiftSelectMethod.GetAll:
                    results = ShiftProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ShiftSelectMethod.GetPaged:
					results = ShiftProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ShiftSelectMethod.Find:
					if ( FilterParameters != null )
						results = ShiftProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ShiftProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ShiftSelectMethod.GetByShiftId:
					_shiftId = ( values["ShiftId"] != null ) ? (System.Byte) EntityUtil.ChangeType(values["ShiftId"], typeof(System.Byte)) : (byte)0;
					item = ShiftProvider.GetByShiftId(_shiftId);
					results = new TList<Shift>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ShiftSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ShiftProvider.GetByName(_name);
					results = new TList<Shift>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ShiftSelectMethod.GetByStartTimeEndTime:
					_startTime = ( values["StartTime"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartTime"], typeof(System.DateTime)) : DateTime.MinValue;
					_endTime = ( values["EndTime"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["EndTime"], typeof(System.DateTime)) : DateTime.MinValue;
					item = ShiftProvider.GetByStartTimeEndTime(_startTime, _endTime);
					results = new TList<Shift>();
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
			if ( SelectMethod == ShiftSelectMethod.Get || SelectMethod == ShiftSelectMethod.GetByShiftId )
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
				Shift entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ShiftProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Shift> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ShiftProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ShiftDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ShiftDataSource class.
	/// </summary>
	public class ShiftDataSourceDesigner : ProviderDataSourceDesigner<Shift, ShiftKey>
	{
		/// <summary>
		/// Initializes a new instance of the ShiftDataSourceDesigner class.
		/// </summary>
		public ShiftDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ShiftSelectMethod SelectMethod
		{
			get { return ((ShiftDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ShiftDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ShiftDataSourceActionList

	/// <summary>
	/// Supports the ShiftDataSourceDesigner class.
	/// </summary>
	internal class ShiftDataSourceActionList : DesignerActionList
	{
		private ShiftDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ShiftDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ShiftDataSourceActionList(ShiftDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ShiftSelectMethod SelectMethod
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

	#endregion ShiftDataSourceActionList
	
	#endregion ShiftDataSourceDesigner
	
	#region ShiftSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ShiftDataSource.SelectMethod property.
	/// </summary>
	public enum ShiftSelectMethod
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
		/// Represents the GetByStartTimeEndTime method.
		/// </summary>
		GetByStartTimeEndTime,
		/// <summary>
		/// Represents the GetByShiftId method.
		/// </summary>
		GetByShiftId
	}
	
	#endregion ShiftSelectMethod

	#region ShiftFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shift"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShiftFilter : SqlFilter<ShiftColumn>
	{
	}
	
	#endregion ShiftFilter

	#region ShiftExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shift"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShiftExpressionBuilder : SqlExpressionBuilder<ShiftColumn>
	{
	}
	
	#endregion ShiftExpressionBuilder	

	#region ShiftProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ShiftChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Shift"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShiftProperty : ChildEntityProperty<ShiftChildEntityTypes>
	{
	}
	
	#endregion ShiftProperty
}

