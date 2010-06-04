
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.CreditCard"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CreditCardEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the CreditCardId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCreditCardId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreditCardId property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreditCardIdLabel;
		
		/// <summary>
		/// TextBox for the CardType property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCardType;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CardType property.
		/// </summary>
		protected System.Windows.Forms.Label uxCardTypeLabel;
		
		/// <summary>
		/// TextBox for the CardNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCardNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CardNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxCardNumberLabel;
		
		/// <summary>
		/// TextBox for the ExpMonth property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxExpMonth;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ExpMonth property.
		/// </summary>
		protected System.Windows.Forms.Label uxExpMonthLabel;
		
		/// <summary>
		/// TextBox for the ExpYear property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxExpYear;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ExpYear property.
		/// </summary>
		protected System.Windows.Forms.Label uxExpYearLabel;
		
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
		private Entities.CreditCard _CreditCard;
		/// <summary>
		/// Gets or sets the <see cref="Entities.CreditCard"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.CreditCard"/> instance.</value>
		public Entities.CreditCard CreditCard
		{
			get {return this._CreditCard;}
			set
			{
				this._CreditCard = value;
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
			this.uxCreditCardId.DataBindings.Clear();
			this.uxCreditCardId.DataBindings.Add("Text", this.uxBindingSource, "CreditCardId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCardType.DataBindings.Clear();
			this.uxCardType.DataBindings.Add("Text", this.uxBindingSource, "CardType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCardNumber.DataBindings.Clear();
			this.uxCardNumber.DataBindings.Add("Text", this.uxBindingSource, "CardNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxExpMonth.DataBindings.Clear();
			this.uxExpMonth.DataBindings.Add("Text", this.uxBindingSource, "ExpMonth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxExpYear.DataBindings.Clear();
			this.uxExpYear.DataBindings.Add("Text", this.uxBindingSource, "ExpYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCardEditControlBase"/> class.
		/// </summary>
		public CreditCardEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_CreditCard != null) _CreditCard.Validate();
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
			this.uxCreditCardId = new System.Windows.Forms.TextBox();
			uxCreditCardIdLabel = new System.Windows.Forms.Label();
			this.uxCardType = new System.Windows.Forms.TextBox();
			uxCardTypeLabel = new System.Windows.Forms.Label();
			this.uxCardNumber = new System.Windows.Forms.TextBox();
			uxCardNumberLabel = new System.Windows.Forms.Label();
			this.uxExpMonth = new System.Windows.Forms.TextBox();
			uxExpMonthLabel = new System.Windows.Forms.Label();
			this.uxExpYear = new System.Windows.Forms.TextBox();
			uxExpYearLabel = new System.Windows.Forms.Label();
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
			// uxCreditCardIdLabel
			//
			this.uxCreditCardIdLabel.Name = "uxCreditCardIdLabel";
			this.uxCreditCardIdLabel.Text = "Credit Card Id:";
			this.uxCreditCardIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxCreditCardIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditCardIdLabel);			
			//
			// uxCreditCardId
			//
			this.uxCreditCardId.Name = "uxCreditCardId";
            this.uxCreditCardId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreditCardId);
			this.uxCreditCardId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxCreditCardId);
			//
			// uxCardTypeLabel
			//
			this.uxCardTypeLabel.Name = "uxCardTypeLabel";
			this.uxCardTypeLabel.Text = "Card Type:";
			this.uxCardTypeLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxCardTypeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCardTypeLabel);			
			//
			// uxCardType
			//
			this.uxCardType.Name = "uxCardType";
			this.uxCardType.Width = 250;
			this.uxCardType.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCardType);
			this.uxCardType.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxCardType);
			//
			// uxCardNumberLabel
			//
			this.uxCardNumberLabel.Name = "uxCardNumberLabel";
			this.uxCardNumberLabel.Text = "Card Number:";
			this.uxCardNumberLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxCardNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCardNumberLabel);			
			//
			// uxCardNumber
			//
			this.uxCardNumber.Name = "uxCardNumber";
			this.uxCardNumber.Width = 250;
			this.uxCardNumber.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCardNumber);
			this.uxCardNumber.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxCardNumber);
			//
			// uxExpMonthLabel
			//
			this.uxExpMonthLabel.Name = "uxExpMonthLabel";
			this.uxExpMonthLabel.Text = "Exp Month:";
			this.uxExpMonthLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxExpMonthLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxExpMonthLabel);			
			//
			// uxExpMonth
			//
			this.uxExpMonth.Name = "uxExpMonth";
			//this.uxTableLayoutPanel.Controls.Add(this.uxExpMonth);
			this.uxExpMonth.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxExpMonth);
			//
			// uxExpYearLabel
			//
			this.uxExpYearLabel.Name = "uxExpYearLabel";
			this.uxExpYearLabel.Text = "Exp Year:";
			this.uxExpYearLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxExpYearLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxExpYearLabel);			
			//
			// uxExpYear
			//
			this.uxExpYear.Name = "uxExpYear";
			//this.uxTableLayoutPanel.Controls.Add(this.uxExpYear);
			this.uxExpYear.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxExpYear);
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
			// CreditCardEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "CreditCardEditControlBase";
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
        /// Indicates if the controls associated with the uxCardType property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCardTypeVisible
        {
            get { return this.uxCardType.Visible; }
            set
            {
                this.uxCardTypeLabel.Visible = value;
                this.uxCardType.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCardType property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCardTypeEnabled
        {
            get { return this.uxCardType.Enabled; }
            set
            {
                this.uxCardType.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCardNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCardNumberVisible
        {
            get { return this.uxCardNumber.Visible; }
            set
            {
                this.uxCardNumberLabel.Visible = value;
                this.uxCardNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCardNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCardNumberEnabled
        {
            get { return this.uxCardNumber.Enabled; }
            set
            {
                this.uxCardNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxExpMonth property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxExpMonthVisible
        {
            get { return this.uxExpMonth.Visible; }
            set
            {
                this.uxExpMonthLabel.Visible = value;
                this.uxExpMonth.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxExpMonth property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxExpMonthEnabled
        {
            get { return this.uxExpMonth.Enabled; }
            set
            {
                this.uxExpMonth.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxExpYear property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxExpYearVisible
        {
            get { return this.uxExpYear.Visible; }
            set
            {
                this.uxExpYearLabel.Visible = value;
                this.uxExpYear.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxExpYear property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxExpYearEnabled
        {
            get { return this.uxExpYear.Enabled; }
            set
            {
                this.uxExpYear.Enabled = value;
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
