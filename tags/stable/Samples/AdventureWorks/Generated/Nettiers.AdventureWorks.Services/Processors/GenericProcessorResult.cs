﻿
using System;
using System.ComponentModel;
using System.Collections.Generic;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Entities.Validation;

namespace Nettiers.AdventureWorks.Services
{
	/// <summary>
	/// The interface that each component business domain service of the model implements.
	/// </summary> 
	[Serializable]
	public class GenericProcessorResult : IProcessorResult
	{
		private bool result;
		private Dictionary<Type, BrokenRulesList> brokenRuleLists = null;
		private bool resultSetByProcessor = false;
		private ProcessorState finalProcessorState = ProcessorState.Unknown;
		
		/// <summary>
		/// Initializes a new instance of the GenericProcessorResult class.
		/// </summary>
		public GenericProcessorResult()
		{
			brokenRuleLists = new Dictionary<Type, BrokenRulesList>();
		}
		
		/// <summary>
		///	Provides a result of the current process.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public bool Result 
		{	
			get 
			{
				// if not set by a processor, then run a default check on the broken rules.
				if (!resultSetByProcessor)
				{
					//default check to see if a list has broken rules.
					foreach(KeyValuePair<Type, BrokenRulesList> list in BrokenRulesLists)
					{
						if (list.Value.Count > 0)
						{
							result = false;
							return result;
						}
					}
					result = true;
				}
				
				return result;
			} 
			set
			{ 	
				result = value; 	
				resultSetByProcessor = true;
			}
		}
		
		/// <summary>
		///	Provides a list of broken rules for the entire process.
		/// </summary>
		///<value>A list of rules that were broken in the process</value>
		public Dictionary<Type, BrokenRulesList> BrokenRulesLists
		{
			get{	return brokenRuleLists;	}
		}

		/// <summary>
		///	Provides a method to aggregate BrokenRuleList Collections Based on their Type 
		/// if they are invalid.
		/// </summary>
		public void AddBrokenRulesList(Type type, BrokenRulesList otherList)
		{
			//skip, no rules broken
			if (otherList == null || otherList.Count == 0)
                return;

			if (type == null)
				type = typeof(object);
			
			BrokenRulesLists.Add(type, otherList);
		}
		
		/// <summary>
		///	Provides the final processor state the operation. 
		/// This is set by the processor.
		/// </summary>
		public ProcessorState FinalProcessorState 
		{
			get	
			{	
					return finalProcessorState;
			}
			set
			{
				finalProcessorState = value;
			}
		}
	}
}
