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
    /// A designer class for a strongly typed repeater <c>SalesOrderHeaderRepeater</c>
    /// </summary>
	public class SalesOrderHeaderRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:SalesOrderHeaderRepeaterDesigner"/> class.
        /// </summary>
		public SalesOrderHeaderRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is SalesOrderHeaderRepeater))
			{ 
				throw new ArgumentException("Component is not a SalesOrderHeaderRepeater."); 
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
			SalesOrderHeaderRepeater z = (SalesOrderHeaderRepeater)Component;
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
    /// A strongly typed repeater control for the <see cref="SalesOrderHeaderRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(SalesOrderHeaderRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:SalesOrderHeaderRepeater runat=\"server\"></{0}:SalesOrderHeaderRepeater>")]
	public class SalesOrderHeaderRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:SalesOrderHeaderRepeater"/> class.
        /// </summary>
		public SalesOrderHeaderRepeater()
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
		[TemplateContainer(typeof(SalesOrderHeaderItem))]
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
		[TemplateContainer(typeof(SalesOrderHeaderItem))]
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
        [TemplateContainer(typeof(SalesOrderHeaderItem))]
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
		[TemplateContainer(typeof(SalesOrderHeaderItem))]
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
		[TemplateContainer(typeof(SalesOrderHeaderItem))]
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
						Nettiers.AdventureWorks.Entities.SalesOrderHeader entity = o as Nettiers.AdventureWorks.Entities.SalesOrderHeader;
						SalesOrderHeaderItem container = new SalesOrderHeaderItem(entity);
	
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
	public class SalesOrderHeaderItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.SalesOrderHeader _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SalesOrderHeaderItem"/> class.
        /// </summary>
		public SalesOrderHeaderItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SalesOrderHeaderItem"/> class.
        /// </summary>
		public SalesOrderHeaderItem(Nettiers.AdventureWorks.Entities.SalesOrderHeader entity)
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
        /// Gets the RevisionNumber
        /// </summary>
        /// <value>The RevisionNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte RevisionNumber
		{
			get { return _entity.RevisionNumber; }
		}
        /// <summary>
        /// Gets the OrderDate
        /// </summary>
        /// <value>The OrderDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime OrderDate
		{
			get { return _entity.OrderDate; }
		}
        /// <summary>
        /// Gets the DueDate
        /// </summary>
        /// <value>The DueDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime DueDate
		{
			get { return _entity.DueDate; }
		}
        /// <summary>
        /// Gets the ShipDate
        /// </summary>
        /// <value>The ShipDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? ShipDate
		{
			get { return _entity.ShipDate; }
		}
        /// <summary>
        /// Gets the Status
        /// </summary>
        /// <value>The Status.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte Status
		{
			get { return _entity.Status; }
		}
        /// <summary>
        /// Gets the OnlineOrderFlag
        /// </summary>
        /// <value>The OnlineOrderFlag.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean OnlineOrderFlag
		{
			get { return _entity.OnlineOrderFlag; }
		}
        /// <summary>
        /// Gets the SalesOrderNumber
        /// </summary>
        /// <value>The SalesOrderNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SalesOrderNumber
		{
			get { return _entity.SalesOrderNumber; }
		}
        /// <summary>
        /// Gets the PurchaseOrderNumber
        /// </summary>
        /// <value>The PurchaseOrderNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PurchaseOrderNumber
		{
			get { return _entity.PurchaseOrderNumber; }
		}
        /// <summary>
        /// Gets the AccountNumber
        /// </summary>
        /// <value>The AccountNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AccountNumber
		{
			get { return _entity.AccountNumber; }
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
        /// Gets the ContactId
        /// </summary>
        /// <value>The ContactId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ContactId
		{
			get { return _entity.ContactId; }
		}
        /// <summary>
        /// Gets the SalesPersonId
        /// </summary>
        /// <value>The SalesPersonId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SalesPersonId
		{
			get { return _entity.SalesPersonId; }
		}
        /// <summary>
        /// Gets the TerritoryId
        /// </summary>
        /// <value>The TerritoryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? TerritoryId
		{
			get { return _entity.TerritoryId; }
		}
        /// <summary>
        /// Gets the BillToAddressId
        /// </summary>
        /// <value>The BillToAddressId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 BillToAddressId
		{
			get { return _entity.BillToAddressId; }
		}
        /// <summary>
        /// Gets the ShipToAddressId
        /// </summary>
        /// <value>The ShipToAddressId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ShipToAddressId
		{
			get { return _entity.ShipToAddressId; }
		}
        /// <summary>
        /// Gets the ShipMethodId
        /// </summary>
        /// <value>The ShipMethodId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ShipMethodId
		{
			get { return _entity.ShipMethodId; }
		}
        /// <summary>
        /// Gets the CreditCardId
        /// </summary>
        /// <value>The CreditCardId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CreditCardId
		{
			get { return _entity.CreditCardId; }
		}
        /// <summary>
        /// Gets the CreditCardApprovalCode
        /// </summary>
        /// <value>The CreditCardApprovalCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreditCardApprovalCode
		{
			get { return _entity.CreditCardApprovalCode; }
		}
        /// <summary>
        /// Gets the CurrencyRateId
        /// </summary>
        /// <value>The CurrencyRateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CurrencyRateId
		{
			get { return _entity.CurrencyRateId; }
		}
        /// <summary>
        /// Gets the SubTotal
        /// </summary>
        /// <value>The SubTotal.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal SubTotal
		{
			get { return _entity.SubTotal; }
		}
        /// <summary>
        /// Gets the TaxAmt
        /// </summary>
        /// <value>The TaxAmt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal TaxAmt
		{
			get { return _entity.TaxAmt; }
		}
        /// <summary>
        /// Gets the Freight
        /// </summary>
        /// <value>The Freight.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal Freight
		{
			get { return _entity.Freight; }
		}
        /// <summary>
        /// Gets the TotalDue
        /// </summary>
        /// <value>The TotalDue.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal TotalDue
		{
			get { return _entity.TotalDue; }
		}
        /// <summary>
        /// Gets the Comment
        /// </summary>
        /// <value>The Comment.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Comment
		{
			get { return _entity.Comment; }
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
        /// Gets a <see cref="T:Nettiers.AdventureWorks.Entities.SalesOrderHeader"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Nettiers.AdventureWorks.Entities.SalesOrderHeader Entity
        {
            get { return _entity; }
        }
	}
}
