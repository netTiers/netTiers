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
	/// Represents the DataRepository.VProductAndDescriptionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VProductAndDescriptionDataSourceDesigner))]
	public class VProductAndDescriptionDataSource : ReadOnlyDataSource<VProductAndDescription>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionDataSource class.
		/// </summary>
		public VProductAndDescriptionDataSource() : base(new VProductAndDescriptionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VProductAndDescriptionDataSourceView used by the VProductAndDescriptionDataSource.
		/// </summary>
		protected VProductAndDescriptionDataSourceView VProductAndDescriptionView
		{
			get { return ( View as VProductAndDescriptionDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VProductAndDescriptionDataSourceView class that is to be
		/// used by the VProductAndDescriptionDataSource.
		/// </summary>
		/// <returns>An instance of the VProductAndDescriptionDataSourceView class.</returns>
		protected override BaseDataSourceView<VProductAndDescription, Object> GetNewDataSourceView()
		{
			return new VProductAndDescriptionDataSourceView(this, DefaultViewName);
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
	/// Supports the VProductAndDescriptionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VProductAndDescriptionDataSourceView : ReadOnlyDataSourceView<VProductAndDescription>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VProductAndDescriptionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VProductAndDescriptionDataSourceView(VProductAndDescriptionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VProductAndDescriptionDataSource VProductAndDescriptionOwner
		{
			get { return Owner as VProductAndDescriptionDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VProductAndDescriptionService VProductAndDescriptionProvider
		{
			get { return Provider as VProductAndDescriptionService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VProductAndDescriptionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VProductAndDescriptionDataSource class.
	/// </summary>
	public class VProductAndDescriptionDataSourceDesigner : ReadOnlyDataSourceDesigner<VProductAndDescription>
	{
	}

	#endregion VProductAndDescriptionDataSourceDesigner

	#region VProductAndDescriptionFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductAndDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductAndDescriptionFilter : SqlFilter<VProductAndDescriptionColumn>
	{
	}

	#endregion VProductAndDescriptionFilter

	#region VProductAndDescriptionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductAndDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductAndDescriptionExpressionBuilder : SqlExpressionBuilder<VProductAndDescriptionColumn>
	{
	}
	
	#endregion VProductAndDescriptionExpressionBuilder		
}

