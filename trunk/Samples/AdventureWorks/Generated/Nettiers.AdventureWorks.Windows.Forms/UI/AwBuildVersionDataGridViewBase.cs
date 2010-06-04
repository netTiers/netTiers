
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract AwBuildVersion typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class AwBuildVersionDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<AwBuildVersionDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.AwBuildVersion _currentAwBuildVersion = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxAwBuildVersionDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxAwBuildVersionErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxAwBuildVersionBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the SystemInformationId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSystemInformationIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DatabaseVersion property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDatabaseVersionDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the VersionDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxVersionDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.AwBuildVersion> _AwBuildVersionList;
				
		/// <summary> 
		/// The list of AwBuildVersion to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.AwBuildVersion> AwBuildVersionList
		{
			get {return this._AwBuildVersionList;}
			set
			{
				this._AwBuildVersionList = value;
				this.uxAwBuildVersionBindingSource.DataSource = null;
				this.uxAwBuildVersionBindingSource.DataSource = value;
				this.uxAwBuildVersionDataGridView.DataSource = null;
				this.uxAwBuildVersionDataGridView.DataSource = this.uxAwBuildVersionBindingSource;				
				//this.uxAwBuildVersionBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxAwBuildVersionBindingSource_ListChanged);
				this.uxAwBuildVersionBindingSource.CurrentItemChanged += new System.EventHandler(OnAwBuildVersionBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnAwBuildVersionBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentAwBuildVersion = uxAwBuildVersionBindingSource.Current as Entities.AwBuildVersion;
			
			if (_currentAwBuildVersion != null)
			{
				_currentAwBuildVersion.Validate();
			}
			//_AwBuildVersion.Validate();
			OnCurrentEntityChanged();
		}

		//void uxAwBuildVersionBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.AwBuildVersion"/> instance.
		/// </summary>
		public Entities.AwBuildVersion SelectedAwBuildVersion
		{
			get {return this._currentAwBuildVersion;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxAwBuildVersionDataGridView.VirtualMode;}
			set
			{
				this.uxAwBuildVersionDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxAwBuildVersionDataGridView.AllowUserToAddRows;}
			set {this.uxAwBuildVersionDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxAwBuildVersionDataGridView.AllowUserToDeleteRows;}
			set {this.uxAwBuildVersionDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxAwBuildVersionDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxAwBuildVersionDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="AwBuildVersionDataGridViewBase"/> class.
		/// </summary>
		public AwBuildVersionDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxAwBuildVersionDataGridView = new System.Windows.Forms.DataGridView();
			this.uxAwBuildVersionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxAwBuildVersionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSystemInformationIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDatabaseVersionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxVersionDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxAwBuildVersionDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAwBuildVersionBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAwBuildVersionErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxAwBuildVersionErrorProvider
			// 
			this.uxAwBuildVersionErrorProvider.ContainerControl = this;
			this.uxAwBuildVersionErrorProvider.DataSource = this.uxAwBuildVersionBindingSource;						
			// 
			// uxAwBuildVersionDataGridView
			// 
			this.uxAwBuildVersionDataGridView.AutoGenerateColumns = false;
			this.uxAwBuildVersionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxAwBuildVersionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSystemInformationIdDataGridViewColumn,
		this.uxDatabaseVersionDataGridViewColumn,
		this.uxVersionDateDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxAwBuildVersionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxAwBuildVersionDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxAwBuildVersionDataGridView.Name = "uxAwBuildVersionDataGridView";
			this.uxAwBuildVersionDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxAwBuildVersionDataGridView.TabIndex = 0;	
			this.uxAwBuildVersionDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxAwBuildVersionDataGridView.EnableHeadersVisualStyles = false;
			this.uxAwBuildVersionDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnAwBuildVersionDataGridViewDataError);
			this.uxAwBuildVersionDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnAwBuildVersionDataGridViewCellValueNeeded);
			this.uxAwBuildVersionDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnAwBuildVersionDataGridViewCellValuePushed);
			
			//
			// uxSystemInformationIdDataGridViewColumn
			//
			this.uxSystemInformationIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSystemInformationIdDataGridViewColumn.DataPropertyName = "SystemInformationId";
			this.uxSystemInformationIdDataGridViewColumn.HeaderText = "SystemInformationId";
			this.uxSystemInformationIdDataGridViewColumn.Name = "uxSystemInformationIdDataGridViewColumn";
			this.uxSystemInformationIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSystemInformationIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSystemInformationIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxDatabaseVersionDataGridViewColumn
			//
			this.uxDatabaseVersionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDatabaseVersionDataGridViewColumn.DataPropertyName = "DatabaseVersion";
			this.uxDatabaseVersionDataGridViewColumn.HeaderText = "DatabaseVersion";
			this.uxDatabaseVersionDataGridViewColumn.Name = "uxDatabaseVersionDataGridViewColumn";
			this.uxDatabaseVersionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDatabaseVersionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDatabaseVersionDataGridViewColumn.ReadOnly = false;		
			//
			// uxVersionDateDataGridViewColumn
			//
			this.uxVersionDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxVersionDateDataGridViewColumn.DataPropertyName = "VersionDate";
			this.uxVersionDateDataGridViewColumn.HeaderText = "VersionDate";
			this.uxVersionDateDataGridViewColumn.Name = "uxVersionDateDataGridViewColumn";
			this.uxVersionDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxVersionDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxVersionDateDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxAwBuildVersionDataGridView);
			this.Name = "AwBuildVersionDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxAwBuildVersionErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAwBuildVersionDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAwBuildVersionBindingSource)).EndInit();
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
				AwBuildVersionDataGridViewEventArgs args = new AwBuildVersionDataGridViewEventArgs();
				args.AwBuildVersion = _currentAwBuildVersion;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class AwBuildVersionDataGridViewEventArgs : System.EventArgs
		{
			private Entities.AwBuildVersion	_AwBuildVersion;
	
			/// <summary>
			/// the  Entities.AwBuildVersion instance.
			/// </summary>
			public Entities.AwBuildVersion AwBuildVersion
			{
				get { return _AwBuildVersion; }
				set { _AwBuildVersion = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxAwBuildVersionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnAwBuildVersionDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxAwBuildVersionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnAwBuildVersionDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxAwBuildVersionDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSystemInformationIdDataGridViewColumn":
						e.Value = AwBuildVersionList[e.RowIndex].SystemInformationId;
						break;
					case "uxDatabaseVersionDataGridViewColumn":
						e.Value = AwBuildVersionList[e.RowIndex].DatabaseVersion;
						break;
					case "uxVersionDateDataGridViewColumn":
						e.Value = AwBuildVersionList[e.RowIndex].VersionDate;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = AwBuildVersionList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxAwBuildVersionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnAwBuildVersionDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxAwBuildVersionDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSystemInformationIdDataGridViewColumn":
						AwBuildVersionList[e.RowIndex].SystemInformationId = (System.Byte)e.Value;
						break;
					case "uxDatabaseVersionDataGridViewColumn":
						AwBuildVersionList[e.RowIndex].DatabaseVersion = (System.String)e.Value;
						break;
					case "uxVersionDateDataGridViewColumn":
						AwBuildVersionList[e.RowIndex].VersionDate = (System.DateTime)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						AwBuildVersionList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
