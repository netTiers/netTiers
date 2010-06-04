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
	/// Represents the DataRepository.LocationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LocationDataSourceDesigner))]
	public class LocationDataSource : ProviderDataSource<Location, LocationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationDataSource class.
		/// </summary>
		public LocationDataSource() : base(new LocationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LocationDataSourceView used by the LocationDataSource.
		/// </summary>
		protected LocationDataSourceView LocationView
		{
			get { return ( View as LocationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LocationDataSource control invokes to retrieve data.
		/// </summary>
		public LocationSelectMethod SelectMethod
		{
			get
			{
				LocationSelectMethod selectMethod = LocationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LocationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LocationDataSourceView class that is to be
		/// used by the LocationDataSource.
		/// </summary>
		/// <returns>An instance of the LocationDataSourceView class.</returns>
		protected override BaseDataSourceView<Location, LocationKey> GetNewDataSourceView()
		{
			return new LocationDataSourceView(this, DefaultViewName);
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
	/// Supports the LocationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LocationDataSourceView : ProviderDataSourceView<Location, LocationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LocationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LocationDataSourceView(LocationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LocationDataSource LocationOwner
		{
			get { return Owner as LocationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LocationSelectMethod SelectMethod
		{
			get { return LocationOwner.SelectMethod; }
			set { LocationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LocationService LocationProvider
		{
			get { return Provider as LocationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Location> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Location> results = null;
			Location item;
			count = 0;
			
			System.String _name;
			System.Int16 _locationId;
			System.Int32 _productId;

			switch ( SelectMethod )
			{
				case LocationSelectMethod.Get:
					LocationKey entityKey  = new LocationKey();
					entityKey.Load(values);
					item = LocationProvider.Get(entityKey);
					results = new TList<Location>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LocationSelectMethod.GetAll:
                    results = LocationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LocationSelectMethod.GetPaged:
					results = LocationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LocationSelectMethod.Find:
					if ( FilterParameters != null )
						results = LocationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LocationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LocationSelectMethod.GetByLocationId:
					_locationId = ( values["LocationId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["LocationId"], typeof(System.Int16)) : (short)0;
					item = LocationProvider.GetByLocationId(_locationId);
					results = new TList<Location>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case LocationSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = LocationProvider.GetByName(_name);
					results = new TList<Location>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case LocationSelectMethod.GetByProductIdFromProductInventory:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = LocationProvider.GetByProductIdFromProductInventory(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LocationSelectMethod.Get || SelectMethod == LocationSelectMethod.GetByLocationId )
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
				Location entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LocationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Location> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LocationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LocationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LocationDataSource class.
	/// </summary>
	public class LocationDataSourceDesigner : ProviderDataSourceDesigner<Location, LocationKey>
	{
		/// <summary>
		/// Initializes a new instance of the LocationDataSourceDesigner class.
		/// </summary>
		public LocationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LocationSelectMethod SelectMethod
		{
			get { return ((LocationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LocationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LocationDataSourceActionList

	/// <summary>
	/// Supports the LocationDataSourceDesigner class.
	/// </summary>
	internal class LocationDataSourceActionList : DesignerActionList
	{
		private LocationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LocationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LocationDataSourceActionList(LocationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LocationSelectMethod SelectMethod
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

	#endregion LocationDataSourceActionList
	
	#endregion LocationDataSourceDesigner
	
	#region LocationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LocationDataSource.SelectMethod property.
	/// </summary>
	public enum LocationSelectMethod
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
		/// Represents the GetByName method.
		/// </summary>
		GetByName,
		/// <summary>
		/// Represents the GetByLocationId method.
		/// </summary>
		GetByLocationId,
		/// <summary>
		/// Represents the GetByProductIdFromProductInventory method.
		/// </summary>
		GetByProductIdFromProductInventory
	}
	
	#endregion LocationSelectMethod

	#region LocationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationFilter : SqlFilter<LocationColumn>
	{
	}
	
	#endregion LocationFilter

	#region LocationExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationExpressionBuilder : SqlExpressionBuilder<LocationColumn>
	{
	}
	
	#endregion LocationExpressionBuilder	

	#region LocationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LocationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationProperty : ChildEntityProperty<LocationChildEntityTypes>
	{
	}
	
	#endregion LocationProperty
}

