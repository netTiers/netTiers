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
    /// A designer class for a strongly typed repeater <c>TransactionHistoryArchiveRepeater</c>
    /// </summary>
	public class TransactionHistoryArchiveRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TransactionHistoryArchiveRepeaterDesigner"/> class.
        /// </summary>
		public TransactionHistoryArchiveRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is TransactionHistoryArchiveRepeater))
			{ 
				throw new ArgumentException("Component is not a TransactionHistoryArchiveRepeater."); 
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
			TransactionHistoryArchiveRepeater z = (TransactionHistoryArchiveRepeater)Component;
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
    /// A strongly typed repeater control for the <see cref="TransactionHistoryArchiveRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(TransactionHistoryArchiveRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:TransactionHistoryArchiveRepeater runat=\"server\"></{0}:TransactionHistoryArchiveRepeater>")]
	public class TransactionHistoryArchiveRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TransactionHistoryArchiveRepeater"/> class.
        /// </summary>
		public TransactionHistoryArchiveRepeater()
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
		[TemplateContainer(typeof(TransactionHistoryArchiveItem))]
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
		[TemplateContainer(typeof(TransactionHistoryArchiveItem))]
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
        [TemplateContainer(typeof(TransactionHistoryArchiveItem))]
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
		[TemplateContainer(typeof(TransactionHistoryArchiveItem))]
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
		[TemplateContainer(typeof(TransactionHistoryArchiveItem))]
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
						Nettiers.AdventureWorks.Entities.TransactionHistoryArchive entity = o as Nettiers.AdventureWorks.Entities.TransactionHistoryArchive;
						TransactionHistoryArchiveItem container = new TransactionHistoryArchiveItem(entity);
	
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
	public class TransactionHistoryArchiveItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.TransactionHistoryArchive _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TransactionHistoryArchiveItem"/> class.
        /// </summary>
		public TransactionHistoryArchiveItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TransactionHistoryArchiveItem"/> class.
        /// </summary>
		public TransactionHistoryArchiveItem(Nettiers.AdventureWorks.Entities.TransactionHistoryArchive entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the TransactionId
        /// </summary>
        /// <value>The TransactionId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 TransactionId
		{
			get { return _entity.TransactionId; }
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
        /// Gets the ReferenceOrderId
        /// </summary>
        /// <value>The ReferenceOrderId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ReferenceOrderId
		{
			get { return _entity.ReferenceOrderId; }
		}
        /// <summary>
        /// Gets the ReferenceOrderLineId
        /// </summary>
        /// <value>The ReferenceOrderLineId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ReferenceOrderLineId
		{
			get { return _entity.ReferenceOrderLineId; }
		}
        /// <summary>
        /// Gets the TransactionDate
        /// </summary>
        /// <value>The TransactionDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime TransactionDate
		{
			get { return _entity.TransactionDate; }
		}
        /// <summary>
        /// Gets the TransactionType
        /// </summary>
        /// <value>The TransactionType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TransactionType
		{
			get { return _entity.TransactionType; }
		}
        /// <summary>
        /// Gets the Quantity
        /// </summary>
        /// <value>The Quantity.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Quantity
		{
			get { return _entity.Quantity; }
		}
        /// <summary>
        /// Gets the ActualCost
        /// </summary>
        /// <value>The ActualCost.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal ActualCost
		{
			get { return _entity.ActualCost; }
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
        /// Gets a <see cref="T:Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Nettiers.AdventureWorks.Entities.TransactionHistoryArchive Entity
        {
            get { return _entity; }
        }
	}
}
