
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Document"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class DocumentEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the DocumentId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDocumentId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DocumentId property.
		/// </summary>
		protected System.Windows.Forms.Label uxDocumentIdLabel;
		
		/// <summary>
		/// TextBox for the Title property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTitle;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Title property.
		/// </summary>
		protected System.Windows.Forms.Label uxTitleLabel;
		
		/// <summary>
		/// TextBox for the FileName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxFileName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the FileName property.
		/// </summary>
		protected System.Windows.Forms.Label uxFileNameLabel;
		
		/// <summary>
		/// TextBox for the FileExtension property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxFileExtension;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the FileExtension property.
		/// </summary>
		protected System.Windows.Forms.Label uxFileExtensionLabel;
		
		/// <summary>
		/// TextBox for the Revision property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRevision;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Revision property.
		/// </summary>
		protected System.Windows.Forms.Label uxRevisionLabel;
		
		/// <summary>
		/// TextBox for the ChangeNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxChangeNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ChangeNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxChangeNumberLabel;
		
		/// <summary>
		/// TextBox for the Status property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStatus;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Status property.
		/// </summary>
		protected System.Windows.Forms.Label uxStatusLabel;
		
		/// <summary>
		/// TextBox for the DocumentSummary property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDocumentSummary;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DocumentSummary property.
		/// </summary>
		protected System.Windows.Forms.Label uxDocumentSummaryLabel;
		
		/// <summary>
		/// TextBox for the Document property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDocument;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Document property.
		/// </summary>
		protected System.Windows.Forms.Label uxDocumentLabel;
		
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
		private Entities.Document _Document;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Document"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Document"/> instance.</value>
		public Entities.Document Document
		{
			get {return this._Document;}
			set
			{
				this._Document = value;
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
			this.uxDocumentId.DataBindings.Clear();
			this.uxDocumentId.DataBindings.Add("Text", this.uxBindingSource, "DocumentId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTitle.DataBindings.Clear();
			this.uxTitle.DataBindings.Add("Text", this.uxBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFileName.DataBindings.Clear();
			this.uxFileName.DataBindings.Add("Text", this.uxBindingSource, "FileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFileExtension.DataBindings.Clear();
			this.uxFileExtension.DataBindings.Add("Text", this.uxBindingSource, "FileExtension", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRevision.DataBindings.Clear();
			this.uxRevision.DataBindings.Add("Text", this.uxBindingSource, "Revision", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxChangeNumber.DataBindings.Clear();
			this.uxChangeNumber.DataBindings.Add("Text", this.uxBindingSource, "ChangeNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStatus.DataBindings.Clear();
			this.uxStatus.DataBindings.Add("Text", this.uxBindingSource, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDocumentSummary.DataBindings.Clear();
			this.uxDocumentSummary.DataBindings.Add("Text", this.uxBindingSource, "DocumentSummary", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDocument.DataBindings.Clear();
			this.uxDocument.DataBindings.Add("Text", this.uxBindingSource, "Document", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentEditControlBase"/> class.
		/// </summary>
		public DocumentEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Document != null) _Document.Validate();
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
			this.uxDocumentId = new System.Windows.Forms.TextBox();
			uxDocumentIdLabel = new System.Windows.Forms.Label();
			this.uxTitle = new System.Windows.Forms.TextBox();
			uxTitleLabel = new System.Windows.Forms.Label();
			this.uxFileName = new System.Windows.Forms.TextBox();
			uxFileNameLabel = new System.Windows.Forms.Label();
			this.uxFileExtension = new System.Windows.Forms.TextBox();
			uxFileExtensionLabel = new System.Windows.Forms.Label();
			this.uxRevision = new System.Windows.Forms.TextBox();
			uxRevisionLabel = new System.Windows.Forms.Label();
			this.uxChangeNumber = new System.Windows.Forms.TextBox();
			uxChangeNumberLabel = new System.Windows.Forms.Label();
			this.uxStatus = new System.Windows.Forms.TextBox();
			uxStatusLabel = new System.Windows.Forms.Label();
			this.uxDocumentSummary = new System.Windows.Forms.TextBox();
			uxDocumentSummaryLabel = new System.Windows.Forms.Label();
			this.uxDocument = new System.Windows.Forms.TextBox();
			uxDocumentLabel = new System.Windows.Forms.Label();
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
			// uxDocumentIdLabel
			//
			this.uxDocumentIdLabel.Name = "uxDocumentIdLabel";
			this.uxDocumentIdLabel.Text = "Document Id:";
			this.uxDocumentIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxDocumentIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDocumentIdLabel);			
			//
			// uxDocumentId
			//
			this.uxDocumentId.Name = "uxDocumentId";
            this.uxDocumentId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxDocumentId);
			this.uxDocumentId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxDocumentId);
			//
			// uxTitleLabel
			//
			this.uxTitleLabel.Name = "uxTitleLabel";
			this.uxTitleLabel.Text = "Title:";
			this.uxTitleLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxTitleLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTitleLabel);			
			//
			// uxTitle
			//
			this.uxTitle.Name = "uxTitle";
			this.uxTitle.Width = 250;
			this.uxTitle.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTitle);
			this.uxTitle.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxTitle);
			//
			// uxFileNameLabel
			//
			this.uxFileNameLabel.Name = "uxFileNameLabel";
			this.uxFileNameLabel.Text = "File Name:";
			this.uxFileNameLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxFileNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFileNameLabel);			
			//
			// uxFileName
			//
			this.uxFileName.Name = "uxFileName";
			this.uxFileName.Width = 250;
			this.uxFileName.MaxLength = 400;
			//this.uxTableLayoutPanel.Controls.Add(this.uxFileName);
			this.uxFileName.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxFileName);
			//
			// uxFileExtensionLabel
			//
			this.uxFileExtensionLabel.Name = "uxFileExtensionLabel";
			this.uxFileExtensionLabel.Text = "File Extension:";
			this.uxFileExtensionLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxFileExtensionLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFileExtensionLabel);			
			//
			// uxFileExtension
			//
			this.uxFileExtension.Name = "uxFileExtension";
			this.uxFileExtension.Width = 250;
			this.uxFileExtension.MaxLength = 8;
			//this.uxTableLayoutPanel.Controls.Add(this.uxFileExtension);
			this.uxFileExtension.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxFileExtension);
			//
			// uxRevisionLabel
			//
			this.uxRevisionLabel.Name = "uxRevisionLabel";
			this.uxRevisionLabel.Text = "Revision:";
			this.uxRevisionLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxRevisionLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRevisionLabel);			
			//
			// uxRevision
			//
			this.uxRevision.Name = "uxRevision";
			this.uxRevision.Width = 250;
			this.uxRevision.MaxLength = 5;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRevision);
			this.uxRevision.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxRevision);
			//
			// uxChangeNumberLabel
			//
			this.uxChangeNumberLabel.Name = "uxChangeNumberLabel";
			this.uxChangeNumberLabel.Text = "Change Number:";
			this.uxChangeNumberLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxChangeNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxChangeNumberLabel);			
			//
			// uxChangeNumber
			//
			this.uxChangeNumber.Name = "uxChangeNumber";
			//this.uxTableLayoutPanel.Controls.Add(this.uxChangeNumber);
			this.uxChangeNumber.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxChangeNumber);
			//
			// uxStatusLabel
			//
			this.uxStatusLabel.Name = "uxStatusLabel";
			this.uxStatusLabel.Text = "Status:";
			this.uxStatusLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxStatusLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStatusLabel);			
			//
			// uxStatus
			//
			this.uxStatus.Name = "uxStatus";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStatus);
			this.uxStatus.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxStatus);
			//
			// uxDocumentSummaryLabel
			//
			this.uxDocumentSummaryLabel.Name = "uxDocumentSummaryLabel";
			this.uxDocumentSummaryLabel.Text = "Document Summary:";
			this.uxDocumentSummaryLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxDocumentSummaryLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDocumentSummaryLabel);			
			//
			// uxDocumentSummary
			//
			this.uxDocumentSummary.Name = "uxDocumentSummary";
			this.uxDocumentSummary.Width = 250;
			this.uxDocumentSummary.Multiline = true;
			//this.uxDocumentSummary.Height = 80;
			//this.uxTableLayoutPanel.Controls.Add(this.uxDocumentSummary);
			this.uxDocumentSummary.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxDocumentSummary);
			//
			// uxDocumentLabel
			//
			this.uxDocumentLabel.Name = "uxDocumentLabel";
			this.uxDocumentLabel.Text = "Document:";
			this.uxDocumentLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxDocumentLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDocumentLabel);			
			//
			// uxDocument
			//
			this.uxDocument.Name = "uxDocument";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDocument);
			this.uxDocument.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxDocument);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxModifiedDate);
			// 
			// DocumentEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "DocumentEditControlBase";
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
        /// Indicates if the controls associated with the uxDocumentId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDocumentIdVisible
        {
            get { return this.uxDocumentId.Visible; }
            set
            {
                this.uxDocumentIdLabel.Visible = value;
                this.uxDocumentId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDocumentId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDocumentIdEnabled
        {
            get { return this.uxDocumentId.Enabled; }
            set
            {
                this.uxDocumentId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTitle property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTitleVisible
        {
            get { return this.uxTitle.Visible; }
            set
            {
                this.uxTitleLabel.Visible = value;
                this.uxTitle.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTitle property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTitleEnabled
        {
            get { return this.uxTitle.Enabled; }
            set
            {
                this.uxTitle.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFileName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFileNameVisible
        {
            get { return this.uxFileName.Visible; }
            set
            {
                this.uxFileNameLabel.Visible = value;
                this.uxFileName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFileName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFileNameEnabled
        {
            get { return this.uxFileName.Enabled; }
            set
            {
                this.uxFileName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFileExtension property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFileExtensionVisible
        {
            get { return this.uxFileExtension.Visible; }
            set
            {
                this.uxFileExtensionLabel.Visible = value;
                this.uxFileExtension.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFileExtension property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFileExtensionEnabled
        {
            get { return this.uxFileExtension.Enabled; }
            set
            {
                this.uxFileExtension.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRevision property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRevisionVisible
        {
            get { return this.uxRevision.Visible; }
            set
            {
                this.uxRevisionLabel.Visible = value;
                this.uxRevision.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRevision property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRevisionEnabled
        {
            get { return this.uxRevision.Enabled; }
            set
            {
                this.uxRevision.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxChangeNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxChangeNumberVisible
        {
            get { return this.uxChangeNumber.Visible; }
            set
            {
                this.uxChangeNumberLabel.Visible = value;
                this.uxChangeNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxChangeNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxChangeNumberEnabled
        {
            get { return this.uxChangeNumber.Enabled; }
            set
            {
                this.uxChangeNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStatus property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStatusVisible
        {
            get { return this.uxStatus.Visible; }
            set
            {
                this.uxStatusLabel.Visible = value;
                this.uxStatus.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStatus property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStatusEnabled
        {
            get { return this.uxStatus.Enabled; }
            set
            {
                this.uxStatus.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDocumentSummary property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDocumentSummaryVisible
        {
            get { return this.uxDocumentSummary.Visible; }
            set
            {
                this.uxDocumentSummaryLabel.Visible = value;
                this.uxDocumentSummary.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDocumentSummary property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDocumentSummaryEnabled
        {
            get { return this.uxDocumentSummary.Enabled; }
            set
            {
                this.uxDocumentSummary.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDocument property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDocumentVisible
        {
            get { return this.uxDocument.Visible; }
            set
            {
                this.uxDocumentLabel.Visible = value;
                this.uxDocument.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDocument property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDocumentEnabled
        {
            get { return this.uxDocument.Enabled; }
            set
            {
                this.uxDocument.Enabled = value;
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
