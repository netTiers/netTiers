
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.StoreContact"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class StoreContactEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the ContactId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxContactId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ContactId property.
		/// </summary>
		protected System.Windows.Forms.Label uxContactIdLabel;
		
		/// <summary>
		/// ComboBox for the ContactTypeId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxContactTypeId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ContactTypeId property.
		/// </summary>
		protected System.Windows.Forms.Label uxContactTypeIdLabel;
		
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
		private Entities.StoreContact _StoreContact;
		/// <summary>
		/// Gets or sets the <see cref="Entities.StoreContact"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.StoreContact"/> instance.</value>
		public Entities.StoreContact StoreContact
		{
			get {return this._StoreContact;}
			set
			{
				this._StoreContact = value;
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
			this.uxContactId.DataBindings.Clear();
			this.uxContactId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ContactId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxContactTypeId.DataBindings.Clear();
			this.uxContactTypeId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ContactTypeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="StoreContactEditControlBase"/> class.
		/// </summary>
		public StoreContactEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_StoreContact != null) _StoreContact.Validate();
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
			this.uxContactId = new System.Windows.Forms.ComboBox();
			uxContactIdLabel = new System.Windows.Forms.Label();
			this.uxContactTypeId = new System.Windows.Forms.ComboBox();
			uxContactTypeIdLabel = new System.Windows.Forms.Label();
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
			// uxContactIdLabel
			//
			this.uxContactIdLabel.Name = "uxContactIdLabel";
			this.uxContactIdLabel.Text = "Contact Id:";
			this.uxContactIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxContactIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactIdLabel);			
			//
			// uxContactId
			//
			this.uxContactId.Name = "uxContactId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactId);
			this.uxContactId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxContactId);
			//
			// uxContactTypeIdLabel
			//
			this.uxContactTypeIdLabel.Name = "uxContactTypeIdLabel";
			this.uxContactTypeIdLabel.Text = "Contact Type Id:";
			this.uxContactTypeIdLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxContactTypeIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactTypeIdLabel);			
			//
			// uxContactTypeId
			//
			this.uxContactTypeId.Name = "uxContactTypeId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactTypeId);
			this.uxContactTypeId.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxContactTypeId);
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
			// uxContactId
			//				
			this.uxContactId.DisplayMember = "NameStyle";	
			this.uxContactId.ValueMember = "ContactId";	
			//
			// uxContactTypeId
			//				
			this.uxContactTypeId.DisplayMember = "Name";	
			this.uxContactTypeId.ValueMember = "ContactTypeId";	
			//
			// uxCustomerId
			//				
			this.uxCustomerId.DisplayMember = "Name";	
			this.uxCustomerId.ValueMember = "CustomerId";	
			// 
			// StoreContactEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "StoreContactEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Contact> _ContactIdList;
		
		/// <summary>
		/// The ComboBox associated with the ContactId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Contact> ContactIdList
		{
			get {return _ContactIdList;}
			set 
			{
				this._ContactIdList = value;
				this.uxContactId.DataSource = null;
				this.uxContactId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInContactIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ContactId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactIdList
		{
			get { return _allowNewItemInContactIdList;}
			set
			{
				this._allowNewItemInContactIdList = value;
				this.uxContactId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.ContactType> _ContactTypeIdList;
		
		/// <summary>
		/// The ComboBox associated with the ContactTypeId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.ContactType> ContactTypeIdList
		{
			get {return _ContactTypeIdList;}
			set 
			{
				this._ContactTypeIdList = value;
				this.uxContactTypeId.DataSource = null;
				this.uxContactTypeId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInContactTypeIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ContactTypeId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactTypeIdList
		{
			get { return _allowNewItemInContactTypeIdList;}
			set
			{
				this._allowNewItemInContactTypeIdList = value;
				this.uxContactTypeId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Store> _CustomerIdList;
		
		/// <summary>
		/// The ComboBox associated with the CustomerId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Store> CustomerIdList
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
        /// Indicates if the controls associated with the uxContactId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxContactIdVisible
        {
            get { return this.uxContactId.Visible; }
            set
            {
                this.uxContactIdLabel.Visible = value;
                this.uxContactId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxContactId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxContactIdEnabled
        {
            get { return this.uxContactId.Enabled; }
            set
            {
                this.uxContactId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxContactTypeId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxContactTypeIdVisible
        {
            get { return this.uxContactTypeId.Visible; }
            set
            {
                this.uxContactTypeIdLabel.Visible = value;
                this.uxContactTypeId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxContactTypeId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxContactTypeIdEnabled
        {
            get { return this.uxContactTypeId.Enabled; }
            set
            {
                this.uxContactTypeId.Enabled = value;
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
