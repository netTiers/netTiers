
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Vendor"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class VendorEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the VendorId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxVendorId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the VendorId property.
		/// </summary>
		protected System.Windows.Forms.Label uxVendorIdLabel;
		
		/// <summary>
		/// TextBox for the AccountNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAccountNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AccountNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxAccountNumberLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// TextBox for the CreditRating property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCreditRating;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreditRating property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreditRatingLabel;
		
		/// <summary>
		/// CheckBox for the PreferredVendorStatus property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxPreferredVendorStatus;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PreferredVendorStatus property.
		/// </summary>
		protected System.Windows.Forms.Label uxPreferredVendorStatusLabel;
		
		/// <summary>
		/// CheckBox for the ActiveFlag property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxActiveFlag;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ActiveFlag property.
		/// </summary>
		protected System.Windows.Forms.Label uxActiveFlagLabel;
		
		/// <summary>
		/// TextBox for the PurchasingWebServiceUrl property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPurchasingWebServiceUrl;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PurchasingWebServiceUrl property.
		/// </summary>
		protected System.Windows.Forms.Label uxPurchasingWebServiceUrlLabel;
		
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
		private Entities.Vendor _Vendor;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Vendor"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Vendor"/> instance.</value>
		public Entities.Vendor Vendor
		{
			get {return this._Vendor;}
			set
			{
				this._Vendor = value;
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
			this.uxVendorId.DataBindings.Clear();
			this.uxVendorId.DataBindings.Add("Text", this.uxBindingSource, "VendorId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAccountNumber.DataBindings.Clear();
			this.uxAccountNumber.DataBindings.Add("Text", this.uxBindingSource, "AccountNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCreditRating.DataBindings.Clear();
			this.uxCreditRating.DataBindings.Add("Text", this.uxBindingSource, "CreditRating", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPreferredVendorStatus.DataBindings.Clear();
			this.uxPreferredVendorStatus.DataBindings.Add("Checked", this.uxBindingSource, "PreferredVendorStatus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxActiveFlag.DataBindings.Clear();
			this.uxActiveFlag.DataBindings.Add("Checked", this.uxBindingSource, "ActiveFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPurchasingWebServiceUrl.DataBindings.Clear();
			this.uxPurchasingWebServiceUrl.DataBindings.Add("Text", this.uxBindingSource, "PurchasingWebServiceUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="VendorEditControlBase"/> class.
		/// </summary>
		public VendorEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Vendor != null) _Vendor.Validate();
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
			this.uxVendorId = new System.Windows.Forms.TextBox();
			uxVendorIdLabel = new System.Windows.Forms.Label();
			this.uxAccountNumber = new System.Windows.Forms.TextBox();
			uxAccountNumberLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxCreditRating = new System.Windows.Forms.TextBox();
			uxCreditRatingLabel = new System.Windows.Forms.Label();
			this.uxPreferredVendorStatus = new System.Windows.Forms.CheckBox();
			uxPreferredVendorStatusLabel = new System.Windows.Forms.Label();
			this.uxActiveFlag = new System.Windows.Forms.CheckBox();
			uxActiveFlagLabel = new System.Windows.Forms.Label();
			this.uxPurchasingWebServiceUrl = new System.Windows.Forms.TextBox();
			uxPurchasingWebServiceUrlLabel = new System.Windows.Forms.Label();
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
			// uxVendorIdLabel
			//
			this.uxVendorIdLabel.Name = "uxVendorIdLabel";
			this.uxVendorIdLabel.Text = "Vendor Id:";
			this.uxVendorIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxVendorIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxVendorIdLabel);			
			//
			// uxVendorId
			//
			this.uxVendorId.Name = "uxVendorId";
            this.uxVendorId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxVendorId);
			this.uxVendorId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxVendorId);
			//
			// uxAccountNumberLabel
			//
			this.uxAccountNumberLabel.Name = "uxAccountNumberLabel";
			this.uxAccountNumberLabel.Text = "Account Number:";
			this.uxAccountNumberLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxAccountNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAccountNumberLabel);			
			//
			// uxAccountNumber
			//
			this.uxAccountNumber.Name = "uxAccountNumber";
			this.uxAccountNumber.Width = 250;
			this.uxAccountNumber.MaxLength = 15;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAccountNumber);
			this.uxAccountNumber.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxAccountNumber);
			//
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxName);
			//
			// uxCreditRatingLabel
			//
			this.uxCreditRatingLabel.Name = "uxCreditRatingLabel";
			this.uxCreditRatingLabel.Text = "Credit Rating:";
			this.uxCreditRatingLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxCreditRatingLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditRatingLabel);			
			//
			// uxCreditRating
			//
			this.uxCreditRating.Name = "uxCreditRating";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditRating);
			this.uxCreditRating.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxCreditRating);
			//
			// uxPreferredVendorStatusLabel
			//
			this.uxPreferredVendorStatusLabel.Name = "uxPreferredVendorStatusLabel";
			this.uxPreferredVendorStatusLabel.Text = "Preferred Vendor Status:";
			this.uxPreferredVendorStatusLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxPreferredVendorStatusLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPreferredVendorStatusLabel);			
			//
			// uxPreferredVendorStatus
			//
			this.uxPreferredVendorStatus.Name = "uxPreferredVendorStatus";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPreferredVendorStatus);
			this.uxPreferredVendorStatus.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxPreferredVendorStatus);
			//
			// uxActiveFlagLabel
			//
			this.uxActiveFlagLabel.Name = "uxActiveFlagLabel";
			this.uxActiveFlagLabel.Text = "Active Flag:";
			this.uxActiveFlagLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxActiveFlagLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxActiveFlagLabel);			
			//
			// uxActiveFlag
			//
			this.uxActiveFlag.Name = "uxActiveFlag";
			//this.uxTableLayoutPanel.Controls.Add(this.uxActiveFlag);
			this.uxActiveFlag.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxActiveFlag);
			//
			// uxPurchasingWebServiceUrlLabel
			//
			this.uxPurchasingWebServiceUrlLabel.Name = "uxPurchasingWebServiceUrlLabel";
			this.uxPurchasingWebServiceUrlLabel.Text = "Purchasing Web Service Url:";
			this.uxPurchasingWebServiceUrlLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxPurchasingWebServiceUrlLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchasingWebServiceUrlLabel);			
			//
			// uxPurchasingWebServiceUrl
			//
			this.uxPurchasingWebServiceUrl.Name = "uxPurchasingWebServiceUrl";
			this.uxPurchasingWebServiceUrl.Width = 250;
			this.uxPurchasingWebServiceUrl.MaxLength = 1024;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPurchasingWebServiceUrl);
			this.uxPurchasingWebServiceUrl.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxPurchasingWebServiceUrl);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxModifiedDate);
			// 
			// VendorEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "VendorEditControlBase";
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
        /// Indicates if the controls associated with the uxName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNameVisible
        {
            get { return this.uxName.Visible; }
            set
            {
                this.uxNameLabel.Visible = value;
                this.uxName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNameEnabled
        {
            get { return this.uxName.Enabled; }
            set
            {
                this.uxName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCreditRating property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCreditRatingVisible
        {
            get { return this.uxCreditRating.Visible; }
            set
            {
                this.uxCreditRatingLabel.Visible = value;
                this.uxCreditRating.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCreditRating property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCreditRatingEnabled
        {
            get { return this.uxCreditRating.Enabled; }
            set
            {
                this.uxCreditRating.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPreferredVendorStatus property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPreferredVendorStatusVisible
        {
            get { return this.uxPreferredVendorStatus.Visible; }
            set
            {
                this.uxPreferredVendorStatusLabel.Visible = value;
                this.uxPreferredVendorStatus.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPreferredVendorStatus property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPreferredVendorStatusEnabled
        {
            get { return this.uxPreferredVendorStatus.Enabled; }
            set
            {
                this.uxPreferredVendorStatus.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxActiveFlag property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxActiveFlagVisible
        {
            get { return this.uxActiveFlag.Visible; }
            set
            {
                this.uxActiveFlagLabel.Visible = value;
                this.uxActiveFlag.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxActiveFlag property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxActiveFlagEnabled
        {
            get { return this.uxActiveFlag.Enabled; }
            set
            {
                this.uxActiveFlag.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPurchasingWebServiceUrl property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPurchasingWebServiceUrlVisible
        {
            get { return this.uxPurchasingWebServiceUrl.Visible; }
            set
            {
                this.uxPurchasingWebServiceUrlLabel.Visible = value;
                this.uxPurchasingWebServiceUrl.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPurchasingWebServiceUrl property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPurchasingWebServiceUrlEnabled
        {
            get { return this.uxPurchasingWebServiceUrl.Enabled; }
            set
            {
                this.uxPurchasingWebServiceUrl.Enabled = value;
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
