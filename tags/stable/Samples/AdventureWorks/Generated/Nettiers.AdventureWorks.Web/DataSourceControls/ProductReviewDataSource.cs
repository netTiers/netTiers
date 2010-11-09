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
	/// Represents the DataRepository.ProductReviewProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductReviewDataSourceDesigner))]
	public class ProductReviewDataSource : ProviderDataSource<ProductReview, ProductReviewKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductReviewDataSource class.
		/// </summary>
		public ProductReviewDataSource() : base(new ProductReviewService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductReviewDataSourceView used by the ProductReviewDataSource.
		/// </summary>
		protected ProductReviewDataSourceView ProductReviewView
		{
			get { return ( View as ProductReviewDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductReviewDataSource control invokes to retrieve data.
		/// </summary>
		public ProductReviewSelectMethod SelectMethod
		{
			get
			{
				ProductReviewSelectMethod selectMethod = ProductReviewSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductReviewSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductReviewDataSourceView class that is to be
		/// used by the ProductReviewDataSource.
		/// </summary>
		/// <returns>An instance of the ProductReviewDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductReview, ProductReviewKey> GetNewDataSourceView()
		{
			return new ProductReviewDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductReviewDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductReviewDataSourceView : ProviderDataSourceView<ProductReview, ProductReviewKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductReviewDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductReviewDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductReviewDataSourceView(ProductReviewDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductReviewDataSource ProductReviewOwner
		{
			get { return Owner as ProductReviewDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductReviewSelectMethod SelectMethod
		{
			get { return ProductReviewOwner.SelectMethod; }
			set { ProductReviewOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductReviewService ProductReviewProvider
		{
			get { return Provider as ProductReviewService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductReview> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductReview> results = null;
			ProductReview item;
			count = 0;
			
			System.Int32 _productId;
			System.String _reviewerName;
			System.Int32 _productReviewId;

			switch ( SelectMethod )
			{
				case ProductReviewSelectMethod.Get:
					ProductReviewKey entityKey  = new ProductReviewKey();
					entityKey.Load(values);
					item = ProductReviewProvider.Get(entityKey);
					results = new TList<ProductReview>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductReviewSelectMethod.GetAll:
                    results = ProductReviewProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductReviewSelectMethod.GetPaged:
					results = ProductReviewProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductReviewSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductReviewProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductReviewProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductReviewSelectMethod.GetByProductReviewId:
					_productReviewId = ( values["ProductReviewId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductReviewId"], typeof(System.Int32)) : (int)0;
					item = ProductReviewProvider.GetByProductReviewId(_productReviewId);
					results = new TList<ProductReview>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductReviewSelectMethod.GetByProductIdReviewerName:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_reviewerName = ( values["ReviewerName"] != null ) ? (System.String) EntityUtil.ChangeType(values["ReviewerName"], typeof(System.String)) : string.Empty;
					results = ProductReviewProvider.GetByProductIdReviewerName(_productId, _reviewerName, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case ProductReviewSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductReviewProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductReviewSelectMethod.Get || SelectMethod == ProductReviewSelectMethod.GetByProductReviewId )
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
				ProductReview entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductReviewProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductReview> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductReviewProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductReviewDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductReviewDataSource class.
	/// </summary>
	public class ProductReviewDataSourceDesigner : ProviderDataSourceDesigner<ProductReview, ProductReviewKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductReviewDataSourceDesigner class.
		/// </summary>
		public ProductReviewDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductReviewSelectMethod SelectMethod
		{
			get { return ((ProductReviewDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductReviewDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductReviewDataSourceActionList

	/// <summary>
	/// Supports the ProductReviewDataSourceDesigner class.
	/// </summary>
	internal class ProductReviewDataSourceActionList : DesignerActionList
	{
		private ProductReviewDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductReviewDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductReviewDataSourceActionList(ProductReviewDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductReviewSelectMethod SelectMethod
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

	#endregion ProductReviewDataSourceActionList
	
	#endregion ProductReviewDataSourceDesigner
	
	#region ProductReviewSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductReviewDataSource.SelectMethod property.
	/// </summary>
	public enum ProductReviewSelectMethod
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
		/// Represents the GetByProductIdReviewerName method.
		/// </summary>
		GetByProductIdReviewerName,
		/// <summary>
		/// Represents the GetByProductReviewId method.
		/// </summary>
		GetByProductReviewId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion ProductReviewSelectMethod

	#region ProductReviewFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductReviewFilter : SqlFilter<ProductReviewColumn>
	{
	}
	
	#endregion ProductReviewFilter

	#region ProductReviewExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductReviewExpressionBuilder : SqlExpressionBuilder<ProductReviewColumn>
	{
	}
	
	#endregion ProductReviewExpressionBuilder	

	#region ProductReviewProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductReviewChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductReviewProperty : ChildEntityProperty<ProductReviewChildEntityTypes>
	{
	}
	
	#endregion ProductReviewProperty
}

