
using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace PetShop.Services
{
	/// <summary>
	/// The interface that each component business domain service of the model implements.
	/// </summary>
	public interface IComponentService
	{
		/// <summary>
		///	Provides a List of Processors to execute business process logic in.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		IList<IProcessor> ProcessorList {get; set;}

		/// <summary>
		///	Provides a Notification Pattern of Process Results.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		ServiceResult ServiceProcessResult{get;}
				
		/// <summary>
		///	Provides a way to terminate the Processor calls upon an exception. 
		/// </summary>
		///<value>bool value determining to stop once an exceptions been thrown. </value>		
		bool AbortOnFailure {get; set; }

		/// <summary>
		/// Event to indicate that a processor is about to begin.
		/// </summary>
		event ProcessStartingHandler ProcessStarting;

		/// <summary>
		/// Event to indicate that a processor has just ended.
		/// </summary>
		event ProcessEndedHandler ProcessEnded;
		
	}
}
