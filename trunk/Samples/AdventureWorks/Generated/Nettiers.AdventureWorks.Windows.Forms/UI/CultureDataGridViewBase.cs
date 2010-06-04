
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Culture typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CultureDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CultureDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Culture _currentCulture = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCultureDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCultureErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCultureBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the CultureId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCultureIdDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.Culture> _CultureList;
				
		/// <summary> 
		/// The list of Culture to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Culture> CultureList
		{
			get {return this._CultureList;}
			set
			{
				this._CultureList = value;
				this.uxCultureBindingSource.DataSource = null;
				this.uxCultureBindingSource.DataSource = value;
				this.uxCultureDataGridView.DataSource = null;
				this.uxCultureDataGridView.DataSource = this.uxCultureBindingSource;				
				//this.uxCultureBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCultureBindingSource_ListChanged);
				this.uxCultureBindingSource.CurrentItemChanged += new System.EventHandler(OnCultureBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCultureBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCulture = uxCultureBindingSource.Current as Entities.Culture;
			
			if (_currentCulture != null)
			{
				_currentCulture.Validate();
			}
			//_Culture.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCultureBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Culture"/> instance.
		/// </summary>
		public Entities.Culture SelectedCulture
		{
			get {return this._currentCulture;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCultureDataGridView.VirtualMode;}
			set
			{
				this.uxCultureDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCultureDataGridView.AllowUserToAddRows;}
			set {this.uxCultureDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCultureDataGridView.AllowUserToDeleteRows;}
			set {this.uxCultureDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCultureDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCultureDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CultureDataGridViewBase"/> class.
		/// </summary>
		public CultureDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCultureDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCultureBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCultureErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxCultureIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxCultureDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCultureBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCultureErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCultureErrorProvider
			// 
			this.uxCultureErrorProvider.ContainerControl = this;
			this.uxCultureErrorProvider.DataSource = this.uxCultureBindingSource;						
			// 
			// uxCultureDataGridView
			// 
			this.uxCultureDataGridView.AutoGenerateColumns = false;
			this.uxCultureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCultureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxCultureIdDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxCultureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCultureDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCultureDataGridView.Name = "uxCultureDataGridView";
			this.uxCultureDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCultureDataGridView.TabIndex = 0;	
			this.uxCultureDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCultureDataGridView.EnableHeadersVisualStyles = false;
			this.uxCultureDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCultureDataGridViewDataError);
			this.uxCultureDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCultureDataGridViewCellValueNeeded);
			this.uxCultureDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCultureDataGridViewCellValuePushed);
			
			//
			// uxCultureIdDataGridViewColumn
			//
			this.uxCultureIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCultureIdDataGridViewColumn.DataPropertyName = "CultureId";
			this.uxCultureIdDataGridViewColumn.HeaderText = "CultureId";
			this.uxCultureIdDataGridViewColumn.Name = "uxCultureIdDataGridViewColumn";
			this.uxCultureIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCultureIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCultureIdDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxCultureDataGridView);
			this.Name = "CultureDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxCultureErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCultureDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCultureBindingSource)).EndInit();
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
				CultureDataGridViewEventArgs args = new CultureDataGridViewEventArgs();
				args.Culture = _currentCulture;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CultureDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Culture	_Culture;
	
			/// <summary>
			/// the  Entities.Culture instance.
			/// </summary>
			public Entities.Culture Culture
			{
				get { return _Culture; }
				set { _Culture = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCultureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCultureDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCultureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCultureDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCultureDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCultureIdDataGridViewColumn":
						e.Value = CultureList[e.RowIndex].CultureId;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = CultureList[e.RowIndex].Name;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = CultureList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCultureDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCultureDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCultureDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxCultureIdDataGridViewColumn":
						CultureList[e.RowIndex].CultureId = (System.String)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						CultureList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						CultureList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
