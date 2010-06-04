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
    /// A designer class for a strongly typed repeater <c>VProductModelCatalogDescriptionRepeater</c>
    /// </summary>
	public class VProductModelCatalogDescriptionRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VProductModelCatalogDescriptionRepeaterDesigner"/> class.
        /// </summary>
		public VProductModelCatalogDescriptionRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VProductModelCatalogDescriptionRepeater))
			{ 
				throw new ArgumentException("Component is not a VProductModelCatalogDescriptionRepeater."); 
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
			VProductModelCatalogDescriptionRepeater z = (VProductModelCatalogDescriptionRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VProductModelCatalogDescriptionRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(VProductModelCatalogDescriptionRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VProductModelCatalogDescriptionRepeater runat=\"server\"></{0}:VProductModelCatalogDescriptionRepeater>")]
	public class VProductModelCatalogDescriptionRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VProductModelCatalogDescriptionRepeater"/> class.
        /// </summary>
		public VProductModelCatalogDescriptionRepeater()
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
		[TemplateContainer(typeof(VProductModelCatalogDescriptionItem))]
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
		[TemplateContainer(typeof(VProductModelCatalogDescriptionItem))]
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
        [TemplateContainer(typeof(VProductModelCatalogDescriptionItem))]
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
		[TemplateContainer(typeof(VProductModelCatalogDescriptionItem))]
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
		[TemplateContainer(typeof(VProductModelCatalogDescriptionItem))]
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
						Nettiers.AdventureWorks.Entities.VProductModelCatalogDescription entity = o as Nettiers.AdventureWorks.Entities.VProductModelCatalogDescription;
						VProductModelCatalogDescriptionItem container = new VProductModelCatalogDescriptionItem(entity);
	
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
	public class VProductModelCatalogDescriptionItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Nettiers.AdventureWorks.Entities.VProductModelCatalogDescription _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VProductModelCatalogDescriptionItem"/> class.
        /// </summary>
		public VProductModelCatalogDescriptionItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VProductModelCatalogDescriptionItem"/> class.
        /// </summary>
		public VProductModelCatalogDescriptionItem(Nettiers.AdventureWorks.Entities.VProductModelCatalogDescription entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the ProductModelId
        /// </summary>
        /// <value>The ProductModelId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ProductModelId
		{
			get { return _entity.ProductModelId; }
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
        /// Gets the Summary
        /// </summary>
        /// <value>The Summary.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Summary
		{
			get { return _entity.Summary; }
		}
        /// <summary>
        /// Gets the Manufacturer
        /// </summary>
        /// <value>The Manufacturer.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Manufacturer
		{
			get { return _entity.Manufacturer; }
		}
        /// <summary>
        /// Gets the Copyright
        /// </summary>
        /// <value>The Copyright.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Copyright
		{
			get { return _entity.Copyright; }
		}
        /// <summary>
        /// Gets the ProductUrl
        /// </summary>
        /// <value>The ProductUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductUrl
		{
			get { return _entity.ProductUrl; }
		}
        /// <summary>
        /// Gets the WarrantyPeriod
        /// </summary>
        /// <value>The WarrantyPeriod.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WarrantyPeriod
		{
			get { return _entity.WarrantyPeriod; }
		}
        /// <summary>
        /// Gets the WarrantyDescription
        /// </summary>
        /// <value>The WarrantyDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WarrantyDescription
		{
			get { return _entity.WarrantyDescription; }
		}
        /// <summary>
        /// Gets the NoOfYears
        /// </summary>
        /// <value>The NoOfYears.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String NoOfYears
		{
			get { return _entity.NoOfYears; }
		}
        /// <summary>
        /// Gets the MaintenanceDescription
        /// </summary>
        /// <value>The MaintenanceDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MaintenanceDescription
		{
			get { return _entity.MaintenanceDescription; }
		}
        /// <summary>
        /// Gets the Wheel
        /// </summary>
        /// <value>The Wheel.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Wheel
		{
			get { return _entity.Wheel; }
		}
        /// <summary>
        /// Gets the Saddle
        /// </summary>
        /// <value>The Saddle.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Saddle
		{
			get { return _entity.Saddle; }
		}
        /// <summary>
        /// Gets the Pedal
        /// </summary>
        /// <value>The Pedal.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Pedal
		{
			get { return _entity.Pedal; }
		}
        /// <summary>
        /// Gets the BikeFrame
        /// </summary>
        /// <value>The BikeFrame.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BikeFrame
		{
			get { return _entity.BikeFrame; }
		}
        /// <summary>
        /// Gets the Crankset
        /// </summary>
        /// <value>The Crankset.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Crankset
		{
			get { return _entity.Crankset; }
		}
        /// <summary>
        /// Gets the PictureAngle
        /// </summary>
        /// <value>The PictureAngle.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PictureAngle
		{
			get { return _entity.PictureAngle; }
		}
        /// <summary>
        /// Gets the PictureSize
        /// </summary>
        /// <value>The PictureSize.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PictureSize
		{
			get { return _entity.PictureSize; }
		}
        /// <summary>
        /// Gets the ProductPhotoId
        /// </summary>
        /// <value>The ProductPhotoId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductPhotoId
		{
			get { return _entity.ProductPhotoId; }
		}
        /// <summary>
        /// Gets the Material
        /// </summary>
        /// <value>The Material.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Material
		{
			get { return _entity.Material; }
		}
        /// <summary>
        /// Gets the Color
        /// </summary>
        /// <value>The Color.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Color
		{
			get { return _entity.Color; }
		}
        /// <summary>
        /// Gets the ProductLine
        /// </summary>
        /// <value>The ProductLine.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductLine
		{
			get { return _entity.ProductLine; }
		}
        /// <summary>
        /// Gets the Style
        /// </summary>
        /// <value>The Style.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Style
		{
			get { return _entity.Style; }
		}
        /// <summary>
        /// Gets the RiderExperience
        /// </summary>
        /// <value>The RiderExperience.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RiderExperience
		{
			get { return _entity.RiderExperience; }
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
