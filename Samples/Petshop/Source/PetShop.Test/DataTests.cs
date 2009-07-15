using System;
using System.Diagnostics;
using NUnit.Framework;
using PetShop.Business;
using PetShop.Data;

namespace PetShop.Test
{
    [TestFixture]
    public class DataTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        #region Item

        [Test]
        public void ItemInsert()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                DataAccessLayer.Instance.ItemInsert("EST-86", 1, 5, "P", "New Item Test", "", "BG-03", 1).Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ItemFetch()
        {
            Stopwatch watch = Stopwatch.StartNew();
            
            try
            {
                var item = DataAccessLayer.Instance.ItemFetch(new ItemCriteria("EST-86").StateBag);
                Assert.IsTrue(item.FieldCount > 0);

                item.Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ItemUpdate()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                DataAccessLayer.Instance.ItemUpdate("EST-86", 5, 1, "P", "New Item Test Updated", "", "BG-03", 1).Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ItemDelete()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                DataAccessLayer.Instance.ItemDelete(new ItemCriteria("EST-86").StateBag).Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Product

        [Test]
        public void ProductInsert()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                DataAccessLayer.Instance.ProductInsert("BLAKE-0", "Blake", "Blake Niemyjski", "", "EDANGER").Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ProductFetch()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                var product = DataAccessLayer.Instance.ProductFetch(new ProductCriteria("BLAKE-0").StateBag);
                Assert.IsTrue(product.FieldCount > 0);

                product.Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ProductUpdate()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                DataAccessLayer.Instance.ProductUpdate("BLAKE-0", "Blake", "Blake A. Niemyjski", "", "EDANGER").Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ProductDelete()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                DataAccessLayer.Instance.ProductDelete(new ProductCriteria("BLAKE-0").StateBag).Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Profile

        private int _profileUniqueID = 0;

        [Test]
        public void ProfileInsert()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                var data = DataAccessLayer.Instance.ProfileInsert("BLAKE-0", "Blake", false, DateTime.Now, DateTime.Now);

                data.Read();

                _profileUniqueID = data.GetInt32("UniqueID");

                data.Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ProfileFetch()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                var profile = DataAccessLayer.Instance.ProfileFetch(new ProfileCriteria { Username = "BLAKE-0" }.StateBag);
                Assert.IsTrue(profile.FieldCount > 0);

                profile.Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ProfileUpdate()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                DataAccessLayer.Instance.ProfileUpdate(_profileUniqueID, "BLAKE-0", "Blake", true, DateTime.Now, DateTime.Now).Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ProfileDelete()
        {
            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                DataAccessLayer.Instance.ProfileDelete(new ProfileCriteria { Username = "BLAKE-0" }.StateBag).Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion
    }
}
