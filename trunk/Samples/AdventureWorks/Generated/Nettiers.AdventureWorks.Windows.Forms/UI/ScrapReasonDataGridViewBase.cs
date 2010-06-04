
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ScrapReason typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ScrapReasonDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ScrapReasonDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ScrapReason _currentScrapReason = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxScrapReasonDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxScrapReasonErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxScrapReasonBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ScrapReasonId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxScrapReasonIdDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.ScrapReason> _ScrapReasonList;
				
		/// <summary> 
		/// The list of ScrapReason to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ScrapReason> ScrapReasonList
		{
			get {return this._ScrapReasonList;}
			set
			{
				this._ScrapReasonList = value;
				this.uxScrapReasonBindingSource.DataSource = null;
				this.uxScrapReasonBindingSource.DataSource = value;
				this.uxScrapReasonDataGridView.DataSource = null;
				this.uxScrapReasonDataGridView.DataSource = this.uxScrapReasonBindingSource;				
				//this.uxScrapReasonBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxScrapReasonBindingSource_ListChanged);
				this.uxScrapReasonBindingSource.CurrentItemChanged += new System.EventHandler(OnScrapReasonBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnScrapReasonBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentScrapReason = uxScrapReasonBindingSource.Current as Entities.ScrapReason;
			
			if (_currentScrapReason != null)
			{
				_currentScrapReason.Validate();
			}
			//_ScrapReason.Validate();
			OnCurrentEntityChanged();
		}

		//void uxScrapReasonBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ScrapReason"/> instance.
		/// </summary>
		public Entities.ScrapReason SelectedScrapReason
		{
			get {return this._currentScrapReason;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxScrapReasonDataGridView.VirtualMode;}
			set
			{
				this.uxScrapReasonDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxScrapReasonDataGridView.AllowUserToAddRows;}
			set {this.uxScrapReasonDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxScrapReasonDataGridView.AllowUserToDeleteRows;}
			set {this.uxScrapReasonDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxScrapReasonDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxScrapReasonDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ScrapReasonDataGridViewBase"/> class.
		/// </summary>
		public ScrapReasonDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxScrapReasonDataGridView = new System.Windows.Forms.DataGridView();
			this.uxScrapReasonBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxScrapReasonErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxScrapReasonIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxScrapReasonDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxScrapReasonBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxScrapReasonErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxScrapReasonErrorProvider
			// 
			this.uxScrapReasonErrorProvider.ContainerControl = this;
			this.uxScrapReasonErrorProvider.DataSource = this.uxScrapReasonBindingSource;						
			// 
			// uxScrapReasonDataGridView
			// 
			this.uxScrapReasonDataGridView.AutoGenerateColumns = false;
			this.uxScrapReasonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxScrapReasonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxScrapReasonIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxScrapReasonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxScrapReasonDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxScrapReasonDataGridView.Name = "uxScrapReasonDataGridView";
			this.uxScrapReasonDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxScrapReasonDataGridView.TabIndex = 0;	
			this.uxScrapReasonDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxScrapReasonDataGridView.EnableHeadersVisualStyles = false;
			this.uxScrapReasonDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnScrapReasonDataGridViewDataError);
			this.uxScrapReasonDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnScrapReasonDataGridViewCellValueNeeded);
			this.uxScrapReasonDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnScrapReasonDataGridViewCellValuePushed);
			
			//
			// uxScrapReasonIdDataGridViewColumn
			//
			this.uxScrapReasonIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxScrapReasonIdDataGridViewColumn.DataPropertyName = "ScrapReasonId";
			this.uxScrapReasonIdDataGridViewColumn.HeaderText = "ScrapReasonId";
			this.uxScrapReasonIdDataGridViewColumn.Name = "uxScrapReasonIdDataGridViewColumn";
			this.uxScrapReasonIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxScrapReasonIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxScrapReasonIdDataGridViewColumn.ReadOnly = true;		
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
			this.Controls.Add(this.uxScrapReasonDataGridView);
			this.Name = "ScrapReasonDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxScrapReasonErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxScrapReasonDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxScrapReasonBindingSource)).EndInit();
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
				ScrapReasonDataGridViewEventArgs args = new ScrapReasonDataGridViewEventArgs();
				args.ScrapReason = _currentScrapReason;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ScrapReasonDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ScrapReason	_ScrapReason;
	
			/// <summary>
			/// the  Entities.ScrapReason instance.
			/// </summary>
			public Entities.ScrapReason ScrapReason
			{
				get { return _ScrapReason; }
				set { _ScrapReason = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxScrapReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnScrapReasonDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxScrapReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnScrapReasonDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxScrapReasonDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxScrapReasonIdDataGridViewColumn":
						e.Value = ScrapReasonList[e.RowIndex].ScrapReasonId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = ScrapReasonList[e.RowIndex].Name;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ScrapReasonList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxScrapReasonDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnScrapReasonDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxScrapReasonDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxScrapReasonIdDataGridViewColumn":
						ScrapReasonList[e.RowIndex].ScrapReasonId = (System.Int16)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						ScrapReasonList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ScrapReasonList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
