#region Using directives
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Validation;
#endregion Using directives

namespace Nettiers.AdventureWorks.Entities.Validation
{
	/// <summary>
	/// Property Validator Value Access Builder
	/// </summary>
	internal class PropertyValidatorValueAccessBuilder: MemberValueAccessBuilder
	{
        /// <summary>
        /// Does the get field value access.
        /// </summary>
        /// <param name="fieldInfo">The field info.</param>
        /// <returns></returns>
		protected override ValueAccess DoGetFieldValueAccess(FieldInfo fieldInfo)
		{
			throw new NotSupportedException();
		}

        /// <summary>
        /// Does the get method value access.
        /// </summary>
        /// <param name="methodInfo">The method info.</param>
        /// <returns></returns>
		protected override ValueAccess DoGetMethodValueAccess(MethodInfo methodInfo)
		{
			throw new NotSupportedException();
		}

        /// <summary>
        /// Does the get property value access.
        /// </summary>
        /// <param name="propertyInfo">The property info.</param>
        /// <returns></returns>
		protected override ValueAccess DoGetPropertyValueAccess(PropertyInfo propertyInfo)
		{
			return new PropertyValidatorValueAccess(propertyInfo.Name);
		}
	}
}
