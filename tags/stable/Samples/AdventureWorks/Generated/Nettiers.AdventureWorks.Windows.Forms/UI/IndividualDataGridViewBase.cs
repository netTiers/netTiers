
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Individual typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class IndividualDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<IndividualDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Individual _currentIndividual = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxIndividualDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxIndividualErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxIndividualBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the CustomerId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCustomerIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ContactId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxContactIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Demographics property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDemographicsDataGridViewColumn;
		
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
		
				
		private Entities.TList<Entities.Customer> _CustomerIdList;
		
		/// <summary> 
		/// The list of selectable Customer
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Customer> CustomerIdList
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
		/// Indicates if user can add an item in the list of Customer
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
		
		private Entities.TList<Entities.Individual> _IndividualList;
				
		/// <summary> 
		/// The list of Individual to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Individual> IndividualList
		{
			get {return this._IndividualList;}
			set
			{
				this._IndividualList = value;
				this.uxIndividualBindingSource.DataSource = null;
				this.uxIndividualBindingSource.DataSource = value;
				this.uxIndividualDataGridView.DataSource = null;
				this.uxIndividualDataGridView.DataSource = this.uxIndividualBindingSource;				
				//this.uxIndividualBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxIndividualBindingSource_ListChanged);
				this.uxIndividualBindingSource.CurrentItemChanged += new System.EventHandler(OnIndividualBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnIndividualBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentIndividual = uxIndividualBindingSource.Current as Entities.Individual;
			
			if (_currentIndividual != null)
			{
				_currentIndividual.Validate();
			}
			//_Individual.Validate();
			OnCurrentEntityChanged();
		}

		//void uxIndividualBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Individual"/> instance.
		/// </summary>
		public Entities.Individual SelectedIndividual
		{
			get {return this._currentIndividual;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxIndividualDataGridView.VirtualMode;}
			set
			{
				this.uxIndividualDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxIndividualDataGridView.AllowUserToAddRows;}
			set {this.uxIndividualDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxIndividualDataGridView.AllowUserToDeleteRows;}
			set {this.uxIndividualDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxIndividualDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxIndividualDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="IndividualDataGridViewBase"/> class.
		/// </summary>
		public IndividualDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxIndividualDataGridView = new System.Windows.Forms.DataGridView();
			this.uxIndividualBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxIndividualErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCustomerIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxContactIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxDemographicsDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxContactIdBindingSource = new ContactBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).BeginInit();
			//this.uxCustomerIdBindingSource = new CustomerBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIndividualDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIndividualBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIndividualErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxIndividualErrorProvider
			// 
			this.uxIndividualErrorProvider.ContainerControl = this;
			this.uxIndividualErrorProvider.DataSource = this.uxIndividualBindingSource;						
			// 
			// uxIndividualDataGridView
			// 
			this.uxIndividualDataGridView.AutoGenerateColumns = false;
			this.uxIndividualDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxIndividualDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCustomerIdDataGridViewColumn,
		this.uxContactIdDataGridViewColumn,
		this.uxDemographicsDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxIndividualDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxIndividualDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxIndividualDataGridView.Name = "uxIndividualDataGridView";
			this.uxIndividualDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxIndividualDataGridView.TabIndex = 0;	
			this.uxIndividualDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxIndividualDataGridView.EnableHeadersVisualStyles = false;
			this.uxIndividualDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnIndividualDataGridViewDataError);
			this.uxIndividualDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnIndividualDataGridViewCellValueNeeded);
			this.uxIndividualDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnIndividualDataGridViewCellValuePushed);
			
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
			// uxDemographicsDataGridViewColumn
			//
			this.uxDemographicsDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDemographicsDataGridViewColumn.DataPropertyName = "Demographics";
			this.uxDemographicsDataGridViewColumn.HeaderText = "Demographics";
			this.uxDemographicsDataGridViewColumn.Name = "uxDemographicsDataGridViewColumn";
			this.uxDemographicsDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDemographicsDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDemographicsDataGridViewColumn.ReadOnly = false;		
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
			// uxCustomerIdDataGridViewColumn
			//				
			this.uxCustomerIdDataGridViewColumn.DisplayMember = "TerritoryId";	
			this.uxCustomerIdDataGridViewColumn.ValueMember = "CustomerId";	
			this.uxCustomerIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCustomerIdDataGridViewColumn.DataSource = uxCustomerIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxIndividualDataGridView);
			this.Name = "IndividualDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxCustomerIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIndividualErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIndividualDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIndividualBindingSource)).EndInit();
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
				IndividualDataGridViewEventArgs args = new IndividualDataGridViewEventArgs();
				args.Individual = _currentIndividual;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class IndividualDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Individual	_Individual;
	
			/// <summary>
			/// the  Entities.Individual instance.
			/// </summary>
			public Entities.Individual Individual
			{
				get { return _Individual; }
				set { _Individual = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxIndividualDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnIndividualDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxIndividualDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnIndividualDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxIndividualDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						e.Value = IndividualList[e.RowIndex].CustomerId;
						break;
					case "uxContactIdDataGridViewColumn":
						e.Value = IndividualList[e.RowIndex].ContactId;
						break;
					case "uxDemographicsDataGridViewColumn":
						e.Value = IndividualList[e.RowIndex].Demographics;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = IndividualList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxIndividualDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnIndividualDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxIndividualDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCustomerIdDataGridViewColumn":
						IndividualList[e.RowIndex].CustomerId = (System.Int32)e.Value;
						break;
					case "uxContactIdDataGridViewColumn":
						IndividualList[e.RowIndex].ContactId = (System.Int32)e.Value;
						break;
					case "uxDemographicsDataGridViewColumn":
						IndividualList[e.RowIndex].Demographics = (string)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						IndividualList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
