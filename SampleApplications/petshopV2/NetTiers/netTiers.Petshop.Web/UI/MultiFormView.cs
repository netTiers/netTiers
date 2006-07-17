#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Collections;
#endregion

namespace netTiers.Petshop.Web.UI
{
	/// <summary>
	/// Displays the values of a single record from a data source
	/// using user-defined templates. The MultiFormView control
	/// allows you to edit, delete, and insert records. This control
	/// extends the System.Web.UI.WebControls.FormView control and
	/// allows for multiple external templates to be combined for
	/// each of the supported templates.
	/// </summary>
	[ParseChildren(true), PersistChildren(false)]
	public class MultiFormView : FormView
	{
		#region Declarations

		/// <summary>
		/// Enumeration of values used as the key for the different types
		/// of paths managed by the MultiFormView class.
		/// </summary>
		public enum TemplateType
		{
			/// <summary>
			/// Key used by the ItemTemplatePaths property.
			/// </summary>
			ItemTemplate,
			/// <summary>
			/// Key used by the InsertTemplatePaths property.
			/// </summary>
			InsertItemTemplate,
			/// <summary>
			/// Key used by the EditItemTemplatePaths property.
			/// </summary>
			EditItemTemplate,
			/// <summary>
			/// Key used by the EmptyDataTemplatePaths property.
			/// </summary>
			EmptyDataTemplate,
			/// <summary>
			/// Key used by the HeaderTemplatePaths property.
			/// </summary>
			HeaderTemplate,
			/// <summary>
			/// Key used by the FooterTemplatePaths property.
			/// </summary>
			FooterTemplate,
			/// <summary>
			/// Key used by the PagerTemplatePaths property.
			/// </summary>
			PagerTemplate
		}

		private IDictionary<TemplateType, IList> _paths;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MultiFormView class.
		/// </summary>
		public MultiFormView()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets a collection of TemplatePath objects that represent
		/// the paths to external template controls to use for the
		/// ItemTemplate property.
		/// </summary>
		[System.ComponentModel.Bindable(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList ItemTemplatePaths
		{
			get { return GetPaths(TemplateType.ItemTemplate); }
		}

		/// <summary>
		/// Gets a collection of TemplatePath objects that represent
		/// the paths to external template controls to use for the
		/// InsertItemTemplate property.
		/// </summary>
		[System.ComponentModel.Bindable(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList InsertItemTemplatePaths
		{
			get { return GetPaths(TemplateType.InsertItemTemplate); }
		}

		/// <summary>
		/// Gets a collection of TemplatePath objects that represent
		/// the paths to external template controls to use for the
		/// EditItemTemplate property.
		/// </summary>
		[System.ComponentModel.Bindable(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList EditItemTemplatePaths
		{
			get { return GetPaths(TemplateType.EditItemTemplate); }
		}

		/// <summary>
		/// Gets a collection of TemplatePath objects that represent
		/// the paths to external template controls to use for the
		/// EmptyDataTemplate property.
		/// </summary>
		[System.ComponentModel.Bindable(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList EmptyDataTemplatePaths
		{
			get { return GetPaths(TemplateType.EmptyDataTemplate); }
		}

		/// <summary>
		/// Gets a collection of TemplatePath objects that represent
		/// the paths to external template controls to use for the
		/// HeaderTemplate property.
		/// </summary>
		[System.ComponentModel.Bindable(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList HeaderTemplatePaths
		{
			get { return GetPaths(TemplateType.HeaderTemplate); }
		}

		/// <summary>
		/// Gets a collection of TemplatePath objects that represent
		/// the paths to external template controls to use for the
		/// FooterTemplate property.
		/// </summary>
		[System.ComponentModel.Bindable(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList FooterTemplatePaths
		{
			get { return GetPaths(TemplateType.FooterTemplate); }
		}

		/// <summary>
		/// Gets a collection of TemplatePath objects that represent
		/// the paths to external template controls to use for the
		/// PagerTemplate property.
		/// </summary>
		[System.ComponentModel.Bindable(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList PagerTemplatePaths
		{
			get { return GetPaths(TemplateType.PagerTemplate); }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Gets a list of paths to external template controls for the specified key.
		/// </summary>
		/// <param name="type">A TemplateType enum value representing the type of template.</param>
		/// <returns>A list of paths to external template controls.</returns>
		private IList GetPaths(TemplateType type)
		{
			if ( _paths == null )
			{
				_paths = new Dictionary<TemplateType, IList>();
			}
			if ( !_paths.ContainsKey(type) )
			{
				_paths[type] = new ArrayList();
			}

			return _paths[type];
		}

		/// <summary>
		/// Raises the System.Web.UI.Control.Init event.
		/// </summary>
		/// <param name="e">An System.EventArgs that contains the event data.</param>
		protected override void OnInit(EventArgs e)
		{
			InitTemplates();
			base.OnInit(e);
		}

		/// <summary>
		/// Initializes all templates for the MultiFormView control.
		/// </summary>
		protected void InitTemplates()
		{
			if ( _paths != null )
			{
				foreach ( TemplateType type in Enum.GetValues(typeof(TemplateType)) )
				{
					InitTemplate(type);
				}
			}
		}

		/// <summary>
		/// Initializes the template for the MultiFormView control
		/// represented by the specified TemplateType.
		/// </summary>
		/// <param name="type">A TemplateType enum value representing the type of template.</param>
		protected void InitTemplate(TemplateType type)
		{
			if ( _paths != null && _paths.ContainsKey(type) )
			{
				IList typePaths = _paths[type];
				String[] paths = new String[typePaths.Count];

				for ( int i = 0; i < typePaths.Count; i++ )
				{
					paths[i] = ( (TemplatePath) typePaths[i] ).Path;
				}

				MultiBindableTemplate template = new MultiBindableTemplate(this.Page, paths);

				switch ( type )
				{
					case TemplateType.EditItemTemplate:
						EditItemTemplate = template;
						break;
					case TemplateType.EmptyDataTemplate:
						EmptyDataTemplate = template;
						break;
					case TemplateType.FooterTemplate:
						FooterTemplate = template;
						break;
					case TemplateType.HeaderTemplate:
						HeaderTemplate = template;
						break;
					case TemplateType.InsertItemTemplate:
						InsertItemTemplate = template;
						break;
					case TemplateType.PagerTemplate:
						PagerTemplate = template;
						break;
					default:
						ItemTemplate = template;
						break;
				}
			}
		}

		#endregion
	}

	#region TemplatePath Type

	/// <summary>
	/// Holds a path value for the MultiFormView class.
	/// </summary>
	public sealed class TemplatePath
	{
		private String _path;

		/// <summary>
		/// Initializes a new instance of the TemplatePath class.
		/// </summary>
		public TemplatePath()
		{
		}

		/// <summary>
		/// Gets or sets the path to an external template control.
		/// </summary>
		public String Path
		{
			get { return _path; }
			set { _path = value; }
		}
	}

	#endregion
}