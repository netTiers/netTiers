#region Using Directives
using System;
using System.Collections;
using System.Web.UI.WebControls;
#endregion

namespace Nettiers.AdventureWorks.Web.Data
{
	/// <summary>
	/// Provides access to the collection of data provided by this control.
	/// </summary>
	[CLSCompliant(true)]
	public interface IListDataSource
	{
		/// <summary>
		/// Gets a reference to the current list of entities.
		/// </summary>
		/// <returns>The current list of entities if present, otherwise
		/// the data will be retreived by the Provider and cached for future use.</returns>
		IEnumerable GetEntityList();
	}

	/// <summary>
	/// Provides the functionality needed by the various relationship manager web controls.
	/// </summary>
	[CLSCompliant(true)]
	public interface ILinkedDataSource : IListDataSource
	{
		#region Properties

		#endregion Properties

		#region Methods

		/// <summary>
		/// Performs the ExecuteInsert operation using the specified name/value pairs.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> object.</param>
		/// <returns>The number of rows successfully inserted.</returns>
		int Insert(IDictionary values);

		/// <summary>
		/// Performs the ExecuteUpdate operation on the specified Entity object
		/// using the supplied name/value pairs.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <param name="values">An <see cref="IDictionary"/> object.</param>
		/// <returns>The number of rows successfully updated.</returns>
		int Update(Object entity, IDictionary values);

		/// <summary>
		/// Performs the ExecuteDelete operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>The number of rows successfully deleted.</returns>
		int Delete(Object entity);

		/// <summary>
		/// Gets a specific entry from the cached list of entities
		/// based on the value of the EntityIndex property.
		/// </summary>
		/// <returns>The current business object.</returns>
		Object GetCurrentEntity();

		/// <summary>
		/// Gets a comma-separated-list of values representing the
		/// current entity's unique identifier.
		/// </summary>
		/// <returns>Returns a comma-separated-list of values.</returns>
		String GetSelectedEntityId();

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		void DeepLoad();

		#endregion Methods

		#region Events

		/// <summary>
		/// Occurs when a select operation has completed.
		/// </summary>
		event LinkedDataSourceEventHandler AfterSelected;

		/// <summary>
		/// Occurs before an insert operation.
		/// </summary>
		event LinkedDataSourceEventHandler AfterInserting;

		/// <summary>
		/// Occurs when an insert operation has completed.
		/// </summary>
		event LinkedDataSourceEventHandler AfterInserted;

		/// <summary>
		/// Occurs before an update operation.
		/// </summary>
		event LinkedDataSourceEventHandler AfterUpdating;

		/// <summary>
		/// Occurs when an update operation has completed.
		/// </summary>
		event LinkedDataSourceEventHandler AfterUpdated;

		#endregion Events
	}

	/// <summary>
	/// Provides access to common data source control events.
	/// </summary>
	[CLSCompliant(true)]
	public interface IDataSourceEvents
	{
		#region Events

		/// <summary>
		/// Occurs before a select operation.
		/// </summary>
		event ObjectDataSourceSelectingEventHandler Selecting;

		/// <summary>
		/// Occurs when a select operation has completed.
		/// </summary>
		event ObjectDataSourceStatusEventHandler Selected;

		/// <summary>
		/// Occurs before an insert operation.
		/// </summary>
		event ObjectDataSourceMethodEventHandler Inserting;

		/// <summary>
		/// Occurs when an insert operation has completed.
		/// </summary>
		event ObjectDataSourceStatusEventHandler Inserted;

		/// <summary>
		/// Occurs before an update operation
		/// </summary>
		event ObjectDataSourceMethodEventHandler Updating;

		/// <summary>
		/// Occurs when an update operation has completed.
		/// </summary>
		event ObjectDataSourceStatusEventHandler Updated;

		/// <summary>
		/// Occurs before a delete operation.
		/// </summary>
		event ObjectDataSourceMethodEventHandler Deleting;

		/// <summary>
		/// Occurs when a delete operation has completed.
		/// </summary>
		event ObjectDataSourceStatusEventHandler Deleted;

		#endregion Events
	}

	/// <summary>
	/// Represents the method that will handle the <see cref="ILinkedDataSource"/> control's events.
	/// </summary>
	public delegate void LinkedDataSourceEventHandler(object sender, LinkedDataSourceEventArgs e);

	/// <summary>
	/// Provides data for the <see cref="ILinkedDataSource"/> control's events.
	/// </summary>
	public class LinkedDataSourceEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the LinkedDataSourceEventArgs class.
		/// </summary>
		/// <param name="entity">The current business object.</param>
		/// <param name="inputParameters">An IDictionary of name/value pairs.</param>
		/// <param name="index">The current position of the specified entity within the collection.</param>
		public LinkedDataSourceEventArgs(object entity, IDictionary inputParameters, int index)
		{
			Entity = entity;
			InputParameters = inputParameters;
			Index = index;
		}

		#region Properties

		/// <summary>
		/// The Entity member variable.
		/// </summary>
		private object _entity;

		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public object Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}

		/// <summary>
		/// The InputParameters member variable.
		/// </summary>
		private IDictionary inputParameters;

		/// <summary>
		/// Gets or sets the InputParameters property.
		/// </summary>
		public IDictionary InputParameters
		{
			get { return inputParameters; }
			set { inputParameters = value; }
		}

		/// <summary>
		/// The Index member variable.
		/// </summary>
		private int _index;

		/// <summary>
		/// Gets or sets the Index property.
		/// </summary>
		public int Index
		{
			get { return _index; }
			set { _index = value; }
		}

		#endregion Properties
	}
}
