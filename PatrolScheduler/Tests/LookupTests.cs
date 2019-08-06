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


        [TestMethod]
        public void EmployeesShouldAddToDataBase()
        {
            int expected = 6; //total of employees in the database currently is 5
             
            ObservableCollection<CapstoneEmployee> Employees = new ObservableCollection<CapstoneEmployee>();
            CapstoneEmployee testEmp = new CapstoneEmployee()
            {
                
                FirstName = "Test",
                LastName = "Test",
                HireDate = DateTime.Parse("01/01/2019")
            };

            using (var ctx = new CapstoneDatabase())
            {
                ctx.CapstoneEmployees.Add(testEmp);
                ctx.SaveChanges();
            }

            using (var ctx = new CapstoneDatabase())
            {

                foreach (var emp in ctx.CapstoneEmployees)
                {
                    Employees.Add(emp);
                }

            }


            int actual = Employees.Count;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void EmployeeShouldBeDeletedFromTheDatabase()
        {
            int expected = 5; //total of employees in the database currently is 6

            ObservableCollection<CapstoneEmployee> Employees = new ObservableCollection<CapstoneEmployee>();
            

            using (var ctx = new CapstoneDatabase())
            {
                ctx.CapstoneEmployees.Remove(ctx.CapstoneEmployees.Single(a => a.FirstName == "Test"));
                ctx.SaveChanges();
            }

            using (var ctx = new CapstoneDatabase())
            {

                foreach (var emp in ctx.CapstoneEmployees)
                {
                    Employees.Add(emp);
                }

            }


            int actual = Employees.Count;

            Assert.AreEqual(expected, actual);
        }

    }
}
