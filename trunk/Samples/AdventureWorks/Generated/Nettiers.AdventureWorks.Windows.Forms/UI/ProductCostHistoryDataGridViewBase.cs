
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductCostHistory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductCostHistoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductCostHistoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductCostHistory _currentProductCostHistory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductCostHistoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductCostHistoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductCostHistoryBindingSource;
		
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
		/// the DGV column associated with the StandardCost property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStandardCostDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.ProductCostHistory> _ProductCostHistoryList;
				
		/// <summary> 
		/// The list of ProductCostHistory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductCostHistory> ProductCostHistoryList
		{
			get {return this._ProductCostHistoryList;}
			set
			{
				this._ProductCostHistoryList = value;
				this.uxProductCostHistoryBindingSource.DataSource = null;
				this.uxProductCostHistoryBindingSource.DataSource = value;
				this.uxProductCostHistoryDataGridView.DataSource = null;
				this.uxProductCostHistoryDataGridView.DataSource = this.uxProductCostHistoryBindingSource;				
				//this.uxProductCostHistoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductCostHistoryBindingSource_ListChanged);
				this.uxProductCostHistoryBindingSource.CurrentItemChanged += new System.EventHandler(OnProductCostHistoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductCostHistoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductCostHistory = uxProductCostHistoryBindingSource.Current as Entities.ProductCostHistory;
			
			if (_currentProductCostHistory != null)
			{
				_currentProductCostHistory.Validate();
			}
			//_ProductCostHistory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductCostHistoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductCostHistory"/> instance.
		/// </summary>
		public Entities.ProductCostHistory SelectedProductCostHistory
		{
			get {return this._currentProductCostHistory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductCostHistoryDataGridView.VirtualMode;}
			set
			{
				this.uxProductCostHistoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductCostHistoryDataGridView.AllowUserToAddRows;}
			set {this.uxProductCostHistoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductCostHistoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductCostHistoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductCostHistoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductCostHistoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductCostHistoryDataGridViewBase"/> class.
		/// </summary>
		public ProductCostHistoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductCostHistoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductCostHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductCostHistoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStandardCostDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCostHistoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCostHistoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCostHistoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductCostHistoryErrorProvider
			// 
			this.uxProductCostHistoryErrorProvider.ContainerControl = this;
			this.uxProductCostHistoryErrorProvider.DataSource = this.uxProductCostHistoryBindingSource;						
			// 
			// uxProductCostHistoryDataGridView
			// 
			this.uxProductCostHistoryDataGridView.AutoGenerateColumns = false;
			this.uxProductCostHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductCostHistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductIdDataGridViewColumn,
		this.uxStartDateDataGridViewColumn,
		this.uxEndDateDataGridViewColumn,
		this.uxStandardCostDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductCostHistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductCostHistoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductCostHistoryDataGridView.Name = "uxProductCostHistoryDataGridView";
			this.uxProductCostHistoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductCostHistoryDataGridView.TabIndex = 0;	
			this.uxProductCostHistoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductCostHistoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductCostHistoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductCostHistoryDataGridViewDataError);
			this.uxProductCostHistoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductCostHistoryDataGridViewCellValueNeeded);
			this.uxProductCostHistoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductCostHistoryDataGridViewCellValuePushed);
			
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
			// uxStandardCostDataGridViewColumn
			//
			this.uxStandardCostDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStandardCostDataGridViewColumn.DataPropertyName = "StandardCost";
			this.uxStandardCostDataGridViewColumn.HeaderText = "StandardCost";
			this.uxStandardCostDataGridViewColumn.Name = "uxStandardCostDataGridViewColumn";
			this.uxStandardCostDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStandardCostDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStandardCostDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxProductCostHistoryDataGridView);
			this.Name = "ProductCostHistoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCostHistoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCostHistoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductCostHistoryBindingSource)).EndInit();
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
				ProductCostHistoryDataGridViewEventArgs args = new ProductCostHistoryDataGridViewEventArgs();
				args.ProductCostHistory = _currentProductCostHistory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductCostHistoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductCostHistory	_ProductCostHistory;
	
			/// <summary>
			/// the  Entities.ProductCostHistory instance.
			/// </summary>
			public Entities.ProductCostHistory ProductCostHistory
			{
				get { return _ProductCostHistory; }
				set { _ProductCostHistory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductCostHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductCostHistoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductCostHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductCostHistoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductCostHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						e.Value = ProductCostHistoryList[e.RowIndex].ProductId;
						break;
					case "uxStartDateDataGridViewColumn":
						e.Value = ProductCostHistoryList[e.RowIndex].StartDate;
						break;
					case "uxEndDateDataGridViewColumn":
						e.Value = ProductCostHistoryList[e.RowIndex].EndDate;
						break;
					case "uxStandardCostDataGridViewColumn":
						e.Value = ProductCostHistoryList[e.RowIndex].StandardCost;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductCostHistoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductCostHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductCostHistoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductCostHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductIdDataGridViewColumn":
						ProductCostHistoryList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxStartDateDataGridViewColumn":
						ProductCostHistoryList[e.RowIndex].StartDate = (System.DateTime)e.Value;
						break;
					case "uxEndDateDataGridViewColumn":
						ProductCostHistoryList[e.RowIndex].EndDate = (System.DateTime?)e.Value;
						break;
					case "uxStandardCostDataGridViewColumn":
						ProductCostHistoryList[e.RowIndex].StandardCost = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductCostHistoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
