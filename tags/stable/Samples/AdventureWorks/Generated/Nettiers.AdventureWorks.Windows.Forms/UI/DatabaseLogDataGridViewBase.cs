
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract DatabaseLog typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class DatabaseLogDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<DatabaseLogDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.DatabaseLog _currentDatabaseLog = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxDatabaseLogDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxDatabaseLogErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxDatabaseLogBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the DatabaseLogId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDatabaseLogIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PostTime property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPostTimeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DatabaseUser property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDatabaseUserDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SafeNameEvent property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSafeNameEventDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Schema property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSchemaDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SafeNameObject property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSafeNameObjectDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Tsql property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTsqlDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the XmlEvent property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxXmlEventDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.DatabaseLog> _DatabaseLogList;
				
		/// <summary> 
		/// The list of DatabaseLog to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.DatabaseLog> DatabaseLogList
		{
			get {return this._DatabaseLogList;}
			set
			{
				this._DatabaseLogList = value;
				this.uxDatabaseLogBindingSource.DataSource = null;
				this.uxDatabaseLogBindingSource.DataSource = value;
				this.uxDatabaseLogDataGridView.DataSource = null;
				this.uxDatabaseLogDataGridView.DataSource = this.uxDatabaseLogBindingSource;				
				//this.uxDatabaseLogBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxDatabaseLogBindingSource_ListChanged);
				this.uxDatabaseLogBindingSource.CurrentItemChanged += new System.EventHandler(OnDatabaseLogBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnDatabaseLogBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentDatabaseLog = uxDatabaseLogBindingSource.Current as Entities.DatabaseLog;
			
			if (_currentDatabaseLog != null)
			{
				_currentDatabaseLog.Validate();
			}
			//_DatabaseLog.Validate();
			OnCurrentEntityChanged();
		}

		//void uxDatabaseLogBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.DatabaseLog"/> instance.
		/// </summary>
		public Entities.DatabaseLog SelectedDatabaseLog
		{
			get {return this._currentDatabaseLog;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxDatabaseLogDataGridView.VirtualMode;}
			set
			{
				this.uxDatabaseLogDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxDatabaseLogDataGridView.AllowUserToAddRows;}
			set {this.uxDatabaseLogDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxDatabaseLogDataGridView.AllowUserToDeleteRows;}
			set {this.uxDatabaseLogDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxDatabaseLogDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxDatabaseLogDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="DatabaseLogDataGridViewBase"/> class.
		/// </summary>
		public DatabaseLogDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxDatabaseLogDataGridView = new System.Windows.Forms.DataGridView();
			this.uxDatabaseLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxDatabaseLogErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxDatabaseLogIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPostTimeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDatabaseUserDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSafeNameEventDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSchemaDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSafeNameObjectDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTsqlDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxXmlEventDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxDatabaseLogDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDatabaseLogBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDatabaseLogErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxDatabaseLogErrorProvider
			// 
			this.uxDatabaseLogErrorProvider.ContainerControl = this;
			this.uxDatabaseLogErrorProvider.DataSource = this.uxDatabaseLogBindingSource;						
			// 
			// uxDatabaseLogDataGridView
			// 
			this.uxDatabaseLogDataGridView.AutoGenerateColumns = false;
			this.uxDatabaseLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxDatabaseLogDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxDatabaseLogIdDataGridViewColumn,
		this.uxPostTimeDataGridViewColumn,
		this.uxDatabaseUserDataGridViewColumn,
		this.uxSafeNameEventDataGridViewColumn,
		this.uxSchemaDataGridViewColumn,
		this.uxSafeNameObjectDataGridViewColumn,
		this.uxTsqlDataGridViewColumn,
		this.uxXmlEventDataGridViewColumn			});
			this.uxDatabaseLogDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxDatabaseLogDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxDatabaseLogDataGridView.Name = "uxDatabaseLogDataGridView";
			this.uxDatabaseLogDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxDatabaseLogDataGridView.TabIndex = 0;	
			this.uxDatabaseLogDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxDatabaseLogDataGridView.EnableHeadersVisualStyles = false;
			this.uxDatabaseLogDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDatabaseLogDataGridViewDataError);
			this.uxDatabaseLogDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnDatabaseLogDataGridViewCellValueNeeded);
			this.uxDatabaseLogDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnDatabaseLogDataGridViewCellValuePushed);
			
			//
			// uxDatabaseLogIdDataGridViewColumn
			//
			this.uxDatabaseLogIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDatabaseLogIdDataGridViewColumn.DataPropertyName = "DatabaseLogId";
			this.uxDatabaseLogIdDataGridViewColumn.HeaderText = "DatabaseLogId";
			this.uxDatabaseLogIdDataGridViewColumn.Name = "uxDatabaseLogIdDataGridViewColumn";
			this.uxDatabaseLogIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDatabaseLogIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDatabaseLogIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxPostTimeDataGridViewColumn
			//
			this.uxPostTimeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPostTimeDataGridViewColumn.DataPropertyName = "PostTime";
			this.uxPostTimeDataGridViewColumn.HeaderText = "PostTime";
			this.uxPostTimeDataGridViewColumn.Name = "uxPostTimeDataGridViewColumn";
			this.uxPostTimeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPostTimeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPostTimeDataGridViewColumn.ReadOnly = false;		
			//
			// uxDatabaseUserDataGridViewColumn
			//
			this.uxDatabaseUserDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDatabaseUserDataGridViewColumn.DataPropertyName = "DatabaseUser";
			this.uxDatabaseUserDataGridViewColumn.HeaderText = "DatabaseUser";
			this.uxDatabaseUserDataGridViewColumn.Name = "uxDatabaseUserDataGridViewColumn";
			this.uxDatabaseUserDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDatabaseUserDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDatabaseUserDataGridViewColumn.ReadOnly = false;		
			//
			// uxSafeNameEventDataGridViewColumn
			//
			this.uxSafeNameEventDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSafeNameEventDataGridViewColumn.DataPropertyName = "SafeNameEvent";
			this.uxSafeNameEventDataGridViewColumn.HeaderText = "SafeNameEvent";
			this.uxSafeNameEventDataGridViewColumn.Name = "uxSafeNameEventDataGridViewColumn";
			this.uxSafeNameEventDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSafeNameEventDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSafeNameEventDataGridViewColumn.ReadOnly = false;		
			//
			// uxSchemaDataGridViewColumn
			//
			this.uxSchemaDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSchemaDataGridViewColumn.DataPropertyName = "Schema";
			this.uxSchemaDataGridViewColumn.HeaderText = "Schema";
			this.uxSchemaDataGridViewColumn.Name = "uxSchemaDataGridViewColumn";
			this.uxSchemaDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSchemaDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSchemaDataGridViewColumn.ReadOnly = false;		
			//
			// uxSafeNameObjectDataGridViewColumn
			//
			this.uxSafeNameObjectDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSafeNameObjectDataGridViewColumn.DataPropertyName = "SafeNameObject";
			this.uxSafeNameObjectDataGridViewColumn.HeaderText = "SafeNameObject";
			this.uxSafeNameObjectDataGridViewColumn.Name = "uxSafeNameObjectDataGridViewColumn";
			this.uxSafeNameObjectDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSafeNameObjectDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSafeNameObjectDataGridViewColumn.ReadOnly = false;		
			//
			// uxTsqlDataGridViewColumn
			//
			this.uxTsqlDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTsqlDataGridViewColumn.DataPropertyName = "Tsql";
			this.uxTsqlDataGridViewColumn.HeaderText = "Tsql";
			this.uxTsqlDataGridViewColumn.Name = "uxTsqlDataGridViewColumn";
			this.uxTsqlDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTsqlDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTsqlDataGridViewColumn.ReadOnly = false;		
			//
			// uxXmlEventDataGridViewColumn
			//
			this.uxXmlEventDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxXmlEventDataGridViewColumn.DataPropertyName = "XmlEvent";
			this.uxXmlEventDataGridViewColumn.HeaderText = "XmlEvent";
			this.uxXmlEventDataGridViewColumn.Name = "uxXmlEventDataGridViewColumn";
			this.uxXmlEventDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxXmlEventDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxXmlEventDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxDatabaseLogDataGridView);
			this.Name = "DatabaseLogDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxDatabaseLogErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDatabaseLogDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDatabaseLogBindingSource)).EndInit();
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
				DatabaseLogDataGridViewEventArgs args = new DatabaseLogDataGridViewEventArgs();
				args.DatabaseLog = _currentDatabaseLog;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class DatabaseLogDataGridViewEventArgs : System.EventArgs
		{
			private Entities.DatabaseLog	_DatabaseLog;
	
			/// <summary>
			/// the  Entities.DatabaseLog instance.
			/// </summary>
			public Entities.DatabaseLog DatabaseLog
			{
				get { return _DatabaseLog; }
				set { _DatabaseLog = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxDatabaseLogDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnDatabaseLogDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxDatabaseLogDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnDatabaseLogDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxDatabaseLogDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxDatabaseLogIdDataGridViewColumn":
						e.Value = DatabaseLogList[e.RowIndex].DatabaseLogId;
						break;
					case "uxPostTimeDataGridViewColumn":
						e.Value = DatabaseLogList[e.RowIndex].PostTime;
						break;
					case "uxDatabaseUserDataGridViewColumn":
						e.Value = DatabaseLogList[e.RowIndex].DatabaseUser;
						break;
					case "uxSafeNameEventDataGridViewColumn":
						e.Value = DatabaseLogList[e.RowIndex].SafeNameEvent;
						break;
					case "uxSchemaDataGridViewColumn":
						e.Value = DatabaseLogList[e.RowIndex].Schema;
						break;
					case "uxSafeNameObjectDataGridViewColumn":
						e.Value = DatabaseLogList[e.RowIndex].SafeNameObject;
						break;
					case "uxTsqlDataGridViewColumn":
						e.Value = DatabaseLogList[e.RowIndex].Tsql;
						break;
					case "uxXmlEventDataGridViewColumn":
						e.Value = DatabaseLogList[e.RowIndex].XmlEvent;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxDatabaseLogDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnDatabaseLogDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxDatabaseLogDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxDatabaseLogIdDataGridViewColumn":
						DatabaseLogList[e.RowIndex].DatabaseLogId = (System.Int32)e.Value;
						break;
					case "uxPostTimeDataGridViewColumn":
						DatabaseLogList[e.RowIndex].PostTime = (System.DateTime)e.Value;
						break;
					case "uxDatabaseUserDataGridViewColumn":
						DatabaseLogList[e.RowIndex].DatabaseUser = (System.String)e.Value;
						break;
					case "uxSafeNameEventDataGridViewColumn":
						DatabaseLogList[e.RowIndex].SafeNameEvent = (System.String)e.Value;
						break;
					case "uxSchemaDataGridViewColumn":
						DatabaseLogList[e.RowIndex].Schema = (System.String)e.Value;
						break;
					case "uxSafeNameObjectDataGridViewColumn":
						DatabaseLogList[e.RowIndex].SafeNameObject = (System.String)e.Value;
						break;
					case "uxTsqlDataGridViewColumn":
						DatabaseLogList[e.RowIndex].Tsql = (System.String)e.Value;
						break;
					case "uxXmlEventDataGridViewColumn":
						DatabaseLogList[e.RowIndex].XmlEvent = (string)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
