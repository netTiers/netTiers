
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesOrderHeaderSalesReason typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesOrderHeaderSalesReasonDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesOrderHeaderSalesReasonDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesOrderHeaderSalesReason _currentSalesOrderHeaderSalesReason = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesOrderHeaderSalesReasonDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesOrderHeaderSalesReasonErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesOrderHeaderSalesReasonBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the SalesOrderId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSalesOrderIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the SalesReasonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxSalesReasonIdDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.SalesReason> _SalesReasonIdList;
		
		/// <summary> 
		/// The list of selectable SalesReason
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.SalesReason> SalesReasonIdList
		{
			get {return this._SalesReasonIdList;}
			set 
			{
				this._SalesReasonIdList = value;
				this.uxSalesReasonIdDataGridViewColumn.DataSource = null;
				this.uxSalesReasonIdDataGridViewColumn.DataSource = this._SalesReasonIdList;
			}
		}
		
		private bool _allowNewItemInSalesReasonIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of SalesReason
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSalesReasonIdList
		{
			get { return _allowNewItemInSalesReasonIdList;}
			set
			{
				this._allowNewItemInSalesReasonIdList = value;
				this.uxSalesReasonIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SalesOrderHeaderSalesReason> _SalesOrderHeaderSalesReasonList;
				
		/// <summary> 
		/// The list of SalesOrderHeaderSalesReason to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonList
		{
			get {return this._SalesOrderHeaderSalesReasonList;}
			set
			{
				this._SalesOrderHeaderSalesReasonList = value;
				this.uxSalesOrderHeaderSalesReasonBindingSource.DataSource = null;
				this.uxSalesOrderHeaderSalesReasonBindingSource.DataSource = value;
				this.uxSalesOrderHeaderSalesReasonDataGridView.DataSource = null;
				this.uxSalesOrderHeaderSalesReasonDataGridView.DataSource = this.uxSalesOrderHeaderSalesReasonBindingSource;				
				//this.uxSalesOrderHeaderSalesReasonBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesOrderHeaderSalesReasonBindingSource_ListChanged);
				this.uxSalesOrderHeaderSalesReasonBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesOrderHeaderSalesReasonBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesOrderHeaderSalesReasonBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesOrderHeaderSalesReason = uxSalesOrderHeaderSalesReasonBindingSource.Current as Entities.SalesOrderHeaderSalesReason;
			
			if (_currentSalesOrderHeaderSalesReason != null)
			{
				_currentSalesOrderHeaderSalesReason.Validate();
			}
			//_SalesOrderHeaderSalesReason.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesOrderHeaderSalesReasonBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesOrderHeaderSalesReason"/> instance.
		/// </summary>
		public Entities.SalesOrderHeaderSalesReason SelectedSalesOrderHeaderSalesReason
		{
			get {return this._currentSalesOrderHeaderSalesReason;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesOrderHeaderSalesReasonDataGridView.VirtualMode;}
			set
			{
				this.uxSalesOrderHeaderSalesReasonDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesOrderHeaderSalesReasonDataGridView.AllowUserToAddRows;}
			set {this.uxSalesOrderHeaderSalesReasonDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesOrderHeaderSalesReasonDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesOrderHeaderSalesReasonDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesOrderHeaderSalesReasonDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesOrderHeaderSalesReasonDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesOrderHeaderSalesReasonDataGridViewBase"/> class.
		/// </summary>
		public SalesOrderHeaderSalesReasonDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesOrderHeaderSalesReasonDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesOrderHeaderSalesReasonBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesOrderHeaderSalesReasonErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSalesOrderIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSalesReasonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxSalesOrderIdBindingSource = new SalesOrderHeaderBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderIdBindingSource)).BeginInit();
			//this.uxSalesReasonIdBindingSource = new SalesReasonBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesReasonIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderSalesReasonDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderSalesReasonBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderSalesReasonErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesOrderHeaderSalesReasonErrorProvider
			// 
			this.uxSalesOrderHeaderSalesReasonErrorProvider.ContainerControl = this;
			this.uxSalesOrderHeaderSalesReasonErrorProvider.DataSource = this.uxSalesOrderHeaderSalesReasonBindingSource;						
			// 
			// uxSalesOrderHeaderSalesReasonDataGridView
			// 
			this.uxSalesOrderHeaderSalesReasonDataGridView.AutoGenerateColumns = false;
			this.uxSalesOrderHeaderSalesReasonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesOrderHeaderSalesReasonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSalesOrderIdDataGridViewColumn,
		this.uxSalesReasonIdDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesOrderHeaderSalesReasonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesOrderHeaderSalesReasonDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesOrderHeaderSalesReasonDataGridView.Name = "uxSalesOrderHeaderSalesReasonDataGridView";
			this.uxSalesOrderHeaderSalesReasonDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesOrderHeaderSalesReasonDataGridView.TabIndex = 0;	
			this.uxSalesOrderHeaderSalesReasonDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesOrderHeaderSalesReasonDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesOrderHeaderSalesReasonDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesOrderHeaderSalesReasonDataGridViewDataError);
			this.uxSalesOrderHeaderSalesReasonDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesOrderHeaderSalesReasonDataGridViewCellValueNeeded);
			this.uxSalesOrderHeaderSalesReasonDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesOrderHeaderSalesReasonDataGridViewCellValuePushed);
			
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
			// uxSalesReasonIdDataGridViewColumn
			//
			this.uxSalesReasonIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesReasonIdDataGridViewColumn.DataPropertyName = "SalesReasonId";
			this.uxSalesReasonIdDataGridViewColumn.HeaderText = "SalesReasonId";
			this.uxSalesReasonIdDataGridViewColumn.Name = "uxSalesReasonIdDataGridViewColumn";
			this.uxSalesReasonIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesReasonIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesReasonIdDataGridViewColumn.ReadOnly = false;		
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
			// uxSalesReasonIdDataGridViewColumn
			//				
			this.uxSalesReasonIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxSalesReasonIdDataGridViewColumn.ValueMember = "SalesReasonId";	
			this.uxSalesReasonIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxSalesReasonIdDataGridViewColumn.DataSource = uxSalesReasonIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxSalesOrderHeaderSalesReasonDataGridView);
			this.Name = "SalesOrderHeaderSalesReasonDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxSalesReasonIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderSalesReasonErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderSalesReasonDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesOrderHeaderSalesReasonBindingSource)).EndInit();
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
				SalesOrderHeaderSalesReasonDataGridViewEventArgs args = new SalesOrderHeaderSalesReasonDataGridViewEventArgs();
				args.SalesOrderHeaderSalesReason = _currentSalesOrderHeaderSalesReason;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesOrderHeaderSalesReasonDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesOrderHeaderSalesReason	_SalesOrderHeaderSalesReason;
	
			/// <summary>
			/// the  Entities.SalesOrderHeaderSalesReason instance.
			/// </summary>
			public Entities.SalesOrderHeaderSalesReason SalesOrderHeaderSalesReason
			{
				get { return _SalesOrderHeaderSalesReason; }
				set { _SalesOrderHeaderSalesReason = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesOrderHeaderSalesReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderHeaderSalesReasonDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesOrderHeaderSalesReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderHeaderSalesReasonDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesOrderHeaderSalesReasonDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesOrderIdDataGridViewColumn":
						e.Value = SalesOrderHeaderSalesReasonList[e.RowIndex].SalesOrderId;
						break;
					case "uxSalesReasonIdDataGridViewColumn":
						e.Value = SalesOrderHeaderSalesReasonList[e.RowIndex].SalesReasonId;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesOrderHeaderSalesReasonList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesOrderHeaderSalesReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesOrderHeaderSalesReasonDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesOrderHeaderSalesReasonDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesOrderIdDataGridViewColumn":
						SalesOrderHeaderSalesReasonList[e.RowIndex].SalesOrderId = (System.Int32)e.Value;
						break;
					case "uxSalesReasonIdDataGridViewColumn":
						SalesOrderHeaderSalesReasonList[e.RowIndex].SalesReasonId = (System.Int32)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesOrderHeaderSalesReasonList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
