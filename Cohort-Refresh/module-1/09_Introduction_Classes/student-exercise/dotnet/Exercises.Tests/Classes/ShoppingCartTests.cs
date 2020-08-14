using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechElevator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Exercises.Tests;

namespace TechElevator.Classes.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        private Type type;
        private ShoppingCart cart;

        [TestInitialize]
        public void Before()
        {
            type = typeof(ShoppingCart);
            cart = (ShoppingCart)Activator.CreateInstance(type);
        }

        [TestMethod]
        public void ShoppingCart_TotalNumberOfItemsProperty()
        {
            PropertyInfo prop = type.GetProperty("TotalNumberOfItems");
            PropertyValidator.ValidateReadOnly(prop, "TotalNumberOfItems", typeof(int));
        }

        [TestMethod]
        public void ShoppingCart_TotalAmountOwedProperty()
        {
            PropertyInfo prop = type.GetProperty("TotalAmountOwed");
            PropertyValidator.ValidateReadOnly(prop, "TotalAmountOwed", typeof(decimal));
        }

        [TestMethod]
        public void ShoppingCart_GetAveragePricePerItemMethod()
        {
            MethodInfo mi = type.GetMethod("GetAveragePricePerItem");
            Assert.IsNotNull(mi, "Shopping cart class needs the GetAveragePricePerItem method.");
            Assert.AreEqual(typeof(decimal), mi.ReturnType, "GetAveragePricePerItem() method needs to return type: double");
            Assert.AreEqual(0, mi.GetParameters().Length, "GetAveragePricePerItem() should have no parameters");
        }

        [TestMethod]
        public void ShoppingCart_AddItemsMethod()
        {
            MethodInfo mi = type.GetMethod("AddItems");
            Assert.IsNotNull(mi, "Shopping cart class needs the AddItems method.");
            Assert.AreEqual(typeof(void), mi.ReturnType, "AddItems() method needs to return type: void");
            Assert.AreEqual(2, mi.GetParameters().Length);
        }

        [TestMethod]
        public void ShoppingCart_EmptyMethod()
        {
            MethodInfo mi = type.GetMethod("Empty");
            Assert.IsNotNull(mi, "Shopping cart class needs the Empty method.");
            Assert.AreEqual(typeof(void), mi.ReturnType, "Empty() method needs to return type: void");
            Assert.AreEqual(0, mi.GetParameters().Length);
        }

        [TestMethod()]
        public void ShoppingCart_DefaultCart()
        {
            PropertyInfo prop = type.GetProperty("TotalNumberOfItems");
            Assert.AreEqual(0, prop.GetValue(cart), "TotalNumberOfItems should be 0 for new carts.");

            prop = type.GetProperty("TotalAmountOwed");
            Assert.AreEqual(0.0M, prop.GetValue(cart), "TotalAmountOwed should be 0.0 for new carts.");
        }

        [TestMethod]
        public void ShoppingCart_GetAveragericePerItem()
        {
            MethodInfo mi = type.GetMethod("GetAveragePricePerItem");

            type.GetProperty("TotalNumberOfItems").SetValue(cart, 0);
            type.GetProperty("TotalAmountOwed").SetValue(cart, 0.0M);

            Assert.AreEqual(0.0M, mi.Invoke(cart, null), "The average price per item of an empty cart is 0.0");

            type.GetProperty("TotalNumberOfItems").SetValue(cart, 2);
            type.GetProperty("TotalAmountOwed").SetValue(cart, 5M);

            Assert.AreEqual(2.5M, mi.Invoke(cart, null), "The average price per item is totalAmountOwed / totalNumberOfItems");
        }

        [TestMethod()]
        public void ShoppingCart_AddItemTest()
        {
            MethodInfo mi = type.GetMethod("AddItems");

            //Reset the cart
            type.GetProperty("TotalNumberOfItems").SetValue(cart, 0);
            type.GetProperty("TotalAmountOwed").SetValue(cart, 0.0M);

            mi.Invoke(cart, new object[] { 2, 2.10M });

            Assert.AreEqual(2, type.GetProperty("TotalNumberOfItems").GetValue(cart), "AddItems should add numberOfItems to totalNumberOfItems");
            Assert.AreEqual(4.20M, type.GetProperty("TotalAmountOwed").GetValue(cart), "AddItems should add pricePerItem * numberOfItems to totalAmountOwed");
        }

        [TestMethod()]
        public void ShoppingCart_EmptyTest()
        {
            MethodInfo mi = type.GetMethod("Empty");

            //Reset the cart
            type.GetProperty("TotalNumberOfItems").SetValue(cart, 5);
            type.GetProperty("TotalAmountOwed").SetValue(cart, 10.0M);

            mi.Invoke(cart, null);

            Assert.AreEqual(0, type.GetProperty("TotalNumberOfItems").GetValue(cart), "Empty should reset totalNumberOfItems to 0");
            Assert.AreEqual(0.0M, type.GetProperty("TotalAmountOwed").GetValue(cart), "Empty should reset totalAmountOwed to 0.0");
        }
    }
}