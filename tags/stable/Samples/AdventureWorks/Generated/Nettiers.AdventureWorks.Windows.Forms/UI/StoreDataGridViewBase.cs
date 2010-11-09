
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Store typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class StoreDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<StoreDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Store _currentStore = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxStoreDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxStoreErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxStoreBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the CustomerId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCustomerIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the SalesPersonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSalesPersonIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Demographics property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDemographicsDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Customer> _CustomerIdList;
		
		/// <summary> 
		/// The list of selectable Customer
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Customer> CustomerIdList
		{
			get {return this._CustomerIdList;}
			set 
			{
				this._CustomerIdList = value;
				this.uxCustomerIdDataGridViewColumn.DataSource = null;
				this.uxCustomerIdDataGridViewColumn.DataSource = this._CustomerIdList;
			}
		}
		
		private bool _allowNewItemInCustomerIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Customer
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCustomerIdList
		{
			get { return _allowNewItemInCustomerIdList;}
			set
			{
				this._allowNewItemInCustomerIdList = value;
				this.uxCustomerIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Store> _StoreList;
				
		/// <summary> 
		/// The list of Store to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Store> StoreList
		{
			get {return this._StoreList;}
			set
			{
				this._StoreList = value;
				this.uxStoreBindingSource.DataSource = null;
				this.uxStoreBindingSource.DataSource = value;
				this.uxStoreDataGridView.DataSource = null;
				this.uxStoreDataGridView.DataSource = this.uxStoreBindingSource;				
				//this.uxStoreBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxStoreBindingSource_ListChanged);
				this.uxStoreBindingSource.CurrentItemChanged += new System.EventHandler(OnStoreBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnStoreBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentStore = uxStoreBindingSource.Current as Entities.Store;
			
			if (_currentStore != null)
			{
				_currentStore.Validate();
			}
			//_Store.Validate();
			OnCurrentEntityChanged();
		}

		//void uxStoreBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Store"/> instance.
		/// </summary>
		public Entities.Store SelectedStore
		{
			get {return this._currentStore;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxStoreDataGridView.VirtualMode;}
			set
			{
				this.uxStoreDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxStoreDataGridView.AllowUserToAddRows;}
			set {this.uxStoreDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxStoreDataGridView.AllowUserToDeleteRows;}
			set {this.uxStoreDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxStoreDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxStoreDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="StoreDataGridViewBase"/> class.
		/// </summary>
		public StoreDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxStoreDataGridView = new System.Windows.Forms.DataGridView();
			this.uxStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxStoreErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCustomerIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSalesPersonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxDemographicsDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxCustomerIdBindingSource = new CustomerBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).BeginInit();
			//this.uxSalesPersonIdBindingSource = new SalesPersonBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxStoreErrorProvider
			// 
			this.uxStoreErrorProvider.ContainerControl = this;
			this.uxStoreErrorProvider.DataSource = this.uxStoreBindingSource;						
			// 
			// uxStoreDataGridView
			// 
			this.uxStoreDataGridView.AutoGenerateColumns = false;
			this.uxStoreDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxStoreDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCustomerIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxSalesPersonIdDataGridViewColumn,
		this.uxDemographicsDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxStoreDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxStoreDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxStoreDataGridView.Name = "uxStoreDataGridView";
			this.uxStoreDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxStoreDataGridView.TabIndex = 0;	
			this.uxStoreDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxStoreDataGridView.EnableHeadersVisualStyles = false;
			this.uxStoreDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnStoreDataGridViewDataError);
			this.uxStoreDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnStoreDataGridViewCellValueNeeded);
			this.uxStoreDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnStoreDataGridViewCellValuePushed);
			
			//
			// uxCustomerIdDataGridViewColumn
			//
			this.uxCustomerIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCustomerIdDataGridViewColumn.DataPropertyName = "CustomerId";
			this.uxCustomerIdDataGridViewColumn.HeaderText = "CustomerId";
			this.uxCustomerIdDataGridViewColumn.Name = "uxCustomerIdDataGridViewColumn";
			this.uxCustomerIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCustomerIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCustomerIdDataGridViewColumn.ReadOnly = false;		
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
			// uxDemographicsDataGridViewColumn
			//
			this.uxDemographicsDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDemographicsDataGridViewColumn.DataPropertyName = "Demographics";
			this.uxDemographicsDataGridViewColumn.HeaderText = "Demographics";
			this.uxDemographicsDataGridViewColumn.Name = "uxDemographicsDataGridViewColumn";
			this.uxDemographicsDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDemographicsDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDemographicsDataGridViewColumn.ReadOnly = false;		
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
			// uxCustomerIdDataGridViewColumn
			//				
			this.uxCustomerIdDataGridViewColumn.DisplayMember = "TerritoryId";	
			this.uxCustomerIdDataGridViewColumn.ValueMember = "CustomerId";	
			this.uxCustomerIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCustomerIdDataGridViewColumn.DataSource = uxCustomerIdBindingSource;				
				
			//
			// uxSalesPersonIdDataGridViewColumn
			//				
			this.uxSalesPersonIdDataGridViewColumn.DisplayMember = "TerritoryId";	
			this.uxSalesPersonIdDataGridViewColumn.ValueMember = "SalesPersonId";	
			this.uxSalesPersonIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSalesPersonIdDataGridViewColumn.DataSource = uxSalesPersonIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxStoreDataGridView);
			this.Name = "StoreDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreBindingSource)).EndInit();
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
				StoreDataGridViewEventArgs args = new StoreDataGridViewEventArgs();
				args.Store = _currentStore;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class StoreDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Store	_Store;
	
			/// <summary>
			/// the  Entities.Store instance.
			/// </summary>
			public Entities.Store Store
			{
				get { return _Store; }
				set { _Store = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxStoreDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnStoreDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxStoreDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnStoreDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxStoreDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						e.Value = StoreList[e.RowIndex].CustomerId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = StoreList[e.RowIndex].Name;
						break;
					case "uxSalesPersonIdDataGridViewColumn":
						e.Value = StoreList[e.RowIndex].SalesPersonId;
						break;
					case "uxDemographicsDataGridViewColumn":
						e.Value = StoreList[e.RowIndex].Demographics;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = StoreList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = StoreList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxStoreDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnStoreDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxStoreDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						StoreList[e.RowIndex].CustomerId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						StoreList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxSalesPersonIdDataGridViewColumn":
						StoreList[e.RowIndex].SalesPersonId = (System.Int32?)e.Value;
						break;
					case "uxDemographicsDataGridViewColumn":
						StoreList[e.RowIndex].Demographics = (string)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						StoreList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						StoreList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
