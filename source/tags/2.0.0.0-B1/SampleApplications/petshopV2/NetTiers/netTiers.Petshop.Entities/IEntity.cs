using System;
using System.ComponentModel;

namespace netTiers.Petshop.Entities
{
	/// <summary>
    /// List of possible state for an entity.
    /// </summary>
	public enum EntityState
    {
        /// <summary>
        /// Entity is unchanged
        /// </summary>
        Unchanged=0, 

        /// <summary>
        /// Entity is new
        /// </summary>
        Added=1, 

        /// <summary>
        /// Entity has been modified
        /// </summary>
        Changed=2, 

        /// <summary>
        /// Entity has been deleted
        /// </summary>
        Deleted=3
    }
	
	/// <summary>
	/// The interface that each business object of the model implements.
	/// </summary>
	public interface IEntity
	{
		/// <summary>
		///	The name of the underlying database table.
		/// </summary>
		string TableName { get;}

		/// <summary>
		///	Indicates if the object has been modified from its original state.
		/// </summary>
		///<value>True if object has been modified from its original state; otherwise False;</value>
		bool IsDirty {get;}
		
		/// <summary>
		///	Indicates if the object is new.
		/// </summary>
		///<value>True if objectis new; otherwise False;</value>
		bool IsNew {get;}

		/// <summary>
		/// True if object has been marked as deleted. ReadOnly.
		/// </summary>
		bool IsDeleted {get;}

      /// <summary>
      /// Indicates if the object is in a valid state
      /// </summary>
      /// <value>True if object is valid; otherwise False.</value>
      bool IsValid { get;}
				
		/// <summary>
		/// Returns one of EntityState enum values - intended to replace IsNew, IsDirty, IsDeleted.
		/// </summary>
		EntityState EntityState {get;}
		
		/// <summary>
		/// Accepts the changes made to this object by setting each flags to false.
		/// </summary>
		void AcceptChanges();
		
		/// <summary>
		/// Marks entity to be deleted.
		/// </summary>
		void MarkToDelete();
				 
		/// <summary>
        /// Gets or sets the parent collection.
        /// </summary>
        /// <value>The parent collection.</value>
		object ParentCollection{get;set;}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		/// <value>A string array that holds the columns names.</value>
		string[] TableColumns {get;}
		
		/// <summary>
		/// 
		/// </summary>
		System.String Id{ get; }

		/// <summary>
		/// 
		/// </summary>
		System.Byte[] Timestamp{ get; }

		
		/// <summary>
		///     Gets or sets the object that contains supplemental data about this object.
		/// </summary>
		/// <value>Object</value>
		object Tag { get;set;}
		
		/// <summary>
      /// Event to indicate that a property has changed.
      /// </summary>
		event PropertyChangedEventHandler PropertyChanged;
		
		/// <summary>
		/// Determines whether this entity is being tracked.
		/// </summary>
		bool IsEntityTracked {	get;  set;	}
		
		///<summary>
		/// The tracking key used to with the <see cref="EntityLocator" />
		///</summary>
		string EntityTrackingKey {	get;  set;  }
	}
}
