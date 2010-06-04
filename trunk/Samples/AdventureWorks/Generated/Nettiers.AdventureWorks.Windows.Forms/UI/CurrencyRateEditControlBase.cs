
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.CurrencyRate"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CurrencyRateEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the CurrencyRateId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCurrencyRateId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CurrencyRateId property.
		/// </summary>
		protected System.Windows.Forms.Label uxCurrencyRateIdLabel;
		
		/// <summary>
		/// DataTimePicker for the CurrencyRateDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxCurrencyRateDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CurrencyRateDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxCurrencyRateDateLabel;
		
		/// <summary>
		/// ComboBox for the FromCurrencyCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxFromCurrencyCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the FromCurrencyCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxFromCurrencyCodeLabel;
		
		/// <summary>
		/// ComboBox for the ToCurrencyCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxToCurrencyCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ToCurrencyCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxToCurrencyCodeLabel;
		
		/// <summary>
		/// TextBox for the AverageRate property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAverageRate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AverageRate property.
		/// </summary>
		protected System.Windows.Forms.Label uxAverageRateLabel;
		
		/// <summary>
		/// TextBox for the EndOfDayRate property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEndOfDayRate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EndOfDayRate property.
		/// </summary>
		protected System.Windows.Forms.Label uxEndOfDayRateLabel;
		
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
		private Entities.CurrencyRate _CurrencyRate;
		/// <summary>
		/// Gets or sets the <see cref="Entities.CurrencyRate"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.CurrencyRate"/> instance.</value>
		public Entities.CurrencyRate CurrencyRate
		{
			get {return this._CurrencyRate;}
			set
			{
				this._CurrencyRate = value;
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
			this.uxCurrencyRateId.DataBindings.Clear();
			this.uxCurrencyRateId.DataBindings.Add("Text", this.uxBindingSource, "CurrencyRateId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCurrencyRateDate.DataBindings.Clear();
			this.uxCurrencyRateDate.DataBindings.Add("Value", this.uxBindingSource, "CurrencyRateDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFromCurrencyCode.DataBindings.Clear();
			this.uxFromCurrencyCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "FromCurrencyCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxToCurrencyCode.DataBindings.Clear();
			this.uxToCurrencyCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "ToCurrencyCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAverageRate.DataBindings.Clear();
			this.uxAverageRate.DataBindings.Add("Text", this.uxBindingSource, "AverageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEndOfDayRate.DataBindings.Clear();
			this.uxEndOfDayRate.DataBindings.Add("Text", this.uxBindingSource, "EndOfDayRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CurrencyRateEditControlBase"/> class.
		/// </summary>
		public CurrencyRateEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_CurrencyRate != null) _CurrencyRate.Validate();
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
			this.uxCurrencyRateId = new System.Windows.Forms.TextBox();
			uxCurrencyRateIdLabel = new System.Windows.Forms.Label();
			this.uxCurrencyRateDate = new System.Windows.Forms.DateTimePicker();
			uxCurrencyRateDateLabel = new System.Windows.Forms.Label();
			this.uxFromCurrencyCode = new System.Windows.Forms.ComboBox();
			uxFromCurrencyCodeLabel = new System.Windows.Forms.Label();
			this.uxToCurrencyCode = new System.Windows.Forms.ComboBox();
			uxToCurrencyCodeLabel = new System.Windows.Forms.Label();
			this.uxAverageRate = new System.Windows.Forms.TextBox();
			uxAverageRateLabel = new System.Windows.Forms.Label();
			this.uxEndOfDayRate = new System.Windows.Forms.TextBox();
			uxEndOfDayRateLabel = new System.Windows.Forms.Label();
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
			// uxCurrencyRateIdLabel
			//
			this.uxCurrencyRateIdLabel.Name = "uxCurrencyRateIdLabel";
			this.uxCurrencyRateIdLabel.Text = "Currency Rate Id:";
			this.uxCurrencyRateIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxCurrencyRateIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrencyRateIdLabel);			
			//
			// uxCurrencyRateId
			//
			this.uxCurrencyRateId.Name = "uxCurrencyRateId";
            this.uxCurrencyRateId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrencyRateId);
			this.uxCurrencyRateId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxCurrencyRateId);
			//
			// uxCurrencyRateDateLabel
			//
			this.uxCurrencyRateDateLabel.Name = "uxCurrencyRateDateLabel";
			this.uxCurrencyRateDateLabel.Text = "Currency Rate Date:";
			this.uxCurrencyRateDateLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxCurrencyRateDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrencyRateDateLabel);			
			//
			// uxCurrencyRateDate
			//
			this.uxCurrencyRateDate.Name = "uxCurrencyRateDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrencyRateDate);
			this.uxCurrencyRateDate.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxCurrencyRateDate);
			//
			// uxFromCurrencyCodeLabel
			//
			this.uxFromCurrencyCodeLabel.Name = "uxFromCurrencyCodeLabel";
			this.uxFromCurrencyCodeLabel.Text = "From Currency Code:";
			this.uxFromCurrencyCodeLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxFromCurrencyCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFromCurrencyCodeLabel);			
			//
			// uxFromCurrencyCode
			//
			this.uxFromCurrencyCode.Name = "uxFromCurrencyCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxFromCurrencyCode);
			this.uxFromCurrencyCode.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxFromCurrencyCode);
			//
			// uxToCurrencyCodeLabel
			//
			this.uxToCurrencyCodeLabel.Name = "uxToCurrencyCodeLabel";
			this.uxToCurrencyCodeLabel.Text = "To Currency Code:";
			this.uxToCurrencyCodeLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxToCurrencyCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxToCurrencyCodeLabel);			
			//
			// uxToCurrencyCode
			//
			this.uxToCurrencyCode.Name = "uxToCurrencyCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxToCurrencyCode);
			this.uxToCurrencyCode.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxToCurrencyCode);
			//
			// uxAverageRateLabel
			//
			this.uxAverageRateLabel.Name = "uxAverageRateLabel";
			this.uxAverageRateLabel.Text = "Average Rate:";
			this.uxAverageRateLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxAverageRateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAverageRateLabel);			
			//
			// uxAverageRate
			//
			this.uxAverageRate.Name = "uxAverageRate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxAverageRate);
			this.uxAverageRate.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxAverageRate);
			//
			// uxEndOfDayRateLabel
			//
			this.uxEndOfDayRateLabel.Name = "uxEndOfDayRateLabel";
			this.uxEndOfDayRateLabel.Text = "End Of Day Rate:";
			this.uxEndOfDayRateLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxEndOfDayRateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEndOfDayRateLabel);			
			//
			// uxEndOfDayRate
			//
			this.uxEndOfDayRate.Name = "uxEndOfDayRate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEndOfDayRate);
			this.uxEndOfDayRate.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxEndOfDayRate);
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
			// uxFromCurrencyCode
			//				
			this.uxFromCurrencyCode.DisplayMember = "Name";	
			this.uxFromCurrencyCode.ValueMember = "CurrencyCode";	
			//
			// uxToCurrencyCode
			//				
			this.uxToCurrencyCode.DisplayMember = "Name";	
			this.uxToCurrencyCode.ValueMember = "CurrencyCode";	
			// 
			// CurrencyRateEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "CurrencyRateEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Currency> _FromCurrencyCodeList;
		
		/// <summary>
		/// The ComboBox associated with the FromCurrencyCode property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Currency> FromCurrencyCodeList
		{
			get {return _FromCurrencyCodeList;}
			set 
			{
				this._FromCurrencyCodeList = value;
				this.uxFromCurrencyCode.DataSource = null;
				this.uxFromCurrencyCode.DataSource = value;
			}
		}
		
		private bool _allowNewItemInFromCurrencyCodeList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the FromCurrencyCode property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInFromCurrencyCodeList
		{
			get { return _allowNewItemInFromCurrencyCodeList;}
			set
			{
				this._allowNewItemInFromCurrencyCodeList = value;
				this.uxFromCurrencyCode.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Currency> _ToCurrencyCodeList;
		
		/// <summary>
		/// The ComboBox associated with the ToCurrencyCode property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Currency> ToCurrencyCodeList
		{
			get {return _ToCurrencyCodeList;}
			set 
			{
				this._ToCurrencyCodeList = value;
				this.uxToCurrencyCode.DataSource = null;
				this.uxToCurrencyCode.DataSource = value;
			}
		}
		
		private bool _allowNewItemInToCurrencyCodeList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ToCurrencyCode property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInToCurrencyCodeList
		{
			get { return _allowNewItemInToCurrencyCodeList;}
			set
			{
				this._allowNewItemInToCurrencyCodeList = value;
				this.uxToCurrencyCode.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxCurrencyRateId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCurrencyRateIdVisible
        {
            get { return this.uxCurrencyRateId.Visible; }
            set
            {
                this.uxCurrencyRateIdLabel.Visible = value;
                this.uxCurrencyRateId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCurrencyRateId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCurrencyRateIdEnabled
        {
            get { return this.uxCurrencyRateId.Enabled; }
            set
            {
                this.uxCurrencyRateId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCurrencyRateDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCurrencyRateDateVisible
        {
            get { return this.uxCurrencyRateDate.Visible; }
            set
            {
                this.uxCurrencyRateDateLabel.Visible = value;
                this.uxCurrencyRateDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCurrencyRateDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCurrencyRateDateEnabled
        {
            get { return this.uxCurrencyRateDate.Enabled; }
            set
            {
                this.uxCurrencyRateDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFromCurrencyCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFromCurrencyCodeVisible
        {
            get { return this.uxFromCurrencyCode.Visible; }
            set
            {
                this.uxFromCurrencyCodeLabel.Visible = value;
                this.uxFromCurrencyCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFromCurrencyCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFromCurrencyCodeEnabled
        {
            get { return this.uxFromCurrencyCode.Enabled; }
            set
            {
                this.uxFromCurrencyCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxToCurrencyCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxToCurrencyCodeVisible
        {
            get { return this.uxToCurrencyCode.Visible; }
            set
            {
                this.uxToCurrencyCodeLabel.Visible = value;
                this.uxToCurrencyCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxToCurrencyCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxToCurrencyCodeEnabled
        {
            get { return this.uxToCurrencyCode.Enabled; }
            set
            {
                this.uxToCurrencyCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAverageRate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAverageRateVisible
        {
            get { return this.uxAverageRate.Visible; }
            set
            {
                this.uxAverageRateLabel.Visible = value;
                this.uxAverageRate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAverageRate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAverageRateEnabled
        {
            get { return this.uxAverageRate.Enabled; }
            set
            {
                this.uxAverageRate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEndOfDayRate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEndOfDayRateVisible
        {
            get { return this.uxEndOfDayRate.Visible; }
            set
            {
                this.uxEndOfDayRateLabel.Visible = value;
                this.uxEndOfDayRate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEndOfDayRate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEndOfDayRateEnabled
        {
            get { return this.uxEndOfDayRate.Enabled; }
            set
            {
                this.uxEndOfDayRate.Enabled = value;
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
