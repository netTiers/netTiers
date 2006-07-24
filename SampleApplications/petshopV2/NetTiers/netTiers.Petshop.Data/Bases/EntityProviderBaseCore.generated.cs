#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using netTiers.Petshop.Entities;
#endregion

namespace netTiers.Petshop.Data.Bases
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

		#region Find Functions
		
		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(string whereClause)
		{
			int count = -1;
			return Find(null, whereClause, 0, int.MaxValue, out count);
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
			return Find(null, whereClause, start, pageLength, out count);
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
			return Find(null, whereClause, start, pageLength, out count);
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
		
		#endregion "Find Functions"
		
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
		public virtual void Save(Entity entity)
		{
			Save(null, entity);
		}

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to save.</param>
		public virtual void Save(TransactionManager mgr, Entity entity)
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
		}

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="entities">TList of Entity objects to save.</param>
		public virtual void Save(TList<Entity> entities)
		{
			Save(null, entities);
		}

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to save.</param>
		public virtual void Save(TransactionManager mgr, TList<Entity> entities)
		{
			foreach ( Entity entity in entities )
			{
				Save(mgr, entity);
			}

			foreach ( Entity entity in entities.DeletedItems )
			{
				Delete(mgr, entity);
			}

			// Clear the items to delete list.
			entities.DeletedItems.Clear();
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

			//In case an event can trigger the disabling of the deep load
			if ( deepLoadType == DeepLoadType.Ignore )
			{
				return;
			}

			// create a collection of types for easy access
			ChildEntityTypesList innerList = new ChildEntityTypesList();
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
		internal abstract void DeepLoad(TransactionManager mgr, Entity entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList);

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
		internal void DeepLoad(TransactionManager mgr, TList<Entity> entities, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
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

			//Create a HashTable list of types for easy access
			// Loop in order for specific save order.
			Hashtable innerList = new Hashtable(childTypes.Length);
			for(int i=0; i < childTypes.Length; i++)
			{
				if (childTypes[i] == null) continue;
				
				if (!childTypes[i].IsGenericType)
					innerList.Add(childTypes[i].Name, childTypes[i]);
				else 
					innerList.Add(string.Format("List<{0}>" , childTypes[i].GetGenericArguments()[0].Name), childTypes[i]);
			}

			DeepSave(mgr, entity, deepSaveType, childTypes, innerList);
			
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
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal abstract void DeepSave(TransactionManager mgr, Entity entity, DeepSaveType deepSaveType, Type[] childTypes, Hashtable innerList);

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

			foreach ( Entity entity in entities )
			{
				result = DeepSave(mgr, entity, deepSaveType, childTypes);
				if ( !result )
				{
					deepSaveResult = false;
				}
			}

			foreach ( Entity entity in entities.DeletedItems )
			{
				result = DeepSave(mgr, entity, deepSaveType, childTypes);
				if ( !result )
				{
					deepSaveResult = false;
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
		protected bool CanDeepLoad(Object entity, String key, String property, DeepLoadType deepLoadType, ChildEntityTypesList innerList) 
        {
			if ( innerList != null )
			{
				if ( deepLoadType == DeepLoadType.ExcludeChildren )
				{
					if ( !innerList.Contains(key) && !innerList.HasEntityProperty(entity, property) )
					{
						innerList.AddEntityProperty(entity, property);
						return true;
					}
				}
				else if ( deepLoadType == DeepLoadType.IncludeChildren )
				{
					if ( innerList.Contains(key) && !innerList.HasEntityProperty(entity, property) )
					{
						innerList.AddEntityProperty(entity, property);
						return true;
					}
				}
			}

			return false;
        }
		
		///<summary>
		/// Enforces the rules set in order to save this property for a given type.
		///</summary>
		protected bool CanDeepSave(Object entity, String key, String property, DeepSaveType deepSaveType, ChildEntityTypesList innerList) 
        {
			if ( innerList != null )
			{
				if ( deepSaveType == DeepSaveType.ExcludeChildren )
				{
					if ( !innerList.Contains(key) && !innerList.HasEntityProperty(entity, property) )
					{
						innerList.AddEntityProperty(entity, property);
						return true;
					}
				}
				else if ( deepSaveType == DeepSaveType.IncludeChildren )
				{
					if ( innerList.Contains(key) && !innerList.HasEntityProperty(entity, property) )
					{
						innerList.AddEntityProperty(entity, property);
						return true;
					}
				}
			}

			return false;
        }

		#endregion Helper Methods
	}
	
	#region ChildEntityTypesList
	
	/// <summary>
	/// Represents a collection of child entity types.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ChildEntityTypesList : StringCollection
	{
		/// <summary>
		/// Initializes a new instance of the ChildEntityTypeList class.
		/// </summary>
		public ChildEntityTypesList()
		{
		}

		private Dictionary<int, StringCollection> properties;
		
		/// <summary>
		/// Gets a collection of child entity property names.
		/// </summary>
		public Dictionary<int, StringCollection> Properties
		{
			get
			{
				if ( properties == null )
				{
					properties = new Dictionary<int, StringCollection>();
				}
				
				return properties;
			}
		}

		/// <summary>
		/// Gets a collection of property names for the specified entity.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public StringCollection GetEntityProperties(Object entity)
		{
			if ( entity == null ) return null;
			int hashCode = entity.ToString().GetHashCode();

			if ( !Properties.ContainsKey(hashCode) )
			{
				Properties[hashCode] = new StringCollection();
			}

			return Properties[hashCode];
		}

		/// <summary>
		/// Gets a value indicating whether the specified entity property
		/// has been added to the collection of properties.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		/// <returns></returns>
		public bool HasEntityProperty(Object entity, String property)
		{
			if ( entity == null ) return false;
			return GetEntityProperties(entity).Contains(property);
		}

		/// <summary>
		/// Adds the specified entity property to the collection of properties.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		public void AddEntityProperty(Object entity, String property)
		{
			if ( entity == null ) return;
			GetEntityProperties(entity).Add(property);
		}
	}
	
	#endregion ChildEntityTypesList

	#region ChildEntityTypeAttribute
	
	///<summary>
	/// Attribute used to decorate enumerations with underlying system type.
	///</summary>
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
	}
	
	#endregion ChildEntityTypeAttribute
}
