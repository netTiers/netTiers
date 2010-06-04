
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.TransactionHistoryArchive"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TransactionHistoryArchiveEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the TransactionId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTransactionId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TransactionId property.
		/// </summary>
		protected System.Windows.Forms.Label uxTransactionIdLabel;
		
		/// <summary>
		/// TextBox for the ProductId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// TextBox for the ReferenceOrderId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxReferenceOrderId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ReferenceOrderId property.
		/// </summary>
		protected System.Windows.Forms.Label uxReferenceOrderIdLabel;
		
		/// <summary>
		/// TextBox for the ReferenceOrderLineId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxReferenceOrderLineId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ReferenceOrderLineId property.
		/// </summary>
		protected System.Windows.Forms.Label uxReferenceOrderLineIdLabel;
		
		/// <summary>
		/// DataTimePicker for the TransactionDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxTransactionDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TransactionDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxTransactionDateLabel;
		
		/// <summary>
		/// TextBox for the TransactionType property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTransactionType;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TransactionType property.
		/// </summary>
		protected System.Windows.Forms.Label uxTransactionTypeLabel;
		
		/// <summary>
		/// TextBox for the Quantity property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxQuantity;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Quantity property.
		/// </summary>
		protected System.Windows.Forms.Label uxQuantityLabel;
		
		/// <summary>
		/// TextBox for the ActualCost property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxActualCost;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ActualCost property.
		/// </summary>
		protected System.Windows.Forms.Label uxActualCostLabel;
		
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
		private Entities.TransactionHistoryArchive _TransactionHistoryArchive;
		/// <summary>
		/// Gets or sets the <see cref="Entities.TransactionHistoryArchive"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.TransactionHistoryArchive"/> instance.</value>
		public Entities.TransactionHistoryArchive TransactionHistoryArchive
		{
			get {return this._TransactionHistoryArchive;}
			set
			{
				this._TransactionHistoryArchive = value;
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
			this.uxTransactionId.DataBindings.Clear();
			this.uxTransactionId.DataBindings.Add("Text", this.uxBindingSource, "TransactionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("Text", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxReferenceOrderId.DataBindings.Clear();
			this.uxReferenceOrderId.DataBindings.Add("Text", this.uxBindingSource, "ReferenceOrderId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxReferenceOrderLineId.DataBindings.Clear();
			this.uxReferenceOrderLineId.DataBindings.Add("Text", this.uxBindingSource, "ReferenceOrderLineId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTransactionDate.DataBindings.Clear();
			this.uxTransactionDate.DataBindings.Add("Value", this.uxBindingSource, "TransactionDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTransactionType.DataBindings.Clear();
			this.uxTransactionType.DataBindings.Add("Text", this.uxBindingSource, "TransactionType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxQuantity.DataBindings.Clear();
			this.uxQuantity.DataBindings.Add("Text", this.uxBindingSource, "Quantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxActualCost.DataBindings.Clear();
			this.uxActualCost.DataBindings.Add("Text", this.uxBindingSource, "ActualCost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="TransactionHistoryArchiveEditControlBase"/> class.
		/// </summary>
		public TransactionHistoryArchiveEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_TransactionHistoryArchive != null) _TransactionHistoryArchive.Validate();
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
			this.uxTransactionId = new System.Windows.Forms.TextBox();
			uxTransactionIdLabel = new System.Windows.Forms.Label();
			this.uxProductId = new System.Windows.Forms.TextBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxReferenceOrderId = new System.Windows.Forms.TextBox();
			uxReferenceOrderIdLabel = new System.Windows.Forms.Label();
			this.uxReferenceOrderLineId = new System.Windows.Forms.TextBox();
			uxReferenceOrderLineIdLabel = new System.Windows.Forms.Label();
			this.uxTransactionDate = new System.Windows.Forms.DateTimePicker();
			uxTransactionDateLabel = new System.Windows.Forms.Label();
			this.uxTransactionType = new System.Windows.Forms.TextBox();
			uxTransactionTypeLabel = new System.Windows.Forms.Label();
			this.uxQuantity = new System.Windows.Forms.TextBox();
			uxQuantityLabel = new System.Windows.Forms.Label();
			this.uxActualCost = new System.Windows.Forms.TextBox();
			uxActualCostLabel = new System.Windows.Forms.Label();
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
			// uxTransactionIdLabel
			//
			this.uxTransactionIdLabel.Name = "uxTransactionIdLabel";
			this.uxTransactionIdLabel.Text = "Transaction Id:";
			this.uxTransactionIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxTransactionIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTransactionIdLabel);			
			//
			// uxTransactionId
			//
			this.uxTransactionId.Name = "uxTransactionId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTransactionId);
			this.uxTransactionId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxTransactionId);
			//
			// uxProductIdLabel
			//
			this.uxProductIdLabel.Name = "uxProductIdLabel";
			this.uxProductIdLabel.Text = "Product Id:";
			this.uxProductIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductIdLabel);			
			//
			// uxProductId
			//
			this.uxProductId.Name = "uxProductId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductId);
			this.uxProductId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxProductId);
			//
			// uxReferenceOrderIdLabel
			//
			this.uxReferenceOrderIdLabel.Name = "uxReferenceOrderIdLabel";
			this.uxReferenceOrderIdLabel.Text = "Reference Order Id:";
			this.uxReferenceOrderIdLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxReferenceOrderIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxReferenceOrderIdLabel);			
			//
			// uxReferenceOrderId
			//
			this.uxReferenceOrderId.Name = "uxReferenceOrderId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxReferenceOrderId);
			this.uxReferenceOrderId.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxReferenceOrderId);
			//
			// uxReferenceOrderLineIdLabel
			//
			this.uxReferenceOrderLineIdLabel.Name = "uxReferenceOrderLineIdLabel";
			this.uxReferenceOrderLineIdLabel.Text = "Reference Order Line Id:";
			this.uxReferenceOrderLineIdLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxReferenceOrderLineIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxReferenceOrderLineIdLabel);			
			//
			// uxReferenceOrderLineId
			//
			this.uxReferenceOrderLineId.Name = "uxReferenceOrderLineId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxReferenceOrderLineId);
			this.uxReferenceOrderLineId.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxReferenceOrderLineId);
			//
			// uxTransactionDateLabel
			//
			this.uxTransactionDateLabel.Name = "uxTransactionDateLabel";
			this.uxTransactionDateLabel.Text = "Transaction Date:";
			this.uxTransactionDateLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxTransactionDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTransactionDateLabel);			
			//
			// uxTransactionDate
			//
			this.uxTransactionDate.Name = "uxTransactionDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxTransactionDate);
			this.uxTransactionDate.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxTransactionDate);
			//
			// uxTransactionTypeLabel
			//
			this.uxTransactionTypeLabel.Name = "uxTransactionTypeLabel";
			this.uxTransactionTypeLabel.Text = "Transaction Type:";
			this.uxTransactionTypeLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxTransactionTypeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTransactionTypeLabel);			
			//
			// uxTransactionType
			//
			this.uxTransactionType.Name = "uxTransactionType";
			this.uxTransactionType.Width = 250;
			this.uxTransactionType.MaxLength = 1;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTransactionType);
			this.uxTransactionType.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxTransactionType);
			//
			// uxQuantityLabel
			//
			this.uxQuantityLabel.Name = "uxQuantityLabel";
			this.uxQuantityLabel.Text = "Quantity:";
			this.uxQuantityLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxQuantityLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxQuantityLabel);			
			//
			// uxQuantity
			//
			this.uxQuantity.Name = "uxQuantity";
			//this.uxTableLayoutPanel.Controls.Add(this.uxQuantity);
			this.uxQuantity.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxQuantity);
			//
			// uxActualCostLabel
			//
			this.uxActualCostLabel.Name = "uxActualCostLabel";
			this.uxActualCostLabel.Text = "Actual Cost:";
			this.uxActualCostLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxActualCostLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualCostLabel);			
			//
			// uxActualCost
			//
			this.uxActualCost.Name = "uxActualCost";
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualCost);
			this.uxActualCost.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxActualCost);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxModifiedDate);
			// 
			// TransactionHistoryArchiveEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "TransactionHistoryArchiveEditControlBase";
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
        /// Indicates if the controls associated with the uxTransactionId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTransactionIdVisible
        {
            get { return this.uxTransactionId.Visible; }
            set
            {
                this.uxTransactionIdLabel.Visible = value;
                this.uxTransactionId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTransactionId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTransactionIdEnabled
        {
            get { return this.uxTransactionId.Enabled; }
            set
            {
                this.uxTransactionId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductIdVisible
        {
            get { return this.uxProductId.Visible; }
            set
            {
                this.uxProductIdLabel.Visible = value;
                this.uxProductId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductIdEnabled
        {
            get { return this.uxProductId.Enabled; }
            set
            {
                this.uxProductId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxReferenceOrderId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxReferenceOrderIdVisible
        {
            get { return this.uxReferenceOrderId.Visible; }
            set
            {
                this.uxReferenceOrderIdLabel.Visible = value;
                this.uxReferenceOrderId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxReferenceOrderId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxReferenceOrderIdEnabled
        {
            get { return this.uxReferenceOrderId.Enabled; }
            set
            {
                this.uxReferenceOrderId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxReferenceOrderLineId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxReferenceOrderLineIdVisible
        {
            get { return this.uxReferenceOrderLineId.Visible; }
            set
            {
                this.uxReferenceOrderLineIdLabel.Visible = value;
                this.uxReferenceOrderLineId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxReferenceOrderLineId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxReferenceOrderLineIdEnabled
        {
            get { return this.uxReferenceOrderLineId.Enabled; }
            set
            {
                this.uxReferenceOrderLineId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTransactionDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTransactionDateVisible
        {
            get { return this.uxTransactionDate.Visible; }
            set
            {
                this.uxTransactionDateLabel.Visible = value;
                this.uxTransactionDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTransactionDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTransactionDateEnabled
        {
            get { return this.uxTransactionDate.Enabled; }
            set
            {
                this.uxTransactionDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTransactionType property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTransactionTypeVisible
        {
            get { return this.uxTransactionType.Visible; }
            set
            {
                this.uxTransactionTypeLabel.Visible = value;
                this.uxTransactionType.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTransactionType property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTransactionTypeEnabled
        {
            get { return this.uxTransactionType.Enabled; }
            set
            {
                this.uxTransactionType.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxQuantity property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxQuantityVisible
        {
            get { return this.uxQuantity.Visible; }
            set
            {
                this.uxQuantityLabel.Visible = value;
                this.uxQuantity.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxQuantity property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxQuantityEnabled
        {
            get { return this.uxQuantity.Enabled; }
            set
            {
                this.uxQuantity.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxActualCost property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxActualCostVisible
        {
            get { return this.uxActualCost.Visible; }
            set
            {
                this.uxActualCostLabel.Visible = value;
                this.uxActualCost.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxActualCost property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxActualCostEnabled
        {
            get { return this.uxActualCost.Enabled; }
            set
            {
                this.uxActualCost.Enabled = value;
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
