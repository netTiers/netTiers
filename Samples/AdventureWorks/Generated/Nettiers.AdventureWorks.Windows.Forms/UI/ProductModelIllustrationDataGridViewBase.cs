
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductModelIllustration typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductModelIllustrationDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductModelIllustrationDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductModelIllustration _currentProductModelIllustration = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductModelIllustrationDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductModelIllustrationErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductModelIllustrationBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the ProductModelId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductModelIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the IllustrationId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxIllustrationIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Illustration> _IllustrationIdList;
		
		/// <summary> 
		/// The list of selectable Illustration
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Illustration> IllustrationIdList
		{
			get {return this._IllustrationIdList;}
			set 
			{
				this._IllustrationIdList = value;
				this.uxIllustrationIdDataGridViewColumn.DataSource = null;
				this.uxIllustrationIdDataGridViewColumn.DataSource = this._IllustrationIdList;
			}
		}
		
		private bool _allowNewItemInIllustrationIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Illustration
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInIllustrationIdList
		{
			get { return _allowNewItemInIllustrationIdList;}
			set
			{
				this._allowNewItemInIllustrationIdList = value;
				this.uxIllustrationIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.ProductModel> _ProductModelIdList;
		
		/// <summary> 
		/// The list of selectable ProductModel
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.ProductModel> ProductModelIdList
		{
			get {return this._ProductModelIdList;}
			set 
			{
				this._ProductModelIdList = value;
				this.uxProductModelIdDataGridViewColumn.DataSource = null;
				this.uxProductModelIdDataGridViewColumn.DataSource = this._ProductModelIdList;
			}
		}
		
		private bool _allowNewItemInProductModelIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of ProductModel
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductModelIdList
		{
			get { return _allowNewItemInProductModelIdList;}
			set
			{
				this._allowNewItemInProductModelIdList = value;
				this.uxProductModelIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductModelIllustration> _ProductModelIllustrationList;
				
		/// <summary> 
		/// The list of ProductModelIllustration to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductModelIllustration> ProductModelIllustrationList
		{
			get {return this._ProductModelIllustrationList;}
			set
			{
				this._ProductModelIllustrationList = value;
				this.uxProductModelIllustrationBindingSource.DataSource = null;
				this.uxProductModelIllustrationBindingSource.DataSource = value;
				this.uxProductModelIllustrationDataGridView.DataSource = null;
				this.uxProductModelIllustrationDataGridView.DataSource = this.uxProductModelIllustrationBindingSource;				
				//this.uxProductModelIllustrationBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductModelIllustrationBindingSource_ListChanged);
				this.uxProductModelIllustrationBindingSource.CurrentItemChanged += new System.EventHandler(OnProductModelIllustrationBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductModelIllustrationBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductModelIllustration = uxProductModelIllustrationBindingSource.Current as Entities.ProductModelIllustration;
			
			if (_currentProductModelIllustration != null)
			{
				_currentProductModelIllustration.Validate();
			}
			//_ProductModelIllustration.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductModelIllustrationBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductModelIllustration"/> instance.
		/// </summary>
		public Entities.ProductModelIllustration SelectedProductModelIllustration
		{
			get {return this._currentProductModelIllustration;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductModelIllustrationDataGridView.VirtualMode;}
			set
			{
				this.uxProductModelIllustrationDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductModelIllustrationDataGridView.AllowUserToAddRows;}
			set {this.uxProductModelIllustrationDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductModelIllustrationDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductModelIllustrationDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductModelIllustrationDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductModelIllustrationDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductModelIllustrationDataGridViewBase"/> class.
		/// </summary>
		public ProductModelIllustrationDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductModelIllustrationDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductModelIllustrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductModelIllustrationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductModelIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxIllustrationIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxIllustrationIdBindingSource = new IllustrationBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxIllustrationIdBindingSource)).BeginInit();
			//this.uxProductModelIdBindingSource = new ProductModelBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductModelIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelIllustrationDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelIllustrationBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelIllustrationErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductModelIllustrationErrorProvider
			// 
			this.uxProductModelIllustrationErrorProvider.ContainerControl = this;
			this.uxProductModelIllustrationErrorProvider.DataSource = this.uxProductModelIllustrationBindingSource;						
			// 
			// uxProductModelIllustrationDataGridView
			// 
			this.uxProductModelIllustrationDataGridView.AutoGenerateColumns = false;
			this.uxProductModelIllustrationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductModelIllustrationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductModelIdDataGridViewColumn,
		this.uxIllustrationIdDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductModelIllustrationDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductModelIllustrationDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductModelIllustrationDataGridView.Name = "uxProductModelIllustrationDataGridView";
			this.uxProductModelIllustrationDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductModelIllustrationDataGridView.TabIndex = 0;	
			this.uxProductModelIllustrationDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductModelIllustrationDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductModelIllustrationDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductModelIllustrationDataGridViewDataError);
			this.uxProductModelIllustrationDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductModelIllustrationDataGridViewCellValueNeeded);
			this.uxProductModelIllustrationDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductModelIllustrationDataGridViewCellValuePushed);
			
			//
			// uxProductModelIdDataGridViewColumn
			//
			this.uxProductModelIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductModelIdDataGridViewColumn.DataPropertyName = "ProductModelId";
			this.uxProductModelIdDataGridViewColumn.HeaderText = "ProductModelId";
			this.uxProductModelIdDataGridViewColumn.Name = "uxProductModelIdDataGridViewColumn";
			this.uxProductModelIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductModelIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductModelIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxIllustrationIdDataGridViewColumn
			//
			this.uxIllustrationIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIllustrationIdDataGridViewColumn.DataPropertyName = "IllustrationId";
			this.uxIllustrationIdDataGridViewColumn.HeaderText = "IllustrationId";
			this.uxIllustrationIdDataGridViewColumn.Name = "uxIllustrationIdDataGridViewColumn";
			this.uxIllustrationIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIllustrationIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIllustrationIdDataGridViewColumn.ReadOnly = false;		
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
			// uxIllustrationIdDataGridViewColumn
			//				
			this.uxIllustrationIdDataGridViewColumn.DisplayMember = "Diagram";	
			this.uxIllustrationIdDataGridViewColumn.ValueMember = "IllustrationId";	
			this.uxIllustrationIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxIllustrationIdDataGridViewColumn.DataSource = uxIllustrationIdBindingSource;				
				
			//
			// uxProductModelIdDataGridViewColumn
			//				
			this.uxProductModelIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductModelIdDataGridViewColumn.ValueMember = "ProductModelId";	
			this.uxProductModelIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductModelIdDataGridViewColumn.DataSource = uxProductModelIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductModelIllustrationDataGridView);
			this.Name = "ProductModelIllustrationDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxIllustrationIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxProductModelIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelIllustrationErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelIllustrationDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductModelIllustrationBindingSource)).EndInit();
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
				ProductModelIllustrationDataGridViewEventArgs args = new ProductModelIllustrationDataGridViewEventArgs();
				args.ProductModelIllustration = _currentProductModelIllustration;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductModelIllustrationDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductModelIllustration	_ProductModelIllustration;
	
			/// <summary>
			/// the  Entities.ProductModelIllustration instance.
			/// </summary>
			public Entities.ProductModelIllustration ProductModelIllustration
			{
				get { return _ProductModelIllustration; }
				set { _ProductModelIllustration = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductModelIllustrationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelIllustrationDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductModelIllustrationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelIllustrationDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductModelIllustrationDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductModelIdDataGridViewColumn":
						e.Value = ProductModelIllustrationList[e.RowIndex].ProductModelId;
						break;
					case "uxIllustrationIdDataGridViewColumn":
						e.Value = ProductModelIllustrationList[e.RowIndex].IllustrationId;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductModelIllustrationList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductModelIllustrationDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductModelIllustrationDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductModelIllustrationDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductModelIdDataGridViewColumn":
						ProductModelIllustrationList[e.RowIndex].ProductModelId = (System.Int32)e.Value;
						break;
					case "uxIllustrationIdDataGridViewColumn":
						ProductModelIllustrationList[e.RowIndex].IllustrationId = (System.Int32)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductModelIllustrationList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
