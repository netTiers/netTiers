#region Using Directives
using System;
using System.ComponentModel;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.ExtendedItemProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(ExtendedItemDataSourceDesigner))]
	public class ExtendedItemDataSource : ReadOnlyDataSource<ExtendedItem>
	{
		/// <summary>
		/// Initializes a new instance of the ExtendedItemDataSource class.
		/// </summary>
		public ExtendedItemDataSource() : base(DataRepository.ExtendedItemProvider)
		{
		}
	}

	#region ExtendedItemDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ExtendedItemDataSource class.
	/// </summary>
	public class ExtendedItemDataSourceDesigner : ReadOnlyDataSourceDesigner<ExtendedItem>
	{
	}

	#endregion ExtendedItemDataSourceDesigner

	#region ExtendedItemFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtendedItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtendedItemFilter : SqlFilter<ExtendedItemColumn>
	{
	}

	#endregion ExtendedItemFilter
}
