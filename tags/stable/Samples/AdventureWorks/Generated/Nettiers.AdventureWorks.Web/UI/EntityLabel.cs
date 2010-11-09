
#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections;
using Nettiers.AdventureWorks;
#endregion

namespace Nettiers.AdventureWorks.Web.UI
{
    /// <summary>
    /// Specialised DataBoundControl that renders as a Label
    /// <remarks>
    /// DataSource should return 1 row
    /// </remarks>
    /// </summary>
    public class EntityLabel : DataBoundControl
    {
		#region Fields
        Regex placeHolder0 = new Regex( @"\{(?<ID>[0])(?<PARAM>:[^}]+)?\}" ); // first placeholder
        Regex placeHolder1 = new Regex( @"\{(?<ID>[1])(?<PARAM>:[^}]+)?\}" ); // second placeholder
		#endregion
		
        #region Properties
        /// <summary>
        /// Gets or sets the data value field.
        /// </summary>
        /// <value>The data value field.</value>
        public virtual string DataValueField
        {
            get
            {
                object o = ViewState[ "DataValueField" ];
                if ( o == null )
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                ViewState[ "DataValueField" ] = value;
            }
        }

        /// <summary>
        /// Gets or sets the data text field.
        /// </summary>
        /// <value>The data text field.</value>
        public virtual string DataTextField
        {
            get
            {
                object o = ViewState[ "DataTextField" ];
                if ( o == null )
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                ViewState[ "DataTextField" ] = value;
            }
        }

        /// <summary>
        /// Gets or sets the data text format string.
        /// </summary>
        /// <value>The data text format string.</value>
        public virtual string DataTextFormatString
        {
            get
            {
                object o = ViewState[ "DataTextFormatString" ];
                if ( o == null )
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                ViewState[ "DataTextFormatString" ] = value;
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public virtual object Text
        {
            get { return ViewState[ "Text" ]; }
            set { ViewState[ "Text" ] = value; }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public virtual object Value
        {
            get { return ViewState[ "Value" ]; }
            set { ViewState[ "Value" ] = value; }
        }  
        #endregion

        #region Override Data methods
        /// <summary>
        /// When overridden in a derived class, binds data from the data source to the control.
        /// </summary>
        /// <param name="data">The <see cref="T:System.Collections.IEnumerable"></see> list of data returned from a <see cref="M:System.Web.UI.WebControls.DataBoundControl.PerformSelect"></see> method call.</param>
        protected override void PerformDataBinding( System.Collections.IEnumerable data )
        {
            if ( data == null )
            {
                return;
            }

            // get the next data item
            IEnumerator e = data.GetEnumerator();
            while ( e.MoveNext() )
            {
                // get the text item if specified
                if ( !string.IsNullOrEmpty( DataTextField ) )
                {
                     this.Text = DataBinder.GetPropertyValue( e.Current, DataTextField );
                }

                // get the value item if specified
                if ( !string.IsNullOrEmpty( DataValueField ) )
                {
                    this.Value = DataBinder.GetPropertyValue( e.Current, DataValueField );
                }

                // we only do the first item
                break;
            }
        } 
        #endregion

        #region Override Control methods
        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"></see> object that receives the control content.</param>
        protected override void Render( HtmlTextWriter writer )
        {
            if ( !string.IsNullOrEmpty( this.DataTextFormatString ) &&
                    placeHolder0.IsMatch( this.DataTextFormatString ) )
            {
                if ( placeHolder1.IsMatch( this.DataTextFormatString ) )
            	{
                	writer.Write( string.Format( this.DataTextFormatString, Text, Value ) );
            	}
				else
				{
	                writer.Write( string.Format( this.DataTextFormatString, Text ) );
				}
            }
            else
            {
                writer.Write( Text );
            }
        } 
        #endregion
    }
}
