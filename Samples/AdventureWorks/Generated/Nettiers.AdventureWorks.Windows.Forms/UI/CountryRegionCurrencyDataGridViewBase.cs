
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract CountryRegionCurrency typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CountryRegionCurrencyDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CountryRegionCurrencyDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.CountryRegionCurrency _currentCountryRegionCurrency = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCountryRegionCurrencyDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCountryRegionCurrencyErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCountryRegionCurrencyBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the CountryRegionCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCountryRegionCodeDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the CurrencyCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCurrencyCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.CountryRegion> _CountryRegionCodeList;
		
		/// <summary> 
		/// The list of selectable CountryRegion
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.CountryRegion> CountryRegionCodeList
		{
			get {return this._CountryRegionCodeList;}
			set 
			{
				this._CountryRegionCodeList = value;
				this.uxCountryRegionCodeDataGridViewColumn.DataSource = null;
				this.uxCountryRegionCodeDataGridViewColumn.DataSource = this._CountryRegionCodeList;
			}
		}
		
		private bool _allowNewItemInCountryRegionCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of CountryRegion
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCountryRegionCodeList
		{
			get { return _allowNewItemInCountryRegionCodeList;}
			set
			{
				this._allowNewItemInCountryRegionCodeList = value;
				this.uxCountryRegionCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Currency> _CurrencyCodeList;
		
		/// <summary> 
		/// The list of selectable Currency
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Currency> CurrencyCodeList
		{
			get {return this._CurrencyCodeList;}
			set 
			{
				this._CurrencyCodeList = value;
				this.uxCurrencyCodeDataGridViewColumn.DataSource = null;
				this.uxCurrencyCodeDataGridViewColumn.DataSource = this._CurrencyCodeList;
			}
		}
		
		private bool _allowNewItemInCurrencyCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Currency
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCurrencyCodeList
		{
			get { return _allowNewItemInCurrencyCodeList;}
			set
			{
				this._allowNewItemInCurrencyCodeList = value;
				this.uxCurrencyCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.CountryRegionCurrency> _CountryRegionCurrencyList;
				
		/// <summary> 
		/// The list of CountryRegionCurrency to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.CountryRegionCurrency> CountryRegionCurrencyList
		{
			get {return this._CountryRegionCurrencyList;}
			set
			{
				this._CountryRegionCurrencyList = value;
				this.uxCountryRegionCurrencyBindingSource.DataSource = null;
				this.uxCountryRegionCurrencyBindingSource.DataSource = value;
				this.uxCountryRegionCurrencyDataGridView.DataSource = null;
				this.uxCountryRegionCurrencyDataGridView.DataSource = this.uxCountryRegionCurrencyBindingSource;				
				//this.uxCountryRegionCurrencyBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCountryRegionCurrencyBindingSource_ListChanged);
				this.uxCountryRegionCurrencyBindingSource.CurrentItemChanged += new System.EventHandler(OnCountryRegionCurrencyBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCountryRegionCurrencyBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCountryRegionCurrency = uxCountryRegionCurrencyBindingSource.Current as Entities.CountryRegionCurrency;
			
			if (_currentCountryRegionCurrency != null)
			{
				_currentCountryRegionCurrency.Validate();
			}
			//_CountryRegionCurrency.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCountryRegionCurrencyBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.CountryRegionCurrency"/> instance.
		/// </summary>
		public Entities.CountryRegionCurrency SelectedCountryRegionCurrency
		{
			get {return this._currentCountryRegionCurrency;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCountryRegionCurrencyDataGridView.VirtualMode;}
			set
			{
				this.uxCountryRegionCurrencyDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCountryRegionCurrencyDataGridView.AllowUserToAddRows;}
			set {this.uxCountryRegionCurrencyDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCountryRegionCurrencyDataGridView.AllowUserToDeleteRows;}
			set {this.uxCountryRegionCurrencyDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCountryRegionCurrencyDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCountryRegionCurrencyDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CountryRegionCurrencyDataGridViewBase"/> class.
		/// </summary>
		public CountryRegionCurrencyDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCountryRegionCurrencyDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCountryRegionCurrencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCountryRegionCurrencyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCountryRegionCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxCurrencyCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxCountryRegionCodeBindingSource = new CountryRegionBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCodeBindingSource)).BeginInit();
			//this.uxCurrencyCodeBindingSource = new CurrencyBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCurrencyCodeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCurrencyDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCurrencyBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCurrencyErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCountryRegionCurrencyErrorProvider
			// 
			this.uxCountryRegionCurrencyErrorProvider.ContainerControl = this;
			this.uxCountryRegionCurrencyErrorProvider.DataSource = this.uxCountryRegionCurrencyBindingSource;						
			// 
			// uxCountryRegionCurrencyDataGridView
			// 
			this.uxCountryRegionCurrencyDataGridView.AutoGenerateColumns = false;
			this.uxCountryRegionCurrencyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCountryRegionCurrencyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCountryRegionCodeDataGridViewColumn,
		this.uxCurrencyCodeDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxCountryRegionCurrencyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCountryRegionCurrencyDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCountryRegionCurrencyDataGridView.Name = "uxCountryRegionCurrencyDataGridView";
			this.uxCountryRegionCurrencyDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCountryRegionCurrencyDataGridView.TabIndex = 0;	
			this.uxCountryRegionCurrencyDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCountryRegionCurrencyDataGridView.EnableHeadersVisualStyles = false;
			this.uxCountryRegionCurrencyDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCountryRegionCurrencyDataGridViewDataError);
			this.uxCountryRegionCurrencyDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCountryRegionCurrencyDataGridViewCellValueNeeded);
			this.uxCountryRegionCurrencyDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCountryRegionCurrencyDataGridViewCellValuePushed);
			
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
			// uxCurrencyCodeDataGridViewColumn
			//
			this.uxCurrencyCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCurrencyCodeDataGridViewColumn.DataPropertyName = "CurrencyCode";
			this.uxCurrencyCodeDataGridViewColumn.HeaderText = "CurrencyCode";
			this.uxCurrencyCodeDataGridViewColumn.Name = "uxCurrencyCodeDataGridViewColumn";
			this.uxCurrencyCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCurrencyCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCurrencyCodeDataGridViewColumn.ReadOnly = false;		
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
			// uxCountryRegionCodeDataGridViewColumn
			//				
			this.uxCountryRegionCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxCountryRegionCodeDataGridViewColumn.ValueMember = "CountryRegionCode";	
			this.uxCountryRegionCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCountryRegionCodeDataGridViewColumn.DataSource = uxCountryRegionCodeBindingSource;				
				
			//
			// uxCurrencyCodeDataGridViewColumn
			//				
			this.uxCurrencyCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxCurrencyCodeDataGridViewColumn.ValueMember = "CurrencyCode";	
			this.uxCurrencyCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCurrencyCodeDataGridViewColumn.DataSource = uxCurrencyCodeBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxCountryRegionCurrencyDataGridView);
			this.Name = "CountryRegionCurrencyDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCodeBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxCurrencyCodeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCurrencyErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCurrencyDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCountryRegionCurrencyBindingSource)).EndInit();
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
				CountryRegionCurrencyDataGridViewEventArgs args = new CountryRegionCurrencyDataGridViewEventArgs();
				args.CountryRegionCurrency = _currentCountryRegionCurrency;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CountryRegionCurrencyDataGridViewEventArgs : System.EventArgs
		{
			private Entities.CountryRegionCurrency	_CountryRegionCurrency;
	
			/// <summary>
			/// the  Entities.CountryRegionCurrency instance.
			/// </summary>
			public Entities.CountryRegionCurrency CountryRegionCurrency
			{
				get { return _CountryRegionCurrency; }
				set { _CountryRegionCurrency = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCountryRegionCurrencyDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCountryRegionCurrencyDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCountryRegionCurrencyDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCountryRegionCurrencyDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCountryRegionCurrencyDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCountryRegionCodeDataGridViewColumn":
						e.Value = CountryRegionCurrencyList[e.RowIndex].CountryRegionCode;
						break;
					case "uxCurrencyCodeDataGridViewColumn":
						e.Value = CountryRegionCurrencyList[e.RowIndex].CurrencyCode;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = CountryRegionCurrencyList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCountryRegionCurrencyDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCountryRegionCurrencyDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCountryRegionCurrencyDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCountryRegionCodeDataGridViewColumn":
						CountryRegionCurrencyList[e.RowIndex].CountryRegionCode = (System.String)e.Value;
						break;
					case "uxCurrencyCodeDataGridViewColumn":
						CountryRegionCurrencyList[e.RowIndex].CurrencyCode = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						CountryRegionCurrencyList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
