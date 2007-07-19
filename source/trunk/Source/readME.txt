=============================
      .netTiers 2.2.0.559 
=============================

-----------------------------
About .netTiers
-----------------------------
.netTiers is a library of open source CodeSmith templates written in C#.  The intention of the templates are to assist developers with the intention of eliminating repetative mundane coding, and at the same time, provide a full fledged framework that allows you to get started working on what matters the most to you in your applications.  For example, focusing your efforts with the presentation layer, business rules, workflow, and application health  for your application to become a success. Consider .netTiers an application block, only specialized to your domain model, and the growth from within the product will more likely be vertically more than horizontally.  Meaning, future versions will be focusing on providing more things out of the box which will assist you in your everyday development tasks. 

The templates effectively build a set of object-relational domain objects for an existing database based off of Model Driven Design (MDD).  MDD essentially is the concept where a predesigned model is used to generate your application.  MDD was made famouis by many UML modelers, such as Rational Rose, etc.  However, with the advent of CodeSmith's rich set meta-data via it's SchemaExplorer, MDD has been particularly easy to adopt for .netTiers through the familiar data model.   It's .netTiers responsibility to have the ability to take a good database design and yield a wonderful generated domain for your codebase.  Since the majority of business applications revolve around data, .netTiers offers up the ability to work with your data in the easiest way possible as soon as possible.


.netTiers License
--------------------
.netTiers is released under the GNU LESSER GENERAL PUBLIC LICENSE.  You can always find the latest GNU LGPL license at:
http://www.gnu.org/licenses/lgpl.html

-----------------------------
Installing & Getting Started
-----------------------------
You can find detailed getting started information 
@ http://wiki.nettiers.com/GettingStarted2

System Requirements
--------------------
Visual Studio 2005
Codesmith 3.2+
Microsoft SQL Server2000+ 
Microsoft .Net 2.0 
Enterprise Library 2.0 (Optional, Recommended) 
nUnit or Visual Studio Team System (Optional)

Installing .netTiers
--------------------

Once you have downloaded the .netTiers .zip file from the http://www.netTiers.com/download.aspx website, simply extract the files to your favorite projects directory. It's required that you have CodeSmith installed and registered by this point on your system. 

Required Setup 
To execute, you simply have to run (double-click) the main template, NetTiers.cst found in the root of the folder found where you extracted the templates. CodeSmith Explorer will begin, and you will see the .netTiers Property Set. 

Getting Started - Required Properties:
At the bare minimum, you must fill out the first 3 properties as seen in the image to the left.
 
Choose Source Database: 
This property is the heart of the .netTiers meta data for generation. You should select the database that the tables views, and stored procedures should be based on for generation. 

IMPORTANT!!! If SourceTables and SourceViews are left blank, the Entire Database will then be generated. 

Choose DataSource:
--------------------
If you don't see your datasource, you will have to create one of your own, click Add and fill the Datasource Fields, Name, Provider Type, and ConnectionString.  Now that you've created your own entry, you can select it for generation. Setting this property will also try to default the the values of the OutputDirectory and your RootNameSpace by appending the datasource name to them. 

Depicted to the in the image above, Northwind was selected as our datasource, and the output directory appended became "C:\NetTiers\Northwind" and Northwind also became the RootNamespace. 

OutputDirectory: 
--------------------
The root windows directory to output the generated project to. It's usually best that this be a new directory unless you've worked with the templates for awhile. 

RootNameSpace: 
--------------------
Root namespace for generated projects and C# classes. This will be the prefix for the other project namespaces. Example: If you enter NetTiers.Northwind here, and you enter Entities in BLLNamespace, then you will see NetTiers.Northwind.Entities for your Entity Layer. 

Note: 
--------------------
This is all that is required to generate a successful Data Access Layer from the .netTiers templates. There are many more options and other layers you can generate.  


More Information
--------------------
For more options and detailed instructions please see:
http://wiki.nettiers.com/GettingStarted2


-----------------------------
.netTiers Support
-----------------------------
You can find more information on .netTiers Support @ http://netTiers.com/Support.aspx
This will direct you to the community forums site and/or a paid ticket based support option.
