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
	/// Represents the DataRepository.VEmployeeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VEmployeeDataSourceDesigner))]
	public class VEmployeeDataSource : ReadOnlyDataSource<VEmployee>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDataSource class.
		/// </summary>
		public VEmployeeDataSource() : base(new VEmployeeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VEmployeeDataSourceView used by the VEmployeeDataSource.
		/// </summary>
		protected VEmployeeDataSourceView VEmployeeView
		{
			get { return ( View as VEmployeeDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VEmployeeDataSourceView class that is to be
		/// used by the VEmployeeDataSource.
		/// </summary>
		/// <returns>An instance of the VEmployeeDataSourceView class.</returns>
		protected override BaseDataSourceView<VEmployee, Object> GetNewDataSourceView()
		{
			return new VEmployeeDataSourceView(this, DefaultViewName);
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
	/// Supports the VEmployeeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VEmployeeDataSourceView : ReadOnlyDataSourceView<VEmployee>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VEmployeeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VEmployeeDataSourceView(VEmployeeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VEmployeeDataSource VEmployeeOwner
		{
			get { return Owner as VEmployeeDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VEmployeeService VEmployeeProvider
		{
			get { return Provider as VEmployeeService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VEmployeeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VEmployeeDataSource class.
	/// </summary>
	public class VEmployeeDataSourceDesigner : ReadOnlyDataSourceDesigner<VEmployee>
	{
	}

	#endregion VEmployeeDataSourceDesigner

	#region VEmployeeFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeFilter : SqlFilter<VEmployeeColumn>
	{
	}

	#endregion VEmployeeFilter

	#region VEmployeeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeExpressionBuilder : SqlExpressionBuilder<VEmployeeColumn>
	{
	}
	
	#endregion VEmployeeExpressionBuilder		
}

