
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TestProduct typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestProductDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TestProductDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TestProduct _currentTestProduct = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTestProductDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTestProductErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTestProductBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ProductTypeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductTypeIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DownloadId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDownloadIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ManufacturerId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxManufacturerIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the BrandName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBrandNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ProductName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ProductCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UniqueIdentifier property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUniqueIdentifierDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TypeName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTypeNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModelName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModelNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DisplayName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDisplayNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ProductLink property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductLinkDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ConnectorCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxConnectorCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the BaseId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBaseIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OrgProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOrgProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ImageFileType property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxImageFileTypeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the FullImageFileType property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFullImageFileTypeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Status property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStatusDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AddedBy property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddedByDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AddedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddedDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UpdatedBy property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUpdatedByDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UpdatedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUpdatedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.TestProduct> _TestProductList;
				
		/// <summary> 
		/// The list of TestProduct to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TestProduct> TestProductList
		{
			get {return this._TestProductList;}
			set
			{
				this._TestProductList = value;
				this.uxTestProductBindingSource.DataSource = null;
				this.uxTestProductBindingSource.DataSource = value;
				this.uxTestProductDataGridView.DataSource = null;
				this.uxTestProductDataGridView.DataSource = this.uxTestProductBindingSource;				
				//this.uxTestProductBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTestProductBindingSource_ListChanged);
				this.uxTestProductBindingSource.CurrentItemChanged += new System.EventHandler(OnTestProductBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTestProductBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTestProduct = uxTestProductBindingSource.Current as Entities.TestProduct;
			
			if (_currentTestProduct != null)
			{
				_currentTestProduct.Validate();
			}
			//_TestProduct.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTestProductBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <c cref="Entities.TestProduct"/> instance.
		/// </summary>
		public Entities.TestProduct SelectedTestProduct
		{
			get {return this._currentTestProduct;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTestProductDataGridView.VirtualMode;}
			set
			{
				this.uxTestProductDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTestProductDataGridView.AllowUserToAddRows;}
			set {this.uxTestProductDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTestProductDataGridView.AllowUserToDeleteRows;}
			set {this.uxTestProductDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <c cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTestProductDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTestProductDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TestProductDataGridViewBase"/> class.
		/// </summary>
		public TestProductDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTestProductDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTestProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTestProductErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductTypeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDownloadIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxManufacturerIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBrandNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUniqueIdentifierDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTypeNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModelNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDisplayNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductLinkDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxConnectorCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBaseIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxOrgProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxImageFileTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFullImageFileTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStatusDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUpdatedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUpdatedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxTestProductDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestProductBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestProductErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTestProductErrorProvider
			// 
			this.uxTestProductErrorProvider.ContainerControl = this;
			this.uxTestProductErrorProvider.DataSource = this.uxTestProductBindingSource;						
			// 
			// uxTestProductDataGridView
			// 
			this.uxTestProductDataGridView.AutoGenerateColumns = false;
			this.uxTestProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTestProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductIdDataGridViewColumn,
		this.uxProductTypeIdDataGridViewColumn,
		this.uxDownloadIdDataGridViewColumn,
		this.uxManufacturerIdDataGridViewColumn,
		this.uxBrandNameDataGridViewColumn,
		this.uxProductNameDataGridViewColumn,
		this.uxProductCodeDataGridViewColumn,
		this.uxUniqueIdentifierDataGridViewColumn,
		this.uxTypeNameDataGridViewColumn,
		this.uxModelNameDataGridViewColumn,
		this.uxDisplayNameDataGridViewColumn,
		this.uxProductLinkDataGridViewColumn,
		this.uxConnectorCodeDataGridViewColumn,
		this.uxBaseIdDataGridViewColumn,
		this.uxOrgProductIdDataGridViewColumn,
		this.uxImageFileTypeDataGridViewColumn,
		this.uxFullImageFileTypeDataGridViewColumn,
		this.uxStatusDataGridViewColumn,
		this.uxAddedByDataGridViewColumn,
		this.uxAddedDateDataGridViewColumn,
		this.uxUpdatedByDataGridViewColumn,
		this.uxUpdatedDateDataGridViewColumn			});
			this.uxTestProductDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTestProductDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTestProductDataGridView.Name = "uxTestProductDataGridView";
			this.uxTestProductDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTestProductDataGridView.TabIndex = 0;	
			this.uxTestProductDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTestProductDataGridView.EnableHeadersVisualStyles = false;
			this.uxTestProductDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTestProductDataGridViewDataError);
			this.uxTestProductDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestProductDataGridViewCellValueNeeded);
			this.uxTestProductDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestProductDataGridViewCellValuePushed);
			
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
			// uxProductTypeIdDataGridViewColumn
			//
			this.uxProductTypeIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductTypeIdDataGridViewColumn.DataPropertyName = "ProductTypeId";
			this.uxProductTypeIdDataGridViewColumn.HeaderText = "ProductTypeId";
			this.uxProductTypeIdDataGridViewColumn.Name = "uxProductTypeIdDataGridViewColumn";
			this.uxProductTypeIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductTypeIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductTypeIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxDownloadIdDataGridViewColumn
			//
			this.uxDownloadIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDownloadIdDataGridViewColumn.DataPropertyName = "DownloadId";
			this.uxDownloadIdDataGridViewColumn.HeaderText = "DownloadId";
			this.uxDownloadIdDataGridViewColumn.Name = "uxDownloadIdDataGridViewColumn";
			this.uxDownloadIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDownloadIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDownloadIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxManufacturerIdDataGridViewColumn
			//
			this.uxManufacturerIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxManufacturerIdDataGridViewColumn.DataPropertyName = "ManufacturerId";
			this.uxManufacturerIdDataGridViewColumn.HeaderText = "ManufacturerId";
			this.uxManufacturerIdDataGridViewColumn.Name = "uxManufacturerIdDataGridViewColumn";
			this.uxManufacturerIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxManufacturerIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxManufacturerIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxBrandNameDataGridViewColumn
			//
			this.uxBrandNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBrandNameDataGridViewColumn.DataPropertyName = "BrandName";
			this.uxBrandNameDataGridViewColumn.HeaderText = "BrandName";
			this.uxBrandNameDataGridViewColumn.Name = "uxBrandNameDataGridViewColumn";
			this.uxBrandNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBrandNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBrandNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxProductNameDataGridViewColumn
			//
			this.uxProductNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductNameDataGridViewColumn.DataPropertyName = "ProductName";
			this.uxProductNameDataGridViewColumn.HeaderText = "ProductName";
			this.uxProductNameDataGridViewColumn.Name = "uxProductNameDataGridViewColumn";
			this.uxProductNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxProductCodeDataGridViewColumn
			//
			this.uxProductCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductCodeDataGridViewColumn.DataPropertyName = "ProductCode";
			this.uxProductCodeDataGridViewColumn.HeaderText = "ProductCode";
			this.uxProductCodeDataGridViewColumn.Name = "uxProductCodeDataGridViewColumn";
			this.uxProductCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxUniqueIdentifierDataGridViewColumn
			//
			this.uxUniqueIdentifierDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUniqueIdentifierDataGridViewColumn.DataPropertyName = "UniqueIdentifier";
			this.uxUniqueIdentifierDataGridViewColumn.HeaderText = "UniqueIdentifier";
			this.uxUniqueIdentifierDataGridViewColumn.Name = "uxUniqueIdentifierDataGridViewColumn";
			this.uxUniqueIdentifierDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUniqueIdentifierDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUniqueIdentifierDataGridViewColumn.ReadOnly = false;		
			//
			// uxTypeNameDataGridViewColumn
			//
			this.uxTypeNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTypeNameDataGridViewColumn.DataPropertyName = "TypeName";
			this.uxTypeNameDataGridViewColumn.HeaderText = "TypeName";
			this.uxTypeNameDataGridViewColumn.Name = "uxTypeNameDataGridViewColumn";
			this.uxTypeNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTypeNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTypeNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxModelNameDataGridViewColumn
			//
			this.uxModelNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxModelNameDataGridViewColumn.DataPropertyName = "ModelName";
			this.uxModelNameDataGridViewColumn.HeaderText = "ModelName";
			this.uxModelNameDataGridViewColumn.Name = "uxModelNameDataGridViewColumn";
			this.uxModelNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxModelNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxModelNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxDisplayNameDataGridViewColumn
			//
			this.uxDisplayNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDisplayNameDataGridViewColumn.DataPropertyName = "DisplayName";
			this.uxDisplayNameDataGridViewColumn.HeaderText = "DisplayName";
			this.uxDisplayNameDataGridViewColumn.Name = "uxDisplayNameDataGridViewColumn";
			this.uxDisplayNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDisplayNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDisplayNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxProductLinkDataGridViewColumn
			//
			this.uxProductLinkDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductLinkDataGridViewColumn.DataPropertyName = "ProductLink";
			this.uxProductLinkDataGridViewColumn.HeaderText = "ProductLink";
			this.uxProductLinkDataGridViewColumn.Name = "uxProductLinkDataGridViewColumn";
			this.uxProductLinkDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductLinkDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductLinkDataGridViewColumn.ReadOnly = false;		
			//
			// uxConnectorCodeDataGridViewColumn
			//
			this.uxConnectorCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxConnectorCodeDataGridViewColumn.DataPropertyName = "ConnectorCode";
			this.uxConnectorCodeDataGridViewColumn.HeaderText = "ConnectorCode";
			this.uxConnectorCodeDataGridViewColumn.Name = "uxConnectorCodeDataGridViewColumn";
			this.uxConnectorCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxConnectorCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxConnectorCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxBaseIdDataGridViewColumn
			//
			this.uxBaseIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBaseIdDataGridViewColumn.DataPropertyName = "BaseId";
			this.uxBaseIdDataGridViewColumn.HeaderText = "BaseId";
			this.uxBaseIdDataGridViewColumn.Name = "uxBaseIdDataGridViewColumn";
			this.uxBaseIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBaseIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBaseIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxOrgProductIdDataGridViewColumn
			//
			this.uxOrgProductIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxOrgProductIdDataGridViewColumn.DataPropertyName = "OrgProductId";
			this.uxOrgProductIdDataGridViewColumn.HeaderText = "OrgProductId";
			this.uxOrgProductIdDataGridViewColumn.Name = "uxOrgProductIdDataGridViewColumn";
			this.uxOrgProductIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxOrgProductIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxOrgProductIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxImageFileTypeDataGridViewColumn
			//
			this.uxImageFileTypeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxImageFileTypeDataGridViewColumn.DataPropertyName = "ImageFileType";
			this.uxImageFileTypeDataGridViewColumn.HeaderText = "ImageFileType";
			this.uxImageFileTypeDataGridViewColumn.Name = "uxImageFileTypeDataGridViewColumn";
			this.uxImageFileTypeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxImageFileTypeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxImageFileTypeDataGridViewColumn.ReadOnly = false;		
			//
			// uxFullImageFileTypeDataGridViewColumn
			//
			this.uxFullImageFileTypeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFullImageFileTypeDataGridViewColumn.DataPropertyName = "FullImageFileType";
			this.uxFullImageFileTypeDataGridViewColumn.HeaderText = "FullImageFileType";
			this.uxFullImageFileTypeDataGridViewColumn.Name = "uxFullImageFileTypeDataGridViewColumn";
			this.uxFullImageFileTypeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFullImageFileTypeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFullImageFileTypeDataGridViewColumn.ReadOnly = false;		
			//
			// uxStatusDataGridViewColumn
			//
			this.uxStatusDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStatusDataGridViewColumn.DataPropertyName = "Status";
			this.uxStatusDataGridViewColumn.HeaderText = "Status";
			this.uxStatusDataGridViewColumn.Name = "uxStatusDataGridViewColumn";
			this.uxStatusDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStatusDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStatusDataGridViewColumn.ReadOnly = false;		
			//
			// uxAddedByDataGridViewColumn
			//
			this.uxAddedByDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddedByDataGridViewColumn.DataPropertyName = "AddedBy";
			this.uxAddedByDataGridViewColumn.HeaderText = "AddedBy";
			this.uxAddedByDataGridViewColumn.Name = "uxAddedByDataGridViewColumn";
			this.uxAddedByDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddedByDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddedByDataGridViewColumn.ReadOnly = false;		
			//
			// uxAddedDateDataGridViewColumn
			//
			this.uxAddedDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddedDateDataGridViewColumn.DataPropertyName = "AddedDate";
			this.uxAddedDateDataGridViewColumn.HeaderText = "AddedDate";
			this.uxAddedDateDataGridViewColumn.Name = "uxAddedDateDataGridViewColumn";
			this.uxAddedDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddedDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddedDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxUpdatedByDataGridViewColumn
			//
			this.uxUpdatedByDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUpdatedByDataGridViewColumn.DataPropertyName = "UpdatedBy";
			this.uxUpdatedByDataGridViewColumn.HeaderText = "UpdatedBy";
			this.uxUpdatedByDataGridViewColumn.Name = "uxUpdatedByDataGridViewColumn";
			this.uxUpdatedByDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUpdatedByDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUpdatedByDataGridViewColumn.ReadOnly = false;		
			//
			// uxUpdatedDateDataGridViewColumn
			//
			this.uxUpdatedDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUpdatedDateDataGridViewColumn.DataPropertyName = "UpdatedDate";
			this.uxUpdatedDateDataGridViewColumn.HeaderText = "UpdatedDate";
			this.uxUpdatedDateDataGridViewColumn.Name = "uxUpdatedDateDataGridViewColumn";
			this.uxUpdatedDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUpdatedDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUpdatedDateDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxTestProductDataGridView);
			this.Name = "TestProductDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxTestProductErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestProductDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestProductBindingSource)).EndInit();
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
				TestProductDataGridViewEventArgs args = new TestProductDataGridViewEventArgs();
				args.TestProduct = _currentTestProduct;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TestProductDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TestProduct	_TestProduct;
	
			/// <summary>
			/// the  Entities.TestProduct instance.
			/// </summary>
			public Entities.TestProduct TestProduct
			{
				get { return _TestProduct; }
				set { _TestProduct = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTestProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTestProductDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTestProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestProductDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestProductDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ProductId;
						break;
					case "uxProductTypeIdDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ProductTypeId;
						break;
					case "uxDownloadIdDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].DownloadId;
						break;
					case "uxManufacturerIdDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ManufacturerId;
						break;
					case "uxBrandNameDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].BrandName;
						break;
					case "uxProductNameDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ProductName;
						break;
					case "uxProductCodeDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ProductCode;
						break;
					case "uxUniqueIdentifierDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].UniqueIdentifier;
						break;
					case "uxTypeNameDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].TypeName;
						break;
					case "uxModelNameDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ModelName;
						break;
					case "uxDisplayNameDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].DisplayName;
						break;
					case "uxProductLinkDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ProductLink;
						break;
					case "uxConnectorCodeDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ConnectorCode;
						break;
					case "uxBaseIdDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].BaseId;
						break;
					case "uxOrgProductIdDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].OrgProductId;
						break;
					case "uxImageFileTypeDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].ImageFileType;
						break;
					case "uxFullImageFileTypeDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].FullImageFileType;
						break;
					case "uxStatusDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].Status;
						break;
					case "uxAddedByDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].AddedBy;
						break;
					case "uxAddedDateDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].AddedDate;
						break;
					case "uxUpdatedByDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].UpdatedBy;
						break;
					case "uxUpdatedDateDataGridViewColumn":
						e.Value = TestProductList[e.RowIndex].UpdatedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTestProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestProductDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestProductDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						TestProductList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxProductTypeIdDataGridViewColumn":
						TestProductList[e.RowIndex].ProductTypeId = (System.Int32?)e.Value;
						break;
					case "uxDownloadIdDataGridViewColumn":
						TestProductList[e.RowIndex].DownloadId = (System.Int32?)e.Value;
						break;
					case "uxManufacturerIdDataGridViewColumn":
						TestProductList[e.RowIndex].ManufacturerId = (System.Int32?)e.Value;
						break;
					case "uxBrandNameDataGridViewColumn":
						TestProductList[e.RowIndex].BrandName = (System.String)e.Value;
						break;
					case "uxProductNameDataGridViewColumn":
						TestProductList[e.RowIndex].ProductName = (System.String)e.Value;
						break;
					case "uxProductCodeDataGridViewColumn":
						TestProductList[e.RowIndex].ProductCode = (System.String)e.Value;
						break;
					case "uxUniqueIdentifierDataGridViewColumn":
						TestProductList[e.RowIndex].UniqueIdentifier = (System.String)e.Value;
						break;
					case "uxTypeNameDataGridViewColumn":
						TestProductList[e.RowIndex].TypeName = (System.String)e.Value;
						break;
					case "uxModelNameDataGridViewColumn":
						TestProductList[e.RowIndex].ModelName = (System.String)e.Value;
						break;
					case "uxDisplayNameDataGridViewColumn":
						TestProductList[e.RowIndex].DisplayName = (System.String)e.Value;
						break;
					case "uxProductLinkDataGridViewColumn":
						TestProductList[e.RowIndex].ProductLink = (System.String)e.Value;
						break;
					case "uxConnectorCodeDataGridViewColumn":
						TestProductList[e.RowIndex].ConnectorCode = (System.String)e.Value;
						break;
					case "uxBaseIdDataGridViewColumn":
						TestProductList[e.RowIndex].BaseId = (System.Int32?)e.Value;
						break;
					case "uxOrgProductIdDataGridViewColumn":
						TestProductList[e.RowIndex].OrgProductId = (System.Int32?)e.Value;
						break;
					case "uxImageFileTypeDataGridViewColumn":
						TestProductList[e.RowIndex].ImageFileType = (System.String)e.Value;
						break;
					case "uxFullImageFileTypeDataGridViewColumn":
						TestProductList[e.RowIndex].FullImageFileType = (System.String)e.Value;
						break;
					case "uxStatusDataGridViewColumn":
						TestProductList[e.RowIndex].Status = (System.String)e.Value;
						break;
					case "uxAddedByDataGridViewColumn":
						TestProductList[e.RowIndex].AddedBy = (System.Int32?)e.Value;
						break;
					case "uxAddedDateDataGridViewColumn":
						TestProductList[e.RowIndex].AddedDate = (System.DateTime?)e.Value;
						break;
					case "uxUpdatedByDataGridViewColumn":
						TestProductList[e.RowIndex].UpdatedBy = (System.Int32?)e.Value;
						break;
					case "uxUpdatedDateDataGridViewColumn":
						TestProductList[e.RowIndex].UpdatedDate = (System.DateTime?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
