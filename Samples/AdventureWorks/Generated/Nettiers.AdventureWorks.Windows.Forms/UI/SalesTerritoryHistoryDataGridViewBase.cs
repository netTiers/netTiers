
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesTerritoryHistory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesTerritoryHistoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesTerritoryHistoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesTerritoryHistory _currentSalesTerritoryHistory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesTerritoryHistoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesTerritoryHistoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesTerritoryHistoryBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the SalesPersonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSalesPersonIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the TerritoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxTerritoryIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEndDateDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.SalesPerson> _SalesPersonIdList;
		
		/// <summary> 
		/// The list of selectable SalesPerson
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SalesPerson> SalesPersonIdList
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
		/// Indicates if user can add an item in the list of SalesPerson
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
		
		private Entities.TList<Entities.SalesTerritoryHistory> _SalesTerritoryHistoryList;
				
		/// <summary> 
		/// The list of SalesTerritoryHistory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesTerritoryHistory> SalesTerritoryHistoryList
		{
			get {return this._SalesTerritoryHistoryList;}
			set
			{
				this._SalesTerritoryHistoryList = value;
				this.uxSalesTerritoryHistoryBindingSource.DataSource = null;
				this.uxSalesTerritoryHistoryBindingSource.DataSource = value;
				this.uxSalesTerritoryHistoryDataGridView.DataSource = null;
				this.uxSalesTerritoryHistoryDataGridView.DataSource = this.uxSalesTerritoryHistoryBindingSource;				
				//this.uxSalesTerritoryHistoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesTerritoryHistoryBindingSource_ListChanged);
				this.uxSalesTerritoryHistoryBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesTerritoryHistoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesTerritoryHistoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesTerritoryHistory = uxSalesTerritoryHistoryBindingSource.Current as Entities.SalesTerritoryHistory;
			
			if (_currentSalesTerritoryHistory != null)
			{
				_currentSalesTerritoryHistory.Validate();
			}
			//_SalesTerritoryHistory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesTerritoryHistoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesTerritoryHistory"/> instance.
		/// </summary>
		public Entities.SalesTerritoryHistory SelectedSalesTerritoryHistory
		{
			get {return this._currentSalesTerritoryHistory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesTerritoryHistoryDataGridView.VirtualMode;}
			set
			{
				this.uxSalesTerritoryHistoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesTerritoryHistoryDataGridView.AllowUserToAddRows;}
			set {this.uxSalesTerritoryHistoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesTerritoryHistoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesTerritoryHistoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesTerritoryHistoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesTerritoryHistoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesTerritoryHistoryDataGridViewBase"/> class.
		/// </summary>
		public SalesTerritoryHistoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesTerritoryHistoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesTerritoryHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesTerritoryHistoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSalesPersonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxTerritoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxSalesPersonIdBindingSource = new SalesPersonBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).BeginInit();
			//this.uxTerritoryIdBindingSource = new SalesTerritoryBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryHistoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryHistoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryHistoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesTerritoryHistoryErrorProvider
			// 
			this.uxSalesTerritoryHistoryErrorProvider.ContainerControl = this;
			this.uxSalesTerritoryHistoryErrorProvider.DataSource = this.uxSalesTerritoryHistoryBindingSource;						
			// 
			// uxSalesTerritoryHistoryDataGridView
			// 
			this.uxSalesTerritoryHistoryDataGridView.AutoGenerateColumns = false;
			this.uxSalesTerritoryHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesTerritoryHistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSalesPersonIdDataGridViewColumn,
		this.uxTerritoryIdDataGridViewColumn,
		this.uxStartDateDataGridViewColumn,
		this.uxEndDateDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesTerritoryHistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesTerritoryHistoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesTerritoryHistoryDataGridView.Name = "uxSalesTerritoryHistoryDataGridView";
			this.uxSalesTerritoryHistoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesTerritoryHistoryDataGridView.TabIndex = 0;	
			this.uxSalesTerritoryHistoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesTerritoryHistoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesTerritoryHistoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesTerritoryHistoryDataGridViewDataError);
			this.uxSalesTerritoryHistoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesTerritoryHistoryDataGridViewCellValueNeeded);
			this.uxSalesTerritoryHistoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesTerritoryHistoryDataGridViewCellValuePushed);
			
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
			// uxStartDateDataGridViewColumn
			//
			this.uxStartDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStartDateDataGridViewColumn.DataPropertyName = "StartDate";
			this.uxStartDateDataGridViewColumn.HeaderText = "StartDate";
			this.uxStartDateDataGridViewColumn.Name = "uxStartDateDataGridViewColumn";
			this.uxStartDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStartDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStartDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxEndDateDataGridViewColumn
			//
			this.uxEndDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEndDateDataGridViewColumn.DataPropertyName = "EndDate";
			this.uxEndDateDataGridViewColumn.HeaderText = "EndDate";
			this.uxEndDateDataGridViewColumn.Name = "uxEndDateDataGridViewColumn";
			this.uxEndDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEndDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEndDateDataGridViewColumn.ReadOnly = false;		
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
			this.uxSalesPersonIdDataGridViewColumn.DisplayMember = "TerritoryId";	
			this.uxSalesPersonIdDataGridViewColumn.ValueMember = "SalesPersonId";	
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
			this.Controls.Add(this.uxSalesTerritoryHistoryDataGridView);
			this.Name = "SalesTerritoryHistoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryHistoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryHistoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTerritoryHistoryBindingSource)).EndInit();
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
				SalesTerritoryHistoryDataGridViewEventArgs args = new SalesTerritoryHistoryDataGridViewEventArgs();
				args.SalesTerritoryHistory = _currentSalesTerritoryHistory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesTerritoryHistoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesTerritoryHistory	_SalesTerritoryHistory;
	
			/// <summary>
			/// the  Entities.SalesTerritoryHistory instance.
			/// </summary>
			public Entities.SalesTerritoryHistory SalesTerritoryHistory
			{
				get { return _SalesTerritoryHistory; }
				set { _SalesTerritoryHistory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesTerritoryHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTerritoryHistoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesTerritoryHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTerritoryHistoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesTerritoryHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesPersonIdDataGridViewColumn":
						e.Value = SalesTerritoryHistoryList[e.RowIndex].SalesPersonId;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						e.Value = SalesTerritoryHistoryList[e.RowIndex].TerritoryId;
						break;
					case "uxStartDateDataGridViewColumn":
						e.Value = SalesTerritoryHistoryList[e.RowIndex].StartDate;
						break;
					case "uxEndDateDataGridViewColumn":
						e.Value = SalesTerritoryHistoryList[e.RowIndex].EndDate;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SalesTerritoryHistoryList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesTerritoryHistoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesTerritoryHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTerritoryHistoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesTerritoryHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesPersonIdDataGridViewColumn":
						SalesTerritoryHistoryList[e.RowIndex].SalesPersonId = (System.Int32)e.Value;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						SalesTerritoryHistoryList[e.RowIndex].TerritoryId = (System.Int32)e.Value;
						break;
					case "uxStartDateDataGridViewColumn":
						SalesTerritoryHistoryList[e.RowIndex].StartDate = (System.DateTime)e.Value;
						break;
					case "uxEndDateDataGridViewColumn":
						SalesTerritoryHistoryList[e.RowIndex].EndDate = (System.DateTime?)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SalesTerritoryHistoryList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesTerritoryHistoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
