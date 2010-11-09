
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract PurchaseOrderHeader typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class PurchaseOrderHeaderDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<PurchaseOrderHeaderDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.PurchaseOrderHeader _currentPurchaseOrderHeader = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxPurchaseOrderHeaderDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxPurchaseOrderHeaderErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxPurchaseOrderHeaderBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the PurchaseOrderId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPurchaseOrderIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the RevisionNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRevisionNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Status property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStatusDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the EmployeeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxEmployeeIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the VendorId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxVendorIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ShipMethodId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxShipMethodIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OrderDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOrderDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ShipDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShipDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SubTotal property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSubTotalDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TaxAmt property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTaxAmtDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Freight property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFreightDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TotalDue property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTotalDueDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.ShipMethod> _ShipMethodIdList;
		
		/// <summary> 
		/// The list of selectable ShipMethod
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ShipMethod> ShipMethodIdList
		{
			get {return this._ShipMethodIdList;}
			set 
			{
				this._ShipMethodIdList = value;
				this.uxShipMethodIdDataGridViewColumn.DataSource = null;
				this.uxShipMethodIdDataGridViewColumn.DataSource = this._ShipMethodIdList;
			}
		}
		
		private bool _allowNewItemInShipMethodIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ShipMethod
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInShipMethodIdList
		{
			get { return _allowNewItemInShipMethodIdList;}
			set
			{
				this._allowNewItemInShipMethodIdList = value;
				this.uxShipMethodIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
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
		
		private Entities.TList<Entities.PurchaseOrderHeader> _PurchaseOrderHeaderList;
				
		/// <summary> 
		/// The list of PurchaseOrderHeader to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.PurchaseOrderHeader> PurchaseOrderHeaderList
		{
			get {return this._PurchaseOrderHeaderList;}
			set
			{
				this._PurchaseOrderHeaderList = value;
				this.uxPurchaseOrderHeaderBindingSource.DataSource = null;
				this.uxPurchaseOrderHeaderBindingSource.DataSource = value;
				this.uxPurchaseOrderHeaderDataGridView.DataSource = null;
				this.uxPurchaseOrderHeaderDataGridView.DataSource = this.uxPurchaseOrderHeaderBindingSource;				
				//this.uxPurchaseOrderHeaderBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxPurchaseOrderHeaderBindingSource_ListChanged);
				this.uxPurchaseOrderHeaderBindingSource.CurrentItemChanged += new System.EventHandler(OnPurchaseOrderHeaderBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnPurchaseOrderHeaderBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentPurchaseOrderHeader = uxPurchaseOrderHeaderBindingSource.Current as Entities.PurchaseOrderHeader;
			
			if (_currentPurchaseOrderHeader != null)
			{
				_currentPurchaseOrderHeader.Validate();
			}
			//_PurchaseOrderHeader.Validate();
			OnCurrentEntityChanged();
		}

		//void uxPurchaseOrderHeaderBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.PurchaseOrderHeader"/> instance.
		/// </summary>
		public Entities.PurchaseOrderHeader SelectedPurchaseOrderHeader
		{
			get {return this._currentPurchaseOrderHeader;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxPurchaseOrderHeaderDataGridView.VirtualMode;}
			set
			{
				this.uxPurchaseOrderHeaderDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxPurchaseOrderHeaderDataGridView.AllowUserToAddRows;}
			set {this.uxPurchaseOrderHeaderDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxPurchaseOrderHeaderDataGridView.AllowUserToDeleteRows;}
			set {this.uxPurchaseOrderHeaderDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxPurchaseOrderHeaderDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxPurchaseOrderHeaderDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="PurchaseOrderHeaderDataGridViewBase"/> class.
		/// </summary>
		public PurchaseOrderHeaderDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxPurchaseOrderHeaderDataGridView = new System.Windows.Forms.DataGridView();
			this.uxPurchaseOrderHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxPurchaseOrderHeaderErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxPurchaseOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRevisionNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStatusDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEmployeeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxVendorIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxShipMethodIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxOrderDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxShipDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSubTotalDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTaxAmtDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFreightDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTotalDueDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxEmployeeIdBindingSource = new EmployeeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).BeginInit();
			//this.uxShipMethodIdBindingSource = new ShipMethodBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxShipMethodIdBindingSource)).BeginInit();
			//this.uxVendorIdBindingSource = new VendorBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxVendorIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderHeaderDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderHeaderBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderHeaderErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxPurchaseOrderHeaderErrorProvider
			// 
			this.uxPurchaseOrderHeaderErrorProvider.ContainerControl = this;
			this.uxPurchaseOrderHeaderErrorProvider.DataSource = this.uxPurchaseOrderHeaderBindingSource;						
			// 
			// uxPurchaseOrderHeaderDataGridView
			// 
			this.uxPurchaseOrderHeaderDataGridView.AutoGenerateColumns = false;
			this.uxPurchaseOrderHeaderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxPurchaseOrderHeaderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxPurchaseOrderIdDataGridViewColumn,
		this.uxRevisionNumberDataGridViewColumn,
		this.uxStatusDataGridViewColumn,
		this.uxEmployeeIdDataGridViewColumn,
		this.uxVendorIdDataGridViewColumn,
		this.uxShipMethodIdDataGridViewColumn,
		this.uxOrderDateDataGridViewColumn,
		this.uxShipDateDataGridViewColumn,
		this.uxSubTotalDataGridViewColumn,
		this.uxTaxAmtDataGridViewColumn,
		this.uxFreightDataGridViewColumn,
		this.uxTotalDueDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxPurchaseOrderHeaderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxPurchaseOrderHeaderDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxPurchaseOrderHeaderDataGridView.Name = "uxPurchaseOrderHeaderDataGridView";
			this.uxPurchaseOrderHeaderDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxPurchaseOrderHeaderDataGridView.TabIndex = 0;	
			this.uxPurchaseOrderHeaderDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxPurchaseOrderHeaderDataGridView.EnableHeadersVisualStyles = false;
			this.uxPurchaseOrderHeaderDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnPurchaseOrderHeaderDataGridViewDataError);
			this.uxPurchaseOrderHeaderDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnPurchaseOrderHeaderDataGridViewCellValueNeeded);
			this.uxPurchaseOrderHeaderDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnPurchaseOrderHeaderDataGridViewCellValuePushed);
			
			//
			// uxPurchaseOrderIdDataGridViewColumn
			//
			this.uxPurchaseOrderIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPurchaseOrderIdDataGridViewColumn.DataPropertyName = "PurchaseOrderId";
			this.uxPurchaseOrderIdDataGridViewColumn.HeaderText = "PurchaseOrderId";
			this.uxPurchaseOrderIdDataGridViewColumn.Name = "uxPurchaseOrderIdDataGridViewColumn";
			this.uxPurchaseOrderIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPurchaseOrderIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPurchaseOrderIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxRevisionNumberDataGridViewColumn
			//
			this.uxRevisionNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRevisionNumberDataGridViewColumn.DataPropertyName = "RevisionNumber";
			this.uxRevisionNumberDataGridViewColumn.HeaderText = "RevisionNumber";
			this.uxRevisionNumberDataGridViewColumn.Name = "uxRevisionNumberDataGridViewColumn";
			this.uxRevisionNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRevisionNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRevisionNumberDataGridViewColumn.ReadOnly = false;		
			//
			// uxStatusDataGridViewColumn
			//
			this.uxStatusDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStatusDataGridViewColumn.DataPropertyName = "Status";
			this.uxStatusDataGridViewColumn.HeaderText = "Status";
			this.uxStatusDataGridViewColumn.Name = "uxStatusDataGridViewColumn";
			this.uxStatusDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStatusDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStatusDataGridViewColumn.ReadOnly = false;		
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
			// uxShipMethodIdDataGridViewColumn
			//
			this.uxShipMethodIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShipMethodIdDataGridViewColumn.DataPropertyName = "ShipMethodId";
			this.uxShipMethodIdDataGridViewColumn.HeaderText = "ShipMethodId";
			this.uxShipMethodIdDataGridViewColumn.Name = "uxShipMethodIdDataGridViewColumn";
			this.uxShipMethodIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShipMethodIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShipMethodIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxOrderDateDataGridViewColumn
			//
			this.uxOrderDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxOrderDateDataGridViewColumn.DataPropertyName = "OrderDate";
			this.uxOrderDateDataGridViewColumn.HeaderText = "OrderDate";
			this.uxOrderDateDataGridViewColumn.Name = "uxOrderDateDataGridViewColumn";
			this.uxOrderDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxOrderDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxOrderDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxShipDateDataGridViewColumn
			//
			this.uxShipDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShipDateDataGridViewColumn.DataPropertyName = "ShipDate";
			this.uxShipDateDataGridViewColumn.HeaderText = "ShipDate";
			this.uxShipDateDataGridViewColumn.Name = "uxShipDateDataGridViewColumn";
			this.uxShipDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShipDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShipDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxSubTotalDataGridViewColumn
			//
			this.uxSubTotalDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSubTotalDataGridViewColumn.DataPropertyName = "SubTotal";
			this.uxSubTotalDataGridViewColumn.HeaderText = "SubTotal";
			this.uxSubTotalDataGridViewColumn.Name = "uxSubTotalDataGridViewColumn";
			this.uxSubTotalDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSubTotalDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSubTotalDataGridViewColumn.ReadOnly = false;		
			//
			// uxTaxAmtDataGridViewColumn
			//
			this.uxTaxAmtDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTaxAmtDataGridViewColumn.DataPropertyName = "TaxAmt";
			this.uxTaxAmtDataGridViewColumn.HeaderText = "TaxAmt";
			this.uxTaxAmtDataGridViewColumn.Name = "uxTaxAmtDataGridViewColumn";
			this.uxTaxAmtDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTaxAmtDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTaxAmtDataGridViewColumn.ReadOnly = false;		
			//
			// uxFreightDataGridViewColumn
			//
			this.uxFreightDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFreightDataGridViewColumn.DataPropertyName = "Freight";
			this.uxFreightDataGridViewColumn.HeaderText = "Freight";
			this.uxFreightDataGridViewColumn.Name = "uxFreightDataGridViewColumn";
			this.uxFreightDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFreightDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFreightDataGridViewColumn.ReadOnly = false;		
			//
			// uxTotalDueDataGridViewColumn
			//
			this.uxTotalDueDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTotalDueDataGridViewColumn.DataPropertyName = "TotalDue";
			this.uxTotalDueDataGridViewColumn.HeaderText = "TotalDue";
			this.uxTotalDueDataGridViewColumn.Name = "uxTotalDueDataGridViewColumn";
			this.uxTotalDueDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTotalDueDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTotalDueDataGridViewColumn.ReadOnly = true;		
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
				
			//
			// uxShipMethodIdDataGridViewColumn
			//				
			this.uxShipMethodIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxShipMethodIdDataGridViewColumn.ValueMember = "ShipMethodId";	
			this.uxShipMethodIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxShipMethodIdDataGridViewColumn.DataSource = uxShipMethodIdBindingSource;				
				
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
			this.Controls.Add(this.uxPurchaseOrderHeaderDataGridView);
			this.Name = "PurchaseOrderHeaderDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxShipMethodIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxVendorIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderHeaderErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderHeaderDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderHeaderBindingSource)).EndInit();
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
				PurchaseOrderHeaderDataGridViewEventArgs args = new PurchaseOrderHeaderDataGridViewEventArgs();
				args.PurchaseOrderHeader = _currentPurchaseOrderHeader;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class PurchaseOrderHeaderDataGridViewEventArgs : System.EventArgs
		{
			private Entities.PurchaseOrderHeader	_PurchaseOrderHeader;
	
			/// <summary>
			/// the  Entities.PurchaseOrderHeader instance.
			/// </summary>
			public Entities.PurchaseOrderHeader PurchaseOrderHeader
			{
				get { return _PurchaseOrderHeader; }
				set { _PurchaseOrderHeader = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxPurchaseOrderHeaderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnPurchaseOrderHeaderDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxPurchaseOrderHeaderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnPurchaseOrderHeaderDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxPurchaseOrderHeaderDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxPurchaseOrderIdDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].PurchaseOrderId;
						break;
					case "uxRevisionNumberDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].RevisionNumber;
						break;
					case "uxStatusDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].Status;
						break;
					case "uxEmployeeIdDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].EmployeeId;
						break;
					case "uxVendorIdDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].VendorId;
						break;
					case "uxShipMethodIdDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].ShipMethodId;
						break;
					case "uxOrderDateDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].OrderDate;
						break;
					case "uxShipDateDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].ShipDate;
						break;
					case "uxSubTotalDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].SubTotal;
						break;
					case "uxTaxAmtDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].TaxAmt;
						break;
					case "uxFreightDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].Freight;
						break;
					case "uxTotalDueDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].TotalDue;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = PurchaseOrderHeaderList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxPurchaseOrderHeaderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnPurchaseOrderHeaderDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxPurchaseOrderHeaderDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxPurchaseOrderIdDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].PurchaseOrderId = (System.Int32)e.Value;
						break;
					case "uxRevisionNumberDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].RevisionNumber = (System.Byte)e.Value;
						break;
					case "uxStatusDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].Status = (System.Byte)e.Value;
						break;
					case "uxEmployeeIdDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].EmployeeId = (System.Int32)e.Value;
						break;
					case "uxVendorIdDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].VendorId = (System.Int32)e.Value;
						break;
					case "uxShipMethodIdDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].ShipMethodId = (System.Int32)e.Value;
						break;
					case "uxOrderDateDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].OrderDate = (System.DateTime)e.Value;
						break;
					case "uxShipDateDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].ShipDate = (System.DateTime?)e.Value;
						break;
					case "uxSubTotalDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].SubTotal = (System.Decimal)e.Value;
						break;
					case "uxTaxAmtDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].TaxAmt = (System.Decimal)e.Value;
						break;
					case "uxFreightDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].Freight = (System.Decimal)e.Value;
						break;
					case "uxTotalDueDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].TotalDue = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						PurchaseOrderHeaderList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
