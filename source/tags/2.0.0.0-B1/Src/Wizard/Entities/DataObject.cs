using System;
using System.Xml.Serialization;

namespace NetTiers.Wizard.Entities
{
	public enum DataObjectType
	{
		Table
		, View
		, Custom
	}

	/// <summary>
	/// Description résumée de DataObject.
	/// </summary>
	[Serializable]
	public class DataObject
	{

		#region Properties

		private string databaseObjectName;
		private DataObjectType type;
		

		[XmlAttribute("databaseObjectName")]
		public string DatabaseObjectName
		{
			get
			{
				return (this.databaseObjectName);
			}
			set
			{
				this.databaseObjectName = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public DataObjectType Type
		{
			get
			{
				return (this.type);
			}
			set
			{
				this.type = value;
			}
		}

		private string name;

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[XmlAttribute("name")]
		public string Name
		{
			get
			{
				return (this.name);
			}
			set
			{
				this.name = value;
			}
		}

		private string aliasName;

		/// <summary>
		/// Gets or sets the name of the alias.
		/// </summary>
		/// <value>The name of the alias.</value>
		[XmlAttribute("aliasName")]
		public string AliasName
		{
			get
			{
				return (this.aliasName);
			}
			set
			{
				this.aliasName = value;
			}
		}

		private string description;

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		[XmlAttribute("description")]
		public string Description
		{
			get
			{
				return (this.description);
			}
			set
			{
				this.description = value;
			}
		}

		private bool selected;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="DataObject"/> is selected.
		/// </summary>
		/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
		public bool Selected
		{
			get
			{
				return (this.selected);
			}
			set
			{
				this.selected = value;
			}
		}

	
		#endregion

		public DataObject()
		{
		}
	}
}
