
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.SalesOrderHeader"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesOrderHeaderEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the SalesOrderId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSalesOrderId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesOrderId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesOrderIdLabel;
		
		/// <summary>
		/// TextBox for the RevisionNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRevisionNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the RevisionNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxRevisionNumberLabel;
		
		/// <summary>
		/// DataTimePicker for the OrderDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxOrderDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OrderDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxOrderDateLabel;
		
		/// <summary>
		/// DataTimePicker for the DueDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxDueDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DueDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxDueDateLabel;
		
		/// <summary>
		/// DataTimePicker for the ShipDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxShipDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShipDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxShipDateLabel;
		
		/// <summary>
		/// TextBox for the Status property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStatus;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Status property.
		/// </summary>
		protected System.Windows.Forms.Label uxStatusLabel;
		
		/// <summary>
		/// CheckBox for the OnlineOrderFlag property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxOnlineOrderFlag;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OnlineOrderFlag property.
		/// </summary>
		protected System.Windows.Forms.Label uxOnlineOrderFlagLabel;
		
		/// <summary>
		/// TextBox for the SalesOrderNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSalesOrderNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesOrderNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesOrderNumberLabel;
		
		/// <summary>
		/// TextBox for the PurchaseOrderNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPurchaseOrderNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PurchaseOrderNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxPurchaseOrderNumberLabel;
		
		/// <summary>
		/// TextBox for the AccountNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAccountNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AccountNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxAccountNumberLabel;
		
		/// <summary>
		/// ComboBox for the CustomerId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxCustomerId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CustomerId property.
		/// </summary>
		protected System.Windows.Forms.Label uxCustomerIdLabel;
		
		/// <summary>
		/// ComboBox for the ContactId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxContactId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ContactId property.
		/// </summary>
		protected System.Windows.Forms.Label uxContactIdLabel;
		
		/// <summary>
		/// ComboBox for the SalesPersonId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxSalesPersonId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesPersonId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesPersonIdLabel;
		
		/// <summary>
		/// ComboBox for the TerritoryId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxTerritoryId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TerritoryId property.
		/// </summary>
		protected System.Windows.Forms.Label uxTerritoryIdLabel;
		
		/// <summary>
		/// ComboBox for the BillToAddressId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxBillToAddressId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the BillToAddressId property.
		/// </summary>
		protected System.Windows.Forms.Label uxBillToAddressIdLabel;
		
		/// <summary>
		/// ComboBox for the ShipToAddressId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxShipToAddressId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShipToAddressId property.
		/// </summary>
		protected System.Windows.Forms.Label uxShipToAddressIdLabel;
		
		/// <summary>
		/// ComboBox for the ShipMethodId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxShipMethodId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShipMethodId property.
		/// </summary>
		protected System.Windows.Forms.Label uxShipMethodIdLabel;
		
		/// <summary>
		/// ComboBox for the CreditCardId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxCreditCardId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreditCardId property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreditCardIdLabel;
		
		/// <summary>
		/// TextBox for the CreditCardApprovalCode property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCreditCardApprovalCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreditCardApprovalCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreditCardApprovalCodeLabel;
		
		/// <summary>
		/// ComboBox for the CurrencyRateId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxCurrencyRateId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CurrencyRateId property.
		/// </summary>
		protected System.Windows.Forms.Label uxCurrencyRateIdLabel;
		
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
		/// TextBox for the Comment property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxComment;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Comment property.
		/// </summary>
		protected System.Windows.Forms.Label uxCommentLabel;
		
		/// <summary>
		/// TextBox for the Rowguid property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRowguid;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Rowguid property.
		/// </summary>
		protected System.Windows.Forms.Label uxRowguidLabel;
		
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
		private Entities.SalesOrderHeader _SalesOrderHeader;
		/// <summary>
		/// Gets or sets the <see cref="Entities.SalesOrderHeader"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.SalesOrderHeader"/> instance.</value>
		public Entities.SalesOrderHeader SalesOrderHeader
		{
			get {return this._SalesOrderHeader;}
			set
			{
				this._SalesOrderHeader = value;
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
			this.uxSalesOrderId.DataBindings.Clear();
			this.uxSalesOrderId.DataBindings.Add("Text", this.uxBindingSource, "SalesOrderId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRevisionNumber.DataBindings.Clear();
			this.uxRevisionNumber.DataBindings.Add("Text", this.uxBindingSource, "RevisionNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOrderDate.DataBindings.Clear();
			this.uxOrderDate.DataBindings.Add("Value", this.uxBindingSource, "OrderDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDueDate.DataBindings.Clear();
			this.uxDueDate.DataBindings.Add("Value", this.uxBindingSource, "DueDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShipDate.DataBindings.Clear();
			this.uxShipDate.DataBindings.Add("Value", this.uxBindingSource, "ShipDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStatus.DataBindings.Clear();
			this.uxStatus.DataBindings.Add("Text", this.uxBindingSource, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOnlineOrderFlag.DataBindings.Clear();
			this.uxOnlineOrderFlag.DataBindings.Add("Checked", this.uxBindingSource, "OnlineOrderFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesOrderNumber.DataBindings.Clear();
			this.uxSalesOrderNumber.DataBindings.Add("Text", this.uxBindingSource, "SalesOrderNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPurchaseOrderNumber.DataBindings.Clear();
			this.uxPurchaseOrderNumber.DataBindings.Add("Text", this.uxBindingSource, "PurchaseOrderNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAccountNumber.DataBindings.Clear();
			this.uxAccountNumber.DataBindings.Add("Text", this.uxBindingSource, "AccountNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCustomerId.DataBindings.Clear();
			this.uxCustomerId.DataBindings.Add("SelectedValue", this.uxBindingSource, "CustomerId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxContactId.DataBindings.Clear();
			this.uxContactId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ContactId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesPersonId.DataBindings.Clear();
			this.uxSalesPersonId.DataBindings.Add("SelectedValue", this.uxBindingSource, "SalesPersonId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTerritoryId.DataBindings.Clear();
			this.uxTerritoryId.DataBindings.Add("SelectedValue", this.uxBindingSource, "TerritoryId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBillToAddressId.DataBindings.Clear();
			this.uxBillToAddressId.DataBindings.Add("SelectedValue", this.uxBindingSource, "BillToAddressId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShipToAddressId.DataBindings.Clear();
			this.uxShipToAddressId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ShipToAddressId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShipMethodId.DataBindings.Clear();
			this.uxShipMethodId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ShipMethodId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCreditCardId.DataBindings.Clear();
			this.uxCreditCardId.DataBindings.Add("SelectedValue", this.uxBindingSource, "CreditCardId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCreditCardApprovalCode.DataBindings.Clear();
			this.uxCreditCardApprovalCode.DataBindings.Add("Text", this.uxBindingSource, "CreditCardApprovalCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCurrencyRateId.DataBindings.Clear();
			this.uxCurrencyRateId.DataBindings.Add("SelectedValue", this.uxBindingSource, "CurrencyRateId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSubTotal.DataBindings.Clear();
			this.uxSubTotal.DataBindings.Add("Text", this.uxBindingSource, "SubTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTaxAmt.DataBindings.Clear();
			this.uxTaxAmt.DataBindings.Add("Text", this.uxBindingSource, "TaxAmt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFreight.DataBindings.Clear();
			this.uxFreight.DataBindings.Add("Text", this.uxBindingSource, "Freight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTotalDue.DataBindings.Clear();
			this.uxTotalDue.DataBindings.Add("Text", this.uxBindingSource, "TotalDue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxComment.DataBindings.Clear();
			this.uxComment.DataBindings.Add("Text", this.uxBindingSource, "Comment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SalesOrderHeaderEditControlBase"/> class.
		/// </summary>
		public SalesOrderHeaderEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_SalesOrderHeader != null) _SalesOrderHeader.Validate();
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
			this.uxSalesOrderId = new System.Windows.Forms.TextBox();
			uxSalesOrderIdLabel = new System.Windows.Forms.Label();
			this.uxRevisionNumber = new System.Windows.Forms.TextBox();
			uxRevisionNumberLabel = new System.Windows.Forms.Label();
			this.uxOrderDate = new System.Windows.Forms.DateTimePicker();
			uxOrderDateLabel = new System.Windows.Forms.Label();
			this.uxDueDate = new System.Windows.Forms.DateTimePicker();
			uxDueDateLabel = new System.Windows.Forms.Label();
			this.uxShipDate = new System.Windows.Forms.DateTimePicker();
			uxShipDateLabel = new System.Windows.Forms.Label();
			this.uxStatus = new System.Windows.Forms.TextBox();
			uxStatusLabel = new System.Windows.Forms.Label();
			this.uxOnlineOrderFlag = new System.Windows.Forms.CheckBox();
			uxOnlineOrderFlagLabel = new System.Windows.Forms.Label();
			this.uxSalesOrderNumber = new System.Windows.Forms.TextBox();
			uxSalesOrderNumberLabel = new System.Windows.Forms.Label();
			this.uxPurchaseOrderNumber = new System.Windows.Forms.TextBox();
			uxPurchaseOrderNumberLabel = new System.Windows.Forms.Label();
			this.uxAccountNumber = new System.Windows.Forms.TextBox();
			uxAccountNumberLabel = new System.Windows.Forms.Label();
			this.uxCustomerId = new System.Windows.Forms.ComboBox();
			uxCustomerIdLabel = new System.Windows.Forms.Label();
			this.uxContactId = new System.Windows.Forms.ComboBox();
			uxContactIdLabel = new System.Windows.Forms.Label();
			this.uxSalesPersonId = new System.Windows.Forms.ComboBox();
			uxSalesPersonIdLabel = new System.Windows.Forms.Label();
			this.uxTerritoryId = new System.Windows.Forms.ComboBox();
			uxTerritoryIdLabel = new System.Windows.Forms.Label();
			this.uxBillToAddressId = new System.Windows.Forms.ComboBox();
			uxBillToAddressIdLabel = new System.Windows.Forms.Label();
			this.uxShipToAddressId = new System.Windows.Forms.ComboBox();
			uxShipToAddressIdLabel = new System.Windows.Forms.Label();
			this.uxShipMethodId = new System.Windows.Forms.ComboBox();
			uxShipMethodIdLabel = new System.Windows.Forms.Label();
			this.uxCreditCardId = new System.Windows.Forms.ComboBox();
			uxCreditCardIdLabel = new System.Windows.Forms.Label();
			this.uxCreditCardApprovalCode = new System.Windows.Forms.TextBox();
			uxCreditCardApprovalCodeLabel = new System.Windows.Forms.Label();
			this.uxCurrencyRateId = new System.Windows.Forms.ComboBox();
			uxCurrencyRateIdLabel = new System.Windows.Forms.Label();
			this.uxSubTotal = new System.Windows.Forms.TextBox();
			uxSubTotalLabel = new System.Windows.Forms.Label();
			this.uxTaxAmt = new System.Windows.Forms.TextBox();
			uxTaxAmtLabel = new System.Windows.Forms.Label();
			this.uxFreight = new System.Windows.Forms.TextBox();
			uxFreightLabel = new System.Windows.Forms.Label();
			this.uxTotalDue = new System.Windows.Forms.TextBox();
			uxTotalDueLabel = new System.Windows.Forms.Label();
			this.uxComment = new System.Windows.Forms.TextBox();
			uxCommentLabel = new System.Windows.Forms.Label();
			this.uxRowguid = new System.Windows.Forms.TextBox();
			uxRowguidLabel = new System.Windows.Forms.Label();
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
			// uxSalesOrderIdLabel
			//
			this.uxSalesOrderIdLabel.Name = "uxSalesOrderIdLabel";
			this.uxSalesOrderIdLabel.Text = "Sales Order Id:";
			this.uxSalesOrderIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxSalesOrderIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderIdLabel);			
			//
			// uxSalesOrderId
			//
			this.uxSalesOrderId.Name = "uxSalesOrderId";
            this.uxSalesOrderId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderId);
			this.uxSalesOrderId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxSalesOrderId);
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
			// uxOrderDateLabel
			//
			this.uxOrderDateLabel.Name = "uxOrderDateLabel";
			this.uxOrderDateLabel.Text = "Order Date:";
			this.uxOrderDateLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxOrderDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrderDateLabel);			
			//
			// uxOrderDate
			//
			this.uxOrderDate.Name = "uxOrderDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrderDate);
			this.uxOrderDate.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxOrderDate);
			//
			// uxDueDateLabel
			//
			this.uxDueDateLabel.Name = "uxDueDateLabel";
			this.uxDueDateLabel.Text = "Due Date:";
			this.uxDueDateLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxDueDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDueDateLabel);			
			//
			// uxDueDate
			//
			this.uxDueDate.Name = "uxDueDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDueDate);
			this.uxDueDate.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxDueDate);
			//
			// uxShipDateLabel
			//
			this.uxShipDateLabel.Name = "uxShipDateLabel";
			this.uxShipDateLabel.Text = "Ship Date:";
			this.uxShipDateLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxShipDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipDateLabel);			
			//
			// uxShipDate
			//
			this.uxShipDate.Name = "uxShipDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipDate);
			this.uxShipDate.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxShipDate);
			//
			// uxStatusLabel
			//
			this.uxStatusLabel.Name = "uxStatusLabel";
			this.uxStatusLabel.Text = "Status:";
			this.uxStatusLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxStatusLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStatusLabel);			
			//
			// uxStatus
			//
			this.uxStatus.Name = "uxStatus";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStatus);
			this.uxStatus.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxStatus);
			//
			// uxOnlineOrderFlagLabel
			//
			this.uxOnlineOrderFlagLabel.Name = "uxOnlineOrderFlagLabel";
			this.uxOnlineOrderFlagLabel.Text = "Online Order Flag:";
			this.uxOnlineOrderFlagLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxOnlineOrderFlagLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOnlineOrderFlagLabel);			
			//
			// uxOnlineOrderFlag
			//
			this.uxOnlineOrderFlag.Name = "uxOnlineOrderFlag";
			//this.uxTableLayoutPanel.Controls.Add(this.uxOnlineOrderFlag);
			this.uxOnlineOrderFlag.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxOnlineOrderFlag);
			//
			// uxSalesOrderNumberLabel
			//
			this.uxSalesOrderNumberLabel.Name = "uxSalesOrderNumberLabel";
			this.uxSalesOrderNumberLabel.Text = "Sales Order Number:";
			this.uxSalesOrderNumberLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxSalesOrderNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderNumberLabel);			
			//
			// uxSalesOrderNumber
			//
			this.uxSalesOrderNumber.Name = "uxSalesOrderNumber";
			this.uxSalesOrderNumber.Width = 250;
			this.uxSalesOrderNumber.MaxLength = 25;
            this.uxSalesOrderNumber.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderNumber);
			this.uxSalesOrderNumber.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxSalesOrderNumber);
			//
			// uxPurchaseOrderNumberLabel
			//
			this.uxPurchaseOrderNumberLabel.Name = "uxPurchaseOrderNumberLabel";
			this.uxPurchaseOrderNumberLabel.Text = "Purchase Order Number:";
			this.uxPurchaseOrderNumberLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxPurchaseOrderNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchaseOrderNumberLabel);			
			//
			// uxPurchaseOrderNumber
			//
			this.uxPurchaseOrderNumber.Name = "uxPurchaseOrderNumber";
			this.uxPurchaseOrderNumber.Width = 250;
			this.uxPurchaseOrderNumber.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchaseOrderNumber);
			this.uxPurchaseOrderNumber.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxPurchaseOrderNumber);
			//
			// uxAccountNumberLabel
			//
			this.uxAccountNumberLabel.Name = "uxAccountNumberLabel";
			this.uxAccountNumberLabel.Text = "Account Number:";
			this.uxAccountNumberLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxAccountNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAccountNumberLabel);			
			//
			// uxAccountNumber
			//
			this.uxAccountNumber.Name = "uxAccountNumber";
			this.uxAccountNumber.Width = 250;
			this.uxAccountNumber.MaxLength = 15;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAccountNumber);
			this.uxAccountNumber.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxAccountNumber);
			//
			// uxCustomerIdLabel
			//
			this.uxCustomerIdLabel.Name = "uxCustomerIdLabel";
			this.uxCustomerIdLabel.Text = "Customer Id:";
			this.uxCustomerIdLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxCustomerIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCustomerIdLabel);			
			//
			// uxCustomerId
			//
			this.uxCustomerId.Name = "uxCustomerId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCustomerId);
			this.uxCustomerId.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxCustomerId);
			//
			// uxContactIdLabel
			//
			this.uxContactIdLabel.Name = "uxContactIdLabel";
			this.uxContactIdLabel.Text = "Contact Id:";
			this.uxContactIdLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxContactIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactIdLabel);			
			//
			// uxContactId
			//
			this.uxContactId.Name = "uxContactId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactId);
			this.uxContactId.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxContactId);
			//
			// uxSalesPersonIdLabel
			//
			this.uxSalesPersonIdLabel.Name = "uxSalesPersonIdLabel";
			this.uxSalesPersonIdLabel.Text = "Sales Person Id:";
			this.uxSalesPersonIdLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxSalesPersonIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesPersonIdLabel);			
			//
			// uxSalesPersonId
			//
			this.uxSalesPersonId.Name = "uxSalesPersonId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesPersonId);
			this.uxSalesPersonId.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxSalesPersonId);
			//
			// uxTerritoryIdLabel
			//
			this.uxTerritoryIdLabel.Name = "uxTerritoryIdLabel";
			this.uxTerritoryIdLabel.Text = "Territory Id:";
			this.uxTerritoryIdLabel.Location = new System.Drawing.Point(3, 338);
			this.Controls.Add(this.uxTerritoryIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTerritoryIdLabel);			
			//
			// uxTerritoryId
			//
			this.uxTerritoryId.Name = "uxTerritoryId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTerritoryId);
			this.uxTerritoryId.Location = new System.Drawing.Point(160, 338);
			this.Controls.Add(this.uxTerritoryId);
			//
			// uxBillToAddressIdLabel
			//
			this.uxBillToAddressIdLabel.Name = "uxBillToAddressIdLabel";
			this.uxBillToAddressIdLabel.Text = "Bill To Address Id:";
			this.uxBillToAddressIdLabel.Location = new System.Drawing.Point(3, 364);
			this.Controls.Add(this.uxBillToAddressIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBillToAddressIdLabel);			
			//
			// uxBillToAddressId
			//
			this.uxBillToAddressId.Name = "uxBillToAddressId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBillToAddressId);
			this.uxBillToAddressId.Location = new System.Drawing.Point(160, 364);
			this.Controls.Add(this.uxBillToAddressId);
			//
			// uxShipToAddressIdLabel
			//
			this.uxShipToAddressIdLabel.Name = "uxShipToAddressIdLabel";
			this.uxShipToAddressIdLabel.Text = "Ship To Address Id:";
			this.uxShipToAddressIdLabel.Location = new System.Drawing.Point(3, 390);
			this.Controls.Add(this.uxShipToAddressIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipToAddressIdLabel);			
			//
			// uxShipToAddressId
			//
			this.uxShipToAddressId.Name = "uxShipToAddressId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipToAddressId);
			this.uxShipToAddressId.Location = new System.Drawing.Point(160, 390);
			this.Controls.Add(this.uxShipToAddressId);
			//
			// uxShipMethodIdLabel
			//
			this.uxShipMethodIdLabel.Name = "uxShipMethodIdLabel";
			this.uxShipMethodIdLabel.Text = "Ship Method Id:";
			this.uxShipMethodIdLabel.Location = new System.Drawing.Point(3, 416);
			this.Controls.Add(this.uxShipMethodIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipMethodIdLabel);			
			//
			// uxShipMethodId
			//
			this.uxShipMethodId.Name = "uxShipMethodId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipMethodId);
			this.uxShipMethodId.Location = new System.Drawing.Point(160, 416);
			this.Controls.Add(this.uxShipMethodId);
			//
			// uxCreditCardIdLabel
			//
			this.uxCreditCardIdLabel.Name = "uxCreditCardIdLabel";
			this.uxCreditCardIdLabel.Text = "Credit Card Id:";
			this.uxCreditCardIdLabel.Location = new System.Drawing.Point(3, 442);
			this.Controls.Add(this.uxCreditCardIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditCardIdLabel);			
			//
			// uxCreditCardId
			//
			this.uxCreditCardId.Name = "uxCreditCardId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditCardId);
			this.uxCreditCardId.Location = new System.Drawing.Point(160, 442);
			this.Controls.Add(this.uxCreditCardId);
			//
			// uxCreditCardApprovalCodeLabel
			//
			this.uxCreditCardApprovalCodeLabel.Name = "uxCreditCardApprovalCodeLabel";
			this.uxCreditCardApprovalCodeLabel.Text = "Credit Card Approval Code:";
			this.uxCreditCardApprovalCodeLabel.Location = new System.Drawing.Point(3, 468);
			this.Controls.Add(this.uxCreditCardApprovalCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditCardApprovalCodeLabel);			
			//
			// uxCreditCardApprovalCode
			//
			this.uxCreditCardApprovalCode.Name = "uxCreditCardApprovalCode";
			this.uxCreditCardApprovalCode.Width = 250;
			this.uxCreditCardApprovalCode.MaxLength = 15;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditCardApprovalCode);
			this.uxCreditCardApprovalCode.Location = new System.Drawing.Point(160, 468);
			this.Controls.Add(this.uxCreditCardApprovalCode);
			//
			// uxCurrencyRateIdLabel
			//
			this.uxCurrencyRateIdLabel.Name = "uxCurrencyRateIdLabel";
			this.uxCurrencyRateIdLabel.Text = "Currency Rate Id:";
			this.uxCurrencyRateIdLabel.Location = new System.Drawing.Point(3, 494);
			this.Controls.Add(this.uxCurrencyRateIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrencyRateIdLabel);			
			//
			// uxCurrencyRateId
			//
			this.uxCurrencyRateId.Name = "uxCurrencyRateId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrencyRateId);
			this.uxCurrencyRateId.Location = new System.Drawing.Point(160, 494);
			this.Controls.Add(this.uxCurrencyRateId);
			//
			// uxSubTotalLabel
			//
			this.uxSubTotalLabel.Name = "uxSubTotalLabel";
			this.uxSubTotalLabel.Text = "Sub Total:";
			this.uxSubTotalLabel.Location = new System.Drawing.Point(3, 520);
			this.Controls.Add(this.uxSubTotalLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSubTotalLabel);			
			//
			// uxSubTotal
			//
			this.uxSubTotal.Name = "uxSubTotal";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSubTotal);
			this.uxSubTotal.Location = new System.Drawing.Point(160, 520);
			this.Controls.Add(this.uxSubTotal);
			//
			// uxTaxAmtLabel
			//
			this.uxTaxAmtLabel.Name = "uxTaxAmtLabel";
			this.uxTaxAmtLabel.Text = "Tax Amt:";
			this.uxTaxAmtLabel.Location = new System.Drawing.Point(3, 546);
			this.Controls.Add(this.uxTaxAmtLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTaxAmtLabel);			
			//
			// uxTaxAmt
			//
			this.uxTaxAmt.Name = "uxTaxAmt";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTaxAmt);
			this.uxTaxAmt.Location = new System.Drawing.Point(160, 546);
			this.Controls.Add(this.uxTaxAmt);
			//
			// uxFreightLabel
			//
			this.uxFreightLabel.Name = "uxFreightLabel";
			this.uxFreightLabel.Text = "Freight:";
			this.uxFreightLabel.Location = new System.Drawing.Point(3, 572);
			this.Controls.Add(this.uxFreightLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFreightLabel);			
			//
			// uxFreight
			//
			this.uxFreight.Name = "uxFreight";
			//this.uxTableLayoutPanel.Controls.Add(this.uxFreight);
			this.uxFreight.Location = new System.Drawing.Point(160, 572);
			this.Controls.Add(this.uxFreight);
			//
			// uxTotalDueLabel
			//
			this.uxTotalDueLabel.Name = "uxTotalDueLabel";
			this.uxTotalDueLabel.Text = "Total Due:";
			this.uxTotalDueLabel.Location = new System.Drawing.Point(3, 598);
			this.Controls.Add(this.uxTotalDueLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTotalDueLabel);			
			//
			// uxTotalDue
			//
			this.uxTotalDue.Name = "uxTotalDue";
            this.uxTotalDue.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTotalDue);
			this.uxTotalDue.Location = new System.Drawing.Point(160, 598);
			this.Controls.Add(this.uxTotalDue);
			//
			// uxCommentLabel
			//
			this.uxCommentLabel.Name = "uxCommentLabel";
			this.uxCommentLabel.Text = "Comment:";
			this.uxCommentLabel.Location = new System.Drawing.Point(3, 624);
			this.Controls.Add(this.uxCommentLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCommentLabel);			
			//
			// uxComment
			//
			this.uxComment.Name = "uxComment";
			this.uxComment.Width = 250;
			this.uxComment.MaxLength = 128;
			//this.uxTableLayoutPanel.Controls.Add(this.uxComment);
			this.uxComment.Location = new System.Drawing.Point(160, 624);
			this.Controls.Add(this.uxComment);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 650);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 650);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 676);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 676);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxBillToAddressId
			//				
			this.uxBillToAddressId.DisplayMember = "AddressLine1";	
			this.uxBillToAddressId.ValueMember = "AddressId";	
			//
			// uxShipToAddressId
			//				
			this.uxShipToAddressId.DisplayMember = "AddressLine1";	
			this.uxShipToAddressId.ValueMember = "AddressId";	
			//
			// uxContactId
			//				
			this.uxContactId.DisplayMember = "NameStyle";	
			this.uxContactId.ValueMember = "ContactId";	
			//
			// uxCreditCardId
			//				
			this.uxCreditCardId.DisplayMember = "CardType";	
			this.uxCreditCardId.ValueMember = "CreditCardId";	
			//
			// uxCurrencyRateId
			//				
			this.uxCurrencyRateId.DisplayMember = "CurrencyRateDate";	
			this.uxCurrencyRateId.ValueMember = "CurrencyRateId";	
			//
			// uxCustomerId
			//				
			this.uxCustomerId.DisplayMember = "TerritoryId";	
			this.uxCustomerId.ValueMember = "CustomerId";	
			//
			// uxSalesPersonId
			//				
			this.uxSalesPersonId.DisplayMember = "TerritoryId";	
			this.uxSalesPersonId.ValueMember = "SalesPersonId";	
			//
			// uxTerritoryId
			//				
			this.uxTerritoryId.DisplayMember = "Name";	
			this.uxTerritoryId.ValueMember = "TerritoryId";	
			//
			// uxShipMethodId
			//				
			this.uxShipMethodId.DisplayMember = "Name";	
			this.uxShipMethodId.ValueMember = "ShipMethodId";	
			// 
			// SalesOrderHeaderEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "SalesOrderHeaderEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Address> _BillToAddressIdList;
		
		/// <summary>
		/// The ComboBox associated with the BillToAddressId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Address> BillToAddressIdList
		{
			get {return _BillToAddressIdList;}
			set 
			{
				this._BillToAddressIdList = value;
				this.uxBillToAddressId.DataSource = null;
				this.uxBillToAddressId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInBillToAddressIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the BillToAddressId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInBillToAddressIdList
		{
			get { return _allowNewItemInBillToAddressIdList;}
			set
			{
				this._allowNewItemInBillToAddressIdList = value;
				this.uxBillToAddressId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Address> _ShipToAddressIdList;
		
		/// <summary>
		/// The ComboBox associated with the ShipToAddressId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Address> ShipToAddressIdList
		{
			get {return _ShipToAddressIdList;}
			set 
			{
				this._ShipToAddressIdList = value;
				this.uxShipToAddressId.DataSource = null;
				this.uxShipToAddressId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInShipToAddressIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ShipToAddressId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInShipToAddressIdList
		{
			get { return _allowNewItemInShipToAddressIdList;}
			set
			{
				this._allowNewItemInShipToAddressIdList = value;
				this.uxShipToAddressId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Contact> _ContactIdList;
		
		/// <summary>
		/// The ComboBox associated with the ContactId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Contact> ContactIdList
		{
			get {return _ContactIdList;}
			set 
			{
				this._ContactIdList = value;
				this.uxContactId.DataSource = null;
				this.uxContactId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInContactIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ContactId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactIdList
		{
			get { return _allowNewItemInContactIdList;}
			set
			{
				this._allowNewItemInContactIdList = value;
				this.uxContactId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.CreditCard> _CreditCardIdList;
		
		/// <summary>
		/// The ComboBox associated with the CreditCardId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.CreditCard> CreditCardIdList
		{
			get {return _CreditCardIdList;}
			set 
			{
				this._CreditCardIdList = value;
				this.uxCreditCardId.DataSource = null;
				this.uxCreditCardId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInCreditCardIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the CreditCardId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCreditCardIdList
		{
			get { return _allowNewItemInCreditCardIdList;}
			set
			{
				this._allowNewItemInCreditCardIdList = value;
				this.uxCreditCardId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.CurrencyRate> _CurrencyRateIdList;
		
		/// <summary>
		/// The ComboBox associated with the CurrencyRateId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.CurrencyRate> CurrencyRateIdList
		{
			get {return _CurrencyRateIdList;}
			set 
			{
				this._CurrencyRateIdList = value;
				this.uxCurrencyRateId.DataSource = null;
				this.uxCurrencyRateId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInCurrencyRateIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the CurrencyRateId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCurrencyRateIdList
		{
			get { return _allowNewItemInCurrencyRateIdList;}
			set
			{
				this._allowNewItemInCurrencyRateIdList = value;
				this.uxCurrencyRateId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Customer> _CustomerIdList;
		
		/// <summary>
		/// The ComboBox associated with the CustomerId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Customer> CustomerIdList
		{
			get {return _CustomerIdList;}
			set 
			{
				this._CustomerIdList = value;
				this.uxCustomerId.DataSource = null;
				this.uxCustomerId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInCustomerIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the CustomerId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCustomerIdList
		{
			get { return _allowNewItemInCustomerIdList;}
			set
			{
				this._allowNewItemInCustomerIdList = value;
				this.uxCustomerId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.SalesPerson> _SalesPersonIdList;
		
		/// <summary>
		/// The ComboBox associated with the SalesPersonId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.SalesPerson> SalesPersonIdList
		{
			get {return _SalesPersonIdList;}
			set 
			{
				this._SalesPersonIdList = value;
				this.uxSalesPersonId.DataSource = null;
				this.uxSalesPersonId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInSalesPersonIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the SalesPersonId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesPersonIdList
		{
			get { return _allowNewItemInSalesPersonIdList;}
			set
			{
				this._allowNewItemInSalesPersonIdList = value;
				this.uxSalesPersonId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.SalesTerritory> _TerritoryIdList;
		
		/// <summary>
		/// The ComboBox associated with the TerritoryId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.SalesTerritory> TerritoryIdList
		{
			get {return _TerritoryIdList;}
			set 
			{
				this._TerritoryIdList = value;
				this.uxTerritoryId.DataSource = null;
				this.uxTerritoryId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInTerritoryIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the TerritoryId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInTerritoryIdList
		{
			get { return _allowNewItemInTerritoryIdList;}
			set
			{
				this._allowNewItemInTerritoryIdList = value;
				this.uxTerritoryId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxSalesOrderId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesOrderIdVisible
        {
            get { return this.uxSalesOrderId.Visible; }
            set
            {
                this.uxSalesOrderIdLabel.Visible = value;
                this.uxSalesOrderId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesOrderId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesOrderIdEnabled
        {
            get { return this.uxSalesOrderId.Enabled; }
            set
            {
                this.uxSalesOrderId.Enabled = value;
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
        /// Indicates if the controls associated with the uxDueDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDueDateVisible
        {
            get { return this.uxDueDate.Visible; }
            set
            {
                this.uxDueDateLabel.Visible = value;
                this.uxDueDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDueDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDueDateEnabled
        {
            get { return this.uxDueDate.Enabled; }
            set
            {
                this.uxDueDate.Enabled = value;
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
        /// Indicates if the controls associated with the uxOnlineOrderFlag property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxOnlineOrderFlagVisible
        {
            get { return this.uxOnlineOrderFlag.Visible; }
            set
            {
                this.uxOnlineOrderFlagLabel.Visible = value;
                this.uxOnlineOrderFlag.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxOnlineOrderFlag property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxOnlineOrderFlagEnabled
        {
            get { return this.uxOnlineOrderFlag.Enabled; }
            set
            {
                this.uxOnlineOrderFlag.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSalesOrderNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesOrderNumberVisible
        {
            get { return this.uxSalesOrderNumber.Visible; }
            set
            {
                this.uxSalesOrderNumberLabel.Visible = value;
                this.uxSalesOrderNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesOrderNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesOrderNumberEnabled
        {
            get { return this.uxSalesOrderNumber.Enabled; }
            set
            {
                this.uxSalesOrderNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPurchaseOrderNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPurchaseOrderNumberVisible
        {
            get { return this.uxPurchaseOrderNumber.Visible; }
            set
            {
                this.uxPurchaseOrderNumberLabel.Visible = value;
                this.uxPurchaseOrderNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPurchaseOrderNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPurchaseOrderNumberEnabled
        {
            get { return this.uxPurchaseOrderNumber.Enabled; }
            set
            {
                this.uxPurchaseOrderNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAccountNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAccountNumberVisible
        {
            get { return this.uxAccountNumber.Visible; }
            set
            {
                this.uxAccountNumberLabel.Visible = value;
                this.uxAccountNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAccountNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAccountNumberEnabled
        {
            get { return this.uxAccountNumber.Enabled; }
            set
            {
                this.uxAccountNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCustomerId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCustomerIdVisible
        {
            get { return this.uxCustomerId.Visible; }
            set
            {
                this.uxCustomerIdLabel.Visible = value;
                this.uxCustomerId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCustomerId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCustomerIdEnabled
        {
            get { return this.uxCustomerId.Enabled; }
            set
            {
                this.uxCustomerId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxContactId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxContactIdVisible
        {
            get { return this.uxContactId.Visible; }
            set
            {
                this.uxContactIdLabel.Visible = value;
                this.uxContactId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxContactId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxContactIdEnabled
        {
            get { return this.uxContactId.Enabled; }
            set
            {
                this.uxContactId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSalesPersonId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesPersonIdVisible
        {
            get { return this.uxSalesPersonId.Visible; }
            set
            {
                this.uxSalesPersonIdLabel.Visible = value;
                this.uxSalesPersonId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesPersonId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesPersonIdEnabled
        {
            get { return this.uxSalesPersonId.Enabled; }
            set
            {
                this.uxSalesPersonId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTerritoryId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTerritoryIdVisible
        {
            get { return this.uxTerritoryId.Visible; }
            set
            {
                this.uxTerritoryIdLabel.Visible = value;
                this.uxTerritoryId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTerritoryId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTerritoryIdEnabled
        {
            get { return this.uxTerritoryId.Enabled; }
            set
            {
                this.uxTerritoryId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBillToAddressId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBillToAddressIdVisible
        {
            get { return this.uxBillToAddressId.Visible; }
            set
            {
                this.uxBillToAddressIdLabel.Visible = value;
                this.uxBillToAddressId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBillToAddressId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBillToAddressIdEnabled
        {
            get { return this.uxBillToAddressId.Enabled; }
            set
            {
                this.uxBillToAddressId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxShipToAddressId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShipToAddressIdVisible
        {
            get { return this.uxShipToAddressId.Visible; }
            set
            {
                this.uxShipToAddressIdLabel.Visible = value;
                this.uxShipToAddressId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShipToAddressId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShipToAddressIdEnabled
        {
            get { return this.uxShipToAddressId.Enabled; }
            set
            {
                this.uxShipToAddressId.Enabled = value;
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
        /// Indicates if the controls associated with the uxCreditCardId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCreditCardIdVisible
        {
            get { return this.uxCreditCardId.Visible; }
            set
            {
                this.uxCreditCardIdLabel.Visible = value;
                this.uxCreditCardId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCreditCardId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCreditCardIdEnabled
        {
            get { return this.uxCreditCardId.Enabled; }
            set
            {
                this.uxCreditCardId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCreditCardApprovalCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCreditCardApprovalCodeVisible
        {
            get { return this.uxCreditCardApprovalCode.Visible; }
            set
            {
                this.uxCreditCardApprovalCodeLabel.Visible = value;
                this.uxCreditCardApprovalCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCreditCardApprovalCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCreditCardApprovalCodeEnabled
        {
            get { return this.uxCreditCardApprovalCode.Enabled; }
            set
            {
                this.uxCreditCardApprovalCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCurrencyRateId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCurrencyRateIdVisible
        {
            get { return this.uxCurrencyRateId.Visible; }
            set
            {
                this.uxCurrencyRateIdLabel.Visible = value;
                this.uxCurrencyRateId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCurrencyRateId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCurrencyRateIdEnabled
        {
            get { return this.uxCurrencyRateId.Enabled; }
            set
            {
                this.uxCurrencyRateId.Enabled = value;
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
        /// Indicates if the controls associated with the uxComment property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCommentVisible
        {
            get { return this.uxComment.Visible; }
            set
            {
                this.uxCommentLabel.Visible = value;
                this.uxComment.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxComment property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCommentEnabled
        {
            get { return this.uxComment.Enabled; }
            set
            {
                this.uxComment.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRowguid property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRowguidVisible
        {
            get { return this.uxRowguid.Visible; }
            set
            {
                this.uxRowguidLabel.Visible = value;
                this.uxRowguid.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRowguid property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRowguidEnabled
        {
            get { return this.uxRowguid.Enabled; }
            set
            {
                this.uxRowguid.Enabled = value;
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
