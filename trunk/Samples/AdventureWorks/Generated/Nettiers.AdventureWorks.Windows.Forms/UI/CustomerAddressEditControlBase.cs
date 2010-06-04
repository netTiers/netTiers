
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.CustomerAddress"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CustomerAddressEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the AddressId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxAddressId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressId property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressIdLabel;
		
		/// <summary>
		/// ComboBox for the AddressTypeId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxAddressTypeId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressTypeId property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressTypeIdLabel;
		
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
		private Entities.CustomerAddress _CustomerAddress;
		/// <summary>
		/// Gets or sets the <see cref="Entities.CustomerAddress"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.CustomerAddress"/> instance.</value>
		public Entities.CustomerAddress CustomerAddress
		{
			get {return this._CustomerAddress;}
			set
			{
				this._CustomerAddress = value;
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
			this.uxAddressId.DataBindings.Clear();
			this.uxAddressId.DataBindings.Add("SelectedValue", this.uxBindingSource, "AddressId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddressTypeId.DataBindings.Clear();
			this.uxAddressTypeId.DataBindings.Add("SelectedValue", this.uxBindingSource, "AddressTypeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomerAddressEditControlBase"/> class.
		/// </summary>
		public CustomerAddressEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_CustomerAddress != null) _CustomerAddress.Validate();
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
			this.uxAddressId = new System.Windows.Forms.ComboBox();
			uxAddressIdLabel = new System.Windows.Forms.Label();
			this.uxAddressTypeId = new System.Windows.Forms.ComboBox();
			uxAddressTypeIdLabel = new System.Windows.Forms.Label();
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
			// uxAddressIdLabel
			//
			this.uxAddressIdLabel.Name = "uxAddressIdLabel";
			this.uxAddressIdLabel.Text = "Address Id:";
			this.uxAddressIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxAddressIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressIdLabel);			
			//
			// uxAddressId
			//
			this.uxAddressId.Name = "uxAddressId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressId);
			this.uxAddressId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxAddressId);
			//
			// uxAddressTypeIdLabel
			//
			this.uxAddressTypeIdLabel.Name = "uxAddressTypeIdLabel";
			this.uxAddressTypeIdLabel.Text = "Address Type Id:";
			this.uxAddressTypeIdLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxAddressTypeIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressTypeIdLabel);			
			//
			// uxAddressTypeId
			//
			this.uxAddressTypeId.Name = "uxAddressTypeId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressTypeId);
			this.uxAddressTypeId.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxAddressTypeId);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxAddressId
			//				
			this.uxAddressId.DisplayMember = "AddressLine1";	
			this.uxAddressId.ValueMember = "AddressId";	
			//
			// uxAddressTypeId
			//				
			this.uxAddressTypeId.DisplayMember = "Name";	
			this.uxAddressTypeId.ValueMember = "AddressTypeId";	
			//
			// uxCustomerId
			//				
			this.uxCustomerId.DisplayMember = "TerritoryId";	
			this.uxCustomerId.ValueMember = "CustomerId";	
			// 
			// CustomerAddressEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "CustomerAddressEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Address> _AddressIdList;
		
		/// <summary>
		/// The ComboBox associated with the AddressId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Address> AddressIdList
		{
			get {return _AddressIdList;}
			set 
			{
				this._AddressIdList = value;
				this.uxAddressId.DataSource = null;
				this.uxAddressId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInAddressIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the AddressId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInAddressIdList
		{
			get { return _allowNewItemInAddressIdList;}
			set
			{
				this._allowNewItemInAddressIdList = value;
				this.uxAddressId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.AddressType> _AddressTypeIdList;
		
		/// <summary>
		/// The ComboBox associated with the AddressTypeId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.AddressType> AddressTypeIdList
		{
			get {return _AddressTypeIdList;}
			set 
			{
				this._AddressTypeIdList = value;
				this.uxAddressTypeId.DataSource = null;
				this.uxAddressTypeId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInAddressTypeIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the AddressTypeId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInAddressTypeIdList
		{
			get { return _allowNewItemInAddressTypeIdList;}
			set
			{
				this._allowNewItemInAddressTypeIdList = value;
				this.uxAddressTypeId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
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
        /// Indicates if the controls associated with the uxAddressId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressIdVisible
        {
            get { return this.uxAddressId.Visible; }
            set
            {
                this.uxAddressIdLabel.Visible = value;
                this.uxAddressId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddressId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressIdEnabled
        {
            get { return this.uxAddressId.Enabled; }
            set
            {
                this.uxAddressId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddressTypeId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressTypeIdVisible
        {
            get { return this.uxAddressTypeId.Visible; }
            set
            {
                this.uxAddressTypeIdLabel.Visible = value;
                this.uxAddressTypeId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddressTypeId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressTypeIdEnabled
        {
            get { return this.uxAddressTypeId.Enabled; }
            set
            {
                this.uxAddressTypeId.Enabled = value;
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
