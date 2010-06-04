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
    /// A designer class for a strongly typed repeater <c>VEmployeeDepartmentHistoryRepeater</c>
    /// </summary>
	public class VEmployeeDepartmentHistoryRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VEmployeeDepartmentHistoryRepeaterDesigner"/> class.
        /// </summary>
		public VEmployeeDepartmentHistoryRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VEmployeeDepartmentHistoryRepeater))
			{ 
				throw new ArgumentException("Component is not a VEmployeeDepartmentHistoryRepeater."); 
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
			VEmployeeDepartmentHistoryRepeater z = (VEmployeeDepartmentHistoryRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VEmployeeDepartmentHistoryRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(VEmployeeDepartmentHistoryRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VEmployeeDepartmentHistoryRepeater runat=\"server\"></{0}:VEmployeeDepartmentHistoryRepeater>")]
	public class VEmployeeDepartmentHistoryRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VEmployeeDepartmentHistoryRepeater"/> class.
        /// </summary>
		public VEmployeeDepartmentHistoryRepeater()
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
		[TemplateContainer(typeof(VEmployeeDepartmentHistoryItem))]
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
		[TemplateContainer(typeof(VEmployeeDepartmentHistoryItem))]
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
        [TemplateContainer(typeof(VEmployeeDepartmentHistoryItem))]
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
		[TemplateContainer(typeof(VEmployeeDepartmentHistoryItem))]
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
		[TemplateContainer(typeof(VEmployeeDepartmentHistoryItem))]
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
						Nettiers.AdventureWorks.Entities.VEmployeeDepartmentHistory entity = o as Nettiers.AdventureWorks.Entities.VEmployeeDepartmentHistory;
						VEmployeeDepartmentHistoryItem container = new VEmployeeDepartmentHistoryItem(entity);
	
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
	public class VEmployeeDepartmentHistoryItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.VEmployeeDepartmentHistory _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VEmployeeDepartmentHistoryItem"/> class.
        /// </summary>
		public VEmployeeDepartmentHistoryItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VEmployeeDepartmentHistoryItem"/> class.
        /// </summary>
		public VEmployeeDepartmentHistoryItem(Nettiers.AdventureWorks.Entities.VEmployeeDepartmentHistory entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the EmployeeId
        /// </summary>
        /// <value>The EmployeeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmployeeId
		{
			get { return _entity.EmployeeId; }
		}
        /// <summary>
        /// Gets the Title
        /// </summary>
        /// <value>The Title.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Title
		{
			get { return _entity.Title; }
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
        /// Gets the MiddleName
        /// </summary>
        /// <value>The MiddleName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MiddleName
		{
			get { return _entity.MiddleName; }
		}
        /// <summary>
        /// Gets the LastName
        /// </summary>
        /// <value>The LastName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LastName
		{
			get { return _entity.LastName; }
		}
        /// <summary>
        /// Gets the Suffix
        /// </summary>
        /// <value>The Suffix.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Suffix
		{
			get { return _entity.Suffix; }
		}
        /// <summary>
        /// Gets the Shift
        /// </summary>
        /// <value>The Shift.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Shift
		{
			get { return _entity.Shift; }
		}
        /// <summary>
        /// Gets the Department
        /// </summary>
        /// <value>The Department.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Department
		{
			get { return _entity.Department; }
		}
        /// <summary>
        /// Gets the GroupName
        /// </summary>
        /// <value>The GroupName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String GroupName
		{
			get { return _entity.GroupName; }
		}
        /// <summary>
        /// Gets the StartDate
        /// </summary>
        /// <value>The StartDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime StartDate
		{
			get { return _entity.StartDate; }
		}
        /// <summary>
        /// Gets the EndDate
        /// </summary>
        /// <value>The EndDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? EndDate
		{
			get { return _entity.EndDate; }
		}

	}
}
