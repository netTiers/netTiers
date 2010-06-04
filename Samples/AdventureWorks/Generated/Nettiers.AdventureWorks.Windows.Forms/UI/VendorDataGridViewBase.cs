
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Vendor typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class VendorDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<VendorDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Vendor _currentVendor = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxVendorDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxVendorErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxVendorBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the VendorId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxVendorIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AccountNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAccountNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CreditRating property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCreditRatingDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PreferredVendorStatus property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxPreferredVendorStatusDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ActiveFlag property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxActiveFlagDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PurchasingWebServiceUrl property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPurchasingWebServiceUrlDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Vendor> _VendorList;
				
		/// <summary> 
		/// The list of Vendor to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Vendor> VendorList
		{
			get {return this._VendorList;}
			set
			{
				this._VendorList = value;
				this.uxVendorBindingSource.DataSource = null;
				this.uxVendorBindingSource.DataSource = value;
				this.uxVendorDataGridView.DataSource = null;
				this.uxVendorDataGridView.DataSource = this.uxVendorBindingSource;				
				//this.uxVendorBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxVendorBindingSource_ListChanged);
				this.uxVendorBindingSource.CurrentItemChanged += new System.EventHandler(OnVendorBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnVendorBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentVendor = uxVendorBindingSource.Current as Entities.Vendor;
			
			if (_currentVendor != null)
			{
				_currentVendor.Validate();
			}
			//_Vendor.Validate();
			OnCurrentEntityChanged();
		}

		//void uxVendorBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Vendor"/> instance.
		/// </summary>
		public Entities.Vendor SelectedVendor
		{
			get {return this._currentVendor;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxVendorDataGridView.VirtualMode;}
			set
			{
				this.uxVendorDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxVendorDataGridView.AllowUserToAddRows;}
			set {this.uxVendorDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxVendorDataGridView.AllowUserToDeleteRows;}
			set {this.uxVendorDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxVendorDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxVendorDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="VendorDataGridViewBase"/> class.
		/// </summary>
		public VendorDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxVendorDataGridView = new System.Windows.Forms.DataGridView();
			this.uxVendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxVendorErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxVendorIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAccountNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCreditRatingDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPreferredVendorStatusDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxActiveFlagDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxPurchasingWebServiceUrlDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxVendorErrorProvider
			// 
			this.uxVendorErrorProvider.ContainerControl = this;
			this.uxVendorErrorProvider.DataSource = this.uxVendorBindingSource;						
			// 
			// uxVendorDataGridView
			// 
			this.uxVendorDataGridView.AutoGenerateColumns = false;
			this.uxVendorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxVendorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxVendorIdDataGridViewColumn,
		this.uxAccountNumberDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxCreditRatingDataGridViewColumn,
		this.uxPreferredVendorStatusDataGridViewColumn,
		this.uxActiveFlagDataGridViewColumn,
		this.uxPurchasingWebServiceUrlDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxVendorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxVendorDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxVendorDataGridView.Name = "uxVendorDataGridView";
			this.uxVendorDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxVendorDataGridView.TabIndex = 0;	
			this.uxVendorDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxVendorDataGridView.EnableHeadersVisualStyles = false;
			this.uxVendorDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnVendorDataGridViewDataError);
			this.uxVendorDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnVendorDataGridViewCellValueNeeded);
			this.uxVendorDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnVendorDataGridViewCellValuePushed);
			
			//
			// uxVendorIdDataGridViewColumn
			//
			this.uxVendorIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxVendorIdDataGridViewColumn.DataPropertyName = "VendorId";
			this.uxVendorIdDataGridViewColumn.HeaderText = "VendorId";
			this.uxVendorIdDataGridViewColumn.Name = "uxVendorIdDataGridViewColumn";
			this.uxVendorIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxVendorIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxVendorIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxAccountNumberDataGridViewColumn
			//
			this.uxAccountNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAccountNumberDataGridViewColumn.DataPropertyName = "AccountNumber";
			this.uxAccountNumberDataGridViewColumn.HeaderText = "AccountNumber";
			this.uxAccountNumberDataGridViewColumn.Name = "uxAccountNumberDataGridViewColumn";
			this.uxAccountNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAccountNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAccountNumberDataGridViewColumn.ReadOnly = false;		
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
			// uxCreditRatingDataGridViewColumn
			//
			this.uxCreditRatingDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCreditRatingDataGridViewColumn.DataPropertyName = "CreditRating";
			this.uxCreditRatingDataGridViewColumn.HeaderText = "CreditRating";
			this.uxCreditRatingDataGridViewColumn.Name = "uxCreditRatingDataGridViewColumn";
			this.uxCreditRatingDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCreditRatingDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCreditRatingDataGridViewColumn.ReadOnly = false;		
			//
			// uxPreferredVendorStatusDataGridViewColumn
			//
			this.uxPreferredVendorStatusDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPreferredVendorStatusDataGridViewColumn.DataPropertyName = "PreferredVendorStatus";
			this.uxPreferredVendorStatusDataGridViewColumn.HeaderText = "PreferredVendorStatus";
			this.uxPreferredVendorStatusDataGridViewColumn.Name = "uxPreferredVendorStatusDataGridViewColumn";
			this.uxPreferredVendorStatusDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPreferredVendorStatusDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPreferredVendorStatusDataGridViewColumn.ReadOnly = false;		
			//
			// uxActiveFlagDataGridViewColumn
			//
			this.uxActiveFlagDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxActiveFlagDataGridViewColumn.DataPropertyName = "ActiveFlag";
			this.uxActiveFlagDataGridViewColumn.HeaderText = "ActiveFlag";
			this.uxActiveFlagDataGridViewColumn.Name = "uxActiveFlagDataGridViewColumn";
			this.uxActiveFlagDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxActiveFlagDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxActiveFlagDataGridViewColumn.ReadOnly = false;		
			//
			// uxPurchasingWebServiceUrlDataGridViewColumn
			//
			this.uxPurchasingWebServiceUrlDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPurchasingWebServiceUrlDataGridViewColumn.DataPropertyName = "PurchasingWebServiceUrl";
			this.uxPurchasingWebServiceUrlDataGridViewColumn.HeaderText = "PurchasingWebServiceUrl";
			this.uxPurchasingWebServiceUrlDataGridViewColumn.Name = "uxPurchasingWebServiceUrlDataGridViewColumn";
			this.uxPurchasingWebServiceUrlDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPurchasingWebServiceUrlDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPurchasingWebServiceUrlDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxVendorDataGridView);
			this.Name = "VendorDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxVendorErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxVendorBindingSource)).EndInit();
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
				VendorDataGridViewEventArgs args = new VendorDataGridViewEventArgs();
				args.Vendor = _currentVendor;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class VendorDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Vendor	_Vendor;
	
			/// <summary>
			/// the  Entities.Vendor instance.
			/// </summary>
			public Entities.Vendor Vendor
			{
				get { return _Vendor; }
				set { _Vendor = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxVendorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnVendorDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxVendorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnVendorDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxVendorDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxVendorIdDataGridViewColumn":
						e.Value = VendorList[e.RowIndex].VendorId;
						break;
					case "uxAccountNumberDataGridViewColumn":
						e.Value = VendorList[e.RowIndex].AccountNumber;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = VendorList[e.RowIndex].Name;
						break;
					case "uxCreditRatingDataGridViewColumn":
						e.Value = VendorList[e.RowIndex].CreditRating;
						break;
					case "uxPreferredVendorStatusDataGridViewColumn":
						e.Value = VendorList[e.RowIndex].PreferredVendorStatus;
						break;
					case "uxActiveFlagDataGridViewColumn":
						e.Value = VendorList[e.RowIndex].ActiveFlag;
						break;
					case "uxPurchasingWebServiceUrlDataGridViewColumn":
						e.Value = VendorList[e.RowIndex].PurchasingWebServiceUrl;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = VendorList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxVendorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnVendorDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxVendorDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxVendorIdDataGridViewColumn":
						VendorList[e.RowIndex].VendorId = (System.Int32)e.Value;
						break;
					case "uxAccountNumberDataGridViewColumn":
						VendorList[e.RowIndex].AccountNumber = (System.String)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						VendorList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxCreditRatingDataGridViewColumn":
						VendorList[e.RowIndex].CreditRating = (System.Byte)e.Value;
						break;
					case "uxPreferredVendorStatusDataGridViewColumn":
						VendorList[e.RowIndex].PreferredVendorStatus = (System.Boolean)e.Value;
						break;
					case "uxActiveFlagDataGridViewColumn":
						VendorList[e.RowIndex].ActiveFlag = (System.Boolean)e.Value;
						break;
					case "uxPurchasingWebServiceUrlDataGridViewColumn":
						VendorList[e.RowIndex].PurchasingWebServiceUrl = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						VendorList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
