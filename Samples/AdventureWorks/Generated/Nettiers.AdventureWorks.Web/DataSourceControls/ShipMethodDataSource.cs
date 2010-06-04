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
	/// Represents the DataRepository.ShipMethodProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ShipMethodDataSourceDesigner))]
	public class ShipMethodDataSource : ProviderDataSource<ShipMethod, ShipMethodKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShipMethodDataSource class.
		/// </summary>
		public ShipMethodDataSource() : base(new ShipMethodService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ShipMethodDataSourceView used by the ShipMethodDataSource.
		/// </summary>
		protected ShipMethodDataSourceView ShipMethodView
		{
			get { return ( View as ShipMethodDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ShipMethodDataSource control invokes to retrieve data.
		/// </summary>
		public ShipMethodSelectMethod SelectMethod
		{
			get
			{
				ShipMethodSelectMethod selectMethod = ShipMethodSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ShipMethodSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ShipMethodDataSourceView class that is to be
		/// used by the ShipMethodDataSource.
		/// </summary>
		/// <returns>An instance of the ShipMethodDataSourceView class.</returns>
		protected override BaseDataSourceView<ShipMethod, ShipMethodKey> GetNewDataSourceView()
		{
			return new ShipMethodDataSourceView(this, DefaultViewName);
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
	/// Supports the ShipMethodDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ShipMethodDataSourceView : ProviderDataSourceView<ShipMethod, ShipMethodKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShipMethodDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ShipMethodDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ShipMethodDataSourceView(ShipMethodDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ShipMethodDataSource ShipMethodOwner
		{
			get { return Owner as ShipMethodDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ShipMethodSelectMethod SelectMethod
		{
			get { return ShipMethodOwner.SelectMethod; }
			set { ShipMethodOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ShipMethodService ShipMethodProvider
		{
			get { return Provider as ShipMethodService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ShipMethod> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ShipMethod> results = null;
			ShipMethod item;
			count = 0;
			
			System.String _name;
			System.Guid _rowguid;
			System.Int32 _shipMethodId;

			switch ( SelectMethod )
			{
				case ShipMethodSelectMethod.Get:
					ShipMethodKey entityKey  = new ShipMethodKey();
					entityKey.Load(values);
					item = ShipMethodProvider.Get(entityKey);
					results = new TList<ShipMethod>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ShipMethodSelectMethod.GetAll:
                    results = ShipMethodProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ShipMethodSelectMethod.GetPaged:
					results = ShipMethodProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ShipMethodSelectMethod.Find:
					if ( FilterParameters != null )
						results = ShipMethodProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ShipMethodProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ShipMethodSelectMethod.GetByShipMethodId:
					_shipMethodId = ( values["ShipMethodId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ShipMethodId"], typeof(System.Int32)) : (int)0;
					item = ShipMethodProvider.GetByShipMethodId(_shipMethodId);
					results = new TList<ShipMethod>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ShipMethodSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ShipMethodProvider.GetByName(_name);
					results = new TList<ShipMethod>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ShipMethodSelectMethod.GetByRowguid:
					_rowguid = ( values["Rowguid"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Rowguid"], typeof(System.Guid)) : Guid.Empty;
					item = ShipMethodProvider.GetByRowguid(_rowguid);
					results = new TList<ShipMethod>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
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
			if ( SelectMethod == ShipMethodSelectMethod.Get || SelectMethod == ShipMethodSelectMethod.GetByShipMethodId )
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
				ShipMethod entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ShipMethodProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ShipMethod> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ShipMethodProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ShipMethodDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ShipMethodDataSource class.
	/// </summary>
	public class ShipMethodDataSourceDesigner : ProviderDataSourceDesigner<ShipMethod, ShipMethodKey>
	{
		/// <summary>
		/// Initializes a new instance of the ShipMethodDataSourceDesigner class.
		/// </summary>
		public ShipMethodDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ShipMethodSelectMethod SelectMethod
		{
			get { return ((ShipMethodDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ShipMethodDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ShipMethodDataSourceActionList

	/// <summary>
	/// Supports the ShipMethodDataSourceDesigner class.
	/// </summary>
	internal class ShipMethodDataSourceActionList : DesignerActionList
	{
		private ShipMethodDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ShipMethodDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ShipMethodDataSourceActionList(ShipMethodDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ShipMethodSelectMethod SelectMethod
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

	#endregion ShipMethodDataSourceActionList
	
	#endregion ShipMethodDataSourceDesigner
	
	#region ShipMethodSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ShipMethodDataSource.SelectMethod property.
	/// </summary>
	public enum ShipMethodSelectMethod
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
		/// Represents the GetByName method.
		/// </summary>
		GetByName,
		/// <summary>
		/// Represents the GetByRowguid method.
		/// </summary>
		GetByRowguid,
		/// <summary>
		/// Represents the GetByShipMethodId method.
		/// </summary>
		GetByShipMethodId
	}
	
	#endregion ShipMethodSelectMethod

	#region ShipMethodFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShipMethod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShipMethodFilter : SqlFilter<ShipMethodColumn>
	{
	}
	
	#endregion ShipMethodFilter

	#region ShipMethodExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShipMethod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShipMethodExpressionBuilder : SqlExpressionBuilder<ShipMethodColumn>
	{
	}
	
	#endregion ShipMethodExpressionBuilder	

	#region ShipMethodProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ShipMethodChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ShipMethod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShipMethodProperty : ChildEntityProperty<ShipMethodChildEntityTypes>
	{
	}
	
	#endregion ShipMethodProperty
}

