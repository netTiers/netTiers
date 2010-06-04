
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.SalesReason"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesReasonEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the SalesReasonId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSalesReasonId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesReasonId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesReasonIdLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// TextBox for the ReasonType property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxReasonType;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ReasonType property.
		/// </summary>
		protected System.Windows.Forms.Label uxReasonTypeLabel;
		
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
		private Entities.SalesReason _SalesReason;
		/// <summary>
		/// Gets or sets the <see cref="Entities.SalesReason"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.SalesReason"/> instance.</value>
		public Entities.SalesReason SalesReason
		{
			get {return this._SalesReason;}
			set
			{
				this._SalesReason = value;
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
			this.uxSalesReasonId.DataBindings.Clear();
			this.uxSalesReasonId.DataBindings.Add("Text", this.uxBindingSource, "SalesReasonId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxReasonType.DataBindings.Clear();
			this.uxReasonType.DataBindings.Add("Text", this.uxBindingSource, "ReasonType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SalesReasonEditControlBase"/> class.
		/// </summary>
		public SalesReasonEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_SalesReason != null) _SalesReason.Validate();
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
			this.uxSalesReasonId = new System.Windows.Forms.TextBox();
			uxSalesReasonIdLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxReasonType = new System.Windows.Forms.TextBox();
			uxReasonTypeLabel = new System.Windows.Forms.Label();
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
			// uxSalesReasonIdLabel
			//
			this.uxSalesReasonIdLabel.Name = "uxSalesReasonIdLabel";
			this.uxSalesReasonIdLabel.Text = "Sales Reason Id:";
			this.uxSalesReasonIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxSalesReasonIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesReasonIdLabel);			
			//
			// uxSalesReasonId
			//
			this.uxSalesReasonId.Name = "uxSalesReasonId";
            this.uxSalesReasonId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesReasonId);
			this.uxSalesReasonId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxSalesReasonId);
			//
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxName);
			//
			// uxReasonTypeLabel
			//
			this.uxReasonTypeLabel.Name = "uxReasonTypeLabel";
			this.uxReasonTypeLabel.Text = "Reason Type:";
			this.uxReasonTypeLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxReasonTypeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxReasonTypeLabel);			
			//
			// uxReasonType
			//
			this.uxReasonType.Name = "uxReasonType";
			this.uxReasonType.Width = 250;
			this.uxReasonType.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxReasonType);
			this.uxReasonType.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxReasonType);
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
			// SalesReasonEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "SalesReasonEditControlBase";
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
        /// Indicates if the controls associated with the uxSalesReasonId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesReasonIdVisible
        {
            get { return this.uxSalesReasonId.Visible; }
            set
            {
                this.uxSalesReasonIdLabel.Visible = value;
                this.uxSalesReasonId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesReasonId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesReasonIdEnabled
        {
            get { return this.uxSalesReasonId.Enabled; }
            set
            {
                this.uxSalesReasonId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNameVisible
        {
            get { return this.uxName.Visible; }
            set
            {
                this.uxNameLabel.Visible = value;
                this.uxName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNameEnabled
        {
            get { return this.uxName.Enabled; }
            set
            {
                this.uxName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxReasonType property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxReasonTypeVisible
        {
            get { return this.uxReasonType.Visible; }
            set
            {
                this.uxReasonTypeLabel.Visible = value;
                this.uxReasonType.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxReasonType property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxReasonTypeEnabled
        {
            get { return this.uxReasonType.Enabled; }
            set
            {
                this.uxReasonType.Enabled = value;
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
