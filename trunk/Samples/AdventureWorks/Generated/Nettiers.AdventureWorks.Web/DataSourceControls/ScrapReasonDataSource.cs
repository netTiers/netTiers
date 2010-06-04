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
	/// Represents the DataRepository.ScrapReasonProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ScrapReasonDataSourceDesigner))]
	public class ScrapReasonDataSource : ProviderDataSource<ScrapReason, ScrapReasonKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScrapReasonDataSource class.
		/// </summary>
		public ScrapReasonDataSource() : base(new ScrapReasonService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ScrapReasonDataSourceView used by the ScrapReasonDataSource.
		/// </summary>
		protected ScrapReasonDataSourceView ScrapReasonView
		{
			get { return ( View as ScrapReasonDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ScrapReasonDataSource control invokes to retrieve data.
		/// </summary>
		public ScrapReasonSelectMethod SelectMethod
		{
			get
			{
				ScrapReasonSelectMethod selectMethod = ScrapReasonSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ScrapReasonSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ScrapReasonDataSourceView class that is to be
		/// used by the ScrapReasonDataSource.
		/// </summary>
		/// <returns>An instance of the ScrapReasonDataSourceView class.</returns>
		protected override BaseDataSourceView<ScrapReason, ScrapReasonKey> GetNewDataSourceView()
		{
			return new ScrapReasonDataSourceView(this, DefaultViewName);
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
	/// Supports the ScrapReasonDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ScrapReasonDataSourceView : ProviderDataSourceView<ScrapReason, ScrapReasonKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScrapReasonDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ScrapReasonDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ScrapReasonDataSourceView(ScrapReasonDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ScrapReasonDataSource ScrapReasonOwner
		{
			get { return Owner as ScrapReasonDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ScrapReasonSelectMethod SelectMethod
		{
			get { return ScrapReasonOwner.SelectMethod; }
			set { ScrapReasonOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ScrapReasonService ScrapReasonProvider
		{
			get { return Provider as ScrapReasonService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ScrapReason> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ScrapReason> results = null;
			ScrapReason item;
			count = 0;
			
			System.String _name;
			System.Int16 _scrapReasonId;

			switch ( SelectMethod )
			{
				case ScrapReasonSelectMethod.Get:
					ScrapReasonKey entityKey  = new ScrapReasonKey();
					entityKey.Load(values);
					item = ScrapReasonProvider.Get(entityKey);
					results = new TList<ScrapReason>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ScrapReasonSelectMethod.GetAll:
                    results = ScrapReasonProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ScrapReasonSelectMethod.GetPaged:
					results = ScrapReasonProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ScrapReasonSelectMethod.Find:
					if ( FilterParameters != null )
						results = ScrapReasonProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ScrapReasonProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ScrapReasonSelectMethod.GetByScrapReasonId:
					_scrapReasonId = ( values["ScrapReasonId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["ScrapReasonId"], typeof(System.Int16)) : (short)0;
					item = ScrapReasonProvider.GetByScrapReasonId(_scrapReasonId);
					results = new TList<ScrapReason>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ScrapReasonSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ScrapReasonProvider.GetByName(_name);
					results = new TList<ScrapReason>();
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
			if ( SelectMethod == ScrapReasonSelectMethod.Get || SelectMethod == ScrapReasonSelectMethod.GetByScrapReasonId )
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
				ScrapReason entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ScrapReasonProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ScrapReason> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ScrapReasonProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ScrapReasonDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ScrapReasonDataSource class.
	/// </summary>
	public class ScrapReasonDataSourceDesigner : ProviderDataSourceDesigner<ScrapReason, ScrapReasonKey>
	{
		/// <summary>
		/// Initializes a new instance of the ScrapReasonDataSourceDesigner class.
		/// </summary>
		public ScrapReasonDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ScrapReasonSelectMethod SelectMethod
		{
			get { return ((ScrapReasonDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ScrapReasonDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ScrapReasonDataSourceActionList

	/// <summary>
	/// Supports the ScrapReasonDataSourceDesigner class.
	/// </summary>
	internal class ScrapReasonDataSourceActionList : DesignerActionList
	{
		private ScrapReasonDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ScrapReasonDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ScrapReasonDataSourceActionList(ScrapReasonDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ScrapReasonSelectMethod SelectMethod
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

	#endregion ScrapReasonDataSourceActionList
	
	#endregion ScrapReasonDataSourceDesigner
	
	#region ScrapReasonSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ScrapReasonDataSource.SelectMethod property.
	/// </summary>
	public enum ScrapReasonSelectMethod
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
		/// Represents the GetByScrapReasonId method.
		/// </summary>
		GetByScrapReasonId
	}
	
	#endregion ScrapReasonSelectMethod

	#region ScrapReasonFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScrapReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScrapReasonFilter : SqlFilter<ScrapReasonColumn>
	{
	}
	
	#endregion ScrapReasonFilter

	#region ScrapReasonExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScrapReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScrapReasonExpressionBuilder : SqlExpressionBuilder<ScrapReasonColumn>
	{
	}
	
	#endregion ScrapReasonExpressionBuilder	

	#region ScrapReasonProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ScrapReasonChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ScrapReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScrapReasonProperty : ChildEntityProperty<ScrapReasonChildEntityTypes>
	{
	}
	
	#endregion ScrapReasonProperty
}

