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
    /// A designer class for a strongly typed repeater <c>SalesOrderDetailRepeater</c>
    /// </summary>
	public class SalesOrderDetailRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:SalesOrderDetailRepeaterDesigner"/> class.
        /// </summary>
		public SalesOrderDetailRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is SalesOrderDetailRepeater))
			{ 
				throw new ArgumentException("Component is not a SalesOrderDetailRepeater."); 
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
			SalesOrderDetailRepeater z = (SalesOrderDetailRepeater)Component;
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
    /// A strongly typed repeater control for the <see cref="SalesOrderDetailRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(SalesOrderDetailRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:SalesOrderDetailRepeater runat=\"server\"></{0}:SalesOrderDetailRepeater>")]
	public class SalesOrderDetailRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:SalesOrderDetailRepeater"/> class.
        /// </summary>
		public SalesOrderDetailRepeater()
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
		[TemplateContainer(typeof(SalesOrderDetailItem))]
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
		[TemplateContainer(typeof(SalesOrderDetailItem))]
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
        [TemplateContainer(typeof(SalesOrderDetailItem))]
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
		[TemplateContainer(typeof(SalesOrderDetailItem))]
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
		[TemplateContainer(typeof(SalesOrderDetailItem))]
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
						Nettiers.AdventureWorks.Entities.SalesOrderDetail entity = o as Nettiers.AdventureWorks.Entities.SalesOrderDetail;
						SalesOrderDetailItem container = new SalesOrderDetailItem(entity);
	
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
	public class SalesOrderDetailItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.SalesOrderDetail _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SalesOrderDetailItem"/> class.
        /// </summary>
		public SalesOrderDetailItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SalesOrderDetailItem"/> class.
        /// </summary>
		public SalesOrderDetailItem(Nettiers.AdventureWorks.Entities.SalesOrderDetail entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the SalesOrderId
        /// </summary>
        /// <value>The SalesOrderId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 SalesOrderId
		{
			get { return _entity.SalesOrderId; }
		}
        /// <summary>
        /// Gets the SalesOrderDetailId
        /// </summary>
        /// <value>The SalesOrderDetailId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 SalesOrderDetailId
		{
			get { return _entity.SalesOrderDetailId; }
		}
        /// <summary>
        /// Gets the CarrierTrackingNumber
        /// </summary>
        /// <value>The CarrierTrackingNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CarrierTrackingNumber
		{
			get { return _entity.CarrierTrackingNumber; }
		}
        /// <summary>
        /// Gets the OrderQty
        /// </summary>
        /// <value>The OrderQty.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16 OrderQty
		{
			get { return _entity.OrderQty; }
		}
        /// <summary>
        /// Gets the ProductId
        /// </summary>
        /// <value>The ProductId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ProductId
		{
			get { return _entity.ProductId; }
		}
        /// <summary>
        /// Gets the SpecialOfferId
        /// </summary>
        /// <value>The SpecialOfferId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 SpecialOfferId
		{
			get { return _entity.SpecialOfferId; }
		}
        /// <summary>
        /// Gets the UnitPrice
        /// </summary>
        /// <value>The UnitPrice.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal UnitPrice
		{
			get { return _entity.UnitPrice; }
		}
        /// <summary>
        /// Gets the UnitPriceDiscount
        /// </summary>
        /// <value>The UnitPriceDiscount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal UnitPriceDiscount
		{
			get { return _entity.UnitPriceDiscount; }
		}
        /// <summary>
        /// Gets the LineTotal
        /// </summary>
        /// <value>The LineTotal.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal LineTotal
		{
			get { return _entity.LineTotal; }
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

        /// <summary>
        /// Gets a <see cref="T:Nettiers.AdventureWorks.Entities.SalesOrderDetail"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Nettiers.AdventureWorks.Entities.SalesOrderDetail Entity
        {
            get { return _entity; }
        }
	}
}
