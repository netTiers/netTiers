using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Business
{
    /// <summary>
    /// Exposes a factory to create an entity based on a typeString and a default type.
    /// </summary>
    public interface IEntityFactory
    {
        /// <summary>
        /// Create an entity based on a string.  
        /// It will autodiscover the type based on any information we can gather.
        /// </summary>
        /// <param name="typeString">string of entity to discover and create</param>
        /// <param name="defaultType">if string is not found defaultType will be created.</param>
        /// <returns>Created IEntity object</returns>
        IEntity CreateEntity(string typeString, Type defaultType);

        /// <summary>
        /// Create a readonly entity based on a string for views.  
        /// It will autodiscover the type based on any information we can gather.
        /// </summary>
        /// <param name="typeString">string of entity to discover and create</param>
        /// <param name="defaultType">if string is not found defaultType will be created.</param>
        /// <returns>Created IEntity object</returns>
        Object CreateViewEntity(string typeString, Type defaultType);
		
        /// <summary>
        /// Gets the current assembly responsible for entity creation.
        /// </summary>
        /// <value>The current assembly.</value>
        System.Reflection.Assembly CurrentEntityAssembly { get; set;}
    }
}
