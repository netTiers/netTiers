
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductModel typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductModelDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductModelDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductModel _currentProductModel = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductModelDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductModelErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductModelBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ProductModelId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductModelIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CatalogDescription property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCatalogDescriptionDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Instructions property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxInstructionsDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.ProductModel> _ProductModelList;
				
		/// <summary> 
		/// The list of ProductModel to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductModel> ProductModelList
		{
			get {return this._ProductModelList;}
			set
			{
				this._ProductModelList = value;
				this.uxProductModelBindingSource.DataSource = null;
				this.uxProductModelBindingSource.DataSource = value;
				this.uxProductModelDataGridView.DataSource = null;
				this.uxProductModelDataGridView.DataSource = this.uxProductModelBindingSource;				
				//this.uxProductModelBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductModelBindingSource_ListChanged);
				this.uxProductModelBindingSource.CurrentItemChanged += new System.EventHandler(OnProductModelBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductModelBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductModel = uxProductModelBindingSource.Current as Entities.ProductModel;
			
			if (_currentProductModel != null)
			{
				_currentProductModel.Validate();
			}
			//_ProductModel.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductModelBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductModel"/> instance.
		/// </summary>
		public Entities.ProductModel SelectedProductModel
		{
			get {return this._currentProductModel;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductModelDataGridView.VirtualMode;}
			set
			{
				this.uxProductModelDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductModelDataGridView.AllowUserToAddRows;}
			set {this.uxProductModelDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductModelDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductModelDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductModelDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductModelDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductModelDataGridViewBase"/> class.
		/// </summary>
		public ProductModelDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductModelDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductModelErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductModelIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCatalogDescriptionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxInstructionsDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductModelErrorProvider
			// 
			this.uxProductModelErrorProvider.ContainerControl = this;
			this.uxProductModelErrorProvider.DataSource = this.uxProductModelBindingSource;						
			// 
			// uxProductModelDataGridView
			// 
			this.uxProductModelDataGridView.AutoGenerateColumns = false;
			this.uxProductModelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductModelDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductModelIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxCatalogDescriptionDataGridViewColumn,
		this.uxInstructionsDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductModelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductModelDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductModelDataGridView.Name = "uxProductModelDataGridView";
			this.uxProductModelDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductModelDataGridView.TabIndex = 0;	
			this.uxProductModelDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductModelDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductModelDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductModelDataGridViewDataError);
			this.uxProductModelDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductModelDataGridViewCellValueNeeded);
			this.uxProductModelDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductModelDataGridViewCellValuePushed);
			
			//
			// uxProductModelIdDataGridViewColumn
			//
			this.uxProductModelIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductModelIdDataGridViewColumn.DataPropertyName = "ProductModelId";
			this.uxProductModelIdDataGridViewColumn.HeaderText = "ProductModelId";
			this.uxProductModelIdDataGridViewColumn.Name = "uxProductModelIdDataGridViewColumn";
			this.uxProductModelIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductModelIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductModelIdDataGridViewColumn.ReadOnly = true;		
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
			// uxCatalogDescriptionDataGridViewColumn
			//
			this.uxCatalogDescriptionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCatalogDescriptionDataGridViewColumn.DataPropertyName = "CatalogDescription";
			this.uxCatalogDescriptionDataGridViewColumn.HeaderText = "CatalogDescription";
			this.uxCatalogDescriptionDataGridViewColumn.Name = "uxCatalogDescriptionDataGridViewColumn";
			this.uxCatalogDescriptionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCatalogDescriptionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCatalogDescriptionDataGridViewColumn.ReadOnly = false;		
			//
			// uxInstructionsDataGridViewColumn
			//
			this.uxInstructionsDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxInstructionsDataGridViewColumn.DataPropertyName = "Instructions";
			this.uxInstructionsDataGridViewColumn.HeaderText = "Instructions";
			this.uxInstructionsDataGridViewColumn.Name = "uxInstructionsDataGridViewColumn";
			this.uxInstructionsDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxInstructionsDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxInstructionsDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxProductModelDataGridView);
			this.Name = "ProductModelDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelBindingSource)).EndInit();
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
				ProductModelDataGridViewEventArgs args = new ProductModelDataGridViewEventArgs();
				args.ProductModel = _currentProductModel;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductModelDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductModel	_ProductModel;
	
			/// <summary>
			/// the  Entities.ProductModel instance.
			/// </summary>
			public Entities.ProductModel ProductModel
			{
				get { return _ProductModel; }
				set { _ProductModel = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductModelDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductModelDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductModelDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductModelIdDataGridViewColumn":
						e.Value = ProductModelList[e.RowIndex].ProductModelId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = ProductModelList[e.RowIndex].Name;
						break;
					case "uxCatalogDescriptionDataGridViewColumn":
						e.Value = ProductModelList[e.RowIndex].CatalogDescription;
						break;
					case "uxInstructionsDataGridViewColumn":
						e.Value = ProductModelList[e.RowIndex].Instructions;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = ProductModelList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductModelList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductModelDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductModelDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductModelIdDataGridViewColumn":
						ProductModelList[e.RowIndex].ProductModelId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						ProductModelList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxCatalogDescriptionDataGridViewColumn":
						ProductModelList[e.RowIndex].CatalogDescription = (string)e.Value;
						break;
					case "uxInstructionsDataGridViewColumn":
						ProductModelList[e.RowIndex].Instructions = (string)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						ProductModelList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductModelList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
