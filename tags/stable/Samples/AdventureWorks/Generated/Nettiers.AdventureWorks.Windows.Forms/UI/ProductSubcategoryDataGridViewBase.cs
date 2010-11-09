
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductSubcategory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductSubcategoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductSubcategoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductSubcategory _currentProductSubcategory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductSubcategoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductSubcategoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductSubcategoryBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ProductSubcategoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductSubcategoryIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductCategoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductCategoryIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.ProductCategory> _ProductCategoryIdList;
		
		/// <summary> 
		/// The list of selectable ProductCategory
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ProductCategory> ProductCategoryIdList
		{
			get {return this._ProductCategoryIdList;}
			set 
			{
				this._ProductCategoryIdList = value;
				this.uxProductCategoryIdDataGridViewColumn.DataSource = null;
				this.uxProductCategoryIdDataGridViewColumn.DataSource = this._ProductCategoryIdList;
			}
		}
		
		private bool _allowNewItemInProductCategoryIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ProductCategory
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductCategoryIdList
		{
			get { return _allowNewItemInProductCategoryIdList;}
			set
			{
				this._allowNewItemInProductCategoryIdList = value;
				this.uxProductCategoryIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductSubcategory> _ProductSubcategoryList;
				
		/// <summary> 
		/// The list of ProductSubcategory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductSubcategory> ProductSubcategoryList
		{
			get {return this._ProductSubcategoryList;}
			set
			{
				this._ProductSubcategoryList = value;
				this.uxProductSubcategoryBindingSource.DataSource = null;
				this.uxProductSubcategoryBindingSource.DataSource = value;
				this.uxProductSubcategoryDataGridView.DataSource = null;
				this.uxProductSubcategoryDataGridView.DataSource = this.uxProductSubcategoryBindingSource;				
				//this.uxProductSubcategoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductSubcategoryBindingSource_ListChanged);
				this.uxProductSubcategoryBindingSource.CurrentItemChanged += new System.EventHandler(OnProductSubcategoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductSubcategoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductSubcategory = uxProductSubcategoryBindingSource.Current as Entities.ProductSubcategory;
			
			if (_currentProductSubcategory != null)
			{
				_currentProductSubcategory.Validate();
			}
			//_ProductSubcategory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductSubcategoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductSubcategory"/> instance.
		/// </summary>
		public Entities.ProductSubcategory SelectedProductSubcategory
		{
			get {return this._currentProductSubcategory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductSubcategoryDataGridView.VirtualMode;}
			set
			{
				this.uxProductSubcategoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductSubcategoryDataGridView.AllowUserToAddRows;}
			set {this.uxProductSubcategoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductSubcategoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductSubcategoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductSubcategoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductSubcategoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductSubcategoryDataGridViewBase"/> class.
		/// </summary>
		public ProductSubcategoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductSubcategoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductSubcategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductSubcategoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductSubcategoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductCategoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductCategoryIdBindingSource = new ProductCategoryBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductCategoryIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductSubcategoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductSubcategoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductSubcategoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductSubcategoryErrorProvider
			// 
			this.uxProductSubcategoryErrorProvider.ContainerControl = this;
			this.uxProductSubcategoryErrorProvider.DataSource = this.uxProductSubcategoryBindingSource;						
			// 
			// uxProductSubcategoryDataGridView
			// 
			this.uxProductSubcategoryDataGridView.AutoGenerateColumns = false;
			this.uxProductSubcategoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductSubcategoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductSubcategoryIdDataGridViewColumn,
		this.uxProductCategoryIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductSubcategoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductSubcategoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductSubcategoryDataGridView.Name = "uxProductSubcategoryDataGridView";
			this.uxProductSubcategoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductSubcategoryDataGridView.TabIndex = 0;	
			this.uxProductSubcategoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductSubcategoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductSubcategoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductSubcategoryDataGridViewDataError);
			this.uxProductSubcategoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductSubcategoryDataGridViewCellValueNeeded);
			this.uxProductSubcategoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductSubcategoryDataGridViewCellValuePushed);
			
			//
			// uxProductSubcategoryIdDataGridViewColumn
			//
			this.uxProductSubcategoryIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductSubcategoryIdDataGridViewColumn.DataPropertyName = "ProductSubcategoryId";
			this.uxProductSubcategoryIdDataGridViewColumn.HeaderText = "ProductSubcategoryId";
			this.uxProductSubcategoryIdDataGridViewColumn.Name = "uxProductSubcategoryIdDataGridViewColumn";
			this.uxProductSubcategoryIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductSubcategoryIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductSubcategoryIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxProductCategoryIdDataGridViewColumn
			//
			this.uxProductCategoryIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductCategoryIdDataGridViewColumn.DataPropertyName = "ProductCategoryId";
			this.uxProductCategoryIdDataGridViewColumn.HeaderText = "ProductCategoryId";
			this.uxProductCategoryIdDataGridViewColumn.Name = "uxProductCategoryIdDataGridViewColumn";
			this.uxProductCategoryIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductCategoryIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductCategoryIdDataGridViewColumn.ReadOnly = false;		
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
			// uxProductCategoryIdDataGridViewColumn
			//				
			this.uxProductCategoryIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductCategoryIdDataGridViewColumn.ValueMember = "ProductCategoryId";	
			this.uxProductCategoryIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductCategoryIdDataGridViewColumn.DataSource = uxProductCategoryIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductSubcategoryDataGridView);
			this.Name = "ProductSubcategoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductCategoryIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductSubcategoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductSubcategoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductSubcategoryBindingSource)).EndInit();
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
				ProductSubcategoryDataGridViewEventArgs args = new ProductSubcategoryDataGridViewEventArgs();
				args.ProductSubcategory = _currentProductSubcategory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductSubcategoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductSubcategory	_ProductSubcategory;
	
			/// <summary>
			/// the  Entities.ProductSubcategory instance.
			/// </summary>
			public Entities.ProductSubcategory ProductSubcategory
			{
				get { return _ProductSubcategory; }
				set { _ProductSubcategory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductSubcategoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductSubcategoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductSubcategoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductSubcategoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductSubcategoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductSubcategoryIdDataGridViewColumn":
						e.Value = ProductSubcategoryList[e.RowIndex].ProductSubcategoryId;
						break;
					case "uxProductCategoryIdDataGridViewColumn":
						e.Value = ProductSubcategoryList[e.RowIndex].ProductCategoryId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = ProductSubcategoryList[e.RowIndex].Name;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = ProductSubcategoryList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductSubcategoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductSubcategoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductSubcategoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductSubcategoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductSubcategoryIdDataGridViewColumn":
						ProductSubcategoryList[e.RowIndex].ProductSubcategoryId = (System.Int32)e.Value;
						break;
					case "uxProductCategoryIdDataGridViewColumn":
						ProductSubcategoryList[e.RowIndex].ProductCategoryId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						ProductSubcategoryList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						ProductSubcategoryList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductSubcategoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
