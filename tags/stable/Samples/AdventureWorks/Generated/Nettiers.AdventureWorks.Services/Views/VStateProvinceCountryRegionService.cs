
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
	
	///<summary>
	/// An component type implementation of the 'vStateProvinceCountryRegion' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class VStateProvinceCountryRegionService : Nettiers.AdventureWorks.Services.VStateProvinceCountryRegionServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionService class.
		/// </summary>
		public VStateProvinceCountryRegionService() : base()
		{
		}
		
	}//End Class


} // end namespace
