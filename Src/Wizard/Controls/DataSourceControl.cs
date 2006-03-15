using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Description résumée de DataSourceControl.
	/// </summary>
	public class DataSourceControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox uxDataSourceSettings;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txbPassword;
		private System.Windows.Forms.CheckBox ckbUseTrustedConnection;
		private System.Windows.Forms.Button uxTestButton;
		private System.Windows.Forms.ErrorProvider uxServerErrorProvider;
		private System.Windows.Forms.ErrorProvider uxCatalogErrorProvider;
		private System.Windows.Forms.ErrorProvider uxUserErrorProvider;
		private System.Windows.Forms.TextBox uxCatalogTextBox;
		private System.Windows.Forms.TextBox uxUserTextBox;
		private System.Windows.Forms.ComboBox uxServerTextBox;
		private System.Windows.Forms.Label uxMessageLabel;

		public event CancelEventHandler DataSourceTested ;

		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		
		public DataSourceControl()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			
			this.Load +=new EventHandler(DataSourceControl_Load);
		}

		private void DataSourceControl_Load(object sender, EventArgs e)
		{
			Utilities.SQLInfoEnumerator sie = new Utilities.SQLInfoEnumerator();			
			uxServerTextBox.Items.Clear();
			uxServerTextBox.Items.AddRange(sie.EnumerateSQLServers());
			BindConnectionStringToControls();
		}

		/// <summary>
		/// Binds the connection string to controls.
		/// </summary>
		private void BindConnectionStringToControls()
		{
			if (Program.Context.SourceDatabase == null) return;
			string[] cnnItems = Program.Context.SourceDatabase.ConnectionString.Split(';');
			
			foreach(string item in cnnItems)
			{
				string[] key = item.Split('=');

				switch(key[0].ToLower())
				{
					case "user id":
						uxUserTextBox.Text = key[1];
						break;

					case "password":
						txbPassword.Text = key[1];
						break;

					case "data source":
					case "server":
						uxServerTextBox.Text = key[1];
						break;

					case "initial catalog":
					case "database":
						uxCatalogTextBox.Text = key[1];
						break;

					case "trusted_connection":
					case "integrated security":
						if (key[1].ToLower() == "true" || key[1].ToLower() == "yes")
						{
							this.ckbUseTrustedConnection.Checked = true;
						}
						else
						{
							this.ckbUseTrustedConnection.Checked = false;
						}
						break;
				}
			}
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
			this.uxDataSourceSettings = new System.Windows.Forms.GroupBox();
			this.uxMessageLabel = new System.Windows.Forms.Label();
			this.uxServerTextBox = new System.Windows.Forms.ComboBox();
			this.uxTestButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.ckbUseTrustedConnection = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txbPassword = new System.Windows.Forms.TextBox();
			this.uxUserTextBox = new System.Windows.Forms.TextBox();
			this.uxCatalogTextBox = new System.Windows.Forms.TextBox();
			this.uxServerErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxCatalogErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxUserErrorProvider = new System.Windows.Forms.ErrorProvider();
			this.uxDataSourceSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxDataSourceSettings
			// 
			this.uxDataSourceSettings.Controls.Add(this.uxMessageLabel);
			this.uxDataSourceSettings.Controls.Add(this.uxServerTextBox);
			this.uxDataSourceSettings.Controls.Add(this.uxTestButton);
			this.uxDataSourceSettings.Controls.Add(this.label5);
			this.uxDataSourceSettings.Controls.Add(this.ckbUseTrustedConnection);
			this.uxDataSourceSettings.Controls.Add(this.label4);
			this.uxDataSourceSettings.Controls.Add(this.label3);
			this.uxDataSourceSettings.Controls.Add(this.label2);
			this.uxDataSourceSettings.Controls.Add(this.txbPassword);
			this.uxDataSourceSettings.Controls.Add(this.uxUserTextBox);
			this.uxDataSourceSettings.Controls.Add(this.uxCatalogTextBox);
			this.uxDataSourceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxDataSourceSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxDataSourceSettings.Location = new System.Drawing.Point(2, 2);
			this.uxDataSourceSettings.Name = "uxDataSourceSettings";
			this.uxDataSourceSettings.Size = new System.Drawing.Size(540, 268);
			this.uxDataSourceSettings.TabIndex = 0;
			this.uxDataSourceSettings.TabStop = false;
			this.uxDataSourceSettings.Text = "DataSource settings";
			// 
			// uxMessageLabel
			// 
			this.uxMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.uxMessageLabel.AutoSize = true;
			this.uxMessageLabel.BackColor = System.Drawing.SystemColors.Info;
			this.uxMessageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uxMessageLabel.ForeColor = System.Drawing.Color.Red;
			this.uxMessageLabel.Location = new System.Drawing.Point(104, 184);
			this.uxMessageLabel.Name = "uxMessageLabel";
			this.uxMessageLabel.Size = new System.Drawing.Size(37, 19);
			this.uxMessageLabel.TabIndex = 8;
			this.uxMessageLabel.Text = "label1";
			this.uxMessageLabel.Visible = false;
			// 
			// uxServerTextBox
			// 
			this.uxServerTextBox.Location = new System.Drawing.Point(96, 24);
			this.uxServerTextBox.Name = "uxServerTextBox";
			this.uxServerTextBox.Size = new System.Drawing.Size(192, 21);
			this.uxServerTextBox.TabIndex = 1;
			// 
			// uxTestButton
			// 
			this.uxTestButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxTestButton.Location = new System.Drawing.Point(16, 184);
			this.uxTestButton.Name = "uxTestButton";
			this.uxTestButton.TabIndex = 6;
			this.uxTestButton.Text = "&Test";
			this.uxTestButton.Click += new System.EventHandler(this.uxTestButton_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label5.Location = new System.Drawing.Point(24, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Password";
			// 
			// ckbUseTrustedConnection
			// 
			this.ckbUseTrustedConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ckbUseTrustedConnection.Location = new System.Drawing.Point(96, 152);
			this.ckbUseTrustedConnection.Name = "ckbUseTrustedConnection";
			this.ckbUseTrustedConnection.Size = new System.Drawing.Size(200, 24);
			this.ckbUseTrustedConnection.TabIndex = 5;
			this.ckbUseTrustedConnection.Text = "Use trusted connection";
			this.ckbUseTrustedConnection.CheckedChanged += new System.EventHandler(this.ckbUseTrustedConnection_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Location = new System.Drawing.Point(48, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "User";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(40, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Catalog";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(40, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Server";
			// 
			// txbPassword
			// 
			this.txbPassword.Location = new System.Drawing.Point(96, 120);
			this.txbPassword.Name = "txbPassword";
			this.txbPassword.PasswordChar = '*';
			this.txbPassword.Size = new System.Drawing.Size(192, 20);
			this.txbPassword.TabIndex = 4;
			this.txbPassword.Text = "";
			this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
			// 
			// uxUserTextBox
			// 
			this.uxUserTextBox.Location = new System.Drawing.Point(96, 88);
			this.uxUserTextBox.Name = "uxUserTextBox";
			this.uxUserTextBox.Size = new System.Drawing.Size(192, 20);
			this.uxUserTextBox.TabIndex = 3;
			this.uxUserTextBox.Text = "";
			this.uxUserTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxUserTextBox_Validating);
			this.uxUserTextBox.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
			// 
			// uxCatalogTextBox
			// 
			this.uxCatalogTextBox.Location = new System.Drawing.Point(96, 56);
			this.uxCatalogTextBox.Name = "uxCatalogTextBox";
			this.uxCatalogTextBox.Size = new System.Drawing.Size(192, 20);
			this.uxCatalogTextBox.TabIndex = 2;
			this.uxCatalogTextBox.Text = "";
			this.uxCatalogTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uxCatalogTextBox_Validating);
			this.uxCatalogTextBox.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
			// 
			// uxServerErrorProvider
			// 
			this.uxServerErrorProvider.ContainerControl = this;
			// 
			// uxCatalogErrorProvider
			// 
			this.uxCatalogErrorProvider.ContainerControl = this;
			// 
			// uxUserErrorProvider
			// 
			this.uxUserErrorProvider.ContainerControl = this;
			// 
			// DataSourceControl
			// 
			this.Controls.Add(this.uxDataSourceSettings);
			this.DockPadding.All = 2;
			this.Name = "DataSourceControl";
			this.Size = new System.Drawing.Size(544, 272);
			this.uxDataSourceSettings.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// Gets the connection string.
		/// </summary>
		/// <returns></returns>
		private string GetConnectionString() 
		{
			return String.Format("server={0};database={1}; uid={2};pwd={3};Trusted_Connection={4};CONNECTION TIMEOUT=1", uxServerTextBox.Text, uxCatalogTextBox.Text, uxUserTextBox.Text , txbPassword.Text, (ckbUseTrustedConnection.Checked ? "yes" : "no"));
		}

		/// <summary>
		/// Test the connection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uxTestButton_Click(object sender, System.EventArgs e)
		{
			SqlConnection cnn = new SqlConnection(GetConnectionString());
			try
			{
				cnn.Open();
				
				uxMessageLabel.BackColor = Color.White;
				uxMessageLabel.ForeColor = Color.Blue;
				uxMessageLabel.Text = "Test successfull !";
				//wizard1.NextEnabled = true;

				SchemaExplorer.SqlSchemaProvider schemaProvider = new SchemaExplorer.SqlSchemaProvider();
				Program.Context.SourceDatabase = new SchemaExplorer.DatabaseSchema(schemaProvider, GetConnectionString());
	
				this.uxTestButton.Enabled = true;
				
				OnDataSourceTested(true);
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				uxMessageLabel.BackColor = Color.LightYellow;
				uxMessageLabel.ForeColor = Color.Red;
				uxMessageLabel.Text = ex.Message;
				OnDataSourceTested(false);
				//wizard1.NextEnabled = false;
			}
			finally
			{
				cnn.Close();
				uxMessageLabel.Visible = true;
			}

		}

		private void txbPassword_TextChanged(object sender, System.EventArgs e)
		{
			this.uxTestButton.Enabled = true;
			OnDataSourceTested(false);
		}

		private void ckbUseTrustedConnection_CheckedChanged(object sender, System.EventArgs e)
		{
			this.uxTestButton.Enabled = true;
			OnDataSourceTested(false);
		}

		/// <summary>
		/// Called when [data source tested].
		/// </summary>
		private void OnDataSourceTested(bool cancel)
		{
			if (DataSourceTested != null)
			{
				DataSourceTested(this, new CancelEventArgs(cancel));
			}
		}

		#region "Validations"

		/// <summary>
		/// Handles the Validating event of the txbServer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void txbServer_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxServerTextBox.Text.Length == 0)
			{
				uxServerErrorProvider.SetError (uxServerTextBox, "Please enter a sql server name");
				e.Cancel = true;
			}
			else
			{
				uxServerErrorProvider.SetError (uxServerTextBox, string.Empty);
				e.Cancel = false;

//				Utilities.SQLInfoEnumerator sie = new Utilities.SQLInfoEnumerator();
//				sie.SQLServer = uxServerTextBox.Text; 
//				sie.Username = uxUserTextBox.Text;
//				sie.Password = txbPassword.Text;
				//SQLListBox.Items.AddRange(sie.EnumerateSQLServersDatabases());
			}
		}

		/// <summary>
		/// Handles the Validating event of the uxCatalogTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void uxCatalogTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (uxCatalogTextBox.Text.Length == 0)
			{
				uxCatalogErrorProvider.SetError (uxCatalogTextBox, "Please enter the catalogue name");
				e.Cancel = true;
			}
			else
			{
				uxCatalogErrorProvider.SetError (uxCatalogTextBox, string.Empty);
				e.Cancel = false;
			}
		}

		/// <summary>
		/// Handles the Validating event of the uxUserTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void uxUserTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!ckbUseTrustedConnection.Checked && uxUserTextBox.Text.Length ==0)
			{
				uxUserErrorProvider.SetError (uxUserTextBox, "Please enter the user name or choose integrated security");
				e.Cancel = false; // let user go out to click the checkbox
			}
			else
			{
				uxUserErrorProvider.SetError (uxUserTextBox, string.Empty);
				e.Cancel = false;
			}
		}

		#endregion
		
	}
}
