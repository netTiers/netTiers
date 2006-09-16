using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Description résumée de DataObjectControl.
	/// </summary>
	public class DataObjectControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox uxClassNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox uxDescriptionTextBox;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataObjectControl()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();
		}

		public string ClassName
		{
			get {return this.uxClassNameTextBox.Text;}
			set {this.uxClassNameTextBox.Text = value;}
		}

		public string ClassDescription
		{
			get {return this.uxDescriptionTextBox.Text;}
			set {this.uxDescriptionTextBox.Text = value;}
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
			this.label1 = new System.Windows.Forms.Label();
			this.uxClassNameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.uxDescriptionTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Class name:";
			// 
			// uxClassNameTextBox
			// 
			this.uxClassNameTextBox.Location = new System.Drawing.Point(8, 32);
			this.uxClassNameTextBox.Name = "uxClassNameTextBox";
			this.uxClassNameTextBox.Size = new System.Drawing.Size(224, 20);
			this.uxClassNameTextBox.TabIndex = 1;
			this.uxClassNameTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Description:";
			// 
			// uxDescriptionTextBox
			// 
			this.uxDescriptionTextBox.Location = new System.Drawing.Point(8, 104);
			this.uxDescriptionTextBox.Multiline = true;
			this.uxDescriptionTextBox.Name = "uxDescriptionTextBox";
			this.uxDescriptionTextBox.Size = new System.Drawing.Size(224, 64);
			this.uxDescriptionTextBox.TabIndex = 3;
			this.uxDescriptionTextBox.Text = "";
			// 
			// DataObjectControl
			// 
			this.Controls.Add(this.uxDescriptionTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.uxClassNameTextBox);
			this.Controls.Add(this.label1);
			this.Name = "DataObjectControl";
			this.Size = new System.Drawing.Size(240, 208);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
