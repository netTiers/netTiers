
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Document typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class DocumentDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<DocumentDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Document _currentDocument = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxDocumentDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxDocumentErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxDocumentBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the DocumentId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDocumentIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Title property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTitleDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the FileName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFileNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the FileExtension property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFileExtensionDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Revision property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxRevisionDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ChangeNumber property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxChangeNumberDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Status property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxStatusDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DocumentSummary property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDocumentSummaryDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Document property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDocumentDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.Document> _DocumentList;
				
		/// <summary> 
		/// The list of Document to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Document> DocumentList
		{
			get {return this._DocumentList;}
			set
			{
				this._DocumentList = value;
				this.uxDocumentBindingSource.DataSource = null;
				this.uxDocumentBindingSource.DataSource = value;
				this.uxDocumentDataGridView.DataSource = null;
				this.uxDocumentDataGridView.DataSource = this.uxDocumentBindingSource;				
				//this.uxDocumentBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxDocumentBindingSource_ListChanged);
				this.uxDocumentBindingSource.CurrentItemChanged += new System.EventHandler(OnDocumentBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnDocumentBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentDocument = uxDocumentBindingSource.Current as Entities.Document;
			
			if (_currentDocument != null)
			{
				_currentDocument.Validate();
			}
			//_Document.Validate();
			OnCurrentEntityChanged();
		}

		//void uxDocumentBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Document"/> instance.
		/// </summary>
		public Entities.Document SelectedDocument
		{
			get {return this._currentDocument;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxDocumentDataGridView.VirtualMode;}
			set
			{
				this.uxDocumentDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxDocumentDataGridView.AllowUserToAddRows;}
			set {this.uxDocumentDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxDocumentDataGridView.AllowUserToDeleteRows;}
			set {this.uxDocumentDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxDocumentDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxDocumentDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="DocumentDataGridViewBase"/> class.
		/// </summary>
		public DocumentDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxDocumentDataGridView = new System.Windows.Forms.DataGridView();
			this.uxDocumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxDocumentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxDocumentIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTitleDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFileNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFileExtensionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRevisionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxChangeNumberDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxStatusDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDocumentSummaryDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDocumentDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxDocumentDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDocumentBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDocumentErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxDocumentErrorProvider
			// 
			this.uxDocumentErrorProvider.ContainerControl = this;
			this.uxDocumentErrorProvider.DataSource = this.uxDocumentBindingSource;						
			// 
			// uxDocumentDataGridView
			// 
			this.uxDocumentDataGridView.AutoGenerateColumns = false;
			this.uxDocumentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxDocumentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxDocumentIdDataGridViewColumn,
		this.uxTitleDataGridViewColumn,
		this.uxFileNameDataGridViewColumn,
		this.uxFileExtensionDataGridViewColumn,
		this.uxRevisionDataGridViewColumn,
		this.uxChangeNumberDataGridViewColumn,
		this.uxStatusDataGridViewColumn,
		this.uxDocumentSummaryDataGridViewColumn,
		this.uxDocumentDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxDocumentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxDocumentDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxDocumentDataGridView.Name = "uxDocumentDataGridView";
			this.uxDocumentDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxDocumentDataGridView.TabIndex = 0;	
			this.uxDocumentDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxDocumentDataGridView.EnableHeadersVisualStyles = false;
			this.uxDocumentDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDocumentDataGridViewDataError);
			this.uxDocumentDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnDocumentDataGridViewCellValueNeeded);
			this.uxDocumentDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnDocumentDataGridViewCellValuePushed);
			
			//
			// uxDocumentIdDataGridViewColumn
			//
			this.uxDocumentIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDocumentIdDataGridViewColumn.DataPropertyName = "DocumentId";
			this.uxDocumentIdDataGridViewColumn.HeaderText = "DocumentId";
			this.uxDocumentIdDataGridViewColumn.Name = "uxDocumentIdDataGridViewColumn";
			this.uxDocumentIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDocumentIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDocumentIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxTitleDataGridViewColumn
			//
			this.uxTitleDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTitleDataGridViewColumn.DataPropertyName = "Title";
			this.uxTitleDataGridViewColumn.HeaderText = "Title";
			this.uxTitleDataGridViewColumn.Name = "uxTitleDataGridViewColumn";
			this.uxTitleDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTitleDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTitleDataGridViewColumn.ReadOnly = false;		
			//
			// uxFileNameDataGridViewColumn
			//
			this.uxFileNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFileNameDataGridViewColumn.DataPropertyName = "FileName";
			this.uxFileNameDataGridViewColumn.HeaderText = "FileName";
			this.uxFileNameDataGridViewColumn.Name = "uxFileNameDataGridViewColumn";
			this.uxFileNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFileNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFileNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxFileExtensionDataGridViewColumn
			//
			this.uxFileExtensionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFileExtensionDataGridViewColumn.DataPropertyName = "FileExtension";
			this.uxFileExtensionDataGridViewColumn.HeaderText = "FileExtension";
			this.uxFileExtensionDataGridViewColumn.Name = "uxFileExtensionDataGridViewColumn";
			this.uxFileExtensionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFileExtensionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFileExtensionDataGridViewColumn.ReadOnly = false;		
			//
			// uxRevisionDataGridViewColumn
			//
			this.uxRevisionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxRevisionDataGridViewColumn.DataPropertyName = "Revision";
			this.uxRevisionDataGridViewColumn.HeaderText = "Revision";
			this.uxRevisionDataGridViewColumn.Name = "uxRevisionDataGridViewColumn";
			this.uxRevisionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxRevisionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxRevisionDataGridViewColumn.ReadOnly = false;		
			//
			// uxChangeNumberDataGridViewColumn
			//
			this.uxChangeNumberDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxChangeNumberDataGridViewColumn.DataPropertyName = "ChangeNumber";
			this.uxChangeNumberDataGridViewColumn.HeaderText = "ChangeNumber";
			this.uxChangeNumberDataGridViewColumn.Name = "uxChangeNumberDataGridViewColumn";
			this.uxChangeNumberDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxChangeNumberDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxChangeNumberDataGridViewColumn.ReadOnly = false;		
			//
			// uxStatusDataGridViewColumn
			//
			this.uxStatusDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxStatusDataGridViewColumn.DataPropertyName = "Status";
			this.uxStatusDataGridViewColumn.HeaderText = "Status";
			this.uxStatusDataGridViewColumn.Name = "uxStatusDataGridViewColumn";
			this.uxStatusDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxStatusDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxStatusDataGridViewColumn.ReadOnly = false;		
			//
			// uxDocumentSummaryDataGridViewColumn
			//
			this.uxDocumentSummaryDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDocumentSummaryDataGridViewColumn.DataPropertyName = "DocumentSummary";
			this.uxDocumentSummaryDataGridViewColumn.HeaderText = "DocumentSummary";
			this.uxDocumentSummaryDataGridViewColumn.Name = "uxDocumentSummaryDataGridViewColumn";
			this.uxDocumentSummaryDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDocumentSummaryDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDocumentSummaryDataGridViewColumn.ReadOnly = false;		
			//
			// uxDocumentDataGridViewColumn
			//
			this.uxDocumentDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDocumentDataGridViewColumn.DataPropertyName = "Document";
			this.uxDocumentDataGridViewColumn.HeaderText = "Document";
			this.uxDocumentDataGridViewColumn.Name = "uxDocumentDataGridViewColumn";
			this.uxDocumentDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDocumentDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDocumentDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxDocumentDataGridView);
			this.Name = "DocumentDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxDocumentErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDocumentDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxDocumentBindingSource)).EndInit();
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
				DocumentDataGridViewEventArgs args = new DocumentDataGridViewEventArgs();
				args.Document = _currentDocument;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class DocumentDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Document	_Document;
	
			/// <summary>
			/// the  Entities.Document instance.
			/// </summary>
			public Entities.Document Document
			{
				get { return _Document; }
				set { _Document = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxDocumentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnDocumentDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxDocumentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnDocumentDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxDocumentDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxDocumentIdDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].DocumentId;
						break;
					case "uxTitleDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].Title;
						break;
					case "uxFileNameDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].FileName;
						break;
					case "uxFileExtensionDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].FileExtension;
						break;
					case "uxRevisionDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].Revision;
						break;
					case "uxChangeNumberDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].ChangeNumber;
						break;
					case "uxStatusDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].Status;
						break;
					case "uxDocumentSummaryDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].DocumentSummary;
						break;
					case "uxDocumentDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].Document;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = DocumentList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxDocumentDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnDocumentDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxDocumentDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxDocumentIdDataGridViewColumn":
						DocumentList[e.RowIndex].DocumentId = (System.Int32)e.Value;
						break;
					case "uxTitleDataGridViewColumn":
						DocumentList[e.RowIndex].Title = (System.String)e.Value;
						break;
					case "uxFileNameDataGridViewColumn":
						DocumentList[e.RowIndex].FileName = (System.String)e.Value;
						break;
					case "uxFileExtensionDataGridViewColumn":
						DocumentList[e.RowIndex].FileExtension = (System.String)e.Value;
						break;
					case "uxRevisionDataGridViewColumn":
						DocumentList[e.RowIndex].Revision = (System.String)e.Value;
						break;
					case "uxChangeNumberDataGridViewColumn":
						DocumentList[e.RowIndex].ChangeNumber = (System.Int32)e.Value;
						break;
					case "uxStatusDataGridViewColumn":
						DocumentList[e.RowIndex].Status = (System.Byte)e.Value;
						break;
					case "uxDocumentSummaryDataGridViewColumn":
						DocumentList[e.RowIndex].DocumentSummary = (System.String)e.Value;
						break;
					case "uxDocumentDataGridViewColumn":
						DocumentList[e.RowIndex].Document = (System.Byte[])e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						DocumentList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
