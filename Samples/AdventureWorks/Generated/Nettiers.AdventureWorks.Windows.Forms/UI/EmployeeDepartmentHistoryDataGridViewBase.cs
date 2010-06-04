
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract EmployeeDepartmentHistory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class EmployeeDepartmentHistoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<EmployeeDepartmentHistoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.EmployeeDepartmentHistory _currentEmployeeDepartmentHistory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxEmployeeDepartmentHistoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxEmployeeDepartmentHistoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxEmployeeDepartmentHistoryBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the EmployeeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxEmployeeIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the DepartmentId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxDepartmentIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ShiftId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxShiftIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEndDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Department> _DepartmentIdList;
		
		/// <summary> 
		/// The list of selectable Department
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Department> DepartmentIdList
		{
			get {return this._DepartmentIdList;}
			set 
			{
				this._DepartmentIdList = value;
				this.uxDepartmentIdDataGridViewColumn.DataSource = null;
				this.uxDepartmentIdDataGridViewColumn.DataSource = this._DepartmentIdList;
			}
		}
		
		private bool _allowNewItemInDepartmentIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Department
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInDepartmentIdList
		{
			get { return _allowNewItemInDepartmentIdList;}
			set
			{
				this._allowNewItemInDepartmentIdList = value;
				this.uxDepartmentIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Employee> _EmployeeIdList;
		
		/// <summary> 
		/// The list of selectable Employee
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Employee> EmployeeIdList
		{
			get {return this._EmployeeIdList;}
			set 
			{
				this._EmployeeIdList = value;
				this.uxEmployeeIdDataGridViewColumn.DataSource = null;
				this.uxEmployeeIdDataGridViewColumn.DataSource = this._EmployeeIdList;
			}
		}
		
		private bool _allowNewItemInEmployeeIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Employee
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInEmployeeIdList
		{
			get { return _allowNewItemInEmployeeIdList;}
			set
			{
				this._allowNewItemInEmployeeIdList = value;
				this.uxEmployeeIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Shift> _ShiftIdList;
		
		/// <summary> 
		/// The list of selectable Shift
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Shift> ShiftIdList
		{
			get {return this._ShiftIdList;}
			set 
			{
				this._ShiftIdList = value;
				this.uxShiftIdDataGridViewColumn.DataSource = null;
				this.uxShiftIdDataGridViewColumn.DataSource = this._ShiftIdList;
			}
		}
		
		private bool _allowNewItemInShiftIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Shift
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInShiftIdList
		{
			get { return _allowNewItemInShiftIdList;}
			set
			{
				this._allowNewItemInShiftIdList = value;
				this.uxShiftIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.EmployeeDepartmentHistory> _EmployeeDepartmentHistoryList;
				
		/// <summary> 
		/// The list of EmployeeDepartmentHistory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.EmployeeDepartmentHistory> EmployeeDepartmentHistoryList
		{
			get {return this._EmployeeDepartmentHistoryList;}
			set
			{
				this._EmployeeDepartmentHistoryList = value;
				this.uxEmployeeDepartmentHistoryBindingSource.DataSource = null;
				this.uxEmployeeDepartmentHistoryBindingSource.DataSource = value;
				this.uxEmployeeDepartmentHistoryDataGridView.DataSource = null;
				this.uxEmployeeDepartmentHistoryDataGridView.DataSource = this.uxEmployeeDepartmentHistoryBindingSource;				
				//this.uxEmployeeDepartmentHistoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxEmployeeDepartmentHistoryBindingSource_ListChanged);
				this.uxEmployeeDepartmentHistoryBindingSource.CurrentItemChanged += new System.EventHandler(OnEmployeeDepartmentHistoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnEmployeeDepartmentHistoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentEmployeeDepartmentHistory = uxEmployeeDepartmentHistoryBindingSource.Current as Entities.EmployeeDepartmentHistory;
			
			if (_currentEmployeeDepartmentHistory != null)
			{
				_currentEmployeeDepartmentHistory.Validate();
			}
			//_EmployeeDepartmentHistory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxEmployeeDepartmentHistoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.EmployeeDepartmentHistory"/> instance.
		/// </summary>
		public Entities.EmployeeDepartmentHistory SelectedEmployeeDepartmentHistory
		{
			get {return this._currentEmployeeDepartmentHistory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxEmployeeDepartmentHistoryDataGridView.VirtualMode;}
			set
			{
				this.uxEmployeeDepartmentHistoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxEmployeeDepartmentHistoryDataGridView.AllowUserToAddRows;}
			set {this.uxEmployeeDepartmentHistoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxEmployeeDepartmentHistoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxEmployeeDepartmentHistoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxEmployeeDepartmentHistoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxEmployeeDepartmentHistoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="EmployeeDepartmentHistoryDataGridViewBase"/> class.
		/// </summary>
		public EmployeeDepartmentHistoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxEmployeeDepartmentHistoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxEmployeeDepartmentHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxEmployeeDepartmentHistoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxEmployeeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxDepartmentIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxShiftIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxDepartmentIdBindingSource = new DepartmentBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxDepartmentIdBindingSource)).BeginInit();
			//this.uxEmployeeIdBindingSource = new EmployeeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).BeginInit();
			//this.uxShiftIdBindingSource = new ShiftBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxShiftIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDepartmentHistoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDepartmentHistoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDepartmentHistoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxEmployeeDepartmentHistoryErrorProvider
			// 
			this.uxEmployeeDepartmentHistoryErrorProvider.ContainerControl = this;
			this.uxEmployeeDepartmentHistoryErrorProvider.DataSource = this.uxEmployeeDepartmentHistoryBindingSource;						
			// 
			// uxEmployeeDepartmentHistoryDataGridView
			// 
			this.uxEmployeeDepartmentHistoryDataGridView.AutoGenerateColumns = false;
			this.uxEmployeeDepartmentHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxEmployeeDepartmentHistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxEmployeeIdDataGridViewColumn,
		this.uxDepartmentIdDataGridViewColumn,
		this.uxShiftIdDataGridViewColumn,
		this.uxStartDateDataGridViewColumn,
		this.uxEndDateDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxEmployeeDepartmentHistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxEmployeeDepartmentHistoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxEmployeeDepartmentHistoryDataGridView.Name = "uxEmployeeDepartmentHistoryDataGridView";
			this.uxEmployeeDepartmentHistoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxEmployeeDepartmentHistoryDataGridView.TabIndex = 0;	
			this.uxEmployeeDepartmentHistoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxEmployeeDepartmentHistoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxEmployeeDepartmentHistoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnEmployeeDepartmentHistoryDataGridViewDataError);
			this.uxEmployeeDepartmentHistoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeeDepartmentHistoryDataGridViewCellValueNeeded);
			this.uxEmployeeDepartmentHistoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeeDepartmentHistoryDataGridViewCellValuePushed);
			
			//
			// uxEmployeeIdDataGridViewColumn
			//
			this.uxEmployeeIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEmployeeIdDataGridViewColumn.DataPropertyName = "EmployeeId";
			this.uxEmployeeIdDataGridViewColumn.HeaderText = "EmployeeId";
			this.uxEmployeeIdDataGridViewColumn.Name = "uxEmployeeIdDataGridViewColumn";
			this.uxEmployeeIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEmployeeIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEmployeeIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxDepartmentIdDataGridViewColumn
			//
			this.uxDepartmentIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDepartmentIdDataGridViewColumn.DataPropertyName = "DepartmentId";
			this.uxDepartmentIdDataGridViewColumn.HeaderText = "DepartmentId";
			this.uxDepartmentIdDataGridViewColumn.Name = "uxDepartmentIdDataGridViewColumn";
			this.uxDepartmentIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDepartmentIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDepartmentIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxShiftIdDataGridViewColumn
			//
			this.uxShiftIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShiftIdDataGridViewColumn.DataPropertyName = "ShiftId";
			this.uxShiftIdDataGridViewColumn.HeaderText = "ShiftId";
			this.uxShiftIdDataGridViewColumn.Name = "uxShiftIdDataGridViewColumn";
			this.uxShiftIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShiftIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShiftIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxStartDateDataGridViewColumn
			//
			this.uxStartDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStartDateDataGridViewColumn.DataPropertyName = "StartDate";
			this.uxStartDateDataGridViewColumn.HeaderText = "StartDate";
			this.uxStartDateDataGridViewColumn.Name = "uxStartDateDataGridViewColumn";
			this.uxStartDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStartDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStartDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxEndDateDataGridViewColumn
			//
			this.uxEndDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEndDateDataGridViewColumn.DataPropertyName = "EndDate";
			this.uxEndDateDataGridViewColumn.HeaderText = "EndDate";
			this.uxEndDateDataGridViewColumn.Name = "uxEndDateDataGridViewColumn";
			this.uxEndDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEndDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEndDateDataGridViewColumn.ReadOnly = false;		
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
			//
			// uxDepartmentIdDataGridViewColumn
			//				
			this.uxDepartmentIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxDepartmentIdDataGridViewColumn.ValueMember = "DepartmentId";	
			this.uxDepartmentIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxDepartmentIdDataGridViewColumn.DataSource = uxDepartmentIdBindingSource;				
				
			//
			// uxEmployeeIdDataGridViewColumn
			//				
			this.uxEmployeeIdDataGridViewColumn.DisplayMember = "NationalIdNumber";	
			this.uxEmployeeIdDataGridViewColumn.ValueMember = "EmployeeId";	
			this.uxEmployeeIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxEmployeeIdDataGridViewColumn.DataSource = uxEmployeeIdBindingSource;				
				
			//
			// uxShiftIdDataGridViewColumn
			//				
			this.uxShiftIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxShiftIdDataGridViewColumn.ValueMember = "ShiftId";	
			this.uxShiftIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxShiftIdDataGridViewColumn.DataSource = uxShiftIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxEmployeeDepartmentHistoryDataGridView);
			this.Name = "EmployeeDepartmentHistoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxDepartmentIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxShiftIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDepartmentHistoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDepartmentHistoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDepartmentHistoryBindingSource)).EndInit();
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
				EmployeeDepartmentHistoryDataGridViewEventArgs args = new EmployeeDepartmentHistoryDataGridViewEventArgs();
				args.EmployeeDepartmentHistory = _currentEmployeeDepartmentHistory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class EmployeeDepartmentHistoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.EmployeeDepartmentHistory	_EmployeeDepartmentHistory;
	
			/// <summary>
			/// the  Entities.EmployeeDepartmentHistory instance.
			/// </summary>
			public Entities.EmployeeDepartmentHistory EmployeeDepartmentHistory
			{
				get { return _EmployeeDepartmentHistory; }
				set { _EmployeeDepartmentHistory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxEmployeeDepartmentHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDepartmentHistoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxEmployeeDepartmentHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDepartmentHistoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeeDepartmentHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxEmployeeIdDataGridViewColumn":
						e.Value = EmployeeDepartmentHistoryList[e.RowIndex].EmployeeId;
						break;
					case "uxDepartmentIdDataGridViewColumn":
						e.Value = EmployeeDepartmentHistoryList[e.RowIndex].DepartmentId;
						break;
					case "uxShiftIdDataGridViewColumn":
						e.Value = EmployeeDepartmentHistoryList[e.RowIndex].ShiftId;
						break;
					case "uxStartDateDataGridViewColumn":
						e.Value = EmployeeDepartmentHistoryList[e.RowIndex].StartDate;
						break;
					case "uxEndDateDataGridViewColumn":
						e.Value = EmployeeDepartmentHistoryList[e.RowIndex].EndDate;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = EmployeeDepartmentHistoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxEmployeeDepartmentHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDepartmentHistoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeeDepartmentHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxEmployeeIdDataGridViewColumn":
						EmployeeDepartmentHistoryList[e.RowIndex].EmployeeId = (System.Int32)e.Value;
						break;
					case "uxDepartmentIdDataGridViewColumn":
						EmployeeDepartmentHistoryList[e.RowIndex].DepartmentId = (System.Int16)e.Value;
						break;
					case "uxShiftIdDataGridViewColumn":
						EmployeeDepartmentHistoryList[e.RowIndex].ShiftId = (System.Byte)e.Value;
						break;
					case "uxStartDateDataGridViewColumn":
						EmployeeDepartmentHistoryList[e.RowIndex].StartDate = (System.DateTime)e.Value;
						break;
					case "uxEndDateDataGridViewColumn":
						EmployeeDepartmentHistoryList[e.RowIndex].EndDate = (System.DateTime?)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						EmployeeDepartmentHistoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
