using System;
using System.Xml.Serialization;
namespace NetTiers.Configuration
{
	/// <summary>
	/// The settings class that is used by the SqlDataProvider.
	/// </summary>
	[XmlRoot("dataProvider", Namespace=NetTiersSettings.ConfigurationNamespace)]
	public class SqlDataProviderData : DataProviderData
	{
		private string databaseInstanceName;
		private bool useStoredProcedure;

        		
		/// <summary>
		/// Initialize a new instance of the <see cref="SQLDataProviderData"/> class.
		/// </summary>
		public SqlDataProviderData()
		{
		}

		/// <summary>
		/// Initialize a new instance of the <see cref="SQLDataProviderData"/> class with a name.
		/// </summary>
		/// <param name="name">
		/// The name of the provider.
		/// </param>
		public SqlDataProviderData(string name) : base(name)
		{
		}

		/// <summary>
		/// Initialize a new instance of the <see cref="SQLDataProviderData"/> class with a name.
		/// </summary>
		/// <param name="name">
		/// The name of the provider.
		/// </param>
		public SqlDataProviderData(string name, string databaseInstanceName) : base(name)
		{
			this.databaseInstanceName = databaseInstanceName;
		}

		
		/// <summary>
		/// Name of the database instance to use for storage. Instance must be defined in Data configuration.
		/// </summary>
		[XmlAttribute("databaseInstanceName")]
		public string DatabaseInstanceName
		{
			get { return databaseInstanceName; }
			set { databaseInstanceName = value; }
		}

		[XmlElement("useStoredProcedure")]
		public bool UseStoredProcedure
		{
			get { return this.useStoredProcedure;	}
			set { this.useStoredProcedure = value;	}
		}

		/// <summary>
		/// String representation of the type of the DataBackingStore object to instantiate
		/// </summary>
		[XmlIgnore]
		public override string TypeName
		{
			get { return "SqlClient.SqlDataProvider"; }
			set	{}
		}

		
	}
}