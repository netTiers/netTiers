#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Validation;
#endregion Using directives

namespace Nettiers.AdventureWorks.Entities.Validation
{
	/// <summary>
	/// Property Validator Value Access
	/// </summary>
	internal class PropertyValidatorValueAccess : ValueAccess
	{
		#region Fields
		private string propertyName;
		#endregion Fields
		
		#region Properties
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
		public override string Key
		{
			get { return this.propertyName; }
		}
		
		#endregion Properties
		
		#region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PropertyValidatorValueAccess"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
		public PropertyValidatorValueAccess(string propertyName)
		{
			this.propertyName = propertyName;
		}
		#endregion Constructors
		
		#region Public methods
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <param name="valueAccessFailureMessage">The value access failure message.</param>
        /// <returns></returns>
		public override bool GetValue(object source, out object value, out string valueAccessFailureMessage)
		{
			value = null;
			valueAccessFailureMessage = null;

			PropertyValidator validator = source as PropertyValidator;

			if (this.propertyName.Equals(validator.PropertyName))
			{
				return validator.GetValue(out value, out valueAccessFailureMessage);
			}

			valueAccessFailureMessage = "Failed to access value of property.";
			return false;
		}
		#endregion Public methods
	}
}
