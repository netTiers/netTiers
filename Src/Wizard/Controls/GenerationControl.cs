using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Threading;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Summary description for GenerationControl.
	/// </summary>
	public class GenerationControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox uxGenerationSettingsGroupBox;
		private System.Windows.Forms.Button uxBrowseButton;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox ckbStoredProcedure;
		private System.Windows.Forms.CheckBox ckbUnitTests;
		private System.Windows.Forms.TextBox uxOutputPathTextBox;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckBox uxCreateWebServiceCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ErrorProvider uxDestinationErrorProvider;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox uxUsePartialClassCheckBox;
		private System.Windows.Forms.RadioButton uxV2005RadioButton;
		private System.Windows.Forms.GroupBox uxWebServiceGroupBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox uxWebServiceOutputPathTextBox;
		private System.Windows.Forms.TextBox uxWebServiceUrlTextBox;
		private System.Windows.Forms.ErrorProvider uxWebServiceUrlErrorProvider;
		private System.Windows.Forms.ErrorProvider uxWebServiceOutputPathErrorProvider;
		private System.Windows.Forms.GroupBox uxCodeDocumentationSettingsGroupBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox uxCompanyUrlTextBox;
		private System.Windows.Forms.TextBox uxCompanyNameTextBox;
		private System.Windows.Forms.ErrorProvider uxCompanyNameErrorProvider;
		private System.Windows.Forms.ErrorProvider uxCompanyURLErrorProvider;
		private System.Windows.Forms.RadioButton uxV2003RadioButton;

		


		public GenerationControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			this.Load += new EventHandler(GenerationControl_Load);
		}


		private void GenerationControl_Load(object sender, EventArgs e)
		{
			// templates bindings
			this.uxCompanyNameTextBox.DataBindings.Add("Text", Program.Context, "CompanyName");
			this.uxCompanyUrlTextBox.DataBindings.Add("Text", Program.Context, "CompanyUrl");

			this.ckbStoredProcedure.DataBindings.Add("Checked", Program.Context, "CreateStoredProcedure");
			this.ckbUnitTests.DataBindings.Add("Checked", Program.Context, "CreateUnitTest");		
			this.uxCreateWebServiceCheckBox.DataBindings.Add("Checked", Program.Context, "GenerateWebservice");
			this.uxOutputPathTextBox.DataBindings.Add("Text", Program.Context, "OuputDirectory");
			this.uxUsePartialClassCheckBox.DataBindings.Add("Checked", Program.Context, "UsePartialClass");
			//this.uxV2003RadioButton.DataBindings.Add("Checked", Program.Context, "IsTargetingVisualStudio2003");

			this.uxWebServiceUrlTextBox.DataBindings.Add("Text", Program.Context, "WebServiceUrl");
			this.uxWebServiceOutputPathTextBox.DataBindings.Add("Text", Program.Context, "WebServiceOutputPath");

			uxV2003RadioButton.Checked = Program.Context.IsTargetingVisualStudio2003;

			// controls bindings
			//this.uxWebServiceVirtualDirectoryName.DataBindings.Add("Enabled", this.uxCreateWebServiceCheckBox, "Checked");
			this.uxUsePartialClassCheckBox.DataBindings.Add("Enabled", this.uxV2005RadioButton, "Checked");
			this.uxWebServiceGroupBox.DataBindings.Add("Enabled", this.uxCreateWebServiceCheckBox, "Checked");

//			if (uxRootNamespace.Text.Length == 0)
//			{
//				Program.Context.NameSpace = Program.Context.SourceDatabase.Name.Substring(0,1).ToUpper() + Program.Context.SourceDatabase.Name.Remove(0,1);
//			}
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
			this.uxGenerationSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.uxWebServiceGroupBox = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.uxWebServiceOutputPathTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uxWebServiceUrlTextBox = new System.Windows.Forms.TextBox();
			this.uxUsePartialClassCheckBox = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.uxBrowseButton = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.uxOutputPathTextBox = new System.Windows.Forms.TextBox();
			this.uxV2005RadioButton = new System.Windows.Forms.RadioButton();
			this.uxV2003RadioButton = new System.Windows.Forms.RadioButton();
			this.ckbStoredProcedure = new System.Windows.Forms.CheckBox();
			this.uxCreateWebServiceCheckBox = new System.Windows.Forms.CheckBox();
			this.ckbUnitTests = new System.Windows.Forms.CheckBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.uxDestinationErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxWebServiceUrlErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxWebServiceOutputPathErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxCodeDocumentationSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.uxCompanyUrlTextBox = new System.Windows.Forms.TextBox();
			this.uxCompanyNameTextBox = new System.Windows.Forms.TextBox();
			this.uxCompanyNameErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxCompanyURLErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxGenerationSettingsGroupBox.SuspendLayout();
			this.uxWebServiceGroupBox.SuspendLayout();
			this.panel1.SuspendLayout();
			this.uxCodeDocumentationSettingsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxGenerationSettingsGroupBox
			// 
			this.uxGenerationSettingsGroupBox.Controls.Add(this.uxWebServiceGroupBox);
			this.uxGenerationSettingsGroupBox.Controls.Add(this.uxUsePartialClassCheckBox);
			this.uxGenerationSettingsGroupBox.Controls.Add(this.panel1);
			this.uxGenerationSettingsGroupBox.Controls.Add(this.uxV2005RadioButton);
			this.uxGenerationSettingsGroupBox.Controls.Add(this.uxV2003RadioButton);
			this.uxGenerationSettingsGroupBox.Controls.Add(this.ckbStoredProcedure);
			this.uxGenerationSettingsGroupBox.Controls.Add(this.uxCreateWebServiceCheckBox);
			this.uxGenerationSettingsGroupBox.Controls.Add(this.ckbUnitTests);
			this.uxGenerationSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxGenerationSettingsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxGenerationSettingsGroupBox.Location = new System.Drawing.Point(2, 80);
			this.uxGenerationSettingsGroupBox.Name = "uxGenerationSettingsGroupBox";
			this.uxGenerationSettingsGroupBox.Size = new System.Drawing.Size(564, 230);
			this.uxGenerationSettingsGroupBox.TabIndex = 0;
			this.uxGenerationSettingsGroupBox.TabStop = false;
			this.uxGenerationSettingsGroupBox.Text = "Generation settings";
			// 
			// uxWebServiceGroupBox
			// 
			this.uxWebServiceGroupBox.Controls.Add(this.label2);
			this.uxWebServiceGroupBox.Controls.Add(this.uxWebServiceOutputPathTextBox);
			this.uxWebServiceGroupBox.Controls.Add(this.label1);
			this.uxWebServiceGroupBox.Controls.Add(this.uxWebServiceUrlTextBox);
			this.uxWebServiceGroupBox.Location = new System.Drawing.Point(208, 56);
			this.uxWebServiceGroupBox.Name = "uxWebServiceGroupBox";
			this.uxWebServiceGroupBox.Size = new System.Drawing.Size(344, 80);
			this.uxWebServiceGroupBox.TabIndex = 34;
			this.uxWebServiceGroupBox.TabStop = false;
			this.uxWebServiceGroupBox.Text = "WebService settings";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 33;
			this.label2.Text = "Folder path:";
			// 
			// uxWebServiceOutputPathTextBox
			// 
			this.uxWebServiceOutputPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.uxWebServiceOutputPathTextBox.Location = new System.Drawing.Point(88, 48);
			this.uxWebServiceOutputPathTextBox.Name = "uxWebServiceOutputPathTextBox";
			this.uxWebServiceOutputPathTextBox.Size = new System.Drawing.Size(232, 20);
			this.uxWebServiceOutputPathTextBox.TabIndex = 32;
			this.uxWebServiceOutputPathTextBox.Text = "";
			this.uxWebServiceOutputPathTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxWebServiceOutputPathTextBox_Validating);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 31;
			this.label1.Text = "Base url :";
			// 
			// uxWebServiceUrlTextBox
			// 
			this.uxWebServiceUrlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.uxWebServiceUrlTextBox.Location = new System.Drawing.Point(88, 24);
			this.uxWebServiceUrlTextBox.Name = "uxWebServiceUrlTextBox";
			this.uxWebServiceUrlTextBox.Size = new System.Drawing.Size(232, 20);
			this.uxWebServiceUrlTextBox.TabIndex = 30;
			this.uxWebServiceUrlTextBox.Text = "";
			this.uxWebServiceUrlTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxWebServiceUrlTextBox_Validating);
			// 
			// uxUsePartialClassCheckBox
			// 
			this.uxUsePartialClassCheckBox.Checked = true;
			this.uxUsePartialClassCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.uxUsePartialClassCheckBox.Location = new System.Drawing.Point(240, 24);
			this.uxUsePartialClassCheckBox.Name = "uxUsePartialClassCheckBox";
			this.uxUsePartialClassCheckBox.Size = new System.Drawing.Size(152, 24);
			this.uxUsePartialClassCheckBox.TabIndex = 33;
			this.uxUsePartialClassCheckBox.Text = "Use partial classes";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Info;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.uxBrowseButton);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.uxOutputPathTextBox);
			this.panel1.Location = new System.Drawing.Point(24, 152);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(520, 64);
			this.panel1.TabIndex = 32;
			// 
			// uxBrowseButton
			// 
			this.uxBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxBrowseButton.Location = new System.Drawing.Point(432, 32);
			this.uxBrowseButton.Name = "uxBrowseButton";
			this.uxBrowseButton.TabIndex = 22;
			this.uxBrowseButton.Text = "&Browse";
			this.uxBrowseButton.Click += new System.EventHandler(this.uxBrowseButton_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.SystemColors.MenuText;
			this.label7.Location = new System.Drawing.Point(8, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 16);
			this.label7.TabIndex = 21;
			this.label7.Text = "Destination folder:";
			// 
			// uxOutputPathTextBox
			// 
			this.uxOutputPathTextBox.Location = new System.Drawing.Point(8, 32);
			this.uxOutputPathTextBox.Name = "uxOutputPathTextBox";
			this.uxOutputPathTextBox.Size = new System.Drawing.Size(400, 20);
			this.uxOutputPathTextBox.TabIndex = 17;
			this.uxOutputPathTextBox.Text = "c:\\temp";
			this.uxOutputPathTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxOutputPathTextBox_Validating);
			// 
			// uxV2005RadioButton
			// 
			this.uxV2005RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxV2005RadioButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.uxV2005RadioButton.Location = new System.Drawing.Point(120, 24);
			this.uxV2005RadioButton.Name = "uxV2005RadioButton";
			this.uxV2005RadioButton.TabIndex = 25;
			this.uxV2005RadioButton.Text = "VS.Net 2005";
			// 
			// uxV2003RadioButton
			// 
			this.uxV2003RadioButton.Checked = true;
			this.uxV2003RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxV2003RadioButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.uxV2003RadioButton.Location = new System.Drawing.Point(24, 24);
			this.uxV2003RadioButton.Name = "uxV2003RadioButton";
			this.uxV2003RadioButton.TabIndex = 24;
			this.uxV2003RadioButton.TabStop = true;
			this.uxV2003RadioButton.Text = "VS.Net 2003";
			this.uxV2003RadioButton.CheckedChanged += new System.EventHandler(this.uxV2003RadioButton_CheckedChanged);
			// 
			// ckbStoredProcedure
			// 
			this.ckbStoredProcedure.Location = new System.Drawing.Point(24, 88);
			this.ckbStoredProcedure.Name = "ckbStoredProcedure";
			this.ckbStoredProcedure.Size = new System.Drawing.Size(152, 24);
			this.ckbStoredProcedure.TabIndex = 20;
			this.ckbStoredProcedure.Text = "Create stored procedures";
			// 
			// uxCreateWebServiceCheckBox
			// 
			this.uxCreateWebServiceCheckBox.Location = new System.Drawing.Point(24, 112);
			this.uxCreateWebServiceCheckBox.Name = "uxCreateWebServiceCheckBox";
			this.uxCreateWebServiceCheckBox.Size = new System.Drawing.Size(152, 24);
			this.uxCreateWebServiceCheckBox.TabIndex = 19;
			this.uxCreateWebServiceCheckBox.Text = "Create webservice";
			// 
			// ckbUnitTests
			// 
			this.ckbUnitTests.Location = new System.Drawing.Point(24, 64);
			this.ckbUnitTests.Name = "ckbUnitTests";
			this.ckbUnitTests.Size = new System.Drawing.Size(152, 24);
			this.ckbUnitTests.TabIndex = 18;
			this.ckbUnitTests.Text = "Create nUnit tests";
			// 
			// uxDestinationErrorProvider
			// 
			this.uxDestinationErrorProvider.ContainerControl = this;
			// 
			// uxWebServiceUrlErrorProvider
			// 
			this.uxWebServiceUrlErrorProvider.ContainerControl = this;
			// 
			// uxWebServiceOutputPathErrorProvider
			// 
			this.uxWebServiceOutputPathErrorProvider.ContainerControl = this;
			// 
			// uxCodeDocumentationSettingsGroupBox
			// 
			this.uxCodeDocumentationSettingsGroupBox.Controls.Add(this.label9);
			this.uxCodeDocumentationSettingsGroupBox.Controls.Add(this.label8);
			this.uxCodeDocumentationSettingsGroupBox.Controls.Add(this.uxCompanyUrlTextBox);
			this.uxCodeDocumentationSettingsGroupBox.Controls.Add(this.uxCompanyNameTextBox);
			this.uxCodeDocumentationSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.uxCodeDocumentationSettingsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxCodeDocumentationSettingsGroupBox.Location = new System.Drawing.Point(2, 2);
			this.uxCodeDocumentationSettingsGroupBox.Name = "uxCodeDocumentationSettingsGroupBox";
			this.uxCodeDocumentationSettingsGroupBox.Size = new System.Drawing.Size(564, 78);
			this.uxCodeDocumentationSettingsGroupBox.TabIndex = 35;
			this.uxCodeDocumentationSettingsGroupBox.TabStop = false;
			this.uxCodeDocumentationSettingsGroupBox.Text = "Code documentation settings";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label9.Location = new System.Drawing.Point(24, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(74, 16);
			this.label9.TabIndex = 16;
			this.label9.Text = "Company url :";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label8.Location = new System.Drawing.Point(24, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 16);
			this.label8.TabIndex = 15;
			this.label8.Text = "Company name :";
			// 
			// uxCompanyUrlTextBox
			// 
			this.uxCompanyUrlTextBox.Location = new System.Drawing.Point(138, 48);
			this.uxCompanyUrlTextBox.Name = "uxCompanyUrlTextBox";
			this.uxCompanyUrlTextBox.Size = new System.Drawing.Size(272, 20);
			this.uxCompanyUrlTextBox.TabIndex = 14;
			this.uxCompanyUrlTextBox.Text = "";
			this.uxCompanyUrlTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxCompanyUrlTextBox_Validating);
			this.uxCompanyUrlTextBox.DoubleClick += new System.EventHandler(this.uxCompanyUrlTextBox_DoubleClick);
			// 
			// uxCompanyNameTextBox
			// 
			this.uxCompanyNameTextBox.Location = new System.Drawing.Point(138, 24);
			this.uxCompanyNameTextBox.Name = "uxCompanyNameTextBox";
			this.uxCompanyNameTextBox.Size = new System.Drawing.Size(272, 20);
			this.uxCompanyNameTextBox.TabIndex = 13;
			this.uxCompanyNameTextBox.Text = "";
			this.uxCompanyNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxCompanyNameTextBox_Validating);
			this.uxCompanyNameTextBox.DoubleClick += new System.EventHandler(this.uxCompanyNameTextBox_DoubleClick);
			// 
			// uxCompanyNameErrorProvider
			// 
			this.uxCompanyNameErrorProvider.ContainerControl = this;
			// 
			// uxCompanyURLErrorProvider
			// 
			this.uxCompanyURLErrorProvider.ContainerControl = this;
			// 
			// GenerationControl
			// 
			this.Controls.Add(this.uxGenerationSettingsGroupBox);
			this.Controls.Add(this.uxCodeDocumentationSettingsGroupBox);
			this.DockPadding.All = 2;
			this.Name = "GenerationControl";
			this.Size = new System.Drawing.Size(568, 312);
			this.uxGenerationSettingsGroupBox.ResumeLayout(false);
			this.uxWebServiceGroupBox.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.uxCodeDocumentationSettingsGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Handles the Click event of the uxBrowseButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void uxBrowseButton_Click(object sender, System.EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				uxOutputPathTextBox.Text = folderBrowserDialog1.SelectedPath;
				//Program.Context.OuputDirectory = folderBrowserDialog1.SelectedPath;
			}
		}

		/// <summary>
		/// Handles the Click event of the uxGenerateButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void uxGenerateButton_Click(object sender, EventArgs e)
		{
			Forms.GenerationProgress genForm = new NetTiers.Wizard.Forms.GenerationProgress();
			genForm.ShowDialog();
		}

		/// <summary>
		/// Handles the Validating event of the uxOutputPathTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void uxOutputPathTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (System.IO.Directory.Exists(uxOutputPathTextBox.Text))
			{
				uxDestinationErrorProvider.SetError (uxOutputPathTextBox, string.Empty);
				e.Cancel = false;
			}
			else
			{
				try
				{
					System.IO.Directory.CreateDirectory(uxOutputPathTextBox.Text);
				}
				catch(System.IO.IOException ex)
				{
					uxDestinationErrorProvider.SetError (uxOutputPathTextBox, "Please enter a valid folder path." + Environment.NewLine + ex.Message);
					e.Cancel = true;
				}
				catch(Exception)
				{
					uxDestinationErrorProvider.SetError (uxOutputPathTextBox, "Please enter a valid folder path.");
					e.Cancel = true;
				}				
			}
		}

		private void uxV2003RadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			Program.Context.IsTargetingVisualStudio2003 = uxV2003RadioButton.Checked;
		}

		private void uxWebServiceUrlTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxCreateWebServiceCheckBox.Checked)
			{
				try
				{
					Uri uri = new Uri(uxWebServiceUrlTextBox.Text);

					// TODO: check if this web folder exists
				}
				catch(Exception)
				{
					uxWebServiceUrlErrorProvider.SetError (uxWebServiceUrlTextBox, "Please enter a valid webservice base url.");
					e.Cancel = true;
					return;
				}
			}
			
			uxWebServiceUrlErrorProvider.SetError (uxWebServiceUrlTextBox, string.Empty);
			e.Cancel = false;
		}

		private void uxWebServiceOutputPathTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxCreateWebServiceCheckBox.Checked)
			{
				if (!System.IO.Directory.Exists(uxWebServiceOutputPathTextBox.Text))
				{
					uxWebServiceOutputPathErrorProvider.SetError (uxWebServiceOutputPathTextBox, "Please enter the path that match the above url");
					e.Cancel = false;
					return;
				}
				else
				{
					// TODO create a temp file, and browse it
				}
			}
			
			uxWebServiceOutputPathErrorProvider.SetError (uxWebServiceOutputPathTextBox, string.Empty);
			e.Cancel = false;
		
		}

		private void uxCompanyNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxCompanyNameTextBox.Text == string.Empty)
			{
				uxCompanyNameErrorProvider.SetError (uxCompanyNameTextBox, "Please enter your company name");
				e.Cancel = true;
			}
			else
			{
				uxCompanyNameErrorProvider.SetError (uxCompanyNameTextBox, string.Empty);
				e.Cancel = false;
			}
		}

		private void uxCompanyUrlTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				Uri companyUri = new Uri(uxCompanyUrlTextBox.Text);
				uxCompanyURLErrorProvider.SetError (uxCompanyUrlTextBox, string.Empty);
				e.Cancel = false;
			}
			catch(Exception)
			{
				uxCompanyURLErrorProvider.SetError (uxCompanyUrlTextBox, "Please enter your company's website URL");
				e.Cancel = true;
			}
		}

		private void uxCompanyUrlTextBox_DoubleClick(object sender, System.EventArgs e)
		{
			if (uxCompanyUrlTextBox.Text.Length == 0)
			{
				uxCompanyUrlTextBox.Text = "http://www.mycompany.com";
			}
		}

		private void uxCompanyNameTextBox_DoubleClick(object sender, System.EventArgs e)
		{
			if (uxCompanyNameTextBox.Text.Length == 0)
			{
				uxCompanyNameTextBox.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			}
		}

		/*
		/// <summary>
		/// Handles the Validating event of the uxWebServiceVirtualDirectoryName control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void uxWebServiceVirtualDirectoryName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxCreateWebServiceCheckBox.Checked && uxCreateWebServiceCheckBox.Text.Length == 0)
			{
				uxVirtualErrorProvider.SetError (uxWebServiceVirtualDirectoryName, "Please enter the name of the webservice virtual directory.");
				e.Cancel = true;
			}
			else
			{
				uxVirtualErrorProvider.SetError (uxWebServiceVirtualDirectoryName, string.Empty);
				e.Cancel = false;
			}
		}
		*/
	}
}
