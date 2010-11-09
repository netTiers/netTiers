
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductPhoto typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductPhotoDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductPhotoDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductPhoto _currentProductPhoto = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductPhotoDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductPhotoErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductPhotoBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ProductPhotoId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductPhotoIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ThumbNailPhoto property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxThumbNailPhotoDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ThumbnailPhotoFileName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxThumbnailPhotoFileNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LargePhoto property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLargePhotoDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LargePhotoFileName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLargePhotoFileNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductPhoto> _ProductPhotoList;
				
		/// <summary> 
		/// The list of ProductPhoto to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductPhoto> ProductPhotoList
		{
			get {return this._ProductPhotoList;}
			set
			{
				this._ProductPhotoList = value;
				this.uxProductPhotoBindingSource.DataSource = null;
				this.uxProductPhotoBindingSource.DataSource = value;
				this.uxProductPhotoDataGridView.DataSource = null;
				this.uxProductPhotoDataGridView.DataSource = this.uxProductPhotoBindingSource;				
				//this.uxProductPhotoBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductPhotoBindingSource_ListChanged);
				this.uxProductPhotoBindingSource.CurrentItemChanged += new System.EventHandler(OnProductPhotoBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductPhotoBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductPhoto = uxProductPhotoBindingSource.Current as Entities.ProductPhoto;
			
			if (_currentProductPhoto != null)
			{
				_currentProductPhoto.Validate();
			}
			//_ProductPhoto.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductPhotoBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductPhoto"/> instance.
		/// </summary>
		public Entities.ProductPhoto SelectedProductPhoto
		{
			get {return this._currentProductPhoto;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductPhotoDataGridView.VirtualMode;}
			set
			{
				this.uxProductPhotoDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductPhotoDataGridView.AllowUserToAddRows;}
			set {this.uxProductPhotoDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductPhotoDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductPhotoDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductPhotoDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductPhotoDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductPhotoDataGridViewBase"/> class.
		/// </summary>
		public ProductPhotoDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductPhotoDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductPhotoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductPhotoErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductPhotoIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxThumbNailPhotoDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxThumbnailPhotoFileNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLargePhotoDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLargePhotoFileNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxProductPhotoDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductPhotoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductPhotoErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductPhotoErrorProvider
			// 
			this.uxProductPhotoErrorProvider.ContainerControl = this;
			this.uxProductPhotoErrorProvider.DataSource = this.uxProductPhotoBindingSource;						
			// 
			// uxProductPhotoDataGridView
			// 
			this.uxProductPhotoDataGridView.AutoGenerateColumns = false;
			this.uxProductPhotoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductPhotoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductPhotoIdDataGridViewColumn,
		this.uxThumbNailPhotoDataGridViewColumn,
		this.uxThumbnailPhotoFileNameDataGridViewColumn,
		this.uxLargePhotoDataGridViewColumn,
		this.uxLargePhotoFileNameDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductPhotoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductPhotoDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductPhotoDataGridView.Name = "uxProductPhotoDataGridView";
			this.uxProductPhotoDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductPhotoDataGridView.TabIndex = 0;	
			this.uxProductPhotoDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductPhotoDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductPhotoDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductPhotoDataGridViewDataError);
			this.uxProductPhotoDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductPhotoDataGridViewCellValueNeeded);
			this.uxProductPhotoDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductPhotoDataGridViewCellValuePushed);
			
			//
			// uxProductPhotoIdDataGridViewColumn
			//
			this.uxProductPhotoIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductPhotoIdDataGridViewColumn.DataPropertyName = "ProductPhotoId";
			this.uxProductPhotoIdDataGridViewColumn.HeaderText = "ProductPhotoId";
			this.uxProductPhotoIdDataGridViewColumn.Name = "uxProductPhotoIdDataGridViewColumn";
			this.uxProductPhotoIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductPhotoIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductPhotoIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxThumbNailPhotoDataGridViewColumn
			//
			this.uxThumbNailPhotoDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxThumbNailPhotoDataGridViewColumn.DataPropertyName = "ThumbNailPhoto";
			this.uxThumbNailPhotoDataGridViewColumn.HeaderText = "ThumbNailPhoto";
			this.uxThumbNailPhotoDataGridViewColumn.Name = "uxThumbNailPhotoDataGridViewColumn";
			this.uxThumbNailPhotoDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxThumbNailPhotoDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxThumbNailPhotoDataGridViewColumn.ReadOnly = false;		
			//
			// uxThumbnailPhotoFileNameDataGridViewColumn
			//
			this.uxThumbnailPhotoFileNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxThumbnailPhotoFileNameDataGridViewColumn.DataPropertyName = "ThumbnailPhotoFileName";
			this.uxThumbnailPhotoFileNameDataGridViewColumn.HeaderText = "ThumbnailPhotoFileName";
			this.uxThumbnailPhotoFileNameDataGridViewColumn.Name = "uxThumbnailPhotoFileNameDataGridViewColumn";
			this.uxThumbnailPhotoFileNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxThumbnailPhotoFileNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxThumbnailPhotoFileNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxLargePhotoDataGridViewColumn
			//
			this.uxLargePhotoDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLargePhotoDataGridViewColumn.DataPropertyName = "LargePhoto";
			this.uxLargePhotoDataGridViewColumn.HeaderText = "LargePhoto";
			this.uxLargePhotoDataGridViewColumn.Name = "uxLargePhotoDataGridViewColumn";
			this.uxLargePhotoDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLargePhotoDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLargePhotoDataGridViewColumn.ReadOnly = false;		
			//
			// uxLargePhotoFileNameDataGridViewColumn
			//
			this.uxLargePhotoFileNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLargePhotoFileNameDataGridViewColumn.DataPropertyName = "LargePhotoFileName";
			this.uxLargePhotoFileNameDataGridViewColumn.HeaderText = "LargePhotoFileName";
			this.uxLargePhotoFileNameDataGridViewColumn.Name = "uxLargePhotoFileNameDataGridViewColumn";
			this.uxLargePhotoFileNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLargePhotoFileNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLargePhotoFileNameDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxProductPhotoDataGridView);
			this.Name = "ProductPhotoDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxProductPhotoErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductPhotoDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductPhotoBindingSource)).EndInit();
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
				ProductPhotoDataGridViewEventArgs args = new ProductPhotoDataGridViewEventArgs();
				args.ProductPhoto = _currentProductPhoto;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductPhotoDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductPhoto	_ProductPhoto;
	
			/// <summary>
			/// the  Entities.ProductPhoto instance.
			/// </summary>
			public Entities.ProductPhoto ProductPhoto
			{
				get { return _ProductPhoto; }
				set { _ProductPhoto = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductPhotoDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductPhotoDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductPhotoDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductPhotoDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductPhotoDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductPhotoIdDataGridViewColumn":
						e.Value = ProductPhotoList[e.RowIndex].ProductPhotoId;
						break;
					case "uxThumbNailPhotoDataGridViewColumn":
						e.Value = ProductPhotoList[e.RowIndex].ThumbNailPhoto;
						break;
					case "uxThumbnailPhotoFileNameDataGridViewColumn":
						e.Value = ProductPhotoList[e.RowIndex].ThumbnailPhotoFileName;
						break;
					case "uxLargePhotoDataGridViewColumn":
						e.Value = ProductPhotoList[e.RowIndex].LargePhoto;
						break;
					case "uxLargePhotoFileNameDataGridViewColumn":
						e.Value = ProductPhotoList[e.RowIndex].LargePhotoFileName;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductPhotoList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductPhotoDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductPhotoDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductPhotoDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductPhotoIdDataGridViewColumn":
						ProductPhotoList[e.RowIndex].ProductPhotoId = (System.Int32)e.Value;
						break;
					case "uxThumbNailPhotoDataGridViewColumn":
						ProductPhotoList[e.RowIndex].ThumbNailPhoto = (System.Byte[])e.Value;
						break;
					case "uxThumbnailPhotoFileNameDataGridViewColumn":
						ProductPhotoList[e.RowIndex].ThumbnailPhotoFileName = (System.String)e.Value;
						break;
					case "uxLargePhotoDataGridViewColumn":
						ProductPhotoList[e.RowIndex].LargePhoto = (System.Byte[])e.Value;
						break;
					case "uxLargePhotoFileNameDataGridViewColumn":
						ProductPhotoList[e.RowIndex].LargePhotoFileName = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductPhotoList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
