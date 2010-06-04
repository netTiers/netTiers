
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;

namespace Nettiers.AdventureWorks.Contracts
{
    /// <summary>
    /// Security Endpoint Behavior class
    /// </summary>
    public class SecurityEndpointBehavior : IEndpointBehavior
    {
        #region IEndpointBehavior Members

        /// <summary>
        /// Add Binding Parameters
        /// </summary>
        /// <param name="endpoint">End point</param>
        /// <param name="bindingParameters">Binding parameters</param>
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Apply Client Behavior
        /// </summary>
        /// <param name="endpoint">End point</param>
        /// <param name="clientRuntime">Client runtime</param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new SecurityMessageInspector());
        }

        /// <summary>
        /// Apply Dispatch Behavior
        /// </summary>
        /// <param name="endpoint">End point</param>
        /// <param name="endpointDispatcher">End point dispatcher</param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="endpoint">End point</param>
        public void Validate(ServiceEndpoint endpoint)
        {
        }

        #endregion
    }
}