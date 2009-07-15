﻿#region Using Directives
using System;
using System.Collections;
using System.Reflection;
using System.Text;
using regEx = System.Text.RegularExpressions;
#endregion

namespace PetShop.Business
{
	/// <summary>
	/// Provides common utility methods for interacting with objects.
	/// </summary>
	public static class EntityUtil
	{
		/// <summary>
		/// Creates a new instance of the specified type.
		/// </summary>
		/// <param name="type">The runtime type to instantiate.</param>
		/// <returns>An instance of the specified type.</returns>
		public static Object GetNewEntity(Type type)
		{
			return GetNewEntity(type, null);
		}

		/// <summary>
		/// Creates a new instance of the specified type using the supplied
		/// constructor parameters values.
		/// </summary>
		/// <param name="type">The runtime type to instantiate.</param>
		/// <param name="args">The constructor parameter values.</param>
		/// <returns>An instance of the specified type.</returns>
		public static Object GetNewEntity(Type type, params Object[] args)
		{
			ConstructorInfo c = GetConstructor(type, GetTypes(args));
			return ( c != null ) ? c.Invoke(args) : null;
		}

		/// <summary>
		/// Gets the default constructor for the specified type.
		/// </summary>
		/// <param name="type">The runtime type.</param>
		/// <returns>A <see cref="ConstructorInfo"/> object.</returns>
		public static ConstructorInfo GetConstructor(Type type)
		{
			return GetConstructor(type, null);
		}

		/// <summary>
		/// Gets the constructor for the specified type whose parameters
		/// match the supplied type array.
		/// </summary>
		/// <param name="type">The runtime type.</param>
		/// <param name="types">An array of constructor parameter types.</param>
		/// <returns>A <see cref="ConstructorInfo"/> object.</returns>
		public static ConstructorInfo GetConstructor(Type type, Type[] types)
		{
			ConstructorInfo c = null;

			if ( type != null )
			{
				c = type.GetConstructor(types ?? Type.EmptyTypes);
			}

			return c;
		}

		/// <summary>
		/// Gets a <see cref="PropertyInfo"/> object representing the property
		/// belonging to the object having the specified name.
		/// </summary>
		/// <param name="item">An object instance.</param>
		/// <param name="propertyName">The property name.</param>
		/// <returns>A <see cref="PropertyInfo"/> object, or null if the object
		/// instance does not have a property with the specified name.</returns>
		public static PropertyInfo GetProperty(Object item, String propertyName)
		{
			PropertyInfo prop = null;
			
			if ( item != null )
			{
				prop = GetProperty(item.GetType(), propertyName);
			}

			return prop;
		}

		/// <summary>
		/// Gets a <see cref="PropertyInfo"/> object representing the property
		/// belonging to the runtime type having the specified name.
		/// </summary>
		/// <param name="type">The runtime type.</param>
		/// <param name="propertyName">The property name.</param>
		/// <returns>A <see cref="PropertyInfo"/> object, or null if the runtime
		/// type does not have a property with the specified name.</returns>
		public static PropertyInfo GetProperty(Type type, String propertyName)
		{
			PropertyInfo prop = null;

			if ( type != null && !String.IsNullOrEmpty(propertyName) )
			{
				prop = type.GetProperty(propertyName);
			}

			return prop;
		}

		/// <summary>
		/// Gets a <see cref="MethodInfo"/> object representing the method
		/// belonging to the object having the specified name.
		/// </summary>
		/// <param name="item">An object instance.</param>
		/// <param name="methodName">The method name.</param>
		/// <returns>A <see cref="MethodInfo"/> object, or null if the object
		/// instance does not have a method with the specified name.</returns>
		public static MethodInfo GetMethod(Object item, String methodName)
		{
			return GetMethod(item, methodName, null);
		}

		/// <summary>
		/// Gets a <see cref="MethodInfo"/> object representing the method
		/// belonging to the object having the specified name and whose
		/// parameters match the specified types.
		/// </summary>
		/// <param name="item">An object instance.</param>
		/// <param name="methodName">The method name.</param>
		/// <param name="types">The parameter types.</param>
		/// <returns>A <see cref="MethodInfo"/> object, or null if the object
		/// instance does not have a method with the specified name.</returns>
		public static MethodInfo GetMethod(Object item, String methodName, params Type[] types)
		{
			MethodInfo m = null;

			if ( item != null )
			{
				m = GetMethod(item.GetType(), methodName, types);
			}

			return m;
		}

