
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.PurchaseOrderHeader"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class PurchaseOrderHeaderEditControlBase : System.Windows.Forms.UserControl
	{
		#region Fields
		
		//private System.Windows.Forms.TableLayoutPanel uxTableLayoutPanel;
		/// <summary>
		/// The ErrorProvider for the Entity;
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxErrorProvider;
		
		/// <summary>
		/// The BindingSource for the entity.
		///</summary>
		protected System.Windows.Forms.BindingSource uxBindingSource;
						
		
		/// <summary>
		/// TextBox for the PurchaseOrderId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPurchaseOrderId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PurchaseOrderId property.
		/// </summary>
		protected System.Windows.Forms.Label uxPurchaseOrderIdLabel;
		
		/// <summary>
		/// TextBox for the RevisionNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRevisionNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the RevisionNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxRevisionNumberLabel;
		
		/// <summary>
		/// TextBox for the Status property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStatus;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Status property.
		/// </summary>
		protected System.Windows.Forms.Label uxStatusLabel;
		
		/// <summary>
		/// ComboBox for the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxEmployeeId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmployeeIdLabel;
		
		/// <summary>
		/// ComboBox for the VendorId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxVendorId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the VendorId property.
		/// </summary>
		protected System.Windows.Forms.Label uxVendorIdLabel;
		
		/// <summary>
		/// ComboBox for the ShipMethodId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxShipMethodId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShipMethodId property.
		/// </summary>
		protected System.Windows.Forms.Label uxShipMethodIdLabel;
		
		/// <summary>
		/// DataTimePicker for the OrderDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxOrderDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OrderDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxOrderDateLabel;
		
		/// <summary>
		/// DataTimePicker for the ShipDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxShipDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShipDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxShipDateLabel;
		
		/// <summary>
		/// TextBox for the SubTotal property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSubTotal;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SubTotal property.
		/// </summary>
		protected System.Windows.Forms.Label uxSubTotalLabel;
		
		/// <summary>
		/// TextBox for the TaxAmt property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTaxAmt;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TaxAmt property.
		/// </summary>
		protected System.Windows.Forms.Label uxTaxAmtLabel;
		
		/// <summary>
		/// TextBox for the Freight property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxFreight;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Freight property.
		/// </summary>
		protected System.Windows.Forms.Label uxFreightLabel;
		
		/// <summary>
		/// TextBox for the TotalDue property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTotalDue;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TotalDue property.
		/// </summary>
		protected System.Windows.Forms.Label uxTotalDueLabel;
		
		/// <summary>
		/// DataTimePicker for the ModifiedDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxModifiedDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ModifiedDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxModifiedDateLabel;
		#endregion
		
		#region Main entity
		private Entities.PurchaseOrderHeader _PurchaseOrderHeader;
		/// <summary>
		/// Gets or sets the <see cref="Entities.PurchaseOrderHeader"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.PurchaseOrderHeader"/> instance.</value>
		public Entities.PurchaseOrderHeader PurchaseOrderHeader
		{
			get {return this._PurchaseOrderHeader;}
			set
			{
				this._PurchaseOrderHeader = value;
				if (value != null) 
				{
					this.uxBindingSource.DataSource = value;
					BindControls();
				}			
				
			}
		}
		#endregion
		
		/// <summary>
		/// Binds the controls.
		/// </summary>
		private void BindControls()
		{
			this.uxPurchaseOrderId.DataBindings.Clear();
			this.uxPurchaseOrderId.DataBindings.Add("Text", this.uxBindingSource, "PurchaseOrderId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRevisionNumber.DataBindings.Clear();
			this.uxRevisionNumber.DataBindings.Add("Text", this.uxBindingSource, "RevisionNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStatus.DataBindings.Clear();
			this.uxStatus.DataBindings.Add("Text", this.uxBindingSource, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmployeeId.DataBindings.Clear();
			this.uxEmployeeId.DataBindings.Add("SelectedValue", this.uxBindingSource, "EmployeeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxVendorId.DataBindings.Clear();
			this.uxVendorId.DataBindings.Add("SelectedValue", this.uxBindingSource, "VendorId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShipMethodId.DataBindings.Clear();
			this.uxShipMethodId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ShipMethodId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOrderDate.DataBindings.Clear();
			this.uxOrderDate.DataBindings.Add("Value", this.uxBindingSource, "OrderDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShipDate.DataBindings.Clear();
			this.uxShipDate.DataBindings.Add("Value", this.uxBindingSource, "ShipDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSubTotal.DataBindings.Clear();
			this.uxSubTotal.DataBindings.Add("Text", this.uxBindingSource, "SubTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTaxAmt.DataBindings.Clear();
			this.uxTaxAmt.DataBindings.Add("Text", this.uxBindingSource, "TaxAmt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFreight.DataBindings.Clear();
			this.uxFreight.DataBindings.Add("Text", this.uxBindingSource, "Freight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTotalDue.DataBindings.Clear();
			this.uxTotalDue.DataBindings.Add("Text", this.uxBindingSource, "TotalDue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="PurchaseOrderHeaderEditControlBase"/> class.
		/// </summary>
		public PurchaseOrderHeaderEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_PurchaseOrderHeader != null) _PurchaseOrderHeader.Validate();
		}	
				
		/// <summary>
		/// Initializes the component.
		/// </summary>
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.uxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxBindingSource = new System.Windows.Forms.BindingSource(this.components);
			
			//this.uxTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.uxPurchaseOrderId = new System.Windows.Forms.TextBox();
			uxPurchaseOrderIdLabel = new System.Windows.Forms.Label();
			this.uxRevisionNumber = new System.Windows.Forms.TextBox();
			uxRevisionNumberLabel = new System.Windows.Forms.Label();
			this.uxStatus = new System.Windows.Forms.TextBox();
			uxStatusLabel = new System.Windows.Forms.Label();
			this.uxEmployeeId = new System.Windows.Forms.ComboBox();
			uxEmployeeIdLabel = new System.Windows.Forms.Label();
			this.uxVendorId = new System.Windows.Forms.ComboBox();
			uxVendorIdLabel = new System.Windows.Forms.Label();
			this.uxShipMethodId = new System.Windows.Forms.ComboBox();
			uxShipMethodIdLabel = new System.Windows.Forms.Label();
			this.uxOrderDate = new System.Windows.Forms.DateTimePicker();
			uxOrderDateLabel = new System.Windows.Forms.Label();
			this.uxShipDate = new System.Windows.Forms.DateTimePicker();
			uxShipDateLabel = new System.Windows.Forms.Label();
			this.uxSubTotal = new System.Windows.Forms.TextBox();
			uxSubTotalLabel = new System.Windows.Forms.Label();
			this.uxTaxAmt = new System.Windows.Forms.TextBox();
			uxTaxAmtLabel = new System.Windows.Forms.Label();
			this.uxFreight = new System.Windows.Forms.TextBox();
			uxFreightLabel = new System.Windows.Forms.Label();
			this.uxTotalDue = new System.Windows.Forms.TextBox();
			uxTotalDueLabel = new System.Windows.Forms.Label();
			this.uxModifiedDate = new System.Windows.Forms.DateTimePicker();
			uxModifiedDateLabel = new System.Windows.Forms.Label();
			
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).BeginInit();
			this.SuspendLayout();
			
			// 
			// uxTableLayoutPanel
			// 
			//this.uxTableLayoutPanel.AutoSize = true;
			//this.uxTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			//this.uxTableLayoutPanel.ColumnCount = 2;
			//this.uxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			//this.uxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
			//this.uxTableLayoutPanel.Location = new System.Drawing.System.Drawing.Point(3, 3);
			//this.uxTableLayoutPanel.Name = "uxTableLayoutPanel";
			//this.uxTableLayoutPanel.RowCount = 2;
			//this.uxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			//this.uxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			//this.uxTableLayoutPanel.Size = new System.Drawing.Size(450, 50);
			//this.uxTableLayoutPanel.TabIndex = 0;
			
			//
			// uxErrorProvider
			//
			this.uxErrorProvider.ContainerControl = this;
			this.uxErrorProvider.DataSource = this.uxBindingSource;
			
			//
			// uxPurchaseOrderIdLabel
			//
			this.uxPurchaseOrderIdLabel.Name = "uxPurchaseOrderIdLabel";
			this.uxPurchaseOrderIdLabel.Text = "Purchase Order Id:";
			this.uxPurchaseOrderIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxPurchaseOrderIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchaseOrderIdLabel);			
			//
			// uxPurchaseOrderId
			//
			this.uxPurchaseOrderId.Name = "uxPurchaseOrderId";
            this.uxPurchaseOrderId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchaseOrderId);
			this.uxPurchaseOrderId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxPurchaseOrderId);
			//
			// uxRevisionNumberLabel
			//
			this.uxRevisionNumberLabel.Name = "uxRevisionNumberLabel";
			this.uxRevisionNumberLabel.Text = "Revision Number:";
			this.uxRevisionNumberLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxRevisionNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRevisionNumberLabel);			
			//
			// uxRevisionNumber
			//
			this.uxRevisionNumber.Name = "uxRevisionNumber";
			//this.uxTableLayoutPanel.Controls.Add(this.uxRevisionNumber);
			this.uxRevisionNumber.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxRevisionNumber);
			//
			// uxStatusLabel
			//
			this.uxStatusLabel.Name = "uxStatusLabel";
			this.uxStatusLabel.Text = "Status:";
			this.uxStatusLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxStatusLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStatusLabel);			
			//
			// uxStatus
			//
			this.uxStatus.Name = "uxStatus";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStatus);
			this.uxStatus.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxStatus);
			//
			// uxEmployeeIdLabel
			//
			this.uxEmployeeIdLabel.Name = "uxEmployeeIdLabel";
			this.uxEmployeeIdLabel.Text = "Employee Id:";
			this.uxEmployeeIdLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxEmployeeIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeIdLabel);			
			//
			// uxEmployeeId
			//
			this.uxEmployeeId.Name = "uxEmployeeId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeId);
			this.uxEmployeeId.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxEmployeeId);
			//
			// uxVendorIdLabel
			//
			this.uxVendorIdLabel.Name = "uxVendorIdLabel";
			this.uxVendorIdLabel.Text = "Vendor Id:";
			this.uxVendorIdLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxVendorIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxVendorIdLabel);			
			//
			// uxVendorId
			//
			this.uxVendorId.Name = "uxVendorId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxVendorId);
			this.uxVendorId.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxVendorId);
			//
			// uxShipMethodIdLabel
			//
			this.uxShipMethodIdLabel.Name = "uxShipMethodIdLabel";
			this.uxShipMethodIdLabel.Text = "Ship Method Id:";
			this.uxShipMethodIdLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxShipMethodIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipMethodIdLabel);			
			//
			// uxShipMethodId
			//
			this.uxShipMethodId.Name = "uxShipMethodId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipMethodId);
			this.uxShipMethodId.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxShipMethodId);
			//
			// uxOrderDateLabel
			//
			this.uxOrderDateLabel.Name = "uxOrderDateLabel";
			this.uxOrderDateLabel.Text = "Order Date:";
			this.uxOrderDateLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxOrderDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrderDateLabel);			
			//
			// uxOrderDate
			//
			this.uxOrderDate.Name = "uxOrderDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrderDate);
			this.uxOrderDate.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxOrderDate);
			//
			// uxShipDateLabel
			//
			this.uxShipDateLabel.Name = "uxShipDateLabel";
			this.uxShipDateLabel.Text = "Ship Date:";
			this.uxShipDateLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxShipDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipDateLabel);			
			//
			// uxShipDate
			//
			this.uxShipDate.Name = "uxShipDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipDate);
			this.uxShipDate.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxShipDate);
			//
			// uxSubTotalLabel
			//
			this.uxSubTotalLabel.Name = "uxSubTotalLabel";
			this.uxSubTotalLabel.Text = "Sub Total:";
			this.uxSubTotalLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxSubTotalLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSubTotalLabel);			
			//
			// uxSubTotal
			//
			this.uxSubTotal.Name = "uxSubTotal";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSubTotal);
			this.uxSubTotal.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxSubTotal);
			//
			// uxTaxAmtLabel
			//
			this.uxTaxAmtLabel.Name = "uxTaxAmtLabel";
			this.uxTaxAmtLabel.Text = "Tax Amt:";
			this.uxTaxAmtLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxTaxAmtLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTaxAmtLabel);			
			//
			// uxTaxAmt
			//
			this.uxTaxAmt.Name = "uxTaxAmt";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTaxAmt);
			this.uxTaxAmt.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxTaxAmt);
			//
			// uxFreightLabel
			//
			this.uxFreightLabel.Name = "uxFreightLabel";
			this.uxFreightLabel.Text = "Freight:";
			this.uxFreightLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxFreightLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFreightLabel);			
			//
			// uxFreight
			//
			this.uxFreight.Name = "uxFreight";
			//this.uxTableLayoutPanel.Controls.Add(this.uxFreight);
			this.uxFreight.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxFreight);
			//
			// uxTotalDueLabel
			//
			this.uxTotalDueLabel.Name = "uxTotalDueLabel";
			this.uxTotalDueLabel.Text = "Total Due:";
			this.uxTotalDueLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxTotalDueLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTotalDueLabel);			
			//
			// uxTotalDue
			//
			this.uxTotalDue.Name = "uxTotalDue";
            this.uxTotalDue.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTotalDue);
			this.uxTotalDue.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxTotalDue);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxEmployeeId
			//				
			this.uxEmployeeId.DisplayMember = "NationalIdNumber";	
			this.uxEmployeeId.ValueMember = "EmployeeId";	
			//
			// uxShipMethodId
			//				
			this.uxShipMethodId.DisplayMember = "Name";	
			this.uxShipMethodId.ValueMember = "ShipMethodId";	
			//
			// uxVendorId
			//				
			this.uxVendorId.DisplayMember = "AccountNumber";	
			this.uxVendorId.ValueMember = "VendorId";	
			// 
			// PurchaseOrderHeaderEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "PurchaseOrderHeaderEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Employee> _EmployeeIdList;
		
		/// <summary>
		/// The ComboBox associated with the EmployeeId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Employee> EmployeeIdList
		{
			get {return _EmployeeIdList;}
			set 
			{
				this._EmployeeIdList = value;
				this.uxEmployeeId.DataSource = null;
				this.uxEmployeeId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInEmployeeIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the EmployeeId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInEmployeeIdList
		{
			get { return _allowNewItemInEmployeeIdList;}
			set
			{
				this._allowNewItemInEmployeeIdList = value;
				this.uxEmployeeId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.ShipMethod> _ShipMethodIdList;
		
		/// <summary>
		/// The ComboBox associated with the ShipMethodId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.ShipMethod> ShipMethodIdList
		{
			get {return _ShipMethodIdList;}
			set 
			{
				this._ShipMethodIdList = value;
				this.uxShipMethodId.DataSource = null;
				this.uxShipMethodId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInShipMethodIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ShipMethodId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInShipMethodIdList
		{
			get { return _allowNewItemInShipMethodIdList;}
			set
			{
				this._allowNewItemInShipMethodIdList = value;
				this.uxShipMethodId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Vendor> _VendorIdList;
		
		/// <summary>
		/// The ComboBox associated with the VendorId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Vendor> VendorIdList
		{
			get {return _VendorIdList;}
			set 
			{
				this._VendorIdList = value;
				this.uxVendorId.DataSource = null;
				this.uxVendorId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInVendorIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the VendorId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInVendorIdList
		{
			get { return _allowNewItemInVendorIdList;}
			set
			{
				this._allowNewItemInVendorIdList = value;
				this.uxVendorId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxPurchaseOrderId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPurchaseOrderIdVisible
        {
            get { return this.uxPurchaseOrderId.Visible; }
            set
            {
                this.uxPurchaseOrderIdLabel.Visible = value;
                this.uxPurchaseOrderId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPurchaseOrderId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPurchaseOrderIdEnabled
        {
            get { return this.uxPurchaseOrderId.Enabled; }
            set
            {
                this.uxPurchaseOrderId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRevisionNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRevisionNumberVisible
        {
            get { return this.uxRevisionNumber.Visible; }
            set
            {
                this.uxRevisionNumberLabel.Visible = value;
                this.uxRevisionNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRevisionNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRevisionNumberEnabled
        {
            get { return this.uxRevisionNumber.Enabled; }
            set
            {
                this.uxRevisionNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStatus property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStatusVisible
        {
            get { return this.uxStatus.Visible; }
            set
            {
                this.uxStatusLabel.Visible = value;
                this.uxStatus.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStatus property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStatusEnabled
        {
            get { return this.uxStatus.Enabled; }
            set
            {
                this.uxStatus.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEmployeeIdVisible
        {
            get { return this.uxEmployeeId.Visible; }
            set
            {
                this.uxEmployeeIdLabel.Visible = value;
                this.uxEmployeeId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEmployeeIdEnabled
        {
            get { return this.uxEmployeeId.Enabled; }
            set
            {
                this.uxEmployeeId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxVendorId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxVendorIdVisible
        {
            get { return this.uxVendorId.Visible; }
            set
            {
                this.uxVendorIdLabel.Visible = value;
                this.uxVendorId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxVendorId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxVendorIdEnabled
        {
            get { return this.uxVendorId.Enabled; }
            set
            {
                this.uxVendorId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxShipMethodId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShipMethodIdVisible
        {
            get { return this.uxShipMethodId.Visible; }
            set
            {
                this.uxShipMethodIdLabel.Visible = value;
                this.uxShipMethodId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShipMethodId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShipMethodIdEnabled
        {
            get { return this.uxShipMethodId.Enabled; }
            set
            {
                this.uxShipMethodId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxOrderDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxOrderDateVisible
        {
            get { return this.uxOrderDate.Visible; }
            set
            {
                this.uxOrderDateLabel.Visible = value;
                this.uxOrderDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxOrderDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxOrderDateEnabled
        {
            get { return this.uxOrderDate.Enabled; }
            set
            {
                this.uxOrderDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxShipDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShipDateVisible
        {
            get { return this.uxShipDate.Visible; }
            set
            {
                this.uxShipDateLabel.Visible = value;
                this.uxShipDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShipDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShipDateEnabled
        {
            get { return this.uxShipDate.Enabled; }
            set
            {
                this.uxShipDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSubTotal property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSubTotalVisible
        {
            get { return this.uxSubTotal.Visible; }
            set
            {
                this.uxSubTotalLabel.Visible = value;
                this.uxSubTotal.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSubTotal property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSubTotalEnabled
        {
            get { return this.uxSubTotal.Enabled; }
            set
            {
                this.uxSubTotal.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTaxAmt property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTaxAmtVisible
        {
            get { return this.uxTaxAmt.Visible; }
            set
            {
                this.uxTaxAmtLabel.Visible = value;
                this.uxTaxAmt.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTaxAmt property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTaxAmtEnabled
        {
            get { return this.uxTaxAmt.Enabled; }
            set
            {
                this.uxTaxAmt.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFreight property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFreightVisible
        {
            get { return this.uxFreight.Visible; }
            set
            {
                this.uxFreightLabel.Visible = value;
                this.uxFreight.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFreight property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFreightEnabled
        {
            get { return this.uxFreight.Enabled; }
            set
            {
                this.uxFreight.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTotalDue property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTotalDueVisible
        {
            get { return this.uxTotalDue.Visible; }
            set
            {
                this.uxTotalDueLabel.Visible = value;
                this.uxTotalDue.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTotalDue property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTotalDueEnabled
        {
            get { return this.uxTotalDue.Enabled; }
            set
            {
                this.uxTotalDue.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxModifiedDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxModifiedDateVisible
        {
            get { return this.uxModifiedDate.Visible; }
            set
            {
                this.uxModifiedDateLabel.Visible = value;
                this.uxModifiedDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxModifiedDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxModifiedDateEnabled
        {
            get { return this.uxModifiedDate.Enabled; }
            set
            {
                this.uxModifiedDate.Enabled = value;
            }
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
	}
}
