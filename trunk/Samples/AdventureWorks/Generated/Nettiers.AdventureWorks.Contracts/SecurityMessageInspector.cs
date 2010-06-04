
using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.Threading;

namespace Nettiers.AdventureWorks.Contracts
{
    /// <summary>
    /// The Security Message Inspector
    /// </summary>
    public class SecurityMessageInspector : IClientMessageInspector
    {
        #region IClientMessageInspector Members
        
        /// <summary>
        /// AfterReceiveReply executes after a reply has been received from the channel
        /// </summary>
        /// <param name="reply">This parameter contains the reply from the channel</param>
        /// <param name="correlationState">This parameter contains the correlation state</param>
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }

        /// <summary>
        /// BeforeSendRequest executes before a reply has been sent to the channel
        /// </summary>
        /// <param name="request">This parameter contains the request to the channel</param>
        /// <param name="channel">The channel to send to</param>
        /// <returns>A return value</returns>
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            ExtendedPrincipal extendedPrincipal = Thread.CurrentPrincipal as ExtendedPrincipal;
            if (extendedPrincipal == null) return null;

            return null;
        }

        #endregion
    }
}