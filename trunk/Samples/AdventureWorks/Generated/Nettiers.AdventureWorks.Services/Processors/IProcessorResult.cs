
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Entities.Validation;

namespace Nettiers.AdventureWorks.Services
{
	/// <summary>
	/// The interface that each component business domain service of the model implements.
	/// </summary>
	public interface IProcessorResult
	{
		/// <summary>
		///	Provides a result of the current process.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		bool Result {get; set;}
		
		/// <summary>
		///	Provides a list of broken rules for the entire process.
		/// </summary>
		///<value>A list of rules that were broken in the process</value>
		Dictionary<Type, BrokenRulesList> BrokenRulesLists {get;}
		/// <summary>
		///	Provides a method to aggregate BrokenRuleList Collections Based on their Type 
		/// if they are invalid.
		/// </summary>
		void AddBrokenRulesList(Type type, BrokenRulesList otherList);
		
		/// <summary>
		///	Provides the final processor state the operation.
		/// </summary>
		ProcessorState FinalProcessorState {get;set;}
	}
}
