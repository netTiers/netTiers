using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Business.Validation
{
   /// <summary>
   /// Object representing a broken validation rule
   /// </summary>
   [Serializable()]
   public class BrokenRule
   {
      private string _ruleName;
      private string _description;
      private string _property;
	  
	  /// <summary>
	  /// Default parameterless constructor used by Reflection for Soap Serialization
	  /// </summary>
	  private BrokenRule()
	  {
		 // used by Reflection.
	  }
	
      /// <summary>
      /// Creates a instance of the object.
      /// </summary>
      /// <param name="rule"><see cref="ValidationRuleInfo"/> containing the details about the rule that was broken.</param>
      internal BrokenRule(ValidationRuleInfo rule)
      {
         _ruleName = rule.RuleName;
         _description = rule.ValidationRuleArgs.Description;
         _property = rule.ValidationRuleArgs.PropertyName;
      }

      /// <summary>
      /// Provides access to the name of the broken rule.
      /// </summary>
      /// <value>The name of the rule.</value>
      public string RuleName
      {
         get { return _ruleName; }
      }

      /// <summary>
      /// The description of the broken rule.
      /// </summary>
      /// <value>The description of the rule.</value>
      public string Description
      {
         get { return _description; }
      }

      /// <summary>
      /// The name of the property affected by the broken rule.
      /// </summary>
      /// <value>The property affected by the rule.</value>
      public string Property
      {
         get { return _property; }
      }
   }
}
