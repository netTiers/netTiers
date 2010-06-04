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
	/// Represents the DataRepository.CultureProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CultureDataSourceDesigner))]
	public class CultureDataSource : ProviderDataSource<Culture, CultureKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CultureDataSource class.
		/// </summary>
		public CultureDataSource() : base(new CultureService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CultureDataSourceView used by the CultureDataSource.
		/// </summary>
		protected CultureDataSourceView CultureView
		{
			get { return ( View as CultureDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CultureDataSource control invokes to retrieve data.
		/// </summary>
		public CultureSelectMethod SelectMethod
		{
			get
			{
				CultureSelectMethod selectMethod = CultureSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CultureSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CultureDataSourceView class that is to be
		/// used by the CultureDataSource.
		/// </summary>
		/// <returns>An instance of the CultureDataSourceView class.</returns>
		protected override BaseDataSourceView<Culture, CultureKey> GetNewDataSourceView()
		{
			return new CultureDataSourceView(this, DefaultViewName);
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
	/// Supports the CultureDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CultureDataSourceView : ProviderDataSourceView<Culture, CultureKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CultureDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CultureDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CultureDataSourceView(CultureDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CultureDataSource CultureOwner
		{
			get { return Owner as CultureDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CultureSelectMethod SelectMethod
		{
			get { return CultureOwner.SelectMethod; }
			set { CultureOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CultureService CultureProvider
		{
			get { return Provider as CultureService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Culture> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Culture> results = null;
			Culture item;
			count = 0;
			
			System.String _name;
			System.String _cultureId;
			System.Int32 _productDescriptionId;
			System.Int32 _productModelId;

			switch ( SelectMethod )
			{
				case CultureSelectMethod.Get:
					CultureKey entityKey  = new CultureKey();
					entityKey.Load(values);
					item = CultureProvider.Get(entityKey);
					results = new TList<Culture>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CultureSelectMethod.GetAll:
                    results = CultureProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CultureSelectMethod.GetPaged:
					results = CultureProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CultureSelectMethod.Find:
					if ( FilterParameters != null )
						results = CultureProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CultureProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CultureSelectMethod.GetByCultureId:
					_cultureId = ( values["CultureId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CultureId"], typeof(System.String)) : string.Empty;
					item = CultureProvider.GetByCultureId(_cultureId);
					results = new TList<Culture>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CultureSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = CultureProvider.GetByName(_name);
					results = new TList<Culture>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case CultureSelectMethod.GetByProductDescriptionIdFromProductModelProductDescriptionCulture:
					_productDescriptionId = ( values["ProductDescriptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductDescriptionId"], typeof(System.Int32)) : (int)0;
					results = CultureProvider.GetByProductDescriptionIdFromProductModelProductDescriptionCulture(_productDescriptionId, this.StartIndex, this.PageSize, out count);
					break;
				case CultureSelectMethod.GetByProductModelIdFromProductModelProductDescriptionCulture:
					_productModelId = ( values["ProductModelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductModelId"], typeof(System.Int32)) : (int)0;
					results = CultureProvider.GetByProductModelIdFromProductModelProductDescriptionCulture(_productModelId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CultureSelectMethod.Get || SelectMethod == CultureSelectMethod.GetByCultureId )
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
				Culture entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CultureProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Culture> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CultureProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CultureDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CultureDataSource class.
	/// </summary>
	public class CultureDataSourceDesigner : ProviderDataSourceDesigner<Culture, CultureKey>
	{
		/// <summary>
		/// Initializes a new instance of the CultureDataSourceDesigner class.
		/// </summary>
		public CultureDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CultureSelectMethod SelectMethod
		{
			get { return ((CultureDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CultureDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CultureDataSourceActionList

	/// <summary>
	/// Supports the CultureDataSourceDesigner class.
	/// </summary>
	internal class CultureDataSourceActionList : DesignerActionList
	{
		private CultureDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CultureDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CultureDataSourceActionList(CultureDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CultureSelectMethod SelectMethod
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

	#endregion CultureDataSourceActionList
	
	#endregion CultureDataSourceDesigner
	
	#region CultureSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CultureDataSource.SelectMethod property.
	/// </summary>
	public enum CultureSelectMethod
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
		/// Represents the GetByCultureId method.
		/// </summary>
		GetByCultureId,
		/// <summary>
		/// Represents the GetByProductDescriptionIdFromProductModelProductDescriptionCulture method.
		/// </summary>
		GetByProductDescriptionIdFromProductModelProductDescriptionCulture,
		/// <summary>
		/// Represents the GetByProductModelIdFromProductModelProductDescriptionCulture method.
		/// </summary>
		GetByProductModelIdFromProductModelProductDescriptionCulture
	}
	
	#endregion CultureSelectMethod

	#region CultureFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Culture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CultureFilter : SqlFilter<CultureColumn>
	{
	}
	
	#endregion CultureFilter

	#region CultureExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Culture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CultureExpressionBuilder : SqlExpressionBuilder<CultureColumn>
	{
	}
	
	#endregion CultureExpressionBuilder	

	#region CultureProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CultureChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Culture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CultureProperty : ChildEntityProperty<CultureChildEntityTypes>
	{
	}
	
	#endregion CultureProperty
}

