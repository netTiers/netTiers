
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ProductProductPhoto"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductProductPhotoEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the ProductPhotoId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductPhotoId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductPhotoId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductPhotoIdLabel;
		
		/// <summary>
		/// CheckBox for the Primary property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxPrimary;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Primary property.
		/// </summary>
		protected System.Windows.Forms.Label uxPrimaryLabel;
		
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
		private Entities.ProductProductPhoto _ProductProductPhoto;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ProductProductPhoto"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ProductProductPhoto"/> instance.</value>
		public Entities.ProductProductPhoto ProductProductPhoto
		{
			get {return this._ProductProductPhoto;}
			set
			{
				this._ProductProductPhoto = value;
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
			this.uxProductPhotoId.DataBindings.Clear();
			this.uxProductPhotoId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductPhotoId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPrimary.DataBindings.Clear();
			this.uxPrimary.DataBindings.Add("Checked", this.uxBindingSource, "Primary", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductProductPhotoEditControlBase"/> class.
		/// </summary>
		public ProductProductPhotoEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ProductProductPhoto != null) _ProductProductPhoto.Validate();
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
			this.uxProductPhotoId = new System.Windows.Forms.ComboBox();
			uxProductPhotoIdLabel = new System.Windows.Forms.Label();
			this.uxPrimary = new System.Windows.Forms.CheckBox();
			uxPrimaryLabel = new System.Windows.Forms.Label();
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
			// uxProductPhotoIdLabel
			//
			this.uxProductPhotoIdLabel.Name = "uxProductPhotoIdLabel";
			this.uxProductPhotoIdLabel.Text = "Product Photo Id:";
			this.uxProductPhotoIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxProductPhotoIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductPhotoIdLabel);			
			//
			// uxProductPhotoId
			//
			this.uxProductPhotoId.Name = "uxProductPhotoId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductPhotoId);
			this.uxProductPhotoId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxProductPhotoId);
			//
			// uxPrimaryLabel
			//
			this.uxPrimaryLabel.Name = "uxPrimaryLabel";
			this.uxPrimaryLabel.Text = "Primary:";
			this.uxPrimaryLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxPrimaryLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPrimaryLabel);			
			//
			// uxPrimary
			//
			this.uxPrimary.Name = "uxPrimary";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPrimary);
			this.uxPrimary.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxPrimary);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxProductId
			//				
			this.uxProductId.DisplayMember = "Name";	
			this.uxProductId.ValueMember = "ProductId";	
			//
			// uxProductPhotoId
			//				
			this.uxProductPhotoId.DisplayMember = "ThumbNailPhoto";	
			this.uxProductPhotoId.ValueMember = "ProductPhotoId";	
			// 
			// ProductProductPhotoEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ProductProductPhotoEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
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
		
				
		private Entities.TList<Entities.ProductPhoto> _ProductPhotoIdList;
		
		/// <summary>
		/// The ComboBox associated with the ProductPhotoId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.ProductPhoto> ProductPhotoIdList
		{
			get {return _ProductPhotoIdList;}
			set 
			{
				this._ProductPhotoIdList = value;
				this.uxProductPhotoId.DataSource = null;
				this.uxProductPhotoId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInProductPhotoIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ProductPhotoId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductPhotoIdList
		{
			get { return _allowNewItemInProductPhotoIdList;}
			set
			{
				this._allowNewItemInProductPhotoIdList = value;
				this.uxProductPhotoId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        /// Indicates if the controls associated with the uxProductPhotoId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductPhotoIdVisible
        {
            get { return this.uxProductPhotoId.Visible; }
            set
            {
                this.uxProductPhotoIdLabel.Visible = value;
                this.uxProductPhotoId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductPhotoId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductPhotoIdEnabled
        {
            get { return this.uxProductPhotoId.Enabled; }
            set
            {
                this.uxProductPhotoId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPrimary property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPrimaryVisible
        {
            get { return this.uxPrimary.Visible; }
            set
            {
                this.uxPrimaryLabel.Visible = value;
                this.uxPrimary.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPrimary property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPrimaryEnabled
        {
            get { return this.uxPrimary.Enabled; }
            set
            {
                this.uxPrimary.Enabled = value;
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
