


#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.UnitTests
{
    /// <summary>
    /// Provides tests for the <see cref="VVendor"/> objects (entity, collection and repository).
    /// </summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>
    [TestFixture]
    public partial class VVendorTest
    {
		/// <summary>
		/// Creates a new <see cref="VVendorTest"/> instance.
		/// </summary>	
		public VVendorTest()
		{			
		}
      
		
		/// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
		[TestFixtureSetUp]
		public void Init()
        {
			Init_Generated();
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		[TestFixtureTearDown]
        public void Dispose()
        {       	
			CleanUp_Generated();
        }
        
		
		/// <summary>
		/// Selects all VVendor objects of the database.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_1_SelectAll()
		{
			Step_1_SelectAll_Generated();			
		}
		
		/// <summary>
		/// Selects all VVendor objects of the database.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_2_Search()
		{
			Step_2_Search_Generated();
		}
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock VVendor entity into a temporary file.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_6_SerializeEntity()
		{
			Step_6_SerializeEntity_Generated();			
		}
		
		/// <summary>
		/// Deserialize the mock VVendor entity from a temporary file.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_7_DeserializeEntity()
		{
			Step_7_DeserializeEntity_Generated();
		}
		
		/// <summary>
		/// Serialize a VVendor collection into a temporary file.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_8_SerializeCollection()
		{
			Step_8_SerializeCollection_Generated();					
		}
		
		
		/// <summary>
		/// Deserialize a VVendor collection from a temporary file.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_9_DeserializeCollection()
		{
			Step_9_DeserializeCollection_Generated();	
		}
		#endregion
    }
}
