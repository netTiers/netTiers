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
	/// Represents the DataRepository.NullFkeyParentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(NullFkeyParentDataSourceDesigner))]
	public class NullFkeyParentDataSource : ProviderDataSource<NullFkeyParent, NullFkeyParentKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentDataSource class.
		/// </summary>
		public NullFkeyParentDataSource() : base(new NullFkeyParentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the NullFkeyParentDataSourceView used by the NullFkeyParentDataSource.
		/// </summary>
		protected NullFkeyParentDataSourceView NullFkeyParentView
		{
			get { return ( View as NullFkeyParentDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the NullFkeyParentDataSource control invokes to retrieve data.
		/// </summary>
		public NullFkeyParentSelectMethod SelectMethod
		{
			get
			{
				NullFkeyParentSelectMethod selectMethod = NullFkeyParentSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (NullFkeyParentSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the NullFkeyParentDataSourceView class that is to be
		/// used by the NullFkeyParentDataSource.
		/// </summary>
		/// <returns>An instance of the NullFkeyParentDataSourceView class.</returns>
		protected override BaseDataSourceView<NullFkeyParent, NullFkeyParentKey> GetNewDataSourceView()
		{
			return new NullFkeyParentDataSourceView(this, DefaultViewName);
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
	/// Supports the NullFkeyParentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class NullFkeyParentDataSourceView : ProviderDataSourceView<NullFkeyParent, NullFkeyParentKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the NullFkeyParentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public NullFkeyParentDataSourceView(NullFkeyParentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal NullFkeyParentDataSource NullFkeyParentOwner
		{
			get { return Owner as NullFkeyParentDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal NullFkeyParentSelectMethod SelectMethod
		{
			get { return NullFkeyParentOwner.SelectMethod; }
			set { NullFkeyParentOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal NullFkeyParentService NullFkeyParentProvider
		{
			get { return Provider as NullFkeyParentService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<NullFkeyParent> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<NullFkeyParent> results = null;
			NullFkeyParent item;
			count = 0;
			
			System.Int32 _nullFkeyParentId;

			switch ( SelectMethod )
			{
				case NullFkeyParentSelectMethod.Get:
					NullFkeyParentKey entityKey  = new NullFkeyParentKey();
					entityKey.Load(values);
					item = NullFkeyParentProvider.Get(entityKey);
					results = new TList<NullFkeyParent>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case NullFkeyParentSelectMethod.GetAll:
                    results = NullFkeyParentProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case NullFkeyParentSelectMethod.GetPaged:
					results = NullFkeyParentProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case NullFkeyParentSelectMethod.Find:
					if ( FilterParameters != null )
						results = NullFkeyParentProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = NullFkeyParentProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case NullFkeyParentSelectMethod.GetByNullFkeyParentId:
					_nullFkeyParentId = ( values["NullFkeyParentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["NullFkeyParentId"], typeof(System.Int32)) : (int)0;
					item = NullFkeyParentProvider.GetByNullFkeyParentId(_nullFkeyParentId);
					results = new TList<NullFkeyParent>();
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
			if ( SelectMethod == NullFkeyParentSelectMethod.Get || SelectMethod == NullFkeyParentSelectMethod.GetByNullFkeyParentId )
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
				NullFkeyParent entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					NullFkeyParentProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<NullFkeyParent> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			NullFkeyParentProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region NullFkeyParentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the NullFkeyParentDataSource class.
	/// </summary>
	public class NullFkeyParentDataSourceDesigner : ProviderDataSourceDesigner<NullFkeyParent, NullFkeyParentKey>
	{
		/// <summary>
		/// Initializes a new instance of the NullFkeyParentDataSourceDesigner class.
		/// </summary>
		public NullFkeyParentDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NullFkeyParentSelectMethod SelectMethod
		{
			get { return ((NullFkeyParentDataSource) DataSource).SelectMethod; }
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
				actions.Add(new NullFkeyParentDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region NullFkeyParentDataSourceActionList

	/// <summary>
	/// Supports the NullFkeyParentDataSourceDesigner class.
	/// </summary>
	internal class NullFkeyParentDataSourceActionList : DesignerActionList
	{
		private NullFkeyParentDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public NullFkeyParentDataSourceActionList(NullFkeyParentDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NullFkeyParentSelectMethod SelectMethod
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

	#endregion NullFkeyParentDataSourceActionList
	
	#endregion NullFkeyParentDataSourceDesigner
	
	#region NullFkeyParentSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the NullFkeyParentDataSource.SelectMethod property.
	/// </summary>
	public enum NullFkeyParentSelectMethod
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
		/// Represents the GetByNullFkeyParentId method.
		/// </summary>
		GetByNullFkeyParentId
	}
	
	#endregion NullFkeyParentSelectMethod

	#region NullFkeyParentFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyParent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyParentFilter : SqlFilter<NullFkeyParentColumn>
	{
	}
	
	#endregion NullFkeyParentFilter

	#region NullFkeyParentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyParent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyParentExpressionBuilder : SqlExpressionBuilder<NullFkeyParentColumn>
	{
	}
	
	#endregion NullFkeyParentExpressionBuilder	

	#region NullFkeyParentProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;NullFkeyParentChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyParent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyParentProperty : ChildEntityProperty<NullFkeyParentChildEntityTypes>
	{
	}
	
	#endregion NullFkeyParentProperty
}

