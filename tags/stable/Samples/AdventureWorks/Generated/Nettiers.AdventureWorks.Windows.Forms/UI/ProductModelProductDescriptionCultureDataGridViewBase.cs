
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductModelProductDescriptionCulture typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductModelProductDescriptionCultureDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductModelProductDescriptionCultureDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductModelProductDescriptionCulture _currentProductModelProductDescriptionCulture = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductModelProductDescriptionCultureDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductModelProductDescriptionCultureErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductModelProductDescriptionCultureBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the ProductModelId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductModelIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductDescriptionId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductDescriptionIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the CultureId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCultureIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Culture> _CultureIdList;
		
		/// <summary> 
		/// The list of selectable Culture
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Culture> CultureIdList
		{
			get {return this._CultureIdList;}
			set 
			{
				this._CultureIdList = value;
				this.uxCultureIdDataGridViewColumn.DataSource = null;
				this.uxCultureIdDataGridViewColumn.DataSource = this._CultureIdList;
			}
		}
		
		private bool _allowNewItemInCultureIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Culture
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCultureIdList
		{
			get { return _allowNewItemInCultureIdList;}
			set
			{
				this._allowNewItemInCultureIdList = value;
				this.uxCultureIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.ProductDescription> _ProductDescriptionIdList;
		
		/// <summary> 
		/// The list of selectable ProductDescription
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ProductDescription> ProductDescriptionIdList
		{
			get {return this._ProductDescriptionIdList;}
			set 
			{
				this._ProductDescriptionIdList = value;
				this.uxProductDescriptionIdDataGridViewColumn.DataSource = null;
				this.uxProductDescriptionIdDataGridViewColumn.DataSource = this._ProductDescriptionIdList;
			}
		}
		
		private bool _allowNewItemInProductDescriptionIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ProductDescription
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductDescriptionIdList
		{
			get { return _allowNewItemInProductDescriptionIdList;}
			set
			{
				this._allowNewItemInProductDescriptionIdList = value;
				this.uxProductDescriptionIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductModelProductDescriptionCulture> _ProductModelProductDescriptionCultureList;
				
		/// <summary> 
		/// The list of ProductModelProductDescriptionCulture to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureList
		{
			get {return this._ProductModelProductDescriptionCultureList;}
			set
			{
				this._ProductModelProductDescriptionCultureList = value;
				this.uxProductModelProductDescriptionCultureBindingSource.DataSource = null;
				this.uxProductModelProductDescriptionCultureBindingSource.DataSource = value;
				this.uxProductModelProductDescriptionCultureDataGridView.DataSource = null;
				this.uxProductModelProductDescriptionCultureDataGridView.DataSource = this.uxProductModelProductDescriptionCultureBindingSource;				
				//this.uxProductModelProductDescriptionCultureBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductModelProductDescriptionCultureBindingSource_ListChanged);
				this.uxProductModelProductDescriptionCultureBindingSource.CurrentItemChanged += new System.EventHandler(OnProductModelProductDescriptionCultureBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductModelProductDescriptionCultureBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductModelProductDescriptionCulture = uxProductModelProductDescriptionCultureBindingSource.Current as Entities.ProductModelProductDescriptionCulture;
			
			if (_currentProductModelProductDescriptionCulture != null)
			{
				_currentProductModelProductDescriptionCulture.Validate();
			}
			//_ProductModelProductDescriptionCulture.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductModelProductDescriptionCultureBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductModelProductDescriptionCulture"/> instance.
		/// </summary>
		public Entities.ProductModelProductDescriptionCulture SelectedProductModelProductDescriptionCulture
		{
			get {return this._currentProductModelProductDescriptionCulture;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductModelProductDescriptionCultureDataGridView.VirtualMode;}
			set
			{
				this.uxProductModelProductDescriptionCultureDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductModelProductDescriptionCultureDataGridView.AllowUserToAddRows;}
			set {this.uxProductModelProductDescriptionCultureDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductModelProductDescriptionCultureDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductModelProductDescriptionCultureDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductModelProductDescriptionCultureDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductModelProductDescriptionCultureDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductModelProductDescriptionCultureDataGridViewBase"/> class.
		/// </summary>
		public ProductModelProductDescriptionCultureDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductModelProductDescriptionCultureDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductModelProductDescriptionCultureBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductModelProductDescriptionCultureErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductModelIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxProductDescriptionIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxCultureIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxCultureIdBindingSource = new CultureBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCultureIdBindingSource)).BeginInit();
			//this.uxProductDescriptionIdBindingSource = new ProductDescriptionBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductDescriptionIdBindingSource)).BeginInit();
			//this.uxProductModelIdBindingSource = new ProductModelBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductModelIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelProductDescriptionCultureDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelProductDescriptionCultureBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelProductDescriptionCultureErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductModelProductDescriptionCultureErrorProvider
			// 
			this.uxProductModelProductDescriptionCultureErrorProvider.ContainerControl = this;
			this.uxProductModelProductDescriptionCultureErrorProvider.DataSource = this.uxProductModelProductDescriptionCultureBindingSource;						
			// 
			// uxProductModelProductDescriptionCultureDataGridView
			// 
			this.uxProductModelProductDescriptionCultureDataGridView.AutoGenerateColumns = false;
			this.uxProductModelProductDescriptionCultureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductModelProductDescriptionCultureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductModelIdDataGridViewColumn,
		this.uxProductDescriptionIdDataGridViewColumn,
		this.uxCultureIdDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductModelProductDescriptionCultureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductModelProductDescriptionCultureDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductModelProductDescriptionCultureDataGridView.Name = "uxProductModelProductDescriptionCultureDataGridView";
			this.uxProductModelProductDescriptionCultureDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductModelProductDescriptionCultureDataGridView.TabIndex = 0;	
			this.uxProductModelProductDescriptionCultureDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductModelProductDescriptionCultureDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductModelProductDescriptionCultureDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductModelProductDescriptionCultureDataGridViewDataError);
			this.uxProductModelProductDescriptionCultureDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductModelProductDescriptionCultureDataGridViewCellValueNeeded);
			this.uxProductModelProductDescriptionCultureDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductModelProductDescriptionCultureDataGridViewCellValuePushed);
			
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
			// uxProductDescriptionIdDataGridViewColumn
			//
			this.uxProductDescriptionIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductDescriptionIdDataGridViewColumn.DataPropertyName = "ProductDescriptionId";
			this.uxProductDescriptionIdDataGridViewColumn.HeaderText = "ProductDescriptionId";
			this.uxProductDescriptionIdDataGridViewColumn.Name = "uxProductDescriptionIdDataGridViewColumn";
			this.uxProductDescriptionIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductDescriptionIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductDescriptionIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxCultureIdDataGridViewColumn
			//
			this.uxCultureIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCultureIdDataGridViewColumn.DataPropertyName = "CultureId";
			this.uxCultureIdDataGridViewColumn.HeaderText = "CultureId";
			this.uxCultureIdDataGridViewColumn.Name = "uxCultureIdDataGridViewColumn";
			this.uxCultureIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCultureIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCultureIdDataGridViewColumn.ReadOnly = false;		
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
			// uxCultureIdDataGridViewColumn
			//				
			this.uxCultureIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxCultureIdDataGridViewColumn.ValueMember = "CultureId";	
			this.uxCultureIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCultureIdDataGridViewColumn.DataSource = uxCultureIdBindingSource;				
				
			//
			// uxProductDescriptionIdDataGridViewColumn
			//				
			this.uxProductDescriptionIdDataGridViewColumn.DisplayMember = "Description";	
			this.uxProductDescriptionIdDataGridViewColumn.ValueMember = "ProductDescriptionId";	
			this.uxProductDescriptionIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductDescriptionIdDataGridViewColumn.DataSource = uxProductDescriptionIdBindingSource;				
				
			//
			// uxProductModelIdDataGridViewColumn
			//				
			this.uxProductModelIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductModelIdDataGridViewColumn.ValueMember = "ProductModelId";	
			this.uxProductModelIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductModelIdDataGridViewColumn.DataSource = uxProductModelIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductModelProductDescriptionCultureDataGridView);
			this.Name = "ProductModelProductDescriptionCultureDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxCultureIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxProductDescriptionIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxProductModelIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelProductDescriptionCultureErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelProductDescriptionCultureDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelProductDescriptionCultureBindingSource)).EndInit();
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
				ProductModelProductDescriptionCultureDataGridViewEventArgs args = new ProductModelProductDescriptionCultureDataGridViewEventArgs();
				args.ProductModelProductDescriptionCulture = _currentProductModelProductDescriptionCulture;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductModelProductDescriptionCultureDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductModelProductDescriptionCulture	_ProductModelProductDescriptionCulture;
	
			/// <summary>
			/// the  Entities.ProductModelProductDescriptionCulture instance.
			/// </summary>
			public Entities.ProductModelProductDescriptionCulture ProductModelProductDescriptionCulture
			{
				get { return _ProductModelProductDescriptionCulture; }
				set { _ProductModelProductDescriptionCulture = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductModelProductDescriptionCultureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelProductDescriptionCultureDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductModelProductDescriptionCultureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelProductDescriptionCultureDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductModelProductDescriptionCultureDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductModelIdDataGridViewColumn":
						e.Value = ProductModelProductDescriptionCultureList[e.RowIndex].ProductModelId;
						break;
					case "uxProductDescriptionIdDataGridViewColumn":
						e.Value = ProductModelProductDescriptionCultureList[e.RowIndex].ProductDescriptionId;
						break;
					case "uxCultureIdDataGridViewColumn":
						e.Value = ProductModelProductDescriptionCultureList[e.RowIndex].CultureId;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductModelProductDescriptionCultureList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductModelProductDescriptionCultureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelProductDescriptionCultureDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductModelProductDescriptionCultureDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductModelIdDataGridViewColumn":
						ProductModelProductDescriptionCultureList[e.RowIndex].ProductModelId = (System.Int32)e.Value;
						break;
					case "uxProductDescriptionIdDataGridViewColumn":
						ProductModelProductDescriptionCultureList[e.RowIndex].ProductDescriptionId = (System.Int32)e.Value;
						break;
					case "uxCultureIdDataGridViewColumn":
						ProductModelProductDescriptionCultureList[e.RowIndex].CultureId = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductModelProductDescriptionCultureList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
