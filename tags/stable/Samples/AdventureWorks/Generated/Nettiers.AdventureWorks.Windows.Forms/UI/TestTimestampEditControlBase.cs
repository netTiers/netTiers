
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.TestTimestamp"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestTimestampEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the TestTimestampId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTestTimestampId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TestTimestampId property.
		/// </summary>
		protected System.Windows.Forms.Label uxTestTimestampIdLabel;
		
		/// <summary>
		/// CheckBox for the DumbField property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxDumbField;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DumbField property.
		/// </summary>
		protected System.Windows.Forms.Label uxDumbFieldLabel;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Version property.
		/// </summary>
		protected System.Windows.Forms.Label uxVersionLabel;
		#endregion
		
		#region Main entity
		private Entities.TestTimestamp _TestTimestamp;
		/// <summary>
		/// Gets or sets the <see cref="Entities.TestTimestamp"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.TestTimestamp"/> instance.</value>
		public Entities.TestTimestamp TestTimestamp
		{
			get {return this._TestTimestamp;}
			set
			{
				this._TestTimestamp = value;
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
			this.uxTestTimestampId.DataBindings.Clear();
			this.uxTestTimestampId.DataBindings.Add("Text", this.uxBindingSource, "TestTimestampId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDumbField.DataBindings.Clear();
			this.uxDumbField.DataBindings.Add("Checked", this.uxBindingSource, "DumbField", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="TestTimestampEditControlBase"/> class.
		/// </summary>
		public TestTimestampEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_TestTimestamp != null) _TestTimestamp.Validate();
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
			this.uxTestTimestampId = new System.Windows.Forms.TextBox();
			uxTestTimestampIdLabel = new System.Windows.Forms.Label();
			this.uxDumbField = new System.Windows.Forms.CheckBox();
			uxDumbFieldLabel = new System.Windows.Forms.Label();
			uxVersionLabel = new System.Windows.Forms.Label();
			
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
			// uxTestTimestampIdLabel
			//
			this.uxTestTimestampIdLabel.Name = "uxTestTimestampIdLabel";
			this.uxTestTimestampIdLabel.Text = "Test Timestamp Id:";
			this.uxTestTimestampIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxTestTimestampIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestTimestampIdLabel);			
			//
			// uxTestTimestampId
			//
			this.uxTestTimestampId.Name = "uxTestTimestampId";
			this.uxTestTimestampId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestTimestampId);
			this.uxTestTimestampId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxTestTimestampId);
			//
			// uxDumbFieldLabel
			//
			this.uxDumbFieldLabel.Name = "uxDumbFieldLabel";
			this.uxDumbFieldLabel.Text = "Dumb Field:";
			this.uxDumbFieldLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxDumbFieldLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDumbFieldLabel);			
			//
			// uxDumbField
			//
			this.uxDumbField.Name = "uxDumbField";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDumbField);
			this.uxDumbField.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxDumbField);
			// 
			// TestTimestampEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "TestTimestampEditControlBase";
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
        /// Indicates if the controls associated with the uxTestTimestampId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTestTimestampIdVisible
        {
            get { return this.uxTestTimestampId.Visible; }
            set
            {
                this.uxTestTimestampIdLabel.Visible = value;
                this.uxTestTimestampId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTestTimestampId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTestTimestampIdEnabled
        {
            get { return this.uxTestTimestampId.Enabled; }
            set
            {
                this.uxTestTimestampId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDumbField property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDumbFieldVisible
        {
            get { return this.uxDumbField.Visible; }
            set
            {
                this.uxDumbFieldLabel.Visible = value;
                this.uxDumbField.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDumbField property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDumbFieldEnabled
        {
            get { return this.uxDumbField.Enabled; }
            set
            {
                this.uxDumbField.Enabled = value;
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
