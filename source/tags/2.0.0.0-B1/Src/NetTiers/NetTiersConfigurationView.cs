//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Configuration Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using Microsoft.Practices.EnterpriseLibrary.Configuration;
using NetTiers.Configuration;

namespace NetTiers
{
	public class NetTiersConfigurationView : ConfigurationView
	{
		public NetTiersConfigurationView(ConfigurationContext configurationContext) : base(configurationContext)
        {
        }

        public virtual DataProviderData GetNetTiersDataProviderData(string name)
        {
            NetTiersSettings settings = GetNetTiersSetting();
            return settings.DataProviders[name];
        }

        public virtual string GetDefaultNetTiersDataProviderDataName()
        {
            NetTiersSettings settings = GetNetTiersSetting();
            return settings.DefaultDataProvider;
        }

        public virtual NetTiersSettings GetNetTiersSetting()
        {
            return (NetTiersSettings)ConfigurationContext.GetConfiguration(NetTiersSettings.SectionName);
        }
	}
}
