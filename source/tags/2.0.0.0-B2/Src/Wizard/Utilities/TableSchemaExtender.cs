using System;
using System.Data;
using System.Data.SqlClient;
using SchemaExplorer;

using GotDotNet.ApplicationBlocks.Data;
using Microsoft.ApplicationBlocks.Data;


namespace NetTiers.Wizard.Utilities
{
	/// <summary>
	/// Summary description for TableSchemaExtender.
	/// </summary>
	public class TableSchemaExtender
	{
		public TableSchemaExtender()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		

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
