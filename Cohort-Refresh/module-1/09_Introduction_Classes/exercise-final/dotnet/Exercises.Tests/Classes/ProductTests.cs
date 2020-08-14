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
    public class ProductTests
    {
        private Type type;
        private Product product;

        [TestInitialize]
        public void Before()
        {
            type = typeof(Product);
            product = (Product)Activator.CreateInstance(type);
        }

        [TestMethod]
        public void Product_NameProperty()
        {
            PropertyInfo prop = type.GetProperty("Name");
            PropertyValidator.ValidateReadWrite(prop, "Name", typeof(string));
        }

        [TestMethod]
        public void Product_PriceProperty()
        {
            PropertyInfo prop = type.GetProperty("Price");
            PropertyValidator.ValidateReadWrite(prop, "Price", typeof(decimal));
        }

        [TestMethod]
        public void Product_WeightProperty()
        {
            PropertyInfo prop = type.GetProperty("WeightInOunces");
            PropertyValidator.ValidateReadWrite(prop, "WeightInOunces", typeof(double));
        }
    }
}