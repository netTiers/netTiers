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
	/// Represents the DataRepository.PurchaseOrderDetailProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PurchaseOrderDetailDataSourceDesigner))]
	public class PurchaseOrderDetailDataSource : ProviderDataSource<PurchaseOrderDetail, PurchaseOrderDetailKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailDataSource class.
		/// </summary>
		public PurchaseOrderDetailDataSource() : base(new PurchaseOrderDetailService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PurchaseOrderDetailDataSourceView used by the PurchaseOrderDetailDataSource.
		/// </summary>
		protected PurchaseOrderDetailDataSourceView PurchaseOrderDetailView
		{
			get { return ( View as PurchaseOrderDetailDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PurchaseOrderDetailDataSource control invokes to retrieve data.
		/// </summary>
		public PurchaseOrderDetailSelectMethod SelectMethod
		{
			get
			{
				PurchaseOrderDetailSelectMethod selectMethod = PurchaseOrderDetailSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PurchaseOrderDetailSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PurchaseOrderDetailDataSourceView class that is to be
		/// used by the PurchaseOrderDetailDataSource.
		/// </summary>
		/// <returns>An instance of the PurchaseOrderDetailDataSourceView class.</returns>
		protected override BaseDataSourceView<PurchaseOrderDetail, PurchaseOrderDetailKey> GetNewDataSourceView()
		{
			return new PurchaseOrderDetailDataSourceView(this, DefaultViewName);
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
	/// Supports the PurchaseOrderDetailDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PurchaseOrderDetailDataSourceView : ProviderDataSourceView<PurchaseOrderDetail, PurchaseOrderDetailKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PurchaseOrderDetailDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PurchaseOrderDetailDataSourceView(PurchaseOrderDetailDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PurchaseOrderDetailDataSource PurchaseOrderDetailOwner
		{
			get { return Owner as PurchaseOrderDetailDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PurchaseOrderDetailSelectMethod SelectMethod
		{
			get { return PurchaseOrderDetailOwner.SelectMethod; }
			set { PurchaseOrderDetailOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PurchaseOrderDetailService PurchaseOrderDetailProvider
		{
			get { return Provider as PurchaseOrderDetailService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<PurchaseOrderDetail> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<PurchaseOrderDetail> results = null;
			PurchaseOrderDetail item;
			count = 0;
			
			System.Int32 _productId;
			System.Int32 _purchaseOrderId;
			System.Int32 _purchaseOrderDetailId;

			switch ( SelectMethod )
			{
				case PurchaseOrderDetailSelectMethod.Get:
					PurchaseOrderDetailKey entityKey  = new PurchaseOrderDetailKey();
					entityKey.Load(values);
					item = PurchaseOrderDetailProvider.Get(entityKey);
					results = new TList<PurchaseOrderDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PurchaseOrderDetailSelectMethod.GetAll:
                    results = PurchaseOrderDetailProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case PurchaseOrderDetailSelectMethod.GetPaged:
					results = PurchaseOrderDetailProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PurchaseOrderDetailSelectMethod.Find:
					if ( FilterParameters != null )
						results = PurchaseOrderDetailProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PurchaseOrderDetailProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PurchaseOrderDetailSelectMethod.GetByPurchaseOrderIdPurchaseOrderDetailId:
					_purchaseOrderId = ( values["PurchaseOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["PurchaseOrderId"], typeof(System.Int32)) : (int)0;
					_purchaseOrderDetailId = ( values["PurchaseOrderDetailId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["PurchaseOrderDetailId"], typeof(System.Int32)) : (int)0;
					item = PurchaseOrderDetailProvider.GetByPurchaseOrderIdPurchaseOrderDetailId(_purchaseOrderId, _purchaseOrderDetailId);
					results = new TList<PurchaseOrderDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case PurchaseOrderDetailSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = PurchaseOrderDetailProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case PurchaseOrderDetailSelectMethod.GetByPurchaseOrderId:
					_purchaseOrderId = ( values["PurchaseOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["PurchaseOrderId"], typeof(System.Int32)) : (int)0;
					results = PurchaseOrderDetailProvider.GetByPurchaseOrderId(_purchaseOrderId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == PurchaseOrderDetailSelectMethod.Get || SelectMethod == PurchaseOrderDetailSelectMethod.GetByPurchaseOrderIdPurchaseOrderDetailId )
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
				PurchaseOrderDetail entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					PurchaseOrderDetailProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<PurchaseOrderDetail> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			PurchaseOrderDetailProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PurchaseOrderDetailDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PurchaseOrderDetailDataSource class.
	/// </summary>
	public class PurchaseOrderDetailDataSourceDesigner : ProviderDataSourceDesigner<PurchaseOrderDetail, PurchaseOrderDetailKey>
	{
		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailDataSourceDesigner class.
		/// </summary>
		public PurchaseOrderDetailDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PurchaseOrderDetailSelectMethod SelectMethod
		{
			get { return ((PurchaseOrderDetailDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PurchaseOrderDetailDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PurchaseOrderDetailDataSourceActionList

	/// <summary>
	/// Supports the PurchaseOrderDetailDataSourceDesigner class.
	/// </summary>
	internal class PurchaseOrderDetailDataSourceActionList : DesignerActionList
	{
		private PurchaseOrderDetailDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PurchaseOrderDetailDataSourceActionList(PurchaseOrderDetailDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PurchaseOrderDetailSelectMethod SelectMethod
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

	#endregion PurchaseOrderDetailDataSourceActionList
	
	#endregion PurchaseOrderDetailDataSourceDesigner
	
	#region PurchaseOrderDetailSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PurchaseOrderDetailDataSource.SelectMethod property.
	/// </summary>
	public enum PurchaseOrderDetailSelectMethod
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
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId,
		/// <summary>
		/// Represents the GetByPurchaseOrderIdPurchaseOrderDetailId method.
		/// </summary>
		GetByPurchaseOrderIdPurchaseOrderDetailId,
		/// <summary>
		/// Represents the GetByPurchaseOrderId method.
		/// </summary>
		GetByPurchaseOrderId
	}
	
	#endregion PurchaseOrderDetailSelectMethod

	#region PurchaseOrderDetailFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderDetailFilter : SqlFilter<PurchaseOrderDetailColumn>
	{
	}
	
	#endregion PurchaseOrderDetailFilter

	#region PurchaseOrderDetailExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderDetailExpressionBuilder : SqlExpressionBuilder<PurchaseOrderDetailColumn>
	{
	}
	
	#endregion PurchaseOrderDetailExpressionBuilder	

	#region PurchaseOrderDetailProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PurchaseOrderDetailChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderDetailProperty : ChildEntityProperty<PurchaseOrderDetailChildEntityTypes>
	{
	}
	
	#endregion PurchaseOrderDetailProperty
}

