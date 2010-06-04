
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Employee typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class EmployeeDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<EmployeeDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Employee _currentEmployee = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxEmployeeDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxEmployeeErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxEmployeeBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the EmployeeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEmployeeIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the NationalIdNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNationalIdNumberDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ContactId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxContactIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LoginId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLoginIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ManagerId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxManagerIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Title property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTitleDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the BirthDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBirthDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the MaritalStatus property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxMaritalStatusDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Gender property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxGenderDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the HireDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxHireDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalariedFlag property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxSalariedFlagDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the VacationHours property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxVacationHoursDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SickLeaveHours property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSickLeaveHoursDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CurrentFlag property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxCurrentFlagDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Rowguid property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRowguidDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Contact> _ContactIdList;
		
		/// <summary> 
		/// The list of selectable Contact
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Contact> ContactIdList
		{
			get {return this._ContactIdList;}
			set 
			{
				this._ContactIdList = value;
				this.uxContactIdDataGridViewColumn.DataSource = null;
				this.uxContactIdDataGridViewColumn.DataSource = this._ContactIdList;
			}
		}
		
		private bool _allowNewItemInContactIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Contact
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactIdList
		{
			get { return _allowNewItemInContactIdList;}
			set
			{
				this._allowNewItemInContactIdList = value;
				this.uxContactIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Employee> _ManagerIdList;
		
		/// <summary> 
		/// The list of selectable Employee
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Employee> ManagerIdList
		{
			get {return this._ManagerIdList;}
			set 
			{
				this._ManagerIdList = value;
				this.uxManagerIdDataGridViewColumn.DataSource = null;
				this.uxManagerIdDataGridViewColumn.DataSource = this._ManagerIdList;
			}
		}
		
		private bool _allowNewItemInManagerIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Employee
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInManagerIdList
		{
			get { return _allowNewItemInManagerIdList;}
			set
			{
				this._allowNewItemInManagerIdList = value;
				this.uxManagerIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Employee> _EmployeeList;
				
		/// <summary> 
		/// The list of Employee to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Employee> EmployeeList
		{
			get {return this._EmployeeList;}
			set
			{
				this._EmployeeList = value;
				this.uxEmployeeBindingSource.DataSource = null;
				this.uxEmployeeBindingSource.DataSource = value;
				this.uxEmployeeDataGridView.DataSource = null;
				this.uxEmployeeDataGridView.DataSource = this.uxEmployeeBindingSource;				
				//this.uxEmployeeBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxEmployeeBindingSource_ListChanged);
				this.uxEmployeeBindingSource.CurrentItemChanged += new System.EventHandler(OnEmployeeBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnEmployeeBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentEmployee = uxEmployeeBindingSource.Current as Entities.Employee;
			
			if (_currentEmployee != null)
			{
				_currentEmployee.Validate();
			}
			//_Employee.Validate();
			OnCurrentEntityChanged();
		}

		//void uxEmployeeBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Employee"/> instance.
		/// </summary>
		public Entities.Employee SelectedEmployee
		{
			get {return this._currentEmployee;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxEmployeeDataGridView.VirtualMode;}
			set
			{
				this.uxEmployeeDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxEmployeeDataGridView.AllowUserToAddRows;}
			set {this.uxEmployeeDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxEmployeeDataGridView.AllowUserToDeleteRows;}
			set {this.uxEmployeeDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxEmployeeDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxEmployeeDataGridView.Columns; }
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
	
		#region Constructor
	
		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeDataGridViewBase"/> class.
		/// </summary>
		public EmployeeDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxEmployeeDataGridView = new System.Windows.Forms.DataGridView();
			this.uxEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxEmployeeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxEmployeeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNationalIdNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxContactIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxLoginIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxManagerIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxTitleDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBirthDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMaritalStatusDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxGenderDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxHireDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSalariedFlagDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxVacationHoursDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSickLeaveHoursDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCurrentFlagDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxContactIdBindingSource = new ContactBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).BeginInit();
			//this.uxManagerIdBindingSource = new EmployeeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxManagerIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxEmployeeErrorProvider
			// 
			this.uxEmployeeErrorProvider.ContainerControl = this;
			this.uxEmployeeErrorProvider.DataSource = this.uxEmployeeBindingSource;						
			// 
			// uxEmployeeDataGridView
			// 
			this.uxEmployeeDataGridView.AutoGenerateColumns = false;
			this.uxEmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxEmployeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxEmployeeIdDataGridViewColumn,
		this.uxNationalIdNumberDataGridViewColumn,
		this.uxContactIdDataGridViewColumn,
		this.uxLoginIdDataGridViewColumn,
		this.uxManagerIdDataGridViewColumn,
		this.uxTitleDataGridViewColumn,
		this.uxBirthDateDataGridViewColumn,
		this.uxMaritalStatusDataGridViewColumn,
		this.uxGenderDataGridViewColumn,
		this.uxHireDateDataGridViewColumn,
		this.uxSalariedFlagDataGridViewColumn,
		this.uxVacationHoursDataGridViewColumn,
		this.uxSickLeaveHoursDataGridViewColumn,
		this.uxCurrentFlagDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxEmployeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxEmployeeDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxEmployeeDataGridView.Name = "uxEmployeeDataGridView";
			this.uxEmployeeDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxEmployeeDataGridView.TabIndex = 0;	
			this.uxEmployeeDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxEmployeeDataGridView.EnableHeadersVisualStyles = false;
			this.uxEmployeeDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnEmployeeDataGridViewDataError);
			this.uxEmployeeDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeeDataGridViewCellValueNeeded);
			this.uxEmployeeDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeeDataGridViewCellValuePushed);
			
			//
			// uxEmployeeIdDataGridViewColumn
			//
			this.uxEmployeeIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEmployeeIdDataGridViewColumn.DataPropertyName = "EmployeeId";
			this.uxEmployeeIdDataGridViewColumn.HeaderText = "EmployeeId";
			this.uxEmployeeIdDataGridViewColumn.Name = "uxEmployeeIdDataGridViewColumn";
			this.uxEmployeeIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEmployeeIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEmployeeIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxNationalIdNumberDataGridViewColumn
			//
			this.uxNationalIdNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxNationalIdNumberDataGridViewColumn.DataPropertyName = "NationalIdNumber";
			this.uxNationalIdNumberDataGridViewColumn.HeaderText = "NationalIdNumber";
			this.uxNationalIdNumberDataGridViewColumn.Name = "uxNationalIdNumberDataGridViewColumn";
			this.uxNationalIdNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxNationalIdNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxNationalIdNumberDataGridViewColumn.ReadOnly = false;		
			//
			// uxContactIdDataGridViewColumn
			//
			this.uxContactIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxContactIdDataGridViewColumn.DataPropertyName = "ContactId";
			this.uxContactIdDataGridViewColumn.HeaderText = "ContactId";
			this.uxContactIdDataGridViewColumn.Name = "uxContactIdDataGridViewColumn";
			this.uxContactIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxContactIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxContactIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxLoginIdDataGridViewColumn
			//
			this.uxLoginIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLoginIdDataGridViewColumn.DataPropertyName = "LoginId";
			this.uxLoginIdDataGridViewColumn.HeaderText = "LoginId";
			this.uxLoginIdDataGridViewColumn.Name = "uxLoginIdDataGridViewColumn";
			this.uxLoginIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLoginIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLoginIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxManagerIdDataGridViewColumn
			//
			this.uxManagerIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxManagerIdDataGridViewColumn.DataPropertyName = "ManagerId";
			this.uxManagerIdDataGridViewColumn.HeaderText = "ManagerId";
			this.uxManagerIdDataGridViewColumn.Name = "uxManagerIdDataGridViewColumn";
			this.uxManagerIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxManagerIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxManagerIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxTitleDataGridViewColumn
			//
			this.uxTitleDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTitleDataGridViewColumn.DataPropertyName = "Title";
			this.uxTitleDataGridViewColumn.HeaderText = "Title";
			this.uxTitleDataGridViewColumn.Name = "uxTitleDataGridViewColumn";
			this.uxTitleDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTitleDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTitleDataGridViewColumn.ReadOnly = false;		
			//
			// uxBirthDateDataGridViewColumn
			//
			this.uxBirthDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBirthDateDataGridViewColumn.DataPropertyName = "BirthDate";
			this.uxBirthDateDataGridViewColumn.HeaderText = "BirthDate";
			this.uxBirthDateDataGridViewColumn.Name = "uxBirthDateDataGridViewColumn";
			this.uxBirthDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBirthDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBirthDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxMaritalStatusDataGridViewColumn
			//
			this.uxMaritalStatusDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMaritalStatusDataGridViewColumn.DataPropertyName = "MaritalStatus";
			this.uxMaritalStatusDataGridViewColumn.HeaderText = "MaritalStatus";
			this.uxMaritalStatusDataGridViewColumn.Name = "uxMaritalStatusDataGridViewColumn";
			this.uxMaritalStatusDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMaritalStatusDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMaritalStatusDataGridViewColumn.ReadOnly = false;		
			//
			// uxGenderDataGridViewColumn
			//
			this.uxGenderDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxGenderDataGridViewColumn.DataPropertyName = "Gender";
			this.uxGenderDataGridViewColumn.HeaderText = "Gender";
			this.uxGenderDataGridViewColumn.Name = "uxGenderDataGridViewColumn";
			this.uxGenderDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxGenderDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxGenderDataGridViewColumn.ReadOnly = false;		
			//
			// uxHireDateDataGridViewColumn
			//
			this.uxHireDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxHireDateDataGridViewColumn.DataPropertyName = "HireDate";
			this.uxHireDateDataGridViewColumn.HeaderText = "HireDate";
			this.uxHireDateDataGridViewColumn.Name = "uxHireDateDataGridViewColumn";
			this.uxHireDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxHireDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxHireDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxSalariedFlagDataGridViewColumn
			//
			this.uxSalariedFlagDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalariedFlagDataGridViewColumn.DataPropertyName = "SalariedFlag";
			this.uxSalariedFlagDataGridViewColumn.HeaderText = "SalariedFlag";
			this.uxSalariedFlagDataGridViewColumn.Name = "uxSalariedFlagDataGridViewColumn";
			this.uxSalariedFlagDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalariedFlagDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalariedFlagDataGridViewColumn.ReadOnly = false;		
			//
			// uxVacationHoursDataGridViewColumn
			//
			this.uxVacationHoursDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxVacationHoursDataGridViewColumn.DataPropertyName = "VacationHours";
			this.uxVacationHoursDataGridViewColumn.HeaderText = "VacationHours";
			this.uxVacationHoursDataGridViewColumn.Name = "uxVacationHoursDataGridViewColumn";
			this.uxVacationHoursDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxVacationHoursDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxVacationHoursDataGridViewColumn.ReadOnly = false;		
			//
			// uxSickLeaveHoursDataGridViewColumn
			//
			this.uxSickLeaveHoursDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSickLeaveHoursDataGridViewColumn.DataPropertyName = "SickLeaveHours";
			this.uxSickLeaveHoursDataGridViewColumn.HeaderText = "SickLeaveHours";
			this.uxSickLeaveHoursDataGridViewColumn.Name = "uxSickLeaveHoursDataGridViewColumn";
			this.uxSickLeaveHoursDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSickLeaveHoursDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSickLeaveHoursDataGridViewColumn.ReadOnly = false;		
			//
			// uxCurrentFlagDataGridViewColumn
			//
			this.uxCurrentFlagDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCurrentFlagDataGridViewColumn.DataPropertyName = "CurrentFlag";
			this.uxCurrentFlagDataGridViewColumn.HeaderText = "CurrentFlag";
			this.uxCurrentFlagDataGridViewColumn.Name = "uxCurrentFlagDataGridViewColumn";
			this.uxCurrentFlagDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCurrentFlagDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCurrentFlagDataGridViewColumn.ReadOnly = false;		
			//
			// uxRowguidDataGridViewColumn
			//
			this.uxRowguidDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRowguidDataGridViewColumn.DataPropertyName = "Rowguid";
			this.uxRowguidDataGridViewColumn.HeaderText = "Rowguid";
			this.uxRowguidDataGridViewColumn.Name = "uxRowguidDataGridViewColumn";
			this.uxRowguidDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRowguidDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRowguidDataGridViewColumn.ReadOnly = true;		
			//
			// uxModifiedDateDataGridViewColumn
			//
			this.uxModifiedDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxModifiedDateDataGridViewColumn.DataPropertyName = "ModifiedDate";
			this.uxModifiedDateDataGridViewColumn.HeaderText = "ModifiedDate";
			this.uxModifiedDateDataGridViewColumn.Name = "uxModifiedDateDataGridViewColumn";
			this.uxModifiedDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxModifiedDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxModifiedDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxContactIdDataGridViewColumn
			//				
			this.uxContactIdDataGridViewColumn.DisplayMember = "NameStyle";	
			this.uxContactIdDataGridViewColumn.ValueMember = "ContactId";	
			this.uxContactIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxContactIdDataGridViewColumn.DataSource = uxContactIdBindingSource;				
				
			//
			// uxManagerIdDataGridViewColumn
			//				
			this.uxManagerIdDataGridViewColumn.DisplayMember = "NationalIdNumber";	
			this.uxManagerIdDataGridViewColumn.ValueMember = "EmployeeId";	
			this.uxManagerIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxManagerIdDataGridViewColumn.DataSource = uxManagerIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxEmployeeDataGridView);
			this.Name = "EmployeeDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxManagerIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeBindingSource)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
				
		#region events
		
		/// <summary>
		/// Raised the CurrentEntityChanged event.
		/// </summary>
		protected void OnCurrentEntityChanged()
		{
			if (CurrentEntityChanged != null)
			{
				EmployeeDataGridViewEventArgs args = new EmployeeDataGridViewEventArgs();
				args.Employee = _currentEmployee;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class EmployeeDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Employee	_Employee;
	
			/// <summary>
			/// the  Entities.Employee instance.
			/// </summary>
			public Entities.Employee Employee
			{
				get { return _Employee; }
				set { _Employee = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxEmployeeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxEmployeeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxEmployeeIdDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].EmployeeId;
						break;
					case "uxNationalIdNumberDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].NationalIdNumber;
						break;
					case "uxContactIdDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].ContactId;
						break;
					case "uxLoginIdDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].LoginId;
						break;
					case "uxManagerIdDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].ManagerId;
						break;
					case "uxTitleDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Title;
						break;
					case "uxBirthDateDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].BirthDate;
						break;
					case "uxMaritalStatusDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].MaritalStatus;
						break;
					case "uxGenderDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Gender;
						break;
					case "uxHireDateDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].HireDate;
						break;
					case "uxSalariedFlagDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].SalariedFlag;
						break;
					case "uxVacationHoursDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].VacationHours;
						break;
					case "uxSickLeaveHoursDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].SickLeaveHours;
						break;
					case "uxCurrentFlagDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].CurrentFlag;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxEmployeeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxEmployeeIdDataGridViewColumn":
						EmployeeList[e.RowIndex].EmployeeId = (System.Int32)e.Value;
						break;
					case "uxNationalIdNumberDataGridViewColumn":
						EmployeeList[e.RowIndex].NationalIdNumber = (System.String)e.Value;
						break;
					case "uxContactIdDataGridViewColumn":
						EmployeeList[e.RowIndex].ContactId = (System.Int32)e.Value;
						break;
					case "uxLoginIdDataGridViewColumn":
						EmployeeList[e.RowIndex].LoginId = (System.String)e.Value;
						break;
					case "uxManagerIdDataGridViewColumn":
						EmployeeList[e.RowIndex].ManagerId = (System.Int32?)e.Value;
						break;
					case "uxTitleDataGridViewColumn":
						EmployeeList[e.RowIndex].Title = (System.String)e.Value;
						break;
					case "uxBirthDateDataGridViewColumn":
						EmployeeList[e.RowIndex].BirthDate = (System.DateTime)e.Value;
						break;
					case "uxMaritalStatusDataGridViewColumn":
						EmployeeList[e.RowIndex].MaritalStatus = (System.String)e.Value;
						break;
					case "uxGenderDataGridViewColumn":
						EmployeeList[e.RowIndex].Gender = (System.String)e.Value;
						break;
					case "uxHireDateDataGridViewColumn":
						EmployeeList[e.RowIndex].HireDate = (System.DateTime)e.Value;
						break;
					case "uxSalariedFlagDataGridViewColumn":
						EmployeeList[e.RowIndex].SalariedFlag = (System.Boolean)e.Value;
						break;
					case "uxVacationHoursDataGridViewColumn":
						EmployeeList[e.RowIndex].VacationHours = (System.Int16)e.Value;
						break;
					case "uxSickLeaveHoursDataGridViewColumn":
						EmployeeList[e.RowIndex].SickLeaveHours = (System.Int16)e.Value;
						break;
					case "uxCurrentFlagDataGridViewColumn":
						EmployeeList[e.RowIndex].CurrentFlag = (System.Boolean)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						EmployeeList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						EmployeeList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
