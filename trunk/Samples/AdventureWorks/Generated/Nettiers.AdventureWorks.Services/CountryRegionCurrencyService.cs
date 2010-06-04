	

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
	/// An component type implementation of the 'CountryRegionCurrency' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CountryRegionCurrencyService : Nettiers.AdventureWorks.Services.CountryRegionCurrencyServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyService class.
		/// </summary>
		public CountryRegionCurrencyService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
