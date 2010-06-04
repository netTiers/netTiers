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
	/// Represents the DataRepository.VJobCandidateEducationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VJobCandidateEducationDataSourceDesigner))]
	public class VJobCandidateEducationDataSource : ReadOnlyDataSource<VJobCandidateEducation>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationDataSource class.
		/// </summary>
		public VJobCandidateEducationDataSource() : base(new VJobCandidateEducationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VJobCandidateEducationDataSourceView used by the VJobCandidateEducationDataSource.
		/// </summary>
		protected VJobCandidateEducationDataSourceView VJobCandidateEducationView
		{
			get { return ( View as VJobCandidateEducationDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VJobCandidateEducationDataSourceView class that is to be
		/// used by the VJobCandidateEducationDataSource.
		/// </summary>
		/// <returns>An instance of the VJobCandidateEducationDataSourceView class.</returns>
		protected override BaseDataSourceView<VJobCandidateEducation, Object> GetNewDataSourceView()
		{
			return new VJobCandidateEducationDataSourceView(this, DefaultViewName);
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
	/// Supports the VJobCandidateEducationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VJobCandidateEducationDataSourceView : ReadOnlyDataSourceView<VJobCandidateEducation>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VJobCandidateEducationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VJobCandidateEducationDataSourceView(VJobCandidateEducationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VJobCandidateEducationDataSource VJobCandidateEducationOwner
		{
			get { return Owner as VJobCandidateEducationDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VJobCandidateEducationService VJobCandidateEducationProvider
		{
			get { return Provider as VJobCandidateEducationService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VJobCandidateEducationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VJobCandidateEducationDataSource class.
	/// </summary>
	public class VJobCandidateEducationDataSourceDesigner : ReadOnlyDataSourceDesigner<VJobCandidateEducation>
	{
	}

	#endregion VJobCandidateEducationDataSourceDesigner

	#region VJobCandidateEducationFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEducationFilter : SqlFilter<VJobCandidateEducationColumn>
	{
	}

	#endregion VJobCandidateEducationFilter

	#region VJobCandidateEducationExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEducationExpressionBuilder : SqlExpressionBuilder<VJobCandidateEducationColumn>
	{
	}
	
	#endregion VJobCandidateEducationExpressionBuilder		
}

