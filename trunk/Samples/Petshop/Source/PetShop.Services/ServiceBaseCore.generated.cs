
#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using PetShop.Business;
using PetShop.Business.Validation;
using PetShop.Data;
using PetShop.Data.Bases;

using Microsoft.Practices.EnterpriseLibrary.Logging;
#endregion

namespace PetShop.Services
{
	/// <summary>
	/// The interface that each component business domain service of the model implements.
	/// </summary>
	public abstract class ServiceBaseCore<Entity, EntityKey> : MarshalByRefObject, IComponentService, IEntityProvider<Entity, EntityKey>
		where Entity : IEntityId<EntityKey>, new() 
		where EntityKey : IEntityKey, new()
	{
		#region Fields
		
		#endregion Fields
		
		#region Properties
		
		private IList<IProcessor> processorList = new List<IProcessor>();
		/// <summary>
		///	Provides a List of Processors to execute external business process logic in.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public virtual IList<IProcessor> ProcessorList 
		{
			get	{ return processorList;	} 
			set { processorList = value; }
		}

		private ServiceResult serviceResult = null;
		/// <summary>
		///	Provides a Notification Pattern of Process Results.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public virtual ServiceResult ServiceProcessResult
		{
			get
			{
				if (serviceResult == null)
				{
					serviceResult = new ServiceResult();
				}
				
				return serviceResult;
			}
		}

		private bool abortOnFailure = true;
		/// <summary>
		///	Provides a way to terminate the Processor calls upon an exception. 
		/// </summary>
		///<value>bool value determining to stop once an exceptions been thrown. </value>		
		public virtual bool AbortOnFailure 
		{
			get { return abortOnFailure; } 
			set	{ abortOnFailure = value; } 
		}

		/// <summary>
		/// Current Processor being executed
		/// </summary>
		public virtual string CurrentProcessor
		{
			get 
			{
				if (ProcessorList.Count > CurrentProcessorIndex)
				{
					return ProcessorList[CurrentProcessorIndex].ProcessName;
				}
				
				return null;
			}	
		}

		/// <summary>
		/// Current Number of Processes completed thus far.
		/// </summary>
		public virtual int ProcessCounter
		{
			get {return currentProcessorIndex + 1;}
		}
		
		private int currentProcessorIndex = 0;
		/// <summary>
		/// Current index of the processor currently or last executed 
		/// </summary>
		public virtual int CurrentProcessorIndex
		{
			get {return currentProcessorIndex;}
		}
		
		/// <summary>
		/// Total Number of Processes currently enlisted in this service 
		/// </summary>
		public virtual int TotalProcesses
		{
			get {return ProcessorList.Count;}		
		}
		#endregion Properties
		
		#region Events
		/// <summary>
		///	Provides the notification on the change of process state to interested parties.
		/// </summary>
		public virtual void OnProcessStarting(ProcessorBase processor)
		{
			if (ProcessStarting != null)
			{
				ProcessStarting(this, new ProcessorEventArgs(processor));
			}
		}

		/// <summary>
		///	Provides the notification on the change of process state to interested parties.
		/// </summary>
		public virtual void OnProcessEnded(ProcessorBase processor)
		{
			if (ProcessEnded != null)
			{
				ProcessEnded(this, new ProcessorEventArgs(processor));
			}
		}
		
		/// <summary>
		/// Event to indicate that a processor has began.
		/// </summary>
		[field: NonSerialized]
		public event ProcessStartingHandler ProcessStarting;

		/// <summary>
		/// Event to indicate that a processor has ended.
		/// </summary>
		[field: NonSerialized]
		public event ProcessEndedHandler ProcessEnded;
	
		#endregion Events	

		#region Execute methods
		/// <summary>
		///	Provides the beginning
		/// <remarks>
		/// If no AbortIfFailure parameter is passed then the process will not abort if there is a failure
		/// </remarks>
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public virtual ServiceResult Execute()
		{
			return Execute(false);
		}
		
		/// <summary>
		///	Executes the processors in the processor list
		/// <remarks>
		/// If abortIfFailure is set to true then the execution will halt on the first failure
		///</remarks>
		/// </summary>
		public virtual ServiceResult Execute(bool abortIfFailure)
		{
			AbortOnFailure = abortIfFailure;
			ServiceResult result = ServiceProcessResult;
		
			for(int i=0; i < ProcessorList.Count; i++)
			{
				currentProcessorIndex = i;
				
				if (ProcessorList[i] == null)
				{
					throw new ArgumentNullException(string.Format("The process located at index {0} of the ProcessorList is null.", i));
				}
					
				OnProcessStarting((ProcessorBase)ProcessorList[i]);	//Fire Process Starting Event
				ProcessorList[i].ChangeProcessorState(ProcessorState.Running);
				IProcessorResult processResult = null;
				
				try
				{
					processResult = ProcessorList[i].Process();	//Begin Process
				}
				catch(Exception exc)
				{
					Logger.Write(exc);
					result.ExceptionList.Add((ProcessorBase)ProcessorList[i], exc);
					ProcessorList[i].ChangeProcessorState(ProcessorState.Stopped);
				}
				
				//if the processor didn't do cleanup, cleanup by default.
				if (ProcessorList[i].CurrentProcessorState == ProcessorState.Running)
				{
					ProcessorList[i].ChangeProcessorState(processResult.Result ? ProcessorState.Completed : ProcessorState.Stopped);
				}

				if (processResult != null)
				{
					//Add to Processor Result List
					result.ProcessorResultList.Add(processResult);
	
					//Add To Aggregated Broken Rules List
 					foreach(BrokenRulesList list in processResult.BrokenRulesLists.Values)
                        result.ProcessBrokenRuleLists.Add((ProcessorBase)ProcessorList[i], list);
				}
				
				OnProcessEnded(ProcessorList[i] as ProcessorBase);	//Fire Process Ending Event

				if ((processResult == null || !processResult.Result) && 
						AbortOnFailure)
				{
					return result;
				}
			}
			
			return result;
		}
		#endregion Execute methods

		#region IEntityProvider Implementation
		
		#region GetAll Methods
		/// <summary>
        /// Gets a row from the DataSource based on its primary key.
        /// </summary>
        /// <param name="key">The unique identifier of the row to retrieve.</param>
        /// <returns>Returns an instance of the Entity class.</returns>
		public virtual Entity Get(EntityKey key)
		{
			throw new NotImplementedException();	
		}
		
		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetAll()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region GetPaged Methods

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a TList of Entity objects.</returns>
		public virtual TList<Entity> GetPaged(string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Find Functions
		
		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual TList<Entity> Find(string whereClause, int start, int pageLength, out int count)
		{
			throw new NotImplementedException();
		}
	
		#endregion Find Functions
		
		#region Insert Methods

		/// <summary>
		/// Inserts a row into the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public virtual bool Insert(Entity entity)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Efficiently inserts multiple rows into the DataSource.
		/// </summary>
		/// <param name="entities">TList of Entity objects to insert.</param>
		public virtual void BulkInsert(TList<Entity> entities)
		{
			throw new NotImplementedException("The BulkInsert method has not been implemented.");
		}

		#endregion Insert Methods
		
		#region Update Methods

		/// <summary>
		/// Updates an existing row in the DataSource.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if the operation is successful.</returns>
		public virtual bool Update(Entity entity)
		{
			throw new NotImplementedException();
		}
	  
	    /// <summary>
	    /// Deletes a row from the DataSource.
	    /// </summary>
	    /// <param name="entity">The Entity object to delete.</param>
	    /// <returns>Returns true if the operation is successful.</returns>
	    public virtual bool Delete(Entity entity)
		{
			throw new NotImplementedException();	
		}
		#endregion Update Methods

		#region Save Methods
		
		/// <summary>
		/// Saves row changes in the DataSource (insert, update ,delete).
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		public virtual Entity Save(Entity entity)
		{
			throw new NotImplementedException();
		}

		#endregion Save Methods
		
		#region DeepLoad Methods

		#region DeepLoad Entity
		/// <summary>
		/// Deep Load the entire Entity object with criteria based on the child types array and the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with recursion and traverse an entire collection's object graph.
		/// </remarks>
		/// <param name="entity">The Entity object to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Load.</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
		protected virtual void DeepLoad(Entity entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			throw new NotImplementedException();
		}

		#endregion DeepLoad Entity

		#region DeepLoad Entity Collection

		/// <summary>
		/// Deep Loads the entire <see cref="TList{Entity}" /> object with criteria based of the child 
		/// property collections only N Levels Deep based on the DeepLoadType.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire collection's object graph.
		/// </remarks>
		/// <param name="entities">TList of Entity objects to load.</param>
		/// <param name="deep">A flag that indicates whether to recursively load all Property Collections that are descendants of this instance. If True, loads the complete object graph below this object. If False, loads this object only.</param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Load.</param>
		public virtual void DeepLoad(TList<Entity> entities, bool deep, DeepLoadType deepLoadType, params System.Type[] childTypes)
		{
			throw new NotImplementedException();
		}

		#endregion DeepLoad Entity Collection

		#endregion DeepLoad Methods
		
		#region DeepSave

		#region DeepSave Entity

		/// <summary>
		/// Deep Save the Entity object with all of the child property collections only 1 level deep.
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		public virtual bool DeepSave(Entity entity)
		{
			throw new NotImplementedException();
		}
		
		/// <summary>
		/// Deep Save the entire Entity object with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="entity">The Entity object to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		public virtual bool DeepSave(Entity entity, DeepSaveType deepSaveType, params System.Type[] childTypes)
		{
			/*
			// check if borrowed transaction
			bool isBorrowedTransaction = ( mgr != null && mgr.IsOpen );
			DeepSave(mgr, entity, deepSaveType, isBorrowedTransaction, null, null, childTypes);
			return true;
			*/
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deep Save the entire Entity object with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <remarks>
		/// This method should be implemented by sub-classes to provide specific deep save functionality.
		/// </remarks>
		/// <param name="entity">The Entity object to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		protected virtual void DeepSave(Entity entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{
			// check if borrowed transaction
			/*bool isBorrowedTransaction = ( mgr != null && mgr.IsOpen );
			DeepSave(mgr, entity, deepSaveType, isBorrowedTransaction, null, null, childTypes);
			*/
			throw new NotImplementedException();
		}

		#endregion DeepSave Entity

		#region DeepSave Entity Collection

		/// <summary>
		/// Deep Save the Entity objects with criteria based on the child types array and the DeepSaveType.
		/// </summary>
		/// <param name="entities">TList of Entity objects to save.</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Entity Property Collection Type Array To Include or Exclude from Save.</param>
		public virtual bool DeepSave(TList<Entity> entities, DeepSaveType deepSaveType, params System.Type[] childTypes)
		{
			// check if borrowed transaction
			/*
			bool isBorrowedTransaction = ( mgr != null && mgr.IsOpen );
			DeepSave(entities, deepSaveType, childTypes);
			return true;
			*/
			throw new NotImplementedException();
		}

		#endregion DeepSave Entity Collection

		#endregion DeepSave Methods
		
		#endregion IEntityProvider Implementation	
	}

	#region Process delegates
	/// <summary>
	/// ProcessStartingHandler
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	public delegate void ProcessStartingHandler(object sender, ProcessorEventArgs args);

	/// <summary>
	/// ProcessEndedHandler
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	public delegate void ProcessEndedHandler(object sender, ProcessorEventArgs args);

	#endregion Process delegates
	
	#region Event arguments
	/// <summary>
	/// Processor Event Args
	/// </summary>
	public class ProcessorEventArgs : EventArgs
	{
		private ProcessorBase processor;
		
		/// <summary>
		/// Initializes a new instance of the ProcessorEventArgs class.
		/// </summary>
		/// <param name="processor"></param>
		public ProcessorEventArgs(ProcessorBase processor)
		{
			this.processor = processor;
		}
		
		/// <summary>
        /// Gets or sets the processor.
        /// </summary>
        /// <value>The processor.</value>
		public ProcessorBase Processor
	    {
	        get { return processor; }
	        set { processor = value; }
	    }
	}
	#endregion Event arguments	
}
