
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ShipMethod"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ShipMethodEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the ShipMethodId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxShipMethodId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShipMethodId property.
		/// </summary>
		protected System.Windows.Forms.Label uxShipMethodIdLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// TextBox for the ShipBase property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxShipBase;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShipBase property.
		/// </summary>
		protected System.Windows.Forms.Label uxShipBaseLabel;
		
		/// <summary>
		/// TextBox for the ShipRate property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxShipRate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShipRate property.
		/// </summary>
		protected System.Windows.Forms.Label uxShipRateLabel;
		
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
		private Entities.ShipMethod _ShipMethod;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ShipMethod"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ShipMethod"/> instance.</value>
		public Entities.ShipMethod ShipMethod
		{
			get {return this._ShipMethod;}
			set
			{
				this._ShipMethod = value;
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
			this.uxShipMethodId.DataBindings.Clear();
			this.uxShipMethodId.DataBindings.Add("Text", this.uxBindingSource, "ShipMethodId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShipBase.DataBindings.Clear();
			this.uxShipBase.DataBindings.Add("Text", this.uxBindingSource, "ShipBase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShipRate.DataBindings.Clear();
			this.uxShipRate.DataBindings.Add("Text", this.uxBindingSource, "ShipRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ShipMethodEditControlBase"/> class.
		/// </summary>
		public ShipMethodEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ShipMethod != null) _ShipMethod.Validate();
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
			this.uxShipMethodId = new System.Windows.Forms.TextBox();
			uxShipMethodIdLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxShipBase = new System.Windows.Forms.TextBox();
			uxShipBaseLabel = new System.Windows.Forms.Label();
			this.uxShipRate = new System.Windows.Forms.TextBox();
			uxShipRateLabel = new System.Windows.Forms.Label();
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
			// uxShipMethodIdLabel
			//
			this.uxShipMethodIdLabel.Name = "uxShipMethodIdLabel";
			this.uxShipMethodIdLabel.Text = "Ship Method Id:";
			this.uxShipMethodIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxShipMethodIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipMethodIdLabel);			
			//
			// uxShipMethodId
			//
			this.uxShipMethodId.Name = "uxShipMethodId";
            this.uxShipMethodId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipMethodId);
			this.uxShipMethodId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxShipMethodId);
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
			// uxShipBaseLabel
			//
			this.uxShipBaseLabel.Name = "uxShipBaseLabel";
			this.uxShipBaseLabel.Text = "Ship Base:";
			this.uxShipBaseLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxShipBaseLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipBaseLabel);			
			//
			// uxShipBase
			//
			this.uxShipBase.Name = "uxShipBase";
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipBase);
			this.uxShipBase.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxShipBase);
			//
			// uxShipRateLabel
			//
			this.uxShipRateLabel.Name = "uxShipRateLabel";
			this.uxShipRateLabel.Text = "Ship Rate:";
			this.uxShipRateLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxShipRateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipRateLabel);			
			//
			// uxShipRate
			//
			this.uxShipRate.Name = "uxShipRate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxShipRate);
			this.uxShipRate.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxShipRate);
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
			// ShipMethodEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ShipMethodEditControlBase";
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
        /// Indicates if the controls associated with the uxShipMethodId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShipMethodIdVisible
        {
            get { return this.uxShipMethodId.Visible; }
            set
            {
                this.uxShipMethodIdLabel.Visible = value;
                this.uxShipMethodId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShipMethodId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShipMethodIdEnabled
        {
            get { return this.uxShipMethodId.Enabled; }
            set
            {
                this.uxShipMethodId.Enabled = value;
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
        /// Indicates if the controls associated with the uxShipBase property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShipBaseVisible
        {
            get { return this.uxShipBase.Visible; }
            set
            {
                this.uxShipBaseLabel.Visible = value;
                this.uxShipBase.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShipBase property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShipBaseEnabled
        {
            get { return this.uxShipBase.Enabled; }
            set
            {
                this.uxShipBase.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxShipRate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShipRateVisible
        {
            get { return this.uxShipRate.Visible; }
            set
            {
                this.uxShipRateLabel.Visible = value;
                this.uxShipRate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShipRate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShipRateEnabled
        {
            get { return this.uxShipRate.Enabled; }
            set
            {
                this.uxShipRate.Enabled = value;
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
