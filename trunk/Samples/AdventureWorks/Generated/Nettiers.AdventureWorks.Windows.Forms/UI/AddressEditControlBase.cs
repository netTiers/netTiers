
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Address"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class AddressEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the AddressId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddressId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressId property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressIdLabel;
		
		/// <summary>
		/// TextBox for the AddressLine1 property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddressLine1;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressLine1 property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressLine1Label;
		
		/// <summary>
		/// TextBox for the AddressLine2 property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddressLine2;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressLine2 property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressLine2Label;
		
		/// <summary>
		/// TextBox for the City property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCity;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the City property.
		/// </summary>
		protected System.Windows.Forms.Label uxCityLabel;
		
		/// <summary>
		/// ComboBox for the StateProvinceId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxStateProvinceId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StateProvinceId property.
		/// </summary>
		protected System.Windows.Forms.Label uxStateProvinceIdLabel;
		
		/// <summary>
		/// TextBox for the PostalCode property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPostalCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PostalCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxPostalCodeLabel;
		
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
		private Entities.Address _Address;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Address"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Address"/> instance.</value>
		public Entities.Address Address
		{
			get {return this._Address;}
			set
			{
				this._Address = value;
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
			this.uxAddressId.DataBindings.Clear();
			this.uxAddressId.DataBindings.Add("Text", this.uxBindingSource, "AddressId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddressLine1.DataBindings.Clear();
			this.uxAddressLine1.DataBindings.Add("Text", this.uxBindingSource, "AddressLine1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddressLine2.DataBindings.Clear();
			this.uxAddressLine2.DataBindings.Add("Text", this.uxBindingSource, "AddressLine2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCity.DataBindings.Clear();
			this.uxCity.DataBindings.Add("Text", this.uxBindingSource, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStateProvinceId.DataBindings.Clear();
			this.uxStateProvinceId.DataBindings.Add("SelectedValue", this.uxBindingSource, "StateProvinceId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPostalCode.DataBindings.Clear();
			this.uxPostalCode.DataBindings.Add("Text", this.uxBindingSource, "PostalCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="AddressEditControlBase"/> class.
		/// </summary>
		public AddressEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Address != null) _Address.Validate();
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
			this.uxAddressId = new System.Windows.Forms.TextBox();
			uxAddressIdLabel = new System.Windows.Forms.Label();
			this.uxAddressLine1 = new System.Windows.Forms.TextBox();
			uxAddressLine1Label = new System.Windows.Forms.Label();
			this.uxAddressLine2 = new System.Windows.Forms.TextBox();
			uxAddressLine2Label = new System.Windows.Forms.Label();
			this.uxCity = new System.Windows.Forms.TextBox();
			uxCityLabel = new System.Windows.Forms.Label();
			this.uxStateProvinceId = new System.Windows.Forms.ComboBox();
			uxStateProvinceIdLabel = new System.Windows.Forms.Label();
			this.uxPostalCode = new System.Windows.Forms.TextBox();
			uxPostalCodeLabel = new System.Windows.Forms.Label();
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
			// uxAddressIdLabel
			//
			this.uxAddressIdLabel.Name = "uxAddressIdLabel";
			this.uxAddressIdLabel.Text = "Address Id:";
			this.uxAddressIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxAddressIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressIdLabel);			
			//
			// uxAddressId
			//
			this.uxAddressId.Name = "uxAddressId";
            this.uxAddressId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressId);
			this.uxAddressId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxAddressId);
			//
			// uxAddressLine1Label
			//
			this.uxAddressLine1Label.Name = "uxAddressLine1Label";
			this.uxAddressLine1Label.Text = "Address Line1:";
			this.uxAddressLine1Label.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxAddressLine1Label);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine1Label);			
			//
			// uxAddressLine1
			//
			this.uxAddressLine1.Name = "uxAddressLine1";
			this.uxAddressLine1.Width = 250;
			this.uxAddressLine1.MaxLength = 60;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine1);
			this.uxAddressLine1.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxAddressLine1);
			//
			// uxAddressLine2Label
			//
			this.uxAddressLine2Label.Name = "uxAddressLine2Label";
			this.uxAddressLine2Label.Text = "Address Line2:";
			this.uxAddressLine2Label.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxAddressLine2Label);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine2Label);			
			//
			// uxAddressLine2
			//
			this.uxAddressLine2.Name = "uxAddressLine2";
			this.uxAddressLine2.Width = 250;
			this.uxAddressLine2.MaxLength = 60;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine2);
			this.uxAddressLine2.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxAddressLine2);
			//
			// uxCityLabel
			//
			this.uxCityLabel.Name = "uxCityLabel";
			this.uxCityLabel.Text = "City:";
			this.uxCityLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxCityLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCityLabel);			
			//
			// uxCity
			//
			this.uxCity.Name = "uxCity";
			this.uxCity.Width = 250;
			this.uxCity.MaxLength = 30;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCity);
			this.uxCity.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxCity);
			//
			// uxStateProvinceIdLabel
			//
			this.uxStateProvinceIdLabel.Name = "uxStateProvinceIdLabel";
			this.uxStateProvinceIdLabel.Text = "State Province Id:";
			this.uxStateProvinceIdLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxStateProvinceIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStateProvinceIdLabel);			
			//
			// uxStateProvinceId
			//
			this.uxStateProvinceId.Name = "uxStateProvinceId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStateProvinceId);
			this.uxStateProvinceId.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxStateProvinceId);
			//
			// uxPostalCodeLabel
			//
			this.uxPostalCodeLabel.Name = "uxPostalCodeLabel";
			this.uxPostalCodeLabel.Text = "Postal Code:";
			this.uxPostalCodeLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxPostalCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPostalCodeLabel);			
			//
			// uxPostalCode
			//
			this.uxPostalCode.Name = "uxPostalCode";
			this.uxPostalCode.Width = 250;
			this.uxPostalCode.MaxLength = 15;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPostalCode);
			this.uxPostalCode.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxPostalCode);
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
			// uxStateProvinceId
			//				
			this.uxStateProvinceId.DisplayMember = "StateProvinceCode";	
			this.uxStateProvinceId.ValueMember = "StateProvinceId";	
			// 
			// AddressEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "AddressEditControlBase";
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
        /// Indicates if the controls associated with the uxAddressLine1 property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressLine1Visible
        {
            get { return this.uxAddressLine1.Visible; }
            set
            {
                this.uxAddressLine1Label.Visible = value;
                this.uxAddressLine1.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine1 property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressLine1Enabled
        {
            get { return this.uxAddressLine1.Enabled; }
            set
            {
                this.uxAddressLine1.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine2 property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressLine2Visible
        {
            get { return this.uxAddressLine2.Visible; }
            set
            {
                this.uxAddressLine2Label.Visible = value;
                this.uxAddressLine2.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine2 property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressLine2Enabled
        {
            get { return this.uxAddressLine2.Enabled; }
            set
            {
                this.uxAddressLine2.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCity property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCityVisible
        {
            get { return this.uxCity.Visible; }
            set
            {
                this.uxCityLabel.Visible = value;
                this.uxCity.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCity property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCityEnabled
        {
            get { return this.uxCity.Enabled; }
            set
            {
                this.uxCity.Enabled = value;
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
        /// Indicates if the controls associated with the uxPostalCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPostalCodeVisible
        {
            get { return this.uxPostalCode.Visible; }
            set
            {
                this.uxPostalCodeLabel.Visible = value;
                this.uxPostalCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPostalCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPostalCodeEnabled
        {
            get { return this.uxPostalCode.Enabled; }
            set
            {
                this.uxPostalCode.Enabled = value;
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
