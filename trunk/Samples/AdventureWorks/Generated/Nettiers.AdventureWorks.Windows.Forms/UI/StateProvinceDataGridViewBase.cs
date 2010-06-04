
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract StateProvince typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class StateProvinceDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<StateProvinceDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.StateProvince _currentStateProvince = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxStateProvinceDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxStateProvinceErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxStateProvinceBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the StateProvinceId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStateProvinceIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StateProvinceCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStateProvinceCodeDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the CountryRegionCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCountryRegionCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the IsOnlyStateProvinceFlag property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIsOnlyStateProvinceFlagDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the TerritoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxTerritoryIdDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.CountryRegion> _CountryRegionCodeList;
		
		/// <summary> 
		/// The list of selectable CountryRegion
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.CountryRegion> CountryRegionCodeList
		{
			get {return this._CountryRegionCodeList;}
			set 
			{
				this._CountryRegionCodeList = value;
				this.uxCountryRegionCodeDataGridViewColumn.DataSource = null;
				this.uxCountryRegionCodeDataGridViewColumn.DataSource = this._CountryRegionCodeList;
			}
		}
		
		private bool _allowNewItemInCountryRegionCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of CountryRegion
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCountryRegionCodeList
		{
			get { return _allowNewItemInCountryRegionCodeList;}
			set
			{
				this._allowNewItemInCountryRegionCodeList = value;
				this.uxCountryRegionCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
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
		
		private Entities.TList<Entities.StateProvince> _StateProvinceList;
				
		/// <summary> 
		/// The list of StateProvince to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.StateProvince> StateProvinceList
		{
			get {return this._StateProvinceList;}
			set
			{
				this._StateProvinceList = value;
				this.uxStateProvinceBindingSource.DataSource = null;
				this.uxStateProvinceBindingSource.DataSource = value;
				this.uxStateProvinceDataGridView.DataSource = null;
				this.uxStateProvinceDataGridView.DataSource = this.uxStateProvinceBindingSource;				
				//this.uxStateProvinceBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxStateProvinceBindingSource_ListChanged);
				this.uxStateProvinceBindingSource.CurrentItemChanged += new System.EventHandler(OnStateProvinceBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnStateProvinceBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentStateProvince = uxStateProvinceBindingSource.Current as Entities.StateProvince;
			
			if (_currentStateProvince != null)
			{
				_currentStateProvince.Validate();
			}
			//_StateProvince.Validate();
			OnCurrentEntityChanged();
		}

		//void uxStateProvinceBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.StateProvince"/> instance.
		/// </summary>
		public Entities.StateProvince SelectedStateProvince
		{
			get {return this._currentStateProvince;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxStateProvinceDataGridView.VirtualMode;}
			set
			{
				this.uxStateProvinceDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxStateProvinceDataGridView.AllowUserToAddRows;}
			set {this.uxStateProvinceDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxStateProvinceDataGridView.AllowUserToDeleteRows;}
			set {this.uxStateProvinceDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxStateProvinceDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxStateProvinceDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="StateProvinceDataGridViewBase"/> class.
		/// </summary>
		public StateProvinceDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxStateProvinceDataGridView = new System.Windows.Forms.DataGridView();
			this.uxStateProvinceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxStateProvinceErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxStateProvinceIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStateProvinceCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCountryRegionCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxIsOnlyStateProvinceFlagDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTerritoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxCountryRegionCodeBindingSource = new CountryRegionBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCodeBindingSource)).BeginInit();
			//this.uxTerritoryIdBindingSource = new SalesTerritoryBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxStateProvinceErrorProvider
			// 
			this.uxStateProvinceErrorProvider.ContainerControl = this;
			this.uxStateProvinceErrorProvider.DataSource = this.uxStateProvinceBindingSource;						
			// 
			// uxStateProvinceDataGridView
			// 
			this.uxStateProvinceDataGridView.AutoGenerateColumns = false;
			this.uxStateProvinceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxStateProvinceDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxStateProvinceIdDataGridViewColumn,
		this.uxStateProvinceCodeDataGridViewColumn,
		this.uxCountryRegionCodeDataGridViewColumn,
		this.uxIsOnlyStateProvinceFlagDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxTerritoryIdDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxStateProvinceDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxStateProvinceDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxStateProvinceDataGridView.Name = "uxStateProvinceDataGridView";
			this.uxStateProvinceDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxStateProvinceDataGridView.TabIndex = 0;	
			this.uxStateProvinceDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxStateProvinceDataGridView.EnableHeadersVisualStyles = false;
			this.uxStateProvinceDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnStateProvinceDataGridViewDataError);
			this.uxStateProvinceDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnStateProvinceDataGridViewCellValueNeeded);
			this.uxStateProvinceDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnStateProvinceDataGridViewCellValuePushed);
			
			//
			// uxStateProvinceIdDataGridViewColumn
			//
			this.uxStateProvinceIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStateProvinceIdDataGridViewColumn.DataPropertyName = "StateProvinceId";
			this.uxStateProvinceIdDataGridViewColumn.HeaderText = "StateProvinceId";
			this.uxStateProvinceIdDataGridViewColumn.Name = "uxStateProvinceIdDataGridViewColumn";
			this.uxStateProvinceIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStateProvinceIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStateProvinceIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxStateProvinceCodeDataGridViewColumn
			//
			this.uxStateProvinceCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStateProvinceCodeDataGridViewColumn.DataPropertyName = "StateProvinceCode";
			this.uxStateProvinceCodeDataGridViewColumn.HeaderText = "StateProvinceCode";
			this.uxStateProvinceCodeDataGridViewColumn.Name = "uxStateProvinceCodeDataGridViewColumn";
			this.uxStateProvinceCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStateProvinceCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStateProvinceCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxCountryRegionCodeDataGridViewColumn
			//
			this.uxCountryRegionCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCountryRegionCodeDataGridViewColumn.DataPropertyName = "CountryRegionCode";
			this.uxCountryRegionCodeDataGridViewColumn.HeaderText = "CountryRegionCode";
			this.uxCountryRegionCodeDataGridViewColumn.Name = "uxCountryRegionCodeDataGridViewColumn";
			this.uxCountryRegionCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCountryRegionCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCountryRegionCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxIsOnlyStateProvinceFlagDataGridViewColumn
			//
			this.uxIsOnlyStateProvinceFlagDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIsOnlyStateProvinceFlagDataGridViewColumn.DataPropertyName = "IsOnlyStateProvinceFlag";
			this.uxIsOnlyStateProvinceFlagDataGridViewColumn.HeaderText = "IsOnlyStateProvinceFlag";
			this.uxIsOnlyStateProvinceFlagDataGridViewColumn.Name = "uxIsOnlyStateProvinceFlagDataGridViewColumn";
			this.uxIsOnlyStateProvinceFlagDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIsOnlyStateProvinceFlagDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIsOnlyStateProvinceFlagDataGridViewColumn.ReadOnly = false;		
			//
			// uxNameDataGridViewColumn
			//
			this.uxNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxNameDataGridViewColumn.DataPropertyName = "Name";
			this.uxNameDataGridViewColumn.HeaderText = "Name";
			this.uxNameDataGridViewColumn.Name = "uxNameDataGridViewColumn";
			this.uxNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxNameDataGridViewColumn.ReadOnly = false;		
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
			// uxCountryRegionCodeDataGridViewColumn
			//				
			this.uxCountryRegionCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxCountryRegionCodeDataGridViewColumn.ValueMember = "CountryRegionCode";	
			this.uxCountryRegionCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCountryRegionCodeDataGridViewColumn.DataSource = uxCountryRegionCodeBindingSource;				
				
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
			this.Controls.Add(this.uxStateProvinceDataGridView);
			this.Name = "StateProvinceDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCodeBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceBindingSource)).EndInit();
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
				StateProvinceDataGridViewEventArgs args = new StateProvinceDataGridViewEventArgs();
				args.StateProvince = _currentStateProvince;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class StateProvinceDataGridViewEventArgs : System.EventArgs
		{
			private Entities.StateProvince	_StateProvince;
	
			/// <summary>
			/// the  Entities.StateProvince instance.
			/// </summary>
			public Entities.StateProvince StateProvince
			{
				get { return _StateProvince; }
				set { _StateProvince = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxStateProvinceDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnStateProvinceDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxStateProvinceDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnStateProvinceDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxStateProvinceDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxStateProvinceIdDataGridViewColumn":
						e.Value = StateProvinceList[e.RowIndex].StateProvinceId;
						break;
					case "uxStateProvinceCodeDataGridViewColumn":
						e.Value = StateProvinceList[e.RowIndex].StateProvinceCode;
						break;
					case "uxCountryRegionCodeDataGridViewColumn":
						e.Value = StateProvinceList[e.RowIndex].CountryRegionCode;
						break;
					case "uxIsOnlyStateProvinceFlagDataGridViewColumn":
						e.Value = StateProvinceList[e.RowIndex].IsOnlyStateProvinceFlag;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = StateProvinceList[e.RowIndex].Name;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						e.Value = StateProvinceList[e.RowIndex].TerritoryId;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = StateProvinceList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = StateProvinceList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxStateProvinceDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnStateProvinceDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxStateProvinceDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxStateProvinceIdDataGridViewColumn":
						StateProvinceList[e.RowIndex].StateProvinceId = (System.Int32)e.Value;
						break;
					case "uxStateProvinceCodeDataGridViewColumn":
						StateProvinceList[e.RowIndex].StateProvinceCode = (System.String)e.Value;
						break;
					case "uxCountryRegionCodeDataGridViewColumn":
						StateProvinceList[e.RowIndex].CountryRegionCode = (System.String)e.Value;
						break;
					case "uxIsOnlyStateProvinceFlagDataGridViewColumn":
						StateProvinceList[e.RowIndex].IsOnlyStateProvinceFlag = (System.Boolean)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						StateProvinceList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						StateProvinceList[e.RowIndex].TerritoryId = (System.Int32)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						StateProvinceList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						StateProvinceList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
