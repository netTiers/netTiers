#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ExtendedItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ExtendedItemProviderBase : ExtendedItemProviderBaseCore
	{
	} // end class
} // end namespace
