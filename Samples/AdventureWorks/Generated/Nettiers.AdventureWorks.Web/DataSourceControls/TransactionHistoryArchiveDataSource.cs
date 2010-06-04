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
	/// Represents the DataRepository.TransactionHistoryArchiveProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TransactionHistoryArchiveDataSourceDesigner))]
	public class TransactionHistoryArchiveDataSource : ProviderDataSource<TransactionHistoryArchive, TransactionHistoryArchiveKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveDataSource class.
		/// </summary>
		public TransactionHistoryArchiveDataSource() : base(new TransactionHistoryArchiveService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TransactionHistoryArchiveDataSourceView used by the TransactionHistoryArchiveDataSource.
		/// </summary>
		protected TransactionHistoryArchiveDataSourceView TransactionHistoryArchiveView
		{
			get { return ( View as TransactionHistoryArchiveDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TransactionHistoryArchiveDataSource control invokes to retrieve data.
		/// </summary>
		public TransactionHistoryArchiveSelectMethod SelectMethod
		{
			get
			{
				TransactionHistoryArchiveSelectMethod selectMethod = TransactionHistoryArchiveSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TransactionHistoryArchiveSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TransactionHistoryArchiveDataSourceView class that is to be
		/// used by the TransactionHistoryArchiveDataSource.
		/// </summary>
		/// <returns>An instance of the TransactionHistoryArchiveDataSourceView class.</returns>
		protected override BaseDataSourceView<TransactionHistoryArchive, TransactionHistoryArchiveKey> GetNewDataSourceView()
		{
			return new TransactionHistoryArchiveDataSourceView(this, DefaultViewName);
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
	/// Supports the TransactionHistoryArchiveDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TransactionHistoryArchiveDataSourceView : ProviderDataSourceView<TransactionHistoryArchive, TransactionHistoryArchiveKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TransactionHistoryArchiveDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TransactionHistoryArchiveDataSourceView(TransactionHistoryArchiveDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TransactionHistoryArchiveDataSource TransactionHistoryArchiveOwner
		{
			get { return Owner as TransactionHistoryArchiveDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TransactionHistoryArchiveSelectMethod SelectMethod
		{
			get { return TransactionHistoryArchiveOwner.SelectMethod; }
			set { TransactionHistoryArchiveOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TransactionHistoryArchiveService TransactionHistoryArchiveProvider
		{
			get { return Provider as TransactionHistoryArchiveService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TransactionHistoryArchive> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TransactionHistoryArchive> results = null;
			TransactionHistoryArchive item;
			count = 0;
			
			System.Int32 _productId;
			System.Int32 _referenceOrderId;
			System.Int32 _referenceOrderLineId;
			System.Int32 _transactionId;

			switch ( SelectMethod )
			{
				case TransactionHistoryArchiveSelectMethod.Get:
					TransactionHistoryArchiveKey entityKey  = new TransactionHistoryArchiveKey();
					entityKey.Load(values);
					item = TransactionHistoryArchiveProvider.Get(entityKey);
					results = new TList<TransactionHistoryArchive>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TransactionHistoryArchiveSelectMethod.GetAll:
                    results = TransactionHistoryArchiveProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TransactionHistoryArchiveSelectMethod.GetPaged:
					results = TransactionHistoryArchiveProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TransactionHistoryArchiveSelectMethod.Find:
					if ( FilterParameters != null )
						results = TransactionHistoryArchiveProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TransactionHistoryArchiveProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TransactionHistoryArchiveSelectMethod.GetByTransactionId:
					_transactionId = ( values["TransactionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TransactionId"], typeof(System.Int32)) : (int)0;
					item = TransactionHistoryArchiveProvider.GetByTransactionId(_transactionId);
					results = new TList<TransactionHistoryArchive>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case TransactionHistoryArchiveSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = TransactionHistoryArchiveProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				case TransactionHistoryArchiveSelectMethod.GetByReferenceOrderIdReferenceOrderLineId:
					_referenceOrderId = ( values["ReferenceOrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ReferenceOrderId"], typeof(System.Int32)) : (int)0;
					_referenceOrderLineId = ( values["ReferenceOrderLineId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ReferenceOrderLineId"], typeof(System.Int32)) : (int)0;
					results = TransactionHistoryArchiveProvider.GetByReferenceOrderIdReferenceOrderLineId(_referenceOrderId, _referenceOrderLineId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == TransactionHistoryArchiveSelectMethod.Get || SelectMethod == TransactionHistoryArchiveSelectMethod.GetByTransactionId )
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
				TransactionHistoryArchive entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TransactionHistoryArchiveProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TransactionHistoryArchive> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TransactionHistoryArchiveProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TransactionHistoryArchiveDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TransactionHistoryArchiveDataSource class.
	/// </summary>
	public class TransactionHistoryArchiveDataSourceDesigner : ProviderDataSourceDesigner<TransactionHistoryArchive, TransactionHistoryArchiveKey>
	{
		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveDataSourceDesigner class.
		/// </summary>
		public TransactionHistoryArchiveDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TransactionHistoryArchiveSelectMethod SelectMethod
		{
			get { return ((TransactionHistoryArchiveDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TransactionHistoryArchiveDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TransactionHistoryArchiveDataSourceActionList

	/// <summary>
	/// Supports the TransactionHistoryArchiveDataSourceDesigner class.
	/// </summary>
	internal class TransactionHistoryArchiveDataSourceActionList : DesignerActionList
	{
		private TransactionHistoryArchiveDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TransactionHistoryArchiveDataSourceActionList(TransactionHistoryArchiveDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TransactionHistoryArchiveSelectMethod SelectMethod
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

	#endregion TransactionHistoryArchiveDataSourceActionList
	
	#endregion TransactionHistoryArchiveDataSourceDesigner
	
	#region TransactionHistoryArchiveSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TransactionHistoryArchiveDataSource.SelectMethod property.
	/// </summary>
	public enum TransactionHistoryArchiveSelectMethod
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
	
	#endregion TransactionHistoryArchiveSelectMethod

	#region TransactionHistoryArchiveFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistoryArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryArchiveFilter : SqlFilter<TransactionHistoryArchiveColumn>
	{
	}
	
	#endregion TransactionHistoryArchiveFilter

	#region TransactionHistoryArchiveExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistoryArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryArchiveExpressionBuilder : SqlExpressionBuilder<TransactionHistoryArchiveColumn>
	{
	}
	
	#endregion TransactionHistoryArchiveExpressionBuilder	

	#region TransactionHistoryArchiveProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TransactionHistoryArchiveChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistoryArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryArchiveProperty : ChildEntityProperty<TransactionHistoryArchiveChildEntityTypes>
	{
	}
	
	#endregion TransactionHistoryArchiveProperty
}

