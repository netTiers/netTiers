#region Using directives
using System.Collections;
#endregion

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	/// Defines a method that allows setting of property values
	/// based on the key/value pairs of an IDictionary object.
	/// </summary>
	public interface IEntityKey
	{
		/// <summary>
		/// Reads values from the supplied IDictionary object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An IDictionary instance that contains the key/value
		/// pairs to be used as property values.</param>
		void Load(IDictionary values);

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		IDictionary ToDictionary();
	}
}
