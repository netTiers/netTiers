#region Using directives
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Represents a business object that provides data to data-bound
	/// controls in multi-tier Web application architectures.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	public abstract class ReadOnlyDataSource<Entity> : BaseDataSource<Entity, Object> where Entity : new()
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReadOnlyDataSource class.
		/// </summary>
		public ReadOnlyDataSource()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ProviderDataSource class using
		/// the specified data provider.
		/// </summary>
		/// <param name="provider">The business object that provides data access methods.</param>
		public ReadOnlyDataSource(IEntityViewProvider<Entity> provider)
		{
			Provider = provider;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the object that the ReadOnlyDataSource object represents.
		/// </summary>
		public IEntityViewProvider<Entity> Provider
		{
			get { return ReadOnlyView.Provider; }
			set { ReadOnlyView.Provider = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ReadOnlyDataSource control invokes to retrieve data.
		/// </summary>
		public ReadOnlyDataSourceSelectMethod SelectMethod
		{
			get { return ReadOnlyView.SelectMethod; }
			set { ReadOnlyView.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a reference to the ReadOnlyDataSourceView used by the ReadOnlyDataSource.
		/// </summary>
		protected ReadOnlyDataSourceView<Entity> ReadOnlyView
		{
			get { return ( View as ReadOnlyDataSourceView<Entity> ); }
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Creates a new instance of the ReadOnlyDataSourceView class that is to be
		/// used by the ReadOnlyDataSource.
		/// </summary>
		/// <returns>An instance of the ReadOnlyDataSourceView class.</returns>
		protected override BaseDataSourceView<Entity, Object> GetNewDataSourceView()
		{
			return new ReadOnlyDataSourceView<Entity>(this, DefaultViewName);
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
	/// Supports the ReadOnlyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	public class ReadOnlyDataSourceView<Entity> : BaseDataSourceView<Entity, Object> where Entity : new()
	{
		#region Declarations

		private IEntityViewProvider<Entity> _provider;
		private ReadOnlyDataSourceSelectMethod _selectMethod;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReadOnlyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ReadOnlyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ReadOnlyDataSourceView(ReadOnlyDataSource<Entity> owner, String viewName)
			: base(owner, viewName)
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the object that the ProviderDataSource object represents.
		/// </summary>
		internal IEntityViewProvider<Entity> Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ReadOnlyDataSource control invokes to retrieve data.
		/// </summary>
		internal ReadOnlyDataSourceSelectMethod SelectMethod
		{
			get { return _selectMethod; }
			set { _selectMethod = value; }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object
		/// associated with the current BaseDataSource object supports the
		/// ExecuteInsert(IDictionary) operation.
		/// </summary>
		public override bool CanInsert
		{
			get { return false; }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object
		/// associated with the current BaseDataSource object supports the
		/// ExecuteUpdate(IDictionary, IDictionary, IDictionary) operation.
		/// </summary>
		public override bool CanUpdate
		{
			get { return false; }
		}

		/// <summary>
		/// Gets a value indicating whether the BaseDataSourceView object
		/// associated with the current BaseDataSource object supports the
		/// ExecuteDelete(IDictionary, IDictionary) operation.
		/// </summary>
		public override bool CanDelete
		{
			get { return false; }
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Entity> GetSelectData(out int count)
		{
			IList<Entity> entityList = null;
			count = 0;

			switch ( SelectMethod )
			{
				case ReadOnlyDataSourceSelectMethod.Get:
					entityList = Provider.Get(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ReadOnlyDataSourceSelectMethod.GetPaged:
					entityList = Provider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ReadOnlyDataSourceSelectMethod.GetAll:
					entityList = Provider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
					break;
				default:
					break;
			}

			return entityList;
		}

		#endregion Methods
	}

	#region ReadOnlyDataSourceSelectMethod

	/// <summary>
	/// Enumeration of method names available for the ReadOnlyDataSource.SelectMethod property.
	/// </summary>
	[Serializable]
	public enum ReadOnlyDataSourceSelectMethod
	{
		/// <summary>
		/// Represents the IEntityViewProvider&lt;Entity&gt;.Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the IEntityViewProvider&lt;Entity&gt;.GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the IEntityViewProvider&lt;Entity&gt;.GetAll method.
		/// </summary>
		GetAll
	}

	#endregion ReadOnlyDataSourceSelectMethod
}
