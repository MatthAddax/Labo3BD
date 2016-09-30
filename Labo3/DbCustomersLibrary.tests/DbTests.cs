using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

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
        public void AddFromDifferentSources()
        {
            using (var context = GetContext())
            {
                var customer = context.Customers.ToList().First();
                double actualBalance = customer.AccountBalance;
                double addFirst = 15.21;
                double addSecond = 10;

                customer.AccountBalance = actualBalance + addFirst;
                context.SaveChanges();
                customer.AccountBalance = actualBalance + addSecond;
                context.SaveChanges();

                Assert.AreEqual(10, context.Customers.ToList().First().AccountBalance);
            }
        }
    }
}
