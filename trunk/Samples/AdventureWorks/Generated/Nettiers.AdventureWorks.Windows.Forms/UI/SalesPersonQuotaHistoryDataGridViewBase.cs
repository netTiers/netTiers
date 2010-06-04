
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesPersonQuotaHistory typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesPersonQuotaHistoryDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesPersonQuotaHistoryDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesPersonQuotaHistory _currentSalesPersonQuotaHistory = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesPersonQuotaHistoryDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesPersonQuotaHistoryErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesPersonQuotaHistoryBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the SalesPersonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSalesPersonIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the QuotaDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxQuotaDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SalesQuota property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesQuotaDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.SalesPerson> _SalesPersonIdList;
		
		/// <summary> 
		/// The list of selectable SalesPerson
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SalesPerson> SalesPersonIdList
		{
			get {return this._SalesPersonIdList;}
			set 
			{
				this._SalesPersonIdList = value;
				this.uxSalesPersonIdDataGridViewColumn.DataSource = null;
				this.uxSalesPersonIdDataGridViewColumn.DataSource = this._SalesPersonIdList;
			}
		}
		
		private bool _allowNewItemInSalesPersonIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of SalesPerson
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesPersonIdList
		{
			get { return _allowNewItemInSalesPersonIdList;}
			set
			{
				this._allowNewItemInSalesPersonIdList = value;
				this.uxSalesPersonIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SalesPersonQuotaHistory> _SalesPersonQuotaHistoryList;
				
		/// <summary> 
		/// The list of SalesPersonQuotaHistory to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesPersonQuotaHistory> SalesPersonQuotaHistoryList
		{
			get {return this._SalesPersonQuotaHistoryList;}
			set
			{
				this._SalesPersonQuotaHistoryList = value;
				this.uxSalesPersonQuotaHistoryBindingSource.DataSource = null;
				this.uxSalesPersonQuotaHistoryBindingSource.DataSource = value;
				this.uxSalesPersonQuotaHistoryDataGridView.DataSource = null;
				this.uxSalesPersonQuotaHistoryDataGridView.DataSource = this.uxSalesPersonQuotaHistoryBindingSource;				
				//this.uxSalesPersonQuotaHistoryBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesPersonQuotaHistoryBindingSource_ListChanged);
				this.uxSalesPersonQuotaHistoryBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesPersonQuotaHistoryBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesPersonQuotaHistoryBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesPersonQuotaHistory = uxSalesPersonQuotaHistoryBindingSource.Current as Entities.SalesPersonQuotaHistory;
			
			if (_currentSalesPersonQuotaHistory != null)
			{
				_currentSalesPersonQuotaHistory.Validate();
			}
			//_SalesPersonQuotaHistory.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesPersonQuotaHistoryBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesPersonQuotaHistory"/> instance.
		/// </summary>
		public Entities.SalesPersonQuotaHistory SelectedSalesPersonQuotaHistory
		{
			get {return this._currentSalesPersonQuotaHistory;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesPersonQuotaHistoryDataGridView.VirtualMode;}
			set
			{
				this.uxSalesPersonQuotaHistoryDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesPersonQuotaHistoryDataGridView.AllowUserToAddRows;}
			set {this.uxSalesPersonQuotaHistoryDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesPersonQuotaHistoryDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesPersonQuotaHistoryDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesPersonQuotaHistoryDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesPersonQuotaHistoryDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesPersonQuotaHistoryDataGridViewBase"/> class.
		/// </summary>
		public SalesPersonQuotaHistoryDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesPersonQuotaHistoryDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesPersonQuotaHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesPersonQuotaHistoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSalesPersonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxQuotaDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSalesQuotaDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxSalesPersonIdBindingSource = new SalesPersonBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonQuotaHistoryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonQuotaHistoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonQuotaHistoryErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesPersonQuotaHistoryErrorProvider
			// 
			this.uxSalesPersonQuotaHistoryErrorProvider.ContainerControl = this;
			this.uxSalesPersonQuotaHistoryErrorProvider.DataSource = this.uxSalesPersonQuotaHistoryBindingSource;						
			// 
			// uxSalesPersonQuotaHistoryDataGridView
			// 
			this.uxSalesPersonQuotaHistoryDataGridView.AutoGenerateColumns = false;
			this.uxSalesPersonQuotaHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesPersonQuotaHistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSalesPersonIdDataGridViewColumn,
		this.uxQuotaDateDataGridViewColumn,
		this.uxSalesQuotaDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesPersonQuotaHistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesPersonQuotaHistoryDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesPersonQuotaHistoryDataGridView.Name = "uxSalesPersonQuotaHistoryDataGridView";
			this.uxSalesPersonQuotaHistoryDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesPersonQuotaHistoryDataGridView.TabIndex = 0;	
			this.uxSalesPersonQuotaHistoryDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesPersonQuotaHistoryDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesPersonQuotaHistoryDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesPersonQuotaHistoryDataGridViewDataError);
			this.uxSalesPersonQuotaHistoryDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesPersonQuotaHistoryDataGridViewCellValueNeeded);
			this.uxSalesPersonQuotaHistoryDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesPersonQuotaHistoryDataGridViewCellValuePushed);
			
			//
			// uxSalesPersonIdDataGridViewColumn
			//
			this.uxSalesPersonIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesPersonIdDataGridViewColumn.DataPropertyName = "SalesPersonId";
			this.uxSalesPersonIdDataGridViewColumn.HeaderText = "SalesPersonId";
			this.uxSalesPersonIdDataGridViewColumn.Name = "uxSalesPersonIdDataGridViewColumn";
			this.uxSalesPersonIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesPersonIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesPersonIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxQuotaDateDataGridViewColumn
			//
			this.uxQuotaDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxQuotaDateDataGridViewColumn.DataPropertyName = "QuotaDate";
			this.uxQuotaDateDataGridViewColumn.HeaderText = "QuotaDate";
			this.uxQuotaDateDataGridViewColumn.Name = "uxQuotaDateDataGridViewColumn";
			this.uxQuotaDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxQuotaDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxQuotaDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxSalesQuotaDataGridViewColumn
			//
			this.uxSalesQuotaDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesQuotaDataGridViewColumn.DataPropertyName = "SalesQuota";
			this.uxSalesQuotaDataGridViewColumn.HeaderText = "SalesQuota";
			this.uxSalesQuotaDataGridViewColumn.Name = "uxSalesQuotaDataGridViewColumn";
			this.uxSalesQuotaDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesQuotaDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesQuotaDataGridViewColumn.ReadOnly = false;		
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
			// uxSalesPersonIdDataGridViewColumn
			//				
			this.uxSalesPersonIdDataGridViewColumn.DisplayMember = "TerritoryId";	
			this.uxSalesPersonIdDataGridViewColumn.ValueMember = "SalesPersonId";	
			this.uxSalesPersonIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSalesPersonIdDataGridViewColumn.DataSource = uxSalesPersonIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxSalesPersonQuotaHistoryDataGridView);
			this.Name = "SalesPersonQuotaHistoryDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonQuotaHistoryErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonQuotaHistoryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesPersonQuotaHistoryBindingSource)).EndInit();
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
				SalesPersonQuotaHistoryDataGridViewEventArgs args = new SalesPersonQuotaHistoryDataGridViewEventArgs();
				args.SalesPersonQuotaHistory = _currentSalesPersonQuotaHistory;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesPersonQuotaHistoryDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesPersonQuotaHistory	_SalesPersonQuotaHistory;
	
			/// <summary>
			/// the  Entities.SalesPersonQuotaHistory instance.
			/// </summary>
			public Entities.SalesPersonQuotaHistory SalesPersonQuotaHistory
			{
				get { return _SalesPersonQuotaHistory; }
				set { _SalesPersonQuotaHistory = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesPersonQuotaHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesPersonQuotaHistoryDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesPersonQuotaHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesPersonQuotaHistoryDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesPersonQuotaHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesPersonIdDataGridViewColumn":
						e.Value = SalesPersonQuotaHistoryList[e.RowIndex].SalesPersonId;
						break;
					case "uxQuotaDateDataGridViewColumn":
						e.Value = SalesPersonQuotaHistoryList[e.RowIndex].QuotaDate;
						break;
					case "uxSalesQuotaDataGridViewColumn":
						e.Value = SalesPersonQuotaHistoryList[e.RowIndex].SalesQuota;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SalesPersonQuotaHistoryList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesPersonQuotaHistoryList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesPersonQuotaHistoryDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesPersonQuotaHistoryDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesPersonQuotaHistoryDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesPersonIdDataGridViewColumn":
						SalesPersonQuotaHistoryList[e.RowIndex].SalesPersonId = (System.Int32)e.Value;
						break;
					case "uxQuotaDateDataGridViewColumn":
						SalesPersonQuotaHistoryList[e.RowIndex].QuotaDate = (System.DateTime)e.Value;
						break;
					case "uxSalesQuotaDataGridViewColumn":
						SalesPersonQuotaHistoryList[e.RowIndex].SalesQuota = (System.Decimal)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SalesPersonQuotaHistoryList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesPersonQuotaHistoryList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
