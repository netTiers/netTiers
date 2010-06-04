
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.SalesOrderHeaderSalesReason"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesOrderHeaderSalesReasonEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the SalesOrderId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxSalesOrderId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesOrderId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesOrderIdLabel;
		
		/// <summary>
		/// ComboBox for the SalesReasonId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxSalesReasonId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalesReasonId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalesReasonIdLabel;
		
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
		private Entities.SalesOrderHeaderSalesReason _SalesOrderHeaderSalesReason;
		/// <summary>
		/// Gets or sets the <see cref="Entities.SalesOrderHeaderSalesReason"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.SalesOrderHeaderSalesReason"/> instance.</value>
		public Entities.SalesOrderHeaderSalesReason SalesOrderHeaderSalesReason
		{
			get {return this._SalesOrderHeaderSalesReason;}
			set
			{
				this._SalesOrderHeaderSalesReason = value;
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
			this.uxSalesOrderId.DataBindings.Clear();
			this.uxSalesOrderId.DataBindings.Add("SelectedValue", this.uxBindingSource, "SalesOrderId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalesReasonId.DataBindings.Clear();
			this.uxSalesReasonId.DataBindings.Add("SelectedValue", this.uxBindingSource, "SalesReasonId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SalesOrderHeaderSalesReasonEditControlBase"/> class.
		/// </summary>
		public SalesOrderHeaderSalesReasonEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_SalesOrderHeaderSalesReason != null) _SalesOrderHeaderSalesReason.Validate();
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
			this.uxSalesOrderId = new System.Windows.Forms.ComboBox();
			uxSalesOrderIdLabel = new System.Windows.Forms.Label();
			this.uxSalesReasonId = new System.Windows.Forms.ComboBox();
			uxSalesReasonIdLabel = new System.Windows.Forms.Label();
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
			// uxSalesOrderIdLabel
			//
			this.uxSalesOrderIdLabel.Name = "uxSalesOrderIdLabel";
			this.uxSalesOrderIdLabel.Text = "Sales Order Id:";
			this.uxSalesOrderIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxSalesOrderIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderIdLabel);			
			//
			// uxSalesOrderId
			//
			this.uxSalesOrderId.Name = "uxSalesOrderId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesOrderId);
			this.uxSalesOrderId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxSalesOrderId);
			//
			// uxSalesReasonIdLabel
			//
			this.uxSalesReasonIdLabel.Name = "uxSalesReasonIdLabel";
			this.uxSalesReasonIdLabel.Text = "Sales Reason Id:";
			this.uxSalesReasonIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxSalesReasonIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesReasonIdLabel);			
			//
			// uxSalesReasonId
			//
			this.uxSalesReasonId.Name = "uxSalesReasonId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalesReasonId);
			this.uxSalesReasonId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxSalesReasonId);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxSalesOrderId
			//				
			this.uxSalesOrderId.DisplayMember = "RevisionNumber";	
			this.uxSalesOrderId.ValueMember = "SalesOrderId";	
			//
			// uxSalesReasonId
			//				
			this.uxSalesReasonId.DisplayMember = "Name";	
			this.uxSalesReasonId.ValueMember = "SalesReasonId";	
			// 
			// SalesOrderHeaderSalesReasonEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "SalesOrderHeaderSalesReasonEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.SalesOrderHeader> _SalesOrderIdList;
		
		/// <summary>
		/// The ComboBox associated with the SalesOrderId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.SalesOrderHeader> SalesOrderIdList
		{
			get {return _SalesOrderIdList;}
			set 
			{
				this._SalesOrderIdList = value;
				this.uxSalesOrderId.DataSource = null;
				this.uxSalesOrderId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInSalesOrderIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the SalesOrderId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesOrderIdList
		{
			get { return _allowNewItemInSalesOrderIdList;}
			set
			{
				this._allowNewItemInSalesOrderIdList = value;
				this.uxSalesOrderId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.SalesReason> _SalesReasonIdList;
		
		/// <summary>
		/// The ComboBox associated with the SalesReasonId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.SalesReason> SalesReasonIdList
		{
			get {return _SalesReasonIdList;}
			set 
			{
				this._SalesReasonIdList = value;
				this.uxSalesReasonId.DataSource = null;
				this.uxSalesReasonId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInSalesReasonIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the SalesReasonId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesReasonIdList
		{
			get { return _allowNewItemInSalesReasonIdList;}
			set
			{
				this._allowNewItemInSalesReasonIdList = value;
				this.uxSalesReasonId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxSalesOrderId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalesOrderIdVisible
        {
            get { return this.uxSalesOrderId.Visible; }
            set
            {
                this.uxSalesOrderIdLabel.Visible = value;
                this.uxSalesOrderId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalesOrderId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalesOrderIdEnabled
        {
            get { return this.uxSalesOrderId.Enabled; }
            set
            {
                this.uxSalesOrderId.Enabled = value;
            }
        }
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
