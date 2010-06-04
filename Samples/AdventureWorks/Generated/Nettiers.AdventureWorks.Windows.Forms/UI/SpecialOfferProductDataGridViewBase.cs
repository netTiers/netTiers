
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SpecialOfferProduct typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SpecialOfferProductDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SpecialOfferProductDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SpecialOfferProduct _currentSpecialOfferProduct = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSpecialOfferProductDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSpecialOfferProductErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSpecialOfferProductBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the SpecialOfferId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSpecialOfferIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.SpecialOffer> _SpecialOfferIdList;
		
		/// <summary> 
		/// The list of selectable SpecialOffer
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SpecialOffer> SpecialOfferIdList
		{
			get {return this._SpecialOfferIdList;}
			set 
			{
				this._SpecialOfferIdList = value;
				this.uxSpecialOfferIdDataGridViewColumn.DataSource = null;
				this.uxSpecialOfferIdDataGridViewColumn.DataSource = this._SpecialOfferIdList;
			}
		}
		
		private bool _allowNewItemInSpecialOfferIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of SpecialOffer
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSpecialOfferIdList
		{
			get { return _allowNewItemInSpecialOfferIdList;}
			set
			{
				this._allowNewItemInSpecialOfferIdList = value;
				this.uxSpecialOfferIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SpecialOfferProduct> _SpecialOfferProductList;
				
		/// <summary> 
		/// The list of SpecialOfferProduct to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SpecialOfferProduct> SpecialOfferProductList
		{
			get {return this._SpecialOfferProductList;}
			set
			{
				this._SpecialOfferProductList = value;
				this.uxSpecialOfferProductBindingSource.DataSource = null;
				this.uxSpecialOfferProductBindingSource.DataSource = value;
				this.uxSpecialOfferProductDataGridView.DataSource = null;
				this.uxSpecialOfferProductDataGridView.DataSource = this.uxSpecialOfferProductBindingSource;				
				//this.uxSpecialOfferProductBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSpecialOfferProductBindingSource_ListChanged);
				this.uxSpecialOfferProductBindingSource.CurrentItemChanged += new System.EventHandler(OnSpecialOfferProductBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSpecialOfferProductBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSpecialOfferProduct = uxSpecialOfferProductBindingSource.Current as Entities.SpecialOfferProduct;
			
			if (_currentSpecialOfferProduct != null)
			{
				_currentSpecialOfferProduct.Validate();
			}
			//_SpecialOfferProduct.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSpecialOfferProductBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SpecialOfferProduct"/> instance.
		/// </summary>
		public Entities.SpecialOfferProduct SelectedSpecialOfferProduct
		{
			get {return this._currentSpecialOfferProduct;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSpecialOfferProductDataGridView.VirtualMode;}
			set
			{
				this.uxSpecialOfferProductDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSpecialOfferProductDataGridView.AllowUserToAddRows;}
			set {this.uxSpecialOfferProductDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSpecialOfferProductDataGridView.AllowUserToDeleteRows;}
			set {this.uxSpecialOfferProductDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSpecialOfferProductDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSpecialOfferProductDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SpecialOfferProductDataGridViewBase"/> class.
		/// </summary>
		public SpecialOfferProductDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSpecialOfferProductDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSpecialOfferProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSpecialOfferProductErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSpecialOfferIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			//this.uxSpecialOfferIdBindingSource = new SpecialOfferBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferProductDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferProductBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferProductErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSpecialOfferProductErrorProvider
			// 
			this.uxSpecialOfferProductErrorProvider.ContainerControl = this;
			this.uxSpecialOfferProductErrorProvider.DataSource = this.uxSpecialOfferProductBindingSource;						
			// 
			// uxSpecialOfferProductDataGridView
			// 
			this.uxSpecialOfferProductDataGridView.AutoGenerateColumns = false;
			this.uxSpecialOfferProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSpecialOfferProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSpecialOfferIdDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSpecialOfferProductDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSpecialOfferProductDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSpecialOfferProductDataGridView.Name = "uxSpecialOfferProductDataGridView";
			this.uxSpecialOfferProductDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSpecialOfferProductDataGridView.TabIndex = 0;	
			this.uxSpecialOfferProductDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSpecialOfferProductDataGridView.EnableHeadersVisualStyles = false;
			this.uxSpecialOfferProductDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSpecialOfferProductDataGridViewDataError);
			this.uxSpecialOfferProductDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSpecialOfferProductDataGridViewCellValueNeeded);
			this.uxSpecialOfferProductDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSpecialOfferProductDataGridViewCellValuePushed);
			
			//
			// uxSpecialOfferIdDataGridViewColumn
			//
			this.uxSpecialOfferIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSpecialOfferIdDataGridViewColumn.DataPropertyName = "SpecialOfferId";
			this.uxSpecialOfferIdDataGridViewColumn.HeaderText = "SpecialOfferId";
			this.uxSpecialOfferIdDataGridViewColumn.Name = "uxSpecialOfferIdDataGridViewColumn";
			this.uxSpecialOfferIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSpecialOfferIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSpecialOfferIdDataGridViewColumn.ReadOnly = false;		
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
			// uxProductIdDataGridViewColumn
			//				
			this.uxProductIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductIdDataGridViewColumn.ValueMember = "ProductId";	
			this.uxProductIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductIdDataGridViewColumn.DataSource = uxProductIdBindingSource;				
				
			//
			// uxSpecialOfferIdDataGridViewColumn
			//				
			this.uxSpecialOfferIdDataGridViewColumn.DisplayMember = "Description";	
			this.uxSpecialOfferIdDataGridViewColumn.ValueMember = "SpecialOfferId";	
			this.uxSpecialOfferIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSpecialOfferIdDataGridViewColumn.DataSource = uxSpecialOfferIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxSpecialOfferProductDataGridView);
			this.Name = "SpecialOfferProductDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferProductErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferProductDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferProductBindingSource)).EndInit();
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
				SpecialOfferProductDataGridViewEventArgs args = new SpecialOfferProductDataGridViewEventArgs();
				args.SpecialOfferProduct = _currentSpecialOfferProduct;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SpecialOfferProductDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SpecialOfferProduct	_SpecialOfferProduct;
	
			/// <summary>
			/// the  Entities.SpecialOfferProduct instance.
			/// </summary>
			public Entities.SpecialOfferProduct SpecialOfferProduct
			{
				get { return _SpecialOfferProduct; }
				set { _SpecialOfferProduct = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSpecialOfferProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSpecialOfferProductDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSpecialOfferProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSpecialOfferProductDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSpecialOfferProductDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSpecialOfferIdDataGridViewColumn":
						e.Value = SpecialOfferProductList[e.RowIndex].SpecialOfferId;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = SpecialOfferProductList[e.RowIndex].ProductId;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SpecialOfferProductList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SpecialOfferProductList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSpecialOfferProductDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSpecialOfferProductDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSpecialOfferProductDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSpecialOfferIdDataGridViewColumn":
						SpecialOfferProductList[e.RowIndex].SpecialOfferId = (System.Int32)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						SpecialOfferProductList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SpecialOfferProductList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SpecialOfferProductList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
