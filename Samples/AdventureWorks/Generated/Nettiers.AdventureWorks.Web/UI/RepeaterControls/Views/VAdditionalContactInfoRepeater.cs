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
    /// A designer class for a strongly typed repeater <c>VAdditionalContactInfoRepeater</c>
    /// </summary>
	public class VAdditionalContactInfoRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VAdditionalContactInfoRepeaterDesigner"/> class.
        /// </summary>
		public VAdditionalContactInfoRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VAdditionalContactInfoRepeater))
			{ 
				throw new ArgumentException("Component is not a VAdditionalContactInfoRepeater."); 
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
			VAdditionalContactInfoRepeater z = (VAdditionalContactInfoRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VAdditionalContactInfoRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(VAdditionalContactInfoRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VAdditionalContactInfoRepeater runat=\"server\"></{0}:VAdditionalContactInfoRepeater>")]
	public class VAdditionalContactInfoRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VAdditionalContactInfoRepeater"/> class.
        /// </summary>
		public VAdditionalContactInfoRepeater()
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
		[TemplateContainer(typeof(VAdditionalContactInfoItem))]
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
		[TemplateContainer(typeof(VAdditionalContactInfoItem))]
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
        [TemplateContainer(typeof(VAdditionalContactInfoItem))]
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
		[TemplateContainer(typeof(VAdditionalContactInfoItem))]
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
		[TemplateContainer(typeof(VAdditionalContactInfoItem))]
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
						Nettiers.AdventureWorks.Entities.VAdditionalContactInfo entity = o as Nettiers.AdventureWorks.Entities.VAdditionalContactInfo;
						VAdditionalContactInfoItem container = new VAdditionalContactInfoItem(entity);
	
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
	public class VAdditionalContactInfoItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.VAdditionalContactInfo _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VAdditionalContactInfoItem"/> class.
        /// </summary>
		public VAdditionalContactInfoItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VAdditionalContactInfoItem"/> class.
        /// </summary>
		public VAdditionalContactInfoItem(Nettiers.AdventureWorks.Entities.VAdditionalContactInfo entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the ContactId
        /// </summary>
        /// <value>The ContactId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ContactId
		{
			get { return _entity.ContactId; }
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
        /// Gets the TelephoneNumber
        /// </summary>
        /// <value>The TelephoneNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TelephoneNumber
		{
			get { return _entity.TelephoneNumber; }
		}
        /// <summary>
        /// Gets the TelephoneSpecialInstructions
        /// </summary>
        /// <value>The TelephoneSpecialInstructions.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TelephoneSpecialInstructions
		{
			get { return _entity.TelephoneSpecialInstructions; }
		}
        /// <summary>
        /// Gets the Street
        /// </summary>
        /// <value>The Street.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Street
		{
			get { return _entity.Street; }
		}
        /// <summary>
        /// Gets the City
        /// </summary>
        /// <value>The City.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String City
		{
			get { return _entity.City; }
		}
        /// <summary>
        /// Gets the StateProvince
        /// </summary>
        /// <value>The StateProvince.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String StateProvince
		{
			get { return _entity.StateProvince; }
		}
        /// <summary>
        /// Gets the PostalCode
        /// </summary>
        /// <value>The PostalCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PostalCode
		{
			get { return _entity.PostalCode; }
		}
        /// <summary>
        /// Gets the CountryRegion
        /// </summary>
        /// <value>The CountryRegion.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CountryRegion
		{
			get { return _entity.CountryRegion; }
		}
        /// <summary>
        /// Gets the HomeAddressSpecialInstructions
        /// </summary>
        /// <value>The HomeAddressSpecialInstructions.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HomeAddressSpecialInstructions
		{
			get { return _entity.HomeAddressSpecialInstructions; }
		}
        /// <summary>
        /// Gets the EmailAddress
        /// </summary>
        /// <value>The EmailAddress.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailAddress
		{
			get { return _entity.EmailAddress; }
		}
        /// <summary>
        /// Gets the EmailSpecialInstructions
        /// </summary>
        /// <value>The EmailSpecialInstructions.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailSpecialInstructions
		{
			get { return _entity.EmailSpecialInstructions; }
		}
        /// <summary>
        /// Gets the EmailTelephoneNumber
        /// </summary>
        /// <value>The EmailTelephoneNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailTelephoneNumber
		{
			get { return _entity.EmailTelephoneNumber; }
		}
        /// <summary>
        /// Gets the Rowguid
        /// </summary>
        /// <value>The Rowguid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid Rowguid
		{
			get { return _entity.Rowguid; }
		}
        /// <summary>
        /// Gets the ModifiedDate
        /// </summary>
        /// <value>The ModifiedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime ModifiedDate
		{
			get { return _entity.ModifiedDate; }
		}

	}
}
