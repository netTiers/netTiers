
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract WorkOrder typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class WorkOrderDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<WorkOrderDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.WorkOrder _currentWorkOrder = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxWorkOrderDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxWorkOrderErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxWorkOrderBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the WorkOrderId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxWorkOrderIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OrderQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOrderQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StockedQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStockedQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ScrappedQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxScrappedQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEndDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DueDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDueDateDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ScrapReasonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxScrapReasonIdDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.ScrapReason> _ScrapReasonIdList;
		
		/// <summary> 
		/// The list of selectable ScrapReason
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ScrapReason> ScrapReasonIdList
		{
			get {return this._ScrapReasonIdList;}
			set 
			{
				this._ScrapReasonIdList = value;
				this.uxScrapReasonIdDataGridViewColumn.DataSource = null;
				this.uxScrapReasonIdDataGridViewColumn.DataSource = this._ScrapReasonIdList;
			}
		}
		
		private bool _allowNewItemInScrapReasonIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ScrapReason
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInScrapReasonIdList
		{
			get { return _allowNewItemInScrapReasonIdList;}
			set
			{
				this._allowNewItemInScrapReasonIdList = value;
				this.uxScrapReasonIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.WorkOrder> _WorkOrderList;
				
		/// <summary> 
		/// The list of WorkOrder to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.WorkOrder> WorkOrderList
		{
			get {return this._WorkOrderList;}
			set
			{
				this._WorkOrderList = value;
				this.uxWorkOrderBindingSource.DataSource = null;
				this.uxWorkOrderBindingSource.DataSource = value;
				this.uxWorkOrderDataGridView.DataSource = null;
				this.uxWorkOrderDataGridView.DataSource = this.uxWorkOrderBindingSource;				
				//this.uxWorkOrderBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxWorkOrderBindingSource_ListChanged);
				this.uxWorkOrderBindingSource.CurrentItemChanged += new System.EventHandler(OnWorkOrderBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnWorkOrderBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentWorkOrder = uxWorkOrderBindingSource.Current as Entities.WorkOrder;
			
			if (_currentWorkOrder != null)
			{
				_currentWorkOrder.Validate();
			}
			//_WorkOrder.Validate();
			OnCurrentEntityChanged();
		}

		//void uxWorkOrderBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.WorkOrder"/> instance.
		/// </summary>
		public Entities.WorkOrder SelectedWorkOrder
		{
			get {return this._currentWorkOrder;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxWorkOrderDataGridView.VirtualMode;}
			set
			{
				this.uxWorkOrderDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxWorkOrderDataGridView.AllowUserToAddRows;}
			set {this.uxWorkOrderDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxWorkOrderDataGridView.AllowUserToDeleteRows;}
			set {this.uxWorkOrderDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxWorkOrderDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxWorkOrderDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="WorkOrderDataGridViewBase"/> class.
		/// </summary>
		public WorkOrderDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxWorkOrderDataGridView = new System.Windows.Forms.DataGridView();
			this.uxWorkOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxWorkOrderErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxWorkOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxOrderQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStockedQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxScrappedQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDueDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxScrapReasonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			//this.uxScrapReasonIdBindingSource = new ScrapReasonBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxScrapReasonIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxWorkOrderErrorProvider
			// 
			this.uxWorkOrderErrorProvider.ContainerControl = this;
			this.uxWorkOrderErrorProvider.DataSource = this.uxWorkOrderBindingSource;						
			// 
			// uxWorkOrderDataGridView
			// 
			this.uxWorkOrderDataGridView.AutoGenerateColumns = false;
			this.uxWorkOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxWorkOrderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxWorkOrderIdDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxOrderQtyDataGridViewColumn,
		this.uxStockedQtyDataGridViewColumn,
		this.uxScrappedQtyDataGridViewColumn,
		this.uxStartDateDataGridViewColumn,
		this.uxEndDateDataGridViewColumn,
		this.uxDueDateDataGridViewColumn,
		this.uxScrapReasonIdDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxWorkOrderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxWorkOrderDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxWorkOrderDataGridView.Name = "uxWorkOrderDataGridView";
			this.uxWorkOrderDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxWorkOrderDataGridView.TabIndex = 0;	
			this.uxWorkOrderDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxWorkOrderDataGridView.EnableHeadersVisualStyles = false;
			this.uxWorkOrderDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnWorkOrderDataGridViewDataError);
			this.uxWorkOrderDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnWorkOrderDataGridViewCellValueNeeded);
			this.uxWorkOrderDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnWorkOrderDataGridViewCellValuePushed);
			
			//
			// uxWorkOrderIdDataGridViewColumn
			//
			this.uxWorkOrderIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxWorkOrderIdDataGridViewColumn.DataPropertyName = "WorkOrderId";
			this.uxWorkOrderIdDataGridViewColumn.HeaderText = "WorkOrderId";
			this.uxWorkOrderIdDataGridViewColumn.Name = "uxWorkOrderIdDataGridViewColumn";
			this.uxWorkOrderIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxWorkOrderIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxWorkOrderIdDataGridViewColumn.ReadOnly = true;		
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
			// uxOrderQtyDataGridViewColumn
			//
			this.uxOrderQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxOrderQtyDataGridViewColumn.DataPropertyName = "OrderQty";
			this.uxOrderQtyDataGridViewColumn.HeaderText = "OrderQty";
			this.uxOrderQtyDataGridViewColumn.Name = "uxOrderQtyDataGridViewColumn";
			this.uxOrderQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxOrderQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxOrderQtyDataGridViewColumn.ReadOnly = false;		
			//
			// uxStockedQtyDataGridViewColumn
			//
			this.uxStockedQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStockedQtyDataGridViewColumn.DataPropertyName = "StockedQty";
			this.uxStockedQtyDataGridViewColumn.HeaderText = "StockedQty";
			this.uxStockedQtyDataGridViewColumn.Name = "uxStockedQtyDataGridViewColumn";
			this.uxStockedQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStockedQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStockedQtyDataGridViewColumn.ReadOnly = true;		
			//
			// uxScrappedQtyDataGridViewColumn
			//
			this.uxScrappedQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxScrappedQtyDataGridViewColumn.DataPropertyName = "ScrappedQty";
			this.uxScrappedQtyDataGridViewColumn.HeaderText = "ScrappedQty";
			this.uxScrappedQtyDataGridViewColumn.Name = "uxScrappedQtyDataGridViewColumn";
			this.uxScrappedQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxScrappedQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxScrappedQtyDataGridViewColumn.ReadOnly = false;		
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
			// uxDueDateDataGridViewColumn
			//
			this.uxDueDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDueDateDataGridViewColumn.DataPropertyName = "DueDate";
			this.uxDueDateDataGridViewColumn.HeaderText = "DueDate";
			this.uxDueDateDataGridViewColumn.Name = "uxDueDateDataGridViewColumn";
			this.uxDueDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDueDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDueDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxScrapReasonIdDataGridViewColumn
			//
			this.uxScrapReasonIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxScrapReasonIdDataGridViewColumn.DataPropertyName = "ScrapReasonId";
			this.uxScrapReasonIdDataGridViewColumn.HeaderText = "ScrapReasonId";
			this.uxScrapReasonIdDataGridViewColumn.Name = "uxScrapReasonIdDataGridViewColumn";
			this.uxScrapReasonIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxScrapReasonIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxScrapReasonIdDataGridViewColumn.ReadOnly = false;		
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
			// uxScrapReasonIdDataGridViewColumn
			//				
			this.uxScrapReasonIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxScrapReasonIdDataGridViewColumn.ValueMember = "ScrapReasonId";	
			this.uxScrapReasonIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxScrapReasonIdDataGridViewColumn.DataSource = uxScrapReasonIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxWorkOrderDataGridView);
			this.Name = "WorkOrderDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxScrapReasonIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderBindingSource)).EndInit();
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
				WorkOrderDataGridViewEventArgs args = new WorkOrderDataGridViewEventArgs();
				args.WorkOrder = _currentWorkOrder;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class WorkOrderDataGridViewEventArgs : System.EventArgs
		{
			private Entities.WorkOrder	_WorkOrder;
	
			/// <summary>
			/// the  Entities.WorkOrder instance.
			/// </summary>
			public Entities.WorkOrder WorkOrder
			{
				get { return _WorkOrder; }
				set { _WorkOrder = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxWorkOrderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnWorkOrderDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxWorkOrderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnWorkOrderDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxWorkOrderDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxWorkOrderIdDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].WorkOrderId;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].ProductId;
						break;
					case "uxOrderQtyDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].OrderQty;
						break;
					case "uxStockedQtyDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].StockedQty;
						break;
					case "uxScrappedQtyDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].ScrappedQty;
						break;
					case "uxStartDateDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].StartDate;
						break;
					case "uxEndDateDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].EndDate;
						break;
					case "uxDueDateDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].DueDate;
						break;
					case "uxScrapReasonIdDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].ScrapReasonId;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = WorkOrderList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxWorkOrderDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnWorkOrderDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxWorkOrderDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxWorkOrderIdDataGridViewColumn":
						WorkOrderList[e.RowIndex].WorkOrderId = (System.Int32)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						WorkOrderList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxOrderQtyDataGridViewColumn":
						WorkOrderList[e.RowIndex].OrderQty = (System.Int32)e.Value;
						break;
					case "uxStockedQtyDataGridViewColumn":
						WorkOrderList[e.RowIndex].StockedQty = (System.Int32)e.Value;
						break;
					case "uxScrappedQtyDataGridViewColumn":
						WorkOrderList[e.RowIndex].ScrappedQty = (System.Int16)e.Value;
						break;
					case "uxStartDateDataGridViewColumn":
						WorkOrderList[e.RowIndex].StartDate = (System.DateTime)e.Value;
						break;
					case "uxEndDateDataGridViewColumn":
						WorkOrderList[e.RowIndex].EndDate = (System.DateTime?)e.Value;
						break;
					case "uxDueDateDataGridViewColumn":
						WorkOrderList[e.RowIndex].DueDate = (System.DateTime)e.Value;
						break;
					case "uxScrapReasonIdDataGridViewColumn":
						WorkOrderList[e.RowIndex].ScrapReasonId = (System.Int16?)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						WorkOrderList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
