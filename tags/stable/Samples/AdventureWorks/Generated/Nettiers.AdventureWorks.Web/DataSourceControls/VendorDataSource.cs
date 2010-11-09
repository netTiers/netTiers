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
	/// Represents the DataRepository.VendorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(VendorDataSourceDesigner))]
	public class VendorDataSource : ProviderDataSource<Vendor, VendorKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorDataSource class.
		/// </summary>
		public VendorDataSource() : base(new VendorService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VendorDataSourceView used by the VendorDataSource.
		/// </summary>
		protected VendorDataSourceView VendorView
		{
			get { return ( View as VendorDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the VendorDataSource control invokes to retrieve data.
		/// </summary>
		public VendorSelectMethod SelectMethod
		{
			get
			{
				VendorSelectMethod selectMethod = VendorSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (VendorSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VendorDataSourceView class that is to be
		/// used by the VendorDataSource.
		/// </summary>
		/// <returns>An instance of the VendorDataSourceView class.</returns>
		protected override BaseDataSourceView<Vendor, VendorKey> GetNewDataSourceView()
		{
			return new VendorDataSourceView(this, DefaultViewName);
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
	/// Supports the VendorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VendorDataSourceView : ProviderDataSourceView<Vendor, VendorKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VendorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VendorDataSourceView(VendorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VendorDataSource VendorOwner
		{
			get { return Owner as VendorDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal VendorSelectMethod SelectMethod
		{
			get { return VendorOwner.SelectMethod; }
			set { VendorOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VendorService VendorProvider
		{
			get { return Provider as VendorService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Vendor> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Vendor> results = null;
			Vendor item;
			count = 0;
			
			System.String _accountNumber;
			System.Int32 _vendorId;
			System.Int32 _productId;
			System.Int32 _addressId;
			System.Int32 _contactId;

			switch ( SelectMethod )
			{
				case VendorSelectMethod.Get:
					VendorKey entityKey  = new VendorKey();
					entityKey.Load(values);
					item = VendorProvider.Get(entityKey);
					results = new TList<Vendor>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case VendorSelectMethod.GetAll:
                    results = VendorProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case VendorSelectMethod.GetPaged:
					results = VendorProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case VendorSelectMethod.Find:
					if ( FilterParameters != null )
						results = VendorProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = VendorProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case VendorSelectMethod.GetByVendorId:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					item = VendorProvider.GetByVendorId(_vendorId);
					results = new TList<Vendor>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case VendorSelectMethod.GetByAccountNumber:
					_accountNumber = ( values["AccountNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["AccountNumber"], typeof(System.String)) : string.Empty;
					item = VendorProvider.GetByAccountNumber(_accountNumber);
					results = new TList<Vendor>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case VendorSelectMethod.GetByProductIdFromProductVendor:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = VendorProvider.GetByProductIdFromProductVendor(_productId, this.StartIndex, this.PageSize, out count);
					break;
				case VendorSelectMethod.GetByAddressIdFromVendorAddress:
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					results = VendorProvider.GetByAddressIdFromVendorAddress(_addressId, this.StartIndex, this.PageSize, out count);
					break;
				case VendorSelectMethod.GetByContactIdFromVendorContact:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					results = VendorProvider.GetByContactIdFromVendorContact(_contactId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == VendorSelectMethod.Get || SelectMethod == VendorSelectMethod.GetByVendorId )
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
				Vendor entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					VendorProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Vendor> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			VendorProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region VendorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VendorDataSource class.
	/// </summary>
	public class VendorDataSourceDesigner : ProviderDataSourceDesigner<Vendor, VendorKey>
	{
		/// <summary>
		/// Initializes a new instance of the VendorDataSourceDesigner class.
		/// </summary>
		public VendorDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VendorSelectMethod SelectMethod
		{
			get { return ((VendorDataSource) DataSource).SelectMethod; }
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
				actions.Add(new VendorDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region VendorDataSourceActionList

	/// <summary>
	/// Supports the VendorDataSourceDesigner class.
	/// </summary>
	internal class VendorDataSourceActionList : DesignerActionList
	{
		private VendorDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the VendorDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public VendorDataSourceActionList(VendorDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VendorSelectMethod SelectMethod
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

	#endregion VendorDataSourceActionList
	
	#endregion VendorDataSourceDesigner
	
	#region VendorSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the VendorDataSource.SelectMethod property.
	/// </summary>
	public enum VendorSelectMethod
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
		/// Represents the GetByAccountNumber method.
		/// </summary>
		GetByAccountNumber,
		/// <summary>
		/// Represents the GetByVendorId method.
		/// </summary>
		GetByVendorId,
		/// <summary>
		/// Represents the GetByProductIdFromProductVendor method.
		/// </summary>
		GetByProductIdFromProductVendor,
		/// <summary>
		/// Represents the GetByAddressIdFromVendorAddress method.
		/// </summary>
		GetByAddressIdFromVendorAddress,
		/// <summary>
		/// Represents the GetByContactIdFromVendorContact method.
		/// </summary>
		GetByContactIdFromVendorContact
	}
	
	#endregion VendorSelectMethod

	#region VendorFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorFilter : SqlFilter<VendorColumn>
	{
	}
	
	#endregion VendorFilter

	#region VendorExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorExpressionBuilder : SqlExpressionBuilder<VendorColumn>
	{
	}
	
	#endregion VendorExpressionBuilder	

	#region VendorProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;VendorChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Vendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorProperty : ChildEntityProperty<VendorChildEntityTypes>
	{
	}
	
	#endregion VendorProperty
}

