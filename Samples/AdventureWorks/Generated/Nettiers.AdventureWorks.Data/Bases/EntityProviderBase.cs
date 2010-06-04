#region Using Directives
using System;
using Nettiers.AdventureWorks.Entities;
#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{
	/// <summary>
	/// Serves as the base class for objects that provide data access functionality.
	/// Provides a default implementation of the IEntityProvider&lt;Entity, EntityKey&gt; interface.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the EntityId
	/// property of the specified business object class.</typeparam>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>
	[Serializable]
	[CLSCompliant(true)]
	public abstract partial class EntityProviderBase<Entity, EntityKey> : EntityProviderBaseCore<Entity, EntityKey>
		where Entity : IEntityId<EntityKey>, new()
		where EntityKey : IEntityKey, new()
	{

	}
}