		/// <summary>
		/// Gets a <see cref="MethodInfo"/> object representing the method
		/// belonging to the runtime type having the specified name.
		/// </summary>
		/// <param name="type">The runtime type.</param>
		/// <param name="methodName">The method name.</param>
		/// <returns>A <see cref="MethodInfo"/> object, or null if the runtime
		/// type does not have a method with the specified name.</returns>
		public static MethodInfo GetMethod(Type type, String methodName)
		{
			return GetMethod(type, methodName, null);
		}

		/// <summary>
		/// Gets a <see cref="MethodInfo"/> object representing the method
		/// belonging to the runtime type having the specified name and whose
		/// parameters match the specified types.
		/// </summary>
		/// <param name="type">The runtime type.</param>
		/// <param name="methodName">The method name.</param>
		/// <param name="types">The parameter types.</param>
		/// <returns>A <see cref="MethodInfo"/> object, or null if the runtime
		/// type does not have a method with the specified name.</returns>
		public static MethodInfo GetMethod(Type type, String methodName, params Type[] types)
		{
			MethodInfo m = null;

			if ( type != null && !String.IsNullOrEmpty(methodName) )
			{
				m = type.GetMethod(methodName, (types ?? Type.EmptyTypes));
			}

			return m;
		}

		/// <summary>
		/// Invokes the specified method on the object using reflection.
		/// </summary>
		/// <param name="entity">An object instance.</param>
		/// <param name="methodName">The method name.</param>
		/// <returns>The result of the method invocation.</returns>
		public static Object InvokeMethod(Object entity, String methodName)
		{
			return InvokeMethod(entity, methodName, null, null);
		}

		/// <summary>
		/// Invokes the specified method on the object using reflection.
		/// Passes the supplied arguments as method parameters.
		/// </summary>
		/// <param name="entity">An object instance.</param>
		/// <param name="methodName">The method name.</param>
		/// <param name="args">The method parameters.</param>
		/// <returns>The result of the method invocation.</returns>
		public static Object InvokeMethod(Object entity, String methodName, Object[] args)
		{
			return InvokeMethod(entity, methodName, args, GetTypes(args));
		}

		/// <summary>
		/// Invokes the specified method on the object using reflection.
		/// Passes the supplied arguments as method parameters.
		/// </summary>
		/// <param name="entity">An object instance.</param>
		/// <param name="methodName">The method name.</param>
		/// <param name="args">The method parameters.</param>
		/// <param name="types">The method parameter types.</param>
		/// <returns>The result of the method invocation.</returns>
		public static Object InvokeMethod(Object entity, String methodName, Object[] args, Type[] types)
		{
			MethodInfo m = GetMethod(entity, methodName, types);

			if ( m == null )
			{
				// If this were not late-binding it would basically be a compilation error.
				// Throw an exception in order to fail early and in an obvious manner.
				string format = "The method '{0}' with arguments '{1}' could not be located on the specified entity.";
				string typesValue = (types == null) ? "()" : "(" + GetTypeNames(types) + ")";
				throw new ArgumentException(string.Format(format, methodName, typesValue));
			}

			return m.Invoke(entity, args);
		}

		/// <summary>
		/// Gets the System.Type with the specified name.
		/// </summary>
		/// <param name="typeName">The name of the type to get.</param>
		/// <returns>The System.Type with the specified name, if found; otherwise, null.</returns>
		public static Type GetType(String typeName)
		{
			Type type = null;

			if ( !String.IsNullOrEmpty(typeName) )
			{
				type = Type.GetType(typeName, true);
			}

			return type;
		}

		/// <summary>
		/// Gets an array of System.Type objects which match the specified objects.
		/// NOTE: this method will throw an exception if any of the values held
		/// within the args array are null.
		/// </summary>
		/// <param name="args">An array of objects.</param>
		/// <returns>An array of System.Type objects.</returns>
		public static Type[] GetTypes(params Object[] args)
		{
			Type[] types = Type.EmptyTypes;

			if ( args != null )
			{
				types = Type.GetTypeArray(args);
			}

			return types;
		}

		/// <summary>
		/// Gets the value of the property with the specified name.
		/// </summary>
		/// <param name="item">An object instance.</param>
		/// <param name="propertyName">The property name.</param>
		/// <returns>The property value.</returns>
		public static Object GetPropertyValue(Object item, String propertyName)
		{
			PropertyInfo property = null;
			return GetPropertyValue(item, propertyName, out property);
		}

