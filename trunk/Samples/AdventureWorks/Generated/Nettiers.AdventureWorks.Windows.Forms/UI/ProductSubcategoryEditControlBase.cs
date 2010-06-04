
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ProductSubcategory"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductSubcategoryEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the ProductSubcategoryId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductSubcategoryId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductSubcategoryId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductSubcategoryIdLabel;
		
		/// <summary>
		/// ComboBox for the ProductCategoryId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductCategoryId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductCategoryId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductCategoryIdLabel;
		
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
		private Entities.ProductSubcategory _ProductSubcategory;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ProductSubcategory"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ProductSubcategory"/> instance.</value>
		public Entities.ProductSubcategory ProductSubcategory
		{
			get {return this._ProductSubcategory;}
			set
			{
				this._ProductSubcategory = value;
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
			this.uxProductSubcategoryId.DataBindings.Clear();
			this.uxProductSubcategoryId.DataBindings.Add("Text", this.uxBindingSource, "ProductSubcategoryId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductCategoryId.DataBindings.Clear();
			this.uxProductCategoryId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductCategoryId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductSubcategoryEditControlBase"/> class.
		/// </summary>
		public ProductSubcategoryEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ProductSubcategory != null) _ProductSubcategory.Validate();
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
			this.uxProductSubcategoryId = new System.Windows.Forms.TextBox();
			uxProductSubcategoryIdLabel = new System.Windows.Forms.Label();
			this.uxProductCategoryId = new System.Windows.Forms.ComboBox();
			uxProductCategoryIdLabel = new System.Windows.Forms.Label();
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
			// uxProductSubcategoryIdLabel
			//
			this.uxProductSubcategoryIdLabel.Name = "uxProductSubcategoryIdLabel";
			this.uxProductSubcategoryIdLabel.Text = "Product Subcategory Id:";
			this.uxProductSubcategoryIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxProductSubcategoryIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductSubcategoryIdLabel);			
			//
			// uxProductSubcategoryId
			//
			this.uxProductSubcategoryId.Name = "uxProductSubcategoryId";
            this.uxProductSubcategoryId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductSubcategoryId);
			this.uxProductSubcategoryId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxProductSubcategoryId);
			//
			// uxProductCategoryIdLabel
			//
			this.uxProductCategoryIdLabel.Name = "uxProductCategoryIdLabel";
			this.uxProductCategoryIdLabel.Text = "Product Category Id:";
			this.uxProductCategoryIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxProductCategoryIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductCategoryIdLabel);			
			//
			// uxProductCategoryId
			//
			this.uxProductCategoryId.Name = "uxProductCategoryId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductCategoryId);
			this.uxProductCategoryId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxProductCategoryId);
			//
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxName);
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
			// uxProductCategoryId
			//				
			this.uxProductCategoryId.DisplayMember = "Name";	
			this.uxProductCategoryId.ValueMember = "ProductCategoryId";	
			// 
			// ProductSubcategoryEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ProductSubcategoryEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.ProductCategory> _ProductCategoryIdList;
		
		/// <summary>
		/// The ComboBox associated with the ProductCategoryId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.ProductCategory> ProductCategoryIdList
		{
			get {return _ProductCategoryIdList;}
			set 
			{
				this._ProductCategoryIdList = value;
				this.uxProductCategoryId.DataSource = null;
				this.uxProductCategoryId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInProductCategoryIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ProductCategoryId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductCategoryIdList
		{
			get { return _allowNewItemInProductCategoryIdList;}
			set
			{
				this._allowNewItemInProductCategoryIdList = value;
				this.uxProductCategoryId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxProductSubcategoryId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductSubcategoryIdVisible
        {
            get { return this.uxProductSubcategoryId.Visible; }
            set
            {
                this.uxProductSubcategoryIdLabel.Visible = value;
                this.uxProductSubcategoryId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductSubcategoryId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductSubcategoryIdEnabled
        {
            get { return this.uxProductSubcategoryId.Enabled; }
            set
            {
                this.uxProductSubcategoryId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductCategoryId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductCategoryIdVisible
        {
            get { return this.uxProductCategoryId.Visible; }
            set
            {
                this.uxProductCategoryIdLabel.Visible = value;
                this.uxProductCategoryId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductCategoryId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductCategoryIdEnabled
        {
            get { return this.uxProductCategoryId.Enabled; }
            set
            {
                this.uxProductCategoryId.Enabled = value;
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
