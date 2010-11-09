
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ShipMethod typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ShipMethodDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ShipMethodDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ShipMethod _currentShipMethod = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxShipMethodDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxShipMethodErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxShipMethodBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ShipMethodId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShipMethodIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ShipBase property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShipBaseDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ShipRate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxShipRateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Rowguid property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRowguidDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ShipMethod> _ShipMethodList;
				
		/// <summary> 
		/// The list of ShipMethod to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ShipMethod> ShipMethodList
		{
			get {return this._ShipMethodList;}
			set
			{
				this._ShipMethodList = value;
				this.uxShipMethodBindingSource.DataSource = null;
				this.uxShipMethodBindingSource.DataSource = value;
				this.uxShipMethodDataGridView.DataSource = null;
				this.uxShipMethodDataGridView.DataSource = this.uxShipMethodBindingSource;				
				//this.uxShipMethodBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxShipMethodBindingSource_ListChanged);
				this.uxShipMethodBindingSource.CurrentItemChanged += new System.EventHandler(OnShipMethodBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnShipMethodBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentShipMethod = uxShipMethodBindingSource.Current as Entities.ShipMethod;
			
			if (_currentShipMethod != null)
			{
				_currentShipMethod.Validate();
			}
			//_ShipMethod.Validate();
			OnCurrentEntityChanged();
		}

		//void uxShipMethodBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ShipMethod"/> instance.
		/// </summary>
		public Entities.ShipMethod SelectedShipMethod
		{
			get {return this._currentShipMethod;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxShipMethodDataGridView.VirtualMode;}
			set
			{
				this.uxShipMethodDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxShipMethodDataGridView.AllowUserToAddRows;}
			set {this.uxShipMethodDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxShipMethodDataGridView.AllowUserToDeleteRows;}
			set {this.uxShipMethodDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxShipMethodDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxShipMethodDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ShipMethodDataGridViewBase"/> class.
		/// </summary>
		public ShipMethodDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxShipMethodDataGridView = new System.Windows.Forms.DataGridView();
			this.uxShipMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxShipMethodErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxShipMethodIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxShipBaseDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxShipRateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxShipMethodDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShipMethodBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShipMethodErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxShipMethodErrorProvider
			// 
			this.uxShipMethodErrorProvider.ContainerControl = this;
			this.uxShipMethodErrorProvider.DataSource = this.uxShipMethodBindingSource;						
			// 
			// uxShipMethodDataGridView
			// 
			this.uxShipMethodDataGridView.AutoGenerateColumns = false;
			this.uxShipMethodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxShipMethodDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxShipMethodIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxShipBaseDataGridViewColumn,
		this.uxShipRateDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxShipMethodDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxShipMethodDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxShipMethodDataGridView.Name = "uxShipMethodDataGridView";
			this.uxShipMethodDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxShipMethodDataGridView.TabIndex = 0;	
			this.uxShipMethodDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxShipMethodDataGridView.EnableHeadersVisualStyles = false;
			this.uxShipMethodDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnShipMethodDataGridViewDataError);
			this.uxShipMethodDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnShipMethodDataGridViewCellValueNeeded);
			this.uxShipMethodDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnShipMethodDataGridViewCellValuePushed);
			
			//
			// uxShipMethodIdDataGridViewColumn
			//
			this.uxShipMethodIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShipMethodIdDataGridViewColumn.DataPropertyName = "ShipMethodId";
			this.uxShipMethodIdDataGridViewColumn.HeaderText = "ShipMethodId";
			this.uxShipMethodIdDataGridViewColumn.Name = "uxShipMethodIdDataGridViewColumn";
			this.uxShipMethodIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShipMethodIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShipMethodIdDataGridViewColumn.ReadOnly = true;		
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
			// uxShipBaseDataGridViewColumn
			//
			this.uxShipBaseDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShipBaseDataGridViewColumn.DataPropertyName = "ShipBase";
			this.uxShipBaseDataGridViewColumn.HeaderText = "ShipBase";
			this.uxShipBaseDataGridViewColumn.Name = "uxShipBaseDataGridViewColumn";
			this.uxShipBaseDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShipBaseDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShipBaseDataGridViewColumn.ReadOnly = false;		
			//
			// uxShipRateDataGridViewColumn
			//
			this.uxShipRateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxShipRateDataGridViewColumn.DataPropertyName = "ShipRate";
			this.uxShipRateDataGridViewColumn.HeaderText = "ShipRate";
			this.uxShipRateDataGridViewColumn.Name = "uxShipRateDataGridViewColumn";
			this.uxShipRateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxShipRateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxShipRateDataGridViewColumn.ReadOnly = false;		
			//
			// uxRowguidDataGridViewColumn
			//
			this.uxRowguidDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRowguidDataGridViewColumn.DataPropertyName = "Rowguid";
			this.uxRowguidDataGridViewColumn.HeaderText = "Rowguid";
			this.uxRowguidDataGridViewColumn.Name = "uxRowguidDataGridViewColumn";
			this.uxRowguidDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRowguidDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRowguidDataGridViewColumn.ReadOnly = true;		
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
			this.Controls.Add(this.uxShipMethodDataGridView);
			this.Name = "ShipMethodDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxShipMethodErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShipMethodDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxShipMethodBindingSource)).EndInit();
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
				ShipMethodDataGridViewEventArgs args = new ShipMethodDataGridViewEventArgs();
				args.ShipMethod = _currentShipMethod;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ShipMethodDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ShipMethod	_ShipMethod;
	
			/// <summary>
			/// the  Entities.ShipMethod instance.
			/// </summary>
			public Entities.ShipMethod ShipMethod
			{
				get { return _ShipMethod; }
				set { _ShipMethod = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxShipMethodDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnShipMethodDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxShipMethodDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnShipMethodDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxShipMethodDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxShipMethodIdDataGridViewColumn":
						e.Value = ShipMethodList[e.RowIndex].ShipMethodId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = ShipMethodList[e.RowIndex].Name;
						break;
					case "uxShipBaseDataGridViewColumn":
						e.Value = ShipMethodList[e.RowIndex].ShipBase;
						break;
					case "uxShipRateDataGridViewColumn":
						e.Value = ShipMethodList[e.RowIndex].ShipRate;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = ShipMethodList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ShipMethodList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxShipMethodDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnShipMethodDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxShipMethodDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxShipMethodIdDataGridViewColumn":
						ShipMethodList[e.RowIndex].ShipMethodId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						ShipMethodList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxShipBaseDataGridViewColumn":
						ShipMethodList[e.RowIndex].ShipBase = (System.Decimal)e.Value;
						break;
					case "uxShipRateDataGridViewColumn":
						ShipMethodList[e.RowIndex].ShipRate = (System.Decimal)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						ShipMethodList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ShipMethodList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
