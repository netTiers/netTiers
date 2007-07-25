#region Using Directives
using System;
#endregion

namespace netTiers.Petshop.Data.Bases
{
	/// <summary>
	/// Serves as the base class for objects that provide data access functionality.
	/// Provides a default implementation of the IEntityViewProvider&lt;Entity&gt; interface.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>
	[Serializable]
	[CLSCompliant(true)]
	public abstract partial class EntityViewProviderBase<Entity> : EntityViewProviderBaseCore<Entity>
		where Entity : new()
	{

	}
}
