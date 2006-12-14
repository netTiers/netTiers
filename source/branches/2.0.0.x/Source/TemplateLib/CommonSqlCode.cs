/*
 * $Id: CommonSqlCode.cs,v 1.15 2006/02/27 22:06:44 bgjohnso Exp $
 * Last modified by $Author: goofsr $
 * Last modified at $Date: 2006-04-24 23:36:21 -0500 (Mon, 24 Apr 2006) $
 * $Revision: 135 $
 */
 
/*
	Common SQL related code generation methods
	Created: 12/30/03 by Oskar Austegard
	
	9/17/2004 - Dave Kekish 
	Changed sql to c# conversion for decimal type from Single to a Decimal.
	You cannot implicitly convert a objet to a Single.  
	see http://www.gotdotnet.com/Community/MessageBoard/Thread.aspx?id=263704
	
	01/26/05 - ab
	added isIntXX(), a convenience method	
*/



using CodeSmith.Engine;
using SchemaExplorer;
using System;
using System.Windows.Forms.Design;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
//using System.Diagnostics;

namespace MoM.Templates
{
	/// <summary>
	/// Common code-behind class used to simplify SQL Server based CodeSmith templates
	/// </summary>
	[DefaultProperty("ChooseSourceDatabase")]
	public class CommonSqlCode : CodeTemplate
	{
			
		// [ab 012605] convenience array for checking if a datatype is an integer 
		private readonly static DbType[] aIntegerDbTypes = new DbType[] {DbType.Int16,DbType.Int32, DbType.Int64 };
		
		private string entityFormat 		= "{0}";
		private string componentServiceFormat = "{0}Service";
		private string entityDataFormat 	= "{0}EntityData";
		private string collectionFormat 	= "{0}Collection";
		private string genericListFormat 	= "TList<{0}>";
		private string genericViewFormat 	= "VList<{0}>";
		private string providerFormat 		= "{0}Provider";
		private string interfaceFormat	 	= "I{0}";
		private string baseClassFormat 		= "{0}Base";
		private string unitTestFormat		= "{0}Test";
		private string enumFormat 			= "{0}List";
		private string manyToManyFormat		= "{0}From{1}";
		private string strippedTablePrefixes		= "tbl;tbl_";
		private string customProcedureStartsWith = "_{0}_";
		private string aliasFilePath 		= "";
		private string procedurePrefix = "";
		private string auditUserField = "";
		private string auditDateField = "";
		private bool cspUseDefaultValForNonNullableTypes = false;
		private bool parseDbColDefaultVal  = false;
		private bool changeUnderscoreToPascalCase  = false;
		private bool includeCustoms = true;

		private MethodNamesProperty methodNames = null;
		private Hashtable aliases = null;
		
		#region CSharpKeywords
		
		private string[] csharpKeywords = new string[77] 
		{
				"abstract","event", "new", "struct", 
				"as", "explicit", "null", "switch",
				"base", "extern", "object", "this",
				"bool", "false", "operator", "throw",
				"break", "finally", "out", "true",
				"byte", "fixed", "override", "try",
				"case", "float", "params", "typeof",
				"catch", "for", "private", "uint",
				"char", "foreach", "protected", "ulong",
				"checked", "goto", "public", "unchecked",
				"class", "if", "readonly", "unsafe",
				"const", "implicit", "ref", "ushort",
				"continue","in","return","using",
				"decimal","int","sbyte","virtual",
				"default","interface","sealed","volatile",
				"delegate","internal","short","void",
				"do","is","sizeof","while",
				"double","lock","stackalloc",
				"else","long","static",
				"enum","namespace", "string"
		}; 
		
		#endregion 
		
		/// <summary>
		/// Return a specified number of tabs
		/// </summary>
		/// <param name="n">Number of tabs</param>
		/// <returns>n tabs</returns>
		public string Tab(int n)
		{
			return new String('\t', n);
		}
		
		#region Diagnostics
		
		/// <summary>
		/// Gets or sets a value that indicates if output during generation should
		/// be verbose or not.
		/// </summary>
		protected bool Verbose { get { return verbose; } set { verbose = value; } }
		private bool verbose = false;

		
		/// <summary>
		/// Write a message to the debug log.
		/// </summary>
		protected void DebugWriteLine(string msg)
		{
			if (Verbose && msg != null && msg.Length > 0)
				System.Diagnostics.Debug.WriteLine(msg);
		}
		#endregion
		
		
		#region "9. Code Style public properties"
		
		[Category("09. Code style - Advanced")]
		[Description("The names to use for various generated methods.")]
		public MethodNamesProperty MethodNames
		{
			get
			{
				if ( methodNames == null )
				{
					methodNames = new MethodNamesProperty();
				}
				
				return methodNames;
			}
			set { methodNames = value; }
		}
		
