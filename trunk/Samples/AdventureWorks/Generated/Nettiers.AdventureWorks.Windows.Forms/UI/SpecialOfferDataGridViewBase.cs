
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract SpecialOffer typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class SpecialOfferDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<SpecialOfferDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.SpecialOffer _currentSpecialOffer = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxSpecialOfferDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxSpecialOfferErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxSpecialOfferBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the SpecialOfferId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSpecialOfferIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Description property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDescriptionDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DiscountPct property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDiscountPctDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Type property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTypeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Category property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCategoryDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the StartDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStartDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EndDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEndDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the MinQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxMinQtyDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the MaxQty property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxMaxQtyDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.SpecialOffer> _SpecialOfferList;
				
		/// <summary> 
		/// The list of SpecialOffer to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.SpecialOffer> SpecialOfferList
		{
			get {return this._SpecialOfferList;}
			set
			{
				this._SpecialOfferList = value;
				this.uxSpecialOfferBindingSource.DataSource = null;
				this.uxSpecialOfferBindingSource.DataSource = value;
				this.uxSpecialOfferDataGridView.DataSource = null;
				this.uxSpecialOfferDataGridView.DataSource = this.uxSpecialOfferBindingSource;				
				//this.uxSpecialOfferBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxSpecialOfferBindingSource_ListChanged);
				this.uxSpecialOfferBindingSource.CurrentItemChanged += new System.EventHandler(OnSpecialOfferBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnSpecialOfferBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentSpecialOffer = uxSpecialOfferBindingSource.Current as Entities.SpecialOffer;
			
			if (_currentSpecialOffer != null)
			{
				_currentSpecialOffer.Validate();
			}
			//_SpecialOffer.Validate();
			OnCurrentEntityChanged();
		}

		//void uxSpecialOfferBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.SpecialOffer"/> instance.
		/// </summary>
		public Entities.SpecialOffer SelectedSpecialOffer
		{
			get {return this._currentSpecialOffer;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxSpecialOfferDataGridView.VirtualMode;}
			set
			{
				this.uxSpecialOfferDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxSpecialOfferDataGridView.AllowUserToAddRows;}
			set {this.uxSpecialOfferDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxSpecialOfferDataGridView.AllowUserToDeleteRows;}
			set {this.uxSpecialOfferDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxSpecialOfferDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxSpecialOfferDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="SpecialOfferDataGridViewBase"/> class.
		/// </summary>
		public SpecialOfferDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxSpecialOfferDataGridView = new System.Windows.Forms.DataGridView();
			this.uxSpecialOfferBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxSpecialOfferErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxSpecialOfferIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDescriptionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDiscountPctDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTypeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCategoryDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStartDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEndDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMinQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMaxQtyDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxSpecialOfferErrorProvider
			// 
			this.uxSpecialOfferErrorProvider.ContainerControl = this;
			this.uxSpecialOfferErrorProvider.DataSource = this.uxSpecialOfferBindingSource;						
			// 
			// uxSpecialOfferDataGridView
			// 
			this.uxSpecialOfferDataGridView.AutoGenerateColumns = false;
			this.uxSpecialOfferDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxSpecialOfferDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxSpecialOfferIdDataGridViewColumn,
		this.uxDescriptionDataGridViewColumn,
		this.uxDiscountPctDataGridViewColumn,
		this.uxTypeDataGridViewColumn,
		this.uxCategoryDataGridViewColumn,
		this.uxStartDateDataGridViewColumn,
		this.uxEndDateDataGridViewColumn,
		this.uxMinQtyDataGridViewColumn,
		this.uxMaxQtyDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxSpecialOfferDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxSpecialOfferDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxSpecialOfferDataGridView.Name = "uxSpecialOfferDataGridView";
			this.uxSpecialOfferDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxSpecialOfferDataGridView.TabIndex = 0;	
			this.uxSpecialOfferDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxSpecialOfferDataGridView.EnableHeadersVisualStyles = false;
			this.uxSpecialOfferDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnSpecialOfferDataGridViewDataError);
			this.uxSpecialOfferDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSpecialOfferDataGridViewCellValueNeeded);
			this.uxSpecialOfferDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnSpecialOfferDataGridViewCellValuePushed);
			
			//
			// uxSpecialOfferIdDataGridViewColumn
			//
			this.uxSpecialOfferIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSpecialOfferIdDataGridViewColumn.DataPropertyName = "SpecialOfferId";
			this.uxSpecialOfferIdDataGridViewColumn.HeaderText = "SpecialOfferId";
			this.uxSpecialOfferIdDataGridViewColumn.Name = "uxSpecialOfferIdDataGridViewColumn";
			this.uxSpecialOfferIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSpecialOfferIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSpecialOfferIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxDescriptionDataGridViewColumn
			//
			this.uxDescriptionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDescriptionDataGridViewColumn.DataPropertyName = "Description";
			this.uxDescriptionDataGridViewColumn.HeaderText = "Description";
			this.uxDescriptionDataGridViewColumn.Name = "uxDescriptionDataGridViewColumn";
			this.uxDescriptionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDescriptionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDescriptionDataGridViewColumn.ReadOnly = false;		
			//
			// uxDiscountPctDataGridViewColumn
			//
			this.uxDiscountPctDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDiscountPctDataGridViewColumn.DataPropertyName = "DiscountPct";
			this.uxDiscountPctDataGridViewColumn.HeaderText = "DiscountPct";
			this.uxDiscountPctDataGridViewColumn.Name = "uxDiscountPctDataGridViewColumn";
			this.uxDiscountPctDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDiscountPctDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDiscountPctDataGridViewColumn.ReadOnly = false;		
			//
			// uxTypeDataGridViewColumn
			//
			this.uxTypeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTypeDataGridViewColumn.DataPropertyName = "Type";
			this.uxTypeDataGridViewColumn.HeaderText = "Type";
			this.uxTypeDataGridViewColumn.Name = "uxTypeDataGridViewColumn";
			this.uxTypeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTypeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTypeDataGridViewColumn.ReadOnly = false;		
			//
			// uxCategoryDataGridViewColumn
			//
			this.uxCategoryDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCategoryDataGridViewColumn.DataPropertyName = "Category";
			this.uxCategoryDataGridViewColumn.HeaderText = "Category";
			this.uxCategoryDataGridViewColumn.Name = "uxCategoryDataGridViewColumn";
			this.uxCategoryDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCategoryDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCategoryDataGridViewColumn.ReadOnly = false;		
			//
			// uxStartDateDataGridViewColumn
			//
			this.uxStartDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStartDateDataGridViewColumn.DataPropertyName = "StartDate";
			this.uxStartDateDataGridViewColumn.HeaderText = "StartDate";
			this.uxStartDateDataGridViewColumn.Name = "uxStartDateDataGridViewColumn";
			this.uxStartDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStartDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStartDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxEndDateDataGridViewColumn
			//
			this.uxEndDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEndDateDataGridViewColumn.DataPropertyName = "EndDate";
			this.uxEndDateDataGridViewColumn.HeaderText = "EndDate";
			this.uxEndDateDataGridViewColumn.Name = "uxEndDateDataGridViewColumn";
			this.uxEndDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEndDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEndDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxMinQtyDataGridViewColumn
			//
			this.uxMinQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMinQtyDataGridViewColumn.DataPropertyName = "MinQty";
			this.uxMinQtyDataGridViewColumn.HeaderText = "MinQty";
			this.uxMinQtyDataGridViewColumn.Name = "uxMinQtyDataGridViewColumn";
			this.uxMinQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMinQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMinQtyDataGridViewColumn.ReadOnly = false;		
			//
			// uxMaxQtyDataGridViewColumn
			//
			this.uxMaxQtyDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMaxQtyDataGridViewColumn.DataPropertyName = "MaxQty";
			this.uxMaxQtyDataGridViewColumn.HeaderText = "MaxQty";
			this.uxMaxQtyDataGridViewColumn.Name = "uxMaxQtyDataGridViewColumn";
			this.uxMaxQtyDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMaxQtyDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMaxQtyDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxSpecialOfferDataGridView);
			this.Name = "SpecialOfferDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSpecialOfferBindingSource)).EndInit();
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
				SpecialOfferDataGridViewEventArgs args = new SpecialOfferDataGridViewEventArgs();
				args.SpecialOffer = _currentSpecialOffer;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class SpecialOfferDataGridViewEventArgs : System.EventArgs
		{
			private Entities.SpecialOffer	_SpecialOffer;
	
			/// <summary>
			/// the  Entities.SpecialOffer instance.
			/// </summary>
			public Entities.SpecialOffer SpecialOffer
			{
				get { return _SpecialOffer; }
				set { _SpecialOffer = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxSpecialOfferDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnSpecialOfferDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxSpecialOfferDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSpecialOfferDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSpecialOfferDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSpecialOfferIdDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].SpecialOfferId;
						break;
					case "uxDescriptionDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].Description;
						break;
					case "uxDiscountPctDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].DiscountPct;
						break;
					case "uxTypeDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].Type;
						break;
					case "uxCategoryDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].Category;
						break;
					case "uxStartDateDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].StartDate;
						break;
					case "uxEndDateDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].EndDate;
						break;
					case "uxMinQtyDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].MinQty;
						break;
					case "uxMaxQtyDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].MaxQty;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = SpecialOfferList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxSpecialOfferDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnSpecialOfferDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxSpecialOfferDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxSpecialOfferIdDataGridViewColumn":
						SpecialOfferList[e.RowIndex].SpecialOfferId = (System.Int32)e.Value;
						break;
					case "uxDescriptionDataGridViewColumn":
						SpecialOfferList[e.RowIndex].Description = (System.String)e.Value;
						break;
					case "uxDiscountPctDataGridViewColumn":
						SpecialOfferList[e.RowIndex].DiscountPct = (System.Decimal)e.Value;
						break;
					case "uxTypeDataGridViewColumn":
						SpecialOfferList[e.RowIndex].Type = (System.String)e.Value;
						break;
					case "uxCategoryDataGridViewColumn":
						SpecialOfferList[e.RowIndex].Category = (System.String)e.Value;
						break;
					case "uxStartDateDataGridViewColumn":
						SpecialOfferList[e.RowIndex].StartDate = (System.DateTime)e.Value;
						break;
					case "uxEndDateDataGridViewColumn":
						SpecialOfferList[e.RowIndex].EndDate = (System.DateTime)e.Value;
						break;
					case "uxMinQtyDataGridViewColumn":
						SpecialOfferList[e.RowIndex].MinQty = (System.Int32)e.Value;
						break;
					case "uxMaxQtyDataGridViewColumn":
						SpecialOfferList[e.RowIndex].MaxQty = (System.Int32?)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						SpecialOfferList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						SpecialOfferList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
