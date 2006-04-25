using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

namespace netTiers.PetShop.Validation
{
   public static class CommonRules
   {
      #region NotNull

      /// <summary>
      /// Rule that does not allow a property value to be null
      /// </summary>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      /// <returns>Returns true if the property value is not null; false otherwise.</returns>
      public static bool NotNull(object target, ValidationRuleArgs e)
      {
         PropertyInfo p = target.GetType().GetProperty(e.PropertyName);

         if (p != null)
         {
            object value = p.GetValue(target, null);

            if ( value == null)
            {
               e.Description = string.Format("{0} can not be null.",e.PropertyName);
               return false;
            }

            return true;
         }
         else
         { 
            throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"",e.PropertyName,target.GetType().ToString()));
         }
      }

      #endregion

      #region StringRequired

      /// <summary>
      /// Rule ensuring a String value contains one or more
      /// characters.
      /// </summary>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      /// <remarks>
      /// This implementation uses late binding, and will only work
      /// against String property values.
      /// </remarks>
      public static bool StringRequired(object target, ValidationRuleArgs e)
      {
         PropertyInfo p = target.GetType().GetProperty(e.PropertyName);

         if (p != null)
         {
            string value = (string)p.GetValue(target,null);
            if (string.IsNullOrEmpty(value))
            {
               e.Description = e.PropertyName + " required";
               return false;
            }
            return true;
         }
         else
         { 
            throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"",e.PropertyName,target.GetType().ToString()));
         }
         
      }

      #endregion 

      #region StringMaxLength

      /// <summary>
      /// Rule ensuring a String value doesn't exceed
      /// a specified length.
      /// </summary>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      /// <remarks>
      /// This implementation uses late binding, and will only work
      /// against String property values.
      /// </remarks>
      public static bool StringMaxLength(object target, ValidationRuleArgs e)
      {
         MaxLengthRuleArgs args = e as MaxLengthRuleArgs;
         if (args != null)
         {
            int max = args.MaxLength;

            PropertyInfo p = target.GetType().GetProperty(e.PropertyName);

            if (p != null)
            {
               if (p.PropertyType == typeof(string))
               {
                  string value = (string)p.GetValue(target, null);

                  if (!String.IsNullOrEmpty(value) && (value.Length > max))
                  {
                     e.Description = String.Format(
                       "{0} can not exceed {1} characters",
                       e.PropertyName, max.ToString());
                     return false;
                  }
                  return true;
               }
               else 
               {
                  throw new ArgumentException(string.Format("Property \"{0}\" is not of type String.", e.PropertyName));
               }
            }
            else
            { 
               throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"",e.PropertyName,target.GetType().ToString()));
            }
         }
         else
         {
            throw new ArgumentException("Invalid ValidationRuleArgs.  e must be of type MaxLengthRuleArgs.");
         }

      }

      /// <summary>
      /// Class used with the <see cref="StringMaxLength"/>.
      /// </summary>
      public class MaxLengthRuleArgs : ValidationRuleArgs
      {
         private int _maxLength;

         /// <summary>
         /// Maximum length of the string property.
         /// </summary>
         public int MaxLength
         {
            get { return _maxLength; }
         }

         /// <summary>
         /// Constructor
         /// </summary>
         /// <param name="propertyName">Property to validate</param>
         /// <param name="maxLength">Max length of the property</param>
         public MaxLengthRuleArgs(
           string propertyName, int maxLength)
            : base(propertyName)
         {
            _maxLength = maxLength;
         }

         /// <summary>
         /// Return a string representation of the object.
         /// </summary>
         public override string ToString()
         {
            return base.ToString() + "!" + _maxLength.ToString();
         }
      }

      #endregion

	  #region RegexIsMatch

	  /// <summary>
      /// Rule ensuring a String value is matching
      /// a specified regular expression.
      /// </summary>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      /// <remarks>
      /// This implementation uses late binding, and will only work
      /// against String property values.
      /// </remarks>
	   public static bool RegexIsMatch(object target, ValidationRuleArgs e)
      {
         RegExpRuleArgs args = e as RegExpRuleArgs;
         if (args != null)
         {
            string expression = args.Expression;

            PropertyInfo p = target.GetType().GetProperty(e.PropertyName);

            if (p != null)
            {
               if (p.PropertyType == typeof(string))
               {
                  string value = (string)p.GetValue(target, null);

				  if (!Regex.IsMatch(expression, value))
                  {
                     e.Description = String.Format(
                       "{0} do not match the regular expression {1}",
                       e.PropertyName, expression);
                     return false;
                  }
                  return true;
               }
               else 
               {
                  throw new ArgumentException(string.Format("Property \"{0}\" is not of type String.", e.PropertyName));
               }
            }
            else
            { 
               throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"",e.PropertyName,target.GetType().ToString()));
            }
         }
         else
         {
            throw new ArgumentException("Invalid ValidationRuleArgs.  e must be of type RegExpRuleArgs.");
         }

      }

      /// <summary>
      /// Class used with the <see cref="RegExpRuleArgs"/>.
      /// </summary>
      public class RegExpRuleArgs : ValidationRuleArgs
      {
         private string _expression;

         /// <summary>
         /// The Regular expression that the string have to match.
         /// </summary>
         public string Expression
         {
            get { return _expression; }
         }

         /// <summary>
         /// Constructor
         /// </summary>
         /// <param name="propertyName">Property to validate</param>
         /// <param name="expression">The Regular expression that the property have to match</param>
         public RegExpRuleArgs(
           string propertyName, string expression)
            : base(propertyName)
         {
            _expression = expression;
         }

         /// <summary>
         /// Return a string representation of the object.
         /// </summary>
         public override string ToString()
         {
            return base.ToString() + "!" + _expression;
         }
      }

      #endregion

      #region CompareValues

      /// <summary>
      /// Generic rule that determines if an object's property is less than a particular value.
      /// </summary>
      /// <typeparam name="T">Datatype of the property to validate</typeparam>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      public static bool LessThanValue<T>(object target, ValidationRuleArgs e)
      {
         return CompareValues<T>(target, e as CompareValueRuleArgs<T>, CompareType.LessThan);
      }

      /// <summary>
      /// Generic rule that determines if an object's property is less than or equal to a particular value.
      /// </summary>
      /// <typeparam name="T">Datatype of the property to validate</typeparam>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      public static bool LessThanOrEqualToValue<T>(object target, ValidationRuleArgs e)
      {
         return CompareValues<T>(target, e as CompareValueRuleArgs<T>, CompareType.LessThanOrEqualTo);
      }

      /// <summary>
      /// Generic rule that determines if an object's property is equal to a particular value.
      /// </summary>
      /// <typeparam name="T">Datatype of the property to validate</typeparam>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      public static bool EqualsValue<T>(object target, ValidationRuleArgs e)
      {
         return CompareValues<T>(target, e as CompareValueRuleArgs<T>, CompareType.EqualTo);
      }

      /// <summary>
      /// Generic rule that determines if an object's property is greater than a particular value.
      /// </summary>
      /// <typeparam name="T">Datatype of the property to validate</typeparam>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      public static bool GreaterThanValue<T>(object target, ValidationRuleArgs e)
      {
         return CompareValues<T>(target, e as CompareValueRuleArgs<T>, CompareType.GreaterThan
            );
      }

      /// <summary>
      /// Generic rule that determines if an object's property is greater than or equal to a particular value.
      /// </summary>
      /// <typeparam name="T">Datatype of the property to validate</typeparam>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <returns>False if the rule is broken; true otherwise.</returns>
      public static bool GreaterThanOrEqualToValue<T>(object target, ValidationRuleArgs e)
      {
         return CompareValues<T>(target, e as CompareValueRuleArgs<T>, CompareType.GreaterThanOrEqualTo);
      }

      /// <summary>
      /// Private method that compares a property value with a specified value.
      /// </summary>
      /// <typeparam name="T">Datatype of the property to validate.</typeparam>
      /// <param name="target">Object containing the data to validate.</param>
      /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
      /// <param name="compareType"><see cref="CompareType"/> defining the type of comparison that will be made.
      /// <returns></returns>
      private static bool CompareValues<T>(object target, CompareValueRuleArgs<T> e, CompareType compareType)
      {
         bool result = true;
         
         if (e != null)
         {
            T compareValue = e.CompareValue;

            PropertyInfo p = target.GetType().GetProperty(e.PropertyName);

            T value = (T)p.GetValue(target, null);
            int res = System.Collections.Comparer.DefaultInvariant.Compare(value, compareValue);

            switch (compareType)
            { 
               case CompareType.LessThanOrEqualTo:
                  result = (res <= 0);

                  if (!result)
                  {
                     e.Description = string.Format("{0} can not exceed {1}",
                     e.PropertyName, compareValue.ToString());
                  }
                  break;

               case CompareType.LessThan:
                  result = (res < 0);

                  if (!result)
                  {
                     e.Description = string.Format("{0} must be less than {1}",
                     e.PropertyName, compareValue.ToString());
                  }
                  break;

               case CompareType.EqualTo:
                  result = (res == 0);

                  if (!result)
                  {
                     e.Description = string.Format("{0} must equal {1}",
                     e.PropertyName, compareValue.ToString());
                  }
                  break;

               case CompareType.GreaterThan:
                  result = (res > 0);

                  if (!result)
                  {
                     e.Description = string.Format("{0} must exceed {1}",
                     e.PropertyName, compareValue.ToString());
                  }
                  break;

               case CompareType.GreaterThanOrEqualTo:
                  result = (res >= 0);

                  if (!result)
                  {
                     e.Description = string.Format("{0} must be greater than or equal to {1}",
                     e.PropertyName, compareValue.ToString());
                  }
                  break;

            }

            if (!result)
            {
               
            }
         }
         return result;
      }

      /// <summary>
      /// Enum indicating the type of comparison that will be made.
      /// </summary>
      private enum CompareType
      { 
         LessThanOrEqualTo,
         LessThan,
         EqualTo,
         GreaterThan,
         GreaterThanOrEqualTo
      }

      /// <summary>
      /// Class used with the <see cref="CompareValues{T}"/> rules.
      /// </summary>
      /// <typeparam name="T"></typeparam>
      public class CompareValueRuleArgs<T> : ValidationRuleArgs
      {
         T _compareValue;

         /// <summary>
         /// Value to be compared against an object's property.
         /// </summary>
         public T CompareValue
         {
            get { return _compareValue; }
         }

         /// <summary>
         /// Constructor
         /// </summary>
         /// <param name="propertyName">Name of the property to be validated.</param>
         /// <param name="compareValue">The value to be compared against the property.</param>
         public CompareValueRuleArgs(string propertyName, T compareValue)
            : base(propertyName)
         {
            _compareValue = compareValue;
         }

         /// <summary>
         /// Returns a string representation of the object.
         /// </summary>
         public override string ToString()
         {
            return base.ToString() + "!" + _compareValue.ToString();
         }
      }

      #endregion

   }
}