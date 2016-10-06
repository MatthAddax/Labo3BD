using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DbCustomersLibrary.tests
{
    [TestClass]
    public class DbTests
    {
        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DbInitializer());
            using (CompanyContext context = GetContext())
            {
                context.Database.Initialize(true);
            }
        }

        [TestMethod]
        public void CanGetCustomers()
        {
            using (var context = GetContext())
            {
                Assert.AreEqual(1, context.Customers.ToList().Count);
            }
        }

        private CompanyContext GetContext()
        {
            return new CompanyContext();
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void AddFromDifferentSources()
        {
            using (var context1 = GetContext())
            {
                using (var context2 = GetContext()) { 

                    var customer1 = context1.Customers.ToList().First();
                    var customer2 = context2.Customers.ToList().First();

                    customer1.AccountBalance = 20;
                    context1.SaveChanges();

                    customer2.AccountBalance = 36;
                    context2.SaveChanges();
                }
            }
                

        }

    }
}
