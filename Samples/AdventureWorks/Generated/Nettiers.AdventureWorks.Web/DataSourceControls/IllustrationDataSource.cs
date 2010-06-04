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
	/// Represents the DataRepository.IllustrationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(IllustrationDataSourceDesigner))]
	public class IllustrationDataSource : ProviderDataSource<Illustration, IllustrationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IllustrationDataSource class.
		/// </summary>
		public IllustrationDataSource() : base(new IllustrationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the IllustrationDataSourceView used by the IllustrationDataSource.
		/// </summary>
		protected IllustrationDataSourceView IllustrationView
		{
			get { return ( View as IllustrationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the IllustrationDataSource control invokes to retrieve data.
		/// </summary>
		public IllustrationSelectMethod SelectMethod
		{
			get
			{
				IllustrationSelectMethod selectMethod = IllustrationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (IllustrationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the IllustrationDataSourceView class that is to be
		/// used by the IllustrationDataSource.
		/// </summary>
		/// <returns>An instance of the IllustrationDataSourceView class.</returns>
		protected override BaseDataSourceView<Illustration, IllustrationKey> GetNewDataSourceView()
		{
			return new IllustrationDataSourceView(this, DefaultViewName);
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
	/// Supports the IllustrationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class IllustrationDataSourceView : ProviderDataSourceView<Illustration, IllustrationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IllustrationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the IllustrationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public IllustrationDataSourceView(IllustrationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal IllustrationDataSource IllustrationOwner
		{
			get { return Owner as IllustrationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal IllustrationSelectMethod SelectMethod
		{
			get { return IllustrationOwner.SelectMethod; }
			set { IllustrationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal IllustrationService IllustrationProvider
		{
			get { return Provider as IllustrationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Illustration> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Illustration> results = null;
			Illustration item;
			count = 0;
			
			System.Int32 _illustrationId;
			System.Int32 _productModelId;

			switch ( SelectMethod )
			{
				case IllustrationSelectMethod.Get:
					IllustrationKey entityKey  = new IllustrationKey();
					entityKey.Load(values);
					item = IllustrationProvider.Get(entityKey);
					results = new TList<Illustration>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case IllustrationSelectMethod.GetAll:
                    results = IllustrationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case IllustrationSelectMethod.GetPaged:
					results = IllustrationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case IllustrationSelectMethod.Find:
					if ( FilterParameters != null )
						results = IllustrationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = IllustrationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case IllustrationSelectMethod.GetByIllustrationId:
					_illustrationId = ( values["IllustrationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IllustrationId"], typeof(System.Int32)) : (int)0;
					item = IllustrationProvider.GetByIllustrationId(_illustrationId);
					results = new TList<Illustration>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case IllustrationSelectMethod.GetByProductModelIdFromProductModelIllustration:
					_productModelId = ( values["ProductModelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32)) : (int)0;
					results = IllustrationProvider.GetByProductModelIdFromProductModelIllustration(_productModelId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == IllustrationSelectMethod.Get || SelectMethod == IllustrationSelectMethod.GetByIllustrationId )
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
				Illustration entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					IllustrationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Illustration> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			IllustrationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region IllustrationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the IllustrationDataSource class.
	/// </summary>
	public class IllustrationDataSourceDesigner : ProviderDataSourceDesigner<Illustration, IllustrationKey>
	{
		/// <summary>
		/// Initializes a new instance of the IllustrationDataSourceDesigner class.
		/// </summary>
		public IllustrationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IllustrationSelectMethod SelectMethod
		{
			get { return ((IllustrationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new IllustrationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region IllustrationDataSourceActionList

	/// <summary>
	/// Supports the IllustrationDataSourceDesigner class.
	/// </summary>
	internal class IllustrationDataSourceActionList : DesignerActionList
	{
		private IllustrationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the IllustrationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public IllustrationDataSourceActionList(IllustrationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IllustrationSelectMethod SelectMethod
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

	#endregion IllustrationDataSourceActionList
	
	#endregion IllustrationDataSourceDesigner
	
	#region IllustrationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the IllustrationDataSource.SelectMethod property.
	/// </summary>
	public enum IllustrationSelectMethod
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
		/// Represents the GetByIllustrationId method.
		/// </summary>
		GetByIllustrationId,
		/// <summary>
		/// Represents the GetByProductModelIdFromProductModelIllustration method.
		/// </summary>
		GetByProductModelIdFromProductModelIllustration
	}
	
	#endregion IllustrationSelectMethod

	#region IllustrationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Illustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IllustrationFilter : SqlFilter<IllustrationColumn>
	{
	}
	
	#endregion IllustrationFilter

	#region IllustrationExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Illustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IllustrationExpressionBuilder : SqlExpressionBuilder<IllustrationColumn>
	{
	}
	
	#endregion IllustrationExpressionBuilder	

	#region IllustrationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;IllustrationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Illustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IllustrationProperty : ChildEntityProperty<IllustrationChildEntityTypes>
	{
	}
	
	#endregion IllustrationProperty
}

