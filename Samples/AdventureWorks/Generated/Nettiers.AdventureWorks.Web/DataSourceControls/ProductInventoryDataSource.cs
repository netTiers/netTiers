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
	/// Represents the DataRepository.ProductInventoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductInventoryDataSourceDesigner))]
	public class ProductInventoryDataSource : ProviderDataSource<ProductInventory, ProductInventoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductInventoryDataSource class.
		/// </summary>
		public ProductInventoryDataSource() : base(new ProductInventoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductInventoryDataSourceView used by the ProductInventoryDataSource.
		/// </summary>
		protected ProductInventoryDataSourceView ProductInventoryView
		{
			get { return ( View as ProductInventoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductInventoryDataSource control invokes to retrieve data.
		/// </summary>
		public ProductInventorySelectMethod SelectMethod
		{
			get
			{
				ProductInventorySelectMethod selectMethod = ProductInventorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductInventorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductInventoryDataSourceView class that is to be
		/// used by the ProductInventoryDataSource.
		/// </summary>
		/// <returns>An instance of the ProductInventoryDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductInventory, ProductInventoryKey> GetNewDataSourceView()
		{
			return new ProductInventoryDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductInventoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductInventoryDataSourceView : ProviderDataSourceView<ProductInventory, ProductInventoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductInventoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductInventoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductInventoryDataSourceView(ProductInventoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductInventoryDataSource ProductInventoryOwner
		{
			get { return Owner as ProductInventoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductInventorySelectMethod SelectMethod
		{
			get { return ProductInventoryOwner.SelectMethod; }
			set { ProductInventoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductInventoryService ProductInventoryProvider
		{
			get { return Provider as ProductInventoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductInventory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductInventory> results = null;
			ProductInventory item;
			count = 0;
			
			System.Int32 _productId;
			System.Int16 _locationId;

			switch ( SelectMethod )
			{
				case ProductInventorySelectMethod.Get:
					ProductInventoryKey entityKey  = new ProductInventoryKey();
					entityKey.Load(values);
					item = ProductInventoryProvider.Get(entityKey);
					results = new TList<ProductInventory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductInventorySelectMethod.GetAll:
                    results = ProductInventoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductInventorySelectMethod.GetPaged:
					results = ProductInventoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductInventorySelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductInventoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductInventoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductInventorySelectMethod.GetByProductIdLocationId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_locationId = ( values["LocationId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["LocationId"], typeof(System.Int16)) : (short)0;
					item = ProductInventoryProvider.GetByProductIdLocationId(_productId, _locationId);
					results = new TList<ProductInventory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProductInventorySelectMethod.GetByLocationId:
					_locationId = ( values["LocationId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["LocationId"], typeof(System.Int16)) : (short)0;
					results = ProductInventoryProvider.GetByLocationId(_locationId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductInventorySelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductInventoryProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductInventorySelectMethod.Get || SelectMethod == ProductInventorySelectMethod.GetByProductIdLocationId )
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
				ProductInventory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductInventoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductInventory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductInventoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductInventoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductInventoryDataSource class.
	/// </summary>
	public class ProductInventoryDataSourceDesigner : ProviderDataSourceDesigner<ProductInventory, ProductInventoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductInventoryDataSourceDesigner class.
		/// </summary>
		public ProductInventoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductInventorySelectMethod SelectMethod
		{
			get { return ((ProductInventoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductInventoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductInventoryDataSourceActionList

	/// <summary>
	/// Supports the ProductInventoryDataSourceDesigner class.
	/// </summary>
	internal class ProductInventoryDataSourceActionList : DesignerActionList
	{
		private ProductInventoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductInventoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductInventoryDataSourceActionList(ProductInventoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductInventorySelectMethod SelectMethod
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

	#endregion ProductInventoryDataSourceActionList
	
	#endregion ProductInventoryDataSourceDesigner
	
	#region ProductInventorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductInventoryDataSource.SelectMethod property.
	/// </summary>
	public enum ProductInventorySelectMethod
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
		/// Represents the GetByProductIdLocationId method.
		/// </summary>
		GetByProductIdLocationId,
		/// <summary>
		/// Represents the GetByLocationId method.
		/// </summary>
		GetByLocationId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion ProductInventorySelectMethod

	#region ProductInventoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductInventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductInventoryFilter : SqlFilter<ProductInventoryColumn>
	{
	}
	
	#endregion ProductInventoryFilter

	#region ProductInventoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductInventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductInventoryExpressionBuilder : SqlExpressionBuilder<ProductInventoryColumn>
	{
	}
	
	#endregion ProductInventoryExpressionBuilder	

	#region ProductInventoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductInventoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductInventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductInventoryProperty : ChildEntityProperty<ProductInventoryChildEntityTypes>
	{
	}
	
	#endregion ProductInventoryProperty
}

