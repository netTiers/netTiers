﻿#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
#endregion

namespace PetShop.Data
{
	/// <summary>
	/// Provides the base functionality required to parse search terms.
	/// </summary>
	[CLSCompliant(true)]
	public abstract class ExpressionParserBase
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExpressionParserBase class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="comparisonType"></param>
		/// <param name="ignoreCase"></param>
		protected ExpressionParserBase(String propertyName, SqlComparisonType comparisonType, bool ignoreCase)
		{
			PropertyName = propertyName;
			ComparisonType = comparisonType;
			IgnoreCase = ignoreCase;
		}

		#endregion Constructors

		#region Methods

		/// <summary>
		/// Appends the specified search text to the current expression.
		/// </summary>
		/// <param name="searchText">The search text to append.</param>
		protected void ParseCore(String searchText)
		{
			IList<String> quotedValues = new List<String>();
			
			int leftNumber = 0;
			int rightNumber = 0;
			int i = -1;
			
			// last param was a key word
			bool isKeyWord = false;

			// used to track if the first param is a key word
			// i.e., and or "john smith"
			int numParams = 0;

			// use AND to search all
			// i.e. John Smith would become John and Smith
			// however "John Smith" is one entity
			bool needToInsertAND = false;

			String outStr = ParseQuotes(searchText, quotedValues);
			StringTokenizer tokenizer = new StringTokenizer(outStr, "( ),\t\r\n", true);
			String nextToken;

			while ( tokenizer.HasMoreTokens )
			{
				// trim token
				nextToken = tokenizer.NextToken.Trim();

				// left parenthesis
				if ( nextToken.Equals(SqlUtil.LEFT) )
				{
					leftNumber++;

					if ( needToInsertAND )
					{
						AppendAnd();
					}

					OpenGrouping();

					needToInsertAND = false;
					isKeyWord = false;
				}

				// right parenthesis
				else if ( nextToken.Equals(SqlUtil.RIGHT) )
				{
					rightNumber++;

					CloseGrouping();

					needToInsertAND = true;
					isKeyWord = false;
				}
				// comma
				else if ( nextToken.Equals(SqlUtil.COMMA) )
				{
					AppendOr();
					needToInsertAND = false;
					isKeyWord = false;
				}
				// token is a key word (such as AND, OR,...)
				else if ( IsKeyWord(nextToken) )
				{
					numParams++;

					// if this is the first parameter in the entire string
					// treat it as a regular param (not a key word)
					if ( numParams == 1 )
					{
						needToInsertAND = true;

						AppendSearchText(nextToken);
					}

					// if only two params
					else if ( ( numParams == 2 ) && ( tokenizer.CountTokens <= 1 ) )
					{
						AppendAnd();
						AppendSearchText(nextToken);
					}

					// if the last string was a key word
					else if ( isKeyWord )
					{
						needToInsertAND = true;

						// treat this param as a regular string, not a key word
						isKeyWord = false;

						AppendSearchText(nextToken);
					}
					else
					{
						// make sure this is not the last param, if so use AND to search all
						if ( tokenizer.CountTokens <= 1 )
						{
							AppendAnd();
							AppendSearchText(nextToken);
						}
						else
						{
							if ( SqlUtil.AND.Equals(nextToken, StringComparison.OrdinalIgnoreCase) )
							{
								AppendAnd();
							}
							else if ( SqlUtil.OR.Equals(nextToken, StringComparison.OrdinalIgnoreCase) )
							{
								AppendOr();
							}

							needToInsertAND = false;
							isKeyWord = true;
						}
					}
				}
				else if ( nextToken.Equals(" ") )
				{
					AppendSpace();
				}
				else if ( nextToken.Equals("") )
				{
				}
				// string in quotes
				else if ( nextToken.Equals(SqlUtil.TOKEN) )
				{
					numParams++;

					if ( needToInsertAND )
					{
						AppendAnd();
					}

					needToInsertAND = true;

					// if the search param string is like: "John Smith" and Jones
					// the and needs to be translated to a SQL "AND"
					isKeyWord = false;

					// get the next quoted string
					i++;

					AppendSearchText(quotedValues[i]);
				}
				// a regular string other than the above cases
				else
				{
					numParams++;

					if ( needToInsertAND )
					{
						AppendAnd();
					}

					needToInsertAND = true;
					isKeyWord = false;

					AppendSearchText(nextToken);
				}
			}

			if ( leftNumber != rightNumber )
			{
				throw new ArgumentException("Syntax Error: mismatched parenthesis.");
			}
		}

		/// <summary>
		/// Parses quoted search terms.
		/// </summary>
		/// <param name="searchText"></param>
		/// <param name="quotedValues"></param>
		/// <returns></returns>
		private String ParseQuotes(String searchText, IList<String> quotedValues)
		{
			// sanity check
			if ( String.IsNullOrEmpty(searchText) || searchText.IndexOf('"') < 0 )
			{
				return searchText;
			}

			String[] tokens = searchText.Split('"');
			StringBuilder sb = new StringBuilder();
			bool needEndQuotes = true;

			foreach ( String token in tokens )
			{
				needEndQuotes = !needEndQuotes;

				if ( needEndQuotes )
				{
					sb.Append(SqlUtil.TOKEN);
					quotedValues.Add(token);
				}
				else
				{
					sb.Append(token);
				}
			}

			if ( needEndQuotes )
			{
				throw new ArgumentException("Syntax Error: mismatched quotes.");
			}

			return sb.ToString();
		}

		/// <summary>
		/// Determines whether the specified word is a reserved keyword.
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		private bool IsKeyWord(String word)
		{
			return ( word != null && (
				SqlUtil.AND.Equals(word, StringComparison.OrdinalIgnoreCase) || 
				SqlUtil.OR.Equals(word, StringComparison.OrdinalIgnoreCase)
			));
		}

		#endregion Methods

		#region Abstract Methods

		/// <summary>
		/// Appends an OR expression.
		/// </summary>
		protected abstract void AppendOr();

		/// <summary>
		/// Appends an AND expression.
		/// </summary>
		protected abstract void AppendAnd();

		/// <summary>
		/// Appends an expression separator.
		/// </summary>
		protected abstract void AppendSpace();

		/// <summary>
		/// Appends a group opened expression.
		/// </summary>
		protected abstract void OpenGrouping();

		/// <summary>
		/// Appends a group closed expression.
		/// </summary>
		protected abstract void CloseGrouping();

		/// <summary>
		/// Appends the specified search text to the expression.
		/// </summary>
		/// <param name="searchText">The search text to append.</param>
		protected abstract void AppendSearchText(String searchText);

		#endregion Abstract Methods

		#region Properties

		/// <summary>
		/// The IgnoreCase member variable.
		/// </summary>
		private bool ignoreCase;

		/// <summary>
		/// Gets or sets the IgnoreCase property.
		/// </summary>
		public bool IgnoreCase
		{
			get { return ignoreCase; }
			set { ignoreCase = value; }
		}

		/// <summary>
		/// The PropertyName member variable.
		/// </summary>
		private String propertyName;

		/// <summary>
		/// Gets or sets the PropertyName property.
		/// </summary>
		public String PropertyName
		{
			get { return propertyName; }
			set { propertyName = value; }
		}

		/// <summary>
		/// The ComparisonType member variable.
		/// </summary>
		private SqlComparisonType comparisonType;

		/// <summary>
		/// Gets or sets the ComparisonType property.
		/// </summary>
		public SqlComparisonType ComparisonType
		{
			get { return comparisonType; }
			set { comparisonType = value; }
		}

		#endregion Properties
	}
}
