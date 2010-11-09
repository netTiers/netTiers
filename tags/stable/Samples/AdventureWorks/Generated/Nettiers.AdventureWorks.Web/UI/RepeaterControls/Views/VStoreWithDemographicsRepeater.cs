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
    /// A designer class for a strongly typed repeater <c>VStoreWithDemographicsRepeater</c>
    /// </summary>
	public class VStoreWithDemographicsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VStoreWithDemographicsRepeaterDesigner"/> class.
        /// </summary>
		public VStoreWithDemographicsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VStoreWithDemographicsRepeater))
			{ 
				throw new ArgumentException("Component is not a VStoreWithDemographicsRepeater."); 
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
			VStoreWithDemographicsRepeater z = (VStoreWithDemographicsRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VStoreWithDemographicsRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(VStoreWithDemographicsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VStoreWithDemographicsRepeater runat=\"server\"></{0}:VStoreWithDemographicsRepeater>")]
	public class VStoreWithDemographicsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VStoreWithDemographicsRepeater"/> class.
        /// </summary>
		public VStoreWithDemographicsRepeater()
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
		[TemplateContainer(typeof(VStoreWithDemographicsItem))]
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
		[TemplateContainer(typeof(VStoreWithDemographicsItem))]
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
        [TemplateContainer(typeof(VStoreWithDemographicsItem))]
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
		[TemplateContainer(typeof(VStoreWithDemographicsItem))]
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
		[TemplateContainer(typeof(VStoreWithDemographicsItem))]
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
						Nettiers.AdventureWorks.Entities.VStoreWithDemographics entity = o as Nettiers.AdventureWorks.Entities.VStoreWithDemographics;
						VStoreWithDemographicsItem container = new VStoreWithDemographicsItem(entity);
	
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
	public class VStoreWithDemographicsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.VStoreWithDemographics _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VStoreWithDemographicsItem"/> class.
        /// </summary>
		public VStoreWithDemographicsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VStoreWithDemographicsItem"/> class.
        /// </summary>
		public VStoreWithDemographicsItem(Nettiers.AdventureWorks.Entities.VStoreWithDemographics entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the CustomerId
        /// </summary>
        /// <value>The CustomerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CustomerId
		{
			get { return _entity.CustomerId; }
		}
        /// <summary>
        /// Gets the Name
        /// </summary>
        /// <value>The Name.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Name
		{
			get { return _entity.Name; }
		}
        /// <summary>
        /// Gets the ContactType
        /// </summary>
        /// <value>The ContactType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ContactType
		{
			get { return _entity.ContactType; }
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
        /// Gets the Phone
        /// </summary>
        /// <value>The Phone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Phone
		{
			get { return _entity.Phone; }
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
        /// Gets the EmailPromotion
        /// </summary>
        /// <value>The EmailPromotion.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmailPromotion
		{
			get { return _entity.EmailPromotion; }
		}
        /// <summary>
        /// Gets the AddressType
        /// </summary>
        /// <value>The AddressType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AddressType
		{
			get { return _entity.AddressType; }
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
        /// Gets the City
        /// </summary>
        /// <value>The City.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String City
		{
			get { return _entity.City; }
		}
        /// <summary>
        /// Gets the StateProvinceName
        /// </summary>
        /// <value>The StateProvinceName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String StateProvinceName
		{
			get { return _entity.StateProvinceName; }
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
        /// Gets the CountryRegionName
        /// </summary>
        /// <value>The CountryRegionName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CountryRegionName
		{
			get { return _entity.CountryRegionName; }
		}
        /// <summary>
        /// Gets the AnnualSales
        /// </summary>
        /// <value>The AnnualSales.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? AnnualSales
		{
			get { return _entity.AnnualSales; }
		}
        /// <summary>
        /// Gets the AnnualRevenue
        /// </summary>
        /// <value>The AnnualRevenue.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? AnnualRevenue
		{
			get { return _entity.AnnualRevenue; }
		}
        /// <summary>
        /// Gets the BankName
        /// </summary>
        /// <value>The BankName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BankName
		{
			get { return _entity.BankName; }
		}
        /// <summary>
        /// Gets the BusinessType
        /// </summary>
        /// <value>The BusinessType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BusinessType
		{
			get { return _entity.BusinessType; }
		}
        /// <summary>
        /// Gets the YearOpened
        /// </summary>
        /// <value>The YearOpened.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? YearOpened
		{
			get { return _entity.YearOpened; }
		}
        /// <summary>
        /// Gets the Specialty
        /// </summary>
        /// <value>The Specialty.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Specialty
		{
			get { return _entity.Specialty; }
		}
        /// <summary>
        /// Gets the SquareFeet
        /// </summary>
        /// <value>The SquareFeet.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SquareFeet
		{
			get { return _entity.SquareFeet; }
		}
        /// <summary>
        /// Gets the Brands
        /// </summary>
        /// <value>The Brands.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Brands
		{
			get { return _entity.Brands; }
		}
        /// <summary>
        /// Gets the Internet
        /// </summary>
        /// <value>The Internet.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Internet
		{
			get { return _entity.Internet; }
		}
        /// <summary>
        /// Gets the NumberEmployees
        /// </summary>
        /// <value>The NumberEmployees.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? NumberEmployees
		{
			get { return _entity.NumberEmployees; }
		}

	}
}
