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
	/// Represents the DataRepository.ErrorLogProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ErrorLogDataSourceDesigner))]
	public class ErrorLogDataSource : ProviderDataSource<ErrorLog, ErrorLogKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorLogDataSource class.
		/// </summary>
		public ErrorLogDataSource() : base(new ErrorLogService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ErrorLogDataSourceView used by the ErrorLogDataSource.
		/// </summary>
		protected ErrorLogDataSourceView ErrorLogView
		{
			get { return ( View as ErrorLogDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ErrorLogDataSource control invokes to retrieve data.
		/// </summary>
		public ErrorLogSelectMethod SelectMethod
		{
			get
			{
				ErrorLogSelectMethod selectMethod = ErrorLogSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ErrorLogSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ErrorLogDataSourceView class that is to be
		/// used by the ErrorLogDataSource.
		/// </summary>
		/// <returns>An instance of the ErrorLogDataSourceView class.</returns>
		protected override BaseDataSourceView<ErrorLog, ErrorLogKey> GetNewDataSourceView()
		{
			return new ErrorLogDataSourceView(this, DefaultViewName);
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
	/// Supports the ErrorLogDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ErrorLogDataSourceView : ProviderDataSourceView<ErrorLog, ErrorLogKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorLogDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ErrorLogDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ErrorLogDataSourceView(ErrorLogDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ErrorLogDataSource ErrorLogOwner
		{
			get { return Owner as ErrorLogDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ErrorLogSelectMethod SelectMethod
		{
			get { return ErrorLogOwner.SelectMethod; }
			set { ErrorLogOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ErrorLogService ErrorLogProvider
		{
			get { return Provider as ErrorLogService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ErrorLog> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ErrorLog> results = null;
			ErrorLog item;
			count = 0;
			
			System.Int32 _errorLogId;

			switch ( SelectMethod )
			{
				case ErrorLogSelectMethod.Get:
					ErrorLogKey entityKey  = new ErrorLogKey();
					entityKey.Load(values);
					item = ErrorLogProvider.Get(entityKey);
					results = new TList<ErrorLog>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ErrorLogSelectMethod.GetAll:
                    results = ErrorLogProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ErrorLogSelectMethod.GetPaged:
					results = ErrorLogProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ErrorLogSelectMethod.Find:
					if ( FilterParameters != null )
						results = ErrorLogProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ErrorLogProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ErrorLogSelectMethod.GetByErrorLogId:
					_errorLogId = ( values["ErrorLogId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ErrorLogId"], typeof(System.Int32)) : (int)0;
					item = ErrorLogProvider.GetByErrorLogId(_errorLogId);
					results = new TList<ErrorLog>();
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
			if ( SelectMethod == ErrorLogSelectMethod.Get || SelectMethod == ErrorLogSelectMethod.GetByErrorLogId )
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
				ErrorLog entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ErrorLogProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ErrorLog> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ErrorLogProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ErrorLogDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ErrorLogDataSource class.
	/// </summary>
	public class ErrorLogDataSourceDesigner : ProviderDataSourceDesigner<ErrorLog, ErrorLogKey>
	{
		/// <summary>
		/// Initializes a new instance of the ErrorLogDataSourceDesigner class.
		/// </summary>
		public ErrorLogDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ErrorLogSelectMethod SelectMethod
		{
			get { return ((ErrorLogDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ErrorLogDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ErrorLogDataSourceActionList

	/// <summary>
	/// Supports the ErrorLogDataSourceDesigner class.
	/// </summary>
	internal class ErrorLogDataSourceActionList : DesignerActionList
	{
		private ErrorLogDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ErrorLogDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ErrorLogDataSourceActionList(ErrorLogDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ErrorLogSelectMethod SelectMethod
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

	#endregion ErrorLogDataSourceActionList
	
	#endregion ErrorLogDataSourceDesigner
	
	#region ErrorLogSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ErrorLogDataSource.SelectMethod property.
	/// </summary>
	public enum ErrorLogSelectMethod
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
		/// Represents the GetByErrorLogId method.
		/// </summary>
		GetByErrorLogId
	}
	
	#endregion ErrorLogSelectMethod

	#region ErrorLogFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorLogFilter : SqlFilter<ErrorLogColumn>
	{
	}
	
	#endregion ErrorLogFilter

	#region ErrorLogExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorLogExpressionBuilder : SqlExpressionBuilder<ErrorLogColumn>
	{
	}
	
	#endregion ErrorLogExpressionBuilder	

	#region ErrorLogProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ErrorLogChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorLogProperty : ChildEntityProperty<ErrorLogChildEntityTypes>
	{
	}
	
	#endregion ErrorLogProperty
}

