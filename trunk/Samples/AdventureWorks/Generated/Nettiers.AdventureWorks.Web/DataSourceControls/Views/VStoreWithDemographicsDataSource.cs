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
	/// Represents the DataRepository.VStoreWithDemographicsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VStoreWithDemographicsDataSourceDesigner))]
	public class VStoreWithDemographicsDataSource : ReadOnlyDataSource<VStoreWithDemographics>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsDataSource class.
		/// </summary>
		public VStoreWithDemographicsDataSource() : base(new VStoreWithDemographicsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VStoreWithDemographicsDataSourceView used by the VStoreWithDemographicsDataSource.
		/// </summary>
		protected VStoreWithDemographicsDataSourceView VStoreWithDemographicsView
		{
			get { return ( View as VStoreWithDemographicsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VStoreWithDemographicsDataSourceView class that is to be
		/// used by the VStoreWithDemographicsDataSource.
		/// </summary>
		/// <returns>An instance of the VStoreWithDemographicsDataSourceView class.</returns>
		protected override BaseDataSourceView<VStoreWithDemographics, Object> GetNewDataSourceView()
		{
			return new VStoreWithDemographicsDataSourceView(this, DefaultViewName);
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
	/// Supports the VStoreWithDemographicsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VStoreWithDemographicsDataSourceView : ReadOnlyDataSourceView<VStoreWithDemographics>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VStoreWithDemographicsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VStoreWithDemographicsDataSourceView(VStoreWithDemographicsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VStoreWithDemographicsDataSource VStoreWithDemographicsOwner
		{
			get { return Owner as VStoreWithDemographicsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VStoreWithDemographicsService VStoreWithDemographicsProvider
		{
			get { return Provider as VStoreWithDemographicsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VStoreWithDemographicsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VStoreWithDemographicsDataSource class.
	/// </summary>
	public class VStoreWithDemographicsDataSourceDesigner : ReadOnlyDataSourceDesigner<VStoreWithDemographics>
	{
	}

	#endregion VStoreWithDemographicsDataSourceDesigner

	#region VStoreWithDemographicsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStoreWithDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStoreWithDemographicsFilter : SqlFilter<VStoreWithDemographicsColumn>
	{
	}

	#endregion VStoreWithDemographicsFilter

	#region VStoreWithDemographicsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStoreWithDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStoreWithDemographicsExpressionBuilder : SqlExpressionBuilder<VStoreWithDemographicsColumn>
	{
	}
	
	#endregion VStoreWithDemographicsExpressionBuilder		
}

