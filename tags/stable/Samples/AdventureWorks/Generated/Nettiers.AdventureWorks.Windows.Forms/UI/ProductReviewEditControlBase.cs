
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ProductReview"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductReviewEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the ProductReviewId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductReviewId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductReviewId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductReviewIdLabel;
		
		/// <summary>
		/// ComboBox for the ProductId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// TextBox for the ReviewerName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxReviewerName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ReviewerName property.
		/// </summary>
		protected System.Windows.Forms.Label uxReviewerNameLabel;
		
		/// <summary>
		/// DataTimePicker for the ReviewDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxReviewDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ReviewDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxReviewDateLabel;
		
		/// <summary>
		/// TextBox for the EmailAddress property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEmailAddress;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmailAddress property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmailAddressLabel;
		
		/// <summary>
		/// TextBox for the Rating property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRating;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Rating property.
		/// </summary>
		protected System.Windows.Forms.Label uxRatingLabel;
		
		/// <summary>
		/// TextBox for the Comments property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxComments;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Comments property.
		/// </summary>
		protected System.Windows.Forms.Label uxCommentsLabel;
		
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
		private Entities.ProductReview _ProductReview;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ProductReview"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ProductReview"/> instance.</value>
		public Entities.ProductReview ProductReview
		{
			get {return this._ProductReview;}
			set
			{
				this._ProductReview = value;
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
			this.uxProductReviewId.DataBindings.Clear();
			this.uxProductReviewId.DataBindings.Add("Text", this.uxBindingSource, "ProductReviewId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxReviewerName.DataBindings.Clear();
			this.uxReviewerName.DataBindings.Add("Text", this.uxBindingSource, "ReviewerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxReviewDate.DataBindings.Clear();
			this.uxReviewDate.DataBindings.Add("Value", this.uxBindingSource, "ReviewDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmailAddress.DataBindings.Clear();
			this.uxEmailAddress.DataBindings.Add("Text", this.uxBindingSource, "EmailAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRating.DataBindings.Clear();
			this.uxRating.DataBindings.Add("Text", this.uxBindingSource, "Rating", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxComments.DataBindings.Clear();
			this.uxComments.DataBindings.Add("Text", this.uxBindingSource, "Comments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductReviewEditControlBase"/> class.
		/// </summary>
		public ProductReviewEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ProductReview != null) _ProductReview.Validate();
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
			this.uxProductReviewId = new System.Windows.Forms.TextBox();
			uxProductReviewIdLabel = new System.Windows.Forms.Label();
			this.uxProductId = new System.Windows.Forms.ComboBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxReviewerName = new System.Windows.Forms.TextBox();
			uxReviewerNameLabel = new System.Windows.Forms.Label();
			this.uxReviewDate = new System.Windows.Forms.DateTimePicker();
			uxReviewDateLabel = new System.Windows.Forms.Label();
			this.uxEmailAddress = new System.Windows.Forms.TextBox();
			uxEmailAddressLabel = new System.Windows.Forms.Label();
			this.uxRating = new System.Windows.Forms.TextBox();
			uxRatingLabel = new System.Windows.Forms.Label();
			this.uxComments = new System.Windows.Forms.TextBox();
			uxCommentsLabel = new System.Windows.Forms.Label();
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
			// uxProductReviewIdLabel
			//
			this.uxProductReviewIdLabel.Name = "uxProductReviewIdLabel";
			this.uxProductReviewIdLabel.Text = "Product Review Id:";
			this.uxProductReviewIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxProductReviewIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductReviewIdLabel);			
			//
			// uxProductReviewId
			//
			this.uxProductReviewId.Name = "uxProductReviewId";
            this.uxProductReviewId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductReviewId);
			this.uxProductReviewId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxProductReviewId);
			//
			// uxProductIdLabel
			//
			this.uxProductIdLabel.Name = "uxProductIdLabel";
			this.uxProductIdLabel.Text = "Product Id:";
			this.uxProductIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductIdLabel);			
			//
			// uxProductId
			//
			this.uxProductId.Name = "uxProductId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductId);
			this.uxProductId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxProductId);
			//
			// uxReviewerNameLabel
			//
			this.uxReviewerNameLabel.Name = "uxReviewerNameLabel";
			this.uxReviewerNameLabel.Text = "Reviewer Name:";
			this.uxReviewerNameLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxReviewerNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxReviewerNameLabel);			
			//
			// uxReviewerName
			//
			this.uxReviewerName.Name = "uxReviewerName";
			this.uxReviewerName.Width = 250;
			this.uxReviewerName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxReviewerName);
			this.uxReviewerName.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxReviewerName);
			//
			// uxReviewDateLabel
			//
			this.uxReviewDateLabel.Name = "uxReviewDateLabel";
			this.uxReviewDateLabel.Text = "Review Date:";
			this.uxReviewDateLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxReviewDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxReviewDateLabel);			
			//
			// uxReviewDate
			//
			this.uxReviewDate.Name = "uxReviewDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxReviewDate);
			this.uxReviewDate.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxReviewDate);
			//
			// uxEmailAddressLabel
			//
			this.uxEmailAddressLabel.Name = "uxEmailAddressLabel";
			this.uxEmailAddressLabel.Text = "Email Address:";
			this.uxEmailAddressLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxEmailAddressLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailAddressLabel);			
			//
			// uxEmailAddress
			//
			this.uxEmailAddress.Name = "uxEmailAddress";
			this.uxEmailAddress.Width = 250;
			this.uxEmailAddress.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailAddress);
			this.uxEmailAddress.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxEmailAddress);
			//
			// uxRatingLabel
			//
			this.uxRatingLabel.Name = "uxRatingLabel";
			this.uxRatingLabel.Text = "Rating:";
			this.uxRatingLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxRatingLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRatingLabel);			
			//
			// uxRating
			//
			this.uxRating.Name = "uxRating";
			//this.uxTableLayoutPanel.Controls.Add(this.uxRating);
			this.uxRating.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxRating);
			//
			// uxCommentsLabel
			//
			this.uxCommentsLabel.Name = "uxCommentsLabel";
			this.uxCommentsLabel.Text = "Comments:";
			this.uxCommentsLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxCommentsLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCommentsLabel);			
			//
			// uxComments
			//
			this.uxComments.Name = "uxComments";
			this.uxComments.Width = 250;
			this.uxComments.MaxLength = 3850;
			//this.uxTableLayoutPanel.Controls.Add(this.uxComments);
			this.uxComments.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxComments);
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
			// uxProductId
			//				
			this.uxProductId.DisplayMember = "Name";	
			this.uxProductId.ValueMember = "ProductId";	
			// 
			// ProductReviewEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ProductReviewEditControlBase";
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
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxProductReviewId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductReviewIdVisible
        {
            get { return this.uxProductReviewId.Visible; }
            set
            {
                this.uxProductReviewIdLabel.Visible = value;
                this.uxProductReviewId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductReviewId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductReviewIdEnabled
        {
            get { return this.uxProductReviewId.Enabled; }
            set
            {
                this.uxProductReviewId.Enabled = value;
            }
        }
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
        /// Indicates if the controls associated with the uxReviewerName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxReviewerNameVisible
        {
            get { return this.uxReviewerName.Visible; }
            set
            {
                this.uxReviewerNameLabel.Visible = value;
                this.uxReviewerName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxReviewerName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxReviewerNameEnabled
        {
            get { return this.uxReviewerName.Enabled; }
            set
            {
                this.uxReviewerName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxReviewDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxReviewDateVisible
        {
            get { return this.uxReviewDate.Visible; }
            set
            {
                this.uxReviewDateLabel.Visible = value;
                this.uxReviewDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxReviewDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxReviewDateEnabled
        {
            get { return this.uxReviewDate.Enabled; }
            set
            {
                this.uxReviewDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEmailAddress property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEmailAddressVisible
        {
            get { return this.uxEmailAddress.Visible; }
            set
            {
                this.uxEmailAddressLabel.Visible = value;
                this.uxEmailAddress.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEmailAddress property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEmailAddressEnabled
        {
            get { return this.uxEmailAddress.Enabled; }
            set
            {
                this.uxEmailAddress.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRating property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRatingVisible
        {
            get { return this.uxRating.Visible; }
            set
            {
                this.uxRatingLabel.Visible = value;
                this.uxRating.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRating property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRatingEnabled
        {
            get { return this.uxRating.Enabled; }
            set
            {
                this.uxRating.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxComments property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCommentsVisible
        {
            get { return this.uxComments.Visible; }
            set
            {
                this.uxCommentsLabel.Visible = value;
                this.uxComments.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxComments property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCommentsEnabled
        {
            get { return this.uxComments.Enabled; }
            set
            {
                this.uxComments.Enabled = value;
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
