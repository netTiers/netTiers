
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesOrderHeader typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesOrderHeaderDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesOrderHeaderDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesOrderHeader _currentSalesOrderHeader = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesOrderHeaderDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesOrderHeaderErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesOrderHeaderBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the SalesOrderId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesOrderIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the RevisionNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRevisionNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OrderDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOrderDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DueDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDueDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ShipDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShipDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Status property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStatusDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OnlineOrderFlag property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxOnlineOrderFlagDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalesOrderNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesOrderNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PurchaseOrderNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPurchaseOrderNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AccountNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAccountNumberDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the CustomerId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCustomerIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ContactId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxContactIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the SalesPersonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSalesPersonIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the TerritoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxTerritoryIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the BillToAddressId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxBillToAddressIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ShipToAddressId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxShipToAddressIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ShipMethodId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxShipMethodIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the CreditCardId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCreditCardIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CreditCardApprovalCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCreditCardApprovalCodeDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the CurrencyRateId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCurrencyRateIdDataGridViewColumn;
		
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
		/// the DGV column associated with the Comment property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCommentDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Address> _BillToAddressIdList;
		
		/// <summary> 
		/// The list of selectable Address
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Address> BillToAddressIdList
		{
			get {return this._BillToAddressIdList;}
			set 
			{
				this._BillToAddressIdList = value;
				this.uxBillToAddressIdDataGridViewColumn.DataSource = null;
				this.uxBillToAddressIdDataGridViewColumn.DataSource = this._BillToAddressIdList;
			}
		}
		
		private bool _allowNewItemInBillToAddressIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Address
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInBillToAddressIdList
		{
			get { return _allowNewItemInBillToAddressIdList;}
			set
			{
				this._allowNewItemInBillToAddressIdList = value;
				this.uxBillToAddressIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Address> _ShipToAddressIdList;
		
		/// <summary> 
		/// The list of selectable Address
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Address> ShipToAddressIdList
		{
			get {return this._ShipToAddressIdList;}
			set 
			{
				this._ShipToAddressIdList = value;
				this.uxShipToAddressIdDataGridViewColumn.DataSource = null;
				this.uxShipToAddressIdDataGridViewColumn.DataSource = this._ShipToAddressIdList;
			}
		}
		
		private bool _allowNewItemInShipToAddressIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Address
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInShipToAddressIdList
		{
			get { return _allowNewItemInShipToAddressIdList;}
			set
			{
				this._allowNewItemInShipToAddressIdList = value;
				this.uxShipToAddressIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Contact> _ContactIdList;
		
		/// <summary> 
		/// The list of selectable Contact
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Contact> ContactIdList
		{
			get {return this._ContactIdList;}
			set 
			{
				this._ContactIdList = value;
				this.uxContactIdDataGridViewColumn.DataSource = null;
				this.uxContactIdDataGridViewColumn.DataSource = this._ContactIdList;
			}
		}
		
		private bool _allowNewItemInContactIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Contact
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactIdList
		{
			get { return _allowNewItemInContactIdList;}
			set
			{
				this._allowNewItemInContactIdList = value;
				this.uxContactIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.CreditCard> _CreditCardIdList;
		
		/// <summary> 
		/// The list of selectable CreditCard
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.CreditCard> CreditCardIdList
		{
			get {return this._CreditCardIdList;}
			set 
			{
				this._CreditCardIdList = value;
				this.uxCreditCardIdDataGridViewColumn.DataSource = null;
				this.uxCreditCardIdDataGridViewColumn.DataSource = this._CreditCardIdList;
			}
		}
		
		private bool _allowNewItemInCreditCardIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of CreditCard
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCreditCardIdList
		{
			get { return _allowNewItemInCreditCardIdList;}
			set
			{
				this._allowNewItemInCreditCardIdList = value;
				this.uxCreditCardIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.CurrencyRate> _CurrencyRateIdList;
		
		/// <summary> 
		/// The list of selectable CurrencyRate
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.CurrencyRate> CurrencyRateIdList
		{
			get {return this._CurrencyRateIdList;}
			set 
			{
				this._CurrencyRateIdList = value;
				this.uxCurrencyRateIdDataGridViewColumn.DataSource = null;
				this.uxCurrencyRateIdDataGridViewColumn.DataSource = this._CurrencyRateIdList;
			}
		}
		
		private bool _allowNewItemInCurrencyRateIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of CurrencyRate
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCurrencyRateIdList
		{
			get { return _allowNewItemInCurrencyRateIdList;}
			set
			{
				this._allowNewItemInCurrencyRateIdList = value;
				this.uxCurrencyRateIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
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
		
				
		private Entities.TList<Entities.SalesPerson> _SalesPersonIdList;
		
		/// <summary> 
		/// The list of selectable SalesPerson
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SalesPerson> SalesPersonIdList
		{
			get {return this._SalesPersonIdList;}
			set 
			{
				this._SalesPersonIdList = value;
				this.uxSalesPersonIdDataGridViewColumn.DataSource = null;
				this.uxSalesPersonIdDataGridViewColumn.DataSource = this._SalesPersonIdList;
			}
		}
		
		private bool _allowNewItemInSalesPersonIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of SalesPerson
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesPersonIdList
		{
			get { return _allowNewItemInSalesPersonIdList;}
			set
			{
				this._allowNewItemInSalesPersonIdList = value;
				this.uxSalesPersonIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.SalesTerritory> _TerritoryIdList;
		
		/// <summary> 
		/// The list of selectable SalesTerritory
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SalesTerritory> TerritoryIdList
		{
			get {return this._TerritoryIdList;}
			set 
			{
				this._TerritoryIdList = value;
				this.uxTerritoryIdDataGridViewColumn.DataSource = null;
				this.uxTerritoryIdDataGridViewColumn.DataSource = this._TerritoryIdList;
			}
		}
		
		private bool _allowNewItemInTerritoryIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of SalesTerritory
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInTerritoryIdList
		{
			get { return _allowNewItemInTerritoryIdList;}
			set
			{
				this._allowNewItemInTerritoryIdList = value;
				this.uxTerritoryIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SalesOrderHeader> _SalesOrderHeaderList;
				
		/// <summary> 
		/// The list of SalesOrderHeader to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesOrderHeader> SalesOrderHeaderList
		{
			get {return this._SalesOrderHeaderList;}
			set
			{
				this._SalesOrderHeaderList = value;
				this.uxSalesOrderHeaderBindingSource.DataSource = null;
				this.uxSalesOrderHeaderBindingSource.DataSource = value;
				this.uxSalesOrderHeaderDataGridView.DataSource = null;
				this.uxSalesOrderHeaderDataGridView.DataSource = this.uxSalesOrderHeaderBindingSource;				
				//this.uxSalesOrderHeaderBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesOrderHeaderBindingSource_ListChanged);
				this.uxSalesOrderHeaderBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesOrderHeaderBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesOrderHeaderBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesOrderHeader = uxSalesOrderHeaderBindingSource.Current as Entities.SalesOrderHeader;
			
			if (_currentSalesOrderHeader != null)
			{
				_currentSalesOrderHeader.Validate();
			}
			//_SalesOrderHeader.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesOrderHeaderBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesOrderHeader"/> instance.
		/// </summary>
		public Entities.SalesOrderHeader SelectedSalesOrderHeader
		{
			get {return this._currentSalesOrderHeader;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesOrderHeaderDataGridView.VirtualMode;}
			set
			{
				this.uxSalesOrderHeaderDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesOrderHeaderDataGridView.AllowUserToAddRows;}
			set {this.uxSalesOrderHeaderDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesOrderHeaderDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesOrderHeaderDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesOrderHeaderDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesOrderHeaderDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesOrderHeaderDataGridViewBase"/> class.
		/// </summary>
		public SalesOrderHeaderDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesOrderHeaderDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesOrderHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesOrderHeaderErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSalesOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRevisionNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxOrderDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDueDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxShipDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStatusDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxOnlineOrderFlagDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxSalesOrderNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPurchaseOrderNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAccountNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCustomerIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxContactIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSalesPersonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxTerritoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxBillToAddressIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxShipToAddressIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxShipMethodIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxCreditCardIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxCreditCardApprovalCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCurrencyRateIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSubTotalDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTaxAmtDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFreightDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTotalDueDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCommentDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxBillToAddressIdBindingSource = new AddressBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxBillToAddressIdBindingSource)).BeginInit();
			//this.uxShipToAddressIdBindingSource = new AddressBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxShipToAddressIdBindingSource)).BeginInit();
			//this.uxContactIdBindingSource = new ContactBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).BeginInit();
			//this.uxCreditCardIdBindingSource = new CreditCardBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCreditCardIdBindingSource)).BeginInit();
			//this.uxCurrencyRateIdBindingSource = new CurrencyRateBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCurrencyRateIdBindingSource)).BeginInit();
			//this.uxCustomerIdBindingSource = new CustomerBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).BeginInit();
			//this.uxSalesPersonIdBindingSource = new SalesPersonBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).BeginInit();
			//this.uxTerritoryIdBindingSource = new SalesTerritoryBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).BeginInit();
			//this.uxShipMethodIdBindingSource = new ShipMethodBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxShipMethodIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesOrderHeaderErrorProvider
			// 
			this.uxSalesOrderHeaderErrorProvider.ContainerControl = this;
			this.uxSalesOrderHeaderErrorProvider.DataSource = this.uxSalesOrderHeaderBindingSource;						
			// 
			// uxSalesOrderHeaderDataGridView
			// 
			this.uxSalesOrderHeaderDataGridView.AutoGenerateColumns = false;
			this.uxSalesOrderHeaderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesOrderHeaderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSalesOrderIdDataGridViewColumn,
		this.uxRevisionNumberDataGridViewColumn,
		this.uxOrderDateDataGridViewColumn,
		this.uxDueDateDataGridViewColumn,
		this.uxShipDateDataGridViewColumn,
		this.uxStatusDataGridViewColumn,
		this.uxOnlineOrderFlagDataGridViewColumn,
		this.uxSalesOrderNumberDataGridViewColumn,
		this.uxPurchaseOrderNumberDataGridViewColumn,
		this.uxAccountNumberDataGridViewColumn,
		this.uxCustomerIdDataGridViewColumn,
		this.uxContactIdDataGridViewColumn,
		this.uxSalesPersonIdDataGridViewColumn,
		this.uxTerritoryIdDataGridViewColumn,
		this.uxBillToAddressIdDataGridViewColumn,
		this.uxShipToAddressIdDataGridViewColumn,
		this.uxShipMethodIdDataGridViewColumn,
		this.uxCreditCardIdDataGridViewColumn,
		this.uxCreditCardApprovalCodeDataGridViewColumn,
		this.uxCurrencyRateIdDataGridViewColumn,
		this.uxSubTotalDataGridViewColumn,
		this.uxTaxAmtDataGridViewColumn,
		this.uxFreightDataGridViewColumn,
		this.uxTotalDueDataGridViewColumn,
		this.uxCommentDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesOrderHeaderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesOrderHeaderDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesOrderHeaderDataGridView.Name = "uxSalesOrderHeaderDataGridView";
			this.uxSalesOrderHeaderDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesOrderHeaderDataGridView.TabIndex = 0;	
			this.uxSalesOrderHeaderDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesOrderHeaderDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesOrderHeaderDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesOrderHeaderDataGridViewDataError);
			this.uxSalesOrderHeaderDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesOrderHeaderDataGridViewCellValueNeeded);
			this.uxSalesOrderHeaderDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesOrderHeaderDataGridViewCellValuePushed);
			
			//
			// uxSalesOrderIdDataGridViewColumn
			//
			this.uxSalesOrderIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesOrderIdDataGridViewColumn.DataPropertyName = "SalesOrderId";
			this.uxSalesOrderIdDataGridViewColumn.HeaderText = "SalesOrderId";
			this.uxSalesOrderIdDataGridViewColumn.Name = "uxSalesOrderIdDataGridViewColumn";
			this.uxSalesOrderIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesOrderIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesOrderIdDataGridViewColumn.ReadOnly = true;		
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
			// uxDueDateDataGridViewColumn
			//
			this.uxDueDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDueDateDataGridViewColumn.DataPropertyName = "DueDate";
			this.uxDueDateDataGridViewColumn.HeaderText = "DueDate";
			this.uxDueDateDataGridViewColumn.Name = "uxDueDateDataGridViewColumn";
			this.uxDueDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDueDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDueDateDataGridViewColumn.ReadOnly = false;		
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
			// uxOnlineOrderFlagDataGridViewColumn
			//
			this.uxOnlineOrderFlagDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxOnlineOrderFlagDataGridViewColumn.DataPropertyName = "OnlineOrderFlag";
			this.uxOnlineOrderFlagDataGridViewColumn.HeaderText = "OnlineOrderFlag";
			this.uxOnlineOrderFlagDataGridViewColumn.Name = "uxOnlineOrderFlagDataGridViewColumn";
			this.uxOnlineOrderFlagDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxOnlineOrderFlagDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxOnlineOrderFlagDataGridViewColumn.ReadOnly = false;		
			//
			// uxSalesOrderNumberDataGridViewColumn
			//
			this.uxSalesOrderNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesOrderNumberDataGridViewColumn.DataPropertyName = "SalesOrderNumber";
			this.uxSalesOrderNumberDataGridViewColumn.HeaderText = "SalesOrderNumber";
			this.uxSalesOrderNumberDataGridViewColumn.Name = "uxSalesOrderNumberDataGridViewColumn";
			this.uxSalesOrderNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesOrderNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesOrderNumberDataGridViewColumn.ReadOnly = true;		
			//
			// uxPurchaseOrderNumberDataGridViewColumn
			//
			this.uxPurchaseOrderNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPurchaseOrderNumberDataGridViewColumn.DataPropertyName = "PurchaseOrderNumber";
			this.uxPurchaseOrderNumberDataGridViewColumn.HeaderText = "PurchaseOrderNumber";
			this.uxPurchaseOrderNumberDataGridViewColumn.Name = "uxPurchaseOrderNumberDataGridViewColumn";
			this.uxPurchaseOrderNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPurchaseOrderNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPurchaseOrderNumberDataGridViewColumn.ReadOnly = false;		
			//
			// uxAccountNumberDataGridViewColumn
			//
			this.uxAccountNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAccountNumberDataGridViewColumn.DataPropertyName = "AccountNumber";
			this.uxAccountNumberDataGridViewColumn.HeaderText = "AccountNumber";
			this.uxAccountNumberDataGridViewColumn.Name = "uxAccountNumberDataGridViewColumn";
			this.uxAccountNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAccountNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAccountNumberDataGridViewColumn.ReadOnly = false;		
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
			// uxContactIdDataGridViewColumn
			//
			this.uxContactIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxContactIdDataGridViewColumn.DataPropertyName = "ContactId";
			this.uxContactIdDataGridViewColumn.HeaderText = "ContactId";
			this.uxContactIdDataGridViewColumn.Name = "uxContactIdDataGridViewColumn";
			this.uxContactIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxContactIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxContactIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxSalesPersonIdDataGridViewColumn
			//
			this.uxSalesPersonIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesPersonIdDataGridViewColumn.DataPropertyName = "SalesPersonId";
			this.uxSalesPersonIdDataGridViewColumn.HeaderText = "SalesPersonId";
			this.uxSalesPersonIdDataGridViewColumn.Name = "uxSalesPersonIdDataGridViewColumn";
			this.uxSalesPersonIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesPersonIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesPersonIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxTerritoryIdDataGridViewColumn
			//
			this.uxTerritoryIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTerritoryIdDataGridViewColumn.DataPropertyName = "TerritoryId";
			this.uxTerritoryIdDataGridViewColumn.HeaderText = "TerritoryId";
			this.uxTerritoryIdDataGridViewColumn.Name = "uxTerritoryIdDataGridViewColumn";
			this.uxTerritoryIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTerritoryIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTerritoryIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxBillToAddressIdDataGridViewColumn
			//
			this.uxBillToAddressIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBillToAddressIdDataGridViewColumn.DataPropertyName = "BillToAddressId";
			this.uxBillToAddressIdDataGridViewColumn.HeaderText = "BillToAddressId";
			this.uxBillToAddressIdDataGridViewColumn.Name = "uxBillToAddressIdDataGridViewColumn";
			this.uxBillToAddressIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBillToAddressIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBillToAddressIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxShipToAddressIdDataGridViewColumn
			//
			this.uxShipToAddressIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShipToAddressIdDataGridViewColumn.DataPropertyName = "ShipToAddressId";
			this.uxShipToAddressIdDataGridViewColumn.HeaderText = "ShipToAddressId";
			this.uxShipToAddressIdDataGridViewColumn.Name = "uxShipToAddressIdDataGridViewColumn";
			this.uxShipToAddressIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShipToAddressIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShipToAddressIdDataGridViewColumn.ReadOnly = false;		
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
			// uxCreditCardIdDataGridViewColumn
			//
			this.uxCreditCardIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCreditCardIdDataGridViewColumn.DataPropertyName = "CreditCardId";
			this.uxCreditCardIdDataGridViewColumn.HeaderText = "CreditCardId";
			this.uxCreditCardIdDataGridViewColumn.Name = "uxCreditCardIdDataGridViewColumn";
			this.uxCreditCardIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCreditCardIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCreditCardIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxCreditCardApprovalCodeDataGridViewColumn
			//
			this.uxCreditCardApprovalCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCreditCardApprovalCodeDataGridViewColumn.DataPropertyName = "CreditCardApprovalCode";
			this.uxCreditCardApprovalCodeDataGridViewColumn.HeaderText = "CreditCardApprovalCode";
			this.uxCreditCardApprovalCodeDataGridViewColumn.Name = "uxCreditCardApprovalCodeDataGridViewColumn";
			this.uxCreditCardApprovalCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCreditCardApprovalCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCreditCardApprovalCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxCurrencyRateIdDataGridViewColumn
			//
			this.uxCurrencyRateIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCurrencyRateIdDataGridViewColumn.DataPropertyName = "CurrencyRateId";
			this.uxCurrencyRateIdDataGridViewColumn.HeaderText = "CurrencyRateId";
			this.uxCurrencyRateIdDataGridViewColumn.Name = "uxCurrencyRateIdDataGridViewColumn";
			this.uxCurrencyRateIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCurrencyRateIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCurrencyRateIdDataGridViewColumn.ReadOnly = false;		
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
			// uxCommentDataGridViewColumn
			//
			this.uxCommentDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCommentDataGridViewColumn.DataPropertyName = "Comment";
			this.uxCommentDataGridViewColumn.HeaderText = "Comment";
			this.uxCommentDataGridViewColumn.Name = "uxCommentDataGridViewColumn";
			this.uxCommentDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCommentDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCommentDataGridViewColumn.ReadOnly = false;		
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
			// uxBillToAddressIdDataGridViewColumn
			//				
			this.uxBillToAddressIdDataGridViewColumn.DisplayMember = "AddressLine1";	
			this.uxBillToAddressIdDataGridViewColumn.ValueMember = "AddressId";	
			this.uxBillToAddressIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxBillToAddressIdDataGridViewColumn.DataSource = uxBillToAddressIdBindingSource;				
				
			//
			// uxShipToAddressIdDataGridViewColumn
			//				
			this.uxShipToAddressIdDataGridViewColumn.DisplayMember = "AddressLine1";	
			this.uxShipToAddressIdDataGridViewColumn.ValueMember = "AddressId";	
			this.uxShipToAddressIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxShipToAddressIdDataGridViewColumn.DataSource = uxShipToAddressIdBindingSource;				
				
			//
			// uxContactIdDataGridViewColumn
			//				
			this.uxContactIdDataGridViewColumn.DisplayMember = "NameStyle";	
			this.uxContactIdDataGridViewColumn.ValueMember = "ContactId";	
			this.uxContactIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxContactIdDataGridViewColumn.DataSource = uxContactIdBindingSource;				
				
			//
			// uxCreditCardIdDataGridViewColumn
			//				
			this.uxCreditCardIdDataGridViewColumn.DisplayMember = "CardType";	
			this.uxCreditCardIdDataGridViewColumn.ValueMember = "CreditCardId";	
			this.uxCreditCardIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCreditCardIdDataGridViewColumn.DataSource = uxCreditCardIdBindingSource;				
				
			//
			// uxCurrencyRateIdDataGridViewColumn
			//				
			this.uxCurrencyRateIdDataGridViewColumn.DisplayMember = "CurrencyRateDate";	
			this.uxCurrencyRateIdDataGridViewColumn.ValueMember = "CurrencyRateId";	
			this.uxCurrencyRateIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCurrencyRateIdDataGridViewColumn.DataSource = uxCurrencyRateIdBindingSource;				
				
			//
			// uxCustomerIdDataGridViewColumn
			//				
			this.uxCustomerIdDataGridViewColumn.DisplayMember = "TerritoryId";	
			this.uxCustomerIdDataGridViewColumn.ValueMember = "CustomerId";	
			this.uxCustomerIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCustomerIdDataGridViewColumn.DataSource = uxCustomerIdBindingSource;				
				
			//
			// uxSalesPersonIdDataGridViewColumn
			//				
			this.uxSalesPersonIdDataGridViewColumn.DisplayMember = "TerritoryId";	
			this.uxSalesPersonIdDataGridViewColumn.ValueMember = "SalesPersonId";	
			this.uxSalesPersonIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSalesPersonIdDataGridViewColumn.DataSource = uxSalesPersonIdBindingSource;				
				
			//
			// uxTerritoryIdDataGridViewColumn
			//				
			this.uxTerritoryIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxTerritoryIdDataGridViewColumn.ValueMember = "TerritoryId";	
			this.uxTerritoryIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxTerritoryIdDataGridViewColumn.DataSource = uxTerritoryIdBindingSource;				
				
			//
			// uxShipMethodIdDataGridViewColumn
			//				
			this.uxShipMethodIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxShipMethodIdDataGridViewColumn.ValueMember = "ShipMethodId";	
			this.uxShipMethodIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxShipMethodIdDataGridViewColumn.DataSource = uxShipMethodIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxSalesOrderHeaderDataGridView);
			this.Name = "SalesOrderHeaderDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxBillToAddressIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxShipToAddressIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxCreditCardIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxCurrencyRateIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxShipMethodIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderBindingSource)).EndInit();
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
				SalesOrderHeaderDataGridViewEventArgs args = new SalesOrderHeaderDataGridViewEventArgs();
				args.SalesOrderHeader = _currentSalesOrderHeader;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesOrderHeaderDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesOrderHeader	_SalesOrderHeader;
	
			/// <summary>
			/// the  Entities.SalesOrderHeader instance.
			/// </summary>
			public Entities.SalesOrderHeader SalesOrderHeader
			{
				get { return _SalesOrderHeader; }
				set { _SalesOrderHeader = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesOrderHeaderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderHeaderDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesOrderHeaderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderHeaderDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesOrderHeaderDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesOrderIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].SalesOrderId;
						break;
					case "uxRevisionNumberDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].RevisionNumber;
						break;
					case "uxOrderDateDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].OrderDate;
						break;
					case "uxDueDateDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].DueDate;
						break;
					case "uxShipDateDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].ShipDate;
						break;
					case "uxStatusDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].Status;
						break;
					case "uxOnlineOrderFlagDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].OnlineOrderFlag;
						break;
					case "uxSalesOrderNumberDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].SalesOrderNumber;
						break;
					case "uxPurchaseOrderNumberDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].PurchaseOrderNumber;
						break;
					case "uxAccountNumberDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].AccountNumber;
						break;
					case "uxCustomerIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].CustomerId;
						break;
					case "uxContactIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].ContactId;
						break;
					case "uxSalesPersonIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].SalesPersonId;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].TerritoryId;
						break;
					case "uxBillToAddressIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].BillToAddressId;
						break;
					case "uxShipToAddressIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].ShipToAddressId;
						break;
					case "uxShipMethodIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].ShipMethodId;
						break;
					case "uxCreditCardIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].CreditCardId;
						break;
					case "uxCreditCardApprovalCodeDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].CreditCardApprovalCode;
						break;
					case "uxCurrencyRateIdDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].CurrencyRateId;
						break;
					case "uxSubTotalDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].SubTotal;
						break;
					case "uxTaxAmtDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].TaxAmt;
						break;
					case "uxFreightDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].Freight;
						break;
					case "uxTotalDueDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].TotalDue;
						break;
					case "uxCommentDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].Comment;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesOrderHeaderList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesOrderHeaderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderHeaderDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesOrderHeaderDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesOrderIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].SalesOrderId = (System.Int32)e.Value;
						break;
					case "uxRevisionNumberDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].RevisionNumber = (System.Byte)e.Value;
						break;
					case "uxOrderDateDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].OrderDate = (System.DateTime)e.Value;
						break;
					case "uxDueDateDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].DueDate = (System.DateTime)e.Value;
						break;
					case "uxShipDateDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].ShipDate = (System.DateTime?)e.Value;
						break;
					case "uxStatusDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].Status = (System.Byte)e.Value;
						break;
					case "uxOnlineOrderFlagDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].OnlineOrderFlag = (System.Boolean)e.Value;
						break;
					case "uxSalesOrderNumberDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].SalesOrderNumber = (System.String)e.Value;
						break;
					case "uxPurchaseOrderNumberDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].PurchaseOrderNumber = (System.String)e.Value;
						break;
					case "uxAccountNumberDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].AccountNumber = (System.String)e.Value;
						break;
					case "uxCustomerIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].CustomerId = (System.Int32)e.Value;
						break;
					case "uxContactIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].ContactId = (System.Int32)e.Value;
						break;
					case "uxSalesPersonIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].SalesPersonId = (System.Int32?)e.Value;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].TerritoryId = (System.Int32?)e.Value;
						break;
					case "uxBillToAddressIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].BillToAddressId = (System.Int32)e.Value;
						break;
					case "uxShipToAddressIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].ShipToAddressId = (System.Int32)e.Value;
						break;
					case "uxShipMethodIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].ShipMethodId = (System.Int32)e.Value;
						break;
					case "uxCreditCardIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].CreditCardId = (System.Int32?)e.Value;
						break;
					case "uxCreditCardApprovalCodeDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].CreditCardApprovalCode = (System.String)e.Value;
						break;
					case "uxCurrencyRateIdDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].CurrencyRateId = (System.Int32?)e.Value;
						break;
					case "uxSubTotalDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].SubTotal = (System.Decimal)e.Value;
						break;
					case "uxTaxAmtDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].TaxAmt = (System.Decimal)e.Value;
						break;
					case "uxFreightDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].Freight = (System.Decimal)e.Value;
						break;
					case "uxTotalDueDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].TotalDue = (System.Decimal)e.Value;
						break;
					case "uxCommentDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].Comment = (System.String)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesOrderHeaderList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
