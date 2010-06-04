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
	/// Represents the DataRepository.DatabaseLogProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DatabaseLogDataSourceDesigner))]
	public class DatabaseLogDataSource : ProviderDataSource<DatabaseLog, DatabaseLogKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DatabaseLogDataSource class.
		/// </summary>
		public DatabaseLogDataSource() : base(new DatabaseLogService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DatabaseLogDataSourceView used by the DatabaseLogDataSource.
		/// </summary>
		protected DatabaseLogDataSourceView DatabaseLogView
		{
			get { return ( View as DatabaseLogDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DatabaseLogDataSource control invokes to retrieve data.
		/// </summary>
		public DatabaseLogSelectMethod SelectMethod
		{
			get
			{
				DatabaseLogSelectMethod selectMethod = DatabaseLogSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DatabaseLogSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DatabaseLogDataSourceView class that is to be
		/// used by the DatabaseLogDataSource.
		/// </summary>
		/// <returns>An instance of the DatabaseLogDataSourceView class.</returns>
		protected override BaseDataSourceView<DatabaseLog, DatabaseLogKey> GetNewDataSourceView()
		{
			return new DatabaseLogDataSourceView(this, DefaultViewName);
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
	/// Supports the DatabaseLogDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DatabaseLogDataSourceView : ProviderDataSourceView<DatabaseLog, DatabaseLogKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DatabaseLogDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DatabaseLogDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DatabaseLogDataSourceView(DatabaseLogDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DatabaseLogDataSource DatabaseLogOwner
		{
			get { return Owner as DatabaseLogDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DatabaseLogSelectMethod SelectMethod
		{
			get { return DatabaseLogOwner.SelectMethod; }
			set { DatabaseLogOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DatabaseLogService DatabaseLogProvider
		{
			get { return Provider as DatabaseLogService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DatabaseLog> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DatabaseLog> results = null;
			DatabaseLog item;
			count = 0;
			
			System.Int32 _databaseLogId;

			switch ( SelectMethod )
			{
				case DatabaseLogSelectMethod.Get:
					DatabaseLogKey entityKey  = new DatabaseLogKey();
					entityKey.Load(values);
					item = DatabaseLogProvider.Get(entityKey);
					results = new TList<DatabaseLog>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DatabaseLogSelectMethod.GetAll:
                    results = DatabaseLogProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DatabaseLogSelectMethod.GetPaged:
					results = DatabaseLogProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DatabaseLogSelectMethod.Find:
					if ( FilterParameters != null )
						results = DatabaseLogProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DatabaseLogProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DatabaseLogSelectMethod.GetByDatabaseLogId:
					_databaseLogId = ( values["DatabaseLogId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DatabaseLogId"], typeof(System.Int32)) : (int)0;
					item = DatabaseLogProvider.GetByDatabaseLogId(_databaseLogId);
					results = new TList<DatabaseLog>();
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
			if ( SelectMethod == DatabaseLogSelectMethod.Get || SelectMethod == DatabaseLogSelectMethod.GetByDatabaseLogId )
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
				DatabaseLog entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DatabaseLogProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DatabaseLog> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DatabaseLogProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DatabaseLogDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DatabaseLogDataSource class.
	/// </summary>
	public class DatabaseLogDataSourceDesigner : ProviderDataSourceDesigner<DatabaseLog, DatabaseLogKey>
	{
		/// <summary>
		/// Initializes a new instance of the DatabaseLogDataSourceDesigner class.
		/// </summary>
		public DatabaseLogDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DatabaseLogSelectMethod SelectMethod
		{
			get { return ((DatabaseLogDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DatabaseLogDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DatabaseLogDataSourceActionList

	/// <summary>
	/// Supports the DatabaseLogDataSourceDesigner class.
	/// </summary>
	internal class DatabaseLogDataSourceActionList : DesignerActionList
	{
		private DatabaseLogDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DatabaseLogDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DatabaseLogDataSourceActionList(DatabaseLogDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DatabaseLogSelectMethod SelectMethod
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

	#endregion DatabaseLogDataSourceActionList
	
	#endregion DatabaseLogDataSourceDesigner
	
	#region DatabaseLogSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DatabaseLogDataSource.SelectMethod property.
	/// </summary>
	public enum DatabaseLogSelectMethod
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
		/// Represents the GetByDatabaseLogId method.
		/// </summary>
		GetByDatabaseLogId
	}
	
	#endregion DatabaseLogSelectMethod

	#region DatabaseLogFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DatabaseLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DatabaseLogFilter : SqlFilter<DatabaseLogColumn>
	{
	}
	
	#endregion DatabaseLogFilter

	#region DatabaseLogExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DatabaseLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DatabaseLogExpressionBuilder : SqlExpressionBuilder<DatabaseLogColumn>
	{
	}
	
	#endregion DatabaseLogExpressionBuilder	

	#region DatabaseLogProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DatabaseLogChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DatabaseLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DatabaseLogProperty : ChildEntityProperty<DatabaseLogChildEntityTypes>
	{
	}
	
	#endregion DatabaseLogProperty
}

