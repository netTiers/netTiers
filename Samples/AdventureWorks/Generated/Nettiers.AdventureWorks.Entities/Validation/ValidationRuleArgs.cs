using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Nettiers.AdventureWorks.Entities.Validation
{
   /// <summary>
   /// Object that provides additional information about an validation rule.
   /// </summary>
   public class ValidationRuleArgs
   {
    	private string _propertyName;
      	private string _description;
		private object _tag;
		private string _friendlyName;

		/// <summary>
		/// Gets or sets the tag.
		/// </summary>
		/// <value>The tag.</value>
		[XmlIgnore]
		public object Tag
		{
			get { return _tag; }
			set { _tag = value; }
		}
		
		/// <summary>
		/// The name of the property to be validated.
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
		}
	
		/// <summary>
		/// Detailed description of why the rule was invalidated.  This should be set from the method handling the rule.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Friendly name to use in the validation error text.
		/// </summary>
		public string FriendlyName
		{
			get { return _friendlyName; }
			set { _friendlyName = value; }
		}
		
		/// <summary>
		/// Creates an instance of the object
		/// </summary>
		/// <param name="propertyName">The name of the property to be validated.</param>
		public ValidationRuleArgs(string propertyName)
		{
			_propertyName = propertyName;
			_friendlyName = propertyName;
		}

		/// <summary>
		/// Creates an instance of the object
		/// </summary>
		/// <param name="propertyName">The name of the property to be validated.</param>
		/// <param name="friendlyName">Friendly name to use in the validation error text.</param>
		public ValidationRuleArgs(string propertyName, string friendlyName)
		{
			_propertyName = propertyName;
			_friendlyName = friendlyName;
		}
		
		/// <summary>
		/// Return a string representation of the object.
		/// </summary>
		public override string ToString()
		{
			return _propertyName;
		}
   }
}
