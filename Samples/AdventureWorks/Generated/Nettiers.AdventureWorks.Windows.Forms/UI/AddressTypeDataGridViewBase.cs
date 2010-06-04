
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract AddressType typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class AddressTypeDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<AddressTypeDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.AddressType _currentAddressType = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxAddressTypeDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxAddressTypeErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxAddressTypeBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the AddressTypeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressTypeIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.AddressType> _AddressTypeList;
				
		/// <summary> 
		/// The list of AddressType to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.AddressType> AddressTypeList
		{
			get {return this._AddressTypeList;}
			set
			{
				this._AddressTypeList = value;
				this.uxAddressTypeBindingSource.DataSource = null;
				this.uxAddressTypeBindingSource.DataSource = value;
				this.uxAddressTypeDataGridView.DataSource = null;
				this.uxAddressTypeDataGridView.DataSource = this.uxAddressTypeBindingSource;				
				//this.uxAddressTypeBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxAddressTypeBindingSource_ListChanged);
				this.uxAddressTypeBindingSource.CurrentItemChanged += new System.EventHandler(OnAddressTypeBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnAddressTypeBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentAddressType = uxAddressTypeBindingSource.Current as Entities.AddressType;
			
			if (_currentAddressType != null)
			{
				_currentAddressType.Validate();
			}
			//_AddressType.Validate();
			OnCurrentEntityChanged();
		}

		//void uxAddressTypeBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.AddressType"/> instance.
		/// </summary>
		public Entities.AddressType SelectedAddressType
		{
			get {return this._currentAddressType;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxAddressTypeDataGridView.VirtualMode;}
			set
			{
				this.uxAddressTypeDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxAddressTypeDataGridView.AllowUserToAddRows;}
			set {this.uxAddressTypeDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxAddressTypeDataGridView.AllowUserToDeleteRows;}
			set {this.uxAddressTypeDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxAddressTypeDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxAddressTypeDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="AddressTypeDataGridViewBase"/> class.
		/// </summary>
		public AddressTypeDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxAddressTypeDataGridView = new System.Windows.Forms.DataGridView();
			this.uxAddressTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxAddressTypeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxAddressTypeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxAddressTypeErrorProvider
			// 
			this.uxAddressTypeErrorProvider.ContainerControl = this;
			this.uxAddressTypeErrorProvider.DataSource = this.uxAddressTypeBindingSource;						
			// 
			// uxAddressTypeDataGridView
			// 
			this.uxAddressTypeDataGridView.AutoGenerateColumns = false;
			this.uxAddressTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxAddressTypeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxAddressTypeIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxAddressTypeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxAddressTypeDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxAddressTypeDataGridView.Name = "uxAddressTypeDataGridView";
			this.uxAddressTypeDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxAddressTypeDataGridView.TabIndex = 0;	
			this.uxAddressTypeDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxAddressTypeDataGridView.EnableHeadersVisualStyles = false;
			this.uxAddressTypeDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnAddressTypeDataGridViewDataError);
			this.uxAddressTypeDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnAddressTypeDataGridViewCellValueNeeded);
			this.uxAddressTypeDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnAddressTypeDataGridViewCellValuePushed);
			
			//
			// uxAddressTypeIdDataGridViewColumn
			//
			this.uxAddressTypeIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressTypeIdDataGridViewColumn.DataPropertyName = "AddressTypeId";
			this.uxAddressTypeIdDataGridViewColumn.HeaderText = "AddressTypeId";
			this.uxAddressTypeIdDataGridViewColumn.Name = "uxAddressTypeIdDataGridViewColumn";
			this.uxAddressTypeIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressTypeIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressTypeIdDataGridViewColumn.ReadOnly = true;		
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
			this.Controls.Add(this.uxAddressTypeDataGridView);
			this.Name = "AddressTypeDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressTypeBindingSource)).EndInit();
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
				AddressTypeDataGridViewEventArgs args = new AddressTypeDataGridViewEventArgs();
				args.AddressType = _currentAddressType;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class AddressTypeDataGridViewEventArgs : System.EventArgs
		{
			private Entities.AddressType	_AddressType;
	
			/// <summary>
			/// the  Entities.AddressType instance.
			/// </summary>
			public Entities.AddressType AddressType
			{
				get { return _AddressType; }
				set { _AddressType = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxAddressTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnAddressTypeDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxAddressTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnAddressTypeDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxAddressTypeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxAddressTypeIdDataGridViewColumn":
						e.Value = AddressTypeList[e.RowIndex].AddressTypeId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = AddressTypeList[e.RowIndex].Name;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = AddressTypeList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = AddressTypeList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxAddressTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnAddressTypeDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxAddressTypeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxAddressTypeIdDataGridViewColumn":
						AddressTypeList[e.RowIndex].AddressTypeId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						AddressTypeList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						AddressTypeList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						AddressTypeList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
