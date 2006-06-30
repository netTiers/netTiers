#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.Bases;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Represents a business object that provides data to data-bound
	/// controls in multi-tier Web application architectures.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the key
	/// property of the specified business object class.</typeparam>
	[CLSCompliant(true)]
	[ParseChildren(true), PersistChildren(false)]
	public abstract class BaseDataSource<Entity, EntityKey> : DataSourceControl
		where Entity : new()
		where EntityKey : new()
	{
		#region Declarations

		/// <summary>
		/// The name used for the associated DataSourceView class.
		/// </summary>
		public static readonly String DefaultViewName = "DefaultView";

		private BaseDataSourceView<Entity, EntityKey> _view;
		private ParameterCollection _parameters;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BaseDataSource class.
		/// </summary>
		public BaseDataSource()
		{
		}

		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a reference to the BaseDataSourceView used by the BaseDataSource.
		/// </summary>
		protected BaseDataSourceView<Entity, EntityKey> View
		{
			get
			{
				if ( _view == null )
				{
					_view = GetNewDataSourceView();
				}

				return _view;
			}
		}

		/// <summary>
		/// Gets the parameters collection that contains the parameters that
		/// are used by the BaseDataSource.SelectMethod method.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public ParameterCollection Parameters
		{
			get
			{
				if ( _parameters == null )
				{
					_parameters = new ParameterCollection();
					_parameters.ParametersChanged += new EventHandler(this.OnParametersChanged);

					if ( IsTrackingViewState )
					{
						( (IStateManager) _parameters ).TrackViewState();
					}
				}

				return _parameters;
			}
		}

		/// <summary>
		/// Gets a value indicating if any Parameter objects have been specified.
		/// </summary>
		internal bool HasParameters
		{
			get { return ( _parameters != null ); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// supports paging through the set of data that it retrieves.
		/// </summary>
		public bool EnablePaging
		{
			get { return View.EnablePaging; }
			set { View.EnablePaging = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// supports sorting the set of data that it retrieves.
		/// </summary>
		public bool EnableSorting
		{
			get { return View.EnableSorting; }
			set { View.EnableSorting = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// should access the EntityTransactionModule.TransactionManager property.
		/// </summary>
		/// <remarks>When this property is set to true, the EntityTransactionModule.TransactionManager
		/// object will be the first parameter passed to any data retrieval operation.</remarks>
		public bool EnableTransaction
		{
			get { return View.EnableTransaction; }
			set { View.EnableTransaction = value; }
		}

		/// <summary>
		/// Gets or sets a reference to an existing TransactionManager object
		/// to use when the EnableTransaction property is set to false.
		/// </summary>
		/// <remarks>When a value is supplied and EnableTransaction is set to false,
		/// the BaseDataSource.TransactionManager object will be the first
		/// parameter passed to any data retrieval operation.</remarks>
		[Browsable(false)]
		public TransactionManager TransactionManager
		{
			get { return View.TransactionManager; }
			set { View.TransactionManager = value; }
		}

		/// <summary>
		/// Gets or sets a filtering expression that is applied when the method that
		/// is specified by the SelectMethod property is called. This only applies
		/// if EnablePaging and EnableSorting are both false.
		/// </summary>
		public String Filter
		{
			get { return View.Filter; }
			set { View.Filter = value; }
		}

		/// <summary>
		/// Gets or sets a sorting expression that is applied when the method that
		/// is specified by the SelectMethod property is called. This only applies
		/// if EnablePaging and EnableSorting are both false.
		/// </summary>
		public String Sort
		{
			get { return View.Sort; }
			set { View.Sort = value; }
		}

		/// <summary>
		/// Gets or sets the value to be used as the whereClause parameter for
		/// any data retrieval operation.
		/// </summary>
		internal String WhereClause
		{
			get { return ((String) ViewState["WhereClause"]) ?? String.Empty; }
			set { ViewState["WhereClause"] = value; }
		}

		/// <summary>
		/// Gets or sets the value to be used as the orderBy parameter for
		/// any data retrieval operation.
		/// </summary>
		internal String OrderBy
		{
			get { return ((String) ViewState["OrderBy"]) ?? String.Empty; }
			set { ViewState["OrderBy"] = value; }
		}

		/// <summary>
		/// Gets or sets the value that represents the SortExpression argument that
		/// is supplied by DataBoundControls via a DataSourceSelectArguments object.
		/// </summary>
		internal String SortExpression
		{
			get { return ((String) ViewState["SortExpression"]) ?? String.Empty; }
			set { ViewState["SortExpression"] = value; }
		}

		/// <summary>
		/// Gets or sets the value that represents the StartRowIndex argument that
		/// is supplied by DataBoundControls via a DataSourceSelectArguments object.
		/// </summary>
		internal int StartIndex
		{
			get
			{
				Object value = ViewState["StartIndex"];
				return value != null ? (int) value : 0;
			}
			set { ViewState["StartIndex"] = value; }
		}

		/// <summary>
		/// Gets or sets the value that represents the MaximumRows argument that
		/// is supplied by DataBoundControls via a DataSourceSelectArguments object.
		/// </summary>
		internal int PageSize
		{
			get
			{
				Object value = ViewState["PageSize"];
				int intValue = 0;

				if ( value != null )
				{
					intValue = (int) value;
				}
				if ( intValue < 1 )
				{
					intValue = Int32.MaxValue;
				}

				return intValue;
			}
			set { ViewState["PageSize"] = value; }
		}

		/// <summary>
		/// Gets or sets the value of the unique identifer used when retreiving a single Entity object.
		/// </summary>
		[Browsable(false)]
		public EntityKey EntityId
		{
			get
			{
				Object value = ViewState["EntityId"];
				return value != null ? (EntityKey) value : default(EntityKey);
			}
			set { ViewState["EntityId"] = value; }
		}

		/// <summary>
		/// Gets or sets a comma-separated list of the entity's property names that
		/// will be initialized to the current system time during an insert operation.
		/// </summary>
		public String InsertDateTimeNames
		{
			get { return View.InsertDateTimeNames; }
			set { View.InsertDateTimeNames = value; }
		}

		/// <summary>
		/// Gets or sets a comma-separated list of the entity's property names that
		/// will be initialized to the current system time during an update operation.
		/// </summary>
		public String UpdateDateTimeNames
		{
			get { return View.UpdateDateTimeNames; }
			set { View.UpdateDateTimeNames = value; }
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Retrieves the data source view that is associated with the data source control.
		/// </summary>
		/// <param name="viewName">The name of the view to retrieve.</param>
		/// <returns>The BaseDataSourceView that is associated with the BaseDataSource.</returns>
		protected override DataSourceView GetView(string viewName)
		{
			return View;
		}

		/// <summary>
		/// Creates a new instance of the BaseDataSourceView class that is to be
		/// used by the BaseDataSource.
		/// </summary>
		/// <returns>An instance of the BaseDataSourceView class.</returns>
		/// <remarks>This method should be overridden by sub-classes who need to provide
		/// additional functionality through the use of a sub-classed BaseDataSourceView.</remarks>
		protected virtual BaseDataSourceView<Entity, EntityKey> GetNewDataSourceView()
		{
			return new BaseDataSourceView<Entity, EntityKey>(this, DefaultViewName);
		}

		/// <summary>
		/// Performs the ExecuteSelect operation using a default DataSourceSelectArguments object.
		/// </summary>
		/// <returns>A collection of Entity objects returned by the method specified
		/// by the SelectMethod property.</returns>
		public IList<Entity> Select()
		{
			DataSourceSelectArguments arguments = new DataSourceSelectArguments();
			return Select(arguments);
		}

		/// <summary>
		/// Performs the ExecuteSelect operation using the specified DataSourceSelectArguments object.
		/// </summary>
		/// <param name="arguments">A <see cref="DataSourceSelectArguments"/> object.</param>
		/// <returns>A collection of Entity objects returned by the method specified
		/// by the SelectMethod property.</returns>
		public IList<Entity> Select(DataSourceSelectArguments arguments)
		{
			return View.Select(arguments);
		}

		/// <summary>
		/// Performs the ExecuteInsert operation using the specified name/value pairs.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> object.</param>
		/// <returns>The number of rows successfully inserted.</returns>
		public int Insert(IDictionary values)
		{
			return View.Insert(values);
		}

		/// <summary>
		/// Performs the ExecuteUpdate operation on the specified Entity object
		/// using the supplied name/value pairs.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <param name="values">An <see cref="IDictionary"/> object.</param>
		/// <returns>The number of rows successfully updated.</returns>
		public int Update(Entity entity, IDictionary values)
		{
			return View.Update(entity, values);
		}

		/// <summary>
		/// Performs the ExecuteDelete operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>The number of rows successfully deleted.</returns>
		public int Delete(Entity entity)
		{
			return View.Delete(entity);
		}
		
		#endregion Methods

		#region Events

		/// <summary>
		/// Occurs before a select operation.
		/// </summary>
		public event ObjectDataSourceSelectingEventHandler Selecting
		{
			add { View.Selecting += value; }
			remove { View.Selecting -= value; }
		}

		/// <summary>
		/// Occurs when a select operation has completed.
		/// </summary>
		public event ObjectDataSourceStatusEventHandler Selected
		{
			add { View.Selected += value; }
			remove { View.Selected -= value; }
		}

		/// <summary>
		/// Occurs before an insert operation.
		/// </summary>
		public event ObjectDataSourceMethodEventHandler Inserting
		{
			add { View.Inserting += value; }
			remove { View.Inserting -= value; }
		}

		/// <summary>
		/// Occurs when an insert operation has completed.
		/// </summary>
		public event ObjectDataSourceStatusEventHandler Inserted
		{
			add { View.Inserted += value; }
			remove { View.Inserted -= value; }
		}

		/// <summary>
		/// Occurs before an update operation
		/// </summary>
		public event ObjectDataSourceMethodEventHandler Updating
		{
			add { View.Updating += value; }
			remove { View.Updating -= value; }
		}

		/// <summary>
		/// Occurs when an update operation has completed.
		/// </summary>
		public event ObjectDataSourceStatusEventHandler Updated
		{
			add { View.Updated += value; }
			remove { View.Updated -= value; }
		}

		/// <summary>
		/// Occurs before a delete operation.
		/// </summary>
		public event ObjectDataSourceMethodEventHandler Deleting
		{
			add { View.Deleting += value; }
			remove { View.Deleting -= value; }
		}

		/// <summary>
		/// Occurs when a delete operation has completed.
		/// </summary>
		public event ObjectDataSourceStatusEventHandler Deleted
		{
			add { View.Deleted += value; }
			remove { View.Deleted -= value; }
		}
		
		#endregion

		#region Caching
		
		/// <summary>
		/// Gets or sets a value indicating whether the
		/// DataSource control has data caching enabled.
		/// </summary>
		public bool EnableCaching
		{
			get { return View.EnableCaching; }
			set { View.EnableCaching = value; }
		}
		
		private int _cacheDuration = 30;
		
		/// <summary>
		/// The cache duration in minutes.
		/// </summary>
		public int CacheDuration
		{
			get { return this._cacheDuration; }
			set { this._cacheDuration = value; }
		}
		
		/// <summary>
		/// Returns an entry from the cache. Entries are stored partially based on the start and page value.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		internal CachedDataSource<Entity, EntityKey> GetDataFromCache(int start, int page)
		{
			// check for design time
			if ( DesignMode ) return null;

			Hashtable cachedData = (Hashtable) Context.Cache.Get(GetType().Name);
			CachedDataSource<Entity, EntityKey> data = null;
			string hashKey = CacheHashKey(start, page);

			if ( cachedData != null && cachedData.ContainsKey(hashKey) )
			{
				Context.Trace.Write(GetType().Name, "Getting Cached Data " + hashKey);
				data = cachedData[hashKey] as CachedDataSource<Entity, EntityKey>;
			}
			
			return data;
		}
		
		/// <summary>
		/// Saves an entry to the cache, partially based on start and page value
		/// </summary>
		/// <param name="data"></param>
		/// <param name="start"></param>
		/// <param name="page"></param>
		internal void SaveDataToCache(CachedDataSource<Entity, EntityKey> data, int start, int page)
		{
			// check for design time
			if ( DesignMode ) return;

			Context.Trace.Write(GetType().Name, "Saving Cache Data");
			Hashtable cacheData = (Hashtable) Context.Cache.Get(GetType().Name);
			string hashKey = CacheHashKey(start, page);
			
			if ( cacheData == null )
			{
				cacheData = CreateCacheEntry();
			}
			if ( !cacheData.ContainsKey(hashKey) )
			{
				Context.Trace.Write(GetType().Name, "Adding Data to Cache " + hashKey);
				cacheData.Add(hashKey, data);
			}
		}
		
		/// <summary>
		/// Initializes the dictionary used for caching by this control.
		/// </summary>
		private Hashtable CreateCacheEntry()
		{
			Hashtable cacheObject = new Hashtable();
			Context.Cache.Insert(GetType().Name, cacheObject, null, DateTime.Now.AddMinutes(CacheDuration), TimeSpan.Zero);
			return cacheObject;
		}
		
		/// <summary>
		/// Creates a cache hashing key based on the startIndex, pageSize.
		/// </summary>
		/// <param name="startIndex">The current start row index.</param>
		/// <param name="pageSize">The current page size.</param>
		/// <returns>A string that can be used as a key for caching purposes.</returns>
		/// <remarks>Currently abstract becuase using the enum name as part of the cache key.</remarks>
		protected abstract string CacheHashKey(int startIndex, int pageSize);
		
        #endregion

		#region Parameter Helper Methods

		/// <summary>
		/// Raises the System.Web.UI.Control.Init event.
		/// </summary>
		/// <param name="e">An System.EventArgs object that contains the event data.</param>
		protected override void OnInit(EventArgs e)
		{
			Page.LoadComplete += new EventHandler(this.OnPageLoadComplete);
		}

		/// <summary>
		/// Handles the Page.LoadComplete event.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An System.EventArgs object that contains the event data.</param>
		private void OnPageLoadComplete(object sender, EventArgs e)
		{
			if ( _parameters != null )
			{
				_parameters.UpdateValues(Context, this);
			}
		}

		/// <summary>
		/// Handles the ParameterCollection.ParametersChanged event.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An System.EventArgs object that contains the event data.</param>
		private void OnParametersChanged(object sender, EventArgs e)
		{
			View.RaiseChangedEvent();
		}

		/// <summary>
		/// Loads the previously saved view state of the BaseDataSource control.
		/// </summary>
		/// <param name="state">An object that contains the saved view state values for the control.</param>
		protected override void LoadViewState(object state)
		{
			object baseState = null;

			if ( state != null )
			{
				Pair p = (Pair) state;
				baseState = p.First;

				if ( p.Second != null )
				{
					( (IStateManager) Parameters ).LoadViewState(p.Second);
				}
			}

			base.LoadViewState(baseState);
		}

		/// <summary>
		/// Saves the state of the BaseDataSource control.
		/// </summary>
		/// <returns>Returns the server control's current view state; otherwise,
		/// null, if there is no view state associated with the control.</returns>
		protected override object SaveViewState()
		{
			object baseState = base.SaveViewState();
			object parameterState = null;

			if ( _parameters != null )
			{
				parameterState = ( (IStateManager) _parameters ).SaveViewState();
			}

			if ( ( baseState != null ) || ( parameterState != null ) )
			{
				return new Pair(baseState, parameterState);
			}

			return null;
		}

		/// <summary>
		/// Tracks view-state changes to the BaseDataSource control so
		/// that they can be stored in the System.Web.UI.StateBag object.
		/// </summary>
		protected override void TrackViewState()
		{
			base.TrackViewState();
			if ( _parameters != null )
			{
				( (IStateManager) _parameters ).TrackViewState();
			}
		}

		/// <summary>
		/// Gets a collection of values supplied by the current Parameter objects.
		/// </summary>
		/// <returns>An IOrderedDictionary of name/value pairs.</returns>
		internal IOrderedDictionary GetParameterValues()
		{
			IOrderedDictionary values = null;

			if ( HasParameters )
			{
				values = Parameters.GetValues(Context, this);
			}
			else
			{
				values = new OrderedDictionary(0);
			}

			return values;
		}

		#endregion Parameter Helper Methods

		#region ILinkedDataSource Members

		#region Methods

		/// <summary>
		/// Performs the ExecuteUpdate operation on the specified Entity object
		/// using the supplied name/value pairs.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <param name="values">An <see cref="IDictionary"/> object.</param>
		/// <returns>The number of rows successfully updated.</returns>
		public int Update(Object entity, IDictionary values)
		{
			return Update((Entity) entity, values);
		}

		/// <summary>
		/// Performs the ExecuteDelete operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>The number of rows successfully deleted.</returns>
		public int Delete(Object entity)
		{
			return Delete((Entity) entity);
		}

		/// <summary>
		/// Gets a reference to the current list of entities.
		/// </summary>
		/// <returns>The current list of entities if present, otherwise
		/// the data will be retreived by the Provider and cached for future use.</returns>
		public IEnumerable GetEntityList()
		{
			return Select();
		}

		/// <summary>
		/// Gets a specific entry from the cached list of entities
		/// based on the value of the EntityIndex property.
		/// </summary>
		/// <returns>The current business object.</returns>
		public Object GetCurrentEntity()
		{
			return View.GetCurrentEntity();
		}

		/// <summary>
		/// Gets a comma-separated-list of values representing the
		/// current entity's unique identifier.
		/// </summary>
		/// <returns>Returns a comma-separated-list of values.</returns>
		public String GetSelectedEntityId()
		{
			return View.GetSelectedEntityId();
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		public void DeepLoad()
		{
			View.DeepLoad();
		}

		#endregion Methods

		#region Events

		/// <summary>
		/// Occurs when a select operation has completed.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterSelected
		{
			add { View.AfterSelected += value; }
			remove { View.AfterSelected -= value; }
		}

		/// <summary>
		/// Occurs before an insert operation.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterInserting
		{
			add { View.AfterInserting += value; }
			remove { View.AfterInserting -= value; }
		}

		/// <summary>
		/// Occurs when an insert operation has completed.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterInserted
		{
			add { View.AfterInserted += value; }
			remove { View.AfterInserted -= value; }
		}

		/// <summary>
		/// Occurs before an update operation.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterUpdating
		{
			add { View.AfterUpdating += value; }
			remove { View.AfterUpdating -= value; }
		}

		/// <summary>
		/// Occurs when an update operation has completed.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterUpdated
		{
			add { View.AfterUpdated += value; }
			remove { View.AfterUpdated -= value; }
		}

		#endregion Events

		#endregion ILinkedDataSource Members
	}

	/// <summary>
	/// Supports the BaseDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the EntityId
	/// property of the specified business object class.</typeparam>
	public class BaseDataSourceView<Entity, EntityKey> : DataSourceView
		where Entity : new()
		where EntityKey : new()
	{
		#region Declarations

		private BaseDataSource<Entity, EntityKey> _owner;
		private TransactionManager _transactionManager;
		private IList<Entity> _prevTempList;
		private IList<Entity> _tempList;
		private EntityKey _prevEntityId;
		private int _prevRowCount;
		private int _totalRowCount;

		private String _filter;
		private String _sort;
		private String _insertDateTimeNames;
		private String _updateDateTimeNames;
		
		private bool _enableTransaction = true;
		private bool _enableCaching;
		private bool _enablePaging;
		private bool _enableSorting;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BaseDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BaseDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BaseDataSourceView(BaseDataSource<Entity, EntityKey> owner, String viewName)
			: base(owner, viewName)
		{
			_owner = owner;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets a reference to the associated BaseDataSource object.
		/// </summary>
		internal BaseDataSource<Entity, EntityKey> Owner
		{
			get { return _owner; }
		}

		/// <summary>
		/// Gets or sets a reference to an existing TransactionManager object
		/// to use when the EnableTransaction property is set to false.
		/// </summary>
		/// <remarks>When a value is supplied and EnableTransaction is set to false,
		/// the BaseDataSource.TransactionManager object will be the first
		/// parameter passed to any data retrieval operation.</remarks>
		internal TransactionManager TransactionManager
		{
			get { return _transactionManager; }
			set { _transactionManager = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the
		/// data source control has data caching enabled.
		/// </summary>
		internal bool EnableCaching
		{
			get { return _enableCaching; }
			set { _enableCaching = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// supports paging through the set of data that it retrieves.
		/// </summary>
		internal bool EnablePaging
		{
			get { return _enablePaging; }
			set { _enablePaging = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// supports sorting the set of data that it retrieves.
		/// </summary>
		internal bool EnableSorting
		{
			get { return _enableSorting; }
			set { _enableSorting = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// should access the EntityTransactionModule.TransactionManager property.
		/// </summary>
		/// <remarks>When this property is set to true, the EntityTransactionModule.TransactionManager
		/// object will be the first parameter passed to any data retrieval operation.</remarks>
		internal bool EnableTransaction
		{
			get { return _enableTransaction; }
			set { _enableTransaction = value; }
		}

		/// <summary>
		/// Gets or sets the value of the unique identifer used when retreiving a single Entity object.
		/// </summary>
		internal EntityKey EntityId
		{
			get { return _owner.EntityId; }
			set { _owner.EntityId = value; }
		}

		/// <summary>
		/// Gets or sets a comma-separated list of the entity's property names that
		/// will be initialized to the current system time during an insert operation.
		/// </summary>
		internal String InsertDateTimeNames
		{
			get { return _insertDateTimeNames; }
			set { _insertDateTimeNames = value; }
		}

		/// <summary>
		/// Gets or sets a comma-separated list of the entity's property names that
		/// will be initialized to the current system time during an update operation.
		/// </summary>
		internal String UpdateDateTimeNames
		{
			get { return _updateDateTimeNames; }
			set { _updateDateTimeNames = value; }
		}

		/// <summary>
		/// Gets or sets a filtering expression that is applied when the method that
		/// is specified by the SelectMethod property is called. This only applies
		/// if EnablePaging and EnableSorting are both false.
		/// </summary>
		internal String Filter
		{
			get { return _filter; }
			set { _filter = value; }
		}

		/// <summary>
		/// Gets or sets a sorting expression that is applied when the method that
		/// is specified by the SelectMethod property is called. This only applies
		/// if EnablePaging and EnableSorting are both false.
		/// </summary>
		internal String Sort
		{
			get { return _sort; }
			set { _sort = value; }
		}

		/// <summary>
		/// Gets or sets the value to be used as the whereClause parameter for
		/// any data retrieval operation.
		/// </summary>
		internal String WhereClause
		{
			get { return _owner.WhereClause; }
			set { _owner.WhereClause = value; }
		}

		/// <summary>
		/// Gets or sets the value to be used as the orderBy parameter for
		/// any data retrieval operation.
		/// </summary>
		internal String OrderBy
		{
			get { return _owner.OrderBy; }
			set { _owner.OrderBy = value; }
		}

		/// <summary>
		/// Gets or sets the value that represents the SortExpression argument that
		/// is supplied by DataBoundControls via a DataSourceSelectArguments object.
		/// </summary>
		internal String SortExpression
		{
			get { return _owner.SortExpression; }
			set { _owner.SortExpression = value; }
		}

		/// <summary>
		/// Gets or sets the value that represents the StartRowIndex argument that
		/// is supplied by DataBoundControls via a DataSourceSelectArguments object.
		/// </summary>
		internal int StartIndex
		{
			get { return _owner.StartIndex; }
			set { _owner.StartIndex = value; }
		}

		/// <summary>
		/// Gets or sets the value that represents the MaximumRows argument that
		/// is supplied by DataBoundControls via a DataSourceSelectArguments object.
		/// </summary>
		internal int PageSize
		{
			get { return _owner.PageSize; }
			set { _owner.PageSize = value; }
		}

		/// <summary>
		/// Gets or sets the value indicating the current PageIndex as
		/// determined by the following equation: StartIndex/PageSize
		/// </summary>
		internal int PageIndex
		{
			get { return ( StartIndex / PageSize ); }
			set { StartIndex = ( value * PageSize ); }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object
		/// associated with the current BaseDataSource object supports the
		/// ExecuteInsert(IDictionary) operation.
		/// </summary>
		public override bool CanInsert
		{
			get { return true; }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object
		/// associated with the current BaseDataSource object supports the
		/// ExecuteUpdate(IDictionary, IDictionary, IDictionary) operation.
		/// </summary>
		public override bool CanUpdate
		{
			get { return true; }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object
		/// associated with the current BaseDataSource object supports the
		/// ExecuteDelete(IDictionary, IDictionary) operation.
		/// </summary>
		public override bool CanDelete
		{
			get { return true; }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object associated
		/// with the current BaseDataSource object supports paging through the data
		/// retrieved by the ExecuteSelect(DataSourceSelectArguments) method.
		/// </summary>
		public override bool CanPage
		{
			get { return true; }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object
		/// associated with the current BaseDataSource object supports a
		/// sorted view on the underlying data source.
		/// </summary>
		public override bool CanSort
		{
			get { return true; }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object
		/// associated with the current BaseDataSource object supports
		/// retrieving the total number of data rows, instead of the data.
		/// </summary>
		public override bool CanRetrieveTotalRowCount
		{
			get { return true; }
		}

		#endregion Properties

		#region Select Methods

		/// <summary>
		/// Gets a list of data from the underlying data storage.
		/// </summary>
		/// <param name="arguments">A System.Web.UI.DataSourceSelectArguments that
		/// is used to request operations on the data beyond basic data retrieval.</param>
		/// <returns>A collection of Entity objects from the underlying data storage.</returns>
		internal IList<Entity> Select(DataSourceSelectArguments arguments)
		{
			return ExecuteSelectCore(arguments);
		}

		/// <summary>
		/// Gets a list of data from the underlying data storage.
		/// </summary>
		/// <param name="arguments">A System.Web.UI.DataSourceSelectArguments that
		/// is used to request operations on the data beyond basic data retrieval.</param>
		/// <returns>An System.Collections.IEnumerable list of data from the underlying data storage.</returns>
		protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
		{
			return ExecuteSelectCore(arguments);
		}

		/// <summary>
		/// Gets a list of data from the underlying data storage.
		/// </summary>
		/// <param name="arguments">A System.Web.UI.DataSourceSelectArguments that
		/// is used to request operations on the data beyond basic data retrieval.</param>
		/// <returns>A collection of Entity objects from the underlying data storage.</returns>
		private IList<Entity> ExecuteSelectCore(DataSourceSelectArguments arguments)
		{
			arguments.RaiseUnsupportedCapabilitiesError(this);

			IOrderedDictionary values = GetParameterValues();
			IList<Entity> entityList = null;

			ObjectDataSourceSelectingEventArgs methodArgs = new ObjectDataSourceSelectingEventArgs(values, arguments, true);
			OnSelecting(methodArgs);

			if ( methodArgs.Cancel )
			{
				return null;
			}

			try
			{
				entityList = GetEntityList(arguments, values);
				EntityId = default(EntityKey);

				ObjectDataSourceStatusEventArgs statusArgs = new ObjectDataSourceStatusEventArgs(entityList, values);
				statusArgs.AffectedRows = arguments.TotalRowCount;
				OnSelected(statusArgs);

				if ( arguments.TotalRowCount > 0 )
				{
					Entity entity = entityList[0];
					EntityId = GetEntityId(entity);

					// raise linked event
					OnAfterSelected(new LinkedDataSourceEventArgs(entity, 0));
				}
			}
			catch ( Exception ex )
			{
				ObjectDataSourceStatusEventArgs statusArgs = new ObjectDataSourceStatusEventArgs(entityList, values, ex);
				OnSelected(statusArgs);

				if ( !statusArgs.ExceptionHandled )
				{
					throw;
				}
			}

			return entityList;
		}

		/// <summary>
		/// Gets a collection of Entity objects.  Provides internal caching of values
		/// specified in the supplied DataSourceSelectArguments object.
		/// </summary>
		/// <param name="arguments">A System.Web.UI.DataSourceSelectArguments that
		/// is used to request operations on the data beyond basic data retrieval.</param>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		/// <returns>A collection of Entity objects from the underlying data storage.</returns>
		private IList<Entity> GetEntityList(DataSourceSelectArguments arguments, IDictionary values)
		{
			StartIndex = arguments.StartRowIndex;
			PageSize = arguments.MaximumRows;
			SortExpression = arguments.SortExpression;
			
			if ( !String.IsNullOrEmpty(SortExpression) )
			{
				OrderBy = SortExpression;
			}
			
			// allow case-insensitive parameter names
			values = CollectionsUtil.CreateCaseInsensitiveHashtable(values);
			
			// known parameters
			WhereClause = (String) values["WhereClause"];

			if ( values["OrderBy"] != null )
			{
				OrderBy = (String) values["OrderBy"];
			}
			if ( values["PageIndex"] != null )
			{
				PageIndex = (int) values["PageIndex"];
			}
			if ( values["PageSize"] != null )
			{
				PageSize = (int) values["PageSize"];
			}

			GetSelectParameters(values);

			int count = 0;
			IList<Entity> entityList = GetCachedData(out count);
			arguments.TotalRowCount = count;
			return entityList;
		}

		/// <summary>
		/// Gets a collection of previously selected Entity objects.
		/// </summary>
		/// <returns>A collection of Entity objects from the underlying data storage.</returns>
		private IList<Entity> GetEntityList()
		{
			int count = 0;
			return GetCachedData(out count);
		}

		/// <summary>
		/// Gets a collection of previously selected Entity objects.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects from the underlying data storage.</returns>
		private IList<Entity> GetCachedData(out int count)
		{
			// check temporary cache first
			IList<Entity> entityList = _tempList;
			count = _totalRowCount;

			if ( entityList == null )
			{
				if ( EnableCaching )
				{
					//get cached datasource
					CachedDataSource<Entity, EntityKey> data = Owner.GetDataFromCache(StartIndex, PageSize);
					//if there is cached data use it and the record count returned and
					if (data != null)
					{
						count = data.VirtualRecordCount;
						entityList = data.Data;
					}   
				}
				if ( entityList == null )
				{
					entityList = GetSelectData(out count);

					// make sure paging and sorting were not enabled
					if ( entityList is ListBase<Entity> && !EnablePaging && !EnableSorting )
					{
						// apply filter
						if ( !String.IsNullOrEmpty(Filter) )
						{
							((ListBase<Entity>) entityList).Filter = Filter;
						}
						// apply sort
						if ( !String.IsNullOrEmpty(Sort) )
						{
							((ListBase<Entity>) entityList).Sort(Sort);
						}
					}

					if ( EnableCaching )
					{
						Owner.SaveDataToCache(new CachedDataSource<Entity,EntityKey>(entityList, count), StartIndex, PageSize);
					}
				}

				// place in temporary cache
				_tempList = entityList;
				_totalRowCount = count;

				// TODO: how do we invalidate the cache before time expires?
			}

			return entityList;
		}

		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		/// <remarks>This method can be overridden by sub-classes needing to provide
		/// additional data retrieval functionality.</remarks>
		protected virtual IList<Entity> GetSelectData(out int count)
		{
			count = 0;
			return null;
		}

		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		/// <remarks>This method can be overridden by sub-classes needing to provide
		/// additional data retrieval functionality.</remarks>
		protected virtual void GetSelectParameters(IDictionary values)
		{
		}

		#endregion Select Methods

		#region Insert Methods

		/// <summary>
		/// Performs an insert operation.
		/// </summary>
		/// <param name="values">A System.Collections.IDictionary of
		/// name/value pairs used during an insert operation.</param>
		/// <returns>The number of items that were inserted into the underlying data storage.</returns>
		internal int Insert(IDictionary values)
		{
			int count = 0;

			if ( values != null )
			{
				SetPreviousValues();

				count = ExecuteInsert(values);

				ResetPreviousValues();
			}

			return count;
		}

		/// <summary>
		/// Performs an insert operation on the list of data
		/// that the BaseDataSourceView object represents.
		/// </summary>
		/// <param name="values">A System.Collections.IDictionary of
		/// name/value pairs used during an insert operation.</param>
		/// <returns>The number of items that were inserted into the underlying data storage.</returns>
		protected override int ExecuteInsert(IDictionary values)
		{
			values = GetOrderedDictionary(values);
			ObjectDataSourceMethodEventArgs methodArgs = new ObjectDataSourceMethodEventArgs(values as IOrderedDictionary);
			OnInserting(methodArgs);

			if ( methodArgs.Cancel )
			{
				return 0;
			}

			// get new entity
			Entity entity = new Entity();
			int count = 0;

			// raise linked event
			OnAfterInserting(new LinkedDataSourceEventArgs(entity, 0));

			// set date/time values
			String[] names = GetInsertDateTimeNames();
			EntityUtil.InitEntityDateTimeValues(entity, names);
			// set property values
			SetPropertyValues(entity, values);

			try
			{
				// insert entity
				if ( ExecuteInsert(entity) )
				{
					ObjectDataSourceStatusEventArgs statusArgs = new ObjectDataSourceStatusEventArgs(entity, values);
					statusArgs.AffectedRows = 1;
					EntityId = GetEntityId(entity);
					count = 1;

					OnInserted(statusArgs);
					OnAfterInserted(new LinkedDataSourceEventArgs(entity, 0));
					RaiseChangedEvent();
				}
			}
			catch ( Exception ex )
			{
				ObjectDataSourceStatusEventArgs statusArgs = new ObjectDataSourceStatusEventArgs(entity, values, ex);
				OnInserted(statusArgs);

				if ( !statusArgs.ExceptionHandled )
				{
					throw;
				}
			}

			return count;
		}

		/// <summary>
		/// Performs an insert operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		/// <remarks>Sub-classes should implement this method to provide specific insert functionality.</remarks>
		protected virtual bool ExecuteInsert(Entity entity)
		{
			return false;
		}

		#endregion Insert Methods

		#region Update Methods

		/// <summary>
		/// Performs an update operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <param name="values">An System.Collections.IDictionary of name/value
		/// pairs that represent data elements and their new values.</param>
		/// <returns>The number of items that were updated in the underlying data storage.</returns>
		internal int Update(Entity entity, IDictionary values)
		{
			int count = 0;

			if ( entity != null && values != null )
			{
				SetPreviousValues();

				// set temporary reference
				SetTempCache(entity);

				// perform delete operation
				count = ExecuteUpdate(null, values, null);

				ResetPreviousValues();
			}

			return count;
		}

		/// <summary>
		/// Performs an update operation on the list of data
		/// that the BaseDataSourceView object represents.
		/// </summary>
		/// <param name="keys">An System.Collections.IDictionary of object or
		/// row keys to be updated by the update operation.</param>
		/// <param name="values">An System.Collections.IDictionary of name/value
		/// pairs that represent data elements and their new values.</param>
		/// <param name="oldValues">An System.Collections.IDictionary of name/value
		/// pairs that represent data elements and their original values.</param>
		/// <returns>The number of items that were updated in the underlying data storage.</returns>
		protected override int ExecuteUpdate(IDictionary keys, IDictionary values, IDictionary oldValues)
		{
			values = GetOrderedDictionary(values);
			ObjectDataSourceMethodEventArgs methodArgs = new ObjectDataSourceMethodEventArgs(values as IOrderedDictionary);
			OnUpdating(methodArgs);

			if ( methodArgs.Cancel )
			{
				return 0;
			}

			IList<Entity> entityList = GetEntityList();
			Entity entity = GetCurrentEntity(entityList, keys);
			int count = 0;

			ValidateEntity(entity);

			// raise linked event
			int entityIndex = entityList.IndexOf(entity);
			OnAfterUpdating(new LinkedDataSourceEventArgs(entity, entityIndex));

			// set date/time values
			String[] names = GetUpdateDateTimeNames();
			EntityUtil.InitEntityDateTimeValues(entity, names);
			// set property values
			SetPropertyValues(entity, values);

			// update entity
			try
			{
				if ( ExecuteUpdate(entity) )
				{
					ObjectDataSourceStatusEventArgs statusArgs = new ObjectDataSourceStatusEventArgs(entity, values);
					statusArgs.AffectedRows = 1;
					EntityId = GetEntityId(entity);
					count = 1;

					OnUpdated(statusArgs);
					OnAfterUpdated(new LinkedDataSourceEventArgs(entity, entityIndex));
					RaiseChangedEvent();
				}
			}
			catch ( Exception ex )
			{
				ObjectDataSourceStatusEventArgs statusArgs = new ObjectDataSourceStatusEventArgs(entity, values, ex);
				OnUpdated(statusArgs);

				if ( !statusArgs.ExceptionHandled )
				{
					throw;
				}
			}

			return count;
		}

		/// <summary>
		/// Performs an update operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		/// <remarks>Sub-classes should implement this method to provide specific update functionality.</remarks>
		protected virtual bool ExecuteUpdate(Entity entity)
		{
			return false;
		}

		#endregion UpdateMethods

		#region Delete Methods

		/// <summary>
		/// Performs a delete operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>The number of items that were deleted from the underlying data storage.</returns>
		internal int Delete(Entity entity)
		{
			int count = 0;

			if ( entity != null )
			{
				SetPreviousValues();

				// set temporary reference
				SetTempCache(entity);

				// perform delete operation
				count = ExecuteDelete(null, new Hashtable());

				ResetPreviousValues();
			}

			return count;
		}

		/// <summary>
		/// Performs a delete operation on the list of data
		/// that the BaseDataSourceView object represents.
		/// </summary>
		/// <param name="keys">A System.Collections.IDictionary of object or
		/// row keys to be deleted by the ExecuteDelete operation.</param>
		/// <param name="oldValues">An System.Collections.IDictionary of name/value
		/// pairs that represent data elements and their original values.</param>
		/// <returns>The number of items that were deleted from the underlying data storage.</returns>
		protected override int ExecuteDelete(IDictionary keys, IDictionary oldValues)
		{
			oldValues = GetOrderedDictionary(oldValues);
			ObjectDataSourceMethodEventArgs methodArgs = new ObjectDataSourceMethodEventArgs(oldValues as IOrderedDictionary);
			OnDeleting(methodArgs);

			if ( methodArgs.Cancel )
			{
				return 0;
			}

			IList<Entity> entityList = GetEntityList();
			Entity entity = GetCurrentEntity(entityList, keys);
			int count = 0;

			ValidateEntity(entity);

			// delete entity
			try
			{
				if ( ExecuteDelete(entity) )
				{
					ObjectDataSourceStatusEventArgs statusArgs = new ObjectDataSourceStatusEventArgs(entity, oldValues);
					statusArgs.AffectedRows = 1;
					count = 1;
					
					OnDeleted(statusArgs);
					RaiseChangedEvent();
				}
			}
			catch ( Exception ex )
			{
				ObjectDataSourceStatusEventArgs statusArgs = new ObjectDataSourceStatusEventArgs(entity, oldValues, ex);
				OnDeleted(statusArgs);

				if ( !statusArgs.ExceptionHandled )
				{
					throw;
				}
			}

			return count;
		}

		/// <summary>
		/// Performs a delete operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		/// <remarks>Sub-classes should implement this method to provide specific delete functionality.</remarks>
		protected virtual bool ExecuteDelete(Entity entity)
		{
			return false;
		}

		#endregion Delete Methods

		#region ILinkedDataSource Members
		
		#region Methods

		/// <summary>
		/// Gets a specific entry from the cached list of entities
		/// based on the value of the EntityIndex property.
		/// </summary>
		/// <returns>The current business object.</returns>
		internal Entity GetCurrentEntity()
		{
			return GetCurrentEntity(Owner.Select(), EntityId);
		}

		/// <summary>
		/// Gets a comma-separated-list of values representing the
		/// current entity's unique identifier.
		/// </summary>
		/// <returns>Returns a comma-separated-list of values.</returns>
		internal virtual String GetSelectedEntityId()
		{
			IEntityKey key = EntityId as IEntityKey;
			StringBuilder id = new StringBuilder();
			IDictionary values = null;
			String value;

			if ( key != null )
			{
				values = key.ToDictionary();
			}
			else
			{
				values = EntityId as IDictionary;
			}

			if ( values != null )
			{
				foreach ( DictionaryEntry entry in values )
				{
					if ( id.Length > 0 ) id.Append("&");
					value = String.Format("{0}", entry.Value);
					id.AppendFormat("{0}={1}", entry.Key, HttpContext.Current.Server.UrlEncode(value));
				}
			}
			else
			{
				id.AppendFormat("{0}", EntityId);
			}

			return id.ToString();
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal void DeepLoad()
		{
			// TODO:
			//Provider.DeepLoad();
		}

		#endregion Methods

		#region Events

		/// <summary>
		/// Occurs when a select operation has completed.
		/// </summary>
		internal event LinkedDataSourceEventHandler AfterSelected;

		/// <summary>
		/// Occurs before an insert operation.
		/// </summary>
		internal event LinkedDataSourceEventHandler AfterInserting;

		/// <summary>
		/// Occurs when an insert operation has completed.
		/// </summary>
		internal event LinkedDataSourceEventHandler AfterInserted;

		/// <summary>
		/// Occurs before an update operation.
		/// </summary>
		internal event LinkedDataSourceEventHandler AfterUpdating;

		/// <summary>
		/// Occurs when an update operation has completed.
		/// </summary>
		internal event LinkedDataSourceEventHandler AfterUpdated;

		/// <summary>
		/// Raises the AfterSelected event.
		/// </summary>
		/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
		internal void OnAfterSelected(LinkedDataSourceEventArgs e)
		{
			if ( AfterSelected != null )
			{
				AfterSelected(this, e);
			}
		}

		/// <summary>
		/// Raises the AfterInserting event.
		/// </summary>
		/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
		internal void OnAfterInserting(LinkedDataSourceEventArgs e)
		{
			if ( AfterInserting != null )
			{
				AfterInserting(this, e);
			}
		}

		/// <summary>
		/// Raises the AfterInserted event.
		/// </summary>
		/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
		internal void OnAfterInserted(LinkedDataSourceEventArgs e)
		{
			if ( AfterInserted != null )
			{
				AfterInserted(this, e);
			}
		}

		/// <summary>
		/// Raises the AfterUpdating event.
		/// </summary>
		/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
		internal void OnAfterUpdating(LinkedDataSourceEventArgs e)
		{
			if ( AfterUpdating != null )
			{
				AfterUpdating(this, e);
			}
		}

		/// <summary>
		/// Raises the AfterUpdated event.
		/// </summary>
		/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
		internal void OnAfterUpdated(LinkedDataSourceEventArgs e)
		{
			if ( AfterUpdated != null )
			{
				AfterUpdated(this, e);
			}
		}

		#endregion Events

		#endregion ILinkedDataSource Members

		#region Helper Methods

		/// <summary>
		/// Gets the unique identifier of the specified entity object.
		/// </summary>
		/// <param name="entity">The current business object.</param>
		/// <returns>Returns the unique identifier for the specified entity.</returns>
		protected virtual EntityKey GetEntityId(Entity entity)
		{
			return default(EntityKey);
		}

		/// <summary>
		/// Create an instance of the EntityKey class based on the values
		/// contained within the specified IDictionary object.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		/// <returns>An EntityKey object representing the key property.</returns>
		protected virtual EntityKey GetEntityKey(IDictionary values)
		{
			EntityKey key = new EntityKey();
			IEntityKey entityKey = key as IEntityKey;

			if ( entityKey != null )
			{
				entityKey.Load(values);
			}

			return key;
		}

		/// <summary>
		/// Gets the Entity object within the collection of Entity objects that matches
		/// the values found in the specified IDictionary object.
		/// </summary>
		/// <param name="entityList">A collection of Entity objects.</param>
		/// <param name="keys">An IDictionary of name/value pairs representing a unique identifier.</param>
		/// <returns>The Entity object that matches the supplied unique identifier.</returns>
		protected virtual Entity GetCurrentEntity(IList<Entity> entityList, IDictionary keys)
		{
			// special processing when keys parameter is null
			if ( keys == null && entityList.Count == 1 )
			{
				return entityList[0];
			}

			EntityKey entityKey = GetEntityKey(keys);
			return GetCurrentEntity(entityList, entityKey);
		}

		/// <summary>
		/// Gets the Entity object within the collection of Entity objects that matches
		/// the values found in the specified EntityKey object.
		/// </summary>
		/// <param name="entityList">A collection of Entity objects.</param>
		/// <param name="entityKey">An <see cref="T:EntityKey"/> object.</param>
		/// <returns></returns>
		protected virtual Entity GetCurrentEntity(IList<Entity> entityList, EntityKey entityKey)
		{
			return default(Entity);
		}

		/// <summary>
		/// Validates the specified Entity object to ensure that is is not null.
		/// </summary>
		/// <param name="entity">The Entity object to validate.</param>
		protected virtual void ValidateEntity(Entity entity)
		{
			if ( entity == null )
			{
				throw new NullReferenceException("entity cannot be null");
			}
		}

		/// <summary>
		/// Sets the properties of the specified Entity object based on the
		/// name/value pairs found in the specified IDictionary object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <param name="values">An IDictionary of name/value pairs.</param>
		protected virtual void SetPropertyValues(Entity entity, IDictionary values)
		{
			EntityUtil.SetEntityValues(entity, values);
		}

		/// <summary>
		/// Gets an array of valid DateTime property names to
		/// initialize during an insert operation.
		/// </summary>
		/// <returns>Returns an array of property names.</returns>
		internal String[] GetInsertDateTimeNames()
		{
			return GetNames(InsertDateTimeNames);
		}

		/// <summary>
		/// Gets an array of valid DateTime property names to
		/// initialize during an update operation.
		/// </summary>
		/// <returns>Returns an array of property names.</returns>
		internal String[] GetUpdateDateTimeNames()
		{
			return GetNames(UpdateDateTimeNames);
		}

		/// <summary>
		/// Converts the specified comma-separated list of property names
		/// into a valid string array.
		/// </summary>
		/// <param name="value">A comma-separated list of property names.</param>
		/// <returns>Returns an array of property names.</returns>
		internal String[] GetNames(String value)
		{
			String[] names = new String[0];

			if ( !String.IsNullOrEmpty(value) )
			{
				names = value.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
				for ( int i = 0; i < names.Length; i++ )
				{
					names[i] = names[i].Trim();
				}
			}

			return names;
		}

		/// <summary>
		/// Gets a collection of values supplied by the current Parameter objects.
		/// </summary>
		/// <returns>An IOrderedDictionary of name/value pairs.</returns>
		protected virtual IOrderedDictionary GetParameterValues()
		{
			return _owner.GetParameterValues();
		}

		/// <summary>
		/// Gets an instance of the IOrderedDictionary class for the values
		/// found in the specified IDictionary object.
		/// </summary>
		/// <param name="values">An IDictionary of name/value pairs.</param>
		/// <returns>An IOrderedDictionary of name/value pairs.</returns>
		protected IOrderedDictionary GetOrderedDictionary(IDictionary values)
		{
			IOrderedDictionary ordered = values as IOrderedDictionary;

			if ( ordered == null )
			{
				ordered = new OrderedDictionary();

				foreach ( DictionaryEntry entry in values )
				{
					ordered.Add(entry.Key, entry.Value);
				}
			}

			return ordered;
		}

		/// <summary>
		/// Gets a reference to a TransactionManager object to use as the first
		/// parameter that is passed to any data retrieval operation.
		/// </summary>
		/// <returns>A <see cref="TransactionManager"/> object, or null.</returns>
		protected virtual TransactionManager GetTransactionManager()
		{
			return EnableTransaction ? EntityTransactionModule.TransactionManager : TransactionManager;
		}

		/// <summary>
		/// Stores the specified entity list in the temporary cache.
		/// </summary>
		/// <param name="entity">The Entity object to cache.</param>
		/// <param name="entityList">The list of Entity objects to cache.</param>
		protected virtual void SetTempCache(Entity entity, out IList<Entity> entityList)
		{
			entityList = null;
		}

		/// <summary>
		/// Stores the specified entity in the temporary cache.
		/// </summary>
		/// <param name="entity">The Entity object to cache.</param>
		private void SetTempCache(Entity entity)
		{
			SetTempCache(entity, out _tempList);
		}

		/// <summary>
		/// Stores current temporary cache values.
		/// </summary>
		private void SetPreviousValues()
		{
			_prevRowCount = _totalRowCount;
			_prevTempList = _tempList;
			_prevEntityId = EntityId;
		}

		/// <summary>
		/// Restores temporary cache to previous values.
		/// </summary>
		private void ResetPreviousValues()
		{
			_tempList = _prevTempList;
			_totalRowCount = _prevRowCount;
			EntityId = _prevEntityId;
		}

		#endregion Helper Methods

		#region Events

		/// <summary>
		/// Occurs before a select operation.
		/// </summary>
		public event ObjectDataSourceSelectingEventHandler Selecting;

		/// <summary>
		/// Occurs when a select operation has completed.
		/// </summary>
		public event ObjectDataSourceStatusEventHandler Selected;

		/// <summary>
		/// Occurs before an insert operation.
		/// </summary>
		public event ObjectDataSourceMethodEventHandler Inserting;

		/// <summary>
		/// Occurs when an insert operation has completed.
		/// </summary>
		public event ObjectDataSourceStatusEventHandler Inserted;

		/// <summary>
		/// Occurs before an update operation
		/// </summary>
		public event ObjectDataSourceMethodEventHandler Updating;

		/// <summary>
		/// Occurs when an update operation has completed.
		/// </summary>
		public event ObjectDataSourceStatusEventHandler Updated;

		/// <summary>
		/// Occurs before a delete operation.
		/// </summary>
		public event ObjectDataSourceMethodEventHandler Deleting;

		/// <summary>
		/// Occurs when a delete operation has completed.
		/// </summary>
		public event ObjectDataSourceStatusEventHandler Deleted;

		/// <summary>
		/// Raises the Selecting event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceSelectingEventArgs containing the event data.</param>
		public void OnSelecting(ObjectDataSourceSelectingEventArgs e)
		{
			if ( Selecting != null )
			{
				Selecting(this, e);
			}
		}

		/// <summary>
		/// Raises the Selected event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceStatusEventArgs containing the event data.</param>
		public void OnSelected(ObjectDataSourceStatusEventArgs e)
		{
			if ( Selected != null )
			{
				Selected(this, e);
			}
		}

		/// <summary>
		/// Raises the Inserting event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceMethodEventArgs containing the event data.</param>
		public void OnInserting(ObjectDataSourceMethodEventArgs e)
		{
			if ( Inserting != null )
			{
				Inserting(this, e);
			}
		}

		/// <summary>
		/// Raises the Inserted event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceStatusEventArgs containing the event data.</param>
		public void OnInserted(ObjectDataSourceStatusEventArgs e)
		{
			if ( Inserted != null )
			{
				Inserted(this, e);
			}
		}

		/// <summary>
		/// Raises the Updating event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceMethodEventArgs containing the event data.</param>
		public void OnUpdating(ObjectDataSourceMethodEventArgs e)
		{
			if ( Updating != null )
			{
				Updating(this, e);
			}
		}

		/// <summary>
		/// Raises the Updated event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceStatusEventArgs containing the event data.</param>
		public void OnUpdated(ObjectDataSourceStatusEventArgs e)
		{
			if ( Updated != null )
			{
				Updated(this, e);
			}
		}

		/// <summary>
		/// Raises the Deleting event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceMethodEventArgs containing the event data.</param>
		public void OnDeleting(ObjectDataSourceMethodEventArgs e)
		{
			if ( Deleting != null )
			{
				Deleting(this, e);
			}
		}

		/// <summary>
		/// Raises the Deleted event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceStatusEventArgs containing the event data.</param>
		public void OnDeleted(ObjectDataSourceStatusEventArgs e)
		{
			if ( Deleted != null )
			{
				Deleted(this, e);
			}
		}

		/// <summary>
		/// Raises the DataSourceView.OnDataSourceViewChanged event.
		/// </summary>
		internal void RaiseChangedEvent()
		{
			_tempList = null;
			_totalRowCount = 0;

			OnDataSourceViewChanged(EventArgs.Empty);
		}

		#endregion
	}

	#region CachedDataSource
	
	/// <summary>
	/// Internal object used to maintain cached data. Keeps track of the data and the record count.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the key
	/// property of the specified business object class.</typeparam>
	internal class CachedDataSource<Entity, EntityKey>
		where Entity : new()
		where EntityKey : new()
	{
		/// <summary>
		/// Initializes a new instance of the CachedDataSource class.
		/// </summary>
		public CachedDataSource() { }
		
		/// <summary>
		/// Initializes a new instance of the CachedDataSource class
		/// using the specifed collection and total count.
		/// </summary>
		public CachedDataSource(IList<Entity> data, int count)
		{
			this._data = data;
			this._virtualRecordCount = count;
		}
		
		private IList<Entity> _data;
		
		/// <summary>
		/// Gets or sets the cached data.
		/// </summary>
		public IList<Entity> Data
		{
			get { return _data; }
			set { _data = value; }
		}
		
		private int _virtualRecordCount;
		
		/// <summary>
		/// Keeps track of the record count to keep paging working.
		/// </summary>
		public int VirtualRecordCount
		{
			get { return _virtualRecordCount; }
			set { _virtualRecordCount = value; }
		}
	}
	
	#endregion CachedDataSource
}
