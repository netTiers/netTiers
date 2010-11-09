
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductDescription typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductDescriptionDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductDescriptionDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductDescription _currentProductDescription = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductDescriptionDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductDescriptionErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductDescriptionBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ProductDescriptionId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductDescriptionIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Description property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDescriptionDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.ProductDescription> _ProductDescriptionList;
				
		/// <summary> 
		/// The list of ProductDescription to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductDescription> ProductDescriptionList
		{
			get {return this._ProductDescriptionList;}
			set
			{
				this._ProductDescriptionList = value;
				this.uxProductDescriptionBindingSource.DataSource = null;
				this.uxProductDescriptionBindingSource.DataSource = value;
				this.uxProductDescriptionDataGridView.DataSource = null;
				this.uxProductDescriptionDataGridView.DataSource = this.uxProductDescriptionBindingSource;				
				//this.uxProductDescriptionBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductDescriptionBindingSource_ListChanged);
				this.uxProductDescriptionBindingSource.CurrentItemChanged += new System.EventHandler(OnProductDescriptionBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductDescriptionBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductDescription = uxProductDescriptionBindingSource.Current as Entities.ProductDescription;
			
			if (_currentProductDescription != null)
			{
				_currentProductDescription.Validate();
			}
			//_ProductDescription.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductDescriptionBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductDescription"/> instance.
		/// </summary>
		public Entities.ProductDescription SelectedProductDescription
		{
			get {return this._currentProductDescription;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductDescriptionDataGridView.VirtualMode;}
			set
			{
				this.uxProductDescriptionDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductDescriptionDataGridView.AllowUserToAddRows;}
			set {this.uxProductDescriptionDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductDescriptionDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductDescriptionDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductDescriptionDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductDescriptionDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductDescriptionDataGridViewBase"/> class.
		/// </summary>
		public ProductDescriptionDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductDescriptionDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductDescriptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductDescriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductDescriptionIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDescriptionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDescriptionDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDescriptionBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDescriptionErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductDescriptionErrorProvider
			// 
			this.uxProductDescriptionErrorProvider.ContainerControl = this;
			this.uxProductDescriptionErrorProvider.DataSource = this.uxProductDescriptionBindingSource;						
			// 
			// uxProductDescriptionDataGridView
			// 
			this.uxProductDescriptionDataGridView.AutoGenerateColumns = false;
			this.uxProductDescriptionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductDescriptionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductDescriptionIdDataGridViewColumn,
		this.uxDescriptionDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductDescriptionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductDescriptionDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductDescriptionDataGridView.Name = "uxProductDescriptionDataGridView";
			this.uxProductDescriptionDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductDescriptionDataGridView.TabIndex = 0;	
			this.uxProductDescriptionDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductDescriptionDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductDescriptionDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductDescriptionDataGridViewDataError);
			this.uxProductDescriptionDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductDescriptionDataGridViewCellValueNeeded);
			this.uxProductDescriptionDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductDescriptionDataGridViewCellValuePushed);
			
			//
			// uxProductDescriptionIdDataGridViewColumn
			//
			this.uxProductDescriptionIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductDescriptionIdDataGridViewColumn.DataPropertyName = "ProductDescriptionId";
			this.uxProductDescriptionIdDataGridViewColumn.HeaderText = "ProductDescriptionId";
			this.uxProductDescriptionIdDataGridViewColumn.Name = "uxProductDescriptionIdDataGridViewColumn";
			this.uxProductDescriptionIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductDescriptionIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductDescriptionIdDataGridViewColumn.ReadOnly = true;		
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
			this.Controls.Add(this.uxProductDescriptionDataGridView);
			this.Name = "ProductDescriptionDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxProductDescriptionErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDescriptionDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductDescriptionBindingSource)).EndInit();
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
				ProductDescriptionDataGridViewEventArgs args = new ProductDescriptionDataGridViewEventArgs();
				args.ProductDescription = _currentProductDescription;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductDescriptionDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductDescription	_ProductDescription;
	
			/// <summary>
			/// the  Entities.ProductDescription instance.
			/// </summary>
			public Entities.ProductDescription ProductDescription
			{
				get { return _ProductDescription; }
				set { _ProductDescription = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductDescriptionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductDescriptionDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductDescriptionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductDescriptionDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductDescriptionDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductDescriptionIdDataGridViewColumn":
						e.Value = ProductDescriptionList[e.RowIndex].ProductDescriptionId;
						break;
					case "uxDescriptionDataGridViewColumn":
						e.Value = ProductDescriptionList[e.RowIndex].Description;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = ProductDescriptionList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductDescriptionList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductDescriptionDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductDescriptionDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductDescriptionDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductDescriptionIdDataGridViewColumn":
						ProductDescriptionList[e.RowIndex].ProductDescriptionId = (System.Int32)e.Value;
						break;
					case "uxDescriptionDataGridViewColumn":
						ProductDescriptionList[e.RowIndex].Description = (System.String)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						ProductDescriptionList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductDescriptionList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
