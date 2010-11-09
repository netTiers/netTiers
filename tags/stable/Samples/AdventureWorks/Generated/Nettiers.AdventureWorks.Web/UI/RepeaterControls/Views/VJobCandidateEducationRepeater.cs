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
    /// A designer class for a strongly typed repeater <c>VJobCandidateEducationRepeater</c>
    /// </summary>
	public class VJobCandidateEducationRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VJobCandidateEducationRepeaterDesigner"/> class.
        /// </summary>
		public VJobCandidateEducationRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VJobCandidateEducationRepeater))
			{ 
				throw new ArgumentException("Component is not a VJobCandidateEducationRepeater."); 
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
			VJobCandidateEducationRepeater z = (VJobCandidateEducationRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VJobCandidateEducationRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(VJobCandidateEducationRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VJobCandidateEducationRepeater runat=\"server\"></{0}:VJobCandidateEducationRepeater>")]
	public class VJobCandidateEducationRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VJobCandidateEducationRepeater"/> class.
        /// </summary>
		public VJobCandidateEducationRepeater()
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
		[TemplateContainer(typeof(VJobCandidateEducationItem))]
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
		[TemplateContainer(typeof(VJobCandidateEducationItem))]
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
        [TemplateContainer(typeof(VJobCandidateEducationItem))]
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
		[TemplateContainer(typeof(VJobCandidateEducationItem))]
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
		[TemplateContainer(typeof(VJobCandidateEducationItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}
		
		
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

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//		{
//			if (ChildControlsCreated)
//			{
//				return;
//			}
//			Controls.Clear();
//
//			if (m_headerTemplate != null)
//			{
//				Control headerItem = new Control();
//				m_headerTemplate.InstantiateIn(headerItem);
//				Controls.Add(headerItem);
//			}
//
//			
//			if (m_footerTemplate != null)
//			{
//				Control footerItem = new Control();
//				m_footerTemplate.InstantiateIn(footerItem);
//				Controls.Add(footerItem);
//			}
//			ChildControlsCreated = true;
//		}
		
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
						Nettiers.AdventureWorks.Entities.VJobCandidateEducation entity = o as Nettiers.AdventureWorks.Entities.VJobCandidateEducation;
						VJobCandidateEducationItem container = new VJobCandidateEducationItem(entity);
	
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
	public class VJobCandidateEducationItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.VJobCandidateEducation _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VJobCandidateEducationItem"/> class.
        /// </summary>
		public VJobCandidateEducationItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VJobCandidateEducationItem"/> class.
        /// </summary>
		public VJobCandidateEducationItem(Nettiers.AdventureWorks.Entities.VJobCandidateEducation entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the JobCandidateId
        /// </summary>
        /// <value>The JobCandidateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 JobCandidateId
		{
			get { return _entity.JobCandidateId; }
		}
        /// <summary>
        /// Gets the SafeNameEduLevel
        /// </summary>
        /// <value>The SafeNameEduLevel.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduLevel
		{
			get { return _entity.SafeNameEduLevel; }
		}
        /// <summary>
        /// Gets the SafeNameEduStartDate
        /// </summary>
        /// <value>The SafeNameEduStartDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? SafeNameEduStartDate
		{
			get { return _entity.SafeNameEduStartDate; }
		}
        /// <summary>
        /// Gets the SafeNameEduEndDate
        /// </summary>
        /// <value>The SafeNameEduEndDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? SafeNameEduEndDate
		{
			get { return _entity.SafeNameEduEndDate; }
		}
        /// <summary>
        /// Gets the SafeNameEduDegree
        /// </summary>
        /// <value>The SafeNameEduDegree.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduDegree
		{
			get { return _entity.SafeNameEduDegree; }
		}
        /// <summary>
        /// Gets the SafeNameEduMajor
        /// </summary>
        /// <value>The SafeNameEduMajor.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduMajor
		{
			get { return _entity.SafeNameEduMajor; }
		}
        /// <summary>
        /// Gets the SafeNameEduMinor
        /// </summary>
        /// <value>The SafeNameEduMinor.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduMinor
		{
			get { return _entity.SafeNameEduMinor; }
		}
        /// <summary>
        /// Gets the SafeNameEduGpa
        /// </summary>
        /// <value>The SafeNameEduGpa.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduGpa
		{
			get { return _entity.SafeNameEduGpa; }
		}
        /// <summary>
        /// Gets the SafeNameEduGpaScale
        /// </summary>
        /// <value>The SafeNameEduGpaScale.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduGpaScale
		{
			get { return _entity.SafeNameEduGpaScale; }
		}
        /// <summary>
        /// Gets the SafeNameEduSchool
        /// </summary>
        /// <value>The SafeNameEduSchool.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduSchool
		{
			get { return _entity.SafeNameEduSchool; }
		}
        /// <summary>
        /// Gets the SafeNameEduLocCountryRegion
        /// </summary>
        /// <value>The SafeNameEduLocCountryRegion.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduLocCountryRegion
		{
			get { return _entity.SafeNameEduLocCountryRegion; }
		}
        /// <summary>
        /// Gets the SafeNameEduLocState
        /// </summary>
        /// <value>The SafeNameEduLocState.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduLocState
		{
			get { return _entity.SafeNameEduLocState; }
		}
        /// <summary>
        /// Gets the SafeNameEduLocCity
        /// </summary>
        /// <value>The SafeNameEduLocCity.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameEduLocCity
		{
			get { return _entity.SafeNameEduLocCity; }
		}

	}
}
