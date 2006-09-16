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

using System.Xml.Serialization;

namespace NetTiers.Configuration
{
	/// <summary>
	/// Overall configuration settings for Caching
	/// </summary>
	[XmlRoot("nettiers.nettiersSettings", Namespace=DataProviderSettings.ConfigurationNamespace)]
	public class DataProviderSettings
	{
		private string defaultDataProvider;
		private DataProviderDataCollection dataProviders = new DataProviderDataCollection();

		/// <summary>
		/// <para>Gets the Xml namespace for this root node.</para>
		/// </summary>
		/// <value>
		/// <para>The Xml namespace for this root node.</para>
		/// </value>
		public const string ConfigurationNamespace = "http://www.nettiers.com/03-26-2005/provider";

		/// <summary>
		/// Configuration key for cache manager settings.
		/// </summary>
		public const string SectionName = "providerConfiguration";

		/// <summary>
		/// Defines the default manager instance to use when no other manager is specified
		/// </summary>
		[XmlAttribute("defaultDataProvider")]
		public string DefaultDataProvider
		{
			get { return defaultDataProvider; }
			set { defaultDataProvider = value; }
		}

		/// <summary>
		/// Defines the collection of CacheManagerData instances
		/// </summary>
		[XmlArray(ElementName="dataProviders")]
		[XmlArrayItem(ElementName="dataProvider", Type=typeof(DataProviderData))]

		public DataProviderDataCollection DataProviders
		{
			get { return dataProviders; }
		}
	}
}