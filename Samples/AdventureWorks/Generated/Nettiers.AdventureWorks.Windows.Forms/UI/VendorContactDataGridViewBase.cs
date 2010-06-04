
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract VendorContact typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class VendorContactDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<VendorContactDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.VendorContact _currentVendorContact = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxVendorContactDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxVendorContactErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxVendorContactBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the VendorId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxVendorIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ContactId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxContactIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ContactTypeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxContactTypeIdDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Vendor> _VendorIdList;
		
		/// <summary> 
		/// The list of selectable Vendor
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Vendor> VendorIdList
		{
			get {return this._VendorIdList;}
			set 
			{
				this._VendorIdList = value;
				this.uxVendorIdDataGridViewColumn.DataSource = null;
				this.uxVendorIdDataGridViewColumn.DataSource = this._VendorIdList;
			}
		}
		
		private bool _allowNewItemInVendorIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Vendor
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInVendorIdList
		{
			get { return _allowNewItemInVendorIdList;}
			set
			{
				this._allowNewItemInVendorIdList = value;
				this.uxVendorIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.VendorContact> _VendorContactList;
				
		/// <summary> 
		/// The list of VendorContact to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.VendorContact> VendorContactList
		{
			get {return this._VendorContactList;}
			set
			{
				this._VendorContactList = value;
				this.uxVendorContactBindingSource.DataSource = null;
				this.uxVendorContactBindingSource.DataSource = value;
				this.uxVendorContactDataGridView.DataSource = null;
				this.uxVendorContactDataGridView.DataSource = this.uxVendorContactBindingSource;				
				//this.uxVendorContactBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxVendorContactBindingSource_ListChanged);
				this.uxVendorContactBindingSource.CurrentItemChanged += new System.EventHandler(OnVendorContactBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnVendorContactBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentVendorContact = uxVendorContactBindingSource.Current as Entities.VendorContact;
			
			if (_currentVendorContact != null)
			{
				_currentVendorContact.Validate();
			}
			//_VendorContact.Validate();
			OnCurrentEntityChanged();
		}

		//void uxVendorContactBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.VendorContact"/> instance.
		/// </summary>
		public Entities.VendorContact SelectedVendorContact
		{
			get {return this._currentVendorContact;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxVendorContactDataGridView.VirtualMode;}
			set
			{
				this.uxVendorContactDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxVendorContactDataGridView.AllowUserToAddRows;}
			set {this.uxVendorContactDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxVendorContactDataGridView.AllowUserToDeleteRows;}
			set {this.uxVendorContactDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxVendorContactDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxVendorContactDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="VendorContactDataGridViewBase"/> class.
		/// </summary>
		public VendorContactDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxVendorContactDataGridView = new System.Windows.Forms.DataGridView();
			this.uxVendorContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxVendorContactErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxVendorIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxContactIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxContactTypeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxContactIdBindingSource = new ContactBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).BeginInit();
			//this.uxContactTypeIdBindingSource = new ContactTypeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactTypeIdBindingSource)).BeginInit();
			//this.uxVendorIdBindingSource = new VendorBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxVendorIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorContactDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorContactBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorContactErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxVendorContactErrorProvider
			// 
			this.uxVendorContactErrorProvider.ContainerControl = this;
			this.uxVendorContactErrorProvider.DataSource = this.uxVendorContactBindingSource;						
			// 
			// uxVendorContactDataGridView
			// 
			this.uxVendorContactDataGridView.AutoGenerateColumns = false;
			this.uxVendorContactDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxVendorContactDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxVendorIdDataGridViewColumn,
		this.uxContactIdDataGridViewColumn,
		this.uxContactTypeIdDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxVendorContactDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxVendorContactDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxVendorContactDataGridView.Name = "uxVendorContactDataGridView";
			this.uxVendorContactDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxVendorContactDataGridView.TabIndex = 0;	
			this.uxVendorContactDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxVendorContactDataGridView.EnableHeadersVisualStyles = false;
			this.uxVendorContactDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnVendorContactDataGridViewDataError);
			this.uxVendorContactDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnVendorContactDataGridViewCellValueNeeded);
			this.uxVendorContactDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnVendorContactDataGridViewCellValuePushed);
			
			//
			// uxVendorIdDataGridViewColumn
			//
			this.uxVendorIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxVendorIdDataGridViewColumn.DataPropertyName = "VendorId";
			this.uxVendorIdDataGridViewColumn.HeaderText = "VendorId";
			this.uxVendorIdDataGridViewColumn.Name = "uxVendorIdDataGridViewColumn";
			this.uxVendorIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxVendorIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxVendorIdDataGridViewColumn.ReadOnly = false;		
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
			// uxVendorIdDataGridViewColumn
			//				
			this.uxVendorIdDataGridViewColumn.DisplayMember = "AccountNumber";	
			this.uxVendorIdDataGridViewColumn.ValueMember = "VendorId";	
			this.uxVendorIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxVendorIdDataGridViewColumn.DataSource = uxVendorIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxVendorContactDataGridView);
			this.Name = "VendorContactDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxContactTypeIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxVendorIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorContactErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorContactDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorContactBindingSource)).EndInit();
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
				VendorContactDataGridViewEventArgs args = new VendorContactDataGridViewEventArgs();
				args.VendorContact = _currentVendorContact;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class VendorContactDataGridViewEventArgs : System.EventArgs
		{
			private Entities.VendorContact	_VendorContact;
	
			/// <summary>
			/// the  Entities.VendorContact instance.
			/// </summary>
			public Entities.VendorContact VendorContact
			{
				get { return _VendorContact; }
				set { _VendorContact = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxVendorContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnVendorContactDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxVendorContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnVendorContactDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxVendorContactDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxVendorIdDataGridViewColumn":
						e.Value = VendorContactList[e.RowIndex].VendorId;
						break;
					case "uxContactIdDataGridViewColumn":
						e.Value = VendorContactList[e.RowIndex].ContactId;
						break;
					case "uxContactTypeIdDataGridViewColumn":
						e.Value = VendorContactList[e.RowIndex].ContactTypeId;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = VendorContactList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxVendorContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnVendorContactDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxVendorContactDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxVendorIdDataGridViewColumn":
						VendorContactList[e.RowIndex].VendorId = (System.Int32)e.Value;
						break;
					case "uxContactIdDataGridViewColumn":
						VendorContactList[e.RowIndex].ContactId = (System.Int32)e.Value;
						break;
					case "uxContactTypeIdDataGridViewColumn":
						VendorContactList[e.RowIndex].ContactTypeId = (System.Int32)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						VendorContactList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
