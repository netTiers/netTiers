
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.SalesPerson"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesPersonEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the SalesQuota property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSalesQuota;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesQuota property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesQuotaLabel;
		
		/// <summary>
		/// TextBox for the Bonus property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxBonus;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Bonus property.
		/// </summary>
		protected System.Windows.Forms.Label uxBonusLabel;
		
		/// <summary>
		/// TextBox for the CommissionPct property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCommissionPct;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CommissionPct property.
		/// </summary>
		protected System.Windows.Forms.Label uxCommissionPctLabel;
		
		/// <summary>
		/// TextBox for the SalesYtd property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSalesYtd;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesYtd property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesYtdLabel;
		
		/// <summary>
		/// TextBox for the SalesLastYear property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSalesLastYear;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesLastYear property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesLastYearLabel;
		
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
		private Entities.SalesPerson _SalesPerson;
		/// <summary>
		/// Gets or sets the <see cref="Entities.SalesPerson"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.SalesPerson"/> instance.</value>
		public Entities.SalesPerson SalesPerson
		{
			get {return this._SalesPerson;}
			set
			{
				this._SalesPerson = value;
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
			this.uxSalesPersonId.DataBindings.Clear();
			this.uxSalesPersonId.DataBindings.Add("SelectedValue", this.uxBindingSource, "SalesPersonId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTerritoryId.DataBindings.Clear();
			this.uxTerritoryId.DataBindings.Add("SelectedValue", this.uxBindingSource, "TerritoryId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesQuota.DataBindings.Clear();
			this.uxSalesQuota.DataBindings.Add("Text", this.uxBindingSource, "SalesQuota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBonus.DataBindings.Clear();
			this.uxBonus.DataBindings.Add("Text", this.uxBindingSource, "Bonus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCommissionPct.DataBindings.Clear();
			this.uxCommissionPct.DataBindings.Add("Text", this.uxBindingSource, "CommissionPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesYtd.DataBindings.Clear();
			this.uxSalesYtd.DataBindings.Add("Text", this.uxBindingSource, "SalesYtd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesLastYear.DataBindings.Clear();
			this.uxSalesLastYear.DataBindings.Add("Text", this.uxBindingSource, "SalesLastYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SalesPersonEditControlBase"/> class.
		/// </summary>
		public SalesPersonEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_SalesPerson != null) _SalesPerson.Validate();
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
			this.uxSalesPersonId = new System.Windows.Forms.ComboBox();
			uxSalesPersonIdLabel = new System.Windows.Forms.Label();
			this.uxTerritoryId = new System.Windows.Forms.ComboBox();
			uxTerritoryIdLabel = new System.Windows.Forms.Label();
			this.uxSalesQuota = new System.Windows.Forms.TextBox();
			uxSalesQuotaLabel = new System.Windows.Forms.Label();
			this.uxBonus = new System.Windows.Forms.TextBox();
			uxBonusLabel = new System.Windows.Forms.Label();
			this.uxCommissionPct = new System.Windows.Forms.TextBox();
			uxCommissionPctLabel = new System.Windows.Forms.Label();
			this.uxSalesYtd = new System.Windows.Forms.TextBox();
			uxSalesYtdLabel = new System.Windows.Forms.Label();
			this.uxSalesLastYear = new System.Windows.Forms.TextBox();
			uxSalesLastYearLabel = new System.Windows.Forms.Label();
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
			// uxSalesPersonIdLabel
			//
			this.uxSalesPersonIdLabel.Name = "uxSalesPersonIdLabel";
			this.uxSalesPersonIdLabel.Text = "Sales Person Id:";
			this.uxSalesPersonIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxSalesPersonIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesPersonIdLabel);			
			//
			// uxSalesPersonId
			//
			this.uxSalesPersonId.Name = "uxSalesPersonId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesPersonId);
			this.uxSalesPersonId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxSalesPersonId);
			//
			// uxTerritoryIdLabel
			//
			this.uxTerritoryIdLabel.Name = "uxTerritoryIdLabel";
			this.uxTerritoryIdLabel.Text = "Territory Id:";
			this.uxTerritoryIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxTerritoryIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTerritoryIdLabel);			
			//
			// uxTerritoryId
			//
			this.uxTerritoryId.Name = "uxTerritoryId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTerritoryId);
			this.uxTerritoryId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxTerritoryId);
			//
			// uxSalesQuotaLabel
			//
			this.uxSalesQuotaLabel.Name = "uxSalesQuotaLabel";
			this.uxSalesQuotaLabel.Text = "Sales Quota:";
			this.uxSalesQuotaLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxSalesQuotaLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesQuotaLabel);			
			//
			// uxSalesQuota
			//
			this.uxSalesQuota.Name = "uxSalesQuota";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesQuota);
			this.uxSalesQuota.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxSalesQuota);
			//
			// uxBonusLabel
			//
			this.uxBonusLabel.Name = "uxBonusLabel";
			this.uxBonusLabel.Text = "Bonus:";
			this.uxBonusLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxBonusLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBonusLabel);			
			//
			// uxBonus
			//
			this.uxBonus.Name = "uxBonus";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBonus);
			this.uxBonus.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxBonus);
			//
			// uxCommissionPctLabel
			//
			this.uxCommissionPctLabel.Name = "uxCommissionPctLabel";
			this.uxCommissionPctLabel.Text = "Commission Pct:";
			this.uxCommissionPctLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxCommissionPctLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCommissionPctLabel);			
			//
			// uxCommissionPct
			//
			this.uxCommissionPct.Name = "uxCommissionPct";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCommissionPct);
			this.uxCommissionPct.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxCommissionPct);
			//
			// uxSalesYtdLabel
			//
			this.uxSalesYtdLabel.Name = "uxSalesYtdLabel";
			this.uxSalesYtdLabel.Text = "Sales Ytd:";
			this.uxSalesYtdLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxSalesYtdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesYtdLabel);			
			//
			// uxSalesYtd
			//
			this.uxSalesYtd.Name = "uxSalesYtd";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesYtd);
			this.uxSalesYtd.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxSalesYtd);
			//
			// uxSalesLastYearLabel
			//
			this.uxSalesLastYearLabel.Name = "uxSalesLastYearLabel";
			this.uxSalesLastYearLabel.Text = "Sales Last Year:";
			this.uxSalesLastYearLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxSalesLastYearLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesLastYearLabel);			
			//
			// uxSalesLastYear
			//
			this.uxSalesLastYear.Name = "uxSalesLastYear";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesLastYear);
			this.uxSalesLastYear.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxSalesLastYear);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxSalesPersonId
			//				
			this.uxSalesPersonId.DisplayMember = "NationalIdNumber";	
			this.uxSalesPersonId.ValueMember = "EmployeeId";	
			//
			// uxTerritoryId
			//				
			this.uxTerritoryId.DisplayMember = "Name";	
			this.uxTerritoryId.ValueMember = "TerritoryId";	
			// 
			// SalesPersonEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "SalesPersonEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Employee> _SalesPersonIdList;
		
		/// <summary>
		/// The ComboBox associated with the SalesPersonId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Employee> SalesPersonIdList
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
		
		
		#endregion
		
        #region Field visibility

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
        /// Indicates if the controls associated with the uxSalesQuota property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesQuotaVisible
        {
            get { return this.uxSalesQuota.Visible; }
            set
            {
                this.uxSalesQuotaLabel.Visible = value;
                this.uxSalesQuota.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesQuota property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesQuotaEnabled
        {
            get { return this.uxSalesQuota.Enabled; }
            set
            {
                this.uxSalesQuota.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBonus property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBonusVisible
        {
            get { return this.uxBonus.Visible; }
            set
            {
                this.uxBonusLabel.Visible = value;
                this.uxBonus.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBonus property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBonusEnabled
        {
            get { return this.uxBonus.Enabled; }
            set
            {
                this.uxBonus.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCommissionPct property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCommissionPctVisible
        {
            get { return this.uxCommissionPct.Visible; }
            set
            {
                this.uxCommissionPctLabel.Visible = value;
                this.uxCommissionPct.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCommissionPct property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCommissionPctEnabled
        {
            get { return this.uxCommissionPct.Enabled; }
            set
            {
                this.uxCommissionPct.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSalesYtd property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesYtdVisible
        {
            get { return this.uxSalesYtd.Visible; }
            set
            {
                this.uxSalesYtdLabel.Visible = value;
                this.uxSalesYtd.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesYtd property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesYtdEnabled
        {
            get { return this.uxSalesYtd.Enabled; }
            set
            {
                this.uxSalesYtd.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSalesLastYear property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesLastYearVisible
        {
            get { return this.uxSalesLastYear.Visible; }
            set
            {
                this.uxSalesLastYearLabel.Visible = value;
                this.uxSalesLastYear.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesLastYear property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesLastYearEnabled
        {
            get { return this.uxSalesLastYear.Enabled; }
            set
            {
                this.uxSalesLastYear.Enabled = value;
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