		/// <summary>
		/// This property is used to set the MethodNames property from NetTiers.cst
		/// due to runtime error when trying to set it directly using an object value.
		/// </summary>
		[Browsable(false)]
		public string MethodNamesValues
		{
			get { return MethodNames.ToStringList(); }
			set { MethodNames = new MethodNamesProperty(value); }
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The table prefixes to strip from the classes name, delimited by comma.")]
		public string StrippedTablePrefixes
		{
			get {return this.strippedTablePrefixes;}
			set	{this.strippedTablePrefixes = value;}
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The format for entity class name. Parameter {0} is replaced by the trimed table name, in Pascal case.")]
		public string EntityFormat
		{
			get {return this.entityFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "EntityFormat");
				}
				this.entityFormat = value;
			}
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The format for any collection class name. Parameter {0} is replaced by the collection item class name.")]
		public string CollectionFormat
		{
			get {return this.collectionFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "CollectionFormat");
				}
				this.collectionFormat = value;
			}
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The format for the views generic class name. Parameter {0} is replaced by the name of the class that will be stored in the list.")]
		public string GenericViewFormat
		{
			get {return this.genericViewFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "GenericViewFormat");
				}
				this.genericViewFormat = value;
			}
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The format for the tables generic class name. Parameter {0} is replaced by the name of the class that will be stored in the list.")]
		public string GenericListFormat
		{
			get {return this.genericListFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "GenericListFormat");
				}
				this.genericListFormat = value;
			}
		}
		
		
		
		[Category("09. Code style - Advanced")]
		[Description("The format for any provider class name. Parameter {0} is replaced by the original class name.")]
		public string ProviderFormat
		{
			get {return this.providerFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "ProviderFormat");
				}
				this.providerFormat = value;
			}
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The format for any interface name. Parameter {0} is replaced by the original class name.")]
		public string InterfaceFormat
		{
			get {return this.interfaceFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "InterfaceFormat");
				}
				this.interfaceFormat = value;
			}
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The format for any base class name. Parameter {0} is replaced by the original class name.")]
		public string BaseClassFormat
		{
			get {return this.baseClassFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "BaseClassFormat");
				}
				this.baseClassFormat = value;
			}
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The format for any enum. Parameter {0} is replaced by the original class name.")]
		public string EnumFormat
		{
			get {return this.enumFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "EnumFormat");
				}
				this.enumFormat = value;
			}
		}
		
		[Category("09. Code style - Advanced")]
		[Description("The format for many to many methods. Parameter {0} is replaced by the secondary class name.")]
		public string ManyToManyFormat
		{
			get {return this.manyToManyFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "ManyToManyFormat");
				}
				this.manyToManyFormat = value;
			}
		}
				
		[Category("07. CRUD - Advanced")]
		[Description("If set to true, attempts to parse the Default Value of your column and set it for the default value of the property on initialization.")]
		public bool ParseDbColDefaultVal
		{
			get { return this.parseDbColDefaultVal; }
			set { this.parseDbColDefaultVal = value; }
		}
		
		[Category("09. Code style - Advanced")]
		[Description("If set to true, attempts to treat underscores, '_', as word seperators for Pascal casing.  So, a table called aspnet_users, turns into AspnetUsers.")]
		public bool ChangeUnderscoreToPascalCase
		{
			get { return this.changeUnderscoreToPascalCase; }
			set { this.changeUnderscoreToPascalCase = value; }
		}
		
		
		[Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))] 
		[Category("09. Code style - Advanced")]
		[CodeTemplateProperty(CodeTemplatePropertyOption.Optional)]
		[DefaultValue("")]		
		[Description("Optional File Path to a table/object alias file.")]
		public string AliasFilePath
		{
			get {return this.aliasFilePath;}
			set	{this.aliasFilePath = value;}
		}
		
		[Category("08. Stored procedures - Advanced")]
		[Description("The prefix to attach to the stored procs.")]
		public string ProcedurePrefix
		{
			get {return this.procedurePrefix;}
			set
			{
				if (value == null || value == string.Empty)
					return;
				this.procedurePrefix = value;
			}
		}

		[Category("07. CRUD - Advanced")]
		[Description("If you include custom stored procedures, this is the pattern that NetTiers will look for your custom stored procedures to start with. A string format will be used to match the beginning of the procedure pattern.  So, {0}=TableName, {1}=ProcedurePrefix(See Property Below).  By default NetTiers will look at tables that starts with '_{0}_', which means it will detect the procedure _TableName_GetByBirthdate, '{1}_cust_{0}' would match usp_cust_tablename_GetByAny; the appropriate methods will be generated.")]
		public string CustomProcedureStartsWith
		{
			get { return this.customProcedureStartsWith; }
			set { this.customProcedureStartsWith = value; }
		}
		
		[Category("07. CRUD - Advanced")]
		[Description("If true custom stored procedures will be detected and generated.")]
		public bool IncludeCustoms
		{
			get { return this.includeCustoms; }
			set { this.includeCustoms = value; }
		}		
		
		[Category("07. CRUD - Advanced")]
		[Description("By Default, any parameter in the Custom Stored Procedure will be a nullable type if it's a value type.  Setting this flag to true will only allow the param value types that specify NULL, such as (@param1 int=NULL), be nullable i.e. (int? param1).  While the rest of the params, @param2 int, will be regular (int param2).")]
		public bool CSPUseDefaultValForNonNullableTypes
		{
			get { return this.cspUseDefaultValForNonNullableTypes; }
			set { this.cspUseDefaultValForNonNullableTypes = value; }
		}
		
		public enum CustomNonMatchingReturnType
		{
			DataSet,
			IDataReader
		}
		#endregion

		/// <summary>
		/// Get the safe name for a data object by determining if it contains spaces or other illegal
		/// characters - if so wrap with []
		/// </summary>
		/// <param name="schemaObject">Database schema object (e.g. a table, stored proc, etc)</param>
		/// <returns>The safe name of the object</returns>
		public string GetSafeName(SchemaObjectBase schemaObject)
		{
			return GetSafeName(schemaObject.Name);
		}

		/// <summary>
		/// Get the safe name for a data object by determining if it contains spaces or other illegal
		/// characters - if so wrap with []
		/// </summary>
		/// <param name="objectName">The name of the database schema object</param>
		/// <returns>The safe name of the object</returns>
		public string GetSafeName(string objectName)
		{
			return objectName.IndexOfAny(new char[]{' ', '@', '-', ',', '!'}) > -1 ? "[" + objectName + "]" : objectName;
		}

		/// <summary>
		/// Get the camel cased version of a name.  
		/// If the name is all upper case, change it to all lower case
		/// </summary>
		/// <param name="name">Name to be changed</param>
		/// <returns>CamelCased version of the name</returns>
        public string GetCamelCaseName(string name)
        {
            if (name.Equals(name.ToUpper()) && name.IndexOf("_") == -1)
                return name.ToLower().Replace(" ", "");
            else
            {
                // first get the PascalCase version of the name (DRY)
                string pascalName = GetPascalCaseName(name);
                // now lowercase the first character to transform it to camelCase
                return pascalName.Substring(0, 1).ToLower() + pascalName.Substring(1);
            }
        }

        /// <summary>
        /// Get the Pascal cased version of a name.  
        /// </summary>
        /// <param name="name">Name to be changed</param>
        /// <returns>PascalCased version of the name</returns>
        public string GetPascalCaseName(string name)
        {
			string[] splitNames;
			if (ChangeUnderscoreToPascalCase)
			{
				char[] splitter = {'_', ' '};
				splitNames = name.Split(splitter);
			}	
			else
			{
				char[] splitter =  {' '};
				splitNames = name.Split(splitter);
			}
			
            string pascalName = "";
            foreach (string s in splitNames)
            {
                if (s.Length > 0)
                    pascalName += s.Substring(0, 1).ToUpper() + s.Substring(1);
            }

            return pascalName;
        }

        /// <summary>
        /// Get the Pascal spaced version of a name.  
        /// </summary>
        /// <param name="name">Name to be changed</param>
        /// <returns>PascalSpaced version of the name</returns>
        public string PascalToSpaced(string name)
        {
            Regex regex = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
            return regex.Replace(name, " ${x}");
        }

        /// <summary>
        /// Get the Pascal spaced version of a name.  
        /// </summary>
        /// <param name="name">Name to be changed</param>
        /// <returns>PascalSpaced version of the name</returns>
        public string GetPascalSpacedName(string name)
        {
            return PascalToSpaced(GetClassName(name));
        }		

		/// <summary>
		/// Remove any non-word characters from a SchemaObject's name (word characters are a-z, A-Z, 0-9, _)
		/// so that it may be used in code
		/// </summary>
		/// <param name="schemaObject">DB Object whose name is to be cleaned</param>
		/// <returns>Cleaned up object name</returns>
		public string GetCleanName(SchemaObjectBase schemaObject)
		{
			return GetCleanName(schemaObject.Name);
		}
		
		
		/// <summary>
		/// Applies the configured string format to the table module
		/// </summary>
		private string ApplyBaseClassFormat(string className)
		{
			return string.Format(baseClassFormat, className);
		}
		
		#region Business object class name
		/// <summary>
		/// Gets the abstract class name of a table.
		/// </summary>
		public string GetAbstractClassName(string tableName)
		{
			return ApplyBaseClassFormat(GetClassName(tableName));
		}
		
		/// <summary>
		/// Get the name of the IEntityKey implementation for the specified table.
		/// </summary>
		public string GetKeyClassName(string tableName)

		{
			return String.Format("{0}Key", GetClassName(tableName));
		}
		
		/// <summary>
		/// Get a partial class name from a standard class name.
		/// </summary>
		/// <param name="className">The normal class name.</param>
		public string GetPartialClassName(string className)
		{
			return string.Format("{0}.generated", className);
		}
		
		
		/// <summary>
		/// Get a service based class name from a standard class name.
		/// </summary>
		/// <param name="className">The normal class name.</param>
		public string GetServiceClassName(string className)
		{
			return string.Format("{0}Service", GetClassName(className));
		}

		/// <summary>
		/// Get a partial class name from a standard class name.
		/// </summary>
		/// <param name="className">The normal class name.</param>
		public string GetAbstractServiceClassName(string className)
		{
			return string.Format("{0}ServiceBase", GetClassName(className));
		}
		
		/// <summary>
		/// Get the proxy class name of the Data Repository.
		/// </summary>
		/// <param name="className">The normal class name.</param>
		public string GetProxyClassName(string className)
		{
			return string.Format("{0}Services", className);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string GetEnumName(string tableName)
		{
			return string.Format(this.enumFormat, GetClassName(tableName));
		}
				
		/// <summary>
		/// 
		/// </summary>
		public string GetStructName(string tableName)
		{
			return string.Format(this.entityDataFormat, GetClassName(tableName));
		}
				
		
		/// <summary>
		/// This function get the alias name for this object name.
		/// </summary>
		/// <remark>This function should not be called directly, but via the GetClassName.</remark>
		public string GetAliasName(string tableName)
		{
			tableName = GetCleanName(tableName);
			
			// If the aliases aren't loaded yet, and the filepath exists, then load the hashtable of aliases.
			if (aliases == null && File.Exists(this.aliasFilePath))
			{				
				//Debugger.Break();
				aliases = new Hashtable();
				using (StreamReader sr = new StreamReader(this.aliasFilePath))
				{
					string line;
					while ((line = sr.ReadLine()) != null)	
					{
						if (line.IndexOf(":") > 0)
						{
							aliases.Add(line.Split(':')[0], (line.Split(':')[1]));
						}
					}
				}
			}
			
			// See if our tablename is in the aliases hashtable, and if so, replace it.
			if (aliases != null)
			{
				//Debugger.Break();
				IDictionaryEnumerator alias = aliases.GetEnumerator();
				while (alias.MoveNext())
				{
					if (tableName.ToLower() == alias.Key.ToString().ToLower())
					{
						tableName = alias.Value.ToString();
						break;
					}
				}
			}
			return tableName;
		}
				
		/// <summary>
		///  Create a class name from a table name, for a business object.
		/// Is an alias file is present, use the defined mapping.
		/// Otherwise, use the cleaned table name.
		/// </summary>
		public string GetClassName(TableSchema tableName)
		{
			return GetClassName(tableName.Name);
		}
		
		/// <summary>
		///  Create a class name from a table name, for a business object.
		/// Is an alias file is present, use the defined mapping.
		/// Otherwise, use the cleaned table name.
		/// </summary>
		public string GetClassName(string tableName)
		{
			
			if (File.Exists(this.aliasFilePath))
			{			
				//See newName there is any alias for this table name
				string tableAlias = GetAliasName(tableName);
				// see if the alias and original table name are the different
				if ( string.Compare(tableName, tableAlias, true) != 0 )
					return tableAlias;

				// ok, just fall thru and allow normal stripping of prefixes
			}
						
			
			// Otherwise just use the old good method ;-) (strip prefix, remove bad char, Pascal case)
			
			// 1. strip prefix
			string newName = tableName;
			
			string[] strips = this.strippedTablePrefixes.Split(new char[] {',', ';'});
			foreach(string strip in strips)
			{
            if (newName.StartsWith(strip))
				{
					newName = newName.Remove(0, strip.Length);
					continue;
				}
			}
			
			// 2.remove space or bad characters
			newName = GetCleanName(string.Format(this.entityFormat, newName));
			
			if (Regex.IsMatch(newName, @"^[\d]"))
				newName="Entity" + newName;
				
			// 3. Set Pascal case
			return GetPascalCaseName(newName);
			
			/*
			// 3. Remove any plural - Experimental, need more grammar analysis//ref: http://www.gsu.edu/~wwwesl/egw/crump.htm
			ArrayList invariants = new ArrayList();
			invariants.Add("alias");
							
			if (invariants.Contains(name.ToLower()))
			{
				return name;
			}
			else if (name.EndsWith("ies"))
			{
				return name.Substring(0, name.Length-3) + "y";
			}
			else if (name.EndsWith("s") && !(name.EndsWith("ss") || name.EndsWith("us")))
			{
				return name.Substring(0, name.Length-1);
			}
			else
				return name;	
			*/		
		}		
		#endregion
		
		
		#region collection class name
		/// <summary>
		/// 
		/// </summary>
		public string GetAbstractCollectionClassName(string tableName)
		{
			return ApplyBaseClassFormat(GetCollectionClassName(tableName));
		}
		/// <summary>
		/// 
		/// </summary>
		public string GetCollectionClassName(string tableName)
		{
			return string.Format(genericListFormat, GetClassName(tableName));
		}
		
		public string GetViewCollectionClassName(string tableName)
		{
			return string.Format(genericViewFormat, GetClassName(tableName));
		}
		
		public string GetCollectionPropertyName(string tableName)
		{
			return string.Format(collectionFormat, GetClassName(tableName));
		}
		
		#endregion

		#region Provider class name
		/// <summary>
		/// 
		/// </summary>
		public string GetProviderName(string tableName)
		{
			return string.Format(providerFormat, GetClassName(tableName));
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string GetProviderClassName(string tableName)
		{
			return GetProviderName(tableName);
		}
		
		/*public string GetProviderDecoratorClassName(string tableName)
		{
			return string.Format(decoratorFormat, GetProviderClassName(tableName));
		}*/
		/// <summary>
		/// 
		/// </summary>
		public string GetIProviderName(string tableName)
		{
			return string.Format(interfaceFormat, GetProviderClassName(tableName));
		}
		/// <summary>
		/// 
		/// </summary>
		public string GetProviderBaseName(string tableName)
		{
			return ApplyBaseClassFormat(GetProviderClassName(tableName));
		}
		/// <summary>
		/// 
		/// </summary>
		public string GetProviderTestName(string tableName)
		{
			return string.Format(unitTestFormat, GetClassName(tableName));
		}
		#endregion
		
		#region Factory class name
				
		/// <summary>
		/// 
		/// </summary>
		public string GetAbstractRepositoryClassName(string tableName)
		{
			return ApplyBaseClassFormat(GetRepositoryClassName(tableName));
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string GetRepositoryClassName(string tableName)
		{
			return GetProviderName(tableName);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		public string GetRepositoryTestClassName(string tableName)
		{
			return string.Format(unitTestFormat, GetClassName(tableName));
		}
		#endregion
		
        #region 6b - Web Advanced Options
        /// <summary>
        /// Build and return a concatened list of columns that are contained in the specified key. (ex: Column1, Column2() )
        /// </summary>
        /// <param name="keys"> the key instance.</param>
        public string GetDataKeyNames(ColumnSchemaCollection keys)
        {
            StringBuilder Name = new StringBuilder();
            for (int x = 0; x < keys.Count; x++)
            {
                Name.Append(GetPropertyName(keys[x].Name));
                if (x < keys.Count - 1)
                {
                    Name.Append(", ");
                }
            }
            return Name.ToString();
        }

        /// <summary>
        /// Returns TableSchemaCollection of tables by a fk
        /// </summary>
        /// <param name="col"></param>
        /// <param name="sourceTables"></param>
        /// <returns></returns>
        public TableSchemaCollection GetTablesCollectionByFk(ColumnSchema col, TableSchemaCollection sourceTables)
        {
            TableSchemaCollection SourceTablesRelated = new TableSchemaCollection();

            for (int x = 0; x < sourceTables.Count; x++)
            {
                TableSchema SourceTable = sourceTables[x];
                foreach (ColumnSchema tCol in SourceTable.Columns)
                {
                    if (col.Name == tCol.Name && col.SystemType == tCol.SystemType && tCol.IsForeignKeyMember && !tCol.IsPrimaryKeyMember)
                        SourceTablesRelated.Add(SourceTable);
                }
            }

            return SourceTablesRelated;
        }

        #endregion

		/// <summary>
		/// Remove any non-word characters from a name (word characters are a-z, A-Z, 0-9, _)
		/// so that it may be used in code
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>Cleaned up object name</returns>
		public string GetCleanName(string name)
		{
			return Regex.Replace(name, @"[\W]", "");
		}
		
		/// <summary>
		/// Remove any non-word characters from a name (word characters are a-z, A-Z, 0-9, _)
		/// with the exception of a period (.)
		/// so that it may be used in code
		/// </summary>
		/// <remarks>
		///		Meant to be used to format things like namespaces and database names.
		///	</remarks>
		/// <param name="name">name to be cleaned</param>
		/// <returns>Cleaned up object name</returns>
		public string GetCleanName2(string name)
		{
			return Regex.Replace(name, @"[^A-Za-z0-9_\.]", "");
		}
		
		/// <summary>
		/// Transform the name of a column into a public class property name.
		/// </summary>
		public string GetPropertyName(ColumnSchema column)
		{
			if (column == null)
				return "";
				
		   	return GetPropertyName(column.Name);
		}
		
		/// <summary>
		/// Transform a name into a public class property name.
		/// </summary>
		public string GetPropertyName(string name)
		{
		   	name = Regex.Replace(name, @"[\W]", "");
		   	name = name.TrimStart(new char[] {'_', '-', '+', '=', '*'});
			name = GetPascalCaseName(name);
			
			if (Regex.IsMatch(name, @"^[\d]"))
				name="Data" + name;
			return name;
		}
		
		/// <summary>
		/// Gets the expression used to set the property value in an entity.  Specificly used to handle nullable columns.
		/// </summary>
		/// <param name="column">The column object </param>
		/// <param name="containerName">The object that has a string indexer for the column (DataRow, IDataReader, etc)</param>
		/// <param name="objectName">The object instance name.</param>
		/// <param name="indent">How tabs should the code be indented</param>
		/// <returns>An expression that sets the property based on contents of the column in the container.</returns>
		/// <remarks>This method should not append the trailing semicolon.</remarks>
		public string GetObjectPropertySetExpression(ColumnSchema column, string containerName, string objectName, int indent)
		{
			if ( column.AllowDBNull )
			{
				return string.Format("{2} = ({1}.IsDBNull({1}.GetOrdinal(\"{0}\")))?null:({3}){1}[\"{0}\"]",
						/*0*/column.Name,
						/*1*/containerName,
						/*2*/GetObjectPropertyAccessor(column,objectName),
						/*3*/GetCSType(column));
			}
			else
			{
				// regular NOT NULL data types, set to default value for type if null
				return string.Format("{2} = ({3}){1}[\"{0}\"]",
					/*0*/column.Name,
					/*1*/containerName,
					/*2*/GetObjectPropertyAccessor(column,objectName),
					/*3*/GetCSType(column),
					/*4*/GetCSDefaultByType(column));
			}
		}
		
		/// <summary>
		/// Gets the expression used to set the property value in an entity.  Specificly used to handle nullable columns.
		/// </summary>
		/// <param name="column">The column object </param>
		/// <param name="containerName">The object that has a string indexer for the column (DataRow, IDataReader, etc)</param>
		/// <param name="objectName">The object instance name.</param>
		/// <param name="indent">How tabs should the code be indented</param>
		/// <returns>An expression that sets the property based on contents of the column in the container.</returns>
		/// <remarks>This method should not append the trailing semicolon.</remarks>
		public string GetOriginalObjectPropertySetExpression(ColumnSchema column, string containerName, string objectName, int indent)
		{
			if ( column.AllowDBNull )
			{
				return string.Format("{2} = ({1}.IsDBNull({1}.GetOrdinal(\"{0}\")))?null:({3}){1}[\"{0}\"]",
						/*0*/column.Name,
						/*1*/containerName,
						/*2*/GetOriginalObjectPropertyAccessor(column,objectName),
						/*3*/GetCSType(column));
			}
			else
			{
				// regular NOT NULL data types, set to default value for type if null
				return string.Format("{2} = ({3}){1}[\"{0}\"]",
					/*0*/column.Name,
					/*1*/containerName,
					/*2*/GetOriginalObjectPropertyAccessor(column,objectName),
					/*3*/GetCSType(column),
					/*4*/GetCSDefaultByType(column));
			}
		}

		/// <summary>
		/// Gets the expression used to set the property value in an entity.  Specificly used to handle nullable columns.
		/// </summary>
		/// <param name="column">The column object </param>
		/// <param name="containerName">The object that has a string indexer for the column (DataRow, IDataReader, etc)</param>
		/// <param name="objectName">The object instance name.</param>
		/// <param name="indent">How tabs should the code be indented</param>
		/// <returns>An expression that sets the property based on contents of the column in the container.</returns>
		/// <remarks>This method should not append the trailing semicolon.</remarks>
		public string GetDatasetPropertySetExpression(ColumnSchema column, string containerName, string objectName, int indent)
		{
			if ( column.AllowDBNull )
			{
				return string.Format("{2} = (Convert.IsDBNull({1}[\"{0}\"]))?null:({3}){1}[\"{0}\"]",
						/*0*/column.Name,
						/*1*/containerName,
						/*2*/objectName,
						/*3*/GetCSType(column));
			}
			else
			{
				// regular NOT NULL data types, set to default value for type if null
				return string.Format("{2} = ({3}){1}[\"{0}\"]",
					/*0*/column.Name,
					/*1*/containerName,
					/*2*/objectName,
					/*3*/GetCSType(column),
					/*4*/GetCSDefaultByType(column));
			}
		}
		
		/// <summary>
		/// Gets the expression used to set the property value in an entity.  Specificly used to handle nullable columns.
		/// </summary>
		/// <param name="column">The column object </param>
		/// <param name="containerName">The object that has a string indexer for the column (DataRow, IDataReader, etc)</param>
		/// <param name="objectName">The object instance name.</param>
		/// <param name="indent">How tabs should the code be indented</param>
		/// <returns>An expression that sets the property based on contents of the column in the container.</returns>
		/// <remarks>This method should not append the trailing semicolon.</remarks>
		public string GetObjectPropertySetExpression(ViewColumnSchema column, string containerName, string objectName, int indent)
		{
			if ( column.AllowDBNull )
			{
				// nullable reference types (strings), set to null if null retrieved from database
				return string.Format("{2} = ({1}.IsDBNull({1}.GetOrdinal(\"{0}\")))?null:({3}){1}[\"{0}\"]",
					/*0*/column.Name,
					/*1*/containerName,
					/*2*/GetObjectPropertyAccessor(column,objectName),
					/*3*/GetCSType(column));
			}
			else
			{
				// regular NOT NULL data types, set to default value for type if null
				return string.Format("{2} = ({3}){1}[\"{0}\"]",
					/*0*/column.Name,
					/*1*/containerName,
					/*2*/GetObjectPropertyAccessor(column,objectName),
					/*3*/GetCSType(column),
					/*4*/GetCSDefaultByType(column));
			}
		}

		/// <summary>
		/// Gets the expression used to set the property value in an entity.  Specificly used to handle nullable columns.
		/// </summary>
		/// <param name="column">The column object </param>
		/// <param name="containerName">The object that has a string indexer for the column (DataRow, IDataReader, etc)</param>
		/// <param name="objectName">The object instance name.</param>
		/// <param name="indent">How tabs should the code be indented</param>
		/// <returns>An expression that sets a temporary variable with a null value if possible.</returns>
		/// <remarks>This method should not append the trailing semicolon.</remarks>
		public string GetKeyIfNullable(ColumnSchema column, string objectName)
		{
			if ( column.AllowDBNull )
			{
				// nullable reference types (strings), set to null if null retrieved from database
				return string.Format("{2} tmp = {1} ?? {1}",
					/*0*/GetObjectPropertyAccessor(column,objectName),
					/*1*/GetCSDefaultByType(column));
			}
			return "";
		}
		
		/// <summary>
		/// Creates a string that reprensents an entity and its property.
		/// </summary>
		/// <param name="objectName">Name of the object.</param>
		/// <param name="column">Name of the column that define the property.</param>
		public string GetObjectPropertyAccessor(ColumnSchema column, string objectName)
		{
			return objectName + "." + GetPropertyName(column.Name);
		}
		
		/// <summary>
		/// Creates a string that reprensents an entity and its property.
		/// </summary>
		/// <param name="objectName">Name of the object.</param>
		/// <param name="column">Name of the column that define the property.</param>
		public string GetObjectPropertyAccessorWithDefault(ColumnSchema column, string objectName)
		{
			
			if ( column.AllowDBNull )
			{
				// nullable reference types (strings), set to null if null retrieved from database
				return string.Format("({0} ?? {1})",
					/*0*/GetObjectPropertyAccessor(column,objectName),
					/*1*/GetCSDefaultByType(column));
			}
			return objectName + "." + GetPropertyName(column.Name);
		}
		
		/// <summary>
		/// Creates a string that reprensents an entity and its property.
		/// </summary>
		/// <param name="objectName">Name of the object.</param>
		/// <param name="column">Name of the column that define the property.</param>
		public string GetOriginalObjectPropertyAccessor(ColumnSchema column, string objectName)
		{
			return objectName + ".Original" + GetPropertyName(column.Name);
		}

		/// <summary>
		/// Creates a string that reprensents an entity and its property.
		/// </summary>
		/// <param name="objectName">Name of the object.</param>
		/// <param name="column">Name of the column that define the property.</param>
		public string GetObjectPropertyAccessor(ViewColumnSchema column, string objectName)
		{
			return objectName + "." + GetPropertyName(column.Name);
		}
		
		/// <summary>
		/// Creates a string that retpresents a column as a class private member.
		/// </summary>
		/// <param name="column">the database column from which we want the generate a private member.</param>
		public string GetPrivateName(ColumnSchema column)
		{
			return GetPrivateName(column.Name);
		}
		

		
		/// <summary>
		/// Creates a string that retpresents a column as a class private member.
		/// </summary>
		/// <param name="name">the name from which we want the generate a private member.</param>
		public string GetPrivateName(string name)
		{		
		   	name = Regex.Replace(name, @"[\W]", "");
			name = GetCamelCaseName(name);
			
			foreach(string keyword in csharpKeywords)
			{
				if (keyword == name)
				{
					name = "@" + name;
				}
			}	
			
			if (Regex.IsMatch(name, @"^[\d]"))
				name="data" + name;
			
			return name;
		}

		/// <summary>
		/// Creates a string that represents a many to many relation name.
		/// </summary>
		/// <param name="junctionTableKey">The key that make the relationship.</param>
		/// <param name="junctionTableName">the table that store the relation.</param>
		public string GetManyToManyName(TableKeySchema junctionTableKey, string junctionTableName)
		{			
			return GetManyToManyName(junctionTableKey.ForeignKeyMemberColumns, junctionTableName);
		}
		
		/// <summary>
		/// Creates a string that represents a many to many relation name.
		/// </summary>
		/// <param name="columns">The columns that belong to the relationship.</param>
		/// <param name="junctionTableName">the table that store the relation.</param>
		public string GetManyToManyName(ColumnSchemaCollection columns, string junctionTableName)
		{
			StringBuilder result = new StringBuilder();
			foreach(ColumnSchema pCol in columns)
			{
				result.Append(GetCleanName(pCol.Name));
			}
			
			//See if there is any alias for this table name (check include in GetClassName)
			junctionTableName = GetClassName(junctionTableName);
			
			return string.Format(this.manyToManyFormat, result.ToString(), junctionTableName);
		}
		
		/// <summary>
		/// Check that a given key has all foreign's columns into the primary key.
		/// </summary>
		/// <param name="key">The key to check.</param>
		public bool IsJunctionKey(TableKeySchema key)
		{
			foreach(ColumnSchema col in key.ForeignKeyMemberColumns)
			{
				if (!col.IsPrimaryKeyMember)
					return false;
			}
			return true;
		}
		
		/// <summary>
		/// Check that a given table has a primary key.
		/// </summary>
		/// <param name="table">The table to check.</param>
		public bool HasPrimaryKey(TableSchema table)
		{
            if (table.GetType().GetProperty("HasPrimaryKey") != null)
            {
                if (!(bool)table.GetType().GetProperty("HasPrimaryKey").GetValue(table, null)) return false;
            }
			if (table.PrimaryKey == null || table.PrimaryKey.MemberColumns.Count == 0) return false;
			return true;
		}
		
		/// <summary>
		/// Check that a given index has all it's columns into the primary key.
		/// </summary>
		/// <param name="index">The index to check.</param>
		public bool IsPrimaryKey(IndexSchema index)
		{
			foreach(ColumnSchema col in index.MemberColumns)
			{
				if (!col.IsPrimaryKeyMember)
					return false;
			}
			return true;
		}

		/// <summary>
		/// Get the cleaned, camelcased name of a parameter
		/// </summary>
		/// <param name="par">Command Parameter</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetCleanParName(ParameterSchema par)
		{
			return GetCleanParName(par.Name);
		}

		/// <summary>
		/// Get the cleaned, camelcased version of a name
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetCleanParName(string name)
		{
			return GetCamelCaseName(GetCleanName(name));
		}

		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="column">The ColumnSchema with the name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetMemberVariableName(ColumnSchema column)
		{
			return "_" + GetCleanParName(column.Name);
		}

		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetMemberVariableName(string name)
		{
			return "_" + GetCleanParName(name);
		}
		
		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="column">The column with the name to be cleaned</param>
		/// <returns>the cleaned, pascal cases name with a _Original prefix</returns>
		public string GetOriginalMemberVariableName(ColumnSchema column)
		{
			return GetOriginalMemberVariableName(column.Name);
		}
		
		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetOriginalMemberVariableName(string name)
		{
			return "_" + GetOriginalPropertyName(name);
		}
		
		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="column">the column from which we want the name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetOriginalPropertyName(ColumnSchema column)
		{
			return GetOriginalPropertyName(column.Name);
		}
		
		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetOriginalPropertyName(string name)
		{
			return "Original" + GetPropertyName(name);
		}

		/// <summary>
		/// Get the description ext. property of a column and return as inline SQL comment
		/// </summary>
		/// <param name="schemaObject">Any database object, but typically a column</param>
		/// <returns>Object description, as inline SQL comment</returns>
		public string GetColumnSqlComment(SchemaObjectBase schemaObject)
		{
			return schemaObject.Description.Length > 0 ? "-- " + schemaObject.Description.Replace(Environment.NewLine, Environment.NewLine + "-- ") : "";
		}
		
		#region GetColumnXmlComment
		/// <summary>
		/// Gets the table's description as a well formatted string for C# XML comments.
		/// </summary>
		public string GetColumnXmlComment(TableSchema table, int indentLevel)
		{
			return GetColumnXmlComment(table.Description, indentLevel);
		}

		/// <summary>
		/// Gets the column's description as a well formatted string for C# XML comments.
		/// </summary>
		public string GetColumnXmlComment(ColumnSchema column, int indentLevel)
		{
			return GetColumnXmlComment(column.Description, indentLevel);
		}

		/// <summary>
		/// Gets the view's description as a well formatted string for C# XML comments.
		/// </summary>
		public string GetColumnXmlComment(ViewSchema view, int indentLevel)
		{
			return GetColumnXmlComment(view.Description, indentLevel);
		}

		/// <summary>
		/// Gets the table key's description as a well formatted string for C# XML comments.
		/// </summary>
		public string GetColumnXmlComment(TableKeySchema key, int indentLevel)
		{
			return GetColumnXmlComment(key.Description, indentLevel);
		}
		
		/// <summary>
		/// Internal implementation.  Gets the description text as a clean C# XML comment line.
		/// </summary>
		private string GetColumnXmlComment(string description, int indentLevel)
		{
			string linePrefix = new string('\t', indentLevel) + "/// ";
			return description.Replace(Environment.NewLine, Environment.NewLine + linePrefix);
		}
		#endregion GetColumnXmlComment
		
		#region Component/Composition Helper Methods
			/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="column">The ColumnSchema with the name to be cleaned</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetComponentMemberVariableName(ColumnSchema column)
		{
			return GetCleanParName(column.Name);
		}
		
		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name</returns>
		public string GetComponentMemberVariableName(string name)
		{
			return GetCleanParName(name);
		}
		
		public string GetForeignKeyCompositeName (string fk, TableKeySchemaCollection fkeys)
		{
			foreach (TableKeySchema key in fkeys)
			{
				foreach (ColumnSchema col in key.ForeignKeyMemberColumns)
				{
					if (col.Name == fk)
					{
						return GetPropertyName(GetClassName(key.PrimaryKeyTable.Name));
					}
				}
			}
			return "//TODO: UNKNOWN, COULD NOT FIND FOREIGN KEY COMPOSITE NAME \t";
		}
				
		public string GetCompositeClassName(string fk, TableKeySchemaCollection fkeys)
		{
			foreach (TableKeySchema key in fkeys)
			{
				foreach (ColumnSchema col in key.ForeignKeyMemberColumns)
				{
					if (col.Name == fk)
					{
						return GetClassName(key.PrimaryKeyTable.Name);
					}
				}
			}
			return "//TODO: UNKNOWN, COULD NOT FIND COMPOSITE CLASS NAME \t" ;
		}
		
		public string GetCompositeMemberVariableName(string fk, TableKeySchemaCollection fkeys)
		{
			foreach (TableKeySchema key in fkeys)
			{
				foreach (ColumnSchema col in key.ForeignKeyMemberColumns)
				{
					if (col.Name == fk)
					{
						return GetComponentMemberVariableName(GetClassName(key.PrimaryKeyTable.Name));
					}
				}
			}
			return "//TODO: UNKNOWN, COULD NOT FIND COMPOSITE MEMBER VARIABLE NAME\t ";
		}
		
				
		public string GetCompositePropertyName(string fk, TableKeySchemaCollection fkeys)
		{
			foreach (TableKeySchema key in fkeys)
			{
				foreach (ColumnSchema col in key.ForeignKeyMemberColumns)
				{
					if (col.Name == fk)
					{
						return GetPropertyName(GetClassName(key.PrimaryKeyTable.Name));
					}
				}
			}
			return "//TODO: UNKNOWN, COULD NOT FIND COMPOSITE PROPERTY NAME\t ";
		}

		public string GetFKPropertyName(string fk, TableKeySchemaCollection fkeys)
		{
			foreach (TableKeySchema key in fkeys)
			{
				foreach (ColumnSchema col in key.ForeignKeyMemberColumns)
				{
					if (col.Name == fk)
					{
						return GetPropertyName(GetClassName(key.PrimaryKeyMemberColumns[0].Name));
					}
				}
			}
			return "//TODO: UNKNOWN, COULD NOT FIND FK COLUMN PROPERTY NAME\t ";
		}
		#endregion 

/*
		/// <summary>
		/// Transform the list of sql parameters to a list of comment param for a method
		/// </summary>
		public string TransformStoredProcedureInputsToMethodComments(ParameterSchemaCollection inputParameters)
		{
			StringBuilder temp = new StringBuilder();
			for(int i=0; i<inputParameters.Count; i++)
			{
				temp.AppendFormat("{2}\t/// <param name=\"{0}\"> A <c>{1}</c> instance.</param>", GetPrivateName(inputParameters[i].Name.Substring(1)), GetCSType(inputParameters[i]).Replace("<", "&lt;").Replace(">", "&gt;"), Environment.NewLine);
			}
			
			return temp.ToString();
		}
		
*/

		/// <summary>
		/// Cleans the given text so that it can be used in a [DescriptionAttribute] attribute in C# code.
		/// </summary>
		public string GetDescriptionAttributeText(string text)
		{
			return text.Replace(Environment.NewLine, " ").Replace("\"", "'");
		}
		
		/// <summary>
		/// Determines if the given column has a user defined data type.  
		/// </summary>
		/// <remarks>
		/// User defined data types are dynamically loaded from the database where the column is from.
		/// </remarks>
		public bool IsUserDefinedType(ColumnSchema column)
		{
			// lazy load the user defined user type list
			if ( userDefinedTypes == null )
			{
				userDefinedTypes = GetUserDefinedTypes(column.Database);
			}
			
			foreach (string userDefinedType in userDefinedTypes)
			{
				// compare the data types case ignoring the case.
				if ( String.Compare(column.NativeType, userDefinedType, true) == 0 )
					return true;
			}
			return false;
		}
		
		private string[] userDefinedTypes = null;

		/// <summary>
		/// Determines if the given schema object has a user defined data type.  
		/// -- [ab] this is a generic ver of IsUserDefinedType(ColumnSchema column)
		/// </summary>
		/// <remarks>
		/// User defined data types are dynamically loaded from the database where the schema object is from.
		/// </remarks>
		public bool IsUserDefinedType<TSchemaType>(TSchemaType schemaItem) where TSchemaType:DataObjectBase
		{
			// lazy load the user defined user type list
			if ( userDefinedTypes == null )
			{
				userDefinedTypes = GetUserDefinedTypes(schemaItem.Database);
			}
			
			foreach (string userDefinedType in userDefinedTypes)
			{
				// compare the data types case ignoring the case.
				if ( String.Compare(schemaItem.NativeType, userDefinedType, true) == 0 )
					return true;
			}
			return false;
		}



		/// <summary>
		/// Get the user defined data types from the specified database.
		/// </summary>
		protected string[] GetUserDefinedTypes(DatabaseSchema database)
		{
			switch (database.Provider.Name)
			{
				case "SqlSchemaProvider":
					return GetSqlUserDefinedTypes(database);
				default:
					return new string[0];
			}
		}
		
		/// <summary>
		/// Get the user defined data types from the specified Sql Server database.
		/// </summary>
		protected string[] GetSqlUserDefinedTypes(DatabaseSchema database)
		{
			try
			{
				SqlCommand	command = new SqlCommand();
				command.CommandText = "sp_MShelptype";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = new SqlConnection(database.ConnectionString);
	   
				command.Parameters.Add("@typename", SqlDbType.NVarChar, 517);
				command.Parameters.Add("@flags", SqlDbType.NVarChar, 10);

				command.Parameters[0].Value = System.DBNull.Value;
				command.Parameters[1].Value = "uddt";  // look in user defined datatypes

				ArrayList udt = new ArrayList();
				command.Connection.Open();
				using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
				{
					while(reader.Read()) 
					{
						udt.Add(reader["UserDatatypeName"]);
					}
				}
				
				string[] userDatatypeNames = new string[ udt.Count ];
				udt.CopyTo(userDatatypeNames,0);
				return userDatatypeNames;
			}
			catch 
			{
				return new string[0]; // oh oh, should handle this better.
			}
		}

		/// <summary>
		/// Check if a column is an identity column
		/// </summary>
		/// <param name="column">DB table column to be checked</param>
		/// <returns>Identity?</returns>
		public bool IsIdentityColumn(ColumnSchema column)
		{
			// for sql server
			if (column.ExtendedProperties["CS_IsIdentity"] != null)
				return (bool)column.ExtendedProperties["CS_IsIdentity"].Value;
			
			// for access
			if (column.ExtendedProperties["Autoincrement"] != null)
				return (bool)column.ExtendedProperties["Autoincrement"].Value;
			
			// test mysql
			
			
			return false;
			
			//Autoincrement: 
			//return (bool)column.ExtendedProperties["CS_IsIdentity"].Value;
		} 
		
		/// <summary>
		/// Get's the default value of a column
		/// </summary>
		/// <param name="column">DB table column to be checked</param>
		/// <returns>string representation of the default value</returns>
		public string GetColumnDefaultValue(ColumnSchema column)
		{
			/*
			return "";
			
			// for sql server
			if (column.ExtendedProperties["CS_Default"] != null)
			{
				string value = column.ExtendedProperties["CS_Default"].Value.ToString().ToLower();
				value = value.Replace("getdate()", "DateTime.Now");
				value = value.Replace("newid()", "Guid.NewGuid()");
				
				while(value.StartsWith("(") && value.EndsWith(")"))
    			 	value= value.TrimStart('(').TrimEnd(')');
	
				if (column.DataType == DbType.Boolean)
					value = value.Contains("1") ? "true" : "false";
				else if (!IsNumericType(column) || value.IndexOf("DateTime.Now") > -1 || value.IndexOf("Guid.NewGuid()") > -1)
					value = string.Format("\"{0}\"", value);
					
				return value;
	
				
			// for access
			if (column.ExtendedProperties["DefaultValue"] != null)
				return column.ExtendedProperties["DefaultValue"].Value.ToString();
			
			// test mysql
			}
			
			*/

			return "";			
		} 
		
		/// <summary>
		/// Determines if the column is a numeric column or not.
		/// </summary>
		/// <param name="column">DB table column to be checked</param>
		/// <returns>true when Numeric, otherwise false</returns>
		public bool IsNumericType(ColumnSchema column)
		{
			switch (column.NativeType.ToLower())
			{
				case "bigint":
				case "bit":
				case "decimal":
				case "float":
				case "int":
				case "money":
				case "numeric":
				case "real":
				case "smallint":
				case "smallmoney":
				case "tinyint": return true;
				default: return false;
			}
		}

		/// <summary>
		/// Check if a column is read-only.
		/// </summary>
		public bool IsReadOnlyColumn(ColumnSchema column)
		{
			// sql server
			if (column.ExtendedProperties["CS_ReadOnly"].Value != null && (bool)column.ExtendedProperties["CS_ReadOnly"].Value)
				return true;
			
			// access, if auto inco
			if (column.ExtendedProperties["Autoincrement"] != null && (bool)column.ExtendedProperties["Autoincrement"].Value)
				return true;
				
			// Jet: if auto generate
			if (column.ExtendedProperties["Jet OLEDB:AutoGenerate"] != null && (bool)column.ExtendedProperties["Jet OLEDB:AutoGenerate"].Value)
				return true;
				
			// default
			return false;
			
			//return column.ExtendedProperties.Count == 0 || (bool)column.ExtendedProperties["CS_ReadOnly"].Value;
		}
		
		/// <summary>
		///  Check if a column is computed.
		/// </summary>
		/// <param name="column"></param>
		public bool IsComputed(ColumnSchema column)
		{
			// Sql server extended property
			if (column.ExtendedProperties["CS_IsComputed"] != null && (bool)column.ExtendedProperties["CS_IsComputed"].Value)
				return true;
			
			// sqlserver timestamp field are computed
			if (column.NativeType.ToLower() == "timestamp")
				return true;
				
			// access, if auto inco
			if (column.ExtendedProperties["Autoincrement"] != null && (bool)column.ExtendedProperties["Autoincrement"].Value)
				return true;
				
			// Jet: if auto generate
			if (column.ExtendedProperties["Jet OLEDB:AutoGenerate"] != null && (bool)column.ExtendedProperties["Jet OLEDB:AutoGenerate"].Value)
				return true;
			
			
			return false;
			
			//return (bool)column.ExtendedProperties["CS_IsComputed"].Value == true || column.NativeType.ToLower() == "timestamp";
		}
		
		/// <summary>
		///  Check if a column is a guid (uniqueidentifier).
		/// </summary>
		/// <param name="column"></param>
		public bool IsGuidColumn( ColumnSchema column )
		{
			return column.SystemType.ToString() == typeof(System.Guid).ToString();
		}

		/// <summary>
		/// Get the owner of a table.
		/// </summary>
		/// <param name="table">The table to check</param>
		/// <returns>The safe name of the owner of the table</returns>
		public string GetOwner(TableSchema table)
		{
			return (table.Owner.Length > 0) ? GetSafeName(table.Owner) + "." : "";
		}
		
		/// <summary>
		/// Get the owner of a view
		/// </summary>
		/// <param name="view">The view to check</param>
		/// <returns>The safe name of the owner of the view</returns>
		public string GetOwner(ViewSchema view)
		{
			return (view.Owner.Length > 0) ? GetSafeName(view.Owner) + "." : "";
		}

		/// <summary>
		/// Get the owner of a command
		/// </summary>
		/// <param name="command">The command to check</param>
		/// <returns>The safe name of the owner of the command</returns>
		public string GetOwner(CommandSchema command)
		{
			return (command.Owner.Length > 0) ? GetSafeName(command.Owner) + "." : "";
		}

		/// <summary>
		/// Does the command have a resultset?
		/// </summary>
		/// <param name="cmd">Command in question</param>
		/// <returns>Resultset?</returns>
		public bool HasResultset(CommandSchema cmd)
		{
			return cmd.CommandResults.Count > 0;
		}
		
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="columns">Columns for which to get the Sql parameter statement</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterStatement(ColumnSchemaCollection columns)
		{
			StringBuilder result = new StringBuilder();
			
			for(int i=0; i<columns.Count; i++)
			{
				if (i>0) result.Append(", ");
				
				result.Append(GetSqlParameterStatement(columns[i]));
				result.Append(Environment.NewLine);
				
			}	
			return result.ToString();
		}

		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterStatement(ColumnSchema column)
		{
			return GetSqlParameterStatement(column, false);
		}
		
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="isOutput">Is this an output parameter?</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterStatement(ColumnSchema column, bool isOutput)
		{
			StringBuilder param = new StringBuilder();
			param.AppendFormat("@{0} {1}", GetPropertyName(column.Name), column.NativeType);
			
			// user defined data types do not need size components
			if ( ! IsUserDefinedType(column) )
			{
			switch (column.DataType)
			{
				case DbType.Decimal:
				{
					if (column.NativeType != "real")
						param.AppendFormat("({0}, {1})", column.Precision, column.Scale);
				
					break;
				}
				// [ab 022205] now handles xxxbinary data type
				case DbType.Binary:
				// 
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				{
					if (column.NativeType != "text" && 
						column.NativeType != "ntext" && 
						column.NativeType != "timestamp" &&
						column.NativeType != "image"
						)

					{
						if (column.Size > 0)
						{
							param.AppendFormat("({0})", column.Size);
						}
					}
					break;
				}
			}
			}
			if (isOutput)
			{
				param.Append(" OUTPUT");
			}
			
			return param.ToString();
		}
		
		
		public bool IsColumnFindable(ColumnSchema column)
		{
			if (column.DataType == DbType.Binary || column.NativeType == "text" || 
					column.NativeType == "ntext" || 
					column.NativeType == "timestamp" ||
					column.NativeType == "image"
				)
				return false;
			
			return true;
		}
		
		
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="Name">the name of the parameter?</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterStatement(ColumnSchema column, string Name)
		{
			string param = "@" + GetPropertyName(Name) + " " + column.NativeType;
			
			// user defined data types do not need size components
			if ( ! IsUserDefinedType(column) )
			{
			switch (column.DataType)
			{
				case DbType.Decimal:
				{
					param += "(" + column.Precision + ", " + column.Scale + ")";
					break;
				}
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				{
					if (column.NativeType != "text" && column.NativeType != "ntext")
					{
						if (column.Size > 0)
						{
							param += "(" + column.Size + ")";
						}
					}
					break;
				}
			}	
			}
			return param;
		}
		
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="isOutput">indicates the direction</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterXmlNode(ColumnSchema column, bool isOutput)
		{
			return GetSqlParameterXmlNode(column, column.Name, isOutput, false);
		}
		
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="parameterName">the name of the parameter?</param>
		/// <param name="isOutput">indicates the direction</param>
		/// <returns>the xml Sql Parameter statement</returns>
		public string GetSqlParameterXmlNode(ColumnSchema column, string parameterName, bool isOutput)
		{
			return GetSqlParameterXmlNode(column, parameterName, isOutput, false);
		}
		
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="parameterName">the name of the parameter?</param>
		/// <param name="isOutput">indicates the direction</param>
		/// <param name ="nullDefaults">indicates whether to give each parameter a null or empty default.  (used mainly for Find sp's)</param>
		/// <returns>the xml Sql Parameter statement</returns>
		public string GetSqlParameterXmlNode(ColumnSchema column, string parameterName, bool isOutput, bool nullDefaults)
		{
			string formater = "<parameter name=\"@{0}\" type=\"{1}\" direction=\"{2}\" size=\"{3}\" precision=\"{4}\" scale=\"{5}\" param=\"{6}\" nulldefault=\"{7}\"/>";			
			
			string nullDefaultValue = "";
			if (nullDefaults)
			{
				nullDefaultValue = "null";
			}

			bool isReal = false;
			if (column.NativeType.ToLower() == "real") // SQL doesn't like precision or scale on Real
			{
				isReal = true;
			}

			return string.Format(formater, GetPropertyName(parameterName), column.NativeType, isOutput ? "Output" : "Input", column.Size, column.Precision, column.Scale, isReal ? "" : GetSqlParameterParam(column), nullDefaultValue);
		}
		
		/// <summary>
		/// Get an xml representation for a stored procedure parameter - this is for pre-existing (most likely, custom) Stored Procedures
		/// </summary>
		/// <param name="parameter">SP Parameter for which to get the Sql parameter statement</param>
		/// <returns>the xml Sql Parameter statement</returns>
		public string GetSqlParameterXmlNode(ParameterSchema parameter)
		{
			string formater = "<parameter name=\"@{0}\" type=\"{1}\" direction=\"{2}\" size=\"{3}\" precision=\"{4}\" scale=\"{5}\" param=\"{6}\" nulldefault=\"{7}\"/>";			
			
			return string.Format(	formater, 
									parameter.Name.TrimStart('@'),
									parameter.NativeType, 
									parameter.Direction.ToString(), 
									parameter.Size, 
									parameter.Precision, 
									parameter.Scale, 
									parameter.NativeType.ToLower() == "real" ? String.Empty : GetSqlParameterParam<ParameterSchema>(parameter), 
									parameter.AllowDBNull? "null":String.Empty );
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="column"></param>
		public string GetSqlParameterParam(ColumnSchema column)
		{
			string param = string.Empty;
			
			// user defined data types do not need size components
			if ( ! IsUserDefinedType(column) )
			{
			switch (column.DataType)
			{
				case DbType.Decimal:
				{
					param = "(" + column.Precision + ", " + column.Scale + ")";
					break;
				}
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.Binary:
				{
					if (column.NativeType != "text" && column.NativeType != "ntext" && column.NativeType != "image" && column.NativeType != "timestamp")
					{
						if (column.Size > 0)
						{
							param = "(" + column.Size + ")";
						}
						else if (column.Size == -1)
						{
							param = "(MAX)";
						}
					}
					break;
				}
			}	
			}
			return param;
		}

		/// <summary>
		/// 	[ab] This is a somewhat generic :) version of the singly typed GetSqlParameterParam
		/// </summary>
		/// <param name="column"></param>
		/// <remarks>
		///	
		/// </remarks>
		public string GetSqlParameterParam<TSchemaType>(TSchemaType schemaItem) where TSchemaType:DataObjectBase
		{
			string param = string.Empty;
			
			// user defined data types do not need size components
			if ( ! IsUserDefinedType<TSchemaType>(schemaItem) )
			{
			switch (schemaItem.DataType)
			{
				case DbType.Decimal:
				{
					param = "(" + schemaItem.Precision + ", " + schemaItem.Scale + ")";
					break;
				}
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.Binary:				
				{
					if (schemaItem.NativeType != "text" && schemaItem.NativeType != "ntext")
					{
						if (schemaItem.Size > 0)
						{
							param = "(" + schemaItem.Size + ")";
						}
						else if (schemaItem.Size == -1)
						{
							param = "(MAX)";
						}
					}
					break;
				}
			}	
			}
			return param;
		}
		

		/// <summary>
		/// Parse the text of a stored procedure to retrieve any comment prior to the CREATE PROC construct
		/// </summary>
		/// <param name="commandText">Command Text of the procedure</param>
		/// <returns>The procedure header comment</returns>
		public string GetSqlProcedureComment(string commandText)
		{
			string comment = "";
			// Find anything upto the CREATE PROC statement
			Regex regex = new Regex(@"CREATE\s+PROC(?:EDURE)?", RegexOptions.IgnoreCase);	
			comment = regex.Split(commandText)[0];
			//remove comment characters
			regex = new Regex(@"(-{2,})|(/\*)|(\*/)");
			comment = regex.Replace(comment, string.Empty);
			//trim and return
			return comment.Trim();
		}

		/// <summary>
		/// Get any in-line SQL comments on the same lines as parameters
		/// </summary>
		/// <param name="commandText">Command Text of the procedure</param>
		/// <returns>Hashtable of parameter comments, with parameter names as keys</returns>
		public Hashtable GetSqlParameterComments(string commandText)
		{
			Hashtable paramComments = new Hashtable();
			//Get parameter names and comments
			string pattern = @"(?<param>@\w*)[^@]*--(?<comment>.*)";
			//loop through the matches and extract the parameter and the comment, ignoring duplicates
			foreach (Match match in Regex.Matches(commandText, pattern))
				if (!paramComments.ContainsKey(match.Groups["param"].Value))
					paramComments.Add(match.Groups["param"].Value, match.Groups["comment"].Value.Trim());
			//return the hashtable
			return paramComments;
		}
		
		
		#region "Stored procedures input transformations"
		
		/// <summary>
		/// Transform the list of sql parameters to a list of method parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToMethod(ParameterSchemaCollection inputParameters)
		{
			return TransformStoredProcedureInputsToMethod(false, inputParameters);
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of method parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToMethod(bool startWithComa, ParameterSchemaCollection inputParameters)
		{
			StringBuilder temp = new StringBuilder();
			for(int i=0; i<inputParameters.Count; i++)
			{
				if ((i>0) || startWithComa)
					temp.Append(", ");

				temp.AppendFormat("{0} {1}", GetCSType(inputParameters[i]), GetPrivateName(inputParameters[i].Name.Substring(1)));
			}
			
			return temp.ToString();
		}
		
		public string TransformStoredProcedureInputsToMethod(bool startWithComa, CommandSchema command)
		{
			string temp = string.Empty;
			
			for(int i=0; i<command.InputParameters.Count; i++)
			{
				temp += (temp.Length > 0) || startWithComa ? ", " : "";
				temp += GetCSType(command.InputParameters[i]) + " " + GetPrivateName(command.InputParameters[i].Name.Substring(1));
			}
			for(int j=0; j < command.InputOutputParameters.Count; j++)
			{
				temp += (temp.Length > 0) || (startWithComa)  ? ", out " : " out ";
				temp += GetCSType(command.InputOutputParameters[j]) + " " + GetPrivateName(command.InputOutputParameters[j].Name.Substring(1));
			}
			
			return temp;
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of ExecuteXXXXX parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToDataAccess(ParameterSchemaCollection inputParameters)
		{
			return TransformStoredProcedureInputsToDataAccess(false, inputParameters);
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of ExecuteXXXXX parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToDataAccess(bool alwaysStartWithaComa, ParameterSchemaCollection inputParameters)
		{
			return TransformStoredProcedureInputsToDataAccess(alwaysStartWithaComa, inputParameters, false);
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of ExecuteXXXXX parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToDataAccess(bool alwaysStartWithaComa, ParameterSchemaCollection inputParameters, bool useCustomPrefix)
		{
			StringBuilder temp = new StringBuilder();
			for(int i=0; i<inputParameters.Count; i++)
			{
				if ( (i>0) || alwaysStartWithaComa )
					temp.Append(", ");

				if ( useCustomPrefix )
				{
					temp.Append( GetCustomVariableName(inputParameters[i].Name.Substring(1) , inputParameters[i].Command) );
				}
				else
				{
					temp.Append( GetPrivateName(inputParameters[i].Name.Substring(1)) );
				}
			}
			
			return temp.ToString();
		}
						
		/// <summary>
		/// Transform the list of sql parameters to a list of comment param for a method
		/// </summary>
		public string TransformStoredProcedureInputsToMethodComments(ParameterSchemaCollection inputParameters)
		{
			StringBuilder temp = new StringBuilder();
			for(int i=0; i<inputParameters.Count; i++)
			{
				temp.AppendFormat("{2}\t\t/// <param name=\"{0}\"> A <c>{1}</c> instance.</param>", GetPrivateName(inputParameters[i].Name.Substring(1)).Replace("@", ""), GetCSType(inputParameters[i]).Replace("<", "&lt;").Replace(">", "&gt;"), "\r\n");
			}
			
			return temp.ToString();
		}

		/// <summary>
		/// Transform the list of sql parameters to a list of comment param for a method
		/// </summary>
		public string TransformStoredProcedureInputsToMethodComments(CommandSchema command)
		{
			string temp = string.Empty;
			for(int i=0; i<command.InputParameters.Count; i++)
			{
				temp += string.Format("{2}\t\t\t/// <param name=\"{0}\"> A <c>{1}</c> instance.</param>", GetPrivateName(command.InputParameters[i].Name.Substring(1)), GetCSType(command.InputParameters[i]), "\r\n");
			}
			for(int i=0; i<command.InputOutputParameters.Count; i++)
			{
				temp += string.Format("{2}\t\t\t/// <param name=\"{0}\"> An output  <c>{1}</c> instance.</param>", GetPrivateName(command.InputOutputParameters[i].Name.Substring(1)).Replace("@", ""), GetCSType(command.InputOutputParameters[i]), Environment.NewLine);
			}
			
			return temp;
		}

		#endregion
		
		#region "Stored procedures output transformations"
		
		/// <summary>
		/// Transform the list of sql parameters to a list of method parameters.
		/// </summary>
		public string TransformStoredProcedureOutputsToMethod(ParameterSchemaCollection outputParameters)
		{
			return TransformStoredProcedureOutputsToMethod(false, outputParameters);
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of method parameters.
		/// </summary>
		public string TransformStoredProcedureOutputsToMethod(bool startWithComa, ParameterSchemaCollection outputParameters)
		{
			StringBuilder temp = new StringBuilder();
			for(int i=0; i<outputParameters.Count; i++)
			{
				if ((i>0) || startWithComa)
					temp.Append(", ");

				temp.AppendFormat("ref {0} {1}", GetCSType(outputParameters[i]), GetPrivateName(outputParameters[i].Name.Substring(1)));
			}
			
			return temp.ToString();
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of ExecuteXXXXX parameters.
		/// </summary>
		public string TransformStoredProcedureOutputsToDataAccess(ParameterSchemaCollection outputParameters)
		{
			return TransformStoredProcedureOutputsToDataAccess(false, outputParameters);
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of ExecuteXXXXX parameters.
		/// </summary>
		public string TransformStoredProcedureOutputsToDataAccess(bool alwaysStartWithaComa, ParameterSchemaCollection outputParameters)
		{
			return TransformStoredProcedureOutputsToDataAccess(alwaysStartWithaComa, outputParameters, false);
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of ExecuteXXXXX parameters.
		/// </summary>
		public string TransformStoredProcedureOutputsToDataAccess(bool alwaysStartWithaComa, ParameterSchemaCollection outputParameters, bool useCustomPrefix)
		{
			StringBuilder temp = new StringBuilder();
			for(int i=0; i<outputParameters.Count; i++)
			{
				if ( (i>0) || alwaysStartWithaComa )
					temp.Append(", ");

				if ( useCustomPrefix )
				{
					temp.AppendFormat("ref {0}", GetCustomVariableName(outputParameters[i].Name.Substring(1), outputParameters[i].Command) );
				}
				else
				{
					temp.AppendFormat("ref {0}", GetPrivateName(outputParameters[i].Name.Substring(1)) );
				}
			}
			
			return temp.ToString();
		}
						
		/// <summary>
		/// Transform the list of sql parameters to a list of comment param for a method
		/// </summary>
		public string TransformStoredProcedureOutputsToMethodComments(ParameterSchemaCollection outputParameters)
		{
			StringBuilder temp = new StringBuilder();
			for(int i=0; i<outputParameters.Count; i++)
			{
				temp.AppendFormat("{2}\t\t\t/// <param name=\"{0}\"> A <c>{1}</c> instance.</param>", GetPrivateName(outputParameters[i].Name.Substring(1)).Replace("@", ""), GetCSType(outputParameters[i]).Replace("<", "&lt;").Replace(">", "&gt;"), Environment.NewLine);
			}
			
			return temp.ToString();
		}

		#endregion
		
		/// <summary>
		/// Returns a string that reprenst the given columns formated as method parameters definitions. (ex: string param1, int param2)
		/// </summary>
		/// <param name="columns">The columns to transform.</param>
		public string GetFunctionHeaderParameters(ColumnSchemaCollection columns)
		{
			StringBuilder output = new StringBuilder();
			for (int i = 0; i < columns.Count; i++)
			{
				output.AppendFormat("{0} {1}", GetCSType(columns[i]), GetPrivateName(columns[i].Name));
				if (i < columns.Count - 1)
				{
					output.Append(", ");
				}
			}
			return output.ToString();
		}
		
		
		/// <summary>
		/// Returns a string that reprenst the given columns formated as method parameters call. (ex: param1, param2)
		/// </summary>
		/// <param name="columns">The columns to transform.</param>
		public string GetFunctionCallParameters(ColumnSchemaCollection columns)
		{
			return GetFunctionCallParameters(columns, string.Empty, null);
		}
		
		public delegate bool AppendIf(ColumnSchema col);
		
		/// <summary>
		/// Returns a string that reprenst the given columns formated as method parameters call. (ex: param1, param2)
		/// </summary>
		/// <param name="columns">The columns to transform.</param>
		public string GetFunctionCallParameters(ColumnSchemaCollection columns, string appendString, AppendIf condition)
		{			
			StringBuilder output = new StringBuilder();
			for (int i = 0; i < columns.Count; i++)
			{		
				output.Append(GetPrivateName(columns[i].Name));
				if (condition != null)
				{
					if (condition(columns[i]))
					{
						output.Append(appendString);
					}
				}
					
				if (i < columns.Count - 1)
				{
					output.Append(", ");
				}
			}
			return output.ToString();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="columns"></param>
		public string GetFunctionEntityParameters(ColumnSchemaCollection columns)
		{
			StringBuilder output = new StringBuilder();
			for (int i = 0; i < columns.Count; i++)
			{
				output.AppendFormat("entity.{0}", GetPropertyName(columns[i].Name));
				if (i < columns.Count - 1)
				{
					output.Append(", ");
				}
			}
			return output.ToString();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="columns"></param>
		/// <param name="accessor"></param>
		public string GetFunctionThisParametersWithNullable(ColumnSchemaCollection columns, string accessor)
		{
			StringBuilder output = new StringBuilder();
			for (int i = 0; i < columns.Count; i++)
			{
				if (!columns[i].AllowDBNull)
					output.AppendFormat("{1}.{0}", GetPropertyName(columns[i].Name), accessor);
				else
					output.AppendFormat("({1}.{0} ?? {2})", GetPropertyName(columns[i].Name), accessor, GetCSDefaultByType(columns[i]));
				
				if (i < columns.Count - 1)
				{
					output.Append(", ");
				}
			}
			return output.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="columns"></param>
		/// <param name="objectName"></param>
		public string GetFunctionObjectParameters(ColumnSchemaCollection columns, String objectName)
		{
			StringBuilder output = new StringBuilder();
			for (int i = 0; i < columns.Count; i++)
			{
				output.AppendFormat("{1}.{0}", GetPropertyName(columns[i].Name), objectName);

				if (i < columns.Count - 1)
				{
					output.Append(", ");
				}
			}
			return output.ToString();
		}

		/// <summary>
		/// Gets the <see cref="System.ComponentModel.DataObjectField" /> Ctor Params
		/// based on the schema information on a column.
		/// The 4 params are 
		///	1. indicates whether the field is the primary key 
		/// 2. whether the field is a database identity field
		/// 3. whether the field can be null
		/// 4. sets the length of the field
		/// </summary>
		/// <param name="column">Column</param>
		/// <returns>The ctor params for the <see cref="System.ComponentModel.DataObjectField" /></returns>
		public string GetDataObjectFieldCallParams(ColumnSchema column)
		{
			return string.Format("{0}, {1}, {2}{3}",
				/*0*/ column.IsPrimaryKeyMember.ToString().ToLower(),
				/*1*/ IsIdentityColumn(column).ToString().ToLower(),
				/*2*/ column.AllowDBNull.ToString().ToLower(),
				/*3*/ (CanCheckLength(column) ? ", " + column.Size.ToString() : ""));
		}
		
		/// <summary>
		/// Gets the parameters needed for the ColumnEnumAttribute class
		/// for the specified column.
		/// </summary>
		/// <param name="column"></param>
		public string GetColumnEnumAttributeParams(ColumnSchema column)
		{
			return string.Format("\"{0}\", typeof({1}), System.Data.{2}, ",
				column.Name,
				GetCSTypeWithoutNullable(column),
				GetDbType(column)
			) + GetDataObjectFieldCallParams(column);
		}

		/// <summary>
		/// Convert database types to C# types
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetCSType(DataObjectBase field)
		{		
			if (field.NativeType.ToLower() == "real")
				return "System.Single" + (field.AllowDBNull?"?":"");
			else if (field.NativeType.ToLower() == "xml")
				return "string";
			//else if (field.NativeType.ToLower() == "xml")
			//	return "System.Xml.XmlNode";
			///Only for Custom Stored Procedures that allow nulls for every param
			else if (CSPUseDefaultValForNonNullableTypes 
					&& (field is ParameterSchema)
					&&	!IsCSReferenceDataType(field))
			{			
				if (!DefaultIsNull(	(ParameterSchema)field ))
					return field.SystemType.ToString();
				else 
					return field.SystemType.ToString() + "?";
			}
			else if (!IsCSReferenceDataType(field) && field.AllowDBNull)
			{				
				return field.SystemType.ToString() + "?";
			}
			else
				return field.SystemType.ToString();
		}
		
		#region Defualt Param Value
		
        public static string parseParameterRegex = @"
CREATE\s+PROC(?:EDURE)?                               # find the start of the stored procedure
.*?                                                   # skip all content until we get to the name of the parameter that we are looking for
{0}                                                   # name of the parameter we are interested in
\s+[\w\.\(\)\[\]]+                                    # parameter data type
(?:\s*\=\s*(?<default>(?:'[^']*' | [\w]+)))?          # parameter default value";

		///<summary>
		/// Checks a Parameter Schema if NULL is set to the default value of that procedure param
		///</summary>
		public bool DefaultIsNull(ParameterSchema param)
		{
			if (param == null)
				return false;
			
			System.Text.RegularExpressions.Regex DefaultParamRegex = new System.Text.RegularExpressions.Regex(String.Format(parseParameterRegex, param.Name), 
				System.Text.RegularExpressions.RegexOptions.IgnoreCase | 
				System.Text.RegularExpressions.RegexOptions.Multiline | 
				System.Text.RegularExpressions.RegexOptions.Singleline | 
				System.Text.RegularExpressions.RegexOptions.CultureInvariant | 
				System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace);

		
            System.Text.RegularExpressions.Match match = DefaultParamRegex.Match(param.Command.CommandText);
            if (match != null && match.Success)
			{
				if (match.Groups["default"].Value != null && match.Groups["default"].Value.ToString().Trim().ToUpper() == "NULL")
					return true;
			}	
			return false;
		}
		#endregion 
		
		/// <summary>
		/// Convert database types to C# types, withou nullable support.
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetCSTypeWithoutNullable(DataObjectBase field)
		{
			if (field.NativeType.ToLower() == "real")
				return "System.Single";
			else if (field.NativeType.ToLower() == "xml")
				return "string";
			//else if (field.NativeType.ToLower() == "xml")
			//	return "System.Xml.XmlNode";
			else
				return field.SystemType.ToString();
			//return GetCSType(field.DataType);
		}
		
		/// <summary>
		/// Return the DbType enum entry of a specified column. It's a hack of the SchemaExplorer property, as it do not support Xml column properly.
		/// </summary>
		/// <param name="field">Column or parameter</param>
		public string GetDbType(DataObjectBase field)
		{
			if (field.NativeType.ToLower() == "xml")
			{
				return "DbType.Xml";
			}
			else
			{
				return "DbType." + field.DataType.ToString();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="column"></param>
		public string GetCSDefaultByType(DataObjectBase column)
		{
			return GetCSDefaultByType(column, false);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="column"></param>
		public string GetCSDefaultByType(DataObjectBase column, bool forceReturnDefault)
		{
			// first attempt to see if the DB defines any default values for this
			// column.  If so, return it.
			string defaultValue;
			if (ParseDbColDefaultVal && !forceReturnDefault)
			{
				defaultValue = GetCSDefaultValueByType(column);
				if (defaultValue != null)
					return defaultValue;
			}

			if (column.NativeType.ToLower() == "real")
				return "0.0F";
			else
			{
				DbType dataType = column.DataType;
				switch (dataType)
				{
					case DbType.AnsiString: 
						return "string.Empty";
						
					case DbType.AnsiStringFixedLength: 
						return "string.Empty";
					
					case DbType.String: 
						return "string.Empty";
						
					case DbType.Boolean: 
						return "false";
					
					case DbType.StringFixedLength: 
						return "string.Empty";
						
					case DbType.Guid: 
						return "Guid.Empty";
					
					
					//Answer modified was just 0
					case DbType.Binary: 
						return "new byte[] {}";
					
					//Answer modified was just 0
					case DbType.Byte:
						return "(byte)0";
						//return "{ 0 }";
					
					case DbType.Currency: 
						return "0";
					
					case DbType.Date: 
						return "DateTime.MinValue";
					
					case DbType.DateTime: 
						return "DateTime.MinValue";
					
					case DbType.Decimal: 
						return "0.0m";
						//return "0M";
						//return "0.0M";
					
					case DbType.Double: 
						return "0.0f";
					
					case DbType.Int16: 
						return "(short)0";
						
					case DbType.Int32: 
						return "(int)0";
						
					case DbType.Int64: 
						return "(long)0";
					
					case DbType.Object: 
						return "null";
					
					case DbType.Single: 
						return "0F";
					
					//case DbType.Time: return "DateTime.MaxValue";
					case DbType.Time: return "new DateTime(1900,1,1,0,0,0,0)";
					case DbType.VarNumeric: return "0";
						//the following won't be used
						//		case DbType.SByte: return "0";
						//		case DbType.UInt16: return "0";
						//		case DbType.UInt32: return "0";
						//		case DbType.UInt64: return "0";
					default: return "null";
				}
			}
		}
		
		/// <summary>
		/// This method returns the default value from the database if it is available.  It returns null
		/// if no default value could be parsed.
		/// 
		/// NOTE: rudimentary support for default values with computations/functions is built in.  Right now th
		///   only supported function is getdate().  Any others can be added below if desired.
		/// </summary>
		/// <param name="column"></param>
		public string GetCSDefaultValueByType(DataObjectBase column)
		{
			if (column == null)
				return null;

			ExtendedProperty defaultValueProperty = column.ExtendedProperties["CS_Default"];
			if (defaultValueProperty == null)
				return null;			
				
			string defaultValue = null;
			
			#region Convert declarations
			bool boolConvert;
			byte byteConvert;
			decimal decimalConvert;
			double doubleConvert;
			float floatConvert;
			int intConvert;
			long longConvert;
			short shortConvert;
			DateTime dateConvert;
			Guid guidConvert; 
			XmlNode xmlNodeConvert;
			#endregion
	
			try
			{
				//Get Default Value 
				defaultValue = defaultValueProperty.Value.ToString();
				
				if (defaultValue == null || defaultValue.Trim().Length == 0)
					return null;
				
				// trim off the surrounding ()'s if they exist (SQL Server)
				while (defaultValue.StartsWith("(") && defaultValue.EndsWith(")") 
					|| defaultValue.StartsWith("\"") && defaultValue.EndsWith("\""))
				{
					defaultValue = defaultValue.Substring(1);
					defaultValue = defaultValue.Substring(0, defaultValue.Length - 1);
				}
				
				if (IsNumericType(column as ColumnSchema))
					defaultValue = defaultValue.TrimEnd('.');
					
				if (defaultValueProperty.DataType == DbType.String)
				{
					// probably a char type.  Let's remove the quotes so parsing is happy
					if (defaultValue.StartsWith("'") && defaultValue.EndsWith("'"))
					{
						defaultValue = defaultValue.Substring(1);
						defaultValue = defaultValue.Substring(0, defaultValue.Length - 1);
					}
		
					//this is probably a custom function, lets handle it sane-like
					if (defaultValue.Contains("()"))
					{
						if ( defaultValue.ToLower() == "getdate()" )
							defaultValue = "DateTime.Now";
						else if ( defaultValue.ToLower() == "newid()" )
							defaultValue = "new Guid()";
						else if ( defaultValue.ToLower() == "getutcdate()" )
							defaultValue = "DateTime.UtcNow";
						else
							return null;
					}
				}

				if (column.NativeType.ToLower() == "real")
				{
					floatConvert = float.Parse(defaultValue);
					if (defaultValue != null)
						return floatConvert.ToString() + "F";
					else
						return null;
				}
				else
				{
					DbType dataType = column.DataType;
					switch (dataType)
					{
						case DbType.AnsiString:
							if (defaultValue != null)
								return "\"" + defaultValue + "\"";
							else
								return null;
			
						case DbType.AnsiStringFixedLength:
							if (defaultValue != null)
								return "\"" + defaultValue + "\"";
							else
								return null;
			
						case DbType.String:
							if (defaultValue != null)
								return "\"" + defaultValue + "\"";
							else
								return null;
			
						case DbType.Boolean:
						
							if (defaultValue != null )
							{
								if (defaultValue == "1") return "true";
								if (defaultValue == "0") return "false";
								if (defaultValue.Trim().ToLower() == "yes") return "true";
								if (defaultValue.Trim().ToLower() == "no") return "false";
								if (defaultValue.Trim().ToLower() == "y") return "true";
								if (defaultValue.Trim().ToLower() == "n") return "false";
								
								boolConvert = bool.Parse(defaultValue);
								return boolConvert.ToString();
							}
							else
								return null;
			
						case DbType.StringFixedLength:
							if (defaultValue != null)
								return "\"" + defaultValue + "\"";
							else
								return null;
			
						case DbType.Guid:
							if (defaultValue == "new Guid()")
								return defaultValue;
								
							guidConvert = new Guid(defaultValue);
							if (defaultValue != null && guidConvert != null)
								return "new Guid(\"" + guidConvert.ToString() + "\")";
							else
								return null;
						case DbType.Xml:
								return null;			
			
						//Answer modified was just 0
						case DbType.Binary:
							return null;
			
						//Answer modified was just 0
						case DbType.Byte:
							if (defaultValue != null )
							{
								byteConvert = byte.Parse(defaultValue);
								return "(byte)" + byteConvert.ToString();
							}
							else
								return null;
			
						case DbType.Currency:
							if (defaultValue != null)
							{
								decimalConvert = decimal.Parse(defaultValue);
								return decimalConvert.ToString() + "m";
							}
							else
								return null;
			
						case DbType.Date:
						case DbType.DateTime:
						
							if (defaultValue == "DateTime.Now")
								return "DateTime.Now";
							if (defaultValue == "DateTime.UtcNow")
								return "DateTime.UtcNow";

							dateConvert = DateTime.Parse(defaultValue);
							if (defaultValue != null )
								return "new DateTime(\"" + dateConvert.ToString() + "\")";
					
							return null;
						
						case DbType.Decimal:
							if (defaultValue != null)
							{
								decimalConvert = decimal.Parse(defaultValue);
								return decimalConvert.ToString() + "m";
							}
							else
								return null;
			
						case DbType.Double:
							if (defaultValue != null)
							{
								floatConvert = float.Parse(defaultValue);
								return floatConvert.ToString() + "f";
							}
							else
								return null;
			
						case DbType.Int16:
							if (defaultValue != null)
							{
								shortConvert = short.Parse(defaultValue);
								return "(short)" + shortConvert.ToString();
							}
							else
								return null;
			
						case DbType.Int32:
							if (defaultValue != null )
							{
								intConvert = int.Parse(defaultValue);
								return "(int)" + intConvert.ToString();
							}
							else
								return null;
			
						case DbType.Int64:
							if (defaultValue != null)
							{
								longConvert = long.Parse(defaultValue);
								return "(long)" + longConvert.ToString();
							}
							else
								return null;
			
						case DbType.Object:
							return null;
			
						case DbType.Single:
							if (defaultValue != null)
							{
								floatConvert = float.Parse(defaultValue);
								return floatConvert.ToString() + "F";
							}
							else
								return null;
			
						case DbType.Time:
							if (defaultValue == "DateTime.Now")
								return defaultValue;
							else if (defaultValue != null)
							{
								dateConvert = DateTime.Parse(defaultValue);
								return "DateTime.Parse(\"" + dateConvert.ToString() + "\")";
							}
							return null;
						case DbType.VarNumeric:
							if (defaultValue != null)
							{	
								decimalConvert = decimal.Parse(defaultValue);
								return decimalConvert.ToString();
							}
							else
								return null;
						//the following won't be used
						//		case DbType.SByte: return "0";
						//		case DbType.UInt16: return "0";
						//		case DbType.UInt32: return "0";
						//		case DbType.UInt64: return "0";
						default: return null;
					}
				}
			}
			catch{}
			return null;
		}
		
		public bool IsLengthType(DataObjectBase column)
		{
			DbType dataType = column.DataType;
			switch (dataType)
			{
				case DbType.AnsiString: 
				case DbType.AnsiStringFixedLength: 
				case DbType.String: 
				case DbType.StringFixedLength: 
				case DbType.Binary: 
					return true;
					
				default: 
						return false;
			}
		}

		/// <summary>
		/// Determines whether base DataObjectBase is a string type
		/// </summary>
		public bool IsStringType(DataObjectBase column)
		{
			DbType dataType = column.DataType;
			switch (dataType)
			{
				case DbType.AnsiString: 
				case DbType.AnsiStringFixedLength: 
				case DbType.String: 
				case DbType.StringFixedLength: 
					return true;
					
				default: 
						return false;
			}
		}
		
		/// <summary>
		/// Determines whether base DataObjectBase is a string type, and not a blob column of text or ntext
		/// </summary>
		public bool CanCheckLength(DataObjectBase column)
		{
			switch (column.DataType)
			{
				case DbType.AnsiString: 
				case DbType.AnsiStringFixedLength: 
				case DbType.String: 
				case DbType.StringFixedLength: 
					return 
					(
						column.NativeType != "text" && 
						column.NativeType != "ntext" && 
						column.Size > 0
					);
					
				default: 
						return false;
			}
		}
		
		
		/// <summary>
		/// Returns true if the column is represented as a reference data type
		/// rather than a value type. In other words, the C# code can set a
		/// column of this data type to 'null'
		/// </summary>
		public bool IsCSReferenceDataType(DataObjectBase column)
		{
			if (column.NativeType.ToLower() == "real")
				return false;
			else if (column.NativeType.ToLower() == "xml")
				return true;
			else
			{
				DbType dataType = column.DataType;
				switch (dataType)
				{
					case DbType.AnsiString: 
					case DbType.AnsiStringFixedLength: 
					case DbType.String: 
					case DbType.StringFixedLength: 
					case DbType.Binary: 
						return true;
						
					case DbType.Boolean: 
					case DbType.Guid: 
					case DbType.Byte:
					case DbType.Currency: 
					case DbType.Date: 
					case DbType.DateTime: 
					case DbType.Decimal: 
					case DbType.Double:
					case DbType.Int16: 
					case DbType.Int32: 
					case DbType.Int64: 
					case DbType.Object: 
					case DbType.Single: 
					case DbType.Time:
					case DbType.VarNumeric:
						return false;
						
					default: 
						return false;
				}
			}
		}

		
		/// <summary>
		/// Get a mock value for a given data type. Used by the unit test classes.
		/// </summary>
		/// <param name="column">Data type for which to get the default value.</param>
		/// <param name="stringValue">a mock string value.</param>
		/// <param name="bValue">a mock boolean value.</param>
		/// <param name="guidValue">a mock Guid value.</param>
		/// <param name="numValue">a mock numeric value.</param>
		/// <param name="dtValue">a mock datetime value.</param>
		/// <returns>A string representation of the default value.</returns>
		public string GetCSMockValueByType(DataObjectBase column, string stringValue, bool bValue, Guid guidValue, int numValue, DateTime dtValue)
		{	
			if (column.NativeType.ToLower() == "real")
				return numValue.ToString() + "F";
			else if (column.NativeType.ToLower() == "xml")
			{
				return "\"" + "<TEST></TEST>" + "\"";
			}	
			else
			{
				switch (column.DataType)
				{
					case DbType.AnsiString: 
						return "\"" + stringValue + "\"";
						
					case DbType.AnsiStringFixedLength: 
					return "\"" + stringValue + "\"";
					
					case DbType.String: 
						return "\"" + stringValue + "\"";
						
					case DbType.Boolean: 
						return bValue.ToString().ToLower();
					
					case DbType.StringFixedLength: 
						return "\"" + stringValue + "\"";
						
					case DbType.Guid: 
						return "new Guid(\"" + guidValue.ToString() + "\")"; 
					
					
					//Answer modified was just 0
					case DbType.Binary: 
						return "new byte[] {" + numValue.ToString() + "}";
					
					//Answer modified was just 0
					case DbType.Byte:
						return "(byte)" + numValue.ToString() + "";
						//return "{ 0 }";
					
					case DbType.Currency: 
						return numValue.ToString();
					
					case DbType.Date: 
						return string.Format("new DateTime({0}, {1}, {2}, 0, 0, 0, 0)", dtValue.Date.Year, dtValue.Date.Month, dtValue.Date.Day);
					
					case DbType.DateTime: 
						return string.Format("new DateTime({0}, {1}, {2}, {3}, {4}, {5}, {6})", dtValue.Year, dtValue.Month, dtValue.Day, dtValue.Hour, dtValue.Minute, dtValue.Second, dtValue.Millisecond);
					
					case DbType.Decimal: 
						return numValue.ToString() + "m";
						//return "0M";
						//return "0.0M";
					
					case DbType.Double: 
						return numValue.ToString() + ".0f";
					
					case DbType.Int16: 
						return "(short)" + numValue.ToString();
						
					case DbType.Int32: 
						return "(int)" + numValue.ToString();
						
					case DbType.Int64: 
						return "(long)" + numValue.ToString();
					
					case DbType.Object: 
						return "null";
					
					case DbType.Single: 
						return numValue.ToString() + "F";
					
					//case DbType.Time: return "DateTime.MaxValue";
					case DbType.Time: 
						return string.Format("new DateTime({0}, {1}, {2}, {3}, {4}, {5}, {6})", dtValue.Year, dtValue.Month, dtValue.Day, dtValue.Hour, dtValue.Minute, dtValue.Second, dtValue.Millisecond);
						
					case DbType.VarNumeric: 
						return numValue.ToString();
						//the following won't be used
						//		case DbType.SByte: return "0";
						//		case DbType.UInt16: return "0";
						//		case DbType.UInt32: return "0";
						//		case DbType.UInt64: return "0";
					default: return "null";
				}
			}
		}
		
		
		/// <summary>
		/// Generates a random number between the given bounds.
		/// </summary>
		/// <param name="min">lowest bound</param>
		/// <param name="max">highest bound</param>
		public int RandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max); 
		}
		
		public string RandomString(ViewColumnSchema column, bool lowerCase)
		{
			//Debugger.Break();
			int size = 2; // default size
			
			// calculate maximum size of the field
			switch (column.DataType)
			{				
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				{
					if (column.NativeType != "text" && column.NativeType != "ntext")
					{
						if (column.Size > 0)
						{
							size = column.Size;
						}
						
						if (size > 1000)
						{
							size = 1000;	
						}
					}
					break;
				}
			}
			
			return RandomString((size/2) -1, lowerCase);
		}

		public string RandomString(ColumnSchema column, bool lowerCase)
		{
			//Debugger.Break();
			int size = 2; // default size
			
			// calculate maximum size of the field
			switch (column.DataType)
			{				
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				{
					if (column.NativeType != "text" && column.NativeType != "ntext")
					{
						if (column.Size > 0)
						{
							size = column.Size;
						}
						
						if (size > 1000)
						{
							size = 1000;	
						}
					}
					break;
				}
			}
			
			return RandomString((size/2) -1, lowerCase);
		}
		
		/// <summary>
		/// Generates a random string with the given length
		/// </summary>
		/// <param name="size">Size of the string</param>
		/// <param name="lowerCase">If true, generate lowercase string</param>
		/// <returns>Random string</returns>
		/// <remarks>Mahesh Chand  - http://www.c-sharpcorner.com/Code/2004/Oct/RandomNumber.asp</remarks>
		public string RandomString(int size, bool lowerCase)
		{
			StringBuilder builder = new StringBuilder();
			Random random = new Random(size);
			char ch ;
			for(int i=0; i<size; i++)
			{
				ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65)) ;
				builder.Append(ch); 
			}
			if(lowerCase)
			return builder.ToString().ToLower();
			return builder.ToString();
		}


		/// <summary>
		/// Get the Sql Data type of a column
		/// </summary>
		/// <param name="column">Column for which to get the type</param>
		/// <returns>String representing the SQL data type</returns>
		public string GetSqlDbType(DataObjectBase column)	
		{
			switch (column.NativeType)
			{
				case "bigint": return "BigInt";
				case "binary": return "Binary";
				case "bit": return "Bit";
				case "char": return "Char";
				case "datetime": return "DateTime";
				case "decimal": return "Decimal";
				case "float": return "Float";
				case "image": return "Image";
				case "int": return "Int";
				case "money": return "Money";
				case "nchar": return "NChar";
				case "ntext": return "NText";
				case "numeric": return "Decimal";
				case "nvarchar": return "NVarChar";
				case "real": return "Real";
				case "smalldatetime": return "SmallDateTime";
				case "smallint": return "SmallInt";
				case "smallmoney": return "SmallMoney";
				case "sql_variant": return "Variant";
				case "sysname": return "NChar";
				case "text": return "Text";
				case "timestamp": return "Timestamp";
				case "tinyint": return "TinyInt";
				case "uniqueidentifier": return "UniqueIdentifier";
				case "varbinary": return "VarBinary";
				case "varchar": return "VarChar";
				default: return "__UNKNOWN__" + column.NativeType;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="fkey"></param>
		public string FKColumnName(TableKeySchema fkey)
		{
			StringBuilder Name = new StringBuilder();
			for(int x=0;x < fkey.ForeignKeyMemberColumns.Count;x++)
			{
				Name.Append( GetPropertyName(fkey.ForeignKeyMemberColumns[x].Name) );
			}
			return Name.ToString();
		}
		
		
		
		/// <summary>
		/// Build and return a concatened list of columns that are contained in the specified index. (ex: Column1Column2() )
		/// </summary>
		/// <param name="index"> the index instance.</param>
		public string IXColumnName(IndexSchema index)
		{
			StringBuilder Name = new StringBuilder();
			for(int x=0;x < index.MemberColumns.Count;x++)
			{
				Name.Append( GetPropertyName(index.MemberColumns[x].Name) );
			}
			return Name.ToString();
		}
		
		/// <summary>
		/// Build and return a comma separated list of column contained in the specified index. (ex: column1, column2 )
		/// </summary>
		/// <param name="index"> the index instance.</param>
		public string IXColumnNames(IndexSchema index)
		{
			StringBuilder Name = new StringBuilder();
			for(int x=0;x < index.MemberColumns.Count;x++)
			{
				if ( x > 0 )
					Name.Append(", ");

				Name.Append( GetPrivateName(index.MemberColumns[x].Name) );
			}
			return Name.ToString();
		}
		
		/// <summary>
		/// Build and return a concatened list of columns that are contained in the specified key. (ex: Column1Column2() )
		/// </summary>
		/// <param name="keys"> the key instance.</param>
		public string GetKeysName(ColumnSchemaCollection keys)
		{	
			StringBuilder Name = new StringBuilder();
			for(int x=0; x < keys.Count;x++)
			{
				Name.Append( GetPropertyName(keys[x].Name) );
			}
			return Name.ToString();
		}

		/// <summary>
		/// Indicates if the key is containing more than one column.
		/// </summary>
		/// <param name="keys"> <c>true</c> if > 1; false otherwise.</param>
		public bool IsMultiplePrimaryKeys(ColumnSchemaCollection keys)
		{
			if(keys.Count > 1)
				return true;
			return false;
		}
		
		public bool HasCommonColumn(ColumnSchemaCollection cols1, ColumnSchemaCollection cols2)
		{
			foreach(ColumnSchema col1 in cols1)
			{
				foreach(ColumnSchema col2 in cols2)
				{
					if (col1.Equals(col2))
					return true;
				}	
			}
			return false;
		}
		
		/// <summary>
		/// Return a ColumnSchemaCollection of columns that are contained in all of the tables
		/// </summary>
		/// <param name="sourceTables">Tables to search.</param>
		public ColumnSchemaCollection GetCommonTableColumns(TableSchemaCollection sourceTables)
		{
			ColumnSchemaCollection commonColumns = new ColumnSchemaCollection();
			
			if (sourceTables.Count > 0)
			{
				foreach(ColumnSchema col in sourceTables[0].Columns)
				{
					bool isInEveryTable = true;
					
					//System.Diagnostics.Debug.Write (col.Name + ":" + Environment.NewLine);
					
					for (int k = 1; k < sourceTables.Count ; k++)
					{
						TableSchema table = sourceTables[k];
						bool isInThisTable = false;
							
						// scan each column of this table to find this column
						foreach (ColumnSchema tCol in table.Columns)
						{					
							if (col.Name == tCol.Name && col.SystemType == tCol.SystemType && col.AllowDBNull == tCol.AllowDBNull)
							{
								isInThisTable= true;
							}
						}
						
						//System.Diagnostics.Debug.Write ("\t" + table.Name + " : " + isInThisTable.ToString() + Environment.NewLine);					
						isInEveryTable = isInEveryTable && isInThisTable;			
					}
										
					// If this column is present in every table, put it in the IEnity interface.
					if (isInEveryTable)
					{
						commonColumns.Add(col);
					}
				}
				
			}
			return commonColumns;
		}
		
		/// <summary>
		/// Check a table for enum eligibility
		/// </summary>
		/// <param name="table">the table instance to check.</param>
		/// <exception name="ApplicationException"/>
		public void ValidForEnum(TableSchema table)
		{
			#region "Primary key validation"
			
			// No primary key
			if (!HasPrimaryKey(table))
			{
				throw new ApplicationException("table has no primary key.");
			}
			
			// Multiple column in primary key
			if (table.PrimaryKey.MemberColumns.Count != 1)
			{
				throw new ApplicationException("table primary key contains more than one column.");
			}
			
			// Primary key column is not an integer
			if (!isIntXX(table.PrimaryKey.MemberColumns[0]))
			{
				throw new ApplicationException("table primary key column is not an integer. (used for enum value)");
			}
			
			#endregion
			
			#region "Second column must be a string"
			
			// The table must have 2 columns at least
			if (table.Columns.Count < 2)
			{
				throw new ApplicationException("table must at least contains two columns, an integer primary key, and a string.");
			}
			
			// The second column must be a string (char, varchar) 
			if (table.Columns[1].SystemType != typeof(string))
			{
				throw new ApplicationException("table 2nd column must be a string.");
			}
						
			// The second column must have a unique constraint (index with unique constraint)
			if (!table.Columns[1].IsUnique)
			{
				throw new ApplicationException("table 2nd column must be unique (used for the enum label).");
			}
									
			#endregion
			
			#region "Check relations"
			// the table mustn't have foreign relation
			//if (table.ForeignKeys.Count > 0)
			//{
			//	throw new ApplicationException("table cannot have relations where it is the foreign table.");
			//}
			
			// relation with table as primary key can only be on the first column 
			foreach(TableKeySchema key in table.PrimaryKeys)
			{
				if (key.PrimaryKeyMemberColumns[0].Name != table.Columns[0].Name || key.PrimaryKeyMemberColumns.Count > 1)
				{
					throw new ApplicationException("table cannot have relations where it is the foreign table.");
				}
				
				
			}
			
			#endregion
		}
	
		/// <summary>
		/// Indicates if the output rowset of the command is compliant with the table rowset.
		/// </summary>
		/// <param name="command">The stored procedure</param>
		/// <param name="table">The table</param>
		public bool IsMatching(CommandSchema command, TableSchema table)
		{
			try
			{
				if (command.CommandResults.Count == 0)
					return false;
					
				if (command.CommandResults[0].Columns.Count != table.Columns.Count)
				{
					return false;
				}
				
				for(int i=0; i<table.Columns.Count; i++)
				{
					if (IsComputed(table.Columns[i]))
						continue;
				
					if (!command.CommandResults[0].Columns.Contains(table.Columns[i].Name.ToLower()))
					{
						return false;
					}
					
					// manage the xml column type separately
					if ( table.Columns[i].NativeType == "xml" && (command.CommandResults[0].Columns[i].NativeType == "sql_variant" || command.CommandResults[0].Columns[i].NativeType == "ntext"))
					{
						continue;
					}
					else if (!SqlTypesAreEquivalent(command.CommandResults[0].Columns[i].NativeType, table.Columns[i].NativeType))
					{
						return false;
					}
				}
				return true;
			}	
			catch(Exception exc)
			{
				System.Diagnostics.Debug.WriteLine("Procedure Threw Exception: " + command.Name);
				return false;	
			}
		}
		
		/// <summary>
		/// Indicates if the output rowset of the command is compliant with the view rowset.
		/// </summary>
		/// <param name="command">The stored procedure</param>
		/// <param name="view">The view</param>
		public bool IsMatching(CommandSchema command, ViewSchema view)
		{
			try
			{
				if (command.CommandResults.Count == 0)
					return false;
					
				if (command.CommandResults[0].Columns.Count != view.Columns.Count)
				{
					return false;
				}
				
				for(int i=0; i<view.Columns.Count; i++)
				{	
					if (!command.CommandResults[0].Columns.Contains(view.Columns[i].Name.ToLower()))
					{
						return false;
					}
					
					// manage the xml column type separately
					if ( view.Columns[i].NativeType == "xml" && (command.CommandResults[0].Columns[i].NativeType == "sql_variant" || command.CommandResults[0].Columns[i].NativeType == "ntext"))
					{
						continue;
					}
					else if (!SqlTypesAreEquivalent(command.CommandResults[0].Columns[i].NativeType, view.Columns[i].NativeType))
					{
						return false;
					}
				}
				return true;
			}	
			catch(Exception exc)
			{
				System.Diagnostics.Debug.WriteLine("!!ERROR!! - Procedure Threw Exception: " + command.Name);
				return false;	
			}
		}
		
		/// <summary>
		/// Compares two sql types and determines if they are syntax equivalent.
		/// </summary>
		/// <param name="type1">The first sql type to compare.</param>
		/// <param name="type2">The second sql type to compare.</param>
		public bool SqlTypesAreEquivalent(string type1, string type2)
		{
			type1 = type1.ToLower();
			type2 = type2.ToLower();
			
			if ((type1 == "numeric" && type2 == "decimal") || (type2 == "numeric" && type1 == "decimal"))
			{
				return true;
			}
			else if ((type1 == "varchar" && type2 == "nvarchar") || (type2 == "varchar" && type2 == "nvarchar"))
			{
					return true;   
			}
			return (type1 == type2);
		}
		

		public bool isIntXX(DataObjectBase column)
		{
			bool result = false;

			for(int i = 0; i < aIntegerDbTypes.Length; i++)
			{
				if (aIntegerDbTypes[i] == column.DataType) result=true;
			}
			
			return result;
		}

		/// <summary>
		///	Indicates if a column is an int.
		/// </summary>
		/// <author>ab</author>
		/// <date>01/26/05</date>
		public bool isIntXX(ColumnSchema column)
		{
			bool result = false;

			for(int i = 0; i < aIntegerDbTypes.Length; i++)
			{
				if (aIntegerDbTypes[i] == column.DataType) result=true;
			}
			
			return result;		
		}
		
		#region Long Line Wrapping Handling
		// EntityBase.cst and EntityCollectionBase.cst render constructs with every column
		// in a table as arguments.  For very long tables, the C# compliler complains with
		// "CS1034: Compiler limit exceeded: Line cannot exceed 2046 characters"
		// Data warehouses can have very long tables.
		
		/// <summary>
		/// Stores the current column were are at.
		/// </summary>
		private int wrapCurrentColumn;
		
		/// <summary>
		/// Inititalizes the line wrapping to column 50.
		/// </summary>
		protected void WrapInit()
		{
			wrapCurrentColumn = 50;
		}

		/// <summary>
		/// Increment the wrap column by the normal amount.
		/// </summary>
		/// <remarks>
		/// This is not meant to be exact, rough estimate only.  This is called by
		/// EntityBase.cst and EntityCollectionBase.cst.
		/// </remarks>
		protected void WrapIncr(ColumnSchema column)
		{
			wrapCurrentColumn += GetCSType(column).Length + 1 /*space*/ + column.Table.Name.Length + GetPropertyName(column.Name).Length + 2; /*comma, space*/;
		}

		/// <summary>
		/// Wrap the line of text if the line exceeds 130 columns long.
		/// </summary>
		/// <remarks>
		/// CS1034: Compiler limit exceeded: Line cannot exceed 2046 characters
		/// </remarks>
		protected void WrapLine(int indentLevel)
		{
			if ( wrapCurrentColumn >= 130 ) // keep this reasonable, people do like printing code too
			{
				Response.Write(Environment.NewLine);
				for (int i = 0; i < indentLevel; i++)
					Response.Write("\t");
				wrapCurrentColumn = indentLevel * 4; // most people use 4 space tabs
			}
		}
		#endregion
		
		#region Column Comparer
		// [ab 013105] column name sorting comparer
		public class columnSchemaComparer : IComparer  
		{
	      	int IComparer.Compare( Object x, Object y )  
			{
				if (x is ColumnSchema && y is ColumnSchema)
	          		return( (new CaseInsensitiveComparer()).Compare( ((ColumnSchema)x).Name,  ((ColumnSchema)y).Name ) );
					
				throw new ArgumentException("one or both object(s) are not of type ColumnSchema");
			}
				
      	}
      	#endregion
		
		#region Utils
		
		#region Recursive Copy Code
		///<summary>
		/// Safely Copies all files from one directory to another
		///</summary>
		public void SafeCopyAll(string path, string destination) 
		{ 
			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path); 
			SafeCopyAll(dir, destination); 
		} 
		
		///<summary>
		/// Safely Copies all files from one directory to another
		///</summary>
		public void SafeCopyAll(System.IO.DirectoryInfo dir, string destination) 
		{ 
			string path; 
			foreach ( System.IO.FileInfo f in dir.GetFiles() ) 
			{ 
				f.CopyTo(System.IO.Path.Combine(destination, f.Name), true); 
			} 
			
			foreach ( System.IO.DirectoryInfo d in dir.GetDirectories() ) 
			{ 
				path = System.IO.Path.Combine(destination, d.Name); 
				SafeCreateDirectory(path); 
				SafeCopyAll(d, path); 
			} 
		} 
		
		/// <summary>
		/// Copy the specified file.
		/// </summary>
		public void SafeCreateDirectory(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
		
		/// <summary>
		/// Copy the specified file.
		/// </summary>
		public void SafeCopyFile(string path, string destination)
		{
			FileInfo file1 = new FileInfo(path);
			file1.CopyTo(destination, true);
		}

		#endregion 
		
		#region Recursive Get Files
		///<summary>
		/// Get's all available files with the proper extensions for inclusion into a project
		/// NOTE: Not Tested
		///</summary>
		public System.Collections.IList  GetFiles(string path) 
		{ 
				System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path); 
			
			return GetFiles(dir, new System.Collections.ArrayList()); 
		} 
		
		///<summary>
		/// Get's all available files with the proper extensions for inclusion into a project
		/// NOTE: Not Tested
		///</summary>
		public System.Collections.IList GetFiles(System.IO.DirectoryInfo dir, System.Collections.ArrayList files) 
		{ 
			string path; 
			foreach (System.IO.FileInfo f in dir.GetFiles() ) 
			{
				if (Array.IndexOf(IncludeExtensions, f.Extension) >= 0)
					files.Add(f);
			} 
			
			foreach (System.IO.DirectoryInfo d in dir.GetDirectories() ) 
			{ 
				path = System.IO.Path.Combine(dir.FullName, d.Name); 
				files.AddRange(GetFiles(d, files)); 
			} 
			
			return files;
		} 
		#endregion 
		
      	#region File Extensions
		private static string[] IncludeExtensions = new string[]{".arj", ".asa",".asax", ".ascx", ".asmx", ".ashx", ".asp", ".aspx", ".au", ".avi", ".bat", ".bmp", 
													  ".cab", ".chm", ".com", ".config", ".cs", ".css", ".disco", ".dll", ".doc", 
													  ".exe", ".png", ".gif", ".hlp", ".htm", ".html", ".jpg", ".inc", ".ini", 
													  ".log", ".mdb", ".mid", ".midi", ".mov", ".mp3", ".mpg", ".mpeg", ".fla", ".swf",
													  ".cur", ".ico", ".resx", ".jsl", ".cd", ".rdlc", ".js", ".vbs", ".wsf", ".master", 
													  ".skin", ".pdf", ".ppt", ".psd", ".sys", ".txt", ".tif", ".vb", ".vbs", ".vsdisco", 
													  ".wav", ".wri", ".xls", ".xml", ".xsd", ".xslt", ".zip", ".rpt", ".java",
													  ".settings", ".cfm", ".cfmx", ".jsp", ".mdf", ".ldf" };
													
		#endregion 
		
		#endregion 
		
		#region Custom Stored Procedures
		
		public IDictionary GetCustomProcedures(TableSchema table)
		{
			return GetCustomProcedures(table.Name, table.Database.Commands);
		}
		
		public IDictionary GetCustomProcedures(ViewSchema view)
		{
			return GetCustomProcedures(view.Name, view.Database.Commands);
		}
		
		public IDictionary GetCustomProcedures(string objectName, CommandSchemaCollection allCommands)
		{		
			string customPrefix = string.Format(CustomProcedureStartsWith, objectName, ProcedurePrefix);
			IDictionary procs = new Hashtable();
			string customName;
			bool discover = true;
			System.Collections.ArrayList invalids = new System.Collections.ArrayList();
			string current = string.Empty;
			
			while(discover)
			{
				try
				{
					procs.Clear();
					foreach ( CommandSchema proc in allCommands )
					{
						if (proc == null)
							continue;
							
						current = proc.Name;
						if (invalids.Contains(proc.Name))
							continue;
							
						if ( proc.Name.ToLower().StartsWith(customPrefix.ToLower()) )
						{
							customName = proc.Name.Substring(customPrefix.Length);
							procs.Add(customName, proc);
						}
					}
					discover = false;
				}
				catch(Exception exc)
				{
					System.Diagnostics.Debug.WriteLine("Stored Procedure Command Failed: " + current);	
					invalids.Add(current);
				}	
			}
		
			return procs;
		}

		public string GetReturnCustomProcReturnType(CustomNonMatchingReturnType nonMatchingReturnType, SchemaExplorer.TableSchema table, SchemaExplorer.CommandSchema command)
		{
			string returnType = "void";
			try
			{
				if (IsMatching(command, table))
				{
					returnType = GetCollectionClassName(table.Name);
				}
				else if (command.CommandResults != null && command.CommandResults.Count > 0)
				{
					returnType = nonMatchingReturnType.ToString();				
				}
			}
			catch(Exception exc)
			{
				System.Diagnostics.Debug.WriteLine("!!ERROR!!: Could not get return type from " + command.Name);	
			}	
			return returnType;	
		}

		
		public string GetReturnCustomProcReturnType(CustomNonMatchingReturnType nonMatchingReturnType, SchemaExplorer.ViewSchema view, SchemaExplorer.CommandSchema command)
		{
			string returnType = "void";
			try
			{
				if (IsMatching(command, view))
				{
					returnType = GetViewCollectionClassName(view.Name);
				}
				else if (command.CommandResults != null && command.CommandResults.Count > 0)
				{
					returnType = nonMatchingReturnType.ToString();
				}
			}
			catch(Exception exc)
			{
				System.Diagnostics.Debug.WriteLine("!!ERROR!!: Could not get return type from " + command.Name);	
			}	
			
			return returnType;	
		}

		public string GetCustomVariableName(string paramName, SchemaExplorer.CommandSchema command)
		{
			int c = 1;
			try
			{
				for(;c < command.Database.Commands.Count; c++)
				{
					CommandSchema tmp = command.Database.Commands[c];
					
					if (tmp.Name == command.Name)
						break;
				}
			} catch{}
			
			return string.Format("sp{1}_{0}", GetPropertyName(paramName), c);
		}
		
		#endregion 
      	
		#region Execute sql file

		public void ExecuteSqlInFile(string pathToScriptFile, string connectionString ) 
		{
			SqlConnection connection;

			StreamReader _reader			= null;

			string sql	= "";

			if( false == System.IO.File.Exists( pathToScriptFile )) 
			{
				throw new Exception("File " + pathToScriptFile + " does not exists");
			}
			using( Stream stream = System.IO.File.OpenRead( pathToScriptFile ) ) 
			{
				_reader = new StreamReader( stream );

				connection = new SqlConnection(connectionString);

				SqlCommand	command = new SqlCommand();

				connection.Open();
				command.Connection = connection;
				command.CommandType	= System.Data.CommandType.Text;

				while( null != (sql = ReadNextStatementFromStream( _reader ) )) 
				{
					command.CommandText = sql;

					command.ExecuteNonQuery();
				}

				_reader.Close();
			}
			connection.Close();			
		}


		private static string ReadNextStatementFromStream( StreamReader _reader ) 
		{			
			StringBuilder sb = new StringBuilder();

			string lineOfText;

			while(true) 
			{
				lineOfText = _reader.ReadLine();
				if( lineOfText == null ) 
				{

					if( sb.Length > 0 ) 
					{
						return sb.ToString();
					}
					else 
					{
						return null;
					}
				}

				if( lineOfText.TrimEnd().ToUpper() == "GO" ) 
				{
					break;
				}
			
				sb.Append(lineOfText + Environment.NewLine);
			}

			return sb.ToString();
		}

		#endregion
		
		#region Children Collections
		
		/////////////////////////////////////////////////////////////////////////////////////
		/// Begin Children Collection 
		/////////////////////////////////////////////////////////////////////////////////////
		
		///<summary>
		///  An ArrayList of all the child collections for this table.
		///</summary>
		private System.Collections.ArrayList _collections = new System.Collections.ArrayList();
		
		///<summary>
		///  An ArrayList of all the properties rendered.  
		///  Eliminate Dupes through common junction tables and fk relationships
		///</summary>
		private System.Collections.Hashtable relationshipDictionary = new System.Collections.Hashtable();
		
		///<summary>
		///	Returns an array list of Child Collections of the object
		///</summary>
		public System.Collections.Hashtable GetChildrenCollections(SchemaExplorer.TableSchema table, SchemaExplorer.TableSchemaCollection tables) 
		{
			//System.Diagnostics.Debugger.Break();
			
			///  An ArrayList of all the child collections for this table.
			System.Collections.Hashtable _collections = new System.Collections.Hashtable();
		
			CurrentTable = table.Name;
			
			//Check Cache
			if( relationshipDictionary[table.Name] == null )
			{
				relationshipDictionary[table.Name] = _collections;
			}
			else 
			{
				return relationshipDictionary[table.Name] as System.Collections.Hashtable;
			}
	
			//Provides Informatoin about the foreign keys
			SchemaExplorer.TableKeySchemaCollection fkeys = table.ForeignKeys;
			
			//Provides information about the indexes contained in the table. 
			IndexSchemaCollection indexes = table.Indexes;
			
			// Begin -- Fix for TableSchema.PrimaryKeys issue 2006-09-21 mwerner
			// Fix to generate code for recursive relations for a table
			
			// All keys that relate to this table
			TableKeySchemaCollection primaryKeyCollection = new TableKeySchemaCollection();
			primaryKeyCollection.AddRange(table.PrimaryKeys);
			
			// Add missing item to primaryKeyCollection 			
			foreach(TableKeySchema keyschema in fkeys)
			{
				if (keyschema.ForeignKeyTable.Equals(table) && keyschema.PrimaryKeyTable.Equals(table))
				{
					bool found = false;
					
					foreach(TableKeySchema primaryKey in primaryKeyCollection)
					{
						if (keyschema.Equals(primaryKey))
						{
							found = true;
							break;
						}
					}
					if (!found)
					{
						primaryKeyCollection.Add(keyschema);
					}					
				}
			}
			
			// End -- Fix for TableSchema.PrimaryKeys issue 2006-09-21 mwerner
			
			
			//for each relationship
			foreach(TableKeySchema keyschema in primaryKeyCollection)
			{
				
				// add the relationship only if the linked table is part of the selected tables (ie: omit tables without primary key)
				if (!tables.Contains(keyschema.ForeignKeyTable.Owner, keyschema.ForeignKeyTable.Name))
				{
					continue;
				}
				
				if (IsRelationOneToOne(keyschema))
				{
					CollectionInfo collectionInfo = new CollectionInfo();

					#region Additional 1:1 meta-data properties
					collectionInfo.PkColNames = GetColumnNames(table.PrimaryKey.MemberColumns);
					collectionInfo.PrimaryTable = GetClassName(table);
					collectionInfo.SecondaryTable = GetClassName(keyschema.ForeignKeyTable);
					collectionInfo.SecondaryTablePkColNames = GetColumnNames(keyschema.ForeignKeyTable.PrimaryKey.MemberColumns);
					collectionInfo.CollectionRelationshipType = RelationshipType.OneToOne;			
					collectionInfo.CollectionName = GetCollectionPropertyName(collectionInfo.SecondaryTable);
					collectionInfo.CollectionTypeName = GetCollectionClassName(collectionInfo.SecondaryTable);
					collectionInfo.TableKey = keyschema;
					collectionInfo.CleanName = GetClassName(collectionInfo.SecondaryTable);

					#endregion 

					//Key Name - Each collection should have a unique key namce
					collectionInfo.PkIdxName = keyschema.Name;
										
					// Method to fill this entity
					collectionInfo.GetByKeysName = "GetBy" + GetKeysName(keyschema.ForeignKeyMemberColumns);
					
					// Params to fill this entity
					collectionInfo.CallParams = GetFunctionRelationshipCallParameters(keyschema.PrimaryKeyMemberColumns);
					
					// Property String Name for a this relationship
					collectionInfo.PropertyName = GetClassName(collectionInfo.SecondaryTable);

					// Property String Name for a this relationship
					collectionInfo.PropertyNameUnique = GetClassName(collectionInfo.SecondaryTable);

					// Property Type for this relationship
					collectionInfo.TypeName = GetClassName(collectionInfo.SecondaryTable);
					
					// Field Variable String
					collectionInfo.FieldName = GetPrivateName(collectionInfo.SecondaryTable) + GetKeysName(keyschema.ForeignKeyMemberColumns);

					AddToCollection(_collections, collectionInfo);
				}
				//Add 1-N,N-1 relations
				else
				{
					CollectionInfo collectionInfo = new CollectionInfo();
					
					#region Additional 1:N meta-data properties
					
					collectionInfo.PkColNames = GetColumnNames(table.PrimaryKey.MemberColumns);
					collectionInfo.PrimaryTable = GetClassName(table);
					collectionInfo.SecondaryTable = GetClassName(keyschema.ForeignKeyTable);
					collectionInfo.SecondaryTablePkColNames = GetColumnNames(keyschema.ForeignKeyTable.PrimaryKey.MemberColumns);
					collectionInfo.CollectionRelationshipType = RelationshipType.OneToMany;
					collectionInfo.CollectionName = GetCollectionPropertyName(collectionInfo.SecondaryTable);
					collectionInfo.TableKey = keyschema;
					collectionInfo.CleanName = GetClassName(collectionInfo.SecondaryTable); 
					collectionInfo.CollectionTypeName = GetCollectionClassName(collectionInfo.SecondaryTable);
					
					#endregion 
					
					//Key Name - Each collection should have a unique key namce
					collectionInfo.PkIdxName = keyschema.Name;
					
					
					// Gets Method Calls
					if (IsForeignKeyCoveredByIndex(keyschema))
					{
						IndexSchema idx = GetIndexCoveringForeignKey(keyschema);
						
						// Method to fill this entity
						collectionInfo.GetByKeysName = "GetBy" + GetKeysName(idx.MemberColumns);

						// Params to fill this entity
						collectionInfo.CallParams = GetFunctionRelationshipCallParametersInKeyOrder(idx.MemberColumns, keyschema);
					}
					else
					{
						// Method to fill this entity
						collectionInfo.GetByKeysName = "GetBy" + GetKeysName(keyschema.ForeignKeyMemberColumns);
						
						// Params to fill this entity
						collectionInfo.CallParams = GetFunctionRelationshipCallParameters(keyschema.PrimaryKeyMemberColumns);
					}	

					// Usually the same as the property string
					collectionInfo.PropertyName = GetCollectionPropertyName(collectionInfo.SecondaryTable);

					// Usually the same as the property string
					collectionInfo.PropertyNameUnique = GetCollectionPropertyName(collectionInfo.SecondaryTable);

					// Usually the same as the property type
					collectionInfo.TypeName = GetCollectionClassName(collectionInfo.SecondaryTable);

					// Field Variable String
					collectionInfo.FieldName = GetPrivateName(collectionInfo.SecondaryTable) + GetKeysName(keyschema.ForeignKeyMemberColumns);

					AddToCollection(_collections, collectionInfo);
				}
			}

			//Add N-N relations
			foreach(SchemaExplorer.TableKeySchema key in primaryKeyCollection)
			{
				// Check that the key is related to a junction table and that this key relate a PK in this junction table
				if ( tables.Contains(key.ForeignKeyTable.Owner, key.ForeignKeyTable.Name) &&  IsJunctionTable(key.ForeignKeyTable) && IsJunctionKey(key))
				{
					TableSchema junctionTable = key.ForeignKeyTable;
					
					// Search for the other(s) key(s) of the junction table' primary key
					foreach(TableKeySchema junctionTableKey in junctionTable.ForeignKeys)
					{				
						if ( tables.Contains(junctionTableKey.ForeignKeyTable.Owner, junctionTableKey.ForeignKeyTable.Name) && IsJunctionKey(junctionTableKey) && junctionTableKey.Name != key.Name )
						{
							TableSchema secondaryTable = junctionTableKey.PrimaryKeyTable;
																			
							CollectionInfo collectionInfo = new CollectionInfo();
					
							#region Additional M:M meta-data 
							collectionInfo.PkColNames = GetColumnNames(table.PrimaryKey.MemberColumns);
							collectionInfo.PrimaryTable = GetClassName(table);
							collectionInfo.SecondaryTable = GetClassName(junctionTableKey.PrimaryKeyTable);
							collectionInfo.SecondaryTablePkColNames = GetColumnNames(junctionTableKey.PrimaryKeyTable.PrimaryKey.MemberColumns);
							collectionInfo.JunctionTableSchema = junctionTable;
							collectionInfo.SecondaryTableSchema = junctionTableKey.PrimaryKeyTable;
							collectionInfo.PrimaryTableSchema = table;
							collectionInfo.JunctionTable = GetClassName(junctionTable);
							collectionInfo.JunctionTablePkColNames = GetColumnNames(junctionTable.PrimaryKey.MemberColumns);
							collectionInfo.CollectionName = string.Format("{0}_From_{1}", GetCollectionPropertyName( collectionInfo.SecondaryTable), GetClassName(collectionInfo.JunctionTable)); //GetManyToManyName(GetCollectionClassName( collectionInfo.SecondaryTable), collectionInfo.JunctionTable);
							collectionInfo.CollectionTypeName = GetCollectionClassName( collectionInfo.SecondaryTable);
							collectionInfo.CollectionRelationshipType = RelationshipType.ManyToMany;
							collectionInfo.FkColNames = GetColumnNames(secondaryTable.PrimaryKey.MemberColumns);
							collectionInfo.TableKey = key;		
							collectionInfo.CleanName = string.Format(manyToManyFormat, GetClassName(collectionInfo.SecondaryTable), GetClassName(junctionTable.Name)); 
							#endregion 
							
							//Key Name - Each collection should have a unique key name
							collectionInfo.PkIdxName = junctionTableKey.Name;
							
							// Property Name
							collectionInfo.PropertyName = string.Format("{0}_From_{1}", GetCollectionPropertyName( collectionInfo.SecondaryTable), GetClassName(collectionInfo.JunctionTable)); 

							// Uninque Property Name, in case of conflict
							collectionInfo.PropertyNameUnique = string.Format("{0}_From_{1}", GetCollectionPropertyName( collectionInfo.SecondaryTable), GetClassName(collectionInfo.JunctionTable)); 

							// Field Variable String
							collectionInfo.FieldName = GetManyToManyName(key, GetCleanName(junctionTable.Name)).Substring(5);
							
							// Property/Field Type Name
							collectionInfo.TypeName = GetCollectionClassName(collectionInfo.SecondaryTable);
							
							//Method Params
							collectionInfo.CallParams = GetFunctionRelationshipCallParameters(table.PrimaryKey.MemberColumns);
							
							//Method Name
							collectionInfo.GetByKeysName = GetManyToManyName(key, GetCleanName(junctionTable.Name));
							
							AddToCollection(_collections, collectionInfo);
						}
					}
				}
			}// end N-N relations
			
			return _collections; 
		}
		
		public void AddToCollection(System.Collections.Hashtable _collections, CollectionInfo collectionInfo)
		{
			if(_collections[collectionInfo.PropertyName] == null)
			{
				_collections[collectionInfo.PropertyName] = collectionInfo;
			}
			else
			{
				CollectionInfo tmp = (CollectionInfo)_collections[collectionInfo.PropertyName];
				tmp.PropertyNameUnique = collectionInfo.PropertyName + tmp.GetByKeysName.Substring(3);

				collectionInfo.PropertyName += collectionInfo.GetByKeysName.Substring(3);
				collectionInfo.PropertyNameUnique += collectionInfo.GetByKeysName.Substring(3);

				if (_collections[collectionInfo.PropertyNameUnique] != null)
				{
					collectionInfo.PropertyName += "From" + GetPropertyName(collectionInfo.PkIdxName);
					collectionInfo.PropertyNameUnique += "From" + GetPropertyName(collectionInfo.PkIdxName);
				}
				_collections[collectionInfo.PropertyName] = collectionInfo;
			}
		}
		#endregion 
		
		#region CollectionInfo class
		///<summary>
		///	Child relationship structure information and their <see cref="RelationshipType" />
		/// to store in the ChildCollections ArrayList
		///</summary>
		public class CollectionInfo 
		{
			public string CleanName;
			public string[] PkColNames;
			public string PkIdxName;
			public string[] FkColNames;
			public string FkIdxName;
			public string PrimaryTable;
			public string SecondaryTable;
			public string[] SecondaryTablePkColNames;
			public string JunctionTable;
			public string[] JunctionTablePkColNames;
			public TableSchema JunctionTableSchema;
			public TableSchema SecondaryTableSchema;
			public TableSchema PrimaryTableSchema;
			public string CollectionName = string.Empty;
			public string CollectionTypeName = string.Empty;
			public string CallParams = string.Empty;
			public string PropertyName = string.Empty;
			public string PropertyNameUnique = string.Empty;
			public string TypeName = string.Empty;
			public string FieldName = string.Empty;
			public string GetByKeysName = string.Empty;
			public RelationshipType CollectionRelationshipType;	
			public TableKeySchema TableKey = null;
		}
		#endregion
			
		#region Relationships
		
		/// <summary>
		/// Gets params for a method based on the columns
		/// </summary>
		public string GetFunctionRelationshipCallParameters(ColumnSchemaCollection columns)
		{
			
			StringBuilder output = new StringBuilder();
			for (int i = 0; i < columns.Count; i++)
			{
				if (i > 0)
					output.Append(", ");
				output.AppendFormat("entity.{0}", GetPropertyName(columns[i].Name));
			}
			return output.ToString();
		}

		/// <summary>
		/// Orders the params for a method, based on the ordered column list.  It's useful when dealing with the IsForeignKeyCoveredByIndex method, which the 
		/// columns may be in different orders
		/// </summary>
		public string GetFunctionRelationshipCallParametersInKeyOrder(ColumnSchemaCollection orderedColumns, TableKeySchema keySchema)
		{
			ColumnSchemaCollection unorderedColumns = keySchema.ForeignKeyMemberColumns;
			ColumnSchemaCollection entityColumns = keySchema.PrimaryKeyMemberColumns;
			
			StringBuilder output = new StringBuilder();
			for (int j = 0; j < orderedColumns.Count; j++)
			{
				for (int i = 0; i < unorderedColumns.Count; i++)
				{
					if (orderedColumns[j].Name.ToLower() != unorderedColumns[i].Name.ToLower())
						continue;
						
					if (j > 0)
						output.Append(", ");
						
					output.AppendFormat("entity.{0}", GetPropertyName(entityColumns[i].Name));
				}
			}
			return output.ToString();
		}
		

	
		///<summary>
		/// Workaround for when a method in the DAL is using Indexes to create the method
		/// instead of the keys
		/// Sometimes when working with composite primary keys, the orders could be 
		/// different in the index than in the key.
		/// So it could be Col1 Col2 in TableKeySchema.ForeignKeyMemberColumns 
		/// But in Index.MemberColumns it could be Col2, Col1
		///</summary>
		public ColumnSchemaCollection GetCorrectColumnOrder(TableKeySchema key)
		{		
			if(IsForeignKeyCoveredByIndex(key))
			{
				bool found = true;
				foreach (IndexSchema idx in key.PrimaryKeyTable.Indexes)
				{
					foreach(ColumnSchema col in key.ForeignKeyMemberColumns)
					{
						if (!idx.MemberColumns.Contains(col.Name))
							found = false;
					}
					
					if (found)
					{
						return idx.MemberColumns;
					}
				}
			}
			
			return key.ForeignKeyMemberColumns;
		}

		/// <summary>
		/// Determines if the table key represents a identifying relationship.
		/// </summary>
		/// <param name="key">The key to check.</param>
		/// <returns>true if all of the child's foreign key members are part of the primary key.</returns>
		/// <remarks>
		/// An identifying relationship means that the child table cannot 
		/// be uniquely identified without the parent.
		/// </remarks>
		/// <exception cref="ArgumentNullException">key is null</exception>
		public bool IsIdentifyingRelationship(TableKeySchema key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			PrimaryKeySchema childPrimaryKey = key.ForeignKeyTable.PrimaryKey;
			
			// cant be a identifying relationship if the child does not have a PK
			if ( childPrimaryKey.MemberColumns.Count == 0 )
				return false;

			for (int i = 0; i < key.ForeignKeyMemberColumns.Count; i++)
			{
				// see if the child table's PK has the FK member
				if (childPrimaryKey.MemberColumns[key.ForeignKeyMemberColumns[i].Name] == null)
					return false;
			}
			return true;
		}


		///<summary>
		/// returns true all primary key columns have is a foreign key relationship
		/// </summary>
		public bool IsJunctionTable(TableSchema table)
		{
			if (!HasPrimaryKey(table))
			{
				//Response.WriteLine(string.Format("IsJunctionTable: The table {0} doesn't have a primary key.", table.Name));
				return false;
			}
			if (table.PrimaryKey.MemberColumns.Count == 1)
			{
				return false;				
			}
						
			// junction table requires at least 2 FK
			if (table.ForeignKeys.Count < 2)
				return false;

			// we need 2 identifying relationships
			int identifyingRelationshipCount = 0;
			for (int i = 0; i < table.ForeignKeys.Count; i++)
			{
				if ( IsIdentifyingRelationship(table.ForeignKeys[i]) )
					identifyingRelationshipCount++;
			}
			if ( identifyingRelationshipCount != 2 )
				return false;

						
			for (int i=0;i < table.PrimaryKey.MemberColumns.Count; i++){
				if (!table.PrimaryKey.MemberColumns[i].IsForeignKeyMember)
					return false;
			}
			return true;			
		}
		

		public bool IsRelationOneToOne(TableKeySchema keyschema) //, PrimaryKeySchema primaryKey)
		{
			bool result = true;
			
			// if this key do not contain
			if (keyschema.PrimaryKeyMemberColumns.Count != keyschema.PrimaryKeyTable.PrimaryKey.MemberColumns.Count)
				return false;
			
			// Each member must reference a unique key in the foreign table
			foreach(ColumnSchema column in keyschema.ForeignKeyMemberColumns)
			{
				bool columnIsUnique = false;

				// the only way to find the key in the foreign table is to loop through the indexes
				foreach(IndexSchema i in keyschema.ForeignKeyTable.Indexes)
				{
					//The index must be unique and the numer of columns columns
					//in the FK must match the number of columns in the index
					if((i.IsUnique || i.IsPrimaryKey) && (keyschema.ForeignKeyMemberColumns.Count == i.MemberColumns.Count))
					{
						//The index must contain the same column
						if(i.MemberColumns.Contains(column.Name) && (!IsJunctionTable(keyschema.ForeignKeyTable)))
						{
							columnIsUnique = true;
						}
					}
				}
				
				result = result && columnIsUnique;
			}
			
			return result;
		}
		
		

		
		public bool IsForeignKeyCoveredByIndex(TableKeySchema fKey)
		{
			bool isCovered = false;
				
			//If the Foreign key is also covered by an index, let the index 
			//processing handle the Get methods
			foreach(IndexSchema i in fKey.ForeignKeyTable.Indexes)
			{
				ColumnSchemaCollection fkCols = fKey.ForeignKeyMemberColumns;
				
				//First, the index must contain the same number of columns as the key
				if (fkCols.Count != i.MemberColumns.Count)
					continue;
					
				//Index must contain the same columns
				bool hasAllColumns = true;
				foreach(ColumnSchema column in fkCols)
				{
					if(!i.MemberColumns.Contains(column.Name))
					{
						hasAllColumns = false;
						break;
					}
				}
				
				if ( hasAllColumns )
				{
					//Index is a match - stop looking
					isCovered = true;
					break;
					
				}	
			}
			
			return isCovered;
		}
		
		
		public IndexSchema GetIndexCoveringForeignKey(TableKeySchema fKey)
		{
			bool isCovered = false;
				
			//If the Foreign key is also covered by an index, let the index 
			//processing handle the Get methods
			foreach(IndexSchema i in fKey.ForeignKeyTable.Indexes)
			{
				ColumnSchemaCollection fkCols = fKey.ForeignKeyMemberColumns;
				
				//First, the index must contain the same number of columns as the key
				if (fkCols.Count != i.MemberColumns.Count)
					continue;
					
				//Index must contain the same columns
				bool hasAllColumns = true;
				foreach(ColumnSchema column in fkCols)
				{
					if(!i.MemberColumns.Contains(column.Name))
					{
						hasAllColumns = false;
						break;
					}
				}
				
				if ( hasAllColumns )
				{
					//Index is a match - stop looking
					isCovered = true;
					return i;
				}	
			}
			
			return null;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public ColumnSchemaCollection GetRelationKeyColumns(TableKeySchemaCollection fkeys, IndexSchemaCollection indexes)
		{
			//Debugger.Break();
			for (int j=0; j < fkeys.Count; j++)
			{
				bool skipkey = false;
				foreach(IndexSchema i in indexes)
				{
					if(i.MemberColumns.Contains(fkeys[j].ForeignKeyMemberColumns[0]))
						skipkey = true;			
				}
				if(skipkey)
					continue;

				return fkeys[j].ForeignKeyMemberColumns;
			}
			return new ColumnSchemaCollection();
		}
		
		/// <summary>
		/// Gets the names of all the columns in the collection as a string array.
		/// </summary>
		/// <param name="columns"></param>
		/// <returns></returns>
		private string[] GetColumnNames(ColumnSchemaCollection columns)
		{
			string[] columnNames = new string[ columns.Count ];
			for (int i = 0; i < columns.Count; i++)
				columnNames[i] = GetPropertyName(columns[i].Name);
			return columnNames;
		}

		///<summary>
		/// Get's the constraint side of a column from a m:m relationship to it's corresponding 1:m relationship
		///</summary>
		public ColumnSchema GetCorrespondingRelationship(TableKeySchemaCollection fkeys, string columnName)
		{
			//System.Diagnostics.Debugger.Break();
			for (int j=0; j < fkeys.Count; j++)
			{
				for (int y=0; y < fkeys[j].ForeignKeyMemberColumns.Count; y++)
				{
					if (fkeys[j].ForeignKeyMemberColumns[y].Name.ToLower() 
							== columnName.ToLower())
						return fkeys[j].PrimaryKeyMemberColumns[y];
				}
			}
			return null;
		}


		private string _currentTable = string.Empty;
		
		///<summary>
		///  Store the most recent SourceTable of the templates,
		///  Used to clean up upon new SourceTable execution.  
		///</summary>
		[BrowsableAttribute(false)]
		public  string CurrentTable {
			get{return _currentTable;}
			set {_currentTable = value;}
		}
		
		///<summary>
		///  Store the most recent
		///  Used to keep track of which childcollections have been rendered
		///  Eliminates the Dupes.
		///</summary>
		[BrowsableAttribute(false)]
		public  System.Collections.Hashtable RelationshipDictionary {
			get{return relationshipDictionary;}
			set {relationshipDictionary = value;}
		}
		
		
		///<summary>
		/// Child Collection RelationshipType Enum
		///</summary>
		[BrowsableAttribute(false)]
		public enum RelationshipType{
			None = 0,
			OneToOne,
			OneToMany,
			ManyToOne,
			ManyToMany
		}
		
		#endregion Relationships
		
		#region GetParent/Child Tables
		///<summary>
		/// Get's the parent tables if any based on a child table.
		///</summary>
		public TableSchemaCollection GetParentTables(SchemaExplorer.TableSchema table)
		{
			TableSchemaCollection _tbParent= new TableSchemaCollection();
			if(CurrentTable != table.Name){
				CurrentTable = table.Name;
			}
			DatabaseSchema _dbCurrent;
			_dbCurrent=table.Database;
			
			foreach(TableSchema _tb in _dbCurrent.Tables){
				if(CurrentTable!=_tb.Name){
					foreach(ColumnSchema _col in _tb.PrimaryKey.MemberColumns){
						foreach(ColumnSchema col in table.Columns){
							if (col.Name == _col.Name){
								_tbParent.Add(_tb);
							}
						}                        
					}
				}
			}
			return _tbParent;
		}
			
		///<summary>
		///  Get's all the child tables based on a parent table
		///</summary>
		public TableSchemaCollection GetChildTables(SchemaExplorer.TableSchema table)
		{
			TableSchemaCollection _tbChild= new TableSchemaCollection();
				if(CurrentTable != table.Name){
					CurrentTable = table.Name;
				}
				DatabaseSchema _dbCurrent;
				_dbCurrent=table.Database;
				foreach(TableSchema _tb in _dbCurrent.Tables){
					if(CurrentTable!=_tb.Name){
						foreach(ColumnSchema _col in _tb.Columns){
							foreach(ColumnSchema primaryCol in table.PrimaryKey.MemberColumns){
								if (_col.Name == primaryCol.Name){
									_tbChild.Add(_tb);
								}
							}                       
						}
					}
				}
			return _tbChild;
		}
		#endregion 
	}

	#region Retry
	public enum SleepStyle
	{ 
		/// <summary>Each sleep will be the <i>n</i> milliseconds.</summary>
		Constant, 
		/// <summary>Each sleep will increase by <i>n</i>*<i>attempts</i> milliseconds.</summary>
		Linear, 
		/// <summary>Each sleep will increase exponential by <i>n</i>^<i>attempts</i> milliseconds.</summary>
		Exponential 
	}
	#endregion
	
	#region UnitTests
	
	public enum UnitTestStyle
	{
		/// <summary>No unit test should be included.</summary>
		None,
		/// <summary>NUnit tests should be generated.</summary>
		NUnit,
		/// <summary>VSTS test should be gerenated.</summary>
		VSTS
	}
	#endregion
	
	#region ComponentPatternType
	public enum ComponentPatternType
	{
		/// <summary>No Component Pattern Generation should be included.</summary>
		None,
		/// <summary>A Service Layer Pattern should be included.</summary>
		ServiceLayer,
		/// <summary>A Domain Model Pattern Generation should be included.</summary>
		DomainModel
	}
	#endregion
	
	#region DatabaseType
	public enum DatabaseType
	{
		/// <summary>No specific database type.</summary>
		None,
		/// <summary>SQL Server 2000.</summary>
		//SQLServer2000,
		/// <summary>SQL Server 2005.</summary>
		SQLServer2005
		/// <summary>Oracle 8i.</summary>
		//Oracle8i,
		/// <summary>Oracle 9i.</summary>
		//Oracle9i,
		/// <summary>Oracle 10g.</summary>
		//Oracle10g,
	}
	#endregion

	#region MethodNamesProperty
	
	[Serializable]
	//[TypeConverter(typeof(MethodNamesTypeConverter))]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[PropertySerializer(typeof(XmlPropertySerializer))]
	public class MethodNamesProperty
	{
		public MethodNamesProperty() { }
		public MethodNamesProperty(string values)
		{
			ParseCore(values);
		}
		
		// used for testing
		private static readonly string _methodNameSuffix = "";
		
		private string _get = "Get" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a Get operation.")]
		public string Get
		{
			get { return _get; }
			set { if ( IsValid(value) ) _get = value.Trim(); }
		}
		
		private string _getAll = "GetAll" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a GetAll operation.")]
		public string GetAll
		{
			get { return _getAll; }
			set { if ( IsValid(value) ) _getAll = value.Trim(); }
		}
		
		private string _getPaged = "GetPaged" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a GetPaged operation.")]
		public string GetPaged
		{
			get { return _getPaged; }
			set { if ( IsValid(value) ) _getPaged = value.Trim(); }
		}
		
		private string _find = "Find" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a Find operation.")]
		public string Find
		{
			get { return _find; }
			set { if ( IsValid(value) ) _find = value.Trim(); }
		}
		
		private string _insert = "Insert" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a Insert operation.")]
		public string Insert
		{
			get { return _insert; }
			set { if ( IsValid(value) ) _insert = value.Trim(); }
		}
		
		private string _update = "Update" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a Update operation.")]
		public string Update
		{
			get { return _update; }
			set { if ( IsValid(value) ) _update = value.Trim(); }
		}
		
		private string _save = "Save" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a Save operation.")]
		public string Save
		{
			get { return _save; }
			set { if ( IsValid(value) ) _save = value.Trim(); }
		}
		
		private string _delete = "Delete" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a Delete operation.")]
		public string Delete
		{
			get { return _delete; }
			set { if ( IsValid(value) ) _delete = value.Trim(); }
		}
		
		private string _deepLoad = "DeepLoad" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a DeepLoad operation.")]
		public string DeepLoad
		{
			get { return _deepLoad; }
			set { if ( IsValid(value) ) _deepLoad = value.Trim(); }
		}
		
		private string _deepSave = "DeepSave" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a DeepSave operation.")]
		public string DeepSave
		{
			get { return _deepSave; }
			set { if ( IsValid(value) ) _deepSave = value.Trim(); }
		}
		
		private string _getTotalItems = "GetTotalItems" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a GetTotalItems operation.")]
		public string GetTotalItems
		{
			get { return _getTotalItems; }
			set { if ( IsValid(value) ) _getTotalItems = value.Trim(); }
		}
		
		private string _bulkInsert = "BulkInsert" + _methodNameSuffix;
		[NotifyParentProperty(true)]
		[Description("The name of the method used to perform a BulkInsert operation.")]
		public string BulkInsert
		{
			get { return _bulkInsert; }
			set { if ( IsValid(value) ) _bulkInsert = value.Trim(); }
		}
		
		private bool IsValid(string value)
		{
			return ( value != null && value.Trim().Length > 0 );
		}
		
		private void ParseCore(string value)
		{
			if ( value != null && value.Length > 0 )
			{
				string[] values = value.Split(new char[] { ',' });
				
				if ( values.Length > 0 )
					Get = values[0];
				if ( values.Length > 1 )
					GetAll = values[1];
				if ( values.Length > 2 )
					GetPaged = values[2];
				if ( values.Length > 3 )
					Find = values[3];
				if ( values.Length > 4 )
					Insert = values[4];
				if ( values.Length > 5 )
					Update = values[5];
				if ( values.Length > 6 )
					Save = values[6];
				if ( values.Length > 7 )
					Delete = values[7];
				if ( values.Length > 8 )
					DeepLoad = values[8];
				if ( values.Length > 9 )
					DeepSave = values[9];
				if ( values.Length > 10 )
					GetTotalItems = values[10];
				if ( values.Length > 11 )
					BulkInsert = values[11];
			}
		}
		
		public static MethodNamesProperty Parse(string value)
		{
			return new MethodNamesProperty(value);
		}
		
		public string ToStringList()
		{
			string[] names = new string[] {
				Get, GetAll, GetPaged, Find,
				Insert, Update, Save, Delete,
				DeepLoad, DeepSave, GetTotalItems,
				BulkInsert
			};
			
			return string.Join(",", names);
		}
		
		public override string ToString()
		{
			return "(Expand to edit...)";
		}
	}
	
	public class MethodNamesTypeConverter : ExpandableObjectConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type t)
		{
			if ( t == typeof(string) )
			{
				return true;
			}
			else if ( t == typeof(XmlNode) )
			{
				return true;
			}
			
			return base.CanConvertFrom(context, t);
		}
		
		public override bool CanConvertTo(ITypeDescriptorContext context, Type t)
		{
			if ( t == typeof(XmlNode) )
			{
				return true;
			}
			
			return base.CanConvertTo(context, t);
		}
		
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo info, object value)
		{
			if ( value is string )
			{
				return MethodNamesProperty.Parse(value as string);
			}
			else if ( value is XmlNode )
			{
				XmlNode node = (XmlNode) value;
				XmlSerializer ser = new XmlSerializer(context.PropertyDescriptor.PropertyType);
				XmlNodeReader reader = new XmlNodeReader(node.FirstChild);
				return ser.Deserialize(reader);
			}
			
			return base.ConvertFrom(context, info, value);
		}
		
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type t)
		{
			if ( t == typeof(string) )
			{
				return ((MethodNamesProperty) value).ToStringList();
			}
			else if ( t == typeof(XmlNode) )
			{
				XmlSerializer ser = new XmlSerializer(t);
				MemoryStream stream = new MemoryStream();
				ser.Serialize(stream, value);
				stream.Position = 0;
				XmlDocument xml = new XmlDocument();
				xml.Load(stream);
				stream.Close();
				return xml.DocumentElement.FirstChild;
			}
			
			return base.ConvertTo(context, culture, value, t);
		}
	}
	
	#endregion MethodNamesProperty
	
	#region Archived Depricated
	/*
	///<summary>
	/// returns true all primary key columns have is a foreign key relationship
	/// </summary>
	public bool Many2ManyCompliant(TableKeySchema primaryKey)
	{
		// une seul column vers la table pivot
		if (primaryKey.ForeignKeyMemberColumns.Count != 1)
			return false;
		
		// une seul column venant de la table primaire
		if (primaryKey.PrimaryKeyMemberColumns.Count != 1)
			return false;
		
		
		// Junction table require a primary on two columns
		if (primaryKey.ForeignKeyTable.PrimaryKey == null || primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns.Count != 2)
		{
			//Response.WriteLine(string.Format("IsJunctionTable: The table {0} doesn't have a primary key.", table.Name));
			return false;
		}
		
		// And each primary key member columns must be part of relation
		for (int i=0;i < primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns.Count; i++)
		{
			if (!primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns[i].IsForeignKeyMember)
				return false;
			
			//if (!primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns[i].IsPrimaryKeyMember)
			//	return false;
		}
		
		// the foreign column of the relation must be a junction table's primary key member's column
		//if (primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns[0] != primaryKey.ForeignKeyMemberColumns[0] && primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns[1] != primaryKey.ForeignKeyMemberColumns[0])
		//{
		//	return false;
		//}
		
		if (!primaryKey.ForeignKeyMemberColumns[0].IsPrimaryKeyMember)	return false;
		
		return true;			
		}
			TableSchemaCollection _tbChild= new TableSchemaCollection();
				if(CurrentTable != table.Name){
					CurrentTable = table.Name;
				}
				DatabaseSchema _dbCurrent;
				_dbCurrent=table.Database;
				foreach(TableSchema _tb in _dbCurrent.Tables){
					if(CurrentTable!=_tb.Name){
						foreach(ColumnSchema _col in _tb.Columns){
							foreach(ColumnSchema primaryCol in table.PrimaryKey.MemberColumns){
								if (_col.Name == primaryCol.Name){
									_tbChild.Add(_tb);
								}
							}                       
						}
					}
				}
			return _tbChild;
		}
		
	}

	public bool IsJunctionTable(TableSchema table)
		{
			bool RetValue;
			ColumnSchemaCollection keys;
			RetValue = false;
			if(table.PrimaryKey.MemberColumns.Count > 1)
			{
				keys = new ColumnSchemaCollection(SourceTable.PrimaryKey.MemberColumns);
				foreach(ColumnSchema primarykey in keys)
				{
					if(primarykey.IsForeignKeyMember)
					{
						RetValue = true;
					}
					else
					{
						RetValue = false;
						break;
					}
				} 
			}
			return RetValue;
		}

*/
#endregion 
}
