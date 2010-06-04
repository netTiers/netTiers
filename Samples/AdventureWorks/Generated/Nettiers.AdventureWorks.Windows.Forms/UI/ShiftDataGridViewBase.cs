
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Shift typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ShiftDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ShiftDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Shift _currentShift = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxShiftDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxShiftErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxShiftBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ShiftId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShiftIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StartTime property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStartTimeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EndTime property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEndTimeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Shift> _ShiftList;
				
		/// <summary> 
		/// The list of Shift to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Shift> ShiftList
		{
			get {return this._ShiftList;}
			set
			{
				this._ShiftList = value;
				this.uxShiftBindingSource.DataSource = null;
				this.uxShiftBindingSource.DataSource = value;
				this.uxShiftDataGridView.DataSource = null;
				this.uxShiftDataGridView.DataSource = this.uxShiftBindingSource;				
				//this.uxShiftBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxShiftBindingSource_ListChanged);
				this.uxShiftBindingSource.CurrentItemChanged += new System.EventHandler(OnShiftBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnShiftBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentShift = uxShiftBindingSource.Current as Entities.Shift;
			
			if (_currentShift != null)
			{
				_currentShift.Validate();
			}
			//_Shift.Validate();
			OnCurrentEntityChanged();
		}

		//void uxShiftBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Shift"/> instance.
		/// </summary>
		public Entities.Shift SelectedShift
		{
			get {return this._currentShift;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxShiftDataGridView.VirtualMode;}
			set
			{
				this.uxShiftDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxShiftDataGridView.AllowUserToAddRows;}
			set {this.uxShiftDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxShiftDataGridView.AllowUserToDeleteRows;}
			set {this.uxShiftDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxShiftDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxShiftDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ShiftDataGridViewBase"/> class.
		/// </summary>
		public ShiftDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxShiftDataGridView = new System.Windows.Forms.DataGridView();
			this.uxShiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxShiftErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxShiftIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStartTimeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndTimeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxShiftDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShiftBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShiftErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxShiftErrorProvider
			// 
			this.uxShiftErrorProvider.ContainerControl = this;
			this.uxShiftErrorProvider.DataSource = this.uxShiftBindingSource;						
			// 
			// uxShiftDataGridView
			// 
			this.uxShiftDataGridView.AutoGenerateColumns = false;
			this.uxShiftDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxShiftDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxShiftIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxStartTimeDataGridViewColumn,
		this.uxEndTimeDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxShiftDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxShiftDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxShiftDataGridView.Name = "uxShiftDataGridView";
			this.uxShiftDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxShiftDataGridView.TabIndex = 0;	
			this.uxShiftDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxShiftDataGridView.EnableHeadersVisualStyles = false;
			this.uxShiftDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnShiftDataGridViewDataError);
			this.uxShiftDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnShiftDataGridViewCellValueNeeded);
			this.uxShiftDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnShiftDataGridViewCellValuePushed);
			
			//
			// uxShiftIdDataGridViewColumn
			//
			this.uxShiftIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShiftIdDataGridViewColumn.DataPropertyName = "ShiftId";
			this.uxShiftIdDataGridViewColumn.HeaderText = "ShiftId";
			this.uxShiftIdDataGridViewColumn.Name = "uxShiftIdDataGridViewColumn";
			this.uxShiftIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShiftIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShiftIdDataGridViewColumn.ReadOnly = true;		
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
			// uxStartTimeDataGridViewColumn
			//
			this.uxStartTimeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStartTimeDataGridViewColumn.DataPropertyName = "StartTime";
			this.uxStartTimeDataGridViewColumn.HeaderText = "StartTime";
			this.uxStartTimeDataGridViewColumn.Name = "uxStartTimeDataGridViewColumn";
			this.uxStartTimeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStartTimeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStartTimeDataGridViewColumn.ReadOnly = false;		
			//
			// uxEndTimeDataGridViewColumn
			//
			this.uxEndTimeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEndTimeDataGridViewColumn.DataPropertyName = "EndTime";
			this.uxEndTimeDataGridViewColumn.HeaderText = "EndTime";
			this.uxEndTimeDataGridViewColumn.Name = "uxEndTimeDataGridViewColumn";
			this.uxEndTimeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEndTimeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEndTimeDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxShiftDataGridView);
			this.Name = "ShiftDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxShiftErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShiftDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShiftBindingSource)).EndInit();
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
				ShiftDataGridViewEventArgs args = new ShiftDataGridViewEventArgs();
				args.Shift = _currentShift;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ShiftDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Shift	_Shift;
	
			/// <summary>
			/// the  Entities.Shift instance.
			/// </summary>
			public Entities.Shift Shift
			{
				get { return _Shift; }
				set { _Shift = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxShiftDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnShiftDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxShiftDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnShiftDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxShiftDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxShiftIdDataGridViewColumn":
						e.Value = ShiftList[e.RowIndex].ShiftId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = ShiftList[e.RowIndex].Name;
						break;
					case "uxStartTimeDataGridViewColumn":
						e.Value = ShiftList[e.RowIndex].StartTime;
						break;
					case "uxEndTimeDataGridViewColumn":
						e.Value = ShiftList[e.RowIndex].EndTime;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ShiftList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxShiftDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnShiftDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxShiftDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxShiftIdDataGridViewColumn":
						ShiftList[e.RowIndex].ShiftId = (System.Byte)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						ShiftList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxStartTimeDataGridViewColumn":
						ShiftList[e.RowIndex].StartTime = (System.DateTime)e.Value;
						break;
					case "uxEndTimeDataGridViewColumn":
						ShiftList[e.RowIndex].EndTime = (System.DateTime)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ShiftList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
