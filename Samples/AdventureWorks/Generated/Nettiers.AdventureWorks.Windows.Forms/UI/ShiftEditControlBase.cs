
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Shift"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ShiftEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the ShiftId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxShiftId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ShiftId property.
		/// </summary>
		protected System.Windows.Forms.Label uxShiftIdLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// DataTimePicker for the StartTime property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxStartTime;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StartTime property.
		/// </summary>
		protected System.Windows.Forms.Label uxStartTimeLabel;
		
		/// <summary>
		/// DataTimePicker for the EndTime property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxEndTime;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EndTime property.
		/// </summary>
		protected System.Windows.Forms.Label uxEndTimeLabel;
		
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
		private Entities.Shift _Shift;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Shift"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Shift"/> instance.</value>
		public Entities.Shift Shift
		{
			get {return this._Shift;}
			set
			{
				this._Shift = value;
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
			this.uxShiftId.DataBindings.Clear();
			this.uxShiftId.DataBindings.Add("Text", this.uxBindingSource, "ShiftId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStartTime.DataBindings.Clear();
			this.uxStartTime.DataBindings.Add("Value", this.uxBindingSource, "StartTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEndTime.DataBindings.Clear();
			this.uxEndTime.DataBindings.Add("Value", this.uxBindingSource, "EndTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ShiftEditControlBase"/> class.
		/// </summary>
		public ShiftEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Shift != null) _Shift.Validate();
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
			this.uxShiftId = new System.Windows.Forms.TextBox();
			uxShiftIdLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxStartTime = new System.Windows.Forms.DateTimePicker();
			uxStartTimeLabel = new System.Windows.Forms.Label();
			this.uxEndTime = new System.Windows.Forms.DateTimePicker();
			uxEndTimeLabel = new System.Windows.Forms.Label();
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
			// uxShiftIdLabel
			//
			this.uxShiftIdLabel.Name = "uxShiftIdLabel";
			this.uxShiftIdLabel.Text = "Shift Id:";
			this.uxShiftIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxShiftIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxShiftIdLabel);			
			//
			// uxShiftId
			//
			this.uxShiftId.Name = "uxShiftId";
            this.uxShiftId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxShiftId);
			this.uxShiftId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxShiftId);
			//
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxName);
			//
			// uxStartTimeLabel
			//
			this.uxStartTimeLabel.Name = "uxStartTimeLabel";
			this.uxStartTimeLabel.Text = "Start Time:";
			this.uxStartTimeLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxStartTimeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStartTimeLabel);			
			//
			// uxStartTime
			//
			this.uxStartTime.Name = "uxStartTime";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStartTime);
			this.uxStartTime.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxStartTime);
			//
			// uxEndTimeLabel
			//
			this.uxEndTimeLabel.Name = "uxEndTimeLabel";
			this.uxEndTimeLabel.Text = "End Time:";
			this.uxEndTimeLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxEndTimeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEndTimeLabel);			
			//
			// uxEndTime
			//
			this.uxEndTime.Name = "uxEndTime";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEndTime);
			this.uxEndTime.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxEndTime);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxModifiedDate);
			// 
			// ShiftEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ShiftEditControlBase";
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
        /// Indicates if the controls associated with the uxShiftId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxShiftIdVisible
        {
            get { return this.uxShiftId.Visible; }
            set
            {
                this.uxShiftIdLabel.Visible = value;
                this.uxShiftId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxShiftId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxShiftIdEnabled
        {
            get { return this.uxShiftId.Enabled; }
            set
            {
                this.uxShiftId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNameVisible
        {
            get { return this.uxName.Visible; }
            set
            {
                this.uxNameLabel.Visible = value;
                this.uxName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNameEnabled
        {
            get { return this.uxName.Enabled; }
            set
            {
                this.uxName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStartTime property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStartTimeVisible
        {
            get { return this.uxStartTime.Visible; }
            set
            {
                this.uxStartTimeLabel.Visible = value;
                this.uxStartTime.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStartTime property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStartTimeEnabled
        {
            get { return this.uxStartTime.Enabled; }
            set
            {
                this.uxStartTime.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEndTime property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEndTimeVisible
        {
            get { return this.uxEndTime.Visible; }
            set
            {
                this.uxEndTimeLabel.Visible = value;
                this.uxEndTime.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEndTime property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEndTimeEnabled
        {
            get { return this.uxEndTime.Enabled; }
            set
            {
                this.uxEndTime.Enabled = value;
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
