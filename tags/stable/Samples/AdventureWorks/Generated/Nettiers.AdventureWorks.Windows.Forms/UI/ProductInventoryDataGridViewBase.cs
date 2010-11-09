
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductInventory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductInventoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductInventoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductInventory _currentProductInventory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductInventoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductInventoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductInventoryBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the LocationId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxLocationIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Shelf property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShelfDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Bin property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBinDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Quantity property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxQuantityDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Location> _LocationIdList;
		
		/// <summary> 
		/// The list of selectable Location
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Location> LocationIdList
		{
			get {return this._LocationIdList;}
			set 
			{
				this._LocationIdList = value;
				this.uxLocationIdDataGridViewColumn.DataSource = null;
				this.uxLocationIdDataGridViewColumn.DataSource = this._LocationIdList;
			}
		}
		
		private bool _allowNewItemInLocationIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Location
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInLocationIdList
		{
			get { return _allowNewItemInLocationIdList;}
			set
			{
				this._allowNewItemInLocationIdList = value;
				this.uxLocationIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductInventory> _ProductInventoryList;
				
		/// <summary> 
		/// The list of ProductInventory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductInventory> ProductInventoryList
		{
			get {return this._ProductInventoryList;}
			set
			{
				this._ProductInventoryList = value;
				this.uxProductInventoryBindingSource.DataSource = null;
				this.uxProductInventoryBindingSource.DataSource = value;
				this.uxProductInventoryDataGridView.DataSource = null;
				this.uxProductInventoryDataGridView.DataSource = this.uxProductInventoryBindingSource;				
				//this.uxProductInventoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductInventoryBindingSource_ListChanged);
				this.uxProductInventoryBindingSource.CurrentItemChanged += new System.EventHandler(OnProductInventoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductInventoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductInventory = uxProductInventoryBindingSource.Current as Entities.ProductInventory;
			
			if (_currentProductInventory != null)
			{
				_currentProductInventory.Validate();
			}
			//_ProductInventory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductInventoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductInventory"/> instance.
		/// </summary>
		public Entities.ProductInventory SelectedProductInventory
		{
			get {return this._currentProductInventory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductInventoryDataGridView.VirtualMode;}
			set
			{
				this.uxProductInventoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductInventoryDataGridView.AllowUserToAddRows;}
			set {this.uxProductInventoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductInventoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductInventoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductInventoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductInventoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductInventoryDataGridViewBase"/> class.
		/// </summary>
		public ProductInventoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductInventoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductInventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductInventoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxLocationIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxShelfDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBinDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxQuantityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxLocationIdBindingSource = new LocationBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxLocationIdBindingSource)).BeginInit();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductInventoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductInventoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductInventoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductInventoryErrorProvider
			// 
			this.uxProductInventoryErrorProvider.ContainerControl = this;
			this.uxProductInventoryErrorProvider.DataSource = this.uxProductInventoryBindingSource;						
			// 
			// uxProductInventoryDataGridView
			// 
			this.uxProductInventoryDataGridView.AutoGenerateColumns = false;
			this.uxProductInventoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductInventoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductIdDataGridViewColumn,
		this.uxLocationIdDataGridViewColumn,
		this.uxShelfDataGridViewColumn,
		this.uxBinDataGridViewColumn,
		this.uxQuantityDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductInventoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductInventoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductInventoryDataGridView.Name = "uxProductInventoryDataGridView";
			this.uxProductInventoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductInventoryDataGridView.TabIndex = 0;	
			this.uxProductInventoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductInventoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductInventoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductInventoryDataGridViewDataError);
			this.uxProductInventoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductInventoryDataGridViewCellValueNeeded);
			this.uxProductInventoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductInventoryDataGridViewCellValuePushed);
			
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
			// uxLocationIdDataGridViewColumn
			//
			this.uxLocationIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLocationIdDataGridViewColumn.DataPropertyName = "LocationId";
			this.uxLocationIdDataGridViewColumn.HeaderText = "LocationId";
			this.uxLocationIdDataGridViewColumn.Name = "uxLocationIdDataGridViewColumn";
			this.uxLocationIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLocationIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLocationIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxShelfDataGridViewColumn
			//
			this.uxShelfDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShelfDataGridViewColumn.DataPropertyName = "Shelf";
			this.uxShelfDataGridViewColumn.HeaderText = "Shelf";
			this.uxShelfDataGridViewColumn.Name = "uxShelfDataGridViewColumn";
			this.uxShelfDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShelfDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShelfDataGridViewColumn.ReadOnly = false;		
			//
			// uxBinDataGridViewColumn
			//
			this.uxBinDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBinDataGridViewColumn.DataPropertyName = "Bin";
			this.uxBinDataGridViewColumn.HeaderText = "Bin";
			this.uxBinDataGridViewColumn.Name = "uxBinDataGridViewColumn";
			this.uxBinDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBinDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBinDataGridViewColumn.ReadOnly = false;		
			//
			// uxQuantityDataGridViewColumn
			//
			this.uxQuantityDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxQuantityDataGridViewColumn.DataPropertyName = "Quantity";
			this.uxQuantityDataGridViewColumn.HeaderText = "Quantity";
			this.uxQuantityDataGridViewColumn.Name = "uxQuantityDataGridViewColumn";
			this.uxQuantityDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxQuantityDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxQuantityDataGridViewColumn.ReadOnly = false;		
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
			// uxLocationIdDataGridViewColumn
			//				
			this.uxLocationIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxLocationIdDataGridViewColumn.ValueMember = "LocationId";	
			this.uxLocationIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxLocationIdDataGridViewColumn.DataSource = uxLocationIdBindingSource;				
				
			//
			// uxProductIdDataGridViewColumn
			//				
			this.uxProductIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductIdDataGridViewColumn.ValueMember = "ProductId";	
			this.uxProductIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductIdDataGridViewColumn.DataSource = uxProductIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductInventoryDataGridView);
			this.Name = "ProductInventoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxLocationIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductInventoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductInventoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductInventoryBindingSource)).EndInit();
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
				ProductInventoryDataGridViewEventArgs args = new ProductInventoryDataGridViewEventArgs();
				args.ProductInventory = _currentProductInventory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductInventoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductInventory	_ProductInventory;
	
			/// <summary>
			/// the  Entities.ProductInventory instance.
			/// </summary>
			public Entities.ProductInventory ProductInventory
			{
				get { return _ProductInventory; }
				set { _ProductInventory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductInventoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductInventoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductInventoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductInventoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductInventoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						e.Value = ProductInventoryList[e.RowIndex].ProductId;
						break;
					case "uxLocationIdDataGridViewColumn":
						e.Value = ProductInventoryList[e.RowIndex].LocationId;
						break;
					case "uxShelfDataGridViewColumn":
						e.Value = ProductInventoryList[e.RowIndex].Shelf;
						break;
					case "uxBinDataGridViewColumn":
						e.Value = ProductInventoryList[e.RowIndex].Bin;
						break;
					case "uxQuantityDataGridViewColumn":
						e.Value = ProductInventoryList[e.RowIndex].Quantity;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = ProductInventoryList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductInventoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductInventoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductInventoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductInventoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						ProductInventoryList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxLocationIdDataGridViewColumn":
						ProductInventoryList[e.RowIndex].LocationId = (System.Int16)e.Value;
						break;
					case "uxShelfDataGridViewColumn":
						ProductInventoryList[e.RowIndex].Shelf = (System.String)e.Value;
						break;
					case "uxBinDataGridViewColumn":
						ProductInventoryList[e.RowIndex].Bin = (System.Byte)e.Value;
						break;
					case "uxQuantityDataGridViewColumn":
						ProductInventoryList[e.RowIndex].Quantity = (System.Int16)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						ProductInventoryList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductInventoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
