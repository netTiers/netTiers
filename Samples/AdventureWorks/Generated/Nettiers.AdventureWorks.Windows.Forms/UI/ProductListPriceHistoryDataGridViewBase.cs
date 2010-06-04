
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductListPriceHistory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductListPriceHistoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductListPriceHistoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductListPriceHistory _currentProductListPriceHistory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductListPriceHistoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductListPriceHistoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductListPriceHistoryBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEndDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ListPrice property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxListPriceDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.ProductListPriceHistory> _ProductListPriceHistoryList;
				
		/// <summary> 
		/// The list of ProductListPriceHistory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductListPriceHistory> ProductListPriceHistoryList
		{
			get {return this._ProductListPriceHistoryList;}
			set
			{
				this._ProductListPriceHistoryList = value;
				this.uxProductListPriceHistoryBindingSource.DataSource = null;
				this.uxProductListPriceHistoryBindingSource.DataSource = value;
				this.uxProductListPriceHistoryDataGridView.DataSource = null;
				this.uxProductListPriceHistoryDataGridView.DataSource = this.uxProductListPriceHistoryBindingSource;				
				//this.uxProductListPriceHistoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductListPriceHistoryBindingSource_ListChanged);
				this.uxProductListPriceHistoryBindingSource.CurrentItemChanged += new System.EventHandler(OnProductListPriceHistoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductListPriceHistoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductListPriceHistory = uxProductListPriceHistoryBindingSource.Current as Entities.ProductListPriceHistory;
			
			if (_currentProductListPriceHistory != null)
			{
				_currentProductListPriceHistory.Validate();
			}
			//_ProductListPriceHistory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductListPriceHistoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductListPriceHistory"/> instance.
		/// </summary>
		public Entities.ProductListPriceHistory SelectedProductListPriceHistory
		{
			get {return this._currentProductListPriceHistory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductListPriceHistoryDataGridView.VirtualMode;}
			set
			{
				this.uxProductListPriceHistoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductListPriceHistoryDataGridView.AllowUserToAddRows;}
			set {this.uxProductListPriceHistoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductListPriceHistoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductListPriceHistoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductListPriceHistoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductListPriceHistoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductListPriceHistoryDataGridViewBase"/> class.
		/// </summary>
		public ProductListPriceHistoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductListPriceHistoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductListPriceHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductListPriceHistoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxListPriceDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductListPriceHistoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductListPriceHistoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductListPriceHistoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductListPriceHistoryErrorProvider
			// 
			this.uxProductListPriceHistoryErrorProvider.ContainerControl = this;
			this.uxProductListPriceHistoryErrorProvider.DataSource = this.uxProductListPriceHistoryBindingSource;						
			// 
			// uxProductListPriceHistoryDataGridView
			// 
			this.uxProductListPriceHistoryDataGridView.AutoGenerateColumns = false;
			this.uxProductListPriceHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductListPriceHistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductIdDataGridViewColumn,
		this.uxStartDateDataGridViewColumn,
		this.uxEndDateDataGridViewColumn,
		this.uxListPriceDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductListPriceHistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductListPriceHistoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductListPriceHistoryDataGridView.Name = "uxProductListPriceHistoryDataGridView";
			this.uxProductListPriceHistoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductListPriceHistoryDataGridView.TabIndex = 0;	
			this.uxProductListPriceHistoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductListPriceHistoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductListPriceHistoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductListPriceHistoryDataGridViewDataError);
			this.uxProductListPriceHistoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductListPriceHistoryDataGridViewCellValueNeeded);
			this.uxProductListPriceHistoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductListPriceHistoryDataGridViewCellValuePushed);
			
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
			// uxStartDateDataGridViewColumn
			//
			this.uxStartDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStartDateDataGridViewColumn.DataPropertyName = "StartDate";
			this.uxStartDateDataGridViewColumn.HeaderText = "StartDate";
			this.uxStartDateDataGridViewColumn.Name = "uxStartDateDataGridViewColumn";
			this.uxStartDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStartDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStartDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxEndDateDataGridViewColumn
			//
			this.uxEndDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEndDateDataGridViewColumn.DataPropertyName = "EndDate";
			this.uxEndDateDataGridViewColumn.HeaderText = "EndDate";
			this.uxEndDateDataGridViewColumn.Name = "uxEndDateDataGridViewColumn";
			this.uxEndDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEndDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEndDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxListPriceDataGridViewColumn
			//
			this.uxListPriceDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxListPriceDataGridViewColumn.DataPropertyName = "ListPrice";
			this.uxListPriceDataGridViewColumn.HeaderText = "ListPrice";
			this.uxListPriceDataGridViewColumn.Name = "uxListPriceDataGridViewColumn";
			this.uxListPriceDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxListPriceDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxListPriceDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxProductListPriceHistoryDataGridView);
			this.Name = "ProductListPriceHistoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductListPriceHistoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductListPriceHistoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductListPriceHistoryBindingSource)).EndInit();
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
				ProductListPriceHistoryDataGridViewEventArgs args = new ProductListPriceHistoryDataGridViewEventArgs();
				args.ProductListPriceHistory = _currentProductListPriceHistory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductListPriceHistoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductListPriceHistory	_ProductListPriceHistory;
	
			/// <summary>
			/// the  Entities.ProductListPriceHistory instance.
			/// </summary>
			public Entities.ProductListPriceHistory ProductListPriceHistory
			{
				get { return _ProductListPriceHistory; }
				set { _ProductListPriceHistory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductListPriceHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductListPriceHistoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductListPriceHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductListPriceHistoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductListPriceHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						e.Value = ProductListPriceHistoryList[e.RowIndex].ProductId;
						break;
					case "uxStartDateDataGridViewColumn":
						e.Value = ProductListPriceHistoryList[e.RowIndex].StartDate;
						break;
					case "uxEndDateDataGridViewColumn":
						e.Value = ProductListPriceHistoryList[e.RowIndex].EndDate;
						break;
					case "uxListPriceDataGridViewColumn":
						e.Value = ProductListPriceHistoryList[e.RowIndex].ListPrice;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductListPriceHistoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductListPriceHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductListPriceHistoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductListPriceHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						ProductListPriceHistoryList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxStartDateDataGridViewColumn":
						ProductListPriceHistoryList[e.RowIndex].StartDate = (System.DateTime)e.Value;
						break;
					case "uxEndDateDataGridViewColumn":
						ProductListPriceHistoryList[e.RowIndex].EndDate = (System.DateTime?)e.Value;
						break;
					case "uxListPriceDataGridViewColumn":
						ProductListPriceHistoryList[e.RowIndex].ListPrice = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductListPriceHistoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
