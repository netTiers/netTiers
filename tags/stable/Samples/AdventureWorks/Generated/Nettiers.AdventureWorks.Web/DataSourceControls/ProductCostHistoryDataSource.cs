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
	/// Represents the DataRepository.ProductCostHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductCostHistoryDataSourceDesigner))]
	public class ProductCostHistoryDataSource : ProviderDataSource<ProductCostHistory, ProductCostHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryDataSource class.
		/// </summary>
		public ProductCostHistoryDataSource() : base(new ProductCostHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductCostHistoryDataSourceView used by the ProductCostHistoryDataSource.
		/// </summary>
		protected ProductCostHistoryDataSourceView ProductCostHistoryView
		{
			get { return ( View as ProductCostHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductCostHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public ProductCostHistorySelectMethod SelectMethod
		{
			get
			{
				ProductCostHistorySelectMethod selectMethod = ProductCostHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductCostHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductCostHistoryDataSourceView class that is to be
		/// used by the ProductCostHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the ProductCostHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductCostHistory, ProductCostHistoryKey> GetNewDataSourceView()
		{
			return new ProductCostHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductCostHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductCostHistoryDataSourceView : ProviderDataSourceView<ProductCostHistory, ProductCostHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductCostHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductCostHistoryDataSourceView(ProductCostHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductCostHistoryDataSource ProductCostHistoryOwner
		{
			get { return Owner as ProductCostHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductCostHistorySelectMethod SelectMethod
		{
			get { return ProductCostHistoryOwner.SelectMethod; }
			set { ProductCostHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductCostHistoryService ProductCostHistoryProvider
		{
			get { return Provider as ProductCostHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductCostHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductCostHistory> results = null;
			ProductCostHistory item;
			count = 0;
			
			System.Int32 _productId;
			System.DateTime _startDate;

			switch ( SelectMethod )
			{
				case ProductCostHistorySelectMethod.Get:
					ProductCostHistoryKey entityKey  = new ProductCostHistoryKey();
					entityKey.Load(values);
					item = ProductCostHistoryProvider.Get(entityKey);
					results = new TList<ProductCostHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductCostHistorySelectMethod.GetAll:
                    results = ProductCostHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductCostHistorySelectMethod.GetPaged:
					results = ProductCostHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductCostHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductCostHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductCostHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductCostHistorySelectMethod.GetByProductIdStartDate:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_startDate = ( values["StartDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartDate"], typeof(System.DateTime)) : DateTime.MinValue;
					item = ProductCostHistoryProvider.GetByProductIdStartDate(_productId, _startDate);
					results = new TList<ProductCostHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProductCostHistorySelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductCostHistoryProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductCostHistorySelectMethod.Get || SelectMethod == ProductCostHistorySelectMethod.GetByProductIdStartDate )
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
				ProductCostHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductCostHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductCostHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductCostHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductCostHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductCostHistoryDataSource class.
	/// </summary>
	public class ProductCostHistoryDataSourceDesigner : ProviderDataSourceDesigner<ProductCostHistory, ProductCostHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryDataSourceDesigner class.
		/// </summary>
		public ProductCostHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductCostHistorySelectMethod SelectMethod
		{
			get { return ((ProductCostHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductCostHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductCostHistoryDataSourceActionList

	/// <summary>
	/// Supports the ProductCostHistoryDataSourceDesigner class.
	/// </summary>
	internal class ProductCostHistoryDataSourceActionList : DesignerActionList
	{
		private ProductCostHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductCostHistoryDataSourceActionList(ProductCostHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductCostHistorySelectMethod SelectMethod
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

	#endregion ProductCostHistoryDataSourceActionList
	
	#endregion ProductCostHistoryDataSourceDesigner
	
	#region ProductCostHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductCostHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum ProductCostHistorySelectMethod
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
	
	#endregion ProductCostHistorySelectMethod

	#region ProductCostHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCostHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCostHistoryFilter : SqlFilter<ProductCostHistoryColumn>
	{
	}
	
	#endregion ProductCostHistoryFilter

	#region ProductCostHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCostHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCostHistoryExpressionBuilder : SqlExpressionBuilder<ProductCostHistoryColumn>
	{
	}
	
	#endregion ProductCostHistoryExpressionBuilder	

	#region ProductCostHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductCostHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCostHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCostHistoryProperty : ChildEntityProperty<ProductCostHistoryChildEntityTypes>
	{
	}
	
	#endregion ProductCostHistoryProperty
}

