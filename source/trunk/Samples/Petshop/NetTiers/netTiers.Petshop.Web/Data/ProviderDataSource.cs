#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
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

		#endregion Properties

		#region Insert Methods

		/// <summary>
		/// Performs an insert operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		protected override bool ExecuteInsert(Entity entity)
		{
			return Provider.Insert(entity);
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
			return Provider.Update(entity);
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
	}
}
