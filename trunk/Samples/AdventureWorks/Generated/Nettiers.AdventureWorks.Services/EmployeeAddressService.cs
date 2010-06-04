	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Entities.Validation;

using Nettiers.AdventureWorks.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace Nettiers.AdventureWorks.Services
{		
	/// <summary>
	/// An component type implementation of the 'EmployeeAddress' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class EmployeeAddressService : Nettiers.AdventureWorks.Services.EmployeeAddressServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the EmployeeAddressService class.
		/// </summary>
		public EmployeeAddressService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
