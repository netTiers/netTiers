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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration.Design;

using Microsoft.Practices.EnterpriseLibrary.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Validation;

namespace NetTiers.Configuration.Design
{
	/// <summary>
	/// The root node for caching configuration.
	/// </summary>
	[Image(typeof(NetTiersSettingsNode))]
	[ServiceDependency(typeof(ILinkNodeService))]
	public class NetTiersSettingsNode : ConfigurationNode
	{
		private NetTiersSettings netTiersSettings;
		
		private DataProviderNode dataProviderNode;
		private ConfigurationNodeChangedEventHandler dataProviderNodeRemovedHandler;
		private ConfigurationNodeChangedEventHandler dataProviderNodeRenamedHandler;

		private CacheManagerNode cacheManagerNode;
		private ConfigurationNodeChangedEventHandler cacheManagerNodeRemovedHandler;
		private ConfigurationNodeChangedEventHandler cacheManagerNodeRenamedHandler;

		/// <summary>
		/// Creates node with initial data.
		/// </summary>
		public NetTiersSettingsNode() : this(new NetTiersSettings())
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CacheManagerSettingsNode"/> class.
		/// </summary>
		/// <param name="cacheManagerSettings">The settings to use for initialization.</param>
		public NetTiersSettingsNode(NetTiersSettings netTiersSettings) : base()
		{
			this.dataProviderNodeRemovedHandler = new ConfigurationNodeChangedEventHandler(OnDataProviderNodeRemoved);
			this.dataProviderNodeRenamedHandler = new ConfigurationNodeChangedEventHandler(OnDataProviderNodeRenamed);
			
			this.cacheManagerNodeRemovedHandler = new ConfigurationNodeChangedEventHandler(OnCacheManagerNodeRemoved);
			this.cacheManagerNodeRenamedHandler = new ConfigurationNodeChangedEventHandler(OnCacheManagerNodeRenamed);
           
			this.netTiersSettings = netTiersSettings;
		}

		/// <summary>
		/// <para>Gets the name for the node.</para>
		/// </summary>
		/// <value>
		/// <para>The display name for the node.</para>
		/// </value>
		/// <remarks>
		/// <para>The name should be the <seealso cref="ISite.Name"/>.</para>
		/// </remarks>
		/// <exception cref="InvalidOperationException">
		/// <para>The name already exists in the parent's node collection.</para>
		/// </exception>
		[ReadOnly(true)]
		public override string Name
		{
			get { return base.Name; }
			set { base.Name = value; }
		}

       
		[Category("General"), Description("The codesmith properties file for the templates.(Optional, for future use.)")]
		[Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(UITypeEditor))]
		public string PropertiesFile
		{
			get {return this.NetTiersSettings.PropertiesFile;}
			set {this.NetTiersSettings.PropertiesFile = value;}
		}
		

		[Category("Caching"), Description("The .NetTiers cache manager")]
		[Editor(typeof(ReferenceEditor), typeof(UITypeEditor))]
		[ReferenceType(typeof(CacheManagerNode))]
		[Required]
		public CacheManagerNode CacheManager 
		{
			get {return cacheManagerNode;}
			set 
			{
				ILinkNodeService service = (ILinkNodeService)GetService(typeof(ILinkNodeService));
				System.Diagnostics.Debug.Assert(null!=service, "Could not get the ILinkNodeService");
				this.cacheManagerNode = service.CreateReference(cacheManagerNode, value, cacheManagerNodeRemovedHandler, cacheManagerNodeRenamedHandler) as CacheManagerNode;
				netTiersSettings.CacheManagerName = cacheManagerNode == null ? string.Empty : cacheManagerNode.Name;
			}
		}
		

		/// <summary>
		/// The default data provider
		/// </summary>
		[Required]
		[Description("The default data provider")]
		[Editor(typeof(ReferenceEditor), typeof(UITypeEditor))]
		[ReferenceType(typeof(DataProviderNode))]
		[Category("General")]
		public DataProviderNode DefaultDataProvider
		{
			get { return this.dataProviderNode; }
			set
			{
				ILinkNodeService service = GetService(typeof(ILinkNodeService)) as ILinkNodeService;
				Debug.Assert(service != null, "Could not get the ILinkNodeService");
				this.dataProviderNode = (DataProviderNode)service.CreateReference(dataProviderNode, value, dataProviderNodeRemovedHandler, dataProviderNodeRenamedHandler);
				this.netTiersSettings.DefaultDataProvider = dataProviderNode == null ? String.Empty : dataProviderNode.Name;
			}
		}

		/// <summary>
		/// Retrieves configuration data based on the current state of the node.
		/// </summary>
		/// <returns>Configuration data for this node.</returns>
		[Browsable(false)]
		public virtual NetTiersSettings NetTiersSettings
		{
			get
			{
				DataProviderCollectionNode dataProviderCollectionNode = Hierarchy.FindNodeByType(this, typeof(DataProviderCollectionNode)) as DataProviderCollectionNode;
				Debug.Assert(dataProviderCollectionNode != null, "We should have a data provider collection.");
				DataProviderDataCollection dataProviderDataCollection = dataProviderCollectionNode.DataProviderDataCollection;
				if (Object.ReferenceEquals(dataProviderDataCollection, netTiersSettings.DataProviders))
				{
					return netTiersSettings;
				}

				netTiersSettings.DataProviders.Clear();
				foreach (DataProviderData providerData in dataProviderDataCollection)
				{
					netTiersSettings.DataProviders[providerData.Name] = providerData;
				}
				return netTiersSettings;
			}

		}

