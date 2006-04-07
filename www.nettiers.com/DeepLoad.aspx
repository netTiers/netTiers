<%@ Page MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<P>

From Original post by John Teague : <a href="http://forum.codesmithtools.com/default.aspx?f=19&amp;m=9264">http://forum.codesmithtools.com/default.aspx?f=19&amp;m=9264</a> 
<BR></P>
<P>
<TABLE id=Table1 height="100%" cellSpacing=0 cellPadding=0 width="100%" 
border=0>
  <TR>
    <TD class=msgThread1 vAlign=top height="100%">
      <DIV>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><B 
      style="mso-bidi-font-weight: normal"><FONT size=3><FONT 
      face="Times New Roman">Using DeepLoad <o:p></o:p></FONT></FONT></B></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>The </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad</SPAN><FONT 
      face="Times New Roman" size=3> and </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepSave</SPAN><FONT 
      face="Times New Roman" size=3> methods in NetTiers retrieve and make 
      changes to all of the object’s associated with an instantiated 
      object.<SPAN style="mso-spacerun: yes">&nbsp;&nbsp; </SPAN>For example, 
      the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Employees</SPAN><FONT 
      face="Times New Roman" size=3> object from Northwind includes an 
      </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3>, </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">EmployeeTerritoriesCollection</SPAN><FONT 
      face="Times New Roman" size=3>, and a </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">TerritoriesCollection_From_EmployeeTerritories 
      </SPAN><FONT face="Times New Roman" size=3>generated from a Many-Many 
      relationship. The DeepLoad method calls </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">DataRepository.OrdersProivider.GetByEmployeeID</SPAN><FONT 
      face="Times New Roman" size=3>, </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">DataRepository.EmployeeTerritoriesProvider.GetByEmployeeID, 
      and 
      DataRepository.TerritoriesProvider.GetByEmployeeIDFromEmployeeTerritories 
      </SPAN><FONT face="Times New Roman" size=3>methods to populate the 
      collection classes found in an </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">Employees </SPAN><FONT 
      face="Times New Roman" size=3>object.</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>There are 3 overloads to DeepLoad</FONT></P>
      <UL style="MARGIN-TOP: 0in" type=disc>
        <LI class=MsoNormal 
        style="MARGIN: 0in 0in 0pt; mso-list: l1 level1 lfo1; tab-stops: list .5in"><SPAN 
        style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad(Employees 
        entity)<o:p></o:p></SPAN> 
        <LI class=MsoNormal 
        style="MARGIN: 0in 0in 0pt; mso-list: l1 level1 lfo1; tab-stops: list .5in"><SPAN 
        style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad(Employees 
        entity, bool deep)<o:p></o:p></SPAN> 
        <LI class=MsoNormal 
        style="MARGIN: 0in 0in 0pt; mso-list: l1 level1 lfo1; tab-stops: list .5in"><SPAN 
        style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad(Employees 
        entity, bool deep Type, DeepLoadType deepLoad,Type [] 
        childTypes)</SPAN></LI></UL>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad(entity) 
      </SPAN><FONT face="Times New Roman" size=3>and</FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'"> 
      DeepLoad(entity, false)</SPAN><FONT face="Times New Roman" size=3> have 
      the same behavior.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>These 
      methods will load all of the collections for the entity object one level 
      deep.<SPAN style="mso-spacerun: yes">&nbsp;&nbsp; 
      </SPAN>DeepLoad(employee) will populate </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3>, </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">EmployeeTerritories</SPAN><FONT 
      face="Times New Roman" size=3>, and </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">TerritoriesCollection_From_EmployeeTerritories</SPAN><FONT 
      face="Times New Roman" size=3> <SPAN 
      style="mso-spacerun: yes">&nbsp;</SPAN>will be populated.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>However, </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">EmployeesCollection_From_EmployeeTerritories</SPAN><FONT 
      face="Times New Roman" size=3> property of </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">EmployeeTerritories</SPAN><FONT 
      face="Times New Roman" size=3> will not be populated.</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>Calling </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad(entity, 
      true)</SPAN><FONT face="Times New Roman" size=3> will<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>recursively call deep load for all 
      of the collection properties in the object.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>This means that the entire object 
      graph will be loaded.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>If 
      you’re object model has a lot of relationships, you will be loading a lot 
      of objects into memory.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>Use 
      this overload with caution.</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad(Employees 
      entity, bool deep, DeepLoadType deepLoadtype, Type[] 
      childTypes)</SPAN><FONT face="Times New Roman" size=3> overload allows you 
      to specifiy which collections you want to load.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN><SPAN 
      style="mso-spacerun: yes">&nbsp;</SPAN>The </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoadType</SPAN><FONT 
      face="Times New Roman" size=3> enumeration has three values</FONT></P>
      <UL style="MARGIN-TOP: 0in" type=disc>
        <LI class=MsoNormal 
        style="MARGIN: 0in 0in 0pt; mso-list: l0 level1 lfo2; tab-stops: list .5in"><SPAN 
        style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Ignore<o:p></o:p></SPAN> 

        <LI class=MsoNormal 
        style="MARGIN: 0in 0in 0pt; mso-list: l0 level1 lfo2; tab-stops: list .5in"><SPAN 
        style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">IncludeChildren<o:p></o:p></SPAN> 

        <LI class=MsoNormal 
        style="MARGIN: 0in 0in 0pt; mso-list: l0 level1 lfo2; tab-stops: list .5in"><SPAN 
        style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">ExcludeChildren</SPAN><FONT 
        size=3><FONT face="Times New Roman">.<SPAN 
        style="mso-spacerun: yes">&nbsp; </SPAN></FONT></FONT></LI></UL>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>Choosing </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Ignore</SPAN><FONT 
      face="Times New Roman" size=3> will cause the method to exit without doing 
      anything. </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">IncludeChildren</SPAN><FONT 
      face="Times New Roman" size=3> and </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">ExcludeChildren</SPAN><FONT 
      face="Times New Roman" size=3> change the childTypes array<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>to either an <I 
      style="mso-bidi-font-style: normal">inclusionary</I> list or <I 
      style="mso-bidi-font-style: normal">exclusionary</I> list.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>When you use </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoadType</SPAN><FONT 
      face="Times New Roman" size=3>.</FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">IncludeChildren</SPAN><FONT 
      face="Times New Roman" size=3>, the types in the the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">childTypes</SPAN><FONT 
      face="Times New Roman" size=3> array will be loaded.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>With </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoadType</SPAN><FONT 
      face="Times New Roman" size=3>.</FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">ExcludeChildren</SPAN><FONT 
      face="Times New Roman" size=3>, the types in the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">childTypes</SPAN><FONT 
      size=3><FONT face="Times New Roman"> array will not be 
      loaded.<o:p></o:p></FONT></FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>Let’s look at an example.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>This is an example console 
      application that is attached to this post.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>(The deep flag for Many-Many 
      relations is commented out when the code is generated, you need to 
      un-comment them on to follow this example).<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>Let’s load an employee object and 
      Run Deep Load.</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">Employees emp = 
      DataRepository.EmployeesProvider.GetByEmployeeID(9);<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">//this loads all child 
      collections one level deep<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">//it is the same call 
      (litrally) as DeepLoad(emp,false);<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">DataRepository.EmployeesProvider.DeepLoad(emp);<o:p></o:p></SPAN></P>
      <P class=MsoNormal 
      style="MARGIN: 0in 0in 0pt; mso-layout-grid-align: none"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">Console.WriteLine("Employee 
      Orders = " + emp.OrdersCollection.Count.ToString());<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">Console.WriteLine("</SPAN><st1:place><st1:PlaceName><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">Employee</SPAN></st1:PlaceName><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'"> 
      </SPAN><st1:PlaceType><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">Territories</SPAN></st1:PlaceType></st1:place><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'"> = " + 
      emp.TerritoriesCollection_From_EmployeeTerritories.Count.ToString());<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'"><o:p>&nbsp;</o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>The Results from this call is that the 
      </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3>, </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">TerritoriesCollection_From_EmployeeTerritories</SPAN><FONT 
      face="Times New Roman" size=3>, </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">EmployeeTerritoriesCollection</SPAN><FONT 
      face="Times New Roman" size=3> are populated.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>The </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">EmployeeTerritoriesCollection</SPAN><FONT 
      face="Times New Roman" size=3> contains only the elements from the 
      many-many table, </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">EmployeeId</SPAN><FONT 
      face="Times New Roman" size=3> and </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">TerritoryId</SPAN><FONT 
      face="Times New Roman" size=3>.<SPAN style="mso-spacerun: yes">&nbsp; 
      </SPAN>While the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">TerritoriesCollection_From_EmployeeTerritories</SPAN><FONT 
      size=3><FONT face="Times New Roman"> collection has the entire Territory 
      object fore each of Territory assocatiated.<o:p></o:p></FONT></FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'"><o:p>&nbsp;</o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>The output of this is</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Employee 
      Orders = 43<o:p></o:p></SPAN></P>
      <P class=MsoNormal 
      style="MARGIN: 0in 0in 0pt"><st1:place><st1:PlaceName><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Employee</SPAN></st1:PlaceName><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'"> 
      </SPAN><st1:PlaceType><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Territories</SPAN></st1:PlaceType></st1:place><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'"> 
      Collection = 7<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Territories 
      = 7<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'"><o:p>&nbsp;</o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>Let’s Look at the first </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Order</SPAN><FONT 
      face="Times New Roman" size=3> in the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3>:</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">Orders order = 
      emp.OrdersCollection[0];<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">Console.WriteLine("Order 
      Details Count = " + 
      order.OrderDetailsCollection.Count.ToString());<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>Since we didn’t set the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">deep 
      flag to true</SPAN><FONT size=3><FONT face="Times New Roman">, the 
      OrdersDetailCollection count will be 0.<o:p></o:p></FONT></FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>If we change the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad</SPAN><FONT 
      face="Times New Roman" size=3> call to: </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">DataRepository.EmployeesProvider.DeepLoad(emp, 
      true);<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>every collection property for every object 
      associated with Employee will be populated.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>Now, <SPAN 
      style="mso-spacerun: yes">&nbsp;</SPAN>the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">order.OrderDetailsCollection.Count 
      </SPAN><FONT face="Times New Roman" size=3>will equal 4</FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">.<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'"><o:p>&nbsp;</o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>If you have a highly connected object 
      structure, you can see how you can get into trouble quickly with the 
      </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">deep</SPAN><FONT 
      face="Times New Roman" size=3> flag turned on.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>By loading all of those child 
      collections in memory, your going to run into problems quickly.<SPAN 
      style="mso-spacerun: yes">&nbsp;&nbsp; </SPAN>That is why there is a third 
      overload that allows you to specify which child types you want to 
      load.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>Suppose you do need the 
      </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3>, but no other collections.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>You can use this call:</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'"><o:p>&nbsp;</o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">DataRepository.EmployeesProvider.DeepLoad(emp,true,DeepLoadType.IncludeChildren, 
      new Type[]{typeof(OrdersCollection)});<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'"><o:p>&nbsp;</o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>It is important to note only </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3> will be loaded, none of the child types 
      within </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3> will be loaded even though you set 
      </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">deep</SPAN><FONT 
      face="Times New Roman" size=3> to true.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>You can continue along the object 
      graph if you want by adding them to the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">childType</SPAN><FONT 
      face="Times New Roman" size=3> array.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN>If you want to load </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">Orders</SPAN><FONT 
      face="Times New Roman" size=3> and </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrderDetails</SPAN><FONT 
      face="Times New Roman" size=3>:</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'"><o:p>&nbsp;</o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">DataRepository.EmployeesProvider.DeepLoad(emp,<SPAN 
      style="COLOR: blue">true</SPAN>,DeepLoadType.IncludeChildren, <SPAN 
      style="COLOR: blue">new</SPAN> Type[] {<SPAN 
      style="COLOR: blue">typeof</SPAN>(OrdersCollection),<SPAN 
      style="COLOR: blue">typeof</SPAN>(OrderDetailsCollection)});</SPAN><o:p></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>This call will load all of the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3> and all of the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrderDetails</SPAN><FONT 
      face="Times New Roman" size=3> for every Order in the 
      collection.</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>The opposite effect will occur if you use 
      </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoadType.ExcludeChildren</SPAN><FONT 
      size=3><FONT face="Times New Roman">.<SPAN 
      style="mso-spacerun: yes">&nbsp; </SPAN></FONT></FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">DataRepository.EmployeesProvider.DeepLoad(emp,true,<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'">DeepLoadType.ExcludeChildren, 
      new Type[]{typeof(OrdersCollection)});<o:p></o:p></SPAN></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>Will load the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">TerritoriesCollection_From_EmployeeTerritories</SPAN><FONT 
      face="Times New Roman" size=3>, </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">EmployeeTerritoriesCollection</SPAN><FONT 
      face="Times New Roman" size=3>, but not the </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">OrdersCollection</SPAN><FONT 
      face="Times New Roman" size=3>.</FONT></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT 
      face="Times New Roman" size=3>&nbsp;</FONT></o:p></P>
      <P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT 
      face="Times New Roman" size=3>I have not yet experimented with 
      </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepSave</SPAN><FONT 
      face="Times New Roman" size=3>, however I expect it to have the same 
      behavior.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>If I find any 
      differences, I will write up another article detailing any difference 
      between </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepLoad</SPAN><FONT 
      face="Times New Roman" size=3> and </FONT><SPAN 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'">DeepSave</SPAN></P></DIV></TR></P>


</asp:Content>