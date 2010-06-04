
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Store"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class StoreEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the CustomerId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxCustomerId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CustomerId property.
		/// </summary>
		protected System.Windows.Forms.Label uxCustomerIdLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// ComboBox for the SalesPersonId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxSalesPersonId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesPersonId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesPersonIdLabel;
		
		/// <summary>
		/// TextBox for the Demographics property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDemographics;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Demographics property.
		/// </summary>
		protected System.Windows.Forms.Label uxDemographicsLabel;
		
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
		private Entities.Store _Store;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Store"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Store"/> instance.</value>
		public Entities.Store Store
		{
			get {return this._Store;}
			set
			{
				this._Store = value;
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
			this.uxCustomerId.DataBindings.Clear();
			this.uxCustomerId.DataBindings.Add("SelectedValue", this.uxBindingSource, "CustomerId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesPersonId.DataBindings.Clear();
			this.uxSalesPersonId.DataBindings.Add("SelectedValue", this.uxBindingSource, "SalesPersonId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDemographics.DataBindings.Clear();
			this.uxDemographics.DataBindings.Add("Text", this.uxBindingSource, "Demographics", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="StoreEditControlBase"/> class.
		/// </summary>
		public StoreEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Store != null) _Store.Validate();
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
			this.uxCustomerId = new System.Windows.Forms.ComboBox();
			uxCustomerIdLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxSalesPersonId = new System.Windows.Forms.ComboBox();
			uxSalesPersonIdLabel = new System.Windows.Forms.Label();
			this.uxDemographics = new System.Windows.Forms.TextBox();
			uxDemographicsLabel = new System.Windows.Forms.Label();
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
			// uxCustomerIdLabel
			//
			this.uxCustomerIdLabel.Name = "uxCustomerIdLabel";
			this.uxCustomerIdLabel.Text = "Customer Id:";
			this.uxCustomerIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxCustomerIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCustomerIdLabel);			
			//
			// uxCustomerId
			//
			this.uxCustomerId.Name = "uxCustomerId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCustomerId);
			this.uxCustomerId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxCustomerId);
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
			// uxSalesPersonIdLabel
			//
			this.uxSalesPersonIdLabel.Name = "uxSalesPersonIdLabel";
			this.uxSalesPersonIdLabel.Text = "Sales Person Id:";
			this.uxSalesPersonIdLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxSalesPersonIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesPersonIdLabel);			
			//
			// uxSalesPersonId
			//
			this.uxSalesPersonId.Name = "uxSalesPersonId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesPersonId);
			this.uxSalesPersonId.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxSalesPersonId);
			//
			// uxDemographicsLabel
			//
			this.uxDemographicsLabel.Name = "uxDemographicsLabel";
			this.uxDemographicsLabel.Text = "Demographics:";
			this.uxDemographicsLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxDemographicsLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDemographicsLabel);			
			//
			// uxDemographics
			//
			this.uxDemographics.Name = "uxDemographics";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDemographics);
			this.uxDemographics.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxDemographics);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxCustomerId
			//				
			this.uxCustomerId.DisplayMember = "TerritoryId";	
			this.uxCustomerId.ValueMember = "CustomerId";	
			//
			// uxSalesPersonId
			//				
			this.uxSalesPersonId.DisplayMember = "TerritoryId";	
			this.uxSalesPersonId.ValueMember = "SalesPersonId";	
			// 
			// StoreEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "StoreEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Customer> _CustomerIdList;
		
		/// <summary>
		/// The ComboBox associated with the CustomerId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Customer> CustomerIdList
		{
			get {return _CustomerIdList;}
			set 
			{
				this._CustomerIdList = value;
				this.uxCustomerId.DataSource = null;
				this.uxCustomerId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInCustomerIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the CustomerId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCustomerIdList
		{
			get { return _allowNewItemInCustomerIdList;}
			set
			{
				this._allowNewItemInCustomerIdList = value;
				this.uxCustomerId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.SalesPerson> _SalesPersonIdList;
		
		/// <summary>
		/// The ComboBox associated with the SalesPersonId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.SalesPerson> SalesPersonIdList
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
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxCustomerId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCustomerIdVisible
        {
            get { return this.uxCustomerId.Visible; }
            set
            {
                this.uxCustomerIdLabel.Visible = value;
                this.uxCustomerId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCustomerId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCustomerIdEnabled
        {
            get { return this.uxCustomerId.Enabled; }
            set
            {
                this.uxCustomerId.Enabled = value;
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
        /// Indicates if the controls associated with the uxDemographics property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDemographicsVisible
        {
            get { return this.uxDemographics.Visible; }
            set
            {
                this.uxDemographicsLabel.Visible = value;
                this.uxDemographics.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDemographics property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDemographicsEnabled
        {
            get { return this.uxDemographics.Enabled; }
            set
            {
                this.uxDemographics.Enabled = value;
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
