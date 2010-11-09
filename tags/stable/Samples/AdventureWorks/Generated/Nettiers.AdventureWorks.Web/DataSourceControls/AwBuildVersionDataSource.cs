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
	/// Represents the DataRepository.AwBuildVersionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AwBuildVersionDataSourceDesigner))]
	public class AwBuildVersionDataSource : ProviderDataSource<AwBuildVersion, AwBuildVersionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionDataSource class.
		/// </summary>
		public AwBuildVersionDataSource() : base(new AwBuildVersionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AwBuildVersionDataSourceView used by the AwBuildVersionDataSource.
		/// </summary>
		protected AwBuildVersionDataSourceView AwBuildVersionView
		{
			get { return ( View as AwBuildVersionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AwBuildVersionDataSource control invokes to retrieve data.
		/// </summary>
		public AwBuildVersionSelectMethod SelectMethod
		{
			get
			{
				AwBuildVersionSelectMethod selectMethod = AwBuildVersionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AwBuildVersionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AwBuildVersionDataSourceView class that is to be
		/// used by the AwBuildVersionDataSource.
		/// </summary>
		/// <returns>An instance of the AwBuildVersionDataSourceView class.</returns>
		protected override BaseDataSourceView<AwBuildVersion, AwBuildVersionKey> GetNewDataSourceView()
		{
			return new AwBuildVersionDataSourceView(this, DefaultViewName);
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
	/// Supports the AwBuildVersionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AwBuildVersionDataSourceView : ProviderDataSourceView<AwBuildVersion, AwBuildVersionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AwBuildVersionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AwBuildVersionDataSourceView(AwBuildVersionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AwBuildVersionDataSource AwBuildVersionOwner
		{
			get { return Owner as AwBuildVersionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AwBuildVersionSelectMethod SelectMethod
		{
			get { return AwBuildVersionOwner.SelectMethod; }
			set { AwBuildVersionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AwBuildVersionService AwBuildVersionProvider
		{
			get { return Provider as AwBuildVersionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AwBuildVersion> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AwBuildVersion> results = null;
			AwBuildVersion item;
			count = 0;
			
			System.Byte _systemInformationId;

			switch ( SelectMethod )
			{
				case AwBuildVersionSelectMethod.Get:
					AwBuildVersionKey entityKey  = new AwBuildVersionKey();
					entityKey.Load(values);
					item = AwBuildVersionProvider.Get(entityKey);
					results = new TList<AwBuildVersion>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AwBuildVersionSelectMethod.GetAll:
                    results = AwBuildVersionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AwBuildVersionSelectMethod.GetPaged:
					results = AwBuildVersionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AwBuildVersionSelectMethod.Find:
					if ( FilterParameters != null )
						results = AwBuildVersionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AwBuildVersionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AwBuildVersionSelectMethod.GetBySystemInformationId:
					_systemInformationId = ( values["SystemInformationId"] != null ) ? (System.Byte) EntityUtil.ChangeType(values["SystemInformationId"], typeof(System.Byte)) : (byte)0;
					item = AwBuildVersionProvider.GetBySystemInformationId(_systemInformationId);
					results = new TList<AwBuildVersion>();
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
			if ( SelectMethod == AwBuildVersionSelectMethod.Get || SelectMethod == AwBuildVersionSelectMethod.GetBySystemInformationId )
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
				AwBuildVersion entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AwBuildVersionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AwBuildVersion> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AwBuildVersionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AwBuildVersionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AwBuildVersionDataSource class.
	/// </summary>
	public class AwBuildVersionDataSourceDesigner : ProviderDataSourceDesigner<AwBuildVersion, AwBuildVersionKey>
	{
		/// <summary>
		/// Initializes a new instance of the AwBuildVersionDataSourceDesigner class.
		/// </summary>
		public AwBuildVersionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AwBuildVersionSelectMethod SelectMethod
		{
			get { return ((AwBuildVersionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AwBuildVersionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AwBuildVersionDataSourceActionList

	/// <summary>
	/// Supports the AwBuildVersionDataSourceDesigner class.
	/// </summary>
	internal class AwBuildVersionDataSourceActionList : DesignerActionList
	{
		private AwBuildVersionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AwBuildVersionDataSourceActionList(AwBuildVersionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AwBuildVersionSelectMethod SelectMethod
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

	#endregion AwBuildVersionDataSourceActionList
	
	#endregion AwBuildVersionDataSourceDesigner
	
	#region AwBuildVersionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AwBuildVersionDataSource.SelectMethod property.
	/// </summary>
	public enum AwBuildVersionSelectMethod
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
		/// Represents the GetBySystemInformationId method.
		/// </summary>
		GetBySystemInformationId
	}
	
	#endregion AwBuildVersionSelectMethod

	#region AwBuildVersionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AwBuildVersion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AwBuildVersionFilter : SqlFilter<AwBuildVersionColumn>
	{
	}
	
	#endregion AwBuildVersionFilter

	#region AwBuildVersionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AwBuildVersion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AwBuildVersionExpressionBuilder : SqlExpressionBuilder<AwBuildVersionColumn>
	{
	}
	
	#endregion AwBuildVersionExpressionBuilder	

	#region AwBuildVersionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AwBuildVersionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AwBuildVersion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AwBuildVersionProperty : ChildEntityProperty<AwBuildVersionChildEntityTypes>
	{
	}
	
	#endregion AwBuildVersionProperty
}

