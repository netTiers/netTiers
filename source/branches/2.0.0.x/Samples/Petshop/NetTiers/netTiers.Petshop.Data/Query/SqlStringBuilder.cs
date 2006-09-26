#region Using Directives
using System;
using System.Text;
using netTiers.Petshop.Entities;
#endregion

namespace netTiers.Petshop.Data
{
	/// <summary>
	/// Represents a SQL filter expression.
	/// </summary>
	[CLSCompliant(true)]
	public class SqlStringBuilder
	{
		#region Declarations

		private StringBuilder sql = new StringBuilder();

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SqlStringBuilder class.
		/// </summary>
		public SqlStringBuilder()
		{
			this.junction = SqlUtil.AND;
			this.ignoreCase = false;
		}


		/// <summary>
		/// Initializes a new instance of the SqlStringBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SqlStringBuilder(bool ignoreCase)
		{
			this.junction = SqlUtil.AND;
			this.ignoreCase = ignoreCase;
		}

		/// <summary>
		/// Initializes a new instance of the SqlStringBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SqlStringBuilder(bool ignoreCase, bool useAnd)
		{
			this.junction = useAnd ? SqlUtil.AND : SqlUtil.OR;
			this.ignoreCase = ignoreCase;
		}

		#endregion Constructors

		#region Append

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <returns></returns>
		public SqlStringBuilder Append(String column, String searchText)
		{
			return Append(this.junction, column, searchText, this.ignoreCase);
		}

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public SqlStringBuilder Append(String column, String searchText, bool ignoreCase)
		{
			return Append(this.junction, column, searchText, ignoreCase);
		}

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public SqlStringBuilder Append(String junction, String column, String searchText, bool ignoreCase)
		{
			if ( !String.IsNullOrEmpty(searchText) )
			{
				AppendInternal(junction, new SqlExpressionParser(column, ignoreCase).Parse(searchText));
			}

			return this;
		}

		#endregion Append

