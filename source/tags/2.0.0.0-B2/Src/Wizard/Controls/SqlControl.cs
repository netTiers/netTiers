using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Summary description for SqlControl.
	/// </summary>
	public class SqlControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox uxSqlSettingsGroupBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SqlControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.uxSqlSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// uxSqlSettingsGroupBox
			// 
			this.uxSqlSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSqlSettingsGroupBox.Location = new System.Drawing.Point(2, 2);
			this.uxSqlSettingsGroupBox.Name = "uxSqlSettingsGroupBox";
			this.uxSqlSettingsGroupBox.Size = new System.Drawing.Size(420, 284);
			this.uxSqlSettingsGroupBox.TabIndex = 0;
			this.uxSqlSettingsGroupBox.TabStop = false;
			this.uxSqlSettingsGroupBox.Text = "Sql settings";
			// 
			// SqlControl
			// 
			this.Controls.Add(this.uxSqlSettingsGroupBox);
			this.DockPadding.All = 2;
			this.Name = "SqlControl";
			this.Size = new System.Drawing.Size(424, 288);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
