using System;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using System.ComponentModel;

namespace NetTiers.Configuration
{
	/// <summary>
	/// Base class for the settings that are used by a specific DataProvider implementation.
	/// </summary>
	[XmlInclude(typeof(SqlDataProviderData))]
	[XmlInclude(typeof(WsDataProviderData))]
	[XmlRoot("dataProvider", Namespace=NetTiersSettings.ConfigurationNamespace)]
	public abstract class DataProviderData : ProviderData
	{
		
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DataProviderData"/> class.
		/// </summary>
		protected DataProviderData() : this(string.Empty)
		{
			
		}

		/// <summary>
		/// Initialize a new instance of the <see cref="DataProviderData"/> class.
		/// </summary>
		/// <param name="name">
		/// The name of the <see cref="CacheManagerData"/>.
		/// </param>
		protected DataProviderData(string name) : base(name)
		{
		}
		
		/*
		private string myProvider;
		/// <summary>
		/// Hold the concrete type of the DataProvider (the nettiers generated SqlClient for example)
		/// </summary>
		public string MyProvider
		{
			get {return this.myProvider;}
			set {this.myProvider = value;}
		}
		*/
	}
}
