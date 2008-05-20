using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace netTiers.PetShop.Validation
{
   /// <summary>
   /// A List of broken rules.
   /// </summary>
   [Serializable()]
   public class BrokenRulesList : BindingList<BrokenRule>
   {

      /// <summary>
      /// Returns the firstRule <see cref="BrokenRule" /> object
      /// corresponding to the specified property.
      /// </summary>
      /// <param name="property">The name of the property affected by the rule.</param>
      /// <returns>
      /// The firstRule BrokenRule object corresponding to the specified property, or null if 
      /// there are no rules defined for the property.
      /// </returns>
      public BrokenRule GetFirstBrokenRule(string property)
      {
         foreach (BrokenRule item in this)
            if (item.Property == property)
               return item;
         return null;
      }

      /// <summary>
      /// Internal contructor
      /// </summary>
      internal BrokenRulesList()
      {
         // limit creation to this assembly
      }

      /// <summary>
      /// Add a broken rule to the list
      /// </summary>
      /// <param name="rule"><see cref="ValidationRuleInfo"/> object containing the details about the rule.</param>
      internal void Add(ValidationRuleInfo rule)
      {
         Remove(rule);
         Add(new BrokenRule(rule));

      }

      /// <summary>
      /// Removes a broken rule from the list
      /// </summary>
      /// <param name="rule"><see cref="ValidationRuleInfo"/> object containing the details about the rule.</param>
      internal void Remove(ValidationRuleInfo rule)
      {
         
         for (int index = Count - 1; index >= 0; index--)
            if (this[index].RuleName == rule.RuleName)
            {
               RemoveAt(index);
               break;
            }

      }

		/// <summary>
      /// Returns a string containing all of the broken rule descriptions for the specified property.
      /// </summary>
      /// <param name="propertyName">The name of the property to get the errors for.</param>
      /// <returns>String of the error descriptions</returns>
      public string GetPropertyErrorDescriptions(string propertyName)
      {
         System.Text.StringBuilder errorDescription = new System.Text.StringBuilder();
         bool firstRule = true;
         foreach (BrokenRule item in this)
         {
            if (string.IsNullOrEmpty(propertyName) || item.Property.Equals(propertyName))
            {
               if (firstRule)
                  firstRule = false;
               else
                  errorDescription.Append(Environment.NewLine);

               errorDescription.Append(item.Description);
            }
         }

         return errorDescription.ToString();
      }

      /// <summary>
      /// Returns the description of each broken rule separated by a new line.
      /// </summary>
      public override string ToString()
      {
         return GetPropertyErrorDescriptions(null);
      }
   }
}
