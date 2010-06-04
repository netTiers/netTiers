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
	/// Represents the DataRepository.SalesOrderDetailProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalesOrderDetailDataSourceDesigner))]
	public class SalesOrderDetailDataSource : ProviderDataSource<SalesOrderDetail, SalesOrderDetailKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailDataSource class.
		/// </summary>
		public SalesOrderDetailDataSource() : base(new SalesOrderDetailService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalesOrderDetailDataSourceView used by the SalesOrderDetailDataSource.
		/// </summary>
		protected SalesOrderDetailDataSourceView SalesOrderDetailView
		{
			get { return ( View as SalesOrderDetailDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalesOrderDetailDataSource control invokes to retrieve data.
		/// </summary>
		public SalesOrderDetailSelectMethod SelectMethod
		{
			get
			{
				SalesOrderDetailSelectMethod selectMethod = SalesOrderDetailSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalesOrderDetailSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalesOrderDetailDataSourceView class that is to be
		/// used by the SalesOrderDetailDataSource.
		/// </summary>
		/// <returns>An instance of the SalesOrderDetailDataSourceView class.</returns>
		protected override BaseDataSourceView<SalesOrderDetail, SalesOrderDetailKey> GetNewDataSourceView()
		{
			return new SalesOrderDetailDataSourceView(this, DefaultViewName);
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
	/// Supports the SalesOrderDetailDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalesOrderDetailDataSourceView : ProviderDataSourceView<SalesOrderDetail, SalesOrderDetailKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalesOrderDetailDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalesOrderDetailDataSourceView(SalesOrderDetailDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalesOrderDetailDataSource SalesOrderDetailOwner
		{
			get { return Owner as SalesOrderDetailDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalesOrderDetailSelectMethod SelectMethod
		{
			get { return SalesOrderDetailOwner.SelectMethod; }
			set { SalesOrderDetailOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalesOrderDetailService SalesOrderDetailProvider
		{
			get { return Provider as SalesOrderDetailService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalesOrderDetail> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalesOrderDetail> results = null;
			SalesOrderDetail item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _productId;
			System.Int32 _salesOrderId;
			System.Int32 _salesOrderDetailId;
			System.Int32 _specialOfferId;

			switch ( SelectMethod )
			{
				case SalesOrderDetailSelectMethod.Get:
					SalesOrderDetailKey entityKey  = new SalesOrderDetailKey();
					entityKey.Load(values);
					item = SalesOrderDetailProvider.Get(entityKey);
					results = new TList<SalesOrderDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesOrderDetailSelectMethod.GetAll:
                    results = SalesOrderDetailProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalesOrderDetailSelectMethod.GetPaged:
					results = SalesOrderDetailProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalesOrderDetailSelectMethod.Find:
					if ( FilterParameters != null )
						results = SalesOrderDetailProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalesOrderDetailProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalesOrderDetailSelectMethod.GetBySalesOrderIdSalesOrderDetailId:
					_salesOrderId = ( values["SalesOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesOrderId"], typeof(System.Int32)) : (int)0;
					_salesOrderDetailId = ( values["SalesOrderDetailId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesOrderDetailId"], typeof(System.Int32)) : (int)0;
					item = SalesOrderDetailProvider.GetBySalesOrderIdSalesOrderDetailId(_salesOrderId, _salesOrderDetailId);
					results = new TList<SalesOrderDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SalesOrderDetailSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = SalesOrderDetailProvider.GetByRowguid(_rowguid);
					results = new TList<SalesOrderDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesOrderDetailSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderDetailProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case SalesOrderDetailSelectMethod.GetBySalesOrderId:
					_salesOrderId = ( values["SalesOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesOrderId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderDetailProvider.GetBySalesOrderId(_salesOrderId, this.StartIndex, this.PageSize, out count);
					break;
				case SalesOrderDetailSelectMethod.GetBySpecialOfferIdProductId:
					_specialOfferId = ( values["SpecialOfferId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SpecialOfferId"], typeof(System.Int32)) : (int)0;
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = SalesOrderDetailProvider.GetBySpecialOfferIdProductId(_specialOfferId, _productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SalesOrderDetailSelectMethod.Get || SelectMethod == SalesOrderDetailSelectMethod.GetBySalesOrderIdSalesOrderDetailId )
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
				SalesOrderDetail entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalesOrderDetailProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalesOrderDetail> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalesOrderDetailProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalesOrderDetailDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalesOrderDetailDataSource class.
	/// </summary>
	public class SalesOrderDetailDataSourceDesigner : ProviderDataSourceDesigner<SalesOrderDetail, SalesOrderDetailKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailDataSourceDesigner class.
		/// </summary>
		public SalesOrderDetailDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesOrderDetailSelectMethod SelectMethod
		{
			get { return ((SalesOrderDetailDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalesOrderDetailDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalesOrderDetailDataSourceActionList

	/// <summary>
	/// Supports the SalesOrderDetailDataSourceDesigner class.
	/// </summary>
	internal class SalesOrderDetailDataSourceActionList : DesignerActionList
	{
		private SalesOrderDetailDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalesOrderDetailDataSourceActionList(SalesOrderDetailDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesOrderDetailSelectMethod SelectMethod
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

	#endregion SalesOrderDetailDataSourceActionList
	
	#endregion SalesOrderDetailDataSourceDesigner
	
	#region SalesOrderDetailSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalesOrderDetailDataSource.SelectMethod property.
	/// </summary>
	public enum SalesOrderDetailSelectMethod
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
		/// Represents the GetBySalesOrderIdSalesOrderDetailId method.
		/// </summary>
		GetBySalesOrderIdSalesOrderDetailId,
		/// <summary>
		/// Represents the GetBySalesOrderId method.
		/// </summary>
		GetBySalesOrderId,
		/// <summary>
		/// Represents the GetBySpecialOfferIdProductId method.
		/// </summary>
		GetBySpecialOfferIdProductId
	}
	
	#endregion SalesOrderDetailSelectMethod

	#region SalesOrderDetailFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderDetailFilter : SqlFilter<SalesOrderDetailColumn>
	{
	}
	
	#endregion SalesOrderDetailFilter

	#region SalesOrderDetailExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderDetailExpressionBuilder : SqlExpressionBuilder<SalesOrderDetailColumn>
	{
	}
	
	#endregion SalesOrderDetailExpressionBuilder	

	#region SalesOrderDetailProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalesOrderDetailChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderDetailProperty : ChildEntityProperty<SalesOrderDetailChildEntityTypes>
	{
	}
	
	#endregion SalesOrderDetailProperty
}

