
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesTerritory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesTerritoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesTerritoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesTerritory _currentSalesTerritory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesTerritoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesTerritoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesTerritoryBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the TerritoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTerritoryIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CountryRegionCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCountryRegionCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Group property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxGroupDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalesYtd property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesYtdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalesLastYear property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesLastYearDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CostYtd property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCostYtdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CostLastYear property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCostLastYearDataGridViewColumn;
		
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SalesTerritory> _SalesTerritoryList;
				
		/// <summary> 
		/// The list of SalesTerritory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesTerritory> SalesTerritoryList
		{
			get {return this._SalesTerritoryList;}
			set
			{
				this._SalesTerritoryList = value;
				this.uxSalesTerritoryBindingSource.DataSource = null;
				this.uxSalesTerritoryBindingSource.DataSource = value;
				this.uxSalesTerritoryDataGridView.DataSource = null;
				this.uxSalesTerritoryDataGridView.DataSource = this.uxSalesTerritoryBindingSource;				
				//this.uxSalesTerritoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesTerritoryBindingSource_ListChanged);
				this.uxSalesTerritoryBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesTerritoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesTerritoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesTerritory = uxSalesTerritoryBindingSource.Current as Entities.SalesTerritory;
			
			if (_currentSalesTerritory != null)
			{
				_currentSalesTerritory.Validate();
			}
			//_SalesTerritory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesTerritoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesTerritory"/> instance.
		/// </summary>
		public Entities.SalesTerritory SelectedSalesTerritory
		{
			get {return this._currentSalesTerritory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesTerritoryDataGridView.VirtualMode;}
			set
			{
				this.uxSalesTerritoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesTerritoryDataGridView.AllowUserToAddRows;}
			set {this.uxSalesTerritoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesTerritoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesTerritoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesTerritoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesTerritoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesTerritoryDataGridViewBase"/> class.
		/// </summary>
		public SalesTerritoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesTerritoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesTerritoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesTerritoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTerritoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCountryRegionCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxGroupDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSalesYtdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSalesLastYearDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCostYtdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCostLastYearDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesTerritoryErrorProvider
			// 
			this.uxSalesTerritoryErrorProvider.ContainerControl = this;
			this.uxSalesTerritoryErrorProvider.DataSource = this.uxSalesTerritoryBindingSource;						
			// 
			// uxSalesTerritoryDataGridView
			// 
			this.uxSalesTerritoryDataGridView.AutoGenerateColumns = false;
			this.uxSalesTerritoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesTerritoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTerritoryIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxCountryRegionCodeDataGridViewColumn,
		this.uxGroupDataGridViewColumn,
		this.uxSalesYtdDataGridViewColumn,
		this.uxSalesLastYearDataGridViewColumn,
		this.uxCostYtdDataGridViewColumn,
		this.uxCostLastYearDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesTerritoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesTerritoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesTerritoryDataGridView.Name = "uxSalesTerritoryDataGridView";
			this.uxSalesTerritoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesTerritoryDataGridView.TabIndex = 0;	
			this.uxSalesTerritoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesTerritoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesTerritoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesTerritoryDataGridViewDataError);
			this.uxSalesTerritoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesTerritoryDataGridViewCellValueNeeded);
			this.uxSalesTerritoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesTerritoryDataGridViewCellValuePushed);
			
			//
			// uxTerritoryIdDataGridViewColumn
			//
			this.uxTerritoryIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTerritoryIdDataGridViewColumn.DataPropertyName = "TerritoryId";
			this.uxTerritoryIdDataGridViewColumn.HeaderText = "TerritoryId";
			this.uxTerritoryIdDataGridViewColumn.Name = "uxTerritoryIdDataGridViewColumn";
			this.uxTerritoryIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTerritoryIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTerritoryIdDataGridViewColumn.ReadOnly = true;		
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
			// uxGroupDataGridViewColumn
			//
			this.uxGroupDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxGroupDataGridViewColumn.DataPropertyName = "Group";
			this.uxGroupDataGridViewColumn.HeaderText = "Group";
			this.uxGroupDataGridViewColumn.Name = "uxGroupDataGridViewColumn";
			this.uxGroupDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxGroupDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxGroupDataGridViewColumn.ReadOnly = false;		
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
			// uxCostYtdDataGridViewColumn
			//
			this.uxCostYtdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCostYtdDataGridViewColumn.DataPropertyName = "CostYtd";
			this.uxCostYtdDataGridViewColumn.HeaderText = "CostYtd";
			this.uxCostYtdDataGridViewColumn.Name = "uxCostYtdDataGridViewColumn";
			this.uxCostYtdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCostYtdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCostYtdDataGridViewColumn.ReadOnly = false;		
			//
			// uxCostLastYearDataGridViewColumn
			//
			this.uxCostLastYearDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCostLastYearDataGridViewColumn.DataPropertyName = "CostLastYear";
			this.uxCostLastYearDataGridViewColumn.HeaderText = "CostLastYear";
			this.uxCostLastYearDataGridViewColumn.Name = "uxCostLastYearDataGridViewColumn";
			this.uxCostLastYearDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCostLastYearDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCostLastYearDataGridViewColumn.ReadOnly = false;		
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
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxSalesTerritoryDataGridView);
			this.Name = "SalesTerritoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryBindingSource)).EndInit();
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
				SalesTerritoryDataGridViewEventArgs args = new SalesTerritoryDataGridViewEventArgs();
				args.SalesTerritory = _currentSalesTerritory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesTerritoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesTerritory	_SalesTerritory;
	
			/// <summary>
			/// the  Entities.SalesTerritory instance.
			/// </summary>
			public Entities.SalesTerritory SalesTerritory
			{
				get { return _SalesTerritory; }
				set { _SalesTerritory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesTerritoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTerritoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesTerritoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTerritoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesTerritoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTerritoryIdDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].TerritoryId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].Name;
						break;
					case "uxCountryRegionCodeDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].CountryRegionCode;
						break;
					case "uxGroupDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].Group;
						break;
					case "uxSalesYtdDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].SalesYtd;
						break;
					case "uxSalesLastYearDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].SalesLastYear;
						break;
					case "uxCostYtdDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].CostYtd;
						break;
					case "uxCostLastYearDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].CostLastYear;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesTerritoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesTerritoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTerritoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesTerritoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTerritoryIdDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].TerritoryId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxCountryRegionCodeDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].CountryRegionCode = (System.String)e.Value;
						break;
					case "uxGroupDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].Group = (System.String)e.Value;
						break;
					case "uxSalesYtdDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].SalesYtd = (System.Decimal)e.Value;
						break;
					case "uxSalesLastYearDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].SalesLastYear = (System.Decimal)e.Value;
						break;
					case "uxCostYtdDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].CostYtd = (System.Decimal)e.Value;
						break;
					case "uxCostLastYearDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].CostLastYear = (System.Decimal)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesTerritoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
