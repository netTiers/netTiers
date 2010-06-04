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
	/// Represents the DataRepository.VendorContactProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(VendorContactDataSourceDesigner))]
	public class VendorContactDataSource : ProviderDataSource<VendorContact, VendorContactKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorContactDataSource class.
		/// </summary>
		public VendorContactDataSource() : base(new VendorContactService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VendorContactDataSourceView used by the VendorContactDataSource.
		/// </summary>
		protected VendorContactDataSourceView VendorContactView
		{
			get { return ( View as VendorContactDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the VendorContactDataSource control invokes to retrieve data.
		/// </summary>
		public VendorContactSelectMethod SelectMethod
		{
			get
			{
				VendorContactSelectMethod selectMethod = VendorContactSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (VendorContactSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VendorContactDataSourceView class that is to be
		/// used by the VendorContactDataSource.
		/// </summary>
		/// <returns>An instance of the VendorContactDataSourceView class.</returns>
		protected override BaseDataSourceView<VendorContact, VendorContactKey> GetNewDataSourceView()
		{
			return new VendorContactDataSourceView(this, DefaultViewName);
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
	/// Supports the VendorContactDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VendorContactDataSourceView : ProviderDataSourceView<VendorContact, VendorContactKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorContactDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VendorContactDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VendorContactDataSourceView(VendorContactDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VendorContactDataSource VendorContactOwner
		{
			get { return Owner as VendorContactDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal VendorContactSelectMethod SelectMethod
		{
			get { return VendorContactOwner.SelectMethod; }
			set { VendorContactOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VendorContactService VendorContactProvider
		{
			get { return Provider as VendorContactService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<VendorContact> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<VendorContact> results = null;
			VendorContact item;
			count = 0;
			
			System.Int32 _contactId;
			System.Int32 _contactTypeId;
			System.Int32 _vendorId;

			switch ( SelectMethod )
			{
				case VendorContactSelectMethod.Get:
					VendorContactKey entityKey  = new VendorContactKey();
					entityKey.Load(values);
					item = VendorContactProvider.Get(entityKey);
					results = new TList<VendorContact>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case VendorContactSelectMethod.GetAll:
                    results = VendorContactProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case VendorContactSelectMethod.GetPaged:
					results = VendorContactProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case VendorContactSelectMethod.Find:
					if ( FilterParameters != null )
						results = VendorContactProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = VendorContactProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case VendorContactSelectMethod.GetByVendorIdContactId:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					item = VendorContactProvider.GetByVendorIdContactId(_vendorId, _contactId);
					results = new TList<VendorContact>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case VendorContactSelectMethod.GetByContactId:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					results = VendorContactProvider.GetByContactId(_contactId, this.StartIndex, this.PageSize, out count);
					break;
				case VendorContactSelectMethod.GetByContactTypeId:
					_contactTypeId = ( values["ContactTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactTypeId"], typeof(System.Int32)) : (int)0;
					results = VendorContactProvider.GetByContactTypeId(_contactTypeId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case VendorContactSelectMethod.GetByVendorId:
					_vendorId = ( values["VendorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["VendorId"], typeof(System.Int32)) : (int)0;
					results = VendorContactProvider.GetByVendorId(_vendorId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == VendorContactSelectMethod.Get || SelectMethod == VendorContactSelectMethod.GetByVendorIdContactId )
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
				VendorContact entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					VendorContactProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<VendorContact> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			VendorContactProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region VendorContactDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VendorContactDataSource class.
	/// </summary>
	public class VendorContactDataSourceDesigner : ProviderDataSourceDesigner<VendorContact, VendorContactKey>
	{
		/// <summary>
		/// Initializes a new instance of the VendorContactDataSourceDesigner class.
		/// </summary>
		public VendorContactDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VendorContactSelectMethod SelectMethod
		{
			get { return ((VendorContactDataSource) DataSource).SelectMethod; }
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
				actions.Add(new VendorContactDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region VendorContactDataSourceActionList

	/// <summary>
	/// Supports the VendorContactDataSourceDesigner class.
	/// </summary>
	internal class VendorContactDataSourceActionList : DesignerActionList
	{
		private VendorContactDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the VendorContactDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public VendorContactDataSourceActionList(VendorContactDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VendorContactSelectMethod SelectMethod
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

	#endregion VendorContactDataSourceActionList
	
	#endregion VendorContactDataSourceDesigner
	
	#region VendorContactSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the VendorContactDataSource.SelectMethod property.
	/// </summary>
	public enum VendorContactSelectMethod
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
		/// Represents the GetByContactId method.
		/// </summary>
		GetByContactId,
		/// <summary>
		/// Represents the GetByContactTypeId method.
		/// </summary>
		GetByContactTypeId,
		/// <summary>
		/// Represents the GetByVendorIdContactId method.
		/// </summary>
		GetByVendorIdContactId,
		/// <summary>
		/// Represents the GetByVendorId method.
		/// </summary>
		GetByVendorId
	}
	
	#endregion VendorContactSelectMethod

	#region VendorContactFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorContactFilter : SqlFilter<VendorContactColumn>
	{
	}
	
	#endregion VendorContactFilter

	#region VendorContactExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorContactExpressionBuilder : SqlExpressionBuilder<VendorContactColumn>
	{
	}
	
	#endregion VendorContactExpressionBuilder	

	#region VendorContactProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;VendorContactChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="VendorContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorContactProperty : ChildEntityProperty<VendorContactChildEntityTypes>
	{
	}
	
	#endregion VendorContactProperty
}

