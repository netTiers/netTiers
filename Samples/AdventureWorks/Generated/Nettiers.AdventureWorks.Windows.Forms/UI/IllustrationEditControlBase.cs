
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Illustration"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class IllustrationEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the IllustrationId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxIllustrationId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IllustrationId property.
		/// </summary>
		protected System.Windows.Forms.Label uxIllustrationIdLabel;
		
		/// <summary>
		/// TextBox for the Diagram property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDiagram;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Diagram property.
		/// </summary>
		protected System.Windows.Forms.Label uxDiagramLabel;
		
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
		private Entities.Illustration _Illustration;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Illustration"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Illustration"/> instance.</value>
		public Entities.Illustration Illustration
		{
			get {return this._Illustration;}
			set
			{
				this._Illustration = value;
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
			this.uxIllustrationId.DataBindings.Clear();
			this.uxIllustrationId.DataBindings.Add("Text", this.uxBindingSource, "IllustrationId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDiagram.DataBindings.Clear();
			this.uxDiagram.DataBindings.Add("Text", this.uxBindingSource, "Diagram", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="IllustrationEditControlBase"/> class.
		/// </summary>
		public IllustrationEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Illustration != null) _Illustration.Validate();
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
			this.uxIllustrationId = new System.Windows.Forms.TextBox();
			uxIllustrationIdLabel = new System.Windows.Forms.Label();
			this.uxDiagram = new System.Windows.Forms.TextBox();
			uxDiagramLabel = new System.Windows.Forms.Label();
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
			// uxIllustrationIdLabel
			//
			this.uxIllustrationIdLabel.Name = "uxIllustrationIdLabel";
			this.uxIllustrationIdLabel.Text = "Illustration Id:";
			this.uxIllustrationIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxIllustrationIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIllustrationIdLabel);			
			//
			// uxIllustrationId
			//
			this.uxIllustrationId.Name = "uxIllustrationId";
            this.uxIllustrationId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxIllustrationId);
			this.uxIllustrationId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxIllustrationId);
			//
			// uxDiagramLabel
			//
			this.uxDiagramLabel.Name = "uxDiagramLabel";
			this.uxDiagramLabel.Text = "Diagram:";
			this.uxDiagramLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxDiagramLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDiagramLabel);			
			//
			// uxDiagram
			//
			this.uxDiagram.Name = "uxDiagram";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDiagram);
			this.uxDiagram.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxDiagram);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxModifiedDate);
			// 
			// IllustrationEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "IllustrationEditControlBase";
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
        /// Indicates if the controls associated with the uxIllustrationId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIllustrationIdVisible
        {
            get { return this.uxIllustrationId.Visible; }
            set
            {
                this.uxIllustrationIdLabel.Visible = value;
                this.uxIllustrationId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIllustrationId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIllustrationIdEnabled
        {
            get { return this.uxIllustrationId.Enabled; }
            set
            {
                this.uxIllustrationId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDiagram property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDiagramVisible
        {
            get { return this.uxDiagram.Visible; }
            set
            {
                this.uxDiagramLabel.Visible = value;
                this.uxDiagram.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDiagram property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDiagramEnabled
        {
            get { return this.uxDiagram.Enabled; }
            set
            {
                this.uxDiagram.Enabled = value;
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
