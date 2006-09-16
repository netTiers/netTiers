using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SchemaExplorer;

using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Threading;


namespace NetTiers.Wizard.Forms
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class Main : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		
		private SerialCoder.Windows.Controls.Wizard.InfoPage infoPage1;
		private SerialCoder.Windows.Controls.Wizard.Wizard wizard1;

		#region "Wizard pages"

		private SerialCoder.Windows.Controls.Wizard.WizardPage wizardPageWelcome;
		private SerialCoder.Windows.Controls.Wizard.WizardPage wizardPageLoadSettings;
		private SerialCoder.Windows.Controls.Wizard.WizardPage wizardPageDataSource;
		private SerialCoder.Windows.Controls.Wizard.WizardPage wizardPageDocumentation;
		private SerialCoder.Windows.Controls.Wizard.WizardPage wizardPageCrudOptions;
		private SerialCoder.Windows.Controls.Wizard.WizardPage wizardPageNamespaces;
		private SerialCoder.Windows.Controls.Wizard.WizardPage wizardPageGenerationSettings;
		private SerialCoder.Windows.Controls.Wizard.WizardPage wizardPageFinish;

		#endregion

		#region "Wizard controls"

		private Controls.LoadSettingsControl loadSettingsControl;
		private Controls.DataSourceControl dataSourceControl;
		private Controls.NamespacesControl namespaceControl;
		private Controls.CrudControl crudControl;
		private Controls.DocumentationControl documentationControl;
		private Controls.GenerationControl generationControl;
        private Controls.SaveSettingControl saveSettingsControl;
		#endregion
		
		
		AutoResetEvent m_MREvent = new AutoResetEvent(false);
		
		public Main()
		{
			InitializeComponent();
			
			this.infoPage1.PageText = "This wizard will guide through the process of generating your own .Net Data Tiers Application block.";
		
			#region "Controls"

			this.loadSettingsControl = new NetTiers.Wizard.Controls.LoadSettingsControl();
			this.loadSettingsControl.Dock = DockStyle.Fill;

			this.dataSourceControl = new NetTiers.Wizard.Controls.DataSourceControl();
			this.dataSourceControl.Dock = DockStyle.Fill;
			this.dataSourceControl.DataSourceTested += new CancelEventHandler(dataSourceControl_DataSourceTested);

			// Documentation control
			this.documentationControl = new NetTiers.Wizard.Controls.DocumentationControl();
			this.documentationControl.Dock = DockStyle.Fill;

			// Namespace control
			this.namespaceControl = new NetTiers.Wizard.Controls.NamespacesControl();
			this.namespaceControl.Dock = DockStyle.Fill;
			
			// Crud control
			this.crudControl = new NetTiers.Wizard.Controls.CrudControl();
			this.crudControl.Dock = DockStyle.Fill;

			this.generationControl = new NetTiers.Wizard.Controls.GenerationControl();
			this.generationControl.Dock = DockStyle.Fill;

			this.saveSettingsControl = new NetTiers.Wizard.Controls.SaveSettingControl();
			this.saveSettingsControl.Dock = DockStyle.Fill;

			#endregion

			#region "Wizard pages"

			// LoadSettings page
			this.wizardPageLoadSettings.Controls.Add(loadSettingsControl);
			this.wizardPageLoadSettings.Controls.Add(this.CreateWizardHeader());

			// DataSource page
			this.wizardPageDataSource.Controls.Add(this.dataSourceControl);
			this.wizardPageDataSource.Controls.Add(this.CreateWizardHeader());
			
			// Documentation page
			this.wizardPageDocumentation.Controls.Add(this.documentationControl);
			this.wizardPageDocumentation.Controls.Add(this.CreateWizardHeader());

			// Namespace page
			this.wizardPageNamespaces.Controls.Add(this.namespaceControl);
			this.wizardPageNamespaces.Controls.Add(this.CreateWizardHeader());
			
			// Crud page
			this.wizardPageCrudOptions.Controls.Add(this.crudControl);
			this.wizardPageCrudOptions.Controls.Add(this.CreateWizardHeader());

			// Generation page
			this.wizardPageGenerationSettings.Controls.Add(this.generationControl);
			this.wizardPageGenerationSettings.Controls.Add(this.CreateWizardHeader());

			// Save setting page
			this.wizardPageFinish.Controls.Add(this.saveSettingsControl);
			this.wizardPageFinish.Controls.Add(this.CreateWizardHeader());

			#endregion
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Main));
			this.wizardPageFinish = new SerialCoder.Windows.Controls.Wizard.WizardPage();
			this.wizardPageGenerationSettings = new SerialCoder.Windows.Controls.Wizard.WizardPage();
			this.wizardPageCrudOptions = new SerialCoder.Windows.Controls.Wizard.WizardPage();
			this.wizardPageNamespaces = new SerialCoder.Windows.Controls.Wizard.WizardPage();
			this.wizardPageDocumentation = new SerialCoder.Windows.Controls.Wizard.WizardPage();
			this.wizardPageLoadSettings = new SerialCoder.Windows.Controls.Wizard.WizardPage();
			this.wizardPageWelcome = new SerialCoder.Windows.Controls.Wizard.WizardPage();
			this.infoPage1 = new SerialCoder.Windows.Controls.Wizard.InfoPage();
			this.wizard1 = new SerialCoder.Windows.Controls.Wizard.Wizard();
			this.wizardPageDataSource = new SerialCoder.Windows.Controls.Wizard.WizardPage();
			this.wizardPageWelcome.SuspendLayout();
			this.wizard1.SuspendLayout();
			this.SuspendLayout();
			// 
			// wizardPageFinish
			// 
			this.wizardPageFinish.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageFinish.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.wizardPageFinish.Location = new System.Drawing.Point(0, 0);
			this.wizardPageFinish.Name = "wizardPageFinish";
			this.wizardPageFinish.Size = new System.Drawing.Size(576, 365);
			this.wizardPageFinish.TabIndex = 10;
			this.wizardPageFinish.ShowFromNext += new System.EventHandler(this.wizardPageFinish_ShowFromNext);
			// 
			// wizardPageGenerationSettings
			// 
			this.wizardPageGenerationSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageGenerationSettings.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.wizardPageGenerationSettings.Location = new System.Drawing.Point(0, 0);
			this.wizardPageGenerationSettings.Name = "wizardPageGenerationSettings";
			this.wizardPageGenerationSettings.Size = new System.Drawing.Size(576, 365);
			this.wizardPageGenerationSettings.TabIndex = 9;
			this.wizardPageGenerationSettings.Tag = "ready ?";
			// 
			// wizardPageCrudOptions
			// 
			this.wizardPageCrudOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageCrudOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.wizardPageCrudOptions.Location = new System.Drawing.Point(0, 0);
			this.wizardPageCrudOptions.Name = "wizardPageCrudOptions";
			this.wizardPageCrudOptions.Size = new System.Drawing.Size(576, 365);
			this.wizardPageCrudOptions.TabIndex = 7;
			// 
			// wizardPageNamespaces
			// 
			this.wizardPageNamespaces.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageNamespaces.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.wizardPageNamespaces.Location = new System.Drawing.Point(0, 0);
			this.wizardPageNamespaces.Name = "wizardPageNamespaces";
			this.wizardPageNamespaces.Size = new System.Drawing.Size(576, 365);
			this.wizardPageNamespaces.TabIndex = 5;
			this.wizardPageNamespaces.ShowFromNext += new System.EventHandler(this.wizardPageNamespaces_ShowFromNext);
			// 
			// wizardPageDocumentation
			// 
			this.wizardPageDocumentation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageDocumentation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.wizardPageDocumentation.Location = new System.Drawing.Point(0, 0);
			this.wizardPageDocumentation.Name = "wizardPageDocumentation";
			this.wizardPageDocumentation.Size = new System.Drawing.Size(576, 365);
			this.wizardPageDocumentation.TabIndex = 4;
			this.wizardPageDocumentation.Tag = "database browser and configuration";
			// 
			// wizardPageLoadSettings
			// 
			this.wizardPageLoadSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageLoadSettings.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.wizardPageLoadSettings.Location = new System.Drawing.Point(0, 0);
			this.wizardPageLoadSettings.Name = "wizardPageLoadSettings";
			this.wizardPageLoadSettings.Size = new System.Drawing.Size(576, 365);
			this.wizardPageLoadSettings.TabIndex = 2;
			this.wizardPageLoadSettings.Tag = "open existing project";
			// 
			// wizardPageWelcome
			// 
			this.wizardPageWelcome.Controls.Add(this.infoPage1);
			this.wizardPageWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageWelcome.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.wizardPageWelcome.Location = new System.Drawing.Point(0, 0);
			this.wizardPageWelcome.Name = "wizardPageWelcome";
			this.wizardPageWelcome.Size = new System.Drawing.Size(576, 365);
			this.wizardPageWelcome.TabIndex = 1;
			// 
			// infoPage1
			// 
			this.infoPage1.BackColor = System.Drawing.Color.White;
			this.infoPage1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoPage1.Image = ((System.Drawing.Image)(resources.GetObject("infoPage1.Image")));
			this.infoPage1.Location = new System.Drawing.Point(0, 0);
			this.infoPage1.Name = "infoPage1";
			this.infoPage1.PageText = "This wizard enables you to generate classes, stored procedures, webservice, unit " +
				"tests, documentation, build file, visual studio projects for your sql server dat" +
				"abase.";
			this.infoPage1.PageTitle = "Welcome to the .NetTiers Wizard";
			this.infoPage1.Size = new System.Drawing.Size(576, 365);
			this.infoPage1.TabIndex = 0;
			// 
			// wizard1
			// 
			this.wizard1.Controls.Add(this.wizardPageWelcome);
			this.wizard1.Controls.Add(this.wizardPageFinish);
			this.wizard1.Controls.Add(this.wizardPageGenerationSettings);
			this.wizard1.Controls.Add(this.wizardPageCrudOptions);
			this.wizard1.Controls.Add(this.wizardPageNamespaces);
			this.wizard1.Controls.Add(this.wizardPageDocumentation);
			this.wizard1.Controls.Add(this.wizardPageDataSource);
			this.wizard1.Controls.Add(this.wizardPageLoadSettings);
			this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.wizard1.Location = new System.Drawing.Point(0, 0);
			this.wizard1.Name = "wizard1";
			this.wizard1.Pages.AddRange(new SerialCoder.Windows.Controls.Wizard.WizardPage[] {
																								 this.wizardPageWelcome,
																								 this.wizardPageLoadSettings,
																								 this.wizardPageDataSource,
																								 this.wizardPageDocumentation,
																								 this.wizardPageNamespaces,
																								 this.wizardPageCrudOptions,
																								 this.wizardPageGenerationSettings,
																								 this.wizardPageFinish});
			this.wizard1.Size = new System.Drawing.Size(576, 413);
			this.wizard1.TabIndex = 7;
			this.wizard1.CloseFromCancel += new System.ComponentModel.CancelEventHandler(this.wizard1_CloseFromCancel);
			// 
			// wizardPageDataSource
			// 
			this.wizardPageDataSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageDataSource.Location = new System.Drawing.Point(0, 0);
			this.wizardPageDataSource.Name = "wizardPageDataSource";
			this.wizardPageDataSource.Size = new System.Drawing.Size(576, 365);
			this.wizardPageDataSource.TabIndex = 3;
			this.wizardPageDataSource.ShowFromNext += new System.EventHandler(this.wizardPageDataSource_ShowFromNext);
			// 
			// Main
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 413);
			this.Controls.Add(this.wizard1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = ".NetTiers";
			this.wizardPageWelcome.ResumeLayout(false);
			this.wizard1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		/// <summary>
		/// When the cnn setting page is displayed, we disable the next button till a connection is tested successfully.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void wizardPageDataSource_ShowFromNext(object sender, System.EventArgs e)
		{
			wizard1.NextEnabled = false;
		}

		private void wizardPageNamespaces_ShowFromNext(object sender, System.EventArgs e)
		{
			wizard1.NextEnabled = true;
		}

		// la derniere page est affichée. bye bye.
		private void wizardPageFinish_ShowFromNext(object sender, System.EventArgs e)
		{
			wizard1.BackEnabled = true;
			wizard1.NextEnabled = true;
			wizard1.CancelEnabled = false;	
		}

		//http://weblogs.asp.net/dphill/articles/43260.aspx
				
		private void wizard1_CloseFromCancel(object sender, System.ComponentModel.CancelEventArgs e)
		{
			wizard1.NextEnabled = true;	
		}

	
		/// <summary>
		/// Handles the DataSourceTested event of the dataSourceControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void dataSourceControl_DataSourceTested(object sender, CancelEventArgs e)
		{
			wizard1.NextEnabled = e.Cancel;
		}


		/// <summary>
		/// Creates a wizard header instance, which is used as header on each wizard page.
		/// </summary>
		/// <returns></returns>
		private SerialCoder.Windows.Controls.Wizard.Header CreateWizardHeader()
		{
			// header will be used on every wizard page
			SerialCoder.Windows.Controls.Wizard.Header header = new SerialCoder.Windows.Controls.Wizard.Header();

			header = new SerialCoder.Windows.Controls.Wizard.Header();
			header.Dock = DockStyle.Top;

			System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream file = thisExe.GetManifestResourceStream("NetTiers.Wizard.Resources.header.png");
			header.Image = Image.FromStream(file);

			header.BackColor = System.Drawing.Color.White;
			header.Description = "The .Net Data Tiers application block generator";
			header.Title = ".NetTiers Wizard";		

			return header;
		}

		
	}
}
