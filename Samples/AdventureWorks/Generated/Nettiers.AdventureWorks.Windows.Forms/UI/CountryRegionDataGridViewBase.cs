
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract CountryRegion typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CountryRegionDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CountryRegionDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.CountryRegion _currentCountryRegion = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCountryRegionDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCountryRegionErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCountryRegionBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the CountryRegionCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCountryRegionCodeDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.CountryRegion> _CountryRegionList;
				
		/// <summary> 
		/// The list of CountryRegion to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.CountryRegion> CountryRegionList
		{
			get {return this._CountryRegionList;}
			set
			{
				this._CountryRegionList = value;
				this.uxCountryRegionBindingSource.DataSource = null;
				this.uxCountryRegionBindingSource.DataSource = value;
				this.uxCountryRegionDataGridView.DataSource = null;
				this.uxCountryRegionDataGridView.DataSource = this.uxCountryRegionBindingSource;				
				//this.uxCountryRegionBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCountryRegionBindingSource_ListChanged);
				this.uxCountryRegionBindingSource.CurrentItemChanged += new System.EventHandler(OnCountryRegionBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCountryRegionBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCountryRegion = uxCountryRegionBindingSource.Current as Entities.CountryRegion;
			
			if (_currentCountryRegion != null)
			{
				_currentCountryRegion.Validate();
			}
			//_CountryRegion.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCountryRegionBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.CountryRegion"/> instance.
		/// </summary>
		public Entities.CountryRegion SelectedCountryRegion
		{
			get {return this._currentCountryRegion;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCountryRegionDataGridView.VirtualMode;}
			set
			{
				this.uxCountryRegionDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCountryRegionDataGridView.AllowUserToAddRows;}
			set {this.uxCountryRegionDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCountryRegionDataGridView.AllowUserToDeleteRows;}
			set {this.uxCountryRegionDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCountryRegionDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCountryRegionDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CountryRegionDataGridViewBase"/> class.
		/// </summary>
		public CountryRegionDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCountryRegionDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCountryRegionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCountryRegionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCountryRegionCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCountryRegionErrorProvider
			// 
			this.uxCountryRegionErrorProvider.ContainerControl = this;
			this.uxCountryRegionErrorProvider.DataSource = this.uxCountryRegionBindingSource;						
			// 
			// uxCountryRegionDataGridView
			// 
			this.uxCountryRegionDataGridView.AutoGenerateColumns = false;
			this.uxCountryRegionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCountryRegionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCountryRegionCodeDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxCountryRegionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCountryRegionDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCountryRegionDataGridView.Name = "uxCountryRegionDataGridView";
			this.uxCountryRegionDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCountryRegionDataGridView.TabIndex = 0;	
			this.uxCountryRegionDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCountryRegionDataGridView.EnableHeadersVisualStyles = false;
			this.uxCountryRegionDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCountryRegionDataGridViewDataError);
			this.uxCountryRegionDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCountryRegionDataGridViewCellValueNeeded);
			this.uxCountryRegionDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCountryRegionDataGridViewCellValuePushed);
			
			//
			// uxCountryRegionCodeDataGridViewColumn
			//
			this.uxCountryRegionCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCountryRegionCodeDataGridViewColumn.DataPropertyName = "CountryRegionCode";
			this.uxCountryRegionCodeDataGridViewColumn.HeaderText = "CountryRegionCode";
			this.uxCountryRegionCodeDataGridViewColumn.Name = "uxCountryRegionCodeDataGridViewColumn";
			this.uxCountryRegionCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCountryRegionCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCountryRegionCodeDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxCountryRegionDataGridView);
			this.Name = "CountryRegionDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionBindingSource)).EndInit();
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
				CountryRegionDataGridViewEventArgs args = new CountryRegionDataGridViewEventArgs();
				args.CountryRegion = _currentCountryRegion;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CountryRegionDataGridViewEventArgs : System.EventArgs
		{
			private Entities.CountryRegion	_CountryRegion;
	
			/// <summary>
			/// the  Entities.CountryRegion instance.
			/// </summary>
			public Entities.CountryRegion CountryRegion
			{
				get { return _CountryRegion; }
				set { _CountryRegion = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCountryRegionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCountryRegionDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCountryRegionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCountryRegionDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCountryRegionDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCountryRegionCodeDataGridViewColumn":
						e.Value = CountryRegionList[e.RowIndex].CountryRegionCode;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = CountryRegionList[e.RowIndex].Name;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = CountryRegionList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCountryRegionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCountryRegionDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCountryRegionDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCountryRegionCodeDataGridViewColumn":
						CountryRegionList[e.RowIndex].CountryRegionCode = (System.String)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						CountryRegionList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						CountryRegionList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
