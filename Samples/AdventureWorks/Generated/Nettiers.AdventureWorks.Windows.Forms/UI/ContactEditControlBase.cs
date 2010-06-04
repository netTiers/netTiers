
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Contact"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ContactEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the ContactId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxContactId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ContactId property.
		/// </summary>
		protected System.Windows.Forms.Label uxContactIdLabel;
		
		/// <summary>
		/// CheckBox for the NameStyle property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxNameStyle;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the NameStyle property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameStyleLabel;
		
		/// <summary>
		/// TextBox for the Title property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTitle;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Title property.
		/// </summary>
		protected System.Windows.Forms.Label uxTitleLabel;
		
		/// <summary>
		/// TextBox for the FirstName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxFirstName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the FirstName property.
		/// </summary>
		protected System.Windows.Forms.Label uxFirstNameLabel;
		
		/// <summary>
		/// TextBox for the MiddleName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxMiddleName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the MiddleName property.
		/// </summary>
		protected System.Windows.Forms.Label uxMiddleNameLabel;
		
		/// <summary>
		/// TextBox for the LastName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLastName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LastName property.
		/// </summary>
		protected System.Windows.Forms.Label uxLastNameLabel;
		
		/// <summary>
		/// TextBox for the Suffix property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSuffix;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Suffix property.
		/// </summary>
		protected System.Windows.Forms.Label uxSuffixLabel;
		
		/// <summary>
		/// TextBox for the EmailAddress property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEmailAddress;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmailAddress property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmailAddressLabel;
		
		/// <summary>
		/// TextBox for the EmailPromotion property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEmailPromotion;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmailPromotion property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmailPromotionLabel;
		
		/// <summary>
		/// TextBox for the Phone property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPhone;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Phone property.
		/// </summary>
		protected System.Windows.Forms.Label uxPhoneLabel;
		
		/// <summary>
		/// TextBox for the PasswordHash property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPasswordHash;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PasswordHash property.
		/// </summary>
		protected System.Windows.Forms.Label uxPasswordHashLabel;
		
		/// <summary>
		/// TextBox for the PasswordSalt property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPasswordSalt;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PasswordSalt property.
		/// </summary>
		protected System.Windows.Forms.Label uxPasswordSaltLabel;
		
		/// <summary>
		/// TextBox for the AdditionalContactInfo property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAdditionalContactInfo;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AdditionalContactInfo property.
		/// </summary>
		protected System.Windows.Forms.Label uxAdditionalContactInfoLabel;
		
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
		private Entities.Contact _Contact;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Contact"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Contact"/> instance.</value>
		public Entities.Contact Contact
		{
			get {return this._Contact;}
			set
			{
				this._Contact = value;
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
			this.uxContactId.DataBindings.Clear();
			this.uxContactId.DataBindings.Add("Text", this.uxBindingSource, "ContactId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxNameStyle.DataBindings.Clear();
			this.uxNameStyle.DataBindings.Add("Checked", this.uxBindingSource, "NameStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTitle.DataBindings.Clear();
			this.uxTitle.DataBindings.Add("Text", this.uxBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFirstName.DataBindings.Clear();
			this.uxFirstName.DataBindings.Add("Text", this.uxBindingSource, "FirstName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMiddleName.DataBindings.Clear();
			this.uxMiddleName.DataBindings.Add("Text", this.uxBindingSource, "MiddleName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLastName.DataBindings.Clear();
			this.uxLastName.DataBindings.Add("Text", this.uxBindingSource, "LastName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSuffix.DataBindings.Clear();
			this.uxSuffix.DataBindings.Add("Text", this.uxBindingSource, "Suffix", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmailAddress.DataBindings.Clear();
			this.uxEmailAddress.DataBindings.Add("Text", this.uxBindingSource, "EmailAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmailPromotion.DataBindings.Clear();
			this.uxEmailPromotion.DataBindings.Add("Text", this.uxBindingSource, "EmailPromotion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPhone.DataBindings.Clear();
			this.uxPhone.DataBindings.Add("Text", this.uxBindingSource, "Phone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPasswordHash.DataBindings.Clear();
			this.uxPasswordHash.DataBindings.Add("Text", this.uxBindingSource, "PasswordHash", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPasswordSalt.DataBindings.Clear();
			this.uxPasswordSalt.DataBindings.Add("Text", this.uxBindingSource, "PasswordSalt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAdditionalContactInfo.DataBindings.Clear();
			this.uxAdditionalContactInfo.DataBindings.Add("Text", this.uxBindingSource, "AdditionalContactInfo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ContactEditControlBase"/> class.
		/// </summary>
		public ContactEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Contact != null) _Contact.Validate();
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
			this.uxContactId = new System.Windows.Forms.TextBox();
			uxContactIdLabel = new System.Windows.Forms.Label();
			this.uxNameStyle = new System.Windows.Forms.CheckBox();
			uxNameStyleLabel = new System.Windows.Forms.Label();
			this.uxTitle = new System.Windows.Forms.TextBox();
			uxTitleLabel = new System.Windows.Forms.Label();
			this.uxFirstName = new System.Windows.Forms.TextBox();
			uxFirstNameLabel = new System.Windows.Forms.Label();
			this.uxMiddleName = new System.Windows.Forms.TextBox();
			uxMiddleNameLabel = new System.Windows.Forms.Label();
			this.uxLastName = new System.Windows.Forms.TextBox();
			uxLastNameLabel = new System.Windows.Forms.Label();
			this.uxSuffix = new System.Windows.Forms.TextBox();
			uxSuffixLabel = new System.Windows.Forms.Label();
			this.uxEmailAddress = new System.Windows.Forms.TextBox();
			uxEmailAddressLabel = new System.Windows.Forms.Label();
			this.uxEmailPromotion = new System.Windows.Forms.TextBox();
			uxEmailPromotionLabel = new System.Windows.Forms.Label();
			this.uxPhone = new System.Windows.Forms.TextBox();
			uxPhoneLabel = new System.Windows.Forms.Label();
			this.uxPasswordHash = new System.Windows.Forms.TextBox();
			uxPasswordHashLabel = new System.Windows.Forms.Label();
			this.uxPasswordSalt = new System.Windows.Forms.TextBox();
			uxPasswordSaltLabel = new System.Windows.Forms.Label();
			this.uxAdditionalContactInfo = new System.Windows.Forms.TextBox();
			uxAdditionalContactInfoLabel = new System.Windows.Forms.Label();
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
			// uxContactIdLabel
			//
			this.uxContactIdLabel.Name = "uxContactIdLabel";
			this.uxContactIdLabel.Text = "Contact Id:";
			this.uxContactIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxContactIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactIdLabel);			
			//
			// uxContactId
			//
			this.uxContactId.Name = "uxContactId";
            this.uxContactId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactId);
			this.uxContactId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxContactId);
			//
			// uxNameStyleLabel
			//
			this.uxNameStyleLabel.Name = "uxNameStyleLabel";
			this.uxNameStyleLabel.Text = "Name Style:";
			this.uxNameStyleLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxNameStyleLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameStyleLabel);			
			//
			// uxNameStyle
			//
			this.uxNameStyle.Name = "uxNameStyle";
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameStyle);
			this.uxNameStyle.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxNameStyle);
			//
			// uxTitleLabel
			//
			this.uxTitleLabel.Name = "uxTitleLabel";
			this.uxTitleLabel.Text = "Title:";
			this.uxTitleLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxTitleLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTitleLabel);			
			//
			// uxTitle
			//
			this.uxTitle.Name = "uxTitle";
			this.uxTitle.Width = 250;
			this.uxTitle.MaxLength = 8;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTitle);
			this.uxTitle.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxTitle);
			//
			// uxFirstNameLabel
			//
			this.uxFirstNameLabel.Name = "uxFirstNameLabel";
			this.uxFirstNameLabel.Text = "First Name:";
			this.uxFirstNameLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxFirstNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFirstNameLabel);			
			//
			// uxFirstName
			//
			this.uxFirstName.Name = "uxFirstName";
			this.uxFirstName.Width = 250;
			this.uxFirstName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxFirstName);
			this.uxFirstName.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxFirstName);
			//
			// uxMiddleNameLabel
			//
			this.uxMiddleNameLabel.Name = "uxMiddleNameLabel";
			this.uxMiddleNameLabel.Text = "Middle Name:";
			this.uxMiddleNameLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxMiddleNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMiddleNameLabel);			
			//
			// uxMiddleName
			//
			this.uxMiddleName.Name = "uxMiddleName";
			this.uxMiddleName.Width = 250;
			this.uxMiddleName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxMiddleName);
			this.uxMiddleName.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxMiddleName);
			//
			// uxLastNameLabel
			//
			this.uxLastNameLabel.Name = "uxLastNameLabel";
			this.uxLastNameLabel.Text = "Last Name:";
			this.uxLastNameLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxLastNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLastNameLabel);			
			//
			// uxLastName
			//
			this.uxLastName.Name = "uxLastName";
			this.uxLastName.Width = 250;
			this.uxLastName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLastName);
			this.uxLastName.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxLastName);
			//
			// uxSuffixLabel
			//
			this.uxSuffixLabel.Name = "uxSuffixLabel";
			this.uxSuffixLabel.Text = "Suffix:";
			this.uxSuffixLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxSuffixLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSuffixLabel);			
			//
			// uxSuffix
			//
			this.uxSuffix.Name = "uxSuffix";
			this.uxSuffix.Width = 250;
			this.uxSuffix.MaxLength = 10;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSuffix);
			this.uxSuffix.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxSuffix);
			//
			// uxEmailAddressLabel
			//
			this.uxEmailAddressLabel.Name = "uxEmailAddressLabel";
			this.uxEmailAddressLabel.Text = "Email Address:";
			this.uxEmailAddressLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxEmailAddressLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailAddressLabel);			
			//
			// uxEmailAddress
			//
			this.uxEmailAddress.Name = "uxEmailAddress";
			this.uxEmailAddress.Width = 250;
			this.uxEmailAddress.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailAddress);
			this.uxEmailAddress.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxEmailAddress);
			//
			// uxEmailPromotionLabel
			//
			this.uxEmailPromotionLabel.Name = "uxEmailPromotionLabel";
			this.uxEmailPromotionLabel.Text = "Email Promotion:";
			this.uxEmailPromotionLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxEmailPromotionLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailPromotionLabel);			
			//
			// uxEmailPromotion
			//
			this.uxEmailPromotion.Name = "uxEmailPromotion";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailPromotion);
			this.uxEmailPromotion.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxEmailPromotion);
			//
			// uxPhoneLabel
			//
			this.uxPhoneLabel.Name = "uxPhoneLabel";
			this.uxPhoneLabel.Text = "Phone:";
			this.uxPhoneLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxPhoneLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhoneLabel);			
			//
			// uxPhone
			//
			this.uxPhone.Name = "uxPhone";
			this.uxPhone.Width = 250;
			this.uxPhone.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhone);
			this.uxPhone.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxPhone);
			//
			// uxPasswordHashLabel
			//
			this.uxPasswordHashLabel.Name = "uxPasswordHashLabel";
			this.uxPasswordHashLabel.Text = "Password Hash:";
			this.uxPasswordHashLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxPasswordHashLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPasswordHashLabel);			
			//
			// uxPasswordHash
			//
			this.uxPasswordHash.Name = "uxPasswordHash";
			this.uxPasswordHash.Width = 250;
			this.uxPasswordHash.MaxLength = 128;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPasswordHash);
			this.uxPasswordHash.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxPasswordHash);
			//
			// uxPasswordSaltLabel
			//
			this.uxPasswordSaltLabel.Name = "uxPasswordSaltLabel";
			this.uxPasswordSaltLabel.Text = "Password Salt:";
			this.uxPasswordSaltLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxPasswordSaltLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPasswordSaltLabel);			
			//
			// uxPasswordSalt
			//
			this.uxPasswordSalt.Name = "uxPasswordSalt";
			this.uxPasswordSalt.Width = 250;
			this.uxPasswordSalt.MaxLength = 10;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPasswordSalt);
			this.uxPasswordSalt.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxPasswordSalt);
			//
			// uxAdditionalContactInfoLabel
			//
			this.uxAdditionalContactInfoLabel.Name = "uxAdditionalContactInfoLabel";
			this.uxAdditionalContactInfoLabel.Text = "Additional Contact Info:";
			this.uxAdditionalContactInfoLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxAdditionalContactInfoLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAdditionalContactInfoLabel);			
			//
			// uxAdditionalContactInfo
			//
			this.uxAdditionalContactInfo.Name = "uxAdditionalContactInfo";
			//this.uxTableLayoutPanel.Controls.Add(this.uxAdditionalContactInfo);
			this.uxAdditionalContactInfo.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxAdditionalContactInfo);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 338);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 338);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 364);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 364);
			this.Controls.Add(this.uxModifiedDate);
			// 
			// ContactEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ContactEditControlBase";
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
        /// Indicates if the controls associated with the uxNameStyle property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNameStyleVisible
        {
            get { return this.uxNameStyle.Visible; }
            set
            {
                this.uxNameStyleLabel.Visible = value;
                this.uxNameStyle.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxNameStyle property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNameStyleEnabled
        {
            get { return this.uxNameStyle.Enabled; }
            set
            {
                this.uxNameStyle.Enabled = value;
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
        /// Indicates if the controls associated with the uxFirstName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFirstNameVisible
        {
            get { return this.uxFirstName.Visible; }
            set
            {
                this.uxFirstNameLabel.Visible = value;
                this.uxFirstName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFirstName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFirstNameEnabled
        {
            get { return this.uxFirstName.Enabled; }
            set
            {
                this.uxFirstName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxMiddleName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxMiddleNameVisible
        {
            get { return this.uxMiddleName.Visible; }
            set
            {
                this.uxMiddleNameLabel.Visible = value;
                this.uxMiddleName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxMiddleName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxMiddleNameEnabled
        {
            get { return this.uxMiddleName.Enabled; }
            set
            {
                this.uxMiddleName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLastName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLastNameVisible
        {
            get { return this.uxLastName.Visible; }
            set
            {
                this.uxLastNameLabel.Visible = value;
                this.uxLastName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLastName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLastNameEnabled
        {
            get { return this.uxLastName.Enabled; }
            set
            {
                this.uxLastName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSuffix property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSuffixVisible
        {
            get { return this.uxSuffix.Visible; }
            set
            {
                this.uxSuffixLabel.Visible = value;
                this.uxSuffix.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSuffix property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSuffixEnabled
        {
            get { return this.uxSuffix.Enabled; }
            set
            {
                this.uxSuffix.Enabled = value;
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
        /// Indicates if the controls associated with the uxEmailPromotion property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEmailPromotionVisible
        {
            get { return this.uxEmailPromotion.Visible; }
            set
            {
                this.uxEmailPromotionLabel.Visible = value;
                this.uxEmailPromotion.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEmailPromotion property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEmailPromotionEnabled
        {
            get { return this.uxEmailPromotion.Enabled; }
            set
            {
                this.uxEmailPromotion.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPhone property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPhoneVisible
        {
            get { return this.uxPhone.Visible; }
            set
            {
                this.uxPhoneLabel.Visible = value;
                this.uxPhone.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPhone property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPhoneEnabled
        {
            get { return this.uxPhone.Enabled; }
            set
            {
                this.uxPhone.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPasswordHash property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPasswordHashVisible
        {
            get { return this.uxPasswordHash.Visible; }
            set
            {
                this.uxPasswordHashLabel.Visible = value;
                this.uxPasswordHash.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPasswordHash property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPasswordHashEnabled
        {
            get { return this.uxPasswordHash.Enabled; }
            set
            {
                this.uxPasswordHash.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPasswordSalt property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPasswordSaltVisible
        {
            get { return this.uxPasswordSalt.Visible; }
            set
            {
                this.uxPasswordSaltLabel.Visible = value;
                this.uxPasswordSalt.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPasswordSalt property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPasswordSaltEnabled
        {
            get { return this.uxPasswordSalt.Enabled; }
            set
            {
                this.uxPasswordSalt.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAdditionalContactInfo property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAdditionalContactInfoVisible
        {
            get { return this.uxAdditionalContactInfo.Visible; }
            set
            {
                this.uxAdditionalContactInfoLabel.Visible = value;
                this.uxAdditionalContactInfo.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAdditionalContactInfo property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAdditionalContactInfoEnabled
        {
            get { return this.uxAdditionalContactInfo.Enabled; }
            set
            {
                this.uxAdditionalContactInfo.Enabled = value;
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
