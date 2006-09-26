
	

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
	/// An component type implementation of the 'ExtendedItem' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ExtendedItemService : netTiers.Petshop.Services.ExtendedItemServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ExtendedItemService class.
		/// </summary>
		public ExtendedItemService() : base()
		{
		}
		
	}//End Class


} // end namespace
