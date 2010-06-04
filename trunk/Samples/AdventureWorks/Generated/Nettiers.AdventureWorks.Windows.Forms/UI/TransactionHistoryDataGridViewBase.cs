
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TransactionHistory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TransactionHistoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TransactionHistoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TransactionHistory _currentTransactionHistory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTransactionHistoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTransactionHistoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTransactionHistoryBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the TransactionId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTransactionIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ReferenceOrderId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxReferenceOrderIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ReferenceOrderLineId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxReferenceOrderLineIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TransactionDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTransactionDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TransactionType property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTransactionTypeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Quantity property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxQuantityDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ActualCost property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxActualCostDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.TransactionHistory> _TransactionHistoryList;
				
		/// <summary> 
		/// The list of TransactionHistory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TransactionHistory> TransactionHistoryList
		{
			get {return this._TransactionHistoryList;}
			set
			{
				this._TransactionHistoryList = value;
				this.uxTransactionHistoryBindingSource.DataSource = null;
				this.uxTransactionHistoryBindingSource.DataSource = value;
				this.uxTransactionHistoryDataGridView.DataSource = null;
				this.uxTransactionHistoryDataGridView.DataSource = this.uxTransactionHistoryBindingSource;				
				//this.uxTransactionHistoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTransactionHistoryBindingSource_ListChanged);
				this.uxTransactionHistoryBindingSource.CurrentItemChanged += new System.EventHandler(OnTransactionHistoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTransactionHistoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTransactionHistory = uxTransactionHistoryBindingSource.Current as Entities.TransactionHistory;
			
			if (_currentTransactionHistory != null)
			{
				_currentTransactionHistory.Validate();
			}
			//_TransactionHistory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTransactionHistoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.TransactionHistory"/> instance.
		/// </summary>
		public Entities.TransactionHistory SelectedTransactionHistory
		{
			get {return this._currentTransactionHistory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTransactionHistoryDataGridView.VirtualMode;}
			set
			{
				this.uxTransactionHistoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTransactionHistoryDataGridView.AllowUserToAddRows;}
			set {this.uxTransactionHistoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTransactionHistoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxTransactionHistoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTransactionHistoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTransactionHistoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TransactionHistoryDataGridViewBase"/> class.
		/// </summary>
		public TransactionHistoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTransactionHistoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTransactionHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTransactionHistoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTransactionIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxReferenceOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxReferenceOrderLineIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTransactionDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTransactionTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxQuantityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxActualCostDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTransactionHistoryErrorProvider
			// 
			this.uxTransactionHistoryErrorProvider.ContainerControl = this;
			this.uxTransactionHistoryErrorProvider.DataSource = this.uxTransactionHistoryBindingSource;						
			// 
			// uxTransactionHistoryDataGridView
			// 
			this.uxTransactionHistoryDataGridView.AutoGenerateColumns = false;
			this.uxTransactionHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTransactionHistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTransactionIdDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxReferenceOrderIdDataGridViewColumn,
		this.uxReferenceOrderLineIdDataGridViewColumn,
		this.uxTransactionDateDataGridViewColumn,
		this.uxTransactionTypeDataGridViewColumn,
		this.uxQuantityDataGridViewColumn,
		this.uxActualCostDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxTransactionHistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTransactionHistoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTransactionHistoryDataGridView.Name = "uxTransactionHistoryDataGridView";
			this.uxTransactionHistoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTransactionHistoryDataGridView.TabIndex = 0;	
			this.uxTransactionHistoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTransactionHistoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxTransactionHistoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTransactionHistoryDataGridViewDataError);
			this.uxTransactionHistoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTransactionHistoryDataGridViewCellValueNeeded);
			this.uxTransactionHistoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTransactionHistoryDataGridViewCellValuePushed);
			
			//
			// uxTransactionIdDataGridViewColumn
			//
			this.uxTransactionIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTransactionIdDataGridViewColumn.DataPropertyName = "TransactionId";
			this.uxTransactionIdDataGridViewColumn.HeaderText = "TransactionId";
			this.uxTransactionIdDataGridViewColumn.Name = "uxTransactionIdDataGridViewColumn";
			this.uxTransactionIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTransactionIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTransactionIdDataGridViewColumn.ReadOnly = true;		
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
			// uxReferenceOrderIdDataGridViewColumn
			//
			this.uxReferenceOrderIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxReferenceOrderIdDataGridViewColumn.DataPropertyName = "ReferenceOrderId";
			this.uxReferenceOrderIdDataGridViewColumn.HeaderText = "ReferenceOrderId";
			this.uxReferenceOrderIdDataGridViewColumn.Name = "uxReferenceOrderIdDataGridViewColumn";
			this.uxReferenceOrderIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxReferenceOrderIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxReferenceOrderIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxReferenceOrderLineIdDataGridViewColumn
			//
			this.uxReferenceOrderLineIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxReferenceOrderLineIdDataGridViewColumn.DataPropertyName = "ReferenceOrderLineId";
			this.uxReferenceOrderLineIdDataGridViewColumn.HeaderText = "ReferenceOrderLineId";
			this.uxReferenceOrderLineIdDataGridViewColumn.Name = "uxReferenceOrderLineIdDataGridViewColumn";
			this.uxReferenceOrderLineIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxReferenceOrderLineIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxReferenceOrderLineIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxTransactionDateDataGridViewColumn
			//
			this.uxTransactionDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTransactionDateDataGridViewColumn.DataPropertyName = "TransactionDate";
			this.uxTransactionDateDataGridViewColumn.HeaderText = "TransactionDate";
			this.uxTransactionDateDataGridViewColumn.Name = "uxTransactionDateDataGridViewColumn";
			this.uxTransactionDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTransactionDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTransactionDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxTransactionTypeDataGridViewColumn
			//
			this.uxTransactionTypeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTransactionTypeDataGridViewColumn.DataPropertyName = "TransactionType";
			this.uxTransactionTypeDataGridViewColumn.HeaderText = "TransactionType";
			this.uxTransactionTypeDataGridViewColumn.Name = "uxTransactionTypeDataGridViewColumn";
			this.uxTransactionTypeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTransactionTypeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTransactionTypeDataGridViewColumn.ReadOnly = false;		
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
			// uxActualCostDataGridViewColumn
			//
			this.uxActualCostDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxActualCostDataGridViewColumn.DataPropertyName = "ActualCost";
			this.uxActualCostDataGridViewColumn.HeaderText = "ActualCost";
			this.uxActualCostDataGridViewColumn.Name = "uxActualCostDataGridViewColumn";
			this.uxActualCostDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxActualCostDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxActualCostDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxTransactionHistoryDataGridView);
			this.Name = "TransactionHistoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryBindingSource)).EndInit();
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
				TransactionHistoryDataGridViewEventArgs args = new TransactionHistoryDataGridViewEventArgs();
				args.TransactionHistory = _currentTransactionHistory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TransactionHistoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TransactionHistory	_TransactionHistory;
	
			/// <summary>
			/// the  Entities.TransactionHistory instance.
			/// </summary>
			public Entities.TransactionHistory TransactionHistory
			{
				get { return _TransactionHistory; }
				set { _TransactionHistory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTransactionHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTransactionHistoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTransactionHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTransactionHistoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTransactionHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTransactionIdDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].TransactionId;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].ProductId;
						break;
					case "uxReferenceOrderIdDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].ReferenceOrderId;
						break;
					case "uxReferenceOrderLineIdDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].ReferenceOrderLineId;
						break;
					case "uxTransactionDateDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].TransactionDate;
						break;
					case "uxTransactionTypeDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].TransactionType;
						break;
					case "uxQuantityDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].Quantity;
						break;
					case "uxActualCostDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].ActualCost;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = TransactionHistoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTransactionHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTransactionHistoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTransactionHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTransactionIdDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].TransactionId = (System.Int32)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxReferenceOrderIdDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].ReferenceOrderId = (System.Int32)e.Value;
						break;
					case "uxReferenceOrderLineIdDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].ReferenceOrderLineId = (System.Int32)e.Value;
						break;
					case "uxTransactionDateDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].TransactionDate = (System.DateTime)e.Value;
						break;
					case "uxTransactionTypeDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].TransactionType = (System.String)e.Value;
						break;
					case "uxQuantityDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].Quantity = (System.Int32)e.Value;
						break;
					case "uxActualCostDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].ActualCost = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						TransactionHistoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
