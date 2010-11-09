#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.WebServiceClient
{
	///<summary>
	/// This class is the WebServiceClient Data Access Logic Component implementation for the <see cref="Document"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class WsDocumentProvider: WsDocumentProviderBase
	{		
		/// <summary>
		/// Creates a new <see cref="WsDocumentProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsDocumentProvider(string url): base(url){}
	}
}
