﻿#region Using directives

using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.ComponentModel;
using Nettiers.AdventureWorks;
#endregion

namespace Nettiers.AdventureWorks.Web.UI
{
    /// <summary>
    /// A specialised Drop Down List that adds extra functionality to the base class.
    /// Features include the ability to add a null item, make the control readonly,
    /// make the control required and it supports type ahead
    /// </summary>
    public class EntityDropDownList : DropDownList
    {
        #region Fields
        private RequiredFieldValidator requiredValidator;
        private ListItem nullItem;
        private static string functionName = "KeySortDropDownList_onkeypress";
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this control uses case sensitive key sort.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if case sensitive key sort; otherwise, <c>false</c>.
        /// </value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "false" ), Description( "Indicates if key sort is case sensitive" )]
        public bool CaseSensitiveKeySort
        {
          get 
          {
              if ( ViewState[ "CaseSensitiveKeySort" ] == null )
              {
                  ViewState.Add( "CaseSensitiveKeySort", false );
              }
              return (bool)ViewState[ "CaseSensitiveKeySort" ];
          }
          set { ViewState[ "CaseSensitiveKeySort" ] = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether client script is enabled.
        /// </summary>
        /// <value><c>true</c> if client script enabled; otherwise, <c>false</c>.</value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "true" ), Description( "Indicates if client script is enabled" )]
        public bool EnableClientScript
        {
            get
            {
                if ( ViewState[ "EnableClientScript" ] == null )
                {
                    ViewState.Add( "EnableClientScript", true );
                }
                return (bool)ViewState[ "EnableClientScript" ];
            }
            set { ViewState[ "EnableClientScript" ] = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control is read only.
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "false" ), Description( "Indicates if the control is read only" )]
        public bool ReadOnly
        {
            get
            {
                if ( ViewState[ "ReadOnly" ] == null )
                {
                    ViewState.Add( "ReadOnly", false );
                }
                return (bool)ViewState[ "ReadOnly" ];
            }
            set { ViewState[ "ReadOnly" ] = value; }
        }

		/// <summary>
      	/// Gets or sets the friendly name.
      	/// <remarks>Defaults to ""</remarks>
      	/// </summary>
      	/// <value>The friendly name.</value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "" ), Description( "Friendly name used in messages" )]
        public string FriendlyName
        {
            get
            {
                if ( ViewState[ "FriendlyName" ] == null )
                {
                    ViewState.Add( "FriendlyName", string.Empty );
                }
                return ViewState[ "FriendlyName" ].ToString();
            }
            set { ViewState[ "FriendlyName" ] = value; }
        }
		
        /// <summary>
        /// Gets or sets the error text.
        /// <remarks>Defaults to "*"</remarks>
        /// </summary>
        /// <value>The error text.</value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "*" ), Description( "The text displayed by the control when a value is not supplied" )]
        public string ErrorText
        {
            get
            {
                if ( ViewState[ "ErrorText" ] == null )
                {
                    ViewState.Add( "ErrorText", "*" );
                }
                return ViewState[ "ErrorText" ].ToString();
            }
            set { ViewState[ "ErrorText" ] = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:EntityDropDownList"/> is required.
        /// </summary>
        /// <value><c>true</c> if required; otherwise, <c>false</c>.</value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "true" ), Description( "Determines if a value is required" )]
        public bool Required
        {
            get
            {
                if ( ViewState[ "Required" ] == null )
                {
                    ViewState.Add( "Required", false );
                }
                return (bool)ViewState[ "Required" ];
            }
            set { ViewState[ "Required" ] = value; }
        }

        /// <summary>
        /// Gets or sets the required error message.
        /// </summary>
        /// <value>The required error message.</value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "Value required" ), Description( "The message displayed when a value is not supplied" )]
        public string RequiredErrorMessage
        {
            get
            {
                if ( ViewState[ "RequiredErrorMessage" ] == null )
                {
                    string msg = ( FriendlyName.Length > 0 ) ? FriendlyName : "Value";
                    ViewState.Add( "RequiredErrorMessage", string.Format( "{0} required", msg ) );
                }
                return ViewState[ "RequiredErrorMessage" ].ToString();
            }
            set { ViewState[ "RequiredErrorMessage" ] = value; }
        }

        /// <summary>
        /// Gets the collection of items in the list control.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Web.UI.WebControls.ListItemCollection"></see> that represents the items within the list. The default is an empty list.</returns>
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [PersistenceMode( PersistenceMode.InnerDefaultProperty )]
        public override ListItemCollection Items
        {
            get { return base.Items; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [append null row].
        /// </summary>
        /// <value><c>true</c> if [append null row]; otherwise, <c>false</c>.</value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "false" ), Description( "Determines if a null value item should be added to the list" )]
        public bool AppendNullItem
        {
            get
            {
                if ( ViewState[ "AppendNullItem" ] == null )
                {
                    ViewState.Add( "AppendNullItem", false );
                }
                return (bool)ViewState[ "AppendNullItem" ];
            }
            set { ViewState[ "AppendNullItem" ] = value; }
        }


        /// <summary>
        /// Gets or sets the null item text.
        /// </summary>
        /// <value>The null item text.</value>
        [Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "" ), Description( "The text to be used when AppendNullItem is true" )]
        public string NullItemText
        {
            get
            {
                if ( ViewState[ "NullItemText" ] == null )
                {
                    ViewState.Add( "NullItemText", string.Empty );
                }
                return ViewState[ "NullItemText" ].ToString();
            }
            set { ViewState[ "NullItemText" ] = value; }
        }
        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntityDropDownList"/> class.
        /// </summary>
        public EntityDropDownList()
            : base()
        {
            EnsureChildControls();
        } 
        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit( e );

            // Required field?
            if ( Required && !ReadOnly )
            {
                requiredValidator.Enabled = false;
                requiredValidator.ControlToValidate = this.ID;
                requiredValidator.ID = this.ID + "_RQ";
                requiredValidator.Text = ErrorText;
                requiredValidator.ErrorMessage = RequiredErrorMessage;
                requiredValidator.EnableClientScript = EnableClientScript;
				requiredValidator.ValidationGroup = this.ValidationGroup;
                this.Controls.Add( requiredValidator );
            }

            if ( AppendNullItem )
            {
                this.AppendDataBoundItems = true;
            }
        }
		
			/// <summary>
      	/// Raises the <see cref="E:System.Web.UI.Control.DataBinding"></see> event.
      	/// </summary>
      	/// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
        protected override void OnDataBinding( EventArgs e )
        {
            if ( AppendNullItem && !Page.IsPostBack )
            {
                nullItem.Text = NullItemText;
                nullItem.Value = string.Empty;
                base.Items.Add( nullItem );
            }
            
            base.OnDataBinding( e );

        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            // create the controls
            requiredValidator = new RequiredFieldValidator();
            requiredValidator.ControlToValidate = this.ClientID;
            nullItem = new ListItem();

        }

        /// <summary>
        /// Handles the <see cref="E:System.Web.UI.Control.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !ReadOnly )
            {
                // define the client-side script
                StringBuilder script = new StringBuilder();
                script.Append( "function " + functionName + " (dropdownlist,caseSensitive) {" + System.Environment.NewLine );
                script.Append( "  // check the keypressBuffer attribute is defined on the dropdownlist" + System.Environment.NewLine );
                script.Append( "  var undefined; " + System.Environment.NewLine );
                script.Append( "  if (dropdownlist.keypressBuffer == undefined) { " + System.Environment.NewLine );
                script.Append( "    dropdownlist.keypressBuffer = ''; " + System.Environment.NewLine );
                script.Append( "  } " + System.Environment.NewLine );
                script.Append( "  // get the key that was pressed " + System.Environment.NewLine );
                script.Append( "  var key = String.fromCharCode(window.event.keyCode); " + System.Environment.NewLine );
                script.Append( "  dropdownlist.keypressBuffer += key;" + System.Environment.NewLine );
                script.Append( "  if (!caseSensitive) {" + System.Environment.NewLine );
                script.Append( "    // convert buffer to lowercase" + System.Environment.NewLine );
                script.Append( "    dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();" + System.Environment.NewLine );
                script.Append( "  }" + System.Environment.NewLine );
                script.Append( "  // find if it is the start of any of the options " + System.Environment.NewLine );
                script.Append( "  var optionsLength = dropdownlist.options.length; " + System.Environment.NewLine );
                script.Append( "  for (var n=0; n < optionsLength; n++) { " + System.Environment.NewLine );
                script.Append( "    var optionText = dropdownlist.options[n].text; " + System.Environment.NewLine );
                script.Append( "    if (!caseSensitive) {" + Environment.NewLine );
                script.Append( "      optionText = optionText.toLowerCase();" + Environment.NewLine );
                script.Append( "    }" + System.Environment.NewLine );
                script.Append( "    if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0) { " + System.Environment.NewLine );
                script.Append( "      dropdownlist.selectedIndex = n; " + System.Environment.NewLine );
                script.Append( "      return false; // cancel the default behavior since " + System.Environment.NewLine );
                script.Append( "                    // we have selected our own value " + System.Environment.NewLine );
                script.Append( "    } " + System.Environment.NewLine );
                script.Append( "  } " + System.Environment.NewLine );
                script.Append( "  // reset initial key to be inline with default behavior " + System.Environment.NewLine );
                script.Append( "  dropdownlist.keypressBuffer = key; " + System.Environment.NewLine );
                script.Append( "  return true; // give default behavior " + System.Environment.NewLine );
                script.Append( "} " + System.Environment.NewLine );

                // register the client-side script block
                this.Page.ClientScript.RegisterClientScriptBlock( this.GetType(), functionName, script.ToString(), true );
                this.Attributes.Add( "onkeydown", "return " + functionName + "(this," + CaseSensitiveKeySort.ToString().ToLower() + ")" );
            }
        }
        
        /// <summary> 
        /// The base DropDownList class doesn't allow a child control 
        /// collection.  We'll override it so that we can have one for the validator. 
        /// </summary> 
        protected override System.Web.UI.ControlCollection CreateControlCollection()
        {
            ControlCollection newControlCollection = new ControlCollection(this);
            return newControlCollection;
        }

        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"></see> object that receives the control content.</param>
        protected override void Render( HtmlTextWriter writer )
        {
            RenderDropDownList( writer );
            RenderRequiredValidator( writer );
        }

        /// <summary>
        /// Renders the drop down list.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected void RenderDropDownList( HtmlTextWriter writer )
        {
            if ( ReadOnly )
            {
                if ( string.IsNullOrEmpty( SelectedItem.Text ) )
                {
                    writer.Write( string.Empty );
                }
                else
                {
                    writer.Write( SelectedItem.Text );
                }
            }
            else
            {
                base.Render( writer );
            }
        }

        /// <summary>
        /// Renders the required validator.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected void RenderRequiredValidator( HtmlTextWriter writer )
        {
            if ( Required && !ReadOnly )
            {
                requiredValidator.Enabled = true;
                requiredValidator.RenderControl( writer );
            }
        }
		
		/// <summary>
		/// Calls the validate method on the embedded required validator if permitted
		/// </summary>
		public void Validate()
		{
			if ( Required && requiredValidator != null )
			{
				requiredValidator.Validate();
			}
		}
    }
}
