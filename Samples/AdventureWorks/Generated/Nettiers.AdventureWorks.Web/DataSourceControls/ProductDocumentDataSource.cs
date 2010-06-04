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
	/// Represents the DataRepository.ProductDocumentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductDocumentDataSourceDesigner))]
	public class ProductDocumentDataSource : ProviderDataSource<ProductDocument, ProductDocumentKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDocumentDataSource class.
		/// </summary>
		public ProductDocumentDataSource() : base(new ProductDocumentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductDocumentDataSourceView used by the ProductDocumentDataSource.
		/// </summary>
		protected ProductDocumentDataSourceView ProductDocumentView
		{
			get { return ( View as ProductDocumentDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductDocumentDataSource control invokes to retrieve data.
		/// </summary>
		public ProductDocumentSelectMethod SelectMethod
		{
			get
			{
				ProductDocumentSelectMethod selectMethod = ProductDocumentSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductDocumentSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductDocumentDataSourceView class that is to be
		/// used by the ProductDocumentDataSource.
		/// </summary>
		/// <returns>An instance of the ProductDocumentDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductDocument, ProductDocumentKey> GetNewDataSourceView()
		{
			return new ProductDocumentDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductDocumentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductDocumentDataSourceView : ProviderDataSourceView<ProductDocument, ProductDocumentKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDocumentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductDocumentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductDocumentDataSourceView(ProductDocumentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductDocumentDataSource ProductDocumentOwner
		{
			get { return Owner as ProductDocumentDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductDocumentSelectMethod SelectMethod
		{
			get { return ProductDocumentOwner.SelectMethod; }
			set { ProductDocumentOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductDocumentService ProductDocumentProvider
		{
			get { return Provider as ProductDocumentService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductDocument> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductDocument> results = null;
			ProductDocument item;
			count = 0;
			
			System.Int32 _productId;
			System.Int32 _documentId;

			switch ( SelectMethod )
			{
				case ProductDocumentSelectMethod.Get:
					ProductDocumentKey entityKey  = new ProductDocumentKey();
					entityKey.Load(values);
					item = ProductDocumentProvider.Get(entityKey);
					results = new TList<ProductDocument>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductDocumentSelectMethod.GetAll:
                    results = ProductDocumentProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductDocumentSelectMethod.GetPaged:
					results = ProductDocumentProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductDocumentSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductDocumentProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductDocumentProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductDocumentSelectMethod.GetByProductIdDocumentId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_documentId = ( values["DocumentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DocumentId"], typeof(System.Int32)) : (int)0;
					item = ProductDocumentProvider.GetByProductIdDocumentId(_productId, _documentId);
					results = new TList<ProductDocument>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProductDocumentSelectMethod.GetByDocumentId:
					_documentId = ( values["DocumentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DocumentId"], typeof(System.Int32)) : (int)0;
					results = ProductDocumentProvider.GetByDocumentId(_documentId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductDocumentSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductDocumentProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductDocumentSelectMethod.Get || SelectMethod == ProductDocumentSelectMethod.GetByProductIdDocumentId )
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
				ProductDocument entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductDocumentProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductDocument> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductDocumentProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductDocumentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductDocumentDataSource class.
	/// </summary>
	public class ProductDocumentDataSourceDesigner : ProviderDataSourceDesigner<ProductDocument, ProductDocumentKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductDocumentDataSourceDesigner class.
		/// </summary>
		public ProductDocumentDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductDocumentSelectMethod SelectMethod
		{
			get { return ((ProductDocumentDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductDocumentDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductDocumentDataSourceActionList

	/// <summary>
	/// Supports the ProductDocumentDataSourceDesigner class.
	/// </summary>
	internal class ProductDocumentDataSourceActionList : DesignerActionList
	{
		private ProductDocumentDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductDocumentDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductDocumentDataSourceActionList(ProductDocumentDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductDocumentSelectMethod SelectMethod
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

	#endregion ProductDocumentDataSourceActionList
	
	#endregion ProductDocumentDataSourceDesigner
	
	#region ProductDocumentSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductDocumentDataSource.SelectMethod property.
	/// </summary>
	public enum ProductDocumentSelectMethod
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
		/// Represents the GetByProductIdDocumentId method.
		/// </summary>
		GetByProductIdDocumentId,
		/// <summary>
		/// Represents the GetByDocumentId method.
		/// </summary>
		GetByDocumentId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion ProductDocumentSelectMethod

	#region ProductDocumentFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDocumentFilter : SqlFilter<ProductDocumentColumn>
	{
	}
	
	#endregion ProductDocumentFilter

	#region ProductDocumentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDocumentExpressionBuilder : SqlExpressionBuilder<ProductDocumentColumn>
	{
	}
	
	#endregion ProductDocumentExpressionBuilder	

	#region ProductDocumentProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductDocumentChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDocumentProperty : ChildEntityProperty<ProductDocumentChildEntityTypes>
	{
	}
	
	#endregion ProductDocumentProperty
}

