#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;
using Nettiers.AdventureWorks.Services;
#endregion

namespace Nettiers.AdventureWorks.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.VendorAddressProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(VendorAddressDataSourceDesigner))]
	public class VendorAddressDataSource : ProviderDataSource<VendorAddress, VendorAddressKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorAddressDataSource class.
		/// </summary>
		public VendorAddressDataSource() : base(new VendorAddressService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VendorAddressDataSourceView used by the VendorAddressDataSource.
		/// </summary>
		protected VendorAddressDataSourceView VendorAddressView
		{
			get { return ( View as VendorAddressDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the VendorAddressDataSource control invokes to retrieve data.
		/// </summary>
		public VendorAddressSelectMethod SelectMethod
		{
			get
			{
				VendorAddressSelectMethod selectMethod = VendorAddressSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (VendorAddressSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VendorAddressDataSourceView class that is to be
		/// used by the VendorAddressDataSource.
		/// </summary>
		/// <returns>An instance of the VendorAddressDataSourceView class.</returns>
		protected override BaseDataSourceView<VendorAddress, VendorAddressKey> GetNewDataSourceView()
		{
			return new VendorAddressDataSourceView(this, DefaultViewName);
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
	/// Supports the VendorAddressDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VendorAddressDataSourceView : ProviderDataSourceView<VendorAddress, VendorAddressKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorAddressDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VendorAddressDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VendorAddressDataSourceView(VendorAddressDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VendorAddressDataSource VendorAddressOwner
		{
			get { return Owner as VendorAddressDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal VendorAddressSelectMethod SelectMethod
		{
			get { return VendorAddressOwner.SelectMethod; }
			set { VendorAddressOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VendorAddressService VendorAddressProvider
		{
			get { return Provider as VendorAddressService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<VendorAddress> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<VendorAddress> results = null;
			VendorAddress item;
			count = 0;
			
			System.Int32 _addressId;
			System.Int32 _vendorId;
			System.Int32 _addressTypeId;

			switch ( SelectMethod )
			{
				case VendorAddressSelectMethod.Get:
					VendorAddressKey entityKey  = new VendorAddressKey();
					entityKey.Load(values);
					item = VendorAddressProvider.Get(entityKey);
					results = new TList<VendorAddress>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case VendorAddressSelectMethod.GetAll:
                    results = VendorAddressProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case VendorAddressSelectMethod.GetPaged:
					results = VendorAddressProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case VendorAddressSelectMethod.Find:
					if ( FilterParameters != null )
						results = VendorAddressProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = VendorAddressProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case VendorAddressSelectMethod.GetByVendorIdAddressId:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					item = VendorAddressProvider.GetByVendorIdAddressId(_vendorId, _addressId);
					results = new TList<VendorAddress>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case VendorAddressSelectMethod.GetByAddressId:
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					results = VendorAddressProvider.GetByAddressId(_addressId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case VendorAddressSelectMethod.GetByAddressTypeId:
					_addressTypeId = ( values["AddressTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressTypeId"], typeof(System.Int32)) : (int)0;
					results = VendorAddressProvider.GetByAddressTypeId(_addressTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case VendorAddressSelectMethod.GetByVendorId:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					results = VendorAddressProvider.GetByVendorId(_vendorId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == VendorAddressSelectMethod.Get || SelectMethod == VendorAddressSelectMethod.GetByVendorIdAddressId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				VendorAddress entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					VendorAddressProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<VendorAddress> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			VendorAddressProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region VendorAddressDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VendorAddressDataSource class.
	/// </summary>
	public class VendorAddressDataSourceDesigner : ProviderDataSourceDesigner<VendorAddress, VendorAddressKey>
	{
		/// <summary>
		/// Initializes a new instance of the VendorAddressDataSourceDesigner class.
		/// </summary>
		public VendorAddressDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VendorAddressSelectMethod SelectMethod
		{
			get { return ((VendorAddressDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new VendorAddressDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region VendorAddressDataSourceActionList

	/// <summary>
	/// Supports the VendorAddressDataSourceDesigner class.
	/// </summary>
	internal class VendorAddressDataSourceActionList : DesignerActionList
	{
		private VendorAddressDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the VendorAddressDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public VendorAddressDataSourceActionList(VendorAddressDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VendorAddressSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion VendorAddressDataSourceActionList
	
	#endregion VendorAddressDataSourceDesigner
	
	#region VendorAddressSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the VendorAddressDataSource.SelectMethod property.
	/// </summary>
	public enum VendorAddressSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByAddressId method.
		/// </summary>
		GetByAddressId,
		/// <summary>
		/// Represents the GetByVendorIdAddressId method.
		/// </summary>
		GetByVendorIdAddressId,
		/// <summary>
		/// Represents the GetByAddressTypeId method.
		/// </summary>
		GetByAddressTypeId,
		/// <summary>
		/// Represents the GetByVendorId method.
		/// </summary>
		GetByVendorId
	}
	
	#endregion VendorAddressSelectMethod

	#region VendorAddressFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorAddressFilter : SqlFilter<VendorAddressColumn>
	{
	}
	
	#endregion VendorAddressFilter

	#region VendorAddressExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorAddressExpressionBuilder : SqlExpressionBuilder<VendorAddressColumn>
	{
	}
	
	#endregion VendorAddressExpressionBuilder	

	#region VendorAddressProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;VendorAddressChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="VendorAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorAddressProperty : ChildEntityProperty<VendorAddressChildEntityTypes>
	{
	}
	
	#endregion VendorAddressProperty
}

