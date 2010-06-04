
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ErrorLog typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ErrorLogDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ErrorLogDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ErrorLog _currentErrorLog = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxErrorLogDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxErrorLogErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxErrorLogBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ErrorLogId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxErrorLogIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ErrorTime property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxErrorTimeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UserName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUserNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ErrorNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxErrorNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ErrorSeverity property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxErrorSeverityDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ErrorState property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxErrorStateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ErrorProcedure property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxErrorProcedureDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ErrorLine property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxErrorLineDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ErrorMessage property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxErrorMessageDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ErrorLog> _ErrorLogList;
				
		/// <summary> 
		/// The list of ErrorLog to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ErrorLog> ErrorLogList
		{
			get {return this._ErrorLogList;}
			set
			{
				this._ErrorLogList = value;
				this.uxErrorLogBindingSource.DataSource = null;
				this.uxErrorLogBindingSource.DataSource = value;
				this.uxErrorLogDataGridView.DataSource = null;
				this.uxErrorLogDataGridView.DataSource = this.uxErrorLogBindingSource;				
				//this.uxErrorLogBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxErrorLogBindingSource_ListChanged);
				this.uxErrorLogBindingSource.CurrentItemChanged += new System.EventHandler(OnErrorLogBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnErrorLogBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentErrorLog = uxErrorLogBindingSource.Current as Entities.ErrorLog;
			
			if (_currentErrorLog != null)
			{
				_currentErrorLog.Validate();
			}
			//_ErrorLog.Validate();
			OnCurrentEntityChanged();
		}

		//void uxErrorLogBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ErrorLog"/> instance.
		/// </summary>
		public Entities.ErrorLog SelectedErrorLog
		{
			get {return this._currentErrorLog;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxErrorLogDataGridView.VirtualMode;}
			set
			{
				this.uxErrorLogDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxErrorLogDataGridView.AllowUserToAddRows;}
			set {this.uxErrorLogDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxErrorLogDataGridView.AllowUserToDeleteRows;}
			set {this.uxErrorLogDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxErrorLogDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxErrorLogDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ErrorLogDataGridViewBase"/> class.
		/// </summary>
		public ErrorLogDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxErrorLogDataGridView = new System.Windows.Forms.DataGridView();
			this.uxErrorLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxErrorLogErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxErrorLogIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxErrorTimeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUserNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxErrorNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxErrorSeverityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxErrorStateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxErrorProcedureDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxErrorLineDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxErrorMessageDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorLogDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorLogBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorLogErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxErrorLogErrorProvider
			// 
			this.uxErrorLogErrorProvider.ContainerControl = this;
			this.uxErrorLogErrorProvider.DataSource = this.uxErrorLogBindingSource;						
			// 
			// uxErrorLogDataGridView
			// 
			this.uxErrorLogDataGridView.AutoGenerateColumns = false;
			this.uxErrorLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxErrorLogDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxErrorLogIdDataGridViewColumn,
		this.uxErrorTimeDataGridViewColumn,
		this.uxUserNameDataGridViewColumn,
		this.uxErrorNumberDataGridViewColumn,
		this.uxErrorSeverityDataGridViewColumn,
		this.uxErrorStateDataGridViewColumn,
		this.uxErrorProcedureDataGridViewColumn,
		this.uxErrorLineDataGridViewColumn,
		this.uxErrorMessageDataGridViewColumn			});
			this.uxErrorLogDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxErrorLogDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxErrorLogDataGridView.Name = "uxErrorLogDataGridView";
			this.uxErrorLogDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxErrorLogDataGridView.TabIndex = 0;	
			this.uxErrorLogDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxErrorLogDataGridView.EnableHeadersVisualStyles = false;
			this.uxErrorLogDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnErrorLogDataGridViewDataError);
			this.uxErrorLogDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnErrorLogDataGridViewCellValueNeeded);
			this.uxErrorLogDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnErrorLogDataGridViewCellValuePushed);
			
			//
			// uxErrorLogIdDataGridViewColumn
			//
			this.uxErrorLogIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxErrorLogIdDataGridViewColumn.DataPropertyName = "ErrorLogId";
			this.uxErrorLogIdDataGridViewColumn.HeaderText = "ErrorLogId";
			this.uxErrorLogIdDataGridViewColumn.Name = "uxErrorLogIdDataGridViewColumn";
			this.uxErrorLogIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxErrorLogIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxErrorLogIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxErrorTimeDataGridViewColumn
			//
			this.uxErrorTimeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxErrorTimeDataGridViewColumn.DataPropertyName = "ErrorTime";
			this.uxErrorTimeDataGridViewColumn.HeaderText = "ErrorTime";
			this.uxErrorTimeDataGridViewColumn.Name = "uxErrorTimeDataGridViewColumn";
			this.uxErrorTimeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxErrorTimeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxErrorTimeDataGridViewColumn.ReadOnly = false;		
			//
			// uxUserNameDataGridViewColumn
			//
			this.uxUserNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUserNameDataGridViewColumn.DataPropertyName = "UserName";
			this.uxUserNameDataGridViewColumn.HeaderText = "UserName";
			this.uxUserNameDataGridViewColumn.Name = "uxUserNameDataGridViewColumn";
			this.uxUserNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUserNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUserNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxErrorNumberDataGridViewColumn
			//
			this.uxErrorNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxErrorNumberDataGridViewColumn.DataPropertyName = "ErrorNumber";
			this.uxErrorNumberDataGridViewColumn.HeaderText = "ErrorNumber";
			this.uxErrorNumberDataGridViewColumn.Name = "uxErrorNumberDataGridViewColumn";
			this.uxErrorNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxErrorNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxErrorNumberDataGridViewColumn.ReadOnly = false;		
			//
			// uxErrorSeverityDataGridViewColumn
			//
			this.uxErrorSeverityDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxErrorSeverityDataGridViewColumn.DataPropertyName = "ErrorSeverity";
			this.uxErrorSeverityDataGridViewColumn.HeaderText = "ErrorSeverity";
			this.uxErrorSeverityDataGridViewColumn.Name = "uxErrorSeverityDataGridViewColumn";
			this.uxErrorSeverityDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxErrorSeverityDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxErrorSeverityDataGridViewColumn.ReadOnly = false;		
			//
			// uxErrorStateDataGridViewColumn
			//
			this.uxErrorStateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxErrorStateDataGridViewColumn.DataPropertyName = "ErrorState";
			this.uxErrorStateDataGridViewColumn.HeaderText = "ErrorState";
			this.uxErrorStateDataGridViewColumn.Name = "uxErrorStateDataGridViewColumn";
			this.uxErrorStateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxErrorStateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxErrorStateDataGridViewColumn.ReadOnly = false;		
			//
			// uxErrorProcedureDataGridViewColumn
			//
			this.uxErrorProcedureDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxErrorProcedureDataGridViewColumn.DataPropertyName = "ErrorProcedure";
			this.uxErrorProcedureDataGridViewColumn.HeaderText = "ErrorProcedure";
			this.uxErrorProcedureDataGridViewColumn.Name = "uxErrorProcedureDataGridViewColumn";
			this.uxErrorProcedureDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxErrorProcedureDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxErrorProcedureDataGridViewColumn.ReadOnly = false;		
			//
			// uxErrorLineDataGridViewColumn
			//
			this.uxErrorLineDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxErrorLineDataGridViewColumn.DataPropertyName = "ErrorLine";
			this.uxErrorLineDataGridViewColumn.HeaderText = "ErrorLine";
			this.uxErrorLineDataGridViewColumn.Name = "uxErrorLineDataGridViewColumn";
			this.uxErrorLineDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxErrorLineDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxErrorLineDataGridViewColumn.ReadOnly = false;		
			//
			// uxErrorMessageDataGridViewColumn
			//
			this.uxErrorMessageDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxErrorMessageDataGridViewColumn.DataPropertyName = "ErrorMessage";
			this.uxErrorMessageDataGridViewColumn.HeaderText = "ErrorMessage";
			this.uxErrorMessageDataGridViewColumn.Name = "uxErrorMessageDataGridViewColumn";
			this.uxErrorMessageDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxErrorMessageDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxErrorMessageDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxErrorLogDataGridView);
			this.Name = "ErrorLogDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxErrorLogErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorLogDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorLogBindingSource)).EndInit();
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
				ErrorLogDataGridViewEventArgs args = new ErrorLogDataGridViewEventArgs();
				args.ErrorLog = _currentErrorLog;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ErrorLogDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ErrorLog	_ErrorLog;
	
			/// <summary>
			/// the  Entities.ErrorLog instance.
			/// </summary>
			public Entities.ErrorLog ErrorLog
			{
				get { return _ErrorLog; }
				set { _ErrorLog = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxErrorLogDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnErrorLogDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxErrorLogDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnErrorLogDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxErrorLogDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxErrorLogIdDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].ErrorLogId;
						break;
					case "uxErrorTimeDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].ErrorTime;
						break;
					case "uxUserNameDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].UserName;
						break;
					case "uxErrorNumberDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].ErrorNumber;
						break;
					case "uxErrorSeverityDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].ErrorSeverity;
						break;
					case "uxErrorStateDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].ErrorState;
						break;
					case "uxErrorProcedureDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].ErrorProcedure;
						break;
					case "uxErrorLineDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].ErrorLine;
						break;
					case "uxErrorMessageDataGridViewColumn":
						e.Value = ErrorLogList[e.RowIndex].ErrorMessage;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxErrorLogDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnErrorLogDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxErrorLogDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxErrorLogIdDataGridViewColumn":
						ErrorLogList[e.RowIndex].ErrorLogId = (System.Int32)e.Value;
						break;
					case "uxErrorTimeDataGridViewColumn":
						ErrorLogList[e.RowIndex].ErrorTime = (System.DateTime)e.Value;
						break;
					case "uxUserNameDataGridViewColumn":
						ErrorLogList[e.RowIndex].UserName = (System.String)e.Value;
						break;
					case "uxErrorNumberDataGridViewColumn":
						ErrorLogList[e.RowIndex].ErrorNumber = (System.Int32)e.Value;
						break;
					case "uxErrorSeverityDataGridViewColumn":
						ErrorLogList[e.RowIndex].ErrorSeverity = (System.Int32?)e.Value;
						break;
					case "uxErrorStateDataGridViewColumn":
						ErrorLogList[e.RowIndex].ErrorState = (System.Int32?)e.Value;
						break;
					case "uxErrorProcedureDataGridViewColumn":
						ErrorLogList[e.RowIndex].ErrorProcedure = (System.String)e.Value;
						break;
					case "uxErrorLineDataGridViewColumn":
						ErrorLogList[e.RowIndex].ErrorLine = (System.Int32?)e.Value;
						break;
					case "uxErrorMessageDataGridViewColumn":
						ErrorLogList[e.RowIndex].ErrorMessage = (System.String)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
