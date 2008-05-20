#region Imports...
using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Web.UI;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Provides management of a one-to-many relationship between a primary
	/// table and a child table. This control is specifically designed to
	/// be used with the System.Web.UI.WebControls.GridView class.
	/// </summary>
	public class OneToManyGridRelationship : EntityRelationship
	{
		/// <summary>
		/// Initializes a new instance of the OneToManyGridRelationship class.
		/// </summary>
		public OneToManyGridRelationship()
		{
		}

		/// <summary>
		/// Initializes and updates the control with the relationships
		/// held within the specified business object.
		/// </summary>
		/// <param name="entity"></param>
		protected override void UpdateControl(Object entity)
		{
			IList links = GetReferenceList(entity);

			foreach ( Object link in links )
			{
				UpdateLink(link);
			}
		}

		/// <summary>
		/// Initializes and updates the control with the relationships
		/// held within the specified business object.
		/// </summary>
		/// <param name="link">The business object that contains
		/// the current relationships with which to update the control.</param>
		protected virtual void UpdateLink(Object link)
		{
			GridViewRowCollection rows = ReferenceMember.GridControl.Rows;
			GridViewRow row = ReferenceMember.GetRow(rows, link);
			Object value;

			if ( row != null )
			{
				// update row values
				foreach ( EntityProperty property in ReferenceMember.PropertyMappings )
				{
					value = EntityUtil.GetPropertyValue(link, property.DataField);
					ReferenceMember.SetValue(row, property.DataField, value);
				}
			}
		}

		/// <summary>
		/// Updates the specified business object with values bound to the
		/// control which represent the current relationships.
		/// </summary>
		/// <param name="entity"></param>
		protected override void UpdateRelationships(Object entity)
		{
			IList links = GetReferenceList(entity);
			IList remove = new ArrayList();

			// verify current items
			foreach ( Object link in links )
			{
				if ( !ReferenceMember.IsCurrentItem(ReferenceMember.GridControl.Rows, link) )
				{
					remove.Add(link);
				}
			}

			// remove delted items
			foreach ( Object link in remove )
			{
				RemoveReference(links, link);
			}

			// add new & update existing items
			IDictionary values;
			Object child;

			// loop through each row
			foreach ( GridViewRow row in ReferenceMember.GridControl.Rows )
			{
				values = ReferenceMember.GetValues(row);

				if ( ReferenceMember.IsNewItem(row) )
				{
					InsertReference(links, values);
				}
				else
				{
					child = ReferenceMember.GetLink(links, row);
					UpdateReference(child, values);
				}
			}
		}
	}
}
