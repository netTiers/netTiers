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
	/// Represents the DataRepository.VProductModelInstructionsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VProductModelInstructionsDataSourceDesigner))]
	public class VProductModelInstructionsDataSource : ReadOnlyDataSource<VProductModelInstructions>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsDataSource class.
		/// </summary>
		public VProductModelInstructionsDataSource() : base(new VProductModelInstructionsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VProductModelInstructionsDataSourceView used by the VProductModelInstructionsDataSource.
		/// </summary>
		protected VProductModelInstructionsDataSourceView VProductModelInstructionsView
		{
			get { return ( View as VProductModelInstructionsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VProductModelInstructionsDataSourceView class that is to be
		/// used by the VProductModelInstructionsDataSource.
		/// </summary>
		/// <returns>An instance of the VProductModelInstructionsDataSourceView class.</returns>
		protected override BaseDataSourceView<VProductModelInstructions, Object> GetNewDataSourceView()
		{
			return new VProductModelInstructionsDataSourceView(this, DefaultViewName);
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
	/// Supports the VProductModelInstructionsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VProductModelInstructionsDataSourceView : ReadOnlyDataSourceView<VProductModelInstructions>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VProductModelInstructionsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VProductModelInstructionsDataSourceView(VProductModelInstructionsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VProductModelInstructionsDataSource VProductModelInstructionsOwner
		{
			get { return Owner as VProductModelInstructionsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VProductModelInstructionsService VProductModelInstructionsProvider
		{
			get { return Provider as VProductModelInstructionsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VProductModelInstructionsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VProductModelInstructionsDataSource class.
	/// </summary>
	public class VProductModelInstructionsDataSourceDesigner : ReadOnlyDataSourceDesigner<VProductModelInstructions>
	{
	}

	#endregion VProductModelInstructionsDataSourceDesigner

	#region VProductModelInstructionsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelInstructions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelInstructionsFilter : SqlFilter<VProductModelInstructionsColumn>
	{
	}

	#endregion VProductModelInstructionsFilter

	#region VProductModelInstructionsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelInstructions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelInstructionsExpressionBuilder : SqlExpressionBuilder<VProductModelInstructionsColumn>
	{
	}
	
	#endregion VProductModelInstructionsExpressionBuilder		
}

