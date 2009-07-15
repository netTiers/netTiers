using System;
using System.Diagnostics;
using NUnit.Framework;
using PetShop.Business;

namespace PetShop.Test
{
    [TestFixture]
    public class BusinessTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        private const string NAME = "UnitTests";
        private const string ID = "Unit-Test";
        private static int _supplierId = 1;

        #region Profile

        [Test]
        public void CreateProfile()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Profile profile = Profile.NewProfile();
            profile.Username = NAME;
            profile.ApplicationName = "PetShop..Businesss";
            profile.IsAnonymous = false;
            profile.LastActivityDate = DateTime.Now;
            profile.LastUpdatedDate = DateTime.Now;

            try
            {
                profile = profile.Save();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void FetchProfile()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Profile profile = Profile.GetProfile(NAME);

            Assert.IsTrue(profile.Username == NAME);
            
            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void UpdateProfile()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Profile profile = Profile.GetProfile(NAME);
            profile.IsAnonymous = true;

            profile = profile.Save();

            Assert.IsTrue(Profile.GetProfile(NAME).IsAnonymous.Value);
            
            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Category

        [Test]
        public void CreateCategory()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Category category = Category.NewCategory();
            category.CategoryId = ID;
            category.Name = "";
            category.Descn = "";

            try
            {
                category = category.Save();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void FetchCategory()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Category category = Category.GetCategory(ID);

            Assert.IsTrue(category.CategoryId == ID);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void UpdateCategory()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Category category = Category.GetCategory(ID);
            category.Descn = "This is a .";

            category = category.Save();

            Assert.IsTrue(Category.GetCategory(ID).Descn == "This is a .");

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Inventory

        [Test]
        public void CreateInventory()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Inventory inventory = Inventory.NewInventory();
            inventory.ItemId = ID;
            inventory.Qty = 10;

            try
            {
                inventory = inventory.Save();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void FetchInventory()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Inventory inventory = Inventory.GetInventory(ID);

            Assert.IsTrue(inventory.ItemId == ID);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void UpdateInventory()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Inventory inventory = Inventory.GetInventory(ID);
            inventory.Qty = 100;

            inventory = inventory.Save();

            Assert.IsTrue(Inventory.GetInventory(ID).Qty == 100);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Product

        [Test]
        public void CreateProduct()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Product product = Product.NewProduct();
            product.ProductId = ID;
            product.CategoryId = ID;
            product.Image = "/.png";
            product.Descn = "";
            product.Name = "";

            try
            {
                product = product.Save();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void FetchProduct()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Product product = Product.GetProduct(ID);

            Assert.IsTrue(product.ProductId == ID);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void UpdateProduct()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Product product = Product.GetProduct(ID);
            product.Descn = "This is a ";

            product = product.Save();

            Assert.IsTrue(Product.GetProduct(ID).Descn == "This is a ");

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Supplier

        [Test]
        public void CreateSupplier()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Supplier supplier = Supplier.NewSupplier();
            supplier.Name = NAME;
            supplier.Status = "AB";
            supplier.Addr1 = "One  Way";
            supplier.Addr2 = "Two  Way";
            supplier.City = "Dallas";
            supplier.State = "TX";
            supplier.Zip = "90210";
            supplier.Phone = "555-555-5555";

            try
            {
                supplier = supplier.Save();
                _supplierId = supplier.SuppId;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void FetchSupplier()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Supplier supplier = Supplier.GetSupplier(_supplierId);

            Assert.IsTrue(supplier.SuppId == _supplierId);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void UpdateSupplier()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Supplier supplier = Supplier.GetSupplier(_supplierId);
            supplier.Phone = "111-111-1111";

            supplier = supplier.Save();

            Assert.IsTrue(Supplier.GetSupplier(_supplierId).Phone == "111-111-1111");

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Item

        [Test]
        public void CreateItem()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Item item = Item.NewItem();
            item.ItemId = ID;
            item.Image = "/.png";
            item.ListPrice = 0;
            item.Name = "";
            item.ProductId = ID;
            item.Status = "";
            item.SuppId = _supplierId;
            item.UnitCost = 0;

            try
            {
                item = item.Save();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsTrue(true);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void FetchItem()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Item item = Item.GetItem(ID);

            Assert.IsTrue(item.ItemId == ID);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void UpdateItem()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Item item = Item.GetItem(ID);
            item.ListPrice = 111;

            item = item.Save();

            Assert.IsTrue(Item.GetItem(ID).ListPrice == 111);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion


        #region ShoppingCart

        [Test]
        public void CreateAndFetchShoppingCart()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Profile profile = Profile.GetProfile(NAME);
            Assert.IsTrue(profile.ShoppingCart.Count == 0);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void AddItemToShoppingCart()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Profile profile = Profile.GetProfile(NAME);
            profile.ShoppingCart.Add(ID, profile.UniqueID, true);
            profile = profile.Save();

            Assert.IsTrue(Profile.GetProfile(NAME).ShoppingCart.Count == 1);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void RemoveItemFromShoppingCart()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Profile profile = Profile.GetProfile(NAME);
            profile.ShoppingCart.Remove(ID);
            profile = profile.Save();

            Assert.IsTrue(Profile.GetProfile(NAME).ShoppingCart.Count == 0);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void UpdateItemQuantityShoppingCart()
        {
            Stopwatch watch = Stopwatch.StartNew();

            //Add new Item to the cart.
            Profile profile = Profile.GetProfile(NAME);
            profile.ShoppingCart.Add(ID, profile.UniqueID, true);
            profile = profile.Save();

            profile = Profile.GetProfile(NAME);
            profile.ShoppingCart.Add(ID, profile.UniqueID, true);
            profile = profile.Save();

            profile = Profile.GetProfile(NAME);

            Assert.IsTrue(profile.ShoppingCart.Count == 1 && profile.ShoppingCart[0].Quantity == 2);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        [Test]
        public void ClearShoppingCart()
        {
            Stopwatch watch = Stopwatch.StartNew();

            //Add new Item to the cart.
            Profile profile = Profile.GetProfile(NAME);
            profile.ShoppingCart.Add(ID, profile.UniqueID, true);
            profile = profile.Save();

            //Clear the cart.
            profile = Profile.GetProfile(NAME);
            profile.ShoppingCart.Clear();
            profile = profile.Save();

            Assert.IsTrue(Profile.GetProfile(NAME).ShoppingCart.Count == 0);

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Deletes

        #region Delete Item

        [Test]
        public void DeleteItem()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Item item = Item.GetItem(ID);
            item.Delete();

            item = item.Save();

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Delete Supplier

        [Test]
        public void DeleteSupplier()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Supplier supplier = Supplier.GetSupplier(_supplierId);
            supplier.Delete();

            supplier = supplier.Save();

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Delete Product

        [Test]
        public void DeleteProduct()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Product product = Product.GetProduct(ID);
            product.Delete();

            product = product.Save();

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Delete Inventory

        [Test]
        public void DeleteInventory()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Inventory inventory = Inventory.GetInventory(ID);
            inventory.Delete();

            inventory = inventory.Save();

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Delete Category

        [Test]
        public void DeleteCategory()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Category category = Category.GetCategory(ID);
            category.Delete();

            category = category.Save();

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #region Delete Profile

        [Test]
        public void DeleteProfile()
        {
            Stopwatch watch = Stopwatch.StartNew();

            Profile profile = Profile.GetProfile(NAME);
            profile.Delete();

            profile = profile.Save();

            Console.WriteLine("Time: {0} ms", watch.ElapsedMilliseconds);
        }

        #endregion

        #endregion
    }
}
