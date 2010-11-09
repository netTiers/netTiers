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
	/// Represents the DataRepository.VAdditionalContactInfoProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VAdditionalContactInfoDataSourceDesigner))]
	public class VAdditionalContactInfoDataSource : ReadOnlyDataSource<VAdditionalContactInfo>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoDataSource class.
		/// </summary>
		public VAdditionalContactInfoDataSource() : base(new VAdditionalContactInfoService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VAdditionalContactInfoDataSourceView used by the VAdditionalContactInfoDataSource.
		/// </summary>
		protected VAdditionalContactInfoDataSourceView VAdditionalContactInfoView
		{
			get { return ( View as VAdditionalContactInfoDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VAdditionalContactInfoDataSourceView class that is to be
		/// used by the VAdditionalContactInfoDataSource.
		/// </summary>
		/// <returns>An instance of the VAdditionalContactInfoDataSourceView class.</returns>
		protected override BaseDataSourceView<VAdditionalContactInfo, Object> GetNewDataSourceView()
		{
			return new VAdditionalContactInfoDataSourceView(this, DefaultViewName);
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
	/// Supports the VAdditionalContactInfoDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VAdditionalContactInfoDataSourceView : ReadOnlyDataSourceView<VAdditionalContactInfo>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VAdditionalContactInfoDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VAdditionalContactInfoDataSourceView(VAdditionalContactInfoDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VAdditionalContactInfoDataSource VAdditionalContactInfoOwner
		{
			get { return Owner as VAdditionalContactInfoDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VAdditionalContactInfoService VAdditionalContactInfoProvider
		{
			get { return Provider as VAdditionalContactInfoService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VAdditionalContactInfoDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VAdditionalContactInfoDataSource class.
	/// </summary>
	public class VAdditionalContactInfoDataSourceDesigner : ReadOnlyDataSourceDesigner<VAdditionalContactInfo>
	{
	}

	#endregion VAdditionalContactInfoDataSourceDesigner

	#region VAdditionalContactInfoFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VAdditionalContactInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VAdditionalContactInfoFilter : SqlFilter<VAdditionalContactInfoColumn>
	{
	}

	#endregion VAdditionalContactInfoFilter

	#region VAdditionalContactInfoExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VAdditionalContactInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VAdditionalContactInfoExpressionBuilder : SqlExpressionBuilder<VAdditionalContactInfoColumn>
	{
	}
	
	#endregion VAdditionalContactInfoExpressionBuilder		
}

