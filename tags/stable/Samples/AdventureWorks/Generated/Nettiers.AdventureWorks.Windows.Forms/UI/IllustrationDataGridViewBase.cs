
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Illustration typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class IllustrationDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<IllustrationDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Illustration _currentIllustration = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxIllustrationDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxIllustrationErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxIllustrationBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the IllustrationId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIllustrationIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Diagram property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDiagramDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Illustration> _IllustrationList;
				
		/// <summary> 
		/// The list of Illustration to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Illustration> IllustrationList
		{
			get {return this._IllustrationList;}
			set
			{
				this._IllustrationList = value;
				this.uxIllustrationBindingSource.DataSource = null;
				this.uxIllustrationBindingSource.DataSource = value;
				this.uxIllustrationDataGridView.DataSource = null;
				this.uxIllustrationDataGridView.DataSource = this.uxIllustrationBindingSource;				
				//this.uxIllustrationBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxIllustrationBindingSource_ListChanged);
				this.uxIllustrationBindingSource.CurrentItemChanged += new System.EventHandler(OnIllustrationBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnIllustrationBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentIllustration = uxIllustrationBindingSource.Current as Entities.Illustration;
			
			if (_currentIllustration != null)
			{
				_currentIllustration.Validate();
			}
			//_Illustration.Validate();
			OnCurrentEntityChanged();
		}

		//void uxIllustrationBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Illustration"/> instance.
		/// </summary>
		public Entities.Illustration SelectedIllustration
		{
			get {return this._currentIllustration;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxIllustrationDataGridView.VirtualMode;}
			set
			{
				this.uxIllustrationDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxIllustrationDataGridView.AllowUserToAddRows;}
			set {this.uxIllustrationDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxIllustrationDataGridView.AllowUserToDeleteRows;}
			set {this.uxIllustrationDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxIllustrationDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxIllustrationDataGridView.Columns; }
		}
		
		#endregion
		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	
		#region Constructor
	
		/// <summary>
		/// Initializes a new instance of the <see cref="IllustrationDataGridViewBase"/> class.
		/// </summary>
		public IllustrationDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxIllustrationDataGridView = new System.Windows.Forms.DataGridView();
			this.uxIllustrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxIllustrationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIllustrationIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDiagramDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxIllustrationDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIllustrationBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIllustrationErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxIllustrationErrorProvider
			// 
			this.uxIllustrationErrorProvider.ContainerControl = this;
			this.uxIllustrationErrorProvider.DataSource = this.uxIllustrationBindingSource;						
			// 
			// uxIllustrationDataGridView
			// 
			this.uxIllustrationDataGridView.AutoGenerateColumns = false;
			this.uxIllustrationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxIllustrationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIllustrationIdDataGridViewColumn,
		this.uxDiagramDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxIllustrationDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxIllustrationDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxIllustrationDataGridView.Name = "uxIllustrationDataGridView";
			this.uxIllustrationDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxIllustrationDataGridView.TabIndex = 0;	
			this.uxIllustrationDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxIllustrationDataGridView.EnableHeadersVisualStyles = false;
			this.uxIllustrationDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnIllustrationDataGridViewDataError);
			this.uxIllustrationDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnIllustrationDataGridViewCellValueNeeded);
			this.uxIllustrationDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnIllustrationDataGridViewCellValuePushed);
			
			//
			// uxIllustrationIdDataGridViewColumn
			//
			this.uxIllustrationIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIllustrationIdDataGridViewColumn.DataPropertyName = "IllustrationId";
			this.uxIllustrationIdDataGridViewColumn.HeaderText = "IllustrationId";
			this.uxIllustrationIdDataGridViewColumn.Name = "uxIllustrationIdDataGridViewColumn";
			this.uxIllustrationIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIllustrationIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIllustrationIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxDiagramDataGridViewColumn
			//
			this.uxDiagramDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDiagramDataGridViewColumn.DataPropertyName = "Diagram";
			this.uxDiagramDataGridViewColumn.HeaderText = "Diagram";
			this.uxDiagramDataGridViewColumn.Name = "uxDiagramDataGridViewColumn";
			this.uxDiagramDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDiagramDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDiagramDataGridViewColumn.ReadOnly = false;		
			//
			// uxModifiedDateDataGridViewColumn
			//
			this.uxModifiedDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxModifiedDateDataGridViewColumn.DataPropertyName = "ModifiedDate";
			this.uxModifiedDateDataGridViewColumn.HeaderText = "ModifiedDate";
			this.uxModifiedDateDataGridViewColumn.Name = "uxModifiedDateDataGridViewColumn";
			this.uxModifiedDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxModifiedDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxModifiedDateDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxIllustrationDataGridView);
			this.Name = "IllustrationDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxIllustrationErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIllustrationDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIllustrationBindingSource)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
				
		#region events
		
		/// <summary>
		/// Raised the CurrentEntityChanged event.
		/// </summary>
		protected void OnCurrentEntityChanged()
		{
			if (CurrentEntityChanged != null)
			{
				IllustrationDataGridViewEventArgs args = new IllustrationDataGridViewEventArgs();
				args.Illustration = _currentIllustration;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class IllustrationDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Illustration	_Illustration;
	
			/// <summary>
			/// the  Entities.Illustration instance.
			/// </summary>
			public Entities.Illustration Illustration
			{
				get { return _Illustration; }
				set { _Illustration = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxIllustrationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnIllustrationDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxIllustrationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnIllustrationDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxIllustrationDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIllustrationIdDataGridViewColumn":
						e.Value = IllustrationList[e.RowIndex].IllustrationId;
						break;
					case "uxDiagramDataGridViewColumn":
						e.Value = IllustrationList[e.RowIndex].Diagram;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = IllustrationList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxIllustrationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnIllustrationDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxIllustrationDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIllustrationIdDataGridViewColumn":
						IllustrationList[e.RowIndex].IllustrationId = (System.Int32)e.Value;
						break;
					case "uxDiagramDataGridViewColumn":
						IllustrationList[e.RowIndex].Diagram = (string)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						IllustrationList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