		/// <summary>
		/// See <see cref="ConfigurationNode.ResolveNodeReferences"/>.
		/// </summary>
		public override void ResolveNodeReferences()
		{
			base.ResolveNodeReferences();
		
			DataProviderCollectionNode nodes = Hierarchy.FindNodeByType(this, typeof(DataProviderCollectionNode)) as DataProviderCollectionNode;
			DefaultDataProvider = Hierarchy.FindNodeByName(nodes, this.netTiersSettings.DefaultDataProvider) as DataProviderNode;
			
			CacheManagerCollectionNode nodes2 = Hierarchy.FindNodeByType(this.Parent, typeof(CacheManagerCollectionNode)) as CacheManagerCollectionNode;
			CacheManager = Hierarchy.FindNodeByName(nodes2, this.netTiersSettings.CacheManagerName) as CacheManagerNode;
        
		}

		/// <summary>
		/// Adds default nodes for managers and storages.
		/// </summary>
		protected override void AddDefaultChildNodes()
		{
			base.AddDefaultChildNodes();
            
			DataProviderCollectionNode node = new DataProviderCollectionNode(this.netTiersSettings.DataProviders);
			Nodes.AddWithDefaultChildren(node);

			//CacheManagerCollectionNode nod2e = new CacheManagerCollectionNode(this.cacheManagerSettings.CacheManagers);
			//Nodes.AddWithDefaultChildren(node2);

			this.CreateCacheManagerSettingsNode();
		}

		/// <summary>
		/// Creates a default <see cref="CacheManagerCollectionNode"/> when this node is sited.
		/// </summary>
		protected override void OnSited()
		{
			base.OnSited();
			Site.Name = ".NetTiers Application Block";//SR.DefaultCacheManagerSettingsNodeName;
			if ((netTiersSettings.DataProviders != null) && (netTiersSettings.DataProviders.Count > 0))
			{
				DataProviderCollectionNode node = new DataProviderCollectionNode(netTiersSettings.DataProviders);
				Nodes.Add(node);
			}
			
		}

		/// <summary>
		/// <para>Adds a menu item for the CacheManagerCollectionNode.</para>
		/// </summary>
		protected override void OnAddMenuItems()
		{
			base.OnAddMenuItems();
//			ConfigurationNodeCommand cmd = new ConfigurationNodeCommand();
//			cmd.
//			ConfigurationMenuItem generate = new ConfigurationMenuItem(

			ConfigurationMenuItem item = ConfigurationMenuItem.CreateAddChildNodeMenuItem(Site, this, typeof(DataProviderCollectionNode), "Data provider", false);
			AddMenuItem(item);
		}

		/// <summary>
		/// Raises the ChildAdded event and confirms that only one <see cref="CacheManagerCollectionNode"/> has been added.
		/// </summary>
		/// <param name="e">A 
		/// <see cref="ConfigurationNodeChangedEventArgs"/> that contains
		/// the event data.</param>
		/// <exception cref="InvalidOperationException" />
		protected override void OnChildAdded(ConfigurationNodeChangedEventArgs e)
		{
			base.OnChildAdded (e);
			if (Nodes.Count > 1 && e.Node.GetType() == typeof(DataProviderCollectionNode))
			{
				throw new InvalidOperationException("Only one data provider collection node");
			}
		}


		private void OnDataProviderNodeRemoved(object sender, ConfigurationNodeChangedEventArgs e)
		{
			this.dataProviderNode = null;
		}

		private void OnDataProviderNodeRenamed(object sender, ConfigurationNodeChangedEventArgs e)
		{
			this.netTiersSettings.DefaultDataProvider = e.Node.Name;
		}

		private void OnCacheManagerNodeRemoved(object sender, ConfigurationNodeChangedEventArgs e)
		{
			this.cacheManagerNode = null;
		}

		private void OnCacheManagerNodeRenamed(object sender, ConfigurationNodeChangedEventArgs e)
		{
			this.netTiersSettings.CacheManagerName = e.Node.Name;
		}

		/// <summary>
		/// Used to create a blank database node if none exist in the application.
		/// </summary>
		private void CreateCacheManagerSettingsNode() 
		{
			if (!CacheManagerSettingsNodeExists()) 
			{
				AddConfigurationSectionCommand cmd = new AddConfigurationSectionCommand(Site, typeof(CacheManagerSettingsNode), CacheManagerSettings.SectionName);
				cmd.Execute(Hierarchy.RootNode);
			}
		}

		/// <summary>
		/// Attempts to find a cache manager settings node in the configuration and returns if it was successful
		/// </summary>
		/// <returns>True if a DatabaseSettingsNode exist, and False if it doesn't.</returns>
		private bool CacheManagerSettingsNodeExists() 
		{
			CacheManagerSettingsNode node = (CacheManagerSettingsNode)Hierarchy.FindNodeByType(typeof(CacheManagerSettingsNode));
			return (null!=node);
		}
		
	}
}