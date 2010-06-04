
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract VendorAddress typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class VendorAddressDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<VendorAddressDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.VendorAddress _currentVendorAddress = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxVendorAddressDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxVendorAddressErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxVendorAddressBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the VendorId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxVendorIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the AddressId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxAddressIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the AddressTypeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxAddressTypeIdDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Vendor> _VendorIdList;
		
		/// <summary> 
		/// The list of selectable Vendor
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Vendor> VendorIdList
		{
			get {return this._VendorIdList;}
			set 
			{
				this._VendorIdList = value;
				this.uxVendorIdDataGridViewColumn.DataSource = null;
				this.uxVendorIdDataGridViewColumn.DataSource = this._VendorIdList;
			}
		}
		
		private bool _allowNewItemInVendorIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Vendor
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInVendorIdList
		{
			get { return _allowNewItemInVendorIdList;}
			set
			{
				this._allowNewItemInVendorIdList = value;
				this.uxVendorIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.VendorAddress> _VendorAddressList;
				
		/// <summary> 
		/// The list of VendorAddress to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.VendorAddress> VendorAddressList
		{
			get {return this._VendorAddressList;}
			set
			{
				this._VendorAddressList = value;
				this.uxVendorAddressBindingSource.DataSource = null;
				this.uxVendorAddressBindingSource.DataSource = value;
				this.uxVendorAddressDataGridView.DataSource = null;
				this.uxVendorAddressDataGridView.DataSource = this.uxVendorAddressBindingSource;				
				//this.uxVendorAddressBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxVendorAddressBindingSource_ListChanged);
				this.uxVendorAddressBindingSource.CurrentItemChanged += new System.EventHandler(OnVendorAddressBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnVendorAddressBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentVendorAddress = uxVendorAddressBindingSource.Current as Entities.VendorAddress;
			
			if (_currentVendorAddress != null)
			{
				_currentVendorAddress.Validate();
			}
			//_VendorAddress.Validate();
			OnCurrentEntityChanged();
		}

		//void uxVendorAddressBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.VendorAddress"/> instance.
		/// </summary>
		public Entities.VendorAddress SelectedVendorAddress
		{
			get {return this._currentVendorAddress;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxVendorAddressDataGridView.VirtualMode;}
			set
			{
				this.uxVendorAddressDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxVendorAddressDataGridView.AllowUserToAddRows;}
			set {this.uxVendorAddressDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxVendorAddressDataGridView.AllowUserToDeleteRows;}
			set {this.uxVendorAddressDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxVendorAddressDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxVendorAddressDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="VendorAddressDataGridViewBase"/> class.
		/// </summary>
		public VendorAddressDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxVendorAddressDataGridView = new System.Windows.Forms.DataGridView();
			this.uxVendorAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxVendorAddressErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxVendorIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAddressIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAddressTypeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxAddressIdBindingSource = new AddressBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressIdBindingSource)).BeginInit();
			//this.uxAddressTypeIdBindingSource = new AddressTypeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeIdBindingSource)).BeginInit();
			//this.uxVendorIdBindingSource = new VendorBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxVendorIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorAddressDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorAddressBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorAddressErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxVendorAddressErrorProvider
			// 
			this.uxVendorAddressErrorProvider.ContainerControl = this;
			this.uxVendorAddressErrorProvider.DataSource = this.uxVendorAddressBindingSource;						
			// 
			// uxVendorAddressDataGridView
			// 
			this.uxVendorAddressDataGridView.AutoGenerateColumns = false;
			this.uxVendorAddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxVendorAddressDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxVendorIdDataGridViewColumn,
		this.uxAddressIdDataGridViewColumn,
		this.uxAddressTypeIdDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxVendorAddressDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxVendorAddressDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxVendorAddressDataGridView.Name = "uxVendorAddressDataGridView";
			this.uxVendorAddressDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxVendorAddressDataGridView.TabIndex = 0;	
			this.uxVendorAddressDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxVendorAddressDataGridView.EnableHeadersVisualStyles = false;
			this.uxVendorAddressDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnVendorAddressDataGridViewDataError);
			this.uxVendorAddressDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnVendorAddressDataGridViewCellValueNeeded);
			this.uxVendorAddressDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnVendorAddressDataGridViewCellValuePushed);
			
			//
			// uxVendorIdDataGridViewColumn
			//
			this.uxVendorIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxVendorIdDataGridViewColumn.DataPropertyName = "VendorId";
			this.uxVendorIdDataGridViewColumn.HeaderText = "VendorId";
			this.uxVendorIdDataGridViewColumn.Name = "uxVendorIdDataGridViewColumn";
			this.uxVendorIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxVendorIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxVendorIdDataGridViewColumn.ReadOnly = false;		
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
			// uxVendorIdDataGridViewColumn
			//				
			this.uxVendorIdDataGridViewColumn.DisplayMember = "AccountNumber";	
			this.uxVendorIdDataGridViewColumn.ValueMember = "VendorId";	
			this.uxVendorIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxVendorIdDataGridViewColumn.DataSource = uxVendorIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxVendorAddressDataGridView);
			this.Name = "VendorAddressDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxVendorIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorAddressErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorAddressDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorAddressBindingSource)).EndInit();
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
				VendorAddressDataGridViewEventArgs args = new VendorAddressDataGridViewEventArgs();
				args.VendorAddress = _currentVendorAddress;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class VendorAddressDataGridViewEventArgs : System.EventArgs
		{
			private Entities.VendorAddress	_VendorAddress;
	
			/// <summary>
			/// the  Entities.VendorAddress instance.
			/// </summary>
			public Entities.VendorAddress VendorAddress
			{
				get { return _VendorAddress; }
				set { _VendorAddress = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxVendorAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnVendorAddressDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxVendorAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnVendorAddressDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxVendorAddressDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxVendorIdDataGridViewColumn":
						e.Value = VendorAddressList[e.RowIndex].VendorId;
						break;
					case "uxAddressIdDataGridViewColumn":
						e.Value = VendorAddressList[e.RowIndex].AddressId;
						break;
					case "uxAddressTypeIdDataGridViewColumn":
						e.Value = VendorAddressList[e.RowIndex].AddressTypeId;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = VendorAddressList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxVendorAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnVendorAddressDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxVendorAddressDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxVendorIdDataGridViewColumn":
						VendorAddressList[e.RowIndex].VendorId = (System.Int32)e.Value;
						break;
					case "uxAddressIdDataGridViewColumn":
						VendorAddressList[e.RowIndex].AddressId = (System.Int32)e.Value;
						break;
					case "uxAddressTypeIdDataGridViewColumn":
						VendorAddressList[e.RowIndex].AddressTypeId = (System.Int32)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						VendorAddressList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
