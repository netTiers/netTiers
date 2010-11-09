
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.DatabaseLog"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class DatabaseLogEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the DatabaseLogId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDatabaseLogId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DatabaseLogId property.
		/// </summary>
		protected System.Windows.Forms.Label uxDatabaseLogIdLabel;
		
		/// <summary>
		/// DataTimePicker for the PostTime property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxPostTime;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PostTime property.
		/// </summary>
		protected System.Windows.Forms.Label uxPostTimeLabel;
		
		/// <summary>
		/// TextBox for the DatabaseUser property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDatabaseUser;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DatabaseUser property.
		/// </summary>
		protected System.Windows.Forms.Label uxDatabaseUserLabel;
		
		/// <summary>
		/// TextBox for the SafeNameEvent property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSafeNameEvent;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SafeNameEvent property.
		/// </summary>
		protected System.Windows.Forms.Label uxSafeNameEventLabel;
		
		/// <summary>
		/// TextBox for the Schema property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSchema;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Schema property.
		/// </summary>
		protected System.Windows.Forms.Label uxSchemaLabel;
		
		/// <summary>
		/// TextBox for the SafeNameObject property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSafeNameObject;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SafeNameObject property.
		/// </summary>
		protected System.Windows.Forms.Label uxSafeNameObjectLabel;
		
		/// <summary>
		/// TextBox for the Tsql property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTsql;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Tsql property.
		/// </summary>
		protected System.Windows.Forms.Label uxTsqlLabel;
		
		/// <summary>
		/// TextBox for the XmlEvent property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxXmlEvent;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the XmlEvent property.
		/// </summary>
		protected System.Windows.Forms.Label uxXmlEventLabel;
		#endregion
		
		#region Main entity
		private Entities.DatabaseLog _DatabaseLog;
		/// <summary>
		/// Gets or sets the <see cref="Entities.DatabaseLog"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.DatabaseLog"/> instance.</value>
		public Entities.DatabaseLog DatabaseLog
		{
			get {return this._DatabaseLog;}
			set
			{
				this._DatabaseLog = value;
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
			this.uxDatabaseLogId.DataBindings.Clear();
			this.uxDatabaseLogId.DataBindings.Add("Text", this.uxBindingSource, "DatabaseLogId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPostTime.DataBindings.Clear();
			this.uxPostTime.DataBindings.Add("Value", this.uxBindingSource, "PostTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDatabaseUser.DataBindings.Clear();
			this.uxDatabaseUser.DataBindings.Add("Text", this.uxBindingSource, "DatabaseUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSafeNameEvent.DataBindings.Clear();
			this.uxSafeNameEvent.DataBindings.Add("Text", this.uxBindingSource, "SafeNameEvent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSchema.DataBindings.Clear();
			this.uxSchema.DataBindings.Add("Text", this.uxBindingSource, "Schema", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSafeNameObject.DataBindings.Clear();
			this.uxSafeNameObject.DataBindings.Add("Text", this.uxBindingSource, "SafeNameObject", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTsql.DataBindings.Clear();
			this.uxTsql.DataBindings.Add("Text", this.uxBindingSource, "Tsql", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxXmlEvent.DataBindings.Clear();
			this.uxXmlEvent.DataBindings.Add("Text", this.uxBindingSource, "XmlEvent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseLogEditControlBase"/> class.
		/// </summary>
		public DatabaseLogEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_DatabaseLog != null) _DatabaseLog.Validate();
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
			this.uxDatabaseLogId = new System.Windows.Forms.TextBox();
			uxDatabaseLogIdLabel = new System.Windows.Forms.Label();
			this.uxPostTime = new System.Windows.Forms.DateTimePicker();
			uxPostTimeLabel = new System.Windows.Forms.Label();
			this.uxDatabaseUser = new System.Windows.Forms.TextBox();
			uxDatabaseUserLabel = new System.Windows.Forms.Label();
			this.uxSafeNameEvent = new System.Windows.Forms.TextBox();
			uxSafeNameEventLabel = new System.Windows.Forms.Label();
			this.uxSchema = new System.Windows.Forms.TextBox();
			uxSchemaLabel = new System.Windows.Forms.Label();
			this.uxSafeNameObject = new System.Windows.Forms.TextBox();
			uxSafeNameObjectLabel = new System.Windows.Forms.Label();
			this.uxTsql = new System.Windows.Forms.TextBox();
			uxTsqlLabel = new System.Windows.Forms.Label();
			this.uxXmlEvent = new System.Windows.Forms.TextBox();
			uxXmlEventLabel = new System.Windows.Forms.Label();
			
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
			// uxDatabaseLogIdLabel
			//
			this.uxDatabaseLogIdLabel.Name = "uxDatabaseLogIdLabel";
			this.uxDatabaseLogIdLabel.Text = "Database Log Id:";
			this.uxDatabaseLogIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxDatabaseLogIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDatabaseLogIdLabel);			
			//
			// uxDatabaseLogId
			//
			this.uxDatabaseLogId.Name = "uxDatabaseLogId";
            this.uxDatabaseLogId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxDatabaseLogId);
			this.uxDatabaseLogId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxDatabaseLogId);
			//
			// uxPostTimeLabel
			//
			this.uxPostTimeLabel.Name = "uxPostTimeLabel";
			this.uxPostTimeLabel.Text = "Post Time:";
			this.uxPostTimeLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxPostTimeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPostTimeLabel);			
			//
			// uxPostTime
			//
			this.uxPostTime.Name = "uxPostTime";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPostTime);
			this.uxPostTime.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxPostTime);
			//
			// uxDatabaseUserLabel
			//
			this.uxDatabaseUserLabel.Name = "uxDatabaseUserLabel";
			this.uxDatabaseUserLabel.Text = "Database User:";
			this.uxDatabaseUserLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxDatabaseUserLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDatabaseUserLabel);			
			//
			// uxDatabaseUser
			//
			this.uxDatabaseUser.Name = "uxDatabaseUser";
			this.uxDatabaseUser.Width = 250;
			this.uxDatabaseUser.MaxLength = 128;
			//this.uxTableLayoutPanel.Controls.Add(this.uxDatabaseUser);
			this.uxDatabaseUser.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxDatabaseUser);
			//
			// uxSafeNameEventLabel
			//
			this.uxSafeNameEventLabel.Name = "uxSafeNameEventLabel";
			this.uxSafeNameEventLabel.Text = "Event:";
			this.uxSafeNameEventLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxSafeNameEventLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSafeNameEventLabel);			
			//
			// uxSafeNameEvent
			//
			this.uxSafeNameEvent.Name = "uxSafeNameEvent";
			this.uxSafeNameEvent.Width = 250;
			this.uxSafeNameEvent.MaxLength = 128;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSafeNameEvent);
			this.uxSafeNameEvent.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxSafeNameEvent);
			//
			// uxSchemaLabel
			//
			this.uxSchemaLabel.Name = "uxSchemaLabel";
			this.uxSchemaLabel.Text = "Schema:";
			this.uxSchemaLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxSchemaLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSchemaLabel);			
			//
			// uxSchema
			//
			this.uxSchema.Name = "uxSchema";
			this.uxSchema.Width = 250;
			this.uxSchema.MaxLength = 128;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSchema);
			this.uxSchema.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxSchema);
			//
			// uxSafeNameObjectLabel
			//
			this.uxSafeNameObjectLabel.Name = "uxSafeNameObjectLabel";
			this.uxSafeNameObjectLabel.Text = "Object:";
			this.uxSafeNameObjectLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxSafeNameObjectLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSafeNameObjectLabel);			
			//
			// uxSafeNameObject
			//
			this.uxSafeNameObject.Name = "uxSafeNameObject";
			this.uxSafeNameObject.Width = 250;
			this.uxSafeNameObject.MaxLength = 128;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSafeNameObject);
			this.uxSafeNameObject.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxSafeNameObject);
			//
			// uxTsqlLabel
			//
			this.uxTsqlLabel.Name = "uxTsqlLabel";
			this.uxTsqlLabel.Text = "Tsql:";
			this.uxTsqlLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxTsqlLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTsqlLabel);			
			//
			// uxTsql
			//
			this.uxTsql.Name = "uxTsql";
			this.uxTsql.Width = 250;
			this.uxTsql.Multiline = true;
			//this.uxTsql.Height = 80;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTsql);
			this.uxTsql.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxTsql);
			//
			// uxXmlEventLabel
			//
			this.uxXmlEventLabel.Name = "uxXmlEventLabel";
			this.uxXmlEventLabel.Text = "Xml Event:";
			this.uxXmlEventLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxXmlEventLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxXmlEventLabel);			
			//
			// uxXmlEvent
			//
			this.uxXmlEvent.Name = "uxXmlEvent";
			//this.uxTableLayoutPanel.Controls.Add(this.uxXmlEvent);
			this.uxXmlEvent.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxXmlEvent);
			// 
			// DatabaseLogEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "DatabaseLogEditControlBase";
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
        /// Indicates if the controls associated with the uxDatabaseLogId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDatabaseLogIdVisible
        {
            get { return this.uxDatabaseLogId.Visible; }
            set
            {
                this.uxDatabaseLogIdLabel.Visible = value;
                this.uxDatabaseLogId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDatabaseLogId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDatabaseLogIdEnabled
        {
            get { return this.uxDatabaseLogId.Enabled; }
            set
            {
                this.uxDatabaseLogId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPostTime property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPostTimeVisible
        {
            get { return this.uxPostTime.Visible; }
            set
            {
                this.uxPostTimeLabel.Visible = value;
                this.uxPostTime.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPostTime property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPostTimeEnabled
        {
            get { return this.uxPostTime.Enabled; }
            set
            {
                this.uxPostTime.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDatabaseUser property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDatabaseUserVisible
        {
            get { return this.uxDatabaseUser.Visible; }
            set
            {
                this.uxDatabaseUserLabel.Visible = value;
                this.uxDatabaseUser.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDatabaseUser property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDatabaseUserEnabled
        {
            get { return this.uxDatabaseUser.Enabled; }
            set
            {
                this.uxDatabaseUser.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSafeNameEvent property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSafeNameEventVisible
        {
            get { return this.uxSafeNameEvent.Visible; }
            set
            {
                this.uxSafeNameEventLabel.Visible = value;
                this.uxSafeNameEvent.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSafeNameEvent property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSafeNameEventEnabled
        {
            get { return this.uxSafeNameEvent.Enabled; }
            set
            {
                this.uxSafeNameEvent.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSchema property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSchemaVisible
        {
            get { return this.uxSchema.Visible; }
            set
            {
                this.uxSchemaLabel.Visible = value;
                this.uxSchema.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSchema property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSchemaEnabled
        {
            get { return this.uxSchema.Enabled; }
            set
            {
                this.uxSchema.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSafeNameObject property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSafeNameObjectVisible
        {
            get { return this.uxSafeNameObject.Visible; }
            set
            {
                this.uxSafeNameObjectLabel.Visible = value;
                this.uxSafeNameObject.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSafeNameObject property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSafeNameObjectEnabled
        {
            get { return this.uxSafeNameObject.Enabled; }
            set
            {
                this.uxSafeNameObject.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTsql property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTsqlVisible
        {
            get { return this.uxTsql.Visible; }
            set
            {
                this.uxTsqlLabel.Visible = value;
                this.uxTsql.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTsql property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTsqlEnabled
        {
            get { return this.uxTsql.Enabled; }
            set
            {
                this.uxTsql.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxXmlEvent property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxXmlEventVisible
        {
            get { return this.uxXmlEvent.Visible; }
            set
            {
                this.uxXmlEventLabel.Visible = value;
                this.uxXmlEvent.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxXmlEvent property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxXmlEventEnabled
        {
            get { return this.uxXmlEvent.Enabled; }
            set
            {
                this.uxXmlEvent.Enabled = value;
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
