using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NetTiers.Wizard.Forms
{
	/// <summary>
	/// Description résumée de UserSettings.
	/// </summary>
	public class UserSettings : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button btnOk;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserSettings()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			this.propertyGrid1.SelectedObject = Program.Context.ApplicationSettings;
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

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(296, 264);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// btnOk
			// 
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(216, 272);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "&OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// UserSettings
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 303);
			this.ControlBox = false;
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.propertyGrid1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UserSettings";
			this.Text = "UserSettings";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			// todo verification des datas
			Context.Current.SaveUserSettings();
			this.Close();
		}
	}
}