		/// <summary>
		/// Gets the value of the property with the specified name.
		/// </summary>
		/// <param name="item">An object instance.</param>
		/// <param name="propertyName">The property name.</param>
		/// <param name="property">A reference to the <see cref="PropertyInfo"/> object.</param>
		/// <returns>The property value.</returns>
		public static Object GetPropertyValue(Object item, String propertyName, out PropertyInfo property)
		{
			Object value = null;
			property = GetProperty(item, propertyName);

			if ( property != null && property.CanRead )
			{
				value = property.GetValue(item, null);
			}

			return value;
		}

		/// <summary>
		/// Gets the value of the static property with the specified name.
		/// </summary>
		/// <param name="type">The runtime type.</param>
		/// <param name="propertyName">The property name.</param>
		/// <returns>The property value.</returns>
		public static Object GetStaticPropertyValue(Type type, String propertyName)
		{
			PropertyInfo property = null;
			return GetStaticPropertyValue(type, propertyName, out property);
		}

		/// <summary>
		/// Gets the value of the static property with the specified name.
		/// </summary>
		/// <param name="type">The runtime type.</param>
		/// <param name="propertyName">The property name.</param>
		/// <param name="property">A reference to the <see cref="PropertyInfo"/> object.</param>
		/// <returns>The property value.</returns>
		public static Object GetStaticPropertyValue(Type type, String propertyName, out PropertyInfo property)
		{
			Object value = null;
			property = GetProperty(type, propertyName);

			if ( property != null && property.CanRead )
			{
				value = property.GetValue(null, null);
			}

			return value;
		}

		/// <summary>
		/// Sets the value of the property with the specified name.
		/// </summary>
		/// <param name="item">An object instance.</param>
		/// <param name="propertyName">The property name.</param>
		/// <param name="propertyValue">The property value.</param>
		public static void SetPropertyValue(Object item, String propertyName, Object propertyValue)
		{
			SetPropertyValue(item, propertyName, propertyValue, true);
		}

      /// <summary>
      /// Sets the value of the property with the specified name.
      /// </summary>
      /// <param name="item">An object instance.</param>
      /// <param name="propertyName">The property name.</param>
      /// <param name="propertyValue">The property value.</param>
      /// <param name="convertBlankToNull">Boolean indicating whether empty strings should be converted to null values.</param>
      public static void SetPropertyValue(Object item, String propertyName, Object propertyValue, bool convertBlankToNull)
      {
         PropertyInfo property = null;
         SetPropertyValue(item, propertyName, propertyValue, out property, convertBlankToNull);
      }

		/// <summary>
		/// Sets the value of the property with the specified name.
		/// </summary>
		/// <param name="item">An object instance.</param>
		/// <param name="propertyName">The property name.</param>
		/// <param name="propertyValue">The property value.</param>
		/// <param name="property">A reference to the <see cref="PropertyInfo"/> object.</param>
		public static void SetPropertyValue(Object item, String propertyName, Object propertyValue, out PropertyInfo property)
		{
         SetPropertyValue(item, propertyName, propertyValue, out property, true);
		}

      /// <summary>
      /// Sets the value of the property with the specified name.
      /// </summary>
      /// <param name="item">An object instance.</param>
      /// <param name="propertyName">The property name.</param>
      /// <param name="propertyValue">The property value.</param>
      /// <param name="property">A reference to the <see cref="PropertyInfo"/> object.</param>
      /// <param name="convertBlankToNull">Boolean indicating whether empty strings should be converted to null values.</param>
      public static void SetPropertyValue(Object item, String propertyName, Object propertyValue, out PropertyInfo property, bool convertBlankToNull)
      {
         property = GetProperty(item, propertyName);

         if (property != null && property.CanWrite)
         {
            Object value = ChangeType(propertyValue, property.PropertyType,convertBlankToNull);
            property.SetValue(item, value, null);
         }
      }

