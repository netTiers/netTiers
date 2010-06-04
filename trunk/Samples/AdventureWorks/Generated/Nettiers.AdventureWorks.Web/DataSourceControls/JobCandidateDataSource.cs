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
	/// Represents the DataRepository.JobCandidateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(JobCandidateDataSourceDesigner))]
	public class JobCandidateDataSource : ProviderDataSource<JobCandidate, JobCandidateKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCandidateDataSource class.
		/// </summary>
		public JobCandidateDataSource() : base(new JobCandidateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the JobCandidateDataSourceView used by the JobCandidateDataSource.
		/// </summary>
		protected JobCandidateDataSourceView JobCandidateView
		{
			get { return ( View as JobCandidateDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the JobCandidateDataSource control invokes to retrieve data.
		/// </summary>
		public JobCandidateSelectMethod SelectMethod
		{
			get
			{
				JobCandidateSelectMethod selectMethod = JobCandidateSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (JobCandidateSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the JobCandidateDataSourceView class that is to be
		/// used by the JobCandidateDataSource.
		/// </summary>
		/// <returns>An instance of the JobCandidateDataSourceView class.</returns>
		protected override BaseDataSourceView<JobCandidate, JobCandidateKey> GetNewDataSourceView()
		{
			return new JobCandidateDataSourceView(this, DefaultViewName);
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
	/// Supports the JobCandidateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class JobCandidateDataSourceView : ProviderDataSourceView<JobCandidate, JobCandidateKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCandidateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the JobCandidateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public JobCandidateDataSourceView(JobCandidateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal JobCandidateDataSource JobCandidateOwner
		{
			get { return Owner as JobCandidateDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal JobCandidateSelectMethod SelectMethod
		{
			get { return JobCandidateOwner.SelectMethod; }
			set { JobCandidateOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal JobCandidateService JobCandidateProvider
		{
			get { return Provider as JobCandidateService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<JobCandidate> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<JobCandidate> results = null;
			JobCandidate item;
			count = 0;
			
			System.Int32? _employeeId_nullable;
			System.Int32 _jobCandidateId;

			switch ( SelectMethod )
			{
				case JobCandidateSelectMethod.Get:
					JobCandidateKey entityKey  = new JobCandidateKey();
					entityKey.Load(values);
					item = JobCandidateProvider.Get(entityKey);
					results = new TList<JobCandidate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case JobCandidateSelectMethod.GetAll:
                    results = JobCandidateProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case JobCandidateSelectMethod.GetPaged:
					results = JobCandidateProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case JobCandidateSelectMethod.Find:
					if ( FilterParameters != null )
						results = JobCandidateProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = JobCandidateProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case JobCandidateSelectMethod.GetByJobCandidateId:
					_jobCandidateId = ( values["JobCandidateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobCandidateId"], typeof(System.Int32)) : (int)0;
					item = JobCandidateProvider.GetByJobCandidateId(_jobCandidateId);
					results = new TList<JobCandidate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case JobCandidateSelectMethod.GetByEmployeeId:
					_employeeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32?));
					results = JobCandidateProvider.GetByEmployeeId(_employeeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == JobCandidateSelectMethod.Get || SelectMethod == JobCandidateSelectMethod.GetByJobCandidateId )
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
				JobCandidate entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					JobCandidateProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<JobCandidate> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			JobCandidateProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region JobCandidateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the JobCandidateDataSource class.
	/// </summary>
	public class JobCandidateDataSourceDesigner : ProviderDataSourceDesigner<JobCandidate, JobCandidateKey>
	{
		/// <summary>
		/// Initializes a new instance of the JobCandidateDataSourceDesigner class.
		/// </summary>
		public JobCandidateDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobCandidateSelectMethod SelectMethod
		{
			get { return ((JobCandidateDataSource) DataSource).SelectMethod; }
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
				actions.Add(new JobCandidateDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region JobCandidateDataSourceActionList

	/// <summary>
	/// Supports the JobCandidateDataSourceDesigner class.
	/// </summary>
	internal class JobCandidateDataSourceActionList : DesignerActionList
	{
		private JobCandidateDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the JobCandidateDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public JobCandidateDataSourceActionList(JobCandidateDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobCandidateSelectMethod SelectMethod
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

	#endregion JobCandidateDataSourceActionList
	
	#endregion JobCandidateDataSourceDesigner
	
	#region JobCandidateSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the JobCandidateDataSource.SelectMethod property.
	/// </summary>
	public enum JobCandidateSelectMethod
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
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId,
		/// <summary>
		/// Represents the GetByJobCandidateId method.
		/// </summary>
		GetByJobCandidateId
	}
	
	#endregion JobCandidateSelectMethod

	#region JobCandidateFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCandidateFilter : SqlFilter<JobCandidateColumn>
	{
	}
	
	#endregion JobCandidateFilter

	#region JobCandidateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCandidateExpressionBuilder : SqlExpressionBuilder<JobCandidateColumn>
	{
	}
	
	#endregion JobCandidateExpressionBuilder	

	#region JobCandidateProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;JobCandidateChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="JobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCandidateProperty : ChildEntityProperty<JobCandidateChildEntityTypes>
	{
	}
	
	#endregion JobCandidateProperty
}

