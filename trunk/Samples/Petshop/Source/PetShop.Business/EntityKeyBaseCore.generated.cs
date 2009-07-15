﻿#region Using Directives
using System;
using System.Collections;
#endregion

namespace PetShop.Business
{
	/// <summary>
	/// The base object for each database table's unique identifier.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public abstract partial class EntityKeyBaseCore : IEntityKey
	{
		/// <summary>
		/// Reads values from the supplied IDictionary object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An IDictionary instance that contains the key/value
		/// pairs to be used as property values.</param>
		public abstract void Load(IDictionary values);

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public abstract IDictionary ToDictionary();

		/// <summary>
		/// Determines whether the specified System.Object is equal to the current object.
		/// </summary>
		/// <param name="obj">The System.Object to compare with the current object.</param>
		/// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
		public override bool Equals(object obj)
		{
			if ( obj == null || GetType() != obj.GetType() ) return false;
			return ( ToString() == obj.ToString() );
		}

		/// <summary>
		/// Serves as a hash function for a particular type. GetHashCode() is suitable
		/// for use in hashing algorithms and data structures like a hash table.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}
	}
}
