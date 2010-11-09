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
	/// Represents the DataRepository.TestProductProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TestProductDataSourceDesigner))]
	public class TestProductDataSource : ProviderDataSource<TestProduct, TestProductKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestProductDataSource class.
		/// </summary>
		public TestProductDataSource() : base(new TestProductService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TestProductDataSourceView used by the TestProductDataSource.
		/// </summary>
		protected TestProductDataSourceView TestProductView
		{
			get { return ( View as TestProductDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TestProductDataSource control invokes to retrieve data.
		/// </summary>
		public TestProductSelectMethod SelectMethod
		{
			get
			{
				TestProductSelectMethod selectMethod = TestProductSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TestProductSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TestProductDataSourceView class that is to be
		/// used by the TestProductDataSource.
		/// </summary>
		/// <returns>An instance of the TestProductDataSourceView class.</returns>
		protected override BaseDataSourceView<TestProduct, TestProductKey> GetNewDataSourceView()
		{
			return new TestProductDataSourceView(this, DefaultViewName);
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
	/// Supports the TestProductDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TestProductDataSourceView : ProviderDataSourceView<TestProduct, TestProductKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestProductDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TestProductDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TestProductDataSourceView(TestProductDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TestProductDataSource TestProductOwner
		{
			get { return Owner as TestProductDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TestProductSelectMethod SelectMethod
		{
			get { return TestProductOwner.SelectMethod; }
			set { TestProductOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TestProductService TestProductProvider
		{
			get { return Provider as TestProductService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TestProduct> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TestProduct> results = null;
			TestProduct item;
			count = 0;
			
			System.Int32 _productId;

			switch ( SelectMethod )
			{
				case TestProductSelectMethod.Get:
					TestProductKey entityKey  = new TestProductKey();
					entityKey.Load(values);
					item = TestProductProvider.Get(entityKey);
					results = new TList<TestProduct>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TestProductSelectMethod.GetAll:
                    results = TestProductProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TestProductSelectMethod.GetPaged:
					results = TestProductProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TestProductSelectMethod.Find:
					if ( FilterParameters != null )
						results = TestProductProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TestProductProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TestProductSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					item = TestProductProvider.GetByProductId(_productId);
					results = new TList<TestProduct>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
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
			if ( SelectMethod == TestProductSelectMethod.Get || SelectMethod == TestProductSelectMethod.GetByProductId )
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
				TestProduct entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TestProductProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TestProduct> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TestProductProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TestProductDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TestProductDataSource class.
	/// </summary>
	public class TestProductDataSourceDesigner : ProviderDataSourceDesigner<TestProduct, TestProductKey>
	{
		/// <summary>
		/// Initializes a new instance of the TestProductDataSourceDesigner class.
		/// </summary>
		public TestProductDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestProductSelectMethod SelectMethod
		{
			get { return ((TestProductDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TestProductDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TestProductDataSourceActionList

	/// <summary>
	/// Supports the TestProductDataSourceDesigner class.
	/// </summary>
	internal class TestProductDataSourceActionList : DesignerActionList
	{
		private TestProductDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TestProductDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TestProductDataSourceActionList(TestProductDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestProductSelectMethod SelectMethod
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

	#endregion TestProductDataSourceActionList
	
	#endregion TestProductDataSourceDesigner
	
	#region TestProductSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TestProductDataSource.SelectMethod property.
	/// </summary>
	public enum TestProductSelectMethod
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
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion TestProductSelectMethod

	#region TestProductFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestProductFilter : SqlFilter<TestProductColumn>
	{
	}
	
	#endregion TestProductFilter

	#region TestProductExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestProductExpressionBuilder : SqlExpressionBuilder<TestProductColumn>
	{
	}
	
	#endregion TestProductExpressionBuilder	

	#region TestProductProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TestProductChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TestProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestProductProperty : ChildEntityProperty<TestProductChildEntityTypes>
	{
	}
	
	#endregion TestProductProperty
}

