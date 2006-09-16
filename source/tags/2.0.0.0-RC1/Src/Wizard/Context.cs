using System;
using CodeSmith.Engine;
using System.Windows.Forms;
using System.Configuration;

namespace NetTiers.Wizard
{

	/// <summary>
	/// Description résumée de Context.
	/// </summary>
	internal class Context
	{
			
		//private NetTiers.Wizard.Configuration.AppConfigData userDatas;
		private CodeTemplate template;
		private string netTiersPath;
		
		#region "Public template properties"

		#region "Progress reporting"

		/// <summary>
		/// Gets the number of generated files.
		/// </summary>
		/// <value>The counter.</value>
		public int Counter
		{
			get {return Convert.ToInt32(this.template.GetProperty("Counter"));}
		}

		/// <summary>
		/// Gets the name of the current file that is generated.
		/// </summary>
		/// <value>The name of the current file.</value>
		public string CurrentFileName
		{
			get {return Convert.ToString(this.template.GetProperty("CurrentFileName"));}
		}

		
		public int TotalTemplates
		{
			get {return Convert.ToInt32(this.template.GetProperty("TotalTemplates"));}
		}

		public int CurrentTemplateIndex
		{
			get {return Convert.ToInt32(this.template.GetProperty("CurrentTemplateIndex"));}
		}

		public int TotalObjects
		{
			get {return Convert.ToInt32(this.template.GetProperty("TotalObjects"));}
		}


		public int CurrentObjectIndex
		{
			get {return Convert.ToInt32(this.template.GetProperty("CurrentObjectIndex"));}
		}

		public string CurrentPhase
		{
			get {return Convert.ToString(this.template.GetProperty("CurrentPhase"));}
		}

		#endregion

		#region "DataSource"
		
		/// <summary>
		/// Gets or sets a value indicating whether to generate the entire database or not.
		/// </summary>
		/// <value><c>true</c> if [entire database]; otherwise, <c>false</c>.</value>
		public bool EntireDatabase
		{
			get {return Convert.ToBoolean(this.template.GetProperty("EntireDatabase"));}
			set
			{
				this.template.SetProperty("EntireDatabase", value);
				
			}
		}

		/// <summary>
		/// Gets or sets the source database.
		/// </summary>
		/// <value>The source database.</value>
		public SchemaExplorer.DatabaseSchema SourceDatabase
		{
			get {return this.template.GetProperty("SourceDatabase") as SchemaExplorer.DatabaseSchema;}
			set
			{
				this.template.SetProperty("SourceDatabase", value);
				this.template.SetProperty("SourceTables", new SchemaExplorer.TableSchemaCollection(SourceDatabase.Tables.ToArray()));
			}
		}

		/// <summary>
		/// Gets the source tables.
		/// </summary>
		/// <value>The source tables.</value>
		public SchemaExplorer.TableSchemaCollection SourceTables
		{
			get
			{
				return this.template.GetProperty("SourceTables") as SchemaExplorer.TableSchemaCollection;
			}
		}

		/// <summary>
		/// Gets the source tables.
		/// </summary>
		/// <value>The source tables.</value>
		public SchemaExplorer.ViewSchemaCollection SourceViews
		{
			get
			{
				return this.template.GetProperty("SourceViews") as SchemaExplorer.ViewSchemaCollection;
			}
		}

		#endregion

		#region "Namespace settings"

		/// <summary>
		/// Gets or sets the root namespace.
		/// </summary>
		/// <value>The name space.</value>
		public string NameSpace
		{
			get {return Convert.ToString(this.template.GetProperty("NameSpace"));}
			set {this.template.SetProperty("NameSpace", value);}
		}

		/// <summary>
		/// Gets or sets the business logic layer' namespace.
		/// </summary>
		/// <value>The business logic layer name space.</value>
		public string BusinessLogicLayerNameSpace
		{
			get {return Convert.ToString(this.template.GetProperty("BusinessLogicLayerNameSpace"));}
			set {this.template.SetProperty("BusinessLogicLayerNameSpace", value);}
		}

		/// <summary>
		/// Gets or sets the data access layer' namespace.
		/// </summary>
		/// <value>The data access layer name space.</value>
		public string DataAccessLayerNameSpace
		{
			get {return Convert.ToString(this.template.GetProperty("DataAccessLayerNameSpace"));}
			set {this.template.SetProperty("DataAccessLayerNameSpace", value);}
		}

		/// <summary>
		/// Gets or sets the unit tests' namespace.
		/// </summary>
		/// <value>The unit tests name space.</value>
		public string UnitTestsNameSpace
		{
			get {return Convert.ToString(this.template.GetProperty("UnitTestsNameSpace"));}
			set {this.template.SetProperty("UnitTestsNameSpace", value);}
		}

		#endregion

		#region "CRUD options"

		public bool IncludeCustoms
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeCustoms"));}
			set {this.template.SetProperty("IncludeCustoms", value);}
		}
		
