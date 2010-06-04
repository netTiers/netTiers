
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;

namespace Nettiers.AdventureWorks.Contracts
{
    /// <summary>
    /// Security Behaviour Extension Element class
    /// </summary>
    public class SecurityBehaviorExtensionElement : BehaviorExtensionElement
    {
        /// <summary>
        /// Create Behavior
        /// </summary>
        /// <returns>object</returns>
        protected override object CreateBehavior()
        {
            return new SecurityEndpointBehavior();
        }

        /// <summary>
        /// BehaviorType
        /// </summary>
        public override Type BehaviorType
        {
            get
            {
                return typeof(SecurityEndpointBehavior);
            }
        }

    }
}