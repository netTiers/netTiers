
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductCategory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductCategoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductCategoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductCategory _currentProductCategory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductCategoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductCategoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductCategoryBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ProductCategoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductCategoryIdDataGridViewColumn;
		
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductCategory> _ProductCategoryList;
				
		/// <summary> 
		/// The list of ProductCategory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductCategory> ProductCategoryList
		{
			get {return this._ProductCategoryList;}
			set
			{
				this._ProductCategoryList = value;
				this.uxProductCategoryBindingSource.DataSource = null;
				this.uxProductCategoryBindingSource.DataSource = value;
				this.uxProductCategoryDataGridView.DataSource = null;
				this.uxProductCategoryDataGridView.DataSource = this.uxProductCategoryBindingSource;				
				//this.uxProductCategoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductCategoryBindingSource_ListChanged);
				this.uxProductCategoryBindingSource.CurrentItemChanged += new System.EventHandler(OnProductCategoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductCategoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductCategory = uxProductCategoryBindingSource.Current as Entities.ProductCategory;
			
			if (_currentProductCategory != null)
			{
				_currentProductCategory.Validate();
			}
			//_ProductCategory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductCategoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductCategory"/> instance.
		/// </summary>
		public Entities.ProductCategory SelectedProductCategory
		{
			get {return this._currentProductCategory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductCategoryDataGridView.VirtualMode;}
			set
			{
				this.uxProductCategoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductCategoryDataGridView.AllowUserToAddRows;}
			set {this.uxProductCategoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductCategoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductCategoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductCategoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductCategoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductCategoryDataGridViewBase"/> class.
		/// </summary>
		public ProductCategoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductCategoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductCategoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductCategoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCategoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCategoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCategoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductCategoryErrorProvider
			// 
			this.uxProductCategoryErrorProvider.ContainerControl = this;
			this.uxProductCategoryErrorProvider.DataSource = this.uxProductCategoryBindingSource;						
			// 
			// uxProductCategoryDataGridView
			// 
			this.uxProductCategoryDataGridView.AutoGenerateColumns = false;
			this.uxProductCategoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductCategoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductCategoryIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductCategoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductCategoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductCategoryDataGridView.Name = "uxProductCategoryDataGridView";
			this.uxProductCategoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductCategoryDataGridView.TabIndex = 0;	
			this.uxProductCategoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductCategoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductCategoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductCategoryDataGridViewDataError);
			this.uxProductCategoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductCategoryDataGridViewCellValueNeeded);
			this.uxProductCategoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductCategoryDataGridViewCellValuePushed);
			
			//
			// uxProductCategoryIdDataGridViewColumn
			//
			this.uxProductCategoryIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductCategoryIdDataGridViewColumn.DataPropertyName = "ProductCategoryId";
			this.uxProductCategoryIdDataGridViewColumn.HeaderText = "ProductCategoryId";
			this.uxProductCategoryIdDataGridViewColumn.Name = "uxProductCategoryIdDataGridViewColumn";
			this.uxProductCategoryIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductCategoryIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductCategoryIdDataGridViewColumn.ReadOnly = true;		
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
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductCategoryDataGridView);
			this.Name = "ProductCategoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxProductCategoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCategoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCategoryBindingSource)).EndInit();
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
				ProductCategoryDataGridViewEventArgs args = new ProductCategoryDataGridViewEventArgs();
				args.ProductCategory = _currentProductCategory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductCategoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductCategory	_ProductCategory;
	
			/// <summary>
			/// the  Entities.ProductCategory instance.
			/// </summary>
			public Entities.ProductCategory ProductCategory
			{
				get { return _ProductCategory; }
				set { _ProductCategory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductCategoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductCategoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductCategoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductCategoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductCategoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductCategoryIdDataGridViewColumn":
						e.Value = ProductCategoryList[e.RowIndex].ProductCategoryId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = ProductCategoryList[e.RowIndex].Name;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = ProductCategoryList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductCategoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductCategoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductCategoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductCategoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductCategoryIdDataGridViewColumn":
						ProductCategoryList[e.RowIndex].ProductCategoryId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						ProductCategoryList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						ProductCategoryList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductCategoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
