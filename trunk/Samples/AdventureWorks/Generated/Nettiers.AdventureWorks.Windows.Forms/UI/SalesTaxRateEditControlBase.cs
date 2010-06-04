
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.SalesTaxRate"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesTaxRateEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the SalesTaxRateId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSalesTaxRateId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesTaxRateId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesTaxRateIdLabel;
		
		/// <summary>
		/// ComboBox for the StateProvinceId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxStateProvinceId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StateProvinceId property.
		/// </summary>
		protected System.Windows.Forms.Label uxStateProvinceIdLabel;
		
		/// <summary>
		/// TextBox for the TaxType property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTaxType;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TaxType property.
		/// </summary>
		protected System.Windows.Forms.Label uxTaxTypeLabel;
		
		/// <summary>
		/// TextBox for the TaxRate property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTaxRate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TaxRate property.
		/// </summary>
		protected System.Windows.Forms.Label uxTaxRateLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
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
		private Entities.SalesTaxRate _SalesTaxRate;
		/// <summary>
		/// Gets or sets the <see cref="Entities.SalesTaxRate"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.SalesTaxRate"/> instance.</value>
		public Entities.SalesTaxRate SalesTaxRate
		{
			get {return this._SalesTaxRate;}
			set
			{
				this._SalesTaxRate = value;
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
			this.uxSalesTaxRateId.DataBindings.Clear();
			this.uxSalesTaxRateId.DataBindings.Add("Text", this.uxBindingSource, "SalesTaxRateId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStateProvinceId.DataBindings.Clear();
			this.uxStateProvinceId.DataBindings.Add("SelectedValue", this.uxBindingSource, "StateProvinceId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTaxType.DataBindings.Clear();
			this.uxTaxType.DataBindings.Add("Text", this.uxBindingSource, "TaxType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTaxRate.DataBindings.Clear();
			this.uxTaxRate.DataBindings.Add("Text", this.uxBindingSource, "TaxRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SalesTaxRateEditControlBase"/> class.
		/// </summary>
		public SalesTaxRateEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_SalesTaxRate != null) _SalesTaxRate.Validate();
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
			this.uxSalesTaxRateId = new System.Windows.Forms.TextBox();
			uxSalesTaxRateIdLabel = new System.Windows.Forms.Label();
			this.uxStateProvinceId = new System.Windows.Forms.ComboBox();
			uxStateProvinceIdLabel = new System.Windows.Forms.Label();
			this.uxTaxType = new System.Windows.Forms.TextBox();
			uxTaxTypeLabel = new System.Windows.Forms.Label();
			this.uxTaxRate = new System.Windows.Forms.TextBox();
			uxTaxRateLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
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
			// uxSalesTaxRateIdLabel
			//
			this.uxSalesTaxRateIdLabel.Name = "uxSalesTaxRateIdLabel";
			this.uxSalesTaxRateIdLabel.Text = "Sales Tax Rate Id:";
			this.uxSalesTaxRateIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxSalesTaxRateIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesTaxRateIdLabel);			
			//
			// uxSalesTaxRateId
			//
			this.uxSalesTaxRateId.Name = "uxSalesTaxRateId";
            this.uxSalesTaxRateId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesTaxRateId);
			this.uxSalesTaxRateId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxSalesTaxRateId);
			//
			// uxStateProvinceIdLabel
			//
			this.uxStateProvinceIdLabel.Name = "uxStateProvinceIdLabel";
			this.uxStateProvinceIdLabel.Text = "State Province Id:";
			this.uxStateProvinceIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxStateProvinceIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStateProvinceIdLabel);			
			//
			// uxStateProvinceId
			//
			this.uxStateProvinceId.Name = "uxStateProvinceId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStateProvinceId);
			this.uxStateProvinceId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxStateProvinceId);
			//
			// uxTaxTypeLabel
			//
			this.uxTaxTypeLabel.Name = "uxTaxTypeLabel";
			this.uxTaxTypeLabel.Text = "Tax Type:";
			this.uxTaxTypeLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxTaxTypeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTaxTypeLabel);			
			//
			// uxTaxType
			//
			this.uxTaxType.Name = "uxTaxType";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTaxType);
			this.uxTaxType.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxTaxType);
			//
			// uxTaxRateLabel
			//
			this.uxTaxRateLabel.Name = "uxTaxRateLabel";
			this.uxTaxRateLabel.Text = "Tax Rate:";
			this.uxTaxRateLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxTaxRateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTaxRateLabel);			
			//
			// uxTaxRate
			//
			this.uxTaxRate.Name = "uxTaxRate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTaxRate);
			this.uxTaxRate.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxTaxRate);
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
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxStateProvinceId
			//				
			this.uxStateProvinceId.DisplayMember = "StateProvinceCode";	
			this.uxStateProvinceId.ValueMember = "StateProvinceId";	
			// 
			// SalesTaxRateEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "SalesTaxRateEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.StateProvince> _StateProvinceIdList;
		
		/// <summary>
		/// The ComboBox associated with the StateProvinceId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.StateProvince> StateProvinceIdList
		{
			get {return _StateProvinceIdList;}
			set 
			{
				this._StateProvinceIdList = value;
				this.uxStateProvinceId.DataSource = null;
				this.uxStateProvinceId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInStateProvinceIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the StateProvinceId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInStateProvinceIdList
		{
			get { return _allowNewItemInStateProvinceIdList;}
			set
			{
				this._allowNewItemInStateProvinceIdList = value;
				this.uxStateProvinceId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxSalesTaxRateId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesTaxRateIdVisible
        {
            get { return this.uxSalesTaxRateId.Visible; }
            set
            {
                this.uxSalesTaxRateIdLabel.Visible = value;
                this.uxSalesTaxRateId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesTaxRateId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesTaxRateIdEnabled
        {
            get { return this.uxSalesTaxRateId.Enabled; }
            set
            {
                this.uxSalesTaxRateId.Enabled = value;
            }
        }
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
        /// Indicates if the controls associated with the uxTaxType property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTaxTypeVisible
        {
            get { return this.uxTaxType.Visible; }
            set
            {
                this.uxTaxTypeLabel.Visible = value;
                this.uxTaxType.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTaxType property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTaxTypeEnabled
        {
            get { return this.uxTaxType.Enabled; }
            set
            {
                this.uxTaxType.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTaxRate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTaxRateVisible
        {
            get { return this.uxTaxRate.Visible; }
            set
            {
                this.uxTaxRateLabel.Visible = value;
                this.uxTaxRate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTaxRate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTaxRateEnabled
        {
            get { return this.uxTaxRate.Enabled; }
            set
            {
                this.uxTaxRate.Enabled = value;
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
