
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.TestIssue117Tableb"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestIssue117TablebEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the TestIssue117TableBid property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTestIssue117TableBid;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TestIssue117TableBid property.
		/// </summary>
		protected System.Windows.Forms.Label uxTestIssue117TableBidLabel;
		
		/// <summary>
		/// CheckBox for the DumbField property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxDumbField;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DumbField property.
		/// </summary>
		protected System.Windows.Forms.Label uxDumbFieldLabel;
		#endregion
		
		#region Main entity
		private Entities.TestIssue117Tableb _TestIssue117Tableb;
		/// <summary>
		/// Gets or sets the <see cref="Entities.TestIssue117Tableb"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.TestIssue117Tableb"/> instance.</value>
		public Entities.TestIssue117Tableb TestIssue117Tableb
		{
			get {return this._TestIssue117Tableb;}
			set
			{
				this._TestIssue117Tableb = value;
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
			this.uxTestIssue117TableBid.DataBindings.Clear();
			this.uxTestIssue117TableBid.DataBindings.Add("Text", this.uxBindingSource, "TestIssue117TableBid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDumbField.DataBindings.Clear();
			this.uxDumbField.DataBindings.Add("Checked", this.uxBindingSource, "DumbField", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="TestIssue117TablebEditControlBase"/> class.
		/// </summary>
		public TestIssue117TablebEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_TestIssue117Tableb != null) _TestIssue117Tableb.Validate();
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
			this.uxTestIssue117TableBid = new System.Windows.Forms.TextBox();
			uxTestIssue117TableBidLabel = new System.Windows.Forms.Label();
			this.uxDumbField = new System.Windows.Forms.CheckBox();
			uxDumbFieldLabel = new System.Windows.Forms.Label();
			
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
			// uxTestIssue117TableBidLabel
			//
			this.uxTestIssue117TableBidLabel.Name = "uxTestIssue117TableBidLabel";
			this.uxTestIssue117TableBidLabel.Text = "Test Issue117 Table Bid:";
			this.uxTestIssue117TableBidLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxTestIssue117TableBidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestIssue117TableBidLabel);			
			//
			// uxTestIssue117TableBid
			//
			this.uxTestIssue117TableBid.Name = "uxTestIssue117TableBid";
			this.uxTestIssue117TableBid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestIssue117TableBid);
			this.uxTestIssue117TableBid.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxTestIssue117TableBid);
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
			// TestIssue117TablebEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "TestIssue117TablebEditControlBase";
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
        /// Indicates if the controls associated with the uxTestIssue117TableBid property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTestIssue117TableBidVisible
        {
            get { return this.uxTestIssue117TableBid.Visible; }
            set
            {
                this.uxTestIssue117TableBidLabel.Visible = value;
                this.uxTestIssue117TableBid.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTestIssue117TableBid property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTestIssue117TableBidEnabled
        {
            get { return this.uxTestIssue117TableBid.Enabled; }
            set
            {
                this.uxTestIssue117TableBid.Enabled = value;
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
