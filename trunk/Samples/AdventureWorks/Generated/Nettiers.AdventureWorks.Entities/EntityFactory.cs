
using System;
using System.Collections;
using System.Reflection;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
    /// Entity Factory provides methods to create entity types from type names as strings.
    /// </summary>
    public partial class EntityFactory : EntityFactoryBase, IEntityFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFactory"/> class.
        /// </summary>
        public EntityFactory()
        {
            base.CurrentEntityAssembly = typeof(EntityFactory).Assembly;
        }
    }
}
