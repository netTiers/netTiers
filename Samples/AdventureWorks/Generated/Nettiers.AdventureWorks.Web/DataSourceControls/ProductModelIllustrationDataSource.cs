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
	/// Represents the DataRepository.ProductModelIllustrationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductModelIllustrationDataSourceDesigner))]
	public class ProductModelIllustrationDataSource : ProviderDataSource<ProductModelIllustration, ProductModelIllustrationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationDataSource class.
		/// </summary>
		public ProductModelIllustrationDataSource() : base(new ProductModelIllustrationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductModelIllustrationDataSourceView used by the ProductModelIllustrationDataSource.
		/// </summary>
		protected ProductModelIllustrationDataSourceView ProductModelIllustrationView
		{
			get { return ( View as ProductModelIllustrationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductModelIllustrationDataSource control invokes to retrieve data.
		/// </summary>
		public ProductModelIllustrationSelectMethod SelectMethod
		{
			get
			{
				ProductModelIllustrationSelectMethod selectMethod = ProductModelIllustrationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductModelIllustrationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductModelIllustrationDataSourceView class that is to be
		/// used by the ProductModelIllustrationDataSource.
		/// </summary>
		/// <returns>An instance of the ProductModelIllustrationDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductModelIllustration, ProductModelIllustrationKey> GetNewDataSourceView()
		{
			return new ProductModelIllustrationDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductModelIllustrationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductModelIllustrationDataSourceView : ProviderDataSourceView<ProductModelIllustration, ProductModelIllustrationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductModelIllustrationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductModelIllustrationDataSourceView(ProductModelIllustrationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductModelIllustrationDataSource ProductModelIllustrationOwner
		{
			get { return Owner as ProductModelIllustrationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductModelIllustrationSelectMethod SelectMethod
		{
			get { return ProductModelIllustrationOwner.SelectMethod; }
			set { ProductModelIllustrationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductModelIllustrationService ProductModelIllustrationProvider
		{
			get { return Provider as ProductModelIllustrationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductModelIllustration> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductModelIllustration> results = null;
			ProductModelIllustration item;
			count = 0;
			
			System.Int32 _productModelId;
			System.Int32 _illustrationId;

			switch ( SelectMethod )
			{
				case ProductModelIllustrationSelectMethod.Get:
					ProductModelIllustrationKey entityKey  = new ProductModelIllustrationKey();
					entityKey.Load(values);
					item = ProductModelIllustrationProvider.Get(entityKey);
					results = new TList<ProductModelIllustration>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductModelIllustrationSelectMethod.GetAll:
                    results = ProductModelIllustrationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductModelIllustrationSelectMethod.GetPaged:
					results = ProductModelIllustrationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductModelIllustrationSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductModelIllustrationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductModelIllustrationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductModelIllustrationSelectMethod.GetByProductModelIdIllustrationId:
					_productModelId = ( values["ProductModelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32)) : (int)0;
					_illustrationId = ( values["IllustrationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IllustrationId"], typeof(System.Int32)) : (int)0;
					item = ProductModelIllustrationProvider.GetByProductModelIdIllustrationId(_productModelId, _illustrationId);
					results = new TList<ProductModelIllustration>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProductModelIllustrationSelectMethod.GetByIllustrationId:
					_illustrationId = ( values["IllustrationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IllustrationId"], typeof(System.Int32)) : (int)0;
					results = ProductModelIllustrationProvider.GetByIllustrationId(_illustrationId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductModelIllustrationSelectMethod.GetByProductModelId:
					_productModelId = ( values["ProductModelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32)) : (int)0;
					results = ProductModelIllustrationProvider.GetByProductModelId(_productModelId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductModelIllustrationSelectMethod.Get || SelectMethod == ProductModelIllustrationSelectMethod.GetByProductModelIdIllustrationId )
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
				ProductModelIllustration entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductModelIllustrationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductModelIllustration> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductModelIllustrationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductModelIllustrationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductModelIllustrationDataSource class.
	/// </summary>
	public class ProductModelIllustrationDataSourceDesigner : ProviderDataSourceDesigner<ProductModelIllustration, ProductModelIllustrationKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationDataSourceDesigner class.
		/// </summary>
		public ProductModelIllustrationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductModelIllustrationSelectMethod SelectMethod
		{
			get { return ((ProductModelIllustrationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductModelIllustrationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductModelIllustrationDataSourceActionList

	/// <summary>
	/// Supports the ProductModelIllustrationDataSourceDesigner class.
	/// </summary>
	internal class ProductModelIllustrationDataSourceActionList : DesignerActionList
	{
		private ProductModelIllustrationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductModelIllustrationDataSourceActionList(ProductModelIllustrationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductModelIllustrationSelectMethod SelectMethod
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

	#endregion ProductModelIllustrationDataSourceActionList
	
	#endregion ProductModelIllustrationDataSourceDesigner
	
	#region ProductModelIllustrationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductModelIllustrationDataSource.SelectMethod property.
	/// </summary>
	public enum ProductModelIllustrationSelectMethod
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
		/// Represents the GetByProductModelIdIllustrationId method.
		/// </summary>
		GetByProductModelIdIllustrationId,
		/// <summary>
		/// Represents the GetByIllustrationId method.
		/// </summary>
		GetByIllustrationId,
		/// <summary>
		/// Represents the GetByProductModelId method.
		/// </summary>
		GetByProductModelId
	}
	
	#endregion ProductModelIllustrationSelectMethod

	#region ProductModelIllustrationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelIllustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelIllustrationFilter : SqlFilter<ProductModelIllustrationColumn>
	{
	}
	
	#endregion ProductModelIllustrationFilter

	#region ProductModelIllustrationExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelIllustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelIllustrationExpressionBuilder : SqlExpressionBuilder<ProductModelIllustrationColumn>
	{
	}
	
	#endregion ProductModelIllustrationExpressionBuilder	

	#region ProductModelIllustrationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductModelIllustrationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelIllustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelIllustrationProperty : ChildEntityProperty<ProductModelIllustrationChildEntityTypes>
	{
	}
	
	#endregion ProductModelIllustrationProperty
}

