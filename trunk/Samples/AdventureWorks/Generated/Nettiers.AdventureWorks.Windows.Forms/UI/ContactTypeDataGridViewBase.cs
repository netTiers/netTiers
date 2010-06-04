
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ContactType typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ContactTypeDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ContactTypeDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ContactType _currentContactType = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxContactTypeDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxContactTypeErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxContactTypeBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ContactTypeId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxContactTypeIdDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.ContactType> _ContactTypeList;
				
		/// <summary> 
		/// The list of ContactType to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ContactType> ContactTypeList
		{
			get {return this._ContactTypeList;}
			set
			{
				this._ContactTypeList = value;
				this.uxContactTypeBindingSource.DataSource = null;
				this.uxContactTypeBindingSource.DataSource = value;
				this.uxContactTypeDataGridView.DataSource = null;
				this.uxContactTypeDataGridView.DataSource = this.uxContactTypeBindingSource;				
				//this.uxContactTypeBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxContactTypeBindingSource_ListChanged);
				this.uxContactTypeBindingSource.CurrentItemChanged += new System.EventHandler(OnContactTypeBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnContactTypeBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentContactType = uxContactTypeBindingSource.Current as Entities.ContactType;
			
			if (_currentContactType != null)
			{
				_currentContactType.Validate();
			}
			//_ContactType.Validate();
			OnCurrentEntityChanged();
		}

		//void uxContactTypeBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ContactType"/> instance.
		/// </summary>
		public Entities.ContactType SelectedContactType
		{
			get {return this._currentContactType;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxContactTypeDataGridView.VirtualMode;}
			set
			{
				this.uxContactTypeDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxContactTypeDataGridView.AllowUserToAddRows;}
			set {this.uxContactTypeDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxContactTypeDataGridView.AllowUserToDeleteRows;}
			set {this.uxContactTypeDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxContactTypeDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxContactTypeDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ContactTypeDataGridViewBase"/> class.
		/// </summary>
		public ContactTypeDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxContactTypeDataGridView = new System.Windows.Forms.DataGridView();
			this.uxContactTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxContactTypeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxContactTypeIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxContactTypeDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactTypeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactTypeErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxContactTypeErrorProvider
			// 
			this.uxContactTypeErrorProvider.ContainerControl = this;
			this.uxContactTypeErrorProvider.DataSource = this.uxContactTypeBindingSource;						
			// 
			// uxContactTypeDataGridView
			// 
			this.uxContactTypeDataGridView.AutoGenerateColumns = false;
			this.uxContactTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxContactTypeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxContactTypeIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxContactTypeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxContactTypeDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxContactTypeDataGridView.Name = "uxContactTypeDataGridView";
			this.uxContactTypeDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxContactTypeDataGridView.TabIndex = 0;	
			this.uxContactTypeDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxContactTypeDataGridView.EnableHeadersVisualStyles = false;
			this.uxContactTypeDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnContactTypeDataGridViewDataError);
			this.uxContactTypeDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnContactTypeDataGridViewCellValueNeeded);
			this.uxContactTypeDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnContactTypeDataGridViewCellValuePushed);
			
			//
			// uxContactTypeIdDataGridViewColumn
			//
			this.uxContactTypeIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxContactTypeIdDataGridViewColumn.DataPropertyName = "ContactTypeId";
			this.uxContactTypeIdDataGridViewColumn.HeaderText = "ContactTypeId";
			this.uxContactTypeIdDataGridViewColumn.Name = "uxContactTypeIdDataGridViewColumn";
			this.uxContactTypeIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxContactTypeIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxContactTypeIdDataGridViewColumn.ReadOnly = true;		
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
			this.Controls.Add(this.uxContactTypeDataGridView);
			this.Name = "ContactTypeDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxContactTypeErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactTypeDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactTypeBindingSource)).EndInit();
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
				ContactTypeDataGridViewEventArgs args = new ContactTypeDataGridViewEventArgs();
				args.ContactType = _currentContactType;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ContactTypeDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ContactType	_ContactType;
	
			/// <summary>
			/// the  Entities.ContactType instance.
			/// </summary>
			public Entities.ContactType ContactType
			{
				get { return _ContactType; }
				set { _ContactType = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxContactTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnContactTypeDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxContactTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnContactTypeDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxContactTypeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxContactTypeIdDataGridViewColumn":
						e.Value = ContactTypeList[e.RowIndex].ContactTypeId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = ContactTypeList[e.RowIndex].Name;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ContactTypeList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxContactTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnContactTypeDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxContactTypeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxContactTypeIdDataGridViewColumn":
						ContactTypeList[e.RowIndex].ContactTypeId = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						ContactTypeList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ContactTypeList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
