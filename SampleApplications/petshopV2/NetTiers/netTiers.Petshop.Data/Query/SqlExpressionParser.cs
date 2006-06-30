#region Using Directives
using System;
using System.Text;
#endregion

namespace netTiers.Petshop.Data
{
	/// <summary>
	/// Parses search text into an expression that can
	/// be used in a SQL WHERE clause.
	/// </summary>
	[CLSCompliant(true)]
	public class SqlExpressionParser : ExpressionParserBase
	{
		#region Declarations

		private StringBuilder sql;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		public SqlExpressionParser(String propertyName)
			: this(propertyName, SqlComparisonType.Contains, false)
		{
		}

		/// <summary>
		/// Initializes a new instance of the SqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="ignoreCase"></param>
		public SqlExpressionParser(String propertyName, bool ignoreCase)
			: this(propertyName, SqlComparisonType.Contains, ignoreCase)
		{
		}

		/// <summary>
		/// Initializes a new instance of the SqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="comparisonType"></param>
		public SqlExpressionParser(String propertyName, SqlComparisonType comparisonType)
			: this(propertyName, comparisonType, false)
		{
		}

		/// <summary>
		/// Initializes a new instance of the SqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="comparisonType"></param>
		/// <param name="ignoreCase"></param>
		public SqlExpressionParser(String propertyName, SqlComparisonType comparisonType, bool ignoreCase)
			: base(propertyName, comparisonType, ignoreCase)
		{
		}

		#endregion

		#region ExpressionParserBase Members

		/// <summary>
		/// Appends "OR" to the SQL statement.
		/// </summary>
		protected override void AppendOr()
		{
			sql.AppendFormat(" {0} ", SqlUtil.OR);
		}

		/// <summary>
		/// Appends "AND" to the SQL statement.
		/// </summary>
		protected override void AppendAnd()
		{
			sql.AppendFormat(" {0} ", SqlUtil.AND);
		}

		/// <summary>
		/// Appends a space to the SQL statement.
		/// </summary>
		protected override void AppendSpace()
		{
			sql.Append(" ");
		}

		/// <summary>
		/// Appends a left parentheses to the SQL statement.
		/// </summary>
		protected override void OpenGrouping()
		{
			sql.Append(SqlUtil.LEFT);
		}

		/// <summary>
		/// Appends a right parentheses to the SQL statement.
		/// </summary>
		protected override void CloseGrouping()
		{
			sql.Append(SqlUtil.RIGHT);
		}

		/// <summary>
		/// Appends the specified search text to the SQL statement.
		/// </summary>
		/// <param name="searchText">The search text to append.</param>
		protected override void AppendSearchText(string searchText)
		{
			sql.Append(WrapWithSQL(PropertyName, searchText, IgnoreCase));
		}

		/// <summary>
		/// Converts the search text into a valid search expression.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		private String WrapWithSQL(String propertyName, String value, bool ignoreCase)
		{
			SqlComparisonType compare = ComparisonType;
			String sql = String.Empty;

			// check for wildcards
			if ( String.IsNullOrEmpty(value) )
			{
				return sql;
			}
			else if ( value.Equals(SqlUtil.STAR) )
			{
				compare = SqlComparisonType.Like;
				value = SqlUtil.WILD;
			}
			else if ( value.StartsWith(SqlUtil.STAR) && value.EndsWith(SqlUtil.STAR) )
			{
				compare = SqlComparisonType.Contains;
				value = value.Substring(1, value.Length - 2);
			}
			else if ( value.EndsWith(SqlUtil.STAR) )
			{
				compare = SqlComparisonType.StartsWith;
				value = value.Substring(0, value.Length - 1);
			}
			else if ( value.StartsWith(SqlUtil.STAR) )
			{
				compare = SqlComparisonType.EndsWith;
				value = value.Substring(1, value.Length - 1);
			}
			else
			{
				compare = SqlComparisonType.Equals;
			}

			// make sure there are no embeded wildcards
			if ( value.IndexOf(SqlUtil.STAR) > -1 )
			{
				value = value.Replace(SqlUtil.STAR, SqlUtil.WILD);

				if ( compare == SqlComparisonType.Equals )
				{
					compare = SqlComparisonType.Like;
				}
			}

			switch ( compare )
			{
				case SqlComparisonType.Contains:
					sql = SqlUtil.Contains(propertyName, value, ignoreCase);
					break;
				case SqlComparisonType.StartsWith:
					sql = SqlUtil.StartsWith(propertyName, value, ignoreCase);
					break;
				case SqlComparisonType.EndsWith:
					sql = SqlUtil.EndsWith(propertyName, value, ignoreCase);
					break;
				case SqlComparisonType.Like:
					sql = SqlUtil.Like(propertyName, value, ignoreCase);
					break;
				default:
					sql = SqlUtil.Equals(propertyName, value, ignoreCase);
					break;
			}

			return sql;
		}

		#endregion ExpressionParserBase Members

		#region Parse Method

		/// <summary>
		/// Parses the specified value into separate search terms.
		/// </summary>
		/// <param name="value">The search text.</param>
		/// <returns>Returns a parsed search phrase.</returns>
		public virtual String Parse(String value)
		{
			sql = new StringBuilder();
			ParseCore(value);
			return sql.ToString();
		}

		#endregion Parse Method
	}
}
