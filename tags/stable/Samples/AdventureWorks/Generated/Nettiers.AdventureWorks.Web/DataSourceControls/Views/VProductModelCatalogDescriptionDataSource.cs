#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;
using Nettiers.AdventureWorks.Services;
#endregion

namespace Nettiers.AdventureWorks.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.VProductModelCatalogDescriptionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VProductModelCatalogDescriptionDataSourceDesigner))]
	public class VProductModelCatalogDescriptionDataSource : ReadOnlyDataSource<VProductModelCatalogDescription>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionDataSource class.
		/// </summary>
		public VProductModelCatalogDescriptionDataSource() : base(new VProductModelCatalogDescriptionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VProductModelCatalogDescriptionDataSourceView used by the VProductModelCatalogDescriptionDataSource.
		/// </summary>
		protected VProductModelCatalogDescriptionDataSourceView VProductModelCatalogDescriptionView
		{
			get { return ( View as VProductModelCatalogDescriptionDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VProductModelCatalogDescriptionDataSourceView class that is to be
		/// used by the VProductModelCatalogDescriptionDataSource.
		/// </summary>
		/// <returns>An instance of the VProductModelCatalogDescriptionDataSourceView class.</returns>
		protected override BaseDataSourceView<VProductModelCatalogDescription, Object> GetNewDataSourceView()
		{
			return new VProductModelCatalogDescriptionDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the VProductModelCatalogDescriptionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VProductModelCatalogDescriptionDataSourceView : ReadOnlyDataSourceView<VProductModelCatalogDescription>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VProductModelCatalogDescriptionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VProductModelCatalogDescriptionDataSourceView(VProductModelCatalogDescriptionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VProductModelCatalogDescriptionDataSource VProductModelCatalogDescriptionOwner
		{
			get { return Owner as VProductModelCatalogDescriptionDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VProductModelCatalogDescriptionService VProductModelCatalogDescriptionProvider
		{
			get { return Provider as VProductModelCatalogDescriptionService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VProductModelCatalogDescriptionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VProductModelCatalogDescriptionDataSource class.
	/// </summary>
	public class VProductModelCatalogDescriptionDataSourceDesigner : ReadOnlyDataSourceDesigner<VProductModelCatalogDescription>
	{
	}

	#endregion VProductModelCatalogDescriptionDataSourceDesigner

	#region VProductModelCatalogDescriptionFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelCatalogDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelCatalogDescriptionFilter : SqlFilter<VProductModelCatalogDescriptionColumn>
	{
	}

	#endregion VProductModelCatalogDescriptionFilter

	#region VProductModelCatalogDescriptionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelCatalogDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelCatalogDescriptionExpressionBuilder : SqlExpressionBuilder<VProductModelCatalogDescriptionColumn>
	{
	}
	
	#endregion VProductModelCatalogDescriptionExpressionBuilder		
}

