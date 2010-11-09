
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract EmployeeAddress typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class EmployeeAddressDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<EmployeeAddressDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.EmployeeAddress _currentEmployeeAddress = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxEmployeeAddressDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxEmployeeAddressErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxEmployeeAddressBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the EmployeeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxEmployeeIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the AddressId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxAddressIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Rowguid property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRowguidDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Address> _AddressIdList;
		
		/// <summary> 
		/// The list of selectable Address
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Address> AddressIdList
		{
			get {return this._AddressIdList;}
			set 
			{
				this._AddressIdList = value;
				this.uxAddressIdDataGridViewColumn.DataSource = null;
				this.uxAddressIdDataGridViewColumn.DataSource = this._AddressIdList;
			}
		}
		
		private bool _allowNewItemInAddressIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Address
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInAddressIdList
		{
			get { return _allowNewItemInAddressIdList;}
			set
			{
				this._allowNewItemInAddressIdList = value;
				this.uxAddressIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.EmployeeAddress> _EmployeeAddressList;
				
		/// <summary> 
		/// The list of EmployeeAddress to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.EmployeeAddress> EmployeeAddressList
		{
			get {return this._EmployeeAddressList;}
			set
			{
				this._EmployeeAddressList = value;
				this.uxEmployeeAddressBindingSource.DataSource = null;
				this.uxEmployeeAddressBindingSource.DataSource = value;
				this.uxEmployeeAddressDataGridView.DataSource = null;
				this.uxEmployeeAddressDataGridView.DataSource = this.uxEmployeeAddressBindingSource;				
				//this.uxEmployeeAddressBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxEmployeeAddressBindingSource_ListChanged);
				this.uxEmployeeAddressBindingSource.CurrentItemChanged += new System.EventHandler(OnEmployeeAddressBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnEmployeeAddressBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentEmployeeAddress = uxEmployeeAddressBindingSource.Current as Entities.EmployeeAddress;
			
			if (_currentEmployeeAddress != null)
			{
				_currentEmployeeAddress.Validate();
			}
			//_EmployeeAddress.Validate();
			OnCurrentEntityChanged();
		}

		//void uxEmployeeAddressBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.EmployeeAddress"/> instance.
		/// </summary>
		public Entities.EmployeeAddress SelectedEmployeeAddress
		{
			get {return this._currentEmployeeAddress;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxEmployeeAddressDataGridView.VirtualMode;}
			set
			{
				this.uxEmployeeAddressDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxEmployeeAddressDataGridView.AllowUserToAddRows;}
			set {this.uxEmployeeAddressDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxEmployeeAddressDataGridView.AllowUserToDeleteRows;}
			set {this.uxEmployeeAddressDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxEmployeeAddressDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxEmployeeAddressDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="EmployeeAddressDataGridViewBase"/> class.
		/// </summary>
		public EmployeeAddressDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxEmployeeAddressDataGridView = new System.Windows.Forms.DataGridView();
			this.uxEmployeeAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxEmployeeAddressErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxEmployeeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAddressIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxAddressIdBindingSource = new AddressBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressIdBindingSource)).BeginInit();
			//this.uxEmployeeIdBindingSource = new EmployeeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeAddressDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeAddressBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeAddressErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxEmployeeAddressErrorProvider
			// 
			this.uxEmployeeAddressErrorProvider.ContainerControl = this;
			this.uxEmployeeAddressErrorProvider.DataSource = this.uxEmployeeAddressBindingSource;						
			// 
			// uxEmployeeAddressDataGridView
			// 
			this.uxEmployeeAddressDataGridView.AutoGenerateColumns = false;
			this.uxEmployeeAddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxEmployeeAddressDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxEmployeeIdDataGridViewColumn,
		this.uxAddressIdDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxEmployeeAddressDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxEmployeeAddressDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxEmployeeAddressDataGridView.Name = "uxEmployeeAddressDataGridView";
			this.uxEmployeeAddressDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxEmployeeAddressDataGridView.TabIndex = 0;	
			this.uxEmployeeAddressDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxEmployeeAddressDataGridView.EnableHeadersVisualStyles = false;
			this.uxEmployeeAddressDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnEmployeeAddressDataGridViewDataError);
			this.uxEmployeeAddressDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeeAddressDataGridViewCellValueNeeded);
			this.uxEmployeeAddressDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeeAddressDataGridViewCellValuePushed);
			
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
			// uxAddressIdDataGridViewColumn
			//
			this.uxAddressIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressIdDataGridViewColumn.DataPropertyName = "AddressId";
			this.uxAddressIdDataGridViewColumn.HeaderText = "AddressId";
			this.uxAddressIdDataGridViewColumn.Name = "uxAddressIdDataGridViewColumn";
			this.uxAddressIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxRowguidDataGridViewColumn
			//
			this.uxRowguidDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRowguidDataGridViewColumn.DataPropertyName = "Rowguid";
			this.uxRowguidDataGridViewColumn.HeaderText = "Rowguid";
			this.uxRowguidDataGridViewColumn.Name = "uxRowguidDataGridViewColumn";
			this.uxRowguidDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRowguidDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRowguidDataGridViewColumn.ReadOnly = true;		
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
			// uxAddressIdDataGridViewColumn
			//				
			this.uxAddressIdDataGridViewColumn.DisplayMember = "AddressLine1";	
			this.uxAddressIdDataGridViewColumn.ValueMember = "AddressId";	
			this.uxAddressIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxAddressIdDataGridViewColumn.DataSource = uxAddressIdBindingSource;				
				
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
			this.Controls.Add(this.uxEmployeeAddressDataGridView);
			this.Name = "EmployeeAddressDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeAddressErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeAddressDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeAddressBindingSource)).EndInit();
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
				EmployeeAddressDataGridViewEventArgs args = new EmployeeAddressDataGridViewEventArgs();
				args.EmployeeAddress = _currentEmployeeAddress;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class EmployeeAddressDataGridViewEventArgs : System.EventArgs
		{
			private Entities.EmployeeAddress	_EmployeeAddress;
	
			/// <summary>
			/// the  Entities.EmployeeAddress instance.
			/// </summary>
			public Entities.EmployeeAddress EmployeeAddress
			{
				get { return _EmployeeAddress; }
				set { _EmployeeAddress = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxEmployeeAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeAddressDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxEmployeeAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeAddressDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeeAddressDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxEmployeeIdDataGridViewColumn":
						e.Value = EmployeeAddressList[e.RowIndex].EmployeeId;
						break;
					case "uxAddressIdDataGridViewColumn":
						e.Value = EmployeeAddressList[e.RowIndex].AddressId;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = EmployeeAddressList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = EmployeeAddressList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxEmployeeAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeAddressDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeeAddressDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxEmployeeIdDataGridViewColumn":
						EmployeeAddressList[e.RowIndex].EmployeeId = (System.Int32)e.Value;
						break;
					case "uxAddressIdDataGridViewColumn":
						EmployeeAddressList[e.RowIndex].AddressId = (System.Int32)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						EmployeeAddressList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						EmployeeAddressList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
