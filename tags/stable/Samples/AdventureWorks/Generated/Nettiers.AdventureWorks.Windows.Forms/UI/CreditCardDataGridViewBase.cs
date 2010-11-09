
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract CreditCard typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CreditCardDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CreditCardDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.CreditCard _currentCreditCard = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCreditCardDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCreditCardErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCreditCardBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the CreditCardId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCreditCardIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CardType property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCardTypeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CardNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCardNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ExpMonth property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxExpMonthDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ExpYear property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxExpYearDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.CreditCard> _CreditCardList;
				
		/// <summary> 
		/// The list of CreditCard to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.CreditCard> CreditCardList
		{
			get {return this._CreditCardList;}
			set
			{
				this._CreditCardList = value;
				this.uxCreditCardBindingSource.DataSource = null;
				this.uxCreditCardBindingSource.DataSource = value;
				this.uxCreditCardDataGridView.DataSource = null;
				this.uxCreditCardDataGridView.DataSource = this.uxCreditCardBindingSource;				
				//this.uxCreditCardBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCreditCardBindingSource_ListChanged);
				this.uxCreditCardBindingSource.CurrentItemChanged += new System.EventHandler(OnCreditCardBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCreditCardBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCreditCard = uxCreditCardBindingSource.Current as Entities.CreditCard;
			
			if (_currentCreditCard != null)
			{
				_currentCreditCard.Validate();
			}
			//_CreditCard.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCreditCardBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.CreditCard"/> instance.
		/// </summary>
		public Entities.CreditCard SelectedCreditCard
		{
			get {return this._currentCreditCard;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCreditCardDataGridView.VirtualMode;}
			set
			{
				this.uxCreditCardDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCreditCardDataGridView.AllowUserToAddRows;}
			set {this.uxCreditCardDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCreditCardDataGridView.AllowUserToDeleteRows;}
			set {this.uxCreditCardDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCreditCardDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCreditCardDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CreditCardDataGridViewBase"/> class.
		/// </summary>
		public CreditCardDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCreditCardDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCreditCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCreditCardErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCreditCardIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCardTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCardNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxExpMonthDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxExpYearDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxCreditCardDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCreditCardBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCreditCardErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCreditCardErrorProvider
			// 
			this.uxCreditCardErrorProvider.ContainerControl = this;
			this.uxCreditCardErrorProvider.DataSource = this.uxCreditCardBindingSource;						
			// 
			// uxCreditCardDataGridView
			// 
			this.uxCreditCardDataGridView.AutoGenerateColumns = false;
			this.uxCreditCardDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCreditCardDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCreditCardIdDataGridViewColumn,
		this.uxCardTypeDataGridViewColumn,
		this.uxCardNumberDataGridViewColumn,
		this.uxExpMonthDataGridViewColumn,
		this.uxExpYearDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxCreditCardDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCreditCardDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCreditCardDataGridView.Name = "uxCreditCardDataGridView";
			this.uxCreditCardDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCreditCardDataGridView.TabIndex = 0;	
			this.uxCreditCardDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCreditCardDataGridView.EnableHeadersVisualStyles = false;
			this.uxCreditCardDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCreditCardDataGridViewDataError);
			this.uxCreditCardDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCreditCardDataGridViewCellValueNeeded);
			this.uxCreditCardDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCreditCardDataGridViewCellValuePushed);
			
			//
			// uxCreditCardIdDataGridViewColumn
			//
			this.uxCreditCardIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCreditCardIdDataGridViewColumn.DataPropertyName = "CreditCardId";
			this.uxCreditCardIdDataGridViewColumn.HeaderText = "CreditCardId";
			this.uxCreditCardIdDataGridViewColumn.Name = "uxCreditCardIdDataGridViewColumn";
			this.uxCreditCardIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCreditCardIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCreditCardIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxCardTypeDataGridViewColumn
			//
			this.uxCardTypeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCardTypeDataGridViewColumn.DataPropertyName = "CardType";
			this.uxCardTypeDataGridViewColumn.HeaderText = "CardType";
			this.uxCardTypeDataGridViewColumn.Name = "uxCardTypeDataGridViewColumn";
			this.uxCardTypeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCardTypeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCardTypeDataGridViewColumn.ReadOnly = false;		
			//
			// uxCardNumberDataGridViewColumn
			//
			this.uxCardNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCardNumberDataGridViewColumn.DataPropertyName = "CardNumber";
			this.uxCardNumberDataGridViewColumn.HeaderText = "CardNumber";
			this.uxCardNumberDataGridViewColumn.Name = "uxCardNumberDataGridViewColumn";
			this.uxCardNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCardNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCardNumberDataGridViewColumn.ReadOnly = false;		
			//
			// uxExpMonthDataGridViewColumn
			//
			this.uxExpMonthDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxExpMonthDataGridViewColumn.DataPropertyName = "ExpMonth";
			this.uxExpMonthDataGridViewColumn.HeaderText = "ExpMonth";
			this.uxExpMonthDataGridViewColumn.Name = "uxExpMonthDataGridViewColumn";
			this.uxExpMonthDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxExpMonthDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxExpMonthDataGridViewColumn.ReadOnly = false;		
			//
			// uxExpYearDataGridViewColumn
			//
			this.uxExpYearDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxExpYearDataGridViewColumn.DataPropertyName = "ExpYear";
			this.uxExpYearDataGridViewColumn.HeaderText = "ExpYear";
			this.uxExpYearDataGridViewColumn.Name = "uxExpYearDataGridViewColumn";
			this.uxExpYearDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxExpYearDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxExpYearDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxCreditCardDataGridView);
			this.Name = "CreditCardDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxCreditCardErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCreditCardDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCreditCardBindingSource)).EndInit();
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
				CreditCardDataGridViewEventArgs args = new CreditCardDataGridViewEventArgs();
				args.CreditCard = _currentCreditCard;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CreditCardDataGridViewEventArgs : System.EventArgs
		{
			private Entities.CreditCard	_CreditCard;
	
			/// <summary>
			/// the  Entities.CreditCard instance.
			/// </summary>
			public Entities.CreditCard CreditCard
			{
				get { return _CreditCard; }
				set { _CreditCard = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCreditCardDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCreditCardDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCreditCardDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCreditCardDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCreditCardDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCreditCardIdDataGridViewColumn":
						e.Value = CreditCardList[e.RowIndex].CreditCardId;
						break;
					case "uxCardTypeDataGridViewColumn":
						e.Value = CreditCardList[e.RowIndex].CardType;
						break;
					case "uxCardNumberDataGridViewColumn":
						e.Value = CreditCardList[e.RowIndex].CardNumber;
						break;
					case "uxExpMonthDataGridViewColumn":
						e.Value = CreditCardList[e.RowIndex].ExpMonth;
						break;
					case "uxExpYearDataGridViewColumn":
						e.Value = CreditCardList[e.RowIndex].ExpYear;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = CreditCardList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCreditCardDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCreditCardDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCreditCardDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCreditCardIdDataGridViewColumn":
						CreditCardList[e.RowIndex].CreditCardId = (System.Int32)e.Value;
						break;
					case "uxCardTypeDataGridViewColumn":
						CreditCardList[e.RowIndex].CardType = (System.String)e.Value;
						break;
					case "uxCardNumberDataGridViewColumn":
						CreditCardList[e.RowIndex].CardNumber = (System.String)e.Value;
						break;
					case "uxExpMonthDataGridViewColumn":
						CreditCardList[e.RowIndex].ExpMonth = (System.Byte)e.Value;
						break;
					case "uxExpYearDataGridViewColumn":
						CreditCardList[e.RowIndex].ExpYear = (System.Int16)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						CreditCardList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
