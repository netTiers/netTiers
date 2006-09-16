using System;
using System.Xml.Serialization;
using EntLib = Microsoft.Practices.EnterpriseLibrary.Configuration;

namespace NetTiers.Configuration
{
	/// <summary>
	/// This class is the serializable representation of our configuration data.
	/// </summary>
	/// 
	[XmlRoot("enterpriseLibrary.netTiersSettings", Namespace=NetTiersSettings.ConfigurationNamespace)]
    public class NetTiersSettings
	{
		private string name;
		private string cacheManagerName;
		private DataProviderDataCollection dataProviders = new DataProviderDataCollection();
		private string defaultDataProvider;
		private string propertiesFile;
		
		/// <summary>
		/// <para>Gets the Xml namespace for this root node.</para>
		/// </summary>
		/// <value>
		/// <para>The Xml namespace for this root node.</para>
		/// </value>
		public const string ConfigurationNamespace = "http://www.nettiers.com/enterpriselibrary/03-28-2005/nettiers";

		public const string SectionName = "netTiersConfigData";
		

		/// <summary>
		/// Creates a new <see cref="NetTiersSettings"/> instance.
		/// </summary>
		public NetTiersSettings() 
		{
		}

		/// <summary>
		/// Creates a new <see cref="NetTiersSettings"/> instance.
		/// </summary>
		/// <param name="name">Name.</param>
		public NetTiersSettings(string name)
		{
			this.name = name;
		}
				
		[XmlElement("Name")]
		public string Name
		{
			get { return this.name;	}
			set { this.name = value;	}
		}

		/// <summary>
		/// Defines the default data provider instance.
		/// </summary>
		[XmlAttribute("defaultDataProvider")]
		public string DefaultDataProvider
		{
			get { return defaultDataProvider; }
			set { defaultDataProvider = value; }
		}

		/// <summary>
		/// Defines the default manager instance.
		/// </summary>
		[XmlAttribute("cacheManagerName")]
		public string CacheManagerName
		{
			get { return this.cacheManagerName;}
			set { this.cacheManagerName = value;	}
		}


		/// <summary>
		/// The path to the the nettiers xml properties file.
		/// </summary>
		[XmlAttribute("propertiesFile")]
		public string PropertiesFile
		{
			get { return this.propertiesFile;}
			set { this.propertiesFile = value;	}
		}
		/// <summary>
		/// Defines the collection of DataProvider instances.
		/// </summary>
		[XmlArray(ElementName="dataProviders")]
		[XmlArrayItem(ElementName="dataProvider", Type=typeof(DataProviderData))]
		public DataProviderDataCollection DataProviders
		{
			get { return dataProviders; }
		}
	}
}
