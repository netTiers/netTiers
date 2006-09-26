#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.Bases;
using netTiers.Petshop.Services;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.SupplierProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SupplierDataSourceDesigner))]
	public class SupplierDataSource : ProviderDataSource<Supplier, SupplierKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SupplierDataSource class.
		/// </summary>
		public SupplierDataSource() : base(new SupplierService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SupplierDataSourceView used by the SupplierDataSource.
		/// </summary>
		protected SupplierDataSourceView SupplierView
		{
			get { return ( View as SupplierDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SupplierDataSource control invokes to retrieve data.
		/// </summary>
		public SupplierSelectMethod SelectMethod
		{
			get { return SupplierView.SelectMethod; }
			set { SupplierView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SupplierDataSourceView class that is to be
		/// used by the SupplierDataSource.
		/// </summary>
		/// <returns>An instance of the SupplierDataSourceView class.</returns>
		protected override BaseDataSourceView<Supplier, SupplierKey> GetNewDataSourceView()
		{
			return new SupplierDataSourceView(this, DefaultViewName);
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
	/// Supports the SupplierDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SupplierDataSourceView : ProviderDataSourceView<Supplier, SupplierKey>
	{
		#region Declarations

		private SupplierSelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SupplierDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SupplierDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SupplierDataSourceView(SupplierDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SupplierSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SupplierService SupplierProvider
		{
			get { return Provider as SupplierService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Supplier> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<Supplier> results = null;
			Supplier item;
			count = 0;
			
			System.Guid suppId;
			System.Guid itemId;

			switch ( SelectMethod )
			{
				case SupplierSelectMethod.Get:
					SupplierKey entityKey  = new SupplierKey();
					entityKey.Load(values);
					item = SupplierProvider.Get(entityKey);
					results = new TList<Supplier>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SupplierSelectMethod.GetAll:
                    results = SupplierProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SupplierSelectMethod.GetPaged:
					results = SupplierProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SupplierSelectMethod.Find:
					results = SupplierProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SupplierSelectMethod.GetBySuppId:
					suppId = ( values["SuppId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["SuppId"], typeof(System.Guid)) : Guid.Empty;
					item = SupplierProvider.GetBySuppId(suppId);
					results = new TList<Supplier>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case SupplierSelectMethod.GetByItemIdFromInventory:
					itemId = ( values["ItemId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ItemId"], typeof(System.Guid)) : Guid.Empty;
					results = SupplierProvider.GetByItemIdFromInventory(itemId, this.StartIndex, this.PageSize, out count);
					break;
				default:
					break;
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == SupplierSelectMethod.Get || SelectMethod == SupplierSelectMethod.GetBySuppId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(Supplier entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.SuppId == Guid.Empty )
				entity.SuppId = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Supplier entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SupplierProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					IsDeepLoaded = true;
				}
			}
		}

		#endregion Select Methods
	}
	
	#region SupplierDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SupplierDataSource class.
	/// </summary>
	public class SupplierDataSourceDesigner : ProviderDataSourceDesigner<Supplier, SupplierKey>
	{
		/// <summary>
		/// Initializes a new instance of the SupplierDataSourceDesigner class.
		/// </summary>
		public SupplierDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SupplierSelectMethod SelectMethod
		{
			get { return ((SupplierDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SupplierDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SupplierDataSourceActionList

	/// <summary>
	/// Supports the SupplierDataSourceDesigner class.
	/// </summary>
	internal class SupplierDataSourceActionList : DesignerActionList
	{
		private SupplierDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SupplierDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SupplierDataSourceActionList(SupplierDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SupplierSelectMethod SelectMethod
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

	#endregion SupplierDataSourceActionList
	
	#endregion SupplierDataSourceDesigner
	
	#region SupplierSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SupplierDataSource.SelectMethod property.
	/// </summary>
	public enum SupplierSelectMethod
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
		/// Represents the GetBySuppId method.
		/// </summary>
		GetBySuppId,
		/// <summary>
		/// Represents the GetByItemIdFromInventory method.
		/// </summary>
		GetByItemIdFromInventory
	}
	
	#endregion SupplierSelectMethod

	#region SupplierFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Supplier"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SupplierFilter : SqlFilter<SupplierColumn>
	{
	}
	
	#endregion SupplierFilter
}

