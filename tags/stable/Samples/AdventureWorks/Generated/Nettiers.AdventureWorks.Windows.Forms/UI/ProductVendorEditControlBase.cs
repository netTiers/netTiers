
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ProductVendor"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductVendorEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the ProductId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// ComboBox for the VendorId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxVendorId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the VendorId property.
		/// </summary>
		protected System.Windows.Forms.Label uxVendorIdLabel;
		
		/// <summary>
		/// TextBox for the AverageLeadTime property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAverageLeadTime;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AverageLeadTime property.
		/// </summary>
		protected System.Windows.Forms.Label uxAverageLeadTimeLabel;
		
		/// <summary>
		/// TextBox for the StandardPrice property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStandardPrice;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StandardPrice property.
		/// </summary>
		protected System.Windows.Forms.Label uxStandardPriceLabel;
		
		/// <summary>
		/// TextBox for the LastReceiptCost property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLastReceiptCost;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LastReceiptCost property.
		/// </summary>
		protected System.Windows.Forms.Label uxLastReceiptCostLabel;
		
		/// <summary>
		/// DataTimePicker for the LastReceiptDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxLastReceiptDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LastReceiptDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxLastReceiptDateLabel;
		
		/// <summary>
		/// TextBox for the MinOrderQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxMinOrderQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the MinOrderQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxMinOrderQtyLabel;
		
		/// <summary>
		/// TextBox for the MaxOrderQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxMaxOrderQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the MaxOrderQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxMaxOrderQtyLabel;
		
		/// <summary>
		/// TextBox for the OnOrderQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxOnOrderQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OnOrderQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxOnOrderQtyLabel;
		
		/// <summary>
		/// ComboBox for the UnitMeasureCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxUnitMeasureCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UnitMeasureCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxUnitMeasureCodeLabel;
		
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
		private Entities.ProductVendor _ProductVendor;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ProductVendor"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ProductVendor"/> instance.</value>
		public Entities.ProductVendor ProductVendor
		{
			get {return this._ProductVendor;}
			set
			{
				this._ProductVendor = value;
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
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxVendorId.DataBindings.Clear();
			this.uxVendorId.DataBindings.Add("SelectedValue", this.uxBindingSource, "VendorId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAverageLeadTime.DataBindings.Clear();
			this.uxAverageLeadTime.DataBindings.Add("Text", this.uxBindingSource, "AverageLeadTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStandardPrice.DataBindings.Clear();
			this.uxStandardPrice.DataBindings.Add("Text", this.uxBindingSource, "StandardPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLastReceiptCost.DataBindings.Clear();
			this.uxLastReceiptCost.DataBindings.Add("Text", this.uxBindingSource, "LastReceiptCost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLastReceiptDate.DataBindings.Clear();
			this.uxLastReceiptDate.DataBindings.Add("Value", this.uxBindingSource, "LastReceiptDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMinOrderQty.DataBindings.Clear();
			this.uxMinOrderQty.DataBindings.Add("Text", this.uxBindingSource, "MinOrderQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMaxOrderQty.DataBindings.Clear();
			this.uxMaxOrderQty.DataBindings.Add("Text", this.uxBindingSource, "MaxOrderQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOnOrderQty.DataBindings.Clear();
			this.uxOnOrderQty.DataBindings.Add("Text", this.uxBindingSource, "OnOrderQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUnitMeasureCode.DataBindings.Clear();
			this.uxUnitMeasureCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "UnitMeasureCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductVendorEditControlBase"/> class.
		/// </summary>
		public ProductVendorEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ProductVendor != null) _ProductVendor.Validate();
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
			this.uxProductId = new System.Windows.Forms.ComboBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxVendorId = new System.Windows.Forms.ComboBox();
			uxVendorIdLabel = new System.Windows.Forms.Label();
			this.uxAverageLeadTime = new System.Windows.Forms.TextBox();
			uxAverageLeadTimeLabel = new System.Windows.Forms.Label();
			this.uxStandardPrice = new System.Windows.Forms.TextBox();
			uxStandardPriceLabel = new System.Windows.Forms.Label();
			this.uxLastReceiptCost = new System.Windows.Forms.TextBox();
			uxLastReceiptCostLabel = new System.Windows.Forms.Label();
			this.uxLastReceiptDate = new System.Windows.Forms.DateTimePicker();
			uxLastReceiptDateLabel = new System.Windows.Forms.Label();
			this.uxMinOrderQty = new System.Windows.Forms.TextBox();
			uxMinOrderQtyLabel = new System.Windows.Forms.Label();
			this.uxMaxOrderQty = new System.Windows.Forms.TextBox();
			uxMaxOrderQtyLabel = new System.Windows.Forms.Label();
			this.uxOnOrderQty = new System.Windows.Forms.TextBox();
			uxOnOrderQtyLabel = new System.Windows.Forms.Label();
			this.uxUnitMeasureCode = new System.Windows.Forms.ComboBox();
			uxUnitMeasureCodeLabel = new System.Windows.Forms.Label();
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
			// uxProductIdLabel
			//
			this.uxProductIdLabel.Name = "uxProductIdLabel";
			this.uxProductIdLabel.Text = "Product Id:";
			this.uxProductIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductIdLabel);			
			//
			// uxProductId
			//
			this.uxProductId.Name = "uxProductId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductId);
			this.uxProductId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxProductId);
			//
			// uxVendorIdLabel
			//
			this.uxVendorIdLabel.Name = "uxVendorIdLabel";
			this.uxVendorIdLabel.Text = "Vendor Id:";
			this.uxVendorIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxVendorIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxVendorIdLabel);			
			//
			// uxVendorId
			//
			this.uxVendorId.Name = "uxVendorId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxVendorId);
			this.uxVendorId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxVendorId);
			//
			// uxAverageLeadTimeLabel
			//
			this.uxAverageLeadTimeLabel.Name = "uxAverageLeadTimeLabel";
			this.uxAverageLeadTimeLabel.Text = "Average Lead Time:";
			this.uxAverageLeadTimeLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxAverageLeadTimeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAverageLeadTimeLabel);			
			//
			// uxAverageLeadTime
			//
			this.uxAverageLeadTime.Name = "uxAverageLeadTime";
			//this.uxTableLayoutPanel.Controls.Add(this.uxAverageLeadTime);
			this.uxAverageLeadTime.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxAverageLeadTime);
			//
			// uxStandardPriceLabel
			//
			this.uxStandardPriceLabel.Name = "uxStandardPriceLabel";
			this.uxStandardPriceLabel.Text = "Standard Price:";
			this.uxStandardPriceLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxStandardPriceLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStandardPriceLabel);			
			//
			// uxStandardPrice
			//
			this.uxStandardPrice.Name = "uxStandardPrice";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStandardPrice);
			this.uxStandardPrice.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxStandardPrice);
			//
			// uxLastReceiptCostLabel
			//
			this.uxLastReceiptCostLabel.Name = "uxLastReceiptCostLabel";
			this.uxLastReceiptCostLabel.Text = "Last Receipt Cost:";
			this.uxLastReceiptCostLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxLastReceiptCostLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLastReceiptCostLabel);			
			//
			// uxLastReceiptCost
			//
			this.uxLastReceiptCost.Name = "uxLastReceiptCost";
			//this.uxTableLayoutPanel.Controls.Add(this.uxLastReceiptCost);
			this.uxLastReceiptCost.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxLastReceiptCost);
			//
			// uxLastReceiptDateLabel
			//
			this.uxLastReceiptDateLabel.Name = "uxLastReceiptDateLabel";
			this.uxLastReceiptDateLabel.Text = "Last Receipt Date:";
			this.uxLastReceiptDateLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxLastReceiptDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLastReceiptDateLabel);			
			//
			// uxLastReceiptDate
			//
			this.uxLastReceiptDate.Name = "uxLastReceiptDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxLastReceiptDate);
			this.uxLastReceiptDate.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxLastReceiptDate);
			//
			// uxMinOrderQtyLabel
			//
			this.uxMinOrderQtyLabel.Name = "uxMinOrderQtyLabel";
			this.uxMinOrderQtyLabel.Text = "Min Order Qty:";
			this.uxMinOrderQtyLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxMinOrderQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMinOrderQtyLabel);			
			//
			// uxMinOrderQty
			//
			this.uxMinOrderQty.Name = "uxMinOrderQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxMinOrderQty);
			this.uxMinOrderQty.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxMinOrderQty);
			//
			// uxMaxOrderQtyLabel
			//
			this.uxMaxOrderQtyLabel.Name = "uxMaxOrderQtyLabel";
			this.uxMaxOrderQtyLabel.Text = "Max Order Qty:";
			this.uxMaxOrderQtyLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxMaxOrderQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMaxOrderQtyLabel);			
			//
			// uxMaxOrderQty
			//
			this.uxMaxOrderQty.Name = "uxMaxOrderQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxMaxOrderQty);
			this.uxMaxOrderQty.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxMaxOrderQty);
			//
			// uxOnOrderQtyLabel
			//
			this.uxOnOrderQtyLabel.Name = "uxOnOrderQtyLabel";
			this.uxOnOrderQtyLabel.Text = "On Order Qty:";
			this.uxOnOrderQtyLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxOnOrderQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOnOrderQtyLabel);			
			//
			// uxOnOrderQty
			//
			this.uxOnOrderQty.Name = "uxOnOrderQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxOnOrderQty);
			this.uxOnOrderQty.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxOnOrderQty);
			//
			// uxUnitMeasureCodeLabel
			//
			this.uxUnitMeasureCodeLabel.Name = "uxUnitMeasureCodeLabel";
			this.uxUnitMeasureCodeLabel.Text = "Unit Measure Code:";
			this.uxUnitMeasureCodeLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxUnitMeasureCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitMeasureCodeLabel);			
			//
			// uxUnitMeasureCode
			//
			this.uxUnitMeasureCode.Name = "uxUnitMeasureCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitMeasureCode);
			this.uxUnitMeasureCode.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxUnitMeasureCode);
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
			// uxUnitMeasureCode
			//				
			this.uxUnitMeasureCode.DisplayMember = "Name";	
			this.uxUnitMeasureCode.ValueMember = "UnitMeasureCode";	
			//
			// uxVendorId
			//				
			this.uxVendorId.DisplayMember = "AccountNumber";	
			this.uxVendorId.ValueMember = "VendorId";	
			// 
			// ProductVendorEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ProductVendorEditControlBase";
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
		
				
		private Entities.TList<Entities.UnitMeasure> _UnitMeasureCodeList;
		
		/// <summary>
		/// The ComboBox associated with the UnitMeasureCode property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.UnitMeasure> UnitMeasureCodeList
		{
			get {return _UnitMeasureCodeList;}
			set 
			{
				this._UnitMeasureCodeList = value;
				this.uxUnitMeasureCode.DataSource = null;
				this.uxUnitMeasureCode.DataSource = value;
			}
		}
		
		private bool _allowNewItemInUnitMeasureCodeList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the UnitMeasureCode property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInUnitMeasureCodeList
		{
			get { return _allowNewItemInUnitMeasureCodeList;}
			set
			{
				this._allowNewItemInUnitMeasureCodeList = value;
				this.uxUnitMeasureCode.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        /// Indicates if the controls associated with the uxAverageLeadTime property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAverageLeadTimeVisible
        {
            get { return this.uxAverageLeadTime.Visible; }
            set
            {
                this.uxAverageLeadTimeLabel.Visible = value;
                this.uxAverageLeadTime.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAverageLeadTime property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAverageLeadTimeEnabled
        {
            get { return this.uxAverageLeadTime.Enabled; }
            set
            {
                this.uxAverageLeadTime.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStandardPrice property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStandardPriceVisible
        {
            get { return this.uxStandardPrice.Visible; }
            set
            {
                this.uxStandardPriceLabel.Visible = value;
                this.uxStandardPrice.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStandardPrice property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStandardPriceEnabled
        {
            get { return this.uxStandardPrice.Enabled; }
            set
            {
                this.uxStandardPrice.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLastReceiptCost property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLastReceiptCostVisible
        {
            get { return this.uxLastReceiptCost.Visible; }
            set
            {
                this.uxLastReceiptCostLabel.Visible = value;
                this.uxLastReceiptCost.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLastReceiptCost property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLastReceiptCostEnabled
        {
            get { return this.uxLastReceiptCost.Enabled; }
            set
            {
                this.uxLastReceiptCost.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLastReceiptDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLastReceiptDateVisible
        {
            get { return this.uxLastReceiptDate.Visible; }
            set
            {
                this.uxLastReceiptDateLabel.Visible = value;
                this.uxLastReceiptDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLastReceiptDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLastReceiptDateEnabled
        {
            get { return this.uxLastReceiptDate.Enabled; }
            set
            {
                this.uxLastReceiptDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxMinOrderQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxMinOrderQtyVisible
        {
            get { return this.uxMinOrderQty.Visible; }
            set
            {
                this.uxMinOrderQtyLabel.Visible = value;
                this.uxMinOrderQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxMinOrderQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxMinOrderQtyEnabled
        {
            get { return this.uxMinOrderQty.Enabled; }
            set
            {
                this.uxMinOrderQty.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxMaxOrderQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxMaxOrderQtyVisible
        {
            get { return this.uxMaxOrderQty.Visible; }
            set
            {
                this.uxMaxOrderQtyLabel.Visible = value;
                this.uxMaxOrderQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxMaxOrderQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxMaxOrderQtyEnabled
        {
            get { return this.uxMaxOrderQty.Enabled; }
            set
            {
                this.uxMaxOrderQty.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxOnOrderQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxOnOrderQtyVisible
        {
            get { return this.uxOnOrderQty.Visible; }
            set
            {
                this.uxOnOrderQtyLabel.Visible = value;
                this.uxOnOrderQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxOnOrderQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxOnOrderQtyEnabled
        {
            get { return this.uxOnOrderQty.Enabled; }
            set
            {
                this.uxOnOrderQty.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUnitMeasureCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUnitMeasureCodeVisible
        {
            get { return this.uxUnitMeasureCode.Visible; }
            set
            {
                this.uxUnitMeasureCodeLabel.Visible = value;
                this.uxUnitMeasureCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUnitMeasureCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUnitMeasureCodeEnabled
        {
            get { return this.uxUnitMeasureCode.Enabled; }
            set
            {
                this.uxUnitMeasureCode.Enabled = value;
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
