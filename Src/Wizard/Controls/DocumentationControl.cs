using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;

using SchemaExplorer;

namespace NetTiers.Wizard.Controls
{
	
	/// <summary>
	/// Summary description for DocumentationControl.
	/// </summary>
	public class DocumentationControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox uxDataBaseDocumentationSettingsGroupBox;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		ThreadEventHandler onTreeViewElement;

		Entities.DataObjectCollection dos = new NetTiers.Wizard.Entities.DataObjectCollection();
		
		public DocumentationControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			this.onTreeViewElement = new ThreadEventHandler(populateTreeView);

			this.Load+=new EventHandler(DocumentationControl_Load);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DocumentationControl));
			this.uxDataBaseDocumentationSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.treeView = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.uxDataBaseDocumentationSettingsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxDataBaseDocumentationSettingsGroupBox
			// 
			this.uxDataBaseDocumentationSettingsGroupBox.Controls.Add(this.treeView);
			this.uxDataBaseDocumentationSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxDataBaseDocumentationSettingsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxDataBaseDocumentationSettingsGroupBox.Location = new System.Drawing.Point(2, 2);
			this.uxDataBaseDocumentationSettingsGroupBox.Name = "uxDataBaseDocumentationSettingsGroupBox";
			this.uxDataBaseDocumentationSettingsGroupBox.Size = new System.Drawing.Size(676, 292);
			this.uxDataBaseDocumentationSettingsGroupBox.TabIndex = 1;
			this.uxDataBaseDocumentationSettingsGroupBox.TabStop = false;
			this.uxDataBaseDocumentationSettingsGroupBox.Text = "Database documentation settings";
			// 
			// treeView
			// 
			this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView.ImageList = this.imageList1;
			this.treeView.ItemHeight = 16;
			this.treeView.Location = new System.Drawing.Point(3, 16);
			this.treeView.Name = "treeView";
			this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				 new System.Windows.Forms.TreeNode("Database", 0, 0, new System.Windows.Forms.TreeNode[] {
																																											 new System.Windows.Forms.TreeNode("Tables", 2, 2),
																																											 new System.Windows.Forms.TreeNode("Views", 2, 2)})});
			this.treeView.Size = new System.Drawing.Size(205, 273);
			this.treeView.TabIndex = 9;
			this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
			this.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeSelect);
			
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// DocumentationControl
			// 
			this.Controls.Add(this.uxDataBaseDocumentationSettingsGroupBox);
			this.DockPadding.All = 2;
			this.Name = "DocumentationControl";
			this.Size = new System.Drawing.Size(680, 296);
			this.uxDataBaseDocumentationSettingsGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void DataBind()
		{
			//treeView.TopNode.Nodes.Clear();
			treeView.TopNode.Text =	Program.Context.SourceDatabase.Name;
            
			foreach(TableSchema table in Program.Context.SourceDatabase.Tables)
			{
				Entities.DataObject doTable = new Entities.DataObject();
				doTable.Name = table.Name;
				doTable.AliasName = table.Name; // Todo : clean name invoke from template
				doTable.Description = table.Description;
				doTable.Type = Entities.DataObjectType.Table;

				BeginInvoke(onTreeViewElement, new object[] {this, new ThreadEventArgs(doTable)});
			}

			foreach(ViewSchema view in Program.Context.SourceDatabase.Views)
			{
				Entities.DataObject doView = new Entities.DataObject();
				doView.Name = view.Name;
				doView.AliasName = view.Name; // Todo : clean name invoke from template
				doView.Description = view.Description;
				doView.Type = Entities.DataObjectType.View;

				BeginInvoke(onTreeViewElement, new object[] {this, new ThreadEventArgs(doView)});
			}

			this.treeView.TopNode.Expand();
			this.treeView.Enabled = true;
		}

		private void populateTreeView(object sender, ThreadEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			DataObjectControl ctrl = new DataObjectControl();
			ctrl.Visible = false;
			ctrl.Top = 16;
			ctrl.Left = 216;
			this.uxDataBaseDocumentationSettingsGroupBox.Controls.Add(ctrl);

			DataObjectTreeNode node = new DataObjectTreeNode(e.DataObject, ctrl);

			//TreeNode node = new TreeNode(e.DataObject.Name, 3, 3);
			//node.Tag = e.DataObject;

			
//			//this.treeViewItems.Add(table.Name, 0);
//			foreach(ColumnSchema column in Program.Context.SourceTables[e.DataObject.Name].Columns)
//			{
//				TreeNode columnNode = new TreeNode(column.Name, 4, 4);
//				columnNode.Tag = column;
//				tableNode.Nodes.Add(columnNode);
//			}

			switch(e.DataObject.Type)
			{
				case Entities.DataObjectType.Table :
					treeView.TopNode.Nodes[0].Nodes.Add(node);
					break;
				
				case Entities.DataObjectType.View :
					treeView.TopNode.Nodes[1].Nodes.Add(node);
					break;
				
			}
			
			treeView.TopNode.Nodes[0].Expand();
			treeView.TopNode.Nodes[1].Expand();
			Cursor.Current = Cursors.Default;
		}


		private void treeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Node is DataObjectTreeNode)
			{
				((DataObjectTreeNode)e.Node).Control.Visible = true;
			}

			/*
			Cursor.Current = Cursors.WaitCursor;

			if (e.Node.Tag is ColumnSchema)
			{
				txbName.Text = ((ColumnSchema)e.Node.Tag).Name;
				txbDescription.Text = ((ColumnSchema)e.Node.Tag).Description;
			}
			else if (e.Node.Tag is TableSchema)
			{
				txbName.Text = ((TableSchema)e.Node.Tag).Name;
				txbDescription.Text = ((TableSchema)e.Node.Tag).Description;
				
				uxAliasTextBox.Text = ((ColumnSchema)e.Node.Tag).ExtendedProperties["AliasName"] == null ? string.Empty : ((ColumnSchema)e.Node.Tag).ExtendedProperties["AliasName"].Value.ToString();
			}
			txbName.Enabled = txbDescription.Enabled = true;
			uxApplyButton.Enabled = false;

			Cursor.Current = Cursors.Default;
			*/
		}

		private void treeView_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if (this.treeView.SelectedNode != null && this.treeView.SelectedNode is DataObjectTreeNode)
			{
				((DataObjectTreeNode)this.treeView.SelectedNode).Control.Visible = false;
			}

			/*if (e.Node.Tag is ColumnSchema)
			{
				((ColumnSchema)e.Node.Tag).ExtendedProperties["MS_Description"].Value = txbDescription.Text;
			}
			else if (e.Node.Tag is TableSchema)
			{
				((TableSchema)e.Node.Tag).ExtendedProperties["MS_Description"].Value = txbDescription.Text;
				
				if (((ColumnSchema)e.Node.Tag).ExtendedProperties.Contains("AliasName"))
				{
					((ColumnSchema)e.Node.Tag).ExtendedProperties.Remove(("AliasName");					
				}
				
				// readd the expy
				((ColumnSchema)e.Node.Tag).ExtendedProperties.Add(new ExtendedProperty("AliasName", uxAliasTextBox.Text, DbType.String));
				
			}
			*/
		}


		private void uxApplyButton_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			// TODO warn that this will save informations as extended properties

			//SaveExtendedProperties();

