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
	/// Represents the DataRepository.NullFkeyChildProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(NullFkeyChildDataSourceDesigner))]
	public class NullFkeyChildDataSource : ProviderDataSource<NullFkeyChild, NullFkeyChildKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildDataSource class.
		/// </summary>
		public NullFkeyChildDataSource() : base(new NullFkeyChildService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the NullFkeyChildDataSourceView used by the NullFkeyChildDataSource.
		/// </summary>
		protected NullFkeyChildDataSourceView NullFkeyChildView
		{
			get { return ( View as NullFkeyChildDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the NullFkeyChildDataSource control invokes to retrieve data.
		/// </summary>
		public NullFkeyChildSelectMethod SelectMethod
		{
			get
			{
				NullFkeyChildSelectMethod selectMethod = NullFkeyChildSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (NullFkeyChildSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the NullFkeyChildDataSourceView class that is to be
		/// used by the NullFkeyChildDataSource.
		/// </summary>
		/// <returns>An instance of the NullFkeyChildDataSourceView class.</returns>
		protected override BaseDataSourceView<NullFkeyChild, NullFkeyChildKey> GetNewDataSourceView()
		{
			return new NullFkeyChildDataSourceView(this, DefaultViewName);
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
	/// Supports the NullFkeyChildDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class NullFkeyChildDataSourceView : ProviderDataSourceView<NullFkeyChild, NullFkeyChildKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the NullFkeyChildDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public NullFkeyChildDataSourceView(NullFkeyChildDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal NullFkeyChildDataSource NullFkeyChildOwner
		{
			get { return Owner as NullFkeyChildDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal NullFkeyChildSelectMethod SelectMethod
		{
			get { return NullFkeyChildOwner.SelectMethod; }
			set { NullFkeyChildOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal NullFkeyChildService NullFkeyChildProvider
		{
			get { return Provider as NullFkeyChildService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<NullFkeyChild> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<NullFkeyChild> results = null;
			NullFkeyChild item;
			count = 0;
			
			System.Int32 _nullFkeyChildId;
			System.Int32? _nullFkeyParentId_nullable;

			switch ( SelectMethod )
			{
				case NullFkeyChildSelectMethod.Get:
					NullFkeyChildKey entityKey  = new NullFkeyChildKey();
					entityKey.Load(values);
					item = NullFkeyChildProvider.Get(entityKey);
					results = new TList<NullFkeyChild>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case NullFkeyChildSelectMethod.GetAll:
                    results = NullFkeyChildProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case NullFkeyChildSelectMethod.GetPaged:
					results = NullFkeyChildProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case NullFkeyChildSelectMethod.Find:
					if ( FilterParameters != null )
						results = NullFkeyChildProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = NullFkeyChildProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case NullFkeyChildSelectMethod.GetByNullFkeyChildId:
					_nullFkeyChildId = ( values["NullFkeyChildId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["NullFkeyChildId"], typeof(System.Int32)) : (int)0;
					item = NullFkeyChildProvider.GetByNullFkeyChildId(_nullFkeyChildId);
					results = new TList<NullFkeyChild>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case NullFkeyChildSelectMethod.GetByNullFkeyParentId:
					_nullFkeyParentId_nullable = (System.Int32?) EntityUtil.ChangeType(values["NullFkeyParentId"], typeof(System.Int32?));
					results = NullFkeyChildProvider.GetByNullFkeyParentId(_nullFkeyParentId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == NullFkeyChildSelectMethod.Get || SelectMethod == NullFkeyChildSelectMethod.GetByNullFkeyChildId )
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
				NullFkeyChild entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					NullFkeyChildProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<NullFkeyChild> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			NullFkeyChildProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region NullFkeyChildDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the NullFkeyChildDataSource class.
	/// </summary>
	public class NullFkeyChildDataSourceDesigner : ProviderDataSourceDesigner<NullFkeyChild, NullFkeyChildKey>
	{
		/// <summary>
		/// Initializes a new instance of the NullFkeyChildDataSourceDesigner class.
		/// </summary>
		public NullFkeyChildDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NullFkeyChildSelectMethod SelectMethod
		{
			get { return ((NullFkeyChildDataSource) DataSource).SelectMethod; }
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
				actions.Add(new NullFkeyChildDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region NullFkeyChildDataSourceActionList

	/// <summary>
	/// Supports the NullFkeyChildDataSourceDesigner class.
	/// </summary>
	internal class NullFkeyChildDataSourceActionList : DesignerActionList
	{
		private NullFkeyChildDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public NullFkeyChildDataSourceActionList(NullFkeyChildDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NullFkeyChildSelectMethod SelectMethod
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

	#endregion NullFkeyChildDataSourceActionList
	
	#endregion NullFkeyChildDataSourceDesigner
	
	#region NullFkeyChildSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the NullFkeyChildDataSource.SelectMethod property.
	/// </summary>
	public enum NullFkeyChildSelectMethod
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
		/// Represents the GetByNullFkeyChildId method.
		/// </summary>
		GetByNullFkeyChildId,
		/// <summary>
		/// Represents the GetByNullFkeyParentId method.
		/// </summary>
		GetByNullFkeyParentId
	}
	
	#endregion NullFkeyChildSelectMethod

	#region NullFkeyChildFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyChild"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyChildFilter : SqlFilter<NullFkeyChildColumn>
	{
	}
	
	#endregion NullFkeyChildFilter

	#region NullFkeyChildExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyChild"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyChildExpressionBuilder : SqlExpressionBuilder<NullFkeyChildColumn>
	{
	}
	
	#endregion NullFkeyChildExpressionBuilder	

	#region NullFkeyChildProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;NullFkeyChildChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyChild"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyChildProperty : ChildEntityProperty<NullFkeyChildChildEntityTypes>
	{
	}
	
	#endregion NullFkeyChildProperty
}

