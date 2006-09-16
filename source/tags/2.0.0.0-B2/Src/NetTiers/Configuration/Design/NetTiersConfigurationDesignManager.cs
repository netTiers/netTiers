using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design;

namespace NetTiers.Configuration.Design
{
	/// <summary>
	/// Description résumée de NetTiersConfigurationDesignManager.
	/// </summary>
	public class NetTiersConfigurationDesignManager : IConfigurationDesignManager
	{
		/// <summary>
		/// Create's an instance of the block manager.
		/// </summary>
		public NetTiersConfigurationDesignManager()
		{
		}

		/// <summary>
		/// <para>Registers the <see cref="CacheManagerSettings"/> in the application.</para>
		/// </summary>
		/// <param name="serviceProvider">
		/// <para>The a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</para>
		/// </param>
		public void Register(IServiceProvider serviceProvider)
		{
			RegisterNodeMaps(serviceProvider);
			CreateCommands(serviceProvider);
		}

		/// <summary>
		/// <para>Opens the configuration settings and registers them with the application.</para>
		/// </summary>
		/// <param name="serviceProvider">
		/// <para>The a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</para>
		/// </param>
		public void Open(IServiceProvider serviceProvider)
		{
			ConfigurationContext configurationContext = ServiceHelper.GetCurrentConfigurationContext(serviceProvider);
			if (configurationContext.IsValidSection(NetTiersSettings.SectionName))
			{
				NetTiersSettingsNode netTiersSettingsNode = null;
				try
				{
					NetTiersSettings settings = configurationContext.GetConfiguration(NetTiersSettings.SectionName) as NetTiersSettings;
					if (settings != null)
					{
						netTiersSettingsNode = new NetTiersSettingsNode(settings);
						ConfigurationNode configurationNode = ServiceHelper.GetCurrentRootNode(serviceProvider);
						configurationNode.Nodes.Add(netTiersSettingsNode);
					}
				}
				catch (ConfigurationException e)
				{
					ServiceHelper.LogError(serviceProvider, netTiersSettingsNode, e);
				}
			}
		}

		/// <summary>
		/// <para>Saves the configuration settings created for the application.</para>
		/// </summary>
		/// <param name="serviceProvider">
		/// <para>The a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</para>
		/// </param>
		public void Save(IServiceProvider serviceProvider)
		{
			ConfigurationContext configurationContext = ServiceHelper.GetCurrentConfigurationContext(serviceProvider);
			if (configurationContext.IsValidSection(NetTiersSettings.SectionName))
			{
				NetTiersSettingsNode netTiersSettingsNode = GetNetTiersSettingsNode(serviceProvider);
				NetTiersSettings settings = netTiersSettingsNode.NetTiersSettings;
				if (settings != null)
				{
					try
					{
						configurationContext.WriteConfiguration(NetTiersSettings.SectionName, settings);
					}
					catch (InvalidOperationException e)
					{
						ServiceHelper.LogError(serviceProvider, netTiersSettingsNode, e);
					}
				}
			}
		}

		/// <summary>
		/// <para>Adds to the dictionary configuration data for 
		/// the enterpriselibrary.configurationSettings configuration section.</para>
		/// </summary>
		/// <param name="serviceProvider">
		/// <para>The a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</para>
		/// </param>
		/// <param name="configurationDictionary">
		/// <para>A <see cref="ConfigurationDictionary"/> to add 
		/// configuration data to.</para></param>
		public void BuildContext(IServiceProvider serviceProvider, ConfigurationDictionary configurationDictionary)
		{
			NetTiersSettingsNode node = GetNetTiersSettingsNode(serviceProvider);
			if (node != null)
			{
				NetTiersSettings settings = node.NetTiersSettings;
				configurationDictionary[NetTiersSettings.SectionName] = settings;
			}
		}

		private static NetTiersSettingsNode GetNetTiersSettingsNode(IServiceProvider serviceProvider)
		{
			IUIHierarchy hierarchy = ServiceHelper.GetCurrentHierarchy(serviceProvider);
			if (hierarchy == null) return null;

			return hierarchy.FindNodeByType(typeof(NetTiersSettingsNode)) as NetTiersSettingsNode;
		}

		private static void CreateCommands(IServiceProvider serviceProvider)
		{
			IUIHierarchyService hierarchyService = ServiceHelper.GetUIHierarchyService(serviceProvider);
			IUIHierarchy currentHierarchy = hierarchyService.SelectedHierarchy;
			bool containsNode = currentHierarchy.ContainsNodeType(typeof(NetTiersSettingsNode));
			IMenuContainerService menuService = ServiceHelper.GetMenuContainerService(serviceProvider);
			ConfigurationMenuItem item = new ConfigurationMenuItem(".NetTiers Application Block", new AddConfigurationSectionCommand(serviceProvider, typeof(NetTiersSettingsNode), NetTiersSettings.SectionName), ServiceHelper.GetCurrentRootNode(serviceProvider), Shortcut.None, "Create a new NetTiers configuration block", InsertionPoint.New);
			item.Enabled = !containsNode;
			menuService.MenuItems.Add(item);

		}

		private static void RegisterNodeMaps(IServiceProvider serviceProvider)
		{
			INodeCreationService nodeCreationService = ServiceHelper.GetNodeCreationService(serviceProvider);
            
//			Type nodeType = typeof(SqlDataProviderNode);
//			NodeCreationEntry entry = NodeCreationEntry.CreateNodeCreationEntryNoMultiples(new AddChildNodeCommand(serviceProvider, nodeType), nodeType, typeof(SqlDataProviderData), "Sql Data provider");
//			nodeCreationService.AddNodeCreationEntry(entry);
            
//			nodeType = typeof(WsDataProviderNode);
//			entry = NodeCreationEntry.CreateNodeCreationEntryNoMultiples(new AddChildNodeCommand(serviceProvider, nodeType), nodeType, typeof(CustomCacheStorageData), SR.DefaultCustomCacheStorageNodeName);
//			nodeCreationService.AddNodeCreationEntry(entry);
		}
	}
}
