	

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
	/// An component type implementation of the 'OrderStatus' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class OrderStatusService : netTiers.Petshop.Services.OrderStatusServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the OrderStatusService class.
		/// </summary>
		public OrderStatusService() : base()
		{
		}
		
	}//End Class


} // end namespace
