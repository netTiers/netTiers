<%@ Page MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<p class="overview">

<script src="http://js.track.semway.com/v1.2/tag.js" type="text/javascript"></script>
    <script type="text/javascript">
    <!--
        swtag();
    -->
    </script>
    <noscript>
			<img width="1" height="1" src="http://ws2.track.semway.com/v1.3/noscript.ashx" >
		</noscript>

	Date: 2005/22/11	
	<b>.netTiers Beta 2 release [v0.9.2 - codename Caribert]</b><br/>
	
	[for download go to the <a href="nightly.aspx">Download & nightly builds</a> section, thanks]<br />
	<!--
	 is <a href="http://sourceforge.net/project/showfiles.php?group_id=118735&package_id=129487&release_id=372797" target="_blank">available for download</a> !!!</b>
    -->
</p>

<p>
	Main improvements are:
	<ul>
		<li>WebService data provider</li>
		<li>Stronger null support</li>
		<li>Enterprise library 1.1 for .net 2</li>
		<li>Dal provider instantiate by reflection</li>
		<li>Collection filtering</li>
		<li>IBindinglist, IEditableObject, IListSource, ITypedList, IDisposable, IComponent support</li>
		<li>unit tests for Views</li>
		<li>Multi-line C# XML comments</li>
		<li>Added support for user-defined data types</li>
		<li>Alias file to choose your class name</li>
		<li>and many more</li>
	</ul>
	
	Here is a list of the main contributors (coding, testing, flaming...) for this release: 
	<ul>
		<li>John Roland</li>
		<li>Phil Bolduc</li>
		<li>Robert Hinojosa</li>
		<li>David Sanders</li>
		<li>David Sandor</li>
		<li>Ben Johnson</li>
		<li>jcteague</li>
		<li>David B. Bitton</li>
		<li>Dave Kekish </li>
		<li>Ben Johnson</li>
		<li>Alexander Kachalkov</li>
		<li>Tony Selke</li>
		<li>Bamber George</li>
		<li>scharland</li>
		<li>...</li>
	</ul>
</p>
								
				The change log:<br />
				
<textarea name="textarea" cols="100" rows="200" style="border-width: 1px black solid; background-color: #f0f0f0;" readonly>
11/20/2005
	- Sourceforge bugs fixes (cstemplates-Bugs-1336459, cstemplates-Bugs-1344008)
	- solution template corruption	
	
11/17/2005
	- Fix missing comments
	- Fix error when view name were camel cased
	- Fix SqlClient Guid

11/09/2005
	- Ws proxy bug -> entity was not updated correctly after an insert or an update.

11/08/2005
	- Fix few webservice problem like updatable primary keys and Update method that was calling the insert stored procedure.

11/03/2005
	- Add a Check on the parent entity of a foreign relationship
	- Fix the IEditableObject implementation

10/26/2005
	- Dal implementation have now their own project
	- WebService is back
	- webservice client dal is back

10/25/2005
	- remove the unseless try/catch in Filter.cst
	- cstemplates-Bugs-1337125 : SetFieldToNull not putting isDirty flag.

10/23/2005
		- Changed name of EntityBase BeforeChanged event handler to ColumnChanging to follow MS naming guidelines
		- Changed name of EntityBase AfterChanged event handler to ColumnChanged to follow MS naming guidelines
		- Changed name of TableColumns enumeration to TableColumn to follow MS naming guidelines
		- Added serialization code access security on EntityCollectionBase's GetObjectData(...) to match Serializable.
		- Implemented IDisposable interface on EntityCollectionBase
		- Fixed spelling error 'filtred' to 'filtered'
		- Fixed Filter.cst to just 'throw;' instead of 'throw ex;' to maintain the correct stack trace
		- Changed EntityViewBase.CompareTo() to throw NotImplementedException instead of incorrectly returning 0.
		- Fixed DeepLoad Many-to-Many code generation error.

10/20/2005
		- Various filtering enhancements
		- Entity now implements IEditableObject interface.
		- A small EntityData class in now generated to manage the  IEditableObject transaction.

10/19/2005
		- Collection sorting simplified and lighter (one inner arraylist removed)
		- Collection now support to mark item as removed, available throw the DeletedItems property until the save method of the Dalc is called.
		- Collection now support filtering, on multiple criteria. also added a RemoveFilter method to restore original state.

10/18/2005
		- Change the collection.Remove method, so it call the entity.MarkToDelete instead of the InnerList.Remove method. 
		 
10/17/2005
		- Removed possible race condition on OnBeforeChanged / OnAfterChanged virtual methods that raise the events.
		- Reduced the number of FxCop violations on Northwind generated Entity classes from 1899 to 1725.
		- Changed constructors on abstract entity base classes from public to protected.
		- Added check for null object on EntityBase.Equals(object), EntityViewBase.Equals(object)
		- Added check for null objects on EntityBase.Equals(object,object), EntityViewBase.Equals(object,object)
		- Added CultureInfo.InvariantCulture on ToString() methods on EntityBase, EntityViewBase, 
		- Changed serialization constructors from public to protected.
		- Added null parameter checks for AddRange() in EntityCollectionBase
		- Sealed BindableAttribute for performance reasons. (Seal attribute types for improved performance. 
                  Sealing attribute types speeds up performance during reflection on custom attributes.)
		- Changed GenericTypeConvert.CanConvertTo() argument destType to destinationType to
		  match base class' parameter name.
		- 

10/16/2005
		- Unit tests added (32 to 42.8% of coverage) - FK, IX and transactions are now tested :-D
		- Fixed a bug in the transaction manager (connection was closed too early).
		
