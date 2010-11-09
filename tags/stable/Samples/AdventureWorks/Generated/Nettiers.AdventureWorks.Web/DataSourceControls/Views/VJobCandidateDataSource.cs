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
	/// Represents the DataRepository.VJobCandidateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VJobCandidateDataSourceDesigner))]
	public class VJobCandidateDataSource : ReadOnlyDataSource<VJobCandidate>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateDataSource class.
		/// </summary>
		public VJobCandidateDataSource() : base(new VJobCandidateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VJobCandidateDataSourceView used by the VJobCandidateDataSource.
		/// </summary>
		protected VJobCandidateDataSourceView VJobCandidateView
		{
			get { return ( View as VJobCandidateDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VJobCandidateDataSourceView class that is to be
		/// used by the VJobCandidateDataSource.
		/// </summary>
		/// <returns>An instance of the VJobCandidateDataSourceView class.</returns>
		protected override BaseDataSourceView<VJobCandidate, Object> GetNewDataSourceView()
		{
			return new VJobCandidateDataSourceView(this, DefaultViewName);
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
	/// Supports the VJobCandidateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VJobCandidateDataSourceView : ReadOnlyDataSourceView<VJobCandidate>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VJobCandidateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VJobCandidateDataSourceView(VJobCandidateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VJobCandidateDataSource VJobCandidateOwner
		{
			get { return Owner as VJobCandidateDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VJobCandidateService VJobCandidateProvider
		{
			get { return Provider as VJobCandidateService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VJobCandidateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VJobCandidateDataSource class.
	/// </summary>
	public class VJobCandidateDataSourceDesigner : ReadOnlyDataSourceDesigner<VJobCandidate>
	{
	}

	#endregion VJobCandidateDataSourceDesigner

	#region VJobCandidateFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateFilter : SqlFilter<VJobCandidateColumn>
	{
	}

	#endregion VJobCandidateFilter

	#region VJobCandidateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateExpressionBuilder : SqlExpressionBuilder<VJobCandidateColumn>
	{
	}
	
	#endregion VJobCandidateExpressionBuilder		
}

