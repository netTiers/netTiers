using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Description résumée de CrudControl.
	/// </summary>
	public class CrudControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox uxCrudOptionsGroupBox;
		private System.Windows.Forms.CheckBox uxIncludeCustomCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeDeleteCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeFindCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeGetCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeGetListCheckBox;
		private System.Windows.Forms.CheckBox uxGetListByFKCheckBox;
		private System.Windows.Forms.CheckBox uxGetListByIXCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeInsertCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeUpdateCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeSaveCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeRelationsCheckBox;
		private System.Windows.Forms.CheckBox uxIncludeMany2ManyRelationsCheckBox;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CrudControl()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			this.uxIncludeInsertCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeInsert");
			this.uxIncludeUpdateCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeUpdate");
			this.uxIncludeDeleteCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeDelete");
			this.uxIncludeSaveCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeSave");

			this.uxIncludeGetCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeGet");
			this.uxIncludeGetListCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeGetList");
			this.uxGetListByFKCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeGetListByFK");
			this.uxGetListByIXCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeGetListByIX");

			this.uxIncludeCustomCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeCustoms");
			this.uxIncludeFindCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeFind");
			this.uxIncludeRelationsCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeRelations");
			this.uxIncludeMany2ManyRelationsCheckBox.DataBindings.Add("Checked", Program.Context, "IncludeManyToMany");


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
			this.uxCrudOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.uxIncludeMany2ManyRelationsCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeRelationsCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeSaveCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeUpdateCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeInsertCheckBox = new System.Windows.Forms.CheckBox();
			this.uxGetListByIXCheckBox = new System.Windows.Forms.CheckBox();
			this.uxGetListByFKCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeGetListCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeGetCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeFindCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeDeleteCheckBox = new System.Windows.Forms.CheckBox();
			this.uxIncludeCustomCheckBox = new System.Windows.Forms.CheckBox();
			this.uxCrudOptionsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxCrudOptionsGroupBox
			// 
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeMany2ManyRelationsCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeRelationsCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeSaveCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeUpdateCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeInsertCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxGetListByIXCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxGetListByFKCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeGetListCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeGetCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeFindCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeDeleteCheckBox);
			this.uxCrudOptionsGroupBox.Controls.Add(this.uxIncludeCustomCheckBox);
			this.uxCrudOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCrudOptionsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxCrudOptionsGroupBox.Location = new System.Drawing.Point(2, 2);
			this.uxCrudOptionsGroupBox.Name = "uxCrudOptionsGroupBox";
			this.uxCrudOptionsGroupBox.Size = new System.Drawing.Size(636, 164);
			this.uxCrudOptionsGroupBox.TabIndex = 0;
			this.uxCrudOptionsGroupBox.TabStop = false;
			this.uxCrudOptionsGroupBox.Text = "CRUD options";
			// 
			// uxIncludeMany2ManyRelationsCheckBox
			// 
			this.uxIncludeMany2ManyRelationsCheckBox.Location = new System.Drawing.Point(256, 136);
			this.uxIncludeMany2ManyRelationsCheckBox.Name = "uxIncludeMany2ManyRelationsCheckBox";
			this.uxIncludeMany2ManyRelationsCheckBox.Size = new System.Drawing.Size(232, 24);
			this.uxIncludeMany2ManyRelationsCheckBox.TabIndex = 11;
			this.uxIncludeMany2ManyRelationsCheckBox.Text = "Detect also M:N relations";
			// 
			// uxIncludeRelationsCheckBox
			// 
			this.uxIncludeRelationsCheckBox.Location = new System.Drawing.Point(256, 112);
			this.uxIncludeRelationsCheckBox.Name = "uxIncludeRelationsCheckBox";
			this.uxIncludeRelationsCheckBox.Size = new System.Drawing.Size(232, 24);
			this.uxIncludeRelationsCheckBox.TabIndex = 10;
			this.uxIncludeRelationsCheckBox.Text = "Detect relations";
			this.uxIncludeRelationsCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// uxIncludeSaveCheckBox
			// 
			this.uxIncludeSaveCheckBox.Location = new System.Drawing.Point(16, 64);
			this.uxIncludeSaveCheckBox.Name = "uxIncludeSaveCheckBox";
			this.uxIncludeSaveCheckBox.Size = new System.Drawing.Size(224, 24);
			this.uxIncludeSaveCheckBox.TabIndex = 9;
			this.uxIncludeSaveCheckBox.Text = "Generate Save methods";
			// 
			// uxIncludeUpdateCheckBox
			// 
			this.uxIncludeUpdateCheckBox.Location = new System.Drawing.Point(16, 40);
			this.uxIncludeUpdateCheckBox.Name = "uxIncludeUpdateCheckBox";
			this.uxIncludeUpdateCheckBox.Size = new System.Drawing.Size(224, 24);
			this.uxIncludeUpdateCheckBox.TabIndex = 8;
			this.uxIncludeUpdateCheckBox.Text = "Generate Update methods";
			// 
			// uxIncludeInsertCheckBox
			// 
			this.uxIncludeInsertCheckBox.Location = new System.Drawing.Point(16, 16);
			this.uxIncludeInsertCheckBox.Name = "uxIncludeInsertCheckBox";
			this.uxIncludeInsertCheckBox.Size = new System.Drawing.Size(224, 24);
			this.uxIncludeInsertCheckBox.TabIndex = 7;
			this.uxIncludeInsertCheckBox.Text = "Generate Insert methods";
			// 
			// uxGetListByIXCheckBox
			// 
			this.uxGetListByIXCheckBox.Location = new System.Drawing.Point(256, 64);
			this.uxGetListByIXCheckBox.Name = "uxGetListByIXCheckBox";
			this.uxGetListByIXCheckBox.Size = new System.Drawing.Size(240, 24);
			this.uxGetListByIXCheckBox.TabIndex = 6;
			this.uxGetListByIXCheckBox.Text = "Generate GetList by indexes methods";
			// 
			// uxGetListByFKCheckBox
			// 
			this.uxGetListByFKCheckBox.Location = new System.Drawing.Point(256, 40);
			this.uxGetListByFKCheckBox.Name = "uxGetListByFKCheckBox";
			this.uxGetListByFKCheckBox.Size = new System.Drawing.Size(240, 24);
			this.uxGetListByFKCheckBox.TabIndex = 5;
			this.uxGetListByFKCheckBox.Text = "Generate GetList by foreign keys methods";
			// 
			// uxIncludeGetListCheckBox
			// 
			this.uxIncludeGetListCheckBox.Location = new System.Drawing.Point(256, 16);
			this.uxIncludeGetListCheckBox.Name = "uxIncludeGetListCheckBox";
			this.uxIncludeGetListCheckBox.Size = new System.Drawing.Size(224, 24);
			this.uxIncludeGetListCheckBox.TabIndex = 4;
			this.uxIncludeGetListCheckBox.Text = "Generate GetList methods";
			// 
			// uxIncludeGetCheckBox
			// 
			this.uxIncludeGetCheckBox.Location = new System.Drawing.Point(16, 112);
			this.uxIncludeGetCheckBox.Name = "uxIncludeGetCheckBox";
			this.uxIncludeGetCheckBox.Size = new System.Drawing.Size(224, 24);
			this.uxIncludeGetCheckBox.TabIndex = 3;
			this.uxIncludeGetCheckBox.Text = "Generate Get methods";
			// 
			// uxIncludeFindCheckBox
			// 
			this.uxIncludeFindCheckBox.Location = new System.Drawing.Point(256, 88);
			this.uxIncludeFindCheckBox.Name = "uxIncludeFindCheckBox";
			this.uxIncludeFindCheckBox.Size = new System.Drawing.Size(224, 24);
			this.uxIncludeFindCheckBox.TabIndex = 2;
			this.uxIncludeFindCheckBox.Text = "Generate Find method";
			// 
			// uxIncludeDeleteCheckBox
			// 
			this.uxIncludeDeleteCheckBox.Location = new System.Drawing.Point(16, 88);
			this.uxIncludeDeleteCheckBox.Name = "uxIncludeDeleteCheckBox";
			this.uxIncludeDeleteCheckBox.Size = new System.Drawing.Size(224, 24);
			this.uxIncludeDeleteCheckBox.TabIndex = 1;
			this.uxIncludeDeleteCheckBox.Text = "Generate Delete method";
			// 
			// uxIncludeCustomCheckBox
			// 
			this.uxIncludeCustomCheckBox.Location = new System.Drawing.Point(16, 136);
			this.uxIncludeCustomCheckBox.Name = "uxIncludeCustomCheckBox";
			this.uxIncludeCustomCheckBox.Size = new System.Drawing.Size(224, 24);
			this.uxIncludeCustomCheckBox.TabIndex = 0;
			this.uxIncludeCustomCheckBox.Text = "Detect customs stored procedures";
			// 
			// CrudControl
			// 
			this.Controls.Add(this.uxCrudOptionsGroupBox);
			this.DockPadding.All = 2;
			this.Name = "CrudControl";
			this.Size = new System.Drawing.Size(640, 168);
			this.uxCrudOptionsGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
