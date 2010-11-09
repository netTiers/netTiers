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
	/// Represents the DataRepository.SpecialOfferProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SpecialOfferDataSourceDesigner))]
	public class SpecialOfferDataSource : ProviderDataSource<SpecialOffer, SpecialOfferKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferDataSource class.
		/// </summary>
		public SpecialOfferDataSource() : base(new SpecialOfferService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SpecialOfferDataSourceView used by the SpecialOfferDataSource.
		/// </summary>
		protected SpecialOfferDataSourceView SpecialOfferView
		{
			get { return ( View as SpecialOfferDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SpecialOfferDataSource control invokes to retrieve data.
		/// </summary>
		public SpecialOfferSelectMethod SelectMethod
		{
			get
			{
				SpecialOfferSelectMethod selectMethod = SpecialOfferSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SpecialOfferSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SpecialOfferDataSourceView class that is to be
		/// used by the SpecialOfferDataSource.
		/// </summary>
		/// <returns>An instance of the SpecialOfferDataSourceView class.</returns>
		protected override BaseDataSourceView<SpecialOffer, SpecialOfferKey> GetNewDataSourceView()
		{
			return new SpecialOfferDataSourceView(this, DefaultViewName);
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
	/// Supports the SpecialOfferDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SpecialOfferDataSourceView : ProviderDataSourceView<SpecialOffer, SpecialOfferKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SpecialOfferDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SpecialOfferDataSourceView(SpecialOfferDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SpecialOfferDataSource SpecialOfferOwner
		{
			get { return Owner as SpecialOfferDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SpecialOfferSelectMethod SelectMethod
		{
			get { return SpecialOfferOwner.SelectMethod; }
			set { SpecialOfferOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SpecialOfferService SpecialOfferProvider
		{
			get { return Provider as SpecialOfferService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SpecialOffer> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SpecialOffer> results = null;
			SpecialOffer item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _specialOfferId;
			System.Int32 _productId;

			switch ( SelectMethod )
			{
				case SpecialOfferSelectMethod.Get:
					SpecialOfferKey entityKey  = new SpecialOfferKey();
					entityKey.Load(values);
					item = SpecialOfferProvider.Get(entityKey);
					results = new TList<SpecialOffer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SpecialOfferSelectMethod.GetAll:
                    results = SpecialOfferProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SpecialOfferSelectMethod.GetPaged:
					results = SpecialOfferProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SpecialOfferSelectMethod.Find:
					if ( FilterParameters != null )
						results = SpecialOfferProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SpecialOfferProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SpecialOfferSelectMethod.GetBySpecialOfferId:
					_specialOfferId = ( values["SpecialOfferId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SpecialOfferId"], typeof(System.Int32)) : (int)0;
					item = SpecialOfferProvider.GetBySpecialOfferId(_specialOfferId);
					results = new TList<SpecialOffer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SpecialOfferSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = SpecialOfferProvider.GetByRowguid(_rowguid);
					results = new TList<SpecialOffer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case SpecialOfferSelectMethod.GetByProductIdFromSpecialOfferProduct:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = SpecialOfferProvider.GetByProductIdFromSpecialOfferProduct(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SpecialOfferSelectMethod.Get || SelectMethod == SpecialOfferSelectMethod.GetBySpecialOfferId )
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
				SpecialOffer entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SpecialOfferProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SpecialOffer> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SpecialOfferProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SpecialOfferDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SpecialOfferDataSource class.
	/// </summary>
	public class SpecialOfferDataSourceDesigner : ProviderDataSourceDesigner<SpecialOffer, SpecialOfferKey>
	{
		/// <summary>
		/// Initializes a new instance of the SpecialOfferDataSourceDesigner class.
		/// </summary>
		public SpecialOfferDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SpecialOfferSelectMethod SelectMethod
		{
			get { return ((SpecialOfferDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SpecialOfferDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SpecialOfferDataSourceActionList

	/// <summary>
	/// Supports the SpecialOfferDataSourceDesigner class.
	/// </summary>
	internal class SpecialOfferDataSourceActionList : DesignerActionList
	{
		private SpecialOfferDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SpecialOfferDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SpecialOfferDataSourceActionList(SpecialOfferDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SpecialOfferSelectMethod SelectMethod
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

	#endregion SpecialOfferDataSourceActionList
	
	#endregion SpecialOfferDataSourceDesigner
	
	#region SpecialOfferSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SpecialOfferDataSource.SelectMethod property.
	/// </summary>
	public enum SpecialOfferSelectMethod
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
		/// Represents the GetBySpecialOfferId method.
		/// </summary>
		GetBySpecialOfferId,
		/// <summary>
		/// Represents the GetByProductIdFromSpecialOfferProduct method.
		/// </summary>
		GetByProductIdFromSpecialOfferProduct
	}
	
	#endregion SpecialOfferSelectMethod

	#region SpecialOfferFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferFilter : SqlFilter<SpecialOfferColumn>
	{
	}
	
	#endregion SpecialOfferFilter

	#region SpecialOfferExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferExpressionBuilder : SqlExpressionBuilder<SpecialOfferColumn>
	{
	}
	
	#endregion SpecialOfferExpressionBuilder	

	#region SpecialOfferProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SpecialOfferChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferProperty : ChildEntityProperty<SpecialOfferChildEntityTypes>
	{
	}
	
	#endregion SpecialOfferProperty
}

