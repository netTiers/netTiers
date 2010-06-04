
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract StudentMasterIndex typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class StudentMasterIndexDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<StudentMasterIndexDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.StudentMasterIndex _currentStudentMasterIndex = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxStudentMasterIndexDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxStudentMasterIndexErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxStudentMasterIndexBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the StudentId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStudentIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EpassId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEpassIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StudentUpn property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStudentUpnDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SsabsaId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSsabsaIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Surname property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSurnameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the FirstName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFirstNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OtherNames property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOtherNamesDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the KnownName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxKnownNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LegalName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLegalNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Dob property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDobDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Gender property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxGenderDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the IndigeneousStatus property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIndigeneousStatusDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Lbote property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLboteDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EslPhase property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEslPhaseDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TribalGroup property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTribalGroupDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SlpCreatedFlag property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSlpCreatedFlagDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AddressLine1 property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressLine1DataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AddressLine2 property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressLine2DataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AddressLine3 property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressLine3DataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AddressLine4 property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressLine4DataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Suburb property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSuburbDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Postcode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPostcodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Phone1 property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPhone1DataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Phone2 property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPhone2DataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SourceSystem property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSourceSystemDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PhoneticMatchId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPhoneticMatchIdDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.StudentMasterIndex> _StudentMasterIndexList;
				
		/// <summary> 
		/// The list of StudentMasterIndex to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.StudentMasterIndex> StudentMasterIndexList
		{
			get {return this._StudentMasterIndexList;}
			set
			{
				this._StudentMasterIndexList = value;
				this.uxStudentMasterIndexBindingSource.DataSource = null;
				this.uxStudentMasterIndexBindingSource.DataSource = value;
				this.uxStudentMasterIndexDataGridView.DataSource = null;
				this.uxStudentMasterIndexDataGridView.DataSource = this.uxStudentMasterIndexBindingSource;				
				//this.uxStudentMasterIndexBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxStudentMasterIndexBindingSource_ListChanged);
				this.uxStudentMasterIndexBindingSource.CurrentItemChanged += new System.EventHandler(OnStudentMasterIndexBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnStudentMasterIndexBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentStudentMasterIndex = uxStudentMasterIndexBindingSource.Current as Entities.StudentMasterIndex;
			
			if (_currentStudentMasterIndex != null)
			{
				_currentStudentMasterIndex.Validate();
			}
			//_StudentMasterIndex.Validate();
			OnCurrentEntityChanged();
		}

		//void uxStudentMasterIndexBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <c cref="Entities.StudentMasterIndex"/> instance.
		/// </summary>
		public Entities.StudentMasterIndex SelectedStudentMasterIndex
		{
			get {return this._currentStudentMasterIndex;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxStudentMasterIndexDataGridView.VirtualMode;}
			set
			{
				this.uxStudentMasterIndexDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxStudentMasterIndexDataGridView.AllowUserToAddRows;}
			set {this.uxStudentMasterIndexDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxStudentMasterIndexDataGridView.AllowUserToDeleteRows;}
			set {this.uxStudentMasterIndexDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <c cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxStudentMasterIndexDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxStudentMasterIndexDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="StudentMasterIndexDataGridViewBase"/> class.
		/// </summary>
		public StudentMasterIndexDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxStudentMasterIndexDataGridView = new System.Windows.Forms.DataGridView();
			this.uxStudentMasterIndexBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxStudentMasterIndexErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxStudentIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEpassIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStudentUpnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSsabsaIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSurnameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFirstNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxOtherNamesDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxKnownNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLegalNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDobDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxGenderDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIndigeneousStatusDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLboteDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEslPhaseDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTribalGroupDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSlpCreatedFlagDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddressLine1DataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddressLine2DataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddressLine3DataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddressLine4DataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSuburbDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPostcodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPhone1DataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPhone2DataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSourceSystemDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPhoneticMatchIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxStudentMasterIndexDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStudentMasterIndexBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStudentMasterIndexErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxStudentMasterIndexErrorProvider
			// 
			this.uxStudentMasterIndexErrorProvider.ContainerControl = this;
			this.uxStudentMasterIndexErrorProvider.DataSource = this.uxStudentMasterIndexBindingSource;						
			// 
			// uxStudentMasterIndexDataGridView
			// 
			this.uxStudentMasterIndexDataGridView.AutoGenerateColumns = false;
			this.uxStudentMasterIndexDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxStudentMasterIndexDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxStudentIdDataGridViewColumn,
		this.uxEpassIdDataGridViewColumn,
		this.uxStudentUpnDataGridViewColumn,
		this.uxSsabsaIdDataGridViewColumn,
		this.uxSurnameDataGridViewColumn,
		this.uxFirstNameDataGridViewColumn,
		this.uxOtherNamesDataGridViewColumn,
		this.uxKnownNameDataGridViewColumn,
		this.uxLegalNameDataGridViewColumn,
		this.uxDobDataGridViewColumn,
		this.uxGenderDataGridViewColumn,
		this.uxIndigeneousStatusDataGridViewColumn,
		this.uxLboteDataGridViewColumn,
		this.uxEslPhaseDataGridViewColumn,
		this.uxTribalGroupDataGridViewColumn,
		this.uxSlpCreatedFlagDataGridViewColumn,
		this.uxAddressLine1DataGridViewColumn,
		this.uxAddressLine2DataGridViewColumn,
		this.uxAddressLine3DataGridViewColumn,
		this.uxAddressLine4DataGridViewColumn,
		this.uxSuburbDataGridViewColumn,
		this.uxPostcodeDataGridViewColumn,
		this.uxPhone1DataGridViewColumn,
		this.uxPhone2DataGridViewColumn,
		this.uxSourceSystemDataGridViewColumn,
		this.uxPhoneticMatchIdDataGridViewColumn			});
			this.uxStudentMasterIndexDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxStudentMasterIndexDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxStudentMasterIndexDataGridView.Name = "uxStudentMasterIndexDataGridView";
			this.uxStudentMasterIndexDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxStudentMasterIndexDataGridView.TabIndex = 0;	
			this.uxStudentMasterIndexDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxStudentMasterIndexDataGridView.EnableHeadersVisualStyles = false;
			this.uxStudentMasterIndexDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnStudentMasterIndexDataGridViewDataError);
			this.uxStudentMasterIndexDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnStudentMasterIndexDataGridViewCellValueNeeded);
			this.uxStudentMasterIndexDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnStudentMasterIndexDataGridViewCellValuePushed);
			
			//
			// uxStudentIdDataGridViewColumn
			//
			this.uxStudentIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStudentIdDataGridViewColumn.DataPropertyName = "StudentId";
			this.uxStudentIdDataGridViewColumn.HeaderText = "StudentId";
			this.uxStudentIdDataGridViewColumn.Name = "uxStudentIdDataGridViewColumn";
			this.uxStudentIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStudentIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStudentIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxEpassIdDataGridViewColumn
			//
			this.uxEpassIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEpassIdDataGridViewColumn.DataPropertyName = "EpassId";
			this.uxEpassIdDataGridViewColumn.HeaderText = "EpassId";
			this.uxEpassIdDataGridViewColumn.Name = "uxEpassIdDataGridViewColumn";
			this.uxEpassIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEpassIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEpassIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxStudentUpnDataGridViewColumn
			//
			this.uxStudentUpnDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStudentUpnDataGridViewColumn.DataPropertyName = "StudentUpn";
			this.uxStudentUpnDataGridViewColumn.HeaderText = "StudentUpn";
			this.uxStudentUpnDataGridViewColumn.Name = "uxStudentUpnDataGridViewColumn";
			this.uxStudentUpnDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStudentUpnDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStudentUpnDataGridViewColumn.ReadOnly = false;		
			//
			// uxSsabsaIdDataGridViewColumn
			//
			this.uxSsabsaIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSsabsaIdDataGridViewColumn.DataPropertyName = "SsabsaId";
			this.uxSsabsaIdDataGridViewColumn.HeaderText = "SsabsaId";
			this.uxSsabsaIdDataGridViewColumn.Name = "uxSsabsaIdDataGridViewColumn";
			this.uxSsabsaIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSsabsaIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSsabsaIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxSurnameDataGridViewColumn
			//
			this.uxSurnameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSurnameDataGridViewColumn.DataPropertyName = "Surname";
			this.uxSurnameDataGridViewColumn.HeaderText = "Surname";
			this.uxSurnameDataGridViewColumn.Name = "uxSurnameDataGridViewColumn";
			this.uxSurnameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSurnameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSurnameDataGridViewColumn.ReadOnly = false;		
			//
			// uxFirstNameDataGridViewColumn
			//
			this.uxFirstNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFirstNameDataGridViewColumn.DataPropertyName = "FirstName";
			this.uxFirstNameDataGridViewColumn.HeaderText = "FirstName";
			this.uxFirstNameDataGridViewColumn.Name = "uxFirstNameDataGridViewColumn";
			this.uxFirstNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFirstNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFirstNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxOtherNamesDataGridViewColumn
			//
			this.uxOtherNamesDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxOtherNamesDataGridViewColumn.DataPropertyName = "OtherNames";
			this.uxOtherNamesDataGridViewColumn.HeaderText = "OtherNames";
			this.uxOtherNamesDataGridViewColumn.Name = "uxOtherNamesDataGridViewColumn";
			this.uxOtherNamesDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxOtherNamesDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxOtherNamesDataGridViewColumn.ReadOnly = false;		
			//
			// uxKnownNameDataGridViewColumn
			//
			this.uxKnownNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxKnownNameDataGridViewColumn.DataPropertyName = "KnownName";
			this.uxKnownNameDataGridViewColumn.HeaderText = "KnownName";
			this.uxKnownNameDataGridViewColumn.Name = "uxKnownNameDataGridViewColumn";
			this.uxKnownNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxKnownNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxKnownNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxLegalNameDataGridViewColumn
			//
			this.uxLegalNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLegalNameDataGridViewColumn.DataPropertyName = "LegalName";
			this.uxLegalNameDataGridViewColumn.HeaderText = "LegalName";
			this.uxLegalNameDataGridViewColumn.Name = "uxLegalNameDataGridViewColumn";
			this.uxLegalNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLegalNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLegalNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxDobDataGridViewColumn
			//
			this.uxDobDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDobDataGridViewColumn.DataPropertyName = "Dob";
			this.uxDobDataGridViewColumn.HeaderText = "Dob";
			this.uxDobDataGridViewColumn.Name = "uxDobDataGridViewColumn";
			this.uxDobDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDobDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDobDataGridViewColumn.ReadOnly = false;		
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
			// uxIndigeneousStatusDataGridViewColumn
			//
			this.uxIndigeneousStatusDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIndigeneousStatusDataGridViewColumn.DataPropertyName = "IndigeneousStatus";
			this.uxIndigeneousStatusDataGridViewColumn.HeaderText = "IndigeneousStatus";
			this.uxIndigeneousStatusDataGridViewColumn.Name = "uxIndigeneousStatusDataGridViewColumn";
			this.uxIndigeneousStatusDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIndigeneousStatusDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIndigeneousStatusDataGridViewColumn.ReadOnly = false;		
			//
			// uxLboteDataGridViewColumn
			//
			this.uxLboteDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLboteDataGridViewColumn.DataPropertyName = "Lbote";
			this.uxLboteDataGridViewColumn.HeaderText = "Lbote";
			this.uxLboteDataGridViewColumn.Name = "uxLboteDataGridViewColumn";
			this.uxLboteDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLboteDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLboteDataGridViewColumn.ReadOnly = false;		
			//
			// uxEslPhaseDataGridViewColumn
			//
			this.uxEslPhaseDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEslPhaseDataGridViewColumn.DataPropertyName = "EslPhase";
			this.uxEslPhaseDataGridViewColumn.HeaderText = "EslPhase";
			this.uxEslPhaseDataGridViewColumn.Name = "uxEslPhaseDataGridViewColumn";
			this.uxEslPhaseDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEslPhaseDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEslPhaseDataGridViewColumn.ReadOnly = false;		
			//
			// uxTribalGroupDataGridViewColumn
			//
			this.uxTribalGroupDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTribalGroupDataGridViewColumn.DataPropertyName = "TribalGroup";
			this.uxTribalGroupDataGridViewColumn.HeaderText = "TribalGroup";
			this.uxTribalGroupDataGridViewColumn.Name = "uxTribalGroupDataGridViewColumn";
			this.uxTribalGroupDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTribalGroupDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTribalGroupDataGridViewColumn.ReadOnly = false;		
			//
			// uxSlpCreatedFlagDataGridViewColumn
			//
			this.uxSlpCreatedFlagDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSlpCreatedFlagDataGridViewColumn.DataPropertyName = "SlpCreatedFlag";
			this.uxSlpCreatedFlagDataGridViewColumn.HeaderText = "SlpCreatedFlag";
			this.uxSlpCreatedFlagDataGridViewColumn.Name = "uxSlpCreatedFlagDataGridViewColumn";
			this.uxSlpCreatedFlagDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSlpCreatedFlagDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSlpCreatedFlagDataGridViewColumn.ReadOnly = false;		
			//
			// uxAddressLine1DataGridViewColumn
			//
			this.uxAddressLine1DataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressLine1DataGridViewColumn.DataPropertyName = "AddressLine1";
			this.uxAddressLine1DataGridViewColumn.HeaderText = "AddressLine1";
			this.uxAddressLine1DataGridViewColumn.Name = "uxAddressLine1DataGridViewColumn";
			this.uxAddressLine1DataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressLine1DataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressLine1DataGridViewColumn.ReadOnly = false;		
			//
			// uxAddressLine2DataGridViewColumn
			//
			this.uxAddressLine2DataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressLine2DataGridViewColumn.DataPropertyName = "AddressLine2";
			this.uxAddressLine2DataGridViewColumn.HeaderText = "AddressLine2";
			this.uxAddressLine2DataGridViewColumn.Name = "uxAddressLine2DataGridViewColumn";
			this.uxAddressLine2DataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressLine2DataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressLine2DataGridViewColumn.ReadOnly = false;		
			//
			// uxAddressLine3DataGridViewColumn
			//
			this.uxAddressLine3DataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressLine3DataGridViewColumn.DataPropertyName = "AddressLine3";
			this.uxAddressLine3DataGridViewColumn.HeaderText = "AddressLine3";
			this.uxAddressLine3DataGridViewColumn.Name = "uxAddressLine3DataGridViewColumn";
			this.uxAddressLine3DataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressLine3DataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressLine3DataGridViewColumn.ReadOnly = false;		
			//
			// uxAddressLine4DataGridViewColumn
			//
			this.uxAddressLine4DataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressLine4DataGridViewColumn.DataPropertyName = "AddressLine4";
			this.uxAddressLine4DataGridViewColumn.HeaderText = "AddressLine4";
			this.uxAddressLine4DataGridViewColumn.Name = "uxAddressLine4DataGridViewColumn";
			this.uxAddressLine4DataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressLine4DataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressLine4DataGridViewColumn.ReadOnly = false;		
			//
			// uxSuburbDataGridViewColumn
			//
			this.uxSuburbDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSuburbDataGridViewColumn.DataPropertyName = "Suburb";
			this.uxSuburbDataGridViewColumn.HeaderText = "Suburb";
			this.uxSuburbDataGridViewColumn.Name = "uxSuburbDataGridViewColumn";
			this.uxSuburbDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSuburbDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSuburbDataGridViewColumn.ReadOnly = false;		
			//
			// uxPostcodeDataGridViewColumn
			//
			this.uxPostcodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPostcodeDataGridViewColumn.DataPropertyName = "Postcode";
			this.uxPostcodeDataGridViewColumn.HeaderText = "Postcode";
			this.uxPostcodeDataGridViewColumn.Name = "uxPostcodeDataGridViewColumn";
			this.uxPostcodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPostcodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPostcodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxPhone1DataGridViewColumn
			//
			this.uxPhone1DataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPhone1DataGridViewColumn.DataPropertyName = "Phone1";
			this.uxPhone1DataGridViewColumn.HeaderText = "Phone1";
			this.uxPhone1DataGridViewColumn.Name = "uxPhone1DataGridViewColumn";
			this.uxPhone1DataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPhone1DataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPhone1DataGridViewColumn.ReadOnly = false;		
			//
			// uxPhone2DataGridViewColumn
			//
			this.uxPhone2DataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPhone2DataGridViewColumn.DataPropertyName = "Phone2";
			this.uxPhone2DataGridViewColumn.HeaderText = "Phone2";
			this.uxPhone2DataGridViewColumn.Name = "uxPhone2DataGridViewColumn";
			this.uxPhone2DataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPhone2DataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPhone2DataGridViewColumn.ReadOnly = false;		
			//
			// uxSourceSystemDataGridViewColumn
			//
			this.uxSourceSystemDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSourceSystemDataGridViewColumn.DataPropertyName = "SourceSystem";
			this.uxSourceSystemDataGridViewColumn.HeaderText = "SourceSystem";
			this.uxSourceSystemDataGridViewColumn.Name = "uxSourceSystemDataGridViewColumn";
			this.uxSourceSystemDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSourceSystemDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSourceSystemDataGridViewColumn.ReadOnly = false;		
			//
			// uxPhoneticMatchIdDataGridViewColumn
			//
			this.uxPhoneticMatchIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPhoneticMatchIdDataGridViewColumn.DataPropertyName = "PhoneticMatchId";
			this.uxPhoneticMatchIdDataGridViewColumn.HeaderText = "PhoneticMatchId";
			this.uxPhoneticMatchIdDataGridViewColumn.Name = "uxPhoneticMatchIdDataGridViewColumn";
			this.uxPhoneticMatchIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPhoneticMatchIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPhoneticMatchIdDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxStudentMasterIndexDataGridView);
			this.Name = "StudentMasterIndexDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxStudentMasterIndexErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStudentMasterIndexDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStudentMasterIndexBindingSource)).EndInit();
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
				StudentMasterIndexDataGridViewEventArgs args = new StudentMasterIndexDataGridViewEventArgs();
				args.StudentMasterIndex = _currentStudentMasterIndex;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class StudentMasterIndexDataGridViewEventArgs : System.EventArgs
		{
			private Entities.StudentMasterIndex	_StudentMasterIndex;
	
			/// <summary>
			/// the  Entities.StudentMasterIndex instance.
			/// </summary>
			public Entities.StudentMasterIndex StudentMasterIndex
			{
				get { return _StudentMasterIndex; }
				set { _StudentMasterIndex = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxStudentMasterIndexDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnStudentMasterIndexDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxStudentMasterIndexDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnStudentMasterIndexDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxStudentMasterIndexDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxStudentIdDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].StudentId;
						break;
					case "uxEpassIdDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].EpassId;
						break;
					case "uxStudentUpnDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].StudentUpn;
						break;
					case "uxSsabsaIdDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].SsabsaId;
						break;
					case "uxSurnameDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].Surname;
						break;
					case "uxFirstNameDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].FirstName;
						break;
					case "uxOtherNamesDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].OtherNames;
						break;
					case "uxKnownNameDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].KnownName;
						break;
					case "uxLegalNameDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].LegalName;
						break;
					case "uxDobDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].Dob;
						break;
					case "uxGenderDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].Gender;
						break;
					case "uxIndigeneousStatusDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].IndigeneousStatus;
						break;
					case "uxLboteDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].Lbote;
						break;
					case "uxEslPhaseDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].EslPhase;
						break;
					case "uxTribalGroupDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].TribalGroup;
						break;
					case "uxSlpCreatedFlagDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].SlpCreatedFlag;
						break;
					case "uxAddressLine1DataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].AddressLine1;
						break;
					case "uxAddressLine2DataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].AddressLine2;
						break;
					case "uxAddressLine3DataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].AddressLine3;
						break;
					case "uxAddressLine4DataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].AddressLine4;
						break;
					case "uxSuburbDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].Suburb;
						break;
					case "uxPostcodeDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].Postcode;
						break;
					case "uxPhone1DataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].Phone1;
						break;
					case "uxPhone2DataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].Phone2;
						break;
					case "uxSourceSystemDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].SourceSystem;
						break;
					case "uxPhoneticMatchIdDataGridViewColumn":
						e.Value = StudentMasterIndexList[e.RowIndex].PhoneticMatchId;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxStudentMasterIndexDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnStudentMasterIndexDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxStudentMasterIndexDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxStudentIdDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].StudentId = (System.Int32)e.Value;
						break;
					case "uxEpassIdDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].EpassId = (System.String)e.Value;
						break;
					case "uxStudentUpnDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].StudentUpn = (System.String)e.Value;
						break;
					case "uxSsabsaIdDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].SsabsaId = (System.String)e.Value;
						break;
					case "uxSurnameDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].Surname = (System.String)e.Value;
						break;
					case "uxFirstNameDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].FirstName = (System.String)e.Value;
						break;
					case "uxOtherNamesDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].OtherNames = (System.String)e.Value;
						break;
					case "uxKnownNameDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].KnownName = (System.String)e.Value;
						break;
					case "uxLegalNameDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].LegalName = (System.String)e.Value;
						break;
					case "uxDobDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].Dob = (System.DateTime?)e.Value;
						break;
					case "uxGenderDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].Gender = (System.String)e.Value;
						break;
					case "uxIndigeneousStatusDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].IndigeneousStatus = (System.String)e.Value;
						break;
					case "uxLboteDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].Lbote = (System.String)e.Value;
						break;
					case "uxEslPhaseDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].EslPhase = (System.String)e.Value;
						break;
					case "uxTribalGroupDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].TribalGroup = (System.String)e.Value;
						break;
					case "uxSlpCreatedFlagDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].SlpCreatedFlag = (System.String)e.Value;
						break;
					case "uxAddressLine1DataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].AddressLine1 = (System.String)e.Value;
						break;
					case "uxAddressLine2DataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].AddressLine2 = (System.String)e.Value;
						break;
					case "uxAddressLine3DataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].AddressLine3 = (System.String)e.Value;
						break;
					case "uxAddressLine4DataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].AddressLine4 = (System.String)e.Value;
						break;
					case "uxSuburbDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].Suburb = (System.String)e.Value;
						break;
					case "uxPostcodeDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].Postcode = (System.String)e.Value;
						break;
					case "uxPhone1DataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].Phone1 = (System.String)e.Value;
						break;
					case "uxPhone2DataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].Phone2 = (System.String)e.Value;
						break;
					case "uxSourceSystemDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].SourceSystem = (System.String)e.Value;
						break;
					case "uxPhoneticMatchIdDataGridViewColumn":
						StudentMasterIndexList[e.RowIndex].PhoneticMatchId = (System.Int32?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
