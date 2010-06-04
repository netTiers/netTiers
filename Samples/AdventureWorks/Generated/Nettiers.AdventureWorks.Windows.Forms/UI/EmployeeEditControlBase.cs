
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Employee"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class EmployeeEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the EmployeeId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEmployeeId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmployeeIdLabel;
		
		/// <summary>
		/// TextBox for the NationalIdNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxNationalIdNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the NationalIdNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxNationalIdNumberLabel;
		
		/// <summary>
		/// ComboBox for the ContactId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxContactId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ContactId property.
		/// </summary>
		protected System.Windows.Forms.Label uxContactIdLabel;
		
		/// <summary>
		/// TextBox for the LoginId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLoginId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LoginId property.
		/// </summary>
		protected System.Windows.Forms.Label uxLoginIdLabel;
		
		/// <summary>
		/// ComboBox for the ManagerId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxManagerId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ManagerId property.
		/// </summary>
		protected System.Windows.Forms.Label uxManagerIdLabel;
		
		/// <summary>
		/// TextBox for the Title property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTitle;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Title property.
		/// </summary>
		protected System.Windows.Forms.Label uxTitleLabel;
		
		/// <summary>
		/// DataTimePicker for the BirthDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxBirthDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the BirthDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxBirthDateLabel;
		
		/// <summary>
		/// TextBox for the MaritalStatus property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxMaritalStatus;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the MaritalStatus property.
		/// </summary>
		protected System.Windows.Forms.Label uxMaritalStatusLabel;
		
		/// <summary>
		/// TextBox for the Gender property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxGender;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Gender property.
		/// </summary>
		protected System.Windows.Forms.Label uxGenderLabel;
		
		/// <summary>
		/// DataTimePicker for the HireDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxHireDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the HireDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxHireDateLabel;
		
		/// <summary>
		/// CheckBox for the SalariedFlag property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxSalariedFlag;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SalariedFlag property.
		/// </summary>
		protected System.Windows.Forms.Label uxSalariedFlagLabel;
		
		/// <summary>
		/// TextBox for the VacationHours property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxVacationHours;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the VacationHours property.
		/// </summary>
		protected System.Windows.Forms.Label uxVacationHoursLabel;
		
		/// <summary>
		/// TextBox for the SickLeaveHours property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSickLeaveHours;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SickLeaveHours property.
		/// </summary>
		protected System.Windows.Forms.Label uxSickLeaveHoursLabel;
		
		/// <summary>
		/// CheckBox for the CurrentFlag property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxCurrentFlag;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CurrentFlag property.
		/// </summary>
		protected System.Windows.Forms.Label uxCurrentFlagLabel;
		
		/// <summary>
		/// TextBox for the Rowguid property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRowguid;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Rowguid property.
		/// </summary>
		protected System.Windows.Forms.Label uxRowguidLabel;
		
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
		private Entities.Employee _Employee;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Employee"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Employee"/> instance.</value>
		public Entities.Employee Employee
		{
			get {return this._Employee;}
			set
			{
				this._Employee = value;
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
			this.uxEmployeeId.DataBindings.Add("Text", this.uxBindingSource, "EmployeeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxNationalIdNumber.DataBindings.Clear();
			this.uxNationalIdNumber.DataBindings.Add("Text", this.uxBindingSource, "NationalIdNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxContactId.DataBindings.Clear();
			this.uxContactId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ContactId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLoginId.DataBindings.Clear();
			this.uxLoginId.DataBindings.Add("Text", this.uxBindingSource, "LoginId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxManagerId.DataBindings.Clear();
			this.uxManagerId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ManagerId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTitle.DataBindings.Clear();
			this.uxTitle.DataBindings.Add("Text", this.uxBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBirthDate.DataBindings.Clear();
			this.uxBirthDate.DataBindings.Add("Value", this.uxBindingSource, "BirthDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMaritalStatus.DataBindings.Clear();
			this.uxMaritalStatus.DataBindings.Add("Text", this.uxBindingSource, "MaritalStatus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxGender.DataBindings.Clear();
			this.uxGender.DataBindings.Add("Text", this.uxBindingSource, "Gender", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxHireDate.DataBindings.Clear();
			this.uxHireDate.DataBindings.Add("Value", this.uxBindingSource, "HireDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSalariedFlag.DataBindings.Clear();
			this.uxSalariedFlag.DataBindings.Add("Checked", this.uxBindingSource, "SalariedFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxVacationHours.DataBindings.Clear();
			this.uxVacationHours.DataBindings.Add("Text", this.uxBindingSource, "VacationHours", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSickLeaveHours.DataBindings.Clear();
			this.uxSickLeaveHours.DataBindings.Add("Text", this.uxBindingSource, "SickLeaveHours", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCurrentFlag.DataBindings.Clear();
			this.uxCurrentFlag.DataBindings.Add("Checked", this.uxBindingSource, "CurrentFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeEditControlBase"/> class.
		/// </summary>
		public EmployeeEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Employee != null) _Employee.Validate();
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
			this.uxEmployeeId = new System.Windows.Forms.TextBox();
			uxEmployeeIdLabel = new System.Windows.Forms.Label();
			this.uxNationalIdNumber = new System.Windows.Forms.TextBox();
			uxNationalIdNumberLabel = new System.Windows.Forms.Label();
			this.uxContactId = new System.Windows.Forms.ComboBox();
			uxContactIdLabel = new System.Windows.Forms.Label();
			this.uxLoginId = new System.Windows.Forms.TextBox();
			uxLoginIdLabel = new System.Windows.Forms.Label();
			this.uxManagerId = new System.Windows.Forms.ComboBox();
			uxManagerIdLabel = new System.Windows.Forms.Label();
			this.uxTitle = new System.Windows.Forms.TextBox();
			uxTitleLabel = new System.Windows.Forms.Label();
			this.uxBirthDate = new System.Windows.Forms.DateTimePicker();
			uxBirthDateLabel = new System.Windows.Forms.Label();
			this.uxMaritalStatus = new System.Windows.Forms.TextBox();
			uxMaritalStatusLabel = new System.Windows.Forms.Label();
			this.uxGender = new System.Windows.Forms.TextBox();
			uxGenderLabel = new System.Windows.Forms.Label();
			this.uxHireDate = new System.Windows.Forms.DateTimePicker();
			uxHireDateLabel = new System.Windows.Forms.Label();
			this.uxSalariedFlag = new System.Windows.Forms.CheckBox();
			uxSalariedFlagLabel = new System.Windows.Forms.Label();
			this.uxVacationHours = new System.Windows.Forms.TextBox();
			uxVacationHoursLabel = new System.Windows.Forms.Label();
			this.uxSickLeaveHours = new System.Windows.Forms.TextBox();
			uxSickLeaveHoursLabel = new System.Windows.Forms.Label();
			this.uxCurrentFlag = new System.Windows.Forms.CheckBox();
			uxCurrentFlagLabel = new System.Windows.Forms.Label();
			this.uxRowguid = new System.Windows.Forms.TextBox();
			uxRowguidLabel = new System.Windows.Forms.Label();
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
            this.uxEmployeeId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeId);
			this.uxEmployeeId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxEmployeeId);
			//
			// uxNationalIdNumberLabel
			//
			this.uxNationalIdNumberLabel.Name = "uxNationalIdNumberLabel";
			this.uxNationalIdNumberLabel.Text = "National Id Number:";
			this.uxNationalIdNumberLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxNationalIdNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNationalIdNumberLabel);			
			//
			// uxNationalIdNumber
			//
			this.uxNationalIdNumber.Name = "uxNationalIdNumber";
			this.uxNationalIdNumber.Width = 250;
			this.uxNationalIdNumber.MaxLength = 15;
			//this.uxTableLayoutPanel.Controls.Add(this.uxNationalIdNumber);
			this.uxNationalIdNumber.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxNationalIdNumber);
			//
			// uxContactIdLabel
			//
			this.uxContactIdLabel.Name = "uxContactIdLabel";
			this.uxContactIdLabel.Text = "Contact Id:";
			this.uxContactIdLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxContactIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactIdLabel);			
			//
			// uxContactId
			//
			this.uxContactId.Name = "uxContactId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxContactId);
			this.uxContactId.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxContactId);
			//
			// uxLoginIdLabel
			//
			this.uxLoginIdLabel.Name = "uxLoginIdLabel";
			this.uxLoginIdLabel.Text = "Login Id:";
			this.uxLoginIdLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxLoginIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLoginIdLabel);			
			//
			// uxLoginId
			//
			this.uxLoginId.Name = "uxLoginId";
			this.uxLoginId.Width = 250;
			this.uxLoginId.MaxLength = 256;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLoginId);
			this.uxLoginId.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxLoginId);
			//
			// uxManagerIdLabel
			//
			this.uxManagerIdLabel.Name = "uxManagerIdLabel";
			this.uxManagerIdLabel.Text = "Manager Id:";
			this.uxManagerIdLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxManagerIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxManagerIdLabel);			
			//
			// uxManagerId
			//
			this.uxManagerId.Name = "uxManagerId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxManagerId);
			this.uxManagerId.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxManagerId);
			//
			// uxTitleLabel
			//
			this.uxTitleLabel.Name = "uxTitleLabel";
			this.uxTitleLabel.Text = "Title:";
			this.uxTitleLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxTitleLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTitleLabel);			
			//
			// uxTitle
			//
			this.uxTitle.Name = "uxTitle";
			this.uxTitle.Width = 250;
			this.uxTitle.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTitle);
			this.uxTitle.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxTitle);
			//
			// uxBirthDateLabel
			//
			this.uxBirthDateLabel.Name = "uxBirthDateLabel";
			this.uxBirthDateLabel.Text = "Birth Date:";
			this.uxBirthDateLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxBirthDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBirthDateLabel);			
			//
			// uxBirthDate
			//
			this.uxBirthDate.Name = "uxBirthDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBirthDate);
			this.uxBirthDate.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxBirthDate);
			//
			// uxMaritalStatusLabel
			//
			this.uxMaritalStatusLabel.Name = "uxMaritalStatusLabel";
			this.uxMaritalStatusLabel.Text = "Marital Status:";
			this.uxMaritalStatusLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxMaritalStatusLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMaritalStatusLabel);			
			//
			// uxMaritalStatus
			//
			this.uxMaritalStatus.Name = "uxMaritalStatus";
			this.uxMaritalStatus.Width = 250;
			this.uxMaritalStatus.MaxLength = 1;
			//this.uxTableLayoutPanel.Controls.Add(this.uxMaritalStatus);
			this.uxMaritalStatus.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxMaritalStatus);
			//
			// uxGenderLabel
			//
			this.uxGenderLabel.Name = "uxGenderLabel";
			this.uxGenderLabel.Text = "Gender:";
			this.uxGenderLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxGenderLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxGenderLabel);			
			//
			// uxGender
			//
			this.uxGender.Name = "uxGender";
			this.uxGender.Width = 250;
			this.uxGender.MaxLength = 1;
			//this.uxTableLayoutPanel.Controls.Add(this.uxGender);
			this.uxGender.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxGender);
			//
			// uxHireDateLabel
			//
			this.uxHireDateLabel.Name = "uxHireDateLabel";
			this.uxHireDateLabel.Text = "Hire Date:";
			this.uxHireDateLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxHireDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxHireDateLabel);			
			//
			// uxHireDate
			//
			this.uxHireDate.Name = "uxHireDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxHireDate);
			this.uxHireDate.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxHireDate);
			//
			// uxSalariedFlagLabel
			//
			this.uxSalariedFlagLabel.Name = "uxSalariedFlagLabel";
			this.uxSalariedFlagLabel.Text = "Salaried Flag:";
			this.uxSalariedFlagLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxSalariedFlagLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalariedFlagLabel);			
			//
			// uxSalariedFlag
			//
			this.uxSalariedFlag.Name = "uxSalariedFlag";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSalariedFlag);
			this.uxSalariedFlag.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxSalariedFlag);
			//
			// uxVacationHoursLabel
			//
			this.uxVacationHoursLabel.Name = "uxVacationHoursLabel";
			this.uxVacationHoursLabel.Text = "Vacation Hours:";
			this.uxVacationHoursLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxVacationHoursLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxVacationHoursLabel);			
			//
			// uxVacationHours
			//
			this.uxVacationHours.Name = "uxVacationHours";
			//this.uxTableLayoutPanel.Controls.Add(this.uxVacationHours);
			this.uxVacationHours.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxVacationHours);
			//
			// uxSickLeaveHoursLabel
			//
			this.uxSickLeaveHoursLabel.Name = "uxSickLeaveHoursLabel";
			this.uxSickLeaveHoursLabel.Text = "Sick Leave Hours:";
			this.uxSickLeaveHoursLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxSickLeaveHoursLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSickLeaveHoursLabel);			
			//
			// uxSickLeaveHours
			//
			this.uxSickLeaveHours.Name = "uxSickLeaveHours";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSickLeaveHours);
			this.uxSickLeaveHours.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxSickLeaveHours);
			//
			// uxCurrentFlagLabel
			//
			this.uxCurrentFlagLabel.Name = "uxCurrentFlagLabel";
			this.uxCurrentFlagLabel.Text = "Current Flag:";
			this.uxCurrentFlagLabel.Location = new System.Drawing.Point(3, 338);
			this.Controls.Add(this.uxCurrentFlagLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrentFlagLabel);			
			//
			// uxCurrentFlag
			//
			this.uxCurrentFlag.Name = "uxCurrentFlag";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCurrentFlag);
			this.uxCurrentFlag.Location = new System.Drawing.Point(160, 338);
			this.Controls.Add(this.uxCurrentFlag);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 364);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 364);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 390);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 390);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxContactId
			//				
			this.uxContactId.DisplayMember = "NameStyle";	
			this.uxContactId.ValueMember = "ContactId";	
			//
			// uxManagerId
			//				
			this.uxManagerId.DisplayMember = "NationalIdNumber";	
			this.uxManagerId.ValueMember = "EmployeeId";	
			// 
			// EmployeeEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "EmployeeEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Contact> _ContactIdList;
		
		/// <summary>
		/// The ComboBox associated with the ContactId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Contact> ContactIdList
		{
			get {return _ContactIdList;}
			set 
			{
				this._ContactIdList = value;
				this.uxContactId.DataSource = null;
				this.uxContactId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInContactIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ContactId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactIdList
		{
			get { return _allowNewItemInContactIdList;}
			set
			{
				this._allowNewItemInContactIdList = value;
				this.uxContactId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.Employee> _ManagerIdList;
		
		/// <summary>
		/// The ComboBox associated with the ManagerId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Employee> ManagerIdList
		{
			get {return _ManagerIdList;}
			set 
			{
				this._ManagerIdList = value;
				this.uxManagerId.DataSource = null;
				this.uxManagerId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInManagerIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ManagerId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInManagerIdList
		{
			get { return _allowNewItemInManagerIdList;}
			set
			{
				this._allowNewItemInManagerIdList = value;
				this.uxManagerId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        /// Indicates if the controls associated with the uxNationalIdNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNationalIdNumberVisible
        {
            get { return this.uxNationalIdNumber.Visible; }
            set
            {
                this.uxNationalIdNumberLabel.Visible = value;
                this.uxNationalIdNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxNationalIdNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNationalIdNumberEnabled
        {
            get { return this.uxNationalIdNumber.Enabled; }
            set
            {
                this.uxNationalIdNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxContactId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxContactIdVisible
        {
            get { return this.uxContactId.Visible; }
            set
            {
                this.uxContactIdLabel.Visible = value;
                this.uxContactId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxContactId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxContactIdEnabled
        {
            get { return this.uxContactId.Enabled; }
            set
            {
                this.uxContactId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLoginId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLoginIdVisible
        {
            get { return this.uxLoginId.Visible; }
            set
            {
                this.uxLoginIdLabel.Visible = value;
                this.uxLoginId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLoginId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLoginIdEnabled
        {
            get { return this.uxLoginId.Enabled; }
            set
            {
                this.uxLoginId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxManagerId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxManagerIdVisible
        {
            get { return this.uxManagerId.Visible; }
            set
            {
                this.uxManagerIdLabel.Visible = value;
                this.uxManagerId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxManagerId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxManagerIdEnabled
        {
            get { return this.uxManagerId.Enabled; }
            set
            {
                this.uxManagerId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTitle property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTitleVisible
        {
            get { return this.uxTitle.Visible; }
            set
            {
                this.uxTitleLabel.Visible = value;
                this.uxTitle.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTitle property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTitleEnabled
        {
            get { return this.uxTitle.Enabled; }
            set
            {
                this.uxTitle.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBirthDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBirthDateVisible
        {
            get { return this.uxBirthDate.Visible; }
            set
            {
                this.uxBirthDateLabel.Visible = value;
                this.uxBirthDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBirthDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBirthDateEnabled
        {
            get { return this.uxBirthDate.Enabled; }
            set
            {
                this.uxBirthDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxMaritalStatus property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxMaritalStatusVisible
        {
            get { return this.uxMaritalStatus.Visible; }
            set
            {
                this.uxMaritalStatusLabel.Visible = value;
                this.uxMaritalStatus.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxMaritalStatus property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxMaritalStatusEnabled
        {
            get { return this.uxMaritalStatus.Enabled; }
            set
            {
                this.uxMaritalStatus.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxGender property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxGenderVisible
        {
            get { return this.uxGender.Visible; }
            set
            {
                this.uxGenderLabel.Visible = value;
                this.uxGender.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxGender property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxGenderEnabled
        {
            get { return this.uxGender.Enabled; }
            set
            {
                this.uxGender.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxHireDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxHireDateVisible
        {
            get { return this.uxHireDate.Visible; }
            set
            {
                this.uxHireDateLabel.Visible = value;
                this.uxHireDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxHireDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxHireDateEnabled
        {
            get { return this.uxHireDate.Enabled; }
            set
            {
                this.uxHireDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSalariedFlag property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSalariedFlagVisible
        {
            get { return this.uxSalariedFlag.Visible; }
            set
            {
                this.uxSalariedFlagLabel.Visible = value;
                this.uxSalariedFlag.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSalariedFlag property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSalariedFlagEnabled
        {
            get { return this.uxSalariedFlag.Enabled; }
            set
            {
                this.uxSalariedFlag.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxVacationHours property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxVacationHoursVisible
        {
            get { return this.uxVacationHours.Visible; }
            set
            {
                this.uxVacationHoursLabel.Visible = value;
                this.uxVacationHours.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxVacationHours property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxVacationHoursEnabled
        {
            get { return this.uxVacationHours.Enabled; }
            set
            {
                this.uxVacationHours.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSickLeaveHours property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSickLeaveHoursVisible
        {
            get { return this.uxSickLeaveHours.Visible; }
            set
            {
                this.uxSickLeaveHoursLabel.Visible = value;
                this.uxSickLeaveHours.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSickLeaveHours property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSickLeaveHoursEnabled
        {
            get { return this.uxSickLeaveHours.Enabled; }
            set
            {
                this.uxSickLeaveHours.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCurrentFlag property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCurrentFlagVisible
        {
            get { return this.uxCurrentFlag.Visible; }
            set
            {
                this.uxCurrentFlagLabel.Visible = value;
                this.uxCurrentFlag.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCurrentFlag property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCurrentFlagEnabled
        {
            get { return this.uxCurrentFlag.Enabled; }
            set
            {
                this.uxCurrentFlag.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRowguid property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRowguidVisible
        {
            get { return this.uxRowguid.Visible; }
            set
            {
                this.uxRowguidLabel.Visible = value;
                this.uxRowguid.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRowguid property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRowguidEnabled
        {
            get { return this.uxRowguid.Enabled; }
            set
            {
                this.uxRowguid.Enabled = value;
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
