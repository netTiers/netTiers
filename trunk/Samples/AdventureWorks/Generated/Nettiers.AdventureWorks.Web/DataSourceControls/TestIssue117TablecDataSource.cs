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
	/// Represents the DataRepository.TestIssue117TablecProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TestIssue117TablecDataSourceDesigner))]
	public class TestIssue117TablecDataSource : ProviderDataSource<TestIssue117Tablec, TestIssue117TablecKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecDataSource class.
		/// </summary>
		public TestIssue117TablecDataSource() : base(new TestIssue117TablecService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TestIssue117TablecDataSourceView used by the TestIssue117TablecDataSource.
		/// </summary>
		protected TestIssue117TablecDataSourceView TestIssue117TablecView
		{
			get { return ( View as TestIssue117TablecDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TestIssue117TablecDataSource control invokes to retrieve data.
		/// </summary>
		public TestIssue117TablecSelectMethod SelectMethod
		{
			get
			{
				TestIssue117TablecSelectMethod selectMethod = TestIssue117TablecSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TestIssue117TablecSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TestIssue117TablecDataSourceView class that is to be
		/// used by the TestIssue117TablecDataSource.
		/// </summary>
		/// <returns>An instance of the TestIssue117TablecDataSourceView class.</returns>
		protected override BaseDataSourceView<TestIssue117Tablec, TestIssue117TablecKey> GetNewDataSourceView()
		{
			return new TestIssue117TablecDataSourceView(this, DefaultViewName);
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
	/// Supports the TestIssue117TablecDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TestIssue117TablecDataSourceView : ProviderDataSourceView<TestIssue117Tablec, TestIssue117TablecKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TestIssue117TablecDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TestIssue117TablecDataSourceView(TestIssue117TablecDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TestIssue117TablecDataSource TestIssue117TablecOwner
		{
			get { return Owner as TestIssue117TablecDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TestIssue117TablecSelectMethod SelectMethod
		{
			get { return TestIssue117TablecOwner.SelectMethod; }
			set { TestIssue117TablecOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TestIssue117TablecService TestIssue117TablecProvider
		{
			get { return Provider as TestIssue117TablecService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TestIssue117Tablec> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TestIssue117Tablec> results = null;
			TestIssue117Tablec item;
			count = 0;
			
			System.Int32 _testIssue117TableAid;
			System.Int32 _testIssue117TableBid;

			switch ( SelectMethod )
			{
				case TestIssue117TablecSelectMethod.Get:
					TestIssue117TablecKey entityKey  = new TestIssue117TablecKey();
					entityKey.Load(values);
					item = TestIssue117TablecProvider.Get(entityKey);
					results = new TList<TestIssue117Tablec>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TestIssue117TablecSelectMethod.GetAll:
                    results = TestIssue117TablecProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TestIssue117TablecSelectMethod.GetPaged:
					results = TestIssue117TablecProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TestIssue117TablecSelectMethod.Find:
					if ( FilterParameters != null )
						results = TestIssue117TablecProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TestIssue117TablecProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TestIssue117TablecSelectMethod.GetByTestIssue117TableAidTestIssue117TableBid:
					_testIssue117TableAid = ( values["TestIssue117TableAid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestIssue117TableAid"], typeof(System.Int32)) : (int)0;
					_testIssue117TableBid = ( values["TestIssue117TableBid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestIssue117TableBid"], typeof(System.Int32)) : (int)0;
					item = TestIssue117TablecProvider.GetByTestIssue117TableAidTestIssue117TableBid(_testIssue117TableAid, _testIssue117TableBid);
					results = new TList<TestIssue117Tablec>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case TestIssue117TablecSelectMethod.GetByTestIssue117TableAid:
					_testIssue117TableAid = ( values["TestIssue117TableAid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestIssue117TableAid"], typeof(System.Int32)) : (int)0;
					results = TestIssue117TablecProvider.GetByTestIssue117TableAid(_testIssue117TableAid, this.StartIndex, this.PageSize, out count);
					break;
				case TestIssue117TablecSelectMethod.GetByTestIssue117TableBid:
					_testIssue117TableBid = ( values["TestIssue117TableBid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestIssue117TableBid"], typeof(System.Int32)) : (int)0;
					results = TestIssue117TablecProvider.GetByTestIssue117TableBid(_testIssue117TableBid, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == TestIssue117TablecSelectMethod.Get || SelectMethod == TestIssue117TablecSelectMethod.GetByTestIssue117TableAidTestIssue117TableBid )
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
				TestIssue117Tablec entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TestIssue117TablecProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TestIssue117Tablec> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TestIssue117TablecProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TestIssue117TablecDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TestIssue117TablecDataSource class.
	/// </summary>
	public class TestIssue117TablecDataSourceDesigner : ProviderDataSourceDesigner<TestIssue117Tablec, TestIssue117TablecKey>
	{
		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecDataSourceDesigner class.
		/// </summary>
		public TestIssue117TablecDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestIssue117TablecSelectMethod SelectMethod
		{
			get { return ((TestIssue117TablecDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TestIssue117TablecDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TestIssue117TablecDataSourceActionList

	/// <summary>
	/// Supports the TestIssue117TablecDataSourceDesigner class.
	/// </summary>
	internal class TestIssue117TablecDataSourceActionList : DesignerActionList
	{
		private TestIssue117TablecDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablecDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TestIssue117TablecDataSourceActionList(TestIssue117TablecDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestIssue117TablecSelectMethod SelectMethod
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

	#endregion TestIssue117TablecDataSourceActionList
	
	#endregion TestIssue117TablecDataSourceDesigner
	
	#region TestIssue117TablecSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TestIssue117TablecDataSource.SelectMethod property.
	/// </summary>
	public enum TestIssue117TablecSelectMethod
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
		/// Represents the GetByTestIssue117TableAidTestIssue117TableBid method.
		/// </summary>
		GetByTestIssue117TableAidTestIssue117TableBid,
		/// <summary>
		/// Represents the GetByTestIssue117TableAid method.
		/// </summary>
		GetByTestIssue117TableAid,
		/// <summary>
		/// Represents the GetByTestIssue117TableBid method.
		/// </summary>
		GetByTestIssue117TableBid
	}
	
	#endregion TestIssue117TablecSelectMethod

	#region TestIssue117TablecFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablec"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablecFilter : SqlFilter<TestIssue117TablecColumn>
	{
	}
	
	#endregion TestIssue117TablecFilter

	#region TestIssue117TablecExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablec"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablecExpressionBuilder : SqlExpressionBuilder<TestIssue117TablecColumn>
	{
	}
	
	#endregion TestIssue117TablecExpressionBuilder	

	#region TestIssue117TablecProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TestIssue117TablecChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablec"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablecProperty : ChildEntityProperty<TestIssue117TablecChildEntityTypes>
	{
	}
	
	#endregion TestIssue117TablecProperty
}

