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
	/// Represents the DataRepository.InventoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(InventoryDataSourceDesigner))]
	public class InventoryDataSource : ProviderDataSource<Inventory, InventoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InventoryDataSource class.
		/// </summary>
		public InventoryDataSource() : base(new InventoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the InventoryDataSourceView used by the InventoryDataSource.
		/// </summary>
		protected InventoryDataSourceView InventoryView
		{
			get { return ( View as InventoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the InventoryDataSource control invokes to retrieve data.
		/// </summary>
		public InventorySelectMethod SelectMethod
		{
			get { return InventoryView.SelectMethod; }
			set { InventoryView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the InventoryDataSourceView class that is to be
		/// used by the InventoryDataSource.
		/// </summary>
		/// <returns>An instance of the InventoryDataSourceView class.</returns>
		protected override BaseDataSourceView<Inventory, InventoryKey> GetNewDataSourceView()
		{
			return new InventoryDataSourceView(this, DefaultViewName);
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
	/// Supports the InventoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class InventoryDataSourceView : ProviderDataSourceView<Inventory, InventoryKey>
	{
		#region Declarations

		private InventorySelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InventoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the InventoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public InventoryDataSourceView(InventoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal InventorySelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal InventoryService InventoryProvider
		{
			get { return Provider as InventoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Inventory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<Inventory> results = null;
			Inventory item;
			count = 0;
			
			System.Guid itemId;
			System.Guid suppId;

			switch ( SelectMethod )
			{
				case InventorySelectMethod.Get:
					InventoryKey entityKey  = new InventoryKey();
					entityKey.Load(values);
					item = InventoryProvider.Get(entityKey);
					results = new TList<Inventory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case InventorySelectMethod.GetAll:
                    results = InventoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case InventorySelectMethod.GetPaged:
					results = InventoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case InventorySelectMethod.Find:
					results = InventoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case InventorySelectMethod.GetByItemIdSuppId:
					itemId = ( values["ItemId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ItemId"], typeof(System.Guid)) : Guid.Empty;
					suppId = ( values["SuppId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["SuppId"], typeof(System.Guid)) : Guid.Empty;
					item = InventoryProvider.GetByItemIdSuppId(itemId, suppId);
					results = new TList<Inventory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case InventorySelectMethod.GetByItemId:
					itemId = ( values["ItemId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ItemId"], typeof(System.Guid)) : Guid.Empty;
					results = InventoryProvider.GetByItemId(itemId, this.StartIndex, this.PageSize, out count);
					break;
				case InventorySelectMethod.GetBySuppId:
					suppId = ( values["SuppId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["SuppId"], typeof(System.Guid)) : Guid.Empty;
					results = InventoryProvider.GetBySuppId(suppId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
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
			if ( SelectMethod == InventorySelectMethod.Get || SelectMethod == InventorySelectMethod.GetByItemIdSuppId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(Inventory entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.ItemId == Guid.Empty )
				entity.ItemId = Guid.NewGuid();
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
				Inventory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					InventoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					IsDeepLoaded = true;
				}
			}
		}

		#endregion Select Methods
	}
	
	#region InventoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the InventoryDataSource class.
	/// </summary>
	public class InventoryDataSourceDesigner : ProviderDataSourceDesigner<Inventory, InventoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the InventoryDataSourceDesigner class.
		/// </summary>
		public InventoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InventorySelectMethod SelectMethod
		{
			get { return ((InventoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new InventoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region InventoryDataSourceActionList

	/// <summary>
	/// Supports the InventoryDataSourceDesigner class.
	/// </summary>
	internal class InventoryDataSourceActionList : DesignerActionList
	{
		private InventoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the InventoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public InventoryDataSourceActionList(InventoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InventorySelectMethod SelectMethod
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

	#endregion InventoryDataSourceActionList
	
	#endregion InventoryDataSourceDesigner
	
	#region InventorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the InventoryDataSource.SelectMethod property.
	/// </summary>
	public enum InventorySelectMethod
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
		/// Represents the GetByItemIdSuppId method.
		/// </summary>
		GetByItemIdSuppId,
		/// <summary>
		/// Represents the GetByItemId method.
		/// </summary>
		GetByItemId,
		/// <summary>
		/// Represents the GetBySuppId method.
		/// </summary>
		GetBySuppId
	}
	
	#endregion InventorySelectMethod

	#region InventoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Inventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InventoryFilter : SqlFilter<InventoryColumn>
	{
	}
	
	#endregion InventoryFilter
}

