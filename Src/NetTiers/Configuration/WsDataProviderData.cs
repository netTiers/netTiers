using System;
using System.Xml.Serialization;

namespace NetTiers.Configuration
{
	/// <summary>
	/// Configuration information for WSDataProviderData. This class represents the extra information, over and
	/// above what is defined in <see cref="DataProviderData" />, needed to connect caching to the Data block.
	/// </summary>
    [XmlRoot("dataProvider", Namespace=NetTiersSettings.ConfigurationNamespace)]
	public class WsDataProviderData : DataProviderData
	{
		private string url;
		
		/// <summary>
		/// Initialize a new instance of the <see cref="SQLDataProviderData"/> class.
		/// </summary>
		public WsDataProviderData()
		{
		}

		/// <summary>
		/// Initialize a new instance of the <see cref="SQLDataProviderData"/> class with a name.
		/// </summary>
		/// <param name="name">
		/// The name of the provider.
		/// </param>
		public WsDataProviderData(string name) : base(name)
		{
		}

		/// <summary>
		/// Initialize a new instance of the <see cref="SQLDataProviderData"/> class with a name.
		/// </summary>
		/// <param name="name">
		/// The name of the provider.
		/// </param>
		public WsDataProviderData(string name, string url) : base(name)
		{
			this.url = url;
		}


		/// <summary>
		/// The URL for the ASP.Net Webservice
		/// </summary>
		[XmlAttribute("Url")]
		public string Url 
		{
			get 
			{ 
				return this.url;
			}
			set 
			{
				this.url = value;
			}
		}

		/// <summary>
		/// String representation of the type of the DataProvider object to instantiate
		/// </summary>
		[XmlIgnore]
		public override string TypeName
		{
			get { return "WebServiceClient.WsDataProvider"; }
			set	{}
		}
		
	}
}
