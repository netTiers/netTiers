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
	/// Represents the DataRepository.VVendorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VVendorDataSourceDesigner))]
	public class VVendorDataSource : ReadOnlyDataSource<VVendor>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VVendorDataSource class.
		/// </summary>
		public VVendorDataSource() : base(new VVendorService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VVendorDataSourceView used by the VVendorDataSource.
		/// </summary>
		protected VVendorDataSourceView VVendorView
		{
			get { return ( View as VVendorDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VVendorDataSourceView class that is to be
		/// used by the VVendorDataSource.
		/// </summary>
		/// <returns>An instance of the VVendorDataSourceView class.</returns>
		protected override BaseDataSourceView<VVendor, Object> GetNewDataSourceView()
		{
			return new VVendorDataSourceView(this, DefaultViewName);
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
	/// Supports the VVendorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VVendorDataSourceView : ReadOnlyDataSourceView<VVendor>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VVendorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VVendorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VVendorDataSourceView(VVendorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VVendorDataSource VVendorOwner
		{
			get { return Owner as VVendorDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VVendorService VVendorProvider
		{
			get { return Provider as VVendorService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VVendorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VVendorDataSource class.
	/// </summary>
	public class VVendorDataSourceDesigner : ReadOnlyDataSourceDesigner<VVendor>
	{
	}

	#endregion VVendorDataSourceDesigner

	#region VVendorFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VVendorFilter : SqlFilter<VVendorColumn>
	{
	}

	#endregion VVendorFilter

	#region VVendorExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VVendorExpressionBuilder : SqlExpressionBuilder<VVendorColumn>
	{
	}
	
	#endregion VVendorExpressionBuilder		
}