		public bool IncludeInsert
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeInsert"));}
			set {this.template.SetProperty("IncludeInsert", value);}
		}

		public bool IncludeUpdate
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeUpdate"));}
			set {this.template.SetProperty("IncludeUpdate", value);}
		}

		public bool IncludeSave
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeSave"));}
			set {this.template.SetProperty("IncludeSave", value);}
		}

		public bool IncludeDelete
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeDelete"));}
			set {this.template.SetProperty("IncludeDelete", value);}
		}

		public bool IncludeGet
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeGet"));}
			set {this.template.SetProperty("IncludeGet", value);}
		}

		public bool IncludeGetList
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeGetList"));}
			set {this.template.SetProperty("IncludeGetList", value);}
		}

		public bool IncludeGetListByFK
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeGetListByFK"));}
			set {this.template.SetProperty("IncludeGetListByFK", value);}
		}

		public bool IncludeGetListByIX
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeGetListByIX"));}
			set {this.template.SetProperty("IncludeGetListByIX", value);}
		}

		public bool IncludeFind
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeFind"));}
			set {this.template.SetProperty("IncludeFind", value);}
		}

		public bool IncludeManyToMany
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeManyToMany"));}
			set {this.template.SetProperty("IncludeManyToMany", value);}
		}
		
		public bool IncludeRelations
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeRelations"));}
			set {this.template.SetProperty("IncludeRelations", value);}
		}

		#endregion
		
		#region "Documentation settings"
		
		/// <summary>
		/// Gets or sets the name of the company.
		/// </summary>
		/// <value>The name of the company.</value>
		public string CompanyName
		{
			get {return Convert.ToString(this.template.GetProperty("CompanyName"));}
			set {this.template.SetProperty("CompanyName", value);}
		}

		/// <summary>
		/// Gets or sets the company URL.
		/// </summary>
		/// <value>The company URL.</value>
		public string CompanyURL
		{
			get {return Convert.ToString(this.template.GetProperty("CompanyURL"));}
			set {this.template.SetProperty("CompanyURL", value);}
		}

		#endregion

		#region "Code style"
		
		public string EntityFormat
		{
			get {return Convert.ToString(this.template.GetProperty("EntityFormat"));}
			set {this.template.SetProperty("EntityFormat", value);}
		}

		public string EntityDataFormat
		{
			get {return Convert.ToString(this.template.GetProperty("EntityDataFormat"));}
			set {this.template.SetProperty("EntityDataFormat", value);}
		}

		public string CollectionFormat
		{
			get {return Convert.ToString(this.template.GetProperty("CollectionFormat"));}
			set {this.template.SetProperty("CollectionFormat", value);}
		}

		public string ProviderFormat
		{
			get {return Convert.ToString(this.template.GetProperty("ProviderFormat"));}
			set {this.template.SetProperty("ProviderFormat", value);}
		}

		public string InterfaceFormat
		{
			get {return Convert.ToString(this.template.GetProperty("InterfaceFormat"));}
			set {this.template.SetProperty("InterfaceFormat", value);}
		}

		public string BaseClassFormat
		{
			get {return Convert.ToString(this.template.GetProperty("BaseClassFormat"));}
			set {this.template.SetProperty("BaseClassFormat", value);}
		}

		public string UnitTestFormat
		{
			get {return Convert.ToString(this.template.GetProperty("UnitTestFormat"));}
			set {this.template.SetProperty("UnitTestFormat", value);}
		}

		public string EnumFormat
		{
			get {return Convert.ToString(this.template.GetProperty("EnumFormat"));}
			set {this.template.SetProperty("EnumFormat", value);}
		}

		public string ManyToManyFormat
		{
			get {return Convert.ToString(this.template.GetProperty("ManyToManyFormat"));}
			set {this.template.SetProperty("ManyToManyFormat", value);}
		}

		public string StrippedTablePrefixes
		{
			get {return Convert.ToString(this.template.GetProperty("StrippedTablePrefixes"));}
			set {this.template.SetProperty("StrippedTablePrefixes", value);}
		}

		#endregion

		#region "WebService Settings"
		
		/// <summary>
		/// Gets or sets the web service URL.
		/// </summary>
		/// <value>The web service URL.</value>
		public string WebServiceUrl
		{
			get {return Convert.ToString(this.template.GetProperty("WebServiceUrl"));}
			set {this.template.SetProperty("WebServiceUrl", value);}
		}

		/// <summary>
		/// Gets or sets the web service output path.
		/// </summary>
		/// <value>The web service output path.</value>
		public string WebServiceOutputPath
		{
			get {return Convert.ToString(this.template.GetProperty("WebServiceOutputPath"));}
			set {this.template.SetProperty("WebServiceOutputPath", value);}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to generate the webservice or not.
		/// </summary>
		/// <value><c>true</c> if [generate webservice]; otherwise, <c>false</c>.</value>
		public bool GenerateWebservice
		{
			get {return Convert.ToBoolean(this.template.GetProperty("GenerateWebservice"));}
			set {this.template.SetProperty("GenerateWebservice", value);}
		}

		#endregion

		#region "Generation settings"

		/// <summary>
		/// Gets or sets the ouput directory.
		/// </summary>
		/// <value>The ouput directory.</value>
		public string OuputDirectory
		{
			get {return Convert.ToString(this.template.GetProperty("OutputDirectory"));}
			set {this.template.SetProperty("OutputDirectory", value);}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [create unit test].
		/// </summary>
		/// <value><c>true</c> if [create unit test]; otherwise, <c>false</c>.</value>
		public bool CreateUnitTest
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IncludeUnitTest"));}
			set {this.template.SetProperty("IncludeUnitTest", value);}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [create stored procedure].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [create stored procedure]; otherwise, <c>false</c>.
		/// </value>
		public bool CreateStoredProcedure
		{
			get {return Convert.ToBoolean(this.template.GetProperty("ExecuteSql"));}
			set {this.template.SetProperty("ExecuteSql", value);}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [create web service].
		/// </summary>
		/// <value><c>true</c> if [create web service]; otherwise, <c>false</c>.</value>
		public bool CreateWebService
		{
			get {return Convert.ToBoolean(this.template.GetProperty("GenerateWebService"));}
			set {this.template.SetProperty("GenerateWebService", value);}
		}

		

		/// <summary>
		/// Gets or sets a value indicating whether [use partial class].
		/// </summary>
		/// <value><c>true</c> if [use partial class]; otherwise, <c>false</c>.</value>
		public bool UsePartialClass
		{
			get {return Convert.ToBoolean(this.template.GetProperty("UsePartialClass"));}
			set {this.template.SetProperty("UsePartialClass", value);}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is targeting visual studio 2003.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is targeting visual studio2003; otherwise, <c>false</c>.
		/// </value>
		public bool IsTargetingVisualStudio2003
		{
			get {return Convert.ToBoolean(this.template.GetProperty("IsTargetingVisualStudio2003"));}
			set {this.template.SetProperty("IsTargetingVisualStudio2003", value);}
		}
		
		#endregion

		#endregion
		
		/// <summary>
		/// Creates a new <see cref="Context"/> instance.
		/// </summary>
		internal Context()
		{
			try
			{
				this.netTiersPath = ConfigurationSettings.AppSettings["NetTiersPath"];

				if (!System.IO.File.Exists(this.netTiersPath) )
				{
					this.netTiersPath = @"C:\Projects\Sourceforge\NetTiers\Templates\NetTiers.cst";
				}
			}
			catch(Exception)
			{
				this.netTiersPath = @"C:\Projects\Sourceforge\NetTiers\Templates\NetTiers.cst";
			}
			
			this.template = CompileTemplate(NetTiersPath);

			// Some properties are set to value that cannot be changed with the wizard
			this.template.SetProperty("ViewReport", false);
			//this.template.SetProperty("ExcludeFields", new string[] {});
			
			this.template.SetProperty("IncludeDrop", true);
			this.template.SetProperty("ExecuteSql", false);
			this.template.SetProperty("SQLFolderName", "SQL");
			
			/*	
						
			IsolationLevel
			InsertSuffix
			UpdateSuffix
			DeleteSuffix
			SelectSuffix
			SelectAllSuffix
			FindSuffix
			ProcedurePrefix
			GrantUser
			
			public string AliasFilePath;
		*/
		}

		public string NetTiersPath
		{
			get {return this.netTiersPath;}
		}

		public CodeTemplate Template
		{
			get
			{				
				return this.template; 
			}
		}

		private string settingFileName = string.Empty;

		public string SettingFileName
		{
			get {return this.settingFileName;}
			set {this.settingFileName = value;}
		}

		public bool HasSettingFile
		{
			get {return this.settingFileName.Length > 0;}
		}

		/// <summary>
		/// Loads the settings file into the NetTiers template.
		/// </summary>
		/// <param name="path">The path.</param>
		public void LoadSettingsFile(string path)
		{
			this.settingFileName = path;
			//this.template = CompileTemplate(NetTiersPath);
			this.template.RestorePropertiesFromXmlFile(settingFileName);
		}

		/// <summary>
		/// Compiles the template.
		/// </summary>
		/// <param name="templateName">Name of the template.</param>
		/// <returns></returns>
		private CodeTemplate CompileTemplate(string templateName)
		{
			CodeTemplateCompiler compiler = new CodeTemplateCompiler(templateName);
			compiler.Compile();
	
			if (compiler.Errors.Count == 0)
			{
				return compiler.CreateInstance();
			}
			else
			{
				Forms.ErrorReport.Current.ErrorText = string.Empty;
				
				for (int i = 0; i < compiler.Errors.Count; i++)
				{
					if (!compiler.Errors[i].IsWarning)
					{
						Forms.ErrorReport.Current.ErrorText = string.Format("{0}", compiler.Errors[i]);
					}
				}

				Forms.ErrorReport.Current.ShowDialog();
				Application.Exit();
				return null;
			}
		}

	}
}