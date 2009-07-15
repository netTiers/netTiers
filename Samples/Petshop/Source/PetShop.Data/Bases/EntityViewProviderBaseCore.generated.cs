#region Using Directives
using System;
using PetShop.Business;
#endregion

namespace PetShop.Data.Bases
{
	/// <summary>
	/// Serves as the base class for objects that provide data access functionality.
	/// Provides a default implementation of the IEntityViewProvider&lt;Entity&gt; interface.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	[Serializable]
	[CLSCompliant(true)]
	public abstract partial class EntityViewProviderBaseCore<Entity> : IEntityViewProvider<Entity>
		where Entity : new()
	{
		#region GetAll Methods

		/// <summary>
		/// Gets All rows from the DataSource.
		/// </summary>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> GetAll()
		{
			return GetAll(0, int.MaxValue);
		}

		/// <summary>
		/// Gets All rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks>Uses connection string object was created with.</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> GetAll(int start, int pageLength)
		{
			return GetAll(null, start, pageLength);
		}

		/// <summary>
		/// Gets All rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of rows in the data source.</param>
		/// <remarks>Uses connection string object was created with.</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> GetAll(int start, int pageLength, out int count)
		{
			return GetAll(null, start, pageLength, out count);
		}

		/// <summary>
		/// Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> GetAll(TransactionManager transactionManager)
		{
			return GetAll(transactionManager, 0, int.MaxValue);
		}

		/// <summary>
		/// Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> GetAll(TransactionManager transactionManager, int start, int pageLength)
		{
			int count = 0;
			return GetAll(transactionManager, start, pageLength, out count);
		}

		/// <summary>
		/// Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of rows in the data source.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public abstract VList<Entity> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count);

		#endregion GetAll Methods

		#region Get Methods

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get()
		{
			return Get(null, null, null, 0, int.MaxValue);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(TransactionManager transactionManager)
		{
			return Get(transactionManager, null, null, 0, int.MaxValue);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(int start, int pageLength)
		{
			return Get(null, null, null, start, pageLength);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of rows in the data source.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(int start, int pageLength, out int count)
		{
			return Get(null, null, null, start, pageLength, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(TransactionManager transactionManager, int start, int pageLength)
		{
			return Get(transactionManager, null, null, start, pageLength);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of rows in the data source.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			return Get(transactionManager, null, null, start, pageLength, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(string whereClause, string orderBy)
		{
			return Get(whereClause, orderBy, 0, int.MaxValue);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(TransactionManager transactionManager, string whereClause, string orderBy)
		{
			return Get(transactionManager, whereClause, orderBy, 0, int.MaxValue);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(string whereClause, string orderBy, int start, int pageLength)
		{
			return Get(null, whereClause, orderBy, start, pageLength);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of rows in the data source.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			return Get(null, whereClause, orderBy, start, pageLength, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength)
		{
			int count;
			return Get(transactionManager, whereClause, orderBy, start, pageLength, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of rows in the data source.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public abstract VList<Entity> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count);

		#endregion Get Methods

		#region GetPaged Methods

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a VList of Entity objects.</returns>
		public virtual VList<Entity> GetPaged(out int count)
		{
			return GetPaged(null, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a VList of Entity objects.</returns>
		public virtual VList<Entity> GetPaged(TransactionManager mgr, out int count)
		{
			return GetPaged(mgr, String.Empty, String.Empty, 0, 0, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a VList of Entity objects.</returns>
		public virtual VList<Entity> GetPaged(int start, int pageLength, out int count)
		{
			return GetPaged(null, start, pageLength, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a VList of Entity objects.</returns>
		public virtual VList<Entity> GetPaged(TransactionManager mgr, int start, int pageLength, out int count)
		{
			return GetPaged(mgr, String.Empty, String.Empty, start, pageLength, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a VList of Entity objects.</returns>
		public virtual VList<Entity> GetPaged(String whereClause, String orderBy, int start, int pageLength, out int count)
		{
			return GetPaged(null, whereClause, orderBy, start, pageLength, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a VList of Entity objects.</returns>
		public virtual VList<Entity> GetPaged(TransactionManager mgr, String whereClause, String orderBy, int start, int pageLength, out int count)
		{
			return Get(mgr, whereClause, orderBy, start, pageLength, out count);
		}

		/// <summary>
		/// Gets the number of rows in the DataSource that match the specified whereClause.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns the number of rows.</returns>
		public virtual int GetTotalItems(String whereClause, out int count)
		{
			return GetTotalItems(null, whereClause, out count);
		}

		/// <summary>
		/// Gets the number of rows in the DataSource that match the specified whereClause.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns the number of rows.</returns>
		public virtual int GetTotalItems(TransactionManager mgr, String whereClause, out int count)
		{
            GetPaged(mgr, whereClause, String.Empty, 0, 0, out count);
            return count;
		}

		#endregion

		#region Find Methods
		
		#region Parameterized Find Methods
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Find(IFilterParameterCollection parameters)
		{
			return Find((TransactionManager) null, parameters);
		}
		
		/// <summary>
        /// Returns rows from the DataSource that meet the parameter conditions.
        /// </summary>
        /// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
        /// <param name="sortColumns">A collection of <see cref="SqlSortColumn"/> objects.</param>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual VList<Entity> Find(IFilterParameterCollection parameters, ISortColumnCollection sortColumns)
        {
            return Find((TransactionManager)null, parameters, sortColumns);
        }
		
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Find(TransactionManager transactionManager, IFilterParameterCollection parameters)
		{
			return Find(transactionManager, parameters, (string) null);
		}
		
		/// <summary>
        /// Returns rows from the DataSource that meet the parameter conditions.
        /// </summary>
        /// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
        /// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
        /// <param name="sortColumns">A collection of <see cref="SqlSortColumn"/> objects.</param>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual VList<Entity> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, ISortColumnCollection sortColumns)
        {
            return Find(transactionManager, parameters, sortColumns.ToString());
        }
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Find(IFilterParameterCollection parameters, string orderBy)
		{
			return Find((TransactionManager) null, parameters, orderBy);
		}
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy)
		{
			int count = 0;
			return Find(transactionManager, parameters, orderBy, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Find(IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			return Find((TransactionManager) null, parameters, orderBy, start, pageLength, out count);
		}
		
		/// <summary>
        /// Returns rows from the DataSource that meet the parameter and sort conditions.
        /// </summary>
        /// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
        /// <param name="sortColumns">A collection of <see cref="SqlSortColumn"/> objects.</param>
        /// <param name="start">Row number at which to start reading.</param>
        /// <param name="pageLength">Number of rows to return.</param>
        /// <param name="count">out. The number of rows that match this query.</param>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual VList<Entity> Find(IFilterParameterCollection parameters, ISortColumnCollection sortColumns, int start, int pageLength, out int count)
        {
            return Find((TransactionManager)null, parameters, sortColumns.ToString(), start, pageLength, out count);
        }
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			count = 0;
			return null;
		}

		#endregion Parameterized Find Methods
		
		#endregion Find Methods
		
	}
}
