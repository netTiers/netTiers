﻿#region Using Directives
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Web.Data;
#endregion

namespace Nettiers.AdventureWorks.Web.UI
{
	/// <summary>
	/// Provides helper methods for use in web pages and controls.
	/// </summary>
	[CLSCompliant(true)]
	public partial class FormUtilBase
	{
		private static readonly String ControlCacheKey = "ControlCache";
		
		#region Request Methods

		#endregion

		#region Response Methods

		/// <summary>
		/// Redirects a client to a new URL.
		/// </summary>
		/// <param name="url">The target location.</param>
		public static void Redirect(String url)
		{
			Redirect(url, null, null);
		}

		/// <summary>
		/// Redirects a client to a new URL.
		/// </summary>
		/// <param name="url">The target location.</param>
		/// <param name="exception">The System.Exception thrown, if any.</param>
		public static void Redirect(String url, Exception exception)
		{
			Redirect(url, null, exception);
		}

		/// <summary>
		/// Redirects a client to a new URL and provides the currently selected
		/// EntityId from the specified <see cref="ILinkedDataSource"/> object;
		/// This method only redirects if the specified exception is null.
		/// </summary>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">An <see cref="ILinkedDataSource"/> object.</param>
		/// <param name="exception">The System.Exception that was thrown, if any.</param>
		public static void Redirect(String url, ILinkedDataSource dataSource, Exception exception)
		{
			if ( exception == null )
			{
				Redirect(url, dataSource);
			}
		}

		/// <summary>
		/// Redirects a client to a new URL and provides the currently selected
		/// EntityId from the specified <see cref="ILinkedDataSource"/> object.
		/// </summary>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">An <see cref="ILinkedDataSource"/> object.</param>
		public static void Redirect(String url, ILinkedDataSource dataSource)
		{
			if ( dataSource != null )
			{
				url = String.Format(url, dataSource.GetSelectedEntityId());
			}

			// make sure second argument is false so that unhandled
			// exceptions bubble up to the application level handler
			HttpContext.Current.Response.Redirect(url, false);
		}

		#endregion

		#region Session Methods

		/// <summary>
		/// Saves a <see cref="HttpRequest"/> parameter value into the current
		/// <see cref="HttpSessionState"/> object.
		/// </summary>
		/// <param name="requestParameterName">The <see cref="HttpRequest"/> parameter name.</param>
		/// <param name="sessionParameterName">The <see cref="HttpSessionState"/> parameter name.</param>
		public static void SaveRequestParameter(String requestParameterName, String sessionParameterName)
		{
			String value = HttpContext.Current.Request[requestParameterName];

			if ( !String.IsNullOrEmpty(value) )
			{
				HttpContext.Current.Session[sessionParameterName] = value;
			}
		}

		/// <summary>
		/// Validates that the value held in the current <see cref="HttpSessionState"/> object
		/// is not null; otherwise redirects the client to a new URL.
		/// </summary>
		/// <param name="parameterName">The <see cref="HttpSessionState"/> parameter name.</param>
		/// <param name="url">The target location.</param>
		public static void ValidateSessionParam(String parameterName, String url)
		{
			Object value = HttpContext.Current.Session[parameterName];

			if ( value == null )
			{
				Redirect(url);
			}
		}

		#endregion

		#region FormView Methods

		/// <summary>
		/// Sets the data-entry mode of the specified <see cref="FormView"/> object based
		/// on whether or not the <see cref="HttpRequest"/> parameter value is null.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="requestParameterName">The <see cref="HttpRequest"/> parameter name.</param>
		public static void SetDefaultMode(FormView formView, String requestParameterName)
		{
			if ( String.IsNullOrEmpty(HttpContext.Current.Request[requestParameterName]) )
			{
				formView.DefaultMode = FormViewMode.Insert;
				HideButton(formView, "UpdateButton");
			}
			else
			{
				formView.DefaultMode = FormViewMode.Edit;
				HideButton(formView, "InsertButton");
			}
		}

		/// <summary>
		/// Sets the values to insert using the specified names and values.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="names">The property names.</param>
		/// <param name="values">The property values.</param>
		public static void SetOnInserting(FormView formView, String[] names, Object[] values)
		{
			formView.ItemInserting += new FormViewInsertEventHandler(
				delegate(object sender, FormViewInsertEventArgs e)
				{
					SetValues(e.Values, names, values);
				}
			);
		}

