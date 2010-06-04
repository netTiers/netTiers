
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.EmployeeDepartmentHistory"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class EmployeeDepartmentHistoryEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxEmployeeId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmployeeIdLabel;
		
		/// <summary>
		/// ComboBox for the DepartmentId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxDepartmentId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DepartmentId property.
		/// </summary>
		protected System.Windows.Forms.Label uxDepartmentIdLabel;
		
		/// <summary>
		/// ComboBox for the ShiftId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxShiftId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShiftId property.
		/// </summary>
		protected System.Windows.Forms.Label uxShiftIdLabel;
		
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
		/// DataTimePicker for the ModifiedDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxModifiedDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ModifiedDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxModifiedDateLabel;
		#endregion
		
		#region Main entity
		private Entities.EmployeeDepartmentHistory _EmployeeDepartmentHistory;
		/// <summary>
		/// Gets or sets the <see cref="Entities.EmployeeDepartmentHistory"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.EmployeeDepartmentHistory"/> instance.</value>
		public Entities.EmployeeDepartmentHistory EmployeeDepartmentHistory
		{
			get {return this._EmployeeDepartmentHistory;}
			set
			{
				this._EmployeeDepartmentHistory = value;
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
			this.uxEmployeeId.DataBindings.Clear();
			this.uxEmployeeId.DataBindings.Add("SelectedValue", this.uxBindingSource, "EmployeeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDepartmentId.DataBindings.Clear();
			this.uxDepartmentId.DataBindings.Add("SelectedValue", this.uxBindingSource, "DepartmentId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShiftId.DataBindings.Clear();
			this.uxShiftId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ShiftId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStartDate.DataBindings.Clear();
			this.uxStartDate.DataBindings.Add("Value", this.uxBindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEndDate.DataBindings.Clear();
			this.uxEndDate.DataBindings.Add("Value", this.uxBindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeDepartmentHistoryEditControlBase"/> class.
		/// </summary>
		public EmployeeDepartmentHistoryEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_EmployeeDepartmentHistory != null) _EmployeeDepartmentHistory.Validate();
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
			this.uxEmployeeId = new System.Windows.Forms.ComboBox();
			uxEmployeeIdLabel = new System.Windows.Forms.Label();
			this.uxDepartmentId = new System.Windows.Forms.ComboBox();
			uxDepartmentIdLabel = new System.Windows.Forms.Label();
			this.uxShiftId = new System.Windows.Forms.ComboBox();
			uxShiftIdLabel = new System.Windows.Forms.Label();
			this.uxStartDate = new System.Windows.Forms.DateTimePicker();
			uxStartDateLabel = new System.Windows.Forms.Label();
			this.uxEndDate = new System.Windows.Forms.DateTimePicker();
			uxEndDateLabel = new System.Windows.Forms.Label();
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
			// uxEmployeeIdLabel
			//
			this.uxEmployeeIdLabel.Name = "uxEmployeeIdLabel";
			this.uxEmployeeIdLabel.Text = "Employee Id:";
			this.uxEmployeeIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxEmployeeIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeIdLabel);			
			//
			// uxEmployeeId
			//
			this.uxEmployeeId.Name = "uxEmployeeId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeId);
			this.uxEmployeeId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxEmployeeId);
			//
			// uxDepartmentIdLabel
			//
			this.uxDepartmentIdLabel.Name = "uxDepartmentIdLabel";
			this.uxDepartmentIdLabel.Text = "Department Id:";
			this.uxDepartmentIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxDepartmentIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDepartmentIdLabel);			
			//
			// uxDepartmentId
			//
			this.uxDepartmentId.Name = "uxDepartmentId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDepartmentId);
			this.uxDepartmentId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxDepartmentId);
			//
			// uxShiftIdLabel
			//
			this.uxShiftIdLabel.Name = "uxShiftIdLabel";
			this.uxShiftIdLabel.Text = "Shift Id:";
			this.uxShiftIdLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxShiftIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShiftIdLabel);			
			//
			// uxShiftId
			//
			this.uxShiftId.Name = "uxShiftId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxShiftId);
			this.uxShiftId.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxShiftId);
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
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxDepartmentId
			//				
			this.uxDepartmentId.DisplayMember = "Name";	
			this.uxDepartmentId.ValueMember = "DepartmentId";	
			//
			// uxEmployeeId
			//				
			this.uxEmployeeId.DisplayMember = "NationalIdNumber";	
			this.uxEmployeeId.ValueMember = "EmployeeId";	
			//
			// uxShiftId
			//				
			this.uxShiftId.DisplayMember = "Name";	
			this.uxShiftId.ValueMember = "ShiftId";	
			// 
			// EmployeeDepartmentHistoryEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "EmployeeDepartmentHistoryEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Department> _DepartmentIdList;
		
		/// <summary>
		/// The ComboBox associated with the DepartmentId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Department> DepartmentIdList
		{
			get {return _DepartmentIdList;}
			set 
			{
				this._DepartmentIdList = value;
				this.uxDepartmentId.DataSource = null;
				this.uxDepartmentId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInDepartmentIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the DepartmentId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInDepartmentIdList
		{
			get { return _allowNewItemInDepartmentIdList;}
			set
			{
				this._allowNewItemInDepartmentIdList = value;
				this.uxDepartmentId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Employee> _EmployeeIdList;
		
		/// <summary>
		/// The ComboBox associated with the EmployeeId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Employee> EmployeeIdList
		{
			get {return _EmployeeIdList;}
			set 
			{
				this._EmployeeIdList = value;
				this.uxEmployeeId.DataSource = null;
				this.uxEmployeeId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInEmployeeIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the EmployeeId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInEmployeeIdList
		{
			get { return _allowNewItemInEmployeeIdList;}
			set
			{
				this._allowNewItemInEmployeeIdList = value;
				this.uxEmployeeId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Shift> _ShiftIdList;
		
		/// <summary>
		/// The ComboBox associated with the ShiftId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Shift> ShiftIdList
		{
			get {return _ShiftIdList;}
			set 
			{
				this._ShiftIdList = value;
				this.uxShiftId.DataSource = null;
				this.uxShiftId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInShiftIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ShiftId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInShiftIdList
		{
			get { return _allowNewItemInShiftIdList;}
			set
			{
				this._allowNewItemInShiftIdList = value;
				this.uxShiftId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEmployeeIdVisible
        {
            get { return this.uxEmployeeId.Visible; }
            set
            {
                this.uxEmployeeIdLabel.Visible = value;
                this.uxEmployeeId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEmployeeIdEnabled
        {
            get { return this.uxEmployeeId.Enabled; }
            set
            {
                this.uxEmployeeId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDepartmentId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDepartmentIdVisible
        {
            get { return this.uxDepartmentId.Visible; }
            set
            {
                this.uxDepartmentIdLabel.Visible = value;
                this.uxDepartmentId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDepartmentId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDepartmentIdEnabled
        {
            get { return this.uxDepartmentId.Enabled; }
            set
            {
                this.uxDepartmentId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxShiftId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShiftIdVisible
        {
            get { return this.uxShiftId.Visible; }
            set
            {
                this.uxShiftIdLabel.Visible = value;
                this.uxShiftId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShiftId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShiftIdEnabled
        {
            get { return this.uxShiftId.Enabled; }
            set
            {
                this.uxShiftId.Enabled = value;
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
