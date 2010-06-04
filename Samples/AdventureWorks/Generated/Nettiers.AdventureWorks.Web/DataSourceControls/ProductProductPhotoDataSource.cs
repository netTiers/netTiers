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
	/// Represents the DataRepository.ProductProductPhotoProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductProductPhotoDataSourceDesigner))]
	public class ProductProductPhotoDataSource : ProviderDataSource<ProductProductPhoto, ProductProductPhotoKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoDataSource class.
		/// </summary>
		public ProductProductPhotoDataSource() : base(new ProductProductPhotoService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductProductPhotoDataSourceView used by the ProductProductPhotoDataSource.
		/// </summary>
		protected ProductProductPhotoDataSourceView ProductProductPhotoView
		{
			get { return ( View as ProductProductPhotoDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductProductPhotoDataSource control invokes to retrieve data.
		/// </summary>
		public ProductProductPhotoSelectMethod SelectMethod
		{
			get
			{
				ProductProductPhotoSelectMethod selectMethod = ProductProductPhotoSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductProductPhotoSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductProductPhotoDataSourceView class that is to be
		/// used by the ProductProductPhotoDataSource.
		/// </summary>
		/// <returns>An instance of the ProductProductPhotoDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductProductPhoto, ProductProductPhotoKey> GetNewDataSourceView()
		{
			return new ProductProductPhotoDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductProductPhotoDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductProductPhotoDataSourceView : ProviderDataSourceView<ProductProductPhoto, ProductProductPhotoKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductProductPhotoDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductProductPhotoDataSourceView(ProductProductPhotoDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductProductPhotoDataSource ProductProductPhotoOwner
		{
			get { return Owner as ProductProductPhotoDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductProductPhotoSelectMethod SelectMethod
		{
			get { return ProductProductPhotoOwner.SelectMethod; }
			set { ProductProductPhotoOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductProductPhotoService ProductProductPhotoProvider
		{
			get { return Provider as ProductProductPhotoService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductProductPhoto> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductProductPhoto> results = null;
			ProductProductPhoto item;
			count = 0;
			
			System.Int32 _productId;
			System.Int32 _productPhotoId;

			switch ( SelectMethod )
			{
				case ProductProductPhotoSelectMethod.Get:
					ProductProductPhotoKey entityKey  = new ProductProductPhotoKey();
					entityKey.Load(values);
					item = ProductProductPhotoProvider.Get(entityKey);
					results = new TList<ProductProductPhoto>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductProductPhotoSelectMethod.GetAll:
                    results = ProductProductPhotoProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductProductPhotoSelectMethod.GetPaged:
					results = ProductProductPhotoProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductProductPhotoSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductProductPhotoProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductProductPhotoProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductProductPhotoSelectMethod.GetByProductIdProductPhotoId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_productPhotoId = ( values["ProductPhotoId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductPhotoId"], typeof(System.Int32)) : (int)0;
					item = ProductProductPhotoProvider.GetByProductIdProductPhotoId(_productId, _productPhotoId);
					results = new TList<ProductProductPhoto>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProductProductPhotoSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductProductPhotoProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductProductPhotoSelectMethod.GetByProductPhotoId:
					_productPhotoId = ( values["ProductPhotoId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductPhotoId"], typeof(System.Int32)) : (int)0;
					results = ProductProductPhotoProvider.GetByProductPhotoId(_productPhotoId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductProductPhotoSelectMethod.Get || SelectMethod == ProductProductPhotoSelectMethod.GetByProductIdProductPhotoId )
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
				ProductProductPhoto entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductProductPhotoProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductProductPhoto> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductProductPhotoProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductProductPhotoDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductProductPhotoDataSource class.
	/// </summary>
	public class ProductProductPhotoDataSourceDesigner : ProviderDataSourceDesigner<ProductProductPhoto, ProductProductPhotoKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoDataSourceDesigner class.
		/// </summary>
		public ProductProductPhotoDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductProductPhotoSelectMethod SelectMethod
		{
			get { return ((ProductProductPhotoDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductProductPhotoDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductProductPhotoDataSourceActionList

	/// <summary>
	/// Supports the ProductProductPhotoDataSourceDesigner class.
	/// </summary>
	internal class ProductProductPhotoDataSourceActionList : DesignerActionList
	{
		private ProductProductPhotoDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductProductPhotoDataSourceActionList(ProductProductPhotoDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductProductPhotoSelectMethod SelectMethod
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

	#endregion ProductProductPhotoDataSourceActionList
	
	#endregion ProductProductPhotoDataSourceDesigner
	
	#region ProductProductPhotoSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductProductPhotoDataSource.SelectMethod property.
	/// </summary>
	public enum ProductProductPhotoSelectMethod
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
		/// Represents the GetByProductIdProductPhotoId method.
		/// </summary>
		GetByProductIdProductPhotoId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId,
		/// <summary>
		/// Represents the GetByProductPhotoId method.
		/// </summary>
		GetByProductPhotoId
	}
	
	#endregion ProductProductPhotoSelectMethod

	#region ProductProductPhotoFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductProductPhotoFilter : SqlFilter<ProductProductPhotoColumn>
	{
	}
	
	#endregion ProductProductPhotoFilter

	#region ProductProductPhotoExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductProductPhotoExpressionBuilder : SqlExpressionBuilder<ProductProductPhotoColumn>
	{
	}
	
	#endregion ProductProductPhotoExpressionBuilder	

	#region ProductProductPhotoProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductProductPhotoChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductProductPhotoProperty : ChildEntityProperty<ProductProductPhotoChildEntityTypes>
	{
	}
	
	#endregion ProductProductPhotoProperty
}

