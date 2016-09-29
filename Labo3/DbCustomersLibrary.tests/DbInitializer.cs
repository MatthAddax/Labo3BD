using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbCustomersLibrary;

namespace DbCustomersLibrary.tests
{
    class DbInitializer : DropCreateDatabaseAlways<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            Customer customer = new Customer()
            {
                Name = "Albert Dupont",
                AddressLine1 = "Rue des cerisiers, 16",
                City = "Arlon",
                Email = "info@me.be",
                Id = 3,
                Remark = "Ne pas avoir peur des chiens pour aller chez ce client",
                Postcode = "6700"
            };

            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}
