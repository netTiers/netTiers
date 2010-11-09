
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductProductPhoto typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductProductPhotoDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductProductPhotoDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductProductPhoto _currentProductProductPhoto = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductProductPhotoDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductProductPhotoErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductProductPhotoBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductPhotoId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductPhotoIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Primary property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxPrimaryDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.ProductPhoto> _ProductPhotoIdList;
		
		/// <summary> 
		/// The list of selectable ProductPhoto
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ProductPhoto> ProductPhotoIdList
		{
			get {return this._ProductPhotoIdList;}
			set 
			{
				this._ProductPhotoIdList = value;
				this.uxProductPhotoIdDataGridViewColumn.DataSource = null;
				this.uxProductPhotoIdDataGridViewColumn.DataSource = this._ProductPhotoIdList;
			}
		}
		
		private bool _allowNewItemInProductPhotoIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ProductPhoto
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductPhotoIdList
		{
			get { return _allowNewItemInProductPhotoIdList;}
			set
			{
				this._allowNewItemInProductPhotoIdList = value;
				this.uxProductPhotoIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductProductPhoto> _ProductProductPhotoList;
				
		/// <summary> 
		/// The list of ProductProductPhoto to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductProductPhoto> ProductProductPhotoList
		{
			get {return this._ProductProductPhotoList;}
			set
			{
				this._ProductProductPhotoList = value;
				this.uxProductProductPhotoBindingSource.DataSource = null;
				this.uxProductProductPhotoBindingSource.DataSource = value;
				this.uxProductProductPhotoDataGridView.DataSource = null;
				this.uxProductProductPhotoDataGridView.DataSource = this.uxProductProductPhotoBindingSource;				
				//this.uxProductProductPhotoBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductProductPhotoBindingSource_ListChanged);
				this.uxProductProductPhotoBindingSource.CurrentItemChanged += new System.EventHandler(OnProductProductPhotoBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductProductPhotoBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductProductPhoto = uxProductProductPhotoBindingSource.Current as Entities.ProductProductPhoto;
			
			if (_currentProductProductPhoto != null)
			{
				_currentProductProductPhoto.Validate();
			}
			//_ProductProductPhoto.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductProductPhotoBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductProductPhoto"/> instance.
		/// </summary>
		public Entities.ProductProductPhoto SelectedProductProductPhoto
		{
			get {return this._currentProductProductPhoto;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductProductPhotoDataGridView.VirtualMode;}
			set
			{
				this.uxProductProductPhotoDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductProductPhotoDataGridView.AllowUserToAddRows;}
			set {this.uxProductProductPhotoDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductProductPhotoDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductProductPhotoDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductProductPhotoDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductProductPhotoDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductProductPhotoDataGridViewBase"/> class.
		/// </summary>
		public ProductProductPhotoDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductProductPhotoDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductProductPhotoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductProductPhotoErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxProductPhotoIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxPrimaryDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			//this.uxProductPhotoIdBindingSource = new ProductPhotoBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductPhotoIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductProductPhotoDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductProductPhotoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductProductPhotoErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductProductPhotoErrorProvider
			// 
			this.uxProductProductPhotoErrorProvider.ContainerControl = this;
			this.uxProductProductPhotoErrorProvider.DataSource = this.uxProductProductPhotoBindingSource;						
			// 
			// uxProductProductPhotoDataGridView
			// 
			this.uxProductProductPhotoDataGridView.AutoGenerateColumns = false;
			this.uxProductProductPhotoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductProductPhotoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductIdDataGridViewColumn,
		this.uxProductPhotoIdDataGridViewColumn,
		this.uxPrimaryDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductProductPhotoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductProductPhotoDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductProductPhotoDataGridView.Name = "uxProductProductPhotoDataGridView";
			this.uxProductProductPhotoDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductProductPhotoDataGridView.TabIndex = 0;	
			this.uxProductProductPhotoDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductProductPhotoDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductProductPhotoDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductProductPhotoDataGridViewDataError);
			this.uxProductProductPhotoDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductProductPhotoDataGridViewCellValueNeeded);
			this.uxProductProductPhotoDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductProductPhotoDataGridViewCellValuePushed);
			
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
			// uxProductPhotoIdDataGridViewColumn
			//
			this.uxProductPhotoIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductPhotoIdDataGridViewColumn.DataPropertyName = "ProductPhotoId";
			this.uxProductPhotoIdDataGridViewColumn.HeaderText = "ProductPhotoId";
			this.uxProductPhotoIdDataGridViewColumn.Name = "uxProductPhotoIdDataGridViewColumn";
			this.uxProductPhotoIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductPhotoIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductPhotoIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxPrimaryDataGridViewColumn
			//
			this.uxPrimaryDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPrimaryDataGridViewColumn.DataPropertyName = "Primary";
			this.uxPrimaryDataGridViewColumn.HeaderText = "Primary";
			this.uxPrimaryDataGridViewColumn.Name = "uxPrimaryDataGridViewColumn";
			this.uxPrimaryDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPrimaryDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPrimaryDataGridViewColumn.ReadOnly = false;		
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
			// uxProductPhotoIdDataGridViewColumn
			//				
			this.uxProductPhotoIdDataGridViewColumn.DisplayMember = "ThumbNailPhoto";	
			this.uxProductPhotoIdDataGridViewColumn.ValueMember = "ProductPhotoId";	
			this.uxProductPhotoIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductPhotoIdDataGridViewColumn.DataSource = uxProductPhotoIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductProductPhotoDataGridView);
			this.Name = "ProductProductPhotoDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxProductPhotoIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductProductPhotoErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductProductPhotoDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductProductPhotoBindingSource)).EndInit();
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
				ProductProductPhotoDataGridViewEventArgs args = new ProductProductPhotoDataGridViewEventArgs();
				args.ProductProductPhoto = _currentProductProductPhoto;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductProductPhotoDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductProductPhoto	_ProductProductPhoto;
	
			/// <summary>
			/// the  Entities.ProductProductPhoto instance.
			/// </summary>
			public Entities.ProductProductPhoto ProductProductPhoto
			{
				get { return _ProductProductPhoto; }
				set { _ProductProductPhoto = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductProductPhotoDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductProductPhotoDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductProductPhotoDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductProductPhotoDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductProductPhotoDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						e.Value = ProductProductPhotoList[e.RowIndex].ProductId;
						break;
					case "uxProductPhotoIdDataGridViewColumn":
						e.Value = ProductProductPhotoList[e.RowIndex].ProductPhotoId;
						break;
					case "uxPrimaryDataGridViewColumn":
						e.Value = ProductProductPhotoList[e.RowIndex].Primary;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductProductPhotoList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductProductPhotoDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductProductPhotoDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductProductPhotoDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						ProductProductPhotoList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxProductPhotoIdDataGridViewColumn":
						ProductProductPhotoList[e.RowIndex].ProductPhotoId = (System.Int32)e.Value;
						break;
					case "uxPrimaryDataGridViewColumn":
						ProductProductPhotoList[e.RowIndex].Primary = (System.Boolean)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductProductPhotoList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
