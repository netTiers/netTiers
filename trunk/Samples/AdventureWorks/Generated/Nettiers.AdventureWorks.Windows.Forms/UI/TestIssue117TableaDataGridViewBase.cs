
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TestIssue117Tablea typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestIssue117TableaDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TestIssue117TableaDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TestIssue117Tablea _currentTestIssue117Tablea = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTestIssue117TableaDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTestIssue117TableaErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTestIssue117TableaBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the TestIssue117TableAid property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTestIssue117TableAidDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DumbField property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxDumbFieldDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.TestIssue117Tablea> _TestIssue117TableaList;
				
		/// <summary> 
		/// The list of TestIssue117Tablea to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TestIssue117Tablea> TestIssue117TableaList
		{
			get {return this._TestIssue117TableaList;}
			set
			{
				this._TestIssue117TableaList = value;
				this.uxTestIssue117TableaBindingSource.DataSource = null;
				this.uxTestIssue117TableaBindingSource.DataSource = value;
				this.uxTestIssue117TableaDataGridView.DataSource = null;
				this.uxTestIssue117TableaDataGridView.DataSource = this.uxTestIssue117TableaBindingSource;				
				//this.uxTestIssue117TableaBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTestIssue117TableaBindingSource_ListChanged);
				this.uxTestIssue117TableaBindingSource.CurrentItemChanged += new System.EventHandler(OnTestIssue117TableaBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTestIssue117TableaBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTestIssue117Tablea = uxTestIssue117TableaBindingSource.Current as Entities.TestIssue117Tablea;
			
			if (_currentTestIssue117Tablea != null)
			{
				_currentTestIssue117Tablea.Validate();
			}
			//_TestIssue117Tablea.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTestIssue117TableaBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <c cref="Entities.TestIssue117Tablea"/> instance.
		/// </summary>
		public Entities.TestIssue117Tablea SelectedTestIssue117Tablea
		{
			get {return this._currentTestIssue117Tablea;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTestIssue117TableaDataGridView.VirtualMode;}
			set
			{
				this.uxTestIssue117TableaDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTestIssue117TableaDataGridView.AllowUserToAddRows;}
			set {this.uxTestIssue117TableaDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTestIssue117TableaDataGridView.AllowUserToDeleteRows;}
			set {this.uxTestIssue117TableaDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <c cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTestIssue117TableaDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTestIssue117TableaDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TestIssue117TableaDataGridViewBase"/> class.
		/// </summary>
		public TestIssue117TableaDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTestIssue117TableaDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTestIssue117TableaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTestIssue117TableaErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTestIssue117TableAidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDumbFieldDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableaDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableaErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTestIssue117TableaErrorProvider
			// 
			this.uxTestIssue117TableaErrorProvider.ContainerControl = this;
			this.uxTestIssue117TableaErrorProvider.DataSource = this.uxTestIssue117TableaBindingSource;						
			// 
			// uxTestIssue117TableaDataGridView
			// 
			this.uxTestIssue117TableaDataGridView.AutoGenerateColumns = false;
			this.uxTestIssue117TableaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTestIssue117TableaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTestIssue117TableAidDataGridViewColumn,
		this.uxDumbFieldDataGridViewColumn			});
			this.uxTestIssue117TableaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTestIssue117TableaDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTestIssue117TableaDataGridView.Name = "uxTestIssue117TableaDataGridView";
			this.uxTestIssue117TableaDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTestIssue117TableaDataGridView.TabIndex = 0;	
			this.uxTestIssue117TableaDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTestIssue117TableaDataGridView.EnableHeadersVisualStyles = false;
			this.uxTestIssue117TableaDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTestIssue117TableaDataGridViewDataError);
			this.uxTestIssue117TableaDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestIssue117TableaDataGridViewCellValueNeeded);
			this.uxTestIssue117TableaDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestIssue117TableaDataGridViewCellValuePushed);
			
			//
			// uxTestIssue117TableAidDataGridViewColumn
			//
			this.uxTestIssue117TableAidDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTestIssue117TableAidDataGridViewColumn.DataPropertyName = "TestIssue117TableAid";
			this.uxTestIssue117TableAidDataGridViewColumn.HeaderText = "TestIssue117TableAid";
			this.uxTestIssue117TableAidDataGridViewColumn.Name = "uxTestIssue117TableAidDataGridViewColumn";
			this.uxTestIssue117TableAidDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTestIssue117TableAidDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTestIssue117TableAidDataGridViewColumn.ReadOnly = true;		
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
			this.Controls.Add(this.uxTestIssue117TableaDataGridView);
			this.Name = "TestIssue117TableaDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableaErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableaDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestIssue117TableaBindingSource)).EndInit();
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
				TestIssue117TableaDataGridViewEventArgs args = new TestIssue117TableaDataGridViewEventArgs();
				args.TestIssue117Tablea = _currentTestIssue117Tablea;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TestIssue117TableaDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TestIssue117Tablea	_TestIssue117Tablea;
	
			/// <summary>
			/// the  Entities.TestIssue117Tablea instance.
			/// </summary>
			public Entities.TestIssue117Tablea TestIssue117Tablea
			{
				get { return _TestIssue117Tablea; }
				set { _TestIssue117Tablea = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTestIssue117TableaDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TableaDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTestIssue117TableaDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TableaDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestIssue117TableaDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestIssue117TableAidDataGridViewColumn":
						e.Value = TestIssue117TableaList[e.RowIndex].TestIssue117TableAid;
						break;
					case "uxDumbFieldDataGridViewColumn":
						e.Value = TestIssue117TableaList[e.RowIndex].DumbField;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTestIssue117TableaDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestIssue117TableaDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestIssue117TableaDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestIssue117TableAidDataGridViewColumn":
						TestIssue117TableaList[e.RowIndex].TestIssue117TableAid = (System.Int32)e.Value;
						break;
					case "uxDumbFieldDataGridViewColumn":
						TestIssue117TableaList[e.RowIndex].DumbField = (System.Boolean?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
