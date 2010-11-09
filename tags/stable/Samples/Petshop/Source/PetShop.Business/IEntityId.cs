#region Using Directives
#endregion

namespace PetShop.Business
{
	/// <summary>
	/// Defines a common property which represents the
	/// unique identifier for a business object.
	/// </summary>
	/// <typeparam name="EntityKey">The value type or
	/// class to be used for the EntityId property.</typeparam>
	public interface IEntityId<EntityKey> : IEntity where EntityKey : IEntityKey, new()
	{
		/// <summary>
		/// Gets or sets the value of the unique identifier
		/// for the current business object.
		/// </summary>
		EntityKey EntityId { get; set; }
	}
}
