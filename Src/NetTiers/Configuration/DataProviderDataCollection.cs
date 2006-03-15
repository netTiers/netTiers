//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Caching Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using Microsoft.Practices.EnterpriseLibrary.Configuration;

namespace NetTiers.Configuration
{
	/// <summary>
	/// Represents a collection of <see cref="DataProviderData"/> settings.
	/// </summary>
	[Serializable]
	public class DataProviderDataCollection : ProviderDataCollection
	{
		/// <summary>
		/// <para>Gets or sets the <see cref="DataProviderData"/> at the specified <paramref name="index"/>.</para>
		/// </summary>
		/// <param name="index">
		/// <para>The index of the <see cref="DataProviderData"/> to get or set.</para>
		/// </param>
		/// <para>The value associated with the specified <paramref name="index"/>. If the specified <paramref name="index"/> is not found, attempting to get it returns a <see langword="null"/> reference (Nothing in Visual Basic), and attempting to set it creates a new entry using the specified <paramref name="index"/>.</para>
		public DataProviderData this[int index]
		{
			get { return (DataProviderData)GetProvider(index); }
			set { SetProvider(index, value); }
		}

		/// <summary>
		/// Indexer to retrieve a named <see cref="DataProviderData"/>.
		/// </summary>        
		/// <param name="name">Name of DataProviderData to retrieve</param>
		public DataProviderData this[string name]
		{
			get { return (DataProviderData)base.GetProvider(name); }
			set { base.SetProvider(name, value); }
		}

		/// <summary>
		/// Add a new <see cref="DataProviderData"/> to the collection.
		/// </summary>
		/// <param name="data">Distribution strategy to add.</param>
		public void Add(DataProviderData data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("DataProvider");
			}
			if (data.Name == null)
			{
				throw new InvalidOperationException("Data provider name is null");
			}
			base.AddProvider(data);
		}

		/// <summary>
		/// Adds the items in the specified collection to the current collection.
		/// </summary>
		/// <param name="collection">A <see cref="DataProviderDataCollection"/>.</param>
		public void AddRange(DataProviderDataCollection collection)
		{
			base.AddProviders(collection);
		}

		/// <summary>
		/// Copies the elements of the <see cref="DataProviderDataCollection"/>
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="CacheManagerDataCollection"/>.</param>
		/// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins. </param>
		public void CopyTo(DataProviderData[] array, int index)
		{
			base.CopyTo((Array)array, index);
		}
	}
}