#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.Bases;
using netTiers.Petshop.Services;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.CreditCardProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CreditCardDataSourceDesigner))]
	public class CreditCardDataSource : ProviderDataSource<CreditCard, CreditCardKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CreditCardDataSource class.
		/// </summary>
		public CreditCardDataSource() : base(new CreditCardService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CreditCardDataSourceView used by the CreditCardDataSource.
		/// </summary>
		protected CreditCardDataSourceView CreditCardView
		{
			get { return ( View as CreditCardDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CreditCardDataSource control invokes to retrieve data.
		/// </summary>
		public CreditCardSelectMethod SelectMethod
		{
			get { return CreditCardView.SelectMethod; }
			set { CreditCardView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CreditCardDataSourceView class that is to be
		/// used by the CreditCardDataSource.
		/// </summary>
		/// <returns>An instance of the CreditCardDataSourceView class.</returns>
		protected override BaseDataSourceView<CreditCard, CreditCardKey> GetNewDataSourceView()
		{
			return new CreditCardDataSourceView(this, DefaultViewName);
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
	/// Supports the CreditCardDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CreditCardDataSourceView : ProviderDataSourceView<CreditCard, CreditCardKey>
	{
		#region Declarations

		private CreditCardSelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CreditCardDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CreditCardDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CreditCardDataSourceView(CreditCardDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CreditCardSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CreditCardService CreditCardProvider
		{
			get { return Provider as CreditCardService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CreditCard> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<CreditCard> results = null;
			CreditCard item;
			count = 0;
			
			System.String id;

			switch ( SelectMethod )
			{
				case CreditCardSelectMethod.Get:
					CreditCardKey key = new CreditCardKey();
					key.Load(values);
					item = CreditCardProvider.Get(key);
					results = new TList<CreditCard>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CreditCardSelectMethod.GetAll:
                    results = CreditCardProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CreditCardSelectMethod.GetPaged:
					results = CreditCardProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CreditCardSelectMethod.Find:
					results = CreditCardProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CreditCardSelectMethod.GetById:
					id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = CreditCardProvider.GetById(id);
					results = new TList<CreditCard>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				default:
					break;
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == CreditCardSelectMethod.Get || SelectMethod == CreditCardSelectMethod.GetById )
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
				IsDeepLoaded = true;
				CreditCardProvider.DeepLoad(GetCurrentEntity());
			}
		}

		#endregion Select Methods
	}
	
	#region CreditCardDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CreditCardDataSource class.
	/// </summary>
	public class CreditCardDataSourceDesigner : ProviderDataSourceDesigner<CreditCard, CreditCardKey>
	{
		/// <summary>
		/// Initializes a new instance of the CreditCardDataSourceDesigner class.
		/// </summary>
		public CreditCardDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CreditCardSelectMethod SelectMethod
		{
			get { return ((CreditCardDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CreditCardDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CreditCardDataSourceActionList

	/// <summary>
	/// Supports the CreditCardDataSourceDesigner class.
	/// </summary>
	internal class CreditCardDataSourceActionList : DesignerActionList
	{
		private CreditCardDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CreditCardDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CreditCardDataSourceActionList(CreditCardDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CreditCardSelectMethod SelectMethod
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

	#endregion CreditCardDataSourceActionList
	
	#endregion CreditCardDataSourceDesigner
	
	#region CreditCardSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CreditCardDataSource.SelectMethod property.
	/// </summary>
	public enum CreditCardSelectMethod
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
		/// Represents the GetById method.
		/// </summary>
		GetById
	}
	
	#endregion CreditCardSelectMethod

	#region CreditCardFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CreditCardFilter : SqlFilter<CreditCardColumn>
	{
	}
	
	#endregion CreditCardFilter
}

