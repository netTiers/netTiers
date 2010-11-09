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
	/// Represents the DataRepository.VSalesPersonSalesByFiscalYearsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VSalesPersonSalesByFiscalYearsDataSourceDesigner))]
	public class VSalesPersonSalesByFiscalYearsDataSource : ReadOnlyDataSource<VSalesPersonSalesByFiscalYears>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsDataSource class.
		/// </summary>
		public VSalesPersonSalesByFiscalYearsDataSource() : base(new VSalesPersonSalesByFiscalYearsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VSalesPersonSalesByFiscalYearsDataSourceView used by the VSalesPersonSalesByFiscalYearsDataSource.
		/// </summary>
		protected VSalesPersonSalesByFiscalYearsDataSourceView VSalesPersonSalesByFiscalYearsView
		{
			get { return ( View as VSalesPersonSalesByFiscalYearsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VSalesPersonSalesByFiscalYearsDataSourceView class that is to be
		/// used by the VSalesPersonSalesByFiscalYearsDataSource.
		/// </summary>
		/// <returns>An instance of the VSalesPersonSalesByFiscalYearsDataSourceView class.</returns>
		protected override BaseDataSourceView<VSalesPersonSalesByFiscalYears, Object> GetNewDataSourceView()
		{
			return new VSalesPersonSalesByFiscalYearsDataSourceView(this, DefaultViewName);
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
	/// Supports the VSalesPersonSalesByFiscalYearsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VSalesPersonSalesByFiscalYearsDataSourceView : ReadOnlyDataSourceView<VSalesPersonSalesByFiscalYears>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VSalesPersonSalesByFiscalYearsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VSalesPersonSalesByFiscalYearsDataSourceView(VSalesPersonSalesByFiscalYearsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VSalesPersonSalesByFiscalYearsDataSource VSalesPersonSalesByFiscalYearsOwner
		{
			get { return Owner as VSalesPersonSalesByFiscalYearsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VSalesPersonSalesByFiscalYearsService VSalesPersonSalesByFiscalYearsProvider
		{
			get { return Provider as VSalesPersonSalesByFiscalYearsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VSalesPersonSalesByFiscalYearsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VSalesPersonSalesByFiscalYearsDataSource class.
	/// </summary>
	public class VSalesPersonSalesByFiscalYearsDataSourceDesigner : ReadOnlyDataSourceDesigner<VSalesPersonSalesByFiscalYears>
	{
	}

	#endregion VSalesPersonSalesByFiscalYearsDataSourceDesigner

	#region VSalesPersonSalesByFiscalYearsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPersonSalesByFiscalYears"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonSalesByFiscalYearsFilter : SqlFilter<VSalesPersonSalesByFiscalYearsColumn>
	{
	}

	#endregion VSalesPersonSalesByFiscalYearsFilter

	#region VSalesPersonSalesByFiscalYearsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPersonSalesByFiscalYears"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonSalesByFiscalYearsExpressionBuilder : SqlExpressionBuilder<VSalesPersonSalesByFiscalYearsColumn>
	{
	}
	
	#endregion VSalesPersonSalesByFiscalYearsExpressionBuilder		
}

