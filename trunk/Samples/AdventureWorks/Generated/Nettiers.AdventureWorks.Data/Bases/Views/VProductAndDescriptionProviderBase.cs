#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="VProductAndDescriptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VProductAndDescriptionProviderBase : VProductAndDescriptionProviderBaseCore
	{
	} // end class
} // end namespace
