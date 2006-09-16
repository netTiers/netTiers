using System;
using System.Data;
using System.Data.SqlClient;
using SchemaExplorer;

using GotDotNet.ApplicationBlocks.Data;
using Microsoft.ApplicationBlocks.Data;


namespace NetTiers.Wizard.Utilities
{
	/// <summary>
	/// Summary description for SqlXProperties.
	/// </summary>
	internal sealed class SqlXProperties
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlXProperties"/> class.
		/// </summary>
		private SqlXProperties()
		{			
		}


		#region "Table properties"
		
		public static object GetTableProperty(string connectionString, string tableName, string propertyName)
		{
			SqlDataReader reader = null;
			object _value = null;

			try
			{
				reader= SqlHelper.ExecuteReader(connectionString, CommandType.Text, string.Format("select * From ::fn_listextendedproperty(NULL, N'USER', N'dbo', N'Table', N'{0}', NULL, NULL) where name = '{1}' p", tableName, propertyName));
				if (reader.Read())
				{
					_value = reader["value"];
				}
				
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}

			return _value;
		}


		public static void SetTableProperty(string connectionString, string tableName, string propertyName, object propertyValue)
		{
			try
			{
				int count = (int) SqlHelper.ExecuteScalar(connectionString, CommandType.Text, string.Format("select count(*) From ::fn_listextendedproperty(NULL, N'USER', N'dbo', N'Table', N'{0}', NULL, NULL) where name = {1} p", tableName, propertyName));
		
				if (count == 1)
				{
					SqlParameter[] cmd = new SqlParameter[6];
					cmd[0] = new SqlParameter("@name", propertyName);
					cmd[1] = new SqlParameter("@value", propertyValue);
					cmd[2] = new SqlParameter("@level0type", "USER");
					cmd[3] = new SqlParameter("@level0name", "dbo");
					cmd[4] = new SqlParameter("@level1type", "TABLE");
					cmd[5] = new SqlParameter("@level1name", tableName);
					
					SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure,  "sp_updateextendedproperty", cmd);
				}
				else
				{
					SqlParameter[] cmd = new SqlParameter[6];
					cmd[0] = new SqlParameter("@name", propertyName);
					cmd[1] = new SqlParameter("@value", propertyValue);
					cmd[2] = new SqlParameter("@level0type", "USER");
					cmd[3] = new SqlParameter("@level0name", "dbo");
					cmd[4] = new SqlParameter("@level1type", "TABLE");
					cmd[5] = new SqlParameter("@level1name", tableName);
					
					SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure,  "sp_addextendedproperty", cmd);
				}
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		#endregion


		#region "Column properties"
		
		public static object GetTableColumnProperty(string connectionString, string tableName, string columnName, string propertyName)
		{
			SqlDataReader reader = null;
			object _value = null;

			try
			{
				reader= SqlHelper.ExecuteReader(connectionString, CommandType.Text, string.Format("select * From ::fn_listextendedproperty(NULL, N'USER', N'dbo', N'Table', N'{0}', N'Column', '{1}') where name = '{2}' p", tableName, columnName, propertyName));
				if (reader.Read())
				{
					_value = reader["value"];
				}
				
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}

			return _value;
		}


