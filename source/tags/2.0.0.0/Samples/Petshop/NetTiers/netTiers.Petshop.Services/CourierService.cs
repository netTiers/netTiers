	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Entities.Validation;

using netTiers.Petshop.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace netTiers.Petshop.Services
{		
	
	///<summary>
	/// An component type implementation of the 'Courier' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CourierService : netTiers.Petshop.Services.CourierServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the CourierService class.
		/// </summary>
		public CourierService() : base()
		{
		}
		
	}//End Class


} // end namespace
