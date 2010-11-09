
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract BillOfMaterials typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class BillOfMaterialsDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<BillOfMaterialsDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.BillOfMaterials _currentBillOfMaterials = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxBillOfMaterialsDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxBillOfMaterialsErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxBillOfMaterialsBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the BillOfMaterialsId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBillOfMaterialsIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductAssemblyId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductAssemblyIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ComponentId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxComponentIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEndDateDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the UnitMeasureCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxUnitMeasureCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the BomLevel property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBomLevelDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PerAssemblyQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPerAssemblyQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Product> _ComponentIdList;
		
		/// <summary> 
		/// The list of selectable Product
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Product> ComponentIdList
		{
			get {return this._ComponentIdList;}
			set 
			{
				this._ComponentIdList = value;
				this.uxComponentIdDataGridViewColumn.DataSource = null;
				this.uxComponentIdDataGridViewColumn.DataSource = this._ComponentIdList;
			}
		}
		
		private bool _allowNewItemInComponentIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Product
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInComponentIdList
		{
			get { return _allowNewItemInComponentIdList;}
			set
			{
				this._allowNewItemInComponentIdList = value;
				this.uxComponentIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Product> _ProductAssemblyIdList;
		
		/// <summary> 
		/// The list of selectable Product
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Product> ProductAssemblyIdList
		{
			get {return this._ProductAssemblyIdList;}
			set 
			{
				this._ProductAssemblyIdList = value;
				this.uxProductAssemblyIdDataGridViewColumn.DataSource = null;
				this.uxProductAssemblyIdDataGridViewColumn.DataSource = this._ProductAssemblyIdList;
			}
		}
		
		private bool _allowNewItemInProductAssemblyIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Product
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductAssemblyIdList
		{
			get { return _allowNewItemInProductAssemblyIdList;}
			set
			{
				this._allowNewItemInProductAssemblyIdList = value;
				this.uxProductAssemblyIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.UnitMeasure> _UnitMeasureCodeList;
		
		/// <summary> 
		/// The list of selectable UnitMeasure
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.UnitMeasure> UnitMeasureCodeList
		{
			get {return this._UnitMeasureCodeList;}
			set 
			{
				this._UnitMeasureCodeList = value;
				this.uxUnitMeasureCodeDataGridViewColumn.DataSource = null;
				this.uxUnitMeasureCodeDataGridViewColumn.DataSource = this._UnitMeasureCodeList;
			}
		}
		
		private bool _allowNewItemInUnitMeasureCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of UnitMeasure
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInUnitMeasureCodeList
		{
			get { return _allowNewItemInUnitMeasureCodeList;}
			set
			{
				this._allowNewItemInUnitMeasureCodeList = value;
				this.uxUnitMeasureCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.BillOfMaterials> _BillOfMaterialsList;
				
		/// <summary> 
		/// The list of BillOfMaterials to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.BillOfMaterials> BillOfMaterialsList
		{
			get {return this._BillOfMaterialsList;}
			set
			{
				this._BillOfMaterialsList = value;
				this.uxBillOfMaterialsBindingSource.DataSource = null;
				this.uxBillOfMaterialsBindingSource.DataSource = value;
				this.uxBillOfMaterialsDataGridView.DataSource = null;
				this.uxBillOfMaterialsDataGridView.DataSource = this.uxBillOfMaterialsBindingSource;				
				//this.uxBillOfMaterialsBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxBillOfMaterialsBindingSource_ListChanged);
				this.uxBillOfMaterialsBindingSource.CurrentItemChanged += new System.EventHandler(OnBillOfMaterialsBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnBillOfMaterialsBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentBillOfMaterials = uxBillOfMaterialsBindingSource.Current as Entities.BillOfMaterials;
			
			if (_currentBillOfMaterials != null)
			{
				_currentBillOfMaterials.Validate();
			}
			//_BillOfMaterials.Validate();
			OnCurrentEntityChanged();
		}

		//void uxBillOfMaterialsBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.BillOfMaterials"/> instance.
		/// </summary>
		public Entities.BillOfMaterials SelectedBillOfMaterials
		{
			get {return this._currentBillOfMaterials;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxBillOfMaterialsDataGridView.VirtualMode;}
			set
			{
				this.uxBillOfMaterialsDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxBillOfMaterialsDataGridView.AllowUserToAddRows;}
			set {this.uxBillOfMaterialsDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxBillOfMaterialsDataGridView.AllowUserToDeleteRows;}
			set {this.uxBillOfMaterialsDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxBillOfMaterialsDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxBillOfMaterialsDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="BillOfMaterialsDataGridViewBase"/> class.
		/// </summary>
		public BillOfMaterialsDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxBillOfMaterialsDataGridView = new System.Windows.Forms.DataGridView();
			this.uxBillOfMaterialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxBillOfMaterialsErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxBillOfMaterialsIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductAssemblyIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxComponentIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUnitMeasureCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxBomLevelDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPerAssemblyQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxComponentIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxComponentIdBindingSource)).BeginInit();
			//this.uxProductAssemblyIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductAssemblyIdBindingSource)).BeginInit();
			//this.uxUnitMeasureCodeBindingSource = new UnitMeasureBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureCodeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBillOfMaterialsDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBillOfMaterialsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBillOfMaterialsErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxBillOfMaterialsErrorProvider
			// 
			this.uxBillOfMaterialsErrorProvider.ContainerControl = this;
			this.uxBillOfMaterialsErrorProvider.DataSource = this.uxBillOfMaterialsBindingSource;						
			// 
			// uxBillOfMaterialsDataGridView
			// 
			this.uxBillOfMaterialsDataGridView.AutoGenerateColumns = false;
			this.uxBillOfMaterialsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxBillOfMaterialsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxBillOfMaterialsIdDataGridViewColumn,
		this.uxProductAssemblyIdDataGridViewColumn,
		this.uxComponentIdDataGridViewColumn,
		this.uxStartDateDataGridViewColumn,
		this.uxEndDateDataGridViewColumn,
		this.uxUnitMeasureCodeDataGridViewColumn,
		this.uxBomLevelDataGridViewColumn,
		this.uxPerAssemblyQtyDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxBillOfMaterialsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxBillOfMaterialsDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxBillOfMaterialsDataGridView.Name = "uxBillOfMaterialsDataGridView";
			this.uxBillOfMaterialsDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxBillOfMaterialsDataGridView.TabIndex = 0;	
			this.uxBillOfMaterialsDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxBillOfMaterialsDataGridView.EnableHeadersVisualStyles = false;
			this.uxBillOfMaterialsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnBillOfMaterialsDataGridViewDataError);
			this.uxBillOfMaterialsDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBillOfMaterialsDataGridViewCellValueNeeded);
			this.uxBillOfMaterialsDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBillOfMaterialsDataGridViewCellValuePushed);
			
			//
			// uxBillOfMaterialsIdDataGridViewColumn
			//
			this.uxBillOfMaterialsIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBillOfMaterialsIdDataGridViewColumn.DataPropertyName = "BillOfMaterialsId";
			this.uxBillOfMaterialsIdDataGridViewColumn.HeaderText = "BillOfMaterialsId";
			this.uxBillOfMaterialsIdDataGridViewColumn.Name = "uxBillOfMaterialsIdDataGridViewColumn";
			this.uxBillOfMaterialsIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBillOfMaterialsIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBillOfMaterialsIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxProductAssemblyIdDataGridViewColumn
			//
			this.uxProductAssemblyIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductAssemblyIdDataGridViewColumn.DataPropertyName = "ProductAssemblyId";
			this.uxProductAssemblyIdDataGridViewColumn.HeaderText = "ProductAssemblyId";
			this.uxProductAssemblyIdDataGridViewColumn.Name = "uxProductAssemblyIdDataGridViewColumn";
			this.uxProductAssemblyIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductAssemblyIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductAssemblyIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxComponentIdDataGridViewColumn
			//
			this.uxComponentIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxComponentIdDataGridViewColumn.DataPropertyName = "ComponentId";
			this.uxComponentIdDataGridViewColumn.HeaderText = "ComponentId";
			this.uxComponentIdDataGridViewColumn.Name = "uxComponentIdDataGridViewColumn";
			this.uxComponentIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxComponentIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxComponentIdDataGridViewColumn.ReadOnly = false;		
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
			// uxUnitMeasureCodeDataGridViewColumn
			//
			this.uxUnitMeasureCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUnitMeasureCodeDataGridViewColumn.DataPropertyName = "UnitMeasureCode";
			this.uxUnitMeasureCodeDataGridViewColumn.HeaderText = "UnitMeasureCode";
			this.uxUnitMeasureCodeDataGridViewColumn.Name = "uxUnitMeasureCodeDataGridViewColumn";
			this.uxUnitMeasureCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUnitMeasureCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUnitMeasureCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxBomLevelDataGridViewColumn
			//
			this.uxBomLevelDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBomLevelDataGridViewColumn.DataPropertyName = "BomLevel";
			this.uxBomLevelDataGridViewColumn.HeaderText = "BomLevel";
			this.uxBomLevelDataGridViewColumn.Name = "uxBomLevelDataGridViewColumn";
			this.uxBomLevelDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBomLevelDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBomLevelDataGridViewColumn.ReadOnly = false;		
			//
			// uxPerAssemblyQtyDataGridViewColumn
			//
			this.uxPerAssemblyQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPerAssemblyQtyDataGridViewColumn.DataPropertyName = "PerAssemblyQty";
			this.uxPerAssemblyQtyDataGridViewColumn.HeaderText = "PerAssemblyQty";
			this.uxPerAssemblyQtyDataGridViewColumn.Name = "uxPerAssemblyQtyDataGridViewColumn";
			this.uxPerAssemblyQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPerAssemblyQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPerAssemblyQtyDataGridViewColumn.ReadOnly = false;		
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
			// uxComponentIdDataGridViewColumn
			//				
			this.uxComponentIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxComponentIdDataGridViewColumn.ValueMember = "ProductId";	
			this.uxComponentIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxComponentIdDataGridViewColumn.DataSource = uxComponentIdBindingSource;				
				
			//
			// uxProductAssemblyIdDataGridViewColumn
			//				
			this.uxProductAssemblyIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductAssemblyIdDataGridViewColumn.ValueMember = "ProductId";	
			this.uxProductAssemblyIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductAssemblyIdDataGridViewColumn.DataSource = uxProductAssemblyIdBindingSource;				
				
			//
			// uxUnitMeasureCodeDataGridViewColumn
			//				
			this.uxUnitMeasureCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxUnitMeasureCodeDataGridViewColumn.ValueMember = "UnitMeasureCode";	
			this.uxUnitMeasureCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxUnitMeasureCodeDataGridViewColumn.DataSource = uxUnitMeasureCodeBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxBillOfMaterialsDataGridView);
			this.Name = "BillOfMaterialsDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxComponentIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxProductAssemblyIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureCodeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBillOfMaterialsErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBillOfMaterialsDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBillOfMaterialsBindingSource)).EndInit();
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
				BillOfMaterialsDataGridViewEventArgs args = new BillOfMaterialsDataGridViewEventArgs();
				args.BillOfMaterials = _currentBillOfMaterials;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class BillOfMaterialsDataGridViewEventArgs : System.EventArgs
		{
			private Entities.BillOfMaterials	_BillOfMaterials;
	
			/// <summary>
			/// the  Entities.BillOfMaterials instance.
			/// </summary>
			public Entities.BillOfMaterials BillOfMaterials
			{
				get { return _BillOfMaterials; }
				set { _BillOfMaterials = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxBillOfMaterialsDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnBillOfMaterialsDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxBillOfMaterialsDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBillOfMaterialsDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBillOfMaterialsDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxBillOfMaterialsIdDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].BillOfMaterialsId;
						break;
					case "uxProductAssemblyIdDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].ProductAssemblyId;
						break;
					case "uxComponentIdDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].ComponentId;
						break;
					case "uxStartDateDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].StartDate;
						break;
					case "uxEndDateDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].EndDate;
						break;
					case "uxUnitMeasureCodeDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].UnitMeasureCode;
						break;
					case "uxBomLevelDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].BomLevel;
						break;
					case "uxPerAssemblyQtyDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].PerAssemblyQty;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = BillOfMaterialsList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxBillOfMaterialsDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBillOfMaterialsDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBillOfMaterialsDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxBillOfMaterialsIdDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].BillOfMaterialsId = (System.Int32)e.Value;
						break;
					case "uxProductAssemblyIdDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].ProductAssemblyId = (System.Int32?)e.Value;
						break;
					case "uxComponentIdDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].ComponentId = (System.Int32)e.Value;
						break;
					case "uxStartDateDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].StartDate = (System.DateTime)e.Value;
						break;
					case "uxEndDateDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].EndDate = (System.DateTime?)e.Value;
						break;
					case "uxUnitMeasureCodeDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].UnitMeasureCode = (System.String)e.Value;
						break;
					case "uxBomLevelDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].BomLevel = (System.Int16)e.Value;
						break;
					case "uxPerAssemblyQtyDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].PerAssemblyQty = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						BillOfMaterialsList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
