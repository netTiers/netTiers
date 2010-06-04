
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.PurchaseOrderDetail"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class PurchaseOrderDetailEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the PurchaseOrderId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxPurchaseOrderId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PurchaseOrderId property.
		/// </summary>
		protected System.Windows.Forms.Label uxPurchaseOrderIdLabel;
		
		/// <summary>
		/// TextBox for the PurchaseOrderDetailId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPurchaseOrderDetailId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PurchaseOrderDetailId property.
		/// </summary>
		protected System.Windows.Forms.Label uxPurchaseOrderDetailIdLabel;
		
		/// <summary>
		/// DataTimePicker for the DueDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxDueDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DueDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxDueDateLabel;
		
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
		/// TextBox for the UnitPrice property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUnitPrice;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UnitPrice property.
		/// </summary>
		protected System.Windows.Forms.Label uxUnitPriceLabel;
		
		/// <summary>
		/// TextBox for the LineTotal property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLineTotal;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LineTotal property.
		/// </summary>
		protected System.Windows.Forms.Label uxLineTotalLabel;
		
		/// <summary>
		/// TextBox for the ReceivedQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxReceivedQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ReceivedQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxReceivedQtyLabel;
		
		/// <summary>
		/// TextBox for the RejectedQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRejectedQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the RejectedQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxRejectedQtyLabel;
		
		/// <summary>
		/// TextBox for the StockedQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStockedQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StockedQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxStockedQtyLabel;
		
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
		private Entities.PurchaseOrderDetail _PurchaseOrderDetail;
		/// <summary>
		/// Gets or sets the <see cref="Entities.PurchaseOrderDetail"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.PurchaseOrderDetail"/> instance.</value>
		public Entities.PurchaseOrderDetail PurchaseOrderDetail
		{
			get {return this._PurchaseOrderDetail;}
			set
			{
				this._PurchaseOrderDetail = value;
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
			this.uxPurchaseOrderId.DataBindings.Add("SelectedValue", this.uxBindingSource, "PurchaseOrderId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPurchaseOrderDetailId.DataBindings.Clear();
			this.uxPurchaseOrderDetailId.DataBindings.Add("Text", this.uxBindingSource, "PurchaseOrderDetailId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDueDate.DataBindings.Clear();
			this.uxDueDate.DataBindings.Add("Value", this.uxBindingSource, "DueDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOrderQty.DataBindings.Clear();
			this.uxOrderQty.DataBindings.Add("Text", this.uxBindingSource, "OrderQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUnitPrice.DataBindings.Clear();
			this.uxUnitPrice.DataBindings.Add("Text", this.uxBindingSource, "UnitPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLineTotal.DataBindings.Clear();
			this.uxLineTotal.DataBindings.Add("Text", this.uxBindingSource, "LineTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxReceivedQty.DataBindings.Clear();
			this.uxReceivedQty.DataBindings.Add("Text", this.uxBindingSource, "ReceivedQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRejectedQty.DataBindings.Clear();
			this.uxRejectedQty.DataBindings.Add("Text", this.uxBindingSource, "RejectedQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStockedQty.DataBindings.Clear();
			this.uxStockedQty.DataBindings.Add("Text", this.uxBindingSource, "StockedQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="PurchaseOrderDetailEditControlBase"/> class.
		/// </summary>
		public PurchaseOrderDetailEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_PurchaseOrderDetail != null) _PurchaseOrderDetail.Validate();
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
			this.uxPurchaseOrderId = new System.Windows.Forms.ComboBox();
			uxPurchaseOrderIdLabel = new System.Windows.Forms.Label();
			this.uxPurchaseOrderDetailId = new System.Windows.Forms.TextBox();
			uxPurchaseOrderDetailIdLabel = new System.Windows.Forms.Label();
			this.uxDueDate = new System.Windows.Forms.DateTimePicker();
			uxDueDateLabel = new System.Windows.Forms.Label();
			this.uxOrderQty = new System.Windows.Forms.TextBox();
			uxOrderQtyLabel = new System.Windows.Forms.Label();
			this.uxProductId = new System.Windows.Forms.ComboBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxUnitPrice = new System.Windows.Forms.TextBox();
			uxUnitPriceLabel = new System.Windows.Forms.Label();
			this.uxLineTotal = new System.Windows.Forms.TextBox();
			uxLineTotalLabel = new System.Windows.Forms.Label();
			this.uxReceivedQty = new System.Windows.Forms.TextBox();
			uxReceivedQtyLabel = new System.Windows.Forms.Label();
			this.uxRejectedQty = new System.Windows.Forms.TextBox();
			uxRejectedQtyLabel = new System.Windows.Forms.Label();
			this.uxStockedQty = new System.Windows.Forms.TextBox();
			uxStockedQtyLabel = new System.Windows.Forms.Label();
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
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchaseOrderId);
			this.uxPurchaseOrderId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxPurchaseOrderId);
			//
			// uxPurchaseOrderDetailIdLabel
			//
			this.uxPurchaseOrderDetailIdLabel.Name = "uxPurchaseOrderDetailIdLabel";
			this.uxPurchaseOrderDetailIdLabel.Text = "Purchase Order Detail Id:";
			this.uxPurchaseOrderDetailIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxPurchaseOrderDetailIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchaseOrderDetailIdLabel);			
			//
			// uxPurchaseOrderDetailId
			//
			this.uxPurchaseOrderDetailId.Name = "uxPurchaseOrderDetailId";
            this.uxPurchaseOrderDetailId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchaseOrderDetailId);
			this.uxPurchaseOrderDetailId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxPurchaseOrderDetailId);
			//
			// uxDueDateLabel
			//
			this.uxDueDateLabel.Name = "uxDueDateLabel";
			this.uxDueDateLabel.Text = "Due Date:";
			this.uxDueDateLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxDueDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDueDateLabel);			
			//
			// uxDueDate
			//
			this.uxDueDate.Name = "uxDueDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDueDate);
			this.uxDueDate.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxDueDate);
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
			// uxUnitPriceLabel
			//
			this.uxUnitPriceLabel.Name = "uxUnitPriceLabel";
			this.uxUnitPriceLabel.Text = "Unit Price:";
			this.uxUnitPriceLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxUnitPriceLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitPriceLabel);			
			//
			// uxUnitPrice
			//
			this.uxUnitPrice.Name = "uxUnitPrice";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitPrice);
			this.uxUnitPrice.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxUnitPrice);
			//
			// uxLineTotalLabel
			//
			this.uxLineTotalLabel.Name = "uxLineTotalLabel";
			this.uxLineTotalLabel.Text = "Line Total:";
			this.uxLineTotalLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxLineTotalLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLineTotalLabel);			
			//
			// uxLineTotal
			//
			this.uxLineTotal.Name = "uxLineTotal";
            this.uxLineTotal.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLineTotal);
			this.uxLineTotal.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxLineTotal);
			//
			// uxReceivedQtyLabel
			//
			this.uxReceivedQtyLabel.Name = "uxReceivedQtyLabel";
			this.uxReceivedQtyLabel.Text = "Received Qty:";
			this.uxReceivedQtyLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxReceivedQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxReceivedQtyLabel);			
			//
			// uxReceivedQty
			//
			this.uxReceivedQty.Name = "uxReceivedQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxReceivedQty);
			this.uxReceivedQty.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxReceivedQty);
			//
			// uxRejectedQtyLabel
			//
			this.uxRejectedQtyLabel.Name = "uxRejectedQtyLabel";
			this.uxRejectedQtyLabel.Text = "Rejected Qty:";
			this.uxRejectedQtyLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxRejectedQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRejectedQtyLabel);			
			//
			// uxRejectedQty
			//
			this.uxRejectedQty.Name = "uxRejectedQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxRejectedQty);
			this.uxRejectedQty.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxRejectedQty);
			//
			// uxStockedQtyLabel
			//
			this.uxStockedQtyLabel.Name = "uxStockedQtyLabel";
			this.uxStockedQtyLabel.Text = "Stocked Qty:";
			this.uxStockedQtyLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxStockedQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStockedQtyLabel);			
			//
			// uxStockedQty
			//
			this.uxStockedQty.Name = "uxStockedQty";
            this.uxStockedQty.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxStockedQty);
			this.uxStockedQty.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxStockedQty);
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
			// uxProductId
			//				
			this.uxProductId.DisplayMember = "Name";	
			this.uxProductId.ValueMember = "ProductId";	
			//
			// uxPurchaseOrderId
			//				
			this.uxPurchaseOrderId.DisplayMember = "RevisionNumber";	
			this.uxPurchaseOrderId.ValueMember = "PurchaseOrderId";	
			// 
			// PurchaseOrderDetailEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "PurchaseOrderDetailEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Product> _ProductIdList;
		
		/// <summary>
		/// The ComboBox associated with the ProductId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Product> ProductIdList
		{
			get {return _ProductIdList;}
			set 
			{
				this._ProductIdList = value;
				this.uxProductId.DataSource = null;
				this.uxProductId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInProductIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ProductId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductIdList
		{
			get { return _allowNewItemInProductIdList;}
			set
			{
				this._allowNewItemInProductIdList = value;
				this.uxProductId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.PurchaseOrderHeader> _PurchaseOrderIdList;
		
		/// <summary>
		/// The ComboBox associated with the PurchaseOrderId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.PurchaseOrderHeader> PurchaseOrderIdList
		{
			get {return _PurchaseOrderIdList;}
			set 
			{
				this._PurchaseOrderIdList = value;
				this.uxPurchaseOrderId.DataSource = null;
				this.uxPurchaseOrderId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInPurchaseOrderIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the PurchaseOrderId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInPurchaseOrderIdList
		{
			get { return _allowNewItemInPurchaseOrderIdList;}
			set
			{
				this._allowNewItemInPurchaseOrderIdList = value;
				this.uxPurchaseOrderId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        /// Indicates if the controls associated with the uxPurchaseOrderDetailId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPurchaseOrderDetailIdVisible
        {
            get { return this.uxPurchaseOrderDetailId.Visible; }
            set
            {
                this.uxPurchaseOrderDetailIdLabel.Visible = value;
                this.uxPurchaseOrderDetailId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPurchaseOrderDetailId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPurchaseOrderDetailIdEnabled
        {
            get { return this.uxPurchaseOrderDetailId.Enabled; }
            set
            {
                this.uxPurchaseOrderDetailId.Enabled = value;
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
        /// Indicates if the controls associated with the uxReceivedQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxReceivedQtyVisible
        {
            get { return this.uxReceivedQty.Visible; }
            set
            {
                this.uxReceivedQtyLabel.Visible = value;
                this.uxReceivedQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxReceivedQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxReceivedQtyEnabled
        {
            get { return this.uxReceivedQty.Enabled; }
            set
            {
                this.uxReceivedQty.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRejectedQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRejectedQtyVisible
        {
            get { return this.uxRejectedQty.Visible; }
            set
            {
                this.uxRejectedQtyLabel.Visible = value;
                this.uxRejectedQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRejectedQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRejectedQtyEnabled
        {
            get { return this.uxRejectedQty.Enabled; }
            set
            {
                this.uxRejectedQty.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStockedQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStockedQtyVisible
        {
            get { return this.uxStockedQty.Visible; }
            set
            {
                this.uxStockedQtyLabel.Visible = value;
                this.uxStockedQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStockedQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStockedQtyEnabled
        {
            get { return this.uxStockedQty.Enabled; }
            set
            {
                this.uxStockedQty.Enabled = value;
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
