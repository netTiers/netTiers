
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract CurrencyRate typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CurrencyRateDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CurrencyRateDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.CurrencyRate _currentCurrencyRate = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCurrencyRateDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCurrencyRateErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCurrencyRateBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the CurrencyRateId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCurrencyRateIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CurrencyRateDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCurrencyRateDateDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the FromCurrencyCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxFromCurrencyCodeDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ToCurrencyCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxToCurrencyCodeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AverageRate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAverageRateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EndOfDayRate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEndOfDayRateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Currency> _FromCurrencyCodeList;
		
		/// <summary> 
		/// The list of selectable Currency
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Currency> FromCurrencyCodeList
		{
			get {return this._FromCurrencyCodeList;}
			set 
			{
				this._FromCurrencyCodeList = value;
				this.uxFromCurrencyCodeDataGridViewColumn.DataSource = null;
				this.uxFromCurrencyCodeDataGridViewColumn.DataSource = this._FromCurrencyCodeList;
			}
		}
		
		private bool _allowNewItemInFromCurrencyCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Currency
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInFromCurrencyCodeList
		{
			get { return _allowNewItemInFromCurrencyCodeList;}
			set
			{
				this._allowNewItemInFromCurrencyCodeList = value;
				this.uxFromCurrencyCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.Currency> _ToCurrencyCodeList;
		
		/// <summary> 
		/// The list of selectable Currency
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Currency> ToCurrencyCodeList
		{
			get {return this._ToCurrencyCodeList;}
			set 
			{
				this._ToCurrencyCodeList = value;
				this.uxToCurrencyCodeDataGridViewColumn.DataSource = null;
				this.uxToCurrencyCodeDataGridViewColumn.DataSource = this._ToCurrencyCodeList;
			}
		}
		
		private bool _allowNewItemInToCurrencyCodeList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Currency
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInToCurrencyCodeList
		{
			get { return _allowNewItemInToCurrencyCodeList;}
			set
			{
				this._allowNewItemInToCurrencyCodeList = value;
				this.uxToCurrencyCodeDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.CurrencyRate> _CurrencyRateList;
				
		/// <summary> 
		/// The list of CurrencyRate to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.CurrencyRate> CurrencyRateList
		{
			get {return this._CurrencyRateList;}
			set
			{
				this._CurrencyRateList = value;
				this.uxCurrencyRateBindingSource.DataSource = null;
				this.uxCurrencyRateBindingSource.DataSource = value;
				this.uxCurrencyRateDataGridView.DataSource = null;
				this.uxCurrencyRateDataGridView.DataSource = this.uxCurrencyRateBindingSource;				
				//this.uxCurrencyRateBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCurrencyRateBindingSource_ListChanged);
				this.uxCurrencyRateBindingSource.CurrentItemChanged += new System.EventHandler(OnCurrencyRateBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCurrencyRateBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCurrencyRate = uxCurrencyRateBindingSource.Current as Entities.CurrencyRate;
			
			if (_currentCurrencyRate != null)
			{
				_currentCurrencyRate.Validate();
			}
			//_CurrencyRate.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCurrencyRateBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.CurrencyRate"/> instance.
		/// </summary>
		public Entities.CurrencyRate SelectedCurrencyRate
		{
			get {return this._currentCurrencyRate;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCurrencyRateDataGridView.VirtualMode;}
			set
			{
				this.uxCurrencyRateDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCurrencyRateDataGridView.AllowUserToAddRows;}
			set {this.uxCurrencyRateDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCurrencyRateDataGridView.AllowUserToDeleteRows;}
			set {this.uxCurrencyRateDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCurrencyRateDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCurrencyRateDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CurrencyRateDataGridViewBase"/> class.
		/// </summary>
		public CurrencyRateDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCurrencyRateDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCurrencyRateBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCurrencyRateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCurrencyRateIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCurrencyRateDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFromCurrencyCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxToCurrencyCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAverageRateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndOfDayRateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxFromCurrencyCodeBindingSource = new CurrencyBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxFromCurrencyCodeBindingSource)).BeginInit();
			//this.uxToCurrencyCodeBindingSource = new CurrencyBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxToCurrencyCodeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyRateDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyRateBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyRateErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCurrencyRateErrorProvider
			// 
			this.uxCurrencyRateErrorProvider.ContainerControl = this;
			this.uxCurrencyRateErrorProvider.DataSource = this.uxCurrencyRateBindingSource;						
			// 
			// uxCurrencyRateDataGridView
			// 
			this.uxCurrencyRateDataGridView.AutoGenerateColumns = false;
			this.uxCurrencyRateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCurrencyRateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCurrencyRateIdDataGridViewColumn,
		this.uxCurrencyRateDateDataGridViewColumn,
		this.uxFromCurrencyCodeDataGridViewColumn,
		this.uxToCurrencyCodeDataGridViewColumn,
		this.uxAverageRateDataGridViewColumn,
		this.uxEndOfDayRateDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxCurrencyRateDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCurrencyRateDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCurrencyRateDataGridView.Name = "uxCurrencyRateDataGridView";
			this.uxCurrencyRateDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCurrencyRateDataGridView.TabIndex = 0;	
			this.uxCurrencyRateDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCurrencyRateDataGridView.EnableHeadersVisualStyles = false;
			this.uxCurrencyRateDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCurrencyRateDataGridViewDataError);
			this.uxCurrencyRateDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCurrencyRateDataGridViewCellValueNeeded);
			this.uxCurrencyRateDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCurrencyRateDataGridViewCellValuePushed);
			
			//
			// uxCurrencyRateIdDataGridViewColumn
			//
			this.uxCurrencyRateIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCurrencyRateIdDataGridViewColumn.DataPropertyName = "CurrencyRateId";
			this.uxCurrencyRateIdDataGridViewColumn.HeaderText = "CurrencyRateId";
			this.uxCurrencyRateIdDataGridViewColumn.Name = "uxCurrencyRateIdDataGridViewColumn";
			this.uxCurrencyRateIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCurrencyRateIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCurrencyRateIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxCurrencyRateDateDataGridViewColumn
			//
			this.uxCurrencyRateDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCurrencyRateDateDataGridViewColumn.DataPropertyName = "CurrencyRateDate";
			this.uxCurrencyRateDateDataGridViewColumn.HeaderText = "CurrencyRateDate";
			this.uxCurrencyRateDateDataGridViewColumn.Name = "uxCurrencyRateDateDataGridViewColumn";
			this.uxCurrencyRateDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCurrencyRateDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCurrencyRateDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxFromCurrencyCodeDataGridViewColumn
			//
			this.uxFromCurrencyCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFromCurrencyCodeDataGridViewColumn.DataPropertyName = "FromCurrencyCode";
			this.uxFromCurrencyCodeDataGridViewColumn.HeaderText = "FromCurrencyCode";
			this.uxFromCurrencyCodeDataGridViewColumn.Name = "uxFromCurrencyCodeDataGridViewColumn";
			this.uxFromCurrencyCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFromCurrencyCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFromCurrencyCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxToCurrencyCodeDataGridViewColumn
			//
			this.uxToCurrencyCodeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxToCurrencyCodeDataGridViewColumn.DataPropertyName = "ToCurrencyCode";
			this.uxToCurrencyCodeDataGridViewColumn.HeaderText = "ToCurrencyCode";
			this.uxToCurrencyCodeDataGridViewColumn.Name = "uxToCurrencyCodeDataGridViewColumn";
			this.uxToCurrencyCodeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxToCurrencyCodeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxToCurrencyCodeDataGridViewColumn.ReadOnly = false;		
			//
			// uxAverageRateDataGridViewColumn
			//
			this.uxAverageRateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAverageRateDataGridViewColumn.DataPropertyName = "AverageRate";
			this.uxAverageRateDataGridViewColumn.HeaderText = "AverageRate";
			this.uxAverageRateDataGridViewColumn.Name = "uxAverageRateDataGridViewColumn";
			this.uxAverageRateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAverageRateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAverageRateDataGridViewColumn.ReadOnly = false;		
			//
			// uxEndOfDayRateDataGridViewColumn
			//
			this.uxEndOfDayRateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEndOfDayRateDataGridViewColumn.DataPropertyName = "EndOfDayRate";
			this.uxEndOfDayRateDataGridViewColumn.HeaderText = "EndOfDayRate";
			this.uxEndOfDayRateDataGridViewColumn.Name = "uxEndOfDayRateDataGridViewColumn";
			this.uxEndOfDayRateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEndOfDayRateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEndOfDayRateDataGridViewColumn.ReadOnly = false;		
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
			// uxFromCurrencyCodeDataGridViewColumn
			//				
			this.uxFromCurrencyCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxFromCurrencyCodeDataGridViewColumn.ValueMember = "CurrencyCode";	
			this.uxFromCurrencyCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxFromCurrencyCodeDataGridViewColumn.DataSource = uxFromCurrencyCodeBindingSource;				
				
			//
			// uxToCurrencyCodeDataGridViewColumn
			//				
			this.uxToCurrencyCodeDataGridViewColumn.DisplayMember = "Name";	
			this.uxToCurrencyCodeDataGridViewColumn.ValueMember = "CurrencyCode";	
			this.uxToCurrencyCodeDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxToCurrencyCodeDataGridViewColumn.DataSource = uxToCurrencyCodeBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxCurrencyRateDataGridView);
			this.Name = "CurrencyRateDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxFromCurrencyCodeBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxToCurrencyCodeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyRateErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyRateDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyRateBindingSource)).EndInit();
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
				CurrencyRateDataGridViewEventArgs args = new CurrencyRateDataGridViewEventArgs();
				args.CurrencyRate = _currentCurrencyRate;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CurrencyRateDataGridViewEventArgs : System.EventArgs
		{
			private Entities.CurrencyRate	_CurrencyRate;
	
			/// <summary>
			/// the  Entities.CurrencyRate instance.
			/// </summary>
			public Entities.CurrencyRate CurrencyRate
			{
				get { return _CurrencyRate; }
				set { _CurrencyRate = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCurrencyRateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCurrencyRateDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCurrencyRateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCurrencyRateDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCurrencyRateDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCurrencyRateIdDataGridViewColumn":
						e.Value = CurrencyRateList[e.RowIndex].CurrencyRateId;
						break;
					case "uxCurrencyRateDateDataGridViewColumn":
						e.Value = CurrencyRateList[e.RowIndex].CurrencyRateDate;
						break;
					case "uxFromCurrencyCodeDataGridViewColumn":
						e.Value = CurrencyRateList[e.RowIndex].FromCurrencyCode;
						break;
					case "uxToCurrencyCodeDataGridViewColumn":
						e.Value = CurrencyRateList[e.RowIndex].ToCurrencyCode;
						break;
					case "uxAverageRateDataGridViewColumn":
						e.Value = CurrencyRateList[e.RowIndex].AverageRate;
						break;
					case "uxEndOfDayRateDataGridViewColumn":
						e.Value = CurrencyRateList[e.RowIndex].EndOfDayRate;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = CurrencyRateList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCurrencyRateDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCurrencyRateDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCurrencyRateDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCurrencyRateIdDataGridViewColumn":
						CurrencyRateList[e.RowIndex].CurrencyRateId = (System.Int32)e.Value;
						break;
					case "uxCurrencyRateDateDataGridViewColumn":
						CurrencyRateList[e.RowIndex].CurrencyRateDate = (System.DateTime)e.Value;
						break;
					case "uxFromCurrencyCodeDataGridViewColumn":
						CurrencyRateList[e.RowIndex].FromCurrencyCode = (System.String)e.Value;
						break;
					case "uxToCurrencyCodeDataGridViewColumn":
						CurrencyRateList[e.RowIndex].ToCurrencyCode = (System.String)e.Value;
						break;
					case "uxAverageRateDataGridViewColumn":
						CurrencyRateList[e.RowIndex].AverageRate = (System.Decimal)e.Value;
						break;
					case "uxEndOfDayRateDataGridViewColumn":
						CurrencyRateList[e.RowIndex].EndOfDayRate = (System.Decimal)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						CurrencyRateList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
