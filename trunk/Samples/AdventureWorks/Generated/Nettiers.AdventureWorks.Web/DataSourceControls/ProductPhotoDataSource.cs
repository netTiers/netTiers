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
	/// Represents the DataRepository.ProductPhotoProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductPhotoDataSourceDesigner))]
	public class ProductPhotoDataSource : ProviderDataSource<ProductPhoto, ProductPhotoKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductPhotoDataSource class.
		/// </summary>
		public ProductPhotoDataSource() : base(new ProductPhotoService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductPhotoDataSourceView used by the ProductPhotoDataSource.
		/// </summary>
		protected ProductPhotoDataSourceView ProductPhotoView
		{
			get { return ( View as ProductPhotoDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductPhotoDataSource control invokes to retrieve data.
		/// </summary>
		public ProductPhotoSelectMethod SelectMethod
		{
			get
			{
				ProductPhotoSelectMethod selectMethod = ProductPhotoSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductPhotoSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductPhotoDataSourceView class that is to be
		/// used by the ProductPhotoDataSource.
		/// </summary>
		/// <returns>An instance of the ProductPhotoDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductPhoto, ProductPhotoKey> GetNewDataSourceView()
		{
			return new ProductPhotoDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductPhotoDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductPhotoDataSourceView : ProviderDataSourceView<ProductPhoto, ProductPhotoKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductPhotoDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductPhotoDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductPhotoDataSourceView(ProductPhotoDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductPhotoDataSource ProductPhotoOwner
		{
			get { return Owner as ProductPhotoDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductPhotoSelectMethod SelectMethod
		{
			get { return ProductPhotoOwner.SelectMethod; }
			set { ProductPhotoOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductPhotoService ProductPhotoProvider
		{
			get { return Provider as ProductPhotoService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductPhoto> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductPhoto> results = null;
			ProductPhoto item;
			count = 0;
			
			System.Int32 _productPhotoId;
			System.Int32 _productId;

			switch ( SelectMethod )
			{
				case ProductPhotoSelectMethod.Get:
					ProductPhotoKey entityKey  = new ProductPhotoKey();
					entityKey.Load(values);
					item = ProductPhotoProvider.Get(entityKey);
					results = new TList<ProductPhoto>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductPhotoSelectMethod.GetAll:
                    results = ProductPhotoProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductPhotoSelectMethod.GetPaged:
					results = ProductPhotoProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductPhotoSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductPhotoProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductPhotoProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductPhotoSelectMethod.GetByProductPhotoId:
					_productPhotoId = ( values["ProductPhotoId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductPhotoId"], typeof(System.Int32)) : (int)0;
					item = ProductPhotoProvider.GetByProductPhotoId(_productPhotoId);
					results = new TList<ProductPhoto>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case ProductPhotoSelectMethod.GetByProductIdFromProductProductPhoto:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductPhotoProvider.GetByProductIdFromProductProductPhoto(_productId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == ProductPhotoSelectMethod.Get || SelectMethod == ProductPhotoSelectMethod.GetByProductPhotoId )
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
				ProductPhoto entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductPhotoProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductPhoto> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductPhotoProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductPhotoDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductPhotoDataSource class.
	/// </summary>
	public class ProductPhotoDataSourceDesigner : ProviderDataSourceDesigner<ProductPhoto, ProductPhotoKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductPhotoDataSourceDesigner class.
		/// </summary>
		public ProductPhotoDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductPhotoSelectMethod SelectMethod
		{
			get { return ((ProductPhotoDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductPhotoDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductPhotoDataSourceActionList

	/// <summary>
	/// Supports the ProductPhotoDataSourceDesigner class.
	/// </summary>
	internal class ProductPhotoDataSourceActionList : DesignerActionList
	{
		private ProductPhotoDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductPhotoDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductPhotoDataSourceActionList(ProductPhotoDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductPhotoSelectMethod SelectMethod
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

	#endregion ProductPhotoDataSourceActionList
	
	#endregion ProductPhotoDataSourceDesigner
	
	#region ProductPhotoSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductPhotoDataSource.SelectMethod property.
	/// </summary>
	public enum ProductPhotoSelectMethod
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
		/// Represents the GetByProductPhotoId method.
		/// </summary>
		GetByProductPhotoId,
		/// <summary>
		/// Represents the GetByProductIdFromProductProductPhoto method.
		/// </summary>
		GetByProductIdFromProductProductPhoto
	}
	
	#endregion ProductPhotoSelectMethod

	#region ProductPhotoFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductPhotoFilter : SqlFilter<ProductPhotoColumn>
	{
	}
	
	#endregion ProductPhotoFilter

	#region ProductPhotoExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductPhotoExpressionBuilder : SqlExpressionBuilder<ProductPhotoColumn>
	{
	}
	
	#endregion ProductPhotoExpressionBuilder	

	#region ProductPhotoProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductPhotoChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductPhotoProperty : ChildEntityProperty<ProductPhotoChildEntityTypes>
	{
	}
	
	#endregion ProductPhotoProperty
}

