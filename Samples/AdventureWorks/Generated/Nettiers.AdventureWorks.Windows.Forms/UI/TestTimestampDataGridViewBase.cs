
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TestTimestamp typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestTimestampDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TestTimestampDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TestTimestamp _currentTestTimestamp = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTestTimestampDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTestTimestampErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTestTimestampBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the TestTimestampId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTestTimestampIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DumbField property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxDumbFieldDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Version property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxVersionDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.TestTimestamp> _TestTimestampList;
				
		/// <summary> 
		/// The list of TestTimestamp to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TestTimestamp> TestTimestampList
		{
			get {return this._TestTimestampList;}
			set
			{
				this._TestTimestampList = value;
				this.uxTestTimestampBindingSource.DataSource = null;
				this.uxTestTimestampBindingSource.DataSource = value;
				this.uxTestTimestampDataGridView.DataSource = null;
				this.uxTestTimestampDataGridView.DataSource = this.uxTestTimestampBindingSource;				
				//this.uxTestTimestampBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTestTimestampBindingSource_ListChanged);
				this.uxTestTimestampBindingSource.CurrentItemChanged += new System.EventHandler(OnTestTimestampBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTestTimestampBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTestTimestamp = uxTestTimestampBindingSource.Current as Entities.TestTimestamp;
			
			if (_currentTestTimestamp != null)
			{
				_currentTestTimestamp.Validate();
			}
			//_TestTimestamp.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTestTimestampBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <c cref="Entities.TestTimestamp"/> instance.
		/// </summary>
		public Entities.TestTimestamp SelectedTestTimestamp
		{
			get {return this._currentTestTimestamp;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTestTimestampDataGridView.VirtualMode;}
			set
			{
				this.uxTestTimestampDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTestTimestampDataGridView.AllowUserToAddRows;}
			set {this.uxTestTimestampDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTestTimestampDataGridView.AllowUserToDeleteRows;}
			set {this.uxTestTimestampDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <c cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTestTimestampDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTestTimestampDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TestTimestampDataGridViewBase"/> class.
		/// </summary>
		public TestTimestampDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTestTimestampDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTestTimestampBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTestTimestampErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTestTimestampIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDumbFieldDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxVersionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxTestTimestampDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestTimestampBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestTimestampErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTestTimestampErrorProvider
			// 
			this.uxTestTimestampErrorProvider.ContainerControl = this;
			this.uxTestTimestampErrorProvider.DataSource = this.uxTestTimestampBindingSource;						
			// 
			// uxTestTimestampDataGridView
			// 
			this.uxTestTimestampDataGridView.AutoGenerateColumns = false;
			this.uxTestTimestampDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTestTimestampDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTestTimestampIdDataGridViewColumn,
		this.uxDumbFieldDataGridViewColumn,
		this.uxVersionDataGridViewColumn			});
			this.uxTestTimestampDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTestTimestampDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTestTimestampDataGridView.Name = "uxTestTimestampDataGridView";
			this.uxTestTimestampDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTestTimestampDataGridView.TabIndex = 0;	
			this.uxTestTimestampDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTestTimestampDataGridView.EnableHeadersVisualStyles = false;
			this.uxTestTimestampDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTestTimestampDataGridViewDataError);
			this.uxTestTimestampDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestTimestampDataGridViewCellValueNeeded);
			this.uxTestTimestampDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestTimestampDataGridViewCellValuePushed);
			
			//
			// uxTestTimestampIdDataGridViewColumn
			//
			this.uxTestTimestampIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTestTimestampIdDataGridViewColumn.DataPropertyName = "TestTimestampId";
			this.uxTestTimestampIdDataGridViewColumn.HeaderText = "TestTimestampId";
			this.uxTestTimestampIdDataGridViewColumn.Name = "uxTestTimestampIdDataGridViewColumn";
			this.uxTestTimestampIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTestTimestampIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTestTimestampIdDataGridViewColumn.ReadOnly = true;		
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
			// uxVersionDataGridViewColumn
			//
			this.uxVersionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxVersionDataGridViewColumn.DataPropertyName = "Version";
			this.uxVersionDataGridViewColumn.HeaderText = "Version";
			this.uxVersionDataGridViewColumn.Name = "uxVersionDataGridViewColumn";
			this.uxVersionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxVersionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxVersionDataGridViewColumn.ReadOnly = true;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxTestTimestampDataGridView);
			this.Name = "TestTimestampDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxTestTimestampErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestTimestampDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestTimestampBindingSource)).EndInit();
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
				TestTimestampDataGridViewEventArgs args = new TestTimestampDataGridViewEventArgs();
				args.TestTimestamp = _currentTestTimestamp;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TestTimestampDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TestTimestamp	_TestTimestamp;
	
			/// <summary>
			/// the  Entities.TestTimestamp instance.
			/// </summary>
			public Entities.TestTimestamp TestTimestamp
			{
				get { return _TestTimestamp; }
				set { _TestTimestamp = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTestTimestampDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTestTimestampDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTestTimestampDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestTimestampDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestTimestampDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestTimestampIdDataGridViewColumn":
						e.Value = TestTimestampList[e.RowIndex].TestTimestampId;
						break;
					case "uxDumbFieldDataGridViewColumn":
						e.Value = TestTimestampList[e.RowIndex].DumbField;
						break;
					case "uxVersionDataGridViewColumn":
						e.Value = TestTimestampList[e.RowIndex].Version;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTestTimestampDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestTimestampDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestTimestampDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestTimestampIdDataGridViewColumn":
						TestTimestampList[e.RowIndex].TestTimestampId = (System.Int32)e.Value;
						break;
					case "uxDumbFieldDataGridViewColumn":
						TestTimestampList[e.RowIndex].DumbField = (System.Boolean?)e.Value;
						break;
					case "uxVersionDataGridViewColumn":
						TestTimestampList[e.RowIndex].Version = (System.Byte[])e.Value;
						break;
				default:
				break;
			}
		}
	}
}
