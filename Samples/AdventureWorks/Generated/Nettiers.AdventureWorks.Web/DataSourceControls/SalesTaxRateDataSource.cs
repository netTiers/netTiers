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
	/// Represents the DataRepository.SalesTaxRateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalesTaxRateDataSourceDesigner))]
	public class SalesTaxRateDataSource : ProviderDataSource<SalesTaxRate, SalesTaxRateKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateDataSource class.
		/// </summary>
		public SalesTaxRateDataSource() : base(new SalesTaxRateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalesTaxRateDataSourceView used by the SalesTaxRateDataSource.
		/// </summary>
		protected SalesTaxRateDataSourceView SalesTaxRateView
		{
			get { return ( View as SalesTaxRateDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalesTaxRateDataSource control invokes to retrieve data.
		/// </summary>
		public SalesTaxRateSelectMethod SelectMethod
		{
			get
			{
				SalesTaxRateSelectMethod selectMethod = SalesTaxRateSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalesTaxRateSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalesTaxRateDataSourceView class that is to be
		/// used by the SalesTaxRateDataSource.
		/// </summary>
		/// <returns>An instance of the SalesTaxRateDataSourceView class.</returns>
		protected override BaseDataSourceView<SalesTaxRate, SalesTaxRateKey> GetNewDataSourceView()
		{
			return new SalesTaxRateDataSourceView(this, DefaultViewName);
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
	/// Supports the SalesTaxRateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalesTaxRateDataSourceView : ProviderDataSourceView<SalesTaxRate, SalesTaxRateKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalesTaxRateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalesTaxRateDataSourceView(SalesTaxRateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalesTaxRateDataSource SalesTaxRateOwner
		{
			get { return Owner as SalesTaxRateDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalesTaxRateSelectMethod SelectMethod
		{
			get { return SalesTaxRateOwner.SelectMethod; }
			set { SalesTaxRateOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalesTaxRateService SalesTaxRateProvider
		{
			get { return Provider as SalesTaxRateService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalesTaxRate> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalesTaxRate> results = null;
			SalesTaxRate item;
			count = 0;
			
			System.Guid _rowguid;
			System.Int32 _stateProvinceId;
			System.Byte _taxType;
			System.Int32 _salesTaxRateId;

			switch ( SelectMethod )
			{
				case SalesTaxRateSelectMethod.Get:
					SalesTaxRateKey entityKey  = new SalesTaxRateKey();
					entityKey.Load(values);
					item = SalesTaxRateProvider.Get(entityKey);
					results = new TList<SalesTaxRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesTaxRateSelectMethod.GetAll:
                    results = SalesTaxRateProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalesTaxRateSelectMethod.GetPaged:
					results = SalesTaxRateProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalesTaxRateSelectMethod.Find:
					if ( FilterParameters != null )
						results = SalesTaxRateProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalesTaxRateProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalesTaxRateSelectMethod.GetBySalesTaxRateId:
					_salesTaxRateId = ( values["SalesTaxRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesTaxRateId"], typeof(System.Int32)) : (int)0;
					item = SalesTaxRateProvider.GetBySalesTaxRateId(_salesTaxRateId);
					results = new TList<SalesTaxRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SalesTaxRateSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = SalesTaxRateProvider.GetByRowguid(_rowguid);
					results = new TList<SalesTaxRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalesTaxRateSelectMethod.GetByStateProvinceIdTaxType:
					_stateProvinceId = ( values["StateProvinceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StateProvinceId"], typeof(System.Int32)) : (int)0;
					_taxType = ( values["TaxType"] != null ) ? (System.Byte) EntityUtil.ChangeType(values["TaxType"], typeof(System.Byte)) : (byte)0;
					item = SalesTaxRateProvider.GetByStateProvinceIdTaxType(_stateProvinceId, _taxType);
					results = new TList<SalesTaxRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case SalesTaxRateSelectMethod.GetByStateProvinceId:
					_stateProvinceId = ( values["StateProvinceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StateProvinceId"], typeof(System.Int32)) : (int)0;
					results = SalesTaxRateProvider.GetByStateProvinceId(_stateProvinceId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SalesTaxRateSelectMethod.Get || SelectMethod == SalesTaxRateSelectMethod.GetBySalesTaxRateId )
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
				SalesTaxRate entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalesTaxRateProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalesTaxRate> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalesTaxRateProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalesTaxRateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalesTaxRateDataSource class.
	/// </summary>
	public class SalesTaxRateDataSourceDesigner : ProviderDataSourceDesigner<SalesTaxRate, SalesTaxRateKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalesTaxRateDataSourceDesigner class.
		/// </summary>
		public SalesTaxRateDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesTaxRateSelectMethod SelectMethod
		{
			get { return ((SalesTaxRateDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalesTaxRateDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalesTaxRateDataSourceActionList

	/// <summary>
	/// Supports the SalesTaxRateDataSourceDesigner class.
	/// </summary>
	internal class SalesTaxRateDataSourceActionList : DesignerActionList
	{
		private SalesTaxRateDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalesTaxRateDataSourceActionList(SalesTaxRateDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalesTaxRateSelectMethod SelectMethod
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

	#endregion SalesTaxRateDataSourceActionList
	
	#endregion SalesTaxRateDataSourceDesigner
	
	#region SalesTaxRateSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalesTaxRateDataSource.SelectMethod property.
	/// </summary>
	public enum SalesTaxRateSelectMethod
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
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByStateProvinceIdTaxType method.
		/// </summary>
		GetByStateProvinceIdTaxType,
		/// <summary>
		/// Represents the GetBySalesTaxRateId method.
		/// </summary>
		GetBySalesTaxRateId,
		/// <summary>
		/// Represents the GetByStateProvinceId method.
		/// </summary>
		GetByStateProvinceId
	}
	
	#endregion SalesTaxRateSelectMethod

	#region SalesTaxRateFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTaxRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTaxRateFilter : SqlFilter<SalesTaxRateColumn>
	{
	}
	
	#endregion SalesTaxRateFilter

	#region SalesTaxRateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTaxRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTaxRateExpressionBuilder : SqlExpressionBuilder<SalesTaxRateColumn>
	{
	}
	
	#endregion SalesTaxRateExpressionBuilder	

	#region SalesTaxRateProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalesTaxRateChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTaxRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTaxRateProperty : ChildEntityProperty<SalesTaxRateChildEntityTypes>
	{
	}
	
	#endregion SalesTaxRateProperty
}

