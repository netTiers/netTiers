
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Location typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class LocationDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<LocationDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Location _currentLocation = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxLocationDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxLocationErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxLocationBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the LocationId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLocationIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CostRate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCostRateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Availability property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAvailabilityDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Location> _LocationList;
				
		/// <summary> 
		/// The list of Location to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Location> LocationList
		{
			get {return this._LocationList;}
			set
			{
				this._LocationList = value;
				this.uxLocationBindingSource.DataSource = null;
				this.uxLocationBindingSource.DataSource = value;
				this.uxLocationDataGridView.DataSource = null;
				this.uxLocationDataGridView.DataSource = this.uxLocationBindingSource;				
				//this.uxLocationBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxLocationBindingSource_ListChanged);
				this.uxLocationBindingSource.CurrentItemChanged += new System.EventHandler(OnLocationBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnLocationBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentLocation = uxLocationBindingSource.Current as Entities.Location;
			
			if (_currentLocation != null)
			{
				_currentLocation.Validate();
			}
			//_Location.Validate();
			OnCurrentEntityChanged();
		}

		//void uxLocationBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Location"/> instance.
		/// </summary>
		public Entities.Location SelectedLocation
		{
			get {return this._currentLocation;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxLocationDataGridView.VirtualMode;}
			set
			{
				this.uxLocationDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxLocationDataGridView.AllowUserToAddRows;}
			set {this.uxLocationDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxLocationDataGridView.AllowUserToDeleteRows;}
			set {this.uxLocationDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxLocationDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxLocationDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="LocationDataGridViewBase"/> class.
		/// </summary>
		public LocationDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxLocationDataGridView = new System.Windows.Forms.DataGridView();
			this.uxLocationBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxLocationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxLocationIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCostRateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAvailabilityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxLocationDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxLocationBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxLocationErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxLocationErrorProvider
			// 
			this.uxLocationErrorProvider.ContainerControl = this;
			this.uxLocationErrorProvider.DataSource = this.uxLocationBindingSource;						
			// 
			// uxLocationDataGridView
			// 
			this.uxLocationDataGridView.AutoGenerateColumns = false;
			this.uxLocationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxLocationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxLocationIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxCostRateDataGridViewColumn,
		this.uxAvailabilityDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxLocationDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxLocationDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxLocationDataGridView.Name = "uxLocationDataGridView";
			this.uxLocationDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxLocationDataGridView.TabIndex = 0;	
			this.uxLocationDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxLocationDataGridView.EnableHeadersVisualStyles = false;
			this.uxLocationDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnLocationDataGridViewDataError);
			this.uxLocationDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnLocationDataGridViewCellValueNeeded);
			this.uxLocationDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnLocationDataGridViewCellValuePushed);
			
			//
			// uxLocationIdDataGridViewColumn
			//
			this.uxLocationIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLocationIdDataGridViewColumn.DataPropertyName = "LocationId";
			this.uxLocationIdDataGridViewColumn.HeaderText = "LocationId";
			this.uxLocationIdDataGridViewColumn.Name = "uxLocationIdDataGridViewColumn";
			this.uxLocationIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLocationIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLocationIdDataGridViewColumn.ReadOnly = true;		
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
			// uxCostRateDataGridViewColumn
			//
			this.uxCostRateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCostRateDataGridViewColumn.DataPropertyName = "CostRate";
			this.uxCostRateDataGridViewColumn.HeaderText = "CostRate";
			this.uxCostRateDataGridViewColumn.Name = "uxCostRateDataGridViewColumn";
			this.uxCostRateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCostRateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCostRateDataGridViewColumn.ReadOnly = false;		
			//
			// uxAvailabilityDataGridViewColumn
			//
			this.uxAvailabilityDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAvailabilityDataGridViewColumn.DataPropertyName = "Availability";
			this.uxAvailabilityDataGridViewColumn.HeaderText = "Availability";
			this.uxAvailabilityDataGridViewColumn.Name = "uxAvailabilityDataGridViewColumn";
			this.uxAvailabilityDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAvailabilityDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAvailabilityDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxLocationDataGridView);
			this.Name = "LocationDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxLocationErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxLocationDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxLocationBindingSource)).EndInit();
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
				LocationDataGridViewEventArgs args = new LocationDataGridViewEventArgs();
				args.Location = _currentLocation;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class LocationDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Location	_Location;
	
			/// <summary>
			/// the  Entities.Location instance.
			/// </summary>
			public Entities.Location Location
			{
				get { return _Location; }
				set { _Location = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxLocationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnLocationDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxLocationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnLocationDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxLocationDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxLocationIdDataGridViewColumn":
						e.Value = LocationList[e.RowIndex].LocationId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = LocationList[e.RowIndex].Name;
						break;
					case "uxCostRateDataGridViewColumn":
						e.Value = LocationList[e.RowIndex].CostRate;
						break;
					case "uxAvailabilityDataGridViewColumn":
						e.Value = LocationList[e.RowIndex].Availability;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = LocationList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxLocationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnLocationDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxLocationDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxLocationIdDataGridViewColumn":
						LocationList[e.RowIndex].LocationId = (System.Int16)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						LocationList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxCostRateDataGridViewColumn":
						LocationList[e.RowIndex].CostRate = (System.Decimal)e.Value;
						break;
					case "uxAvailabilityDataGridViewColumn":
						LocationList[e.RowIndex].Availability = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						LocationList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
