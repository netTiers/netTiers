
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.NullFkeyParent"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class NullFkeyParentEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the NullFkeyParentId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxNullFkeyParentId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the NullFkeyParentId property.
		/// </summary>
		protected System.Windows.Forms.Label uxNullFkeyParentIdLabel;
		
		/// <summary>
		/// TextBox for the SomeText property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSomeText;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SomeText property.
		/// </summary>
		protected System.Windows.Forms.Label uxSomeTextLabel;
		#endregion
		
		#region Main entity
		private Entities.NullFkeyParent _NullFkeyParent;
		/// <summary>
		/// Gets or sets the <see cref="Entities.NullFkeyParent"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.NullFkeyParent"/> instance.</value>
		public Entities.NullFkeyParent NullFkeyParent
		{
			get {return this._NullFkeyParent;}
			set
			{
				this._NullFkeyParent = value;
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
			this.uxNullFkeyParentId.DataBindings.Clear();
			this.uxNullFkeyParentId.DataBindings.Add("Text", this.uxBindingSource, "NullFkeyParentId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSomeText.DataBindings.Clear();
			this.uxSomeText.DataBindings.Add("Text", this.uxBindingSource, "SomeText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="NullFkeyParentEditControlBase"/> class.
		/// </summary>
		public NullFkeyParentEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_NullFkeyParent != null) _NullFkeyParent.Validate();
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
			this.uxNullFkeyParentId = new System.Windows.Forms.TextBox();
			uxNullFkeyParentIdLabel = new System.Windows.Forms.Label();
			this.uxSomeText = new System.Windows.Forms.TextBox();
			uxSomeTextLabel = new System.Windows.Forms.Label();
			
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
			// uxNullFkeyParentIdLabel
			//
			this.uxNullFkeyParentIdLabel.Name = "uxNullFkeyParentIdLabel";
			this.uxNullFkeyParentIdLabel.Text = "Null Fkey Parent Id:";
			this.uxNullFkeyParentIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxNullFkeyParentIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNullFkeyParentIdLabel);			
			//
			// uxNullFkeyParentId
			//
			this.uxNullFkeyParentId.Name = "uxNullFkeyParentId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxNullFkeyParentId);
			this.uxNullFkeyParentId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxNullFkeyParentId);
			//
			// uxSomeTextLabel
			//
			this.uxSomeTextLabel.Name = "uxSomeTextLabel";
			this.uxSomeTextLabel.Text = "Some Text:";
			this.uxSomeTextLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxSomeTextLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSomeTextLabel);			
			//
			// uxSomeText
			//
			this.uxSomeText.Name = "uxSomeText";
			this.uxSomeText.Width = 250;
			this.uxSomeText.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSomeText);
			this.uxSomeText.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxSomeText);
			// 
			// NullFkeyParentEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "NullFkeyParentEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxNullFkeyParentId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNullFkeyParentIdVisible
        {
            get { return this.uxNullFkeyParentId.Visible; }
            set
            {
                this.uxNullFkeyParentIdLabel.Visible = value;
                this.uxNullFkeyParentId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxNullFkeyParentId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNullFkeyParentIdEnabled
        {
            get { return this.uxNullFkeyParentId.Enabled; }
            set
            {
                this.uxNullFkeyParentId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSomeText property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSomeTextVisible
        {
            get { return this.uxSomeText.Visible; }
            set
            {
                this.uxSomeTextLabel.Visible = value;
                this.uxSomeText.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSomeText property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSomeTextEnabled
        {
            get { return this.uxSomeText.Enabled; }
            set
            {
                this.uxSomeText.Enabled = value;
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
