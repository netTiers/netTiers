using System;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using NetTiers.Configuration;

namespace NetTiers
{
	/// <summary>
	/// Creates an <see cref="NetTiersDataProviderFactory"/> object based on the current context.
	/// </summary>
	public class NetTiersDataProviderFactory : ProviderFactory
	{
		/// <summary>
		/// Creates a new instance of <see cref="NetTiersDataProviderFactory"/>.
		/// </summary>
		public NetTiersDataProviderFactory() : this(ConfigurationManager.GetCurrentContext())
		{
		}

		/// <summary>
		/// Creates a new instance of <see cref="NetTiersDataProviderFactory"/>.
		/// </summary>
		/// <param name="context">A <see cref="ConfigurationContext"/> object.</param>
		public NetTiersDataProviderFactory(ConfigurationContext context) : base("NetTiers Data Provider Factory", context, typeof(INetTiersDataProvider))
		{
		}

		/// <summary>
		/// Creates the <see cref="INetTiersDataProvider"/> object associated with the specified name.
		/// </summary>
		/// <param name="name">Name of the provider.</param>
		/// <returns>The associated <see cref="IGreetingProvider"/> object.</returns>
		public INetTiersDataProvider GetNetTiersProvider(string name)
		{
			return (INetTiersDataProvider)base.CreateInstance(name);
		}

		/// <summary>
		/// Creates the default <see cref="IGreetingProvider"/> object.
		/// </summary>
		/// <returns>The default <see cref="IGreetingProvider"/> object.</returns>
		public INetTiersDataProvider GetNetTiersProvider()
		{
			return (INetTiersDataProvider)base.CreateDefaultInstance();
		}
        /// <summary>
        /// <para>Gets the default greeting provider name.</para>
        /// </summary>
        /// <returns>
        /// <para>The default greeting provider name.</para>
        /// </returns>
        protected override string GetDefaultInstanceName()
        {
            NetTiersConfigurationView view = (NetTiersConfigurationView)CreateConfigurationView();
            return view.GetDefaultNetTiersDataProviderDataName();
        }
       
        protected override ConfigurationView CreateConfigurationView()
        {
            return new NetTiersConfigurationView(ConfigurationContext);
        }

        protected override Type GetConfigurationType(string instanceName)
        {
            NetTiersConfigurationView view = (NetTiersConfigurationView)CreateConfigurationView();
            DataProviderData netTiersDataProviderData = view.GetNetTiersDataProviderData(instanceName);
            return GetType(netTiersDataProviderData.TypeName);
        }
	}
}
