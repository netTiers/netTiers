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
	/// Represents the DataRepository.TimestampPkProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TimestampPkDataSourceDesigner))]
	public class TimestampPkDataSource : ProviderDataSource<TimestampPk, TimestampPkKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TimestampPkDataSource class.
		/// </summary>
		public TimestampPkDataSource() : base(new TimestampPkService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TimestampPkDataSourceView used by the TimestampPkDataSource.
		/// </summary>
		protected TimestampPkDataSourceView TimestampPkView
		{
			get { return ( View as TimestampPkDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TimestampPkDataSource control invokes to retrieve data.
		/// </summary>
		public TimestampPkSelectMethod SelectMethod
		{
			get
			{
				TimestampPkSelectMethod selectMethod = TimestampPkSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TimestampPkSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TimestampPkDataSourceView class that is to be
		/// used by the TimestampPkDataSource.
		/// </summary>
		/// <returns>An instance of the TimestampPkDataSourceView class.</returns>
		protected override BaseDataSourceView<TimestampPk, TimestampPkKey> GetNewDataSourceView()
		{
			return new TimestampPkDataSourceView(this, DefaultViewName);
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
	/// Supports the TimestampPkDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TimestampPkDataSourceView : ProviderDataSourceView<TimestampPk, TimestampPkKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TimestampPkDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TimestampPkDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TimestampPkDataSourceView(TimestampPkDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TimestampPkDataSource TimestampPkOwner
		{
			get { return Owner as TimestampPkDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TimestampPkSelectMethod SelectMethod
		{
			get { return TimestampPkOwner.SelectMethod; }
			set { TimestampPkOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TimestampPkService TimestampPkProvider
		{
			get { return Provider as TimestampPkService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TimestampPk> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TimestampPk> results = null;
			TimestampPk item;
			count = 0;
			
			System.Byte[] _timestampPk;

			switch ( SelectMethod )
			{
				case TimestampPkSelectMethod.Get:
					TimestampPkKey entityKey  = new TimestampPkKey();
					entityKey.Load(values);
					item = TimestampPkProvider.Get(entityKey);
					results = new TList<TimestampPk>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TimestampPkSelectMethod.GetAll:
                    results = TimestampPkProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TimestampPkSelectMethod.GetPaged:
					results = TimestampPkProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TimestampPkSelectMethod.Find:
					if ( FilterParameters != null )
						results = TimestampPkProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TimestampPkProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TimestampPkSelectMethod.GetByTimestampPk:
					_timestampPk = ( values["TimestampPk"] != null ) ? (System.Byte[]) EntityUtil.ChangeType(values["TimestampPk"], typeof(System.Byte[])) : new byte[] {};
					item = TimestampPkProvider.GetByTimestampPk(_timestampPk);
					results = new TList<TimestampPk>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
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
			if ( SelectMethod == TimestampPkSelectMethod.Get || SelectMethod == TimestampPkSelectMethod.GetByTimestampPk )
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
				TimestampPk entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TimestampPkProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TimestampPk> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TimestampPkProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TimestampPkDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TimestampPkDataSource class.
	/// </summary>
	public class TimestampPkDataSourceDesigner : ProviderDataSourceDesigner<TimestampPk, TimestampPkKey>
	{
		/// <summary>
		/// Initializes a new instance of the TimestampPkDataSourceDesigner class.
		/// </summary>
		public TimestampPkDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TimestampPkSelectMethod SelectMethod
		{
			get { return ((TimestampPkDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TimestampPkDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TimestampPkDataSourceActionList

	/// <summary>
	/// Supports the TimestampPkDataSourceDesigner class.
	/// </summary>
	internal class TimestampPkDataSourceActionList : DesignerActionList
	{
		private TimestampPkDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TimestampPkDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TimestampPkDataSourceActionList(TimestampPkDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TimestampPkSelectMethod SelectMethod
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

	#endregion TimestampPkDataSourceActionList
	
	#endregion TimestampPkDataSourceDesigner
	
	#region TimestampPkSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TimestampPkDataSource.SelectMethod property.
	/// </summary>
	public enum TimestampPkSelectMethod
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
		/// Represents the GetByTimestampPk method.
		/// </summary>
		GetByTimestampPk
	}
	
	#endregion TimestampPkSelectMethod

	#region TimestampPkFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TimestampPk"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TimestampPkFilter : SqlFilter<TimestampPkColumn>
	{
	}
	
	#endregion TimestampPkFilter

	#region TimestampPkExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TimestampPk"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TimestampPkExpressionBuilder : SqlExpressionBuilder<TimestampPkColumn>
	{
	}
	
	#endregion TimestampPkExpressionBuilder	

	#region TimestampPkProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TimestampPkChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TimestampPk"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TimestampPkProperty : ChildEntityProperty<TimestampPkChildEntityTypes>
	{
	}
	
	#endregion TimestampPkProperty
}

