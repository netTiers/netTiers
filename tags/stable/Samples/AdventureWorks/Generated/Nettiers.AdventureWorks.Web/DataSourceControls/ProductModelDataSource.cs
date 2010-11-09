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
	/// Represents the DataRepository.ProductModelProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductModelDataSourceDesigner))]
	public class ProductModelDataSource : ProviderDataSource<ProductModel, ProductModelKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelDataSource class.
		/// </summary>
		public ProductModelDataSource() : base(new ProductModelService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductModelDataSourceView used by the ProductModelDataSource.
		/// </summary>
		protected ProductModelDataSourceView ProductModelView
		{
			get { return ( View as ProductModelDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductModelDataSource control invokes to retrieve data.
		/// </summary>
		public ProductModelSelectMethod SelectMethod
		{
			get
			{
				ProductModelSelectMethod selectMethod = ProductModelSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductModelSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductModelDataSourceView class that is to be
		/// used by the ProductModelDataSource.
		/// </summary>
		/// <returns>An instance of the ProductModelDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductModel, ProductModelKey> GetNewDataSourceView()
		{
			return new ProductModelDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductModelDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductModelDataSourceView : ProviderDataSourceView<ProductModel, ProductModelKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductModelDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductModelDataSourceView(ProductModelDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductModelDataSource ProductModelOwner
		{
			get { return Owner as ProductModelDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductModelSelectMethod SelectMethod
		{
			get { return ProductModelOwner.SelectMethod; }
			set { ProductModelOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductModelService ProductModelProvider
		{
			get { return Provider as ProductModelService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductModel> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductModel> results = null;
			ProductModel item;
			count = 0;
			
			System.String _name;
			System.Guid _rowguid;
			System.Int32 _productModelId;
			string _catalogDescription_nullable;
			string _instructions_nullable;
			System.Int32 _illustrationId;
			System.String _cultureId;
			System.Int32 _productDescriptionId;

			switch ( SelectMethod )
			{
				case ProductModelSelectMethod.Get:
					ProductModelKey entityKey  = new ProductModelKey();
					entityKey.Load(values);
					item = ProductModelProvider.Get(entityKey);
					results = new TList<ProductModel>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductModelSelectMethod.GetAll:
                    results = ProductModelProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductModelSelectMethod.GetPaged:
					results = ProductModelProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductModelSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductModelProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductModelProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductModelSelectMethod.GetByProductModelId:
					_productModelId = ( values["ProductModelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32)) : (int)0;
					item = ProductModelProvider.GetByProductModelId(_productModelId);
					results = new TList<ProductModel>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductModelSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ProductModelProvider.GetByName(_name);
					results = new TList<ProductModel>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductModelSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = ProductModelProvider.GetByRowguid(_rowguid);
					results = new TList<ProductModel>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductModelSelectMethod.GetByCatalogDescription:
					_catalogDescription_nullable = (string) EntityUtil.ChangeType(values["CatalogDescription"], typeof(string));
					results = ProductModelProvider.GetByCatalogDescription(_catalogDescription_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProductModelSelectMethod.GetByInstructions:
					_instructions_nullable = (string) EntityUtil.ChangeType(values["Instructions"], typeof(string));
					results = ProductModelProvider.GetByInstructions(_instructions_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				case ProductModelSelectMethod.GetByIllustrationIdFromProductModelIllustration:
					_illustrationId = ( values["IllustrationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IllustrationId"], typeof(System.Int32)) : (int)0;
					results = ProductModelProvider.GetByIllustrationIdFromProductModelIllustration(_illustrationId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductModelSelectMethod.GetByCultureIdFromProductModelProductDescriptionCulture:
					_cultureId = ( values["CultureId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CultureId"], typeof(System.String)) : string.Empty;
					results = ProductModelProvider.GetByCultureIdFromProductModelProductDescriptionCulture(_cultureId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductModelSelectMethod.GetByProductDescriptionIdFromProductModelProductDescriptionCulture:
					_productDescriptionId = ( values["ProductDescriptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductDescriptionId"], typeof(System.Int32)) : (int)0;
					results = ProductModelProvider.GetByProductDescriptionIdFromProductModelProductDescriptionCulture(_productDescriptionId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductModelSelectMethod.Get || SelectMethod == ProductModelSelectMethod.GetByProductModelId )
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
				ProductModel entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductModelProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductModel> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductModelProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductModelDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductModelDataSource class.
	/// </summary>
	public class ProductModelDataSourceDesigner : ProviderDataSourceDesigner<ProductModel, ProductModelKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductModelDataSourceDesigner class.
		/// </summary>
		public ProductModelDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductModelSelectMethod SelectMethod
		{
			get { return ((ProductModelDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductModelDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductModelDataSourceActionList

	/// <summary>
	/// Supports the ProductModelDataSourceDesigner class.
	/// </summary>
	internal class ProductModelDataSourceActionList : DesignerActionList
	{
		private ProductModelDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductModelDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductModelDataSourceActionList(ProductModelDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductModelSelectMethod SelectMethod
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

	#endregion ProductModelDataSourceActionList
	
	#endregion ProductModelDataSourceDesigner
	
	#region ProductModelSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductModelDataSource.SelectMethod property.
	/// </summary>
	public enum ProductModelSelectMethod
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
		/// Represents the GetByName method.
		/// </summary>
		GetByName,
		/// <summary>
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByProductModelId method.
		/// </summary>
		GetByProductModelId,
		/// <summary>
		/// Represents the GetByCatalogDescription method.
		/// </summary>
		GetByCatalogDescription,
		/// <summary>
		/// Represents the GetByInstructions method.
		/// </summary>
		GetByInstructions,
		/// <summary>
		/// Represents the GetByIllustrationIdFromProductModelIllustration method.
		/// </summary>
		GetByIllustrationIdFromProductModelIllustration,
		/// <summary>
		/// Represents the GetByCultureIdFromProductModelProductDescriptionCulture method.
		/// </summary>
		GetByCultureIdFromProductModelProductDescriptionCulture,
		/// <summary>
		/// Represents the GetByProductDescriptionIdFromProductModelProductDescriptionCulture method.
		/// </summary>
		GetByProductDescriptionIdFromProductModelProductDescriptionCulture
	}
	
	#endregion ProductModelSelectMethod

	#region ProductModelFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelFilter : SqlFilter<ProductModelColumn>
	{
	}
	
	#endregion ProductModelFilter

	#region ProductModelExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelExpressionBuilder : SqlExpressionBuilder<ProductModelColumn>
	{
	}
	
	#endregion ProductModelExpressionBuilder	

	#region ProductModelProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductModelChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelProperty : ChildEntityProperty<ProductModelChildEntityTypes>
	{
	}
	
	#endregion ProductModelProperty
}

