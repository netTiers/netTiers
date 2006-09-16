using System;

namespace NetTiers.Wizard.Utilities
{
	/// <summary>
	/// Description résumée de SchemaExplorerAdapter.
	/// </summary>
	public class SchemaExplorerAdapter
	{
		public SchemaExplorerAdapter()
		{
			
		}

		public Entities.DataObjectCollection CreateDataSource(SchemaExplorer.DatabaseSchema database)
		{
			Entities.DataObjectCollection ds = new NetTiers.Wizard.Entities.DataObjectCollection();
			return ds;
		}
	}
}
