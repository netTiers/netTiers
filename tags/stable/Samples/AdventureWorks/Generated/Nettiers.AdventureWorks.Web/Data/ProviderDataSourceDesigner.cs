#region Using Directives
using System;
using Nettiers.AdventureWorks.Entities;
#endregion

namespace Nettiers.AdventureWorks.Web.Data
{
	/// <summary>
	/// Provides design-time support in a design host for the ProviderDataSource class.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the EntityId
	/// property of the specified business object class.</typeparam>
	[Serializable]
	[CLSCompliant(true)]
	public abstract class ProviderDataSourceDesigner<Entity, EntityKey> : BaseDataSourceDesigner<Entity, EntityKey>
		where Entity : IEntityId<EntityKey>, new()
		where EntityKey : IEntityKey, new()
	{
		/// <summary>
		/// Initializes a new instance of the ProviderDataSourceDesigner class.
		/// </summary>
		public ProviderDataSourceDesigner()
		{
		}
	}
}
