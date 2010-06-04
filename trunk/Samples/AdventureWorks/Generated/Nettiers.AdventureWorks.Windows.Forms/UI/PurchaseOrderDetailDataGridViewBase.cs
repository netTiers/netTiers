
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract PurchaseOrderDetail typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class PurchaseOrderDetailDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<PurchaseOrderDetailDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.PurchaseOrderDetail _currentPurchaseOrderDetail = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxPurchaseOrderDetailDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxPurchaseOrderDetailErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxPurchaseOrderDetailBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the PurchaseOrderId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxPurchaseOrderIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PurchaseOrderDetailId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPurchaseOrderDetailIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DueDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDueDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OrderQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOrderQtyDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UnitPrice property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUnitPriceDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LineTotal property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLineTotalDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ReceivedQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxReceivedQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the RejectedQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRejectedQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StockedQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStockedQtyDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.PurchaseOrderHeader> _PurchaseOrderIdList;
		
		/// <summary> 
		/// The list of selectable PurchaseOrderHeader
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.PurchaseOrderHeader> PurchaseOrderIdList
		{
			get {return this._PurchaseOrderIdList;}
			set 
			{
				this._PurchaseOrderIdList = value;
				this.uxPurchaseOrderIdDataGridViewColumn.DataSource = null;
				this.uxPurchaseOrderIdDataGridViewColumn.DataSource = this._PurchaseOrderIdList;
			}
		}
		
		private bool _allowNewItemInPurchaseOrderIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of PurchaseOrderHeader
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInPurchaseOrderIdList
		{
			get { return _allowNewItemInPurchaseOrderIdList;}
			set
			{
				this._allowNewItemInPurchaseOrderIdList = value;
				this.uxPurchaseOrderIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.PurchaseOrderDetail> _PurchaseOrderDetailList;
				
		/// <summary> 
		/// The list of PurchaseOrderDetail to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.PurchaseOrderDetail> PurchaseOrderDetailList
		{
			get {return this._PurchaseOrderDetailList;}
			set
			{
				this._PurchaseOrderDetailList = value;
				this.uxPurchaseOrderDetailBindingSource.DataSource = null;
				this.uxPurchaseOrderDetailBindingSource.DataSource = value;
				this.uxPurchaseOrderDetailDataGridView.DataSource = null;
				this.uxPurchaseOrderDetailDataGridView.DataSource = this.uxPurchaseOrderDetailBindingSource;				
				//this.uxPurchaseOrderDetailBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxPurchaseOrderDetailBindingSource_ListChanged);
				this.uxPurchaseOrderDetailBindingSource.CurrentItemChanged += new System.EventHandler(OnPurchaseOrderDetailBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnPurchaseOrderDetailBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentPurchaseOrderDetail = uxPurchaseOrderDetailBindingSource.Current as Entities.PurchaseOrderDetail;
			
			if (_currentPurchaseOrderDetail != null)
			{
				_currentPurchaseOrderDetail.Validate();
			}
			//_PurchaseOrderDetail.Validate();
			OnCurrentEntityChanged();
		}

		//void uxPurchaseOrderDetailBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.PurchaseOrderDetail"/> instance.
		/// </summary>
		public Entities.PurchaseOrderDetail SelectedPurchaseOrderDetail
		{
			get {return this._currentPurchaseOrderDetail;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxPurchaseOrderDetailDataGridView.VirtualMode;}
			set
			{
				this.uxPurchaseOrderDetailDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxPurchaseOrderDetailDataGridView.AllowUserToAddRows;}
			set {this.uxPurchaseOrderDetailDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxPurchaseOrderDetailDataGridView.AllowUserToDeleteRows;}
			set {this.uxPurchaseOrderDetailDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxPurchaseOrderDetailDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxPurchaseOrderDetailDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="PurchaseOrderDetailDataGridViewBase"/> class.
		/// </summary>
		public PurchaseOrderDetailDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxPurchaseOrderDetailDataGridView = new System.Windows.Forms.DataGridView();
			this.uxPurchaseOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxPurchaseOrderDetailErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxPurchaseOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxPurchaseOrderDetailIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDueDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxOrderQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxUnitPriceDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLineTotalDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxReceivedQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRejectedQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStockedQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			//this.uxPurchaseOrderIdBindingSource = new PurchaseOrderHeaderBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderDetailDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderDetailBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderDetailErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxPurchaseOrderDetailErrorProvider
			// 
			this.uxPurchaseOrderDetailErrorProvider.ContainerControl = this;
			this.uxPurchaseOrderDetailErrorProvider.DataSource = this.uxPurchaseOrderDetailBindingSource;						
			// 
			// uxPurchaseOrderDetailDataGridView
			// 
			this.uxPurchaseOrderDetailDataGridView.AutoGenerateColumns = false;
			this.uxPurchaseOrderDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxPurchaseOrderDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxPurchaseOrderIdDataGridViewColumn,
		this.uxPurchaseOrderDetailIdDataGridViewColumn,
		this.uxDueDateDataGridViewColumn,
		this.uxOrderQtyDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxUnitPriceDataGridViewColumn,
		this.uxLineTotalDataGridViewColumn,
		this.uxReceivedQtyDataGridViewColumn,
		this.uxRejectedQtyDataGridViewColumn,
		this.uxStockedQtyDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxPurchaseOrderDetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxPurchaseOrderDetailDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxPurchaseOrderDetailDataGridView.Name = "uxPurchaseOrderDetailDataGridView";
			this.uxPurchaseOrderDetailDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxPurchaseOrderDetailDataGridView.TabIndex = 0;	
			this.uxPurchaseOrderDetailDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxPurchaseOrderDetailDataGridView.EnableHeadersVisualStyles = false;
			this.uxPurchaseOrderDetailDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnPurchaseOrderDetailDataGridViewDataError);
			this.uxPurchaseOrderDetailDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnPurchaseOrderDetailDataGridViewCellValueNeeded);
			this.uxPurchaseOrderDetailDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnPurchaseOrderDetailDataGridViewCellValuePushed);
			
			//
			// uxPurchaseOrderIdDataGridViewColumn
			//
			this.uxPurchaseOrderIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPurchaseOrderIdDataGridViewColumn.DataPropertyName = "PurchaseOrderId";
			this.uxPurchaseOrderIdDataGridViewColumn.HeaderText = "PurchaseOrderId";
			this.uxPurchaseOrderIdDataGridViewColumn.Name = "uxPurchaseOrderIdDataGridViewColumn";
			this.uxPurchaseOrderIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPurchaseOrderIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPurchaseOrderIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxPurchaseOrderDetailIdDataGridViewColumn
			//
			this.uxPurchaseOrderDetailIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPurchaseOrderDetailIdDataGridViewColumn.DataPropertyName = "PurchaseOrderDetailId";
			this.uxPurchaseOrderDetailIdDataGridViewColumn.HeaderText = "PurchaseOrderDetailId";
			this.uxPurchaseOrderDetailIdDataGridViewColumn.Name = "uxPurchaseOrderDetailIdDataGridViewColumn";
			this.uxPurchaseOrderDetailIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPurchaseOrderDetailIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPurchaseOrderDetailIdDataGridViewColumn.ReadOnly = true;		
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
			// uxUnitPriceDataGridViewColumn
			//
			this.uxUnitPriceDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUnitPriceDataGridViewColumn.DataPropertyName = "UnitPrice";
			this.uxUnitPriceDataGridViewColumn.HeaderText = "UnitPrice";
			this.uxUnitPriceDataGridViewColumn.Name = "uxUnitPriceDataGridViewColumn";
			this.uxUnitPriceDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUnitPriceDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUnitPriceDataGridViewColumn.ReadOnly = false;		
			//
			// uxLineTotalDataGridViewColumn
			//
			this.uxLineTotalDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLineTotalDataGridViewColumn.DataPropertyName = "LineTotal";
			this.uxLineTotalDataGridViewColumn.HeaderText = "LineTotal";
			this.uxLineTotalDataGridViewColumn.Name = "uxLineTotalDataGridViewColumn";
			this.uxLineTotalDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLineTotalDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLineTotalDataGridViewColumn.ReadOnly = true;		
			//
			// uxReceivedQtyDataGridViewColumn
			//
			this.uxReceivedQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxReceivedQtyDataGridViewColumn.DataPropertyName = "ReceivedQty";
			this.uxReceivedQtyDataGridViewColumn.HeaderText = "ReceivedQty";
			this.uxReceivedQtyDataGridViewColumn.Name = "uxReceivedQtyDataGridViewColumn";
			this.uxReceivedQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxReceivedQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxReceivedQtyDataGridViewColumn.ReadOnly = false;		
			//
			// uxRejectedQtyDataGridViewColumn
			//
			this.uxRejectedQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRejectedQtyDataGridViewColumn.DataPropertyName = "RejectedQty";
			this.uxRejectedQtyDataGridViewColumn.HeaderText = "RejectedQty";
			this.uxRejectedQtyDataGridViewColumn.Name = "uxRejectedQtyDataGridViewColumn";
			this.uxRejectedQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRejectedQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRejectedQtyDataGridViewColumn.ReadOnly = false;		
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
			// uxPurchaseOrderIdDataGridViewColumn
			//				
			this.uxPurchaseOrderIdDataGridViewColumn.DisplayMember = "RevisionNumber";	
			this.uxPurchaseOrderIdDataGridViewColumn.ValueMember = "PurchaseOrderId";	
			this.uxPurchaseOrderIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxPurchaseOrderIdDataGridViewColumn.DataSource = uxPurchaseOrderIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxPurchaseOrderDetailDataGridView);
			this.Name = "PurchaseOrderDetailDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderDetailErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderDetailDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPurchaseOrderDetailBindingSource)).EndInit();
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
				PurchaseOrderDetailDataGridViewEventArgs args = new PurchaseOrderDetailDataGridViewEventArgs();
				args.PurchaseOrderDetail = _currentPurchaseOrderDetail;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class PurchaseOrderDetailDataGridViewEventArgs : System.EventArgs
		{
			private Entities.PurchaseOrderDetail	_PurchaseOrderDetail;
	
			/// <summary>
			/// the  Entities.PurchaseOrderDetail instance.
			/// </summary>
			public Entities.PurchaseOrderDetail PurchaseOrderDetail
			{
				get { return _PurchaseOrderDetail; }
				set { _PurchaseOrderDetail = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxPurchaseOrderDetailDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnPurchaseOrderDetailDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxPurchaseOrderDetailDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnPurchaseOrderDetailDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxPurchaseOrderDetailDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxPurchaseOrderIdDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].PurchaseOrderId;
						break;
					case "uxPurchaseOrderDetailIdDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].PurchaseOrderDetailId;
						break;
					case "uxDueDateDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].DueDate;
						break;
					case "uxOrderQtyDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].OrderQty;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].ProductId;
						break;
					case "uxUnitPriceDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].UnitPrice;
						break;
					case "uxLineTotalDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].LineTotal;
						break;
					case "uxReceivedQtyDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].ReceivedQty;
						break;
					case "uxRejectedQtyDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].RejectedQty;
						break;
					case "uxStockedQtyDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].StockedQty;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = PurchaseOrderDetailList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxPurchaseOrderDetailDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnPurchaseOrderDetailDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxPurchaseOrderDetailDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxPurchaseOrderIdDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].PurchaseOrderId = (System.Int32)e.Value;
						break;
					case "uxPurchaseOrderDetailIdDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].PurchaseOrderDetailId = (System.Int32)e.Value;
						break;
					case "uxDueDateDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].DueDate = (System.DateTime)e.Value;
						break;
					case "uxOrderQtyDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].OrderQty = (System.Int16)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxUnitPriceDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].UnitPrice = (System.Decimal)e.Value;
						break;
					case "uxLineTotalDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].LineTotal = (System.Decimal)e.Value;
						break;
					case "uxReceivedQtyDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].ReceivedQty = (System.Decimal)e.Value;
						break;
					case "uxRejectedQtyDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].RejectedQty = (System.Decimal)e.Value;
						break;
					case "uxStockedQtyDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].StockedQty = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						PurchaseOrderDetailList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
