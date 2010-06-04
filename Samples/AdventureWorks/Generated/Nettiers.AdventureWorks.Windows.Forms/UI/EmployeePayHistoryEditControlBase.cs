
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.EmployeePayHistory"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class EmployeePayHistoryEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxEmployeeId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmployeeIdLabel;
		
		/// <summary>
		/// DataTimePicker for the RateChangeDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxRateChangeDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the RateChangeDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxRateChangeDateLabel;
		
		/// <summary>
		/// TextBox for the Rate property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Rate property.
		/// </summary>
		protected System.Windows.Forms.Label uxRateLabel;
		
		/// <summary>
		/// TextBox for the PayFrequency property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPayFrequency;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PayFrequency property.
		/// </summary>
		protected System.Windows.Forms.Label uxPayFrequencyLabel;
		
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
		private Entities.EmployeePayHistory _EmployeePayHistory;
		/// <summary>
		/// Gets or sets the <see cref="Entities.EmployeePayHistory"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.EmployeePayHistory"/> instance.</value>
		public Entities.EmployeePayHistory EmployeePayHistory
		{
			get {return this._EmployeePayHistory;}
			set
			{
				this._EmployeePayHistory = value;
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
			this.uxEmployeeId.DataBindings.Clear();
			this.uxEmployeeId.DataBindings.Add("SelectedValue", this.uxBindingSource, "EmployeeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRateChangeDate.DataBindings.Clear();
			this.uxRateChangeDate.DataBindings.Add("Value", this.uxBindingSource, "RateChangeDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRate.DataBindings.Clear();
			this.uxRate.DataBindings.Add("Text", this.uxBindingSource, "Rate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPayFrequency.DataBindings.Clear();
			this.uxPayFrequency.DataBindings.Add("Text", this.uxBindingSource, "PayFrequency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeePayHistoryEditControlBase"/> class.
		/// </summary>
		public EmployeePayHistoryEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_EmployeePayHistory != null) _EmployeePayHistory.Validate();
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
			this.uxEmployeeId = new System.Windows.Forms.ComboBox();
			uxEmployeeIdLabel = new System.Windows.Forms.Label();
			this.uxRateChangeDate = new System.Windows.Forms.DateTimePicker();
			uxRateChangeDateLabel = new System.Windows.Forms.Label();
			this.uxRate = new System.Windows.Forms.TextBox();
			uxRateLabel = new System.Windows.Forms.Label();
			this.uxPayFrequency = new System.Windows.Forms.TextBox();
			uxPayFrequencyLabel = new System.Windows.Forms.Label();
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
			// uxEmployeeIdLabel
			//
			this.uxEmployeeIdLabel.Name = "uxEmployeeIdLabel";
			this.uxEmployeeIdLabel.Text = "Employee Id:";
			this.uxEmployeeIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxEmployeeIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeIdLabel);			
			//
			// uxEmployeeId
			//
			this.uxEmployeeId.Name = "uxEmployeeId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeId);
			this.uxEmployeeId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxEmployeeId);
			//
			// uxRateChangeDateLabel
			//
			this.uxRateChangeDateLabel.Name = "uxRateChangeDateLabel";
			this.uxRateChangeDateLabel.Text = "Rate Change Date:";
			this.uxRateChangeDateLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxRateChangeDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRateChangeDateLabel);			
			//
			// uxRateChangeDate
			//
			this.uxRateChangeDate.Name = "uxRateChangeDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxRateChangeDate);
			this.uxRateChangeDate.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxRateChangeDate);
			//
			// uxRateLabel
			//
			this.uxRateLabel.Name = "uxRateLabel";
			this.uxRateLabel.Text = "Rate:";
			this.uxRateLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxRateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRateLabel);			
			//
			// uxRate
			//
			this.uxRate.Name = "uxRate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxRate);
			this.uxRate.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxRate);
			//
			// uxPayFrequencyLabel
			//
			this.uxPayFrequencyLabel.Name = "uxPayFrequencyLabel";
			this.uxPayFrequencyLabel.Text = "Pay Frequency:";
			this.uxPayFrequencyLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxPayFrequencyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPayFrequencyLabel);			
			//
			// uxPayFrequency
			//
			this.uxPayFrequency.Name = "uxPayFrequency";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPayFrequency);
			this.uxPayFrequency.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxPayFrequency);
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
			// uxEmployeeId
			//				
			this.uxEmployeeId.DisplayMember = "NationalIdNumber";	
			this.uxEmployeeId.ValueMember = "EmployeeId";	
			// 
			// EmployeePayHistoryEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "EmployeePayHistoryEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Employee> _EmployeeIdList;
		
		/// <summary>
		/// The ComboBox associated with the EmployeeId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Employee> EmployeeIdList
		{
			get {return _EmployeeIdList;}
			set 
			{
				this._EmployeeIdList = value;
				this.uxEmployeeId.DataSource = null;
				this.uxEmployeeId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInEmployeeIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the EmployeeId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInEmployeeIdList
		{
			get { return _allowNewItemInEmployeeIdList;}
			set
			{
				this._allowNewItemInEmployeeIdList = value;
				this.uxEmployeeId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEmployeeIdVisible
        {
            get { return this.uxEmployeeId.Visible; }
            set
            {
                this.uxEmployeeIdLabel.Visible = value;
                this.uxEmployeeId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEmployeeIdEnabled
        {
            get { return this.uxEmployeeId.Enabled; }
            set
            {
                this.uxEmployeeId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRateChangeDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRateChangeDateVisible
        {
            get { return this.uxRateChangeDate.Visible; }
            set
            {
                this.uxRateChangeDateLabel.Visible = value;
                this.uxRateChangeDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRateChangeDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRateChangeDateEnabled
        {
            get { return this.uxRateChangeDate.Enabled; }
            set
            {
                this.uxRateChangeDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRateVisible
        {
            get { return this.uxRate.Visible; }
            set
            {
                this.uxRateLabel.Visible = value;
                this.uxRate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRateEnabled
        {
            get { return this.uxRate.Enabled; }
            set
            {
                this.uxRate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPayFrequency property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPayFrequencyVisible
        {
            get { return this.uxPayFrequency.Visible; }
            set
            {
                this.uxPayFrequencyLabel.Visible = value;
                this.uxPayFrequency.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPayFrequency property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPayFrequencyEnabled
        {
            get { return this.uxPayFrequency.Enabled; }
            set
            {
                this.uxPayFrequency.Enabled = value;
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
