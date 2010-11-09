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
	/// Represents the DataRepository.SpecialOfferProductProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SpecialOfferProductDataSourceDesigner))]
	public class SpecialOfferProductDataSource : ProviderDataSource<SpecialOfferProduct, SpecialOfferProductKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductDataSource class.
		/// </summary>
		public SpecialOfferProductDataSource() : base(new SpecialOfferProductService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SpecialOfferProductDataSourceView used by the SpecialOfferProductDataSource.
		/// </summary>
		protected SpecialOfferProductDataSourceView SpecialOfferProductView
		{
			get { return ( View as SpecialOfferProductDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SpecialOfferProductDataSource control invokes to retrieve data.
		/// </summary>
		public SpecialOfferProductSelectMethod SelectMethod
		{
			get
			{
				SpecialOfferProductSelectMethod selectMethod = SpecialOfferProductSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SpecialOfferProductSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SpecialOfferProductDataSourceView class that is to be
		/// used by the SpecialOfferProductDataSource.
		/// </summary>
		/// <returns>An instance of the SpecialOfferProductDataSourceView class.</returns>
		protected override BaseDataSourceView<SpecialOfferProduct, SpecialOfferProductKey> GetNewDataSourceView()
		{
			return new SpecialOfferProductDataSourceView(this, DefaultViewName);
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
	/// Supports the SpecialOfferProductDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SpecialOfferProductDataSourceView : ProviderDataSourceView<SpecialOfferProduct, SpecialOfferProductKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SpecialOfferProductDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SpecialOfferProductDataSourceView(SpecialOfferProductDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SpecialOfferProductDataSource SpecialOfferProductOwner
		{
			get { return Owner as SpecialOfferProductDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SpecialOfferProductSelectMethod SelectMethod
		{
			get { return SpecialOfferProductOwner.SelectMethod; }
			set { SpecialOfferProductOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SpecialOfferProductService SpecialOfferProductProvider
		{
			get { return Provider as SpecialOfferProductService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SpecialOfferProduct> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SpecialOfferProduct> results = null;
			SpecialOfferProduct item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _productId;
			System.Int32 _specialOfferId;

			switch ( SelectMethod )
			{
				case SpecialOfferProductSelectMethod.Get:
					SpecialOfferProductKey entityKey  = new SpecialOfferProductKey();
					entityKey.Load(values);
					item = SpecialOfferProductProvider.Get(entityKey);
					results = new TList<SpecialOfferProduct>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SpecialOfferProductSelectMethod.GetAll:
                    results = SpecialOfferProductProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SpecialOfferProductSelectMethod.GetPaged:
					results = SpecialOfferProductProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SpecialOfferProductSelectMethod.Find:
					if ( FilterParameters != null )
						results = SpecialOfferProductProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SpecialOfferProductProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SpecialOfferProductSelectMethod.GetBySpecialOfferIdProductId:
					_specialOfferId = ( values["SpecialOfferId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SpecialOfferId"], typeof(System.Int32)) : (int)0;
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					item = SpecialOfferProductProvider.GetBySpecialOfferIdProductId(_specialOfferId, _productId);
					results = new TList<SpecialOfferProduct>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SpecialOfferProductSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = SpecialOfferProductProvider.GetByRowguid(_rowguid);
					results = new TList<SpecialOfferProduct>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SpecialOfferProductSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = SpecialOfferProductProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case SpecialOfferProductSelectMethod.GetBySpecialOfferId:
					_specialOfferId = ( values["SpecialOfferId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SpecialOfferId"], typeof(System.Int32)) : (int)0;
					results = SpecialOfferProductProvider.GetBySpecialOfferId(_specialOfferId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SpecialOfferProductSelectMethod.Get || SelectMethod == SpecialOfferProductSelectMethod.GetBySpecialOfferIdProductId )
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
				SpecialOfferProduct entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SpecialOfferProductProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SpecialOfferProduct> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SpecialOfferProductProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SpecialOfferProductDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SpecialOfferProductDataSource class.
	/// </summary>
	public class SpecialOfferProductDataSourceDesigner : ProviderDataSourceDesigner<SpecialOfferProduct, SpecialOfferProductKey>
	{
		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductDataSourceDesigner class.
		/// </summary>
		public SpecialOfferProductDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SpecialOfferProductSelectMethod SelectMethod
		{
			get { return ((SpecialOfferProductDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SpecialOfferProductDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SpecialOfferProductDataSourceActionList

	/// <summary>
	/// Supports the SpecialOfferProductDataSourceDesigner class.
	/// </summary>
	internal class SpecialOfferProductDataSourceActionList : DesignerActionList
	{
		private SpecialOfferProductDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SpecialOfferProductDataSourceActionList(SpecialOfferProductDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SpecialOfferProductSelectMethod SelectMethod
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

	#endregion SpecialOfferProductDataSourceActionList
	
	#endregion SpecialOfferProductDataSourceDesigner
	
	#region SpecialOfferProductSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SpecialOfferProductDataSource.SelectMethod property.
	/// </summary>
	public enum SpecialOfferProductSelectMethod
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
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId,
		/// <summary>
		/// Represents the GetBySpecialOfferIdProductId method.
		/// </summary>
		GetBySpecialOfferIdProductId,
		/// <summary>
		/// Represents the GetBySpecialOfferId method.
		/// </summary>
		GetBySpecialOfferId
	}
	
	#endregion SpecialOfferProductSelectMethod

	#region SpecialOfferProductFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOfferProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferProductFilter : SqlFilter<SpecialOfferProductColumn>
	{
	}
	
	#endregion SpecialOfferProductFilter

	#region SpecialOfferProductExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOfferProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferProductExpressionBuilder : SqlExpressionBuilder<SpecialOfferProductColumn>
	{
	}
	
	#endregion SpecialOfferProductExpressionBuilder	

	#region SpecialOfferProductProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SpecialOfferProductChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOfferProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferProductProperty : ChildEntityProperty<SpecialOfferProductChildEntityTypes>
	{
	}
	
	#endregion SpecialOfferProductProperty
}

