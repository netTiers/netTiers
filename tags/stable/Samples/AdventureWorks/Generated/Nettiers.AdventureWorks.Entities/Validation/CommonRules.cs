﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections;

namespace Nettiers.AdventureWorks.Entities.Validation
{
	/// <summary>
	/// Static class that contains common validation rules.  Each rule conforms to the <see cref="ValidationRuleArgs"/> delegate.
    /// </summary>
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

                if (value == null)
                {
                    if (string.IsNullOrEmpty(e.Description)) e.Description = string.Format("{0} cannot be null.", e.FriendlyName);
                    return false;
                }

                return true;
            }
            else
            {
                throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"", e.PropertyName, target.GetType().ToString()));
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
                string value = (string)p.GetValue(target, null);
                if (string.IsNullOrEmpty(value))
                {
                    if (string.IsNullOrEmpty(e.Description)) e.Description = e.FriendlyName + " is required.";
                    return false;
                }
                return true;
            }
            else
            {
                throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"", e.PropertyName, target.GetType().ToString()));
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
                            if (string.IsNullOrEmpty(e.Description)) e.Description = String.Format("{0} can not exceed {1} characters", e.FriendlyName, max.ToString());
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
                    throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"", e.PropertyName, target.GetType().ToString()));
                }
            }
            else
            {
                throw new ArgumentException("Invalid ValidationRuleArgs. e must be of type MaxLengthRuleArgs.");
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
			/// <param name="friendlyName">Friendly name to use in the validation error text.</param>
            /// <param name="maxLength">Max length of the property</param>
            public MaxLengthRuleArgs(string propertyName, string friendlyName, int maxLength)
                : base(propertyName, friendlyName)
            {
                _maxLength = maxLength;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="propertyName">Property to validate</param>
            /// <param name="maxLength">Max length of the property</param>
            public MaxLengthRuleArgs(string propertyName, int maxLength)
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

        #region MaxWords

        /// <summary>
        /// Summary description for MaxWordsRuleArgs.
        /// </summary>
        public class MaxWordsRuleArgs : ValidationRuleArgs
        {
            /// <summary>
            /// Creates a new instance of the MaxWordsRuleArgs class.
            /// </summary>
            /// <param name="propertyName">The name of the property to be validated.</param>
            /// <param name="maxLength">Maximum number of words allowed.</param>
            public MaxWordsRuleArgs(string propertyName, int maxLength)
                : base(propertyName)
            {
                this._maxLength = maxLength;
            }

            /// <summary>
            /// Creates a new instance of the MaxWordsRuleArgs class.
            /// </summary>
            /// <param name="propertyName">The name of the property to be validated.</param>
			/// <param name="friendlyName">Friendly name to use in the validation error text.</param>
            /// <param name="maxLength">Maximum number of words allowed.</param>
            public MaxWordsRuleArgs(string propertyName, string friendlyName, int maxLength)
                : base(propertyName, friendlyName)
            {
                this._maxLength = maxLength;
            }

            /// <summary>
            /// Return a string representation of the object.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return (base.ToString() + "!" + this._maxLength.ToString());
            }


            /// <summary>
            /// Gets the value of the MaxLength property.
            /// </summary>
            public int MaxLength
            {
                get
                {
                    return this._maxLength;
                }
            }


            // Fields
            private int _maxLength;
        }

        /// <summary>
        /// Summary description for MaxWords.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool MaxWords(object target, ValidationRuleArgs e)
        {
            CommonRules.MaxWordsRuleArgs args1 = e as CommonRules.MaxWordsRuleArgs;
            if (args1 == null)
            {
                throw new ArgumentException("Invalid ValidationRuleArgs. e must be of type MaxWordsRuleArgs.");
            }
            string text1 = @"\b\w+\b";
            PropertyInfo info1 = target.GetType().GetProperty(e.PropertyName);
            if (info1 == null)
            {
                throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"", e.PropertyName, target.GetType().ToString()));
            }
            if (info1.PropertyType != typeof(string))
            {
                throw new ArgumentException(string.Format("Property \"{0}\" is not of type String.", e.PropertyName));
            }
            string text2 = (string)info1.GetValue(target, null);
            if (Regex.Matches(text2, text1).Count > args1.MaxLength)
            {
                if (e.Description == string.Empty)
                {
                    e.Description = string.Format("{0} exceed the maximum number of words", e.FriendlyName, text1);
                }
                return false;
            }
            return true;
        }

        #endregion

        #region RegexIsMatch

        /// <summary>
        /// Rule ensuring a String value is matching
        /// a specified regular expression.
        /// </summary>
        /// <param name="target">Object containing the data to validate.</param>
        /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated, must be of type RegexRuleArgs</param>
        /// <returns>False if the rule is broken; true otherwise.</returns>
        /// <remarks>
        /// This implementation uses late binding, and will only work
        /// against String property values.
        /// </remarks>
        public static bool RegexIsMatch(object target, ValidationRuleArgs e)
        {
            RegexRuleArgs args = e as RegexRuleArgs;
            if (args != null)
            {
                string expression = args.Expression;

                PropertyInfo p = target.GetType().GetProperty(e.PropertyName);

                if (p != null)
                {
                    if (p.PropertyType == typeof(string))
                    {
                        string value = (string)p.GetValue(target, null);

                        if (value == null || !Regex.IsMatch(value, expression))
                        {
                            if (string.IsNullOrEmpty(e.Description)) e.Description = String.Format("{0} is not valid.", e.FriendlyName);
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
                    throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"", e.PropertyName, target.GetType().ToString()));
                }
            }
            else
            {
                throw new ArgumentException("Invalid ValidationRuleArgs. e must be of type RegexRuleArgs.");
            }

        }

        /// <summary>
        /// Class used with the <see cref="RegexIsMatch"/>.
        /// </summary>
        public class RegexRuleArgs : ValidationRuleArgs
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
            /// Initializes a new instance of the RegexRuleArgs class.
            /// </summary>
            /// <param name="propertyName">Property to validate</param>
			/// <param name="friendlyName">Friendly name to use in the validation error text.</param>
            /// <param name="expression">The Regular expression that the property have to match</param>
            public RegexRuleArgs(string propertyName, string friendlyName, string expression)
                : base(propertyName, friendlyName)
            {
                _expression = expression;
            }

            /// <summary>
            /// Initializes a new instance of the RegexRuleArgs class.
            /// </summary>
            /// <param name="propertyName">Property to validate</param>
            /// <param name="expression">The Regular expression that the property have to match</param>
            public RegexRuleArgs(string propertyName, string expression)
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
        /// <param name="compareType"><see cref="CompareType"/> defining the type of comparison that will be made.</param>
        /// <returns></returns>
        private static bool CompareValues<T>(object target, CompareValueRuleArgs<T> e, CompareType compareType)
        {
            bool result = true;

            if (e != null)
            {
                T compareValue = e.CompareValue;

                PropertyInfo p = target.GetType().GetProperty(e.PropertyName);

                T value;

                //if (p.PropertyType.Name.Equals(typeof(Nullable<>).Name))
                //{
                //}
                try
                {
                    value = (T)p.GetValue(target, null);
                }
                catch (Exception)
                {
                    return true;
                }

                // if the property is read from a nullable type, then a null valid is considered as allowed
                if (p.PropertyType.Name.Equals(typeof(Nullable<>).Name) && value == null)
                {
                    return true;
                }

                int res = Comparer.DefaultInvariant.Compare(value, compareValue);

                switch (compareType)
                {
                    case CompareType.LessThanOrEqualTo:
                        result = (res <= 0);

                        if (!result)
                        {
                            if (string.IsNullOrEmpty(e.Description))
                            {
                                e.Description = string.Format("{0} cannot exceed {1}.", e.FriendlyName, compareValue.ToString());
                            }
                        }
                        break;

                    case CompareType.LessThan:
                        result = (res < 0);

                        if (!result)
                        {
                            if (string.IsNullOrEmpty(e.Description))
                            {
                                e.Description = string.Format("{0} must be less than {1}.", e.FriendlyName, compareValue.ToString());
                            }
                        }
                        break;

                    case CompareType.EqualTo:
                        result = (res == 0);

                        if (!result)
                        {
                            if (string.IsNullOrEmpty(e.Description))
                            {
                                e.Description = string.Format("{0} must equal {1}.", e.FriendlyName, compareValue.ToString());
                            }
                        }
                        break;

                    case CompareType.GreaterThan:
                        result = (res > 0);

                        if (!result)
                        {
                            if (string.IsNullOrEmpty(e.Description))
                            {
                                e.Description = string.Format("{0} must exceed {1}.", e.FriendlyName, compareValue.ToString());
                            }
                        }
                        break;

                    case CompareType.GreaterThanOrEqualTo:
                        result = (res >= 0);

                        if (!result)
                        {
                            if (string.IsNullOrEmpty(e.Description))
                            {
                                e.Description = string.Format("{0} must be greater than or equal to {1}.", e.FriendlyName, compareValue.ToString());
                            }
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
            /// Constructor
            /// </summary>
            /// <param name="propertyName">Name of the property to be validated.</param>
			/// <param name="friendlyName">Friendly name to use in the validation error text.</param>
            /// <param name="compareValue">The value to be compared against the property.</param>
            public CompareValueRuleArgs(string propertyName, string friendlyName, T compareValue)
                : base(propertyName, friendlyName)
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

        #region InRange

        /// <summary>
        /// Generic rule that determines if an object's property is within a specified range.
        /// </summary>
        /// <typeparam name="T">Datatype of the property to validate.  Must implement <see cref="System.IComparable{T}"/>.</typeparam>
        /// <param name="target">Object containing the data to validate.</param>
        /// <param name="e"><see cref="ValidationRuleArgs"/> containing the information about the object to be validated.</param>
        /// <returns>False if the rule is broken; true otherwise.</returns>
        public static bool InRange<T>(object target, ValidationRuleArgs e)
        {
            bool result = true;

            RangeRuleArgs<T> ruleArgs = e as RangeRuleArgs<T>;

            if (ruleArgs != null)
            {
                PropertyInfo p = target.GetType().GetProperty(e.PropertyName);

                T value = (T)p.GetValue(target, null);

                result = ruleArgs.Range.Contains(value);

                if (!result)
                {
                    if (string.IsNullOrEmpty(e.Description)) e.Description = string.Format("{0} must be between {1} and {2}.", ruleArgs.FriendlyName, ruleArgs.Range.MinValue, ruleArgs.Range.MaxValue);
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Must be of type RangeRuleArgs.", "e");
            }
        }

        /// <summary>
        /// Class used to do a range comparison on a property.
        /// </summary>
        /// <typeparam name="T">Datatype of the property being validated.</typeparam>
        public class Range<T>
        {
            private readonly T minValue;
            private readonly T maxValue;

            /// <summary>
            /// Creates a new instance of the <see cref="T:Range"/> class.
            /// </summary>
            /// <param name="minValue">The minimum value of the property.</param>
            /// <param name="maxValue">The maximum value of the property.</param>
            public Range(T minValue, T maxValue)
            {
                //Make sure that the user has not reversed the values
                if (Comparer.DefaultInvariant.Compare(minValue, maxValue) <= 0)
                {
                    this.minValue = minValue;
                    this.maxValue = maxValue;
                }
                else
                {
                    //Values are reversed
                    this.minValue = maxValue;
                    this.maxValue = minValue;
                }
            }

            /// <summary>
            /// The minimum value in the range.
            /// </summary>
            public T MinValue
            {
                get { return this.minValue; }
            }

            /// <summary>
            /// The maximum value in the range.
            /// </summary>
            public T MaxValue
            {
                get { return this.maxValue; }
            }

            /// <summary>
            /// Compares the specified value with the <see cref="MinValue"/> and <see cref="MaxValue"/>
            /// to determine if the value is within the range.
            /// </summary>
            /// <param name="value">The value to find within the current range</param>
            /// <returns>True if the value is within the range (inclusive); False otherwise.</returns>
            public bool Contains(T value)
            {
                return Comparer.DefaultInvariant.Compare(value, MinValue) >= 0 && Comparer.DefaultInvariant.Compare(value, MaxValue) <= 0;
            }

            /// <summary>
            /// Returns a string representation of the object.
            /// </summary>
            public override string ToString()
            {
                return base.ToString() + "!" + minValue.ToString() + "-" + maxValue.ToString();
            }
        }

        /// <summary>
        /// Validation Rule Argument class
        /// </summary>
        /// <typeparam name="T">Datatype of the property being validated.</typeparam>
        public class RangeRuleArgs<T> : ValidationRuleArgs
        {
            private Range<T> range;

            /// <summary>
            /// Creates a new instance of the <see cref="T:RangeRuleArgs"/> class.
            /// </summary>
            /// <param name="propertyName">Name of the property to be validated.</param>
            /// <param name="minValue">The minimum value of the property.</param>
            /// <param name="maxValue">The maximum value of the property.</param>
            public RangeRuleArgs(string propertyName, T minValue, T maxValue)
                : base(propertyName)
            {
                range = new Range<T>(minValue, maxValue);
            }

            /// <summary>
            /// Creates a new instance of the <see cref="T:RangeRuleArgs"/> class.
            /// </summary>
            /// <param name="propertyName">Name of the property to be validated.</param>
			/// <param name="friendlyName">Friendly name to use in the validation error text.</param>
            /// <param name="minValue">The minimum value of the property.</param>
            /// <param name="maxValue">The maximum value of the property.</param>
            public RangeRuleArgs(string propertyName, string friendlyName, T minValue, T maxValue)
                : base(propertyName, friendlyName)
            {
                range = new Range<T>(minValue, maxValue);
            }
			
            /// <summary>
            /// Creates a new instance of the <see cref="T:RangeRuleArgs"/> class.
            /// </summary>
            /// <param name="propertyName">Name of the property to be validated.</param>
            /// <param name="range"><see cref="T:Range"/> object containing the range of valid values for the property.</param>
            public RangeRuleArgs(string propertyName, Range<T> range)
                : base(propertyName)
            {
                this.range = range;
            }

            /// <summary>
            /// Creates a new instance of the <see cref="T:RangeRuleArgs"/> class.
            /// </summary>
            /// <param name="propertyName">Name of the property to be validated.</param>
			/// <param name="friendlyName">Friendly name to use in the validation error text.</param>
            /// <param name="range"><see cref="T:Range"/> object containing the range of valid values for the property.</param>
            public RangeRuleArgs(string propertyName, string friendlyName, Range<T> range)
                : base(propertyName, friendlyName)
            {
                this.range = range;
            }
			
            /// <summary>
            /// Returns the <see cref="T:Range{T}"/> object associated with this instance.
            /// </summary>
            public Range<T> Range
            {
                get { return this.range; }
            }

            /// <summary>
            /// Returns a string representation of the object.
            /// </summary>
            public override string ToString()
            {
                return base.ToString() + "!" + range.ToString();
            }
        }

        #endregion		
		
    }

}
