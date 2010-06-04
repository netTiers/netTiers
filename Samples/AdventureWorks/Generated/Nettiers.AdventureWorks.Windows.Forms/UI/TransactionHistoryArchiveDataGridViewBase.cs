
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TransactionHistoryArchive typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TransactionHistoryArchiveDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TransactionHistoryArchiveDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TransactionHistoryArchive _currentTransactionHistoryArchive = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTransactionHistoryArchiveDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTransactionHistoryArchiveErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTransactionHistoryArchiveBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the TransactionId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTransactionIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductIdDataGridViewColumn;
		
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
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.TransactionHistoryArchive> _TransactionHistoryArchiveList;
				
		/// <summary> 
		/// The list of TransactionHistoryArchive to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TransactionHistoryArchive> TransactionHistoryArchiveList
		{
			get {return this._TransactionHistoryArchiveList;}
			set
			{
				this._TransactionHistoryArchiveList = value;
				this.uxTransactionHistoryArchiveBindingSource.DataSource = null;
				this.uxTransactionHistoryArchiveBindingSource.DataSource = value;
				this.uxTransactionHistoryArchiveDataGridView.DataSource = null;
				this.uxTransactionHistoryArchiveDataGridView.DataSource = this.uxTransactionHistoryArchiveBindingSource;				
				//this.uxTransactionHistoryArchiveBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTransactionHistoryArchiveBindingSource_ListChanged);
				this.uxTransactionHistoryArchiveBindingSource.CurrentItemChanged += new System.EventHandler(OnTransactionHistoryArchiveBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTransactionHistoryArchiveBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTransactionHistoryArchive = uxTransactionHistoryArchiveBindingSource.Current as Entities.TransactionHistoryArchive;
			
			if (_currentTransactionHistoryArchive != null)
			{
				_currentTransactionHistoryArchive.Validate();
			}
			//_TransactionHistoryArchive.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTransactionHistoryArchiveBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.TransactionHistoryArchive"/> instance.
		/// </summary>
		public Entities.TransactionHistoryArchive SelectedTransactionHistoryArchive
		{
			get {return this._currentTransactionHistoryArchive;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTransactionHistoryArchiveDataGridView.VirtualMode;}
			set
			{
				this.uxTransactionHistoryArchiveDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTransactionHistoryArchiveDataGridView.AllowUserToAddRows;}
			set {this.uxTransactionHistoryArchiveDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTransactionHistoryArchiveDataGridView.AllowUserToDeleteRows;}
			set {this.uxTransactionHistoryArchiveDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTransactionHistoryArchiveDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTransactionHistoryArchiveDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TransactionHistoryArchiveDataGridViewBase"/> class.
		/// </summary>
		public TransactionHistoryArchiveDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTransactionHistoryArchiveDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTransactionHistoryArchiveBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTransactionHistoryArchiveErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTransactionIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxReferenceOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxReferenceOrderLineIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTransactionDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTransactionTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxQuantityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxActualCostDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryArchiveDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryArchiveBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryArchiveErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTransactionHistoryArchiveErrorProvider
			// 
			this.uxTransactionHistoryArchiveErrorProvider.ContainerControl = this;
			this.uxTransactionHistoryArchiveErrorProvider.DataSource = this.uxTransactionHistoryArchiveBindingSource;						
			// 
			// uxTransactionHistoryArchiveDataGridView
			// 
			this.uxTransactionHistoryArchiveDataGridView.AutoGenerateColumns = false;
			this.uxTransactionHistoryArchiveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTransactionHistoryArchiveDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTransactionIdDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxReferenceOrderIdDataGridViewColumn,
		this.uxReferenceOrderLineIdDataGridViewColumn,
		this.uxTransactionDateDataGridViewColumn,
		this.uxTransactionTypeDataGridViewColumn,
		this.uxQuantityDataGridViewColumn,
		this.uxActualCostDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxTransactionHistoryArchiveDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTransactionHistoryArchiveDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTransactionHistoryArchiveDataGridView.Name = "uxTransactionHistoryArchiveDataGridView";
			this.uxTransactionHistoryArchiveDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTransactionHistoryArchiveDataGridView.TabIndex = 0;	
			this.uxTransactionHistoryArchiveDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTransactionHistoryArchiveDataGridView.EnableHeadersVisualStyles = false;
			this.uxTransactionHistoryArchiveDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTransactionHistoryArchiveDataGridViewDataError);
			this.uxTransactionHistoryArchiveDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTransactionHistoryArchiveDataGridViewCellValueNeeded);
			this.uxTransactionHistoryArchiveDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTransactionHistoryArchiveDataGridViewCellValuePushed);
			
			//
			// uxTransactionIdDataGridViewColumn
			//
			this.uxTransactionIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTransactionIdDataGridViewColumn.DataPropertyName = "TransactionId";
			this.uxTransactionIdDataGridViewColumn.HeaderText = "TransactionId";
			this.uxTransactionIdDataGridViewColumn.Name = "uxTransactionIdDataGridViewColumn";
			this.uxTransactionIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTransactionIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTransactionIdDataGridViewColumn.ReadOnly = false;		
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
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxTransactionHistoryArchiveDataGridView);
			this.Name = "TransactionHistoryArchiveDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryArchiveErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryArchiveDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTransactionHistoryArchiveBindingSource)).EndInit();
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
				TransactionHistoryArchiveDataGridViewEventArgs args = new TransactionHistoryArchiveDataGridViewEventArgs();
				args.TransactionHistoryArchive = _currentTransactionHistoryArchive;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TransactionHistoryArchiveDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TransactionHistoryArchive	_TransactionHistoryArchive;
	
			/// <summary>
			/// the  Entities.TransactionHistoryArchive instance.
			/// </summary>
			public Entities.TransactionHistoryArchive TransactionHistoryArchive
			{
				get { return _TransactionHistoryArchive; }
				set { _TransactionHistoryArchive = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTransactionHistoryArchiveDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTransactionHistoryArchiveDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTransactionHistoryArchiveDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTransactionHistoryArchiveDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTransactionHistoryArchiveDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTransactionIdDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].TransactionId;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].ProductId;
						break;
					case "uxReferenceOrderIdDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].ReferenceOrderId;
						break;
					case "uxReferenceOrderLineIdDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].ReferenceOrderLineId;
						break;
					case "uxTransactionDateDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].TransactionDate;
						break;
					case "uxTransactionTypeDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].TransactionType;
						break;
					case "uxQuantityDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].Quantity;
						break;
					case "uxActualCostDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].ActualCost;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = TransactionHistoryArchiveList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTransactionHistoryArchiveDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTransactionHistoryArchiveDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTransactionHistoryArchiveDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTransactionIdDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].TransactionId = (System.Int32)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxReferenceOrderIdDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].ReferenceOrderId = (System.Int32)e.Value;
						break;
					case "uxReferenceOrderLineIdDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].ReferenceOrderLineId = (System.Int32)e.Value;
						break;
					case "uxTransactionDateDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].TransactionDate = (System.DateTime)e.Value;
						break;
					case "uxTransactionTypeDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].TransactionType = (System.String)e.Value;
						break;
					case "uxQuantityDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].Quantity = (System.Int32)e.Value;
						break;
					case "uxActualCostDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].ActualCost = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						TransactionHistoryArchiveList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
