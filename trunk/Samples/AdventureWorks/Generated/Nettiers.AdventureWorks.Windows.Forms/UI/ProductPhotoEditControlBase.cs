
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ProductPhoto"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductPhotoEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the ProductPhotoId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductPhotoId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductPhotoId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductPhotoIdLabel;
		
		/// <summary>
		/// TextBox for the ThumbNailPhoto property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxThumbNailPhoto;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ThumbNailPhoto property.
		/// </summary>
		protected System.Windows.Forms.Label uxThumbNailPhotoLabel;
		
		/// <summary>
		/// TextBox for the ThumbnailPhotoFileName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxThumbnailPhotoFileName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ThumbnailPhotoFileName property.
		/// </summary>
		protected System.Windows.Forms.Label uxThumbnailPhotoFileNameLabel;
		
		/// <summary>
		/// TextBox for the LargePhoto property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLargePhoto;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LargePhoto property.
		/// </summary>
		protected System.Windows.Forms.Label uxLargePhotoLabel;
		
		/// <summary>
		/// TextBox for the LargePhotoFileName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLargePhotoFileName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LargePhotoFileName property.
		/// </summary>
		protected System.Windows.Forms.Label uxLargePhotoFileNameLabel;
		
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
		private Entities.ProductPhoto _ProductPhoto;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ProductPhoto"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ProductPhoto"/> instance.</value>
		public Entities.ProductPhoto ProductPhoto
		{
			get {return this._ProductPhoto;}
			set
			{
				this._ProductPhoto = value;
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
			this.uxProductPhotoId.DataBindings.Clear();
			this.uxProductPhotoId.DataBindings.Add("Text", this.uxBindingSource, "ProductPhotoId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxThumbNailPhoto.DataBindings.Clear();
			this.uxThumbNailPhoto.DataBindings.Add("Text", this.uxBindingSource, "ThumbNailPhoto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxThumbnailPhotoFileName.DataBindings.Clear();
			this.uxThumbnailPhotoFileName.DataBindings.Add("Text", this.uxBindingSource, "ThumbnailPhotoFileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLargePhoto.DataBindings.Clear();
			this.uxLargePhoto.DataBindings.Add("Text", this.uxBindingSource, "LargePhoto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLargePhotoFileName.DataBindings.Clear();
			this.uxLargePhotoFileName.DataBindings.Add("Text", this.uxBindingSource, "LargePhotoFileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductPhotoEditControlBase"/> class.
		/// </summary>
		public ProductPhotoEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ProductPhoto != null) _ProductPhoto.Validate();
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
			this.uxProductPhotoId = new System.Windows.Forms.TextBox();
			uxProductPhotoIdLabel = new System.Windows.Forms.Label();
			this.uxThumbNailPhoto = new System.Windows.Forms.TextBox();
			uxThumbNailPhotoLabel = new System.Windows.Forms.Label();
			this.uxThumbnailPhotoFileName = new System.Windows.Forms.TextBox();
			uxThumbnailPhotoFileNameLabel = new System.Windows.Forms.Label();
			this.uxLargePhoto = new System.Windows.Forms.TextBox();
			uxLargePhotoLabel = new System.Windows.Forms.Label();
			this.uxLargePhotoFileName = new System.Windows.Forms.TextBox();
			uxLargePhotoFileNameLabel = new System.Windows.Forms.Label();
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
			// uxProductPhotoIdLabel
			//
			this.uxProductPhotoIdLabel.Name = "uxProductPhotoIdLabel";
			this.uxProductPhotoIdLabel.Text = "Product Photo Id:";
			this.uxProductPhotoIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxProductPhotoIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductPhotoIdLabel);			
			//
			// uxProductPhotoId
			//
			this.uxProductPhotoId.Name = "uxProductPhotoId";
            this.uxProductPhotoId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductPhotoId);
			this.uxProductPhotoId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxProductPhotoId);
			//
			// uxThumbNailPhotoLabel
			//
			this.uxThumbNailPhotoLabel.Name = "uxThumbNailPhotoLabel";
			this.uxThumbNailPhotoLabel.Text = "Thumb Nail Photo:";
			this.uxThumbNailPhotoLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxThumbNailPhotoLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxThumbNailPhotoLabel);			
			//
			// uxThumbNailPhoto
			//
			this.uxThumbNailPhoto.Name = "uxThumbNailPhoto";
			//this.uxTableLayoutPanel.Controls.Add(this.uxThumbNailPhoto);
			this.uxThumbNailPhoto.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxThumbNailPhoto);
			//
			// uxThumbnailPhotoFileNameLabel
			//
			this.uxThumbnailPhotoFileNameLabel.Name = "uxThumbnailPhotoFileNameLabel";
			this.uxThumbnailPhotoFileNameLabel.Text = "Thumbnail Photo File Name:";
			this.uxThumbnailPhotoFileNameLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxThumbnailPhotoFileNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxThumbnailPhotoFileNameLabel);			
			//
			// uxThumbnailPhotoFileName
			//
			this.uxThumbnailPhotoFileName.Name = "uxThumbnailPhotoFileName";
			this.uxThumbnailPhotoFileName.Width = 250;
			this.uxThumbnailPhotoFileName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxThumbnailPhotoFileName);
			this.uxThumbnailPhotoFileName.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxThumbnailPhotoFileName);
			//
			// uxLargePhotoLabel
			//
			this.uxLargePhotoLabel.Name = "uxLargePhotoLabel";
			this.uxLargePhotoLabel.Text = "Large Photo:";
			this.uxLargePhotoLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxLargePhotoLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLargePhotoLabel);			
			//
			// uxLargePhoto
			//
			this.uxLargePhoto.Name = "uxLargePhoto";
			//this.uxTableLayoutPanel.Controls.Add(this.uxLargePhoto);
			this.uxLargePhoto.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxLargePhoto);
			//
			// uxLargePhotoFileNameLabel
			//
			this.uxLargePhotoFileNameLabel.Name = "uxLargePhotoFileNameLabel";
			this.uxLargePhotoFileNameLabel.Text = "Large Photo File Name:";
			this.uxLargePhotoFileNameLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxLargePhotoFileNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLargePhotoFileNameLabel);			
			//
			// uxLargePhotoFileName
			//
			this.uxLargePhotoFileName.Name = "uxLargePhotoFileName";
			this.uxLargePhotoFileName.Width = 250;
			this.uxLargePhotoFileName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLargePhotoFileName);
			this.uxLargePhotoFileName.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxLargePhotoFileName);
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
			// ProductPhotoEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ProductPhotoEditControlBase";
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
        /// Indicates if the controls associated with the uxThumbNailPhoto property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxThumbNailPhotoVisible
        {
            get { return this.uxThumbNailPhoto.Visible; }
            set
            {
                this.uxThumbNailPhotoLabel.Visible = value;
                this.uxThumbNailPhoto.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxThumbNailPhoto property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxThumbNailPhotoEnabled
        {
            get { return this.uxThumbNailPhoto.Enabled; }
            set
            {
                this.uxThumbNailPhoto.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxThumbnailPhotoFileName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxThumbnailPhotoFileNameVisible
        {
            get { return this.uxThumbnailPhotoFileName.Visible; }
            set
            {
                this.uxThumbnailPhotoFileNameLabel.Visible = value;
                this.uxThumbnailPhotoFileName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxThumbnailPhotoFileName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxThumbnailPhotoFileNameEnabled
        {
            get { return this.uxThumbnailPhotoFileName.Enabled; }
            set
            {
                this.uxThumbnailPhotoFileName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLargePhoto property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLargePhotoVisible
        {
            get { return this.uxLargePhoto.Visible; }
            set
            {
                this.uxLargePhotoLabel.Visible = value;
                this.uxLargePhoto.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLargePhoto property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLargePhotoEnabled
        {
            get { return this.uxLargePhoto.Enabled; }
            set
            {
                this.uxLargePhoto.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLargePhotoFileName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLargePhotoFileNameVisible
        {
            get { return this.uxLargePhotoFileName.Visible; }
            set
            {
                this.uxLargePhotoFileNameLabel.Visible = value;
                this.uxLargePhotoFileName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLargePhotoFileName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLargePhotoFileNameEnabled
        {
            get { return this.uxLargePhotoFileName.Enabled; }
            set
            {
                this.uxLargePhotoFileName.Enabled = value;
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
