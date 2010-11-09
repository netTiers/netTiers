
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesOrderDetail typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesOrderDetailDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesOrderDetailDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesOrderDetail _currentSalesOrderDetail = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesOrderDetailDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesOrderDetailErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesOrderDetailBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the SalesOrderId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSalesOrderIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalesOrderDetailId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesOrderDetailIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CarrierTrackingNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCarrierTrackingNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OrderQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOrderQtyDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the SpecialOfferId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSpecialOfferIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UnitPrice property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUnitPriceDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UnitPriceDiscount property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUnitPriceDiscountDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LineTotal property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLineTotalDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.SalesOrderHeader> _SalesOrderIdList;
		
		/// <summary> 
		/// The list of selectable SalesOrderHeader
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SalesOrderHeader> SalesOrderIdList
		{
			get {return this._SalesOrderIdList;}
			set 
			{
				this._SalesOrderIdList = value;
				this.uxSalesOrderIdDataGridViewColumn.DataSource = null;
				this.uxSalesOrderIdDataGridViewColumn.DataSource = this._SalesOrderIdList;
			}
		}
		
		private bool _allowNewItemInSalesOrderIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of SalesOrderHeader
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesOrderIdList
		{
			get { return _allowNewItemInSalesOrderIdList;}
			set
			{
				this._allowNewItemInSalesOrderIdList = value;
				this.uxSalesOrderIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SalesOrderDetail> _SalesOrderDetailList;
				
		/// <summary> 
		/// The list of SalesOrderDetail to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesOrderDetail> SalesOrderDetailList
		{
			get {return this._SalesOrderDetailList;}
			set
			{
				this._SalesOrderDetailList = value;
				this.uxSalesOrderDetailBindingSource.DataSource = null;
				this.uxSalesOrderDetailBindingSource.DataSource = value;
				this.uxSalesOrderDetailDataGridView.DataSource = null;
				this.uxSalesOrderDetailDataGridView.DataSource = this.uxSalesOrderDetailBindingSource;				
				//this.uxSalesOrderDetailBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesOrderDetailBindingSource_ListChanged);
				this.uxSalesOrderDetailBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesOrderDetailBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesOrderDetailBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesOrderDetail = uxSalesOrderDetailBindingSource.Current as Entities.SalesOrderDetail;
			
			if (_currentSalesOrderDetail != null)
			{
				_currentSalesOrderDetail.Validate();
			}
			//_SalesOrderDetail.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesOrderDetailBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesOrderDetail"/> instance.
		/// </summary>
		public Entities.SalesOrderDetail SelectedSalesOrderDetail
		{
			get {return this._currentSalesOrderDetail;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesOrderDetailDataGridView.VirtualMode;}
			set
			{
				this.uxSalesOrderDetailDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesOrderDetailDataGridView.AllowUserToAddRows;}
			set {this.uxSalesOrderDetailDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesOrderDetailDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesOrderDetailDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesOrderDetailDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesOrderDetailDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesOrderDetailDataGridViewBase"/> class.
		/// </summary>
		public SalesOrderDetailDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesOrderDetailDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesOrderDetailErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSalesOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSalesOrderDetailIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCarrierTrackingNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxOrderQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSpecialOfferIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxUnitPriceDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUnitPriceDiscountDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLineTotalDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxSalesOrderIdBindingSource = new SalesOrderHeaderBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderDetailDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderDetailBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderDetailErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesOrderDetailErrorProvider
			// 
			this.uxSalesOrderDetailErrorProvider.ContainerControl = this;
			this.uxSalesOrderDetailErrorProvider.DataSource = this.uxSalesOrderDetailBindingSource;						
			// 
			// uxSalesOrderDetailDataGridView
			// 
			this.uxSalesOrderDetailDataGridView.AutoGenerateColumns = false;
			this.uxSalesOrderDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesOrderDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSalesOrderIdDataGridViewColumn,
		this.uxSalesOrderDetailIdDataGridViewColumn,
		this.uxCarrierTrackingNumberDataGridViewColumn,
		this.uxOrderQtyDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxSpecialOfferIdDataGridViewColumn,
		this.uxUnitPriceDataGridViewColumn,
		this.uxUnitPriceDiscountDataGridViewColumn,
		this.uxLineTotalDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesOrderDetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesOrderDetailDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesOrderDetailDataGridView.Name = "uxSalesOrderDetailDataGridView";
			this.uxSalesOrderDetailDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesOrderDetailDataGridView.TabIndex = 0;	
			this.uxSalesOrderDetailDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesOrderDetailDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesOrderDetailDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesOrderDetailDataGridViewDataError);
			this.uxSalesOrderDetailDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesOrderDetailDataGridViewCellValueNeeded);
			this.uxSalesOrderDetailDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesOrderDetailDataGridViewCellValuePushed);
			
			//
			// uxSalesOrderIdDataGridViewColumn
			//
			this.uxSalesOrderIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesOrderIdDataGridViewColumn.DataPropertyName = "SalesOrderId";
			this.uxSalesOrderIdDataGridViewColumn.HeaderText = "SalesOrderId";
			this.uxSalesOrderIdDataGridViewColumn.Name = "uxSalesOrderIdDataGridViewColumn";
			this.uxSalesOrderIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesOrderIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesOrderIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxSalesOrderDetailIdDataGridViewColumn
			//
			this.uxSalesOrderDetailIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesOrderDetailIdDataGridViewColumn.DataPropertyName = "SalesOrderDetailId";
			this.uxSalesOrderDetailIdDataGridViewColumn.HeaderText = "SalesOrderDetailId";
			this.uxSalesOrderDetailIdDataGridViewColumn.Name = "uxSalesOrderDetailIdDataGridViewColumn";
			this.uxSalesOrderDetailIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesOrderDetailIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesOrderDetailIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxCarrierTrackingNumberDataGridViewColumn
			//
			this.uxCarrierTrackingNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCarrierTrackingNumberDataGridViewColumn.DataPropertyName = "CarrierTrackingNumber";
			this.uxCarrierTrackingNumberDataGridViewColumn.HeaderText = "CarrierTrackingNumber";
			this.uxCarrierTrackingNumberDataGridViewColumn.Name = "uxCarrierTrackingNumberDataGridViewColumn";
			this.uxCarrierTrackingNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCarrierTrackingNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCarrierTrackingNumberDataGridViewColumn.ReadOnly = false;		
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
			// uxUnitPriceDiscountDataGridViewColumn
			//
			this.uxUnitPriceDiscountDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUnitPriceDiscountDataGridViewColumn.DataPropertyName = "UnitPriceDiscount";
			this.uxUnitPriceDiscountDataGridViewColumn.HeaderText = "UnitPriceDiscount";
			this.uxUnitPriceDiscountDataGridViewColumn.Name = "uxUnitPriceDiscountDataGridViewColumn";
			this.uxUnitPriceDiscountDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUnitPriceDiscountDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUnitPriceDiscountDataGridViewColumn.ReadOnly = false;		
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
			// uxSalesOrderIdDataGridViewColumn
			//				
			this.uxSalesOrderIdDataGridViewColumn.DisplayMember = "RevisionNumber";	
			this.uxSalesOrderIdDataGridViewColumn.ValueMember = "SalesOrderId";	
			this.uxSalesOrderIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSalesOrderIdDataGridViewColumn.DataSource = uxSalesOrderIdBindingSource;				
				
			//
			// uxSpecialOfferIdDataGridViewColumn
			//				
			this.uxSpecialOfferIdDataGridViewColumn.DisplayMember = "ProductId";	
			this.uxSpecialOfferIdDataGridViewColumn.ValueMember = "SpecialOfferId";	
			this.uxSpecialOfferIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSpecialOfferIdDataGridViewColumn.DataSource = uxSpecialOfferIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxSalesOrderDetailDataGridView);
			this.Name = "SalesOrderDetailDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderDetailErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderDetailDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderDetailBindingSource)).EndInit();
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
				SalesOrderDetailDataGridViewEventArgs args = new SalesOrderDetailDataGridViewEventArgs();
				args.SalesOrderDetail = _currentSalesOrderDetail;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesOrderDetailDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesOrderDetail	_SalesOrderDetail;
	
			/// <summary>
			/// the  Entities.SalesOrderDetail instance.
			/// </summary>
			public Entities.SalesOrderDetail SalesOrderDetail
			{
				get { return _SalesOrderDetail; }
				set { _SalesOrderDetail = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesOrderDetailDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderDetailDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesOrderDetailDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderDetailDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesOrderDetailDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesOrderIdDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].SalesOrderId;
						break;
					case "uxSalesOrderDetailIdDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].SalesOrderDetailId;
						break;
					case "uxCarrierTrackingNumberDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].CarrierTrackingNumber;
						break;
					case "uxOrderQtyDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].OrderQty;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].ProductId;
						break;
					case "uxSpecialOfferIdDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].SpecialOfferId;
						break;
					case "uxUnitPriceDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].UnitPrice;
						break;
					case "uxUnitPriceDiscountDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].UnitPriceDiscount;
						break;
					case "uxLineTotalDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].LineTotal;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesOrderDetailList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesOrderDetailDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderDetailDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesOrderDetailDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesOrderIdDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].SalesOrderId = (System.Int32)e.Value;
						break;
					case "uxSalesOrderDetailIdDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].SalesOrderDetailId = (System.Int32)e.Value;
						break;
					case "uxCarrierTrackingNumberDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].CarrierTrackingNumber = (System.String)e.Value;
						break;
					case "uxOrderQtyDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].OrderQty = (System.Int16)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxSpecialOfferIdDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].SpecialOfferId = (System.Int32)e.Value;
						break;
					case "uxUnitPriceDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].UnitPrice = (System.Decimal)e.Value;
						break;
					case "uxUnitPriceDiscountDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].UnitPriceDiscount = (System.Decimal)e.Value;
						break;
					case "uxLineTotalDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].LineTotal = (System.Decimal)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesOrderDetailList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
