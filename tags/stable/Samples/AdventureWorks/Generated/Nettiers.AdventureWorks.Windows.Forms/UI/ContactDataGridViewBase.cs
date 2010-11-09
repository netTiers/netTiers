
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// abstract Contact typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ContactDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<ContactDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private Entities.Contact _currentContact = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxContactDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxContactErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxContactBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ContactId property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxContactIdDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the NameStyle property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxNameStyleDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Title property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTitleDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the FirstName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFirstNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the MiddleName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxMiddleNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the LastName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLastNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Suffix property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSuffixDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EmailAddress property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEmailAddressDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the EmailPromotion property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEmailPromotionDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Phone property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPhoneDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PasswordHash property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPasswordHashDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the PasswordSalt property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPasswordSaltDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the AdditionalContactInfo property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAdditionalContactInfoDataGridViewColumn;
		
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
		
		private Entities.TList<Entities.Contact> _ContactList;
				
		/// <summary> 
		/// The list of Contact to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public Entities.TList<Entities.Contact> ContactList
		{
			get {return this._ContactList;}
			set
			{
				this._ContactList = value;
				this.uxContactBindingSource.DataSource = null;
				this.uxContactBindingSource.DataSource = value;
				this.uxContactDataGridView.DataSource = null;
				this.uxContactDataGridView.DataSource = this.uxContactBindingSource;				
				//this.uxContactBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxContactBindingSource_ListChanged);
				this.uxContactBindingSource.CurrentItemChanged += new System.EventHandler(OnContactBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnContactBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentContact = uxContactBindingSource.Current as Entities.Contact;
			
			if (_currentContact != null)
			{
				_currentContact.Validate();
			}
			//_Contact.Validate();
			OnCurrentEntityChanged();
		}

		//void uxContactBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="Entities.Contact"/> instance.
		/// </summary>
		public Entities.Contact SelectedContact
		{
			get {return this._currentContact;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxContactDataGridView.VirtualMode;}
			set
			{
				this.uxContactDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxContactDataGridView.AllowUserToAddRows;}
			set {this.uxContactDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxContactDataGridView.AllowUserToDeleteRows;}
			set {this.uxContactDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxContactDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxContactDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="ContactDataGridViewBase"/> class.
		/// </summary>
		public ContactDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxContactDataGridView = new System.Windows.Forms.DataGridView();
			this.uxContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxContactErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxContactIdDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameStyleDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxTitleDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFirstNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMiddleNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLastNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSuffixDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEmailAddressDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEmailPromotionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPhoneDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPasswordHashDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPasswordSaltDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAdditionalContactInfoDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxRowguidDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxModifiedDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxContactDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxContactErrorProvider
			// 
			this.uxContactErrorProvider.ContainerControl = this;
			this.uxContactErrorProvider.DataSource = this.uxContactBindingSource;						
			// 
			// uxContactDataGridView
			// 
			this.uxContactDataGridView.AutoGenerateColumns = false;
			this.uxContactDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxContactDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxContactIdDataGridViewColumn,
		this.uxNameStyleDataGridViewColumn,
		this.uxTitleDataGridViewColumn,
		this.uxFirstNameDataGridViewColumn,
		this.uxMiddleNameDataGridViewColumn,
		this.uxLastNameDataGridViewColumn,
		this.uxSuffixDataGridViewColumn,
		this.uxEmailAddressDataGridViewColumn,
		this.uxEmailPromotionDataGridViewColumn,
		this.uxPhoneDataGridViewColumn,
		this.uxPasswordHashDataGridViewColumn,
		this.uxPasswordSaltDataGridViewColumn,
		this.uxAdditionalContactInfoDataGridViewColumn,
		this.uxRowguidDataGridViewColumn,
		this.uxModifiedDateDataGridViewColumn			});
			this.uxContactDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxContactDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxContactDataGridView.Name = "uxContactDataGridView";
			this.uxContactDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxContactDataGridView.TabIndex = 0;	
			this.uxContactDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxContactDataGridView.EnableHeadersVisualStyles = false;
			this.uxContactDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnContactDataGridViewDataError);
			this.uxContactDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnContactDataGridViewCellValueNeeded);
			this.uxContactDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnContactDataGridViewCellValuePushed);
			
			//
			// uxContactIdDataGridViewColumn
			//
			this.uxContactIdDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxContactIdDataGridViewColumn.DataPropertyName = "ContactId";
			this.uxContactIdDataGridViewColumn.HeaderText = "ContactId";
			this.uxContactIdDataGridViewColumn.Name = "uxContactIdDataGridViewColumn";
			this.uxContactIdDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxContactIdDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxContactIdDataGridViewColumn.ReadOnly = true;		
			//
			// uxNameStyleDataGridViewColumn
			//
			this.uxNameStyleDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxNameStyleDataGridViewColumn.DataPropertyName = "NameStyle";
			this.uxNameStyleDataGridViewColumn.HeaderText = "NameStyle";
			this.uxNameStyleDataGridViewColumn.Name = "uxNameStyleDataGridViewColumn";
			this.uxNameStyleDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxNameStyleDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxNameStyleDataGridViewColumn.ReadOnly = false;		
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
			// uxFirstNameDataGridViewColumn
			//
			this.uxFirstNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFirstNameDataGridViewColumn.DataPropertyName = "FirstName";
			this.uxFirstNameDataGridViewColumn.HeaderText = "FirstName";
			this.uxFirstNameDataGridViewColumn.Name = "uxFirstNameDataGridViewColumn";
			this.uxFirstNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFirstNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFirstNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxMiddleNameDataGridViewColumn
			//
			this.uxMiddleNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMiddleNameDataGridViewColumn.DataPropertyName = "MiddleName";
			this.uxMiddleNameDataGridViewColumn.HeaderText = "MiddleName";
			this.uxMiddleNameDataGridViewColumn.Name = "uxMiddleNameDataGridViewColumn";
			this.uxMiddleNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMiddleNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMiddleNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxLastNameDataGridViewColumn
			//
			this.uxLastNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLastNameDataGridViewColumn.DataPropertyName = "LastName";
			this.uxLastNameDataGridViewColumn.HeaderText = "LastName";
			this.uxLastNameDataGridViewColumn.Name = "uxLastNameDataGridViewColumn";
			this.uxLastNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLastNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLastNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxSuffixDataGridViewColumn
			//
			this.uxSuffixDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSuffixDataGridViewColumn.DataPropertyName = "Suffix";
			this.uxSuffixDataGridViewColumn.HeaderText = "Suffix";
			this.uxSuffixDataGridViewColumn.Name = "uxSuffixDataGridViewColumn";
			this.uxSuffixDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSuffixDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSuffixDataGridViewColumn.ReadOnly = false;		
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
			// uxEmailPromotionDataGridViewColumn
			//
			this.uxEmailPromotionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEmailPromotionDataGridViewColumn.DataPropertyName = "EmailPromotion";
			this.uxEmailPromotionDataGridViewColumn.HeaderText = "EmailPromotion";
			this.uxEmailPromotionDataGridViewColumn.Name = "uxEmailPromotionDataGridViewColumn";
			this.uxEmailPromotionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEmailPromotionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEmailPromotionDataGridViewColumn.ReadOnly = false;		
			//
			// uxPhoneDataGridViewColumn
			//
			this.uxPhoneDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPhoneDataGridViewColumn.DataPropertyName = "Phone";
			this.uxPhoneDataGridViewColumn.HeaderText = "Phone";
			this.uxPhoneDataGridViewColumn.Name = "uxPhoneDataGridViewColumn";
			this.uxPhoneDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPhoneDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPhoneDataGridViewColumn.ReadOnly = false;		
			//
			// uxPasswordHashDataGridViewColumn
			//
			this.uxPasswordHashDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPasswordHashDataGridViewColumn.DataPropertyName = "PasswordHash";
			this.uxPasswordHashDataGridViewColumn.HeaderText = "PasswordHash";
			this.uxPasswordHashDataGridViewColumn.Name = "uxPasswordHashDataGridViewColumn";
			this.uxPasswordHashDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPasswordHashDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPasswordHashDataGridViewColumn.ReadOnly = false;		
			//
			// uxPasswordSaltDataGridViewColumn
			//
			this.uxPasswordSaltDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPasswordSaltDataGridViewColumn.DataPropertyName = "PasswordSalt";
			this.uxPasswordSaltDataGridViewColumn.HeaderText = "PasswordSalt";
			this.uxPasswordSaltDataGridViewColumn.Name = "uxPasswordSaltDataGridViewColumn";
			this.uxPasswordSaltDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPasswordSaltDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPasswordSaltDataGridViewColumn.ReadOnly = false;		
			//
			// uxAdditionalContactInfoDataGridViewColumn
			//
			this.uxAdditionalContactInfoDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAdditionalContactInfoDataGridViewColumn.DataPropertyName = "AdditionalContactInfo";
			this.uxAdditionalContactInfoDataGridViewColumn.HeaderText = "AdditionalContactInfo";
			this.uxAdditionalContactInfoDataGridViewColumn.Name = "uxAdditionalContactInfoDataGridViewColumn";
			this.uxAdditionalContactInfoDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAdditionalContactInfoDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAdditionalContactInfoDataGridViewColumn.ReadOnly = false;		
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
			this.Controls.Add(this.uxContactDataGridView);
			this.Name = "ContactDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxContactErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxContactBindingSource)).EndInit();
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
				ContactDataGridViewEventArgs args = new ContactDataGridViewEventArgs();
				args.Contact = _currentContact;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class ContactDataGridViewEventArgs : System.EventArgs
		{
			private Entities.Contact	_Contact;
	
			/// <summary>
			/// the  Entities.Contact instance.
			/// </summary>
			public Entities.Contact Contact
			{
				get { return _Contact; }
				set { _Contact = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnContactDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnContactDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxContactDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxContactIdDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].ContactId;
						break;
					case "uxNameStyleDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].NameStyle;
						break;
					case "uxTitleDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].Title;
						break;
					case "uxFirstNameDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].FirstName;
						break;
					case "uxMiddleNameDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].MiddleName;
						break;
					case "uxLastNameDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].LastName;
						break;
					case "uxSuffixDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].Suffix;
						break;
					case "uxEmailAddressDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].EmailAddress;
						break;
					case "uxEmailPromotionDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].EmailPromotion;
						break;
					case "uxPhoneDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].Phone;
						break;
					case "uxPasswordHashDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].PasswordHash;
						break;
					case "uxPasswordSaltDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].PasswordSalt;
						break;
					case "uxAdditionalContactInfoDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].AdditionalContactInfo;
						break;
					case "uxRowguidDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].Rowguid;
						break;
					case "uxModifiedDateDataGridViewColumn":
						e.Value = ContactList[e.RowIndex].ModifiedDate;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxContactDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnContactDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxContactDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxContactIdDataGridViewColumn":
						ContactList[e.RowIndex].ContactId = (System.Int32)e.Value;
						break;
					case "uxNameStyleDataGridViewColumn":
						ContactList[e.RowIndex].NameStyle = (System.Boolean)e.Value;
						break;
					case "uxTitleDataGridViewColumn":
						ContactList[e.RowIndex].Title = (System.String)e.Value;
						break;
					case "uxFirstNameDataGridViewColumn":
						ContactList[e.RowIndex].FirstName = (System.String)e.Value;
						break;
					case "uxMiddleNameDataGridViewColumn":
						ContactList[e.RowIndex].MiddleName = (System.String)e.Value;
						break;
					case "uxLastNameDataGridViewColumn":
						ContactList[e.RowIndex].LastName = (System.String)e.Value;
						break;
					case "uxSuffixDataGridViewColumn":
						ContactList[e.RowIndex].Suffix = (System.String)e.Value;
						break;
					case "uxEmailAddressDataGridViewColumn":
						ContactList[e.RowIndex].EmailAddress = (System.String)e.Value;
						break;
					case "uxEmailPromotionDataGridViewColumn":
						ContactList[e.RowIndex].EmailPromotion = (System.Int32)e.Value;
						break;
					case "uxPhoneDataGridViewColumn":
						ContactList[e.RowIndex].Phone = (System.String)e.Value;
						break;
					case "uxPasswordHashDataGridViewColumn":
						ContactList[e.RowIndex].PasswordHash = (System.String)e.Value;
						break;
					case "uxPasswordSaltDataGridViewColumn":
						ContactList[e.RowIndex].PasswordSalt = (System.String)e.Value;
						break;
					case "uxAdditionalContactInfoDataGridViewColumn":
						ContactList[e.RowIndex].AdditionalContactInfo = (string)e.Value;
						break;
					case "uxRowguidDataGridViewColumn":
						ContactList[e.RowIndex].Rowguid = (System.Guid)e.Value;
						break;
					case "uxModifiedDateDataGridViewColumn":
						ContactList[e.RowIndex].ModifiedDate = (System.DateTime)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
