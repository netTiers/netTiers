
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TestIssue117Tablec typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestIssue117TablecDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TestIssue117TablecDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TestIssue117Tablec _currentTestIssue117Tablec = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTestIssue117TablecDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTestIssue117TablecErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTestIssue117TablecBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the TestIssue117TableAid property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxTestIssue117TableAidDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the TestIssue117TableBid property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxTestIssue117TableBidDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DumbField property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxDumbFieldDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.TestIssue117Tablea> _TestIssue117TableAidList;
		
		/// <summary> 
		/// The list of selectable TestIssue117Tablea
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.TestIssue117Tablea> TestIssue117TableAidList
		{
			get {return this._TestIssue117TableAidList;}
			set 
			{
				this._TestIssue117TableAidList = value;
				this.uxTestIssue117TableAidDataGridViewColumn.DataSource = null;
				this.uxTestIssue117TableAidDataGridViewColumn.DataSource = this._TestIssue117TableAidList;
			}
		}
		
		private bool _allowNewItemInTestIssue117TableAidList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of TestIssue117Tablea
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInTestIssue117TableAidList
		{
			get { return _allowNewItemInTestIssue117TableAidList;}
			set
			{
				this._allowNewItemInTestIssue117TableAidList = value;
				this.uxTestIssue117TableAidDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.TestIssue117Tableb> _TestIssue117TableBidList;
		
		/// <summary> 
		/// The list of selectable TestIssue117Tableb
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.TestIssue117Tableb> TestIssue117TableBidList
		{
			get {return this._TestIssue117TableBidList;}
			set 
			{
				this._TestIssue117TableBidList = value;
				this.uxTestIssue117TableBidDataGridViewColumn.DataSource = null;
				this.uxTestIssue117TableBidDataGridViewColumn.DataSource = this._TestIssue117TableBidList;
			}
		}
		
		private bool _allowNewItemInTestIssue117TableBidList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of TestIssue117Tableb
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInTestIssue117TableBidList
		{
			get { return _allowNewItemInTestIssue117TableBidList;}
			set
			{
				this._allowNewItemInTestIssue117TableBidList = value;
				this.uxTestIssue117TableBidDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.TestIssue117Tablec> _TestIssue117TablecList;
				
		/// <summary> 
		/// The list of TestIssue117Tablec to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TestIssue117Tablec> TestIssue117TablecList
		{
			get {return this._TestIssue117TablecList;}
			set
			{
				this._TestIssue117TablecList = value;
				this.uxTestIssue117TablecBindingSource.DataSource = null;
				this.uxTestIssue117TablecBindingSource.DataSource = value;
				this.uxTestIssue117TablecDataGridView.DataSource = null;
				this.uxTestIssue117TablecDataGridView.DataSource = this.uxTestIssue117TablecBindingSource;				
				//this.uxTestIssue117TablecBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTestIssue117TablecBindingSource_ListChanged);
				this.uxTestIssue117TablecBindingSource.CurrentItemChanged += new System.EventHandler(OnTestIssue117TablecBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTestIssue117TablecBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTestIssue117Tablec = uxTestIssue117TablecBindingSource.Current as Entities.TestIssue117Tablec;
			
			if (_currentTestIssue117Tablec != null)
			{
				_currentTestIssue117Tablec.Validate();
			}
			//_TestIssue117Tablec.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTestIssue117TablecBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <c cref="Entities.TestIssue117Tablec"/> instance.
		/// </summary>
		public Entities.TestIssue117Tablec SelectedTestIssue117Tablec
		{
			get {return this._currentTestIssue117Tablec;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTestIssue117TablecDataGridView.VirtualMode;}
			set
			{
				this.uxTestIssue117TablecDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTestIssue117TablecDataGridView.AllowUserToAddRows;}
			set {this.uxTestIssue117TablecDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTestIssue117TablecDataGridView.AllowUserToDeleteRows;}
			set {this.uxTestIssue117TablecDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <c cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTestIssue117TablecDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTestIssue117TablecDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TestIssue117TablecDataGridViewBase"/> class.
		/// </summary>
		public TestIssue117TablecDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTestIssue117TablecDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTestIssue117TablecBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTestIssue117TablecErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTestIssue117TableAidDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxTestIssue117TableBidDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxDumbFieldDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			//this.uxTestIssue117TableAidBindingSource = new TestIssue117TableaBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableAidBindingSource)).BeginInit();
			//this.uxTestIssue117TableBidBindingSource = new TestIssue117TablebBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableBidBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablecDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablecBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablecErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTestIssue117TablecErrorProvider
			// 
			this.uxTestIssue117TablecErrorProvider.ContainerControl = this;
			this.uxTestIssue117TablecErrorProvider.DataSource = this.uxTestIssue117TablecBindingSource;						
			// 
			// uxTestIssue117TablecDataGridView
			// 
			this.uxTestIssue117TablecDataGridView.AutoGenerateColumns = false;
			this.uxTestIssue117TablecDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTestIssue117TablecDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTestIssue117TableAidDataGridViewColumn,
		this.uxTestIssue117TableBidDataGridViewColumn,
		this.uxDumbFieldDataGridViewColumn			});
			this.uxTestIssue117TablecDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTestIssue117TablecDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTestIssue117TablecDataGridView.Name = "uxTestIssue117TablecDataGridView";
			this.uxTestIssue117TablecDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTestIssue117TablecDataGridView.TabIndex = 0;	
			this.uxTestIssue117TablecDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTestIssue117TablecDataGridView.EnableHeadersVisualStyles = false;
			this.uxTestIssue117TablecDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTestIssue117TablecDataGridViewDataError);
			this.uxTestIssue117TablecDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestIssue117TablecDataGridViewCellValueNeeded);
			this.uxTestIssue117TablecDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestIssue117TablecDataGridViewCellValuePushed);
			
			//
			// uxTestIssue117TableAidDataGridViewColumn
			//
			this.uxTestIssue117TableAidDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTestIssue117TableAidDataGridViewColumn.DataPropertyName = "TestIssue117TableAid";
			this.uxTestIssue117TableAidDataGridViewColumn.HeaderText = "TestIssue117TableAid";
			this.uxTestIssue117TableAidDataGridViewColumn.Name = "uxTestIssue117TableAidDataGridViewColumn";
			this.uxTestIssue117TableAidDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTestIssue117TableAidDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTestIssue117TableAidDataGridViewColumn.ReadOnly = false;		
			//
			// uxTestIssue117TableBidDataGridViewColumn
			//
			this.uxTestIssue117TableBidDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTestIssue117TableBidDataGridViewColumn.DataPropertyName = "TestIssue117TableBid";
			this.uxTestIssue117TableBidDataGridViewColumn.HeaderText = "TestIssue117TableBid";
			this.uxTestIssue117TableBidDataGridViewColumn.Name = "uxTestIssue117TableBidDataGridViewColumn";
			this.uxTestIssue117TableBidDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTestIssue117TableBidDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTestIssue117TableBidDataGridViewColumn.ReadOnly = false;		
			//
			// uxDumbFieldDataGridViewColumn
			//
			this.uxDumbFieldDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDumbFieldDataGridViewColumn.DataPropertyName = "DumbField";
			this.uxDumbFieldDataGridViewColumn.HeaderText = "DumbField";
			this.uxDumbFieldDataGridViewColumn.Name = "uxDumbFieldDataGridViewColumn";
			this.uxDumbFieldDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDumbFieldDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDumbFieldDataGridViewColumn.ReadOnly = false;		
			//
			// uxTestIssue117TableAidDataGridViewColumn
			//				
			this.uxTestIssue117TableAidDataGridViewColumn.DisplayMember = "DumbField";	
			this.uxTestIssue117TableAidDataGridViewColumn.ValueMember = "TestIssue117TableAid";	
			this.uxTestIssue117TableAidDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxTestIssue117TableAidDataGridViewColumn.DataSource = uxTestIssue117TableAidBindingSource;				
				
			//
			// uxTestIssue117TableBidDataGridViewColumn
			//				
			this.uxTestIssue117TableBidDataGridViewColumn.DisplayMember = "DumbField";	
			this.uxTestIssue117TableBidDataGridViewColumn.ValueMember = "TestIssue117TableBid";	
			this.uxTestIssue117TableBidDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxTestIssue117TableBidDataGridViewColumn.DataSource = uxTestIssue117TableBidBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxTestIssue117TablecDataGridView);
			this.Name = "TestIssue117TablecDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableAidBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableBidBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablecErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablecDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablecBindingSource)).EndInit();
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
				TestIssue117TablecDataGridViewEventArgs args = new TestIssue117TablecDataGridViewEventArgs();
				args.TestIssue117Tablec = _currentTestIssue117Tablec;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TestIssue117TablecDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TestIssue117Tablec	_TestIssue117Tablec;
	
			/// <summary>
			/// the  Entities.TestIssue117Tablec instance.
			/// </summary>
			public Entities.TestIssue117Tablec TestIssue117Tablec
			{
				get { return _TestIssue117Tablec; }
				set { _TestIssue117Tablec = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTestIssue117TablecDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TablecDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTestIssue117TablecDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TablecDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestIssue117TablecDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestIssue117TableAidDataGridViewColumn":
						e.Value = TestIssue117TablecList[e.RowIndex].TestIssue117TableAid;
						break;
					case "uxTestIssue117TableBidDataGridViewColumn":
						e.Value = TestIssue117TablecList[e.RowIndex].TestIssue117TableBid;
						break;
					case "uxDumbFieldDataGridViewColumn":
						e.Value = TestIssue117TablecList[e.RowIndex].DumbField;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTestIssue117TablecDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TablecDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestIssue117TablecDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestIssue117TableAidDataGridViewColumn":
						TestIssue117TablecList[e.RowIndex].TestIssue117TableAid = (System.Int32)e.Value;
						break;
					case "uxTestIssue117TableBidDataGridViewColumn":
						TestIssue117TablecList[e.RowIndex].TestIssue117TableBid = (System.Int32)e.Value;
						break;
					case "uxDumbFieldDataGridViewColumn":
						TestIssue117TablecList[e.RowIndex].DumbField = (System.Boolean?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
