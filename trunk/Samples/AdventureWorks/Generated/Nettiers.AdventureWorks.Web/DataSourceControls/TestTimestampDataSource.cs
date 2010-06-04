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
	/// Represents the DataRepository.TestTimestampProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TestTimestampDataSourceDesigner))]
	public class TestTimestampDataSource : ProviderDataSource<TestTimestamp, TestTimestampKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestTimestampDataSource class.
		/// </summary>
		public TestTimestampDataSource() : base(new TestTimestampService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TestTimestampDataSourceView used by the TestTimestampDataSource.
		/// </summary>
		protected TestTimestampDataSourceView TestTimestampView
		{
			get { return ( View as TestTimestampDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TestTimestampDataSource control invokes to retrieve data.
		/// </summary>
		public TestTimestampSelectMethod SelectMethod
		{
			get
			{
				TestTimestampSelectMethod selectMethod = TestTimestampSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TestTimestampSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TestTimestampDataSourceView class that is to be
		/// used by the TestTimestampDataSource.
		/// </summary>
		/// <returns>An instance of the TestTimestampDataSourceView class.</returns>
		protected override BaseDataSourceView<TestTimestamp, TestTimestampKey> GetNewDataSourceView()
		{
			return new TestTimestampDataSourceView(this, DefaultViewName);
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
	/// Supports the TestTimestampDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TestTimestampDataSourceView : ProviderDataSourceView<TestTimestamp, TestTimestampKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestTimestampDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TestTimestampDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TestTimestampDataSourceView(TestTimestampDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TestTimestampDataSource TestTimestampOwner
		{
			get { return Owner as TestTimestampDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TestTimestampSelectMethod SelectMethod
		{
			get { return TestTimestampOwner.SelectMethod; }
			set { TestTimestampOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TestTimestampService TestTimestampProvider
		{
			get { return Provider as TestTimestampService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TestTimestamp> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TestTimestamp> results = null;
			TestTimestamp item;
			count = 0;
			
			System.Int32 _testTimestampId;

			switch ( SelectMethod )
			{
				case TestTimestampSelectMethod.Get:
					TestTimestampKey entityKey  = new TestTimestampKey();
					entityKey.Load(values);
					item = TestTimestampProvider.Get(entityKey);
					results = new TList<TestTimestamp>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TestTimestampSelectMethod.GetAll:
                    results = TestTimestampProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TestTimestampSelectMethod.GetPaged:
					results = TestTimestampProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TestTimestampSelectMethod.Find:
					if ( FilterParameters != null )
						results = TestTimestampProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TestTimestampProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TestTimestampSelectMethod.GetByTestTimestampId:
					_testTimestampId = ( values["TestTimestampId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestTimestampId"], typeof(System.Int32)) : (int)0;
					item = TestTimestampProvider.GetByTestTimestampId(_testTimestampId);
					results = new TList<TestTimestamp>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				// Custom
				case TestTimestampSelectMethod.GetAllTimestamp:
					results = TestTimestampProvider.GetAllTimestamp(StartIndex, PageSize);
					break;
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
			if ( SelectMethod == TestTimestampSelectMethod.Get || SelectMethod == TestTimestampSelectMethod.GetByTestTimestampId )
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
				TestTimestamp entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TestTimestampProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TestTimestamp> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TestTimestampProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TestTimestampDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TestTimestampDataSource class.
	/// </summary>
	public class TestTimestampDataSourceDesigner : ProviderDataSourceDesigner<TestTimestamp, TestTimestampKey>
	{
		/// <summary>
		/// Initializes a new instance of the TestTimestampDataSourceDesigner class.
		/// </summary>
		public TestTimestampDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestTimestampSelectMethod SelectMethod
		{
			get { return ((TestTimestampDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TestTimestampDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TestTimestampDataSourceActionList

	/// <summary>
	/// Supports the TestTimestampDataSourceDesigner class.
	/// </summary>
	internal class TestTimestampDataSourceActionList : DesignerActionList
	{
		private TestTimestampDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TestTimestampDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TestTimestampDataSourceActionList(TestTimestampDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestTimestampSelectMethod SelectMethod
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

	#endregion TestTimestampDataSourceActionList
	
	#endregion TestTimestampDataSourceDesigner
	
	#region TestTimestampSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TestTimestampDataSource.SelectMethod property.
	/// </summary>
	public enum TestTimestampSelectMethod
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
		/// Represents the GetByTestTimestampId method.
		/// </summary>
		GetByTestTimestampId,
		/// <summary>
		/// Represents the GetAllTimestamp method.
		/// </summary>
		GetAllTimestamp
	}
	
	#endregion TestTimestampSelectMethod

	#region TestTimestampFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestTimestamp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestTimestampFilter : SqlFilter<TestTimestampColumn>
	{
	}
	
	#endregion TestTimestampFilter

	#region TestTimestampExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestTimestamp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestTimestampExpressionBuilder : SqlExpressionBuilder<TestTimestampColumn>
	{
	}
	
	#endregion TestTimestampExpressionBuilder	

	#region TestTimestampProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TestTimestampChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TestTimestamp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestTimestampProperty : ChildEntityProperty<TestTimestampChildEntityTypes>
	{
	}
	
	#endregion TestTimestampProperty
}