		#region AppendEquals

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendEquals(String column, String value)
		{
			return AppendEquals(this.junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendEquals(String junction, String column, String value)
		{
			if ( !String.IsNullOrEmpty(value) )
			{
				AppendInternal(junction, column, "=", SqlUtil.Encode(value, true));
			}

			return this;
		}

		#endregion AppendEquals

		#region AppendNotEquals

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendNotEquals(String column, String value)
		{
			return AppendNotEquals(this.junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendNotEquals(String junction, String column, String value)
		{
			if ( !String.IsNullOrEmpty(value) )
			{
				AppendInternal(junction, column, "<>", SqlUtil.Encode(value, true));
			}

			return this;
		}

		#endregion AppendNotEquals

		#region AppendIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendIn(String column, String values)
		{
			return AppendIn(this.junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendIn(String column, String values, bool encode)
		{
			return AppendIn(this.junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendIn(String junction, String column, String values)
		{
			return AppendIn(junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendIn(String junction, String column, String values, bool encode)
		{
			if ( !String.IsNullOrEmpty(values) )
			{
				if ( encode )
				{
					String[] split = values.Split(',');
					values = SqlUtil.Encode(split, encode);

					if ( !String.IsNullOrEmpty(values) )
					{
						AppendInQuery(junction, column, values);
					}
				}
				else
				{
					AppendInQuery(junction, column, values);
				}
			}

			return this;
		}

		#endregion AppendIn

		#region AppendNotIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendNotIn(String column, String values)
		{
			return AppendNotIn(this.junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendNotIn(String column, String values, bool encode)
		{
			return AppendNotIn(this.junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendNotIn(String junction, String column, String values)
		{
			return AppendNotIn(junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendNotIn(String junction, String column, String values, bool encode)
		{
			if ( !String.IsNullOrEmpty(values) )
			{
				if ( encode )
				{
					String[] split = values.Split(',');
					values = SqlUtil.Encode(split, encode);

					if ( !String.IsNullOrEmpty(values) )
					{
						AppendNotInQuery(junction, column, values);
					}
				}
				else
				{
					AppendNotInQuery(junction, column, values);
				}
			}

			return this;
		}

		#endregion AppendNotIn

		#region AppendInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendInQuery(String column, String query)
		{
			return AppendInQuery(this.junction, column, query);
		}

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendInQuery(String junction, String column, String query)
		{
			if ( !String.IsNullOrEmpty(query) )
			{
				AppendInternal(junction, column, "IN", "(" + query + ")");
			}

			return this;
		}

		#endregion AppendInQuery

		#region AppendNotInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendNotInQuery(String column, String query)
		{
			return AppendNotInQuery(this.junction, column, query);
		}

		/// <summary>
		/// Appends the specified sub-query to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendNotInQuery(String junction, String column, String query)
		{
			if ( !String.IsNullOrEmpty(query) )
			{
				AppendInternal(junction, column, "NOT IN", "(" + query + ")");
			}

			return this;
		}

		#endregion AppendNotInQuery

		#region AppendRange

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendRange(String column, String from, String to)
		{
			return AppendRange(this.junction, column, from, to);
		}

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public SqlStringBuilder AppendRange(String junction, String column, String from, String to)
		{
			if ( !String.IsNullOrEmpty(from) || !String.IsNullOrEmpty(to) )
			{
				StringBuilder sb = new StringBuilder();

				if ( !String.IsNullOrEmpty(from) )
				{
					sb.AppendFormat("{0} >= {1}", column, SqlUtil.Encode(from, true));
				}
				if ( !String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to) )
				{
					sb.AppendFormat(" {0} ", SqlUtil.AND);
				}
				if ( !String.IsNullOrEmpty(to) )
				{
					sb.AppendFormat("{0} <= {1}", column, SqlUtil.Encode(to, true));
				}

				AppendInternal(junction, sb.ToString());
			}

			return this;
		}

		#endregion AppendRange

		#region AppendInternal

		private void AppendInternal(String junction, String column, String compare, String value)
		{
			AppendInternal(junction, String.Format("{0} {1} {2}", column, compare, value));
		}

		private void AppendInternal(String junction, String query)
		{
			if ( !String.IsNullOrEmpty(query) )
			{
				#if DEBUG
				String end = Environment.NewLine;
				#else
				String end = String.Empty;
				#endif
				String format = ( sql.Length > 0 ) ? " {0} ({1}){2}" : " ({1}){2}";
				sql.AppendFormat(format, junction, query, end);
			}
		}

		#endregion AppendInternal

		#region Methods

		/// <summary>
		/// Clears the internal string buffer.
		/// </summary>
		public void Clear()
		{
			sql.Length = 0;
		}

		/// <summary>
		/// Converts the value of this instance to a System.String.
		/// </summary>
		public override string ToString()
		{
			return sql.ToString();
		}
		
		/// <summary>
		/// Converts the value of this instance to a System.String and
		/// prepends the specified junction if the expression is not empty.
		/// </summary>
		public string ToString(String junction)
		{
			if( sql.Length > 0 )
			{
				return new StringBuilder(" ").Append(junction).Append(" ").Append(sql).ToString();
			}
			
			return String.Empty;
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// The Junction member variable.
		/// </summary>
		private String junction;

		/// <summary>
		/// Gets or sets the Junction property.
		/// </summary>
		public String Junction
		{
			get { return junction; }
			set { junction = value; }
		}

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

		#endregion Properties
	}

	/// <summary>
	/// Allows for building SQL filter expressions using strongly-typed
	/// column enumeration values.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	[CLSCompliant(true)]
	public class SqlFilterBuilder<EntityColumn> : SqlStringBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SqlFilterBuilder class.
		/// </summary>
		public SqlFilterBuilder() : base() {}

		/// <summary>
		/// Initializes a new instance of the SqlFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SqlFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SqlFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SqlFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors

		#region Append

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> Append(EntityColumn column, String searchText)
		{
			return Append(this.Junction, column, searchText, this.IgnoreCase);
		}

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> Append(EntityColumn column, String searchText, bool ignoreCase)
		{
			return Append(this.Junction, column, searchText, ignoreCase);
		}

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> Append(String junction, EntityColumn column, String searchText, bool ignoreCase)
		{
			Append(junction, GetColumnName(column), searchText, ignoreCase);
			return this;
		}

		#endregion Append

		#region AppendEquals

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendEquals(EntityColumn column, String value)
		{
			return AppendEquals(this.Junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendEquals(String junction, EntityColumn column, String value)
		{
			AppendEquals(junction, GetColumnName(column), value);
			return this;
		}

		#endregion AppendEquals

		#region AppendNotEquals

		/// <summary>
		/// Appends the specified column and value to the current filter
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendNotEquals(EntityColumn column, String value)
		{
			return AppendNotEquals(this.Junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendNotEquals(String junction, EntityColumn column, String value)
		{
			AppendNotEquals(junction, GetColumnName(column), value);
			return this;
		}

		#endregion AppendNotEquals

		#region AppendIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendIn(EntityColumn column, String values)
		{
			return AppendIn(this.Junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendIn(EntityColumn column, String values, bool encode)
		{
			return AppendIn(this.Junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendIn(String junction, EntityColumn column, String values)
		{
			return AppendIn(junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendIn(String junction, EntityColumn column, String values, bool encode)
		{
			AppendIn(junction, GetColumnName(column), values, encode);
			return this;
		}

		#endregion AppendIn

		#region AppendNotIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendNotIn(EntityColumn column, String values)
		{
			return AppendNotIn(this.Junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendNotIn(EntityColumn column, String values, bool encode)
		{
			return AppendNotIn(this.Junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendNotIn(String junction, EntityColumn column, String values)
		{
			return AppendNotIn(junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendNotIn(String junction, EntityColumn column, String values, bool encode)
		{
			AppendNotIn(junction, GetColumnName(column), values, encode);
			return this;
		}

		#endregion AppendIn

		#region AppendInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendInQuery(EntityColumn column, String query)
		{
			return AppendInQuery(this.Junction, column, query);
		}

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendInQuery(String junction, EntityColumn column, String query)
		{
			AppendInQuery(junction, GetColumnName(column), query);
			return this;
		}

		#endregion AppendInQuery

		#region AppendNotInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendNotInQuery(EntityColumn column, String query)
		{
			return AppendNotInQuery(this.Junction, column, query);
		}

		/// <summary>
		/// Appends the specified sub-query to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendNotInQuery(String junction, EntityColumn column, String query)
		{
			AppendNotInQuery(junction, GetColumnName(column), query);
			return this;
		}

		#endregion AppendNotInQuery

		#region AppendRange

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendRange(EntityColumn column, String from, String to)
		{
			return AppendRange(this.Junction, column, from, to);
		}

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public SqlFilterBuilder<EntityColumn> AppendRange(String junction, EntityColumn column, String from, String to)
		{
			AppendRange(junction, GetColumnName(column), from, to);
			return this;
		}

		#endregion AppendRange

		#region Methods

		/// <summary>
		/// Gets the column name from the specified column enumeration value.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		private String GetColumnName(EntityColumn column)
		{
			String name = EntityHelper.GetEnumTextValue(column as Enum);

			if ( String.IsNullOrEmpty(name) )
			{
				name = column.ToString();
			}

			return name;
		}

		#endregion Methods
	}
}
