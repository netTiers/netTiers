
using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace netTiers.PetShop.DataAccessLayer
{

	#region Repository Enumerations
	
	#region Load/Save Enums

	/// <summary>
	/// DeepLoad options for deep loading entities
	/// </summary>
	public enum DeepLoadType : int
	{
		/// <summary>
		/// Will Include a child property collection 1 Level Deep
		/// </summary>
		IncludeChildren = 1,
		
		/// <summary>
		/// Will Exclude a child property collection
		/// </summary>
		ExcludeChildren = 2,
					
		/// <summary>
		/// Will ignore the request and return the entity.
		/// </summary>
		Ignore = 3
	}

	/// <summary>
	/// DeepSave options for deep saving entities
	/// </summary>
	public enum DeepSaveType : int
	{
		/// <summary>Will Include a child property collection</summary>
		IncludeChildren = 1,

		/// <summary>Will Exclude a child property collection</summary>
		ExcludeChildren = 2,

		/// <summary>Will ignore the request and return the entity.</summary>
		Ignore = 3
	}
	#endregion
		
	#endregion

		
	/// <summary>
	/// Contains some helper function for SQL.
	/// </summary>
	public sealed class Utility
	{
		private Utility()
		{
			// All static methods
		}

		#region Helper Methods
		/// <summary>
		/// Get a default value for a given data type
		/// </summary>
		/// <param name="dataType">Data type for which to get the default value</param>
		/// <returns>An object of the default value.</returns>
		public static Object GetDefaultByType(DbType dataType)
		{
			switch (dataType)
			{
				case DbType.AnsiString: return string.Empty;
				case DbType.AnsiStringFixedLength: return string.Empty;
				case DbType.Binary: return new byte[] { };
				case DbType.Boolean: return false;
				case DbType.Byte: return (byte)0;
				case DbType.Currency: return 0m;
				case DbType.Date: return DateTime.MinValue;
				case DbType.DateTime: return DateTime.MinValue;
				case DbType.Decimal: return 0m;
				case DbType.Double: return 0f;
				case DbType.Guid: return Guid.Empty;
				case DbType.Int16: return (short)0;
				case DbType.Int32: return 0;
				case DbType.Int64: return (long)0;
				case DbType.Object: return null;
				case DbType.Single: return 0F;
				case DbType.String: return String.Empty;
				case DbType.StringFixedLength: return string.Empty;
				case DbType.Time: return DateTime.MinValue;
				case DbType.VarNumeric: return 0;
				default: return null;

			}
		}

		/// <summary>
		/// Get Value or Default Value from an IDataParamater
		/// Based on DbType
		/// </summary>
		/// <param name="p">The IDataParameter instance type is used to determine the default value.</param>
		/// <returns></returns>
		public static Object GetDataValue(IDataParameter p)
		{
			if (p.Value != DBNull.Value) 
				return p.Value;
			else
				return GetDefaultByType(p.DbType);
		}

		/// <summary>
		/// Checks to see if the Default Value has been set to the parameter.
		/// If it's the default value, then create.
		/// </summary>
		/// <param name="val">The value we want to check.</param>
		/// <param name="dbtype">The DbType from wich we take the default value.</param>
		/// <returns></returns>
		public static object DefaultToDBNull(object val, DbType dbtype){
			if (val == null || Object.Equals(val, GetDefaultByType(dbtype)))
				return System.DBNull.Value;
			else
				return val;
		}
		
		#region GetParameterValue<T>
		/// <summary>
        /// Generic method to return the value of a nullable parameter
        /// </summary>
        /// <typeparam name="T">Type of value to return</typeparam>
        /// <param name="parameter">Parameter from which to extract the value</param>
        /// <returns></returns>
        public static T GetParameterValue<T>(IDataParameter parameter)
        {
            if (parameter.Value == System.DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)parameter.Value;
            }
        }
		#endregion
		
		#region ConvertDatareaderToDataSet
		/// <summary>
		/// Converts a IDataReader to a DataSet.  For use when a custom stored procedure returns an <see cref="IDataReader" />, it will 
		/// convert all result sets returned as a DataSet.
		/// </summary>
		/// <param name="reader">The reader to convert</param>
		/// <returns>A dataset with one table per result in the reader</returns>
		public static DataSet ConvertDataReaderToDataSet(IDataReader reader)
		{
		    DataSet dataSet = new DataSet();
		    do
		    {
				// Create new data table
	
				DataTable schemaTable = reader.GetSchemaTable();
				DataTable dataTable = new DataTable();
	
				if (schemaTable != null)
				{
					// A query returning records was executed
	
					for (int i = 0; i < schemaTable.Rows.Count; i++)
					{
					DataRow dataRow = schemaTable.Rows[i];
					// Create a column name that is unique in the data table
					string columnName = (string)dataRow["ColumnName"]; 
					// Add the column definition to the data table
					DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
					dataTable.Columns.Add(column);
					}
	
					dataSet.Tables.Add(dataTable);
	
					// Fill the data table we just created
	
					while (reader.Read())
					{
					DataRow dataRow = dataTable.NewRow();
	
					for (int i = 0; i < reader.FieldCount; i++)
						dataRow[i] = reader.GetValue(i);
	
					dataTable.Rows.Add(dataRow);
					}
				}
				else
				{
					// No records were returned
	
					DataColumn column = new DataColumn("RowsAffected");
					dataTable.Columns.Add(column);
					dataSet.Tables.Add(dataTable);
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = reader.RecordsAffected;
					dataTable.Rows.Add(dataRow);
				}
			}
			while (reader.NextResult());
			return dataSet;
        }
		#endregion 
		
		#region SqlInjection
		private static readonly System.Text.RegularExpressions.Regex regSystemThreats = 
				new System.Text.RegularExpressions.Regex(@"\s?;\s?|\s?drop\s|\s?grant\s|^'|\s?--|\s?union\s|\s?delete\s|\s?truncate\s|\s?sysobjects\s?|\s?xp_.*?|\s?syslogins\s?|\s?sysremote\s?|\s?sysusers\s?|\s?sysxlogins\s?|\s?sysdatabases\s?|\s?aspnet_.*?|\s?exec\s?|",
                    System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

		/// <summary>
		/// A helper method to attempt to discover known SqlInjection attacks.  
		/// For use when using one of the flexible non-parameterized access methods, such as GetPaged()
		/// </summary>
		/// <param name="whereClause">string of the whereClause to check</param>
		/// <returns>true if found, false if not found </returns>
		public static bool DetectSqlInjection(string whereClause)
		{
			return regSystemThreats.IsMatch(whereClause);
		}

		/// <summary>
		/// A helper method to attempt to discover known SqlInjection attacks.  
		/// For use when using one of the flexible non-parameterized access methods, such as GetPaged()
		/// </summary>
		/// <param name="whereClause">string of the whereClause to check</param>
		/// <param name="orderBy">string of the orderBy clause to check</param>
		/// <returns>true if found, false if not found </returns>
		public static bool DetectSqlInjection (string whereClause, string orderBy)
		{
			return regSystemThreats.IsMatch(whereClause) || regSystemThreats.IsMatch(orderBy);
		}
		#endregion 
		
		#endregion
		
		
		

	}
}
