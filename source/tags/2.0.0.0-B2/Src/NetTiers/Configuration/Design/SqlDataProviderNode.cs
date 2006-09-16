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

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Validation;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration.Design;

namespace NetTiers.Configuration.Design
{
	/// <summary>
	/// Node representing a Sql Data Provider.
	/// </summary>
	[Image(typeof(SqlDataProviderNode))]
	[ServiceDependency(typeof(ILinkNodeService))]
	[ServiceDependency(typeof(IXmlIncludeTypeService))]
	[ServiceDependency(typeof(INodeCreationService))]
	public class SqlDataProviderNode : DataProviderNode
	{
		private SqlDataProviderData sqlDataProviderData;
		private InstanceNode instanceNode;
		private ConfigurationNodeChangedEventHandler onInstanceNodeRemoved;
		private ConfigurationNodeChangedEventHandler onInstanceNodeRenamed;

		/// <summary>
		/// Creates node with initial data.
		/// </summary>
		public SqlDataProviderNode() : this(new SqlDataProviderData("Sql data provider instance"))
		{
		}

		/// <summary>
		/// Creates node with specified data.
		/// </summary>
		/// <param name="dataCacheStorageData">Configuration data.</param>
		public SqlDataProviderNode(SqlDataProviderData sqlDataProviderData) : base(sqlDataProviderData)
		{
			this.sqlDataProviderData = sqlDataProviderData;
			this.onInstanceNodeRemoved += new ConfigurationNodeChangedEventHandler(OnInstanceNodeRemoved);
			this.onInstanceNodeRenamed += new ConfigurationNodeChangedEventHandler(OnInstanceNodeRenamed);
		}

		/// <summary>
		/// Read only.  Returns the type name for a NetTiers dataprovider.
		/// </summary>
		/*[Browsable(false)]
		public override string Type
		{
			get { return sqlDataProviderData.TypeName; }
		}*/

		/// <summary>
		/// The configured database instance node reference.
		/// </summary>
		[Required]
		[Editor(typeof(ReferenceEditor), typeof(UITypeEditor))]
		[ReferenceType(typeof(InstanceNode))]    
		[Category("General")]
		public InstanceNode DatabaseInstance
		{
			get { return instanceNode; }
			set
			{
				ILinkNodeService service = GetService(typeof(ILinkNodeService)) as ILinkNodeService;
				Debug.Assert(service != null, "Could not get the ILinkNodeService");
				instanceNode = service.CreateReference(instanceNode, value, onInstanceNodeRemoved, onInstanceNodeRenamed) as InstanceNode;
				this.sqlDataProviderData.DatabaseInstanceName = string.Empty;
				if (instanceNode != null)
				{
					sqlDataProviderData.DatabaseInstanceName = instanceNode.Name;
				}
			}
		}

		public bool UseStoredProcedure
		{
			get { return this.sqlDataProviderData.UseStoredProcedure;	}
			set { this.sqlDataProviderData.UseStoredProcedure = value;	}
		}		

		/// <summary>
		/// See <see cref="ConfigurationNode.ResolveNodeReferences"/>.
		/// </summary>
		public override void ResolveNodeReferences()
		{
			base.ResolveNodeReferences();
			InstanceCollectionNode instanceCollectionNode = Hierarchy.FindNodeByType(typeof(InstanceCollectionNode)) as InstanceCollectionNode;
			DatabaseInstance = Hierarchy.FindNodeByName(instanceCollectionNode, this.sqlDataProviderData.DatabaseInstanceName) as InstanceNode;
		}

		/// <summary>
		/// Retrieves configuration data based on the current state of the node.
		/// </summary>
		/// <returns>Configuration data for this node.</returns>
		public override DataProviderData DataProviderData
		{
			get
			{
				return base.DataProviderData;
			}
		}


		/// <summary>
		/// Initializes the data configuration section of the configuration tree
		/// </summary>
		protected override void AddDefaultChildNodes()
		{
			base.AddDefaultChildNodes();
			CreateDatabaseSettingsNode();
		}

		private void OnInstanceNodeRemoved(object sender, ConfigurationNodeChangedEventArgs e)
		{
			this.instanceNode = null;
		}

		private void OnInstanceNodeRenamed(object sender, ConfigurationNodeChangedEventArgs e)
		{
			this.sqlDataProviderData.DatabaseInstanceName = e.Node.Name;
		}
		
		public void CreateDatabaseSettingsNode()
		{
			if (!DatabaseSettingsNodeExists())
			{
				AddConfigurationSectionCommand cmd = new AddConfigurationSectionCommand(Site, typeof(DatabaseSettingsNode), DatabaseSettings.SectionName);
				cmd.Execute(Hierarchy.RootNode);
			}
		}

		public bool DatabaseSettingsNodeExists()
		{
			DatabaseSettingsNode node = Hierarchy.FindNodeByType(typeof(DatabaseSettingsNode)) as DatabaseSettingsNode;
			return (node != null);
		}

		
	}
}