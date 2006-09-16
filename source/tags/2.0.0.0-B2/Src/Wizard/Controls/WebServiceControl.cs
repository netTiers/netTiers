using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Summary description for WebServiceControl.
	/// </summary>
	public class WebServiceControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox uxWebServiceSettings;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox uxGenerateWebServiceCheckBox;
		private System.Windows.Forms.TextBox uxWebServiceVirtualDirectoryName;
		private System.Windows.Forms.TextBox uxUrlPreviewTextBox;
		private System.Windows.Forms.Label label2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WebServiceControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.uxGenerateWebServiceCheckBox.DataBindings.Add("Checked", Program.Context, "GenerateWebservice");
			this.uxWebServiceVirtualDirectoryName.DataBindings.Add("Text", Program.Context, "WebServiceVirtualDirectoryName");
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
			this.uxWebServiceSettings = new System.Windows.Forms.GroupBox();
			this.uxUrlPreviewTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.uxGenerateWebServiceCheckBox = new System.Windows.Forms.CheckBox();
			this.uxWebServiceVirtualDirectoryName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.uxWebServiceSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxWebServiceSettings
			// 
			this.uxWebServiceSettings.Controls.Add(this.label2);
			this.uxWebServiceSettings.Controls.Add(this.uxUrlPreviewTextBox);
			this.uxWebServiceSettings.Controls.Add(this.label1);
			this.uxWebServiceSettings.Controls.Add(this.label11);
			this.uxWebServiceSettings.Controls.Add(this.label10);
			this.uxWebServiceSettings.Controls.Add(this.uxGenerateWebServiceCheckBox);
			this.uxWebServiceSettings.Controls.Add(this.uxWebServiceVirtualDirectoryName);
			this.uxWebServiceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxWebServiceSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxWebServiceSettings.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.uxWebServiceSettings.Location = new System.Drawing.Point(2, 2);
			this.uxWebServiceSettings.Name = "uxWebServiceSettings";
			this.uxWebServiceSettings.Size = new System.Drawing.Size(452, 164);
			this.uxWebServiceSettings.TabIndex = 1;
			this.uxWebServiceSettings.TabStop = false;
			this.uxWebServiceSettings.Text = "WebService Settings";
			// 
			// uxUrlPreviewTextBox
			// 
			this.uxUrlPreviewTextBox.Location = new System.Drawing.Point(8, 128);
			this.uxUrlPreviewTextBox.Name = "uxUrlPreviewTextBox";
			this.uxUrlPreviewTextBox.ReadOnly = true;
			this.uxUrlPreviewTextBox.Size = new System.Drawing.Size(440, 21);
			this.uxUrlPreviewTextBox.TabIndex = 13;
			this.uxUrlPreviewTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 23);
			this.label1.TabIndex = 12;
			this.label1.Text = "Virtual directory name :";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(56, 104);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(0, 16);
			this.label11.TabIndex = 11;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(8, 80);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(0, 16);
			this.label10.TabIndex = 10;
			// 
			// uxGenerateWebServiceCheckBox
			// 
			this.uxGenerateWebServiceCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.uxGenerateWebServiceCheckBox.Location = new System.Drawing.Point(16, 24);
			this.uxGenerateWebServiceCheckBox.Name = "uxGenerateWebServiceCheckBox";
			this.uxGenerateWebServiceCheckBox.Size = new System.Drawing.Size(136, 24);
			this.uxGenerateWebServiceCheckBox.TabIndex = 7;
			this.uxGenerateWebServiceCheckBox.Text = "Create webservice";
			// 
			// uxWebServiceVirtualDirectoryName
			// 
			this.uxWebServiceVirtualDirectoryName.Enabled = false;
			this.uxWebServiceVirtualDirectoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.uxWebServiceVirtualDirectoryName.Location = new System.Drawing.Point(168, 56);
			this.uxWebServiceVirtualDirectoryName.Name = "uxWebServiceVirtualDirectoryName";
			this.uxWebServiceVirtualDirectoryName.Size = new System.Drawing.Size(280, 20);
			this.uxWebServiceVirtualDirectoryName.TabIndex = 8;
			this.uxWebServiceVirtualDirectoryName.Text = "";
			this.uxWebServiceVirtualDirectoryName.TextChanged += new System.EventHandler(this.uxWebServiceFolderName_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 23);
			this.label2.TabIndex = 14;
			this.label2.Text = "WebService url preview :";
			// 
			// WebServiceControl
			// 
			this.Controls.Add(this.uxWebServiceSettings);
			this.DockPadding.All = 2;
			this.Name = "WebServiceControl";
			this.Size = new System.Drawing.Size(456, 168);
			this.uxWebServiceSettings.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void uxWebServiceFolderName_TextChanged(object sender, System.EventArgs e)
		{
			this.uxUrlPreviewTextBox.Text = string.Format("http://localhost/{0}/{1}Services.asmx", uxWebServiceVirtualDirectoryName.Text);
		}
	}
}
