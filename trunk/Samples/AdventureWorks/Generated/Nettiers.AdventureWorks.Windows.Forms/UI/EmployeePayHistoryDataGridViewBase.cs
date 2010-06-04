
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract EmployeePayHistory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class EmployeePayHistoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<EmployeePayHistoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.EmployeePayHistory _currentEmployeePayHistory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxEmployeePayHistoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxEmployeePayHistoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxEmployeePayHistoryBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the EmployeeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxEmployeeIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the RateChangeDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRateChangeDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Rate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PayFrequency property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPayFrequencyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.EmployeePayHistory> _EmployeePayHistoryList;
				
		/// <summary> 
		/// The list of EmployeePayHistory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.EmployeePayHistory> EmployeePayHistoryList
		{
			get {return this._EmployeePayHistoryList;}
			set
			{
				this._EmployeePayHistoryList = value;
				this.uxEmployeePayHistoryBindingSource.DataSource = null;
				this.uxEmployeePayHistoryBindingSource.DataSource = value;
				this.uxEmployeePayHistoryDataGridView.DataSource = null;
				this.uxEmployeePayHistoryDataGridView.DataSource = this.uxEmployeePayHistoryBindingSource;				
				//this.uxEmployeePayHistoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxEmployeePayHistoryBindingSource_ListChanged);
				this.uxEmployeePayHistoryBindingSource.CurrentItemChanged += new System.EventHandler(OnEmployeePayHistoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnEmployeePayHistoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentEmployeePayHistory = uxEmployeePayHistoryBindingSource.Current as Entities.EmployeePayHistory;
			
			if (_currentEmployeePayHistory != null)
			{
				_currentEmployeePayHistory.Validate();
			}
			//_EmployeePayHistory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxEmployeePayHistoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.EmployeePayHistory"/> instance.
		/// </summary>
		public Entities.EmployeePayHistory SelectedEmployeePayHistory
		{
			get {return this._currentEmployeePayHistory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxEmployeePayHistoryDataGridView.VirtualMode;}
			set
			{
				this.uxEmployeePayHistoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxEmployeePayHistoryDataGridView.AllowUserToAddRows;}
			set {this.uxEmployeePayHistoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxEmployeePayHistoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxEmployeePayHistoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxEmployeePayHistoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxEmployeePayHistoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="EmployeePayHistoryDataGridViewBase"/> class.
		/// </summary>
		public EmployeePayHistoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxEmployeePayHistoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxEmployeePayHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxEmployeePayHistoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxEmployeeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxRateChangeDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPayFrequencyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxEmployeeIdBindingSource = new EmployeeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeePayHistoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeePayHistoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeePayHistoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxEmployeePayHistoryErrorProvider
			// 
			this.uxEmployeePayHistoryErrorProvider.ContainerControl = this;
			this.uxEmployeePayHistoryErrorProvider.DataSource = this.uxEmployeePayHistoryBindingSource;						
			// 
			// uxEmployeePayHistoryDataGridView
			// 
			this.uxEmployeePayHistoryDataGridView.AutoGenerateColumns = false;
			this.uxEmployeePayHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxEmployeePayHistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxEmployeeIdDataGridViewColumn,
		this.uxRateChangeDateDataGridViewColumn,
		this.uxRateDataGridViewColumn,
		this.uxPayFrequencyDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxEmployeePayHistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxEmployeePayHistoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxEmployeePayHistoryDataGridView.Name = "uxEmployeePayHistoryDataGridView";
			this.uxEmployeePayHistoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxEmployeePayHistoryDataGridView.TabIndex = 0;	
			this.uxEmployeePayHistoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxEmployeePayHistoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxEmployeePayHistoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnEmployeePayHistoryDataGridViewDataError);
			this.uxEmployeePayHistoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeePayHistoryDataGridViewCellValueNeeded);
			this.uxEmployeePayHistoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeePayHistoryDataGridViewCellValuePushed);
			
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
			// uxRateChangeDateDataGridViewColumn
			//
			this.uxRateChangeDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRateChangeDateDataGridViewColumn.DataPropertyName = "RateChangeDate";
			this.uxRateChangeDateDataGridViewColumn.HeaderText = "RateChangeDate";
			this.uxRateChangeDateDataGridViewColumn.Name = "uxRateChangeDateDataGridViewColumn";
			this.uxRateChangeDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRateChangeDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRateChangeDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxRateDataGridViewColumn
			//
			this.uxRateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRateDataGridViewColumn.DataPropertyName = "Rate";
			this.uxRateDataGridViewColumn.HeaderText = "Rate";
			this.uxRateDataGridViewColumn.Name = "uxRateDataGridViewColumn";
			this.uxRateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRateDataGridViewColumn.ReadOnly = false;		
			//
			// uxPayFrequencyDataGridViewColumn
			//
			this.uxPayFrequencyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPayFrequencyDataGridViewColumn.DataPropertyName = "PayFrequency";
			this.uxPayFrequencyDataGridViewColumn.HeaderText = "PayFrequency";
			this.uxPayFrequencyDataGridViewColumn.Name = "uxPayFrequencyDataGridViewColumn";
			this.uxPayFrequencyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPayFrequencyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPayFrequencyDataGridViewColumn.ReadOnly = false;		
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
			// uxEmployeeIdDataGridViewColumn
			//				
			this.uxEmployeeIdDataGridViewColumn.DisplayMember = "NationalIdNumber";	
			this.uxEmployeeIdDataGridViewColumn.ValueMember = "EmployeeId";	
			this.uxEmployeeIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxEmployeeIdDataGridViewColumn.DataSource = uxEmployeeIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxEmployeePayHistoryDataGridView);
			this.Name = "EmployeePayHistoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeePayHistoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeePayHistoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeePayHistoryBindingSource)).EndInit();
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
				EmployeePayHistoryDataGridViewEventArgs args = new EmployeePayHistoryDataGridViewEventArgs();
				args.EmployeePayHistory = _currentEmployeePayHistory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class EmployeePayHistoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.EmployeePayHistory	_EmployeePayHistory;
	
			/// <summary>
			/// the  Entities.EmployeePayHistory instance.
			/// </summary>
			public Entities.EmployeePayHistory EmployeePayHistory
			{
				get { return _EmployeePayHistory; }
				set { _EmployeePayHistory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxEmployeePayHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeePayHistoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxEmployeePayHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeePayHistoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeePayHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxEmployeeIdDataGridViewColumn":
						e.Value = EmployeePayHistoryList[e.RowIndex].EmployeeId;
						break;
					case "uxRateChangeDateDataGridViewColumn":
						e.Value = EmployeePayHistoryList[e.RowIndex].RateChangeDate;
						break;
					case "uxRateDataGridViewColumn":
						e.Value = EmployeePayHistoryList[e.RowIndex].Rate;
						break;
					case "uxPayFrequencyDataGridViewColumn":
						e.Value = EmployeePayHistoryList[e.RowIndex].PayFrequency;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = EmployeePayHistoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxEmployeePayHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeePayHistoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeePayHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxEmployeeIdDataGridViewColumn":
						EmployeePayHistoryList[e.RowIndex].EmployeeId = (System.Int32)e.Value;
						break;
					case "uxRateChangeDateDataGridViewColumn":
						EmployeePayHistoryList[e.RowIndex].RateChangeDate = (System.DateTime)e.Value;
						break;
					case "uxRateDataGridViewColumn":
						EmployeePayHistoryList[e.RowIndex].Rate = (System.Decimal)e.Value;
						break;
					case "uxPayFrequencyDataGridViewColumn":
						EmployeePayHistoryList[e.RowIndex].PayFrequency = (System.Byte)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						EmployeePayHistoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
