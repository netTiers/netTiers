
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesTaxRate typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesTaxRateDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesTaxRateDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesTaxRate _currentSalesTaxRate = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesTaxRateDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesTaxRateErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesTaxRateBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the SalesTaxRateId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesTaxRateIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the StateProvinceId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxStateProvinceIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TaxType property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTaxTypeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TaxRate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTaxRateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.StateProvince> _StateProvinceIdList;
		
		/// <summary> 
		/// The list of selectable StateProvince
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.StateProvince> StateProvinceIdList
		{
			get {return this._StateProvinceIdList;}
			set 
			{
				this._StateProvinceIdList = value;
				this.uxStateProvinceIdDataGridViewColumn.DataSource = null;
				this.uxStateProvinceIdDataGridViewColumn.DataSource = this._StateProvinceIdList;
			}
		}
		
		private bool _allowNewItemInStateProvinceIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of StateProvince
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInStateProvinceIdList
		{
			get { return _allowNewItemInStateProvinceIdList;}
			set
			{
				this._allowNewItemInStateProvinceIdList = value;
				this.uxStateProvinceIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SalesTaxRate> _SalesTaxRateList;
				
		/// <summary> 
		/// The list of SalesTaxRate to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesTaxRate> SalesTaxRateList
		{
			get {return this._SalesTaxRateList;}
			set
			{
				this._SalesTaxRateList = value;
				this.uxSalesTaxRateBindingSource.DataSource = null;
				this.uxSalesTaxRateBindingSource.DataSource = value;
				this.uxSalesTaxRateDataGridView.DataSource = null;
				this.uxSalesTaxRateDataGridView.DataSource = this.uxSalesTaxRateBindingSource;				
				//this.uxSalesTaxRateBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesTaxRateBindingSource_ListChanged);
				this.uxSalesTaxRateBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesTaxRateBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesTaxRateBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesTaxRate = uxSalesTaxRateBindingSource.Current as Entities.SalesTaxRate;
			
			if (_currentSalesTaxRate != null)
			{
				_currentSalesTaxRate.Validate();
			}
			//_SalesTaxRate.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesTaxRateBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesTaxRate"/> instance.
		/// </summary>
		public Entities.SalesTaxRate SelectedSalesTaxRate
		{
			get {return this._currentSalesTaxRate;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesTaxRateDataGridView.VirtualMode;}
			set
			{
				this.uxSalesTaxRateDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesTaxRateDataGridView.AllowUserToAddRows;}
			set {this.uxSalesTaxRateDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesTaxRateDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesTaxRateDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesTaxRateDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesTaxRateDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesTaxRateDataGridViewBase"/> class.
		/// </summary>
		public SalesTaxRateDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesTaxRateDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesTaxRateBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesTaxRateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSalesTaxRateIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStateProvinceIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxTaxTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTaxRateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxStateProvinceIdBindingSource = new StateProvinceBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTaxRateDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTaxRateBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTaxRateErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesTaxRateErrorProvider
			// 
			this.uxSalesTaxRateErrorProvider.ContainerControl = this;
			this.uxSalesTaxRateErrorProvider.DataSource = this.uxSalesTaxRateBindingSource;						
			// 
			// uxSalesTaxRateDataGridView
			// 
			this.uxSalesTaxRateDataGridView.AutoGenerateColumns = false;
			this.uxSalesTaxRateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesTaxRateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSalesTaxRateIdDataGridViewColumn,
		this.uxStateProvinceIdDataGridViewColumn,
		this.uxTaxTypeDataGridViewColumn,
		this.uxTaxRateDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesTaxRateDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesTaxRateDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesTaxRateDataGridView.Name = "uxSalesTaxRateDataGridView";
			this.uxSalesTaxRateDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesTaxRateDataGridView.TabIndex = 0;	
			this.uxSalesTaxRateDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesTaxRateDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesTaxRateDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesTaxRateDataGridViewDataError);
			this.uxSalesTaxRateDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesTaxRateDataGridViewCellValueNeeded);
			this.uxSalesTaxRateDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesTaxRateDataGridViewCellValuePushed);
			
			//
			// uxSalesTaxRateIdDataGridViewColumn
			//
			this.uxSalesTaxRateIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesTaxRateIdDataGridViewColumn.DataPropertyName = "SalesTaxRateId";
			this.uxSalesTaxRateIdDataGridViewColumn.HeaderText = "SalesTaxRateId";
			this.uxSalesTaxRateIdDataGridViewColumn.Name = "uxSalesTaxRateIdDataGridViewColumn";
			this.uxSalesTaxRateIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesTaxRateIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesTaxRateIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxStateProvinceIdDataGridViewColumn
			//
			this.uxStateProvinceIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStateProvinceIdDataGridViewColumn.DataPropertyName = "StateProvinceId";
			this.uxStateProvinceIdDataGridViewColumn.HeaderText = "StateProvinceId";
			this.uxStateProvinceIdDataGridViewColumn.Name = "uxStateProvinceIdDataGridViewColumn";
			this.uxStateProvinceIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStateProvinceIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStateProvinceIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxTaxTypeDataGridViewColumn
			//
			this.uxTaxTypeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTaxTypeDataGridViewColumn.DataPropertyName = "TaxType";
			this.uxTaxTypeDataGridViewColumn.HeaderText = "TaxType";
			this.uxTaxTypeDataGridViewColumn.Name = "uxTaxTypeDataGridViewColumn";
			this.uxTaxTypeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTaxTypeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTaxTypeDataGridViewColumn.ReadOnly = false;		
			//
			// uxTaxRateDataGridViewColumn
			//
			this.uxTaxRateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTaxRateDataGridViewColumn.DataPropertyName = "TaxRate";
			this.uxTaxRateDataGridViewColumn.HeaderText = "TaxRate";
			this.uxTaxRateDataGridViewColumn.Name = "uxTaxRateDataGridViewColumn";
			this.uxTaxRateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTaxRateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTaxRateDataGridViewColumn.ReadOnly = false;		
			//
			// uxNameDataGridViewColumn
			//
			this.uxNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxNameDataGridViewColumn.DataPropertyName = "Name";
			this.uxNameDataGridViewColumn.HeaderText = "Name";
			this.uxNameDataGridViewColumn.Name = "uxNameDataGridViewColumn";
			this.uxNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxNameDataGridViewColumn.ReadOnly = false;		
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
			// uxStateProvinceIdDataGridViewColumn
			//				
			this.uxStateProvinceIdDataGridViewColumn.DisplayMember = "StateProvinceCode";	
			this.uxStateProvinceIdDataGridViewColumn.ValueMember = "StateProvinceId";	
			this.uxStateProvinceIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxStateProvinceIdDataGridViewColumn.DataSource = uxStateProvinceIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxSalesTaxRateDataGridView);
			this.Name = "SalesTaxRateDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTaxRateErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTaxRateDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesTaxRateBindingSource)).EndInit();
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
				SalesTaxRateDataGridViewEventArgs args = new SalesTaxRateDataGridViewEventArgs();
				args.SalesTaxRate = _currentSalesTaxRate;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesTaxRateDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesTaxRate	_SalesTaxRate;
	
			/// <summary>
			/// the  Entities.SalesTaxRate instance.
			/// </summary>
			public Entities.SalesTaxRate SalesTaxRate
			{
				get { return _SalesTaxRate; }
				set { _SalesTaxRate = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesTaxRateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTaxRateDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesTaxRateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTaxRateDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesTaxRateDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesTaxRateIdDataGridViewColumn":
						e.Value = SalesTaxRateList[e.RowIndex].SalesTaxRateId;
						break;
					case "uxStateProvinceIdDataGridViewColumn":
						e.Value = SalesTaxRateList[e.RowIndex].StateProvinceId;
						break;
					case "uxTaxTypeDataGridViewColumn":
						e.Value = SalesTaxRateList[e.RowIndex].TaxType;
						break;
					case "uxTaxRateDataGridViewColumn":
						e.Value = SalesTaxRateList[e.RowIndex].TaxRate;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = SalesTaxRateList[e.RowIndex].Name;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SalesTaxRateList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesTaxRateList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesTaxRateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesTaxRateDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesTaxRateDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesTaxRateIdDataGridViewColumn":
						SalesTaxRateList[e.RowIndex].SalesTaxRateId = (System.Int32)e.Value;
						break;
					case "uxStateProvinceIdDataGridViewColumn":
						SalesTaxRateList[e.RowIndex].StateProvinceId = (System.Int32)e.Value;
						break;
					case "uxTaxTypeDataGridViewColumn":
						SalesTaxRateList[e.RowIndex].TaxType = (System.Byte)e.Value;
						break;
					case "uxTaxRateDataGridViewColumn":
						SalesTaxRateList[e.RowIndex].TaxRate = (System.Decimal)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						SalesTaxRateList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SalesTaxRateList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesTaxRateList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
