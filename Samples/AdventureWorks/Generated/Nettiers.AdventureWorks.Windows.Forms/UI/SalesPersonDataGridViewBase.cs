
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesPerson typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesPersonDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesPersonDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesPerson _currentSalesPerson = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesPersonDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesPersonErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesPersonBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the SalesPersonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSalesPersonIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the TerritoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxTerritoryIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalesQuota property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesQuotaDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Bonus property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBonusDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CommissionPct property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCommissionPctDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalesYtd property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesYtdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalesLastYear property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesLastYearDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Employee> _SalesPersonIdList;
		
		/// <summary> 
		/// The list of selectable Employee
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Employee> SalesPersonIdList
		{
			get {return this._SalesPersonIdList;}
			set 
			{
				this._SalesPersonIdList = value;
				this.uxSalesPersonIdDataGridViewColumn.DataSource = null;
				this.uxSalesPersonIdDataGridViewColumn.DataSource = this._SalesPersonIdList;
			}
		}
		
		private bool _allowNewItemInSalesPersonIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Employee
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesPersonIdList
		{
			get { return _allowNewItemInSalesPersonIdList;}
			set
			{
				this._allowNewItemInSalesPersonIdList = value;
				this.uxSalesPersonIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.SalesTerritory> _TerritoryIdList;
		
		/// <summary> 
		/// The list of selectable SalesTerritory
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SalesTerritory> TerritoryIdList
		{
			get {return this._TerritoryIdList;}
			set 
			{
				this._TerritoryIdList = value;
				this.uxTerritoryIdDataGridViewColumn.DataSource = null;
				this.uxTerritoryIdDataGridViewColumn.DataSource = this._TerritoryIdList;
			}
		}
		
		private bool _allowNewItemInTerritoryIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of SalesTerritory
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInTerritoryIdList
		{
			get { return _allowNewItemInTerritoryIdList;}
			set
			{
				this._allowNewItemInTerritoryIdList = value;
				this.uxTerritoryIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SalesPerson> _SalesPersonList;
				
		/// <summary> 
		/// The list of SalesPerson to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesPerson> SalesPersonList
		{
			get {return this._SalesPersonList;}
			set
			{
				this._SalesPersonList = value;
				this.uxSalesPersonBindingSource.DataSource = null;
				this.uxSalesPersonBindingSource.DataSource = value;
				this.uxSalesPersonDataGridView.DataSource = null;
				this.uxSalesPersonDataGridView.DataSource = this.uxSalesPersonBindingSource;				
				//this.uxSalesPersonBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesPersonBindingSource_ListChanged);
				this.uxSalesPersonBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesPersonBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesPersonBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesPerson = uxSalesPersonBindingSource.Current as Entities.SalesPerson;
			
			if (_currentSalesPerson != null)
			{
				_currentSalesPerson.Validate();
			}
			//_SalesPerson.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesPersonBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesPerson"/> instance.
		/// </summary>
		public Entities.SalesPerson SelectedSalesPerson
		{
			get {return this._currentSalesPerson;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesPersonDataGridView.VirtualMode;}
			set
			{
				this.uxSalesPersonDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesPersonDataGridView.AllowUserToAddRows;}
			set {this.uxSalesPersonDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesPersonDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesPersonDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesPersonDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesPersonDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesPersonDataGridViewBase"/> class.
		/// </summary>
		public SalesPersonDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesPersonDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesPersonErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSalesPersonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxTerritoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSalesQuotaDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBonusDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCommissionPctDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSalesYtdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSalesLastYearDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxSalesPersonIdBindingSource = new EmployeeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).BeginInit();
			//this.uxTerritoryIdBindingSource = new SalesTerritoryBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesPersonErrorProvider
			// 
			this.uxSalesPersonErrorProvider.ContainerControl = this;
			this.uxSalesPersonErrorProvider.DataSource = this.uxSalesPersonBindingSource;						
			// 
			// uxSalesPersonDataGridView
			// 
			this.uxSalesPersonDataGridView.AutoGenerateColumns = false;
			this.uxSalesPersonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesPersonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSalesPersonIdDataGridViewColumn,
		this.uxTerritoryIdDataGridViewColumn,
		this.uxSalesQuotaDataGridViewColumn,
		this.uxBonusDataGridViewColumn,
		this.uxCommissionPctDataGridViewColumn,
		this.uxSalesYtdDataGridViewColumn,
		this.uxSalesLastYearDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesPersonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesPersonDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesPersonDataGridView.Name = "uxSalesPersonDataGridView";
			this.uxSalesPersonDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesPersonDataGridView.TabIndex = 0;	
			this.uxSalesPersonDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesPersonDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesPersonDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesPersonDataGridViewDataError);
			this.uxSalesPersonDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesPersonDataGridViewCellValueNeeded);
			this.uxSalesPersonDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesPersonDataGridViewCellValuePushed);
			
			//
			// uxSalesPersonIdDataGridViewColumn
			//
			this.uxSalesPersonIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesPersonIdDataGridViewColumn.DataPropertyName = "SalesPersonId";
			this.uxSalesPersonIdDataGridViewColumn.HeaderText = "SalesPersonId";
			this.uxSalesPersonIdDataGridViewColumn.Name = "uxSalesPersonIdDataGridViewColumn";
			this.uxSalesPersonIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesPersonIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesPersonIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxTerritoryIdDataGridViewColumn
			//
			this.uxTerritoryIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTerritoryIdDataGridViewColumn.DataPropertyName = "TerritoryId";
			this.uxTerritoryIdDataGridViewColumn.HeaderText = "TerritoryId";
			this.uxTerritoryIdDataGridViewColumn.Name = "uxTerritoryIdDataGridViewColumn";
			this.uxTerritoryIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTerritoryIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTerritoryIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxSalesQuotaDataGridViewColumn
			//
			this.uxSalesQuotaDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesQuotaDataGridViewColumn.DataPropertyName = "SalesQuota";
			this.uxSalesQuotaDataGridViewColumn.HeaderText = "SalesQuota";
			this.uxSalesQuotaDataGridViewColumn.Name = "uxSalesQuotaDataGridViewColumn";
			this.uxSalesQuotaDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesQuotaDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesQuotaDataGridViewColumn.ReadOnly = false;		
			//
			// uxBonusDataGridViewColumn
			//
			this.uxBonusDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBonusDataGridViewColumn.DataPropertyName = "Bonus";
			this.uxBonusDataGridViewColumn.HeaderText = "Bonus";
			this.uxBonusDataGridViewColumn.Name = "uxBonusDataGridViewColumn";
			this.uxBonusDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBonusDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBonusDataGridViewColumn.ReadOnly = false;		
			//
			// uxCommissionPctDataGridViewColumn
			//
			this.uxCommissionPctDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCommissionPctDataGridViewColumn.DataPropertyName = "CommissionPct";
			this.uxCommissionPctDataGridViewColumn.HeaderText = "CommissionPct";
			this.uxCommissionPctDataGridViewColumn.Name = "uxCommissionPctDataGridViewColumn";
			this.uxCommissionPctDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCommissionPctDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCommissionPctDataGridViewColumn.ReadOnly = false;		
			//
			// uxSalesYtdDataGridViewColumn
			//
			this.uxSalesYtdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesYtdDataGridViewColumn.DataPropertyName = "SalesYtd";
			this.uxSalesYtdDataGridViewColumn.HeaderText = "SalesYtd";
			this.uxSalesYtdDataGridViewColumn.Name = "uxSalesYtdDataGridViewColumn";
			this.uxSalesYtdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesYtdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesYtdDataGridViewColumn.ReadOnly = false;		
			//
			// uxSalesLastYearDataGridViewColumn
			//
			this.uxSalesLastYearDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesLastYearDataGridViewColumn.DataPropertyName = "SalesLastYear";
			this.uxSalesLastYearDataGridViewColumn.HeaderText = "SalesLastYear";
			this.uxSalesLastYearDataGridViewColumn.Name = "uxSalesLastYearDataGridViewColumn";
			this.uxSalesLastYearDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesLastYearDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesLastYearDataGridViewColumn.ReadOnly = false;		
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
			// uxSalesPersonIdDataGridViewColumn
			//				
			this.uxSalesPersonIdDataGridViewColumn.DisplayMember = "NationalIdNumber";	
			this.uxSalesPersonIdDataGridViewColumn.ValueMember = "EmployeeId";	
			this.uxSalesPersonIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSalesPersonIdDataGridViewColumn.DataSource = uxSalesPersonIdBindingSource;				
				
			//
			// uxTerritoryIdDataGridViewColumn
			//				
			this.uxTerritoryIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxTerritoryIdDataGridViewColumn.ValueMember = "TerritoryId";	
			this.uxTerritoryIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxTerritoryIdDataGridViewColumn.DataSource = uxTerritoryIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxSalesPersonDataGridView);
			this.Name = "SalesPersonDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonBindingSource)).EndInit();
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
				SalesPersonDataGridViewEventArgs args = new SalesPersonDataGridViewEventArgs();
				args.SalesPerson = _currentSalesPerson;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesPersonDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesPerson	_SalesPerson;
	
			/// <summary>
			/// the  Entities.SalesPerson instance.
			/// </summary>
			public Entities.SalesPerson SalesPerson
			{
				get { return _SalesPerson; }
				set { _SalesPerson = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesPersonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesPersonDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesPersonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesPersonDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesPersonDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesPersonIdDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].SalesPersonId;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].TerritoryId;
						break;
					case "uxSalesQuotaDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].SalesQuota;
						break;
					case "uxBonusDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].Bonus;
						break;
					case "uxCommissionPctDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].CommissionPct;
						break;
					case "uxSalesYtdDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].SalesYtd;
						break;
					case "uxSalesLastYearDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].SalesLastYear;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesPersonList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesPersonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesPersonDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesPersonDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesPersonIdDataGridViewColumn":
						SalesPersonList[e.RowIndex].SalesPersonId = (System.Int32)e.Value;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						SalesPersonList[e.RowIndex].TerritoryId = (System.Int32?)e.Value;
						break;
					case "uxSalesQuotaDataGridViewColumn":
						SalesPersonList[e.RowIndex].SalesQuota = (System.Decimal?)e.Value;
						break;
					case "uxBonusDataGridViewColumn":
						SalesPersonList[e.RowIndex].Bonus = (System.Decimal)e.Value;
						break;
					case "uxCommissionPctDataGridViewColumn":
						SalesPersonList[e.RowIndex].CommissionPct = (System.Decimal)e.Value;
						break;
					case "uxSalesYtdDataGridViewColumn":
						SalesPersonList[e.RowIndex].SalesYtd = (System.Decimal)e.Value;
						break;
					case "uxSalesLastYearDataGridViewColumn":
						SalesPersonList[e.RowIndex].SalesLastYear = (System.Decimal)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SalesPersonList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesPersonList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
