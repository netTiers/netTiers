
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract NullFkeyParent typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class NullFkeyParentDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<NullFkeyParentDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.NullFkeyParent _currentNullFkeyParent = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxNullFkeyParentDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxNullFkeyParentErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxNullFkeyParentBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the NullFkeyParentId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNullFkeyParentIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SomeText property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSomeTextDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.NullFkeyParent> _NullFkeyParentList;
				
		/// <summary> 
		/// The list of NullFkeyParent to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.NullFkeyParent> NullFkeyParentList
		{
			get {return this._NullFkeyParentList;}
			set
			{
				this._NullFkeyParentList = value;
				this.uxNullFkeyParentBindingSource.DataSource = null;
				this.uxNullFkeyParentBindingSource.DataSource = value;
				this.uxNullFkeyParentDataGridView.DataSource = null;
				this.uxNullFkeyParentDataGridView.DataSource = this.uxNullFkeyParentBindingSource;				
				//this.uxNullFkeyParentBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxNullFkeyParentBindingSource_ListChanged);
				this.uxNullFkeyParentBindingSource.CurrentItemChanged += new System.EventHandler(OnNullFkeyParentBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnNullFkeyParentBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentNullFkeyParent = uxNullFkeyParentBindingSource.Current as Entities.NullFkeyParent;
			
			if (_currentNullFkeyParent != null)
			{
				_currentNullFkeyParent.Validate();
			}
			//_NullFkeyParent.Validate();
			OnCurrentEntityChanged();
		}

		//void uxNullFkeyParentBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.NullFkeyParent"/> instance.
		/// </summary>
		public Entities.NullFkeyParent SelectedNullFkeyParent
		{
			get {return this._currentNullFkeyParent;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxNullFkeyParentDataGridView.VirtualMode;}
			set
			{
				this.uxNullFkeyParentDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxNullFkeyParentDataGridView.AllowUserToAddRows;}
			set {this.uxNullFkeyParentDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxNullFkeyParentDataGridView.AllowUserToDeleteRows;}
			set {this.uxNullFkeyParentDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxNullFkeyParentDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxNullFkeyParentDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="NullFkeyParentDataGridViewBase"/> class.
		/// </summary>
		public NullFkeyParentDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxNullFkeyParentDataGridView = new System.Windows.Forms.DataGridView();
			this.uxNullFkeyParentBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxNullFkeyParentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxNullFkeyParentIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSomeTextDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyParentDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyParentBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyParentErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxNullFkeyParentErrorProvider
			// 
			this.uxNullFkeyParentErrorProvider.ContainerControl = this;
			this.uxNullFkeyParentErrorProvider.DataSource = this.uxNullFkeyParentBindingSource;						
			// 
			// uxNullFkeyParentDataGridView
			// 
			this.uxNullFkeyParentDataGridView.AutoGenerateColumns = false;
			this.uxNullFkeyParentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxNullFkeyParentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxNullFkeyParentIdDataGridViewColumn,
		this.uxSomeTextDataGridViewColumn			});
			this.uxNullFkeyParentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxNullFkeyParentDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxNullFkeyParentDataGridView.Name = "uxNullFkeyParentDataGridView";
			this.uxNullFkeyParentDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxNullFkeyParentDataGridView.TabIndex = 0;	
			this.uxNullFkeyParentDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxNullFkeyParentDataGridView.EnableHeadersVisualStyles = false;
			this.uxNullFkeyParentDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnNullFkeyParentDataGridViewDataError);
			this.uxNullFkeyParentDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnNullFkeyParentDataGridViewCellValueNeeded);
			this.uxNullFkeyParentDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnNullFkeyParentDataGridViewCellValuePushed);
			
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
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxNullFkeyParentDataGridView);
			this.Name = "NullFkeyParentDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyParentErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyParentDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxNullFkeyParentBindingSource)).EndInit();
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
				NullFkeyParentDataGridViewEventArgs args = new NullFkeyParentDataGridViewEventArgs();
				args.NullFkeyParent = _currentNullFkeyParent;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class NullFkeyParentDataGridViewEventArgs : System.EventArgs
		{
			private Entities.NullFkeyParent	_NullFkeyParent;
	
			/// <summary>
			/// the  Entities.NullFkeyParent instance.
			/// </summary>
			public Entities.NullFkeyParent NullFkeyParent
			{
				get { return _NullFkeyParent; }
				set { _NullFkeyParent = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxNullFkeyParentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnNullFkeyParentDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxNullFkeyParentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnNullFkeyParentDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxNullFkeyParentDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxNullFkeyParentIdDataGridViewColumn":
						e.Value = NullFkeyParentList[e.RowIndex].NullFkeyParentId;
						break;
					case "uxSomeTextDataGridViewColumn":
						e.Value = NullFkeyParentList[e.RowIndex].SomeText;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxNullFkeyParentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnNullFkeyParentDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxNullFkeyParentDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxNullFkeyParentIdDataGridViewColumn":
						NullFkeyParentList[e.RowIndex].NullFkeyParentId = (System.Int32)e.Value;
						break;
					case "uxSomeTextDataGridViewColumn":
						NullFkeyParentList[e.RowIndex].SomeText = (System.String)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
