using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NetTiers.Wizard.Forms
{
	/// <summary>
	/// Description résumée de ErrorReport.
	/// </summary>
	public class ErrorReport : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox uxErrorTextBox;
		private System.Windows.Forms.Button uxCloseButton;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private static ErrorReport current;
		private static volatile object SyncRoot = new object();

		private ErrorReport()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			this.uxCloseButton.Click += new EventHandler(uxCloseButton_Click);
		}

		public static ErrorReport Current
		{
			get
			{
				if (current == null)
				{
					lock(SyncRoot)
					{
						if (current == null)
						{
							current = new ErrorReport();
						}
					}
				}
				return current;
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

		public string ErrorText
		{
			set
			{
				this.uxErrorTextBox.Text = value;
			}
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.uxErrorTextBox = new System.Windows.Forms.TextBox();
			this.uxCloseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// uxErrorTextBox
			// 
			this.uxErrorTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.uxErrorTextBox.Location = new System.Drawing.Point(0, 0);
			this.uxErrorTextBox.Multiline = true;
			this.uxErrorTextBox.Name = "uxErrorTextBox";
			this.uxErrorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.uxErrorTextBox.Size = new System.Drawing.Size(488, 264);
			this.uxErrorTextBox.TabIndex = 0;
			this.uxErrorTextBox.Text = "";
			// 
			// uxCloseButton
			// 
			this.uxCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxCloseButton.Location = new System.Drawing.Point(208, 272);
			this.uxCloseButton.Name = "uxCloseButton";
			this.uxCloseButton.TabIndex = 1;
			this.uxCloseButton.Text = "&Close";
			// 
			// ErrorReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 304);
			this.ControlBox = false;
			this.Controls.Add(this.uxCloseButton);
			this.Controls.Add(this.uxErrorTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ErrorReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ErrorReport";
			this.ResumeLayout(false);

		}
		#endregion

		private void uxCloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
