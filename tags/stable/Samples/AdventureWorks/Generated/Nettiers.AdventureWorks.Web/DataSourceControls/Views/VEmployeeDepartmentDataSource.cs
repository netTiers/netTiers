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
	/// Represents the DataRepository.VEmployeeDepartmentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VEmployeeDepartmentDataSourceDesigner))]
	public class VEmployeeDepartmentDataSource : ReadOnlyDataSource<VEmployeeDepartment>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentDataSource class.
		/// </summary>
		public VEmployeeDepartmentDataSource() : base(new VEmployeeDepartmentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VEmployeeDepartmentDataSourceView used by the VEmployeeDepartmentDataSource.
		/// </summary>
		protected VEmployeeDepartmentDataSourceView VEmployeeDepartmentView
		{
			get { return ( View as VEmployeeDepartmentDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VEmployeeDepartmentDataSourceView class that is to be
		/// used by the VEmployeeDepartmentDataSource.
		/// </summary>
		/// <returns>An instance of the VEmployeeDepartmentDataSourceView class.</returns>
		protected override BaseDataSourceView<VEmployeeDepartment, Object> GetNewDataSourceView()
		{
			return new VEmployeeDepartmentDataSourceView(this, DefaultViewName);
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
	/// Supports the VEmployeeDepartmentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VEmployeeDepartmentDataSourceView : ReadOnlyDataSourceView<VEmployeeDepartment>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VEmployeeDepartmentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VEmployeeDepartmentDataSourceView(VEmployeeDepartmentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VEmployeeDepartmentDataSource VEmployeeDepartmentOwner
		{
			get { return Owner as VEmployeeDepartmentDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VEmployeeDepartmentService VEmployeeDepartmentProvider
		{
			get { return Provider as VEmployeeDepartmentService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VEmployeeDepartmentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VEmployeeDepartmentDataSource class.
	/// </summary>
	public class VEmployeeDepartmentDataSourceDesigner : ReadOnlyDataSourceDesigner<VEmployeeDepartment>
	{
	}

	#endregion VEmployeeDepartmentDataSourceDesigner

	#region VEmployeeDepartmentFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentFilter : SqlFilter<VEmployeeDepartmentColumn>
	{
	}

	#endregion VEmployeeDepartmentFilter

	#region VEmployeeDepartmentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentExpressionBuilder : SqlExpressionBuilder<VEmployeeDepartmentColumn>
	{
	}
	
	#endregion VEmployeeDepartmentExpressionBuilder		
}

