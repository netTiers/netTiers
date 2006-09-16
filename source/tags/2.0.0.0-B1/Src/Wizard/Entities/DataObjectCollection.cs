using System;
using System.Collections;
using System.Xml.Serialization;

namespace NetTiers.Wizard.Entities
{
	/// <summary>
	/// Description résumée de DataObjectCollection.
	/// </summary>
	[Serializable]
	public class DataObjectCollection : CollectionBase
	{
		public DataObjectCollection()
		{
		}

		public int Add(DataObject item)
		{
			return this.InnerList.Add(item);
		}

		public void Remove(DataObject item)
		{
			this.InnerList.Remove(item);
		}

		public DataObject this[int index]
		{
			get
			{
				return (DataObject)this.InnerList[index];
			}
			set
			{
				this.InnerList[index] = value;
			}
		}

		public DataObjectCollection SelectedItems
		{
			get
			{
				DataObjectCollection selectedItems = new DataObjectCollection();

				foreach(DataObject datao in this.InnerList)
				{
					if (datao.Selected)
					{
						selectedItems.Add(datao);
					}
				}
				return selectedItems;
			}
		}
	}
}
