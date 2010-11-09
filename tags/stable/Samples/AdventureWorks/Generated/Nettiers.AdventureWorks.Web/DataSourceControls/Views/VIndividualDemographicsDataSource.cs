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
	/// Represents the DataRepository.VIndividualDemographicsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VIndividualDemographicsDataSourceDesigner))]
	public class VIndividualDemographicsDataSource : ReadOnlyDataSource<VIndividualDemographics>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsDataSource class.
		/// </summary>
		public VIndividualDemographicsDataSource() : base(new VIndividualDemographicsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VIndividualDemographicsDataSourceView used by the VIndividualDemographicsDataSource.
		/// </summary>
		protected VIndividualDemographicsDataSourceView VIndividualDemographicsView
		{
			get { return ( View as VIndividualDemographicsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VIndividualDemographicsDataSourceView class that is to be
		/// used by the VIndividualDemographicsDataSource.
		/// </summary>
		/// <returns>An instance of the VIndividualDemographicsDataSourceView class.</returns>
		protected override BaseDataSourceView<VIndividualDemographics, Object> GetNewDataSourceView()
		{
			return new VIndividualDemographicsDataSourceView(this, DefaultViewName);
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
	/// Supports the VIndividualDemographicsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VIndividualDemographicsDataSourceView : ReadOnlyDataSourceView<VIndividualDemographics>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VIndividualDemographicsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VIndividualDemographicsDataSourceView(VIndividualDemographicsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VIndividualDemographicsDataSource VIndividualDemographicsOwner
		{
			get { return Owner as VIndividualDemographicsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VIndividualDemographicsService VIndividualDemographicsProvider
		{
			get { return Provider as VIndividualDemographicsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VIndividualDemographicsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VIndividualDemographicsDataSource class.
	/// </summary>
	public class VIndividualDemographicsDataSourceDesigner : ReadOnlyDataSourceDesigner<VIndividualDemographics>
	{
	}

	#endregion VIndividualDemographicsDataSourceDesigner

	#region VIndividualDemographicsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualDemographicsFilter : SqlFilter<VIndividualDemographicsColumn>
	{
	}

	#endregion VIndividualDemographicsFilter

	#region VIndividualDemographicsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualDemographicsExpressionBuilder : SqlExpressionBuilder<VIndividualDemographicsColumn>
	{
	}
	
	#endregion VIndividualDemographicsExpressionBuilder		
}

