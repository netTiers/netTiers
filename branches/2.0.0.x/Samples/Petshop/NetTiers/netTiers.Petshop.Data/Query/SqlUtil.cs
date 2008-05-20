#region Using Directives
using System;
using System.Configuration;
using System.Text;
#endregion

namespace netTiers.Petshop.Data
{
	/// <summary>
	/// Provides utility methods for generating SQL expressions.
	/// </summary>
	[CLSCompliant(true)]
	public static class SqlUtil
	{
		#region Declarations

		/// <summary>
		/// SQL AND keyword.
		/// </summary>
		public static readonly String AND  = "AND";
		/// <summary>
		/// SQL OR keyword.
		/// </summary>
		public static readonly String OR   = "OR";
		/// <summary>
		/// SQL ASC keyword.
		/// </summary>
		public static readonly String ASC  = "ASC";
		/// <summary>
		/// SQL DESC keyword.
		/// </summary>
		public static readonly String DESC = "DESC";
		/// <summary>
		/// SQL NULL keyword.
		/// </summary>
		public static readonly String NULL = "NULL";
		/// <summary>
		/// Used to represent quoted search terms.
		/// </summary>
		public static readonly String TOKEN = "@@@";
		/// <summary>
		/// Delimiter for quoted search terms.
		/// </summary>
		public static readonly String QUOTE = "\"";
		/// <summary>
		/// Used as wildcard character within search text.
		/// </summary>
		public static readonly String STAR  = "*";
		/// <summary>
		/// SQL wildcard character.
		/// </summary>
		public static readonly String WILD  = "%";
		/// <summary>
		/// SQL grouping open character.
		/// </summary>
		public static readonly String LEFT  = "(";
		/// <summary>
		/// SQL grouping close character.
		/// </summary>
		public static readonly String RIGHT = ")";
		/// <summary>
		/// Delimiter for optional search terms.
		/// </summary>
		public static readonly String COMMA = ",";

		#endregion Declarations

		#region Equals

		/// <summary>
		/// Creates an <see cref="SqlComparisonType.Equals"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String Equals(String column, String value)
		{
			return Equals(column, value, true);
		}

		/// <summary>
		/// Creates an <see cref="SqlComparisonType.Equals"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String Equals(String column, String value, bool ignoreCase)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			String format = ignoreCase ? "UPPER({0}) = UPPER('{1}')" : "{0} = '{1}'";
			return String.Format(format, column, Encode(value));
		}

		#endregion Equals

		#region Contains

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Contains"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String Contains(String column, String value)
		{
			return Contains(column, value, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Contains"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String Contains(String column, String value, bool ignoreCase)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			String format = ignoreCase ? "UPPER({0}) LIKE UPPER('%{1}%')" : "{0} LIKE '%{1}%'";
			return String.Format(format, column, Encode(value));
		}

		#endregion Contains

		#region StartsWith

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.StartsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String StartsWith(String column, String value)
		{
			return StartsWith(column, value, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.StartsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String StartsWith(String column, String value, bool ignoreCase)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			String format = ignoreCase ? "UPPER({0}) LIKE UPPER('{1}%')" : "{0} LIKE '{1}%'";
			return String.Format(format, column, Encode(value));
		}

		#endregion StartsWith

		#region EndsWith

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.EndsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String EndsWith(String column, String value)
		{
			return EndsWith(column, value, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.EndsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String EndsWith(String column, String value, bool ignoreCase)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			String format = ignoreCase ? "UPPER({0}) LIKE UPPER('%{1}')" : "{0} LIKE '%{1}'";
			return String.Format(format, column, Encode(value));
		}

		#endregion EndsWith

		#region Like

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Like"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String Like(String column, String value)
		{
			return Like(column, value, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Like"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String Like(String column, String value, bool ignoreCase)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			String format = ignoreCase ? "UPPER({0}) LIKE UPPER('{1}')" : "{0} LIKE '{1}'";
			return String.Format(format, column, Encode(value));
		}

		#endregion Like

		#region Null/Not Null

		/// <summary>
		/// Creates an IS NULL expression.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public static String IsNull(String column)
		{
			return String.Format("{0} IS NULL", column);
		}

		/// <summary>
		/// Creates an IS NOT NULL expression.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public static String IsNotNull(String column)
		{
			return String.Format("{0} IS NOT NULL", column);
		}

		#endregion Null/Not Null

		#region Encode

		/// <summary>
		/// Encodes the specified value for use in SQL expressions.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String Encode(String value)
		{
			return Encode(value, false);
		}

		/// <summary>
		/// Encodes the specified value for use in SQL expressions and
		/// optionally surrounds the value with single-quotes.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String Encode(String value, bool surround)
		{
			if ( String.IsNullOrEmpty(value) ) return SqlUtil.NULL;
			String format = surround ? "'{0}'" : "{0}";
			return String.Format(format, value.Replace("'", "''"));
		}

		/// <summary>
		/// Encodes the specified values for use in SQL expressions.
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static String Encode(String[] values)
		{
			return Encode(values, false);
		}

		/// <summary>
		/// Encodes the specified values for use in SQL expressions and
		/// optionally surrounds the value with single-quotes.
		/// </summary>
		/// <param name="values"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String Encode(String[] values, bool surround)
		{
			if ( values == null || values.Length < 1 )
			{
				return SqlUtil.NULL;
			}

			CommaDelimitedStringCollection csv = new CommaDelimitedStringCollection();

			foreach ( String value in values )
			{
				if ( !String.IsNullOrEmpty(value) )
				{
					csv.Add(SqlUtil.Encode(value.Trim(), surround));
				}
			}

			return csv.ToString();
		}

		#endregion Encode
	}

	#region SqlComparisonType Enum

	/// <summary>
	/// Enumeration of SQL expression comparison types.
	/// </summary>
	public enum SqlComparisonType
	{
		/// <summary>
		/// Represents = value.
		/// </summary>
		Equals,
		/// <summary>
		/// Represents LIKE value%.
		/// </summary>
		StartsWith,
		/// <summary>
		/// Represents LIKE %value.
		/// </summary>
		EndsWith,
		/// <summary>
		/// Represents LIKE %value%.
		/// </summary>
		Contains,
		/// <summary>
		/// Represents LIKE value.
		/// </summary>
		Like
	}

	#endregion SqlComparisonType Enum
}