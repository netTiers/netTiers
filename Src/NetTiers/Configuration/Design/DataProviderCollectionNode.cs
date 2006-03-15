
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Validation;

namespace NetTiers.Configuration.Design
{
	/// <summary>
	/// Node that represents a CacheManagerDataCollection
	/// </summary>
	[Image(typeof(DataProviderCollectionNode))]
	public class DataProviderCollectionNode : ConfigurationNode
	{
		private DataProviderDataCollection dataProviderDataCollection;

		/// <summary>
		/// Creates node with initial data.
		/// </summary>
		public DataProviderCollectionNode() : this(new DataProviderDataCollection())
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataProviderCollectionNode"/> class with the given settings.
		/// </summary>
		/// <param name="dataProviderDataCollection">A settings class to use for initialization.</param>
		public DataProviderCollectionNode(DataProviderDataCollection dataProviderDataCollection) : base()
		{
			if (dataProviderDataCollection == null)
			{
				throw new ArgumentNullException("dataProviderDataCollection");
			}
			this.dataProviderDataCollection = dataProviderDataCollection;
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

		/// <summary>
		/// Retrieves configuration data based on the current state of the node.
		/// </summary>
		/// <returns>Configuration data for this node.</returns>
		[Browsable(false)]
		public virtual DataProviderDataCollection DataProviderDataCollection
		{
			get
			{
				this.dataProviderDataCollection.Clear();
				foreach (DataProviderNode node in Nodes)
				{
					this.dataProviderDataCollection[node.DataProviderData.Name] = node.DataProviderData;
				}
				return this.dataProviderDataCollection;
			}
		}

		/// <summary>
		/// Adds a default data provider.
		/// </summary>
		protected override void AddDefaultChildNodes()
		{
			base.AddDefaultChildNodes();
			
			SqlDataProviderData defaultData = new SqlDataProviderData("Sql data provider instance", "Database instance");
			SqlDataProviderNode defaultNode = new SqlDataProviderNode(defaultData);
			//int defaultNodeIdx = Nodes.Add(defaultNode);
			int defaultNodeIdx = Nodes.AddWithDefaultChildren(defaultNode);
			NetTiersSettingsNode settingsNode = Parent as NetTiersSettingsNode;
			if (settingsNode != null)
			{
				settingsNode.DefaultDataProvider = (DataProviderNode)Nodes[defaultNodeIdx];
			}
			
		}

		/// <summary>
		/// Adds the <see cref="CacheManagerNode"/>'s menu items and the and Validate node menu item.
		/// </summary>
		protected override void OnAddMenuItems() 
		{
			AddMenuItem(ConfigurationMenuItem.CreateValidateNodeCommand(Site, this));
			
			// TODO +> construire dynamiquement cette liste
			ConfigurationMenuItem item = new ConfigurationMenuItem("Sql Data provider", new AddChildNodeCommand(Site, typeof(SqlDataProviderNode)), this, Shortcut.None, "Create a new sql data provider", InsertionPoint.New);
			AddMenuItem(item);

			ConfigurationMenuItem item2 = new ConfigurationMenuItem("Web Service Data provider", new AddChildNodeCommand(Site, typeof(WsDataProviderNode)), this, Shortcut.None, "Create a new web service data provider", InsertionPoint.New);
			AddMenuItem(item2);
		}

		/// <summary>
		/// Sets the site's name and builds the cache manager nodes.
		/// </summary>
		protected override void OnSited()
		{
			base.OnSited();
			Site.Name = "Data providers";
			BuildDataProvidersNodes();
		}

		// TODO -> dynamic provider node
		private void BuildDataProvidersNodes()
		{
			foreach (DataProviderData dataProviderData in dataProviderDataCollection)
			{
				if (dataProviderData.TypeName == "SqlClient.SqlDataProvider")
                    Nodes.Add(new SqlDataProviderNode((SqlDataProviderData)dataProviderData));
				else if (dataProviderData.TypeName == "WebServiceClient.WsDataProvider")
					Nodes.Add(new WsDataProviderNode((WsDataProviderData)dataProviderData));
			}
		}

		
	}
}