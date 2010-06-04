
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Customer typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CustomerDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CustomerDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Customer _currentCustomer = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCustomerDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCustomerErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCustomerBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the CustomerId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCustomerIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the TerritoryId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxTerritoryIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AccountNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAccountNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CustomerType property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCustomerTypeDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.SalesTerritory> _TerritoryIdList;
		
		/// <summary> 
		/// The list of selectable SalesTerritory
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SalesTerritory> TerritoryIdList
		{
			get {return this._TerritoryIdList;}
			set 
			{
				this._TerritoryIdList = value;
				this.uxTerritoryIdDataGridViewColumn.DataSource = null;
				this.uxTerritoryIdDataGridViewColumn.DataSource = this._TerritoryIdList;
			}
		}
		
		private bool _allowNewItemInTerritoryIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of SalesTerritory
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInTerritoryIdList
		{
			get { return _allowNewItemInTerritoryIdList;}
			set
			{
				this._allowNewItemInTerritoryIdList = value;
				this.uxTerritoryIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Customer> _CustomerList;
				
		/// <summary> 
		/// The list of Customer to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Customer> CustomerList
		{
			get {return this._CustomerList;}
			set
			{
				this._CustomerList = value;
				this.uxCustomerBindingSource.DataSource = null;
				this.uxCustomerBindingSource.DataSource = value;
				this.uxCustomerDataGridView.DataSource = null;
				this.uxCustomerDataGridView.DataSource = this.uxCustomerBindingSource;				
				//this.uxCustomerBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCustomerBindingSource_ListChanged);
				this.uxCustomerBindingSource.CurrentItemChanged += new System.EventHandler(OnCustomerBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCustomerBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCustomer = uxCustomerBindingSource.Current as Entities.Customer;
			
			if (_currentCustomer != null)
			{
				_currentCustomer.Validate();
			}
			//_Customer.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCustomerBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Customer"/> instance.
		/// </summary>
		public Entities.Customer SelectedCustomer
		{
			get {return this._currentCustomer;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCustomerDataGridView.VirtualMode;}
			set
			{
				this.uxCustomerDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCustomerDataGridView.AllowUserToAddRows;}
			set {this.uxCustomerDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCustomerDataGridView.AllowUserToDeleteRows;}
			set {this.uxCustomerDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCustomerDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCustomerDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CustomerDataGridViewBase"/> class.
		/// </summary>
		public CustomerDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCustomerDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCustomerErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCustomerIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTerritoryIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAccountNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCustomerTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxTerritoryIdBindingSource = new SalesTerritoryBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCustomerErrorProvider
			// 
			this.uxCustomerErrorProvider.ContainerControl = this;
			this.uxCustomerErrorProvider.DataSource = this.uxCustomerBindingSource;						
			// 
			// uxCustomerDataGridView
			// 
			this.uxCustomerDataGridView.AutoGenerateColumns = false;
			this.uxCustomerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCustomerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCustomerIdDataGridViewColumn,
		this.uxTerritoryIdDataGridViewColumn,
		this.uxAccountNumberDataGridViewColumn,
		this.uxCustomerTypeDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxCustomerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCustomerDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCustomerDataGridView.Name = "uxCustomerDataGridView";
			this.uxCustomerDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCustomerDataGridView.TabIndex = 0;	
			this.uxCustomerDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCustomerDataGridView.EnableHeadersVisualStyles = false;
			this.uxCustomerDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCustomerDataGridViewDataError);
			this.uxCustomerDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCustomerDataGridViewCellValueNeeded);
			this.uxCustomerDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCustomerDataGridViewCellValuePushed);
			
			//
			// uxCustomerIdDataGridViewColumn
			//
			this.uxCustomerIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCustomerIdDataGridViewColumn.DataPropertyName = "CustomerId";
			this.uxCustomerIdDataGridViewColumn.HeaderText = "CustomerId";
			this.uxCustomerIdDataGridViewColumn.Name = "uxCustomerIdDataGridViewColumn";
			this.uxCustomerIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCustomerIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCustomerIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxTerritoryIdDataGridViewColumn
			//
			this.uxTerritoryIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTerritoryIdDataGridViewColumn.DataPropertyName = "TerritoryId";
			this.uxTerritoryIdDataGridViewColumn.HeaderText = "TerritoryId";
			this.uxTerritoryIdDataGridViewColumn.Name = "uxTerritoryIdDataGridViewColumn";
			this.uxTerritoryIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTerritoryIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTerritoryIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxAccountNumberDataGridViewColumn
			//
			this.uxAccountNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAccountNumberDataGridViewColumn.DataPropertyName = "AccountNumber";
			this.uxAccountNumberDataGridViewColumn.HeaderText = "AccountNumber";
			this.uxAccountNumberDataGridViewColumn.Name = "uxAccountNumberDataGridViewColumn";
			this.uxAccountNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAccountNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAccountNumberDataGridViewColumn.ReadOnly = true;		
			//
			// uxCustomerTypeDataGridViewColumn
			//
			this.uxCustomerTypeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCustomerTypeDataGridViewColumn.DataPropertyName = "CustomerType";
			this.uxCustomerTypeDataGridViewColumn.HeaderText = "CustomerType";
			this.uxCustomerTypeDataGridViewColumn.Name = "uxCustomerTypeDataGridViewColumn";
			this.uxCustomerTypeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCustomerTypeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCustomerTypeDataGridViewColumn.ReadOnly = false;		
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
			// uxTerritoryIdDataGridViewColumn
			//				
			this.uxTerritoryIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxTerritoryIdDataGridViewColumn.ValueMember = "TerritoryId";	
			this.uxTerritoryIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxTerritoryIdDataGridViewColumn.DataSource = uxTerritoryIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxCustomerDataGridView);
			this.Name = "CustomerDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxTerritoryIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCustomerBindingSource)).EndInit();
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
				CustomerDataGridViewEventArgs args = new CustomerDataGridViewEventArgs();
				args.Customer = _currentCustomer;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CustomerDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Customer	_Customer;
	
			/// <summary>
			/// the  Entities.Customer instance.
			/// </summary>
			public Entities.Customer Customer
			{
				get { return _Customer; }
				set { _Customer = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCustomerDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCustomerDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCustomerDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCustomerDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCustomerDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						e.Value = CustomerList[e.RowIndex].CustomerId;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						e.Value = CustomerList[e.RowIndex].TerritoryId;
						break;
					case "uxAccountNumberDataGridViewColumn":
						e.Value = CustomerList[e.RowIndex].AccountNumber;
						break;
					case "uxCustomerTypeDataGridViewColumn":
						e.Value = CustomerList[e.RowIndex].CustomerType;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = CustomerList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = CustomerList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCustomerDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCustomerDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCustomerDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						CustomerList[e.RowIndex].CustomerId = (System.Int32)e.Value;
						break;
					case "uxTerritoryIdDataGridViewColumn":
						CustomerList[e.RowIndex].TerritoryId = (System.Int32?)e.Value;
						break;
					case "uxAccountNumberDataGridViewColumn":
						CustomerList[e.RowIndex].AccountNumber = (System.String)e.Value;
						break;
					case "uxCustomerTypeDataGridViewColumn":
						CustomerList[e.RowIndex].CustomerType = (System.String)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						CustomerList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						CustomerList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
