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
	/// Represents the DataRepository.StudentMasterIndexProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(StudentMasterIndexDataSourceDesigner))]
	public class StudentMasterIndexDataSource : ProviderDataSource<StudentMasterIndex, StudentMasterIndexKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexDataSource class.
		/// </summary>
		public StudentMasterIndexDataSource() : base(new StudentMasterIndexService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the StudentMasterIndexDataSourceView used by the StudentMasterIndexDataSource.
		/// </summary>
		protected StudentMasterIndexDataSourceView StudentMasterIndexView
		{
			get { return ( View as StudentMasterIndexDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the StudentMasterIndexDataSource control invokes to retrieve data.
		/// </summary>
		public StudentMasterIndexSelectMethod SelectMethod
		{
			get
			{
				StudentMasterIndexSelectMethod selectMethod = StudentMasterIndexSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (StudentMasterIndexSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the StudentMasterIndexDataSourceView class that is to be
		/// used by the StudentMasterIndexDataSource.
		/// </summary>
		/// <returns>An instance of the StudentMasterIndexDataSourceView class.</returns>
		protected override BaseDataSourceView<StudentMasterIndex, StudentMasterIndexKey> GetNewDataSourceView()
		{
			return new StudentMasterIndexDataSourceView(this, DefaultViewName);
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
	/// Supports the StudentMasterIndexDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class StudentMasterIndexDataSourceView : ProviderDataSourceView<StudentMasterIndex, StudentMasterIndexKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the StudentMasterIndexDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public StudentMasterIndexDataSourceView(StudentMasterIndexDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal StudentMasterIndexDataSource StudentMasterIndexOwner
		{
			get { return Owner as StudentMasterIndexDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal StudentMasterIndexSelectMethod SelectMethod
		{
			get { return StudentMasterIndexOwner.SelectMethod; }
			set { StudentMasterIndexOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal StudentMasterIndexService StudentMasterIndexProvider
		{
			get { return Provider as StudentMasterIndexService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<StudentMasterIndex> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<StudentMasterIndex> results = null;
			StudentMasterIndex item;
			count = 0;
			
			System.Int32 _studentId;

			switch ( SelectMethod )
			{
				case StudentMasterIndexSelectMethod.Get:
					StudentMasterIndexKey entityKey  = new StudentMasterIndexKey();
					entityKey.Load(values);
					item = StudentMasterIndexProvider.Get(entityKey);
					results = new TList<StudentMasterIndex>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StudentMasterIndexSelectMethod.GetAll:
                    results = StudentMasterIndexProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case StudentMasterIndexSelectMethod.GetPaged:
					results = StudentMasterIndexProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case StudentMasterIndexSelectMethod.Find:
					if ( FilterParameters != null )
						results = StudentMasterIndexProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = StudentMasterIndexProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case StudentMasterIndexSelectMethod.GetByStudentId:
					_studentId = ( values["StudentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StudentId"], typeof(System.Int32)) : (int)0;
					item = StudentMasterIndexProvider.GetByStudentId(_studentId);
					results = new TList<StudentMasterIndex>();
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
			if ( SelectMethod == StudentMasterIndexSelectMethod.Get || SelectMethod == StudentMasterIndexSelectMethod.GetByStudentId )
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
				StudentMasterIndex entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					StudentMasterIndexProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<StudentMasterIndex> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			StudentMasterIndexProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region StudentMasterIndexDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the StudentMasterIndexDataSource class.
	/// </summary>
	public class StudentMasterIndexDataSourceDesigner : ProviderDataSourceDesigner<StudentMasterIndex, StudentMasterIndexKey>
	{
		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexDataSourceDesigner class.
		/// </summary>
		public StudentMasterIndexDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StudentMasterIndexSelectMethod SelectMethod
		{
			get { return ((StudentMasterIndexDataSource) DataSource).SelectMethod; }
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
				actions.Add(new StudentMasterIndexDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region StudentMasterIndexDataSourceActionList

	/// <summary>
	/// Supports the StudentMasterIndexDataSourceDesigner class.
	/// </summary>
	internal class StudentMasterIndexDataSourceActionList : DesignerActionList
	{
		private StudentMasterIndexDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public StudentMasterIndexDataSourceActionList(StudentMasterIndexDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StudentMasterIndexSelectMethod SelectMethod
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

	#endregion StudentMasterIndexDataSourceActionList
	
	#endregion StudentMasterIndexDataSourceDesigner
	
	#region StudentMasterIndexSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the StudentMasterIndexDataSource.SelectMethod property.
	/// </summary>
	public enum StudentMasterIndexSelectMethod
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
		/// Represents the GetByStudentId method.
		/// </summary>
		GetByStudentId
	}
	
	#endregion StudentMasterIndexSelectMethod

	#region StudentMasterIndexFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StudentMasterIndex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StudentMasterIndexFilter : SqlFilter<StudentMasterIndexColumn>
	{
	}
	
	#endregion StudentMasterIndexFilter

	#region StudentMasterIndexExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StudentMasterIndex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StudentMasterIndexExpressionBuilder : SqlExpressionBuilder<StudentMasterIndexColumn>
	{
	}
	
	#endregion StudentMasterIndexExpressionBuilder	

	#region StudentMasterIndexProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;StudentMasterIndexChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="StudentMasterIndex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StudentMasterIndexProperty : ChildEntityProperty<StudentMasterIndexChildEntityTypes>
	{
	}
	
	#endregion StudentMasterIndexProperty
}

