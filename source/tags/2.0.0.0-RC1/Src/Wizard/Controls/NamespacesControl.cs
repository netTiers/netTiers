using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Description résumée de NsControl.
	/// </summary>
	public class NamespacesControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox uxNsGroupBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox uxEntitiesFolderNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox uxDalFolderNameTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox uxUnitTestsTextBox;
		private System.Windows.Forms.TextBox uxPreviewTextBox;
		private System.Windows.Forms.TextBox uxRootNamespace;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ErrorProvider uxRootNamespaceErrorProvider;
		private System.Windows.Forms.ErrorProvider uxDalNamespaceErrorProvider;
		private System.Windows.Forms.ErrorProvider uxUnitTestNamespaceErrorProvider;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NamespacesControl()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			this.Load += new EventHandler(NamespacesControl_Load);

			
		}

		private void NamespacesControl_Load(object sender, EventArgs e)
		{
			this.uxRootNamespace.DataBindings.Add("Text", Program.Context, "NameSpace");
			this.uxEntitiesFolderNameTextBox.DataBindings.Add("Text", Program.Context, "BusinessLogicLayerNameSpace");
			this.uxDalFolderNameTextBox.DataBindings.Add("Text", Program.Context, "DataAccessLayerNameSpace");
			this.uxUnitTestsTextBox.DataBindings.Add("Text", Program.Context, "UnitTestsNameSpace");

			if (uxRootNamespace.Text.Length == 0)
			{
				Program.Context.NameSpace = Program.Context.SourceDatabase.Name.Substring(0,1).ToUpper() + Program.Context.SourceDatabase.Name.Remove(0,1);
			}

			this.uxRootNamespace.Focus();
		}

		/// <summary> 
		/// Nettoyage des ressources utilisées.
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

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.uxNsGroupBox = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.uxPreviewTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.uxUnitTestsTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.uxDalFolderNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uxEntitiesFolderNameTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.uxRootNamespace = new System.Windows.Forms.TextBox();
			this.uxRootNamespaceErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxDalNamespaceErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxUnitTestNamespaceErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxNsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxNsGroupBox
			// 
			this.uxNsGroupBox.Controls.Add(this.label4);
			this.uxNsGroupBox.Controls.Add(this.uxPreviewTextBox);
			this.uxNsGroupBox.Controls.Add(this.label3);
			this.uxNsGroupBox.Controls.Add(this.uxUnitTestsTextBox);
			this.uxNsGroupBox.Controls.Add(this.label2);
			this.uxNsGroupBox.Controls.Add(this.uxDalFolderNameTextBox);
			this.uxNsGroupBox.Controls.Add(this.label1);
			this.uxNsGroupBox.Controls.Add(this.uxEntitiesFolderNameTextBox);
			this.uxNsGroupBox.Controls.Add(this.label6);
			this.uxNsGroupBox.Controls.Add(this.uxRootNamespace);
			this.uxNsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxNsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxNsGroupBox.Location = new System.Drawing.Point(2, 2);
			this.uxNsGroupBox.Name = "uxNsGroupBox";
			this.uxNsGroupBox.Size = new System.Drawing.Size(468, 276);
			this.uxNsGroupBox.TabIndex = 0;
			this.uxNsGroupBox.TabStop = false;
			this.uxNsGroupBox.Text = "Namespaces";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(144, 16);
			this.label4.TabIndex = 19;
			this.label4.Text = "Namespaces preview :";
			// 
			// uxPreviewTextBox
			// 
			this.uxPreviewTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uxPreviewTextBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.uxPreviewTextBox.Location = new System.Drawing.Point(8, 184);
			this.uxPreviewTextBox.Multiline = true;
			this.uxPreviewTextBox.Name = "uxPreviewTextBox";
			this.uxPreviewTextBox.ReadOnly = true;
			this.uxPreviewTextBox.Size = new System.Drawing.Size(456, 88);
			this.uxPreviewTextBox.TabIndex = 18;
			this.uxPreviewTextBox.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 16);
			this.label3.TabIndex = 17;
			this.label3.Text = "Tests folder name :";
			// 
			// uxUnitTestsTextBox
			// 
			this.uxUnitTestsTextBox.Location = new System.Drawing.Point(128, 112);
			this.uxUnitTestsTextBox.Name = "uxUnitTestsTextBox";
			this.uxUnitTestsTextBox.Size = new System.Drawing.Size(272, 20);
			this.uxUnitTestsTextBox.TabIndex = 16;
			this.uxUnitTestsTextBox.Text = "UnitTests";
			this.uxUnitTestsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxUnitTestsTextBox_Validating);
			this.uxUnitTestsTextBox.TextChanged += new System.EventHandler(this.uxUnitTestsTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "Dal folder name :";
			// 
			// uxDalFolderNameTextBox
			// 
			this.uxDalFolderNameTextBox.Location = new System.Drawing.Point(128, 88);
			this.uxDalFolderNameTextBox.Name = "uxDalFolderNameTextBox";
			this.uxDalFolderNameTextBox.Size = new System.Drawing.Size(272, 20);
			this.uxDalFolderNameTextBox.TabIndex = 14;
			this.uxDalFolderNameTextBox.Text = "DataAccessLayer";
			this.uxDalFolderNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxDalFolderNameTextBox_Validating);
			this.uxDalFolderNameTextBox.TextChanged += new System.EventHandler(this.uxUnitTestsTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "Entities folder name :";
			// 
			// uxEntitiesFolderNameTextBox
			// 
			this.uxEntitiesFolderNameTextBox.Location = new System.Drawing.Point(128, 64);
			this.uxEntitiesFolderNameTextBox.Name = "uxEntitiesFolderNameTextBox";
			this.uxEntitiesFolderNameTextBox.Size = new System.Drawing.Size(272, 20);
			this.uxEntitiesFolderNameTextBox.TabIndex = 12;
			this.uxEntitiesFolderNameTextBox.Text = "";
			this.uxEntitiesFolderNameTextBox.TextChanged += new System.EventHandler(this.uxUnitTestsTextBox_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Root namespace :";
			// 
			// uxRootNamespace
			// 
			this.uxRootNamespace.Location = new System.Drawing.Point(128, 24);
			this.uxRootNamespace.Name = "uxRootNamespace";
			this.uxRootNamespace.Size = new System.Drawing.Size(272, 20);
			this.uxRootNamespace.TabIndex = 10;
			this.uxRootNamespace.Text = "Company.Product";
			this.uxRootNamespace.Validating += new System.ComponentModel.CancelEventHandler(this.uxRootNamespace_Validating);
			this.uxRootNamespace.TextChanged += new System.EventHandler(this.uxUnitTestsTextBox_TextChanged);
			// 
			// uxRootNamespaceErrorProvider
			// 
			this.uxRootNamespaceErrorProvider.ContainerControl = this;
			// 
			// uxDalNamespaceErrorProvider
			// 
			this.uxDalNamespaceErrorProvider.ContainerControl = this;
			// 
			// uxUnitTestNamespaceErrorProvider
			// 
			this.uxUnitTestNamespaceErrorProvider.ContainerControl = this;
			// 
			// NamespacesControl
			// 
			this.Controls.Add(this.uxNsGroupBox);
			this.DockPadding.All = 2;
			this.Name = "NamespacesControl";
			this.Size = new System.Drawing.Size(472, 280);
			this.uxNsGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void uxUnitTestsTextBox_TextChanged(object sender, System.EventArgs e)
		{
			string _PreviewData = "namespace {1}{2}{0}namespace {1}.{3}{0}namespace {1}.{4}{0}";
			uxPreviewTextBox.Text = string.Format(_PreviewData, Environment.NewLine, uxRootNamespace.Text, uxEntitiesFolderNameTextBox.Text.Length > 0 ? "."+uxEntitiesFolderNameTextBox.Text : string.Empty, uxDalFolderNameTextBox.Text, uxUnitTestsTextBox.Text);
		}

		#region "validations"
		/// <summary>
		/// Handles the Validating event of the uxRootNamespace control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void uxRootNamespace_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxRootNamespace.Text == string.Empty)
			{
				uxRootNamespaceErrorProvider.SetError (uxRootNamespace, "Please enter a root namespace");
				e.Cancel = true;
			}
			else
			{
				uxRootNamespaceErrorProvider.SetError (uxRootNamespace, string.Empty);
				e.Cancel = false;
			}
		}
		

		/// <summary>
		/// Handles the Validating event of the uxDalFolderNameTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void uxDalFolderNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxDalFolderNameTextBox.Text == string.Empty)
			{
				uxDalNamespaceErrorProvider.SetError (uxDalFolderNameTextBox, "Please enter the data access layer folder name");
				e.Cancel = true;
			}
			else
			{
				uxDalNamespaceErrorProvider.SetError (uxDalFolderNameTextBox, string.Empty);
				e.Cancel = false;
			}
		}

		/// <summary>
		/// Handles the Validating event of the uxUnitTestsTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void uxUnitTestsTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxUnitTestsTextBox.Text == string.Empty)
			{
				uxUnitTestNamespaceErrorProvider.SetError (uxUnitTestsTextBox, "Please enter the unit tests folder name");
				e.Cancel = true;
			}
			else
			{
				uxUnitTestNamespaceErrorProvider.SetError (uxUnitTestsTextBox, string.Empty);
				e.Cancel = false;
			}
		}

		#endregion
		
	}
}
