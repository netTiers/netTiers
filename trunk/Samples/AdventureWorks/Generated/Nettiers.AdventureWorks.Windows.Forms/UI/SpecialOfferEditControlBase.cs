
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.SpecialOffer"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SpecialOfferEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the SpecialOfferId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSpecialOfferId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SpecialOfferId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSpecialOfferIdLabel;
		
		/// <summary>
		/// TextBox for the Description property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDescription;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Description property.
		/// </summary>
		protected System.Windows.Forms.Label uxDescriptionLabel;
		
		/// <summary>
		/// TextBox for the DiscountPct property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDiscountPct;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DiscountPct property.
		/// </summary>
		protected System.Windows.Forms.Label uxDiscountPctLabel;
		
		/// <summary>
		/// TextBox for the Type property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxType;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Type property.
		/// </summary>
		protected System.Windows.Forms.Label uxTypeLabel;
		
		/// <summary>
		/// TextBox for the Category property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCategory;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Category property.
		/// </summary>
		protected System.Windows.Forms.Label uxCategoryLabel;
		
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
		/// TextBox for the MinQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxMinQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the MinQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxMinQtyLabel;
		
		/// <summary>
		/// TextBox for the MaxQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxMaxQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the MaxQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxMaxQtyLabel;
		
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
		private Entities.SpecialOffer _SpecialOffer;
		/// <summary>
		/// Gets or sets the <see cref="Entities.SpecialOffer"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.SpecialOffer"/> instance.</value>
		public Entities.SpecialOffer SpecialOffer
		{
			get {return this._SpecialOffer;}
			set
			{
				this._SpecialOffer = value;
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
			this.uxSpecialOfferId.DataBindings.Clear();
			this.uxSpecialOfferId.DataBindings.Add("Text", this.uxBindingSource, "SpecialOfferId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDescription.DataBindings.Clear();
			this.uxDescription.DataBindings.Add("Text", this.uxBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDiscountPct.DataBindings.Clear();
			this.uxDiscountPct.DataBindings.Add("Text", this.uxBindingSource, "DiscountPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxType.DataBindings.Clear();
			this.uxType.DataBindings.Add("Text", this.uxBindingSource, "Type", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCategory.DataBindings.Clear();
			this.uxCategory.DataBindings.Add("Text", this.uxBindingSource, "Category", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStartDate.DataBindings.Clear();
			this.uxStartDate.DataBindings.Add("Value", this.uxBindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEndDate.DataBindings.Clear();
			this.uxEndDate.DataBindings.Add("Value", this.uxBindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMinQty.DataBindings.Clear();
			this.uxMinQty.DataBindings.Add("Text", this.uxBindingSource, "MinQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMaxQty.DataBindings.Clear();
			this.uxMaxQty.DataBindings.Add("Text", this.uxBindingSource, "MaxQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SpecialOfferEditControlBase"/> class.
		/// </summary>
		public SpecialOfferEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_SpecialOffer != null) _SpecialOffer.Validate();
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
			this.uxSpecialOfferId = new System.Windows.Forms.TextBox();
			uxSpecialOfferIdLabel = new System.Windows.Forms.Label();
			this.uxDescription = new System.Windows.Forms.TextBox();
			uxDescriptionLabel = new System.Windows.Forms.Label();
			this.uxDiscountPct = new System.Windows.Forms.TextBox();
			uxDiscountPctLabel = new System.Windows.Forms.Label();
			this.uxType = new System.Windows.Forms.TextBox();
			uxTypeLabel = new System.Windows.Forms.Label();
			this.uxCategory = new System.Windows.Forms.TextBox();
			uxCategoryLabel = new System.Windows.Forms.Label();
			this.uxStartDate = new System.Windows.Forms.DateTimePicker();
			uxStartDateLabel = new System.Windows.Forms.Label();
			this.uxEndDate = new System.Windows.Forms.DateTimePicker();
			uxEndDateLabel = new System.Windows.Forms.Label();
			this.uxMinQty = new System.Windows.Forms.TextBox();
			uxMinQtyLabel = new System.Windows.Forms.Label();
			this.uxMaxQty = new System.Windows.Forms.TextBox();
			uxMaxQtyLabel = new System.Windows.Forms.Label();
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
			// uxSpecialOfferIdLabel
			//
			this.uxSpecialOfferIdLabel.Name = "uxSpecialOfferIdLabel";
			this.uxSpecialOfferIdLabel.Text = "Special Offer Id:";
			this.uxSpecialOfferIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxSpecialOfferIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSpecialOfferIdLabel);			
			//
			// uxSpecialOfferId
			//
			this.uxSpecialOfferId.Name = "uxSpecialOfferId";
            this.uxSpecialOfferId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSpecialOfferId);
			this.uxSpecialOfferId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxSpecialOfferId);
			//
			// uxDescriptionLabel
			//
			this.uxDescriptionLabel.Name = "uxDescriptionLabel";
			this.uxDescriptionLabel.Text = "Description:";
			this.uxDescriptionLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxDescriptionLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDescriptionLabel);			
			//
			// uxDescription
			//
			this.uxDescription.Name = "uxDescription";
			this.uxDescription.Width = 250;
			this.uxDescription.MaxLength = 255;
			//this.uxTableLayoutPanel.Controls.Add(this.uxDescription);
			this.uxDescription.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxDescription);
			//
			// uxDiscountPctLabel
			//
			this.uxDiscountPctLabel.Name = "uxDiscountPctLabel";
			this.uxDiscountPctLabel.Text = "Discount Pct:";
			this.uxDiscountPctLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxDiscountPctLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDiscountPctLabel);			
			//
			// uxDiscountPct
			//
			this.uxDiscountPct.Name = "uxDiscountPct";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDiscountPct);
			this.uxDiscountPct.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxDiscountPct);
			//
			// uxTypeLabel
			//
			this.uxTypeLabel.Name = "uxTypeLabel";
			this.uxTypeLabel.Text = "Type:";
			this.uxTypeLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxTypeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTypeLabel);			
			//
			// uxType
			//
			this.uxType.Name = "uxType";
			this.uxType.Width = 250;
			this.uxType.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxType);
			this.uxType.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxType);
			//
			// uxCategoryLabel
			//
			this.uxCategoryLabel.Name = "uxCategoryLabel";
			this.uxCategoryLabel.Text = "Category:";
			this.uxCategoryLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxCategoryLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCategoryLabel);			
			//
			// uxCategory
			//
			this.uxCategory.Name = "uxCategory";
			this.uxCategory.Width = 250;
			this.uxCategory.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCategory);
			this.uxCategory.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxCategory);
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
			// uxMinQtyLabel
			//
			this.uxMinQtyLabel.Name = "uxMinQtyLabel";
			this.uxMinQtyLabel.Text = "Min Qty:";
			this.uxMinQtyLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxMinQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMinQtyLabel);			
			//
			// uxMinQty
			//
			this.uxMinQty.Name = "uxMinQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxMinQty);
			this.uxMinQty.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxMinQty);
			//
			// uxMaxQtyLabel
			//
			this.uxMaxQtyLabel.Name = "uxMaxQtyLabel";
			this.uxMaxQtyLabel.Text = "Max Qty:";
			this.uxMaxQtyLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxMaxQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMaxQtyLabel);			
			//
			// uxMaxQty
			//
			this.uxMaxQty.Name = "uxMaxQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxMaxQty);
			this.uxMaxQty.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxMaxQty);
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
			// SpecialOfferEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "SpecialOfferEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
		
		#endregion
		
        #region Field visibility

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
        /// Indicates if the controls associated with the uxDescription property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDescriptionVisible
        {
            get { return this.uxDescription.Visible; }
            set
            {
                this.uxDescriptionLabel.Visible = value;
                this.uxDescription.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDescription property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDescriptionEnabled
        {
            get { return this.uxDescription.Enabled; }
            set
            {
                this.uxDescription.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDiscountPct property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDiscountPctVisible
        {
            get { return this.uxDiscountPct.Visible; }
            set
            {
                this.uxDiscountPctLabel.Visible = value;
                this.uxDiscountPct.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDiscountPct property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDiscountPctEnabled
        {
            get { return this.uxDiscountPct.Enabled; }
            set
            {
                this.uxDiscountPct.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxType property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTypeVisible
        {
            get { return this.uxType.Visible; }
            set
            {
                this.uxTypeLabel.Visible = value;
                this.uxType.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxType property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTypeEnabled
        {
            get { return this.uxType.Enabled; }
            set
            {
                this.uxType.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCategory property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCategoryVisible
        {
            get { return this.uxCategory.Visible; }
            set
            {
                this.uxCategoryLabel.Visible = value;
                this.uxCategory.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCategory property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCategoryEnabled
        {
            get { return this.uxCategory.Enabled; }
            set
            {
                this.uxCategory.Enabled = value;
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
        /// Indicates if the controls associated with the uxMinQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxMinQtyVisible
        {
            get { return this.uxMinQty.Visible; }
            set
            {
                this.uxMinQtyLabel.Visible = value;
                this.uxMinQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxMinQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxMinQtyEnabled
        {
            get { return this.uxMinQty.Enabled; }
            set
            {
                this.uxMinQty.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxMaxQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxMaxQtyVisible
        {
            get { return this.uxMaxQty.Visible; }
            set
            {
                this.uxMaxQtyLabel.Visible = value;
                this.uxMaxQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxMaxQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxMaxQtyEnabled
        {
            get { return this.uxMaxQty.Enabled; }
            set
            {
                this.uxMaxQty.Enabled = value;
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
