
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Validation;

namespace NetTiers.Configuration.Design
{
	/// <summary>
	/// Node that represents a CacheStorageData
	/// </summary>
	[Image(typeof(DataProviderNode))]
	public abstract class DataProviderNode : ConfigurationNode
	{
		private DataProviderData dataProviderData;

		/// <summary>
		/// Creates node with sepecifed display name and configuration data.
		/// </summary>
		/// <param name="dataProviderData">The configuration data.</param>
		protected DataProviderNode(DataProviderData dataProviderData) : base()
		{
			if (dataProviderData == null)
			{
				throw new ArgumentNullException("dataProviderData");
			}
			this.dataProviderData = dataProviderData;
		}

//		/// <summary>
//		/// Name of the type used to implement this behavior
//		/// </summary>
//		[Required]
//		[Description("Data provider type")]
//		[Category("General")]
//		//[Editor(typeof(Microsoft.Practices.EnterpriseLibrary.Configuration.Design.TypeSelectorEditor), typeof(System.Drawing.Design.UITypeEditor))] 
//		[Editor(typeof(TypeSelectorEditor), typeof(UITypeEditor))] 
//		[BaseType(typeof(IDataProvider))] 
//		public virtual string TypeName 
//		{ 
//			get { return this.dataProviderData.TypeName; } 
//			set { this.dataProviderData.TypeName = value; } 
//		}

		//[Required]
		//[Description("NetTiers generated Data provider type")]
		//[Category("General")]
		//[Editor(typeof(TypeSelectorEditor), typeof(UITypeEditor))] 
		//[BaseType(typeof(INetTiersDataProvider))] 
        [Browsable(false)]
        public virtual string TypeName 
		{ 
			get { return this.dataProviderData.TypeName; }
            set { this.dataProviderData.TypeName = value; } 
		}

        /*
        [Required]
        [Description("NetTiers generated Data provider type")]
        [Editor(typeof(TypeSelectorEditor), typeof(UITypeEditor))]
        [BaseType(typeof(INetTiersDataProvider))] 
        public virtual string MyProvider
        {
            get { return this.dataProviderData.MyProvider; }
            set { this.dataProviderData.MyProvider = value; }
        }
        */

		/// <summary>
		/// Retrieves configuration data based on the current state of the node.
		/// </summary>
		/// <returns>Configuration data for this node.</returns>
		[Browsable(false)]
		public virtual DataProviderData DataProviderData
		{
			get
			{
				//dataProviderData.StorageEncryption = GetStorageEncryptionData();
				return dataProviderData;
			}
		}

		/// <summary>
		/// <para>Sets the name based on the data name and adds the encyrption node if one exists.</para>
		/// </summary>
		protected override void OnSited()
		{
			base.OnSited();
			Site.Name = dataProviderData.Name;			
		}

		/// <summary>
		/// <para>Adds the default menu items.</para>
		/// </summary>
		protected override void OnAddMenuItems()
		{
			base.OnAddMenuItems();
			//CreateDynamicMenuItems(typeof(StorageEncryptionNode));
		}

		/// <summary>
		/// <para>Renames the underlying data.</para>
		/// </summary>
		/// <param name="e"><para>A <see cref="ConfigurationNodeChangedEventArgs"/> that contains the event data.</para></param>
		protected override void OnRenamed(ConfigurationNodeChangedEventArgs e)
		{
			base.OnRenamed(e);
			dataProviderData.Name = e.Node.Name;
		}

		
	}
}