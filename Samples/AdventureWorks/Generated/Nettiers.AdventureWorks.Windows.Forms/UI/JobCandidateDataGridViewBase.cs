
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract JobCandidate typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class JobCandidateDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<JobCandidateDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.JobCandidate _currentJobCandidate = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxJobCandidateDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxJobCandidateErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxJobCandidateBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the JobCandidateId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxJobCandidateIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the EmployeeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxEmployeeIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Resume property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxResumeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Employee> _EmployeeIdList;
		
		/// <summary> 
		/// The list of selectable Employee
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Employee> EmployeeIdList
		{
			get {return this._EmployeeIdList;}
			set 
			{
				this._EmployeeIdList = value;
				this.uxEmployeeIdDataGridViewColumn.DataSource = null;
				this.uxEmployeeIdDataGridViewColumn.DataSource = this._EmployeeIdList;
			}
		}
		
		private bool _allowNewItemInEmployeeIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Employee
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInEmployeeIdList
		{
			get { return _allowNewItemInEmployeeIdList;}
			set
			{
				this._allowNewItemInEmployeeIdList = value;
				this.uxEmployeeIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.JobCandidate> _JobCandidateList;
				
		/// <summary> 
		/// The list of JobCandidate to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.JobCandidate> JobCandidateList
		{
			get {return this._JobCandidateList;}
			set
			{
				this._JobCandidateList = value;
				this.uxJobCandidateBindingSource.DataSource = null;
				this.uxJobCandidateBindingSource.DataSource = value;
				this.uxJobCandidateDataGridView.DataSource = null;
				this.uxJobCandidateDataGridView.DataSource = this.uxJobCandidateBindingSource;				
				//this.uxJobCandidateBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxJobCandidateBindingSource_ListChanged);
				this.uxJobCandidateBindingSource.CurrentItemChanged += new System.EventHandler(OnJobCandidateBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnJobCandidateBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentJobCandidate = uxJobCandidateBindingSource.Current as Entities.JobCandidate;
			
			if (_currentJobCandidate != null)
			{
				_currentJobCandidate.Validate();
			}
			//_JobCandidate.Validate();
			OnCurrentEntityChanged();
		}

		//void uxJobCandidateBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.JobCandidate"/> instance.
		/// </summary>
		public Entities.JobCandidate SelectedJobCandidate
		{
			get {return this._currentJobCandidate;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxJobCandidateDataGridView.VirtualMode;}
			set
			{
				this.uxJobCandidateDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxJobCandidateDataGridView.AllowUserToAddRows;}
			set {this.uxJobCandidateDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxJobCandidateDataGridView.AllowUserToDeleteRows;}
			set {this.uxJobCandidateDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxJobCandidateDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxJobCandidateDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="JobCandidateDataGridViewBase"/> class.
		/// </summary>
		public JobCandidateDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxJobCandidateDataGridView = new System.Windows.Forms.DataGridView();
			this.uxJobCandidateBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxJobCandidateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxJobCandidateIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEmployeeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxResumeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxEmployeeIdBindingSource = new EmployeeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxJobCandidateDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxJobCandidateBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxJobCandidateErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxJobCandidateErrorProvider
			// 
			this.uxJobCandidateErrorProvider.ContainerControl = this;
			this.uxJobCandidateErrorProvider.DataSource = this.uxJobCandidateBindingSource;						
			// 
			// uxJobCandidateDataGridView
			// 
			this.uxJobCandidateDataGridView.AutoGenerateColumns = false;
			this.uxJobCandidateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxJobCandidateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxJobCandidateIdDataGridViewColumn,
		this.uxEmployeeIdDataGridViewColumn,
		this.uxResumeDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxJobCandidateDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxJobCandidateDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxJobCandidateDataGridView.Name = "uxJobCandidateDataGridView";
			this.uxJobCandidateDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxJobCandidateDataGridView.TabIndex = 0;	
			this.uxJobCandidateDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxJobCandidateDataGridView.EnableHeadersVisualStyles = false;
			this.uxJobCandidateDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnJobCandidateDataGridViewDataError);
			this.uxJobCandidateDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnJobCandidateDataGridViewCellValueNeeded);
			this.uxJobCandidateDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnJobCandidateDataGridViewCellValuePushed);
			
			//
			// uxJobCandidateIdDataGridViewColumn
			//
			this.uxJobCandidateIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxJobCandidateIdDataGridViewColumn.DataPropertyName = "JobCandidateId";
			this.uxJobCandidateIdDataGridViewColumn.HeaderText = "JobCandidateId";
			this.uxJobCandidateIdDataGridViewColumn.Name = "uxJobCandidateIdDataGridViewColumn";
			this.uxJobCandidateIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxJobCandidateIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxJobCandidateIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxEmployeeIdDataGridViewColumn
			//
			this.uxEmployeeIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEmployeeIdDataGridViewColumn.DataPropertyName = "EmployeeId";
			this.uxEmployeeIdDataGridViewColumn.HeaderText = "EmployeeId";
			this.uxEmployeeIdDataGridViewColumn.Name = "uxEmployeeIdDataGridViewColumn";
			this.uxEmployeeIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEmployeeIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEmployeeIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxResumeDataGridViewColumn
			//
			this.uxResumeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxResumeDataGridViewColumn.DataPropertyName = "Resume";
			this.uxResumeDataGridViewColumn.HeaderText = "Resume";
			this.uxResumeDataGridViewColumn.Name = "uxResumeDataGridViewColumn";
			this.uxResumeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxResumeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxResumeDataGridViewColumn.ReadOnly = false;		
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
			// uxEmployeeIdDataGridViewColumn
			//				
			this.uxEmployeeIdDataGridViewColumn.DisplayMember = "NationalIdNumber";	
			this.uxEmployeeIdDataGridViewColumn.ValueMember = "EmployeeId";	
			this.uxEmployeeIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxEmployeeIdDataGridViewColumn.DataSource = uxEmployeeIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxJobCandidateDataGridView);
			this.Name = "JobCandidateDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxJobCandidateErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxJobCandidateDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxJobCandidateBindingSource)).EndInit();
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
				JobCandidateDataGridViewEventArgs args = new JobCandidateDataGridViewEventArgs();
				args.JobCandidate = _currentJobCandidate;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class JobCandidateDataGridViewEventArgs : System.EventArgs
		{
			private Entities.JobCandidate	_JobCandidate;
	
			/// <summary>
			/// the  Entities.JobCandidate instance.
			/// </summary>
			public Entities.JobCandidate JobCandidate
			{
				get { return _JobCandidate; }
				set { _JobCandidate = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxJobCandidateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnJobCandidateDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxJobCandidateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnJobCandidateDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxJobCandidateDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxJobCandidateIdDataGridViewColumn":
						e.Value = JobCandidateList[e.RowIndex].JobCandidateId;
						break;
					case "uxEmployeeIdDataGridViewColumn":
						e.Value = JobCandidateList[e.RowIndex].EmployeeId;
						break;
					case "uxResumeDataGridViewColumn":
						e.Value = JobCandidateList[e.RowIndex].Resume;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = JobCandidateList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxJobCandidateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnJobCandidateDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxJobCandidateDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxJobCandidateIdDataGridViewColumn":
						JobCandidateList[e.RowIndex].JobCandidateId = (System.Int32)e.Value;
						break;
					case "uxEmployeeIdDataGridViewColumn":
						JobCandidateList[e.RowIndex].EmployeeId = (System.Int32?)e.Value;
						break;
					case "uxResumeDataGridViewColumn":
						JobCandidateList[e.RowIndex].Resume = (string)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						JobCandidateList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
