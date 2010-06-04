
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ProductReview typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductReviewDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ProductReviewDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ProductReview _currentProductReview = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxProductReviewDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxProductReviewErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxProductReviewBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ProductReviewId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxProductReviewIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the ProductId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxProductIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ReviewerName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxReviewerNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ReviewDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxReviewDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EmailAddress property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEmailAddressDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Rating property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRatingDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Comments property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCommentsDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Product> _ProductIdList;
		
		/// <summary> 
		/// The list of selectable Product
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Product> ProductIdList
		{
			get {return this._ProductIdList;}
			set 
			{
				this._ProductIdList = value;
				this.uxProductIdDataGridViewColumn.DataSource = null;
				this.uxProductIdDataGridViewColumn.DataSource = this._ProductIdList;
			}
		}
		
		private bool _allowNewItemInProductIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Product
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductIdList
		{
			get { return _allowNewItemInProductIdList;}
			set
			{
				this._allowNewItemInProductIdList = value;
				this.uxProductIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ProductReview> _ProductReviewList;
				
		/// <summary> 
		/// The list of ProductReview to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ProductReview> ProductReviewList
		{
			get {return this._ProductReviewList;}
			set
			{
				this._ProductReviewList = value;
				this.uxProductReviewBindingSource.DataSource = null;
				this.uxProductReviewBindingSource.DataSource = value;
				this.uxProductReviewDataGridView.DataSource = null;
				this.uxProductReviewDataGridView.DataSource = this.uxProductReviewBindingSource;				
				//this.uxProductReviewBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxProductReviewBindingSource_ListChanged);
				this.uxProductReviewBindingSource.CurrentItemChanged += new System.EventHandler(OnProductReviewBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnProductReviewBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentProductReview = uxProductReviewBindingSource.Current as Entities.ProductReview;
			
			if (_currentProductReview != null)
			{
				_currentProductReview.Validate();
			}
			//_ProductReview.Validate();
			OnCurrentEntityChanged();
		}

		//void uxProductReviewBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ProductReview"/> instance.
		/// </summary>
		public Entities.ProductReview SelectedProductReview
		{
			get {return this._currentProductReview;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxProductReviewDataGridView.VirtualMode;}
			set
			{
				this.uxProductReviewDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxProductReviewDataGridView.AllowUserToAddRows;}
			set {this.uxProductReviewDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxProductReviewDataGridView.AllowUserToDeleteRows;}
			set {this.uxProductReviewDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxProductReviewDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxProductReviewDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ProductReviewDataGridViewBase"/> class.
		/// </summary>
		public ProductReviewDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxProductReviewDataGridView = new System.Windows.Forms.DataGridView();
			this.uxProductReviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxProductReviewErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxProductReviewIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxProductIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxReviewerNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxReviewDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEmailAddressDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRatingDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCommentsDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxProductIdBindingSource = new ProductBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductReviewDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductReviewBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductReviewErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxProductReviewErrorProvider
			// 
			this.uxProductReviewErrorProvider.ContainerControl = this;
			this.uxProductReviewErrorProvider.DataSource = this.uxProductReviewBindingSource;						
			// 
			// uxProductReviewDataGridView
			// 
			this.uxProductReviewDataGridView.AutoGenerateColumns = false;
			this.uxProductReviewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxProductReviewDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxProductReviewIdDataGridViewColumn,
		this.uxProductIdDataGridViewColumn,
		this.uxReviewerNameDataGridViewColumn,
		this.uxReviewDateDataGridViewColumn,
		this.uxEmailAddressDataGridViewColumn,
		this.uxRatingDataGridViewColumn,
		this.uxCommentsDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxProductReviewDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxProductReviewDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxProductReviewDataGridView.Name = "uxProductReviewDataGridView";
			this.uxProductReviewDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxProductReviewDataGridView.TabIndex = 0;	
			this.uxProductReviewDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxProductReviewDataGridView.EnableHeadersVisualStyles = false;
			this.uxProductReviewDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnProductReviewDataGridViewDataError);
			this.uxProductReviewDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductReviewDataGridViewCellValueNeeded);
			this.uxProductReviewDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnProductReviewDataGridViewCellValuePushed);
			
			//
			// uxProductReviewIdDataGridViewColumn
			//
			this.uxProductReviewIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductReviewIdDataGridViewColumn.DataPropertyName = "ProductReviewId";
			this.uxProductReviewIdDataGridViewColumn.HeaderText = "ProductReviewId";
			this.uxProductReviewIdDataGridViewColumn.Name = "uxProductReviewIdDataGridViewColumn";
			this.uxProductReviewIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductReviewIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductReviewIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxProductIdDataGridViewColumn
			//
			this.uxProductIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxProductIdDataGridViewColumn.DataPropertyName = "ProductId";
			this.uxProductIdDataGridViewColumn.HeaderText = "ProductId";
			this.uxProductIdDataGridViewColumn.Name = "uxProductIdDataGridViewColumn";
			this.uxProductIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxProductIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxProductIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxReviewerNameDataGridViewColumn
			//
			this.uxReviewerNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxReviewerNameDataGridViewColumn.DataPropertyName = "ReviewerName";
			this.uxReviewerNameDataGridViewColumn.HeaderText = "ReviewerName";
			this.uxReviewerNameDataGridViewColumn.Name = "uxReviewerNameDataGridViewColumn";
			this.uxReviewerNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxReviewerNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxReviewerNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxReviewDateDataGridViewColumn
			//
			this.uxReviewDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxReviewDateDataGridViewColumn.DataPropertyName = "ReviewDate";
			this.uxReviewDateDataGridViewColumn.HeaderText = "ReviewDate";
			this.uxReviewDateDataGridViewColumn.Name = "uxReviewDateDataGridViewColumn";
			this.uxReviewDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxReviewDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxReviewDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxEmailAddressDataGridViewColumn
			//
			this.uxEmailAddressDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEmailAddressDataGridViewColumn.DataPropertyName = "EmailAddress";
			this.uxEmailAddressDataGridViewColumn.HeaderText = "EmailAddress";
			this.uxEmailAddressDataGridViewColumn.Name = "uxEmailAddressDataGridViewColumn";
			this.uxEmailAddressDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEmailAddressDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEmailAddressDataGridViewColumn.ReadOnly = false;		
			//
			// uxRatingDataGridViewColumn
			//
			this.uxRatingDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRatingDataGridViewColumn.DataPropertyName = "Rating";
			this.uxRatingDataGridViewColumn.HeaderText = "Rating";
			this.uxRatingDataGridViewColumn.Name = "uxRatingDataGridViewColumn";
			this.uxRatingDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRatingDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRatingDataGridViewColumn.ReadOnly = false;		
			//
			// uxCommentsDataGridViewColumn
			//
			this.uxCommentsDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCommentsDataGridViewColumn.DataPropertyName = "Comments";
			this.uxCommentsDataGridViewColumn.HeaderText = "Comments";
			this.uxCommentsDataGridViewColumn.Name = "uxCommentsDataGridViewColumn";
			this.uxCommentsDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCommentsDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCommentsDataGridViewColumn.ReadOnly = false;		
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
			// uxProductIdDataGridViewColumn
			//				
			this.uxProductIdDataGridViewColumn.DisplayMember = "Name";	
			this.uxProductIdDataGridViewColumn.ValueMember = "ProductId";	
			this.uxProductIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxProductIdDataGridViewColumn.DataSource = uxProductIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxProductReviewDataGridView);
			this.Name = "ProductReviewDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxProductIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductReviewErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductReviewDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxProductReviewBindingSource)).EndInit();
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
				ProductReviewDataGridViewEventArgs args = new ProductReviewDataGridViewEventArgs();
				args.ProductReview = _currentProductReview;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ProductReviewDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ProductReview	_ProductReview;
	
			/// <summary>
			/// the  Entities.ProductReview instance.
			/// </summary>
			public Entities.ProductReview ProductReview
			{
				get { return _ProductReview; }
				set { _ProductReview = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxProductReviewDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnProductReviewDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxProductReviewDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductReviewDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductReviewDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductReviewIdDataGridViewColumn":
						e.Value = ProductReviewList[e.RowIndex].ProductReviewId;
						break;
					case "uxProductIdDataGridViewColumn":
						e.Value = ProductReviewList[e.RowIndex].ProductId;
						break;
					case "uxReviewerNameDataGridViewColumn":
						e.Value = ProductReviewList[e.RowIndex].ReviewerName;
						break;
					case "uxReviewDateDataGridViewColumn":
						e.Value = ProductReviewList[e.RowIndex].ReviewDate;
						break;
					case "uxEmailAddressDataGridViewColumn":
						e.Value = ProductReviewList[e.RowIndex].EmailAddress;
						break;
					case "uxRatingDataGridViewColumn":
						e.Value = ProductReviewList[e.RowIndex].Rating;
						break;
					case "uxCommentsDataGridViewColumn":
						e.Value = ProductReviewList[e.RowIndex].Comments;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ProductReviewList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxProductReviewDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnProductReviewDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxProductReviewDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxProductReviewIdDataGridViewColumn":
						ProductReviewList[e.RowIndex].ProductReviewId = (System.Int32)e.Value;
						break;
					case "uxProductIdDataGridViewColumn":
						ProductReviewList[e.RowIndex].ProductId = (System.Int32)e.Value;
						break;
					case "uxReviewerNameDataGridViewColumn":
						ProductReviewList[e.RowIndex].ReviewerName = (System.String)e.Value;
						break;
					case "uxReviewDateDataGridViewColumn":
						ProductReviewList[e.RowIndex].ReviewDate = (System.DateTime)e.Value;
						break;
					case "uxEmailAddressDataGridViewColumn":
						ProductReviewList[e.RowIndex].EmailAddress = (System.String)e.Value;
						break;
					case "uxRatingDataGridViewColumn":
						ProductReviewList[e.RowIndex].Rating = (System.Int32)e.Value;
						break;
					case "uxCommentsDataGridViewColumn":
						ProductReviewList[e.RowIndex].Comments = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ProductReviewList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
