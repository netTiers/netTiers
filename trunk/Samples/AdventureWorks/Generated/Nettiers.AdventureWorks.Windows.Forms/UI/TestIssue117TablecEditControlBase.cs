
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.TestIssue117Tablec"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestIssue117TablecEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the TestIssue117TableAid property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxTestIssue117TableAid;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TestIssue117TableAid property.
		/// </summary>
		protected System.Windows.Forms.Label uxTestIssue117TableAidLabel;
		
		/// <summary>
		/// ComboBox for the TestIssue117TableBid property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxTestIssue117TableBid;
		
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
		private Entities.TestIssue117Tablec _TestIssue117Tablec;
		/// <summary>
		/// Gets or sets the <see cref="Entities.TestIssue117Tablec"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.TestIssue117Tablec"/> instance.</value>
		public Entities.TestIssue117Tablec TestIssue117Tablec
		{
			get {return this._TestIssue117Tablec;}
			set
			{
				this._TestIssue117Tablec = value;
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
			this.uxTestIssue117TableAid.DataBindings.Clear();
			this.uxTestIssue117TableAid.DataBindings.Add("SelectedValue", this.uxBindingSource, "TestIssue117TableAid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTestIssue117TableBid.DataBindings.Clear();
			this.uxTestIssue117TableBid.DataBindings.Add("SelectedValue", this.uxBindingSource, "TestIssue117TableBid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDumbField.DataBindings.Clear();
			this.uxDumbField.DataBindings.Add("Checked", this.uxBindingSource, "DumbField", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="TestIssue117TablecEditControlBase"/> class.
		/// </summary>
		public TestIssue117TablecEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_TestIssue117Tablec != null) _TestIssue117Tablec.Validate();
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
			this.uxTestIssue117TableAid = new System.Windows.Forms.ComboBox();
			uxTestIssue117TableAidLabel = new System.Windows.Forms.Label();
			this.uxTestIssue117TableBid = new System.Windows.Forms.ComboBox();
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
			// uxTestIssue117TableAidLabel
			//
			this.uxTestIssue117TableAidLabel.Name = "uxTestIssue117TableAidLabel";
			this.uxTestIssue117TableAidLabel.Text = "Test Issue117 Table Aid:";
			this.uxTestIssue117TableAidLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxTestIssue117TableAidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestIssue117TableAidLabel);			
			//
			// uxTestIssue117TableAid
			//
			this.uxTestIssue117TableAid.Name = "uxTestIssue117TableAid";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestIssue117TableAid);
			this.uxTestIssue117TableAid.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxTestIssue117TableAid);
			//
			// uxTestIssue117TableBidLabel
			//
			this.uxTestIssue117TableBidLabel.Name = "uxTestIssue117TableBidLabel";
			this.uxTestIssue117TableBidLabel.Text = "Test Issue117 Table Bid:";
			this.uxTestIssue117TableBidLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxTestIssue117TableBidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestIssue117TableBidLabel);			
			//
			// uxTestIssue117TableBid
			//
			this.uxTestIssue117TableBid.Name = "uxTestIssue117TableBid";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTestIssue117TableBid);
			this.uxTestIssue117TableBid.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxTestIssue117TableBid);
			//
			// uxDumbFieldLabel
			//
			this.uxDumbFieldLabel.Name = "uxDumbFieldLabel";
			this.uxDumbFieldLabel.Text = "Dumb Field:";
			this.uxDumbFieldLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxDumbFieldLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDumbFieldLabel);			
			//
			// uxDumbField
			//
			this.uxDumbField.Name = "uxDumbField";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDumbField);
			this.uxDumbField.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxDumbField);
			//
			// uxTestIssue117TableAid
			//				
			this.uxTestIssue117TableAid.DisplayMember = "DumbField";	
			this.uxTestIssue117TableAid.ValueMember = "TestIssue117TableAid";	
			//
			// uxTestIssue117TableBid
			//				
			this.uxTestIssue117TableBid.DisplayMember = "DumbField";	
			this.uxTestIssue117TableBid.ValueMember = "TestIssue117TableBid";	
			// 
			// TestIssue117TablecEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "TestIssue117TablecEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.TestIssue117Tablea> _TestIssue117TableAidList;
		
		/// <summary>
		/// The ComboBox associated with the TestIssue117TableAid property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.TestIssue117Tablea> TestIssue117TableAidList
		{
			get {return _TestIssue117TableAidList;}
			set 
			{
				this._TestIssue117TableAidList = value;
				this.uxTestIssue117TableAid.DataSource = null;
				this.uxTestIssue117TableAid.DataSource = value;
			}
		}
		
		private bool _allowNewItemInTestIssue117TableAidList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the TestIssue117TableAid property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInTestIssue117TableAidList
		{
			get { return _allowNewItemInTestIssue117TableAidList;}
			set
			{
				this._allowNewItemInTestIssue117TableAidList = value;
				this.uxTestIssue117TableAid.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.TestIssue117Tableb> _TestIssue117TableBidList;
		
		/// <summary>
		/// The ComboBox associated with the TestIssue117TableBid property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.TestIssue117Tableb> TestIssue117TableBidList
		{
			get {return _TestIssue117TableBidList;}
			set 
			{
				this._TestIssue117TableBidList = value;
				this.uxTestIssue117TableBid.DataSource = null;
				this.uxTestIssue117TableBid.DataSource = value;
			}
		}
		
		private bool _allowNewItemInTestIssue117TableBidList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the TestIssue117TableBid property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInTestIssue117TableBidList
		{
			get { return _allowNewItemInTestIssue117TableBidList;}
			set
			{
				this._allowNewItemInTestIssue117TableBidList = value;
				this.uxTestIssue117TableBid.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxTestIssue117TableAid property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTestIssue117TableAidVisible
        {
            get { return this.uxTestIssue117TableAid.Visible; }
            set
            {
                this.uxTestIssue117TableAidLabel.Visible = value;
                this.uxTestIssue117TableAid.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTestIssue117TableAid property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTestIssue117TableAidEnabled
        {
            get { return this.uxTestIssue117TableAid.Enabled; }
            set
            {
                this.uxTestIssue117TableAid.Enabled = value;
            }
        }
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
