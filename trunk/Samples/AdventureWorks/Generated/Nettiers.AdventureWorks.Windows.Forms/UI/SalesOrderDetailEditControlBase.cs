
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.SalesOrderDetail"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesOrderDetailEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the SalesOrderId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxSalesOrderId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesOrderId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesOrderIdLabel;
		
		/// <summary>
		/// TextBox for the SalesOrderDetailId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSalesOrderDetailId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesOrderDetailId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesOrderDetailIdLabel;
		
		/// <summary>
		/// TextBox for the CarrierTrackingNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCarrierTrackingNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CarrierTrackingNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxCarrierTrackingNumberLabel;
		
		/// <summary>
		/// TextBox for the OrderQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxOrderQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OrderQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxOrderQtyLabel;
		
		/// <summary>
		/// ComboBox for the ProductId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// ComboBox for the SpecialOfferId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxSpecialOfferId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SpecialOfferId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSpecialOfferIdLabel;
		
		/// <summary>
		/// TextBox for the UnitPrice property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUnitPrice;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UnitPrice property.
		/// </summary>
		protected System.Windows.Forms.Label uxUnitPriceLabel;
		
		/// <summary>
		/// TextBox for the UnitPriceDiscount property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUnitPriceDiscount;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UnitPriceDiscount property.
		/// </summary>
		protected System.Windows.Forms.Label uxUnitPriceDiscountLabel;
		
		/// <summary>
		/// TextBox for the LineTotal property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLineTotal;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LineTotal property.
		/// </summary>
		protected System.Windows.Forms.Label uxLineTotalLabel;
		
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
		private Entities.SalesOrderDetail _SalesOrderDetail;
		/// <summary>
		/// Gets or sets the <see cref="Entities.SalesOrderDetail"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.SalesOrderDetail"/> instance.</value>
		public Entities.SalesOrderDetail SalesOrderDetail
		{
			get {return this._SalesOrderDetail;}
			set
			{
				this._SalesOrderDetail = value;
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
			this.uxSalesOrderId.DataBindings.Add("SelectedValue", this.uxBindingSource, "SalesOrderId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesOrderDetailId.DataBindings.Clear();
			this.uxSalesOrderDetailId.DataBindings.Add("Text", this.uxBindingSource, "SalesOrderDetailId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCarrierTrackingNumber.DataBindings.Clear();
			this.uxCarrierTrackingNumber.DataBindings.Add("Text", this.uxBindingSource, "CarrierTrackingNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOrderQty.DataBindings.Clear();
			this.uxOrderQty.DataBindings.Add("Text", this.uxBindingSource, "OrderQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSpecialOfferId.DataBindings.Clear();
			this.uxSpecialOfferId.DataBindings.Add("SelectedValue", this.uxBindingSource, "SpecialOfferId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUnitPrice.DataBindings.Clear();
			this.uxUnitPrice.DataBindings.Add("Text", this.uxBindingSource, "UnitPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUnitPriceDiscount.DataBindings.Clear();
			this.uxUnitPriceDiscount.DataBindings.Add("Text", this.uxBindingSource, "UnitPriceDiscount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLineTotal.DataBindings.Clear();
			this.uxLineTotal.DataBindings.Add("Text", this.uxBindingSource, "LineTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SalesOrderDetailEditControlBase"/> class.
		/// </summary>
		public SalesOrderDetailEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_SalesOrderDetail != null) _SalesOrderDetail.Validate();
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
			this.uxSalesOrderId = new System.Windows.Forms.ComboBox();
			uxSalesOrderIdLabel = new System.Windows.Forms.Label();
			this.uxSalesOrderDetailId = new System.Windows.Forms.TextBox();
			uxSalesOrderDetailIdLabel = new System.Windows.Forms.Label();
			this.uxCarrierTrackingNumber = new System.Windows.Forms.TextBox();
			uxCarrierTrackingNumberLabel = new System.Windows.Forms.Label();
			this.uxOrderQty = new System.Windows.Forms.TextBox();
			uxOrderQtyLabel = new System.Windows.Forms.Label();
			this.uxProductId = new System.Windows.Forms.ComboBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxSpecialOfferId = new System.Windows.Forms.ComboBox();
			uxSpecialOfferIdLabel = new System.Windows.Forms.Label();
			this.uxUnitPrice = new System.Windows.Forms.TextBox();
			uxUnitPriceLabel = new System.Windows.Forms.Label();
			this.uxUnitPriceDiscount = new System.Windows.Forms.TextBox();
			uxUnitPriceDiscountLabel = new System.Windows.Forms.Label();
			this.uxLineTotal = new System.Windows.Forms.TextBox();
			uxLineTotalLabel = new System.Windows.Forms.Label();
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
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderId);
			this.uxSalesOrderId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxSalesOrderId);
			//
			// uxSalesOrderDetailIdLabel
			//
			this.uxSalesOrderDetailIdLabel.Name = "uxSalesOrderDetailIdLabel";
			this.uxSalesOrderDetailIdLabel.Text = "Sales Order Detail Id:";
			this.uxSalesOrderDetailIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxSalesOrderDetailIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderDetailIdLabel);			
			//
			// uxSalesOrderDetailId
			//
			this.uxSalesOrderDetailId.Name = "uxSalesOrderDetailId";
            this.uxSalesOrderDetailId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderDetailId);
			this.uxSalesOrderDetailId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxSalesOrderDetailId);
			//
			// uxCarrierTrackingNumberLabel
			//
			this.uxCarrierTrackingNumberLabel.Name = "uxCarrierTrackingNumberLabel";
			this.uxCarrierTrackingNumberLabel.Text = "Carrier Tracking Number:";
			this.uxCarrierTrackingNumberLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxCarrierTrackingNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCarrierTrackingNumberLabel);			
			//
			// uxCarrierTrackingNumber
			//
			this.uxCarrierTrackingNumber.Name = "uxCarrierTrackingNumber";
			this.uxCarrierTrackingNumber.Width = 250;
			this.uxCarrierTrackingNumber.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCarrierTrackingNumber);
			this.uxCarrierTrackingNumber.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxCarrierTrackingNumber);
			//
			// uxOrderQtyLabel
			//
			this.uxOrderQtyLabel.Name = "uxOrderQtyLabel";
			this.uxOrderQtyLabel.Text = "Order Qty:";
			this.uxOrderQtyLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxOrderQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrderQtyLabel);			
			//
			// uxOrderQty
			//
			this.uxOrderQty.Name = "uxOrderQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrderQty);
			this.uxOrderQty.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxOrderQty);
			//
			// uxProductIdLabel
			//
			this.uxProductIdLabel.Name = "uxProductIdLabel";
			this.uxProductIdLabel.Text = "Product Id:";
			this.uxProductIdLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductIdLabel);			
			//
			// uxProductId
			//
			this.uxProductId.Name = "uxProductId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductId);
			this.uxProductId.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxProductId);
			//
			// uxSpecialOfferIdLabel
			//
			this.uxSpecialOfferIdLabel.Name = "uxSpecialOfferIdLabel";
			this.uxSpecialOfferIdLabel.Text = "Special Offer Id:";
			this.uxSpecialOfferIdLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxSpecialOfferIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSpecialOfferIdLabel);			
			//
			// uxSpecialOfferId
			//
			this.uxSpecialOfferId.Name = "uxSpecialOfferId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSpecialOfferId);
			this.uxSpecialOfferId.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxSpecialOfferId);
			//
			// uxUnitPriceLabel
			//
			this.uxUnitPriceLabel.Name = "uxUnitPriceLabel";
			this.uxUnitPriceLabel.Text = "Unit Price:";
			this.uxUnitPriceLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxUnitPriceLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitPriceLabel);			
			//
			// uxUnitPrice
			//
			this.uxUnitPrice.Name = "uxUnitPrice";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitPrice);
			this.uxUnitPrice.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxUnitPrice);
			//
			// uxUnitPriceDiscountLabel
			//
			this.uxUnitPriceDiscountLabel.Name = "uxUnitPriceDiscountLabel";
			this.uxUnitPriceDiscountLabel.Text = "Unit Price Discount:";
			this.uxUnitPriceDiscountLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxUnitPriceDiscountLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitPriceDiscountLabel);			
			//
			// uxUnitPriceDiscount
			//
			this.uxUnitPriceDiscount.Name = "uxUnitPriceDiscount";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitPriceDiscount);
			this.uxUnitPriceDiscount.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxUnitPriceDiscount);
			//
			// uxLineTotalLabel
			//
			this.uxLineTotalLabel.Name = "uxLineTotalLabel";
			this.uxLineTotalLabel.Text = "Line Total:";
			this.uxLineTotalLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxLineTotalLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLineTotalLabel);			
			//
			// uxLineTotal
			//
			this.uxLineTotal.Name = "uxLineTotal";
            this.uxLineTotal.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLineTotal);
			this.uxLineTotal.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxLineTotal);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxSalesOrderId
			//				
			this.uxSalesOrderId.DisplayMember = "RevisionNumber";	
			this.uxSalesOrderId.ValueMember = "SalesOrderId";	
			//
			// uxSpecialOfferId
			//				
			this.uxSpecialOfferId.DisplayMember = "ProductId";	
			this.uxSpecialOfferId.ValueMember = "SpecialOfferId";	
			// 
			// SalesOrderDetailEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "SalesOrderDetailEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.SalesOrderHeader> _SalesOrderIdList;
		
		/// <summary>
		/// The ComboBox associated with the SalesOrderId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.SalesOrderHeader> SalesOrderIdList
		{
			get {return _SalesOrderIdList;}
			set 
			{
				this._SalesOrderIdList = value;
				this.uxSalesOrderId.DataSource = null;
				this.uxSalesOrderId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInSalesOrderIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the SalesOrderId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesOrderIdList
		{
			get { return _allowNewItemInSalesOrderIdList;}
			set
			{
				this._allowNewItemInSalesOrderIdList = value;
				this.uxSalesOrderId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        /// Indicates if the controls associated with the uxSalesOrderDetailId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesOrderDetailIdVisible
        {
            get { return this.uxSalesOrderDetailId.Visible; }
            set
            {
                this.uxSalesOrderDetailIdLabel.Visible = value;
                this.uxSalesOrderDetailId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesOrderDetailId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesOrderDetailIdEnabled
        {
            get { return this.uxSalesOrderDetailId.Enabled; }
            set
            {
                this.uxSalesOrderDetailId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCarrierTrackingNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCarrierTrackingNumberVisible
        {
            get { return this.uxCarrierTrackingNumber.Visible; }
            set
            {
                this.uxCarrierTrackingNumberLabel.Visible = value;
                this.uxCarrierTrackingNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCarrierTrackingNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCarrierTrackingNumberEnabled
        {
            get { return this.uxCarrierTrackingNumber.Enabled; }
            set
            {
                this.uxCarrierTrackingNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxOrderQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxOrderQtyVisible
        {
            get { return this.uxOrderQty.Visible; }
            set
            {
                this.uxOrderQtyLabel.Visible = value;
                this.uxOrderQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxOrderQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxOrderQtyEnabled
        {
            get { return this.uxOrderQty.Enabled; }
            set
            {
                this.uxOrderQty.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductIdVisible
        {
            get { return this.uxProductId.Visible; }
            set
            {
                this.uxProductIdLabel.Visible = value;
                this.uxProductId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductIdEnabled
        {
            get { return this.uxProductId.Enabled; }
            set
            {
                this.uxProductId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSpecialOfferId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSpecialOfferIdVisible
        {
            get { return this.uxSpecialOfferId.Visible; }
            set
            {
                this.uxSpecialOfferIdLabel.Visible = value;
                this.uxSpecialOfferId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSpecialOfferId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSpecialOfferIdEnabled
        {
            get { return this.uxSpecialOfferId.Enabled; }
            set
            {
                this.uxSpecialOfferId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUnitPrice property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUnitPriceVisible
        {
            get { return this.uxUnitPrice.Visible; }
            set
            {
                this.uxUnitPriceLabel.Visible = value;
                this.uxUnitPrice.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUnitPrice property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUnitPriceEnabled
        {
            get { return this.uxUnitPrice.Enabled; }
            set
            {
                this.uxUnitPrice.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUnitPriceDiscount property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUnitPriceDiscountVisible
        {
            get { return this.uxUnitPriceDiscount.Visible; }
            set
            {
                this.uxUnitPriceDiscountLabel.Visible = value;
                this.uxUnitPriceDiscount.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUnitPriceDiscount property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUnitPriceDiscountEnabled
        {
            get { return this.uxUnitPriceDiscount.Enabled; }
            set
            {
                this.uxUnitPriceDiscount.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLineTotal property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLineTotalVisible
        {
            get { return this.uxLineTotal.Visible; }
            set
            {
                this.uxLineTotalLabel.Visible = value;
                this.uxLineTotal.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLineTotal property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLineTotalEnabled
        {
            get { return this.uxLineTotal.Enabled; }
            set
            {
                this.uxLineTotal.Enabled = value;
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
