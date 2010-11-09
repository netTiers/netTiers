
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.WorkOrderRouting"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class WorkOrderRoutingEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the WorkOrderId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxWorkOrderId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the WorkOrderId property.
		/// </summary>
		protected System.Windows.Forms.Label uxWorkOrderIdLabel;
		
		/// <summary>
		/// TextBox for the ProductId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// TextBox for the OperationSequence property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxOperationSequence;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OperationSequence property.
		/// </summary>
		protected System.Windows.Forms.Label uxOperationSequenceLabel;
		
		/// <summary>
		/// ComboBox for the LocationId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxLocationId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LocationId property.
		/// </summary>
		protected System.Windows.Forms.Label uxLocationIdLabel;
		
		/// <summary>
		/// DataTimePicker for the ScheduledStartDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxScheduledStartDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ScheduledStartDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxScheduledStartDateLabel;
		
		/// <summary>
		/// DataTimePicker for the ScheduledEndDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxScheduledEndDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ScheduledEndDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxScheduledEndDateLabel;
		
		/// <summary>
		/// DataTimePicker for the ActualStartDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxActualStartDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ActualStartDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxActualStartDateLabel;
		
		/// <summary>
		/// DataTimePicker for the ActualEndDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxActualEndDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ActualEndDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxActualEndDateLabel;
		
		/// <summary>
		/// TextBox for the ActualResourceHrs property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxActualResourceHrs;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ActualResourceHrs property.
		/// </summary>
		protected System.Windows.Forms.Label uxActualResourceHrsLabel;
		
		/// <summary>
		/// TextBox for the PlannedCost property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPlannedCost;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PlannedCost property.
		/// </summary>
		protected System.Windows.Forms.Label uxPlannedCostLabel;
		
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
		private Entities.WorkOrderRouting _WorkOrderRouting;
		/// <summary>
		/// Gets or sets the <see cref="Entities.WorkOrderRouting"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.WorkOrderRouting"/> instance.</value>
		public Entities.WorkOrderRouting WorkOrderRouting
		{
			get {return this._WorkOrderRouting;}
			set
			{
				this._WorkOrderRouting = value;
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
			this.uxWorkOrderId.DataBindings.Clear();
			this.uxWorkOrderId.DataBindings.Add("SelectedValue", this.uxBindingSource, "WorkOrderId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("Text", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOperationSequence.DataBindings.Clear();
			this.uxOperationSequence.DataBindings.Add("Text", this.uxBindingSource, "OperationSequence", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLocationId.DataBindings.Clear();
			this.uxLocationId.DataBindings.Add("SelectedValue", this.uxBindingSource, "LocationId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxScheduledStartDate.DataBindings.Clear();
			this.uxScheduledStartDate.DataBindings.Add("Value", this.uxBindingSource, "ScheduledStartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxScheduledEndDate.DataBindings.Clear();
			this.uxScheduledEndDate.DataBindings.Add("Value", this.uxBindingSource, "ScheduledEndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxActualStartDate.DataBindings.Clear();
			this.uxActualStartDate.DataBindings.Add("Value", this.uxBindingSource, "ActualStartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxActualEndDate.DataBindings.Clear();
			this.uxActualEndDate.DataBindings.Add("Value", this.uxBindingSource, "ActualEndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxActualResourceHrs.DataBindings.Clear();
			this.uxActualResourceHrs.DataBindings.Add("Text", this.uxBindingSource, "ActualResourceHrs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPlannedCost.DataBindings.Clear();
			this.uxPlannedCost.DataBindings.Add("Text", this.uxBindingSource, "PlannedCost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxActualCost.DataBindings.Clear();
			this.uxActualCost.DataBindings.Add("Text", this.uxBindingSource, "ActualCost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="WorkOrderRoutingEditControlBase"/> class.
		/// </summary>
		public WorkOrderRoutingEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_WorkOrderRouting != null) _WorkOrderRouting.Validate();
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
			this.uxWorkOrderId = new System.Windows.Forms.ComboBox();
			uxWorkOrderIdLabel = new System.Windows.Forms.Label();
			this.uxProductId = new System.Windows.Forms.TextBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxOperationSequence = new System.Windows.Forms.TextBox();
			uxOperationSequenceLabel = new System.Windows.Forms.Label();
			this.uxLocationId = new System.Windows.Forms.ComboBox();
			uxLocationIdLabel = new System.Windows.Forms.Label();
			this.uxScheduledStartDate = new System.Windows.Forms.DateTimePicker();
			uxScheduledStartDateLabel = new System.Windows.Forms.Label();
			this.uxScheduledEndDate = new System.Windows.Forms.DateTimePicker();
			uxScheduledEndDateLabel = new System.Windows.Forms.Label();
			this.uxActualStartDate = new System.Windows.Forms.DateTimePicker();
			uxActualStartDateLabel = new System.Windows.Forms.Label();
			this.uxActualEndDate = new System.Windows.Forms.DateTimePicker();
			uxActualEndDateLabel = new System.Windows.Forms.Label();
			this.uxActualResourceHrs = new System.Windows.Forms.TextBox();
			uxActualResourceHrsLabel = new System.Windows.Forms.Label();
			this.uxPlannedCost = new System.Windows.Forms.TextBox();
			uxPlannedCostLabel = new System.Windows.Forms.Label();
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
			// uxWorkOrderIdLabel
			//
			this.uxWorkOrderIdLabel.Name = "uxWorkOrderIdLabel";
			this.uxWorkOrderIdLabel.Text = "Work Order Id:";
			this.uxWorkOrderIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxWorkOrderIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxWorkOrderIdLabel);			
			//
			// uxWorkOrderId
			//
			this.uxWorkOrderId.Name = "uxWorkOrderId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxWorkOrderId);
			this.uxWorkOrderId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxWorkOrderId);
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
			// uxOperationSequenceLabel
			//
			this.uxOperationSequenceLabel.Name = "uxOperationSequenceLabel";
			this.uxOperationSequenceLabel.Text = "Operation Sequence:";
			this.uxOperationSequenceLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxOperationSequenceLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOperationSequenceLabel);			
			//
			// uxOperationSequence
			//
			this.uxOperationSequence.Name = "uxOperationSequence";
			//this.uxTableLayoutPanel.Controls.Add(this.uxOperationSequence);
			this.uxOperationSequence.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxOperationSequence);
			//
			// uxLocationIdLabel
			//
			this.uxLocationIdLabel.Name = "uxLocationIdLabel";
			this.uxLocationIdLabel.Text = "Location Id:";
			this.uxLocationIdLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxLocationIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLocationIdLabel);			
			//
			// uxLocationId
			//
			this.uxLocationId.Name = "uxLocationId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxLocationId);
			this.uxLocationId.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxLocationId);
			//
			// uxScheduledStartDateLabel
			//
			this.uxScheduledStartDateLabel.Name = "uxScheduledStartDateLabel";
			this.uxScheduledStartDateLabel.Text = "Scheduled Start Date:";
			this.uxScheduledStartDateLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxScheduledStartDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxScheduledStartDateLabel);			
			//
			// uxScheduledStartDate
			//
			this.uxScheduledStartDate.Name = "uxScheduledStartDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxScheduledStartDate);
			this.uxScheduledStartDate.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxScheduledStartDate);
			//
			// uxScheduledEndDateLabel
			//
			this.uxScheduledEndDateLabel.Name = "uxScheduledEndDateLabel";
			this.uxScheduledEndDateLabel.Text = "Scheduled End Date:";
			this.uxScheduledEndDateLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxScheduledEndDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxScheduledEndDateLabel);			
			//
			// uxScheduledEndDate
			//
			this.uxScheduledEndDate.Name = "uxScheduledEndDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxScheduledEndDate);
			this.uxScheduledEndDate.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxScheduledEndDate);
			//
			// uxActualStartDateLabel
			//
			this.uxActualStartDateLabel.Name = "uxActualStartDateLabel";
			this.uxActualStartDateLabel.Text = "Actual Start Date:";
			this.uxActualStartDateLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxActualStartDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualStartDateLabel);			
			//
			// uxActualStartDate
			//
			this.uxActualStartDate.Name = "uxActualStartDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualStartDate);
			this.uxActualStartDate.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxActualStartDate);
			//
			// uxActualEndDateLabel
			//
			this.uxActualEndDateLabel.Name = "uxActualEndDateLabel";
			this.uxActualEndDateLabel.Text = "Actual End Date:";
			this.uxActualEndDateLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxActualEndDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualEndDateLabel);			
			//
			// uxActualEndDate
			//
			this.uxActualEndDate.Name = "uxActualEndDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualEndDate);
			this.uxActualEndDate.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxActualEndDate);
			//
			// uxActualResourceHrsLabel
			//
			this.uxActualResourceHrsLabel.Name = "uxActualResourceHrsLabel";
			this.uxActualResourceHrsLabel.Text = "Actual Resource Hrs:";
			this.uxActualResourceHrsLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxActualResourceHrsLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualResourceHrsLabel);			
			//
			// uxActualResourceHrs
			//
			this.uxActualResourceHrs.Name = "uxActualResourceHrs";
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualResourceHrs);
			this.uxActualResourceHrs.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxActualResourceHrs);
			//
			// uxPlannedCostLabel
			//
			this.uxPlannedCostLabel.Name = "uxPlannedCostLabel";
			this.uxPlannedCostLabel.Text = "Planned Cost:";
			this.uxPlannedCostLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxPlannedCostLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPlannedCostLabel);			
			//
			// uxPlannedCost
			//
			this.uxPlannedCost.Name = "uxPlannedCost";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPlannedCost);
			this.uxPlannedCost.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxPlannedCost);
			//
			// uxActualCostLabel
			//
			this.uxActualCostLabel.Name = "uxActualCostLabel";
			this.uxActualCostLabel.Text = "Actual Cost:";
			this.uxActualCostLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxActualCostLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualCostLabel);			
			//
			// uxActualCost
			//
			this.uxActualCost.Name = "uxActualCost";
			//this.uxTableLayoutPanel.Controls.Add(this.uxActualCost);
			this.uxActualCost.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxActualCost);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxLocationId
			//				
			this.uxLocationId.DisplayMember = "Name";	
			this.uxLocationId.ValueMember = "LocationId";	
			//
			// uxWorkOrderId
			//				
			this.uxWorkOrderId.DisplayMember = "ProductId";	
			this.uxWorkOrderId.ValueMember = "WorkOrderId";	
			// 
			// WorkOrderRoutingEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "WorkOrderRoutingEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Location> _LocationIdList;
		
		/// <summary>
		/// The ComboBox associated with the LocationId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Location> LocationIdList
		{
			get {return _LocationIdList;}
			set 
			{
				this._LocationIdList = value;
				this.uxLocationId.DataSource = null;
				this.uxLocationId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInLocationIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the LocationId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInLocationIdList
		{
			get { return _allowNewItemInLocationIdList;}
			set
			{
				this._allowNewItemInLocationIdList = value;
				this.uxLocationId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.WorkOrder> _WorkOrderIdList;
		
		/// <summary>
		/// The ComboBox associated with the WorkOrderId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.WorkOrder> WorkOrderIdList
		{
			get {return _WorkOrderIdList;}
			set 
			{
				this._WorkOrderIdList = value;
				this.uxWorkOrderId.DataSource = null;
				this.uxWorkOrderId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInWorkOrderIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the WorkOrderId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInWorkOrderIdList
		{
			get { return _allowNewItemInWorkOrderIdList;}
			set
			{
				this._allowNewItemInWorkOrderIdList = value;
				this.uxWorkOrderId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxWorkOrderId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxWorkOrderIdVisible
        {
            get { return this.uxWorkOrderId.Visible; }
            set
            {
                this.uxWorkOrderIdLabel.Visible = value;
                this.uxWorkOrderId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxWorkOrderId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxWorkOrderIdEnabled
        {
            get { return this.uxWorkOrderId.Enabled; }
            set
            {
                this.uxWorkOrderId.Enabled = value;
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
        /// Indicates if the controls associated with the uxOperationSequence property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxOperationSequenceVisible
        {
            get { return this.uxOperationSequence.Visible; }
            set
            {
                this.uxOperationSequenceLabel.Visible = value;
                this.uxOperationSequence.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxOperationSequence property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxOperationSequenceEnabled
        {
            get { return this.uxOperationSequence.Enabled; }
            set
            {
                this.uxOperationSequence.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLocationId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLocationIdVisible
        {
            get { return this.uxLocationId.Visible; }
            set
            {
                this.uxLocationIdLabel.Visible = value;
                this.uxLocationId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLocationId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLocationIdEnabled
        {
            get { return this.uxLocationId.Enabled; }
            set
            {
                this.uxLocationId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxScheduledStartDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxScheduledStartDateVisible
        {
            get { return this.uxScheduledStartDate.Visible; }
            set
            {
                this.uxScheduledStartDateLabel.Visible = value;
                this.uxScheduledStartDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxScheduledStartDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxScheduledStartDateEnabled
        {
            get { return this.uxScheduledStartDate.Enabled; }
            set
            {
                this.uxScheduledStartDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxScheduledEndDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxScheduledEndDateVisible
        {
            get { return this.uxScheduledEndDate.Visible; }
            set
            {
                this.uxScheduledEndDateLabel.Visible = value;
                this.uxScheduledEndDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxScheduledEndDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxScheduledEndDateEnabled
        {
            get { return this.uxScheduledEndDate.Enabled; }
            set
            {
                this.uxScheduledEndDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxActualStartDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxActualStartDateVisible
        {
            get { return this.uxActualStartDate.Visible; }
            set
            {
                this.uxActualStartDateLabel.Visible = value;
                this.uxActualStartDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxActualStartDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxActualStartDateEnabled
        {
            get { return this.uxActualStartDate.Enabled; }
            set
            {
                this.uxActualStartDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxActualEndDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxActualEndDateVisible
        {
            get { return this.uxActualEndDate.Visible; }
            set
            {
                this.uxActualEndDateLabel.Visible = value;
                this.uxActualEndDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxActualEndDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxActualEndDateEnabled
        {
            get { return this.uxActualEndDate.Enabled; }
            set
            {
                this.uxActualEndDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxActualResourceHrs property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxActualResourceHrsVisible
        {
            get { return this.uxActualResourceHrs.Visible; }
            set
            {
                this.uxActualResourceHrsLabel.Visible = value;
                this.uxActualResourceHrs.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxActualResourceHrs property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxActualResourceHrsEnabled
        {
            get { return this.uxActualResourceHrs.Enabled; }
            set
            {
                this.uxActualResourceHrs.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPlannedCost property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPlannedCostVisible
        {
            get { return this.uxPlannedCost.Visible; }
            set
            {
                this.uxPlannedCostLabel.Visible = value;
                this.uxPlannedCost.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPlannedCost property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPlannedCostEnabled
        {
            get { return this.uxPlannedCost.Enabled; }
            set
            {
                this.uxPlannedCost.Enabled = value;
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
