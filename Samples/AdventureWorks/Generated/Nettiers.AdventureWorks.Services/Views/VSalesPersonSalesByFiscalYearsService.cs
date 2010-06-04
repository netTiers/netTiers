
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
	/// An component type implementation of the 'vSalesPersonSalesByFiscalYears' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class VSalesPersonSalesByFiscalYearsService : Nettiers.AdventureWorks.Services.VSalesPersonSalesByFiscalYearsServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsService class.
		/// </summary>
		public VSalesPersonSalesByFiscalYearsService() : base()
		{
		}
		
	}//End Class


} // end namespace
