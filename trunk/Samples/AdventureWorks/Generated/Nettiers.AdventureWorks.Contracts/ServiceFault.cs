
using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Contracts
{
    /// <summary>
    /// The ServiceFault class is responsible for handling any WCF Service Faults
    /// </summary>
    [DataContract(IsReference = true), Serializable]
    [DataObject, CLSCompliant(true)]
    public class ServiceFault
    {
        /// <summary>
        /// Arguments
        /// </summary>
        [DataMember]
        public int[] Arguments;

        /// <summary>
        /// ReferenceId
        /// </summary>
        [DataMember]
        public int ReferenceID;
    
        /// <summary>
        /// ReferenceGuid
        /// </summary>
        [DataMember]
        public Guid ReferenceGuid;

        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        public string Message;

    } // End Class

} // End Namespace
