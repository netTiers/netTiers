
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract StoreContact typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class StoreContactDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<StoreContactDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.StoreContact _currentStoreContact = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxStoreContactDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxStoreContactErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxStoreContactBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the CustomerId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCustomerIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ContactId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxContactIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ContactTypeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxContactTypeIdDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Contact> _ContactIdList;
		
		/// <summary> 
		/// The list of selectable Contact
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Contact> ContactIdList
		{
			get {return this._ContactIdList;}
			set 
			{
				this._ContactIdList = value;
				this.uxContactIdDataGridViewColumn.DataSource = null;
				this.uxContactIdDataGridViewColumn.DataSource = this._ContactIdList;
			}
		}
		
		private bool _allowNewItemInContactIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Contact
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactIdList
		{
			get { return _allowNewItemInContactIdList;}
			set
			{
				this._allowNewItemInContactIdList = value;
				this.uxContactIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.ContactType> _ContactTypeIdList;
		
		/// <summary> 
		/// The list of selectable ContactType
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ContactType> ContactTypeIdList
		{
			get {return this._ContactTypeIdList;}
			set 
			{
				this._ContactTypeIdList = value;
				this.uxContactTypeIdDataGridViewColumn.DataSource = null;
				this.uxContactTypeIdDataGridViewColumn.DataSource = this._ContactTypeIdList;
			}
		}
		
		private bool _allowNewItemInContactTypeIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ContactType
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactTypeIdList
		{
			get { return _allowNewItemInContactTypeIdList;}
			set
			{
				this._allowNewItemInContactTypeIdList = value;
				this.uxContactTypeIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Store> _CustomerIdList;
		
		/// <summary> 
		/// The list of selectable Store
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Store> CustomerIdList
		{
			get {return this._CustomerIdList;}
			set 
			{
				this._CustomerIdList = value;
				this.uxCustomerIdDataGridViewColumn.DataSource = null;
				this.uxCustomerIdDataGridViewColumn.DataSource = this._CustomerIdList;
			}
		}
		
		private bool _allowNewItemInCustomerIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Store
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCustomerIdList
		{
			get { return _allowNewItemInCustomerIdList;}
			set
			{
				this._allowNewItemInCustomerIdList = value;
				this.uxCustomerIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.StoreContact> _StoreContactList;
				
		/// <summary> 
		/// The list of StoreContact to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.StoreContact> StoreContactList
		{
			get {return this._StoreContactList;}
			set
			{
				this._StoreContactList = value;
				this.uxStoreContactBindingSource.DataSource = null;
				this.uxStoreContactBindingSource.DataSource = value;
				this.uxStoreContactDataGridView.DataSource = null;
				this.uxStoreContactDataGridView.DataSource = this.uxStoreContactBindingSource;				
				//this.uxStoreContactBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxStoreContactBindingSource_ListChanged);
				this.uxStoreContactBindingSource.CurrentItemChanged += new System.EventHandler(OnStoreContactBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnStoreContactBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentStoreContact = uxStoreContactBindingSource.Current as Entities.StoreContact;
			
			if (_currentStoreContact != null)
			{
				_currentStoreContact.Validate();
			}
			//_StoreContact.Validate();
			OnCurrentEntityChanged();
		}

		//void uxStoreContactBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.StoreContact"/> instance.
		/// </summary>
		public Entities.StoreContact SelectedStoreContact
		{
			get {return this._currentStoreContact;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxStoreContactDataGridView.VirtualMode;}
			set
			{
				this.uxStoreContactDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxStoreContactDataGridView.AllowUserToAddRows;}
			set {this.uxStoreContactDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxStoreContactDataGridView.AllowUserToDeleteRows;}
			set {this.uxStoreContactDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxStoreContactDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxStoreContactDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="StoreContactDataGridViewBase"/> class.
		/// </summary>
		public StoreContactDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxStoreContactDataGridView = new System.Windows.Forms.DataGridView();
			this.uxStoreContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxStoreContactErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCustomerIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxContactIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxContactTypeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxContactIdBindingSource = new ContactBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).BeginInit();
			//this.uxContactTypeIdBindingSource = new ContactTypeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactTypeIdBindingSource)).BeginInit();
			//this.uxCustomerIdBindingSource = new StoreBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreContactDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreContactBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreContactErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxStoreContactErrorProvider
			// 
			this.uxStoreContactErrorProvider.ContainerControl = this;
			this.uxStoreContactErrorProvider.DataSource = this.uxStoreContactBindingSource;						
			// 
			// uxStoreContactDataGridView
			// 
			this.uxStoreContactDataGridView.AutoGenerateColumns = false;
			this.uxStoreContactDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxStoreContactDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCustomerIdDataGridViewColumn,
		this.uxContactIdDataGridViewColumn,
		this.uxContactTypeIdDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxStoreContactDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxStoreContactDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxStoreContactDataGridView.Name = "uxStoreContactDataGridView";
			this.uxStoreContactDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxStoreContactDataGridView.TabIndex = 0;	
			this.uxStoreContactDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxStoreContactDataGridView.EnableHeadersVisualStyles = false;
			this.uxStoreContactDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnStoreContactDataGridViewDataError);
			this.uxStoreContactDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnStoreContactDataGridViewCellValueNeeded);
			this.uxStoreContactDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnStoreContactDataGridViewCellValuePushed);
			
			//
			// uxCustomerIdDataGridViewColumn
			//
			this.uxCustomerIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCustomerIdDataGridViewColumn.DataPropertyName = "CustomerId";
			this.uxCustomerIdDataGridViewColumn.HeaderText = "CustomerId";
			this.uxCustomerIdDataGridViewColumn.Name = "uxCustomerIdDataGridViewColumn";
			this.uxCustomerIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCustomerIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCustomerIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxContactIdDataGridViewColumn
			//
			this.uxContactIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxContactIdDataGridViewColumn.DataPropertyName = "ContactId";
			this.uxContactIdDataGridViewColumn.HeaderText = "ContactId";
			this.uxContactIdDataGridViewColumn.Name = "uxContactIdDataGridViewColumn";
			this.uxContactIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxContactIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxContactIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxContactTypeIdDataGridViewColumn
			//
			this.uxContactTypeIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxContactTypeIdDataGridViewColumn.DataPropertyName = "ContactTypeId";
			this.uxContactTypeIdDataGridViewColumn.HeaderText = "ContactTypeId";
			this.uxContactTypeIdDataGridViewColumn.Name = "uxContactTypeIdDataGridViewColumn";
			this.uxContactTypeIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxContactTypeIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxContactTypeIdDataGridViewColumn.ReadOnly = false;		
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
			// uxContactIdDataGridViewColumn
			//				
			this.uxContactIdDataGridViewColumn.DisplayMember = "NameStyle";	
			this.uxContactIdDataGridViewColumn.ValueMember = "ContactId";	
			this.uxContactIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxContactIdDataGridViewColumn.DataSource = uxContactIdBindingSource;				
				
			//
			// uxContactTypeIdDataGridViewColumn
			//				
			this.uxContactTypeIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxContactTypeIdDataGridViewColumn.ValueMember = "ContactTypeId";	
			this.uxContactTypeIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxContactTypeIdDataGridViewColumn.DataSource = uxContactTypeIdBindingSource;				
				
			//
			// uxCustomerIdDataGridViewColumn
			//				
			this.uxCustomerIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxCustomerIdDataGridViewColumn.ValueMember = "CustomerId";	
			this.uxCustomerIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCustomerIdDataGridViewColumn.DataSource = uxCustomerIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxStoreContactDataGridView);
			this.Name = "StoreContactDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxContactTypeIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreContactErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreContactDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxStoreContactBindingSource)).EndInit();
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
				StoreContactDataGridViewEventArgs args = new StoreContactDataGridViewEventArgs();
				args.StoreContact = _currentStoreContact;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class StoreContactDataGridViewEventArgs : System.EventArgs
		{
			private Entities.StoreContact	_StoreContact;
	
			/// <summary>
			/// the  Entities.StoreContact instance.
			/// </summary>
			public Entities.StoreContact StoreContact
			{
				get { return _StoreContact; }
				set { _StoreContact = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxStoreContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnStoreContactDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxStoreContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnStoreContactDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxStoreContactDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						e.Value = StoreContactList[e.RowIndex].CustomerId;
						break;
					case "uxContactIdDataGridViewColumn":
						e.Value = StoreContactList[e.RowIndex].ContactId;
						break;
					case "uxContactTypeIdDataGridViewColumn":
						e.Value = StoreContactList[e.RowIndex].ContactTypeId;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = StoreContactList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = StoreContactList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxStoreContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnStoreContactDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxStoreContactDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						StoreContactList[e.RowIndex].CustomerId = (System.Int32)e.Value;
						break;
					case "uxContactIdDataGridViewColumn":
						StoreContactList[e.RowIndex].ContactId = (System.Int32)e.Value;
						break;
					case "uxContactTypeIdDataGridViewColumn":
						StoreContactList[e.RowIndex].ContactTypeId = (System.Int32)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						StoreContactList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						StoreContactList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
