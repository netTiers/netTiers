
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract WorkOrderRouting typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class WorkOrderRoutingDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<WorkOrderRoutingDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.WorkOrderRouting _currentWorkOrderRouting = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxWorkOrderRoutingDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxWorkOrderRoutingErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxWorkOrderRoutingBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the WorkOrderId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxWorkOrderIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the OperationSequence property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxOperationSequenceDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the LocationId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxLocationIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ScheduledStartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxScheduledStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ScheduledEndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxScheduledEndDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ActualStartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxActualStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ActualEndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxActualEndDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ActualResourceHrs property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxActualResourceHrsDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PlannedCost property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPlannedCostDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Location> _LocationIdList;
		
		/// <summary> 
		/// The list of selectable Location
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Location> LocationIdList
		{
			get {return this._LocationIdList;}
			set 
			{
				this._LocationIdList = value;
				this.uxLocationIdDataGridViewColumn.DataSource = null;
				this.uxLocationIdDataGridViewColumn.DataSource = this._LocationIdList;
			}
		}
		
		private bool _allowNewItemInLocationIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Location
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInLocationIdList
		{
			get { return _allowNewItemInLocationIdList;}
			set
			{
				this._allowNewItemInLocationIdList = value;
				this.uxLocationIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.WorkOrder> _WorkOrderIdList;
		
		/// <summary> 
		/// The list of selectable WorkOrder
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.WorkOrder> WorkOrderIdList
		{
			get {return this._WorkOrderIdList;}
			set 
			{
				this._WorkOrderIdList = value;
				this.uxWorkOrderIdDataGridViewColumn.DataSource = null;
				this.uxWorkOrderIdDataGridViewColumn.DataSource = this._WorkOrderIdList;
			}
		}
		
		private bool _allowNewItemInWorkOrderIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of WorkOrder
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInWorkOrderIdList
		{
			get { return _allowNewItemInWorkOrderIdList;}
			set
			{
				this._allowNewItemInWorkOrderIdList = value;
				this.uxWorkOrderIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.WorkOrderRouting> _WorkOrderRoutingList;
				
		/// <summary> 
		/// The list of WorkOrderRouting to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.WorkOrderRouting> WorkOrderRoutingList
		{
			get {return this._WorkOrderRoutingList;}
			set
			{
				this._WorkOrderRoutingList = value;
				this.uxWorkOrderRoutingBindingSource.DataSource = null;
				this.uxWorkOrderRoutingBindingSource.DataSource = value;
				this.uxWorkOrderRoutingDataGridView.DataSource = null;
				this.uxWorkOrderRoutingDataGridView.DataSource = this.uxWorkOrderRoutingBindingSource;				
				//this.uxWorkOrderRoutingBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxWorkOrderRoutingBindingSource_ListChanged);
				this.uxWorkOrderRoutingBindingSource.CurrentItemChanged += new System.EventHandler(OnWorkOrderRoutingBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnWorkOrderRoutingBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentWorkOrderRouting = uxWorkOrderRoutingBindingSource.Current as Entities.WorkOrderRouting;
			
			if (_currentWorkOrderRouting != null)
			{
				_currentWorkOrderRouting.Validate();
			}
			//_WorkOrderRouting.Validate();
			OnCurrentEntityChanged();
		}

		//void uxWorkOrderRoutingBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.WorkOrderRouting"/> instance.
		/// </summary>
		public Entities.WorkOrderRouting SelectedWorkOrderRouting
		{
			get {return this._currentWorkOrderRouting;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxWorkOrderRoutingDataGridView.VirtualMode;}
			set
			{
				this.uxWorkOrderRoutingDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxWorkOrderRoutingDataGridView.AllowUserToAddRows;}
			set {this.uxWorkOrderRoutingDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxWorkOrderRoutingDataGridView.AllowUserToDeleteRows;}
			set {this.uxWorkOrderRoutingDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxWorkOrderRoutingDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxWorkOrderRoutingDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="WorkOrderRoutingDataGridViewBase"/> class.
		/// </summary>
		public WorkOrderRoutingDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxWorkOrderRoutingDataGridView = new System.Windows.Forms.DataGridView();
			this.uxWorkOrderRoutingBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxWorkOrderRoutingErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxWorkOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxOperationSequenceDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLocationIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxScheduledStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxScheduledEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxActualStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxActualEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxActualResourceHrsDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPlannedCostDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxActualCostDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxLocationIdBindingSource = new LocationBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxLocationIdBindingSource)).BeginInit();
			//this.uxWorkOrderIdBindingSource = new WorkOrderBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderRoutingDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderRoutingBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderRoutingErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxWorkOrderRoutingErrorProvider
			// 
			this.uxWorkOrderRoutingErrorProvider.ContainerControl = this;
			this.uxWorkOrderRoutingErrorProvider.DataSource = this.uxWorkOrderRoutingBindingSource;						
			// 
			// uxWorkOrderRoutingDataGridView
			// 
			this.uxWorkOrderRoutingDataGridView.AutoGenerateColumns = false;
			this.uxWorkOrderRoutingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxWorkOrderRoutingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxWorkOrderIdDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxOperationSequenceDataGridViewColumn,
		this.uxLocationIdDataGridViewColumn,
		this.uxScheduledStartDateDataGridViewColumn,
		this.uxScheduledEndDateDataGridViewColumn,
		this.uxActualStartDateDataGridViewColumn,
		this.uxActualEndDateDataGridViewColumn,
		this.uxActualResourceHrsDataGridViewColumn,
		this.uxPlannedCostDataGridViewColumn,
		this.uxActualCostDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxWorkOrderRoutingDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxWorkOrderRoutingDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxWorkOrderRoutingDataGridView.Name = "uxWorkOrderRoutingDataGridView";
			this.uxWorkOrderRoutingDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxWorkOrderRoutingDataGridView.TabIndex = 0;	
			this.uxWorkOrderRoutingDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxWorkOrderRoutingDataGridView.EnableHeadersVisualStyles = false;
			this.uxWorkOrderRoutingDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnWorkOrderRoutingDataGridViewDataError);
			this.uxWorkOrderRoutingDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnWorkOrderRoutingDataGridViewCellValueNeeded);
			this.uxWorkOrderRoutingDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnWorkOrderRoutingDataGridViewCellValuePushed);
			
			//
			// uxWorkOrderIdDataGridViewColumn
			//
			this.uxWorkOrderIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxWorkOrderIdDataGridViewColumn.DataPropertyName = "WorkOrderId";
			this.uxWorkOrderIdDataGridViewColumn.HeaderText = "WorkOrderId";
			this.uxWorkOrderIdDataGridViewColumn.Name = "uxWorkOrderIdDataGridViewColumn";
			this.uxWorkOrderIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxWorkOrderIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxWorkOrderIdDataGridViewColumn.ReadOnly = false;		
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
			// uxOperationSequenceDataGridViewColumn
			//
			this.uxOperationSequenceDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxOperationSequenceDataGridViewColumn.DataPropertyName = "OperationSequence";
			this.uxOperationSequenceDataGridViewColumn.HeaderText = "OperationSequence";
			this.uxOperationSequenceDataGridViewColumn.Name = "uxOperationSequenceDataGridViewColumn";
			this.uxOperationSequenceDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxOperationSequenceDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxOperationSequenceDataGridViewColumn.ReadOnly = false;		
			//
			// uxLocationIdDataGridViewColumn
			//
			this.uxLocationIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLocationIdDataGridViewColumn.DataPropertyName = "LocationId";
			this.uxLocationIdDataGridViewColumn.HeaderText = "LocationId";
			this.uxLocationIdDataGridViewColumn.Name = "uxLocationIdDataGridViewColumn";
			this.uxLocationIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLocationIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLocationIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxScheduledStartDateDataGridViewColumn
			//
			this.uxScheduledStartDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxScheduledStartDateDataGridViewColumn.DataPropertyName = "ScheduledStartDate";
			this.uxScheduledStartDateDataGridViewColumn.HeaderText = "ScheduledStartDate";
			this.uxScheduledStartDateDataGridViewColumn.Name = "uxScheduledStartDateDataGridViewColumn";
			this.uxScheduledStartDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxScheduledStartDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxScheduledStartDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxScheduledEndDateDataGridViewColumn
			//
			this.uxScheduledEndDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxScheduledEndDateDataGridViewColumn.DataPropertyName = "ScheduledEndDate";
			this.uxScheduledEndDateDataGridViewColumn.HeaderText = "ScheduledEndDate";
			this.uxScheduledEndDateDataGridViewColumn.Name = "uxScheduledEndDateDataGridViewColumn";
			this.uxScheduledEndDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxScheduledEndDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxScheduledEndDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxActualStartDateDataGridViewColumn
			//
			this.uxActualStartDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxActualStartDateDataGridViewColumn.DataPropertyName = "ActualStartDate";
			this.uxActualStartDateDataGridViewColumn.HeaderText = "ActualStartDate";
			this.uxActualStartDateDataGridViewColumn.Name = "uxActualStartDateDataGridViewColumn";
			this.uxActualStartDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxActualStartDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxActualStartDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxActualEndDateDataGridViewColumn
			//
			this.uxActualEndDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxActualEndDateDataGridViewColumn.DataPropertyName = "ActualEndDate";
			this.uxActualEndDateDataGridViewColumn.HeaderText = "ActualEndDate";
			this.uxActualEndDateDataGridViewColumn.Name = "uxActualEndDateDataGridViewColumn";
			this.uxActualEndDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxActualEndDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxActualEndDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxActualResourceHrsDataGridViewColumn
			//
			this.uxActualResourceHrsDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxActualResourceHrsDataGridViewColumn.DataPropertyName = "ActualResourceHrs";
			this.uxActualResourceHrsDataGridViewColumn.HeaderText = "ActualResourceHrs";
			this.uxActualResourceHrsDataGridViewColumn.Name = "uxActualResourceHrsDataGridViewColumn";
			this.uxActualResourceHrsDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxActualResourceHrsDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxActualResourceHrsDataGridViewColumn.ReadOnly = false;		
			//
			// uxPlannedCostDataGridViewColumn
			//
			this.uxPlannedCostDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPlannedCostDataGridViewColumn.DataPropertyName = "PlannedCost";
			this.uxPlannedCostDataGridViewColumn.HeaderText = "PlannedCost";
			this.uxPlannedCostDataGridViewColumn.Name = "uxPlannedCostDataGridViewColumn";
			this.uxPlannedCostDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPlannedCostDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPlannedCostDataGridViewColumn.ReadOnly = false;		
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
			// uxLocationIdDataGridViewColumn
			//				
			this.uxLocationIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxLocationIdDataGridViewColumn.ValueMember = "LocationId";	
			this.uxLocationIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxLocationIdDataGridViewColumn.DataSource = uxLocationIdBindingSource;				
				
			//
			// uxWorkOrderIdDataGridViewColumn
			//				
			this.uxWorkOrderIdDataGridViewColumn.DisplayMember = "ProductId";	
			this.uxWorkOrderIdDataGridViewColumn.ValueMember = "WorkOrderId";	
			this.uxWorkOrderIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxWorkOrderIdDataGridViewColumn.DataSource = uxWorkOrderIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxWorkOrderRoutingDataGridView);
			this.Name = "WorkOrderRoutingDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxLocationIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderRoutingErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderRoutingDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxWorkOrderRoutingBindingSource)).EndInit();
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
				WorkOrderRoutingDataGridViewEventArgs args = new WorkOrderRoutingDataGridViewEventArgs();
				args.WorkOrderRouting = _currentWorkOrderRouting;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class WorkOrderRoutingDataGridViewEventArgs : System.EventArgs
		{
			private Entities.WorkOrderRouting	_WorkOrderRouting;
	
			/// <summary>
			/// the  Entities.WorkOrderRouting instance.
			/// </summary>
			public Entities.WorkOrderRouting WorkOrderRouting
			{
				get { return _WorkOrderRouting; }
				set { _WorkOrderRouting = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxWorkOrderRoutingDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnWorkOrderRoutingDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxWorkOrderRoutingDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnWorkOrderRoutingDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxWorkOrderRoutingDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxWorkOrderIdDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].WorkOrderId;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].ProductId;
						break;
					case "uxOperationSequenceDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].OperationSequence;
						break;
					case "uxLocationIdDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].LocationId;
						break;
					case "uxScheduledStartDateDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].ScheduledStartDate;
						break;
					case "uxScheduledEndDateDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].ScheduledEndDate;
						break;
					case "uxActualStartDateDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].ActualStartDate;
						break;
					case "uxActualEndDateDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].ActualEndDate;
						break;
					case "uxActualResourceHrsDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].ActualResourceHrs;
						break;
					case "uxPlannedCostDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].PlannedCost;
						break;
					case "uxActualCostDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].ActualCost;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = WorkOrderRoutingList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxWorkOrderRoutingDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnWorkOrderRoutingDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxWorkOrderRoutingDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxWorkOrderIdDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].WorkOrderId = (System.Int32)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxOperationSequenceDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].OperationSequence = (System.Int16)e.Value;
						break;
					case "uxLocationIdDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].LocationId = (System.Int16)e.Value;
						break;
					case "uxScheduledStartDateDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].ScheduledStartDate = (System.DateTime)e.Value;
						break;
					case "uxScheduledEndDateDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].ScheduledEndDate = (System.DateTime)e.Value;
						break;
					case "uxActualStartDateDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].ActualStartDate = (System.DateTime?)e.Value;
						break;
					case "uxActualEndDateDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].ActualEndDate = (System.DateTime?)e.Value;
						break;
					case "uxActualResourceHrsDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].ActualResourceHrs = (System.Decimal?)e.Value;
						break;
					case "uxPlannedCostDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].PlannedCost = (System.Decimal)e.Value;
						break;
					case "uxActualCostDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].ActualCost = (System.Decimal?)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						WorkOrderRoutingList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
