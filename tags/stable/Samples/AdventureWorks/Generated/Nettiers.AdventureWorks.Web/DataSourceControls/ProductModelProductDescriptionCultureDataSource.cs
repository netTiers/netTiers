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
	/// Represents the DataRepository.ProductModelProductDescriptionCultureProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductModelProductDescriptionCultureDataSourceDesigner))]
	public class ProductModelProductDescriptionCultureDataSource : ProviderDataSource<ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureDataSource class.
		/// </summary>
		public ProductModelProductDescriptionCultureDataSource() : base(new ProductModelProductDescriptionCultureService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductModelProductDescriptionCultureDataSourceView used by the ProductModelProductDescriptionCultureDataSource.
		/// </summary>
		protected ProductModelProductDescriptionCultureDataSourceView ProductModelProductDescriptionCultureView
		{
			get { return ( View as ProductModelProductDescriptionCultureDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductModelProductDescriptionCultureDataSource control invokes to retrieve data.
		/// </summary>
		public ProductModelProductDescriptionCultureSelectMethod SelectMethod
		{
			get
			{
				ProductModelProductDescriptionCultureSelectMethod selectMethod = ProductModelProductDescriptionCultureSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductModelProductDescriptionCultureSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductModelProductDescriptionCultureDataSourceView class that is to be
		/// used by the ProductModelProductDescriptionCultureDataSource.
		/// </summary>
		/// <returns>An instance of the ProductModelProductDescriptionCultureDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureKey> GetNewDataSourceView()
		{
			return new ProductModelProductDescriptionCultureDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductModelProductDescriptionCultureDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductModelProductDescriptionCultureDataSourceView : ProviderDataSourceView<ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductModelProductDescriptionCultureDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductModelProductDescriptionCultureDataSourceView(ProductModelProductDescriptionCultureDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductModelProductDescriptionCultureDataSource ProductModelProductDescriptionCultureOwner
		{
			get { return Owner as ProductModelProductDescriptionCultureDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductModelProductDescriptionCultureSelectMethod SelectMethod
		{
			get { return ProductModelProductDescriptionCultureOwner.SelectMethod; }
			set { ProductModelProductDescriptionCultureOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductModelProductDescriptionCultureService ProductModelProductDescriptionCultureProvider
		{
			get { return Provider as ProductModelProductDescriptionCultureService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductModelProductDescriptionCulture> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductModelProductDescriptionCulture> results = null;
			ProductModelProductDescriptionCulture item;
			count = 0;
			
			System.Int32 _productModelId;
			System.Int32 _productDescriptionId;
			System.String _cultureId;

			switch ( SelectMethod )
			{
				case ProductModelProductDescriptionCultureSelectMethod.Get:
					ProductModelProductDescriptionCultureKey entityKey  = new ProductModelProductDescriptionCultureKey();
					entityKey.Load(values);
					item = ProductModelProductDescriptionCultureProvider.Get(entityKey);
					results = new TList<ProductModelProductDescriptionCulture>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductModelProductDescriptionCultureSelectMethod.GetAll:
                    results = ProductModelProductDescriptionCultureProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductModelProductDescriptionCultureSelectMethod.GetPaged:
					results = ProductModelProductDescriptionCultureProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductModelProductDescriptionCultureSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductModelProductDescriptionCultureProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductModelProductDescriptionCultureProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductModelProductDescriptionCultureSelectMethod.GetByProductModelIdProductDescriptionIdCultureId:
					_productModelId = ( values["ProductModelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32)) : (int)0;
					_productDescriptionId = ( values["ProductDescriptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductDescriptionId"], typeof(System.Int32)) : (int)0;
					_cultureId = ( values["CultureId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CultureId"], typeof(System.String)) : string.Empty;
					item = ProductModelProductDescriptionCultureProvider.GetByProductModelIdProductDescriptionIdCultureId(_productModelId, _productDescriptionId, _cultureId);
					results = new TList<ProductModelProductDescriptionCulture>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProductModelProductDescriptionCultureSelectMethod.GetByCultureId:
					_cultureId = ( values["CultureId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CultureId"], typeof(System.String)) : string.Empty;
					results = ProductModelProductDescriptionCultureProvider.GetByCultureId(_cultureId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductModelProductDescriptionCultureSelectMethod.GetByProductDescriptionId:
					_productDescriptionId = ( values["ProductDescriptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductDescriptionId"], typeof(System.Int32)) : (int)0;
					results = ProductModelProductDescriptionCultureProvider.GetByProductDescriptionId(_productDescriptionId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductModelProductDescriptionCultureSelectMethod.GetByProductModelId:
					_productModelId = ( values["ProductModelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32)) : (int)0;
					results = ProductModelProductDescriptionCultureProvider.GetByProductModelId(_productModelId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductModelProductDescriptionCultureSelectMethod.Get || SelectMethod == ProductModelProductDescriptionCultureSelectMethod.GetByProductModelIdProductDescriptionIdCultureId )
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
				ProductModelProductDescriptionCulture entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductModelProductDescriptionCultureProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductModelProductDescriptionCulture> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductModelProductDescriptionCultureProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductModelProductDescriptionCultureDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductModelProductDescriptionCultureDataSource class.
	/// </summary>
	public class ProductModelProductDescriptionCultureDataSourceDesigner : ProviderDataSourceDesigner<ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureDataSourceDesigner class.
		/// </summary>
		public ProductModelProductDescriptionCultureDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductModelProductDescriptionCultureSelectMethod SelectMethod
		{
			get { return ((ProductModelProductDescriptionCultureDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductModelProductDescriptionCultureDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductModelProductDescriptionCultureDataSourceActionList

	/// <summary>
	/// Supports the ProductModelProductDescriptionCultureDataSourceDesigner class.
	/// </summary>
	internal class ProductModelProductDescriptionCultureDataSourceActionList : DesignerActionList
	{
		private ProductModelProductDescriptionCultureDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductModelProductDescriptionCultureDataSourceActionList(ProductModelProductDescriptionCultureDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductModelProductDescriptionCultureSelectMethod SelectMethod
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

	#endregion ProductModelProductDescriptionCultureDataSourceActionList
	
	#endregion ProductModelProductDescriptionCultureDataSourceDesigner
	
	#region ProductModelProductDescriptionCultureSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductModelProductDescriptionCultureDataSource.SelectMethod property.
	/// </summary>
	public enum ProductModelProductDescriptionCultureSelectMethod
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
		/// Represents the GetByProductModelIdProductDescriptionIdCultureId method.
		/// </summary>
		GetByProductModelIdProductDescriptionIdCultureId,
		/// <summary>
		/// Represents the GetByCultureId method.
		/// </summary>
		GetByCultureId,
		/// <summary>
		/// Represents the GetByProductDescriptionId method.
		/// </summary>
		GetByProductDescriptionId,
		/// <summary>
		/// Represents the GetByProductModelId method.
		/// </summary>
		GetByProductModelId
	}
	
	#endregion ProductModelProductDescriptionCultureSelectMethod

	#region ProductModelProductDescriptionCultureFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelProductDescriptionCulture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelProductDescriptionCultureFilter : SqlFilter<ProductModelProductDescriptionCultureColumn>
	{
	}
	
	#endregion ProductModelProductDescriptionCultureFilter

	#region ProductModelProductDescriptionCultureExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelProductDescriptionCulture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelProductDescriptionCultureExpressionBuilder : SqlExpressionBuilder<ProductModelProductDescriptionCultureColumn>
	{
	}
	
	#endregion ProductModelProductDescriptionCultureExpressionBuilder	

	#region ProductModelProductDescriptionCultureProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductModelProductDescriptionCultureChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelProductDescriptionCulture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelProductDescriptionCultureProperty : ChildEntityProperty<ProductModelProductDescriptionCultureChildEntityTypes>
	{
	}
	
	#endregion ProductModelProductDescriptionCultureProperty
}

