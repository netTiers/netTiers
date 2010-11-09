
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract NullFkeyChild typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class NullFkeyChildDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<NullFkeyChildDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.NullFkeyChild _currentNullFkeyChild = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxNullFkeyChildDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxNullFkeyChildErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxNullFkeyChildBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the NullFkeyChildId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNullFkeyChildIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the NullFkeyParentId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxNullFkeyParentIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SomeText property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSomeTextDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.NullFkeyParent> _NullFkeyParentIdList;
		
		/// <summary> 
		/// The list of selectable NullFkeyParent
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.NullFkeyParent> NullFkeyParentIdList
		{
			get {return this._NullFkeyParentIdList;}
			set 
			{
				this._NullFkeyParentIdList = value;
				this.uxNullFkeyParentIdDataGridViewColumn.DataSource = null;
				this.uxNullFkeyParentIdDataGridViewColumn.DataSource = this._NullFkeyParentIdList;
			}
		}
		
		private bool _allowNewItemInNullFkeyParentIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of NullFkeyParent
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInNullFkeyParentIdList
		{
			get { return _allowNewItemInNullFkeyParentIdList;}
			set
			{
				this._allowNewItemInNullFkeyParentIdList = value;
				this.uxNullFkeyParentIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.NullFkeyChild> _NullFkeyChildList;
				
		/// <summary> 
		/// The list of NullFkeyChild to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.NullFkeyChild> NullFkeyChildList
		{
			get {return this._NullFkeyChildList;}
			set
			{
				this._NullFkeyChildList = value;
				this.uxNullFkeyChildBindingSource.DataSource = null;
				this.uxNullFkeyChildBindingSource.DataSource = value;
				this.uxNullFkeyChildDataGridView.DataSource = null;
				this.uxNullFkeyChildDataGridView.DataSource = this.uxNullFkeyChildBindingSource;				
				//this.uxNullFkeyChildBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxNullFkeyChildBindingSource_ListChanged);
				this.uxNullFkeyChildBindingSource.CurrentItemChanged += new System.EventHandler(OnNullFkeyChildBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnNullFkeyChildBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentNullFkeyChild = uxNullFkeyChildBindingSource.Current as Entities.NullFkeyChild;
			
			if (_currentNullFkeyChild != null)
			{
				_currentNullFkeyChild.Validate();
			}
			//_NullFkeyChild.Validate();
			OnCurrentEntityChanged();
		}

		//void uxNullFkeyChildBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.NullFkeyChild"/> instance.
		/// </summary>
		public Entities.NullFkeyChild SelectedNullFkeyChild
		{
			get {return this._currentNullFkeyChild;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxNullFkeyChildDataGridView.VirtualMode;}
			set
			{
				this.uxNullFkeyChildDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxNullFkeyChildDataGridView.AllowUserToAddRows;}
			set {this.uxNullFkeyChildDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxNullFkeyChildDataGridView.AllowUserToDeleteRows;}
			set {this.uxNullFkeyChildDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxNullFkeyChildDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxNullFkeyChildDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="NullFkeyChildDataGridViewBase"/> class.
		/// </summary>
		public NullFkeyChildDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxNullFkeyChildDataGridView = new System.Windows.Forms.DataGridView();
			this.uxNullFkeyChildBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxNullFkeyChildErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxNullFkeyChildIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNullFkeyParentIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSomeTextDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxNullFkeyParentIdBindingSource = new NullFkeyParentBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyParentIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyChildDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyChildBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyChildErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxNullFkeyChildErrorProvider
			// 
			this.uxNullFkeyChildErrorProvider.ContainerControl = this;
			this.uxNullFkeyChildErrorProvider.DataSource = this.uxNullFkeyChildBindingSource;						
			// 
			// uxNullFkeyChildDataGridView
			// 
			this.uxNullFkeyChildDataGridView.AutoGenerateColumns = false;
			this.uxNullFkeyChildDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxNullFkeyChildDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxNullFkeyChildIdDataGridViewColumn,
		this.uxNullFkeyParentIdDataGridViewColumn,
		this.uxSomeTextDataGridViewColumn			});
			this.uxNullFkeyChildDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxNullFkeyChildDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxNullFkeyChildDataGridView.Name = "uxNullFkeyChildDataGridView";
			this.uxNullFkeyChildDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxNullFkeyChildDataGridView.TabIndex = 0;	
			this.uxNullFkeyChildDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxNullFkeyChildDataGridView.EnableHeadersVisualStyles = false;
			this.uxNullFkeyChildDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnNullFkeyChildDataGridViewDataError);
			this.uxNullFkeyChildDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnNullFkeyChildDataGridViewCellValueNeeded);
			this.uxNullFkeyChildDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnNullFkeyChildDataGridViewCellValuePushed);
			
			//
			// uxNullFkeyChildIdDataGridViewColumn
			//
			this.uxNullFkeyChildIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxNullFkeyChildIdDataGridViewColumn.DataPropertyName = "NullFkeyChildId";
			this.uxNullFkeyChildIdDataGridViewColumn.HeaderText = "NullFkeyChildId";
			this.uxNullFkeyChildIdDataGridViewColumn.Name = "uxNullFkeyChildIdDataGridViewColumn";
			this.uxNullFkeyChildIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxNullFkeyChildIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxNullFkeyChildIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxNullFkeyParentIdDataGridViewColumn
			//
			this.uxNullFkeyParentIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxNullFkeyParentIdDataGridViewColumn.DataPropertyName = "NullFkeyParentId";
			this.uxNullFkeyParentIdDataGridViewColumn.HeaderText = "NullFkeyParentId";
			this.uxNullFkeyParentIdDataGridViewColumn.Name = "uxNullFkeyParentIdDataGridViewColumn";
			this.uxNullFkeyParentIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxNullFkeyParentIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxNullFkeyParentIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxSomeTextDataGridViewColumn
			//
			this.uxSomeTextDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSomeTextDataGridViewColumn.DataPropertyName = "SomeText";
			this.uxSomeTextDataGridViewColumn.HeaderText = "SomeText";
			this.uxSomeTextDataGridViewColumn.Name = "uxSomeTextDataGridViewColumn";
			this.uxSomeTextDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSomeTextDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSomeTextDataGridViewColumn.ReadOnly = false;		
			//
			// uxNullFkeyParentIdDataGridViewColumn
			//				
			this.uxNullFkeyParentIdDataGridViewColumn.DisplayMember = "SomeText";	
			this.uxNullFkeyParentIdDataGridViewColumn.ValueMember = "NullFkeyParentId";	
			this.uxNullFkeyParentIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxNullFkeyParentIdDataGridViewColumn.DataSource = uxNullFkeyParentIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxNullFkeyChildDataGridView);
			this.Name = "NullFkeyChildDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyParentIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyChildErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyChildDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyChildBindingSource)).EndInit();
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
				NullFkeyChildDataGridViewEventArgs args = new NullFkeyChildDataGridViewEventArgs();
				args.NullFkeyChild = _currentNullFkeyChild;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class NullFkeyChildDataGridViewEventArgs : System.EventArgs
		{
			private Entities.NullFkeyChild	_NullFkeyChild;
	
			/// <summary>
			/// the  Entities.NullFkeyChild instance.
			/// </summary>
			public Entities.NullFkeyChild NullFkeyChild
			{
				get { return _NullFkeyChild; }
				set { _NullFkeyChild = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxNullFkeyChildDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnNullFkeyChildDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxNullFkeyChildDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnNullFkeyChildDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxNullFkeyChildDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxNullFkeyChildIdDataGridViewColumn":
						e.Value = NullFkeyChildList[e.RowIndex].NullFkeyChildId;
						break;
					case "uxNullFkeyParentIdDataGridViewColumn":
						e.Value = NullFkeyChildList[e.RowIndex].NullFkeyParentId;
						break;
					case "uxSomeTextDataGridViewColumn":
						e.Value = NullFkeyChildList[e.RowIndex].SomeText;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxNullFkeyChildDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnNullFkeyChildDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxNullFkeyChildDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxNullFkeyChildIdDataGridViewColumn":
						NullFkeyChildList[e.RowIndex].NullFkeyChildId = (System.Int32)e.Value;
						break;
					case "uxNullFkeyParentIdDataGridViewColumn":
						NullFkeyChildList[e.RowIndex].NullFkeyParentId = (System.Int32?)e.Value;
						break;
					case "uxSomeTextDataGridViewColumn":
						NullFkeyChildList[e.RowIndex].SomeText = (System.String)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
