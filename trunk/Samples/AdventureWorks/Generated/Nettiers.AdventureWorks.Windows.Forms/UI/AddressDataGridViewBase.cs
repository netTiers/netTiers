
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Address typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class AddressDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<AddressDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Address _currentAddress = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxAddressDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxAddressErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxAddressBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the AddressId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AddressLine1 property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressLine1DataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AddressLine2 property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressLine2DataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the City property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCityDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the StateProvinceId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxStateProvinceIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PostalCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPostalCodeDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.StateProvince> _StateProvinceIdList;
		
		/// <summary> 
		/// The list of selectable StateProvince
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.StateProvince> StateProvinceIdList
		{
			get {return this._StateProvinceIdList;}
			set 
			{
				this._StateProvinceIdList = value;
				this.uxStateProvinceIdDataGridViewColumn.DataSource = null;
				this.uxStateProvinceIdDataGridViewColumn.DataSource = this._StateProvinceIdList;
			}
		}
		
		private bool _allowNewItemInStateProvinceIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of StateProvince
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInStateProvinceIdList
		{
			get { return _allowNewItemInStateProvinceIdList;}
			set
			{
				this._allowNewItemInStateProvinceIdList = value;
				this.uxStateProvinceIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Address> _AddressList;
				
		/// <summary> 
		/// The list of Address to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Address> AddressList
		{
			get {return this._AddressList;}
			set
			{
				this._AddressList = value;
				this.uxAddressBindingSource.DataSource = null;
				this.uxAddressBindingSource.DataSource = value;
				this.uxAddressDataGridView.DataSource = null;
				this.uxAddressDataGridView.DataSource = this.uxAddressBindingSource;				
				//this.uxAddressBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxAddressBindingSource_ListChanged);
				this.uxAddressBindingSource.CurrentItemChanged += new System.EventHandler(OnAddressBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnAddressBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentAddress = uxAddressBindingSource.Current as Entities.Address;
			
			if (_currentAddress != null)
			{
				_currentAddress.Validate();
			}
			//_Address.Validate();
			OnCurrentEntityChanged();
		}

		//void uxAddressBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Address"/> instance.
		/// </summary>
		public Entities.Address SelectedAddress
		{
			get {return this._currentAddress;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxAddressDataGridView.VirtualMode;}
			set
			{
				this.uxAddressDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxAddressDataGridView.AllowUserToAddRows;}
			set {this.uxAddressDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxAddressDataGridView.AllowUserToDeleteRows;}
			set {this.uxAddressDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxAddressDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxAddressDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="AddressDataGridViewBase"/> class.
		/// </summary>
		public AddressDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxAddressDataGridView = new System.Windows.Forms.DataGridView();
			this.uxAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxAddressErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxAddressIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddressLine1DataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddressLine2DataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStateProvinceIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxPostalCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxStateProvinceIdBindingSource = new StateProvinceBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxAddressErrorProvider
			// 
			this.uxAddressErrorProvider.ContainerControl = this;
			this.uxAddressErrorProvider.DataSource = this.uxAddressBindingSource;						
			// 
			// uxAddressDataGridView
			// 
			this.uxAddressDataGridView.AutoGenerateColumns = false;
			this.uxAddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxAddressDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxAddressIdDataGridViewColumn,
		this.uxAddressLine1DataGridViewColumn,
		this.uxAddressLine2DataGridViewColumn,
		this.uxCityDataGridViewColumn,
		this.uxStateProvinceIdDataGridViewColumn,
		this.uxPostalCodeDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxAddressDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxAddressDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxAddressDataGridView.Name = "uxAddressDataGridView";
			this.uxAddressDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxAddressDataGridView.TabIndex = 0;	
			this.uxAddressDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxAddressDataGridView.EnableHeadersVisualStyles = false;
			this.uxAddressDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnAddressDataGridViewDataError);
			this.uxAddressDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnAddressDataGridViewCellValueNeeded);
			this.uxAddressDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnAddressDataGridViewCellValuePushed);
			
			//
			// uxAddressIdDataGridViewColumn
			//
			this.uxAddressIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressIdDataGridViewColumn.DataPropertyName = "AddressId";
			this.uxAddressIdDataGridViewColumn.HeaderText = "AddressId";
			this.uxAddressIdDataGridViewColumn.Name = "uxAddressIdDataGridViewColumn";
			this.uxAddressIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxAddressLine1DataGridViewColumn
			//
			this.uxAddressLine1DataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressLine1DataGridViewColumn.DataPropertyName = "AddressLine1";
			this.uxAddressLine1DataGridViewColumn.HeaderText = "AddressLine1";
			this.uxAddressLine1DataGridViewColumn.Name = "uxAddressLine1DataGridViewColumn";
			this.uxAddressLine1DataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressLine1DataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressLine1DataGridViewColumn.ReadOnly = false;		
			//
			// uxAddressLine2DataGridViewColumn
			//
			this.uxAddressLine2DataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressLine2DataGridViewColumn.DataPropertyName = "AddressLine2";
			this.uxAddressLine2DataGridViewColumn.HeaderText = "AddressLine2";
			this.uxAddressLine2DataGridViewColumn.Name = "uxAddressLine2DataGridViewColumn";
			this.uxAddressLine2DataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressLine2DataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressLine2DataGridViewColumn.ReadOnly = false;		
			//
			// uxCityDataGridViewColumn
			//
			this.uxCityDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCityDataGridViewColumn.DataPropertyName = "City";
			this.uxCityDataGridViewColumn.HeaderText = "City";
			this.uxCityDataGridViewColumn.Name = "uxCityDataGridViewColumn";
			this.uxCityDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCityDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCityDataGridViewColumn.ReadOnly = false;		
			//
			// uxStateProvinceIdDataGridViewColumn
			//
			this.uxStateProvinceIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStateProvinceIdDataGridViewColumn.DataPropertyName = "StateProvinceId";
			this.uxStateProvinceIdDataGridViewColumn.HeaderText = "StateProvinceId";
			this.uxStateProvinceIdDataGridViewColumn.Name = "uxStateProvinceIdDataGridViewColumn";
			this.uxStateProvinceIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStateProvinceIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStateProvinceIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxPostalCodeDataGridViewColumn
			//
			this.uxPostalCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPostalCodeDataGridViewColumn.DataPropertyName = "PostalCode";
			this.uxPostalCodeDataGridViewColumn.HeaderText = "PostalCode";
			this.uxPostalCodeDataGridViewColumn.Name = "uxPostalCodeDataGridViewColumn";
			this.uxPostalCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPostalCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPostalCodeDataGridViewColumn.ReadOnly = false;		
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
			//
			// uxStateProvinceIdDataGridViewColumn
			//				
			this.uxStateProvinceIdDataGridViewColumn.DisplayMember = "StateProvinceCode";	
			this.uxStateProvinceIdDataGridViewColumn.ValueMember = "StateProvinceId";	
			this.uxStateProvinceIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxStateProvinceIdDataGridViewColumn.DataSource = uxStateProvinceIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxAddressDataGridView);
			this.Name = "AddressDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxStateProvinceIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAddressBindingSource)).EndInit();
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
				AddressDataGridViewEventArgs args = new AddressDataGridViewEventArgs();
				args.Address = _currentAddress;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class AddressDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Address	_Address;
	
			/// <summary>
			/// the  Entities.Address instance.
			/// </summary>
			public Entities.Address Address
			{
				get { return _Address; }
				set { _Address = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnAddressDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnAddressDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxAddressDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxAddressIdDataGridViewColumn":
						e.Value = AddressList[e.RowIndex].AddressId;
						break;
					case "uxAddressLine1DataGridViewColumn":
						e.Value = AddressList[e.RowIndex].AddressLine1;
						break;
					case "uxAddressLine2DataGridViewColumn":
						e.Value = AddressList[e.RowIndex].AddressLine2;
						break;
					case "uxCityDataGridViewColumn":
						e.Value = AddressList[e.RowIndex].City;
						break;
					case "uxStateProvinceIdDataGridViewColumn":
						e.Value = AddressList[e.RowIndex].StateProvinceId;
						break;
					case "uxPostalCodeDataGridViewColumn":
						e.Value = AddressList[e.RowIndex].PostalCode;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = AddressList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = AddressList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxAddressDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnAddressDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxAddressDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxAddressIdDataGridViewColumn":
						AddressList[e.RowIndex].AddressId = (System.Int32)e.Value;
						break;
					case "uxAddressLine1DataGridViewColumn":
						AddressList[e.RowIndex].AddressLine1 = (System.String)e.Value;
						break;
					case "uxAddressLine2DataGridViewColumn":
						AddressList[e.RowIndex].AddressLine2 = (System.String)e.Value;
						break;
					case "uxCityDataGridViewColumn":
						AddressList[e.RowIndex].City = (System.String)e.Value;
						break;
					case "uxStateProvinceIdDataGridViewColumn":
						AddressList[e.RowIndex].StateProvinceId = (System.Int32)e.Value;
						break;
					case "uxPostalCodeDataGridViewColumn":
						AddressList[e.RowIndex].PostalCode = (System.String)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						AddressList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						AddressList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
