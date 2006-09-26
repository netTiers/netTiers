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
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Provides management of a one-to-one relationship
	/// between two business objects.
	/// </summary>
	public class OneToOneViewRelationship : EntityRelationship
	{
		/// <summary>
		/// Initializes a new instance of the OneToOneViewRelationship class.
		/// </summary>
		public OneToOneViewRelationship()
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
					// force the FormView object to call Insert
					formView.InsertItem(true);
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