//			TreeNode sel = treeView.SelectedNode;
//			
//			if (sel.Tag is TableSchema)
//			{
//				Utilities.SqlXProperties.SaveDescription((TableSchema)sel.Tag, txbDescription.Text);
//				//txbName.Enabled = txbDescription.Enabled = btnSave.Enabled = true;
//			}
//			else if (sel.Tag is ColumnSchema)
//			{
//				Utilities.SqlXProperties.SaveDescription((ColumnSchema)sel.Tag, txbDescription.Text);
//			}
//
//			uxApplyButton.Enabled = false;
//			treeView.Select();

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Saves the extended properties.
		/// </summary>
		public static void SaveExtendedProperties()
		{
			foreach(TableSchema table in Program.Context.SourceDatabase.Tables)
			{
				//SqlXProperties.SetTableProperty(db.ConnectionString, table.Name , "MS_Description", table.Description);
				
				// save properties of the table
				foreach(SchemaExplorer.ExtendedProperty xp in table.ExtendedProperties)
				{
					Utilities.SqlXProperties.SetTableProperty(Program.Context.SourceDatabase.ConnectionString, xp.Name , "MS_Description", xp.Value);
				}

				// loop on column
				foreach(ColumnSchema column in table.Columns)
				{
					//SqlXProperties.SetTableColumnProperty(db.ConnectionString, table.Name , column.Name,"MS_Description", column.Description);
					
					// save properties of the column
					foreach(SchemaExplorer.ExtendedProperty xp in column.ExtendedProperties)
					{
						Utilities.SqlXProperties.SetTableColumnProperty(Program.Context.SourceDatabase.ConnectionString, table.Name , column.Name, xp.Name, xp.Value);
					
					}
				}
			}
		}

		private void uxTableDescriptionTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			uxApplyButton_Click(null, null);
		}

		private void DocumentationControl_Load(object sender, EventArgs e)
		{
			// On lance la methode databind dans un thread a part
			Thread t = new Thread(new ThreadStart(DataBind));
			t.Start();
			this.treeView.Enabled = true;
		}
	

		#region "Thread async"

		public delegate void ThreadEventHandler(object sender, ThreadEventArgs e);


		public class ThreadEventArgs : EventArgs
		{
			Entities.DataObject dataObject;
			public Entities.DataObject DataObject 
			{
				get 
				{
					return this.dataObject;
				}
			}
			public ThreadEventArgs(Entities.DataObject item)
			{
				this.dataObject = item;
			}
		}

		#endregion

		internal class DataObjectTreeNode : System.Windows.Forms.TreeNode
		{

			#region Properties
			private DataObjectControl control;

			public DataObjectControl Control
			{
				get
				{
					return (this.control);
				}
				set
				{
					this.control = value;
				}
			}

			private Entities.DataObject data;

			public Entities.DataObject Data
			{
				get
				{
					return (this.data);
				}
				set
				{
					this.data = value;
				}
			}
			#endregion

			public DataObjectTreeNode(Entities.DataObject data, DataObjectControl control)
			{
				this.data = data;
				this.control = control;

				this.Text = data.Name;

				if (this.data.Type == Entities.DataObjectType.Table)
				{
					this.ImageIndex = 3;
					this.SelectedImageIndex = 3;
				}
				else if (this.data.Type == Entities.DataObjectType.View)
				{
					this.ImageIndex = 4;
					this.SelectedImageIndex = 4;
				}

				this.control.DataBindings.Add("ClassName", this.data, "Name");
				this.control.DataBindings.Add("ClassDescription", this.data, "Description");

			}
		}

	}
}
