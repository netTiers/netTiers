
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.JobCandidate"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class JobCandidateEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the JobCandidateId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxJobCandidateId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the JobCandidateId property.
		/// </summary>
		protected System.Windows.Forms.Label uxJobCandidateIdLabel;
		
		/// <summary>
		/// ComboBox for the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxEmployeeId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmployeeId property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmployeeIdLabel;
		
		/// <summary>
		/// TextBox for the Resume property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxResume;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Resume property.
		/// </summary>
		protected System.Windows.Forms.Label uxResumeLabel;
		
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
		private Entities.JobCandidate _JobCandidate;
		/// <summary>
		/// Gets or sets the <see cref="Entities.JobCandidate"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.JobCandidate"/> instance.</value>
		public Entities.JobCandidate JobCandidate
		{
			get {return this._JobCandidate;}
			set
			{
				this._JobCandidate = value;
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
			this.uxJobCandidateId.DataBindings.Clear();
			this.uxJobCandidateId.DataBindings.Add("Text", this.uxBindingSource, "JobCandidateId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmployeeId.DataBindings.Clear();
			this.uxEmployeeId.DataBindings.Add("SelectedValue", this.uxBindingSource, "EmployeeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxResume.DataBindings.Clear();
			this.uxResume.DataBindings.Add("Text", this.uxBindingSource, "Resume", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="JobCandidateEditControlBase"/> class.
		/// </summary>
		public JobCandidateEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_JobCandidate != null) _JobCandidate.Validate();
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
			this.uxJobCandidateId = new System.Windows.Forms.TextBox();
			uxJobCandidateIdLabel = new System.Windows.Forms.Label();
			this.uxEmployeeId = new System.Windows.Forms.ComboBox();
			uxEmployeeIdLabel = new System.Windows.Forms.Label();
			this.uxResume = new System.Windows.Forms.TextBox();
			uxResumeLabel = new System.Windows.Forms.Label();
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
			// uxJobCandidateIdLabel
			//
			this.uxJobCandidateIdLabel.Name = "uxJobCandidateIdLabel";
			this.uxJobCandidateIdLabel.Text = "Job Candidate Id:";
			this.uxJobCandidateIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxJobCandidateIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxJobCandidateIdLabel);			
			//
			// uxJobCandidateId
			//
			this.uxJobCandidateId.Name = "uxJobCandidateId";
            this.uxJobCandidateId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxJobCandidateId);
			this.uxJobCandidateId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxJobCandidateId);
			//
			// uxEmployeeIdLabel
			//
			this.uxEmployeeIdLabel.Name = "uxEmployeeIdLabel";
			this.uxEmployeeIdLabel.Text = "Employee Id:";
			this.uxEmployeeIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxEmployeeIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeIdLabel);			
			//
			// uxEmployeeId
			//
			this.uxEmployeeId.Name = "uxEmployeeId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeId);
			this.uxEmployeeId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxEmployeeId);
			//
			// uxResumeLabel
			//
			this.uxResumeLabel.Name = "uxResumeLabel";
			this.uxResumeLabel.Text = "Resume:";
			this.uxResumeLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxResumeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxResumeLabel);			
			//
			// uxResume
			//
			this.uxResume.Name = "uxResume";
			//this.uxTableLayoutPanel.Controls.Add(this.uxResume);
			this.uxResume.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxResume);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxEmployeeId
			//				
			this.uxEmployeeId.DisplayMember = "NationalIdNumber";	
			this.uxEmployeeId.ValueMember = "EmployeeId";	
			// 
			// JobCandidateEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "JobCandidateEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.Employee> _EmployeeIdList;
		
		/// <summary>
		/// The ComboBox associated with the EmployeeId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.Employee> EmployeeIdList
		{
			get {return _EmployeeIdList;}
			set 
			{
				this._EmployeeIdList = value;
				this.uxEmployeeId.DataSource = null;
				this.uxEmployeeId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInEmployeeIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the EmployeeId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInEmployeeIdList
		{
			get { return _allowNewItemInEmployeeIdList;}
			set
			{
				this._allowNewItemInEmployeeIdList = value;
				this.uxEmployeeId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxJobCandidateId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxJobCandidateIdVisible
        {
            get { return this.uxJobCandidateId.Visible; }
            set
            {
                this.uxJobCandidateIdLabel.Visible = value;
                this.uxJobCandidateId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxJobCandidateId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxJobCandidateIdEnabled
        {
            get { return this.uxJobCandidateId.Enabled; }
            set
            {
                this.uxJobCandidateId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEmployeeIdVisible
        {
            get { return this.uxEmployeeId.Visible; }
            set
            {
                this.uxEmployeeIdLabel.Visible = value;
                this.uxEmployeeId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEmployeeIdEnabled
        {
            get { return this.uxEmployeeId.Enabled; }
            set
            {
                this.uxEmployeeId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxResume property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxResumeVisible
        {
            get { return this.uxResume.Visible; }
            set
            {
                this.uxResumeLabel.Visible = value;
                this.uxResume.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxResume property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxResumeEnabled
        {
            get { return this.uxResume.Enabled; }
            set
            {
                this.uxResume.Enabled = value;
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
