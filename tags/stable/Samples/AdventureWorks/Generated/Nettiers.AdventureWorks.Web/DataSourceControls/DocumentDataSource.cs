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
	/// Represents the DataRepository.DocumentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DocumentDataSourceDesigner))]
	public class DocumentDataSource : ProviderDataSource<Document, DocumentKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentDataSource class.
		/// </summary>
		public DocumentDataSource() : base(new DocumentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DocumentDataSourceView used by the DocumentDataSource.
		/// </summary>
		protected DocumentDataSourceView DocumentView
		{
			get { return ( View as DocumentDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DocumentDataSource control invokes to retrieve data.
		/// </summary>
		public DocumentSelectMethod SelectMethod
		{
			get
			{
				DocumentSelectMethod selectMethod = DocumentSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DocumentSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DocumentDataSourceView class that is to be
		/// used by the DocumentDataSource.
		/// </summary>
		/// <returns>An instance of the DocumentDataSourceView class.</returns>
		protected override BaseDataSourceView<Document, DocumentKey> GetNewDataSourceView()
		{
			return new DocumentDataSourceView(this, DefaultViewName);
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
	/// Supports the DocumentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DocumentDataSourceView : ProviderDataSourceView<Document, DocumentKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DocumentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DocumentDataSourceView(DocumentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DocumentDataSource DocumentOwner
		{
			get { return Owner as DocumentDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DocumentSelectMethod SelectMethod
		{
			get { return DocumentOwner.SelectMethod; }
			set { DocumentOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DocumentService DocumentProvider
		{
			get { return Provider as DocumentService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Document> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Document> results = null;
			Document item;
			count = 0;
			
			System.String _fileName;
			System.String _revision;
			System.Int32 _documentId;
			System.Int32 _productId;

			switch ( SelectMethod )
			{
				case DocumentSelectMethod.Get:
					DocumentKey entityKey  = new DocumentKey();
					entityKey.Load(values);
					item = DocumentProvider.Get(entityKey);
					results = new TList<Document>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DocumentSelectMethod.GetAll:
                    results = DocumentProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DocumentSelectMethod.GetPaged:
					results = DocumentProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DocumentSelectMethod.Find:
					if ( FilterParameters != null )
						results = DocumentProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DocumentProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DocumentSelectMethod.GetByDocumentId:
					_documentId = ( values["DocumentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DocumentId"], typeof(System.Int32)) : (int)0;
					item = DocumentProvider.GetByDocumentId(_documentId);
					results = new TList<Document>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case DocumentSelectMethod.GetByFileNameRevision:
					_fileName = ( values["FileName"] != null ) ? (System.String) EntityUtil.ChangeType(values["FileName"], typeof(System.String)) : string.Empty;
					_revision = ( values["Revision"] != null ) ? (System.String) EntityUtil.ChangeType(values["Revision"], typeof(System.String)) : string.Empty;
					item = DocumentProvider.GetByFileNameRevision(_fileName, _revision);
					results = new TList<Document>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case DocumentSelectMethod.GetByProductIdFromProductDocument:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = DocumentProvider.GetByProductIdFromProductDocument(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DocumentSelectMethod.Get || SelectMethod == DocumentSelectMethod.GetByDocumentId )
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
				Document entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DocumentProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Document> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DocumentProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DocumentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DocumentDataSource class.
	/// </summary>
	public class DocumentDataSourceDesigner : ProviderDataSourceDesigner<Document, DocumentKey>
	{
		/// <summary>
		/// Initializes a new instance of the DocumentDataSourceDesigner class.
		/// </summary>
		public DocumentDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DocumentSelectMethod SelectMethod
		{
			get { return ((DocumentDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DocumentDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DocumentDataSourceActionList

	/// <summary>
	/// Supports the DocumentDataSourceDesigner class.
	/// </summary>
	internal class DocumentDataSourceActionList : DesignerActionList
	{
		private DocumentDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DocumentDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DocumentDataSourceActionList(DocumentDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DocumentSelectMethod SelectMethod
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

	#endregion DocumentDataSourceActionList
	
	#endregion DocumentDataSourceDesigner
	
	#region DocumentSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DocumentDataSource.SelectMethod property.
	/// </summary>
	public enum DocumentSelectMethod
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
		/// Represents the GetByFileNameRevision method.
		/// </summary>
		GetByFileNameRevision,
		/// <summary>
		/// Represents the GetByDocumentId method.
		/// </summary>
		GetByDocumentId,
		/// <summary>
		/// Represents the GetByProductIdFromProductDocument method.
		/// </summary>
		GetByProductIdFromProductDocument
	}
	
	#endregion DocumentSelectMethod

	#region DocumentFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Document"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentFilter : SqlFilter<DocumentColumn>
	{
	}
	
	#endregion DocumentFilter

	#region DocumentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Document"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentExpressionBuilder : SqlExpressionBuilder<DocumentColumn>
	{
	}
	
	#endregion DocumentExpressionBuilder	

	#region DocumentProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DocumentChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Document"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentProperty : ChildEntityProperty<DocumentChildEntityTypes>
	{
	}
	
	#endregion DocumentProperty
}

