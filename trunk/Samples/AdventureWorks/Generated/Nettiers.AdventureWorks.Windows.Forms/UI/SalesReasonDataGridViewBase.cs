
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SalesReason typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SalesReasonDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SalesReasonDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SalesReason _currentSalesReason = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSalesReasonDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSalesReasonErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSalesReasonBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the SalesReasonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSalesReasonIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ReasonType property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxReasonTypeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.SalesReason> _SalesReasonList;
				
		/// <summary> 
		/// The list of SalesReason to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SalesReason> SalesReasonList
		{
			get {return this._SalesReasonList;}
			set
			{
				this._SalesReasonList = value;
				this.uxSalesReasonBindingSource.DataSource = null;
				this.uxSalesReasonBindingSource.DataSource = value;
				this.uxSalesReasonDataGridView.DataSource = null;
				this.uxSalesReasonDataGridView.DataSource = this.uxSalesReasonBindingSource;				
				//this.uxSalesReasonBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSalesReasonBindingSource_ListChanged);
				this.uxSalesReasonBindingSource.CurrentItemChanged += new System.EventHandler(OnSalesReasonBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSalesReasonBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSalesReason = uxSalesReasonBindingSource.Current as Entities.SalesReason;
			
			if (_currentSalesReason != null)
			{
				_currentSalesReason.Validate();
			}
			//_SalesReason.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSalesReasonBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SalesReason"/> instance.
		/// </summary>
		public Entities.SalesReason SelectedSalesReason
		{
			get {return this._currentSalesReason;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSalesReasonDataGridView.VirtualMode;}
			set
			{
				this.uxSalesReasonDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSalesReasonDataGridView.AllowUserToAddRows;}
			set {this.uxSalesReasonDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSalesReasonDataGridView.AllowUserToDeleteRows;}
			set {this.uxSalesReasonDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSalesReasonDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSalesReasonDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SalesReasonDataGridViewBase"/> class.
		/// </summary>
		public SalesReasonDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSalesReasonDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSalesReasonBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSalesReasonErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSalesReasonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxReasonTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesReasonDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesReasonBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesReasonErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSalesReasonErrorProvider
			// 
			this.uxSalesReasonErrorProvider.ContainerControl = this;
			this.uxSalesReasonErrorProvider.DataSource = this.uxSalesReasonBindingSource;						
			// 
			// uxSalesReasonDataGridView
			// 
			this.uxSalesReasonDataGridView.AutoGenerateColumns = false;
			this.uxSalesReasonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSalesReasonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSalesReasonIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxReasonTypeDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSalesReasonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSalesReasonDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSalesReasonDataGridView.Name = "uxSalesReasonDataGridView";
			this.uxSalesReasonDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSalesReasonDataGridView.TabIndex = 0;	
			this.uxSalesReasonDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSalesReasonDataGridView.EnableHeadersVisualStyles = false;
			this.uxSalesReasonDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSalesReasonDataGridViewDataError);
			this.uxSalesReasonDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesReasonDataGridViewCellValueNeeded);
			this.uxSalesReasonDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSalesReasonDataGridViewCellValuePushed);
			
			//
			// uxSalesReasonIdDataGridViewColumn
			//
			this.uxSalesReasonIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSalesReasonIdDataGridViewColumn.DataPropertyName = "SalesReasonId";
			this.uxSalesReasonIdDataGridViewColumn.HeaderText = "SalesReasonId";
			this.uxSalesReasonIdDataGridViewColumn.Name = "uxSalesReasonIdDataGridViewColumn";
			this.uxSalesReasonIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSalesReasonIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSalesReasonIdDataGridViewColumn.ReadOnly = true;		
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
			// uxReasonTypeDataGridViewColumn
			//
			this.uxReasonTypeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxReasonTypeDataGridViewColumn.DataPropertyName = "ReasonType";
			this.uxReasonTypeDataGridViewColumn.HeaderText = "ReasonType";
			this.uxReasonTypeDataGridViewColumn.Name = "uxReasonTypeDataGridViewColumn";
			this.uxReasonTypeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxReasonTypeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxReasonTypeDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxSalesReasonDataGridView);
			this.Name = "SalesReasonDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxSalesReasonErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesReasonDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSalesReasonBindingSource)).EndInit();
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
				SalesReasonDataGridViewEventArgs args = new SalesReasonDataGridViewEventArgs();
				args.SalesReason = _currentSalesReason;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SalesReasonDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SalesReason	_SalesReason;
	
			/// <summary>
			/// the  Entities.SalesReason instance.
			/// </summary>
			public Entities.SalesReason SalesReason
			{
				get { return _SalesReason; }
				set { _SalesReason = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSalesReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSalesReasonDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSalesReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesReasonDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesReasonDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesReasonIdDataGridViewColumn":
						e.Value = SalesReasonList[e.RowIndex].SalesReasonId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = SalesReasonList[e.RowIndex].Name;
						break;
					case "uxReasonTypeDataGridViewColumn":
						e.Value = SalesReasonList[e.RowIndex].ReasonType;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SalesReasonList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSalesReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSalesReasonDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSalesReasonDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSalesReasonIdDataGridViewColumn":
						SalesReasonList[e.RowIndex].SalesReasonId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						SalesReasonList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxReasonTypeDataGridViewColumn":
						SalesReasonList[e.RowIndex].ReasonType = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SalesReasonList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
