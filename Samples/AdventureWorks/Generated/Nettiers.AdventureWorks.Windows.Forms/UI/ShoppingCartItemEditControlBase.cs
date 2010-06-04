
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.ShoppingCartItem"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ShoppingCartItemEditControlBase : System.Windows.Forms.UserControl
	{
		#region Fields
		
		//private System.Windows.Forms.TableLayoutPanel uxTableLayoutPanel;
		/// <summary>
		/// The ErrorProvider for the Entity;
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxErrorProvider;
		
		/// <summary>
		/// The BindingSource for the entity.
		///</summary>
		protected System.Windows.Forms.BindingSource uxBindingSource;
						
		
		/// <summary>
		/// TextBox for the ShoppingCartItemId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxShoppingCartItemId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShoppingCartItemId property.
		/// </summary>
		protected System.Windows.Forms.Label uxShoppingCartItemIdLabel;
		
		/// <summary>
		/// TextBox for the ShoppingCartId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxShoppingCartId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShoppingCartId property.
		/// </summary>
		protected System.Windows.Forms.Label uxShoppingCartIdLabel;
		
		/// <summary>
		/// TextBox for the Quantity property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxQuantity;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Quantity property.
		/// </summary>
		protected System.Windows.Forms.Label uxQuantityLabel;
		
		/// <summary>
		/// ComboBox for the ProductId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// DataTimePicker for the DateCreated property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxDateCreated;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DateCreated property.
		/// </summary>
		protected System.Windows.Forms.Label uxDateCreatedLabel;
		
		/// <summary>
		/// DataTimePicker for the ModifiedDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxModifiedDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ModifiedDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxModifiedDateLabel;
		#endregion
		
		#region Main entity
		private Entities.ShoppingCartItem _ShoppingCartItem;
		/// <summary>
		/// Gets or sets the <see cref="Entities.ShoppingCartItem"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.ShoppingCartItem"/> instance.</value>
		public Entities.ShoppingCartItem ShoppingCartItem
		{
			get {return this._ShoppingCartItem;}
			set
			{
				this._ShoppingCartItem = value;
				if (value != null) 
				{
					this.uxBindingSource.DataSource = value;
					BindControls();
				}			
				
			}
		}
		#endregion
		
		/// <summary>
		/// Binds the controls.
		/// </summary>
		private void BindControls()
		{
			this.uxShoppingCartItemId.DataBindings.Clear();
			this.uxShoppingCartItemId.DataBindings.Add("Text", this.uxBindingSource, "ShoppingCartItemId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxShoppingCartId.DataBindings.Clear();
			this.uxShoppingCartId.DataBindings.Add("Text", this.uxBindingSource, "ShoppingCartId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxQuantity.DataBindings.Clear();
			this.uxQuantity.DataBindings.Add("Text", this.uxBindingSource, "Quantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDateCreated.DataBindings.Clear();
			this.uxDateCreated.DataBindings.Add("Value", this.uxBindingSource, "DateCreated", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ShoppingCartItemEditControlBase"/> class.
		/// </summary>
		public ShoppingCartItemEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_ShoppingCartItem != null) _ShoppingCartItem.Validate();
		}	
				
		/// <summary>
		/// Initializes the component.
		/// </summary>
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.uxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxBindingSource = new System.Windows.Forms.BindingSource(this.components);
			
			//this.uxTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.uxShoppingCartItemId = new System.Windows.Forms.TextBox();
			uxShoppingCartItemIdLabel = new System.Windows.Forms.Label();
			this.uxShoppingCartId = new System.Windows.Forms.TextBox();
			uxShoppingCartIdLabel = new System.Windows.Forms.Label();
			this.uxQuantity = new System.Windows.Forms.TextBox();
			uxQuantityLabel = new System.Windows.Forms.Label();
			this.uxProductId = new System.Windows.Forms.ComboBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxDateCreated = new System.Windows.Forms.DateTimePicker();
			uxDateCreatedLabel = new System.Windows.Forms.Label();
			this.uxModifiedDate = new System.Windows.Forms.DateTimePicker();
			uxModifiedDateLabel = new System.Windows.Forms.Label();
			
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).BeginInit();
			this.SuspendLayout();
			
			// 
			// uxTableLayoutPanel
			// 
			//this.uxTableLayoutPanel.AutoSize = true;
			//this.uxTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			//this.uxTableLayoutPanel.ColumnCount = 2;
			//this.uxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			//this.uxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
			//this.uxTableLayoutPanel.Location = new System.Drawing.System.Drawing.Point(3, 3);
			//this.uxTableLayoutPanel.Name = "uxTableLayoutPanel";
			//this.uxTableLayoutPanel.RowCount = 2;
			//this.uxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			//this.uxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			//this.uxTableLayoutPanel.Size = new System.Drawing.Size(450, 50);
			//this.uxTableLayoutPanel.TabIndex = 0;
			
			//
			// uxErrorProvider
			//
			this.uxErrorProvider.ContainerControl = this;
			this.uxErrorProvider.DataSource = this.uxBindingSource;
			
			//
			// uxShoppingCartItemIdLabel
			//
			this.uxShoppingCartItemIdLabel.Name = "uxShoppingCartItemIdLabel";
			this.uxShoppingCartItemIdLabel.Text = "Shopping Cart Item Id:";
			this.uxShoppingCartItemIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxShoppingCartItemIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShoppingCartItemIdLabel);			
			//
			// uxShoppingCartItemId
			//
			this.uxShoppingCartItemId.Name = "uxShoppingCartItemId";
            this.uxShoppingCartItemId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxShoppingCartItemId);
			this.uxShoppingCartItemId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxShoppingCartItemId);
			//
			// uxShoppingCartIdLabel
			//
			this.uxShoppingCartIdLabel.Name = "uxShoppingCartIdLabel";
			this.uxShoppingCartIdLabel.Text = "Shopping Cart Id:";
			this.uxShoppingCartIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxShoppingCartIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShoppingCartIdLabel);			
			//
			// uxShoppingCartId
			//
			this.uxShoppingCartId.Name = "uxShoppingCartId";
			this.uxShoppingCartId.Width = 250;
			this.uxShoppingCartId.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxShoppingCartId);
			this.uxShoppingCartId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxShoppingCartId);
			//
			// uxQuantityLabel
			//
			this.uxQuantityLabel.Name = "uxQuantityLabel";
			this.uxQuantityLabel.Text = "Quantity:";
			this.uxQuantityLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxQuantityLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxQuantityLabel);			
			//
			// uxQuantity
			//
			this.uxQuantity.Name = "uxQuantity";
			//this.uxTableLayoutPanel.Controls.Add(this.uxQuantity);
			this.uxQuantity.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxQuantity);
			//
			// uxProductIdLabel
			//
			this.uxProductIdLabel.Name = "uxProductIdLabel";
			this.uxProductIdLabel.Text = "Product Id:";
			this.uxProductIdLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductIdLabel);			
			//
			// uxProductId
			//
			this.uxProductId.Name = "uxProductId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductId);
			this.uxProductId.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxProductId);
			//
			// uxDateCreatedLabel
			//
			this.uxDateCreatedLabel.Name = "uxDateCreatedLabel";
			this.uxDateCreatedLabel.Text = "Date Created:";
			this.uxDateCreatedLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxDateCreatedLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDateCreatedLabel);			
			//
			// uxDateCreated
			//
			this.uxDateCreated.Name = "uxDateCreated";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDateCreated);
			this.uxDateCreated.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxDateCreated);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxProductId
			//				
			this.uxProductId.DisplayMember = "Name";	
			this.uxProductId.ValueMember = "ProductId";	
			// 
			// ShoppingCartItemEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ShoppingCartItemEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Product> _ProductIdList;
		
		/// <summary>
		/// The ComboBox associated with the ProductId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Product> ProductIdList
		{
			get {return _ProductIdList;}
			set 
			{
				this._ProductIdList = value;
				this.uxProductId.DataSource = null;
				this.uxProductId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInProductIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ProductId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductIdList
		{
			get { return _allowNewItemInProductIdList;}
			set
			{
				this._allowNewItemInProductIdList = value;
				this.uxProductId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxShoppingCartItemId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShoppingCartItemIdVisible
        {
            get { return this.uxShoppingCartItemId.Visible; }
            set
            {
                this.uxShoppingCartItemIdLabel.Visible = value;
                this.uxShoppingCartItemId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShoppingCartItemId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShoppingCartItemIdEnabled
        {
            get { return this.uxShoppingCartItemId.Enabled; }
            set
            {
                this.uxShoppingCartItemId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxShoppingCartId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShoppingCartIdVisible
        {
            get { return this.uxShoppingCartId.Visible; }
            set
            {
                this.uxShoppingCartIdLabel.Visible = value;
                this.uxShoppingCartId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShoppingCartId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShoppingCartIdEnabled
        {
            get { return this.uxShoppingCartId.Enabled; }
            set
            {
                this.uxShoppingCartId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxQuantity property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxQuantityVisible
        {
            get { return this.uxQuantity.Visible; }
            set
            {
                this.uxQuantityLabel.Visible = value;
                this.uxQuantity.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxQuantity property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxQuantityEnabled
        {
            get { return this.uxQuantity.Enabled; }
            set
            {
                this.uxQuantity.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductIdVisible
        {
            get { return this.uxProductId.Visible; }
            set
            {
                this.uxProductIdLabel.Visible = value;
                this.uxProductId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductIdEnabled
        {
            get { return this.uxProductId.Enabled; }
            set
            {
                this.uxProductId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDateCreated property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDateCreatedVisible
        {
            get { return this.uxDateCreated.Visible; }
            set
            {
                this.uxDateCreatedLabel.Visible = value;
                this.uxDateCreated.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDateCreated property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDateCreatedEnabled
        {
            get { return this.uxDateCreated.Enabled; }
            set
            {
                this.uxDateCreated.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxModifiedDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxModifiedDateVisible
        {
            get { return this.uxModifiedDate.Visible; }
            set
            {
                this.uxModifiedDateLabel.Visible = value;
                this.uxModifiedDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxModifiedDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxModifiedDateEnabled
        {
            get { return this.uxModifiedDate.Enabled; }
            set
            {
                this.uxModifiedDate.Enabled = value;
            }
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
	}
}
