
using System;
using System.ComponentModel;

namespace PetShop.Services
{
	/// <summary>
	/// ProcessorState enumeration.
	/// </summary>
	public enum ProcessorState
	{
		/// <summary>
		/// Unknown
		/// </summary>
		Unknown,
		/// <summary>
		/// Running
		/// </summary>
		Running,
		/// <summary>
		/// Stopped
		/// </summary>
		Stopped, 
		/// <summary>
		/// Completed
		/// </summary>
		Completed
	}
	
	/// <summary>
	/// The interface that each component business domain service of the model implements.
	/// </summary>
	public interface IProcessor
	{
		/// <summary>
		///	Provides a name of the current processor to execute business process logic in.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		string ProcessName{get; set;}
		
		/// <summary>
		///	Provides a name of the current processor to execute business process logic in.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		IProcessorResult Process();

		/// <summary>
		///	Provides the notification on the change of process state to interested parties.
		/// </summary>
		void ChangeProcessorState(ProcessorState newProcessorState);
		
		/// <summary>
		///	Provides the current process state of operation.
		/// </summary>
		ProcessorState CurrentProcessorState {get;}

	}
}
