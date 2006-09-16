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
	/// Node representing a Data Cache Storage
	/// </summary>
	[Image(typeof(WsDataProviderNode))]
	[ServiceDependency(typeof(ILinkNodeService))]
	[ServiceDependency(typeof(IXmlIncludeTypeService))]
	[ServiceDependency(typeof(INodeCreationService))]
	public class WsDataProviderNode : DataProviderNode
	{
		private WsDataProviderData wsDataProviderData;
		
		/// <summary>
		/// Creates node with initial data.
		/// </summary>
		public WsDataProviderNode() : this(new WsDataProviderData("Webservice provider instance"))
		{
		}

		/// <summary>
		/// Creates node with specified data.
		/// </summary>
		/// <param name="dataCacheStorageData">Configuration data.</param>
		public WsDataProviderNode(WsDataProviderData wsDataProviderData) : base(wsDataProviderData)
		{
			this.wsDataProviderData = wsDataProviderData;
		}

		/// <summary>
		/// Read only.  Returns the type name for a DataBackingStore.
		/// </summary>
		/*[Browsable(false)]
		public override string Type
		{
			get { return wsDataProviderData.TypeName; }
		}*/

		
		[Category("General"), Description("The url of the asp.net webservice.")]
		public string Url {
			get {
				return wsDataProviderData.Url;
			}
			set {
				wsDataProviderData.Url = value;
			}
		}

		

		/// <summary>
		/// See <see cref="ConfigurationNode.ResolveNodeReferences"/>.
		/// </summary>
		public override void ResolveNodeReferences()
		{
			base.ResolveNodeReferences();
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
		}
		
	}
}