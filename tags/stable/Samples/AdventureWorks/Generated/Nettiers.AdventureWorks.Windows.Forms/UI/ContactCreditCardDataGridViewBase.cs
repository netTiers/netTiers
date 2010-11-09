
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract ContactCreditCard typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ContactCreditCardDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ContactCreditCardDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.ContactCreditCard _currentContactCreditCard = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxContactCreditCardDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxContactCreditCardErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxContactCreditCardBindingSource;
		
		/// <summary> 
		/// the DGV column associated with the ContactId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxContactIdDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the CreditCardId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxCreditCardIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ModifiedDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxModifiedDateDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private Entities.TList<Entities.Contact> _ContactIdList;
		
		/// <summary> 
		/// The list of selectable Contact
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.Contact> ContactIdList
		{
			get {return this._ContactIdList;}
			set 
			{
				this._ContactIdList = value;
				this.uxContactIdDataGridViewColumn.DataSource = null;
				this.uxContactIdDataGridViewColumn.DataSource = this._ContactIdList;
			}
		}
		
		private bool _allowNewItemInContactIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Contact
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInContactIdList
		{
			get { return _allowNewItemInContactIdList;}
			set
			{
				this._allowNewItemInContactIdList = value;
				this.uxContactIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private Entities.TList<Entities.CreditCard> _CreditCardIdList;
		
		/// <summary> 
		/// The list of selectable CreditCard
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public Entities.TList<Entities.CreditCard> CreditCardIdList
		{
			get {return this._CreditCardIdList;}
			set 
			{
				this._CreditCardIdList = value;
				this.uxCreditCardIdDataGridViewColumn.DataSource = null;
				this.uxCreditCardIdDataGridViewColumn.DataSource = this._CreditCardIdList;
			}
		}
		
		private bool _allowNewItemInCreditCardIdList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of CreditCard
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInCreditCardIdList
		{
			get { return _allowNewItemInCreditCardIdList;}
			set
			{
				this._allowNewItemInCreditCardIdList = value;
				this.uxCreditCardIdDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private Entities.TList<Entities.ContactCreditCard> _ContactCreditCardList;
				
		/// <summary> 
		/// The list of ContactCreditCard to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.ContactCreditCard> ContactCreditCardList
		{
			get {return this._ContactCreditCardList;}
			set
			{
				this._ContactCreditCardList = value;
				this.uxContactCreditCardBindingSource.DataSource = null;
				this.uxContactCreditCardBindingSource.DataSource = value;
				this.uxContactCreditCardDataGridView.DataSource = null;
				this.uxContactCreditCardDataGridView.DataSource = this.uxContactCreditCardBindingSource;				
				//this.uxContactCreditCardBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxContactCreditCardBindingSource_ListChanged);
				this.uxContactCreditCardBindingSource.CurrentItemChanged += new System.EventHandler(OnContactCreditCardBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnContactCreditCardBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentContactCreditCard = uxContactCreditCardBindingSource.Current as Entities.ContactCreditCard;
			
			if (_currentContactCreditCard != null)
			{
				_currentContactCreditCard.Validate();
			}
			//_ContactCreditCard.Validate();
			OnCurrentEntityChanged();
		}

		//void uxContactCreditCardBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.ContactCreditCard"/> instance.
		/// </summary>
		public Entities.ContactCreditCard SelectedContactCreditCard
		{
			get {return this._currentContactCreditCard;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxContactCreditCardDataGridView.VirtualMode;}
			set
			{
				this.uxContactCreditCardDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxContactCreditCardDataGridView.AllowUserToAddRows;}
			set {this.uxContactCreditCardDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxContactCreditCardDataGridView.AllowUserToDeleteRows;}
			set {this.uxContactCreditCardDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxContactCreditCardDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxContactCreditCardDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ContactCreditCardDataGridViewBase"/> class.
		/// </summary>
		public ContactCreditCardDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxContactCreditCardDataGridView = new System.Windows.Forms.DataGridView();
			this.uxContactCreditCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxContactCreditCardErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxContactIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxCreditCardIdDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxContactIdBindingSource = new ContactBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).BeginInit();
			//this.uxCreditCardIdBindingSource = new CreditCardBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxCreditCardIdBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactCreditCardDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactCreditCardBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactCreditCardErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxContactCreditCardErrorProvider
			// 
			this.uxContactCreditCardErrorProvider.ContainerControl = this;
			this.uxContactCreditCardErrorProvider.DataSource = this.uxContactCreditCardBindingSource;						
			// 
			// uxContactCreditCardDataGridView
			// 
			this.uxContactCreditCardDataGridView.AutoGenerateColumns = false;
			this.uxContactCreditCardDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxContactCreditCardDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxContactIdDataGridViewColumn,
		this.uxCreditCardIdDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxContactCreditCardDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxContactCreditCardDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxContactCreditCardDataGridView.Name = "uxContactCreditCardDataGridView";
			this.uxContactCreditCardDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxContactCreditCardDataGridView.TabIndex = 0;	
			this.uxContactCreditCardDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxContactCreditCardDataGridView.EnableHeadersVisualStyles = false;
			this.uxContactCreditCardDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnContactCreditCardDataGridViewDataError);
			this.uxContactCreditCardDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnContactCreditCardDataGridViewCellValueNeeded);
			this.uxContactCreditCardDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnContactCreditCardDataGridViewCellValuePushed);
			
			//
			// uxContactIdDataGridViewColumn
			//
			this.uxContactIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxContactIdDataGridViewColumn.DataPropertyName = "ContactId";
			this.uxContactIdDataGridViewColumn.HeaderText = "ContactId";
			this.uxContactIdDataGridViewColumn.Name = "uxContactIdDataGridViewColumn";
			this.uxContactIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxContactIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxContactIdDataGridViewColumn.ReadOnly = false;		
			//
			// uxCreditCardIdDataGridViewColumn
			//
			this.uxCreditCardIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCreditCardIdDataGridViewColumn.DataPropertyName = "CreditCardId";
			this.uxCreditCardIdDataGridViewColumn.HeaderText = "CreditCardId";
			this.uxCreditCardIdDataGridViewColumn.Name = "uxCreditCardIdDataGridViewColumn";
			this.uxCreditCardIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCreditCardIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCreditCardIdDataGridViewColumn.ReadOnly = false;		
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
			// uxContactIdDataGridViewColumn
			//				
			this.uxContactIdDataGridViewColumn.DisplayMember = "NameStyle";	
			this.uxContactIdDataGridViewColumn.ValueMember = "ContactId";	
			this.uxContactIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxContactIdDataGridViewColumn.DataSource = uxContactIdBindingSource;				
				
			//
			// uxCreditCardIdDataGridViewColumn
			//				
			this.uxCreditCardIdDataGridViewColumn.DisplayMember = "CardType";	
			this.uxCreditCardIdDataGridViewColumn.ValueMember = "CreditCardId";	
			this.uxCreditCardIdDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxCreditCardIdDataGridViewColumn.DataSource = uxCreditCardIdBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxContactCreditCardDataGridView);
			this.Name = "ContactCreditCardDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxContactIdBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxCreditCardIdBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactCreditCardErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactCreditCardDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactCreditCardBindingSource)).EndInit();
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
				ContactCreditCardDataGridViewEventArgs args = new ContactCreditCardDataGridViewEventArgs();
				args.ContactCreditCard = _currentContactCreditCard;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ContactCreditCardDataGridViewEventArgs : System.EventArgs
		{
			private Entities.ContactCreditCard	_ContactCreditCard;
	
			/// <summary>
			/// the  Entities.ContactCreditCard instance.
			/// </summary>
			public Entities.ContactCreditCard ContactCreditCard
			{
				get { return _ContactCreditCard; }
				set { _ContactCreditCard = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxContactCreditCardDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnContactCreditCardDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxContactCreditCardDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnContactCreditCardDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxContactCreditCardDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxContactIdDataGridViewColumn":
						e.Value = ContactCreditCardList[e.RowIndex].ContactId;
						break;
					case "uxCreditCardIdDataGridViewColumn":
						e.Value = ContactCreditCardList[e.RowIndex].CreditCardId;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ContactCreditCardList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxContactCreditCardDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnContactCreditCardDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxContactCreditCardDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxContactIdDataGridViewColumn":
						ContactCreditCardList[e.RowIndex].ContactId = (System.Int32)e.Value;
						break;
					case "uxCreditCardIdDataGridViewColumn":
						ContactCreditCardList[e.RowIndex].CreditCardId = (System.Int32)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ContactCreditCardList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
