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
	/// Represents the DataRepository.TestIssue117TablebProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TestIssue117TablebDataSourceDesigner))]
	public class TestIssue117TablebDataSource : ProviderDataSource<TestIssue117Tableb, TestIssue117TablebKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebDataSource class.
		/// </summary>
		public TestIssue117TablebDataSource() : base(new TestIssue117TablebService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TestIssue117TablebDataSourceView used by the TestIssue117TablebDataSource.
		/// </summary>
		protected TestIssue117TablebDataSourceView TestIssue117TablebView
		{
			get { return ( View as TestIssue117TablebDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TestIssue117TablebDataSource control invokes to retrieve data.
		/// </summary>
		public TestIssue117TablebSelectMethod SelectMethod
		{
			get
			{
				TestIssue117TablebSelectMethod selectMethod = TestIssue117TablebSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TestIssue117TablebSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TestIssue117TablebDataSourceView class that is to be
		/// used by the TestIssue117TablebDataSource.
		/// </summary>
		/// <returns>An instance of the TestIssue117TablebDataSourceView class.</returns>
		protected override BaseDataSourceView<TestIssue117Tableb, TestIssue117TablebKey> GetNewDataSourceView()
		{
			return new TestIssue117TablebDataSourceView(this, DefaultViewName);
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
	/// Supports the TestIssue117TablebDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TestIssue117TablebDataSourceView : ProviderDataSourceView<TestIssue117Tableb, TestIssue117TablebKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TestIssue117TablebDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TestIssue117TablebDataSourceView(TestIssue117TablebDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TestIssue117TablebDataSource TestIssue117TablebOwner
		{
			get { return Owner as TestIssue117TablebDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TestIssue117TablebSelectMethod SelectMethod
		{
			get { return TestIssue117TablebOwner.SelectMethod; }
			set { TestIssue117TablebOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TestIssue117TablebService TestIssue117TablebProvider
		{
			get { return Provider as TestIssue117TablebService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TestIssue117Tableb> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TestIssue117Tableb> results = null;
			TestIssue117Tableb item;
			count = 0;
			
			System.Int32 _testIssue117TableBid;
			System.Int32 _testIssue117TableAid;

			switch ( SelectMethod )
			{
				case TestIssue117TablebSelectMethod.Get:
					TestIssue117TablebKey entityKey  = new TestIssue117TablebKey();
					entityKey.Load(values);
					item = TestIssue117TablebProvider.Get(entityKey);
					results = new TList<TestIssue117Tableb>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TestIssue117TablebSelectMethod.GetAll:
                    results = TestIssue117TablebProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TestIssue117TablebSelectMethod.GetPaged:
					results = TestIssue117TablebProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TestIssue117TablebSelectMethod.Find:
					if ( FilterParameters != null )
						results = TestIssue117TablebProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TestIssue117TablebProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TestIssue117TablebSelectMethod.GetByTestIssue117TableBid:
					_testIssue117TableBid = ( values["TestIssue117TableBid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestIssue117TableBid"], typeof(System.Int32)) : (int)0;
					item = TestIssue117TablebProvider.GetByTestIssue117TableBid(_testIssue117TableBid);
					results = new TList<TestIssue117Tableb>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case TestIssue117TablebSelectMethod.GetByTestIssue117TableAidFromTestIssue117Tablec:
					_testIssue117TableAid = ( values["TestIssue117TableAid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestIssue117TableAid"], typeof(System.Int32)) : (int)0;
					results = TestIssue117TablebProvider.GetByTestIssue117TableAidFromTestIssue117Tablec(_testIssue117TableAid, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == TestIssue117TablebSelectMethod.Get || SelectMethod == TestIssue117TablebSelectMethod.GetByTestIssue117TableBid )
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
				TestIssue117Tableb entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TestIssue117TablebProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TestIssue117Tableb> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TestIssue117TablebProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TestIssue117TablebDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TestIssue117TablebDataSource class.
	/// </summary>
	public class TestIssue117TablebDataSourceDesigner : ProviderDataSourceDesigner<TestIssue117Tableb, TestIssue117TablebKey>
	{
		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebDataSourceDesigner class.
		/// </summary>
		public TestIssue117TablebDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestIssue117TablebSelectMethod SelectMethod
		{
			get { return ((TestIssue117TablebDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TestIssue117TablebDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TestIssue117TablebDataSourceActionList

	/// <summary>
	/// Supports the TestIssue117TablebDataSourceDesigner class.
	/// </summary>
	internal class TestIssue117TablebDataSourceActionList : DesignerActionList
	{
		private TestIssue117TablebDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TestIssue117TablebDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TestIssue117TablebDataSourceActionList(TestIssue117TablebDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestIssue117TablebSelectMethod SelectMethod
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

	#endregion TestIssue117TablebDataSourceActionList
	
	#endregion TestIssue117TablebDataSourceDesigner
	
	#region TestIssue117TablebSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TestIssue117TablebDataSource.SelectMethod property.
	/// </summary>
	public enum TestIssue117TablebSelectMethod
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
		/// Represents the GetByTestIssue117TableBid method.
		/// </summary>
		GetByTestIssue117TableBid,
		/// <summary>
		/// Represents the GetByTestIssue117TableAidFromTestIssue117Tablec method.
		/// </summary>
		GetByTestIssue117TableAidFromTestIssue117Tablec
	}
	
	#endregion TestIssue117TablebSelectMethod

	#region TestIssue117TablebFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tableb"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablebFilter : SqlFilter<TestIssue117TablebColumn>
	{
	}
	
	#endregion TestIssue117TablebFilter

	#region TestIssue117TablebExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tableb"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablebExpressionBuilder : SqlExpressionBuilder<TestIssue117TablebColumn>
	{
	}
	
	#endregion TestIssue117TablebExpressionBuilder	

	#region TestIssue117TablebProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TestIssue117TablebChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tableb"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TablebProperty : ChildEntityProperty<TestIssue117TablebChildEntityTypes>
	{
	}
	
	#endregion TestIssue117TablebProperty
}

