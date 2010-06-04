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
	/// Represents the DataRepository.TestVariantProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TestVariantDataSourceDesigner))]
	public class TestVariantDataSource : ProviderDataSource<TestVariant, TestVariantKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestVariantDataSource class.
		/// </summary>
		public TestVariantDataSource() : base(new TestVariantService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TestVariantDataSourceView used by the TestVariantDataSource.
		/// </summary>
		protected TestVariantDataSourceView TestVariantView
		{
			get { return ( View as TestVariantDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TestVariantDataSource control invokes to retrieve data.
		/// </summary>
		public TestVariantSelectMethod SelectMethod
		{
			get
			{
				TestVariantSelectMethod selectMethod = TestVariantSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TestVariantSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TestVariantDataSourceView class that is to be
		/// used by the TestVariantDataSource.
		/// </summary>
		/// <returns>An instance of the TestVariantDataSourceView class.</returns>
		protected override BaseDataSourceView<TestVariant, TestVariantKey> GetNewDataSourceView()
		{
			return new TestVariantDataSourceView(this, DefaultViewName);
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
	/// Supports the TestVariantDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TestVariantDataSourceView : ProviderDataSourceView<TestVariant, TestVariantKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestVariantDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TestVariantDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TestVariantDataSourceView(TestVariantDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TestVariantDataSource TestVariantOwner
		{
			get { return Owner as TestVariantDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TestVariantSelectMethod SelectMethod
		{
			get { return TestVariantOwner.SelectMethod; }
			set { TestVariantOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TestVariantService TestVariantProvider
		{
			get { return Provider as TestVariantService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TestVariant> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TestVariant> results = null;
			TestVariant item;
			count = 0;
			
			System.Int32 _testVariantId;

			switch ( SelectMethod )
			{
				case TestVariantSelectMethod.Get:
					TestVariantKey entityKey  = new TestVariantKey();
					entityKey.Load(values);
					item = TestVariantProvider.Get(entityKey);
					results = new TList<TestVariant>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TestVariantSelectMethod.GetAll:
                    results = TestVariantProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TestVariantSelectMethod.GetPaged:
					results = TestVariantProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TestVariantSelectMethod.Find:
					if ( FilterParameters != null )
						results = TestVariantProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TestVariantProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TestVariantSelectMethod.GetByTestVariantId:
					_testVariantId = ( values["TestVariantId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestVariantId"], typeof(System.Int32)) : (int)0;
					item = TestVariantProvider.GetByTestVariantId(_testVariantId);
					results = new TList<TestVariant>();
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
			if ( SelectMethod == TestVariantSelectMethod.Get || SelectMethod == TestVariantSelectMethod.GetByTestVariantId )
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
				TestVariant entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TestVariantProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TestVariant> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TestVariantProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TestVariantDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TestVariantDataSource class.
	/// </summary>
	public class TestVariantDataSourceDesigner : ProviderDataSourceDesigner<TestVariant, TestVariantKey>
	{
		/// <summary>
		/// Initializes a new instance of the TestVariantDataSourceDesigner class.
		/// </summary>
		public TestVariantDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestVariantSelectMethod SelectMethod
		{
			get { return ((TestVariantDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TestVariantDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TestVariantDataSourceActionList

	/// <summary>
	/// Supports the TestVariantDataSourceDesigner class.
	/// </summary>
	internal class TestVariantDataSourceActionList : DesignerActionList
	{
		private TestVariantDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TestVariantDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TestVariantDataSourceActionList(TestVariantDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestVariantSelectMethod SelectMethod
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

	#endregion TestVariantDataSourceActionList
	
	#endregion TestVariantDataSourceDesigner
	
	#region TestVariantSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TestVariantDataSource.SelectMethod property.
	/// </summary>
	public enum TestVariantSelectMethod
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
		/// Represents the GetByTestVariantId method.
		/// </summary>
		GetByTestVariantId
	}
	
	#endregion TestVariantSelectMethod

	#region TestVariantFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestVariant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestVariantFilter : SqlFilter<TestVariantColumn>
	{
	}
	
	#endregion TestVariantFilter

	#region TestVariantExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestVariant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestVariantExpressionBuilder : SqlExpressionBuilder<TestVariantColumn>
	{
	}
	
	#endregion TestVariantExpressionBuilder	

	#region TestVariantProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TestVariantChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TestVariant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestVariantProperty : ChildEntityProperty<TestVariantChildEntityTypes>
	{
	}
	
	#endregion TestVariantProperty
}

