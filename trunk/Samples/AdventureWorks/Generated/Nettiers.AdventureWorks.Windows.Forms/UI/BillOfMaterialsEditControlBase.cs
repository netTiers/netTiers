
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.BillOfMaterials"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class BillOfMaterialsEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the BillOfMaterialsId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxBillOfMaterialsId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the BillOfMaterialsId property.
		/// </summary>
		protected System.Windows.Forms.Label uxBillOfMaterialsIdLabel;
		
		/// <summary>
		/// ComboBox for the ProductAssemblyId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductAssemblyId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductAssemblyId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductAssemblyIdLabel;
		
		/// <summary>
		/// ComboBox for the ComponentId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxComponentId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ComponentId property.
		/// </summary>
		protected System.Windows.Forms.Label uxComponentIdLabel;
		
		/// <summary>
		/// DataTimePicker for the StartDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxStartDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StartDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxStartDateLabel;
		
		/// <summary>
		/// DataTimePicker for the EndDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxEndDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EndDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxEndDateLabel;
		
		/// <summary>
		/// ComboBox for the UnitMeasureCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxUnitMeasureCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UnitMeasureCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxUnitMeasureCodeLabel;
		
		/// <summary>
		/// TextBox for the BomLevel property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxBomLevel;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the BomLevel property.
		/// </summary>
		protected System.Windows.Forms.Label uxBomLevelLabel;
		
		/// <summary>
		/// TextBox for the PerAssemblyQty property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPerAssemblyQty;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PerAssemblyQty property.
		/// </summary>
		protected System.Windows.Forms.Label uxPerAssemblyQtyLabel;
		
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
		private Entities.BillOfMaterials _BillOfMaterials;
		/// <summary>
		/// Gets or sets the <see cref="Entities.BillOfMaterials"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.BillOfMaterials"/> instance.</value>
		public Entities.BillOfMaterials BillOfMaterials
		{
			get {return this._BillOfMaterials;}
			set
			{
				this._BillOfMaterials = value;
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
			this.uxBillOfMaterialsId.DataBindings.Clear();
			this.uxBillOfMaterialsId.DataBindings.Add("Text", this.uxBindingSource, "BillOfMaterialsId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductAssemblyId.DataBindings.Clear();
			this.uxProductAssemblyId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductAssemblyId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxComponentId.DataBindings.Clear();
			this.uxComponentId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ComponentId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStartDate.DataBindings.Clear();
			this.uxStartDate.DataBindings.Add("Value", this.uxBindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEndDate.DataBindings.Clear();
			this.uxEndDate.DataBindings.Add("Value", this.uxBindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUnitMeasureCode.DataBindings.Clear();
			this.uxUnitMeasureCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "UnitMeasureCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBomLevel.DataBindings.Clear();
			this.uxBomLevel.DataBindings.Add("Text", this.uxBindingSource, "BomLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPerAssemblyQty.DataBindings.Clear();
			this.uxPerAssemblyQty.DataBindings.Add("Text", this.uxBindingSource, "PerAssemblyQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="BillOfMaterialsEditControlBase"/> class.
		/// </summary>
		public BillOfMaterialsEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_BillOfMaterials != null) _BillOfMaterials.Validate();
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
			this.uxBillOfMaterialsId = new System.Windows.Forms.TextBox();
			uxBillOfMaterialsIdLabel = new System.Windows.Forms.Label();
			this.uxProductAssemblyId = new System.Windows.Forms.ComboBox();
			uxProductAssemblyIdLabel = new System.Windows.Forms.Label();
			this.uxComponentId = new System.Windows.Forms.ComboBox();
			uxComponentIdLabel = new System.Windows.Forms.Label();
			this.uxStartDate = new System.Windows.Forms.DateTimePicker();
			uxStartDateLabel = new System.Windows.Forms.Label();
			this.uxEndDate = new System.Windows.Forms.DateTimePicker();
			uxEndDateLabel = new System.Windows.Forms.Label();
			this.uxUnitMeasureCode = new System.Windows.Forms.ComboBox();
			uxUnitMeasureCodeLabel = new System.Windows.Forms.Label();
			this.uxBomLevel = new System.Windows.Forms.TextBox();
			uxBomLevelLabel = new System.Windows.Forms.Label();
			this.uxPerAssemblyQty = new System.Windows.Forms.TextBox();
			uxPerAssemblyQtyLabel = new System.Windows.Forms.Label();
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
			// uxBillOfMaterialsIdLabel
			//
			this.uxBillOfMaterialsIdLabel.Name = "uxBillOfMaterialsIdLabel";
			this.uxBillOfMaterialsIdLabel.Text = "Bill Of Materials Id:";
			this.uxBillOfMaterialsIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxBillOfMaterialsIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBillOfMaterialsIdLabel);			
			//
			// uxBillOfMaterialsId
			//
			this.uxBillOfMaterialsId.Name = "uxBillOfMaterialsId";
            this.uxBillOfMaterialsId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxBillOfMaterialsId);
			this.uxBillOfMaterialsId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxBillOfMaterialsId);
			//
			// uxProductAssemblyIdLabel
			//
			this.uxProductAssemblyIdLabel.Name = "uxProductAssemblyIdLabel";
			this.uxProductAssemblyIdLabel.Text = "Product Assembly Id:";
			this.uxProductAssemblyIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxProductAssemblyIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductAssemblyIdLabel);			
			//
			// uxProductAssemblyId
			//
			this.uxProductAssemblyId.Name = "uxProductAssemblyId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductAssemblyId);
			this.uxProductAssemblyId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxProductAssemblyId);
			//
			// uxComponentIdLabel
			//
			this.uxComponentIdLabel.Name = "uxComponentIdLabel";
			this.uxComponentIdLabel.Text = "Component Id:";
			this.uxComponentIdLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxComponentIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxComponentIdLabel);			
			//
			// uxComponentId
			//
			this.uxComponentId.Name = "uxComponentId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxComponentId);
			this.uxComponentId.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxComponentId);
			//
			// uxStartDateLabel
			//
			this.uxStartDateLabel.Name = "uxStartDateLabel";
			this.uxStartDateLabel.Text = "Start Date:";
			this.uxStartDateLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxStartDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStartDateLabel);			
			//
			// uxStartDate
			//
			this.uxStartDate.Name = "uxStartDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStartDate);
			this.uxStartDate.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxStartDate);
			//
			// uxEndDateLabel
			//
			this.uxEndDateLabel.Name = "uxEndDateLabel";
			this.uxEndDateLabel.Text = "End Date:";
			this.uxEndDateLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxEndDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEndDateLabel);			
			//
			// uxEndDate
			//
			this.uxEndDate.Name = "uxEndDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEndDate);
			this.uxEndDate.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxEndDate);
			//
			// uxUnitMeasureCodeLabel
			//
			this.uxUnitMeasureCodeLabel.Name = "uxUnitMeasureCodeLabel";
			this.uxUnitMeasureCodeLabel.Text = "Unit Measure Code:";
			this.uxUnitMeasureCodeLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxUnitMeasureCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitMeasureCodeLabel);			
			//
			// uxUnitMeasureCode
			//
			this.uxUnitMeasureCode.Name = "uxUnitMeasureCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUnitMeasureCode);
			this.uxUnitMeasureCode.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxUnitMeasureCode);
			//
			// uxBomLevelLabel
			//
			this.uxBomLevelLabel.Name = "uxBomLevelLabel";
			this.uxBomLevelLabel.Text = "Bom Level:";
			this.uxBomLevelLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxBomLevelLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBomLevelLabel);			
			//
			// uxBomLevel
			//
			this.uxBomLevel.Name = "uxBomLevel";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBomLevel);
			this.uxBomLevel.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxBomLevel);
			//
			// uxPerAssemblyQtyLabel
			//
			this.uxPerAssemblyQtyLabel.Name = "uxPerAssemblyQtyLabel";
			this.uxPerAssemblyQtyLabel.Text = "Per Assembly Qty:";
			this.uxPerAssemblyQtyLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxPerAssemblyQtyLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPerAssemblyQtyLabel);			
			//
			// uxPerAssemblyQty
			//
			this.uxPerAssemblyQty.Name = "uxPerAssemblyQty";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPerAssemblyQty);
			this.uxPerAssemblyQty.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxPerAssemblyQty);
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
			// uxComponentId
			//				
			this.uxComponentId.DisplayMember = "Name";	
			this.uxComponentId.ValueMember = "ProductId";	
			//
			// uxProductAssemblyId
			//				
			this.uxProductAssemblyId.DisplayMember = "Name";	
			this.uxProductAssemblyId.ValueMember = "ProductId";	
			//
			// uxUnitMeasureCode
			//				
			this.uxUnitMeasureCode.DisplayMember = "Name";	
			this.uxUnitMeasureCode.ValueMember = "UnitMeasureCode";	
			// 
			// BillOfMaterialsEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "BillOfMaterialsEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Product> _ComponentIdList;
		
		/// <summary>
		/// The ComboBox associated with the ComponentId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Product> ComponentIdList
		{
			get {return _ComponentIdList;}
			set 
			{
				this._ComponentIdList = value;
				this.uxComponentId.DataSource = null;
				this.uxComponentId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInComponentIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ComponentId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInComponentIdList
		{
			get { return _allowNewItemInComponentIdList;}
			set
			{
				this._allowNewItemInComponentIdList = value;
				this.uxComponentId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Product> _ProductAssemblyIdList;
		
		/// <summary>
		/// The ComboBox associated with the ProductAssemblyId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Product> ProductAssemblyIdList
		{
			get {return _ProductAssemblyIdList;}
			set 
			{
				this._ProductAssemblyIdList = value;
				this.uxProductAssemblyId.DataSource = null;
				this.uxProductAssemblyId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInProductAssemblyIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ProductAssemblyId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductAssemblyIdList
		{
			get { return _allowNewItemInProductAssemblyIdList;}
			set
			{
				this._allowNewItemInProductAssemblyIdList = value;
				this.uxProductAssemblyId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.UnitMeasure> _UnitMeasureCodeList;
		
		/// <summary>
		/// The ComboBox associated with the UnitMeasureCode property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.UnitMeasure> UnitMeasureCodeList
		{
			get {return _UnitMeasureCodeList;}
			set 
			{
				this._UnitMeasureCodeList = value;
				this.uxUnitMeasureCode.DataSource = null;
				this.uxUnitMeasureCode.DataSource = value;
			}
		}
		
		private bool _allowNewItemInUnitMeasureCodeList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the UnitMeasureCode property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInUnitMeasureCodeList
		{
			get { return _allowNewItemInUnitMeasureCodeList;}
			set
			{
				this._allowNewItemInUnitMeasureCodeList = value;
				this.uxUnitMeasureCode.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxBillOfMaterialsId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBillOfMaterialsIdVisible
        {
            get { return this.uxBillOfMaterialsId.Visible; }
            set
            {
                this.uxBillOfMaterialsIdLabel.Visible = value;
                this.uxBillOfMaterialsId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBillOfMaterialsId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBillOfMaterialsIdEnabled
        {
            get { return this.uxBillOfMaterialsId.Enabled; }
            set
            {
                this.uxBillOfMaterialsId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductAssemblyId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductAssemblyIdVisible
        {
            get { return this.uxProductAssemblyId.Visible; }
            set
            {
                this.uxProductAssemblyIdLabel.Visible = value;
                this.uxProductAssemblyId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductAssemblyId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductAssemblyIdEnabled
        {
            get { return this.uxProductAssemblyId.Enabled; }
            set
            {
                this.uxProductAssemblyId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxComponentId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxComponentIdVisible
        {
            get { return this.uxComponentId.Visible; }
            set
            {
                this.uxComponentIdLabel.Visible = value;
                this.uxComponentId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxComponentId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxComponentIdEnabled
        {
            get { return this.uxComponentId.Enabled; }
            set
            {
                this.uxComponentId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStartDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStartDateVisible
        {
            get { return this.uxStartDate.Visible; }
            set
            {
                this.uxStartDateLabel.Visible = value;
                this.uxStartDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStartDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStartDateEnabled
        {
            get { return this.uxStartDate.Enabled; }
            set
            {
                this.uxStartDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEndDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEndDateVisible
        {
            get { return this.uxEndDate.Visible; }
            set
            {
                this.uxEndDateLabel.Visible = value;
                this.uxEndDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEndDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEndDateEnabled
        {
            get { return this.uxEndDate.Enabled; }
            set
            {
                this.uxEndDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUnitMeasureCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUnitMeasureCodeVisible
        {
            get { return this.uxUnitMeasureCode.Visible; }
            set
            {
                this.uxUnitMeasureCodeLabel.Visible = value;
                this.uxUnitMeasureCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUnitMeasureCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUnitMeasureCodeEnabled
        {
            get { return this.uxUnitMeasureCode.Enabled; }
            set
            {
                this.uxUnitMeasureCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBomLevel property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBomLevelVisible
        {
            get { return this.uxBomLevel.Visible; }
            set
            {
                this.uxBomLevelLabel.Visible = value;
                this.uxBomLevel.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBomLevel property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBomLevelEnabled
        {
            get { return this.uxBomLevel.Enabled; }
            set
            {
                this.uxBomLevel.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPerAssemblyQty property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPerAssemblyQtyVisible
        {
            get { return this.uxPerAssemblyQty.Visible; }
            set
            {
                this.uxPerAssemblyQtyLabel.Visible = value;
                this.uxPerAssemblyQty.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPerAssemblyQty property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPerAssemblyQtyEnabled
        {
            get { return this.uxPerAssemblyQty.Enabled; }
            set
            {
                this.uxPerAssemblyQty.Enabled = value;
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
