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
    /// A designer class for a strongly typed repeater <c>TestProductRepeater</c>
    /// </summary>
	public class TestProductRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TestProductRepeaterDesigner"/> class.
        /// </summary>
		public TestProductRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is TestProductRepeater))
			{ 
				throw new ArgumentException("Component is not a TestProductRepeater."); 
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
			TestProductRepeater z = (TestProductRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="TestProductRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(TestProductRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:TestProductRepeater runat=\"server\"></{0}:TestProductRepeater>")]
	public class TestProductRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TestProductRepeater"/> class.
        /// </summary>
		public TestProductRepeater()
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
		[TemplateContainer(typeof(TestProductItem))]
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
		[TemplateContainer(typeof(TestProductItem))]
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
        [TemplateContainer(typeof(TestProductItem))]
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
		[TemplateContainer(typeof(TestProductItem))]
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
		[TemplateContainer(typeof(TestProductItem))]
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
						Nettiers.AdventureWorks.Entities.TestProduct entity = o as Nettiers.AdventureWorks.Entities.TestProduct;
						TestProductItem container = new TestProductItem(entity);
	
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
	public class TestProductItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.TestProduct _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TestProductItem"/> class.
        /// </summary>
		public TestProductItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TestProductItem"/> class.
        /// </summary>
		public TestProductItem(Nettiers.AdventureWorks.Entities.TestProduct entity)
			: base()
		{
			_entity = entity;
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
        /// Gets the ProductTypeId
        /// </summary>
        /// <value>The ProductTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ProductTypeId
		{
			get { return _entity.ProductTypeId; }
		}
        /// <summary>
        /// Gets the DownloadId
        /// </summary>
        /// <value>The DownloadId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DownloadId
		{
			get { return _entity.DownloadId; }
		}
        /// <summary>
        /// Gets the ManufacturerId
        /// </summary>
        /// <value>The ManufacturerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ManufacturerId
		{
			get { return _entity.ManufacturerId; }
		}
        /// <summary>
        /// Gets the BrandName
        /// </summary>
        /// <value>The BrandName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BrandName
		{
			get { return _entity.BrandName; }
		}
        /// <summary>
        /// Gets the ProductName
        /// </summary>
        /// <value>The ProductName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductName
		{
			get { return _entity.ProductName; }
		}
        /// <summary>
        /// Gets the ProductCode
        /// </summary>
        /// <value>The ProductCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductCode
		{
			get { return _entity.ProductCode; }
		}
        /// <summary>
        /// Gets the UniqueIdentifier
        /// </summary>
        /// <value>The UniqueIdentifier.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UniqueIdentifier
		{
			get { return _entity.UniqueIdentifier; }
		}
        /// <summary>
        /// Gets the TypeName
        /// </summary>
        /// <value>The TypeName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TypeName
		{
			get { return _entity.TypeName; }
		}
        /// <summary>
        /// Gets the ModelName
        /// </summary>
        /// <value>The ModelName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ModelName
		{
			get { return _entity.ModelName; }
		}
        /// <summary>
        /// Gets the DisplayName
        /// </summary>
        /// <value>The DisplayName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DisplayName
		{
			get { return _entity.DisplayName; }
		}
        /// <summary>
        /// Gets the ProductLink
        /// </summary>
        /// <value>The ProductLink.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductLink
		{
			get { return _entity.ProductLink; }
		}
        /// <summary>
        /// Gets the ConnectorCode
        /// </summary>
        /// <value>The ConnectorCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ConnectorCode
		{
			get { return _entity.ConnectorCode; }
		}
        /// <summary>
        /// Gets the BaseId
        /// </summary>
        /// <value>The BaseId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? BaseId
		{
			get { return _entity.BaseId; }
		}
        /// <summary>
        /// Gets the OrgProductId
        /// </summary>
        /// <value>The OrgProductId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? OrgProductId
		{
			get { return _entity.OrgProductId; }
		}
        /// <summary>
        /// Gets the ImageFileType
        /// </summary>
        /// <value>The ImageFileType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ImageFileType
		{
			get { return _entity.ImageFileType; }
		}
        /// <summary>
        /// Gets the FullImageFileType
        /// </summary>
        /// <value>The FullImageFileType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FullImageFileType
		{
			get { return _entity.FullImageFileType; }
		}
        /// <summary>
        /// Gets the Status
        /// </summary>
        /// <value>The Status.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Status
		{
			get { return _entity.Status; }
		}
        /// <summary>
        /// Gets the AddedBy
        /// </summary>
        /// <value>The AddedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? AddedBy
		{
			get { return _entity.AddedBy; }
		}
        /// <summary>
        /// Gets the AddedDate
        /// </summary>
        /// <value>The AddedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? AddedDate
		{
			get { return _entity.AddedDate; }
		}
        /// <summary>
        /// Gets the UpdatedBy
        /// </summary>
        /// <value>The UpdatedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? UpdatedBy
		{
			get { return _entity.UpdatedBy; }
		}
        /// <summary>
        /// Gets the UpdatedDate
        /// </summary>
        /// <value>The UpdatedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? UpdatedDate
		{
			get { return _entity.UpdatedDate; }
		}

        /// <summary>
        /// Gets a <see cref="T:Nettiers.AdventureWorks.Entities.TestProduct"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Nettiers.AdventureWorks.Entities.TestProduct Entity
        {
            get { return _entity; }
        }
	}
}
