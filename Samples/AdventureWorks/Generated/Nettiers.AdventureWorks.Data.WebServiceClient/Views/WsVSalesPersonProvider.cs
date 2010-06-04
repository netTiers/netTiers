
#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Entities;

#endregion

namespace Nettiers.AdventureWorks.Data.WebServiceClient
{
	///<summary>
	/// This class is the WebServiceClient Data Access Logic Component implementation for the <see cref="VSalesPerson"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class WsVSalesPersonProvider: WsVSalesPersonProviderBase
	{		
		/// <summary>
		/// Creates a new <see cref="WsVSalesPersonProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsVSalesPersonProvider(string url): base(url){}
	}
}
