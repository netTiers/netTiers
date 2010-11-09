
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.AwBuildVersion"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class AwBuildVersionEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the SystemInformationId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSystemInformationId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SystemInformationId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSystemInformationIdLabel;
		
		/// <summary>
		/// TextBox for the DatabaseVersion property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDatabaseVersion;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DatabaseVersion property.
		/// </summary>
		protected System.Windows.Forms.Label uxDatabaseVersionLabel;
		
		/// <summary>
		/// DataTimePicker for the VersionDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxVersionDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the VersionDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxVersionDateLabel;
		
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
		private Entities.AwBuildVersion _AwBuildVersion;
		/// <summary>
		/// Gets or sets the <see cref="Entities.AwBuildVersion"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.AwBuildVersion"/> instance.</value>
		public Entities.AwBuildVersion AwBuildVersion
		{
			get {return this._AwBuildVersion;}
			set
			{
				this._AwBuildVersion = value;
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
			this.uxSystemInformationId.DataBindings.Clear();
			this.uxSystemInformationId.DataBindings.Add("Text", this.uxBindingSource, "SystemInformationId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDatabaseVersion.DataBindings.Clear();
			this.uxDatabaseVersion.DataBindings.Add("Text", this.uxBindingSource, "DatabaseVersion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxVersionDate.DataBindings.Clear();
			this.uxVersionDate.DataBindings.Add("Value", this.uxBindingSource, "VersionDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="AwBuildVersionEditControlBase"/> class.
		/// </summary>
		public AwBuildVersionEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_AwBuildVersion != null) _AwBuildVersion.Validate();
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
			this.uxSystemInformationId = new System.Windows.Forms.TextBox();
			uxSystemInformationIdLabel = new System.Windows.Forms.Label();
			this.uxDatabaseVersion = new System.Windows.Forms.TextBox();
			uxDatabaseVersionLabel = new System.Windows.Forms.Label();
			this.uxVersionDate = new System.Windows.Forms.DateTimePicker();
			uxVersionDateLabel = new System.Windows.Forms.Label();
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
			// uxSystemInformationIdLabel
			//
			this.uxSystemInformationIdLabel.Name = "uxSystemInformationIdLabel";
			this.uxSystemInformationIdLabel.Text = "System Information Id:";
			this.uxSystemInformationIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxSystemInformationIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSystemInformationIdLabel);			
			//
			// uxSystemInformationId
			//
			this.uxSystemInformationId.Name = "uxSystemInformationId";
            this.uxSystemInformationId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSystemInformationId);
			this.uxSystemInformationId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxSystemInformationId);
			//
			// uxDatabaseVersionLabel
			//
			this.uxDatabaseVersionLabel.Name = "uxDatabaseVersionLabel";
			this.uxDatabaseVersionLabel.Text = "Database Version:";
			this.uxDatabaseVersionLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxDatabaseVersionLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDatabaseVersionLabel);			
			//
			// uxDatabaseVersion
			//
			this.uxDatabaseVersion.Name = "uxDatabaseVersion";
			this.uxDatabaseVersion.Width = 250;
			this.uxDatabaseVersion.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxDatabaseVersion);
			this.uxDatabaseVersion.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxDatabaseVersion);
			//
			// uxVersionDateLabel
			//
			this.uxVersionDateLabel.Name = "uxVersionDateLabel";
			this.uxVersionDateLabel.Text = "Version Date:";
			this.uxVersionDateLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxVersionDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxVersionDateLabel);			
			//
			// uxVersionDate
			//
			this.uxVersionDate.Name = "uxVersionDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxVersionDate);
			this.uxVersionDate.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxVersionDate);
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
			// AwBuildVersionEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "AwBuildVersionEditControlBase";
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
        /// Indicates if the controls associated with the uxSystemInformationId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSystemInformationIdVisible
        {
            get { return this.uxSystemInformationId.Visible; }
            set
            {
                this.uxSystemInformationIdLabel.Visible = value;
                this.uxSystemInformationId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSystemInformationId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSystemInformationIdEnabled
        {
            get { return this.uxSystemInformationId.Enabled; }
            set
            {
                this.uxSystemInformationId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDatabaseVersion property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDatabaseVersionVisible
        {
            get { return this.uxDatabaseVersion.Visible; }
            set
            {
                this.uxDatabaseVersionLabel.Visible = value;
                this.uxDatabaseVersion.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDatabaseVersion property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDatabaseVersionEnabled
        {
            get { return this.uxDatabaseVersion.Enabled; }
            set
            {
                this.uxDatabaseVersion.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxVersionDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxVersionDateVisible
        {
            get { return this.uxVersionDate.Visible; }
            set
            {
                this.uxVersionDateLabel.Visible = value;
                this.uxVersionDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxVersionDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxVersionDateEnabled
        {
            get { return this.uxVersionDate.Enabled; }
            set
            {
                this.uxVersionDate.Enabled = value;
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