		/// <summary>
		/// Sets the values to update using the specified names and values.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="names">The property names.</param>
		/// <param name="values">The property values.</param>
		public static void SetOnUpdating(FormView formView, String[] names, Object[] values)
		{
			formView.ItemUpdating += new FormViewUpdateEventHandler(
				delegate(object sender, FormViewUpdateEventArgs e)
				{
					SetValues(e.NewValues, names, values);
				}
			);
		}
		
		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event of
		/// the <see cref="FormView"/> object has been raised.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsert(FormView formView, String url)
		{
			RedirectAfterInsert(formView, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event of
		/// the <see cref="FormView"/> object has been raised.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterInsert(FormView formView, String url, ILinkedDataSource dataSource)
		{
			formView.ItemInserted += new FormViewInsertedEventHandler(
				delegate(object sender, FormViewInsertedEventArgs e)
				{
					Redirect(url, dataSource, e.Exception);
				}
			);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event of
		/// the <see cref="FormView"/> object has been raised.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsert(FormView formView, GridView gridView, String url)
		{
			url = GetRedirectUrl(gridView, url);
			RedirectAfterInsert(formView, url);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemUpdated event of
		/// the <see cref="FormView"/> object has been raised.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterUpdate(FormView formView, String url)
		{
			RedirectAfterUpdate(formView, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemUpdated event of
		/// the <see cref="FormView"/> object has been raised.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterUpdate(FormView formView, String url, ILinkedDataSource dataSource)
		{
			formView.ItemUpdated += new FormViewUpdatedEventHandler(
				delegate(object sender, FormViewUpdatedEventArgs e)
				{
					Redirect(url, dataSource, e.Exception);
				}
			);
		}

		/// <summary>
        /// Redirects the client to a new URL after the ItemDeleted event of
        /// the <see cref="FormView"/> object has been raised.
        /// </summary>
        /// <param name="formView">A <see cref="FormView"/> object.</param>
        /// <param name="url">The target location.</param>
        public static void RedirectAfterDelete(FormView formView, String url)
        {
            RedirectAfterDelete(formView, url, null);
        }

        /// <summary>
        /// Redirects the client to a new URL after the ItemDeleted event of
        /// the <see cref="FormView"/> object has been raised.
        /// </summary>
        /// <param name="formView">A <see cref="FormView"/> object.</param>
        /// <param name="url">The target location.</param>
        /// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
        public static void RedirectAfterDelete(FormView formView, String url, ILinkedDataSource dataSource)
        {
            formView.ItemDeleted += new FormViewDeletedEventHandler(
                delegate(object sender, FormViewDeletedEventArgs e)
                {
                    Redirect(url, dataSource, e.Exception);
                }
            );
        }

        /// <summary>
        /// Redirects the client to a new URL after the ItemDeleted event of
        /// the <see cref="FormView"/> object has been raised.
        /// </summary>
        /// <param name="formView">A <see cref="FormView"/> object.</param>
        /// <param name="gridView">A <see cref="GridView"/> object.</param>
        /// <param name="url">The target location.</param>
        public static void RedirectAfterDelete(FormView formView, GridView gridView, String url)
        {
            url = GetRedirectUrl(gridView, url);
            RedirectAfterDelete(formView, url);
        }
		
		/// <summary>
		/// Redirects the client to a new URL after the ItemCommand event of
		/// the <see cref="FormView"/> object has been raised with a CommandName
		/// of "Cancel".
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterCancel(FormView formView, String url)
		{
			RedirectAfterCancel(formView, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemCommand event of
		/// the <see cref="FormView"/> object has been raised with a CommandName
		/// of "Cancel".
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterCancel(FormView formView, String url, ILinkedDataSource dataSource)
		{
			formView.ItemCommand += new FormViewCommandEventHandler(
				delegate(object sender, FormViewCommandEventArgs e)
				{
					// cancel button
					if ( String.Compare("Cancel", e.CommandName, true) == 0 )
					{
						Redirect(url, dataSource);
					}
				}
			);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemCommand event of
		/// the <see cref="FormView"/> object has been raised with a CommandName
		/// of "New".
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterAddNew(FormView formView, String url)
		{
			formView.ItemCommand += new FormViewCommandEventHandler(
				delegate(object sender, FormViewCommandEventArgs e)
				{
					// add button
					if ( String.Compare("New", e.CommandName, true) == 0 )
					{
						Redirect(url);
						HttpContext.Current.Response.End();
					}
				}
			);
		}

		/// <summary>
		/// Redirect the client to a new URL after an insert or cancel operation.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsertCancel(FormView formView, String url)
		{
			RedirectAfterInsertCancel(formView, url, null);
		}

		/// <summary>
		/// Redirect the client to a new URL after an insert or cancel operation.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterInsertCancel(FormView formView, String url, ILinkedDataSource dataSource)
		{
			RedirectAfterInsert(formView, url, dataSource);
			RedirectAfterCancel(formView, url, dataSource);
		}

		/// <summary>
		/// Redirect the client to a new URL after an update or cancel operation.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterUpdateCancel(FormView formView, String url)
		{
			RedirectAfterUpdateCancel(formView, url, null);
		}

		/// <summary>
		/// Redirect the client to a new URL after an update or cancel operation.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterUpdateCancel(FormView formView, String url, ILinkedDataSource dataSource)
		{
			RedirectAfterUpdate(formView, url, dataSource);
			RedirectAfterCancel(formView, url, dataSource);
		}

		/// <summary>
		/// Redirect the client to a new URL after an insert or update operation.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsertUpdate(FormView formView, String url)
		{
			RedirectAfterInsertUpdate(formView, url, null);
		}

		/// <summary>
		/// Redirect the client to a new URL after an insert or update operation.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterInsertUpdate(FormView formView, String url, ILinkedDataSource dataSource)
		{
			RedirectAfterInsert(formView, url, dataSource);
			RedirectAfterUpdate(formView, url, dataSource);
		}

		/// <summary>
		/// Redirect the client to a new URL after an insert, update, or cancel operation.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterInsertUpdateCancel(FormView formView, String url, ILinkedDataSource dataSource)
		{
			RedirectAfterInsert(formView, url, dataSource);
			RedirectAfterUpdate(formView, url, dataSource);
			RedirectAfterCancel(formView, url, dataSource);
		}
		
		/// <summary>
      /// Sets the default value of the control with the specified id parameter when
      /// the <see cref="FormView"/> is in Insert mode.
      /// </summary>
      /// <param name="formView">The form view.</param>
      /// <param name="controlID">The control ID.</param>
      /// <param name="value">The value.</param>
      public static void SetDefaultValue(FormView formView, String controlID, String value)
      {
         if (formView != null && formView.CurrentMode == FormViewMode.Insert)
         {
            Control control = formView.FindControl(controlID);

            if (control != null)
            {
               SetValue(control, value);
            }
         }
      }
      /// <summary>
      /// Binds a property's value to a <see cref="FormView" /> child control when the <see cref="FormView"/> is updating.
      /// </summary>
      /// <param name="formView">A <see cref="FormView"/> object.</param>
      /// <param name="propertyName">The name of the property to bind the value to.</param>
      /// <param name="controlId">The id of child control that contains the desired value.</param>
      public static void BindOnUpdating(FormView formView, string propertyName, string controlId)
      {
         if (formView != null)
         {
            formView.ItemUpdating += new FormViewUpdateEventHandler(
            delegate(object sender, FormViewUpdateEventArgs e)
            {
               BindControl(formView, e.NewValues, propertyName, controlId);
            }
         );
         }
      }

      /// <summary>
      /// Binds a property's value to a <see cref="FormView" /> child control when the <see cref="FormView"/> is inserting.
      /// </summary>
      /// <param name="formView">A <see cref="FormView"/> object.</param>
      /// <param name="propertyName">The name of the property to bind the value to.</param>
      /// <param name="controlId">The id of child control that contains the desired value.</param>
      public static void BindOnInserting(FormView formView, string propertyName, string controlId)
      {
         if (formView != null)
         {
            formView.ItemInserting += new FormViewInsertEventHandler(
            delegate(object sender, FormViewInsertEventArgs e)
            {
               BindControl(formView, e.Values, propertyName, controlId);
            }
         );
         }
      }

      /// <summary>
      /// Binds a property's value to a <see cref="FormView" /> child control when the <see cref="FormView"/> is inserting or updating.
      /// </summary>
      /// <param name="formView">A <see cref="FormView"/> object.</param>
      /// <param name="propertyName">The name of the property to bind the value to.</param>
      /// <param name="controlId">The id of child control that contains the desired value.</param>
      public static void BindOnInsertingUpdating(FormView formView, string propertyName, string controlId)
      {
         BindOnInserting(formView, propertyName, controlId);
         BindOnUpdating(formView, propertyName, controlId);
      }

      /// <summary>
      /// Binds a controls value to a property of an entity.
      /// </summary>
      /// <param name="formView">A <see cref="FormView"/> object.</param>
      /// <param name="list">The <see cref="IOrderedDictionary"/> containing the values.</param>
      /// <param name="propertyName">The name of the property to bind the value to.</param>
      /// <param name="controlId">The id of the control to get the value from.</param>
      public static void BindControl(FormView formView, IOrderedDictionary list, string propertyName, string controlId)
      {
         if (formView != null)
         {
            Control control = formView.FindControl(controlId);
            BindControl(control, list, propertyName);
         }
      }
		
		#endregion

		#region DetailsView Methods

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event
		/// of the <see cref="DetailsView"/> object has been raised.
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsert(DetailsView view, String url)
		{
			RedirectAfterInsert(view, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event
		/// of the <see cref="DetailsView"/> object has been raised.
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterInsert(DetailsView view, String url, ILinkedDataSource dataSource)
		{
			view.ItemInserted += new DetailsViewInsertedEventHandler(
				delegate(object sender, DetailsViewInsertedEventArgs e)
				{
					Redirect(url, dataSource, e.Exception);
				}
			);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event
		/// of the <see cref="DetailsView"/> object has been raised.
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="grid">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsert(DetailsView view, GridView grid, String url)
		{
			url = GetRedirectUrl(grid, url);
			RedirectAfterInsert(view, url);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event of the <see cref="DetailsView"/>
		/// has been raised or after the ItemCommand event of the <see cref="DetailsView"/> object has
		/// been raised with a CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="grid">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsertCancel(DetailsView view, GridView grid, String url)
		{
			url = GetRedirectUrl(grid, url);
			RedirectAfterInsertCancel(view, url);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemUpdated event
		/// of the <see cref="DetailsView"/> object has been raised.
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterUpdate(DetailsView view, String url)
		{
			RedirectAfterUpdate(view, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemUpdated event
		/// of the <see cref="DetailsView"/> object has been raised.
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterUpdate(DetailsView view, String url, ILinkedDataSource dataSource)
		{
			view.ItemUpdated += new DetailsViewUpdatedEventHandler(
				delegate(object sender, DetailsViewUpdatedEventArgs e)
				{
					Redirect(url, dataSource, e.Exception);
				}
			);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemUpdated event
		/// of the <see cref="DetailsView"/> object has been raised.
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="grid">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterUpdate(DetailsView view, GridView grid, String url)
		{
			url = GetRedirectUrl(grid, url);
			RedirectAfterUpdate(view, url);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemUpdated event of the <see cref="DetailsView"/>
		/// has been raised or after the ItemCommand event of the <see cref="DetailsView"/> object has
		/// been raised with a CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="grid">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterUpdateCancel(DetailsView view, GridView grid, String url)
		{
			url = GetRedirectUrl(grid, url);
			RedirectAfterUpdateCancel(view, url);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemCommand event
		/// of the <see cref="DetailsView"/> object has been raised with a
		/// CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterCancel(DetailsView view, String url)
		{
			RedirectAfterCancel(view, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemCommand event
		/// of the <see cref="DetailsView"/> object has been raised with a
		/// CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterCancel(DetailsView view, String url, ILinkedDataSource dataSource)
		{
			view.ItemCommand += new DetailsViewCommandEventHandler(
				delegate(object sender, DetailsViewCommandEventArgs e)
				{
					// cancel button
					if ( String.Compare("Cancel", e.CommandName, true) == 0 )
					{
						Redirect(url, dataSource);
					}
				}
			);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event of the <see cref="DetailsView"/>
		/// has been raised or after the ItemCommand event of the <see cref="DetailsView"/> object has
		/// been raised with a CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsertCancel(DetailsView view, String url)
		{
			RedirectAfterInsertCancel(view, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted event of the <see cref="DetailsView"/>
		/// has been raised or after the ItemCommand event of the <see cref="DetailsView"/> object has
		/// been raised with a CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterInsertCancel(DetailsView view, String url, ILinkedDataSource dataSource)
		{
			RedirectAfterInsert(view, url, dataSource);
			RedirectAfterCancel(view, url, dataSource);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemUpdated event of the <see cref="DetailsView"/>
		/// has been raised or after the ItemCommand event of the <see cref="DetailsView"/> object has
		/// been raised with a CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterUpdateCancel(DetailsView view, String url)
		{
			RedirectAfterUpdateCancel(view, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemUpdated event of the <see cref="DetailsView"/>
		/// has been raised or after the ItemCommand event of the <see cref="DetailsView"/> object has
		/// been raised with a CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterUpdateCancel(DetailsView view, String url, ILinkedDataSource dataSource)
		{
			RedirectAfterUpdate(view, url, dataSource);
			RedirectAfterCancel(view, url, dataSource);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted or ItemUpdated event of the <see cref="DetailsView"/>
		/// has been raised or after the ItemCommand event of the <see cref="DetailsView"/> object has
		/// been raised with a CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterInsertUpdateCancel(DetailsView view, String url)
		{
			RedirectAfterInsertUpdateCancel(view, url, null);
		}

		/// <summary>
		/// Redirects the client to a new URL after the ItemInserted or ItemUpdated event of the <see cref="DetailsView"/>
		/// has been raised or after the ItemCommand event of the <see cref="DetailsView"/> object has
		/// been raised with a CommandName of "Cancel".
		/// </summary>
		/// <param name="view">A <see cref="DetailsView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		public static void RedirectAfterInsertUpdateCancel(DetailsView view, String url, ILinkedDataSource dataSource)
		{
			RedirectAfterInsert(view, url, dataSource);
			RedirectAfterUpdate(view, url, dataSource);
			RedirectAfterCancel(view, url, dataSource);
		}

		#endregion

		#region GridView Methods

		/// <summary>
		/// Sets the index of the currently displayed page.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="parameterName">The <see cref="HttpRequest"/> parameter name.</param>
		public static void SetPageIndex(GridView gridView, String parameterName)
		{
			if ( !gridView.Page.IsPostBack && !gridView.Page.IsCallback && !String.IsNullOrEmpty(parameterName) )
			{
				String page = HttpContext.Current.Request[parameterName];

				if ( !String.IsNullOrEmpty(page) )
				{
					int index = 0;

					if ( Int32.TryParse(page, out index) )
					{
						gridView.PageIndex = index;
					}
				}
			}
		}

		/// <summary>
		/// Sets the index of the selected row.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="parameterName">The <see cref="HttpRequest"/> parameter name.</param>
		public static void SetSelectedIndex(GridView gridView, String parameterName)
		{
			if ( !gridView.Page.IsPostBack && !gridView.Page.IsCallback && !String.IsNullOrEmpty(parameterName) )
			{
				String value = HttpContext.Current.Request[parameterName];

				if ( !String.IsNullOrEmpty(value) )
				{
					int index = -1;
					Int32.TryParse(value, out index);
					gridView.SelectedIndex = Math.Max(index, -1);
				}
			}
		}

		/// <summary>
		/// Sorts the <see cref="GridView"/> control based on the specified sort expression and direction.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="sortParameterName">The <see cref="HttpRequest"/> parameter name for the sort expression.</param>
		/// <param name="dirParameterName">The <see cref="HttpRequest"/> parameter name for the sort direction.</param>
		public static void SetSortExpression(GridView gridView, String sortParameterName, String dirParameterName)
		{
			if ( !gridView.Page.IsPostBack && !gridView.Page.IsCallback && !String.IsNullOrEmpty(sortParameterName) )
			{
				String sort = HttpContext.Current.Request[sortParameterName];

				if ( !String.IsNullOrEmpty(sort) )
				{
					SortDirection dir = SortDirection.Ascending;

					if ( !String.IsNullOrEmpty(dirParameterName) )
					{
						String sortDir = HttpContext.Current.Request[dirParameterName];

						if ( !String.IsNullOrEmpty(sortDir) )
						{
							dir = (SortDirection) Enum.Parse(typeof(SortDirection), sortDir);
						}
					}

					gridView.Sort(sort, dir);
				}
			}
		}

		/// <summary>
		/// Sets the page index, selected index, and sort expression for the specified <see cref="GridView"/> object.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="pageParam">The <see cref="HttpRequest"/> parameter name for the page index.</param>
		/// <param name="sortParam">The <see cref="HttpRequest"/> parameter name for the sort expression.</param>
		/// <param name="dirParam">The <see cref="HttpRequest"/> parameter name for the sort direction.</param>
		public static void SetGridParams(GridView gridView, String pageParam, String sortParam, String dirParam)
		{
			SetGridParams(gridView, pageParam, sortParam, dirParam, "index");
		}

		/// <summary>
		/// Sets the page index, selected index, and sort expression for the specified <see cref="GridView"/> object.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="pageParam">The <see cref="HttpRequest"/> parameter name for the page index.</param>
		/// <param name="sortParam">The <see cref="HttpRequest"/> parameter name for the sort expression.</param>
		/// <param name="dirParam">The <see cref="HttpRequest"/> parameter name for the sort direction.</param>
		/// <param name="indexParam">The <see cref="HttpRequest"/> parameter name for the selected index.</param>
		public static void SetGridParams(GridView gridView, String pageParam, String sortParam, String dirParam, String indexParam)
		{
			SetPageIndex(gridView, pageParam);
			SetSortExpression(gridView, sortParam, dirParam);
			SetSelectedIndex(gridView, indexParam);
		}

		/// <summary>
		/// Sets the page index, selected index, and sort expression for the specified <see cref="GridView"/> object.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		public static void SetGridParams(GridView gridView)
		{
			SetGridParams(gridView, "page", "sort", "dir", "index");
		}

		/// <summary>
		/// Gets the current page url with query parameters and values indicating
		/// the current state of the <see cref="GridView"/> object.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <returns></returns>
		public static String GetRedirectUrl(GridView gridView)
		{
			String url = HttpContext.Current.Request.Url.AbsolutePath + "?page={0}&sort={1}&dir={2}&index={3}";
			return GetRedirectUrl(gridView, url);
		}

		/// <summary>
		/// Formats the specified url with query parameters and values indicating
		/// the current state of the <see cref="GridView"/> object.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="url">The url value to format.</param>
		/// <returns>A formatted url.</returns>
		public static String GetRedirectUrl(GridView gridView, String url)
		{
			String sort = HttpContext.Current.Server.UrlEncode(gridView.SortExpression);
			int dir = (int) gridView.SortDirection;
			return String.Format(url, gridView.PageIndex, sort, dir, gridView.SelectedIndex);
		}

		/// <summary>
		/// Redirects a client to a new URL which contains query parameters and
		/// values indicating the current state of the <see cref="GridView"/> object.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void Redirect(GridView gridView, String url)
		{
			Redirect(gridView, url, null);
		}

		/// <summary>
		/// Redirects a client to a new URL which contains query parameters and
		/// values indicating the current state of the <see cref="GridView"/> object.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		/// <param name="exception">The System.Exception thrown, if any.</param>
		public static void Redirect(GridView gridView, String url, Exception exception)
		{
			url = GetRedirectUrl(gridView, url);
			Redirect(url, exception);
		}

		/// <summary>
		/// Redirects a client to a new URL which contains query parameters and
		/// values indicating the current state of the <see cref="GridView"/> object
		/// after the RowUpdated event has been raised.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterUpdate(GridView gridView, String url)
		{
			gridView.RowUpdated += new GridViewUpdatedEventHandler(
				delegate(object sender, GridViewUpdatedEventArgs e)
				{
					Redirect(gridView, url, e.Exception);
				}
			);
		}

		/// <summary>
		/// Redirects a client to a new URL which contains query parameters and
		/// values indicating the current state of the <see cref="GridView"/> object
		/// after the RowDeleted event has been raised.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterDelete(GridView gridView, String url)
		{
			gridView.RowDeleted += new GridViewDeletedEventHandler(
				delegate(object sender, GridViewDeletedEventArgs e)
				{
					Redirect(gridView, url, e.Exception);
				}
			);
		}

		/// <summary>
		/// Redirects a client to a new URL which contains query parameters and
		/// values indicating the current state of the <see cref="GridView"/> object
		/// after the RowCancelingEdit event has been raised.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterCancel(GridView gridView, String url)
		{
			gridView.RowCancelingEdit += new GridViewCancelEditEventHandler(
				delegate(object sender, GridViewCancelEditEventArgs e)
				{
					Redirect(gridView, url);
				}
			);
		}

		/// <summary>
		/// Redirects a client to a new URL which contains query parameters and
		/// values indicating the current state of the <see cref="GridView"/> object
		/// after the RowUpdated, RowDeleted, or RowCancelingEdit events have been raised.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="url">The target location.</param>
		public static void RedirectAfterUpdateDeleteCancel(GridView gridView, String url)
		{
			RedirectAfterUpdate(gridView, url);
			RedirectAfterDelete(gridView, url);
			RedirectAfterCancel(gridView, url);
		}

		/// <summary>
		/// Sets the value of the client-side onclick event handler property.
		/// </summary>
		/// <param name="gridView">A <see cref="GridView"/> object.</param>
		/// <param name="cellIndex">The zero-based column index.</param>
		/// <param name="buttonText">The <see cref="Button"/> control's Text property value.</param>
		/// <param name="script">The client-side event handler script.</param>
		public static void SetOnClientClick(GridView gridView, int cellIndex, String buttonText, String script)
		{
			gridView.RowCreated += new GridViewRowEventHandler(
				delegate(object sender, GridViewRowEventArgs e)
				{
					if ( cellIndex < e.Row.Cells.Count )
					{
						TableCell cell = e.Row.Cells[cellIndex] as DataControlFieldCell;
						Button button;

						if ( cell != null )
						{
							foreach ( Control control in cell.Controls )
							{
								button = control as Button;

								if ( button != null && String.Compare(button.Text, buttonText, true) == 0 )
								{
									button.Attributes.Add("onclick", script);
								}
							}
						}
					}
				}
			);
		}

		#endregion

		#region Control Methods
		
		/// <summary>
      /// Binds a controls value to a property of an entity.
      /// </summary>
      /// <param name="control">The control to get the value from.</param>
      /// <param name="list">The <see cref="IOrderedDictionary"/> containing the values.</param>
      /// <param name="propertyName">The name of the property to bind the value to.</param>
      public static void BindControl(Control control, IOrderedDictionary list, String propertyName)
      {
         if (control != null)
         {
            if (list.Contains(propertyName))
            {
               list.Remove(propertyName);
            }

            list.Add(propertyName, GetValue(control));
         }
      }

		/// <summary>
		/// Loads an instance of an IBindableTemplate from the specified path.
		/// </summary>
		/// <param name="control">The TemplateControl which will perform the load.</param>
		/// <param name="path">The path to the template to load.</param>
		/// <returns>An instance of IBindableTemplate found at the specified path.</returns>
		/// <remarks>
		/// Adapted from an article written by James Crowley, which can be found at:
		/// http://www.developerfusion.co.uk/show/4721/
		/// </remarks>
		public static IBindableTemplate LoadBindableTemplate(TemplateControl control, String path)
		{
			Control container = control.LoadControl(path);
			FormView formView = container.Controls[0] as FormView;

			if ( formView == null )
			{
				throw new Exception("Required FormView control not found as the first child of specified template");
			}

			return (IBindableTemplate) formView.ItemTemplate;
		}

		/// <summary>
		/// Initializes a password <see cref="TextBox"/> control with the current value.
		/// </summary>
		/// <param name="formView">A <see cref="FormView"/> object.</param>
		/// <param name="controlId">The control's ID property value.</param>
		/// <param name="dataSource">The associated <see cref="ILinkedDataSource"/> object.</param>
		/// <param name="propertyName">The property name that the <see cref="TextBox"/> is bound to.</param>
		public static void InitPassword(FormView formView, String controlId, ILinkedDataSource dataSource, String propertyName)
		{
			if ( formView != null && !formView.Page.IsPostBack && dataSource != null &&
				!String.IsNullOrEmpty(controlId) && !String.IsNullOrEmpty(propertyName) )
			{
				TextBox input = formView.FindControl(controlId) as TextBox;
				if ( input != null )
				{
					Object entity = dataSource.GetCurrentEntity();
					if ( entity != null )
					{
						String password = EntityUtil.GetPropertyValue(entity, propertyName) as String;
						InitPassword(input, password);
					}
				}
			}
		}

		/// <summary>
		/// Initializes a password <see cref="TextBox"/> control with the current value.
		/// </summary>
		/// <param name="control">A <see cref="TextBox"/> control.</param>
		/// <param name="password">The current password value.</param>
		public static void InitPassword(TextBox control, String password)
		{
			if ( control != null && control.TextMode == TextBoxMode.Password && !control.Page.IsPostBack )
			{
				control.Attributes.Add("value", password);
			}
		}

		/// <summary>
		/// Hides the <see cref="Button"/> control with the specified ID.
		/// </summary>
		/// <param name="parent">The <see cref="Button"/> control's parent control or NamingContainer.</param>
		/// <param name="buttonId">The <see cref="Button"/> control's ID property value.</param>
		public static void HideButton(Control parent, String buttonId)
		{
			if ( parent != null && !String.IsNullOrEmpty(buttonId) )
			{
				Control btn = parent.FindControl(buttonId) as Control;
				if ( btn != null )
				{
					btn.Visible = false;
				}
			}
		}

		/// <summary>
		/// Adds elements to the collection having the specified names and values.
		/// </summary>
		/// <param name="list">A collection of name/value pairs.</param>
		/// <param name="names">The property names.</param>
		/// <param name="values">The property values.</param>
		public static void SetValues(IOrderedDictionary list, String[] names, Object[] values)
		{
			for ( int i = 0; i < names.Length; i++ )
			{
				if ( list.Contains(names[i]) )
				{
					list.Remove(names[i]);
				}

				list.Add(names[i], values[i]);
			}
		}

		/// <summary>
		/// Searches the specified control for a server control with the
		/// specified id parameter values.
		/// </summary>
		/// <param name="control">The <see cref="Control"/> at which to begin the search.</param>
		/// <param name="controlIds">The heirarchy of id parameter values.</param>
		/// <returns>A <see cref="Control"/> object if found; otherwise null.</returns>
		public static Control FindControl(Control control, params String[] controlIds)
		{
			if ( control != null )
			{
				foreach ( String controlId in controlIds )
				{
					control = control.FindControl(controlId);

					if ( control == null )
					{
						break;
					}
				}
			}

			return control;
		}

		/// <summary>
		/// Searches the specified control for a server control with the specified id parameter.
		/// </summary>
		/// <param name="control">The <see cref="Control"/> at which to begin the search.</param>
		/// <param name="controlId">The id parameter value.</param>
		/// <returns>A collection of <see cref="Control"/> objects.</returns>
		public static IList<Control> FindControls(Control control, String controlId)
		{
			IList<Control> controls = new List<Control>();

			if ( control != null )
			{
				if ( control.ID == controlId )
				{
					controls.Add(control);
				}

				IList<Control> list;

				foreach ( Control ctrl in control.Controls )
				{
					list = FindControls(ctrl, controlId);

					foreach ( Control c in list )
					{
						controls.Add(c);
					}
				}
			}

			return controls;
		}

		/// <summary>
		/// Gets a collection of controls that acts as a cache for <see cref="Control"/> object
		/// collections returned by the GetControls method.
		/// </summary>
		/// <param name="page">The current System.Web.UI.Page object.</param>
		/// <returns>A collection of cached controls.</returns>
		public static IDictionary<String, IList<Control>> GetControlCache(System.Web.UI.Page page)
		{
			if ( !page.Items.Contains(ControlCacheKey) )
			{
				page.Items.Add(ControlCacheKey, new Dictionary<String, IList<Control>>());
			}

			return page.Items[ControlCacheKey] as IDictionary<String, IList<Control>>;
		}

		/// <summary>
		/// Gets a collection of controls contained within the specified System.Web.UI.Page
		/// object that have the specified ID property value.
		/// </summary>
		/// <param name="page">The current System.Web.UI.Page object.</param>
		/// <param name="controlId">The control's ID property value.</param>
		/// <returns>A collection of <see cref="Control"/> objects.</returns>
		public static IList<Control> GetControls(System.Web.UI.Page page, String controlId)
		{
			IDictionary<String, IList<Control>> cache = GetControlCache(page);

			if ( !cache.ContainsKey(controlId) )
			{
				IList<Control> controls = FindControls(page, controlId);

				if ( !cache.ContainsKey(controlId) )
				{
					cache.Add(controlId, controls);
				}
			}

			return cache[controlId];
		}

		/// <summary>
		/// Gets the value of the ClientID property.
		/// </summary>
		/// <param name="container">The control's parent control or NamingContainer.</param>
		/// <param name="controlId">The control's ID property value.</param>
		/// <param name="propertyName">The property name.</param>
		/// <returns>The value of the ClientID property.</returns>
		public static String GetClientID(Control container, String controlId, String propertyName)
		{
			IList<Control> controls = GetControls(container.Page, controlId);
			int index = Math.Max((int) DataBinder.Eval(container, propertyName), 0);
			String clientId = String.Empty;

			if ( controls.Count > index )
			{
				clientId = controls[index].ClientID;
			}

			return clientId;
		}

		/// <summary>
		/// Gets the value of the default property.
		/// </summary>
		/// <param name="control">A <see cref="Control"/> object.</param>
		/// <returns>The property value.</returns>
		public static Object GetValue(Control control)
		{
			return GetValue(control, null);
		}

		/// <summary>
		/// Gets the value of the property with the specified name.
		/// </summary>
		/// <param name="control">A <see cref="Control"/> object.</param>
		/// <param name="propertyName">The property name.</param>
		/// <returns>The property value.</returns>
		public static Object GetValue(Control control, String propertyName)
		{
			if ( control == null )
			{
				return null;
			}
			if ( String.IsNullOrEmpty(propertyName) )
			{
				propertyName = GetDefaultPropertyName(control);
			}

			Object value = null;

			if ( control is CheckBox )
			{
				value = ( control as CheckBox ).Checked ? 1 : 0;
			}
			else if ( control is ListControl )
			{
				CommaDelimitedStringCollection values = new CommaDelimitedStringCollection();
				ListControl list = control as ListControl;
				
				ListItem firstItem = null;
				foreach ( ListItem item in list.Items )
				{
					if ( item.Selected )
					{
						values.Add(item.Value);
					}
					
					if (firstItem == null)
               {
                  firstItem = item;
               }
				}
				
            if (firstItem != null && list is DropDownList && values.Count == 0)
            {
               //DropDownList must have one item selected
               values.Add(firstItem.Value);
            }

				value = values.ToString();
			}
			else
			{
				value = EntityUtil.GetPropertyValue(control, propertyName);
			}

			return value;
		}

		/// <summary>
		/// Sets the value of the default property.
		/// </summary>
		/// <param name="control">A <see cref="Control"/> object.</param>
		/// <param name="value">The property value.</param>
		public static void SetValue(Control control, Object value)
		{
			SetValue(control, null, value);
		}

		/// <summary>
		/// Sets the value of the property with the specified name.
		/// </summary>
		/// <param name="control">A <see cref="Control"/> object.</param>
		/// <param name="propertyName">The property name.</param>
		/// <param name="value">The property value.</param>
		public static void SetValue(Control control, String propertyName, Object value)
		{
			if ( control is CheckBox )
			{
				CheckBox chkBox = control as CheckBox;
				//String strValue = ( value != null ) ? value.ToString() : String.Empty;
				//chkBox.Checked = strValue.Equals(chkBox.Text);
				chkBox.Checked = Convert.ToBoolean(value);
			}
			else
			{
				if ( String.IsNullOrEmpty(propertyName) )
				{
					propertyName = GetDefaultPropertyName(control);
				}

				EntityUtil.SetPropertyValue(control, propertyName, value);
			}
		}

		/// <summary>
		/// Gets the name of the default property, if defined.
		/// </summary>
		/// <param name="o">An object instance.</param>
		/// <returns>The property name.</returns>
		public static String GetDefaultPropertyName(Object o)
		{
			Type type = null;

			if ( o != null )
			{
				type = o.GetType();
			}

			return GetDefaultPropertyName(type);
		}

		/// <summary>
		/// Gets the name of the default property, if defined.
		/// </summary>
		/// <param name="type">A System.Type to query for the name of the default property.</param>
		/// <returns>The property name.</returns>
		public static String GetDefaultPropertyName(Type type)
		{
			String name = null;

			if ( type != null )
			{
				Type attribType = typeof(ControlValuePropertyAttribute);
				ControlValuePropertyAttribute attrib = (ControlValuePropertyAttribute) Attribute.GetCustomAttribute(type, attribType);

				if ( attrib != null )
				{
					name = attrib.Name;
				}
			}

			return name;
		}

		/// <summary>
		/// Gets a value indicating whether the specified control contains a value
		/// which is neither null nor empty.
		/// </summary>
		/// <param name="control">A <see cref="Control"/> object.</param>
		/// <returns>True if the <see cref="Control"/> contains a value; otherwise false.</returns>
		public static bool HasValue(Control control)
		{
			String value = String.Format("{0}", GetValue(control));
			return ( control != null && !String.IsNullOrEmpty(value) );
		}

		/// <summary>
		/// Gets a value indicating whether the specified control contains a value
		/// which is neither null nor empty.
		/// </summary>
		/// <param name="parent">The <see cref="Control"/>'s parent control or NamingContainer.</param>
		/// <param name="controlId">The <see cref="Control"/>'s ID property value.</param>
		/// <returns></returns>
		public static bool HasValue(Control parent, String controlId)
		{
			bool hasValue = false;

			if ( parent != null && !String.IsNullOrEmpty(controlId) )
			{
				Control control = parent.FindControl(controlId);
				hasValue = HasValue(control);
			}

			return hasValue;
		}

		/// <summary>
		/// Sets the default focus.
		/// </summary>
		/// <param name="control">The control.</param>
		public static void SetDefaultFocus(System.Web.UI.Control control)
		{
			if ( control != null )
			{
				control.Page.Form.DefaultFocus = control.ClientID;
			}
		}
		
		/// <summary>
		/// Sets the default button.
		/// </summary>
		/// <param name="button">The button.</param>
		public static void SetDefaultButton(System.Web.UI.WebControls.Button button)
		{
			if ( button != null )
			{
				button.Page.Form.DefaultButton = button.UniqueID;
			}
		}
		
		/// <summary>
		/// Sets the default button and focus.
		/// </summary>
		/// <param name="button">The button.</param>
		/// <param name="control">The control.</param>
		public static void SetDefaultButtonAndFocus(System.Web.UI.WebControls.Button button, System.Web.UI.Control control)
		{
			SetDefaultButton(button);
			SetDefaultFocus(control);
		}

		#endregion
		
        #region Handles the GridViewSearchPanel State
        /// <summary>
        /// Handles the state of the GridViewSearchPanel
        /// </summary>
        /// <param name="searchPanel">The search panel.</param>
        public static void HandleGridViewSearchPanelState( GridViewSearchPanel searchPanel )
        {
			HandleGridViewSearchPanelState( searchPanel, PersistenceMethod.Session );
		}
		
		/// <summary>
        /// Handles the state of the GridViewSearchPanel
        /// </summary>
        /// <param name="searchPanel">The search panel.</param>
        /// <param name="persistentCookieExpiryDateTime">The date and time the persistent cookie expires.</param>
        public static void HandleGridViewSearchPanelState( GridViewSearchPanel searchPanel, DateTime persistentCookieExpiryDateTime )
        {
			HandleGridViewSearchPanelState( searchPanel, null, PersistenceMethod.PersistentCookie, persistentCookieExpiryDateTime );
		}
		
		/// <summary>
        /// Handles the state of the GridViewSearchPanel
        /// </summary>
        /// <param name="searchPanel">The search panel.</param>
        /// <param name="persistenceMethod">The persistence method.</param>
        public static void HandleGridViewSearchPanelState( GridViewSearchPanel searchPanel, PersistenceMethod persistenceMethod )
        {
			HandleGridViewSearchPanelState( searchPanel, null, persistenceMethod, null );
		}
		
        /// <summary>
        /// Handles the state of the GridViewSearchPanel
        /// </summary>
        /// <param name="searchPanel">The search panel.</param>
        /// <param name="gridView">The grid view.</param>
        /// <param name="persistenceMethod">The persistence method</param>
        /// <param name="persistentCookieExpiryDateTime">The date and time the persistent cookie expires</param>
        public static void HandleGridViewSearchPanelState( GridViewSearchPanel searchPanel, GridView gridView, 
															PersistenceMethod persistenceMethod, DateTime? persistentCookieExpiryDateTime )
        {
			if ( gridView == null )
			{
				// try and find the GridView control if it hasn't been explicitly supplied
	            gridView = FindControl( searchPanel.NamingContainer, searchPanel.GridViewControlID ) as GridView;
			}
			
            if ( gridView != null )
            {
                // restore any previously saved state
                gridView.Page.Load += new EventHandler(
                    delegate( object sender, EventArgs e )
                    {
                        if ( !gridView.Page.IsPostBack )
                        {
                            GridViewSearchPanelState controlState = GetGridViewSearchPanelState( GetUniqueGridViewName( gridView ), persistenceMethod );
                            if ( controlState != null )
                            {
                                controlState.RestoreState( ref gridView, ref searchPanel );                                
                            }
                        }
                    }
                );

                // save state on row command, and rebind searchPanel
                gridView.RowCommand += new GridViewCommandEventHandler(
                    delegate(object sender, GridViewCommandEventArgs e)
                    {
                        GridViewSearchPanelState controlState = new GridViewSearchPanelState(gridView, searchPanel);
                        SaveGridViewSearchPanelState(controlState, GetUniqueGridViewName(gridView),
                                                        persistenceMethod, persistentCookieExpiryDateTime);
                        searchPanel.DataBind();
                    }    
                );

                // save state when page index changes
                gridView.PageIndexChanged += new EventHandler(
                    delegate( object sender, EventArgs e )
                    {
                        GridViewSearchPanelState controlState = new GridViewSearchPanelState( gridView, searchPanel );
                        SaveGridViewSearchPanelState( controlState, GetUniqueGridViewName( gridView ), 
														persistenceMethod, persistentCookieExpiryDateTime );
                    }
                );

                // save state when grid is sorted
                gridView.Sorted += new EventHandler(
                    delegate( object sender, EventArgs e )
                    {
                        GridViewSearchPanelState controlState = new GridViewSearchPanelState( gridView, searchPanel );
                        SaveGridViewSearchPanelState( controlState, GetUniqueGridViewName( gridView ), 
														persistenceMethod, persistentCookieExpiryDateTime );
                        
                    }
                );

                if (gridView is EntityGridView)
                {
                    // save state when grid's page size changed
                    ((EntityGridView)gridView).PageSizeChanged += new EventHandler(
                        delegate(object sender, EventArgs e)
                        {
                            GridViewSearchPanelState controlState = new GridViewSearchPanelState(gridView, searchPanel);
                            SaveGridViewSearchPanelState(controlState, GetUniqueGridViewName(gridView),
                                                            persistenceMethod, persistentCookieExpiryDateTime);
                        }
                    );
                }
                // save state when search id done
                searchPanel.SearchButtonClicked += new EventHandler(
                    delegate( object sender, EventArgs e )
                    {
                        GridViewSearchPanelState controlState = new GridViewSearchPanelState( gridView, searchPanel );
                        SaveGridViewSearchPanelState( controlState, GetUniqueGridViewName( gridView ), 
														persistenceMethod, persistentCookieExpiryDateTime );
                    }
                );

                // save state when reset is done
                searchPanel.ResetButtonClicked += new EventHandler(
                    delegate( object sender, EventArgs e )
                    {
                        GridViewSearchPanelState controlState = new GridViewSearchPanelState( gridView, searchPanel );
                        SaveGridViewSearchPanelState(controlState, GetUniqueGridViewName(gridView),
                                persistenceMethod, persistentCookieExpiryDateTime);
                    }
                );
            }
        }

        /// <summary>
        /// Gets the unique name of the grid view.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <returns></returns>
        private static string GetUniqueGridViewName( GridView gridView )
        {
            return gridView.Page.Request.Url.AbsoluteUri + gridView.UniqueID;
        }

        /// <summary>
        /// Saves the GridViewSearchPanel State.
        /// </summary>
        /// <param name="controlState">State of the control.</param>
        /// <param name="controlStateName">Name of the control state.</param>
        /// <param name="persistenceMethod">The persistent method.</param>
        /// <param name="persistentCookieExpiryDateTime">The persistent cookie expiry datetime.</param>
        public static void SaveGridViewSearchPanelState( GridViewSearchPanelState controlState, string controlStateName, 
															PersistenceMethod persistenceMethod, DateTime? persistentCookieExpiryDateTime )
        {
			switch ( persistenceMethod )
			{
				case PersistenceMethod.Session :
					#region Uses Session state
					HttpContext.Current.Session[ controlStateName ] = controlState;
					#endregion
					break;
				case PersistenceMethod.Cookie :
				case PersistenceMethod.PersistentCookie :
					#region Uses a client cookie
		            string serializedString = SerializeGridViewSearchPanelState( controlState );
			        HttpCookie cookie = new HttpCookie( controlStateName, HttpContext.Current.Server.UrlEncode( serializedString ) );
			        // Determine if this should be persisted longer than just the current session
			        if ( persistentCookieExpiryDateTime != null )
			        {
						cookie.Expires = persistentCookieExpiryDateTime.Value;
			        }
					HttpContext.Current.Response.Cookies.Add( cookie );

					#endregion
					break;
			}
        }

        /// <summary>
        /// Gets the GridViewSearchPanel State from the cookie
        /// </summary>
        /// <param name="controlStateName">Name of the control state.</param>
        /// <param name="persistenceMethod">The persistent method.</param>
        /// <returns></returns>
        public static GridViewSearchPanelState GetGridViewSearchPanelState( string controlStateName, PersistenceMethod persistenceMethod )
        {
			GridViewSearchPanelState controlState = null;
			
			switch ( persistenceMethod )
			{
				case PersistenceMethod.Session :
					#region Uses Session state
					if ( HttpContext.Current.Session[ controlStateName ] != null )
					{ 
						controlState = HttpContext.Current.Session[ controlStateName ] as GridViewSearchPanelState;
					}
					#endregion
					break;
					
				case PersistenceMethod.Cookie :
				case PersistenceMethod.PersistentCookie :
					#region Uses a client session cookie
					HttpCookie cookie = HttpContext.Current.Request.Cookies[ controlStateName ];

					if ( cookie != null )
					{
						controlState = DeserializeGridViewSearchPanelState( HttpContext.Current.Server.UrlDecode( cookie.Value ) );
					}
					#endregion

					break;
			}
			
            return controlState;
        }
        
		/// <summary>
        /// Serializes the grid view search panel state.
        /// </summary>
        /// <param name="controlState">The control state.</param>
        /// <returns></returns>
        private static string SerializeGridViewSearchPanelState( GridViewSearchPanelState controlState)
        {
            string serializedString = string.Empty;

            using ( StringWriter stringWriter = new StringWriter() )
            {
                XmlSerializer serializer = new XmlSerializer( typeof( GridViewSearchPanelState ) );
                serializer.Serialize( stringWriter, controlState );
                serializedString = stringWriter.ToString();
            }

            return serializedString;
        }

        /// <summary>
        /// Deserializes the grid view search panel state.
        /// </summary>
        /// <param name="serializedString">The serialized string.</param>
        /// <returns></returns>
        private static GridViewSearchPanelState DeserializeGridViewSearchPanelState( string serializedString )
        {
            GridViewSearchPanelState controlState = null;
            XmlSerializer serializer = new XmlSerializer( typeof( GridViewSearchPanelState ) );
            controlState = (GridViewSearchPanelState)serializer.Deserialize( new StringReader( serializedString ) );

            return controlState;
        }
        
        #endregion

	}
	
	#region Enums
	/// <summary>
	/// used to determine the persistence method
	/// </summary>
	public enum PersistenceMethod
	{
        /// <summary>
        /// no persistents
        /// </summary>
        None = 0,
		/// session state will be used
		Session = 1,
		/// client cookie will be used
		Cookie = 2,
		/// a persistent client cookie will be used
		PersistentCookie = 3,
	}
	#endregion
}