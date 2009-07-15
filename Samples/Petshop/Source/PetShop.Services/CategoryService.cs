	

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
	/// An component type implementation of the 'Category' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CategoryService : PetShop.Services.CategoryServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CategoryService class.
		/// </summary>
		public CategoryService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
