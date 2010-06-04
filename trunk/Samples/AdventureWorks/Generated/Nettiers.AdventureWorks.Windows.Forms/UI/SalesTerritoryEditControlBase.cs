
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.SalesTerritory"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesTerritoryEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the TerritoryId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTerritoryId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TerritoryId property.
		/// </summary>
		protected System.Windows.Forms.Label uxTerritoryIdLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// TextBox for the CountryRegionCode property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCountryRegionCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CountryRegionCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxCountryRegionCodeLabel;
		
		/// <summary>
		/// TextBox for the Group property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxGroup;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Group property.
		/// </summary>
		protected System.Windows.Forms.Label uxGroupLabel;
		
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
		/// TextBox for the CostYtd property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCostYtd;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CostYtd property.
		/// </summary>
		protected System.Windows.Forms.Label uxCostYtdLabel;
		
		/// <summary>
		/// TextBox for the CostLastYear property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCostLastYear;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CostLastYear property.
		/// </summary>
		protected System.Windows.Forms.Label uxCostLastYearLabel;
		
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
		private Entities.SalesTerritory _SalesTerritory;
		/// <summary>
		/// Gets or sets the <see cref="Entities.SalesTerritory"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.SalesTerritory"/> instance.</value>
		public Entities.SalesTerritory SalesTerritory
		{
			get {return this._SalesTerritory;}
			set
			{
				this._SalesTerritory = value;
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
			this.uxTerritoryId.DataBindings.Clear();
			this.uxTerritoryId.DataBindings.Add("Text", this.uxBindingSource, "TerritoryId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCountryRegionCode.DataBindings.Clear();
			this.uxCountryRegionCode.DataBindings.Add("Text", this.uxBindingSource, "CountryRegionCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxGroup.DataBindings.Clear();
			this.uxGroup.DataBindings.Add("Text", this.uxBindingSource, "Group", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesYtd.DataBindings.Clear();
			this.uxSalesYtd.DataBindings.Add("Text", this.uxBindingSource, "SalesYtd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesLastYear.DataBindings.Clear();
			this.uxSalesLastYear.DataBindings.Add("Text", this.uxBindingSource, "SalesLastYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCostYtd.DataBindings.Clear();
			this.uxCostYtd.DataBindings.Add("Text", this.uxBindingSource, "CostYtd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCostLastYear.DataBindings.Clear();
			this.uxCostLastYear.DataBindings.Add("Text", this.uxBindingSource, "CostLastYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SalesTerritoryEditControlBase"/> class.
		/// </summary>
		public SalesTerritoryEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_SalesTerritory != null) _SalesTerritory.Validate();
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
			this.uxTerritoryId = new System.Windows.Forms.TextBox();
			uxTerritoryIdLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxCountryRegionCode = new System.Windows.Forms.TextBox();
			uxCountryRegionCodeLabel = new System.Windows.Forms.Label();
			this.uxGroup = new System.Windows.Forms.TextBox();
			uxGroupLabel = new System.Windows.Forms.Label();
			this.uxSalesYtd = new System.Windows.Forms.TextBox();
			uxSalesYtdLabel = new System.Windows.Forms.Label();
			this.uxSalesLastYear = new System.Windows.Forms.TextBox();
			uxSalesLastYearLabel = new System.Windows.Forms.Label();
			this.uxCostYtd = new System.Windows.Forms.TextBox();
			uxCostYtdLabel = new System.Windows.Forms.Label();
			this.uxCostLastYear = new System.Windows.Forms.TextBox();
			uxCostLastYearLabel = new System.Windows.Forms.Label();
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
			// uxTerritoryIdLabel
			//
			this.uxTerritoryIdLabel.Name = "uxTerritoryIdLabel";
			this.uxTerritoryIdLabel.Text = "Territory Id:";
			this.uxTerritoryIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxTerritoryIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTerritoryIdLabel);			
			//
			// uxTerritoryId
			//
			this.uxTerritoryId.Name = "uxTerritoryId";
            this.uxTerritoryId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTerritoryId);
			this.uxTerritoryId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxTerritoryId);
			//
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxName);
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
			this.uxCountryRegionCode.Width = 250;
			this.uxCountryRegionCode.MaxLength = 3;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountryRegionCode);
			this.uxCountryRegionCode.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxCountryRegionCode);
			//
			// uxGroupLabel
			//
			this.uxGroupLabel.Name = "uxGroupLabel";
			this.uxGroupLabel.Text = "Group:";
			this.uxGroupLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxGroupLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxGroupLabel);			
			//
			// uxGroup
			//
			this.uxGroup.Name = "uxGroup";
			this.uxGroup.Width = 250;
			this.uxGroup.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxGroup);
			this.uxGroup.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxGroup);
			//
			// uxSalesYtdLabel
			//
			this.uxSalesYtdLabel.Name = "uxSalesYtdLabel";
			this.uxSalesYtdLabel.Text = "Sales Ytd:";
			this.uxSalesYtdLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxSalesYtdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesYtdLabel);			
			//
			// uxSalesYtd
			//
			this.uxSalesYtd.Name = "uxSalesYtd";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesYtd);
			this.uxSalesYtd.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxSalesYtd);
			//
			// uxSalesLastYearLabel
			//
			this.uxSalesLastYearLabel.Name = "uxSalesLastYearLabel";
			this.uxSalesLastYearLabel.Text = "Sales Last Year:";
			this.uxSalesLastYearLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxSalesLastYearLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesLastYearLabel);			
			//
			// uxSalesLastYear
			//
			this.uxSalesLastYear.Name = "uxSalesLastYear";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesLastYear);
			this.uxSalesLastYear.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxSalesLastYear);
			//
			// uxCostYtdLabel
			//
			this.uxCostYtdLabel.Name = "uxCostYtdLabel";
			this.uxCostYtdLabel.Text = "Cost Ytd:";
			this.uxCostYtdLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxCostYtdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCostYtdLabel);			
			//
			// uxCostYtd
			//
			this.uxCostYtd.Name = "uxCostYtd";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCostYtd);
			this.uxCostYtd.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxCostYtd);
			//
			// uxCostLastYearLabel
			//
			this.uxCostLastYearLabel.Name = "uxCostLastYearLabel";
			this.uxCostLastYearLabel.Text = "Cost Last Year:";
			this.uxCostLastYearLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxCostLastYearLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCostLastYearLabel);			
			//
			// uxCostLastYear
			//
			this.uxCostLastYear.Name = "uxCostLastYear";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCostLastYear);
			this.uxCostLastYear.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxCostLastYear);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxRowguid);
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
			// SalesTerritoryEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "SalesTerritoryEditControlBase";
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
        /// Indicates if the controls associated with the uxGroup property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxGroupVisible
        {
            get { return this.uxGroup.Visible; }
            set
            {
                this.uxGroupLabel.Visible = value;
                this.uxGroup.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxGroup property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxGroupEnabled
        {
            get { return this.uxGroup.Enabled; }
            set
            {
                this.uxGroup.Enabled = value;
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
        /// Indicates if the controls associated with the uxCostYtd property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCostYtdVisible
        {
            get { return this.uxCostYtd.Visible; }
            set
            {
                this.uxCostYtdLabel.Visible = value;
                this.uxCostYtd.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCostYtd property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCostYtdEnabled
        {
            get { return this.uxCostYtd.Enabled; }
            set
            {
                this.uxCostYtd.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCostLastYear property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCostLastYearVisible
        {
            get { return this.uxCostLastYear.Visible; }
            set
            {
                this.uxCostLastYearLabel.Visible = value;
                this.uxCostLastYear.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCostLastYear property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCostLastYearEnabled
        {
            get { return this.uxCostLastYear.Enabled; }
            set
            {
                this.uxCostLastYear.Enabled = value;
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
