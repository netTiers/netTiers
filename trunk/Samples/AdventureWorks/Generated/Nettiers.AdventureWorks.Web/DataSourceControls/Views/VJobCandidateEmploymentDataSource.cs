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
	/// Represents the DataRepository.VJobCandidateEmploymentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VJobCandidateEmploymentDataSourceDesigner))]
	public class VJobCandidateEmploymentDataSource : ReadOnlyDataSource<VJobCandidateEmployment>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentDataSource class.
		/// </summary>
		public VJobCandidateEmploymentDataSource() : base(new VJobCandidateEmploymentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VJobCandidateEmploymentDataSourceView used by the VJobCandidateEmploymentDataSource.
		/// </summary>
		protected VJobCandidateEmploymentDataSourceView VJobCandidateEmploymentView
		{
			get { return ( View as VJobCandidateEmploymentDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VJobCandidateEmploymentDataSourceView class that is to be
		/// used by the VJobCandidateEmploymentDataSource.
		/// </summary>
		/// <returns>An instance of the VJobCandidateEmploymentDataSourceView class.</returns>
		protected override BaseDataSourceView<VJobCandidateEmployment, Object> GetNewDataSourceView()
		{
			return new VJobCandidateEmploymentDataSourceView(this, DefaultViewName);
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
	/// Supports the VJobCandidateEmploymentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VJobCandidateEmploymentDataSourceView : ReadOnlyDataSourceView<VJobCandidateEmployment>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VJobCandidateEmploymentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VJobCandidateEmploymentDataSourceView(VJobCandidateEmploymentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VJobCandidateEmploymentDataSource VJobCandidateEmploymentOwner
		{
			get { return Owner as VJobCandidateEmploymentDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VJobCandidateEmploymentService VJobCandidateEmploymentProvider
		{
			get { return Provider as VJobCandidateEmploymentService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VJobCandidateEmploymentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VJobCandidateEmploymentDataSource class.
	/// </summary>
	public class VJobCandidateEmploymentDataSourceDesigner : ReadOnlyDataSourceDesigner<VJobCandidateEmployment>
	{
	}

	#endregion VJobCandidateEmploymentDataSourceDesigner

	#region VJobCandidateEmploymentFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEmployment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEmploymentFilter : SqlFilter<VJobCandidateEmploymentColumn>
	{
	}

	#endregion VJobCandidateEmploymentFilter

	#region VJobCandidateEmploymentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEmployment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEmploymentExpressionBuilder : SqlExpressionBuilder<VJobCandidateEmploymentColumn>
	{
	}
	
	#endregion VJobCandidateEmploymentExpressionBuilder		
}

