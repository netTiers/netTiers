﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PetShop.Business;
#endregion

namespace PetShop.Data
{
	/// <summary>
	/// Defines the common data access methods that can be used by the
	/// ProviderDataSource control to interact with the underlying data store.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the EntityId
	/// property of the specified business object class.</typeparam>
	public interface IEntityProvider<Entity, EntityKey>
		where Entity : IEntityId<EntityKey>, new()
		where EntityKey : IEntityKey, new()
	{
		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		Entity Get(EntityKey key);

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetAll();

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetPaged(String whereClause, String orderBy, int start, int pageLength, out int count);

		/// <summary>
		/// Inserts a row into the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Insert(Entity entity);

		/// <summary>
		/// Updates an existing row in the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Update(Entity entity);

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Delete(Entity entity);

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		Entity Save(Entity entity);

		/// <summary>
		/// Deep Save the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		bool DeepSave(Entity entity);
		
		#region Full Implementation
		/*
		#region Get Methods

		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		Entity Get(EntityKey key);

		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		Entity Get(TransactionManager mgr, EntityKey key);

		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		Entity Get(EntityKey key, int start, int pageLength);

		/// <summary>
		/// Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		Entity Get(TransactionManager mgr, EntityKey key, int start, int pageLength);

		#endregion

		#region GetAll Methods

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetAll();

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetAll(TransactionManager mgr);

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetAll(int start, int pageLength);

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetAll(TransactionManager mgr, int start, int pageLength);

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetAll(int start, int pageLength, out int count);

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetAll(TransactionManager mgr, int start, int pageLength, out int count);

		#endregion

		#region GetPaged Methods

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetPaged(out int count);

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetPaged(TransactionManager mgr, out int count);

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetPaged(int start, int pageLength, out int count);

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetPaged(TransactionManager mgr, int start, int pageLength, out int count);

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		TList<Entity> GetPaged(String whereClause, String orderBy, int start, int pageLength, out int count);

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
		TList<Entity> GetPaged(TransactionManager mgr, String whereClause, String orderBy, int start, int pageLength, out int count);

		/// <summary>
		/// Gets the number of rows in the DataSource that match the specified whereClause.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns the number of rows.</returns>
		int GetTotalItems(String whereClause, out int count);

		/// <summary>
		/// Gets the number of rows in the DataSource that match the specified whereClause.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns the number of rows.</returns>
		int GetTotalItems(TransactionManager mgr, String whereClause, out int count);

		#endregion

		#region Insert Methods

		/// <summary>
		/// Inserts a row into the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Insert(Entity entity);

		/// <summary>
		/// Inserts a row into the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Insert(TransactionManager mgr, Entity entity);

		/// <summary>
		/// Inserts rows into the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to insert.</param>
		/// <returns>Returns the number of rows successfully inserted.</returns>
		int Insert(TList<Entity> entities);

		/// <summary>
		/// Inserts rows into the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to insert.</param>
		/// <returns>Returns the number of rows successfully inserted.</returns>
		int Insert(TransactionManager mgr, TList<Entity> entities);

		/// <summary>
		/// Efficiently inserts multiple rows into the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to insert.</param>
		void BulkInsert(TList<Entity> entities);

		/// <summary>
		/// Efficiently inserts multiple rows into the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to insert.</param>
		void BulkInsert(TransactionManager mgr, TList<Entity> entities);

		#endregion

		#region Update Methods

		/// <summary>
		/// Updates an existing row in the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Update(Entity entity);

		/// <summary>
		/// Updates an existing row in the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Update(TransactionManager mgr, Entity entity);

		/// <summary>
		/// Updates existing rows in the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to update.</param>
		/// <returns>Returns the number of rows successfully updated.</returns>
		int Update(TList<Entity> entities);

		/// <summary>
		/// Updates existing rows in the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to update.</param>
		/// <returns>Returns the number of rows successfully updated.</returns>
		int Update(TransactionManager mgr, TList<Entity> entities);

		#endregion

		#region Save Methods

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		void Save(Entity entity);

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to save.</param>
		void Save(TransactionManager mgr, Entity entity);

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="entities">TList of Entity objects to save.</param>
		void Save(TList<Entity> entities);

		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to save.</param>
		void Save(TransactionManager mgr, TList<Entity> entities);

		#endregion

		#region Delete Methods

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Delete(Entity entity);

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Delete(TransactionManager mgr, Entity entity);

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Delete(EntityKey key);

		/// <summary>
		/// Deletes a row from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		bool Delete(TransactionManager mgr, EntityKey key);

		/// <summary>
		/// Deletes rows from the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to delete.</param>
		/// <returns>Returns the number of rows successfully deleted.</returns>
		int Delete(TList<Entity> entities);

		/// <summary>
		/// Deletes rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to delete.</param>
		/// <returns>Returns the number of rows successfully deleted.</returns>
		int Delete(TransactionManager mgr, TList<Entity> entities);

		#endregion

		#region DeepLoad Methods

		/// <summary>
		/// Deep Load the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entity">The Entity object to load.</param>
		void DeepLoad(Entity entity);

		/// <summary>
		/// Deep Load the Entity object with all of the child property collections N levels deep.
		/// </summary>
		/// <param name="entity">The Entity object to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		void DeepLoad(Entity entity, bool deep);

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
		void DeepLoad(Entity entity, bool deep, DeepLoadType deepLoadType, params Type[] childTypes);

		/// <summary>
		/// Deep Load the Entity objects with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entities">TList of Entity objects to load.</param>
		void DeepLoad(TList<Entity> entities);

		/// <summary>
		/// Deep Load the Entity objects with all of the child property collections N levels deep.
		/// </summary>
		/// <param name="entities">TList of Entity objects to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		void DeepLoad(TList<Entity> entities, bool deep);

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
		void DeepLoad(TList<Entity> entities, bool deep, DeepLoadType deepLoadType, params Type[] childTypes);

		#endregion

		#region DeepSave Methods

		/// <summary>
		/// Deep Save the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		bool DeepSave(Entity entity);

		/// <summary>
		/// Deep Save the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to save.</param>
		bool DeepSave(TransactionManager mgr, Entity entity);

		/// <summary>
		/// Deep Save the entire Entity object with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		bool DeepSave(Entity entity, DeepSaveType deepSaveType, params Type[] childTypes);

		/// <summary>
		/// Deep Save the entire Entity object with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entity">The Entity object to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		bool DeepSave(TransactionManager mgr, Entity entity, DeepSaveType deepSaveType, params Type[] childTypes);

		/// <summary>
		/// Deep Save the Entity objects with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entities">TList of Entity objects to save.</param>
		bool DeepSave(TList<Entity> entities);

		/// <summary>
		/// Deep Save the Entity objects with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to save.</param>
		bool DeepSave(TransactionManager mgr, TList<Entity> entities);

		/// <summary>
		/// Deep Save the Entity objects with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="entities">TList of Entity objects to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		bool DeepSave(Northwind.BLL.TList<Entity> entities, DeepSaveType deepSaveType, params Type[] childTypes);

		/// <summary>
		/// Deep Save the Entity objects with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="entities">TList of Entity objects to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		bool DeepSave(TransactionManager mgr, TList<Entity> entities, DeepSaveType deepSaveType, params Type[] childTypes);

		#endregion
		*/
		#endregion
	}
}
