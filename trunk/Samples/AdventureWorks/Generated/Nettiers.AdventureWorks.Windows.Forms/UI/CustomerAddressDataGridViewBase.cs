
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract CustomerAddress typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CustomerAddressDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CustomerAddressDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.CustomerAddress _currentCustomerAddress = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCustomerAddressDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCustomerAddressErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCustomerAddressBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the CustomerId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCustomerIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the AddressId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxAddressIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the AddressTypeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxAddressTypeIdDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.AddressType> _AddressTypeIdList;
		
		/// <summary> 
		/// The list of selectable AddressType
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.AddressType> AddressTypeIdList
		{
			get {return this._AddressTypeIdList;}
			set 
			{
				this._AddressTypeIdList = value;
				this.uxAddressTypeIdDataGridViewColumn.DataSource = null;
				this.uxAddressTypeIdDataGridViewColumn.DataSource = this._AddressTypeIdList;
			}
		}
		
		private bool _allowNewItemInAddressTypeIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of AddressType
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInAddressTypeIdList
		{
			get { return _allowNewItemInAddressTypeIdList;}
			set
			{
				this._allowNewItemInAddressTypeIdList = value;
				this.uxAddressTypeIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Customer> _CustomerIdList;
		
		/// <summary> 
		/// The list of selectable Customer
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Customer> CustomerIdList
		{
			get {return this._CustomerIdList;}
			set 
			{
				this._CustomerIdList = value;
				this.uxCustomerIdDataGridViewColumn.DataSource = null;
				this.uxCustomerIdDataGridViewColumn.DataSource = this._CustomerIdList;
			}
		}
		
		private bool _allowNewItemInCustomerIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Customer
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCustomerIdList
		{
			get { return _allowNewItemInCustomerIdList;}
			set
			{
				this._allowNewItemInCustomerIdList = value;
				this.uxCustomerIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.CustomerAddress> _CustomerAddressList;
				
		/// <summary> 
		/// The list of CustomerAddress to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.CustomerAddress> CustomerAddressList
		{
			get {return this._CustomerAddressList;}
			set
			{
				this._CustomerAddressList = value;
				this.uxCustomerAddressBindingSource.DataSource = null;
				this.uxCustomerAddressBindingSource.DataSource = value;
				this.uxCustomerAddressDataGridView.DataSource = null;
				this.uxCustomerAddressDataGridView.DataSource = this.uxCustomerAddressBindingSource;				
				//this.uxCustomerAddressBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCustomerAddressBindingSource_ListChanged);
				this.uxCustomerAddressBindingSource.CurrentItemChanged += new System.EventHandler(OnCustomerAddressBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCustomerAddressBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCustomerAddress = uxCustomerAddressBindingSource.Current as Entities.CustomerAddress;
			
			if (_currentCustomerAddress != null)
			{
				_currentCustomerAddress.Validate();
			}
			//_CustomerAddress.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCustomerAddressBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.CustomerAddress"/> instance.
		/// </summary>
		public Entities.CustomerAddress SelectedCustomerAddress
		{
			get {return this._currentCustomerAddress;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCustomerAddressDataGridView.VirtualMode;}
			set
			{
				this.uxCustomerAddressDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCustomerAddressDataGridView.AllowUserToAddRows;}
			set {this.uxCustomerAddressDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCustomerAddressDataGridView.AllowUserToDeleteRows;}
			set {this.uxCustomerAddressDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCustomerAddressDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCustomerAddressDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CustomerAddressDataGridViewBase"/> class.
		/// </summary>
		public CustomerAddressDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCustomerAddressDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCustomerAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCustomerAddressErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCustomerIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAddressIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAddressTypeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxAddressIdBindingSource = new AddressBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressIdBindingSource)).BeginInit();
			//this.uxAddressTypeIdBindingSource = new AddressTypeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeIdBindingSource)).BeginInit();
			//this.uxCustomerIdBindingSource = new CustomerBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerAddressDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerAddressBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerAddressErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCustomerAddressErrorProvider
			// 
			this.uxCustomerAddressErrorProvider.ContainerControl = this;
			this.uxCustomerAddressErrorProvider.DataSource = this.uxCustomerAddressBindingSource;						
			// 
			// uxCustomerAddressDataGridView
			// 
			this.uxCustomerAddressDataGridView.AutoGenerateColumns = false;
			this.uxCustomerAddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCustomerAddressDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCustomerIdDataGridViewColumn,
		this.uxAddressIdDataGridViewColumn,
		this.uxAddressTypeIdDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxCustomerAddressDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCustomerAddressDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCustomerAddressDataGridView.Name = "uxCustomerAddressDataGridView";
			this.uxCustomerAddressDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCustomerAddressDataGridView.TabIndex = 0;	
			this.uxCustomerAddressDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCustomerAddressDataGridView.EnableHeadersVisualStyles = false;
			this.uxCustomerAddressDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCustomerAddressDataGridViewDataError);
			this.uxCustomerAddressDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCustomerAddressDataGridViewCellValueNeeded);
			this.uxCustomerAddressDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCustomerAddressDataGridViewCellValuePushed);
			
			//
			// uxCustomerIdDataGridViewColumn
			//
			this.uxCustomerIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCustomerIdDataGridViewColumn.DataPropertyName = "CustomerId";
			this.uxCustomerIdDataGridViewColumn.HeaderText = "CustomerId";
			this.uxCustomerIdDataGridViewColumn.Name = "uxCustomerIdDataGridViewColumn";
			this.uxCustomerIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCustomerIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCustomerIdDataGridViewColumn.ReadOnly = false;		
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
			// uxAddressTypeIdDataGridViewColumn
			//
			this.uxAddressTypeIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressTypeIdDataGridViewColumn.DataPropertyName = "AddressTypeId";
			this.uxAddressTypeIdDataGridViewColumn.HeaderText = "AddressTypeId";
			this.uxAddressTypeIdDataGridViewColumn.Name = "uxAddressTypeIdDataGridViewColumn";
			this.uxAddressTypeIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressTypeIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressTypeIdDataGridViewColumn.ReadOnly = false;		
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
			// uxAddressTypeIdDataGridViewColumn
			//				
			this.uxAddressTypeIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxAddressTypeIdDataGridViewColumn.ValueMember = "AddressTypeId";	
			this.uxAddressTypeIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxAddressTypeIdDataGridViewColumn.DataSource = uxAddressTypeIdBindingSource;				
				
			//
			// uxCustomerIdDataGridViewColumn
			//				
			this.uxCustomerIdDataGridViewColumn.DisplayMember = "TerritoryId";	
			this.uxCustomerIdDataGridViewColumn.ValueMember = "CustomerId";	
			this.uxCustomerIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCustomerIdDataGridViewColumn.DataSource = uxCustomerIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxCustomerAddressDataGridView);
			this.Name = "CustomerAddressDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerAddressErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerAddressDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerAddressBindingSource)).EndInit();
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
				CustomerAddressDataGridViewEventArgs args = new CustomerAddressDataGridViewEventArgs();
				args.CustomerAddress = _currentCustomerAddress;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CustomerAddressDataGridViewEventArgs : System.EventArgs
		{
			private Entities.CustomerAddress	_CustomerAddress;
	
			/// <summary>
			/// the  Entities.CustomerAddress instance.
			/// </summary>
			public Entities.CustomerAddress CustomerAddress
			{
				get { return _CustomerAddress; }
				set { _CustomerAddress = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCustomerAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCustomerAddressDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCustomerAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCustomerAddressDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCustomerAddressDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						e.Value = CustomerAddressList[e.RowIndex].CustomerId;
						break;
					case "uxAddressIdDataGridViewColumn":
						e.Value = CustomerAddressList[e.RowIndex].AddressId;
						break;
					case "uxAddressTypeIdDataGridViewColumn":
						e.Value = CustomerAddressList[e.RowIndex].AddressTypeId;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = CustomerAddressList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = CustomerAddressList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCustomerAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCustomerAddressDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCustomerAddressDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						CustomerAddressList[e.RowIndex].CustomerId = (System.Int32)e.Value;
						break;
					case "uxAddressIdDataGridViewColumn":
						CustomerAddressList[e.RowIndex].AddressId = (System.Int32)e.Value;
						break;
					case "uxAddressTypeIdDataGridViewColumn":
						CustomerAddressList[e.RowIndex].AddressTypeId = (System.Int32)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						CustomerAddressList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						CustomerAddressList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
