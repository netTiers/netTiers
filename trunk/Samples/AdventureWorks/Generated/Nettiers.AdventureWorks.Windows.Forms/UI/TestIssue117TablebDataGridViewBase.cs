
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TestIssue117Tableb typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestIssue117TablebDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TestIssue117TablebDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TestIssue117Tableb _currentTestIssue117Tableb = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTestIssue117TablebDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTestIssue117TablebErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTestIssue117TablebBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the TestIssue117TableBid property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTestIssue117TableBidDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DumbField property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxDumbFieldDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.TestIssue117Tableb> _TestIssue117TablebList;
				
		/// <summary> 
		/// The list of TestIssue117Tableb to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TestIssue117Tableb> TestIssue117TablebList
		{
			get {return this._TestIssue117TablebList;}
			set
			{
				this._TestIssue117TablebList = value;
				this.uxTestIssue117TablebBindingSource.DataSource = null;
				this.uxTestIssue117TablebBindingSource.DataSource = value;
				this.uxTestIssue117TablebDataGridView.DataSource = null;
				this.uxTestIssue117TablebDataGridView.DataSource = this.uxTestIssue117TablebBindingSource;				
				//this.uxTestIssue117TablebBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTestIssue117TablebBindingSource_ListChanged);
				this.uxTestIssue117TablebBindingSource.CurrentItemChanged += new System.EventHandler(OnTestIssue117TablebBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTestIssue117TablebBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTestIssue117Tableb = uxTestIssue117TablebBindingSource.Current as Entities.TestIssue117Tableb;
			
			if (_currentTestIssue117Tableb != null)
			{
				_currentTestIssue117Tableb.Validate();
			}
			//_TestIssue117Tableb.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTestIssue117TablebBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <c cref="Entities.TestIssue117Tableb"/> instance.
		/// </summary>
		public Entities.TestIssue117Tableb SelectedTestIssue117Tableb
		{
			get {return this._currentTestIssue117Tableb;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTestIssue117TablebDataGridView.VirtualMode;}
			set
			{
				this.uxTestIssue117TablebDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTestIssue117TablebDataGridView.AllowUserToAddRows;}
			set {this.uxTestIssue117TablebDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTestIssue117TablebDataGridView.AllowUserToDeleteRows;}
			set {this.uxTestIssue117TablebDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <c cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTestIssue117TablebDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTestIssue117TablebDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TestIssue117TablebDataGridViewBase"/> class.
		/// </summary>
		public TestIssue117TablebDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTestIssue117TablebDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTestIssue117TablebBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTestIssue117TablebErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTestIssue117TableBidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDumbFieldDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablebDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablebBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablebErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTestIssue117TablebErrorProvider
			// 
			this.uxTestIssue117TablebErrorProvider.ContainerControl = this;
			this.uxTestIssue117TablebErrorProvider.DataSource = this.uxTestIssue117TablebBindingSource;						
			// 
			// uxTestIssue117TablebDataGridView
			// 
			this.uxTestIssue117TablebDataGridView.AutoGenerateColumns = false;
			this.uxTestIssue117TablebDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTestIssue117TablebDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTestIssue117TableBidDataGridViewColumn,
		this.uxDumbFieldDataGridViewColumn			});
			this.uxTestIssue117TablebDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTestIssue117TablebDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTestIssue117TablebDataGridView.Name = "uxTestIssue117TablebDataGridView";
			this.uxTestIssue117TablebDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTestIssue117TablebDataGridView.TabIndex = 0;	
			this.uxTestIssue117TablebDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTestIssue117TablebDataGridView.EnableHeadersVisualStyles = false;
			this.uxTestIssue117TablebDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTestIssue117TablebDataGridViewDataError);
			this.uxTestIssue117TablebDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestIssue117TablebDataGridViewCellValueNeeded);
			this.uxTestIssue117TablebDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestIssue117TablebDataGridViewCellValuePushed);
			
			//
			// uxTestIssue117TableBidDataGridViewColumn
			//
			this.uxTestIssue117TableBidDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTestIssue117TableBidDataGridViewColumn.DataPropertyName = "TestIssue117TableBid";
			this.uxTestIssue117TableBidDataGridViewColumn.HeaderText = "TestIssue117TableBid";
			this.uxTestIssue117TableBidDataGridViewColumn.Name = "uxTestIssue117TableBidDataGridViewColumn";
			this.uxTestIssue117TableBidDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTestIssue117TableBidDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTestIssue117TableBidDataGridViewColumn.ReadOnly = true;		
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
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxTestIssue117TablebDataGridView);
			this.Name = "TestIssue117TablebDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablebErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablebDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TablebBindingSource)).EndInit();
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
				TestIssue117TablebDataGridViewEventArgs args = new TestIssue117TablebDataGridViewEventArgs();
				args.TestIssue117Tableb = _currentTestIssue117Tableb;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TestIssue117TablebDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TestIssue117Tableb	_TestIssue117Tableb;
	
			/// <summary>
			/// the  Entities.TestIssue117Tableb instance.
			/// </summary>
			public Entities.TestIssue117Tableb TestIssue117Tableb
			{
				get { return _TestIssue117Tableb; }
				set { _TestIssue117Tableb = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTestIssue117TablebDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TablebDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTestIssue117TablebDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TablebDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestIssue117TablebDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestIssue117TableBidDataGridViewColumn":
						e.Value = TestIssue117TablebList[e.RowIndex].TestIssue117TableBid;
						break;
					case "uxDumbFieldDataGridViewColumn":
						e.Value = TestIssue117TablebList[e.RowIndex].DumbField;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTestIssue117TablebDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TablebDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestIssue117TablebDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestIssue117TableBidDataGridViewColumn":
						TestIssue117TablebList[e.RowIndex].TestIssue117TableBid = (System.Int32)e.Value;
						break;
					case "uxDumbFieldDataGridViewColumn":
						TestIssue117TablebList[e.RowIndex].DumbField = (System.Boolean?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
