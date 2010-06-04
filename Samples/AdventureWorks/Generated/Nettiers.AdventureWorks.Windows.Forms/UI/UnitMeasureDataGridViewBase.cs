
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract UnitMeasure typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class UnitMeasureDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<UnitMeasureDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.UnitMeasure _currentUnitMeasure = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxUnitMeasureDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxUnitMeasureErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxUnitMeasureBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the UnitMeasureCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUnitMeasureCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.UnitMeasure> _UnitMeasureList;
				
		/// <summary> 
		/// The list of UnitMeasure to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.UnitMeasure> UnitMeasureList
		{
			get {return this._UnitMeasureList;}
			set
			{
				this._UnitMeasureList = value;
				this.uxUnitMeasureBindingSource.DataSource = null;
				this.uxUnitMeasureBindingSource.DataSource = value;
				this.uxUnitMeasureDataGridView.DataSource = null;
				this.uxUnitMeasureDataGridView.DataSource = this.uxUnitMeasureBindingSource;				
				//this.uxUnitMeasureBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxUnitMeasureBindingSource_ListChanged);
				this.uxUnitMeasureBindingSource.CurrentItemChanged += new System.EventHandler(OnUnitMeasureBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnUnitMeasureBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentUnitMeasure = uxUnitMeasureBindingSource.Current as Entities.UnitMeasure;
			
			if (_currentUnitMeasure != null)
			{
				_currentUnitMeasure.Validate();
			}
			//_UnitMeasure.Validate();
			OnCurrentEntityChanged();
		}

		//void uxUnitMeasureBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.UnitMeasure"/> instance.
		/// </summary>
		public Entities.UnitMeasure SelectedUnitMeasure
		{
			get {return this._currentUnitMeasure;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxUnitMeasureDataGridView.VirtualMode;}
			set
			{
				this.uxUnitMeasureDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxUnitMeasureDataGridView.AllowUserToAddRows;}
			set {this.uxUnitMeasureDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxUnitMeasureDataGridView.AllowUserToDeleteRows;}
			set {this.uxUnitMeasureDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxUnitMeasureDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxUnitMeasureDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="UnitMeasureDataGridViewBase"/> class.
		/// </summary>
		public UnitMeasureDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxUnitMeasureDataGridView = new System.Windows.Forms.DataGridView();
			this.uxUnitMeasureBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxUnitMeasureErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxUnitMeasureCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxUnitMeasureErrorProvider
			// 
			this.uxUnitMeasureErrorProvider.ContainerControl = this;
			this.uxUnitMeasureErrorProvider.DataSource = this.uxUnitMeasureBindingSource;						
			// 
			// uxUnitMeasureDataGridView
			// 
			this.uxUnitMeasureDataGridView.AutoGenerateColumns = false;
			this.uxUnitMeasureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxUnitMeasureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxUnitMeasureCodeDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxUnitMeasureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxUnitMeasureDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxUnitMeasureDataGridView.Name = "uxUnitMeasureDataGridView";
			this.uxUnitMeasureDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxUnitMeasureDataGridView.TabIndex = 0;	
			this.uxUnitMeasureDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxUnitMeasureDataGridView.EnableHeadersVisualStyles = false;
			this.uxUnitMeasureDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnUnitMeasureDataGridViewDataError);
			this.uxUnitMeasureDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnUnitMeasureDataGridViewCellValueNeeded);
			this.uxUnitMeasureDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnUnitMeasureDataGridViewCellValuePushed);
			
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
			// uxModifiedDateDataGridViewColumn
			//
			this.uxModifiedDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxModifiedDateDataGridViewColumn.DataPropertyName = "ModifiedDate";
			this.uxModifiedDateDataGridViewColumn.HeaderText = "ModifiedDate";
			this.uxModifiedDateDataGridViewColumn.Name = "uxModifiedDateDataGridViewColumn";
			this.uxModifiedDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxModifiedDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxModifiedDateDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxUnitMeasureDataGridView);
			this.Name = "UnitMeasureDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUnitMeasureBindingSource)).EndInit();
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
				UnitMeasureDataGridViewEventArgs args = new UnitMeasureDataGridViewEventArgs();
				args.UnitMeasure = _currentUnitMeasure;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class UnitMeasureDataGridViewEventArgs : System.EventArgs
		{
			private Entities.UnitMeasure	_UnitMeasure;
	
			/// <summary>
			/// the  Entities.UnitMeasure instance.
			/// </summary>
			public Entities.UnitMeasure UnitMeasure
			{
				get { return _UnitMeasure; }
				set { _UnitMeasure = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxUnitMeasureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnUnitMeasureDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxUnitMeasureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnUnitMeasureDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxUnitMeasureDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxUnitMeasureCodeDataGridViewColumn":
						e.Value = UnitMeasureList[e.RowIndex].UnitMeasureCode;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = UnitMeasureList[e.RowIndex].Name;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = UnitMeasureList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxUnitMeasureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnUnitMeasureDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxUnitMeasureDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxUnitMeasureCodeDataGridViewColumn":
						UnitMeasureList[e.RowIndex].UnitMeasureCode = (System.String)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						UnitMeasureList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						UnitMeasureList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
