
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Customer"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CustomerEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the CustomerId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCustomerId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CustomerId property.
		/// </summary>
		protected System.Windows.Forms.Label uxCustomerIdLabel;
		
		/// <summary>
		/// ComboBox for the TerritoryId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxTerritoryId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TerritoryId property.
		/// </summary>
		protected System.Windows.Forms.Label uxTerritoryIdLabel;
		
		/// <summary>
		/// TextBox for the AccountNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAccountNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AccountNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxAccountNumberLabel;
		
		/// <summary>
		/// TextBox for the CustomerType property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCustomerType;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CustomerType property.
		/// </summary>
		protected System.Windows.Forms.Label uxCustomerTypeLabel;
		
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
		private Entities.Customer _Customer;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Customer"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Customer"/> instance.</value>
		public Entities.Customer Customer
		{
			get {return this._Customer;}
			set
			{
				this._Customer = value;
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
			this.uxCustomerId.DataBindings.Add("Text", this.uxBindingSource, "CustomerId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTerritoryId.DataBindings.Clear();
			this.uxTerritoryId.DataBindings.Add("SelectedValue", this.uxBindingSource, "TerritoryId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAccountNumber.DataBindings.Clear();
			this.uxAccountNumber.DataBindings.Add("Text", this.uxBindingSource, "AccountNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCustomerType.DataBindings.Clear();
			this.uxCustomerType.DataBindings.Add("Text", this.uxBindingSource, "CustomerType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomerEditControlBase"/> class.
		/// </summary>
		public CustomerEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Customer != null) _Customer.Validate();
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
			this.uxCustomerId = new System.Windows.Forms.TextBox();
			uxCustomerIdLabel = new System.Windows.Forms.Label();
			this.uxTerritoryId = new System.Windows.Forms.ComboBox();
			uxTerritoryIdLabel = new System.Windows.Forms.Label();
			this.uxAccountNumber = new System.Windows.Forms.TextBox();
			uxAccountNumberLabel = new System.Windows.Forms.Label();
			this.uxCustomerType = new System.Windows.Forms.TextBox();
			uxCustomerTypeLabel = new System.Windows.Forms.Label();
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
            this.uxCustomerId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCustomerId);
			this.uxCustomerId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxCustomerId);
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
			// uxAccountNumberLabel
			//
			this.uxAccountNumberLabel.Name = "uxAccountNumberLabel";
			this.uxAccountNumberLabel.Text = "Account Number:";
			this.uxAccountNumberLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxAccountNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAccountNumberLabel);			
			//
			// uxAccountNumber
			//
			this.uxAccountNumber.Name = "uxAccountNumber";
			this.uxAccountNumber.Width = 250;
			this.uxAccountNumber.MaxLength = 10;
            this.uxAccountNumber.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAccountNumber);
			this.uxAccountNumber.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxAccountNumber);
			//
			// uxCustomerTypeLabel
			//
			this.uxCustomerTypeLabel.Name = "uxCustomerTypeLabel";
			this.uxCustomerTypeLabel.Text = "Customer Type:";
			this.uxCustomerTypeLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxCustomerTypeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCustomerTypeLabel);			
			//
			// uxCustomerType
			//
			this.uxCustomerType.Name = "uxCustomerType";
			this.uxCustomerType.Width = 250;
			this.uxCustomerType.MaxLength = 1;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCustomerType);
			this.uxCustomerType.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxCustomerType);
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
			// uxTerritoryId
			//				
			this.uxTerritoryId.DisplayMember = "Name";	
			this.uxTerritoryId.ValueMember = "TerritoryId";	
			// 
			// CustomerEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "CustomerEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
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
        /// Indicates if the controls associated with the uxCustomerType property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCustomerTypeVisible
        {
            get { return this.uxCustomerType.Visible; }
            set
            {
                this.uxCustomerTypeLabel.Visible = value;
                this.uxCustomerType.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCustomerType property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCustomerTypeEnabled
        {
            get { return this.uxCustomerType.Enabled; }
            set
            {
                this.uxCustomerType.Enabled = value;
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
