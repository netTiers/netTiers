
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ContactCreditCard"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ContactCreditCardEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the ContactId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxContactId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ContactId property.
		/// </summary>
		protected System.Windows.Forms.Label uxContactIdLabel;
		
		/// <summary>
		/// ComboBox for the CreditCardId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxCreditCardId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreditCardId property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreditCardIdLabel;
		
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
		private Entities.ContactCreditCard _ContactCreditCard;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ContactCreditCard"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ContactCreditCard"/> instance.</value>
		public Entities.ContactCreditCard ContactCreditCard
		{
			get {return this._ContactCreditCard;}
			set
			{
				this._ContactCreditCard = value;
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
			this.uxContactId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ContactId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCreditCardId.DataBindings.Clear();
			this.uxCreditCardId.DataBindings.Add("SelectedValue", this.uxBindingSource, "CreditCardId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ContactCreditCardEditControlBase"/> class.
		/// </summary>
		public ContactCreditCardEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ContactCreditCard != null) _ContactCreditCard.Validate();
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
			this.uxContactId = new System.Windows.Forms.ComboBox();
			uxContactIdLabel = new System.Windows.Forms.Label();
			this.uxCreditCardId = new System.Windows.Forms.ComboBox();
			uxCreditCardIdLabel = new System.Windows.Forms.Label();
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
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactId);
			this.uxContactId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxContactId);
			//
			// uxCreditCardIdLabel
			//
			this.uxCreditCardIdLabel.Name = "uxCreditCardIdLabel";
			this.uxCreditCardIdLabel.Text = "Credit Card Id:";
			this.uxCreditCardIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxCreditCardIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditCardIdLabel);			
			//
			// uxCreditCardId
			//
			this.uxCreditCardId.Name = "uxCreditCardId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditCardId);
			this.uxCreditCardId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxCreditCardId);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxContactId
			//				
			this.uxContactId.DisplayMember = "NameStyle";	
			this.uxContactId.ValueMember = "ContactId";	
			//
			// uxCreditCardId
			//				
			this.uxCreditCardId.DisplayMember = "CardType";	
			this.uxCreditCardId.ValueMember = "CreditCardId";	
			// 
			// ContactCreditCardEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ContactCreditCardEditControlBase";
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
		
				
		private Entities.TList<Entities.CreditCard> _CreditCardIdList;
		
		/// <summary>
		/// The ComboBox associated with the CreditCardId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.CreditCard> CreditCardIdList
		{
			get {return _CreditCardIdList;}
			set 
			{
				this._CreditCardIdList = value;
				this.uxCreditCardId.DataSource = null;
				this.uxCreditCardId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInCreditCardIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the CreditCardId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCreditCardIdList
		{
			get { return _allowNewItemInCreditCardIdList;}
			set
			{
				this._allowNewItemInCreditCardIdList = value;
				this.uxCreditCardId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
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
        /// Indicates if the controls associated with the uxCreditCardId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCreditCardIdVisible
        {
            get { return this.uxCreditCardId.Visible; }
            set
            {
                this.uxCreditCardIdLabel.Visible = value;
                this.uxCreditCardId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCreditCardId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCreditCardIdEnabled
        {
            get { return this.uxCreditCardId.Enabled; }
            set
            {
                this.uxCreditCardId.Enabled = value;
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