		/// <summary>
		/// Sets the value of the property with the specified name to the value
		/// returned by the Guid.NewGuid() method.
		/// </summary>
		/// <param name="entity">An object instance.</param>
		/// <param name="entityKeyName">The property name.</param>
		/// <returns>The property value.</returns>
		public static Guid SetEntityKeyValue(Object entity, String entityKeyName)
		{
			PropertyInfo property = null;
			Object objId = GetPropertyValue(entity, entityKeyName, out property);
			Guid entityId = Guid.Empty;

			if ( property != null && property.PropertyType.IsAssignableFrom(typeof(Guid)) )
			{
				if ( Guid.Empty.Equals(objId) && property.CanWrite )
				{
					entityId = Guid.NewGuid();
					property.SetValue(entity, entityId, null);
				}
			}

			return entityId;
		}

		/// <summary>
		/// Sets the properties of the specified entity based on the
		/// name/value pairs found in the specified collection.
		/// </summary>
		/// <param name="entity">The instance of an object to set the properties on.</param>
		/// <param name="values">An instance of System.Collections.IDictionary containing the name/value pairs.</param>
		public static void SetEntityValues(Object entity, IDictionary values)
		{
			if ( entity != null && values != null )
			{
				Object oValue;

				foreach ( Object oKey in values.Keys )
				{
					if ( oKey is String )
					{
						oValue = values[oKey];
						SetPropertyValue(entity, oKey.ToString(), oValue);
					}
				}
			}
		}

		/// <summary>
		/// Initializes the properties specified in propertyNames
		/// with the value of DateTime.Now for the specified entity.
		/// </summary>
		/// <param name="entity">The instance of an object to set the properties on.</param>
		/// <param name="propertyNames">The list of property names to initialize.</param>
		public static void InitEntityDateTimeValues(Object entity, params String[] propertyNames)
		{
			if ( entity != null && propertyNames != null )
			{
				PropertyInfo prop;

				foreach ( String name in propertyNames )
				{
					prop = GetProperty(entity, name);

					if ( prop != null && prop.CanWrite && prop.PropertyType.IsAssignableFrom(typeof(DateTime)) )
					{
					   	prop.SetValue(entity, DateTime.Now, null);			   					   
					}
				}
			}
		}

		/// <summary>
		/// Determines if the property with the specified name equals the specified value.
		/// </summary>
		/// <param name="item">An object instance.</param>
		/// <param name="propertyName">The property name.</param>
		/// <param name="propertyValue">The property value.</param>
		/// <returns>True if the property value matches the specified value; otherwise, false.</returns>
		public static bool IsPropertyValueEqual(Object item, String propertyName, Object propertyValue)
		{
			PropertyInfo property = null;
			Object prevValue = GetPropertyValue(item, propertyName, out property);

			Object currValue = null;
			bool isEqual = false;

			if ( property != null )
			{
				currValue = ChangeType(propertyValue, property.PropertyType);
				isEqual = Object.Equals(prevValue, currValue);
			}

			return isEqual;
		}

		/// <summary>
		/// Converts the specified value to the specified type.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="conversionType">A System.Type to convert to.</param>
		/// <returns>The results of the conversion.</returns>
		public static Object ChangeType(Object value, Type conversionType)
		{
			return ChangeType(value, conversionType, true);
		}

		/// <summary>
		/// Converts the specified value to the specified type.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="conversionType">A System.Type to convert to.</param>
		/// <param name="convertBlankToNull">A value indicating whether to treat
		/// empty string objects as null values.</param>
		/// <returns>The results of the conversion.</returns>
		public static Object ChangeType(Object value, Type conversionType, bool convertBlankToNull)
		{
			Object newValue = null;

			if ( convertBlankToNull && value != null )
			{
				if ( value is String )
				{
					String strValue = value.ToString().Trim();

					if ( String.IsNullOrEmpty(strValue) )
					{
						value = null;
					}
				}
			}
			if (conversionType.IsInstanceOfType(value))
         {
            newValue = value;
         }
			else if ( conversionType.IsGenericType )
			{
				newValue = ChangeGenericType(value, conversionType, convertBlankToNull);
			}
			else if ( value != null )
			{
				// special handling for non-convertible values
				if ( !(value is IConvertible) )
				{
					// special handling of byte[] types
					if ( conversionType == typeof(Byte[]) )
					{
						newValue = value;
					}
					else
					{
						value = value.ToString();
					}
				}
				// special handling of Guid types
				if ( conversionType == typeof(Guid) )
				{
					if ( !String.IsNullOrEmpty(value.ToString()) )
					{
						newValue = new Guid(value.ToString());
					}
				}
				else
				{
					newValue = Convert.ChangeType(value, conversionType);
				}
			}

			return newValue;
		}

