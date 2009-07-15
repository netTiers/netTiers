﻿#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;

using PetShop.Business;
using Microsoft.Practices.ObjectBuilder2;
#endregion

namespace PetShop.Data.Bases
{
	
	
	/// <summary>
	/// Serves as the base class for objects that provide data access functionality.
	/// Provides a default implementation of the IEntityProvider&lt;Entity, EntityKey&gt; interface.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the EntityId
	/// property of the specified business object class.</typeparam>
	[Serializable]
	[CLSCompliant(true)]
	public abstract partial class EntityProviderBaseCore<Entity, EntityKey> : IEntityProvider<Entity, EntityKey>
		where Entity : IEntityId<EntityKey>, new()
		where EntityKey : IEntityKey, new()
	{
		#region Get Methods

		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public virtual Entity Get(EntityKey key)
		{
			return Get(null, key);
		}

		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public virtual Entity Get(TransactionManager mgr, EntityKey key)
		{
			return Get(mgr, key, 0, Int32.MaxValue);
		}

		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public virtual Entity Get(EntityKey key, int start, int pageLength)
		{
			return Get(null, key, start, pageLength);
		}

		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public abstract Entity Get(TransactionManager mgr, EntityKey key, int start, int pageLength);

		#endregion

		#region GetAll Methods

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetAll()
		{
			return GetAll(null);
		}

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetAll(TransactionManager mgr)
		{
			return GetAll(mgr, 0, Int32.MaxValue);
		}

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetAll(int start, int pageLength)
		{
			return GetAll(null, start, pageLength);
		}

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetAll(TransactionManager mgr, int start, int pageLength)
		{
			int count;
			return GetAll(mgr, start, pageLength, out count);
		}

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetAll(int start, int pageLength, out int count)
		{
			return GetAll(null, start, pageLength, out count);
		}

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public abstract TList<Entity> GetAll(TransactionManager mgr, int start, int pageLength, out int count);

		#endregion

		#region GetPaged Methods

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetPaged(out int count)
		{
			return GetPaged(null, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetPaged(TransactionManager mgr, out int count)
		{
			return GetPaged(mgr, String.Empty, String.Empty, 0, 0, out count);
		}

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetPaged(int start, int pageLength, out int count)
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
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetPaged(TransactionManager mgr, int start, int pageLength, out int count)
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
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetPaged(String whereClause, String orderBy, int start, int pageLength, out int count)
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
		/// <returns>Returns a TList of Entity objects.</returns>
		public abstract TList<Entity> GetPaged(TransactionManager mgr, String whereClause, String orderBy, int start, int pageLength, out int count);

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
		
		#region Parsed Find Methods
		
		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(string whereClause)
		{
			int count = -1;
			return Find((TransactionManager) null, whereClause, 0, int.MaxValue, out count);
		}	
		
		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(TransactionManager transactionManager, string whereClause)
		{
			int count = -1;
			return Find(transactionManager, whereClause, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(string whereClause, int start, int pageLength)
		{
			int count = -1;
			return Find((TransactionManager) null, whereClause, start, pageLength, out count);
		}
		
		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(TransactionManager transactionManager, string whereClause, out int count)
		{
			return Find(transactionManager, whereClause, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(string whereClause, int start, int pageLength, out int count)
		{
			return Find((TransactionManager) null, whereClause, start, pageLength, out count);
		}
		
		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public abstract TList<Entity> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count);
		
		#endregion Parsed Find Methods
		
		#region Parameterized Find Methods
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(IFilterParameterCollection parameters)
		{
			return Find((TransactionManager) null, parameters);
		}
		
		
		/// <summary>
        /// Returns rows from the DataSource that meet the parameter and sortColumn conditions.
        /// </summary>
        /// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
        /// <param name="sortColumns">A collection of <see cref="SqlSortColumn"/> or <see cref="SqlSortBuilder&lt;T&gt;"/> objects</param>
        /// <returns></returns>
        public virtual TList<Entity> Find(IFilterParameterCollection parameters, ISortColumnCollection sortColumns)
        {
            return Find((TransactionManager) null, parameters, sortColumns);
        }
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(TransactionManager transactionManager, IFilterParameterCollection parameters)
		{
			return Find(transactionManager, parameters, (string) null);
		}
		
		/// <summary>
        /// Returns rows from the DataSource that meet the parameter and sortColumn conditions.
        /// </summary>
        /// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
        /// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
        /// <param name="sortColumns">A collection of <see cref="SqlSortColumn"/> or <see cref="SqlSortBuilder&lt;T&gt;"/> objects</param>
        /// <returns></returns>
        public virtual TList<Entity> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, ISortColumnCollection sortColumns)
        {
            return Find(transactionManager, parameters, sortColumns.ToString());
        }
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(IFilterParameterCollection parameters, string orderBy)
		{
			return Find((TransactionManager) null, parameters, orderBy);
		}
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy)
		{
			int count = 0;
			return Find(transactionManager, parameters, orderBy, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			return Find((TransactionManager) null, parameters, orderBy, start, pageLength, out count);
		}
		
		/// <summary>
        /// Returns rows from the DataSource that meet the parameter and sortColumn conditions.
        /// </summary>
        /// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
        /// <param name="sortColumns">A collection of <see cref="SqlSortColumn"/> or <see cref="SqlSortBuilder&lt;T&gt;"/> objects</param>
        /// <param name="start">Row number at which to start reading.</param>
        /// <param name="pageLength">Number of rows to return.</param>
        /// <param name="count">out. The number of rows that match this query.</param>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual TList<Entity> Find(IFilterParameterCollection parameters, ISortColumnCollection sortColumns, int start, int pageLength, out int count)
        {
            return Find((TransactionManager) null, parameters, sortColumns.ToString(), start, pageLength, out count);
        }
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> or <see cref="ParameterizedSqlFilterBuilder&lt;T&gt;"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			count = 0;
			return null;
		}

		#endregion Parameterized Find Methods

		#endregion Find Methods
		
		#region Insert Methods

		/// <summary>
		/// Inserts a row into the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public virtual bool Insert(Entity entity)
		{
			return Insert(null, entity);
		}

		/// <summary>
		/// Inserts a row into the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public abstract bool Insert(TransactionManager mgr, Entity entity);

		/// <summary>
		/// Inserts rows into the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to insert.</param>
		/// <returns>Returns the number of rows successfully inserted.</returns>
		public virtual int Insert(TList<Entity> entities)
		{
			return Insert(null, entities);
		}

		/// <summary>
		/// Inserts rows into the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to insert.</param>
		/// <returns>Returns the number of rows successfully inserted.</returns>
		public virtual int Insert(TransactionManager mgr, TList<Entity> entities)
		{
			int count = 0;

			foreach ( Entity entity in entities )
			{
				if ( entity.EntityState == EntityState.Added )
				{
					if ( Insert(mgr, entity) )
					{
						count++;
					}
				}
			}

			return count;
		}

		/// <summary>
		/// Efficiently inserts multiple rows into the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to insert.</param>
		public virtual void BulkInsert(TList<Entity> entities)
		{
			BulkInsert(null, entities);
		}

		/// <summary>
		/// Efficiently inserts multiple rows into the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to insert.</param>
		public abstract void BulkInsert(TransactionManager mgr, TList<Entity> entities);

		#endregion
		
		#region Update Methods

		/// <summary>
		/// Updates an existing row in the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public virtual bool Update(Entity entity)
		{
			return Update(null, entity);
		}

		/// <summary>
		/// Updates an existing row in the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public abstract bool Update(TransactionManager mgr, Entity entity);

		/// <summary>
		/// Updates existing rows in the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to update.</param>
		/// <returns>Returns the number of rows successfully updated.</returns>
		public virtual int Update(TList<Entity> entities)
		{
			return Update(null, entities);
		}

		/// <summary>
		/// Updates existing rows in the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to update.</param>
		/// <returns>Returns the number of rows successfully updated.</returns>
		public virtual int Update(TransactionManager mgr, TList<Entity> entities)
		{
			int count = 0;

			foreach ( Entity entity in entities )
			{
				if ( entity.EntityState == EntityState.Changed )
				{
					if ( Update(mgr, entity) )
					{
						count++;
					}
				}
			}

			return count;
		}

		#endregion

		#region Save Methods

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		public virtual Entity Save(Entity entity)
		{
			return Save(null, entity);
		}

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to save.</param>
		public virtual Entity Save(TransactionManager mgr, Entity entity)
		{
			switch ( entity.EntityState )
			{
				case EntityState.Deleted:
					Delete(mgr, entity);
					break;
				case EntityState.Changed:
					Update(mgr, entity);
					break;
				case EntityState.Added:
					Insert(mgr, entity);
					break;
			}
			
			return entity;
		}

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="entities">TList of Entity objects to save.</param>
		public virtual TList<Entity> Save(TList<Entity> entities)
		{
			return Save(null, entities);
		}

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to save.</param>
		public virtual TList<Entity> Save(TransactionManager mgr, TList<Entity> entities)
		{
			foreach ( Entity entity in entities.DeletedItems )
			{
				Delete(mgr, entity);
			}

      			foreach ( Entity entity in entities )
			{
				if (!entity.IsNew) Save(mgr, entity);
			}

      			foreach ( Entity entity in entities )
			{
				if (entity.IsNew) Save(mgr, entity);
			}

			// Clear the items to delete list.
			entities.DeletedItems.Clear();
			return entities;
		}

		#endregion

		#region Delete Methods

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public virtual bool Delete(Entity entity)
		{
			return Delete(null, entity);
		}

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public virtual bool Delete(TransactionManager mgr, Entity entity)
		{
			return Delete(mgr, entity.EntityId);
		}

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public virtual bool Delete(EntityKey key)
		{
			return Delete(null, key);
		}

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public abstract bool Delete(TransactionManager mgr, EntityKey key);

		/// <summary>
		/// Deletes rows from the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to delete.</param>
		/// <returns>Returns the number of rows successfully deleted.</returns>
		public virtual int Delete(TList<Entity> entities)
		{
			return Delete(null, entities);
		}

		/// <summary>
		/// Deletes rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to delete.</param>
		/// <returns>Returns the number of rows successfully deleted.</returns>
		public virtual int Delete(TransactionManager mgr, TList<Entity> entities)
		{
			int count = 0;

			foreach ( Entity entity in entities )
			{
				if ( Delete(mgr, entity) )
				{
					count++;
				}
			}

			return count;
		}

		#endregion

		#region DeepLoad Methods
		
		#region DeepLoad Entity

		/// <summary>
		/// Deep Load the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entity">The Entity object to load.</param>
		public virtual void DeepLoad(Entity entity)
		{
			DeepLoad(null, entity);
		}

		/// <summary>
		/// Deep Load the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to load.</param>
		public virtual void DeepLoad(TransactionManager mgr, Entity entity)
		{
			DeepLoad(mgr, entity, false, DeepLoadType.ExcludeChildren, Type.EmptyTypes);
		}

		/// <summary>
		/// Deep Load the Entity object with all of the child property collections N levels deep.
		/// </summary>
		/// <param name="entity">The Entity object to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		public virtual void DeepLoad(Entity entity, bool deep)
		{
			DeepLoad(null, entity, deep);
		}
		
		/// <summary>
		/// Deep Load the Entity object with all of the child property collections N levels deep.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		public virtual void DeepLoad(TransactionManager mgr, Entity entity, bool deep)
		{
			DeepLoad(mgr, entity, deep, DeepLoadType.ExcludeChildren, Type.EmptyTypes);
		}

		/// <summary>
		/// Deep Load the entire Entity object with criteria based on the child types array and the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with recursion and traverse an entire collection's object graph.
		/// </remarks>
		/// <param name="entity">The Entity object to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Load.</param>
		public virtual void DeepLoad(Entity entity, bool deep, DeepLoadType deepLoadType, params Type[] childTypes)
		{
			DeepLoad(null, entity, deep, deepLoadType, childTypes);
		}

		/// <summary>
		/// Deep Load the entire Entity object with criteria based on the child types array and the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with recursion and traverse an entire collection's object graph.
		/// </remarks>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Load.</param>
		public virtual void DeepLoad(TransactionManager mgr, Entity entity, bool deep, DeepLoadType deepLoadType, params Type[] childTypes)
		{
			#region Argument Validation
			//Argument checks
			if ( entity == null )
			{
				throw new ArgumentNullException("entity", "The argument entity, can not be null.");
			}
			if ( !Enum.IsDefined(typeof(DeepLoadType), deepLoadType) )
			{
				throw new ArgumentException("A valid DeepLoadType option is not present.", "DeepLoadType");
			}
			if ( childTypes == null )
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion

			//In case an event can trigger the disabling of the deep load || do not deep load new entities.
			if (deepLoadType == DeepLoadType.Ignore || entity.EntityState == EntityState.Added)
			{
				return;
			}

			// create a collection of types for easy access
			DeepSession innerList = new DeepSession();
			for(int i=0; i < childTypes.Length; i++)
			{
				if (childTypes[i] == null) continue;
				
				if (!childTypes[i].IsGenericType)
					innerList.Add(childTypes[i].Name);
				else 
					innerList.Add(string.Format("List<{0}>" , childTypes[i].GetGenericArguments()[0].Name));

			}
			
			#if NETTIERS_DEBUG
			Debug.Indent();
			Debug.WriteLine(String.Format("DeepLoad object '{0}'", typeof(Entity)));
			Debug.Indent();
			#endif 
			
			DeepLoad(mgr, entity, deep, deepLoadType, childTypes, innerList);

			#if NETTIERS_DEBUG
			Debug.Unindent();
			Debug.Unindent();
			Debug.WriteLine("");
			#endif
			
			return;
		}

		/// <summary>
		/// Deep Load the entire Entity object with criteria based on the child types array and the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// This method should be implemented by sub-classes to provide specific deep load functionality.
		/// </remarks>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Load.</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
		public abstract void DeepLoad(TransactionManager mgr, Entity entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList);

		#endregion DeepLoad Entity

		#region DeepLoad Entity Collection

		/// <summary>
		/// Deep Load the entire Entity object with criteria based on the child types array and the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// This method should be implemented by sub-classes to provide specific deep load functionality.
		/// </remarks>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">The Entity List object to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Load.</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
		public void DeepLoad(TransactionManager mgr, TList<Entity> entities, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			#region Argument Validation
			//Argument checks
			if ( entities == null )
			{
				throw new ArgumentNullException("entities", "A valid non-null, TList<Entity> object is not present.");
			}
			if ( !Enum.IsDefined(typeof(DeepLoadType), deepLoadType) )
			{
				throw new ArgumentException("A valid DeepLoadType option is not present.", deepLoadType.ToString());
			}
			if ( childTypes == null )
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion

			//In case an event can trigger the disabling of the deepload
			if ( deepLoadType == DeepLoadType.Ignore )
			{
				return;
			}

			foreach ( Entity entity in entities )
			{
				DeepLoad(mgr, entity, deep, deepLoadType, childTypes, innerList);
				// remove the loaded keys for this entity
			}

			return;
		}


		/// <summary>
		/// Deep Load the Entity objects with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entities">TList of Entity objects to load.</param>
		public virtual void DeepLoad(TList<Entity> entities)
		{
			DeepLoad(null, entities);
		}

		/// <summary>
		/// Deep Load the Entity objects with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to load.</param>
		public virtual void DeepLoad(TransactionManager mgr, TList<Entity> entities)
		{
			DeepLoad(mgr, entities, false, DeepLoadType.ExcludeChildren, Type.EmptyTypes);
		}

		/// <summary>
		/// Deep Load the Entity objects with all of the child property collections N levels deep.
		/// </summary>
		/// <param name="entities">TList of Entity objects to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		public virtual void DeepLoad(TList<Entity> entities, bool deep)
		{
			DeepLoad(null, entities, deep);
		}

		/// <summary>
		/// Deep Load the Entity objects with all of the child property collections N levels deep.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		public virtual void DeepLoad(TransactionManager mgr, TList<Entity> entities, bool deep)
		{
			DeepLoad(mgr, entities, deep, DeepLoadType.ExcludeChildren, Type.EmptyTypes);
		}

		/// <summary>
		/// Deep Load the Entity objects with criteria based on the child types array and the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with recursion and traverse an entire collection's object graph.
		/// </remarks>
		/// <param name="entities">TList of Entity objects to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Load.</param>
		public virtual void DeepLoad(TList<Entity> entities, bool deep, DeepLoadType deepLoadType, params Type[] childTypes)
		{
			DeepLoad(null, entities, deep, deepLoadType, childTypes);
		}
		
		/// <summary>
		/// Deep Load the Entity objects with criteria based on the child types array and the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with recursion and traverse an entire collection's object graph.
		/// </remarks>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Load.</param>
		public virtual void DeepLoad(TransactionManager mgr, TList<Entity> entities, bool deep, DeepLoadType deepLoadType, params Type[] childTypes)
		{
			#region Argument Validation
			//Argument checks
			if ( entities == null )
			{
				throw new ArgumentNullException("entities", "A valid non-null, TList<Entity> object is not present.");
			}
			if ( !Enum.IsDefined(typeof(DeepLoadType), deepLoadType) )
			{
				throw new ArgumentException("A valid DeepLoadType option is not present.", deepLoadType.ToString());
			}
			if ( childTypes == null )
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion

			//In case an event can trigger the disabling of the deepload
			if ( deepLoadType == DeepLoadType.Ignore )
			{
				return;
			}

			foreach ( Entity entity in entities )
			{
				DeepLoad(mgr, entity, deep, deepLoadType, childTypes);
			}

			return;
		}

		#endregion DeepLoad Entity Collection

		#endregion DeepLoad Methods

		#region DeepSave Methods

		#region DeepSave Entity
		
		/// <summary>
		/// Deep Save the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		public virtual bool DeepSave(Entity entity)
		{
			return DeepSave(null, entity, DeepSaveType.ExcludeChildren, Type.EmptyTypes);
		}

		/// <summary>
		/// Deep Save the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to save.</param>
		public virtual bool DeepSave(TransactionManager mgr, Entity entity)
		{
			return DeepSave(mgr, entity, DeepSaveType.ExcludeChildren, Type.EmptyTypes);
		}

		/// <summary>
		/// Deep Save the entire Entity object with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		public virtual bool DeepSave(Entity entity, DeepSaveType deepSaveType, params Type[] childTypes)
		{
			return DeepSave(null, entity, deepSaveType, childTypes);
		}

		/// <summary>
		/// Deep Save the entire Entity object with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		public virtual bool DeepSave(TransactionManager mgr, Entity entity, DeepSaveType deepSaveType, params Type[] childTypes)
		{
			#region Argument Validation
			//Argument checks
			if ( entity == null )
			{
				throw new ArgumentNullException("entity", "The argument entity, can not be null.");
			}
			if ( !Enum.IsDefined(typeof(DeepSaveType), deepSaveType) )
			{
				throw new ArgumentNullException("A valid DeepSaveType option is not present.", "deepSaveType");
			}
			if ( childTypes == null )
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion

			//In case an event can trigger the disabling of the deepsave
			if ( deepSaveType == DeepSaveType.Ignore )
			{
				return true;
			}

			// create a collection of types for easy access
			DeepSession innerList = new DeepSession();
			for(int i=0; i < childTypes.Length; i++)
			{
				if (childTypes[i] == null) continue;
				
				if (!childTypes[i].IsGenericType)
					innerList.Add(childTypes[i].Name);
				else 
					innerList.Add(string.Format("List<{0}>" , childTypes[i].GetGenericArguments()[0].Name));

			}
			
			#if NETTIERS_DEBUG
			Debug.Indent();
			Debug.WriteLine(String.Format("DeepSave object '{0}'", typeof(Entity)));
			Debug.Indent();
			#endif 
			
			DeepSave(mgr, entity, deepSaveType, childTypes, innerList);

			#if NETTIERS_DEBUG
			Debug.Unindent();
			Debug.Unindent();
			Debug.WriteLine("");
			#endif
			
			return true;
		}

		/// <summary>
		/// Deep Save the entire Entity object with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <remarks>
		/// This method should be implemented by sub-classes to provide specific deep save functionality.
		/// </remarks>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		/// <param name="innerList">A <c>DeepSession</c> of child types for easy access.</param>
		public abstract bool DeepSave(TransactionManager mgr, Entity entity, DeepSaveType deepSaveType, Type[] childTypes, DeepSession innerList);

		#endregion DeepSave Entity
		
		#region DeepSave Entity Collection
		
		/// <summary>
		/// Deep Save the Entity objects with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entities">TList of Entity objects to save.</param>
		public virtual bool DeepSave(TList<Entity> entities)
		{
			return DeepSave(null, entities, DeepSaveType.ExcludeChildren, Type.EmptyTypes);
		}

		/// <summary>
		/// Deep Save the Entity objects with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to save.</param>
		public virtual bool DeepSave(TransactionManager mgr, TList<Entity> entities)
		{
			return DeepSave(mgr, entities, DeepSaveType.ExcludeChildren, Type.EmptyTypes);
		}

		/// <summary>
		/// Deep Save the Entity objects with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="entities">TList of Entity objects to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		public virtual bool DeepSave(TList<Entity> entities, DeepSaveType deepSaveType, params Type[] childTypes)
		{
			return DeepSave(null, entities, deepSaveType, childTypes);
		}

		/// <summary>
		/// Deep Save the Entity objects with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		public virtual bool DeepSave(TransactionManager mgr, TList<Entity> entities, DeepSaveType deepSaveType, params Type[] childTypes)
		{	
			return DeepSave(mgr, entities, deepSaveType, childTypes, null);
		}
		
		/// <summary>
		/// Deep Save the Entity objects with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="mgr">The transaction manager.</param>
		/// <param name="entities">TList of Entity objects to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public virtual bool DeepSave(TransactionManager mgr, TList<Entity> entities, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{
			#region Argument Validation
			//Argument checks
			if ( entities == null )
			{
				throw new ArgumentNullException("entityCollection", "A valid non-null, TList<Entity> object is not present.");
			}
			if ( !Enum.IsDefined(typeof(DeepSaveType), deepSaveType) )
			{
				throw new ArgumentException("A valid DeepSaveType option is not present.", "deepSaveType");
			}
			if ( childTypes == null )
			{
				throw new ArgumentNullException("childTypes", "A valid Type[] array is not present.");
			}
			#endregion

			//In case an event can trigger the disabling of the deepsave
			if ( deepSaveType == DeepSaveType.Ignore )
			{
				return true;
			}

			bool deepSaveResult = true;
			bool result;

			if (innerList == null)
			{
				// create a collection of types for easy access
				innerList = new DeepSession();
				for(int i=0; i < childTypes.Length; i++)
				{
					if (childTypes[i] == null) continue;
					
					if (!childTypes[i].IsGenericType)
						innerList.Add(childTypes[i].Name);
					else 
						innerList.Add(string.Format("List<{0}>" , childTypes[i].GetGenericArguments()[0].Name));
				}
			}
			
			foreach ( Entity entity in entities.DeletedItems )
			{
			  result = DeepSave(mgr, entity, deepSaveType, childTypes, innerList);
			  if ( !result )
			  {
			    deepSaveResult = false;
			  }
			}
                                            
			foreach ( Entity entity in entities )
			{
		          if (!entity.IsNew)
		          {
				result = DeepSave(mgr, entity, deepSaveType, childTypes, innerList);
				if ( !result )
				{
				  deepSaveResult = false;
				}
		          }
			}

			foreach ( Entity entity in entities )
			{
		          if (entity.IsNew)
		          {
				result = DeepSave(mgr, entity, deepSaveType, childTypes, innerList);
				if ( !result )
				{
				  deepSaveResult = false;
				}
        		  }
			}

			entities.DeletedItems.Clear();
			return deepSaveResult;
		}
		#endregion DeepSave Entity Collection

		#endregion DeepSave Methods
		
		#region Helper Methods
		
		///<summary>
		/// Enforces the rules set in order to load this property for a given type.
		///</summary>
		/// <param name="entity">The entity.</param>
        /// <param name="key">The key.</param>
        /// <param name="deepLoadType">Type of the deep load.</param>
        /// <param name="innerList">The inner list.</param>
		protected bool CanDeepLoad(IEntity entity, String key, DeepLoadType deepLoadType, DeepSession innerList) 
        {
			if ( innerList != null && !innerList.CancelSession)
			{
                if ( deepLoadType == DeepLoadType.ExcludeChildren )
				{
                	if (!innerList.ContainsTypeExcluded(key) 
						&& !innerList.HasRun(entity, key))
                    {
                        //add to list prior to firing event
                        innerList.AddRun(entity, key);

                        //call deep loading event
                        DeepSessionEventArgs args = GetDeepSessionArgs(innerList, deepLoadType, entity, key);
                        OnDeepLoading(args);

                        if (args.Skip)
                            return false;

                        if (args.Cancel)
                        {
                            innerList.CancelSession = true;
                            return false;
                        }

                        return true;
                    }
				}
				else if ( deepLoadType == DeepLoadType.IncludeChildren )
				{
                    if (innerList.ContainsType(key) && !innerList.HasRun(entity, key))
                    {
                        //add to list prior to firing event
                        innerList.AddRun(entity, key);

                        //call deep loading event
                        DeepSessionEventArgs args = GetDeepSessionArgs(innerList, deepLoadType, entity, key);
                        OnDeepLoading(args);

                        if (args.Skip)
                            return false;

                        if (args.Cancel)
                        {
                            innerList.CancelSession = true;
                            return false;
                        }

                        return true;
                    }
				}
			}
		
			return false;
        }
		
        /// <summary>
        /// Enforces the rules set in order to save this property for a given type.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="key">The key.</param>
        /// <param name="deepSaveType">Type of the deep save.</param>
        /// <param name="innerList">The inner list.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can deep save] the specified entity; otherwise, <c>false</c>.
        /// </returns>
		protected bool CanDeepSave(Object entity, string key, DeepSaveType deepSaveType, DeepSession innerList) 
        {
			if ( innerList != null && !innerList.CancelSession)
			{
				if ( deepSaveType == DeepSaveType.ExcludeChildren )
				{
					if ( !innerList.ContainsType(key) && !innerList.HasRun(entity, key) )
					{
						//Add to list prior to firing
						innerList.AddRun( entity, key);
						
						//call deep saving event
						DeepSessionEventArgs args = GetDeepSessionArgs( innerList, deepSaveType,  entity, key );
						OnDeepSaving( args );
						
						if ( args.Skip )
							return false;
						
						if ( args.Cancel )
						{
							innerList.CancelSession = true;
							return false;
						}
						
						return true;
					}
				}
				else if ( deepSaveType == DeepSaveType.IncludeChildren )
				{
                    if (innerList.ContainsType(key) && !innerList.HasRun(entity, key))
					{
						//Add to list prior to firing
						innerList.AddRun( entity , key);
						
						//call deep saving event
						DeepSessionEventArgs args = GetDeepSessionArgs(innerList, deepSaveType, entity, key);
						OnDeepSaving( args );
						
						if ( args.Skip )
							return false;
						
						if ( args.Cancel )
						{
							innerList.CancelSession = true;
							return false;
						}
						
						return true;
					}
				}
			}

			return false;
        }
		
		/// <summary>
        /// Gets the DeepSession Arguments for an event.
        /// </summary>
        /// <param name="deepSession">the current DeepSession.</param>
		/// <param name="deepTypeValue"> The Deep Type Value</param>
        /// <param name="obj">The current entity or list.</param>
		/// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>DeepSessionEventArgs</c> if the item being run is a valid entity or list.
        /// </returns>
        protected DeepSessionEventArgs GetDeepSessionArgs(DeepSession deepSession, Enum deepTypeValue, object obj, string key)
		{			
			DeepSessionEventArgs args = null;
			
			if (obj is IEntity)
				args = new DeepSessionEventArgs(deepSession, key, deepTypeValue, (IEntity)obj);
			else if (obj is IList)
				args = new DeepSessionEventArgs(deepSession, key, deepTypeValue, (IList)obj);
			else 
				args = new DeepSessionEventArgs();
				
			return args;
		}
		#endregion Helper Methods
		
        #region DataRequesting event definition code
        /// <summary>
        ///     This represents the delegate method prototype that
        ///     event receivers must implement
        /// </summary>
        public delegate void DataRequestingEventHandler(object sender, CommandEventArgs e);

        /// <summary>
        ///     An event which occurs just before a data 
        ///     request is made in the data provider.
        /// </summary>
        public event DataRequestingEventHandler DataRequesting;

        /// <summary>
        ///     This is the method that is responsible for notifying
        ///     receivers that the event occurred just before accessing the 
        ///     data provider.
        /// </summary>
        protected virtual void OnDataRequesting(CommandEventArgs e)
        {
            if (DataRequesting != null)
            {
                DataRequesting(this, e);
            }
        }


        #endregion //('DataRequesting' event definition code)

        #region DataRequested event definition code
        /// <summary>
        ///     This represents the delegate method prototype that
        ///     event receivers must implement 
        /// </summary>
        public delegate void DataRequestedEventHandler(object sender, CommandEventArgs e);
        
        /// <summary>
        ///     An event which occurs just before a data 
        ///     request is made in the data provider.
        /// </summary>
        public event DataRequestedEventHandler DataRequested;

        /// <summary>
        ///     This is the method that is responsible for notifying
        ///     receivers that the event occurred just after accessing the 
        ///     data provider.
        /// </summary>
        protected virtual void OnDataRequested(CommandEventArgs e)
        {
            if (DataRequested != null)
            {
                DataRequested(this, e);
            }
        }
        #endregion //('DataRequested' event definition code)
		
		#region DeepLoading event definition code
        /// <summary>
        ///     This represents the delegate method prototype that
        ///     event receivers must implement 
        /// </summary>
        public delegate void DeepLoadingEventHandler(object sender, DeepSessionEventArgs e);
        
        /// <summary>
        ///     An event which occurs just before a data 
        ///     request is made in the data provider.
        /// </summary>
        public event DeepLoadingEventHandler DeepLoading;

        /// <summary>
        ///     This is the method that is responsible for notifying
        ///     receivers that the event occurred just after accessing the 
        ///     data provider.
        /// </summary>
        protected virtual void OnDeepLoading(DeepSessionEventArgs e)
        {
            if (DeepLoading != null)
            {
                DeepLoading(this, e);
            }
        }
        #endregion //('DeepLoading' event definition code)
		
		#region DeepSaving event definition code
        /// <summary>
        ///     This represents the delegate method prototype that
        ///     event receivers must implement 
        /// </summary>
        public delegate void DeepSavingEventHandler(object sender, DeepSessionEventArgs e);
        
        /// <summary>
        ///     An event which occurs just before a data 
        ///     request is made in the data provider.
        /// </summary>
        public event DeepSavingEventHandler DeepSaving;

        /// <summary>
        ///     This is the method that is responsible for notifying
        ///     receivers that the event occurred just after accessing the 
        ///     data provider.
        /// </summary>
        protected virtual void OnDeepSaving(DeepSessionEventArgs e)
        {
            if (DeepSaving != null)
            {
                DeepSaving(this, e);
            }
        }
        #endregion //('DeepSaving' event definition code)
	}

	#region DeepSessionEventArgs
	/// <summary>
    /// Event Args used to transfer crucial information just before 
    /// and after a command is used in the data provider.
    /// </summary>
    public class DeepSessionEventArgs
    {
        #region Fields
        private IList currentEntityList = null;
        private IEntity currentEntity = null;
        private bool cancel;
		private bool skip;
		private string currentTypePropertyKey = null;
		private DeepSession deepSession = null;
		private Enum deepTypeValue;
        #endregion 

        #region Ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DeepSessionEventArgs"/> class.
        /// </summary>
        public DeepSessionEventArgs() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DeepSessionEventArgs"/> class.
        /// </summary>
        /// <param name="deepSession">The Current Deep Session.</param>
		/// <param name="currentTypePropertyKey">The Current Key"</param>
		/// <param name="deepTypeValue">The current Deep Type Value, DeepSaveType/DeepLoadType </param>
        /// <param name="entity">The entity.</param>
        /// <param name="list">The list.</param>
        public DeepSessionEventArgs(DeepSession deepSession, string currentTypePropertyKey, Enum deepTypeValue, IEntity entity, IList list)
        {
            this.DeepSession = deepSession;
            this.CurrentTypePropertyKey = currentTypePropertyKey;
		    this.CurrentEntity = entity;
            this.CurrentEntityList = list;	
			this.DeepTypeValue = deepTypeValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommandEventArgs"/> class.
        /// </summary>
        /// <param name="deepSession">The deepSession.</param>
		/// <param name="currentTypePropertyKey">The Current Key"</param>
		/// <param name="deepTypeValue">The current Deep Type Value, DeepSaveType/DeepLoadType </param>
		/// <param name="list">The list.</param>
        public DeepSessionEventArgs(DeepSession deepSession, string currentTypePropertyKey, Enum deepTypeValue, IList list) : this(deepSession, currentTypePropertyKey, deepTypeValue, null, list)
        { }
		
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommandEventArgs"/> class.
        /// </summary>
        /// <param name="deepSession">The deepSession.</param>
		/// <param name="currentTypePropertyKey">The Current Key.</param>
		/// <param name="deepTypeValue">The current Deep Type Value, DeepSaveType/DeepLoadType </param>
        /// <param name="entity">The current entity.</param>
        public DeepSessionEventArgs(DeepSession deepSession, string currentTypePropertyKey, Enum deepTypeValue, IEntity entity) : this(deepSession, currentTypePropertyKey, deepTypeValue, entity, null)
        { }
        #endregion 

        #region Properties
        /// <summary>
        /// Gets or sets the current DeepSession.
        /// </summary>
        /// <value>The DeepSession.</value>
        public DeepSession DeepSession
        {
            get { return deepSession; }
            set { deepSession = value; }
        }

        /// <summary>
        /// Gets or sets the current entity which the action is 
        /// being acted on.  If there is no entity, this 
        /// value will be null.
        /// </summary>
        /// <value>The entity.</value>
        public IEntity CurrentEntity
        {
            get { return currentEntity; }
            set { currentEntity = value; }
        }

        /// <summary>
        /// Gets or sets the current .
        /// </summary>
        /// <value>The return value.</value>
        public IList CurrentEntityList
        {
            get {   return currentEntityList; }
            set {   currentEntityList = value; }
        }
		
		/// <summary>
        /// Gets or Sets the name of the current type property key that 
		/// will be used to determine if the property will be run in the deep session.
        /// </summary>
        /// <value>A string value of the type property key.</value>
		public string CurrentTypePropertyKey
		{
			get  {  return 	currentTypePropertyKey;  }
			set  {  currentTypePropertyKey = value;  }
		}
		
		
		///<summary>
		/// The current DeepType Value, Either <c>DeepLoadType</c>, or <c>DeepSaveType</c>.
		///</summary>
		public Enum DeepTypeValue
		{
			get  {  return 	deepTypeValue;  }
			set  {  deepTypeValue = value;  }
		}
		
		/// <summary>
        /// Gets or sets the Cancel property of the event.
        /// </summary>
        /// <value>Current Cancel Value.</value>
        public bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }
		
		/// <summary>
        /// Gets or sets the current Skip value.  
		/// Setting this property will skip the current Deep Property.
        /// </summary>
        /// <value>The name of the method.</value>
        public bool Skip
        {
            get { return skip; }
            set { skip = value; }
        }
        #endregion 
    }
	#endregion 

    #region CommandEventArgs
    /// <summary>
    /// Event Args used to transfer crucial information just before 
    /// and after a command is used in the data provider.
    /// </summary>
    public class CommandEventArgs
    {
        #region Fields
        private IList currentEntityList = null;
        private IEntity currentEntity = null;
        private System.Data.Common.DbCommand command;
        private string methodName = null;
        #endregion 

        #region Ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommandEventArgs"/> class.
        /// </summary>
        public CommandEventArgs() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommandEventArgs"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="list">The list.</param>
        public CommandEventArgs(System.Data.Common.DbCommand command, string methodName, IEntity entity, IList list)
        {
            this.Command = command;
            this.MethodName = methodName;
            this.CurrentEntity = entity;
            this.CurrentEntityList = list;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommandEventArgs"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="list">The list.</param>
        public CommandEventArgs(System.Data.Common.DbCommand command, string methodName, IList list) : this(command, methodName, null, list)
        { }
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:CommandEventArgs"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="methodName">Name of the method.</param>
        public CommandEventArgs(System.Data.Common.DbCommand command, string methodName) : this(command, methodName, null, null)
        { }
		
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommandEventArgs"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="entity">The current entity.</param>
        public CommandEventArgs(System.Data.Common.DbCommand command, string methodName, IEntity entity) : this(command, methodName, entity, null)
        { }
        #endregion 

        #region Properties
        /// <summary>
        /// Gets or sets the current command.
        /// </summary>
        /// <value>The command.</value>
        public System.Data.Common.DbCommand Command
        {
            get { return command; }
            set { command = value; }
        }

        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        /// <value>The name of the method.</value>
        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; }
        }

        /// <summary>
        /// Gets or sets the current entity which the action is 
        /// being acted on.  If there is no entity, this 
        /// value will be null.
        /// </summary>
        /// <value>The entity.</value>
        public IEntity CurrentEntity
        {
            get { return currentEntity; }
            set { currentEntity = value; }
        }

        /// <summary>
        /// Gets or sets the current .
        /// </summary>
        /// <value>The return value.</value>
        public IList CurrentEntityList
        {
            get {   return currentEntityList; }
            set {   currentEntityList = value; }
        }
        #endregion 
    }
    #endregion 
		
	#region DeepSession
	
	/// <summary>
	/// Keeps a weak reference of the entire deep transaction for tracking purposes.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class DeepSession : List<String>, IDisposable
    {
        private WeakRefDictionary<string, object> deepSessionInnerList;
		private bool cancelSession;
		private bool skipChildren;
		
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DeepSession"/> class.
        /// </summary>
        public DeepSession()
        { 
        }

        #region Methods
		/// <summary>
		/// Gets the set of current loaded objects.
		/// </summary>
		/// <returns>a list of already run objects</returns>
		public IList<object> GetSessionObjects()
		{
			List<object> list = new List<object>();

            foreach (KeyValuePair<string, object> pair in DeepSessionInnerList)
			{
				if (pair.Value != null)
					list.Add(pair.Value);
			}
			return list;
		}

	    /// <summary>
        /// Adds the specified entity property to the collection of properties.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="key"></param>
        public void AddRun( Object entity, string key )
        {
            if (entity != null && !string.IsNullOrEmpty(key))
            {
                string lkey;
                if (entity is IEntity)
                    lkey = ((IEntity)entity).EntityTrackingKey + key;
                else 
                    lkey = entity.GetHashCode().ToString()+ key;

                DeepSessionInnerList.Add(lkey, entity);
            }
			
			if (DeepSessionInnerList.Count > 300)
				CancelSession = true;
        }

        /// <summary>
        /// Determines whether the specified obj has run for a specified property type.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified obj has run; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsType(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key"); 

            string lkey = key.Split('|')[0];
		   if (SkipChildren && lkey.StartsWith("List<"))
				return false;
           
		   return this.Exists(delegate(string s)
           {
                return s.Split('|')[0] == lkey;
           });
        }
	    
		/// <summary>
        /// Determines whether the specified obj has run for a specified property type.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified obj has run; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsTypeExcluded(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key"); 

           string lkey = key.Split('|')[0];
		   if (SkipChildren && lkey.StartsWith("List<"))
				return true;
           
           return this.Exists(delegate(string s)
           {
                return s.Split('|')[0] == lkey;
           });
        }
	    