		public static void SetTableColumnProperty(string connectionString, string tableName, string columnName, string propertyName, object propertyValue)
		{
			try
			{
				int count = (int) SqlHelper.ExecuteScalar(connectionString, CommandType.Text, string.Format("select count(*) From ::fn_listextendedproperty(NULL, N'USER', N'dbo', N'Table', N'{0}', N'Column', '{1}') where name = {2} p", tableName, columnName, propertyName));
		
				if (count == 1)
				{
					SqlParameter[] cmd = new SqlParameter[8];
					cmd[0] = new SqlParameter("@name", propertyName); //MS_Description
					cmd[1] = new SqlParameter("@value", propertyValue);
					cmd[2] = new SqlParameter("@level0type", "USER");
					cmd[3] = new SqlParameter("@level0name", "dbo");
					cmd[4] = new SqlParameter("@level1type", "TABLE");
					cmd[5] = new SqlParameter("@level1name", tableName);
					cmd[6] = new SqlParameter("@level2type", "COLUMN");
					cmd[7] = new SqlParameter("@level2name", columnName);
					
					SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure,  "sp_updateextendedproperty", cmd);
				}
				else
				{
					SqlParameter[] cmd = new SqlParameter[8];
					cmd[0] = new SqlParameter("@name", propertyName);
					cmd[1] = new SqlParameter("@value", propertyValue); //MS_Description
					cmd[2] = new SqlParameter("@level0type", "USER");
					cmd[3] = new SqlParameter("@level0name", "dbo");
					cmd[4] = new SqlParameter("@level1type", "TABLE");
					cmd[5] = new SqlParameter("@level1name", tableName);
					cmd[6] = new SqlParameter("@level2type", "COLUMN");
					cmd[7] = new SqlParameter("@level2name", columnName);
					
					SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure,  "sp_addextendedproperty", cmd);
				}
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		#endregion

/*
		public static void SaveDescription(TableSchema table, string description)
		{
			try
			{
				int count = (int) SqlHelper.ExecuteScalar(table.Database.ConnectionString, CommandType.Text, string.Format("select count(*) From ::fn_listextendedproperty(NULL, N'USER', N'dbo', N'Table', N'{0}', NULL, NULL) p", table.Name));
		
				if (count == 1)
				{
					SqlParameter[] cmd = new SqlParameter[6];
					cmd[0] = new SqlParameter("@name", "MS_Description");
					cmd[1] = new SqlParameter("@value", description);
					cmd[2] = new SqlParameter("@level0type", "USER");
					cmd[3] = new SqlParameter("@level0name", "dbo");
					cmd[4] = new SqlParameter("@level1type", "TABLE");
					cmd[5] = new SqlParameter("@level1name", table.Name);
					
					SqlHelper.ExecuteNonQuery(table.Database.ConnectionString, CommandType.StoredProcedure,  "sp_updateextendedproperty", cmd);
				}
				else
				{
					SqlParameter[] cmd = new SqlParameter[6];
					cmd[0] = new SqlParameter("@name", "MS_Description");
					cmd[1] = new SqlParameter("@value", description);
					cmd[2] = new SqlParameter("@level0type", "USER");
					cmd[3] = new SqlParameter("@level0name", "dbo");
					cmd[4] = new SqlParameter("@level1type", "TABLE");
					cmd[5] = new SqlParameter("@level1name", table.Name);
					
					SqlHelper.ExecuteNonQuery(table.Database.ConnectionString, CommandType.StoredProcedure,  "sp_addextendedproperty", cmd);
				}
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void SaveDescription(ColumnSchema column, string description)
		{
			try
			{
				int count = (int) SqlHelper.ExecuteScalar(column.Table.Database.ConnectionString, CommandType.Text, string.Format("select count(*) From ::fn_listextendedproperty(NULL, N'USER', N'dbo', N'Table', N'{0}', N'Column', '{1}') p", column.Table.Name, column.Name));
		
				if (count == 1)
				{
					SqlParameter[] cmd = new SqlParameter[8];
					cmd[0] = new SqlParameter("@name", "MS_Description");
					cmd[1] = new SqlParameter("@value", description);
					cmd[2] = new SqlParameter("@level0type", "USER");
					cmd[3] = new SqlParameter("@level0name", "dbo");
					cmd[4] = new SqlParameter("@level1type", "TABLE");
					cmd[5] = new SqlParameter("@level1name", column.Table.Name);
					cmd[6] = new SqlParameter("@level2type", "COLUMN");
					cmd[7] = new SqlParameter("@level2name", column.Name);
					
					SqlHelper.ExecuteNonQuery(column.Table.Database.ConnectionString, CommandType.StoredProcedure,  "sp_updateextendedproperty", cmd);
				}
				else
				{
					SqlParameter[] cmd = new SqlParameter[8];
					cmd[0] = new SqlParameter("@name", "MS_Description");
					cmd[1] = new SqlParameter("@value", description);
					cmd[2] = new SqlParameter("@level0type", "USER");
					cmd[3] = new SqlParameter("@level0name", "dbo");
					cmd[4] = new SqlParameter("@level1type", "TABLE");
					cmd[5] = new SqlParameter("@level1name", column.Table.Name);
					cmd[6] = new SqlParameter("@level2type", "COLUMN");
					cmd[7] = new SqlParameter("@level2name", column.Name);
					
					SqlHelper.ExecuteNonQuery(column.Table.Database.ConnectionString, CommandType.StoredProcedure,  "sp_addextendedproperty", cmd);
				}
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}
	*/
	}
}
