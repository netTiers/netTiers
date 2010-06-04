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
	/// Represents the DataRepository.IndividualProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(IndividualDataSourceDesigner))]
	public class IndividualDataSource : ProviderDataSource<Individual, IndividualKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndividualDataSource class.
		/// </summary>
		public IndividualDataSource() : base(new IndividualService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the IndividualDataSourceView used by the IndividualDataSource.
		/// </summary>
		protected IndividualDataSourceView IndividualView
		{
			get { return ( View as IndividualDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the IndividualDataSource control invokes to retrieve data.
		/// </summary>
		public IndividualSelectMethod SelectMethod
		{
			get
			{
				IndividualSelectMethod selectMethod = IndividualSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (IndividualSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the IndividualDataSourceView class that is to be
		/// used by the IndividualDataSource.
		/// </summary>
		/// <returns>An instance of the IndividualDataSourceView class.</returns>
		protected override BaseDataSourceView<Individual, IndividualKey> GetNewDataSourceView()
		{
			return new IndividualDataSourceView(this, DefaultViewName);
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
	/// Supports the IndividualDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class IndividualDataSourceView : ProviderDataSourceView<Individual, IndividualKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndividualDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the IndividualDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public IndividualDataSourceView(IndividualDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal IndividualDataSource IndividualOwner
		{
			get { return Owner as IndividualDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal IndividualSelectMethod SelectMethod
		{
			get { return IndividualOwner.SelectMethod; }
			set { IndividualOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal IndividualService IndividualProvider
		{
			get { return Provider as IndividualService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Individual> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Individual> results = null;
			Individual item;
			count = 0;
			
			System.Int32 _customerId;
			string _demographics_nullable;
			System.Int32 _contactId;

			switch ( SelectMethod )
			{
				case IndividualSelectMethod.Get:
					IndividualKey entityKey  = new IndividualKey();
					entityKey.Load(values);
					item = IndividualProvider.Get(entityKey);
					results = new TList<Individual>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case IndividualSelectMethod.GetAll:
                    results = IndividualProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case IndividualSelectMethod.GetPaged:
					results = IndividualProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case IndividualSelectMethod.Find:
					if ( FilterParameters != null )
						results = IndividualProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = IndividualProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case IndividualSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					item = IndividualProvider.GetByCustomerId(_customerId);
					results = new TList<Individual>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case IndividualSelectMethod.GetByDemographics:
					_demographics_nullable = (string) EntityUtil.ChangeType(values["Demographics"], typeof(string));
					results = IndividualProvider.GetByDemographics(_demographics_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case IndividualSelectMethod.GetByContactId:
					_contactId = ( values["ContactId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactId"], typeof(System.Int32)) : (int)0;
					results = IndividualProvider.GetByContactId(_contactId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == IndividualSelectMethod.Get || SelectMethod == IndividualSelectMethod.GetByCustomerId )
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
				Individual entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					IndividualProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Individual> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			IndividualProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region IndividualDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the IndividualDataSource class.
	/// </summary>
	public class IndividualDataSourceDesigner : ProviderDataSourceDesigner<Individual, IndividualKey>
	{
		/// <summary>
		/// Initializes a new instance of the IndividualDataSourceDesigner class.
		/// </summary>
		public IndividualDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IndividualSelectMethod SelectMethod
		{
			get { return ((IndividualDataSource) DataSource).SelectMethod; }
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
				actions.Add(new IndividualDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region IndividualDataSourceActionList

	/// <summary>
	/// Supports the IndividualDataSourceDesigner class.
	/// </summary>
	internal class IndividualDataSourceActionList : DesignerActionList
	{
		private IndividualDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the IndividualDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public IndividualDataSourceActionList(IndividualDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IndividualSelectMethod SelectMethod
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

	#endregion IndividualDataSourceActionList
	
	#endregion IndividualDataSourceDesigner
	
	#region IndividualSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the IndividualDataSource.SelectMethod property.
	/// </summary>
	public enum IndividualSelectMethod
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
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByDemographics method.
		/// </summary>
		GetByDemographics,
		/// <summary>
		/// Represents the GetByContactId method.
		/// </summary>
		GetByContactId
	}
	
	#endregion IndividualSelectMethod

	#region IndividualFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Individual"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndividualFilter : SqlFilter<IndividualColumn>
	{
	}
	
	#endregion IndividualFilter

	#region IndividualExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Individual"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndividualExpressionBuilder : SqlExpressionBuilder<IndividualColumn>
	{
	}
	
	#endregion IndividualExpressionBuilder	

	#region IndividualProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;IndividualChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Individual"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndividualProperty : ChildEntityProperty<IndividualChildEntityTypes>
	{
	}
	
	#endregion IndividualProperty
}

