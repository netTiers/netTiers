
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductVendor typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductVendorDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductVendorDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductVendor _currentProductVendor = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductVendorDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductVendorErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductVendorBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the VendorId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxVendorIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AverageLeadTime property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAverageLeadTimeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StandardPrice property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStandardPriceDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LastReceiptCost property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLastReceiptCostDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LastReceiptDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLastReceiptDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the MinOrderQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxMinOrderQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the MaxOrderQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxMaxOrderQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OnOrderQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOnOrderQtyDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the UnitMeasureCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxUnitMeasureCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Product> _ProductIdList;
		
		/// <summary> 
		/// The list of selectable Product
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Product> ProductIdList
		{
			get {return this._ProductIdList;}
			set 
			{
				this._ProductIdList = value;
				this.uxProductIdDataGridViewColumn.DataSource = null;
				this.uxProductIdDataGridViewColumn.DataSource = this._ProductIdList;
			}
		}
		
		private bool _allowNewItemInProductIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Product
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductIdList
		{
			get { return _allowNewItemInProductIdList;}
			set
			{
				this._allowNewItemInProductIdList = value;
				this.uxProductIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.UnitMeasure> _UnitMeasureCodeList;
		
		/// <summary> 
		/// The list of selectable UnitMeasure
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.UnitMeasure> UnitMeasureCodeList
		{
			get {return this._UnitMeasureCodeList;}
			set 
			{
				this._UnitMeasureCodeList = value;
				this.uxUnitMeasureCodeDataGridViewColumn.DataSource = null;
				this.uxUnitMeasureCodeDataGridViewColumn.DataSource = this._UnitMeasureCodeList;
			}
		}
		
		private bool _allowNewItemInUnitMeasureCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of UnitMeasure
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInUnitMeasureCodeList
		{
			get { return _allowNewItemInUnitMeasureCodeList;}
			set
			{
				this._allowNewItemInUnitMeasureCodeList = value;
				this.uxUnitMeasureCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Vendor> _VendorIdList;
		
		/// <summary> 
		/// The list of selectable Vendor
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Vendor> VendorIdList
		{
			get {return this._VendorIdList;}
			set 
			{
				this._VendorIdList = value;
				this.uxVendorIdDataGridViewColumn.DataSource = null;
				this.uxVendorIdDataGridViewColumn.DataSource = this._VendorIdList;
			}
		}
		
		private bool _allowNewItemInVendorIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Vendor
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInVendorIdList
		{
			get { return _allowNewItemInVendorIdList;}
			set
			{
				this._allowNewItemInVendorIdList = value;
				this.uxVendorIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductVendor> _ProductVendorList;
				
		/// <summary> 
		/// The list of ProductVendor to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductVendor> ProductVendorList
		{
			get {return this._ProductVendorList;}
			set
			{
				this._ProductVendorList = value;
				this.uxProductVendorBindingSource.DataSource = null;
				this.uxProductVendorBindingSource.DataSource = value;
				this.uxProductVendorDataGridView.DataSource = null;
				this.uxProductVendorDataGridView.DataSource = this.uxProductVendorBindingSource;				
				//this.uxProductVendorBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductVendorBindingSource_ListChanged);
				this.uxProductVendorBindingSource.CurrentItemChanged += new System.EventHandler(OnProductVendorBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductVendorBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductVendor = uxProductVendorBindingSource.Current as Entities.ProductVendor;
			
			if (_currentProductVendor != null)
			{
				_currentProductVendor.Validate();
			}
			//_ProductVendor.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductVendorBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductVendor"/> instance.
		/// </summary>
		public Entities.ProductVendor SelectedProductVendor
		{
			get {return this._currentProductVendor;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductVendorDataGridView.VirtualMode;}
			set
			{
				this.uxProductVendorDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductVendorDataGridView.AllowUserToAddRows;}
			set {this.uxProductVendorDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductVendorDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductVendorDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductVendorDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductVendorDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductVendorDataGridViewBase"/> class.
		/// </summary>
		public ProductVendorDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductVendorDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductVendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductVendorErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxVendorIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAverageLeadTimeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStandardPriceDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLastReceiptCostDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLastReceiptDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMinOrderQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMaxOrderQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxOnOrderQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUnitMeasureCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			//this.uxUnitMeasureCodeBindingSource = new UnitMeasureBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureCodeBindingSource)).BeginInit();
			//this.uxVendorIdBindingSource = new VendorBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxVendorIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductVendorDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductVendorBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductVendorErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductVendorErrorProvider
			// 
			this.uxProductVendorErrorProvider.ContainerControl = this;
			this.uxProductVendorErrorProvider.DataSource = this.uxProductVendorBindingSource;						
			// 
			// uxProductVendorDataGridView
			// 
			this.uxProductVendorDataGridView.AutoGenerateColumns = false;
			this.uxProductVendorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductVendorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductIdDataGridViewColumn,
		this.uxVendorIdDataGridViewColumn,
		this.uxAverageLeadTimeDataGridViewColumn,
		this.uxStandardPriceDataGridViewColumn,
		this.uxLastReceiptCostDataGridViewColumn,
		this.uxLastReceiptDateDataGridViewColumn,
		this.uxMinOrderQtyDataGridViewColumn,
		this.uxMaxOrderQtyDataGridViewColumn,
		this.uxOnOrderQtyDataGridViewColumn,
		this.uxUnitMeasureCodeDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductVendorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductVendorDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductVendorDataGridView.Name = "uxProductVendorDataGridView";
			this.uxProductVendorDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductVendorDataGridView.TabIndex = 0;	
			this.uxProductVendorDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductVendorDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductVendorDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductVendorDataGridViewDataError);
			this.uxProductVendorDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductVendorDataGridViewCellValueNeeded);
			this.uxProductVendorDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductVendorDataGridViewCellValuePushed);
			
			//
			// uxProductIdDataGridViewColumn
			//
			this.uxProductIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductIdDataGridViewColumn.DataPropertyName = "ProductId";
			this.uxProductIdDataGridViewColumn.HeaderText = "ProductId";
			this.uxProductIdDataGridViewColumn.Name = "uxProductIdDataGridViewColumn";
			this.uxProductIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxVendorIdDataGridViewColumn
			//
			this.uxVendorIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxVendorIdDataGridViewColumn.DataPropertyName = "VendorId";
			this.uxVendorIdDataGridViewColumn.HeaderText = "VendorId";
			this.uxVendorIdDataGridViewColumn.Name = "uxVendorIdDataGridViewColumn";
			this.uxVendorIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxVendorIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxVendorIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxAverageLeadTimeDataGridViewColumn
			//
			this.uxAverageLeadTimeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAverageLeadTimeDataGridViewColumn.DataPropertyName = "AverageLeadTime";
			this.uxAverageLeadTimeDataGridViewColumn.HeaderText = "AverageLeadTime";
			this.uxAverageLeadTimeDataGridViewColumn.Name = "uxAverageLeadTimeDataGridViewColumn";
			this.uxAverageLeadTimeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAverageLeadTimeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAverageLeadTimeDataGridViewColumn.ReadOnly = false;		
			//
			// uxStandardPriceDataGridViewColumn
			//
			this.uxStandardPriceDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStandardPriceDataGridViewColumn.DataPropertyName = "StandardPrice";
			this.uxStandardPriceDataGridViewColumn.HeaderText = "StandardPrice";
			this.uxStandardPriceDataGridViewColumn.Name = "uxStandardPriceDataGridViewColumn";
			this.uxStandardPriceDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStandardPriceDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStandardPriceDataGridViewColumn.ReadOnly = false;		
			//
			// uxLastReceiptCostDataGridViewColumn
			//
			this.uxLastReceiptCostDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLastReceiptCostDataGridViewColumn.DataPropertyName = "LastReceiptCost";
			this.uxLastReceiptCostDataGridViewColumn.HeaderText = "LastReceiptCost";
			this.uxLastReceiptCostDataGridViewColumn.Name = "uxLastReceiptCostDataGridViewColumn";
			this.uxLastReceiptCostDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLastReceiptCostDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLastReceiptCostDataGridViewColumn.ReadOnly = false;		
			//
			// uxLastReceiptDateDataGridViewColumn
			//
			this.uxLastReceiptDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLastReceiptDateDataGridViewColumn.DataPropertyName = "LastReceiptDate";
			this.uxLastReceiptDateDataGridViewColumn.HeaderText = "LastReceiptDate";
			this.uxLastReceiptDateDataGridViewColumn.Name = "uxLastReceiptDateDataGridViewColumn";
			this.uxLastReceiptDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLastReceiptDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLastReceiptDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxMinOrderQtyDataGridViewColumn
			//
			this.uxMinOrderQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMinOrderQtyDataGridViewColumn.DataPropertyName = "MinOrderQty";
			this.uxMinOrderQtyDataGridViewColumn.HeaderText = "MinOrderQty";
			this.uxMinOrderQtyDataGridViewColumn.Name = "uxMinOrderQtyDataGridViewColumn";
			this.uxMinOrderQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMinOrderQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMinOrderQtyDataGridViewColumn.ReadOnly = false;		
			//
			// uxMaxOrderQtyDataGridViewColumn
			//
			this.uxMaxOrderQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMaxOrderQtyDataGridViewColumn.DataPropertyName = "MaxOrderQty";
			this.uxMaxOrderQtyDataGridViewColumn.HeaderText = "MaxOrderQty";
			this.uxMaxOrderQtyDataGridViewColumn.Name = "uxMaxOrderQtyDataGridViewColumn";
			this.uxMaxOrderQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMaxOrderQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMaxOrderQtyDataGridViewColumn.ReadOnly = false;		
			//
			// uxOnOrderQtyDataGridViewColumn
			//
			this.uxOnOrderQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxOnOrderQtyDataGridViewColumn.DataPropertyName = "OnOrderQty";
			this.uxOnOrderQtyDataGridViewColumn.HeaderText = "OnOrderQty";
			this.uxOnOrderQtyDataGridViewColumn.Name = "uxOnOrderQtyDataGridViewColumn";
			this.uxOnOrderQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxOnOrderQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxOnOrderQtyDataGridViewColumn.ReadOnly = false;		
			//
			// uxUnitMeasureCodeDataGridViewColumn
			//
			this.uxUnitMeasureCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUnitMeasureCodeDataGridViewColumn.DataPropertyName = "UnitMeasureCode";
			this.uxUnitMeasureCodeDataGridViewColumn.HeaderText = "UnitMeasureCode";
			this.uxUnitMeasureCodeDataGridViewColumn.Name = "uxUnitMeasureCodeDataGridViewColumn";
			this.uxUnitMeasureCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUnitMeasureCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUnitMeasureCodeDataGridViewColumn.ReadOnly = false;		
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
			// uxProductIdDataGridViewColumn
			//				
			this.uxProductIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductIdDataGridViewColumn.ValueMember = "ProductId";	
			this.uxProductIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductIdDataGridViewColumn.DataSource = uxProductIdBindingSource;				
				
			//
			// uxUnitMeasureCodeDataGridViewColumn
			//				
			this.uxUnitMeasureCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxUnitMeasureCodeDataGridViewColumn.ValueMember = "UnitMeasureCode";	
			this.uxUnitMeasureCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxUnitMeasureCodeDataGridViewColumn.DataSource = uxUnitMeasureCodeBindingSource;				
				
			//
			// uxVendorIdDataGridViewColumn
			//				
			this.uxVendorIdDataGridViewColumn.DisplayMember = "AccountNumber";	
			this.uxVendorIdDataGridViewColumn.ValueMember = "VendorId";	
			this.uxVendorIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxVendorIdDataGridViewColumn.DataSource = uxVendorIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductVendorDataGridView);
			this.Name = "ProductVendorDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureCodeBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxVendorIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductVendorErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductVendorDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductVendorBindingSource)).EndInit();
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
				ProductVendorDataGridViewEventArgs args = new ProductVendorDataGridViewEventArgs();
				args.ProductVendor = _currentProductVendor;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductVendorDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductVendor	_ProductVendor;
	
			/// <summary>
			/// the  Entities.ProductVendor instance.
			/// </summary>
			public Entities.ProductVendor ProductVendor
			{
				get { return _ProductVendor; }
				set { _ProductVendor = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductVendorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductVendorDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductVendorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductVendorDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductVendorDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].ProductId;
						break;
					case "uxVendorIdDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].VendorId;
						break;
					case "uxAverageLeadTimeDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].AverageLeadTime;
						break;
					case "uxStandardPriceDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].StandardPrice;
						break;
					case "uxLastReceiptCostDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].LastReceiptCost;
						break;
					case "uxLastReceiptDateDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].LastReceiptDate;
						break;
					case "uxMinOrderQtyDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].MinOrderQty;
						break;
					case "uxMaxOrderQtyDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].MaxOrderQty;
						break;
					case "uxOnOrderQtyDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].OnOrderQty;
						break;
					case "uxUnitMeasureCodeDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].UnitMeasureCode;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductVendorList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductVendorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductVendorDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductVendorDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						ProductVendorList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxVendorIdDataGridViewColumn":
						ProductVendorList[e.RowIndex].VendorId = (System.Int32)e.Value;
						break;
					case "uxAverageLeadTimeDataGridViewColumn":
						ProductVendorList[e.RowIndex].AverageLeadTime = (System.Int32)e.Value;
						break;
					case "uxStandardPriceDataGridViewColumn":
						ProductVendorList[e.RowIndex].StandardPrice = (System.Decimal)e.Value;
						break;
					case "uxLastReceiptCostDataGridViewColumn":
						ProductVendorList[e.RowIndex].LastReceiptCost = (System.Decimal?)e.Value;
						break;
					case "uxLastReceiptDateDataGridViewColumn":
						ProductVendorList[e.RowIndex].LastReceiptDate = (System.DateTime?)e.Value;
						break;
					case "uxMinOrderQtyDataGridViewColumn":
						ProductVendorList[e.RowIndex].MinOrderQty = (System.Int32)e.Value;
						break;
					case "uxMaxOrderQtyDataGridViewColumn":
						ProductVendorList[e.RowIndex].MaxOrderQty = (System.Int32)e.Value;
						break;
					case "uxOnOrderQtyDataGridViewColumn":
						ProductVendorList[e.RowIndex].OnOrderQty = (System.Int32?)e.Value;
						break;
					case "uxUnitMeasureCodeDataGridViewColumn":
						ProductVendorList[e.RowIndex].UnitMeasureCode = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductVendorList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
