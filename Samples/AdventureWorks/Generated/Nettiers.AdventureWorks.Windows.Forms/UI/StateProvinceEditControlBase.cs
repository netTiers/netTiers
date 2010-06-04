
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.StateProvince"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class StateProvinceEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the StateProvinceId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStateProvinceId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StateProvinceId property.
		/// </summary>
		protected System.Windows.Forms.Label uxStateProvinceIdLabel;
		
		/// <summary>
		/// TextBox for the StateProvinceCode property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStateProvinceCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StateProvinceCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxStateProvinceCodeLabel;
		
		/// <summary>
		/// ComboBox for the CountryRegionCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxCountryRegionCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CountryRegionCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxCountryRegionCodeLabel;
		
		/// <summary>
		/// CheckBox for the IsOnlyStateProvinceFlag property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIsOnlyStateProvinceFlag;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IsOnlyStateProvinceFlag property.
		/// </summary>
		protected System.Windows.Forms.Label uxIsOnlyStateProvinceFlagLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// ComboBox for the TerritoryId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxTerritoryId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TerritoryId property.
		/// </summary>
		protected System.Windows.Forms.Label uxTerritoryIdLabel;
		
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
		private Entities.StateProvince _StateProvince;
		/// <summary>
		/// Gets or sets the <see cref="Entities.StateProvince"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.StateProvince"/> instance.</value>
		public Entities.StateProvince StateProvince
		{
			get {return this._StateProvince;}
			set
			{
				this._StateProvince = value;
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
			this.uxStateProvinceId.DataBindings.Clear();
			this.uxStateProvinceId.DataBindings.Add("Text", this.uxBindingSource, "StateProvinceId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStateProvinceCode.DataBindings.Clear();
			this.uxStateProvinceCode.DataBindings.Add("Text", this.uxBindingSource, "StateProvinceCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCountryRegionCode.DataBindings.Clear();
			this.uxCountryRegionCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "CountryRegionCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIsOnlyStateProvinceFlag.DataBindings.Clear();
			this.uxIsOnlyStateProvinceFlag.DataBindings.Add("Checked", this.uxBindingSource, "IsOnlyStateProvinceFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTerritoryId.DataBindings.Clear();
			this.uxTerritoryId.DataBindings.Add("SelectedValue", this.uxBindingSource, "TerritoryId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="StateProvinceEditControlBase"/> class.
		/// </summary>
		public StateProvinceEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_StateProvince != null) _StateProvince.Validate();
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
			this.uxStateProvinceId = new System.Windows.Forms.TextBox();
			uxStateProvinceIdLabel = new System.Windows.Forms.Label();
			this.uxStateProvinceCode = new System.Windows.Forms.TextBox();
			uxStateProvinceCodeLabel = new System.Windows.Forms.Label();
			this.uxCountryRegionCode = new System.Windows.Forms.ComboBox();
			uxCountryRegionCodeLabel = new System.Windows.Forms.Label();
			this.uxIsOnlyStateProvinceFlag = new System.Windows.Forms.CheckBox();
			uxIsOnlyStateProvinceFlagLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxTerritoryId = new System.Windows.Forms.ComboBox();
			uxTerritoryIdLabel = new System.Windows.Forms.Label();
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
			// uxStateProvinceIdLabel
			//
			this.uxStateProvinceIdLabel.Name = "uxStateProvinceIdLabel";
			this.uxStateProvinceIdLabel.Text = "State Province Id:";
			this.uxStateProvinceIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxStateProvinceIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStateProvinceIdLabel);			
			//
			// uxStateProvinceId
			//
			this.uxStateProvinceId.Name = "uxStateProvinceId";
            this.uxStateProvinceId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxStateProvinceId);
			this.uxStateProvinceId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxStateProvinceId);
			//
			// uxStateProvinceCodeLabel
			//
			this.uxStateProvinceCodeLabel.Name = "uxStateProvinceCodeLabel";
			this.uxStateProvinceCodeLabel.Text = "State Province Code:";
			this.uxStateProvinceCodeLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxStateProvinceCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStateProvinceCodeLabel);			
			//
			// uxStateProvinceCode
			//
			this.uxStateProvinceCode.Name = "uxStateProvinceCode";
			this.uxStateProvinceCode.Width = 250;
			this.uxStateProvinceCode.MaxLength = 3;
			//this.uxTableLayoutPanel.Controls.Add(this.uxStateProvinceCode);
			this.uxStateProvinceCode.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxStateProvinceCode);
			//
			// uxCountryRegionCodeLabel
			//
			this.uxCountryRegionCodeLabel.Name = "uxCountryRegionCodeLabel";
			this.uxCountryRegionCodeLabel.Text = "Country Region Code:";
			this.uxCountryRegionCodeLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxCountryRegionCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountryRegionCodeLabel);			
			//
			// uxCountryRegionCode
			//
			this.uxCountryRegionCode.Name = "uxCountryRegionCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountryRegionCode);
			this.uxCountryRegionCode.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxCountryRegionCode);
			//
			// uxIsOnlyStateProvinceFlagLabel
			//
			this.uxIsOnlyStateProvinceFlagLabel.Name = "uxIsOnlyStateProvinceFlagLabel";
			this.uxIsOnlyStateProvinceFlagLabel.Text = "Is Only State Province Flag:";
			this.uxIsOnlyStateProvinceFlagLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxIsOnlyStateProvinceFlagLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsOnlyStateProvinceFlagLabel);			
			//
			// uxIsOnlyStateProvinceFlag
			//
			this.uxIsOnlyStateProvinceFlag.Name = "uxIsOnlyStateProvinceFlag";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsOnlyStateProvinceFlag);
			this.uxIsOnlyStateProvinceFlag.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxIsOnlyStateProvinceFlag);
			//
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxName);
			//
			// uxTerritoryIdLabel
			//
			this.uxTerritoryIdLabel.Name = "uxTerritoryIdLabel";
			this.uxTerritoryIdLabel.Text = "Territory Id:";
			this.uxTerritoryIdLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxTerritoryIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTerritoryIdLabel);			
			//
			// uxTerritoryId
			//
			this.uxTerritoryId.Name = "uxTerritoryId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTerritoryId);
			this.uxTerritoryId.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxTerritoryId);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxRowguid);
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
			// uxCountryRegionCode
			//				
			this.uxCountryRegionCode.DisplayMember = "Name";	
			this.uxCountryRegionCode.ValueMember = "CountryRegionCode";	
			//
			// uxTerritoryId
			//				
			this.uxTerritoryId.DisplayMember = "Name";	
			this.uxTerritoryId.ValueMember = "TerritoryId";	
			// 
			// StateProvinceEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "StateProvinceEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.CountryRegion> _CountryRegionCodeList;
		
		/// <summary>
		/// The ComboBox associated with the CountryRegionCode property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.CountryRegion> CountryRegionCodeList
		{
			get {return _CountryRegionCodeList;}
			set 
			{
				this._CountryRegionCodeList = value;
				this.uxCountryRegionCode.DataSource = null;
				this.uxCountryRegionCode.DataSource = value;
			}
		}
		
		private bool _allowNewItemInCountryRegionCodeList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the CountryRegionCode property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCountryRegionCodeList
		{
			get { return _allowNewItemInCountryRegionCodeList;}
			set
			{
				this._allowNewItemInCountryRegionCodeList = value;
				this.uxCountryRegionCode.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        /// Indicates if the controls associated with the uxStateProvinceId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStateProvinceIdVisible
        {
            get { return this.uxStateProvinceId.Visible; }
            set
            {
                this.uxStateProvinceIdLabel.Visible = value;
                this.uxStateProvinceId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStateProvinceId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStateProvinceIdEnabled
        {
            get { return this.uxStateProvinceId.Enabled; }
            set
            {
                this.uxStateProvinceId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStateProvinceCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStateProvinceCodeVisible
        {
            get { return this.uxStateProvinceCode.Visible; }
            set
            {
                this.uxStateProvinceCodeLabel.Visible = value;
                this.uxStateProvinceCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStateProvinceCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStateProvinceCodeEnabled
        {
            get { return this.uxStateProvinceCode.Enabled; }
            set
            {
                this.uxStateProvinceCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCountryRegionCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCountryRegionCodeVisible
        {
            get { return this.uxCountryRegionCode.Visible; }
            set
            {
                this.uxCountryRegionCodeLabel.Visible = value;
                this.uxCountryRegionCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCountryRegionCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCountryRegionCodeEnabled
        {
            get { return this.uxCountryRegionCode.Enabled; }
            set
            {
                this.uxCountryRegionCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIsOnlyStateProvinceFlag property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIsOnlyStateProvinceFlagVisible
        {
            get { return this.uxIsOnlyStateProvinceFlag.Visible; }
            set
            {
                this.uxIsOnlyStateProvinceFlagLabel.Visible = value;
                this.uxIsOnlyStateProvinceFlag.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIsOnlyStateProvinceFlag property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIsOnlyStateProvinceFlagEnabled
        {
            get { return this.uxIsOnlyStateProvinceFlag.Enabled; }
            set
            {
                this.uxIsOnlyStateProvinceFlag.Enabled = value;
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
