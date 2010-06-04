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
	/// Represents the DataRepository.VIndividualCustomerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VIndividualCustomerDataSourceDesigner))]
	public class VIndividualCustomerDataSource : ReadOnlyDataSource<VIndividualCustomer>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerDataSource class.
		/// </summary>
		public VIndividualCustomerDataSource() : base(new VIndividualCustomerService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VIndividualCustomerDataSourceView used by the VIndividualCustomerDataSource.
		/// </summary>
		protected VIndividualCustomerDataSourceView VIndividualCustomerView
		{
			get { return ( View as VIndividualCustomerDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VIndividualCustomerDataSourceView class that is to be
		/// used by the VIndividualCustomerDataSource.
		/// </summary>
		/// <returns>An instance of the VIndividualCustomerDataSourceView class.</returns>
		protected override BaseDataSourceView<VIndividualCustomer, Object> GetNewDataSourceView()
		{
			return new VIndividualCustomerDataSourceView(this, DefaultViewName);
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
	/// Supports the VIndividualCustomerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VIndividualCustomerDataSourceView : ReadOnlyDataSourceView<VIndividualCustomer>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VIndividualCustomerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VIndividualCustomerDataSourceView(VIndividualCustomerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VIndividualCustomerDataSource VIndividualCustomerOwner
		{
			get { return Owner as VIndividualCustomerDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VIndividualCustomerService VIndividualCustomerProvider
		{
			get { return Provider as VIndividualCustomerService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VIndividualCustomerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VIndividualCustomerDataSource class.
	/// </summary>
	public class VIndividualCustomerDataSourceDesigner : ReadOnlyDataSourceDesigner<VIndividualCustomer>
	{
	}

	#endregion VIndividualCustomerDataSourceDesigner

	#region VIndividualCustomerFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualCustomerFilter : SqlFilter<VIndividualCustomerColumn>
	{
	}

	#endregion VIndividualCustomerFilter

	#region VIndividualCustomerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualCustomerExpressionBuilder : SqlExpressionBuilder<VIndividualCustomerColumn>
	{
	}
	
	#endregion VIndividualCustomerExpressionBuilder		
}

