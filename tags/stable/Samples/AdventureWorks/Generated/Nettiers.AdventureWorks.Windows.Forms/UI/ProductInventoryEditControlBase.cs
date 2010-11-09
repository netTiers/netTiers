
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ProductInventory"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductInventoryEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the ProductId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// ComboBox for the LocationId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxLocationId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LocationId property.
		/// </summary>
		protected System.Windows.Forms.Label uxLocationIdLabel;
		
		/// <summary>
		/// TextBox for the Shelf property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxShelf;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Shelf property.
		/// </summary>
		protected System.Windows.Forms.Label uxShelfLabel;
		
		/// <summary>
		/// TextBox for the Bin property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxBin;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Bin property.
		/// </summary>
		protected System.Windows.Forms.Label uxBinLabel;
		
		/// <summary>
		/// TextBox for the Quantity property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxQuantity;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Quantity property.
		/// </summary>
		protected System.Windows.Forms.Label uxQuantityLabel;
		
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
		private Entities.ProductInventory _ProductInventory;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ProductInventory"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ProductInventory"/> instance.</value>
		public Entities.ProductInventory ProductInventory
		{
			get {return this._ProductInventory;}
			set
			{
				this._ProductInventory = value;
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
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLocationId.DataBindings.Clear();
			this.uxLocationId.DataBindings.Add("SelectedValue", this.uxBindingSource, "LocationId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShelf.DataBindings.Clear();
			this.uxShelf.DataBindings.Add("Text", this.uxBindingSource, "Shelf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBin.DataBindings.Clear();
			this.uxBin.DataBindings.Add("Text", this.uxBindingSource, "Bin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxQuantity.DataBindings.Clear();
			this.uxQuantity.DataBindings.Add("Text", this.uxBindingSource, "Quantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductInventoryEditControlBase"/> class.
		/// </summary>
		public ProductInventoryEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ProductInventory != null) _ProductInventory.Validate();
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
			this.uxProductId = new System.Windows.Forms.ComboBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxLocationId = new System.Windows.Forms.ComboBox();
			uxLocationIdLabel = new System.Windows.Forms.Label();
			this.uxShelf = new System.Windows.Forms.TextBox();
			uxShelfLabel = new System.Windows.Forms.Label();
			this.uxBin = new System.Windows.Forms.TextBox();
			uxBinLabel = new System.Windows.Forms.Label();
			this.uxQuantity = new System.Windows.Forms.TextBox();
			uxQuantityLabel = new System.Windows.Forms.Label();
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
			// uxProductIdLabel
			//
			this.uxProductIdLabel.Name = "uxProductIdLabel";
			this.uxProductIdLabel.Text = "Product Id:";
			this.uxProductIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductIdLabel);			
			//
			// uxProductId
			//
			this.uxProductId.Name = "uxProductId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductId);
			this.uxProductId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxProductId);
			//
			// uxLocationIdLabel
			//
			this.uxLocationIdLabel.Name = "uxLocationIdLabel";
			this.uxLocationIdLabel.Text = "Location Id:";
			this.uxLocationIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxLocationIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLocationIdLabel);			
			//
			// uxLocationId
			//
			this.uxLocationId.Name = "uxLocationId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxLocationId);
			this.uxLocationId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxLocationId);
			//
			// uxShelfLabel
			//
			this.uxShelfLabel.Name = "uxShelfLabel";
			this.uxShelfLabel.Text = "Shelf:";
			this.uxShelfLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxShelfLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShelfLabel);			
			//
			// uxShelf
			//
			this.uxShelf.Name = "uxShelf";
			this.uxShelf.Width = 250;
			this.uxShelf.MaxLength = 10;
			//this.uxTableLayoutPanel.Controls.Add(this.uxShelf);
			this.uxShelf.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxShelf);
			//
			// uxBinLabel
			//
			this.uxBinLabel.Name = "uxBinLabel";
			this.uxBinLabel.Text = "Bin:";
			this.uxBinLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxBinLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBinLabel);			
			//
			// uxBin
			//
			this.uxBin.Name = "uxBin";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBin);
			this.uxBin.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxBin);
			//
			// uxQuantityLabel
			//
			this.uxQuantityLabel.Name = "uxQuantityLabel";
			this.uxQuantityLabel.Text = "Quantity:";
			this.uxQuantityLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxQuantityLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxQuantityLabel);			
			//
			// uxQuantity
			//
			this.uxQuantity.Name = "uxQuantity";
			//this.uxTableLayoutPanel.Controls.Add(this.uxQuantity);
			this.uxQuantity.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxQuantity);
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
			// uxLocationId
			//				
			this.uxLocationId.DisplayMember = "Name";	
			this.uxLocationId.ValueMember = "LocationId";	
			//
			// uxProductId
			//				
			this.uxProductId.DisplayMember = "Name";	
			this.uxProductId.ValueMember = "ProductId";	
			// 
			// ProductInventoryEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ProductInventoryEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Location> _LocationIdList;
		
		/// <summary>
		/// The ComboBox associated with the LocationId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Location> LocationIdList
		{
			get {return _LocationIdList;}
			set 
			{
				this._LocationIdList = value;
				this.uxLocationId.DataSource = null;
				this.uxLocationId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInLocationIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the LocationId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInLocationIdList
		{
			get { return _allowNewItemInLocationIdList;}
			set
			{
				this._allowNewItemInLocationIdList = value;
				this.uxLocationId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Product> _ProductIdList;
		
		/// <summary>
		/// The ComboBox associated with the ProductId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Product> ProductIdList
		{
			get {return _ProductIdList;}
			set 
			{
				this._ProductIdList = value;
				this.uxProductId.DataSource = null;
				this.uxProductId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInProductIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ProductId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductIdList
		{
			get { return _allowNewItemInProductIdList;}
			set
			{
				this._allowNewItemInProductIdList = value;
				this.uxProductId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductIdVisible
        {
            get { return this.uxProductId.Visible; }
            set
            {
                this.uxProductIdLabel.Visible = value;
                this.uxProductId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductIdEnabled
        {
            get { return this.uxProductId.Enabled; }
            set
            {
                this.uxProductId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLocationId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLocationIdVisible
        {
            get { return this.uxLocationId.Visible; }
            set
            {
                this.uxLocationIdLabel.Visible = value;
                this.uxLocationId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLocationId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLocationIdEnabled
        {
            get { return this.uxLocationId.Enabled; }
            set
            {
                this.uxLocationId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxShelf property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShelfVisible
        {
            get { return this.uxShelf.Visible; }
            set
            {
                this.uxShelfLabel.Visible = value;
                this.uxShelf.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShelf property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShelfEnabled
        {
            get { return this.uxShelf.Enabled; }
            set
            {
                this.uxShelf.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBin property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBinVisible
        {
            get { return this.uxBin.Visible; }
            set
            {
                this.uxBinLabel.Visible = value;
                this.uxBin.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBin property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBinEnabled
        {
            get { return this.uxBin.Enabled; }
            set
            {
                this.uxBin.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxQuantity property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxQuantityVisible
        {
            get { return this.uxQuantity.Visible; }
            set
            {
                this.uxQuantityLabel.Visible = value;
                this.uxQuantity.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxQuantity property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxQuantityEnabled
        {
            get { return this.uxQuantity.Enabled; }
            set
            {
                this.uxQuantity.Enabled = value;
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
