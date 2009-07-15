	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using PetShop.Business;
using PetShop.Business.Validation;

using PetShop.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace PetShop.Services
{		
	/// <summary>
	/// An component type implementation of the 'Profiles' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ProfileService : PetShop.Services.ProfileServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ProfileService class.
		/// </summary>
		public ProfileService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
