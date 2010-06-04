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
	/// Represents the DataRepository.VStateProvinceCountryRegionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VStateProvinceCountryRegionDataSourceDesigner))]
	public class VStateProvinceCountryRegionDataSource : ReadOnlyDataSource<VStateProvinceCountryRegion>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionDataSource class.
		/// </summary>
		public VStateProvinceCountryRegionDataSource() : base(new VStateProvinceCountryRegionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VStateProvinceCountryRegionDataSourceView used by the VStateProvinceCountryRegionDataSource.
		/// </summary>
		protected VStateProvinceCountryRegionDataSourceView VStateProvinceCountryRegionView
		{
			get { return ( View as VStateProvinceCountryRegionDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VStateProvinceCountryRegionDataSourceView class that is to be
		/// used by the VStateProvinceCountryRegionDataSource.
		/// </summary>
		/// <returns>An instance of the VStateProvinceCountryRegionDataSourceView class.</returns>
		protected override BaseDataSourceView<VStateProvinceCountryRegion, Object> GetNewDataSourceView()
		{
			return new VStateProvinceCountryRegionDataSourceView(this, DefaultViewName);
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
	/// Supports the VStateProvinceCountryRegionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VStateProvinceCountryRegionDataSourceView : ReadOnlyDataSourceView<VStateProvinceCountryRegion>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VStateProvinceCountryRegionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VStateProvinceCountryRegionDataSourceView(VStateProvinceCountryRegionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VStateProvinceCountryRegionDataSource VStateProvinceCountryRegionOwner
		{
			get { return Owner as VStateProvinceCountryRegionDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VStateProvinceCountryRegionService VStateProvinceCountryRegionProvider
		{
			get { return Provider as VStateProvinceCountryRegionService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VStateProvinceCountryRegionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VStateProvinceCountryRegionDataSource class.
	/// </summary>
	public class VStateProvinceCountryRegionDataSourceDesigner : ReadOnlyDataSourceDesigner<VStateProvinceCountryRegion>
	{
	}

	#endregion VStateProvinceCountryRegionDataSourceDesigner

	#region VStateProvinceCountryRegionFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStateProvinceCountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStateProvinceCountryRegionFilter : SqlFilter<VStateProvinceCountryRegionColumn>
	{
	}

	#endregion VStateProvinceCountryRegionFilter

	#region VStateProvinceCountryRegionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStateProvinceCountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStateProvinceCountryRegionExpressionBuilder : SqlExpressionBuilder<VStateProvinceCountryRegionColumn>
	{
	}
	
	#endregion VStateProvinceCountryRegionExpressionBuilder		
}

