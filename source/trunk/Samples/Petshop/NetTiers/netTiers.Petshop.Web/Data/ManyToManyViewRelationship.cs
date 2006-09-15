#region Using Directives
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
	/// be used with controls that display one record of data at a time.
	/// </summary>
	public class ManyToManyViewRelationship : EntityRelationship
	{
		/// <summary>
		/// Initializes a new instance fo the ManyToManyViewRelationship class.
		/// </summary>
		public ManyToManyViewRelationship()
		{
		}

		/// <summary>
		/// Initializes and updates the control with the relationships
		/// held within the specified business object.
		/// </summary>
		/// <param name="entity"></param>
		protected override void UpdateControl(Object entity)
		{
			// Not needed as the configured view control should handle
			// updating the user interface for this relationship.
		}

		/// <summary>
		/// Updates the specified business object with values bound to the
		/// control which represent the current relationships.
		/// </summary>
		/// <param name="entity"></param>
		protected override void UpdateRelationships(Object entity)
		{
			FormView formView = ReferenceMember.ViewControl as FormView;

			if ( formView != null )
			{
				if ( formView.CurrentMode == FormViewMode.Insert )
				{
					// handle the AfterInserted event
					ReferenceMember.GetLinkedDataSource().AfterInserted += new LinkedDataSourceEventHandler(
					delegate(object sender, LinkedDataSourceEventArgs e)
					{
						ReferenceMember.CurrentEntity = e.Entity;
					});

					// force the FormView object to call Insert
					formView.InsertItem(true);
					// get the value of the inserted item's id
					Object referenceId = ReferenceMember.GetEntityId();
					// insert the link record
					InsertLink(entity, referenceId);
				}
				else if ( formView.CurrentMode == FormViewMode.Edit )
				{
					// force the FormView object to call Update
					formView.UpdateItem(true);
				}
			}
		}
	}
}
