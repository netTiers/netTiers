
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductDocument typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductDocumentDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductDocumentDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductDocument _currentProductDocument = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductDocumentDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductDocumentErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductDocumentBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the DocumentId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxDocumentIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Document> _DocumentIdList;
		
		/// <summary> 
		/// The list of selectable Document
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Document> DocumentIdList
		{
			get {return this._DocumentIdList;}
			set 
			{
				this._DocumentIdList = value;
				this.uxDocumentIdDataGridViewColumn.DataSource = null;
				this.uxDocumentIdDataGridViewColumn.DataSource = this._DocumentIdList;
			}
		}
		
		private bool _allowNewItemInDocumentIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Document
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInDocumentIdList
		{
			get { return _allowNewItemInDocumentIdList;}
			set
			{
				this._allowNewItemInDocumentIdList = value;
				this.uxDocumentIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
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
		
		private Entities.TList<Entities.ProductDocument> _ProductDocumentList;
				
		/// <summary> 
		/// The list of ProductDocument to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductDocument> ProductDocumentList
		{
			get {return this._ProductDocumentList;}
			set
			{
				this._ProductDocumentList = value;
				this.uxProductDocumentBindingSource.DataSource = null;
				this.uxProductDocumentBindingSource.DataSource = value;
				this.uxProductDocumentDataGridView.DataSource = null;
				this.uxProductDocumentDataGridView.DataSource = this.uxProductDocumentBindingSource;				
				//this.uxProductDocumentBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductDocumentBindingSource_ListChanged);
				this.uxProductDocumentBindingSource.CurrentItemChanged += new System.EventHandler(OnProductDocumentBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductDocumentBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductDocument = uxProductDocumentBindingSource.Current as Entities.ProductDocument;
			
			if (_currentProductDocument != null)
			{
				_currentProductDocument.Validate();
			}
			//_ProductDocument.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductDocumentBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductDocument"/> instance.
		/// </summary>
		public Entities.ProductDocument SelectedProductDocument
		{
			get {return this._currentProductDocument;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductDocumentDataGridView.VirtualMode;}
			set
			{
				this.uxProductDocumentDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductDocumentDataGridView.AllowUserToAddRows;}
			set {this.uxProductDocumentDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductDocumentDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductDocumentDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductDocumentDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductDocumentDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductDocumentDataGridViewBase"/> class.
		/// </summary>
		public ProductDocumentDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductDocumentDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductDocumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductDocumentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxDocumentIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxDocumentIdBindingSource = new DocumentBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxDocumentIdBindingSource)).BeginInit();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDocumentDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDocumentBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDocumentErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductDocumentErrorProvider
			// 
			this.uxProductDocumentErrorProvider.ContainerControl = this;
			this.uxProductDocumentErrorProvider.DataSource = this.uxProductDocumentBindingSource;						
			// 
			// uxProductDocumentDataGridView
			// 
			this.uxProductDocumentDataGridView.AutoGenerateColumns = false;
			this.uxProductDocumentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductDocumentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductIdDataGridViewColumn,
		this.uxDocumentIdDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductDocumentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductDocumentDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductDocumentDataGridView.Name = "uxProductDocumentDataGridView";
			this.uxProductDocumentDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductDocumentDataGridView.TabIndex = 0;	
			this.uxProductDocumentDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductDocumentDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductDocumentDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductDocumentDataGridViewDataError);
			this.uxProductDocumentDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductDocumentDataGridViewCellValueNeeded);
			this.uxProductDocumentDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductDocumentDataGridViewCellValuePushed);
			
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
			// uxDocumentIdDataGridViewColumn
			//
			this.uxDocumentIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDocumentIdDataGridViewColumn.DataPropertyName = "DocumentId";
			this.uxDocumentIdDataGridViewColumn.HeaderText = "DocumentId";
			this.uxDocumentIdDataGridViewColumn.Name = "uxDocumentIdDataGridViewColumn";
			this.uxDocumentIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDocumentIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDocumentIdDataGridViewColumn.ReadOnly = false;		
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
			// uxDocumentIdDataGridViewColumn
			//				
			this.uxDocumentIdDataGridViewColumn.DisplayMember = "Title";	
			this.uxDocumentIdDataGridViewColumn.ValueMember = "DocumentId";	
			this.uxDocumentIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxDocumentIdDataGridViewColumn.DataSource = uxDocumentIdBindingSource;				
				
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
			this.Controls.Add(this.uxProductDocumentDataGridView);
			this.Name = "ProductDocumentDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxDocumentIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDocumentErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDocumentDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDocumentBindingSource)).EndInit();
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
				ProductDocumentDataGridViewEventArgs args = new ProductDocumentDataGridViewEventArgs();
				args.ProductDocument = _currentProductDocument;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductDocumentDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductDocument	_ProductDocument;
	
			/// <summary>
			/// the  Entities.ProductDocument instance.
			/// </summary>
			public Entities.ProductDocument ProductDocument
			{
				get { return _ProductDocument; }
				set { _ProductDocument = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductDocumentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductDocumentDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductDocumentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductDocumentDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductDocumentDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						e.Value = ProductDocumentList[e.RowIndex].ProductId;
						break;
					case "uxDocumentIdDataGridViewColumn":
						e.Value = ProductDocumentList[e.RowIndex].DocumentId;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductDocumentList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductDocumentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductDocumentDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductDocumentDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						ProductDocumentList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxDocumentIdDataGridViewColumn":
						ProductDocumentList[e.RowIndex].DocumentId = (System.Int32)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductDocumentList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
