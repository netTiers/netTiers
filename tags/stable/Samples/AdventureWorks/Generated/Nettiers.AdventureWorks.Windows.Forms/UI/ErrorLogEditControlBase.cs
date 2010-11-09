
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ErrorLog"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ErrorLogEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the ErrorLogId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxErrorLogId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ErrorLogId property.
		/// </summary>
		protected System.Windows.Forms.Label uxErrorLogIdLabel;
		
		/// <summary>
		/// DataTimePicker for the ErrorTime property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxErrorTime;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ErrorTime property.
		/// </summary>
		protected System.Windows.Forms.Label uxErrorTimeLabel;
		
		/// <summary>
		/// TextBox for the UserName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUserName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UserName property.
		/// </summary>
		protected System.Windows.Forms.Label uxUserNameLabel;
		
		/// <summary>
		/// TextBox for the ErrorNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxErrorNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ErrorNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxErrorNumberLabel;
		
		/// <summary>
		/// TextBox for the ErrorSeverity property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxErrorSeverity;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ErrorSeverity property.
		/// </summary>
		protected System.Windows.Forms.Label uxErrorSeverityLabel;
		
		/// <summary>
		/// TextBox for the ErrorState property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxErrorState;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ErrorState property.
		/// </summary>
		protected System.Windows.Forms.Label uxErrorStateLabel;
		
		/// <summary>
		/// TextBox for the ErrorProcedure property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxErrorProcedure;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ErrorProcedure property.
		/// </summary>
		protected System.Windows.Forms.Label uxErrorProcedureLabel;
		
		/// <summary>
		/// TextBox for the ErrorLine property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxErrorLine;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ErrorLine property.
		/// </summary>
		protected System.Windows.Forms.Label uxErrorLineLabel;
		
		/// <summary>
		/// TextBox for the ErrorMessage property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxErrorMessage;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ErrorMessage property.
		/// </summary>
		protected System.Windows.Forms.Label uxErrorMessageLabel;
		#endregion
		
		#region Main entity
		private Entities.ErrorLog _ErrorLog;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ErrorLog"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ErrorLog"/> instance.</value>
		public Entities.ErrorLog ErrorLog
		{
			get {return this._ErrorLog;}
			set
			{
				this._ErrorLog = value;
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
			this.uxErrorLogId.DataBindings.Clear();
			this.uxErrorLogId.DataBindings.Add("Text", this.uxBindingSource, "ErrorLogId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxErrorTime.DataBindings.Clear();
			this.uxErrorTime.DataBindings.Add("Value", this.uxBindingSource, "ErrorTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUserName.DataBindings.Clear();
			this.uxUserName.DataBindings.Add("Text", this.uxBindingSource, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxErrorNumber.DataBindings.Clear();
			this.uxErrorNumber.DataBindings.Add("Text", this.uxBindingSource, "ErrorNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxErrorSeverity.DataBindings.Clear();
			this.uxErrorSeverity.DataBindings.Add("Text", this.uxBindingSource, "ErrorSeverity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxErrorState.DataBindings.Clear();
			this.uxErrorState.DataBindings.Add("Text", this.uxBindingSource, "ErrorState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxErrorProcedure.DataBindings.Clear();
			this.uxErrorProcedure.DataBindings.Add("Text", this.uxBindingSource, "ErrorProcedure", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxErrorLine.DataBindings.Clear();
			this.uxErrorLine.DataBindings.Add("Text", this.uxBindingSource, "ErrorLine", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxErrorMessage.DataBindings.Clear();
			this.uxErrorMessage.DataBindings.Add("Text", this.uxBindingSource, "ErrorMessage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorLogEditControlBase"/> class.
		/// </summary>
		public ErrorLogEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ErrorLog != null) _ErrorLog.Validate();
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
			this.uxErrorLogId = new System.Windows.Forms.TextBox();
			uxErrorLogIdLabel = new System.Windows.Forms.Label();
			this.uxErrorTime = new System.Windows.Forms.DateTimePicker();
			uxErrorTimeLabel = new System.Windows.Forms.Label();
			this.uxUserName = new System.Windows.Forms.TextBox();
			uxUserNameLabel = new System.Windows.Forms.Label();
			this.uxErrorNumber = new System.Windows.Forms.TextBox();
			uxErrorNumberLabel = new System.Windows.Forms.Label();
			this.uxErrorSeverity = new System.Windows.Forms.TextBox();
			uxErrorSeverityLabel = new System.Windows.Forms.Label();
			this.uxErrorState = new System.Windows.Forms.TextBox();
			uxErrorStateLabel = new System.Windows.Forms.Label();
			this.uxErrorProcedure = new System.Windows.Forms.TextBox();
			uxErrorProcedureLabel = new System.Windows.Forms.Label();
			this.uxErrorLine = new System.Windows.Forms.TextBox();
			uxErrorLineLabel = new System.Windows.Forms.Label();
			this.uxErrorMessage = new System.Windows.Forms.TextBox();
			uxErrorMessageLabel = new System.Windows.Forms.Label();
			
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
			// uxErrorLogIdLabel
			//
			this.uxErrorLogIdLabel.Name = "uxErrorLogIdLabel";
			this.uxErrorLogIdLabel.Text = "Error Log Id:";
			this.uxErrorLogIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxErrorLogIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorLogIdLabel);			
			//
			// uxErrorLogId
			//
			this.uxErrorLogId.Name = "uxErrorLogId";
            this.uxErrorLogId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorLogId);
			this.uxErrorLogId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxErrorLogId);
			//
			// uxErrorTimeLabel
			//
			this.uxErrorTimeLabel.Name = "uxErrorTimeLabel";
			this.uxErrorTimeLabel.Text = "Error Time:";
			this.uxErrorTimeLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxErrorTimeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorTimeLabel);			
			//
			// uxErrorTime
			//
			this.uxErrorTime.Name = "uxErrorTime";
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorTime);
			this.uxErrorTime.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxErrorTime);
			//
			// uxUserNameLabel
			//
			this.uxUserNameLabel.Name = "uxUserNameLabel";
			this.uxUserNameLabel.Text = "User Name:";
			this.uxUserNameLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxUserNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUserNameLabel);			
			//
			// uxUserName
			//
			this.uxUserName.Name = "uxUserName";
			this.uxUserName.Width = 250;
			this.uxUserName.MaxLength = 128;
			//this.uxTableLayoutPanel.Controls.Add(this.uxUserName);
			this.uxUserName.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxUserName);
			//
			// uxErrorNumberLabel
			//
			this.uxErrorNumberLabel.Name = "uxErrorNumberLabel";
			this.uxErrorNumberLabel.Text = "Error Number:";
			this.uxErrorNumberLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxErrorNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorNumberLabel);			
			//
			// uxErrorNumber
			//
			this.uxErrorNumber.Name = "uxErrorNumber";
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorNumber);
			this.uxErrorNumber.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxErrorNumber);
			//
			// uxErrorSeverityLabel
			//
			this.uxErrorSeverityLabel.Name = "uxErrorSeverityLabel";
			this.uxErrorSeverityLabel.Text = "Error Severity:";
			this.uxErrorSeverityLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxErrorSeverityLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorSeverityLabel);			
			//
			// uxErrorSeverity
			//
			this.uxErrorSeverity.Name = "uxErrorSeverity";
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorSeverity);
			this.uxErrorSeverity.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxErrorSeverity);
			//
			// uxErrorStateLabel
			//
			this.uxErrorStateLabel.Name = "uxErrorStateLabel";
			this.uxErrorStateLabel.Text = "Error State:";
			this.uxErrorStateLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxErrorStateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorStateLabel);			
			//
			// uxErrorState
			//
			this.uxErrorState.Name = "uxErrorState";
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorState);
			this.uxErrorState.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxErrorState);
			//
			// uxErrorProcedureLabel
			//
			this.uxErrorProcedureLabel.Name = "uxErrorProcedureLabel";
			this.uxErrorProcedureLabel.Text = "Error Procedure:";
			this.uxErrorProcedureLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxErrorProcedureLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorProcedureLabel);			
			//
			// uxErrorProcedure
			//
			this.uxErrorProcedure.Name = "uxErrorProcedure";
			this.uxErrorProcedure.Width = 250;
			this.uxErrorProcedure.MaxLength = 126;
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorProcedure);
			this.uxErrorProcedure.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxErrorProcedure);
			//
			// uxErrorLineLabel
			//
			this.uxErrorLineLabel.Name = "uxErrorLineLabel";
			this.uxErrorLineLabel.Text = "Error Line:";
			this.uxErrorLineLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxErrorLineLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorLineLabel);			
			//
			// uxErrorLine
			//
			this.uxErrorLine.Name = "uxErrorLine";
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorLine);
			this.uxErrorLine.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxErrorLine);
			//
			// uxErrorMessageLabel
			//
			this.uxErrorMessageLabel.Name = "uxErrorMessageLabel";
			this.uxErrorMessageLabel.Text = "Error Message:";
			this.uxErrorMessageLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxErrorMessageLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorMessageLabel);			
			//
			// uxErrorMessage
			//
			this.uxErrorMessage.Name = "uxErrorMessage";
			this.uxErrorMessage.Width = 250;
			this.uxErrorMessage.MaxLength = 4000;
			//this.uxTableLayoutPanel.Controls.Add(this.uxErrorMessage);
			this.uxErrorMessage.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxErrorMessage);
			// 
			// ErrorLogEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ErrorLogEditControlBase";
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
        /// Indicates if the controls associated with the uxErrorLogId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxErrorLogIdVisible
        {
            get { return this.uxErrorLogId.Visible; }
            set
            {
                this.uxErrorLogIdLabel.Visible = value;
                this.uxErrorLogId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxErrorLogId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxErrorLogIdEnabled
        {
            get { return this.uxErrorLogId.Enabled; }
            set
            {
                this.uxErrorLogId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxErrorTime property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxErrorTimeVisible
        {
            get { return this.uxErrorTime.Visible; }
            set
            {
                this.uxErrorTimeLabel.Visible = value;
                this.uxErrorTime.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxErrorTime property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxErrorTimeEnabled
        {
            get { return this.uxErrorTime.Enabled; }
            set
            {
                this.uxErrorTime.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUserName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUserNameVisible
        {
            get { return this.uxUserName.Visible; }
            set
            {
                this.uxUserNameLabel.Visible = value;
                this.uxUserName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUserName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUserNameEnabled
        {
            get { return this.uxUserName.Enabled; }
            set
            {
                this.uxUserName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxErrorNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxErrorNumberVisible
        {
            get { return this.uxErrorNumber.Visible; }
            set
            {
                this.uxErrorNumberLabel.Visible = value;
                this.uxErrorNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxErrorNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxErrorNumberEnabled
        {
            get { return this.uxErrorNumber.Enabled; }
            set
            {
                this.uxErrorNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxErrorSeverity property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxErrorSeverityVisible
        {
            get { return this.uxErrorSeverity.Visible; }
            set
            {
                this.uxErrorSeverityLabel.Visible = value;
                this.uxErrorSeverity.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxErrorSeverity property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxErrorSeverityEnabled
        {
            get { return this.uxErrorSeverity.Enabled; }
            set
            {
                this.uxErrorSeverity.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxErrorState property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxErrorStateVisible
        {
            get { return this.uxErrorState.Visible; }
            set
            {
                this.uxErrorStateLabel.Visible = value;
                this.uxErrorState.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxErrorState property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxErrorStateEnabled
        {
            get { return this.uxErrorState.Enabled; }
            set
            {
                this.uxErrorState.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxErrorProcedure property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxErrorProcedureVisible
        {
            get { return this.uxErrorProcedure.Visible; }
            set
            {
                this.uxErrorProcedureLabel.Visible = value;
                this.uxErrorProcedure.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxErrorProcedure property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxErrorProcedureEnabled
        {
            get { return this.uxErrorProcedure.Enabled; }
            set
            {
                this.uxErrorProcedure.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxErrorLine property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxErrorLineVisible
        {
            get { return this.uxErrorLine.Visible; }
            set
            {
                this.uxErrorLineLabel.Visible = value;
                this.uxErrorLine.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxErrorLine property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxErrorLineEnabled
        {
            get { return this.uxErrorLine.Enabled; }
            set
            {
                this.uxErrorLine.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxErrorMessage property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxErrorMessageVisible
        {
            get { return this.uxErrorMessage.Visible; }
            set
            {
                this.uxErrorMessageLabel.Visible = value;
                this.uxErrorMessage.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxErrorMessage property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxErrorMessageEnabled
        {
            get { return this.uxErrorMessage.Enabled; }
            set
            {
                this.uxErrorMessage.Enabled = value;
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
