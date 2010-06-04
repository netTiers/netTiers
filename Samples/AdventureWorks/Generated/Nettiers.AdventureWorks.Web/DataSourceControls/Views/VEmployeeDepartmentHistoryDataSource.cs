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
	/// Represents the DataRepository.VEmployeeDepartmentHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VEmployeeDepartmentHistoryDataSourceDesigner))]
	public class VEmployeeDepartmentHistoryDataSource : ReadOnlyDataSource<VEmployeeDepartmentHistory>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryDataSource class.
		/// </summary>
		public VEmployeeDepartmentHistoryDataSource() : base(new VEmployeeDepartmentHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VEmployeeDepartmentHistoryDataSourceView used by the VEmployeeDepartmentHistoryDataSource.
		/// </summary>
		protected VEmployeeDepartmentHistoryDataSourceView VEmployeeDepartmentHistoryView
		{
			get { return ( View as VEmployeeDepartmentHistoryDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VEmployeeDepartmentHistoryDataSourceView class that is to be
		/// used by the VEmployeeDepartmentHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the VEmployeeDepartmentHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<VEmployeeDepartmentHistory, Object> GetNewDataSourceView()
		{
			return new VEmployeeDepartmentHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the VEmployeeDepartmentHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VEmployeeDepartmentHistoryDataSourceView : ReadOnlyDataSourceView<VEmployeeDepartmentHistory>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VEmployeeDepartmentHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VEmployeeDepartmentHistoryDataSourceView(VEmployeeDepartmentHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VEmployeeDepartmentHistoryDataSource VEmployeeDepartmentHistoryOwner
		{
			get { return Owner as VEmployeeDepartmentHistoryDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VEmployeeDepartmentHistoryService VEmployeeDepartmentHistoryProvider
		{
			get { return Provider as VEmployeeDepartmentHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VEmployeeDepartmentHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VEmployeeDepartmentHistoryDataSource class.
	/// </summary>
	public class VEmployeeDepartmentHistoryDataSourceDesigner : ReadOnlyDataSourceDesigner<VEmployeeDepartmentHistory>
	{
	}

	#endregion VEmployeeDepartmentHistoryDataSourceDesigner

	#region VEmployeeDepartmentHistoryFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentHistoryFilter : SqlFilter<VEmployeeDepartmentHistoryColumn>
	{
	}

	#endregion VEmployeeDepartmentHistoryFilter

	#region VEmployeeDepartmentHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentHistoryExpressionBuilder : SqlExpressionBuilder<VEmployeeDepartmentHistoryColumn>
	{
	}
	
	#endregion VEmployeeDepartmentHistoryExpressionBuilder		
}

