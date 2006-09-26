	

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
	/// An component type implementation of the 'Supplier' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SupplierService : netTiers.Petshop.Services.SupplierServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the SupplierService class.
		/// </summary>
		public SupplierService() : base()
		{
		}
		
	}//End Class


} // end namespace
