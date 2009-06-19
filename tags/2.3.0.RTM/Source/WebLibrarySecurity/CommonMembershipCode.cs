using CodeSmith.Engine;
using SchemaExplorer;
using System;
using System.Windows.Forms.Design;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Design;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;


namespace MoM.Templates
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class CommonMembershipCode : CommonSqlCode //CodeTemplate
	{
		private DbType _isApprDbType;
		private DbType _isLockedOutDbType;
		private bool _initAttrRun;
		
		public CommonMembershipCode()
		{
			_initAttrRun = false;
		}
		
		private void InitAttrTypes()
		{
			if(!_initAttrRun)
			{
				_isApprDbType = DbType.Boolean;
				_isLockedOutDbType = DbType.Boolean;

				string aprCol = GetMappedColumn("IsApproved").ToLower();
				string loCol = GetMappedColumn("IsLockedOut").ToLower();

				foreach (ColumnSchema sch in MembershipTable.Columns)
				{
					if(sch.Name.ToLower() == aprCol)
						_isApprDbType = sch.DataType;
					if(sch.Name.ToLower() == loCol)
						_isLockedOutDbType = sch.DataType;
				}
			}
		}

		#region Copied from CommonSqlCode.cs

		private string aliasFilePath 		= "";

		[Editor( typeof( System.Windows.Forms.Design.FileNameEditor ), typeof( System.Drawing.Design.UITypeEditor ) )]
		[Category( "09. Code style - Advanced" )]
		[OptionalAttribute]
		[DefaultValue( "" )]
		[Description( "Optional File Path to a table/object alias file." )]
		public string AliasFilePath
		{
			get { return this.aliasFilePath; }
			set { this.aliasFilePath = value; }
		}

		/// <summary>
		/// Convert database types to C# types
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetCSType(DataObjectBase field)
		{
			if ( field.NativeType.ToLower() == "real" )
				return "System.Single" + ( field.AllowDBNull?"?":"" );
			else if ( field.NativeType.ToLower() == "xml" )
				return "string";
			//else if (field.NativeType.ToLower() == "xml")
			//	return "System.Xml.XmlNode";
			else if ( !IsCSReferenceDataType( field ) && field.AllowDBNull )
				return field.SystemType.ToString() + "?";
			else
				return field.SystemType.ToString();
			//return GetCSType(field.DataType);
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
		/// Get the Pascal cased version of a name.  
		/// </summary>
		/// <param name="name">Name to be changed</param>
		/// <returns>PascalCased version of the name</returns>
		public string GetPascalCaseName(string name)
		{		
			return name.Substring(0, 1).ToUpper() + name.Substring(1);
		}
		
		#endregion

		private ColumnSchema _entityMembershipUserPrimaryKey = null;

		[Category("10. WebLibrary.Security - Optional")]
		[OptionalAttribute]
		[DefaultValue("")]		
		[Description("Primary key column from the table that will become the EntityMembershipUser's user entity.")]
		public ColumnSchema EntityMembershipUserPKCol
		{
			get
			{
				return this._entityMembershipUserPrimaryKey;
			}
			set
			{
				_entityMembershipUserPrimaryKey = value;
			}
		}


		private string _membershipUserMapFile;

		[Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))] 
		[Category("10. WebLibrary.Security - Optional")]
		[OptionalAttribute]
		[DefaultValue("")]
		[Description("Optional File Path to a MembershipUserProperty/EntityProperty alias file")]
		public string MembershipUserMapFile
		{
			get
			{
				return this._membershipUserMapFile;
			}
			set
			{
				_membershipUserMapFile = value;
			}
		}
		
		private bool _membershipUseMD5 = false;
		
		[Category("10. WebLibrary.Security - Optional")]
		[Description("Use MD5 hash for passwords. False defaults to SHA1.")]
		public bool UseMD5Hash
		{
			get
			{
				return this._membershipUseMD5;
			}
			set
			{
				_membershipUseMD5 = value;
			}
		}
		
		public TableSchema MembershipTable
		{
			get
			{
				return EntityMembershipUserPKCol.Table;
			}
		}

		private Hashtable membershipUserMap = null;

		public string GetEntityAlias(string providerType)
		{
			if ( providerType == "Membership" )
			{
				return GetClassName(EntityMembershipUserPKCol.Table);
			}

			return null;
		}

		protected string EntityClass
		{
			get
			{
				return GetEntityAlias( "Membership" );
			}
		}

		protected string EntityKeyType
		{
			get
			{
				return EntityMembershipUserPKCol.GetType().ToString();
			}
		}
		
		public DbType IsApprovedType
		{
			get
			{
				InitAttrTypes();
				return _isApprDbType;
			}
		}
		
		public DbType IsLockedOutType
		{
			get
			{
				InitAttrTypes();
				return _isLockedOutDbType;
			}
		}
		
		public string GetBoolExp(DbType type, bool expected)
		{
			if(type == DbType.Boolean)
			{
				if(expected) return "true";
				else return "false";
			}
			else
			{
				if(expected) return "1";
				else return "0";
			}
		}
		
		public string GetBoolExp(DbType type, string subj)
		{
			if(type == DbType.Boolean)
			{
				return subj;
			}
			else
			{
				string cast = GetCast(type);
				return subj +"?" + cast + "1:"+ cast +"0";
			}
		}
		
		protected string GetCast(DbType type)
		{
			switch (type)
			{
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength: 
				case DbType.String:
				case DbType.StringFixedLength:
					return "(string)";

				case DbType.Boolean: 
					return "(bool)";

				//Answer modified was just 0
				case DbType.Byte:
					return "(byte)";

				case DbType.Decimal: 
					return "(float)";

				case DbType.Double: 
					return "(double)";

				case DbType.Int16: 
					return "(short)";

				case DbType.Int32: 
					return "(int)";

				case DbType.Int64: 
					return "(long)";

				case DbType.SByte: 
					return "(sbyte)";

				case DbType.UInt16: 
					return "(ushort)";

				case DbType.UInt32: 
					return "(uint)";

				case DbType.UInt64: 
					return "(ulong)";
			}
			return "";
		}

		/// <summary>
		/// This function gets the name of the property in the user entity that corresponds to 
		/// the selected MembershipUser property name.
		/// </summary>
		public string GetMappedColumn(string propertyName)
		{
			// If the mappings aren't loaded yet, and the filepath exists, then load the hashtable of mappings
			if ( membershipUserMap == null && File.Exists( MembershipUserMapFile ) )
			{
				membershipUserMap = new Hashtable();
				using ( StreamReader sr = new StreamReader( MembershipUserMapFile ) )
				{
					string line;
					while ( ( line = sr.ReadLine() ) != null )
					{
						if ( line.IndexOf( ":" ) > 0 )
						{
							string lvalue = line.Split( ':' )[0];
							string rvalue = line.Split( ':' )[1];
							
							if ( IsValidLValue( "Membership", lvalue ) && IsValidRValue( "Membership", rvalue ) )
							{
								membershipUserMap.Add( lvalue, GetPropertyName(rvalue) );
							}
						}
					}
				}
			}

			// See if our tablename is in the aliases hashtable, and if so, replace it.
			if ( membershipUserMap != null )
			{
				IDictionaryEnumerator mapping = membershipUserMap.GetEnumerator();
				while ( mapping.MoveNext() )
				{
					if ( propertyName.ToLower() == mapping.Key.ToString().ToLower() )
					{
						propertyName = mapping.Value.ToString();
						break;
					}
				}
			}

			return propertyName;
		}


		private bool IsValidLValue(string providerType, string lvalue)
		{
			if ( providerType == "Membership" )
			{
				switch ( lvalue )
				{
					case "ApplicationName":
					case "Comment":
					case "CreationDate":
					case "Email":
					case "FailedPasswordAttemptCount":
					case "FailedPasswordAttemptWindowStart":
					case "FailedPasswordAnswerAttemptCount":
					case "FailedPasswordAnswerAttemptWindowStart":
					case "IsApproved":
					case "IsLockedOut":
					case "LastActivityDate":
					case "LastLockoutDate":
					case "LastLoginDate":
					case "LastPasswordChangedDate":
					case "PasswordQuestion":
					case "PasswordAnswer":
					case "ProviderUserKey":
					case "UserName":
						return true;
				}
			}

			return false;
		}


		private bool IsValidRValue(string providerType, string rvalue)
		{
			if ( providerType == "Membership" )
			{
				if ( EntityMembershipUserPKCol.Table.Columns[rvalue] != null )
					return true;
			}

			return false;
		}

		public string GetPKType(string providerType)
		{
			if ( providerType == "Membership" )
			{
				return GetCSType( EntityMembershipUserPKCol.Table.PrimaryKey.MemberColumns[0] );
			}

			return null;
		}

	}
}
