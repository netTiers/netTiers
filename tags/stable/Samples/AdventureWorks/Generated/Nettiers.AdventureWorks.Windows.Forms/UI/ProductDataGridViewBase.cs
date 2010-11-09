
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Product typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Product _currentProduct = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ProductNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the MakeFlag property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxMakeFlagDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the FinishedGoodsFlag property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxFinishedGoodsFlagDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Color property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxColorDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SafetyStockLevel property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSafetyStockLevelDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ReorderPoint property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxReorderPointDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StandardCost property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStandardCostDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ListPrice property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxListPriceDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Size property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSizeDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the SizeUnitMeasureCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSizeUnitMeasureCodeDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the WeightUnitMeasureCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxWeightUnitMeasureCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Weight property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxWeightDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DaysToManufacture property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDaysToManufactureDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ProductLine property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductLineDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SafeNameClass property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSafeNameClassDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Style property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStyleDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductSubcategoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductSubcategoryIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductModelId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductModelIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SellStartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSellStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SellEndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSellEndDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DiscontinuedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDiscontinuedDateDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.ProductModel> _ProductModelIdList;
		
		/// <summary> 
		/// The list of selectable ProductModel
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ProductModel> ProductModelIdList
		{
			get {return this._ProductModelIdList;}
			set 
			{
				this._ProductModelIdList = value;
				this.uxProductModelIdDataGridViewColumn.DataSource = null;
				this.uxProductModelIdDataGridViewColumn.DataSource = this._ProductModelIdList;
			}
		}
		
		private bool _allowNewItemInProductModelIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ProductModel
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductModelIdList
		{
			get { return _allowNewItemInProductModelIdList;}
			set
			{
				this._allowNewItemInProductModelIdList = value;
				this.uxProductModelIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.ProductSubcategory> _ProductSubcategoryIdList;
		
		/// <summary> 
		/// The list of selectable ProductSubcategory
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ProductSubcategory> ProductSubcategoryIdList
		{
			get {return this._ProductSubcategoryIdList;}
			set 
			{
				this._ProductSubcategoryIdList = value;
				this.uxProductSubcategoryIdDataGridViewColumn.DataSource = null;
				this.uxProductSubcategoryIdDataGridViewColumn.DataSource = this._ProductSubcategoryIdList;
			}
		}
		
		private bool _allowNewItemInProductSubcategoryIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ProductSubcategory
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductSubcategoryIdList
		{
			get { return _allowNewItemInProductSubcategoryIdList;}
			set
			{
				this._allowNewItemInProductSubcategoryIdList = value;
				this.uxProductSubcategoryIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.UnitMeasure> _SizeUnitMeasureCodeList;
		
		/// <summary> 
		/// The list of selectable UnitMeasure
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.UnitMeasure> SizeUnitMeasureCodeList
		{
			get {return this._SizeUnitMeasureCodeList;}
			set 
			{
				this._SizeUnitMeasureCodeList = value;
				this.uxSizeUnitMeasureCodeDataGridViewColumn.DataSource = null;
				this.uxSizeUnitMeasureCodeDataGridViewColumn.DataSource = this._SizeUnitMeasureCodeList;
			}
		}
		
		private bool _allowNewItemInSizeUnitMeasureCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of UnitMeasure
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSizeUnitMeasureCodeList
		{
			get { return _allowNewItemInSizeUnitMeasureCodeList;}
			set
			{
				this._allowNewItemInSizeUnitMeasureCodeList = value;
				this.uxSizeUnitMeasureCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.UnitMeasure> _WeightUnitMeasureCodeList;
		
		/// <summary> 
		/// The list of selectable UnitMeasure
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.UnitMeasure> WeightUnitMeasureCodeList
		{
			get {return this._WeightUnitMeasureCodeList;}
			set 
			{
				this._WeightUnitMeasureCodeList = value;
				this.uxWeightUnitMeasureCodeDataGridViewColumn.DataSource = null;
				this.uxWeightUnitMeasureCodeDataGridViewColumn.DataSource = this._WeightUnitMeasureCodeList;
			}
		}
		
		private bool _allowNewItemInWeightUnitMeasureCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of UnitMeasure
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInWeightUnitMeasureCodeList
		{
			get { return _allowNewItemInWeightUnitMeasureCodeList;}
			set
			{
				this._allowNewItemInWeightUnitMeasureCodeList = value;
				this.uxWeightUnitMeasureCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Product> _ProductList;
				
		/// <summary> 
		/// The list of Product to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Product> ProductList
		{
			get {return this._ProductList;}
			set
			{
				this._ProductList = value;
				this.uxProductBindingSource.DataSource = null;
				this.uxProductBindingSource.DataSource = value;
				this.uxProductDataGridView.DataSource = null;
				this.uxProductDataGridView.DataSource = this.uxProductBindingSource;				
				//this.uxProductBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductBindingSource_ListChanged);
				this.uxProductBindingSource.CurrentItemChanged += new System.EventHandler(OnProductBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProduct = uxProductBindingSource.Current as Entities.Product;
			
			if (_currentProduct != null)
			{
				_currentProduct.Validate();
			}
			//_Product.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Product"/> instance.
		/// </summary>
		public Entities.Product SelectedProduct
		{
			get {return this._currentProduct;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductDataGridView.VirtualMode;}
			set
			{
				this.uxProductDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductDataGridView.AllowUserToAddRows;}
			set {this.uxProductDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductDataGridViewBase"/> class.
		/// </summary>
		public ProductDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMakeFlagDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxFinishedGoodsFlagDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxColorDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSafetyStockLevelDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxReorderPointDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStandardCostDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxListPriceDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSizeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSizeUnitMeasureCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxWeightUnitMeasureCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxWeightDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDaysToManufactureDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductLineDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSafeNameClassDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStyleDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductSubcategoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxProductModelIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSellStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSellEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDiscontinuedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductModelIdBindingSource = new ProductModelBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductModelIdBindingSource)).BeginInit();
			//this.uxProductSubcategoryIdBindingSource = new ProductSubcategoryBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductSubcategoryIdBindingSource)).BeginInit();
			//this.uxSizeUnitMeasureCodeBindingSource = new UnitMeasureBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSizeUnitMeasureCodeBindingSource)).BeginInit();
			//this.uxWeightUnitMeasureCodeBindingSource = new UnitMeasureBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxWeightUnitMeasureCodeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductErrorProvider
			// 
			this.uxProductErrorProvider.ContainerControl = this;
			this.uxProductErrorProvider.DataSource = this.uxProductBindingSource;						
			// 
			// uxProductDataGridView
			// 
			this.uxProductDataGridView.AutoGenerateColumns = false;
			this.uxProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxProductNumberDataGridViewColumn,
		this.uxMakeFlagDataGridViewColumn,
		this.uxFinishedGoodsFlagDataGridViewColumn,
		this.uxColorDataGridViewColumn,
		this.uxSafetyStockLevelDataGridViewColumn,
		this.uxReorderPointDataGridViewColumn,
		this.uxStandardCostDataGridViewColumn,
		this.uxListPriceDataGridViewColumn,
		this.uxSizeDataGridViewColumn,
		this.uxSizeUnitMeasureCodeDataGridViewColumn,
		this.uxWeightUnitMeasureCodeDataGridViewColumn,
		this.uxWeightDataGridViewColumn,
		this.uxDaysToManufactureDataGridViewColumn,
		this.uxProductLineDataGridViewColumn,
		this.uxSafeNameClassDataGridViewColumn,
		this.uxStyleDataGridViewColumn,
		this.uxProductSubcategoryIdDataGridViewColumn,
		this.uxProductModelIdDataGridViewColumn,
		this.uxSellStartDateDataGridViewColumn,
		this.uxSellEndDateDataGridViewColumn,
		this.uxDiscontinuedDateDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductDataGridView.Name = "uxProductDataGridView";
			this.uxProductDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductDataGridView.TabIndex = 0;	
			this.uxProductDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductDataGridViewDataError);
			this.uxProductDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductDataGridViewCellValueNeeded);
			this.uxProductDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductDataGridViewCellValuePushed);
			
			//
			// uxProductIdDataGridViewColumn
			//
			this.uxProductIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductIdDataGridViewColumn.DataPropertyName = "ProductId";
			this.uxProductIdDataGridViewColumn.HeaderText = "ProductId";
			this.uxProductIdDataGridViewColumn.Name = "uxProductIdDataGridViewColumn";
			this.uxProductIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductIdDataGridViewColumn.ReadOnly = true;		
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
			// uxProductNumberDataGridViewColumn
			//
			this.uxProductNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductNumberDataGridViewColumn.DataPropertyName = "ProductNumber";
			this.uxProductNumberDataGridViewColumn.HeaderText = "ProductNumber";
			this.uxProductNumberDataGridViewColumn.Name = "uxProductNumberDataGridViewColumn";
			this.uxProductNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductNumberDataGridViewColumn.ReadOnly = false;		
			//
			// uxMakeFlagDataGridViewColumn
			//
			this.uxMakeFlagDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMakeFlagDataGridViewColumn.DataPropertyName = "MakeFlag";
			this.uxMakeFlagDataGridViewColumn.HeaderText = "MakeFlag";
			this.uxMakeFlagDataGridViewColumn.Name = "uxMakeFlagDataGridViewColumn";
			this.uxMakeFlagDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMakeFlagDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMakeFlagDataGridViewColumn.ReadOnly = false;		
			//
			// uxFinishedGoodsFlagDataGridViewColumn
			//
			this.uxFinishedGoodsFlagDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFinishedGoodsFlagDataGridViewColumn.DataPropertyName = "FinishedGoodsFlag";
			this.uxFinishedGoodsFlagDataGridViewColumn.HeaderText = "FinishedGoodsFlag";
			this.uxFinishedGoodsFlagDataGridViewColumn.Name = "uxFinishedGoodsFlagDataGridViewColumn";
			this.uxFinishedGoodsFlagDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFinishedGoodsFlagDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFinishedGoodsFlagDataGridViewColumn.ReadOnly = false;		
			//
			// uxColorDataGridViewColumn
			//
			this.uxColorDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxColorDataGridViewColumn.DataPropertyName = "Color";
			this.uxColorDataGridViewColumn.HeaderText = "Color";
			this.uxColorDataGridViewColumn.Name = "uxColorDataGridViewColumn";
			this.uxColorDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxColorDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxColorDataGridViewColumn.ReadOnly = false;		
			//
			// uxSafetyStockLevelDataGridViewColumn
			//
			this.uxSafetyStockLevelDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSafetyStockLevelDataGridViewColumn.DataPropertyName = "SafetyStockLevel";
			this.uxSafetyStockLevelDataGridViewColumn.HeaderText = "SafetyStockLevel";
			this.uxSafetyStockLevelDataGridViewColumn.Name = "uxSafetyStockLevelDataGridViewColumn";
			this.uxSafetyStockLevelDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSafetyStockLevelDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSafetyStockLevelDataGridViewColumn.ReadOnly = false;		
			//
			// uxReorderPointDataGridViewColumn
			//
			this.uxReorderPointDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxReorderPointDataGridViewColumn.DataPropertyName = "ReorderPoint";
			this.uxReorderPointDataGridViewColumn.HeaderText = "ReorderPoint";
			this.uxReorderPointDataGridViewColumn.Name = "uxReorderPointDataGridViewColumn";
			this.uxReorderPointDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxReorderPointDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxReorderPointDataGridViewColumn.ReadOnly = false;		
			//
			// uxStandardCostDataGridViewColumn
			//
			this.uxStandardCostDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStandardCostDataGridViewColumn.DataPropertyName = "StandardCost";
			this.uxStandardCostDataGridViewColumn.HeaderText = "StandardCost";
			this.uxStandardCostDataGridViewColumn.Name = "uxStandardCostDataGridViewColumn";
			this.uxStandardCostDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStandardCostDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStandardCostDataGridViewColumn.ReadOnly = false;		
			//
			// uxListPriceDataGridViewColumn
			//
			this.uxListPriceDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxListPriceDataGridViewColumn.DataPropertyName = "ListPrice";
			this.uxListPriceDataGridViewColumn.HeaderText = "ListPrice";
			this.uxListPriceDataGridViewColumn.Name = "uxListPriceDataGridViewColumn";
			this.uxListPriceDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxListPriceDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxListPriceDataGridViewColumn.ReadOnly = false;		
			//
			// uxSizeDataGridViewColumn
			//
			this.uxSizeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSizeDataGridViewColumn.DataPropertyName = "Size";
			this.uxSizeDataGridViewColumn.HeaderText = "Size";
			this.uxSizeDataGridViewColumn.Name = "uxSizeDataGridViewColumn";
			this.uxSizeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSizeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSizeDataGridViewColumn.ReadOnly = false;		
			//
			// uxSizeUnitMeasureCodeDataGridViewColumn
			//
			this.uxSizeUnitMeasureCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSizeUnitMeasureCodeDataGridViewColumn.DataPropertyName = "SizeUnitMeasureCode";
			this.uxSizeUnitMeasureCodeDataGridViewColumn.HeaderText = "SizeUnitMeasureCode";
			this.uxSizeUnitMeasureCodeDataGridViewColumn.Name = "uxSizeUnitMeasureCodeDataGridViewColumn";
			this.uxSizeUnitMeasureCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSizeUnitMeasureCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSizeUnitMeasureCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxWeightUnitMeasureCodeDataGridViewColumn
			//
			this.uxWeightUnitMeasureCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxWeightUnitMeasureCodeDataGridViewColumn.DataPropertyName = "WeightUnitMeasureCode";
			this.uxWeightUnitMeasureCodeDataGridViewColumn.HeaderText = "WeightUnitMeasureCode";
			this.uxWeightUnitMeasureCodeDataGridViewColumn.Name = "uxWeightUnitMeasureCodeDataGridViewColumn";
			this.uxWeightUnitMeasureCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxWeightUnitMeasureCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxWeightUnitMeasureCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxWeightDataGridViewColumn
			//
			this.uxWeightDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxWeightDataGridViewColumn.DataPropertyName = "Weight";
			this.uxWeightDataGridViewColumn.HeaderText = "Weight";
			this.uxWeightDataGridViewColumn.Name = "uxWeightDataGridViewColumn";
			this.uxWeightDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxWeightDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxWeightDataGridViewColumn.ReadOnly = false;		
			//
			// uxDaysToManufactureDataGridViewColumn
			//
			this.uxDaysToManufactureDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDaysToManufactureDataGridViewColumn.DataPropertyName = "DaysToManufacture";
			this.uxDaysToManufactureDataGridViewColumn.HeaderText = "DaysToManufacture";
			this.uxDaysToManufactureDataGridViewColumn.Name = "uxDaysToManufactureDataGridViewColumn";
			this.uxDaysToManufactureDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDaysToManufactureDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDaysToManufactureDataGridViewColumn.ReadOnly = false;		
			//
			// uxProductLineDataGridViewColumn
			//
			this.uxProductLineDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductLineDataGridViewColumn.DataPropertyName = "ProductLine";
			this.uxProductLineDataGridViewColumn.HeaderText = "ProductLine";
			this.uxProductLineDataGridViewColumn.Name = "uxProductLineDataGridViewColumn";
			this.uxProductLineDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductLineDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductLineDataGridViewColumn.ReadOnly = false;		
			//
			// uxSafeNameClassDataGridViewColumn
			//
			this.uxSafeNameClassDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSafeNameClassDataGridViewColumn.DataPropertyName = "SafeNameClass";
			this.uxSafeNameClassDataGridViewColumn.HeaderText = "SafeNameClass";
			this.uxSafeNameClassDataGridViewColumn.Name = "uxSafeNameClassDataGridViewColumn";
			this.uxSafeNameClassDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSafeNameClassDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSafeNameClassDataGridViewColumn.ReadOnly = false;		
			//
			// uxStyleDataGridViewColumn
			//
			this.uxStyleDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStyleDataGridViewColumn.DataPropertyName = "Style";
			this.uxStyleDataGridViewColumn.HeaderText = "Style";
			this.uxStyleDataGridViewColumn.Name = "uxStyleDataGridViewColumn";
			this.uxStyleDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStyleDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStyleDataGridViewColumn.ReadOnly = false;		
			//
			// uxProductSubcategoryIdDataGridViewColumn
			//
			this.uxProductSubcategoryIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductSubcategoryIdDataGridViewColumn.DataPropertyName = "ProductSubcategoryId";
			this.uxProductSubcategoryIdDataGridViewColumn.HeaderText = "ProductSubcategoryId";
			this.uxProductSubcategoryIdDataGridViewColumn.Name = "uxProductSubcategoryIdDataGridViewColumn";
			this.uxProductSubcategoryIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductSubcategoryIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductSubcategoryIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxProductModelIdDataGridViewColumn
			//
			this.uxProductModelIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductModelIdDataGridViewColumn.DataPropertyName = "ProductModelId";
			this.uxProductModelIdDataGridViewColumn.HeaderText = "ProductModelId";
			this.uxProductModelIdDataGridViewColumn.Name = "uxProductModelIdDataGridViewColumn";
			this.uxProductModelIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductModelIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductModelIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxSellStartDateDataGridViewColumn
			//
			this.uxSellStartDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSellStartDateDataGridViewColumn.DataPropertyName = "SellStartDate";
			this.uxSellStartDateDataGridViewColumn.HeaderText = "SellStartDate";
			this.uxSellStartDateDataGridViewColumn.Name = "uxSellStartDateDataGridViewColumn";
			this.uxSellStartDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSellStartDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSellStartDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxSellEndDateDataGridViewColumn
			//
			this.uxSellEndDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSellEndDateDataGridViewColumn.DataPropertyName = "SellEndDate";
			this.uxSellEndDateDataGridViewColumn.HeaderText = "SellEndDate";
			this.uxSellEndDateDataGridViewColumn.Name = "uxSellEndDateDataGridViewColumn";
			this.uxSellEndDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSellEndDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSellEndDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxDiscontinuedDateDataGridViewColumn
			//
			this.uxDiscontinuedDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDiscontinuedDateDataGridViewColumn.DataPropertyName = "DiscontinuedDate";
			this.uxDiscontinuedDateDataGridViewColumn.HeaderText = "DiscontinuedDate";
			this.uxDiscontinuedDateDataGridViewColumn.Name = "uxDiscontinuedDateDataGridViewColumn";
			this.uxDiscontinuedDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDiscontinuedDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDiscontinuedDateDataGridViewColumn.ReadOnly = false;		
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
			// uxProductModelIdDataGridViewColumn
			//				
			this.uxProductModelIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductModelIdDataGridViewColumn.ValueMember = "ProductModelId";	
			this.uxProductModelIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductModelIdDataGridViewColumn.DataSource = uxProductModelIdBindingSource;				
				
			//
			// uxProductSubcategoryIdDataGridViewColumn
			//				
			this.uxProductSubcategoryIdDataGridViewColumn.DisplayMember = "ProductCategoryId";	
			this.uxProductSubcategoryIdDataGridViewColumn.ValueMember = "ProductSubcategoryId";	
			this.uxProductSubcategoryIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductSubcategoryIdDataGridViewColumn.DataSource = uxProductSubcategoryIdBindingSource;				
				
			//
			// uxSizeUnitMeasureCodeDataGridViewColumn
			//				
			this.uxSizeUnitMeasureCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxSizeUnitMeasureCodeDataGridViewColumn.ValueMember = "UnitMeasureCode";	
			this.uxSizeUnitMeasureCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSizeUnitMeasureCodeDataGridViewColumn.DataSource = uxSizeUnitMeasureCodeBindingSource;				
				
			//
			// uxWeightUnitMeasureCodeDataGridViewColumn
			//				
			this.uxWeightUnitMeasureCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxWeightUnitMeasureCodeDataGridViewColumn.ValueMember = "UnitMeasureCode";	
			this.uxWeightUnitMeasureCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxWeightUnitMeasureCodeDataGridViewColumn.DataSource = uxWeightUnitMeasureCodeBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductDataGridView);
			this.Name = "ProductDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductModelIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxProductSubcategoryIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxSizeUnitMeasureCodeBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxWeightUnitMeasureCodeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductBindingSource)).EndInit();
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
				ProductDataGridViewEventArgs args = new ProductDataGridViewEventArgs();
				args.Product = _currentProduct;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Product	_Product;
	
			/// <summary>
			/// the  Entities.Product instance.
			/// </summary>
			public Entities.Product Product
			{
				get { return _Product; }
				set { _Product = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].ProductId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].Name;
						break;
					case "uxProductNumberDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].ProductNumber;
						break;
					case "uxMakeFlagDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].MakeFlag;
						break;
					case "uxFinishedGoodsFlagDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].FinishedGoodsFlag;
						break;
					case "uxColorDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].Color;
						break;
					case "uxSafetyStockLevelDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].SafetyStockLevel;
						break;
					case "uxReorderPointDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].ReorderPoint;
						break;
					case "uxStandardCostDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].StandardCost;
						break;
					case "uxListPriceDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].ListPrice;
						break;
					case "uxSizeDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].Size;
						break;
					case "uxSizeUnitMeasureCodeDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].SizeUnitMeasureCode;
						break;
					case "uxWeightUnitMeasureCodeDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].WeightUnitMeasureCode;
						break;
					case "uxWeightDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].Weight;
						break;
					case "uxDaysToManufactureDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].DaysToManufacture;
						break;
					case "uxProductLineDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].ProductLine;
						break;
					case "uxSafeNameClassDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].SafeNameClass;
						break;
					case "uxStyleDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].Style;
						break;
					case "uxProductSubcategoryIdDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].ProductSubcategoryId;
						break;
					case "uxProductModelIdDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].ProductModelId;
						break;
					case "uxSellStartDateDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].SellStartDate;
						break;
					case "uxSellEndDateDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].SellEndDate;
						break;
					case "uxDiscontinuedDateDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].DiscontinuedDate;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						ProductList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						ProductList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxProductNumberDataGridViewColumn":
						ProductList[e.RowIndex].ProductNumber = (System.String)e.Value;
						break;
					case "uxMakeFlagDataGridViewColumn":
						ProductList[e.RowIndex].MakeFlag = (System.Boolean)e.Value;
						break;
					case "uxFinishedGoodsFlagDataGridViewColumn":
						ProductList[e.RowIndex].FinishedGoodsFlag = (System.Boolean)e.Value;
						break;
					case "uxColorDataGridViewColumn":
						ProductList[e.RowIndex].Color = (System.String)e.Value;
						break;
					case "uxSafetyStockLevelDataGridViewColumn":
						ProductList[e.RowIndex].SafetyStockLevel = (System.Int16)e.Value;
						break;
					case "uxReorderPointDataGridViewColumn":
						ProductList[e.RowIndex].ReorderPoint = (System.Int16)e.Value;
						break;
					case "uxStandardCostDataGridViewColumn":
						ProductList[e.RowIndex].StandardCost = (System.Decimal)e.Value;
						break;
					case "uxListPriceDataGridViewColumn":
						ProductList[e.RowIndex].ListPrice = (System.Decimal)e.Value;
						break;
					case "uxSizeDataGridViewColumn":
						ProductList[e.RowIndex].Size = (System.String)e.Value;
						break;
					case "uxSizeUnitMeasureCodeDataGridViewColumn":
						ProductList[e.RowIndex].SizeUnitMeasureCode = (System.String)e.Value;
						break;
					case "uxWeightUnitMeasureCodeDataGridViewColumn":
						ProductList[e.RowIndex].WeightUnitMeasureCode = (System.String)e.Value;
						break;
					case "uxWeightDataGridViewColumn":
						ProductList[e.RowIndex].Weight = (System.Decimal?)e.Value;
						break;
					case "uxDaysToManufactureDataGridViewColumn":
						ProductList[e.RowIndex].DaysToManufacture = (System.Int32)e.Value;
						break;
					case "uxProductLineDataGridViewColumn":
						ProductList[e.RowIndex].ProductLine = (System.String)e.Value;
						break;
					case "uxSafeNameClassDataGridViewColumn":
						ProductList[e.RowIndex].SafeNameClass = (System.String)e.Value;
						break;
					case "uxStyleDataGridViewColumn":
						ProductList[e.RowIndex].Style = (System.String)e.Value;
						break;
					case "uxProductSubcategoryIdDataGridViewColumn":
						ProductList[e.RowIndex].ProductSubcategoryId = (System.Int32?)e.Value;
						break;
					case "uxProductModelIdDataGridViewColumn":
						ProductList[e.RowIndex].ProductModelId = (System.Int32?)e.Value;
						break;
					case "uxSellStartDateDataGridViewColumn":
						ProductList[e.RowIndex].SellStartDate = (System.DateTime)e.Value;
						break;
					case "uxSellEndDateDataGridViewColumn":
						ProductList[e.RowIndex].SellEndDate = (System.DateTime?)e.Value;
						break;
					case "uxDiscontinuedDateDataGridViewColumn":
						ProductList[e.RowIndex].DiscontinuedDate = (System.DateTime?)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						ProductList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
