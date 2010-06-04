
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Department typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class DepartmentDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<DepartmentDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Department _currentDepartment = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxDepartmentDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxDepartmentErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxDepartmentBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the DepartmentId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDepartmentIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the GroupName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxGroupNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Department> _DepartmentList;
				
		/// <summary> 
		/// The list of Department to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Department> DepartmentList
		{
			get {return this._DepartmentList;}
			set
			{
				this._DepartmentList = value;
				this.uxDepartmentBindingSource.DataSource = null;
				this.uxDepartmentBindingSource.DataSource = value;
				this.uxDepartmentDataGridView.DataSource = null;
				this.uxDepartmentDataGridView.DataSource = this.uxDepartmentBindingSource;				
				//this.uxDepartmentBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxDepartmentBindingSource_ListChanged);
				this.uxDepartmentBindingSource.CurrentItemChanged += new System.EventHandler(OnDepartmentBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnDepartmentBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentDepartment = uxDepartmentBindingSource.Current as Entities.Department;
			
			if (_currentDepartment != null)
			{
				_currentDepartment.Validate();
			}
			//_Department.Validate();
			OnCurrentEntityChanged();
		}

		//void uxDepartmentBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Department"/> instance.
		/// </summary>
		public Entities.Department SelectedDepartment
		{
			get {return this._currentDepartment;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxDepartmentDataGridView.VirtualMode;}
			set
			{
				this.uxDepartmentDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxDepartmentDataGridView.AllowUserToAddRows;}
			set {this.uxDepartmentDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxDepartmentDataGridView.AllowUserToDeleteRows;}
			set {this.uxDepartmentDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxDepartmentDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxDepartmentDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="DepartmentDataGridViewBase"/> class.
		/// </summary>
		public DepartmentDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxDepartmentDataGridView = new System.Windows.Forms.DataGridView();
			this.uxDepartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxDepartmentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxDepartmentIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxGroupNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxDepartmentDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDepartmentBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDepartmentErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxDepartmentErrorProvider
			// 
			this.uxDepartmentErrorProvider.ContainerControl = this;
			this.uxDepartmentErrorProvider.DataSource = this.uxDepartmentBindingSource;						
			// 
			// uxDepartmentDataGridView
			// 
			this.uxDepartmentDataGridView.AutoGenerateColumns = false;
			this.uxDepartmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxDepartmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxDepartmentIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxGroupNameDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxDepartmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxDepartmentDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxDepartmentDataGridView.Name = "uxDepartmentDataGridView";
			this.uxDepartmentDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxDepartmentDataGridView.TabIndex = 0;	
			this.uxDepartmentDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxDepartmentDataGridView.EnableHeadersVisualStyles = false;
			this.uxDepartmentDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDepartmentDataGridViewDataError);
			this.uxDepartmentDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnDepartmentDataGridViewCellValueNeeded);
			this.uxDepartmentDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnDepartmentDataGridViewCellValuePushed);
			
			//
			// uxDepartmentIdDataGridViewColumn
			//
			this.uxDepartmentIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDepartmentIdDataGridViewColumn.DataPropertyName = "DepartmentId";
			this.uxDepartmentIdDataGridViewColumn.HeaderText = "DepartmentId";
			this.uxDepartmentIdDataGridViewColumn.Name = "uxDepartmentIdDataGridViewColumn";
			this.uxDepartmentIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDepartmentIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDepartmentIdDataGridViewColumn.ReadOnly = true;		
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
			// uxGroupNameDataGridViewColumn
			//
			this.uxGroupNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxGroupNameDataGridViewColumn.DataPropertyName = "GroupName";
			this.uxGroupNameDataGridViewColumn.HeaderText = "GroupName";
			this.uxGroupNameDataGridViewColumn.Name = "uxGroupNameDataGridViewColumn";
			this.uxGroupNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxGroupNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxGroupNameDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxDepartmentDataGridView);
			this.Name = "DepartmentDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxDepartmentErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDepartmentDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDepartmentBindingSource)).EndInit();
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
				DepartmentDataGridViewEventArgs args = new DepartmentDataGridViewEventArgs();
				args.Department = _currentDepartment;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class DepartmentDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Department	_Department;
	
			/// <summary>
			/// the  Entities.Department instance.
			/// </summary>
			public Entities.Department Department
			{
				get { return _Department; }
				set { _Department = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxDepartmentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnDepartmentDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxDepartmentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnDepartmentDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxDepartmentDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxDepartmentIdDataGridViewColumn":
						e.Value = DepartmentList[e.RowIndex].DepartmentId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = DepartmentList[e.RowIndex].Name;
						break;
					case "uxGroupNameDataGridViewColumn":
						e.Value = DepartmentList[e.RowIndex].GroupName;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = DepartmentList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxDepartmentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnDepartmentDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxDepartmentDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxDepartmentIdDataGridViewColumn":
						DepartmentList[e.RowIndex].DepartmentId = (System.Int16)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						DepartmentList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxGroupNameDataGridViewColumn":
						DepartmentList[e.RowIndex].GroupName = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						DepartmentList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
