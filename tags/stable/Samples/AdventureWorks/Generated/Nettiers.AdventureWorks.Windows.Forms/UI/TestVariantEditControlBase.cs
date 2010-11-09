
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.TestVariant"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestVariantEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the TestVariantId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTestVariantId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TestVariantId property.
		/// </summary>
		protected System.Windows.Forms.Label uxTestVariantIdLabel;
		
		/// <summary>
		/// TextBox for the VariantField property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxVariantField;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the VariantField property.
		/// </summary>
		protected System.Windows.Forms.Label uxVariantFieldLabel;
		#endregion
		
		#region Main entity
		private Entities.TestVariant _TestVariant;
		/// <summary>
		/// Gets or sets the <see cref="Entities.TestVariant"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.TestVariant"/> instance.</value>
		public Entities.TestVariant TestVariant
		{
			get {return this._TestVariant;}
			set
			{
				this._TestVariant = value;
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
			this.uxTestVariantId.DataBindings.Clear();
			this.uxTestVariantId.DataBindings.Add("Text", this.uxBindingSource, "TestVariantId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxVariantField.DataBindings.Clear();
			this.uxVariantField.DataBindings.Add("Text", this.uxBindingSource, "VariantField", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="TestVariantEditControlBase"/> class.
		/// </summary>
		public TestVariantEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_TestVariant != null) _TestVariant.Validate();
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
			this.uxTestVariantId = new System.Windows.Forms.TextBox();
			uxTestVariantIdLabel = new System.Windows.Forms.Label();
			this.uxVariantField = new System.Windows.Forms.TextBox();
			uxVariantFieldLabel = new System.Windows.Forms.Label();
			
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
			// uxTestVariantIdLabel
			//
			this.uxTestVariantIdLabel.Name = "uxTestVariantIdLabel";
			this.uxTestVariantIdLabel.Text = "Test Variant Id:";
			this.uxTestVariantIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxTestVariantIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestVariantIdLabel);			
			//
			// uxTestVariantId
			//
			this.uxTestVariantId.Name = "uxTestVariantId";
            this.uxTestVariantId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestVariantId);
			this.uxTestVariantId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxTestVariantId);
			//
			// uxVariantFieldLabel
			//
			this.uxVariantFieldLabel.Name = "uxVariantFieldLabel";
			this.uxVariantFieldLabel.Text = "Variant Field:";
			this.uxVariantFieldLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxVariantFieldLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxVariantFieldLabel);			
			//
			// uxVariantField
			//
			this.uxVariantField.Name = "uxVariantField";
			//this.uxTableLayoutPanel.Controls.Add(this.uxVariantField);
			this.uxVariantField.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxVariantField);
			// 
			// TestVariantEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "TestVariantEditControlBase";
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
        /// Indicates if the controls associated with the uxTestVariantId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTestVariantIdVisible
        {
            get { return this.uxTestVariantId.Visible; }
            set
            {
                this.uxTestVariantIdLabel.Visible = value;
                this.uxTestVariantId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTestVariantId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTestVariantIdEnabled
        {
            get { return this.uxTestVariantId.Enabled; }
            set
            {
                this.uxTestVariantId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxVariantField property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxVariantFieldVisible
        {
            get { return this.uxVariantField.Visible; }
            set
            {
                this.uxVariantFieldLabel.Visible = value;
                this.uxVariantField.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxVariantField property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxVariantFieldEnabled
        {
            get { return this.uxVariantField.Enabled; }
            set
            {
                this.uxVariantField.Enabled = value;
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
