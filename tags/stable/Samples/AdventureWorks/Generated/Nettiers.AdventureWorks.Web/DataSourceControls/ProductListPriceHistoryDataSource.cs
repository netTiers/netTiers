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
	/// Represents the DataRepository.ProductListPriceHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductListPriceHistoryDataSourceDesigner))]
	public class ProductListPriceHistoryDataSource : ProviderDataSource<ProductListPriceHistory, ProductListPriceHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryDataSource class.
		/// </summary>
		public ProductListPriceHistoryDataSource() : base(new ProductListPriceHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductListPriceHistoryDataSourceView used by the ProductListPriceHistoryDataSource.
		/// </summary>
		protected ProductListPriceHistoryDataSourceView ProductListPriceHistoryView
		{
			get { return ( View as ProductListPriceHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductListPriceHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public ProductListPriceHistorySelectMethod SelectMethod
		{
			get
			{
				ProductListPriceHistorySelectMethod selectMethod = ProductListPriceHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductListPriceHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductListPriceHistoryDataSourceView class that is to be
		/// used by the ProductListPriceHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the ProductListPriceHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductListPriceHistory, ProductListPriceHistoryKey> GetNewDataSourceView()
		{
			return new ProductListPriceHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductListPriceHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductListPriceHistoryDataSourceView : ProviderDataSourceView<ProductListPriceHistory, ProductListPriceHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductListPriceHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductListPriceHistoryDataSourceView(ProductListPriceHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductListPriceHistoryDataSource ProductListPriceHistoryOwner
		{
			get { return Owner as ProductListPriceHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductListPriceHistorySelectMethod SelectMethod
		{
			get { return ProductListPriceHistoryOwner.SelectMethod; }
			set { ProductListPriceHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductListPriceHistoryService ProductListPriceHistoryProvider
		{
			get { return Provider as ProductListPriceHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductListPriceHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductListPriceHistory> results = null;
			ProductListPriceHistory item;
			count = 0;
			
			System.Int32 _productId;
			System.DateTime _startDate;

			switch ( SelectMethod )
			{
				case ProductListPriceHistorySelectMethod.Get:
					ProductListPriceHistoryKey entityKey  = new ProductListPriceHistoryKey();
					entityKey.Load(values);
					item = ProductListPriceHistoryProvider.Get(entityKey);
					results = new TList<ProductListPriceHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductListPriceHistorySelectMethod.GetAll:
                    results = ProductListPriceHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductListPriceHistorySelectMethod.GetPaged:
					results = ProductListPriceHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductListPriceHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductListPriceHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductListPriceHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductListPriceHistorySelectMethod.GetByProductIdStartDate:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_startDate = ( values["StartDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartDate"], typeof(System.DateTime)) : DateTime.MinValue;
					item = ProductListPriceHistoryProvider.GetByProductIdStartDate(_productId, _startDate);
					results = new TList<ProductListPriceHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProductListPriceHistorySelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductListPriceHistoryProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductListPriceHistorySelectMethod.Get || SelectMethod == ProductListPriceHistorySelectMethod.GetByProductIdStartDate )
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
				ProductListPriceHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductListPriceHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductListPriceHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductListPriceHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductListPriceHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductListPriceHistoryDataSource class.
	/// </summary>
	public class ProductListPriceHistoryDataSourceDesigner : ProviderDataSourceDesigner<ProductListPriceHistory, ProductListPriceHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryDataSourceDesigner class.
		/// </summary>
		public ProductListPriceHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductListPriceHistorySelectMethod SelectMethod
		{
			get { return ((ProductListPriceHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductListPriceHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductListPriceHistoryDataSourceActionList

	/// <summary>
	/// Supports the ProductListPriceHistoryDataSourceDesigner class.
	/// </summary>
	internal class ProductListPriceHistoryDataSourceActionList : DesignerActionList
	{
		private ProductListPriceHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductListPriceHistoryDataSourceActionList(ProductListPriceHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductListPriceHistorySelectMethod SelectMethod
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

	#endregion ProductListPriceHistoryDataSourceActionList
	
	#endregion ProductListPriceHistoryDataSourceDesigner
	
	#region ProductListPriceHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductListPriceHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum ProductListPriceHistorySelectMethod
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
		/// Represents the GetByProductIdStartDate method.
		/// </summary>
		GetByProductIdStartDate,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion ProductListPriceHistorySelectMethod

	#region ProductListPriceHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductListPriceHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductListPriceHistoryFilter : SqlFilter<ProductListPriceHistoryColumn>
	{
	}
	
	#endregion ProductListPriceHistoryFilter

	#region ProductListPriceHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductListPriceHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductListPriceHistoryExpressionBuilder : SqlExpressionBuilder<ProductListPriceHistoryColumn>
	{
	}
	
	#endregion ProductListPriceHistoryExpressionBuilder	

	#region ProductListPriceHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductListPriceHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductListPriceHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductListPriceHistoryProperty : ChildEntityProperty<ProductListPriceHistoryChildEntityTypes>
	{
	}
	
	#endregion ProductListPriceHistoryProperty
}

