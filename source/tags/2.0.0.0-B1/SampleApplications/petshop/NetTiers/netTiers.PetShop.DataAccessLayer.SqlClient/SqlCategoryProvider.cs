#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;

using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;

#endregion

namespace netTiers.PetShop.DataAccessLayer.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="Category"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class SqlCategoryProvider: SqlCategoryProviderBase
	{
		public SqlCategoryProvider(string connectionString, bool useStoredProcedure, string providerInvariantName): base(connectionString, useStoredProcedure, providerInvariantName){}
	}
}