		/// <summary>
		/// Converts the specified value to the specified generic type.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="conversionType">A System.Type to convert to.</param>
		/// <returns>The result of the conversion.</returns>
		public static Object ChangeGenericType(Object value, Type conversionType)
		{
			return ChangeGenericType(value, conversionType, true);
		}

		/// <summary>
		/// Converts the specified value to the specified generic type.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="conversionType">A System.Type to convert to.</param>
		/// <param name="convertBlankToNull">A value indicating whether to treat
		/// empty string objects as null values.</param>
		/// <returns>The results of the conversion.</returns>
		public static Object ChangeGenericType(Object value, Type conversionType, bool convertBlankToNull)
		{
			Object newValue = null;

			if ( conversionType.IsGenericType )
			{
				Type typeDef = conversionType.GetGenericTypeDefinition();
				Type[] typeArgs = conversionType.GetGenericArguments();

				if ( typeArgs.Length == 1 )
				{
					Type newType = typeArgs[0];
					Object arg = ChangeType(value, newType, convertBlankToNull);
					newValue = GetNewGenericEntity(typeDef, typeArgs, arg);
				}
			}

			return newValue;
		}

		/// <summary>
		/// Creates a reference to a generic type using the specified type definition
		/// and the supplied type arguments.
		/// </summary>
		/// <param name="typeDefinition">A generic type definition.</param>
		/// <param name="typeArguments">An array of System.Type arguments.</param>
		/// <returns>A System.Type representing the generic type.</returns>
		public static Type MakeGenericType(Type typeDefinition, Type[] typeArguments)
		{
			Type genericType = null;

			if ( typeDefinition != null && typeArguments != null && typeArguments.Length > 0 )
			{
				genericType = typeDefinition.MakeGenericType(typeArguments);
			}

			return genericType;
		}

		/// <summary>
		/// Creates a new instance of the specified generic type.
		/// </summary>
		/// <param name="typeDefinition">A generic type definition.</param>
		/// <param name="typeArguments">An array of System.Type arguments.</param>
		/// <param name="args">An array of constructor parameters values.</param>
		/// <returns>An instance of the generic type.</returns>
		public static Object GetNewGenericEntity(Type typeDefinition, Type[] typeArguments, params Object[] args)
		{
			Type genericType = MakeGenericType(typeDefinition, typeArguments);
			return GetNewGenericEntity(genericType, args);
		}

		/// <summary>
		/// Creates a new instance of the specified generic type.
		/// </summary>
		/// <param name="genericType">The runtime type.</param>
		/// <returns>An instance of the generic type.</returns>
		public static Object GetNewGenericEntity(Type genericType)
		{
			return GetNewGenericEntity(genericType, null);
		}

		/// <summary>
		/// Creates a new instance of the specified generic type.
		/// </summary>
		/// <param name="genericType">The runtime type.</param>
		/// <param name="args">An array of constructor parameters values.</param>
		/// <returns>An instance of the generic type.</returns>
		public static Object GetNewGenericEntity(Type genericType, params Object[] args)
		{
			Object entity = null;

			if ( genericType != null )
			{
				// make sure a single null arg was not passed in
				if ( args != null && args.Length == 1 && args[0] == null )
				{
					args = null;
				}

				entity = Activator.CreateInstance(genericType, args);
			}

			return entity;
		}

		/// <summary>
		/// Gets a value indicating whether the specified list contains any items.
		/// </summary>
		/// <param name="entities">A collection of objects.</param>
		/// <returns>True if the collection is not null and contains at least
		/// one item; otherwise false.</returns>
		public static bool HasEntities(IList entities)
		{
			return ( entities != null && entities.Count > 0 );
		}

