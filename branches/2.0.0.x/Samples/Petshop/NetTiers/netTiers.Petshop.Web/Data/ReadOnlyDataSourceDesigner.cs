#region Using Directives
using System;
using System.ComponentModel.Design;
using System.Web.UI.Design;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Provides design-time support in a design host for the ReadOnlyDataSource class.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	[CLSCompliant(true)]
	public abstract class ReadOnlyDataSourceDesigner<Entity> : BaseDataSourceDesigner<Entity, Object>
		where Entity : new()
	{
		/// <summary>
		/// Initializes a new instance of the ReadOnlyDataSourceDesigner class.
		/// </summary>
		public ReadOnlyDataSourceDesigner()
		{
		}

		#region Properties

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ReadOnlyDataSourceSelectMethod SelectMethod
		{
			get { return ( (ReadOnlyDataSource<Entity>) DataSource ).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new ReadOnlyDataSourceActionList<Entity>(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}

		#endregion Properties
	}

	#region ReadOnlyDataSourceActionList

	/// <summary>
	/// Supports the ReadOnlyDataSourceDesigner class.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	internal class ReadOnlyDataSourceActionList<Entity> : DesignerActionList
		where Entity : new()
	{
		private ReadOnlyDataSourceDesigner<Entity> _designer;

		/// <summary>
		/// Initializes a new instance of the ReadOnlyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ReadOnlyDataSourceActionList(ReadOnlyDataSourceDesigner<Entity> designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ReadOnlyDataSourceSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion ReadOnlyDataSourceActionList
}
