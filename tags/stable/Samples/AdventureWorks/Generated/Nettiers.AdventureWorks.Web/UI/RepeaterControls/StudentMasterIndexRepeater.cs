using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace Nettiers.AdventureWorks.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>StudentMasterIndexRepeater</c>
    /// </summary>
	public class StudentMasterIndexRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:StudentMasterIndexRepeaterDesigner"/> class.
        /// </summary>
		public StudentMasterIndexRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is StudentMasterIndexRepeater))
			{ 
				throw new ArgumentException("Component is not a StudentMasterIndexRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			StudentMasterIndexRepeater z = (StudentMasterIndexRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <c cref="StudentMasterIndexRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(StudentMasterIndexRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:StudentMasterIndexRepeater runat=\"server\"></{0}:StudentMasterIndexRepeater>")]
	public class StudentMasterIndexRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:StudentMasterIndexRepeater"/> class.
        /// </summary>
		public StudentMasterIndexRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(StudentMasterIndexItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(StudentMasterIndexItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(StudentMasterIndexItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(StudentMasterIndexItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(StudentMasterIndexItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						Nettiers.AdventureWorks.Entities.StudentMasterIndex entity = o as Nettiers.AdventureWorks.Entities.StudentMasterIndex;
						StudentMasterIndexItem container = new StudentMasterIndexItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class StudentMasterIndexItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.StudentMasterIndex _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StudentMasterIndexItem"/> class.
        /// </summary>
		public StudentMasterIndexItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StudentMasterIndexItem"/> class.
        /// </summary>
		public StudentMasterIndexItem(Nettiers.AdventureWorks.Entities.StudentMasterIndex entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the StudentId
        /// </summary>
        /// <value>The StudentId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 StudentId
		{
			get { return _entity.StudentId; }
		}
        /// <summary>
        /// Gets the EpassId
        /// </summary>
        /// <value>The EpassId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EpassId
		{
			get { return _entity.EpassId; }
		}
        /// <summary>
        /// Gets the StudentUpn
        /// </summary>
        /// <value>The StudentUpn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String StudentUpn
		{
			get { return _entity.StudentUpn; }
		}
        /// <summary>
        /// Gets the SsabsaId
        /// </summary>
        /// <value>The SsabsaId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SsabsaId
		{
			get { return _entity.SsabsaId; }
		}
        /// <summary>
        /// Gets the Surname
        /// </summary>
        /// <value>The Surname.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Surname
		{
			get { return _entity.Surname; }
		}
        /// <summary>
        /// Gets the FirstName
        /// </summary>
        /// <value>The FirstName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FirstName
		{
			get { return _entity.FirstName; }
		}
        /// <summary>
        /// Gets the OtherNames
        /// </summary>
        /// <value>The OtherNames.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String OtherNames
		{
			get { return _entity.OtherNames; }
		}
        /// <summary>
        /// Gets the KnownName
        /// </summary>
        /// <value>The KnownName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String KnownName
		{
			get { return _entity.KnownName; }
		}
        /// <summary>
        /// Gets the LegalName
        /// </summary>
        /// <value>The LegalName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LegalName
		{
			get { return _entity.LegalName; }
		}
        /// <summary>
        /// Gets the Dob
        /// </summary>
        /// <value>The Dob.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? Dob
		{
			get { return _entity.Dob; }
		}
        /// <summary>
        /// Gets the Gender
        /// </summary>
        /// <value>The Gender.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Gender
		{
			get { return _entity.Gender; }
		}
        /// <summary>
        /// Gets the IndigeneousStatus
        /// </summary>
        /// <value>The IndigeneousStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String IndigeneousStatus
		{
			get { return _entity.IndigeneousStatus; }
		}
        /// <summary>
        /// Gets the Lbote
        /// </summary>
        /// <value>The Lbote.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Lbote
		{
			get { return _entity.Lbote; }
		}
        /// <summary>
        /// Gets the EslPhase
        /// </summary>
        /// <value>The EslPhase.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EslPhase
		{
			get { return _entity.EslPhase; }
		}
        /// <summary>
        /// Gets the TribalGroup
        /// </summary>
        /// <value>The TribalGroup.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TribalGroup
		{
			get { return _entity.TribalGroup; }
		}
        /// <summary>
        /// Gets the SlpCreatedFlag
        /// </summary>
        /// <value>The SlpCreatedFlag.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SlpCreatedFlag
		{
			get { return _entity.SlpCreatedFlag; }
		}
        /// <summary>
        /// Gets the AddressLine1
        /// </summary>
        /// <value>The AddressLine1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AddressLine1
		{
			get { return _entity.AddressLine1; }
		}
        /// <summary>
        /// Gets the AddressLine2
        /// </summary>
        /// <value>The AddressLine2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AddressLine2
		{
			get { return _entity.AddressLine2; }
		}
        /// <summary>
        /// Gets the AddressLine3
        /// </summary>
        /// <value>The AddressLine3.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AddressLine3
		{
			get { return _entity.AddressLine3; }
		}
        /// <summary>
        /// Gets the AddressLine4
        /// </summary>
        /// <value>The AddressLine4.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AddressLine4
		{
			get { return _entity.AddressLine4; }
		}
        /// <summary>
        /// Gets the Suburb
        /// </summary>
        /// <value>The Suburb.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Suburb
		{
			get { return _entity.Suburb; }
		}
        /// <summary>
        /// Gets the Postcode
        /// </summary>
        /// <value>The Postcode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Postcode
		{
			get { return _entity.Postcode; }
		}
        /// <summary>
        /// Gets the Phone1
        /// </summary>
        /// <value>The Phone1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Phone1
		{
			get { return _entity.Phone1; }
		}
        /// <summary>
        /// Gets the Phone2
        /// </summary>
        /// <value>The Phone2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Phone2
		{
			get { return _entity.Phone2; }
		}
        /// <summary>
        /// Gets the SourceSystem
        /// </summary>
        /// <value>The SourceSystem.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SourceSystem
		{
			get { return _entity.SourceSystem; }
		}
        /// <summary>
        /// Gets the PhoneticMatchId
        /// </summary>
        /// <value>The PhoneticMatchId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? PhoneticMatchId
		{
			get { return _entity.PhoneticMatchId; }
		}

        /// <summary>
        /// Gets a <see cref="T:Nettiers.AdventureWorks.Entities.StudentMasterIndex"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Nettiers.AdventureWorks.Entities.StudentMasterIndex Entity
        {
            get { return _entity; }
        }
	}
}
