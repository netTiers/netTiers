
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ShoppingCartItem typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ShoppingCartItemDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ShoppingCartItemDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ShoppingCartItem _currentShoppingCartItem = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxShoppingCartItemDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxShoppingCartItemErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxShoppingCartItemBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ShoppingCartItemId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShoppingCartItemIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ShoppingCartId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShoppingCartIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Quantity property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxQuantityDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DateCreated property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDateCreatedDataGridViewColumn;
		
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ShoppingCartItem> _ShoppingCartItemList;
				
		/// <summary> 
		/// The list of ShoppingCartItem to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ShoppingCartItem> ShoppingCartItemList
		{
			get {return this._ShoppingCartItemList;}
			set
			{
				this._ShoppingCartItemList = value;
				this.uxShoppingCartItemBindingSource.DataSource = null;
				this.uxShoppingCartItemBindingSource.DataSource = value;
				this.uxShoppingCartItemDataGridView.DataSource = null;
				this.uxShoppingCartItemDataGridView.DataSource = this.uxShoppingCartItemBindingSource;				
				//this.uxShoppingCartItemBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxShoppingCartItemBindingSource_ListChanged);
				this.uxShoppingCartItemBindingSource.CurrentItemChanged += new System.EventHandler(OnShoppingCartItemBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnShoppingCartItemBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentShoppingCartItem = uxShoppingCartItemBindingSource.Current as Entities.ShoppingCartItem;
			
			if (_currentShoppingCartItem != null)
			{
				_currentShoppingCartItem.Validate();
			}
			//_ShoppingCartItem.Validate();
			OnCurrentEntityChanged();
		}

		//void uxShoppingCartItemBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ShoppingCartItem"/> instance.
		/// </summary>
		public Entities.ShoppingCartItem SelectedShoppingCartItem
		{
			get {return this._currentShoppingCartItem;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxShoppingCartItemDataGridView.VirtualMode;}
			set
			{
				this.uxShoppingCartItemDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxShoppingCartItemDataGridView.AllowUserToAddRows;}
			set {this.uxShoppingCartItemDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxShoppingCartItemDataGridView.AllowUserToDeleteRows;}
			set {this.uxShoppingCartItemDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxShoppingCartItemDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxShoppingCartItemDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ShoppingCartItemDataGridViewBase"/> class.
		/// </summary>
		public ShoppingCartItemDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxShoppingCartItemDataGridView = new System.Windows.Forms.DataGridView();
			this.uxShoppingCartItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxShoppingCartItemErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxShoppingCartItemIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxShoppingCartIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxQuantityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxDateCreatedDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShoppingCartItemDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShoppingCartItemBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShoppingCartItemErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxShoppingCartItemErrorProvider
			// 
			this.uxShoppingCartItemErrorProvider.ContainerControl = this;
			this.uxShoppingCartItemErrorProvider.DataSource = this.uxShoppingCartItemBindingSource;						
			// 
			// uxShoppingCartItemDataGridView
			// 
			this.uxShoppingCartItemDataGridView.AutoGenerateColumns = false;
			this.uxShoppingCartItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxShoppingCartItemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxShoppingCartItemIdDataGridViewColumn,
		this.uxShoppingCartIdDataGridViewColumn,
		this.uxQuantityDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxDateCreatedDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxShoppingCartItemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxShoppingCartItemDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxShoppingCartItemDataGridView.Name = "uxShoppingCartItemDataGridView";
			this.uxShoppingCartItemDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxShoppingCartItemDataGridView.TabIndex = 0;	
			this.uxShoppingCartItemDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxShoppingCartItemDataGridView.EnableHeadersVisualStyles = false;
			this.uxShoppingCartItemDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnShoppingCartItemDataGridViewDataError);
			this.uxShoppingCartItemDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnShoppingCartItemDataGridViewCellValueNeeded);
			this.uxShoppingCartItemDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnShoppingCartItemDataGridViewCellValuePushed);
			
			//
			// uxShoppingCartItemIdDataGridViewColumn
			//
			this.uxShoppingCartItemIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShoppingCartItemIdDataGridViewColumn.DataPropertyName = "ShoppingCartItemId";
			this.uxShoppingCartItemIdDataGridViewColumn.HeaderText = "ShoppingCartItemId";
			this.uxShoppingCartItemIdDataGridViewColumn.Name = "uxShoppingCartItemIdDataGridViewColumn";
			this.uxShoppingCartItemIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShoppingCartItemIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShoppingCartItemIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxShoppingCartIdDataGridViewColumn
			//
			this.uxShoppingCartIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShoppingCartIdDataGridViewColumn.DataPropertyName = "ShoppingCartId";
			this.uxShoppingCartIdDataGridViewColumn.HeaderText = "ShoppingCartId";
			this.uxShoppingCartIdDataGridViewColumn.Name = "uxShoppingCartIdDataGridViewColumn";
			this.uxShoppingCartIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShoppingCartIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShoppingCartIdDataGridViewColumn.ReadOnly = false;		
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
			// uxDateCreatedDataGridViewColumn
			//
			this.uxDateCreatedDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDateCreatedDataGridViewColumn.DataPropertyName = "DateCreated";
			this.uxDateCreatedDataGridViewColumn.HeaderText = "DateCreated";
			this.uxDateCreatedDataGridViewColumn.Name = "uxDateCreatedDataGridViewColumn";
			this.uxDateCreatedDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDateCreatedDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDateCreatedDataGridViewColumn.ReadOnly = false;		
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
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxShoppingCartItemDataGridView);
			this.Name = "ShoppingCartItemDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShoppingCartItemErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShoppingCartItemDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShoppingCartItemBindingSource)).EndInit();
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
				ShoppingCartItemDataGridViewEventArgs args = new ShoppingCartItemDataGridViewEventArgs();
				args.ShoppingCartItem = _currentShoppingCartItem;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ShoppingCartItemDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ShoppingCartItem	_ShoppingCartItem;
	
			/// <summary>
			/// the  Entities.ShoppingCartItem instance.
			/// </summary>
			public Entities.ShoppingCartItem ShoppingCartItem
			{
				get { return _ShoppingCartItem; }
				set { _ShoppingCartItem = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxShoppingCartItemDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnShoppingCartItemDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxShoppingCartItemDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnShoppingCartItemDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxShoppingCartItemDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxShoppingCartItemIdDataGridViewColumn":
						e.Value = ShoppingCartItemList[e.RowIndex].ShoppingCartItemId;
						break;
					case "uxShoppingCartIdDataGridViewColumn":
						e.Value = ShoppingCartItemList[e.RowIndex].ShoppingCartId;
						break;
					case "uxQuantityDataGridViewColumn":
						e.Value = ShoppingCartItemList[e.RowIndex].Quantity;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = ShoppingCartItemList[e.RowIndex].ProductId;
						break;
					case "uxDateCreatedDataGridViewColumn":
						e.Value = ShoppingCartItemList[e.RowIndex].DateCreated;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ShoppingCartItemList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxShoppingCartItemDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnShoppingCartItemDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxShoppingCartItemDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxShoppingCartItemIdDataGridViewColumn":
						ShoppingCartItemList[e.RowIndex].ShoppingCartItemId = (System.Int32)e.Value;
						break;
					case "uxShoppingCartIdDataGridViewColumn":
						ShoppingCartItemList[e.RowIndex].ShoppingCartId = (System.String)e.Value;
						break;
					case "uxQuantityDataGridViewColumn":
						ShoppingCartItemList[e.RowIndex].Quantity = (System.Int32)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						ShoppingCartItemList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxDateCreatedDataGridViewColumn":
						ShoppingCartItemList[e.RowIndex].DateCreated = (System.DateTime)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ShoppingCartItemList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
