
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.WorkOrder"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class WorkOrderEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the WorkOrderId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxWorkOrderId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the WorkOrderId property.
		/// </summary>
		protected System.Windows.Forms.Label uxWorkOrderIdLabel;
		
		/// <summary>
		/// ComboBox for the ProductId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// TextBox for the OrderQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxOrderQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OrderQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxOrderQtyLabel;
		
		/// <summary>
		/// TextBox for the StockedQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStockedQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StockedQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxStockedQtyLabel;
		
		/// <summary>
		/// TextBox for the ScrappedQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxScrappedQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ScrappedQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxScrappedQtyLabel;
		
		/// <summary>
		/// DataTimePicker for the StartDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxStartDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StartDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxStartDateLabel;
		
		/// <summary>
		/// DataTimePicker for the EndDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxEndDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EndDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxEndDateLabel;
		
		/// <summary>
		/// DataTimePicker for the DueDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxDueDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DueDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxDueDateLabel;
		
		/// <summary>
		/// ComboBox for the ScrapReasonId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxScrapReasonId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ScrapReasonId property.
		/// </summary>
		protected System.Windows.Forms.Label uxScrapReasonIdLabel;
		
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
		private Entities.WorkOrder _WorkOrder;
		/// <summary>
		/// Gets or sets the <see cref="Entities.WorkOrder"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.WorkOrder"/> instance.</value>
		public Entities.WorkOrder WorkOrder
		{
			get {return this._WorkOrder;}
			set
			{
				this._WorkOrder = value;
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
			this.uxWorkOrderId.DataBindings.Clear();
			this.uxWorkOrderId.DataBindings.Add("Text", this.uxBindingSource, "WorkOrderId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOrderQty.DataBindings.Clear();
			this.uxOrderQty.DataBindings.Add("Text", this.uxBindingSource, "OrderQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStockedQty.DataBindings.Clear();
			this.uxStockedQty.DataBindings.Add("Text", this.uxBindingSource, "StockedQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxScrappedQty.DataBindings.Clear();
			this.uxScrappedQty.DataBindings.Add("Text", this.uxBindingSource, "ScrappedQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStartDate.DataBindings.Clear();
			this.uxStartDate.DataBindings.Add("Value", this.uxBindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEndDate.DataBindings.Clear();
			this.uxEndDate.DataBindings.Add("Value", this.uxBindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDueDate.DataBindings.Clear();
			this.uxDueDate.DataBindings.Add("Value", this.uxBindingSource, "DueDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxScrapReasonId.DataBindings.Clear();
			this.uxScrapReasonId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ScrapReasonId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="WorkOrderEditControlBase"/> class.
		/// </summary>
		public WorkOrderEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_WorkOrder != null) _WorkOrder.Validate();
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
			this.uxWorkOrderId = new System.Windows.Forms.TextBox();
			uxWorkOrderIdLabel = new System.Windows.Forms.Label();
			this.uxProductId = new System.Windows.Forms.ComboBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxOrderQty = new System.Windows.Forms.TextBox();
			uxOrderQtyLabel = new System.Windows.Forms.Label();
			this.uxStockedQty = new System.Windows.Forms.TextBox();
			uxStockedQtyLabel = new System.Windows.Forms.Label();
			this.uxScrappedQty = new System.Windows.Forms.TextBox();
			uxScrappedQtyLabel = new System.Windows.Forms.Label();
			this.uxStartDate = new System.Windows.Forms.DateTimePicker();
			uxStartDateLabel = new System.Windows.Forms.Label();
			this.uxEndDate = new System.Windows.Forms.DateTimePicker();
			uxEndDateLabel = new System.Windows.Forms.Label();
			this.uxDueDate = new System.Windows.Forms.DateTimePicker();
			uxDueDateLabel = new System.Windows.Forms.Label();
			this.uxScrapReasonId = new System.Windows.Forms.ComboBox();
			uxScrapReasonIdLabel = new System.Windows.Forms.Label();
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
			// uxWorkOrderIdLabel
			//
			this.uxWorkOrderIdLabel.Name = "uxWorkOrderIdLabel";
			this.uxWorkOrderIdLabel.Text = "Work Order Id:";
			this.uxWorkOrderIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxWorkOrderIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxWorkOrderIdLabel);			
			//
			// uxWorkOrderId
			//
			this.uxWorkOrderId.Name = "uxWorkOrderId";
            this.uxWorkOrderId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxWorkOrderId);
			this.uxWorkOrderId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxWorkOrderId);
			//
			// uxProductIdLabel
			//
			this.uxProductIdLabel.Name = "uxProductIdLabel";
			this.uxProductIdLabel.Text = "Product Id:";
			this.uxProductIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductIdLabel);			
			//
			// uxProductId
			//
			this.uxProductId.Name = "uxProductId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductId);
			this.uxProductId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxProductId);
			//
			// uxOrderQtyLabel
			//
			this.uxOrderQtyLabel.Name = "uxOrderQtyLabel";
			this.uxOrderQtyLabel.Text = "Order Qty:";
			this.uxOrderQtyLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxOrderQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrderQtyLabel);			
			//
			// uxOrderQty
			//
			this.uxOrderQty.Name = "uxOrderQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrderQty);
			this.uxOrderQty.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxOrderQty);
			//
			// uxStockedQtyLabel
			//
			this.uxStockedQtyLabel.Name = "uxStockedQtyLabel";
			this.uxStockedQtyLabel.Text = "Stocked Qty:";
			this.uxStockedQtyLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxStockedQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStockedQtyLabel);			
			//
			// uxStockedQty
			//
			this.uxStockedQty.Name = "uxStockedQty";
            this.uxStockedQty.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxStockedQty);
			this.uxStockedQty.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxStockedQty);
			//
			// uxScrappedQtyLabel
			//
			this.uxScrappedQtyLabel.Name = "uxScrappedQtyLabel";
			this.uxScrappedQtyLabel.Text = "Scrapped Qty:";
			this.uxScrappedQtyLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxScrappedQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxScrappedQtyLabel);			
			//
			// uxScrappedQty
			//
			this.uxScrappedQty.Name = "uxScrappedQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxScrappedQty);
			this.uxScrappedQty.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxScrappedQty);
			//
			// uxStartDateLabel
			//
			this.uxStartDateLabel.Name = "uxStartDateLabel";
			this.uxStartDateLabel.Text = "Start Date:";
			this.uxStartDateLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxStartDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStartDateLabel);			
			//
			// uxStartDate
			//
			this.uxStartDate.Name = "uxStartDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStartDate);
			this.uxStartDate.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxStartDate);
			//
			// uxEndDateLabel
			//
			this.uxEndDateLabel.Name = "uxEndDateLabel";
			this.uxEndDateLabel.Text = "End Date:";
			this.uxEndDateLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxEndDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEndDateLabel);			
			//
			// uxEndDate
			//
			this.uxEndDate.Name = "uxEndDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEndDate);
			this.uxEndDate.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxEndDate);
			//
			// uxDueDateLabel
			//
			this.uxDueDateLabel.Name = "uxDueDateLabel";
			this.uxDueDateLabel.Text = "Due Date:";
			this.uxDueDateLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxDueDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDueDateLabel);			
			//
			// uxDueDate
			//
			this.uxDueDate.Name = "uxDueDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDueDate);
			this.uxDueDate.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxDueDate);
			//
			// uxScrapReasonIdLabel
			//
			this.uxScrapReasonIdLabel.Name = "uxScrapReasonIdLabel";
			this.uxScrapReasonIdLabel.Text = "Scrap Reason Id:";
			this.uxScrapReasonIdLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxScrapReasonIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxScrapReasonIdLabel);			
			//
			// uxScrapReasonId
			//
			this.uxScrapReasonId.Name = "uxScrapReasonId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxScrapReasonId);
			this.uxScrapReasonId.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxScrapReasonId);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxProductId
			//				
			this.uxProductId.DisplayMember = "Name";	
			this.uxProductId.ValueMember = "ProductId";	
			//
			// uxScrapReasonId
			//				
			this.uxScrapReasonId.DisplayMember = "Name";	
			this.uxScrapReasonId.ValueMember = "ScrapReasonId";	
			// 
			// WorkOrderEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "WorkOrderEditControlBase";
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
		
				
		private Entities.TList<Entities.ScrapReason> _ScrapReasonIdList;
		
		/// <summary>
		/// The ComboBox associated with the ScrapReasonId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.ScrapReason> ScrapReasonIdList
		{
			get {return _ScrapReasonIdList;}
			set 
			{
				this._ScrapReasonIdList = value;
				this.uxScrapReasonId.DataSource = null;
				this.uxScrapReasonId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInScrapReasonIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ScrapReasonId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInScrapReasonIdList
		{
			get { return _allowNewItemInScrapReasonIdList;}
			set
			{
				this._allowNewItemInScrapReasonIdList = value;
				this.uxScrapReasonId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxWorkOrderId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxWorkOrderIdVisible
        {
            get { return this.uxWorkOrderId.Visible; }
            set
            {
                this.uxWorkOrderIdLabel.Visible = value;
                this.uxWorkOrderId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxWorkOrderId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxWorkOrderIdEnabled
        {
            get { return this.uxWorkOrderId.Enabled; }
            set
            {
                this.uxWorkOrderId.Enabled = value;
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
        /// Indicates if the controls associated with the uxScrappedQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxScrappedQtyVisible
        {
            get { return this.uxScrappedQty.Visible; }
            set
            {
                this.uxScrappedQtyLabel.Visible = value;
                this.uxScrappedQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxScrappedQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxScrappedQtyEnabled
        {
            get { return this.uxScrappedQty.Enabled; }
            set
            {
                this.uxScrappedQty.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStartDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStartDateVisible
        {
            get { return this.uxStartDate.Visible; }
            set
            {
                this.uxStartDateLabel.Visible = value;
                this.uxStartDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStartDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStartDateEnabled
        {
            get { return this.uxStartDate.Enabled; }
            set
            {
                this.uxStartDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEndDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEndDateVisible
        {
            get { return this.uxEndDate.Visible; }
            set
            {
                this.uxEndDateLabel.Visible = value;
                this.uxEndDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEndDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEndDateEnabled
        {
            get { return this.uxEndDate.Enabled; }
            set
            {
                this.uxEndDate.Enabled = value;
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
        /// Indicates if the controls associated with the uxScrapReasonId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxScrapReasonIdVisible
        {
            get { return this.uxScrapReasonId.Visible; }
            set
            {
                this.uxScrapReasonIdLabel.Visible = value;
                this.uxScrapReasonId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxScrapReasonId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxScrapReasonIdEnabled
        {
            get { return this.uxScrapReasonId.Enabled; }
            set
            {
                this.uxScrapReasonId.Enabled = value;
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
