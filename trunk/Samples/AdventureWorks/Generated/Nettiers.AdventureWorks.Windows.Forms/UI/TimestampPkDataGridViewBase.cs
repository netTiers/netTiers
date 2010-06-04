
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract TimestampPk typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TimestampPkDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<TimestampPkDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.TimestampPk _currentTimestampPk = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxTimestampPkDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxTimestampPkErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxTimestampPkBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the TimestampPk property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTimestampPkDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the SomeText property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSomeTextDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.TimestampPk> _TimestampPkList;
				
		/// <summary> 
		/// The list of TimestampPk to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.TimestampPk> TimestampPkList
		{
			get {return this._TimestampPkList;}
			set
			{
				this._TimestampPkList = value;
				this.uxTimestampPkBindingSource.DataSource = null;
				this.uxTimestampPkBindingSource.DataSource = value;
				this.uxTimestampPkDataGridView.DataSource = null;
				this.uxTimestampPkDataGridView.DataSource = this.uxTimestampPkBindingSource;				
				//this.uxTimestampPkBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxTimestampPkBindingSource_ListChanged);
				this.uxTimestampPkBindingSource.CurrentItemChanged += new System.EventHandler(OnTimestampPkBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnTimestampPkBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentTimestampPk = uxTimestampPkBindingSource.Current as Entities.TimestampPk;
			
			if (_currentTimestampPk != null)
			{
				_currentTimestampPk.Validate();
			}
			//_TimestampPk.Validate();
			OnCurrentEntityChanged();
		}

		//void uxTimestampPkBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.TimestampPk"/> instance.
		/// </summary>
		public Entities.TimestampPk SelectedTimestampPk
		{
			get {return this._currentTimestampPk;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxTimestampPkDataGridView.VirtualMode;}
			set
			{
				this.uxTimestampPkDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxTimestampPkDataGridView.AllowUserToAddRows;}
			set {this.uxTimestampPkDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxTimestampPkDataGridView.AllowUserToDeleteRows;}
			set {this.uxTimestampPkDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxTimestampPkDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxTimestampPkDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="TimestampPkDataGridViewBase"/> class.
		/// </summary>
		public TimestampPkDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxTimestampPkDataGridView = new System.Windows.Forms.DataGridView();
			this.uxTimestampPkBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxTimestampPkErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxTimestampPkDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSomeTextDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxTimestampPkDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTimestampPkBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTimestampPkErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxTimestampPkErrorProvider
			// 
			this.uxTimestampPkErrorProvider.ContainerControl = this;
			this.uxTimestampPkErrorProvider.DataSource = this.uxTimestampPkBindingSource;						
			// 
			// uxTimestampPkDataGridView
			// 
			this.uxTimestampPkDataGridView.AutoGenerateColumns = false;
			this.uxTimestampPkDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxTimestampPkDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxTimestampPkDataGridViewColumn,
		this.uxSomeTextDataGridViewColumn			});
			this.uxTimestampPkDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxTimestampPkDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxTimestampPkDataGridView.Name = "uxTimestampPkDataGridView";
			this.uxTimestampPkDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxTimestampPkDataGridView.TabIndex = 0;	
			this.uxTimestampPkDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxTimestampPkDataGridView.EnableHeadersVisualStyles = false;
			this.uxTimestampPkDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnTimestampPkDataGridViewDataError);
			this.uxTimestampPkDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTimestampPkDataGridViewCellValueNeeded);
			this.uxTimestampPkDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnTimestampPkDataGridViewCellValuePushed);
			
			//
			// uxTimestampPkDataGridViewColumn
			//
			this.uxTimestampPkDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTimestampPkDataGridViewColumn.DataPropertyName = "TimestampPk";
			this.uxTimestampPkDataGridViewColumn.HeaderText = "TimestampPk";
			this.uxTimestampPkDataGridViewColumn.Name = "uxTimestampPkDataGridViewColumn";
			this.uxTimestampPkDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTimestampPkDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTimestampPkDataGridViewColumn.ReadOnly = true;		
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
			this.Controls.Add(this.uxTimestampPkDataGridView);
			this.Name = "TimestampPkDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxTimestampPkErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTimestampPkDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxTimestampPkBindingSource)).EndInit();
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
				TimestampPkDataGridViewEventArgs args = new TimestampPkDataGridViewEventArgs();
				args.TimestampPk = _currentTimestampPk;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class TimestampPkDataGridViewEventArgs : System.EventArgs
		{
			private Entities.TimestampPk	_TimestampPk;
	
			/// <summary>
			/// the  Entities.TimestampPk instance.
			/// </summary>
			public Entities.TimestampPk TimestampPk
			{
				get { return _TimestampPk; }
				set { _TimestampPk = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxTimestampPkDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnTimestampPkDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxTimestampPkDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTimestampPkDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTimestampPkDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTimestampPkDataGridViewColumn":
						e.Value = TimestampPkList[e.RowIndex].TimestampPk;
						break;
					case "uxSomeTextDataGridViewColumn":
						e.Value = TimestampPkList[e.RowIndex].SomeText;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxTimestampPkDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnTimestampPkDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxTimestampPkDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxTimestampPkDataGridViewColumn":
						TimestampPkList[e.RowIndex].TimestampPk = (System.Byte[])e.Value;
						break;
					case "uxSomeTextDataGridViewColumn":
						TimestampPkList[e.RowIndex].SomeText = (System.String)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
