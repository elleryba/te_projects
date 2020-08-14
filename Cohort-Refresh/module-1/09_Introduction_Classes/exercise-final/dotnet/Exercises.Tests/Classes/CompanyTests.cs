using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechElevator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Exercises.Tests.Classes
{
    [TestClass()]
    public class CompanyTests
    {
        private Company company;
        private Type type;


        [TestInitialize]
        public void Before()
        {
            type = typeof(Company);
            company = (Company)Activator.CreateInstance(type);
        }

        [TestMethod]
        public void Company_NameProperty()
        {
            PropertyInfo prop = type.GetProperty("Name");
            PropertyValidator.ValidateReadWrite(prop, "Name", typeof(string));
        }

        [TestMethod]
        public void Company_NumberOfEmployeesProperty()
        {
            PropertyInfo prop = type.GetProperty("NumberOfEmployees");
            PropertyValidator.ValidateReadWrite(prop, "NumberOfEmployees", typeof(int));
        }

        [TestMethod]
        public void Company_RevenueProperty()
        {
            PropertyInfo prop = type.GetProperty("Revenue");
            PropertyValidator.ValidateReadWrite(prop, "Revenue", typeof(decimal));
        }

        [TestMethod]
        public void Company_ExpensesProperty()
        {
            PropertyInfo prop = type.GetProperty("Expenses");
            PropertyValidator.ValidateReadWrite(prop, "Expenses", typeof(decimal));
        }

        [TestMethod]
        public void Company_GetCompanySizeMethod()
        {
            MethodInfo mi = type.GetMethod("GetCompanySize");
            Assert.IsNotNull(mi, "A method called GetCompanySize needs to be included");
            Assert.AreEqual(typeof(string), mi.ReturnType, "The GetCompanySize() method needs to be type: string");
        }

        [TestMethod]
        public void Company_GetProfitMethod()
        {
            MethodInfo mi = type.GetMethod("GetProfit");
            Assert.IsNotNull(mi, "A method called GetProfit needs to be included");
            Assert.AreEqual(typeof(decimal), mi.ReturnType, "The GetProfit() method needs to be type: decimal");
        }

        [TestMethod]
        public void Company_CompanySizeTests()
        {
            PropertyInfo pi = type.GetProperty("NumberOfEmployees");
            MethodInfo mi = type.GetMethod("GetCompanySize");

            pi.SetValue(company, 49);
            Assert.AreEqual("small", mi.Invoke(company, null), "Company Size should be 'small' when employees are less than 50");

            pi.SetValue(company, 50);
            Assert.AreEqual("medium", mi.Invoke(company, null), "Company Size should be 'medium' when employees are between 50 and 250");

            pi.SetValue(company, 251);
            Assert.AreEqual("large", mi.Invoke(company, null), "Company Size should be 'large' when employees are greater than 250");
        }

        [TestMethod]
        public void Company_ProfitTests()
        {
            type.GetProperty("Revenue").SetValue(company, 125.51M);
            type.GetProperty("Expenses").SetValue(company, 2.50M);

            MethodInfo mi = type.GetMethod("GetProfit");
            Assert.AreEqual(123.01M, mi.Invoke(company, null), "GetProfit() should return difference between revenue and expenses.");
        }
    }
}