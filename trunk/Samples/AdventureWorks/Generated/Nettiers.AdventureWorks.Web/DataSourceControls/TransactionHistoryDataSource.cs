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
	/// Represents the DataRepository.TransactionHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TransactionHistoryDataSourceDesigner))]
	public class TransactionHistoryDataSource : ProviderDataSource<TransactionHistory, TransactionHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryDataSource class.
		/// </summary>
		public TransactionHistoryDataSource() : base(new TransactionHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TransactionHistoryDataSourceView used by the TransactionHistoryDataSource.
		/// </summary>
		protected TransactionHistoryDataSourceView TransactionHistoryView
		{
			get { return ( View as TransactionHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TransactionHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public TransactionHistorySelectMethod SelectMethod
		{
			get
			{
				TransactionHistorySelectMethod selectMethod = TransactionHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TransactionHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TransactionHistoryDataSourceView class that is to be
		/// used by the TransactionHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the TransactionHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<TransactionHistory, TransactionHistoryKey> GetNewDataSourceView()
		{
			return new TransactionHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the TransactionHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TransactionHistoryDataSourceView : ProviderDataSourceView<TransactionHistory, TransactionHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TransactionHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TransactionHistoryDataSourceView(TransactionHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TransactionHistoryDataSource TransactionHistoryOwner
		{
			get { return Owner as TransactionHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TransactionHistorySelectMethod SelectMethod
		{
			get { return TransactionHistoryOwner.SelectMethod; }
			set { TransactionHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TransactionHistoryService TransactionHistoryProvider
		{
			get { return Provider as TransactionHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TransactionHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TransactionHistory> results = null;
			TransactionHistory item;
			count = 0;
			
			System.Int32 _productId;
			System.Int32 _referenceOrderId;
			System.Int32 _referenceOrderLineId;
			System.Int32 _transactionId;

			switch ( SelectMethod )
			{
				case TransactionHistorySelectMethod.Get:
					TransactionHistoryKey entityKey  = new TransactionHistoryKey();
					entityKey.Load(values);
					item = TransactionHistoryProvider.Get(entityKey);
					results = new TList<TransactionHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TransactionHistorySelectMethod.GetAll:
                    results = TransactionHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TransactionHistorySelectMethod.GetPaged:
					results = TransactionHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TransactionHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = TransactionHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TransactionHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TransactionHistorySelectMethod.GetByTransactionId:
					_transactionId = ( values["TransactionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TransactionId"], typeof(System.Int32)) : (int)0;
					item = TransactionHistoryProvider.GetByTransactionId(_transactionId);
					results = new TList<TransactionHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case TransactionHistorySelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = TransactionHistoryProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				case TransactionHistorySelectMethod.GetByReferenceOrderIdReferenceOrderLineId:
					_referenceOrderId = ( values["ReferenceOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ReferenceOrderId"], typeof(System.Int32)) : (int)0;
					_referenceOrderLineId = ( values["ReferenceOrderLineId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ReferenceOrderLineId"], typeof(System.Int32)) : (int)0;
					results = TransactionHistoryProvider.GetByReferenceOrderIdReferenceOrderLineId(_referenceOrderId, _referenceOrderLineId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
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
			if ( SelectMethod == TransactionHistorySelectMethod.Get || SelectMethod == TransactionHistorySelectMethod.GetByTransactionId )
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
				TransactionHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TransactionHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TransactionHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TransactionHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TransactionHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TransactionHistoryDataSource class.
	/// </summary>
	public class TransactionHistoryDataSourceDesigner : ProviderDataSourceDesigner<TransactionHistory, TransactionHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the TransactionHistoryDataSourceDesigner class.
		/// </summary>
		public TransactionHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TransactionHistorySelectMethod SelectMethod
		{
			get { return ((TransactionHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TransactionHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TransactionHistoryDataSourceActionList

	/// <summary>
	/// Supports the TransactionHistoryDataSourceDesigner class.
	/// </summary>
	internal class TransactionHistoryDataSourceActionList : DesignerActionList
	{
		private TransactionHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TransactionHistoryDataSourceActionList(TransactionHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TransactionHistorySelectMethod SelectMethod
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

	#endregion TransactionHistoryDataSourceActionList
	
	#endregion TransactionHistoryDataSourceDesigner
	
	#region TransactionHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TransactionHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum TransactionHistorySelectMethod
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
		/// Represents the GetByReferenceOrderIdReferenceOrderLineId method.
		/// </summary>
		GetByReferenceOrderIdReferenceOrderLineId,
		/// <summary>
		/// Represents the GetByTransactionId method.
		/// </summary>
		GetByTransactionId
	}
	
	#endregion TransactionHistorySelectMethod

	#region TransactionHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryFilter : SqlFilter<TransactionHistoryColumn>
	{
	}
	
	#endregion TransactionHistoryFilter

	#region TransactionHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryExpressionBuilder : SqlExpressionBuilder<TransactionHistoryColumn>
	{
	}
	
	#endregion TransactionHistoryExpressionBuilder	

	#region TransactionHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TransactionHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryProperty : ChildEntityProperty<TransactionHistoryChildEntityTypes>
	{
	}
	
	#endregion TransactionHistoryProperty
}