10/15/2005
		- Unit tests added (29 to 32% of coverage)
		- DeepSave now support transactions
		- DataRepository.CreateTransaction method added.
		- DataRepository.Create property added.
		- Fix the enum problem with char/nchar field
		- Fix a bug with unclosed stream in the entityHelper.DeserializeXml method.
		- Update the EntLib assemblies, with the instrumentation compilation flags removed.
		

10/14/2005 
        - fixed when larger tables cause the C# compiler to complain about lines being too long.
          Line cannot exceed 2046 characters.  Lines are now wrapped at around 132 columns. This 
          only affected the construstors that passed in all the columns in a table,
          EntityBase.cst and EntityCollectionBase.cst.
        - fixed IEntity.cst when a column exists in all tables, the accessor did not call 
          GetPropertyName on the column name.

10/14/2005
        - Fix the property's case problem in DeepLoad, one to one relationship.

10/13/2005
        - [ 1261599 ] Get By Index Functions are wrong if based on UNIQUE index
        - fix cstemplates-Bugs-1324793 
        - fix table aliases to not be case sensitive

10/12/2005
        - Add the missing BindableAttribute on the entities generated from views.
        - Fix some comments in CommonSqlCode.cs

10/11/2005
        - Change hard coded .NET SDK install path to lookup from registry.  Could someone verify sdk v2.0 registry key.

10/08/2005
        - Fix GetByFK and deep load for when foriegn keys have more than one column.
        - Changed loading of user defined data types to call sp_MShelptype instead of query system tables.  Attempt to load
          user defined data types only happens if the DatabaseSchema.Provider.Name is "SqlSchemaProvider".  Placeholder for
          other providers is provided (no pun in intended).


10/07/2005
	- SqlEntityProviderBase.cst : 
		throw new DataException("Cannot find the unique instance of the class."); // ** thrown when get by unique index -- function should return null object??
		throw new DataException("The record has been already deleted."); // ** thrown when a delete affected no rows -- function should just return false instead
	- TransactionManager.cst : DataException replaced by InvalidOperationException when appropriate.

10/05/2005
	- nettiersconfigdata.config.cst : Use strored procedure was not correctly placed
	- EntityCollectionBase.cst : Fix the IBindingList support
	


10/04/2005 
        - Fixed multi-line C# XML comments
        - Added support for user-defined data types. User defined data types are dynamically loaded from the source database.

9/29/2005
	- fix the IBindingList implementation

9/26/2205
	-EntityRepositoryTest.cst : Unit tests were broken when the tables that are part of a key were not include.

9/23/2005 - John Roland
	- EntityProviderBase.cst, SqlEntityProvider.cst: move TransactionManager overload to the base class. now providers have to indicate if they support transaction or not.
	- StoredProceduresXml.cst : Fixing the Find issue with text and binary column.

9/23/2005 - Phil bolduc
	NetTiers.cst - added passing IncludeGetListByFK to EntityRepositoryTest.cst
	BusinessLogicLayer\Views\EntityView.cst - Changed <summary> tag to read view instead of table
	BusinessLogicLayer\Views\EntityViewBase.cst - Added same edits as EntityBase.cst for null columns (Property,IsNull,Copy,ToString,Equals)
	BusinessLogicLayer\EntityBase.cst - Get propery value no longer throws exception if null. ToString() uses String.Empty if column is null instead of "null"
	UnitTests\EntityRepositoryTest.cst - Added IncludeGetListByFK propery. 
						Include Deep Load tests only if IncludeGetListByFK = true.  
	EntityBase.cst only renders DeepLoad if IncludeGetListByFK = true, Fixed CreateMockInstance(), UpdateMockInstance() for when 2+ column FK


9/23/2005 - john
	- move transactions overload in base provider
	- added FileNameEditor selector for the alias files
	
9/22/2005 - Tony Selke / John Roland
	- added new features in collection base: IListSource, ITypedList, IDisposable, IComponent implementation


9/21/2005
	- Fixed forum bug: http://forum.codesmithtools.com/default.aspx?f=19&p=1&m=7927#m7935
		(Unclean name on isNull) (Dave Sanders)
	- Fixed forum bug: http://forum.codesmithtools.com/default.aspx?f=19&m=7761
		(making custom sprocs convert to null) (Dave Sanders)

9/18/2005
	- CommonSql.cs : fix of the many to many problem (Phil Bolduc)
	
9/18/2005 - Fix - [ 1257329 ] Nullable primitive data types handled wrong
	- EntityBase.cst, commonsql.cs, SqlEntityProviderBase.cst
		Nullable value types (int, smallint, etc) are now handled with a
		boolean flag instead of relying on default value of the type. Column
		property getter now throws InvalidOperationException if value is null.
		Column property setter throws ArgumentNullException if attempt to set
		reference type (ie varchar) type columns to null if they are NOT NULL
		in the database.


9/9/2005
	- StoredProceduresXml.cst: find method was not working with tables that have text or image column(s)

9/2/2005
	- Changed StoredProceduresXml.cst to not generate GRANT statement if the GrantUser property is not filled



9/1/2005
	- Added BusinessLogicLayerNameSpace variable

8/26/2005
	- Changed the sql view provider so that they work like the table provider
	- Achived the CLS compliancy

8/24/2005 - Changed SQL behavior to always generate .SQL file (Dave Sanders)
	Before this change, the user had to select "ExecuteSql" to request the SQL be generated.
	Now its generated every time.

8/24/2005 - Added "Alias" functionality
	The Alias is an optional file that allows the user to map table names to new class name aliases.
	The file is a simple text file with each line being an alias:
	
	MyTableName:MyClassName
	
	All references to that table will be replaced with the alias name.  This is useful for systems
	that have unruly database names that make the code "ugly" or cause confusion or difficulty.
	The underlying stored procedures are not affected however, maintaining database readability.
</textarea>
				
</asp:Content>