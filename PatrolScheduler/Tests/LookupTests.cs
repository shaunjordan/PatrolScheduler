using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatrolScheduler.Database;
using PatrolScheduler.Models;
using PatrolScheduler.Services;


namespace PatrolScheduler.Tests
{
    [TestClass]
    public class LookupTests
    {
        
        [TestMethod]        
        public void Lookup_ShouldReturnCustomers()
        {                      

            ObservableCollection<CapstoneCustomer> Customers = new ObservableCollection<CapstoneCustomer>();

            using (var ctx = new CapstoneDatabase())
            {
                foreach (var cust in ctx.CapstoneCustomers)
                {
                    Customers.Add(cust);
                }
            }

            //total customers in database
            int expected = 2;

            //customers returned from the database
            int actual = Customers.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
