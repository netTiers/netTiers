#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;
#endregion

namespace Nettiers.AdventureWorks.Web.Data
{
	/// <summary>
	/// Represents a business object that provides data to data-bound
	/// controls in multi-tier Web application architectures.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the EntityId
	/// property of the specified business object class.</typeparam>
	public abstract class ProviderDataSource<Entity, EntityKey> : BaseDataSource<Entity, EntityKey>, ILinkedDataSource
		where Entity : IEntityId<EntityKey>, new()
		where EntityKey : IEntityKey, new()
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProviderDataSource class.
		/// </summary>
		public ProviderDataSource()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ProviderDataSource class using
		/// the specified data provider.
		/// </summary>
		/// <param name="provider">The business object that provides data access methods.</param>
		public ProviderDataSource(IEntityProvider<Entity, EntityKey> provider)
		{
			Provider = provider;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets a reference to the ProviderDataSourceView used by the ProviderDataSource.
		/// </summary>
		protected ProviderDataSourceView<Entity, EntityKey> ProviderView
		{
			get { return ( View as ProviderDataSourceView<Entity, EntityKey> ); }
		}

		/// <summary>
		/// Gets or sets the object that the ProviderDataSource object represents.
		/// </summary>
		[Browsable(false)]
		public IEntityProvider<Entity, EntityKey> Provider
		{
			get { return ProviderView.Provider; }
			set { ProviderView.Provider = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether to perform a DeepLoad operation
		/// after a Select operation.
		/// </summary>
		public bool EnableDeepLoad
		{
			get
			{
				bool isEnabled = false;
				Object enable = ViewState["EnableDeepLoad"];
				if ( enable != null ) isEnabled = (bool) enable;
				return isEnabled;
			}
			set { ViewState["EnableDeepLoad"] = value; }
		}

		/// <summary>
		/// Gets the DeepLoadProperties property.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public ProviderDataSourceDeepLoadList DeepLoadProperties
		{
			get
			{
				ProviderDataSourceDeepLoadList types = ViewState["DeepLoadProperties"] as ProviderDataSourceDeepLoadList;
				if ( types == null )
				{
					types = new ProviderDataSourceDeepLoadList();
					ViewState["DeepLoadProperties"] = types;
				}
				return types;
			}
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProviderDataSource control invokes to insert data.
		/// </summary>
		public ProviderDataSourceInsertMethod InsertMethod
		{
			get
			{
				ProviderDataSourceInsertMethod insertMethod = ProviderDataSourceInsertMethod.Insert;
				Object method = ViewState["InsertMethod"];
				if ( method != null )
				{
					insertMethod = (ProviderDataSourceInsertMethod) method;
				}
				return insertMethod;
			}
			set { ViewState["InsertMethod"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProviderDataSource control invokes to update data.
		/// </summary>
		public ProviderDataSourceUpdateMethod UpdateMethod
		{
			get
			{
				ProviderDataSourceUpdateMethod updateMethod = ProviderDataSourceUpdateMethod.Update;
				Object method = ViewState["UpdateMethod"];
				if ( method != null )
				{
					updateMethod = (ProviderDataSourceUpdateMethod) method;
				}
				return updateMethod;
			}
			set { ViewState["UpdateMethod"] = value; }
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Creates a new instance of the ProviderDataSourceView class that is to be
		/// used by the ProviderDataSource.
		/// </summary>
		/// <returns>An instance of the ProviderDataSourceView class.</returns>
		/// <remarks>This method should be overridden by sub-classes who need to provide
		/// additional functionality through the use of a sub-classed ProviderDataSourceView.</remarks>
		protected override BaseDataSourceView<Entity, EntityKey> GetNewDataSourceView()
		{
			return new ProviderDataSourceView<Entity, EntityKey>(this, DefaultViewName);
		}

		#endregion Methods

		#region Events

		/// <summary>
		/// Occurs after the Selected event has fired.
		/// </summary>
		public event ProviderDataSourceDeepLoadEventHandler DeepLoading
		{
			add { ProviderView.DeepLoading += value; }
			remove { ProviderView.DeepLoaded += value; }
		}

		/// <summary>
		/// Occurs after the DeepLoading event has fired.
		/// </summary>
		public event ProviderDataSourceDeepLoadEventHandler DeepLoaded
		{
			add { ProviderView.DeepLoaded += value; }
			remove { ProviderView.DeepLoaded += value; }
		}

		#endregion
	}

	/// <summary>
	/// Supports the ProviderDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the EntityId
	/// property of the specified business object class.</typeparam>
	public class ProviderDataSourceView<Entity, EntityKey> : BaseDataSourceView<Entity, EntityKey>
		where Entity : IEntityId<EntityKey>, new()
		where EntityKey : IEntityKey, new()
	{
		#region Declarations

		private IEntityProvider<Entity, EntityKey> _provider;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProviderDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProviderDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProviderDataSourceView(ProviderDataSource<Entity, EntityKey> owner, String viewName)
			: base(owner, viewName)
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the object that the ProviderDataSource object represents.
		/// </summary>
		internal IEntityProvider<Entity, EntityKey> Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProviderDataSource<Entity, EntityKey> ProviderOwner
		{
			get { return Owner as ProviderDataSource<Entity, EntityKey>; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether to perform a DeepLoad operation
		/// after a Select operation.
		/// </summary>
		internal bool EnableDeepLoad
		{
			get { return ProviderOwner.EnableDeepLoad; }
			set { ProviderOwner.EnableDeepLoad = value; }
		}

		/// <summary>
		/// Gets the DeepLoadProperties property.
		/// </summary>
		internal ProviderDataSourceDeepLoadList DeepLoadProperties
		{
			get { return ProviderOwner.DeepLoadProperties; }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProviderDataSource control invokes to insert data.
		/// </summary>
		internal ProviderDataSourceInsertMethod InsertMethod
		{
			get { return ProviderOwner.InsertMethod; }
			set { ProviderOwner.InsertMethod = value; }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProviderDataSource control invokes to update data.
		/// </summary>
		internal ProviderDataSourceUpdateMethod UpdateMethod
		{
			get { return ProviderOwner.UpdateMethod; }
			set { ProviderOwner.UpdateMethod = value; }
		}
		
		#endregion Properties

		#region DeepLoad Methods

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		internal virtual void ExecuteDeepLoad(TList<Entity> entityList)
		{
			ProviderDataSourceDeepLoadEventArgs args1 = new ProviderDataSourceDeepLoadEventArgs(entityList, DeepLoadProperties);
			OnDeepLoading(args1);

			if ( args1.Cancel )
			{
				return;
			}

			try
			{
				DeepLoad(entityList, args1.DeepLoadProperties);

				ProviderDataSourceDeepLoadEventArgs args2 = new ProviderDataSourceDeepLoadEventArgs(entityList, args1.DeepLoadProperties);
				OnDeepLoaded(args2);
			}
			catch ( Exception )
			{
				throw;
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal virtual void DeepLoad(TList<Entity> entityList, ProviderDataSourceDeepLoadList properties)
		{
		}

		#endregion DeepLoad Methods

		#region Insert Methods

		/// <summary>
		/// Performs an insert operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		protected override bool ExecuteInsert(Entity entity)
		{
			if ( InsertMethod == ProviderDataSourceInsertMethod.Save )
			{
				Provider.Save(entity);
				return true;
			}
			if ( InsertMethod == ProviderDataSourceInsertMethod.DeepSave )
			{
				return Provider.DeepSave(entity);
			}
			if ( InsertMethod == ProviderDataSourceInsertMethod.Insert )
			{
				return Provider.Insert(entity);
			}
			
			return false;
		}

		#endregion Insert Methods

		#region Update Methods

		/// <summary>
		/// Performs an update operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		protected override bool ExecuteUpdate(Entity entity)
		{
			if ( UpdateMethod == ProviderDataSourceUpdateMethod.Save )
			{
				Provider.Save(entity);
				return true;
			}
			if ( UpdateMethod == ProviderDataSourceUpdateMethod.DeepSave )
			{
				return Provider.DeepSave(entity);
			}
			if ( UpdateMethod == ProviderDataSourceUpdateMethod.Update )
			{
				return Provider.Update(entity);
			}
			
			return false;
		}

		#endregion UpdateMethods

		#region Delete Methods

		/// <summary>
		/// Performs a delete operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		protected override bool ExecuteDelete(Entity entity)
		{
			return Provider.Delete(entity);
		}

		#endregion Delete Methods

		#region Helper Methods

		/// <summary>
		/// Gets the unique identifier of the specified entity object.
		/// </summary>
		/// <param name="entity">The current business object.</param>
		/// <returns>Returns the unique identifier for the specified entity.</returns>
		protected override EntityKey GetEntityId(Entity entity)
		{
			if ( entity != null )
			{
				return entity.EntityId;
			}

			return base.GetEntityId(entity);
		}

		/// <summary>
		/// Gets the Entity object within the collection of Entity objects that matches
		/// the values found in the specified EntityKey object.
		/// </summary>
		/// <param name="entityList">A collection of Entity objects.</param>
		/// <param name="entityKey">An <see cref="T:EntityKey"/> object.</param>
		/// <returns></returns>
		protected override Entity GetCurrentEntity(IList<Entity> entityList, EntityKey entityKey)
		{
			return ( (ListBase<Entity>) entityList ).Find(delegate(Entity entity)
			{
				return entityKey.Equals(entity.EntityId);
			});
		}

		/// <summary>
		/// Stores the specified entity in the temporary cache.
		/// </summary>
		/// <param name="entity">The Entity object to cache.</param>
		/// <param name="entityList">The list of Entity objects to cache.</param>
		protected override void SetTempCache(Entity entity, out IList<Entity> entityList)
		{
			entityList = new List<Entity>();
			entityList.Add(entity);
		}

		#endregion Helper Methods

		#region Events

		/// <summary>
		/// Occurs after the Selected event has fired.
		/// </summary>
		internal event ProviderDataSourceDeepLoadEventHandler DeepLoading;

		/// <summary>
		/// Occurs after the DeepLoading event has fired.
		/// </summary>
		internal event ProviderDataSourceDeepLoadEventHandler DeepLoaded;

		/// <summary>
		/// Raises the Selected event.
		/// </summary>
		/// <param name="e">An instance of ObjectDataSourceStatusEventArgs containing the event data.</param>
		internal override void OnSelected(ObjectDataSourceStatusEventArgs e)
		{
			base.OnSelected(e);

			if ( EnableDeepLoad && e.ReturnValue != null )
			{
				ExecuteDeepLoad(e.ReturnValue as TList<Entity>);
			}
		}

		/// <summary>
		/// Raises the DeepLoading event.
		/// </summary>
		/// <param name="e">An instance of ProviderDataSourceDeepLoadEventArgs containing the event data.</param>
		internal virtual void OnDeepLoading(ProviderDataSourceDeepLoadEventArgs e)
		{
			if ( DeepLoading != null )
			{
				DeepLoading(Owner, e);
			}
		}

		/// <summary>
		/// Raises the DeepLoaded event.
		/// </summary>
		/// <param name="e">An instance of ProviderDataSourceDeepLoadEventArgs containing the event data.</param>
		internal virtual void OnDeepLoaded(ProviderDataSourceDeepLoadEventArgs e)
		{
			if ( DeepLoaded != null )
			{
				DeepLoaded(Owner, e);
			}
		}

		#endregion Events
	}

	#region ProviderDataSourceDeepLoadList

	/// <summary>
	/// Groups DeepLoad information for the ProviderDataSource control.
	/// </summary>
	[ParseChildren(true), PersistChildren(false)]
	public class ProviderDataSourceDeepLoadList
	{
		/// <summary>
		/// The Method member variable.
		/// </summary>
		private DeepLoadType method = DeepLoadType.IncludeChildren;

		/// <summary>
		/// Gets or sets the Method property.
		/// </summary>
		public DeepLoadType Method
		{
			get { return method; }
			set { method = value; }
		}

		/// <summary>
		/// The Recursive member variable.
		/// </summary>
		private bool recursive = false;

		/// <summary>
		/// Gets or sets the Recursive property.
		/// </summary>
		public bool Recursive
		{
			get { return recursive; }
			set { recursive = value; }
		}

		/// <summary>
		/// The Types member variable.
		/// </summary>
		private IList types;

		/// <summary>
		/// Gets or sets the Types property.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList Types
		{
			get
			{
				if ( types == null )
				{
					types = new ArrayList();
				}
				
				return types;
			}
		}

		/// <summary>
		/// Gets an array of <see cref="System.Type"/> objects represented
		/// by the current Types collection.
		/// </summary>
		/// <returns></returns>
		public Type[] GetTypes()
		{
			Type[] childTypes = Type.EmptyTypes;

			if ( types != null )
			{
				List<Type> list = new List<Type>();

				foreach ( IChildEntityProperty property in types )
				{
					list.Add(ChildEntityTypeAttribute.GetType(property.ChildEntityType));
				}

				childTypes = list.ToArray();
			}

			return childTypes;
		}
	}

	#endregion ProviderDataSourceDeepLoadList

	#region ProviderDataSourceDeepLoadEventHandler

	/// <summary>
	/// Represents the methods that will handle the DeepLoading and DeepLoaded events.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void ProviderDataSourceDeepLoadEventHandler(object sender, ProviderDataSourceDeepLoadEventArgs e);

	/// <summary>
	/// Provides data for the DeepLoading and DeepLoaded events.
	/// </summary>
	public class ProviderDataSourceDeepLoadEventArgs : CancelEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the ProviderDataSourceDeepLoadEventArgs class.
		/// </summary>
		/// <param name="entityList"></param>
		public ProviderDataSourceDeepLoadEventArgs(IList entityList)
		{
			this.entityList = entityList;
		}

		/// <summary>
		/// Initializes a new instance of the ProviderDataSourceDeepLoadEventArgs class.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		public ProviderDataSourceDeepLoadEventArgs(IList entityList, ProviderDataSourceDeepLoadList properties)
			: this(entityList)
		{
			this.deepLoadProperties = properties;
		}

		/// <summary>
		/// The EntityList member variable.
		/// </summary>
		private IList entityList;

		/// <summary>
		/// Gets the EntityList property.
		/// </summary>
		public IList EntityList
		{
			get { return entityList; }
		}

		/// <summary>
		/// The DeepLoadProperties member variable.
		/// </summary>
		private ProviderDataSourceDeepLoadList deepLoadProperties;

		/// <summary>
		/// Gets the DeepLoadProperties property.
		/// </summary>
		public ProviderDataSourceDeepLoadList DeepLoadProperties
		{
			get { return deepLoadProperties; }
		}
	}

	#endregion ProviderDataSourceDeepLoadEventHandler

	#region ProviderDataSourceInsertMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProviderDataSource.InsertMethod property.
	/// </summary>
	public enum ProviderDataSourceInsertMethod
	{
		/// <summary>
		/// Represents the Insert method.
		/// </summary>
		Insert,
		/// <summary>
		/// Represents the Save method.
		/// </summary>
		Save,
		/// <summary>
		/// Represents the DeepSave method.
		/// </summary>
		DeepSave
	}
	
	#endregion ProviderDataSourceInsertMethod
	
	#region ProviderDataSourceUpdateMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProviderDataSource.UpdateMethod property.
	/// </summary>
	public enum ProviderDataSourceUpdateMethod
	{
		/// <summary>
		/// Represents the Update method.
		/// </summary>
		Update,
		/// <summary>
		/// Represents the Save method.
		/// </summary>
		Save,
		/// <summary>
		/// Represents the DeepSave method.
		/// </summary>
		DeepSave
	}
	
	#endregion ProviderDataSourceUpdateMethod
}
