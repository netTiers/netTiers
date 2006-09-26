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
	/// Represents the DataRepository.CourierProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CourierDataSourceDesigner))]
	public class CourierDataSource : ProviderDataSource<Courier, CourierKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourierDataSource class.
		/// </summary>
		public CourierDataSource() : base(new CourierService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CourierDataSourceView used by the CourierDataSource.
		/// </summary>
		protected CourierDataSourceView CourierView
		{
			get { return ( View as CourierDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CourierDataSource control invokes to retrieve data.
		/// </summary>
		public CourierSelectMethod SelectMethod
		{
			get { return CourierView.SelectMethod; }
			set { CourierView.SelectMethod = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CourierDataSourceView class that is to be
		/// used by the CourierDataSource.
		/// </summary>
		/// <returns>An instance of the CourierDataSourceView class.</returns>
		protected override BaseDataSourceView<Courier, CourierKey> GetNewDataSourceView()
		{
			return new CourierDataSourceView(this, DefaultViewName);
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
	/// Supports the CourierDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CourierDataSourceView : ProviderDataSourceView<Courier, CourierKey>
	{
		#region Declarations

		private CourierSelectMethod _selectMethod;

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourierDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CourierDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CourierDataSourceView(CourierDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CourierSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CourierService CourierProvider
		{
			get { return Provider as CourierService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Courier> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			IList<Courier> results = null;
			Courier item;
			count = 0;
			
			System.Guid courierId;

			switch ( SelectMethod )
			{
				case CourierSelectMethod.Get:
					CourierKey entityKey  = new CourierKey();
					entityKey.Load(values);
					item = CourierProvider.Get(entityKey);
					results = new TList<Courier>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CourierSelectMethod.GetAll:
                    results = CourierProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CourierSelectMethod.GetPaged:
					results = CourierProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CourierSelectMethod.Find:
					results = CourierProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CourierSelectMethod.GetByCourierId:
					courierId = ( values["CourierId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["CourierId"], typeof(System.Guid)) : Guid.Empty;
					item = CourierProvider.GetByCourierId(courierId);
					results = new TList<Courier>();
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
			if ( SelectMethod == CourierSelectMethod.Get || SelectMethod == CourierSelectMethod.GetByCourierId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(Courier entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.CourierId == Guid.Empty )
				entity.CourierId = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Courier entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CourierProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					IsDeepLoaded = true;
				}
			}
		}

		#endregion Select Methods
	}
	
	#region CourierDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CourierDataSource class.
	/// </summary>
	public class CourierDataSourceDesigner : ProviderDataSourceDesigner<Courier, CourierKey>
	{
		/// <summary>
		/// Initializes a new instance of the CourierDataSourceDesigner class.
		/// </summary>
		public CourierDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourierSelectMethod SelectMethod
		{
			get { return ((CourierDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CourierDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CourierDataSourceActionList

	/// <summary>
	/// Supports the CourierDataSourceDesigner class.
	/// </summary>
	internal class CourierDataSourceActionList : DesignerActionList
	{
		private CourierDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CourierDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CourierDataSourceActionList(CourierDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourierSelectMethod SelectMethod
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

	#endregion CourierDataSourceActionList
	
	#endregion CourierDataSourceDesigner
	
	#region CourierSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CourierDataSource.SelectMethod property.
	/// </summary>
	public enum CourierSelectMethod
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
		/// Represents the GetByCourierId method.
		/// </summary>
		GetByCourierId
	}
	
	#endregion CourierSelectMethod

	#region CourierFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Courier"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourierFilter : SqlFilter<CourierColumn>
	{
	}
	
	#endregion CourierFilter
}

