	

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
	/// An component type implementation of the 'StateProvince' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class StateProvinceService : Nettiers.AdventureWorks.Services.StateProvinceServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the StateProvinceService class.
		/// </summary>
		public StateProvinceService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
