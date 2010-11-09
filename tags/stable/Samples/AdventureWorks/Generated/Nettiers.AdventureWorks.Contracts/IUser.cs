
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nettiers.AdventureWorks.Contracts
{
    /// <summary>
    /// IUser interface.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// UserId
        /// </summary>
        int? UserID { get; set; }
        
        /// <summary>
        /// Username
        /// </summary>
        string UserName { get; set; }
    }
}