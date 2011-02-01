﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="OrderStatusTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderStatusTypeProviderBase : OrderStatusTypeProviderBaseCore
	{
	} // end class
} // end namespace