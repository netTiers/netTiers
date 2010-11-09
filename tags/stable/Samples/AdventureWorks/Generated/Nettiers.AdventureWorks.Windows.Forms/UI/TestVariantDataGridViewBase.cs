
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TestVariant typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestVariantDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TestVariantDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TestVariant _currentTestVariant = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTestVariantDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTestVariantErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTestVariantBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the TestVariantId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTestVariantIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the VariantField property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxVariantFieldDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.TestVariant> _TestVariantList;
				
		/// <summary> 
		/// The list of TestVariant to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TestVariant> TestVariantList
		{
			get {return this._TestVariantList;}
			set
			{
				this._TestVariantList = value;
				this.uxTestVariantBindingSource.DataSource = null;
				this.uxTestVariantBindingSource.DataSource = value;
				this.uxTestVariantDataGridView.DataSource = null;
				this.uxTestVariantDataGridView.DataSource = this.uxTestVariantBindingSource;				
				//this.uxTestVariantBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTestVariantBindingSource_ListChanged);
				this.uxTestVariantBindingSource.CurrentItemChanged += new System.EventHandler(OnTestVariantBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTestVariantBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTestVariant = uxTestVariantBindingSource.Current as Entities.TestVariant;
			
			if (_currentTestVariant != null)
			{
				_currentTestVariant.Validate();
			}
			//_TestVariant.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTestVariantBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.TestVariant"/> instance.
		/// </summary>
		public Entities.TestVariant SelectedTestVariant
		{
			get {return this._currentTestVariant;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTestVariantDataGridView.VirtualMode;}
			set
			{
				this.uxTestVariantDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTestVariantDataGridView.AllowUserToAddRows;}
			set {this.uxTestVariantDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTestVariantDataGridView.AllowUserToDeleteRows;}
			set {this.uxTestVariantDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTestVariantDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTestVariantDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TestVariantDataGridViewBase"/> class.
		/// </summary>
		public TestVariantDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTestVariantDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTestVariantBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTestVariantErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTestVariantIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxVariantFieldDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxTestVariantDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestVariantBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestVariantErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTestVariantErrorProvider
			// 
			this.uxTestVariantErrorProvider.ContainerControl = this;
			this.uxTestVariantErrorProvider.DataSource = this.uxTestVariantBindingSource;						
			// 
			// uxTestVariantDataGridView
			// 
			this.uxTestVariantDataGridView.AutoGenerateColumns = false;
			this.uxTestVariantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTestVariantDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTestVariantIdDataGridViewColumn,
		this.uxVariantFieldDataGridViewColumn			});
			this.uxTestVariantDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTestVariantDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTestVariantDataGridView.Name = "uxTestVariantDataGridView";
			this.uxTestVariantDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTestVariantDataGridView.TabIndex = 0;	
			this.uxTestVariantDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTestVariantDataGridView.EnableHeadersVisualStyles = false;
			this.uxTestVariantDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTestVariantDataGridViewDataError);
			this.uxTestVariantDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestVariantDataGridViewCellValueNeeded);
			this.uxTestVariantDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTestVariantDataGridViewCellValuePushed);
			
			//
			// uxTestVariantIdDataGridViewColumn
			//
			this.uxTestVariantIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTestVariantIdDataGridViewColumn.DataPropertyName = "TestVariantId";
			this.uxTestVariantIdDataGridViewColumn.HeaderText = "TestVariantId";
			this.uxTestVariantIdDataGridViewColumn.Name = "uxTestVariantIdDataGridViewColumn";
			this.uxTestVariantIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTestVariantIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTestVariantIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxVariantFieldDataGridViewColumn
			//
			this.uxVariantFieldDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxVariantFieldDataGridViewColumn.DataPropertyName = "VariantField";
			this.uxVariantFieldDataGridViewColumn.HeaderText = "VariantField";
			this.uxVariantFieldDataGridViewColumn.Name = "uxVariantFieldDataGridViewColumn";
			this.uxVariantFieldDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxVariantFieldDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxVariantFieldDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxTestVariantDataGridView);
			this.Name = "TestVariantDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxTestVariantErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestVariantDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTestVariantBindingSource)).EndInit();
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
				TestVariantDataGridViewEventArgs args = new TestVariantDataGridViewEventArgs();
				args.TestVariant = _currentTestVariant;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TestVariantDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TestVariant	_TestVariant;
	
			/// <summary>
			/// the  Entities.TestVariant instance.
			/// </summary>
			public Entities.TestVariant TestVariant
			{
				get { return _TestVariant; }
				set { _TestVariant = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTestVariantDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTestVariantDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTestVariantDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestVariantDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestVariantDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestVariantIdDataGridViewColumn":
						e.Value = TestVariantList[e.RowIndex].TestVariantId;
						break;
					case "uxVariantFieldDataGridViewColumn":
						e.Value = TestVariantList[e.RowIndex].VariantField;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTestVariantDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTestVariantDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTestVariantDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTestVariantIdDataGridViewColumn":
						TestVariantList[e.RowIndex].TestVariantId = (System.Int32)e.Value;
						break;
					case "uxVariantFieldDataGridViewColumn":
						TestVariantList[e.RowIndex].VariantField = (System.Object)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
