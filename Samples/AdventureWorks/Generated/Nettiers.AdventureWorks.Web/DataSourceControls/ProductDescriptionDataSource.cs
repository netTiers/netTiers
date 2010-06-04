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
	/// Represents the DataRepository.ProductDescriptionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductDescriptionDataSourceDesigner))]
	public class ProductDescriptionDataSource : ProviderDataSource<ProductDescription, ProductDescriptionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionDataSource class.
		/// </summary>
		public ProductDescriptionDataSource() : base(new ProductDescriptionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductDescriptionDataSourceView used by the ProductDescriptionDataSource.
		/// </summary>
		protected ProductDescriptionDataSourceView ProductDescriptionView
		{
			get { return ( View as ProductDescriptionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductDescriptionDataSource control invokes to retrieve data.
		/// </summary>
		public ProductDescriptionSelectMethod SelectMethod
		{
			get
			{
				ProductDescriptionSelectMethod selectMethod = ProductDescriptionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductDescriptionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductDescriptionDataSourceView class that is to be
		/// used by the ProductDescriptionDataSource.
		/// </summary>
		/// <returns>An instance of the ProductDescriptionDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductDescription, ProductDescriptionKey> GetNewDataSourceView()
		{
			return new ProductDescriptionDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductDescriptionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductDescriptionDataSourceView : ProviderDataSourceView<ProductDescription, ProductDescriptionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductDescriptionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductDescriptionDataSourceView(ProductDescriptionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductDescriptionDataSource ProductDescriptionOwner
		{
			get { return Owner as ProductDescriptionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductDescriptionSelectMethod SelectMethod
		{
			get { return ProductDescriptionOwner.SelectMethod; }
			set { ProductDescriptionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductDescriptionService ProductDescriptionProvider
		{
			get { return Provider as ProductDescriptionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductDescription> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductDescription> results = null;
			ProductDescription item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _productDescriptionId;
			System.String _cultureId;
			System.Int32 _productModelId;

			switch ( SelectMethod )
			{
				case ProductDescriptionSelectMethod.Get:
					ProductDescriptionKey entityKey  = new ProductDescriptionKey();
					entityKey.Load(values);
					item = ProductDescriptionProvider.Get(entityKey);
					results = new TList<ProductDescription>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductDescriptionSelectMethod.GetAll:
                    results = ProductDescriptionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductDescriptionSelectMethod.GetPaged:
					results = ProductDescriptionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductDescriptionSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductDescriptionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductDescriptionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductDescriptionSelectMethod.GetByProductDescriptionId:
					_productDescriptionId = ( values["ProductDescriptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductDescriptionId"], typeof(System.Int32)) : (int)0;
					item = ProductDescriptionProvider.GetByProductDescriptionId(_productDescriptionId);
					results = new TList<ProductDescription>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductDescriptionSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = ProductDescriptionProvider.GetByRowguid(_rowguid);
					results = new TList<ProductDescription>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case ProductDescriptionSelectMethod.GetByCultureIdFromProductModelProductDescriptionCulture:
					_cultureId = ( values["CultureId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CultureId"], typeof(System.String)) : string.Empty;
					results = ProductDescriptionProvider.GetByCultureIdFromProductModelProductDescriptionCulture(_cultureId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductDescriptionSelectMethod.GetByProductModelIdFromProductModelProductDescriptionCulture:
					_productModelId = ( values["ProductModelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32)) : (int)0;
					results = ProductDescriptionProvider.GetByProductModelIdFromProductModelProductDescriptionCulture(_productModelId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductDescriptionSelectMethod.Get || SelectMethod == ProductDescriptionSelectMethod.GetByProductDescriptionId )
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
				ProductDescription entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductDescriptionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductDescription> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductDescriptionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductDescriptionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductDescriptionDataSource class.
	/// </summary>
	public class ProductDescriptionDataSourceDesigner : ProviderDataSourceDesigner<ProductDescription, ProductDescriptionKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductDescriptionDataSourceDesigner class.
		/// </summary>
		public ProductDescriptionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductDescriptionSelectMethod SelectMethod
		{
			get { return ((ProductDescriptionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductDescriptionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductDescriptionDataSourceActionList

	/// <summary>
	/// Supports the ProductDescriptionDataSourceDesigner class.
	/// </summary>
	internal class ProductDescriptionDataSourceActionList : DesignerActionList
	{
		private ProductDescriptionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductDescriptionDataSourceActionList(ProductDescriptionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductDescriptionSelectMethod SelectMethod
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

	#endregion ProductDescriptionDataSourceActionList
	
	#endregion ProductDescriptionDataSourceDesigner
	
	#region ProductDescriptionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductDescriptionDataSource.SelectMethod property.
	/// </summary>
	public enum ProductDescriptionSelectMethod
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
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByProductDescriptionId method.
		/// </summary>
		GetByProductDescriptionId,
		/// <summary>
		/// Represents the GetByCultureIdFromProductModelProductDescriptionCulture method.
		/// </summary>
		GetByCultureIdFromProductModelProductDescriptionCulture,
		/// <summary>
		/// Represents the GetByProductModelIdFromProductModelProductDescriptionCulture method.
		/// </summary>
		GetByProductModelIdFromProductModelProductDescriptionCulture
	}
	
	#endregion ProductDescriptionSelectMethod

	#region ProductDescriptionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDescriptionFilter : SqlFilter<ProductDescriptionColumn>
	{
	}
	
	#endregion ProductDescriptionFilter

	#region ProductDescriptionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDescriptionExpressionBuilder : SqlExpressionBuilder<ProductDescriptionColumn>
	{
	}
	
	#endregion ProductDescriptionExpressionBuilder	

	#region ProductDescriptionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductDescriptionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDescriptionProperty : ChildEntityProperty<ProductDescriptionChildEntityTypes>
	{
	}
	
	#endregion ProductDescriptionProperty
}

