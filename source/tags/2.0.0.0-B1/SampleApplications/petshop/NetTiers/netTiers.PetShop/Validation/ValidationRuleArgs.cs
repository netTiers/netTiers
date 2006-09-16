using System;
using System.Collections.Generic;
using System.Text;

namespace netTiers.PetShop.Validation
{
   /// <summary>
   /// Object that provides additional information about an validation rule.
   /// </summary>
   public class ValidationRuleArgs
   {
      private string _propertyName;
      private string _description;

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
      /// Creates an instance of the object
      /// </summary>
      /// <param name="propertyName">The name of the property to be validated.</param>
      public ValidationRuleArgs(string propertyName)
      {
         _propertyName = propertyName;
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
