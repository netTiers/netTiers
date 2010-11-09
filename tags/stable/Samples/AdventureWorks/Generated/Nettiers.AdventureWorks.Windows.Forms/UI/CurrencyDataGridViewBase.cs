
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Currency typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CurrencyDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CurrencyDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Currency _currentCurrency = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCurrencyDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCurrencyErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCurrencyBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the CurrencyCode property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCurrencyCodeDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.Currency> _CurrencyList;
				
		/// <summary> 
		/// The list of Currency to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Currency> CurrencyList
		{
			get {return this._CurrencyList;}
			set
			{
				this._CurrencyList = value;
				this.uxCurrencyBindingSource.DataSource = null;
				this.uxCurrencyBindingSource.DataSource = value;
				this.uxCurrencyDataGridView.DataSource = null;
				this.uxCurrencyDataGridView.DataSource = this.uxCurrencyBindingSource;				
				//this.uxCurrencyBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCurrencyBindingSource_ListChanged);
				this.uxCurrencyBindingSource.CurrentItemChanged += new System.EventHandler(OnCurrencyBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCurrencyBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCurrency = uxCurrencyBindingSource.Current as Entities.Currency;
			
			if (_currentCurrency != null)
			{
				_currentCurrency.Validate();
			}
			//_Currency.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCurrencyBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Currency"/> instance.
		/// </summary>
		public Entities.Currency SelectedCurrency
		{
			get {return this._currentCurrency;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCurrencyDataGridView.VirtualMode;}
			set
			{
				this.uxCurrencyDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCurrencyDataGridView.AllowUserToAddRows;}
			set {this.uxCurrencyDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCurrencyDataGridView.AllowUserToDeleteRows;}
			set {this.uxCurrencyDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCurrencyDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCurrencyDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CurrencyDataGridViewBase"/> class.
		/// </summary>
		public CurrencyDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCurrencyDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCurrencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCurrencyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCurrencyCodeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCurrencyErrorProvider
			// 
			this.uxCurrencyErrorProvider.ContainerControl = this;
			this.uxCurrencyErrorProvider.DataSource = this.uxCurrencyBindingSource;						
			// 
			// uxCurrencyDataGridView
			// 
			this.uxCurrencyDataGridView.AutoGenerateColumns = false;
			this.uxCurrencyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCurrencyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCurrencyCodeDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxCurrencyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCurrencyDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCurrencyDataGridView.Name = "uxCurrencyDataGridView";
			this.uxCurrencyDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCurrencyDataGridView.TabIndex = 0;	
			this.uxCurrencyDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCurrencyDataGridView.EnableHeadersVisualStyles = false;
			this.uxCurrencyDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCurrencyDataGridViewDataError);
			this.uxCurrencyDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCurrencyDataGridViewCellValueNeeded);
			this.uxCurrencyDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCurrencyDataGridViewCellValuePushed);
			
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
			this.Controls.Add(this.uxCurrencyDataGridView);
			this.Name = "CurrencyDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCurrencyBindingSource)).EndInit();
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
				CurrencyDataGridViewEventArgs args = new CurrencyDataGridViewEventArgs();
				args.Currency = _currentCurrency;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CurrencyDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Currency	_Currency;
	
			/// <summary>
			/// the  Entities.Currency instance.
			/// </summary>
			public Entities.Currency Currency
			{
				get { return _Currency; }
				set { _Currency = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCurrencyDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCurrencyDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCurrencyDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCurrencyDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCurrencyDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCurrencyCodeDataGridViewColumn":
						e.Value = CurrencyList[e.RowIndex].CurrencyCode;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = CurrencyList[e.RowIndex].Name;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = CurrencyList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCurrencyDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCurrencyDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCurrencyDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCurrencyCodeDataGridViewColumn":
						CurrencyList[e.RowIndex].CurrencyCode = (System.String)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						CurrencyList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						CurrencyList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
