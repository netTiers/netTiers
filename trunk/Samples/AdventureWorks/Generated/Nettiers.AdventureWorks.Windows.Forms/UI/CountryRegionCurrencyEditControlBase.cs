
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.CountryRegionCurrency"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CountryRegionCurrencyEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the CountryRegionCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxCountryRegionCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CountryRegionCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxCountryRegionCodeLabel;
		
		/// <summary>
		/// ComboBox for the CurrencyCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxCurrencyCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CurrencyCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxCurrencyCodeLabel;
		
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
		private Entities.CountryRegionCurrency _CountryRegionCurrency;
		/// <summary>
		/// Gets or sets the <see cref="Entities.CountryRegionCurrency"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.CountryRegionCurrency"/> instance.</value>
		public Entities.CountryRegionCurrency CountryRegionCurrency
		{
			get {return this._CountryRegionCurrency;}
			set
			{
				this._CountryRegionCurrency = value;
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
			this.uxCountryRegionCode.DataBindings.Clear();
			this.uxCountryRegionCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "CountryRegionCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCurrencyCode.DataBindings.Clear();
			this.uxCurrencyCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "CurrencyCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CountryRegionCurrencyEditControlBase"/> class.
		/// </summary>
		public CountryRegionCurrencyEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_CountryRegionCurrency != null) _CountryRegionCurrency.Validate();
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
			this.uxCountryRegionCode = new System.Windows.Forms.ComboBox();
			uxCountryRegionCodeLabel = new System.Windows.Forms.Label();
			this.uxCurrencyCode = new System.Windows.Forms.ComboBox();
			uxCurrencyCodeLabel = new System.Windows.Forms.Label();
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
			// uxCountryRegionCodeLabel
			//
			this.uxCountryRegionCodeLabel.Name = "uxCountryRegionCodeLabel";
			this.uxCountryRegionCodeLabel.Text = "Country Region Code:";
			this.uxCountryRegionCodeLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxCountryRegionCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountryRegionCodeLabel);			
			//
			// uxCountryRegionCode
			//
			this.uxCountryRegionCode.Name = "uxCountryRegionCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountryRegionCode);
			this.uxCountryRegionCode.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxCountryRegionCode);
			//
			// uxCurrencyCodeLabel
			//
			this.uxCurrencyCodeLabel.Name = "uxCurrencyCodeLabel";
			this.uxCurrencyCodeLabel.Text = "Currency Code:";
			this.uxCurrencyCodeLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxCurrencyCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrencyCodeLabel);			
			//
			// uxCurrencyCode
			//
			this.uxCurrencyCode.Name = "uxCurrencyCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrencyCode);
			this.uxCurrencyCode.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxCurrencyCode);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxCountryRegionCode
			//				
			this.uxCountryRegionCode.DisplayMember = "Name";	
			this.uxCountryRegionCode.ValueMember = "CountryRegionCode";	
			//
			// uxCurrencyCode
			//				
			this.uxCurrencyCode.DisplayMember = "Name";	
			this.uxCurrencyCode.ValueMember = "CurrencyCode";	
			// 
			// CountryRegionCurrencyEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "CountryRegionCurrencyEditControlBase";
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
		
				
		private Entities.TList<Entities.Currency> _CurrencyCodeList;
		
		/// <summary>
		/// The ComboBox associated with the CurrencyCode property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Currency> CurrencyCodeList
		{
			get {return _CurrencyCodeList;}
			set 
			{
				this._CurrencyCodeList = value;
				this.uxCurrencyCode.DataSource = null;
				this.uxCurrencyCode.DataSource = value;
			}
		}
		
		private bool _allowNewItemInCurrencyCodeList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the CurrencyCode property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCurrencyCodeList
		{
			get { return _allowNewItemInCurrencyCodeList;}
			set
			{
				this._allowNewItemInCurrencyCodeList = value;
				this.uxCurrencyCode.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

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
        /// Indicates if the controls associated with the uxCurrencyCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCurrencyCodeVisible
        {
            get { return this.uxCurrencyCode.Visible; }
            set
            {
                this.uxCurrencyCodeLabel.Visible = value;
                this.uxCurrencyCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCurrencyCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCurrencyCodeEnabled
        {
            get { return this.uxCurrencyCode.Enabled; }
            set
            {
                this.uxCurrencyCode.Enabled = value;
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
