
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.StudentMasterIndex"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class StudentMasterIndexEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the StudentId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStudentId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StudentId property.
		/// </summary>
		protected System.Windows.Forms.Label uxStudentIdLabel;
		
		/// <summary>
		/// TextBox for the EpassId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEpassId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EpassId property.
		/// </summary>
		protected System.Windows.Forms.Label uxEpassIdLabel;
		
		/// <summary>
		/// TextBox for the StudentUpn property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStudentUpn;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StudentUpn property.
		/// </summary>
		protected System.Windows.Forms.Label uxStudentUpnLabel;
		
		/// <summary>
		/// TextBox for the SsabsaId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSsabsaId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SsabsaId property.
		/// </summary>
		protected System.Windows.Forms.Label uxSsabsaIdLabel;
		
		/// <summary>
		/// TextBox for the Surname property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSurname;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Surname property.
		/// </summary>
		protected System.Windows.Forms.Label uxSurnameLabel;
		
		/// <summary>
		/// TextBox for the FirstName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxFirstName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the FirstName property.
		/// </summary>
		protected System.Windows.Forms.Label uxFirstNameLabel;
		
		/// <summary>
		/// TextBox for the OtherNames property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxOtherNames;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OtherNames property.
		/// </summary>
		protected System.Windows.Forms.Label uxOtherNamesLabel;
		
		/// <summary>
		/// TextBox for the KnownName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxKnownName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the KnownName property.
		/// </summary>
		protected System.Windows.Forms.Label uxKnownNameLabel;
		
		/// <summary>
		/// TextBox for the LegalName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLegalName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the LegalName property.
		/// </summary>
		protected System.Windows.Forms.Label uxLegalNameLabel;
		
		/// <summary>
		/// DataTimePicker for the Dob property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxDob;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Dob property.
		/// </summary>
		protected System.Windows.Forms.Label uxDobLabel;
		
		/// <summary>
		/// TextBox for the Gender property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxGender;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Gender property.
		/// </summary>
		protected System.Windows.Forms.Label uxGenderLabel;
		
		/// <summary>
		/// TextBox for the IndigeneousStatus property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxIndigeneousStatus;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IndigeneousStatus property.
		/// </summary>
		protected System.Windows.Forms.Label uxIndigeneousStatusLabel;
		
		/// <summary>
		/// TextBox for the Lbote property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLbote;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Lbote property.
		/// </summary>
		protected System.Windows.Forms.Label uxLboteLabel;
		
		/// <summary>
		/// TextBox for the EslPhase property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEslPhase;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EslPhase property.
		/// </summary>
		protected System.Windows.Forms.Label uxEslPhaseLabel;
		
		/// <summary>
		/// TextBox for the TribalGroup property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTribalGroup;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TribalGroup property.
		/// </summary>
		protected System.Windows.Forms.Label uxTribalGroupLabel;
		
		/// <summary>
		/// TextBox for the SlpCreatedFlag property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSlpCreatedFlag;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SlpCreatedFlag property.
		/// </summary>
		protected System.Windows.Forms.Label uxSlpCreatedFlagLabel;
		
		/// <summary>
		/// TextBox for the AddressLine1 property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddressLine1;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressLine1 property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressLine1Label;
		
		/// <summary>
		/// TextBox for the AddressLine2 property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddressLine2;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressLine2 property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressLine2Label;
		
		/// <summary>
		/// TextBox for the AddressLine3 property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddressLine3;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressLine3 property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressLine3Label;
		
		/// <summary>
		/// TextBox for the AddressLine4 property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddressLine4;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddressLine4 property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressLine4Label;
		
		/// <summary>
		/// TextBox for the Suburb property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSuburb;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Suburb property.
		/// </summary>
		protected System.Windows.Forms.Label uxSuburbLabel;
		
		/// <summary>
		/// TextBox for the Postcode property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPostcode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Postcode property.
		/// </summary>
		protected System.Windows.Forms.Label uxPostcodeLabel;
		
		/// <summary>
		/// TextBox for the Phone1 property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPhone1;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Phone1 property.
		/// </summary>
		protected System.Windows.Forms.Label uxPhone1Label;
		
		/// <summary>
		/// TextBox for the Phone2 property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPhone2;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Phone2 property.
		/// </summary>
		protected System.Windows.Forms.Label uxPhone2Label;
		
		/// <summary>
		/// TextBox for the SourceSystem property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSourceSystem;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SourceSystem property.
		/// </summary>
		protected System.Windows.Forms.Label uxSourceSystemLabel;
		
		/// <summary>
		/// TextBox for the PhoneticMatchId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPhoneticMatchId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the PhoneticMatchId property.
		/// </summary>
		protected System.Windows.Forms.Label uxPhoneticMatchIdLabel;
		#endregion
		
		#region Main entity
		private Entities.StudentMasterIndex _StudentMasterIndex;
		/// <summary>
		/// Gets or sets the <see cref="Entities.StudentMasterIndex"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.StudentMasterIndex"/> instance.</value>
		public Entities.StudentMasterIndex StudentMasterIndex
		{
			get {return this._StudentMasterIndex;}
			set
			{
				this._StudentMasterIndex = value;
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
			this.uxStudentId.DataBindings.Clear();
			this.uxStudentId.DataBindings.Add("Text", this.uxBindingSource, "StudentId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEpassId.DataBindings.Clear();
			this.uxEpassId.DataBindings.Add("Text", this.uxBindingSource, "EpassId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStudentUpn.DataBindings.Clear();
			this.uxStudentUpn.DataBindings.Add("Text", this.uxBindingSource, "StudentUpn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSsabsaId.DataBindings.Clear();
			this.uxSsabsaId.DataBindings.Add("Text", this.uxBindingSource, "SsabsaId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSurname.DataBindings.Clear();
			this.uxSurname.DataBindings.Add("Text", this.uxBindingSource, "Surname", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFirstName.DataBindings.Clear();
			this.uxFirstName.DataBindings.Add("Text", this.uxBindingSource, "FirstName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOtherNames.DataBindings.Clear();
			this.uxOtherNames.DataBindings.Add("Text", this.uxBindingSource, "OtherNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxKnownName.DataBindings.Clear();
			this.uxKnownName.DataBindings.Add("Text", this.uxBindingSource, "KnownName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLegalName.DataBindings.Clear();
			this.uxLegalName.DataBindings.Add("Text", this.uxBindingSource, "LegalName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDob.DataBindings.Clear();
			this.uxDob.DataBindings.Add("Value", this.uxBindingSource, "Dob", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxGender.DataBindings.Clear();
			this.uxGender.DataBindings.Add("Text", this.uxBindingSource, "Gender", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIndigeneousStatus.DataBindings.Clear();
			this.uxIndigeneousStatus.DataBindings.Add("Text", this.uxBindingSource, "IndigeneousStatus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLbote.DataBindings.Clear();
			this.uxLbote.DataBindings.Add("Text", this.uxBindingSource, "Lbote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEslPhase.DataBindings.Clear();
			this.uxEslPhase.DataBindings.Add("Text", this.uxBindingSource, "EslPhase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTribalGroup.DataBindings.Clear();
			this.uxTribalGroup.DataBindings.Add("Text", this.uxBindingSource, "TribalGroup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSlpCreatedFlag.DataBindings.Clear();
			this.uxSlpCreatedFlag.DataBindings.Add("Text", this.uxBindingSource, "SlpCreatedFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddressLine1.DataBindings.Clear();
			this.uxAddressLine1.DataBindings.Add("Text", this.uxBindingSource, "AddressLine1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddressLine2.DataBindings.Clear();
			this.uxAddressLine2.DataBindings.Add("Text", this.uxBindingSource, "AddressLine2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddressLine3.DataBindings.Clear();
			this.uxAddressLine3.DataBindings.Add("Text", this.uxBindingSource, "AddressLine3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddressLine4.DataBindings.Clear();
			this.uxAddressLine4.DataBindings.Add("Text", this.uxBindingSource, "AddressLine4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSuburb.DataBindings.Clear();
			this.uxSuburb.DataBindings.Add("Text", this.uxBindingSource, "Suburb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPostcode.DataBindings.Clear();
			this.uxPostcode.DataBindings.Add("Text", this.uxBindingSource, "Postcode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPhone1.DataBindings.Clear();
			this.uxPhone1.DataBindings.Add("Text", this.uxBindingSource, "Phone1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPhone2.DataBindings.Clear();
			this.uxPhone2.DataBindings.Add("Text", this.uxBindingSource, "Phone2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSourceSystem.DataBindings.Clear();
			this.uxSourceSystem.DataBindings.Add("Text", this.uxBindingSource, "SourceSystem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPhoneticMatchId.DataBindings.Clear();
			this.uxPhoneticMatchId.DataBindings.Add("Text", this.uxBindingSource, "PhoneticMatchId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="StudentMasterIndexEditControlBase"/> class.
		/// </summary>
		public StudentMasterIndexEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_StudentMasterIndex != null) _StudentMasterIndex.Validate();
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
			this.uxStudentId = new System.Windows.Forms.TextBox();
			uxStudentIdLabel = new System.Windows.Forms.Label();
			this.uxEpassId = new System.Windows.Forms.TextBox();
			uxEpassIdLabel = new System.Windows.Forms.Label();
			this.uxStudentUpn = new System.Windows.Forms.TextBox();
			uxStudentUpnLabel = new System.Windows.Forms.Label();
			this.uxSsabsaId = new System.Windows.Forms.TextBox();
			uxSsabsaIdLabel = new System.Windows.Forms.Label();
			this.uxSurname = new System.Windows.Forms.TextBox();
			uxSurnameLabel = new System.Windows.Forms.Label();
			this.uxFirstName = new System.Windows.Forms.TextBox();
			uxFirstNameLabel = new System.Windows.Forms.Label();
			this.uxOtherNames = new System.Windows.Forms.TextBox();
			uxOtherNamesLabel = new System.Windows.Forms.Label();
			this.uxKnownName = new System.Windows.Forms.TextBox();
			uxKnownNameLabel = new System.Windows.Forms.Label();
			this.uxLegalName = new System.Windows.Forms.TextBox();
			uxLegalNameLabel = new System.Windows.Forms.Label();
			this.uxDob = new System.Windows.Forms.DateTimePicker();
			uxDobLabel = new System.Windows.Forms.Label();
			this.uxGender = new System.Windows.Forms.TextBox();
			uxGenderLabel = new System.Windows.Forms.Label();
			this.uxIndigeneousStatus = new System.Windows.Forms.TextBox();
			uxIndigeneousStatusLabel = new System.Windows.Forms.Label();
			this.uxLbote = new System.Windows.Forms.TextBox();
			uxLboteLabel = new System.Windows.Forms.Label();
			this.uxEslPhase = new System.Windows.Forms.TextBox();
			uxEslPhaseLabel = new System.Windows.Forms.Label();
			this.uxTribalGroup = new System.Windows.Forms.TextBox();
			uxTribalGroupLabel = new System.Windows.Forms.Label();
			this.uxSlpCreatedFlag = new System.Windows.Forms.TextBox();
			uxSlpCreatedFlagLabel = new System.Windows.Forms.Label();
			this.uxAddressLine1 = new System.Windows.Forms.TextBox();
			uxAddressLine1Label = new System.Windows.Forms.Label();
			this.uxAddressLine2 = new System.Windows.Forms.TextBox();
			uxAddressLine2Label = new System.Windows.Forms.Label();
			this.uxAddressLine3 = new System.Windows.Forms.TextBox();
			uxAddressLine3Label = new System.Windows.Forms.Label();
			this.uxAddressLine4 = new System.Windows.Forms.TextBox();
			uxAddressLine4Label = new System.Windows.Forms.Label();
			this.uxSuburb = new System.Windows.Forms.TextBox();
			uxSuburbLabel = new System.Windows.Forms.Label();
			this.uxPostcode = new System.Windows.Forms.TextBox();
			uxPostcodeLabel = new System.Windows.Forms.Label();
			this.uxPhone1 = new System.Windows.Forms.TextBox();
			uxPhone1Label = new System.Windows.Forms.Label();
			this.uxPhone2 = new System.Windows.Forms.TextBox();
			uxPhone2Label = new System.Windows.Forms.Label();
			this.uxSourceSystem = new System.Windows.Forms.TextBox();
			uxSourceSystemLabel = new System.Windows.Forms.Label();
			this.uxPhoneticMatchId = new System.Windows.Forms.TextBox();
			uxPhoneticMatchIdLabel = new System.Windows.Forms.Label();
			
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
			// uxStudentIdLabel
			//
			this.uxStudentIdLabel.Name = "uxStudentIdLabel";
			this.uxStudentIdLabel.Text = "Student Id:";
			this.uxStudentIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxStudentIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStudentIdLabel);			
			//
			// uxStudentId
			//
			this.uxStudentId.Name = "uxStudentId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStudentId);
			this.uxStudentId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxStudentId);
			//
			// uxEpassIdLabel
			//
			this.uxEpassIdLabel.Name = "uxEpassIdLabel";
			this.uxEpassIdLabel.Text = "Epass Id:";
			this.uxEpassIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxEpassIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEpassIdLabel);			
			//
			// uxEpassId
			//
			this.uxEpassId.Name = "uxEpassId";
			this.uxEpassId.Width = 250;
			this.uxEpassId.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxEpassId);
			this.uxEpassId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxEpassId);
			//
			// uxStudentUpnLabel
			//
			this.uxStudentUpnLabel.Name = "uxStudentUpnLabel";
			this.uxStudentUpnLabel.Text = "Student Upn:";
			this.uxStudentUpnLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxStudentUpnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStudentUpnLabel);			
			//
			// uxStudentUpn
			//
			this.uxStudentUpn.Name = "uxStudentUpn";
			this.uxStudentUpn.Width = 250;
			this.uxStudentUpn.MaxLength = 13;
			//this.uxTableLayoutPanel.Controls.Add(this.uxStudentUpn);
			this.uxStudentUpn.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxStudentUpn);
			//
			// uxSsabsaIdLabel
			//
			this.uxSsabsaIdLabel.Name = "uxSsabsaIdLabel";
			this.uxSsabsaIdLabel.Text = "Ssabsa Id:";
			this.uxSsabsaIdLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxSsabsaIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSsabsaIdLabel);			
			//
			// uxSsabsaId
			//
			this.uxSsabsaId.Name = "uxSsabsaId";
			this.uxSsabsaId.Width = 250;
			this.uxSsabsaId.MaxLength = 100;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSsabsaId);
			this.uxSsabsaId.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxSsabsaId);
			//
			// uxSurnameLabel
			//
			this.uxSurnameLabel.Name = "uxSurnameLabel";
			this.uxSurnameLabel.Text = "Surname:";
			this.uxSurnameLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxSurnameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSurnameLabel);			
			//
			// uxSurname
			//
			this.uxSurname.Name = "uxSurname";
			this.uxSurname.Width = 250;
			this.uxSurname.MaxLength = 30;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSurname);
			this.uxSurname.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxSurname);
			//
			// uxFirstNameLabel
			//
			this.uxFirstNameLabel.Name = "uxFirstNameLabel";
			this.uxFirstNameLabel.Text = "First Name:";
			this.uxFirstNameLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxFirstNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFirstNameLabel);			
			//
			// uxFirstName
			//
			this.uxFirstName.Name = "uxFirstName";
			this.uxFirstName.Width = 250;
			this.uxFirstName.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxFirstName);
			this.uxFirstName.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxFirstName);
			//
			// uxOtherNamesLabel
			//
			this.uxOtherNamesLabel.Name = "uxOtherNamesLabel";
			this.uxOtherNamesLabel.Text = "Other Names:";
			this.uxOtherNamesLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxOtherNamesLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOtherNamesLabel);			
			//
			// uxOtherNames
			//
			this.uxOtherNames.Name = "uxOtherNames";
			this.uxOtherNames.Width = 250;
			this.uxOtherNames.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxOtherNames);
			this.uxOtherNames.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxOtherNames);
			//
			// uxKnownNameLabel
			//
			this.uxKnownNameLabel.Name = "uxKnownNameLabel";
			this.uxKnownNameLabel.Text = "Known Name:";
			this.uxKnownNameLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxKnownNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxKnownNameLabel);			
			//
			// uxKnownName
			//
			this.uxKnownName.Name = "uxKnownName";
			this.uxKnownName.Width = 250;
			this.uxKnownName.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxKnownName);
			this.uxKnownName.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxKnownName);
			//
			// uxLegalNameLabel
			//
			this.uxLegalNameLabel.Name = "uxLegalNameLabel";
			this.uxLegalNameLabel.Text = "Legal Name:";
			this.uxLegalNameLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxLegalNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLegalNameLabel);			
			//
			// uxLegalName
			//
			this.uxLegalName.Name = "uxLegalName";
			this.uxLegalName.Width = 250;
			this.uxLegalName.MaxLength = 30;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLegalName);
			this.uxLegalName.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxLegalName);
			//
			// uxDobLabel
			//
			this.uxDobLabel.Name = "uxDobLabel";
			this.uxDobLabel.Text = "Dob:";
			this.uxDobLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxDobLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDobLabel);			
			//
			// uxDob
			//
			this.uxDob.Name = "uxDob";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDob);
			this.uxDob.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxDob);
			//
			// uxGenderLabel
			//
			this.uxGenderLabel.Name = "uxGenderLabel";
			this.uxGenderLabel.Text = "Gender:";
			this.uxGenderLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxGenderLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxGenderLabel);			
			//
			// uxGender
			//
			this.uxGender.Name = "uxGender";
			this.uxGender.Width = 250;
			this.uxGender.MaxLength = 6;
			//this.uxTableLayoutPanel.Controls.Add(this.uxGender);
			this.uxGender.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxGender);
			//
			// uxIndigeneousStatusLabel
			//
			this.uxIndigeneousStatusLabel.Name = "uxIndigeneousStatusLabel";
			this.uxIndigeneousStatusLabel.Text = "Indigeneous Status:";
			this.uxIndigeneousStatusLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxIndigeneousStatusLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIndigeneousStatusLabel);			
			//
			// uxIndigeneousStatus
			//
			this.uxIndigeneousStatus.Name = "uxIndigeneousStatus";
			this.uxIndigeneousStatus.Width = 250;
			this.uxIndigeneousStatus.MaxLength = 40;
			//this.uxTableLayoutPanel.Controls.Add(this.uxIndigeneousStatus);
			this.uxIndigeneousStatus.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxIndigeneousStatus);
			//
			// uxLboteLabel
			//
			this.uxLboteLabel.Name = "uxLboteLabel";
			this.uxLboteLabel.Text = "Lbote:";
			this.uxLboteLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxLboteLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLboteLabel);			
			//
			// uxLbote
			//
			this.uxLbote.Name = "uxLbote";
			this.uxLbote.Width = 250;
			this.uxLbote.MaxLength = 3;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLbote);
			this.uxLbote.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxLbote);
			//
			// uxEslPhaseLabel
			//
			this.uxEslPhaseLabel.Name = "uxEslPhaseLabel";
			this.uxEslPhaseLabel.Text = "Esl Phase:";
			this.uxEslPhaseLabel.Location = new System.Drawing.Point(3, 338);
			this.Controls.Add(this.uxEslPhaseLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEslPhaseLabel);			
			//
			// uxEslPhase
			//
			this.uxEslPhase.Name = "uxEslPhase";
			this.uxEslPhase.Width = 250;
			this.uxEslPhase.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxEslPhase);
			this.uxEslPhase.Location = new System.Drawing.Point(160, 338);
			this.Controls.Add(this.uxEslPhase);
			//
			// uxTribalGroupLabel
			//
			this.uxTribalGroupLabel.Name = "uxTribalGroupLabel";
			this.uxTribalGroupLabel.Text = "Tribal Group:";
			this.uxTribalGroupLabel.Location = new System.Drawing.Point(3, 364);
			this.Controls.Add(this.uxTribalGroupLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTribalGroupLabel);			
			//
			// uxTribalGroup
			//
			this.uxTribalGroup.Name = "uxTribalGroup";
			this.uxTribalGroup.Width = 250;
			this.uxTribalGroup.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTribalGroup);
			this.uxTribalGroup.Location = new System.Drawing.Point(160, 364);
			this.Controls.Add(this.uxTribalGroup);
			//
			// uxSlpCreatedFlagLabel
			//
			this.uxSlpCreatedFlagLabel.Name = "uxSlpCreatedFlagLabel";
			this.uxSlpCreatedFlagLabel.Text = "Slp Created Flag:";
			this.uxSlpCreatedFlagLabel.Location = new System.Drawing.Point(3, 390);
			this.Controls.Add(this.uxSlpCreatedFlagLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSlpCreatedFlagLabel);			
			//
			// uxSlpCreatedFlag
			//
			this.uxSlpCreatedFlag.Name = "uxSlpCreatedFlag";
			this.uxSlpCreatedFlag.Width = 250;
			this.uxSlpCreatedFlag.MaxLength = 3;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSlpCreatedFlag);
			this.uxSlpCreatedFlag.Location = new System.Drawing.Point(160, 390);
			this.Controls.Add(this.uxSlpCreatedFlag);
			//
			// uxAddressLine1Label
			//
			this.uxAddressLine1Label.Name = "uxAddressLine1Label";
			this.uxAddressLine1Label.Text = "Address Line1:";
			this.uxAddressLine1Label.Location = new System.Drawing.Point(3, 416);
			this.Controls.Add(this.uxAddressLine1Label);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine1Label);			
			//
			// uxAddressLine1
			//
			this.uxAddressLine1.Name = "uxAddressLine1";
			this.uxAddressLine1.Width = 250;
			this.uxAddressLine1.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine1);
			this.uxAddressLine1.Location = new System.Drawing.Point(160, 416);
			this.Controls.Add(this.uxAddressLine1);
			//
			// uxAddressLine2Label
			//
			this.uxAddressLine2Label.Name = "uxAddressLine2Label";
			this.uxAddressLine2Label.Text = "Address Line2:";
			this.uxAddressLine2Label.Location = new System.Drawing.Point(3, 442);
			this.Controls.Add(this.uxAddressLine2Label);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine2Label);			
			//
			// uxAddressLine2
			//
			this.uxAddressLine2.Name = "uxAddressLine2";
			this.uxAddressLine2.Width = 250;
			this.uxAddressLine2.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine2);
			this.uxAddressLine2.Location = new System.Drawing.Point(160, 442);
			this.Controls.Add(this.uxAddressLine2);
			//
			// uxAddressLine3Label
			//
			this.uxAddressLine3Label.Name = "uxAddressLine3Label";
			this.uxAddressLine3Label.Text = "Address Line3:";
			this.uxAddressLine3Label.Location = new System.Drawing.Point(3, 468);
			this.Controls.Add(this.uxAddressLine3Label);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine3Label);			
			//
			// uxAddressLine3
			//
			this.uxAddressLine3.Name = "uxAddressLine3";
			this.uxAddressLine3.Width = 250;
			this.uxAddressLine3.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine3);
			this.uxAddressLine3.Location = new System.Drawing.Point(160, 468);
			this.Controls.Add(this.uxAddressLine3);
			//
			// uxAddressLine4Label
			//
			this.uxAddressLine4Label.Name = "uxAddressLine4Label";
			this.uxAddressLine4Label.Text = "Address Line4:";
			this.uxAddressLine4Label.Location = new System.Drawing.Point(3, 494);
			this.Controls.Add(this.uxAddressLine4Label);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine4Label);			
			//
			// uxAddressLine4
			//
			this.uxAddressLine4.Name = "uxAddressLine4";
			this.uxAddressLine4.Width = 250;
			this.uxAddressLine4.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLine4);
			this.uxAddressLine4.Location = new System.Drawing.Point(160, 494);
			this.Controls.Add(this.uxAddressLine4);
			//
			// uxSuburbLabel
			//
			this.uxSuburbLabel.Name = "uxSuburbLabel";
			this.uxSuburbLabel.Text = "Suburb:";
			this.uxSuburbLabel.Location = new System.Drawing.Point(3, 520);
			this.Controls.Add(this.uxSuburbLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSuburbLabel);			
			//
			// uxSuburb
			//
			this.uxSuburb.Name = "uxSuburb";
			this.uxSuburb.Width = 250;
			this.uxSuburb.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSuburb);
			this.uxSuburb.Location = new System.Drawing.Point(160, 520);
			this.Controls.Add(this.uxSuburb);
			//
			// uxPostcodeLabel
			//
			this.uxPostcodeLabel.Name = "uxPostcodeLabel";
			this.uxPostcodeLabel.Text = "Postcode:";
			this.uxPostcodeLabel.Location = new System.Drawing.Point(3, 546);
			this.Controls.Add(this.uxPostcodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPostcodeLabel);			
			//
			// uxPostcode
			//
			this.uxPostcode.Name = "uxPostcode";
			this.uxPostcode.Width = 250;
			this.uxPostcode.MaxLength = 4;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPostcode);
			this.uxPostcode.Location = new System.Drawing.Point(160, 546);
			this.Controls.Add(this.uxPostcode);
			//
			// uxPhone1Label
			//
			this.uxPhone1Label.Name = "uxPhone1Label";
			this.uxPhone1Label.Text = "Phone1:";
			this.uxPhone1Label.Location = new System.Drawing.Point(3, 572);
			this.Controls.Add(this.uxPhone1Label);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhone1Label);			
			//
			// uxPhone1
			//
			this.uxPhone1.Name = "uxPhone1";
			this.uxPhone1.Width = 250;
			this.uxPhone1.MaxLength = 10;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhone1);
			this.uxPhone1.Location = new System.Drawing.Point(160, 572);
			this.Controls.Add(this.uxPhone1);
			//
			// uxPhone2Label
			//
			this.uxPhone2Label.Name = "uxPhone2Label";
			this.uxPhone2Label.Text = "Phone2:";
			this.uxPhone2Label.Location = new System.Drawing.Point(3, 598);
			this.Controls.Add(this.uxPhone2Label);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhone2Label);			
			//
			// uxPhone2
			//
			this.uxPhone2.Name = "uxPhone2";
			this.uxPhone2.Width = 250;
			this.uxPhone2.MaxLength = 10;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhone2);
			this.uxPhone2.Location = new System.Drawing.Point(160, 598);
			this.Controls.Add(this.uxPhone2);
			//
			// uxSourceSystemLabel
			//
			this.uxSourceSystemLabel.Name = "uxSourceSystemLabel";
			this.uxSourceSystemLabel.Text = "Source System:";
			this.uxSourceSystemLabel.Location = new System.Drawing.Point(3, 624);
			this.Controls.Add(this.uxSourceSystemLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSourceSystemLabel);			
			//
			// uxSourceSystem
			//
			this.uxSourceSystem.Name = "uxSourceSystem";
			this.uxSourceSystem.Width = 250;
			this.uxSourceSystem.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSourceSystem);
			this.uxSourceSystem.Location = new System.Drawing.Point(160, 624);
			this.Controls.Add(this.uxSourceSystem);
			//
			// uxPhoneticMatchIdLabel
			//
			this.uxPhoneticMatchIdLabel.Name = "uxPhoneticMatchIdLabel";
			this.uxPhoneticMatchIdLabel.Text = "Phonetic Match Id:";
			this.uxPhoneticMatchIdLabel.Location = new System.Drawing.Point(3, 650);
			this.Controls.Add(this.uxPhoneticMatchIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhoneticMatchIdLabel);			
			//
			// uxPhoneticMatchId
			//
			this.uxPhoneticMatchId.Name = "uxPhoneticMatchId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhoneticMatchId);
			this.uxPhoneticMatchId.Location = new System.Drawing.Point(160, 650);
			this.Controls.Add(this.uxPhoneticMatchId);
			// 
			// StudentMasterIndexEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "StudentMasterIndexEditControlBase";
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
        /// Indicates if the controls associated with the uxStudentId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStudentIdVisible
        {
            get { return this.uxStudentId.Visible; }
            set
            {
                this.uxStudentIdLabel.Visible = value;
                this.uxStudentId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStudentId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStudentIdEnabled
        {
            get { return this.uxStudentId.Enabled; }
            set
            {
                this.uxStudentId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEpassId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEpassIdVisible
        {
            get { return this.uxEpassId.Visible; }
            set
            {
                this.uxEpassIdLabel.Visible = value;
                this.uxEpassId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEpassId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEpassIdEnabled
        {
            get { return this.uxEpassId.Enabled; }
            set
            {
                this.uxEpassId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStudentUpn property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStudentUpnVisible
        {
            get { return this.uxStudentUpn.Visible; }
            set
            {
                this.uxStudentUpnLabel.Visible = value;
                this.uxStudentUpn.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStudentUpn property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStudentUpnEnabled
        {
            get { return this.uxStudentUpn.Enabled; }
            set
            {
                this.uxStudentUpn.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSsabsaId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSsabsaIdVisible
        {
            get { return this.uxSsabsaId.Visible; }
            set
            {
                this.uxSsabsaIdLabel.Visible = value;
                this.uxSsabsaId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSsabsaId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSsabsaIdEnabled
        {
            get { return this.uxSsabsaId.Enabled; }
            set
            {
                this.uxSsabsaId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSurname property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSurnameVisible
        {
            get { return this.uxSurname.Visible; }
            set
            {
                this.uxSurnameLabel.Visible = value;
                this.uxSurname.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSurname property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSurnameEnabled
        {
            get { return this.uxSurname.Enabled; }
            set
            {
                this.uxSurname.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFirstName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFirstNameVisible
        {
            get { return this.uxFirstName.Visible; }
            set
            {
                this.uxFirstNameLabel.Visible = value;
                this.uxFirstName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFirstName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFirstNameEnabled
        {
            get { return this.uxFirstName.Enabled; }
            set
            {
                this.uxFirstName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxOtherNames property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxOtherNamesVisible
        {
            get { return this.uxOtherNames.Visible; }
            set
            {
                this.uxOtherNamesLabel.Visible = value;
                this.uxOtherNames.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxOtherNames property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxOtherNamesEnabled
        {
            get { return this.uxOtherNames.Enabled; }
            set
            {
                this.uxOtherNames.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxKnownName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxKnownNameVisible
        {
            get { return this.uxKnownName.Visible; }
            set
            {
                this.uxKnownNameLabel.Visible = value;
                this.uxKnownName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxKnownName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxKnownNameEnabled
        {
            get { return this.uxKnownName.Enabled; }
            set
            {
                this.uxKnownName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLegalName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLegalNameVisible
        {
            get { return this.uxLegalName.Visible; }
            set
            {
                this.uxLegalNameLabel.Visible = value;
                this.uxLegalName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLegalName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLegalNameEnabled
        {
            get { return this.uxLegalName.Enabled; }
            set
            {
                this.uxLegalName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDob property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDobVisible
        {
            get { return this.uxDob.Visible; }
            set
            {
                this.uxDobLabel.Visible = value;
                this.uxDob.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDob property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDobEnabled
        {
            get { return this.uxDob.Enabled; }
            set
            {
                this.uxDob.Enabled = value;
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
        /// Indicates if the controls associated with the uxIndigeneousStatus property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIndigeneousStatusVisible
        {
            get { return this.uxIndigeneousStatus.Visible; }
            set
            {
                this.uxIndigeneousStatusLabel.Visible = value;
                this.uxIndigeneousStatus.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIndigeneousStatus property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIndigeneousStatusEnabled
        {
            get { return this.uxIndigeneousStatus.Enabled; }
            set
            {
                this.uxIndigeneousStatus.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLbote property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLboteVisible
        {
            get { return this.uxLbote.Visible; }
            set
            {
                this.uxLboteLabel.Visible = value;
                this.uxLbote.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLbote property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLboteEnabled
        {
            get { return this.uxLbote.Enabled; }
            set
            {
                this.uxLbote.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEslPhase property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEslPhaseVisible
        {
            get { return this.uxEslPhase.Visible; }
            set
            {
                this.uxEslPhaseLabel.Visible = value;
                this.uxEslPhase.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEslPhase property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEslPhaseEnabled
        {
            get { return this.uxEslPhase.Enabled; }
            set
            {
                this.uxEslPhase.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTribalGroup property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTribalGroupVisible
        {
            get { return this.uxTribalGroup.Visible; }
            set
            {
                this.uxTribalGroupLabel.Visible = value;
                this.uxTribalGroup.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTribalGroup property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTribalGroupEnabled
        {
            get { return this.uxTribalGroup.Enabled; }
            set
            {
                this.uxTribalGroup.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSlpCreatedFlag property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSlpCreatedFlagVisible
        {
            get { return this.uxSlpCreatedFlag.Visible; }
            set
            {
                this.uxSlpCreatedFlagLabel.Visible = value;
                this.uxSlpCreatedFlag.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSlpCreatedFlag property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSlpCreatedFlagEnabled
        {
            get { return this.uxSlpCreatedFlag.Enabled; }
            set
            {
                this.uxSlpCreatedFlag.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine1 property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressLine1Visible
        {
            get { return this.uxAddressLine1.Visible; }
            set
            {
                this.uxAddressLine1Label.Visible = value;
                this.uxAddressLine1.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine1 property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressLine1Enabled
        {
            get { return this.uxAddressLine1.Enabled; }
            set
            {
                this.uxAddressLine1.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine2 property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressLine2Visible
        {
            get { return this.uxAddressLine2.Visible; }
            set
            {
                this.uxAddressLine2Label.Visible = value;
                this.uxAddressLine2.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine2 property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressLine2Enabled
        {
            get { return this.uxAddressLine2.Enabled; }
            set
            {
                this.uxAddressLine2.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine3 property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressLine3Visible
        {
            get { return this.uxAddressLine3.Visible; }
            set
            {
                this.uxAddressLine3Label.Visible = value;
                this.uxAddressLine3.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine3 property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressLine3Enabled
        {
            get { return this.uxAddressLine3.Enabled; }
            set
            {
                this.uxAddressLine3.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine4 property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressLine4Visible
        {
            get { return this.uxAddressLine4.Visible; }
            set
            {
                this.uxAddressLine4Label.Visible = value;
                this.uxAddressLine4.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddressLine4 property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressLine4Enabled
        {
            get { return this.uxAddressLine4.Enabled; }
            set
            {
                this.uxAddressLine4.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSuburb property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSuburbVisible
        {
            get { return this.uxSuburb.Visible; }
            set
            {
                this.uxSuburbLabel.Visible = value;
                this.uxSuburb.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSuburb property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSuburbEnabled
        {
            get { return this.uxSuburb.Enabled; }
            set
            {
                this.uxSuburb.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPostcode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPostcodeVisible
        {
            get { return this.uxPostcode.Visible; }
            set
            {
                this.uxPostcodeLabel.Visible = value;
                this.uxPostcode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPostcode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPostcodeEnabled
        {
            get { return this.uxPostcode.Enabled; }
            set
            {
                this.uxPostcode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPhone1 property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPhone1Visible
        {
            get { return this.uxPhone1.Visible; }
            set
            {
                this.uxPhone1Label.Visible = value;
                this.uxPhone1.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPhone1 property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPhone1Enabled
        {
            get { return this.uxPhone1.Enabled; }
            set
            {
                this.uxPhone1.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPhone2 property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPhone2Visible
        {
            get { return this.uxPhone2.Visible; }
            set
            {
                this.uxPhone2Label.Visible = value;
                this.uxPhone2.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPhone2 property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPhone2Enabled
        {
            get { return this.uxPhone2.Enabled; }
            set
            {
                this.uxPhone2.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSourceSystem property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSourceSystemVisible
        {
            get { return this.uxSourceSystem.Visible; }
            set
            {
                this.uxSourceSystemLabel.Visible = value;
                this.uxSourceSystem.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSourceSystem property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSourceSystemEnabled
        {
            get { return this.uxSourceSystem.Enabled; }
            set
            {
                this.uxSourceSystem.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPhoneticMatchId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPhoneticMatchIdVisible
        {
            get { return this.uxPhoneticMatchId.Visible; }
            set
            {
                this.uxPhoneticMatchIdLabel.Visible = value;
                this.uxPhoneticMatchId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPhoneticMatchId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPhoneticMatchIdEnabled
        {
            get { return this.uxPhoneticMatchId.Enabled; }
            set
            {
                this.uxPhoneticMatchId.Enabled = value;
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
