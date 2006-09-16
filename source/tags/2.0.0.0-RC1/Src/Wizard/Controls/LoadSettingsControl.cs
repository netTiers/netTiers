using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Summary description for LoadSettingsControl.
	/// </summary>
	public class LoadSettingsControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button uxLoadSettingsButton;
		private System.Windows.Forms.TextBox uxFileNameTextBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LoadSettingsControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.Load += new EventHandler(LoadSettingsControl_Load);

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uxLoadSettingsButton = new System.Windows.Forms.Button();
			this.uxFileNameTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.uxLoadSettingsButton);
			this.groupBox1.Controls.Add(this.uxFileNameTextBox);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(452, 332);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Load settings";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(16, 152);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(384, 21);
			this.comboBox1.TabIndex = 20;
			this.comboBox1.Text = "comboBox1";
			this.comboBox1.Visible = false;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 24);
			this.label1.TabIndex = 17;
			this.label1.Text = "Load an existing configuration: ";
			// 
			// uxLoadSettingsButton
			// 
			this.uxLoadSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxLoadSettingsButton.Location = new System.Drawing.Point(312, 72);
			this.uxLoadSettingsButton.Name = "uxLoadSettingsButton";
			this.uxLoadSettingsButton.TabIndex = 19;
			this.uxLoadSettingsButton.Text = "&Browse";
			this.uxLoadSettingsButton.Click += new System.EventHandler(this.uxLoadSettingsButton_Click);
			// 
			// uxFileNameTextBox
			// 
			this.uxFileNameTextBox.Location = new System.Drawing.Point(8, 48);
			this.uxFileNameTextBox.Name = "uxFileNameTextBox";
			this.uxFileNameTextBox.ReadOnly = true;
			this.uxFileNameTextBox.Size = new System.Drawing.Size(384, 20);
			this.uxFileNameTextBox.TabIndex = 18;
			this.uxFileNameTextBox.Text = "";
			// 
			// LoadSettingsControl
			// 
			this.Controls.Add(this.groupBox1);
			this.DockPadding.All = 2;
			this.Name = "LoadSettingsControl";
			this.Size = new System.Drawing.Size(456, 336);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void uxLoadSettingsButton_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Filter = "NetTiers files (*.nettiers)|*.nettiers|All files (*.*)|*.*";
			openDialog.DefaultExt = ".nettiers";
			openDialog.Multiselect = false;
			openDialog.CheckFileExists = true;
			openDialog.Title = "Select a NetTiers settings file";
			
			if (openDialog.ShowDialog() != DialogResult.Cancel)
			{
				this.uxFileNameTextBox.Text = openDialog.FileName;
				Program.Context.LoadSettingsFile(openDialog.FileName);
			}
		}

		private void LoadSettingsControl_Load(object sender, EventArgs e)
		{
			this.uxFileNameTextBox.Text = Program.Context.SettingFileName;
		}
	}
}