		/// <summary>
		/// Determines whether the specified obj has run.
		/// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="key">The key.</param>
		/// <returns>
		/// 	<c>true</c> if the specified obj has run; otherwise, <c>false</c>.
		/// </returns>
		public bool HasRun( object entity , string key)
		{
			if (entity == null) return false;

            string lkey;
            if (entity is IEntity)
                lkey = ((IEntity)entity).EntityTrackingKey + key;
            else 
                lkey = entity.GetHashCode().ToString()+ key;
				
            if (DeepSessionInnerList.ContainsKey(lkey))
                return true;
			    
			return false;
		}
		
		/// <summary>
        /// Get's the reference of the object that has run
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	object of the run reference
        /// </returns>
        public object GetReference(object entity, string key)
        {
            if (entity == null) return false;

            string lkey = ((IEntity)entity).EntityTrackingKey + key;
            if (DeepSessionInnerList.ContainsKey(lkey))
            {
                object locateEntity = null;
                if (DeepSessionInnerList.TryGet(lkey, out locateEntity))
                {
                    return locateEntity;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the Deep Session nner list.
        /// </summary>
        /// <value>The inner list.</value>
        public WeakRefDictionary<string, object> DeepSessionInnerList
		{
			get 
			{
				if (deepSessionInnerList == null)
				{
                    deepSessionInnerList = new WeakRefDictionary<string, object>();
				}
                return deepSessionInnerList; 
			}
		}
		
		///<summary>
	    ///If set to true, any further requests for this deep session will be canceled.
	    ///</summary>
		public bool CancelSession
		{
			get{  return cancelSession;	 }
			set{  cancelSession = value; }
		}

	    ///<summary>
        ///If set to true, any further requests for this deep session requesting to Load a child collection will be skipped.
        ///</summary>
        public bool SkipChildren
        {
            get { return skipChildren; }
            set { skipChildren = value; }
        }
		
	    ///<summary>
	    ///Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	    ///</summary>
	    ///<filterpriority>2</filterpriority>
	    public void Dispose()
	    {
            if (deepSessionInnerList != null) 
			{
                //deepSessionInnerList.Clear();
                deepSessionInnerList = null;
			}
	    }
		#endregion Methods
    }
	
	
	#endregion DeepSession
	
	#region Deep Load/Save Handle Delegates
	    /// <summary>
		/// Handler for the deep save
		/// </summary>
		public delegate bool DeepSaveHandle<Entity>(
            TransactionManager transactionManager,  
            TList<Entity> entityList, 
            DeepSaveType saveType, 
            Type[] childTypes, 
            DeepSession list) 
        where Entity : IEntity, new();

		/// <summary>
		/// Handler for the single deep save
		/// </summary>
	    public delegate bool DeepSaveSingleHandle<Entity>(
            TransactionManager transactionManager,  
            Entity entity, 
            DeepSaveType saveType, 
            Type[] childTypes, 
            DeepSession list) 
        where Entity : IEntity, new();
		
		/// <summary>
		/// Handler for the deep load
		/// </summary>
    	public delegate void DeepLoadHandle<Entity>(
			TransactionManager transactionManager,
			TList<Entity> entityList,
			bool goDeep,
			DeepLoadType deepLoadType,
			Type[] childTypes,
			DeepSession list)
		where Entity : IEntity, new();
		
		/// <summary>
		/// Handler for the single deep load
		/// </summary>
		public delegate void DeepLoadSingleHandle<Entity>(
			TransactionManager transactionManager,
			Entity entity,
			bool goDeep,
			DeepLoadType deepLoadType,
			Type[] childTypes,
			DeepSession list)
		where Entity : IEntity, new();
	#endregion 

	#region ChildEntityTypeAttribute
	
	///<summary>
	/// Attribute used to decorate enumerations with underlying system type.
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ChildEntityTypeAttribute : System.Attribute
	{
		///<summary>
		/// Marks the underlying type of a child entity property.
		/// </summary>
		/// <param name="entityType">Type of the property to load.</param>
		public ChildEntityTypeAttribute(Type entityType)
		{
			this.entityType = entityType;
		}
		
		private readonly Type entityType;
		
		/// <summary>
		/// The underlying type for the ChildEntityTypes enumerations.
		/// </summary>
		public Type EntityType
		{
			get	{ return entityType; }
		}

		/// <summary>
		/// Gets the underlying system type for the specified enumeration value.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static Type GetType(Enum e)
		{
			ChildEntityTypeAttribute attribute = EntityHelper.GetAttribute<ChildEntityTypeAttribute>(e);
			Type propertyType = null;
			
			if ( attribute != null )
			{
				propertyType = attribute.EntityType;
			}

			return propertyType;
		}
	}
	
	#endregion ChildEntityTypeAttribute

	#region ChildEntityProperty<ChildEntityTypeEnum>

	/// <summary>
	/// Provides a common property used to access the child entity type enumeration value.
	/// </summary>
	public interface IChildEntityProperty
	{
		/// <summary>
		/// Gets the value of the ChildEntityType property.
		/// </summary>
		Enum ChildEntityType { get; }
	}
	
	/// <summary>
	/// A generic wrapper for the generated ChildEntityTypes enumerations.
	/// </summary>
	/// <typeparam name="ChildEntityTypesEnum"></typeparam>
	public class ChildEntityProperty<ChildEntityTypesEnum> : IChildEntityProperty
	{
		/// <summary>
		/// The Name member variable.
		/// </summary>
		private ChildEntityTypesEnum name;

		/// <summary>
		/// Gets or sets the Name property.
		/// </summary>
		public ChildEntityTypesEnum Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Gets the value of the ChildEntityType property.
		/// </summary>
		public Enum ChildEntityType
		{
			get { return Name as Enum; }
		}
	}

	#endregion ChildEntityProperty<ChildEntityTypeEnum>
}