		/// <summary>
		/// Gets the item within entityList whose property value matches the specifed value.
		/// </summary>
		/// <param name="entities">A collection of objects.</param>
		/// <param name="propertyName">The property name.</param>
		/// <param name="propertyValue">The property value.</param>
		/// <returns>The object whose property value matches the specified value.</returns>
		public static Object GetEntity(IList entities, String propertyName, Object propertyValue)
		{
			if ( HasEntities(entities) )
			{
				foreach ( Object entity in entities )
				{
					if ( IsPropertyValueEqual(entity, propertyName, propertyValue) )
					{
						return entity;
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Gets the item within entityList at the position specified by index.
		/// </summary>
		/// <param name="entityList">The collection of business objects.</param>
		/// <param name="index">The position within entityList that contains the current item.</param>
		/// <returns>The current business object.</returns>
		public static Object GetEntity(IEnumerable entityList, int index)
		{
			IList list = GetEntityList(entityList);
			Object entity = null;

			if ( list.Count > index )
			{
				entity = list[index];
			}

			return entity;
		}

		/// <summary>
		/// Gets the value of the property with the specified name and returns
		/// it as a collection of objects.
		/// </summary>
		/// <param name="entity">An object instance.</param>
		/// <param name="propertyName">The property name.</param>
		/// <returns>A collection of objects.</returns>
		public static IList GetEntityList(Object entity, String propertyName)
		{
			Object list = EntityUtil.GetPropertyValue(entity, propertyName);
			return GetEntityList(list);
		}

		/// <summary>
		/// Converts the specified object into a collection of objects.
		/// </summary>
		/// <param name="entityList">An object instance.</param>
		/// <returns>A collection of objects.</returns>
		public static IList GetEntityList(Object entityList)
		{
			IList list = null;

			if ( entityList == null )
			{
				list = new ArrayList();
			}
			else
			{
				if ( entityList is IList )
				{
					list = (IList) entityList;
				}
				else
				{
					list = new ArrayList();

					if ( entityList is IEnumerable )
					{
						IEnumerable temp = entityList as IEnumerable;

						foreach ( Object item in temp )
						{
							if ( item != null )
							{
								list.Add(item);
							}
						}
					}
					else
					{
						list.Add(entityList);
					}
				}
			}

			return list;
		}

		/// <summary>
		/// Adds the specified object to the collection of objects.
		/// </summary>
		/// <param name="list">A collection of objects.</param>
		/// <param name="item">The obejct to add.</param>
		public static void Add(IList list, Object item)
		{
			if ( list != null && item != null )
			{
				list.Add(item);
			}
		}

		/// <summary>
		/// Removes the specified object from the collection of objects.
		/// </summary>
		/// <param name="list">A collection of objects.</param>
		/// <param name="item">The object to remove.</param>
		public static void Remove(IList list, Object item)
		{
			if ( list != null && item != null )
			{
				if ( item is IEntity )
				{
					((IEntity) item).MarkToDelete();
				}

				list.Remove(item);
			}
		}

		/// <summary>
		/// Converts the string representation of a Guid to its Guid 
		/// equivalent. A return value indicates whether the operation 
		/// succeeded. 
		/// </summary>
		/// <param name="s">A string containing a Guid to convert.</param>
		/// <param name="result">
		/// When this method returns, contains the Guid value equivalent to 
		/// the Guid contained in <paramref name="s"/>, if the conversion 
		/// succeeded, or <see cref="Guid.Empty"/> if the conversion failed. 
		/// The conversion fails if the <paramref name="s"/> parameter is a 
		/// <see langword="null" /> reference (<see langword="Nothing" /> in 
		/// Visual Basic), or is not of the correct format. 
		/// </param>
		/// <value>
		/// <see langword="true" /> if <paramref name="s"/> was converted 
		/// successfully; otherwise, <see langword="false" />.
		/// </value>
		/// <exception cref="ArgumentNullException">
		///        Thrown if <pararef name="s"/> is <see langword="null"/>.
		/// </exception>
		public static bool GuidTryParse(string s, out Guid result)
		{
			if ( s == null )
				throw new ArgumentNullException("s");

			regEx.Regex format = new regEx.Regex(
				"^[A-Fa-f0-9]{32}$|" +
				"^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
				"^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
			
			regEx.Match match = format.Match(s);
			
			if ( match.Success )
			{
				result = new Guid(s);
				return true;
			}
			else
			{
				result = Guid.Empty;
				return false;
			}
		}

		/// <summary>Outputs a string containing the type names, delimited by ", "</summary>
		/// <param name="types" type="System.Type[]">
		///     <para>The types to show.</para>
		/// </param>
		/// <returns>A string value...</returns>
		public static string GetTypeNames(params Type[] types)
		{
			StringBuilder builder = new StringBuilder();

			foreach ( Type type in types )
			{
				if ( builder.Length > 0 )
				{
					builder.Append(", ");
				}

				builder.Append(type.Name);
			}

			return builder.ToString();
		}
	}
}
