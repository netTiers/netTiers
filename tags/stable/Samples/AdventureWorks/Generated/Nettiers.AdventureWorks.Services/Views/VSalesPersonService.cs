
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
	/// An component type implementation of the 'vSalesPerson' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class VSalesPersonService : Nettiers.AdventureWorks.Services.VSalesPersonServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the VSalesPersonService class.
		/// </summary>
		public VSalesPersonService() : base()
		{
		}
		
	}//End Class


} // end namespace
