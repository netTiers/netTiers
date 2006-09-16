using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Summary description for SaveSettingControl.
	/// </summary>
	public class SaveSettingControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox uxCommandGroupBox;
		private System.Windows.Forms.Button uxSaveButton;
		private System.Windows.Forms.Button uxSaveAsButton;
		private System.Windows.Forms.Button uxGenerateButton;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SaveSettingControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.Load +=new EventHandler(SaveSettingControl_Load);
		}

		private void SaveSettingControl_Load(object sender, EventArgs e)
		{
			uxSaveButton.DataBindings.Add("Enabled", Program.Context, "HasSettingFile");
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.uxCommandGroupBox = new System.Windows.Forms.GroupBox();
			this.uxGenerateButton = new System.Windows.Forms.Button();
			this.uxSaveAsButton = new System.Windows.Forms.Button();
			this.uxSaveButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.uxCommandGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(388, 100);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(368, 72);
			this.label1.TabIndex = 0;
			this.label1.Text = "Congratulations ! You have provided enough information to NetTiers. It\'s time now" +
				"  to generate your application block. Use the command buttons bellow to decide w" +
				"hat you want to do next.";
			// 
			// uxCommandGroupBox
			// 
			this.uxCommandGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.uxCommandGroupBox.Controls.Add(this.uxGenerateButton);
			this.uxCommandGroupBox.Controls.Add(this.uxSaveAsButton);
			this.uxCommandGroupBox.Controls.Add(this.uxSaveButton);
			this.uxCommandGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxCommandGroupBox.Location = new System.Drawing.Point(8, 112);
			this.uxCommandGroupBox.Name = "uxCommandGroupBox";
			this.uxCommandGroupBox.Size = new System.Drawing.Size(376, 64);
			this.uxCommandGroupBox.TabIndex = 1;
			this.uxCommandGroupBox.TabStop = false;
			this.uxCommandGroupBox.Text = "Commands";
			// 
			// uxGenerateButton
			// 
			this.uxGenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.uxGenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxGenerateButton.Location = new System.Drawing.Point(288, 24);
			this.uxGenerateButton.Name = "uxGenerateButton";
			this.uxGenerateButton.TabIndex = 2;
			this.uxGenerateButton.Text = "&Generate";
			this.uxGenerateButton.Click += new System.EventHandler(this.uxGenerateButton_Click);
			// 
			// uxSaveAsButton
			// 
			this.uxSaveAsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxSaveAsButton.Location = new System.Drawing.Point(96, 24);
			this.uxSaveAsButton.Name = "uxSaveAsButton";
			this.uxSaveAsButton.TabIndex = 1;
			this.uxSaveAsButton.Text = "&Save as...";
			this.uxSaveAsButton.Click += new System.EventHandler(this.uxSaveAsButton_Click);
			// 
			// uxSaveButton
			// 
			this.uxSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxSaveButton.Location = new System.Drawing.Point(8, 24);
			this.uxSaveButton.Name = "uxSaveButton";
			this.uxSaveButton.TabIndex = 0;
			this.uxSaveButton.Text = "&Save";
			this.uxSaveButton.Click += new System.EventHandler(this.uxSaveButton_Click);
			// 
			// SaveSettingControl
			// 
			this.Controls.Add(this.uxCommandGroupBox);
			this.Controls.Add(this.panel1);
			this.DockPadding.All = 2;
			this.Name = "SaveSettingControl";
			this.Size = new System.Drawing.Size(392, 264);
			this.panel1.ResumeLayout(false);
			this.uxCommandGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void uxGenerateButton_Click(object sender, System.EventArgs e)
		{
			Forms.GenerationProgress genForm = new NetTiers.Wizard.Forms.GenerationProgress();
			genForm.ShowDialog();
		}

		private void uxSaveButton_Click(object sender, System.EventArgs e)
		{
			Program.Context.Template.SavePropertiesToXmlFile(Program.Context.SettingFileName);
		}

		private void uxSaveAsButton_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "NetTiers files (*.nettiers)|*.nettiers|All files (*.*)|*.*";
			saveFileDialog.DefaultExt = ".nettiers";
			saveFileDialog.AddExtension = true;
			saveFileDialog.CheckFileExists = false;
			saveFileDialog.Title = "Select a NetTiers settings file";
			saveFileDialog.FileName = string.Format("{0}.NetTiers", Program.Context.SourceDatabase.Name);

			if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
			{
				Program.Context.SettingFileName = saveFileDialog.FileName;
				Program.Context.Template.SavePropertiesToXmlFile(Program.Context.SettingFileName);
			}
		}

		
	}
}
